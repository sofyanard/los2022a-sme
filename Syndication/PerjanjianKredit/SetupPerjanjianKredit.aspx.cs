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

namespace SME.Syndication.PerjanjianKredit
{
	/// <summary>
	/// Summary description for SetupPerjanjianKredit.
	/// </summary>
	public partial class SetupPerjanjianKredit : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			
			if(!IsPostBack)
			{
				CekCode();

				DDL_TGL_PK_MONTH.Items.Add(new ListItem("--Select--",""));
				DDL_TGL_ADDENDUM_MONTH.Items.Add(new ListItem("--Select--",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_TGL_PK_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_TGL_ADDENDUM_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				DDL_FORMAT_TYPE.Items.Clear();
				DDL_FORMAT_TYPE.Items.Add(new ListItem("Nota Standar Baru", "SDCPRINTPASAL"));

				ViewData();
			}
			FillDataGrid();
			ViewExportFiles();
		}

		private void ViewMenu()
		{
			Menu.Controls.Clear();
			try 
			{
				conn.QueryString = "SELECT * FROM SCREENMENU WHERE MENUCODE = '" + Request.QueryString["mc"] + "'";
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
							strtemp = "&curef=" + Request.QueryString["curef"] + "&cif=" + Request.QueryString["cif"] + "&exist=" + Request.QueryString["exist"];
						else	
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&curef=" + Request.QueryString["curef"] + "&cif=" + Request.QueryString["cif"] + "&exist=" + Request.QueryString["exist"];
					}
					else 
					{
						strtemp = ""; 
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

		private void CekCode()
		{
			conn.QueryString	= "SELECT ISNULL(MAX(CONVERT(INT, SEQ)),0)+1 AS SEQ FROM SDC_PERJANJIAN_PASAL WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			LBL_SEQ.Text		= conn.GetFieldValue("SEQ").ToString();
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT TOP 1 * FROM VW_SDC_DOC_GENERAL_INFO WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			TXT_CIF.Text							= conn.GetFieldValue("CIF").ToString().Replace("&nbsp;","");
			TXT_NAMA_DEBIT.Text						= conn.GetFieldValue("CUST_NAME").ToString().Replace("&nbsp;","");
			TXT_ALAMAT_KANPUS.Text					= conn.GetFieldValue("HQ_ADR").ToString().Replace("&nbsp;","");
			TXT_GROUP_USAHA.Text					= conn.GetFieldValue("GROUP_NM").ToString().Replace("&nbsp;","");

			conn.QueryString = "SELECT * FROM SDC_PERJANJIAN WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			LBL_SEQ1.Text							= conn.GetFieldValue("SEQ").ToString();
			TXT_NO_PK.Text							= conn.GetFieldValue("FIRST_PK_NO").ToString().Replace("&nbsp;","");
			TXT_TGL_PK_DAY.Text						= tools.FormatDate_Day(conn.GetFieldValue("FIRST_PK_DATE").ToString());
			DDL_TGL_PK_MONTH.SelectedValue			= tools.FormatDate_Month(conn.GetFieldValue("FIRST_PK_DATE").ToString());
			TXT_TGL_PK_YEAR.Text					= tools.FormatDate_Year(conn.GetFieldValue("FIRST_PK_DATE").ToString());
			TXT_NO_ADDENDUM.Text					= conn.GetFieldValue("ADM_PK_NO").ToString().Replace("&nbsp;","");
			TXT_TGL_ADDENDUM_DAY.Text				= tools.FormatDate_Day(conn.GetFieldValue("ADM_PK_DATE").ToString());
			DDL_TGL_ADDENDUM_MONTH.SelectedValue	= tools.FormatDate_Month(conn.GetFieldValue("ADM_PK_DATE").ToString());
			TXT_TGL_ADDENDUM_YEAR.Text				= tools.FormatDate_Year(conn.GetFieldValue("ADM_PK_DATE").ToString());
		}

		private void FillDataGrid()
		{
			conn.QueryString = "SELECT * FROM VW_SDC_PERJANJIAN_PASAL WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			BindData(DATA_GRID.ID.ToString(), conn.QueryString);
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				string url = "";
				conn.QueryString = "SELECT EXPORT_URL FROM RFEXPORT WHERE EXPORT_ID = 'SYNDICATION01'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0) 
				{
					url = conn.GetFieldValue("EXPORT_URL");
					//url = /SME/JiwaServiceUpload/
				}

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
					HyperLink HpDownload	= (HyperLink) dg.Items[i].Cells[7].FindControl("SCR_DOWNLOAD");
					LinkButton HpDelete		= (LinkButton) dg.Items[i].Cells[7].FindControl("SCR_DELETE");

					conn.QueryString		= "SELECT * FROM VW_SDC_PERJANJIAN_PASAL WHERE SEQ = '" + dg.Items[i].Cells[0].Text.Trim() + "' AND CU_REF = '" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();

					if(conn.GetFieldValue("FILE_UPLOAD_EXP_NAME") == "" || conn.GetFieldValue("FILE_UPLOAD_EXP_NAME") == null)
					{
						HpDownload.Visible	= false;
						HpDelete.Visible	= false;
					}
					else
					{
						HpDownload.NavigateUrl	= url + conn.GetFieldValue("FILE_UPLOAD_EXP_NAME");
					}					
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
			this.DATA_GRID.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_GRID_ItemCommand);
			this.DATA_GRID.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_GRID_PageIndexChanged);
			this.DATA_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_ItemCommand);

		}
		#endregion

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../CustomerList.aspx?mc=" + Request.QueryString["mc"]);
		}

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			conn.QueryString = "EXEC SDC_INSERT_FILE_EXP '" + 
								LBL_SEQ.Text + "','" +
								Session["UserID"].ToString() + "','" +
								Request.QueryString["curef"] + "','" +
								Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_EXP) AS MAX_ID FROM SDC_FILE_UPLOAD_EXP WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			string sdfsd = conn.GetFieldValue("MAX_ID");

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_EXP_NAME FROM SDC_FILE_UPLOAD_EXP WHERE ID_UPLOAD_EXP = '" + max_id + "' AND CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_EXP_NAME");
				TXT_XLSNAME.Text = outputfilename;
			}

			conn.QueryString = "SELECT EXPORT_URL FROM RFEXPORT WHERE EXPORT_ID = 'SYNDICATION01'";
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
							FillDataGrid();
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
			FillDataGrid();
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC SDC_PERJANJIAN_PASAL_INSERT '" +
									LBL_SEQ.Text + "','" +
									Session["UserID"].ToString() + "','" +
									Request.QueryString["curef"] + "','" +
									Request.QueryString["cif"] + "','" +
									TXT_NO_PASAL.Text + "','" +
									TXT_JUDUL_PASAL.Text + "','" +
									TXT_ISI_PASAL.Text + "','" +
									TXT_KETERANGAN.Text + "'";
				conn.ExecuteQuery();

				ClearData2();
				FillDataGrid();
				CekCode();
			}

			catch(Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		protected void BTN_CLEAR2_Click(object sender, System.EventArgs e)
		{
			ClearData2();
			FillDataGrid();
			CekCode();
		}

		private void ClearData2()
		{
			TXT_NO_PASAL.Text			= "";
			TXT_JUDUL_PASAL.Text		= "";
			TXT_ISI_PASAL.Text			= "";
			TXT_KETERANGAN.Text			= "";
		}

		private void DATA_GRID_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_GRID.CurrentPageIndex = e.NewPageIndex;
			FillDataGrid();
		}

		private void DATA_GRID_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string directory = "";
			conn.QueryString = "SELECT EXPORT_URL FROM RFEXPORT WHERE EXPORT_ID = 'SYNDICATION01'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());
			}

			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "delete_file":
					conn.QueryString = "DELETE SDC_FILE_UPLOAD_EXP WHERE ID_UPLOAD_EXP = '" + e.Item.Cells[5].Text + "' AND FILE_UPLOAD_EXP_NAME = '" +
										e.Item.Cells[6].Text + "' AND CU_REF = '" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();

					deleteFile(directory, e.Item.Cells[6].Text);
					FillDataGrid();
					break;

				case "edit":
					conn.QueryString = "SELECT * FROM SDC_PERJANJIAN_PASAL WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();

					LBL_SEQ.Text				= conn.GetFieldValue("SEQ").ToString().Replace("&nbsp;","");
					TXT_NO_PASAL.Text			= conn.GetFieldValue("PASAL_NO").ToString().Replace("&nbsp;","");
					TXT_JUDUL_PASAL.Text		= conn.GetFieldValue("PASAL_TITLE").ToString().Replace("&nbsp;","");
					TXT_ISI_PASAL.Text			= conn.GetFieldValue("PASAL_ISI").ToString().Replace("&nbsp;","");
					TXT_KETERANGAN.Text			= conn.GetFieldValue("PASAL_REMARK").ToString().Replace("&nbsp;","");
					break;

				case "delete":
					conn.QueryString = "DELETE SDC_PERJANJIAN_PASAL WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();

					FillDataGrid();
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

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC SDC_PERJANJIAN_INSERT '" +
									LBL_SEQ1.Text + "','" +
									Session["UserID"].ToString() + "','" +
									Request.QueryString["curef"] + "','" +
									Request.QueryString["cif"] + "','" +
									TXT_NO_PK.Text + "'," +
									tools.ConvertDate(TXT_TGL_PK_DAY.Text, DDL_TGL_PK_MONTH.SelectedValue, TXT_TGL_PK_YEAR.Text) + ",'" +
									TXT_NO_ADDENDUM.Text + "'," +
									tools.ConvertDate(TXT_TGL_ADDENDUM_DAY.Text, DDL_TGL_ADDENDUM_MONTH.SelectedValue, TXT_TGL_ADDENDUM_YEAR.Text);
				conn.ExecuteQuery();

				conn.QueryString = "SELECT SEQ FROM SDC_PERJANJIAN WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();

				LBL_SEQ1.Text		= conn.GetFieldValue("SEQ").ToString();
			}

			catch(Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{
			TXT_NO_PK.Text							= "";
			TXT_TGL_PK_DAY.Text						= "";
			DDL_TGL_PK_MONTH.SelectedValue			= "";
			TXT_TGL_PK_YEAR.Text					= "";
			TXT_NO_ADDENDUM.Text					= "";
			TXT_TGL_ADDENDUM_DAY.Text				= "";
			DDL_TGL_ADDENDUM_MONTH.SelectedValue	= "";
			TXT_TGL_ADDENDUM_YEAR.Text				= "";
		}

		protected void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('PerjanjianPasalPrint.aspx?mc=" + Request.QueryString["mc"] + "&curef=" + Request.QueryString["curef"] + "','PrintRequest');</script>");
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

		private string CreateWord(string templateid)
		{
			string	templatefilename = "", outputfilename = "", templatepath = "", outputpath = "";
			string	returnmsg = string.Empty;
			string	curr_date = "";
			int		writeitem = 0;
			bool	savestatus;

			//string fileIn = string.Empty;
			//string fileOut = string.Empty;
			object fileIn;
			object fileOut;
			System.Data.DataTable dt1;
			System.Data.DataTable dt2;
			System.Data.DataTable dt3;

			System.Threading.Thread.CurrentThread.CurrentCulture	= System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
			System.Threading.Thread.CurrentThread.CurrentUICulture	= new System.Globalization.CultureInfo("en-US");

			object oMissingObject		= System.Reflection.Missing.Value;
			Word.Application wordApp	= null;
			Word.Document wordDoc		= null;

			ArrayList orgId = new ArrayList();
			ArrayList newId = new ArrayList();

			wordApp			= new Word.ApplicationClass();
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
				templatefilename	= conn.GetFieldValue("TEMPLATE_FILENAME");
				outputfilename		= conn.GetFieldValue("UPLOAD_FILEFORMAT").Replace("#NAME$",Request.QueryString["curef"]).Replace("#REGNUM$","PASAL") + "-" + curr_date + ".DOC";
				templatepath		= Server.MapPath(conn.GetFieldValue("TEMPLATE_PATH").Trim());
				outputpath			= Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());

				try
				{
					//Collectiong Existing Word in Taskbar
					Process[] newProcess = Process.GetProcessesByName("WINWORD");
					foreach(Process thisProcess in newProcess)
						newId.Add(thisProcess);

					//Save process into database
					//SupportTools.saveProcessWord(wordApp, newId, orgId, conn);

					fileIn	= templatepath + templatefilename;
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
							string sheetid	= dt1.Rows[i][0].ToString().Trim();
							string sheetseq = dt1.Rows[i][1].ToString().Trim();
							string proc		= dt1.Rows[i][2].ToString().Trim();

							//Query Stored Procedure
							conn.QueryString = "EXEC " + proc + " '" + Request.QueryString["curef"] + "'";
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
									string xarr			= dt2.Rows[j][0].ToString().Trim(); //indicating "0"=array, "1"=single data
									object wbm			= dt2.Rows[j][1].ToString().Trim(); //bookmark di wordnya
									string dbfield		= dt2.Rows[j][2].ToString().Trim();
									string cell_value	= dt3.Rows[k][dbfield].ToString().Trim();

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
												Request.QueryString["curef"] + "', '" + 
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

			conn.QueryString = "SELECT * FROM VW_DOCEXPORT_VIEWFILEEXPORT WHERE TEMPLATE_GROUP = 'SDCPRINTPASAL' AND AP_REGNO = '" + Request.QueryString["curef"] + "'";
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

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					try 
					{					
						conn.QueryString = "SELECT TOP 1 UPLOAD_PATH FROM VW_DOCEXPORT_PARAMETER WHERE TEMPLATE_GROUP = 'SDCPRINTPASAL'";
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
	}
}
