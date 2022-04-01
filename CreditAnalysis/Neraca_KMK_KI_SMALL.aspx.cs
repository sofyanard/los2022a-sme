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


//namespace SME.CreditAnalysis
namespace SME.CreditAnalysis
{
	/// <summary>
	/// Summary description for Neraca_KMK_KI_500JT_2M.
	/// </summary>
	public partial class Neraca_KMK_KI_500JT_2M : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button BTN_DEL;
		protected System.Web.UI.WebControls.Button BTN_RTRV;
		protected System.Web.UI.WebControls.RadioButton RBTN_LAPKEU1;
		protected System.Web.UI.WebControls.RadioButton RadioButton2;
		protected System.Web.UI.WebControls.TextBox TXT_A_THNKEN_20;
		protected System.Web.UI.WebControls.TextBox TXT_A_THNKENPLUS1_20;
		protected System.Web.UI.WebControls.TextBox TXT_A_THNPROYEKSI_20;
		protected System.Web.UI.WebControls.TextBox TXT_A_THNKENPLUS1_36;
		protected System.Web.UI.WebControls.TextBox TXT_A_THNPROYEKSI_39;
		protected System.Web.UI.WebControls.TextBox TXT_A_THNKENPLUS1_56;
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.TextBox TXT_A_THNPROYEKSI_36;
		protected System.Web.UI.WebControls.TextBox TXT_A_THNKENPLUS1_57;
		protected System.Web.UI.WebControls.TextBox TXT_A_THNKENPLUS1_58;
		protected System.Web.UI.WebControls.TextBox TXT_B;
		protected System.Web.UI.WebControls.TextBox TXT_1;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected Connection conn;
        private SMEExportImport.WordClient client;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
            client = new SMEExportImport.WordClient();
			
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (Request.QueryString["viewmode"] == "1")
			{
				DG_Neraca1.Columns[6].Visible = false;
				BTN_SIMPANSAJA.Visible = false;
			}
			
			if(!IsPostBack)
			{
				//viewdata_history();		
				initTgl();
				ViewData();
				viewdata_history();		
				retrieve_data();
			}
			ViewMenu();
			ViewSubMenu();
			viewGridExcel();
			
			//BTN_PROSES.Attributes.Add("onclick","if(!valid_small('TXT_B20','TXT_B34','TXT_C20','TXT_C34','TXT_D20','TXT_D34')){return false;};if(!cek_key('neraca')){return false;};");
			
