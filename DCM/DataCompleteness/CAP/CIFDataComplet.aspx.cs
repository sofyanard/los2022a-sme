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
	/// Summary description for CIFDataComplet.
	/// </summary>
	public partial class CIFDataComplet : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn3 = new Connection(ConfigurationSettings.AppSettings["conn2"]);

		/*Deklarasi variable penampung*/
		private string VAR_CIFNo;
		private string VAR_CustomerName;
		private string VAR_JenisNasabah;
		private string VAR_BUC;
		private string VAR_PICDataOwner;
		private string VAR_NamaNasabahPelaporan;
		private string VAR_TglLahirTglBerdiriPerusahaanDay;
		private string VAR_TglLahirTglBerdiriPerusahaanMonth;
		private string VAR_TglLahirTglBerdiriPerusahaanYear;
		private string VAR_TempatLahirAktaDikeluarkan;
		private string VAR_JenisIDUtama;
		private string VAR_NoIDUtama;
		private string VAR_TglKadaluarsaIDUtamaDay;
		private string VAR_TglKadaluarsaIDUtamaMonth;
		private string VAR_TglKadaluarsaIDUtamaYear;
		private string VAR_GolonganNasabah;
		private string VAR_JenisDebitur;
		private string VAR_HubunganDenganBank;
		private string VAR_AlamatNasabah;
		private string VAR_Kecamatan;
		private string VAR_KodePose;
		private string VAR_LokasiDatiII;
		private string VAR_NomorTelpRumahKantorHP;
		private string VAR_NomorTelpRumahKantorHPSelected;
		private string VAR_Valuta;
		private string VAR_NoAPP;
		private string VAR_TanggalAkteAPPDay;
		private string VAR_TanggalAkteAPPMonth;
		private string VAR_TanggalAkteAPPYear;
		private string VAR_NoAPT;
		private string VAR_TanggalAPTDay;
		private string VAR_TanggalAPTMonth;
		private string VAR_TanggalAPTYear;
		private string VAR_PendapatanOperasional;
		private string VAR_PendapatanNonOperasional;
		private string VAR_LembagaPemeringkat;
		private string VAR_PeringkatPerusahaan;
		private string VAR_TanggalPemeringkatanTanggal;
		private string VAR_TanggalPemeringkatanMonth;
		private string VAR_TanggalPemeringkatanYear;
		private string VAR_BentukBadanUsaha;
		private string VAR_JenisKelamin;
		private string VAR_NamaGadisIbuKandung;
		private string VAR_NamaPrefik;
		private string VAR_NamaPerushNasabahBekerja;
		private string VAR_BidangUsahaNasabah;
		private string VAR_JabatanNasabah;
		private string VAR_PekerjaanNasabah;
		private string VAR_Gaji;
		private string VAR_PendapatanUtama;
		private string VAR_PendapatanLainnya;
		private string VAR_Kewarganegaraan;
		private string VAR_StatusPerkawinan;

		/*Deklarasi variable penampung data pengurus*/
		private string VAR_CIFNoPengurus;
		private string VAR_NamaPengurus;
		private string VAR_JenisNasabahPengurus;
		private string VAR_BODBerdiriSejakDate;
		private string VAR_BODBerdiriSejakMonth;
		private string VAR_BODBerdiriSejakYear;
		private string VAR_JenisKelaminPengurus;
		private string VAR_ShareSaham;
		private string VAR_JenisIDUtamaPengurus;
		private string VAR_NoIDUtamaPengurus;
		private string VAR_ExpiredDateIDUtamaDay;
		private string VAR_ExpiredDateIDUtamaMonth;
		private string VAR_ExpiredDateIDUtamaYear;
		private string VAR_Alamat;
		private string VAR_KodePos;
		private string VAR_BUCPengurus;
		private string VAR_KodeHubungan;
		private string VAR_RemoveLink;

		/*Deklarasi varibale penampung data keuangan*/
		private string VAR_PosisiLaporanKeuanganDay;
		private string VAR_PosisiLaporanKeuanganMonth;
		private string VAR_PosisiLaporanKeuanganYear;
		private string VAR_PinjamanLuarNegeri;
		private string VAR_Denominasi;
		private string VAR_AuditedUnAudited;
		private string VAR_Currency;
		private string VAR_JumlahBulan;
		private string VAR_AktivaLancar;
		private string VAR_TotalAktiva;
		private string VAR_KewajibanKepadaBank;
		private string VAR_KewajibanLancar;
		private string VAR_TotalKewajiban;
		private string VAR_Modal;
		private string VAR_Penjualan;
		private string VAR_PendapatanOperasionalDataKeuangan;
		private string VAR_BiayaOperasional;
		private string VAR_PendapatanNonOperasionalDataKeuangan;
		private string VAR_BiayaNonOperasional;
		private string VAR_LabaRugiTahunLaluSetelahPajak;
		private string VAR_LabaRugiTahunLaluSebelumPajak;
	
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

				conn3.QueryString = "SELECT IDCONTROL FROM DCM_TABLE_ERROR WHERE PAGE = 'CIFDataComplet.aspx' AND MESSAGE = '" + err_msg.Trim() + "'";
				conn3.ExecuteQuery();

				if (conn3.GetFieldValue("IDCONTROL") != "")
				{
					id = "LBL_" + conn3.GetFieldValue("IDCONTROL");
					((Label)this.Page.FindControl(id)).ForeColor = Color.Red;
				}
			}
		}

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
			/*Deklarasi variable penampung*/
			VAR_CIFNo = "";
			VAR_CustomerName = "";
			VAR_JenisNasabah = null;
			VAR_BUC = "";
			VAR_PICDataOwner = "";
			VAR_NamaNasabahPelaporan = "";
			VAR_TglLahirTglBerdiriPerusahaanDay = "";
			VAR_TglLahirTglBerdiriPerusahaanMonth = "";
			VAR_TglLahirTglBerdiriPerusahaanYear = "";
			VAR_TempatLahirAktaDikeluarkan = "";
			VAR_JenisIDUtama = "";
			VAR_NoIDUtama = "";
			VAR_TglKadaluarsaIDUtamaDay = "";
			VAR_TglKadaluarsaIDUtamaMonth = "";
			VAR_TglKadaluarsaIDUtamaYear = "";
			VAR_GolonganNasabah = "";
			VAR_JenisDebitur = "";
			VAR_HubunganDenganBank = "";
			VAR_AlamatNasabah = "";
			VAR_Kecamatan = "";
			VAR_KodePose = "";
			VAR_LokasiDatiII = "";
			VAR_NomorTelpRumahKantorHP = "";
			VAR_NomorTelpRumahKantorHPSelected = null;
			VAR_Valuta = "";
			VAR_NoAPP = "";
			VAR_TanggalAkteAPPDay = "";
			VAR_TanggalAkteAPPMonth = "";
			VAR_TanggalAkteAPPYear = "";
			VAR_NoAPT = "";
			VAR_TanggalAPTDay = "";
			VAR_TanggalAPTMonth = "";
			VAR_TanggalAPTYear = "";
			VAR_PendapatanOperasional = "";
			VAR_PendapatanNonOperasional = "";
			VAR_LembagaPemeringkat = "";
			VAR_PeringkatPerusahaan = "";
			VAR_TanggalPemeringkatanTanggal = "";
			VAR_TanggalPemeringkatanMonth = "";
			VAR_TanggalPemeringkatanYear = "";
			VAR_BentukBadanUsaha = "";
			VAR_JenisKelamin = "";
			VAR_NamaGadisIbuKandung = "";
			VAR_NamaPrefik = "";
			VAR_NamaPerushNasabahBekerja = "";
			VAR_BidangUsahaNasabah = "";
			VAR_JabatanNasabah = "";
			VAR_PekerjaanNasabah = "";
			VAR_Gaji = "";
			VAR_PendapatanUtama = "";
			VAR_PendapatanLainnya = "";
			VAR_Kewarganegaraan = "";
			VAR_StatusPerkawinan = "";

			/*Deklarasi variable penampung data pengurus*/
			VAR_CIFNoPengurus = "";
			VAR_NamaPengurus = "";
			VAR_JenisNasabahPengurus = null;
			VAR_BODBerdiriSejakDate = "";
			VAR_BODBerdiriSejakMonth = "";
			VAR_BODBerdiriSejakYear = "";
			VAR_JenisKelaminPengurus = "";
			VAR_ShareSaham = "";
			VAR_JenisIDUtamaPengurus = "";
			VAR_NoIDUtamaPengurus = "";
			VAR_ExpiredDateIDUtamaDay = "";
			VAR_ExpiredDateIDUtamaMonth = "";
			VAR_ExpiredDateIDUtamaYear = "";
			VAR_Alamat = "";
			VAR_KodePos = "";
			VAR_BUCPengurus = "";
			VAR_KodeHubungan = "";
			VAR_RemoveLink = "false";

			/*Deklarasi varibale penampung data keuangan*/
			VAR_PosisiLaporanKeuanganDay = "";
			VAR_PosisiLaporanKeuanganMonth = "";
			VAR_PosisiLaporanKeuanganYear = "";
			VAR_PinjamanLuarNegeri = null;
			VAR_Denominasi = "";
			VAR_AuditedUnAudited = "";
			VAR_Currency = "";
			VAR_JumlahBulan = "";
			VAR_AktivaLancar = "";
			VAR_TotalAktiva = "";
			VAR_KewajibanKepadaBank = "";
			VAR_KewajibanLancar = "";
			VAR_TotalKewajiban = "";
			VAR_Modal = "";
			VAR_Penjualan = "";
			VAR_PendapatanOperasionalDataKeuangan = "";
			VAR_BiayaOperasional = "";
			VAR_PendapatanNonOperasionalDataKeuangan = "";
			VAR_BiayaNonOperasional = "";
			VAR_LabaRugiTahunLaluSetelahPajak = "";
			VAR_LabaRugiTahunLaluSebelumPajak = "";
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

		private void AllDropDownListInitiation()
		{
			ListItem a = new ListItem("- SELECT -", "");

			DDL_AUDITED.Items.Add(a);
			DDL_BLN_COMP.Items.Add(a);
			DDL_BLN_EXP.Items.Add(a);
			DDL_BLN_LAP.Items.Add(a);
			DDL_BUC.Items.Add(a);
			DDL_CIF_APP_DATE_MM.Items.Add(a);
			DDL_CIF_APT_DATE_MM.Items.Add(a);
			DDL_CIF_BIDANG_USAHA.Items.Add(a);
			DDL_CIF_BOD_ESTABLISH_DATE_MM.Items.Add(a);
			DDL_CIF_BUC.Items.Add(a);
			DDL_CIF_BUSINESS_TYPE.Items.Add(a);
			DDL_CIF_CITIZEN.Items.Add(a);
			DDL_CIF_CUST_OCCUPATION.Items.Add(a);
			DDL_CIF_DATI2.Items.Add(a);
			DDL_CIF_DEBITUR_TYPE.Items.Add(a);
			DDL_CIF_GOL_CUSTOMER.Items.Add(a);
			DDL_CIF_HUBUNGAN.Items.Add(a);
			DDL_CIF_JOB_TITLE.Items.Add(a);
			DDL_CIF_MAIN_ID_TYPE.Items.Add(a);
			DDL_CIF_MARITAL.Items.Add(a);
			DDL_CIF_OWNER_UNIT.Items.Add(a);
			DDL_CIF_PREFIK_NAME.Items.Add(a);
			DDL_CIF_RATING_COMP.Items.Add(a);
			DDL_CIF_RATING_DATE_MM.Items.Add(a);
			DDL_CIF_RATING_RESULT.Items.Add(a);
			DDL_CIF_SEX_TYPE.Items.Add(a);
			DDL_CURR.Items.Add(a);
			DDL_DENO.Items.Add(a);
			DDL_JNS_ID.Items.Add(a);
			DDL_JNS_KELAMIN.Items.Add(a);
			DDL_JNS_NASABAH.Items.Add(a);
			DDL_KODE_HUB.Items.Add(a);
			DDL_MM_TGLKADALUARSAIDUTAMA.Items.Add(a);
			DDL_VALUTA.Items.Add(a);
		}

		private void VAR_to_CONTROL()
		{
			TXT_CIF_CIF.Text = VAR_CIFNo;
			TXT_CIF_CUST_NAME.Text = VAR_CustomerName;
			RDO_CIF_DEBITUR_TYPE.SelectedValue = VAR_JenisNasabah;
			DDL_BUC.SelectedValue = VAR_BUC;
			DDL_CIF_OWNER_UNIT.SelectedValue = VAR_PICDataOwner;
			TXT_CIF_REPORT_NAME.Text = VAR_NamaNasabahPelaporan;
			TXT_CIF_BOD_ESTABLISH_DATE_DD.Text = VAR_TglLahirTglBerdiriPerusahaanDay;
			DDL_CIF_BOD_ESTABLISH_DATE_MM.SelectedValue = VAR_TglLahirTglBerdiriPerusahaanMonth;
			TXT_CIF_BOD_ESTABLISH_DATE_YY.Text = VAR_TglLahirTglBerdiriPerusahaanYear;
			TXT_CIF_PLACE_BOD_STABLISH.Text = VAR_TempatLahirAktaDikeluarkan;
			DDL_JNS_ID.SelectedValue = VAR_JenisIDUtama;
			TXT_CIF_MAIN_ID.Text = VAR_NoIDUtama;
			TXT_DD_TGLKADALUARSAIDUTAMA.Text = VAR_TglKadaluarsaIDUtamaDay;
			DDL_MM_TGLKADALUARSAIDUTAMA.SelectedValue = VAR_TglKadaluarsaIDUtamaMonth;
			TXT_YY_TGLKADALUARSAIDUTAMA.Text = VAR_TglLahirTglBerdiriPerusahaanYear;
			DDL_CIF_GOL_CUSTOMER.SelectedValue = VAR_GolonganNasabah;
			DDL_CIF_DEBITUR_TYPE.SelectedValue = VAR_JenisDebitur;
			DDL_CIF_HUBUNGAN.SelectedValue = VAR_HubunganDenganBank;
			TXT_CIF_ADDRESS_LINE1.Text = VAR_AlamatNasabah;
			TXT_CIF_KECAMATAN.Text = VAR_Kecamatan;
			TXT_CIF_ZIP.Text = VAR_KodePose;
			DDL_CIF_DATI2.SelectedValue = VAR_LokasiDatiII;
			RDO_PH.SelectedValue = VAR_NomorTelpRumahKantorHPSelected;
			TXT_PH.Text = VAR_NomorTelpRumahKantorHP;
			DDL_VALUTA.SelectedValue = VAR_Valuta;
			TXT_CIF_APP.Text = VAR_NoAPP;
			TXT_CIF_APP_DATE_DD.Text = VAR_TanggalAkteAPPDay;
			DDL_CIF_APP_DATE_MM.SelectedValue = VAR_TanggalAkteAPPMonth;
			TXT_CIF_APP_YY.Text = VAR_TglLahirTglBerdiriPerusahaanYear;
			TXT_CIF_APT.Text = VAR_NoAPT;
			TXT_CIF_APT_DATE_DD.Text = VAR_TanggalAPTDay;
			DDL_CIF_APT_DATE_MM.SelectedValue = VAR_TanggalAPTMonth;
			TXT_CIF_APT_DATE_YY.Text = VAR_TanggalAPTYear;
			TXT_CIF_PENDAPATAN_OPR.Text = VAR_PendapatanOperasional;
			TXT_CIF_PEDAPATAN_NOPR.Text = VAR_PendapatanNonOperasional;
			DDL_CIF_RATING_COMP.SelectedValue = VAR_LembagaPemeringkat;
			DDL_CIF_RATING_RESULT.SelectedValue = VAR_PeringkatPerusahaan;
			TXT_CIF_RATING_DATE_DD.Text = VAR_TanggalPemeringkatanTanggal;
			DDL_CIF_RATING_DATE_MM.SelectedValue = VAR_TanggalPemeringkatanMonth;
			TXT_CIF_RATING_DATE_YY.Text = VAR_TanggalPemeringkatanYear;
			DDL_CIF_BUSINESS_TYPE.SelectedValue = VAR_BentukBadanUsaha;
			DDL_CIF_SEX_TYPE.SelectedValue = VAR_JenisKelamin;
			TXT_CIF_MOTHER_NM.Text = VAR_NamaGadisIbuKandung;
			DDL_CIF_PREFIK_NAME.SelectedValue = VAR_NamaPrefik;
			TXT_CIF_CUST_COMP_NAME.Text = VAR_NamaPerushNasabahBekerja;
			DDL_CIF_BIDANG_USAHA.SelectedValue = VAR_BidangUsahaNasabah;
			DDL_CIF_JOB_TITLE.SelectedValue = VAR_JabatanNasabah;
			DDL_CIF_CUST_OCCUPATION.SelectedValue = VAR_PekerjaanNasabah;
			TXT_CIF_SALARY.Text = VAR_Gaji;
			TXT_CIF_MAIN_INCOME.Text = VAR_PendapatanUtama;
			TXT_CIF_OTHER_INCOME.Text = VAR_PendapatanLainnya;
			DDL_CIF_CITIZEN.SelectedValue = VAR_Kewarganegaraan;
			DDL_CIF_MARITAL.SelectedValue = VAR_StatusPerkawinan;

			/*Deklarasi variable penampung data pengurus*/
			TXT_CIF.Text = VAR_CIFNoPengurus;
			TXT_NAMA.Text = VAR_NamaPengurus;
			DDL_JNS_NASABAH.SelectedValue = VAR_JenisNasabahPengurus;
			TXT_TGL_COMP.Text = VAR_BODBerdiriSejakDate; 
			DDL_BLN_COMP.SelectedValue = VAR_BODBerdiriSejakMonth;
			TXT_THN_COMP.Text = VAR_BODBerdiriSejakYear;
			DDL_JNS_KELAMIN.SelectedValue = VAR_JenisKelaminPengurus;
			TXT_SAHAM.Text = VAR_ShareSaham;
			DDL_JNS_ID.SelectedValue = VAR_JenisIDUtamaPengurus;
			TXT_ID_UTAMA.Text = VAR_NoIDUtamaPengurus;
			TXT_EXP_DAY.Text = VAR_ExpiredDateIDUtamaDay;
			DDL_BLN_EXP.SelectedValue = VAR_ExpiredDateIDUtamaMonth;
			TXT_EXP_YEAR.Text = VAR_TglLahirTglBerdiriPerusahaanYear;
			TXT_ALAMAT.Text = VAR_Alamat;
			TXT_CU_ZIPCODE.Text = VAR_KodePos;
			DDL_BUC.SelectedValue = VAR_BUCPengurus;
			DDL_KODE_HUB.SelectedValue = VAR_KodeHubungan;
			CHK_REMOVED.Checked = bool.Parse(VAR_RemoveLink);

			/*Deklarasi varibale penampung data keuangan*/
			TXT_TGL_LAP.Text = VAR_PosisiLaporanKeuanganDay;
			DDL_BLN_LAP.SelectedValue = VAR_PosisiLaporanKeuanganMonth;
			TXT_THN_LAP.Text = VAR_PosisiLaporanKeuanganYear;
			RDO_PINJAMAN_LN.SelectedValue = VAR_PinjamanLuarNegeri;
			DDL_DENO.SelectedValue = VAR_Denominasi;
			DDL_AUDITED.SelectedValue = VAR_AuditedUnAudited;
			DDL_CURR.SelectedValue = VAR_Currency;
			TXT_JML_BLN.Text = VAR_JumlahBulan;
			TXT_ACTIVA.Text = VAR_AktivaLancar;
			TXT_TOT_ACTIVA.Text= VAR_TotalAktiva;
			TXT_WJB_BANK.Text = VAR_KewajibanKepadaBank;
			TXT_WJB_LANCAR.Text = VAR_KewajibanLancar;
			TXT_TOT_WJB.Text = VAR_TotalKewajiban;
			TXT_MODAL.Text = VAR_Modal;
			TXT_PENJUALAN.Text = VAR_Penjualan;
			TXT_POP.Text = VAR_PendapatanOperasionalDataKeuangan;
			TXT_BOP.Text = VAR_BiayaOperasional;
			TXT_NON_POP.Text = VAR_PendapatanNonOperasionalDataKeuangan;
			TXT_NON_BOP.Text = VAR_BiayaNonOperasional;
			LR_AFTER.Text = VAR_LabaRugiTahunLaluSetelahPajak;
			LR_BEFORE.Text = VAR_LabaRugiTahunLaluSebelumPajak;
		}

		private void CONTROL_to_VAR()
		{
			VAR_CIFNo = TXT_CIF_CIF.Text.ToString();
			VAR_CustomerName = TXT_CIF_CUST_NAME.Text.ToString();
			VAR_JenisNasabah = RDO_CIF_DEBITUR_TYPE.SelectedValue.ToString();
			VAR_BUC = DDL_BUC.SelectedValue.ToString();
			VAR_PICDataOwner = DDL_CIF_OWNER_UNIT.SelectedValue.ToString();
			VAR_NamaNasabahPelaporan = TXT_CIF_REPORT_NAME.Text.ToString();
			VAR_TglLahirTglBerdiriPerusahaanDay = TXT_CIF_BOD_ESTABLISH_DATE_DD.Text.ToString();
			VAR_TglLahirTglBerdiriPerusahaanMonth = DDL_CIF_BOD_ESTABLISH_DATE_MM.SelectedValue.ToString();
			VAR_TglLahirTglBerdiriPerusahaanYear = TXT_CIF_BOD_ESTABLISH_DATE_YY.Text.ToString();
			VAR_TempatLahirAktaDikeluarkan = TXT_CIF_PLACE_BOD_STABLISH.Text.ToString();
			VAR_JenisIDUtama = DDL_JNS_ID.SelectedValue.ToString();
			VAR_NoIDUtama = TXT_CIF_MAIN_ID.Text.ToString();
			VAR_TglKadaluarsaIDUtamaDay = TXT_DD_TGLKADALUARSAIDUTAMA.Text.ToString();
			VAR_TglKadaluarsaIDUtamaMonth = DDL_MM_TGLKADALUARSAIDUTAMA.SelectedValue.ToString(); 
			VAR_TglKadaluarsaIDUtamaYear = TXT_YY_TGLKADALUARSAIDUTAMA.Text.ToString();
			VAR_GolonganNasabah = DDL_CIF_GOL_CUSTOMER.SelectedValue.ToString();
			VAR_JenisDebitur = DDL_CIF_DEBITUR_TYPE.SelectedValue.ToString();
			VAR_HubunganDenganBank = DDL_CIF_HUBUNGAN.SelectedValue.ToString();
			VAR_AlamatNasabah = TXT_CIF_ADDRESS_LINE1.Text.ToString();
			VAR_Kecamatan = TXT_CIF_KECAMATAN.Text.ToString();
			VAR_KodePose = TXT_CIF_ZIP.Text.ToString();
			VAR_LokasiDatiII = DDL_CIF_DATI2.SelectedValue.ToString();
			VAR_NomorTelpRumahKantorHPSelected = RDO_PH.SelectedValue.ToString();
			VAR_NomorTelpRumahKantorHP = TXT_PH.Text.ToString();
			VAR_Valuta = DDL_VALUTA.SelectedValue.ToString();
			VAR_NoAPP = TXT_CIF_APP.Text.ToString();
			VAR_TanggalAkteAPPDay = TXT_CIF_APP_DATE_DD.Text.ToString();
			VAR_TanggalAkteAPPMonth = DDL_CIF_APP_DATE_MM.SelectedValue.ToString(); 
			VAR_TanggalAkteAPPYear = TXT_CIF_APP_YY.Text.ToString();
			VAR_NoAPT = TXT_CIF_APT.Text.ToString();
			VAR_TanggalAPTDay = TXT_CIF_APT_DATE_DD.Text.ToString();
			VAR_TanggalAPTMonth = DDL_CIF_APT_DATE_MM.SelectedValue.ToString();
			VAR_TanggalAPTYear = TXT_CIF_APT_DATE_YY.Text.ToString();
			VAR_PendapatanOperasional = TXT_CIF_PENDAPATAN_OPR.Text.ToString();
			VAR_PendapatanNonOperasional = TXT_CIF_PEDAPATAN_NOPR.Text.ToString();
			VAR_LembagaPemeringkat = DDL_CIF_RATING_COMP.SelectedValue.ToString();
			VAR_PeringkatPerusahaan = DDL_CIF_RATING_RESULT.SelectedValue.ToString();
			VAR_TanggalPemeringkatanTanggal = TXT_CIF_RATING_DATE_DD.Text.ToString();
			VAR_TanggalPemeringkatanMonth = DDL_CIF_RATING_DATE_MM.SelectedValue.ToString();
			VAR_TanggalPemeringkatanYear = TXT_CIF_RATING_DATE_YY.Text.ToString();
			VAR_BentukBadanUsaha = DDL_CIF_BUSINESS_TYPE.SelectedValue.ToString();
			VAR_JenisKelamin = DDL_CIF_SEX_TYPE.SelectedValue.ToString();
			VAR_NamaGadisIbuKandung = TXT_CIF_MOTHER_NM.Text.ToString();
			VAR_NamaPrefik = DDL_CIF_PREFIK_NAME.SelectedValue.ToString();
			VAR_NamaPerushNasabahBekerja = TXT_CIF_CUST_COMP_NAME.Text.ToString();
			VAR_BidangUsahaNasabah = DDL_CIF_BIDANG_USAHA.SelectedValue.ToString();
			VAR_JabatanNasabah = DDL_CIF_JOB_TITLE.SelectedValue.ToString();
			VAR_PekerjaanNasabah = DDL_CIF_CUST_OCCUPATION.SelectedValue.ToString();
			VAR_Gaji = TXT_CIF_SALARY.Text.ToString();
			VAR_PendapatanUtama = TXT_CIF_MAIN_INCOME.Text.ToString();
			VAR_PendapatanLainnya = TXT_CIF_OTHER_INCOME.Text.ToString();
			VAR_Kewarganegaraan = DDL_CIF_CITIZEN.SelectedValue.ToString();
			VAR_StatusPerkawinan = DDL_CIF_MARITAL.SelectedValue.ToString();

			/*Deklarasi variable penampung data pengurus*/
			VAR_CIFNoPengurus = TXT_CIF.Text.ToString();
			VAR_NamaPengurus = TXT_NAMA.Text.ToString();
			VAR_JenisNasabahPengurus = DDL_JNS_NASABAH.SelectedValue.ToString();
			VAR_BODBerdiriSejakDate = TXT_TGL_COMP.Text.ToString(); 
			VAR_BODBerdiriSejakMonth = DDL_BLN_COMP.SelectedValue.ToString();
			VAR_BODBerdiriSejakYear = TXT_THN_COMP.Text.ToString();
			VAR_JenisKelaminPengurus = DDL_JNS_KELAMIN.SelectedValue.ToString();
			VAR_ShareSaham = TXT_SAHAM.Text.ToString();
			VAR_JenisIDUtamaPengurus = DDL_JNS_ID.SelectedValue.ToString();
			VAR_NoIDUtamaPengurus = TXT_ID_UTAMA.Text.ToString();
			VAR_ExpiredDateIDUtamaDay = TXT_EXP_DAY.Text.ToString(); 
			VAR_ExpiredDateIDUtamaMonth = DDL_BLN_EXP.SelectedValue.ToString(); 
			VAR_ExpiredDateIDUtamaYear = TXT_EXP_YEAR.Text.ToString();
			VAR_Alamat = TXT_ALAMAT.Text.ToString();
			VAR_KodePos = TXT_CU_ZIPCODE.Text.ToString();
			VAR_BUCPengurus = DDL_BUC.SelectedValue.ToString();
			VAR_KodeHubungan = DDL_KODE_HUB.SelectedValue.ToString();
			VAR_RemoveLink = CHK_REMOVED.Checked.ToString();

			/*Deklarasi varibale penampung data keuangan*/
			VAR_PosisiLaporanKeuanganDay = TXT_TGL_LAP.Text.ToString(); 
			VAR_PosisiLaporanKeuanganMonth = DDL_BLN_LAP.SelectedValue.ToString();
			VAR_PosisiLaporanKeuanganYear = TXT_THN_LAP.Text.ToString();
			VAR_PinjamanLuarNegeri = RDO_PINJAMAN_LN.SelectedValue.ToString();
			VAR_Denominasi = DDL_DENO.SelectedValue.ToString();
			VAR_AuditedUnAudited = DDL_AUDITED.SelectedValue.ToString();
			VAR_Currency = DDL_CURR.SelectedValue.ToString();
			VAR_JumlahBulan = TXT_JML_BLN.Text.ToString();
			VAR_AktivaLancar = TXT_ACTIVA.Text.ToString();
			VAR_TotalAktiva = TXT_TOT_ACTIVA.Text.ToString();
			VAR_KewajibanKepadaBank = TXT_WJB_BANK.Text.ToString();
			VAR_KewajibanLancar = TXT_WJB_LANCAR.Text.ToString();
			VAR_TotalKewajiban = TXT_TOT_WJB.Text.ToString();
			VAR_Modal = TXT_MODAL.Text.ToString();
			VAR_Penjualan = TXT_PENJUALAN.Text.ToString();
			VAR_PendapatanOperasionalDataKeuangan = TXT_POP.Text.ToString();
			VAR_BiayaOperasional = TXT_BOP.Text.ToString();
			VAR_PendapatanNonOperasionalDataKeuangan = TXT_NON_POP.Text.ToString();
			VAR_BiayaNonOperasional = TXT_NON_BOP.Text.ToString();
			VAR_LabaRugiTahunLaluSetelahPajak = LR_AFTER.Text.ToString();
			VAR_LabaRugiTahunLaluSebelumPajak = LR_BEFORE.Text.ToString();
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
		
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("CAPCompletenessList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}
	}
}
