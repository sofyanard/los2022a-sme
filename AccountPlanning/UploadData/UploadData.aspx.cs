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
	/// Summary description for UploadData.
	/// </summary>
	public partial class UploadData : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected string sheetname="";
		protected ArrayList array = new ArrayList();
		protected Tools tools = new Tools();
        protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);		
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if(!IsPostBack)
			{
				TR_CPA.Visible = false;
				TR_FUNDING.Visible = false;
				TR_PAYROLL.Visible = false;
				TR_SUBSIDIARY.Visible = false;
				ViewPage();
			}
		}

		private void ViewPage()
		{
			string id = Request.QueryString["mc"];
			switch(id)
			{
				case "AP0201":	// Upload CPA Data
					TR_CPA.Visible = true;
					LBL_TITLE.Text = "UPLOAD CPA DATA";
					LBL_TABLE.Text = "CPA DATA";
					break;

				case "AP0202":	// Upload Funding Data
					TR_FUNDING.Visible = true;
					LBL_TITLE.Text = "UPLOAD FUNDING DATA";
					LBL_TABLE.Text = "FUNDING DATA";
					break;

				case "AP0203":	// Upload Payroll Data
					TR_PAYROLL.Visible = true;
					LBL_TITLE.Text = "UPLOAD PAYROLL DATA";
					LBL_TABLE.Text = "PAYROLL DATA";
					break;

				case "AP0204":	// Upload Subsidiary Data
					TR_SUBSIDIARY.Visible = true;
					LBL_TITLE.Text = "UPLOAD SUBSIDIARY DATA";
					LBL_TABLE.Text = "SUBSIDIARY DATA";
					break;
			}
			FillGrid(id);
			ViewGridExcel(id);
		}

		private void FillGrid(string id)
		{
			switch(id)
			{
				case "AP0201":
					conn.QueryString = "SELECT * FROM AP_UPLOAD_CPA";
					BindData(DGR_DATA_CPA.ID.ToString(), conn.QueryString);
					break;

				case "AP0202":
					conn.QueryString = "SELECT * FROM AP_UPLOAD_FUNDING";
					BindData(DGR_DATA_FUNDING.ID.ToString(), conn.QueryString);
					break;

				case "AP0203":
					conn.QueryString = "SELECT * FROM AP_UPLOAD_PAYROLL";
					BindData(DGR_DATA_PAYROLL.ID.ToString(), conn.QueryString);
					break;

				case "AP0204":
					conn.QueryString = "SELECT * FROM AP_UPLOAD_SUBSIDIARY";
					BindData(DGR_DATA_SUBSIDIARY.ID.ToString(), conn.QueryString);
					break;
			}
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

		private void ViewGridExcel(string id)
		{
			string url = "";
			System.Data.DataTable dt = new System.Data.DataTable();

			conn.QueryString = "SELECT * FROM AP_TEMPLATE_UPLOAD WHERE ID_UPLOAD='" + id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("LINK_TEMPLATE");
				//url = /SME/Template/...
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
			this.DGR_DATA_CPA.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_DATA_CPA_PageIndexChanged);
			this.DGR_DATA_FUNDING.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_DATA_FUNDING_PageIndexChanged);
			this.DGR_DATA_PAYROLL.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_DATA_PAYROLL_PageIndexChanged);
			this.DGR_DATA_SUBSIDIARY.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_DATA_SUBSIDIARY_PageIndexChanged);

		}
		#endregion

		private string ID_UPLOAD(string id_upload)
		{
			switch(id_upload)
			{
				case "AP0201":
					id_upload = "1";
					break;
				case "AP0202":
					id_upload = "2";
					break;
				case "AP0203":
					id_upload = "3";
					break;
				case "AP0204":
					id_upload = "4";
					break;
			}
			return id_upload;
		}

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string id_upload = ID_UPLOAD(Request.QueryString["mc"]);

			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			conn.QueryString = "EXEC AP_INSERT_UPLOAD_FILE_EXP '" + id_upload + "','" + Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_EXP) AS MAX_ID FROM AP_FILE_UPLOAD_EXP WHERE ID_TEMPLATE='" + id_upload + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_EXP_NAME FROM AP_FILE_UPLOAD_EXP WHERE ID_TEMPLATE = '" + id_upload + "' AND ID_UPLOAD_EXP='" + max_id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_EXP_NAME");
				TXT_XLSNAME.Text = outputfilename;
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
		}

		private void ReadExcel(string filename)
		{
			string id_upload = ID_UPLOAD(Request.QueryString["mc"]);
			
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
				conn.QueryString = "SELECT * FROM AP_TEMPLATE_MASTER WHERE ID_UPLOAD = '" + id_upload + "'";
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
						conn.QueryString = "SELECT CELL_COL, DB_FIELD FROM AP_TEMPLATE_DETAIL WHERE ID_UPLOAD='" + id_upload + "' ORDER BY ID_VALIDATION_TEMPLATE";
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
											if(xcol=="B")
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
										else if (dttype[k].ToString() == "F")
											query = query + "" + par[k].ToString() + "";
										else if (dttype[k].ToString() == "D")
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
			catch
			{
				try
				{
					Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheetname);
					LBL_STATUS.ForeColor = Color.Green;
					LBL_STATUSREPORT.ForeColor = Color.Red;
					LBL_STATUS.Text = "Upload Sucessful!";
					LBL_STATUSREPORT.Text = "Gagal memasukkan data! Silahkan periksa kembali format datanya !";
					//LBL_STATUSREPORT.Text = ex.Message + "\n" + ex.StackTrace;
				}
				catch
				{
					//Show Success Message
					LBL_STATUS.ForeColor = Color.Green;
					LBL_STATUSREPORT.ForeColor = Color.Green;
					LBL_STATUS.Text = "Upload Sucessful! Insert dihentikan karena tidak ada sheet " + sheetname;
					LBL_STATUSREPORT.Text = "";
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
				FillGrid(Request.QueryString["mc"]);
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			string id_upload = Request.QueryString["mc"];
			
			switch(id_upload)
			{
				case "AP0201":
					conn.QueryString = "DELETE AP_UPLOAD_CPA";
					conn.ExecuteQuery();
					break;

				case "AP0202":
					conn.QueryString = "DELETE AP_UPLOAD_FUNDING";
					conn.ExecuteQuery();
					break;

				case "AP0203":
					conn.QueryString = "DELETE AP_UPLOAD_PAYROLL";
					conn.ExecuteQuery();
					break;

				case "AP0204":
					conn.QueryString = "DELETE AP_UPLOAD_SUBSIDIARY";
					conn.ExecuteQuery();
					break;
			}
			FillGrid(id_upload);
		}

		private void DGR_DATA_CPA_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_DATA_CPA.CurrentPageIndex = e.NewPageIndex;
			FillGrid("AP0201");
		}

		private void DGR_DATA_FUNDING_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_DATA_FUNDING.CurrentPageIndex = e.NewPageIndex;
			FillGrid("AP0202");
		}

		private void DGR_DATA_PAYROLL_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_DATA_PAYROLL.CurrentPageIndex = e.NewPageIndex;
			FillGrid("AP0203");
		}

		private void DGR_DATA_SUBSIDIARY_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_DATA_SUBSIDIARY.CurrentPageIndex = e.NewPageIndex;
			FillGrid("AP0204");
		}
	}
}
