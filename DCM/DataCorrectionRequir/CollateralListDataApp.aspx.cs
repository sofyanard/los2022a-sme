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


namespace SME.DCM.DataCorrectionRequir
{
	/// <summary>
	/// Summary description for CollateralListDataApp.
	/// </summary>
	public partial class CollateralListDataApp : System.Web.UI.Page
	{
		protected Connection conn;
		protected Connection2 conn2;

		/* Deklarasi Variable */
		private string VAR_CollateralType;
		private string VAR_CollateralID;
		private string VAR_KeteranganJaminan;
		private string VAR_SifatAgunan;
		private string VAR_JenisValuta;
		private string VAR_JenisAgunan;
		private string VAR_NamaPemillikAgunan;
		private string VAR_AlamatBankPenyimpanAgunan;
		private string VAR_LokasiDatiII;
		private string VAR_StatusBuktiKepemilikan;		
		private string VAR_NilaiAgunan;
		private string VAR_NilaiLikuidasi;
		private string VAR_NilaiAppraisal;		
		private string VAR_NamaPenilaiIndependen;
		private string VAR_TanggalPenilaianDay;
		private string VAR_TanggalPenilaianMonth;
		private string VAR_TanggalPenilaianYear;
		private string VAR_TanggalPenilaianTerakhirDay;
		private string VAR_TanggalPenilaianTerakhirMonth;
		private string VAR_TanggalPenilaianTerakhirYear;
		private string VAR_NilaiPengikatan;
		private string VAR_TanggalPengikatanDay;
		private string VAR_TanggalPengikatanMonth;
		private string VAR_TanggalPengikatanYear;
		private string VAR_JenisPengikatan;
		private string VAR_NomorPengikatan;
		private string VAR_Paripasu;		
		private string VAR_Asuransi;
	
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			conn2 = new Connection2(ConfigurationSettings.AppSettings["conn2"]);

			if(!IsPostBack)
			{
				DDL_SIFAT_AGUNAN.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_JNS_VALUTA.Items.Add(new ListItem("Pilih--", ""));
				DDL_JNS_AGUNAN.Items.Add(new ListItem("--Pilih--", ""));
				DDL_DATI.Items.Add(new ListItem("--Pilih--",""));				
				DDL_STATUS.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN_PENILAIAN.Items.Add(new ListItem("--Pilih--", ""));
				DDL_BLN_LAST.Items.Add(new ListItem("--Pilih--", ""));
				DDL_BLN_PENGIKAT.Items.Add(new ListItem("--Pilih--", ""));
				DDL_JNS_PENGIKAT.Items.Add(new ListItem ("--Pilih--", ""));

				for (int i=1; i<=12; i++)
				{
					DDL_BLN_PENILAIAN.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_LAST.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_PENGIKAT.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));						
				}

