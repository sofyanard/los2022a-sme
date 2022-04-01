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
	/// Summary description for ListEndUserEntryAcq.
	/// </summary>
	public partial class ListEndUserEntryAcq : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];			
			conn.QueryString = "select * from VW_HELPDESK_LIST_ACQ where H_SEND_BY='" + Session["UserID"].ToString() + "'  ";
			conn.ExecuteQuery();
			FillGrid();
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_ACQ.DataSource = dt;
			try 
			{
				DGR_ACQ.DataBind();
			} 
			catch 
			{
				DGR_ACQ.CurrentPageIndex = 0;
				DGR_ACQ.DataBind();
			}
			for (int i = 0; i < DGR_ACQ.Items.Count; i++)
			{
				DGR_ACQ.Items[i].Cells[1].Text = tool.FormatDate(DGR_ACQ.Items[i].Cells[1].Text, true);
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
			this.DGR_ACQ.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_ACQ_ItemCommand);
			this.DGR_ACQ.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_ACQ_PageIndexChanged);

		}
		#endregion

		private void DGR_ACQ_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_ACQ.CurrentPageIndex = e.NewPageIndex;
		}

		private void DGR_ACQ_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Continue":					
					Response.Redirect("EndUserEntryAcq.aspx?sta=exist&regnum=" + e.Item.Cells[0].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);									
					break;
			}
		
		}
	}
}
