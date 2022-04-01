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
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.CreditOperations.BIChecking
{
	/// <summary>
	/// Summary description for BICheckingList.
	/// </summary>
	public partial class BICheckingResultList : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn;
		protected Tools tool = new Tools();
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				/*
				// Munculkan pesan next step
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"] != null) 
					GlobalTools.popMessage(this, Request.QueryString["msg"]);
				*/

				bindData();
			}
			
			// Manually register the event-handling method for the PageIndexChanged 
			// event of the DataGrid control.
			DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
		}

		private void bindData()
		{
			DataTable dt = new DataTable();
			DataRow dr;
			//conn.QueryString = "SELECT AP_REGNO, CU_REF, NAME, AP_SIGNDATE, AP_RELMNGR "+
				//"FROM VW_CREOPR_BICHECK_RESULTLIST  where CBC_CODE = '" + Session["CBC"].ToString() + "'";
			/***
			 * modif oleh Yudi
			conn.QueryString = "SELECT AP_REGNO, CU_REF, NAME, AP_SIGNDATE, AP_RELMNGR "+
				"FROM VW_CREOPR_BICHECK_RESULTLIST  where BR_CCOBRANCH = '" + Session["BranchID"].ToString() + "'";
			***/
			string userID = (string) Session["UserID"];
			conn.QueryString = "SELECT AP_REGNO, CU_REF, NAME, AP_SIGNDATE, AP_RELMNGR "+
				"FROM VW_CREOPR_BICHECK_RESULTLIST  where BR_CCOBRANCH = '" + Session["BranchID"].ToString() + "' " +
				" and AP_REJECT = '0' and AP_CANCEL = '0' and BS_COOFFICER = '" + userID + "' order by " + LBL_SORTEXP.Text + " " + LBL_SORTTYPE.Text;

				//" and AP_REJECT = '0' and AP_CANCEL = '0' order by " + LBL_SORTEXP.Text + " " + LBL_SORTTYPE.Text;

			
			conn.ExecuteQuery();
			dt.Columns.Add(new DataColumn("AP_REGNO"));
			dt.Columns.Add(new DataColumn("CU_REF"));
			dt.Columns.Add(new DataColumn("NAME"));
			dt.Columns.Add(new DataColumn("AP_SIGNDATE"));
			dt.Columns.Add(new DataColumn("AP_RELMNGR"));
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				dr = dt.NewRow();
				for (int j = 0; j < conn.GetColumnCount(); j++)
				{
					dr[j] = conn.GetFieldValue(i,j);
				}
				dt.Rows.Add(dr);
			}
			DataGrid1.DataSource = new DataView(dt);
			try 
			{
				DataGrid1.DataBind();
			} 
			catch 
			{
				DataGrid1.CurrentPageIndex = 0;
				DataGrid1.DataBind();
			}

			for (int i = 0; i < DataGrid1.Items.Count; i++)
				DataGrid1.Items[i].Cells[3].Text = tool.FormatDate(DataGrid1.Items[i].Cells[3].Text, true);
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DataGrid1_SortCommand);

		}
		#endregion

		void Grid_Change(Object sender, DataGridPageChangedEventArgs e) 
		{
			// Set CurrentPageIndex to the page the user clicked.
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData();	
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "View":								
					// e.Item is the table row where the command is raised. For bound
					// columns, the value is stored in the Text property of a TableCell.
					string regno = e.Item.Cells[0].Text.Trim(),
						curef = e.Item.Cells[1].Text.Trim();
					string mc = Request.QueryString["mc"];
					Response.Redirect("BICheckingResultEntry.aspx?regno=" + regno + "&curef="+curef + "&mc=" + mc);
					break;

					// Add other cases here, if there are multiple ButtonColumns in 
					// the DataGrid control.
				default:
					// Do nothing.
					break;
			}

		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			bindData();
		}

		private void DataGrid1_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			LBL_SORTEXP.Text = e.SortExpression;
			if (LBL_SORTTYPE.Text == "ASC") LBL_SORTTYPE.Text = "DESC";
			else LBL_SORTTYPE.Text = "ASC";

			bindData();
		}
	}
}
