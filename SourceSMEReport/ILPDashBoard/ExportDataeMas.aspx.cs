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
using System.IO;
using System.Diagnostics;

namespace SME.SourceSMEReport.ILPDashBoard
{
	/// <summary>
	/// Summary description for ExportDataeMas.
	/// </summary>
	public partial class ExportDataeMas : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		protected ArrayList array = new ArrayList();
		protected string xlsname;
		protected string sheetname="";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/../SME/Restricted.aspx");

			if(!IsPostBack)
			{
				ViewUploadFiles();
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
			this.DATA_EXPORT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_EXPORT_PageIndexChanged);

		}
		#endregion

		private void DATA_EXPORT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_EXPORT.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFiles();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ILPDashboard.aspx?mc=" + Request.QueryString["mc"]);
		}

		protected void BTN_UPLOAD_NEW_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			conn.QueryString = "EXEC DASHBOARD_FILE_EXPORT_INSERT '" +
				Session["USERID"].ToString() + "', '" +
				Path.GetFileName(TXT_FILE_UPLOAD_NEW.PostedFile.FileName) + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_EXP) as MAX_ID from [DASHBOARD_FILE_EXPORT]";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_EXP_NAME from [DASHBOARD_FILE_EXPORT] where ID_UPLOAD_EXP = '" + max_id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_EXP_NAME");
			}

			conn.QueryString = "SELECT EXPORT_URL FROM DASHBOARD_RFEXPORT WHERE EXPORT_ID = 'DASHBOARD01'";
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

							LBL_STATUS_NEW.ForeColor = Color.Green;
							LBL_STATUSREPORT_NEW.ForeColor = Color.Green;
							LBL_STATUS_NEW.Text = "Upload Successful!";
							LBL_STATUSREPORT_NEW.Text = "<u>File #" + counter.ToString() + "</u><br>" + 
								"File Content Type: " + userPostedFile.ContentType + "<br>" + 
								"File Size: " + userPostedFile.ContentLength + " bytes<br>" + 
								"File Name: " + userPostedFile.FileName + "<br>" +
								"Location Where Saved: " + directory + outputfilename + "<p>";

							conn.QueryString = "DELETE DASHBOARD_TAT_NEW";
							conn.ExecuteQuery();
	
							//View Upload File
							ViewUploadFiles();
						}
					}
					catch (Exception ex)
					{
						LBL_STATUS_NEW.ForeColor = Color.Red;
						LBL_STATUSREPORT_NEW.ForeColor = Color.Red;
						LBL_STATUS_NEW.Text = "Upload Failed!";
						LBL_STATUSREPORT_NEW.Text = ex.Message + "\n" + ex.StackTrace;
					}
				}
				try
				{
					ReadExcelNew(directory + outputfilename);
				}
				catch {}
			}
			ViewUploadFiles();
		}

		private void ViewUploadFiles()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM DASHBOARD_RFEXPORT WHERE EXPORT_ID = 'DASHBOARD01'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD_EXP, FILE_UPLOAD_EXP_NAME FROM DASHBOARD_FILE_EXPORT";
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
				HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("FILE_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[3].FindControl("FILE_DELETE");
				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_EXP_NAME");
			}
		}

		protected void BTN_UPLOAD_LIMIT_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			conn.QueryString = "EXEC DASHBOARD_FILE_EXPORT_INSERT '" +
				Session["USERID"].ToString() + "', '" +
				Path.GetFileName(TXT_FILE_UPLOAD_LIMIT.PostedFile.FileName) + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_EXP) as MAX_ID from [DASHBOARD_FILE_EXPORT]";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_EXP_NAME from [DASHBOARD_FILE_EXPORT] where ID_UPLOAD_EXP = '" + max_id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_EXP_NAME");
			}

			conn.QueryString = "SELECT EXPORT_URL FROM DASHBOARD_RFEXPORT WHERE EXPORT_ID = 'DASHBOARD01'";
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

							LBL_STATUS_LIMIT.ForeColor = Color.Green;
							LBL_STATUSREPORT_LIMIT.ForeColor = Color.Green;
							LBL_STATUS_LIMIT.Text = "Upload Successful!";
							LBL_STATUSREPORT_LIMIT.Text = "<u>File #" + counter.ToString() + "</u><br>" + 
								"File Content Type: " + userPostedFile.ContentType + "<br>" + 
								"File Size: " + userPostedFile.ContentLength + " bytes<br>" + 
								"File Name: " + userPostedFile.FileName + "<br>" +
								"Location Where Saved: " + directory + outputfilename + "<p>";

							conn.QueryString = "DELETE DASHBOARD_TAT_LIMIT";
							conn.ExecuteQuery();

							//View Upload File
							ViewUploadFiles();
						}
					}
					catch (Exception ex)
					{
						LBL_STATUS_LIMIT.ForeColor = Color.Red;
						LBL_STATUSREPORT_LIMIT.ForeColor = Color.Red;
						LBL_STATUS_LIMIT.Text = "Upload Failed!";
						LBL_STATUSREPORT_LIMIT.Text = ex.Message + "\n" + ex.StackTrace;
					}
				}
				try
				{
					ReadExcelLimit(directory + outputfilename);
				}
				catch {}
			}
			ViewUploadFiles();
		}

		protected void BTN_UPLOAD_RENEWAL_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			conn.QueryString = "EXEC DASHBOARD_FILE_EXPORT_INSERT '" +
				Session["USERID"].ToString() + "', '" +
				Path.GetFileName(TXT_FILE_UPLOAD_RENEWAL.PostedFile.FileName) + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_EXP) as MAX_ID from [DASHBOARD_FILE_EXPORT]";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_EXP_NAME from [DASHBOARD_FILE_EXPORT] where ID_UPLOAD_EXP = '" + max_id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_EXP_NAME");
			}

			conn.QueryString = "SELECT EXPORT_URL FROM DASHBOARD_RFEXPORT WHERE EXPORT_ID = 'DASHBOARD01'";
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

							LBL_STATUS_RENEWAL.ForeColor = Color.Green;
							LBL_STATUSREPORT_RENEWAL.ForeColor = Color.Green;
							LBL_STATUS_RENEWAL.Text = "Upload Successful!";
							LBL_STATUSREPORT_RENEWAL.Text = "<u>File #" + counter.ToString() + "</u><br>" + 
								"File Content Type: " + userPostedFile.ContentType + "<br>" + 
								"File Size: " + userPostedFile.ContentLength + " bytes<br>" + 
								"File Name: " + userPostedFile.FileName + "<br>" +
								"Location Where Saved: " + directory + outputfilename + "<p>";

							conn.QueryString = "DELETE DASHBOARD_TAT_RENEWAL";
							conn.ExecuteQuery();

							//View Upload File
							ViewUploadFiles();
						}
					}
					catch (Exception ex)
					{
						LBL_STATUS_RENEWAL.ForeColor = Color.Red;
						LBL_STATUSREPORT_RENEWAL.ForeColor = Color.Red;
						LBL_STATUS_RENEWAL.Text = "Upload Failed!";
						LBL_STATUSREPORT_RENEWAL.Text = ex.Message + "\n" + ex.StackTrace;
					}
				}
				try
				{
					ReadExcelRenewal(directory + outputfilename);
				}
				catch {}
			}
			ViewUploadFiles();
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string directory = "";
			conn.QueryString = "SELECT EXPORT_URL FROM DASHBOARD_RFEXPORT WHERE EXPORT_ID = 'DASHBOARD01'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());
			}

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "EXEC DASHBOARD_DELETE_FILE_UPLOAD '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					deleteFile(directory, e.Item.Cells[1].Text);
					ViewUploadFiles();
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

		private void ReadExcelNew(string filename)
		{
			Excel.Application excelApp = null;
			Excel.Workbook excelWorkBook = null;
			Excel.Sheets excelSheet = null;

			ArrayList orgId = new ArrayList();
			ArrayList newId = new ArrayList();
			array.Clear();

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
				conn.QueryString = "SELECT SHEET_ID, SHEET_SEQ, STOREDPROCEDURE FROM DASHBOARD_TEMPLATE_MASTER WHERE APP_TYPE='NEW' ORDER BY SEQ";
				conn.ExecuteQuery();

				dt1 = conn.GetDataTable().Copy();
			
				if (dt1.Rows.Count > 0)
				{
					for (int i = 0; i < dt1.Rows.Count; i++)
					{
						string sheetid = dt1.Rows[i][0].ToString().Trim();
						sheetname = sheetid;
						string sheetseq = dt1.Rows[i][1].ToString().Trim();
						string proc = dt1.Rows[i][2].ToString().Trim();

						Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheetid);
						
						
						//Loop for Template Detail
						conn.QueryString = "SELECT CELL_COL, DB_FIELD FROM DASHBOARD_TEMPLATE_DETAIL WHERE APP_TYPE='NEW' ORDER BY ID_TEMPLATE";
						conn.ExecuteQuery();
						dt2 = conn.GetDataTable().Copy();
						int n = dt2.Rows.Count;
						object[] par;
						par = new object[n];
						object[] dttype;
						dttype = new object[n];
						string kolomA = "";


						if (dt2.Rows.Count > 0)
						{
							int row = 2;
							bool flag = false;

							while(true)
							{
								for (int j = 0; j < dt2.Rows.Count; j++)
								{
									string xcol = dt2.Rows[j][0].ToString().Trim();
									string datatype = dt2.Rows[j][1].ToString().Trim(); //data type
									string cell_value;
									string xcell = xcol + row.ToString();
									

									Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(xcell, xcell);
									
									try
									{
										if (excelCell != null)
										{
											if(xcol=="A")
												kolomA = excelCell.Value2.ToString();

											cell_value = excelCell.Value2.ToString();
											par[j] = (string)cell_value;
											dttype[j] = (string)datatype;
										}
									}
									catch
									{
										if(kolomA != "")
										{
											switch(datatype)
											{
												case "V":
													par[j] = "";
													dttype[j] = (string)datatype;
													break;
												case "F":
													par[j] = 0;
													dttype[j] = (string)datatype;
													break;
												case "D":
													par[j] = "0";
													dttype[j] = (string)datatype;
													break;
												default:
													break;
											}
										}
										else
										{flag = true;}
									}
								}
								string tgl;
							//-----------------------------------------------------------------------------------//
								//Construct Query
								if(flag == false)
								{
									string query = "EXEC " + proc + " ";
									for (int k = 0; k < n; k++)
									{
										if (dttype[k].ToString() == "V")
											query = query + "'" + par[k].ToString() + "'";
										else if (dttype[k].ToString() == "F")
											query = query + "" + par[k].ToString() + "";
										else if (dttype[k].ToString() == "D")
										{
											if(par[k].ToString()=="0")
											{
												tgl = tool.ConvertDate("01", "01", "1900");
												query = query + "" + tgl + "";
											}
											else
											{
												//tgl = par[k].ToString().Length();
												conn.QueryString = "EXEC DASHBOARD_CREATE_TGL '" + par[k].ToString() + "'";
												conn.ExecuteQuery();
												tgl = tool.ConvertDate(conn.GetFieldValue(0,0),conn.GetFieldValue(0,1),conn.GetFieldValue(0,2));
												query = query + "" + tgl + "";
											}
										}

										if (k < n-1)
											query = query + ", ";
									}

							//----------------------------------------------------------------------------------//		

									conn.QueryString = query;
									conn.ExecuteQuery();
									kolomA = "";

									row++;
								}
								else
								{
									break;
								}
							}

							//Show Success Message
							LBL_STATUS_NEW.ForeColor = Color.Green;
							LBL_STATUSREPORT_NEW.ForeColor = Color.Green;
							LBL_STATUS_NEW.Text = "Upload Sucessful! Insert Result Sucessful!";
							LBL_STATUSREPORT_NEW.Text = "";
						}
					}
				}
			}
			catch
			{
				try
				{
					Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheetname);
					LBL_STATUS_NEW.ForeColor = Color.Green;
					LBL_STATUSREPORT_NEW.ForeColor = Color.Red;
					LBL_STATUS_NEW.Text = "Upload Sucessful!";
					LBL_STATUSREPORT_NEW.Text = "Gagal memasukkan data! Silahkan periksa kembali format datanya !";
					//LBL_STATUSREPORT.Text = ex.Message + "\n" + ex.StackTrace;
				}
				catch
				{
					//Show Success Message
					LBL_STATUS_NEW.ForeColor = Color.Green;
					LBL_STATUSREPORT_NEW.ForeColor = Color.Green;
					LBL_STATUS_NEW.Text = "Upload Sucessful! Insert dihentikan karena tidak ada sheet " + sheetname;
					LBL_STATUSREPORT_NEW.Text = "";
				}
				
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
		}

		private void ReadExcelLimit(string filename)
		{
			Excel.Application excelApp = null;
			Excel.Workbook excelWorkBook = null;
			Excel.Sheets excelSheet = null;

			ArrayList orgId = new ArrayList();
			ArrayList newId = new ArrayList();
			array.Clear();

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
				conn.QueryString = "SELECT SHEET_ID, SHEET_SEQ, STOREDPROCEDURE FROM DASHBOARD_TEMPLATE_MASTER WHERE APP_TYPE='LIMIT' ORDER BY SEQ";
				conn.ExecuteQuery();

				dt1 = conn.GetDataTable().Copy();
			
				if (dt1.Rows.Count > 0)
				{
					for (int i = 0; i < dt1.Rows.Count; i++)
					{
						string sheetid = dt1.Rows[i][0].ToString().Trim();
						sheetname = sheetid;
						string sheetseq = dt1.Rows[i][1].ToString().Trim();
						string proc = dt1.Rows[i][2].ToString().Trim();

						Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheetid);
						
						
						//Loop for Template Detail
						conn.QueryString = "SELECT CELL_COL, DB_FIELD FROM DASHBOARD_TEMPLATE_DETAIL WHERE APP_TYPE='LIMIT' ORDER BY ID_TEMPLATE";
						conn.ExecuteQuery();
						dt2 = conn.GetDataTable().Copy();
						int n = dt2.Rows.Count;
						object[] par;
						par = new object[n];
						object[] dttype;
						dttype = new object[n];
						string kolomA = "";

						if (dt2.Rows.Count > 0)
						{
							int row = 2;
							bool flag = false;

							while(true)
							{
								for (int j = 0; j < dt2.Rows.Count; j++)
								{
									string xcol = dt2.Rows[j][0].ToString().Trim();
									string datatype = dt2.Rows[j][1].ToString().Trim(); //data type
									string cell_value;
									string xcell = xcol + row.ToString();

									Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(xcell, xcell);
									
									try
									{
										if (excelCell != null)
										{
											if(xcol=="A")
												kolomA = excelCell.Value2.ToString();

											cell_value = excelCell.Value2.ToString();
											par[j] = (string)cell_value;
											dttype[j] = (string)datatype;
										}
									}
									catch
									{
										if(kolomA != "")
										{
											switch(datatype)
											{
												case "V":
													par[j] = "";
													dttype[j] = (string)datatype;
													break;
												case "F":
													par[j] = 0;
													dttype[j] = (string)datatype;
													break;
												case "D":
													par[j] = "0";
													dttype[j] = (string)datatype;
													break;
												default:
													break;
											}
										}
										else
										{flag = true;}
									}
								}
								string tgl;
						//--------------------------------------------------------------------------------------//	
								//Construct Query
								if(flag == false)
								{
									string query = "EXEC " + proc + " ";
									for (int k = 0; k < n; k++)
									{
										if (dttype[k].ToString() == "V")
											query = query + "'" + par[k].ToString() + "'";
										else if (dttype[k].ToString() == "F")
											query = query + "" + par[k].ToString() + "";
										else if (dttype[k].ToString() == "D")
										{
											if(par[k].ToString()=="0")
											{
												tgl = tool.ConvertDate("01", "01", "1900");
												query = query + "" + tgl + "";
											}
											else
											{
												//tgl = par[k].ToString().Length();
												conn.QueryString = "EXEC DASHBOARD_CREATE_TGL '" + par[k].ToString() + "'";
												conn.ExecuteQuery();
												tgl = tool.ConvertDate(conn.GetFieldValue(0,0),conn.GetFieldValue(0,1),conn.GetFieldValue(0,2));
												query = query + "" + tgl + "";
											}
										}

										if (k < n-1)
											query = query + ", ";
									}

						//------------------------------------------------------------------------------------------//			

									conn.QueryString = query;
									conn.ExecuteQuery();
									kolomA = "";

									row++;
								}
								else
								{
									break;
								}
							}

							//Show Success Message
							LBL_STATUS_LIMIT.ForeColor = Color.Green;
							LBL_STATUSREPORT_LIMIT.ForeColor = Color.Green;
							LBL_STATUS_LIMIT.Text = "Upload Sucessful! Insert Result Sucessful!";
							LBL_STATUSREPORT_LIMIT.Text = "";
						}
					}
				}
			}
			catch
			{
				try
				{
					Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheetname);
					LBL_STATUS_LIMIT.ForeColor = Color.Green;
					LBL_STATUSREPORT_LIMIT.ForeColor = Color.Red;
					LBL_STATUS_LIMIT.Text = "Upload Sucessful!";
					LBL_STATUSREPORT_LIMIT.Text = "Gagal memasukkan data! Silahkan periksa kembali format datanya !";
					//LBL_STATUSREPORT.Text = ex.Message + "\n" + ex.StackTrace;
				}
				catch
				{
					//Show Success Message
					LBL_STATUS_LIMIT.ForeColor = Color.Green;
					LBL_STATUSREPORT_LIMIT.ForeColor = Color.Green;
					LBL_STATUS_LIMIT.Text = "Upload Sucessful! Insert dihentikan karena tidak ada sheet " + sheetname;
					LBL_STATUSREPORT_LIMIT.Text = "";
				}
				
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
		}

		private void ReadExcelRenewal(string filename)
		{
			Excel.Application excelApp = null;
			Excel.Workbook excelWorkBook = null;
			Excel.Sheets excelSheet = null;

			ArrayList orgId = new ArrayList();
			ArrayList newId = new ArrayList();
			array.Clear();

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
				conn.QueryString = "SELECT SHEET_ID, SHEET_SEQ, STOREDPROCEDURE FROM DASHBOARD_TEMPLATE_MASTER WHERE APP_TYPE='RENEWAL' ORDER BY SEQ";
				conn.ExecuteQuery();

				dt1 = conn.GetDataTable().Copy();
			
				if (dt1.Rows.Count > 0)
				{
					for (int i = 0; i < dt1.Rows.Count; i++)
					{
						string sheetid = dt1.Rows[i][0].ToString().Trim();
						sheetname = sheetid;
						string sheetseq = dt1.Rows[i][1].ToString().Trim();
						string proc = dt1.Rows[i][2].ToString().Trim();

						Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheetid);
						
						
						//Loop for Template Detail
						conn.QueryString = "SELECT CELL_COL, DB_FIELD FROM DASHBOARD_TEMPLATE_DETAIL WHERE APP_TYPE='RENEWAL' ORDER BY ID_TEMPLATE";
						conn.ExecuteQuery();
						dt2 = conn.GetDataTable().Copy();
						int n = dt2.Rows.Count;
						object[] par;
						par = new object[n];
						object[] dttype;
						dttype = new object[n];
						string kolomA = "";

						if (dt2.Rows.Count > 0)
						{
							int row = 2;
							bool flag = false;

							while(true)
							{
								for (int j = 0; j < dt2.Rows.Count; j++)
								{
									string xcol = dt2.Rows[j][0].ToString().Trim();
									string datatype = dt2.Rows[j][1].ToString().Trim(); //data type
									string cell_value;
									string xcell = xcol + row.ToString();

									Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(xcell, xcell);
									
									try
									{
										if (excelCell != null)
										{
											if(xcol=="A")
												kolomA = excelCell.Value2.ToString();

											cell_value = excelCell.Value2.ToString();
											par[j] = (string)cell_value;
											dttype[j] = (string)datatype;
										}
									}
									catch
									{
										if(kolomA != "")
										{
											switch(datatype)
											{
												case "V":
													par[j] = "";
													dttype[j] = (string)datatype;
													break;
												case "F":
													par[j] = 0;
													dttype[j] = (string)datatype;
													break;
												case "D":
													par[j] = "0";
													dttype[j] = (string)datatype;
													break;
												default:
													break;
											}
										}
										else
										{flag = true;}
									}
								}

								string tgl;
								//--------------------------------------------------------------------------------------//	
								//Construct Query
								if(flag == false)
								{
									string query = "EXEC " + proc + " ";
									for (int k = 0; k < n; k++)
									{
										if (dttype[k].ToString() == "V")
											query = query + "'" + par[k].ToString() + "'";
										else if (dttype[k].ToString() == "F")
											query = query + "" + par[k].ToString() + "";
										else if (dttype[k].ToString() == "D")
										{
											if(par[k].ToString()=="0")
											{
												tgl = tool.ConvertDate("01", "01", "1900");
												query = query + "" + tgl + "";
											}
											else
											{
												//tgl = par[k].ToString().Length();
												conn.QueryString = "EXEC DASHBOARD_CREATE_TGL '" + par[k].ToString() + "'";
												conn.ExecuteQuery();
												tgl = tool.ConvertDate(conn.GetFieldValue(0,0),conn.GetFieldValue(0,1),conn.GetFieldValue(0,2));
												query = query + "" + tgl + "";
											}
										}

										if (k < n-1)
											query = query + ", ";
									}

									//------------------------------------------------------------------------------------------//			

									conn.QueryString = query;
									conn.ExecuteQuery();
									kolomA = "";

									row++;
								}
								else
								{
									break;
								}
							}

							//Show Success Message
							LBL_STATUS_RENEWAL.ForeColor = Color.Green;
							LBL_STATUSREPORT_RENEWAL.ForeColor = Color.Green;
							LBL_STATUS_RENEWAL.Text = "Upload Sucessful! Insert Result Sucessful!";
							LBL_STATUSREPORT_RENEWAL.Text = "";
						}
					}
				}
			}
			catch
			{
				try
				{
					Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheetname);
					LBL_STATUS_RENEWAL.ForeColor = Color.Green;
					LBL_STATUSREPORT_RENEWAL.ForeColor = Color.Red;
					LBL_STATUS_RENEWAL.Text = "Upload Sucessful!";
					LBL_STATUSREPORT_RENEWAL.Text = "Gagal memasukkan data! Silahkan periksa kembali format datanya !";
					//LBL_STATUSREPORT.Text = ex.Message + "\n" + ex.StackTrace;
				}
				catch
				{
					//Show Success Message
					LBL_STATUS_RENEWAL.ForeColor = Color.Green;
					LBL_STATUSREPORT_RENEWAL.ForeColor = Color.Green;
					LBL_STATUS_RENEWAL.Text = "Upload Sucessful! Insert dihentikan karena tidak ada sheet " + sheetname;
					LBL_STATUSREPORT_RENEWAL.Text = "";
				}
				
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
		}
	}
}
