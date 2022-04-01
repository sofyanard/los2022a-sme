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

namespace SME.AccountPlanning.AccountPlanSetup
{
	/// <summary>
	/// Summary description for ActionPlan.
	/// </summary>
	public partial class ActionPlan : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			
			if(!IsPostBack)
			{
				ViewData();

				TR_COMPANY_HEADER.Visible	= false;
				TR_COMPANY_GRID.Visible		= false;
				TR_COMPANY_FIELD.Visible	= false;
				TR_COMPANY_BTN.Visible		= false;

				DDL_START_MONTH.Items.Add(new ListItem("--Select--", ""));
				DDL_DUE_MONTH.Items.Add(new ListItem("--Select--", ""));
				
				for (int i = 1; i <= 12; i++)
				{
					DDL_START_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_DUE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
				
				ViewCompany();
				FillDDLProduct();
				//FillDDLOpp();
			}
		}

		private void ViewMenu()
		{
			Menu.Controls.Clear();
			try 
			{
				conn.QueryString = "SELECT * FROM SCREENMENU WHERE MENUCODE = '" + Request.QueryString["mc"] + "'";
				conn.ExecuteQuery();
				
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "cif=" + Request.QueryString["cif"] + "&bs=" + Request.QueryString["bs"] + "&bc=" + Request.QueryString["bc"] + "&rd=" + Request.QueryString["rd"] + "&cd=" + Request.QueryString["cd"];
						else	
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&cif=" + Request.QueryString["cif"] + "&bs=" + Request.QueryString["bs"] + "&bc=" + Request.QueryString["bc"] + "&rd=" + Request.QueryString["rd"] + "&cd=" + Request.QueryString["cd"];
					}
					else 
					{
						strtemp = ""; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM AP_ANCHOR_INFO WHERE CIF#='" + Request.QueryString["cif"] + "' ORDER BY CONVERT(INT, CIF#)";
			conn.ExecuteQuery();

			TXT_CIF.Text				= conn.GetFieldValue("CIF#").ToString();
			TXT_CUST_NAME.Text			= conn.GetFieldValue("CUSTOMER_GROUP").ToString();
			TXT_ADDRESS.Text			= conn.GetFieldValue("CUST_ADDRESS").ToString();
			TXT_KOTA.Text				= conn.GetFieldValue("CUST_CITY").ToString();
			TXT_CUST_DATE.Text			= tools.FormatDate(conn.GetFieldValue("CUST_DATE").ToString());
			TXT_RM.Text					= conn.GetFieldValue("RM_NAME").ToString();
			TXT_GROUP_NAME.Text			= conn.GetFieldValue("GROUP_NAME").ToString();
			TXT_UNIT_NAME.Text			= conn.GetFieldValue("BUC").ToString();
			TXT_RELATIONSHIP.Text		= conn.GetFieldValue("CUST_LENGTH").ToString();
		}

		private void FillDDLProduct()
		{
			DDL_PRODUCT.Items.Clear();
			DDL_PRODUCT.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT ID_AP_VARIABLE, [DESCRIPTION] FROM AP_VARIABLE WHERE STATUS = '1'";
			conn.ExecuteQuery();
						
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_PRODUCT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		protected void DDL_PRODUCT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LBL_SEQ.Text					= "";
			TXT_OVERALL_PIC.Text			= "";
			TXT_ACTION_STEP.Text			= "";
			TXT_PIC.Text					= "";
			TXT_START_DAY.Text				= "";
			DDL_START_MONTH.SelectedValue	= "";
			TXT_START_YEAR.Text				= "";
			TXT_DUE_DAY.Text				= "";
			DDL_DUE_MONTH.SelectedValue		= "";
			TXT_DUE_YEAR.Text				= "";
			TXT_SUPPORT_REQUIRED.Text		= "";

			FillDDLOpp();
		}

		private void FillDDLOpp()
		{
			/*DDL_OPP_DESC.Items.Clear();
			DDL_OPP_DESC.Items.Add(new ListItem("--Select--", ""));

			if(DDL_COMPANY.SelectedValue == "" && DDL_PRODUCT.SelectedValue == "")
			{
				conn.QueryString = "SELECT OPPID, OPPDESC FROM AP_OPPORTUNITY_DESC";
				conn.ExecuteQuery();
			}
			else
			{
				conn.QueryString = "SELECT OPPID, OPPDESC FROM AP_OPPORTUNITY_DESC WHERE CIF='" + DDL_COMPANY.SelectedValue + "' AND PRODUCTID = '" + DDL_PRODUCT.SelectedValue + "'";
				conn.ExecuteQuery();
			}

			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_OPP_DESC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}*/

			conn.QueryString = "SELECT OPPDESC1 FROM AP_OPPORTUNITY_TARGET WHERE CIF='" + DDL_COMPANY.SelectedValue + "' AND PRODUCTID = '" + DDL_PRODUCT.SelectedValue + "'";
			conn.ExecuteQuery();

			TXT_OPP_DESC.Text		= conn.GetFieldValue("OPPDESC1").ToString().Replace("&nbsp;","");
		}

		private void ViewCompany()
		{
			DDL_COMPANY.Items.Clear();
			DDL_COMPANY.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT CIF_CUST, CUSTOMER_NAME FROM AP_COMPANY_INFO WHERE CIF_GROUP='" + TXT_CIF.Text + "'";
			conn.ExecuteQuery();
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_COMPANY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		protected void DDL_COMPANY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DDL_COMPANY.SelectedValue == "")
			{
				TR_COMPANY_HEADER.Visible	= false;
				TR_COMPANY_GRID.Visible		= false;
				TR_COMPANY_FIELD.Visible	= false;
				TR_COMPANY_BTN.Visible		= false;
				ClearData();
			}
			else
			{
				TR_COMPANY_HEADER.Visible	= true;
				TR_COMPANY_GRID.Visible		= true;
				TR_COMPANY_FIELD.Visible	= true;
				TR_COMPANY_BTN.Visible		= true;
				LBL_COMPANY_HEADER.Text		= DDL_COMPANY.SelectedItem.ToString();
				
				FillGridCompany();
				ClearData();
				
				FillDDLOpp();
				//Selected Opportunity Description by Company
				/*DDL_OPP_DESC.Items.Clear();
				DDL_OPP_DESC.Items.Add(new ListItem("--Select--", ""));
				
				conn.QueryString = "SELECT OPPID, OPPDESC FROM AP_OPPORTUNITY_DESC WHERE CIF='" + DDL_COMPANY.SelectedValue + "'";
				conn.ExecuteQuery();

				for(int i=0; i < conn.GetRowCount(); i++)
				{
					DDL_OPP_DESC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}*/
			}
		}

