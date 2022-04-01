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

namespace SME.MAS.CollateralAdministration.DetailCollateral
{
	/// <summary>
	/// Summary description for DataJaminan.
	/// </summary>
	public partial class DataJaminan : System.Web.UI.Page
	{
		protected Connection connn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection connn2 = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn= new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn2;
		protected System.Web.UI.WebControls.Label lbt;
		protected System.Web.UI.WebControls.Button btn_export;
		protected string coded;
	

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if (!IsPostBack)
			{
				//conn = (Connection) Session["Connection"];
				//conn2 = (Connection) Session["Connection"];

				coded=Request.QueryString["acc_number"];

//				HyperLink h1 = new HyperLink();
//				h1.Text = "Main";
//				h1.Font.Bold = true;
//				string av ="../InputNewCollateral/CollateralData.aspx?sta=exist&acc_number=" + Request.QueryString["acc_number"]+ "&collateral_id=" + Request.QueryString["collateral_id"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"];
//				h1.NavigateUrl = av ;
//				
//				
//
//				HyperLink h2 = new HyperLink();
//				h2.Text = "Data Jaminan";
//				h2.Font.Bold = true;
//				h2.NavigateUrl = "DataJaminan.aspx?acc_number="+Request.QueryString["acc_number"]+"&collateral_id="+Request.QueryString["collateral_id"]+"&de=1&sta=view" + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"];
//				
//
//				HyperLink h3 = new HyperLink();
//				h3.Text = "Dokumen Kredit";
//				h3.Font.Bold = true;
//				string aaa="DokumenKredit.aspx?acc_number="+Request.QueryString["acc_number"]+"&collateral_id="+Request.QueryString["collateral_id"]+"&de=1&sta=view" + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"];
//				h3.NavigateUrl=aaa;
//
//				
//
//				PH_SUBMENU.Controls.Add(h1);
//				PH_SUBMENU.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
//				PH_SUBMENU.Controls.Add(h2);
//				PH_SUBMENU.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
//				PH_SUBMENU.Controls.Add(h3);
//				PH_SUBMENU.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
				ViewData();
				FillDDL();
				ViewExportFiles();
			}
			
			ViewScreenMenu();
		}

		private void ViewScreenMenu()
		{
			HyperLink h2 = new HyperLink();
			h2.Text = "Administration Report";
			h2.Font.Bold = true;
			h2.NavigateUrl = "../Reporting/CollateralAdministrationReport.aspx";

			HyperLink h3 = new HyperLink();
			h3.Text = "Document Report";
			h3.Font.Bold = true;			
			h3.NavigateUrl="DataJaminan.aspx";		
			PH_SUBMENU.Controls.Add(h2);
			PH_SUBMENU.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
			PH_SUBMENU.Controls.Add(h3);
			PH_SUBMENU.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
		}

		private void FillDDL()
		{
			conn.QueryString = "select coltypeseq,coltypedesc from rfcollateraltype";
			conn.ExecuteQuery();
			
			ddl_type_col.Items.Add(new ListItem("--Pilih--", ""));

			for (int i = 0; i < conn.GetRowCount(); i++)
				ddl_type_col.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

		}

