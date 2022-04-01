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

namespace SME.MAS.CollateralAdministration.PickUpSendCollateral
{
	/// <summary>
	/// Summary description for ListRequest.
	/// </summary>
	public partial class ListRequest : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				
				FillGridResult();
			}
		}

		private void FillGridResult()
		{
			conn.QueryString = "select * from VW_MAS_INPUT_NEW_COLLATERAL where trackcode = 'M1.6' and CA_NAME = '" + Session["UserID"].ToString() + "' ";
			conn.ExecuteQuery();
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_RESULT.DataSource = dt;
			try 
			{
				DGR_RESULT.DataBind();
			} 
			catch 
			{
				DGR_RESULT.CurrentPageIndex = 0;
				DGR_RESULT.DataBind();
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
			this.DGR_RESULT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_RESULT_ItemCommand);
			this.DGR_RESULT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_RESULT_PageIndexChanged);

		}
		#endregion

		private void DGR_RESULT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_RESULT.CurrentPageIndex = e.NewPageIndex;
			FillGridResult();
		}

		private void DGR_RESULT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":					
					Response.Redirect("UpdateRequestAgunan.aspx?sta=exist&acc_number=" + e.Item.Cells[0].Text + "&collateral_id=" + e.Item.Cells[2].Text + 
						"&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]+ 
						"&type=" + e.Item.Cells[3].Text + "&acc_status=" + e.Item.Cells[4].Text);
					break;
			}
		}
	}
}
