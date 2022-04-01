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
	/// Summary description for CIFGenDataPO.
	/// </summary>
	public partial class CIFGenDataPO : System.Web.UI.Page
	{
		protected Connection conn;
		protected Connection2 conn2;
		protected Connection2 conn3;

		/* Deklarasi Variable */
		private string VAR_CIFNo;
		private string VAR_CustomerName;
		private string VAR_NamaPelaporan;
		private string VAR_NamaPrefik;
		private string VAR_JenisNasabah;
		private string VAR_TanggalLahirDay;
		private string VAR_TanggalLahirMonth;
		private string VAR_TanggalLahirYear;
		private string VAR_TempatLahir;
		private string VAR_JenisIDUtama;
		private string VAR_NoIDUtama;
		private string VAR_TglKadaluarsaIDUtamaDay;
		private string VAR_TglKadaluarsaIDUtamaMonth;
		private string VAR_TglKadaluarsaIDUtamaYear;
		private string VAR_TempatDikeluarkanIDUtama;
		private string VAR_JenisDebitur;
		private string VAR_GolonganNasabah;
		private string VAR_Kewarganegaraan;
		private string VAR_NoTeleponMobile;
		private string VAR_NoTeleponRumah;
		private string VAR_KodeNegara;
		private string VAR_Alamat1;
		private string VAR_Alamat2;
		private string VAR_Kecamatan;
		private string VAR_ZipCode;
		private string VAR_Kota;
		private string VAR_JenisAlamat;
		private string VAR_LokasiDatiII;
		private string VAR_NamaGadisIbuKandung;
		private string VAR_HubungandenganBank;
		private string VAR_HubungandenganKeluarga;
		private string VAR_JenisKelamin;
		private string VAR_KodeIndustri;
		private string VAR_PICDataOwner;		
		private string VAR_NoNPWP;

		/* 
		 * Connect class SOA
		private DQM.SOA.SOA_DQM MainClass = new DQM.SOA.SOA_DQM();

		private DQM.CIFInquiry.body CIFInquiryBody;
		private DQM.CIFInquiry.CIFInquiryResponse CIFInquiryResponse;
		*/

		protected void Page_Load(object sender, System.EventArgs e)
		{
			ViewField();

			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			conn2 = new Connection2(ConfigurationSettings.AppSettings["conn2"]);
			conn3 = new Connection2(ConfigurationSettings.AppSettings["conn2"]);

			if(!IsPostBack)
			{
				DDL_NAMA_PREFIK.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_JNS_NASABAH.Items.Add(new ListItem("Pilih--", ""));
				DDL_BLN_LAHIR.Items.Add(new ListItem("--Pilih--", ""));
				DDL_JNS_IDI.Items.Add(new ListItem("--Pilih--",""));				
				DDL_BLN_KADAL.Items.Add(new ListItem("--Pilih--",""));
				DDL_JNS_DEBITUR.Items.Add(new ListItem("--Pilih--", ""));
				DDL_GOL_NASABAH.Items.Add(new ListItem("--Pilih--", ""));
				DDL_KEWARGANEGARAAN.Items.Add(new ListItem("--Pilih--", ""));
				DDL_JNS_ALAMAT.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_DATI.Items.Add(new ListItem("Pilih--", ""));
				DDL_HUB_BANK.Items.Add(new ListItem("--Pilih--", ""));
				DDL_HUB_FAM.Items.Add(new ListItem("--Pilih--",""));
				DDL_JNS_KELAMIN.Items.Add(new ListItem("--Pilih--",""));
				DDL_KODE_INDUSTRY.Items.Add(new ListItem("--Pilih--",""));
				DDL_PIC_DATA_OWNER.Items.Add(new ListItem("--Pilih--", ""));

				for (int i=1; i<=12; i++)
				{
					DDL_BLN_LAHIR.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_KADAL.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));					
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
					DDL_JNS_DEBITUR.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_GOLNASABAH";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_GOL_NASABAH.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_KODENEGARA";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_KEWARGANEGARAAN.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_JENISALAMAT";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JNS_ALAMAT.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_LOKASIDATI ORDER BY CONVERT(INT, LOCATIONID)";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_DATI.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_HUBDGKELUARGA";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_HUB_FAM.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_HUBDENGANBANK ORDER BY CONVERT(INT, HUBEXEC_CODE)";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_HUB_BANK.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_JENISKELAMIN";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JNS_KELAMIN.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_PICDATAOWNER";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_PIC_DATA_OWNER.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_KODEINDUSTRI";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_KODE_INDUSTRY.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));
                
				/*************************************************************************************************/
				//RetrieveSOA();

				/*Cek error message*/
				CheckError();
			}
			ViewMenu();
		}

		private void ViewField()
		{
			TXT_NAMA_PELAPORAN.Enabled = false;
			DDL_NAMA_PREFIK.Enabled = false;
			DDL_JNS_NASABAH.Enabled = false;
			TXT_TGL_LAHIR.Enabled = false;
			DDL_BLN_LAHIR.Enabled = false;
			TXT_THN_LAHIR.Enabled = false;
			TXT_TMP_LAHIR.Enabled = false;
			DDL_JNS_IDI.Enabled = false;
			TXT_IDI_UTAMA.Enabled = false;
			TXT_TGL_KADAL.Enabled = false;
			DDL_BLN_KADAL.Enabled = false;
			TXT_THN_KADAL.Enabled = false;
			TXT_TEMPAT_IDI.Enabled = false;
			DDL_JNS_DEBITUR.Enabled = false;
			DDL_GOL_NASABAH.Enabled = false;
			DDL_KEWARGANEGARAAN.Enabled = false;
			TXT_TELP_M.Enabled = false;
			TXT_TELP_R.Enabled = false;
			DDL_KODE_NEGARA.Enabled = false;
			TXT_ALAMAT1.Enabled = false;
			TXT_ALAMAT2.Enabled = false;
			TXT_KECAMATAN.Enabled = false;
			TXT_CU_COMPZIPCODE.Enabled = false;
			BTN_SEARCHCOMP.Enabled = false;
			TXT_CITY.Enabled = false;
			DDL_JNS_ALAMAT.Enabled = false;
			DDL_DATI.Enabled = false;
			TXT_MOTHER_NAME.Enabled = false;
			DDL_HUB_BANK.Enabled = false;
			DDL_HUB_FAM.Enabled = false;
			DDL_JNS_KELAMIN.Enabled = false;
			DDL_KODE_INDUSTRY.Enabled = false;
			DDL_PIC_DATA_OWNER.Enabled = false;
			TXT_NPWP.Enabled = false;
		}

		private void CheckError()
		{
			string id = "", id_field = "";

			conn2.QueryString = "EXEC DCM_DATA_ERROR_CHECKING '" + Request.QueryString["cifno"] + "','1'";
			conn2.ExecuteQuery();

			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				string err_msg = conn2.GetFieldValue(i, "ERR_MSG").ToString().Replace(";","");

				conn3.QueryString = "SELECT IDCONTROL FROM DCM_TABLE_ERROR WHERE PAGE = 'CIFGenDataPO.aspx' AND MESSAGE = '" + err_msg.Trim() + "'";
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
		}

		private void ViewMenu()
		{
			MenuCIF.Controls.Clear();
			try
			{
				conn.QueryString = "SELECT * FROM SCREENMENU WHERE MENUCODE = '" + Request.QueryString["mc"] + "' AND SM_ID IN ('DCM010104','DCM010105')";
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
							strtemp = "cifno=" + Request.QueryString["cifno"] + "&msg=" + Request.QueryString["msg"] + "&tc=" + Request.QueryString["tc"] + "&from_appr=1" + "&flag=1";
						else
							strtemp = "&cifno=" + Request.QueryString["cifno"] + "&msg=" + Request.QueryString["msg"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&from_appr=1" + "&flag=1";
					}
					else
					{
						strtemp = "";
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3) + strtemp;
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

		/*
		private void RetrieveSOA()
		{
			CIFInquiryBody = new DQM.CIFInquiry.body();
			CIFInquiryBody.CIFNumber = Request.QueryString["cifno"];
			CIFInquiryResponse = MainClass.CIFMandatoryInquiryService(CIFInquiryBody);

			if (CIFInquiryResponse.soaHeader.responseCode == 1)
			{
				try { VAR_CIFNo                         = Request.QueryString["cifno"]; }
				catch { VAR_CIFNo                       = ""; }
				try { VAR_CIFNo                         = Request.QueryString["cifno"];}
				catch { VAR_CIFNo                       = ""; }
				try { VAR_CustomerName                  = CIFInquiryResponse.body.CIFName1.ToString();}
				catch {VAR_CustomerName                 = ""; }
				try { VAR_NamaPelaporan                 = CIFInquiryResponse.body.CIFName2.ToString(); }
				catch { VAR_NamaPelaporan               = ""; }
				try { VAR_NamaPrefik                    = "";}
				catch {VAR_NamaPrefik                   = ""; }
				try { VAR_JenisNasabah                  = CIFInquiryResponse.body.customerTypeCode.ToString();}
				catch {VAR_JenisNasabah                 = ""; }
				try { VAR_TanggalLahirDay               = CIFInquiryResponse.body.dayOfBirth.Day.ToString();}
				catch {VAR_TanggalLahirDay              = ""; }
				try { VAR_TanggalLahirMonth             = CIFInquiryResponse.body.dayOfBirth.Month.ToString();}
				catch {VAR_TanggalLahirMonth            = ""; }
				try { VAR_TanggalLahirYear              = CIFInquiryResponse.body.dayOfBirth.Year.ToString();}
				catch {VAR_TanggalLahirYear             = ""; }
				try { VAR_TempatLahir                   = CIFInquiryResponse.body.birthIncorporationPlace.ToString();}
				catch {VAR_TempatLahir                  = ""; }
				try { VAR_JenisIDUtama                  = CIFInquiryResponse.body.IDTypeCode.ToString();}
				catch {VAR_JenisIDUtama                 = ""; }
				try { VAR_NoIDUtama                     = CIFInquiryResponse.body.IDNumber.ToString();}
				catch {VAR_NoIDUtama                    = ""; }
				try { VAR_TglKadaluarsaIDUtamaDay       = CIFInquiryResponse.body.IDExpiryDate.Day.ToString();}
				catch {VAR_TglKadaluarsaIDUtamaDay      = ""; }
				try { VAR_TglKadaluarsaIDUtamaMonth     = CIFInquiryResponse.body.IDExpiryDate.Month.ToString();}
				catch {VAR_TglKadaluarsaIDUtamaMonth    = ""; }
				try { VAR_TglKadaluarsaIDUtamaYear      = CIFInquiryResponse.body.IDExpiryDate.Year.ToString();}
				catch {VAR_TglKadaluarsaIDUtamaYear     = ""; }
				try { VAR_TempatDikeluarkanIDUtama      = CIFInquiryResponse.body.IDIssuePlace.ToString();}
				catch {VAR_TempatDikeluarkanIDUtama     = ""; }
				try { VAR_JenisDebitur                  = "";}
				catch {VAR_JenisDebitur                 = ""; }
				try { VAR_GolonganNasabah               = "";}
				catch {VAR_GolonganNasabah              = ""; }
				try { VAR_Kewarganegaraan               = CIFInquiryResponse.body.countryOfCitizenship.ToString();}
				catch {VAR_Kewarganegaraan              = ""; }
				try { VAR_NoTeleponMobile               = CIFInquiryResponse.body.handphone.ToString();}
				catch {VAR_NoTeleponMobile              = ""; }
				try { VAR_NoTeleponRumah                = CIFInquiryResponse.body.telephone.ToString();}
				catch {VAR_NoTeleponRumah               = ""; }
				try { VAR_KodeNegara                    = CIFInquiryResponse.body.country.ToString();}
				catch {VAR_KodeNegara                   = ""; }
				try { VAR_Alamat1                       = CIFInquiryResponse.body.address1.ToString();}
				catch {VAR_Alamat1                      = ""; }
				try { VAR_Alamat2                       = CIFInquiryResponse.body.address2.ToString();}
				catch {VAR_Alamat2                      = ""; }
				try { VAR_Kecamatan                     = "";}
				catch {VAR_Kecamatan                    = ""; }
				try { VAR_ZipCode                       = CIFInquiryResponse.body.postalCode.ToString();}
				catch {VAR_ZipCode                      = ""; }
				try { VAR_Kota                          = "";}
				catch {VAR_Kota                         = ""; }
				try { VAR_JenisAlamat                   = "";}
				catch {VAR_JenisAlamat                  = ""; }
				try { VAR_LokasiDatiII                  = "";}
				catch {VAR_LokasiDatiII                 = ""; }
				try { VAR_NamaGadisIbuKandung           = CIFInquiryResponse.body.motherMaidenName.ToString();}
				catch {VAR_NamaGadisIbuKandung          = ""; }
				try { VAR_HubungandenganBank            = "";}
				catch {VAR_HubungandenganBank           = ""; }
				try { VAR_HubungandenganKeluarga        = "";}
				catch {VAR_HubungandenganKeluarga       = ""; }
				try { VAR_JenisKelamin                  = CIFInquiryResponse.body.sexCode.ToString();}
				catch {VAR_JenisKelamin                 = ""; }
				try { VAR_KodeIndustri                  = CIFInquiryResponse.body.internalIndustryCode.ToString();}
				catch {VAR_KodeIndustri                 = ""; }
				try { VAR_PICDataOwner                  = "";}
				catch {VAR_PICDataOwner                 = ""; }
				try { VAR_NoNPWP                        = "";}
				catch {VAR_NoNPWP                       = ""; }

				//Put hidden variable here
				try
				{
                    
				}
				catch
				{
                    
				}
			}
			else
			{
				Tools.popMessage(this, CIFInquiryResponse.soaHeader.responseMessage.ToString());
				Response.Redirect("");
			}
			VAR_to_CONTROL();
		}
		*/

		private void VAR_to_CONTROL()
		{
			TXT_CIF_NO.Text                     = VAR_CIFNo;
			TXT_CUST_NAME.Text                  = VAR_CustomerName;
			TXT_MOTHER_NAME.Text                = VAR_NamaPelaporan;
			DDL_NAMA_PREFIK.SelectedValue       = VAR_NamaPrefik;
			DDL_JNS_NASABAH.SelectedValue       = VAR_JenisNasabah;
			TXT_TGL_LAHIR.Text                  = VAR_TanggalLahirDay;
			DDL_BLN_LAHIR.SelectedValue         = VAR_TanggalLahirMonth;
			TXT_THN_LAHIR.Text                  = VAR_TanggalLahirYear;
			TXT_TMP_LAHIR.Text                  = VAR_TempatLahir;
			DDL_JNS_IDI.SelectedValue           = VAR_JenisIDUtama;
			TXT_IDI_UTAMA.Text                  = VAR_NoIDUtama;
			TXT_TGL_KADAL.Text                  = VAR_TglKadaluarsaIDUtamaDay;
			DDL_BLN_KADAL.SelectedValue         = VAR_TglKadaluarsaIDUtamaMonth;
			TXT_THN_KADAL.Text                  = VAR_TglKadaluarsaIDUtamaYear;
			TXT_TEMPAT_IDI.Text                 = VAR_TempatDikeluarkanIDUtama;
			DDL_JNS_DEBITUR.SelectedValue       = VAR_JenisDebitur;
			DDL_GOL_NASABAH.SelectedValue       = VAR_GolonganNasabah;
			DDL_KEWARGANEGARAAN.SelectedValue   = VAR_Kewarganegaraan;
			TXT_TELP_M.Text                     = VAR_NoTeleponMobile;
			TXT_TELP_R.Text                     = VAR_NoTeleponRumah;
			DDL_KODE_NEGARA.SelectedValue       = VAR_KodeNegara;
			TXT_ALAMAT1.Text                    = VAR_Alamat1;
			TXT_ALAMAT2.Text                    = VAR_Alamat2;
			TXT_KECAMATAN.Text                  = VAR_Kecamatan;
			TXT_CU_COMPZIPCODE.Text             = VAR_ZipCode;
			TXT_CITY.Text                       = VAR_Kota;
			DDL_JNS_ALAMAT.SelectedValue        = VAR_JenisAlamat;
			DDL_DATI.SelectedValue              = VAR_LokasiDatiII;
			TXT_MOTHER_NAME.Text                = VAR_NamaGadisIbuKandung;
			DDL_HUB_BANK.SelectedValue          = VAR_HubungandenganBank;
			DDL_HUB_FAM.SelectedValue           = VAR_HubungandenganKeluarga;
			DDL_JNS_KELAMIN.SelectedValue       = VAR_JenisKelamin;
			DDL_KODE_INDUSTRY.SelectedValue     = VAR_KodeIndustri;
			DDL_PIC_DATA_OWNER.SelectedValue    = VAR_PICDataOwner;
			TXT_NPWP.Text                       = VAR_NoNPWP;
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{
			//TXT_CIF_NO.Text                   = "";
			//TXT_CUST_NAME.Text                = "";
			TXT_NAMA_PELAPORAN.Text             = "";
			DDL_NAMA_PREFIK.SelectedValue       = "";
			DDL_JNS_NASABAH.SelectedValue       = "";
			TXT_TGL_LAHIR.Text                  = "";
			DDL_BLN_LAHIR.SelectedValue         = "";
			TXT_THN_LAHIR.Text                  = "";
			TXT_TMP_LAHIR.Text                  = "";
			DDL_JNS_IDI.SelectedValue           = "";
			TXT_IDI_UTAMA.Text                  = "";
			TXT_TGL_KADAL.Text                  = "";
			DDL_BLN_KADAL.SelectedValue         = "";
			TXT_THN_KADAL.Text                  = "";
			TXT_TEMPAT_IDI.Text                 = "";
			DDL_JNS_DEBITUR.SelectedValue       = "";
			DDL_GOL_NASABAH.SelectedValue       = "";
			DDL_KEWARGANEGARAAN.SelectedValue   = "";
			DDL_KODE_NEGARA.SelectedValue       = "";
			TXT_ALAMAT1.Text                    = "";
			TXT_ALAMAT2.Text                    = "";
			TXT_KECAMATAN.Text                  = "";
			TXT_CU_COMPZIPCODE.Text             = "";
			TXT_CITY.Text                       = "";
			DDL_JNS_ALAMAT.SelectedValue        = "";
			DDL_DATI.SelectedValue              = "";
			TXT_MOTHER_NAME.Text                = "";
			DDL_HUB_BANK.SelectedValue          = "";
			DDL_HUB_FAM.SelectedValue           = "";
			DDL_JNS_KELAMIN.SelectedValue       = "";
			DDL_KODE_INDUSTRY.SelectedValue     = "";
			DDL_PIC_DATA_OWNER.SelectedValue    = "";
			TXT_TELP_M.Text                     = "";
			TXT_TELP_R.Text                     = "";
			TXT_NPWP.Text                       = "";

			/* Hidden Variable
             
			 */
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("CIFListData2.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		/*
		private DQM.CIFMandatoryMaintenance.body BodyMaintenanceRequest = new DQM.CIFMandatoryMaintenance.body();
		private DQM.CIFMandatoryMaintenance.CIFMandatoryMaintenanceResponse ResponseMaintenanceClass = new DQM.CIFMandatoryMaintenance.CIFMandatoryMaintenanceResponse();
		*/

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			/*
			CONTROL_to_VAR();

			BodyMaintenanceRequest.additionalAddressLine1       = "";
			BodyMaintenanceRequest.additionalAddressLine2       = "";
			BodyMaintenanceRequest.additionalAddressLine3       = "";
			BodyMaintenanceRequest.additionalAddressLine4       = "";
			BodyMaintenanceRequest.additionalID                 = "";
			BodyMaintenanceRequest.additionalIDType             = "";
			BodyMaintenanceRequest.addressLine1                 = VAR_Alamat1;
			BodyMaintenanceRequest.addressLine2                 = VAR_Alamat2;
			BodyMaintenanceRequest.addressLine3                 = "";
			BodyMaintenanceRequest.addressLine4                 = "";
			BodyMaintenanceRequest.amount                       = "";
			BodyMaintenanceRequest.amount1                      = "";
			BodyMaintenanceRequest.amount2                      = "";
			BodyMaintenanceRequest.bankNumber                   = "";
			BodyMaintenanceRequest.birthIncorporationPlace      = VAR_TempatLahir;
			BodyMaintenanceRequest.branchNumber                 = "";
			BodyMaintenanceRequest.businessUnitCode             = "";
			BodyMaintenanceRequest.code1                        = "";
			BodyMaintenanceRequest.codeField_C3                 = "";
			BodyMaintenanceRequest.codeField_T3                 = "";
			BodyMaintenanceRequest.codeField1                   = "";
			BodyMaintenanceRequest.codeField1_T2                = "";
			BodyMaintenanceRequest.codeField5                   = "";
			BodyMaintenanceRequest.codeField5_C2                = "";
			BodyMaintenanceRequest.countryOfCitizenship         = VAR_Kewarganegaraan;
			BodyMaintenanceRequest.currencyCode                 = "";
			BodyMaintenanceRequest.currencyCode1                = "";
			BodyMaintenanceRequest.currencyCode2                = "";
			BodyMaintenanceRequest.currencyCode3                = "";
			BodyMaintenanceRequest.currentSalary                = "";
			BodyMaintenanceRequest.customerName                 = VAR_CustomerName;
			BodyMaintenanceRequest.customerNumber               = VAR_CIFNo;
			BodyMaintenanceRequest.customerTypeCode             = VAR_JenisNasabah;
			BodyMaintenanceRequest.custPreviousName1            = "";
			BodyMaintenanceRequest.custPreviousName2            = "";
			BodyMaintenanceRequest.dobDDMMYYYY                  = VAR_TanggalLahirDay + VAR_TanggalLahirMonth + VAR_TanggalLahirYear;
			BodyMaintenanceRequest.employeeDirectSuperiorName1  = "";
			BodyMaintenanceRequest.employeeDirectSuperiorName2  = "";
			BodyMaintenanceRequest.employementEndDate           = "";
			BodyMaintenanceRequest.employementStartDate         = "";
			BodyMaintenanceRequest.employerIndustryCode         = "";
			BodyMaintenanceRequest.employerName                 = "";
			BodyMaintenanceRequest.fax                          = "";
			BodyMaintenanceRequest.genderCode                   = VAR_JenisKelamin;
			BodyMaintenanceRequest.handphone                    = VAR_NoTeleponMobile;
			BodyMaintenanceRequest.hubunganDenganBank           = VAR_HubungandenganBank;
			BodyMaintenanceRequest.hubunganKeluarga             = VAR_HubungandenganKeluarga;
			BodyMaintenanceRequest.idIssuePlace                 = VAR_TempatDikeluarkanIDUtama;
			BodyMaintenanceRequest.idNumber                     = VAR_NoIDUtama;
			BodyMaintenanceRequest.idtypeCode                   = VAR_JenisIDUtama;
			BodyMaintenanceRequest.informationDate              = "";
			BodyMaintenanceRequest.jenisDebitur                 = "";
			BodyMaintenanceRequest.jobDesignationCode           = "";
			BodyMaintenanceRequest.lokasiI                      = VAR_LokasiDatiII;
			BodyMaintenanceRequest.memberOfKoperasi             = "";
			BodyMaintenanceRequest.motherMaidenName             = VAR_NamaGadisIbuKandung;
			BodyMaintenanceRequest.occupationCode               = "";
			BodyMaintenanceRequest.pemilikDebitur               = "";
			BodyMaintenanceRequest.postalCode                   = VAR_ZipCode;
			BodyMaintenanceRequest.prefixName                   = "";
			BodyMaintenanceRequest.previousSalary               = "";
			BodyMaintenanceRequest.ratingCode                   = "";
			BodyMaintenanceRequest.ratingDate                   = "";
			BodyMaintenanceRequest.ratingSource                 = "";
			BodyMaintenanceRequest.remarkLine1                  = "";
			BodyMaintenanceRequest.remarkLine2                  = "";
			BodyMaintenanceRequest.remarkLine3                  = "";
			BodyMaintenanceRequest.remarkLine4                  = "";
			BodyMaintenanceRequest.reviewDate                   = "";
			BodyMaintenanceRequest.telephone                    = VAR_NoTeleponRumah;
			BodyMaintenanceRequest.titleAfterName               = "";
			BodyMaintenanceRequest.titleBeforName               = "";
			BodyMaintenanceRequest.uicUserDefined               = "";
			BodyMaintenanceRequest.wilayahTLahir                = VAR_TempatLahir;

			ResponseMaintenanceClass = MainClass.CIFMandatoryMaintenanceService(BodyMaintenanceRequest);
			RetrieveDataFromSOAResponse(ResponseMaintenanceClass);
			*/
		}

		private void CONTROL_to_VAR()
		{
			VAR_CIFNo                       = TXT_CIF_NO.Text;
			VAR_CustomerName                = TXT_CUST_NAME.Text;
			VAR_NamaPelaporan               = TXT_MOTHER_NAME.Text;
			VAR_NamaPrefik                  = DDL_NAMA_PREFIK.SelectedValue;
			VAR_JenisNasabah                = DDL_JNS_NASABAH.SelectedValue;
			VAR_TanggalLahirDay             = TXT_TGL_LAHIR.Text;
			VAR_TanggalLahirMonth           = DDL_BLN_LAHIR.SelectedValue;
			VAR_TanggalLahirYear            = TXT_THN_LAHIR.Text;
			VAR_TempatLahir                 = TXT_TMP_LAHIR.Text;
			VAR_JenisIDUtama                = DDL_JNS_IDI.SelectedValue;
			VAR_NoIDUtama                   = TXT_IDI_UTAMA.Text;
			VAR_TglKadaluarsaIDUtamaDay     = TXT_TGL_KADAL.Text;
			VAR_TglKadaluarsaIDUtamaMonth   = DDL_BLN_KADAL.SelectedValue;
			VAR_TglKadaluarsaIDUtamaYear    = TXT_THN_KADAL.Text;
			VAR_TempatDikeluarkanIDUtama    = TXT_TEMPAT_IDI.Text;
			VAR_JenisDebitur                = DDL_JNS_DEBITUR.SelectedValue;
			VAR_GolonganNasabah             = DDL_GOL_NASABAH.SelectedValue;
			VAR_Kewarganegaraan             = DDL_KEWARGANEGARAAN.SelectedValue;
			VAR_NoTeleponMobile             = TXT_TELP_M.Text;
			VAR_NoTeleponRumah              = TXT_TELP_R.Text;
			VAR_KodeNegara                  = DDL_KODE_NEGARA.SelectedValue;
			VAR_Alamat1                     = TXT_ALAMAT1.Text;
			VAR_Alamat2                     = TXT_ALAMAT2.Text;
			VAR_Kecamatan                   = TXT_KECAMATAN.Text;
			VAR_ZipCode                     = TXT_CU_COMPZIPCODE.Text;
			VAR_Kota                        = TXT_CITY.Text;
			VAR_JenisAlamat                 = DDL_JNS_ALAMAT.SelectedValue;
			VAR_LokasiDatiII                = DDL_DATI.SelectedValue;
			VAR_NamaGadisIbuKandung         = TXT_MOTHER_NAME.Text;
			VAR_HubungandenganBank          = DDL_HUB_BANK.SelectedValue;
			VAR_HubungandenganKeluarga      = DDL_HUB_FAM.SelectedValue;
			VAR_JenisKelamin                = DDL_JNS_KELAMIN.SelectedValue;
			VAR_KodeIndustri                = DDL_KODE_INDUSTRY.SelectedValue;
			VAR_PICDataOwner                = DDL_PIC_DATA_OWNER.SelectedValue;
			VAR_NoNPWP                      = TXT_NPWP.Text;
			VAR_NamaPelaporan               = TXT_NAMA_PELAPORAN.Text;
		}

		/*
		public void RetrieveDataFromSOAResponse(DQM.CIFMandatoryMaintenance.CIFMandatoryMaintenanceResponse response)
		{
			if (response.soaHeader.responseCode.ToString() == "1")
			{
				try { VAR_CIFNo                         = response.body.customerNumber.ToString(); }
				catch { VAR_CIFNo                       = ""; }
				try { VAR_CustomerName                  = response.body.customerName.ToString(); } 
				catch { VAR_CustomerName                = ""; }
				try { VAR_NamaPelaporan                 = ""; } 
				catch { VAR_NamaPelaporan               = ""; }
				try { VAR_NamaPrefik                    = ""; } 
				catch { VAR_NamaPrefik                  = ""; }
				try { VAR_JenisNasabah                  = response.body.customerTypeCode.ToString(); } 
				catch { VAR_JenisNasabah                = ""; }
				try { VAR_TanggalLahirDay               = DateTime.Parse(response.body.dobDDMMYYYY).Day.ToString(); } 
				catch { VAR_TanggalLahirDay             = ""; }
				try { VAR_TanggalLahirMonth             = DateTime.Parse(response.body.dobDDMMYYYY).Month.ToString(); } 
				catch { VAR_TanggalLahirMonth           = ""; }
				try { VAR_TanggalLahirYear              = DateTime.Parse(response.body.dobDDMMYYYY).Year.ToString(); } 
				catch { VAR_TanggalLahirYear            = ""; }
				try { VAR_TempatLahir                   = response.body.wilayahTLahir.ToString(); } 
				catch { VAR_TempatLahir                 = ""; }
				try { VAR_JenisIDUtama                  = response.body.idtypeCode.ToString(); } 
				catch { VAR_JenisIDUtama                = ""; }
				try { VAR_NoIDUtama                     = response.body.idNumber.ToString(); } 
				catch { VAR_NoIDUtama                   = ""; }
				try { VAR_TglKadaluarsaIDUtamaDay       = ""; } 
				catch { VAR_TglKadaluarsaIDUtamaDay     = ""; }
				try { VAR_TglKadaluarsaIDUtamaMonth     = ""; } 
				catch { VAR_TglKadaluarsaIDUtamaMonth   = ""; }
				try { VAR_TglKadaluarsaIDUtamaYear      = ""; } 
				catch { VAR_TglKadaluarsaIDUtamaYear    = ""; }
				try { VAR_TempatDikeluarkanIDUtama      = response.body.idIssuePlace.ToString(); } 
				catch { VAR_TempatDikeluarkanIDUtama    = ""; }
				try { VAR_JenisDebitur                  = ""; } 
				catch { VAR_JenisDebitur                = ""; }
				try { VAR_GolonganNasabah               = ""; } 
				catch { VAR_GolonganNasabah             = ""; }
				try { VAR_Kewarganegaraan               = response.body.countryOfCitizenship.ToString(); } 
				catch { VAR_Kewarganegaraan             = ""; }
				try { VAR_NoTeleponMobile               = response.body.handphone.ToString(); } 
				catch { VAR_NoTeleponMobile             = ""; }
				try { VAR_NoTeleponRumah                = response.body.telephone.ToString(); } 
				catch { VAR_NoTeleponRumah              = ""; }
				try { VAR_KodeNegara                    = ""; } 
				catch { VAR_KodeNegara                  = ""; }
				try { VAR_Alamat1                       = response.body.addressLine1.ToString(); } 
				catch { VAR_Alamat1                     = ""; }
				try { VAR_Alamat2                       = response.body.addressLine2.ToString(); } 
				catch { VAR_Alamat2                     = ""; }
				try { VAR_Kecamatan                     = ""; } 
				catch { VAR_Kecamatan                   = ""; }
				try { VAR_ZipCode                       = response.body.postalCode.ToString(); } 
				catch { VAR_ZipCode                     = ""; }
				try { VAR_Kota                          = ""; } 
				catch { VAR_Kota                        = ""; }
				try { VAR_JenisAlamat                   = ""; } 
				catch { VAR_JenisAlamat                 = ""; }
				try { VAR_LokasiDatiII                  = response.body.lokasiI.ToString(); } 
				catch { VAR_LokasiDatiII                = ""; }
				try { VAR_NamaGadisIbuKandung           = response.body.motherMaidenName.ToString(); } 
				catch { VAR_NamaGadisIbuKandung         = ""; }
				try { VAR_HubungandenganBank            = response.body.hubunganDenganBank.ToString(); } 
				catch { VAR_HubungandenganBank          = ""; }
				try { VAR_HubungandenganKeluarga        = response.body.hubunganKeluarga.ToString(); } 
				catch { VAR_HubungandenganKeluarga      = ""; }
				try { VAR_JenisKelamin                  = response.body.genderCode.ToString(); } 
				catch { VAR_JenisKelamin                = ""; }
				try { VAR_KodeIndustri                  = ""; } 
				catch { VAR_KodeIndustri                = ""; }
				try { VAR_PICDataOwner                  = ""; } 
				catch { VAR_PICDataOwner                = ""; }
				try { VAR_NoNPWP                        = ""; } 
				catch { VAR_NoNPWP                      = ""; }

				//Put hidden variable here
				try
				{
                    
				}
				catch
				{
                    
				}
			}
			else
			{
				Tools.popMessage(this, "SOA Connection Fail !");
			}
			VAR_to_CONTROL();
		}
		*/
	}
}
