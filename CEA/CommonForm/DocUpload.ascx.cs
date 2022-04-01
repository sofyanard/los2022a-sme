namespace SME.CEA.CommonForm
{
	using System;
	using System.IO;
	using System.Collections;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.SessionState;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Diagnostics;
	using Microsoft.VisualBasic;
	using DMS.CuBESCore;
	using DMS.DBConnection;

	/// <summary>
	///		Summary description for DocUpload.
	/// </summary>
	public partial class DocUpload : System.Web.UI.UserControl
	{

		protected Connection conn;
		protected Tools tool = new Tools();
		private string regnum;
		private string rekanan_ref;

		private string vargrouptemplate;
		private bool varreadonly;
		private bool varwithreadexcel;

		private string _grptemplate;
		private bool _readonly;
		private bool _withreadexcel;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if ((Request.QueryString["regnum"] != null) && (Request.QueryString["regnum"] != ""))
				regnum = Request.QueryString["regnum"];

			if((Request.QueryString["rekanan_ref"] != null) && (Request.QueryString["rekanan_ref"] != ""))
				rekanan_ref = Request.QueryString["rekanan_ref"];

			vargrouptemplate = _grptemplate;
			varreadonly = _readonly;
			varwithreadexcel = _withreadexcel;

			if (!IsPostBack)
			{
				ViewUploadFiles();
			}
			else
			{
				vargrouptemplate = (string)ViewState["grptemplate"];
				varwithreadexcel = (bool)ViewState["withreadexcel"];
			}
		}

			public string GroupTemplate
			{
				set 
				{
					_grptemplate = value;
					ViewState["grptemplate"] = _grptemplate;
				}
			}

		public bool ReadOnly
		{
			set 
			{
				_readonly = value;
				ViewState["readonly"] = _readonly;
			}
		}

		public bool WithReadExcel
		{
			set 
			{
				_withreadexcel = value;
				ViewState["withreadexcel"] = _withreadexcel;
			}
		}

		private void ViewUploadFiles()
		{
			System.Data.DataTable dt = new System.Data.DataTable();

			conn.QueryString = "SELECT * FROM VW_REKANAN_DOCUPLOAD_VIEWFILEUPLOAD WHERE GROUPFILE = '" + vargrouptemplate + 
				"' AND REKANAN_REF = '" + rekanan_ref + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DG_UPLOAD.DataSource = dt;
			try 
			{
				DG_UPLOAD.DataBind();
			} 
			catch 
			{
				DG_UPLOAD.CurrentPageIndex = 0;
				DG_UPLOAD.DataBind();
			}
			for (int i = 1; i <= DG_UPLOAD.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DG_UPLOAD.Items[i-1].Cells[5].FindControl("FU_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DG_UPLOAD.Items[i-1].Cells[6].FindControl("FU_DELETE");
				HpDownload.NavigateUrl = DG_UPLOAD.Items[i-1].Cells[7].Text.Trim();
				if (Session["UserID"].ToString().Trim() != DG_UPLOAD.Items[i-1].Cells[3].Text)
					HpDelete.Visible	= false;
			}
		}

		private void deleteFile(string directory, string filename) 
		{
			if (File.Exists(directory + filename)) 
			{
				File.Delete(directory + filename);
			}
		}

		private void UploadFile()
		{
			string directory;
			int counter = 0;
			string templateid, outputfilename, initfilename;
			
			//Get Export Properties
			conn.QueryString = "SELECT TOP 1 * FROM VW_REKANAN_DOCEXPORT_PARAMETER WHERE TEMPLATE_GROUP = '" + vargrouptemplate + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());
				templateid = conn.GetFieldValue("TEMPLATE_ID");
				initfilename = conn.GetFieldValue("UPLOAD_FILEFORMAT");

				HttpFileCollection uploadedFiles = Request.Files;

				for (int i = 0; i < uploadedFiles.Count; i++)
				{
					HttpPostedFile userPostedFile = uploadedFiles[i];
					counter = i + 1;

					try
					{
						if (userPostedFile.ContentLength > 0)
						{
							outputfilename = conn.GetFieldValue("UPLOAD_FILEFORMAT").Replace("#REGNUM$",regnum).Replace("#USERID$",Session["UserID"].ToString()) + "-" + Path.GetFileName(userPostedFile.FileName);
							userPostedFile.SaveAs(directory + outputfilename);

							LBL_STATUS.ForeColor = Color.Green;
							LBL_STATUSREPORT.ForeColor = Color.Green;
							LBL_STATUS.Text = "Upload Successful!";
							LBL_STATUSREPORT.Text = "<u>File #" + counter.ToString() + "</u><br>" + 
								"File Content Type: " + userPostedFile.ContentType + "<br>" + 
								"File Size: " + userPostedFile.ContentLength + " bytes<br>" + 
								"File Name: " + userPostedFile.FileName + "<br>" +
								"Location Where Saved: " + directory + outputfilename + "<p>";

							//Save to Table
							conn.QueryString = "EXEC REKANAN_DOCUPLOAD_SAVE '1', '" + 
								regnum + "', '" + 
								vargrouptemplate + "', '', '" + 
								Session["UserID"].ToString().Trim() + "', '" + 
								outputfilename + "', '" +
								rekanan_ref + "'";
							conn.ExecuteQuery();

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
			}
		}

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			UploadFile();
		}

		private void DG_UPLOAD_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					try 
					{					
						conn.QueryString = "SELECT TOP 1 UPLOAD_PATH FROM VW_REKANAN_DOCEXPORT_PARAMETER WHERE TEMPLATE_GROUP = '" + vargrouptemplate + "'";
						conn.ExecuteQuery();

						if (conn.GetRowCount() > 0)
						{
							string directory = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());
						
							//Delete File Physically
							deleteFile(directory, e.Item.Cells[4].Text);
							Response.Write("<!-- file : " + directory + e.Item.Cells[4].Text + " -->");
							Response.Write("<!-- file is deleted. -->");

							conn.QueryString = "EXEC REKANAN_DOCUPLOAD_SAVE '2', '" + 
								e.Item.Cells[0].Text + "', '" + 
								e.Item.Cells[1].Text + "', '" +
								e.Item.Cells[2].Text + "', '" + 
								Session["UserID"].ToString().Trim() + "', '" + 
								e.Item.Cells[4].Text + "', '" +
								rekanan_ref + "'";
							conn.ExecuteQuery();

							ViewUploadFiles();
						}
					} 
					catch (Exception ex) 
					{
						Response.Write("<!-- Delete File Error: " + ex.Message.ToString() + " -->");
					}
					break;
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.DG_UPLOAD.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_UPLOAD_ItemCommand);
			this.DG_UPLOAD.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_UPLOAD_PageIndexChanged);

		}
		#endregion

		private void DG_UPLOAD_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_UPLOAD.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFiles();
		}
	}
}
