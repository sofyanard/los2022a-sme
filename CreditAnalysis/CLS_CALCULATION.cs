using System;
using Microsoft.VisualBasic;
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.CreditAnalysis
{
	/// <summary>
	/// Summary description for CLS_CALCULATION.
	/// </summary>
	public class CLS_CALCULATION
	{
		public CLS_CALCULATION()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region middle_calculation 
		public static bool proses_calculate(System.Web.UI.Page page, string regno, string curef, string tahun, Connection conn)
		{
			conn.QueryString = "SELECT AP_REGNO FROM CA_NERACA_MIDDLE " +
				"WHERE AP_REGNO = '" + regno + "' AND BS_TTL_ASST <> BS_LIAB_NETWORTH ";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)	//neraca not balanced
			{
				GlobalTools.popMessage(page,"Total Asset dan Liabilities Net Worth pada Neraca belum sama !! ");
				//delete ratios if exists 
				delete_ratio(regno,conn);
				return false;
			}

			if (!compare_neraca_labarugi(page, regno, curef, conn)) 
			{
				//delete ratios if exists 
				page.Response.Write("<!-- delete ratio middle -->");
				delete_ratio(regno,conn);
				return false;
			}

			page.Response.Write("<!-- inisialisasi utk ratio -->");

			// --- inisialisasi utk ratio ----
			double[] vSalesGrowthRate = new double[10]; 
			string[] vSalesGrowthRate_1 = new string[10]; 
			
			double[] vROE = new double[10];
			double[] buROE = new double[10];

			string[] vROE_1 = new string[10];

			double[] vROA = new double[10];
			double[] buROA = new double[10];

			string[] vROA_1 = new string[10];
			
			double[] vInterest = new double[10];
			string[] vInterest_1 = new string[10];
			double[] vSales = new double[10];
			string[] vSales_1 = new string[10];
			double[] vCurrentRatio = new double[10];
			string[] vCurrentRatio_1 = new string[10];
			double[] vQuickAssetRatio = new double[10];
			string[] vQuickAssetRatio_1 = new string[10];
			double[] vDaysReceiv = new double[5];
			string[] vDaysReceiv_1 = new string[5];
			double[] vDaysInventory = new double[5];
			string[] vDaysInventory_1 = new string[5];
			double[] vDaysPayable = new double[5];
			string[] vDaysPayable_1 = new string[5];
			double[] vDaysTC = new double[5];
			string[] vDaysTC_1 = new string[5];
			double[] vDebtEquity = new double[10];
			string[] vDebtEquity_1 = new string[10];
			double[] vLeverage = new double[10];
			string[] vLeverage_1 = new string[10];
			double[] vLongTermLev = new double[10];
			string[] vLongTermLev_1 = new string[10];
			double[] vTimeIntrstEarn = new double[10];
			string[] vTimeIntrstEarn_1 = new string[10];
			double[] vDebtServiceCov = new double[10];
			string[] vDebtServiceCov_1 = new string[10];

			double[] dSALES_TO_WK_CAPITAL = new double[10];
			string[] sSALES_TO_WK_CAPITAL = new string[10];

			double[] dDEBT_TO_NETWORTH = new double[10];
			string[] sDEBT_TO_NETWORTH = new string[10];

			double[] dBUSINESS_DEBT_SERV_RATIO = new double[10];	
			string[] sBUSINESS_DEBT_SERV_RATIO = new string[10];	
			double[] dPenyebut_SalesToWkCapital = new double[10];

			string[] No_of_Months = new string[10];
			string[] Sales_on_Credit =  new string[10];
			string[] ReportType = new string[10];
			string[] Posisi = new string[10];

			//---- 22 ratio --------
			DateTime[] dtTahun = new DateTime[10];
			int[] intTahun = new int[10];

			double[] DebtToAsset = new double[10];
			string[] DebtToAsset_1 = new string[10];

			double[] DebtToCapital = new double[10];
			string[] DebtToCapital_1 = new string[10];

			double[] AbsoluteDebtToEquity = new double[10];
			string[] AbsoluteDebtToEquity_1 = new string[10];

			double[] LongTermDebtToEquity = new double[10];
			string[] LongTermDebtToEquity_1 = new string[10];	
			//------- cahflow ------------------------
			double[] EbitdaToInterestExp = new double[10];
			string[] EbitdaToInterestExp_1 = new string[10];

			double[] EbitdaToDebt = new double[10];
			string[] EbitdaToDebt_1 = new string[10];
							
			double[] EbitdaToLiab = new double[10];
			string[] EbitdaToLiab_1 = new string[10];

			double[] OperatingCFToDebt = new double[10];
			string[] OperatingCFToDebt_1 = new string[10];
						
			double[] OperatingCFToInterestExp = new double[10];
			string[] OperatingCFToInterestExp_1 = new string[10];	
			//------- profitability ------------------------
			double[] NetMargin = new double[10];
			string[] NetMargin_1 = new string[10];

			double[] OperatingMargin = new double[10];
			string[] OperatingMargin_1 = new string[10];
			
			//------- Activity ------------------------	
			double[] AssetsTurnOver = new double[10];
			string[] AssetsTurnOver_1 = new string[10];

			double[] InventoryTurnOver = new double[10];
			string[] InventoryTurnOver_1 = new string[10];

			double[] ReceivableTurnOver = new double[10];
			string[] ReceivableTurnOver_1 = new string[10];

			double[] FixedAssetTurnOver = new double[10];
			string[] FixedAssetTurnOver_1 = new string[10];	
			//------- Growth ------------------------	
			double[] EbitdaGrowth = new double[10];
			string[] EbitdaGrowth_1 = new string[10];

			double[] SalesGrowth = new double[10];
			string[] SalesGrowth_1 = new string[10];	

			double[] NetIncomeGrowth = new double[10];
			string[] NetIncomeGrowth_1 = new string[10];

			double prevBS21=0.00, prevBS23=0.00, prevBS39=0.00;
			double prevIS14=0.00, prevIS21=0.00,prevIS23=0.00,prevIS24=0.00,prevIS25=0.00,prevIS26=0.00,prevIS29=0.00, prevIS33=0.00, prevIS28=0.00, prevIS27=0.00;
			double prevBS34 = 0.00, prevBS38 = 0.00, prevBS44 = 0.00, prevBS47 = 0.00, prevBS55 = 0.00;

			/* NEW VAR FOR ASHARI - Rating/STW*/
			double 	dSalesIncrease, dNetIncomeIncrease, dAverageNetProfit;

			/*******************************/
			/*** 2010-01-06, Scoring ILP ***/
			/*******************************/
			double[] NetWorkingCapital = new Double[10];
			double[] GrossProfitMargin = new Double[10];
			double[] EBITDA = new Double[10];
			double[] OperatingProfitMargin = new Double[10];
			double[] NetProfitMargin = new Double[10];
			double[] TotalEquity = new Double[10];
			double[] Leverage = new Double[10];
			double[] InterestCoverageRatio = new Double[10];
			double[] DebttoEBITDA = new Double[10];
			double[] DSC = new Double[10];
			double[] InteresttoSalesRatio  = new Double[10];
			double[] AccPayableTurnover  = new Double[10];

			double currEBITDA = 0.00, prevEBITDA = 0.00;

			/********************************/
			/******RATING MULTIFINANCE*******/
			/********** 2011-02-16 **********/
			/******* Prasetyo Wibowo ********/
			/********************************/

			double[] NetTradeCycle  = new Double[10];
			double[] GearingRatio = new Double[10];
			double[] NetRevenuePerMonth = new Double[10];
			double[] AccReceivabletoAsset = new Double[10];
			double[] AccReceivabletoLiability = new Double[10];
			double[] EquityToAssets = new Double[10];
			double[] AssetGrowth = new Double[10];
			double[] ReceivablesGrowth = new Double[10];
			double[] EquityGrowth = new Double[10];
			double[] EficiencyRatio = new Double[10];
			double[] TotalAsset = new Double[10];

			/* added this piece of codes to clear all previous ratio before recalculation */
			conn.QueryString = "delete from ca_ratio_middle where ap_regno = '" + regno + "'" ;
			conn.ExecuteQuery();

			conn.QueryString = "select CU_REF,AP_REGNO,BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,BS_SALES_ONCR,BS_CASH_BANK" +
				",BS_MARKET_SECUR,BS_AR,BS_AR_FRAFFIL,BS_INVENTORY,BS_OTH_CURASST,BS_PREPAID_EXP,BS_CURRASST" +
				",BS_NETFIXASST,BS_INVESTMENT,BS_NONCA,BS_NI,BS_TTL_NONCA,BS_TTL_ASST,BS_DBST,BS_AP,BS_AP_TOAFFL " +
				",BS_ACCRUALS,BS_TAXPAY,BS_OTH_CURLIAB,BS_CURR_PORTLTDEBT,BS_CURR_LIAB,BS_LONGTERM_DEBT,BS_OTH_LIAB" +
				",BS_LONGTERM_LIAB,BS_TTL_LIAB,BS_CMN_STK,BS_SURP_RESRV,BS_RET_EARN,BS_TTL_NETWORTH,BS_LIAB_NETWORTH" +
				",BS_CURRENCY,BS_DENOMINATOR,BS_SUMBERDATA,BS_ISPROYEKSI,IS_SALES_ONCR,IS_NET_SALES,IS_COST_GS" +
				",IS_PROSEN1,IS_GROSS_MARGIN,IS_PROSEN2,IS_SELLING_GENADM,IS_PROSEN3,IS_OPR_EARN,IS_PROSEN4,IS_DEPRECIATE" +
				",IS_AMORTIZATION1,IS_AMORTIZATION2,IS_OTH_INCM_NET,IS_EXTRAORD,IS_EARN_BIT" +
				",IS_INTRST_EXP,IS_EARN_BT,IS_PROSEN5,IS_INCM_TAX,IS_NET_INCM,IS_PROSEN6,IS_CURRENCY" +
				",IS_DENOMINATOR,IS_SUMBERDATA,IS_ISPROYEKSI from vw_ca_hitung_rasio where ap_regno = '" + regno + "' and year(bs_date_periode) <= '" + tahun + "' order by bs_date_periode asc";
			conn.ExecuteQuery();

			System.Data.DataTable dtCurrent = new System.Data.DataTable();
			dtCurrent = conn.GetDataTable().Copy();

			for (int i=0;i<dtCurrent.Rows.Count;i++)
			{
				
				/*
							12	Date                        	BS_DATE_PERIODE                                        
							13	Number of Months      		BS_NUM_MONTH 
							14	Sales on Credit %		BS_REPORTTYPE                                      
														BS_SALES_ONCR 
	 			
								ASSETS	
							19	Cash & Bank	BS_CASH_BANK                                          
							20	Marketable Securities	BS_MARKET_SECUR                                       
							21	Accounts Receivable	BS_AR                                                 
							22	Accounts Receivable fr Affiliated	BS_AR_FRAFFIL                                         
							23	Inventory	BS_INVENTORY                                          
							24	Other Current Assets	BS_OTH_CURASST                                        
							25	Prepaid Expenses	BS_PREPAID_EXP                                        
							26	Current Assets	BS_CURRASST                                           
						
							28	Net Fixed Assets	BS_NETFIXASST                                         
							29	Investments	BS_INVESTMENT                                         
							30	Net Other Non Current Assets	BS_NONCA                                              
							31	Net Intangibles	BS_NI                                                 
							32	Total Non Current Assets	BS_TTL_NONCA                                          
				
						
							34	Total Assets	BS_TTL_ASST                                           
						
						
								LIABILITIES + EQUITY	
							38	Due Banks, Short Term	BS_DBST                                               
							39	Accounts Payable	BS_AP                                                 
							40	Accounts Payable to Affiliated	BS_AP_TOAFFL                                          
							41	Accruals	BS_ACCRUALS                                           
							42	Taxes Payable	BS_TAXPAY                                             
							43	Other Current Liabilities	BS_OTH_CURLIAB                                        
							44	Current Portion L T Debt	BS_CURR_PORTLTDEBT                                    
								Current Liabilities	BS_CURR_LIAB                                          
						
							47	Long Term Debt	BS_LONGTERM_DEBT                                      
							48	Other Liab, Long Term	BS_OTH_LIAB                                           
							49	Long Term Liabilities	BS_LONGTERM_LIAB                                      
							50	Total Liabilities	BS_TTL_LIAB                                           
						
							52	Common Stock	BS_CMN_STK                                            
							53	Surplus & Reserves	BS_SURP_RESRV                                         
							54	Retained Earnings	BS_RET_EARN                                           
							55	Total Net Worth	BS_TTL_NETWORTH                                       
						
							57	Liabilities + Net Worth	BS_LIAB_NETWORTH                                      

			*/
				int BS13;
				double BS14;
				double BS19, BS20, BS21, BS22, BS23, BS24, BS25, BS26, BS28, BS29, BS30, BS31, BS32;
				double BS34, BS38, BS39, BS40, BS41, BS42, BS43, BS44, BS45, BS47, BS48, BS49, BS50, BS52;
				double BS53, BS54, BS55, BS57;
				double IS14, IS15, IS16, IS17, IS18, IS19, IS20, IS21, IS22;
				double IS23, IS24, IS25, IS26, IS27, IS28, IS29, IS30, IS31;
				double IS32, IS33, IS34;
				
				BS13 = Convert.ToInt32(dtCurrent.Rows[i]["BS_NUM_MONTH"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["BS_SALES_ONCR"].ToString())=="" || dtCurrent.Rows[i]["BS_SALES_ONCR"].ToString()==null)  BS14 = 0.0;
				else BS14 = Convert.ToDouble(dtCurrent.Rows[i]["BS_SALES_ONCR"].ToString());
				
				No_of_Months[i] = Convert.ToString(BS13);
				Sales_on_Credit[i] =  Convert.ToString(BS14);
				ReportType[i] = dtCurrent.Rows[i]["BS_ReporTType"].ToString();
				Posisi[i]= Convert.ToString(dtCurrent.Rows[i]["BS_DATE_PERIODE"].ToString());

				//------------------------- start sales growrate ------------------------------//
				if (Strings.Trim(dtCurrent.Rows[i]["BS_CASH_BANK"].ToString())=="" || dtCurrent.Rows[i]["BS_CASH_BANK"].ToString()==null)  BS19 = 0.0;
				else BS19 = Convert.ToDouble(dtCurrent.Rows[i]["BS_CASH_BANK"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["BS_MARKET_SECUR"].ToString())=="" || dtCurrent.Rows[i]["BS_MARKET_SECUR"].ToString()==null)  BS20 = 0.0;
				else BS20 = Convert.ToDouble(dtCurrent.Rows[i]["BS_MARKET_SECUR"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["BS_AR"].ToString())=="" || dtCurrent.Rows[i]["BS_AR"].ToString()==null)  BS21 = 0.0;
				else BS21 = Convert.ToDouble(dtCurrent.Rows[i]["BS_AR"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["BS_AR_FRAFFIL"].ToString())=="" || dtCurrent.Rows[i]["BS_AR_FRAFFIL"].ToString()==null)  BS22 = 0.0;
				else BS22 = Convert.ToDouble(dtCurrent.Rows[i]["BS_AR_FRAFFIL"].ToString());
		
				if (Strings.Trim(dtCurrent.Rows[i]["BS_INVENTORY"].ToString())=="" || dtCurrent.Rows[i]["BS_INVENTORY"].ToString()==null)  BS23 = 0.0;
				else BS23 = Convert.ToDouble(dtCurrent.Rows[i]["BS_INVENTORY"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["BS_OTH_CURASST"].ToString())=="" || dtCurrent.Rows[i]["BS_OTH_CURASST"].ToString()==null)  BS24 = 0.0;
				else BS24 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_OTH_CURASST"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["BS_PREPAID_EXP"].ToString())=="" || dtCurrent.Rows[i]["BS_PREPAID_EXP"].ToString()==null)  BS25 = 0.0;
				else BS25 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_PREPAID_EXP"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["BS_CURRASST"].ToString())=="" || dtCurrent.Rows[i]["BS_CURRASST"].ToString()==null)  BS26 = 0.0;
				else BS26 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_CURRASST"].ToString());
				
				//else BS27 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_AR_FRAFFIL"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["BS_NETFIXASST"].ToString())=="" || dtCurrent.Rows[i]["BS_NETFIXASST"].ToString()==null)  BS28 = 0.0;
				else BS28 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_NETFIXASST"].ToString());
				

				if (Strings.Trim(dtCurrent.Rows[i]["BS_INVESTMENT"].ToString())=="" || dtCurrent.Rows[i]["BS_INVESTMENT"].ToString()==null)  BS29 = 0.0;
				else BS29 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_INVESTMENT"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["BS_NONCA"].ToString())=="" || dtCurrent.Rows[i]["BS_NONCA"].ToString()==null)  BS30 = 0.0;
				else BS30 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_NONCA"].ToString());
				

				if (Strings.Trim(dtCurrent.Rows[i]["BS_NI"].ToString())=="" || dtCurrent.Rows[i]["BS_NI"].ToString()==null)  BS31 = 0.0;
				else BS31 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_NI"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["BS_TTL_NONCA"].ToString())=="" || dtCurrent.Rows[i]["BS_TTL_NONCA"].ToString()==null)  BS32 = 0.0;
				else BS32 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_TTL_NONCA"].ToString());


				if (Strings.Trim(dtCurrent.Rows[i]["BS_TTL_ASST"].ToString())=="" || dtCurrent.Rows[i]["BS_TTL_ASST"].ToString()==null)  BS34 = 0.0;
				else BS34 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_TTL_ASST"].ToString());
				

				if (Strings.Trim(dtCurrent.Rows[i]["BS_DBST"].ToString())=="" || dtCurrent.Rows[i]["BS_DBST"].ToString()==null)  BS38 = 0.0;
				else BS38 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_DBST"].ToString());
				

				if (Strings.Trim(dtCurrent.Rows[i]["BS_AP"].ToString())=="" || dtCurrent.Rows[i]["BS_AP"].ToString()==null)  BS39 = 0.0;
				else BS39 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_AP"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["BS_AP_TOAFFL"].ToString())=="" || dtCurrent.Rows[i]["BS_AP_TOAFFL"].ToString()==null)  BS40 = 0.0;
				else BS40 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_AP_TOAFFL"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["BS_ACCRUALS"].ToString())=="" || dtCurrent.Rows[i]["BS_ACCRUALS"].ToString()==null)  BS41 = 0.0;
				else BS41 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_ACCRUALS"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["BS_TAXPAY"].ToString())=="" || dtCurrent.Rows[i]["BS_TAXPAY"].ToString()==null)  BS42 = 0.0;
				else BS42 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_TAXPAY"].ToString());
			
				if (Strings.Trim(dtCurrent.Rows[i]["BS_OTH_CURLIAB"].ToString())=="" || dtCurrent.Rows[i]["BS_OTH_CURLIAB"].ToString()==null)  BS43 = 0.0;
				else BS43 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_OTH_CURLIAB"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["BS_CURR_PORTLTDEBT"].ToString())=="" || dtCurrent.Rows[i]["BS_CURR_PORTLTDEBT"].ToString()==null)  BS44 = 0.0;
				else BS44 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_CURR_PORTLTDEBT"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["BS_CURR_LIAB"].ToString())=="" || dtCurrent.Rows[i]["BS_CURR_LIAB"].ToString()==null)  BS45 = 0.0;
				else BS45 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_CURR_LIAB"].ToString());

				// else BS46 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_LONGTERM_DEBT"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["BS_LONGTERM_DEBT"].ToString())=="" || dtCurrent.Rows[i]["BS_LONGTERM_DEBT"].ToString()==null)  BS47 = 0.0;				
				else BS47 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_LONGTERM_DEBT"].ToString());


				if (Strings.Trim(dtCurrent.Rows[i]["BS_OTH_LIAB"].ToString())=="" || dtCurrent.Rows[i]["BS_OTH_LIAB"].ToString()==null)  BS48 = 0.0;
				else BS48 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_OTH_LIAB"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["BS_LONGTERM_LIAB"].ToString())=="" || dtCurrent.Rows[i]["BS_LONGTERM_LIAB"].ToString()==null)  BS49 = 0.0;
				else BS49 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_LONGTERM_LIAB"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["BS_TTL_LIAB"].ToString())=="" || dtCurrent.Rows[i]["BS_TTL_LIAB"].ToString()==null)  BS50 = 0.0;
				else BS50 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_TTL_LIAB"].ToString());

				//else BS51 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_SURP_RESRV"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["BS_CMN_STK"].ToString())=="" || dtCurrent.Rows[i]["BS_CMN_STK"].ToString()==null)  BS52 = 0.0;
				else BS52 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_CMN_STK"].ToString());


				if (Strings.Trim(dtCurrent.Rows[i]["BS_SURP_RESRV"].ToString())=="" || dtCurrent.Rows[i]["BS_SURP_RESRV"].ToString()==null)  BS53 = 0.0;
				else BS53 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_SURP_RESRV"].ToString());


				if (Strings.Trim(dtCurrent.Rows[i]["BS_RET_EARN"].ToString())=="" || dtCurrent.Rows[i]["BS_RET_EARN"].ToString()==null)  BS54 = 0.0;
				else BS54 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_RET_EARN"].ToString());


				if (Strings.Trim(dtCurrent.Rows[i]["BS_TTL_NETWORTH"].ToString())=="" || dtCurrent.Rows[i]["BS_TTL_NETWORTH"].ToString()==null)  BS55 = 0.0;
				else BS55 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_TTL_NETWORTH"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["BS_LIAB_NETWORTH"].ToString())=="" || dtCurrent.Rows[i]["BS_LIAB_NETWORTH"].ToString()==null)  BS57 = 0.0;
				else BS57 =	Convert.ToDouble(dtCurrent.Rows[i]["BS_LIAB_NETWORTH"].ToString());

				
				if (Strings.Trim(dtCurrent.Rows[i]["IS_NET_SALES"].ToString())=="" || dtCurrent.Rows[i]["IS_NET_SALES"].ToString()==null)  IS14 = 0.0;
				else IS14   = Convert.ToDouble(dtCurrent.Rows[i]["IS_NET_SALES"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IS_COST_GS"].ToString())=="" || dtCurrent.Rows[i]["IS_COST_GS"].ToString()==null)  IS15 = 0.0;
				else IS15   = Convert.ToDouble(dtCurrent.Rows[i]["IS_COST_GS"].ToString());
								
				if (Strings.Trim(dtCurrent.Rows[i]["IS_PROSEN1"].ToString())=="" || dtCurrent.Rows[i]["IS_PROSEN1"].ToString()==null)  IS16 = 0.0;
				else IS16   = Convert.ToDouble(dtCurrent.Rows[i]["IS_PROSEN1"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IS_GROSS_MARGIN"].ToString())=="" || dtCurrent.Rows[i]["IS_GROSS_MARGIN"].ToString()==null)  IS17 = 0.0;
				else IS17   = Convert.ToDouble(dtCurrent.Rows[i]["IS_GROSS_MARGIN"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["IS_PROSEN2"].ToString())=="" || dtCurrent.Rows[i]["IS_PROSEN2"].ToString()==null)  IS18 = 0.0;
				else IS18   = Convert.ToDouble(dtCurrent.Rows[i]["IS_PROSEN2"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["IS_SELLING_GENADM"].ToString())=="" || dtCurrent.Rows[i]["IS_SELLING_GENADM"].ToString()==null)  IS19 = 0.0;
				else IS19   = Convert.ToDouble(dtCurrent.Rows[i]["IS_SELLING_GENADM"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["IS_PROSEN3"].ToString())=="" || dtCurrent.Rows[i]["IS_PROSEN3"].ToString()==null)  IS20 = 0.0;
				else IS20   = Convert.ToDouble(dtCurrent.Rows[i]["IS_PROSEN3"].ToString());


				if (Strings.Trim(dtCurrent.Rows[i]["IS_OPR_EARN"].ToString())=="" || dtCurrent.Rows[i]["IS_OPR_EARN"].ToString()==null)  IS21 = 0.0;
				else IS21   = Convert.ToDouble(dtCurrent.Rows[i]["IS_OPR_EARN"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["IS_PROSEN4"].ToString())=="" || dtCurrent.Rows[i]["IS_PROSEN4"].ToString()==null)  IS22 = 0.0;
				else IS22   = Convert.ToDouble(dtCurrent.Rows[i]["IS_PROSEN4"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["IS_DEPRECIATE"].ToString())=="" || dtCurrent.Rows[i]["IS_DEPRECIATE"].ToString()==null)  IS23 = 0.0;
				else IS23   = Convert.ToDouble(dtCurrent.Rows[i]["IS_DEPRECIATE"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["IS_AMORTIZATION1"].ToString())=="" || dtCurrent.Rows[i]["IS_AMORTIZATION1"].ToString()==null)  IS24 = 0.0;
				else IS24   = Convert.ToDouble(dtCurrent.Rows[i]["IS_AMORTIZATION1"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["IS_AMORTIZATION2"].ToString())=="" || dtCurrent.Rows[i]["IS_AMORTIZATION2"].ToString()==null)  IS25 = 0.0;
				else IS25   = Convert.ToDouble(dtCurrent.Rows[i]["IS_AMORTIZATION2"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["IS_OTH_INCM_NET"].ToString())=="" || dtCurrent.Rows[i]["IS_OTH_INCM_NET"].ToString()==null)  IS26 = 0.0;
				else IS26   = Convert.ToDouble(dtCurrent.Rows[i]["IS_OTH_INCM_NET"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["IS_EXTRAORD"].ToString())=="" || dtCurrent.Rows[i]["IS_EXTRAORD"].ToString()==null)  IS27 = 0.0;
				else IS27   = Convert.ToDouble(dtCurrent.Rows[i]["IS_EXTRAORD"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["IS_EARN_BIT"].ToString())=="" || dtCurrent.Rows[i]["IS_EARN_BIT"].ToString()==null)  IS28 = 0.0;
				else IS28   = Convert.ToDouble(dtCurrent.Rows[i]["IS_EARN_BIT"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["IS_INTRST_EXP"].ToString())=="" || dtCurrent.Rows[i]["IS_INTRST_EXP"].ToString()==null)  IS29 = 0.0;
				else IS29   = Convert.ToDouble(dtCurrent.Rows[i]["IS_INTRST_EXP"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["IS_EARN_BT"].ToString())=="" || dtCurrent.Rows[i]["IS_EARN_BT"].ToString()==null)  IS30 = 0.0;
				else IS30   = Convert.ToDouble(dtCurrent.Rows[i]["IS_EARN_BT"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["IS_PROSEN5"].ToString())=="" || dtCurrent.Rows[i]["IS_PROSEN5"].ToString()==null)  IS31 = 0.0;
				else IS31   = Convert.ToDouble(dtCurrent.Rows[i]["IS_PROSEN5"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["IS_INCM_TAX"].ToString())=="" || dtCurrent.Rows[i]["IS_INCM_TAX"].ToString()==null)  IS32 = 0.0;
				else IS32   = Convert.ToDouble(dtCurrent.Rows[i]["IS_INCM_TAX"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["IS_NET_INCM"].ToString())=="" || dtCurrent.Rows[i]["IS_NET_INCM"].ToString()==null)  IS33 = 0.0;
				else IS33   = Convert.ToDouble(dtCurrent.Rows[i]["IS_NET_INCM"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["IS_PROSEN6"].ToString())=="" || dtCurrent.Rows[i]["IS_PROSEN6"].ToString()==null)  IS34 = 0.0;
				else IS34   = Convert.ToDouble(dtCurrent.Rows[i]["IS_PROSEN6"].ToString());

				
				/*******************************/
				/*** 2010-01-06, Scoring ILP ***/
				/*** Set default devider     ***/
				/*******************************/
				double ddef = 0.01;
				
				
				if ((i != 0) && (Math.Abs(BS13) > 0.000001) && (Math.Abs(prevIS14) > 0.000001)) 
					vSalesGrowthRate[i]  = 100 * (((IS14 * (12 / BS13)) - prevIS14) / prevIS14);
				else
					vSalesGrowthRate[i] = 0.00;

				
				double temp1 = 0.0;
				if (i != 0) 
				{
					temp1 = ((BS38 + BS44 + BS47) + (prevBS38 + prevBS44 + prevBS47)) / 2.00;
					
					if (Math.Abs(temp1) < 0.000001 || Math.Abs(BS13) < 0.000001)
						vInterest[i] = 0.00;
					else
						vInterest[i] = 100 * ((IS29 * (12.0 / ((double)BS13))) / temp1);
				}
				else if (i == 0)
				{
					temp1 = ((BS38 + BS44 + BS47) + (BS38 + BS44 + BS47)) / 2.00;
					
					if (Math.Abs(temp1) < 0.000001 || Math.Abs(BS13) < 0.000001)
						vInterest[i] = 0.00;
					else
						vInterest[i] = 100 * ((IS29 * (12.0 / ((double)BS13))) / temp1);
				}
				else vInterest[i] = 0.00;

				
				double temp2 = 0.0;
				if (i != 0)
				{ 
					temp2 = (prevBS34 + BS34) / 2.00;
					if (Math.Abs(temp2) < 0.000001 || Math.Abs(BS13) < 0.000001)
						vSales[i] = 0;
					else
						vSales[i] = (IS14 * (12.0 / (double)BS13)) / temp2;
				}
				else if (i == 0)
				{ 
					temp2 = (BS34 + BS34) / 2.0;
					if (Math.Abs(temp2) < 0.000001 || Math.Abs(BS13) < 0.000001)
						vSales[i] = 0.00;
					else
						vSales[i] = (IS14 * (12.0 / (double)BS13)) / temp2;
				}
				else vSales[i] = 0;


				// BU Calculation on ROE
				if (Math.Abs(BS55) > 0.000001)
				{
					if (IS33 < 0.0 && BS55 < 0.0)
						buROE[i] = -1.0 * IS33 / BS55;
					else
						buROE[i] = IS33 / BS55;
				}
				else
					buROE[i] = IS33 / ddef;

				
				// BU Calculation on ROA ---- take posisi
				if (Math.Abs(BS34) > 0.000001)
					buROA[i] = IS33 / BS34;
				else
					buROA[i] = IS33 / ddef;

				
				/***
				// PORM calculation ---- take average ASSET
				if (i != 0)
				{
					if (Math.Abs(BS55+prevBS55) < 0.000001 ) vROE[i] = 0; 
					else vROE[i] = IS33/((BS55+prevBS55/2.00));
				}
				else vROE[i] = 0.00;

				
				// POR Calculation ---- take average
				if (i != 0) 
				{
					if (Math.Abs(BS34+prevBS34) < 0.000001) vROA[i] = 0;
					else vROA[i] = IS33/((BS34+prevBS34/2.0));
				}
				else vROA[i] = 0.00;
				***/


				if (Math.Abs(BS45) > 0.000001)
					vCurrentRatio[i] = BS26 / BS45;
				else
					vCurrentRatio[i] = BS26 / ddef;


				/*** 2010-01-06, Scoring ILP ***/
				if (Math.Abs(BS45) > 0.000001)
					vQuickAssetRatio[i] = (BS19 + BS21) / BS45;
				else
					vQuickAssetRatio[i] = (BS19 + BS21) / ddef;


				/*** 2010-01-06, Scoring ILP ***/
				if (Math.Abs(IS14 * (BS14 / 100.0)) > 0.000001)
					vDaysReceiv[i] = Math.Round((BS21 / (IS14 * (BS14 /100.0))) * (((double)BS13 / 12.0) * 360.0), 0);
				else
					vDaysReceiv[i] = Math.Round((BS21 / ddef) * (((double)BS13 / 12.0) * 360.0), 0);

				
				if (Math.Abs(IS15) > 0.000001)
					vDaysInventory[i] = Math.Round((BS23 / IS15) * (((double)BS13 / 12.0) * 360.0), 0);
				else
					vDaysInventory[i] = Math.Round((BS23 / ddef) * (((double)BS13 / 12.0) * 360.0), 0);


				if (Math.Abs(IS15) > 0.000001)
					vDaysPayable[i] = Math.Round((BS39 / IS15) * (((double)BS13 / 12.0) * 360.0), 0);
				else
					vDaysPayable[i] = Math.Round((BS39 / ddef) * (((double)BS13 / 12.0) * 360.0), 0);


				vDaysTC[i] =  Math.Round((vDaysReceiv[i] + vDaysInventory[i] - vDaysPayable[i]),0);
				

				/*** 2010-01-06, Scoring ILP ***/
				if (Math.Abs(BS55) > 0.000001)
					vDebtEquity[i] = (BS38 + BS44 + BS47) / BS55;
				else
					vDebtEquity[i] = (BS38 + BS44 + BS47) / ddef;


				if (Math.Abs(BS55) > 0.000001)
					vLongTermLev[i] =  BS49 / BS55;
				else
					vLongTermLev[i] = BS49 / ddef;


				if (Math.Abs(IS29) > 0.000001)
					vTimeIntrstEarn[i] = IS28 / IS29;
				else
					vTimeIntrstEarn[i] = IS28 / ddef;


				double temp4 = BS38 + BS44 + IS29;
				if (Math.Abs(temp4) > 0.000001)
					vDebtServiceCov[i] = (IS33 + IS29 + IS23 + IS24 + IS25) / temp4;
				else
					vDebtServiceCov[i] = (IS33 + IS29 + IS23 + IS24 + IS25) / ddef;


				//------------------------- Sales TO Working capital  ------------------------------//
				double assetminusliabilities = BS26 - BS45;
				if (Math.Abs(assetminusliabilities) > 0.000001 )
				{
					dSALES_TO_WK_CAPITAL[i] = IS14 / assetminusliabilities;
					sSALES_TO_WK_CAPITAL[i] = dSALES_TO_WK_CAPITAL[i].ToString("##,#0.00");
				}
				else
				{
					dSALES_TO_WK_CAPITAL[i] = IS14 / ddef;
					sSALES_TO_WK_CAPITAL[i] = dSALES_TO_WK_CAPITAL[i].ToString("##,#0.00");
				}


				//------------------------- Debt To NetWorth  ------------------------------//				  
				if (Math.Abs(BS55) > 0.000001)
				{
					dDEBT_TO_NETWORTH[i] = (BS45 + BS49) / BS55;
					sDEBT_TO_NETWORTH[i] = dDEBT_TO_NETWORTH [i].ToString("##,#0.00");
				}
				else
				{
					dDEBT_TO_NETWORTH[i] = (BS45 + BS49) / ddef;
					sDEBT_TO_NETWORTH[i] = dDEBT_TO_NETWORTH [i].ToString("##,#0.00");
				}

				
				//------------------------- Business debt Service Ratio  ------------------------------//
				if ( Math.Abs(BS44) > 0.000001)
				{
					dBUSINESS_DEBT_SERV_RATIO[i] = (IS23 + IS33 + IS24 + IS25) / BS44;
					sBUSINESS_DEBT_SERV_RATIO[i] = dBUSINESS_DEBT_SERV_RATIO [i].ToString("##,#0.00");
				}
				else
				{
					dBUSINESS_DEBT_SERV_RATIO[i] = (IS23 + IS33 + IS24 + IS25) / ddef;
					sBUSINESS_DEBT_SERV_RATIO[i] = dBUSINESS_DEBT_SERV_RATIO [i].ToString("##,#0.00");
				}

				
				/* Sales Increase = CurrentYear NetSales - Prev Year NetSales / Prev Year NetSales */
				if (Math.Abs(prevIS14) > 0.000001 && i != 0) 
					dSalesIncrease = (IS14 - prevIS14) / Math.Abs(prevIS14);
				else if (i != 0)
					dSalesIncrease = (IS14 - prevIS14) / ddef;
				else
					dSalesIncrease =0.00;

				
				/* Net Income Increase = CurrentYear NetIncome - PrevYear NetIncome / PrevYear NetIncome */
				if (Math.Abs(prevIS33) > 0.000001 && i != 0) 
					dNetIncomeIncrease = (IS33 - prevIS33) / Math.Abs(prevIS33);
				else if (i != 0)
					dNetIncomeIncrease = (IS33 - prevIS33) / ddef;
				else
					dNetIncomeIncrease =0.00;

				
				/* Average Net Profit = CurrentYear NetIncome + PrevYear Net Income / 2 */
				dAverageNetProfit = (IS33 + prevIS33) / 2;


				/*******************************/
				/*** 2010-01-06, Scoring ILP ***/
				/*******************************/

				/*** Net Working Capital ***/
				NetWorkingCapital[i] = BS26 - BS45;

				/*** Gross Profit Margin ***/
				if (Math.Abs(IS14) > 0.000001)
					GrossProfitMargin[i] = (IS14 - IS15) / IS14;
				else
					GrossProfitMargin[i] = (IS14 - IS15) / ddef;

				/*** EBITDA ***/
				EBITDA[i] = IS14 - IS15 - IS19;
				currEBITDA = EBITDA[i];

				/*** Operating Profit Margin ***/
				if (Math.Abs(IS14) > 0.000001)
					OperatingProfitMargin[i] = EBITDA[i] / IS14;
				else
					OperatingProfitMargin[i] = EBITDA[i] / ddef;

				/*** Net Profit Margin ***/
				if (Math.Abs(IS14) > 0.000001)
					NetProfitMargin[i] = IS33 / IS14;
				else
					NetProfitMargin[i] = IS33 / ddef;

				/*** Return to Average Equity ***/
				if ( i == 0 )
				{
					if (Math.Abs(BS55) > 0.000001)
					{
						if (IS33 < 0.0 && BS55 < 0.0)
							vROE[i] = -1.0 * IS33 / BS55;
						else
							vROE[i] = IS33 / BS55;
					}
					else
						vROE[i] = IS33 / ddef;
				}
				else 
				{
					if (Math.Abs(BS55 + prevBS55) > 0.000001)
					{
						if (IS33 < 0.0 && (BS55 + prevBS55) < 0.0)
							vROE[i] = -1.0 * (IS33 / ((BS55 + prevBS55) / 2.00));
						else
							vROE[i] = IS33 / ((BS55 + prevBS55) / 2.00);
					}
					else
						vROE[i] = IS33 / ddef;
				}

				/*** Return to Average Asset ***/
				if ( i == 0 )
				{
					if (Math.Abs(BS34) > 0.000001 ) 
						vROA[i] = IS33 / BS34;
					else
						vROA[i] = IS33 / ddef;
				}
				else 
				{
					if (Math.Abs(BS34 + prevBS34) > 0.000001)
						vROA[i] = IS33 / ((BS34 + prevBS34) / 2.00);
					else
						vROA[i] = IS33 / ddef;
				}

				/*** Total Equity ***/
				TotalEquity[i] = BS55;

				/*** Leverage ***/
				if (Math.Abs(BS55) > 0.000001)
					Leverage[i] = BS50 / BS55;
				else
					Leverage[i] = BS50 / ddef;

				/*** Interest Coverage Ratio ***/
				if (Math.Abs(IS29) > 0.000001)
					InterestCoverageRatio[i] = IS30 / IS29;
				else
					InterestCoverageRatio[i] = IS30 / ddef;

				/*** Debt to EBITDA ***/
				if (Math.Abs(EBITDA[i]) > 0.000001)
					DebttoEBITDA[i] = (BS38 + BS44 + BS39) / EBITDA[i];
				else
					DebttoEBITDA[i] = (BS38 + BS44 + BS39) / ddef;

				/*** DSC (based on EBITDA) ***/
				if (Math.Abs(prevBS44 + IS29) > 0.000001)
					DSC[i] = EBITDA[i] / (prevBS44 + IS29);
				else
					DSC[i] = EBITDA[i] / ddef;

				/*** Long Term Debt to Equity ***/
				if (Math.Abs(BS55) > 0.000001)
					LongTermDebtToEquity[i] = BS47 / BS55;
				else
					LongTermDebtToEquity[i] = BS47 / ddef;

				/*** Debt to Assets ***/
				if (Math.Abs(BS34) > 0.000001)	
					DebtToAsset[i] = (BS38 + BS44 + BS47) / BS34;
				else
					DebtToAsset[i] = (BS38 + BS44 + BS47) / ddef;

				/*** Interest to Sales Ratio ***/
				if (Math.Abs(IS14) > 0.000001)	
					InteresttoSalesRatio[i] = IS29 / IS14;
				else
					InteresttoSalesRatio[i] = IS29 / ddef;

				/*** EBITDA to Interest Expense ***/
				if (Math.Abs(IS29) > 0.000001)
					EbitdaToInterestExp[i] = EBITDA[i] / IS29;
				else
					EbitdaToInterestExp[i] = EBITDA[i] / ddef;

				/*** EBITDA to Debt ***/
				if(Math.Abs(BS38+BS44+BS47) > 0.000001 )
					EbitdaToDebt[i] = EBITDA[i] / (BS38 + BS44 + BS47);
				else
					EbitdaToDebt[i] = EBITDA[i] / ddef;

				/*** EBITDA to Lialibilities ***/
				if (Math.Abs(BS50) > 0.000001)
					EbitdaToLiab[i] = EBITDA[i] / BS50;
				else
					EbitdaToLiab[i] = EBITDA[i] / ddef;

				/*** Assets Turnover ***/
				if(Math.Abs(BS34) > 0.000001 )
					AssetsTurnOver[i] = IS14 / BS34;
				else
					AssetsTurnOver[i] = IS14 / ddef;

				/*** Fixed Assets Turnover ***/
				if (Math.Abs(BS28) > 0.000001)
					FixedAssetTurnOver[i] = IS14 / BS28;
				else
					FixedAssetTurnOver[i] = IS14 / ddef;

				/*** Inventory Turnover ***/
				if(Math.Abs(BS23) > 0.000001)
					InventoryTurnOver[i] = IS15 / BS23;
				else
					InventoryTurnOver[i] = IS15 / ddef;

				/*** Receivable Turnover ***/
				if (Math.Abs(BS21) > 0.000001)
					ReceivableTurnOver[i] = IS14 / BS21;
				else
					ReceivableTurnOver[i] = IS14 / ddef;

				/*** Accounts Payable Turnover ***/
				if (Math.Abs(BS39) > 0.000001)
					AccPayableTurnover[i] = IS15 / BS39;
				else
					AccPayableTurnover[i] = IS15 / ddef;

				/*** EBITDA Growth ***/
				if (Math.Abs(prevEBITDA) > 0.000001 && i != 0) 
					EbitdaGrowth[i] = (currEBITDA - prevEBITDA) / Math.Abs(prevEBITDA);
				else if (i != 0)
					EbitdaGrowth[i] = (currEBITDA - prevEBITDA) / ddef;
				else
					EbitdaGrowth[i] =0.00;
				/*else if (currEBITDA > 0.00)
					EbitdaGrowth[i] = 0.6260;	//Upper Limit
				else if (currEBITDA < 0.00)
					EbitdaGrowth[i] = 0.0760;	//Lower Limit*/

				/*** Net Income Growth ***/
				if (Math.Abs(prevIS33) > 0.000001 && i != 0) 
					NetIncomeGrowth[i] = (IS33 - prevIS33) / Math.Abs(prevIS33);
				else if (i != 0)
					NetIncomeGrowth[i] = (IS33 - prevIS33) / ddef;
				else
					NetIncomeGrowth[i] =0.00;

				/*** Sales Growth ***/
				if (Math.Abs(prevIS14) > 0.000001 && i != 0) 
					SalesGrowth[i] = (IS14 - prevIS14) / Math.Abs(prevIS14);
				else if (i != 0)
					SalesGrowth[i] = (IS14 - prevIS14) / ddef;
				else
					SalesGrowth[i] =0.00;

				/*** Debt to Capital ***/
				if (Math.Abs(BS38 + BS44 + BS47 + BS55) > 0.000001)
					DebtToCapital[i] = (BS38 + BS44 + BS47) / (BS38 + BS44 + BS47 + BS55);
				else
					DebtToCapital[i] = (BS38 + BS44 + BS47) / ddef;

				/*** Operating Margin ***/
				if (Math.Abs(IS14) > 0.000001)
					//OperatingMargin[i] = (IS21 - IS23 - IS24 + IS26 - IS29) / IS14;
					OperatingMargin[i] = EBITDA[i] / IS14;
				else 
					OperatingMargin[i] = EBITDA[i] / ddef;

				/********************************/
				/******RATING MULTIFINANCE*******/
				/********** 2011-02-16 **********/
				/******* Prasetyo Wibowo ********/
				/********************************/

				/*Net Trade Cycle*/
				NetTradeCycle[i] = vDaysInventory[i] + vDaysReceiv[i] - vDaysPayable[i];

				/*Gearing Ratio*/
				if(Math.Abs(BS55) > 0.000001 )
					GearingRatio[i] = (BS38 + BS44 + BS47 + BS48) / BS55;
				else
					GearingRatio[i] = (BS38 + BS44 + BS47 + BS48) / ddef;

				/*Net Revenue*/
				NetRevenuePerMonth[i] = IS14 / 12;

				/*Account Receivable to Asset*/
				if(Math.Abs(BS34) > 0.000001 )
					AccReceivabletoAsset[i] = BS21 / BS34;
				else
					AccReceivabletoAsset[i] = BS21 / ddef;

				/*Account Receivable to Liabilities */
				if(Math.Abs(BS50) > 0.000001 )
					AccReceivabletoLiability[i] = BS21 / BS50;
				else
					AccReceivabletoLiability[i] = BS21 / ddef;

				/*Equity to Asset*/
				if(Math.Abs(BS34) > 0.000001)
					EquityToAssets[i] = BS55 / BS34;
				else
					EquityToAssets[i] = BS55 / ddef;

				/*Asset Growth*/
				if(Math.Abs(prevBS34) > 0.000001)
					AssetGrowth[i] = (BS34 /prevBS34)-1;
				else
					AssetGrowth[i] = (BS34 /ddef)-1;

				/*Receivables Growth*/
				if(Math.Abs(prevBS21) > 0.000001)
					ReceivablesGrowth[i] = (BS21 /prevBS21)-1;
				else
					ReceivablesGrowth[i] = (BS21 /ddef)-1;

				/*Equity Growth	*/
				if(Math.Abs(prevBS55) > 0.000001)
					EquityGrowth[i] = (BS55 / prevBS55)-1;
				else
					EquityGrowth[i] = (BS55 / ddef)-1;

				/*Efisiensi  Ratio*/
				if(Math.Abs(IS14) > 0.000001)
					EficiencyRatio[i] = IS19 /IS14;
				else
					EficiencyRatio[i] = (IS19 / ddef);

				/*Total Asset*/
				TotalAsset[i] = BS34;

				page.Response.Write("<!-- ca_ratio_middle_sp save -->");
				conn.QueryString = "exec ca_ratio_middle_sp 'save','" + curef + "','" + regno + "','" + Strings.Format(DateTime.Parse(Posisi[i].ToString()),"yyyy-MM-dd") + "'," +
					Convert.ToInt16(dtCurrent.Rows[i]["BS_NUM_MONTH"].ToString()) + ",'" + dtCurrent.Rows[i]["BS_REPORTTYPE"].ToString() + "'," + dtCurrent.Rows[i]["BS_SALES_ONCR"].ToString() + "," +
					GlobalTools.ConvertFloat(Convert.ToString(vSalesGrowthRate[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(buROE[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(buROA[i])) + "," + 
					GlobalTools.ConvertFloat(Convert.ToString(vInterest[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(vSales[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(vCurrentRatio[i])) + "," + 
					GlobalTools.ConvertFloat(Convert.ToString(vQuickAssetRatio[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(vDaysReceiv[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(vDaysInventory[i])) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(vDaysPayable[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(vDaysTC[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(vDebtEquity[i])) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(vLongTermLev[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(vTimeIntrstEarn[i])) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(vDebtServiceCov[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(sSALES_TO_WK_CAPITAL[i])) + "," + 
					GlobalTools.ConvertFloat(Convert.ToString(sDEBT_TO_NETWORTH[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(sBUSINESS_DEBT_SERV_RATIO[i])) + "," + 
					GlobalTools.ConvertFloat(Convert.ToString(BS55)) + "," + GlobalTools.ConvertFloat(Convert.ToString(dSalesIncrease)) + "," + GlobalTools.ConvertFloat(Convert.ToString(dNetIncomeIncrease)) + "," + GlobalTools.ConvertFloat(Convert.ToString(dAverageNetProfit)) + "," + dtCurrent.Rows[i]["bs_isproyeksi"] + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(EBITDA[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(NetProfitMargin[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(NetWorkingCapital[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(GrossProfitMargin[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(OperatingProfitMargin[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(vROE[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(vROA[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(TotalEquity[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(Leverage[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(LongTermDebtToEquity[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(DebtToAsset[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(InterestCoverageRatio[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(InteresttoSalesRatio[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(EbitdaToInterestExp[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(EbitdaToDebt[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(EbitdaToLiab[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(DebttoEBITDA[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(DSC[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(AssetsTurnOver[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(FixedAssetTurnOver[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(InventoryTurnOver[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(ReceivableTurnOver[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(AccPayableTurnover[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(EbitdaGrowth[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(NetIncomeGrowth[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(SalesGrowth[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(DebtToCapital[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(OperatingMargin[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(NetTradeCycle[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(GearingRatio[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(NetRevenuePerMonth[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(AccReceivabletoAsset[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(AccReceivabletoLiability[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(EquityToAssets[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(AssetGrowth[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(ReceivablesGrowth[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(EquityGrowth[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(EficiencyRatio[i])) + ", " +
					GlobalTools.ConvertFloat(Convert.ToString(TotalAsset[i]));
				conn.ExecuteNonQuery();

				//---- start insert data utk keperluan rating 22 ratio -----------------//
				dtTahun[i] = Convert.ToDateTime(dtCurrent.Rows[i][2].ToString());				
				intTahun[i] = dtTahun[i].Year;

				vCurrentRatio[i] = vCurrentRatio[i] * 100.0;				
				vQuickAssetRatio[i] =  vQuickAssetRatio[i] * 100;
				
				/*** 2010-01-06, Scoring ILP ***/
				// Debts to Assets
				if (Math.Abs(BS34) > 0.000001)
					DebtToAsset[i] = 100 * (BS38 + BS44 + BS47) / BS34;
				else
					DebtToAsset[i] = 100 * (BS38 + BS44 + BS47) / ddef;
				
				/*** 2010-01-06, Scoring ILP ***/
				//Debts to Capital
				if (Math.Abs(BS38 + BS44 + BS47 + BS55) > 0.000001 )
					DebtToCapital[i] = 100 * (BS38 + BS44 + BS47) / (BS38 + BS44 + BS47 + BS55);
				else
					DebtToCapital[i] = 100 * (BS38 + BS44 + BS47) / ddef;

				/*** 2010-01-06, Scoring ILP ***/
				// Absolute Debt to Equity
				if (Math.Abs(BS55) > 0.000001)
					AbsoluteDebtToEquity[i] = 100 * ((BS38 + BS44 + BS47) / BS55);
				else
					AbsoluteDebtToEquity[i] = 100 * ((BS38 + BS44 + BS47) / ddef);

				// Long Term Debt to Equity
				if (Math.Abs(BS55) > 0.000001)
					LongTermDebtToEquity[i] = 100 * BS47 / BS55;
				else
					LongTermDebtToEquity[i] = 100 * BS47 / ddef;

				//------- cahflow ------------------------

				/*** 2010-01-06, Scoring ILP ***/
				//	Ebita to Interest Exp
				if (Math.Abs(IS29) > 0.000001)
					EbitdaToInterestExp[i] = 100 * (EBITDA[i] / IS29);
				else
					EbitdaToInterestExp[i] = 100 * (EBITDA[i] / ddef);

				/*** 2010-01-06, Scoring ILP ***/
				// Ebita to Debt
				if(Math.Abs(BS38 + BS44 + BS47) > 0.000001 )
					EbitdaToDebt[i] = 100 * EBITDA[i] / (BS38 + BS44 + BS47);
				else
					EbitdaToDebt[i] = 100 * EBITDA[i] / ddef;
								
				/*** 2010-01-06, Scoring ILP ***/
				// Ebita to Liabilities
				if (Math.Abs(BS50) > 0.000001)
					EbitdaToLiab[i] = 100 * EBITDA[i] / BS50;
				else
					EbitdaToLiab[i] = 100 * EBITDA[i] / ddef;

				// Operating CF to Debt			
				if (Math.Abs(BS38 + BS44 + BS47 + BS48) > 0.000001 && i !=0)
					OperatingCFToDebt[i] = 100 * (IS17 + IS23 - (BS21 - prevBS21) - (BS23 - prevBS23) + (BS39 - prevBS39)) / (BS38 + BS44 + BS47 + BS48);
				else if (i !=0)
					OperatingCFToDebt[i] = 100 * (IS17 + IS23 - (BS21 - prevBS21) - (BS23 - prevBS23) + (BS39 - prevBS39)) / ddef;
				else
					OperatingCFToDebt[i] = 0.00;

				//	Operating CF to Interest Exp
				if (Math.Abs(IS29) > 0.000001 && i != 0)
					OperatingCFToInterestExp[i] = 100 * (IS17 + IS23 - (BS21 - prevBS21) - (BS23 - prevBS23) + (BS39 - prevBS39)) / IS29;
				else if (i !=0)
					OperatingCFToInterestExp[i] = 100 * (IS17 + IS23 - (BS21 - prevBS21) - (BS23 - prevBS23) + (BS39 - prevBS39)) / ddef;
				else
					OperatingCFToInterestExp[i] = 0.00;
				
				//------- profitability ------------------------

				// Net Margin
				if (Math.Abs(IS14) > 0.000001)
					NetMargin[i] = 100.0 * IS33 / IS14;
				else
					NetMargin[i] = 100.0 * IS33 / ddef;

				/*** 2010-01-06, Scoring ILP ***/
				// Operating Margin
				if (Math.Abs(IS14) > 0.000001)
					OperatingMargin[i] = 100.0 * EBITDA[i] / IS14;
				else
					OperatingMargin[i] = 100.0 * EBITDA[i] / ddef;
				
				//--- ROA nilai nya ngambil dari variable ROA diatas
				//--- ROE nilai nya ngambil dari variable ROE diatas

				//------- Activity ------------------------	
				
				//Return on Avg Asset
				if (i == 0)
				{
					if (Math.Abs(BS34) > 0.000001) 
						vROA[i] = 100.00 * IS33 / BS34;
					else
						vROA[i] = 100.00 * IS33 / ddef;
				}
				else 
				{
					if (Math.Abs(BS34 + prevBS34) > 0.000001)
						vROA[i] = 100.0 * IS33 / ((BS34 + prevBS34) / 2.0);
					else
						vROA[i] = 100.0 * IS33 / ddef;
				}
				
				//Asset Turnover
				if(Math.Abs(BS34) > 0.000001 )
					AssetsTurnOver[i] = 100.0 * IS14 / BS34;
				else
					AssetsTurnOver[i] = 100.0 * IS14 / ddef;
				
				// Return on Avg Equity
				if (i == 0)
				{
					if (Math.Abs(BS55) > 0.000001)
					{
						if (IS33 < 0.0 && BS55 < 0.0)
							vROE[i] = -100.0 * IS33 / BS55;
						else
							vROE[i] = 100.0 * IS33 / BS55;
					}
					else
						vROE[i] = 100.0 * IS33 / ddef;
				}
				else 
				{
					if (Math.Abs(BS55 + prevBS55) > 0.000001)
					{
						if (IS33 < 0.0 && (BS55 + prevBS55) < 0.0)
							vROE[i] = -100.00 * IS33 / ((BS55 + prevBS55) / 2.0);
						else
							vROE[i] = 100.00 * IS33 / ((BS55 + prevBS55) / 2.0);
					}
					else
						vROE[i] = 100.00 * IS33 / ddef;
				}

				// Inventory Turnover
				if(Math.Abs(BS23) > 0.000001)
					InventoryTurnOver[i] = 100 * IS15 / BS23;
				else
					InventoryTurnOver[i] = 100 * IS15 / ddef;

				// Receivables turnover
				if (Math.Abs(BS21) > 0.000001)
					ReceivableTurnOver[i] = 100.0 * IS14 / BS21;
				else
					ReceivableTurnOver[i] = 100.0 * IS14 / ddef;

				// Fixed Assets Turnover
				if (Math.Abs(BS28) > 0.000001)
					FixedAssetTurnOver[i] = 100.0 * IS14 / BS28;
				else
					FixedAssetTurnOver[i] = 100.0 * IS14 / ddef;
				
				//------- Growth ------------------------	
				// Ebita Growth
				if (Math.Abs(prevIS21) > 0.000001 && i != 0)
					EbitdaGrowth[i] = 100.0 * ((IS21 - prevIS21) / Math.Abs(prevIS21));
				else if (i != 0)
					EbitdaGrowth[i] = 100.0 * ((IS21 - prevIS21) / ddef);
				else
					EbitdaGrowth[i] = 0.00;
				/*else if (IS21 > 0.00)
					EbitdaGrowth[i] = 62.60;	//Upper Limit
				else if (IS21 < 0.00)
					EbitdaGrowth[i] = 7.60;		//Lower Limit*/

				// Sales Growth
				//if (Math.Abs(prevIS14) > 0.000001 && i != 0) SalesGrowth[i] = 100.00 * (IS14/prevIS14 - 1);
				if (Math.Abs(prevIS14) > 0.000001 && i != 0) 
					SalesGrowth[i] = 100.00 * ((IS14 - prevIS14) / Math.Abs(prevIS14));
				else if (i != 0) 
					SalesGrowth[i] = 100.00 * ((IS14 - prevIS14) / ddef);
				else
					SalesGrowth[i] =0.00;

				// Net income growth
				if (Math.Abs(prevIS33) > 0.000001 && i != 0) 
					NetIncomeGrowth[i] =  100.0 * ((IS33 - prevIS33) / Math.Abs(prevIS33));
				else if (i != 0) 
					NetIncomeGrowth[i] =  100.0 * ((IS33 - prevIS33) / ddef);
				else
					NetIncomeGrowth[i] =0.00;

				prevBS21 = BS21;
				prevBS23 = BS23;
				prevBS34 = BS34; 
				prevBS38 = BS38; 							
				prevBS39 = BS39;  
				prevBS44 = BS44; 
				prevBS47 = BS47;
				prevBS55 = BS55;							
				
				prevIS14 = IS14;
				prevIS21 = IS21; 
				prevIS23 = IS23; 
				prevIS24 = IS24;
				prevIS25 = IS25;
				prevIS26 = IS26;
				prevIS27 = IS27;
				prevIS28 = IS28;
				prevIS29 = IS29;
				prevIS33 = IS33;

				/*******************************/
				/*** 2010-01-06, Scoring ILP ***/
				/*******************************/
				prevEBITDA = currEBITDA;
				
				if (dtCurrent.Rows[i]["bs_isproyeksi"].ToString() != "1")
				{
					conn.QueryString = "exec CUSTFINANCIALRATIO_SAVE '" + curef + "'," +
						intTahun[i] + "," + Convert.ToInt16(dtCurrent.Rows[i]["BS_NUM_MONTH"].ToString()) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(vCurrentRatio[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(vQuickAssetRatio[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(DebtToAsset[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(DebtToCapital[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(AbsoluteDebtToEquity[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(LongTermDebtToEquity[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(EbitdaToInterestExp[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(EbitdaToDebt[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(EbitdaToLiab[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(OperatingCFToDebt[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(OperatingCFToInterestExp[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(NetMargin[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(OperatingMargin[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(vROA[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(vROE[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(AssetsTurnOver[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(InventoryTurnOver[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(ReceivableTurnOver[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(FixedAssetTurnOver[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(EbitdaGrowth[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(SalesGrowth[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(NetIncomeGrowth[i])) + "," +
						GlobalTools.ToSQLDate(dtCurrent.Rows[i]["BS_DATE_PERIODE"].ToString()) + "," +
						GlobalTools.ConvertNull(dtCurrent.Rows[i]["BS_REPORTTYPE"].ToString()) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(NetTradeCycle[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(GearingRatio[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(NetRevenuePerMonth[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(AccReceivabletoAsset[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(AccReceivabletoLiability[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(EquityToAssets[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(AssetGrowth[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(ReceivablesGrowth[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(EquityGrowth[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(EficiencyRatio[i])) + "," +
						GlobalTools.ConvertFloat(Convert.ToString(TotalAsset[i]));
					conn.ExecuteNonQuery();		
				}
			}

			return true;
		}

		private static bool compare_neraca_labarugi(System.Web.UI.Page page, string regno, string curef, Connection conn)
		{
			//int row_banding = 0;

			conn.QueryString = "select year(bs_date_periode) tahun, bs_num_month bulan from ca_neraca_middle where cu_ref = '" + curef + "' and ap_regno = '" + regno + "'";
			conn.ExecuteQuery();
			int row_neraca = conn.GetRowCount();

			conn.QueryString = "select year(is_date_periode) tahun, is_num_month bulan from ca_labarugi_middle where cu_ref = '" + curef + "' and ap_regno = '" + regno + "'";
			conn.ExecuteQuery();
			int row_labarugi = conn.GetRowCount();
			
			/*conn.QueryString = "select  ca_neraca_middle.ap_regno,ca_labarugi_middle.ap_regno, " +
				"ca_neraca_middle.cu_ref, ca_labarugi_middle.cu_ref," +
				"ca_neraca_middle.bs_date_Periode, ca_labarugi_middle.is_date_Periode," +
				"ca_neraca_middle.BS_NUM_MONTH, ca_labarugi_middle.is_NUM_MONTH " +
				"from ca_neraca_middle " +
				"left join ca_labarugi_middle on " +
				"ca_neraca_middle.ap_regno = ca_labarugi_middle.ap_regno and " +
				"ca_neraca_middle.cu_ref = ca_labarugi_middle.cu_ref and " +
				"year(ca_neraca_middle.bs_date_Periode) = year(ca_labarugi_middle.is_date_Periode) " +
				"and ca_neraca_middle.BS_NUM_MONTH = ca_labarugi_middle.is_NUM_MONTH " +
				"where ca_neraca_middle.ap_regno = '" + regno + "' and " +
				"(ca_labarugi_middle.is_date_periode is null or ca_neraca_middle.bs_date_periode is null)";
				*/
			conn.QueryString = "select n.ap_regno , year(n.bs_date_Periode) , year(l.is_date_Periode) " +
				"from ca_neraca_middle n inner join ca_labarugi_middle l on l.ap_regno = n.ap_regno " +
				"and year(l.is_date_Periode) = year(n.bs_date_Periode) and l.IS_NUM_MONTH = n.BS_NUM_MONTH " +
				"and n.bs_reporttype = l.is_reporttype " +
				"where n.ap_regno = '" + regno + "' ";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();

			if (row_neraca != row_labarugi)
			{
				GlobalTools.popMessage(page,"Ratio tidak bisa di hitung karena periode pada labarugi dan neraca tidak sama!");				
				return false;
			}
			else
			{
				if (row == row_neraca) return true;
				else
				{
					GlobalTools.popMessage(page,"Ratio tidak bisa di hitung karena periode pada labarugi dan neraca tidak sama!");				
					return false;
				}

			}
			//return true;
		}

		public static void delete_ratio(string regno, Connection conn)
		{
			conn.QueryString = "delete from ca_ratio_middle where ap_regno = '" + regno + "'" ;
			conn.ExecuteNonQuery();

			conn.QueryString = "select CU_REF, BS_DATE_PERIODE, BS_NUM_MONTH " +
				"from vw_ca_hitung_rasio where ap_regno = '" + regno + "' ";
			conn.ExecuteQuery();
			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DateTime dt = Convert.ToDateTime(conn.GetFieldValue(i,"BS_DATE_PERIODE"));
				string sTahun = dt.Year.ToString(), 
					sNumMonth = conn.GetFieldValue(i,"BS_NUM_MONTH"),
					curef = conn.GetFieldValue(i,"CU_REF");
				conn.QueryString = "exec CUSTFINANCIALRATIO_DELETE '" + curef + "'," +
					sTahun + "," + sNumMonth;
				conn.ExecuteNonQuery();
			}
		}

		//---------------------- end hitung for middle -------------------------------------------------------------------------------------------------/
		#endregion

		#region small_calculation 
		public static bool proses_calculate_small(System.Web.UI.Page page, string regno, string curef, Connection conn)
		{
			conn.QueryString = "SELECT AP_REGNO FROM CA_NERACA_SMALL " +
				"WHERE AP_REGNO = '" + regno + "' AND AKTV_TTLAKTV <> PASV_TTLPASIVA ";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)	//neraca not balanced
			{
				GlobalTools.popMessage(page,"Total Aktiva dan Total Pasiva pada Neraca belum sama !! ");
				//delete ratios if exists 
				delete_ratio_small(regno,conn);
				return false;
			}

			if (!compare_neraca_labarugi_small(page, regno, curef, conn)) 
			{
				//delete ratios if exists 
				delete_ratio_small(regno,conn);
				return false;
			}

			conn.QueryString = "delete from ca_ratio_small where ap_regno = '" + regno + "' ";
			conn.ExecuteNonQuery();			

			//conn.QueryString = "select * from vw_ca_hitung_rasio_small where ap_regno = '" + regno + "' and year(posisi_tgl) <= '" + Request.QueryString["tahun"] + "'";
			conn.QueryString = "select * from vw_ca_hitung_rasio_small where ap_regno = '" + regno + "'";
			conn.ExecuteQuery();

			System.Data.DataTable dtCurrent = new System.Data.DataTable();
			dtCurrent = conn.GetDataTable().Copy();
			int durasi = dtCurrent.Rows.Count;

			double[] dCurrentRatio = new double[durasi];
			double[] dDebtEquityRatio = new double[durasi];
			double[] dROA = new double[durasi];
			double[] dROE = new double[durasi];
			double[] dROI = new double[durasi];
			double[] dCashVelocity = new double[durasi];
			double[] dDaysReceivable = new double[durasi];
			double[] dDaysInventory = new double[durasi];
			double[] dDaysPayable = new double[durasi];
			double[] dDaysAccPay = new double[durasi];
			double[] dTradeCycle = new double[durasi];
			double[] dNetWorth = new double[durasi];
			double[] dNETWORTH = new double[durasi];
			double[] dNET_PROFIT_MARGIN = new double[durasi];
			double[] dNET_PROFIT_MARGIN_prev1 = new double[durasi];
			double[] dNET_PROFIT_MARGIN_prev2 = new double[durasi];
			double[] dNET_PROFIT_MARGIN_curr1 = new double[durasi];
			double[] dNET_PROFIT_MARGIN_curr2 = new double[durasi];
			double[] dNETWORKING_CAPITAL = new double[durasi];
			double[] dRETURN_ON_INVESTMENT = new double[durasi];
			double[] dNET_PROFIT_GROWTH = new double[durasi];
			double[] dNET_PROFIT_GROWTH_prev1 = new double[durasi];
			double[] dNET_PROFIT_GROWTH_curr1 = new double[durasi];
			double[] dTTL_ASSET_TURN_OVER = new double[durasi];
			double[] dSalesToWorkingCapital = new double[durasi];
			double[] dDebtToNetworth = new double[durasi];
			double[] dBusinessDebtServiceRatio = new double[durasi];
			//20090324 tambahan scoring EBITDA
			double[] dCashBanktoHutangBankDagangRatio = new double[durasi];
			double[] dHutangBankDagangtoLabaOperasionalRatio = new double[durasi];

			double prevIS93=0.00,prevBS40=0.00,prevIS73=0.00;
			/* --- KAMUS --
					BS19 AKTV_KASBANK				IS73 IS_PENJ
					BS21 AKTV_PIUDGN				IS74 IS_HPP
					BS23 AKTV_PERSEDIAAN			IS75 IS_PROSEN_PENJ1
					BS24 AKTV_LCRLAIN				IS78 IS_ADMOPR
					BS26 AKTV_TTLAKTLCR				IS79 IS_PROSEN_PENJ2
					BS28 AKTV_TNHBGN				IS80 IS_LABAOPR
					BS29 AKTV_MSNALAT				IS82 IS_SUSUT_TNHBGN
					BS30 AKTV_INVKNDRN				IS83 IS_SUSUT_ALAT
					BS32 AKTV_TTPLAIN				IS84 IS_SUSUT_INVKNDRN
					BS33 AKTV_AKUMSUSUT				IS85 IS_TTLSUSUT
					BS34 AKTV_NETAKTVTTP			IS86 IS_PNDPTN
					BS36 AKTV_BIAYATANGGUH			IS87 IS_BIAYA_LAIN
					BS37 AKTV_AKUMAMOR				IS88 IS_LABA_SBLBUNGA
					BS38 AKTV_AKTVLAIN				IS89 IS_BUNGA
					BS39 AKTV_TTLAKTVLAIN			IS90 IS_LABA_SBLPJK
					BS40 AKTV_TTLAKTV				IS92 IS_PJK
					BS44 PASV_HTDG					IS93 IS_LABA_BRSH
					BS45 PASV_HTBANK				
					BS46 PASV_KIJTHTEMPO				
					BS47 PASV_HTLNCR				
					BS52 PASV_TTLHTLNCR				
					BS54 PASV_HTJKPJG				
					BS55 PASV_HTPMGANGSHM				
					BS56 PASV_JKPJGLAIN				
					BS57 PASV_TTLHTJKPJG				
					BS58 PASV_TTLHT				
					BS60 PASV_MODALSTR				
					BS62 PASV_LBRG				
					BS63 PASV_TTLMODAL				
					BS65 PASV_TTLPASIVA				
					*	
					*/
				

			double BS19,BS21,BS23,BS24,BS26,BS28,BS29,BS30,BS32,BS33,BS34,BS36,BS37,BS38,BS39;
			double BS40,BS44,BS45,BS46,BS47,BS52,BS54,BS55,BS56,BS57,BS58,BS60,BS62,BS63,BS65;
			double IS73,IS74,IS75,IS78,IS79,IS80,IS82,IS83,IS84,IS85,IS86,IS87,IS88,IS89,IS90,IS92,IS93;

			double dSalesIncrease, dNetIncomeIncrease, dAverageNetProfit;

			for (int i=0; i<durasi; i++)
			{
				

				//double[] vDEBT_SERVICE_RATIO = new double[durasi];---- dijadikan teksbox, :mirza said
				//double[] vCOLLATERAL_COVERAGE = new double[durasi];--- dijadikan teksbox, :mirza said
				//double[] vNPV = new double[durasi];------------------- ada di form ratio, 
				//double[] vIRR = new double[durasi];------------------- ada di form ratio,
				//double[] vPAYBACK = new double[durasi];------------------- ada di form ratio,
				
				if (Strings.Trim(dtCurrent.Rows[i]["AKTV_KASBANK"].ToString())=="" || dtCurrent.Rows[i]["AKTV_KASBANK"].ToString()==null)  BS19 = 0.0;
				else BS19 = Convert.ToDouble(dtCurrent.Rows[i]["AKTV_KASBANK"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["AKTV_PIUDGN"].ToString())=="" || dtCurrent.Rows[i]["AKTV_PIUDGN"].ToString()==null)  BS21 = 0.0;
				else BS21 = Convert.ToDouble(dtCurrent.Rows[i]["AKTV_PIUDGN"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTV_PERSEDIAAN"].ToString())=="" || dtCurrent.Rows[i]["AKTV_PERSEDIAAN"].ToString()==null)  BS23 = 0.0;
				else BS23 = Convert.ToDouble(dtCurrent.Rows[i]["AKTV_PERSEDIAAN"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTV_LCRLAIN"].ToString())=="" || dtCurrent.Rows[i]["AKTV_LCRLAIN"].ToString()==null)  BS24 = 0.0;
				else BS24 = Convert.ToDouble(dtCurrent.Rows[i]["AKTV_LCRLAIN"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTV_TTLAKTLCR"].ToString())=="" || dtCurrent.Rows[i]["AKTV_TTLAKTLCR"].ToString()==null)  BS26 = 0.0;
				else BS26 = Convert.ToDouble(dtCurrent.Rows[i]["AKTV_TTLAKTLCR"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTV_TNHBGN"].ToString())=="" || dtCurrent.Rows[i]["AKTV_TNHBGN"].ToString()==null)  BS28 = 0.0;
				else BS28 = Convert.ToDouble(dtCurrent.Rows[i]["AKTV_TNHBGN"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTV_MSNALAT"].ToString())=="" || dtCurrent.Rows[i]["AKTV_MSNALAT"].ToString()==null)  BS29 = 0.0;
				else BS29 = Convert.ToDouble(dtCurrent.Rows[i]["AKTV_MSNALAT"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTV_INVKNDRN"].ToString())=="" || dtCurrent.Rows[i]["AKTV_INVKNDRN"].ToString()==null)  BS30 = 0.0;
				else BS30 = Convert.ToDouble(dtCurrent.Rows[i]["AKTV_INVKNDRN"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTV_TTPLAIN"].ToString())=="" || dtCurrent.Rows[i]["AKTV_TTPLAIN"].ToString()==null)  BS32 = 0.0;
				else BS32 = Convert.ToDouble(dtCurrent.Rows[i]["AKTV_TTPLAIN"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTV_AKUMSUSUT"].ToString())=="" || dtCurrent.Rows[i]["AKTV_AKUMSUSUT"].ToString()==null)  BS33 = 0.0;
				else BS33 = Convert.ToDouble(dtCurrent.Rows[i]["AKTV_AKUMSUSUT"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTV_NETAKTVTTP"].ToString())=="" || dtCurrent.Rows[i]["AKTV_NETAKTVTTP"].ToString()==null)  BS34 = 0.0;
				else BS34 = Convert.ToDouble(dtCurrent.Rows[i]["AKTV_NETAKTVTTP"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTV_BIAYATANGGUH"].ToString())=="" || dtCurrent.Rows[i]["AKTV_BIAYATANGGUH"].ToString()==null)  BS36 = 0.0;
				else BS36 = Convert.ToDouble(dtCurrent.Rows[i]["AKTV_BIAYATANGGUH"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTV_AKUMAMOR"].ToString())=="" || dtCurrent.Rows[i]["AKTV_AKUMAMOR"].ToString()==null)  BS37 = 0.0;
				else BS37 = Convert.ToDouble(dtCurrent.Rows[i]["AKTV_AKUMAMOR"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTV_AKTVLAIN"].ToString())=="" || dtCurrent.Rows[i]["AKTV_AKTVLAIN"].ToString()==null)  BS38 = 0.0;
				else BS38 = Convert.ToDouble(dtCurrent.Rows[i]["AKTV_AKTVLAIN"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTV_TTLAKTVLAIN"].ToString())=="" || dtCurrent.Rows[i]["AKTV_TTLAKTVLAIN"].ToString()==null)  BS39 = 0.0;
				else BS39 = Convert.ToDouble(dtCurrent.Rows[i]["AKTV_TTLAKTVLAIN"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTV_TTLAKTV"].ToString())=="" || dtCurrent.Rows[i]["AKTV_TTLAKTV"].ToString()==null)  BS40 = 0.0;
				else BS40 = Convert.ToDouble(dtCurrent.Rows[i]["AKTV_TTLAKTV"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASV_HTDG"].ToString())=="" || dtCurrent.Rows[i]["PASV_HTDG"].ToString()==null)  BS44 = 0.0;
				else BS44 = Convert.ToDouble(dtCurrent.Rows[i]["PASV_HTDG"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASV_HTBANK"].ToString())=="" || dtCurrent.Rows[i]["PASV_HTBANK"].ToString()==null)  BS45 = 0.0;
				else BS45 = Convert.ToDouble(dtCurrent.Rows[i]["PASV_HTBANK"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASV_KIJTHTEMPO"].ToString())=="" || dtCurrent.Rows[i]["PASV_KIJTHTEMPO"].ToString()==null)  BS46 = 0.0;
				else BS46 = Convert.ToDouble(dtCurrent.Rows[i]["PASV_KIJTHTEMPO"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASV_HTLNCR"].ToString())=="" || dtCurrent.Rows[i]["PASV_HTLNCR"].ToString()==null)  BS47 = 0.0;
				else BS47 = Convert.ToDouble(dtCurrent.Rows[i]["PASV_HTLNCR"].ToString());
	
				if (Strings.Trim(dtCurrent.Rows[i]["PASV_TTLHTLNCR"].ToString())=="" || dtCurrent.Rows[i]["PASV_TTLHTLNCR"].ToString()==null)  BS52 = 0.0;
				else BS52 = Convert.ToDouble(dtCurrent.Rows[i]["PASV_TTLHTLNCR"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASV_HTJKPJG"].ToString())=="" || dtCurrent.Rows[i]["PASV_HTJKPJG"].ToString()==null)  BS54 = 0.0;
				else BS54 = Convert.ToDouble(dtCurrent.Rows[i]["PASV_HTJKPJG"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASV_HTPMGANGSHM"].ToString())=="" || dtCurrent.Rows[i]["PASV_HTPMGANGSHM"].ToString()==null)  BS55 = 0.0;
				else BS55 = Convert.ToDouble(dtCurrent.Rows[i]["PASV_HTPMGANGSHM"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASV_JKPJGLAIN"].ToString())=="" || dtCurrent.Rows[i]["PASV_JKPJGLAIN"].ToString()==null)  BS56 = 0.0;
				else BS56 = Convert.ToDouble(dtCurrent.Rows[i]["PASV_JKPJGLAIN"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASV_TTLHTJKPJG"].ToString())=="" || dtCurrent.Rows[i]["PASV_TTLHTJKPJG"].ToString()==null)  BS57 = 0.0;
				else BS57 = Convert.ToDouble(dtCurrent.Rows[i]["PASV_TTLHTJKPJG"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASV_TTLHT"].ToString())=="" || dtCurrent.Rows[i]["PASV_TTLHT"].ToString()==null)  BS58 = 0.0;
				else BS58 = Convert.ToDouble(dtCurrent.Rows[i]["PASV_TTLHT"].ToString());
				
				if (Strings.Trim(dtCurrent.Rows[i]["PASV_MODALSTR"].ToString())=="" || dtCurrent.Rows[i]["PASV_MODALSTR"].ToString()==null)  BS60 = 0.0;
				else BS60 = Convert.ToDouble(dtCurrent.Rows[i]["PASV_MODALSTR"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASV_LBRG"].ToString())=="" || dtCurrent.Rows[i]["PASV_LBRG"].ToString()==null)  BS62 = 0.0;
				else BS62 = Convert.ToDouble(dtCurrent.Rows[i]["PASV_LBRG"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASV_TTLMODAL"].ToString())=="" || dtCurrent.Rows[i]["PASV_TTLMODAL"].ToString()==null)  BS63 = 0.0;
				else BS63 = Convert.ToDouble(dtCurrent.Rows[i]["PASV_TTLMODAL"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASV_TTLPASIVA"].ToString())=="" || dtCurrent.Rows[i]["PASV_TTLPASIVA"].ToString()==null)  BS65 = 0.0;
				else BS65 = Convert.ToDouble(dtCurrent.Rows[i]["PASV_TTLPASIVA"].ToString());
				
				//---------------------------------------------- end neraca small ----------------------------------
				if (Strings.Trim(dtCurrent.Rows[i]["IS_PENJ"].ToString())=="" || dtCurrent.Rows[i]["IS_PENJ"].ToString()==null) IS73 = 0.0;
				else IS73 = Convert.ToDouble(dtCurrent.Rows[i]["IS_PENJ"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IS_HPP"].ToString())=="" || dtCurrent.Rows[i]["IS_HPP"].ToString()==null) IS74 = 0.0;
				else IS74 = Convert.ToDouble(dtCurrent.Rows[i]["IS_HPP"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IS_PROSEN_PENJ1"].ToString())=="" || dtCurrent.Rows[i]["IS_PROSEN_PENJ1"].ToString()==null)  IS75 = 0.0;
				else IS75 = Convert.ToDouble(dtCurrent.Rows[i]["IS_PROSEN_PENJ1"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IS_ADMOPR"].ToString())=="" || dtCurrent.Rows[i]["IS_ADMOPR"].ToString()==null)  IS78 = 0.0;
				else IS78 = Convert.ToDouble(dtCurrent.Rows[i]["IS_ADMOPR"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IS_PROSEN_PENJ2"].ToString())=="" || dtCurrent.Rows[i]["IS_PROSEN_PENJ2"].ToString()==null)  IS79 = 0.0;
				else IS79 = Convert.ToDouble(dtCurrent.Rows[i]["IS_PROSEN_PENJ2"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IS_LABAOPR"].ToString())=="" || dtCurrent.Rows[i]["IS_LABAOPR"].ToString()==null)  IS80 = 0.0;
				else IS80 = Convert.ToDouble(dtCurrent.Rows[i]["IS_LABAOPR"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IS_SUSUT_TNHBGN"].ToString())=="" || dtCurrent.Rows[i]["IS_SUSUT_TNHBGN"].ToString()==null)  IS82 = 0.0;
				else IS82 = Convert.ToDouble(dtCurrent.Rows[i]["IS_SUSUT_TNHBGN"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IS_SUSUT_ALAT"].ToString())=="" || dtCurrent.Rows[i]["IS_SUSUT_ALAT"].ToString()==null)  IS83 = 0.0;
				else IS83 = Convert.ToDouble(dtCurrent.Rows[i]["IS_SUSUT_ALAT"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IS_SUSUT_INVKNDRN"].ToString())=="" || dtCurrent.Rows[i]["IS_SUSUT_INVKNDRN"].ToString()==null)  IS84 = 0.0;
				else IS84 = Convert.ToDouble(dtCurrent.Rows[i]["IS_SUSUT_INVKNDRN"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IS_TTLSUSUT"].ToString())=="" || dtCurrent.Rows[i]["IS_TTLSUSUT"].ToString()==null)  IS85 = 0.0;
				else IS85 = Convert.ToDouble(dtCurrent.Rows[i]["IS_TTLSUSUT"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IS_PNDPTN"].ToString())=="" || dtCurrent.Rows[i]["IS_PNDPTN"].ToString()==null)  IS86 = 0.0;
				else IS86 = Convert.ToDouble(dtCurrent.Rows[i]["IS_PNDPTN"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IS_BIAYA_LAIN"].ToString())=="" || dtCurrent.Rows[i]["IS_BIAYA_LAIN"].ToString()==null)  IS87 = 0.0;
				else IS87 = Convert.ToDouble(dtCurrent.Rows[i]["IS_BIAYA_LAIN"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IS_LABA_SBLBUNGA"].ToString())=="" || dtCurrent.Rows[i]["IS_LABA_SBLBUNGA"].ToString()==null)  IS88 = 0.0;
				else IS88 = Convert.ToDouble(dtCurrent.Rows[i]["IS_LABA_SBLBUNGA"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IS_BUNGA"].ToString())=="" || dtCurrent.Rows[i]["IS_BUNGA"].ToString()==null)  IS89 = 0.0;
				else IS89 = Convert.ToDouble(dtCurrent.Rows[i]["IS_BUNGA"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IS_LABA_SBLPJK"].ToString())=="" || dtCurrent.Rows[i]["IS_LABA_SBLPJK"].ToString()==null)  IS90 = 0.0;
				else IS90 = Convert.ToDouble(dtCurrent.Rows[i]["IS_LABA_SBLPJK"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IS_PJK"].ToString())=="" || dtCurrent.Rows[i]["IS_PJK"].ToString()==null)  IS92 = 0.0;
				else IS92 = Convert.ToDouble(dtCurrent.Rows[i]["IS_PJK"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IS_LABA_BRSH"].ToString())=="" || dtCurrent.Rows[i]["IS_LABA_BRSH"].ToString()==null)  IS93 = 0.0;
				else IS93 = Convert.ToDouble(dtCurrent.Rows[i]["IS_LABA_BRSH"].ToString());


				/* start ngitung -------------------*/
				/* current ratio - current asset / current liabilities */ 
				if (Math.Abs(BS52) > 0.000001) dCurrentRatio[i] =  BS26/BS52; 
				else dCurrentRatio[i] = 0.00;


				/* rumus salah
				 * Short Term + Long Term + Other liabilities / total net worth */
				/* total hutang / total equity */
				/*salah --- if (Math.Abs(BS63) > 0.000001) dDebtEquityRatio[i] = BS52/BS63; 
				else dDebtEquityRatio[i] = 0.00;*/
				
				/* new rumus
				(Total Hutang Lancar + Total Hutang Jk pjg) / TOtal Modal
				(BS52+BS57)/BS63
				*/
				if (Math.Abs(BS63) > 0.000001) dDebtEquityRatio[i] = (BS52+BS57)/BS63; 
				else dDebtEquityRatio[i] = 0.00;
	

				/*   NEt income/total equity * 12/x months */
				if (Math.Abs(BS63) > 0.000001) dROE[i] = (IS93/BS63) * 100  ; //* BS13/12.0;
				else dROE[i] = 0.00;
				 

				/* net income/net sales */
				if (Math.Abs(IS73) > 0.000001) dNET_PROFIT_MARGIN[i] = (IS93/IS73);
				else dNET_PROFIT_MARGIN[i] = 0.00;
				
				/* Cash/Net Sales */
				if (Math.Abs(IS73) > 0.000001) dCashVelocity[i] = (BS19/IS73)*360;
				else dCashVelocity[i] = 0.00;

				/* piutang dagang / net sales */
				if (Math.Abs(IS73) > 0.000001) dDaysReceivable[i] = (BS21/IS73)*360;
				else dDaysReceivable[i] = 0.00;

				/* Persediaan/cost of goods */
				if (Math.Abs(IS74) > 0.000001) dDaysInventory[i]  = (BS23/IS74)*360;
				else dDaysInventory[i] = 0.00;

				/* Hutang Usaha/pokok */
				if (Math.Abs(IS74) > 0.000001) dDaysAccPay[i] = (BS44/IS74)*360;
				else dDaysAccPay[i] = 0.00;

				dTradeCycle[i] = (dDaysReceivable[i] + dDaysInventory[i]) - dDaysAccPay[i];	
				
				/* current receivables - current liabities  */
				dNETWORKING_CAPITAL[i] = BS26 - BS52;
				
				/* net income / total asset */
				if (Math.Abs(BS40) > 0.000001) dROI[i] = (IS93/BS40)*100; 
				else dROI[i] = 0.00;

				if (Math.Abs(prevIS93) > 0.000001 && i!=0) dNET_PROFIT_GROWTH[i] = (IS93-prevIS93)/prevIS93;
				else dNET_PROFIT_GROWTH[i] = 0.00;	 

				/*
							if (prevBS40 != 0 && i!=0) dTTL_ASSET_TURN_OVER[i] = IS73/prevBS40;
							else dTTL_ASSET_TURN_OVER[i] = 0.00;
							*/
				
				if (Math.Abs(BS40) > 0.000001) dTTL_ASSET_TURN_OVER[i] = IS73/BS40;
				else dTTL_ASSET_TURN_OVER[i] = 0.00;

				/* sales /( current receivables - current liabilities */
				if (Math.Abs(BS26-BS52) > 0.000001) dSalesToWorkingCapital[i] = IS73/(BS26-BS52);
				else dSalesToWorkingCapital[i] = 0.00;
				
				if (Math.Abs(BS63) > 0.000001) dDebtToNetworth[i] = (BS52+BS57)/BS63;
				else dDebtToNetworth[i] = 0.00;

				/* (net profit + depr + amor) /net worth */
				if (Math.Abs(BS46) > 0.000001)dBusinessDebtServiceRatio[i] = (IS93 + BS33 + BS37)/BS46;
				else dBusinessDebtServiceRatio[i] = 0.00;

				/* sales increase  - take what we have, if we does not have prev year */
				if (Math.Abs(prevIS73) > 0.000001)
					dSalesIncrease = (IS73 - prevIS73)/prevIS73;
				else
					dSalesIncrease = 0;

				/* net income increase  ---  take what we have, if we does not have prev year */
				if (Math.Abs(prevIS93) > 0.000001)
					dNetIncomeIncrease = (IS93 - prevIS93)/prevIS93;
				else 
					dNetIncomeIncrease = 0;
	
				/* average net profit */
				if (  Math.Abs(prevIS93) > 0.0000001 )
						dAverageNetProfit = (IS93 + prevIS93) /2;	
				else 
						dAverageNetProfit = IS93;

				//20090324 tambahan scoring EBITDA
				/* CashBanktoHutangBankDagangRatio = CashBank / (HutangBank + HutangDagang) */
				if (Math.Abs(BS44 + BS45) > 0.0000001)
					dCashBanktoHutangBankDagangRatio[i] = BS19 / (BS44 + BS45);
				else
					dCashBanktoHutangBankDagangRatio[i] = 0.00;
				/* HutangBankDagangtoLabaOperasionalRatio = (HutangBank + HutangDagang) / LabaOperasional */
				if ((IS80 > 0.0000001) || (IS80 < -0.0000001))
					dHutangBankDagangtoLabaOperasionalRatio[i] = (BS44 + BS45) / IS80;
				else
					dHutangBankDagangtoLabaOperasionalRatio[i] = 0.00;

				prevIS73 = IS73;
				prevIS93 = IS93;
				prevBS40 = BS40;


				//------ insert into ratio
				/*
				conn.QueryString = "exec CA_RATIO_SMALL_SP 'save','" + curef + "','" + regno + "'," +
					GlobalTools.ToSQLDate(dtCurrent.Rows[i]["posisi_tgl"].ToString()) + "," + GlobalTools.ConvertFloat(dtCurrent.Rows[i]["jml_bln"].ToString()) + ",'" +
					dtCurrent.Rows[i]["jns_lap"].ToString() + "'," + GlobalTools.ConvertFloat(Convert.ToString(dCurrentRatio[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(dDebtEquityRatio[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(dNET_PROFIT_MARGIN[i])) + "," + GlobalTools.ConvertFloat(dtCurrent.Rows[i]["pasv_ttlmodal"].ToString()) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dCashVelocity[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(dDaysReceivable[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(dDaysInventory[i])) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dDaysAccPay[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(dTradeCycle[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(dNETWORKING_CAPITAL[i])) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dROI[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(dNET_PROFIT_GROWTH[i])) +"," + GlobalTools.ConvertFloat(Convert.ToString(dTTL_ASSET_TURN_OVER[i])) + ",0,0,0,0,0,0," + GlobalTools.ConvertFloat(Convert.ToString(dROE[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(dSalesToWorkingCapital[i])) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dDebtToNetworth[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(dBusinessDebtServiceRatio[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(dSalesIncrease)) + "," + GlobalTools.ConvertFloat(Convert.ToString(dNetIncomeIncrease)) + "," + GlobalTools.ConvertFloat(Convert.ToString(dAverageNetProfit)) + ",'" + dtCurrent.Rows[i]["is_proyeksi"].ToString() + "'";  
				*/
				conn.QueryString = "exec CA_RATIO_SMALL_SP 'save','" + curef + "','" + regno + "'," +
					GlobalTools.ToSQLDate(dtCurrent.Rows[i]["posisi_tgl"].ToString()) + "," + GlobalTools.ConvertFloat(dtCurrent.Rows[i]["jml_bln"].ToString()) + ",'" +
					dtCurrent.Rows[i]["jns_lap"].ToString() + "'," + GlobalTools.ConvertFloat(Convert.ToString(dCurrentRatio[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(dDebtEquityRatio[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(dNET_PROFIT_MARGIN[i])) + "," + GlobalTools.ConvertFloat(dtCurrent.Rows[i]["pasv_ttlmodal"].ToString()) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dCashVelocity[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(dDaysReceivable[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(dDaysInventory[i])) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dDaysAccPay[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(dTradeCycle[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(dNETWORKING_CAPITAL[i])) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dROI[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(dNET_PROFIT_GROWTH[i])) +"," + GlobalTools.ConvertFloat(Convert.ToString(dTTL_ASSET_TURN_OVER[i])) + ",0,0,0,0,0,0," + GlobalTools.ConvertFloat(Convert.ToString(dROE[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(dSalesToWorkingCapital[i])) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dDebtToNetworth[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(dBusinessDebtServiceRatio[i])) + "," + GlobalTools.ConvertFloat(Convert.ToString(dSalesIncrease)) + "," + GlobalTools.ConvertFloat(Convert.ToString(dNetIncomeIncrease)) + "," + GlobalTools.ConvertFloat(Convert.ToString(dAverageNetProfit)) + ",'" + dtCurrent.Rows[i]["is_proyeksi"].ToString() + "', " +
					GlobalTools.ConvertFloat(Convert.ToString(dCashBanktoHutangBankDagangRatio[i])) + ", " + GlobalTools.ConvertFloat(Convert.ToString(dHutangBankDagangtoLabaOperasionalRatio[i]));
				conn.ExecuteNonQuery();
			}
			return true;
		}

		private static bool compare_neraca_labarugi_small(System.Web.UI.Page page, string regno, string curef, Connection conn)
		{
			//int row_banding = 0;

			conn.QueryString = "select year(posisi_tgl) tahun, jml_bln bulan from ca_neraca_small where ap_regno = '" + regno + "'";
			conn.ExecuteQuery();
			int row_neraca = conn.GetRowCount();

			conn.QueryString = "select year(posisi_tgl) tahun, jml_bln bulan from ca_labarugi_small where ap_regno = '" + regno + "'";
			conn.ExecuteQuery();
			int row_labarugi = conn.GetRowCount();
			
			conn.QueryString = "select n.ap_regno , year(n.posisi_tgl), year(l.posisi_tgl) " +
                "from ca_neraca_small n inner join ca_labarugi_small l on l.ap_regno = n.ap_regno " +
						"and year(l.posisi_tgl) = year(n.posisi_tgl) and l.jml_bln = n.jml_bln " +
						"and n.jns_lap = l.jns_lap " + 
				"where n.ap_regno = '" + regno + "' ";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();

			if (row_neraca != row_labarugi)
			{
				GlobalTools.popMessage(page,"Ratio tidak bisa di hitung karena periode pada labarugi dan neraca tidak sama!");
				return false;
			}
			else
			{
				if (row == row_neraca) return true;
				else
				{
					GlobalTools.popMessage(page,"Ratio tidak bisa di hitung karena periode pada labarugi dan neraca tidak sama!");
					return false;
				}

			}
			//return true;
		}

		public static void delete_ratio_small(string regno, Connection conn)
		{
			conn.QueryString = "delete from ca_ratio_small where ap_regno = '" + regno + "'" ;
			conn.ExecuteNonQuery();
		}

		/************* end hitung utk small *****************/
		#endregion
	}
}