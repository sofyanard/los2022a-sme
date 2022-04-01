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
using DMS.DBConnection;
using DMS.CuBESCore;
using Microsoft.VisualBasic;

namespace SME.LMS
{
	/// <summary>
	/// Summary description for PorInquiryStatus.
	/// </summary>
	public partial class PorInquiryStatus : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				GlobalTools.fillRefList(DDL_CU_RM,"SELECT USERID, USERNAME FROM VW_PORLMS_INQSTATUS_FILLDDLRM ORDER BY USERID",false,conn);
			}
		}

		private void SearchApp()
		{
			conn.QueryString = "EXEC PORLMS_INQSTATUS_SEARCHAPP '" +
				TXT_LMSREG.Text + "', '" +
				Session["UserID"].ToString() + "', '" +
				DDL_CU_RM.SelectedValue + "'";
			conn.ExecuteQuery();
			
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_APP.DataSource = dt;
			try 
			{
				DG_APP.DataBind();
			} 
			catch 
			{
				DG_APP.CurrentPageIndex = 0;
				DG_APP.DataBind();
			}
		}

		private void InquiryTrack(string lmsreg)
		{
			conn.QueryString = "EXEC PORLMS_INQSTATUS_INQTRACK '" + lmsreg + "'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_TRACK.DataSource = dt;
			try 
			{
				DG_TRACK.DataBind();
			} 
			catch 
			{
				DG_TRACK.CurrentPageIndex = 0;
				DG_TRACK.DataBind();
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
			this.DG_APP.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_APP_ItemCommand);
			this.DG_APP.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_APP_PageIndexChanged);
			this.DG_TRACK.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_TRACK_PageIndexChanged);

		}
		#endregion

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			SearchApp();
			DG_APP.Visible = true;
			DG_TRACK.Visible = false;
			LBL_APREGNO.Text = "";
			LBL_APREGNO.Visible = false;
		}

		protected void btn_clear_Click(object sender, System.EventArgs e)
		{
			TXT_LMSREG.Text = "";
			try {DDL_CU_RM.SelectedValue = "";} 
			catch {}
		}

		private void DG_TRACK_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_TRACK.CurrentPageIndex = e.NewPageIndex;
			InquiryTrack(LBL_APREGNO.Text.Trim());
		}

		private void DG_APP_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_APP.CurrentPageIndex = e.NewPageIndex;
			SearchApp();
		}

		private void DG_APP_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
					InquiryTrack(e.Item.Cells[0].Text.Trim());
					DG_APP.Visible = false;
					DG_TRACK.Visible = true;
					LBL_APREGNO.Visible = true;
					LBL_APREGNO.Text = e.Item.Cells[0].Text.Trim();
					break;
			}
		}
	}
}
