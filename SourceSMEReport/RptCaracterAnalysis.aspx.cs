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
using System.Diagnostics;
using System.IO;

namespace SME.SourceSMEReport
{
	/// <summary>
	/// Summary description for RptCaracterAnalysis.
	/// </summary>
	public partial class RptCaracterAnalysis : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();
		protected string var_userid;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{			
			Conn = (Connection) Session["Connection"];
			//double tahun;
			LBL_BU.Text = Request.QueryString["BU"];
			var_userid = (string) Session["UserID"];



			if (!IsPostBack)
			{
				/// Drop downs Initialization
				/// 				

				/// Tanggal
				/// 
				GlobalTools.initDateForm(TXT_Day1, DDL_Month1, TXT_Year1, false);
				GlobalTools.initDateForm(TXT_Day2, DDL_Month2, TXT_Year2, false);
				GlobalTools.initDateForm(TXT_DAY3, DDL_MONTH3, TXT_YEAR3, false);


				/// Program
				/// 
				string query = "";
				if (LBL_BU.Text.Trim() != "" && LBL_BU.Text.Trim() != "&nbsp;") 
				{
					query = "select distinct PROGRAMID, PROGRAMDESC from RFPROGRAM where businessunit = '" + LBL_BU.Text.Trim() + "' and  fi_approval_ver in ('2','3')";
				}
				else 
				{
					query = "select distinct PROGRAMID, PROGRAMDESC from RFPROGRAM where fi_approval_ver in ('2','3')";
				}
				GlobalTools.fillRefList(DDL_Program, query, false, Conn);

					
				/// Pilihan Informasi
				///  --- post back to handle it 
				/* dipindahkan ke event ddl_program_changed by deni
				query = "select DATA_ID, DATA_DESC from RFRPTDATAANALYSIS where REPORTTYPE = 'r-c'";
				Conn.QueryString = query;
				Conn.ExecuteQuery();
				this.DDL_PROGRAMRPT.Items.Clear();
				this.DDL_PROGRAMRPT.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					if (i==0)
						LBL_Score.Text	= Conn.GetFieldValue(0, "DATA_ID");
					String s0 = Conn.GetFieldValue(i, "DATA_ID"),
						s1 = Conn.GetFieldValue(i, "DATA_DESC");
					ListItem li = new ListItem(s1,s0);
					this.DDL_PROGRAMRPT.Items.Add(li);
				}
				*/


				/**
				 * Old Codes
				 * 
				DDL_year.Items.Add(new ListItem("-- PILIH --",""));
				tahun = double.Parse(DateTime.Now.Date.Year.ToString());
				for (double i=tahun-3; i <= tahun; i++)
				{
					DDL_year.Items.Add(new ListItem(i.ToString(), i.ToString()));
				}
				**/

				this.setDefault();
				Label1.Text = Posisi_User().ToString();

			}

			//Load_Data("VIEW");
			ViewFileExport();

			//BTN_LIHAT.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			//Btn_Print.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			BTN_EXPORT.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;}; if(!exportInProgress()) { return false; }");
		}
	

		private void setDefault() 
		{
			/*
			TXT_Day1.Text = "1";
			DDL_Month1.SelectedValue = "1";
			TXT_Year1.Text = DateTime.Today.Year.ToString();

			TXT_Day2.Text = "31";
			DDL_Month2.SelectedValue = "12";
			TXT_Year2.Text = DateTime.Today.Year.ToString();
			*/
		}


		/// <summary>
		/// Validasi input (Tanggal, dll).
		/// </summary>
		private void validateInput()
		{
			if (!GlobalTools.isDateValid(TXT_Day1.Text.Trim(), DDL_Month1.SelectedValue, TXT_Year1.Text.Trim())) 
			{
				GlobalTools.popMessage(this, "Past Start Date tidak valid!");
				return;
			}

			if (!GlobalTools.isDateValid(TXT_Day2.Text.Trim(), DDL_Month2.SelectedValue, TXT_Year2.Text.Trim())) 
			{
				GlobalTools.popMessage(this, "Past End Date tidak valid!");
				return;
			}

			if (!GlobalTools.isDateValid(TXT_DAY3.Text.Trim(), DDL_MONTH3.SelectedValue, TXT_YEAR3.Text.Trim())) 
			{
				GlobalTools.popMessage(this, "Recent End Date tidak valid!");
				return;
			}
		}

