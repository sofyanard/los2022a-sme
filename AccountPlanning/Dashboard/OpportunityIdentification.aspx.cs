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

namespace SME.AccountPlanning.Dashboard
{
	/// <summary>
	/// Summary description for OpportunityIdentification.
	/// </summary>
	public partial class OpportunityIdentification : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				FillDDLSegment();
				FillDDLUnit();

				conn.QueryString = "SELECT * FROM VW_AP_ANCHOR_INFORMATION";
				BindData(DGR_ANCHOR_INFORM.ID.ToString(), conn.QueryString);
			}
		}

		private void FillDDLSegment()
		{
			DDL_SEGMENT.Items.Clear();
			DDL_SEGMENT.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT BUSSUNITID, BUSSUNITDESC FROM RFBUSINESSUNIT WHERE ACTIVE='1' ORDER BY BUSSUNITID";
			conn.ExecuteQuery();
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_SEGMENT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLUnit()
		{
			DDL_UNIT .Items.Clear();
			DDL_UNIT.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH WHERE ACTIVE='1'";
			conn.ExecuteQuery();
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
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
			this.DGR_ANCHOR_INFORM.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_ANCHOR_INFORM_ItemCommand);
			this.DGR_ANCHOR_INFORM.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_ANCHOR_INFORM_PageIndexChanged);

		}
		#endregion

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			DGR_ANCHOR_INFORM.CurrentPageIndex = 0;
			SearchData();
		}

		private void SearchData()
		{
			string query = "";

			if(DDL_SEGMENT.SelectedValue != "")
			{
				query += "AND BUSSUNITID = '" + DDL_SEGMENT.SelectedValue + "' ";
			}
			if(DDL_UNIT.SelectedValue != "")
			{
				query += "AND BUC = '" + DDL_UNIT.SelectedValue + "' ";
			}

			if(query != "")
			{
				conn.QueryString = "SELECT * FROM VW_AP_ANCHOR_INFORMATION WHERE 1=1 " + query;
				BindData(DGR_ANCHOR_INFORM.ID.ToString(), conn.QueryString);
			}

			else
			{
				conn.QueryString = "SELECT * FROM VW_AP_ANCHOR_INFORMATION";
				BindData(DGR_ANCHOR_INFORM.ID.ToString(), conn.QueryString);
			}
		}

		private void DGR_ANCHOR_INFORM_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_ANCHOR_INFORM.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void DGR_ANCHOR_INFORM_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					Response.Redirect("CompanyTree.aspx?mc=" + Request.QueryString["mc"] + "&cif=" + e.Item.Cells[0].Text.Trim());
					break;
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("AccountPlanBoard.aspx?mc=AP03");
		}
	}
}
