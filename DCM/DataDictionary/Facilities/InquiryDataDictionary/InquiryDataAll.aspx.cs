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
using System.Diagnostics;
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;
using System.Configuration;

namespace SME.DCM.DataDictionary.Facilities.InquiryDataDictionary
{
	/// <summary>
	/// Summary description for DataCIFIn.
	/// </summary>
	public partial class InquiryDataAll : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;

		private string totest = "";
		private string jenisdata = "";
		private string user = "";
		private string regno = "TESTING";
		private bool []checkedbox;
		private string []columnarray;
		private string []titlecolumn;
		
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			TR_MENU.Visible = true;
			if(!IsPostBack)
			{
				#region Interim Inisiasi Drop Down List
				ListItem a = new ListItem("CIF", "1");
				ListItem b = new ListItem("Dana Pihak Ketiga", "2");
				ListItem c = new ListItem("Perkreditan", "3");
				ListItem h = new ListItem("Collateral", "4");
				ListItem d = new ListItem("Trade", "5");
				ListItem g = new ListItem("Treasury", "6");	

				DropDownList1.Items.Add(a);
				DropDownList1.Items.Add(b);
				DropDownList1.Items.Add(c);
				DropDownList1.Items.Add(h);
				DropDownList1.Items.Add(d);
				DropDownList1.Items.Add(g);

				DDL_FORMAT_TYPE.Items.Add(new ListItem("inquirydataall","inquirydataall"));
				#endregion
			}

			jenisdata = DropDownList1.SelectedValue;

			if(!IsPostBack)
			{
				Session.Add("prev","");
			}

			if(Session["prev"].ToString() != jenisdata)
			{
				//set all label (dynamic)
				conn.QueryString = "SELECT * FROM VW_DCM_DATADICIONARY_FACILITIES_INQUIRYDATADICTIONARY_INQUIRYDATAALL1 WHERE THEID = '" + jenisdata + "'";
				conn.ExecuteQuery();
				LBL_PAGE.Text = conn.GetFieldValue("PAGE_NAME");
				LBL_PAGE_2ND.Text = conn.GetFieldValue("ROWANDFIELDSNAME");
				LBL_DOCUMENT.Text = conn.GetFieldValue("DATADICTIONARYDOCUMENTEXPORT");

				//set the grid (dynamic)
				conn.QueryString = "SELECT * FROM VW_DCM_DATADICIONARY_FACILITIES_INQUIRYDATADICTIONARY_INQUIRYDATAALL2 WHERE THEID = '" + jenisdata + "'";
				BindData(DGR_INQUIRY.ID.ToString(), conn.QueryString);
				conn.ExecuteQuery();

				checkedbox = new bool[conn.GetRowCount()];
				columnarray = new String[conn.GetRowCount()];
				titlecolumn = new String[conn.GetRowCount()];
				
				//add to session
				Session.Add("checkedbox", checkedbox);
				Session.Add("columnarray", columnarray);
				Session.Add("titlecolumn", titlecolumn);

				Session["prev"] = jenisdata;
			}

