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

namespace SME.DCM.DataDictionary.Facilities.AssignmentAnalysisDataRequested
{
	/// <summary>
	/// Summary description for AssignmentList.
	/// </summary>
	public partial class AssignmentList : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				ViewData();

				DDL_REQ_MONTH.Items.Add(new ListItem("--Select--",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_REQ_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
			}
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT DISTINCT * FROM VW_SDC_FACILITIES_ASSIGNMENT_LIST ORDER BY SEQ";
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

				for (int i = 0; i < dg.Items.Count; i++)
				{
					dg.Items[i].Cells[2].Text = tools.FormatDate(dg.Items[i].Cells[2].Text, true);
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

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			DATA_GRID.CurrentPageIndex = 0;
			SearchData();
		}

		private void SearchData()
		{
			string query = "";

			if(TXT_REQ.Text != "")
			{
				query += "AND REQ_NUMBER LIKE '%" + TXT_REQ.Text + "%' ";
			}

			if (TXT_REQ_DAY.Text != "" && DDL_REQ_MONTH.SelectedValue != "" && TXT_REQ_YEAR.Text != "") 
			{
				if (!GlobalTools.isDateValid(TXT_REQ_DAY.Text, DDL_REQ_MONTH.SelectedValue, TXT_REQ_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Date Not Valid!");
					return;
				}
				else
				{
					query += "AND YEAR(REQ_DATE) = " + TXT_REQ_YEAR.Text + " AND MONTH(REQ_DATE) = " + DDL_REQ_MONTH.SelectedValue + " AND DAY(REQ_DATE) = " + TXT_REQ_DAY.Text + " ";
				}
			}

			if(query != "")
			{
				conn.QueryString = "SELECT DISTINCT * FROM VW_SDC_FACILITIES_ASSIGNMENT_LIST WHERE 1=1 " + query + "ORDER BY SEQ";
				BindData(DATA_GRID.ID.ToString(), conn.QueryString);
			}

			else
			{
				conn.QueryString = "SELECT DISTINCT * FROM VW_SDC_FACILITIES_ASSIGNMENT_LIST ORDER BY SEQ";
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
					Response.Redirect("AssignmentProcess.aspx?mc=" + Request.QueryString["mc"] + "&regno=" + e.Item.Cells[1].Text.Trim() + "&exist=1");
					break;
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			TXT_REQ.Text				= "";
			TXT_REQ_DAY.Text			= "";
			DDL_REQ_MONTH.SelectedValue	= "";
			TXT_REQ_YEAR.Text			= "";

			ViewData();
		}
	}
}
