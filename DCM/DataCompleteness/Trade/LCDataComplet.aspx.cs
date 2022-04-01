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

namespace SME.DCM.DataCompleteness.Trade
{
	/// <summary>
	/// Summary description for LCDataComplet.
	/// </summary>
	public partial class LCDataComplet : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TXT_JUMLAH;
		protected Tools tool = new Tools();
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn3 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		private string VAR_CIF;
		private string VAR_CustomerName;
		private string VAR_JenisNasabah;
		private string VAR_NoLC;
		private string VAR_JenisLC;
		private string VAR_JenisValuta;
		private string VAR_MulaiTanggal;
		private string VAR_MulaiBulan;
		private string VAR_MulaiTahun;
		private string VAR_JatuhTempoTanggal;
		private string VAR_JatuhTempoBulan;
		private string VAR_JatuhTempoTahun;
		private string VAR_GolonganPemohon;
		private string VAR_HubunganDenganBank;
		private string VAR_StatusPemohon;
		private string VAR_NegaraPihakPemohon;
		private string VAR_LembagaPemeringkat;
		private string VAR_PeringkatPerusahaan;
		private string VAR_TanggalPemeringkatanDay;
		private string VAR_TanggalPemeringkatanMonth;
		private string VAR_TanggalPemeringkatanYear;
		private string VAR_BankBeneficiary;
		private string VAR_CaraPembayaranLC;
		private string VAR_NominalLC;
		private string VAR_Plafon;
		private string VAR_PlafonInduk;
		private string VAR_JenisAgunanJaminan;
		private string VAR_SifatAgunanJaminan;
		private string VAR_JenisValutaAgunan;
		private string VAR_JangkaWaktuMulaiDay;
		private string VAR_JangkaWaktuMulaiMonth;
		private string VAR_JangkaWaktuMulaiYear;
		private string VAR_JangkaWaktuJatuhTempoDay;
		private string VAR_JangkaWaktuJatuhTempoMonth;
		private string VAR_JangkaWaktuJatuhTempoYear;
		private string VAR_NilaiAgunan;
		private string VAR_TanggalPenilaianTerakhirDay;
		private string VAR_TanggalPenilaianTerakhirMonth;
		private string VAR_TanggalPenilaianTerakhirYear;
		private string VAR_PenerbitAgunan;
		private string VAR_Paripasu;
		private string VAR_PPAPYangDibentuk;
		private string VAR_SetoranJaminan;
		private string VAR_NomorAkadAwal;
		private string VAR_TanggalAkadAwalDay;
		private string VAR_TanggalAkadAwalMonth;
		private string VAR_TanggalAkadAwalYear;
		private string VAR_NomorAkadAkhir;
		private string VAR_TanggalAkadAkhirDay;
		private string VAR_TanggalAkadAkhirMonth;
		private string VAR_TanggalAkadAkhirYear;
		private string VAR_Kolektibilitas;
		private string VAR_TglMacetDay;
		private string VAR_TglMacetMonth;
		private string VAR_TglMacetYear;
		private string VAR_SebabMacet;
		private string VAR_KeteranganMacet;
		private string VAR_TglWanPrestasiDay;
		private string VAR_TglWanPrestasiMonth;
		private string VAR_TglWanPrestasiYear;
		private string VAR_Kondisi;
		private string VAR_TglKondisiDay;
		private string VAR_TglKondisiMonth;
		private string VAR_TglKondisiYear;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			AllDropDownListInitiation();
			RetrieveSOA();
			VAR_to_CONTROL();
			CheckingError(this, Color.Red);
		}

		private void CheckError()
		{
			string id = "";

			conn2.QueryString = "EXEC DCM_DATA_ERROR_CHECKING '" + Request.QueryString["acctno"] + "','4'";
			conn2.ExecuteQuery();

			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				string err_msg = conn2.GetFieldValue(i, "ERR_MSG").ToString().Replace(";","");

				conn3.QueryString = "SELECT IDCONTROL FROM DCM_TABLE_ERROR WHERE PAGE = 'LCDataComplet.aspx' AND MESSAGE = '" + err_msg.Trim() + "'";
				conn3.ExecuteQuery();

				if (conn3.GetFieldValue("IDCONTROL") != "")
				{
					id = "LBL_" + conn3.GetFieldValue("IDCONTROL");
					((Label)this.Page.FindControl(id)).ForeColor = Color.Red;
				}
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

		private void CheckingError(Control Page, Color clr)
		{
			/*ini ngeceknya klo kosong doang*/
			string id = "";

			foreach (Control ctrl in Page.Controls)
			{
				if (ctrl is Label)
				{
					id = ctrl.ID;
					id = id.Replace("LBL_","");
					Control ctrlfix = (Control)this.FindControl(id);
						
					if(ctrlfix is DropDownList)
					{
						DropDownList ddl = (DropDownList)this.FindControl(id);
						if(ddl.SelectedValue.ToString().Trim() == "")
						{
							((Label)(ctrl)).ForeColor = clr;
							((Label)(ctrl)).ToolTip = "Harus Diisi !";
						}
					}
					else if(ctrlfix is TextBox)
					{
						TextBox txt = (TextBox)this.FindControl(id);
						if(txt != null)
						{
							if(txt.Text.ToString().Trim() == "")
							{
								((Label)(ctrl)).ForeColor = clr;
								((Label)(ctrl)).ToolTip = "Tidak sesuai dengan data eMas !";
							}
						}
					}
					else if(ctrlfix is RadioButtonList)
					{
						RadioButtonList rdo = (RadioButtonList)this.FindControl(id);
						if(rdo != null)
						{
							if(rdo.SelectedValue.ToString().Trim() == "")
							{
								((Label)(ctrl)).ForeColor = clr;
								((Label)(ctrl)).ToolTip = "Tidak boleh kosong ";
							}
						}
					}
					else
					{
						continue;
					}
				}
				else
				{
					if (ctrl.Controls.Count > 0)
					{
						CheckingError(ctrl, clr);
					}
				}
			}
		}


		private void RetrieveSOA()
		{
			VAR_CIF = "";
			VAR_CustomerName = "";
			VAR_JenisNasabah = "";
			VAR_NoLC = "";
			VAR_JenisLC = "";
			VAR_JenisValuta = "";
			VAR_MulaiTanggal = "";
			VAR_MulaiBulan = "";
			VAR_MulaiTahun = "";
			VAR_JatuhTempoTanggal = "";
			VAR_JatuhTempoBulan = "";
			VAR_JatuhTempoTahun = "";
			VAR_GolonganPemohon = "";
			VAR_HubunganDenganBank = "";
			VAR_StatusPemohon = "";
			VAR_NegaraPihakPemohon = "";
			VAR_LembagaPemeringkat = "";
			VAR_PeringkatPerusahaan = "";
			VAR_TanggalPemeringkatanDay = "";
			VAR_TanggalPemeringkatanMonth = "";
			VAR_TanggalPemeringkatanYear = "";
			VAR_BankBeneficiary = "";
			VAR_CaraPembayaranLC = "";
			VAR_NominalLC = "";
			VAR_Plafon = "";
			VAR_PlafonInduk = "";
			VAR_JenisAgunanJaminan = "";
			VAR_SifatAgunanJaminan = "";
			VAR_JenisValutaAgunan = "";
			VAR_JangkaWaktuMulaiDay = "";
			VAR_JangkaWaktuMulaiMonth = "";
			VAR_JangkaWaktuMulaiYear = "";
			VAR_JangkaWaktuJatuhTempoDay = "";
			VAR_JangkaWaktuJatuhTempoMonth = "";
			VAR_JangkaWaktuJatuhTempoYear = "";
			VAR_NilaiAgunan = "";
			VAR_TanggalPenilaianTerakhirDay = "";
			VAR_TanggalPenilaianTerakhirMonth = "";
			VAR_TanggalPenilaianTerakhirYear = "";
			VAR_PenerbitAgunan = "";
			VAR_Paripasu = "";
			VAR_PPAPYangDibentuk = "";
			VAR_SetoranJaminan = "";
			VAR_NomorAkadAwal = "";
			VAR_TanggalAkadAwalDay = "";
			VAR_TanggalAkadAwalMonth = "";
			VAR_TanggalAkadAwalYear = "";
			VAR_NomorAkadAkhir = "";
			VAR_TanggalAkadAkhirDay = "";
			VAR_TanggalAkadAkhirMonth = "";
			VAR_TanggalAkadAkhirYear = "";
			VAR_Kolektibilitas = "";
			VAR_TglMacetDay = "";
			VAR_TglMacetMonth = "";
			VAR_TglMacetYear = "";
			VAR_SebabMacet = "";
			VAR_KeteranganMacet = "";
			VAR_TglWanPrestasiDay = "";
			VAR_TglWanPrestasiMonth = "";
			VAR_TglWanPrestasiYear = "";
			VAR_Kondisi = "";
			VAR_TglKondisiDay = "";
			VAR_TglKondisiMonth = "";
			VAR_TglKondisiYear = "";
		}

		private void AllDropDownListInitiation()
		{
			ListItem a = new ListItem("- SELECT -", "");

			DDL_BANK_BENEFICIARY.Items.Add(a);
			DDL_BLN_JANGKA_WAKTU2.Items.Add(a);
			DDL_BLN_JATUH_TEMPO.Items.Add(a);
			DDL_BLN_MULAI.Items.Add(a);
			DDL_BLN_MULAI2.Items.Add(a);
			DDL_BLN_PEMERINGKAT.Items.Add(a);
			DDL_BLN_PENILAIAN_TERAKHIR.Items.Add(a);
			DDL_CARAPEMBAYARAN_LC.Items.Add(a);
			DDL_GOL_PEMOHON.Items.Add(a);
			DDL_HUB_BANK.Items.Add(a);
			DDL_JENIS_AGUNAN.Items.Add(a);
			DDL_JENIS_LC.Items.Add(a);
			DDL_JENIS_VALUTA_AGUNAN.Items.Add(a);
			DDL_JNS_NASABAH.Items.Add(a);
			DDL_JNS_VALUTA.Items.Add(a);
			DDL_KOLEKTIBILITAS.Items.Add(a);
			DDL_LEMBAGA_PEMERINGKAT.Items.Add(a);
			DDL_MM_AKAD_AWAL.Items.Add(a);
			DDL_MM_TANGGALAKADAKHIR.Items.Add(a);
			DDL_MM_TGLKONDISI.Items.Add(a);
			DDL_MM_TGLMACET.Items.Add(a);
			DDL_MM_TGLWANPRESTASI.Items.Add(a);
			DDL_NEGARA_PEMOHON.Items.Add(a);
			DDL_PENERBIT_AGUNAN.Items.Add(a);
			DDL_PERINGKAT_PERUSAHAAN.Items.Add(a);
			DDL_SEBABMACET.Items.Add(a);
			DDL_SIFAT_AGUNAN.Items.Add(a);
			DDL_STATUS_PEMOHON.Items.Add(a);
		}

		private void VAR_to_CONTROL()
		{
			TXT_CIF.Text = VAR_CIF;
			TXT_CUSTNAME.Text = VAR_CustomerName;
			DDL_JNS_NASABAH.SelectedValue = VAR_JenisNasabah;
			TXT_NO_LC.Text = VAR_NoLC;
			DDL_JENIS_LC.SelectedValue = VAR_JenisLC;
			DDL_JNS_VALUTA.SelectedValue = VAR_JenisValuta;
			TXT_TGL_MULAI.Text = VAR_MulaiTanggal;
			DDL_BLN_MULAI.SelectedValue = VAR_MulaiBulan;
			TXT_THN_MULAI.Text = VAR_MulaiTahun;
			TXT_TGL_JATUH_TEMPO.Text = VAR_JatuhTempoTanggal;
			DDL_BLN_JATUH_TEMPO.SelectedValue = VAR_JatuhTempoBulan;
			TXT_THN_JATUH_TEMPO.Text = VAR_JatuhTempoTahun;
			DDL_GOL_PEMOHON.SelectedValue = VAR_GolonganPemohon;
			DDL_HUB_BANK.SelectedValue = VAR_HubunganDenganBank;
			DDL_STATUS_PEMOHON.SelectedValue = VAR_StatusPemohon;
			DDL_NEGARA_PEMOHON.SelectedValue = VAR_NegaraPihakPemohon;
			DDL_LEMBAGA_PEMERINGKAT.SelectedValue = VAR_LembagaPemeringkat;
			DDL_PERINGKAT_PERUSAHAAN.SelectedValue = VAR_PeringkatPerusahaan;
			TXT_TGL_PEMERINGKAT.Text = VAR_TanggalPemeringkatanDay;
			DDL_BLN_PEMERINGKAT.SelectedValue = VAR_TanggalPemeringkatanMonth;
			TXT_THN_PEMERINGKAT.Text = VAR_TanggalPemeringkatanYear;
			DDL_BANK_BENEFICIARY.SelectedValue = VAR_BankBeneficiary;
			DDL_CARAPEMBAYARAN_LC.SelectedValue = VAR_CaraPembayaranLC;
			TXT_NOMINAL_LC.Text = VAR_NominalLC;
			TXT_PLAFON.Text = VAR_Plafon;
			TXT_PLAFON_INDUK.Text = VAR_PlafonInduk;
			DDL_JENIS_AGUNAN.SelectedValue = VAR_JenisAgunanJaminan;
			DDL_SIFAT_AGUNAN.SelectedValue = VAR_SifatAgunanJaminan;
			DDL_JENIS_VALUTA_AGUNAN.SelectedValue = VAR_JenisValutaAgunan;
			TXT_TGL_MULAI2.Text = VAR_JangkaWaktuMulaiDay;
			DDL_BLN_MULAI2.SelectedValue = VAR_JangkaWaktuMulaiMonth;
			TXT_THN_MULAI2.Text = VAR_JangkaWaktuMulaiYear;
			TXT_TGL_JANGKA_WAKTU2.Text = VAR_JangkaWaktuJatuhTempoDay;
			DDL_BLN_JANGKA_WAKTU2.SelectedValue = VAR_JangkaWaktuJatuhTempoMonth;
			TXT_THN_JANGKA_WAKTU2.Text = VAR_JangkaWaktuJatuhTempoYear;
			TXT_NILAI_AGUNAN.Text = VAR_NilaiAgunan;
			TXT_TGL_PENILAIAN_TERAKHIR.Text = VAR_TanggalPenilaianTerakhirDay;
			DDL_BLN_PENILAIAN_TERAKHIR.SelectedValue = VAR_TanggalPenilaianTerakhirMonth;
			TXT_THN_PENILAIAN_TERAKHIR.Text = VAR_TanggalPenilaianTerakhirYear;
			DDL_PENERBIT_AGUNAN.SelectedValue = VAR_PenerbitAgunan;
			TXT_PARIPASU.Text = VAR_Paripasu;
			TXT_PPAP_YG_DIBENTUK.Text = VAR_PPAPYangDibentuk;
			TXT_SETORAN_JAMINAN.Text = VAR_SetoranJaminan;
			TXT_NOMOR_AKAD_AWAL.Text = VAR_NomorAkadAwal;
			TXT_DD_AKAD_AWAL.Text = VAR_TanggalAkadAwalDay;
			DDL_MM_AKAD_AWAL.SelectedValue = VAR_TanggalAkadAwalMonth;
			TXT_YY_AKAD_AWAL.Text = VAR_TanggalAkadAwalYear;
			TXT_NOMOR_AKAD_AKHIR.Text = VAR_NomorAkadAkhir;
			TXT_DD_TANGGALAKADAKHIR.Text = VAR_TanggalAkadAkhirDay;
			DDL_MM_TANGGALAKADAKHIR.SelectedValue = VAR_TanggalAkadAkhirMonth;
			TXT_YY_TANGGALAKADAKHIR.Text = VAR_TanggalAkadAkhirYear;
			DDL_KOLEKTIBILITAS.SelectedValue = VAR_Kolektibilitas;
			TXT_DD_TGLMACET.Text = VAR_TglMacetDay;
			DDL_MM_TGLMACET.SelectedValue = VAR_TglMacetMonth;
			TXT_YY_TGLMACET.Text = VAR_TglMacetYear;
			DDL_SEBABMACET.SelectedValue = VAR_SebabMacet;
			TXT_KETERANGANMACET.Text = VAR_KeteranganMacet;
			TXT_DD_TGLWANPRESTASI.Text = VAR_TglWanPrestasiDay;
			DDL_MM_TGLWANPRESTASI.SelectedValue = VAR_TglWanPrestasiMonth;
			TXT_YY_TGLWANPRESTASI.Text = VAR_TglWanPrestasiYear;
			TXT_KONDISI.Text = VAR_Kondisi;
			TXT_DD_TGLKONDISI.Text = VAR_TglKondisiDay;
			DDL_MM_TGLKONDISI.SelectedValue = VAR_TglKondisiMonth;
			TXT_YY_TGLKONDISI.Text = VAR_TglKondisiYear;
		}

		private void CONTROL_to_VAR()
		{
			VAR_CIF = TXT_CIF.Text.ToString();
			VAR_CustomerName = TXT_CUSTNAME.Text.ToString();
			VAR_JenisNasabah = DDL_JNS_NASABAH.SelectedValue.ToString();
			VAR_NoLC = TXT_NO_LC.Text.ToString();
			VAR_JenisLC = DDL_JENIS_LC.SelectedValue.ToString();
			VAR_JenisValuta = DDL_JNS_VALUTA.SelectedValue.ToString();
			VAR_MulaiTanggal = TXT_TGL_MULAI.Text.ToString();
			VAR_MulaiBulan = DDL_BLN_MULAI.SelectedValue.ToString();
			VAR_MulaiTahun = TXT_THN_MULAI.Text.ToString();
			VAR_JatuhTempoTanggal = TXT_TGL_JATUH_TEMPO.Text.ToString();
			VAR_JatuhTempoBulan = DDL_BLN_JATUH_TEMPO.SelectedValue.ToString();
			VAR_JatuhTempoTahun = TXT_THN_JATUH_TEMPO.Text.ToString();
			VAR_GolonganPemohon = DDL_GOL_PEMOHON.SelectedValue.ToString();
			VAR_HubunganDenganBank = DDL_HUB_BANK.SelectedValue.ToString();
			VAR_StatusPemohon = DDL_STATUS_PEMOHON.SelectedValue.ToString();
			VAR_NegaraPihakPemohon = DDL_NEGARA_PEMOHON.SelectedValue.ToString();
			VAR_LembagaPemeringkat = DDL_LEMBAGA_PEMERINGKAT.SelectedValue.ToString();
			VAR_PeringkatPerusahaan = DDL_PERINGKAT_PERUSAHAAN.SelectedValue.ToString();
			VAR_TanggalPemeringkatanDay = TXT_TGL_PEMERINGKAT.Text.ToString();
			VAR_TanggalPemeringkatanMonth = DDL_BLN_PEMERINGKAT.SelectedValue.ToString();
			VAR_TanggalPemeringkatanYear = TXT_THN_PEMERINGKAT.Text.ToString();
			VAR_BankBeneficiary = DDL_BANK_BENEFICIARY.SelectedValue.ToString();
			VAR_CaraPembayaranLC = DDL_CARAPEMBAYARAN_LC.SelectedValue.ToString();
			VAR_NominalLC = TXT_NOMINAL_LC.Text.ToString();
			VAR_Plafon = TXT_PLAFON.Text.ToString();
			VAR_PlafonInduk = TXT_PLAFON_INDUK.Text.ToString();
			VAR_JenisAgunanJaminan = DDL_JENIS_AGUNAN.SelectedValue.ToString();
			VAR_SifatAgunanJaminan = DDL_SIFAT_AGUNAN.SelectedValue.ToString();
			VAR_JenisValutaAgunan = DDL_JENIS_VALUTA_AGUNAN.SelectedValue.ToString();
			VAR_JangkaWaktuMulaiDay = TXT_TGL_MULAI2.Text.ToString();
			VAR_JangkaWaktuMulaiMonth = DDL_BLN_MULAI2.SelectedValue.ToString();
			VAR_JangkaWaktuMulaiYear = TXT_THN_MULAI2.Text.ToString();
			VAR_JangkaWaktuJatuhTempoDay = TXT_TGL_JANGKA_WAKTU2.Text.ToString();
			VAR_JangkaWaktuJatuhTempoMonth = DDL_BLN_JANGKA_WAKTU2.SelectedValue.ToString();
			VAR_JangkaWaktuJatuhTempoYear = TXT_THN_JANGKA_WAKTU2.Text.ToString();
			VAR_NilaiAgunan = TXT_NILAI_AGUNAN.Text.ToString();
			VAR_TanggalPenilaianTerakhirDay = TXT_TGL_PENILAIAN_TERAKHIR.Text.ToString();
			VAR_TanggalPenilaianTerakhirMonth = DDL_BLN_PENILAIAN_TERAKHIR.SelectedValue.ToString();
			VAR_TanggalPenilaianTerakhirYear = TXT_THN_PENILAIAN_TERAKHIR.Text.ToString();
			VAR_PenerbitAgunan = DDL_PENERBIT_AGUNAN.SelectedValue.ToString();
			VAR_Paripasu = TXT_PARIPASU.Text.ToString();
			VAR_PPAPYangDibentuk = TXT_PPAP_YG_DIBENTUK.Text.ToString();
			VAR_SetoranJaminan = TXT_SETORAN_JAMINAN.Text.ToString();
			VAR_NomorAkadAwal = TXT_NOMOR_AKAD_AWAL.Text.ToString();
			VAR_TanggalAkadAwalDay = TXT_DD_AKAD_AWAL.Text.ToString();
			VAR_TanggalAkadAwalMonth = DDL_MM_AKAD_AWAL.SelectedValue.ToString();
			VAR_TanggalAkadAwalYear = TXT_YY_AKAD_AWAL.Text.ToString();
			VAR_NomorAkadAkhir = TXT_NOMOR_AKAD_AKHIR.Text.ToString();
			VAR_TanggalAkadAkhirDay = TXT_DD_TANGGALAKADAKHIR.Text.ToString();
			VAR_TanggalAkadAkhirMonth = DDL_MM_TANGGALAKADAKHIR.SelectedValue.ToString();
			VAR_TanggalAkadAkhirYear = TXT_YY_TANGGALAKADAKHIR.Text.ToString();
			VAR_Kolektibilitas = DDL_KOLEKTIBILITAS.SelectedValue.ToString();
			VAR_TglMacetDay = TXT_DD_TGLMACET.Text.ToString();
			VAR_TglMacetMonth = DDL_MM_TGLMACET.SelectedValue.ToString();
			VAR_TglMacetYear = TXT_YY_TGLMACET.Text.ToString();
			VAR_SebabMacet = DDL_SEBABMACET.SelectedValue.ToString();
			VAR_KeteranganMacet = TXT_KETERANGANMACET.Text.ToString();
			VAR_TglWanPrestasiDay = TXT_DD_TGLWANPRESTASI.Text.ToString();
			VAR_TglWanPrestasiMonth = DDL_MM_TGLWANPRESTASI.SelectedValue.ToString();
			VAR_TglWanPrestasiYear = TXT_YY_TGLWANPRESTASI.Text.ToString();
			VAR_Kondisi = TXT_KONDISI.Text.ToString();
			VAR_TglKondisiDay = TXT_DD_TGLKONDISI.Text.ToString();
			VAR_TglKondisiMonth = DDL_MM_TGLKONDISI.SelectedValue.ToString();
			VAR_TglKondisiYear = TXT_YY_TGLKONDISI.Text.ToString();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("TradeDataCompleteList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}
	}
}
