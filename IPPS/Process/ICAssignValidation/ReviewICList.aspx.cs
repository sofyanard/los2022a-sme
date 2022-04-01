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

namespace SME.IPPS.Process.ICAssignValidation
{
	/// <summary>
	/// Summary description for ReviewICList.
	/// </summary>
	public partial class ReviewICList : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../../SME/Restricted.aspx");

			if(!IsPostBack)
			{
				FillGrid();
			}
		}

		private void FillGrid()
		{
			conn.QueryString = "EXEC IPPS_ICASSIGNLIST '" + Session["UserID"].ToString() + "'";
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

		}
		#endregion

		private void dg_list_initiation_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":	
					Response.Redirect("AssignmentToPIC.aspx?regno=" + e.Item.Cells[0].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
					break;
			}
		}
	}
}
