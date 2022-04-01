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
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;


namespace SME.AccountPlanning.WalletShareTarget
{
	/// <summary>
	/// Summary description for WalletMain.
	/// </summary>
	public partial class WalletMain : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected ArrayList array = new ArrayList();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				
			}

			ViewMenu();
			ViewData();
			ViewTemplateParameterAP();
			BindData(DatagridWalletMain.ID.ToString(), "EXEC AP_GET_WALLET_SIZING ''");
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

		private void ViewTemplateParameterAP()
		{
			string url = "";
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_TEMPLATE, TEMPLATE_NAME, TEMPLATE_LINK FROM AP_TEMPLATE_WALLET_SIZE";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("TEMPLATE_LINK");
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
				HpDownload.NavigateUrl = url + "WalletSizeTemplate.xlt";
			}
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
							strtemp = "cif=" + Request.QueryString["cif"] + "&bs=" + Request.QueryString["bs"] + "&bc=" + Request.QueryString["bc"] + "&rd=" + Request.QueryString["rd"] + "&cd=" + Request.QueryString["cd"];
						else	
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&cif=" + Request.QueryString["cif"] + "&bs=" + Request.QueryString["bs"] + "&bc=" + Request.QueryString["bc"] + "&rd=" + Request.QueryString["rd"] + "&cd=" + Request.QueryString["cd"];
					}
					else 
					{
						strtemp = ""; 
					}
					t.NavigateUrl = conn.GetFieldValue(i,3) + strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void ViewData()
		{
			/*conn.QueryString = "SELECT DISTINCT CIF#,CUSTOMER_GROUP,CUST_ADDRESS,CUST_CITY,CUST_DATE,RM_NAME,GROUP_NAME,BRANCH_NAME,CUST_LENGTH FROM VW_AP_CUSTOMER_LIST" +
				" WHERE CIF#='" + Request.QueryString["cif"] + "' AND BUSSUNITID='" + Request.QueryString["bs"] + "' AND BUC='" + Request.QueryString["bc"] +
				"' AND (RM_ID='" + Request.QueryString["rd"] + "' OR CST_ID='" + Request.QueryString["cd"] + "')";*/
			conn.QueryString = "SELECT * FROM VW_AP_CUSTOMER_LIST WHERE CIF#='" + Request.QueryString["cif"] + "' ORDER BY CONVERT(INT, CIF#)";
			conn.ExecuteQuery();

			/*TXT_CIF.Text = conn.GetFieldValue("CIF#").ToString();
			TXT_CUST_NAME.Text = conn.GetFieldValue("CUSTOMER_GROUP").ToString();
			TXT_ADDRESS.Text = conn.GetFieldValue("CUST_ADDRESS").ToString();
			TXT_KOTA.Text = conn.GetFieldValue("CUST_CITY").ToString();
			TXT_CUST_DATE.Text = tools.FormatDate(conn.GetFieldValue("CUST_DATE").ToString());
			TXT_RM.Text = conn.GetFieldValue("RM_NAME").ToString();
			TXT_GROUP_NAME.Text = conn.GetFieldValue("GROUP_NAME").ToString();
			TXT_UNIT_NAME.Text = conn.GetFieldValue("BRANCH_NAME").ToString();
			TXT_RELATIONSHIP.Text = conn.GetFieldValue("CUST_LENGTH").ToString();

			FillDataGrid();*/
		}

		private void FillDataGrid()
		{
			conn.QueryString = "EXEC AP_RECAP_WALLET_SIZE '" + Request.QueryString["cif"] + "','ANCHORONLY'";
			//BindData(DGR_WALLETSIZE.ID.ToString(), conn.QueryString);
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

		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../CustomerList.aspx?mc=" + Request.QueryString["mc"]);
		}

		private void DGR_WALLETSIZE_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			/*if(DGR_WALLETSIZE.CurrentPageIndex >= 0 && DGR_WALLETSIZE.CurrentPageIndex < DGR_WALLETSIZE.PageCount)
			{
				DGR_WALLETSIZE.CurrentPageIndex = e.NewPageIndex;
				//conn2.QueryString = "EXEC AP_RECAP_WALLET_SIZE '" + CIF + "','ANCHORONLY'";
				conn.QueryString = "EXEC AP_RECAP_WALLET_SIZE '" + Request.QueryString["cif"] + "','ANCHORONLY'";
				BindData(DGR_WALLETSIZE.ID.ToString(), conn.QueryString);
			}*/
		}

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			//Get Export Properties
			conn.QueryString = "EXEC AP_INSERT_WALLETSIZE_UPLOAD '" + Session["USERID"].ToString() + "','" +
				Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_WALLETSIZE) as MAX_ID from [AP_WALLET_SIZE_FILE_UPLOAD]";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT [FILE_NAME] from [AP_WALLET_SIZE_FILE_UPLOAD] where ID_UPLOAD_WALLETSIZE = '" + max_id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_NAME");
			}

			conn.QueryString = "SELECT EXPORT_URL FROM RFRORACCUSTEXPORT WHERE EXPORT_ID = 'ACC_PLAN'";
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
					BindData(DatagridWalletMain.ID.ToString(), "EXEC AP_GET_WALLET_SIZING ''");
				}
				catch {}
			}
			//ViewDataUpload();
		}

		/*private void ViewUploadFiles()
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
		}*/

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
				conn.QueryString = "SELECT SHEET_ID, SHEET_SEQ, STOREDPROCEDURE FROM AP_WALLET_SIZE_TEMPLATE_MASTER";
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
						conn.QueryString = "SELECT CELL_COL, DB_FIELD FROM AP_WALLET_SIZE_TEMPLATE_DETAIL ORDER BY ID_DETAIL";
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
										string sdsa = ex.Message.ToString();
										string yuyu = ex.Message.ToString();
									}
								}
							
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
									}
									
									//array.Add(new UploadedData(cif,rorac,ec));

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

				//DatGrd.DataSource = array;
				//DatGrd.DataBind();
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
	}
}
