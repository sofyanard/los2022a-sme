using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Runtime.Remoting;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Excel;
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace WebApplication1
{
	/// <summary>
	/// Summary description for RptDataAnalysis.
	/// </summary>
	public partial class RptDataAnalysis : System.Web.UI.Page
	{
		protected string ReportAddr,var_user;
		protected Connection Conn;
		protected Tools tool = new Tools();

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Conn = (Connection) Session["Connection"];
			var_user = (string)Session["UserID"];

			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], Conn))
			//Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{   
				LBL_BRANCH.Text = Posisi_User().ToString();

				viewDDL();
				isiData();								
				fillRegion();
				fillGrid();
				ViewFileExport();
			}

			initEvents();

			//tidak perlu!
			//BTN_LIHAT.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");

			BTN_EXPORT.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;}; if (!exportInProgress()) { return false; }");
		}

		/// <summary>
		/// Initialize Control Events manually
		/// </summary>
		private void initEvents() 
		{
			btn_back.Click += new ImageClickEventHandler(btn_back_Click);
			DATA_EXPORT.ItemCommand += new DataGridCommandEventHandler(DATA_EXPORT_ItemCommand);
			DATA_EXPORT.SelectedIndexChanged += new EventHandler(DATA_EXPORT_SelectedIndexChanged);
			DDL_Region.SelectedIndexChanged += new EventHandler(DDL_Region_SelectedIndexChanged);			
		}

		private void isiData()
		{
			LBL_BU.Text = Request.QueryString["BU"];

			// default value untuk filtering tanggal adalah tahun sekarang, mulai dari Januari - Desember
			TXT_Day1.Text = "1";
			DDL_Month1.SelectedValue = "1";
			TXT_Year1.Text = DateTime.Today.Year.ToString();

			TXT_Day2.Text = "31";
			DDL_Month2.SelectedValue = "12";
			TXT_Year2.Text = DateTime.Today.Year.ToString();
		}

		private void viewDDL()
		{
			DDL_Month1.Items.Add(new ListItem("-- PILIH --",""));
			DDL_Month2.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 1; i <= 12; i++)
			{
				DDL_Month1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_Month2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}

			string vBU = Request.QueryString["BU"];
			if (vBU.Trim() != "" && vBU.Trim() != "&nbsp;") 
			{
				//Conn.QueryString = "select distinct PROGRAMID, PROGRAMDESC from RFPROGRAM where active = '1' and businessunit = '" + vBU + "'";
				Conn.QueryString = "exec RPT_PROGRAM '" + Session["AreaID"] + "', '" + vBU + "'";
			}
			else 
			{
				//Conn.QueryString = "select distinct PROGRAMID, PROGRAMDESC from RFPROGRAM where active = '1' and businessunit <> 'CB100' ";
				Conn.QueryString = "exec RPT_PROGRAM '" + Session["AreaID"] + "', NULL";
			}

			Conn.ExecuteQuery();
			this.DDL_Program.Items.Clear();
			this.DDL_Program.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				if (i==0)
					LBL_Score.Text	= Conn.GetFieldValue(0,"PROGRAMID");
				String s0 = Conn.GetFieldValue(i,"PROGRAMID"),
					s1 = Conn.GetFieldValue(i,"PROGRAMDESC");
				ListItem li = new ListItem(s1,s0);
				this.DDL_Program.Items.Add(li);
			}


			Conn.QueryString = "select DATA_ID, DATA_DESC from RFRPTDATAANALYSIS where REPORTTYPE = 'DATAANALYSIS'";
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

		private void fillGrid()
		{
			System.Data.DataTable dt = new System.Data.DataTable();
			Conn.QueryString = "select * from DATAANALYSIS_EXPORT where upper(REPORTTYPE) = 'DATAANALYSIS' and userid = '" + Session["UserID"].ToString() + "'";
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

		private void clearMessage()
		{
			LBL_STATUSEXPORT.Text="";
			LBL_STATUS_EXPORT.Text="";
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

					if (var_user.ToString().Trim() != DATA_EXPORT.Items[i-1].Cells[4].Text.Trim())
						HpDelete.Visible = false;
				}
			}
			else
			{
				fillGrid();
			}
		}

		private void fillRegion()
		{
			DDL_Region.Items.Clear();
			switch(LBL_BRANCH.Text)
			{
				case "1": case "2":
					Conn.QueryString = "select AreaID, AREANAME from rfarea where AreaID='" + Session["AreaID"].ToString() + "' ";
					break;

				case "3": 
					Conn.QueryString = "select AreaID, AREANAME from rfarea where arearegmanager='" + Session["UserID"].ToString() + "' ";
					break;

				default:
					Conn.QueryString = "select AreaID, AREANAME from rfarea";
					DDL_Region.Items.Add(new ListItem("-- PILIH --",""));
					break;
			}
			Conn.ExecuteQuery();

			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_Region.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}
			fillBranch();
		}

		private void fillBranch()
		{
			DDL_Branch.Items.Clear();
			switch(LBL_BRANCH.Text)
			{
				case "1": 
					Conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where areaid='" +
						DDL_Region.SelectedValue + "' and Branch_Code='" + Session["BranchID"].ToString() + "' ";
					break;

				default:
					Conn.QueryString =  "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where areaid='" + 
						DDL_Region.SelectedValue + "' ";
					DDL_Branch.Items.Add(new ListItem("-- PILIH --",""));
					break;
			}
			if(DDL_Region.SelectedValue != "")
			{
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					DDL_Branch.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
			}
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
				Conn.QueryString = "select * from rfarea where arearegmanager='" + Session["UserID"].ToString() + "' ";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
					area="yup";
				else
					area="nop";

				if (area=="yup")
				{
					Posisi=3;
				}//aa
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

		private void DDL_Region_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillBranch();
		}

		private void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportCR.aspx?mc=" + Request.QueryString["mc"] + "&BU=" + LBL_BU.Text);
		}

		protected void BTN_EXPORT_Click(object sender, System.EventArgs e)
		{
			string start_date;
			string end_date;
			System.Data.DataTable dt_field = null;
			string areaid=null;
			string branchid=null;
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
			//int m_Row = 0;

			LBL_STATUS_EXPORT.Text = "";
			LBL_STATUSEXPORT.Text = "";

			/// defaul date adalah tahun ini
			/// 
			start_date = GlobalTools.ToSQLDate("1", "1", DateTime.Today.Year.ToString());
			end_date = GlobalTools.ToSQLDate("31", "12", DateTime.Today.Year.ToString());
			

			/// Validasi masukan tanggal awal
			/// 
			if (!GlobalTools.isDateValid(TXT_Day1.Text, DDL_Month1.SelectedValue, TXT_Year1.Text)) 
			{
				GlobalTools.popMessage(this, "Application Booking Date tidak valid!");
				return;
			}


			/// Validasi masukan tanggal akhir
			/// 
			if (!GlobalTools.isDateValid(TXT_Day2.Text, DDL_Month2.SelectedValue, TXT_Year2.Text)) 
			{
				GlobalTools.popMessage(this, "Application Booking Date tidak valid!");
				return;
			}

			start_date = GlobalTools.ToSQLDate(TXT_Day1.Text, DDL_Month1.SelectedValue, TXT_Year1.Text);			
			end_date = GlobalTools.ToSQLDate(TXT_Day2.Text, DDL_Month2.SelectedValue, TXT_Year2.Text);

			areaid = DDL_Region.SelectedValue;
			branchid = DDL_Branch.SelectedValue;
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
			Conn.QueryString = " select * from RFRPTDATAANALYSIS where data_id = '" + data_id + "'";
			Conn.ExecuteQuery();

			if (Conn.GetRowCount() == 0)  
			{
				GlobalTools.popMessage(this, "Data Referensi RFRPTDATAANALYSIS kosong!");
				return;
			}

			string nota = data_id;										// nama file hasil export
			string sheet = Conn.GetFieldValue("DATA_SHEET");			// sheet di excel
			string path = vAPP_ROOT + Conn.GetFieldValue("DATA_PATH");	// directory excel hasil export			
			string file_xls = nota + ".XLT";							// nama file excel template
			string template = Conn.GetFieldValue("DATA_TEMPLATE");		// directory excel template
			string url = Conn.GetFieldValue("DATA_URL");				// url (link) untuk download
			string procedure_name = Conn.GetFieldValue ("StoreProcedure");

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
			Conn.QueryString = "Select SEQ, DATA_COL, DATA_ROW, DATA_FIELD, [DESCRIPTION] from RFRPTDATAANALYSISDETAIL where DATA_ID = '" + nota + "' order by SEQ";
			Conn.ExecuteQuery();
				
			dt_field = Conn.GetDataTable().Copy();			
										
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

			Conn.QueryString = " exec " + procedure_name + " " + 
				start_date + "," +
				end_date + ", " + 
				GlobalTools.ConvertNull(areaid) + ", " + 
				GlobalTools.ConvertNull(branchid) + ", " +
				DDL_Program.SelectedValue;
			Conn.ExecuteQuery();

			/*
			if (Conn.GetRowCount() == 0) 
			{
				GlobalTools.popMessage(this, "Data dari " + procedure_name + "kosong!");
				return;
			}
			*/

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


			//if (Conn.GetRowCount() > 0) 
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
				Conn.QueryString = "exec RPT_EXPORT_DATAANALYSIS '" + 
					data_id + "', '" + 
					fileNm + "', '" + 
					var_user + " ', '1', 'DATAANALYSIS'";
				Conn.ExecuteNonQuery();													
			}
			catch (Exception exp2) 
			{ 
				LBL_STATUS_EXPORT.Text = "Export File gagal!";
				LBL_STATUSEXPORT.Text = exp2.ToString();					
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
				LBL_STATUS_EXPORT.Text = "Export File gagal!";
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
					///////////////////////////////////////////////////////////////////
					/// Delete record from database
					/// 
					string data_id = e.Item.Cells[0].Text;
					Conn.QueryString = "exec RPT_EXPORT_DATAANALYSIS '" + data_id + "', null, '" + 
						var_user + " ', '2', 'DATAANALYSIS'";
					Conn.ExecuteNonQuery();

					////
					/// Get Application Root
					/// 
					Conn.QueryString = "select top 1 app_root + data_path as filepath " + 
						" from app_parameter, rfrptdataanalysis " + 
						" where data_id = '" + data_id + "' and reporttype = 'DATAANALYSIS'";
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

		private void DATA_EXPORT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	} 	
}
