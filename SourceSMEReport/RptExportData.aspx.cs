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
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;
using Excel;
using System.Threading;
using System.Globalization;
using System.IO;
using System.Diagnostics;

namespace SME.SourceSMEReport
{
	/// <summary>
	/// Summary description for RptExportData.
	/// </summary>
	public partial class RptExportData : System.Web.UI.Page
	{
		protected Connection conn = new Connection();
		protected Tools tools = new Tools();
		protected string var_user = "";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			var_user = (string) Session["UserID"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				LBL_BU.Text = Request.QueryString["BU"];

				initDates();
				fillRegion();
				fillProgram();
				fillPilihanInformasi();
				fillGrid();
				ViewFileExport();
			}

			BTN_EXPORT.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1)){return false;}; if (!exportInProgress()) { return false; }");
		}

		private void fillPilihanInformasi() 
		{
			string query = "select DATA_ID, DATA_DESC from RFRPTDATAANALYSIS where upper(REPORTTYPE) = 'POR'";
			GlobalTools.fillRefList(DDL_PROGRAMRPT, query, false, conn);
		}

		private void fillProgram() 
		{
			string query = "";
			string subquery1 = " and AREAID = '0000'", subquery2 = " and BUSINESSUNIT <> 'CB100'";

			if (DDL_REGION.SelectedValue != "") 
				subquery1 = " and AREAID = '" + DDL_REGION.SelectedValue + "'";			
			
			if (LBL_BU.Text != "" && LBL_BU.Text != null && LBL_BU.Text != "'nbsp;'") 
				subquery2 = " and BUSINESSUNIT = '" + LBL_BU.Text + "'";
			

			query = "select PROGRAMID, PROGRAMDESC from RFPROGRAM where ACTIVE = '1' " + subquery1 + subquery2;

			GlobalTools.fillRefList(DDL_PROGRAM, query, false, conn);
		}

		private void initDates() 
		{
			GlobalTools.initDateForm(TXT_TGL1, DDL_BLN1, TXT_THN1);
			GlobalTools.initDateForm(TXT_TGL2, DDL_BLN2, TXT_THN2);

			/// Set tanggal dengan Tahun sekarang
			/// 
			TXT_TGL1.Text = "01";
			try { DDL_BLN1.SelectedValue = "1"; } 
			catch {}
			TXT_THN1.Text = DateTime.Today.Year.ToString();

			TXT_TGL2.Text = "31";
			try { DDL_BLN2.SelectedValue = "12"; } 
			catch {}
			TXT_THN2.Text = DateTime.Today.Year.ToString();
		}

		private void fillRegion()
		{
			GlobalTools.fillRefList(DDL_REGION, "select areaid, areaname from rfarea where active = '1'", false, conn);
			fillBranch();
			//fillCity();
		}

		private void fillCity()
		{

		}

		private void fillBranch() 
		{
			if (DDL_REGION.SelectedValue == "") return;

			GlobalTools.fillRefList(DDL_BRANCH, "select BRANCH_CODE, BRANCH_NAME from RFBRANCH where ACTIVE = '1' and AREAID = '" + DDL_REGION.SelectedValue + "'", false, conn);
		}

		private int Posisi_User()
		{
			string area="";
			int Posisi;
			if (Session["BranchID"].ToString()=="99999")
			{ 
				//Head Office
				Posisi = 0;
			}
			else
			{
				conn.QueryString = "select * from rfarea where arearegmanager='" + Session["UserID"].ToString() + "' ";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
					area="yup";
				else
					area="nop";

				if (area=="yup")
				{
					Posisi=3;
				}
				else
				{
					if (Session["BranchID"].ToString()==Session["CBC"].ToString()) //(Session["GroupID"].ToString().StartsWith("01"))
					{
						//CBC
						Posisi=2;
					}
					else
					{
						//Branch
						Posisi = 1;
					}
				}
			}
			return Posisi;
		}
		private void ViewFileExport()
		{
			conn.QueryString = "select top 1 DATA_URL from RFRPTDATAANALYSIS where upper(REPORTTYPE) = 'POR'";
			conn.ExecuteQuery();
			
			if (conn.GetRowCount() > 0) 
			{
				string url = conn.GetFieldValue("DATA_URL");

				/// Mengisi Grid
				/// 
				fillGrid();

				/// Men-construct hyperlink download dan delete
				/// 
				for (int i = 1; i <= DATA_EXPORT.Items.Count; i++)
				{
					HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("HL_DOWNLOAD");
					LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[3].FindControl("LB_DELETE");
					HpDownload.NavigateUrl = url + DATA_EXPORT.Items[i-1].Cells[1].Text.Trim();

					HpDownload.Enabled = true;
					HpDelete.Enabled = true;
					HpDelete.Visible = true;

					/// kalau user yang login BUKAN user yang upload/export file, maka dia tidak punya hak
					/// untuk menghapus file tersebut
					/// 
					/*
					Response.Write("var_user: [" + var_user.ToString() + "]<BR>");
					Response.Write("user datagrid(4) : [" + DATA_EXPORT.Items[i-1].Cells[4].Text + "]<BR>");
					*/

					if (var_user.ToString().Trim() != DATA_EXPORT.Items[i-1].Cells[4].Text.Trim())
						HpDelete.Visible = false;
				}
			}
			else
			{
				fillGrid();
			}
		}

		private void fillGrid()
		{
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "select * from DATAANALYSIS_EXPORT where upper(REPORTTYPE) = 'POR' and userid = '" + (string) Session["UserID"] + "'";
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

		}
		#endregion

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportCR.aspx?mc=" + Request.QueryString["mc"] + "&BU=" + LBL_BU.Text);
		}

		protected void DDL_REGION_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//fillCity();
			fillBranch();
			fillProgram();
		}

		protected void BTN_EXPORT_Click(object sender, System.EventArgs e)
		{
			string start_date;
			string end_date;
			System.Data.DataTable dt_field = null;
			string areaid = null;
			string branchid = null;
			string data_id = null;
			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			object objValue = null;
			object objType = Type.Missing;		
			string mStatus = string.Empty;

			/// defaul date adalah tahun ini
			/// 
			start_date = GlobalTools.ToSQLDate("1", "1", DateTime.Today.Year.ToString());
			end_date = GlobalTools.ToSQLDate("31", "12", DateTime.Today.Year.ToString());

			LBL_STATUS_EXPORT.Text = "";
			LBL_STATUSEXPORT.Text = "";
			

			/// Validasi masukan tanggal awal
			/// 
			if (!GlobalTools.isDateValid(TXT_TGL1.Text, DDL_BLN1.SelectedValue, TXT_THN1.Text)) 
			{
				GlobalTools.popMessage(this, "Tanggal periode awal tidak valid!");
				return;
			}


			/// Validasi masukan tanggal akhir
			/// 
			if (!GlobalTools.isDateValid(TXT_TGL2.Text, DDL_BLN2.SelectedValue, TXT_THN2.Text)) 
			{
				GlobalTools.popMessage(this, "Tanggal periode akhir tidak valid!");
				return;
			}

			start_date = GlobalTools.ToSQLDate(TXT_TGL1.Text, DDL_BLN1.SelectedValue, TXT_THN1.Text);			
			end_date = GlobalTools.ToSQLDate(TXT_TGL2.Text, DDL_BLN2.SelectedValue, TXT_THN2.Text);

			areaid = DDL_REGION.SelectedValue;
			branchid = DDL_BRANCH.SelectedValue;
			data_id = DDL_PROGRAMRPT.SelectedValue;


			// dapatkan picklistnya ...
			// build criteria ---> default sesuatu if not selected
			// filter ----
			// start date, end date
			// areaid
			// cabang

			//1. Validate the input and default the values ....
			// default end_date ->today
			// default start_date -> 2004 Jan 1
			// default areaid = null, branch id = null


			/// Mengambil application root
			/// 
			conn.QueryString = "select APP_ROOT from APP_PARAMETER";
			conn.ExecuteQuery();
			string vAPP_ROOT = conn.GetFieldValue("APP_ROOT");	

			
			/// Mengambil nilai parameter
			/// 
			conn.QueryString = " select * from RFRPTDATAANALYSIS where DATA_ID = '" + data_id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() == 0)  
			{
				GlobalTools.popMessage(this, "Data Referensi RFRPTDATAANALYSIS kosong!");
				return;
			}

			string nota = data_id;										// nama file hasil export
			string sheet = conn.GetFieldValue("DATA_SHEET");			// sheet di excel
			string path = vAPP_ROOT + conn.GetFieldValue("DATA_PATH");	// directory excel hasil export			
			string file_xls = nota + ".XLT";							// nama file excel template
			string template = conn.GetFieldValue("DATA_TEMPLATE");		// directory excel template
			string url = conn.GetFieldValue("DATA_URL");				// url (link) untuk download
			string procedure_name = conn.GetFieldValue ("STOREPROCEDURE");
			string procedure_name2 = conn.GetFieldValue ("StoreProcedure2");
			string procedure_name3 = conn.GetFieldValue ("StoreProcedure3");


			/// Men-construct nama file
			/// 
			fileIn = template + file_xls;	// file template
			fileNm = Session["UserID"] + "-" + nota + "-POREXPORT.XLS";	// file hasil export
			fileOut = path + fileNm;		


			/// Cek apakah file templatenya (input) ada atau tidak
			/// 
			if (!File.Exists(template + file_xls)) 
			{
				GlobalTools.popMessage(this, "File Template tidak ada!");
				return;
			}

			/// Cek direktori untuk menyimpan file hasil export (output)
			/// 
			if (!Directory.Exists(path)) 
			{
				// create directory if does not exist
				Directory.CreateDirectory(path);
			}


			/// dapatkan semua fields to populate
			/// 
			/*
			conn.QueryString = "Select SEQ, EXP_COL, EXP_ROW, EXP_FIELD, [DESCRIPTION] from RFRPTGENERALEXPORTDETAIL where data_id = '" + nota + "' order by SEQ";
			conn.ExecuteQuery();
				
			dt_field = conn.GetDataTable().Copy();			
			*/
										
			Excel.Application excelApp = null;
			Excel.Workbook excelWorkBook = null;
			Excel.Sheets excelSheet = null;

			ArrayList orgId = new ArrayList();
			ArrayList newId = new ArrayList();
			
			Process[] oldProcess = Process.GetProcessesByName("EXCEL");				
			foreach(Process thisProcess in oldProcess)
				orgId.Add(thisProcess);

	
			// Always already when using Export Excel file format					
			System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
			System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");


			excelApp = new Excel.ApplicationClass();
			excelApp.Visible = false;
			excelApp.DisplayAlerts = false;						

			Process[] newProcess = Process.GetProcessesByName("EXCEL");
			foreach(Process thisProcess in newProcess)
				newId.Add(thisProcess);

			/// Save process into database
			/// 
			//SupportTools.saveProcessExcel(excelApp, newId, orgId, conn);
					
			
			excelWorkBook = excelApp.Workbooks.Open(fileIn, 0, false, 5, string.Empty, string.Empty, true, Excel.XlPlatform.xlWindows, "\t|",
				false, false, 0, true);

			excelSheet = excelWorkBook.Worksheets;

			Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheet);
							
			int counter  = 0;
			string Col ;
			int Row = 3  ;
			string Cell ;
			string Field ;

			
			int procedure_cnt = 0;  // for the moment, we handle 3 store procedures
			string exe_procedure;

			for ( procedure_cnt = 0; procedure_cnt < 3; procedure_cnt++ ) 
			{
		
				if ( procedure_cnt == 0 ) 
				{
					exe_procedure = procedure_name; 
					if (  Strings.Len(procedure_name.Trim()) == 0 ) continue;
				}
				else if ( procedure_cnt == 1 ) 
				{
					exe_procedure = procedure_name2; 
					if (  Strings.Len(procedure_name2.Trim()) == 0 ) continue;
				}
				else 
				{
					exe_procedure = procedure_name3; 
					if (  Strings.Len(procedure_name3.Trim()) == 0 ) continue;
				}
				

				conn.QueryString = "Select SEQ, DATA_COL, DATA_ROW, DATA_FIELD, [DESCRIPTION], isnull([GROUP],'0') AS [Group] from RFRPTDATAANALYSISDETAIL " + 
					" where DATA_ID = '" + nota + 
					"' and category = " + procedure_cnt.ToString() +
					" order by SEQ";
				conn.ExecuteQuery();
				dt_field = conn.GetDataTable().Copy();			


				conn.QueryString = " exec " + exe_procedure + " " + 
					start_date + "," +
					end_date + ", " + 
					GlobalTools.ConvertNull(areaid) + ", " + 
					GlobalTools.ConvertNull(branchid) + ", " +
					GlobalTools.ConvertNull(DDL_PROGRAM.SelectedValue) + ", '" + 
					DDL_PROGRAMRPT.SelectedValue + "', '" + 
					var_user + "', " + 
					GlobalTools.ConvertNull(LBL_BU.Text.Trim()) + "";
				conn.ExecuteQuery();

				/*
				if (conn.GetRowCount() == 0) 
				{
					GlobalTools.popMessage(this, "Data dari " + procedure_name + "kosong!");
					return;
				}
				*/

				for(int j = 0; j < conn.GetRowCount(); j++)
				{							
					
					
					if (counter == 0 && dt_field.Rows.Count > 0)
					{
						Row = Convert.ToInt32(dt_field.Rows[0]["DATA_ROW"]) ;
						counter = 1;
					}
					else Row ++;

					for(int i = 0; i < dt_field.Rows.Count; i++)
					{
							
						try 
						{
							
							if (dt_field.Rows[i]["Group"].ToString() != "0") 
							{
								Row = Convert.ToInt32(dt_field.Rows[i]["DATA_ROW"]);
							}
							
							Col = dt_field.Rows[i]["DATA_COL"].ToString().Trim();								
							
							Cell = Col.ToString().Trim() + Row.ToString().Trim();

							Field = dt_field.Rows[i]["DATA_FIELD"].ToString();

							objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range) excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;
						}
						catch {}
								
					}
				}  // end of j 
				// close the objects				
			} // end of running store procedure  -- MOVE BY CHENG


			//if (conn.GetRowCount() > 0) 
			//{
			try 
			{
				/// Save file fisik hasil export
				/// 
				//excelWorkSheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;
				excelWorkBook.SaveAs(fileOut, Excel.XlFileFormat.xlWorkbookNormal, null, null, null, null,
					Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, true);						
				System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));  																					 
					
	
				/// Save data file hasil export ke database
				/// 
				conn.QueryString = "exec RPT_EXPORT_DATAANALYSIS '" + 
					data_id + "', '" + 
					fileNm + "', '" + 
					var_user + " ', '1', 'POR'";
				conn.ExecuteNonQuery();													
			}
			catch (Exception exp2) 
			{ 
				LBL_STATUS_EXPORT.Text = "Export File gagal!";
				LBL_STATUSEXPORT.Text = exp2.ToString();

				//break; // Daripada menggunakan return, gunakan break, sehingga process dapat di kill...
				//return;
			}	
			//}
			


			/// Kill Process
			/// 
			try 
			{
				// close the excel objects
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
			catch { } 

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
                        catch (Exception e1)
                        {
                            continue;
                        }
                    }
				}
				
			}
			catch (Exception exp3) 
			{
				LBL_STATUS_EXPORT.Text = "Kill process gagal!";
				LBL_STATUSEXPORT.Text = exp3.ToString();
				return;
			}


			ViewFileExport();
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (e.CommandName.ToString()) 
			{
				case "delete":
					string data_id = e.Item.Cells[0].Text;
					//conn.QueryString = "delete DATAANALYSIS_EXPORT where data_id = '"+ data_id +"' and upper(REPORTTYPE) = 'POR'";
					//ahmad
					conn.QueryString = "exec RPT_EXPORT_DATAANALYSIS '" + data_id + "', null, '" + 
						var_user + " ', '2', 'POR'";
					conn.ExecuteNonQuery();

					////
					/// Get Application Root
					/// 
					conn.QueryString = "select top 1 app_root + data_path as filepath " + 
						" from app_parameter, rfrptdataanalysis " + 
						" where data_id = '" + data_id + "' and reporttype = 'POR'";
					conn.ExecuteQuery();
					string _filepath = "";
					try { _filepath = conn.GetFieldValue("filepath"); } 
					catch {}

					////////////////////////////////////////////////////////////////////
					/// Delete file from server
					/// 
					string _filename = e.Item.Cells[1].Text.Trim();
					try 
					{
						if (File.Exists(_filepath + _filename)) 
						{
							File.Delete(_filepath + _filename);
						}	
					} 
					catch (Exception ex) 
					{
						ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "Del File: " + (_filepath + _filename));
					}
					ViewFileExport();
					break;
			}
		}
	}
}
