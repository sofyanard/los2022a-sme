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

namespace SME.IPPS.Process.ValidationSubmitIC
{
	/// <summary>
	/// Summary description for ValidationList.
	/// </summary>
	public partial class ValidationList : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../../SME/Restricted.aspx");

			if(!IsPostBack)
			{
				if ((Request.QueryString["msg"] != "") && (Request.QueryString["msg"] != null))
					GlobalTools.popMessage(this, Request.QueryString["msg"]);
				
				conn.QueryString = "select * from vw_ipps_initiationlist where CURRENT_TRACK='"+ Request.QueryString["tc"] + "'";
				conn.ExecuteQuery();
				FillGrid();
			}
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_validation_list.DataSource = dt;
			try 
			{
				DG_validation_list.DataBind();
			} 
			catch 
			{
				DG_validation_list.CurrentPageIndex = 0;
				DG_validation_list.DataBind();
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
			this.DG_validation_list.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_validation_list_ItemCommand);
			this.DG_validation_list.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_validation_list_PageIndexChanged);

		}
		#endregion

		private void DG_validation_list_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":	
					Response.Redirect("AssignToInternalControl.aspx?regno=" + e.Item.Cells[0].Text + "&tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"]+ "&unit=" + e.Item.Cells[2].Text + "&initdate=" + e.Item.Cells[1].Text);
					break;				
			}
		}

		private void DG_validation_list_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_validation_list.CurrentPageIndex = e.NewPageIndex;
		}
	}
}
