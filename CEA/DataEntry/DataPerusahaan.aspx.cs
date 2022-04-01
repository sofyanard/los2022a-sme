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
//using Excel;

namespace SME.CEA.DataEntry
{
	/// <summary>
	/// Summary description for DataPerusahaan.
	/// </summary>
	public partial class DataPerusahaan : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		protected ArrayList array = new ArrayList();
		protected string xlsname;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/../SME/Restricted.aspx");

			ViewMenu();
			

			if(!IsPostBack)
			{
				DDL_BLN_COMP.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLNEXP_KTP.Items.Add(new ListItem("--Pilih--",""));

				for(int i=1; i<=12; i++)
				{
					DDL_BLN_COMP.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLNEXP_KTP.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
				BTN_UPDATE.Visible = false;
				BTN_ADD.Visible = true;

				ViewUploadFiles();
				viewGridExcel();

				TXT_NILAI_SAHAM.Text = tool.MoneyFormat(TXT_NILAI_SAHAM.Text);
				TXT_PERSEN_SAHAM.Text = tool.MoneyFormat(TXT_PERSEN_SAHAM.Text);
			}
			ViewData();
			CekView();
			
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT SEQ, REKANAN_REF, NAMA, BOD_ISTABLISH, KTP#, KTP_END, SHARE, SHARE_VAL, KEY_PERSON, NPWP, JABATAN, SERTIFIKASI FROM REKANAN_PENGURUS WHERE REKANAN_REF='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();
			FillGrid();
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGridDataPerusahaan.DataSource = dt;
			try 
			{
				DatGridDataPerusahaan.DataBind();
			} 
			catch 
			{
				DatGridDataPerusahaan.CurrentPageIndex = 0;
				DatGridDataPerusahaan.DataBind();
			}
			for (int i = 0; i < DatGridDataPerusahaan.Items.Count; i++)
			{
				DatGridDataPerusahaan.Items[i].Cells[3].Text = tool.FormatDate(DatGridDataPerusahaan.Items[i].Cells[3].Text, true);
			}
			for (int i = 0; i < DatGridDataPerusahaan.Items.Count; i++)
			{
				DatGridDataPerusahaan.Items[i].Cells[5].Text = tool.MoneyFormat(DatGridDataPerusahaan.Items[i].Cells[5].Text);
				DatGridDataPerusahaan.Items[i].Cells[4].Text = tool.MoneyFormat(DatGridDataPerusahaan.Items[i].Cells[4].Text);
			}
		}

		protected void BTN_ADD_Click(object sender, EventArgs e)
		{
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), CompDate, KTPExp;
			
			//--VALIDASI TANGGAL BERDIRI PERUSAHAAN--//
			/*if (int.Parse(DDL_BLN_COMP.SelectedValue) > 12 )
			{
				GlobalTools.popMessage(this, "Tanggal berdiri perusahaan (MM) tidak valid");
				return;
			}*/
			/*try 
			{
				CompDate = Int64.Parse(Tools.toISODate(TXT_TGL_COMP.Text, DDL_BLN_COMP.SelectedValue, TXT_THN_COMP.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal berdiri perusahaan tidak valid!");
				return;
			}
			if (CompDate > now)
			{
				GlobalTools.popMessage(this, "Tanggal berdiri perusahaan tidak boleh lebih dari tanggal sekarang!");
				return;
			}
			////////////////////////////////////////////////////////////////////
			///	VALIDASI TANGGAL BERAKHIR KTP
			///	
			try 
			{
				CompDate = Int64.Parse(Tools.toISODate(TXT_TGLEXP_KTP.Text, DDL_BLNEXP_KTP.SelectedValue, TXT_THNEXP_KTP.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal berdiri perusahaan tidak valid!");
				return;
			}
			if (CompDate <= now)
			{
				GlobalTools.popMessage(this, "Tanggal berakhir KTP tidak boleh kurang dari atau sama dengan tanggal sekarang!");
				return;
			}	*/
			
			
			
