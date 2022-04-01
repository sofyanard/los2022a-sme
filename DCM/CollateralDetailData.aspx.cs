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
using Microsoft.VisualBasic;
using System.Configuration;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.DCM
{
	/// <summary>
	/// Summary description for CollateralDetailData.
	/// </summary>
	public partial class CollateralDetailData : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				FillDDL();
				ViewData();
			}

			SecureData();
			BTN_UPDATE.Attributes.Add("onclick","if(!update()){return false;};");
		}

		private void FillDDL()
		{
			/* Sifat Agunan */
			GlobalTools.fillRefList(DDL_SIFAT_AGUNAN, "SELECT * FROM VW_DCM_COLLATERAL_CORRECTION_DDLSIFATAGUNAN", conn2);

			/* Bukti Kepemilikan */
			GlobalTools.fillRefList(DDL_BUKTI_KEPEMILIKAN, "SELECT * FROM VW_DCM_COLLATERAL_CORRECTION_DDLBUKTIKEPEMILIKAN", conn2);

			/* Status Kepemilikan */
			GlobalTools.fillRefList(DDL_STATUS_KEPEMILIKAN, "SELECT * FROM VW_DCM_COLLATERAL_CORRECTION_DDLSTATUSKEPEMILIKAN", conn2);

			/* Lokasi Dati II */
			GlobalTools.fillRefList(DDL_LOKASI_DATI2, "SELECT * FROM VW_DCM_COLLATERAL_CORRECTION_DDLLOKASIDATI2", conn2);

			/* Currency */
			GlobalTools.fillRefList(DDL_CURRENCY, "SELECT * FROM VW_DCM_COLLATERAL_CORRECTION_DDLCURENCY", conn2);

			/* Penilaian Oleh */
			GlobalTools.fillRefList(DDL_PENILAIAN_OLEH, "SELECT * FROM VW_DCM_COLLATERAL_CORRECTION_DDLPENILAIANOLEH", conn2);

			/* Jenis Pengikatan */
			GlobalTools.fillRefList(DDL_JENIS_PENGIKATAN, "SELECT * FROM VW_DCM_COLLATERAL_CORRECTION_DDLJENISPENGIKATAN", conn2);

			/* Asuransi */
			GlobalTools.fillRefList(DDL_ASURANSI, "SELECT * FROM VW_DCM_COLLATERAL_CORRECTION_DDLASURANSI", conn2);

			DDL_TGL_TERBIT_SERTIFIKAT_MM.Items.Add(new ListItem("- PILIH -", ""));
			DDL_TGL_EXPIRED_SERTIFIKAT_MM.Items.Add(new ListItem("- PILIH -", ""));
			DDL_TGL_PENILAIAN_PERTAMA_MM.Items.Add(new ListItem("- PILIH -", ""));
			DDL_TGL_PENILAIAN_TERAKHIR_MM.Items.Add(new ListItem("- PILIH -", ""));
			DDL_TGL_PENGIKATAN_MM.Items.Add(new ListItem("- PILIH -", ""));
			DDL_TGL_PERINGKAT_MM.Items.Add(new ListItem("- PILIH -", ""));
			DDL_TGL_PENERBITAN_SURAT_MM.Items.Add(new ListItem("- PILIH -", ""));
			DDL_TGL_EXPIRED_SURAT_MM.Items.Add(new ListItem("- PILIH -", ""));

			for (int i = 1; i <= 12; i++)
			{
				DDL_TGL_TERBIT_SERTIFIKAT_MM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_TGL_EXPIRED_SERTIFIKAT_MM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_TGL_PENILAIAN_PERTAMA_MM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_TGL_PENILAIAN_TERAKHIR_MM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_TGL_PENGIKATAN_MM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_TGL_PERINGKAT_MM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_TGL_PENERBITAN_SURAT_MM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_TGL_EXPIRED_SURAT_MM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}
		}

		private void ViewData()
		{
			conn2.QueryString = "SELECT * FROM VW_DCM_COLLATERAL_CORRECTION_VIEWCOLLDETAIL WHERE COLL_ID = '" + Request.QueryString["colid"].Trim() + "'";
			conn2.ExecuteQuery();

			if (conn2.GetRowCount() > 0)
			{
				TXT_ID_AGUNAN.Text = conn2.GetFieldValue("COLL_ID");
				TXT_JENIS_AGUNAN.Text = conn2.GetFieldValue("COLL_TYPE");
				TXT_KETERANGAN_AGUNAN.Text = conn2.GetFieldValue("COLL_DESC");
				TXT_ERRORMSG.Text = conn2.GetFieldValue("ERROR_MSG");
				try {DDL_SIFAT_AGUNAN.SelectedValue = conn2.GetFieldValue("SIFAT_AGUNAN");}
				catch {}
				TXT_NAMA_PEMILIK.Text = conn2.GetFieldValue("NAMA_PEMILIK");
				try {DDL_BUKTI_KEPEMILIKAN.SelectedValue = conn2.GetFieldValue("BUKTI_KEPEMILIKAN");}
				catch {}
				try {DDL_STATUS_KEPEMILIKAN.SelectedValue = conn2.GetFieldValue("STATUS_KEPEMILIKAN");}
				catch {}
				TXT_TGL_TERBIT_SERTIFIKAT_DD.Text = tool.FormatDate_Day(conn2.GetFieldValue("TANGGAL_TERBIT_SERTIFIKAT"));
				try {DDL_TGL_TERBIT_SERTIFIKAT_MM.SelectedValue	= tool.FormatDate_Month(conn2.GetFieldValue("TANGGAL_TERBIT_SERTIFIKAT"));}
				catch {}
				TXT_TGL_TERBIT_SERTIFIKAT_YY.Text = tool.FormatDate_Year(conn2.GetFieldValue("TANGGAL_TERBIT_SERTIFIKAT"));
				TXT_TGL_EXPIRED_SERTIFIKAT_DD.Text = tool.FormatDate_Day(conn2.GetFieldValue("TANGGAL_EXPIRED_SERTIFIKAT"));
				try {DDL_TGL_EXPIRED_SERTIFIKAT_MM.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("TANGGAL_EXPIRED_SERTIFIKAT"));}
				catch {}
				TXT_TGL_EXPIRED_SERTIFIKAT_YY.Text = tool.FormatDate_Year(conn2.GetFieldValue("TANGGAL_EXPIRED_SERTIFIKAT"));
				TXT_ALAMAT_AGUNAN.Text = conn2.GetFieldValue("ALAMAT_AGUNAN");
				try {DDL_LOKASI_DATI2.SelectedValue = conn2.GetFieldValue("LOKASI_DATI2");}
				catch {}
				try {DDL_CURRENCY.SelectedValue = conn2.GetFieldValue("CURRENCY");}
				catch {}
				TXT_NILAI_PASAR.Text = tool.MoneyFormat(conn2.GetFieldValue("NILAI_PASAR"));
				TXT_NILAI_APPRAISAL.Text = tool.MoneyFormat(conn2.GetFieldValue("NILAI_APPRAISAL"));
				TXT_NILAI_LIKUIDASI.Text = tool.MoneyFormat(conn2.GetFieldValue("NILAI_LIKUIDASI"));
				TXT_NILAI_NJOP.Text = tool.MoneyFormat(conn2.GetFieldValue("NILAI_NJOP"));
				TXT_NILAI_PENGIKATAN.Text = tool.MoneyFormat(conn2.GetFieldValue("NILAI_PENGIKATAN"));
				TXT_TGL_PENILAIAN_PERTAMA_DD.Text = tool.FormatDate_Day(conn2.GetFieldValue("TANGGAL_PENILAIAN_PERTAMA"));
				try {DDL_TGL_PENILAIAN_PERTAMA_MM.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("TANGGAL_PENILAIAN_PERTAMA"));}
				catch {}
				TXT_TGL_PENILAIAN_PERTAMA_YY.Text = tool.FormatDate_Year(conn2.GetFieldValue("TANGGAL_PENILAIAN_PERTAMA"));
				TXT_TGL_PENILAIAN_TERAKHIR_DD.Text = tool.FormatDate_Day(conn2.GetFieldValue("TANGGAL_PENILAIAN_TERAKHIR"));
				try {DDL_TGL_PENILAIAN_TERAKHIR_MM.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("TANGGAL_PENILAIAN_TERAKHIR"));}
				catch {}
				TXT_TGL_PENILAIAN_TERAKHIR_YY.Text = tool.FormatDate_Year(conn2.GetFieldValue("TANGGAL_PENILAIAN_TERAKHIR"));
				try {DDL_PENILAIAN_OLEH.SelectedValue = conn2.GetFieldValue("PENILAIAN_OLEH");}
				catch {}
				try {DDL_JENIS_PENGIKATAN.SelectedValue = conn2.GetFieldValue("JENIS_PENGIKATAN");}
				catch {}
				TXT_TGL_PENGIKATAN_DD.Text = tool.FormatDate_Day(conn2.GetFieldValue("TANGGAL_PENGIKATAN"));
				try {DDL_TGL_PENGIKATAN_MM.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("TANGGAL_PENGIKATAN"));}
				catch {}
				TXT_TGL_PENGIKATAN_YY.Text = tool.FormatDate_Year(conn2.GetFieldValue("TANGGAL_PENGIKATAN"));
				try {DDL_ASURANSI.SelectedValue = conn2.GetFieldValue("ASURANSI");}
				catch {}
				TXT_PERINGKAT_SURAT.Text = conn2.GetFieldValue("PERINGKAT_SURAT_BERHARGA");
				TXT_TGL_PERINGKAT_DD.Text = tool.FormatDate_Day(conn2.GetFieldValue("TANGGAL_TERBIT_PERINGKAT"));
				try {DDL_TGL_PERINGKAT_MM.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("TANGGAL_TERBIT_PERINGKAT"));}
				catch {}
				TXT_TGL_PERINGKAT_YY.Text = tool.FormatDate_Year(conn2.GetFieldValue("TANGGAL_TERBIT_PERINGKAT"));
				TXT_PENERBIT_SURAT.Text = conn2.GetFieldValue("PENERBIT_SURAT_BERHARGA");
				TXT_TGL_PENERBITAN_SURAT_DD.Text = tool.FormatDate_Day(conn2.GetFieldValue("TANGGAL_TERBIT_SURAT"));
				try {DDL_TGL_PENERBITAN_SURAT_MM.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("TANGGAL_TERBIT_SURAT"));}
				catch {}
				TXT_TGL_PENERBITAN_SURAT_YY.Text = tool.FormatDate_Year(conn2.GetFieldValue("TANGGAL_TERBIT_SURAT"));
				TXT_TGL_EXPIRED_SURAT_DD.Text = tool.FormatDate_Day(conn2.GetFieldValue("TANGGAL_EXPIRED_SURAT"));
				try {DDL_TGL_EXPIRED_SURAT_MM.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("TANGGAL_EXPIRED_SURAT"));}
				catch {}
				TXT_TGL_EXPIRED_SURAT_YY.Text = tool.FormatDate_Year(conn2.GetFieldValue("TANGGAL_EXPIRED_SURAT"));

				if (conn2.GetFieldValue("ALLOW_SAVE") == "1")
					BTN_SAVE.Enabled = true;
				else
					BTN_SAVE.Enabled = false;

				if (conn2.GetFieldValue("ALLOW_UPDATE") == "1")
					BTN_UPDATE.Enabled = true;
				else
					BTN_UPDATE.Enabled = false;
			}
		}

		private void SecureData() 
		{
			if ((Request.QueryString["asgn"] == null) || (Request.QueryString["asgn"] != "2"))
			{
				DDL_SIFAT_AGUNAN.Enabled = false;
				TXT_NAMA_PEMILIK.ReadOnly = true;
				DDL_BUKTI_KEPEMILIKAN.Enabled = false;
				DDL_STATUS_KEPEMILIKAN.Enabled = false;
				TXT_TGL_TERBIT_SERTIFIKAT_DD.ReadOnly = true;
				DDL_TGL_TERBIT_SERTIFIKAT_MM.Enabled = false;
				TXT_TGL_TERBIT_SERTIFIKAT_YY.ReadOnly = true;
				TXT_TGL_EXPIRED_SERTIFIKAT_DD.ReadOnly = true;
				DDL_TGL_EXPIRED_SERTIFIKAT_MM.Enabled = false;
				TXT_TGL_EXPIRED_SERTIFIKAT_YY.ReadOnly = true;
				TXT_ALAMAT_AGUNAN.ReadOnly = true;
				DDL_LOKASI_DATI2.Enabled = false;
				DDL_CURRENCY.Enabled = false;
				TXT_NILAI_PASAR.ReadOnly = true;
				TXT_NILAI_APPRAISAL.ReadOnly = true;
				TXT_NILAI_LIKUIDASI.ReadOnly = true;
				TXT_NILAI_NJOP.ReadOnly = true;
				TXT_NILAI_PENGIKATAN.ReadOnly = true;
				TXT_TGL_PENILAIAN_PERTAMA_DD.ReadOnly = true;
				DDL_TGL_PENILAIAN_PERTAMA_MM.Enabled = false;
				TXT_TGL_PENILAIAN_PERTAMA_YY.ReadOnly = true;
				TXT_TGL_PENILAIAN_TERAKHIR_DD.ReadOnly = true;
				DDL_TGL_PENILAIAN_TERAKHIR_MM.Enabled = false;
				TXT_TGL_PENILAIAN_TERAKHIR_YY.ReadOnly = true;
				DDL_PENILAIAN_OLEH.Enabled = false;
				DDL_JENIS_PENGIKATAN.Enabled = false;
				TXT_TGL_PENGIKATAN_DD.ReadOnly = false;
				DDL_TGL_PENGIKATAN_MM.Enabled = false;
				TXT_TGL_PENGIKATAN_YY.ReadOnly = true;
				DDL_ASURANSI.Enabled = false;
				TXT_PERINGKAT_SURAT.ReadOnly = true;
				TXT_TGL_PERINGKAT_DD.ReadOnly = true;
				DDL_TGL_PERINGKAT_MM.Enabled = false;
				TXT_TGL_PERINGKAT_YY.ReadOnly = true;
				TXT_PENERBIT_SURAT.ReadOnly = true;
				TXT_TGL_PENERBITAN_SURAT_DD.ReadOnly = true;
				DDL_TGL_PENERBITAN_SURAT_MM.Enabled = false;
				TXT_TGL_PENERBITAN_SURAT_YY.ReadOnly = true;
				TXT_TGL_EXPIRED_SURAT_DD.ReadOnly = true;
				DDL_TGL_EXPIRED_SURAT_MM.Enabled = false;
				TXT_TGL_EXPIRED_SURAT_YY.ReadOnly = true;

				BTN_SAVE.Visible = false;
				BTN_UPDATE.Visible = false;
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
			try
			{
				conn2.QueryString  = "EXEC DCM_COLLATERAL_CORRECTION_SAVE '" + 
					Request.QueryString["colid"].Trim() + "', '" +
					TXT_JENIS_AGUNAN.Text + "', '" +
					TXT_KETERANGAN_AGUNAN.Text + "', '" +
					DDL_SIFAT_AGUNAN.SelectedValue + "', '" +
					TXT_NAMA_PEMILIK.Text + "', '" +
					DDL_BUKTI_KEPEMILIKAN.SelectedValue + "', '" +
					DDL_STATUS_KEPEMILIKAN.SelectedValue + "', " +
					tool.ConvertDate(TXT_TGL_TERBIT_SERTIFIKAT_DD.Text, DDL_TGL_TERBIT_SERTIFIKAT_MM.SelectedValue, TXT_TGL_TERBIT_SERTIFIKAT_YY.Text) + ", " +
					tool.ConvertDate(TXT_TGL_EXPIRED_SERTIFIKAT_DD.Text, DDL_TGL_EXPIRED_SERTIFIKAT_MM.SelectedValue, TXT_TGL_EXPIRED_SERTIFIKAT_YY.Text) + ", '" +
					TXT_ALAMAT_AGUNAN.Text + "', '" +
					DDL_LOKASI_DATI2.SelectedValue + "', '" +
					DDL_CURRENCY.SelectedValue + "', " +
					tool.ConvertFloat(TXT_NILAI_PASAR.Text) + ", " +
					tool.ConvertFloat(TXT_NILAI_APPRAISAL.Text) + ", " +
					tool.ConvertFloat(TXT_NILAI_LIKUIDASI.Text) + ", " +
					tool.ConvertFloat(TXT_NILAI_NJOP.Text) + ", " +
					tool.ConvertFloat(TXT_NILAI_PENGIKATAN.Text) + ", " +
					tool.ConvertDate(TXT_TGL_PENILAIAN_PERTAMA_DD.Text, DDL_TGL_PENILAIAN_PERTAMA_MM.SelectedValue, TXT_TGL_PENILAIAN_PERTAMA_YY.Text) + ", " +
					tool.ConvertDate(TXT_TGL_PENILAIAN_TERAKHIR_DD.Text, DDL_TGL_PENILAIAN_TERAKHIR_MM.SelectedValue, TXT_TGL_PENILAIAN_TERAKHIR_YY.Text) + ", '" +
					DDL_PENILAIAN_OLEH.SelectedValue + "', '" +
					DDL_JENIS_PENGIKATAN.SelectedValue + "', " +
					tool.ConvertDate(TXT_TGL_PENGIKATAN_DD.Text, DDL_TGL_PENGIKATAN_MM.SelectedValue, TXT_TGL_PENGIKATAN_YY.Text) + ", '" +
					DDL_ASURANSI.SelectedValue + "', '" +
					TXT_PERINGKAT_SURAT.Text + "', " +
					tool.ConvertDate(TXT_TGL_PERINGKAT_DD.Text, DDL_TGL_PERINGKAT_MM.SelectedValue, TXT_TGL_PERINGKAT_YY.Text) + ", '" +
					TXT_PENERBIT_SURAT.Text + "', " +
					tool.ConvertDate(TXT_TGL_PENERBITAN_SURAT_DD.Text, DDL_TGL_PENERBITAN_SURAT_MM.SelectedValue, TXT_TGL_PENERBITAN_SURAT_YY.Text) + ", " +
					tool.ConvertDate(TXT_TGL_EXPIRED_SURAT_DD.Text, DDL_TGL_EXPIRED_SURAT_MM.SelectedValue, TXT_TGL_EXPIRED_SURAT_YY.Text) + ", '" +
					Session["UserID"].ToString() + "'";
				conn2.ExecuteNonQuery();

				ViewData();
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn2.QueryString  = "EXEC DCM_COLLATERAL_CORRECTION_UPDATE '" + 
					Request.QueryString["colid"].Trim() + "', '" +
					Session["UserID"].ToString() + "'";
				conn2.ExecuteNonQuery();

				ViewData();
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}
	}
}
