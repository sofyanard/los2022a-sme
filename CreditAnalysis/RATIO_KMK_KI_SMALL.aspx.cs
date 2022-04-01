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

namespace TestSME.CreditAnalysis
{
	/// <summary>
	/// Summary description for RATIO_KMK_KI_SMALL.
	/// </summary>
	public partial class RATIO_KMK_KI_SMALL : System.Web.UI.Page
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
				BTN_UPDATE.Visible = false;
				TXT_NPV.BackColor = Color.Gainsboro;
				TXT_NPV.ReadOnly = true;
				TXT_IRR.BackColor = Color.Gainsboro;
				TXT_IRR.ReadOnly = true;
				TXT_PAYBACK.BackColor = Color.Gainsboro;
				TXT_PAYBACK.ReadOnly = true;
			}

			if (!IsPostBack)
			{
				retrieve_data();
				
			}
			ViewMenu();
			ViewSubMenu();
			readonly_teksbox();
			
		}

		private void initTgl()
		{
			GlobalTools.initDateForm(this.TXT_TGL_B1, this.DDL_BLN_B1, this.TXT_YEAR_B1, true);
			GlobalTools.initDateForm(this.TXT_TGL_C1, this.DDL_BLN_C1, this.TXT_YEAR_C1, true);
			GlobalTools.initDateForm(this.TXT_TGL_D1, this.DDL_BLN_D1, this.TXT_YEAR_D1, true);
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

				conn.QueryString = "select MENUCODE,BUSSUNITID,PROGRAMID,PROGRAMID_SEQ," +
					"SM_MENUDISPLAY,SM_LINKNAME,LG_CODE from screensubmenu where lg_code in (select distinct lg_code " + 
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
			
			conn.QueryString = "select top 1 is_proyeksi, year(posisi_tgl) as tahun from ca_ratio_small where ap_regno = '" + Request.QueryString["regno"] + "' order by posisi_tgl desc";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("is_proyeksi")=="1")
				row = 69;
			else
				row = 68;
			string tahun = conn.GetFieldValue("tahun");
			Session.Add("tahun", tahun);



			conn.QueryString = "select top 3 CU_REF,AP_REGNO,POSISI_TGL,JML_BLN," +
				"JNS_LAP,CURRENT_RATIO,DEBT_EQUITY_RATIO,RETURN_EQUITY,"+
				"NET_PROFIT_MARGIN,NET_WORTH,CASH_VELOCITY,DAYS_RECEIVABLE,DAYS_INVENTORY,DAYS_ACCPAYABLE,"+
				"TRADE_CYCLE,NETWORKING_CAPITAL,RETURN_ON_INVESTMENT,NET_PROFIT_GROWTH,TTL_ASSET_TURN_OVER,"+
				"DEBT_SERVICE_RATIO,COLLATERAL_COVERAGE,NPV,IRR,PAYBACK,ROA,ROE,SALES_TO_WK_CAPITAL,DEBT_TO_NETWORTH,"+
				"BUSINESS_DEBT_SERVICE_RATIO,SALES_INCREASE,NETINCOME_INCREASE,AVERAGE_NETPROFIT,SUMBERDATA,IS_PROYEKSI,"+
				"KASBANK_TO_HTBANKDG, HTBANKDG_TO_LABAOPR "+
				"from ca_ratio_small where year(posisi_tgl) <= '" + (string) Session["tahun"] + "' and ap_regno = '" + Request.QueryString["regno"] + "' order by posisi_tgl desc";
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
				int kkk = 26; //--- sales to working capital;
				int kkkk = 34; //--- cash bank to hutang bank dagang;
				for (int m=1;m<4;m++)
				{
					
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
					//if (Request.QueryString["mode"]=="retrieve")
					//{
					if (m==1)
					{
						System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmp + m.ToString());
						System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmp + m.ToString());
						System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmp + m.ToString());

						try { GlobalTools.fillDateForm(TXT_TGL_, DDL_BLN_, TXT_YEAR_, Convert.ToDateTime(dt.Rows[i][kk].ToString())); }
						catch 
						{
							TXT_TGL_.Text = "";
							DDL_BLN_.SelectedValue = "";	
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
				
				for (int j = 3; j <= 16; j++)
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

				for (int j = 17; j <= 19; j++)
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + j.ToString());
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

				for (int j = 20; j <= 21; j++)
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + j.ToString());
					//if (Request.QueryString["mode"]=="retrieve")
					//{
					try { txt.Text = tool.MoneyFormat(dt.Rows[i][kkkk].ToString()); }
					catch { txt.Text = "";}
					//}
					//else 
					//{
					//	txt.Text = "";
					//}
					kkkk++;
				}

				if (row<=66){ break; }
			}
		}	
		
		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec ca_ratio_small_sp_npv '" + Request.QueryString["regno"] + "'," + tool.ConvertFloat(TXT_NPV.Text) + "," +
				tool.ConvertFloat(TXT_IRR.Text) + "," + tool.ConvertFloat(TXT_PAYBACK.Text) + "";
			conn.ExecuteNonQuery();

			conn.QueryString = "select  CU_REF,AP_REGNO,POSISI_TGL,JML_BLN," +
				"JNS_LAP,CURRENT_RATIO,DEBT_EQUITY_RATIO,RETURN_EQUITY," +
				"NET_PROFIT_MARGIN,NET_WORTH,CASH_VELOCITY,DAYS_RECEIVABLE,DAYS_INVENTORY,DAYS_ACCPAYABLE," +
				"TRADE_CYCLE,NETWORKING_CAPITAL,RETURN_ON_INVESTMENT,NET_PROFIT_GROWTH,TTL_ASSET_TURN_OVER," +
				"DEBT_SERVICE_RATIO,COLLATERAL_COVERAGE,NPV,IRR,PAYBACK,ROA,ROE,SALES_TO_WK_CAPITAL,DEBT_TO_NETWORTH," +
				"BUSINESS_DEBT_SERVICE_RATIO,SALES_INCREASE,NETINCOME_INCREASE,AVERAGE_NETPROFIT,SUMBERDATA,IS_PROYEKSI from ca_ratio_small where posisi_tgl = (" +
				" select max(posisi_tgl) from ca_ratio_small where ap_regno = '" + Request.QueryString["regno"] + "')";
			conn.ExecuteQuery();
			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();
			

			if (!dt.Rows.Count.Equals(""))
				//if (!conn.GetRowCount().Equals(""))
			{
				conn.QueryString = "exec app_proyeksi_ratio_sp '" + Request.QueryString["curef"] + "','" +  Request.QueryString["regno"] + "'," +
					tool.ConvertFloat(TXT_NPV.Text) + "," + tool.ConvertFloat(TXT_IRR.Text) + "," + tool.ConvertFloat(TXT_PAYBACK.Text) + "," +
					tool.ConvertFloat(dt.Rows[0]["ROA"].ToString()) + "," + tool.ConvertFloat(dt.Rows[0]["ROE"].ToString()) + "," + tool.ConvertFloat(dt.Rows[0]["NET_PROFIT_MARGIN"].ToString()) + "," +
					tool.ConvertFloat(dt.Rows[0]["RETURN_ON_INVESTMENT"].ToString()) + "," + tool.ConvertFloat(dt.Rows[0]["NET_WORTH"].ToString()) + "," + tool.ConvertFloat(dt.Rows[0]["DEBT_EQUITY_RATIO"].ToString()) + "," +
					tool.ConvertFloat(dt.Rows[0]["COLLATERAL_COVERAGE"].ToString()) + "," + tool.ConvertFloat(dt.Rows[0]["CURRENT_RATIO"].ToString()) + "," + tool.ConvertFloat(dt.Rows[0]["DEBT_SERVICE_RATIO"].ToString()) + "," +
					tool.ConvertFloat(dt.Rows[0]["DAYS_RECEIVABLE"].ToString()) + "," + tool.ConvertFloat(dt.Rows[0]["DAYS_INVENTORY"].ToString()) + "," + tool.ConvertFloat(dt.Rows[0]["DAYS_ACCPAYABLE"].ToString()) + "," +
					tool.ConvertFloat(dt.Rows[0]["TRADE_CYCLE"].ToString()) + "";
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
			TXT_TGL_B1.BackColor = Color.Gainsboro;
			TXT_TGL_B1.ReadOnly = true;
			TXT_TGL_C1.BackColor = Color.Gainsboro;
			TXT_TGL_C1.ReadOnly = true;
			TXT_TGL_D1.BackColor = Color.Gainsboro;
			TXT_TGL_D1.ReadOnly = true;
			
			DDL_BLN_B1.BackColor = Color.Gainsboro;
			DDL_BLN_B1.Enabled = false;
			DDL_BLN_C1.BackColor = Color.Gainsboro;
			DDL_BLN_C1.Enabled = false;
			DDL_BLN_D1.BackColor = Color.Gainsboro;
			DDL_BLN_D1.Enabled = false;

			TXT_YEAR_B1.BackColor = Color.Gainsboro; 
			TXT_YEAR_B1.ReadOnly =true;
			TXT_YEAR_C1.BackColor = Color.Gainsboro;
			TXT_YEAR_C1.ReadOnly =true;
			TXT_YEAR_D1.BackColor = Color.Gainsboro;
			TXT_YEAR_D1.ReadOnly =true;

			int row = 65;
			for (int i = 0; i <3; i++)
			{
				row++;
				string vtmp = ((char)row).ToString();
				//for (int j = 2; j <= 19; j++)
				for (int j = 2; j <= 21; j++)
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
	}
}