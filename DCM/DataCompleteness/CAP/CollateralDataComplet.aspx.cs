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

namespace SME.DCM.CAP.CollateralDataCompleteness
{
	/// <summary>
	/// Summary description for CollateralDataComplet.
	/// </summary>
	public partial class CollateralDataComplet : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn3 = new Connection(ConfigurationSettings.AppSettings["conn2"]);

		private string VAR_TypeAgunan;
		private string VAR_KeteranganAgunan;
		private string VAR_SifatAgunan;
		private string VAR_NamaPemilikAgunan;
		private string VAR_BuktiKepemilikan;
		private string VAR_StatusKepemilikan;
		private string VAR_TanggalTerbitSertifikatDay;
		private string VAR_TanggalTerbitSertifikatMonth;
		private string VAR_TanggalTerbitSertifikatYear;
		private string VAR_TanggalExpiredSertifikatDay;
		private string VAR_TanggalExpiredSertifikatMonth;
		private string VAR_TanggalExpiredSertifikatYear;
		private string VAR_AlamatAgunan;
		private string VAR_LokasiDatiII;
		private string VAR_KodeMataUang;
		private string VAR_NilaiPasar;
		private string VAR_NilaiAppraisal;
		private string VAR_NilaiLikuidasi;
		private string VAR_NilaiNJOP;
		private string VAR_PenerbitAgunan;
		private string VAR_LembagaPemeringkat;
		private string VAR_PeringkatPenerbitAgunan;
		private string VAR_TglPemeringkatanDay;
		private string VAR_TglPemeringkatanMonth;
		private string VAR_TglPemeringkatanYear;
		private string VAR_NilaiPengikatan;
		private string VAR_NoPengikatan;
		private string VAR_TanggalPenilaianKe1Day;
		private string VAR_TanggalPenilaianKe1Month;
		private string VAR_TanggalPenilaianKe1Year;
		private string VAR_TanggalPenilaianTerakhirDay;
		private string VAR_TanggalPenilaianTerakhirMonth;
		private string VAR_TanggalPenilaianTerakhirYear;
		private string VAR_PenilaianOleh;
		private string VAR_JenisPengikatan;
		private string VAR_TglPengikatanDay;
		private string VAR_TglPengikatanMonth;
		private string VAR_TglPengikatanYear;
		private string VAR_JenisAgunan;
		private string VAR_Asuransi;
		private string VAR_PeringkatSuratBerharga;
		private string VAR_TanggalPeringkatDay;
		private string VAR_TanggalPeringkatMonth;
		private string VAR_TanggalPeringkatYear;
		private string VAR_PenerbitSuratBerharga;
		private string VAR_TanggalPenerbitanDay;
		private string VAR_TanggalPenerbitanMonth;
		private string VAR_TanggalPenerbitanYear;
		private string VAR_TglJatuhTempoDay;
		private string VAR_TglJatuhTempoMonth;
		private string VAR_TglJatuhTempoYear;
		private string VAR_PledgingAmtToLimit;
		private string VAR_PledgingAmtToAwalLimit;
		private string VAR_PPACadanganUmum;
		private string VAR_PPACadanganKhusus;

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

