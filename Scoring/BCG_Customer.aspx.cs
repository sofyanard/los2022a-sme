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
	/// Summary description for CustomerRating.
	/// 1. Customer harus di-rate: (belum pernah di rate/rate expired)
	///			Load Current data&RATE!!
	///	2. Customer dah pernah di-rate:
	///			- munculkan data rate terakhir
	///			- btn text "Re-Rate"
	///			- Data yang tidak current lagi dikasih warna merah
	///			Saat "Re-rate" di tekan : 
	///			- muncul data yang current otomatis tanpa hasil rating
	///			- btn text jadi "Rate"
	///			Saat "Rate" ditekan :
	///			- Perform Rating : Generate text input file ==> kirim ke STW, baca hasil dan display
	/// 
	/// </summary>
	public partial class BCG_Customer : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected Tools tool = new Tools();		
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV2;uid=sa;pwd=dmscorp");
		protected Connection conn;
		//median-extreme
		string TA0401,TA0402,TA0403,TA0404,TA0405,TA0406,TA0407,TA0408,TA0409,TA0410,TA0411,TA0412,TA0413,TA0414,TA0415;
		string TA0416,TA0417,TA0418,TA0419,TA0420,TA0421,TA0422,TA0423,TA0424,TA0425,TA0426,TA0427,TA0428,TA0429,TA0430;
		string TA0431,TA0432,TA0433,TA0434,TA0435,TA0436,TA0437,TA0438,TA0439,TA0440,TA0441,TA0442,TA0443,TA0444,TA0502,TA0503;

		/* untuk scoring */ 
		protected int i = 0;
					
			
		/*belum muncul*/
		protected System.Web.UI.WebControls.Label LBL_CA023;
		protected System.Web.UI.WebControls.Label LBL_CA024;
		protected System.Web.UI.WebControls.Label LBL_CA025;
		protected System.Web.UI.WebControls.Label LBL_CA026;
		protected System.Web.UI.WebControls.Label LBL_CA027;
		protected System.Web.UI.WebControls.Label LBL_CA028;
		protected System.Web.UI.WebControls.Label LBL_CA029;
		protected System.Web.UI.WebControls.Label LBL_CA030;
		protected System.Web.UI.WebControls.Label LBL_CA031;
		protected System.Web.UI.WebControls.Label LBL_CA032;
		protected System.Web.UI.WebControls.Label LBL_CA033;
		string str;

						
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			TD_Pre_Customer_Rating.Visible = true;
			TD_Historical_Customer_Rating.Visible = true;
			TR_CUSTOMER_RATING.Visible = true;
			TD_Historical_Qualitative.Visible = true;
			TD_Historical_Financial_Rating.Visible = true;

			//hide pre, history dan semua yang g dipakai klo g pakai buffer
			conn.QueryString  = "EXEC ISNEEDBUFFER '" + Request.QueryString["regno"] + "'";	//this method called after rate, thus by this ap_regno
			conn.ExecuteQuery();
			if(conn.GetFieldValue("ISTRUE") == "N")
			{
				TD_Pre_Customer_Rating.Visible = false;
				TD_Historical_Customer_Rating.Visible = false;
				TR_CUSTOMER_RATING.Visible = false;
				TD_Historical_Qualitative.Visible = false;
				TD_Historical_Financial_Rating.Visible = false;
			}

			if (!IsPostBack)
			{
				GlobalTools.fillRefList(DDL_INDCODE, "SELECT * FROM VW_RFSTWINDUSTRIALCODE", conn);
				this.LBL_CU_REF.Text = Request.QueryString["curef"];
				ViewData();
				cekControl();
			}
			SecureData();
			setButtonsStatus();
			//btnUpdateStatus.Attributes.Add("onclick", "if(!update()) { return false; };");
			btnUpdateStatus.Attributes.Add("onclick","if(!updateMsg('E')){return false;};");
            btnRate.Click += new EventHandler(btnRate_Click);
		}

		public void cekControl()
		{
			conn.QueryString  = "SELECT UPPER(REPLACE(REPLACE(REPLACE(REPLACE(PRMSCORING_PARAM.PARAM_NAME, ' ', '_'),'-','_'),'(',''),')','')) as PARAMNAME " +
			"FROM PRMSCORING_PARAM ";
			conn.ExecuteQuery();

			for(int i=0; i<conn.GetRowCount(); i++)
			{
				System.Web.UI.Control cont = this.Page.FindControl(conn.GetFieldValue(i,0));
				string d = conn.GetFieldValue(i,0).ToString();
				if(cont != null)
				{
					HtmlTableRow tr = (HtmlTableRow) cont;
					tr.Visible = false;
				}
			}
			
			conn.QueryString  = "SELECT UPPER(REPLACE(REPLACE(REPLACE(REPLACE(PRMSCORING_PARAM.PARAM_NAME, ' ', '_'),'-','_'),'(',''),')','')) as PARAMNAME " +
			"FROM APPLICATION, PRMSCORING_MODEL, PRMSCORING_PARAM, PRMSCORING_PARAM_VALUE " +
			"WHERE APPLICATION.PROG_CODE = PRMSCORING_MODEL.PROGRAMID " +
			"AND PRMSCORING_MODEL.SCOTPL_ID = PRMSCORING_PARAM_VALUE.SCOTPL_ID " +
			"AND PRMSCORING_PARAM.PARAM_ID = PRMSCORING_PARAM_VALUE.PARAM_ID " +
			"AND APPLICATION.AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			for(int i=0; i<conn.GetRowCount(); i++)
			{
				System.Web.UI.Control cont = this.Page.FindControl(conn.GetFieldValue(i,0));
				string d = conn.GetFieldValue(i,0).ToString();
				if(cont != null)
				{
					HtmlTableRow tr = (HtmlTableRow) cont;
					tr.Visible = true;
				}
			}
		}

		private void ViewData() 
		{
			conn.QueryString  = "select top 1 convert(varchar,GETDATE(),112) AS NOW, " + 
				"CONVERT (VARCHAR,DATEADD(YEAR,1,RATEDATE),112) AS EXPIREDDATE " +
				"from vw_scorebcg_resultcustrating where CU_REF = '" + Request.QueryString["curef"] +
				"' ORDER BY SEQ DESC";
			conn.ExecuteQuery();

			int now = 0;
			int expired = 0;
			try 
			{
				now		= int.Parse(conn.GetFieldValue(0,"NOW"));
				expired	= int.Parse(conn.GetFieldValue(0,"EXPIREDDATE"));
			} 
			catch {}

			if (loadLastRatingData())
			{
				if (now > expired)
				{
					this.btnRate.Text = "Rate";
					this.loadCurrentData();
					ClearResponse();
					return;
				}
				this.btnRate.Text = "Re-Rate";
				// color + load into Denny's database
				this.GiveMandatoryClass();
				//kalo data tidak current lagi diberi warna merah!! (belum nih)
			}
			else
			{
				//GlobalTools.popMessage(this,"false");
				this.btnRate.Text = "Rate";
				this.loadCurrentData();
				ClearResponse();
			}
			//Adjustment();//
		}

		private void ClearResponse()
		{
			LBL_A0701.Text	= "";
			LBL_A0801.Text	= "";
			LBL_A0802.Text	= "";
			LBL_G0025.Text	= "";
			LBL_G0026.Text	= "";
			LBL_G0027.Text	= "";
			LBL_A0901.Text	= "";
			LBL_0G024.Text	= "";
			LBL_0A602.Text	= "";
			LBL_0A601.Text	= "";
			LBL_0A603.Text	= "";
			LBL_A1002.Text	= "";
			LBL_A1001.Text	= "";
			LBL_A1003.Text	= "";
			LBL_A1004.Text	= "";

			LBL_0G024H.Text	= "";
			LBL_0A601H.Text	= "";
			LBL_0A602H.Text	= "";
			LBL_0A603H.Text	= "";
			LBL_0A601F.Text	= "";
			LBL_0A602F.Text	= "";
			LBL_0A603F.Text	= "";

			LBL_A1003H.Text	= "";
			LBL_A1004H.Text	= "";
			LBL_A1003F.Text	= "";
			LBL_A1004F.Text	= "";

			LBL_G0027H.Text = "";
			LBL_A0901H.Text = "";
		}

		private void enableRDO(bool mode)
		{
			RDO_A0303ACCEPTCUSTRISKCLASS.Enabled = mode;

			RDO_CU_PERNAHJDNASABAHBM.Enabled = mode;
			RDO_AP_BLBIPERNAH.Enabled = mode;
			
			RDO_LANCAR_LAST_12BLN.Enabled = mode;
			RDO_PRIORRESULT_LOSS.Enabled = mode;
			RDO_REVOLVING_NOW.Enabled = mode;
			RDO_FULL_RECOVERY.Enabled = mode;
			RDO_DEFAULT_LOSS.Enabled = mode;
		}

		private void enableRDOnew(bool mode)
		{
			RBL_ACCEPT1.Enabled = mode;
			RBL_ACCEPT2.Enabled = mode;
			RBL_ACCEPT3.Enabled = mode;

			if (mode == true)
			{
				RBL_ACCEPT1.CssClass = "mandatory";
				RBL_ACCEPT2.CssClass = "mandatory";
				RBL_ACCEPT3.CssClass = "mandatory";
			}
			else
			{
				RBL_ACCEPT1.CssClass = "";
				RBL_ACCEPT2.CssClass = "";
				RBL_ACCEPT3.CssClass = "";
			}
		}

		private void resetRDOnew()
		{
			RBL_ACCEPT1.SelectedValue = "1";
			RBL_ACCEPT2.SelectedValue = "0";
			RBL_ACCEPT3.SelectedValue = "0";
		}

		private bool loadLastRatingData()
		{
			string seq = "";
			//ViewResultRatingData
			/* diganti procedure dibawah
			conn.QueryString = "SELECT TOP 1 * FROM VW_SCOREBCG_RESULTCUSTRATING where CU_REF ='" +
				Request.QueryString["curef"] + "' " + "order by RATEDATE desc";
			*/
			conn.QueryString = "EXEC SCOREBCG_LOADLASTRATINGDATA '" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			int jmlresult = conn.GetRowCount();
			
			if (conn.GetRowCount()> 0)
			{
				seq = conn.GetFieldValue(0,"SEQ");
				LBL_A0701.Text	= conn.GetFieldValue(0,"PH_DESC");
				LBL_A0801.Text	= conn.GetFieldValue(0,"A0801IND_SCORE");
				LBL_A0802.Text	= conn.GetFieldValue(0,"IND_DESC");
				LBL_G0025.Text	= conn.GetFieldValue(0,"G0025TMQ_SCORE");
				LBL_G0026.Text	= conn.GetFieldValue(0,"G0026TBO_SCORE");
				LBL_G0027.Text	= conn.GetFieldValue(0,"G0027QUAL_SCORE");
				LBL_A0901.Text	= conn.GetFieldValue(0,"QUAL_DESC");
				LBL_0G024.Text	= conn.GetFieldValue(0,"G0024FIN_SCORE");
				LBL_0A602.Text	= conn.GetFieldValue(0,"A0602FIN_RISKCLASS");
				LBL_0A601.Text	= conn.GetFieldValue(0,"A0601FIN_SCORERANGE");
				LBL_0A603.Text	= conn.GetFieldValue(0,"A0603FIN_PDRANGE");
				LBL_A1002.Text	= conn.GetFieldValue(0,"A1002CUST_PRE_RISKCLASS");
				LBL_A1001.Text	= conn.GetFieldValue(0,"ADJ_DESC");
				LBL_A1003.Text	= conn.GetFieldValue(0,"A1003CUST_FINAL_RISKCLASS");
				LBL_A1004.Text	= conn.GetFieldValue(0,"A1004CUST_PDRANGE");

				ViewLastBuffer(Request.QueryString["regno"], Request.QueryString["curef"], seq);
			}
			
			//ViewInputRatingData
			/*conn.QueryString = "select TOP 1 * from VW_SCOREBCG_INPUTCUSTRATING where AP_REGNO ='" +
				Request.QueryString["regno"] + "' order by RATEDATE desc";*/
			if (seq != "")
			{
				/*conn.QueryString = "select TOP 1 * from VW_SCOREBCG_INPUTCUSTRATING where CU_REF ='" +
					Request.QueryString["curef"] + "' and SEQ = " + seq + " order by RATEDATE desc";
				conn.ExecuteQuery();*/

				conn.QueryString = "EXEC SCOREBCG_CUSTFINANCIALRATIO '" + Request.QueryString["regno"] + "', '" +
					Request.QueryString["curef"] + "'";		
				conn.ExecuteQuery();
			}
			if (conn.GetRowCount () > 0 && seq != "")
			{
				/*this.TXT_OPERATING_CASHFLOW_TO_DEBT.Text= Devide100(conn.GetFieldValue(0,"A0001OPERATING_CASHFLOW_TO_DEBT"));
				this.TXT_CURRENT_RATIO.Text				= Devide100(conn.GetFieldValue(0,"A0002CURRENT_RATIO"));
				this.TXT_DEBT_TO_EQUITY.Text	= Devide100(conn.GetFieldValue(0,"A0003ABSOLUTE_DEBT_TO_EQUITY"));
				this.TXT_DEBT_TO_ASSETS.Text			= Devide100(conn.GetFieldValue(0,"A0004DEBT_TO_ASSETS"));
				this.TXT_EBITDA_TO_INTEREST_EXPENSE.Text	= Devide100(conn.GetFieldValue(0,"A0005EBITDA_TO_INTERESTEXPENSE"));
				this.TXT_RETURN_ON_AVERAGE_EQUITY.Text	= Devide100(conn.GetFieldValue(0,"A0006RETURN_ON_AVERAGE_EQUITY"));
				this.TXT_NET_PROFIT_MARGIN.Text				= Devide100(conn.GetFieldValue(0,"A0007NET_MARGIN"));
				this.TXT_ASSETS_TURN_OVER.Text			= Devide100(conn.GetFieldValue(0,"A0008ASSETS_TURNOVER"));
				this.TXT_INVENTORY_TURN_OVER.Text		= Devide100(conn.GetFieldValue(0,"A0009INVENTORY_TURNOVER"));
				this.TXT_EBITDA_GROWTH.Text				= Devide100(conn.GetFieldValue(0,"A0010EBITDA_GROWTH"));
				this.TXT_NET_INCOME_GROWTH.Text			= Devide100(conn.GetFieldValue(0,"A0011NET_INCOME_GROWTH"));
				this.TXT_QUICK_RATIO.Text				= Devide100(conn.GetFieldValue(0,"A0012QUICK_RATIO"));
				this.TXT_DEBT_TO_CAPITAL.Text			= Devide100(conn.GetFieldValue(0,"A0013DEBT_TO_CAPITAL"));
				this.TXT_LONG_TERM_DEBT_TO_EQUITY_LTD.Text	= Devide100(conn.GetFieldValue(0,"A0014LONGTERM_DEBT_TO_EQUITY"));
				this.TXT_EBITDA_TO_DEBT.Text			= Devide100(conn.GetFieldValue(0,"A0015EBITDA_TO_DEBT"));
				this.TXT_EBITDA_TO_LIABILITIES.Text		= Devide100(conn.GetFieldValue(0,"A0016EBITDA_TO_LIABILITIES"));
				this.TXT_RECEIVABLE_TURN_OVER.Text		= Devide100(conn.GetFieldValue(0,"A0017RECEIVABLE_TURNOVER"));
				this.TXT_FIXED_ASSETS_TURN_OVER.Text		= Devide100(conn.GetFieldValue(0,"A0018FIXED_ASSETS_TURNOVER"));
				this.TXT_OPERATING_MARGIN.Text			= Devide100(conn.GetFieldValue(0,"A0019OPERATING_MARGIN"));
				this.TXT_SALES_GROWTH.Text				= Devide100(conn.GetFieldValue(0,"A0020SALES_GROWTH"));
				this.TXT_RETURN_ON_AVERAGE_ASSETS.Text	= Devide100(conn.GetFieldValue(0,"A0021RETURN_ON_AVERAGE_ASSETS"));
				this.TXT_OPERATING_CASHFLOW_TO_INTERESTEXPENSE.Text = Devide100(conn.GetFieldValue(0,"A0022OPERATING_CASHFLOW_TO_INTERESTEXPENSE"));
				*/

				TXT_OPERATING_CASHFLOW_TO_DEBT.Text = conn.GetFieldValue(0, "EBITDA_TO_DEBT");
				TXT_OPERATING_CASHFLOW_TO_DEBT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_TO_DEBT"));
				TXT_CURRENT_RATIO.Text = conn.GetFieldValue(0, "CURRENT_RATIO").ToString();
				TXT_CURRENT_RATIO.Text = tool.MoneyFormat(conn.GetFieldValue(0, "CURRENT_RATIO").ToString());
				TXT_DEBT_TO_EQUITY.Text = conn.GetFieldValue(0, "DEBT_EQUITY_RATIO");
				TXT_DEBT_TO_EQUITY.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DEBT_EQUITY_RATIO"));
				TXT_DEBT_TO_ASSETS.Text = conn.GetFieldValue(0, "DEBT_TO_ASSETS");
				TXT_DEBT_TO_ASSETS.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DEBT_TO_ASSETS"));
				TXT_EBITDA_TO_INTEREST_EXPENSE.Text = conn.GetFieldValue(0, "EBITDA_TO_INTERESTEXPENSE");
				TXT_EBITDA_TO_INTEREST_EXPENSE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_TO_INTERESTEXPENSE"));
				TXT_RETURN_ON_AVERAGE_EQUITY.Text = conn.GetFieldValue(0, "RETURN_AVRG_EQUITY");
				TXT_RETURN_ON_AVERAGE_EQUITY.Text = tool.MoneyFormat(conn.GetFieldValue(0, "RETURN_AVRG_EQUITY"));
				TXT_NET_PROFIT_MARGIN.Text = conn.GetFieldValue(0, "NET_PROFITMARGIN");
				TXT_NET_PROFIT_MARGIN.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NET_PROFITMARGIN"));
				TXT_ASSETS_TURN_OVER.Text = conn.GetFieldValue(0, "ASSETS_TURNOVER");
				TXT_ASSETS_TURN_OVER.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ASSETS_TURNOVER"));
				TXT_INVENTORY_TURN_OVER.Text = conn.GetFieldValue(0, "INVENTORY_TURNOVER");
				TXT_INVENTORY_TURN_OVER.Text = tool.MoneyFormat(conn.GetFieldValue(0, "INVENTORY_TURNOVER"));
				TXT_EBITDA_GROWTH.Text = conn.GetFieldValue(0, "EBITDA_GROWTH");
				TXT_EBITDA_GROWTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_GROWTH"));
				TXT_NET_INCOME_GROWTH.Text = conn.GetFieldValue(0, "NET_INCOME_GROWTH");
				TXT_NET_INCOME_GROWTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NET_INCOME_GROWTH"));
				TXT_QUICK_RATIO.Text = conn.GetFieldValue(0, "QUICK_ASSET_RATIO");
				TXT_QUICK_RATIO.Text = tool.MoneyFormat(conn.GetFieldValue(0, "QUICK_ASSET_RATIO"));
				TXT_DEBT_TO_CAPITAL.Text = conn.GetFieldValue(0, "DEBT_TO_CAPITAL");
				TXT_DEBT_TO_CAPITAL.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DEBT_TO_CAPITAL"));
				TXT_LONG_TERM_DEBT_TO_EQUITY_LTD.Text = conn.GetFieldValue(0, "LONGTERM_DEBT_TO_EQUITY");
				TXT_LONG_TERM_DEBT_TO_EQUITY_LTD.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LONGTERM_DEBT_TO_EQUITY"));
				TXT_EBITDA_TO_DEBT.Text = conn.GetFieldValue(0, "EBITDA_TO_DEBT");
				TXT_EBITDA_TO_DEBT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_TO_DEBT"));
				TXT_EBITDA_TO_LIABILITIES.Text = conn.GetFieldValue(0, "EBITDA_TO_LIABILITIES");
				TXT_EBITDA_TO_LIABILITIES.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_TO_LIABILITIES"));
				TXT_RECEIVABLE_TURN_OVER.Text = conn.GetFieldValue(0, "RECEIVABLE_TURNOVER");
				TXT_RECEIVABLE_TURN_OVER.Text = tool.MoneyFormat(conn.GetFieldValue(0, "RECEIVABLE_TURNOVER"));
				TXT_FIXED_ASSETS_TURN_OVER.Text = conn.GetFieldValue(0, "FIXED_ASSETS_TURNOVER");
				TXT_FIXED_ASSETS_TURN_OVER.Text = tool.MoneyFormat(conn.GetFieldValue(0, "FIXED_ASSETS_TURNOVER"));
				TXT_OPERATING_MARGIN.Text = conn.GetFieldValue(0, "OPERATING_MARGIN");
				TXT_OPERATING_MARGIN.Text = tool.MoneyFormat(conn.GetFieldValue(0, "OPERATING_MARGIN"));
				TXT_SALES_GROWTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "SALES_GROWTH"));
				TXT_SALES_GROWTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "SALES_GROWTH"));
				TXT_RETURN_ON_AVERAGE_ASSETS.Text = conn.GetFieldValue(0, "RETURN_AVRG_ASSET");
				TXT_RETURN_ON_AVERAGE_ASSETS.Text = tool.MoneyFormat(conn.GetFieldValue(0, "RETURN_AVRG_ASSET"));
				TXT_OPERATING_CASHFLOW_TO_INTERESTEXPENSE.Text = conn.GetFieldValue(0, "EBITDA_TO_INTERESTEXPENSE");
				TXT_OPERATING_CASHFLOW_TO_INTERESTEXPENSE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_TO_INTERESTEXPENSE"));
					
				TXT_NET_TRADE_CYCLE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NET_TRADE_CYCLE"));
				TXT_NET_TRADE_CYCLE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NET_TRADE_CYCLE"));
				TXT_GEARING_RATIO.Text = tool.MoneyFormat(conn.GetFieldValue(0, "GEARING_RATIO"));
				TXT_NET_REVENUE_PER_MONTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NET_REVENUE_PERMONTH"));
				TXT_ACCOUNT_RECEIVABLE_TO_LIABILITIES.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ACCRECEIVABLE_TO_LIABILITIES"));
				TXT_EQUITY_TO_ASSET.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EQUITY_TO_ASSET"));
				TXT_ASSET_GROWTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ASSET_GROWTH"));
				TXT_EFICIENCY_RATIO.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EFICIENCY_RATIO"));
				TXT_TOTAL_ASSET.Text = tool.MoneyFormat(conn.GetFieldValue(0, "TOTAL_ASSET"));
				TXT_ACCOUNT_RECEIVABLE_TO_ASSET.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ACCRECEIVABLE_TO_ASSET"));
				TXT_RECEIVABLES_GROWTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "RECEIVABLES_GROWTH"));
				TXT_EQUITY_GROWTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EQUITY_GROWTH"));	
				TXT_NET_REVENUE_PER_MONTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NET_REVENUE_PERMONTH"));
				TXT_ROA.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ROA"));
				TXT_BUSINESS_DEBT_SERVICE_RATIO.Text = tool.MoneyFormat(conn.GetFieldValue(0, "BUSINESS_DEBT_SERV_RATIO"));
				TXT_SALES_TO_WORKING_CAPITAL.Text = tool.MoneyFormat(conn.GetFieldValue(0, "SALES_TO_WK_CAPITAL"));
				TXT_ASSET_GROWTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ASSET_GROWTH"));
				TXT_OPERATING_CASHFLOW_TO_INTERESTEXPENSE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_TO_INTERESTEXPENSE"));
					
				TXT_QUICK_RATIO_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "QUICK_ASSET_RATIO"));
				TXT_NET_INCOME_GROWTH_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NET_INCOME_GROWTH"));
				TXT_INVENTORY_TURN_OVER_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "INVENTORY_TURNOVER"));
				TXT_CURRENT_RATIO_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "CURRENT_RATIO"));
				TXT_DEBT_TO_EQUITY_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DEBT_EQUITY_RATIO"));
				TXT_EBITDA_TO_INTEREST_EXPENSE_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_TO_INTERESTEXPENSE"));
				TXT_ASSETS_TURN_OVER_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ASSETS_TURNOVER"));
				TXT_EBITDA_GROWTH_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_GROWTH"));
				TXT_DEBT_TO_ASSETS_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DEBT_TO_ASSETS"));
				TXT_RETURN_ON_AVERAGE_EQUITY_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "RETURN_AVRG_EQUITY"));
				TXT_NET_PROFIT_MARGIN_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NET_PROFITMARGIN"));
				TXT_DEBT_TO_CAPITAL_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DEBT_TO_CAPITAL"));
				TXT_LONG_TERM_DEBT_TO_EQUITY_LTD_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LONGTERM_DEBT_TO_EQUITY"));
				TXT_EBITDA_TO_DEBT_COPRPRATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_TO_DEBT"));
				TXT_EBITDA_TO_LIABILITIES_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_TO_LIABILITIES"));
				TXT_RECEIVABLE_TURN_OVER_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "RECEIVABLE_TURNOVER"));
				TXT_FIXED_ASSETS_TURN_OVER_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "FIXED_ASSETS_TURNOVER"));
				TXT_OPERATING_MARGIN_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "OPERATING_MARGIN"));
				TXT_SALES_GROWTH_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "SALES_GROWTH"));
				TXT_RETURN_ON_AVERAGE_ASSETS_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "RETURN_AVRG_ASSET"));
				
				/*belum muncul*/
				TXT_SALES_ON_CREDIT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "SALESONCREDIT"));
				TXT_SALES_GROWTH_RATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "SALES_GROWTH_RATE"));
				TXT_RETURN_ON_EQUITY.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ROE"));
				TXT_INTEREST_AVERAGE_BANK_DEBT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "INTEREST_AVEBANKDEBT"));
				TXT_SALES_AVERAGE_ASSET.Text = tool.MoneyFormat(conn.GetFieldValue(0, "SALES_AVEASSET"));
				TXT_DAYS_RECEIVABLE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DAYS_RECEIVABLE"));
				TXT_DAYS_INVENTORY.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DAYS_INVENTORY"));
				TXT_DAYS_PAYABLE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DAYS_PAYABLE"));
				TXT_DAYS_TRADE_CYCLE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DAYS_TC"));
				TXT_LONG_TERM_LEVERAGE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LONG_TERM_LVRG"));
				TXT_TIME_INTEREST_EARN.Text = tool.MoneyFormat(conn.GetFieldValue(0, "TIME_INTRST_EARN"));
				TXT_DEBT_SERVICE_COVERAGE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DEBT_SERV_COVERAGE"));
				TXT_COLLATERAL_COVERAGE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "COLLATERAL_COVERAGE"));
				TXT_NET_WORTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NET_WORTH"));
				TXT_RETURN_ON_INVESTMENT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ROI"));
				TXT_NET_PRESENT_VALUE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NPV"));
				TXT_INTEREST_RATE_OF_RETURN.Text = tool.MoneyFormat(conn.GetFieldValue(0, "IRR"));
				TXT_PAYBACK.Text = tool.MoneyFormat(conn.GetFieldValue(0, "PAYBACK"));
				TXT_EBITDA.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA"));
				TXT_DEBT_TO_NETWORTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DEBT_TO_NETWORTH"));
				TXT_SALES_INCREASE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "SALES_INCREASE"));
				TXT_NET_INCOME_INCREASE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NETINCOME_INCREASE"));
				TXT_AVERAGE_NET_PROFIT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "AVERAGE_NETPROFIT"));
				TXT_NET_WORKING_CAPITAL.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NET_WORKING_CAPITAL"));
				TXT_GROSS_PROFIT_MARGIN.Text = tool.MoneyFormat(conn.GetFieldValue(0, "GROSS_PROFIT_MARGIN"));
				TXT_OPERATIONAL_PROFIT_MARGIN.Text = tool.MoneyFormat(conn.GetFieldValue(0, "OPR_PROFIT_MARGIN"));
				TXT_TOTAL_EQUITY.Text = tool.MoneyFormat(conn.GetFieldValue(0, "TOTAL_EQUITY"));
				TXT_LEVERAGE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LEVERAGE"));
				TXT_LONGTERM_DEBT_TO_EQUITY.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LONGTERM_DEBT_TO_EQUITY"));
				TXT_INTEREST_COVERAGE_RATIO.Text = tool.MoneyFormat(conn.GetFieldValue(0, "INTEREST_COVERAGE_RATIO"));
				TXT_INTEREST_TO_SALES_RATIO.Text = tool.MoneyFormat(conn.GetFieldValue(0, "INTEREST_TO_SALES_RATIO"));
				TXT_DEBT_TO_EBITDA.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DEBT_TO_EBITDA"));
				TXT_DEBT_SERVICE_COVERAGE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DSC"));
				TXT_ACCOUNT_PAYABLE_TURN_OVER.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ACCPAYABLE_TURNOVER"));

				conn.QueryString = "select TOP 1 * from VW_SCOREBCG_INPUTCUSTRATING where CU_REF ='" +
					Request.QueryString["curef"] + "' and SEQ = " + seq + " order by RATEDATE desc";
				conn.ExecuteQuery();
				
				this.RDO_A0303ACCEPTCUSTRISKCLASS.SelectedValue		= conn.GetFieldValue(0,"A0303ACCEPTCUSTRISKCLASS").Trim();					
				//load Payment History
				this.RDO_CU_PERNAHJDNASABAHBM.SelectedValue = conn.GetFieldValue(0,"A0101BMCUST");		
				this.RDO_AP_BLBIPERNAH.SelectedValue		= conn.GetFieldValue(0,"A0102BIIBRASIDPRESENT");
				this.RDO_LANCAR_LAST_12BLN.SelectedValue	= conn.GetFieldValue(0,"A0103RECENTCUST");
				this.RDO_PRIORRESULT_LOSS.SelectedValue		= conn.GetFieldValue(0,"A0104PRIORDEFAULTWITHLOSSES");
				this.RDO_REVOLVING_NOW.SelectedValue		= conn.GetFieldValue(0,"A0105DEFAULTNOW");
				this.RDO_FULL_RECOVERY.SelectedValue		= conn.GetFieldValue(0,"A0107RECONPREVDEFAULT");
				this.RDO_DEFAULT_LOSS.SelectedValue			= conn.GetFieldValue(0,"A0108DEFAULTWITHLOSSES");
				//BO & MM
				this.LBL_A0109.Text	= conn.GetFieldValue(0,"A0109EXPERIENCEEXPERTISE");
				this.LBL_A0110.Text = conn.GetFieldValue(0,"A0110INFDISCLOSURE");
				this.LBL_A0111.Text = conn.GetFieldValue(0,"A0111REPUTATION");
				this.LBL_A0112.Text	= conn.GetFieldValue(0,"A0112CAPITALSUPPORT");
				this.LBL_A0113.Text = conn.GetFieldValue(0,"A0113MARKETSHARE");
				this.LBL_A0114.Text	= conn.GetFieldValue(0,"A0114PRODCOMPETITIVENESS");
				this.LBL_A0115.Text = conn.GetFieldValue(0,"A0115COSTEFFICIENCY");
				this.LBL_A0116.Text = conn.GetFieldValue(0,"A0116THIRDPARTYDEPENDANCY");
				try
				{
					this.DDL_INDCODE.SelectedValue = conn.GetFieldValue(0,"A0201INDUSTRIALCODE");
				} 
				catch {}
				
				loadMgt("0");
				loadBO("0");
				
			}
			if (jmlresult > 0)
			{
				enableRDO(false);
				enableRDOnew(false);
				return true;
			}
			else
				return false;
		}

		private void CheckBeda(string a,string b, TextBox txt)
		{
			if (a != b)
				//txt.CssClass = "mandatory";
				txt.ForeColor = System.Drawing.Color.Red;
		}

		private void CheckBeda2(string a,string b, RadioButtonList rdo)
		{
			if (a != b)
				//txt.CssClass = "mandatory";
				rdo.ForeColor = System.Drawing.Color.Red;
		}

		private void CheckBeda3(string a,string b, Label lbl)
		{
			if (a != b)
				//txt.CssClass = "mandatory";
				lbl.ForeColor = System.Drawing.Color.Red;
		}

		private void GiveMandatoryClass()
		{
			loadRatio("2");
			loadPay("2");
			loadMgt("2");
			loadBO("2");
			this.CheckBeda(LBL_CA0001.Text,this.TXT_OPERATING_CASHFLOW_TO_DEBT.Text,TXT_OPERATING_CASHFLOW_TO_DEBT);
			this.CheckBeda(LBL_CA0002.Text,this.TXT_CURRENT_RATIO.Text,TXT_CURRENT_RATIO);
			this.CheckBeda(LBL_CA0003.Text,this.TXT_DEBT_TO_EQUITY.Text,TXT_DEBT_TO_EQUITY);
			this.CheckBeda(LBL_CA0004.Text,this.TXT_DEBT_TO_ASSETS.Text,TXT_DEBT_TO_ASSETS);
			this.CheckBeda(LBL_CA0005.Text,this.TXT_EBITDA_TO_INTEREST_EXPENSE.Text,TXT_EBITDA_TO_INTEREST_EXPENSE);
			this.CheckBeda(LBL_CA0006.Text,this.TXT_RETURN_ON_AVERAGE_EQUITY.Text,TXT_RETURN_ON_AVERAGE_EQUITY);
			this.CheckBeda(LBL_CA0007.Text,this.TXT_NET_PROFIT_MARGIN.Text,TXT_NET_PROFIT_MARGIN);
			this.CheckBeda(LBL_CA0008.Text,this.TXT_ASSETS_TURN_OVER.Text,TXT_ASSETS_TURN_OVER);
			this.CheckBeda(LBL_CA0009.Text,this.TXT_INVENTORY_TURN_OVER.Text,TXT_INVENTORY_TURN_OVER);
			this.CheckBeda(LBL_CA0010.Text,this.TXT_EBITDA_GROWTH.Text,TXT_EBITDA_GROWTH);
			this.CheckBeda(LBL_CA0011.Text,this.TXT_NET_INCOME_GROWTH.Text,TXT_NET_INCOME_GROWTH);
			this.CheckBeda(LBL_CA0012.Text,this.TXT_QUICK_RATIO.Text,TXT_QUICK_RATIO);
			this.CheckBeda(LBL_CA0013.Text,this.TXT_DEBT_TO_CAPITAL.Text,TXT_DEBT_TO_CAPITAL);
			this.CheckBeda(LBL_CA0014.Text,this.TXT_LONG_TERM_DEBT_TO_EQUITY_LTD.Text,TXT_LONG_TERM_DEBT_TO_EQUITY_LTD);
			this.CheckBeda(LBL_CA0015.Text,this.TXT_EBITDA_TO_DEBT.Text,TXT_EBITDA_TO_DEBT);
			this.CheckBeda(LBL_CA0016.Text,this.TXT_EBITDA_TO_LIABILITIES.Text,TXT_EBITDA_TO_LIABILITIES);
			this.CheckBeda(LBL_CA0017.Text,this.TXT_RECEIVABLE_TURN_OVER.Text,TXT_RECEIVABLE_TURN_OVER);
			this.CheckBeda(LBL_CA0018.Text,this.TXT_FIXED_ASSETS_TURN_OVER.Text,TXT_FIXED_ASSETS_TURN_OVER);
			this.CheckBeda(LBL_CA0019.Text,this.TXT_OPERATING_MARGIN.Text,TXT_OPERATING_MARGIN);
			this.CheckBeda(LBL_CA0020.Text,this.TXT_SALES_GROWTH.Text,TXT_SALES_GROWTH);
			this.CheckBeda(LBL_CA0021.Text,this.TXT_RETURN_ON_AVERAGE_ASSETS.Text,TXT_RETURN_ON_AVERAGE_ASSETS);
			this.CheckBeda(LBL_CA0022.Text,this.TXT_OPERATING_CASHFLOW_TO_INTERESTEXPENSE.Text,TXT_OPERATING_CASHFLOW_TO_INTERESTEXPENSE);	
				

			this.CheckBeda(LBL_CA0023.Text,this.TXT_NET_TRADE_CYCLE.Text,TXT_NET_TRADE_CYCLE);
			this.CheckBeda(LBL_CA0024.Text,this.TXT_GEARING_RATIO.Text,TXT_GEARING_RATIO);
			this.CheckBeda(LBL_CA0025.Text,this.TXT_NET_REVENUE_PER_MONTH.Text,TXT_NET_REVENUE_PER_MONTH);
			this.CheckBeda(LBL_CA0026.Text,this.TXT_ACCOUNT_RECEIVABLE_TO_LIABILITIES.Text,TXT_ACCOUNT_RECEIVABLE_TO_LIABILITIES);
			this.CheckBeda(LBL_CA0027.Text,this.TXT_EQUITY_TO_ASSET.Text,TXT_EQUITY_TO_ASSET);
			this.CheckBeda(LBL_CA0028.Text,this.TXT_ASSET_GROWTH.Text,TXT_ASSET_GROWTH);
			this.CheckBeda(LBL_CA0029.Text,this.TXT_EFICIENCY_RATIO.Text,TXT_EFICIENCY_RATIO);
			this.CheckBeda(LBL_CA0030.Text,this.TXT_TOTAL_ASSET.Text,TXT_TOTAL_ASSET);
			this.CheckBeda(LBL_CA0031.Text,this.TXT_ACCOUNT_RECEIVABLE_TO_ASSET.Text,TXT_ACCOUNT_RECEIVABLE_TO_ASSET);
			this.CheckBeda(LBL_CA0032.Text,this.TXT_RECEIVABLES_GROWTH.Text,TXT_RECEIVABLES_GROWTH);
			this.CheckBeda(LBL_CA0033.Text,this.TXT_EQUITY_GROWTH.Text,TXT_EQUITY_GROWTH );
			this.CheckBeda(LBL_CA0034.Text,this.TXT_NET_REVENUE_PER_MONTH.Text,TXT_NET_REVENUE_PER_MONTH);
			this.CheckBeda(LBL_CA0035.Text,this.TXT_ROA.Text,TXT_ROA);
			this.CheckBeda(LBL_CA0036.Text,this.TXT_BUSINESS_DEBT_SERVICE_RATIO.Text,TXT_BUSINESS_DEBT_SERVICE_RATIO );
			this.CheckBeda(LBL_CA0037.Text,this.TXT_SALES_TO_WORKING_CAPITAL.Text,TXT_SALES_TO_WORKING_CAPITAL);
			this.CheckBeda(LBL_CA0038.Text,this.TXT_ASSET_GROWTH.Text,TXT_ASSET_GROWTH);
			this.CheckBeda(LBL_CA0039.Text,this.TXT_OPERATING_CASHFLOW_TO_INTERESTEXPENSE.Text,TXT_OPERATING_CASHFLOW_TO_INTERESTEXPENSE);
					
			this.CheckBeda(LBL_CA0040.Text,this.TXT_QUICK_RATIO_CORPORATE.Text,TXT_QUICK_RATIO_CORPORATE);
			this.CheckBeda(LBL_CA0041.Text,this.TXT_NET_INCOME_GROWTH_CORPORATE.Text,TXT_NET_INCOME_GROWTH_CORPORATE);
			this.CheckBeda(LBL_CA0042.Text,this.TXT_INVENTORY_TURN_OVER_CORPORATE.Text,TXT_INVENTORY_TURN_OVER_CORPORATE);
			this.CheckBeda(LBL_CA0043.Text,this.TXT_CURRENT_RATIO_CORPORATE.Text,TXT_CURRENT_RATIO_CORPORATE);
			this.CheckBeda(LBL_CA0044.Text,this.TXT_DEBT_TO_EQUITY_CORPORATE.Text,TXT_DEBT_TO_EQUITY_CORPORATE);
			this.CheckBeda(LBL_CA0045.Text,this.TXT_EBITDA_TO_INTEREST_EXPENSE_CORPORATE.Text,TXT_EBITDA_TO_INTEREST_EXPENSE_CORPORATE);
			this.CheckBeda(LBL_CA0046.Text,this.TXT_ASSETS_TURN_OVER_CORPORATE.Text,TXT_ASSETS_TURN_OVER_CORPORATE);
			this.CheckBeda(LBL_CA0047.Text,this.TXT_EBITDA_GROWTH_CORPORATE.Text,TXT_EBITDA_GROWTH_CORPORATE);
			this.CheckBeda(LBL_CA0048.Text,this.TXT_DEBT_TO_ASSETS_CORPORATE.Text,TXT_DEBT_TO_ASSETS_CORPORATE);
			this.CheckBeda(LBL_CA0049.Text,this.TXT_RETURN_ON_AVERAGE_EQUITY_CORPORATE.Text,TXT_RETURN_ON_AVERAGE_EQUITY_CORPORATE);
			this.CheckBeda(LBL_CA0050.Text,this.TXT_NET_PROFIT_MARGIN_CORPORATE.Text,TXT_NET_PROFIT_MARGIN_CORPORATE);
			this.CheckBeda(LBL_CA0051.Text,this.TXT_DEBT_TO_CAPITAL_CORPORATE.Text,TXT_DEBT_TO_CAPITAL_CORPORATE);
			this.CheckBeda(LBL_CA0052.Text,this.TXT_LONG_TERM_DEBT_TO_EQUITY_LTD_CORPORATE.Text,TXT_LONG_TERM_DEBT_TO_EQUITY_LTD_CORPORATE);
			this.CheckBeda(LBL_CA0053.Text,this.TXT_EBITDA_TO_DEBT_COPRPRATE.Text,TXT_EBITDA_TO_DEBT_COPRPRATE);
			this.CheckBeda(LBL_CA0054.Text,this.TXT_EBITDA_TO_LIABILITIES_CORPORATE.Text,TXT_EBITDA_TO_LIABILITIES_CORPORATE);
			this.CheckBeda(LBL_CA0055.Text,this.TXT_RECEIVABLE_TURN_OVER_CORPORATE.Text,TXT_RECEIVABLE_TURN_OVER_CORPORATE);
			this.CheckBeda(LBL_CA0056.Text,this.TXT_FIXED_ASSETS_TURN_OVER_CORPORATE.Text,TXT_FIXED_ASSETS_TURN_OVER_CORPORATE);
			this.CheckBeda(LBL_CA0057.Text,this.TXT_OPERATING_MARGIN_CORPORATE.Text,TXT_OPERATING_MARGIN_CORPORATE);
			this.CheckBeda(LBL_CA0058.Text,this.TXT_SALES_GROWTH_CORPORATE.Text,TXT_SALES_GROWTH_CORPORATE);
			this.CheckBeda(LBL_CA0059.Text,this.TXT_RETURN_ON_AVERAGE_ASSETS_CORPORATE.Text,TXT_RETURN_ON_AVERAGE_ASSETS_CORPORATE);
			
			/*belum muncul*/
			this.CheckBeda(LBL_CA0060.Text,this.TXT_SALES_ON_CREDIT.Text,TXT_SALES_ON_CREDIT);
			this.CheckBeda(LBL_CA0061.Text,this.TXT_SALES_GROWTH_RATE.Text,TXT_SALES_GROWTH_RATE);
			this.CheckBeda(LBL_CA0062.Text,this.TXT_RETURN_ON_EQUITY.Text,TXT_RETURN_ON_EQUITY);
			this.CheckBeda(LBL_CA0063.Text,this.TXT_INTEREST_AVERAGE_BANK_DEBT.Text,TXT_INTEREST_AVERAGE_BANK_DEBT);
			this.CheckBeda(LBL_CA0064.Text,this.TXT_SALES_AVERAGE_ASSET.Text,TXT_SALES_AVERAGE_ASSET);
			this.CheckBeda(LBL_CA0065.Text,this.TXT_DAYS_RECEIVABLE.Text,TXT_DAYS_RECEIVABLE);
			this.CheckBeda(LBL_CA0066.Text,this.TXT_DAYS_INVENTORY.Text,TXT_DAYS_INVENTORY);
			this.CheckBeda(LBL_CA0067.Text,this.TXT_DAYS_PAYABLE.Text,TXT_DAYS_PAYABLE);
			this.CheckBeda(LBL_CA0068.Text,this.TXT_DAYS_TRADE_CYCLE.Text,TXT_DAYS_TRADE_CYCLE);
			this.CheckBeda(LBL_CA0069.Text,this.TXT_LONG_TERM_LEVERAGE.Text,TXT_LONG_TERM_LEVERAGE);
			this.CheckBeda(LBL_CA0070.Text,this.TXT_TIME_INTEREST_EARN.Text,TXT_TIME_INTEREST_EARN);
			this.CheckBeda(LBL_CA0071.Text,this.TXT_DEBT_SERVICE_COVERAGE.Text,TXT_DEBT_SERVICE_COVERAGE);
			this.CheckBeda(LBL_CA0072.Text,this.TXT_COLLATERAL_COVERAGE.Text,TXT_COLLATERAL_COVERAGE);
			this.CheckBeda(LBL_CA0073.Text,this.TXT_NET_WORTH.Text,TXT_NET_WORTH);
			this.CheckBeda(LBL_CA0074.Text,this.TXT_RETURN_ON_INVESTMENT.Text,TXT_RETURN_ON_INVESTMENT);
			this.CheckBeda(LBL_CA0075.Text,this.TXT_NET_PRESENT_VALUE.Text,TXT_NET_PRESENT_VALUE);
			this.CheckBeda(LBL_CA0076.Text,this.TXT_INTEREST_RATE_OF_RETURN.Text,TXT_INTEREST_RATE_OF_RETURN);
			this.CheckBeda(LBL_CA0077.Text,this.TXT_PAYBACK.Text,TXT_PAYBACK);
			this.CheckBeda(LBL_CA0078.Text,this.TXT_EBITDA.Text,TXT_EBITDA);
			this.CheckBeda(LBL_CA0079.Text,this.TXT_DEBT_TO_NETWORTH.Text,TXT_DEBT_TO_NETWORTH);
			this.CheckBeda(LBL_CA0080.Text,this.TXT_SALES_INCREASE.Text,TXT_SALES_INCREASE);
			this.CheckBeda(LBL_CA0081.Text,this.TXT_NET_INCOME_INCREASE.Text,TXT_NET_INCOME_INCREASE);
			this.CheckBeda(LBL_CA0082.Text,this.TXT_AVERAGE_NET_PROFIT.Text,TXT_AVERAGE_NET_PROFIT);
			this.CheckBeda(LBL_CA0083.Text,this.TXT_NET_WORKING_CAPITAL.Text,TXT_NET_WORKING_CAPITAL);
			this.CheckBeda(LBL_CA0084.Text,this.TXT_GROSS_PROFIT_MARGIN.Text,TXT_GROSS_PROFIT_MARGIN);
			this.CheckBeda(LBL_CA0085.Text,this.TXT_OPERATIONAL_PROFIT_MARGIN.Text,TXT_OPERATIONAL_PROFIT_MARGIN);
			this.CheckBeda(LBL_CA0086.Text,this.TXT_TOTAL_EQUITY.Text,TXT_TOTAL_EQUITY);
			this.CheckBeda(LBL_CA0087.Text,this.TXT_LEVERAGE.Text,TXT_LEVERAGE);
			this.CheckBeda(LBL_CA0088.Text,this.TXT_LONGTERM_DEBT_TO_EQUITY.Text,TXT_LONGTERM_DEBT_TO_EQUITY);
			this.CheckBeda(LBL_CA0089.Text,this.TXT_INTEREST_COVERAGE_RATIO.Text,TXT_INTEREST_COVERAGE_RATIO);
			this.CheckBeda(LBL_CA0090.Text,this.TXT_INTEREST_TO_SALES_RATIO.Text,TXT_INTEREST_TO_SALES_RATIO);
			this.CheckBeda(LBL_CA0091.Text,this.TXT_DEBT_TO_EBITDA.Text,TXT_DEBT_TO_EBITDA);
			this.CheckBeda(LBL_CA0092.Text,this.TXT_DEBT_SERVICE_COVERAGE.Text,TXT_DEBT_SERVICE_COVERAGE);
			this.CheckBeda(LBL_CA0093.Text,this.TXT_ACCOUNT_PAYABLE_TURN_OVER.Text,TXT_ACCOUNT_PAYABLE_TURN_OVER);

			this.CheckBeda2(LBL_CA0102.Text, RDO_AP_BLBIPERNAH.SelectedValue, RDO_AP_BLBIPERNAH);
			this.CheckBeda2(LBL_CA0103.Text, RDO_LANCAR_LAST_12BLN.SelectedValue, RDO_LANCAR_LAST_12BLN);
			this.CheckBeda2(LBL_CA0104.Text, RDO_PRIORRESULT_LOSS.SelectedValue, RDO_PRIORRESULT_LOSS);
			this.CheckBeda2(LBL_CA0105.Text, RDO_REVOLVING_NOW.SelectedValue, RDO_REVOLVING_NOW);
			this.CheckBeda2(LBL_CA0106.Text, RDO_FULL_RECOVERY.SelectedValue, RDO_FULL_RECOVERY);
			this.CheckBeda2(LBL_CA0107.Text, RDO_DEFAULT_LOSS.SelectedValue, RDO_DEFAULT_LOSS);

			this.CheckBeda(LBL_A0109.Text,LBL_CA0109.Text,TXT_EXPERIENCE);
			this.CheckBeda(LBL_A0110.Text,LBL_CA0110.Text,TXT_INFODISCLOSURE);
			this.CheckBeda(LBL_A0111.Text,LBL_CA0111.Text,TXT_COMPANYGROUP);
			this.CheckBeda(LBL_A0112.Text,LBL_CA0112.Text,TXT_CAPITALSUPPORT);

			this.CheckBeda(LBL_A0113.Text,LBL_CA0113.Text,TXT_MARKETSHARE);
			this.CheckBeda(LBL_A0114.Text,LBL_CA0114.Text,TXT_PRODUCT_COMPETITIVENESS);
			this.CheckBeda(LBL_A0115.Text,LBL_CA0115.Text,TXT_COSTEFICIENCY);
			this.CheckBeda(LBL_A0116.Text,LBL_CA0116.Text,TXT_PARTYDEPENDENCY);

			//20081127 add by sofyan, for Qualitative Rating
			ViewCurrentQualitative();
			this.CheckBeda3(LBL_G0027_TEMP.Text,this.LBL_G0027.Text,LBL_G0027);
			this.CheckBeda3(LBL_A0901_TEMP.Text,this.LBL_A0901.Text,LBL_A0901);
		}

		private void resetForeColor()
		{
			TXT_OPERATING_CASHFLOW_TO_DEBT.ForeColor = System.Drawing.Color.Black;
			TXT_CURRENT_RATIO.ForeColor = System.Drawing.Color.Black;
			TXT_DEBT_TO_EQUITY.ForeColor = System.Drawing.Color.Black;
			TXT_DEBT_TO_ASSETS.ForeColor = System.Drawing.Color.Black;
			TXT_EBITDA_TO_INTEREST_EXPENSE.ForeColor = System.Drawing.Color.Black;
			TXT_RETURN_ON_AVERAGE_EQUITY.ForeColor = System.Drawing.Color.Black;
			TXT_NET_PROFIT_MARGIN.ForeColor = System.Drawing.Color.Black;
			TXT_ASSETS_TURN_OVER.ForeColor = System.Drawing.Color.Black;
			TXT_INVENTORY_TURN_OVER.ForeColor = System.Drawing.Color.Black;
			TXT_EBITDA_GROWTH.ForeColor = System.Drawing.Color.Black;
			TXT_NET_INCOME_GROWTH.ForeColor = System.Drawing.Color.Black;
			TXT_QUICK_RATIO.ForeColor = System.Drawing.Color.Black;
			TXT_DEBT_TO_CAPITAL.ForeColor = System.Drawing.Color.Black;
			TXT_LONG_TERM_DEBT_TO_EQUITY_LTD.ForeColor = System.Drawing.Color.Black;
			TXT_EBITDA_TO_DEBT.ForeColor = System.Drawing.Color.Black;
			TXT_EBITDA_TO_LIABILITIES.ForeColor = System.Drawing.Color.Black;
			TXT_RECEIVABLE_TURN_OVER.ForeColor = System.Drawing.Color.Black;
			TXT_FIXED_ASSETS_TURN_OVER.ForeColor = System.Drawing.Color.Black;
			TXT_OPERATING_MARGIN.ForeColor = System.Drawing.Color.Black;
			TXT_SALES_GROWTH.ForeColor = System.Drawing.Color.Black;
			TXT_RETURN_ON_AVERAGE_ASSETS.ForeColor = System.Drawing.Color.Black;
			TXT_OPERATING_CASHFLOW_TO_INTERESTEXPENSE.ForeColor = System.Drawing.Color.Black;

			RDO_AP_BLBIPERNAH.ForeColor = System.Drawing.Color.Black;
			RDO_LANCAR_LAST_12BLN.ForeColor = System.Drawing.Color.Black;
			RDO_PRIORRESULT_LOSS.ForeColor = System.Drawing.Color.Black;
			RDO_REVOLVING_NOW.ForeColor = System.Drawing.Color.Black;
			RDO_FULL_RECOVERY.ForeColor = System.Drawing.Color.Black;
			RDO_DEFAULT_LOSS.ForeColor = System.Drawing.Color.Black;

			TXT_EXPERIENCE.ForeColor = System.Drawing.Color.Black;
			TXT_INFODISCLOSURE.ForeColor = System.Drawing.Color.Black;
			TXT_COMPANYGROUP.ForeColor = System.Drawing.Color.Black;
			TXT_CAPITALSUPPORT.ForeColor = System.Drawing.Color.Black;

			TXT_MARKETSHARE.ForeColor = System.Drawing.Color.Black;
			TXT_PRODUCT_COMPETITIVENESS.ForeColor = System.Drawing.Color.Black;
			TXT_COSTEFICIENCY.ForeColor = System.Drawing.Color.Black;
			TXT_PARTYDEPENDENCY.ForeColor = System.Drawing.Color.Black;

			LBL_G0027.ForeColor = System.Drawing.Color.Black;
			LBL_A0901.ForeColor = System.Drawing.Color.Black;

		}

		private void loadCurrentData()
		{
			resetForeColor();
			//enableRDO(true);
			enableRDO(false);									//last agreed rule: payment history data can't be changed in this screen
			RDO_A0303ACCEPTCUSTRISKCLASS.SelectedValue = "1";
			RDO_A0303ACCEPTCUSTRISKCLASS.Enabled = false;		//set 'Y' for cust rating 

			enableRDOnew(false);
			resetRDOnew();

			LBL_CurentDataSta.Text = "";

			loadRatio("1");
			loadPay("1");
			loadMgt("1");
			loadBO("1");
		}

		private void loadRatio(string view )
		{
			// pilih tahun yang betul .... sudah salah !!!!!.. belom  betul.... (konfimasi ke Denny tdk bisa hr ini)
			conn.QueryString = "EXEC SCOREBCG_CUSTFINANCIALRATIO '" + Request.QueryString["regno"] + "', '" +
				Request.QueryString["curef"] + "'";		
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				//LBL_RATIO_PERIOD.Text = conn.GetFieldValue(0, "RATIO_PERIOD");
				//LBL_RATIO_TYPE.Text = conn.GetFieldValue(0, "RATIO_TYPE");
				LBL_RATIO_PERIOD.Text = conn.GetFieldValue(0, "DATE_PERIODE");
				LBL_RATIO_TYPE.Text = conn.GetFieldValue(0, "REPORTTYPE");

				if (view == "1")
				{

					TXT_OPERATING_CASHFLOW_TO_DEBT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_TO_DEBT"));
					TXT_CURRENT_RATIO.Text = tool.MoneyFormat(conn.GetFieldValue(0, "CURRENT_RATIO").ToString());
					TXT_CURRENT_RATIO.Text = tool.MoneyFormat(conn.GetFieldValue(0, "CURRENT_RATIO").ToString());
					TXT_DEBT_TO_EQUITY.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DEBT_EQUITY_RATIO"));
					TXT_DEBT_TO_ASSETS.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DEBT_TO_ASSETS"));
					TXT_EBITDA_TO_INTEREST_EXPENSE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_TO_INTERESTEXPENSE"));
					TXT_RETURN_ON_AVERAGE_EQUITY.Text = tool.MoneyFormat(conn.GetFieldValue(0, "RETURN_AVRG_EQUITY"));
					TXT_NET_PROFIT_MARGIN.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NET_PROFITMARGIN"));
					TXT_ASSETS_TURN_OVER.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ASSETS_TURNOVER"));
					TXT_INVENTORY_TURN_OVER.Text = tool.MoneyFormat(conn.GetFieldValue(0, "INVENTORY_TURNOVER"));
					TXT_EBITDA_GROWTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_GROWTH"));
					TXT_NET_INCOME_GROWTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NET_INCOME_GROWTH"));
					TXT_QUICK_RATIO.Text = tool.MoneyFormat(conn.GetFieldValue(0, "QUICK_ASSET_RATIO"));
					TXT_DEBT_TO_CAPITAL.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DEBT_TO_CAPITAL"));
					TXT_LONG_TERM_DEBT_TO_EQUITY_LTD.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LONGTERM_DEBT_TO_EQUITY"));
					TXT_EBITDA_TO_DEBT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_TO_DEBT"));
					TXT_EBITDA_TO_LIABILITIES.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_TO_LIABILITIES"));
					TXT_RECEIVABLE_TURN_OVER.Text = tool.MoneyFormat(conn.GetFieldValue(0, "RECEIVABLE_TURNOVER"));
					TXT_FIXED_ASSETS_TURN_OVER.Text = tool.MoneyFormat(conn.GetFieldValue(0, "FIXED_ASSETS_TURNOVER"));
					TXT_OPERATING_MARGIN.Text = tool.MoneyFormat(conn.GetFieldValue(0, "OPERATING_MARGIN"));
					TXT_SALES_GROWTH.Text = Devide100( conn.GetFieldValue(0, "SALES_GROWTH"));
					TXT_RETURN_ON_AVERAGE_ASSETS.Text = tool.MoneyFormat(conn.GetFieldValue(0, "RETURN_AVRG_ASSET"));
					TXT_OPERATING_CASHFLOW_TO_INTERESTEXPENSE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_TO_INTERESTEXPENSE"));
					
					TXT_NET_TRADE_CYCLE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NET_TRADE_CYCLE"));
					TXT_GEARING_RATIO.Text = tool.MoneyFormat(conn.GetFieldValue(0, "GEARING_RATIO"));
					TXT_NET_REVENUE_PER_MONTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NET_REVENUE_PERMONTH"));
					TXT_ACCOUNT_RECEIVABLE_TO_LIABILITIES.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ACCRECEIVABLE_TO_LIABILITIES"));
					TXT_EQUITY_TO_ASSET.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EQUITY_TO_ASSET"));
					TXT_ASSET_GROWTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ASSET_GROWTH"));
					TXT_EFICIENCY_RATIO.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EFICIENCY_RATIO"));
					TXT_TOTAL_ASSET.Text = tool.MoneyFormat(conn.GetFieldValue(0, "TOTAL_ASSET"));
					TXT_ACCOUNT_RECEIVABLE_TO_ASSET.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ACCRECEIVABLE_TO_ASSET"));
					TXT_RECEIVABLES_GROWTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "RECEIVABLES_GROWTH"));
					TXT_EQUITY_GROWTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EQUITY_GROWTH"));	
					TXT_NET_REVENUE_PER_MONTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NET_REVENUE_PERMONTH"));
					TXT_ROA.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ROA"));
					TXT_BUSINESS_DEBT_SERVICE_RATIO.Text = tool.MoneyFormat(conn.GetFieldValue(0, "BUSINESS_DEBT_SERV_RATIO"));
					TXT_SALES_TO_WORKING_CAPITAL.Text = tool.MoneyFormat(conn.GetFieldValue(0, "SALES_TO_WK_CAPITAL"));
					TXT_ASSET_GROWTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ASSET_GROWTH"));
					TXT_OPERATING_CASHFLOW_TO_INTERESTEXPENSE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_TO_INTERESTEXPENSE"));
					
					TXT_QUICK_RATIO_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "QUICK_ASSET_RATIO"));
					TXT_NET_INCOME_GROWTH_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NET_INCOME_GROWTH"));
					TXT_INVENTORY_TURN_OVER_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "INVENTORY_TURNOVER"));
					TXT_CURRENT_RATIO_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "CURRENT_RATIO"));
					TXT_DEBT_TO_EQUITY_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DEBT_EQUITY_RATIO"));
					TXT_EBITDA_TO_INTEREST_EXPENSE_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_TO_INTERESTEXPENSE"));
					TXT_ASSETS_TURN_OVER_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ASSETS_TURNOVER"));
					TXT_EBITDA_GROWTH_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_GROWTH"));
					TXT_DEBT_TO_ASSETS_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DEBT_TO_ASSETS"));
					TXT_RETURN_ON_AVERAGE_EQUITY_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "RETURN_AVRG_EQUITY"));
					TXT_NET_PROFIT_MARGIN_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NET_PROFITMARGIN"));
					TXT_DEBT_TO_CAPITAL_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DEBT_TO_CAPITAL"));
					TXT_LONG_TERM_DEBT_TO_EQUITY_LTD_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LONGTERM_DEBT_TO_EQUITY"));
					TXT_EBITDA_TO_DEBT_COPRPRATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_TO_DEBT"));
					TXT_EBITDA_TO_LIABILITIES_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA_TO_LIABILITIES"));
					TXT_RECEIVABLE_TURN_OVER_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "RECEIVABLE_TURNOVER"));
					TXT_FIXED_ASSETS_TURN_OVER_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "FIXED_ASSETS_TURNOVER"));
					TXT_OPERATING_MARGIN_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "OPERATING_MARGIN"));
					TXT_SALES_GROWTH_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "SALES_GROWTH"));
					TXT_RETURN_ON_AVERAGE_ASSETS_CORPORATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "RETURN_AVRG_ASSET"));
				
					/*belum muncul*/
					TXT_SALES_ON_CREDIT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "SALESONCREDIT"));
					TXT_SALES_GROWTH_RATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "SALES_GROWTH_RATE"));
					TXT_RETURN_ON_EQUITY.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ROE"));
					TXT_INTEREST_AVERAGE_BANK_DEBT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "INTEREST_AVEBANKDEBT"));
					TXT_SALES_AVERAGE_ASSET.Text = tool.MoneyFormat(conn.GetFieldValue(0, "SALES_AVEASSET"));
					TXT_DAYS_RECEIVABLE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DAYS_RECEIVABLE"));
					TXT_DAYS_INVENTORY.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DAYS_INVENTORY"));
					TXT_DAYS_PAYABLE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DAYS_PAYABLE"));
					TXT_DAYS_TRADE_CYCLE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DAYS_TC"));
					TXT_LONG_TERM_LEVERAGE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LONG_TERM_LVRG"));
					TXT_TIME_INTEREST_EARN.Text = tool.MoneyFormat(conn.GetFieldValue(0, "TIME_INTRST_EARN"));
					TXT_DEBT_SERVICE_COVERAGE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DEBT_SERV_COVERAGE"));
					TXT_COLLATERAL_COVERAGE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "COLLATERAL_COVERAGE"));
					TXT_NET_WORTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NET_WORTH"));
					TXT_RETURN_ON_INVESTMENT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ROI"));
					TXT_NET_PRESENT_VALUE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NPV"));
					TXT_INTEREST_RATE_OF_RETURN.Text = tool.MoneyFormat(conn.GetFieldValue(0, "IRR"));
					TXT_PAYBACK.Text = tool.MoneyFormat(conn.GetFieldValue(0, "PAYBACK"));
					TXT_EBITDA.Text = tool.MoneyFormat(conn.GetFieldValue(0, "EBITDA"));
					TXT_DEBT_TO_NETWORTH.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DEBT_TO_NETWORTH"));
					TXT_SALES_INCREASE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "SALES_INCREASE"));
					TXT_NET_INCOME_INCREASE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NETINCOME_INCREASE"));
					TXT_AVERAGE_NET_PROFIT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "AVERAGE_NETPROFIT"));
					TXT_NET_WORKING_CAPITAL.Text = tool.MoneyFormat(conn.GetFieldValue(0, "NET_WORKING_CAPITAL"));
					TXT_GROSS_PROFIT_MARGIN.Text = tool.MoneyFormat(conn.GetFieldValue(0, "GROSS_PROFIT_MARGIN"));
					TXT_OPERATIONAL_PROFIT_MARGIN.Text = tool.MoneyFormat(conn.GetFieldValue(0, "OPR_PROFIT_MARGIN"));
					TXT_TOTAL_EQUITY.Text = tool.MoneyFormat(conn.GetFieldValue(0, "TOTAL_EQUITY"));
					TXT_LEVERAGE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LEVERAGE"));
					TXT_LONGTERM_DEBT_TO_EQUITY.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LONGTERM_DEBT_TO_EQUITY"));
					TXT_INTEREST_COVERAGE_RATIO.Text = tool.MoneyFormat(conn.GetFieldValue(0, "INTEREST_COVERAGE_RATIO"));
					TXT_INTEREST_TO_SALES_RATIO.Text = tool.MoneyFormat(conn.GetFieldValue(0, "INTEREST_TO_SALES_RATIO"));
					TXT_DEBT_TO_EBITDA.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DEBT_TO_EBITDA"));
					TXT_DEBT_SERVICE_COVERAGE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "DSC"));
					TXT_ACCOUNT_PAYABLE_TURN_OVER.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ACCPAYABLE_TURNOVER"));
				}
				else if (view=="2")
				{
					LBL_CA0001.Text = conn.GetFieldValue(0, "EBITDA_TO_DEBT");
					LBL_CA0002.Text = conn.GetFieldValue(0, "CURRENT_RATIO").ToString();
					LBL_CA0003.Text = conn.GetFieldValue(0, "DEBT_EQUITY_RATIO");
					LBL_CA0004.Text = conn.GetFieldValue(0, "DEBT_TO_ASSETS");
					LBL_CA0005.Text = conn.GetFieldValue(0, "EBITDA_TO_INTERESTEXPENSE");
					LBL_CA0006.Text = conn.GetFieldValue(0, "RETURN_AVRG_EQUITY");
					LBL_CA0007.Text = conn.GetFieldValue(0, "NET_PROFITMARGIN");
					LBL_CA0008.Text = conn.GetFieldValue(0, "ASSETS_TURNOVER");
					LBL_CA0009.Text = conn.GetFieldValue(0, "INVENTORY_TURNOVER");
					LBL_CA0010.Text = conn.GetFieldValue(0, "EBITDA_GROWTH");
					LBL_CA0011.Text = conn.GetFieldValue(0, "NET_INCOME_GROWTH");
					LBL_CA0012.Text = conn.GetFieldValue(0, "QUICK_ASSET_RATIO");
					LBL_CA0013.Text = conn.GetFieldValue(0, "DEBT_TO_CAPITAL");
					LBL_CA0014.Text = conn.GetFieldValue(0, "LONGTERM_DEBT_TO_EQUITY");
					LBL_CA0015.Text = conn.GetFieldValue(0, "EBITDA_TO_DEBT");
					LBL_CA0016.Text = conn.GetFieldValue(0, "EBITDA_TO_LIABILITIES");
					LBL_CA0017.Text = conn.GetFieldValue(0, "RECEIVABLE_TURNOVER");
					LBL_CA0018.Text = conn.GetFieldValue(0, "FIXED_ASSETS_TURNOVER");
					LBL_CA0019.Text = conn.GetFieldValue(0, "OPERATING_MARGIN");
					LBL_CA0020.Text = Devide100(conn.GetFieldValue(0, "SALES_GROWTH"));
					LBL_CA0021.Text = conn.GetFieldValue(0, "RETURN_AVRG_ASSET");
					LBL_CA0022.Text = conn.GetFieldValue(0, "EBITDA_TO_INTERESTEXPENSE");

					LBL_CA0023.Text = conn.GetFieldValue(0, "NET_TRADE_CYCLE");
					LBL_CA0024.Text = conn.GetFieldValue(0, "GEARING_RATIO");
					LBL_CA0025.Text = conn.GetFieldValue(0, "NET_REVENUE_PERMONTH");
					LBL_CA0026.Text = conn.GetFieldValue(0, "ACCRECEIVABLE_TO_LIABILITIES");
					LBL_CA0027.Text = conn.GetFieldValue(0, "EQUITY_TO_ASSET");
					LBL_CA0028.Text = conn.GetFieldValue(0, "ASSET_GROWTH");
					LBL_CA0029.Text = conn.GetFieldValue(0, "EFICIENCY_RATIO");
					LBL_CA0030.Text = conn.GetFieldValue(0, "TOTAL_ASSET");
					LBL_CA0031.Text = conn.GetFieldValue(0, "ACCRECEIVABLE_TO_ASSET");
					LBL_CA0032.Text = conn.GetFieldValue(0, "RECEIVABLES_GROWTH");
					LBL_CA0033.Text = conn.GetFieldValue(0, "EQUITY_GROWTH");	
					LBL_CA0034.Text = conn.GetFieldValue(0, "NET_REVENUE_PERMONTH");
					LBL_CA0035.Text = conn.GetFieldValue(0, "ROA");
					LBL_CA0036.Text = conn.GetFieldValue(0, "BUSINESS_DEBT_SERV_RATIO");
					LBL_CA0037.Text = conn.GetFieldValue(0, "SALES_TO_WK_CAPITAL");
					LBL_CA0038.Text = conn.GetFieldValue(0, "ASSET_GROWTH");
					LBL_CA0039.Text = conn.GetFieldValue(0, "EBITDA_TO_INTERESTEXPENSE");
					
					LBL_CA0040.Text = conn.GetFieldValue(0, "QUICK_ASSET_RATIO");
					LBL_CA0041.Text = conn.GetFieldValue(0, "NET_INCOME_GROWTH");
					LBL_CA0042.Text = conn.GetFieldValue(0, "INVENTORY_TURNOVER");
					LBL_CA0043.Text = conn.GetFieldValue(0, "CURRENT_RATIO");
					LBL_CA0044.Text = conn.GetFieldValue(0, "DEBT_EQUITY_RATIO");
					LBL_CA0045.Text = conn.GetFieldValue(0, "EBITDA_TO_INTERESTEXPENSE");
					LBL_CA0046.Text = conn.GetFieldValue(0, "ASSETS_TURNOVER");
					LBL_CA0047.Text = conn.GetFieldValue(0, "EBITDA_GROWTH");
					LBL_CA0048.Text = conn.GetFieldValue(0, "DEBT_TO_ASSETS");
					LBL_CA0049.Text = conn.GetFieldValue(0, "RETURN_AVRG_EQUITY");
					LBL_CA0050.Text = conn.GetFieldValue(0, "NET_PROFITMARGIN");
					LBL_CA0051.Text = conn.GetFieldValue(0, "DEBT_TO_CAPITAL");
					LBL_CA0052.Text = conn.GetFieldValue(0, "LONGTERM_DEBT_TO_EQUITY");
					LBL_CA0053.Text = conn.GetFieldValue(0, "EBITDA_TO_DEBT");
					LBL_CA0054.Text = conn.GetFieldValue(0, "EBITDA_TO_LIABILITIES");
					LBL_CA0055.Text = conn.GetFieldValue(0, "RECEIVABLE_TURNOVER");
					LBL_CA0056.Text = conn.GetFieldValue(0, "FIXED_ASSETS_TURNOVER");
					LBL_CA0057.Text = conn.GetFieldValue(0, "OPERATING_MARGIN");
					LBL_CA0058.Text = conn.GetFieldValue(0, "SALES_GROWTH");
					LBL_CA0059.Text = conn.GetFieldValue(0, "RETURN_AVRG_ASSET");
			
					/*belum muncul*/
					LBL_CA0060.Text = conn.GetFieldValue(0, "SALESONCREDIT");
					LBL_CA0061.Text = conn.GetFieldValue(0, "SALES_GROWTH_RATE");
					LBL_CA0062.Text = conn.GetFieldValue(0, "ROE");
					LBL_CA0063.Text = conn.GetFieldValue(0, "INTEREST_AVEBANKDEBT");
					LBL_CA0064.Text = conn.GetFieldValue(0, "SALES_AVEASSET");
					LBL_CA0065.Text = conn.GetFieldValue(0, "DAYS_RECEIVABLE");
					LBL_CA0066.Text = conn.GetFieldValue(0, "DAYS_INVENTORY");
					LBL_CA0067.Text = conn.GetFieldValue(0, "DAYS_PAYABLE");
					LBL_CA0068.Text = conn.GetFieldValue(0, "DAYS_TC");
					LBL_CA0069.Text = conn.GetFieldValue(0, "LONG_TERM_LVRG");
					LBL_CA0070.Text = conn.GetFieldValue(0, "TIME_INTRST_EARN");
					LBL_CA0071.Text = conn.GetFieldValue(0, "DEBT_SERV_COVERAGE");
					LBL_CA0072.Text = conn.GetFieldValue(0, "COLLATERAL_COVERAGE");
					LBL_CA0073.Text = conn.GetFieldValue(0, "NET_WORTH");
					LBL_CA0074.Text = conn.GetFieldValue(0, "ROI");
					LBL_CA0075.Text = conn.GetFieldValue(0, "NPV");
					LBL_CA0076.Text = conn.GetFieldValue(0, "IRR");
					LBL_CA0077.Text = conn.GetFieldValue(0, "PAYBACK");
					LBL_CA0078.Text = conn.GetFieldValue(0, "EBITDA");
					LBL_CA0079.Text = conn.GetFieldValue(0, "DEBT_TO_NETWORTH");
					LBL_CA0080.Text = conn.GetFieldValue(0, "SALES_INCREASE");
					LBL_CA0081.Text = conn.GetFieldValue(0, "NETINCOME_INCREASE");
					LBL_CA0082.Text = conn.GetFieldValue(0, "AVERAGE_NETPROFIT");
					LBL_CA0083.Text = conn.GetFieldValue(0, "NET_WORKING_CAPITAL");
					LBL_CA0084.Text = conn.GetFieldValue(0, "GROSS_PROFIT_MARGIN");
					LBL_CA0085.Text = conn.GetFieldValue(0, "OPR_PROFIT_MARGIN");
					LBL_CA0086.Text = conn.GetFieldValue(0, "TOTAL_EQUITY");
					LBL_CA0087.Text = conn.GetFieldValue(0, "LEVERAGE");
					LBL_CA0088.Text = conn.GetFieldValue(0, "LONGTERM_DEBT_TO_EQUITY");
					LBL_CA0089.Text = conn.GetFieldValue(0, "INTEREST_COVERAGE_RATIO");
					LBL_CA0090.Text = conn.GetFieldValue(0, "INTEREST_TO_SALES_RATIO");
					LBL_CA0091.Text = conn.GetFieldValue(0, "DEBT_TO_EBITDA");
					LBL_CA0092.Text = conn.GetFieldValue(0, "DSC");
					LBL_CA0093.Text = conn.GetFieldValue(0, "ACCPAYABLE_TURNOVER");

					/*LBL_CA023.Text = Devide100(conn.GetFieldValue(0, "NET_TRADE_CYCLE").ToString());
					LBL_CA024.Text = Devide100(conn.GetFieldValue(0, "GEARING_RATIO").ToString());
					LBL_CA025.Text = Devide100(conn.GetFieldValue(0, "NET_REVENUE_PERMONTH").ToString());
					LBL_CA026.Text = Devide100(conn.GetFieldValue(0, "ACCRECEIVABLE_TO_ASSET").ToString());
					LBL_CA027.Text = Devide100(conn.GetFieldValue(0, "ACCRECEIVABLE_TO_LIABILITIES").ToString());
					LBL_CA028.Text = Devide100(conn.GetFieldValue(0, "EQUITY_TO_ASSET").ToString());
					LBL_CA029.Text = Devide100(conn.GetFieldValue(0, "ASSET_GROWTH").ToString());
					LBL_CA030.Text = Devide100(conn.GetFieldValue(0, "RECEIVABLES_GROWTH").ToString());
					LBL_CA031.Text = Devide100(conn.GetFieldValue(0, "EQUITY_GROWTH").ToString());
					LBL_CA032.Text = Devide100(conn.GetFieldValue(0, "EFICIENCY_RATIO").ToString());
					LBL_CA033.Text = Devide100(conn.GetFieldValue(0, "TOTAL_ASSET").ToString());*/
				}
			}
			else
			{//current ratio has not been filled in
				LBL_CurentDataSta.Text += "Ratio data is not complete. " + (char)13 + (char)10;
				LBL_STA1.Text = "1";
			}
		}

		private void loadPay(string view )
		{
			if (view == "1")
			{
				conn.QueryString = "select CI_BMGIRO,CI_BMSAVING,CI_BMDEBITUR from  VW_DE_HUBUNGANBANK " +
					"where CU_REF ='" + Request.QueryString["curef"]+ "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0)
				{
					//if (conn.GetFieldValue("CI_BMGIRO")!="" || conn.GetFieldValue("CI_BMSAVING")!="" || conn.GetFieldValue("CI_BMSAVING")!="")
					if (conn.GetFieldValue("CI_BMDEBITUR")!="")
						this.RDO_CU_PERNAHJDNASABAHBM.SelectedValue		= "1";
					else
						this.RDO_CU_PERNAHJDNASABAHBM.SelectedValue		= "0";
				}
				else
				{
					LBL_CurentDataSta.Text += "Hubungan Dengan Bank data is not complete. " + (char)13 + (char)10;
					LBL_STA2.Text = "1";
				}
				conn.QueryString = "select * from VW_SCORINGBCG_PAYMENTCATEGORY where AP_REGNO = '" + Request.QueryString["regno"] + "' AND " +
					"AP_REGNO = '" + Request.QueryString["regno"]+ "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0) 
				{
					this.RDO_AP_BLBIPERNAH.SelectedValue			= conn.GetFieldValue("AP_BLPERNAH");
					this.RDO_DEFAULT_LOSS.SelectedValue				= conn.GetFieldValue("DEFAULT_LOSS");
					this.RDO_FULL_RECOVERY.SelectedValue			= conn.GetFieldValue("FULL_RECOVERY");
					this.RDO_LANCAR_LAST_12BLN.SelectedValue		= conn.GetFieldValue("LANCAR_LAST_12BLN");
					this.RDO_PRIORRESULT_LOSS.SelectedValue			= conn.GetFieldValue("PRIORRESULT_LOSS");
					this.RDO_REVOLVING_NOW.SelectedValue			= conn.GetFieldValue("REVOLVING_NOW");
				}
				else
				{
					LBL_CurentDataSta.Text += "Payment Category data is not complete. " + (char)13 + (char)10;
					LBL_STA3.Text = "1";
				}
			} 
			else if (view== "2")
			{
				conn.QueryString = "select CI_BMGIRO,CI_BMSAVING,CI_BMDEBITUR from  VW_DE_HUBUNGANBANK " +
					"where CU_REF ='" + Request.QueryString["curef"]+ "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue("CI_BMGIRO")!="" || conn.GetFieldValue("CI_BMSAVING")!="" || conn.GetFieldValue("CI_BMSAVING")!="")
					LBL_CA0101.Text		= "1";
				else
					LBL_CA0101.Text		= "0";

				conn.QueryString = "select * from VW_SCORINGBCG_PAYMENTCATEGORY where AP_REGNO = '" + Request.QueryString["regno"] + "' AND " +
					"AP_REGNO = '" + Request.QueryString["regno"]+ "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0) 
				{
					LBL_CA0102.Text			= conn.GetFieldValue("AP_BLPERNAH");
					LBL_CA0103.Text			= conn.GetFieldValue("LANCAR_LAST_12BLN");
					LBL_CA0104.Text			= conn.GetFieldValue("PRIORRESULT_LOSS");
					LBL_CA0105.Text			= conn.GetFieldValue("REVOLVING_NOW");
					LBL_CA0106.Text			= conn.GetFieldValue("FULL_RECOVERY");
					LBL_CA0107.Text			= conn.GetFieldValue("DEFAULT_LOSS");
				}
			}

		}

		private void loadMgt(string view)
		{
			if (view == "1")
			{
				conn.QueryString = "select * from VW_SCORINGBCG_EXPERIENCE where AP_REGNO ='" +
					Request.QueryString["regno"] + "' ";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0)
				{
					this.TXT_EXPERIENCE.Text		= conn.GetFieldValue("DES");
					this.LBL_A0109.Text				= conn.GetFieldValue("NILAI");
					conn.QueryString = "select * from  VW_SCORINGBCG_INFODISCLOSURE where AP_REGNO ='" +
						Request.QueryString["regno"] + "' ";
					conn.ExecuteQuery();
					this.TXT_INFODISCLOSURE.Text	= conn.GetFieldValue("DES");
					this.LBL_A0110.Text				= conn.GetFieldValue("NILAI");
					conn.QueryString = "select * from VW_SCORINGBCG_COMPANYGROUP where AP_REGNO ='" +
						Request.QueryString["regno"] + "' ";
					conn.ExecuteQuery();
					this.TXT_COMPANYGROUP.Text		= conn.GetFieldValue("DES");
					this.LBL_A0111.Text				= conn.GetFieldValue("NILAI");
					conn.QueryString = "select * from VW_SCORINGBCG_CAPITALSUPPORT where AP_REGNO ='" +
						Request.QueryString["regno"] + "' ";
					conn.ExecuteQuery();
					this.TXT_CAPITALSUPPORT.Text	= conn.GetFieldValue("DES");
					this.LBL_A0112.Text				= conn.GetFieldValue("NILAI");
				}
				else
				{
					//20080122 remark by sofyan, old rating is not used anymore
					//LBL_CurentDataSta.Text += "Management Quality data is not complete. " + (char)13 + (char)10;
					//LBL_STA4.Text = "1";
				}
			} 
			else if (view =="2")
			{
				conn.QueryString = "select * from VW_SCORINGBCG_EXPERIENCE where AP_REGNO ='" +
					Request.QueryString["regno"] + "' ";
				conn.ExecuteQuery();
				LBL_CA0109.Text = conn.GetFieldValue("NILAI");
				conn.QueryString = "select * from  VW_SCORINGBCG_INFODISCLOSURE where AP_REGNO ='" +
					Request.QueryString["regno"] + "' ";
				conn.ExecuteQuery();
				LBL_CA0110.Text = conn.GetFieldValue("NILAI");
				conn.QueryString = "select * from VW_SCORINGBCG_COMPANYGROUP where AP_REGNO ='" +
					Request.QueryString["regno"] + "' ";
				conn.ExecuteQuery();
				LBL_CA0111.Text = conn.GetFieldValue("NILAI");
				conn.QueryString = "select * from VW_SCORINGBCG_CAPITALSUPPORT where AP_REGNO ='" +
					Request.QueryString["regno"] + "' ";
				conn.ExecuteQuery();
				LBL_CA0112.Text = conn.GetFieldValue("NILAI");
			
			}
			else
			{
				conn.QueryString = "select * from VW_SCORINGBCG_EXPERIENCE where AP_REGNO ='" +
					Request.QueryString["regno"] + "' and NILAI ='" +this.LBL_A0109.Text+ "'";
				conn.ExecuteQuery();
				this.TXT_EXPERIENCE.Text		= conn.GetFieldValue("DES");
				conn.QueryString = "select * from  VW_SCORINGBCG_INFODISCLOSURE where AP_REGNO ='" +
					Request.QueryString["regno"] + "' AND NILAI ='" + this.LBL_A0110.Text + "'";
				conn.ExecuteQuery();
				this.TXT_INFODISCLOSURE.Text	= conn.GetFieldValue("DES");
				conn.QueryString = "select * from VW_SCORINGBCG_COMPANYGROUP where AP_REGNO ='" +
					Request.QueryString["regno"] + "' AND NILAI ='" + this.LBL_A0111.Text	+ "'";
				conn.ExecuteQuery();
				this.TXT_COMPANYGROUP.Text		= conn.GetFieldValue("DES");
				conn.QueryString = "select * from VW_SCORINGBCG_CAPITALSUPPORT where AP_REGNO ='" +
					Request.QueryString["regno"] + "' AND NILAI ='" + this.LBL_A0112.Text + "'";
				conn.ExecuteQuery();
				this.TXT_CAPITALSUPPORT.Text	= conn.GetFieldValue("DES");
			}
			
		}

		private void loadBO(string view)
		{
			if (view == "1")
			{
				conn.QueryString = "select * from VW_SCORINGBCG_MARKETSHARE where AP_REGNO ='" +
					Request.QueryString["regno"] + "' ";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0)
				{
					this.TXT_MARKETSHARE.Text				= conn.GetFieldValue("DES");
					this.LBL_A0113.Text						= conn.GetFieldValue("NILAI");
					conn.QueryString = "select * from VW_SCORINGBCG_PRODUCTCOMPETITIVENESS where AP_REGNO ='" +
						Request.QueryString["regno"] + "' ";
					conn.ExecuteQuery();
					this.TXT_PRODUCT_COMPETITIVENESS.Text	= conn.GetFieldValue("DES");
					this.LBL_A0114.Text						= conn.GetFieldValue("NILAI");
					conn.QueryString = "select * from VW_SCORINGBCG_COSTEFICIENCY where AP_REGNO ='" +
						Request.QueryString["regno"] + "' ";
					conn.ExecuteQuery();
					this.TXT_COSTEFICIENCY.Text				= conn.GetFieldValue("DES");
					this.LBL_A0115.Text						= conn.GetFieldValue("NILAI");
					conn.QueryString = "select * from VW_SCORINGBCG_PARTYDEPENDENCY where AP_REGNO ='" +
						Request.QueryString["regno"] + "' ";
					conn.ExecuteQuery();
					this.TXT_PARTYDEPENDENCY.Text			= conn.GetFieldValue("DES");
					this.LBL_A0116.Text						= conn.GetFieldValue("NILAI");
				}
				else
				{
					//20080122 remark by sofyan, old rating is not used anymore
					//LBL_CurentDataSta.Text += "Business Outlook data is not complete. " + (char)13 + (char)10;
					//LBL_STA5.Text = "1";
				}
			} 
			else
				if(view == "2")
			{
				conn.QueryString = "select * from VW_SCORINGBCG_MARKETSHARE where AP_REGNO ='" +
					Request.QueryString["regno"] + "' ";
				conn.ExecuteQuery();
				LBL_CA0113.Text = conn.GetFieldValue("NILAI");
				conn.QueryString = "select * from VW_SCORINGBCG_PRODUCTCOMPETITIVENESS where AP_REGNO ='" +
					Request.QueryString["regno"] + "' ";
				conn.ExecuteQuery();
				LBL_CA0114.Text = conn.GetFieldValue("NILAI");
				conn.QueryString = "select * from VW_SCORINGBCG_COSTEFICIENCY where AP_REGNO ='" +
					Request.QueryString["regno"] + "' ";
				conn.ExecuteQuery();
				LBL_CA0115.Text = conn.GetFieldValue("NILAI");
				conn.QueryString = "select * from VW_SCORINGBCG_PARTYDEPENDENCY where AP_REGNO ='" +
					Request.QueryString["regno"] + "' ";
				conn.ExecuteQuery();
				LBL_CA0116.Text = conn.GetFieldValue("NILAI");
			}
			else
			{
				conn.QueryString = "select * from VW_SCORINGBCG_MARKETSHARE where AP_REGNO ='" +
					Request.QueryString["regno"] + "' and NILAI ='" + this.LBL_A0113.Text	 + "'";
				conn.ExecuteQuery();
				this.TXT_MARKETSHARE.Text				= conn.GetFieldValue("DES");
				conn.QueryString = "select * from VW_SCORINGBCG_PRODUCTCOMPETITIVENESS where AP_REGNO ='" +
					Request.QueryString["regno"] + "' and NILAI ='" + this.LBL_A0114.Text + "'";
				conn.ExecuteQuery();
				this.TXT_PRODUCT_COMPETITIVENESS.Text	= conn.GetFieldValue("DES");
				conn.QueryString = "select * from VW_SCORINGBCG_COSTEFICIENCY where AP_REGNO ='" +
					Request.QueryString["regno"] + "' and NILAI ='" + this.LBL_A0115.Text + "'";
				conn.ExecuteQuery();
				this.TXT_COSTEFICIENCY.Text				= conn.GetFieldValue("DES");
				conn.QueryString = "select * from VW_SCORINGBCG_PARTYDEPENDENCY where AP_REGNO ='" +
					Request.QueryString["regno"] + "' and NILAI ='" +this.LBL_A0116.Text+ "'";
				conn.ExecuteQuery();
				this.TXT_PARTYDEPENDENCY.Text			= conn.GetFieldValue("DES");
			}
		}

		private void Adjustment()
		{
			/*
			if (this.RDO_A0303ACCEPTCUSTRISKCLASS.SelectedValue == "1")
			{
				LBL_A1003.Text	= LBL_A1002.Text;
			}
			else
			{
				LBL_A1003.Text	= LBL_0A602.Text;
			}
			*/
			conn.QueryString = "exec SCOREBCG_ADJUSTMENT '" + Request.QueryString["regno"] + "', " +
				LBL_SCOREBCG_SEQ.Text + ", '" + RDO_A0303ACCEPTCUSTRISKCLASS.SelectedValue + "' ";
			conn.ExecuteQuery();
			try
			{
				LBL_A1003.Text = conn.GetFieldValue(0,0);
				LBL_A1004.Text = conn.GetFieldValue(0,1);
			}
			catch
			{
				GlobalTools.popMessage(this, "Failed executing query");
			}
		}

		private void GetCode()
		{
			/* Ket Code untuk Customer... diisi null
			 * Net collateral(A0301) = 1 (>0)
			 * Facility Value(A0302) = 1 (>0)
			 */
			this.LBL_KET_CODE.Text			= "NULL";
			this.LBL_NETCOLLATERAL.Text		= "1";
			this.LBL_FACILITY.Text			= "1";
		}

		private void GetInputMedianExtreme()
		{
			//Median Value
			conn.QueryString = "select * from SCOREBCG_DUMMYVAL where BCG_DV_ID = '1'";
			conn.ExecuteQuery();
			TA0401 = conn.GetFieldValue("OPERATING_CASHFLOW_TO_DEBT");
			TA0402 = conn.GetFieldValue("CURRENT_RATIO");
			TA0403 = conn.GetFieldValue("DEBT_TO_EQUITY");
			TA0404 = conn.GetFieldValue("DEBT_TO_ASSETS");
			TA0405 = conn.GetFieldValue("EBITDA_TO_INTERESTEXPENSE");
			TA0406 = conn.GetFieldValue("RETURN_ON_AVERAGE_EQUITY");
			TA0407 = conn.GetFieldValue("NET_MARGIN");
			TA0408 = conn.GetFieldValue("ASSETS_TURNOVER");
			TA0409 = conn.GetFieldValue("INVENTORY_TURNOVER");
			TA0410 = conn.GetFieldValue("EBITDA_GROWTH");
			TA0411 = conn.GetFieldValue("NET_INCOME_GROWTH");
			TA0412 = conn.GetFieldValue("QUICK_RATIO");
			TA0413 = conn.GetFieldValue("DEBT_TO_CAPITAL");
			TA0414 = conn.GetFieldValue("LONGTERM_DEBT_TO_EQUITY");
			TA0415 = conn.GetFieldValue("EBITDA_TO_DEBT");
			TA0416 = conn.GetFieldValue("EBITDA_TO_LIABILITIES");
			TA0417 = conn.GetFieldValue("RECEIVABLE_TURNOVER");
			TA0418 = conn.GetFieldValue("FIXED_ASSETS_TURNOVER");
			TA0419 = conn.GetFieldValue("OPERATING_MARGIN");
			TA0420 = conn.GetFieldValue("SALES_GROWTH");
			TA0421 = conn.GetFieldValue("RETURN_ON_AVERAGE_ASSETS");
			TA0422 = conn.GetFieldValue("OPERATING_CASHFLOW_TO_INTERESTEXPENSE");
			//Extreme Value
			conn.QueryString = "select * from SCOREBCG_DUMMYVAL where BCG_DV_ID = '2'";
			conn.ExecuteQuery();
			TA0423 = conn.GetFieldValue("OPERATING_CASHFLOW_TO_DEBT");
			TA0424 = conn.GetFieldValue("CURRENT_RATIO");
			TA0425 = conn.GetFieldValue("DEBT_TO_EQUITY");
			TA0426 = conn.GetFieldValue("DEBT_TO_ASSETS");
			TA0427 = conn.GetFieldValue("EBITDA_TO_INTERESTEXPENSE");
			TA0428 = conn.GetFieldValue("RETURN_ON_AVERAGE_EQUITY");
			TA0429 = conn.GetFieldValue("NET_MARGIN");
			TA0430 = conn.GetFieldValue("ASSETS_TURNOVER");
			TA0431 = conn.GetFieldValue("INVENTORY_TURNOVER");
			TA0432 = conn.GetFieldValue("EBITDA_GROWTH");
			TA0433 = conn.GetFieldValue("NET_INCOME_GROWTH");
			TA0434 = conn.GetFieldValue("QUICK_RATIO");
			TA0435 = conn.GetFieldValue("DEBT_TO_CAPITAL");
			TA0436 = conn.GetFieldValue("LONGTERM_DEBT_TO_EQUITY");
			TA0437 = conn.GetFieldValue("EBITDA_TO_DEBT");
			TA0438 = conn.GetFieldValue("EBITDA_TO_LIABILITIES");
			TA0439 = conn.GetFieldValue("RECEIVABLE_TURNOVER");
			TA0440 = conn.GetFieldValue("FIXED_ASSETS_TURNOVER");
			TA0441 = conn.GetFieldValue("OPERATING_MARGIN");
			TA0442 = conn.GetFieldValue("SALES_GROWTH");
			TA0443 = conn.GetFieldValue("RETURN_ON_AVERAGE_ASSETS");
			TA0444 = conn.GetFieldValue("OPERATING_CASHFLOW_TO_INTERESTEXPENSE");
			
			TA0502 = "";
			TA0503 = "";

		}

		private void UpdatePaymentCategory()
		{
			conn.QueryString = "exec SCOREBCG_PAYMENTCATEGORY_UPDATE '" + Request.QueryString["regno"] +
				"', '" + RDO_AP_BLBIPERNAH.SelectedValue + "', '" + RDO_DEFAULT_LOSS.SelectedValue +
				"', '" + RDO_FULL_RECOVERY.SelectedValue + "', '" + RDO_LANCAR_LAST_12BLN.SelectedValue +
				"', '" + RDO_PRIORRESULT_LOSS.SelectedValue + "', '" + RDO_REVOLVING_NOW.SelectedValue + "' ";
			conn.ExecuteNonQuery();
		}

		private bool cekMandatory()
		{
			if (this.LBL_STA1.Text == "1" || /*this.LBL_STA2.Text == "1" ||*/ this.LBL_STA3.Text == "1" /*|| this.LBL_STA4.Text =="1" || this.LBL_STA5.Text=="1"*/)
			{
				if (this.LBL_STA1.Text == "1")
					str = "Ratio, ";
				/*if (this.LBL_STA2.Text == "1")
					str += "Hubungan dengan bank, ";*/
				if (this.LBL_STA3.Text == "1")
					str += "Payment Category, ";
				//20080122 remark by sofyan, old rating is not used anymore
				/*if (this.LBL_STA4.Text == "1")
					str += "Management Quality, ";
				if (this.LBL_STA5.Text == "1")
					str += "Business Outlook, ";*/
				str += "is not complete.";
				GlobalTools.popMessage(this, str);
				return false;
			}
			//20081126 remark by sofyan, industrial code is not used anymore
			/*if (DDL_INDCODE.SelectedValue == "")
			{
				GlobalTools.popMessage(this, "Industrial Code belum diisi.");
				return false;
			}*/
			return true;
		}

		private void SaveInputRating()
		{
			//update Payment Category fields in case changed by user 
			//UpdatePaymentCategory();

			/**
			 * data-data yang disimpan ke dalam table scorebcg_input
			 * Data Type-nya belum sesuai data Dictionary
			 * sehingga sebelum dikirim ke STW harus dikonversi dulu
			 * 
			 * */
			GetCode();

			GetInputMedianExtreme();
			conn.QueryString = "exec SCOREBCG_INPUT_SAVE '" + Request.QueryString["regno"] + "','" + 
				Request.QueryString["curef"] + "'," +this.LBL_KET_CODE.Text+ "," + 
				//A0001-A0022
				GlobalTools.ConvertFloat(Multiply100(this.TXT_OPERATING_CASHFLOW_TO_DEBT.Text)) + "," + GlobalTools.ConvertFloat(Multiply100(this.TXT_CURRENT_RATIO.Text))+ "," + 
				GlobalTools.ConvertFloat(Multiply100(this.TXT_DEBT_TO_EQUITY.Text)) + "," + GlobalTools.ConvertFloat(Multiply100(this.TXT_DEBT_TO_ASSETS.Text)) + "," + 
				GlobalTools.ConvertFloat(Multiply100(this.TXT_EBITDA_TO_INTEREST_EXPENSE.Text)) + "," + GlobalTools.ConvertFloat(Multiply100(this.TXT_RETURN_ON_AVERAGE_EQUITY.Text)) + "," + 
				GlobalTools.ConvertFloat(Multiply100(this.TXT_NET_PROFIT_MARGIN.Text)) + "," + GlobalTools.ConvertFloat(Multiply100(this.TXT_ASSETS_TURN_OVER.Text)) + "," + 
				GlobalTools.ConvertFloat(Multiply100(this.TXT_INVENTORY_TURN_OVER.Text)) + "," + GlobalTools.ConvertFloat(Multiply100(this.TXT_EBITDA_GROWTH.Text))	 + "," + 
				GlobalTools.ConvertFloat(Multiply100(this.TXT_NET_INCOME_GROWTH.Text)) + "," + GlobalTools.ConvertFloat(Multiply100(this.TXT_QUICK_RATIO.Text)) + "," + 
				GlobalTools.ConvertFloat(Multiply100(this.TXT_DEBT_TO_CAPITAL.Text)) + "," + GlobalTools.ConvertFloat(Multiply100(this.TXT_LONG_TERM_DEBT_TO_EQUITY_LTD.Text)) + "," + 
				GlobalTools.ConvertFloat(Multiply100(this.TXT_EBITDA_TO_DEBT.Text)) + "," + GlobalTools.ConvertFloat(Multiply100(this.TXT_EBITDA_TO_LIABILITIES.Text)) + "," + 
				GlobalTools.ConvertFloat(Multiply100(this.TXT_RECEIVABLE_TURN_OVER.Text)) + "," + GlobalTools.ConvertFloat(Multiply100(this.TXT_FIXED_ASSETS_TURN_OVER.Text)) + "," + 
				GlobalTools.ConvertFloat(Multiply100(this.TXT_OPERATING_MARGIN.Text)) + "," + GlobalTools.ConvertFloat(Multiply100(this.TXT_SALES_GROWTH.Text)) + "," + 
				GlobalTools.ConvertFloat(Multiply100(this.TXT_RETURN_ON_AVERAGE_ASSETS.Text)) + "," + GlobalTools.ConvertFloat(Multiply100(this.TXT_OPERATING_CASHFLOW_TO_INTERESTEXPENSE.Text)) + ",'" + 
				//A0101-A0108 
				this.RDO_CU_PERNAHJDNASABAHBM.SelectedValue + "','" + this.RDO_AP_BLBIPERNAH.SelectedValue + "','" +
				this.RDO_LANCAR_LAST_12BLN.SelectedValue + "','" + this.RDO_PRIORRESULT_LOSS.SelectedValue + "','" +
				this.RDO_REVOLVING_NOW.SelectedValue + "','" + this.RDO_AP_BLBIPERNAH.SelectedValue + "','" +
				this.RDO_FULL_RECOVERY.SelectedValue + "','" + this.RDO_DEFAULT_LOSS.SelectedValue + "','" +
				//A0109-A1016
				this.LBL_A0109.Text.Trim()+ "','" + this.LBL_A0110.Text.Trim() + "','" + 
				this.LBL_A0111.Text.Trim() + "','" + this.LBL_A0112.Text.Trim() + "','" + 
				this.LBL_A0113.Text.Trim() + "','" + this.LBL_A0114.Text.Trim() + "','" +
				this.LBL_A0115.Text.Trim() + "','" + this.LBL_A0116.Text.Trim() + "','" +
				//A0201,A0301,A0302,A0303 .... Industrial Code(A0201)
				//this.LBL_INDUSTRIALCODE.Text + "'," +		----> change to the following: 
				this.DDL_INDCODE.SelectedValue + "'," + 
				GlobalTools.ConvertFloat(this.LBL_NETCOLLATERAL.Text) + ","+ GlobalTools.ConvertFloat(this.LBL_FACILITY.Text) + ",'" +
				this.RDO_A0303ACCEPTCUSTRISKCLASS.SelectedValue + "'," +
				//A0401-A0444 ************* RESULT ************************
				GlobalTools.ConvertFloat(TA0401)  + "," + GlobalTools.ConvertFloat(TA0402)  + "," + 
				GlobalTools.ConvertFloat(TA0403)  + "," + GlobalTools.ConvertFloat(TA0404)  + "," + 
				GlobalTools.ConvertFloat(TA0405)  + "," + GlobalTools.ConvertFloat(TA0406)  + "," + 
				GlobalTools.ConvertFloat(TA0407)  + "," + GlobalTools.ConvertFloat(TA0408)  + "," + 
				GlobalTools.ConvertFloat(TA0409)  + "," + GlobalTools.ConvertFloat(TA0410)  + "," + 
				GlobalTools.ConvertFloat(TA0411)  + "," + GlobalTools.ConvertFloat(TA0412)  + "," + 
				GlobalTools.ConvertFloat(TA0413)  + "," + GlobalTools.ConvertFloat(TA0414)  + "," + 
				GlobalTools.ConvertFloat(TA0415)  + "," + GlobalTools.ConvertFloat(TA0416)  + "," + 
				GlobalTools.ConvertFloat(TA0417)  + "," + GlobalTools.ConvertFloat(TA0418)  + "," + 
				GlobalTools.ConvertFloat(TA0419)  + "," + GlobalTools.ConvertFloat(TA0420)  + "," + 
				GlobalTools.ConvertFloat(TA0421)  + "," + GlobalTools.ConvertFloat(TA0422)  + "," + 
				GlobalTools.ConvertFloat(TA0423)  + "," + GlobalTools.ConvertFloat(TA0424)  + "," + 
				GlobalTools.ConvertFloat(TA0425)  + "," + GlobalTools.ConvertFloat(TA0426)  + "," + 
				GlobalTools.ConvertFloat(TA0427)  + "," + GlobalTools.ConvertFloat(TA0428)  + "," + 
				GlobalTools.ConvertFloat(TA0429)  + "," + GlobalTools.ConvertFloat(TA0430)  + "," + 
				GlobalTools.ConvertFloat(TA0431)  + "," + GlobalTools.ConvertFloat(TA0432)  + "," + 
				GlobalTools.ConvertFloat(TA0433)  + "," + GlobalTools.ConvertFloat(TA0434)  + "," + 
				GlobalTools.ConvertFloat(TA0435)  + "," + GlobalTools.ConvertFloat(TA0436)  + "," + 
				GlobalTools.ConvertFloat(TA0437)  + "," + GlobalTools.ConvertFloat(TA0438)  + "," + 
				GlobalTools.ConvertFloat(TA0439)  + "," + GlobalTools.ConvertFloat(TA0440)  + "," + 
				GlobalTools.ConvertFloat(TA0441)  + "," + GlobalTools.ConvertFloat(TA0442)  + "," + 
				GlobalTools.ConvertFloat(TA0443)  + "," + GlobalTools.ConvertFloat(TA0444)  + ",'" +
				GlobalTools.ConvertFloat(TA0502)  + "','" + GlobalTools.ConvertFloat(TA0503)  + "',NULL,0" +
				"," + GlobalTools.ToSQLDate(LBL_RATIO_PERIOD.Text) + "," + GlobalTools.ConvertNull(LBL_RATIO_TYPE.Text) + "," +
				GlobalTools.ConvertFloat(Multiply100(this.TXT_NET_TRADE_CYCLE.Text)) + "," +
				GlobalTools.ConvertFloat(Multiply100(this.TXT_GEARING_RATIO.Text)) + "," +
				GlobalTools.ConvertFloat(Multiply100(this.TXT_NET_REVENUE_PER_MONTH.Text)) + "," +
				GlobalTools.ConvertFloat(Multiply100(this.TXT_ACCOUNT_RECEIVABLE_TO_ASSET.Text)) + "," +
				GlobalTools.ConvertFloat(Multiply100(this.TXT_ACCOUNT_RECEIVABLE_TO_LIABILITIES.Text)) + "," +
				GlobalTools.ConvertFloat(Multiply100(this.TXT_EQUITY_TO_ASSET.Text)) + "," +
				GlobalTools.ConvertFloat(Multiply100(this.TXT_ASSET_GROWTH.Text)) + "," +
				GlobalTools.ConvertFloat(Multiply100(this.TXT_RECEIVABLES_GROWTH.Text)) + "," +
				GlobalTools.ConvertFloat(Multiply100(this.TXT_EQUITY_GROWTH.Text)) + "," +
				GlobalTools.ConvertFloat(Multiply100(this.TXT_EFICIENCY_RATIO.Text)) + "," +
				GlobalTools.ConvertFloat(Multiply100(this.TXT_TOTAL_ASSET.Text));

			string abc = conn.QueryString;
			conn.ExecuteNonQuery();

			conn.QueryString = "select TOP 1 SEQ from VW_SCOREBCG_INPUTCUSTRATING where CU_REF ='" +
				Request.QueryString["curef"] + "' order by RATEDATE desc";
			conn.ExecuteQuery();
			LBL_SCOREBCG_SEQ.Text = conn.GetFieldValue(0,0);
		}

		private void setButtonsStatus()
		{
			conn.QueryString = "exec SCOREBCG_SETBUTTON '" + Request.QueryString["regno"] + "', 'C' ";
			conn.ExecuteQuery();
			btnUpdateStatus.Enabled = false;
			btnRate.Enabled = false;
			try
			{
				if(conn.GetFieldValue(0,"UPDBTNSTA") == "1")
					btnUpdateStatus.Enabled = true;
				if(conn.GetFieldValue(0,"RATEBTNSTA") == "1")
					btnRate.Enabled = true;
				if(conn.GetFieldValue(0,"MSG") != "")
					GlobalTools.popMessage(this, conn.GetFieldValue(0,"MSG"));
			} 
			catch {}
		}

		protected void btnRate_Click(object sender, System.EventArgs e)
		{
			clsBCGScoring bcg = new clsBCGScoring(conn);

			try 
			{
				/// Log Audit trail tracking application
				/// 
				conn.QueryString = "exec SP_AUDITTRAIL_APP '" + 
					Request.QueryString["regno"] + "', NULL, NULL, NULL, '" + 
					Request.QueryString["curef"] + "', '" + 
					Request.QueryString["tc"] + "', " + 
					"'Send Rating Message to STW (BCG Rating)', NULL, '" + 
					Session["UserID"].ToString() + "', NULL, 'N', NULL";
				conn.ExecuteNonQuery();
			} 
			catch (Exception ex)
			{
				ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, Request.QueryString["regno"]);
				Response.Write("<!-- " + ex.ToString() + " -->");
                GlobalTools.popMessage(this, ex.Message);
			}

			if(this.btnRate.Text == "Re-Rate")
			{
				btnRate.Text = "Rate";
				loadCurrentData(); 
				this.ClearResponse();
				return;
			}
			else if ((this.btnRate.Text == "Rate") && (LBL_TRY.Text == "0"))
			{ // button Rate ditekan untuk pertama kali, 
				if(!cekMandatory())
					return;
				SaveInputRating(); 

				conn.QueryString  = "SELECT * FROM VW_PRMSCORING_BYILP WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				/*even pertama kali scoring uda masuk sini ternyata*/
				if (conn.GetRowCount() > 0)
				{
					/* RATING BY ILP */

					try
					{
						conn.QueryString  = "EXEC PRMSCORING_CALCULATE_RATING '" + Request.QueryString["regno"] + "'";
						conn.ExecuteQuery();

						if(conn.GetFieldValue(0,"RESULT") == "1")
						{
							btnRate.Text = "Re-Rate"; 
							ViewResponseData();
							btnRate.Enabled = true;
							btnUpdateStatus.Enabled = true;
						}
						else
						{
							GlobalTools.popMessage(this, "Error in Calculating Rating Result!");
							return;
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
				else
				{
					/* RATING BY STW */

					/******************************************
					 * Antisipasi mendapatkan result yang salah
					 ******************************************/
					conn.QueryString  = "delete from SCORING_RESPONSE where AP_REGNO like '%" + Request.QueryString["regno"] + "%' ";
					//conn.QueryString += "and SUMBERDATA = 'RATINGCUSTOMER'"; //SCOREBCG_TEXT_MESSAGE";
					conn.ExecuteNonQuery();

					bcg.GenerateSendTextFile(Request.QueryString["regno"],Request.QueryString["tc"]); // send message to queue
					bool success = bcg.UploadResponse(this,Request.QueryString["regno"],Request.QueryString["curef"]); // try to get Response
					if (success) 
					{ // jika proses upload sukses
						btnRate.Text = "Re-Rate"; 
						ViewResponseData();
						btnRate.Enabled = true;
						btnUpdateStatus.Enabled = true;
					}
					else 
					{ // jika proses upload gagal, user diminta menunggu dan dapat menekan tombol Rate untuk 
						// dapatkan response jika sudah ada
						LBL_TRY.Text += "0";
						btnRate.Text = "Retreive Rate";
						btnRate.Enabled = true; //false;
						btnUpdateStatus.Enabled = false;
					}
				}
			} 
			else if (this.btnRate.Text == "Retreive Rate")
			{ // vek apakah response sudah ada apa belum
				if (LBL_TRY.Text.Length <= 3)
				{ 
					bool success = bcg.UploadResponse(this,Request.QueryString["regno"],Request.QueryString["curef"]);
					if (success) 
					{ // jika upload berhasil, teks button diganti, status mencoba diset ke 0 (first chance)
						btnRate.Text = "Re-Rate";
						ViewResponseData();
						LBL_TRY.Text = "0"; 
						btnRate.Enabled = true;
						btnUpdateStatus.Enabled = true;
					} 
					else 
					{
						LBL_TRY.Text += "0";
						btnRate.Enabled = true; //false;
						btnUpdateStatus.Enabled = false;
					}
				} 
				else 
				{	// user sudah 3 kali gagal
					GlobalTools.popMessage(this, "Gagal mendapatkan response dari Strategy Ware. Silahkan mencoba Rate kembali!");
					btnRate.Text = "Rate";
					LBL_TRY.Text = "0";
				}
			}
		}

		private void RDO_A0303ACCEPTCUSTRISKCLASS_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.Adjustment();
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

		//20080122 add by sofyan, view new qualitative rating data from LOS
		private void ViewQualitativeFromLOS()
		{
			try
			{
				conn.QueryString = "EXEC SCOREBCG_VIEWQUALITATIVESCORELOS '" + Request.QueryString["regno"] + "', " +
					LBL_SCOREBCG_SEQ.Text;
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0) 
				{
					LBL_G0027.Text = conn.GetFieldValue("QUAL_SCORE");
					LBL_A0901.Text = conn.GetFieldValue("QUAL_DESC");
					//LBL_A1001.Text = conn.GetFieldValue("ADJ_DESC");
				}
			}
			catch (Exception ex)
			{
				GlobalTools.popMessage(this, "Error calculate qualitative score!");
				Response.Write("<!--" + ex.Message + "-->");
				return;
			}
		}

		//20081125 add by sofyan, mekanisme buffer
		private void BufferMechanism2(string regno, string cu_ref, string seq)
		{
			try
			{
				conn.QueryString = "EXEC SCOREBCG_BUFFERMECHANISM2 '" + regno + "', '" + cu_ref + "', " + seq;
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0) 
				{
					LBL_0G024H.Text = conn.GetFieldValue("HIST_FIN_SCORE");
					LBL_0A601H.Text = conn.GetFieldValue("HIST_FIN_SCORERANGE");
					LBL_0A602H.Text = conn.GetFieldValue("HIST_FIN_RISKCLASS");
					LBL_0A603H.Text = conn.GetFieldValue("HIST_FIN_PDRANGE");

					LBL_0A601F.Text = conn.GetFieldValue("FINAL_FIN_SCORERANGE");
					LBL_0A602F.Text = conn.GetFieldValue("FINAL_FIN_RISKCLASS");
					LBL_0A603F.Text = conn.GetFieldValue("FINAL_FIN_PDRANGE");
				}
			}
			catch (Exception ex)
			{
				GlobalTools.popMessage(this, "Error financial rating buffer!");
				Response.Write("<!--" + ex.Message + "-->");
				return;
			}
		}

		//20081201 add by sofyan
		private void ViewLastBuffer(string regno, string cu_ref, string seq)
		{
			try
			{
				conn.QueryString = "EXEC SCOREBCG_VIEWLASTBUFFER '" + regno + "', '" + cu_ref + "', " + seq;
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0) 
				{
					LBL_0A601.Text = conn.GetFieldValue("ORIG_FIN_SCORERANGE");
					LBL_0A602.Text = conn.GetFieldValue("ORIG_FIN_RISKCLASS");
					LBL_0A603.Text = conn.GetFieldValue("ORIG_FIN_PDRANGE");
				
					LBL_0G024H.Text = conn.GetFieldValue("HIST_FIN_SCORE");
					LBL_0A601H.Text = conn.GetFieldValue("HIST_FIN_SCORERANGE");
					LBL_0A602H.Text = conn.GetFieldValue("HIST_FIN_RISKCLASS");
					LBL_0A603H.Text = conn.GetFieldValue("HIST_FIN_PDRANGE");

					LBL_0A601F.Text = conn.GetFieldValue("FINAL_FIN_SCORERANGE");
					LBL_0A602F.Text = conn.GetFieldValue("FINAL_FIN_RISKCLASS");
					LBL_0A603F.Text = conn.GetFieldValue("FINAL_FIN_PDRANGE");

					LBL_A1003.Text = conn.GetFieldValue("ORIG_CUST_RISKCLASS");
					LBL_A1004.Text = conn.GetFieldValue("ORIG_CUST_PDRANGE");
				
					LBL_A1003H.Text = conn.GetFieldValue("HIST_CUST_RISKCLASS");
					LBL_A1004H.Text = conn.GetFieldValue("HIST_CUST_PDRANGE");

					LBL_A1003F.Text = conn.GetFieldValue("FINAL_CUST_RISKCLASS");
					LBL_A1004F.Text = conn.GetFieldValue("FINAL_CUST_PDRANGE");

					try {RBL_ACCEPT1.SelectedValue = conn.GetFieldValue("ACCEPT_PRECUSTRATING");} 
					catch {}
					try {RBL_ACCEPT2.SelectedValue = conn.GetFieldValue("RATIOKEU_DLMRATA2IND");} 
					catch {}
					try {RBL_ACCEPT3.SelectedValue = conn.GetFieldValue("ACCEPT_LASTCUSTRATING");} 
					catch {}

					LBL_CHKSYS1.Text = "";
					LBL_CHKSYS2.Text = "";
					LBL_CHKSYS3.Text = "";

					LBL_G0027H.Text = conn.GetFieldValue("HIST_QUAL_SCORE");
					LBL_A0901H.Text = conn.GetFieldValue("HIST_QUAL_RECDESC");
				}
			}
			catch (Exception ex)
			{
				GlobalTools.popMessage(this, "Error loading last rating data!");
				Response.Write("<!--" + ex.Message + "-->");
				return;
			}
		}

		//20081126 add by sofyan
		private void UpdateFinalCustRating(string regno, string cu_ref, string seq)
		{
			try
			{
				conn.QueryString = "EXEC SCOREBCG_UPDATEFINALCUSTRATING '" + regno + "', '" + cu_ref + "', " + seq;
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0) 
				{
					LBL_A1003.Text = conn.GetFieldValue("CUST_FINALRATING");
					LBL_A1004.Text = conn.GetFieldValue("CUST_FINALPDRANGE");
				}
			}
			catch (Exception ex)
			{
				GlobalTools.popMessage(this, "Error financial rating buffer!");
				Response.Write("<!--" + ex.Message + "-->");
				return;
			}
		}

		//20081127 add by sofyan, view new qualitative rating data from LOS
		private void ViewCurrentQualitative()
		{
			try
			{
				conn.QueryString = "EXEC SCOREBCG_VIEWCURRENTQUALITATIVE '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0) 
				{
					LBL_G0027_TEMP.Text = conn.GetFieldValue("QUAL_SCORE");
					LBL_A0901_TEMP.Text = conn.GetFieldValue("QUAL_DESC");
				}
			}
			catch (Exception ex)
			{
				GlobalTools.popMessage(this, "Error loading last rating data!");
				Response.Write("<!--" + ex.Message + "-->");
				return;
			}
		}

		//20090114 add by sofyan,
		//mekanisme buffer kedua
		private void UpdateFinalCustRatingAfterBuffer(string regno, string cu_ref, string seq, string mode)
		{
			/*
				mode	1 = Final Customer Rating = Pre Customer Rating
						2 = Final Customer Rating = Last Customer Rating
						3 = Final Customer Rating = Last Customer Rating Down Grade 1 Level
			*/
			try
			{
				conn.QueryString = "EXEC SCOREBCG_BUFFER3_UPDATEFINALCUSTRATING '" + regno + "', '" + cu_ref + "', '" + seq + "', '" + mode + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0) 
				{
					LBL_A1003F.Text = conn.GetFieldValue("CUST_FINALRATING");
					LBL_A1004F.Text = conn.GetFieldValue("CUST_FINALPDRANGE");
				}
			}
			catch (Exception ex)
			{
				GlobalTools.popMessage(this, "Error customer rating buffer!");
				Response.Write("<!--" + ex.Message + "-->");
				return;
			}
		}

		//20090114 add by sofyan,
		//mekanisme buffer kedua
		private void ViewFinalBuffer(string regno, string cu_ref, string seq)
		{
			try
			{
				conn.QueryString = "EXEC SCOREBCG_BUFFER3_VIEWFINAL '" + regno + "', '" + cu_ref + "', " + seq;
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0) 
				{
					LBL_A1003.Text = conn.GetFieldValue("ORIG_CUST_RISKCLASS");
					LBL_A1004.Text = conn.GetFieldValue("ORIG_CUST_PDRANGE");
				
					LBL_A1003H.Text = conn.GetFieldValue("HIST_CUST_RISKCLASS");
					LBL_A1004H.Text = conn.GetFieldValue("HIST_CUST_PDRANGE");

					LBL_A1003F.Text = conn.GetFieldValue("FINAL_CUST_RISKCLASS");
					LBL_A1004F.Text = conn.GetFieldValue("FINAL_CUST_PDRANGE");

					try {RBL_ACCEPT1.SelectedValue = conn.GetFieldValue("ACCEPT_PRECUSTRATING");} 
					catch {}
					try {RBL_ACCEPT2.SelectedValue = conn.GetFieldValue("RATIOKEU_DLMRATA2IND");} 
					catch {}
					try {RBL_ACCEPT3.SelectedValue = conn.GetFieldValue("ACCEPT_LASTCUSTRATING");} 
					catch {}

					LBL_G0027H.Text = conn.GetFieldValue("HIST_QUAL_SCORE");
					LBL_A0901H.Text = conn.GetFieldValue("HIST_QUAL_RECDESC");
				}
			}
			catch (Exception ex)
			{
				GlobalTools.popMessage(this, "Error customer rating buffer!");
				Response.Write("<!--" + ex.Message + "-->");
				return;
			}
		}

		//20090114 add by sofyan,
		//mekanisme buffer kedua
		private void FinalCustBuffer(string regno, string cu_ref, string seq)
		{
			string check1, //Mandatory Down Grade Applied? (1=Ya, 0=Tidak)
				check2,	//Current Qualitative Score >= Last Qualitative Score - 5? (1=Ya, 0=Tidak)
				check3; //Last Customer Rating > BB? (1=Ya, 0=Tidak)

			try
			{
				conn.QueryString = "EXEC SCOREBCG_BUFFER3_CHECKBYSYSTEM '" + regno + "', '" + cu_ref + "', " + seq;
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					check1 = conn.GetFieldValue("CHECK1");
					check2 = conn.GetFieldValue("CHECK2");
					check3 = conn.GetFieldValue("CHECK3");

					LBL_CHKSYS1.Text = conn.GetFieldValue("CHECK1DESC");
					LBL_CHKSYS2.Text = conn.GetFieldValue("CHECK2DESC");
					LBL_CHKSYS3.Text = conn.GetFieldValue("CHECK3DESC");
				}
				else
					return;

				//Accept Pre Cust Rating?
				//If Accept
				if (RBL_ACCEPT1.SelectedValue == "1")
				{
					UpdateFinalCustRatingAfterBuffer(regno, cu_ref, seq, "1");
				}
					//If Not Accept
				else
				{
					//Check Mandatory Down Grade Applied?
					//If DownGrade Applied
					if (check1 == "1")
					{
						UpdateFinalCustRatingAfterBuffer(regno, cu_ref, seq, "1");
					}
						//If No DownGrade Applied
					else if (check1 == "0")
					{
						//Check Apakah Ratio Keuangan Debitur Masih Berada Dalam Rata-rata Industri?
						//If Ya
						if (RBL_ACCEPT2.SelectedValue == "1")
						{
							//Check Apakah Current Qualitative Score >= Last Qualitative Score - 5?
							//If Ya
							if (check2 == "1")
							{
								//Check Apakah Last Customer Rating > BB?
								//If Ya
								if (check3 == "1")
								{
									//Check Apakah Accept Last Customer Rating?
									//If Ya
									if (RBL_ACCEPT3.SelectedValue == "1")
									{
										UpdateFinalCustRatingAfterBuffer(regno, cu_ref, seq, "2");
									}
										//If Tidak
									else
									{
										UpdateFinalCustRatingAfterBuffer(regno, cu_ref, seq, "1");
									}
								}
								else if (check3 == "0")
								{
									UpdateFinalCustRatingAfterBuffer(regno, cu_ref, seq, "3");
								}
							}
								//If Tidak
							else if (check2 == "0")
							{
								UpdateFinalCustRatingAfterBuffer(regno, cu_ref, seq, "1");
							}
						}
							//If Tidak
						else
						{
							UpdateFinalCustRatingAfterBuffer(regno, cu_ref, seq, "1");
						}
					}
				}

				//Save Ke History Buffer
				conn.QueryString = "EXEC SCOREBCG_BUFFER3_SAVEHISTORY '" + 
					regno + "', '" + cu_ref + "', " + seq + ", '" +
					RBL_ACCEPT1.SelectedValue + "', '" +
					RBL_ACCEPT2.SelectedValue + "', '" +
					RBL_ACCEPT3.SelectedValue + "'";
				conn.ExecuteQuery();

				ViewFinalBuffer(regno, cu_ref, seq);
			}
			catch (Exception ex)
			{
				GlobalTools.popMessage(this, "Error customer rating buffer!");
				Response.Write("<!--" + ex.Message + "-->");
				return;
			}
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

		private void ViewResponseData()
		{
			try
			{
				//				conn.QueryString  = "select top 1 * from SCOREBCG_RESULT where ";
				//				conn.QueryString += "AP_REGNO = '" + Request.QueryString["regno"] + "'";
				conn.QueryString  = "select top 1 * from VW_SCOREBCG_RESULTCUSTRATING where AP_REGNO = '" +
					Request.QueryString["regno"] + "' and seq = " + LBL_SCOREBCG_SEQ.Text;	//this method called after rate, thus by this ap_regno
				conn.ExecuteQuery();

				/* PAYMENT CATEGORY */
				LBL_A0701.Text = conn.GetFieldValue("PH_DESC").Trim(); 
				
				/* INDUSTRY REVIEW */
				LBL_A0801.Text = conn.GetFieldValue("A0801IND_SCORE");
				LBL_A0802.Text = conn.GetFieldValue("IND_DESC").Trim(); 

				/* QUALITATIVE SCORE */
				LBL_G0027.Text = conn.GetFieldValue("G0027QUAL_SCORE");
				LBL_A0901.Text = conn.GetFieldValue("QUAL_DESC").Trim(); 

				/* TOTAL SCORE */
				LBL_0G024.Text = conn.GetFieldValue("G0024FIN_SCORE"); // Total Financial Score
				LBL_0A601.Text = conn.GetFieldValue("A0601FIN_SCORERANGE"); // Financial Score Range
				LBL_0A602.Text = conn.GetFieldValue("A0602FIN_RISKCLASS"); // Financial Risk Class
				LBL_0A603.Text = conn.GetFieldValue("A0603FIN_PDRANGE"); // Financial PD Range	
 
				/* MANAGEMENT QUALITY */
				LBL_G0025.Text = conn.GetFieldValue("G0025TMQ_SCORE");

				/* BUSINESS OUTLOOK */
				LBL_G0026.Text = conn.GetFieldValue("G0026TBO_SCORE");

				/* CUSTOMER SCORE */
				LBL_A1001.Text = conn.GetFieldValue("ADJ_DESC");
				LBL_A1002.Text = conn.GetFieldValue("A1002CUST_PRE_RISKCLASS");
				LBL_A1003.Text = conn.GetFieldValue("A1003CUST_FINAL_RISKCLASS");
				LBL_A1004.Text = conn.GetFieldValue("A1004CUST_PDRANGE");
				try
				{
					int adj = Convert.ToInt16(conn.GetFieldValue("A1001CUST_TOTADJUSTMENT"));
					//20080312 remark by sofyan, dibuka aja (nggak usah di-disabled)
					//if(adj > 0)
					//	RDO_A0303ACCEPTCUSTRISKCLASS.Enabled = true;
				} 
				catch {}

				//20080306 add by sofyan,
				//dioverride lagi untuk menampilkan hasil Qualitative dari LOS
				//hasil Qualitative dari STW sekarang nggak dipakai lagi
				ViewQualitativeFromLOS();
				//20080312 add by sofyan,
				//mekanisme buffer
				
				conn.QueryString  = "EXEC ISNEEDBUFFER '" + Request.QueryString["regno"] + "'";	//this method called after rate, thus by this ap_regno
				conn.ExecuteQuery();
				if(conn.GetFieldValue("ISTRUE") == "Y")
				{
					BufferMechanism2(Request.QueryString["regno"], Request.QueryString["curef"], LBL_SCOREBCG_SEQ.Text);
					UpdateFinalCustRating(Request.QueryString["regno"], Request.QueryString["curef"], LBL_SCOREBCG_SEQ.Text);
					//20090114 add by sofyan,
					//mekanisme buffer kedua
					FinalCustBuffer(Request.QueryString["regno"], Request.QueryString["curef"], LBL_SCOREBCG_SEQ.Text);
				}
				else if(conn.GetFieldValue("ISTRUE") == "N")
				{
					UpdateFinalCustRating(Request.QueryString["regno"], Request.QueryString["curef"], LBL_SCOREBCG_SEQ.Text);
					LBL_A1003F.Text = LBL_A1003.Text;
					LBL_A1004F.Text = LBL_A1004.Text;
					
					LBL_0A601F.Text = LBL_0A601.Text;
					LBL_0A602F.Text = LBL_0A602.Text;
					LBL_0A603F.Text = LBL_0A603.Text;
				}
				
				enableRDOnew(true);
			}
			catch (Exception ex)
			{
				GlobalTools.popMessage(this, "Error loading response data!");
				Response.Write("<!--" + ex.Message + "-->");
				return;
			}
			setButtonsStatus();
		}
		#region Secure Data
		private void SecureData() 
		{
			string scr = Request.QueryString["scr"];

			if (scr == "0")
			{
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				int kk = 0, index = -1;
				for (kk = 0; kk < coll.Count; kk++) 
				{
					if (coll[kk] is System.Web.UI.HtmlControls.HtmlForm) 
					{
						index = kk;
						break;
					}
				}

				if (index == -1) return;
				if (kk == coll.Count) return;

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
		#endregion
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
			
			// menambahkan pesan: GATOT
			string msg = getNextStepMsg(Request.QueryString["regno"]);
			Response.Redirect("ListScoring.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);

		}

		private string getNextStepMsg(string regno) 
		{
			string pesan = "";
			string nextTrack = "";
			try 
			{
				/***
				 * Memunculkan pesan next step
				 ***/
				conn.QueryString = "exec TRACKNEXTMSG '" + regno + "'";
				conn.ExecuteQuery();
				nextTrack = conn.GetFieldValue("TRACKNAME");
				pesan = "Application proceeds to " + nextTrack;
				/***********************************/
			} 
			catch 
			{
				throw new Exception();
			}
			return pesan;
		}

		private void backToList() 
		{
			Session.Add("tc", Request.QueryString["tc"]);
			Session.Add("mc", Request.QueryString["mc"]);
			
			string link = "../Scoring/ListScoring.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"];
			Response.Write("<form name='Form2' action='"+link+"' target='main'");
			Response.Write("");
			Response.Write("</form>");
			Response.Write("<script language='javascript'>alert('Track Update Successful!');</script>");
			Response.Write("<script language='JavaScript'>document.Form2.submit();</script>");			
			
			//Server.Transfer("ListScoring.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);				
			Server.Transfer("ListScoring.aspx");						
		}

		protected void RBL_ACCEPT1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FinalCustBuffer(Request.QueryString["regno"], Request.QueryString["curef"], LBL_SCOREBCG_SEQ.Text);
		}

		protected void RBL_ACCEPT2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FinalCustBuffer(Request.QueryString["regno"], Request.QueryString["curef"], LBL_SCOREBCG_SEQ.Text);
		}

		protected void RBL_ACCEPT3_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FinalCustBuffer(Request.QueryString["regno"], Request.QueryString["curef"], LBL_SCOREBCG_SEQ.Text);
		}
		
	}
}