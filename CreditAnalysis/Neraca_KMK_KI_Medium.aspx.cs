using System;
using System.IO;
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
using Excel;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SME.CreditAnalysis
{
	/// <summary>
	/// Summary description for Neraca_KMK_KI_Medium.
	/// </summary>
	public partial class Neraca_KMK_KI_Medium_new : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.TextBox Textbox10;
		protected System.Web.UI.WebControls.TextBox Textbox23;
		protected System.Web.UI.WebControls.TextBox Textbox24;
		protected System.Web.UI.WebControls.TextBox Textbox25;
		protected System.Web.UI.WebControls.TextBox TXT_A_THNKENPLUS1_42;
		protected System.Web.UI.WebControls.TextBox TXT_A_THNKENPLUS2_42;
		protected System.Web.UI.WebControls.TextBox TXT_B;
        protected System.Web.UI.WebControls.Label Label2;
		protected Connection conn;
        private SMEExportImport.WordClient client;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
            client = new SMEExportImport.WordClient();
			
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (Request.QueryString["viewmode"] == "1")
			{
				//DG_NeracaHistory.Columns[5].Visible = false;
				DG_Neraca1.Columns[8].Visible = false;
				BTN_SAVE.Visible = false;
			}

			if(!IsPostBack)
			{
				viewdata();
				viewdata_history();		
				isi_initial();
				retrieve_data();
			}

			ViewMenu();
			ViewSubMenu();
			viewGridExcel();
			
			BTN_CEK.Attributes.Add("onclick","if(!cek_curr_denom()){return false;};");
			BTN_UPLOAD.Attributes.Add("onclick","if(!uploadInProgress()){return false;};");
			
			BTN_SAVE.Attributes.Add("onclick","if(!cek_key_middle('neraca')){return false;} " +
				"else HitungNeracaMiddle(1,'B'),HitungNeracaMiddle(1,'C'),HitungNeracaMiddle(1,'D'),HitungNeracaMiddle(1,'E')," +
                "HitungNeracaMiddle(2,'B'),HitungNeracaMiddle(2,'C'),HitungNeracaMiddle(2,'D'),HitungNeracaMiddle(2,'E')," +
                "HitungNeracaMiddle(3,'B'),HitungNeracaMiddle(3,'C'),HitungNeracaMiddle(3,'D'),HitungNeracaMiddle(3,'E')," +
                "HitungNeracaMiddle(4,'B'),HitungNeracaMiddle(4,'C'),HitungNeracaMiddle(4,'D'),HitungNeracaMiddle(4,'E')," +
                "HitungNeracaMiddle(5,'B'),HitungNeracaMiddle(5,'C'),HitungNeracaMiddle(5,'D'),HitungNeracaMiddle(5,'E')," +
                "HitungNeracaMiddle(6,'B'),HitungNeracaMiddle(6,'C'),HitungNeracaMiddle(6,'D'),HitungNeracaMiddle(6,'E')," +
                "HitungNeracaMiddle(7,'B'),HitungNeracaMiddle(7,'C'),HitungNeracaMiddle(7,'D'),HitungNeracaMiddle(7,'E')," +
                "HitungNeracaMiddle(8,'B'),HitungNeracaMiddle(8,'C'),HitungNeracaMiddle(8,'D'),HitungNeracaMiddle(8,'E')," +
                "FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'));");
			
			//BTN_PROSES.Attributes.Add("onclick","if(!validasi('TXT_B18','TXT_B35','TXT_C18','TXT_C35','TXT_D18','TXT_D35','TXT_E18','TXT_E35')){return false;};if(!cek_key_middle('neraca')){return false;};");

			ViewFileUpload();
			readonly_teksbox();
		}
		
		private void isi_initial()
		{
			conn.QueryString = "select bs_currency,bs_denominator from ca_neraca_middle where cu_ref = '" + Request.QueryString["curef"] + "' and ap_regno = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			if (conn.GetRowCount() <= 0)
			{
				GlobalTools.fillRefList(DDL_CURRENCY,"select currencyid,currencydesc from rfcurrency where active ='1'",true,conn);
				DDL_CURRENCY.SelectedValue = "IDR";
				DDL_DENOMINATOR.SelectedValue = "000";
				DDL_CURRENCY.Enabled = true;
				DDL_DENOMINATOR.Enabled = true;
				BTN_CEK.Enabled = true;
			}
			else
			{
				GlobalTools.fillRefList(DDL_CURRENCY,"select currencyid,currencydesc from rfcurrency where active ='1'",true,conn);
				try { DDL_CURRENCY.SelectedValue = dt.Rows[0]["bs_currency"].ToString(); }
				catch { DDL_CURRENCY.SelectedValue = "IDR"; }
				DDL_CURRENCY.Enabled = false;
				try { DDL_DENOMINATOR.SelectedValue = dt.Rows[0]["bs_denominator"].ToString(); }
				catch { DDL_DENOMINATOR.SelectedValue = "000"; }
				DDL_DENOMINATOR.Enabled = false;
				BTN_CEK.Enabled = false;
				PnlNeraca.Visible = true;
			}

			//----------------------------------------------
			//added by nyoman for current scoring condition 
			conn.QueryString = "select FI_APPROVAL_VER from  VW_CA_NERACA_MIDDLE_FI_APPROVAL_VER " +
				"where AP_REGNO = '" + Request.QueryString["regno"] + "' ";
			conn.ExecuteQuery();
			try
			{
				if (conn.GetFieldValue(0,0) == "2")
				{
					DDL_CURRENCY.SelectedValue = "IDR";
					DDL_DENOMINATOR.SelectedValue = "000";
					DDL_CURRENCY.Enabled = false;
					DDL_DENOMINATOR.Enabled = false;
					BTN_CEK.Enabled = false;
					PnlNeraca.Visible = true;
				}
			}
			catch {}
			//----------------------------------------------
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select SM_ID,MENUCODE,SM_MENUDISPLAY,SM_LINKNAME from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
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
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						else	strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
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
		
	
		private void ViewSubMenu()
		{
			try 
			{
				string sProgramID,sJnsNasabah;

				conn.QueryString = "select distinct top 1 cu_jnsnasabah from customer where cu_ref in (Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+ "')";
				conn.ExecuteQuery();
				sJnsNasabah = conn.GetFieldValue("cu_jnsnasabah").ToString();
				//------------------------------------------------------------------------------
					
				conn.QueryString = "select distinct top 1 programid from rfprogram where programid in (select prog_code from application where ap_regno = '"+Request.QueryString["regno"]+ "')";
				conn.ExecuteQuery();
				sProgramID = conn.GetFieldValue("programid").ToString();

				//conn.QueryString = "select * from screensubmenu where lg_code in (select distinct lg_code from rfcafinstatement where programid = '"+Request.QueryString["programid"]+"' and nasabahid = '" +Request.QueryString["jnsnasabah"]+"') and menucode = '" +Request.QueryString["mc"]+ "' and programid = '"+Request.QueryString["programid"]+"'";

				conn.QueryString = "select MENUCODE,BUSSUNITID,PROGRAMID,PROGRAMID_SEQ,SM_MENUDISPLAY,SM_LINKNAME,LG_CODE from screensubmenu where lg_code in (select distinct lg_code from rfcafinstatement where programid = '" + sProgramID + "' and nasabahid = '" + sJnsNasabah + "') and menucode = '" + Request.QueryString["mc"]+ "' and programid = '" + sProgramID + "'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 4);
					string strtemp = "";
					strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&tc="+Request.QueryString["tc"]+"&tahun="+Request.QueryString["tahun"]+"&mode="+Request.QueryString["mode"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
					t.NavigateUrl = conn.GetFieldValue(i, 5)+strtemp;
					SubMenu.Controls.Add(t);
					SubMenu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private string myMoneyFormat_noDec(string str)
		{
			if ((str.Trim() == "") || (str.Trim() == "&nbsp;")) 
			{
				return Strings.FormatNumber(0, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
			} 
			else 
			{
				return Strings.FormatNumber(str, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
			}
		}

		/// <summary>
		/// Menghapus file hasil upload
		/// </summary>
		/// <param name="directory">directory yang menyimpan file</param>
		/// <param name="filename">nama file saja</param>
		private void deleteFile(string directory, string filename) 
		{
			if (File.Exists(directory + filename)) 
			{
				File.Delete(directory + filename);
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			base.OnInit(e);
            if (!this.DesignMode)
            {
                InitializeComponent();
            }
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.DG_NeracaHistory.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_NeracaHistory_ItemCommand);
			this.DG_Neraca1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_Neraca1_ItemCommand);
			this.DG_XLS.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_XLS_ItemCommand);
			this.DatGrid.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrid_ItemCommand);

		}
		#endregion

		private void viewdata()
		{
			conn.QueryString = "select distinct BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,year(BS_DATE_PERIODE) tahun,BS_CURRENCY,BS_DENOMINATOR from CA_NERACA_MIDDLE where ap_regno = '"+ Request.QueryString["regno"]+ "' order by BS_DATE_PERIODE desc";
			conn.ExecuteQuery();
			
			DG_Neraca1.DataSource = conn.GetDataTable().Copy();
			DG_Neraca1.DataBind();
			for(int i = 0; i < DG_Neraca1.Items.Count; i++)
			{
				DG_Neraca1.Items[i].Cells[0].Text = tool.FormatDate(DG_Neraca1.Items[i].Cells[0].Text);
			}
		}

		private void viewdata_history()
		{
			//conn.QueryString = "select POSISI_TGL,JML_BLN,JNS_LAP,year(POSISI_TGL) tahun from CA_NERACA_SMALL where ap_regno = '"+ Request.QueryString["regno"]+ "' order by POSISI_TGL desc";
			//conn.QueryString = "select AP_REGNO,BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,TAHUN " +
			//	"from VW_CA_NERACA_MIDDLE_HISTORY where cu_ref = '" + Request.QueryString["curef"] + "' " +
			//	"and ap_regno <> '"+ Request.QueryString["regno"] + "' order by AP_REGNO, BS_DATE_PERIODE desc";
			conn.QueryString = "exec CA_NERACA_MIDDLE_HISTORY '" + Request.QueryString["curef"] + "', '" +
				Request.QueryString["regno"] + "' ";
			conn.ExecuteQuery();
			
			DG_NeracaHistory.DataSource = conn.GetDataTable().Copy();
			DG_NeracaHistory.DataBind();
			for(int i = 0; i < DG_NeracaHistory.Items.Count; i++)
			{
				DG_NeracaHistory.Items[i].Cells[1].Text = tool.FormatDate(DG_NeracaHistory.Items[i].Cells[1].Text);
			}
		}


		private void viewGridExcel()
		{
			string a = "MCG-F";
			conn.QueryString = "select '1.' as cnt, xls_view, location from ca_excel_template where lg_code ='" + a + "'";
			conn.ExecuteQuery();
			DG_XLS.DataSource = conn.GetDataTable().Copy();
			DG_XLS.DataBind();
			for(int i = 0; i < DG_XLS.Items.Count; i++)
			{
				DG_XLS.Items[i].Cells[0].Text = (DG_XLS.Items[i].DataSetIndex+1).ToString()+".";
				HyperLink Hp = (HyperLink) DG_XLS.Items[i].Cells[3].FindControl("HP_DOWNLOAD");
				Hp.NavigateUrl = DG_XLS.Items[i].Cells[2].Text.Trim();
			}
		}	

		
		private void viewExcel(string dir)
		{

			//TO DO ....
			string vPath;
			
			conn.QueryString = "select xls_dir+''+fu_filename as filexls from CA_FILEUPLOADXL where fu_filename = '"+Request.QueryString["regno"]+"-"+Session["USERID"]+"-"+dir+"'";
			conn.ExecuteQuery();
			vPath = conn.GetFieldValue("filexls");

			Excel.Application excelApp = null;
			Excel.Workbook excelWorkbook = null;

			/////////////////////////////////
			ArrayList orgId = new ArrayList();
			ArrayList newId = new ArrayList();
			/////////////////////////////////

			/////////////////////////////////////////////////////////////////
			Process[] oldProcess = Process.GetProcessesByName("EXCEL");
			foreach(Process thisProcess in oldProcess) orgId.Add(thisProcess);
			////////////////////////////////////////////////////////////////

			try
			{

				System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
				System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

				excelApp = new Excel.ApplicationClass();
				excelApp.Visible = false;
				excelApp.DisplayAlerts = false;
				////////////////////////////////////////////////////////////////
				Process[] newProcess = Process.GetProcessesByName("EXCEL");
				foreach(Process thisProcess in newProcess) newId.Add(thisProcess);
				////////////////////////////////////////////////////////////////

				/// Save process into database
				/// 					
				//SupportTools.saveProcessExcel(excelApp, newId, orgId, conn);

				excelWorkbook = excelApp.Workbooks.Open(vPath,
					0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t",
					false, false, 0, true);
				Excel.Sheets excelSheets = excelWorkbook.Worksheets;
				string currentSheet = "LOS";
				Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheets.get_Item(currentSheet);
				/*--------------------- separator ---------------------------------------------------------------*/
				// loop utk date periode, number of months lihat excel !!!!!!!!!!!
				for (int i=66;i<70;i++) 
				{
					for (int j=1;j<5;j++)
					{
						string vtmp = ((char)i).ToString()+j; //i=66 diconvert ke ascci jd huruf B, di concat dgn j hasilnya B1,B2,C1,C2
						Excel.Range excelB2 = (Excel.Range)excelWorksheet.get_Range(vtmp, vtmp);
						System.Web.UI.WebControls.TextBox TXT_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_" + vtmp);
					
						System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmp);
						System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmp);
						System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmp);
					
						if (j!=1)
						{
							if (j==3)
							{
								for (int p=3;p<4;p++)
								{
									string vRg = ((char)i).ToString(); 
									System.Web.UI.WebControls.TextBox teks = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_" + vRg + p.ToString());
									System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vRg + p.ToString());
									try 
									{
										teks.Text = excelB2.Value2.ToString();
										DDL_.SelectedValue = teks.Text;
									}
									catch
									{
										teks.Text = "";
										DDL_.SelectedValue = "-";
									}
								}
							}
							else
							{
								try
								{
									TXT_.Text = excelB2.Value2.ToString();
								}
								catch
								{
									TXT_.Text = "0";
								}
							}
						}
						else 
						{
							//--------------------------------------------------------------------------------------//
							try 
							{
								DateTime excdatestr = Convert.ToDateTime(tool.FormatDate(excelB2.Text.ToString()));
								GlobalTools.fillDateForm(TXT_TGL_, DDL_BLN_, TXT_YEAR_, excdatestr);
							}
							catch
							{
								TXT_TGL_.Text = "";
								DDL_BLN_.SelectedValue = "";
								TXT_YEAR_.Text = "";
							}
							//--------------------------------------------------------------------------------------//
						}
					}
				}
				/*--------------------- separator ---------------------------------------------------------------*/
				// loop utk cash bank sampe liabilities net worth, lihat excel !!!!!!
				for (int m=66;m<70;m++)
				{
					/// Start Read Neraca
					/// 
					//for (int n=4;n<=conn.GetRowCount();n++)
					for (int n=5;n<36;n++) 
					{ 
						string vRange = ((char)m).ToString()+n; 
						Excel.Range excelCell = (Excel.Range)excelWorksheet.get_Range(vRange, vRange);
						System.Web.UI.WebControls.TextBox TXT_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_" + vRange);
						//TXT_.Text = formatMoney_ind(excelCell.Value.ToString());
						try
						{
							TXT_.Text = formatMoney_ind(excelCell.Value2.ToString());
							//TXT_.Text = GlobalTools.MoneyFormat(excelCell.Value2.ToString());
						}
						catch(Exception e)
						{
							TXT_.Text = "0";
                            string msk = e.Message;
                            string a = "";
						}
					}
				}
				/*--------------------- separator ---------------------------------------------------------------*/
			}
			catch(Exception e)
            {
                string error = e.Message;
                string a = "";
            }
			finally
			{
				excelWorkbook.Close(null,null,null);
				excelApp.Workbooks.Close();
				excelApp.Application.Quit();
				excelApp.Quit();
			
				//System.Runtime.InteropServices.Marshal.ReleaseComObject(excelSheets); 
				System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook); 
				System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp); 
				//excelSheets = null; 
				excelWorkbook = null; 
				excelApp = null;

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
                        catch
                        {
                            continue;
                        }
                    }
				}

			}
		}


		private void viewExcel_LabaRugi(string directori)
		{
			string vPath;
			//string a = "MCGF";
			
			//TODO : Jangan di hardcode !!!
			conn.QueryString = "select xls_dir+''+fu_filename as filexls from CA_FILEUPLOADXL where fu_filename = '"+Request.QueryString["regno"]+"-"+Session["USERID"]+"-"+directori+"'";
			conn.ExecuteQuery();
			vPath = conn.GetFieldValue("filexls");


			Excel.Application excelAppIS = null;
			Excel.Workbook excelWorkbookIS = null;

			/////////////////////////////////
			ArrayList orgId = new ArrayList();
			ArrayList newId = new ArrayList();
			/////////////////////////////////

			/////////////////////////////////////////////////////////////////
			Process[] oldProcess = Process.GetProcessesByName("EXCEL");
			foreach(Process thisProcess in oldProcess) orgId.Add(thisProcess);
			////////////////////////////////////////////////////////////////
			
			try 
			{
				// Set the culture and UI culture to the browser's accept language
				System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
				System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

				excelAppIS = new Excel.ApplicationClass();
				excelAppIS.Visible = false;
				excelAppIS.DisplayAlerts = false;	
				
				////////////////////////////////////////////////////////////////
				Process[] newProcess = Process.GetProcessesByName("EXCEL");
				foreach(Process thisProcess in newProcess) newId.Add(thisProcess);
				////////////////////////////////////////////////////////////////
				
				/// Save process into database
				/// 					
				//SupportTools.saveProcessExcel(excelAppIS, newId, orgId, conn);

				excelWorkbookIS = excelAppIS.Workbooks.Open(vPath,
					0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t",
					false, false, 0, true);
				Excel.Sheets excelSheets = excelWorkbookIS.Worksheets;
				string currentSheet = "LOS";
				Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheets.get_Item(currentSheet);
				/*--------------------- separator ---------------------------------------------------------------*/
				// loop utk date periode, number of months lihat excel !!!!!!!!!!!
				for (int i=66;i<70;i++) 
				{
					for (int j=37;j<41;j++)
					{
						string vtmp = ((char)i).ToString()+j; //i=66 diconvert ke ascci jd huruf B, di concat dgn j hasilnya B1,B2,C1,C2
						Excel.Range excelLBRG1 = (Excel.Range)excelWorksheet.get_Range(vtmp, vtmp);
						System.Web.UI.WebControls.TextBox TXT_LBRG_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_LBRG_" + vtmp);
						if (j==37)
						{
							try
							{
								//TXT_LBRG_.Text = excelLBRG1.Text.ToString();
								TXT_LBRG_.Text = excelLBRG1.Value2.ToString();
							}
							catch
							{
								TXT_LBRG_.Text = "";
							}
						}
						else 
						{
							try
							{
								TXT_LBRG_.Text = excelLBRG1.Value2.ToString();
							}
							catch
							{
								TXT_LBRG_.Text = "";
							}
						}
					}
				}
				/*--------------------- separator ---------------------------------------------------------------*/
				// loop utk NET SALES sampe   % OF SALES, lihat excel !!!!!!
				for (int m=66;m<70;m++)
				{
					//for (int n=4;n<=conn.GetRowCount();n++) 
					for (int n=41;n<62;n++) 
					{
                        int a = n;
						string vRange = ((char)m).ToString()+n; 
						Excel.Range excelLBRG2 = (Excel.Range)excelWorksheet.get_Range(vRange, vRange);
						System.Web.UI.WebControls.TextBox TXT_LBRG_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_LBRG_" + vRange);
						try
						{
							TXT_LBRG_.Text = formatMoney_ind(excelLBRG2.Value2.ToString());
							//TXT_LBRG_.Text = GlobalTools.MoneyFormat(excelLBRG2.Value2.ToString());
						}
						catch(Exception e)
						{
							TXT_LBRG_.Text = "0";
                            string msg = e.Message;
                            string ask = "";
						}
					}
				}
				/*--------------------- separator ---------------------------------------------------------------*/
			}
			catch(Exception e) 
            {
                string mess = e.Message;
                string a = "";
            }
			finally 
			{
                try
                {
                    excelWorkbookIS.Close(null, null, null);
                }
                catch(Exception e)
                {
                    string mesg = e.Message;
                    string a = "";
                }

                try
                {
                    excelAppIS.Workbooks.Close();
                }
                catch (Exception e)
                {
                    string mesg = e.Message;
                    string a = "";
                }

                try
                {
				    excelAppIS.Application.Quit();
                }
                catch (Exception e)
                {
                    string mesg = e.Message;
                    string a = "";
                }

                try
                {
				    excelAppIS.Quit();
                }
                catch (Exception e)
                {
                    string mesg = e.Message;
                    string a = "";
                }
			
				//System.Runtime.InteropServices.Marshal.ReleaseComObject(excelSheets); 
				System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbookIS); 
				System.Runtime.InteropServices.Marshal.ReleaseComObject(excelAppIS); 
				//excelSheets = null; 
				excelWorkbookIS = null; 
				excelAppIS = null; 

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
                        catch
                        {
                            continue;
                        }
                    }
				}
			}
			
	
		}

		private bool cek_tanggal()
		{
			if (TXT_TGL_B1.Text != "" && DDL_BLN_B1.SelectedIndex > 0 && TXT_YEAR_B1.Text != "")
				if(!GlobalTools.isDateValid(this,TXT_TGL_B1.Text,DDL_BLN_B1.SelectedValue,TXT_YEAR_B1.Text))
					return false;
			
			if (TXT_TGL_C1.Text != "" && DDL_BLN_C1.SelectedIndex > 0 && TXT_YEAR_C1.Text != "")
				if(!GlobalTools.isDateValid(this,TXT_TGL_C1.Text,DDL_BLN_C1.SelectedValue,TXT_YEAR_C1.Text))
					return false;

			if (TXT_TGL_D1.Text != "" && DDL_BLN_D1.SelectedIndex > 0 && TXT_YEAR_D1.Text != "")
				if(!GlobalTools.isDateValid(this,TXT_TGL_D1.Text,DDL_BLN_D1.SelectedValue,TXT_YEAR_D1.Text))
					return false;

			if (TXT_TGL_E1.Text != "" && DDL_BLN_E1.SelectedIndex > 0 && TXT_YEAR_E1.Text != "")
				if(!GlobalTools.isDateValid(this,TXT_TGL_E1.Text,DDL_BLN_E1.SelectedValue,TXT_YEAR_E1.Text))
					return false;
			return true;
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if (!cek_tanggal())
				return;
			if (LBL_SUMBERDATA.Text == "excel")
			{
				save_neraca();
				save_labarugi();
			}
			else
			{	save_neraca(); }

			string tahun = LBL_H_TAHUN.Text ;
			if (tahun == "")
			{
				
				tahun = (TXT_YEAR_E1.Text != "" ? TXT_YEAR_E1.Text : 
					TXT_YEAR_D1.Text != "" ? TXT_YEAR_D1.Text : 
					TXT_YEAR_C1.Text != "" ? TXT_YEAR_C1.Text : 
					TXT_YEAR_B1.Text != "" ? TXT_YEAR_B1.Text : "");

				
			}

			if ( Request.QueryString["tahun"] != "" && Request.QueryString["tahun"] != null ) 
			{
				Response.Write("<!-- tahun nggak kososng -->");
				CLS_CALCULATION.proses_calculate(this, Request.QueryString["regno"], Request.QueryString["curef"],Request.QueryString["tahun"], conn);
			}
			else
			{
				CLS_CALCULATION.proses_calculate(this, Request.QueryString["regno"], Request.QueryString["curef"],tahun, conn);
			}
				
				


			LBL_SUMBERDATA.Text = "";
			isi_initial();
		}


		private void save_neraca()
		{
			conn.QueryString = "Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
			string a = conn.GetFieldValue("cu_ref").ToString();
			if (TXT_B2.Text != "")
			{
				conn.QueryString = "exec ca_neraca_middle_sp '" + a + "','"+ Request.QueryString["regno"]+"',"+ GlobalTools.ToSQLDate(TXT_TGL_B1.Text,DDL_BLN_B1.SelectedValue,TXT_YEAR_B1.Text) + "," + tool.ConvertNum(TXT_B2.Text) + ",'" + DDL_B3.SelectedValue + "'," + tool.ConvertFloat(TXT_B4.Text) + "," + 
					tool.ConvertFloat(TXT_B5.Text) + "," + tool.ConvertFloat(TXT_B6.Text) + ", " + tool.ConvertFloat(TXT_B7.Text) + "," + tool.ConvertFloat(TXT_B8.Text) + "," + 
					tool.ConvertFloat(TXT_B9.Text) + "," + tool.ConvertFloat(TXT_B10.Text) + ", " + tool.ConvertFloat(TXT_B11.Text) + "," + tool.ConvertFloat(TXT_B12.Text) + "," +
					tool.ConvertFloat(TXT_B13.Text) + "," + tool.ConvertFloat(TXT_B14.Text) + "," + tool.ConvertFloat(TXT_B15.Text) + "," + tool.ConvertFloat(TXT_B16.Text) + "," +
					tool.ConvertFloat(TXT_B17.Text) + "," + tool.ConvertFloat(TXT_B18.Text) + "," + tool.ConvertFloat(TXT_B19.Text) + "," + tool.ConvertFloat(TXT_B20.Text) + "," +
					tool.ConvertFloat(TXT_B21.Text) + "," + tool.ConvertFloat(TXT_B22.Text) + "," + tool.ConvertFloat(TXT_B23.Text) + "," + tool.ConvertFloat(TXT_B24.Text) + "," +
					tool.ConvertFloat(TXT_B25.Text) + "," + tool.ConvertFloat(TXT_B26.Text) + "," + tool.ConvertFloat(TXT_B27.Text) + "," + tool.ConvertFloat(TXT_B28.Text) + "," +
					tool.ConvertFloat(TXT_B29.Text) + "," + tool.ConvertFloat(TXT_B30.Text) + "," + tool.ConvertFloat(TXT_B31.Text) + "," + tool.ConvertFloat(TXT_B32.Text) + "," +
					tool.ConvertFloat(TXT_B33.Text) + "," + tool.ConvertFloat(TXT_B34.Text) + "," + tool.ConvertFloat(TXT_B35.Text) + ",'" + DDL_CURRENCY.SelectedValue + "','" + DDL_DENOMINATOR.SelectedValue + "','" + LBL_SUMBERDATA.Text + "',''";			
				conn.ExecuteNonQuery();
			}
				
			if (TXT_C2.Text!="")
			{
				conn.QueryString = "exec ca_neraca_middle_sp '" + a + "','"+ Request.QueryString["regno"]+"',"+ GlobalTools.ToSQLDate(TXT_TGL_C1.Text,DDL_BLN_C1.SelectedValue,TXT_YEAR_C1.Text) + "," + tool.ConvertNum(TXT_C2.Text) + ",'" + DDL_C3.SelectedValue + "'," + tool.ConvertFloat(TXT_C4.Text) + "," + 
					tool.ConvertFloat(TXT_C5.Text) + "," + tool.ConvertFloat(TXT_C6.Text) + ", " + tool.ConvertFloat(TXT_C7.Text) + "," + tool.ConvertFloat(TXT_C8.Text) + "," + 
					tool.ConvertFloat(TXT_C9.Text) + "," + tool.ConvertFloat(TXT_C10.Text) + ", " + tool.ConvertFloat(TXT_C11.Text) + "," + tool.ConvertFloat(TXT_C12.Text) + "," +
					tool.ConvertFloat(TXT_C13.Text) + "," + tool.ConvertFloat(TXT_C14.Text) + "," + tool.ConvertFloat(TXT_C15.Text) + "," + tool.ConvertFloat(TXT_C16.Text) + "," +
					tool.ConvertFloat(TXT_C17.Text) + "," + tool.ConvertFloat(TXT_C18.Text) + "," + tool.ConvertFloat(TXT_C19.Text) + "," + tool.ConvertFloat(TXT_C20.Text) + "," +
					tool.ConvertFloat(TXT_C21.Text) + "," + tool.ConvertFloat(TXT_C22.Text) + "," + tool.ConvertFloat(TXT_C23.Text) + "," + tool.ConvertFloat(TXT_C24.Text) + "," +
					tool.ConvertFloat(TXT_C25.Text) + "," + tool.ConvertFloat(TXT_C26.Text) + "," + tool.ConvertFloat(TXT_C27.Text) + "," + tool.ConvertFloat(TXT_C28.Text) + "," +
					tool.ConvertFloat(TXT_C29.Text) + "," + tool.ConvertFloat(TXT_C30.Text) + "," + tool.ConvertFloat(TXT_C31.Text) + "," + tool.ConvertFloat(TXT_C32.Text) + "," +
					tool.ConvertFloat(TXT_C33.Text) + "," + tool.ConvertFloat(TXT_C34.Text) + "," + tool.ConvertFloat(TXT_C35.Text) + ",'" + DDL_CURRENCY.SelectedValue + "','" + DDL_DENOMINATOR.SelectedValue + "','" + LBL_SUMBERDATA.Text + "',''";			
				conn.ExecuteNonQuery();
			}
				
			if (TXT_D2.Text != "")
			{
				conn.QueryString = "exec ca_neraca_middle_sp '" + a + "','"+ Request.QueryString["regno"]+"',"+ GlobalTools.ToSQLDate(TXT_TGL_D1.Text,DDL_BLN_D1.SelectedValue,TXT_YEAR_D1.Text) + "," + tool.ConvertNum(TXT_D2.Text) + ",'" + DDL_D3.SelectedValue + "'," + tool.ConvertFloat(TXT_D4.Text) + "," + 
					tool.ConvertFloat(TXT_D5.Text) + "," + tool.ConvertFloat(TXT_D6.Text) + ", " + tool.ConvertFloat(TXT_D7.Text) + "," + tool.ConvertFloat(TXT_D8.Text) + "," + 
					tool.ConvertFloat(TXT_D9.Text) + "," + tool.ConvertFloat(TXT_D10.Text) + ", " + tool.ConvertFloat(TXT_D11.Text) + "," + tool.ConvertFloat(TXT_D12.Text) + "," +
					tool.ConvertFloat(TXT_D13.Text) + "," + tool.ConvertFloat(TXT_D14.Text) + "," + tool.ConvertFloat(TXT_D15.Text) + "," + tool.ConvertFloat(TXT_D16.Text) + "," +
					tool.ConvertFloat(TXT_D17.Text) + "," + tool.ConvertFloat(TXT_D18.Text) + "," + tool.ConvertFloat(TXT_D19.Text) + "," + tool.ConvertFloat(TXT_D20.Text) + "," +
					tool.ConvertFloat(TXT_D21.Text) + "," + tool.ConvertFloat(TXT_D22.Text) + "," + tool.ConvertFloat(TXT_D23.Text) + "," + tool.ConvertFloat(TXT_D24.Text) + "," +
					tool.ConvertFloat(TXT_D25.Text) + "," + tool.ConvertFloat(TXT_D26.Text) + "," + tool.ConvertFloat(TXT_D27.Text) + "," + tool.ConvertFloat(TXT_D28.Text) + "," +
					tool.ConvertFloat(TXT_D29.Text) + "," + tool.ConvertFloat(TXT_D30.Text) + "," + tool.ConvertFloat(TXT_D31.Text) + "," + tool.ConvertFloat(TXT_D32.Text) + "," +
					tool.ConvertFloat(TXT_D33.Text) + "," + tool.ConvertFloat(TXT_D34.Text) + "," + tool.ConvertFloat(TXT_D35.Text) + ",'" + DDL_CURRENCY.SelectedValue + "','" + DDL_DENOMINATOR.SelectedValue + "','" + LBL_SUMBERDATA.Text + "',''";			
				conn.ExecuteNonQuery();
			}
				
			if (TXT_E2.Text != "")
			{
				string tempo = "Proyeksi";
				conn.QueryString = "exec ca_neraca_middle_sp '" + a + "','"+ Request.QueryString["regno"]+"',"+ GlobalTools.ToSQLDate(TXT_TGL_E1.Text,DDL_BLN_E1.SelectedValue,TXT_YEAR_E1.Text) + "," + tool.ConvertNum(TXT_E2.Text) + ",'" + tempo + "'," + tool.ConvertFloat(TXT_E4.Text) + "," + 
					tool.ConvertFloat(TXT_E5.Text) + "," + tool.ConvertFloat(TXT_E6.Text) + ", " + tool.ConvertFloat(TXT_E7.Text) + "," + tool.ConvertFloat(TXT_E8.Text) + "," + 
					tool.ConvertFloat(TXT_E9.Text) + "," + tool.ConvertFloat(TXT_E10.Text) + ", " + tool.ConvertFloat(TXT_E11.Text) + "," + tool.ConvertFloat(TXT_E12.Text) + "," +
					tool.ConvertFloat(TXT_E13.Text) + "," + tool.ConvertFloat(TXT_E14.Text) + "," + tool.ConvertFloat(TXT_E15.Text) + "," + tool.ConvertFloat(TXT_E16.Text) + "," +
					tool.ConvertFloat(TXT_E17.Text) + "," + tool.ConvertFloat(TXT_E18.Text) + "," + tool.ConvertFloat(TXT_E19.Text) + "," + tool.ConvertFloat(TXT_E20.Text) + "," +
					tool.ConvertFloat(TXT_E21.Text) + "," + tool.ConvertFloat(TXT_E22.Text) + "," + tool.ConvertFloat(TXT_E23.Text) + "," + tool.ConvertFloat(TXT_E24.Text) + "," +
					tool.ConvertFloat(TXT_E25.Text) + "," + tool.ConvertFloat(TXT_E26.Text) + "," + tool.ConvertFloat(TXT_E27.Text) + "," + tool.ConvertFloat(TXT_E28.Text) + "," +
					tool.ConvertFloat(TXT_E29.Text) + "," + tool.ConvertFloat(TXT_E30.Text) + "," + tool.ConvertFloat(TXT_E31.Text) + "," + tool.ConvertFloat(TXT_E32.Text) + "," +
					tool.ConvertFloat(TXT_E33.Text) + "," + tool.ConvertFloat(TXT_E34.Text) + "," + tool.ConvertFloat(TXT_E35.Text) + ",'" + DDL_CURRENCY.SelectedValue + "','" + DDL_DENOMINATOR.SelectedValue + "','" + LBL_SUMBERDATA.Text + "','1'";		
				conn.ExecuteNonQuery();
			}
			viewdata();
			
		}
		
		private void save_labarugi()
		{
			conn.QueryString = "Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
			string a = conn.GetFieldValue("cu_ref").ToString();
			//int b = 100;
			//conn.QueryString = "exec ca_labarugi_middle_sp '" + a + "','" + Request.QueryString["regno"]+ "','" + TXT_LBRG_B37.Text + "'," + TXT_LBRG_B38.Text + ",'" + TXT_LBRG_B39.Text + "'," + tool.ConvertNum(TXT_LBRG_B40.Text) + "," +
			if (TXT_B2.Text != "")
			{
				conn.QueryString = "exec ca_labarugi_middle_sp '" + a + "','"+ Request.QueryString["regno"]+"',"+ GlobalTools.ToSQLDate(TXT_TGL_B1.Text,DDL_BLN_B1.SelectedValue,TXT_YEAR_B1.Text) + "," + tool.ConvertNum(TXT_B2.Text) + ",'" + DDL_B3.SelectedValue + "'," + tool.ConvertFloat(TXT_B4.Text) + "," + 
					tool.ConvertFloat(TXT_LBRG_B41.Text) + "," + tool.ConvertFloat(TXT_LBRG_B42.Text) + "," + tool.ConvertFloat(TXT_LBRG_B43.Text) + "," + tool.ConvertFloat(TXT_LBRG_B44.Text) + "," + tool.ConvertFloat(TXT_LBRG_B45.Text) + ", " + tool.ConvertFloat(TXT_LBRG_B46.Text) + "," + tool.ConvertFloat(TXT_LBRG_B47.Text) + "," +
					tool.ConvertFloat(TXT_LBRG_B48.Text) + "," + tool.ConvertFloat(TXT_LBRG_B49.Text) + "," + tool.ConvertFloat(TXT_LBRG_B50.Text) + "," + tool.ConvertFloat(TXT_LBRG_B51.Text) + "," +
					tool.ConvertFloat(TXT_LBRG_B52.Text) + "," + tool.ConvertFloat(TXT_LBRG_B53.Text) + "," + tool.ConvertFloat(TXT_LBRG_B54.Text) + "," + tool.ConvertFloat(TXT_LBRG_B55.Text) + "," +			
					tool.ConvertFloat(TXT_LBRG_B56.Text) + "," + tool.ConvertFloat(TXT_LBRG_B57.Text) + "," + tool.ConvertFloat(TXT_LBRG_B58.Text) + "," + tool.ConvertFloat(TXT_LBRG_B59.Text) + "," +			
					tool.ConvertFloat(TXT_LBRG_B60.Text) + "," + tool.ConvertFloat(TXT_LBRG_B61.Text) + ",'" + DDL_CURRENCY.SelectedValue + "','" + DDL_DENOMINATOR.SelectedValue + "','" + LBL_SUMBERDATA.Text + "',''";
				conn.ExecuteNonQuery();
			}
			/* ---------------------- separator -------------------------------------------------*/
			if (TXT_C2.Text != "")
			{
				//conn.QueryString = "exec ca_labarugi_middle_sp '" + a + "','" + Request.QueryString["regno"]+ "','" + TXT_LBRG_C37.Text + "'," + TXT_LBRG_C38.Text + ",'" + TXT_LBRG_C39.Text + "'," + tool.ConvertNum(TXT_LBRG_C40.Text) + "," +
				conn.QueryString = "exec ca_labarugi_middle_sp '" + a + "','"+ Request.QueryString["regno"]+"',"+ GlobalTools.ToSQLDate(TXT_TGL_C1.Text,DDL_BLN_C1.SelectedValue,TXT_YEAR_C1.Text) + "," + tool.ConvertNum(TXT_C2.Text) + ",'" + DDL_C3.SelectedValue + "'," + tool.ConvertFloat(TXT_C4.Text) + "," + 
					tool.ConvertFloat(TXT_LBRG_C41.Text) + "," + tool.ConvertFloat(TXT_LBRG_C42.Text) + "," + tool.ConvertFloat(TXT_LBRG_C43.Text) + "," + 
					tool.ConvertFloat(TXT_LBRG_C44.Text) + "," + tool.ConvertFloat(TXT_LBRG_C45.Text) + ", " + tool.ConvertFloat(TXT_LBRG_C46.Text) + "," + tool.ConvertFloat(TXT_LBRG_C47.Text) + "," +
					tool.ConvertFloat(TXT_LBRG_C48.Text) + "," + tool.ConvertFloat(TXT_LBRG_C49.Text) + "," + tool.ConvertFloat(TXT_LBRG_C50.Text) + "," + tool.ConvertFloat(TXT_LBRG_C51.Text) + "," +
					tool.ConvertFloat(TXT_LBRG_C52.Text) + "," + tool.ConvertFloat(TXT_LBRG_C53.Text) + "," + tool.ConvertFloat(TXT_LBRG_C54.Text) + "," + tool.ConvertFloat(TXT_LBRG_C55.Text) + "," +			
					tool.ConvertFloat(TXT_LBRG_C56.Text) + "," + tool.ConvertFloat(TXT_LBRG_C57.Text) + "," + tool.ConvertFloat(TXT_LBRG_C58.Text) + "," + tool.ConvertFloat(TXT_LBRG_C59.Text) + "," +			
					tool.ConvertFloat(TXT_LBRG_C60.Text) + "," + tool.ConvertFloat(TXT_LBRG_C61.Text) + ",'" + DDL_CURRENCY.SelectedValue + "','" + DDL_DENOMINATOR.SelectedValue + "','" + LBL_SUMBERDATA.Text + "',''";
				conn.ExecuteNonQuery();
			}
			/* ---------------------- separator -------------------------------------------------*/
			if (TXT_D2.Text != "")
			{
				//conn.QueryString = "exec ca_labarugi_middle_sp '" + a + "','" + Request.QueryString["regno"]+ "','" + TXT_LBRG_D37.Text + "'," + TXT_LBRG_D38.Text + ",'" + TXT_LBRG_D39.Text + "'," + tool.ConvertNum(TXT_LBRG_D40.Text) + "," +
				conn.QueryString = "exec ca_labarugi_middle_sp '" + a + "','"+ Request.QueryString["regno"]+"',"+ GlobalTools.ToSQLDate(TXT_TGL_D1.Text,DDL_BLN_D1.SelectedValue,TXT_YEAR_D1.Text) + "," + tool.ConvertNum(TXT_D2.Text) + ",'" + DDL_D3.SelectedValue + "'," + tool.ConvertFloat(TXT_D4.Text) + "," + 
					tool.ConvertFloat(TXT_LBRG_D41.Text) + "," + tool.ConvertFloat(TXT_LBRG_D42.Text) + "," + tool.ConvertFloat(TXT_LBRG_D43.Text) + "," + 
					tool.ConvertFloat(TXT_LBRG_D44.Text) + "," + tool.ConvertFloat(TXT_LBRG_D45.Text) + ", " + tool.ConvertFloat(TXT_LBRG_D46.Text) + "," + tool.ConvertFloat(TXT_LBRG_D47.Text) + "," +
					tool.ConvertFloat(TXT_LBRG_D48.Text) + "," + tool.ConvertFloat(TXT_LBRG_D49.Text) + "," + tool.ConvertFloat(TXT_LBRG_D50.Text) + "," + tool.ConvertFloat(TXT_LBRG_D51.Text) + "," +
					tool.ConvertFloat(TXT_LBRG_D52.Text) + "," + tool.ConvertFloat(TXT_LBRG_D53.Text) + "," + tool.ConvertFloat(TXT_LBRG_D54.Text) + "," + tool.ConvertFloat(TXT_LBRG_D55.Text) + "," +			
					tool.ConvertFloat(TXT_LBRG_D56.Text) + "," + tool.ConvertFloat(TXT_LBRG_D57.Text) + "," + tool.ConvertFloat(TXT_LBRG_D58.Text) + "," + tool.ConvertFloat(TXT_LBRG_D59.Text) + "," +			
					tool.ConvertFloat(TXT_LBRG_D60.Text) + "," + tool.ConvertFloat(TXT_LBRG_D61.Text) + ",'" + DDL_CURRENCY.SelectedValue + "','" + DDL_DENOMINATOR.SelectedValue + "','" + LBL_SUMBERDATA.Text + "',''";
				conn.ExecuteNonQuery();
			}
			/* ---------------------- separator -------------------------------------------------*/
			if (TXT_E2.Text != "")
			{
				//conn.QueryString = "exec ca_labarugi_middle_sp '" + a + "','" + Request.QueryString["regno"]+ "','" + TXT_LBRG_E37.Text + "'," + TXT_LBRG_E38.Text + ",'" + TXT_LBRG_E39.Text + "'," + tool.ConvertNum(TXT_LBRG_E40.Text) + "," +
				string temp = "Proyeksi";
				conn.QueryString = "exec ca_labarugi_middle_sp '" + a + "','"+ Request.QueryString["regno"]+"',"+ GlobalTools.ToSQLDate(TXT_TGL_E1.Text,DDL_BLN_E1.SelectedValue,TXT_YEAR_E1.Text) + "," + tool.ConvertNum(TXT_E2.Text) + ",'" + temp + "'," + tool.ConvertFloat(TXT_E4.Text) + "," + 
					tool.ConvertFloat(TXT_LBRG_E41.Text) + "," + tool.ConvertFloat(TXT_LBRG_E42.Text) + "," + tool.ConvertFloat(TXT_LBRG_E43.Text) + "," + 
					tool.ConvertFloat(TXT_LBRG_E44.Text) + "," + tool.ConvertFloat(TXT_LBRG_E45.Text) + ", " + tool.ConvertFloat(TXT_LBRG_E46.Text) + "," + tool.ConvertFloat(TXT_LBRG_E47.Text) + "," +
					tool.ConvertFloat(TXT_LBRG_E48.Text) + "," + tool.ConvertFloat(TXT_LBRG_E49.Text) + "," + tool.ConvertFloat(TXT_LBRG_E50.Text) + "," + tool.ConvertFloat(TXT_LBRG_E51.Text) + "," +
					tool.ConvertFloat(TXT_LBRG_E52.Text) + "," + tool.ConvertFloat(TXT_LBRG_E53.Text) + "," + tool.ConvertFloat(TXT_LBRG_E54.Text) + "," + tool.ConvertFloat(TXT_LBRG_E55.Text) + "," +			
					tool.ConvertFloat(TXT_LBRG_E56.Text) + "," + tool.ConvertFloat(TXT_LBRG_E57.Text) + "," + tool.ConvertFloat(TXT_LBRG_E58.Text) + "," + tool.ConvertFloat(TXT_LBRG_E59.Text) + "," +			
					tool.ConvertFloat(TXT_LBRG_E60.Text) + "," + tool.ConvertFloat(TXT_LBRG_E61.Text) + ",'" + DDL_CURRENCY.SelectedValue + "','" + DDL_DENOMINATOR.SelectedValue + "','" + LBL_SUMBERDATA.Text + "','1'";
				conn.ExecuteNonQuery();
			}
			/* ---------------------- separator -------------------------------------------------*/
		}

	
		
		//private void retrieve_data(string param1, string mode)
		private void retrieve_data()
		{
			LBL_H_TAHUN.Text = Request.QueryString["tahun"];

			int row;
			tgl_default();
			
			conn.QueryString = "select bs_isproyeksi from ca_neraca_middle where ap_regno = '" + Request.QueryString["regno"] + "' and year(bs_date_periode) = '" + Request.QueryString["tahun"] + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("bs_isproyeksi")=="1")
				row = 70;
			else
				row = 69;
			
			int jmlrow;
			conn.QueryString = "select excel_field from ca_excel where excel_file = 'kmk_ki_middle' and excel_type = 'bs'";
			conn.ExecuteQuery();
			jmlrow = conn.GetRowCount();

			conn.QueryString = "select top 4 CU_REF,AP_REGNO,BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,BS_SALES_ONCR,BS_CASH_BANK,BS_MARKET_SECUR" +
				",BS_AR,BS_AR_FRAFFIL,BS_INVENTORY,BS_OTH_CURASST,BS_PREPAID_EXP,BS_CURRASST,BS_NETFIXASST" +
				",BS_INVESTMENT,BS_NONCA,BS_NI,BS_TTL_NONCA,BS_TTL_ASST,BS_DBST,BS_AP,BS_AP_TOAFFL,BS_ACCRUALS" +
				",BS_TAXPAY,BS_OTH_CURLIAB,BS_CURR_PORTLTDEBT,BS_CURR_LIAB,BS_LONGTERM_DEBT,BS_OTH_LIAB,BS_LONGTERM_LIAB" +
				",BS_TTL_LIAB,BS_CMN_STK,BS_SURP_RESRV,BS_RET_EARN,BS_TTL_NETWORTH,BS_LIAB_NETWORTH,BS_CURRENCY" +
				",BS_DENOMINATOR,BS_SUMBERDATA,BS_ISPROYEKSI from ca_neraca_middle where year(bs_date_periode) <= '" + Request.QueryString["tahun"] + "' and ap_regno = '" + Request.QueryString["regno"]+ "' order by bs_date_periode desc";
			conn.ExecuteQuery();

			
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				
				row--;
				string vtmp = ((char)row).ToString();
				int k = 6;
				
				int xx=1;
				for (int m=1;m<5;m++)
				{
					xx++;
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
					if (Request.QueryString["mode"] == "retrieve")
					{
						if (m!=1)
						{
							if (m==3)
							{
								for (int p=3;p<4;p++)
								{
									System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vtmp + p.ToString());
									txt.Text = conn.GetFieldValue(i, xx);
									try 
									{
										DDL_.SelectedValue = txt.Text;
									}
									catch
									{
										DDL_.SelectedValue = "-";
									}
								}
							}
							else 
							{
								try
								{
									txt.Text = conn.GetFieldValue(i,xx);
								}
								catch
								{
									txt.Text = "0";
								}
							}
						} 
						else 
						{
							for (int n=1;n<2;n++)
							{
								System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmp + n.ToString());
								System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmp + n.ToString());
								System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmp + n.ToString());
								
								DateTime excdatestr = Convert.ToDateTime(tool.FormatDate(conn.GetFieldValue(i, xx)));
								try
								{
									TXT_TGL_.Text = "";
									DDL_BLN_.SelectedValue = "";
									TXT_YEAR_.Text = "";
									GlobalTools.fillDateForm(TXT_TGL_, DDL_BLN_, TXT_YEAR_, excdatestr);
								}
								catch
								{
									//									TXT_TGL_.Text = "";
									//									DDL_BLN_.SelectedValue = "";
									//									TXT_YEAR_.Text = "";
								}

							}
						}			
					} 
					else 
					{
						txt.Text = "";
					}
				}
	
				
				for (int j = 5; j <= jmlrow; j++)
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + j.ToString());
					if (Request.QueryString["mode"] == "retrieve")
					{
						try
						{
							txt.Text = myMoneyFormat_noDec(conn.GetFieldValue(i, k));
						}
						catch
						{
							txt.Text = "";
						}
					}
					else 
					{
						txt.Text = "";
					}
					k++;
				}

			}
			
		}


		private void retrieve_HistoryData(string regno, string tahun)
		{
			LBL_H_TAHUN.Text = tahun;

			int row;
			tgl_default();
			
			conn.QueryString = "select bs_isproyeksi from ca_neraca_middle where ap_regno = '" + 
				regno + "' and year(bs_date_periode) = '" + tahun + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("bs_isproyeksi")=="1")
				row = 70;
			else
				row = 69;
			
			int jmlrow;
			conn.QueryString = "select excel_field from ca_excel where excel_file = 'kmk_ki_middle' and excel_type = 'bs'";
			conn.ExecuteQuery();
			jmlrow = conn.GetRowCount();

			conn.QueryString = "select top 4 CU_REF,AP_REGNO,BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,BS_SALES_ONCR,BS_CASH_BANK,BS_MARKET_SECUR" +
				",BS_AR,BS_AR_FRAFFIL,BS_INVENTORY,BS_OTH_CURASST,BS_PREPAID_EXP,BS_CURRASST,BS_NETFIXASST" +
				",BS_INVESTMENT,BS_NONCA,BS_NI,BS_TTL_NONCA,BS_TTL_ASST,BS_DBST,BS_AP,BS_AP_TOAFFL,BS_ACCRUALS" +
				",BS_TAXPAY,BS_OTH_CURLIAB,BS_CURR_PORTLTDEBT,BS_CURR_LIAB,BS_LONGTERM_DEBT,BS_OTH_LIAB,BS_LONGTERM_LIAB" +
				",BS_TTL_LIAB,BS_CMN_STK,BS_SURP_RESRV,BS_RET_EARN,BS_TTL_NETWORTH,BS_LIAB_NETWORTH,BS_CURRENCY" +
				",BS_DENOMINATOR,BS_SUMBERDATA,BS_ISPROYEKSI from ca_neraca_middle where year(bs_date_periode) <= '" + 
				tahun + "' and ap_regno = '" + regno + "' order by bs_date_periode desc";
			conn.ExecuteQuery();

			//row = 69;
			
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				
				row--;
				string vtmp = ((char)row).ToString();
				int k = 6;
				
				int xx=1;
				for (int m=1;m<5;m++)
				{
					xx++;
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
					if (m!=1)
					{
						if (m==3)
						{
							for (int p=3;p<4;p++)
							{
								System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vtmp + p.ToString());
								txt.Text = conn.GetFieldValue(i, xx);
								try 
								{
									DDL_.SelectedValue = txt.Text;
								}
								catch
								{
									DDL_.SelectedValue = "-";
								}
							}
						}
						else 
						{
							try
							{
								txt.Text = conn.GetFieldValue(i,xx);
							}
							catch
							{
								txt.Text = "0";
							}
						}
					} 
					else 
					{
						for (int n=1;n<2;n++)
						{
							System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmp + n.ToString());
							System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmp + n.ToString());
							System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmp + n.ToString());
								
							DateTime excdatestr = Convert.ToDateTime(tool.FormatDate(conn.GetFieldValue(i, xx)));
							try
							{
								TXT_TGL_.Text = "";
								DDL_BLN_.SelectedValue = "";
								TXT_YEAR_.Text = "";
								GlobalTools.fillDateForm(TXT_TGL_, DDL_BLN_, TXT_YEAR_, excdatestr);
							}
							catch
							{
								//									TXT_TGL_.Text = "";
								//									DDL_BLN_.SelectedValue = "";
								//									TXT_YEAR_.Text = "";
							}

						}
					}
				}
	
				
				for (int j = 5; j <= jmlrow; j++)
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + j.ToString());
					try
					{
						txt.Text = myMoneyFormat_noDec(conn.GetFieldValue(i, k));
					}
					catch
					{
						txt.Text = "";
					}
					k++;
				}

			}
			
		}

		private string formatMoney_ind(string a)
		{
			string b,c,d;																	//a = 1,230.00
			c = Strings.Replace(myMoneyFormat_noDec(a),".", ";",1,-1,CompareMethod.Binary);	//c = 1,230;00
			b = Strings.Replace(c,",", ".",1,-1,CompareMethod.Binary);						//b = 1.230;00
			d = Strings.Replace(b,";", ",",1,-1,CompareMethod.Binary);						//d = 1.230,00
			
			return d;
			//return myMoneyFormat_noDec(a);
		}

		private void BTN_SIMPAN_Click(object sender, System.EventArgs e)
		{
			save_neraca();
			save_labarugi();
		}

		private void BTN_REFRESH_Click(object sender, System.EventArgs e)
		{
		}	

		

		private void DG_Neraca1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;
			
			
			switch (cmd)
			{
				case "retrieve" :
					string vtemp = e.Item.Cells[3].Text;
					Response.Redirect("Neraca_KMK_KI_Medium.aspx?tahun=" + vtemp +"&mode=retrieve&regno="+Request.QueryString["regno"]+"&mc="+Request.QueryString["mc"]+"&bussunitid="+Request.QueryString["bussunitid"]+"&programid="+Request.QueryString["programid"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&viewmode="+Request.QueryString["viewmode"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]);
					clear_field();
					//retrieve_data(vtemp,"retrieve");
					retrieve_data();
					
					break;
				case "delete" :
					conn.QueryString = "exec ca_neraca_middle_sp_delete '" + Request.QueryString["curef"]+ "','" + Request.QueryString["regno"]+ "'," +
						GlobalTools.ToSQLDate(e.Item.Cells[4].Text) + ",'" + e.Item.Cells[1].Text + "','" + e.Item.Cells[2].Text + "'";
					conn.ExecuteNonQuery();
					
					conn.QueryString = "exec ca_temp_curr_denom_sp 'delete','" + Request.QueryString["curef"]+ "','" + Request.QueryString["regno"]+ "'"; 
					conn.ExecuteNonQuery();
					
					//delete ratio as well 
					CLS_CALCULATION.delete_ratio(Request.QueryString["regno"],conn);
					
					isi_initial();
					viewdata();
					clear_field();
					
					break;
				default :
					break;
			}
		}

		private void DG_NeracaHistory_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;

			switch (cmd)
			{
				case "retrieve_history" :
					//string vtemp = e.Item.Cells[4].Text;
					//retrieve_datahistory(vtemp,"retrieve_history");		//changed by nyoman
					string regno = e.Item.Cells[0].Text,
						tahun = e.Item.Cells[4].Text;
					retrieve_HistoryData(regno, tahun);
					break;
				case "delete_history" :
					string vtempo = e.Item.Cells[4].Text;
					//retrieve_datahistory(vtempo,"delete_history");
					clear_field_history(vtempo);
					//tgl_default();
					break;
				default :
					break;
			}
		}
		
		//private void clear_field(string vtahun)
		private void clear_field()
		{
			LBL_H_TAHUN.Text = "";

			int cnt;
				
			conn.QueryString = "select CU_REF,AP_REGNO,BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,BS_SALES_ONCR,BS_CASH_BANK,BS_MARKET_SECUR" +
				",BS_AR,BS_AR_FRAFFIL,BS_INVENTORY,BS_OTH_CURASST,BS_PREPAID_EXP,BS_CURRASST,BS_NETFIXASST" +
				",BS_INVESTMENT,BS_NONCA,BS_NI,BS_TTL_NONCA,BS_TTL_ASST,BS_DBST,BS_AP,BS_AP_TOAFFL,BS_ACCRUALS" +
				",BS_TAXPAY,BS_OTH_CURLIAB,BS_CURR_PORTLTDEBT,BS_CURR_LIAB,BS_LONGTERM_DEBT,BS_OTH_LIAB,BS_LONGTERM_LIAB" +
				",BS_TTL_LIAB,BS_CMN_STK,BS_SURP_RESRV,BS_RET_EARN,BS_TTL_NETWORTH,BS_LIAB_NETWORTH,BS_CURRENCY" +
				",BS_DENOMINATOR,BS_SUMBERDATA,BS_ISPROYEKSI from ca_neraca_middle where ap_regno = '" + Request.QueryString["regno"] + "' order by bs_date_periode desc";
			conn.ExecuteQuery();
			cnt = conn.GetRowCount();

			conn.QueryString="select excel_field from ca_excel where excel_file = 'kmk_ki_middle' and excel_type = 'bs'";
			conn.ExecuteQuery();
				
			int row = 70;
			//for (int i = 0; i < cnt; i++)
			//TO DO :
			for (int i = 0; i < 4; i++)
			{
				row--;
				string vtmp = ((char)row).ToString();
				
				//for (int m=1;m<=conn.GetRowCount();m++)
				for (int m=2;m<=35;m++)
				{
					if (m==3)
					{
						System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vtmp + m.ToString());
						DDL_.SelectedValue = "-";
					}
					else
					{
						System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
						txt.Text = "";
					}
				}
				
				if(row<=66)
				{
					break;}
			}
			tgl_default();
		}


		private void clear_field_history(string vtahun)
		{
			int cnt;
				
			conn.QueryString = "select CU_REF,AP_REGNO,BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,BS_SALES_ONCR,BS_CASH_BANK,BS_MARKET_SECUR" +
				",BS_AR,BS_AR_FRAFFIL,BS_INVENTORY,BS_OTH_CURASST,BS_PREPAID_EXP,BS_CURRASST,BS_NETFIXASST" +
				",BS_INVESTMENT,BS_NONCA,BS_NI,BS_TTL_NONCA,BS_TTL_ASST,BS_DBST,BS_AP,BS_AP_TOAFFL,BS_ACCRUALS" +
				",BS_TAXPAY,BS_OTH_CURLIAB,BS_CURR_PORTLTDEBT,BS_CURR_LIAB,BS_LONGTERM_DEBT,BS_OTH_LIAB,BS_LONGTERM_LIAB" +
				",BS_TTL_LIAB,BS_CMN_STK,BS_SURP_RESRV,BS_RET_EARN,BS_TTL_NETWORTH,BS_LIAB_NETWORTH,BS_CURRENCY" +
				",BS_DENOMINATOR,BS_SUMBERDATA,BS_ISPROYEKSI from ca_neraca_middle where year(bs_date_periode) > '" + vtahun + "' and ap_regno = '" + Request.QueryString["regno"]+ "'";
			conn.ExecuteQuery();
			cnt = conn.GetRowCount();

			conn.QueryString="select excel_field from ca_excel where excel_file = 'kmk_ki_middle' and excel_type = 'bs'";
			conn.ExecuteQuery();
				
			int row = 65;
			for (int i = 0; i < cnt; i++)
			{
				row++;
				string vtmp = ((char)row).ToString();
				for (int m=1;m<=conn.GetRowCount();m++)
				{
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
					txt.Text = "";
				}
			}
			DDL_B3.SelectedValue = "-";
			DDL_C3.SelectedValue = "-";
			DDL_D3.SelectedValue = "-";
			DDL_E3.SelectedValue = "-";
			tgl_default();
		}

		private void tgl_default()
		{
			GlobalTools.initDateForm(this.TXT_TGL_B1, this.DDL_BLN_B1, this.TXT_YEAR_B1, true);
			GlobalTools.initDateForm(this.TXT_TGL_C1, this.DDL_BLN_C1, this.TXT_YEAR_C1, true);
			GlobalTools.initDateForm(this.TXT_TGL_D1, this.DDL_BLN_D1, this.TXT_YEAR_D1, true);
			GlobalTools.initDateForm(this.TXT_TGL_E1, this.DDL_BLN_E1, this.TXT_YEAR_E1, true);
			try
			{ 
				//this.DDL_BLN_B1.SelectedValue = DateTime.Now.Month.ToString();
				this.DDL_BLN_B1.SelectedValue = "";
				this.DDL_BLN_C1.SelectedValue = "";
				this.DDL_BLN_D1.SelectedValue = "";
				this.DDL_BLN_E1.SelectedValue = "";
			}
			catch{}
		}
		
		private void retrieve_datahistory(string vtahun, string mode)
		{
			if (mode == "retrieve_history")
			{
				clear_field_history(vtahun);
				/********* start retrieve **************************/
				System.Data.DataTable dt = new System.Data.DataTable();
				conn.QueryString = "select CU_REF,AP_REGNO,POSISI_TGL,JML_BLN,JNS_LAP,SALES_ONCREDIT,AKTV_KASBANK,AKTV_PIUDGN,AKTV_PERSEDIAAN" +
					",AKTV_LCRLAIN,AKTV_TTLAKTLCR,AKTV_TNHBGN,AKTV_MSNALAT,AKTV_INVKNDRN,AKTV_TTPLAIN,AKTV_AKUMSUSUT" +
					",AKTV_NETAKTVTTP,AKTV_BIAYATANGGUH,AKTV_AKUMAMOR,AKTV_AKTVLAIN,AKTV_TTLAKTVLAIN,AKTV_TTLAKTV" +
					",PASV_HTDG,PASV_HTBANK,PASV_KIJTHTEMPO,PASV_HTLNCR,PASV_TTLHTLNCR,PASV_HTJKPJG,PASV_HTPMGANGSHM" +
					",PASV_JKPJGLAIN,PASV_TTLHTJKPJG,PASV_TTLHT,PASV_MODALSTR,PASV_LBRG,PASV_TTLMODAL,PASV_TTLPASIVA" +
					",IS_CURRENCY,IS_DENOMINATOR,SUMBERDATA,IS_PROYEKSI from ca_neraca_small where year(posisi_tgl) <= '" + vtahun + "' and ap_regno = '" + Request.QueryString["regno"]+ "'";
				conn.ExecuteQuery();
				int jml_baris = conn.GetRowCount();
				
				dt = conn.GetDataTable().Copy();
				
				conn.QueryString="select excel_field from ca_excel where excel_file = 'kmk_ki_middle' and excel_type = 'bs'";
				conn.ExecuteQuery();

				int hrf = 69;
				for (int ii = 0; ii < jml_baris; ii++)
				{
					hrf--;
					string vtmpe = ((char)hrf).ToString();
					int start = 1;
					
					for (int n=1;n<=4;n++)
					{
						start++;
						System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_" + vtmpe + n.ToString());
						
						if (n==1)
						{
							System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmpe + n.ToString());
							System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmpe + n.ToString());
							System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmpe + n.ToString());
					
							DateTime excdatestr = Convert.ToDateTime(tool.FormatDate(dt.Rows[ii][start].ToString()));
							try 
							{
								GlobalTools.fillDateForm(TXT_TGL_, DDL_BLN_, TXT_YEAR_, excdatestr);
							}
							catch
							{
								TXT_TGL_.Text = "";
								DDL_BLN_.SelectedValue = "";
								TXT_YEAR_.Text = "";		
							}
						}
						else if (n==3)
						{ 
							System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vtmpe + n.ToString());
							txt.Text = dt.Rows[ii][4].ToString();
							try 
							{
								DDL_.SelectedValue = txt.Text;
							}
							catch
							{
								DDL_.SelectedValue = "-";
							}	
							
						}
						else 
						{ 
							try
							{
								txt.Text = dt.Rows[ii][start].ToString();
							}
							catch
							{
								txt.Text = "";
							}
						}
						if (start==4){ continue; }
					}
					
					/**** separator ***/
					//for (int nn=5;nn<=conn.GetRowCount();nn++)
					int start_k = 5;
					int temp = 0;
					for (int nn=5;nn<11;nn++)
					{
						start_k++;
						System.Web.UI.WebControls.TextBox teksbok = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_" + vtmpe + nn.ToString());
						
						if (nn==6) 
						{ 
							start_k = 6; 
							try
							{ teksbok.Text = temp.ToString(); }
							catch { teksbok.Text = "0"; }

							continue;
						}
						else if (nn==8)
						{
							start_k = 7;
							try
							{ teksbok.Text = temp.ToString(); }
							catch 
							{
								teksbok.Text = "0"; 
								continue;
							}
						
							try
							{
								teksbok.Text = myMoneyFormat_noDec(dt.Rows[ii][start_k].ToString());
							}
							catch
							{
								teksbok.Text = "0";
							}
						}
						/**** separator ****/
						for (int nnn=11;nnn<36;nnn++)
						{
							System.Web.UI.WebControls.TextBox teksboks = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_" + vtmpe + nnn.ToString());				
							if (nnn == 12) 
							{ 
								try  { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][10].ToString()); }
								catch { teksboks.Text = "0"; }
							}
							else if (nnn == 13) 
							{ 
								try { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][16].ToString()); } 
								catch { teksboks.Text = "0"; }
							}
							else if (nnn == 17) 
							{ 
								try { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][20].ToString()); }
								catch { teksboks.Text = "0"; }
							}
							else if (nnn == 18)	
							{ 
								try { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][21].ToString()); }
								catch { teksboks.Text = "0"; }
							}
							else if (nnn == 19)	
							{ 
								try { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][23].ToString()); }
								catch { teksboks.Text = "0"; }
							}
							else if (nnn == 20)	
							{ 
								try { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][22].ToString()); }
								catch { teksboks.Text = "0"; }
							}
							else if (nnn == 24)	
							{ 
								try { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][25].ToString()); }
								catch { teksboks.Text = "0"; }
							}
							else if (nnn == 26)	
							{ 
								try { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][26].ToString()); }
								catch { teksboks.Text = "0"; }
							}
							else if (nnn == 28)	
							{ 
								try { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][29].ToString()); }
								catch { teksboks.Text = "0"; }
							}
							else if (nnn == 29)	
							{ 
								try { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][30].ToString()); }
								catch { teksboks.Text = "0"; }
							}
							else if (nnn == 30)	
							{ 
								try { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][31].ToString()); }
								catch { teksboks.Text = "0"; }
							}
							else if (nnn == 31)	
							{ 
								try { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][32].ToString()); }
								catch { teksboks.Text = "0"; }
							}
							else if (nnn == 32)	
							{ 
								try { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][32].ToString()); }
								catch { teksboks.Text = "0"; }
							}	
							else if (nnn == 33)	
							{ 
								try { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][33].ToString()); }
								catch { teksboks.Text = "0"; }
							}	
							else if (nnn == 34)	
							{ 
								try { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][34].ToString()); }
								catch { teksboks.Text = "0"; }
							}	
							else if (nnn == 35)	
							{ 
								try { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][35].ToString()); }
								catch { teksboks.Text = "0"; }
							}	
							else 
							{ 
								try { teksboks.Text = temp.ToString(); }
								catch { teksboks.Text = "0"; }
							}
						}
						if (hrf<=66) // if < B keluar..
						{
							break;
						}
					}

				}
			}
		}

		private void ViewFileUpload()
		{
			conn.QueryString = "select XLS_DIR from CA_EXCEL_TEMPLATE";
			conn.ExecuteQuery();
			string path = "/SME/" + conn.GetFieldValue("XLS_DIR").ToString().Trim().Replace("\\", "/");
			
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "select AP_REGNO,SEQ,FU_FILENAME,FU_USERID,XLS_DIR from CA_FILEUPLOADXL where AP_REGNO ='"+ Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrid.DataSource = dt;
			try 
			{
				DatGrid.DataBind();
			} 
			catch 
			{
				DatGrid.CurrentPageIndex = 0;
				DatGrid.DataBind();
			}
			for (int i = 1; i <= DatGrid.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DatGrid.Items[i-1].Cells[3].FindControl("HL_DOWNLOAD");
				LinkButton HpDelete   = (LinkButton) DatGrid.Items[i-1].Cells[4].FindControl("LinkButton1");
				HpDownload.NavigateUrl = path + DatGrid.Items[i-1].Cells[2].Text.Trim();
				DatGrid.Items[i-1].Cells[1].Text = i.ToString();

				if (Session["USERID"].ToString().Trim() != DatGrid.Items[i-1].Cells[5].Text)
					HpDelete.Visible	= false;

				if (Request.QueryString["ca"] =="0") 
				{
					//HpDownload.Enabled	= false;
					HpDelete.Enabled	= false;
				}
			}
		}

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string path, mStatus = "", mStatusReport = "";
			conn.QueryString = "select XLS_ROOT, XLS_DIR from CA_EXCEL_TEMPLATE";
			conn.ExecuteQuery();
			path = conn.GetFieldValue("XLS_ROOT").ToString().Trim()+ conn.GetFieldValue("XLS_DIR").ToString().Trim();
 
			HttpFileCollection uploadedFiles = Request.Files;
			
			int counter = 0, mField = 0;
			LBL_STATUS.Text = "";
			LBL_STATUSREPORT.Text = "";

			string vdir;
			for (int i = 0; i < uploadedFiles.Count; i++)
			{
				HttpPostedFile userPostedFile = uploadedFiles[i];
				counter = i + 1;
				try
				{
					if (userPostedFile.ContentLength > 0)
					{
						userPostedFile.SaveAs(path + Request.QueryString["regno"].Trim() + "-"+ Session["USERID"].ToString() +"-" + Path.GetFileName(userPostedFile.FileName));
						LBL_STATUS.ForeColor = Color.Black;
						LBL_STATUSREPORT.ForeColor = Color.Black;
						mStatus = "Upload Successful!";
						mStatusReport = "<u>File #" + counter.ToString() + "</u><br>" + 
							"File Content Type: " + userPostedFile.ContentType + "<br>" + 
							"File Size: " + userPostedFile.ContentLength + " bytes<br>" + 
							"File Name: " + userPostedFile.FileName + "<br>";
						mStatusReport += "Location Where Saved: " + path + Request.QueryString["regno"].Trim() + "-"+Session["USERID"].ToString()+"-" + Path.GetFileName(userPostedFile.FileName) + "<p>";

						int lket = Request.QueryString["regno"].Trim().Length + Session["USERID"].ToString().Trim().Length + 2;
						conn.QueryString = "select FU_FILENAME from CA_FILEUPLOADXL where AP_REGNO = '" +Request.QueryString["regno"]+ "' and FU_USERID = '"+Session["USERID"].ToString()+"'";
						conn.ExecuteQuery();
						for (int j = 0; j < conn.GetRowCount(); j++)
						{
							string fileNameDB = conn.GetFieldValue(j,0).Substring(lket, conn.GetFieldValue(j,0).Trim().Length - lket);
							if (fileNameDB.Trim() == Path.GetFileName(userPostedFile.FileName).Trim())
							{
								mField = mField + 1;
							}
						}

						if (mField == 0)
						{
							conn.QueryString = "exec CA_FILEUPLOADXL_SP '" +Request.QueryString["regno"]+ "', '', '" +Request.QueryString["regno"].Trim() + "-"+Session["USERID"].ToString()+"-" + 
								Path.GetFileName(userPostedFile.FileName)+ "', '" +Session["USERID"].ToString()+ "', '1'";
							conn.ExecuteNonQuery();
							ViewFileUpload();
						}
					}
					//vdir = Path.GetFileName(userPostedFile.FileName);
					LBL_SUMBERDATA.Text = "excel";	
				}

				catch (Exception ex)
				{
					LBL_STATUS.ForeColor = Color.Red;
					LBL_STATUSREPORT.ForeColor = Color.Red;
					mStatus		  = "Error Uploading File";
					mStatusReport = ex.ToString();
				}
				
				LBL_STATUS.Text			= mStatus.Trim();
				LBL_STATUSREPORT.Text	= mStatusReport.Trim();
			}		
			
			
			/********************************/
			vdir = Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName);
			//viewExcel(vdir);			
			//viewExcel_LabaRugi(vdir);

            Dictionary<string, string> theresult = new Dictionary<string, string>();

            client.Neraca_KMK_KI_MediumASPXViewExcel(out theresult, vdir, Request.QueryString["regno"], Session["USERID"].ToString());

            for (int i = 0; i < theresult.Keys.Count; i++)
            {
                string ID_CONTROL = theresult.Keys.ElementAt(i);

                System.Web.UI.Control controls = this.Page.FindControl(ID_CONTROL);
                if (controls is System.Web.UI.WebControls.TextBox)
                {
                    ((System.Web.UI.WebControls.TextBox)controls).Text = theresult[ID_CONTROL];
                }
            }

            client.Neraca_KMK_KI_MediumASPXviewExcel_LabaRugi(out theresult, vdir, Request.QueryString["regno"], Session["USERID"].ToString());

            for (int i = 0; i < theresult.Keys.Count; i++)
            {
                string ID_CONTROL = theresult.Keys.ElementAt(i);

                System.Web.UI.Control controls = this.Page.FindControl(ID_CONTROL);
                if (controls is System.Web.UI.WebControls.TextBox)
                {
                    ((System.Web.UI.WebControls.TextBox)controls).Text = theresult[ID_CONTROL];
                }
            }
			/********************************/
            
		}

		private void DatGrid_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete" :
					/// Function delete file fisik
					/// 
					try 
					{					
						string directory = @"C:\";
						conn.QueryString = "select top 1 XLS_ROOT + XLS_DIR as fullpath from CA_EXCEL_TEMPLATE";
						conn.ExecuteQuery();
						directory = conn.GetFieldValue("FULLPATH");						

						deleteFile(directory, e.Item.Cells[2].Text);
						Response.Write("<!-- file : " + directory + e.Item.Cells[2].Text + " -->");
						Response.Write("<!-- file is deleted. -->");
					} 
					catch (Exception ex) 
					{
						Response.Write("<!-- Delete File Error: " + ex.Message.ToString() + " -->");
					}

					conn.QueryString = "exec CA_FILEUPLOADXL_SP '" +Request.QueryString["regno"]+ "', '" +e.Item.Cells[0].Text+ "','','','2'";
					conn.ExecuteNonQuery();					
					
					ViewFileUpload();
					break;
			}
		}		

		private void DG_XLS_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
		
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			clear_field();
		}

		private void BTN_PROSES_Click(object sender, System.EventArgs e)
		{
			save_neraca();
			//proses_calculate();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn));
		}

		
		private void readonly_teksbox()
		{
			conn.QueryString = "select excel_cell1,excel_cell2,excel_cell3,excel_cell4 from ca_excel where table_name = 'ca_neraca_middle'" +
				" and excel_field in ('BS_CURRASST','BS_TTL_NONCA','BS_TTL_ASST','BS_CURR_LIAB','BS_LONGTERM_LIAB' " +
				",'BS_TTL_LIAB','BS_TTL_NETWORTH','BS_LIAB_NETWORTH')";
			conn.ExecuteQuery();	
			 
			  
			for(int i=0; i < conn.GetRowCount(); i++) 
			{
				System.Web.UI.WebControls.TextBox TXT_B = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + conn.GetFieldValue(i,0));
				System.Web.UI.WebControls.TextBox TXT_C = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + conn.GetFieldValue(i,1));
				System.Web.UI.WebControls.TextBox TXT_D = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + conn.GetFieldValue(i,2));
				System.Web.UI.WebControls.TextBox TXT_E = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + conn.GetFieldValue(i,3));
			    
				TXT_B.BackColor = Color.Gainsboro;
				//TXT_B.ReadOnly = true;
                TXT_B.Attributes.Add("readonly", "readonly");
				
				TXT_C.BackColor = Color.Gainsboro;
				//TXT_C.ReadOnly = true;
                TXT_C.Attributes.Add("readonly", "readonly");

				TXT_D.BackColor = Color.Gainsboro;
				//TXT_D.ReadOnly = true;
                TXT_D.Attributes.Add("readonly", "readonly");

				TXT_E.BackColor = Color.Gainsboro;
				//TXT_E.ReadOnly = true;
                TXT_E.Attributes.Add("readonly", "readonly");
			}

		}

		protected void BTN_CEK_Click(object sender, System.EventArgs e)
		{
			//LbL_FLAG_INISIALISASI.Text = "1";
			//conn.QueryString = "select bs_currency,bs_denominator from ca_neraca_middle where cu_ref = '" + Request.QueryString["curef"] + "'" +
			//					" and ap_regno = '" + Request.QueryString["regno"] + "'";
			//conn.ExecuteNonQuery();
			
			
			conn.QueryString = "exec ca_temp_curr_denom_sp 'save','" + Request.QueryString["curef"] + "','" +
				Request.QueryString["regno"] + "','" + DDL_CURRENCY.SelectedValue + "','" +
				DDL_DENOMINATOR.SelectedValue + "'";
			conn.ExecuteNonQuery();
			PnlNeraca.Visible = true;
			

		}

        protected override void Render(HtmlTextWriter writer)
        {
            string content = string.Empty;

            using (var stringWriter = new StringWriter())
            using (var htmlWriter = new HtmlTextWriter(stringWriter))
            {
                base.Render(htmlWriter);
                htmlWriter.Close();
                content = stringWriter.ToString();
            }

            string newContent = LoopTextboxes(this.Page, content);
            writer.Write(newContent);
        }

        private string LoopTextboxes(Control page, string contents)
        {
            string element = "";

            foreach (Control control in page.Controls)
            {
                if (control is System.Web.UI.WebControls.TextBox || control is System.Web.UI.WebControls.Label)
                {
                    element = control.ID;
                    contents = NetMigrationEmpat(contents, element);
                }

                if (control.HasControls())
                {
                    contents = LoopTextboxes(control, contents);
                }
            }

            return contents;
        }

        private string NetMigrationEmpat(string content, string element)
        {
            string EditedRender = content;

            EditedRender = EditedRender.Replace("document." + this.Form.ID + "." + element, "document.getElementById('" + element + "')");

            return EditedRender;
        }
	}
}
