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
using Excel;
using System.IO;

namespace SME.CEA
{
	/// <summary>
	/// Summary description for AnalisaMain.
	/// </summary>
	public partial class AnalisaMain : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.HtmlControls.HtmlInputFile File2;
		protected System.Web.UI.HtmlControls.HtmlInputFile File1;
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			ViewMenu();
			//BTN_UPLOAD.Click += new System.EventHandler(this.BTN_UPLOAD_Click);
			BTN_UPDATE.Attributes.Add("onclick","if(!update()){return false;};");

			conn.QueryString = "select ap_currtrack from rekanan_apptrack where regnum='" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();

			//string tes = conn.GetFieldValue("ap_currtrack");

			if (conn.GetFieldValue("ap_currtrack") != "A1.3")
				BTN_UPDATE.Enabled = false;
			else
				BTN_UPDATE.Enabled = true;

			if(!IsPostBack)
			{
				ViewData();
				viewGridExcel();
				ViewFileUpload();
			}

			//this.BTN_UPLOAD.Click += new System.EventHandler(this.BTN_UPLOAD_Click);
			
		}

		private void ViewData()
		{
			conn.QueryString = "select isnull(acqinfo,'') from application_rekanan where regnum='" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();

			string ISACQINFO = conn.GetFieldValue(0,0).ToString().Trim();

			conn.QueryString = "select rekanantypeid from rekanan where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();

			if (conn.GetFieldValue("rekanantypeid")=="01")
			{
				conn.QueryString="select regnum, rekanandesc, namerekanan, pic_name, address1, address2, city, phone_area + '-' + phone# as phone from vw_rekanan_company where regnum='" + Request.QueryString["regnum"] + "'";
				conn.ExecuteQuery();

				TXT_REGNUM.Text = conn.GetFieldValue("regnum");
				TXT_JNS_REK.Text = conn.GetFieldValue("rekanandesc");
				TXT_NAMA_REK.Text = conn.GetFieldValue("namerekanan");
				TXT_CP.Text = conn.GetFieldValue("pic_name");
				TXT_ADDRESS1.Text = conn.GetFieldValue("address1");
				TXT_ADDRESS2.Text = conn.GetFieldValue("address2");
				TXT_CITY.Text = conn.GetFieldValue("city");
				TXT_NOTLP.Text = conn.GetFieldValue("phone");
			}
			else
			{
				conn.QueryString="select regnum, rekanandesc, namerekanan, address1, address2, city, office_area + '-' + office# as phone from vw_rekanan_personal where regnum='" + Request.QueryString["regnum"] + "'";
				conn.ExecuteQuery();

				TXT_REGNUM.Text = conn.GetFieldValue("regnum");
				TXT_JNS_REK.Text = conn.GetFieldValue("rekanandesc");
				TXT_NAMA_REK.Text = conn.GetFieldValue("namerekanan");
				TXT_ADDRESS1.Text = conn.GetFieldValue("address1");
				TXT_ADDRESS2.Text = conn.GetFieldValue("address2");
				TXT_CITY.Text = conn.GetFieldValue("city");
				TXT_NOTLP.Text = conn.GetFieldValue("phone");
			}

			LBL_REGNUM.Text = Request.QueryString["regnum"];
			LBL_REKANANREF.Text = Request.QueryString["rekanan_ref"];

			//--- Link Acquire Information ---
			HyperLink acqInfo = new HyperLink();
			acqInfo.Text = "Acquire Information";
			acqInfo.Font.Bold = true;
			acqInfo.NavigateUrl = "AcqInfoRekanan.aspx?regnum=" + LBL_REGNUM.Text + "&rekanan_ref=" + LBL_REKANANREF.Text + "&sta=view";
			acqInfo.Target = "if2";

			if (ISACQINFO != "")
			{
				Placeholder2.Controls.Add(acqInfo);
				//PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
			}
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"' and sm_id not in ('A010303')";
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
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"]+ "&exist=1";
						else	
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+ "&exist=1";
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

		private void viewGridExcel()
		{
			string url = "";
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_TEMPLATE_REKANAN, NAMA_TEMPLATE_REKANAN, LINK_TEMPLATE_REKANAN FROM REKANAN_TEMPLATE";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("LINK_TEMPLATE_REKANAN");
			}

			dt = conn.GetDataTable().Copy();
			DATA_TEMPLATE.DataSource = dt;
			try 
			{
				DATA_TEMPLATE.DataBind();
			} 
			catch 
			{
				DATA_TEMPLATE.CurrentPageIndex = 0;
				DATA_TEMPLATE.DataBind();
			}
			for (int i = 1; i <= DATA_TEMPLATE.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DATA_TEMPLATE.Items[i-1].Cells[2].FindControl("HP_DOWNLOAD");
				HpDownload.NavigateUrl = url;
			}
			/*string a = "MCG-F";
			conn.QueryString = "select '1.' as cnt, xls_view, location from rekanan_excel_template where lg_code ='" + a + "'";
			conn.ExecuteQuery();
			DATA_TEMPLATE.DataSource = conn.GetDataTable().Copy();
			DATA_TEMPLATE.DataBind();
			for(int i = 0; i < DATA_TEMPLATE.Items.Count; i++)
			{
				DATA_TEMPLATE.Items[i].Cells[0].Text = (DATA_TEMPLATE.Items[i].DataSetIndex+1).ToString()+".";
				HyperLink Hp = (HyperLink) DATA_TEMPLATE.Items[i].Cells[3].FindControl("HP_DOWNLOAD");
				Hp.NavigateUrl = DATA_TEMPLATE.Items[i].Cells[2].Text.Trim();
			}*/
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
			/*conn.QueryString = "select XLS_DIR from REKANAN_EXCEL_TEMPLATE";
			conn.ExecuteQuery();
			string path = "/SME/" + conn.GetFieldValue("XLS_DIR").ToString().Trim().Replace("\\", "/");
			
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "select REGNUM,SEQ,FU_FILENAME,FU_USERID,XLS_DIR from REKANAN_FILEUPLOADXL where REGNUM ='"+ Request.QueryString["regnum"] + "'";
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
				HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[3].FindControl("HL_DOWNLOAD");
				LinkButton HpDelete   = (LinkButton) DATA_EXPORT.Items[i-1].Cells[4].FindControl("LinkButton1");
				HpDownload.NavigateUrl = path + DATA_EXPORT.Items[i-1].Cells[2].Text.Trim();
				DATA_EXPORT.Items[i-1].Cells[1].Text = i.ToString();

				if (Session["USERID"].ToString().Trim() != DATA_EXPORT.Items[i-1].Cells[5].Text)
					HpDelete.Visible	= false;

				if (Request.QueryString["ca"] =="0") 
				{
					//HpDownload.Enabled	= false;
					HpDelete.Enabled	= false;
				}
			}*/
		}

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			if (TXT_FILE_UPLOAD.PostedFile.FileName != "")
			{
				conn.QueryString = "EXEC REKANAN_INSERT_FILE_XLS '" + 
					Request.QueryString["rekanan_ref"] + "', '" +
					Session["USERID"].ToString() + "', '" +
					Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
				conn.ExecuteQuery();
			}			

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

		private void DATA_TEMPLATE_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
		
		}
		private void DATA_EXPORT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_EXPORT.CurrentPageIndex = e.NewPageIndex;
			ViewFileUpload();
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
			this.DATA_TEMPLATE.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_TEMPLATE_ItemCommand);
			this.DATA_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_ItemCommand);

		}
		#endregion

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "select * from rekanan where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();

			string jns_rekanan="";
			jns_rekanan=conn.GetFieldValue("rfrekanantype");

			
			//Cek Kelengkapan Scoring Analisa Kualitatif dan Kuantitatif
			if ( (jns_rekanan=="06") || (jns_rekanan=="08"))
			{
				conn.QueryString="select * from rekanan_quantitative where regnum='" + Request.QueryString["regnum"] + "' and nilai is null";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0)
				{
					GlobalTools.popMessage(this, "Input Data Kuantitatif belum lengkap!");
					return;	
				}
			}
			else
			{
				conn.QueryString="select * from rekanan_quantitative where regnum='" + Request.QueryString["regnum"] + "' and nilai is null";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0)
				{
					GlobalTools.popMessage(this, "Input Data Kuantitatif belum lengkap!");
					return;	
				}

				conn.QueryString="select * from rekanan_qualitative where regnum='" + Request.QueryString["regnum"] + "' and score is null";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0)
				{
					GlobalTools.popMessage(this, "Input Data Kualitatif belum lengkap!");
					return;	
				}					
			}

			//Cek Kelengkapan Scoring Kriteria Tambahan
			if ( (jns_rekanan=="01") || (jns_rekanan=="02") || (jns_rekanan=="03") || (jns_rekanan=="07") )
			{
				conn.QueryString="select * from rekanan_crite where regnum='" + Request.QueryString["regnum"] + "' and nilai is null";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0)
				{
					GlobalTools.popMessage(this, "Input Data Kriteria Tambahan belum lengkap!");
					return;	
				}
			}

			//Cek Secara Keseluruhan bila belum ada data apapun yang disave
			conn.QueryString = "select * from rekanan_quantitative where regnum='" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() == 0)
			{
				GlobalTools.popMessage(this, "Isi terlebih dahulu halaman Kualitatif & Kuantitatif!");
				return;	
			}


			if ( (jns_rekanan!="06") && (jns_rekanan!="08"))
			{
				conn.QueryString="select * from rekanan_qualitative where regnum='" + Request.QueryString["regnum"] + "' ";
				conn.ExecuteQuery();
				if (conn.GetRowCount() == 0)
				{
					GlobalTools.popMessage(this, "Isi terlebih dahulu halaman Kualitatif & Kuantitatif!");
					return;	
				}
			}
			
			if ( (jns_rekanan=="01") || (jns_rekanan=="02") || (jns_rekanan=="03") || (jns_rekanan=="07") )
			{
				conn.QueryString="select * from rekanan_crite where regnum='" + Request.QueryString["regnum"] + "' ";
				conn.ExecuteQuery();
				if (conn.GetRowCount() == 0)
				{
					GlobalTools.popMessage(this, "Isi terlebih dahulu halaman Kualitatif & Kuantitatif!");
					return;	
				}
			}



			string reject="0";
			conn.QueryString = "exec REKANAN_TRACKUPDATE '" + 
				Request.QueryString["regnum"] + "', '" +
				Request.QueryString["tc"] + "', '" +
				Session["UserID"].ToString() + "', '" +
				reject + "'";
			conn.ExecuteNonQuery();

			string msg = getNextStepMsg(Request.QueryString["regnum"]);
			Response.Redirect("Analisa.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);

		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("Analisa.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		private string getNextStepMsg(string regnum) 
		{
			string pesan = "";
			string nextTrack = "";
			try 
			{
				/***
				 * Memunculkan pesan next step
				 ***/
				conn.QueryString = "exec REKANAN_TRACKNEXTMSG '" + regnum + "'";
				conn.ExecuteQuery();
				nextTrack = conn.GetFieldValue("TRACKNAME");
				pesan = "Rekanan diproses ke tahap " + nextTrack;
				/***********************************/
			} 
			catch 
			{
				throw new Exception();
			}

			return pesan;
		}
	}
}