		private string getConstructedDate(string tanggal, string bulan, string tahun) 
		{
			string consDate = "";

			consDate = "" + tahun + "-" + bulan + "-" + tanggal + "";
			return consDate;
		}

		private void Load_Data(string command)
		{
			/*
			string ddl_tahun = "";
			if (!DDL_year.SelectedValue.Equals(""))	{
				ddl_tahun = DDL_year.SelectedValue;
			}
			else {
				ddl_tahun = DateTime.Now.Year.ToString();
			}
			*/

			validateInput();
			
			string vPastStartDate, vPastEndDate, vRecentEndDate;
			
			vPastStartDate = this.getConstructedDate(TXT_Day1.Text.Trim(), DDL_Month1.SelectedValue, TXT_Year1.Text.Trim());
			vPastEndDate = this.getConstructedDate(TXT_Day2.Text.Trim(), DDL_Month2.SelectedValue, TXT_Year2.Text.Trim());
			vRecentEndDate = this.getConstructedDate(TXT_DAY3.Text.Trim(), DDL_MONTH3.SelectedValue, TXT_YEAR3.Text.Trim());

			if (command=="VIEW")
			{
				Load_ReportViewer(vPastStartDate, vPastEndDate, vRecentEndDate, DDL_PROGRAMRPT.SelectedValue, DDL_Program.SelectedValue);
			}
			else
			{
				Load_ReportPrint(vPastStartDate, vPastEndDate, vRecentEndDate, DDL_PROGRAMRPT.SelectedValue, DDL_Program.SelectedValue);
			}			
		}
		
		/// <summary>
		/// Fungsi ini dulu dipakai oleh azmi. Sekarang (25/01/2005) sepertinya tidak dipakai lagi
		/// </summary>
		/// <param name="ddl_tahun"></param>
		private void Load_ReportViewer(string ddl_tahun)
		{
			string ReportAddr="", sql_kondisi="";
			double start_year=0, end_year=0;
			end_year = double.Parse(ddl_tahun.ToString());
			start_year = end_year; //double.Parse(ddl_tahun.ToString())-3;

            sql_kondisi += " and A1.[year]=" + end_year + " "; 

			/// Get report address from parameter
			/// 
			Conn.QueryString = "select reportaddr from app_parameter";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
			{
				ReportAddr = Conn.GetFieldValue(0,0);
			}
			else
			{
				ReportAddr  = "10.123.12.50";
			}	
			///////////////////////////////////////////
			

			/*
			ReportViewer1.ServerUrl = "http://" + ReportAddr + "/ReportServer";
			ReportViewer1.ReportPath = "/SMEReports/RptCaracteristicAnalisis&sql_kondisi=" + Server.HtmlEncode(sql_kondisi) + "&tahun=" + ddl_tahun + "&rs:Command=Render&rc:Toolbar=True";
			*/
		}


		/// <summary>
		/// Fungsi ini dulu dipakai oleh azmi. Sekarang (25/01/2005) sepertinya tidak dipakai lagi
		/// </summary>
		/// <param name="ddl_tahun"></param>
		private void Load_ReportPrint(string ddl_tahun)
		{
			string sql_kondisi="";
			double start_year=0, end_year=0;
			end_year = double.Parse(ddl_tahun.ToString());
			start_year = double.Parse(ddl_tahun.ToString())-3;
			sql_kondisi += " and year between " + start_year.ToString() + " and " + end_year.ToString(); 
			
			Response.Redirect("RptCaracterAnalysisPrint.aspx?sql_kondisi=" + Server.HtmlEncode(sql_kondisi) + "&start_year=" + start_year + "&end_year=" + end_year);
		}


