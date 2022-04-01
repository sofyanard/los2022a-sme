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
using DMS.DBConnection;
using DMS.CuBESCore;
using Microsoft.VisualBasic;

namespace SME.SourceSMEReport
{
	/// <summary>
	/// Summary description for RptExportDataOther.
	/// </summary>
	public partial class RptExportDataOther : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button BTN_LIHAT;

		protected Connection conn;
		protected Tools tool = new Tools();
		protected string var_user;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["connection"];
			var_user = (string) Session["UserID"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");
			
			if (!IsPostBack) 
			{
				isiDDL();
				isiData();
				fillRegion();
				fillGrid();
				ViewFileExport();
			}

			BTN_EXPORT.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;}; if (!exportInProgress()) { return false; }");
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

		private void isiDDL()
		{
			LBL_BU.Text = Request.QueryString["BU"];
			DDL_BLN1.Items.Add(new ListItem("-- PILIH --",""));
			DDL_BLN2.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 1; i <= 12; i++)
			{
				DDL_BLN1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}

			string vBU = Request.QueryString["BU"];
			if (vBU.Trim() != "" && vBU.Trim() != "&nbsp;") 
			{
				conn.QueryString = "select distinct PROGRAMID, PROGRAMDESC from RFPROGRAM WHERE businessunit = '" + vBU + "'";
			}
			else 
			{
				conn.QueryString = "select distinct PROGRAMID, PROGRAMDESC from RFPROGRAM ";
			}

