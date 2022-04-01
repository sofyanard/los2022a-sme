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

namespace SME.LMS.PortfolioWatchlistChecking
{
	/// <summary>
	/// Summary description for UploadDataeMAS.
	/// </summary>
	public partial class UploadDataeMAS : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
		protected ArrayList array = new ArrayList();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				DDL_BLN_PERIODE.Items.Add(new ListItem("-- Pilih --", ""));

				for (int i=1; i<=12; i++)
				{
					DDL_BLN_PERIODE.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				//ViewDataPortfolio();
				conn.QueryString = "select top 0 * from porlms_emas_data";
				conn.ExecuteQuery();
				FillGridPortfolio();

				ViewPeriodeData();
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
			this.DATGRD_PERIODE.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATGRD_PERIODE_ItemCommand);
			this.DATGRD_PERIODE.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATGRD_PERIODE_PageIndexChanged);
			this.DATGRD_PORTFOLIO.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATGRD_PORTFOLIO_PageIndexChanged);
			this.DATA_UPLOAD.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_UPLOAD_ItemCommand);
			this.DATA_UPLOAD.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_UPLOAD_PageIndexChanged);

		}
		#endregion

		private void ViewDataPortfolio()
		{
			conn.QueryString = "select * from porlms_emas_data";
			conn.ExecuteQuery();

			FillGridPortfolio();
		}

		private void FillGridPortfolio()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DATGRD_PORTFOLIO.DataSource = dt;
			try 
			{
				DATGRD_PORTFOLIO.DataBind();
			} 
			catch 
			{
				DATGRD_PORTFOLIO.CurrentPageIndex = 0;
				DATGRD_PORTFOLIO.DataBind();
			}
		}

		private void ViewPeriodeData()
		{
			conn.QueryString = "select distinct convert (varchar, periode_data, 111) as periode_data from porlms_emas_data group by periode_data";
			conn.ExecuteQuery();

			FillGridPeriodeData();
		}

		private void FillGridPeriodeData()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DATGRD_PERIODE.DataSource = dt;
			try 
			{
				DATGRD_PERIODE.DataBind();
			} 
			catch 
			{
				DATGRD_PERIODE.CurrentPageIndex = 0;
				DATGRD_PERIODE.DataBind();
			}
			/*
			for (int i = 0; i < DATGRD_PERIODE.Items.Count; i++)
			{
				DATGRD_PERIODE.Items[i].Cells[0].Text = tool.FormatDate(DATGRD_PERIODE.Items[i].Cells[0].Text, true);
			}
			*/
		}

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), PeriodeDate;

			try 
			{
				PeriodeDate = Int64.Parse(Tools.toISODate(TXT_TGL_PERIODE.Text, DDL_BLN_PERIODE.SelectedValue, TXT_THN_PERIODE.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal periode tidak valid atau kosong!");
				return;
			}
			if (PeriodeDate > now)
			{
				GlobalTools.popMessage(this, "Tanggal periode tidak boleh lebih dari tanggal sekarang!");
				return;
			}

			conn.QueryString = "select * from porlms_emas_data where datepart(month, periode_data)='" + DDL_BLN_PERIODE.SelectedValue + "' and datepart(year, periode_data)='" + TXT_THN_PERIODE.Text + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				GlobalTools.popMessage(this, "Data periode " + DDL_BLN_PERIODE.SelectedItem + " " + TXT_THN_PERIODE.Text + " sudah ada di database!");
				return;
			}

			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			conn.QueryString = "EXEC PORLMS_UPLOAD_DATA_EMAS '" + 
				Session["USERID"].ToString() + "', '" +
				Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_DATA_EMAS) as MAX_ID from [PORLMS_FILE_UPLOAD_DATA_eMAS] where userid='" + Session["USERID"].ToString() + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_NAME from [PORLMS_FILE_UPLOAD_DATA_eMAS] where ID_UPLOAD_DATA_EMAS = '" + max_id + "' and userid='" + Session["USERID"].ToString() + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_NAME");
				//TXT_XLSNAME.Text = outputfilename;
			}

			conn.QueryString = "SELECT EXPORT_URL FROM PORLMS_RFUPLOAD WHERE EXPORT_ID = 'PORLMS01'";
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
				conn.QueryString = "SELECT SHEET_ID, SHEET_SEQ, STOREDPROCEDURE FROM PORLMS_TEMPLATE_MASTER";
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
						conn.QueryString = "SELECT CELL_COL, DB_FIELD FROM PORLMS_TEMPLATE_DETAIL ORDER BY ID_TEMPLATE";
						conn.ExecuteQuery();
						dt2 = conn.GetDataTable().Copy();
						int n = dt2.Rows.Count;
						object[] par;
						par = new object[n];
						object[] dttype;
						dttype = new object[n];


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
									string query = "EXEC " + proc + " " + 
										tool.ConvertDate(TXT_TGL_PERIODE.Text, DDL_BLN_PERIODE.SelectedValue, TXT_THN_PERIODE.Text) + ", '" +
										Session["UserID"].ToString() + "', ";
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

				
				ViewPeriodeData();
			}
			
		}

		private void ViewUploadFiles()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM PORLMS_RFUPLOAD WHERE EXPORT_ID = 'PORLMS01'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD_DATA_EMAS, FILE_UPLOAD_NAME FROM PORLMS_FILE_UPLOAD_DATA_eMAS where userid='" + Session["USERID"].ToString() + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DATA_UPLOAD.DataSource = dt;
			try 
			{
				DATA_UPLOAD.DataBind();
			} 
			catch 
			{
				DATA_UPLOAD.CurrentPageIndex = 0;
				DATA_UPLOAD.DataBind();
			}
			for (int i = 1; i <= DATA_UPLOAD.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DATA_UPLOAD.Items[i-1].Cells[2].FindControl("FILE_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DATA_UPLOAD.Items[i-1].Cells[3].FindControl("FILE_DELETE");
				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_NAME");
			}
		}

		private void DATA_UPLOAD_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string directory = "";
			conn.QueryString = "SELECT EXPORT_URL FROM PORLMS_RFUPLOAD WHERE EXPORT_ID = 'PORLMS01'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());
			}

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "EXEC PORLMS_DELETE_FILE_UPLOAD '" + e.Item.Cells[0].Text + "', '" +
						Session["USERID"].ToString() + "', '" +
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

		private void DATGRD_PERIODE_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Retrieve":
					LBL_TGL_PERIODE.Text = e.Item.Cells[0].Text;
					conn.QueryString = "select * from PORLMS_eMAS_DATA where periode_data='" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					FillGridPortfolio();
					break;
			}
		}

		private void DATGRD_PERIODE_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATGRD_PERIODE.CurrentPageIndex = e.NewPageIndex;
			ViewPeriodeData();
		}

		private void DATGRD_PORTFOLIO_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATGRD_PORTFOLIO.CurrentPageIndex = e.NewPageIndex;
			ViewDataPortfolio();
		}

		private void DATA_UPLOAD_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_UPLOAD.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFiles();
		}

		protected void BTN_CLEAR_PERIODE_Click(object sender, System.EventArgs e)
		{
			if(LBL_TGL_PERIODE.Text == "")
			{
				GlobalTools.popMessage(this, "Pilih salah satu periode terlebih dahulu!");
				return;
			}

			conn.QueryString = "delete PORLMS_eMAS_DATA where periode_data='" + LBL_TGL_PERIODE.Text + "'";
			conn.ExecuteQuery();

			LBL_TGL_PERIODE.Text = "";

			conn.QueryString = "select top 0 * from PORLMS_eMAS_DATA";
			conn.ExecuteQuery();

			FillGridPortfolio();
			ViewPeriodeData();
		}
		/*
		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("Body.aspx");
		}
		*/
	}
}
