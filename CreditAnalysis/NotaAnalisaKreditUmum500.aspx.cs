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
using Excel;

namespace SME.CreditAnalysis
{
	/// <summary>
	/// Summary description for Neraca_KMK_KI_500JT_2M.
	/// </summary>
	public partial class NotaAnalisaKreditUmum500 : System.Web.UI.Page
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
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = new Connection("Data Source=(local);Initial Catalog=SME1;uid=sa;pwd=;Pooling=true");
			//viewdata();
			if(!IsPostBack)
			{
				viewdata();
				retrieve_data();
			}
			ViewMenu();
			ViewSubMenu();

			BTN_EXP2EXCEL.Attributes.Add("onclick", "if (!exportInProgress()) { return false; }");
		}
		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
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
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
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
				conn.QueryString = "select * from SCREENSUBMENU where menucode = '"+Request.QueryString["mc"]+
					"'and bussunitid= '"+Request.QueryString["bussunitid"]+"' and programid = '" + Request.QueryString["programid"]  +"'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 4);
					string strtemp = "";
					//					if (conn.GetFieldValue(i, 5).Trim()!= "") 
					//					{
					//						if (conn.GetFieldValue(i,5).IndexOf("mc=") >= 0)
					//							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
					//						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
					//						//t.ForeColor = Color.MidnightBlue; 
					//					}
					//					else 
					//					{
					//						strtemp = "";
					//						t.ForeColor = Color.Red; 
					//					}
					strtemp = "regno=" + Request.QueryString["regno"] + "&mc="+Request.QueryString["mc"]+"&bussunitid="+Request.QueryString["bussunitid"]+"&programid="+Request.QueryString["programid"];
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
		private void viewdata()
		{
			conn.QueryString = "select POSISI_TGL,JML_BLN from CA_NERACA_SMALL order by POSISI_TGL desc";
			conn.ExecuteQuery();
			DG_Neraca1.DataSource = conn.GetDataTable().Copy();
			DG_Neraca1.DataBind();
			for(int i = 0; i < DG_Neraca1.Items.Count; i++)
			{
				DG_Neraca1.Items[i].Cells[0].Text = tool.FormatDate(DG_Neraca1.Items[i].Cells[0].Text);
			}
		}

		

		private void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			
		}

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			viewExcel();
		}
		private void viewExcel(){
			conn.QueryString = "select EXCEL_SHEET, EXCEL_FIELD, LEFT(EXCEL_CELL1,1) AS STR1, LEFT(EXCEL_CELL2,1) AS STR2, LEFT(EXCEL_CELL3,1) STR3, LEFT(EXCEL_CELL4,1) AS STR4 from ca_excel where excel_file = 'kmk_ki_small' and excel_type = 'BS'";
			conn.ExecuteQuery();

			Excel.Application excelApp = new Excel.ApplicationClass();
			excelApp.Visible = false;
			excelApp.DisplayAlerts = false;
			Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(File1.Value,
				0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t",
				false, false, 0, false);
			Excel.Sheets excelSheets = excelWorkbook.Worksheets;
			string currentSheet = conn.GetFieldValue("Excel_Sheet").ToString();
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
					if (j%2==0)
					{
//						TXT_.Text = excelB2.Value.ToString();
						TXT_.Text = excelB2.Value2.ToString();
					}

					else 
					{
						//TXT_.Text = tool.FormatDate(excelB2.Value.ToString());
						TXT_.Text = excelB2.Text.ToString();
					}
				}
			}
			/*--------------------- separator ---------------------------------------------------------------*/
			// loop utk cash bank sampe liabilities net worth, lihat excel !!!!!!
			for (int m=66;m<69;m++)
			{
				for (int n=3;n<=conn.GetRowCount();n++) 
				{ 
					string vRange = ((char)m).ToString()+n; 
					Excel.Range excelCell = (Excel.Range)excelWorksheet.get_Range(vRange, vRange);
					System.Web.UI.WebControls.TextBox TXT_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_" + vRange);
					//TXT_.Text = tool.MoneyFormat(excelCell.Value.ToString());
					if (n==3 || n==4)
					{
						TXT_.Text = excelCell.Text.ToString();
					}	
					else 
					{
						TXT_.Text = tool.MoneyFormat(excelCell.Value2.ToString());
					}
				}
			}
			/*--------------------- separator ---------------------------------------------------------------*/
			excelWorkbook.Close(null,null,null);
			excelApp.Workbooks.Close();
			excelApp.Application.Quit();
			excelApp.Quit();
			excelWorkbook = null;
			excelApp = null;
		
		}
	
	/* ----------------------------- start retrieve data -------------------------------------------------------------- */
		private void retrieve_data()
		{
			int jmlrow;
			conn.QueryString = "select excel_field from ca_excel where excel_file = 'kmk_ki_small' and excel_type = 'bs'";
			conn.ExecuteQuery();
			jmlrow = conn.GetRowCount();

			conn.QueryString = "select * from ca_neraca_middle where year(bs_date_periode) <= '" + Request.QueryString["tahun"] + "'";
			conn.ExecuteQuery();

			int row = 65;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				
				row++;
				string vtmp = ((char)row).ToString();
				int k = 5;

				for (int m=1;m<3;m++)
				{
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
					if (Request.QueryString["mode"]=="retrieve")
					{
						if (m%2==0)
						{
							txt.Text = conn.GetFieldValue(i, m);
						} 
						else 
						{
							txt.Text = tool.FormatDate(conn.GetFieldValue(i, m));
						
						}			
					} 
					else 
					{
						txt.Text = "";
					}
				}
	
				for (int j = 4; j <= jmlrow; j++)
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + j.ToString());
					if (Request.QueryString["mode"]=="retrieve")
					{
						txt.Text = conn.GetFieldValue(i, k);
					}
					else 
					{
						txt.Text = "";
					}
					k++;
				}
			}

		}	
	/* ----------------------------- end retrieve data -------------------------------------------------------------- */
	/* ------------------------------ START SIMPAN DATA KE TABEL CA_MERACA_SMALL ------------------------------------------- */
		private void save_neraca()
		{
			conn.QueryString = "Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
			string a = conn.GetFieldValue("cu_ref").ToString();
			conn.QueryString = "exec ca_neraca_small_sp '" + a + "','" + tool.FormatDate_GetDate(TXT_B1.Text) + "','" + TXT_B2.Text + "','" + TXT_B3.Text + "'," + TXT_B4.Text + "," +
				tool.ConvertFloat(TXT_B5.Text) + "," + tool.ConvertFloat(TXT_B6.Text) + ", " + tool.ConvertFloat(TXT_B7.Text) + "," + tool.ConvertFloat(TXT_B8.Text) + "," + 
				tool.ConvertFloat(TXT_B9.Text) + "," + tool.ConvertFloat(TXT_B10.Text) + ", " + tool.ConvertFloat(TXT_B11.Text) + "," + tool.ConvertFloat(TXT_B12.Text) + "," +
				tool.ConvertFloat(TXT_B13.Text) + "," + tool.ConvertFloat(TXT_B14.Text) + "," + tool.ConvertFloat(TXT_B15.Text) + "," + tool.ConvertFloat(TXT_B16.Text) + "," +
				tool.ConvertFloat(TXT_B17.Text) + "," + tool.ConvertFloat(TXT_B18.Text) + "," + tool.ConvertFloat(TXT_B19.Text) + "," + tool.ConvertFloat(TXT_B20.Text) + "," +
				tool.ConvertFloat(TXT_B21.Text) + "," + tool.ConvertFloat(TXT_B22.Text) + "," + tool.ConvertFloat(TXT_B23.Text) + "," + tool.ConvertFloat(TXT_B24.Text) + "," +
				tool.ConvertFloat(TXT_B25.Text) + "," + tool.ConvertFloat(TXT_B26.Text) + "," + tool.ConvertFloat(TXT_B27.Text) + "," + tool.ConvertFloat(TXT_B28.Text) + "," +
				tool.ConvertFloat(TXT_B29.Text) + "," + tool.ConvertFloat(TXT_B30.Text) + "," + tool.ConvertFloat(TXT_B31.Text) + "," + tool.ConvertFloat(TXT_B32.Text) + "," +
				tool.ConvertFloat(TXT_B33.Text) + "," + tool.ConvertFloat(TXT_B34.Text) + "";			
			conn.ExecuteNonQuery();
			/* --------------------------- 
			conn.QueryString = "exec ca_neraca_small_sp '" + a + "','" + tool.FormatDate_GetDate(TXT_C1.Text) + "','" + TXT_C2.Text + "','" + TXT_C3.Text + "'," + TXT_C4.Text + "," +
				tool.ConvertFloat(TXT_C5.Text) + "," + tool.ConvertFloat(TXT_C6.Text) + ", " + tool.ConvertFloat(TXT_C7.Text) + "," + tool.ConvertFloat(TXT_C8.Text) + "," + 
				tool.ConvertFloat(TXT_C9.Text) + "," + tool.ConvertFloat(TXT_C10.Text) + ", " + tool.ConvertFloat(TXT_C11.Text) + "," + tool.ConvertFloat(TXT_C12.Text) + "," +
				tool.ConvertFloat(TXT_C13.Text) + "," + tool.ConvertFloat(TXT_C14.Text) + "," + tool.ConvertFloat(TXT_C15.Text) + "," + tool.ConvertFloat(TXT_C16.Text) + "," +
				tool.ConvertFloat(TXT_C17.Text) + "," + tool.ConvertFloat(TXT_C18.Text) + "," + tool.ConvertFloat(TXT_C19.Text) + "," + tool.ConvertFloat(TXT_C20.Text) + "," +
				tool.ConvertFloat(TXT_C21.Text) + "," + tool.ConvertFloat(TXT_C22.Text) + "," + tool.ConvertFloat(TXT_C23.Text) + "," + tool.ConvertFloat(TXT_C24.Text) + "," +
				tool.ConvertFloat(TXT_C25.Text) + "," + tool.ConvertFloat(TXT_C26.Text) + "," + tool.ConvertFloat(TXT_C27.Text) + "," + tool.ConvertFloat(TXT_C28.Text) + "," +
				tool.ConvertFloat(TXT_C29.Text) + "," + tool.ConvertFloat(TXT_C30.Text) + "," + tool.ConvertFloat(TXT_C31.Text) + "," + tool.ConvertFloat(TXT_C32.Text) + "," +
				tool.ConvertFloat(TXT_C33.Text) + "," + tool.ConvertFloat(TXT_C34.Text) + "";			
			conn.ExecuteNonQuery();
			conn.QueryString = "exec ca_neraca_small_sp '" + a + "','" + tool.FormatDate_GetDate(TXT_D1.Text) + "','" + TXT_D2.Text + "','" + TXT_D3.Text + "'," + TXT_D4.Text + "," +
				tool.ConvertFloat(TXT_D5.Text) + "," + tool.ConvertFloat(TXT_D6.Text) + ", " + tool.ConvertFloat(TXT_D7.Text) + "," + tool.ConvertFloat(TXT_D8.Text) + "," + 
				tool.ConvertFloat(TXT_D9.Text) + "," + tool.ConvertFloat(TXT_D10.Text) + ", " + tool.ConvertFloat(TXT_D11.Text) + "," + tool.ConvertFloat(TXT_D12.Text) + "," +
				tool.ConvertFloat(TXT_D13.Text) + "," + tool.ConvertFloat(TXT_D14.Text) + "," + tool.ConvertFloat(TXT_D15.Text) + "," + tool.ConvertFloat(TXT_D16.Text) + "," +
				tool.ConvertFloat(TXT_D17.Text) + "," + tool.ConvertFloat(TXT_D18.Text) + "," + tool.ConvertFloat(TXT_D19.Text) + "," + tool.ConvertFloat(TXT_D20.Text) + "," +
				tool.ConvertFloat(TXT_D21.Text) + "," + tool.ConvertFloat(TXT_D22.Text) + "," + tool.ConvertFloat(TXT_D23.Text) + "," + tool.ConvertFloat(TXT_D24.Text) + "," +
				tool.ConvertFloat(TXT_D25.Text) + "," + tool.ConvertFloat(TXT_D26.Text) + "," + tool.ConvertFloat(TXT_D27.Text) + "," + tool.ConvertFloat(TXT_D28.Text) + "," +
				tool.ConvertFloat(TXT_D29.Text) + "," + tool.ConvertFloat(TXT_D30.Text) + "," + tool.ConvertFloat(TXT_D31.Text) + "," + tool.ConvertFloat(TXT_D32.Text) + "," +
				tool.ConvertFloat(TXT_D33.Text) + "," + tool.ConvertFloat(TXT_D34.Text) + "";			
			conn.ExecuteNonQuery();
			separator ------------------------------------------------------*/
			viewdata();
			//Tools.popMessage(this,"Proses Selesai.");
		}
