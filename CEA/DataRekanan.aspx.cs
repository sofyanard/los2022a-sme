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
using Excel;
using System.IO;

namespace SME.CEA
{
	/// <summary>
	/// Summary description for DataRekanan.
	/// </summary>
	public partial class DataRekanan : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/../SME/Restricted.aspx");

			ViewMenu();
			ViewFileUpload();

			if(!IsPostBack)
			{
				ViewData();
			}
			CekView();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("InquiryRekanan.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		private void ViewData()
		{
			conn.QueryString = "select rekanantypeid from rekanan where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();

			if (conn.GetFieldValue("rekanantypeid")=="01")
			{
				conn.QueryString="select regnum, rekanandesc, namerekanan, pic_name, address1, address2, city, phone_area + '-' + phone# as phone from vw_rekanan_company where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
				conn.ExecuteQuery();

				TXT_REGNUM.Text = conn.GetFieldValue("regnum");
				TXT_JNS_REK.Text = conn.GetFieldValue("rekanandesc");
				TXT_REK_NAME.Text = conn.GetFieldValue("namerekanan");
				TXT_CP.Text = conn.GetFieldValue("pic_name");
				TXT_ADDRESS1.Text = conn.GetFieldValue("address1");
				TXT_ADDRESS2.Text = conn.GetFieldValue("address2");
				TXT_CITY.Text = conn.GetFieldValue("city");
				TXT_TELP.Text = conn.GetFieldValue("phone");
			}
			else
			{
				conn.QueryString="select regnum, rekanandesc, namerekanan, address1, address2, city, office_area + '-' + office# as phone from vw_rekanan_personal where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
				conn.ExecuteQuery();

				TXT_REGNUM.Text = conn.GetFieldValue("regnum");
				TXT_JNS_REK.Text = conn.GetFieldValue("rekanandesc");
				TXT_REK_NAME.Text = conn.GetFieldValue("namerekanan");
				TXT_ADDRESS1.Text = conn.GetFieldValue("address1");
				TXT_ADDRESS2.Text = conn.GetFieldValue("address2");
				TXT_CITY.Text = conn.GetFieldValue("city");
				TXT_TELP.Text = conn.GetFieldValue("phone");
			}
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '" + Request.QueryString["mc"] + "'";
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
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"] + "&view=" + Request.QueryString["view"];
						else	
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+ "&view=" + Request.QueryString["view"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i,3)+strtemp;
					MenuKeputusanMain.Controls.Add(t);
					MenuKeputusanMain.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void ViewFileUpload()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM REKANAN_RFEXPORT WHERE EXPORT_ID = 'REKANAN02'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}
			
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD_XLS, FILE_UPLOAD_XLS_NAME FROM REKANAN_FILE_UPLOAD_XLS where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
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
				HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("XLS_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[3].FindControl("XLS_DELETE");
				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_XLS_NAME");
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
			this.DATA_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_ItemCommand);

		}
		#endregion

		private void DATA_EXPORT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_EXPORT.CurrentPageIndex = e.NewPageIndex;
			ViewFileUpload();
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string directory = "";
			conn.QueryString = "SELECT EXPORT_URL FROM REKANAN_RFEXPORT WHERE EXPORT_ID = 'REKANAN02'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());
			}

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "EXEC REKANAN_DELETE_FILE_UPLOAD_XLS '" + e.Item.Cells[0].Text + "', '" +
						Request.QueryString["rekanan_ref"] + "'";
					conn.ExecuteQuery();
					deleteFile(directory, e.Item.Cells[1].Text);
					ViewFileUpload();
					break;
			}
		}	

		private void deleteFile(string directory, string filename) 
		{
			if (File.Exists(directory + filename)) 
			{
				File.Delete(directory + filename);
			}
		}

		private void CekView()
		{
			if(Request.QueryString["view"]=="1")
			{
				BTN_UPLOAD.Enabled = false;
				DATA_EXPORT.Columns[3].Visible = false;
			}
		}

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			conn.QueryString = "EXEC REKANAN_INSERT_FILE_XLS '" + 
				Request.QueryString["rekanan_ref"] + "', '" +
				Session["USERID"].ToString() + "', '" +
				Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_XLS) as MAX_ID from [REKANAN_FILE_UPLOAD_XLS] where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_XLS_NAME from [REKANAN_FILE_UPLOAD_XLS] where ID_UPLOAD_XLS = '" + max_id + "' and rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_XLS_NAME");
				//TXT_XLSNAME.Text = outputfilename;
			}

			conn.QueryString = "SELECT EXPORT_URL FROM REKANAN_RFEXPORT WHERE EXPORT_ID = 'REKANAN02'";
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
							//ViewFileUpload();
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
			}
			ViewFileUpload();
		}
	}
}
