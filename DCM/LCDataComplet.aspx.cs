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
	/// Summary description for LCDataComplet.
	/// </summary>
	public partial class LCDataComplet : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Textbox14;
		protected System.Web.UI.WebControls.TextBox Textbox15;
		protected System.Web.UI.WebControls.TextBox Textbox16;
		protected System.Web.UI.WebControls.TextBox Textbox17;
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				DDL_BLN_JANGKA_WAKTU2.Items.Add(new ListItem("--Pilih--", ""));
				DDL_BLN_JATUH_TEMPO.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN_MULAI.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN_MULAI2.Items.Add(new ListItem("--Pilih--", ""));
				DDL_BLN_PEMERINGKAT.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN_PENILAIAN.Items.Add(new ListItem("--Pilih--",""));
				DDL_GOL_PEMOHON.Items.Add(new ListItem("--Pilih--",""));
				DDL_HUB_BANK.Items.Add(new ListItem("--Pilih--",""));
				DDL_JENIS_AGUNAN.Items.Add(new ListItem("--Pilih--",""));
				DDL_JENIS_VALUTA_AGUNAN.Items.Add(new ListItem("--Pilih--",""));
				DDL_JNS_NASABAH.Items.Add(new ListItem("--Pilih--",""));
				DDL_JNS_VALUTA.Items.Add(new ListItem("--Pilih--",""));
				DDL_LEMBAGA_PEMERINGKAT.Items.Add(new ListItem("--Pilih--",""));
				DDL_NEGARA_PEMOHON.Items.Add(new ListItem("--Pilih--",""));
				DDL_PENERBIT_AGUNAN.Items.Add(new ListItem("--Pilih--",""));
				DDL_PERINGKAT_PERUSAHAAN.Items.Add(new ListItem("--Pilih--",""));
				DDL_SIFAT_AGUNAN.Items.Add(new ListItem("--Pilih--",""));
				DDL_STATUS_PEMOHON.Items.Add(new ListItem("--Pilih--",""));
				DDL_TUJUAN_HUB_BANK.Items.Add(new ListItem("--Pilih--",""));

				for(int i=1; i<=12; i++)
				{
					DDL_BLN_JANGKA_WAKTU2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_JATUH_TEMPO.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_MULAI.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_MULAI2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_PEMERINGKAT.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_PENILAIAN.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				conn.QueryString = "select custtypeid, custtypedesc from [LOSSME]..rfcustomertype where active='1'";
				conn.ExecuteQuery();
				for(int i=0; i<conn.GetRowCount(); i++)
					DDL_JNS_NASABAH.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_VALUTA";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JNS_VALUTA.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_HUBDENGANBANK order by convert(int, hubexec_code)";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_HUB_BANK.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_LEMBAGAPEMERINGKAT";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_LEMBAGA_PEMERINGKAT.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_PERINGKATPERUSAHAAN";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_PERINGKAT_PERUSAHAAN.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_COLLATERAL_CORRECTION_DDLSIFATAGUNAN";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_SIFAT_AGUNAN.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select coltypeid, coltypedesc from [lossme]..rfcollateraltype";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JENIS_AGUNAN.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DC_INTERIM_TUJUAN_HUB_BANK";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_TUJUAN_HUB_BANK.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DC_INTERIM_GOL_PEMOHON";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_GOL_PEMOHON.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DC_INTERIM_STATUS_PEMOHON";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_STATUS_PEMOHON.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DC_INTERIM_NEGARA_PEMOHON";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_NEGARA_PEMOHON.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DC_INTERIM_JNS_VALUTA_AGUNAN";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JENIS_VALUTA_AGUNAN.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DC_INTERIM_PENERBIT_AGUNAN";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_PENERBIT_AGUNAN.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				BTN_UPDATE.Visible = false;

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
			TXT_CIF.Text = conn2.GetFieldValue("CIF#");
			TXT_NAME.Text = conn2.GetFieldValue("CUSTOMER");

			conn2.QueryString = "SELECT * FROM DC_INTERIM WHERE CIF_CIF#='" + Request.QueryString["cif_no"] + "'";
			conn2.ExecuteQuery();

			try {DDL_JNS_NASABAH.SelectedValue = conn2.GetFieldValue("CIF_P_JENIS");}
			catch {DDL_JNS_NASABAH.SelectedValue = "";}
			TXT_TGL_JATUH_TEMPO.Text = tool.FormatDate_Day(conn2.GetFieldValue("TRD_MATURITY_DATE"));
			try {DDL_BLN_JATUH_TEMPO.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("TRD_MATURITY_DATE"));}
			catch{DDL_BLN_JATUH_TEMPO.SelectedValue = "";}
			TXT_THN_JATUH_TEMPO.Text = tool.FormatDate_Year(conn2.GetFieldValue("TRD_MATURITY_DATE"));
			try{DDL_GOL_PEMOHON.SelectedValue = conn2.GetFieldValue("CIF_GOL_CUSTOMER");}
			catch{DDL_GOL_PEMOHON.SelectedValue = "";}
			TXT_JUMLAH.Text = tool.MoneyFormat(conn2.GetFieldValue("TRD_FACILITY_VAL"));
			try{DDL_JENIS_AGUNAN.SelectedValue = conn2.GetFieldValue("COL_JENIS");}
			catch{DDL_JENIS_AGUNAN.SelectedValue = "";}
			try {DDL_SIFAT_AGUNAN.SelectedValue = conn2.GetFieldValue("COL_CLASS");}
			catch{DDL_SIFAT_AGUNAN.SelectedValue = "";}
			TXT_NILAI_AGUNAN.Text = tool.MoneyFormat(conn2.GetFieldValue("COL_APPR_VAL"));
			TXT_TGL_PENILAIAN.Text = tool.FormatDate_Day(conn2.GetFieldValue("COL_LAST_APPR_DATE"));
			try{DDL_BLN_PENILAIAN.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("COL_LAST_APPR_DATE"));}
			catch{DDL_BLN_PENILAIAN.SelectedValue = "";}
			TXT_THN_PENILAIAN.Text = tool.FormatDate_Year(conn2.GetFieldValue("COL_LAST_APPR_DATE"));
			try{DDL_TUJUAN_HUB_BANK.SelectedValue = conn2.GetFieldValue("AC_TUJUAN_PEMBU_REKG");}
			catch{DDL_TUJUAN_HUB_BANK.SelectedValue = "";}
			try{DDL_JNS_VALUTA.SelectedValue = conn2.GetFieldValue("TRD_CURRENCY");}
			catch{DDL_JNS_VALUTA.SelectedValue = "";}
			TXT_TGL_MULAI.Text = tool.FormatDate_Day(conn2.GetFieldValue("TRD_FAC_ISSUED_DATE"));
			try{DDL_BLN_MULAI.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("TRD_FAC_ISSUED_DATE"));}
			catch{DDL_BLN_MULAI.SelectedValue = "";}
			TXT_THN_MULAI.Text = tool.FormatDate_Year(conn2.GetFieldValue("TRD_FAC_ISSUED_DATE"));
			try{DDL_HUB_BANK.SelectedValue = conn2.GetFieldValue("CIF_HUBUNGAN");}
			catch{DDL_HUB_BANK.SelectedValue = "";}
			try{DDL_STATUS_PEMOHON.SelectedValue = conn2.GetFieldValue("CIF_MARITAL");}
			catch{DDL_STATUS_PEMOHON.SelectedValue = "";}
			try{DDL_NEGARA_PEMOHON.SelectedValue = conn2.GetFieldValue("TRD_CUST_COUNTRY");}
			catch{DDL_NEGARA_PEMOHON.SelectedValue = "";}
			try{DDL_LEMBAGA_PEMERINGKAT.SelectedValue = conn2.GetFieldValue("CIF_RATING_COMP");}
			catch{DDL_LEMBAGA_PEMERINGKAT.SelectedValue = "";}
			try{DDL_PERINGKAT_PERUSAHAAN.SelectedValue = conn2.GetFieldValue("CIF_RATING_RESULT");}
			catch{DDL_PERINGKAT_PERUSAHAAN.SelectedValue = "";}
			TXT_TGL_PEMERINGKAT.Text = tool.FormatDate_Day(conn2.GetFieldValue("CIF_RATING_DATE"));
			try{DDL_BLN_PEMERINGKAT.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("CIF_RATING_DATE"));}
			catch{DDL_BLN_PEMERINGKAT.SelectedValue = "";}
			TXT_THN_PEMERINGKAT.Text = tool.FormatDate_Year(conn2.GetFieldValue("CIF_RATING_DATE"));
			try{DDL_JENIS_VALUTA_AGUNAN.SelectedValue = conn2.GetFieldValue("COL_CURRENCY");}
			catch{DDL_JENIS_VALUTA_AGUNAN.SelectedValue = "";}
			TXT_TGL_MULAI2.Text = tool.FormatDate_Day(conn2.GetFieldValue("COL_CERTIF_ISSUED_DATE"));
			try{DDL_BLN_MULAI2.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("COL_CERTIF_ISSUED_DATE"));}
			catch{DDL_BLN_MULAI2.SelectedValue = "";}
			TXT_THN_MULAI2.Text = tool.FormatDate_Year(conn2.GetFieldValue("COL_CERTIF_ISSUED_DATE"));
			TXT_TGL_JANGKA_WAKTU2.Text = tool.FormatDate_Day(conn2.GetFieldValue("COL_CERTIF_EXP_DATE"));
			try{DDL_BLN_JANGKA_WAKTU2.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("COL_CERTIF_EXP_DATE"));}
			catch{DDL_BLN_JANGKA_WAKTU2.SelectedValue = "";}
			TXT_THN_JANGKA_WAKTU2.Text = tool.FormatDate_Year(conn2.GetFieldValue("COL_CERTIF_EXP_DATE"));
			TXT_PARIPASU.Text = tool.MoneyFormat(conn2.GetFieldValue("PLEDGING"));
			try{DDL_PENERBIT_AGUNAN.SelectedValue = conn2.GetFieldValue("COL_SB_ISSUER");}
			catch{DDL_PENERBIT_AGUNAN.SelectedValue = "";}
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn2.QueryString = "exec DC_INTERIM_INSERT '" +
				TXT_CIF.Text + "', '" +
				TXT_NAME.Text + "', '" +
				DDL_JNS_NASABAH.SelectedValue + "', '" +
				DDL_TUJUAN_HUB_BANK.SelectedValue + "', '" +
				DDL_JNS_VALUTA.SelectedValue + "', " +
				tool.ConvertDate(TXT_TGL_MULAI.Text, DDL_BLN_MULAI.SelectedValue, TXT_THN_MULAI.Text) + ", " +
				tool.ConvertDate(TXT_TGL_JATUH_TEMPO.Text, DDL_BLN_JATUH_TEMPO.SelectedValue, TXT_THN_JATUH_TEMPO.Text) + ", '" +
				DDL_GOL_PEMOHON.SelectedValue + "', '" +
				DDL_HUB_BANK.SelectedValue + "', '" +
				DDL_STATUS_PEMOHON.SelectedValue + "', '" +
				DDL_NEGARA_PEMOHON.SelectedValue + "', '" +
				DDL_LEMBAGA_PEMERINGKAT.SelectedValue + "', '" +
				DDL_PERINGKAT_PERUSAHAAN.SelectedValue + "', " +
				tool.ConvertDate(TXT_TGL_PEMERINGKAT.Text, DDL_BLN_PEMERINGKAT.SelectedValue, TXT_THN_PEMERINGKAT.Text) + ", " +
				tool.ConvertFloat(TXT_JUMLAH.Text) + ", '" +
				DDL_JENIS_AGUNAN.SelectedValue + "', '" +
				DDL_SIFAT_AGUNAN.SelectedValue + "', '" +
				DDL_JENIS_VALUTA_AGUNAN.SelectedValue + "', " +
				tool.ConvertDate(TXT_TGL_MULAI2.Text, DDL_BLN_MULAI2.SelectedValue, TXT_THN_MULAI2.Text) + ", " +
				tool.ConvertDate(TXT_TGL_JANGKA_WAKTU2.Text, DDL_BLN_JANGKA_WAKTU2.SelectedValue, TXT_THN_JANGKA_WAKTU2.Text) + ", " +
				tool.ConvertFloat(TXT_NILAI_AGUNAN.Text) + ", " +
				tool.ConvertDate(TXT_TGL_PENILAIAN.Text, DDL_BLN_PENILAIAN.SelectedValue, TXT_THN_PENILAIAN.Text) + ", '" +
				DDL_PENERBIT_AGUNAN.SelectedValue + "', " + 
				tool.ConvertFloat(TXT_PARIPASU.Text) + ", '0', '" +
				Session["UserID"].ToString() + "', '" +
				Session["FullName"].ToString() + "', 'LC'";
			conn2.ExecuteQuery();

			BTN_UPDATE.Visible = true;
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			DDL_TUJUAN_HUB_BANK.SelectedValue = "";
			DDL_JNS_VALUTA.SelectedValue = "";
			TXT_TGL_MULAI.Text = "";
			DDL_BLN_MULAI.SelectedValue = "";
			TXT_THN_MULAI.Text = "";
			DDL_HUB_BANK.SelectedValue = "";
			DDL_STATUS_PEMOHON.SelectedValue = "";
			DDL_NEGARA_PEMOHON.SelectedValue = "";
			DDL_LEMBAGA_PEMERINGKAT.SelectedValue = "";
			DDL_PERINGKAT_PERUSAHAAN.SelectedValue = "";
			TXT_TGL_PEMERINGKAT.Text = "";
			DDL_BLN_PEMERINGKAT.SelectedValue = "";
			TXT_THN_PEMERINGKAT.Text = "";
			DDL_JENIS_VALUTA_AGUNAN.SelectedValue = "";
			TXT_TGL_MULAI2.Text = "";
			DDL_BLN_MULAI2.SelectedValue = "";
			TXT_THN_MULAI2.Text = "";
			TXT_TGL_JATUH_TEMPO.Text = "";
			DDL_BLN_JATUH_TEMPO.SelectedValue = "";
			TXT_THN_JATUH_TEMPO.Text = "";
			DDL_PENERBIT_AGUNAN.SelectedValue = "";
			TXT_PARIPASU.Text = "";
			DDL_JNS_NASABAH.SelectedValue = "";
			TXT_TGL_JANGKA_WAKTU2.Text = "";
			DDL_BLN_JANGKA_WAKTU2.SelectedValue = "";
			TXT_THN_JANGKA_WAKTU2.Text = "";
			DDL_GOL_PEMOHON.SelectedValue = "";
			TXT_JUMLAH.Text = "";
			DDL_JENIS_AGUNAN.SelectedValue = "";
			DDL_SIFAT_AGUNAN.SelectedValue = "";
			TXT_NILAI_AGUNAN.Text = "";
			TXT_TGL_PENILAIAN.Text = "";
			DDL_BLN_PENILAIAN.SelectedValue = "";
			TXT_THN_PENILAIAN.Text = "";
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			conn2.QueryString = "exec DC_INTERIM_INSERT '" + TXT_CIF.Text + "', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '1', '" +
				Session["UserID"].ToString() + "', '" +
				Session["FullName"].ToString() + "',''";
			conn2.ExecuteQuery();

			string msg = "Data Masuk ke List Pending Approval";

			Response.Redirect("TradeDataCompleteList.aspx?msg=" + msg);

			//GlobalTools.popMessage(this, "Data Masuk ke List Pending Approval");
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("TradeDataCompleteList.aspx");
		}
	}
}