/* ------------------------------ END SIMPAN DATA KE TABEL CA_MERACA_SMALL ------------------------------------------- */	
		/* ---------------------- start export 2 excel ------------------------------- */
		protected void BTN_EXP2EXCEL_Click(object sender, System.EventArgs e)
		{
			
			Excel.Application excelApp = new Excel.ApplicationClass();
			excelApp.Visible = false;
			excelApp.DisplayAlerts = false;
			string path=@"c:\test\coba.xlt";
			Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(path,
				0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t",
				false, false, 0, false);
			Excel.Sheets excelSheets = excelWorkbook.Worksheets;
			
			string currentSheet = "Nota Analisa";
			Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheets.get_Item(currentSheet);
			Excel.Range excelCell = (Excel.Range)excelWorksheet.get_Range("N11","N11");
			excelCell.Value2 = TXT_B3.Text;
	
			string workbookPath = @"c:\test\test3.xls";
			excelWorkbook.SaveAs(workbookPath, Excel.XlFileFormat.xlWorkbookNormal,null,null,null,null,Excel.XlSaveAsAccessMode.xlNoChange,null,null,null, true); 
			excelWorkbook.Close(null,null,null);
			excelApp.Workbooks.Close();
			excelApp.Application.Quit();
			excelApp.Quit();
		}

		protected void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
			
		}
		/* ---------------------- end export 2 excel ------------------------------- */
	}
}
