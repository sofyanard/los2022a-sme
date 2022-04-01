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
	/// Summary description for EndUserResult.
	/// </summary>
	public partial class EndUserResult : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");
			if (!IsPostBack)
			{
				DDL_PROBLEM.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString="select * from rfproblem where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_PROBLEM.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				ViewDataUser();
				conn.QueryString="select * from HELPDESK_TRACK_HISTORY where HTH_HRS# = '" +Request.QueryString["regnum"]+ "' AND HTH_TRACKCODE='B3'";
				conn.ExecuteQuery();
				if(conn.GetRowCount()>= 2)
				{
					//TR_ACQ.Visible = true;
					//HL_ACQ.Visible = true;
				}				
				ViewUploadFiles();
				ViewUploadFilesRespon();
				BindDataSLA();
			}	
			//BindDataSLA();

			/*if()
			{
				Response.Redirect("ResponList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
			}*/

			ViewAkses();
		}

		private void ViewDataUser()
		{
			conn.QueryString = "select * from helpdesk where H_HRS#='" +Request.QueryString["regnum"]+ "' ";
			conn.ExecuteQuery();
			TXT_AREA.Text = conn.GetFieldValue("H_AREA");
			TXT_UNIT.Text = conn.GetFieldValue("H_UNIT");
			TXT_HRS.Text = conn.GetFieldValue("H_HRS#");
			TXT_TGL.Text = tool.FormatDate(conn.GetFieldValue("H_RECEIVED_DATE"));
			TXT_NO_AP.Text = conn.GetFieldValue("H_APP#");
			TXT_CUST.Text = conn.GetFieldValue("H_CUSTOMER");
			DDL_PROBLEM.SelectedValue = conn.GetFieldValue("H_PROBLEM_TYPE");
			TXT_DESC.Text = conn.GetFieldValue("H_PROBLEM");
			TXT_RESPON.Text = conn.GetFieldValue("H_RESPON");
			TXT_SEND_BY.Text = conn.GetFieldValue("H_SEND_BY");
			conn.QueryString = "select * from VW_HELPDESK_APPTRACK_HISTORY where HTH_HRS#='" +Request.QueryString["regnum"]+ "' ";
			conn.ExecuteQuery();
			HTH_PICTRACK.Text = conn.GetFieldValue("HTH_STATUSBY");
		}

		private void ViewUploadFiles()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM helpdesk_rfexport WHERE EXPORT_ID = '" + "daftar" + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD_HELPDESK, FILE_UPLOAD_HELPDESK_NAME FROM HELPDESK_FILE_UPLOAD where H_HRS# ='" +Request.QueryString["regnum"]+ "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DATA_EXPORT.DataSource = dt;
			try 
			{
				DATA_EXPORT.DataBind();
			} 
			catch 
			{
				DATA_EXPORT.CurrentPageIndex = 0;
				DATA_EXPORT.DataBind();
			}
			for (int i = 1; i <= DATA_EXPORT.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("UPL_HELPDESK_DOWNLOAD");				
				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_HELPDESK_NAME");
			} 
		}

		private void ViewUploadFilesRespon()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM helpdesk_rfexport WHERE EXPORT_ID = '" + "daftar" + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD_HELPDESK_RESPON, FILE_UPLOAD_HELPDESK_NAME_RESPON FROM HELPDESK_FILE_UPLOAD_RESPON where H_HRS# ='" +Request.QueryString["regnum"]+ "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DATA_EXPORT_RESPON.DataSource = dt;
			try 
			{
				DATA_EXPORT_RESPON.DataBind();
			} 
			catch 
			{
				DATA_EXPORT_RESPON.CurrentPageIndex = 0;
				DATA_EXPORT_RESPON.DataBind();
			}
			for (int i = 1; i <= DATA_EXPORT_RESPON.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DATA_EXPORT_RESPON.Items[i-1].Cells[2].FindControl("UPL_HELPDESK_DOWNLOAD2");	
				
				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_HELPDESK_NAME_RESPON");
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
			this.DATA_EXPORT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_EXPORT_PageIndexChanged);
			this.DATA_EXPORT_RESPON.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_EXPORT_RESPON_PageIndexChanged);

		}
		#endregion

		private void DATA_EXPORT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_EXPORT.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFiles();
		}

		private void DATA_EXPORT_RESPON_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_EXPORT_RESPON.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFilesRespon();
		}

		protected void BTN_FINISH_Click(object sender, System.EventArgs e)
		{
			ViewAkses();
			conn.QueryString = " exec HELPDESK_TRACKUPDATE '" +
				Request.QueryString["regnum"] +"', 'B8', 'DONE', '"+			
				Session["UserID"].ToString()+" ', 'DONE' ";	
			conn.ExecuteQuery();
			conn.QueryString = " update helpdesk set active='1' where H_HRS# = '"+Request.QueryString["regnum"]+"' ";
			conn.ExecuteQuery();
			
			InsertHelpdeskSLA();
			
			Response.Redirect("ResponList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_ACQ_Click(object sender, System.EventArgs e)
		{
			ViewAkses();
			Response.Write("<script for=window event=onload language='javascript'>PopupPage('ACQ.aspx?regnum=" + TXT_HRS.Text + "&send_to=" + HTH_PICTRACK.Text + "&send_by=" + TXT_SEND_BY.Text + "&theForm=Form1&theObj=TXT_TEMP', '800','350');</script>");			
		}

		private void ViewAkses()
		{			
			conn.QueryString = "select * from VW_HELPDESK_APPTRACK_HISTORY where HTH_HRS# = '"+ TXT_HRS.Text +"' ";
			conn.ExecuteQuery();
			if(conn.GetFieldValue("HTH_TRACKCODE")!="B3")
			{
				BTN_ACQ.Enabled = false;
				BTN_FINISH.Enabled = false;
				Response.Redirect("ResponList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
			}	
		}
		
		private void BindDataSLA()
		{
			conn.QueryString = "select * from helpdesk_track_history where hth_hrs#='"+Request.QueryString["regnum"]+"' and hth_trackcode='B2' order by hth_trackdate ";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_SLA.DataSource = dt;
			try 
			{
				DGR_SLA.DataBind();
			}
			catch 
			{
				DGR_SLA.CurrentPageIndex = 0;
				DGR_SLA.DataBind();
			}
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_PIC.DataSource = dt;
			try 
			{
				DGR_PIC.DataBind();
			}
			catch 
			{
				DGR_PIC.CurrentPageIndex = 0;
				DGR_PIC.DataBind();
			}
		}

		private void InsertHelpdeskSLA()
		{
			//BindDataSLA();			
			for (int i=0;i<DGR_SLA.Items.Count;i++)
			{	
				conn.QueryString = " exec HELPDESK_SLA_INSERT '" +
						Request.QueryString["regnum"] +"', " + 
						tool.ConvertNum(DGR_SLA.Items[i].Cells[5].Text.Trim()) +", '"+						
						DGR_SLA.Items[i].Cells[3].Text.Trim() +"' ";	
				conn.ExecuteNonQuery();					
			}

			conn.QueryString = "select * from helpdesk_pic_assign where h_hrs#='"+Request.QueryString["regnum"]+"' ";
			conn.ExecuteQuery();
			FillGrid();
			if (conn.GetRowCount()!=0)
			{				
				HTH_TRACKBY1.Text = DGR_SLA.Items[0].Cells[3].Text.Trim();
				
				conn.QueryString = "select sum(selang) as SLA_TIME from HELPDESK_SLA where hth_trackby='"+HTH_TRACKBY1.Text+"' and hth_hrs#='"+Request.QueryString["regnum"]+"' ";
				conn.ExecuteQuery();
				string jumlahselang1="";
				jumlahselang1 = conn.GetFieldValue("SLA_TIME");

				conn.QueryString = " exec HELPDESK_INSERT_SLA_FIX '"+
					Request.QueryString["regnum"] +"', '" + 
					HTH_TRACKBY1.Text +"', '" + 
					jumlahselang1 +"' ";
				conn.ExecuteNonQuery();

				for (int i=0;i<DGR_PIC.Items.Count;i++)
				{					
					conn.QueryString = "select sum(selang) as SLA_TIME from HELPDESK_SLA where hth_trackby='"+DGR_PIC.Items[i].Cells[1].Text.Trim()+"' and hth_hrs#='"+Request.QueryString["regnum"]+"' ";
					conn.ExecuteQuery();

					conn.QueryString = " exec HELPDESK_INSERT_SLA_FIX '"+
							Request.QueryString["regnum"] +"', '" + 
							DGR_PIC.Items[i].Cells[1].Text.Trim() +"', '" + 
							conn.GetFieldValue("SLA_TIME") +"' ";
					conn.ExecuteNonQuery();						
				}
				
			}

			if (conn.GetRowCount() ==0)
			{
				conn.QueryString = "select sum(selang) as SLA_TIME from HELPDESK_SLA where hth_hrs#='"+Request.QueryString["regnum"]+"' ";
				conn.ExecuteQuery();

				conn.QueryString = " exec HELPDESK_INSERT_SLA_FIX '"+
					Request.QueryString["regnum"] +"', '" + 
					HTH_PICTRACK.Text +"', '" + 
					conn.GetFieldValue("SLA_TIME") +"' ";
				conn.ExecuteNonQuery();				
			}

			//update active dari helpdesk_sla_fix
			conn.QueryString = "select max(seq) as maxseq from helpdesk_sla_fix where hth_hrs#='"+Request.QueryString["regnum"]+"' ";
			conn.ExecuteQuery();
			string maxseq="";
			maxseq = conn.GetFieldValue("maxseq");
			conn.QueryString = " update helpdesk_sla_fix set active='1' where hth_hrs#='"+Request.QueryString["regnum"]+"' and seq='"+ maxseq +"' ";
			conn.ExecuteQuery();
			
		}

		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ViewAkses();
			GlobalTools.popMessage(this, "Klik Finish jika Helpdesk telah selesai. ");
			Response.Redirect("ResponList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_MENU_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ViewAkses();
			GlobalTools.popMessage(this, "Klik Finish jika Helpdesk telah selesai. ");
		}

		protected void BTN_LOGOUT_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ViewAkses();
			GlobalTools.popMessage(this, "Klik Finish jika Helpdesk telah selesai.");
		}
		
	}
}
