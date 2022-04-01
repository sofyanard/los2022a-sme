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
	/// Summary description for CustomerList.
	/// </summary>
	public partial class CustomerList : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				FillDataGrid();
			}
		}

		private void FillDataGrid()
		{
			conn.QueryString = "SELECT DISTINCT * FROM VW_AP_CUSTOMER_LIST_TEMP";
			BindData(DATA_GRID.ID.ToString(), conn.QueryString);
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
			this.DATA_GRID.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_GRID_ItemCommand);
			this.DATA_GRID.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_GRID_PageIndexChanged);

		}
		#endregion

		protected void BTN_Find_Click(object sender, System.EventArgs e)
		{
			DATA_GRID.CurrentPageIndex = 0;
			SearchData();
		}

		private void SearchData()
		{
			string query = "";

			if(TXT_CIF.Text != "")
			{
				query += "AND CIF# = '" + TXT_CIF.Text + "' ";
			}
			if(TXT_CUST_NAME.Text != "")
			{
				query += "AND CUSTOMER_NAME LIKE '%" + TXT_CUST_NAME.Text + "%' ";
			}
			if(TXT_ADDRESS.Text != "")
			{
				query += "AND CUST_ADDRESS LIKE '%" + TXT_ADDRESS.Text + "%' ";
			}

			if(TXT_GROUP_NAME.Text != "")
			{
				query += "AND CUSTOMER_GROUP LIKE '%" + TXT_GROUP_NAME.Text +"%' ";
			}

			if(query != "")
			{
				conn.QueryString = "SELECT DISTINCT * FROM VW_AP_CUSTOMER_LIST_TEMP WHERE 1=1 " + query;
				BindData(DATA_GRID.ID.ToString(), conn.QueryString);
			}

			else
			{
				conn.QueryString = "SELECT DISTINCT * FROM VW_AP_CUSTOMER_LIST_TEMP";
				BindData(DATA_GRID.ID.ToString(), conn.QueryString);
			}
		}

		private void DATA_GRID_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_GRID.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void DATA_GRID_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "continue":
					Response.Redirect("DealAnalyzer.aspx?mc=" + Request.QueryString["mc"] + "&cif=" + e.Item.Cells[0].Text.Trim());
					break;
			}
		}
	}
}
