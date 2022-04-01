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

namespace SME.HDRS
{
	/// <summary>
	/// Summary description for TrackList.
	/// </summary>
	public partial class TrackList : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			ViewData();
		}

		private void ViewData()
		{
			string prob=" ";
			prob = Request.QueryString["problem_type"] ;
			if (prob=="")
			{
				conn.QueryString = " select * from VW_HELPDESK_QA order by h_problem_type";
				conn.ExecuteQuery();
			}
			if (prob!="")
			{
				conn.QueryString = "select * from VW_HELPDESK_QA where h_problem_type='"+Request.QueryString["problem_type"]+"'";
				conn.ExecuteQuery();
			}
			FillGrid();
		}

		private void FillGrid()
		{				
			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_QA.DataSource = dt;
			try 
			{
				DGR_QA.DataBind();
			} 
			catch 
			{
				DGR_QA.CurrentPageIndex = 0;
				DGR_QA.DataBind();
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
			this.DGR_QA.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_QA_PageIndexChanged);

		}
		#endregion

		private void DGR_QA_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_QA.CurrentPageIndex = e.NewPageIndex;
			ViewData();	
		}
	}
}
