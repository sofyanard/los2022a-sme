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
	/// Summary description for RATIO_KMK_KI_MEDIUM.
	/// </summary>
	public partial class RATIO_KMK_KI_MEDIUM : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.TextBox Textbox33;
		protected System.Web.UI.WebControls.TextBox Textbox36;
		protected System.Web.UI.WebControls.TextBox Textbox57;
		protected System.Web.UI.WebControls.TextBox Textbox58;
		protected System.Web.UI.WebControls.DropDownList DropDownList4;
		protected System.Web.UI.WebControls.TextBox TXT_YEAR_C1;
		protected System.Web.UI.WebControls.TextBox TXT_TGL_D1;
		protected System.Web.UI.WebControls.DropDownList DDL_BLN_D1;
		protected System.Web.UI.WebControls.TextBox TXT_;
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (Request.QueryString["viewmode"] == "1")
			{
				BTN_UPDATE.Visible = false;
			}

			if (!IsPostBack)
			{
				retrieve_data();
				//retrieve_data_rekon();	
			}

			ViewMenu();
			ViewSubMenu();
			//BTN_SIMPANSAJA.Attributes.Add("onclick","if(!cek_ratio('middle',5,20)){return false;};");
			readonly_teksbox();

		}

		private void initTgl()
		{
			GlobalTools.initDateForm(this.TXT_TGL_B2, this.DDL_BLN_B2, this.TXT_YEAR_B2, true);
			GlobalTools.initDateForm(this.TXT_TGL_C2, this.DDL_BLN_C2, this.TXT_YEAR_C2, true);
			GlobalTools.initDateForm(this.TXT_TGL_D2, this.DDL_BLN_D2, this.TXT_YEAR_D2, true);
			GlobalTools.initDateForm(this.TXT_TGL_E2, this.DDL_BLN_E2, this.TXT_YEAR_E2, true);
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
				/*string programid = (string) Session["programid"];
				string jnsnasabah = (string) Session["jnsnasabah"];*/

				conn.QueryString = "select distinct top 1 cu_jnsnasabah from customer where cu_ref in (Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+ "')";
				conn.ExecuteQuery();
				string jnsnasabah = conn.GetFieldValue("cu_jnsnasabah").ToString();
				//------------------------------------------------------------------------------
					
				conn.QueryString = "select distinct top 1 programid from rfprogram where programid in (select prog_code from application where ap_regno = '"+Request.QueryString["regno"]+ "')";
				conn.ExecuteQuery();
				string programid = conn.GetFieldValue("programid").ToString();

				conn.QueryString = "select * from screensubmenu where lg_code in (select distinct lg_code " + 
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

					if (conn.GetFieldValue(i,5).IndexOf("?mode=") < 0 && conn.GetFieldValue(i,5).IndexOf("&mode=") < 0) 
						strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&tc="+Request.QueryString["tc"]+"&tahun="+(string) Session["tahun"]+"&mode="+Request.QueryString["mode"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
					else
						strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&tc="+Request.QueryString["tc"]+"&tahun="+(string) Session["tahun"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
					
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

		}
		#endregion
		
		private void retrieve_data()
		{
			int row;
			initTgl();
			
			//conn.QueryString = "select is_proyeksi from ca_ratio_middle where year(date_periode) = '" + Request.QueryString["tahun "] + "' and ap_regno = '" + Request.QueryString["regno"] + "'";

			conn.QueryString = "select top 1 is_proyeksi, year(date_periode) as tahun from ca_ratio_middle where ap_regno = '" + Request.QueryString["regno"] + "' order by date_periode desc";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("is_proyeksi")=="1")
				row = 70;
			else
				row = 69;
			string tahun = conn.GetFieldValue("tahun");
			Session.Add("tahun", tahun);
			
			/*
			CLS_CALCULATION.proses_calculate(this, Request.QueryString["regno"], Request.QueryString["curef"],
				Request.QueryString["tahun"], conn); //ahmad
			*/

			//conn.QueryString = "select top 4 * from ca_ratio_middle where year(date_periode) <= '" + (string) Session["tahun"] + "' and ap_regno = '" + Request.QueryString["regno"] + "' order by date_periode desc";

			conn.QueryString = "select top 4 " + 
				"CU_REF, AP_REGNO, DATE_PERIODE, NUMBEROFMONTH, REPORTTYPE, " +
				"SALESONCREDIT, CURRENT_RATIO, QUICK_ASSET_RATIO, " +
				"NET_WORKING_CAPITAL, GROSS_PROFIT_MARGIN, EBITDA, " +
				"OPR_PROFIT_MARGIN, NET_PROFITMARGIN, ROE, " +
				"RETURN_AVRG_EQUITY, ROA, RETURN_AVRG_ASSET, " +
				"TOTAL_EQUITY, DEBT_EQUITY_RATIO, LEVERAGE, " +
				"LONGTERM_DEBT_TO_EQUITY, DEBT_TO_ASSETS, INTEREST_COVERAGE_RATIO, " +
				"INTEREST_TO_SALES_RATIO, EBITDA_TO_INTERESTEXPENSE, EBITDA_TO_DEBT, " +
				"EBITDA_TO_LIABILITIES, DEBT_TO_EBITDA, DSC, " +
				"ASSETS_TURNOVER, FIXED_ASSETS_TURNOVER, INVENTORY_TURNOVER, " +
				"RECEIVABLE_TURNOVER, ACCPAYABLE_TURNOVER, DAYS_INVENTORY, " +
				"DAYS_RECEIVABLE, DAYS_PAYABLE, DAYS_TC, " +
				"EBITDA_GROWTH, NET_INCOME_GROWTH, SALES_GROWTH, " +
				"DEBT_TO_CAPITAL, OPERATING_MARGIN, SALES_TO_WK_CAPITAL, " +
				"BUSINESS_DEBT_SERV_RATIO, " + 
				"GEARING_RATIO, " +
				"NET_REVENUE_PERMONTH, " +
				"ACCRECEIVABLE_TO_ASSET, " +
				"ACCRECEIVABLE_TO_LIABILITIES, " +
				"EQUITY_TO_ASSET, " +
				"ASSET_GROWTH, " +
				"RECEIVABLES_GROWTH, " +
				"EQUITY_GROWTH, " +
				"EFICIENCY_RATIO, " +
				"TOTAL_ASSET, " +
				"SALES_GROWTH_RATE, INTEREST_AVEBANKDEBT, " +
				"SALES_AVEASSET, LONG_TERM_LVRG, TIME_INTRST_EARN, " +
				"DEBT_SERV_COVERAGE, NET_WORTH, DEBT_TO_NETWORTH, " +
				"NPV, IRR, PAYBACK, SUMBERDATA, IS_PROYEKSI " +
				"from ca_ratio_middle where year(date_periode) <= '" + (string) Session["tahun"] + "' " + 
				"and ap_regno = '" + Request.QueryString["regno"] + "' order by date_periode desc";
			conn.ExecuteQuery();

			System.Data.DataTable dt;
			dt = conn.GetDataTable().Copy();

			if (dt.Rows.Count == 0) 
			{
				GlobalTools.popMessage(this, "Neraca dan Laba-Rugi tidak boleh kosong!");
				return;
			}
	
			/// Investasi
			/// 
			TXT_NPV.Text = GlobalTools.MoneyFormat(dt.Rows[0]["NPV"].ToString());
			TXT_IRR.Text = GlobalTools.MoneyFormat(dt.Rows[0]["IRR"].ToString()); 
			TXT_PAYBACK.Text = GlobalTools.MoneyFormat(dt.Rows[0]["PAYBACK"].ToString());

			int jml_row = dt.Rows.Count;
			for (int i = 0; i < jml_row; i++)
			{
				
				row--;
				string vtmp = ((char)row).ToString();
				int k = 5;
				int kk = 2;
				int kkk = 29;
				for (int m=2;m<4;m++)
				{
					
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
					//if (Request.QueryString["mode"]=="retrieve")
					//{
					if (m==2)
					{
						System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmp + m.ToString());
						System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmp + m.ToString());
						System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmp + m.ToString());

						try { GlobalTools.fillDateForm(TXT_TGL_, DDL_BLN_, TXT_YEAR_, Convert.ToDateTime(dt.Rows[i][kk].ToString())); }
						catch 
						{
							TXT_TGL_.Text = "";
							DDL_BLN_.SelectedValue = "-";	
							TXT_YEAR_.Text = "";
						}
					} 
					else 
					{
						try { txt.Text = dt.Rows[i][kk].ToString(); }
						catch { txt.Text = "";}
					}			
					//} 
					//else 
					//{
					//	txt.Text = "";
					//}
					kk++;
				}
				
				// added by nyoman
				//---------------------
				for (int r = 4; r <= 4; r++)	
				{	
					System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vtmp + r.ToString());
					//if (Request.QueryString["mode"]=="retrieve")
					//{
					try { DDL_.SelectedValue = dt.Rows[i][4].ToString(); }	
					catch { }
					//}
				}
				//---------------------

				for (int j = 5; j <= 54; j++)		//modified by nyoman; was: for(int j = 5; j <= 21; j++)
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + j.ToString());
					//if (Request.QueryString["mode"]=="retrieve")
					//{
					try { txt.Text = tool.MoneyFormat(dt.Rows[i][k].ToString()); }
					catch { txt.Text = "";}
					//}
					//else 
					//{
					//	txt.Text = "";
					//}
					k++;
				}
				/*
				// added by nyoman
				//---------------------
				for (int q = 21; q <= 21; q++)	
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + q.ToString());
					//if (Request.QueryString["mode"]=="retrieve")
					//{
					try { txt.Text = tool.MoneyFormat(dt.Rows[i][23].ToString()); }	//networth
					catch { txt.Text = "";}
					//}
					//else 
					//{
					//	txt.Text = "";
					//}
				}
				//---------------------
				// new script sebenernya nggak perlu,. tp dicoba dulu
				for (int p = 22; p <= 24; p++)
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + p.ToString());
					//if (Request.QueryString["mode"]=="retrieve")
					//{
					try { txt.Text = tool.MoneyFormat(dt.Rows[i][kkk].ToString()); }
					catch { txt.Text = "";}
					//}
					//else 
					//{
					//	txt.Text = "";
					//}
					kkk++;
				}
				*/
				if (row<=66){ break; }
			}
		}	

		private void retrieve_data_rekon()
		{
			int row;
			
			conn.QueryString = "select is_proyeksi from ca_rekon_middle where year(date_periode) = '" + (string) Session["tahun"] + "' and ap_regno = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("is_proyeksi")=="1")
				row = 70;
			else
				row = 69;


			conn.QueryString = "select top 4 * from ca_rekon_middle where year(date_periode) <= '" + (string) Session["tahun"] + "' and ap_regno = '" + Request.QueryString["regno"] + "' order by date_periode desc";
			conn.ExecuteQuery();

			System.Data.DataTable dt;
			dt = conn.GetDataTable().Copy();
			int jml_row = dt.Rows.Count;
			for (int i = 0; i < jml_row; i++)
			{
				row--;
				string vtmp = ((char)row).ToString();
				int k = 4;
				for (int j = 6; j <= 27; j++)
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_REKON_" + vtmp + j.ToString());
					if (Request.QueryString["mode"]=="retrieve")
					{
						try { txt.Text = tool.MoneyFormat(dt.Rows[i][k].ToString()); }
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
		
		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec ca_ratio_middle_sp_npv '" + Request.QueryString["regno"] + "'," + tool.ConvertFloat(TXT_NPV.Text) + "," +
				tool.ConvertFloat(TXT_IRR.Text) + "," + tool.ConvertFloat(TXT_PAYBACK.Text) + "";
			conn.ExecuteNonQuery();

			conn.QueryString = "select * from ca_ratio_middle where date_periode = (" +
				" select max(date_periode) from ca_ratio_middle where ap_regno = '" + Request.QueryString["regno"] + "')";
			conn.ExecuteQuery();
			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();
			

			if (!dt.Rows.Count.Equals(""))
				//if (!conn.GetRowCount().Equals(""))
			{
				conn.QueryString = "exec app_proyeksi_ratio_sp '" + Request.QueryString["curef"] + "','" +  Request.QueryString["regno"] + "'," +
					tool.ConvertFloat(TXT_NPV.Text) + "," + tool.ConvertFloat(TXT_IRR.Text) + "," + tool.ConvertFloat(TXT_PAYBACK.Text) + "," +
					tool.ConvertFloat(dt.Rows[0]["ROA"].ToString()) + "," + tool.ConvertFloat(dt.Rows[0]["ROE"].ToString()) + "," + tool.ConvertFloat(dt.Rows[0]["NET_PROFITMARGIN"].ToString()) + "," +
					tool.ConvertFloat(dt.Rows[0]["ROI"].ToString()) + "," + tool.ConvertFloat(dt.Rows[0]["NET_WORTH"].ToString()) + "," + tool.ConvertFloat(dt.Rows[0]["DEBT_EQUITY_RATIO"].ToString()) + "," +
					tool.ConvertFloat(dt.Rows[0]["COLLATERAL_COVERAGE"].ToString()) + "," + tool.ConvertFloat(dt.Rows[0]["CURRENT_RATIO"].ToString()) + "," + tool.ConvertFloat(dt.Rows[0]["DEBT_SERV_COVERAGE"].ToString()) + "," +
					tool.ConvertFloat(dt.Rows[0]["DAYS_RECEIVABLE"].ToString()) + "," + tool.ConvertFloat(dt.Rows[0]["DAYS_INVENTORY"].ToString()) + "," + tool.ConvertFloat(dt.Rows[0]["DAYS_PAYABLE"].ToString()) + "," +
					tool.ConvertFloat(dt.Rows[0]["DAYS_TC"].ToString()) + "";
				conn.ExecuteNonQuery();	
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn));
		}	


		private void readonly_teksbox()
		{
			int row = 65;
			for (int i = 0; i <4; i++)
			{
				row++;
				string vtmp = ((char)row).ToString();
				for (int j = 2; j <= 44; j++)
				{	
					if (j==2)
					{
						System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmp + j.ToString());
						System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmp + j.ToString());
						System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmp + j.ToString());

						TXT_TGL_.BackColor = Color.Gainsboro;
						TXT_TGL_.ReadOnly = true;
						DDL_BLN_.BackColor = Color.Gainsboro;
						DDL_BLN_.Enabled = false;
						TXT_YEAR_.BackColor = Color.Gainsboro;
						TXT_YEAR_.ReadOnly = true;
					}
					else if (j==4)
					{
						System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vtmp + j.ToString());
						try 
						{
							DDL_.Enabled = false;
							DDL_.BackColor = Color.Gainsboro;
						}
						catch {}
					}
					else
					{
						System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + j.ToString());
						try 
						{
							txt.BackColor = Color.Gainsboro;
							txt.ReadOnly = true;
						}
						catch { }
					}
				}
				
			}

			//------------------------- start rekon
			int rowi = 65;
			for (int ii = 0; ii <4; ii++)
			{
				rowi++;
				string vtmpo = ((char)rowi).ToString();
				for (int jj = 6; jj <= 27; jj++)
				{	
					
					System.Web.UI.WebControls.TextBox txt_rekon = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_REKON_" + vtmpo + jj.ToString());
					try 
					{
						txt_rekon.BackColor = Color.Gainsboro;
						txt_rekon.ReadOnly = true;
					}
					catch { }
					
				}
				
			}
			
		}

		
	}
}