		private void Load_ReportViewer(string vPastStartDate, string vPastEndDate, string vRecentEndDate, string vNotaID, string vProgramID)
		{			
			string ReportAddr="", sql_kondisi="";

			/**
			double start_year=0, end_year=0;
			end_year = double.Parse(ddl_tahun.ToString());
			start_year = end_year; //double.Parse(ddl_tahun.ToString())-3;
			sql_kondisi += " and A1.[year]=" + end_year + " "; 
			**/

			/// Get report address from parameter
			/// 
			Conn.QueryString = "select reportaddr from app_parameter";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
			{
				ReportAddr = Conn.GetFieldValue(0,0);
			}
			else
			{
				ReportAddr  = "10.123.12.50";
			}	
			///////////////////////////////////////////
			

			/// Construct kondisi untuk query
			/// 
			string vUserID = (string) Session["UserID"];
			sql_kondisi = vPastStartDate + ", " + vPastEndDate + ", " + vRecentEndDate + ", '" + vNotaID + "', '" + vProgramID + "', '" + vUserID + "'"; 
			///////////////////////////////////////////////

			//ReportViewer1.ServerUrl = "http://" + ReportAddr + "/ReportServer";

			//ReportViewer1.ReportPath = "/SMEReports/RptCaracteristicAnalisis&sql_kondisi=" + Server.HtmlEncode(sql_kondisi) + "&tahun=&rs:Command=Render&rc:Toolbar=True";

			/*
			ReportViewer1.ReportPath = "/SMEReports/RptCaracteristicAnalisis&past_start_date=" + vPastStartDate + 
				"&past_end_date=" + vPastEndDate + 
				"&recent_end_date=" + vRecentEndDate + 
				"&nota_id=" + vNotaID + 
				"&program_id=" + vProgramID +"&rs:Command=Render&rc:Toolbar=True";			
			*/
		}


		private void Load_ReportPrint(string vPastStartDate, string vPastEndDate, string vRecentEndDate, string vNotaID, string vProgramID)
		{
		
			string sql_kondisi="";

			/*
			double start_year=0, end_year=0;
			end_year = double.Parse(ddl_tahun.ToString());
			start_year = double.Parse(ddl_tahun.ToString())-3;
			sql_kondisi += " and year between " + start_year.ToString() + " and " + end_year.ToString(); 
			*/

			/// Construct kondisi untuk query
			/// 
			string vUserID = (string) Session["UserID"];
			sql_kondisi = vPastStartDate + ", " + vPastEndDate + ", " + vRecentEndDate + ", '" + vNotaID + "', '" + vProgramID + "', '" + vUserID + "'"; 
			///////////////////////////////////////////////
			

			Response.Redirect("RptCaracterAnalysisPrint.aspx?past_start_date=" + vPastStartDate + 
				"&past_end_date=" + vPastEndDate + 
				"&recent_end_date=" + vRecentEndDate + 
				"&nota_id=" + vNotaID + 
				"&program_id=" + vProgramID);			
		}