			conn.ExecuteQuery();
			this.DDL_PROGRAM.Items.Clear();
			this.DDL_PROGRAM.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				if (i==0)
					LBL_SCORE.Text	= conn.GetFieldValue(0,"PROGRAMID");
				String s0 = conn.GetFieldValue(i,"PROGRAMID"),
					s1 = conn.GetFieldValue(i,"PROGRAMDESC");
				ListItem li = new ListItem(s1,s0);
				this.DDL_PROGRAM.Items.Add(li);
			}


			conn.QueryString = "select DATA_ID, DATA_DESC from RFRPTDATAANALYSIS where upper(REPORTTYPE) = 'GENERAL'";
			conn.ExecuteQuery();
			this.DDL_PROGRAMRPT.Items.Clear();
			this.DDL_PROGRAMRPT.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				if (i==0)
					LBL_SCORE.Text	= conn.GetFieldValue(0, "DATA_ID");
				String s0 = conn.GetFieldValue(i, "DATA_ID"),
					s1 = conn.GetFieldValue(i, "DATA_DESC");
				ListItem li = new ListItem(s1,s0);
				this.DDL_PROGRAMRPT.Items.Add(li);
			}
		}

		private void isiData()
		{
			TXT_TGL1.Text=DateAndTime.Today.Day.ToString();
			DDL_BLN1.SelectedValue=DateAndTime.Today.Month.ToString();
			TXT_THN1.Text=DateAndTime.Today.Year.ToString();
			TXT_TGL2.Text=DateAndTime.Today.Day.ToString();
			DDL_BLN2.SelectedValue=DateAndTime.Today.Month.ToString();
			TXT_THN2.Text=DateAndTime.Today.Year.ToString();


			LBL_RM.Text = "'0002','0004'";
			conn.QueryString = "select rmcode from app_parameter ";
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
			{
				LBL_RM.Text = conn.GetFieldValue(0,0);
			}

			Label1.Text = Posisi_User().ToString();
		}

		private void fillRegion()
		{
			DDL_REGION.Items.Clear();
			switch(Label1.Text)
			{
				case "1": case "2": case "3":
					conn.QueryString = "select AreaID, AREANAME from rfarea where AreaID='" + Session["AreaID"].ToString() + "' ";
					break;
					/*
				case "3": 
					conn.QueryString = "select AreaID, AREANAME from rfarea where arearegmanager='" + Session["UserID"].ToString() + "' ";
					break;
					*/
				default:
					conn.QueryString = "select AreaID, AREANAME from rfarea";
					DDL_REGION.Items.Add(new ListItem("-- PILIH --",""));
					break;
			}
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_REGION.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
			fillCBC();
		}

		private void fillCBC()
		{
			DDL_CBC.Items.Clear();
			switch(Label1.Text)
			{
				case "1": 
					/*
					conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_code <>'' and b.areaid = '" + DDL_REGION.SelectedValue + "' "+
						"and b.Branch_CODE='" + Session["BranchID"].ToString() + "' ";
						*/
					conn.QueryString = "select cbc.branch_code as cbc_code, cbc.branch_name as branch_name  from rfbranch b " +
						" left join rfbranch cbc on cbc.branch_code = b.cbc_code " +
						" where b.Branch_CODE='" + Session["BranchID"].ToString() + "' ";

					break;

				case "2":
					/* 
					conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_code <>'' and b.areaid = '" + DDL_REGION.SelectedValue + "' "+
						"and b.CBC_code='" + Session["CBC"].ToString() + "' ";
						*/
					conn.QueryString = "select branch_code as cbc_code, branch_name as branch_name  from rfbranch  " +
						" where branch_code = cbc_code and CBC_code='" + Session["CBC"].ToString() + "' ";
					break;

				case "3":
					conn.QueryString = "select branch_code as cbc_code, branch_name as branch_name  from rfbranch  " +
						" where branch_code = cbc_code and areaid  ='" + Session["AreaID"].ToString() + "' ";
					break;
					/*case "3": 
						conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
							"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and c.areaid = '" + DDL_REGION.SelectedValue + "' "+
							"and b.AreaID='" + Session["AreaID"].ToString() + "' ";
						DDL_CBC.Items.Add(new ListItem("-- PILIH --",""));
						break;*/

				default:
					conn.QueryString = "select branch_code as cbc_code, branch_name as branch_name  from rfbranch  " +
						" where branch_code = cbc_code and areaid ='" +  DDL_REGION.SelectedValue  + "' ";
					/*conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_code <>'' and b.areaid = '" + DDL_REGION.SelectedValue + "' ";
						*/
					DDL_CBC.Items.Add(new ListItem("-- PILIH --",""));
					break;
			}

			if(DDL_REGION.SelectedValue != "")
			{
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_CBC.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
				}
			}
			fillBranch();
		}

		private void fillBranch()
		{
			DDL_BRANCH.Items.Clear();
			switch(Label1.Text)
			{
				case "1": 
					conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cbc_code='" +
						DDL_CBC.SelectedValue + "' and Branch_Code='" + Session["BranchID"].ToString() + "' ";
					break;
					/*case "2":
						conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cbc_code='" + 
							DDL_CBC.SelectedValue + "' and CBC_Code='" + Session["CBC"].ToString() + "' ";
						DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));
						break;
					case "3": 
						conn.QueryString =  "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cbc_code='" +
							DDL_CBC.SelectedValue + "' ";//and areaid='" + Session["AreaID"].ToString() + "' ";
						DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));
						break;*/
				default:
					conn.QueryString =  "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cbc_code='" + 
						DDL_CBC.SelectedValue + "'";
					DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));
					break;
			}
			if(DDL_CBC.SelectedValue != "")
			{
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_BRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
				}
			}
			fillTeamLeader();
			//fillRM();
		}

		private void fillTeamLeader()
		{
			DDL_TEAM.Items.Clear();
			conn.QueryString = "select distinct a.su_teamleader, b.su_fullname "+
				"from scuser A left join scuser B on b.userid = a.su_teamleader "+
				"where a.su_teamleader is not null and A.su_branch='" + DDL_BRANCH.SelectedValue + "' ";
			DDL_TEAM.Items.Add(new ListItem("-- PILIH --",""));
			if(DDL_BRANCH.SelectedValue != "")
			{
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_TEAM.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
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
				// Area Manager ....
				//conn.QueryString = "select * from rfarea where arearegmanager='" + Session["UserID"].ToString() + "' ";
				conn.QueryString = "select * from scuser where userid ='" + Session["UserID"].ToString() + "' " +
					"and groupid in ( select groupid from scgroup_init2 where GR_KEY = 'AREA_MGR')";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
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

		private void fillRM()
		{
			DDL_RM.Items.Clear();
			conn.QueryString = "select userid, su_fullname from scuser "+
				"left join rfbranch on scuser.su_branch=rfbranch.branch_code "+
				"where groupid in (" + LBL_RM.Text + ") and areaid='" + DDL_REGION.SelectedValue +
				"' and scuser.su_branch='" + DDL_BRANCH.SelectedValue + "' ";
			DDL_RM.Items.Add(new ListItem("-- PILIH --",""));
			if(DDL_BRANCH.SelectedValue != "")
			{
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_RM.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
				}
			}
		}

		private void fillGrid()
		{
			System.Data.DataTable dt = new System.Data.DataTable();

			//ahmad: nanti diisi
			conn.QueryString = "select * from DATAANALYSIS_EXPORT where upper(REPORTTYPE) = 'GENERAL' and userid = '" + Session["UserID"].ToString() + "'";
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

		private void ViewFileExport()
		{
			conn.QueryString = "select top 1 DATA_URL from RFRPTDATAANALYSIS where upper(REPORTTYPE) = 'GENERAL'";
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

		protected void BTN_EXPORT_Click(object sender, System.EventArgs e)
		{
			System.Data.DataTable dt_field = null;

			string start_date;
			string end_date;
			string areaid = "";
			string branchid = "";
			string CBCid = "";
			string teamid = "";
			string rmid = "";
			string buid = "";
			string programid = "";

			string data_id = null;
			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			object objValue = null;
			object objType = Type.Missing;		
			string mStatus = string.Empty;
			string business_unit = 

			/// defaul date adalah tahun ini
			/// 
			start_date = GlobalTools.ToSQLDate("1", "1", DateTime.Today.Year.ToString());
			end_date = GlobalTools.ToSQLDate("31", "12", DateTime.Today.Year.ToString());
			

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

			areaid = DDL_REGION.SelectedIndex == 0 ? "" : DDL_REGION.SelectedValue;
			branchid = DDL_BRANCH.SelectedIndex == 0 ? "" : DDL_BRANCH.SelectedValue;
			CBCid = DDL_CBC.SelectedIndex == 0 ? "" : DDL_CBC.SelectedValue;
			teamid = DDL_TEAM.SelectedIndex == 0 ? "" : DDL_TEAM.SelectedValue;
            rmid = DDL_RM.SelectedIndex == 0 ? "" : DDL_RM.SelectedValue;
			programid = DDL_PROGRAM.SelectedIndex == 0 ? "" : DDL_PROGRAM.SelectedValue;
			buid = Request.QueryString["bu"];

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
			fileNm = Session["UserID"] + "-" + nota + "-GENERALEXPORT.XLS";	// file hasil export
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
					end_date + "," + 
					tool.ConvertNull(areaid)  + "," + 
					tool.ConvertNull(CBCid) + "," +
					tool.ConvertNull(branchid) + "," +
					tool.ConvertNull(teamid) + "," +
					tool.ConvertNull(rmid) + "," + 
					tool.ConvertNull(buid) + "," +
					tool.ConvertNull(programid) + "";
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
			} // end of running store procedure


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
							var_user + " ', '1', 'GENERAL'";
						conn.ExecuteNonQuery();													
					}
					catch (Exception exp2) 
					{ 
						LBL_STATUS_EXPORT.Text = "Export File gagal!";
						LBL_STATUSEXPORT.Text = exp2.ToString();

						//break;	// instead of return, use break, so the process can be killed ...
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

			try {
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

		protected void DDL_REGION_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillCBC();
		}

		protected void DDL_CBC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillBranch();
		}

		protected void DDL_BRANCH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillTeamLeader();
			fillRM();
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (e.CommandName.ToString()) 
			{
				case "delete":
					string data_id = e.Item.Cells[0].Text;
					//conn.QueryString = "delete DATAANALYSIS_EXPORT where data_id = '"+ data_id +"' and upper(REPORTTYPE) = 'GENERAL'";
					//ahmad
					conn.QueryString = "exec RPT_EXPORT_DATAANALYSIS '" + data_id + "', null, '" + 
						var_user + " ', '2', 'GENERAL'";
					conn.ExecuteNonQuery();

					////
					/// Get Application Root
					/// 
					conn.QueryString = "select top 1 app_root + data_path as filepath " + 
						" from app_parameter, rfrptdataanalysis " + 
						" where data_id = '" + data_id + "' and reporttype = 'GENERAL'";
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

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/SourceSMEReport/MainReportSLA.aspx?mc="+Request.QueryString["mc"]);
			//Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["mc"], conn););
			//ahmad
		}

		protected void DDL_PROGRAM_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (DDL_PROGRAM.SelectedIndex != 0)
			{
				conn.QueryString = " exec Rpt_Extract_Valid_Report " + DDL_PROGRAM.SelectedValue.ToString().Trim() + ",'GENERAL'";
				conn.ExecuteQuery();
 
				this.DDL_PROGRAMRPT.Items.Clear();
				this.DDL_PROGRAMRPT.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					if (i==0)
						LBL_SCORE.Text	= conn.GetFieldValue(0, "DATA_ID");
					String s0 = conn.GetFieldValue(i, "DATA_ID"),
						s1 = conn.GetFieldValue(i, "DATA_DESC");
					ListItem li = new ListItem(s1,s0);
					this.DDL_PROGRAMRPT.Items.Add(li);
				}
			}
		}
	}
}
