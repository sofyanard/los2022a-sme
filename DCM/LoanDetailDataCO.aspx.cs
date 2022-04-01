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
	/// Summary description for LoanDetailDataCO.
	/// </summary>
	public partial class LoanDetailDataCO : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_ACQ;		
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			
			if (!IsPostBack)
			{
				ViewBulan();						
				JenisPar();
				ViewData();		
				BTN_UPDATE.Enabled=false;
			}

			ViewMenu();
			
		}

		private void ViewData()
		{
			conn2.QueryString = "select * from pending_loan_co where ACCTNO='"+ Request.QueryString["acctno"] +"' ";
			conn2.ExecuteQuery();
			TXT_TGL_PK_AWAL.Text = tool.FormatDate_Day(conn2.GetFieldValue("AC_1ST_PK_DATE"));
			try{DDL_BLN_PK_AWAL.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("AC_1ST_PK_DATE"));}
			catch{DDL_BLN_PK_AWAL.SelectedValue="";}
			TXT_THN_PK_AWAL.Text = tool.FormatDate_Year(conn2.GetFieldValue("AC_1ST_PK_DATE"));
			TXT_NOPK_AWAL.Text = conn2.GetFieldValue("AC_1ST_PKNO");
			TXT_TGL_PK_AKHIR.Text = tool.FormatDate_Day(conn2.GetFieldValue("AC_LAST_PK_DATE"));
			try{DDL_BLN_PK_AKHIR.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("AC_LAST_PK_DATE"));}
			catch{DDL_BLN_PK_AKHIR.SelectedValue="";}
			TXT_THN_PK_AKHIR.Text = tool.FormatDate_Year(conn2.GetFieldValue("AC_LAST_PK_DATE"));
			TXT_NOPK_AKHIR.Text = conn2.GetFieldValue("AC_LAST_PKNO");
			try{RDO_PPA.SelectedValue = conn2.GetFieldValue("AC_PPA_HITUNG_FLAG");}
			catch{RDO_PPA.SelectedValue = "1";}
			try{RDO_KOLE.SelectedValue = conn2.GetFieldValue("AC_AUTO_KOL_FLAG");}
			catch{RDO_KOLE.SelectedValue = "1";}
			try{RDO_FLAG.SelectedValue = conn2.GetFieldValue("AC_ONE_ENTITY_FLAG");}
			catch{RDO_FLAG.SelectedValue = "1";}
			try{RDO_RESTRU.SelectedValue = conn2.GetFieldValue("AC_RESTRU_FLAG");}
			catch{RDO_RESTRU.SelectedValue = "1";}
			TXT_TGL_REST_AW.Text = tool.FormatDate_Day(conn2.GetFieldValue("AC_START_RESTRU_DATE"));
			try{DDL_BLN_REST_AW.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("AC_START_RESTRU_DATE"));}
			catch{DDL_BLN_REST_AW.SelectedValue="";}
			TXT_THN_REST_AW.Text = tool.FormatDate_Year(conn2.GetFieldValue("AC_START_RESTRU_DATE"));
			TXT_TGL_REST_AKH.Text = tool.FormatDate_Day(conn2.GetFieldValue("AC_END_RESTRU_DATE"));
			try{DDL_BLN_REST_AKH.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("AC_END_RESTRU_DATE"));}
			catch{DDL_BLN_REST_AKH.SelectedValue="";}
			TXT_THN_REST_AKH.Text = tool.FormatDate_Year(conn2.GetFieldValue("AC_END_RESTRU_DATE"));
			try{DDL_JNS_REST.SelectedValue=conn2.GetFieldValue("AC_RESTRU_TYPE");}
			catch{DDL_JNS_REST.SelectedValue="";}
			try{DDL_KOLE.SelectedValue=conn2.GetFieldValue("AC_BIKOLE");}
			catch{DDL_KOLE.SelectedValue="";}
			TXT_TGL_RVW.Text = tool.FormatDate_Day(conn2.GetFieldValue("AC_RESTRU_REVIEW_DATE"));
			try{DDL_BLN_RVW.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("AC_RESTRU_REVIEW_DATE"));}
			catch{DDL_BLN_RVW.SelectedValue="";}
			TXT_THN_REST.Text = tool.FormatDate_Year(conn2.GetFieldValue("AC_RESTRU_REVIEW_DATE"));
			TXT_REST_KE.Text = conn2.GetFieldValue("AC_RESTRU_COUNT");
			try{DDL_KET_REST.SelectedValue=conn2.GetFieldValue("AC_RESTRU_MARK");}
			catch{DDL_KET_REST.SelectedValue="";}
			try{DDL_SANDI.SelectedValue=conn2.GetFieldValue("AC_KODE_POSISI");}
			catch{DDL_SANDI.SelectedValue="";}
			TXT_TGL_POS.Text = tool.FormatDate_Day(conn2.GetFieldValue("AC_POSISI_DATE"));
			try{DDL_BLN_POS.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("AC_POSISI_DATE"));}
			catch{DDL_BLN_POS.SelectedValue="";}
			TXT_THN_POS.Text = tool.FormatDate_Year(conn2.GetFieldValue("AC_POSISI_DATE"));
			try{DDL_MACET.SelectedValue=conn2.GetFieldValue("AC_SEBAB_MACET");}
			catch{DDL_MACET.SelectedValue="";}
			TXT_TGL_MCT.Text = tool.FormatDate_Day(conn2.GetFieldValue("AC_MACET_DATE"));
			try{DDL_BLN_MCT.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("AC_MACET_DATE"));}
			catch{DDL_BLN_MCT.SelectedValue="";}
			TXT_THN_MCT.Text = tool.FormatDate_Year(conn2.GetFieldValue("AC_MACET_DATE"));
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"' and sm_id not in ('A010303')";
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
							strtemp = "acctno=" + Request.QueryString["acctno"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"]+ "&exist=1";
						else	
							strtemp = "acctno=" + Request.QueryString["acctno"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+ "&exist=1";
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


		private void JenisPar()
		{
			DDL_JNS_REST.Items.Add(new ListItem("--Pilih--",""));
			conn2.QueryString="select * from RF_RESTRU_TYPE where active='1'";
			conn2.ExecuteQuery();
			for (int i = 0; i < conn2.GetRowCount(); i++) 
			{
				DDL_JNS_REST.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0))); 
			}

			DDL_KOLE.Items.Add(new ListItem("--Pilih--",""));
			conn2.QueryString="select * from RF_BICOL where active='1'";
			conn2.ExecuteQuery();
			for (int j = 0; j < conn2.GetRowCount(); j++) 
			{
				DDL_KOLE.Items.Add(new ListItem(conn2.GetFieldValue(j,1), conn2.GetFieldValue(j,0))); 
			}

			DDL_KET_REST.Items.Add(new ListItem("--Pilih--",""));
			conn2.QueryString="select * from RF_KET_RESTRU where active='1'";
			conn2.ExecuteQuery();
			for (int k = 0; k < conn2.GetRowCount(); k++) 
			{
				DDL_KET_REST.Items.Add(new ListItem(conn2.GetFieldValue(k,1), conn2.GetFieldValue(k,0))); 
			}

			DDL_SANDI.Items.Add(new ListItem("--Pilih--",""));
			conn2.QueryString="select * from RF_POSITION where active='1'";
			conn2.ExecuteQuery();
			for (int l = 0; l < conn2.GetRowCount(); l++) 
			{
				DDL_SANDI.Items.Add(new ListItem(conn2.GetFieldValue(l,1), conn2.GetFieldValue(l,0))); 
			}

			DDL_MACET.Items.Add(new ListItem("--Pilih--",""));
			conn2.QueryString="select * from RF_POSITION where active='1'";
			conn2.ExecuteQuery();
			for (int m = 0; m < conn2.GetRowCount(); m++) 
			{
				DDL_MACET.Items.Add(new ListItem(conn2.GetFieldValue(m,1), conn2.GetFieldValue(m,0))); 
			}
		}

		private void ViewBulan()
		{
			DDL_BLN_PK_AWAL.Items.Add(new ListItem("--Pilih--", ""));
			DDL_BLN_PK_AKHIR.Items.Add(new ListItem("--Pilih--",""));
			DDL_BLN_REST_AW.Items.Add(new ListItem("--Pilih--",""));
			DDL_BLN_REST_AKH.Items.Add(new ListItem("--Pilih--",""));
			DDL_BLN_RVW.Items.Add(new ListItem("--Pilih--",""));
			DDL_BLN_POS.Items.Add(new ListItem("--Pilih--",""));
			DDL_BLN_MCT.Items.Add(new ListItem("--Pilih--",""));
			
			for(int i=1; i<=12; i++)
			{
				DDL_BLN_PK_AWAL.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN_PK_AKHIR.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN_REST_AW.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN_REST_AKH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN_RVW.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN_POS.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN_MCT.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));				
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

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn2.QueryString = " exec DQM_LOAN_CO_INSERT '" +
				Request.QueryString["acctno"] + "', " +
				tool.ConvertDate(TXT_TGL_PK_AWAL.Text, DDL_BLN_PK_AWAL.SelectedValue, TXT_THN_PK_AWAL.Text) + ", '" +
				TXT_NOPK_AWAL.Text +"', "+				
				tool.ConvertDate(TXT_TGL_PK_AKHIR.Text, DDL_BLN_PK_AKHIR.SelectedValue, TXT_THN_PK_AKHIR.Text) + ", '" +
				TXT_NOPK_AKHIR.Text +"', '"+
				RDO_PPA.SelectedValue +"', '"+
				RDO_KOLE.SelectedValue +"', '"+
				RDO_FLAG.SelectedValue +"', '"+
				RDO_RESTRU.SelectedValue +"', "+
				tool.ConvertDate(TXT_TGL_REST_AW.Text, DDL_BLN_REST_AW.SelectedValue, TXT_THN_REST_AW.Text) + ", " +
				tool.ConvertDate(TXT_TGL_REST_AKH.Text, DDL_BLN_REST_AKH.SelectedValue, TXT_THN_REST_AKH.Text) + ", '" +				
				DDL_JNS_REST.SelectedValue +"','"+
				DDL_KOLE.SelectedValue  +"',"+
				tool.ConvertDate(TXT_TGL_RVW.Text, DDL_BLN_RVW.SelectedValue, TXT_THN_REST.Text) + ", '" +
				TXT_REST_KE.Text +"', '"+
				DDL_KET_REST.SelectedValue +"', '"+
				DDL_SANDI.SelectedValue +"', "+
				tool.ConvertDate(TXT_TGL_POS.Text, DDL_BLN_POS.SelectedValue, TXT_THN_POS.Text) + ", '" +
				DDL_MACET.SelectedValue +"', "+
				tool.ConvertDate(TXT_TGL_MCT.Text, DDL_BLN_MCT.SelectedValue, TXT_THN_MCT.Text) + ", '1' ";
			conn2.ExecuteNonQuery();

			BTN_UPDATE.Enabled = true;
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			conn2.QueryString = "update PENDING_LOAN_CO set status_flag='2' where ACCTNO='"+ Request.QueryString["acctno"] +"' ";
			conn2.ExecuteQuery();
			Response.Redirect("../Body.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		
	}
}
