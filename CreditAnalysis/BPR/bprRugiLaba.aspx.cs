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
using System.IO;


namespace SME.CreditAnalysis.BPR
{
	/// <summary>
	/// Summary description for bprRugiLaba.
	/// </summary>
	public partial class bprRugiLaba : System.Web.UI.Page
	{
		
		protected Connection conn;
		//protected Tools tool = new Tools();
	

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			
			if(!IsPostBack)
			{
				IsiTanggal();
				ViewData();	
				viewdata_history();
				RetrieveData();
			}
			ViewMenu();
			ViewSubMenu();
			
			//ViewGridExcel();
			//ViewFileUpload();

			secureData();

			btn_Save.Attributes.Add("onclick","if(!cek_key('labarugi')){return false;};");
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
			DG_NeracaHistory.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(DG_NeracaHistory_ItemCommand);
			dg_Neraca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(dg_Neraca_ItemCommand);

		}
		#endregion

		private void ViewData()
		{
			conn.QueryString = "Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
			string a = conn.GetFieldValue("cu_ref").ToString();

			conn.QueryString = "select POSISI_TGL,JML_BLN from BPR_LABARUGI WHERE CU_REF = '"+a+"' and ap_regno = '" +Request.QueryString["regno"]+ "' order by POSISI_TGL desc";
			conn.ExecuteQuery();
			dg_Neraca.DataSource = conn.GetDataTable().Copy();
			dg_Neraca.DataBind();
			for(int i = 0; i < dg_Neraca.Items.Count; i++)
			{
				dg_Neraca.Items[i].Cells[0].Text = GlobalTools.FormatDate(dg_Neraca.Items[i].Cells[0].Text);
				
			}
		}
		
		private void viewdata_history()
		{
			conn.QueryString = "exec BPR_NERACA_HISTORY '" + Request.QueryString["curef"] + "', '" +
				Request.QueryString["regno"] + "' ";
			conn.ExecuteQuery();
			
			DG_NeracaHistory.DataSource = conn.GetDataTable().Copy();
			DG_NeracaHistory.DataBind();
			for(int i = 0; i < DG_NeracaHistory.Items.Count; i++)
			{
				DG_NeracaHistory.Items[i].Cells[1].Text = GlobalTools.FormatDate(DG_NeracaHistory.Items[i].Cells[1].Text);
			}
		}

