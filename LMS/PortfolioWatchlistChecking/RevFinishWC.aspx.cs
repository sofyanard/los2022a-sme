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
using DMS.DBConnection;
using DMS.CuBESCore;
using DMS.BlackList;
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;

namespace SME.LMS.PortfolioWatchlistChecking
{
	/// <summary>
	/// Summary description for RevFinishWC.
	/// </summary>
	public partial class RevFinishWC : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			/*if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx"); */
			
			if (!IsPostBack)
			{
				conn.QueryString = "select * from VW_PORTFOLIO_WC_USER_HISTORY where trackcode='P4' and por_tracknextby='" + Session["UserID"].ToString() +"'";	
				conn.ExecuteQuery();
				
				FillGrid();
			}
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = 0;
				DatGrd.DataBind();
			}
			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				DatGrd.Items[i].Cells[3].Text = tool.FormatDate(DatGrd.Items[i].Cells[3].Text, true);
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);

		}
		#endregion

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			DatGrd.CurrentPageIndex = 0;
			SearchData();
		}

		private void SearchData()
		{
			string query=""; 
			
			if(TXT_NOTA.Text!="")
			{
				query += "and no_nota LIKE '%" + TXT_NOTA.Text + "%' ";
			}
			if(TXT_LMS.Text!="")
			{
				query += "and no_lms='" + TXT_LMS.Text + "' ";
			}				

			if(query!="")
			{
				conn.QueryString="select * from VW_PORTFOLIO_WC_USER_HISTORY where trackcode='P4' and por_tracknextby='" + Session["UserID"].ToString() +"'" + query;
				conn.ExecuteQuery();
				FillGrid();
			}
			else
			{
				conn.QueryString="select * from VW_PORTFOLIO_WC_USER_HISTORY where trackcode='P4' and por_tracknextby='" + Session["UserID"].ToString() +"'";	
				conn.ExecuteQuery();
				FillGrid();
			}
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":	
					conn.QueryString = "select * from VW_PORTFOLIO_WC_APPTRACK_HISTORY where no_lms='" + e.Item.Cells[2].Text + "'";
					conn.ExecuteQuery();
					
					Response.Redirect("GenInfoWatchlist4.aspx?sta=exist&porlmsregno=" + e.Item.Cells[2].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&flag=1");					
								
					break;
			}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

	}
}
