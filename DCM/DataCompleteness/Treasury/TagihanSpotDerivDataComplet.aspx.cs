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

namespace SME.DCM.DataCompleteness.Treasury
{
	/// <summary>
	/// Summary description for AccountDataComplet.
	/// </summary>
	public partial class TagihanSpotDerivDataComplet : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TXT_BAKIDEBET;
		protected System.Web.UI.WebControls.Label LBL_TXT_BAKIDEBET;
		protected System.Web.UI.WebControls.RadioButtonList RDO_COMMITTED;
		protected System.Web.UI.WebControls.RadioButtonList RDO_UNCOMMITED;
		protected System.Web.UI.WebControls.Label LBL_RDO_COMMITTED;
		protected System.Web.UI.WebControls.Label LBL_RDO_UNCOMMITED;
		protected System.Web.UI.WebControls.TextBox TXT_PDPTBUNGAYAD;
		protected System.Web.UI.WebControls.TextBox TXT_PDPTDITANGGUHKAN;
		protected System.Web.UI.WebControls.Label LBL_TXT_PDPTBUNGAYAD;
		protected System.Web.UI.WebControls.Label LBL_TXT_PDPTDITANGGUHKAN;
		protected System.Web.UI.WebControls.RadioButtonList RDO_INDIVIDUAL;
		protected System.Web.UI.WebControls.RadioButtonList RDO_KOLEKTIF;
		protected System.Web.UI.WebControls.RadioButtonList RDO_JNSPENGAJUAN;
		protected System.Web.UI.WebControls.Label LBL_RDO_INDIVIDUAL;
		protected System.Web.UI.WebControls.Label LBL_RDO_KOLEKTIF;
		protected System.Web.UI.WebControls.Label LBL_RDO_JNSPENGAJUAN;
		protected Tools tools = new Tools();
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn3 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);

		private string VAR_CIF;
		private string VAR_CustomerName;
		private string VAR_NomorTransaksiRekening;
		private string VAR_Jenis;
		private string VAR_TglDikeluarkanDay;
		private string VAR_TglDikeluarkanMonth;
		private string VAR_TglDikeluarkanYear;
		private string VAR_TglJatuhTempoDay;
		private string VAR_TglJatuhTempoMonth;
		private string VAR_TglJatuhTempoYear;
		private string VAR_Tujuan;
		private string VAR_JenisValuta;
		private string VAR_NilaiKontrakCurrAsal;
		private string VAR_Kurs;
		private string VAR_NilaiKontrak;
		private string VAR_NilaiTagihan;
		private string VAR_PenerbitCounterparty;
		private string VAR_VariableYangMendasari;
		private string VAR_GolonganPihakLawan;
		private string VAR_HubunganDenganBank;
		private string VAR_StatusPihakLawan;
		private string VAR_LembagaPemeringkat;
		private string VAR_PeringkatPihakLawan;
		private string VAR_TglPemeringkatanDay;
		private string VAR_TglPemeringkatanMonth;
		private string VAR_TglPemeringkatanYear;
		private string VAR_NegaraPihakLawan;
		private string VAR_Kualitas;
		private string VAR_SecaraIndividual;
		private string VAR_SecaraKolektif;
		private string VAR_SifatAgunanJaminan;
		private string VAR_JenisAgunanJaminan;
		private string VAR_JenisValutaAgunan;
		private string VAR_JWMulaiDay;
		private string VAR_JWMulaiYear;
		private string VAR_JWMulaiMonth;
		private string VAR_JWJatuhTempoDay;
		private string VAR_JWJatuhTempoMonth;
		private string VAR_JWJatuhTempoYear;
		private string VAR_NilaiAgunan;
		private string VAR_TglPenilaianTerakhirDay;
		private string VAR_TglPenilaianTerakhirMonth;
		private string VAR_TglPenilaianTerakhirYear;
		private string VAR_PenerbitAgunan;
		private string VAR_PeringkatAgunan;
		private string VAR_TglPemeringkatanAgunanDay;
		private string VAR_TglPemeringkatanAgunanMonth;
		private string VAR_TglPemeringkatanAgunanYear;
		private string VAR_NilaiAgunanYgDapatDiperhitungkan;
		private string VAR_Kolektibilitas;
		private string VAR_TanggalMacetDay;
		private string VAR_TanggalMacetMonth;
		private string VAR_TanggalMacetyear;
		private string VAR_TunggakanPokok;
		private string VAR_TanggalTunggakanDay;
		private string VAR_TanggalTunggakanMonth;
		private string VAR_TanggalTunggakanYear;
		private string VAR_SebabMacet;
		private string VAR_Kondisi;
		private string VAR_TanggalKondisiDay;
		private string VAR_TanggalKondisiMonth;
		private string VAR_TanggalKondisiYear;
		private string VAR_PPAPYangDiBentuk;

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

				conn3.QueryString = "SELECT IDCONTROL FROM DCM_TABLE_ERROR WHERE PAGE = 'TagihanSpotDerivDataComplet.aspx' AND MESSAGE = '" + err_msg.Trim() + "'";
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
			VAR_NomorTransaksiRekening = "";
			VAR_Jenis = "";
			VAR_TglDikeluarkanDay = "";
			VAR_TglDikeluarkanMonth = "";
			VAR_TglDikeluarkanYear = "";
			VAR_TglJatuhTempoDay = "";
			VAR_TglJatuhTempoMonth = "";
			VAR_TglJatuhTempoYear = "";
			VAR_Tujuan = "";
			VAR_JenisValuta = "";
			VAR_NilaiKontrakCurrAsal = "";
			VAR_Kurs = "";
			VAR_NilaiKontrak = "";
			VAR_NilaiTagihan = "";
			VAR_PenerbitCounterparty = "";
			VAR_VariableYangMendasari = "";
			VAR_GolonganPihakLawan = "";
			VAR_HubunganDenganBank = "";
			VAR_StatusPihakLawan = "";
			VAR_LembagaPemeringkat = "";
			VAR_PeringkatPihakLawan = "";
			VAR_TglPemeringkatanDay = "";
			VAR_TglPemeringkatanMonth = "";
			VAR_TglPemeringkatanYear = "";
			VAR_NegaraPihakLawan = "";
			VAR_Kualitas = "";
			VAR_SecaraIndividual = null;
			VAR_SecaraKolektif = null;
			VAR_SifatAgunanJaminan = "";
			VAR_JenisAgunanJaminan = "";
			VAR_JenisValutaAgunan = "";
			VAR_JWMulaiDay = "";
			VAR_JWMulaiYear = "";
			VAR_JWMulaiMonth = "";
			VAR_JWJatuhTempoDay = "";
			VAR_JWJatuhTempoMonth = "";
			VAR_JWJatuhTempoYear = "";
			VAR_NilaiAgunan = "";
			VAR_TglPenilaianTerakhirDay = "";
			VAR_TglPenilaianTerakhirMonth = "";
			VAR_TglPenilaianTerakhirYear = "";
			VAR_PenerbitAgunan = "";
			VAR_LembagaPemeringkat = "";
			VAR_PeringkatAgunan = "";
			VAR_TglPemeringkatanAgunanDay = "";
			VAR_TglPemeringkatanAgunanMonth = "";
			VAR_TglPemeringkatanAgunanYear = "";
			VAR_NilaiAgunanYgDapatDiperhitungkan = "";
			VAR_Kolektibilitas = "";
			VAR_TanggalMacetDay = "";
			VAR_TanggalMacetMonth = "";
			VAR_TanggalMacetyear = "";
			VAR_TunggakanPokok = "";
			VAR_TanggalTunggakanDay = "";
			VAR_TanggalTunggakanMonth = "";
			VAR_TanggalTunggakanYear = "";
			VAR_SebabMacet = "";
			VAR_Kondisi = "";
			VAR_TanggalKondisiDay = "";
			VAR_TanggalKondisiMonth = "";
			VAR_TanggalKondisiYear = "";
			VAR_PPAPYangDiBentuk = "";
		}

		private void AllDropDownListInitiation()
		{
			ListItem a = new ListItem("- SELECT -", "");
		
			DDL_GOL_PHK_LAWAN.Items.Add(a);
			DDL_HUBBANK.Items.Add(a);
			DDL_JENIS.Items.Add(a);
			DDL_JENISVALUTA.Items.Add(a);
			DDL_JNSAGUNAN.Items.Add(a);
			DDL_JNSVALUTA.Items.Add(a);
			DDL_KONDISI.Items.Add(a);
			DDL_LBG_PMRKT.Items.Add(a);
			DDL_MM_JWJTHTEMPO.Items.Add(a);
			DDL_MM_JWMULAI.Items.Add(a);
			DDL_MM_PMRKTAGN.Items.Add(a);
			DDL_MM_TGLDIKELUARKAN.Items.Add(a);
			DDL_MM_TGLJTHTEMPO.Items.Add(a);
			DDL_MM_TGLKONDISI.Items.Add(a);
			DDL_MM_TGLMACET.Items.Add(a);
			DDL_MM_TGLPMRKT.Items.Add(a);
			DDL_MM_TGLPNLNTRKHR.Items.Add(a);
			DDL_MM_TGLTUNGGAKAN.Items.Add(a);
			DDL_NRGPHKLWN.Items.Add(a);
			DDL_PRKTPHKLWN.Items.Add(a);
			DDL_SEBABMACET.Items.Add(a);
			DDL_SIFATAGUNAN.Items.Add(a);
			DDL_STSPHKLAWAN.Items.Add(a);
			DDL_TUJUAN.Items.Add(a);
			DDL_VARDASAR.Items.Add(a);
		}

		private void CONTROL_to_VAR()
		{
			VAR_CIF = TXT_CIF.Text.ToString();
			VAR_CustomerName = TXT_CUSTNAME.Text.ToString();
			VAR_NomorTransaksiRekening = TXT_NO_TRANSAKSI.Text.ToString();
			VAR_Jenis = DDL_JENIS.SelectedValue.ToString();
			VAR_TglDikeluarkanDay = TXT_DD_TGLDIKELUARKAN.Text.ToString();
			VAR_TglDikeluarkanMonth = DDL_MM_TGLDIKELUARKAN.SelectedValue.ToString();
			VAR_TglDikeluarkanYear = TXT_YY_TGLDIKELUARKAN.Text.ToString();
			VAR_TglJatuhTempoDay = TXT_DD_TGLJTHTEMPO.Text.ToString();
			VAR_TglJatuhTempoMonth = DDL_MM_TGLJTHTEMPO.SelectedValue.ToString();
			VAR_TglJatuhTempoYear = TXT_YY_TGLJTHTEMPO.Text.ToString();
			VAR_Tujuan = DDL_TUJUAN.SelectedValue.ToString();
			VAR_JenisValuta = DDL_JENISVALUTA.SelectedValue.ToString();
			VAR_NilaiKontrakCurrAsal = TXT_NIKRON_KURSASAL.Text.ToString();
			VAR_Kurs = TXT_KURS.Text.ToString();
			VAR_NilaiKontrak = TXT_NIKRON_RP.Text.ToString();
			VAR_NilaiTagihan = TXT_NILAI_TAGIHAN.Text.ToString();
			VAR_PenerbitCounterparty = TXT_COUNTERPART.Text.ToString();
			VAR_VariableYangMendasari = DDL_VARDASAR.SelectedValue.ToString();
			VAR_GolonganPihakLawan = DDL_GOL_PHK_LAWAN.SelectedValue.ToString();
			VAR_HubunganDenganBank = DDL_HUBBANK.SelectedValue.ToString();
			VAR_StatusPihakLawan = DDL_STSPHKLAWAN.SelectedValue.ToString();
			VAR_LembagaPemeringkat = DDL_LBG_PMRKT.SelectedValue.ToString();
			VAR_PeringkatPihakLawan = DDL_PRKTPHKLWN.SelectedValue.ToString();
			VAR_TglPemeringkatanDay = TXT_DD_TGLPMRKT.Text.ToString();
			VAR_TglPemeringkatanMonth = DDL_MM_TGLPMRKT.SelectedValue.ToString();
			VAR_TglPemeringkatanYear = TXT_YY_TGLPMRKT.Text.ToString();
			VAR_NegaraPihakLawan = DDL_NRGPHKLWN.SelectedValue.ToString();
			VAR_Kualitas = TXT_KUALITAS.Text.ToString();
			VAR_SecaraIndividual = RDO_SCR_INDIVIDUAL.SelectedValue.ToString();
			VAR_SecaraKolektif = RDO_SCR_KOLEKTIF.SelectedValue.ToString();
			VAR_SifatAgunanJaminan = DDL_SIFATAGUNAN.SelectedValue.ToString();
			VAR_JenisAgunanJaminan = DDL_JNSAGUNAN.SelectedValue.ToString();
			VAR_JenisValutaAgunan = DDL_JNSVALUTA.SelectedValue.ToString();
			VAR_JWMulaiDay = TXT_DD_JWMULAI.Text.ToString(); 
			VAR_JWMulaiYear = DDL_MM_JWMULAI.SelectedValue.ToString();
			VAR_JWMulaiMonth = TXT_YY_JWMULAI.Text.ToString();
			VAR_JWJatuhTempoDay = TXT_DD_JWJTHTEMPO.Text.ToString();
			VAR_JWJatuhTempoMonth = DDL_MM_JWJTHTEMPO.SelectedValue.ToString();
			VAR_JWJatuhTempoYear = TXT_YY_JWJTHTEMPO.Text.ToString();
			VAR_NilaiAgunan = TXT_NILAIAGUNAN.Text.ToString();
			VAR_TglPenilaianTerakhirDay = TXT_DD_TGLPNLNTRKHR.Text.ToString();
			VAR_TglPenilaianTerakhirMonth = DDL_MM_TGLPNLNTRKHR.SelectedValue.ToString();
			VAR_TglPenilaianTerakhirYear = TXT_YY_TGLPNLNTRKHR.Text.ToString();
			VAR_PenerbitAgunan = TXT_PNRBTAGUNAN.Text.ToString();
			VAR_LembagaPemeringkat = TXT_LBGPMRKT.Text.ToString();
			VAR_PeringkatAgunan = TXT_PRKTAGUNAN.Text.ToString();
			VAR_TglPemeringkatanAgunanDay = TXT_DD_TGLPMRKT.Text.ToString();
			VAR_TglPemeringkatanAgunanMonth = DDL_MM_TGLPMRKT.SelectedValue.ToString();
			VAR_TglPemeringkatanAgunanYear = TXT_YY_TGLPMRKT.Text.ToString();
			VAR_NilaiAgunanYgDapatDiperhitungkan = TXT_NILAIAGUNAN.Text.ToString();
			VAR_Kolektibilitas = TXT_KOLEKTIBILITAS.Text.ToString();
			VAR_TanggalMacetDay = TXT_DD_TGLMACET.Text.ToString();
			VAR_TanggalMacetMonth = DDL_MM_TGLMACET.SelectedValue.ToString();
			VAR_TanggalMacetyear = TXT_YY_TGLMACET.Text.ToString();
			VAR_TunggakanPokok = TXT_TUNGGAKANPOKOK.Text.ToString();
			VAR_TanggalTunggakanDay = TXT_DD_TGLTUNGGAKAN.Text.ToString();
			VAR_TanggalTunggakanMonth = DDL_MM_TGLTUNGGAKAN.SelectedValue.ToString();
			VAR_TanggalTunggakanYear = TXT_YY_TGLTUNGGAKAN.Text.ToString();
			VAR_SebabMacet = DDL_SEBABMACET.SelectedValue.ToString();
			VAR_Kondisi = DDL_KONDISI.SelectedValue.ToString();
			VAR_TanggalKondisiDay = TXT_DD_TGLKONDISI.Text.ToString();
			VAR_TanggalKondisiMonth = DDL_MM_TGLKONDISI.SelectedValue.ToString();
			VAR_TanggalKondisiYear = TXT_YY_TGLKONDISI.Text.ToString();
			VAR_PPAPYangDiBentuk = TXT_PPAPYGDBNTK.Text.ToString();
		}

		private void VAR_to_CONTROL()
		{
			TXT_CIF.Text = VAR_CIF;
			TXT_CUSTNAME.Text = VAR_CustomerName;
			TXT_NO_TRANSAKSI.Text = VAR_NomorTransaksiRekening;
			DDL_JENIS.SelectedValue = VAR_Jenis;
			TXT_DD_TGLDIKELUARKAN.Text = VAR_TglDikeluarkanDay;
			DDL_MM_TGLDIKELUARKAN.SelectedValue = VAR_TglDikeluarkanMonth;
			TXT_YY_TGLDIKELUARKAN.Text = VAR_TglDikeluarkanYear;
			TXT_DD_TGLJTHTEMPO.Text = VAR_TglJatuhTempoDay;
			DDL_MM_TGLJTHTEMPO.SelectedValue = VAR_TglJatuhTempoMonth;
			TXT_YY_TGLJTHTEMPO.Text = VAR_TglJatuhTempoYear;
			DDL_TUJUAN.SelectedValue = VAR_Tujuan;
			DDL_JENISVALUTA.SelectedValue = VAR_JenisValuta;
			TXT_NIKRON_KURSASAL.Text = VAR_NilaiKontrakCurrAsal;
			TXT_KURS.Text = VAR_Kurs;
			TXT_NIKRON_RP.Text = VAR_NilaiKontrak;
			TXT_NILAI_TAGIHAN.Text = VAR_NilaiTagihan;
			TXT_COUNTERPART.Text = VAR_PenerbitCounterparty;
			DDL_VARDASAR.SelectedValue = VAR_VariableYangMendasari;
			DDL_GOL_PHK_LAWAN.SelectedValue = VAR_GolonganPihakLawan;
			DDL_HUBBANK.SelectedValue = VAR_HubunganDenganBank;
			DDL_STSPHKLAWAN.SelectedValue = VAR_StatusPihakLawan;
			DDL_LBG_PMRKT.SelectedValue = VAR_LembagaPemeringkat;
			DDL_PRKTPHKLWN.SelectedValue = VAR_PeringkatPihakLawan;
			TXT_DD_TGLPMRKT.Text = VAR_TglPemeringkatanDay;
			DDL_MM_TGLPMRKT.SelectedValue = VAR_TglPemeringkatanMonth;
			TXT_YY_TGLPMRKT.Text = VAR_TglPemeringkatanYear;
			DDL_NRGPHKLWN.SelectedValue = VAR_NegaraPihakLawan;
			TXT_KUALITAS.Text = VAR_Kualitas;
			RDO_SCR_INDIVIDUAL.SelectedValue = VAR_SecaraIndividual;
			RDO_SCR_KOLEKTIF.SelectedValue = VAR_SecaraKolektif;
			DDL_SIFATAGUNAN.SelectedValue = VAR_SifatAgunanJaminan;
			DDL_JNSAGUNAN.SelectedValue = VAR_JenisAgunanJaminan;
			DDL_JNSVALUTA.SelectedValue = VAR_JenisValutaAgunan;
			TXT_DD_JWMULAI.Text = VAR_JWMulaiDay;
			DDL_MM_JWMULAI.SelectedValue = VAR_JWMulaiYear;
			TXT_YY_JWMULAI.Text = VAR_JWMulaiMonth;
			TXT_DD_JWJTHTEMPO.Text = VAR_JWJatuhTempoDay;
			DDL_MM_JWJTHTEMPO.SelectedValue = VAR_JWJatuhTempoMonth;
			TXT_YY_JWJTHTEMPO.Text = VAR_JWJatuhTempoYear;
			TXT_NILAIAGUNAN.Text = VAR_NilaiAgunan;
			TXT_DD_TGLPNLNTRKHR.Text = VAR_TglPenilaianTerakhirDay;
			DDL_MM_TGLPNLNTRKHR.SelectedValue = VAR_TglPenilaianTerakhirMonth;
			TXT_YY_TGLPNLNTRKHR.Text = VAR_TglPenilaianTerakhirYear;
			TXT_PNRBTAGUNAN.Text = VAR_PenerbitAgunan;
			TXT_LBGPMRKT.Text = VAR_LembagaPemeringkat;
			TXT_PRKTAGUNAN.Text = VAR_PeringkatAgunan;
			TXT_DD_TGLPMRKT.Text = VAR_TglPemeringkatanAgunanDay;
			DDL_MM_TGLPMRKT.SelectedValue = VAR_TglPemeringkatanAgunanMonth;
			TXT_YY_TGLPMRKT.Text = VAR_TglPemeringkatanAgunanYear;
			TXT_NILAIAGUNAN.Text = VAR_NilaiAgunanYgDapatDiperhitungkan;
			TXT_KOLEKTIBILITAS.Text = VAR_Kolektibilitas;
			TXT_DD_TGLMACET.Text = VAR_TanggalMacetDay;
			DDL_MM_TGLMACET.SelectedValue = VAR_TanggalMacetMonth;
			TXT_YY_TGLMACET.Text = VAR_TanggalMacetyear;
			TXT_TUNGGAKANPOKOK.Text = VAR_TunggakanPokok;
			TXT_DD_TGLTUNGGAKAN.Text = VAR_TanggalTunggakanDay;
			DDL_MM_TGLTUNGGAKAN.SelectedValue = VAR_TanggalTunggakanMonth =
			TXT_YY_TGLTUNGGAKAN.Text = VAR_TanggalTunggakanYear;
			DDL_SEBABMACET.SelectedValue = VAR_SebabMacet;
			DDL_KONDISI.SelectedValue = VAR_Kondisi;
			TXT_DD_TGLKONDISI.Text = VAR_TanggalKondisiDay;
			DDL_MM_TGLKONDISI.SelectedValue = VAR_TanggalKondisiMonth;
			TXT_YY_TGLKONDISI.Text = VAR_TanggalKondisiYear;
			TXT_PPAPYGDBNTK.Text = VAR_PPAPYangDiBentuk;
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("TreasuryDataCompleteList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}
	}
}
