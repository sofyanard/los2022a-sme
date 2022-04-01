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

namespace SME.LMS
{
	/// <summary>
	/// Summary description for GeneralInfo.
	/// </summary>
    public partial class GeneralInfo : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
		//protected CommonForm.DocumentExport DocExport1;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				//Set Button
				if (Request.QueryString["scr"] == "1") //Loan Review
				{
					TR_REV.Visible = true;
					TR_ACC.Visible = false;
					TR_ADVIS.Visible = false;
					TR_ADVISREPLY.Visible = false;
				}
				else if (Request.QueryString["scr"] == "2") //Acceptance Loan Review (BU)
				{
					TR_REV.Visible = false;
					TR_ACC.Visible = true;
					TR_ADVIS.Visible = false;
					TR_ADVISREPLY.Visible = false;
				}
				else if (Request.QueryString["scr"] == "2b") //Acceptance Loan Review (Risk)
				{
					TR_REV.Visible = false;
					TR_ACC.Visible = true;
					TR_ADVIS.Visible = true;
					TR_ADVISREPLY.Visible = false;
				}
				else if (Request.QueryString["scr"] == "7") //Loan Review Finish
				{
					TR_REV.Visible = true;
					TR_ACC.Visible = false;
					TR_ADVIS.Visible = false;
					TR_ADVISREPLY.Visible = false;
				}
				else if (Request.QueryString["scr"] == "5b") //Advis Loan Review
				{
					TR_REV.Visible = false;
					TR_ACC.Visible = false;
					TR_ADVIS.Visible = false;
					TR_ADVISREPLY.Visible = true;
				}
				else
				{
					TR_REV.Visible = false;
					TR_ACC.Visible = false;
					TR_ADVIS.Visible = false;
					TR_ADVISREPLY.Visible = false;
				}

				//Set Acquire Info
				TR_ACQINFO.Visible = false;
				TR_ACQINFO1.Visible = false;
				ViewAcquireInfo();

				ViewExportFiles();
				ViewUploadFiles();
				ViewRemark();

				FillDDL();
				CheckBussinessUnit();
				BindDataWatchlist();
				ViewResult();

