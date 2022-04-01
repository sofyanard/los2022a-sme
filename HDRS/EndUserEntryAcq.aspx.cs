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
	/// Summary description for EndUserEntryAcq.
	/// </summary>
	public partial class EndUserEntryAcq : System.Web.UI.Page
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

				//ViewUserRespon();	
				conn.QueryString = "select a.groupid, b.sg_grpname from grpaccessmenu a left join scgroup b on a.groupid=b.groupid where a.menucode like 'b02'" ;
				conn.ExecuteQuery();
				DDL_PIC2.Items.Add(new ListItem("--Pilih--",""));
				DDL_PIC.Items.Add(new ListItem("--Pilih--",""));
				for (int i=0; i < conn.GetRowCount(); i++)
					DDL_PIC2.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));						

				ViewData();
				ViewUploadFiles();
				ViewACQ();

				BTN_SEND.Enabled = false;
			}	
				
		}

		private void ViewUserRespon()
		{
			conn.QueryString = "select userid, su_fullname from scuser where groupid in (select groupid from grpaccessmenu where menucode like 'b02')" ;
			conn.ExecuteQuery();

			DDL_PIC.Items.Add(new ListItem("--Pilih--",""));
			for (int i=0; i < conn.GetRowCount(); i++)
				DDL_PIC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		private void ViewACQ()
		{
			conn.QueryString = "select * from VW_HELPDESK_APPTRACK_MASSAGE where H_HRS#='"+ TXT_CODE.Text +"' ";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("TRACK")=="B1.1")
			{
				//TR_ACQ.Visible = true;
				Response.Write("<script for=window event=onload language='javascript'>PopupPage('ACQ.aspx?regnum=" + TXT_CODE.Text + "&send_to=" + DDL_PIC.SelectedValue + "&theForm=Form1&theObj=TXT_TEMP', '800','350');</script>");			
			}
		}

		private void ViewData()
		{
			conn.QueryString = "select * from helpdesk where h_hrs#='" +Request.QueryString["regnum"]+ "'";
			conn.ExecuteQuery();
			TXT_CODE.Text = conn.GetFieldValue("H_HRS#");
			TXT_TGL.Text = tool.FormatDate(conn.GetFieldValue("H_RECEIVED_DATE"));
			TXT_NO_AP.Text = conn.GetFieldValue("H_APP#");
			TXT_CUST.Text = conn.GetFieldValue("H_CUSTOMER");
			try{DDL_PROBLEM.SelectedValue = conn.GetFieldValue("H_PROBLEM_TYPE");}
			catch{DDL_PROBLEM.SelectedValue ="";}			
			DESC_TXT.Text = conn.GetFieldValue("H_PROBLEM");
			TXT_UNIT.Text = conn.GetFieldValue("h_unit");
			TXT_EMAIL.Text = conn.GetFieldValue("h_email");
			TXT_TELP.Text = conn.GetFieldValue("h_telp");
			
			try{DDL_PIC2.SelectedValue = conn.GetFieldValue("H_PIC_GROUP");}
			catch{DDL_PIC2.SelectedValue ="";}
			string pic="";
			pic = conn.GetFieldValue("H_SEND_TO");

			conn.QueryString = "select userid, su_fullname from scuser where groupid='" + DDL_PIC2.SelectedValue + "' order by su_fullname";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_PIC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			
			try{DDL_PIC.SelectedValue = pic ;}
			catch{DDL_PIC.SelectedValue ="";}	

			conn.QueryString = "select areaname from rfarea where areaid = '"+Session["AreaID"].ToString()+"'";
			conn.ExecuteQuery();
			TXT_AREA.Text = conn.GetFieldValue("areaname");	
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
			this.DATA_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_ItemCommand);
			this.DATA_EXPORT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_EXPORT_PageIndexChanged);

		}
		#endregion

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string directory = "";
			conn.QueryString = "SELECT EXPORT_URL FROM HELPDESK_RFEXPORT WHERE EXPORT_ID = 'daftar'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());
			}

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "EXEC HELPDESK_DELETE_FILEDH_UPLOAD '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					deleteFile(directory, e.Item.Cells[1].Text);
					ViewUploadFiles();
					break;
			}
		}

		private void DATA_EXPORT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_EXPORT.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFiles();
		}

		private void deleteFile(string directory, string filename) 
		{
			if (File.Exists(directory + filename)) 
			{
				File.Delete(directory + filename);
			}
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
			conn.QueryString = "SELECT ID_UPLOAD_HELPDESK, FILE_UPLOAD_HELPDESK_NAME FROM HELPDESK_FILE_UPLOAD where H_HRS# ='" +TXT_CODE.Text+ "'";
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
				LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[3].FindControl("UPL_HELPDESK_DELETE");
				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_HELPDESK_NAME");
			} 
		}

		protected void UPLOAD_Click(object sender, System.EventArgs e)
		{
			//Cek Jumlah File
			/*conn.QueryString = "SELECT FILE_UPLOAD_HELPDESK_NAME from [HELPDESK_FILE_UPLOAD] where H_HRS# = '" + TXT_CODE.Text + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() == 1)
			{
				GlobalTools.popMessage(this, "File telah diinput, harap delete file apabila ingin mengganti file baru!");
				return;	
			}*/

			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			if (TXT_FILE_UPLOAD.PostedFile.FileName == "")
			{
			}
			else
			{
				//Get Export Properties
				conn.QueryString = "EXEC HELPDESK_INSERT_FILE_UPLOAD '" +TXT_CODE.Text+ "', '" + Session["USERID"].ToString() + "','" +
					Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
				conn.ExecuteQuery();
			}


			//Get Export Properties
			/*conn.QueryString = "EXEC REKANAN_INSERT_FILE_UPLOAD '" +Request.QueryString["regnum"]+ "', '" + Session["USERID"].ToString() + "','" +
				Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
			conn.ExecuteQuery(); */

			conn.QueryString = "SELECT MAX(ID_UPLOAD_HELPDESK) as MAX_ID from [HELPDESK_FILE_UPLOAD]";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_HELPDESK_NAME from [HELPDESK_FILE_UPLOAD] where ID_UPLOAD_HELPDESK = '" + max_id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_HELPDESK_NAME");
			}

			conn.QueryString = "SELECT EXPORT_URL FROM helpdesk_rfexport WHERE EXPORT_ID = 'daftar'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());

				HttpFileCollection uploadedFiles = Request.Files;

				for (int i = 0; i < uploadedFiles.Count; i++)
				{
					HttpPostedFile userPostedFile = uploadedFiles[i];
					counter = i + 1;

					try
					{
						if (userPostedFile.ContentLength > 0)
						{
							userPostedFile.SaveAs(directory + outputfilename);

							LBL_STATUS.ForeColor = Color.Green;
							LBL_STATUSREPORT.ForeColor = Color.Green;
							LBL_STATUS.Text = "Upload Successful!";
							LBL_STATUSREPORT.Text = "<u>File #" + counter.ToString() + "</u><br>" + 
								"File Content Type: " + userPostedFile.ContentType + "<br>" + 
								"File Size: " + userPostedFile.ContentLength + " bytes<br>" + 
								"File Name: " + userPostedFile.FileName + "<br>" +
								"Location Where Saved: " + directory + outputfilename + "<p>";

							//View Upload File
							ViewUploadFiles();
							
						}
					}
					catch (Exception ex)
					{
						LBL_STATUS.ForeColor = Color.Red;
						LBL_STATUSREPORT.ForeColor = Color.Red;
						LBL_STATUS.Text = "Upload Failed!";
						LBL_STATUSREPORT.Text = ex.Message + "\n" + ex.StackTrace;
					}
				}

				try
				{
					//ReadExcel(directory + outputfilename);
				}
				catch {}
			}

			ViewUploadFiles();
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			TXT_NO_AP.Text = "";
			TXT_CUST.Text = "";
			DDL_PROBLEM.SelectedValue = "";
			DESC_TXT.Text = "";
			DDL_PIC.SelectedValue = "";
		}

		protected void BTN_SEND_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "select * from helpdesk where H_HRS# = '" + TXT_CODE.Text + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("H_APP#")=="" || conn.GetFieldValue("H_CUSTOMER")=="" || conn.GetFieldValue("H_PROBLEM_TYPE")=="" ||conn.GetFieldValue("H_SEND_TO")=="")
			{
				GlobalTools.popMessage(this, "Input data mandatory belum lengkap! Kemudian, klik SAVE untuk menyimpan data!");
				return;	
			}
			conn.QueryString = " exec HELPDESK_TRACKUPDATE '" +
				TXT_CODE.Text +"', 'B2', '" + 
				DDL_PIC.SelectedValue +"', '"+
				Session["UserID"].ToString()+" ', 'PENDING' ";	
			conn.ExecuteNonQuery();

			Response.Redirect("ListEndUserEntryAcq.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "SELECT FILE_UPLOAD_HELPDESK_NAME from [HELPDESK_FILE_UPLOAD] where H_HRS# = '" + TXT_CODE.Text + "'";
			conn.ExecuteQuery();
			conn.QueryString = " exec HELPDESK_INSERT '" +
				TXT_AREA.Text +"', '"+
				TXT_UNIT.Text +"', '"+
				TXT_CODE.Text +"', '"+
				//TXT_TGL_SERVER.Text +"', '"+
				TXT_NO_AP.Text +"', '"+
				TXT_CUST.Text +"', '"+
				Session["UserID"].ToString()+"', '"+
				DESC_TXT.Text +"', '"+
				DDL_PIC2.SelectedValue +"', '"+
				DDL_PIC.SelectedValue +"', '"+
				TXT_EMAIL.Text +"', '"+
				TXT_TELP.Text +"', '"+
				conn.GetFieldValue("FILE_UPLOAD_HELPDESK_NAME")+"', '"+ DDL_PROBLEM.SelectedValue +"', '0' ";
			conn.ExecuteNonQuery();

			BTN_SEND.Enabled = true;
		}

		private void ViewPic()
		{
			DDL_PIC.Items.Clear();
			DDL_PIC.Items.Add(new ListItem("- PILIH -", ""));
			
			conn.QueryString = "select userid, su_fullname from scuser where groupid='" + DDL_PIC2.SelectedValue + "' and su_active='1' order by su_fullname";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_PIC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		protected void DDL_PIC2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewPic();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ListEndUserEntryAcq.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}
	}
}
