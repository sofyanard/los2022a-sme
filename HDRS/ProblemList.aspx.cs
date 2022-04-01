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

namespace SME.HDRS
{
	/// <summary>
	/// Summary description for ProblemList.
	/// </summary>
	public partial class ProblemList : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];			

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");
			conn.QueryString = "select * from VW_HELPDESK_LIST_PROBLEM where active='0' and H_SEND_TO='" + Session["UserID"].ToString() + "' and HTH_TRACKCODE='B2' ";
			conn.ExecuteQuery();
			FillGrid();
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
			this.DGR_PROBLEM.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_PROBLEM_ItemCommand);
			this.DGR_PROBLEM.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_PROBLEM_PageIndexChanged);

		}
		#endregion

		private void DGR_PROBLEM_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_PROBLEM.CurrentPageIndex = e.NewPageIndex;
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_PROBLEM.DataSource = dt;
			try 
			{
				DGR_PROBLEM.DataBind();
			} 
			catch 
			{
				DGR_PROBLEM.CurrentPageIndex = 0;
				DGR_PROBLEM.DataBind();
			}
			for (int i = 0; i < DGR_PROBLEM.Items.Count; i++)
			{
				DGR_PROBLEM.Items[i].Cells[1].Text = tool.FormatDate(DGR_PROBLEM.Items[i].Cells[1].Text, true);
			}
		}

		private void DGR_PROBLEM_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//string area="";	
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Continue":					
						Response.Redirect("PicResponEntry.aspx?sta=exist&regnum=" + e.Item.Cells[0].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
									
				break;
			}
		}
	}
}