				DocExport1.GroupTemplate = "LMS_CHECKLIST";
			}
			ViewMenu();

			InitializeEvent();
			TR_DOCEXPORT_OLD.Visible = false;
			TR_DOCEXPORT_OLD2.Visible = false;
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				string mc1 = Request.QueryString["mc"];
				string mc2 = Request.QueryString["mc"];
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						else	strtemp = "lmsreg="+Request.QueryString["lmsreg"]+"&mc="+Request.QueryString["mc"]+"&scr="+Request.QueryString["scr"];
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

		private void SetButton()
		{
			BTN_FWDTOACC.Visible = false;
			BTN_UPDTOWATCH.Visible = false;
			BTN_FINISH.Visible = false;
			BTN_SAVE.Visible = false;
			BTN_EXPORT.Visible = false;

			string iswatchlist, ischecklist;

			conn.QueryString = "EXEC LMS_GENERALINFO_SETBUTTON '"+Request.QueryString["lmsreg"]+"'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				iswatchlist = conn.GetFieldValue("ISWATCHLIST");

				if (iswatchlist == "1")
				{
					BTN_UPDTOWATCH.Visible = true;
					BTN_FWDTOACC.Visible = false;
					BTN_FINISH.Visible = false;

					//pemegang keputusan boleh ubah data checklist
					if (TR_ACC.Visible == true)
						BTN_ACCEPT.Visible = false;
				}
				else if (iswatchlist == "0")
				{
					BTN_UPDTOWATCH.Visible = false;
					BTN_FWDTOACC.Visible = true;
					BTN_FINISH.Visible = false;

					//pemegang keputusan boleh ubah data checklist
					if (TR_ACC.Visible == true)
						BTN_ACCEPT.Visible = true;
				}
				else if (iswatchlist == "FINISH")
				{
					BTN_UPDTOWATCH.Visible = false;
					BTN_FWDTOACC.Visible = false;
					BTN_FINISH.Visible = true;
				}

				ischecklist = conn.GetFieldValue("ISCHECKLIST");

				if (ischecklist == "1")
				{
					BTN_SAVE.Visible = true;
					BTN_EXPORT.Visible = true;
				}
			}
		}

		private void ViewAcquireInfo()
		{
			conn.QueryString = "EXEC LMS_GENERALINFO_VIEWACQUIRE '"+Request.QueryString["lmsreg"]+"'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				string textacqinfo = conn.GetFieldValue("LMS_ACQINFO");

				if (textacqinfo != "")
				{
					TR_ACQINFO.Visible = true;
					TR_ACQINFO1.Visible = true;
					TXT_ACQINFO.Text = textacqinfo;
				}
			}
		}

		private string CreateExcel()
		{
			string templateid = "",
				templatefilename = "", 
				outputfilename = "", 
				templatepath = "", 
				outputpath = "";
			string returnmsg = string.Empty;
			int writeitem = 0;
			bool savestatus;

			string fileIn = string.Empty;
			string fileOut = string.Empty;
			System.Data.DataTable dt1;
			System.Data.DataTable dt2;
			System.Data.DataTable dt3;

			System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
			System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

			Excel.Application excelApp = null;
			Excel.Workbook excelWorkBook = null;
			Excel.Sheets excelSheet = null;

			ArrayList orgId = new ArrayList();
			ArrayList newId = new ArrayList();
				
			//Collecting Existing Excel in Taskbar
			Process[] oldProcess = Process.GetProcessesByName("EXCEL");
			foreach(Process thisProcess in oldProcess)
				orgId.Add(thisProcess);

			//Get Export Properties
			conn.QueryString = "SELECT * FROM VW_LMS_PARAMETER";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				templateid = conn.GetFieldValue("CHKLST_TMPLID");
				templatefilename = conn.GetFieldValue("CHECKLIST_TEMPLATE_FILE");
				outputfilename = conn.GetFieldValue("CHKLST_INITFILENAME") + "-" + Request.QueryString["lmsreg"] + "-" + Session["UserID"].ToString() + ".XLS";
				templatepath = Server.MapPath(conn.GetFieldValue("TEMPLATE_PATH").Trim());
				outputpath = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());

				try
				{
					excelApp = new Excel.ApplicationClass();
					excelApp.Visible = false;
					excelApp.DisplayAlerts = false;

					//Collectiong Existing Excel in Taskbar
					Process[] newProcess = Process.GetProcessesByName("EXCEL");
					foreach(Process thisProcess in newProcess)
						newId.Add(thisProcess);

					//Save process into database
					//SupportTools.saveProcessExcel(excelApp, newId, orgId, conn);

					fileIn = templatepath + templatefilename;
					excelWorkBook = excelApp.Workbooks.Open(fileIn, 0, false, 5, string.Empty, string.Empty, true, Excel.XlPlatform.xlWindows, "\t|",
						false, false, 0, true);

					excelSheet = excelWorkBook.Worksheets;

					//Loop for Template Master
					conn.QueryString = "SELECT SHEET_ID, SHEET_SEQ, STOREDPROCEDURE FROM LMS_RFTEMPLATE WHERE TEMPLATE_ID = '" + templateid + "'";
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

							//Query Stored Procedure
							conn.QueryString = "EXEC " + proc + " '" + Request.QueryString["lmsreg"] + "'";
							conn.ExecuteQuery();
							dt3 = conn.GetDataTable().Copy();

							if (dt3.Rows.Count > 0)
							{
								//Loop for Template Detail
								conn.QueryString = "SELECT EXCEL_ROW, EXCEL_COL, DB_FIELD FROM LMS_RFTEMPLATE_DETAIL WHERE SHEET_ID = '" + 
									sheetid + "' AND SHEET_SEQ = '" + sheetseq + "' ORDER BY SEQ";
								conn.ExecuteQuery();
								dt2 = conn.GetDataTable().Copy();

								for (int j = 0; j < dt2.Rows.Count; j++)
								{
									string xrow = dt2.Rows[j][0].ToString().Trim();
									string xcol = dt2.Rows[j][1].ToString().Trim();
									string dbfield = dt2.Rows[j][2].ToString().Trim();
									string cell_value = dt3.Rows[0][dbfield].ToString().Trim();
									string xcell = xcol + xrow;

									Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(xcell, xcell);
									if (excelCell != null)
									{
										excelCell.Value2 = cell_value;
										writeitem++;
									}
								}
							}
							else
							{
								//returnmsg = "Query Has No Row!!";
								//return returnmsg;
							}
						}

						
						//if (writeitem > 0)
						//{
							//Save Excel File
							fileOut = outputpath + outputfilename;
							excelWorkBook.SaveAs(fileOut, Excel.XlFileFormat.xlWorkbookNormal, null, null, null, null,
								Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, true);

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
							conn.QueryString = "EXEC LMS_GENERALINFO_EXPORTSAVE '1', '" + Request.QueryString["lmsreg"] +
								"', '" + templateid + "', '" + Session["UserID"].ToString().Trim() + "', '" + outputfilename + "'";
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
					if(excelWorkBook!=null)
					{
						excelWorkBook.Close(true , fileOut, null);
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
			conn.QueryString = "EXEC LMS_GENERALINFO_VIEWEXPORT '" + Request.QueryString["lmsreg"] + "'";
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
				HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[4].FindControl("FE_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[5].FindControl("FE_DELETE");
				HpDownload.NavigateUrl = DATA_EXPORT.Items[i-1].Cells[6].Text.Trim();
				if (Session["UserID"].ToString().Trim() != DATA_EXPORT.Items[i-1].Cells[2].Text)
					HpDelete.Visible	= false;
			}
		}

		private void UploadExcel()
		{
			string directory;
			int counter = 0;
			string templateid, outputfilename, initfilename;
			
			//Get Export Properties
			conn.QueryString = "SELECT * FROM VW_LMS_PARAMETER";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());
				templateid = conn.GetFieldValue("CHKLSTSUMM_TMPLID");
				initfilename = conn.GetFieldValue("CHKLSTSUMM_INITFILENAME");

				HttpFileCollection uploadedFiles = Request.Files;

				for (int i = 0; i < uploadedFiles.Count; i++)
				{
					HttpPostedFile userPostedFile = uploadedFiles[i];
					counter = i + 1;

					try
					{
						if (userPostedFile.ContentLength > 0)
						{
							outputfilename = Request.QueryString["lmsreg"].Trim() + "-"+ Session["USERID"].ToString() +"-" + Path.GetFileName(userPostedFile.FileName);
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
							conn.QueryString = "EXEC LMS_GENERALINFO_UPLOADSAVE '1', '" + Request.QueryString["lmsreg"] +
								"', '', '" + Session["UserID"].ToString().Trim() + "', '" + outputfilename + "'";
							conn.ExecuteQuery();

							//View Upload File
							ViewUploadFiles();

							//Read from Excel
							ReadExcel(directory + outputfilename, templateid);

							ViewResult();
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

		private void ViewUploadFiles()
		{
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "EXEC LMS_GENERALINFO_VIEWUPLOAD '" + Request.QueryString["lmsreg"] + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrid.DataSource = dt;
			try 
			{
				DatGrid.DataBind();
			} 
			catch 
			{
				DatGrid.CurrentPageIndex = 0;
				DatGrid.DataBind();
			}
			for (int i = 1; i <= DatGrid.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DatGrid.Items[i-1].Cells[4].FindControl("FU_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DatGrid.Items[i-1].Cells[5].FindControl("FU_DELETE");
				HpDownload.NavigateUrl = DatGrid.Items[i-1].Cells[6].Text.Trim();
				if (Session["UserID"].ToString().Trim() != DatGrid.Items[i-1].Cells[2].Text)
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
				conn.QueryString = "SELECT SHEET_ID, SHEET_SEQ, STOREDPROCEDURE FROM LMS_RFTEMPLATE WHERE TEMPLATE_ID = '" + templateid + "'";
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
						conn.QueryString = "SELECT EXCEL_ROW, EXCEL_COL, DB_FIELD FROM LMS_RFTEMPLATE_DETAIL WHERE SHEET_ID = '" + 
							sheetid + "' AND SHEET_SEQ = '" + sheetseq + "' ORDER BY SEQ";
						conn.ExecuteQuery();
						dt2 = conn.GetDataTable().Copy();
						int n = dt2.Rows.Count;
						object[] par;
						par = new object[n];

						if (dt2.Rows.Count > 0)
						{
							for (int j = 0; j < dt2.Rows.Count; j++)
							{
								string xrow = dt2.Rows[j][0].ToString().Trim();
								string xcol = dt2.Rows[j][1].ToString().Trim();
								string dbfield = dt2.Rows[j][2].ToString().Trim();
								string cell_value;
								string xcell = xcol + xrow;

								Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(xcell, xcell);
								if (excelCell != null)
								{
									cell_value = excelCell.Value2.ToString();
									par[j] = (string)cell_value;
								}
							}

							//Construct Query
							string query = "EXEC " + proc + " '" + Request.QueryString["lmsreg"] + "', '";
							for (int k = 0; k < n; k++)
							{
								if (k < n-1)
									query = query + par[k].ToString() + "', '";
								else
									query = query + par[k].ToString() + "'";
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

		private void InitializeEvent()
		{
			BTN_FWDTOACC.Attributes.Add("onclick","if(!update()){return false;};");
			BTN_UPDTOWATCH.Attributes.Add("onclick","if(!update()){return false;};");
			BTN_FINISH.Attributes.Add("onclick","if(!update()){return false;};");
			BTN_ACCEPT.Attributes.Add("onclick","if(!update()){return false;};");
			BTN_NOREVIEW.Attributes.Add("onclick","if(!update()){return false;};");
			this.TXT_TEMP.TextChanged += new EventHandler(TXT_TEMP_TextChanged);
		}

		private void SaveRemark()
		{
			try
			{
				conn.QueryString = "UPDATE LMS_APPLICATION SET LMS_APRVREMARK = '" + TXT_REMARK.Text + 
					"' WHERE LMS_REGNO = '" + Request.QueryString["lmsreg"] + "'";
				conn.ExecuteQuery();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		private void ViewRemark()
		{
			try
			{
				conn.QueryString = "SELECT LMS_APRVREMARK FROM LMS_APPLICATION WHERE LMS_REGNO = '" + Request.QueryString["lmsreg"] + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					TXT_REMARK.Text = conn.GetFieldValue("LMS_APRVREMARK");
				}
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		private void FillDDL()
		{
			GlobalTools.fillRefList(DDL_BUSSUNIT, "SELECT * FROM RFBUSINESSUNIT WHERE ACTIVE='1'", true, conn);

			if (TR_ADVIS.Visible == true)
			{
				GlobalTools.fillRefList(DDL_ADVIS,"exec LMS_WATCHLIST_FILLDDL_ADVIS '" + Request.QueryString["lmsreg"] + "', '" + Session["UserID"].ToString() + "'",false,conn);
			}
		}

		private void CheckBussinessUnit()
		{
			conn.QueryString = "SELECT * FROM VW_WATCHLIST_CHECKBUSINESSUNIT WHERE LMS_REGNO = '" + Request.QueryString["lmsreg"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				if (conn.GetFieldValue("BUSSUNITID") != "")
				{
					try
					{
						DDL_BUSSUNIT.SelectedValue = conn.GetFieldValue("BUSSUNITID");
						DDL_BUSSUNIT.Enabled = false;
					}
					catch {}
				}
				else
				{
					try
					{
						DDL_BUSSUNIT.SelectedValue = "";
						DDL_BUSSUNIT.Enabled = true;
					}
					catch {}
				}
			}
		}

		private void BindDataWatchlist()
		{
			conn.QueryString = "SELECT * FROM VW_WATCHLIST_ITEM_PARAM2 WHERE BUSSUNITID = '" + DDL_BUSSUNIT.SelectedValue + "' ORDER BY WATCHID, DISPNO";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_WATCH.DataSource = dt;
			try 
			{
				DGR_WATCH.DataBind();
			}
			catch 
			{
				DGR_WATCH.CurrentPageIndex = 0;
				DGR_WATCH.DataBind();
			}

			BindDataWatchlist2();
			BindDataWatchlist3();
		}

		private void BindDataWatchlist2()
		{
			for (int i=0;i<DGR_WATCH.Items.Count;i++)
			{
				RadioButtonList rblsubsubwatch = (RadioButtonList) DGR_WATCH.Items[i].Cells[5].FindControl("RBL_SUBSUBWATCH");

				conn.QueryString = "exec LMS_WATCHLIST_ITEM_VIEWDATA '" + Request.QueryString["lmsreg"] + 
					"', '" + DGR_WATCH.Items[i].Cells[0].Text.Trim() + 
					"', '" + DGR_WATCH.Items[i].Cells[1].Text.Trim() + 
					"', '" + DGR_WATCH.Items[i].Cells[2].Text.Trim() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtsubsubwatch = new DataTable();
					dtsubsubwatch = conn.GetDataTable().Copy();

					string subsubwatchid = "", subsubwatchweight = "", subsubwatchmand = "", 
						subsubwatchrvwkolbi = "", subsubwatchpilarbi = "";
					DataRow[] drs = dtsubsubwatch.Select();
					foreach (DataRow dr in drs)
					{
						if (dr["ISCHECKED"].ToString() == "1")
						{
							subsubwatchid = dr["SUBSUBWATCHID"].ToString();
							subsubwatchweight = dr["WEIGHT"].ToString();
							subsubwatchmand = dr["ISMANDATORYDESC"].ToString();
							subsubwatchrvwkolbi = dr["RVWKOLBIDESC"].ToString();
							subsubwatchpilarbi = dr["PILARBIDESC"].ToString();
						}
					}

					rblsubsubwatch.DataSource = dtsubsubwatch;
					try 
					{
						rblsubsubwatch.DataValueField = "SUBSUBWATCHID";
						rblsubsubwatch.DataTextField = "SUBSUBWATCHDESC";
						if (subsubwatchid != "")
							try {rblsubsubwatch.SelectedValue = subsubwatchid;} 
							catch {}
						rblsubsubwatch.DataBind();

						//Fill column WEIGHT and ISMANDATORY
						DGR_WATCH.Items[i].Cells[7].Text = subsubwatchweight;
						DGR_WATCH.Items[i].Cells[8].Text = subsubwatchmand;
						DGR_WATCH.Items[i].Cells[9].Text = subsubwatchrvwkolbi;
						DGR_WATCH.Items[i].Cells[10].Text = subsubwatchpilarbi;
					} 
					catch {}
				}
			}
		}

		private void BindDataWatchlist3()
		{
			conn.QueryString = "exec LMS_WATCHLIST_ITEM_VIEWSUMMARY '" + Request.QueryString["lmsreg"] + "'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_SUMMARY.DataSource = dt;
			try 
			{
				DGR_SUMMARY.DataBind();
			}
			catch 
			{
				DGR_SUMMARY.CurrentPageIndex = 0;
				DGR_SUMMARY.DataBind();
			}
		}

		private void ViewResult()
		{
			try
			{
				conn.QueryString = "EXEC LMS_WATCHLIST_ITEM_VIEWRESULT '" + Request.QueryString["lmsreg"] + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					TXT_KATEGORI.Text = conn.GetFieldValue("KATEGORI");
					TXT_FAKTOR.Text = conn.GetFieldValue("FAKTOR_PENYEBAB");
					TXT_FOLLOW.Text = conn.GetFieldValue("FOLLOW_UP");
					TXT_REKOMENDASI.Text = conn.GetFieldValue("REKOMENDASI_KOLSTATUS");
					TXT_REVW3PILAR.Text = conn.GetFieldValue("REVIEW_3PILARBI");
				}

				SetButton();
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				//Response.Write("<!--"+ex.ToString()+"-->");
				return;
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
			this.DGR_WATCH.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_WATCH_PageIndexChanged);
			this.DATA_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_ItemCommand);
			this.DatGrid.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrid_ItemCommand);
			this.ID = "GenInfo1";

		}
		#endregion

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string url = "SearchCustomer.aspx?mc=" + Request.QueryString["mc"];
			if (Request.QueryString["tc"] != "")
			{
				url = url + "&tc=" + Request.QueryString["tc"];
			}
			if (Request.QueryString["scr"] != "")
			{
				url = url + "&scr=" + Request.QueryString["scr"];
			}
			Response.Redirect(url);
		}

		protected void BTN_FWDTOACC_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			try
			{
				conn.QueryString = "exec LMS_GENERALINFO_FORWARDTOACCEPTANCE '" + 
					Request.QueryString["lmsreg"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "'";
				conn.ExecuteQuery();
				string msg = conn.GetFieldValue("MSG");

				Response.Redirect("SearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&msg=" + msg +
					"&scr=" + Request.QueryString["scr"]);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		protected void BTN_UPDTOWATCH_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			try
			{
				conn.QueryString = "exec LMS_GENERALINFO_FORWARDTOWATCHLIST '" + 
					Request.QueryString["lmsreg"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "'";
				conn.ExecuteQuery();
				string msg = conn.GetFieldValue("MSG");

				Response.Redirect("SearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&msg=" + msg +
					"&scr=" + Request.QueryString["scr"]);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		protected void BTN_FINISH_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			try
			{
				conn.QueryString = "exec LMS_GENERALINFO_FINISH '" + 
					Request.QueryString["lmsreg"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "'";
				conn.ExecuteQuery();
				string msg = conn.GetFieldValue("MSG");

				Response.Redirect("SearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&msg=" + msg +
					"&scr=" + Request.QueryString["scr"]);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

        public string popUp = "";
        protected void BTN_ACQUIRE_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			//Response.Write("<script for=window event=onload language='javascript'>PopupPage('AcqInfo.aspx?lmsreg=" + Request.QueryString["lmsreg"] + "&tc=" + Request.QueryString["tc"] + "&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>");
            popUp = "<script for=window event=onload language='javascript'>PopupPage('AcqInfo.aspx?lmsreg=" + Request.QueryString["lmsreg"] + "&tc=" + Request.QueryString["tc"] + "&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>";
		}

		protected void BTN_ACCEPT_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			try
			{
				conn.QueryString = "exec LMS_GENERALINFO_ACCEPT '" + 
					Request.QueryString["lmsreg"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "'";
				conn.ExecuteQuery();
				string msg = conn.GetFieldValue("MSG");

				Response.Redirect("SearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&msg=" + msg +
					"&scr=" + Request.QueryString["scr"]);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		protected void BTN_EXPORT_Click(object sender, System.EventArgs e)
		{
			string status;
			try
			{
				status = CreateExcel();
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
					//Get Export Properties
					conn.QueryString = "SELECT * FROM VW_LMS_PARAMETER";
					conn.ExecuteQuery();

					if (conn.GetRowCount() > 0)
					{
						string directory = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());
				
						try 
						{					
							//Delete File Physically
							deleteFile(directory, e.Item.Cells[3].Text);
							Response.Write("<!-- file : " + directory + e.Item.Cells[3].Text + " -->");
							Response.Write("<!-- file is deleted. -->");
						} 
						catch (Exception ex) 
						{
							Response.Write("<!-- Delete File Error: " + ex.Message.ToString() + " -->");
						}

						conn.QueryString = "EXEC LMS_GENERALINFO_EXPORTSAVE '2', '" + e.Item.Cells[0].Text +
							"', '" + e.Item.Cells[1].Text + "', '" + e.Item.Cells[2].Text + "', '" + e.Item.Cells[3].Text + "'";
						conn.ExecuteQuery();

						//View Upload Files
						ViewExportFiles();
					}
					break;
			}
		}

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			UploadExcel();
		}

		private void DatGrid_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					//Get Export Properties
					conn.QueryString = "SELECT * FROM VW_LMS_PARAMETER";
					conn.ExecuteQuery();

					if (conn.GetRowCount() > 0)
					{
						string directory = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());
				
						try 
						{					
							//Delete File Physically
							deleteFile(directory, e.Item.Cells[3].Text);
							Response.Write("<!-- file : " + directory + e.Item.Cells[3].Text + " -->");
							Response.Write("<!-- file is deleted. -->");
						} 
						catch (Exception ex) 
						{
							Response.Write("<!-- Delete File Error: " + ex.Message.ToString() + " -->");
						}

						conn.QueryString = "EXEC LMS_GENERALINFO_UPLOADSAVE '2', '" + e.Item.Cells[0].Text +
							"', '" + e.Item.Cells[1].Text + "', '" + e.Item.Cells[2].Text + "', '" + e.Item.Cells[3].Text + "'";
						conn.ExecuteQuery();

						//View Upload Files
						ViewUploadFiles();
					}
					break;
			}
		}

		private void TXT_TEMP_TextChanged(object sender, EventArgs e)
		{
			if (TXT_TEMP.Text != "") 
			{
				string msg = "";
				msg = TXT_TEMP.Text;
				Response.Redirect("SearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&msg=" + msg +
					"&scr=" + Request.QueryString["scr"]);
			}
		}

		protected void BTN_NOREVIEW_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			try
			{
				conn.QueryString = "exec LMS_GENERALINFO_NOREVIEW '" + 
					Request.QueryString["lmsreg"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "'";
				conn.ExecuteQuery();
				string msg = conn.GetFieldValue("MSG");

				Response.Redirect("SearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&msg=" + msg +
					"&scr=" + Request.QueryString["scr"]);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		protected void DDL_BUSSUNIT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindDataWatchlist();
			ViewResult();
		}

		private void DGR_WATCH_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_WATCH.CurrentPageIndex = e.NewPageIndex;
			BindDataWatchlist();
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			for (int i=0; i<DGR_WATCH.Items.Count; i++)
			{
				RadioButtonList rblsubsubwatch = (RadioButtonList) DGR_WATCH.Items[i].Cells[5].FindControl("RBL_SUBSUBWATCH");

				try
				{
					conn.QueryString = "exec LMS_WATCHLIST_ITEM_SAVEDATA '" +
						Request.QueryString["lmsreg"] + "', '" +
						DGR_WATCH.Items[i].Cells[0].Text.Trim() + "', '" + 
						DGR_WATCH.Items[i].Cells[1].Text.Trim() + "', '" +
						DGR_WATCH.Items[i].Cells[2].Text.Trim() + "', '" +
						rblsubsubwatch.SelectedValue.Trim() + "'";
					conn.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					string errmsg = ex.Message.Replace("'","");
					if (errmsg.IndexOf("Last Query:") > 0)
						errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
					GlobalTools.popMessage(this, errmsg);
					//Response.Write("<!--"+ex.ToString()+"-->");
					return;
				}
			}

			BindDataWatchlist();
			ViewResult();
			SetButton();
		}

		protected void BTN_ADVIS_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "exec LMS_GENERALINFO_ADVIS '" + 
					Request.QueryString["lmsreg"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "', '" +
					DDL_ADVIS.SelectedValue + "'";
				conn.ExecuteQuery();
				string msg = conn.GetFieldValue("MSG");

				Response.Redirect("SearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&msg=" + msg +
					"&scr=" + Request.QueryString["scr"]);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		protected void BTN_ADVISREPLY_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "exec LMS_GENERALINFO_ADVISREPLY '" + 
					Request.QueryString["lmsreg"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "'";
				conn.ExecuteQuery();
				string msg = conn.GetFieldValue("MSG");

				Response.Redirect("SearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&msg=" + msg +
					"&scr=" + Request.QueryString["scr"]);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}
	}
}