		/*
		private void ViewGridExcel()
		{
			string a = "BPRF";
			conn.QueryString = "select seq, excel_name,location from ca_excel_template where lg_code ='" + a + "'";
			conn.ExecuteQuery();
			dg_Excel.DataSource = conn.GetDataTable().Copy();
			dg_Excel.DataBind();
			for(int i = 0; i < dg_Excel.Items.Count; i++)
			{
				HyperLink Hp = (HyperLink) dg_Excel.Items[i].Cells[3].FindControl("HL_DOWNLOAD");
				Hp.NavigateUrl = dg_Excel.Items[i].Cells[2].Text.Trim();
			}
		}	
		*/

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
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
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
				string temp = ex.ToString().Replace("'","");
				Response.Write("<script language='javascript'>alert('"+temp+"');</script>");
			}
		}
		
		
		private void ViewSubMenu()
		{
			/*
			try 
			{
				conn.QueryString = "select * from screensubmenu where lg_code in (select distinct lg_code from rfcafinstatement where programid = '"+Request.QueryString["programid"]+"' and nasabahid = '" +Request.QueryString["jnsnasabah"]+"') and menucode = '" +Request.QueryString["mc"]+ "' and programid = '"+Request.QueryString["programid"]+"'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 4);
					string strtemp = "";
					strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"];
					t.NavigateUrl = conn.GetFieldValue(i, 5)+strtemp;
					SubMenu.Controls.Add(t);
					SubMenu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString().Replace("'","");
				Response.Write("<script language='javascript'>alert('"+temp+"');</script>");
			}
			*/
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
		
				conn.QueryString = "select distinct m.MENUCODE,m.BUSSUNITID,m.PROGRAMID,m.PROGRAMID_SEQ,m.SM_MENUDISPLAY,m.SM_LINKNAME,m.LG_CODE " +
					" from screensubmenu m " +
					" left join rfcafinstatement fin on fin.programid = m.programid and fin.lg_code= m.lg_code " +
					" where m.programid = '" + programid + "' " +
					" and fin.nasabahid = '" + jnsnasabah + "' and m.menucode = '" + Request.QueryString["mc"] + "'";
				conn.ExecuteQuery();

				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 4);
					string strtemp = "";
					strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&tc="+Request.QueryString["tc"]+"&tahun="+Request.QueryString["tahun"]+"&mode="+Request.QueryString["mode"];
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

		
		private void ViewExcel(string dir)
		{
			//			string vPath;
			//			string a = "BPRF";
			//
			//			conn.QueryString = "select xls_root,xls_dir,excel_name from ca_excel_template where lg_code = '" + a + "'";
			//			conn.ExecuteQuery();
			//			vPath = conn.GetFieldValue("xls_root").ToString().Trim()+ conn.GetFieldValue("xls_dir").ToString().Trim()+conn.GetFieldValue("excel_name").ToString().Trim();

			string vPath;
			conn.QueryString = "select xls_dir+''+fu_filename as filexls from CA_FILEUPLOADXL where fu_filename = '"+Request.QueryString["regno"]+"-"+Session["USERID"]+"-"+dir+"'";
			conn.ExecuteQuery();
			vPath = conn.GetFieldValue("filexls");


			System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
			System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
 
			Excel.Application excelApp = new Excel.ApplicationClass();
			
			excelApp.Visible = false;
			excelApp.DisplayAlerts = false;
			Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(vPath, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows,"\t", false, false, 0, true); 
			Excel.Sheets excelSheets = excelWorkbook.Worksheets;

			string currentSheet = "SME";
			Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheets.get_Item(currentSheet);
			
			for (int i=66;i<69;i++) 
			{
				for (int j=29;j<=31;j++)
				{
					string vtmp = ((char)i).ToString()+j; //i=66 diconvert ke ascci jd huruf B, di concat dgn j hasilnya B1,B2,C1,C2
					Excel.Range excelB2 = (Excel.Range)excelWorksheet.get_Range(vtmp, vtmp);

					System.Web.UI.WebControls.TextBox txt_DD_ = (System.Web.UI.WebControls.TextBox) Page.FindControl("txt_DD_" + vtmp);
					System.Web.UI.WebControls.DropDownList ddl_MM_ = (System.Web.UI.WebControls.DropDownList) Page.FindControl("ddl_MM_" + vtmp);
					System.Web.UI.WebControls.TextBox txt_YY_ = (System.Web.UI.WebControls.TextBox) Page.FindControl("txt_YY_" + vtmp);
					System.Web.UI.WebControls.TextBox txt_ = (System.Web.UI.WebControls.TextBox) Page.FindControl("txt_" + vtmp);

					System.Web.UI.WebControls.DropDownList ddl_ = (System.Web.UI.WebControls.DropDownList) Page.FindControl("ddl_" + vtmp);

					if (j==29)
					{
						DateTime tgl = DateTime.Parse(GlobalTools.FormatDate(excelB2.Value.ToString()));
						try {GlobalTools.fillDateForm(txt_DD_, ddl_MM_, txt_YY_, tgl);}
						catch {}
					}
					else if (j==30)
					{
						try {txt_.Text = GlobalTools.ConvertFloat(excelB2.Value2.ToString());}
						catch {}
					}
					else if (j==31)
					{
						try {ddl_.SelectedValue = excelB2.Value2.ToString();}
						catch {}
					}
				}
			}
			//------------------------------------------------------------------------------------
			for (int m=66;m<69;m++)
			{
				//for (int n=3;n<=conn.GetRowCount();n++) 
				for (int n=31;n<=60;n++) 
				{ 
					string vRange = ((char)m).ToString()+n; 
					Excel.Range excelCell = (Excel.Range)excelWorksheet.get_Range(vRange, vRange);
					System.Web.UI.WebControls.TextBox txt_ = (System.Web.UI.WebControls.TextBox) Page.FindControl("txt_" + vRange);
					
					try {txt_.Text = formatMoney_ind(excelCell.Value2.ToString());}
					catch {}
				}
			}
			//------------------------------------------------------------------------------------
			excelWorkbook.Close(null,null,null);
			excelApp.Workbooks.Close();
			excelApp.Application.Quit();
			excelApp.Quit();
			System.Runtime.InteropServices.Marshal.ReleaseComObject(excelSheets); 
			System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook); 
			System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp); 
			excelSheets = null; 
			excelWorkbook = null; 
			excelApp = null; 
		}


		// ----------------------------- start retrieve data ---------------------------------------------------- 
		private void RetrieveData()
		{
			//int jmlrow;
			//conn.QueryString = "select excel_field from ca_excel where excel_file = 'BPR' and excel_type = 'BS'";
			//conn.ExecuteQuery();
			//jmlrow = conn.GetRowCount();
			conn.QueryString = "Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
			string a = conn.GetFieldValue("cu_ref").ToString();


			conn.QueryString = "select top 3 " +  
				"CU_REF,AP_REGNO,POSISI_TGL,JML_BLN,JNS_LAP,IN_OPR_11,IN_OPR_12,IN_OPR_13,IN_OPR_TOT, " +
				"EX_OPR_21,EX_OPR_22,EX_OPR_23,EX_OPR_TOT,NET_OPR,IN_OTHER_OPR_31, " +
				"IN_OTHER_OPR_32,IN_OTHER_OPR_33,IN_OTHER_OPR_TOT,EX_OTHER_OPR_41," +
				"EX_OTHER_OPR_42,EX_OTHER_OPR_43,EX_OTHER_OPR_44,EX_OTHER_OPR_45," +
				"EX_OTHER_OPR_46,EX_OTHER_OPR_TOT,NET_OTHER_OPR,OPR_EARN,NET_NON_OPR," +
				"IN_BEFORE_TAX,IN_TAX,NET_INCOME,BALANCE,DEVIDEN,TOT_EARN" +			
				" from BPR_LABARUGI where CU_REF = '" + a + "' and ap_regno = '" + Request.QueryString["regno"] + "' and year(POSISI_TGL) <= '" + Request.QueryString["tahun"] + "' order by POSISI_TGL asc";
			conn.ExecuteQuery();

			int row = 65;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				
				row++;
				string vtmp = ((char)row).ToString();
				int k = 4;
				int l = 2;

				for (int m=29;m<=31;m++)
				{
					System.Web.UI.WebControls.TextBox txt_DD_ = (System.Web.UI.WebControls.TextBox) Page.FindControl("txt_DD_" + vtmp + m.ToString());
					System.Web.UI.WebControls.DropDownList ddl_MM_ = (System.Web.UI.WebControls.DropDownList) Page.FindControl("ddl_MM_" + vtmp + m.ToString());
					System.Web.UI.WebControls.TextBox txt_YY_ = (System.Web.UI.WebControls.TextBox) Page.FindControl("txt_YY_" + vtmp + m.ToString());
					System.Web.UI.WebControls.TextBox txt_ = (System.Web.UI.WebControls.TextBox) Page.FindControl("txt_" + vtmp + m.ToString());

					System.Web.UI.WebControls.DropDownList ddl_ = (System.Web.UI.WebControls.DropDownList) Page.FindControl("ddl_" + vtmp + m.ToString());

					if (Request.QueryString["mode"]=="retrieve")
					{
						if (m==29)
						{
							try 
							{
								DateTime tgl = DateTime.Parse(GlobalTools.FormatDate(conn.GetFieldValue(i, l)));
								GlobalTools.fillDateForm(txt_DD_, ddl_MM_, txt_YY_, tgl);
							}
							catch
							{
							}
						}
						else if (m==30)
						{
							try {txt_.Text = GlobalTools.ConvertFloat(conn.GetFieldValue(i, l));}
							catch {}
						}
						else if (m==31)
						{
							try{ ddl_.SelectedValue = conn.GetFieldValue(i, "JNS_LAP").ToString();}
							catch {}
						}

					}
					else
					{
						if (m==29)
						{
							try
							{
								txt_DD_.Text = "";
								ddl_MM_.SelectedIndex = 0;
								txt_YY_.Text = "";
							}
							catch
							{
							}
						}
						else if (m==30)
						{
							try {txt_.Text = "";}
							catch {}
						}
						else if (m==31)
						{
							try {ddl_.SelectedValue = "-";}
							catch {}
							
						}
					}
					l++;
				}

				for (int j = 31; j <= 60; j++)
				{	
					System.Web.UI.WebControls.TextBox txt_ = (System.Web.UI.WebControls.TextBox) Page.FindControl("txt_" + vtmp + j.ToString());
					if (Request.QueryString["mode"]=="retrieve")
					{
						try {txt_.Text = myMoneyFormat_noDec(conn.GetFieldValue(i, k).ToString());}
						catch {}
					}
					else 
					{
						try {txt_.Text = "";}
						catch {}
					}
					
					
					if (k > 60)
					{
						break;
					}
					else
					{
						k++; 
					}
				}
			}
		}	
		// ----------------------------- end retrieve data ---------------------------------------------------- 


		private void SaveRugiLaba()
		{
			conn.QueryString = "Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
			string a = conn.GetFieldValue("cu_ref").ToString();

			conn.QueryString = "sp_bpr_labarugi 'Save','" + a + "','" + Request.QueryString["regno"] + "'," +
				GlobalTools.ToSQLDate(txt_DD_B29.Text, ddl_MM_B29.SelectedValue, txt_YY_B29.Text) + "," + 
				GlobalTools.ConvertNum(txt_B30.Text) + ",'" + ddl_B31.SelectedValue + "'," + 
				GlobalTools.ConvertFloat(txt_B32.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B33.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B34.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B35.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B36.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B37.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B38.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B39.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B40.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B41.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B42.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B43.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B44.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B45.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B46.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B47.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B48.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B49.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B50.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B51.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B52.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B53.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B54.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B55.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B56.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B57.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B58.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B59.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B60.Text) + ",''";
			conn.ExecuteNonQuery();

			if (txt_C30.Text != "")
			{
				conn.QueryString = "sp_bpr_labarugi 'Save','" + a + "','" + Request.QueryString["regno"] + "'," +
					GlobalTools.ToSQLDate(txt_DD_C29.Text, ddl_MM_C29.SelectedValue, txt_YY_C29.Text) + "," + 
					GlobalTools.ConvertNum(txt_C30.Text) + ",'" + ddl_C31.SelectedValue + "'," + 
					GlobalTools.ConvertFloat(txt_C32.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C33.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C34.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C35.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C36.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C37.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C38.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C39.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C40.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C41.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C42.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C43.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C44.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C45.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C46.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C47.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C48.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C49.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C50.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C51.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C52.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C53.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C54.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C55.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C56.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C57.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C58.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C59.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C60.Text) + ",''";
				conn.ExecuteNonQuery();
			}

			if (txt_D30.Text != "")
			{
				conn.QueryString = "sp_bpr_labarugi 'Save','" + a + "','" + Request.QueryString["regno"] + "'," +
					GlobalTools.ToSQLDate(txt_DD_D29.Text, ddl_MM_D29.SelectedValue, txt_YY_D29.Text) + "," + 
					GlobalTools.ConvertNum(txt_D30.Text) + ",'" + ddl_D31.SelectedValue + "'," + 
					GlobalTools.ConvertFloat(txt_D32.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D33.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D34.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D35.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D36.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D37.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D38.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D39.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D40.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D41.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D42.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D43.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D44.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D45.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D46.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D47.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D48.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D49.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D50.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D51.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D52.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D53.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D54.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D55.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D56.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D57.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D58.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D59.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D60.Text) + ",'1'";
				conn.ExecuteNonQuery();
			}
			ViewData();	
		}

		
		//		private void btn_Refresh_Click(object sender, System.EventArgs e)
		//		{
		//			ViewExcel();
		//		}

		private bool cekTanggal()
		{
			if (txt_DD_B29.Text != "" && ddl_MM_B29.SelectedIndex > 0 && txt_YY_B29.Text != "")
				if (!GlobalTools.isDateValid(this, txt_DD_B29.Text, ddl_MM_B29.SelectedValue, txt_YY_B29.Text)) 
				{
					GlobalTools.popMessage(this, "Data/Number of Months tidak valid!");
					return false;
				}
			if (txt_DD_C29.Text != "" && ddl_MM_C29.SelectedIndex > 0 && txt_YY_C29.Text != "")
				if (!GlobalTools.isDateValid(this, txt_DD_C29.Text, ddl_MM_C29.SelectedValue, txt_YY_C29.Text)) 
				{
					GlobalTools.popMessage(this, "Data/Number of Months tidak valid!");
					return false;
				}
			if (txt_DD_D29.Text != "" && ddl_MM_D29.SelectedIndex > 0 && txt_YY_D29.Text != "")
				if (!GlobalTools.isDateValid(this, txt_DD_D29.Text, ddl_MM_D29.SelectedValue, txt_YY_D29.Text)) 
				{
					GlobalTools.popMessage(this, "Data/Number of Months tidak valid!");
					return false;
				}

			return true;
		}

		
		protected void btn_Save_Click(object sender, System.EventArgs e)
		{
			if (!cekTanggal())
				return;
			
			SaveRugiLaba();

			string tahun = LBL_H_TAHUN.Text ;
			if (tahun == "")
			{
				tahun = (txt_YY_D29.Text != "" ? txt_YY_D29.Text : 
					txt_YY_C29.Text != "" ? txt_YY_C29.Text : 
					txt_YY_B29.Text != "" ? txt_YY_B29.Text : "");
			}

			conn.QueryString = "Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
			string a = conn.GetFieldValue("cu_ref").ToString();

			string vtahun;
			if (Request.QueryString["tahun"]=="" || Request.QueryString["tahun"]==null)
				vtahun = tahun;
			else
				vtahun = Request.QueryString["tahun"];

			HitRasioBPR.proses_calculate(this,a,Request.QueryString["regno"],vtahun,conn);
			
		}


		//		private void btn_Upload_Click(object sender, System.EventArgs e)
		//		{
		//			string path;
		//
		//			path = @"D:\Projects\SME\Source\CreditAnalysis\ExcelTemplate\BPR.xls";			 
		//			System.IO.FileInfo fi = new System.IO.FileInfo(file_Nama.PostedFile.FileName);
		//			file_Nama.PostedFile.SaveAs(path);			
		//			lbl_Status.Text = "Upload Successful";
		//		}

		//		private void dg_Neraca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		//		{
		//			string cmd = e.CommandName;
		//			switch (cmd)
		//			{		  
		//				case "retrieve" :
		//					Response.Redirect("bprRugiLaba.aspx?tahun=" + GlobalTools.FormatDate_Year(e.Item.Cells[0].Text) +"&mode=retrieve&regno="+Request.QueryString["regno"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]);
		//					RetrieveData();
		//					break;
		//				case "delete" :
		//					Response.Redirect("bprRugiLaba.aspx?tahun=" + GlobalTools.FormatDate_Year(e.Item.Cells[0].Text) +"&mode=delete&regno="+Request.QueryString["regno"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]);
		//					RetrieveData();
		//					break;
		//				default :
		//					break;
		//			}
		//		}

		private void IsiTanggal()
		{
			GlobalTools.initDateFormINA(txt_DD_B29, ddl_MM_B29, txt_YY_B29, true);
			GlobalTools.initDateFormINA(txt_DD_C29, ddl_MM_C29, txt_YY_C29, true);
			GlobalTools.initDateFormINA(txt_DD_D29, ddl_MM_D29, txt_YY_D29, true);
		}

		/*

		private void btn_Upload_Click(object sender, System.EventArgs e)
		{
			string path, mStatus = "", mStatusReport = "";
			conn.QueryString = "select XLS_ROOT, XLS_DIR from CA_EXCEL_TEMPLATE";
			conn.ExecuteQuery();
			path = conn.GetFieldValue("XLS_ROOT").ToString().Trim()+ conn.GetFieldValue("XLS_DIR").ToString().Trim();
 
			HttpFileCollection uploadedFiles = Request.Files;
			
			int counter = 0, mField = 0;
			lbl_Status.Text = "";
			lbl_StatusReport.Text = "";

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
						lbl_Status.ForeColor = Color.Black;
						lbl_StatusReport.ForeColor = Color.Black;
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
				}

				catch (Exception ex)
				{
					lbl_Status.ForeColor = Color.Red;
					lbl_StatusReport.ForeColor = Color.Red;
					mStatus		  = "Error Uploading File";
					mStatusReport = ex.ToString();
				}
				
				lbl_Status.Text			= mStatus.Trim();
				lbl_StatusReport.Text	= mStatusReport.Trim();
			}		
			
			
			vdir = Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName);
			ViewExcel(vdir);
		}

		private void ViewFileUpload()
		{
			conn.QueryString = "select distinct XLS_DIR from CA_EXCEL_TEMPLATE";
			conn.ExecuteQuery();
			string path = "/SME/" + conn.GetFieldValue("XLS_DIR").ToString().Trim().Replace("\\", "/");
			
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "select * from CA_FILEUPLOADXL where AP_REGNO ='"+ Request.QueryString["regno"] + "'";
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
					HpDelete.Enabled	= false;
				}
			}
		}

	
		private void DatGrid_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete" :
					conn.QueryString = "exec CA_FILEUPLOADXL_SP '" +Request.QueryString["regno"]+ "', '" +e.Item.Cells[0].Text+ "','','','2'";
					conn.ExecuteNonQuery();
					ViewFileUpload();
					break;
			}
		}

	*/
	
		private void dg_Neraca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;
			switch (cmd)
			{		  
				case "retrieve" :
					Response.Redirect("bprRugiLaba.aspx?tahun=" + GlobalTools.FormatDate_Year(e.Item.Cells[0].Text) +"&mode=retrieve&regno="+Request.QueryString["regno"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]);
					RetrieveData();
					break;
				case "delete" :
					//---------------------------------------------------delete labarugi
					conn.QueryString = "Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+"'";
					conn.ExecuteQuery();
					string a = conn.GetFieldValue("cu_ref").ToString();

					conn.QueryString = "SP_BPR_LABARUGI 'Delete','"+a+"','" + Request.QueryString["regno"] + "','"+ Strings.Format(DateTime.Parse(e.Item.Cells[0].Text),"yyyy-MM-dd") +
						"',"+e.Item.Cells[1].Text+",'',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
					conn.ExecuteNonQuery();

					Response.Redirect("bprRugiLaba.aspx?tahun=" + GlobalTools.FormatDate_Year(e.Item.Cells[0].Text) +"&mode=delete&regno="+Request.QueryString["regno"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]);
					RetrieveData();
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
					string regno = e.Item.Cells[0].Text,
						tahun = e.Item.Cells[3].Text;
					//retrieve_datahistory(vtemp,"retrieve_history");	//changed by nyoman
					retrieve_HistoryData(regno, tahun);
					break;
				case "delete_history" :
					string vtempo = e.Item.Cells[3].Text;
					//retrieve_datahistory(vtempo,"delete_history");
					//clear_field_history(vtempo);
					//tgl_default();
					break;
				default :
					break;
			}
		}

		private void retrieve_HistoryData(string regno, string tahun)
		{
			int row;
			//initTgl();
			
			conn.QueryString = "select is_proyeksi from bpr_labarugi where year(posisi_tgl) = '" + 
				tahun + "' and ap_regno = '" + regno + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("is_proyeksi")=="1")
				row = 69;
			else
				row = 68;


			conn.QueryString = "select top 3 CU_REF,AP_REGNO,POSISI_TGL,JML_BLN" +
				",IN_OPR_11,IN_OPR_12,IN_OPR_13,IN_OPR_TOT" +
				",EX_OPR_21,EX_OPR_22,EX_OPR_23,EX_OPR_TOT" +
				",NET_OPR,IN_OTHER_OPR_31,IN_OTHER_OPR_32" +
				",IN_OTHER_OPR_33,IN_OTHER_OPR_TOT,EX_OTHER_OPR_41" +
				",EX_OTHER_OPR_42,EX_OTHER_OPR_43,EX_OTHER_OPR_44" +
				",EX_OTHER_OPR_45,EX_OTHER_OPR_46,EX_OTHER_OPR_TOT" +
				",NET_OTHER_OPR,OPR_EARN,NET_NON_OPR,IN_BEFORE_TAX" +
				",IN_TAX,NET_INCOME,BALANCE,DEVIDEN,TOT_EARN,IS_PROYEKSI " +
				"from bpr_labarugi where year(posisi_tgl) <= '" + tahun + "' and ap_regno = '" + regno + "' order by posisi_tgl desc";
			conn.ExecuteQuery();

			System.Data.DataTable dt;
			dt = conn.GetDataTable().Copy();
			int jml_row = dt.Rows.Count;

			
			for (int i = 0; i < jml_row; i++)
			{
				
				row--;
				string vtmp = ((char)row).ToString();
				//int k = 6;
				int k = 4;
				int kk = 2;
				for (int m=29;m<31;m++)
				{
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("txt_" + vtmp + m.ToString());
					if (m!=29)
					{
						try {txt.Text = dt.Rows[i][kk].ToString();}
						catch {txt.Text = "";}
						
					} 
					else 
					{
						for (int n=29;n<31;n++)
						{
							System.Web.UI.WebControls.TextBox txt_DD_ = (System.Web.UI.WebControls.TextBox) Page.FindControl("txt_DD_" + vtmp + n.ToString());
							System.Web.UI.WebControls.DropDownList ddl_MM_ = (System.Web.UI.WebControls.DropDownList) Page.FindControl("ddl_MM_" + vtmp + n.ToString());
							System.Web.UI.WebControls.TextBox txt_YY_ = (System.Web.UI.WebControls.TextBox) Page.FindControl("txt_YY_" + vtmp + n.ToString());

							System.Web.UI.WebControls.TextBox txt_ = (System.Web.UI.WebControls.TextBox) Page.FindControl("txt_" + vtmp + n.ToString());
							System.Web.UI.WebControls.DropDownList ddl_ = (System.Web.UI.WebControls.DropDownList) Page.FindControl("ddl_" + vtmp + n.ToString());

							if (n==1)
							{

								try 
								{
									try
									{
										DateTime excdate = Convert.ToDateTime(GlobalTools.FormatDate(dt.Rows[i][kk].ToString()));
										GlobalTools.fillDateForm(txt_DD_, ddl_MM_, txt_YY_, excdate);
									}
									catch
									{
									}
								}
								catch 
								{
									try
									{
										txt_DD_.Text = "";
										ddl_MM_.SelectedValue = "";	
										txt_YY_.Text = "";
									}
									catch
									{
									}
								}
							}
							else if (n==2)
							{
								try {txt_.Text = conn.GetFieldValue(i, kk+1).ToString();}
								catch {}
							}
							else if (n==3)
							{
								try {ddl_.SelectedValue = conn.GetFieldValue(i, kk+2).ToString();}
								catch {}
							}

						}
					}			
					kk++;
				}
				
				for (int j = 31; j <= 60; j++)
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("txt_" + vtmp + j.ToString());
					try { txt.Text = myMoneyFormat_noDec(dt.Rows[i][k].ToString()); }
					catch { txt.Text = "";}
					k++;
				}
				
				if (row<=66){ break; }
	
			}

		}
		
		private string myMoneyFormat_noDec(string str)
		{
			if ((str.Trim() == "") || (str.Trim() == "&nbsp;")) 
			{
				return Strings.FormatNumber(0, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
			} 
			else 
			{
				return Strings.FormatNumber(str, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
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


		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink("",Request.QueryString["mc"].ToString(), conn));
		}

		private void secureData() 
		{
			if (Request.QueryString["ca"]=="0") 
			{
				int kk = 0, index = -1;
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for (kk = 0; kk < coll.Count; kk++) 
				{
					if (coll[kk] is System.Web.UI.HtmlControls.HtmlForm) 
					{
						index = kk;
						break;
					}
				}

				if (index == -1) return;
				if (kk == coll.Count) return;

				for (int i = 0; i < coll[index].Controls.Count; i++) 
				{
					if (coll[index].Controls[i] is System.Web.UI.WebControls.TextBox) 
					{
						System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) coll[index].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[index].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[index].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[index].Controls[i] is System.Web.UI.WebControls.Button)
					{
						System.Web.UI.WebControls.Button btn = (System.Web.UI.WebControls.Button) coll[index].Controls[i];
						btn.Visible = false;
					}
					else if (coll[index].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[index].Controls[i];

						for (int j=0; j < htr.Controls.Count; j++) 
						{							
							for (int jj = 0; jj < htr.Controls[j].Controls.Count; jj++) 
							{
								if (htr.Controls[j].Controls[jj] is System.Web.UI.WebControls.TextBox) 
								{
									System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) htr.Controls[j].Controls[jj];
									txt.ReadOnly = true;
								}
								else if (htr.Controls[j].Controls[jj] is DropDownList) 
								{
									DropDownList ddl = (DropDownList) htr.Controls[j].Controls[jj];
									ddl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is System.Web.UI.WebControls.Button)
								{
									System.Web.UI.WebControls.Button btn = (System.Web.UI.WebControls.Button) htr.Controls[j].Controls[jj];
									btn.Visible = false;
								}
							}
						}
					}
				}
			}
		}



	}
	
}