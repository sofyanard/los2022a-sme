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
	/// Summary description for PicResponEntry.
	/// </summary>
	public partial class PicResponEntry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbl_regnum;
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];			
			
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");			

			//this.TXT_TEMP.TextChanged += new System.EventHandler(this.TXT_TEMP_TextChanged);
			if (!IsPostBack)
			{
				this.BTN_ACQ.Click += new System.EventHandler(this.BTN_ACQ_Click);
				DDL_PROBLEM.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString="select * from rfproblem where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_PROBLEM.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				ViewDataUser();

				/*conn.QueryString="select * from HELPDESK_TRACK_HISTORY where HTH_HRS# = '" +Request.QueryString["regnum"]+ "' AND HTH_TRACKCODE='B2'";
				conn.ExecuteQuery();
				if(conn.GetRowCount()==0)
				{
					TR_ACQ.Visible = false;
				}*/

				conn.QueryString = " select * from VW_HELPDESK_APPTRACK_HISTORY where HTH_HRS# = '" +Request.QueryString["regnum"]+ "'";
				conn.ExecuteQuery();
				if(conn.GetFieldValue("HTH_TRACKCODE")!="B2")
				{
					BTN_SAVE.Enabled = false;
					BTN_ACQ.Enabled = false;
					BTN_UPDATE.Enabled = false;
				}

				//ViewACQ();
				//ViewAcqInfo2();
				ViewUploadFiles();
				ViewUploadFilesRespon();
				TR_SND.Visible = false;		
		
				conn.QueryString = "select * from helpdesk where H_HRS#='" +Request.QueryString["regnum"]+ "' ";
				conn.ExecuteQuery();
				TXT_SEND_TO.Text = conn.GetFieldValue("H_SEND_TO");
				TXT_SEND_BY.Text = conn.GetFieldValue("H_SEND_BY");

				ViewBtnLnkAcq();

				BTN_UPDATE.Enabled = false;
			}
			
			ViewAcqInfo2();
			ViewAkses();
			ViewMenu();
			
		}

		private void ViewAcqInfo2()
		{
			conn.QueryString = "select * from helpdesk where H_HRS#='" +Request.QueryString["regnum"]+ "' ";
			conn.ExecuteQuery();
			TXT_SEND_TO.Text = conn.GetFieldValue("H_SEND_TO");
			TXT_SEND_BY.Text = conn.GetFieldValue("H_SEND_BY");

			HyperLink acqInfo = new HyperLink();
			acqInfo.Text = "Acquire Information";
			acqInfo.Font.Bold = true;
			acqInfo.NavigateUrl = "ACQ2.aspx?regnum=" + TXT_HRS.Text + "&send_to=" + TXT_SEND_TO.Text + "&send_by=" + TXT_SEND_BY.Text; //+ "&sta=view";
			//Response.Write("<script for=window event=onload language='javascript'>PopupPage('ACQ.aspx?regnum=" + TXT_HRS.Text + "&send_to=" + TXT_SEND_TO.Text + "&send_by=" + TXT_SEND_BY.Text + "&theForm=Form1&theObj=TXT_TEMP', '800','350');</script>");			
			acqInfo.Target = "if2";

			conn.QueryString = "select * from VW_HELPDESK_APPTRACK_MASSAGE where H_HRS#='"+ TXT_HRS.Text +"' ";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("TRACK")=="B2")
			{
				Placeholder1.Controls.Add(acqInfo);
				Placeholder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));

				/***
				PlaceHolder1.Controls.Add(collateral_peal);
				PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				***/
			}
		}

		private void ViewBtnLnkAcq()
		{
			conn.QueryString = "select * from helpdesk_track_history where HTH_HRS#='"+ TXT_HRS.Text +"' and HTH_TRACKCODE='B2'";
			conn.ExecuteQuery();
			if (conn.GetRowCount()>= 3)
			{				
				//HL_ACCOUNT.Visible = true;
			}
		}

		private void ViewACQ()
		{
			conn.QueryString = "select * from VW_HELPDESK_APPTRACK_MASSAGE where H_HRS#='"+ TXT_HRS.Text +"' ";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("TRACK")=="B2")
			{			
				conn.QueryString = "select * from helpdesk where H_HRS#='" +Request.QueryString["regnum"]+ "' ";
				conn.ExecuteQuery();
				TXT_SEND_TO.Text = conn.GetFieldValue("H_SEND_TO");
				TXT_SEND_BY.Text = conn.GetFieldValue("H_SEND_BY");
				Response.Write("<script for=window event=onload language='javascript'>PopupPage('ACQ.aspx?regnum=" + TXT_HRS.Text + "&send_to=" + TXT_SEND_TO.Text + "&send_by=" + TXT_SEND_BY.Text + "&theForm=Form1&theObj=TXT_TEMP', '800','350');</script>");			
			}
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
			TXT_EMAIL.Text = conn.GetFieldValue("h_email");
			TXT_TELP.Text = conn.GetFieldValue("h_telp");

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
			this.DATA_EXPORT_RESPON.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_RESPON_ItemCommand);
			this.DATA_EXPORT_RESPON.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_EXPORT_RESPON_PageIndexChanged_1);

		}
		#endregion

		protected void UPLOAD_Click(object sender, System.EventArgs e)
		{
			//Cek Jumlah File
			/*conn.QueryString = "SELECT FILE_UPLOAD_HELPDESK_NAME_RESPON from [HELPDESK_FILE_UPLOAD_RESPON] where H_HRS# = '" +Request.QueryString["regnum"]+ "'";
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
				conn.QueryString = "EXEC HELPDESK_INSERT_FILE_UPLOAD_RESPON '" +Request.QueryString["regnum"]+ "', '" + Session["USERID"].ToString() + "','" +
					Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
				conn.ExecuteQuery();
			}


			//Get Export Properties
			/*conn.QueryString = "EXEC REKANAN_INSERT_FILE_UPLOAD '" +Request.QueryString["regnum"]+ "', '" + Session["USERID"].ToString() + "','" +
				Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
			conn.ExecuteQuery(); */

			conn.QueryString = "SELECT MAX(ID_UPLOAD_HELPDESK_RESPON) as MAX_ID from [HELPDESK_FILE_UPLOAD_RESPON]";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_HELPDESK_NAME_RESPON from [HELPDESK_FILE_UPLOAD_RESPON] where ID_UPLOAD_HELPDESK_RESPON = '" + max_id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_HELPDESK_NAME_RESPON");
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

			ViewUploadFilesRespon();		
		}

		private void deleteFile(string directory, string filename) 
		{
			if (File.Exists(directory + filename)) 
			{
				File.Delete(directory + filename);
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
				LinkButton HpDelete = (LinkButton) DATA_EXPORT_RESPON.Items[i-1].Cells[3].FindControl("UPL_HELPDESK_DELETE2");
				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_HELPDESK_NAME_RESPON");
			} 
		}

		private void DATA_EXPORT_RESPON_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_EXPORT_RESPON.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFilesRespon();
		}

		private void DATA_EXPORT_RESPON_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
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
					conn.QueryString = "EXEC HELPDESK_DELETE_FILEDH_UPLOAD_RESPON '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					deleteFile(directory, e.Item.Cells[1].Text);
					ViewUploadFilesRespon();
					break;
			}
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			ViewAkses();
			conn.QueryString = "SELECT FILE_UPLOAD_HELPDESK_NAME_RESPON from [HELPDESK_FILE_UPLOAD_RESPON] where H_HRS# = '" +Request.QueryString["regnum"]+ "'";
			conn.ExecuteQuery();			
			conn.QueryString = " exec HELPDESK_UPDADTE '" +
				Request.QueryString["regnum"] +"', '"+
				TXT_RESPON.Text +"', '"+
				conn.GetFieldValue("FILE_UPLOAD_HELPDESK_NAME_RESPON") +"' ";			
			conn.ExecuteQuery();

			BTN_UPDATE.Enabled = true;
		}
		
		private void ViewAkses()
		{			
			conn.QueryString = "select * from VW_HELPDESK_APPTRACK_HISTORY where HTH_HRS# = '"+ TXT_HRS.Text +"' ";
			conn.ExecuteQuery();
			if(conn.GetFieldValue("HTH_TRACKCODE")!="B2")
			{
				BTN_ACQ.Enabled = false;
				BTN_UPDATE.Enabled = false;
				Response.Redirect("ProblemList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
			}	
		}

		protected void BTN_ACQ_Click(object sender, System.EventArgs e)
		{	
			ViewAkses();
			Response.Write("<script for=window event=onload language='javascript'>PopupPage('ACQ.aspx?regnum=" + TXT_HRS.Text + "&send_to=" + HTH_PICTRACK.Text + "&send_by=" + TXT_SEND_BY.Text + "&theForm=Form1&theObj=TXT_TEMP', '800','350');</script>");			
		}		

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			ViewAkses();
			if (TXT_RESPON.Text=="")
			{
				GlobalTools.popMessage(this, "Isi terlebih dahulu Description kemudian klik Save!");
				return;	
			}
			conn.QueryString = "select * from helpdesk where H_HRS# = '" + TXT_HRS.Text + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("H_RESPON")=="" )
			{
				GlobalTools.popMessage(this, "Input data mandatory belum lengkap!");
				return;	
			}
			conn.QueryString = " exec HELPDESK_TRACKUPDATE '" +
				Request.QueryString["regnum"] +"', 'B3', '" + 
				HTH_PICTRACK.Text +"', '"+
				Session["UserID"].ToString()+" ', 'PENDING' ";	
			conn.ExecuteNonQuery();

			conn.QueryString = "exec HELPDESK_INSERT_MASSAGE '"+
				TXT_HRS.Text +"', '"+
				Session["UserID"].ToString()+"', '"+
				HTH_PICTRACK.Text +"', 'B3' , ' ' ";				
			conn.ExecuteNonQuery();

			Response.Redirect("ProblemList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ProblemList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void DATA_EXPORT_RESPON_PageIndexChanged_1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_EXPORT_RESPON.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFiles();
		}
		
	}
}