			/*conn.QueryString = "exec REKANAN_DATA_PERUSAHAAN_INSERT '" +
				TXT_NAMA.Text + "', " + 
				tool.ConvertDate(TXT_TGL_COMP.Text, DDL_BLN_COMP.SelectedValue, TXT_THN_COMP.Text) + ", '" +
				TXT_NO_KTP.Text + "', " +
				tool.ConvertDate(TXT_TGLEXP_KTP.Text, DDL_BLNEXP_KTP.SelectedValue, TXT_THNEXP_KTP.Text) + ", " +
				tool.ConvertFloat(TXT_PERSEN_SAHAM.Text) + ", " +
				tool.ConvertFloat(TXT_NILAI_SAHAM.Text) + ", '" +
				RDO_KEY_PERSON_COMP.SelectedValue + "', '" +
				TXT_NPWP_COMP.Text + "'";
			conn.ExecuteNonQuery();*/

			try
			{
				conn.QueryString = "exec REKANAN_DATA_PERUSAHAAN_INSERT '" +
					Request.QueryString["rekanan_ref"] + "', '" +
					TXT_NAMA.Text + "', " + 
					tool.ConvertDate(TXT_TGL_COMP.Text, DDL_BLN_COMP.SelectedValue, TXT_THN_COMP.Text) + ", '" +
					TXT_NO_KTP.Text + "', " +
					tool.ConvertDate(TXT_TGLEXP_KTP.Text, DDL_BLNEXP_KTP.SelectedValue, TXT_THNEXP_KTP.Text) + ", " +
					tool.ConvertFloat(TXT_PERSEN_SAHAM.Text) + ", " +
					tool.ConvertFloat(TXT_NILAI_SAHAM.Text) + ", '" +
					RDO_KEY_PERSON_COMP.SelectedValue + "', '" +
					TXT_NPWP_COMP.Text + "', '" +
					TXT_JABATAN.Text + "', '" +
					TXT_SERTIFIKASI.Text + "'";
				conn.ExecuteNonQuery();
			}
			catch
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../../Login.aspx?expire=1");
			}
			ClearData();
			ViewData();
		}

		private void ClearData()
		{
			TXT_NAMA.Text="";
			TXT_TGL_COMP.Text="";
			DDL_BLN_COMP.SelectedValue="";
			TXT_THN_COMP.Text="";
			TXT_TGLEXP_KTP.Text="";
			DDL_BLNEXP_KTP.SelectedValue="";
			TXT_THNEXP_KTP.Text="";
			TXT_PERSEN_SAHAM.Text="0,00";
			TXT_NILAI_SAHAM.Text="0,00";
			RDO_KEY_PERSON_COMP.SelectedValue="Y";
			TXT_NPWP_COMP.Text="";
			TXT_NO_KTP.Text="";
			TXT_JABATAN.Text="";
			TXT_SERTIFIKASI.Text="";
		}

		private void DatGridDataPerusahaan_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete_data":
					conn.QueryString = "delete from rekanan_pengurus where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "' and SEQ=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();
					ViewData();
					break;
				case "edit_data":
					conn.QueryString = "select * from rekanan_pengurus where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "' and SEQ=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();

					TXT_SEQ.Text = conn.GetFieldValue("SEQ");
					TXT_NAMA.Text = conn.GetFieldValue("NAMA");
					TXT_TGL_COMP.Text = tool.FormatDate_Day(conn.GetFieldValue("BOD_ISTABLISH"));
					DDL_BLN_COMP.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("BOD_ISTABLISH"));
					TXT_THN_COMP.Text = tool.FormatDate_Year(conn.GetFieldValue("BOD_ISTABLISH"));
					TXT_NO_KTP.Text = conn.GetFieldValue("KTP#");
					TXT_TGLEXP_KTP.Text = tool.FormatDate_Day(conn.GetFieldValue("KTP_END"));
					DDL_BLNEXP_KTP.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("KTP_END"));
					TXT_THNEXP_KTP.Text = tool.FormatDate_Year(conn.GetFieldValue("KTP_END"));
					TXT_PERSEN_SAHAM.Text = conn.GetFieldValue("SHARE");
					TXT_NILAI_SAHAM.Text = conn.GetFieldValue("SHARE_VAL");
					RDO_KEY_PERSON_COMP.SelectedValue = conn.GetFieldValue("KEY_PERSON");
					TXT_NPWP_COMP.Text = conn.GetFieldValue("NPWP");
					TXT_JABATAN.Text = conn.GetFieldValue("JABATAN");
					TXT_SERTIFIKASI.Text = conn.GetFieldValue("SERTIFIKASI");
					TXT_NILAI_SAHAM.Text = tool.MoneyFormat(TXT_NILAI_SAHAM.Text);
					TXT_PERSEN_SAHAM.Text = tool.MoneyFormat(TXT_PERSEN_SAHAM.Text);
					ViewData();
					BTN_UPDATE.Visible = true;
					BTN_ADD.Visible = false;
					break;
			}
		}

		protected void BTN_UPDATE_Click(object sender, EventArgs e)
		{
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), CompDate, KTPExp;
			
			//--VALIDASI TANGGAL BERDIRI PERUSAHAAN--//
			/*if (int.Parse(DDL_BLN_COMP.SelectedValue) > 12 )
			{
				GlobalTools.popMessage(this, "Tanggal berdiri perusahaan (MM) tidak valid");
				return;
			}*/
			/*try 
			{
				CompDate = Int64.Parse(Tools.toISODate(TXT_TGL_COMP.Text, DDL_BLN_COMP.SelectedValue, TXT_THN_COMP.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal berdiri perusahaan tidak valid!");
				return;
			}
			if (CompDate > now)
			{				GlobalTools.popMessage(this, "Tanggal berdiri perusahaan tidak boleh lebih dari tanggal sekarang!");
				return;
			}
			////////////////////////////////////////////////////////////////////
			///	VALIDASI TANGGAL BERAKHIR KTP
			///	
			try 
			{
				CompDate = Int64.Parse(Tools.toISODate(TXT_TGLEXP_KTP.Text, DDL_BLNEXP_KTP.SelectedValue, TXT_THNEXP_KTP.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal berdiri perusahaan tidak valid!");
				return;
			}
			if (CompDate <= now)
			{
					GlobalTools.popMessage(this, "Tanggal berakhir KTP tidak boleh kurang dari atau sama dengan tanggal sekarang!");
				return;
			}	*/

			try
			{
				conn.QueryString = "exec REKANAN_DATA_PERUSAHAAN_UPDATE " +
					Convert.ToInt32(TXT_SEQ.Text) + ", '" +
					Request.QueryString["rekanan_ref"] + "', '" +
					TXT_NAMA.Text + "', " +
					tool.ConvertDate(TXT_TGL_COMP.Text, DDL_BLN_COMP.SelectedValue, TXT_THN_COMP.Text) + ", '" +
					TXT_NO_KTP.Text + "', " +
					tool.ConvertDate(TXT_TGLEXP_KTP.Text, DDL_BLNEXP_KTP.SelectedValue, TXT_THNEXP_KTP.Text) + ", " +
					tool.ConvertFloat(TXT_PERSEN_SAHAM.Text) + ", " +
					tool.ConvertFloat(TXT_NILAI_SAHAM.Text) + ", '" +
					RDO_KEY_PERSON_COMP.SelectedValue + "', '" +
					TXT_NPWP_COMP.Text + "', '" +
					TXT_JABATAN.Text + "', '" +
					TXT_SERTIFIKASI.Text + "'";
				conn.ExecuteNonQuery();
			}
			catch
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../../Login.aspx?expire=1");
			}
			ClearData();
			ViewData();
			BTN_UPDATE.Visible=false;
			BTN_ADD.Visible=true;
		}
		
		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '" + Request.QueryString["mc"] + "'";
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
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"]+ "&exist=" + Request.QueryString["exist"]+ "&view=" + Request.QueryString["view"];
						else	
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+ "&exist=" + Request.QueryString["exist"]+ "&view=" + Request.QueryString["view"];
						//t.ForeColor = Color.MidnightBlue; 
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"] + "&mc2=" + Request.QueryString["mc2"];
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					MenuDataPerusahaan.Controls.Add(t);
					MenuDataPerusahaan.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
					

					
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
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
			this.DatGridDataPerusahaan.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGridDataPerusahaan_ItemCommand);
			this.DatGridDataPerusahaan.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGridDataPerusahaan_PageIndexChanged);
			this.DATA_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_ItemCommand);
			this.DATA_EXPORT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_EXPORT_PageIndexChanged);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);

		}
		#endregion

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			conn.QueryString = "EXEC REKANAN_INSERT_FILE_EXP '" + 
				Request.QueryString["rekanan_ref"] + "', '" +
				Session["USERID"].ToString() + "', '" +
				Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_EXP) as MAX_ID from [REKANAN_FILE_UPLOAD_EXP] where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_EXP_NAME from [REKANAN_FILE_UPLOAD_EXP] where ID_UPLOAD_EXP = '" + max_id + "' and rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_EXP_NAME");
				TXT_XLSNAME.Text = outputfilename;
			}

			conn.QueryString = "SELECT EXPORT_URL FROM REKANAN_RFEXPORT WHERE EXPORT_ID = 'REKANAN01'";
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
				try
				{
					ReadExcel(directory + outputfilename);
				}
				catch {}
			}
			ViewUploadFiles();
		}

		private void ViewUploadFiles()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM REKANAN_RFEXPORT WHERE EXPORT_ID = 'REKANAN01'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD_EXP, FILE_UPLOAD_EXP_NAME FROM REKANAN_FILE_UPLOAD_EXP where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
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
				HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("EXPERIENCE_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[3].FindControl("EXPERIENCE_DELETE");
				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_EXP_NAME");
			}
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string directory = "";
			conn.QueryString = "SELECT EXPORT_URL FROM REKANAN_RFEXPORT WHERE EXPORT_ID = 'REKANAN01'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());
			}

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "EXEC REKANAN_DELETE_FILE_UPLOAD '" + e.Item.Cells[0].Text + "', '" +
						Request.QueryString["rekanan_ref"] + "', '" +
						e.Item.Cells[1].Text + "'";
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
				/*Excel.Worksheet ws = excelApp.ActiveSheet as Excel.Worksheet;
				int rcount = ws.UsedRange.Rows.Count;
				int colcount = ws.UsedRange.Cells.Count;*/
				

				//--- Delete data sebelumnya--//
				//conn.QueryString = "delete rekanan_pengalaman where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
				//conn.ExecuteQuery();

				//Loop for Template Master
				conn.QueryString = "SELECT SHEET_ID, SHEET_SEQ, STOREDPROCEDURE FROM REKANAN_TEMPLATE_MASTER";
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
						conn.QueryString = "SELECT CELL_COL, DB_FIELD FROM REKANAN_TEMPLATE_DETAIL ORDER BY ID_PENGALAMAN_TEMPLATE";
						conn.ExecuteQuery();
						dt2 = conn.GetDataTable().Copy();
						int n = dt2.Rows.Count;
						object[] par;
						par = new object[n];
						object[] dttype;
						dttype = new object[n];


						if (dt2.Rows.Count > 0)
						{
							int row = 3;
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
											cell_value = excelCell.Value2.ToString();
											par[j] = (string)cell_value;
											dttype[j] = (string)datatype;
										}
									}
									catch
									{
										flag = true;
										/*dttype[j] = (string)datatype;
										if (dttype[j].ToString() == "V")
											par[j] = "";
										else if (dttype[j].ToString() == "F")
											par[j] = 0;*/
									}
								}
							
								//Construct Query
								if(flag == false)
								{
									string query = "EXEC " + proc + " '" + Request.QueryString["rekanan_ref"] + "', '" +
										TXT_XLSNAME.Text + "', ";
									for (int k = 0; k < n; k++)
									{
										if (dttype[k].ToString() == "V")
											query = query + "'" + par[k].ToString() + "'";
										else if (dttype[k].ToString() == "F")
											query = query + "" + par[k].ToString() + "";

										if (k < n-1)
											query = query + ", ";
									}

									

									conn.QueryString = query;
									conn.ExecuteQuery();

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
			catch
			{
				LBL_STATUS.ForeColor = Color.Green;
				LBL_STATUSREPORT.ForeColor = Color.Red;
				LBL_STATUS.Text = "Upload Sucessful!";
				LBL_STATUSREPORT.Text = "Gagal memasukkan data! Silahkan periksa kembali format datanya !";
				//LBL_STATUSREPORT.Text = ex.Message + "\n" + ex.StackTrace;
				
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

				
				FillGridExp();
			}
			
		}

		private void viewGridExcel()
		{
			string url = "";
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_TEMPLATE_REKANAN, NAMA_TEMPLATE_REKANAN, LINK_TEMPLATE_REKANAN FROM REKANAN_TEMPLATE";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("LINK_TEMPLATE_REKANAN");
			}

			dt = conn.GetDataTable().Copy();
			DATA_TEMPLATE.DataSource = dt;
			try 
			{
				DATA_TEMPLATE.DataBind();
			} 
			catch 
			{
				DATA_TEMPLATE.CurrentPageIndex = 0;
				DATA_TEMPLATE.DataBind();
			}
			for (int i = 1; i <= DATA_TEMPLATE.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DATA_TEMPLATE.Items[i-1].Cells[2].FindControl("HP_DOWNLOAD");
				HpDownload.NavigateUrl = url;
			}
		}	

		private void FillGridExp()
		{
			conn.QueryString = "select * from rekanan_pengalaman where rekanan_ref='" + Request.QueryString ["rekanan_ref"] + "' and doc_name='" + TXT_XLSNAME.Text + "'";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
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

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			FillGridExp();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["par"] != null && Request.QueryString["par"] != "") 
			{
				Response.Redirect(Request.QueryString["par"] + "&mc=" + Request.QueryString["mc2"] + "&regnum=" + Request.QueryString["regnum"] + "&rekanan_ref=" + Request.QueryString["rekanan_ref"] + "&tc=" + Request.QueryString["tc"]+ "&view=" + Request.QueryString["view"]);
			}
			else
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}

		private void DATA_EXPORT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_EXPORT.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFiles();
		}

		private void DatGridDataPerusahaan_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGridDataPerusahaan.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}

		protected void TXT_PERSEN_SAHAM_TextChanged(object sender, System.EventArgs e)
		{			
			TXT_PERSEN_SAHAM.Text = tool.MoneyFormat(TXT_PERSEN_SAHAM.Text);
			string str = TXT_PERSEN_SAHAM.Text;
			float nilai = float.Parse(str);
			
			if (nilai > 100)
			{
				TXT_PERSEN_SAHAM.Text="0,00";
				
				GlobalTools.popMessage(this, "Nilai saham tidak boleh lebih dari 100%!");
				return;
				
			}			
		}

		protected void TXT_NILAI_SAHAM_TextChanged(object sender, System.EventArgs e)
		{
			TXT_NILAI_SAHAM.Text = tool.MoneyFormat(TXT_NILAI_SAHAM.Text);
		}

		private void CekView()
		{
			if(Request.QueryString["view"]=="1")
			{
				DatGridDataPerusahaan.Columns[7].Visible = false;
				TXT_NAMA.ReadOnly = true;
				TXT_TGL_COMP.ReadOnly = true;
				DDL_BLN_COMP.Enabled = false;
				TXT_NO_KTP.ReadOnly = true;
				TXT_TGLEXP_KTP.ReadOnly = true;
				DDL_BLNEXP_KTP.Enabled = false;
				TXT_THNEXP_KTP.ReadOnly = true;
				TXT_PERSEN_SAHAM.ReadOnly = true;
				TXT_NILAI_SAHAM.ReadOnly = true;
				RDO_KEY_PERSON_COMP.Enabled = false;
				TXT_NPWP_COMP.ReadOnly = true;
				BTN_ADD.Enabled = false;
				TXT_THN_COMP.ReadOnly = true;
				//TXT_SEQ.ReadOnly = true;
				BTN_UPDATE.Enabled = false;
				TXT_JABATAN.ReadOnly = true;
				TXT_SERTIFIKASI.ReadOnly = true;
				DATA_EXPORT.Columns[3].Visible = false;
				//LBL_STATUS.ReadOnly = true;
				LBL_STATUSREPORT.Visible = false;
				BTN_UPLOAD.Enabled = false;
			}
		}
	}
}
