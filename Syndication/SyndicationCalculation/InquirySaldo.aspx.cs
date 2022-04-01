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

namespace SME.Syndication.SyndicationCalculation
{
	/// <summary>
	/// Summary description for InquirySaldo.
	/// </summary>
	public partial class InquirySaldo : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			if(!IsPostBack)
			{
				FillDDLBank();
				FillDDLProduct();
				FillViewData();

				DDL_FORMAT_TYPE.Items.Clear();
				DDL_FORMAT_TYPE.Items.Add(new ListItem("Nota Standar Baru", "SDCINQUIRYSALDO"));
			}
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

		private void FillDDLBank()
		{
			DDL_BANK_TYPE.Items.Clear();
			DDL_BANK_TYPE.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_SDC_DDLBANK WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_BANK_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i,2), conn.GetFieldValue(i,1)));
			}
		}

		private void FillDDLProduct()
		{
			DDL_PRODUCT_TYPE.Items.Clear();
			DDL_PRODUCT_TYPE.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT CODE, [DESC] FROM RF_SINDIKASI_PRODUCT WHERE ACTIVE = '1'";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_PRODUCT_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillViewData()
		{
			conn.QueryString = "SELECT * FROM VW_SDC_DATA_CREDIT_FACILITIES WHERE CU_REF = '" + Request.QueryString["curef"] + "' ORDER BY PRODUCT_ID";
			BindData(DGR_VIEWDATA.ID.ToString(), conn.QueryString);
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

				for (int i = 0; i < dg.Items.Count; i++)
				{
					dg.Items[i].Cells[5].Text = tools.MoneyFormat(dg.Items[i].Cells[5].Text);
					dg.Items[i].Cells[6].Text = tools.MoneyFormat(dg.Items[i].Cells[6].Text);
					dg.Items[i].Cells[7].Text = tools.FormatDate(dg.Items[i].Cells[7].Text, true);
				}

				conn.ClearData();
			}
		}

		private void ViewExportFiles()
		{
			System.Data.DataTable dt = new System.Data.DataTable();

			conn.QueryString = "SELECT * FROM VW_DOCEXPORT_VIEWFILEEXPORT WHERE TEMPLATE_GROUP = 'SDCINQUIRYSALDO' AND AP_REGNO = '" + Request.QueryString["curef"] + "'";
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
			this.DGR_VIEWDATA.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_VIEWDATA_ItemCommand);
			this.DGR_VIEWDATA.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_VIEWDATA_PageIndexChanged);
			this.DATA_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_ItemCommand);

		}
		#endregion

		protected void BTN_SELECT_Click(object sender, System.EventArgs e)
		{
			ViewData();
		}

		private void ViewData()
		{
			//Insert Data dari table Facilities, Calculation
			if(LBL_PRODUCT_SEQ.Text == "" || LBL_PRODUCT_SEQ.Text == null)
			{
				GlobalTools.popMessage(this, "Data Invalid!");
				return;
			}
			
			try
			{
				conn.QueryString = "EXEC SDC_INQUIRY_SALDO_INFO '" + Request.QueryString["curef"] + "','" + DDL_BANK_TYPE.SelectedValue + "','" + DDL_PRODUCT_TYPE.SelectedValue + "'," + LBL_PRODUCT_SEQ.Text;
				conn.ExecuteQuery();

				TXT_BAKI_POKOK.Text				= tools.MoneyFormat(conn.GetFieldValue("BAKI_POKOK").ToString().Replace("&nbsp;", "0"));
				TXT_BAKI_IDC.Text				= tools.MoneyFormat(conn.GetFieldValue("BAKI_IDC").ToString().Replace("&nbsp;", "0"));
				TXT_OUT_NCL.Text				= tools.MoneyFormat(conn.GetFieldValue("OUT_NCL").ToString().Replace("&nbsp;", "0"));
				TXT_BUNGA_JALAN_POKOK.Text		= tools.MoneyFormat(conn.GetFieldValue("BUNGA_POKOK").ToString().Replace("&nbsp;", "0"));
				TXT_BUNGA_JALAN_IDC.Text		= tools.MoneyFormat(conn.GetFieldValue("BUNGA_IDC").ToString().Replace("&nbsp;", "0"));
				TXT_KELONGGARAN_TARIK.Text		= tools.MoneyFormat(conn.GetFieldValue("KELONGGARAN_TARIK").ToString().Replace("&nbsp;", "0"));
				TXT_KWJ_POKOK_INDUK.Text		= tools.MoneyFormat(conn.GetFieldValue("KEW_POKOK_INDUK").ToString().Replace("&nbsp;", "0"));
				TXT_KWJ_POKOK_IDC.Text			= tools.MoneyFormat(conn.GetFieldValue("KEW_POKOK_IDC").ToString().Replace("&nbsp;", "0"));
				TXT_KWJ_BUNGA_INDUK.Text		= tools.MoneyFormat(conn.GetFieldValue("KEW_BUNGA_INDUK").ToString().Replace("&nbsp;", "0"));
				TXT_KWJ_BUNGA_IDC.Text			= tools.MoneyFormat(conn.GetFieldValue("KEW_BUNGA_IDC").ToString().Replace("&nbsp;", "0"));
				TXT_DENDA_POKOK.Text			= tools.MoneyFormat(conn.GetFieldValue("DENDA_POKOK").ToString().Replace("&nbsp;", "0"));
				TXT_DENDA_BUNGA.Text			= tools.MoneyFormat(conn.GetFieldValue("DENDA_BUNGA").ToString().Replace("&nbsp;", "0"));
				TXT_OTHERS.Text					= tools.MoneyFormat(conn.GetFieldValue("OTHERS").ToString().Replace("&nbsp;", "0"));
				TXT_TOT_KWJ.Text				= tools.MoneyFormat(conn.GetFieldValue("TOT_KEWAJIBAN").ToString().Replace("&nbsp;", "0"));
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
			DDL_BANK_TYPE.SelectedValue		= "";
			DDL_PRODUCT_TYPE.SelectedValue	= "";
			LBL_PRODUCT_SEQ.Text			= "";

			//Clear Field
			TXT_BAKI_POKOK.Text				= "";
			TXT_BAKI_IDC.Text				= "";
			TXT_OUT_NCL.Text				= "";
			TXT_BUNGA_JALAN_POKOK.Text		= "";
			TXT_BUNGA_JALAN_IDC.Text		= "";
			TXT_KELONGGARAN_TARIK.Text		= "";
			TXT_KWJ_POKOK_INDUK.Text		= "";
			TXT_KWJ_POKOK_IDC.Text			= "";
			TXT_KWJ_BUNGA_INDUK.Text		= "";
			TXT_KWJ_BUNGA_IDC.Text			= "";
			TXT_DENDA_POKOK.Text			= "";
			TXT_DENDA_BUNGA.Text			= "";
			TXT_OTHERS.Text					= "";
			TXT_TOT_KWJ.Text				= "";
		}

		protected void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('InquirySaldoPrint.aspx?mc=" + Request.QueryString["mc"] + "&curef=" + Request.QueryString["curef"]
						+ "&bk=" + DDL_BANK_TYPE.SelectedValue + "&type=" + DDL_PRODUCT_TYPE.SelectedValue + "&seq=" + LBL_PRODUCT_SEQ.Text + "','PrintRequest');</script>");
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../CustomerList.aspx?mc=" + Request.QueryString["mc"]);
		}

		protected void BTN_EXPORT_Click(object sender, System.EventArgs e)
		{
			string status = "", doctype = "", acttype = "";

			if(LBL_PRODUCT_SEQ.Text == "" || LBL_PRODUCT_SEQ.Text == null)
			{
				GlobalTools.popMessage(this, "Data Invalid!");
				return;
			}

			try
			{
				conn.QueryString = "SELECT DISTINCT DOC_TYPE, ACTION_TYPE FROM DOCEXPORT_TEMPLATE_MASTER WHERE TEMPLATE_ID = '" + DDL_PRODUCT_TYPE.SelectedValue + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					doctype = conn.GetFieldValue("DOC_TYPE");
					acttype = conn.GetFieldValue("ACTION_TYPE");

					if ((doctype == "WORD") && (acttype == "WRITE"))
						status = CreateWord(DDL_PRODUCT_TYPE.SelectedValue);
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
			string	template = "";
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

			switch(templateid)
			{
				case "1":
					template = "KI"; 
					break;
				case "2":
					template = "KMK"; 
					break;
				case "3":
					template = "NCL"; 
					break;
			}

			//Get Export Properties
			conn.QueryString = "SELECT TOP 1 * FROM VW_DOCEXPORT_PARAMETER WHERE TEMPLATE_ID = '" + templateid + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				templatefilename	= conn.GetFieldValue("TEMPLATE_FILENAME");
				outputfilename		= conn.GetFieldValue("UPLOAD_FILEFORMAT").Replace("#NAME$",template).Replace("#REGNUM$",Request.QueryString["curef"]) + ".DOC";
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
							conn.QueryString = "EXEC " + proc + " '" + Request.QueryString["curef"] + "','" + DDL_BANK_TYPE.SelectedValue + "','" + DDL_PRODUCT_TYPE.SelectedValue + "'," + LBL_PRODUCT_SEQ.Text;
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

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					try 
					{					
						conn.QueryString = "SELECT TOP 1 UPLOAD_PATH FROM VW_DOCEXPORT_PARAMETER WHERE TEMPLATE_GROUP = 'SDCINQUIRYSALDO'";
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

		private void deleteFile(string directory, string filename) 
		{
			if (File.Exists(directory + filename)) 
			{
				File.Delete(directory + filename);
			}
		}

		private void DGR_VIEWDATA_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_VIEWDATA.CurrentPageIndex = e.NewPageIndex;
			FillViewData();
		}

		private void DGR_VIEWDATA_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					conn.QueryString = "SELECT * FROM VW_SDC_DATA_CREDIT_FACILITIES WHERE PRODUCT_SEQ = '" + e.Item.Cells[0].Text.ToString() +
										"' AND BANK_ID = '" + e.Item.Cells[1].Text.ToString() + "' AND PRODUCT_ID = '" + e.Item.Cells[3].Text.ToString() +
										"' AND CU_REF = '" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();

					LBL_PRODUCT_SEQ.Text				= conn.GetFieldValue("PRODUCT_SEQ").ToString().Replace("&nbsp;","");
					DDL_BANK_TYPE.SelectedValue			= conn.GetFieldValue("BANK_ID").ToString();
					DDL_PRODUCT_TYPE.SelectedValue		= conn.GetFieldValue("PRODUCT_ID").ToString();
					break;
			}
		}
	}
}
