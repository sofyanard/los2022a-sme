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
	public partial class BGDataComplet : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TXT_JUMLAH;
		protected System.Web.UI.WebControls.DropDownList DDL_JENIS_VALUTA_AGUNAN;
		protected System.Web.UI.WebControls.DropDownList DDL_JENIS_AGUNANa;
		protected System.Web.UI.WebControls.DropDownList DDL_SIFAT_AGUNANa;
		protected Tools tool = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn3 = new Connection(ConfigurationSettings.AppSettings["conn2"]);

		private string VAR_CIF;
		private string VAR_CustomerName;
		private string VAR_Jenis;
		private string VAR_NomorBG;
		private string VAR_TujuanPenerbitanBG;
		private string VAR_PenerimaGaransi;
		private string VAR_JenisValuta;
		private string VAR_MulaiDay;
		private string VAR_MulaiMonth;
		private string VAR_MulaiYear;
		private string VAR_JatuhTempoDay;
		private string VAR_JatuhTempoMonth;
		private string VAR_JatuhTempoYear;
		private string VAR_GolonganPemohon;
		private string VAR_HubunganDenganBank;
		private string VAR_TujuanBerhubunganDgnBank;
		private string VAR_StatusPemohon;
		private string VAR_NegaraPihakPemohon;
		private string VAR_LembagaPemeringkat;
		private string VAR_PeringkatPerusahaan;
		private string VAR_TanggalPemeringkatanDay;
		private string VAR_TanggalPemeringkatanMonth;
		private string VAR_TanggalPemeringkatanYear;
		private string VAR_NilaiNominalBG;
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
		private string VAR_AgunanYangDiperhitungkan;
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
			//VAR_to_CONTROL();
			//CheckingError(this, Color.Red);
		}

		private void CheckError()
		{
			string id = "";

			conn2.QueryString = "EXEC DCM_DATA_ERROR_CHECKING '" + Request.QueryString["acctno"] + "','4'";
			conn2.ExecuteQuery();

			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				string err_msg = conn2.GetFieldValue(i, "ERR_MSG").ToString().Replace(";","");

				conn3.QueryString = "SELECT IDCONTROL FROM DCM_TABLE_ERROR WHERE PAGE = 'BGDataComplet.aspx' AND MESSAGE = '" + err_msg.Trim() + "'";
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
			VAR_Jenis = "";
			VAR_NomorBG = "";
			VAR_TujuanPenerbitanBG = "";
			VAR_PenerimaGaransi = "";
			VAR_JenisValuta = "";
			VAR_MulaiDay = "";
			VAR_MulaiMonth = "";
			VAR_MulaiYear = "";
			VAR_JatuhTempoDay = "";
			VAR_JatuhTempoMonth = "";
			VAR_JatuhTempoYear = "";
			VAR_GolonganPemohon = "";
			VAR_HubunganDenganBank = "";
			VAR_TujuanBerhubunganDgnBank = "";
			VAR_StatusPemohon = "";
			VAR_NegaraPihakPemohon = "";
			VAR_LembagaPemeringkat = "";
			VAR_PeringkatPerusahaan = "";
			VAR_TanggalPemeringkatanDay = "";
			VAR_TanggalPemeringkatanMonth = "";
			VAR_TanggalPemeringkatanYear = "";
			VAR_NilaiNominalBG = "";
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
			VAR_AgunanYangDiperhitungkan = "";
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

			DDL_BLN_MULAI.Items.Add(a);
			DDL_BLN_PENILAIAN.Items.Add(a);
			DDL_GOLONGAN_PEMOHON.Items.Add(a);
			DDL_HUBUNGAN_DGN_BANK.Items.Add(a);
			DDL_JENIS_AGUNAN.Items.Add(a);
			DDL_JNSVALUTA_AGUNAN.Items.Add(a);
			DDL_JENISVALUTA.Items.Add(a);
			DDL_JNS.Items.Add(a);
			DDL_JNSVALUTA_AGUNAN.Items.Add(a);
			DDL_KOLEKTIBILITAS.Items.Add(a);
			DDL_LEMBAGAPEMERINGKAT.Items.Add(a);
			DDL_MM_JATUHTEMPO.Items.Add(a);
			DDL_MM_JKWKJATTEMP.Items.Add(a);
			DDL_MM_JKWKMUL.Items.Add(a);
			DDL_MM_TGLAKADAKHIR.Items.Add(a);
			DDL_MM_TGLKONDISI.Items.Add(a);
			DDL_MM_TGLMACET.Items.Add(a);
			DDL_MM_TGLPEMERINGKATAN.Items.Add(a);
			DDL_MM_WANPRESTASI.Items.Add(a);
			DDL_NEGARAPIHAKPEMOHON.Items.Add(a);
			DDL_PERINGKATPERUSH.Items.Add(a);
			DDL_SEBABMACET.Items.Add(a);
			DDL_SIFAT_AGUNAN.Items.Add(a);
			DDL_STATUSPEMOHON.Items.Add(a);
			DDL_TUJUAN_HUB_BANK.Items.Add(a);
			DDL_TUJUANPENERBITAN.Items.Add(a);
		}

		private void VAR_to_CONTROL()
		{
			TXT_CIF.Text = VAR_CIF;
			TXT_NAME.Text = VAR_CustomerName;
			//string a = DDL_JNS.SelectedValue.ToString();
			//string b = DDL_JNS.SelectedItem.Text.ToString();
			DDL_JNS.SelectedValue = VAR_Jenis;
			TXT_NOBG.Text = VAR_NomorBG;
			DDL_TUJUANPENERBITAN.SelectedValue = VAR_TujuanPenerbitanBG;
			TXT_PENERIMAGARANSI.Text = VAR_PenerimaGaransi;
			DDL_JENISVALUTA.SelectedValue = VAR_JenisValuta;
			TXT_TGL_MULAI.Text = VAR_MulaiDay;
			DDL_BLN_MULAI.SelectedValue = VAR_MulaiMonth;
			TXT_THN_MULAI.Text = VAR_MulaiYear;
			TXT_DD_JATUHTEMPO.Text = VAR_JatuhTempoDay;
			DDL_MM_JATUHTEMPO.SelectedValue = VAR_JatuhTempoMonth;
			TXT_YY_JATUHTEMPO.Text = VAR_JatuhTempoYear;
			DDL_GOLONGAN_PEMOHON.SelectedValue = VAR_GolonganPemohon;
			DDL_HUBUNGAN_DGN_BANK.SelectedValue = VAR_HubunganDenganBank;
			DDL_TUJUAN_HUB_BANK.SelectedValue = VAR_TujuanBerhubunganDgnBank;
			DDL_STATUSPEMOHON.SelectedValue = VAR_StatusPemohon;
			DDL_NEGARAPIHAKPEMOHON.SelectedValue = VAR_NegaraPihakPemohon;
			DDL_LEMBAGAPEMERINGKAT.SelectedValue = VAR_LembagaPemeringkat;
			DDL_PERINGKATPERUSH.SelectedValue = VAR_PeringkatPerusahaan;
			TXT_DD_TGLPEMERINGKATAN.Text = VAR_TanggalPemeringkatanDay;
			DDL_MM_TGLPEMERINGKATAN.SelectedValue = VAR_TanggalPemeringkatanMonth;
			TXT_YY_TGLPEMERINGKATAN.Text = VAR_TanggalPemeringkatanYear;
			TXT_NILAI_BG.Text = VAR_NilaiNominalBG;
			TXT_PLAFOND.Text = VAR_Plafon;
			TXT_PLAFOND_INDUK.Text = VAR_PlafonInduk;
			DDL_JENIS_AGUNAN.SelectedValue = VAR_JenisAgunanJaminan;
			DDL_SIFAT_AGUNAN.SelectedValue = VAR_SifatAgunanJaminan;
			DDL_JNSVALUTA_AGUNAN.SelectedValue = VAR_JenisValutaAgunan;
			TXT_DD_JKWKMUL.Text = VAR_JangkaWaktuMulaiDay;
		 	DDL_MM_JKWKMUL.SelectedValue = VAR_JangkaWaktuMulaiMonth;
			TXT_YY_JKWKMUL.Text = VAR_JangkaWaktuMulaiYear;
			TXT_DD_JKWKJATTEMP.Text = VAR_JangkaWaktuJatuhTempoDay;
			DDL_MM_JKWKJATTEMP.SelectedValue = VAR_JangkaWaktuJatuhTempoMonth;
			TXT_YY_JKWKJATTEMP.Text = VAR_JangkaWaktuJatuhTempoYear;
			TXT_NILAI_AGUNAN.Text = VAR_NilaiAgunan;
			TXT_TGL_PENILAIAN.Text = VAR_TanggalPenilaianTerakhirDay;
			DDL_BLN_PENILAIAN.SelectedValue = VAR_TanggalPenilaianTerakhirMonth;
			TXT_THN_PENILAIAN.Text = VAR_TanggalPenilaianTerakhirYear;
			TXT_PENERBITAGUNAN.Text = VAR_PenerbitAgunan;
			TXT_PARIPASU.Text = VAR_Paripasu;
			TXT_AGUNANYGDIPERHTNGKN.Text = VAR_AgunanYangDiperhitungkan;
			TXT_PPAPYGDIBENTUK.Text = VAR_PPAPYangDibentuk;
			TXT_SETORJAM.Text = VAR_SetoranJaminan;
			TXT_NMR_AKAD_AWAL.Text = VAR_NomorAkadAwal;
			TXT_DD_AKAD_AWAL.Text = VAR_TanggalAkadAwalDay;
			DLL_MM_AKAD_AWAL.SelectedValue = VAR_TanggalAkadAwalMonth;
			TXT_YY_AKAD_AWAL.Text =  VAR_TanggalAkadAwalYear;
			TXT_NMR_AKAD_AKHIR.Text = VAR_NomorAkadAkhir;
			TXT_DD_TGLAKADAKHIR.Text = VAR_TanggalAkadAkhirDay;
			DDL_MM_TGLAKADAKHIR.SelectedValue = VAR_TanggalAkadAkhirMonth;
			TXT_YY_TGLAKADAKHIR.Text = VAR_TanggalAkadAkhirYear;
			DDL_KOLEKTIBILITAS.SelectedValue = VAR_Kolektibilitas;
			TXT_DD_TGLMACET.Text = VAR_TglMacetDay;
			DDL_MM_TGLMACET.SelectedValue = VAR_TglMacetMonth;
			TXT_YY_TGLMACET.Text = VAR_TglMacetYear;
			DDL_SEBABMACET.SelectedValue = VAR_SebabMacet;
			TXT_KET_MACET.Text = VAR_KeteranganMacet;
			TXT_DD_WANPRESTASI.Text = VAR_TglWanPrestasiDay;
			DDL_MM_WANPRESTASI.SelectedValue = VAR_TglWanPrestasiMonth;
			TXT_YY_WANPRESTASI.Text = VAR_TglWanPrestasiYear;
			TXT_KONDISI.Text = VAR_Kondisi;
			TXT_DD_TGLKONDISI.Text = VAR_TglKondisiDay;
			DDL_MM_TGLKONDISI.SelectedValue = VAR_TglKondisiMonth;
			TXT_YY_TGLKONDISI.Text = VAR_TglKondisiYear;
		}

		private void CONTROL_to_VAR()
		{
			VAR_CIF = TXT_CIF.Text.ToString();
			VAR_CustomerName = TXT_NAME.Text.ToString();
			VAR_Jenis = DDL_JNS.SelectedValue.ToString();
			VAR_NomorBG = TXT_NOBG.Text.ToString();
			VAR_TujuanPenerbitanBG = DDL_TUJUANPENERBITAN.SelectedValue.ToString();
			VAR_PenerimaGaransi = TXT_PENERIMAGARANSI.Text.ToString();
			VAR_JenisValuta = DDL_JENISVALUTA.SelectedValue.ToString();
			VAR_MulaiDay = TXT_TGL_MULAI.Text.ToString();
			VAR_MulaiMonth = DDL_BLN_MULAI.SelectedValue.ToString();
			VAR_MulaiYear = TXT_THN_MULAI.Text.ToString();
			VAR_JatuhTempoDay = TXT_DD_JATUHTEMPO.Text.ToString();
			VAR_JatuhTempoMonth = DDL_MM_JATUHTEMPO.SelectedValue.ToString();
			VAR_JatuhTempoYear = TXT_YY_JATUHTEMPO.Text.ToString();
			VAR_GolonganPemohon = DDL_GOLONGAN_PEMOHON.SelectedValue.ToString();
			VAR_HubunganDenganBank = DDL_HUBUNGAN_DGN_BANK.SelectedValue.ToString();
			VAR_TujuanBerhubunganDgnBank = DDL_TUJUAN_HUB_BANK.SelectedValue.ToString();
			VAR_StatusPemohon = DDL_STATUSPEMOHON.SelectedValue.ToString();
			VAR_NegaraPihakPemohon = DDL_NEGARAPIHAKPEMOHON.SelectedValue.ToString();
			VAR_LembagaPemeringkat = DDL_LEMBAGAPEMERINGKAT.SelectedValue.ToString();
			VAR_PeringkatPerusahaan = DDL_PERINGKATPERUSH.SelectedValue.ToString();
			VAR_TanggalPemeringkatanDay = TXT_DD_TGLPEMERINGKATAN.Text.ToString();
			VAR_TanggalPemeringkatanMonth = DDL_MM_TGLPEMERINGKATAN.SelectedValue.ToString();
			VAR_TanggalPemeringkatanYear = TXT_YY_TGLPEMERINGKATAN.Text.ToString();
			VAR_NilaiNominalBG = TXT_NILAI_BG.Text.ToString();
			VAR_Plafon = TXT_PLAFOND.Text.ToString();
			VAR_PlafonInduk = TXT_PLAFOND_INDUK.Text.ToString();
			VAR_JenisAgunanJaminan = DDL_JENIS_AGUNAN.SelectedValue.ToString();
			VAR_SifatAgunanJaminan = DDL_SIFAT_AGUNAN.SelectedValue.ToString();
			VAR_JenisValutaAgunan = DDL_JNSVALUTA_AGUNAN.SelectedValue.ToString();
			VAR_JangkaWaktuMulaiDay = TXT_DD_JKWKMUL.Text.ToString();
			VAR_JangkaWaktuMulaiMonth = DDL_MM_JKWKMUL.SelectedValue.ToString();
			VAR_JangkaWaktuMulaiYear = TXT_YY_JKWKMUL.Text.ToString();
			VAR_JangkaWaktuJatuhTempoDay = TXT_DD_JKWKJATTEMP.Text.ToString();
			VAR_JangkaWaktuJatuhTempoMonth = DDL_MM_JKWKJATTEMP.SelectedItem.ToString();
			VAR_JangkaWaktuJatuhTempoYear = TXT_YY_JKWKJATTEMP.Text.ToString();
			VAR_NilaiAgunan = TXT_NILAI_AGUNAN.Text.ToString();
			VAR_TanggalPenilaianTerakhirDay = TXT_TGL_PENILAIAN.Text.ToString();
			VAR_TanggalPenilaianTerakhirMonth = DDL_BLN_PENILAIAN.SelectedValue.ToString();
			VAR_TanggalPenilaianTerakhirYear = TXT_THN_PENILAIAN.Text.ToString();
			VAR_PenerbitAgunan = TXT_PENERBITAGUNAN.Text.ToString();
			VAR_Paripasu = TXT_PARIPASU.Text.ToString();
			VAR_AgunanYangDiperhitungkan = TXT_AGUNANYGDIPERHTNGKN.Text.ToString();
			VAR_PPAPYangDibentuk = TXT_PPAPYGDIBENTUK.Text.ToString();
			VAR_SetoranJaminan = TXT_SETORJAM.Text.ToString();
			VAR_NomorAkadAwal = TXT_NMR_AKAD_AWAL.Text.ToString();
			VAR_TanggalAkadAwalDay = TXT_DD_AKAD_AWAL.Text.ToString();
			VAR_TanggalAkadAwalMonth = DLL_MM_AKAD_AWAL.SelectedValue.ToString();
			VAR_TanggalAkadAwalYear = TXT_YY_AKAD_AWAL.Text.ToString();
			VAR_NomorAkadAkhir = TXT_NMR_AKAD_AKHIR.Text.ToString();
			VAR_TanggalAkadAkhirDay = TXT_DD_TGLAKADAKHIR.Text.ToString();
			VAR_TanggalAkadAkhirMonth = DDL_MM_TGLAKADAKHIR.SelectedValue.ToString();
			VAR_TanggalAkadAkhirYear = TXT_YY_TGLAKADAKHIR.Text.ToString();
			VAR_Kolektibilitas = DDL_KOLEKTIBILITAS.SelectedValue.ToString();
			VAR_TglMacetDay = TXT_DD_TGLMACET.Text.ToString();
			VAR_TglMacetMonth = DDL_MM_TGLMACET.SelectedValue.ToString();
			VAR_TglMacetYear = TXT_YY_TGLMACET.Text.ToString();
			VAR_SebabMacet = DDL_SEBABMACET.SelectedValue.ToString();
			VAR_KeteranganMacet = TXT_KET_MACET.Text.ToString();
			VAR_TglWanPrestasiDay = TXT_DD_WANPRESTASI.Text.ToString();
			VAR_TglWanPrestasiMonth = DDL_MM_WANPRESTASI.SelectedValue.ToString();
			VAR_TglWanPrestasiYear = TXT_YY_WANPRESTASI.Text.ToString();
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
