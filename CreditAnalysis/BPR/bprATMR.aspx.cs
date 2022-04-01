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
using System.Diagnostics;
using System.IO;


namespace SME.CreditAnalysis.BPR
{
	/// <summary>
	/// Summary description for bprNeraca.
	/// </summary>
	public partial class bprATMR : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txt_B2;
		protected System.Web.UI.WebControls.TextBox txt_C2;
		protected System.Web.UI.WebControls.TextBox txt_D2;
		protected System.Web.UI.WebControls.TextBox txt_BB33;
		protected System.Web.UI.WebControls.DropDownList ddl_B3;
		protected System.Web.UI.WebControls.DropDownList ddl_C3;
		protected System.Web.UI.WebControls.DropDownList ddl_D3;
		protected System.Web.UI.WebControls.TextBox TXT_PSV_TOTAL1;

		protected Connection conn;
		protected Connection2 conn2;
		private double totalAktiva;
		//protected Tools tool = new Tools();
	
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			conn2 = new Connection2();
			retrieve_dataATMR();

			ViewMenu();
			ViewSubMenu();
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


		/// <summary>
		/// Menyimpan data neraca dari form input ke database
		/// </summary>

		private void ViewDataATMR()
		{
			conn2.QueryString = "SELECT SYSCOLUMNS.[name] FROM SYSOBJECTS, SYSCOLUMNS WHERE SYSOBJECTS.[name] = 'CA_ATMR_BPR' AND SYSCOLUMNS.[ID] = SYSOBJECTS.[ID] AND SYSCOLUMNS.[name] not in ('CU_REF','AP_REGNO','POSISI_TGL')";
			conn2.ExecuteQuery();

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "1");
				System.Web.UI.WebControls.TextBox txt2 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "2");
				
				if(conn2.GetFieldValue("name") != "POSISI_TGL")
				{
					if(conn.GetFieldValue(0,conn2.GetFieldValue(i,"name")).ToString() != "")
					{
						txt1.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,conn2.GetFieldValue(i,"name")));
					}
					else
					{
						txt1.Text = "";
					}

					if(conn.GetFieldValue(1,conn2.GetFieldValue(i,"name")).ToString() != "")
					{
						txt2.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(1,conn2.GetFieldValue(i,"name")));
					}
					else
					{
						txt2.Text = "";
					}
				}
				else if(conn2.GetFieldValue("name") == "POSISI_TGL")
				{
					LBL_ATMR1.Text = conn.GetFieldValue(0,conn2.GetFieldValue(i,"name"));
					LBL_ATMR2.Text = conn.GetFieldValue(1,conn2.GetFieldValue(i,"name"));
				}
			}
		}

		private void ViewDataNeraca()
		{
			conn2.QueryString = "SELECT SYSCOLUMNS.[name] FROM SYSOBJECTS, SYSCOLUMNS WHERE SYSOBJECTS.[name] = 'CA_NERACA_BPR' AND SYSCOLUMNS.[ID] = SYSOBJECTS.[ID] AND SYSCOLUMNS.[name] not in ('CU_REF','AP_REGNO','SEQ') " +
				"AND SYSCOLUMNS.[name] in ('AKTV_KAS','AKTV_SBI','AKTV_ANTAR_BANK_AKTIVA','AKTV_KREDIT_YANG_DIBERIKAN'," +
				"'AKTV_AKTIVA_TETAP_DAN_INVENTARIS','AKTV_ANTAR_KANTOR_AKTIVA','AKTV_RUPA2_AKTVIVA','AKTV_TOTAL')";
			conn2.ExecuteQuery();

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "1");
				System.Web.UI.WebControls.TextBox txt2 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "2");
				
				if(conn2.GetFieldValue(i,"name") != "POSISI_TGL" || conn2.GetFieldValue(i,"name") != "DDAY" || conn2.GetFieldValue(i,"name") != "DMONTH" || conn2.GetFieldValue(i,"name") != "DYEAR")
				{
					string id = conn2.GetFieldValue(i,"name");

					if(conn.GetFieldValue(0,conn2.GetFieldValue(i,"name")).ToString() != "")
					{
						txt1.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,conn2.GetFieldValue(i,"name")));
					}
					else
					{
						txt1.Text = "";
					}

					if(conn.GetFieldValue(1,conn2.GetFieldValue(i,"name")).ToString() != "")
					{
						txt2.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(1,conn2.GetFieldValue(i,"name")));
					}
					else
					{
						txt2.Text = "";
					}
				}
			}

			viewTotalNeraca();
		}

		protected void viewTotalNeraca()
		{
			conn2.QueryString = "SELECT SYSCOLUMNS.[name] FROM SYSOBJECTS, SYSCOLUMNS WHERE SYSOBJECTS.[name] = 'CA_NERACA_BPR' AND SYSCOLUMNS.[ID] = SYSOBJECTS.[ID] AND SYSCOLUMNS.[name] not in ('CU_REF','AP_REGNO','SEQ') " +
				"AND SYSCOLUMNS.[name] in ('AKTV_KAS','AKTV_SBI','AKTV_ANTAR_BANK_AKTIVA','AKTV_KREDIT_YANG_DIBERIKAN'," +
				"'AKTV_AKTIVA_TETAP_DAN_INVENTARIS','AKTV_ANTAR_KANTOR_AKTIVA','AKTV_RUPA2_AKTVIVA')";
			conn2.ExecuteQuery();

			double tot1 = 0.0;
			double tot2 = 0.0;

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "1");
				System.Web.UI.WebControls.TextBox txt2 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "2");
				
				if(conn2.GetFieldValue(i,"name") != "POSISI_TGL" || conn2.GetFieldValue(i,"name") != "DDAY" || conn2.GetFieldValue(i,"name") != "DMONTH" || conn2.GetFieldValue(i,"name") != "DYEAR")
				{
					string id = conn2.GetFieldValue(i,"name");

					if(conn.GetFieldValue(0,conn2.GetFieldValue(i,"name")).ToString() != "")
					{
						txt1.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,conn2.GetFieldValue(i,"name")));
					}
					else
					{
						txt1.Text = "0,0";
					}


					if(conn.GetFieldValue(1,conn2.GetFieldValue(i,"name")).ToString() != "")
					{
						txt2.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(1,conn2.GetFieldValue(i,"name")));
					}
					else
					{
						txt2.Text = "0,0";
					}

					tot1 += MyConnection.ConvertToDouble2(txt1.Text.Replace(",",".").ToString());
					tot2 += MyConnection.ConvertToDouble2(txt2.Text.Replace(",",".").ToString());
				}
			}

			TXT_AKTV_TOTAL1.Text = GlobalTools.MoneyFormat(tot1.ToString());
			TXT_AKTV_TOTAL2.Text = GlobalTools.MoneyFormat(tot2.ToString());
		}


		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink("",Request.QueryString["mc"].ToString(), conn));
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);

			dg.DataSource = dt;				

			try
			{
				dg.DataBind();
			}
			catch 
			{
				dg.CurrentPageIndex = dg.PageCount - 1;
				dg.DataBind();
			}

			conn.ClearData();
		}

		private void retrieve_dataATMR()
		{
			string regno =  Request.QueryString["regno"];
			string curef = Request.QueryString["curef"];

			conn.QueryString = "EXEC BPR_GETATMR '" + curef + "','" + regno + "'";
			conn.ExecuteQuery();

			if(conn.GetRowCount() != 0)
			{
				string posisitgl1 = conn.GetFieldValue(1,"POSISI_TGL");

				ViewDataATMR();

				conn.QueryString = "EXEC BPR_GETATMRNERACA '" + curef + "','" + regno + "'," + GlobalTools.ToSQLDate(posisitgl1) + "";
				conn.ExecuteQuery();

				ViewDataNeraca();
			}
		}

		protected void btn_Save_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC CALCULATE_BPR_ATMR '" + Request.QueryString["regno"] + "','" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			retrieve_dataATMR();
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
						else	
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = "../" + conn.GetFieldValue(i, 3)+strtemp;
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
	}
}