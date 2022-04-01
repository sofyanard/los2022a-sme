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

namespace SME.LMS.PortfolioWatchlistChecking
{
	/// <summary>
	/// Summary description for UploadDataPortfolio.
	/// </summary>
	public partial class UploadDataPortfolio : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				ViewUploadFiles();
			}			
		}

		private void deleteFile(string directory, string filename) 
		{
			if (File.Exists(directory + filename)) 
			{
				File.Delete(directory + filename);
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
			this.DATA_UPLOAD.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_UPLOAD_ItemCommand);
			this.DATA_UPLOAD.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_UPLOAD_PageIndexChanged);

		}
		#endregion

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			conn.QueryString = "EXEC PORLMS_UPLOAD_DATA_RISK '" + 
				Session["USERID"].ToString() + "', '" +
				Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_DATA_RISK) as MAX_ID from [PORLMS_FILE_UPLOAD_DATA_RISK] where userid='" + Session["USERID"].ToString() + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_NAME from [PORLMS_FILE_UPLOAD_DATA_RISK] where ID_UPLOAD_DATA_RISK = '" + max_id + "' and userid='" + Session["USERID"].ToString() + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_NAME");
				//TXT_XLSNAME.Text = outputfilename;
			}

			conn.QueryString = "SELECT EXPORT_URL FROM PORLMS_RFUPLOAD WHERE EXPORT_ID = 'PORLMS02'";
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

		private void ViewUploadFiles()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM PORLMS_RFUPLOAD WHERE EXPORT_ID = 'PORLMS02'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD_DATA_RISK, FILE_UPLOAD_NAME FROM PORLMS_FILE_UPLOAD_DATA_RISK where userid='" + Session["USERID"].ToString() + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DATA_UPLOAD.DataSource = dt;
			try 
			{
				DATA_UPLOAD.DataBind();
			} 
			catch 
			{
				DATA_UPLOAD.CurrentPageIndex = 0;
				DATA_UPLOAD.DataBind();
			}
			for (int i = 1; i <= DATA_UPLOAD.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DATA_UPLOAD.Items[i-1].Cells[2].FindControl("FILE_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DATA_UPLOAD.Items[i-1].Cells[3].FindControl("FILE_DELETE");
				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_NAME");
			}
		}

		private void DATA_UPLOAD_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string directory = "";
			conn.QueryString = "SELECT EXPORT_URL FROM PORLMS_RFUPLOAD WHERE EXPORT_ID = 'PORLMS01'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());
			}

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "EXEC PORLMS_DELETE_FILE_UPLOAD_RISK '" + e.Item.Cells[0].Text + "', '" +
						Session["USERID"].ToString() + "', '" +
						e.Item.Cells[1].Text + "'";
					conn.ExecuteQuery();
					deleteFile(directory, e.Item.Cells[1].Text);
					ViewUploadFiles();
					break;
			}
		}

		private void DATA_UPLOAD_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_UPLOAD.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFiles();
		}

	}
}