			BTN_SIMPANSAJA.Attributes.Add("onclick","if(!cek_key('neraca')){return false;};");
			//BTN_SIMPANSAJA.Attributes.Add("onclick","if(!cek_key('neraca')){return false;} else HitungNeracaSmall(1,'B'),HitungNeracaSmall(1,'C'),HitungNeracaSmall(1,'D'),FormatCurrency(document.Form1.TXT_B9),FormatCurrency(document.Form1.TXT_B15), FormatCurrency(document.Form1.TXT_B19), FormatCurrency(document.Form1.TXT_B20),FormatCurrency(document.Form1.TXT_B25), FormatCurrency(document.Form1.TXT_B29),FormatCurrency(document.Form1.TXT_B30), FormatCurrency(document.Form1.TXT_B33),FormatCurrency(document.Form1.TXT_B34),FormatCurrency(document.Form1.TXT_C9),FormatCurrency(document.Form1.TXT_C15), FormatCurrency(document.Form1.TXT_C19), FormatCurrency(document.Form1.TXT_C20),FormatCurrency(document.Form1.TXT_C25), FormatCurrency(document.Form1.TXT_C29),FormatCurrency(document.Form1.TXT_C30), FormatCurrency(document.Form1.TXT_C33),FormatCurrency(document.Form1.TXT_C34),FormatCurrency(document.Form1.TXT_D9),FormatCurrency(document.Form1.TXT_D15), FormatCurrency(document.Form1.TXT_D19), FormatCurrency(document.Form1.TXT_D20),FormatCurrency(document.Form1.TXT_D25), FormatCurrency(document.Form1.TXT_D29),FormatCurrency(document.Form1.TXT_D30), FormatCurrency(document.Form1.TXT_D33),FormatCurrency(document.Form1.TXT_D34);");
			BTN_UPLOAD.Attributes.Add("onclick", "if(!uploadInProgress()){return false;};");

			
			ViewFileUpload();
			readonly_teksbox();
			
		}

		private void initTgl()
		{
			GlobalTools.initDateForm(this.TXT_TGL_B1, this.DDL_BLN_B1, this.TXT_YEAR_B1, true);
			GlobalTools.initDateForm(this.TXT_TGL_C1, this.DDL_BLN_C1, this.TXT_YEAR_C1, true);
			GlobalTools.initDateForm(this.TXT_TGL_D1, this.DDL_BLN_D1, this.TXT_YEAR_D1, true);
			try
			{ 
				//this.DDL_BLN_B1.SelectedValue = DateTime.Now.Month.ToString();
				this.DDL_BLN_B1.SelectedValue = "";
				this.DDL_BLN_C1.SelectedValue = "";
				this.DDL_BLN_D1.SelectedValue = "";
			}
			catch{}
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
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						else	
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
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
				//string programid = (string) Session["programid"];
				//string jnsnasabah = (string) Session["jnsnasabah"];

				conn.QueryString = "select distinct top 1 cu_jnsnasabah from customer where cu_ref in (Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+ "')";
				conn.ExecuteQuery();
				string jnsnasabah = conn.GetFieldValue("cu_jnsnasabah").ToString();
				
				conn.QueryString = "select distinct top 1 programid from rfprogram where programid in (select prog_code from application where ap_regno = '"+Request.QueryString["regno"]+ "')";
				conn.ExecuteQuery();
				string programid = conn.GetFieldValue("programid").ToString();

				conn.QueryString = "select MENUCODE,BUSSUNITID,PROGRAMID,PROGRAMID_SEQ,SM_MENUDISPLAY,SM_LINKNAME,LG_CODE from screensubmenu where lg_code in (select distinct lg_code " + 
					"from rfcafinstatement " + 
					"where programid = '" + programid + 
					"' and nasabahid = '" + jnsnasabah + 
					"') and menucode = '" + Request.QueryString["mc"] + 
					"' and programid = '" + programid +"'";
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
			this.DatGrid.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrid_ItemCommand_1);

		}
		#endregion

		private void ViewData()
		{
			conn.QueryString = "Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
			string a = conn.GetFieldValue("cu_ref").ToString();

			conn.QueryString = "select POSISI_TGL,JML_BLN,JNS_LAP,year(POSISI_TGL) tahun from CA_NERACA_SMALL WHERE CU_REF = '"+a+"' and AP_REGNO = '" + Request.QueryString["regno"] + "' order by POSISI_TGL desc";
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
			//conn.QueryString = "select BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,year(BS_DATE_PERIODE) tahun from CA_NERACA_MIDDLE where ap_regno = '"+ Request.QueryString["regno"] + "' order by BS_DATE_PERIODE desc";
			//conn.QueryString = "select AP_REGNO,POSISI_TGL,JML_BLN,JNS_LAP,TAHUN " +
			//	"from VW_CA_NERACA_SMALL_HISTORY where cu_ref = '" + Request.QueryString["curef"] + "' " +
			//	"and ap_regno <> '"+ Request.QueryString["regno"] + "' order by AP_REGNO, POSISI_TGL desc";
			conn.QueryString = "exec CA_NERACA_SMALL_HISTORY '" + Request.QueryString["curef"] + "', '" +
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
			string a = "SF";
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

				excelWorkbook = excelApp.Workbooks.Open(vPath, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows,"\t", false, false, 0, true); 
				Excel.Sheets excelSheets = excelWorkbook.Worksheets;
				string currentSheet = "LOS";
				Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheets.get_Item(currentSheet);
				/*--------------------- separator ---------------------------------------------------------------*/
				// loop utk date periode, number of months lihat excel !!!!!!!!!!!
				for (int i=66;i<69;i++) 
				{
					for (int j=1;j<3;j++)
					{
						string vtmp = ((char)i).ToString()+j; //i=66 diconvert ke ascci jd huruf B, di concat dgn j hasilnya B1,B2,C1,C2
						Excel.Range excelB2 = (Excel.Range)excelWorksheet.get_Range(vtmp, vtmp);

						System.Web.UI.WebControls.TextBox TXT_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_" + vtmp);
						System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmp);
						System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmp);
						System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmp);
						if (j%2==0)
						{
							try { TXT_.Text = excelB2.Value2.ToString(); }
							catch { TXT_.Text = ""; }
						}

						else 
						{
							try 
							{
								TXT_.Text = excelB2.Text.ToString();
								string excdatestr = excelB2.Text.ToString();
								int dd = int.Parse(excdatestr.Substring(3,2)),
									mm = int.Parse(excdatestr.Substring(0,2)),
									yy = int.Parse(excdatestr.Substring(6,2));
								if (yy < 50)
									yy += 2000;
								else
									yy += 1900;
								DateTime excdate = new DateTime(yy, mm, dd);
						
								GlobalTools.fillDateForm(TXT_TGL_, DDL_BLN_, TXT_YEAR_, excdate);
							}
							catch 
							{ 
								TXT_.Text = ""; 
								TXT_TGL_.Text = "";
								DDL_BLN_.SelectedValue = "";
								TXT_YEAR_.Text = "";
													
							}
						}
					}
				}
				/*--------------------- separator ---------------------------------------------------------------*/
				// loop utk cash bank sampe liabilities net worth, lihat excel !!!!!!
				for (int m=66;m<69;m++)
				{
					for (int n=3;n<=35;n++) 
					{ 
						string vRange = ((char)m).ToString()+n; 
						Excel.Range excelCell = (Excel.Range)excelWorksheet.get_Range(vRange, vRange);
						System.Web.UI.WebControls.TextBox TXT_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_" + vRange);
						if (n==3 || n==4)
						{
							if (n==3)
							{
								for (int p=3;p<4;p++)
								{
									string vRg = ((char)m).ToString(); 
									System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vRg + p.ToString());
									try 
									{
										TXT_.Text = excelCell.Text.ToString();
										DDL_.SelectedValue = TXT_.Text;
									}
									catch
									{
										TXT_.Text = "";
										DDL_.SelectedValue = "-";
									}
								}
							}
							else
							{
								try { TXT_.Text = excelCell.Text.ToString(); }
								catch { TXT_.Text = ""; }
							}
						}	
						else 
						{
							try { TXT_.Text = formatMoney_ind(excelCell.Value2.ToString()); }
							catch { TXT_.Text = ""; }
						}
					}
				}
				/*--------------------- separator ---------------------------------------------------------------*/
			}
			catch{}
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
                        catch (Exception e)
                        {
                            continue;
                        }
                    }
				}

			}
			
	
		}

		/* --------------- ----------------------------------------------------------------------------------------------- */
		private void viewExcel_LabaRugi(string directori)
		{
			
			string vPath;
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
					true, false, 0, true);
				Excel.Sheets excelSheets = excelWorkbookIS.Worksheets;
				string currentSheet = "LOS";
				Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheets.get_Item(currentSheet);
				/*--------------------- separator ---------------------------------------------------------------*/
				// loop utk date periode, number of months lihat excel !!!!!!!!!!!
				for (int i=66;i<69;i++) 
				{
					for (int j=36;j<38;j++)
					{
						string vtmp = ((char)i).ToString()+j; //i=66 diconvert ke ascci jd huruf B, di concat dgn j hasilnya B1,B2,C1,C2
						Excel.Range excelB2 = (Excel.Range)excelWorksheet.get_Range(vtmp, vtmp);
						System.Web.UI.WebControls.TextBox TXT_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_" + vtmp);
						if (j%2!=0)
						{
							try { TXT_.Text = excelB2.Value2.ToString(); }
							catch { TXT_.Text = ""; }
						}

						else 
						{
							try { TXT_.Text = excelB2.Text.ToString(); }
							catch { TXT_.Text = ""; }
						}
					}
				}
				/*--------------------- separator ---------------------------------------------------------------*/
				// loop utk cash bank sampe liabilities net worth, lihat excel !!!!!!
				for (int m=66;m<69;m++)
				{
					for (int n=38;n<=55;n++) 
					{ 
						string vRange = ((char)m).ToString()+n; 
						Excel.Range excelCell = (Excel.Range)excelWorksheet.get_Range(vRange, vRange);
						System.Web.UI.WebControls.TextBox TXT_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_" + vRange);
						if (n==38)
						{
							try { TXT_.Text = excelCell.Value2.ToString(); }
							catch { TXT_.Text = ""; }
						}	
						else 
						{
							try { TXT_.Text = formatMoney_ind(excelCell.Value2.ToString()); }
							catch { TXT_.Text = ""; }
						}
					}
				}
				/*--------------------- separator ---------------------------------------------------------------*/
			}
			catch {} 
			finally 
			{
				excelWorkbookIS.Close(null,null,null);
				excelAppIS.Workbooks.Close();
				excelAppIS.Application.Quit();
				excelAppIS.Quit();
				System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbookIS); 
				System.Runtime.InteropServices.Marshal.ReleaseComObject(excelAppIS); 
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
                        catch (Exception e)
                        {
                            continue;
                        }
                    }
				}
			}
			
		}
	
		/* ----------------------------- start retrieve data -------------------------------------------------------------- */
		private void retrieve_data()
		{
			int row;
			initTgl();

			conn.QueryString = "select is_proyeksi from ca_neraca_small where year(posisi_tgl) = '" + Request.QueryString["tahun"] + "' and ap_regno = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("is_proyeksi")=="1")
				row = 69;
			else
				row = 68;

			int jmlrow;
			conn.QueryString = "select excel_field from ca_excel where excel_file = 'kmk_ki_small' and excel_type = 'bs'";
			conn.ExecuteQuery();
			jmlrow = conn.GetRowCount();

			/*
			conn.QueryString = "select top 3 CU_REF,AP_REGNO,POSISI_TGL,JML_BLN,JNS_LAP,SALES_ONCREDIT,AKTV_KASBANK,AKTV_PIUDGN,AKTV_PERSEDIAAN " +
								",AKTV_LCRLAIN,AKTV_TTLAKTLCR,AKTV_TNHBGN,AKTV_MSNALAT,AKTV_INVKNDRN,AKTV_TTPLAIN,AKTV_AKUMSUSUT" +
								",AKTV_NETAKTVTTP,AKTV_BIAYATANGGUH,AKTV_AKUMAMOR,AKTV_AKTVLAIN,AKTV_TTLAKTVLAIN,AKTV_TTLAKTV" +
								",PASV_HTDG,PASV_HTBANK,PASV_KIJTHTEMPO,PASV_HTLNCR,PASV_TTLHTLNCR,PASV_HTJKPJG,PASV_HTPMGANGSHM" +
								",PASV_JKPJGLAIN,PASV_TTLHTJKPJG,PASV_TTLHT,PASV_MODALSTR,PASV_LBRG,PASV_LBRGJALAN,PASV_TTLMODAL,PASV_TTLPASIVA" +
								",IS_CURRENCY,IS_DENOMINATOR,SUMBERDATA,IS_PROYEKSI from ca_neraca_small where year(posisi_tgl) <= '" + Request.QueryString["tahun"] + "' and ap_regno = '" + Request.QueryString["regno"] + "' order by posisi_tgl desc";
			*/

			conn.QueryString = "select top 3 * from VW_CA_NERACA_SMALL_HISTORY " + 
				" where tahun_posisi_tgl <= '" + Request.QueryString["tahun"] + 
				"' and ap_regno = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			//row = 68;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				
				row--;
				string vtmp = ((char)row).ToString();
				int k = 5;
				int kk = 1;
				for (int m=1;m<4;m++)
				{
					kk++;
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
					//if (mode == "retrieve")
					if (Request.QueryString["mode"] == "retrieve")
					{
						if (m!=1)
						{
							if (m==3)
							{
								for (int p=3;p<4;p++)
								{
									System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vtmp + p.ToString());
									try 
									{
										txt.Text = conn.GetFieldValue(i, kk);
										DDL_.SelectedValue = txt.Text;
									}
									catch
									{
										txt.Text = "";
										DDL_.SelectedValue = "-";
									}
										
								}
							}
							else 
							{
								//try { txt.Text = Strings.Left(myMoneyFormat_noDec(conn.GetFieldValue(i, kk)),2); }
								try { txt.Text = conn.GetFieldValue(i, kk); }
								catch { txt.Text = "0"; }
							}
						} 
						else 
						{
							for (int n=1;n<2;n++)
							{
								System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmp + n.ToString());
								System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmp + n.ToString());
								System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmp + n.ToString());
					
								try 
								{
									DateTime excdate = Convert.ToDateTime(tool.FormatDate(conn.GetFieldValue(i, kk)));
									GlobalTools.fillDateForm(TXT_TGL_, DDL_BLN_, TXT_YEAR_, excdate);
								}
								catch 
								{
									TXT_TGL_.Text = "";
									DDL_BLN_.SelectedValue = "";
									TXT_YEAR_.Text = "";
								}
							}
						}			
					} 
					else 
					{
						txt.Text = "";
					}
					
				}
	
				for (int j = 4; j <= 35; j++)
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + j.ToString());
					if (Request.QueryString["mode"] == "retrieve")
					{
						if (j==4)
						{
							//txt.Text = myMoneyFormat_noDec(conn.GetFieldValue(i, k)).Substring(0,myMoneyFormat_noDec(conn.GetFieldValue(i, k)).LastIndexOf(","));
							string delimStr = ",";
							char[] delimiter = delimStr.ToCharArray();
							try 
							{
								//string words = myMoneyFormat_noDec(conn.GetFieldValue(i, k));
								//txt.Text = myMoneyFormat_noDec(conn.GetFieldValue(i, k)).Substring(0,words.Split(delimiter,0).Length);
								//txt.Text = formatMoney_ind(conn.GetFieldValue(i, k));
								txt.Text = myMoneyFormat_noDec(conn.GetFieldValue(i, k));
							}
							catch 
							{
								txt.Text = "";
							}	
						}
						else
							try { txt.Text = myMoneyFormat_noDec(conn.GetFieldValue(i, k)); }
								//try { txt.Text = formatMoney_ind(conn.GetFieldValue(i, k)); }
							catch { txt.Text = ""; }
					}
					else 
					{
						txt.Text = "";
					}
					if (k > 35)
					{	
						break;
					}
					else {k++; }
				}

				if (row<=66){ break; }
			}

		}	
		/* ----------------------------- end retrieve data -------------------------------------------------------------- */

		private void retrieve_HistoryData(string regno, string tahun)
		{
			int row;
			initTgl();

			conn.QueryString = "select is_proyeksi from ca_neraca_small where year(posisi_tgl) = '" +
				tahun + "' and ap_regno = '" + regno + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("is_proyeksi")=="1")
				row = 69;
			else
				row = 68;

			/*
			conn.QueryString = "select top 3 CU_REF,AP_REGNO,POSISI_TGL,JML_BLN,JNS_LAP,SALES_ONCREDIT,AKTV_KASBANK,AKTV_PIUDGN,AKTV_PERSEDIAAN " +
				",AKTV_LCRLAIN,AKTV_TTLAKTLCR,AKTV_TNHBGN,AKTV_MSNALAT,AKTV_INVKNDRN,AKTV_TTPLAIN,AKTV_AKUMSUSUT" +
				",AKTV_NETAKTVTTP,AKTV_BIAYATANGGUH,AKTV_AKUMAMOR,AKTV_AKTVLAIN,AKTV_TTLAKTVLAIN,AKTV_TTLAKTV" +
				",PASV_HTDG,PASV_HTBANK,PASV_KIJTHTEMPO,PASV_HTLNCR,PASV_TTLHTLNCR,PASV_HTJKPJG,PASV_HTPMGANGSHM" +
				",PASV_JKPJGLAIN,PASV_TTLHTJKPJG,PASV_TTLHT,PASV_MODALSTR,PASV_LBRG,PASV_TTLMODAL,PASV_TTLPASIVA" +
				" from ca_neraca_small where year(posisi_tgl) <= '" + 
				tahun + "' and ap_regno = '" + regno + "' order by posisi_tgl desc";
			*/

			conn.QueryString = "select top 3 * from VW_CA_NERACA_SMALL_HISTORY " + 
				" where tahun_posisi_tgl <= '" + tahun + 
				"' and ap_regno = '" + regno + "'";
			conn.ExecuteQuery();

			//row = 68;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				
				row--;
				string vtmp = ((char)row).ToString();
				int k = 5;
				int kk = 1;
				for (int m=1;m<4;m++)
				{
					kk++;
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
					if (m!=1)
					{
						if (m==3)
						{
							for (int p=3;p<4;p++)
							{
								System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vtmp + p.ToString());
								try 
								{
									txt.Text = conn.GetFieldValue(i, kk);
									DDL_.SelectedValue = txt.Text;
								}
								catch
								{
									txt.Text = "";
									DDL_.SelectedValue = "-";
								}
										
							}
						}
						else 
						{
							//try { txt.Text = Strings.Left(myMoneyFormat_noDec(conn.GetFieldValue(i, kk)),2); }
							try { txt.Text = conn.GetFieldValue(i, kk); }
							catch { txt.Text = "0"; }
						}
					} 
					else 
					{
						for (int n=1;n<2;n++)
						{
							System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmp + n.ToString());
							System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmp + n.ToString());
							System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmp + n.ToString());
					
							try 
							{
								DateTime excdate = Convert.ToDateTime(tool.FormatDate(conn.GetFieldValue(i, kk)));
								GlobalTools.fillDateForm(TXT_TGL_, DDL_BLN_, TXT_YEAR_, excdate);
							}
							catch 
							{
								TXT_TGL_.Text = "";
								DDL_BLN_.SelectedValue = "";
								TXT_YEAR_.Text = "";
							}
						}
					}			
		
				}
	
				for (int j = 4; j <= 35; j++)
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + j.ToString());
					if (j==4)
					{
						//txt.Text = myMoneyFormat_noDec(conn.GetFieldValue(i, k)).Substring(0,myMoneyFormat_noDec(conn.GetFieldValue(i, k)).LastIndexOf(","));
						string delimStr = ",";
						char[] delimiter = delimStr.ToCharArray();
						try 
						{
							//string words = myMoneyFormat_noDec(conn.GetFieldValue(i, k));
							//txt.Text = myMoneyFormat_noDec(conn.GetFieldValue(i, k)).Substring(0,words.Split(delimiter,0).Length);
							//txt.Text = formatMoney_ind(conn.GetFieldValue(i, k));
							txt.Text = myMoneyFormat_noDec(conn.GetFieldValue(i, k));
						}
						catch 
						{
							txt.Text = "";
						}	
					}
					else
						try { txt.Text = myMoneyFormat_noDec(conn.GetFieldValue(i, k)); }
							//try { txt.Text = formatMoney_ind(conn.GetFieldValue(i, k)); }
						catch { txt.Text = ""; }
					if (k > 35)
					{	
						break;
					}
					else {k++; }
				}

				if (row<=66){ break; }
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
		/* ------------------------------ START SIMPAN DATA KE TABEL CA_MERACA_SMALL ------------------------------------------- */
		private void save_neraca()
		{
			conn.QueryString = "Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
			string a = conn.GetFieldValue("cu_ref").ToString();
			if (TXT_B5.Text != "")
			{
				conn.QueryString = "exec ca_neraca_small_sp '" + a + "','" + Request.QueryString["regno"] + "'," + GlobalTools.ToSQLDate(TXT_TGL_B1.Text,DDL_BLN_B1.SelectedValue,TXT_YEAR_B1.Text) + "," + tool.ConvertNum(TXT_B2.Text) + ",'" + DDL_B3.SelectedValue + "'," + tool.ConvertNum(TXT_B4.Text) + "," +
					tool.ConvertFloat(TXT_B5.Text) + "," + tool.ConvertFloat(TXT_B6.Text) + ", " + tool.ConvertFloat(TXT_B7.Text) + "," + tool.ConvertFloat(TXT_B8.Text) + "," + 
					tool.ConvertFloat(TXT_B9.Text) + "," + tool.ConvertFloat(TXT_B10.Text) + ", " + tool.ConvertFloat(TXT_B11.Text) + "," + tool.ConvertFloat(TXT_B12.Text) + "," +
					tool.ConvertFloat(TXT_B13.Text) + "," + tool.ConvertFloat(TXT_B14.Text) + "," + tool.ConvertFloat(TXT_B15.Text) + "," + tool.ConvertFloat(TXT_B16.Text) + "," +
					tool.ConvertFloat(TXT_B17.Text) + "," + tool.ConvertFloat(TXT_B18.Text) + "," + tool.ConvertFloat(TXT_B19.Text) + "," + tool.ConvertFloat(TXT_B20.Text) + "," +
					tool.ConvertFloat(TXT_B21.Text) + "," + tool.ConvertFloat(TXT_B22.Text) + "," + tool.ConvertFloat(TXT_B23.Text) + "," + tool.ConvertFloat(TXT_B24.Text) + "," +
					tool.ConvertFloat(TXT_B25.Text) + "," + tool.ConvertFloat(TXT_B26.Text) + "," + tool.ConvertFloat(TXT_B27.Text) + "," + tool.ConvertFloat(TXT_B28.Text) + "," +
					tool.ConvertFloat(TXT_B29.Text) + "," + tool.ConvertFloat(TXT_B30.Text) + "," + tool.ConvertFloat(TXT_B31.Text) + "," + tool.ConvertFloat(TXT_B32.Text) + "," +
					tool.ConvertFloat(TXT_B33.Text) + "," + tool.ConvertFloat(TXT_B34.Text) + "," + tool.ConvertFloat(TXT_B35.Text) + ",'" + LBL_SUMBERDATA.Text + "',''";			
				conn.ExecuteNonQuery();
			}
			if (TXT_C5.Text != "")
			{
				conn.QueryString = "exec ca_neraca_small_sp '" + a + "','" + Request.QueryString["regno"] + "'," + GlobalTools.ToSQLDate(TXT_TGL_C1.Text,DDL_BLN_C1.SelectedValue,TXT_YEAR_C1.Text) + "," + tool.ConvertNum(TXT_C2.Text) + ",'" + DDL_C3.SelectedValue + "'," + tool.ConvertNum(TXT_C4.Text) + "," +
					tool.ConvertFloat(TXT_C5.Text) + "," + tool.ConvertFloat(TXT_C6.Text) + ", " + tool.ConvertFloat(TXT_C7.Text) + "," + tool.ConvertFloat(TXT_C8.Text) + "," + 
					tool.ConvertFloat(TXT_C9.Text) + "," + tool.ConvertFloat(TXT_C10.Text) + ", " + tool.ConvertFloat(TXT_C11.Text) + "," + tool.ConvertFloat(TXT_C12.Text) + "," +
					tool.ConvertFloat(TXT_C13.Text) + "," + tool.ConvertFloat(TXT_C14.Text) + "," + tool.ConvertFloat(TXT_C15.Text) + "," + tool.ConvertFloat(TXT_C16.Text) + "," +
					tool.ConvertFloat(TXT_C17.Text) + "," + tool.ConvertFloat(TXT_C18.Text) + "," + tool.ConvertFloat(TXT_C19.Text) + "," + tool.ConvertFloat(TXT_C20.Text) + "," +
					tool.ConvertFloat(TXT_C21.Text) + "," + tool.ConvertFloat(TXT_C22.Text) + "," + tool.ConvertFloat(TXT_C23.Text) + "," + tool.ConvertFloat(TXT_C24.Text) + "," +
					tool.ConvertFloat(TXT_C25.Text) + "," + tool.ConvertFloat(TXT_C26.Text) + "," + tool.ConvertFloat(TXT_C27.Text) + "," + tool.ConvertFloat(TXT_C28.Text) + "," +
					tool.ConvertFloat(TXT_C29.Text) + "," + tool.ConvertFloat(TXT_C30.Text) + "," + tool.ConvertFloat(TXT_C31.Text) + "," + tool.ConvertFloat(TXT_C32.Text) + "," +
					tool.ConvertFloat(TXT_C33.Text) + "," + tool.ConvertFloat(TXT_C34.Text) + "," + tool.ConvertFloat(TXT_C35.Text) + ",'" + LBL_SUMBERDATA.Text + "',''";
				conn.ExecuteNonQuery();
			}
			
			if (TXT_D5.Text != "")
			{
				string temp = "-";
				conn.QueryString = "exec ca_neraca_small_sp '" + a + "','" + Request.QueryString["regno"] + "'," + GlobalTools.ToSQLDate(TXT_TGL_D1.Text,DDL_BLN_D1.SelectedValue,TXT_YEAR_D1.Text) + "," + tool.ConvertNum(TXT_D2.Text) + ",'" + temp + "'," + tool.ConvertNum(TXT_D4.Text) + "," +
					tool.ConvertFloat(TXT_D5.Text) + "," + tool.ConvertFloat(TXT_D6.Text) + ", " + tool.ConvertFloat(TXT_D7.Text) + "," + tool.ConvertFloat(TXT_D8.Text) + "," + 
					tool.ConvertFloat(TXT_D9.Text) + "," + tool.ConvertFloat(TXT_D10.Text) + ", " + tool.ConvertFloat(TXT_D11.Text) + "," + tool.ConvertFloat(TXT_D12.Text) + "," +
					tool.ConvertFloat(TXT_D13.Text) + "," + tool.ConvertFloat(TXT_D14.Text) + "," + tool.ConvertFloat(TXT_D15.Text) + "," + tool.ConvertFloat(TXT_D16.Text) + "," +
					tool.ConvertFloat(TXT_D17.Text) + "," + tool.ConvertFloat(TXT_D18.Text) + "," + tool.ConvertFloat(TXT_D19.Text) + "," + tool.ConvertFloat(TXT_D20.Text) + "," +
					tool.ConvertFloat(TXT_D21.Text) + "," + tool.ConvertFloat(TXT_D22.Text) + "," + tool.ConvertFloat(TXT_D23.Text) + "," + tool.ConvertFloat(TXT_D24.Text) + "," +
					tool.ConvertFloat(TXT_D25.Text) + "," + tool.ConvertFloat(TXT_D26.Text) + "," + tool.ConvertFloat(TXT_D27.Text) + "," + tool.ConvertFloat(TXT_D28.Text) + "," +
					tool.ConvertFloat(TXT_D29.Text) + "," + tool.ConvertFloat(TXT_D30.Text) + "," + tool.ConvertFloat(TXT_D31.Text) + "," + tool.ConvertFloat(TXT_D32.Text) + "," +
					tool.ConvertFloat(TXT_D33.Text) + "," + tool.ConvertFloat(TXT_D34.Text) + "," + tool.ConvertFloat(TXT_D35.Text) + ",'" + LBL_SUMBERDATA.Text + "','1'";
				conn.ExecuteNonQuery();
			}
			ViewData();
		}
		/* ------------------------------ END SIMPAN DATA KE TABEL CA_MERACA_SMALL ------------------------------------------- */	
		private void save_labarugi()
		{
			conn.QueryString = "Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
			string a = conn.GetFieldValue("cu_ref").ToString();
			
			if (TXT_B5.Text != "")
			{
				conn.QueryString = "exec ca_labarugi_small_sp '" + a + "','" + Request.QueryString["regno"] + "'," + GlobalTools.ToSQLDate(TXT_TGL_B1.Text,DDL_BLN_B1.SelectedValue,TXT_YEAR_B1.Text) + "," + tool.ConvertNum(TXT_B2.Text) + ",'" + DDL_B3.SelectedValue + "'," + 
					tool.ConvertFloat(TXT_B39.Text) + "," +
					tool.ConvertFloat(TXT_B40.Text) + "," + tool.ConvertFloat(TXT_B41.Text) + ", " + tool.ConvertFloat(TXT_B42.Text) + "," + tool.ConvertFloat(TXT_B43.Text) + "," + 
					tool.ConvertFloat(TXT_B44.Text) + "," + tool.ConvertFloat(TXT_B45.Text) + ", " + tool.ConvertFloat(TXT_B46.Text) + "," + tool.ConvertFloat(TXT_B47.Text) + "," +
					tool.ConvertFloat(TXT_B48.Text) + "," + tool.ConvertFloat(TXT_B49.Text) + "," + tool.ConvertFloat(TXT_B50.Text) + "," + tool.ConvertFloat(TXT_B51.Text) + "," +
					tool.ConvertFloat(TXT_B52.Text) + "," + tool.ConvertFloat(TXT_B53.Text) + "," + tool.ConvertFloat(TXT_B54.Text) + "," + tool.ConvertFloat(TXT_B55.Text) + ",'" + LBL_SUMBERDATA.Text + "',''";			
				conn.ExecuteNonQuery();
			}

			if (TXT_C5.Text != "")
			{
				conn.QueryString = "exec ca_labarugi_small_sp '" + a + "','" + Request.QueryString["regno"] + "'," + GlobalTools.ToSQLDate(TXT_TGL_C1.Text,DDL_BLN_C1.SelectedValue,TXT_YEAR_C1.Text) + "," + tool.ConvertNum(TXT_C2.Text) + ",'" + DDL_C3.SelectedValue + "'," + 
					tool.ConvertFloat(TXT_C39.Text) + "," +
					tool.ConvertFloat(TXT_C40.Text) + "," + tool.ConvertFloat(TXT_C41.Text) + ", " + tool.ConvertFloat(TXT_C42.Text) + "," + tool.ConvertFloat(TXT_C43.Text) + "," + 
					tool.ConvertFloat(TXT_C44.Text) + "," + tool.ConvertFloat(TXT_C45.Text) + ", " + tool.ConvertFloat(TXT_C46.Text) + "," + tool.ConvertFloat(TXT_C47.Text) + "," +
					tool.ConvertFloat(TXT_C48.Text) + "," + tool.ConvertFloat(TXT_C49.Text) + "," + tool.ConvertFloat(TXT_C50.Text) + "," + tool.ConvertFloat(TXT_C51.Text) + "," +
					tool.ConvertFloat(TXT_C52.Text) + "," + tool.ConvertFloat(TXT_C53.Text) + "," + tool.ConvertFloat(TXT_C54.Text) + "," + tool.ConvertFloat(TXT_C55.Text) + ",'" + LBL_SUMBERDATA.Text + "',''";			
				conn.ExecuteNonQuery();
			}

			if (TXT_D5.Text != "")
			{
				string temp = "-";
				conn.QueryString = "exec ca_labarugi_small_sp '" + a + "','" + Request.QueryString["regno"] + "'," + GlobalTools.ToSQLDate(TXT_TGL_D1.Text,DDL_BLN_D1.SelectedValue,TXT_YEAR_D1.Text) + "," + tool.ConvertNum(TXT_D2.Text) + ",'" + temp + "'," + 
					tool.ConvertFloat(TXT_D39.Text) + "," +
					tool.ConvertFloat(TXT_D40.Text) + "," + tool.ConvertFloat(TXT_D41.Text) + ", " + tool.ConvertFloat(TXT_D42.Text) + "," + tool.ConvertFloat(TXT_D43.Text) + "," + 
					tool.ConvertFloat(TXT_D44.Text) + "," + tool.ConvertFloat(TXT_D45.Text) + ", " + tool.ConvertFloat(TXT_D46.Text) + "," + tool.ConvertFloat(TXT_D47.Text) + "," +
					tool.ConvertFloat(TXT_D48.Text) + "," + tool.ConvertFloat(TXT_D49.Text) + "," + tool.ConvertFloat(TXT_D50.Text) + "," + tool.ConvertFloat(TXT_D51.Text) + "," +
					tool.ConvertFloat(TXT_D52.Text) + "," + tool.ConvertFloat(TXT_D53.Text) + "," + tool.ConvertFloat(TXT_D54.Text) + "," + tool.ConvertFloat(TXT_D55.Text) + ",'" + LBL_SUMBERDATA.Text + "','1'";
				conn.ExecuteNonQuery();
			}
		}
		

		private void DG_Neraca1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;
			switch (cmd)
			{		  
				case "retrieve" :
					string vtemp = e.Item.Cells[3].Text;
					Response.Redirect("Neraca_KMK_KI_small.aspx?tahun=" + vtemp +"&mode=retrieve&regno="+
						Request.QueryString["regno"]+"&mc="+Request.QueryString["mc"]+"&bussunitid="+
						Request.QueryString["bussunitid"]+"&programid="+Request.QueryString["programid"]+
						"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&curef="+Request.QueryString["curef"]+
						"&tc="+Request.QueryString["tc"]+"&viewmode="+Request.QueryString["viewmode"]+
						"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]);
					clear_field();
					retrieve_data();
					break;
				case "delete" :
					conn.QueryString = "exec ca_neraca_small_sp_delete '" + Request.QueryString["curef"]+ "','" + Request.QueryString["regno"]+ "'," +
						GlobalTools.ToSQLDate(e.Item.Cells[4].Text) + ",'" + e.Item.Cells[1].Text + "','" + e.Item.Cells[2].Text + "'";
					conn.ExecuteNonQuery();

					//delete ratio as well 
					CLS_CALCULATION.delete_ratio_small(Request.QueryString["regno"],conn);
					
					clear_field();
					ViewData();
					break;
				default :
					break;
			}
		}

		private void clear_field()
		{
			int cnt;
				
			conn.QueryString = "select CU_REF,AP_REGNO,POSISI_TGL,JML_BLN,JNS_LAP,SALES_ONCREDIT,AKTV_KASBANK,AKTV_PIUDGN,AKTV_PERSEDIAAN" +
				",AKTV_LCRLAIN,AKTV_TTLAKTLCR,AKTV_TNHBGN,AKTV_MSNALAT,AKTV_INVKNDRN,AKTV_TTPLAIN,AKTV_AKUMSUSUT" +
				",AKTV_NETAKTVTTP,AKTV_BIAYATANGGUH,AKTV_AKUMAMOR,AKTV_AKTVLAIN,AKTV_TTLAKTVLAIN,AKTV_TTLAKTV" +
				",PASV_HTDG,PASV_HTBANK,PASV_KIJTHTEMPO,PASV_HTLNCR,PASV_TTLHTLNCR,PASV_HTJKPJG,PASV_HTPMGANGSHM" +
				",PASV_JKPJGLAIN,PASV_TTLHTJKPJG,PASV_TTLHT,PASV_MODALSTR,PASV_LBRG,PASV_TTLMODAL,PASV_TTLPASIVA" +
				",IS_CURRENCY,IS_DENOMINATOR,SUMBERDATA,IS_PROYEKSI from ca_neraca_small where ap_regno = '" + Request.QueryString["regno"] + "' order by posisi_tgl desc";
			conn.ExecuteQuery();
			cnt = conn.GetRowCount();

			conn.QueryString="select excel_field from ca_excel where excel_file = 'kmk_ki_small' and excel_type = 'bs'";
			conn.ExecuteQuery();
				
			int row = 69;
			//for (int i = 0; i < cnt; i++)
			//TO DO :
			for (int i = 0; i < 3; i++)
			{
				row--;
				string vtmp = ((char)row).ToString();
				
				//for (int m=1;m<=conn.GetRowCount();m++)
				for (int m=1;m<=34;m++)
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
			initTgl();
		}


		private void clear_field_history(string vtahun)
		{
			int cnt;
				
			conn.QueryString = "select CU_REF,AP_REGNO,POSISI_TGL,JML_BLN,JNS_LAP,SALES_ONCREDIT,AKTV_KASBANK,AKTV_PIUDGN,AKTV_PERSEDIAAN" +
				",AKTV_LCRLAIN,AKTV_TTLAKTLCR,AKTV_TNHBGN,AKTV_MSNALAT,AKTV_INVKNDRN,AKTV_TTPLAIN,AKTV_AKUMSUSUT" +
				",AKTV_NETAKTVTTP,AKTV_BIAYATANGGUH,AKTV_AKUMAMOR,AKTV_AKTVLAIN,AKTV_TTLAKTVLAIN,AKTV_TTLAKTV" +
				",PASV_HTDG,PASV_HTBANK,PASV_KIJTHTEMPO,PASV_HTLNCR,PASV_TTLHTLNCR,PASV_HTJKPJG,PASV_HTPMGANGSHM" +
				",PASV_JKPJGLAIN,PASV_TTLHTJKPJG,PASV_TTLHT,PASV_MODALSTR,PASV_LBRG,PASV_TTLMODAL,PASV_TTLPASIVA" +
				",IS_CURRENCY,IS_DENOMINATOR,SUMBERDATA,IS_PROYEKSI from ca_neraca_small where year(posisi_tgl) > '" + vtahun + "' and ap_regno = '" + Request.QueryString["regno"]+ "'";
			conn.ExecuteQuery();
			cnt = conn.GetRowCount();

			conn.QueryString="select excel_field from ca_excel where excel_file = 'kmk_ki_small' and excel_type = 'bs'";
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
			initTgl();
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

			return true;
		}

		protected void BTN_SIMPANSAJA_Click(object sender, System.EventArgs e)
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

			CLS_CALCULATION.proses_calculate_small(this, Request.QueryString["regno"], Request.QueryString["curef"], conn);

			LBL_SUMBERDATA.Text = "";
		}


		private void ViewFileUpload()
		{
			conn.QueryString = "select distinct XLS_DIR from CA_EXCEL_TEMPLATE";
			conn.ExecuteQuery();
			string path = "../" + conn.GetFieldValue("XLS_DIR").ToString().Trim().Replace("\\", "/");
			
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
			double ukuranFile = 0.0;
			for (int i = 0; i < uploadedFiles.Count; i++)
			{
				HttpPostedFile userPostedFile = uploadedFiles[i];
				
				const int byteConversion = 1024;
				double bytes = Convert.ToDouble(uploadedFiles[i].ContentLength);
				ukuranFile = Math.Round(bytes / Math.Pow(byteConversion, 2), 2);

				if(ukuranFile <= 0.05)
				{
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
				else
				{
					LBL_STATUSREPORT.Text = "Upload gagal ! File yang Anda upload melebihi batas 50 kb !";
				}
			}		
			
			
			/********************************/
			if(ukuranFile <= 0.05)
			{
				vdir = Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName);
				//viewExcel(vdir);
				//viewExcel_LabaRugi(vdir);

                Dictionary<string, string> theresult = new Dictionary<string,string>();

                client.Neraca_KMK_KI_SMALLASPXviewExcel(out theresult, vdir, Request.QueryString["regno"], Session["USERID"].ToString());

                for (int i = 0; i < theresult.Keys.Count; i++)
                {
                    string ID_CONTROL = theresult.Keys.ElementAt(i);

                    System.Web.UI.Control controls = this.Page.FindControl(ID_CONTROL);
                    if (controls is System.Web.UI.WebControls.TextBox)
                    {
                        ((System.Web.UI.WebControls.TextBox)controls).Text = theresult[ID_CONTROL];
                    }
                }

                client.Neraca_KMK_KI_SMALLASPXviewExcel_LabaRugi(out theresult, vdir, Request.QueryString["regno"], Session["USERID"].ToString());

                for (int i = 0; i < theresult.Keys.Count; i++)
                {
                    string ID_CONTROL = theresult.Keys.ElementAt(i);

                    System.Web.UI.Control controls = this.Page.FindControl(ID_CONTROL);
                    if (controls is System.Web.UI.WebControls.TextBox)
                    {
                        ((System.Web.UI.WebControls.TextBox)controls).Text = theresult[ID_CONTROL];
                    }
                }
			}
			/********************************/

		}

		private void DatGrid_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete" :
					/// function untuk delete file
					/// 
					conn.QueryString = "exec CA_FILEUPLOADXL_SP '" +Request.QueryString["regno"]+ "', '" +e.Item.Cells[0].Text+ "','','','2'";
					conn.ExecuteNonQuery();

					ViewFileUpload();
					break;
			}
		}

		private void DG_NeracaHistory_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;

			switch (cmd)
			{
				case "retrieve_history" :
					string regno = e.Item.Cells[0].Text,
						tahun = e.Item.Cells[4].Text;
					//retrieve_datahistory(vtemp,"retrieve_history");	//changed by nyoman
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
		
		private void retrieve_datahistory(string vtahun, string mode)
		{
			if (mode == "retrieve_history")
			{
				clear_field_history(vtahun);
				/********* start retrieve **************************/
				System.Data.DataTable dt = new System.Data.DataTable();
				conn.QueryString = "select CU_REF,AP_REGNO,BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,BS_SALES_ONCR,BS_CASH_BANK,BS_MARKET_SECUR" +
					",BS_AR,BS_AR_FRAFFIL,BS_INVENTORY,BS_OTH_CURASST,BS_PREPAID_EXP,BS_CURRASST,BS_NETFIXASST,BS_INVESTMENT" +
					",BS_NONCA,BS_NI,BS_TTL_NONCA,BS_TTL_ASST,BS_DBST,BS_AP,BS_AP_TOAFFL,BS_ACCRUALS,BS_TAXPAY,BS_OTH_CURLIAB" +
					",BS_CURR_PORTLTDEBT,BS_CURR_LIAB,BS_LONGTERM_DEBT,BS_OTH_LIAB,BS_LONGTERM_LIAB,BS_TTL_LIAB" +
					",BS_CMN_STK,BS_SURP_RESRV,BS_RET_EARN,BS_TTL_NETWORTH,BS_LIAB_NETWORTH,BS_CURRENCY,BS_DENOMINATOR" +
					",BS_SUMBERDATA,BS_ISPROYEKSI from ca_neraca_middle where year(bs_date_periode) <= '" + vtahun + "' and ap_regno = '" + Request.QueryString["regno"]+ "'";
				conn.ExecuteQuery();
				int jml_baris = conn.GetRowCount();
				
				dt = conn.GetDataTable().Copy();
				
				int hrf = 68;
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
							GlobalTools.fillDateForm(TXT_TGL_, DDL_BLN_, TXT_YEAR_, excdatestr);
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
							txt.Text = dt.Rows[ii][start].ToString();
						}
						if (start==4){ continue; }
					}
					
					
					/**** separator ****/
					
					for (int nnn=5;nnn<35;nnn++)
					{
						int temp = 0;
						System.Web.UI.WebControls.TextBox teksboks = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_" + vtmpe + nnn.ToString());				
						if (nnn == 5) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][6].ToString()); }
						else if (nnn == 6) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][8].ToString()); }
						else if (nnn == 7) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][10].ToString()); }
						else if (nnn == 8) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][11].ToString()); }
						else if (nnn == 9) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][13].ToString()); }
						else if (nnn == 15) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][14].ToString()); }
						else if (nnn == 19) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][18].ToString()); }
						else if (nnn == 20) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][19].ToString()); }
							/******/
						else if (nnn == 21) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][21].ToString()); }
						else if (nnn == 22) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][20].ToString()); }
						else if (nnn == 24) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][25].ToString()); }
						else if (nnn == 25) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][27].ToString()); }
						else if (nnn == 28) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][28].ToString()); }
						else if (nnn == 29) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][29].ToString()); }
						else if (nnn == 30) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][31].ToString()); }
						else if (nnn == 31) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][33].ToString()); }
						else if (nnn == 32) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][34].ToString()); }
						else if (nnn == 33) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][35].ToString()); }
						else if (nnn == 34) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][36].ToString()); }
						else { teksboks.Text = temp.ToString(); }
					}
					if (hrf<=66) // if < B keluar..
					{
						break;
					}
				}

			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			clear_field();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//Response.Redirect("../" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
			Response.Redirect("../" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn));
		}

		private void BTN_PROSES_Click(object sender, System.EventArgs e)
		{
			//proses_calculate();
		}
	
		private void readonly_teksbox()
		{
			conn.QueryString = "select excel_cell1,excel_cell2,excel_cell3 from ca_excel where table_name = 'ca_neraca_small' " +
				" and excel_field in ('AKTV_TTLAKTLCR','AKTV_NETAKTVTTP','AKTV_TTLAKTVLAIN','AKTV_TTLAKTV','PASV_TTLHTLNCR','PASV_TTLHTJKPJG' " +  
				",'PASV_TTLHT','PASV_TTLMODAL','PASV_TTLPASIVA')";
			conn.ExecuteQuery();	
			 
			for(int i=0; i < conn.GetRowCount(); i++) 
			{
				System.Web.UI.WebControls.TextBox TXT_B = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + conn.GetFieldValue(i,0));
				System.Web.UI.WebControls.TextBox TXT_C = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + conn.GetFieldValue(i,1));
				System.Web.UI.WebControls.TextBox TXT_D = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + conn.GetFieldValue(i,2));
			    
				TXT_B.BackColor = Color.Gainsboro;
				//TXT_B.ReadOnly = true;
                TXT_B.Attributes.Add("readonly", "readonly");

				TXT_C.BackColor = Color.Gainsboro;
				//TXT_C.ReadOnly = true;
                TXT_C.Attributes.Add("readonly", "readonly");

				TXT_D.BackColor = Color.Gainsboro;
				//TXT_D.ReadOnly = true;
                TXT_D.Attributes.Add("readonly", "readonly");
			}
		}
	
		private void DatGrid_ItemCommand_1(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
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

            EditedRender = EditedRender.Replace("(document." + this.Form.ID + "." + element + ")", "(document.getElementById('" + element + "'))");

            return EditedRender;
        }


	}
}