		private int Posisi_User()
		{
			string area = "";
			int Posisi;
			if (Session["BranchID"].ToString()=="99999")
			{ 
				//Head Office
				Posisi = 0;
			}
			else
			{
				Conn.QueryString = "select * from RFAREA where AREAREGMANAGER ='" + Session["UserID"].ToString() + "' ";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount() > 0) area = "yup";
				else area = "nop";				

				if (area=="yup")
				{
					//User adalah Manager Area
					Posisi=3;
				}
				else
				{
					//if (Session["GroupID"].ToString().StartsWith("01"))
					if (Session["CBC"].ToString().Equals(Session["BranchID"].ToString()))
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
			Conn.QueryString = "select top 1 DATA_URL from RFRPTDATAANALYSIS";
			Conn.ExecuteQuery();
			
			if (Conn.GetRowCount() > 0) 
			{
				string url = Conn.GetFieldValue("DATA_URL");

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

					if (var_userid.ToString().Trim() != DATA_EXPORT.Items[i-1].Cells[4].Text.Trim())
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
			Conn.QueryString = "select * from DATAANALYSIS_EXPORT where upper(REPORTTYPE) = 'R-C' and userid = '" + (string) Session["UserID"] + "'";
			Conn.ExecuteQuery();
			dt = Conn.GetDataTable().Copy();
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

		protected void btn_Back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportCR.aspx?mc=" + Request.QueryString["mc"] + "&BU=" + LBL_BU.Text);
		}

		protected void BTN_LIHAT_Click(object sender, System.EventArgs e)
		{
				Load_Data("VIEW");
		}

		protected void Btn_Print_Click(object sender, System.EventArgs e)
		{
				Load_Data("PRINT");
		}

		protected void BTN_EXPORT_Click(object sender, System.EventArgs e)
		{
			string past_start_date;
			string past_end_date;
			string recent_end_date;
			System.Data.DataTable dt_field = null;

			/*
			string areaid=null;
			string branchid=null;
			*/

			string data_id=null;
			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			//object objPaste = null;
			//object objCopy = null;
			//bool bSukses = true;
			object objValue = null;
			object objType = Type.Missing;		
			string mStatus = string.Empty;
			//int iItem = 0;
			//int iItemOther = 0;
			//int iItemPosition = 0;
		//	int m_Row = 0;
			
			ArrayList orgId = new ArrayList();
			ArrayList newId = new ArrayList();
			
			LBL_STATUS_EXPORT.Text = "";
			LBL_STATUSEXPORT.Text = "";


			/// defaul date adalah tahun ini, tahun-1, tahun-2
			/// 
			int tahun1, tahun2;
			tahun1 = DateTime.Today.Year - 2;
			tahun2 = DateTime.Today.Year - 1;

			past_start_date = GlobalTools.ToSQLDate("1", "1", tahun1.ToString());
			past_end_date = GlobalTools.ToSQLDate("1", "1", tahun2.ToString());
			recent_end_date = GlobalTools.ToSQLDate("1", "1", DateTime.Today.Year.ToString());
			

			/// Validasi masukan Past Start Date
			/// 
			if (!GlobalTools.isDateValid(TXT_Day1.Text, DDL_Month1.SelectedValue, TXT_Year1.Text)) 
			{
				GlobalTools.popMessage(this, "Past Start Date tidak valid!");
				return;
			}


			/// Validasi masukan Past End Date
			/// 
			if (!GlobalTools.isDateValid(TXT_Day2.Text, DDL_Month2.SelectedValue, TXT_Year2.Text)) 
			{
				GlobalTools.popMessage(this, "Past End Date/Recent Start Date tidak valid!");
				return;
			}


			/// Validasi masukan Recent Start Date
			/// 
			if (!GlobalTools.isDateValid(TXT_DAY3.Text, DDL_MONTH3.SelectedValue, TXT_YEAR3.Text)) 
			{
				GlobalTools.popMessage(this, "Recent End Date tidak valid!");
				return;
			}


			past_start_date = GlobalTools.ToSQLDate(TXT_Day1.Text, DDL_Month1.SelectedValue, TXT_Year1.Text);			
			past_end_date = GlobalTools.ToSQLDate(TXT_Day2.Text, DDL_Month2.SelectedValue, TXT_Year2.Text);
			recent_end_date = GlobalTools.ToSQLDate(TXT_DAY3.Text.Trim(), DDL_MONTH3.SelectedValue, TXT_YEAR3.Text.Trim());

			/*
			areaid = DDL_Region.SelectedValue;
			branchid = DDL_Branch.SelectedValue;
			*/
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
			Conn.QueryString = "select APP_ROOT from APP_PARAMETER";
			Conn.ExecuteQuery();
			string vAPP_ROOT = Conn.GetFieldValue("APP_ROOT");	

			
			/// Mengambil nilai parameter
			/// 
			Conn.QueryString = "select data_sheet,data_template,data_url,data_path, isnull(StoreProcedure, '') as StoreProcedure , isnull(StoreProcedure2, '') as StoreProcedure2 , isnull(StoreProcedure3, '') as StoreProcedure3  from RFRPTDATAANALYSIS where data_id = '" + data_id + "' and upper(REPORTTYPE) = 'R-C'";
			Conn.ExecuteQuery();

			if (Conn.GetRowCount() == 0)  
			{
				GlobalTools.popMessage(this, "Data Referensi RFRPTDATAANALYSIS (Character Analysis) kosong!");
				return;
			}

			string nota = data_id;										// nama file hasil export
			string sheet = Conn.GetFieldValue("DATA_SHEET");			// sheet di excel
			string path = vAPP_ROOT + Conn.GetFieldValue("DATA_PATH");	// directory excel hasil export			
			string file_xls = nota + ".XLT";							// nama file excel template
			string template = Conn.GetFieldValue("DATA_TEMPLATE");		// directory excel template
			string url = Conn.GetFieldValue("DATA_URL");				// url (link) untuk download
			string procedure_name = Conn.GetFieldValue ("StoreProcedure");
			string procedure_name2 = Conn.GetFieldValue ("StoreProcedure2");
			string procedure_name3 = Conn.GetFieldValue ("StoreProcedure3");



			/// Men-construct nama file
			/// 
			fileIn = template + file_xls;	// file template
			fileNm = Session["UserID"] + "-" + nota + "-DATAANALYSIS.XLS";	// file hasil export
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
			
										
			Excel.Application excelApp = null;
			Excel.Workbook excelWorkBook = null;
			Excel.Sheets excelSheet = null;

			
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
			//SupportTools.saveProcessExcel(excelApp, newId, orgId, Conn);
					
			
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
		
				if ( procedure_cnt == 0 ) {
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
				

				Conn.QueryString = "Select SEQ, DATA_COL, DATA_ROW, DATA_FIELD, [DESCRIPTION], isnull([GROUP],'0') AS [Group] from RFRPTDATAANALYSISDETAIL " + 
					" where DATA_ID = '" + nota + 
					"' and category = " + procedure_cnt.ToString() +
                    " order by SEQ";
				Conn.ExecuteQuery();
				
				dt_field = Conn.GetDataTable().Copy();			


				Conn.QueryString = " exec " + exe_procedure + " " + 
					past_start_date + "," +
					past_end_date + ", " + 
					recent_end_date + ", '" +
					nota + "', " +
					DDL_Program.SelectedValue + ", '" + 
					var_userid + "'";
				Conn.ExecuteQuery();

				/**
				if (Conn.GetRowCount() == 0) 
				{
					GlobalTools.popMessage(this, "Data dari " + procedure_name + " kosong!");
					return;
				}
		
		
				if (dt_field.Rows.Count == 0) 
				{
					GlobalTools.popMessage(this, "Data pada RFRPTDATAANALYSISDETAIL kosong!");
					return;
				}
				**/

				for(int j = 0; j < Conn.GetRowCount(); j++)
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
							//Row = Convert.ToInt32(dt_field.Rows[0]["DATA_ROW"]) ;
							Cell = Col.ToString().Trim() + Row.ToString().Trim();
							Field = dt_field.Rows[i]["DATA_FIELD"].ToString();

							objValue = Conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range) excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;
						}
						catch {}								
					}
				
				}  // end of j 
				// close the objects					
			}  // end of procedure_cnt


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
				Conn.QueryString = "exec RPT_EXPORT_DATAANALYSIS '" + 
					data_id + "', '" + 
					fileNm + "', '" + 
					var_userid + " ', '1', 'R-C'";
				Conn.ExecuteNonQuery();					
									
			}
			catch  // (Exception exp2)
			{ 
				LBL_STATUS_EXPORT.Text = "Export File gagal!";
				//LBL_STATUSEXPORT.Text = exp2.ToString();
				//return;
			}



			/// Kill process
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
				} // end of excelApp
			}
			catch (Exception exp3) 
			{
				LBL_STATUS_EXPORT.Text = "Kill Excel Process gagal!";
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
					/////////////////////////////////////////////////////////////////////
					/// Delete record from database
					/// 
					string data_id = e.Item.Cells[0].Text;
					Conn.QueryString = "exec RPT_EXPORT_DATAANALYSIS '" + data_id + "', null, '" + 
						var_userid + " ', '2', 'R-C'";
					Conn.ExecuteNonQuery();

					////
					/// Get Application Root
					/// 
					Conn.QueryString = "select top 1 app_root + data_path as filepath " + 
						" from app_parameter, rfrptdataanalysis " + 
						" where data_id = '" + data_id + "' and reporttype = 'R-C'";
					Conn.ExecuteQuery();
					string _filepath = "";
					try { _filepath = Conn.GetFieldValue("filepath"); } 
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

		protected void DDL_Program_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
			if (DDL_Program.SelectedValue == "") return;

			Conn.QueryString = "select distinct fi_approval_ver from RFPROGRAM where programid = '" + DDL_Program.SelectedValue + "'";
			Conn.ExecuteQuery();
			System.Data.DataTable dtA = new System.Data.DataTable();
			dtA = Conn.GetDataTable().Copy();

			string query;
			query = "select DATA_ID, DATA_DESC from RFRPTDATAANALYSIS where REPORTTYPE = 'r-c' and data_id in (select distinct data_id from rfrptcharfiversion where fi_approval_ver = '" + dtA.Rows[0]["fi_approval_ver"].ToString() + "')";
			Conn.QueryString = query;
			Conn.ExecuteQuery();
			this.DDL_PROGRAMRPT.Items.Clear();
			this.DDL_PROGRAMRPT.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				if (i==0)
					LBL_Score.Text	= Conn.GetFieldValue(0, "DATA_ID");
				String s0 = Conn.GetFieldValue(i, "DATA_ID"),
					s1 = Conn.GetFieldValue(i, "DATA_DESC");
				ListItem li = new ListItem(s1,s0);
				this.DDL_PROGRAMRPT.Items.Add(li);
			}

		}
	}
}
