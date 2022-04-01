namespace SME.CommonForm
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
	///		Summary description for DocumentUpload.
	/// </summary>
	public partial class DocumentUpload : System.Web.UI.UserControl
	{

		protected Connection conn;
		protected Tools tool = new Tools();
        private SMEExportImport.WordClient client;

		private string regno;

		private string vargrouptemplate;
		private bool varreadonly;
		private bool varwithreadexcel;

		private string _grptemplate;
		private bool _readonly;
		private bool _withreadexcel;

		/* Parameter Table		: DOCEXPORT_TEMPLATE_MASTER & DOCEXPORT_TEMPLATE_DETAIL
		 * 
		 * Template ID			: Template Identifier
		 * Sheet ID				: Sheet Name for EXCEL
		 * Sheet Seq			: Identifier withnin one sheet (if more than one stored procedures needed within one sheet)
		 * Document Type		: WORD / EXCEL
		 * Action Type			: READ (read data from EXCEL File) / WRITE (write data to WORD or EXCEL file)
		 * Template File Name	: Template file name
		 * Template Path		: Path for template file
		 * Upload Path			: Path for result file
		 * Upload File Format	: Name format for result file
		 *						  #REGNO$ will be replaced with AP_REGNO
		 *						  #USERID$ will be replaced with USERID
		 * Stored Procedure		: Stored Procedure to be executed for providing data to be read/written
		 * 
		 * Seq					: Sequence Identifier for each Template ID, Sheet ID, and Sheet Seq
		 * Cell Column			: Cell Column for EXCEL, Bookmark Name for WORD
		 * Cell Row				: Cell Row for EXCEL, flag for WORD (0 = data contains many row, 1 = data containts single row)
		 * DB Field				: Field in Stored Procedure result, OR Data Type for Read Excel, C = Character, N = Numeric
		 */

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
            client = new SMEExportImport.WordClient();

			if ((Request.QueryString["regno"] != null) && (Request.QueryString["regno"] != ""))
				regno = Request.QueryString["regno"];
			else if ((Request.QueryString["lmsreg"] != null) && (Request.QueryString["lmsreg"] != ""))
				regno = Request.QueryString["lmsreg"];
			else if ((Request.QueryString["porlmsreg"] != null) && (Request.QueryString["porlmsreg"] != ""))
				regno = Request.QueryString["porlmsreg"];

			vargrouptemplate = _grptemplate;
			varreadonly = _readonly;
			varwithreadexcel = _withreadexcel;

			if (!IsPostBack)
			{
				ViewTemplateFiles();
				ViewUploadFiles();
				SecureData();
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

		private void SecureData()
		{
			if (varreadonly == true)
			{
				BTN_UPLOAD.Enabled = false;
				for (int i = 1; i <= DG_UPLOAD.Items.Count; i++)
				{
					LinkButton HpDelete = (LinkButton) DG_UPLOAD.Items[i-1].Cells[6].FindControl("FU_DELETE");
					HpDelete.Enabled = false;
				}
			}
		}

		public void ClearData()
		{
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT * FROM VW_DOCUPLOAD_VIEWFILEUPLOAD WHERE GROUPFILE = 'empty'";
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
		}


		
		private void ViewTemplateFiles()
		{
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT * FROM VW_DOCUPLOAD_VIEWFILETEMPLATE WHERE GROUPFILE = '" + vargrouptemplate + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DG_TEMPLATE.DataSource = dt;
			try 
			{
				DG_TEMPLATE.DataBind();
			} 
			catch 
			{
				DG_TEMPLATE.CurrentPageIndex = 0;
				DG_TEMPLATE.DataBind();
			}
			for (int i = 1; i <= DG_TEMPLATE.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DG_TEMPLATE.Items[i-1].Cells[3].FindControl("HP_DOWNLOAD");
				HpDownload.NavigateUrl = DG_TEMPLATE.Items[i-1].Cells[5].Text.Trim();
			}
		}
		
		private void ViewUploadFiles()
		{
			System.Data.DataTable dt = new System.Data.DataTable();

			conn.QueryString = "SELECT * FROM VW_DOCUPLOAD_VIEWFILEUPLOAD WHERE GROUPFILE = '" + vargrouptemplate + 
				"' AND AP_REGNO = '" + regno + "'";
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

		public void ViewUploadFiles(string apregno)
		{
			System.Data.DataTable dt = new System.Data.DataTable();

			conn.QueryString = "SELECT * FROM VW_DOCUPLOAD_VIEWFILEUPLOAD WHERE GROUPFILE = '" + vargrouptemplate + 
				"' AND AP_REGNO = '" + apregno + "'";
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
			conn.QueryString = "SELECT TOP 1 * FROM VW_DOCUPLOAD_PARAMETER WHERE TEMPLATE_GROUP = '" + vargrouptemplate + "'";
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
							outputfilename = conn.GetFieldValue("UPLOAD_FILEFORMAT").Replace("#REGNO$",regno).Replace("#USERID$",Session["UserID"].ToString()) + "-" + Path.GetFileName(userPostedFile.FileName);
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
							conn.QueryString = "EXEC DOCUPLOAD_SAVE '1', '" + 
								regno + "', '" + 
								vargrouptemplate + "', '', '" + 
								Session["UserID"].ToString().Trim() + "', '" + 
								outputfilename + "'";
							conn.ExecuteQuery();

							//View Upload File
							ViewUploadFiles();

							//Read from Excel
                            if (varwithreadexcel == true)
                            {
                                //ReadExcel(directory + outputfilename, templateid);
                                string report = client.DocumentUploadASCXReadExcel(directory + outputfilename, templateid, regno);
                                string a = "";
                            }
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

		private void ReadExcel(string filename, string templateid)
		{
			Excel.Application excelApp = null;
			Excel.Workbook excelWorkBook = null;
			Excel.Sheets excelSheet = null;

			ArrayList orgId = new ArrayList();
			ArrayList newId = new ArrayList();

			Process[] oldProcess = Process.GetProcessesByName("EXCEL");
			foreach(Process thisProcess in oldProcess) orgId.Add(thisProcess);

			DataTable dt1, dt2;

			try
			{
				System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
				System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

				excelApp = new Excel.ApplicationClass();
				excelApp.Visible = false;
				excelApp.DisplayAlerts = false;

				Process[] newProcess = Process.GetProcessesByName("EXCEL");
				foreach(Process thisProcess in newProcess) newId.Add(thisProcess);

				//Save process into database
				//SupportTools.saveProcessExcel(excelApp, newId, orgId, conn);

				excelWorkBook = excelApp.Workbooks.Open(filename,
					0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t",
					false, false, 0, true);

				excelSheet = excelWorkBook.Worksheets;

				//Loop for Template Master
				conn.QueryString = "SELECT SHEET_ID, SHEET_SEQ, STOREDPROCEDURE FROM DOCEXPORT_TEMPLATE_MASTER WHERE TEMPLATE_ID = '" + templateid + "'";
				conn.ExecuteQuery();

				dt1 = conn.GetDataTable().Copy();

				if (dt1.Rows.Count > 0)
				{
					for (int i = 0; i < dt1.Rows.Count; i++)
					{
						string sheetid = dt1.Rows[i][0].ToString().Trim();
						string sheetseq = dt1.Rows[i][1].ToString().Trim();
						string proc = dt1.Rows[i][2].ToString().Trim();

						Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheetid);

						//Loop for Template Detail
						conn.QueryString = "SELECT CELL_ROW, CELL_COL, DB_FIELD FROM DOCEXPORT_TEMPLATE_DETAIL WHERE TEMPLATE_ID = '" + templateid + 
							"' AND SHEET_ID = '" + sheetid + "' AND SHEET_SEQ = '" + sheetseq + "' ORDER BY SEQ";
						conn.ExecuteQuery();
						dt2 = conn.GetDataTable().Copy();
						int n = dt2.Rows.Count;
						object[] par;
						par = new object[n];
						object[] dttype;
						dttype = new object[n];

						if (dt2.Rows.Count > 0)
						{
							for (int j = 0; j < dt2.Rows.Count; j++)
							{
								string xrow = dt2.Rows[j][0].ToString().Trim();
								string xcol = dt2.Rows[j][1].ToString().Trim();
								string datatype = dt2.Rows[j][2].ToString().Trim(); //data type
								string cell_value;
								string xcell = xcol + xrow;

								Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(xcell, xcell);
								if (excelCell != null)
								{
									cell_value = excelCell.Value2.ToString();
									par[j] = (string)cell_value;
									dttype[j] = (string)datatype;
								}
							}

							//Construct Query
							string query = "EXEC " + proc + " '" + regno + "', ";
							for (int k = 0; k < n; k++)
							{
								if (dttype[k].ToString() == "C")
									query = query + "'" + par[k].ToString() + "'";
								else if (dttype[k].ToString() == "N")
									query = query + "" + par[k].ToString() + "";

								if (k < n-1)
									query = query + ", ";
							}

							//Run Query
							conn.QueryString = query;
							conn.ExecuteQuery();

							//Show Success Message
							LBL_STATUS.ForeColor = Color.Green;
							LBL_STATUSREPORT.ForeColor = Color.Green;
							LBL_STATUS.Text = "Upload Sucessful! Insert Result Sucessful!";
							LBL_STATUSREPORT.Text = "";
						}
					}
				}
			}
			catch (Exception ex)
			{
				/*
				LBL_STATUS.ForeColor = Color.Red;
				LBL_STATUSREPORT.ForeColor = Color.Red;
				LBL_STATUS.Text = "Upload Failed!";
				LBL_STATUSREPORT.Text = ex.Message + "\n" + ex.StackTrace;
				*/
				Response.Write("<!--"+ex.Message + "\n" + ex.StackTrace+"-->");
			}
			finally
			{
				if(excelWorkBook!=null)
				{
					excelWorkBook.Close(true , filename, null);
					excelWorkBook=null;
				}
				if(excelApp!=null)
				{
					excelApp.Workbooks.Close();
					excelApp.Application.Quit();
					excelApp=null;
				}
			}

			try 
			{ 
				for(int x = 0; x < newId.Count; x++)
				{
					Process xnewId = (Process)newId[x];
								
					bool bSameId = false;
					for(int z = 0; z < orgId.Count; z++)
					{
						Process xoldId = (Process)orgId[z];
						
						if(xnewId.Id == xoldId.Id) 
						{
							bSameId = true;
							break;
						}
					}
                    if (!bSameId)
                    {
                        try
                        {
                            xnewId.Kill();
                        }
                        catch (Exception e)
                        {
                            continue;
                        }
                    }
				}
			}
			catch { }
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

		}
		#endregion

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
						conn.QueryString = "SELECT TOP 1 UPLOAD_PATH FROM VW_DOCUPLOAD_PARAMETER WHERE TEMPLATE_GROUP = '" + vargrouptemplate + "'";
						conn.ExecuteQuery();

						if (conn.GetRowCount() > 0)
						{
							string directory = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());
						
							//Delete File Physically
							deleteFile(directory, e.Item.Cells[4].Text);
							Response.Write("<!-- file : " + directory + e.Item.Cells[4].Text + " -->");
							Response.Write("<!-- file is deleted. -->");

							conn.QueryString = "EXEC DOCUPLOAD_SAVE '2', '" + 
								e.Item.Cells[0].Text + "', '" + 
								e.Item.Cells[1].Text + "', '" +
								e.Item.Cells[2].Text + "', '" + 
								Session["UserID"].ToString().Trim() + "', '" + 
								e.Item.Cells[4].Text + "'";
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
	}
}
