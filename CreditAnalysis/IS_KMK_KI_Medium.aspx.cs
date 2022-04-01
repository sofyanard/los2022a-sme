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

namespace SME.CreditAnalysis
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public partial class IS_KMK_KI_Medium : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (Request.QueryString["viewmode"] == "1")
			{
				//DG_LRHistory.Columns[5].Visible = false;
				DB_LBRG1.Columns[6].Visible = false;
				BTN_SIMPAN.Visible = false;
			}

			if(!IsPostBack)
			{
				tgl_default();
				viewdata();
				viewdata_history();
				retrieve_data();
				isi_initial();
			}
			
			ViewMenu();
			ViewSubMenu();
			
            /*
			BTN_SIMPAN.Attributes.Add("onclick","if(!cek_key_middle('labarugi')){return false;} " +
                "else HitungLabaRugiMiddle(1,'B'),HitungLabaRugiMiddle(1,'C'),HitungLabaRugiMiddle(1,'D'),HitungLabaRugiMiddle(1,'E')," +
                "HitungLabaRugiMiddle(2,'B'),HitungLabaRugiMiddle(2,'C'),HitungLabaRugiMiddle(2,'D'),HitungLabaRugiMiddle(2,'E')," +
                "HitungLabaRugiMiddle(3,'B'),HitungLabaRugiMiddle(3,'C'),HitungLabaRugiMiddle(3,'D'),HitungLabaRugiMiddle(3,'E')," +
                "HitungLabaRugiMiddle(4,'B'),HitungLabaRugiMiddle(4,'C'),HitungLabaRugiMiddle(4,'D'),HitungLabaRugiMiddle(4,'E')," +
                "HitungLabaRugiMiddle(5,'B'),HitungLabaRugiMiddle(5,'C'),HitungLabaRugiMiddle(5,'D'),HitungLabaRugiMiddle(5,'E')," +
                "HitungLabaRugiMiddle(6,'B'),HitungLabaRugiMiddle(6,'C'),HitungLabaRugiMiddle(6,'D'),HitungLabaRugiMiddle(6,'E')," +
                "HitungLabaRugiMiddle(7,'B'),HitungLabaRugiMiddle(7,'C'),HitungLabaRugiMiddle(7,'D'),HitungLabaRugiMiddle(7,'E')," +
                "HitungLabaRugiMiddle(8,'B'),HitungLabaRugiMiddle(8,'C'),HitungLabaRugiMiddle(8,'D'),HitungLabaRugiMiddle(8,'E')," +
                "HitungLabaRugiMiddle(9,'B'),HitungLabaRugiMiddle(9,'C'),HitungLabaRugiMiddle(9,'D'),HitungLabaRugiMiddle(9,'E')," +
                "HitungLabaRugiMiddle(10,'B'),HitungLabaRugiMiddle(10,'C'),HitungLabaRugiMiddle(10,'D'),HitungLabaRugiMiddle(10,'E')," +
                "FormatCurrency_noDec(document.getElementById('TXT_B43')),FormatCurrency_noDec(document.getElementById('TXT_B44'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_B45')),FormatCurrency_noDec(document.getElementById('TXT_B47'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_B48')),FormatCurrency_noDec(document.getElementById('TXT_B49'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_B55')),FormatCurrency_noDec(document.getElementById('TXT_B57'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_B58')),FormatCurrency_noDec(document.getElementById('TXT_B60'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_B61'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_C43')),FormatCurrency_noDec(document.getElementById('TXT_C44'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_C45')),FormatCurrency_noDec(document.getElementById('TXT_C47'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_C48')),FormatCurrency_noDec(document.getElementById('TXT_C49'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_C55')),FormatCurrency_noDec(document.getElementById('TXT_C57'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_C58')),FormatCurrency_noDec(document.getElementById('TXT_C60'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_C61'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_D43')),FormatCurrency_noDec(document.getElementById('TXT_D44'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_D45')),FormatCurrency_noDec(document.getElementById('TXT_D47'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_D48')),FormatCurrency_noDec(document.getElementById('TXT_D49'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_D55')),FormatCurrency_noDec(document.getElementById('TXT_D57'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_D58')),FormatCurrency_noDec(document.getElementById('TXT_D60'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_D61'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_E43')),FormatCurrency_noDec(document.getElementById('TXT_E44'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_E45')),FormatCurrency_noDec(document.getElementById('TXT_E47'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_E48')),FormatCurrency_noDec(document.getElementById('TXT_E49'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_E55')),FormatCurrency_noDec(document.getElementById('TXT_E57'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_E58')),FormatCurrency_noDec(document.getElementById('TXT_E60'))," +
                "FormatCurrency_noDec(document.getElementById('TXT_E61'));");*/
			//BTNPROSES.Attributes.Add("onclick","if(!cek_key_middle('labarugi')){return false;};");

            readonly_teksbox();
		}

		private string myMoneyFormat_noDec(string str)
		{
            if (!str.Contains(","))
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
            else
            {
                return str;
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
			this.DG_LRHistory.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_LRHistory_ItemCommand);
			this.DB_LBRG1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DB_LBRG1_ItemCommand);

		}
		#endregion

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
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
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

				//conn.QueryString = "select * from screensubmenu where lg_code in (select distinct lg_code from rfcafinstatement where programid = '"+ Request.QueryString["programid"]+"'and nasabahid = '" +Request.QueryString["jnsnasabah"]+"') and menucode = '" +Request.QueryString["mc"]+ "'";
				//conn.QueryString = "select * from screensubmenu where lg_code in (select distinct lg_code from rfcafinstatement where programid = '"+Request.QueryString["programid"]+"' and nasabahid = '" +Request.QueryString["jnsnasabah"]+"') and menucode = '" +Request.QueryString["mc"]+ "' and programid = '"+Request.QueryString["programid"]+"'";

				conn.QueryString = "select MENUCODE,BUSSUNITID,PROGRAMID,PROGRAMID_SEQ,SM_MENUDISPLAY,SM_LINKNAME,LG_CODE from screensubmenu where lg_code in (select distinct lg_code from rfcafinstatement where programid = '" + sProgramID + "' and nasabahid = '" + sJnsNasabah + "') and menucode = '" + Request.QueryString["mc"]+ "' and programid = '" + sProgramID + "'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 4);
					string strtemp = "";
					//strtemp = "regno=" + Request.QueryString["regno"] + "&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"];
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

		private void viewdata()
		{
			conn.QueryString = "select distinct IS_DATE_PERIODE,IS_NUM_MONTH,IS_REPORTTYPE,year(IS_DATE_PERIODE) tahun,IS_CURRENCY,IS_DENOMINATOR from CA_LABARUGI_MIDDLE where ap_regno = '" + Request.QueryString["regno"] + "' ORDER BY IS_DATE_PERIODE DESC";
			conn.ExecuteQuery();
			
			DB_LBRG1.DataSource = conn.GetDataTable().Copy();
			DB_LBRG1.DataBind();
			for(int i = 0; i < DB_LBRG1.Items.Count; i++)
			{
				DB_LBRG1.Items[i].Cells[0].Text = tool.FormatDate(DB_LBRG1.Items[i].Cells[0].Text);
			}
		}

		private void viewdata_history()
		{
			//conn.QueryString = "select POSISI_TGL,JML_BLN,JNS_LAP,year(POSISI_TGL) tahun from CA_LABARUGI_SMALL where ap_regno = '" + Request.QueryString["regno"]+ "' order by POSISI_TGL desc";
			conn.QueryString = "exec CA_LABARUGI_MIDDLE_HISTORY '" + Request.QueryString["curef"] + "', '" +
				Request.QueryString["regno"] + "' ";
			conn.ExecuteQuery();
			
			//			System.Data.DataTable data = new DataTable(); 
			//			data = conn.GetDataTable().Copy();
			DG_LRHistory.DataSource = conn.GetDataTable().Copy();
			DG_LRHistory.DataBind();
			for(int i = 0; i < DG_LRHistory.Items.Count; i++)
			{
				DG_LRHistory.Items[i].Cells[1].Text = tool.FormatDate(DG_LRHistory.Items[i].Cells[1].Text);
			}
		}

		private void clear_field()
		{
			LBL_H_TAHUN.Text = "";
			
			int cnt;
				
			conn.QueryString = "select CU_REF,AP_REGNO,IS_DATE_PERIODE,IS_NUM_MONTH,IS_REPORTTYPE,IS_SALES_ONCR,IS_NET_SALES" +
				",IS_COST_GS,IS_PROSEN1,IS_GROSS_MARGIN,IS_PROSEN2,IS_SELLING_GENADM,IS_PROSEN3" +
				",IS_OPR_EARN,IS_PROSEN4,IS_DEPRECIATE,IS_AMORTIZATION1,IS_AMORTIZATION2" +
				",IS_OTH_INCM_NET,IS_EXTRAORD,IS_EARN_BIT,IS_INTRST_EXP,IS_EARN_BT,IS_PROSEN5" +
				",IS_INCM_TAX,IS_NET_INCM,IS_PROSEN6,IS_CURRENCY,IS_DENOMINATOR,IS_SUMBERDATA,IS_ISPROYEKSI from ca_labarugi_middle where ap_regno = '" + Request.QueryString["regno"] + "' order by is_date_periode desc";
			conn.ExecuteQuery();
			cnt = conn.GetRowCount();

			conn.QueryString="select excel_field from ca_excel where excel_file = 'kmk_ki_middle' and excel_type = 'is'";
			conn.ExecuteQuery();
				
			int row = 70;
			//for (int i = 0; i < cnt; i++)
			//TO DO :
			for (int i = 0; i < 4; i++)
			{
				row--;
				string vtmp = ((char)row).ToString();
				
				//for (int m=1;m<=conn.GetRowCount();m++)
				for (int m=38;m<=61;m++)
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


		private void tgl_default()
		{
			GlobalTools.initDateForm(this.TXT_TGL_B37, this.DDL_BLN_B37, this.TXT_YEAR_B37, true);
			GlobalTools.initDateForm(this.TXT_TGL_C37, this.DDL_BLN_C37, this.TXT_YEAR_C37, true);
			GlobalTools.initDateForm(this.TXT_TGL_D37, this.DDL_BLN_D37, this.TXT_YEAR_D37, true);
			GlobalTools.initDateForm(this.TXT_TGL_E37, this.DDL_BLN_E37, this.TXT_YEAR_E37, true);
			try
			{ 
				//this.DDL_BLN_B1.SelectedValue = DateTime.Now.Month.ToString();
				this.DDL_B39.SelectedValue = "";
				this.DDL_C39.SelectedValue = "";
				this.DDL_D39.SelectedValue = "";
				this.DDL_E39.SelectedValue = "";
			}
			catch{}
		}

		//private void retrieve_data(string param1, string mode)
		private void retrieve_data()
		{
			LBL_H_TAHUN.Text = Request.QueryString["tahun"];

			int row;
			tgl_default();
			
			conn.QueryString = "select is_isproyeksi from ca_labarugi_middle where year(is_date_periode) = '" + Request.QueryString["tahun"] + "' and ap_regno = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("is_isproyeksi")=="1")
				row = 70;
			else
				row = 69;


			conn.QueryString = "select top 4 CU_REF,AP_REGNO,IS_DATE_PERIODE,IS_NUM_MONTH,IS_REPORTTYPE,IS_SALES_ONCR,IS_NET_SALES" +
				",IS_COST_GS,IS_PROSEN1,IS_GROSS_MARGIN,IS_PROSEN2,IS_SELLING_GENADM,IS_PROSEN3" +
				",IS_OPR_EARN,IS_PROSEN4,IS_DEPRECIATE,IS_AMORTIZATION1,IS_AMORTIZATION2" +
				",IS_OTH_INCM_NET,IS_EXTRAORD,IS_EARN_BIT,IS_INTRST_EXP,IS_EARN_BT,IS_PROSEN5" +
				",IS_INCM_TAX,IS_NET_INCM,IS_PROSEN6,IS_CURRENCY,IS_DENOMINATOR,IS_SUMBERDATA,IS_ISPROYEKSI from ca_labarugi_middle where year(is_date_periode) <= '" + Request.QueryString["tahun"] + "' and ap_regno = '" + Request.QueryString["regno"] + "' order by is_date_periode desc";
			conn.ExecuteQuery();

			System.Data.DataTable dt;
			dt = conn.GetDataTable().Copy();
			int jml_row = dt.Rows.Count;

			conn.QueryString = "select excel_field from ca_excel where excel_file = 'kmk_ki_middle' and excel_type = 'is'";
			conn.ExecuteQuery();

			
			for (int i = 0; i < jml_row; i++)
			{
				
				row--;
				string vtmp = ((char)row).ToString();
				int k = 6;
				int kk = 2;
				for (int m=37;m<41;m++)
				{
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
					if (Request.QueryString["mode"]=="retrieve")
						//if (mode=="retrieve")
					{
						if (m!=37)
						{
							if (m==39)
							{
								for (int nn=39;nn<40;nn++)
								{
									System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vtmp + nn.ToString());							
									txt.Text = dt.Rows[i][kk].ToString();
									try 
									{
										DDL_.SelectedValue = txt.Text;
									}
									catch(Exception ex)
									{
										DDL_.SelectedValue = "-";
										string temp = ex.ToString();
									}
								}
							}
							else
							{
								//txt.Text = myMoneyFormat_noDec(dt.Rows[i][kk].ToString());
								txt.Text = dt.Rows[i][kk].ToString();
							}
						} 
						else 
						{
							for (int n=37;n<38;n++)
							{
								System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmp + n.ToString());
								System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmp + n.ToString());
								System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmp + n.ToString());
			
								DateTime excdate = Convert.ToDateTime(tool.FormatDate(dt.Rows[i][kk].ToString()));
								GlobalTools.fillDateForm(TXT_TGL_, DDL_BLN_, TXT_YEAR_, excdate);
							}
						}			
					} 
					else 
					{
						txt.Text = "";
					}
					kk++;
				}
	
				for (int j = 41; j < 62; j++)
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + j.ToString());
					if (Request.QueryString["mode"]=="retrieve")
					{
						txt.Text = myMoneyFormat_noDec(dt.Rows[i][k].ToString());
					}
					else 
					{
						txt.Text = "";
					}
					k++;
				}
			
				if (row<=66){ break; }
	
			}

		}	

		private void retrieve_HistoryData(string regno, string tahun)
		{
			LBL_H_TAHUN.Text = tahun;

			int row;
			tgl_default();
			
			conn.QueryString = "select is_isproyeksi from ca_labarugi_middle where year(is_date_periode) = '" +
				tahun + "' and ap_regno = '" + regno + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("is_isproyeksi")=="1")
				row = 70;
			else
				row = 69;


			conn.QueryString = "select top 4 CU_REF,AP_REGNO,IS_DATE_PERIODE,IS_NUM_MONTH,IS_REPORTTYPE,IS_SALES_ONCR,IS_NET_SALES" +
				",IS_COST_GS,IS_PROSEN1,IS_GROSS_MARGIN,IS_PROSEN2,IS_SELLING_GENADM,IS_PROSEN3" +
				",IS_OPR_EARN,IS_PROSEN4,IS_DEPRECIATE,IS_AMORTIZATION1,IS_AMORTIZATION2" +
				",IS_OTH_INCM_NET,IS_EXTRAORD,IS_EARN_BIT,IS_INTRST_EXP,IS_EARN_BT,IS_PROSEN5" +
				",IS_INCM_TAX,IS_NET_INCM,IS_PROSEN6,IS_CURRENCY,IS_DENOMINATOR,IS_SUMBERDATA,IS_ISPROYEKSI " +
				"from ca_labarugi_middle where year(is_date_periode) <= '" + tahun +
				"' and ap_regno = '" + regno + "' order by is_date_periode desc";
			conn.ExecuteQuery();

			System.Data.DataTable dt;
			dt = conn.GetDataTable().Copy();
			int jml_row = dt.Rows.Count;

			conn.QueryString = "select excel_field from ca_excel where excel_file = 'kmk_ki_middle' and excel_type = 'is'";
			conn.ExecuteQuery();

			
			for (int i = 0; i < jml_row; i++)
			{
				
				row--;
				string vtmp = ((char)row).ToString();
				int k = 6;
				int kk = 2;
				for (int m=37;m<41;m++)
				{
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
					if (m!=37)
					{
						if (m==39)
						{
							for (int nn=39;nn<40;nn++)
							{
								System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vtmp + nn.ToString());							
								txt.Text = dt.Rows[i][kk].ToString();
								try 
								{
									DDL_.SelectedValue = txt.Text;
								}
								catch(Exception ex)
								{
									DDL_.SelectedValue = "-";
									string temp = ex.ToString();
								}
							}
						}
						else
						{
							//txt.Text = myMoneyFormat_noDec(dt.Rows[i][kk].ToString());
							txt.Text = dt.Rows[i][kk].ToString();
						}
					} 
					else 
					{
						for (int n=37;n<38;n++)
						{
							System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmp + n.ToString());
							System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmp + n.ToString());
							System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmp + n.ToString());
			
							DateTime excdate = Convert.ToDateTime(tool.FormatDate(dt.Rows[i][kk].ToString()));
							GlobalTools.fillDateForm(TXT_TGL_, DDL_BLN_, TXT_YEAR_, excdate);
						}
					}			
					kk++;
				}
	
				for (int j = 41; j < 62; j++)
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + j.ToString());
					txt.Text = myMoneyFormat_noDec(dt.Rows[i][k].ToString());
					k++;
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
			
			//return d;
			return myMoneyFormat_noDec(a);
		}

		private void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			//viewExcel();
		}

		

		private void save_labarugi()
		{
			if (TXT_B41.Text!="")
			{
				conn.QueryString = "exec ca_labarugi_middle_sp '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'," + GlobalTools.ToSQLDate(TXT_TGL_B37.Text,DDL_BLN_B37.SelectedValue,TXT_YEAR_B37.Text)+ "," + TXT_B38.Text + ",'" + DDL_B39.SelectedValue + "'," + tool.ConvertNum(TXT_B40.Text) + "," +
					tool.ConvertFloat(TXT_B41.Text) + "," + tool.ConvertFloat(TXT_B42.Text) + "," + tool.ConvertFloat(TXT_B43.Text) + "," + tool.ConvertFloat(TXT_B44.Text) + "," + tool.ConvertFloat(TXT_B45.Text) + ", " + tool.ConvertFloat(TXT_B46.Text) + "," + tool.ConvertFloat(TXT_B47.Text) + "," +
					tool.ConvertFloat(TXT_B48.Text) + "," + tool.ConvertFloat(TXT_B49.Text) + "," + tool.ConvertFloat(TXT_B50.Text) + "," + tool.ConvertFloat(TXT_B51.Text) + "," +
					tool.ConvertFloat(TXT_B52.Text) + "," + tool.ConvertFloat(TXT_B53.Text) + "," + tool.ConvertFloat(TXT_B54.Text) + "," + tool.ConvertFloat(TXT_B55.Text) + "," +			
					tool.ConvertFloat(TXT_B56.Text) + "," + tool.ConvertFloat(TXT_B57.Text) + "," + tool.ConvertFloat(TXT_B58.Text) + "," + tool.ConvertFloat(TXT_B59.Text) + "," +
					tool.ConvertFloat(TXT_B60.Text) + "," + tool.ConvertFloat(TXT_B61.Text) + ",'" + DDL_CURRENCY.SelectedValue + "','" + DDL_DENOMINATOR.SelectedValue + "','',''";	
				conn.ExecuteNonQuery();
			}

			if (TXT_C41.Text!="")
			{
				conn.QueryString = "exec ca_labarugi_middle_sp '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'," + GlobalTools.ToSQLDate(TXT_TGL_C37.Text,DDL_BLN_C37.SelectedValue,TXT_YEAR_C37.Text)+ "," + TXT_C38.Text + ",'" + DDL_C39.SelectedValue + "'," + tool.ConvertNum(TXT_C40.Text) + "," +
					tool.ConvertFloat(TXT_C41.Text) + "," + tool.ConvertFloat(TXT_C42.Text) + "," + tool.ConvertFloat(TXT_C43.Text) + "," + tool.ConvertFloat(TXT_C44.Text) + "," + tool.ConvertFloat(TXT_C45.Text) + ", " + tool.ConvertFloat(TXT_C46.Text) + "," + tool.ConvertFloat(TXT_C47.Text) + "," +
					tool.ConvertFloat(TXT_C48.Text) + "," + tool.ConvertFloat(TXT_C49.Text) + "," + tool.ConvertFloat(TXT_C50.Text) + "," + tool.ConvertFloat(TXT_C51.Text) + "," +
					tool.ConvertFloat(TXT_C52.Text) + "," + tool.ConvertFloat(TXT_C53.Text) + "," + tool.ConvertFloat(TXT_C54.Text) + "," + tool.ConvertFloat(TXT_C55.Text) + "," +
					tool.ConvertFloat(TXT_C56.Text) + "," + tool.ConvertFloat(TXT_C57.Text) + "," + tool.ConvertFloat(TXT_C58.Text) + "," + tool.ConvertFloat(TXT_C59.Text) + "," +
					tool.ConvertFloat(TXT_C60.Text) + "," + tool.ConvertFloat(TXT_C61.Text) + ",'" + DDL_CURRENCY.SelectedValue + "','" + DDL_DENOMINATOR.SelectedValue + "','',''";
				conn.ExecuteNonQuery();
			}

			if (TXT_D41.Text!="")
			{
				conn.QueryString = "exec ca_labarugi_middle_sp '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'," + GlobalTools.ToSQLDate(TXT_TGL_D37.Text,DDL_BLN_D37.SelectedValue,TXT_YEAR_D37.Text)+ "," + TXT_D38.Text + ",'" + DDL_D39.SelectedValue + "'," + tool.ConvertNum(TXT_D40.Text) + "," +
					tool.ConvertFloat(TXT_D41.Text) + "," + tool.ConvertFloat(TXT_D42.Text) + "," + tool.ConvertFloat(TXT_D43.Text) + "," + tool.ConvertFloat(TXT_D44.Text) + "," + tool.ConvertFloat(TXT_D45.Text) + ", " + tool.ConvertFloat(TXT_D46.Text) + "," + tool.ConvertFloat(TXT_D47.Text) + "," +
					tool.ConvertFloat(TXT_D48.Text) + "," + tool.ConvertFloat(TXT_D49.Text) + "," + tool.ConvertFloat(TXT_D50.Text) + "," + tool.ConvertFloat(TXT_D51.Text) + "," +
					tool.ConvertFloat(TXT_D52.Text) + "," + tool.ConvertFloat(TXT_D53.Text) + "," + tool.ConvertFloat(TXT_D54.Text) + "," + tool.ConvertFloat(TXT_D55.Text) + "," +
					tool.ConvertFloat(TXT_D56.Text) + "," + tool.ConvertFloat(TXT_D57.Text) + "," + tool.ConvertFloat(TXT_D58.Text) + "," + tool.ConvertFloat(TXT_D59.Text) + "," +
					tool.ConvertFloat(TXT_D60.Text) + "," + tool.ConvertFloat(TXT_D61.Text) + ",'" + DDL_CURRENCY.SelectedValue + "','" + DDL_DENOMINATOR.SelectedValue + "','',''";
				conn.ExecuteNonQuery();
			}
			
			
			if (TXT_E41.Text!="") 
			{
				string temp_e = "Proyeksi";
				conn.QueryString = "exec ca_labarugi_middle_sp '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'," + GlobalTools.ToSQLDate(TXT_TGL_E37.Text,DDL_BLN_E37.SelectedValue,TXT_YEAR_E37.Text)+ "," + TXT_E38.Text + ",'" + temp_e + "'," + tool.ConvertNum(TXT_E40.Text) + "," +
					tool.ConvertFloat(TXT_E41.Text) + "," + tool.ConvertFloat(TXT_E42.Text) + "," + tool.ConvertFloat(TXT_E43.Text) + "," + tool.ConvertFloat(TXT_E44.Text) + "," + tool.ConvertFloat(TXT_E45.Text) + ", " + tool.ConvertFloat(TXT_E46.Text) + "," + tool.ConvertFloat(TXT_E47.Text) + "," +
					tool.ConvertFloat(TXT_E48.Text) + "," + tool.ConvertFloat(TXT_E49.Text) + "," + tool.ConvertFloat(TXT_E50.Text) + "," + tool.ConvertFloat(TXT_E51.Text) + "," +
					tool.ConvertFloat(TXT_E52.Text) + "," + tool.ConvertFloat(TXT_E53.Text) + "," + tool.ConvertFloat(TXT_E54.Text) + "," + tool.ConvertFloat(TXT_E55.Text) + "," +
					tool.ConvertFloat(TXT_E56.Text) + "," + tool.ConvertFloat(TXT_E57.Text) + "," + tool.ConvertFloat(TXT_E58.Text) + "," + tool.ConvertFloat(TXT_E59.Text) + "," +
					tool.ConvertFloat(TXT_E60.Text) + "," + tool.ConvertFloat(TXT_E61.Text) + ",'" + DDL_CURRENCY.SelectedValue + "','" + DDL_DENOMINATOR.SelectedValue + "','','1'";
				conn.ExecuteNonQuery();
			}
			viewdata();
		}
		protected void BTN_SIMPAN_Click(object sender, System.EventArgs e)
		{
			if (TXT_TGL_B37.Text != "" && DDL_BLN_B37.SelectedIndex > 0 && TXT_YEAR_B37.Text != "")
				if (!Tools.isDateValid(this, TXT_TGL_B37.Text, DDL_BLN_B37.SelectedValue, TXT_YEAR_B37.Text)) 
				{
					GlobalTools.popMessage(this, "Data/Number of Months tidak valid!");
					return;
				}
			if (TXT_TGL_C37.Text != "" && DDL_BLN_C37.SelectedIndex > 0 && TXT_YEAR_C37.Text != "")
				if (!Tools.isDateValid(this, TXT_TGL_C37.Text, DDL_BLN_C37.SelectedValue, TXT_YEAR_C37.Text)) 
				{
					GlobalTools.popMessage(this, "Data/Number of Months tidak valid!");
					return;
				}
			if (TXT_TGL_D37.Text != "" && DDL_BLN_D37.SelectedIndex > 0 && TXT_YEAR_D37.Text != "")
				if (!Tools.isDateValid(this, TXT_TGL_D37.Text, DDL_BLN_D37.SelectedValue, TXT_YEAR_D37.Text)) 
				{
					GlobalTools.popMessage(this, "Data/Number of Months tidak valid!");
					return;
				}
			if (TXT_TGL_E37.Text != "" && DDL_BLN_E37.SelectedIndex > 0 && TXT_YEAR_E37.Text != "")
				if (!Tools.isDateValid(this, TXT_TGL_E37.Text, DDL_BLN_E37.SelectedValue, TXT_YEAR_E37.Text)) 
				{
					GlobalTools.popMessage(this, "Data/Number of Months tidak valid!");
					return;
				}

			save_labarugi();

			string tahun = LBL_H_TAHUN.Text ;
			if (tahun == "")
			{
				tahun = (TXT_YEAR_E37.Text != "" ? TXT_YEAR_E37.Text : 
					TXT_YEAR_D37.Text != "" ? TXT_YEAR_D37.Text : 
					TXT_YEAR_C37.Text != "" ? TXT_YEAR_C37.Text : 
					TXT_YEAR_B37.Text != "" ? TXT_YEAR_B37.Text : "");
			}

			CLS_CALCULATION.proses_calculate(this, Request.QueryString["regno"], Request.QueryString["curef"], tahun, conn);
		}

		private void DG_LRHistory_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;

			switch (cmd)
			{
				case "retrieve_history" :
					//string vtemp = e.Item.Cells[4].Text;
					//retrieve_datahistory(vtemp,"retrieve_history");
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

		private void clear_field_history(string vtahun)
		{
			int cnt;
				
			conn.QueryString = "select CU_REF,AP_REGNO,IS_DATE_PERIODE,IS_NUM_MONTH,IS_REPORTTYPE,IS_SALES_ONCR,IS_NET_SALES" +
				",IS_COST_GS,IS_PROSEN1,IS_GROSS_MARGIN,IS_PROSEN2,IS_SELLING_GENADM,IS_PROSEN3" +
				",IS_OPR_EARN,IS_PROSEN4,IS_DEPRECIATE,IS_AMORTIZATION1,IS_AMORTIZATION2" +
				",IS_OTH_INCM_NET,IS_EXTRAORD,IS_EARN_BIT,IS_INTRST_EXP,IS_EARN_BT,IS_PROSEN5" +
				",IS_INCM_TAX,IS_NET_INCM,IS_PROSEN6,IS_CURRENCY,IS_DENOMINATOR,IS_SUMBERDATA,IS_ISPROYEKSI from ca_labarugi_middle where year(is_date_periode) > '" + vtahun + "' and ap_regno = '" + Request.QueryString["regno"]+ "'";
			conn.ExecuteQuery();
			cnt = conn.GetRowCount();

			conn.QueryString="select excel_field from ca_excel where excel_file = 'kmk_ki_middle' and excel_type = 'is'";
			conn.ExecuteQuery();
				
			int row = 65;
			for (int i = 0; i < cnt; i++)
			{
				row++;
				string vtmp = ((char)row).ToString();

				int mulai = 37;
				for (int m=mulai;m<mulai+conn.GetRowCount();m++)
				{
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
					txt.Text = "";
				}
			}
			DDL_B39.SelectedValue = "-";
			DDL_C39.SelectedValue = "-";
			DDL_D39.SelectedValue = "-";
			DDL_E39.SelectedValue = "-";
			tgl_default();
		}

		private void retrieve_datahistory(string vtahun, string mode)
		{
			if (mode == "retrieve_history")
			{
				clear_field_history(vtahun);
				/********* start retrieve **************************/
				System.Data.DataTable dt = new System.Data.DataTable();
				conn.QueryString = "select CU_REF,AP_REGNO,POSISI_TGL,JML_BLN,JNS_LAP,SALES_ONCREDIT,IS_PENJ,IS_HPP" +
					",IS_PROSEN_PENJ1,IS_ADMOPR,IS_PROSEN_PENJ2,IS_LABAOPR,IS_SUSUT_TNHBGN" +
					",IS_SUSUT_ALAT,IS_SUSUT_INVKNDRN,IS_TTLSUSUT,IS_PNDPTN,IS_BIAYA_LAIN" +
					",IS_LABA_SBLBUNGA,IS_BUNGA,IS_LABA_SBLPJK,IS_PJK,IS_LABA_BRSH" +
					",IS_CURRENCY,IS_DENOMINATOR,SUMBERDATA,IS_PROYEKSI from ca_labarugi_small where year(posisi_tgl) <= '" + vtahun + "' and ap_regno = '" + Request.QueryString["regno"]+ "'";
				conn.ExecuteQuery();
				int jml_baris = conn.GetRowCount();
				
				dt = conn.GetDataTable().Copy();
				
				conn.QueryString="select excel_field from ca_excel where excel_file = 'kmk_ki_middle' and excel_type = 'is'";
				conn.ExecuteQuery();

				int hrf = 69;
				for (int ii = 0; ii < jml_baris; ii++)
				{
					hrf--;
					string vtmpe = ((char)hrf).ToString();
					int start = 1;
					
					for (int n=37;n<41;n++)
					{
						System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_" + vtmpe + n.ToString());
						start++;
						if (n==37)
						{
							System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmpe + n.ToString());
							System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmpe + n.ToString());
							System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmpe + n.ToString());
					
							DateTime excdatestr = Convert.ToDateTime(tool.FormatDate(dt.Rows[ii][2].ToString()));
							GlobalTools.fillDateForm(TXT_TGL_, DDL_BLN_, TXT_YEAR_, excdatestr);
						}
						else if (n==39)
						{ 
							System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vtmpe + n.ToString());
							txt.Text = dt.Rows[ii][start].ToString();
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
						
					}
					
					/**** separator ****/
					for (int nnn=41;nnn<56;nnn++)
					{
						int temp = 0;
						System.Web.UI.WebControls.TextBox teksboks = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_" + vtmpe + nnn.ToString());				
						if (nnn == 41) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][6].ToString()); }
						else if (nnn == 42) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][7].ToString()); }
						else if (nnn == 44) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][8].ToString()); }
						else if (nnn == 47)	{ teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][14].ToString()); }
						else if (nnn == 49)	{ teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][15].ToString()); }
						else if (nnn == 51)	{ teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][18].ToString()); }
						else if (nnn == 52)	{ teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][19].ToString()); }
						else if (nnn == 53)	{ teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][20].ToString()); }
						else if (nnn == 54)	{ teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][21].ToString()); }
						else if (nnn == 55)	{ teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][22].ToString()); }
						else { teksboks.Text = temp.ToString(); }
					}
					
					if (hrf<=66) // if < B keluar..
					{
						break;
					}
				}

			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn));
		}

		private void DB_LBRG1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;
			
			switch (cmd)
			{		  
				case "retrieve" :										
					string vtemp = e.Item.Cells[3].Text;
					Response.Redirect("IS_KMK_KI_Medium.aspx?tahun=" + vtemp +"&mode=retrieve&regno="+
						Request.QueryString["regno"]+"&mc="+Request.QueryString["mc"]+"&bussunitid="+
						Request.QueryString["bussunitid"]+"&programid="+Request.QueryString["programid"]+
						"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&curef="+Request.QueryString["curef"]+
						"&tc="+Request.QueryString["tc"]+"&viewmode="+Request.QueryString["viewmode"]+
						"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]);
					clear_field();
					retrieve_data();
					break;
				case "delete" :
					//Response.Redirect("IS_KMK_KI_Medium.aspx?tahun=" + tool.FormatDate_Year(e.Item.Cells[0].Text) +"&mode=delete&regno="+Request.QueryString["regno"]+"&mc="+Request.QueryString["mc"]+"&bussunitid="+Request.QueryString["bussunitid"]+"&programid="+Request.QueryString["programid"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&curef="+Request.QueryString["curef"]);
					string vtempe = e.Item.Cells[3].Text;
					conn.QueryString = "exec CA_LABARUGI_MIDDLE_SP_DELETE '" + Request.QueryString["curef"]+ "','" + Request.QueryString["regno"]+ "'," +
						GlobalTools.ToSQLDate(e.Item.Cells[4].Text) + ",'" + e.Item.Cells[1].Text + "','" + e.Item.Cells[2].Text + "'";
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

		private void BTNPROSES_Click(object sender, System.EventArgs e)
		{
			save_labarugi();
			//proses_calculate();
		}

		

		protected void BTNCLEAR_Click(object sender, System.EventArgs e)
		{
			clear_field();
		}

		
		protected void BTN_CEK_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec ca_temp_curr_denom_sp 'save','" + Request.QueryString["curef"] + "','" +
				Request.QueryString["regno"] + "','" + DDL_CURRENCY.SelectedValue + "','" +
				DDL_DENOMINATOR.SelectedValue + "'";
			conn.ExecuteNonQuery();
			PnlNeraca.Visible = true;
		}


		private void readonly_teksbox()
		{
            conn.QueryString = "SELECT EXCEL_CELL1, EXCEL_CELL2, EXCEL_CELL3, EXCEL_CELL4 FROM CA_EXCEL WHERE TABLE_NAME = 'CA_LABARUGI_MIDDLE'" +
				" AND EXCEL_FIELD IN ('IS_PROSEN1','IS_GROSS_MARGIN','IS_PROSEN2','IS_PROSEN3','IS_PROSEN4','IS_EARN_BIT','IS_EARN_BT','IS_PROSEN5','IS_NET_INCM','IS_PROSEN6')";
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

		//		private void readonly_teksbox()
		//		{
		//			conn.QueryString = "select excel_cell1,excel_cell2,excel_cell3,excel_cell4 from ca_excel where table_name = 'ca_neraca_middle'" +
		//				" and excel_field in ('BS_CURRASST','BS_TTL_NONCA','BS_TTL_ASST','BS_CURR_LIAB','BS_LONGTERM_LIAB' " +
		//				",'BS_TTL_LIAB','BS_TTL_NETWORTH','BS_LIAB_NETWORTH')";
		//			conn.ExecuteQuery();	
		//			 
		//			  
		//			for(int i=0; i < conn.GetRowCount(); i++) 
		//			{
		//				System.Web.UI.WebControls.TextBox TXT_B = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + conn.GetFieldValue(i,0));
		//				System.Web.UI.WebControls.TextBox TXT_C = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + conn.GetFieldValue(i,1));
		//				System.Web.UI.WebControls.TextBox TXT_D = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + conn.GetFieldValue(i,2));
		//				System.Web.UI.WebControls.TextBox TXT_E = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + conn.GetFieldValue(i,3));
		//			    
		//				TXT_B.BackColor = Color.Gainsboro;
		//				TXT_B.ReadOnly = true;
		//				
		//				TXT_C.BackColor = Color.Gainsboro;
		//				TXT_C.ReadOnly = true;
		//
		//				TXT_D.BackColor = Color.Gainsboro;
		//				TXT_D.ReadOnly = true;
		//
		//				TXT_E.BackColor = Color.Gainsboro;
		//				TXT_E.ReadOnly = true;
		//			}

		//		}
	}
}