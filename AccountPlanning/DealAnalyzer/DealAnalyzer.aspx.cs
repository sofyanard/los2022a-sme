using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;

namespace SME.AccountPlanning.DealAnalyzer
{
	/// <summary>
	/// Summary description for DealAnalyzer.
	/// </summary>
	public partial class DealAnalyzer : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				ViewData();
				ViewInfo();
				ViewScenario();
				FillDDLProduct();
				FillCurrency();
				FillGridScenario();
				FillBillType();
				FillTradeCover();
			}
		}

		private void ViewData()
		{
			TBL_PAGE.Visible		= false;
			TR_CASA.Visible			= false;
			TR_LOAN.Visible			= false;
			TR_BILLPAYMENT.Visible	= false;
			TR_TRADE.Visible		= false;
			TR_IBAM.Visible			= false;
			TR_PAYMENT.Visible		= false;
			TR_FUNDING.Visible		= false;
		}

		private void ViewInfo()
		{
			conn.QueryString = "SELECT * FROM VW_AP_CUSTOMER_LIST_TEMP WHERE CIF#='" + Request.QueryString["cif"] + "'";
			conn.ExecuteQuery();

			TXT_CIF.Text			= conn.GetFieldValue("CIF#");
			TXT_CUST_NAME.Text		= conn.GetFieldValue("CUSTOMER_NAME");
			TXT_ADDRESS.Text		= conn.GetFieldValue("CUST_ADDRESS");
			TXT_KOTA.Text			= conn.GetFieldValue("CUST_CITY");
			TXT_GROUP_NAME.Text		= conn.GetFieldValue("CUSTOMER_GROUP");
			TXT_CUST_DATE.Text		= tools.FormatDate(conn.GetFieldValue("CUST_DATE").ToString());
			TXT_RM.Text				= conn.GetFieldValue("RM_NAME");
			TXT_RM_GROUP_NAME.Text	= conn.GetFieldValue("GROUP_NAME");
			TXT_RM_UNIT_NAME.Text	= conn.GetFieldValue("BRANCH_NAME");
			TXT_RELATIONSHIP.Text	= conn.GetFieldValue("CUST_LENGTH");
		}

		private void ViewScenario()
		{
			conn.QueryString = "SELECT * FROM AP_SCENARIO WHERE CIF = '" + Request.QueryString["cif"] + "'";
			BindData(DGR_SCENARIO.ID.ToString(), conn.QueryString);
		}

		private void FillBillType()
		{
			DDL_TYPE_BP.Items.Clear();
			DDL_TYPE_BP.Items.Add(new ListItem("--Select--", ""));
			DDL_TYPE_BP.Items.Add(new ListItem("Host to Host", "1"));
			DDL_TYPE_BP.Items.Add(new ListItem("Non Host to Host", "2"));
		}

		private void FillTradeCover()
		{
			DDL_TYPE_TRADE.Items.Clear();
			DDL_TYPE_TRADE.Items.Add(new ListItem("--Select--", ""));
			DDL_TYPE_TRADE.Items.Add(new ListItem("Blokir", "1"));
			DDL_TYPE_TRADE.Items.Add(new ListItem("Giro Jaminan", "2"));
			DDL_TYPE_TRADE.Items.Add(new ListItem("Fasilitas", "3"));
		}

		private void FillDDLProduct()
		{
			DDL_PRODUCT.Items.Clear();
			DDL_PRODUCT.Items.Add(new ListItem("--Select--", ""));

			//conn.QueryString = "SELECT PRODUCTID, PRODUCT_NM FROM VW_AP_PRODUCT_NAME ORDER BY CONVERT(INT, PRODUCTID)";
			conn.QueryString = "SELECT * FROM VW_AP_PRODUCT_DEAL_ANALYZER ORDER BY PRODUCTDESC";
			conn.ExecuteQuery();
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_PRODUCT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void SetDefault()
		{
			ViewData();

			//CASA
			TXT_VOLUME_CASA.CssClass			= "";		TXT_VOLUME_CASA.Enabled			= false;
			TXT_EXCHANGE_CASA.CssClass			= "";		TXT_EXCHANGE_CASA.Enabled		= false;
			TXT_SUPPLIER_CASA.CssClass			= "";		TXT_SUPPLIER_CASA.Enabled		= false;
			TXT_ADMINISTRATION_CASA.CssClass	= "";		TXT_ADMINISTRATION_CASA.Enabled	= false;
			TXT_FTP_GWM_CASA.CssClass			= "";		TXT_FTP_GWM_CASA.Enabled		= false;
			TXT_FTP_INCOME_CASA.CssClass		= "";		TXT_FTP_INCOME_CASA.Enabled		= false;
			TXT_GWM_CASA.CssClass				= "";		TXT_GWM_CASA.Enabled			= false;
			TXT_INTEREST_RATE_CASA.CssClass		= "";		TXT_INTEREST_RATE_CASA.Enabled	= false;
			TXT_LPS_CASA.CssClass				= "";		TXT_LPS_CASA.Enabled			= false;

			//LOAN
			TXT_VOLUME_LOAN.CssClass			= "";		TXT_VOLUME_LOAN.Enabled			= false;
			TXT_EXCHANGE_LOAN.CssClass			= "";		TXT_EXCHANGE_LOAN.Enabled		= false;
			TXT_AVERAGE_AR_SUBS.CssClass		= "";		TXT_AVERAGE_AR_SUBS.Enabled		= false;
			TXT_AVERAGE_TRANSACTION_LOAN.CssClass= "";		TXT_AVERAGE_TRANSACTION_LOAN.Enabled= false;
			TXT_NO_MORTGAGE_LOAN.CssClass		= "";		TXT_NO_MORTGAGE_LOAN.Enabled	= false;
			TXT_NO_CARD_LOAN.CssClass			= "";		TXT_NO_CARD_LOAN.Enabled		= false;
			TXT_NO_LOAN.CssClass				= "";		TXT_NO_LOAN.Enabled				= false;
			TXT_NO_EMPLOYEE_LOAN.CssClass		= "";		TXT_NO_EMPLOYEE_LOAN.Enabled	= false;
			TXT_CKPN_LOAN.CssClass				= "";		TXT_CKPN_LOAN.Enabled			= false;
			TXT_FTP_COST_LOAN.CssClass			= "";		TXT_FTP_COST_LOAN.Enabled		= false;
			TXT_INTEREST_RATE_LOAN.CssClass		= "";		TXT_INTEREST_RATE_LOAN.Enabled	= false;
			TXT_PENALTY_FEE_LOAN.CssClass		= "";		TXT_PENALTY_FEE_LOAN.Enabled	= false;
			TXT_PROVISI_KOMISI_LOAN.CssClass	= "";		TXT_PROVISI_KOMISI_LOAN.Enabled	= false;
			TXT_SYNDICATION_FEE_LOAN.CssClass	= "";		TXT_SYNDICATION_FEE_LOAN.Enabled= false;
			TXT_COMMISSION_FEE_LOAN.CssClass	= "";		TXT_COMMISSION_FEE_LOAN.Enabled	= false;
			TXT_FTP_CKPN_LOAN.CssClass			= "";		TXT_FTP_CKPN_LOAN.Enabled		= false;
			TXT_REFERRAL_FEE_LOAN.CssClass		= "";		TXT_REFERRAL_FEE_LOAN.Enabled	= false;
			TXT_ANNUAL_FEE_LOAN.CssClass		= "";		TXT_ANNUAL_FEE_LOAN.Enabled		= false;

			//BILL PAYMENT
			TXT_TRANSACTION_BP.CssClass			= "";		TXT_TRANSACTION_BP.Enabled		= false;
			TXT_EXCHANGE_BP.CssClass			= "";		TXT_EXCHANGE_BP.Enabled			= false;
			DDL_TYPE_BP.CssClass				= "";		DDL_TYPE_BP.Enabled				= false;
			TXT_MONTHLY_TXN_BP.CssClass			= "";		TXT_MONTHLY_TXN_BP.Enabled		= false;
			TXT_H2HDEV_BP.CssClass				= "";		TXT_H2HDEV_BP.Enabled			= false;
			TXT_ITCOST_BP.CssClass				= "";		TXT_ITCOST_BP.Enabled			= false;
			TXT_JOINING_BP.CssClass				= "";		TXT_JOINING_BP.Enabled			= false;
			TXT_NONH2HDEV_BP.CssClass			= "";		TXT_NONH2HDEV_BP.Enabled		= false;
			TXT_TRANSACTION_FEE_BP.CssClass		= "";		TXT_TRANSACTION_FEE_BP.Enabled	= false;

			//TRADE
			TXT_VOLUME_TRADE.CssClass			= "";		TXT_VOLUME_TRADE.Enabled		= false;
			TXT_AVERAGE_AR_TRADE.CssClass		= "";		TXT_AVERAGE_AR_TRADE.Enabled	= false;
			TXT_EXCHANGE_TRADE.CssClass			= "";		TXT_EXCHANGE_TRADE.Enabled		= false;
			DDL_TYPE_TRADE.CssClass				= "";		DDL_TYPE_TRADE.Enabled			= false;
			TXT_PERIOD_TRADE.CssClass			= "";		TXT_PERIOD_TRADE.Enabled		= false;
			TXT_TOTAL_VOLUME_TRADE.CssClass		= "";		TXT_TOTAL_VOLUME_TRADE.Enabled	= false;
			TXT_SUPPLIER_TRADE.CssClass			= "";		TXT_SUPPLIER_TRADE.Enabled		= false;
			TXT_CKPN_TRADE.CssClass				= "";		TXT_CKPN_TRADE.Enabled			= false;
			TXT_FTP_CKPN_TRADE.CssClass			= "";		TXT_FTP_CKPN_TRADE.Enabled		= false;
			TXT_INTEREST_TRADE.CssClass			= "";		TXT_INTEREST_TRADE.Enabled		= false;
			TXT_PROVISI_BLOKIR_TRADE.CssClass	= "";		TXT_PROVISI_BLOKIR_TRADE.Enabled= false;
			TXT_PROVISI_FASILITAS_TRADE.CssClass= "";		TXT_PROVISI_FASILITAS_TRADE.Enabled= false;
			TXT_PROVISI_GIRO_TRADE.CssClass		= "";		TXT_PROVISI_GIRO_TRADE.Enabled	= false;
			TXT_PROVISION_TRADE.CssClass		= "";		TXT_PROVISION_TRADE.Enabled		= false;
			TXT_SWIFT_TRADE.CssClass			= "";		TXT_SWIFT_TRADE.Enabled			= false;
			TXT_UNIT_COST_TRADE.CssClass		= "";		TXT_UNIT_COST_TRADE.Enabled		= false;
			TXT_DIRECT_IT_TRADE.CssClass		= "";		TXT_DIRECT_IT_TRADE.Enabled		= false;
			TXT_FTP_COST_TRADE.CssClass			= "";		TXT_FTP_COST_TRADE.Enabled		= false;

			//IBAM
			TXT_AVE_VOLUME_IBAM.CssClass		= "";		TXT_AVE_VOLUME_IBAM.Enabled		= false;
			TXT_TOTAL_VOLUME_IBAM.CssClass		= "";		TXT_TOTAL_VOLUME_IBAM.Enabled	= false;
			TXT_EXCHANGE_IBAM.CssClass			= "";		TXT_EXCHANGE_IBAM.Enabled		= false;
			TXT_REFERRAL_IBAM.CssClass			= "";		TXT_REFERRAL_IBAM.Enabled		= false;
			TXT_OTHER_COST_IBAM.CssClass		= "";		TXT_OTHER_COST_IBAM.Enabled		= false;
			TXT_SERVICE_FEE_IBAM.CssClass		= "";		TXT_SERVICE_FEE_IBAM.Enabled	= false;
			TXT_SPREAD_IBAM.CssClass			= "";		TXT_SPREAD_IBAM.Enabled			= false;
			TXT_REFERRAL_FEE_IBAM.CssClass		= "";		TXT_REFERRAL_FEE_IBAM.Enabled	= false;

			//PAYMENT
			TXT_AVERAGE_PAYMENT.CssClass		= "";		TXT_AVERAGE_PAYMENT.Enabled		= false;
			TXT_EXCHANGE_PAYMENT.CssClass		= "";		TXT_EXCHANGE_PAYMENT.Enabled	= false;
			TXT_TRANSACTION_PAYMENT.CssClass	= "";		TXT_TRANSACTION_PAYMENT.Enabled	= false;
			TXT_INTEREST_PAYMENT.CssClass		= "";		TXT_INTEREST_PAYMENT.Enabled	= false;
			TXT_PROVISION_PAYMENT.CssClass		= "";		TXT_PROVISION_PAYMENT.Enabled	= false;
			TXT_CORRESPONDENT_COST_PAYMENT.CssClass= "";	TXT_CORRESPONDENT_COST_PAYMENT.Enabled= false;
			TXT_CORRESPONDENT_FEE_PAYMENT.CssClass= "";		TXT_CORRESPONDENT_FEE_PAYMENT.Enabled= false;
			TXT_BI_PAYMENT.CssClass				= "";		TXT_BI_PAYMENT.Enabled			= false;
			TXT_CABLE_COST_PAYMENT.CssClass		= "";		TXT_CABLE_COST_PAYMENT.Enabled	= false;
			TXT_CABLE_FEE_PAYMENT.CssClass		= "";		TXT_CABLE_FEE_PAYMENT.Enabled	= false;
			TXT_FIXED_FEE_PAYMENT.CssClass		= "";		TXT_FIXED_FEE_PAYMENT.Enabled	= false;
			TXT_INDIRECT_PAYMENT.CssClass		= "";		TXT_INDIRECT_PAYMENT.Enabled	= false;
			TXT_IT_COST_PAYMENT.CssClass		= "";		TXT_IT_COST_PAYMENT.Enabled		= false;
			TXT_MINIMUM_PROVISION_PAYMENT.CssClass= "";		TXT_MINIMUM_PROVISION_PAYMENT.Enabled= false;
			TXT_MAXIMUM_PROVISION_PAYMENT.CssClass= "";		TXT_MAXIMUM_PROVISION_PAYMENT.Enabled= false;

			//FUNDING
			TXT_PAYROLL_FUNDING.CssClass		= "";		TXT_PAYROLL_FUNDING.Enabled		= false;
			TXT_PICKUP_FUNDING.CssClass			= "";		TXT_PICKUP_FUNDING.Enabled		= false;
			TXT_TRANSACTION_FUNDING.CssClass	= "";		TXT_TRANSACTION_FUNDING.Enabled	= false;
			TXT_RATE_FUNDING.CssClass			= "";		TXT_RATE_FUNDING.Enabled		= false;
			TXT_PROCESSING_FEE_FUNDING.CssClass	= "";		TXT_PROCESSING_FEE_FUNDING.Enabled= false;
			TXT_SERVICE_COST_FUNDING.CssClass	= "";		TXT_SERVICE_COST_FUNDING.Enabled= false;
			TXT_CASHIN_SHIFT_FUNDING.CssClass	= "";		TXT_CASHIN_SHIFT_FUNDING.Enabled= false;
			TXT_CASHIN_TRANSIT_FUNDING.CssClass	= "";		TXT_CASHIN_TRANSIT_FUNDING.Enabled= false;
			TXT_COLLECTION_FUNDING.CssClass		= "";		TXT_COLLECTION_FUNDING.Enabled	= false;
			TXT_FEE_FUNDING.CssClass			= "";		TXT_FEE_FUNDING.Enabled			= false;
			TXT_IT_COST_FUNDING.CssClass		= "";		TXT_IT_COST_FUNDING.Enabled		= false;
			TXT_MINIMUM_FEE_FUNDING.CssClass	= "";		TXT_MINIMUM_FEE_FUNDING.Enabled	= false;
		}

		protected void DDL_PRODUCT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ClearData();
			ViewPage();
			ViewProductData();

			TXT_PRODUCT_BP.Text			= DDL_PRODUCT.SelectedItem.ToString();
			TXT_PRODUCT_CASA.Text		= DDL_PRODUCT.SelectedItem.ToString();
			TXT_PRODUCT_FUNDING.Text	= DDL_PRODUCT.SelectedItem.ToString();
			TXT_PRODUCT_IBAM.Text		= DDL_PRODUCT.SelectedItem.ToString();
			TXT_PRODUCT_LOAN.Text		= DDL_PRODUCT.SelectedItem.ToString();
			TXT_PRODUCT_PAYMENT.Text	= DDL_PRODUCT.SelectedItem.ToString();
			TXT_PRODUCT_TRADE.Text		= DDL_PRODUCT.SelectedItem.ToString();

			FillGridScenario();
		}

		private void ViewPage()
		{
			SetDefault();
			
			//conn.QueryString = "SELECT DISTINCT ID_AP_TEMPLATE_DEAL_ANALYZER, ID_AP_VARIABLE FROM AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL WHERE ID_AP_VARIABLE = '" + DDL_PRODUCT.SelectedValue + "'";
			conn.QueryString = "SELECT ID_TEMPLATE FROM VW_AP_TEMPLATE_DEAL_ANALYZER WHERE PRODUCTID = '" + DDL_PRODUCT.SelectedValue + "'";
			conn.ExecuteQuery();
			
			string id_template = conn.GetFieldValue("ID_TEMPLATE").ToString();
			
			switch(id_template)
			{
				case "1":
					ViewData();
					TBL_PAGE.Visible				= true;
					TR_CASA.Visible					= true;
					break;
					
				case "2":
					ViewData();
					TBL_PAGE.Visible				= true;
					TR_LOAN.Visible					= true;
					break;
					
				case "3":
					ViewData();
					TBL_PAGE.Visible				= true;
					TR_BILLPAYMENT.Visible			= true;
					DDL_TYPE_BP.SelectedValue		= "";
					break;
					
				case "4":
					ViewData();
					TBL_PAGE.Visible				= true;
					TR_TRADE.Visible				= true;
					DDL_TYPE_TRADE.SelectedValue	= "";
					break;
					
				case "5":
					ViewData();
					TBL_PAGE.Visible				= true;
					TR_IBAM.Visible					= true;
					break;
					
				case "6":
					ViewData();
					TBL_PAGE.Visible				= true;
					TR_PAYMENT.Visible				= true;
					break;
					
				case "7":
					ViewData();
					TBL_PAGE.Visible				= true;
					TR_FUNDING.Visible				= true;
					break;
			}

			//Check Field Mandatory
			//conn.QueryString = "SELECT FIELD, TYPE, ENABLE FROM AP_FIELD_DEAL_ANALYZER WHERE ID_FIELD = '" + DDL_PRODUCT.SelectedValue + "' AND ID_TEMPLATE = '" + id_template + "'";
			conn.QueryString = "SELECT FIELD, TYPE, ENABLE FROM VW_AP_FIELD_DEAL_ANALYZER WHERE PRODUCTID = '" + DDL_PRODUCT.SelectedValue + "' ORDER BY SEQ";
			conn.ExecuteQuery();
					
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				string field	= conn.GetFieldValue(i,0).ToString();
				string type		= conn.GetFieldValue(i,1).ToString();
				string enable	= conn.GetFieldValue(i,2).ToString();
						
				if(type == "T")	//Text
				{
					TextBox t_field = (TextBox)this.FindControl(field);
					if(enable == "1")
					{
						t_field.CssClass = "Mandatory";
						t_field.Enabled = true;
					}
				}
				else if(type == "D")	//Dropdownlist
				{
					DropDownList d_field = (DropDownList)this.FindControl(field);
					if(enable == "1")
					{
						d_field.CssClass = "Mandatory";
						d_field.Enabled = true;
					}
				}
				else if(type == "R")	//Dropdownlist
				{
					RadioButton r_field = (RadioButton)this.FindControl(field);
					//r_field.CssClass = "Mandatory";
					if(enable == "1")
					{
						r_field.Enabled = true;
					}
				}
			}
		}

		private void FillCurrency()
		{
			DDL_CURRENCY.Items.Clear();
			DDL_CURRENCY.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM RFCURRENCY WHERE ACTIVE = '1' ORDER BY CURRENCYID";
			conn.ExecuteQuery();
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_CURRENCY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		protected void DDL_CURRENCY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "SELECT CURRENCYRATE FROM RFCURRENCY WHERE CURRENCYID = '"+ DDL_CURRENCY.SelectedValue +"' AND ACTIVE='1'";
			conn.ExecuteQuery();

			TXT_EXCHANGE_LOAN.Text		= conn.GetFieldValue("CURRENCYRATE").ToString();
			TXT_EXCHANGE_CASA.Text		= conn.GetFieldValue("CURRENCYRATE").ToString();
			TXT_EXCHANGE_BP.Text		= conn.GetFieldValue("CURRENCYRATE").ToString();
			TXT_EXCHANGE_TRADE.Text		= conn.GetFieldValue("CURRENCYRATE").ToString();
			TXT_EXCHANGE_IBAM.Text		= conn.GetFieldValue("CURRENCYRATE").ToString();
			TXT_EXCHANGE_PAYMENT.Text	= conn.GetFieldValue("CURRENCYRATE").ToString();

			ViewProductData();
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();

				System.Data.DataTable dt = new System.Data.DataTable();
				dt = conn.GetDataTable().Copy();

				System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);
				dg.DataSource = dt;

				try
				{
					dg.DataBind();
				}
				catch
				{
					dg.CurrentPageIndex = dg.PageCount - 1;
					dg.DataBind();
				}

				conn.ClearData();
			}
		}

		private void ViewProductData()
		{
			string FTP_INCOME			= "";
			string FTP_CKPN				= "";
			string FTP_COST				= "";
			string PROVISI				= "";

			//conn.QueryString = "SELECT * FROM AP_VARIABLE WHERE ID_AP_VARIABLE = '"+ DDL_PRODUCT.SelectedValue +"' AND STATUS = '1'";
			conn.QueryString = "SELECT * FROM VW_AP_DATA_DEAL_ANALYZER WHERE ID_PRODUCT = '" + DDL_PRODUCT.SelectedValue + "'";
			conn.ExecuteQuery();

			if(DDL_CURRENCY.SelectedValue == "IDR" || DDL_CURRENCY.SelectedValue == "")
			{
				FTP_INCOME			= conn.GetFieldValue("FTP_INCOME_PERCENT").ToString();
				FTP_CKPN				= conn.GetFieldValue("FTP_CKPN_PERCENT").ToString();
				FTP_COST				= conn.GetFieldValue("FTP_COST_PERCENT").ToString();
				PROVISI				= conn.GetFieldValue("PROVISION_PERCENT").ToString();
			}

			else
			{
				FTP_INCOME			= conn.GetFieldValue("FTP_INCOME_PERCENT_VALAS").ToString();
				FTP_CKPN				= conn.GetFieldValue("FTP_CKPN_PERCENT_VALAS").ToString();
				FTP_COST				= conn.GetFieldValue("FTP_COST_PERCENT_VALAS").ToString();
				PROVISI				= conn.GetFieldValue("PROVISION_PERCENT_VALAS").ToString();
			}

			//CASA
			TXT_ADMINISTRATION_CASA.Text	= conn.GetFieldValue("ADMIN_FEE_PERCENT");
			TXT_FTP_GWM_CASA.Text			= conn.GetFieldValue("FTP_GWM_PERCENT");
			//TXT_FTP_INCOME_CASA.Text		= conn.GetFieldValue("FTP_INCOME_PERCENT");
			TXT_FTP_INCOME_CASA.Text		= FTP_INCOME;
			TXT_GWM_CASA.Text				= conn.GetFieldValue("GWM_PERCENT");
			TXT_INTEREST_RATE_CASA.Text		= conn.GetFieldValue("INTEREST_RATE_PERCENT");
			TXT_LPS_CASA.Text				= conn.GetFieldValue("PREMIUM_FOR_LPS_PERCENT");

			//LOAN
			TXT_CKPN_LOAN.Text				= conn.GetFieldValue("CKPN_PERCENT");
			//TXT_FTP_COST_LOAN.Text		= conn.GetFieldValue("FTP_COST_PERCENT");
			TXT_FTP_COST_LOAN.Text			= FTP_COST;
			TXT_INTEREST_RATE_LOAN.Text		= conn.GetFieldValue("INTEREST_RATE_PERCENT");
			TXT_PENALTY_FEE_LOAN.Text		= conn.GetFieldValue("PENALTY_FEE_PERCENT");
			//TXT_PROVISI_KOMISI_LOAN.Text	= conn.GetFieldValue("PROVISION_PERCENT");
			TXT_PROVISI_KOMISI_LOAN.Text	= PROVISI;
			TXT_SYNDICATION_FEE_LOAN.Text	= conn.GetFieldValue("SYNDICATION_FEE_PERCENT");
			TXT_COMMISSION_FEE_LOAN.Text	= conn.GetFieldValue("COMMITMENT_FEE");
			//TXT_FTP_CKPN_LOAN.Text		= conn.GetFieldValue("FTP_CKPN_PERCENT");
			TXT_FTP_CKPN_LOAN.Text			= FTP_CKPN;
			TXT_REFERRAL_FEE_LOAN.Text		= conn.GetFieldValue("REFERRAL_FEE_INCOME_PERCENT");
			TXT_ANNUAL_FEE_LOAN.Text		= conn.GetFieldValue("ANNUAL_FEE");

			//BILL PAYMENT
			TXT_H2HDEV_BP.Text				= conn.GetFieldValue("H2HDEVELOPMENT_FEE_USD");
			TXT_ITCOST_BP.Text				= conn.GetFieldValue("IT_COST_TRANSACTION");
			TXT_JOINING_BP.Text				= conn.GetFieldValue("JOINING_FEE");
			TXT_NONH2HDEV_BP.Text			= conn.GetFieldValue("NON_H2H_DEV_FEE");
			TXT_TRANSACTION_FEE_BP.Text		= conn.GetFieldValue("TRANSACTION_FEE");

			//TRADE
			TXT_CKPN_TRADE.Text				= conn.GetFieldValue("CKPN_PERCENT");
			//TXT_FTP_CKPN_TRADE.Text		= conn.GetFieldValue("FTP_CKPN_PERCENT");
			TXT_FTP_CKPN_TRADE.Text			= FTP_CKPN;
			TXT_INTEREST_TRADE.Text			= conn.GetFieldValue("INTEREST_RATE_PERCENT");
			TXT_PROVISI_BLOKIR_TRADE.Text	= conn.GetFieldValue("PROVISI_BLOKIR_PERQUARTAL_PERCENT");
			TXT_PROVISI_FASILITAS_TRADE.Text= conn.GetFieldValue("PROVISI_FASILITAS_QUARTAL_PERCENT");
			TXT_PROVISI_GIRO_TRADE.Text		= conn.GetFieldValue("PROVISI_GIRO_JAMINAN_USD");
			//TXT_PROVISION_TRADE.Text		= conn.GetFieldValue("PROVISION_PERCENT");
			TXT_PROVISION_TRADE.Text		= PROVISI;
			TXT_SWIFT_TRADE.Text			= conn.GetFieldValue("SWIFT_FEE_PERCENT");
			TXT_UNIT_COST_TRADE.Text		= conn.GetFieldValue("UNIT_COST_PER_MILLION_UNIT");
			TXT_DIRECT_IT_TRADE.Text		= conn.GetFieldValue("DIRECT_IT_COST_PER_MILLION_UNIT");
			TXT_FTP_COST_TRADE.Text			= conn.GetFieldValue("FTP_COST_PERCENT");
			TXT_FTP_COST_TRADE.Text			= FTP_COST;

			//IBAM
			TXT_OTHER_COST_IBAM.Text		= conn.GetFieldValue("OTHER_COST_PERCENT");
			TXT_SERVICE_FEE_IBAM.Text		= conn.GetFieldValue("SERVICE_FEE_PERCENT");
			TXT_SPREAD_IBAM.Text			= conn.GetFieldValue("SPREAD_PERCENT");
			TXT_REFERRAL_FEE_IBAM.Text		= conn.GetFieldValue("REFERRAL_FEE_INCOME_PERCENT");

			//PAYMENT
			TXT_INTEREST_PAYMENT.Text			= conn.GetFieldValue("INTEREST_RATE_PERCENT");
			//TXT_PROVISION_PAYMENT.Text		= conn.GetFieldValue("PROVISION_PERCENT");
			TXT_PROVISION_PAYMENT.Text			= PROVISI;
			TXT_CORRESPONDENT_COST_PAYMENT.Text	= conn.GetFieldValue("CORRESPONDENT_COST_USD");
			TXT_CORRESPONDENT_FEE_PAYMENT.Text	= conn.GetFieldValue("CORRESPONDENT_FEE_USD");
			TXT_BI_PAYMENT.Text					= conn.GetFieldValue("BI_COST");
			TXT_CABLE_COST_PAYMENT.Text			= conn.GetFieldValue("CABLE_COST_USD");
			TXT_CABLE_FEE_PAYMENT.Text			= conn.GetFieldValue("CABLE_FEE_USD");
			TXT_FIXED_FEE_PAYMENT.Text			= conn.GetFieldValue("FIXED_FEE");
			TXT_INDIRECT_PAYMENT.Text			= conn.GetFieldValue("INDIRECT_COST_TRANSACTION");
			TXT_IT_COST_PAYMENT.Text			= conn.GetFieldValue("IT_COST_TRANSACTION");
			TXT_MINIMUM_PROVISION_PAYMENT.Text	= conn.GetFieldValue("MINIMUM_PROVISION_USD");
			TXT_MAXIMUM_PROVISION_PAYMENT.Text	= conn.GetFieldValue("MAXIMUM_PROVISION_USD");

			//FUNDING
			TXT_PROCESSING_FEE_FUNDING.Text		= conn.GetFieldValue("CASH_PROCESSING_FEE_DAY");
			TXT_SERVICE_COST_FUNDING.Text		= conn.GetFieldValue("SERVICE_COST");
			TXT_CASHIN_SHIFT_FUNDING.Text		= conn.GetFieldValue("CASH_IN_SHIFT_DAY");
			TXT_CASHIN_TRANSIT_FUNDING.Text		= conn.GetFieldValue("CASH_IN_TRANSIT_COST_DAY");
			TXT_COLLECTION_FUNDING.Text			= conn.GetFieldValue("COLLECTION_FEE_DAY");
			TXT_FEE_FUNDING.Text				= conn.GetFieldValue("FEE_TRANSACTION");
			TXT_IT_COST_FUNDING.Text			= conn.GetFieldValue("IT_COST_TRANSACTION");
			TXT_MINIMUM_FEE_FUNDING.Text		= conn.GetFieldValue("MINIMUM_FEE_PER_PROCESS");
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
			this.DGR_SCENARIO.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_SCENARIO_ItemCommand);
			this.DGR_SCENARIO.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_SCENARIO_PageIndexChanged);
			this.DGR_SAVE_SCENARIO.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_SAVE_SCENARIO_ItemCommand);
			this.DGR_SAVE_SCENARIO.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_SAVE_SCENARIO_PageIndexChanged);

		}
		#endregion

		protected void BTN_ADD_SCENARIO_Click(object sender, System.EventArgs e)
		{
			if(TXT_SCENARIO.Text != "" || TXT_SCENARIO.Text != null)
			{
				conn.QueryString = "SELECT ISNULL(MAX(CONVERT(INT, SCENARIO#)),0)+1 AS SCENARIO# FROM AP_SCENARIO WHERE CIF='" + Request.QueryString["cif"] + "'";
				conn.ExecuteQuery();
				LBL_NOSCENARIO.Text =  conn.GetFieldValue("SCENARIO#").ToString();

				conn.QueryString = "EXEC AP_SCENARIO_ADD '" + Request.QueryString["cif"] + "','"+ LBL_NOSCENARIO.Text +"','" + TXT_SCENARIO.Text + "','1'";
				conn.ExecuteQuery();
			}
			else
			{
				GlobalTools.popMessage(this, "Check Field Scenario");
				return;
			}

			TBL_PAGE.Visible = false;
			ViewScenario();
			CekCode();
			ClearData();
			DDL_PRODUCT.SelectedValue = "";
			DDL_CURRENCY.SelectedValue = "";
			FillGridScenario();
		}

		private void DGR_SCENARIO_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_SCENARIO.CurrentPageIndex = e.NewPageIndex;
			ViewScenario();
		}

		private void DGR_SCENARIO_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "EXEC AP_SCENARIO_ADD '" + e.Item.Cells[0].Text.Trim() + "','"+ e.Item.Cells[1].Text.Trim() +"','" + e.Item.Cells[2].Text.Trim()  + "','0'";
					conn.ExecuteQuery();

					conn.QueryString = "DELETE FROM AP_DEAL_ANALYZER WHERE CIF#='" + e.Item.Cells[0].Text.Trim() + "' AND SCENARIO#='" + e.Item.Cells[1].Text.Trim() + "'";
					conn.ExecuteQuery();

					ViewScenario();
					FillGridScenario();
					TXT_SCENARIO.Text = "";
					LBL_NOSCENARIO.Text = "";
					TBL_PAGE.Visible = false;
					break;

				case "view":
					TBL_PAGE.Visible = false;
					conn.QueryString = "SELECT * FROM AP_SCENARIO WHERE CIF = '" + e.Item.Cells[0].Text.Trim() + "' AND SCENARIO# = '" + e.Item.Cells[1].Text.Trim() + "'";
					conn.ExecuteQuery();

					TXT_SCENARIO.Text = conn.GetFieldValue("SCENARIO_DESC");
					LBL_NOSCENARIO.Text = conn.GetFieldValue("SCENARIO#");
					CekCode();
					ClearData();
					TBL_PAGE.Visible = false;
					DDL_PRODUCT.SelectedValue = "";
					DDL_CURRENCY.SelectedValue = "";
					FillGridScenario();
					
					//Print View
					Response.Write("<script language='javascript'>window.open('ScenarioPrint.aspx?mc=" + Request.QueryString["mc"] + "&cif=" + e.Item.Cells[0].Text.Trim() + "&sc=" + e.Item.Cells[1].Text.Trim() + "','PrintScenarioRequest');</script>");
					break;
			}
		}

		private void CekCode()
		{
			conn.QueryString = "SELECT ISNULL(MAX(CONVERT(INT, SEQ_SCENARIO)),0)+1 AS SEQ_SCENARIO FROM AP_DEAL_ANALYZER WHERE CIF#='" + Request.QueryString["cif"] + "' AND SCENARIO#='" + LBL_NOSCENARIO.Text + "'";
			conn.ExecuteQuery();
			LBL_SCENARIO_SEQ_ID.Text =  conn.GetFieldValue("SEQ_SCENARIO").ToString();
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			if(LBL_NOSCENARIO.Text != "")
			{
				string query = "";

				conn.QueryString = "SELECT ID_TEMPLATE, QUERY FROM VW_AP_TEMPLATE_DEAL_ANALYZER WHERE PRODUCTID = '" + DDL_PRODUCT.SelectedValue + "'";
				conn.ExecuteQuery();
				
				string id_template	= conn.GetFieldValue("ID_TEMPLATE").ToString();
				string proc			= conn.GetFieldValue("QUERY").ToString();
				
				switch(id_template)
				{
					case "1":
						query = "EXEC " + proc + " '" +
							TXT_CIF.Text + "','" +
							LBL_NOSCENARIO.Text + "','" +
							LBL_SCENARIO_SEQ_ID.Text + "','" +
							DDL_PRODUCT.SelectedValue + "','" +
							DDL_CURRENCY.SelectedValue + "',";
						break;
					
					case "2":
						query = "EXEC " + proc + " '" +
							TXT_CIF.Text + "','" +
							LBL_NOSCENARIO.Text + "','" +
							LBL_SCENARIO_SEQ_ID.Text + "','" +
							DDL_PRODUCT.SelectedValue + "','" +
							DDL_CURRENCY.SelectedValue + "','" +
							RDO_AVERAGE_VOLUME.SelectedValue + "',";
						break;
					
					case "3":
						query = "EXEC " + proc + " '" +
							TXT_CIF.Text + "','" +
							LBL_NOSCENARIO.Text + "','" +
							LBL_SCENARIO_SEQ_ID.Text + "','" +
							DDL_PRODUCT.SelectedValue + "','" +
							DDL_CURRENCY.SelectedValue + "',";
						break;
					
					case "4":
						query = "EXEC " + proc + " '" +
							TXT_CIF.Text + "','" +
							LBL_NOSCENARIO.Text + "','" +
							LBL_SCENARIO_SEQ_ID.Text + "','" +
							DDL_PRODUCT.SelectedValue + "','" +
							DDL_CURRENCY.SelectedValue + "',";
						break;
					
					case "5":
						query = "EXEC " + proc + " '" +
							TXT_CIF.Text + "','" +
							LBL_NOSCENARIO.Text + "','" +
							LBL_SCENARIO_SEQ_ID.Text + "','" +
							DDL_PRODUCT.SelectedValue + "','" +
							DDL_CURRENCY.SelectedValue + "',";
						break;
					
					case "6":
						query = "EXEC " + proc + " '" +
							TXT_CIF.Text + "','" +
							LBL_NOSCENARIO.Text + "','" +
							LBL_SCENARIO_SEQ_ID.Text + "','" +
							DDL_PRODUCT.SelectedValue + "','" +
							DDL_CURRENCY.SelectedValue + "',";
						break;
					
					case "7":
						query = "EXEC " + proc + " '" +
							TXT_CIF.Text + "','" +
							LBL_NOSCENARIO.Text + "','" +
							LBL_SCENARIO_SEQ_ID.Text + "','" +
							DDL_PRODUCT.SelectedValue + "',";
						break;
				}

				/*Ambil Field dari database*/
				try
				{
					conn.QueryString = "SELECT FIELD, TYPE FROM VW_AP_FIELD_DEAL_ANALYZER WHERE ID_FIELD = '" + DDL_PRODUCT.SelectedValue + "' ORDER BY SEQ";
					conn.ExecuteQuery();
					
					for(int i = 0; i < conn.GetRowCount(); i++)
					{
						string field = conn.GetFieldValue(i,0).ToString();
						string type = conn.GetFieldValue(i,1).ToString();

						if(type == "T") //Text
						{
							TextBox t_field = (TextBox)this.FindControl(field);
							query = query + "'" + t_field.Text.Replace(",",".") + "'";
						}
						else if(type == "D") //Dropdownlist
						{
							DropDownList d_field = (DropDownList)this.FindControl(field);
							query = query + "'" + d_field.SelectedValue + "'";
						}
						else if(type == "R") //Radiobutton
						{
							RadioButton r_field = (RadioButton)this.FindControl(field);
							query = query + "'" + r_field.Checked + "'";
						}

						if(i < conn.GetRowCount() - 1)
						{
							query = query + ", ";
						}
					}

					conn.QueryString = query;
					conn.ExecuteQuery();
				}
				catch (Exception ex)
				{
					string errmsg = ex.Message.Replace("'","");
					if (errmsg.IndexOf("Last Query:") > 0)
						errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
					GlobalTools.popMessage(this, errmsg);
					return;
				}
				
				ClearData();
				CekCode();
				TBL_PAGE.Visible = false;
				DDL_PRODUCT.SelectedValue = "";
				DDL_CURRENCY.SelectedValue = "";
				FillGridScenario();
				ViewProductData();
			}
			else
			{
				GlobalTools.popMessage(this, "Invalid Scenario!");
				return;
			}
		}

		private void ClearData()
		{
			TXT_EXCHANGE_CASA.Text				= "";
			TXT_EXCHANGE_LOAN.Text				= "";
			TXT_EXCHANGE_BP.Text				= "";
			TXT_EXCHANGE_TRADE.Text				= "";
			TXT_EXCHANGE_IBAM.Text				= "";
			TXT_EXCHANGE_PAYMENT.Text			= "";
			//CASA
			TXT_VOLUME_CASA.Text				= "";		
			TXT_SUPPLIER_CASA.Text				= "";
			//LOAN
			RDO_AVERAGE_VOLUME.SelectedValue	= null;
			TXT_VOLUME_LOAN.Text				= "";
			TXT_AVERAGE_AR_SUBS.Text			= "";
			TXT_AVERAGE_TRANSACTION_LOAN.Text	= "";
			TXT_NO_MORTGAGE_LOAN.Text			= "";
			TXT_NO_CARD_LOAN.Text				= "";
			TXT_NO_LOAN.Text					= "";
			TXT_NO_EMPLOYEE_LOAN.Text			= "";
			//Bill Payment
			TXT_TRANSACTION_BP.Text				= "";
			DDL_TYPE_BP.SelectedValue			= "";
			TXT_MONTHLY_TXN_BP.Text				= "";
			//TRADE
			TXT_VOLUME_TRADE.Text				= "";
			TXT_AVERAGE_AR_TRADE.Text			= "";
			DDL_TYPE_TRADE.SelectedValue		= "";
			TXT_PERIOD_TRADE.Text				= "";
			TXT_TOTAL_VOLUME_TRADE.Text			= "";
			TXT_SUPPLIER_TRADE.Text				= "";
			//IBAM
			TXT_AVE_VOLUME_IBAM.Text			= "";
			TXT_TOTAL_VOLUME_IBAM.Text			= "";
			TXT_REFERRAL_IBAM.Text				= "";
			//PAYMENT
			TXT_AVERAGE_PAYMENT.Text			= "";
			TXT_TRANSACTION_PAYMENT.Text		= "";
			//FUNDING
			TXT_PAYROLL_FUNDING.Text			= "";
			TXT_PICKUP_FUNDING.Text				= "";
			TXT_TRANSACTION_FUNDING.Text		= "";
			TXT_RATE_FUNDING.Text				= "";
		}

		private void FillGridScenario()
		{
			conn.QueryString = "SELECT * FROM AP_DEAL_ANALYZER WHERE CIF# = '" + Request.QueryString["cif"] + "' AND SCENARIO#='" + LBL_NOSCENARIO.Text + "'";
			//BindData(DGR_SAVE_SCENARIO.ID.ToString(), conn.QueryString);
			conn.ExecuteQuery();
		
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_SAVE_SCENARIO.DataSource = dt;
			try 
			{
				DGR_SAVE_SCENARIO.DataBind();
			}
			catch 
			{
				DGR_SAVE_SCENARIO.CurrentPageIndex = 0;
				DGR_SAVE_SCENARIO.DataBind();
			}

			for (int i = 0; i < DGR_SAVE_SCENARIO.Items.Count; i++)
			{
				DGR_SAVE_SCENARIO.Items[i].Cells[5].Text = tools.MoneyFormat(DGR_SAVE_SCENARIO.Items[i].Cells[5].Text);
				DGR_SAVE_SCENARIO.Items[i].Cells[6].Text = tools.MoneyFormat(DGR_SAVE_SCENARIO.Items[i].Cells[6].Text);
				DGR_SAVE_SCENARIO.Items[i].Cells[7].Text = tools.MoneyFormat(DGR_SAVE_SCENARIO.Items[i].Cells[7].Text);
				DGR_SAVE_SCENARIO.Items[i].Cells[8].Text = tools.MoneyFormat(DGR_SAVE_SCENARIO.Items[i].Cells[8].Text);
			}
		}

		private void DGR_SAVE_SCENARIO_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_SAVE_SCENARIO.CurrentPageIndex = e.NewPageIndex;
			FillGridScenario();
		}

		private void DGR_SAVE_SCENARIO_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					TBL_PAGE.Visible = true;
					LBL_SCENARIO_SEQ_ID.Text	= e.Item.Cells[0].Text.Trim();
					LBL_NOSCENARIO.Text			= e.Item.Cells[1].Text.Trim();
					DDL_PRODUCT.SelectedValue	= e.Item.Cells[3].Text.Trim();
					
					conn.QueryString = "SELECT * FROM AP_SCENARIO WHERE CIF='" + e.Item.Cells[2].Text.Trim() + "' AND SCENARIO#='" + LBL_NOSCENARIO.Text + "'";
					conn.ExecuteQuery();

					TXT_SCENARIO.Text = conn.GetFieldValue("SCENARIO_DESC");

					ViewPage();
				
					conn.QueryString = "SELECT * FROM AP_DEAL_ANALYZER WHERE CIF#='" + e.Item.Cells[2].Text.Trim() + "' AND SEQ_SCENARIO = '" + e.Item.Cells[0].Text.Trim() + "' AND SCENARIO#='" + e.Item.Cells[1].Text.Trim() + "' AND PRODUCTID='" + e.Item.Cells[3].Text.Trim() + "'";
					conn.ExecuteQuery();
					
					DDL_CURRENCY.SelectedValue		= conn.GetFieldValue("CURRENCY").ToString();
					
					TXT_PRODUCT_CASA.Text			= conn.GetFieldValue("PRODUCT_NM").ToString();
					TXT_PRODUCT_LOAN.Text			= conn.GetFieldValue("PRODUCT_NM").ToString();
					TXT_PRODUCT_BP.Text				= conn.GetFieldValue("PRODUCT_NM").ToString();
					TXT_PRODUCT_TRADE.Text			= conn.GetFieldValue("PRODUCT_NM").ToString();
					TXT_PRODUCT_IBAM.Text			= conn.GetFieldValue("PRODUCT_NM").ToString();
					TXT_PRODUCT_PAYMENT.Text		= conn.GetFieldValue("PRODUCT_NM").ToString();
					TXT_PRODUCT_FUNDING.Text		= conn.GetFieldValue("PRODUCT_NM").ToString();
					TXT_EXCHANGE_CASA.Text			= conn.GetFieldValue("EXCHANGE").ToString().Replace("0.0","");
					TXT_EXCHANGE_LOAN.Text			= conn.GetFieldValue("EXCHANGE").ToString().Replace("0.0","");
					TXT_EXCHANGE_BP.Text			= conn.GetFieldValue("EXCHANGE").ToString().Replace("0.0","");
					TXT_EXCHANGE_TRADE.Text			= conn.GetFieldValue("EXCHANGE").ToString().Replace("0.0","");
					TXT_EXCHANGE_IBAM.Text			= conn.GetFieldValue("EXCHANGE").ToString().Replace("0.0","");
					TXT_EXCHANGE_PAYMENT.Text		= conn.GetFieldValue("EXCHANGE").ToString().Replace("0.0","");

					//CASA
					TXT_VOLUME_CASA.Text			= conn.GetFieldValue("CS_AVE_VOL_PER_YEAR").ToString().Replace("0.0","");
					TXT_SUPPLIER_CASA.Text			= conn.GetFieldValue("CS_NO_OF_SUPPLIER").ToString().Replace("0.0","");
					/******************************/
					TXT_ADMINISTRATION_CASA.Text	= conn.GetFieldValue("CS_ADMIN_FEE_PERCENT").ToString().Replace("0.0","");
					TXT_FTP_GWM_CASA.Text			= conn.GetFieldValue("CS_FTP_GWM_PERCENT").ToString().Replace("0.0","");
					TXT_FTP_INCOME_CASA.Text		= conn.GetFieldValue("CS_FTP_INCOME_PERCENT").ToString().Replace("0.0","");
					TXT_GWM_CASA.Text				= conn.GetFieldValue("CS_GWM_PERCENT").ToString().Replace("0.0","");
					TXT_INTEREST_RATE_CASA.Text		= conn.GetFieldValue("CS_INTEREST_RATE_PERCENT").ToString().Replace("0.0","");
					TXT_LPS_CASA.Text				= conn.GetFieldValue("CS_PREMIUM_LPS_PERCENT").ToString().Replace("0.0","");

					//LOAN
					if(conn.GetFieldValue("LN_AVE_VOL_ID") != "" && conn.GetFieldValue("LN_AVE_VOL_ID") != null)
					{
						RDO_AVERAGE_VOLUME.SelectedValue	= conn.GetFieldValue("LN_AVE_VOL_ID");
					}
					TXT_VOLUME_LOAN.Text				= conn.GetFieldValue("LN_AVE_VOL").ToString().Replace("0.0","");
					TXT_AVERAGE_AR_SUBS.Text			= conn.GetFieldValue("LN_AVE_AR_SUBS").ToString().Replace("0.0","");
					TXT_AVERAGE_TRANSACTION_LOAN.Text	= conn.GetFieldValue("LN_AVE_TX_PER_CARD").ToString().Replace("0.0","");
					TXT_NO_MORTGAGE_LOAN.Text			= conn.GetFieldValue("LN_NO_OF_MG").ToString().Replace("0.0","");
					TXT_NO_CARD_LOAN.Text				= conn.GetFieldValue("LN_NO_OF_CARD").ToString().Replace("0.0","");
					TXT_NO_LOAN.Text					= conn.GetFieldValue("LN_NO_OF_LOAN").ToString().Replace("0.0","");
					TXT_NO_EMPLOYEE_LOAN.Text			= conn.GetFieldValue("LN_NO_OF_EMPLOYEE").ToString().Replace("0.0","");
					/******************************/
					TXT_CKPN_LOAN.Text				= conn.GetFieldValue("LN_CKPN_PERCENT").ToString().Replace("0.0","");
					TXT_FTP_COST_LOAN.Text			= conn.GetFieldValue("LN_FTP_COST_PERCENT").ToString().Replace("0.0","");
					TXT_INTEREST_RATE_LOAN.Text		= conn.GetFieldValue("LN_INTEREST_RATE_PERCENT").ToString().Replace("0.0","");
					TXT_PENALTY_FEE_LOAN.Text		= conn.GetFieldValue("LN_PENALTY_FEE_PERCENT").ToString().Replace("0.0","");
					TXT_PROVISI_KOMISI_LOAN.Text	= conn.GetFieldValue("LN_PROVISI_PERCENT").ToString().Replace("0.0","");
					TXT_SYNDICATION_FEE_LOAN.Text	= conn.GetFieldValue("LN_SYNDICATION_FEE_PERCENT").ToString().Replace("0.0","");
					TXT_COMMISSION_FEE_LOAN.Text	= conn.GetFieldValue("LN_USAGE_COMM_FEE_PERCENT").ToString().Replace("0.0","");
					TXT_FTP_CKPN_LOAN.Text			= conn.GetFieldValue("LN_FTP_CKPN_PERCENT").ToString().Replace("0.0","");
					TXT_REFERRAL_FEE_LOAN.Text		= conn.GetFieldValue("LN_REFERRAL_FEE_PERCENT").ToString().Replace("0.0","");
					TXT_ANNUAL_FEE_LOAN.Text		= conn.GetFieldValue("LN_ANNUAL_FEE").ToString().Replace("0.0","");

					//Bill Payment
					TXT_TRANSACTION_BP.Text			= conn.GetFieldValue("BP_NO_TX_YEAR").ToString().Replace("0.0","");
					DDL_TYPE_BP.SelectedValue		= conn.GetFieldValue("BP_TYPE_ID").ToString();
					TXT_MONTHLY_TXN_BP.Text			= conn.GetFieldValue("BP_MONTH_MIN_TX").ToString().Replace("0.0","");
					/******************************/
					TXT_H2HDEV_BP.Text				= conn.GetFieldValue("BP_H2H_DEV_FEE").ToString().Replace("0.0","");
					TXT_ITCOST_BP.Text				= conn.GetFieldValue("BP_IT_COST_TX").ToString().Replace("0.0","");
					TXT_JOINING_BP.Text				= conn.GetFieldValue("BP_JOINING_FEE").ToString().Replace("0.0","");
					TXT_NONH2HDEV_BP.Text			= conn.GetFieldValue("BP_NH2H_DEV_FEE").ToString().Replace("0.0","");
					TXT_TRANSACTION_FEE_BP.Text		= conn.GetFieldValue("BP_TX_FEE").ToString().Replace("0.0","");

					//TRADE
					TXT_VOLUME_TRADE.Text			= conn.GetFieldValue("TR_AVE_PER_YEAR").ToString().Replace("0.0","");
					TXT_AVERAGE_AR_TRADE.Text		= conn.GetFieldValue("TR_AVE_AR_PER_SUBSI").ToString().Replace("0.0","");
					DDL_TYPE_TRADE.SelectedValue	= conn.GetFieldValue("TR_COVER_PER_TYPE_ID");
					TXT_PERIOD_TRADE.Text			= conn.GetFieldValue("TR_TIME_PERIOD").ToString().Replace("0.0","");
					TXT_TOTAL_VOLUME_TRADE.Text		= conn.GetFieldValue("TR_TOT_VOL_YEAR").ToString().Replace("0.0","");
					TXT_SUPPLIER_TRADE.Text			= conn.GetFieldValue("TR_NO_OF_SUPPLIER").ToString().Replace("0.0","");
					/******************************/
					TXT_CKPN_TRADE.Text				= conn.GetFieldValue("TR_CKPN_PERCENT").Replace("0.0","");
					TXT_FTP_CKPN_TRADE.Text			= conn.GetFieldValue("TR_FTP_CKPN_PERCENT").Replace("0.0","");
					TXT_INTEREST_TRADE.Text			= conn.GetFieldValue("TR_INTEREST_RATE_PERCENT").ToString().Replace("0.0","");
					TXT_PROVISI_BLOKIR_TRADE.Text	= conn.GetFieldValue("TR_PROV_BLOKIR_Q_PERCENT").ToString().Replace("0.0","");
					TXT_PROVISI_FASILITAS_TRADE.Text= conn.GetFieldValue("TR_PROV_FAS_Q_PERCENT").ToString().Replace("0.0","");
					TXT_PROVISI_GIRO_TRADE.Text		= conn.GetFieldValue("TR_PROV_GIRO_JAMINAN").ToString().Replace("0.0","");
					TXT_PROVISION_TRADE.Text		= conn.GetFieldValue("TR_PROVISI_PERCENT").ToString().Replace("0.0","");
					TXT_SWIFT_TRADE.Text			= conn.GetFieldValue("TR_SWIFT_FEE_PERCENT").ToString().Replace("0.0","");
					TXT_UNIT_COST_TRADE.Text		= conn.GetFieldValue("TR_UNIT_COST").ToString().Replace("0.0","");
					TXT_DIRECT_IT_TRADE.Text		= conn.GetFieldValue("TR_DIRECT_IT_COST").ToString().Replace("0.0","");
					TXT_FTP_COST_TRADE.Text			= conn.GetFieldValue("TR_FTP_COST_PERCENT").ToString().Replace("0.0","");

					//IBAM
					TXT_AVE_VOLUME_IBAM.Text		= conn.GetFieldValue("IBAM_AVE_VOL_REFE").ToString().Replace("0.0","");
					TXT_TOTAL_VOLUME_IBAM.Text		= conn.GetFieldValue("IBAM_TOT_VOL_YEAR").ToString().Replace("0.0","");
					TXT_REFERRAL_IBAM.Text			= conn.GetFieldValue("IBAM_NO_OF_REFE").ToString().Replace("0.0","");
					/******************************/
					TXT_OTHER_COST_IBAM.Text		= conn.GetFieldValue("IBAM_OTHER_COST_PERCENT").ToString().Replace("0.0","");
					TXT_SERVICE_FEE_IBAM.Text		= conn.GetFieldValue("IBAM_SERVICE_FEE_PERCENT").ToString().Replace("0.0","");
					TXT_SPREAD_IBAM.Text			= conn.GetFieldValue("IBAM_SPREAD_PERCENT").ToString().Replace("0.0","");
					TXT_REFERRAL_FEE_IBAM.Text		= conn.GetFieldValue("IBAM_REFE_FEE_INCOME_PERCENT").ToString().Replace("0.0","");

					//PAYMENT
					TXT_AVERAGE_PAYMENT.Text		= conn.GetFieldValue("PY_AVE_VOL_TX").ToString().Replace("0.0","");
					TXT_TRANSACTION_PAYMENT.Text	= conn.GetFieldValue("PY_NO_OF_TX_YEAR").ToString().Replace("0.0","");
					/******************************/
					TXT_INTEREST_PAYMENT.Text			= conn.GetFieldValue("PY_INTEREST_RATE_PERCENT").ToString().Replace("0.0","");
					TXT_PROVISION_PAYMENT.Text			= conn.GetFieldValue("PY_PROVISI_PERCENT").ToString().Replace("0.0","");
					TXT_CORRESPONDENT_COST_PAYMENT.Text	= conn.GetFieldValue("PY_CORRESPON_COST").ToString().Replace("0.0","");
					TXT_CORRESPONDENT_FEE_PAYMENT.Text	= conn.GetFieldValue("PY_CORRESPON_FEE").ToString().Replace("0.0","");
					TXT_BI_PAYMENT.Text					= conn.GetFieldValue("PY_BI_COST").ToString().Replace("0.0","");
					TXT_CABLE_COST_PAYMENT.Text			= conn.GetFieldValue("PY_CABLE_COST").ToString().Replace("0.0","");
					TXT_CABLE_FEE_PAYMENT.Text			= conn.GetFieldValue("PY_CABLE_FEE").ToString().Replace("0.0","");
					TXT_FIXED_FEE_PAYMENT.Text			= conn.GetFieldValue("PY_FIXED_FEE").ToString().Replace("0.0","");
					TXT_INDIRECT_PAYMENT.Text			= conn.GetFieldValue("PY_INDIRECT_COST").ToString().Replace("0.0","");
					TXT_IT_COST_PAYMENT.Text			= conn.GetFieldValue("PY_IT_COST_TX").ToString().Replace("0.0","");
					TXT_MINIMUM_PROVISION_PAYMENT.Text	= conn.GetFieldValue("PY_MIN_PROVISION").ToString().Replace("0.0","");
					TXT_MAXIMUM_PROVISION_PAYMENT.Text	= conn.GetFieldValue("PY_MAX_PROVISION").ToString().Replace("0.0","");

					//FUNDING
					TXT_PAYROLL_FUNDING.Text			= conn.GetFieldValue("FD_NO_OF_PAYROLL").ToString().Replace("0.0","");
					TXT_PICKUP_FUNDING.Text				= conn.GetFieldValue("FD_PICKUP").ToString().Replace("0.0","");
					TXT_TRANSACTION_FUNDING.Text		= conn.GetFieldValue("FD_NO_TX_YEAR").ToString().Replace("0.0","");
					TXT_RATE_FUNDING.Text				= conn.GetFieldValue("FD_RATE_EMPLOYEE").ToString().Replace("0.0","");
					/******************************/
					TXT_PROCESSING_FEE_FUNDING.Text		= conn.GetFieldValue("FD_CASH_PROCESS_FEE").ToString().Replace("0.0","");
					TXT_SERVICE_COST_FUNDING.Text		= conn.GetFieldValue("FD_SERVICE_COST").ToString().Replace("0.0","");
					TXT_CASHIN_SHIFT_FUNDING.Text		= conn.GetFieldValue("FD_CASH_INSHIFT").ToString().Replace("0.0","");
					TXT_CASHIN_TRANSIT_FUNDING.Text		= conn.GetFieldValue("FD_CASH_INTRANSIT").ToString().Replace("0.0","");
					TXT_COLLECTION_FUNDING.Text			= conn.GetFieldValue("FD_COLLECTION_FEE").ToString().Replace("0.0","");
					TXT_FEE_FUNDING.Text				= conn.GetFieldValue("FD_FEE_TX").ToString().Replace("0.0","");
					TXT_IT_COST_FUNDING.Text			= conn.GetFieldValue("FD_IT_COST_TX").ToString().Replace("0.0","");
					TXT_MINIMUM_FEE_FUNDING.Text		= conn.GetFieldValue("FD_MIN_FEE").ToString().Replace("0.0","");
					break;

				case "delete":
					conn.QueryString = "DELETE FROM AP_DEAL_ANALYZER WHERE CIF#='" + e.Item.Cells[2].Text.Trim() + "' AND SEQ_SCENARIO = '" + e.Item.Cells[0].Text.Trim() + "' AND SCENARIO#='" + e.Item.Cells[1].Text.Trim() + "'";
					conn.ExecuteQuery();

					CekCode();
					ClearData();
					ViewScenario();
					FillGridScenario();
					DDL_PRODUCT.SelectedValue = "";
					DDL_CURRENCY.SelectedValue = "";
					TBL_PAGE.Visible = false;
					break;
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("CustomerList.aspx?mc=" + Request.QueryString["mc"]);
		}
	}
}
