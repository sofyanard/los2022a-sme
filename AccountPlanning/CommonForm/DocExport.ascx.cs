namespace SME.AccountPlanning.CommonForm
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
	///		Summary description for DocExport.
	/// </summary>
	public partial class DocExport : System.Web.UI.UserControl
	{

		protected Connection conn;
		protected Tools tool = new Tools();
		//private string regnum;
		private string company;

		private string vargrouptemplate;
		private string varcif;
		private bool varreadonly;

		private string _grptemplate;
		private string _cif;
		private bool _readonly;

		/* Parameter Table		: DOCEXPORT_TEMPLATE_MASTER & DOCEXPORT_TEMPLATE_DETAIL
		 * 
		 * Template ID			: Template Identifier
		 * Sheet ID				: Sheet Name for EXCEL
		 * Sheet Seq			: Identifier withnin one sheet (if more than one stored procedures needed within one sheet)
		 * Document Type		: WORD / EXCEL / EXCEL2 (utk array)
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
		 */

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			/*if ((Request.QueryString["regnum"] != null) && (Request.QueryString["regnum"] != ""))
				regnum = Request.QueryString["regnum"];*/
			
			if(_cif == null)
			{
				varcif = "";
			}
			else if(_cif != null)
			{
				varcif = _cif;
			}

			vargrouptemplate = _grptemplate;
			varreadonly = _readonly;

			if (!IsPostBack)
			{
				string qryddl = "SELECT DISTINCT TEMPLATE_ID, TEMPLATE_DESC FROM DOCEXPORT_TEMPLATE_MASTER WHERE TEMPLATE_GROUP = '" + vargrouptemplate + "'";;
				GlobalTools.fillRefList(DDL_FORMAT_TYPE, qryddl , false, conn);

				ViewExportFiles();
			}
			else
			{
				vargrouptemplate = (string)ViewState["grptemplate"];
				//varreadonly = (bool)ViewState["readonly"];
				ViewExportFiles();
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

		public string cif
		{
			set
			{
				_cif = value;
				ViewState["cif"] = _cif;
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

		private string CreateWord(string templateid)
		{
			string templatefilename = "", 
				outputfilename = "", 
				templatepath = "", 
				outputpath = "";
			string returnmsg = string.Empty;
			int writeitem = 0;
			bool savestatus;
			string curr_date = "";

			//string fileIn = string.Empty;
			//string fileOut = string.Empty;
			object fileIn;
			object fileOut;
			System.Data.DataTable dt1;
			System.Data.DataTable dt2;
			System.Data.DataTable dt3;

			System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
			System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

			object oMissingObject = System.Reflection.Missing.Value;
			Word.Application wordApp = null;
			Word.Document wordDoc = null;

			ArrayList orgId = new ArrayList();
			ArrayList newId = new ArrayList();

			wordApp = new Word.ApplicationClass();
			wordApp.Visible = false;
				
			//Collecting Existing Word in Taskbar
			Process[] oldProcess = Process.GetProcessesByName("WINWORD");
			foreach(Process thisProcess in oldProcess)
				orgId.Add(thisProcess);

			conn.QueryString = "SELECT CONVERT(VARCHAR,GETDATE(),112) AS TANGGAL";
			conn.ExecuteQuery();
			curr_date = conn.GetFieldValue("TANGGAL");

			//Get Export Properties
			conn.QueryString = "SELECT TOP 1 * FROM VW_DOCEXPORT_PARAMETER WHERE TEMPLATE_ID = '" + templateid + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				templatefilename = conn.GetFieldValue("TEMPLATE_FILENAME");
				outputfilename = conn.GetFieldValue("UPLOAD_FILEFORMAT").Replace("#NAME$",company).Replace("#REGNUM$",varcif) + "-" + curr_date + ".DOC";
				templatepath = Server.MapPath(conn.GetFieldValue("TEMPLATE_PATH").Trim());
				outputpath = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());

				try
				{
					//Collectiong Existing Word in Taskbar
					Process[] newProcess = Process.GetProcessesByName("WINWORD");
					foreach(Process thisProcess in newProcess)
						newId.Add(thisProcess);

					//Save process into database
					//SupportTools.saveProcessWord(wordApp, newId, orgId, conn);

					fileIn = templatepath + templatefilename;
					wordDoc = wordApp.Documents.Open(ref fileIn, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, 
						ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject);
					wordDoc.Activate();
					Word.Bookmarks wordBookMark = (Word.Bookmarks)wordDoc.Bookmarks;

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

							//Query Stored Procedure
							conn.QueryString = "EXEC " + proc + " '" + varcif + "'";
							conn.ExecuteQuery();
							dt3 = conn.GetDataTable().Copy();

							//Loop for Template Detail
							conn.QueryString = "SELECT CELL_ROW, CELL_COL, DB_FIELD FROM DOCEXPORT_TEMPLATE_DETAIL WHERE SHEET_ID = '" + 
								sheetid + "' AND SHEET_SEQ = '" + sheetseq + "' ORDER BY SEQ";
							conn.ExecuteQuery();
							dt2 = conn.GetDataTable().Copy();
							for (int k = 0; k < dt3.Rows.Count; k++)
							{
								for (int j = 0; j < dt2.Rows.Count; j++)
								{
									string xarr = dt2.Rows[j][0].ToString().Trim(); //indicating "0"=array, "1"=single data
									object wbm = dt2.Rows[j][1].ToString().Trim(); //bookmark di wordnya
									string dbfield = dt2.Rows[j][2].ToString().Trim();
									string cell_value = dt3.Rows[k][dbfield].ToString().Trim();

									if (wordBookMark.Exists(wbm.ToString()))
									{
										if (xarr == "0") cell_value = cell_value + "\n";
									
										Word.Bookmark oBook = wordBookMark.Item(ref wbm);
										oBook.Select();
										oBook.Range.Text = cell_value;
										writeitem++;
									}
								}
							}
						}
						//if (writeitem > 0)
						//{
						//Save Word File
						fileOut = outputpath + outputfilename;
						wordDoc.SaveAs(ref fileOut, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, 
							ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject);

						System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));

						savestatus = true;
						//}
						//else
						//{
						//	savestatus = false;
						//	returnmsg = "Error in Saving File!!";
						//	return returnmsg;
						//}

						if (savestatus == true)
						{
							//Save to Table
							conn.QueryString = "EXEC DOCEXPORT_SAVE '1', '" + 
								templateid + "', '" + 
								varcif + "', '" + 
								Session["UserID"].ToString().Trim() + "', '" + 
								outputfilename + "'";
							conn.ExecuteQuery();

							//View Upload Files
							ViewExportFiles();

							returnmsg = "Export Success!!";
						}
					}
					else
					{
						returnmsg = "Template Procedure Not Yet Defined!!";
						return returnmsg;
					}
				}
				catch (Exception e)
				{
					Response.Write("<!-- " + e.Message + "\n" + e.StackTrace + " -->\n" );

					//Return Fail Message
					returnmsg = e.Message + "\n" + e.StackTrace;
				}
				finally
				{
					if(wordDoc!=null)
					{
						wordDoc.Close(ref oMissingObject, ref oMissingObject, ref oMissingObject);
						wordDoc=null;
					}
					if(wordApp!=null)
					{
						wordApp.Application.Quit(ref oMissingObject, ref oMissingObject, ref oMissingObject);
						wordApp=null;
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
			else
			{
				returnmsg = "Export Parameter Not Yet Defined!!";
				return returnmsg;
			}
			return returnmsg;
		}

		private void ViewExportFiles()
		{
			System.Data.DataTable dt = new System.Data.DataTable();
			if(Session["idcompany"] != null)
			{
				if(Session["idcompany"].ToString() != "")
				{
					conn.QueryString = "SELECT * FROM VW_DOCEXPORT_VIEWFILEEXPORT WHERE TEMPLATE_GROUP = '" + vargrouptemplate + 
						"' AND AP_REGNO = '" + Session["idcompany"].ToString() + "'";
					conn.ExecuteQuery();
				}
			}
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
				HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[4].FindControl("FE_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[5].FindControl("FE_DELETE");
				HpDownload.NavigateUrl = DATA_EXPORT.Items[i-1].Cells[6].Text.Trim();
				if (Session["UserID"].ToString().Trim() != DATA_EXPORT.Items[i-1].Cells[2].Text)
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

		protected void BTN_EXPORT_Click(object sender, System.EventArgs e)
		{
			string status = "", doctype = "", acttype = "";
			varcif = Session["idcompany"].ToString();

			conn.QueryString = "SELECT CUSTOMER_NAME FROM AP_COMPANY_INFO WHERE CIF_CUST='" + varcif + "'";
			conn.ExecuteQuery();
			company = conn.GetFieldValue("CUSTOMER_NAME");

			try
			{
				conn.QueryString = "SELECT DOC_TYPE, ACTION_TYPE FROM DOCEXPORT_TEMPLATE_MASTER WHERE TEMPLATE_ID = '" + DDL_FORMAT_TYPE.SelectedValue + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					doctype = conn.GetFieldValue("DOC_TYPE");
					acttype = conn.GetFieldValue("ACTION_TYPE");

					if ((doctype == "WORD") && (acttype == "WRITE"))
						status = CreateWord(DDL_FORMAT_TYPE.SelectedValue);
					else
						return;
				}

				if (status == "Export Success!!")
				{
					//Show Success Message
					LBL_STATUS_EXPORT.ForeColor	= Color.Green;
					LBL_STATUSEXPORT.ForeColor	= Color.Green;
					LBL_STATUS_EXPORT.Text		= status;
					LBL_STATUSEXPORT.Text		= "";

					//View Upload Files
					ViewExportFiles();
				}
				else
				{
					//Show Success Message
					LBL_STATUS_EXPORT.ForeColor	= Color.Red;
					LBL_STATUSEXPORT.ForeColor	= Color.Red;
					LBL_STATUS_EXPORT.Text		= "Error Exporting File!!";
					LBL_STATUSEXPORT.Text		= status;
				}
			}
			catch (Exception ex)
			{
				//Show Fail Message
				LBL_STATUS_EXPORT.ForeColor = Color.Red;
				LBL_STATUSEXPORT.ForeColor	= Color.Red;
				LBL_STATUS_EXPORT.Text		= "Error Exporting File!!";
				LBL_STATUSEXPORT.Text		= ex.Message + "\n" + ex.StackTrace;
			}
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					try 
					{					
						conn.QueryString = "SELECT TOP 1 UPLOAD_PATH FROM VW_DOCEXPORT_PARAMETER WHERE TEMPLATE_GROUP = '" + vargrouptemplate + "'";
						conn.ExecuteQuery();

						if (conn.GetRowCount() > 0)
						{
							string directory = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());
						
							//Delete File Physically
							deleteFile(directory, e.Item.Cells[3].Text);
							Response.Write("<!-- file : " + directory + e.Item.Cells[3].Text + " -->");
							Response.Write("<!-- file is deleted. -->");

							conn.QueryString = "EXEC DOCEXPORT_SAVE '2', '" + e.Item.Cells[1].Text +
								"', '" + e.Item.Cells[0].Text + "', '" + e.Item.Cells[2].Text + "', '" + e.Item.Cells[3].Text + "'" ;
							conn.ExecuteQuery();

							ViewExportFiles();
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
			this.DATA_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_ItemCommand);

		}
		#endregion
	}
}