			//bind the uploaded file
			ViewMenu();
			ViewExportFiles();
			SettingCheckBox();
		}

		private void SettingCheckBox()
		{
			for(int i=0; i< DGR_INQUIRY.Items.Count; i++)
			{
				CheckBox cb = (CheckBox)DGR_INQUIRY.Items[i].Cells[3].FindControl("edit_cab");
				cb.CheckedChanged += new EventHandler(cb_CheckedChanged);
			}
		}

		private void insertArray()
		{
			bool []checkedbox2 = (bool [])Session["checkedbox"];
			string []columnarray2 = (string [])Session["columnarray"];
			string []titlecolumn2 = (string [])Session["titlecolumn"]; 

			for(int i=0; i< DGR_INQUIRY.Items.Count; i++)
			{
				//dgListChan.Items[i].Cells[0].Text.ToString()
				CheckBox cb = (CheckBox)DGR_INQUIRY.Items[i].Cells[3].FindControl("edit_cab");
				if(cb.Checked)
				{
					//ambilnumbernya
					//checkedbox[int.Parse(DGR_INQUIRY.Items[i].Cells[0].Text.ToString())] = true;
					int a = int.Parse(DGR_INQUIRY.Items[i].Cells[0].Text.ToString());
					try
					{
						checkedbox2[a-1] = true;
						columnarray2[a-1] = DGR_INQUIRY.Items[i].Cells[1].Text.ToString();
						titlecolumn2[a-1] = DGR_INQUIRY.Items[i].Cells[2].Text.ToString();
					}
					catch(Exception M)
					{
						string b = M.Message.ToString();
						string c = M.Message.ToString();
					}
				}
				else
				{
					//checkedbox[int.Parse(DGR_INQUIRY.Items[i].Cells[0].Text.ToString())] = false;
					int a = int.Parse(DGR_INQUIRY.Items[i].Cells[0].Text.ToString());
					try
					{
						checkedbox2[a-1] = false;
						columnarray2[a-1] = "NONE";
						titlecolumn2[a-1] = "NONE";
					}
					catch(Exception M)
					{
						string b = M.Message.ToString();
						string c = M.Message.ToString();
					}
				}
			}
			Session["checkedbox"] = checkedbox2;
			Session["columnarray"] = columnarray2;
			Session["titlecolumn"] = titlecolumn2;

			cekAllArray();
		}

		private void cekAllArray()
		{
			bool []checkedbox2 = (bool [])Session["checkedbox"];
			string []columnarray2 = (string [])Session["columnarray"];
			string []titlecolumn2 = (string [])Session["titlecolumn"]; 

			for(int n=0; n<titlecolumn2.Length; n++)
			{
				string asasassd = titlecolumn2[n].ToString();
				string asasassk = titlecolumn2[n].ToString();
			}

			for(int n=0; n<columnarray2.Length; n++)
			{
				string asasassd = columnarray2[n].ToString();
				string asasassk = columnarray2[n].ToString();
			}

			for(int n=0; n<checkedbox2.Length; n++)
			{
				string asasassd = checkedbox2[n].ToString();
				string asasassk = checkedbox2[n].ToString();
			}

			Session["checkedbox"] = checkedbox2;
			Session["columnarray"] = columnarray2;
			Session["titlecolumn"] = titlecolumn2;
		}

		private void retrieveArray()
		{
			bool []checkedbox2 = (bool [])Session["checkedbox"];
			for(int i=0; i< DGR_INQUIRY.Items.Count; i++)
			{
				int a = int.Parse(DGR_INQUIRY.Items[i].Cells[0].Text.ToString());
				CheckBox cb = (CheckBox)DGR_INQUIRY.Items[i].Cells[3].FindControl("edit_cab");

				cb.Checked = checkedbox2[a-1];
			}

			Session["checkedbox"] = checkedbox2;
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
			this.DGR_INQUIRY.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_INQUIRY_PageIndexChanged);

		}
		#endregion

		protected void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			totest = "OK";
			//Session["prev"] = jenisdata;
			user = "telo";
			
			//Response.Redirect("InquiryDataAll.aspx?totest=" + totest + "&jenisdata=" + jenisdata + "&user=" + user);
		}

		protected void BTN_EXPORT_Click(object sender, System.EventArgs e)
		{
			CreateExcel2("inquirydataall");
		}

		private string GenerateColumn(int theNumber)
		{
			string theColumn = "";

			string theColumnA = "";
			string theColumnB = "";

			//apply the C ANSI
			if(theNumber + 65 <= 90)
			{
				theColumn = System.Convert.ToChar(theNumber + 65).ToString();
			}
			else
			{
				// dilooping disini
				int colA = theNumber / 26;
				colA = colA - 1;
				theColumnA = System.Convert.ToChar(colA + 65).ToString();

				int colB = theNumber % 26;
				theColumnB = System.Convert.ToChar(colB + 65).ToString();

				theColumn = theColumnA + theColumnB;
			}

			return theColumn;
		}

		private string CreateExcel2(string templateid)
		{
			string templatefilename = "", 
				outputfilename = "", 
				templatepath = "", 
				outputpath = "";
			string []columnarray2;
			string []titlecolumn2;
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
			conn.QueryString = "SELECT TOP 1 * FROM VW_DCM_DATADICIONARY_FACILITIES_INQUIRYDATADICTIONARY_INQUIRY_DATA_ALL_MASTER_1 WHERE TEMPLATE_ID = '" + templateid + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				templatefilename = conn.GetFieldValue("TEMPLATE_FILENAME");
				outputfilename = conn.GetFieldValue("UPLOAD_FILEFORMAT").Replace("#REGNO$",regno).Replace("#USERID$","TesTesTes") + ".XLS";
				//outputfilename = conn.GetFieldValue("UPLOAD_FILEFORMAT").Replace("#REGNO$",regno).Replace("#USERID$",Session["UserID"].ToString()) + ".XLS";
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
					SupportTools.saveProcessExcel(excelApp, newId, orgId, conn2);

					fileIn = templatepath + templatefilename;
					excelWorkBook = excelApp.Workbooks.Open(fileIn, 0, false, 5, string.Empty, string.Empty, true, Excel.XlPlatform.xlWindows, "\t|",
						false, false, 0, true);

					excelSheet = excelWorkBook.Worksheets;

					//Loop for Template Master
					conn.QueryString = "SELECT SHEET_ID, SHEET_SEQ, STOREDPROCEDURE FROM VW_DCM_DATADICIONARY_FACILITIES_INQUIRYDATADICTIONARY_INQUIRY_DATA_ALL_MASTER_2 WHERE TEMPLATE_ID = '" + templateid + "'";
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
							//anggapannya dalam sekali query ini uda ada semua kolomnya
							int counter = 0;
							conn.QueryString = "EXEC " + proc + " '" + regno + "','" + jenisdata + "'";
							conn.ExecuteQuery();
							dt3 = conn.GetDataTable().Copy();
							if (dt3.Rows.Count > 0)
							{
								//Loop for Template Detail
								columnarray2 = (string [])Session["columnarray"];
								titlecolumn2 = (string [])Session["titlecolumn"]; 
								for (int k = 0; k < dt3.Rows.Count; k++)
								{
									counter = 0;
									for (int j = 0; j < columnarray2.Length; j++)
									{
										//get the column and the column name
										string dbfield = columnarray2[j].ToString();
										/************************WRITE THE CONTENT****************************/
										if(dbfield != "NONE")
										{
											string xcol = GenerateColumn(counter);
											//**************************WRITE THE TITLE**************************/
											if(true)
											{
												string xcell2 = xcol + 1;
												string title = titlecolumn2[j].ToString();

												Excel.Range excelCell2 = (Excel.Range)excelWorkSheet.get_Range(xcell2, xcell2);
												if (excelCell2 != null)
												{
													excelCell2.Value2 = title;
													writeitem++;
												}
											}
											//********************************************************************/
											int irow;
											try {irow = k + 2;}
											catch {irow = 1;}
											string xrow = irow.ToString().Trim();
											string cell_value = dt3.Rows[k][dbfield].ToString().Trim();
											string xcell = xcol + xrow;

											Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(xcell, xcell);
											if (excelCell != null)
											{
												excelCell.Value2 = cell_value;
												writeitem++;
											}
											counter++;
										}
									}
								}
							}
							else
							{

							}
						}

						
						fileOut = outputpath + outputfilename;
						excelWorkBook.SaveAs(fileOut, Excel.XlFileFormat.xlWorkbookNormal, null, null, null, null,
							Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, true);
						savestatus = true;

						if (savestatus == true)
						{
							//Save to Table
							if(conn2 != null)
							{ 
								try
								{
									conn2.QueryString = "EXEC DOCEXPORT_SAVE '1', '" + 
										templateid + "', '" + 
										regno + "', '" + 
										jenisdata.ToString().Trim() + "', '" + 
										outputfilename + "'"; 

									conn2.ExecuteQuery();
								}
								catch(Exception o)
								{
									string msg = o.Message.ToString();
									string abc = "";
								}
							}

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
			string templateid = "inquirydataall";
			System.Data.DataTable dt = new System.Data.DataTable();
			conn2.QueryString = "SELECT * FROM VW_DOCEXPORT_VIEWFILEEXPORT WHERE TEMPLATE_GROUP = '" + templateid + 
				"' AND FE_USERID = '" + jenisdata.ToString().Trim() + "'";
			conn2.ExecuteQuery();
			dt = conn2.GetDataTable().Copy();
			DATA_EXPORT.DataSource = dt;
			try 
			{
				DATA_EXPORT.DataBind();
			} 
			catch (Exception o)
			{
				string abc = o.Message.ToString();
				string def = o.Message.ToString();

				DATA_EXPORT.CurrentPageIndex = 0;
				DATA_EXPORT.DataBind();
			}
			for (int i = 1; i <= DATA_EXPORT.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[1].FindControl("FE_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[2].FindControl("LinkButton1");
				HpDownload.NavigateUrl = DATA_EXPORT.Items[i-1].Cells[3].Text.Trim();
				/*if (Session["UserID"].ToString().Trim() != DATA_EXPORT.Items[i-1].Cells[2].Text)
					HpDelete.Visible	= false;*/
				HpDelete.Visible = false;
			}
		}

		private void DGR_INQUIRY_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_INQUIRY.CurrentPageIndex = e.NewPageIndex;
			conn.QueryString = "SELECT * FROM VW_DCM_DATADICIONARY_FACILITIES_INQUIRYDATADICTIONARY_INQUIRYDATAALL2 WHERE THEID = '" + jenisdata + "'";
			BindData(DGR_INQUIRY.ID.ToString(), conn.QueryString);
			retrieveArray();
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

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

		private void cb_CheckedChanged(object sender, EventArgs e)
		{
			insertArray();
		}

		private void ViewMenu()
		{
			try 
			{
				//conn.QueryString = "select SM_ID,MENUCODE,SM_MENUDISPLAY,SM_LINKNAME from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn2.QueryString = "select SM_ID,MENUCODE,SM_MENUDISPLAY,SM_LINKNAME from SCREENMENU where menucode = '003'";
				conn2.ExecuteQuery();
				for (int i = 0; i < conn2.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn2.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]+"&parentregno="+Request.QueryString["parentregno"]+"&aano="+Request.QueryString["aano"] + "&productid=" + Request.QueryString["productid"] + "&prodseq=" + Request.QueryString["prodseq"];
						else	
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]+"&parentregno="+Request.QueryString["parentregno"]+"&aano="+Request.QueryString["aano"] + "&productid=" + Request.QueryString["productid"] + "&prodseq=" + Request.QueryString["prodseq"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = "../" + conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}
	}
}
