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
using DMS.DBConnection;
using DMS.CuBESCore;
using System.Configuration;
using Microsoft.VisualBasic;
using DMS.BlackList;
using System.IO;
using System.Diagnostics;

namespace SME.AccountPlanning.UploadData
{
	/// <summary>
	/// Summary description for UploadDataDashboard.
	/// </summary>
	public partial class UploadDataDashboard : System.Web.UI.Page
	{
		protected string sheetname="";
		protected ArrayList array = new ArrayList();
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				ViewTemplateTarget();
				ViewTemplateRealization();
				FillDGRTarget();
				FillDGRRealization();
			}
		}

		private void ViewTemplateTarget()
		{
			string url = "";
			System.Data.DataTable dt = new System.Data.DataTable();

			conn.QueryString = "SELECT * FROM AP_TEMPLATE_UPLOAD WHERE ID_TEMPLATE='5'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("LINK_TEMPLATE");
				//url = /SME/Template/...
			}

			dt = conn.GetDataTable().Copy();
			TEMPLATE_TARGET.DataSource = dt;
			try 
			{
				TEMPLATE_TARGET.DataBind();
			} 
			catch 
			{
				TEMPLATE_TARGET.CurrentPageIndex = 0;
				TEMPLATE_TARGET.DataBind();
			}
			for (int i = 1; i <= TEMPLATE_TARGET.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) TEMPLATE_TARGET.Items[i-1].Cells[2].FindControl("HP_DOWNLOAD");
				HpDownload.NavigateUrl = url;
			}
		}

		private void ViewTemplateRealization()
		{
			string url = "";
			System.Data.DataTable dt = new System.Data.DataTable();

			conn.QueryString = "SELECT * FROM AP_TEMPLATE_UPLOAD WHERE ID_TEMPLATE='6'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("LINK_TEMPLATE");
				//url = /SME/Template/...
			}

			dt = conn.GetDataTable().Copy();
			TEMPLATE_REALIZATION.DataSource = dt;
			try 
			{
				TEMPLATE_REALIZATION.DataBind();
			} 
			catch 
			{
				TEMPLATE_REALIZATION.CurrentPageIndex = 0;
				TEMPLATE_REALIZATION.DataBind();
			}
			for (int i = 1; i <= TEMPLATE_REALIZATION.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) TEMPLATE_REALIZATION.Items[i-1].Cells[2].FindControl("HP_DOWNLOAD_REALIZATION");
				HpDownload.NavigateUrl = url;
			}
		}

		private void FillDGRTarget()
		{
			conn.QueryString = "SELECT *, CASE IS_FOCUS WHEN 1 THEN 'YES' ELSE 'NO' END AS IS_FOCUS2 FROM AP_TARGET";
			BindData(DGR_DATA_UPLOAD_TARGET.ID.ToString(), conn.QueryString);
		}

		private void FillDGRRealization()
		{
			conn.QueryString = "SELECT *, CASE IS_FOCUS WHEN 1 THEN 'YES' ELSE 'NO' END AS IS_FOCUS2 FROM AP_DASHBOARD_DATA_UPLOAD";
			BindData(DGR_DATA_UPLOAD_REALIZATION.ID.ToString(), conn.QueryString);
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();

				System.Data.DataTable dt = new System.Data.DataTable();
				dt = conn.GetDataTable().Copy();

				System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);
				dg.DataSource = dt;

				try
				{
					dg.DataBind();
				}
				catch
				{
					dg.CurrentPageIndex = dg.PageCount - 1;
					dg.DataBind();
				}

				conn.ClearData();
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
			this.DGR_DATA_UPLOAD_TARGET.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_DATA_UPLOAD_TARGET_PageIndexChanged);
			this.DGR_DATA_UPLOAD_REALIZATION.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_DATA_UPLOAD_REALIZATION_PageIndexChanged);
		}
		#endregion

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			//Get Export Properties
			conn.QueryString = "EXEC AP_UPLOAD_DASHBOARD_TARGET '" + Session["USERID"].ToString() + "','" +
				Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_PENCAPAIAN) as MAX_ID from [AP_DASHBOARD_UPLOAD]";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_PENCAPAIAN_NAME from [AP_DASHBOARD_UPLOAD] where ID_UPLOAD_PENCAPAIAN = '" + max_id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_PENCAPAIAN_NAME");
			}

			conn.QueryString = "SELECT EXPORT_URL FROM RFEXPORT WHERE EXPORT_ID = 'ACCOUNTPLANNING01'";
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
							//ViewUploadFiles();
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
					ReadExcel(directory + outputfilename);
				}
				catch {}
			}
			//ViewUploadFiles();
		}

		private void ReadExcel(string filename)
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
				conn.QueryString = "SELECT * FROM AP_TEMPLATE_MASTER WHERE ID_UPLOAD = '5'";
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
						conn.QueryString = "SELECT CELL_COL, DB_FIELD FROM AP_TEMPLATE_DETAIL WHERE ID_UPLOAD='5' ORDER BY ID_VALIDATION_TEMPLATE";
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
												case "N":
													par[j] = 0;
													dttype[j] = (string)datatype;
													break;
												case "DT":
													par[j] = "";
													dttype[j] = (string)datatype;
													break;
												default:
													break;
											}
										}
										else
										{
											flag = true;
										}
									}
								}
								string tgl;
								//-----------------------------------------------------------------------------------//
								//Construct Query
								if(flag == false)
								{
									string query = "EXEC " + proc + " '" 
										//+ id_upload + "','"
										+ TXT_XLSNAME.Text + "',";
									for (int k = 0; k < n; k++)
									{
										if (dttype[k].ToString() == "V")
											query = query + "'" + par[k].ToString() + "'";
										else if (dttype[k].ToString() == "N")
											query = query + "" + par[k].ToString() + "";
										else if (dttype[k].ToString() == "DT")
										{
											if(par[k].ToString()=="0")
											{
												tgl = tools.ConvertDate("01", "01", "1900");
												query = query + "" + tgl + "";
											}
											else
											{
												//tgl = par[k].ToString().Length();
												conn.QueryString = "EXEC DASHBOARD_CREATE_TGL '" + par[k].ToString() + "'";
												conn.ExecuteQuery();
												tgl = tools.ConvertDate(conn.GetFieldValue(0,0),conn.GetFieldValue(0,1),conn.GetFieldValue(0,2));
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
							LBL_STATUS.ForeColor = Color.Green;
							LBL_STATUSREPORT.ForeColor = Color.Green;
							LBL_STATUS.Text = "Upload Sucessful! Insert Result Sucessful!";
							LBL_STATUSREPORT.Text = "";
						}
					}
				}
			}
			catch(Exception ex)
			{
				LBL_STATUS.ForeColor = Color.Green;
				LBL_STATUSREPORT.ForeColor = Color.Red;
				LBL_STATUS.Text = "Upload Sucessful!";
				LBL_STATUSREPORT.Text = "Gagal memasukkan data! Silahkan periksa kembali format datanya !";	
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

				FillDGRTarget();
			}
		}

		protected void BTN_UPLOAD_REALIZATION_Click(object sender, System.EventArgs e)
		{

			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			//Get Export Properties
			conn.QueryString = "EXEC AP_UPLOAD_DASHBOARD_TARGET '" + Session["USERID"].ToString() + "','" +
				Path.GetFileName(TXT_FILE_UPLOAD_REALIZATION.PostedFile.FileName) + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_PENCAPAIAN) as MAX_ID from [AP_DASHBOARD_UPLOAD]";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_PENCAPAIAN_NAME from [AP_DASHBOARD_UPLOAD] where ID_UPLOAD_PENCAPAIAN = '" + max_id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_PENCAPAIAN_NAME");
			}

			conn.QueryString = "SELECT EXPORT_URL FROM RFEXPORT WHERE EXPORT_ID = 'ACCOUNTPLANNING01'";
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

							LBL_STATUS_REALIZATION.ForeColor = Color.Green;
							LBL_STATUSREPORT_REALIZATION.ForeColor = Color.Green;
							LBL_STATUS_REALIZATION.Text = "Upload Successful!";
							LBL_STATUSREPORT_REALIZATION.Text = "<u>File #" + counter.ToString() + "</u><br>" + 
								"File Content Type: " + userPostedFile.ContentType + "<br>" + 
								"File Size: " + userPostedFile.ContentLength + " bytes<br>" + 
								"File Name: " + userPostedFile.FileName + "<br>" +
								"Location Where Saved: " + directory + outputfilename + "<p>";

							//View Upload File
							//ViewUploadFiles();
						}
					}
					catch (Exception ex)
					{
						LBL_STATUS_REALIZATION.ForeColor = Color.Red;
						LBL_STATUSREPORT_REALIZATION.ForeColor = Color.Red;
						LBL_STATUS_REALIZATION.Text = "Upload Failed!";
						LBL_STATUSREPORT_REALIZATION.Text = ex.Message + "\n" + ex.StackTrace;
					}
				}

				try
				{
					ReadExcelPencapaian(directory + outputfilename);
				}
				catch {}
			}
			//ViewUploadFiles();
		}

		private void ReadExcelPencapaian(string filename)
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
				conn.QueryString = "SELECT * FROM AP_TEMPLATE_MASTER WHERE ID_UPLOAD = '6'";
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
						conn.QueryString = "SELECT CELL_COL, DB_FIELD FROM AP_TEMPLATE_DETAIL WHERE ID_UPLOAD='5' ORDER BY ID_VALIDATION_TEMPLATE";
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
												case "N":
													par[j] = 0;
													dttype[j] = (string)datatype;
													break;
												case "DT":
													par[j] = "";
													dttype[j] = (string)datatype;
													break;
												default:
													break;
											}
										}
										else
										{
											flag = true;
										}
									}
								}
								string tgl;
								//-----------------------------------------------------------------------------------//
								//Construct Query
								if(flag == false)
								{
									string query = "EXEC " + proc + " '" 
										//+ id_upload + "','"
										+ TXT_XLSNAME.Text + "',";
									for (int k = 0; k < n; k++)
									{
										if (dttype[k].ToString() == "V")
											query = query + "'" + par[k].ToString() + "'";
										else if (dttype[k].ToString() == "N")
											query = query + "" + par[k].ToString() + "";
										else if (dttype[k].ToString() == "DT")
										{
											if(par[k].ToString()=="0")
											{
												tgl = tools.ConvertDate("01", "01", "1900");
												query = query + "" + tgl + "";
											}
											else
											{
												//tgl = par[k].ToString().Length();
												conn.QueryString = "EXEC DASHBOARD_CREATE_TGL '" + par[k].ToString() + "'";
												conn.ExecuteQuery();
												tgl = tools.ConvertDate(conn.GetFieldValue(0,0),conn.GetFieldValue(0,1),conn.GetFieldValue(0,2));
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
							LBL_STATUS_REALIZATION.ForeColor = Color.Green;
							LBL_STATUSREPORT_REALIZATION.ForeColor = Color.Green;
							LBL_STATUS_REALIZATION.Text = "Upload Sucessful! Insert Result Sucessful!";
							LBL_STATUSREPORT_REALIZATION.Text = "";
						}
					}
				}
			}
			catch(Exception ex)
			{
				LBL_STATUS_REALIZATION.ForeColor = Color.Green;
				LBL_STATUSREPORT_REALIZATION.ForeColor = Color.Red;
				LBL_STATUS_REALIZATION.Text = "Upload Sucessful!";
				LBL_STATUSREPORT_REALIZATION.Text = "Gagal memasukkan data! Silahkan periksa kembali format datanya !";	
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

				FillDGRRealization();
			}
		}

		private void DGR_DATA_UPLOAD_TARGET_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_DATA_UPLOAD_TARGET.CurrentPageIndex = e.NewPageIndex;
			FillDGRTarget();
		}

		private void DGR_DATA_UPLOAD_REALIZATION_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_DATA_UPLOAD_REALIZATION.CurrentPageIndex = e.NewPageIndex;
			FillDGRRealization();
		}
	}
}
