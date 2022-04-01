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
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;
using DMS.BlackList;


namespace SME.IPPS.Process.ReviewCompiling
{
	/// <summary>
	/// Summary description for ReviewReceivedList.
	/// </summary>
	public partial class ReviewReceivedList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DATA_GRID;
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
			conn.QueryString = "SELECT * FROM VW_IPPS_INITIATIONLIST WHERE CURRENT_TRACK = '" + Request.QueryString["tc"] + 
				"' AND OWNER_ID = '" + Session["UserID"].ToString() + "' ORDER BY INIT_DATE";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			dg_list_initiation.DataSource = dt;

			try
			{
				dg_list_initiation.DataBind();
			}
			catch
			{
				dg_list_initiation.CurrentPageIndex = dg_list_initiation.PageCount - 1;
				dg_list_initiation.DataBind();
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
			this.dg_list_initiation.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dg_list_initiation_ItemCommand);
			this.dg_list_initiation.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dg_list_initiation_PageIndexChanged);

		}
		#endregion

		private void dg_list_initiation_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":	
						Response.Redirect("ReviewRetrieve.aspx?regno=" + e.Item.Cells[0].Text + "&unit=" + e.Item.Cells[2].Text + 
						"&initdate=" + e.Item.Cells[1].Text
						+ "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
					break;				
			}
		}

		private void dg_list_initiation_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dg_list_initiation.CurrentPageIndex = e.NewPageIndex;
		}
	}
}
