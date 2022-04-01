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

namespace SME.DCM.DataDictionary.Facilities.InquiryPendingTaskList
{
	/// <summary>
	/// Summary description for InquiryPendingTaskList.
	/// </summary>
	public partial class InquiryPendingTaskList : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewData();

			DDL_REQ_MONTH.Items.Add(new ListItem("-- Pilih --",""));
			for (int i = 1; i <= 12; i++)
			{
				DDL_REQ_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}
			FillDDLUnit();
			FillDDLPic();
			FillDDLTrack();
			FillDDLType();

			ViewExportFiles();
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT DISTINCT * FROM VW_SDC_FACILITIES_INQUIRY_PENDING_LIST ORDER BY SEQ";
			BindData(DATA_GRID.ID.ToString(), conn.QueryString);
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

				for (int i = 0; i < dg.Items.Count; i++)
				{
					dg.Items[i].Cells[2].Text = tools.FormatDate(dg.Items[i].Cells[2].Text, true);
				}

				conn.ClearData();
			}
		}

		private void FillDDLUnit()
		{
			DDL_REQ_UNIT.Items.Clear();
			DDL_REQ_UNIT.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_SDC_FACILITIES_PENDING_TASK_REQUEST_UNIT_LIST";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_REQ_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLPic()
		{
			DDL_PIC_DSO.Items.Clear();
			DDL_PIC_DSO.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_SDC_FACILITIES_PENDING_TASK_PIC_DSO_LIST";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_PIC_DSO.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLTrack()
		{
			DDL_TRACKID.Items.Clear();
			DDL_TRACKID.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_SDC_FACILITIES_PENDING_TASK_TRACK_LIST";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_TRACKID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLType()
		{
			DDL_FORMAT_TYPE.Items.Clear();
			DDL_FORMAT_TYPE.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT DISTINCT TEMPLATE_ID, TEMPLATE_DESC FROM DOCEXPORT_TEMPLATE_MASTER WHERE TEMPLATE_GROUP = 'SDCFACILITIESREQDOC2'";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_FORMAT_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void ViewExportFiles()
		{
			conn.QueryString = "SELECT * FROM VW_DOCEXPORT_VIEWFILEEXPORT WHERE TEMPLATE_GROUP = 'SDCFACILITIESREQDOC2' AND FE_USERID = '" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
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
			this.DATA_GRID.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_GRID_PageIndexChanged);
			this.DATA_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_ItemCommand);

		}
		#endregion

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			DATA_GRID.CurrentPageIndex = 0;
			SearchData();
		}

		private void SearchData()
		{
			string query = "";

			if (TXT_REQ_DAY.Text != "" && DDL_REQ_MONTH.SelectedValue != "" && TXT_REQ_YEAR.Text != "") 
			{
				if (!GlobalTools.isDateValid(TXT_REQ_DAY.Text, DDL_REQ_MONTH.SelectedValue, TXT_REQ_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Date Not Valid!");
					return;
				}

				else
				{
					query += "AND REQ_DATE = " + tools.ConvertDate(TXT_REQ_DAY.Text, DDL_REQ_MONTH.SelectedValue, TXT_REQ_YEAR.Text) + " ";
				}
			}

			if(DDL_REQ_UNIT.SelectedValue != "")
			{
				query += "AND REQ_UNIT LIKE '%" + DDL_REQ_UNIT.SelectedValue + "%' ";
			}

			if(DDL_PIC_DSO.SelectedValue != "")
			{
				query += "AND PIC LIKE '%" + DDL_PIC_DSO.SelectedValue + "%' ";
			}

			if(DDL_TRACKID.SelectedValue != "")
			{
				query += "AND TRACK_ID LIKE '%" + DDL_TRACKID.SelectedValue + "%' ";
			}

			if(query != "")
			{
				conn.QueryString = "SELECT DISTINCT * FROM VW_SDC_FACILITIES_INQUIRY_PENDING_LIST WHERE 1=1 " + query + "ORDER BY SEQ";
				BindData(DATA_GRID.ID.ToString(), conn.QueryString);
			}

			else
			{
				conn.QueryString = "SELECT DISTINCT * FROM VW_SDC_FACILITIES_INQUIRY_PENDING_LIST ORDER BY SEQ";
				BindData(DATA_GRID.ID.ToString(), conn.QueryString);
			}
		}

		protected void BTN_EXPORT_Click(object sender, System.EventArgs e)
		{
			string status = "", doctype = "", acttype = "";
			try
			{
				conn.QueryString = "SELECT DOC_TYPE, ACTION_TYPE FROM DOCEXPORT_TEMPLATE_MASTER WHERE TEMPLATE_ID = '" + DDL_FORMAT_TYPE.SelectedValue + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					doctype = conn.GetFieldValue("DOC_TYPE");
					acttype = conn.GetFieldValue("ACTION_TYPE");

					if ((doctype == "EXCEL2") && (acttype == "WRITE"))
						status = CreateExcel2(DDL_FORMAT_TYPE.SelectedValue);						
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

			ViewExportFiles();
		}

		private string CreateExcel2(string templateid)
		{
			string	templatefilename = "", outputfilename = "", templatepath = "", outputpath = "";
			string returnmsg = string.Empty;
			int writeitem = 0;
			bool savestatus;

			string fileIn	= string.Empty;
			string fileOut	= string.Empty;
			System.Data.DataTable dt1;
			System.Data.DataTable dt2;
			System.Data.DataTable dt3;

			System.Threading.Thread.CurrentThread.CurrentCulture	= System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
			System.Threading.Thread.CurrentThread.CurrentUICulture	= new System.Globalization.CultureInfo("en-US");

			Excel.Application excelApp		= null;
			Excel.Workbook excelWorkBook	= null;
			Excel.Sheets excelSheet			= null;

			ArrayList orgId = new ArrayList();
			ArrayList newId = new ArrayList();
				
			//Collecting Existing Excel in Taskbar
			Process[] oldProcess = Process.GetProcessesByName("EXCEL");
			foreach(Process thisProcess in oldProcess)
				orgId.Add(thisProcess);

			//Get Export Properties
			conn.QueryString = "SELECT TOP 1 * FROM VW_DOCEXPORT_PARAMETER WHERE TEMPLATE_ID = '" + templateid + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				templatefilename	= conn.GetFieldValue("TEMPLATE_FILENAME");
				outputfilename		= conn.GetFieldValue("UPLOAD_FILEFORMAT").Replace("#USERID$",Session["UserID"].ToString()) + ".XLS";
				templatepath		= Server.MapPath(conn.GetFieldValue("TEMPLATE_PATH").Trim());
				outputpath			= Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());

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
					conn.QueryString = "SELECT SHEET_ID, SHEET_SEQ, STOREDPROCEDURE FROM DOCEXPORT_TEMPLATE_MASTER WHERE TEMPLATE_ID = '" + templateid + "'";
					conn.ExecuteQuery();

					dt1 = conn.GetDataTable().Copy();

					if (dt1.Rows.Count > 0)
					{
						for (int i = 0; i < dt1.Rows.Count; i++)
						{
							string sheetid	= dt1.Rows[i][0].ToString().Trim();
							string sheetseq = dt1.Rows[i][1].ToString().Trim();
							string proc		= dt1.Rows[i][2].ToString().Trim();

							Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheetid);

							//Query Stored Procedure
							conn.QueryString = "EXEC " + proc + " " + tools.ConvertDate(TXT_REQ_DAY.Text, DDL_REQ_MONTH.SelectedValue, TXT_REQ_YEAR.Text);
							conn.ExecuteQuery();
							dt3 = conn.GetDataTable().Copy();

							if (dt3.Rows.Count > 0)
							{
								//Loop for Template Detail //cek prosedur
								conn.QueryString = "SELECT CELL_ROW, CELL_COL, DB_FIELD FROM DOCEXPORT_TEMPLATE_DETAIL WHERE TEMPLATE_ID = '" + templateid + "' AND SHEET_ID = '" + sheetid + "' AND SHEET_SEQ = '" + sheetseq + "' ORDER BY SEQ";
								conn.ExecuteQuery();
								dt2 = conn.GetDataTable().Copy();

								for (int k = 0; k < dt3.Rows.Count; k++)
								{
									for (int j = 0; j < dt2.Rows.Count; j++)
									{
										int irow;
										try
										{
											irow = int.Parse(dt2.Rows[j][0].ToString().Trim()) + k;
										}
										catch
										{
											irow = 1;
										}
										string xrow			= irow.ToString().Trim();
										string xcol			= dt2.Rows[j][1].ToString().Trim();
										string dbfield		= dt2.Rows[j][2].ToString().Trim();
										string cell_value	= dt3.Rows[k][dbfield].ToString().Trim();
										string xcell		= xcol + xrow;

										Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(xcell, xcell);
										if (excelCell != null)
										{
											excelCell.Value2 = cell_value;
											writeitem++;
										}
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
							//Save to Table //cek prosedur
							conn.QueryString = "EXEC DOCEXPORT_SAVE '1', '" + 
												templateid + "','" + 
												Session["BranchID"].ToString().Trim() + "','" + 
												Session["UserID"].ToString().Trim() + "','" + 
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

		private void DATA_GRID_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_GRID.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					try 
					{					
						conn.QueryString = "SELECT TOP 1 UPLOAD_PATH FROM VW_DOCEXPORT_PARAMETER WHERE TEMPLATE_GROUP = 'SDCFACILITIESREQDOC'";
						conn.ExecuteQuery();

						if (conn.GetRowCount() > 0)
						{
							string directory = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());
						
							//Delete File Physically
							deleteFile(directory, e.Item.Cells[3].Text);
							Response.Write("<!-- file : " + directory + e.Item.Cells[3].Text + " -->");
							Response.Write("<!-- file is deleted. -->");

							conn.QueryString = "EXEC DOCEXPORT_SAVE '2','" + e.Item.Cells[1].Text +	"','" + e.Item.Cells[0].Text +
								"','" + e.Item.Cells[2].Text + "','" + e.Item.Cells[3].Text + "'" ;
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

		private void deleteFile(string directory, string filename) 
		{
			if (File.Exists(directory + filename)) 
			{
				File.Delete(directory + filename);
			}
		}
	}
}
