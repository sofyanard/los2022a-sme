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

namespace SME.AccountPlanning.OportunityIndentification
{
	/// <summary>
	/// Summary description for ClientStrategyOpportunity.
	/// </summary>
	public partial class ClientStrategyOpportunity : System.Web.UI.Page
	{
		/*******************************************************/
		protected System.Web.UI.WebControls.Label LBL_TARGET;
		/*********************************************************/
		/*********************************************************/
		/*********************************************************/
		/*********************************************************/
		/*********************************************************/
		/*********************************************************/
		/*********************************************************/
		/*********************************************************/
		/*********************************************************/
		/*********************************************************/
		/*********************************************************/
		/*********************************************************/
		/*********************************************************/
		/*********************************************************/
		/*********************************************************/
		/*********************************************************/
		/*********************************************************/
		/*********************************************************/
		/*********************************************************/
		/*********************************************************/
		/*********************************************************/
		/*********************************************************/
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				ViewData();
				TBL_DETAIL.Visible = false;
			}
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT DISTINCT CIF#,CUSTOMER_GROUP,CUST_ADDRESS,CUST_CITY,CUST_DATE,RM_NAME,GROUP_NAME,BRANCH_NAME,CUST_LENGTH FROM VW_AP_CUSTOMER_LIST" +
				" WHERE CIF#='" + Request.QueryString["cif"] + "' AND BUSSUNITID='" + Request.QueryString["bs"] + "' AND BUC='" + Request.QueryString["bc"] +
				"' AND (RM_ID='" + Request.QueryString["rd"] + "' OR CST_ID='" + Request.QueryString["cd"] + "')";
			conn.ExecuteQuery();

			TXT_CIF.Text = conn.GetFieldValue("CIF#").ToString();
			TXT_CUST_NAME.Text = conn.GetFieldValue("CUSTOMER_GROUP").ToString();
			TXT_ADDRESS.Text = conn.GetFieldValue("CUST_ADDRESS").ToString();
			TXT_KOTA.Text = conn.GetFieldValue("CUST_CITY").ToString();
			TXT_CUST_DATE.Text = tools.FormatDate(conn.GetFieldValue("CUST_DATE").ToString());
			TXT_RM.Text = conn.GetFieldValue("RM_NAME").ToString();
			TXT_GROUP_NAME.Text = conn.GetFieldValue("GROUP_NAME").ToString();
			TXT_UNIT_NAME.Text = conn.GetFieldValue("BRANCH_NAME").ToString();
			TXT_RELATIONSHIP.Text = conn.GetFieldValue("CUST_LENGTH").ToString();

