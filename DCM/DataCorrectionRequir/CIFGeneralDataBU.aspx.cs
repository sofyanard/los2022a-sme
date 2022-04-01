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
	/// Summary description for CIFGeneralDataBU.
	/// </summary>
	public partial class CIFGeneralDataBU : System.Web.UI.Page
	{
		protected Connection conn;
		protected Connection2 conn2;
		protected Connection2 conn3;
		protected Tools tool = new Tools();
	
		/*Deklarasi variable*/
		private string VAR_CifNo;
		private string VAR_CustomerName;
		private string VAR_NamaPelaporan;
		private string VAR_NamaPrefik;
		private string VAR_JenisNasabah;
		private string VAR_TglBerdiriPerusahaanDay;
		private string VAR_TglBerdiriPerusahaanMonth;
		private string VAR_TglBerdiriPerusahaanYear;
		private string VAR_TempatAktaDikeluarkan;
		private string VAR_JenisIDUtama;
		private string VAR_NoIDUtama;
		private string VAR_TglKadaluarsaIDUtamaDay;
		private string VAR_TglKadaluarsaIDUtamaMonth;
		private string VAR_TglKadaluarsaIDUtamaYear;
		private string VAR_TempatDikeluarkanIDUtama;
		private string VAR_JenisDebitur;
		private string VAR_GolonganNasabah;
		private string VAR_Kewarganegaraan;
		private string VAR_KodeIndustri;			
		private string VAR_TanggalAPPDay;
		private string VAR_TanggalAPPMonth;
		private string VAR_TanggalAPPYear;
		private string VAR_NoAPT;
		private string VAR_TanggalAPTDay;
		private string VAR_TanggalAPTMonth;
		private string VAR_TanggalAPTYear;
		private string VAR_NoTeleponKantor;
		private string VAR_KodeNegara;
		private string VAR_Alamat1;
		private string VAR_Alamat2;
		private string VAR_Kecamatan;
		private string VAR_ZipCode;
		private string VAR_Kota;
		private string VAR_JenisAlamat;
		private string VAR_LokasiDatiII;
		private string VAR_LembagaPemeringkat;
		private string VAR_PeringkatPerusahaan;
		private string VAR_TanggalPemeringkatanDay;
		private string VAR_TanggalPemeringkatanMonth;
		private string VAR_TanggalPemeringkatanYear;
		private string VAR_HubungandenganKeluarga;
		private string VAR_HubungandenganBank;
		private string VAR_PICDataOwner;
		private string VAR_GoPublic;		
		private string VAR_NoTelponRumah;
		private string VAR_NoTelponMobile;
		private string VAR_PendapatanOperasional;
		private string VAR_PendapatanNonOperasional;		
		private string VAR_Valuta;
		private string VAR_NoAPP;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewField();
			conn = (Connection) Session["Connection"];
			conn2 = new Connection2(ConfigurationSettings.AppSettings["conn2"]);
			conn3 = new Connection2(ConfigurationSettings.AppSettings["conn2"]);

			if(!IsPostBack)
			{
				DDL_NAMA_PREFIK.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_JNS_NASABAH.Items.Add(new ListItem("Pilih--", ""));
				DDL_BLN_BOD.Items.Add(new ListItem("--Pilih--", ""));
				DDL_JNS_IDI.Items.Add(new ListItem("--Pilih--",""));				
				DDL_BLN_KAD.Items.Add(new ListItem("--Pilih--",""));
				DDL_JNS_DEB.Items.Add(new ListItem("--Pilih--", ""));
				DDL_GOL_NASABAH.Items.Add(new ListItem("--Pilih--", ""));
				DDL_KWRG.Items.Add(new ListItem("--Pilih--", ""));
				DDL_KODE_INDUSTRI.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_JNS_ALAMAT.Items.Add(new ListItem("Pilih--", ""));
				DDL_LOKASI_DATI.Items.Add(new ListItem("--Pilih--", ""));
				DDL_LBG_PEM.Items.Add(new ListItem("--Pilih--",""));
				DDL_PEM_COMP.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN_PEM.Items.Add(new ListItem("--Pilih--",""));
				DDL_HUB_KEL.Items.Add(new ListItem("--Pilih--", ""));
				DDL_HUB_BANK.Items.Add(new ListItem("--Pilih--", ""));
				DDL_PIC.Items.Add(new ListItem("--Pilih--", ""));
				DDL_KODE_NEGARA.Items.Add(new ListItem("--Pilih--", ""));
				DDL_BLN_APP.Items.Add(new ListItem("--Pilih--", ""));
				DDL_BLN_APT.Items.Add(new ListItem("--Pilih--", ""));
				
				for (int i=1; i<=12; i++)
				{
					DDL_BLN_BOD.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_KAD.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_PEM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));				
					DDL_BLN_APP.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));	
					DDL_BLN_APT.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));	
				}

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_NAMAPREFIK";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_NAMA_PREFIK.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_BU";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JNS_NASABAH.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_JENISID";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JNS_IDI.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_JENISDEBITUR";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JNS_DEB.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_GOLNASABAH";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_GOL_NASABAH.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_KODENEGARA";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_KWRG.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_KODEINDUSTRI";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_KODE_INDUSTRI.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_KODENEGARA";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_KODE_NEGARA.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_JENISALAMAT";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JNS_ALAMAT.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_LOKASIDATI ORDER BY CONVERT(INT, LOCATIONID)";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_LOKASI_DATI.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_LEMBAGAPEMERINGKAT";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_LBG_PEM.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_PERINGKATPERUSAHAAN";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_PEM_COMP.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_HUBDGKELUARGA";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_HUB_KEL.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_HUBDENGANBANK ORDER BY CONVERT(INT, HUBEXEC_CODE)";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_HUB_BANK.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_PICDATAOWNER";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_PIC.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_VALUTA";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_VALUTA.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				/*************************************************************************************************/
				//RetrieveSOA();

				/*Cek error message*/
				CheckError();
			}

			ViewMenu();
		}

		private void ViewField()
		{
			TXT_CIFNO.Enabled = false;
			TXT_CUST_NAME.Enabled = false;
			TXT_NAMA_PELAPOR.Enabled = false;
			DDL_NAMA_PREFIK.Enabled = false;
			DDL_JNS_NASABAH.Enabled = false;
			TXT_TGL_BOD.Enabled = false;
			DDL_BLN_BOD.Enabled = false;
			TXT_THN_BOD.Enabled = false;
			TXT_TMP_AKTA.Enabled = false;
			DDL_JNS_IDI.Enabled = false;
			TXT_NO_IDI.Enabled = false;
			TXT_TGL_KAD.Enabled = false;
			DDL_BLN_KAD.Enabled = false;
			TXT_THN_KAD.Enabled = false;
			TXT_TEMPAT_IDI.Enabled = false;
			DDL_JNS_DEB.Enabled = false;
			DDL_GOL_NASABAH.Enabled = false;
			DDL_KWRG.Enabled = false;
			DDL_KODE_INDUSTRI.Enabled = false;
			TXT_NO_APP.Enabled = false;
			TXT_TGL_APP.Enabled = false;
			DDL_BLN_APP.Enabled = false;
			TXT_THN_APP.Enabled = false;
			TXT_NO_APT.Enabled = false;
			TXT_TGL_APT.Enabled = false;
			DDL_BLN_APT.Enabled = false;
			TXT_THN_APT.Enabled = false;
			TXT_TLP_KANTOR.Enabled = false;
			DDL_KODE_NEGARA.Enabled = false;
			TXT_ALAMAT1.Enabled = false;
			TXT_ALAMAT2.Enabled = false;
			TXT_KECAMATAN.Enabled = false;
			TXT_CU_COMPZIPCODE.Enabled = false;
			BTN_SEARCHCOMP.Enabled = false;
			TXT_KOTA.Enabled = false;
			DDL_JNS_ALAMAT.Enabled = false;
			DDL_LOKASI_DATI.Enabled = false;
			DDL_PEM_COMP.Enabled = false;
			DDL_LBG_PEM.Enabled = false;
			TXT_TGL_PEMRINGKAT.Enabled = false;
			DDL_BLN_PEM.Enabled = false;
			TXT_THN_PEMRINGKAT.Enabled = false;
			DDL_HUB_KEL.Enabled = false;
			DDL_HUB_BANK.Enabled = false;
			DDL_PIC.Enabled = false;
            RDO_GOPUBLIC.Enabled = false;
			TXT_TELP_RMH.Enabled = false;
			TXT_MOBILE.Enabled = false;
			TXT_OPR.Enabled = false;
			TXT_NON_OPR.Enabled = false;
			DDL_VALUTA.Enabled = false;
		}

		/*
		private DQM.SOA.SOA_DQM MainClass = new DQM.SOA.SOA_DQM();
		private DQM.CIFInquiry.body BodyRequest = new DQM.CIFInquiry.body();
		private DQM.CIFInquiry.CIFInquiryResponse ResponseClass = new DQM.CIFInquiry.CIFInquiryResponse();

		private DQM.CIFMandatoryMaintenance.body BodyMaintenanceRequest = new DQM.CIFMandatoryMaintenance.body();
		private DQM.CIFMandatoryMaintenance.CIFMandatoryMaintenanceResponse ResponseMaintenanceClass = new DQM.CIFMandatoryMaintenance.CIFMandatoryMaintenanceResponse();
		*/
		
		/*
		private void RetrieveSOA()
		{
			BodyRequest.CIFNumber = Request.QueryString["cifno"];
			ResponseClass = MainClass.CIFMandatoryInquiryService(BodyRequest);

			if (ResponseClass.soaHeader.responseCode == 1)
			{
				try{VAR_CifNo = Request.QueryString["cifno"];}
				catch (Exception e)	{VAR_CifNo = "";}
				try{VAR_CustomerName = ResponseClass.body.CIFName1.ToString();}
				catch (Exception e){VAR_CustomerName = "";}
				try{VAR_NamaPelaporan = "";}
				catch{VAR_NamaPelaporan = "";}
				try{VAR_NamaPrefik = "";}
				catch{VAR_NamaPrefik = "";}
				try{VAR_JenisNasabah = ResponseClass.body.customerTypeCode.ToString();}
				catch{VAR_JenisNasabah = "";}
				try{VAR_TglBerdiriPerusahaanDay = ResponseClass.body.birthIncorporationDate.Day.ToString();				}
				catch{VAR_TglBerdiriPerusahaanDay = "";}
				try{VAR_TglBerdiriPerusahaanMonth = ResponseClass.body.birthIncorporationDate.Month.ToString();}
				catch{VAR_TglBerdiriPerusahaanMonth = "";}
				try{VAR_TglBerdiriPerusahaanYear = ResponseClass.body.birthIncorporationDate.Year.ToString();}
				catch{VAR_TglBerdiriPerusahaanYear = "";}
				try{VAR_TempatAktaDikeluarkan = "";}
				catch{VAR_TempatAktaDikeluarkan = "";}
				try{VAR_JenisIDUtama = ResponseClass.body.IDTypeCode.ToString();}
				catch{VAR_JenisIDUtama = "";}
				try{VAR_NoIDUtama = ResponseClass.body.IDNumber.ToString();}
				catch{VAR_NoIDUtama = "";}
				try{VAR_TglKadaluarsaIDUtamaDay = ResponseClass.body.IDExpiryDate.Day.ToString();}
				catch{VAR_TglKadaluarsaIDUtamaDay = "";}
				try{VAR_TglKadaluarsaIDUtamaMonth = ResponseClass.body.IDExpiryDate.Month.ToString();}
				catch{VAR_TglKadaluarsaIDUtamaMonth = "";}
				try{VAR_TglKadaluarsaIDUtamaYear = ResponseClass.body.IDExpiryDate.Year.ToString();}
				catch{VAR_TglKadaluarsaIDUtamaYear = "";}
				try{VAR_TempatDikeluarkanIDUtama = ResponseClass.body.IDIssuePlace.ToString();}
				catch{VAR_TempatDikeluarkanIDUtama = "";}
				try{VAR_JenisDebitur = "";}
				catch{VAR_JenisDebitur = "";}
				try{VAR_GolonganNasabah = "";}
				catch{VAR_GolonganNasabah = "";}
				try{VAR_Kewarganegaraan = ResponseClass.body.countryOfCitizenship.ToString();}
				catch{VAR_Kewarganegaraan = "";}
				try{VAR_KodeIndustri = ResponseClass.body.internalIndustryCode.ToString();}
				catch{VAR_KodeIndustri = "";}
				try{VAR_NoAPP = "";}
				catch{VAR_NoAPP = "";}
				try{VAR_TanggalAPPDay = "";}
				catch{VAR_TanggalAPPDay = "";}
				try{VAR_TanggalAPPMonth = "";}
				catch{VAR_TanggalAPPMonth = "";}
				try{VAR_TanggalAPPYear = "";}
				catch{VAR_TanggalAPPYear = "";}
				try{VAR_NoAPT = "";}
				catch{VAR_NoAPT = "";}
				try{VAR_TanggalAPTDay = "";}
				catch{VAR_TanggalAPTDay = "";}
				try{VAR_TanggalAPTMonth = "";}
				catch{VAR_TanggalAPTMonth = "";}
				try{VAR_TanggalAPTYear = "";}
				catch{VAR_TanggalAPTYear = "";}
				try{VAR_NoTeleponKantor = "";}
				catch{VAR_NoTeleponKantor = "";}
				try{VAR_KodeNegara = ResponseClass.body.country.ToString();}
				catch{VAR_KodeNegara = "";}
				try{VAR_Alamat1 = ResponseClass.body.address1.ToString();}
				catch{VAR_Alamat1 = "";}
				try{VAR_Alamat2 = ResponseClass.body.address2.ToString();}
				catch{VAR_Alamat2 = "";}
				try{VAR_Kecamatan = "";}
				catch{VAR_Kecamatan = "";}
				try{VAR_ZipCode = ResponseClass.body.postalCode.ToString();}
				catch{VAR_ZipCode = "";}
				try{VAR_Kota = "";}
				catch{VAR_Kota = "";}
				try{VAR_JenisAlamat = "";}
				catch{VAR_JenisAlamat = "";}
				try{VAR_LokasiDatiII = "";}
				catch{VAR_LokasiDatiII = "";}
				try{VAR_LembagaPemeringkat = "";}
				catch{VAR_LembagaPemeringkat = "";}
				try{VAR_PeringkatPerusahaan = "";}
				catch{VAR_PeringkatPerusahaan = "";}
				try{VAR_TanggalPemeringkatanDay = "";}
				catch{VAR_TanggalPemeringkatanDay = "";}
				try{VAR_TanggalPemeringkatanMonth = "";}
				catch{VAR_TanggalPemeringkatanMonth = "";}
				try{VAR_TanggalPemeringkatanYear = "";}
				catch{VAR_TanggalPemeringkatanYear = "";}
				try{VAR_HubungandenganBank = "";}
				catch{VAR_HubungandenganBank = "";}
				try{VAR_HubungandenganKeluarga = "";}
				catch{VAR_HubungandenganKeluarga = "";}
				try{VAR_PICDataOwner = "";}
				catch{VAR_PICDataOwner = "";}
				try{VAR_GoPublic = "";}
				catch{VAR_GoPublic = "";}
				try{VAR_NoTelponRumah = ResponseClass.body.telephone.ToString();}
				catch{VAR_NoTelponRumah = "";}
				try{VAR_NoTelponMobile = ResponseClass.body.handphone.ToString();}
				catch{VAR_NoTelponMobile = "";}
				try{VAR_PendapatanOperasional = "";}
				catch{VAR_PendapatanOperasional = "";}
				try{VAR_PendapatanNonOperasional = "";}
				catch{VAR_PendapatanNonOperasional = "";}
				try{VAR_Valuta = "";}
				catch{VAR_Valuta = "";}

				VAR_to_CONTROL();
			}
			else
			{
				Tools.popMessage(this, ResponseClass.soaHeader.responseMessage.ToString());
				Response.Redirect("");
			}
		}
		*/

		private void VAR_to_CONTROL()
		{
			TXT_CIFNO.Text                  = VAR_CifNo;
			TXT_CUST_NAME.Text              = VAR_CustomerName;
			TXT_NAMA_PELAPOR.Text           = VAR_NamaPelaporan;
			DDL_NAMA_PREFIK.SelectedValue   = VAR_NamaPrefik;
			DDL_JNS_NASABAH.SelectedValue   = VAR_JenisNasabah;
			TXT_TGL_BOD.Text                = VAR_TglBerdiriPerusahaanDay;
			DDL_BLN_BOD.SelectedValue       = VAR_TglBerdiriPerusahaanMonth;
			TXT_THN_BOD.Text                = VAR_TglBerdiriPerusahaanYear;
			TXT_TMP_AKTA.Text               = VAR_TempatAktaDikeluarkan;
			DDL_JNS_IDI.SelectedValue       = VAR_JenisIDUtama;
			TXT_NO_IDI.Text                 = VAR_NoIDUtama;
			TXT_TGL_KAD.Text                = VAR_TglKadaluarsaIDUtamaDay;
			DDL_BLN_KAD.SelectedValue       = VAR_TglKadaluarsaIDUtamaMonth;
			TXT_THN_KAD.Text                = VAR_TglKadaluarsaIDUtamaYear;
			TXT_TEMPAT_IDI.Text             = VAR_TempatDikeluarkanIDUtama;
			DDL_JNS_DEB.SelectedValue       = VAR_JenisDebitur;
			DDL_GOL_NASABAH.SelectedValue   = VAR_GolonganNasabah;
			DDL_KWRG.SelectedValue          = VAR_Kewarganegaraan;
			DDL_KODE_INDUSTRI.SelectedValue = VAR_KodeIndustri;
			TXT_NO_APP.Text                 = VAR_NoAPP;
			TXT_TGL_APP.Text                = VAR_TanggalAPPDay;
			DDL_BLN_APP.SelectedValue       = VAR_TanggalAPPMonth;
			TXT_THN_APP.Text                = VAR_TanggalAPPYear;
			TXT_NO_APT.Text                 = VAR_NoAPT;
			TXT_TGL_APT.Text                = VAR_TanggalAPTDay;
			DDL_BLN_APT.SelectedValue       = VAR_TanggalAPTMonth;
			TXT_THN_APT.Text                = VAR_TanggalAPTYear;  
			TXT_TLP_KANTOR.Text             = VAR_NoTeleponKantor;
			DDL_KODE_NEGARA.SelectedValue   = VAR_KodeNegara;
			TXT_ALAMAT1.Text                = VAR_Alamat1;
			TXT_ALAMAT2.Text                = VAR_Alamat2;
			TXT_KECAMATAN.Text              = VAR_Kecamatan;
			TXT_CU_COMPZIPCODE.Text         = VAR_ZipCode;
			TXT_KOTA.Text                   = VAR_Kota;
			DDL_JNS_ALAMAT.SelectedValue    = VAR_JenisAlamat;
			DDL_LOKASI_DATI.SelectedValue   = VAR_LokasiDatiII;
			DDL_LBG_PEM.SelectedValue       = VAR_LembagaPemeringkat;
			DDL_PEM_COMP.SelectedValue      = VAR_PeringkatPerusahaan;
			TXT_TGL_PEMRINGKAT.Text         = VAR_TanggalPemeringkatanDay;
			DDL_BLN_PEM.SelectedValue       = VAR_TanggalPemeringkatanMonth;
			TXT_THN_PEMRINGKAT.Text         = VAR_TanggalPemeringkatanYear;
			DDL_HUB_KEL.SelectedValue       = VAR_HubungandenganKeluarga;
			DDL_HUB_BANK.SelectedValue      = VAR_HubungandenganBank;
			DDL_PIC.SelectedValue           = VAR_PICDataOwner;
			RDO_GOPUBLIC.SelectedValue      = VAR_GoPublic;
			TXT_TELP_RMH.Text               = VAR_NoTelponRumah;
			TXT_MOBILE.Text                 = VAR_NoTelponMobile;
			TXT_OPR.Text                    = VAR_PendapatanOperasional;
			TXT_NON_OPR.Text                = VAR_PendapatanNonOperasional;
			DDL_VALUTA.SelectedValue        = VAR_Valuta;
		}

		private void CheckError()
		{			
			/*
			string id = "";
			string err_msg = Request.QueryString["msg"];

			string[] message = err_msg.Split(new Char[] { ';' });

			foreach (string msg in message)
			{
				if (msg.Trim() != "")
				{
					conn2.QueryString = "SELECT IDCONTROL FROM DCM_TABLE_ERROR WHERE PAGE = 'CIFGeneralDataBU.aspx' AND MESSAGE = '" + msg.Trim() + "'";
					conn2.ExecuteQuery();

					if (conn2.GetFieldValue("IDCONTROL") != "")
					{
						id = "LBL_" + conn2.GetFieldValue("IDCONTROL");
						((Label)this.Page.FindControl(id)).ForeColor = Color.Red;
					}
				}
			}
			*/
			string id = "", id_field = "";

			conn2.QueryString = "EXEC DCM_DATA_ERROR_CHECKING '" + Request.QueryString["cifno"] + "','1'";
			conn2.ExecuteQuery();

			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				string err_msg = conn2.GetFieldValue(i, "ERR_MSG").ToString().Replace(";","");

				conn3.QueryString = "SELECT IDCONTROL FROM DCM_TABLE_ERROR WHERE PAGE = 'CIFGeneralDataBU.aspx' AND MESSAGE = '" + err_msg.Trim() + "'";
				conn3.ExecuteQuery();

				id = "LBL_" + conn3.GetFieldValue("IDCONTROL");
				((Label)this.Page.FindControl(id)).ForeColor = Color.Red;

				for(int j = 0; j < conn3.GetRowCount(); j++)
				{
					if (conn3.GetFieldValue("IDCONTROL") != "")
					{
						try
						{
							id = "LBL_" + conn3.GetFieldValue("IDCONTROL");
							((Label)this.Page.FindControl(id)).ForeColor = Color.Red;
						}
						catch
						{
							return;
						}

						id_field = conn3.GetFieldValue("IDCONTROL").ToString().Substring(0,3);

						if(id_field == "TXT")
						{
							id_field = conn3.GetFieldValue("IDCONTROL");
							((TextBox)this.Page.FindControl(id_field)).Enabled = true;
						}
					
						else if(id_field == "DDL")
						{
							id_field = conn3.GetFieldValue("IDCONTROL");
							((DropDownList)this.Page.FindControl(id_field)).Enabled = true;
						}

						else if(id_field == "RDO")
						{
							id_field = conn3.GetFieldValue("IDCONTROL");
							((RadioButton)this.Page.FindControl(id_field)).Enabled = true;
						}
						else if(id_field == "BTN")
						{
							id_field = conn3.GetFieldValue("IDCONTROL");
							((Button)this.Page.FindControl(id_field)).Enabled = true;
						}
					}
				}
			}

			/*string id = "";

			conn2.QueryString = "EXEC DCM_DATA_ERROR_CHECKING '" + Request.QueryString["cifno"] + "','1'";
			conn2.ExecuteQuery();

			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				string err_msg = conn2.GetFieldValue(i, "ERR_MSG").ToString().Replace(";", "");

				conn3.QueryString = "SELECT IDCONTROL FROM DCM_TABLE_ERROR WHERE PAGE = 'CIFGeneralDataBU.aspx' AND MESSAGE = '" + err_msg.Trim() + "'";
				conn3.ExecuteQuery();

				if (conn3.GetFieldValue("IDCONTROL") != "")
				{
					id = "LBL_" + conn3.GetFieldValue("IDCONTROL");
					((Label)this.Page.FindControl(id)).ForeColor = Color.Red;
				}
			}*/
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
			ClearGenData();
		}

		private void ClearGenData()
		{
			//TXT_CIFNO.Text                = "";
			//TXT_CUST_NAME.Text            = "";
			TXT_NAMA_PELAPOR.Text           = "";
			DDL_NAMA_PREFIK.SelectedValue   = "";
			DDL_JNS_NASABAH.SelectedValue   = "";
			TXT_TGL_BOD.Text                = "";
			DDL_BLN_BOD.SelectedValue       = "";
			TXT_THN_BOD.Text                = "";
			TXT_TMP_AKTA.Text               = "";
			DDL_JNS_IDI.SelectedValue       = "";
			TXT_NO_IDI.Text                 = "";
			TXT_TGL_KAD.Text                = "";
			DDL_BLN_KAD.SelectedValue       = "";
			TXT_THN_KAD.Text                = "";
			TXT_TEMPAT_IDI.Text             = "";
			DDL_JNS_DEB.SelectedValue       = "";
			DDL_GOL_NASABAH.SelectedValue   = "";
			DDL_KWRG.SelectedValue          = "";
			DDL_KODE_INDUSTRI.SelectedValue = "";
			DDL_KODE_NEGARA.SelectedValue   = "";
			TXT_ALAMAT1.Text                = "";			
			TXT_KECAMATAN.Text              = "";
			TXT_CU_COMPZIPCODE.Text         = "";
			TXT_KOTA.Text                   = "";
			DDL_JNS_ALAMAT.SelectedValue    = "";
			DDL_LOKASI_DATI.SelectedValue   = "";
			DDL_LBG_PEM.SelectedValue       = "";
			DDL_PEM_COMP.SelectedValue      = "";
			DDL_BLN_PEM.SelectedValue       = "";
			DDL_HUB_KEL.SelectedValue       = "";
			DDL_HUB_BANK.SelectedValue      = "";
			DDL_PIC.SelectedValue           = "";
			TXT_NO_APP.Text                 = "";
			TXT_TGL_APP.Text                = "";
			DDL_BLN_APP.SelectedValue       = "";
			TXT_THN_APP.Text                = "";
			TXT_NO_APT.Text                 = "";
			TXT_TGL_APT.Text                = "";
			DDL_BLN_APT.SelectedValue       = "";
			TXT_THN_APT.Text                = "";
			TXT_TLP_KANTOR.Text             = "";
			TXT_TELP_RMH.Text               = "";
			TXT_MOBILE.Text                 = "";
			TXT_OPR.Text                    = "";
			TXT_NON_OPR.Text                = "";
			DDL_VALUTA.SelectedValue        = "";
		}
		
		private void ViewMenu()
		{
			MenuCIF.Controls.Clear();
			try 
			{
				conn.QueryString = "SELECT * FROM SCREENMENU WHERE MENUCODE = '"+Request.QueryString["mc"]+"' AND SM_ID IN ('DCM010101','DCM010102','DCM010103')";
				conn.ExecuteQuery();		
				
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "cifno=" + Request.QueryString["cifno"] + "&msg=" + Request.QueryString["msg"] + "&tc=" + Request.QueryString["tc"] + "&from_appr=1" + "&flag=1";
						else
							strtemp = "&cifno=" + Request.QueryString["cifno"] + "&msg=" + Request.QueryString["msg"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&from_appr=1" + "&flag=1";
					}
					else 
					{
						strtemp = ""; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					MenuCIF.Controls.Add(t);
					MenuCIF.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		protected void BTN_SEARCHCOMP_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_COMPZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("CIFListData2.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			/*
			BodyMaintenanceRequest.additionalAddressLine1 = "";
			BodyMaintenanceRequest.additionalAddressLine2 = "";
			BodyMaintenanceRequest.additionalAddressLine3 = "";
			BodyMaintenanceRequest.additionalAddressLine4 = "";
			BodyMaintenanceRequest.additionalID = "";
			BodyMaintenanceRequest.additionalIDType = "";
			BodyMaintenanceRequest.addressLine1 = "";
			BodyMaintenanceRequest.addressLine2 = "";
			BodyMaintenanceRequest.addressLine3 = "";
			BodyMaintenanceRequest.addressLine4 = "";
			BodyMaintenanceRequest.amount = "";
			BodyMaintenanceRequest.amount1 = "";
			BodyMaintenanceRequest.amount2 = "";
			BodyMaintenanceRequest.bankNumber = "";
			BodyMaintenanceRequest.birthIncorporationPlace = "";
			BodyMaintenanceRequest.branchNumber = "";
			BodyMaintenanceRequest.businessUnitCode = "";
			BodyMaintenanceRequest.code1 = "";
			BodyMaintenanceRequest.codeField_C3 = "";
			BodyMaintenanceRequest.codeField_T3 = "";
			BodyMaintenanceRequest.codeField1 = "";
			BodyMaintenanceRequest.codeField1_T2 = "";
			BodyMaintenanceRequest.codeField5 = "";
			BodyMaintenanceRequest.codeField5_C2 = "";
			BodyMaintenanceRequest.countryOfCitizenship = "";
			BodyMaintenanceRequest.currencyCode = "";
			BodyMaintenanceRequest.currencyCode1 = "";
			BodyMaintenanceRequest.currencyCode2 = "";
			BodyMaintenanceRequest.currencyCode3 = "";
			BodyMaintenanceRequest.currentSalary = "";
			BodyMaintenanceRequest.customerName = "";
			BodyMaintenanceRequest.customerNumber = "";
			BodyMaintenanceRequest.customerTypeCode = "";
			BodyMaintenanceRequest.custPreviousName1 = "";
			BodyMaintenanceRequest.custPreviousName2 = "";
			BodyMaintenanceRequest.dobDDMMYYYY = "";
			BodyMaintenanceRequest.employeeDirectSuperiorName1 = "";
			BodyMaintenanceRequest.employeeDirectSuperiorName2 = "";
			BodyMaintenanceRequest.employementEndDate = "";
			BodyMaintenanceRequest.employementStartDate = "";
			BodyMaintenanceRequest.employerIndustryCode = "";
			BodyMaintenanceRequest.employerName = "";
			BodyMaintenanceRequest.fax = "";
			BodyMaintenanceRequest.genderCode = "";
			BodyMaintenanceRequest.handphone = "";
			BodyMaintenanceRequest.hubunganDenganBank = "";
			BodyMaintenanceRequest.hubunganKeluarga = "";
			BodyMaintenanceRequest.idIssuePlace = "";
			BodyMaintenanceRequest.idNumber = "";
			BodyMaintenanceRequest.idtypeCode = "";
			BodyMaintenanceRequest.informationDate = "";
			BodyMaintenanceRequest.jenisDebitur = "";
			BodyMaintenanceRequest.jobDesignationCode = "";
			BodyMaintenanceRequest.lokasiI = "";
			BodyMaintenanceRequest.memberOfKoperasi = "";
			BodyMaintenanceRequest.motherMaidenName = "";
			BodyMaintenanceRequest.occupationCode = "";
			BodyMaintenanceRequest.pemilikDebitur = "";
			BodyMaintenanceRequest.postalCode = "";
			BodyMaintenanceRequest.prefixName = "";
			BodyMaintenanceRequest.previousSalary = "";
			BodyMaintenanceRequest.ratingCode = "";
			BodyMaintenanceRequest.ratingDate = "";
			BodyMaintenanceRequest.ratingSource = "";
			BodyMaintenanceRequest.remarkLine1 = "";
			BodyMaintenanceRequest.remarkLine2 = "";
			BodyMaintenanceRequest.remarkLine3 = "";
			BodyMaintenanceRequest.remarkLine4 = "";
			BodyMaintenanceRequest.reviewDate = "";
			BodyMaintenanceRequest.telephone = "";
			BodyMaintenanceRequest.titleAfterName = "";
			BodyMaintenanceRequest.titleBeforName = "";
			BodyMaintenanceRequest.uicUserDefined = "";
			BodyMaintenanceRequest.wilayahTLahir = "";

			ResponseMaintenanceClass = MainClass.CIFMandatoryMaintenanceService(BodyMaintenanceRequest);
			RetrieveDataFromSOAResponse(ResponseMaintenanceClass);
			*/
		}
		
		/*
		public void RetrieveDataFromSOAResponse(DQM.CIFMandatoryMaintenance.CIFMandatoryMaintenanceResponse response)
		{
			if (response.soaHeader.responseCode.ToString() == "1")
			{
				VAR_CifNo = "";
				VAR_CustomerName = "";
				VAR_NamaPelaporan = "";
				VAR_NamaPrefik = "";
				VAR_JenisNasabah = "";
				VAR_TglBerdiriPerusahaanDay = "";
				VAR_TglBerdiriPerusahaanMonth = "";
				VAR_TglBerdiriPerusahaanYear = "";
				VAR_TempatAktaDikeluarkan = "";
				VAR_JenisIDUtama = "";
				VAR_NoIDUtama = "";
				VAR_TglKadaluarsaIDUtamaDay = "";
				VAR_TglKadaluarsaIDUtamaMonth = "";
				VAR_TglKadaluarsaIDUtamaYear = "";
				VAR_TempatDikeluarkanIDUtama = "";
				VAR_JenisDebitur = "";
				VAR_GolonganNasabah = "";
				VAR_Kewarganegaraan = "";
				VAR_KodeIndustri = "";
				VAR_NoAPP = "";
				VAR_TanggalAPPDay = "";
				VAR_TanggalAPPMonth = "";
				VAR_TanggalAPPYear = "";
				VAR_NoAPT = "";
				VAR_TanggalAPTDay = "";
				VAR_TanggalAPTMonth = "";
				VAR_TanggalAPTYear = "";
				VAR_NoTeleponKantor = "";
				VAR_KodeNegara = "";
				VAR_Alamat1 = "";
				VAR_Alamat2 = "";
				VAR_Kecamatan = "";
				VAR_ZipCode = "";
				VAR_Kota = "";
				VAR_JenisAlamat = "";
				VAR_LokasiDatiII = "";
				VAR_LembagaPemeringkat = "";
				VAR_PeringkatPerusahaan = "";
				VAR_TanggalPemeringkatanDay = "";
				VAR_TanggalPemeringkatanMonth = "";
				VAR_TanggalPemeringkatanYear = "";
				VAR_HubungandenganBank = "";
				VAR_HubungandenganKeluarga = "";
				VAR_PICDataOwner = "";
				VAR_GoPublic = "";
				VAR_NoTelponRumah = "";
				VAR_NoTelponMobile = "";
				VAR_PendapatanOperasional = "";
				VAR_PendapatanNonOperasional = "";
				VAR_Valuta = "";

				CONTROL_to_VAR();
			}
			else
			{
				Tools.popMessage(this, "SOA Connection Fail!");
			}
		}
		*/

		private void CONTROL_to_VAR()
		{
			VAR_CifNo = TXT_CIFNO.Text.ToString();
			VAR_CustomerName = TXT_CUST_NAME.Text.ToString();
			VAR_CifNo = TXT_CIFNO.Text.ToString();
			VAR_CustomerName = TXT_CUST_NAME.Text.ToString();
			VAR_NamaPelaporan = TXT_NAMA_PELAPOR.Text.ToString();
			VAR_NamaPrefik = DDL_NAMA_PREFIK.SelectedValue.ToString();
			VAR_JenisNasabah = DDL_JNS_NASABAH.SelectedValue.ToString();
			VAR_TglBerdiriPerusahaanDay = TXT_TGL_BOD.Text;
			VAR_TglBerdiriPerusahaanMonth = DDL_BLN_BOD.SelectedValue;
			VAR_TglBerdiriPerusahaanYear = TXT_THN_BOD.Text;
			VAR_TempatAktaDikeluarkan = TXT_TMP_AKTA.Text;
			VAR_JenisIDUtama = DDL_JNS_IDI.SelectedValue;
			VAR_NoIDUtama = TXT_NO_IDI.Text;
			VAR_TglKadaluarsaIDUtamaDay = TXT_TGL_KAD.Text;
			VAR_TglKadaluarsaIDUtamaMonth = DDL_BLN_KAD.SelectedValue;
			VAR_TglKadaluarsaIDUtamaYear = TXT_THN_KAD.Text;
			VAR_TempatDikeluarkanIDUtama = TXT_TEMPAT_IDI.Text;
			VAR_JenisDebitur = DDL_JNS_DEB.SelectedValue;
			VAR_GolonganNasabah = DDL_GOL_NASABAH.SelectedValue;
			VAR_Kewarganegaraan = DDL_KWRG.SelectedValue;
			VAR_KodeIndustri = DDL_KODE_INDUSTRI.SelectedValue;
			VAR_NoAPP = TXT_NO_APP.Text;
			VAR_TanggalAPPDay = TXT_TGL_APP.Text;
			VAR_TanggalAPPMonth = DDL_BLN_APP.SelectedValue;
			VAR_TanggalAPPYear = TXT_THN_APP.Text;
			VAR_NoAPT = TXT_NO_APT.Text;
			VAR_TanggalAPTDay = TXT_TGL_APT.Text;
			VAR_TanggalAPTMonth = DDL_BLN_APT.SelectedValue;
			VAR_TanggalAPTYear = TXT_THN_APT.Text;
			VAR_NoTeleponKantor = TXT_TLP_KANTOR.Text;
			VAR_KodeNegara = DDL_KODE_NEGARA.SelectedValue;
			VAR_Alamat1 = TXT_ALAMAT1.Text;
			VAR_Alamat2 = TXT_ALAMAT2.Text;
			VAR_Kecamatan = TXT_KECAMATAN.Text;
			VAR_ZipCode = TXT_CU_COMPZIPCODE.Text;
			VAR_Kota = TXT_KOTA.Text;
			VAR_JenisAlamat = DDL_JNS_ALAMAT.SelectedValue;
			VAR_LokasiDatiII = DDL_LOKASI_DATI.SelectedValue;
			VAR_LembagaPemeringkat = DDL_LBG_PEM.SelectedValue;
			VAR_PeringkatPerusahaan = DDL_PEM_COMP.SelectedValue;
			VAR_TanggalPemeringkatanDay = TXT_TGL_PEMRINGKAT.Text;
			VAR_TanggalPemeringkatanMonth = DDL_BLN_PEM.SelectedValue;
			VAR_TanggalPemeringkatanYear = TXT_THN_PEMRINGKAT.Text;
			VAR_HubungandenganKeluarga = DDL_HUB_KEL.SelectedValue;
			VAR_HubungandenganBank = DDL_HUB_BANK.SelectedValue;
			VAR_PICDataOwner = DDL_PIC.SelectedValue;
			VAR_GoPublic = RDO_GOPUBLIC.SelectedValue;
			VAR_NoTelponRumah = TXT_TELP_RMH.Text;
			VAR_NoTelponMobile = TXT_MOBILE.Text;
			VAR_PendapatanOperasional = TXT_OPR.Text;
			VAR_PendapatanNonOperasional = TXT_NON_OPR.Text;
			VAR_Valuta = DDL_VALUTA.SelectedValue;
		}
	}
}
