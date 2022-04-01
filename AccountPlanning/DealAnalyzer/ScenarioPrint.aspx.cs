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
	/// Summary description for ScenarioPrint.
	/// </summary>
	public partial class ScenarioPrint : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn3 = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewData();
			ViewProduct();
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM VW_AP_CUSTOMER_LIST_TEMP2 WHERE CIF = '" + Request.QueryString["cif"] + "'";
			conn.ExecuteQuery();

			LBL_CIF.Text			= conn.GetFieldValue("CIF").ToString();
			LBL_CUST_NAME.Text		= conn.GetFieldValue("CUSTOMER_NAME").ToString();
			LBL_ADDRESS.Text		= conn.GetFieldValue("CUST_ADDRESS").ToString();
			LBL_KOTA.Text			= conn.GetFieldValue("CUST_CITY").ToString();
			LBL_GROUP_NAME.Text		= conn.GetFieldValue("CUSTOMER_GROUP").ToString();
			LBL_CUST_DATE.Text		= tools.FormatDate(conn.GetFieldValue("CUST_DATE").ToString());
			LBL_RM.Text				= conn.GetFieldValue("RM_NAME").ToString();
			LBL_RM_GROUP_NAME.Text	= conn.GetFieldValue("GROUP_NAME").ToString();
			LBL_RM_UNIT_NAME.Text	= conn.GetFieldValue("BRANCH_NAME").ToString();
			LBL_RELATIONSHIP.Text	= conn.GetFieldValue("CUST_LENGTH").ToString();

			conn.QueryString = "SELECT * FROM AP_SCENARIO WHERE CIF = '" + Request.QueryString["cif"] + "' AND SCENARIO# = '" + Request.QueryString["sc"] + "'";
			conn.ExecuteQuery();

			LBL_SCENARIO.Text		= conn.GetFieldValue("SCENARIO_DESC").ToString();
		}

		private void ViewProduct()
		{
			conn2.QueryString = "SELECT * FROM AP_DEAL_ANALYZER A LEFT OUTER JOIN (SELECT * FROM VW_AP_TEMPLATE_DEAL_ANALYZER) B ON A.PRODUCTID = B.PRODUCTID"
								+ " WHERE CIF#='" + Request.QueryString["cif"] + "' AND SCENARIO#='" + Request.QueryString["sc"] + "'";
			conn2.ExecuteQuery();

			for(int i = 0; i < conn2.GetRowCount(); i++)
			{
				LBL_SEQ_SCENARIO.Text = conn2.GetFieldValue(i,"SEQ_SCENARIO").ToString();
				CreateContent(conn2.GetFieldValue(i,"ID_TEMPLATE"), conn2.GetFieldValue(i,"PRODUCT_NM"));
			}

			//conn.QueryString = "SELECT * FROM VW_AP_TOTAL_DEAL_ANALYZER WHERE CIF#='" + Request.QueryString["cif"] + "' AND SCENARIO#='" + Request.QueryString["sc"] + "'";
			conn.QueryString = "EXEC AP_TOTAL_DEAL_ANALYZER_PRINT '" + Request.QueryString["cif"] + "','" + Request.QueryString["sc"] + "'";
			conn.ExecuteQuery();
			LBL_TOT_INCOME.Text			= tools.MoneyFormat(conn.GetFieldValue("NET_INCOME_RESULT").ToString());
			LBL_NII.Text				= tools.MoneyFormat(conn.GetFieldValue("NII_RESULT").ToString());
			LBL_FBI.Text				= tools.MoneyFormat(conn.GetFieldValue("FBI_RESULT").ToString());
			LBL_RORA.Text				= conn.GetFieldValue("RORA_RESULT").ToString() + "%";
			LBL_CASH.Text				= tools.MoneyFormat(conn.GetFieldValue("CASH_RESULT").ToString());
			LBL_NON_CASH.Text			= tools.MoneyFormat(conn.GetFieldValue("NON_CASH_RESULT").ToString());
			LBL_INCOME_COST_CUST.Text	= tools.MoneyFormat(conn.GetFieldValue("INCOME_COST_CUST_RESULT").ToString());
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

		private void CreateContent(string ID_CATEGORY, string PRODUCT_NM)
		{
			System.Web.UI.HtmlControls.HtmlTableRow TR;
			System.Web.UI.HtmlControls.HtmlTableCell TD;
			System.Web.UI.HtmlControls.HtmlTableRow TR2;
			System.Web.UI.HtmlControls.HtmlTableCell TD2;
			System.Web.UI.HtmlControls.HtmlTableCell TD3;
			System.Web.UI.HtmlControls.HtmlTable Table6;
			System.Web.UI.HtmlControls.HtmlTable Table7;
			System.Web.UI.WebControls.Label LBL_LABEL;
			System.Web.UI.WebControls.Label LBL_FIELD;
			//System.Web.UI.WebControls.TextBox TXT_BOX;
			

			/************************************ MEMBUAT TITLE PAGE ********************************************/
			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = PRODUCT_NM;

			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["class"] = "tdHeader1";
			TD.Attributes["colspan"] = "2";
			TR.Controls.Add(TD);

			TBL_SCENARIO.Controls.Add(TR);

			/*************************************** MEMBUAT TR & TD *****************************************/
			conn.QueryString = "SELECT TEXT, FIELD FROM AP_CATEGORY_PRINT_SCENARIO WHERE ID_CATEGORY = '" + ID_CATEGORY + "'";
			conn.ExecuteQuery();

			TR2 = new HtmlTableRow();
			TD2 = new HtmlTableCell();
			TD3 = new HtmlTableCell();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				Table6 = new HtmlTable();
				Table7 = new HtmlTable();

				//label-kiri
				TR = new HtmlTableRow();
				TD = new HtmlTableCell();
				LBL_LABEL = new Label();
				LBL_LABEL.Text = conn.GetFieldValue(i,0).ToString() + " : ";
				TD.Controls.Add(LBL_LABEL);
				TD.Attributes["class"] = "TDBGColor1";
				TD.Attributes["width"] = "50%";
				//TD.Attributes["align"] = "right";
				TR.Controls.Add(TD);

				//label result-kiri
				LBL_FIELD = new Label();
				LBL_FIELD.Text = conn.GetFieldValue(i,1).ToString();
				/*conn3.QueryString = "SELECT CASE " + LBL_FIELD.Text + " WHEN '0.0' THEN '-' ELSE CONVERT(VARCHAR, " + LBL_FIELD.Text + ") END AS " + LBL_FIELD.Text +
					" FROM AP_DEAL_ANALYZER WHERE CIF#='" + Request.QueryString["cif"] + "' AND SCENARIO#='" + Request.QueryString["sc"] + "' AND SEQ_SCENARIO='" + LBL_SEQ_SCENARIO.Text + "'";
				*/
				conn3.QueryString = "SELECT " + LBL_FIELD.Text + " FROM AP_DEAL_ANALYZER WHERE CIF#='" + Request.QueryString["cif"] + "' AND SCENARIO#='" + Request.QueryString["sc"] + "' AND SEQ_SCENARIO='" + LBL_SEQ_SCENARIO.Text + "'";
				conn3.ExecuteQuery();

				TD = new HtmlTableCell();
				LBL_LABEL = new Label();
				LBL_LABEL.Text = conn3.GetFieldValue(LBL_FIELD.Text);
				TD.Controls.Add(LBL_LABEL);
			    TD.Attributes["class"] = "TDBGColorValue";
				TD.Attributes["width"] = "50%";
				//TD.Attributes["align"] = "left";
				TR.Controls.Add(TD);

				Table6.Controls.Add(TR);
				Table6.Width = "100%";

				/*TD = new HtmlTableCell();
				TXT_BOX = new TextBox();
				TXT_BOX.Width = 350;
				TXT_BOX.Text = conn3.GetFieldValue(LBL_FIELD.Text);
				TXT_BOX.ReadOnly = true;
				TD.Controls.Add(TXT_BOX);
				TR.Controls.Add(TD);*/
				
				i++; //increment

				//label-kanan
				if(i < conn.GetRowCount())
				{
					TR = new HtmlTableRow();

					TD = new HtmlTableCell();
					LBL_LABEL = new Label();
					LBL_LABEL.Text = conn.GetFieldValue(i,0).ToString() + " : ";
					TD.Controls.Add(LBL_LABEL);
					TD.Attributes["class"] = "TDBGColor1";
					TD.Attributes["width"] = "50%";
					//TD.Attributes["align"] = "right";
					TR.Controls.Add(TD);
						
					//label result-kanan
					LBL_FIELD = new Label();
					LBL_FIELD.Text = conn.GetFieldValue(i,1).ToString();
					/*conn3.QueryString = "SELECT CASE " + LBL_FIELD.Text + " WHEN '0.0' THEN '-' ELSE CONVERT(VARCHAR, " + LBL_FIELD.Text + ") END AS " + LBL_FIELD.Text +
										" FROM AP_DEAL_ANALYZER WHERE CIF#='" + Request.QueryString["cif"] + "' AND SCENARIO#='" + Request.QueryString["sc"] + "' AND SEQ_SCENARIO='" + LBL_SEQ_SCENARIO.Text + "'";
					*/
					conn3.QueryString = "SELECT " + LBL_FIELD.Text + " FROM AP_DEAL_ANALYZER WHERE CIF#='" + Request.QueryString["cif"] + "' AND SCENARIO#='" + Request.QueryString["sc"] + "' AND SEQ_SCENARIO='" + LBL_SEQ_SCENARIO.Text + "'";
					conn3.ExecuteQuery();

					TD = new HtmlTableCell();
					LBL_LABEL = new Label();
					LBL_LABEL.Text = conn3.GetFieldValue(LBL_FIELD.Text);
					TD.Controls.Add(LBL_LABEL);
					TD.Attributes["class"] = "TDBGColorValue";
					TD.Attributes["width"] = "50%";
					//TD.Attributes["align"] = "left";
					TR.Controls.Add(TD);

					/*TD = new HtmlTableCell();
					TXT_BOX = new TextBox();
					TXT_BOX.Width = 350;
					TXT_BOX.Text = conn3.GetFieldValue(LBL_FIELD.Text);
					TXT_BOX.ReadOnly = true;
					TD.Controls.Add(TXT_BOX);
					TR.Controls.Add(TD);*/

					Table7.Controls.Add(TR);
					Table7.Width = "100%";
				}
				else
				{
					TR = new HtmlTableRow();

					TD = new HtmlTableCell();
					LBL_LABEL = new Label();
					LBL_LABEL.Text = "";
					TD.Controls.Add(LBL_LABEL);
					TD.Attributes["class"] = "TDBGColor1";
					TD.Attributes["width"] = "50%";
					//TD.Attributes["align"] = "right";
					TR.Controls.Add(TD);

					TD = new HtmlTableCell();
					LBL_LABEL = new Label();
					LBL_LABEL.Text = conn3.GetFieldValue(LBL_FIELD.Text);
					TD.Controls.Add(LBL_LABEL);
					TD.Attributes["class"] = "TDBGColorValue";
					TD.Attributes["width"] = "50%";
					//TD.Attributes["align"] = "left";
					TR.Controls.Add(TD);

					Table7.Controls.Add(TR);
					Table7.Width = "100%";
				}
				
				TD2.Controls.Add(Table6);
				TD2.Attributes["class"] = "td";
				TD2.Width = "50%";

				TD3.Controls.Add(Table7);
				TD2.Attributes["class"] = "td";
				TD3.Width = "50%";

				TR2.Controls.Add(TD2);
				TR2.Controls.Add(TD3);

				TBL_SCENARIO.Controls.Add(TR2);
			}
		}

		private void BTN_BACK_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
