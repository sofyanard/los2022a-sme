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

namespace SME.MAS.CollateralAdministration.UploadData
{
	/// <summary>
	/// Summary description for UploadData.
	/// </summary>
	public partial class UploadData : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected ArrayList array = new ArrayList();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			ViewDataResult();
			if(!IsPostBack)
			{
				ViewUploadFiles();
				ViewSourceFiles();				
				
			}			
		}

		
		private void ViewDataResult()
		{
			conn.QueryString = "select * from MAS_UPLOAD_DATA order by UPLOAD_DATE desc";
			conn.ExecuteQuery();
			FillGridResult();
		}

		private void FillGridResult()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_RESULT.DataSource = dt;
			try 
			{
				DGR_RESULT.DataBind();
			} 
			catch 
			{
				DGR_RESULT.CurrentPageIndex = 0;
				DGR_RESULT.DataBind();
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
			this.DATA_UPLOAD.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_UPLOAD_ItemCommand);
			this.DATA_UPLOAD.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_UPLOAD_PageIndexChanged);
			this.DATA_UPLOAD.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DATA_UPLOAD_ItemDataBound);
			this.DGR_RESULT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_RESULT_ItemCommand);
			this.DGR_RESULT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_RESULT_PageIndexChanged);
			this.DGR_RESULT.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGR_RESULT_ItemDataBound);

		}
		#endregion

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			if (TXT_FILE_UPLOAD.Value=="" )
			{
				LBL_STATUS.ForeColor = Color.Red;
				LBL_STATUSREPORT.ForeColor = Color.Red;
				LBL_STATUS.Text = "Upload Failed!";
				LBL_STATUSREPORT.Text = "Tidak ada file yang dipilih";
			}
			else
			{
				string directory;	
				int counter = 0;
				int max_id = 10000;
				string outputfilename = "";

				conn.QueryString = "EXEC MAS_UPLOAD_DATA_TO_DB '" + 
					Session["USERID"].ToString() + "', '" +
					Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
				conn.ExecuteQuery();

				conn.QueryString = "SELECT MAX(ID_UPLOAD_DATA_MAS) as MAX_ID from [MAS_FILE_UPLOAD_DATA] where userid='" + Session["USERID"].ToString() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
				}

				conn.QueryString = "SELECT FILE_UPLOAD_NAME from [MAS_FILE_UPLOAD_DATA] where ID_UPLOAD_DATA_MAS = '" + max_id + "' and userid='" + Session["USERID"].ToString() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					outputfilename = conn.GetFieldValue("FILE_UPLOAD_NAME");
					//TXT_XLSNAME.Text = outputfilename;
				}

				conn.QueryString = "SELECT EXPORT_URL FROM MAS_RFUPLOAD WHERE EXPORT_ID = 'MAS01'";
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
			}
			ViewUploadFiles();
			ViewDataResult();
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
				conn.QueryString = "SELECT SHEET_ID, SHEET_SEQ, STOREDPROCEDURE FROM MAS_TEMPLATE_MASTER";
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
						conn.QueryString = "SELECT CELL_COL, DB_FIELD FROM MAS_TEMPLATE_DETAIL ORDER BY ID_TEMPLATE";
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
									string query = "EXEC " + proc + " '" + 
										//tool.ConvertDate(TXT_TGL_PERIODE.Text, DDL_BLN_PERIODE.SelectedValue, TXT_THN_PERIODE.Text) + ", '" +
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

				
				//ViewPeriodeData();
			}
			
		}

		private void ViewSourceFiles()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM MAS_RFUPLOAD WHERE EXPORT_ID = 'MAS01'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD_DATA_MAS, FILE_UPLOAD_NAME FROM MAS_FILE_UPLOAD_DATA where userid='template'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DATGRD_SOURCE.DataSource = dt;
			try 
			{
				DATGRD_SOURCE.DataBind();
			} 
			catch 
			{
				DATGRD_SOURCE.CurrentPageIndex = 0;
				DATGRD_SOURCE.DataBind();
			}
			for (int i = 0; i < DATGRD_SOURCE.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DATGRD_SOURCE.Items[i].Cells[2].FindControl("FILE_DOWNLOAD2");
				//LinkButton HpDelete = (LinkButton) DATA_UPLOAD.Items[i].Cells[3].FindControl("FILE_DELETE");
				HpDownload.NavigateUrl = url + conn.GetFieldValue(i,"FILE_UPLOAD_NAME");
			}
		}

		private void ViewUploadFiles()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM MAS_RFUPLOAD WHERE EXPORT_ID = 'MAS01'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD_DATA_MAS, FILE_UPLOAD_NAME FROM MAS_FILE_UPLOAD_DATA where userid='" + Session["USERID"].ToString() + "'";
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
			for (int i = 0; i < DATA_UPLOAD.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DATA_UPLOAD.Items[i].Cells[2].FindControl("FILE_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DATA_UPLOAD.Items[i].Cells[3].FindControl("FILE_DELETE");
				HpDownload.NavigateUrl = url + conn.GetFieldValue(i,"FILE_UPLOAD_NAME");
			}
		}

		private void DATA_UPLOAD_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string directory = "";
			conn.QueryString = "SELECT EXPORT_URL FROM MAS_RFUPLOAD WHERE EXPORT_ID = 'MAS01'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());
			}

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "EXEC MAS_DELETE_FILE_UPLOAD '" + e.Item.Cells[0].Text + "', '" +
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

		private void DATA_UPLOAD_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_UPLOAD.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFiles();
		}

		private void ViewMenu()
		{
			Menu.Controls.Clear();
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
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
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"] + "&exist=" + Request.QueryString["exist"]+ "&view=" + Request.QueryString["view"];
						else	
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+ "&exist=" + Request.QueryString["exist"]+ "&tc="+Request.QueryString["tc"]+ "&view=" + Request.QueryString["view"];
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"] + "&mc2=" + Request.QueryString["mc2"];
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

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			/*conn.QueryString = "delete from MAS_UPLOAD_DATA";
			conn.ExecuteQuery();*/
			string accno = "";
			string collid = "";
			for (int i = 0; i < DATA_UPLOAD.Items.Count; i++)
			{
				accno = DATA_UPLOAD.Items[i].Cells[1].Text.ToString();
				collid = DATA_UPLOAD.Items[i].Cells[3].Text.ToString();

				conn.QueryString = "delete from MAS_UPLOAD_DATA where ACC_NUMBER = '" + accno + "' AND COLLATERAL_ID = '" + collid + "' ";
				conn.ExecuteQuery();

				conn.QueryString = "SELECT * FROM MAS_APP_CURRTRACK where ACC_NUMBER = '" + accno + "' AND COLLATERALID = '" + collid + "' and AP_CURRTRACK = 'M1.2'";
				conn.ExecuteQuery();

				if(conn.GetRowCount() == 0)
				{
					conn.QueryString = "delete from MAS_APP_CURRTRACK where ACC_NUMBER = '" + accno + "' AND COLLATERALID = '" + collid + "' ";
					conn.ExecuteQuery();
					conn.QueryString = "delete from MAS_COLLATERAL_TRACK_HISTORY where ACC_NUMBER = '" + accno + "' AND COLLATERAL_ID = '" + collid + "' ";
					conn.ExecuteQuery();
				}
			}

			ViewDataResult();
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{

//			System.Web.UI.WebControls.DataGrid dg;
//			conn.QueryString = "select * from MAS_UPLOAD_DATA order by UPLOAD_DATE desc";
//			conn.ExecuteQuery();
//
//			dg.DataSource=conn.GetDataTable();
//			dg.DataBinding();
//
//			dg.Items.Count;


			for (int i = 0; i < DGR_RESULT.Items.Count; i++)
			{		
				//begitu diklik save baru isi M1.1
				//insert juga ke appcurrtrack

				conn.QueryString = "exec MAS_COLLATERAL_INSERT " +
					tool.ConvertDate(DGR_RESULT.Items[i].Cells[0].Text.Trim()) + " , '" + 
					DGR_RESULT.Items[i].Cells[1].Text.Trim() + "' , '" + 
					DGR_RESULT.Items[i].Cells[2].Text.Trim() + "' , '" + 
					DGR_RESULT.Items[i].Cells[3].Text.Trim() + "' , '" + 
					DGR_RESULT.Items[i].Cells[4].Text.Trim() + "' , '" + 
					DGR_RESULT.Items[i].Cells[5].Text.Trim() + "' , '" + 
					DGR_RESULT.Items[i].Cells[6].Text.Trim() + "' , '" + 
					DGR_RESULT.Items[i].Cells[7].Text.Trim() + "' , '" + 
					DGR_RESULT.Items[i].Cells[9].Text.Trim() + "' ";
				conn.ExecuteQuery();			
				
				
				if(DGR_RESULT.Items[i].Cells[8].Text.Trim() == "1")
				{
					conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
						DGR_RESULT.Items[i].Cells[1].Text.Trim() + "' , '" + 
						DGR_RESULT.Items[i].Cells[3].Text.Trim() + "' , 'M1.2' , '" + 
						Session["UserID"].ToString() + "' , '" + Session["UserID"].ToString() + "', '1', '" + DGR_RESULT.Items[i].Cells[8].Text.Trim() + "' ";
					conn.ExecuteQuery();
				}
				else if(DGR_RESULT.Items[i].Cells[8].Text.Trim() == "2")
				{
					conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
						DGR_RESULT.Items[i].Cells[1].Text.Trim() + "' , '" + 
						DGR_RESULT.Items[i].Cells[3].Text.Trim() + "' , 'M1.5' , '" + 
						Session["UserID"].ToString() + "' , '" + Session["UserID"].ToString() + "', '1', '" + DGR_RESULT.Items[i].Cells[8].Text.Trim() + "' ";
					conn.ExecuteQuery();
				}
			}
		}

		private void DGR_RESULT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_RESULT.CurrentPageIndex = e.NewPageIndex;
			ViewDataResult();
		}

		private void DGR_RESULT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Delete":
					conn.QueryString = "delete from MAS_UPLOAD_DATA where ACC_NUMBER = '" + e.Item.Cells[1].Text + "' AND COLLATERAL_ID = '" + e.Item.Cells[3].Text + "' ";
					conn.ExecuteQuery();
					/*conn.QueryString = "delete from MAS_COLLATERAL where ACC_NUMBER = '" + e.Item.Cells[1].Text + "' AND COLLATERAL_ID = '" + e.Item.Cells[3].Text + "' ";
					conn.ExecuteQuery();*/

					conn.QueryString = "SELECT * FROM MAS_APP_CURRTRACK where ACC_NUMBER = '" + e.Item.Cells[1].Text + "' AND COLLATERALID = '" + e.Item.Cells[3].Text + "' and AP_CURRTRACK = 'M1.2'";
					conn.ExecuteQuery();

					conn.QueryString = "delete from MAS_collateral_re where ACC_NUMBER = '" + e.Item.Cells[1].Text + "' AND COLLATERAL_ID = '" + e.Item.Cells[3].Text + "' ";
					conn.ExecuteQuery();

					conn.QueryString = "delete from MAS_collateral_veh where ACC_NUMBER = '" + e.Item.Cells[1].Text + "' AND COLLATERAL_ID = '" + e.Item.Cells[3].Text + "' ";
					conn.ExecuteQuery();

					conn.QueryString = "delete from MAS_collateral_value where ACC_NUMBER = '" + e.Item.Cells[1].Text + "' AND COLLATERAL_ID = '" + e.Item.Cells[3].Text + "' ";
					conn.ExecuteQuery();

					if(conn.GetRowCount() == 0)
					{
						/*
						conn.QueryString = "delete from MAS_APP_CURRTRACK where ACC_NUMBER = '" + e.Item.Cells[1].Text + "' AND COLLATERALID = '" + e.Item.Cells[3].Text + "' ";
						conn.ExecuteQuery();
						conn.QueryString = "delete from MAS_COLLATERAL_TRACK_HISTORY where ACC_NUMBER = '" + e.Item.Cells[1].Text + "' AND COLLATERALID = '" + e.Item.Cells[3].Text + "' ";
						conn.ExecuteQuery();*/
					}
					ViewDataResult();
					break;				
			}
		}

		private void DATA_UPLOAD_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) 
			{
				System.Web.UI.WebControls.LinkButton linkntn=(System.Web.UI.WebControls.LinkButton)e.Item.FindControl("FILE_DELETE");
				linkntn.Attributes.Add("onClick", "return confirm('Apakah Anda yakin akan menghapus data ini?')");
			}		
		}

		private void DGR_RESULT_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) 
			{
				System.Web.UI.WebControls.LinkButton linkntn=(System.Web.UI.WebControls.LinkButton)e.Item.FindControl("delete");
				linkntn.Attributes.Add("onClick", "return confirm('Apakah Anda yakin akan menghapus data ini?')");
			}
		}

	}
}
