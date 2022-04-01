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

namespace SME.DCM.DataDictionary.Facilities.InquiryDataDictionary
{
	/// <summary>
	/// Summary description for CollateralDetailData.
	/// </summary>
	public partial class CollateralDetailData : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				ViewData();
				LBL_TEMPLATE.Text = "DD-FACILITIES-COLLATERAL";
				string qryddl = "SELECT DISTINCT TEMPLATE_ID, TEMPLATE_DESC FROM DD_DOCEXPORT_TEMPLATE_MASTER WHERE TEMPLATE_GROUP = '" + LBL_TEMPLATE.Text + "'";;
				GlobalTools.fillRefList(DDL_FORMAT_TYPE, qryddl , false, conn);
				ViewExportFiles();
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
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);
			this.DATA_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_ItemCommand);

		}
		#endregion

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("DataType.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		private void ViewData()
		{
			conn.QueryString = "select * from DD_FIELDS_AGUNAN where is_active='1'";
			conn.ExecuteQuery();
			FillGrid();
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = 0;
				DatGrd.DataBind();
			}			
		}

		protected void BTN_SEARCH_FIELD_Click(object sender, System.EventArgs e)
		{
			SearchDataField();
		}

		private void SearchDataField()
		{
			if (TXT_FIELD_NAME.Text!= "")
			{
				conn.QueryString = "select * from DD_FIELDS_AGUNAN where fieldsname like '%"+ TXT_FIELD_NAME.Text +"%' and is_active='1'";
				conn.ExecuteQuery();
			}
			else
			{
				conn.QueryString = "select * from DD_FIELDS_AGUNAN where is_active='1'";
				conn.ExecuteQuery();
			}
			FillGrid();
		}

		protected void BTN_SEARCH_DESC_Click(object sender, System.EventArgs e)
		{
			SearchDataDesc();
		}

		private void SearchDataDesc()
		{
			if (TXT_DESC.Text!= "")
			{
				conn.QueryString = "select * from DD_FIELDS_AGUNAN where fieldsdescription like '%"+ TXT_DESC.Text +"%' and is_active='1'";
				conn.ExecuteQuery();
			}
			else
			{
				conn.QueryString = "select * from DD_FIELDS_AGUNAN where is_active='1'";
				conn.ExecuteQuery();
			}
			FillGrid();
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;			

			if (TXT_FIELD_NAME.Text != "" && TXT_DESC.Text== "")
			{
				conn.QueryString = "select * from DD_FIELDS_AGUNAN where fieldsname like '%"+ TXT_FIELD_NAME.Text +"%' and is_active='1' ";
				conn.ExecuteQuery();
				FillGrid();
			}

			if (TXT_FIELD_NAME.Text== "" && TXT_DESC.Text != "")
			{
				conn.QueryString = "select * from DD_FIELDS_AGUNAN where fieldsdescription like '%"+ TXT_DESC.Text +"%' and is_active='1' ";
				conn.ExecuteQuery();
				FillGrid();
			}

			if (TXT_FIELD_NAME.Text!= "" && TXT_DESC.Text != "")
			{
				conn.QueryString = "select * from DD_FIELDS_AGUNAN where fieldsname like '%"+ TXT_FIELD_NAME.Text +"%' and is_active='1'";
				conn.ExecuteQuery();
				FillGrid();
			}
			
			else
			{
				ViewData();
			}
		}

		private void ViewExportFiles()
		{
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT * FROM VW_DD_DOCEXPORT_VIEWFILEEXPORT WHERE TEMPLATE_GROUP = '" + LBL_TEMPLATE.Text + "' AND FE_USERID = '" + Session["UserID"].ToString() + "'";
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

		private void deleteFile(string directory, string filename) 
		{
			if (File.Exists(directory + filename)) 
			{
				File.Delete(directory + filename);
			}
		}

		private string CreateExcel2(string templateid)
		{
			string templatefilename = "", 
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
			conn.QueryString = "SELECT TOP 1 * FROM VW_DD_DOCEXPORT_PARAMETER WHERE TEMPLATE_ID = '"+ LBL_TEMPLATE.Text +"'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				templatefilename = conn.GetFieldValue("TEMPLATE_FILENAME");
				outputfilename = conn.GetFieldValue("UPLOAD_FILEFORMAT").Replace("#USERID$",Session["UserID"].ToString()) + ".XLS";
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
					conn.QueryString = "SELECT SHEET_ID, SHEET_SEQ, STOREDPROCEDURE FROM DD_DOCEXPORT_TEMPLATE_MASTER WHERE TEMPLATE_ID = '"+ LBL_TEMPLATE.Text +"'";
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
							conn.QueryString = "EXEC " + proc + " '" + 
								TXT_FIELD_NAME.Text + "' , '" +
								TXT_DESC.Text + "' ";								
							conn.ExecuteQuery();
							dt3 = conn.GetDataTable().Copy();

							if (dt3.Rows.Count > 0)
							{
								//Loop for Template Detail //cek prosedur
								conn.QueryString = "SELECT CELL_ROW, CELL_COL, DB_FIELD FROM DD_DOCEXPORT_TEMPLATE_DETAIL WHERE TEMPLATE_ID = '"+ LBL_TEMPLATE.Text +"' AND SHEET_ID = '" + sheetid + "' AND SHEET_SEQ = '" + sheetseq + "' ORDER BY SEQ";
								conn.ExecuteQuery();
								dt2 = conn.GetDataTable().Copy();

								for (int k = 0; k < dt3.Rows.Count; k++)
								{
									for (int j = 0; j < dt2.Rows.Count; j++)
									{
										int irow;
										try {irow = int.Parse(dt2.Rows[j][0].ToString().Trim()) + k;}
										catch {irow = 1;}
										string xrow = irow.ToString().Trim();
										string xcol = dt2.Rows[j][1].ToString().Trim();
										string dbfield = dt2.Rows[j][2].ToString().Trim();
										string cell_value = dt3.Rows[k][dbfield].ToString().Trim();
										string xcell = xcol + xrow;

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
							conn.QueryString = "EXEC DD_DOCEXPORT_SAVE '1', '" + 
								templateid + "', '" + 								
								Session["UserID"].ToString().Trim() + "', '" + 
								outputfilename + "', 1";
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

		protected void BTN_EXPORT_Click(object sender, System.EventArgs e)
		{
			string status = "", doctype = "", acttype = "";
			try
			{
				conn.QueryString = "SELECT DOC_TYPE, ACTION_TYPE FROM DD_DOCEXPORT_TEMPLATE_MASTER WHERE TEMPLATE_ID = '" + DDL_FORMAT_TYPE.SelectedValue + "'";
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

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					try 
					{					
						conn.QueryString = "SELECT TOP 1 UPLOAD_PATH FROM VW_DD_DOCEXPORT_PARAMETER WHERE TEMPLATE_GROUP = '"+ LBL_TEMPLATE.Text +"'";
						conn.ExecuteQuery();

						if (conn.GetRowCount() > 0)
						{
							string directory = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());
						
							//Delete File Physically
							deleteFile(directory, e.Item.Cells[3].Text);
							Response.Write("<!-- file : " + directory + e.Item.Cells[3].Text + " -->");
							Response.Write("<!-- file is deleted. -->");

							conn.QueryString = "EXEC DD_DOCEXPORT_SAVE '2', '" + e.Item.Cells[1].Text +
								"', '" + e.Item.Cells[2].Text + "', '" + e.Item.Cells[3].Text + "', " + e.Item.Cells[7].Text;
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

	}
}