				conn3.QueryString = "SELECT IDCONTROL FROM DCM_TABLE_ERROR WHERE PAGE = 'CollateralDataComplet.aspx' AND MESSAGE = '" + err_msg.Trim() + "'";
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
			VAR_TypeAgunan = "";
			VAR_KeteranganAgunan = "";
			VAR_SifatAgunan = "";
			VAR_NamaPemilikAgunan = "";
			VAR_BuktiKepemilikan = "";
			VAR_StatusKepemilikan = "";
			VAR_TanggalTerbitSertifikatDay = "";
			VAR_TanggalTerbitSertifikatMonth = "";
			VAR_TanggalTerbitSertifikatYear = "";
			VAR_TanggalExpiredSertifikatDay = "";
			VAR_TanggalExpiredSertifikatMonth = "";
			VAR_TanggalExpiredSertifikatYear = "";
			VAR_AlamatAgunan = "";
			VAR_LokasiDatiII = "";
			VAR_KodeMataUang = "";
			VAR_NilaiPasar = "";
			VAR_NilaiAppraisal = "";
			VAR_NilaiLikuidasi = "";
			VAR_NilaiNJOP = "";
			VAR_PenerbitAgunan = "";
			VAR_LembagaPemeringkat = "";
			VAR_PeringkatPenerbitAgunan = "";
			VAR_TglPemeringkatanDay = "";
			VAR_TglPemeringkatanMonth = "";
			VAR_TglPemeringkatanYear = "";
			VAR_NilaiPengikatan = "";
			VAR_NoPengikatan = "";
			VAR_TanggalPenilaianKe1Day = "";
			VAR_TanggalPenilaianKe1Month = "";
			VAR_TanggalPenilaianKe1Year = "";
			VAR_TanggalPenilaianTerakhirDay = "";
			VAR_TanggalPenilaianTerakhirMonth = "";
			VAR_TanggalPenilaianTerakhirYear = "";
			VAR_PenilaianOleh = "";
			VAR_JenisPengikatan = "";
			VAR_TglPengikatanDay = "";
			VAR_TglPengikatanMonth = "";
			VAR_TglPengikatanYear = "";
			VAR_JenisAgunan = "";
			VAR_Asuransi = null;
			VAR_PeringkatSuratBerharga = "";
			VAR_TanggalPeringkatDay = "";
			VAR_TanggalPeringkatMonth = "";
			VAR_TanggalPeringkatYear = "";
			VAR_PenerbitSuratBerharga = "";
			VAR_TanggalPenerbitanDay = "";
			VAR_TanggalPenerbitanMonth = "";
			VAR_TanggalPenerbitanYear = "";
			VAR_PenerbitSuratBerharga = "";
			VAR_TanggalPenerbitanDay = "";
			VAR_TanggalPenerbitanMonth = "";
			VAR_TanggalPenerbitanYear = "";
			VAR_TglJatuhTempoDay = "";
			VAR_TglJatuhTempoMonth = "";
			VAR_TglJatuhTempoYear = "";
			VAR_PledgingAmtToLimit = "";
			VAR_PledgingAmtToAwalLimit = "";
			VAR_PPACadanganUmum = "";
			VAR_PPACadanganKhusus = "";
		}

		private void AllDropDownListInitiation()
		{
			ListItem a = new ListItem("- SELECT -", "");

			DDL_TYPE_AGUNAN.Items.Add(a);
			DDL_SIFAT_AGUNAN.Items.Add(a);
			DDL_BUKTI_KEPEMILIKAN.Items.Add(a);
			DDL_STATUS_KEPEMILIKAN.Items.Add(a);
			DDL_MM_TGLTERBITSERTF.Items.Add(a);
			DDL_MM_EXPSERTF.Items.Add(a);
			DDL_LKS_DATI2.Items.Add(a);
			DDL_KODE_MATAUANG.Items.Add(a);
			DDL_MM_TGLPEMERINGKATAN.Items.Add(a);
			DDL_MM_PNLN_KE1.Items.Add(a);
			DDL_MM_PNLN_KE2.Items.Add(a);
			DDL_PENILAIANOLEH.Items.Add(a);
			DDL_JENISIKAT.Items.Add(a);
			DDL_MM_TGLIKAT.Items.Add(a);
			DDL_JENISAGUNAN.Items.Add(a);
			DDL_PRKT_SRT_BERHARGA.Items.Add(a);
			DDL_MM_TGLPRKT.Items.Add(a);
			DDL_PNRBTN_SRT_BRHRG.Items.Add(a);
			DDL_MM_TGLTERBIT.Items.Add(a);
			DDL_MM_JTHTEMPO.Items.Add(a);
		}

		private void VAR_to_CONTROL()
		{
			DDL_TYPE_AGUNAN.SelectedValue = VAR_TypeAgunan;
			TXT_KET_AGUNAN.Text = VAR_KeteranganAgunan;
			DDL_SIFAT_AGUNAN.SelectedValue = VAR_SifatAgunan;
			TXT_NMPEMILIK_COLL.Text = VAR_NamaPemilikAgunan;
			DDL_BUKTI_KEPEMILIKAN.SelectedValue = VAR_BuktiKepemilikan;
			DDL_STATUS_KEPEMILIKAN.SelectedValue = VAR_StatusKepemilikan;
			TXT_DD_TGLTERBITSERT.Text = VAR_TanggalTerbitSertifikatDay;
			DDL_MM_TGLTERBITSERTF.SelectedValue = VAR_TanggalTerbitSertifikatMonth;
			TXT_YY_TGLTERBITSERTF.Text = VAR_TanggalTerbitSertifikatYear;
			TXT_DD_EXPSERTF.Text = VAR_TanggalExpiredSertifikatDay;
			DDL_MM_EXPSERTF.SelectedValue = VAR_TanggalExpiredSertifikatMonth;
			TXT_YY_EXPSERTF.Text = VAR_TanggalExpiredSertifikatYear;
			TXT_ALAMAT_AGUNAN.Text = VAR_AlamatAgunan;
			DDL_LKS_DATI2.SelectedValue = VAR_LokasiDatiII;
			DDL_KODE_MATAUANG.SelectedValue = VAR_KodeMataUang;
			TXT_NILAIPASAR.Text = VAR_NilaiPasar;
			TXT_NILAIAPPRAISAL.Text = VAR_NilaiAppraisal;
			TXT_NILAILIKUIDASI.Text = VAR_NilaiLikuidasi;
			TXT_NILAINJOP.Text = VAR_NilaiNJOP;
			TXT_PENERBITAGUNAN.Text = VAR_PenerbitAgunan;
			TXT_LEMBAGA_PRKT.Text = VAR_LembagaPemeringkat;
			TXT_PRKT_PNRBT_COLL.Text = VAR_PeringkatPenerbitAgunan;
			TXT_DD_TGLPEMERINGKATAN.Text = VAR_TglPemeringkatanDay;
			DDL_MM_TGLPEMERINGKATAN.SelectedValue = VAR_TglPemeringkatanMonth;
			TXT_YY_TGLPEMERINGKATAN.Text = VAR_TglPemeringkatanYear;
			TXT_NILAI_IKAT.Text = VAR_NilaiPengikatan;
			TXT_NO_IKAT.Text = VAR_NoPengikatan;
			TXT_DD_PNLN_KE1.Text = VAR_TanggalPenilaianKe1Day;
			DDL_MM_PNLN_KE1.SelectedValue = VAR_TanggalPenilaianKe1Month;
			TXT_YY_PNLN_KE1.Text = VAR_TanggalPenilaianKe1Year;
			TXT_DD_PNLN_KE2.Text = VAR_TanggalPenilaianTerakhirDay;
			DDL_MM_PNLN_KE2.SelectedValue = VAR_TanggalPenilaianTerakhirMonth;
			TXT_YY_PNLN_KE2.Text = VAR_TanggalPenilaianTerakhirYear;
			DDL_PENILAIANOLEH.SelectedValue = VAR_PenilaianOleh;
			DDL_JENISIKAT.SelectedValue = VAR_JenisPengikatan;
			TXT_DD_TGLIKAT.Text = VAR_TglPengikatanDay;
			DDL_MM_TGLIKAT.SelectedValue = VAR_TglPengikatanMonth;
			TXT_YY_TGLIKAT.Text = VAR_TglPengikatanYear;
			DDL_JENISAGUNAN.SelectedValue = VAR_JenisAgunan;
			RDO_ASURANSI.SelectedValue = VAR_Asuransi;
			DDL_PRKT_SRT_BERHARGA.SelectedValue = VAR_PeringkatSuratBerharga;
			TXT_DD_TGLPRKT.Text = VAR_TanggalPeringkatDay;
			DDL_MM_TGLPRKT.SelectedValue = VAR_TanggalPeringkatMonth;
			TXT_YY_TGLPRKT.Text = VAR_TanggalPeringkatYear;
			DDL_PNRBTN_SRT_BRHRG.SelectedValue = VAR_PenerbitSuratBerharga;
			TXT_DD_TGLTERBIT.Text = VAR_TanggalPenerbitanDay;
			DDL_MM_TGLTERBIT.SelectedValue = VAR_TanggalPenerbitanMonth;
			TXT_YY_TGLTERBIT.Text = VAR_TanggalPenerbitanYear;
			TXT_DD_JTHTEMPO.Text = VAR_TglJatuhTempoDay;
			DDL_MM_JTHTEMPO.SelectedValue = VAR_TglJatuhTempoMonth;
			TXT_YY_JTHTEMPO.Text = VAR_TglJatuhTempoYear;
			TXT_PLDAMTTOLIMIT.Text = VAR_PledgingAmtToLimit;
			TXT_PLDAMTTOAVALIMIT.Text = VAR_PledgingAmtToAwalLimit;
			TXT_PPA_CADUM.Text = VAR_PPACadanganUmum;
			TXT_PPA_CADKUS.Text = VAR_PPACadanganKhusus;
		}
		
		private void CONTROL_to_VAR()
		{
			VAR_TypeAgunan = DDL_TYPE_AGUNAN.SelectedValue.ToString();
			VAR_KeteranganAgunan = TXT_KET_AGUNAN.Text.ToString();
			VAR_SifatAgunan = DDL_SIFAT_AGUNAN.SelectedValue.ToString();
			VAR_NamaPemilikAgunan = TXT_NMPEMILIK_COLL.Text.ToString();
			VAR_BuktiKepemilikan = DDL_BUKTI_KEPEMILIKAN.SelectedValue.ToString();
			VAR_StatusKepemilikan = DDL_STATUS_KEPEMILIKAN.SelectedValue.ToString();
			VAR_TanggalTerbitSertifikatDay = TXT_DD_TGLTERBITSERT.Text.ToString();
			VAR_TanggalTerbitSertifikatMonth = DDL_MM_TGLTERBITSERTF.SelectedValue.ToString();
			VAR_TanggalTerbitSertifikatYear = TXT_YY_TGLTERBITSERTF.Text.ToString();
			VAR_TanggalExpiredSertifikatDay = TXT_DD_EXPSERTF.Text.ToString();
			VAR_TanggalExpiredSertifikatMonth = DDL_MM_EXPSERTF.SelectedValue.ToString();
			VAR_TanggalExpiredSertifikatYear = TXT_YY_EXPSERTF.Text.ToString();
			VAR_AlamatAgunan = TXT_ALAMAT_AGUNAN.Text.ToString();
			VAR_LokasiDatiII = DDL_LKS_DATI2.SelectedValue.ToString();
			VAR_KodeMataUang = DDL_KODE_MATAUANG.SelectedValue.ToString();
			VAR_NilaiPasar = TXT_NILAIPASAR.Text.ToString();
			VAR_NilaiAppraisal = TXT_NILAIAPPRAISAL.Text.ToString();
			VAR_NilaiLikuidasi = TXT_NILAILIKUIDASI.Text.ToString();
			VAR_NilaiNJOP = TXT_NILAINJOP.Text.ToString();
			VAR_PenerbitAgunan = TXT_PENERBITAGUNAN.Text.ToString();
			VAR_LembagaPemeringkat = TXT_LEMBAGA_PRKT.Text.ToString();
			VAR_PeringkatPenerbitAgunan = TXT_PRKT_PNRBT_COLL.Text.ToString();
			VAR_TglPemeringkatanDay = TXT_DD_TGLPEMERINGKATAN.Text.ToString();
			VAR_TglPemeringkatanMonth = DDL_MM_TGLPEMERINGKATAN.SelectedValue.ToString();
			VAR_TglPemeringkatanYear = TXT_YY_TGLPEMERINGKATAN.Text.ToString();
			VAR_NilaiPengikatan = TXT_NILAI_IKAT.Text.ToString();
			VAR_NoPengikatan = TXT_NO_IKAT.Text.ToString();
			VAR_TanggalPenilaianKe1Day = TXT_DD_PNLN_KE1.Text.ToString();
			VAR_TanggalPenilaianKe1Month = DDL_MM_PNLN_KE1.SelectedValue.ToString();
			VAR_TanggalPenilaianKe1Year = TXT_YY_PNLN_KE1.Text.ToString();
			VAR_TanggalPenilaianTerakhirDay = TXT_DD_PNLN_KE2.Text.ToString();
			VAR_TanggalPenilaianTerakhirMonth = DDL_MM_PNLN_KE2.SelectedValue.ToString();
			VAR_TanggalPenilaianTerakhirYear = TXT_YY_PNLN_KE2.Text.ToString();
			VAR_PenilaianOleh = DDL_PENILAIANOLEH.SelectedValue.ToString();
			VAR_JenisPengikatan = DDL_JENISIKAT.SelectedValue.ToString();
			VAR_TglPengikatanDay = TXT_DD_TGLIKAT.Text.ToString();
			VAR_TglPengikatanMonth = DDL_MM_TGLIKAT.SelectedValue.ToString();
			VAR_TglPengikatanYear = TXT_YY_TGLIKAT.Text.ToString();
			VAR_JenisAgunan = DDL_JENISAGUNAN.SelectedValue.ToString();
			VAR_Asuransi = RDO_ASURANSI.SelectedValue.ToString();
			VAR_PeringkatSuratBerharga = DDL_PRKT_SRT_BERHARGA.SelectedValue.ToString();
			VAR_TanggalPeringkatDay = TXT_DD_TGLPRKT.Text.ToString();
			VAR_TanggalPeringkatMonth = DDL_MM_TGLPRKT.SelectedValue.ToString();
			VAR_TanggalPeringkatYear = TXT_YY_TGLPRKT.Text.ToString();
			VAR_PenerbitSuratBerharga = DDL_PNRBTN_SRT_BRHRG.SelectedValue.ToString();
			VAR_TanggalPenerbitanDay = TXT_DD_TGLTERBIT.Text.ToString();
			VAR_TanggalPenerbitanMonth = DDL_MM_TGLTERBIT.SelectedValue.ToString();
			VAR_TanggalPenerbitanYear = TXT_YY_TGLTERBIT.Text.ToString();
			VAR_TglJatuhTempoDay = TXT_DD_JTHTEMPO.Text.ToString();
			VAR_TglJatuhTempoMonth = DDL_MM_JTHTEMPO.SelectedValue.ToString();
			VAR_TglJatuhTempoYear = TXT_YY_JTHTEMPO.Text.ToString();
			VAR_PledgingAmtToLimit = TXT_PLDAMTTOLIMIT.Text.ToString();
			VAR_PledgingAmtToAwalLimit = TXT_PLDAMTTOAVALIMIT.Text.ToString();
			VAR_PPACadanganUmum = TXT_PPA_CADUM.Text.ToString();
			VAR_PPACadanganKhusus = TXT_PPA_CADKUS.Text.ToString();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("CAPCompletenessList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}
	}
}
