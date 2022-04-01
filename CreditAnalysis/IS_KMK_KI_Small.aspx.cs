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
	/// Summary description for IS_KMK_KI_Small.
	/// </summary>
	public partial class IS_KMK_KI_Small : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Button BTN_UPLOAD;
		protected System.Web.UI.HtmlControls.HtmlInputFile File1;
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (Request.QueryString["viewmode"] == "1")
			{
				//DG_LRHistory.Columns[5].Visible = false;
				DB_LBRG1.Columns[6].Visible = false;
				BTN_SAVE.Visible = false;
			}

			if(!IsPostBack)
			{
				viewdata();
				initTgl();
				viewdata_history();
				retrieve_data();
			}
			ViewMenu();
			ViewSubMenu();
			
			//BTN_SAVE.Attributes.Add("onclick","if(!cek_key('labarugi')){return false;};");
			BTN_SAVE.Attributes.Add("onclick","if(!cek_key('labarugi')){return false;} " +
				"else HitungLabaRugiSmall(7,'B'),HitungLabaRugiSmall(7,'C'),HitungLabaRugiSmall(7,'D')," +
				"FormatCurrency_noDec(document.Form1.TXT_B41), FormatCurrency_noDec(document.Form1.TXT_B43), " +
				"FormatCurrency_noDec(document.Form1.TXT_B44), FormatCurrency_noDec(document.Form1.TXT_B48), " +
				"FormatCurrency_noDec(document.Form1.TXT_B51), FormatCurrency_noDec(document.Form1.TXT_B53), " +
				"FormatCurrency_noDec(document.Form1.TXT_B55), FormatCurrency_noDec(document.Form1.TXT_C41), " +
				"FormatCurrency_noDec(document.Form1.TXT_C43), FormatCurrency_noDec(document.Form1.TXT_C44), " +
				"FormatCurrency_noDec(document.Form1.TXT_C48), FormatCurrency_noDec(document.Form1.TXT_C51), " +
				"FormatCurrency_noDec(document.Form1.TXT_C53), FormatCurrency_noDec(document.Form1.TXT_C55), " +
				"FormatCurrency_noDec(document.Form1.TXT_D41), FormatCurrency_noDec(document.Form1.TXT_D43), " +
				"FormatCurrency_noDec(document.Form1.TXT_D44), FormatCurrency_noDec(document.Form1.TXT_D48), " +
				"FormatCurrency_noDec(document.Form1.TXT_D51), FormatCurrency_noDec(document.Form1.TXT_D53), " +
				"FormatCurrency_noDec(document.Form1.TXT_D55);");
			
			// di remark sementara BTN_PROSES.Attributes.Add("onclick","if(!cek_key('labarugi')){return false;};");
			
			readonly_teksbox();
			
		}

		private void initTgl()
		{
			GlobalTools.initDateForm(this.TXT_TGL_B36, this.DDL_BLN_B36, this.TXT_YEAR_B36, true);
			GlobalTools.initDateForm(this.TXT_TGL_C36, this.DDL_BLN_C36, this.TXT_YEAR_C36, true);
			GlobalTools.initDateForm(this.TXT_TGL_D36, this.DDL_BLN_D36, this.TXT_YEAR_D36, true);
			try
			{ 
				//this.DDL_BLN_B1.SelectedValue = DateTime.Now.Month.ToString();
				this.DDL_BLN_B36.SelectedValue = "-";
				this.DDL_BLN_C36.SelectedValue = "-";
				this.DDL_BLN_D36.SelectedValue = "-";
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

		private void viewdata()
		{
			conn.QueryString = "select POSISI_TGL,JML_BLN,JNS_LAP,year(posisi_tgl) tahun from CA_LABARUGI_SMALL where ap_regno = '"+ Request.QueryString["regno"] +"' ORDER BY POSISI_TGL DESC";
			conn.ExecuteQuery();
			
			//			System.Data.DataTable data = new DataTable(); 
			//			data = conn.GetDataTable().Copy();
			DB_LBRG1.DataSource = conn.GetDataTable().Copy();
			DB_LBRG1.DataBind();
			for(int i = 0; i < DB_LBRG1.Items.Count; i++)
			{
				DB_LBRG1.Items[i].Cells[0].Text = tool.FormatDate(DB_LBRG1.Items[i].Cells[0].Text);
			}
		}

		private void viewdata_history()
		{
			//conn.QueryString = "select IS_DATE_PERIODE,IS_NUM_MONTH,IS_REPORTTYPE,year(IS_DATE_PERIODE) tahun from CA_LABARUGI_MIDDLE where ap_regno = '" + Request.QueryString["regno"]+ "' order by IS_DATE_PERIODE desc";
			conn.QueryString = "exec CA_LABARUGI_SMALL_HISTORY '" + Request.QueryString["curef"] + "', '" +
				Request.QueryString["regno"] + "' ";
			conn.ExecuteQuery();
			
			DG_LRHistory.DataSource = conn.GetDataTable().Copy();
			DG_LRHistory.DataBind();
			for(int i = 0; i < DG_LRHistory.Items.Count; i++)
			{
				DG_LRHistory.Items[i].Cells[1].Text = tool.FormatDate(DG_LRHistory.Items[i].Cells[1].Text);
			}
		}


		private void clear_field()
		{
			int cnt;
				
			conn.QueryString = "select CU_REF,AP_REGNO,POSISI_TGL,JML_BLN,JNS_LAP,SALES_ONCREDIT,IS_PENJ,IS_HPP,IS_PROSEN_PENJ1," +
				"IS_ADMOPR,IS_PROSEN_PENJ2,IS_LABAOPR,IS_SUSUT_TNHBGN,IS_SUSUT_ALAT,IS_SUSUT_INVKNDRN,IS_TTLSUSUT," +
				"IS_PNDPTN,IS_BIAYA_LAIN,IS_LABA_SBLBUNGA,IS_BUNGA,IS_LABA_SBLPJK,IS_PJK,IS_LABA_BRSH,IS_CURRENCY," +
				"IS_DENOMINATOR,SUMBERDATA,IS_PROYEKSI from ca_labarugi_small where ap_regno = '" + Request.QueryString["regno"] + "' order by posisi_tgl desc";
			conn.ExecuteQuery();
			cnt = conn.GetRowCount();

			conn.QueryString="select excel_field from ca_excel where excel_file = 'kmk_ki_small' and excel_type = 'is'";
			conn.ExecuteQuery();
				
			int row = 69;
			//for (int i = 0; i < cnt; i++)
			//TO DO :
			for (int i = 0; i < 3; i++)
			{
				row--;
				string vtmp = ((char)row).ToString();
				
				//for (int m=1;m<=conn.GetRowCount();m++)
				for (int m=37;m<=55;m++)
				{
					if (m==38)
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


		private void DB_LBRG1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;
			switch (cmd)
			{		  
				case "retrieve" :
					Response.Redirect("IS_KMK_KI_small.aspx?tahun=" + e.Item.Cells[3].Text +"&mode=retrieve&curef="+
						Request.QueryString["curef"]+"&regno="+Request.QueryString["regno"]+"&mc="+
						Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+
						"&programid="+Request.QueryString["programid"]+"&tc="+Request.QueryString["tc"]+
						"&viewmode="+Request.QueryString["viewmode"]+
						"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]);
					clear_field();
					retrieve_data();
					break;
				case "delete" :
					//Response.Redirect("IS_KMK_KI_small.aspx?tahun=" + e.Item.Cells[3].Text +"&mode=delete&regno="+Request.QueryString["regno"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]);
					//LBL_TAMPUNG.Text = e.Item.Cells[3].Text;
					//clear_field(LBL_TAMPUNG.Text);
					conn.QueryString = "exec CA_LABARUGI_SMALL_SP_DELETE '" + Request.QueryString["curef"]+ "','" + Request.QueryString["regno"]+ "'," +
						GlobalTools.ToSQLDate(e.Item.Cells[4].Text) + ",'" + e.Item.Cells[1].Text + "','" + e.Item.Cells[2].Text + "'";
					conn.ExecuteNonQuery();

					//delete ratio as well 
					CLS_CALCULATION.delete_ratio_small(Request.QueryString["regno"],conn);
					
					viewdata();
					clear_field();
					
					break;
				default :
					break;
			}
		}

		//private void retrieve_data(string vstr, string mode)
		private void retrieve_data()
		{
			int row;
			initTgl();
			
			conn.QueryString = "select is_proyeksi from ca_labarugi_small where year(posisi_tgl) = '" + Request.QueryString["tahun"] + "' and ap_regno = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("is_proyeksi")=="1")
				row = 69;
			else
				row = 68;


			conn.QueryString = "select top 3 CU_REF,AP_REGNO,POSISI_TGL,JML_BLN,JNS_LAP,SALES_ONCREDIT,IS_PENJ,IS_HPP,IS_PROSEN_PENJ1," +
				"IS_ADMOPR,IS_PROSEN_PENJ2,IS_LABAOPR,IS_SUSUT_TNHBGN,IS_SUSUT_ALAT,IS_SUSUT_INVKNDRN,IS_TTLSUSUT," +
				"IS_PNDPTN,IS_BIAYA_LAIN,IS_LABA_SBLBUNGA,IS_BUNGA,IS_LABA_SBLPJK,IS_PJK,IS_LABA_BRSH,IS_CURRENCY,IS_DENOMINATOR,SUMBERDATA,IS_PROYEKSI " +
				"from ca_labarugi_small where year(posisi_tgl) <= '" + Request.QueryString["tahun"] + "' and ap_regno = '" + Request.QueryString["regno"] + "' order by posisi_tgl desc";
			conn.ExecuteQuery();

			System.Data.DataTable dt;
			dt = conn.GetDataTable().Copy();
			int jml_row = dt.Rows.Count;

			conn.QueryString = "select excel_field from ca_excel where excel_file = 'kmk_ki_small' and excel_type = 'is'";
			conn.ExecuteQuery();

			
			for (int i = 0; i < jml_row; i++)
			{
				
				row--;
				string vtmp = ((char)row).ToString();
				int k = 6;
				int kk = 2;
				for (int m=36;m<39;m++)
				{
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
					if (Request.QueryString["mode"]=="retrieve")
						//if (mode=="retrieve")
					{
						if (m!=36)
						{
							if (m==38)
							{
								for (int nn=38;nn<39;nn++)
								{
									System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vtmp + nn.ToString());							
									try 
									{
										txt.Text = dt.Rows[i][kk].ToString();
										DDL_.SelectedValue = txt.Text;
									}
									catch(Exception ex)
									{
										txt.Text = dt.Rows[i][kk].ToString();
										DDL_.SelectedValue = "-";
										string temp = ex.ToString();
									}
								}
							}
							else
							{
								//txt.Text = myMoneyFormat_noDec(dt.Rows[i][kk].ToString());
								try { txt.Text = dt.Rows[i][kk].ToString(); }
								catch { txt.Text = "";}
							}
						} 
						else 
						{
							for (int n=36;n<37;n++)
							{
								System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmp + n.ToString());
								System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmp + n.ToString());
								System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmp + n.ToString());
								try 
								{
									DateTime excdate = Convert.ToDateTime(tool.FormatDate(dt.Rows[i][kk].ToString()));
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
					kk++;
				}
				
				for (int j = 39; j < 56; j++)
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + j.ToString());
					if (Request.QueryString["mode"]=="retrieve")
					{
						try { txt.Text = myMoneyFormat_noDec(dt.Rows[i][k].ToString()); }
						catch { txt.Text = "";}
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
			int row;
			initTgl();
			
			conn.QueryString = "select is_proyeksi from ca_labarugi_small where year(posisi_tgl) = '" + 
				tahun + "' and ap_regno = '" + regno + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("is_proyeksi")=="1")
				row = 69;
			else
				row = 68;


			conn.QueryString = "select top 3 CU_REF,AP_REGNO,POSISI_TGL,JML_BLN,JNS_LAP,SALES_ONCREDIT,IS_PENJ,IS_HPP,IS_PROSEN_PENJ1," +
				"IS_ADMOPR,IS_PROSEN_PENJ2,IS_LABAOPR,IS_SUSUT_TNHBGN,IS_SUSUT_ALAT,IS_SUSUT_INVKNDRN,IS_TTLSUSUT," +
				"IS_PNDPTN,IS_BIAYA_LAIN,IS_LABA_SBLBUNGA,IS_BUNGA,IS_LABA_SBLPJK,IS_PJK,IS_LABA_BRSH,IS_CURRENCY,IS_DENOMINATOR,SUMBERDATA,IS_PROYEKSI " +
				"from ca_labarugi_small where year(posisi_tgl) <= '" + tahun + "' and ap_regno = '" + regno + "' order by posisi_tgl desc";
			conn.ExecuteQuery();

			System.Data.DataTable dt;
			dt = conn.GetDataTable().Copy();
			int jml_row = dt.Rows.Count;

			conn.QueryString = "select excel_field from ca_excel where excel_file = 'kmk_ki_small' and excel_type = 'is'";
			conn.ExecuteQuery();

			
			for (int i = 0; i < jml_row; i++)
			{
				
				row--;
				string vtmp = ((char)row).ToString();
				int k = 6;
				int kk = 2;
				for (int m=36;m<39;m++)
				{
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
					if (m!=36)
					{
						if (m==38)
						{
							for (int nn=38;nn<39;nn++)
							{
								System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vtmp + nn.ToString());							
								try 
								{
									txt.Text = dt.Rows[i][kk].ToString();
									DDL_.SelectedValue = txt.Text;
								}
								catch(Exception ex)
								{
									txt.Text = dt.Rows[i][kk].ToString();
									DDL_.SelectedValue = "-";
									string temp = ex.ToString();
								}
							}
						}
						else
						{
							//txt.Text = myMoneyFormat_noDec(dt.Rows[i][kk].ToString());
							try { txt.Text = dt.Rows[i][kk].ToString(); }
							catch { txt.Text = "";}
						}
					} 
					else 
					{
						for (int n=36;n<37;n++)
						{
							System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmp + n.ToString());
							System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmp + n.ToString());
							System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmp + n.ToString());
							try 
							{
								DateTime excdate = Convert.ToDateTime(tool.FormatDate(dt.Rows[i][kk].ToString()));
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
					kk++;
				}
				
				for (int j = 39; j < 56; j++)
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + j.ToString());
					try { txt.Text = myMoneyFormat_noDec(dt.Rows[i][k].ToString()); }
					catch { txt.Text = "";}
					k++;
				}
				
				if (row<=66){ break; }
	
			}

		}

		/*		
		private string formatMoney_ind(string a)
		{
			string b,c,d;																	//a = 1,230.00
			c = Strings.Replace(myMoneyFormat_noDec(a),".", ";",1,-1,CompareMethod.Binary);	//c = 1,230;00
			b = Strings.Replace(c,",", ".",1,-1,CompareMethod.Binary);						//b = 1.230;00
			d = Strings.Replace(b,";", ",",1,-1,CompareMethod.Binary);						//d = 1.230,00
			
			return d;
		}
		*/

		private bool cek_tanggal()
		{
			if (TXT_TGL_B36.Text != "" && DDL_BLN_B36.SelectedIndex > 0 && TXT_YEAR_B36.Text != "")
				if(!GlobalTools.isDateValid(this,TXT_TGL_B36.Text,DDL_BLN_B36.SelectedValue,TXT_YEAR_B36.Text))
					return false;
			
			if (TXT_TGL_C36.Text != "" && DDL_BLN_C36.SelectedIndex > 0 && TXT_YEAR_C36.Text != "")
				if(!GlobalTools.isDateValid(this,TXT_TGL_C36.Text,DDL_BLN_C36.SelectedValue,TXT_YEAR_C36.Text))
					return false;

			if (TXT_TGL_D36.Text != "" && DDL_BLN_D36.SelectedIndex > 0 && TXT_YEAR_D36.Text != "")
				if(!GlobalTools.isDateValid(this,TXT_TGL_D36.Text,DDL_BLN_D36.SelectedValue,TXT_YEAR_D36.Text))
					return false;

			return true;
		}


		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if (!cek_tanggal())
				return;
			
			simpan_labarugi();
			CLS_CALCULATION.proses_calculate_small(this, Request.QueryString["regno"], Request.QueryString["curef"], conn);
		}

		private void simpan_labarugi()
		{
            //PUNDI
            //1. Kemungkinan tool.ConverFloat kurang akurat
            //2. Kemungkinan ketika retrieve proses konversi kurang detail

			if (TXT_B39.Text!="")
			{
				conn.QueryString = "exec ca_labarugi_small_sp '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'," + GlobalTools.ToSQLDate(TXT_TGL_B36.Text,DDL_BLN_B36.SelectedValue,TXT_YEAR_B36.Text) + "," + tool.ConvertNum(TXT_B37.Text) + ",'" + DDL_B38.SelectedValue + "'," + tool.ConvertFloat(TXT_B39.Text) + "," +
					tool.ConvertFloat(TXT_B40.Text) + "," + tool.ConvertFloat(TXT_B41.Text) + ", " + tool.ConvertFloat(TXT_B42.Text) + "," + tool.ConvertFloat(TXT_B43.Text) + "," + 
					tool.ConvertFloat(TXT_B44.Text) + "," + tool.ConvertFloat(TXT_B45.Text) + ", " + tool.ConvertFloat(TXT_B46.Text) + "," + tool.ConvertFloat(TXT_B47.Text) + "," +
					tool.ConvertFloat(TXT_B48.Text) + "," + tool.ConvertFloat(TXT_B49.Text) + "," + tool.ConvertFloat(TXT_B50.Text) + "," + tool.ConvertFloat(TXT_B51.Text) + "," +
					tool.ConvertFloat(TXT_B52.Text) + "," + tool.ConvertFloat(TXT_B53.Text) + "," + tool.ConvertFloat(TXT_B54.Text) + "," + tool.ConvertFloat(TXT_B55.Text) + ",'',''";			
				conn.ExecuteNonQuery();
			}
			if (TXT_C39.Text!="")
			{
				conn.QueryString = "exec ca_labarugi_small_sp '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'," + GlobalTools.ToSQLDate(TXT_TGL_C36.Text,DDL_BLN_C36.SelectedValue,TXT_YEAR_C36.Text) + "," + tool.ConvertNum(TXT_C37.Text) + ",'" + DDL_C38.SelectedValue + "'," + tool.ConvertFloat(TXT_C39.Text) + "," +
					tool.ConvertFloat(TXT_C40.Text) + "," + tool.ConvertFloat(TXT_C41.Text) + ", " + tool.ConvertFloat(TXT_C42.Text) + "," + tool.ConvertFloat(TXT_C43.Text) + "," + 
					tool.ConvertFloat(TXT_C44.Text) + "," + tool.ConvertFloat(TXT_C45.Text) + ", " + tool.ConvertFloat(TXT_C46.Text) + "," + tool.ConvertFloat(TXT_C47.Text) + "," +
					tool.ConvertFloat(TXT_C48.Text) + "," + tool.ConvertFloat(TXT_C49.Text) + "," + tool.ConvertFloat(TXT_C50.Text) + "," + tool.ConvertFloat(TXT_C51.Text) + "," +
					tool.ConvertFloat(TXT_C52.Text) + "," + tool.ConvertFloat(TXT_C53.Text) + "," + tool.ConvertFloat(TXT_C54.Text) + "," + tool.ConvertFloat(TXT_C55.Text) + ",'',''";			
				conn.ExecuteNonQuery();
			}

			if (TXT_D39.Text!="")
			{
				conn.QueryString = "exec ca_labarugi_small_sp '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'," + GlobalTools.ToSQLDate(TXT_TGL_D36.Text,DDL_BLN_D36.SelectedValue,TXT_YEAR_D36.Text) + "," + tool.ConvertNum(TXT_D37.Text) + ",'" + DDL_D38.SelectedValue + "'," + tool.ConvertFloat(TXT_D39.Text) + "," +
					tool.ConvertFloat(TXT_D40.Text) + "," + tool.ConvertFloat(TXT_D41.Text) + ", " + tool.ConvertFloat(TXT_D42.Text) + "," + tool.ConvertFloat(TXT_D43.Text) + "," + 
					tool.ConvertFloat(TXT_D44.Text) + "," + tool.ConvertFloat(TXT_D45.Text) + ", " + tool.ConvertFloat(TXT_D46.Text) + "," + tool.ConvertFloat(TXT_D47.Text) + "," +
					tool.ConvertFloat(TXT_D48.Text) + "," + tool.ConvertFloat(TXT_D49.Text) + "," + tool.ConvertFloat(TXT_D50.Text) + "," + tool.ConvertFloat(TXT_D51.Text) + "," +
					tool.ConvertFloat(TXT_D52.Text) + "," + tool.ConvertFloat(TXT_D53.Text) + "," + tool.ConvertFloat(TXT_D54.Text) + "," + tool.ConvertFloat(TXT_D55.Text) + ",'','1'";			
				conn.ExecuteNonQuery();
			}
			viewdata();
		}

		private void DG_LRHistory_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;

			switch (cmd)
			{
				case "retrieve_history" :
					//string vtemp = e.Item.Cells[3].Text;
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

		private void clear_field_history(string vtahun)
		{
			int cnt;
				
			//conn.QueryString = "select * from ca_labarugi_middle where year(is_date_periode) > '" + vtahun + "' and ap_regno = '" + Request.QueryString["regno"]+ "'";
			conn.QueryString = "select CU_REF,AP_REGNO,POSISI_TGL,JML_BLN,JNS_LAP,SALES_ONCREDIT,IS_PENJ,IS_HPP,IS_PROSEN_PENJ1," +
				"IS_ADMOPR,IS_PROSEN_PENJ2,IS_LABAOPR,IS_SUSUT_TNHBGN,IS_SUSUT_ALAT,IS_SUSUT_INVKNDRN,IS_TTLSUSUT," +
				"IS_PNDPTN,IS_BIAYA_LAIN,IS_LABA_SBLBUNGA,IS_BUNGA,IS_LABA_SBLPJK,IS_PJK,IS_LABA_BRSH,IS_CURRENCY,IS_DENOMINATOR,SUMBERDATA,IS_PROYEKSI " +
				"from ca_labarugi_small where year(posisi_tgl) > '" + vtahun + "' and ap_regno = '" + Request.QueryString["regno"]+ "'";
			conn.ExecuteQuery();
			cnt = conn.GetRowCount();

			conn.QueryString="select excel_field from ca_excel where excel_file = 'kmk_ki_middle' and excel_type = 'is'";
			conn.ExecuteQuery();
				
			int row = 65;
			for (int i = 0; i < cnt; i++)
			{
				row++;
				string vtmp = ((char)row).ToString();

				int mulai = 36;
				for (int m=mulai;m<mulai+conn.GetRowCount();m++)
				{
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
					txt.Text = "";
				}
			}
			DDL_B38.SelectedValue = "-";
			DDL_C38.SelectedValue = "-";
			DDL_D38.SelectedValue = "-";
			initTgl();
		}

		private void retrieve_datahistory(string vtahun, string mode)
		{
			if (mode == "retrieve_history")
			{
				clear_field_history(vtahun);
				/********* start retrieve **************************/
				System.Data.DataTable dt = new System.Data.DataTable();
				conn.QueryString = "select CU_REF,AP_REGNO,IS_DATE_PERIODE,IS_NUM_MONTH IS_REPORTTYPE,IS_SALES_ONCR,IS_NET_SALES," +
					"IS_COST_GS,IS_PROSEN1,IS_GROSS_MARGIN,IS_PROSEN2,IS_SELLING_GENADM,IS_PROSEN3,IS_OPR_EARN," +
					"IS_PROSEN4,IS_DEPRECIATE,IS_AMORTIZATION1,IS_AMORTIZATION2,IS_OTH_INCM_NET,IS_EXTRAORD,IS_EARN_BIT," +
					"IS_INTRST_EXP,IS_EARN_BT,IS_PROSEN5,IS_INCM_TAX,IS_NET_INCM,IS_PROSEN6,IS_CURRENCY,IS_DENOMINATOR,IS_SUMBERDATA,IS_ISPROYEKSI from ca_labarugi_middle where year(is_date_periode) <= '" + vtahun + "' and ap_regno = '" + Request.QueryString["regno"]+ "'";
				conn.ExecuteQuery();
				int jml_baris = conn.GetRowCount();
				
				dt = conn.GetDataTable().Copy();
				
				int hrf = 68;
				for (int ii = 0; ii < jml_baris; ii++)
				{
					hrf--;
					string vtmpe = ((char)hrf).ToString();
					int start = 1;
					
					for (int n=36;n<39;n++)
					{
						System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_" + vtmpe + n.ToString());
						start++;
						if (n==36)
						{
							System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmpe + n.ToString());
							System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmpe + n.ToString());
							System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmpe + n.ToString());
					
							DateTime excdatestr = Convert.ToDateTime(tool.FormatDate(dt.Rows[ii][2].ToString()));
							GlobalTools.fillDateForm(TXT_TGL_, DDL_BLN_, TXT_YEAR_, excdatestr);
						}
						else if (n==38)
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
					for (int nnn=39;nnn<56;nnn++)
					{
						int temp = 0;
						System.Web.UI.WebControls.TextBox teksboks = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_" + vtmpe + nnn.ToString());				
						if (nnn == 39) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][6].ToString()); }
						else if (nnn == 40) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][7].ToString()); }
						else if (nnn == 41) { teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][8].ToString()); }
						else if (nnn == 42)	{ teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][11].ToString()); }
						else if (nnn == 43)	{ teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][12].ToString()); }
						else if (nnn == 48)	{ teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][16].ToString()); }
						else if (nnn == 49)	{ teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][19].ToString()); }
						else if (nnn == 50)	{ teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][19].ToString()); }
						else if (nnn == 51)	{ teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][20].ToString()); }
						else if (nnn == 52)	{ teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][21].ToString()); }
						else if (nnn == 53)	{ teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][22].ToString()); }
						else if (nnn == 54)	{ teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][24].ToString()); }
						else if (nnn == 55)	{ teksboks.Text = myMoneyFormat_noDec(dt.Rows[ii][25].ToString()); }
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

		private void BTN_PROSES_Click(object sender, System.EventArgs e)
		{
			//proses_calculate();
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			clear_field();
		}

		private void readonly_teksbox()
		{
			conn.QueryString = "select excel_cell1,excel_cell2,excel_cell3 from ca_excel where table_name = 'ca_labarugi_small' " +
				//" and excel_field in ('IS_PROSEN_PENJ1','IS_PROSEN_PENJ2','IS_LABAOPR','IS_TTLSUSUT','IS_LABA_SBLBUNGA','IS_LABA_SBLPJK','IS_LABA_BRSH')";
                //Bank Papua 2017-09-27 - - - 
                " and excel_field in ('IS_PROSEN_PENJ1','IS_PROSEN_PENJ2','IS_LABAOPR','IS_TTLSUSUT','IS_LABA_SBLPJK','IS_LABA_BRSH')";
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

	}
}