			FillDataGrid();
		}

		private void FillDataGrid()
		{
			conn.QueryString = "SELECT * FROM AP_COMPANY_INFO WHERE CIF_GROUP='" + Request.QueryString["cif"] + "'";
			BindData(DGR_COMPANY.ID.ToString(), conn.QueryString);
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
			this.DGR_COMPANY.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_COMPANY_ItemCommand);
			this.DGR_COMPANY.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_COMPANY_PageIndexChanged);
			this.DGR_WHOLESALE.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_WHOLESALE_ItemCommand);
			this.DGR_WHOLESALE.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_WHOLESALE_PageIndexChanged);
			this.DGR_ALLIANCE.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_ALLIANCE_ItemCommand);
			this.DGR_ALLIANCE.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_ALLIANCE_PageIndexChanged);
			this.DGR_OTHERS.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_OTHERS_ItemCommand);
			this.DGR_OTHERS.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_OTHERS_PageIndexChanged);

		}
		#endregion

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../CustomerList.aspx?mc=" + Request.QueryString["mc"]);
		}

		private void DGR_COMPANY_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_COMPANY.CurrentPageIndex = e.NewPageIndex;
			FillDataGrid();
		}

		private void DGR_COMPANY_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					TBL_DETAIL.Visible = true;
					LBL_ID.Text = e.Item.Cells[0].Text.Trim();
					LBL_PT.Text = e.Item.Cells[1].Text.Trim();
					CekCode();
					CekStrategy();
					FillGridWholesale();
					FillGridAlliance();
					FillGridOthers();
					FillDDLProduct();
					FillDDLProb();
					break;
			}
		}

		private void CekCode()
		{
			//CEK ID WHOLESALE
			conn.QueryString = "SELECT ISNULL(MAX(CONVERT(INT, SEQ)),0) AS SEQ FROM AP_WHOLESALE_ALLIANCE WHERE [ID]='1' AND CIF#='" + TXT_CIF.Text + "' AND CIF#_SUBS='" + LBL_ID.Text + "'";
			conn.ExecuteQuery();
			LBL_ID_WHOLESALE.Text =  conn.GetFieldValue("SEQ").ToString();

			conn.QueryString = "EXEC AP_GENERATE_SEQ_PARAM '" + LBL_ID_WHOLESALE.Text + "'";
			conn.ExecuteQuery();
			TXT_ID_WHOLESALE.Text = conn.GetFieldValue(0,0).ToString();

			//CEK ID ALLIANCE
			conn.QueryString = "SELECT ISNULL(MAX(CONVERT(INT, SEQ)),0) AS SEQ FROM AP_WHOLESALE_ALLIANCE WHERE [ID]='2' AND CIF#='" + TXT_CIF.Text + "' AND CIF#_SUBS='" + LBL_ID.Text + "'";
			conn.ExecuteQuery();
			LBL_ID_ALLIANCE.Text =  conn.GetFieldValue("SEQ").ToString();

			conn.QueryString = "EXEC AP_GENERATE_SEQ_PARAM '" + LBL_ID_ALLIANCE.Text + "'";
			conn.ExecuteQuery();
			TXT_ID_ALLIANCE.Text = conn.GetFieldValue(0,0).ToString();

			//CEK ID OTHERS
			conn.QueryString = "SELECT ISNULL(MAX(CONVERT(INT, SEQ)),0) AS SEQ FROM AP_WHOLESALE_ALLIANCE WHERE [ID]='3' AND CIF#='" + TXT_CIF.Text + "' AND CIF#_SUBS='" + LBL_ID.Text + "'";
			conn.ExecuteQuery();
			LBL_ID_OTHERS.Text =  conn.GetFieldValue("SEQ").ToString();

			conn.QueryString = "EXEC AP_GENERATE_SEQ_PARAM '" + LBL_ID_ALLIANCE.Text + "'";
			conn.ExecuteQuery();
			TXT_ID_OTHERS.Text = conn.GetFieldValue(0,0).ToString();
		}

		private void CekStrategy()
		{
			conn.QueryString = "SELECT * FROM AP_STRATEGY_COMPANY WHERE CIF = '" + LBL_ID.Text + "'";
			conn.ExecuteQuery();

			TXT_CLIENT_STRATEGY.Text = conn.GetFieldValue("OVERALL_STRATEGY");
			TXT_STRATEGY_OPTIMASI.Text = conn.GetFieldValue("STRATEGY_DESC");
		}

		private void FillGridWholesale()
		{
			conn.QueryString = "SELECT *, CASE PRIORITY WHEN '1' THEN 'Yes' WHEN '0' THEN 'No' END AS PRIORITY_DESC,"+
				"CASE DEV_AP WHEN '1' THEN 'Yes' WHEN '0' THEN 'No' END AS DEV_DESC FROM AP_WHOLESALE_ALLIANCE WHERE [ID]='1' AND CIF#='" + TXT_CIF.Text + "' AND CIF#_SUBS='" + LBL_ID.Text + "'";
			BindData(DGR_WHOLESALE.ID.ToString(), conn.QueryString);
		}

		private void FillGridAlliance()
		{
			conn.QueryString = "SELECT *, CASE PRIORITY WHEN '1' THEN 'Yes' WHEN '0' THEN 'No' END AS PRIORITY_DESC,"+
				"CASE DEV_AP WHEN '1' THEN 'Yes' WHEN '0' THEN 'No' END AS DEV_DESC FROM AP_WHOLESALE_ALLIANCE WHERE [ID]='2' AND CIF#='" + TXT_CIF.Text + "' AND CIF#_SUBS='" + LBL_ID.Text + "'";
			BindData(DGR_ALLIANCE.ID.ToString(), conn.QueryString);
		}

		private void FillGridOthers()
		{
			conn.QueryString = "SELECT *, CASE PRIORITY WHEN '1' THEN 'Yes' WHEN '0' THEN 'No' END AS PRIORITY_DESC,"+
				"CASE DEV_AP WHEN '1' THEN 'Yes' WHEN '0' THEN 'No' END AS DEV_DESC FROM AP_WHOLESALE_ALLIANCE WHERE [ID]='3' AND CIF#='" + TXT_CIF.Text + "' AND CIF#_SUBS='" + LBL_ID.Text + "'";
			BindData(DGR_OTHERS.ID.ToString(), conn.QueryString);
		}

		private void FillDDLProduct()
		{
			DDL_PRODUCT_SERVICE_WHOLESALE.Items.Clear();
			DDL_PRODUCT_SERVICE_ALLIANCE.Items.Clear();
			DDL_PRODUCT_SERVICE_OTHERS.Items.Clear();
			DDL_PRODUCT_SERVICE_WHOLESALE.Items.Add(new ListItem("--Select--",""));
			DDL_PRODUCT_SERVICE_ALLIANCE.Items.Add(new ListItem("--Select--",""));
			DDL_PRODUCT_SERVICE_OTHERS.Items.Add(new ListItem("--Select--",""));

			conn.QueryString = "SELECT ID_AP_VARIABLE, [DESCRIPTION] FROM AP_VARIABLE WHERE STATUS='1'";
			conn.ExecuteQuery();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_PRODUCT_SERVICE_WHOLESALE.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
				DDL_PRODUCT_SERVICE_ALLIANCE.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
				DDL_PRODUCT_SERVICE_OTHERS.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLProb()
		{
			DDL_PROBABILITY_WHOLESALE.Items.Clear();
			DDL_PROBABILITY_ALLIANCE.Items.Clear();
			DDL_PROBABILITY_OTHERS.Items.Clear();
			DDL_PROBABILITY_WHOLESALE.Items.Add(new ListItem("--Select--",""));
			DDL_PROBABILITY_ALLIANCE.Items.Add(new ListItem("--Select--",""));
			DDL_PROBABILITY_OTHERS.Items.Add(new ListItem("--Select--",""));

			conn.QueryString = "SELECT OTHERS_CODE, OTHERS_DESC FROM AP_RF_OTHERS WHERE STATUS='1'";
			conn.ExecuteQuery();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_PROBABILITY_WHOLESALE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				DDL_PROBABILITY_ALLIANCE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				DDL_PROBABILITY_OTHERS.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		protected void BTN_INSERT_WHOLESALE_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC AP_INSERT_WHOLESALE_ALLIANCE '" + TXT_ID_WHOLESALE.Text + "','1','" + TXT_CIF.Text + "','" + LBL_ID.Text + "','"
					+ DDL_PRODUCT_SERVICE_WHOLESALE.SelectedValue + "','" + TXT_CLIENT_NEEDS_WHOLESALE.Text + "','"
					+ TXT_OPPORTUNITY_DESC_WHOLESALE.Text + "','" + TXT_POTENSIAL_VOLUME_WHOLESALE.Text + "','"
					+ TXT_POTENSIAL_INCOME_WHOLESALE.Text + "','" + DDL_PROBABILITY_WHOLESALE.SelectedValue + "','"
					+ RDO_PRIORITY_WHOLESALE.SelectedValue + "','" + RDO_ACTIONPLAN_WHOLESALE.SelectedValue + "'";
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

			CekCode();
			ClearData();
			FillGridWholesale();
		}

		protected void BTN_INSERT_ALLIANCE_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC AP_INSERT_WHOLESALE_ALLIANCE '" + TXT_ID_ALLIANCE.Text + "','2','" + TXT_CIF.Text + "','" + LBL_ID.Text + "','"
					+ DDL_PRODUCT_SERVICE_ALLIANCE.SelectedValue + "','" + TXT_CLIENT_NEEDS_ALLIANCE.Text + "','"
					+ TXT_OPPORTUNITY_DESC_ALLIANCE.Text + "','" + TXT_POTENSIAL_VOLUME_ALLIANCE.Text + "','"
					+ TXT_POTENSIAL_INCOME_ALLIANCE.Text + "','" + DDL_PROBABILITY_ALLIANCE.SelectedValue + "','"
					+ RDO_PRIORITY_ALLIANCE.SelectedValue + "','" + RDO_ACTIONPLAN_ALLIANCE.SelectedValue + "'";
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
			CekCode();
			ClearData();
			FillGridAlliance();
		}

		protected void BTN_INSERT_OTHERS_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC AP_INSERT_WHOLESALE_ALLIANCE '" + TXT_ID_OTHERS.Text + "','3','" + TXT_CIF.Text + "','" + LBL_ID.Text + "','"
					+ DDL_PRODUCT_SERVICE_OTHERS.SelectedValue + "','" + TXT_CLIENT_NEEDS_OTHERS.Text + "','"
					+ TXT_OPPORTUNITY_DESC_OTHERS.Text + "','" + TXT_POTENSIAL_VOLUME_OTHERS.Text + "','"
					+ TXT_POTENSIAL_INCOME_OTHERS.Text + "','" + DDL_PROBABILITY_OTHERS.SelectedValue + "','"
					+ RDO_PRIORITY_OTHERS.SelectedValue + "','" + RDO_ACTIONPLAN_OTHERS.SelectedValue + "'";
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
			CekCode();
			ClearData();
			FillGridOthers();
		}

		private void ClearData()
		{
			DDL_PRODUCT_SERVICE_WHOLESALE.SelectedValue = "";
			DDL_PRODUCT_SERVICE_ALLIANCE.SelectedValue = "";
			DDL_PRODUCT_SERVICE_OTHERS.SelectedValue = "";

			TXT_CLIENT_NEEDS_WHOLESALE.Text = "";
			TXT_CLIENT_NEEDS_ALLIANCE.Text = "";
			TXT_CLIENT_NEEDS_OTHERS.Text = "";

			TXT_OPPORTUNITY_DESC_WHOLESALE.Text = "";
			TXT_OPPORTUNITY_DESC_ALLIANCE.Text = "";
			TXT_OPPORTUNITY_DESC_OTHERS.Text = "";

			TXT_POTENSIAL_VOLUME_WHOLESALE.Text = "";
			TXT_POTENSIAL_VOLUME_ALLIANCE.Text = "";
			TXT_POTENSIAL_VOLUME_OTHERS.Text = "";

			TXT_POTENSIAL_INCOME_WHOLESALE.Text = "";
			TXT_POTENSIAL_INCOME_ALLIANCE.Text = "";
			TXT_POTENSIAL_INCOME_OTHERS.Text = "";

			DDL_PROBABILITY_WHOLESALE.SelectedValue = "";
			DDL_PROBABILITY_ALLIANCE.SelectedValue = "";
			DDL_PROBABILITY_OTHERS.SelectedValue = "";

			RDO_PRIORITY_WHOLESALE.SelectedValue = null;
			RDO_PRIORITY_ALLIANCE.SelectedValue = null;
			RDO_PRIORITY_OTHERS.SelectedValue = null;

			RDO_ACTIONPLAN_WHOLESALE.SelectedValue = null;
			RDO_ACTIONPLAN_ALLIANCE.SelectedValue = null;
			RDO_ACTIONPLAN_OTHERS.SelectedValue = null;
		}

		private void DGR_WHOLESALE_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_WHOLESALE.CurrentPageIndex = e.NewPageIndex;
			FillGridWholesale();
		}

		private void DGR_ALLIANCE_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_ALLIANCE.CurrentPageIndex = e.NewPageIndex;
			FillGridAlliance();
		}

		private void DGR_OTHERS_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_OTHERS.CurrentPageIndex = e.NewPageIndex;
			FillGridOthers();
		}

		private void DGR_WHOLESALE_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					string a = e.Item.Cells[11].Text.Trim();
					string b = e.Item.Cells[13].Text.Trim();

					TXT_ID_WHOLESALE.Text = e.Item.Cells[0].Text.Trim();
					DDL_PRODUCT_SERVICE_WHOLESALE.SelectedValue = e.Item.Cells[3].Text.Trim().Replace("&nbsp;","");
					TXT_CLIENT_NEEDS_WHOLESALE.Text = e.Item.Cells[5].Text.Trim().Replace("&nbsp;","");
					TXT_OPPORTUNITY_DESC_WHOLESALE.Text = e.Item.Cells[6].Text.Trim().Replace("&nbsp;","");
					TXT_POTENSIAL_VOLUME_WHOLESALE.Text = e.Item.Cells[7].Text.Trim().Replace("&nbsp;","");
					TXT_POTENSIAL_INCOME_WHOLESALE.Text = e.Item.Cells[8].Text.Trim().Replace("&nbsp;","");
					DDL_PROBABILITY_WHOLESALE.SelectedValue = e.Item.Cells[9].Text.Trim().Replace("&nbsp;","");
					if(a.ToString() == "&nbsp;")
					{
						RDO_PRIORITY_WHOLESALE.SelectedValue = null;
					}
					else
					{
						RDO_PRIORITY_WHOLESALE.SelectedValue = e.Item.Cells[11].Text.Trim();
					}
					if(b.ToString() == "&nbsp;")
					{
						RDO_ACTIONPLAN_WHOLESALE.SelectedValue = null;
					}
					else
					{
						RDO_ACTIONPLAN_WHOLESALE.SelectedValue = e.Item.Cells[13].Text.Trim();
					}
					break;

				case "delete":
					conn.QueryString = "DELETE AP_WHOLESALE_ALLIANCE WHERE SEQ='" + e.Item.Cells[0].Text.Trim() + "' AND [ID]='1' AND CIF#='" + TXT_CIF.Text + "' AND CIF#_SUBS='" + LBL_ID.Text + "'";
					conn.ExecuteQuery();

					FillGridWholesale();
					break;
			}
		}

		private void DGR_ALLIANCE_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					string a = e.Item.Cells[11].Text.Trim();
					string b = e.Item.Cells[13].Text.Trim();

					TXT_ID_ALLIANCE.Text = e.Item.Cells[0].Text.Trim();
					DDL_PRODUCT_SERVICE_ALLIANCE.SelectedValue = e.Item.Cells[3].Text.Trim().Replace("&nbsp;","");
					TXT_CLIENT_NEEDS_ALLIANCE.Text = e.Item.Cells[5].Text.Trim().Replace("&nbsp;","");
					TXT_OPPORTUNITY_DESC_ALLIANCE.Text = e.Item.Cells[6].Text.Trim().Replace("&nbsp;","");
					TXT_POTENSIAL_VOLUME_ALLIANCE.Text = e.Item.Cells[7].Text.Trim().Replace("&nbsp;","");
					TXT_POTENSIAL_INCOME_ALLIANCE.Text = e.Item.Cells[8].Text.Trim().Replace("&nbsp;","");	  
					DDL_PROBABILITY_ALLIANCE.SelectedValue = e.Item.Cells[9].Text.Trim().Replace("&nbsp;","");
					if(a.ToString() == "&nbsp;")
					{
						RDO_PRIORITY_ALLIANCE.SelectedValue = null;
					}
					else
					{
						RDO_PRIORITY_ALLIANCE.SelectedValue = e.Item.Cells[11].Text.Trim();
					}
					if(b.ToString() == "&nbsp;")
					{
						RDO_ACTIONPLAN_ALLIANCE.SelectedValue = null;
					}
					else
					{
						RDO_ACTIONPLAN_ALLIANCE.SelectedValue = e.Item.Cells[13].Text.Trim();
					}
					break;

				case "delete":
					conn.QueryString = "DELETE AP_WHOLESALE_ALLIANCE WHERE SEQ='" + e.Item.Cells[0].Text.Trim() + "' AND [ID]='2' AND CIF#='" + TXT_CIF.Text + "' AND CIF#_SUBS='" + LBL_ID.Text + "'";
					conn.ExecuteQuery();

					FillGridAlliance();
					break;
			}
		}

		private void DGR_OTHERS_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					string a = e.Item.Cells[11].Text.Trim();
					string b = e.Item.Cells[13].Text.Trim();

					TXT_ID_OTHERS.Text = e.Item.Cells[0].Text.Trim();
					DDL_PRODUCT_SERVICE_OTHERS.SelectedValue = e.Item.Cells[3].Text.Trim().Replace("&nbsp;","");
					TXT_CLIENT_NEEDS_OTHERS.Text = e.Item.Cells[5].Text.Trim().Replace("&nbsp;","");
					TXT_OPPORTUNITY_DESC_OTHERS.Text = e.Item.Cells[6].Text.Trim().Replace("&nbsp;","");
					TXT_POTENSIAL_VOLUME_OTHERS.Text = e.Item.Cells[7].Text.Trim().Replace("&nbsp;","");
					TXT_POTENSIAL_INCOME_OTHERS.Text = e.Item.Cells[8].Text.Trim().Replace("&nbsp;","");	  
					DDL_PROBABILITY_OTHERS.SelectedValue = e.Item.Cells[9].Text.Trim().Replace("&nbsp;","");
					if(a.ToString() == "&nbsp;")
					{
						RDO_PRIORITY_OTHERS.SelectedValue = null;
					}
					else
					{
						RDO_PRIORITY_OTHERS.SelectedValue = e.Item.Cells[11].Text.Trim();
					}
					if(b.ToString() == "&nbsp;")
					{
						RDO_ACTIONPLAN_OTHERS.SelectedValue = null;
					}
					else
					{
						RDO_ACTIONPLAN_OTHERS.SelectedValue = e.Item.Cells[13].Text.Trim();
					}
					break;

				case "delete":
					conn.QueryString = "DELETE AP_WHOLESALE_ALLIANCE WHERE SEQ='" + e.Item.Cells[0].Text.Trim() + "' AND [ID]='3' AND CIF#='" + TXT_CIF.Text + "' AND CIF#_SUBS='" + LBL_ID.Text + "'";
					conn.ExecuteQuery();

					FillGridOthers();
					break;
			}
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC AP_STRATEGY_COMPANY_INSERT '" + LBL_ID.Text + "','" + TXT_CLIENT_STRATEGY.Text + "','" + TXT_STRATEGY_OPTIMASI.Text + "'";
			conn.ExecuteQuery();

			CekStrategy();
		}
	}
}
