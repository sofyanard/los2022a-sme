using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.Scoring
{
	/// <summary>
	/// Summary description for MainPRRK.
	/// </summary>
	public partial class BCG_Facility_Detail : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected Tools tool = new Tools();
		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV2;uid=sa;pwd=dmscorp");
		string A0001, A0002, A0003, A0004, A0005, A0006, A0007, A0008, A0009, A0010;
		string A0011, A0012, A0013, A0014, A0015, A0016, A0017, A0018, A0019, A0020;
		string A0021, A0022, A0101, A0102, A0103, A0104, A0105, A0106, A0107, A0108;
		string A0109, A0110, A0111, A0112, A0113, A0114, A0115, A0116, A0201, A0301;
		string A0302, A0303, A0401, A0402, A0403, A0404, A0405, A0406, A0407, A0408;
		string A0409, A0410, A0411, A0412, A0413, A0414, A0415, A0416, A0417, A0418;
		string A0419, A0420, A0421, A0422, A0423, A0424, A0425, A0426, A0427, A0428;
		string A0429, A0430, A0431, A0432, A0433, A0434, A0435, A0436, A0437, A0438;
		string A0439, A0440, A0441, A0442, A0443, A0444, A0502, A0503,CURRENCYID,LIMITCONVERTION; 
/*
		string G0001, G0002, G0003, G0004, G0005,G0006, G0007, G0008, G0009, G0010;
		string G0011, G0012, G0013, G0014, G0015,G0016, G0017, G0018, G0019, G0020;
		string G0021, G0022, G0023, G0024, G0025,G0026, G0027;//, G0028, G0029, G0030;
		string G0031, A0601, A0602, A0603, A0701,A0801, A0802, A0901, A1001, A1002;
		string A1003, A1004;*/
		//, A1011, A1012, A1013;
		// bool CustRatingStatus;
		/* untuk scoring */ 
		protected int i = 0;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				GetCode();
				FillDDL();
				GetCustomerRatingData();
				this.ViewData();
			}
			SecureData();
			setButtonsStatus();
			//btnUpdateStatus.Attributes.Add("onclick", "if(!update()) { return false; };");
			btnUpdateStatus.Attributes.Add("onclick","if(!updateMsg('E')){return false;};");
		}

		private void FillDDL()
		{
			GlobalTools.fillRefList(this.DDL_CURRENCY,"select CURRENCYID,CURRENCYID + ' - ' + CURRENCYDESC AS CURRENCYDESC from RFCURRENCY",conn);
		}

		private void ViewCurrencyRate()
		{
			SetExchangeRateValue();
			Currency(this.LBL_TOTALLIMIT.Text,this.TXT_EXCHANGERATE.Text,this.TXT_TOTALLIMIT,this.TXT_LIMITINMILLION);
		}

		private void SetExchangeRateValue()
		{
			conn.QueryString = "select CURRENCYRATE from RFCURRENCY where CURRENCYID='" +
				this.DDL_CURRENCY.SelectedValue + "'";
			conn.ExecuteQuery();
			if (this.DDL_CURRENCY.SelectedValue== "IDR" || conn.GetFieldValue("CURRENCYRATE")=="")
				this.TXT_EXCHANGERATE.Text = "1";
			else
				this.TXT_EXCHANGERATE.Text	= GlobalTools.MoneyFormat(conn.GetFieldValue("CURRENCYRATE"));
		}

		protected void DDL_CURRENCY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewCurrencyRate();
		}

		private void ViewData() 
		{
			ViewCurrencyRate();
			//conn.QueryString  = "select convert(varchar,GETDATE(),112) AS NOW, " + 
			//	"CONVERT (VARCHAR,DATEADD(YEAR,1,MAX(RATEDATE)),112) AS EXPIREDDATE " +
			//	"from SCOREBCG_RESULT  where AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.QueryString  = "select top 1 convert(varchar,GETDATE(),112) AS NOW, " + 
				"CONVERT (VARCHAR,DATEADD(YEAR,1,RATEDATE),112) AS EXPIREDDATE " +
				"from vw_scorebcg_resultcustrating where CU_REF = '" + Request.QueryString["curef"] +
				"' ORDER BY SEQ DESC";
			conn.ExecuteQuery();

			int now = 0;
			int expired = 0;
			try 
			{
				now		= int.Parse(conn.GetFieldValue("NOW"));
				expired	= int.Parse(conn.GetFieldValue("EXPIREDDATE"));
			} 
			catch {}

			this.LBL_AP_REGNO.Text  = Request.QueryString["regno"];
			this.LBL_CU_REF.Text    = Request.QueryString["curef"];
			this.LBL_KETCODE.Text	= Request.QueryString["ketcode"];
			conn.QueryString = "select ket_code,ket_desc from ketentuan_kredit where ap_regno='" +
				Request.QueryString["regno"] + "' and KET_CODE ='" + Request.QueryString["ketcode"] + "'";
			conn.ExecuteQuery();
			this.TXT_KETENTUANKREDIT.Text		= conn.GetFieldValue("KET_DESC");
			
			if (loadLastRatingData() == true)
			{
				if (now > expired)
				{
					this.BTN_RATE.Text = "Rate";
					this.loadCurrentData();
					ClearResponse();
					return;
				}
				//this.loadLastRatingData();
				this.BTN_RATE.Text = "Re-Rate";
				this.GiveMandatoryClass();
			}
			else
			{
				this.BTN_RATE.Text = "Rate";
				this.loadCurrentData();
				ClearResponse();
			}
		}

		private void loadCurrentData()
		{
			//UNTUK INITIALISASI CURRENCY in IDR
			try{this.DDL_CURRENCY.SelectedValue = "IDR";}
			catch{}
			this.DDL_CURRENCY.Enabled		= true;
			this.TXT_EXCHANGERATE.Text		= "1";
			GetLimitTotal();
			GetNetCollateral();
			resetForeColor();
		}

		private void ClearResponse()
		{
			this.LBL_G0028.Text				= "";
			this.LBL_G0029.Text				= "";
			this.LBL_G0030.Text				= "";
			this.LBL_A1011.Text				= "";
			this.LBL_A1012.Text				= "";
			this.LBL_A1013.Text				= "";
		}

		private bool loadLastRatingData()
		{
			string seq = "";
			//ViewResultRatingData
			conn.QueryString = "SELECT * " +
				"FROM VW_SCOREBCG_RESULTFACRATING where CU_REF ='" + Request.QueryString["curef"] + "' " +
				"and KET_CODE = '" + Request.QueryString["ketcode"] + "' order by SEQ desc";
			conn.ExecuteQuery();
			int jmlresult = conn.GetRowCount();
			if (conn.GetRowCount()> 0)
			{
				seq = conn.GetFieldValue(0,"SEQ");
				this.LBL_G0028.Text				= conn.GetFieldValue(0,"G0028FAC_COLLCOVERAGE");
				this.LBL_G0029.Text				= conn.GetFieldValue(0,"G0029FAC_LGD");
				this.LBL_G0030.Text				= conn.GetFieldValue(0,"G0030FAC_EL");
				this.LBL_A1011.Text				= conn.GetFieldValue(0,"A1011FAC_AVERAGEPD");
				this.LBL_A1012.Text				= conn.GetFieldValue(0,"A1012FAC_EAD");
				this.LBL_A1013.Text				= conn.GetFieldValue(0,"A1013FAC_RISKCLASS");
				this.DDL_CURRENCY.Enabled = false;// bila load last rating data maka currency tdk bisa diubah lagi
			}
			
			//ViewInputRatingData
			if (seq != "")
			{
				conn.QueryString = "select CURRENCYID,A0201INDUSTRIALCODE,A0301NETCOLL,A0302FACVALUE from VW_SCOREBCG_INPUTFACRATING " +
					"where CU_REF ='" + Request.QueryString["curef"]  + "' " + "and KET_CODE = '" + 
					Request.QueryString["ketcode"] + "' and SEQ = " + seq + " order by SEQ desc";
				conn.ExecuteQuery();
			}
			if (conn.GetRowCount () > 0)
			{
				this.LBL_INDUSTRIALCODE.Text	= conn.GetFieldValue(0,"A0201INDUSTRIALCODE");
				this.LBL_COLLATERAL.Text		= conn.GetFieldValue(0,"A0301NETCOLL");
				this.TXT_LIMITINMILLION.Text	= GlobalTools.MoneyFormat(conn.GetFieldValue(0,"A0302FACVALUE"));
				try 
				{
					this.DDL_CURRENCY.SelectedValue = conn.GetFieldValue(0,"CURRENCYID");
				} 
				catch {}
				   
				double lim; 
				try 
				{
					lim = Convert.ToDouble(conn.GetFieldValue(0,"A0302FACVALUE"));
				} 
				catch {lim =0;}
				lim = lim*1000000;
				this.TXT_TOTALLIMIT.Text = GlobalTools.MoneyFormat(lim.ToString());
							    
				//set value EXCHANGE RATE
				SetExchangeRateValue();				
			}
			if (jmlresult > 0)
				return true;
			else
				return false;
		}

		private void GiveMandatoryClass()
		{
			GetLimitTotal();
			this.CheckBeda(this.LBL_CURRENTLIMIT.Text,this.TXT_LIMITINMILLION.Text,this.TXT_LIMITINMILLION);						
		}

		private void resetForeColor()
		{
			this.TXT_LIMITINMILLION.ForeColor = System.Drawing.Color.Black;
		}

		private void GetCustomerRatingData()
		{
			string seq = "";
			conn.QueryString = "select TOP 1 * from VW_SCOREBCG_RESULTCUSTRATING where CU_REF ='" +
				Request.QueryString["curef"] + "' order by RATEDATE desc";
			conn.ExecuteQuery();
			if (conn.GetRowCount () > 0)
			{
				seq = conn.GetFieldValue(0,"SEQ");
			}
			if (seq != "")
			{
				conn.QueryString = "select * from VW_SCOREBCG_INPUTCUSTRATING where CU_REF ='" +
					Request.QueryString["curef"] + "' and SEQ = " + seq + " order by SEQ desc";
				conn.ExecuteQuery();
			}
			if (conn.GetRowCount () > 0 && seq != "")
			{
				A0001 = conn.GetFieldValue(0,"A0001OPERATING_CASHFLOW_TO_DEBT");
				A0002 = conn.GetFieldValue(0,"A0002CURRENT_RATIO");
				A0003 = conn.GetFieldValue(0,"A0003ABSOLUTE_DEBT_TO_EQUITY");
				A0004 = conn.GetFieldValue(0,"A0004DEBT_TO_ASSETS");
				A0005 = conn.GetFieldValue(0,"A0005EBITDA_TO_INTERESTEXPENSE");
				A0006 = conn.GetFieldValue(0,"A0006RETURN_ON_AVERAGE_EQUITY");
				A0007 = conn.GetFieldValue(0,"A0007NET_MARGIN");
				A0008 = conn.GetFieldValue(0,"A0008ASSETS_TURNOVER");
				A0009 = conn.GetFieldValue(0,"A0009INVENTORY_TURNOVER");
				A0010 = conn.GetFieldValue(0,"A0010EBITDA_GROWTH");
				A0011 = conn.GetFieldValue(0,"A0011NET_INCOME_GROWTH");
				A0012 = conn.GetFieldValue(0,"A0012QUICK_RATIO");
				A0013 = conn.GetFieldValue(0,"A0013DEBT_TO_CAPITAL");
				A0014 = conn.GetFieldValue(0,"A0014LONGTERM_DEBT_TO_EQUITY");
				A0015 = conn.GetFieldValue(0,"A0015EBITDA_TO_DEBT");
				A0016 = conn.GetFieldValue(0,"A0016EBITDA_TO_LIABILITIES");
				A0017 = conn.GetFieldValue(0,"A0017RECEIVABLE_TURNOVER");
				A0018 = conn.GetFieldValue(0,"A0018FIXED_ASSETS_TURNOVER");
				A0019 = conn.GetFieldValue(0,"A0019OPERATING_MARGIN");
				A0020 = conn.GetFieldValue(0,"A0020SALES_GROWTH");
				A0021 = conn.GetFieldValue(0,"A0021RETURN_ON_AVERAGE_ASSETS");
				A0022 = conn.GetFieldValue(0,"A0022OPERATING_CASHFLOW_TO_INTERESTEXPENSE");
				A0101 = conn.GetFieldValue(0,"A0101BMCUST");
				A0102 = conn.GetFieldValue(0,"A0102BIIBRASIDPRESENT");
				A0103 = conn.GetFieldValue(0,"A0103RECENTCUST");
				A0104 = conn.GetFieldValue(0,"A0104PRIORDEFAULTWITHLOSSES");
				A0105 = conn.GetFieldValue(0,"A0105DEFAULTNOW");
				A0106 = conn.GetFieldValue(0,"A0106BIIBRASIDAPPEAR");
				A0107 = conn.GetFieldValue(0,"A0107RECONPREVDEFAULT");
				A0108 = conn.GetFieldValue(0,"A0108DEFAULTWITHLOSSES");
				A0109 = conn.GetFieldValue(0,"A0109EXPERIENCEEXPERTISE");
				A0110 = conn.GetFieldValue(0,"A0110INFDISCLOSURE");
				A0111 = conn.GetFieldValue(0,"A0111REPUTATION");
				A0112 = conn.GetFieldValue(0,"A0112CAPITALSUPPORT");
				A0113 = conn.GetFieldValue(0,"A0113MARKETSHARE");
				A0114 = conn.GetFieldValue(0,"A0114PRODCOMPETITIVENESS");
				A0115 = conn.GetFieldValue(0,"A0115COSTEFFICIENCY");
				A0116 = conn.GetFieldValue(0,"A0116THIRDPARTYDEPENDANCY");
				//******************** Input For Facility Rating
				//A0301 = conn.GetFieldValue(0,41);
				//A0302 = conn.GetFieldValue(0,42);
				//********************
				this.LBL_INDUSTRIALCODE.Text = conn.GetFieldValue(0,"A0201INDUSTRIALCODE");
				A0303 = conn.GetFieldValue(0,"A0303ACCEPTCUSTRISKCLASS");
				A0401 = conn.GetFieldValue(0,"A0401MEDOPERATING_CASHFLOW_TO_DEBT");
				A0402 = conn.GetFieldValue(0,"A0402MEDCURRENT_RATIO");
				A0403 = conn.GetFieldValue(0,"A0403MEDABSOLUTE_DEBT_TO_EQUITY");
				A0404 = conn.GetFieldValue(0,"A0404MEDDEBT_TO_ASSETS");
				A0405 = conn.GetFieldValue(0,"A0405MEDEBITDA_TO_INTERESTEXPENSE");
				A0406 = conn.GetFieldValue(0,"A0406MEDRETURN_ON_AVERAGE_EQUITY");
				A0407 = conn.GetFieldValue(0,"A0407MEDNET_MARGIN");
				A0408 = conn.GetFieldValue(0,"A0408MEDASSETS_TURNOVER");
				A0409 = conn.GetFieldValue(0,"A0409MEDINVENTORY_TURNOVER");
				A0410 = conn.GetFieldValue(0,"A0410MEDEBITDA_GROWTH");
				A0411 = conn.GetFieldValue(0,"A0411MEDNET_INCOME_GROWTH");
				A0412 = conn.GetFieldValue(0,"A0412MEDQUICK_RATIO");
				A0413 = conn.GetFieldValue(0,"A0413MEDDEBT_TO_CAPITAL");
				A0414 = conn.GetFieldValue(0,"A0414MEDLONGTERM_DEBT_TO_EQUITY");
				A0415 = conn.GetFieldValue(0,"A0415MEDEBITDA_TO_DEBT");
				A0416 = conn.GetFieldValue(0,"A0416MEDEBITDA_TO_LIABILITIES");
				A0417 = conn.GetFieldValue(0,"A0417MEDRECEIVABLE_TURNOVER");
				A0418 = conn.GetFieldValue(0,"A0418MEDFIXED_ASSETS_TURNOVER");
				A0419 = conn.GetFieldValue(0,"A0419MEDOPERATING_MARGIN");
				A0420 = conn.GetFieldValue(0,"A0420MEDSALES_GROWTH");
				A0421 = conn.GetFieldValue(0,"A0421MEDRETURN_ON_AVERAGE_ASSETS");
				A0422 = conn.GetFieldValue(0,"A0422MEDOPERATING_CASHFLOW_TO_INTERESTEXPENSE");
				A0423 = conn.GetFieldValue(0,"A0423EXTOPERATING_CASHFLOW_TO_DEBT");
				A0424 = conn.GetFieldValue(0,"A0424EXTCURRENT_RATIO");
				A0425 = conn.GetFieldValue(0,"A0425EXTABSOLUTE_DEBT_TO_EQUITY");
				A0426 = conn.GetFieldValue(0,"A0426EXTDEBT_TO_ASSETS");
				A0427 = conn.GetFieldValue(0,"A0427EXTEBITDA_TO_INTERESTEXPENSE");
				A0428 = conn.GetFieldValue(0,"A0428EXTRETURN_ON_AVERAGE_EQUITY");
				A0429 = conn.GetFieldValue(0,"A0429EXTNET_MARGIN");
				A0430 = conn.GetFieldValue(0,"A0430EXTASSETS_TURNOVER");
				A0431 = conn.GetFieldValue(0,"A0431EXTINVENTORY_TURNOVER");
				A0432 = conn.GetFieldValue(0,"A0432EXTEBITDA_GROWTH");
				A0433 = conn.GetFieldValue(0,"A0433EXTNET_INCOME_GROWTH");
				A0434 = conn.GetFieldValue(0,"A0434EXTQUICK_RATIO");
				A0435 = conn.GetFieldValue(0,"A0435EXTDEBT_TO_CAPITAL");
				A0436 = conn.GetFieldValue(0,"A0436EXTLONGTERM_DEBT_TO_EQUITY");
				A0437 = conn.GetFieldValue(0,"A0437EXTEBITDA_TO_DEBT");
				A0438 = conn.GetFieldValue(0,"A0438EXTEBITDA_TO_LIABILITIES");
				A0439 = conn.GetFieldValue(0,"A0439EXTRECEIVABLE_TURNOVER");
				A0440 = conn.GetFieldValue(0,"A0440EXTFIXED_ASSETS_TURNOVER");
				A0441 = conn.GetFieldValue(0,"A0441EXTOPERATING_MARGIN");
				A0442 = conn.GetFieldValue(0,"A0442EXTSALES_GROWTH");
				A0443 = conn.GetFieldValue(0,"A0443EXTRETURN_ON_AVERAGE_ASSETS");
				A0444 = conn.GetFieldValue(0,"A0444EXTOPERATING_CASHFLOW_TO_INTERESTEXPENSE");
				A0502 = conn.GetFieldValue(0,"A0502FINANCIAL_RATING");
				A0503 = conn.GetFieldValue(0,"A0503DUMMY_FIELD");
				CURRENCYID = conn.GetFieldValue(0,"CURRENCYID");
				LIMITCONVERTION = conn.GetFieldValue(0,"LIMITCONVERTION");
				LBL_STATUS.Text = "1";
			}
			else
				LBL_STATUS.Text = "0"; 
		}

		private void GetLimitTotal()
		{
			//Get Limit Total
			double limittotaldouble=0;double limitmillion=0;
			string limittotal,limittotalInMillion;
		
			//conn.QueryString = "select * from VW_SCOREBCG_LIMITLIST where AP_REGNO = '"+
			//	Request.QueryString["regno"] + "' and KET_CODE ='" + Request.QueryString["ketcode"]+ "'";
			conn.QueryString = "exec SCOREBCG_LIMITLIST '" + Request.QueryString["regno"] + "', '" + 
				Request.QueryString["curef"] + "', '" + Request.QueryString["ketcode"] + "'";
			conn.ExecuteQuery();
			int jml = conn.GetRowCount();
			double[] limitdb = new double[jml];	double[] limit = new double[jml];
			int p=0;
			DataTable dt = conn.GetDataTable();
			foreach(DataRow dr in dt.Rows) 
			{
				try 
				{
					limitdb[p] = Convert.ToDouble(dr["LIMIT"].ToString());
				} 
				catch {limitdb[p] = 0;}
				try
				{
					limit[p] = Convert.ToDouble(limitdb[p].ToString());
				} 
				catch {limit[p]=0;}
				limittotaldouble += limit[p];
				p++;
			}
				
			limitmillion		= limittotaldouble/1000000;
			limittotal			= limittotaldouble.ToString("##,#0.00");
			limittotalInMillion = limitmillion.ToString("##,#0.00");
			this.TXT_TOTALLIMIT.Text		= GlobalTools.MoneyFormat(limittotal);
			this.LBL_TOTALLIMIT.Text		= GlobalTools.MoneyFormat(limittotal);
			A0302							= limittotalInMillion;
			this.TXT_LIMITINMILLION.Text	= GlobalTools.MoneyFormat(limittotalInMillion);
			this.LBL_CURRENTLIMIT.Text		= limittotalInMillion;
			
		}

		private void GetNetCollateral()
		{
			conn.QueryString = "select * from  VW_SCOREBCG_GETCOLLATERALLIST where AP_REGNO ='" +
				Request.QueryString["regno"] + "' and KET_CODE = '" +this.LBL_KETCODE.Text+ "'";
			conn.ExecuteQuery(300);
			//get LC_value n cl_seq
			int jml = conn.GetRowCount();
			
			string[] lcvalue = new string[jml];string[] liquidation = new string[jml];
			string[] cl_seq = new string[jml];string[] cl_type = new string[jml];
			string[] rating = new string[jml];
			double [] lcdouble = new double[jml];double [] lc = new double[jml];
			double [] liqdouble = new double[jml];
			double lc_valuedouble = 0;
			int p=0;
			DataTable dt = conn.GetDataTable();
			foreach(DataRow dr in dt.Rows) 
			{
				cl_seq[p]	= dr["CL_SEQ"].ToString();//collateral seq
				cl_type[p]	= dr["CL_TYPE"].ToString();//collateral type seq
				lcvalue[p]	= dr["LC_VALUE"].ToString(); //pledge value ... (nanti dikali rating code)
				try
				{
					lcdouble[p] = Convert.ToDouble(lcvalue[p].ToString());
				} 
				catch {lcdouble[p]=0;}

				conn.QueryString = "select COLTYPEID,RATINGCODE FROM RFCOLLATERALTYPE WHERE COLTYPESEQ ='" +
					cl_type[p] + "'";
				conn.ExecuteQuery();
				rating[p] = conn.GetFieldValue("RATINGCODE");
				if (rating[p] != "A")
				{
					conn.QueryString = "select LIQUIDATIONVALUE from RFLIQUIDATIONRATE where RATINGCODE ='" +
						rating[p] +"'";
					conn.ExecuteQuery();
					liquidation[p] = conn.GetFieldValue("LIQUIDATIONVALUE");
				}
				else //ambil mortgage type-nya untuk mendapatkan rating....
				{
					conn.QueryString = "select * from VW_SCOREBCG_GETCERTTYPE where CU_REF = '" +
						Request.QueryString["curef"] + "' and cl_seq = '" + cl_seq[p]+ "'";
					conn.ExecuteQuery();
					rating[p] = conn.GetFieldValue("RATINGCODE");

					conn.QueryString = "select LIQUIDATIONVALUE from RFLIQUIDATIONRATE where RATINGCODE ='" +
						rating[p] +"'";
					conn.ExecuteQuery();
					liquidation[p] = conn.GetFieldValue("LIQUIDATIONVALUE");
				}
				try 
				{
					liqdouble[p] = Convert.ToDouble(liquidation[p]);
				} 
				catch {liqdouble[p]=0;}
				try 
				{
					lc[p]= lcdouble[p]*liqdouble[p]/100;
				} 
				catch {lc[p]=0;}
				lc_valuedouble +=lc[p];
				p++;
			}
			lc_valuedouble = Math.Round(lc_valuedouble / 1000000.0);
			int lc_valueint = Convert.ToInt32(lc_valuedouble);
			string final = lc_valueint.ToString();
			A0301					 = final;
			this.LBL_COLLATERAL.Text = final;
			
		}

		private void GetCode()
		{
			this.LBL_KETCODE.Text		= Request.QueryString["ketcode"];
		}

		private static string Devide100(string str)
		{
			double num;string retval;
			try
			{
				num = (Convert.ToDouble(str.Trim())/100);
			} 
			catch 
			{
				num = 0;
			}
			retval = num.ToString("##,#0.00");
			return retval;
		}

		private static string Multiply100(string str)
		{
			double num;string retval;
			try
			{
				num = (Convert.ToDouble(str.Trim())*100);
			} 
			catch 
			{
				num = 0;
			}
			retval = num.ToString("##,#0.00");
			return retval;
		}

		private void SaveRatingData()
		{
			conn.QueryString = "EXEC SCOREBCG_CUSTFINANCIALRATIO '" + Request.QueryString["regno"] + "', '" +
				Request.QueryString["curef"] + "'";		
			conn.ExecuteQuery();

			string NetTradeCycle = Devide100(conn.GetFieldValue(0, "NET_TRADE_CYCLE"));
			string GearingRatio = Devide100(conn.GetFieldValue(0, "GEARING_RATIO"));
			string RevenuePerMonth = Devide100(conn.GetFieldValue(0, "NET_REVENUE_PERMONTH"));
			string AccreceivableToLiabilities = Devide100(conn.GetFieldValue(0, "ACCRECEIVABLE_TO_LIABILITIES"));
			string EquityToAsset = Devide100(conn.GetFieldValue(0, "EQUITY_TO_ASSET"));
			string AssetToGrowth = Devide100(conn.GetFieldValue(0, "ASSET_GROWTH"));
			string EfficiencyRatio = Devide100(conn.GetFieldValue(0, "EFICIENCY_RATIO"));
			string TotalAsset = Devide100(conn.GetFieldValue(0, "TOTAL_ASSET"));
			string AccreceivableToAsset = Devide100(conn.GetFieldValue(0, "ACCRECEIVABLE_TO_ASSET"));
			string ReceivablesGrowth = Devide100(conn.GetFieldValue(0, "RECEIVABLES_GROWTH"));
			string EquityGrowth = Devide100(conn.GetFieldValue(0, "EQUITY_GROWTH"));

			/**
			 * data-data yang disimpan ke dalam table scorebcg_input
			 * Data Type-nya belum sesuai data Dictionary
			 * sehingga sebelum dikirim ke STW harus dikonversi dulu
			 * 
			 * */
			GetCode();
			GetCustomerRatingData();
			//********* SAVE INPUT *********
			conn.QueryString = "exec SCOREBCG_INPUT_SAVE '" + Request.QueryString["regno"] + "','" + 
				Request.QueryString["curef"] + "','" + Request.QueryString["ketcode"] + "'," + 
				GlobalTools.ConvertFloat(A0001) + "," + GlobalTools.ConvertFloat(A0002) + "," + 
				GlobalTools.ConvertFloat(A0003) + "," + GlobalTools.ConvertFloat(A0004) + "," + 
				GlobalTools.ConvertFloat(A0005) + "," + GlobalTools.ConvertFloat(A0006) + "," + 
				GlobalTools.ConvertFloat(A0007) + "," + GlobalTools.ConvertFloat(A0008) + "," + 
				GlobalTools.ConvertFloat(A0009) + "," + GlobalTools.ConvertFloat(A0010) + "," + 
				GlobalTools.ConvertFloat(A0011) + "," + GlobalTools.ConvertFloat(A0012) + "," + 
				GlobalTools.ConvertFloat(A0013) + "," + GlobalTools.ConvertFloat(A0014) + "," + 
				GlobalTools.ConvertFloat(A0015) + "," + GlobalTools.ConvertFloat(A0016) + "," + 
				GlobalTools.ConvertFloat(A0017) + "," + GlobalTools.ConvertFloat(A0018) + "," + 
				GlobalTools.ConvertFloat(A0019) + "," + GlobalTools.ConvertFloat(A0020) + "," + 
				GlobalTools.ConvertFloat(A0021) + "," + GlobalTools.ConvertFloat(A0022) + ",'" + 
				//A0101-A0108 
				A0101 + "','" + A0102 + "','" +	A0103 + "','" + A0104 + "','" +
				A0105 + "','" + A0106 + "','" + A0107 + "','" + A0108 + "','" +
				//A0109-A0116
				A0109 + "','" + A0110 + "','" + A0111 + "','" + A0112 + "','" + 
				A0113 + "','" + A0114 + "','" + A0115 + "','" + A0116 + "','" +
				//A0201,A0301,A0302,A0303 .... Industrial Code(A0201)
				//A0201 + "'," + GlobalTools.ConvertFloat(A0301) + ","+ GlobalTools.ConvertFloat(A0302) + ",'" +
				this.LBL_INDUSTRIALCODE.Text + "'," + GlobalTools.ConvertFloat(this.LBL_COLLATERAL.Text) + ","+ 
				GlobalTools.ConvertFloat(this.TXT_LIMITINMILLION.Text) + ",'" +
				A0303 + "'," +
				//A0401-A0444 
				GlobalTools.ConvertFloat(A0401)  + "," + GlobalTools.ConvertFloat(A0402)  + "," + 
				GlobalTools.ConvertFloat(A0403)  + "," + GlobalTools.ConvertFloat(A0404)  + "," + 
				GlobalTools.ConvertFloat(A0405)  + "," + GlobalTools.ConvertFloat(A0406)  + "," + 
				GlobalTools.ConvertFloat(A0407)  + "," + GlobalTools.ConvertFloat(A0408)  + "," + 
				GlobalTools.ConvertFloat(A0409)  + "," + GlobalTools.ConvertFloat(A0410)  + "," + 
				GlobalTools.ConvertFloat(A0411)  + "," + GlobalTools.ConvertFloat(A0412)  + "," + 
				GlobalTools.ConvertFloat(A0413)  + "," + GlobalTools.ConvertFloat(A0414)  + "," + 
				GlobalTools.ConvertFloat(A0415)  + "," + GlobalTools.ConvertFloat(A0416)  + "," + 
				GlobalTools.ConvertFloat(A0417)  + "," + GlobalTools.ConvertFloat(A0418)  + "," + 
				GlobalTools.ConvertFloat(A0419)  + "," + GlobalTools.ConvertFloat(A0420)  + "," + 
				GlobalTools.ConvertFloat(A0421)  + "," + GlobalTools.ConvertFloat(A0422)  + "," + 
				GlobalTools.ConvertFloat(A0423)  + "," + GlobalTools.ConvertFloat(A0424)  + "," + 
				GlobalTools.ConvertFloat(A0425)  + "," + GlobalTools.ConvertFloat(A0426)  + "," + 
				GlobalTools.ConvertFloat(A0427)  + "," + GlobalTools.ConvertFloat(A0428)  + "," + 
				GlobalTools.ConvertFloat(A0429)  + "," + GlobalTools.ConvertFloat(A0430)  + "," + 
				GlobalTools.ConvertFloat(A0431)  + "," + GlobalTools.ConvertFloat(A0432)  + "," + 
				GlobalTools.ConvertFloat(A0433)  + "," + GlobalTools.ConvertFloat(A0434)  + "," + 
				GlobalTools.ConvertFloat(A0435)  + "," + GlobalTools.ConvertFloat(A0436)  + "," + 
				GlobalTools.ConvertFloat(A0437)  + "," + GlobalTools.ConvertFloat(A0438)  + "," + 
				GlobalTools.ConvertFloat(A0439)  + "," + GlobalTools.ConvertFloat(A0440)  + "," + 
				GlobalTools.ConvertFloat(A0441)  + "," + GlobalTools.ConvertFloat(A0442)  + "," + 
				GlobalTools.ConvertFloat(A0443)  + "," + GlobalTools.ConvertFloat(A0444)  + ",'" +
				GlobalTools.ConvertFloat(A0502)  + "','" + GlobalTools.ConvertFloat(A0503)  + "','" +
				this.DDL_CURRENCY.SelectedValue.ToString() + "'," + GlobalTools.ConvertFloat(this.TXT_TOTALLIMIT.Text) + ",NULL,NULL," +
				GlobalTools.ConvertFloat(Multiply100(NetTradeCycle)) + "," +
				GlobalTools.ConvertFloat(Multiply100(GearingRatio)) + "," +
				GlobalTools.ConvertFloat(Multiply100(RevenuePerMonth)) + "," +
				GlobalTools.ConvertFloat(Multiply100(AccreceivableToAsset)) + "," +
				GlobalTools.ConvertFloat(Multiply100(AccreceivableToLiabilities)) + "," +
				GlobalTools.ConvertFloat(Multiply100(EquityToAsset)) + "," +
				GlobalTools.ConvertFloat(Multiply100(AssetToGrowth)) + "," +
				GlobalTools.ConvertFloat(Multiply100(ReceivablesGrowth)) + "," +
				GlobalTools.ConvertFloat(Multiply100(EquityGrowth)) + "," +
				GlobalTools.ConvertFloat(Multiply100(EfficiencyRatio)) + "," +
				GlobalTools.ConvertFloat(Multiply100(TotalAsset));
			conn.ExecuteNonQuery();

			conn.QueryString = "select TOP 1 SEQ from VW_SCOREBCG_INPUTFACRATING where CU_REF ='" +
				Request.QueryString["curef"] + "' and KET_CODE = '" + Request.QueryString["ketcode"] +
				"' order by RATEDATE desc";
			conn.ExecuteQuery();
			LBL_SCOREBCG_SEQ.Text = conn.GetFieldValue(0,0);	//load the last seq to be used when loading the result 

		}

		private void setButtonsStatus()
		{
			conn.QueryString = "exec SCOREBCG_SETBUTTON '" + Request.QueryString["regno"] + "' ";
			conn.ExecuteQuery();
			btnUpdateStatus.Enabled = false;
			BTN_RATE.Enabled = false;
			try
			{
				if(conn.GetFieldValue(0,"UPDBTNSTA") == "1")
					btnUpdateStatus.Enabled = true;
				if(conn.GetFieldValue(0,"RATEBTNSTA") == "1")
					BTN_RATE.Enabled = true;
				if(conn.GetFieldValue(0,"MSG") != "")
					GlobalTools.popMessage(this, conn.GetFieldValue(0,"MSG"));
			} 
			catch {}
		}

		protected void BTN_RATE_Click(object sender, System.EventArgs e)
		{
			clsBCGScoring bcg = new clsBCGScoring(conn);
			
			if (LBL_STATUS.Text == "0")
			{
				GlobalTools.popMessage(this,"Rate failed, Customer must be rated first!");
				return;
			}
			
			if (this.LBL_COLLATERAL.Text == "0" || this.LBL_COLLATERAL.Text == "")
			{
//				GlobalTools.popMessage(this,"Rate failed, Net Collateral cannot be zero!");
//				return;
				this.LBL_COLLATERAL.Text = "1";
			}
		
			if(this.BTN_RATE.Text == "Re-Rate")
			{
				BTN_RATE.Text = "Rate";
				loadCurrentData(); 
				this.ClearResponse();
			}
			else if ((this.BTN_RATE.Text == "Rate") && (LBL_TRY.Text == "0"))
			{ // button Rate ditekan untuk pertama kali, 
				SaveRatingData(); 
				/******************************************
				 * Antisipasi mendapatkan result yang salah
				 ******************************************/
				conn.QueryString  = "delete from SCORING_RESPONSE where AP_REGNO like '%" + Request.QueryString["regno"] + "%' ";
				//conn.QueryString += "and SUMBERDATA = 'RATINGCUSTOMER'"; //SCOREBCG_TEXT_MESSAGE";
				conn.ExecuteNonQuery();

				/* 20081203, no use STW anymore...
				bcg.GenerateSendTextFile(Request.QueryString["regno"],Request.QueryString["tc"],Request.QueryString["ketcode"]); // send message to queue
				bool success = bcg.UploadResponse(this,Request.QueryString["regno"],Request.QueryString["curef"],Request.QueryString["ketcode"]); // try to get Response
				if (success) 
				{ // jika proses upload sukses
					BTN_RATE.Text = "Re-Rate"; 
					ViewResponseData();
					BTN_RATE.Enabled = true;
					btnUpdateStatus.Enabled = true;
				}
				else 
				{ // jika proses upload gagal, user diminta menunggu dan dapat menekan tombol Rate untuk 
					// dapatkan response jika sudah ada
					LBL_TRY.Text += "0";
					BTN_RATE.Text = "Retreive Rate";
					BTN_RATE.Enabled = true; //false;
					btnUpdateStatus.Enabled = false;
				}
				*/
				
				//20081203, Calculate Facility Rating in LOS
				try
				{
					conn.QueryString  = "EXEC SCOREBCG_CALCULATEFACILITYRATINGBYLOS '" + Request.QueryString["regno"] + "', '" + Request.QueryString["ketcode"] + "'";
					conn.ExecuteNonQuery();

					if (conn.GetRowCount() > 0)
					{
						BTN_RATE.Text = "Re-Rate"; 
						ViewResponseData();
						BTN_RATE.Enabled = true;
						btnUpdateStatus.Enabled = true;
					}
				}
				catch (Exception ex)
				{
					string errmsg = ex.Message.Replace("'","");
					if (errmsg.IndexOf("Last Query:") > 0)
						errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
					GlobalTools.popMessage(this, errmsg);
					return;
				}
			} 
			else if (this.BTN_RATE.Text == "Retreive Rate")
			{ // vek apakah response sudah ada apa belum
				if (LBL_TRY.Text.Length <= 3)
				{ 
					bool success = bcg.UploadResponse(this,Request.QueryString["regno"],Request.QueryString["curef"],Request.QueryString["ketcode"]);
					if (success) 
					{ // jika upload berhasil, teks button diganti, status mencoba diset ke 0 (first chance)
						BTN_RATE.Text = "Re-Rate";
						ViewResponseData();
						LBL_TRY.Text = "0"; 
						BTN_RATE.Enabled = true;
						btnUpdateStatus.Enabled = true;
					} 
					else 
					{
						LBL_TRY.Text += "0";
						BTN_RATE.Enabled = true; //false;
						btnUpdateStatus.Enabled = false;
					}
				} 
				else 
				{	// user sudah 3 kali gagal
					GlobalTools.popMessage(this, "Gagal mendapatkan response dari Strategy Ware. Silahkan mencoba Rate kembali!");
					BTN_RATE.Text = "Rate";
					LBL_TRY.Text = "0";
				}
			}
		}
		

		private void ViewResponseData()
		{
			try
			{
				//conn.QueryString  = "select top 1 * from VW_SCOREBCG_RESULT where ";
				//conn.QueryString += "AP_REGNO = '" + Request.QueryString["regno"] + "'";
				//conn.QueryString  = "SELECT * FROM  VW_SCOREBCG_RESULTFACRATING WHERE AP_REGNO = '" +
				//	Request.QueryString["regno"] + "' AND KET_CODE = '" + 
				//	Request.QueryString["ketcode"] + "' AND  SEQ = (select MAX(SEQ) FROM " +
				//	" VW_SCOREBCG_RESULTFACRATING WHERE AP_REGNO = '" +
				//	Request.QueryString["regno"] + "' AND KET_CODE = '" + 
				//	Request.QueryString["ketcode"] + "')";
				conn.QueryString  = "select top 1 * from VW_SCOREBCG_RESULTFACRATING where AP_REGNO = '" +
					Request.QueryString["regno"] + "' and seq = " + LBL_SCOREBCG_SEQ.Text;	//this method called after rate, thus by this ap_regno
				conn.ExecuteQuery();

				/* FACILITY RATING */
				LBL_G0028.Text = conn.GetFieldValue( "G0028FAC_COLLCOVERAGE" );
				LBL_G0029.Text = conn.GetFieldValue( "G0029FAC_LGD");
				LBL_G0030.Text = conn.GetFieldValue( "G0030FAC_EL");
				LBL_A1011.Text = conn.GetFieldValue( "A1011FAC_AVERAGEPD");
				LBL_A1012.Text = conn.GetFieldValue( "A1012FAC_EAD");
				LBL_A1013.Text = conn.GetFieldValue( "A1013FAC_RISKCLASS");
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Error loading response data!");
				return;
			}
			setButtonsStatus();
		}

		private void Currency(string nominal1, string exchangerate, TextBox txt1, TextBox txt2)
		{
			//nominal1 = nominal in IDR
			string str1 = "";
			
			double nil1 = 0; double nil2=0; double exc=0; double nil3 = 0;
			if (exchangerate.Trim() == "")
				exchangerate="1";
			try 
			{
				nil1 = Convert.ToDouble(nominal1);
			} 
			catch {nil1=0;}
			try 
			{
				exc = Convert.ToDouble(exchangerate);
			} 
			catch {exc=0;}
			
			nil2 = nil1*(Convert.ToDouble(exchangerate));
			nil3 = nil2/1000000;
			txt1.Text = nil2.ToString();
			txt2.Text = nil3.ToString();
		}

		private void CheckBeda(string a,string b, TextBox txt)
		{
			if (a != b)
				txt.ForeColor = System.Drawing.Color.Red;
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    			

		}
		#endregion

		private void SecureData() 
		{
			string scr = Request.QueryString["scr"];

			if (scr == "0")
			{
				int index = -1;
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for(int j=0; j<coll.Count; j++) 
				{
					if (coll[j] is HtmlForm) 
					{
						index = j;
						break;
					}
				}

				for (int i = 0; i < coll[index].Controls.Count; i++) 
				{
					if (coll[index].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[index].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[index].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[index].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[index].Controls[i] is Button)
					{
						Button btn = (Button) coll[index].Controls[i];
						btn.Visible = false;
					}
					else if (coll[index].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[index].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[index].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[index].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[index].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[index].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[index].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[index].Controls[i];

						for (int j=0; j < htr.Controls.Count; j++) 
						{							
							for (int jj = 0; jj < htr.Controls[j].Controls.Count; jj++) 
							{
								if (htr.Controls[j].Controls[jj] is TextBox) 
								{
									TextBox txt = (TextBox) htr.Controls[j].Controls[jj];
									txt.ReadOnly = true;
								}
								else if (htr.Controls[j].Controls[jj] is DropDownList) 
								{
									DropDownList ddl = (DropDownList) htr.Controls[j].Controls[jj];
									ddl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is Button)
								{
									Button btn = (Button) htr.Controls[j].Controls[jj];
									btn.Visible = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButtonList) 
								{
									RadioButtonList rbl = (RadioButtonList) htr.Controls[j].Controls[jj];
									rbl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButton) 
								{
									RadioButton rb = (RadioButton) htr.Controls[j].Controls[jj];
									rb.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is CheckBox)
								{
									CheckBox cb = (CheckBox) htr.Controls[j].Controls[jj];
									cb.Enabled = false;
								}					
							}
						}
					}
				}
			}
		}

		protected void btnUpdateStatus_Click(object sender, System.EventArgs e)
		{
			DataTable dt;
			conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + Request.QueryString["regno"] +
				"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				conn.QueryString = "exec TRACKUPDATE '" + Request.QueryString["regno"] + "', '" +
					dt.Rows[i][1].ToString() + "', '" + dt.Rows[i][0].ToString() + "', '" + Session["UserID"].ToString() + "', '" + dt.Rows[i]["PROD_SEQ"].ToString() + "','"+Request.QueryString["tc"].Trim()+"'";
				conn.ExecuteNonQuery();
			}

						
			this.backToList();
		}

		private void backToList() 
		{
			Session.Add("tc", Request.QueryString["tc"]);
			Session.Add("mc", Request.QueryString["mc"]);
			
			string link = "/SME/Scoring/ListScoring.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"];
			Response.Write("<form name='Form2' action='"+link+"' target='main'");
			Response.Write("");
			Response.Write("</form>");
			Response.Write("<script language='javascript'>alert('Track Update Successful!');</script>");
			Response.Write("<script language='JavaScript'>document.Form2.submit();</script>");			
			
			//Server.Transfer("ListScoring.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);				
			Server.Transfer("ListScoring.aspx");						
		}

	}
}
