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
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;


namespace SME.IPPS.Process.FinalDraftEntry
{
	/// <summary>
	/// Summary description for WGList.
	/// </summary>
	public partial class WGList : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				Fillgrid();
			}
		}

		private void Fillgrid()
		{
			conn.QueryString="select * from ipps_application where CURRENT_TRACK='PP7.0'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			dg_list_initiation.DataSource = dt;
			try 
			{
				dg_list_initiation.DataBind();
			} 
			catch 
			{
				dg_list_initiation.CurrentPageIndex = 0;
				dg_list_initiation.DataBind();
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
			this.dg_list_initiation.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dg_list_initiation_ItemCommand);
			this.dg_list_initiation.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dg_list_initiation_ItemDataBound);

		}
		#endregion

		private void dg_list_initiation_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{			
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "view":					
					Response.Redirect("ApprovalMethodInfo.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] 
						+ "&regno=" + e.Item.Cells[0].Text.Trim());					
					break;
			}
		}

		private void dg_list_initiation_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) 
			{
				e.Item.Cells[1].Text=tool.FormatDate(e.Item.Cells[1].Text);
			}
		}
	}
}
