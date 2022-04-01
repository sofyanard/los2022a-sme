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
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;
using System.Configuration;

namespace SME.DCM
{
	/// <summary>
	/// Summary description for CifGeneralData.
	/// </summary>
	public partial class CifDataKeuangan : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				DDL_BLN_LAP.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_DENO.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_AUDITED.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_CURR.Items.Add(new ListItem ("--Pilih--", ""));
				for (int i=1; i<=12; i++)
				{
					DDL_BLN_LAP.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));					
				}
				conn2.QueryString = "select * from denominator";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_DENO.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));

                conn.QueryString = "select currencyid,currencydesc from rfcurrency where active ='1' order by currencydesc";
				conn.ExecuteQuery();
				for (int j=0; j<conn.GetRowCount(); j++)
					DDL_CURR.Items.Add(new ListItem(conn.GetFieldValue(j,1),conn.GetFieldValue(j,0)));

				conn2.QueryString = "select * from rfaudit";
				conn2.ExecuteQuery();
				for (int k=0; k<conn2.GetRowCount(); k++)
					DDL_AUDITED.Items.Add(new ListItem(conn2.GetFieldValue(k,1),conn2.GetFieldValue(k,0)));

				ViewData();
				conn2.QueryString = "select flag from cif_data_keuangan where cifno= '"+Request.QueryString["cifno"]+"' ";
				conn2.ExecuteQuery();
				if (conn2.GetFieldValue("flag")== "1" || conn2.GetFieldValue("flag")== "2")
				{
					ViewDataAfterUpdate();
				}
			}
			ViewMenu();
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

		private void ViewData()
		{
			conn2.QueryString = "select * from cif_data_keuangan where cifno= '"+Request.QueryString["cifno"]+"' ";
			conn2.ExecuteQuery();
			TXT_TGL_LAP.Text = tools.FormatDate_Day(conn2.GetFieldValue("TGL_LAP"));
			try{DDL_BLN_LAP.SelectedValue = tools.FormatDate_Month(conn2.GetFieldValue("TGL_LAP"));}
			catch{DDL_BLN_LAP.SelectedValue = "";}
			TXT_THN_LAP.Text = tools.FormatDate_Year(conn2.GetFieldValue("TGL_LAP"));
			try{RDO_PINJAMAN_LN.SelectedValue = conn2.GetFieldValue("PINJAMAN_LN");}
			catch{RDO_PINJAMAN_LN.SelectedValue = "Y"; }
			try{DDL_DENO.SelectedValue = conn2.GetFieldValue("DENOMINASI");}
			catch{DDL_DENO.SelectedValue = "" ;}
			try{DDL_AUDITED.SelectedValue = conn2.GetFieldValue("AUDITED");}
			catch{DDL_AUDITED.SelectedValue = "" ;}	
			try{DDL_CURR.SelectedValue = conn2.GetFieldValue("CURRENCY");}
			catch{DDL_CURR.SelectedValue = "" ;}			
			TXT_JML_BLN.Text = conn2.GetFieldValue("JML_BLN");
			TXT_ACTIVA.Text = conn2.GetFieldValue("ACTIVA");
			TXT_TOT_ACTIVA.Text = conn2.GetFieldValue("TOT_ACTIVA");
			TXT_WJB_BANK.Text = conn2.GetFieldValue("WJB_BANK");
			TXT_WJB_LANCAR.Text = conn2.GetFieldValue("WJB_LANCAR");
			TXT_TOT_WJB.Text = conn2.GetFieldValue("TOT_WJB_BANK");
			TXT_MODAL.Text = conn2.GetFieldValue("MODAL");
			TXT_PENJUALAN.Text = conn2.GetFieldValue("PENJUALAN");
			TXT_POP.Text = conn2.GetFieldValue("PEN_OPRASI");
			TXT_BOP.Text = conn2.GetFieldValue("BIAYA_OPRASI");;
			TXT_NON_POP.Text = conn2.GetFieldValue("PEN_NON_OPERASI");;
			TXT_NON_BOP.Text = conn2.GetFieldValue("BIAYA_NON_OPERASI");;
			LR_AFTER.Text = conn2.GetFieldValue("LR_STLH_PJAK");
			LR_BEFORE.Text = conn2.GetFieldValue("LR_SBLM_PJAK");
		}

		private void ClearData()
		{
			TXT_TGL_LAP.Text = "";
			DDL_BLN_LAP.SelectedValue = "";
            TXT_THN_LAP.Text = "";
			RDO_PINJAMAN_LN.SelectedValue = "Y";
			DDL_DENO.SelectedValue = "";
			DDL_AUDITED.SelectedValue = "";
			DDL_CURR.SelectedValue = "";
			TXT_JML_BLN.Text = "";
			TXT_ACTIVA.Text = "";
			TXT_TOT_ACTIVA.Text = "";
			TXT_WJB_BANK.Text = "";
			TXT_WJB_LANCAR.Text = "";
			TXT_TOT_WJB.Text = "";
			TXT_MODAL.Text = "";
			TXT_PENJUALAN.Text = "";
			TXT_POP.Text = "";
			TXT_BOP.Text = "";
			TXT_NON_POP.Text = "";
			TXT_NON_BOP.Text = "";
			LR_AFTER.Text = "";
			LR_BEFORE.Text = "";
		}

		private void ViewDataAfterUpdate()
		{
			TXT_TGL_LAP.ReadOnly = true;
			DDL_BLN_LAP.Enabled = false;
			TXT_THN_LAP.ReadOnly = true;
			RDO_PINJAMAN_LN.Enabled = false;
			DDL_DENO.Enabled = false;
			DDL_AUDITED.Enabled = false;
			DDL_CURR.Enabled = false;
			TXT_JML_BLN.ReadOnly = true;
			TXT_ACTIVA.ReadOnly = true;
			TXT_TOT_ACTIVA.ReadOnly = true;
			TXT_WJB_BANK.ReadOnly = true;
			TXT_WJB_LANCAR.ReadOnly = true;
			TXT_TOT_WJB.ReadOnly = true;
			TXT_MODAL.ReadOnly = true;
			TXT_PENJUALAN.ReadOnly = true;
			TXT_POP.ReadOnly = true;
			TXT_BOP.ReadOnly = true;
			TXT_NON_POP.ReadOnly = true;
			TXT_NON_BOP.ReadOnly = true;
			LR_AFTER.ReadOnly = true;
			LR_BEFORE.ReadOnly = true;
			BTN_SAVE.Enabled = false;
			BTN_CLEAR.Enabled = false;
		}

		private void ViewMenu()
		{
			MenuCIF.Controls.Clear();
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
							strtemp = "cifno=" + Request.QueryString["cifno"];
						else	
							strtemp = "mc=" + Request.QueryString["mc"] + "&cifno=" + Request.QueryString["cifno"];
					}
					else 
					{
						strtemp = ""; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					MenuCIF.Controls.Add(t);
					MenuCIF.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn2.QueryString = "exec CIF_DATA_KEUANGAN_INSERT '"+ 
				Request.QueryString["cifno"] + "', " +
				tools.ConvertDate(TXT_TGL_LAP.Text, DDL_BLN_LAP.SelectedValue, TXT_THN_LAP.Text) + ", '" +
				RDO_PINJAMAN_LN.SelectedValue + "', '" +
				DDL_DENO.SelectedValue + "', '" +
				DDL_AUDITED.SelectedValue + "', '" +
				DDL_CURR.SelectedValue + "', " +
				tools.ConvertFloat(TXT_JML_BLN.Text) + ", " +
				tools.ConvertFloat(TXT_ACTIVA.Text) + ", " +
				tools.ConvertFloat(TXT_TOT_ACTIVA.Text) + ", " +
				tools.ConvertFloat(TXT_WJB_BANK.Text) + ", " +
				tools.ConvertFloat(TXT_WJB_LANCAR.Text) + ", " +
				tools.ConvertFloat(TXT_TOT_WJB.Text) + ", " +
				tools.ConvertFloat(TXT_MODAL.Text) + ", " +
				tools.ConvertFloat(TXT_PENJUALAN.Text) + ", " +
				tools.ConvertFloat(TXT_POP.Text) + ", " +
				tools.ConvertFloat(TXT_BOP.Text) + ", " +
				tools.ConvertFloat(TXT_NON_POP.Text) + ", " +
				tools.ConvertFloat(TXT_NON_BOP.Text) + ", " +
				tools.ConvertFloat(LR_AFTER.Text) + ", " +
				tools.ConvertFloat(LR_BEFORE.Text) +", '0', '"+ Session["USERID"].ToString() +"' ";
			conn2.ExecuteQuery();

			conn.QueryString = "select su_fullname from scuser where userid= '"+ Session["USERID"].ToString() +"' ";
			conn.ExecuteQuery();
			string pic_name;
			pic_name = conn.GetFieldValue("su_fullname");

			conn2.QueryString = "update cif_data_keuangan set pic_name= '"+ pic_name +"' where cifno= '"+Request.QueryString["cifno"]+"' ";
			conn2.ExecuteQuery();
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();			
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string from_appr;
			from_appr = Request.QueryString["from_appr"];
			if (Request.QueryString["from_appr"] == "0")
			Response.Redirect("CifListData.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
			else
			Response.Redirect("CifListDataApproval.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		

		
	}
}
