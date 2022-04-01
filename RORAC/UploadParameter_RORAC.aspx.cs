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

namespace SME.RORAC
{
	/// <summary>
	/// Summary description for UploadParameter_RORAC.
	/// </summary>
	/// 

	public partial class UploadParameter_RORAC : System.Web.UI.Page
	{
		protected Connection conn;
		protected ArrayList array = new ArrayList();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			ViewTemplateParameterRORAC();
			ViewUploadFiles();
			
			DATA_EXPORT.ItemCommand += new DataGridCommandEventHandler(DATA_EXPORT_ItemCommand);
			
		}

		private void ViewTemplateParameterRORAC()
		{
			string url = "";
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_TEMPLATE_RORAC, NAMA_TEMPLATE_RORAC, LINK_TEMPLATE_RORAC FROM TEMPLATE_RORAC";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("LINK_TEMPLATE_RORAC");
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
				HyperLink HpDownload = (HyperLink) DATA_TEMPLATE.Items[i-1].Cells[2].FindControl("HL_DOWNLOAD");
				HpDownload.NavigateUrl = url + "RORAC.xlt";
			}
		}

		private void ViewUploadFiles()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM RFRORACCUSTEXPORT WHERE EXPORT_ID = '" + "RORAC" + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD_RORAC, FILE_UPLOAD_RORAC_NAME FROM FILE_UPLOAD_RORAC";
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
				HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("UPL_RORAC_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[3].FindControl("UPL_RORAC_DELETE");
				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_RORAC_NAME");
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

		}
		#endregion

		private void DATA_EXPORT_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string directory = "";
			conn.QueryString = "SELECT EXPORT_URL FROM RFRORACCUSTEXPORT WHERE EXPORT_ID = 'RORAC'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());
			}

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "EXEC RORAC_DELETE_FILE_UPLOAD '" + e.Item.Cells[0].Text + "'";
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

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			//Get Export Properties
			conn.QueryString = "EXEC RORAC_INSERT_FILE_UPLOAD '" + Session["USERID"].ToString() + "','" +
					Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_RORAC) as MAX_ID from [FILE_UPLOAD_RORAC]";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_RORAC_NAME from [FILE_UPLOAD_RORAC] where ID_UPLOAD_RORAC = '" + max_id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_RORAC_NAME");
			}

			conn.QueryString = "SELECT EXPORT_URL FROM RFRORACCUSTEXPORT WHERE EXPORT_ID = 'RORAC'";
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
				conn.QueryString = "SELECT SHEET_ID, SHEET_SEQ, STOREDPROCEDURE FROM RORAC_TEMPLATE_MASTER";
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
						conn.QueryString = "SELECT CELL_COL, DB_FIELD FROM RORAC_TEMPLATE_DETAIL ORDER BY ID_RORAC_TEMPLATE_DETAIL";
						conn.ExecuteQuery();
						dt2 = conn.GetDataTable().Copy();
						int n = dt2.Rows.Count; //19
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
									//string xrow = dt2.Rows[j][1].ToString().Trim();
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
									catch(Exception ex)
									{
										flag = true;
									}
								}

								string cif = "", rorac = "", ec = "";
							
								//Construct Query
								if(flag == false)
								{
									string query = "EXEC " + proc + " ";
									for (int k = 0; k < n; k++)
									{
										if (dttype[k].ToString() == "C")
											query = query + "'" + par[k].ToString() + "'";
										else if (dttype[k].ToString() == "N")
											query = query + "" + par[k].ToString() + "";
										else if (dttype[k].ToString() == "F")
											query = query + "" + par[k].ToString() + "";

										if (k < n-1)
											query = query + ", ";


										if(k == 0)
										{
											cif = par[k].ToString();
										}
										else if(k == 13)
										{
											ec = par[k].ToString();
										}
										else if(k == 18)
										{
											rorac = par[k].ToString();
										}
									}
									
									array.Add(new UploadedData(cif,rorac,ec));

									//Run Query
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
			catch (Exception ex)
			{
				LBL_STATUS.ForeColor = Color.Green;
				LBL_STATUSREPORT.ForeColor = Color.Red;
				LBL_STATUS.Text = "Upload Sucessful!";
				LBL_STATUSREPORT.Text = "Inserting Data Failed! Please check the validity of your data !";
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

//				for(int i =0; i<array.Count; i++)
//				{
//					Tools.popMessage(this,((UploadedData)array[i]).CIF.ToString());
//					Tools.popMessage(this,((UploadedData)array[i]).EC.ToString());
//					Tools.popMessage(this,((UploadedData)array[i]).RORAC.ToString());
//				}

//				DataTable dt = new DataTable();  
//				DataRow row;  
//				DataColumn col1 = new DataColumn("CIF");  
//				DataColumn col2 = new DataColumn("EC");  
//				DataColumn col3 = new DataColumn("RORAC");  
//				dt.Columns.Add(col1);  
//				dt.Columns.Add(col2);  
//				dt.Columns.Add(col3);  
//
//				row = dt.NewRow();  
//				dt.Rows.Add(row);  
//				foreach (object item in array)  
//				{  
//					string[] ItemArray = ((string[])item);  
//					row = dt.NewRow();  
//					row["CIF"] = ItemArray[0];  
//					row["EC"] = ItemArray[1];  
//					row["RORAC"] = ItemArray[2];  
//					dt.Rows.Add(row);  
//				}  

				DatGrd.DataSource = array;
				DatGrd.DataBind();
			}
/*
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
					if(!bSameId) xnewId.Kill();
				}
			}
			catch { }*/
		}

		public class UploadedData
		{
			private string cif;
			private string rorac;
			private string ec;

			public UploadedData(string CIF, string RORAC, string EC)
			{
				this.cif = CIF;
				this.rorac = RORAC;
				this.ec = EC;
			}

			public string CIF
			{
				get
				{
					return this.cif;
				}
			}

			public string RORAC
			{
				get
				{
					return this.rorac;
				}
			}

			public string EC
			{
				get
				{
					return this.ec;
				}
			}
		}
	}
}