		private void ViewData()
		{
			connn.QueryString = "select cl.*, cc.COLTYPEDESC as COLLATERAL_TYPE2 from mas_collateral cl "+
			" left join rfcollateraltype cc on cl.COLLATERAL_TYPE=cc.coltypeseq " +
			"where cl.acc_number='" + Request.QueryString["acc_number"] + "'";
			connn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = connn.GetDataTable().Copy();
			DGR_list_col.DataSource = dt;
			try 
			{
				DGR_list_col.DataBind();
			} 
			catch 
			{
				DGR_list_col.CurrentPageIndex = 0;
				DGR_list_col.DataBind();
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
			this.DGR_list_col.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_list_col_ItemCommand);
			this.DGR_list_col.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_list_col_PageIndexChanged);
			this.DGR_list_col.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGR_list_col_ItemDataBound);

		}
		#endregion

		private void DGR_list_col_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":									

					string script="";
					PilihScript(e.Item.Cells[0].Text,e.Item.Cells[1].Text,out script);
                    connn2.QueryString=script;
					connn2.ExecuteQuery();
					ViewData();
					break;
			}
		}

		private void DGR_list_col_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_list_col.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}

		private void GetLinkTypeeeee( string type,  string coll_id, out string seqid,out string linkkk)
		{
			
			//string result;
			connn.QueryString = "select ct.COLLINKTABLE as linktable,cl.CL_TYPE,ct.COLTYPESEQ,cl.SIBS_COLID" +
							   " from COLLATERAL cl join RFCOLLATERALTYPE ct on cl.CL_TYPE = ct.COLTYPESEQ" +
							   " where cl.SIBS_COLID='" + coll_id +"' and cl.CL_TYPE='" + type +"'" ;

			//connn.QueryString = "EXEC DDE_JAMINAN_LIST '" + Request.QueryString["acc_number"] + "'";
			//connn.ExecuteQuery();

			connn.ExecuteQuery();
			seqid=connn.GetFieldValue("COLTYPESEQ");
            linkkk=connn.GetFieldValue("linktable");            
		}

		private void DGR_list_col_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{


			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) 
			{
				System.Web.UI.WebControls.HyperLink linkntn=(System.Web.UI.WebControls.HyperLink)e.Item.FindControl("hyper");

				string linlk="";
				PilihHalaman(e.Item.Cells[1].Text,out linlk);
								
				linkntn.Target="coldetail";
				string aaaaaaa=linlk+ "?acc_number="+ Request.QueryString["acc_number"] + "&collateral_id=" + e.Item.Cells[0].Text;
				linkntn.NavigateUrl=linlk+ "?acc_number="+ Request.QueryString["acc_number"] + "&collateral_id=" + e.Item.Cells[0].Text+"&new=0";

			}	
		}

		protected void BTN_new_Click(object sender, System.EventArgs e)
		{
			string link="";
			PilihHalaman(ddl_type_col.SelectedValue,out link);
			coldetail.Attributes["src"] = link + "?acc_number="+ Request.QueryString["acc_number"]+ "&type="+ ddl_type_col.SelectedValue + "&new=1";
			
		}

		private void PilihHalaman(string type, out string linkk)
		{
			linkk="";
			connn.QueryString = "select coltypeid from rfcollateraltype where coltypeseq='"+ type +"'" ;

			connn.ExecuteQuery();

			switch (connn.GetFieldValue("coltypeid"))
			{
				case "AR":
                    linkk="Collateral_Ar.aspx";
					break;
				case "BOND":
					linkk="Collateral_Bond.aspx";
					break;
				case "DEP":
					linkk="Collateral_Dep.aspx";
					break;
				case "INV":
					linkk="Collateral_Inv.aspx";
					break;
				case "LC":
					linkk="Collateral_Lc.aspx";
					break;
				case "LSAGR":
					linkk="Collateral_Lsagr.aspx";
					break;
				case "MISC":
					linkk="Collateral_Misc.aspx";
					break;
				case "PG":
					linkk="Collateral_Pg.aspx";
					break;
				case "PNCHQ":
					linkk="Collateral_Pnchq.aspx";
					break;
				case "RE":
					linkk="Collateral_Re.aspx";
					break;
				case "SPK":
					linkk="Collateral_Spk.aspx";
					break;
				case "STOCK":
					linkk="Collateral_Stock.aspx";
					break;
				case "TRCON":
					linkk="Collateral_Trcon.aspx";
					break;
				case "VEH":
					linkk="Collateral_Veh.aspx";
					break;
			}

		}

		private void PilihScript(string colid, string type, out string Script)
		{
			Script="";
			string scc="";
			connn.QueryString = "select coltypeid from rfcollateraltype where coltypeseq='"+ type +"'" ;
			connn.ExecuteQuery();
			Script="exec mas_change_col_" + connn.GetFieldValue("coltypeid") + " 'delete' ";

			switch (connn.GetFieldValue("coltypeid"))
			{
				case "AR":
					scc=",'','','','','','','','','','','','','','','','','','','',''";
					break;
				case "BOND":
					scc=",'','','','','','','','','','','','','','','','',''" +
						",'','','','','','','','','','','','','','','','',''";
					break;

			}
			Script=Script + ",'" + Request.QueryString["acc_number"] + "','" + colid + "'" + scc;
		}

		protected void btn_export_Click(object sender, System.EventArgs e)
		{
			string status = "", doctype = "", acttype = "";
			if(txt_acc_number.Text!="")
			{
				connn.QueryString = "SELECT acc_number FROM MAS_collateral WHERE acc_number = '" + txt_acc_number.Text + "'";
				connn.ExecuteQuery();
				if(connn.GetRowCount() > 0)
				{
					try
					{

						status = CreateExcel2();						
					
				 

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
			}
			ViewExportFiles();
		}

		private string CreateExcel2()
		{
			

			string templateid="MASCOLLDOC";
			string templatefilename = "", 
				outputfilename = "", 
				templatepath = "", 
				outputpath = "";
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
			conn.QueryString = "SELECT TOP 1 * FROM VW_MAS_DOCEXPORT_PARAMETER WHERE TEMPLATE_ID = 'MASCOLLDOC'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				
				templatefilename = conn.GetFieldValue("TEMPLATE_FILENAME");
				outputfilename = conn.GetFieldValue("UPLOAD_FILEFORMAT").Replace("#USERID$",Session["UserID"].ToString()) + "-" + txt_acc_number.Text ;
				templatepath = Server.MapPath(conn.GetFieldValue("TEMPLATE_PATH").Trim());
				outputpath = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());

				conn.QueryString = "exec MAS_SETNAME_EXPORT_DOC 'MASCOLLDOC','" + Session["UserID"].ToString().Trim() + 
									"','"+outputfilename+"'";
				conn.ExecuteQuery();
				
				outputfilename = conn.GetFieldValue("nameexport") + ".XLS";

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
					//SupportTools.saveProcessExcel(excelApp, newId, orgId, conn);

					fileIn = templatepath + templatefilename;
					excelWorkBook = excelApp.Workbooks.Open(fileIn, 0, false, 5, string.Empty, string.Empty, true, Excel.XlPlatform.xlWindows, "\t|",
						false, false, 0, true);

					excelSheet = excelWorkBook.Worksheets;

					//Loop for Template Master
					conn.QueryString = "SELECT SHEET_ID, SHEET_SEQ, STOREDPROCEDURE FROM MAS_DOCEXPORT_TEMPLATE_MASTER WHERE TEMPLATE_ID = 'MASCOLLDOC'";
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
							conn.QueryString = "EXEC " + proc + " '" + txt_acc_number.Text + "'" ;								
							conn.ExecuteQuery();
							dt3 = conn.GetDataTable().Copy();

							if (dt3.Rows.Count > 0)
							{
								//Loop for Template Detail //cek prosedur
								conn.QueryString = "SELECT CELL_ROW, CELL_COL, DB_FIELD FROM MAS_DOCEXPORT_TEMPLATE_DETAIL WHERE TEMPLATE_ID = 'MASCOLLDOC' ORDER BY SEQ";
								conn.ExecuteQuery();
								dt2 = conn.GetDataTable().Copy();

								for (int k = 0; k < dt3.Rows.Count; k++)
								{
									for (int j = 0; j < dt2.Rows.Count; j++)
									{
										int irow;
										try {irow = int.Parse(dt2.Rows[j][0].ToString().Trim()) + k;}
										catch {irow = 1;}
										string xrow = irow.ToString().Trim();
										string xcol = dt2.Rows[j][1].ToString().Trim();
										string dbfield = dt2.Rows[j][2].ToString().Trim();
										string cell_value = dt3.Rows[k][dbfield].ToString().Trim();
										string xcell = xcol + xrow;

										Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(xcell, xcell);
										if (excelCell != null)
										{
											excelCell.Value2 = cell_value;
											writeitem++;
										}
									}
								}
							}
							else
							{
								//returnmsg = "Query Has No Row!!";
								//return returnmsg;
							}
						}

						
						//if (writeitem > 0)
						//{
						//Save Excel File
						fileOut = outputpath + outputfilename;
						excelWorkBook.SaveAs(fileOut, Excel.XlFileFormat.xlWorkbookNormal, null, null, null, null,
							Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, true);

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
							//Save to Table //cek prosedur
							conn.QueryString = "EXEC MAS_DOCEXPORT_SAVE '1', '" + 
								templateid + "', '" + 								
								Session["UserID"].ToString().Trim() + "', '" + 
								outputfilename + "', 1";
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
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT * FROM VW_MAS_DOCEXPORT_VIEWFILEEXPORT WHERE TEMPLATE_GROUP = 'MASCOLLDOC' AND FE_USERID = '" + Session["UserID"].ToString() + "'";
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

		private void deleteFile(string directory, string filename) 
		{
			if (File.Exists(directory + filename)) 
			{
				File.Delete(directory + filename);
			}
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					try 
					{					
						conn.QueryString = "SELECT TOP 1 UPLOAD_PATH FROM VW_MAS_DOCEXPORT_PARAMETER WHERE TEMPLATE_GROUP = 'MASCOLLATERAL'";
						conn.ExecuteQuery();

						if (conn.GetRowCount() > 0)
						{
							string directory = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());
						
							//Delete File Physically
							deleteFile(directory, e.Item.Cells[3].Text);
							Response.Write("<!-- file : " + directory + e.Item.Cells[3].Text + " -->");
							Response.Write("<!-- file is deleted. -->");

							conn.QueryString = "EXEC MAS_DOCEXPORT_SAVE '2', '" + e.Item.Cells[1].Text +
								"', '" + e.Item.Cells[2].Text + "', '" + e.Item.Cells[3].Text + "', " + e.Item.Cells[7].Text;
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

		private void DATA_EXPORT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_EXPORT.CurrentPageIndex = e.NewPageIndex;
		ViewExportFiles();
		}





	}
}