		private void FillGridCompany()
		{
			conn.QueryString = "SELECT * FROM AP_ACTION_COMPANY WHERE CIF='" + DDL_COMPANY.SelectedValue + "'";
			BindData(DGR_COMPANY.ID.ToString(), conn.QueryString);
		}

		private void DGR_COMPANY_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_COMPANY.CurrentPageIndex = e.NewPageIndex;
			FillGridCompany();
		}

		private void DGR_COMPANY_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					conn.QueryString = "SELECT * FROM AP_ACTION_COMPANY WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "'";
					conn.ExecuteQuery();

					LBL_SEQ.Text					= e.Item.Cells[0].Text.Trim();
					DDL_PRODUCT.SelectedValue		= conn.GetFieldValue("PRODUCTID").ToString().Replace("&nbsp;","");
					TXT_OVERALL_PIC.Text			= conn.GetFieldValue("PIC_TEAM").ToString().Replace("&nbsp;","");
					TXT_ACTION_STEP.Text			= conn.GetFieldValue("ACTION_STEP").ToString().Replace("&nbsp;","");
					/*
					FillDDLOpp();
					conn.QueryString = "SELECT * FROM AP_ACTION_COMPANY WHERE SEQ = '" + LBL_SEQ.Text + "'";
					conn.ExecuteQuery();
					DDL_OPP_DESC.SelectedValue		= conn.GetFieldValue("OPPORTUNITYID").ToString().Replace("&nbsp;","");
					*/
					TXT_OPP_DESC.Text				= conn.GetFieldValue("OPPORTUNITYDESC").ToString().Replace("&nbsp;","");
					TXT_PIC.Text					= conn.GetFieldValue("PIC_NAME").ToString().Replace("&nbsp;","");
					TXT_START_DAY.Text				= tools.FormatDate_Day(conn.GetFieldValue("START_DATE").ToString().Replace("&nbsp;",""));
					DDL_START_MONTH.SelectedValue	= tools.FormatDate_Month(conn.GetFieldValue("START_DATE").ToString().Replace("&nbsp;",""));
					TXT_START_YEAR.Text				= tools.FormatDate_Year(conn.GetFieldValue("START_DATE").ToString().Replace("&nbsp;",""));
					TXT_DUE_DAY.Text				= tools.FormatDate_Day(conn.GetFieldValue("DUE_DATE").ToString().Replace("&nbsp;",""));
					DDL_DUE_MONTH.SelectedValue		= tools.FormatDate_Month(conn.GetFieldValue("DUE_DATE").ToString().Replace("&nbsp;",""));
					TXT_DUE_YEAR.Text				= tools.FormatDate_Year(conn.GetFieldValue("DUE_DATE").ToString().Replace("&nbsp;",""));
					TXT_SUPPORT_REQUIRED.Text		= conn.GetFieldValue("SUPPORT_DESC").ToString().Replace("&nbsp;","");
					break;

				case "delete":
					conn.QueryString = "DELETE AP_ACTION_COMPANY WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "'";
					conn.ExecuteQuery();

					FillGridCompany();
					break;
			}
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if (TXT_START_DAY.Text != "" && DDL_START_MONTH.SelectedValue != "" && TXT_START_YEAR.Text != "") 
			{
				if (!GlobalTools.isDateValid(TXT_START_DAY.Text, DDL_START_MONTH.SelectedValue, TXT_START_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Start Date Not Valid!");
					return;
				}
			}

			if (TXT_DUE_DAY.Text != "" && DDL_DUE_MONTH.SelectedValue != "" && TXT_DUE_YEAR.Text != "") 
			{
				if (!GlobalTools.isDateValid(TXT_DUE_DAY.Text, DDL_DUE_MONTH.SelectedValue, TXT_DUE_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Due Date Not Valid!");
					return;
				}
			}

			try
			{
				conn.QueryString = "EXEC AP_ACTION_COMPANY_INSERT '" +
									LBL_SEQ.Text + "','" +
									DDL_COMPANY.SelectedValue + "','" +
									DDL_PRODUCT.SelectedValue + "','" +
									TXT_OVERALL_PIC.Text + "','" +
									TXT_ACTION_STEP.Text + "','" +
									//DDL_OPP_DESC.SelectedValue + "','" +
									TXT_OPP_DESC.Text + "','" +
									TXT_PIC.Text + "'," +
									tools.ConvertDate(TXT_START_DAY.Text, DDL_START_MONTH.SelectedValue, TXT_START_YEAR.Text) + "," +
									tools.ConvertDate(TXT_DUE_DAY.Text, DDL_DUE_MONTH.SelectedValue, TXT_DUE_YEAR.Text) + ",'" +
									TXT_SUPPORT_REQUIRED.Text + "'";
				conn.ExecuteQuery();
			}

			catch(Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
			
			//ClearData();
			FillGridCompany();
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

		private void ClearData()
		{
			LBL_SEQ.Text					= "";
			DDL_PRODUCT.SelectedValue		= "";
			TXT_OVERALL_PIC.Text			= "";
			TXT_ACTION_STEP.Text			= "";
			//DDL_OPP_DESC.SelectedValue	= "";
			TXT_OPP_DESC.Text				= "";
			TXT_PIC.Text					= "";
			TXT_START_DAY.Text				= "";
			DDL_START_MONTH.SelectedValue	= "";
			TXT_START_YEAR.Text				= "";
			TXT_DUE_DAY.Text				= "";
			DDL_DUE_MONTH.SelectedValue		= "";
			TXT_DUE_YEAR.Text				= "";
			TXT_SUPPORT_REQUIRED.Text		= "";
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../ActionPlan/CustomerList.aspx?mc=" + Request.QueryString["mc"]);
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

		}
		#endregion
	}
}
