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

namespace SME.DCM.DataCompleteness.CAP
{
	/// <summary>
	/// Summary description for AccountDataComplet.
	/// </summary>
	public partial class AccountDataComplet : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LBL_DDL_LOAN_TYPE2;
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn3 = new Connection(ConfigurationSettings.AppSettings["conn2"]);

		private string VAR_NomorRekening;
		private string VAR_LoanType;
		private string VAR_SifatKredit;
		private string VAR_JenisPenggunaan;
		private string VAR_OrientasiPenggunaan;
		private string VAR_GolonganKredit;
		private string VAR_JenisKredit;
		private string VAR_FasPenyediaanDana;
		private string VAR_BankUtamaSindikasi;
		private string VAR_LokasiProyek;
		private string VAR_AlamatProyek;
		private string VAR_NilaiProyek;
		private string VAR_NegaraAsal;
		private string VAR_JumlahRekening;
		private string VAR_StatusDebitur;
		private string VAR_KategoriDebitur;
		private string VAR_KategoriPortofolio;
		private string VAR_JenisValutaInduk;
		private string VAR_JenisValutaFasilitas;
		private string VAR_TunggakanPokok;
		private string VAR_TanggalTunggakan;
		private string VAR_FrekTunggakanPokok;
		private string VAR_GolonganPenjamin;
		private string VAR_BagianYangDijamin;
		private string VAR_KSEBI1;
		private string VAR_KSEBI2;
		private string VAR_KSEBI3;
		private string VAR_KSEBI4;
		private string VAR_TanggalPKPertamaDay;
		private string VAR_TanggalPKPertamaMonth;
		private string VAR_TanggalPKPertamaYear;
		private string VAR_NoPKPertama;
		private string VAR_TAnggalPKTerakhirDay;
		private string VAR_TAnggalPKTerakhirMonth;
		private string VAR_TAnggalPKTerakhirYear;
		private string VAR_NoPKTerakhir;
		private string VAR_Kolektibilitas;
		private string VAR_PerhitunganPPA;
		private string VAR_OtomatisKolektibilitas;
		private string VAR_KategoriPengukuran;
		private string VAR_TKSukuBungaInduk;
		private string VAR_TKSukuBungaPerfasilitas;
		private string VAR_JenisSukuBunga;
		private string VAR_PlafondInduk;
		private string VAR_Plafond;
		private string VAR_TunggakanBungaIntra;
		private string VAR_TunggakanBungaEkstra;
		private string VAR_FrekTunggakanBunga;
		private string VAR_OneEntityFlag;
		private string VAR_Restrukturisasi;
		private string VAR_JenisRestru;
		private string VAR_TglRestruAwalDay;
		private string VAR_TglRestruAwalMonth;
		private string VAR_TglRestruAwalYear;
		private string VAR_TglRestruAkhirDay;
		private string VAR_TglRestruAkhirMonth;
		private string VAR_TglRestruAkhirYear;
		private string VAR_TglReviewRestruDay;
		private string VAR_TglReviewRestruYear;
		private string VAR_TglReviewRestruMonth;
		private string VAR_RestrukturisasiKe;
		private string VAR_KetReskturkturisasi;
		private string VAR_SandiKodePosisi;
		private string VAR_TglPosisiDay;
		private string VAR_TglPosisiMonth;
		private string VAR_TglPosisiYear;
		private string VAR_SebabMacet;
		private string VAR_TanggalMacetDay;
		private string VAR_TanggalMacetMonth;
		private string VAR_TanggalMacetYear;
		private string VAR_BakiDebet;
		private string VAR_Committed;
		private string VAR_Uncommitted;
		private string VAR_PenpdtBungaYAD;
		private string VAR_PendptDitangguhkan;
		private string VAR_Individual;
		private string VAR_Kolektif;
		private string VAR_JenisPengajuan;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			AllDropDownListInitiation();
			RetrieveSOA();
			VAR_to_CONTROL();
			CheckingError(this, Color.Red);
		}

		private void ViewMenu()
		{
			Menu.Controls.Clear();
			try
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '" + Request.QueryString["mc"] + "' ";
				conn.ExecuteQuery();

				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim() != "")
					{
						if (conn.GetFieldValue(i, 3).IndexOf("mc=") >= 0)
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref=" + Request.QueryString["rekanan_ref"] + "&tc=" + Request.QueryString["tc"] + "&exist=" + Request.QueryString["exist"] + "&view=" + Request.QueryString["view"];
						else
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref=" + Request.QueryString["rekanan_ref"] + "&mc=" + Request.QueryString["mc"] + "&exist=" + Request.QueryString["exist"] + "&tc=" + Request.QueryString["tc"] + "&view=" + Request.QueryString["view"];
						if (conn.GetFieldValue(i, 3).IndexOf("?par=") < 0 && conn.GetFieldValue(i, 3).IndexOf("&par=") < 0)
							strtemp = strtemp + "&par=" + Request.QueryString["par"] + "&mc2=" + Request.QueryString["mc2"];
					}
					else
					{
						strtemp = "";
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3) + strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			}
			catch (Exception ex)
			{
				string temp = ex.ToString();
			}
		}

		private void CheckError()
		{
			string id = "";

			conn2.QueryString = "EXEC DCM_DATA_ERROR_CHECKING '" + Request.QueryString["acctno"] + "','4'";
			conn2.ExecuteQuery();

			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				string err_msg = conn2.GetFieldValue(i, "ERR_MSG").ToString().Replace(";","");

				conn3.QueryString = "SELECT IDCONTROL FROM DCM_TABLE_ERROR WHERE PAGE = 'AccountDataComplet.aspx' AND MESSAGE = '" + err_msg.Trim() + "'";
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
			VAR_NomorRekening = ""; 
			VAR_LoanType = ""; 
			VAR_SifatKredit = ""; 
			VAR_JenisPenggunaan = ""; 
			VAR_OrientasiPenggunaan = ""; 
			VAR_GolonganKredit = ""; 
			VAR_JenisKredit = ""; 
			VAR_FasPenyediaanDana = ""; 
			VAR_BankUtamaSindikasi = ""; 
			VAR_LokasiProyek = ""; 
			VAR_AlamatProyek = ""; 
			VAR_NilaiProyek = ""; 
			VAR_NegaraAsal = ""; 
			VAR_JumlahRekening = ""; 
			VAR_StatusDebitur = ""; 
			VAR_KategoriDebitur = ""; 
			VAR_KategoriPortofolio = ""; 
			VAR_JenisValutaInduk = ""; 
			VAR_JenisValutaFasilitas = ""; 
			VAR_TunggakanPokok = ""; 
			VAR_TanggalTunggakan = ""; 
			VAR_FrekTunggakanPokok = ""; 
			VAR_GolonganPenjamin = ""; 
			VAR_BagianYangDijamin = ""; 
			VAR_KSEBI1 = ""; 
			VAR_KSEBI2 = ""; 
			VAR_KSEBI3 = ""; 
			VAR_KSEBI4 = ""; 
			VAR_TanggalPKPertamaDay = ""; 
			VAR_TanggalPKPertamaMonth = ""; 
			VAR_TanggalPKPertamaYear = ""; 
			VAR_NoPKPertama = ""; 
			VAR_TAnggalPKTerakhirDay = ""; 
			VAR_TAnggalPKTerakhirMonth = ""; 
			VAR_TAnggalPKTerakhirYear = ""; 
			VAR_NoPKTerakhir = ""; 
			VAR_Kolektibilitas = ""; 
			VAR_PerhitunganPPA = null; 
			VAR_OtomatisKolektibilitas = null; 
			VAR_KategoriPengukuran = ""; 
			VAR_TKSukuBungaInduk = ""; 
			VAR_TKSukuBungaPerfasilitas = ""; 
			VAR_JenisSukuBunga = ""; 
			VAR_PlafondInduk = ""; 
			VAR_Plafond = ""; 
			VAR_TunggakanBungaEkstra = ""; 
			VAR_TunggakanBungaIntra = ""; 
			VAR_FrekTunggakanBunga = ""; 
			VAR_OneEntityFlag = null; 
			VAR_Restrukturisasi = null; 
			VAR_JenisRestru = ""; 
			VAR_TglRestruAwalDay = ""; 
			VAR_TglRestruAwalMonth = ""; 
			VAR_TglRestruAwalYear = ""; 
			VAR_TglRestruAkhirDay = ""; 
			VAR_TglRestruAkhirMonth = ""; 
			VAR_TglRestruAkhirYear = ""; 
			VAR_TglReviewRestruDay = ""; 
			VAR_TglReviewRestruMonth = ""; 
			VAR_TglReviewRestruYear = ""; 
			VAR_RestrukturisasiKe = ""; 
			VAR_KetReskturkturisasi = ""; 
			VAR_SandiKodePosisi = ""; 
			VAR_TglPosisiDay = ""; 
			VAR_TglPosisiMonth = ""; 
			VAR_TglPosisiYear = ""; 
			VAR_SebabMacet = ""; 
			VAR_TanggalMacetDay = ""; 
			VAR_TanggalMacetMonth = ""; 
			VAR_TanggalMacetYear = ""; 
			VAR_BakiDebet = ""; 
			VAR_Committed = null; 
			VAR_Uncommitted = null; 
			VAR_PenpdtBungaYAD = ""; 
			VAR_PendptDitangguhkan = ""; 
			VAR_Individual = null; 
			VAR_Kolektif = null; 
			VAR_JenisPengajuan = null; 
		}

		private void AllDropDownListInitiation()
		{
			ListItem a = new ListItem("- SELECT -", "");

			DDL_LOAN_TYPE.Items.Add(a);
			DDL_SIFAT_KREDIT.Items.Add(a);
			DDL_JENIS_PENGGUNAAN.Items.Add(a);
			DDL_ORIENTASI.Items.Add(a);
			DDL_GOL_KREDIT.Items.Add(a);
			DDL_JENIS_KREDIT.Items.Add(a);
			DDL_FAS_DANA.Items.Add(a);
			DDL_BANK_SINDIKASI.Items.Add(a);
			DDL_LOKASI_PROYEK.Items.Add(a);
			DDL_NEGARAASAL.Items.Add(a);
			DDL_JNSVALIND.Items.Add(a);
			DDL_JNSVALFAL.Items.Add(a);
			DDL_GOL_PENJAMIN.Items.Add(a);
			DDL_KSEBI1.Items.Add(a);
			DDL_KSEBI2.Items.Add(a);
			DDL_KSEBI3.Items.Add(a);
			DDL_KSEBI4.Items.Add(a);

			DDL_BULAN_PKPERTAMA.Items.Add(a);
			DDL_BULAN_PKAKHIR.Items.Add(a);
			DDL_KOLEKTIBILITAS.Items.Add(a);
			DDL_JNS_SUKBUNG.Items.Add(a);
			DDL_JENISRESTRU.Items.Add(a);
			
			DDL_MM_RESTRUAWAL.Items.Add(a);
			DDL_MM_RESTRUAKHIR.Items.Add(a);
			DDL_MM_RESTRUREVIEW.Items.Add(a);
			
			DDL_KETRESTRU.Items.Add(a);
			DDL_SANDIKODEPOSISI.Items.Add(a);

			DDL_MM_TGLPOSISI.Items.Add(a);
			DDL_SEBABMACET.Items.Add(a);
			DDL_MM_TGLMACET.Items.Add(a);
		}

		private void VAR_to_CONTROL()
		{
			TXT_NOMOR_REKENING.Text = VAR_NomorRekening;
			DDL_LOAN_TYPE.SelectedValue = VAR_LoanType;
			DDL_SIFAT_KREDIT.SelectedValue = VAR_SifatKredit;
			DDL_JENIS_PENGGUNAAN.SelectedValue = VAR_JenisPenggunaan;
			DDL_ORIENTASI.SelectedValue = VAR_OrientasiPenggunaan;
			DDL_GOL_KREDIT.SelectedValue = VAR_GolonganKredit;
			DDL_JENIS_KREDIT.SelectedValue = VAR_JenisKredit;
			DDL_FAS_DANA.SelectedValue = VAR_FasPenyediaanDana;
			DDL_BANK_SINDIKASI.SelectedValue = VAR_BankUtamaSindikasi;
			DDL_LOKASI_PROYEK.SelectedValue = VAR_LokasiProyek;
			TXT_ALAMATPROJ.Text = VAR_AlamatProyek;
			DDL_NILAI_PROYEK.SelectedValue = VAR_NilaiProyek;
			DDL_NEGARAASAL.SelectedValue = VAR_NegaraAsal;
			TXT_JMLREK.Text = VAR_JumlahRekening;
			TXT_STATUSDEBITUR.Text = VAR_StatusDebitur;
			TXT_KTGR_DEBTR.Text = VAR_KategoriDebitur;
			TXT_KTGR_PORT.Text = VAR_KategoriPortofolio;
			DDL_JNSVALIND.SelectedValue = VAR_JenisValutaInduk;
			DDL_JNSVALFAL.SelectedValue = VAR_JenisValutaFasilitas;
			TXT_TGKNPOKOK.Text = VAR_TunggakanPokok;
			TXT_TGLTGKN.Text = VAR_TanggalTunggakan;
			TXT_FREKTGKPOKOK.Text = VAR_FrekTunggakanPokok;
			DDL_GOL_PENJAMIN.SelectedValue = VAR_GolonganPenjamin;
			TXT_BAGYGDIJMN.Text = VAR_BagianYangDijamin;
			DDL_KSEBI1.SelectedValue = VAR_KSEBI1;
			DDL_KSEBI2.SelectedValue = VAR_KSEBI2;
			DDL_KSEBI3.SelectedValue = VAR_KSEBI3;
			DDL_KSEBI4.SelectedValue = VAR_KSEBI4;
			TXT_TANGGAL_PKPERTAMA.Text = VAR_TanggalPKPertamaDay;
			DDL_BULAN_PKPERTAMA.SelectedValue = VAR_TanggalPKPertamaMonth;
			TXT_TAHUN_PKPERTAMA.Text = VAR_TanggalPKPertamaYear;
			TXT_NOPKPERTAMA.Text = VAR_NoPKPertama;
			TXT_TANGGAL_PKAKHIR.Text = VAR_TAnggalPKTerakhirDay;
			DDL_BULAN_PKAKHIR.SelectedValue = VAR_TAnggalPKTerakhirMonth;
			TXT_TANGGAL_PKAKHIR.Text = VAR_TAnggalPKTerakhirYear;
			TXT_NOPKTERAKHIR.Text = VAR_NoPKTerakhir;
			DDL_KOLEKTIBILITAS.SelectedValue = VAR_Kolektibilitas;

			RDO_PERHT_PPA.SelectedValue = VAR_PerhitunganPPA;
			RDO_OTOM_KOL.SelectedValue = VAR_OtomatisKolektibilitas;
			
			TXT_CTGRPENGUKURAN.Text = VAR_KategoriPengukuran;
			TXT_SUKBUNGINDUK.Text = VAR_TKSukuBungaInduk;
			TXT_SUKBUNGPERFAL.Text = VAR_TKSukuBungaPerfasilitas;
			DDL_JNS_SUKBUNG.SelectedValue = VAR_JenisSukuBunga;
			TXT_PLFINDUK.Text = VAR_PlafondInduk;
			TXT_PLAFOND.Text = VAR_Plafond;
			TXT_TGKNBNGEKSTRA.Text = VAR_TunggakanBungaEkstra;
			TXT_TGKNBUNGAINTRA.Text = VAR_TunggakanBungaIntra;
			TXT_FREKTGKNBNG.Text = VAR_FrekTunggakanBunga;
			
			RDO_ONEENTITY.SelectedValue = VAR_OneEntityFlag;
			RDO_RESTRUKTURISASI.SelectedValue = VAR_Restrukturisasi;
			
			DDL_JENISRESTRU.SelectedValue = VAR_JenisRestru;
			TXT_DD_RESTRUAWAL.Text = VAR_TglRestruAwalDay;
			DDL_MM_RESTRUAWAL.SelectedValue = VAR_TglRestruAwalMonth;
			TXT_YY_RESTRUAWAL.Text = VAR_TglRestruAwalYear;
			TXT_DD_RESTRUAKHIR.Text = VAR_TglRestruAkhirDay;
			DDL_MM_RESTRUAKHIR.SelectedValue = VAR_TglRestruAkhirMonth;
			TXT_YY_RESTRUAKHIR.Text = VAR_TglRestruAkhirYear;
			TXT_DD_RESTRUREVIEW.Text = VAR_TglReviewRestruDay;
			DDL_MM_RESTRUREVIEW.SelectedValue = VAR_TglReviewRestruMonth;
			TXT_YY_RESTRUREVIEW.Text = VAR_TglReviewRestruYear;
			TXT_RESTRUKE.Text = VAR_RestrukturisasiKe;
			DDL_KETRESTRU.SelectedValue = VAR_KetReskturkturisasi;
			DDL_SANDIKODEPOSISI.SelectedValue = VAR_SandiKodePosisi;
			TXT_DD_TGLPOSISI.Text = VAR_TglPosisiDay;
			DDL_MM_TGLPOSISI.SelectedValue = VAR_TglPosisiMonth;
			TXT_YY_TGLPOSISI.Text = VAR_TglPosisiYear;
			DDL_SEBABMACET.SelectedValue = VAR_SebabMacet;
			TXT_DD_TGLMACET.Text = VAR_TanggalMacetDay;
			DDL_MM_TGLMACET.SelectedValue = VAR_TanggalMacetMonth;
			TXT_YY_TGLMACET.Text = VAR_TanggalMacetYear;
			TXT_BAKIDEBET.Text = VAR_BakiDebet;
			RDO_COMMITTED.SelectedValue = VAR_Committed;
			RDO_UNCOMMITED.SelectedValue = VAR_Uncommitted;
			TXT_PDPTBUNGAYAD.Text = VAR_PenpdtBungaYAD;
			TXT_PDPTDITANGGUHKAN.Text = VAR_PendptDitangguhkan;
			
			RDO_INDIVIDUAL.SelectedValue = VAR_Individual;
			RDO_KOLEKTIF.SelectedValue = VAR_Kolektif;
			RDO_JNSPENGAJUAN.SelectedValue = VAR_JenisPengajuan;
		}
		
		private void CONTROL_to_VAR()
		{
			VAR_NomorRekening = TXT_NOMOR_REKENING.Text.ToString(); 
			VAR_LoanType = DDL_LOAN_TYPE.SelectedValue.ToString(); 
			VAR_SifatKredit = DDL_SIFAT_KREDIT.SelectedValue.ToString(); 
			VAR_JenisPenggunaan = DDL_JENIS_PENGGUNAAN.SelectedValue.ToString(); 
			VAR_OrientasiPenggunaan = DDL_ORIENTASI.SelectedValue.ToString(); 
			VAR_GolonganKredit = DDL_GOL_KREDIT.SelectedValue.ToString(); 
			VAR_JenisKredit = DDL_JENIS_KREDIT.SelectedValue.ToString(); 
			VAR_FasPenyediaanDana = DDL_FAS_DANA.SelectedValue.ToString(); 
			VAR_BankUtamaSindikasi = DDL_BANK_SINDIKASI.SelectedValue.ToString(); 
			VAR_LokasiProyek = DDL_LOKASI_PROYEK.SelectedValue.ToString(); 
			VAR_AlamatProyek = TXT_ALAMATPROJ.Text.ToString(); 
			VAR_NilaiProyek = DDL_NILAI_PROYEK.SelectedValue.ToString(); 
			VAR_NegaraAsal = DDL_NEGARAASAL.SelectedValue.ToString(); 
			VAR_JumlahRekening = TXT_JMLREK.Text.ToString(); 
			VAR_StatusDebitur = TXT_STATUSDEBITUR.Text.ToString(); 
			VAR_KategoriDebitur = TXT_KTGR_DEBTR.Text.ToString(); 
			VAR_KategoriPortofolio = TXT_KTGR_PORT.Text.ToString(); 
			VAR_JenisValutaInduk = DDL_JNSVALIND.SelectedValue.ToString(); 
			VAR_JenisValutaFasilitas = DDL_JNSVALFAL.SelectedValue.ToString(); 
			VAR_TunggakanPokok = TXT_TGKNPOKOK.Text.ToString(); 
			VAR_TanggalTunggakan = TXT_TGLTGKN.Text.ToString(); 
			VAR_FrekTunggakanPokok = TXT_FREKTGKPOKOK.Text.ToString(); 
			VAR_GolonganPenjamin = DDL_GOL_PENJAMIN.SelectedValue.ToString(); 
			VAR_BagianYangDijamin = TXT_BAGYGDIJMN.Text.ToString(); 
			VAR_KSEBI1 = DDL_KSEBI1.SelectedValue.ToString(); 
			VAR_KSEBI2 = DDL_KSEBI2.SelectedValue.ToString(); 
			VAR_KSEBI3 = DDL_KSEBI3.SelectedValue.ToString(); 
			VAR_KSEBI4 = DDL_KSEBI4.SelectedValue.ToString(); 
			VAR_TanggalPKPertamaDay = TXT_TANGGAL_PKPERTAMA.Text.ToString(); 
			VAR_TanggalPKPertamaMonth = DDL_BULAN_PKPERTAMA.SelectedValue.ToString(); 
			VAR_TanggalPKPertamaYear = TXT_TAHUN_PKPERTAMA.Text.ToString(); 
			VAR_NoPKPertama = TXT_NOPKPERTAMA.Text.ToString(); 
			VAR_TAnggalPKTerakhirDay = TXT_TANGGAL_PKAKHIR.Text.ToString(); 
			VAR_TAnggalPKTerakhirMonth = DDL_BULAN_PKAKHIR.SelectedValue.ToString(); 
			VAR_TAnggalPKTerakhirYear = TXT_TANGGAL_PKAKHIR.Text.ToString(); 
			VAR_NoPKTerakhir = TXT_NOPKTERAKHIR.Text.ToString(); 
			VAR_Kolektibilitas = DDL_KOLEKTIBILITAS.SelectedValue.ToString(); 
			VAR_PerhitunganPPA = RDO_PERHT_PPA.SelectedValue.ToString(); 
			VAR_OtomatisKolektibilitas = RDO_OTOM_KOL.SelectedValue.ToString(); 
			VAR_KategoriPengukuran = TXT_CTGRPENGUKURAN.Text.ToString(); 
			VAR_TKSukuBungaInduk = TXT_SUKBUNGINDUK.Text.ToString(); 
			VAR_TKSukuBungaPerfasilitas = TXT_SUKBUNGPERFAL.Text.ToString(); 
			VAR_JenisSukuBunga = DDL_JNS_SUKBUNG.SelectedValue.ToString(); 
			VAR_PlafondInduk = TXT_PLFINDUK.Text.ToString(); 
			VAR_Plafond = TXT_PLAFOND.Text.ToString(); 
			VAR_TunggakanBungaEkstra = TXT_TGKNBNGEKSTRA.Text.ToString(); 
			VAR_TunggakanBungaIntra = TXT_TGKNBUNGAINTRA.Text.ToString(); 
			VAR_FrekTunggakanBunga = TXT_FREKTGKNBNG.Text.ToString(); 
			VAR_OneEntityFlag = RDO_ONEENTITY.SelectedValue.ToString(); 
			VAR_Restrukturisasi = RDO_RESTRUKTURISASI.SelectedValue.ToString(); 
			VAR_JenisRestru = DDL_JENISRESTRU.SelectedValue.ToString(); 
			VAR_TglRestruAwalDay = TXT_DD_RESTRUAWAL.Text.ToString(); 
			VAR_TglRestruAwalMonth = DDL_MM_RESTRUAWAL.SelectedValue.ToString(); 
			VAR_TglRestruAwalYear = TXT_YY_RESTRUAWAL.Text.ToString(); 
			VAR_TglRestruAkhirDay = TXT_DD_RESTRUAKHIR.Text.ToString(); 
			VAR_TglRestruAkhirMonth = DDL_MM_RESTRUAKHIR.SelectedValue.ToString(); 
			VAR_TglRestruAkhirYear = TXT_YY_RESTRUAKHIR.Text.ToString(); 
			VAR_TglReviewRestruDay = TXT_DD_RESTRUREVIEW.Text.ToString(); 
			VAR_TglReviewRestruMonth = DDL_MM_RESTRUREVIEW.SelectedValue.ToString(); 
			VAR_TglReviewRestruYear = TXT_YY_RESTRUREVIEW.Text.ToString(); 
			VAR_RestrukturisasiKe = TXT_RESTRUKE.Text.ToString(); 
			VAR_KetReskturkturisasi = DDL_KETRESTRU.SelectedValue.ToString(); 
			VAR_SandiKodePosisi = DDL_SANDIKODEPOSISI.SelectedValue.ToString(); 
			VAR_TglPosisiDay = TXT_DD_TGLPOSISI.Text.ToString(); 
			VAR_TglPosisiMonth = DDL_MM_TGLPOSISI.SelectedValue.ToString(); 
			VAR_TglPosisiYear = TXT_YY_TGLPOSISI.Text.ToString(); 
			VAR_SebabMacet = DDL_SEBABMACET.SelectedValue.ToString(); 
			VAR_TanggalMacetDay = TXT_DD_TGLMACET.Text.ToString(); 
			VAR_TanggalMacetMonth = DDL_MM_TGLMACET.SelectedValue.ToString(); 
			VAR_TanggalMacetYear = TXT_YY_TGLMACET.Text.ToString(); 
			VAR_BakiDebet = TXT_BAKIDEBET.Text.ToString(); 
			VAR_Committed = RDO_COMMITTED.SelectedValue.ToString(); 
			VAR_Uncommitted = RDO_UNCOMMITED.SelectedValue.ToString(); 
			VAR_PenpdtBungaYAD = TXT_PDPTBUNGAYAD.Text.ToString(); 
			VAR_PendptDitangguhkan = TXT_PDPTDITANGGUHKAN.Text.ToString(); 
			VAR_Individual = RDO_INDIVIDUAL.SelectedValue.ToString(); 
			VAR_Kolektif = RDO_KOLEKTIF.SelectedValue.ToString(); 
			VAR_JenisPengajuan = RDO_JNSPENGAJUAN.SelectedValue.ToString(); 
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("CAPCompletenessList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}
	}
}
