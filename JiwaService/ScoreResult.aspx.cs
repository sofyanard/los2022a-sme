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
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;

namespace SME.JiwaService
{
	/// <summary>
	/// Summary description for ScoreResult.
	/// </summary>
	public partial class ScoreResult : System.Web.UI.Page
	{
		protected ArrayList array = new ArrayList();
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if(!IsPostBack)
			{
				ViewData();
				viewGridExcel();
				ViewUploadFiles();
			}
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM VALIDATION_RESULT WHERE PIC_UNIT='" +
				Request.QueryString["userid"] + "' AND UPDATE_BY='" + 
				Session["UserID"].ToString() + "' AND D_CODE='" +
				Request.QueryString["dc"] + "' AND ACTIVE='1'";
			conn.ExecuteQuery();

			if(conn.GetRowCount() > 0)
			{
				CekDataFile();
				FillGridExp();
				DataScore();
			}
		}

		private void CekDataFile()
		{
			int max_id = 10000;
			string outputfilename = "";

			conn.QueryString = "SELECT MAX(ID_UPLOAD_EXP) AS MAX_ID FROM JIWASERVICE_FILE_UPLOAD_EXP WHERE PIC_ID='" +
				Request.QueryString["userid"] + "' AND G_CODE='" + Request.QueryString["gc"] +"' AND D_CODE='" +
				Request.QueryString["dc"] + "'AND UPLOAD_BY='" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_EXP_NAME FROM JIWASERVICE_FILE_UPLOAD_EXP WHERE ID_UPLOAD_EXP = '" + max_id + "' AND PIC_ID='" +
				Request.QueryString["userid"] + "' AND G_CODE='" + Request.QueryString["gc"] +"' AND D_CODE='" +
				Request.QueryString["dc"] + "'AND UPLOAD_BY='" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_EXP_NAME");
				TXT_XLSNAME.Text = outputfilename;
			}
		}

		private void viewGridExcel()
		{
			string url = "";
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_TEMPLATE_JIWASERVICE, NAMA_TEMPLATE_JIWASERVICE, LINK_TEMPLATE_JIWASERVICE FROM JIWASERVICE_TEMPLATE";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("LINK_TEMPLATE_JIWASERVICE");
				//url = /SME/Template/Score_Card.xls
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

		private void ViewUploadFiles()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM REKANAN_RFEXPORT WHERE EXPORT_ID='JIWASERVICE01'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
				//url = /SME/JiwaServiceUpload/
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD_EXP, FILE_UPLOAD_EXP_NAME FROM JIWASERVICE_FILE_UPLOAD_EXP WHERE PIC_ID='" +
				Request.QueryString["userid"] + "' AND G_CODE='" + Request.QueryString["gc"] +"' AND D_CODE='" +
				Request.QueryString["dc"] + "'AND UPLOAD_BY='" + Session["UserID"].ToString() + "'";
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
				HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("SCORING_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[3].FindControl("SCORING_DELETE");
				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_EXP_NAME");
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
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);

		}
		#endregion

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			conn.QueryString = "EXEC JIWASERVICE_INSERT_FILE_EXP '" + 
				Request.QueryString["gc"] + "', '" +
				Request.QueryString["dc"] + "', '" +
				Request.QueryString["userid"] + "', '" +
				Session["UserID"].ToString() + "', '" +
				Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_EXP) AS MAX_ID FROM JIWASERVICE_FILE_UPLOAD_EXP WHERE PIC_ID='" + 
				Request.QueryString["userid"] + "' AND G_CODE='" + Request.QueryString["gc"] +"' AND D_CODE='" +
				Request.QueryString["dc"] + "'AND UPLOAD_BY='" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			string sdfsd = conn.GetFieldValue("MAX_ID");

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_EXP_NAME FROM JIWASERVICE_FILE_UPLOAD_EXP WHERE ID_UPLOAD_EXP = '" + max_id + "' AND PIC_ID='" +
				Request.QueryString["userid"] + "' AND G_CODE='" + Request.QueryString["gc"] +"' AND D_CODE='" +
				Request.QueryString["dc"] + "'AND UPLOAD_BY='" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_EXP_NAME");
				TXT_XLSNAME.Text = outputfilename;
			}

			conn.QueryString = "UPDATE VALIDATION_RESULT SET ACTIVE='0' WHERE G_CODE='" + Request.QueryString["gc"] +
								"' AND D_CODE='" + Request.QueryString["dc"] + "' AND PIC_UNIT='" + Request.QueryString["userid"] +
								"' AND UPDATE_BY='" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT EXPORT_URL FROM REKANAN_RFEXPORT WHERE EXPORT_ID = 'JIWASERVICE01'";
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

				//Loop for Template Master
				conn.QueryString = "SELECT * FROM JIWASERVICE_TEMPLATE_MASTER";
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
						conn.QueryString = "SELECT CELL_COL, DB_FIELD FROM JIWASERVICE_TEMPLATE_DETAIL ORDER BY ID_VALIDATION_TEMPLATE";
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
									}
								}
							
								//Construct Query
								if(flag == false)
								{
									string query = "EXEC " + proc + " '" 
										+ Request.QueryString["gc"] + "', '"
										+ Request.QueryString["dc"] + "', '"
										+ Request.QueryString["userid"] + "', '"
										+ Session["UserID"].ToString() + "', '"
										+ Session["BranchID"].ToString() + "', '"
										+ TXT_XLSNAME.Text + "', ";
									for (int k = 0; k < n; k++)
									{
										if (dttype[k].ToString() == "V")
											query = query + "'" + par[k].ToString() + "'";
										else if (dttype[k].ToString() == "N")
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

				FillGridExp();
				DataScore();
			}
			
		}

		private void FillGridExp()
		{
			conn.QueryString = "SELECT * FROM VALIDATION_RESULT WHERE PIC_UNIT='" + 
				Request.QueryString["userid"] + "' AND D_CODE='" +
				Request.QueryString["dc"] +"' AND UPDATE_BY='" + 
				Session["UserID"].ToString() + "' AND FILE_UPLOAD='" + 
				TXT_XLSNAME.Text + "' AND ACTIVE='1'";
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

		private void DataScore()
		{
			conn.QueryString = "EXEC JWS_SCORING_RESULT '" +
				Request.QueryString["userid"] + "','" +
				Request.QueryString["gc"] + "','" +
				Request.QueryString["dc"] + "','" +
				Session["UserID"].ToString() + "','" +
				TXT_XLSNAME.Text + "'";
			conn.ExecuteQuery();
			
			TXT_SCORE.Text = conn.GetFieldValue("T_SCORE").ToString();
			TXT_CATEGORY.Text = conn.GetFieldValue("CATEGORY").ToString();
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			FillGridExp();
		}

		private void DATA_EXPORT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_EXPORT.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFiles();
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string directory = "";
			conn.QueryString = "SELECT EXPORT_URL FROM REKANAN_RFEXPORT WHERE EXPORT_ID = 'JIWASERVICE01'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());
			}

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "EXEC JWS_DELETE_FILE_UPLOAD '"
						+ Request.QueryString["userid"] + "','"
						+ e.Item.Cells[0].Text + "', '"
						+ e.Item.Cells[1].Text + "','"
						+ Session["UserID"].ToString() + "'";
					conn.ExecuteQuery();
					deleteFile(directory, e.Item.Cells[1].Text);
					ViewUploadFiles();
					FillGridExp();
					DataScore();
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

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ValidationInput.aspx?mc=" + Request.QueryString["mc"] + "&exist=1");
		}
	}
}
