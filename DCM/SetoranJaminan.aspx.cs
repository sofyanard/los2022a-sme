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
	/// Summary description for SetoranJaminan.
	/// </summary>
	public partial class SetoranJaminan : System.Web.UI.Page
	{
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				DDL_BLN_BLOKIR.Items.Add(new ListItem("--Pilih--", ""));
				DDL_BLN_SETJAM.Items.Add(new ListItem("--Pilih--", ""));
				DDL_BLOKIR.Items.Add(new ListItem("--Pilih--", ""));
				DDL_GOL_PEMILIK.Items.Add(new ListItem("--Pilih--", ""));
				DDL_HUB_BANK.Items.Add(new ListItem("--Pilih--", ""));
				DDL_JNS_VALUTA.Items.Add(new ListItem("--Pilih--", ""));
				DDL_TUJUAN_HUB_BANK.Items.Add(new ListItem("--Pilih--", ""));

				for (int i = 1; i <= 12; i++)
				{
					DDL_BLN_BLOKIR.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_SETJAM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				conn2.QueryString = "SELECT * FROM VW_DC_INTERIM_TUJUAN_HUB_BANK";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_TUJUAN_HUB_BANK.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_VALUTA";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JNS_VALUTA.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_HUBDENGANBANK order by convert(int, hubexec_code)";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_HUB_BANK.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DC_INTERIM_GOL_PEMILIK";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_GOL_PEMILIK.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DC_INTERIM_BLOKIR";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_BLOKIR.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				ViewData();

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

		private void ViewData()
		{
			conn2.QueryString = "select cif#, customer, error_msg from interim where cif#='" + Request.QueryString["cif_no"] + "'";
			conn2.ExecuteQuery();

			TXT_ERROR_MSG.Text = conn2.GetFieldValue("error_msg");
			TXT_CUSTNAME.Text = conn2.GetFieldValue("customer");
			TXT_CIF.Text = conn2.GetFieldValue("cif#");

			conn2.QueryString = "select * from dc_interim where cif_cif#='" + Request.QueryString["cif_no"] + "'";
			conn2.ExecuteQuery();

			TXT_NILAI_BLOKIR.Text = tool.MoneyFormat(conn2.GetFieldValue("TRD_SETJAM_BLOKIR_VAL"));
			TXT_NILAI_SETJAM.Text = tool.MoneyFormat(conn2.GetFieldValue("TRD_SETJAM_VALUE"));
			try{DDL_BLOKIR.SelectedValue = conn2.GetFieldValue("TRD_SETJAM_BLOKIR_TYPE");}
			catch{DDL_BLOKIR.SelectedValue = "";}
			try{DDL_GOL_PEMILIK.SelectedValue = conn2.GetFieldValue("CIF_GOL_CUSTOMER");}
			catch{DDL_GOL_PEMILIK.SelectedValue = "";}
			try{DDL_HUB_BANK.SelectedValue = conn2.GetFieldValue("CIF_HUBUNGAN");}
			catch{DDL_HUB_BANK.SelectedValue = "";}
			try{DDL_JNS_VALUTA.SelectedValue = conn2.GetFieldValue("TRD_CURRENCY");}
			catch{DDL_JNS_VALUTA.SelectedValue = "";}
			try{DDL_TUJUAN_HUB_BANK.SelectedValue = conn2.GetFieldValue("AC_TUJUAN_PEMBU_REKG");}
			catch{DDL_TUJUAN_HUB_BANK.SelectedValue = "";}
			
			TXT_TGL_BLOKIR.Text = tool.FormatDate_Day(conn2.GetFieldValue("TRD_SETJAM_BLOKIR_DATE"));
			try{DDL_BLN_BLOKIR.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("TRD_SETJAM_BLOKIR_DATE"));}
			catch{DDL_BLN_BLOKIR.SelectedValue = "";}
			TXT_THN_BLOKIR.Text = tool.FormatDate_Year(conn2.GetFieldValue("TRD_SETJAM_BLOKIR_DATE"));
			TXT_TGL_SETJAM.Text = tool.FormatDate_Day(conn2.GetFieldValue("TRD_SETJAM_DATE"));
			try{DDL_BLN_SETJAM.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("TRD_SETJAM_DATE"));}
			catch{DDL_BLN_SETJAM.SelectedValue = "";}
			TXT_THN_SETJAM.Text = tool.FormatDate_Year(conn2.GetFieldValue("TRD_SETJAM_DATE"));
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn2.QueryString = "EXEC DC_INTERIM_SETJAM_INSERT '" + 
				TXT_CIF.Text + "', '" +
				TXT_CUSTNAME.Text + "', '" +
				DDL_JNS_VALUTA.SelectedValue + "', " +
				tool.ConvertFloat(TXT_NILAI_SETJAM.Text) + ", " +
				tool.ConvertDate(TXT_TGL_SETJAM.Text, DDL_BLN_SETJAM.SelectedValue, TXT_THN_SETJAM.Text) + ", " +
				tool.ConvertDate(TXT_TGL_BLOKIR.Text, DDL_BLN_BLOKIR.SelectedValue, TXT_THN_BLOKIR.Text) + ", '" +
				DDL_BLOKIR.SelectedValue + "', " +
				tool.ConvertFloat(TXT_NILAI_BLOKIR.Text) + ", '" +
				DDL_GOL_PEMILIK.SelectedValue + "', '" +
				DDL_HUB_BANK.SelectedValue + "', '" +
				DDL_TUJUAN_HUB_BANK.SelectedValue + "', 'SJ', '0', '" +
				Session["UserID"].ToString() + "', '" +
				Session["FullName"].ToString() + "'";
			conn2.ExecuteQuery();

			BTN_UPDATE.Visible = true;
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			TXT_NILAI_BLOKIR.Text = "";
			TXT_NILAI_SETJAM.Text = "";
			TXT_TGL_BLOKIR.Text = "";
			TXT_TGL_SETJAM.Text = "";
			TXT_THN_BLOKIR.Text = "";
			TXT_THN_SETJAM.Text = "";
			DDL_BLN_BLOKIR.SelectedValue = "";
			DDL_BLN_SETJAM.SelectedValue = "";
			DDL_BLOKIR.SelectedValue = "";
			DDL_GOL_PEMILIK.SelectedValue = "";
			DDL_HUB_BANK.SelectedValue = "";
			DDL_JNS_VALUTA.SelectedValue = "";
			DDL_TUJUAN_HUB_BANK.SelectedValue = "";
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			conn2.QueryString = "EXEC DC_INTERIM_SETJAM_INSERT '" + TXT_CIF.Text + "', '', '', '', '', '', '', '', '', '', '', '', '1', '" +
				Session["UserID"].ToString() + "', '" +
				Session["FullName"].ToString() + "'";
			conn2.ExecuteQuery();

			string msg = "Data Masuk ke List Pending Approval";

			Response.Redirect("TradeDataCompleteList.aspx?msg=" + msg);
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("TradeDataCompleteList.aspx");
		}
	}
}