				conn2.QueryString = "select * from VW_DCM_COLLATERAL_DDL_SIFAT_AGUNAN";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_SIFAT_AGUNAN.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_VALUTA";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JNS_VALUTA.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_COLLATERAL_DDL_JENIS_AGUNAN";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JNS_AGUNAN.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));
				
				conn2.QueryString = "select * from VW_DCM_CIF_DDL_LOKASIDATI order by convert(int, locationid)";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_DATI.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_COLLATERAL_DDL_STATUS_KEPEMILIKAN";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_STATUS.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_COLLATERAL_DDL_JENIS_PENGIKATAN";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JNS_PENGIKAT.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

			}
		}

		
		private void VAR_to_CONTROL()
		{
			TXT_COL_TYPE.Text = VAR_CollateralType;
			TXT_COL_ID.Text = VAR_CollateralID;
			TXT_KET_JAMINAN.Text = VAR_KeteranganJaminan;
			DDL_SIFAT_AGUNAN.SelectedValue = VAR_SifatAgunan;
			DDL_JNS_VALUTA.SelectedValue = VAR_JenisValuta;
			DDL_JNS_AGUNAN.SelectedValue = VAR_JenisAgunan;
			TXT_NM_PEMILIK.Text = VAR_NamaPemillikAgunan;
			TXT_ADD_BANK.Text = VAR_AlamatBankPenyimpanAgunan;
			DDL_DATI.SelectedValue = VAR_LokasiDatiII;
			DDL_STATUS.SelectedValue = VAR_StatusBuktiKepemilikan;		
			TXT_NILAI_AGUNAN.Text = VAR_NilaiAgunan;
			TXT_NILAI_LIQUID.Text = VAR_NilaiLikuidasi;
			TXT_NILAI_APPR.Text = VAR_NilaiAppraisal;		
			TXT_NAMA_PENILAI.Text = VAR_NamaPenilaiIndependen;
			TXT_TGL_PENILAIAN.Text = VAR_TanggalPenilaianDay;
			DDL_BLN_PENILAIAN.SelectedValue = VAR_TanggalPenilaianMonth;
			TXT_THN_PENILAIAN.Text = VAR_TanggalPenilaianYear;
			TXT_TGL_LAST.Text = VAR_TanggalPenilaianTerakhirDay;
			DDL_BLN_LAST.SelectedValue = VAR_TanggalPenilaianTerakhirMonth;
			TXT_THN_LAST.Text = VAR_TanggalPenilaianTerakhirYear;
			TXT_NILAI_PENGIKATAN.Text = VAR_NilaiPengikatan;
			TXT_TGL_PENGIKAT.Text = VAR_TanggalPengikatanDay;
			DDL_BLN_PENGIKAT.SelectedValue = VAR_TanggalPengikatanMonth;
			TXT_THN_PENGIKAT.Text = VAR_TanggalPengikatanYear;
			DDL_JNS_PENGIKAT.SelectedValue = VAR_JenisPengikatan;
			TXT_NO_PENGIKAT.Text = VAR_NomorPengikatan;
			TXT_PARIPASU.Text = VAR_Paripasu;		
			RDO_ASURANSI.SelectedValue = VAR_Asuransi;
		}

		private void CONTROL_to_VAR()
		{
			VAR_CollateralType = TXT_COL_TYPE.Text;
			VAR_CollateralID = TXT_COL_ID.Text;
			VAR_KeteranganJaminan = TXT_KET_JAMINAN.Text;
			VAR_SifatAgunan = DDL_SIFAT_AGUNAN.SelectedValue;
			VAR_JenisValuta = DDL_JNS_VALUTA.SelectedValue;
			VAR_JenisAgunan = DDL_JNS_AGUNAN.SelectedValue;
			VAR_NamaPemillikAgunan = TXT_NM_PEMILIK.Text;
			VAR_AlamatBankPenyimpanAgunan = TXT_ADD_BANK.Text;
			VAR_LokasiDatiII = DDL_DATI.SelectedValue;
			VAR_StatusBuktiKepemilikan = DDL_STATUS.SelectedValue;		
			VAR_NilaiAgunan = TXT_NILAI_AGUNAN.Text;
			VAR_NilaiLikuidasi = TXT_NILAI_LIQUID.Text;
			VAR_NilaiAppraisal = TXT_NILAI_APPR.Text;		
			VAR_NamaPenilaiIndependen = TXT_NAMA_PENILAI.Text;
			VAR_TanggalPenilaianDay = TXT_TGL_PENILAIAN.Text;
			VAR_TanggalPenilaianMonth = DDL_BLN_PENILAIAN.SelectedValue;
			VAR_TanggalPenilaianYear = TXT_THN_PENILAIAN.Text;
			VAR_TanggalPenilaianTerakhirDay = TXT_TGL_LAST.Text;
			VAR_TanggalPenilaianTerakhirMonth = DDL_BLN_LAST.SelectedValue;
			VAR_TanggalPenilaianTerakhirYear = TXT_THN_LAST.Text;
			VAR_NilaiPengikatan = TXT_NILAI_PENGIKATAN.Text;
			VAR_TanggalPengikatanDay = TXT_TGL_PENGIKAT.Text;
			VAR_TanggalPengikatanMonth = DDL_BLN_PENGIKAT.SelectedValue;
			VAR_TanggalPengikatanYear = TXT_THN_PENGIKAT.Text;
			VAR_JenisPengikatan = DDL_JNS_PENGIKAT.SelectedValue;
			VAR_NomorPengikatan = TXT_NO_PENGIKAT.Text;
			VAR_Paripasu = TXT_PARIPASU.Text;		
			VAR_Asuransi = RDO_ASURANSI.SelectedValue;
		}
		
		private void ClearData()
		{
			DDL_SIFAT_AGUNAN.SelectedValue = "";
			DDL_JNS_VALUTA.SelectedValue = "";
			DDL_JNS_AGUNAN.SelectedValue = "";
			TXT_NM_PEMILIK.Text = "";
			TXT_ADD_BANK.Text = "";
			DDL_DATI.SelectedValue = "";
			DDL_STATUS.SelectedValue = "";
			TXT_NILAI_AGUNAN.Text = "";
			TXT_NILAI_LIQUID.Text = "";
			TXT_NILAI_APPR.Text = "";
			TXT_NAMA_PENILAI.Text = "";
			TXT_TGL_PENILAIAN.Text = "";
			DDL_BLN_PENILAIAN.SelectedValue = "";
			TXT_THN_PENILAIAN.Text = "";
			TXT_TGL_LAST.Text = "";
			DDL_BLN_LAST.SelectedValue = "";
			TXT_THN_LAST.Text = "";
			TXT_NILAI_PENGIKATAN.Text = "";
			TXT_TGL_PENGIKAT.Text = "";
			DDL_BLN_PENGIKAT.SelectedValue = "";
			TXT_THN_PENGIKAT.Text = "";
			DDL_JNS_PENGIKAT.SelectedValue = "";
			TXT_NO_PENGIKAT.Text = "";
			TXT_PARIPASU.Text = "";
			RDO_ASURANSI.SelectedValue = null;
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

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}
	}
}
