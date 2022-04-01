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

namespace SME.IPPS.Process.ReviewApproval
{
	/// <summary>
	/// Summary description for ReviewApprovalList.
	/// </summary>
	public partial class ReviewApprovalList : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			if (!IsPostBack)
			{
				PopulateGrid();
			}
		}

		private void PopulateGrid()
		{
			conn.QueryString="exec IPPS_Review_Approval_List '" + Session["BranchID"].ToString() + "'";
			
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			DATA_GRID.DataSource = dt;

			try
			{
				DATA_GRID.DataBind();
			}
			catch
			{
				DATA_GRID.CurrentPageIndex = DATA_GRID.PageCount - 1;
				DATA_GRID.DataBind();
			}

			conn.ClearData();
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

		private void DATA_GRID_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "continue":	
					Response.Redirect("ReviewApprovalMain.aspx?regno=" + e.Item.Cells[2].Text + "&tc=" + Request.QueryString["tc"] 
						+ "&mc=" + Request.QueryString["mc"]
						+ "&reqseq=" + e.Item.Cells[0].Text
						+ "&revseq=" + e.Item.Cells[1].Text
						+ "&initdate=" + e.Item.Cells[3].Text
						+ "&unit=" + e.Item.Cells[4].Text
						+ "&reviewer="+ e.Item.Cells[5].Text
						+ "&validator="+ e.Item.Cells[7].Text
						+ "&codate="+ e.Item.Cells[9].Text);
					break;				
			}
		}

		private void DATA_GRID_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_GRID.CurrentPageIndex = e.NewPageIndex;
		}
	}
}
