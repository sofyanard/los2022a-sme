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
	/// Summary description for LoanBUDetailData.
	/// </summary>
	public partial class LoanBUDetailData : System.Web.UI.Page
	{
		protected Connection conn;
		protected Connection2 conn2;
		protected Connection2 conn3;

		/*Deklarasi variable*/
		private string VAR_SifatKredit;
		private string VAR_JenisPenggunaan;
		private string VAR_OrientasiPenggunaan;		
		private string VAR_GolonganKredit;
		private string VAR_JenisKredit;
		private string VAR_FasilitasPenyediaanDana;
		private string VAR_BankUtamaSindikasi;
		private string VAR_LokasiProyek;
		private string VAR_NilaiProyek;
		private string VAR_AlamatProyek;
		private string VAR_GolonganPenjamin;
		private string VAR_BagianyangDijamin;
		private string VAR_KolektibilitasBItigapilar;
		private string VAR_KolektibilitasBM;
		private string VAR_KSEBI1;
		private string VAR_KSEBI2;
		private string VAR_KSEBI3;
		private string VAR_KSEBI4;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewField();
			conn = (Connection) Session["Connection"];
			conn2 = new Connection2(ConfigurationSettings.AppSettings["conn2"]);
			conn3 = new Connection2(ConfigurationSettings.AppSettings["conn2"]);
			
			if(!IsPostBack)
			{
				DDL_SIFATKREDIT.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_JNSPENGGUNAAN.Items.Add(new ListItem("Pilih--", ""));
				DDL_ORIENTASI_PENGGUNAAN.Items.Add(new ListItem("--Pilih--", ""));
				DDL_GOLKREDIT.Items.Add(new ListItem("--Pilih--",""));				
				DDL_JNSKREDIT.Items.Add(new ListItem("--Pilih--",""));
				DDL_FACDANA.Items.Add(new ListItem("--Pilih--", ""));
				DDL_BANK_UTAMA.Items.Add(new ListItem("--Pilih--", ""));
				DDL_LOKASI_PROYEK.Items.Add(new ListItem("--Pilih--", ""));
				DDL_GOL_PENJAMIN.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_KOL_BI.Items.Add(new ListItem("Pilih--", ""));
				DDL_KOL_BM.Items.Add(new ListItem("--Pilih--", ""));
				DDL_KSBI1.Items.Add(new ListItem("--Pilih--",""));
				DDL_KSBI2.Items.Add(new ListItem("--Pilih--",""));
				DDL_KSBI3.Items.Add(new ListItem("--Pilih--",""));
				DDL_KSBI4.Items.Add(new ListItem("--Pilih--", ""));

				conn2.QueryString = "SELECT * FROM VW_LOANBU_SIFAT_KREDIT";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_SIFATKREDIT.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_LOANBU_JNS_PENGGUNAAN";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JNSPENGGUNAAN.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_LOANBU_ORIENTASI_PENGGUNAAN";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_ORIENTASI_PENGGUNAAN.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_LOANBU_GOL_KREDIT";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_GOLKREDIT.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_LOANBU_JNS_KREDIT";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JNSKREDIT.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_LOANBU_FAC_DANA";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_FACDANA.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_LOANBU_BANK_UTAMA_SINDIKASI";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_BANK_UTAMA.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_LOANBU_LOKASI_PROYEK";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_LOKASI_PROYEK.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_LOANBU_GOL_PENJAMIN";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_GOL_PENJAMIN.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_LOANBU_KOL_BI";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_KOL_BI.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_LOANBU_KOL_BM";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_KOL_BM.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_LOANBU_KSEBI1";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_KSBI1.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_LOANBU_KSEBI2";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_KSBI2.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_LOANBU_KSEBI3";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_KSBI3.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_LOANBU_KSEBI4";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_KSBI4.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));
			}
			/*************************************************************************************************/
			//ViewGenData();

			//RetrieveSOA();

			/*Cek error message*/
			CheckError();
		}

		private void ViewField()
		{
			DDL_SIFATKREDIT.Enabled = false;
			DDL_JNSPENGGUNAAN.Enabled = false;
			DDL_ORIENTASI_PENGGUNAAN.Enabled = false;
			DDL_GOLKREDIT.Enabled = false;
			DDL_JNSKREDIT.Enabled = false;
			DDL_FACDANA.Enabled = false;
			DDL_BANK_UTAMA.Enabled = false;
			DDL_LOKASI_PROYEK.Enabled = false;
			TXT_NILAI_PROYEK.Enabled = false;
			TXT_ADD_PROYEK.Enabled = false;
			DDL_GOL_PENJAMIN.Enabled = false;
			TXT_JAMINAN.Enabled = false;
			DDL_KOL_BI.Enabled = false;
			DDL_KOL_BM.Enabled = false;
			DDL_KSBI1.Enabled = false;
			DDL_KSBI2.Enabled = false;
			DDL_KSBI3.Enabled = false;
			DDL_KSBI4.Enabled = false;
		}
		
		#region ViewGenData
		private void ViewGenData()
		{
			conn2.QueryString = "SELECT * FROM CREDIT_DATA WHERE CIF# = '" + Request.QueryString["acctno"] + "' ";
			conn2.ExecuteQuery();

			try{DDL_SIFATKREDIT.SelectedValue = conn2.GetFieldValue("BISIFA");}
			catch{DDL_SIFATKREDIT.SelectedValue = "";}

			try{DDL_JNSPENGGUNAAN.SelectedValue = conn2.GetFieldValue("BIPENG");}
			catch{DDL_JNSPENGGUNAAN.SelectedValue = "";}

			try{DDL_ORIENTASI_PENGGUNAAN.SelectedValue = conn2.GetFieldValue("BIGUNA");}
			catch{DDL_ORIENTASI_PENGGUNAAN.SelectedValue = "";}

			try{DDL_GOLKREDIT.SelectedValue = conn2.GetFieldValue("BIKUK2");}
			catch{DDL_GOLKREDIT.SelectedValue = "";}

			try{DDL_JNSKREDIT.SelectedValue = conn2.GetFieldValue("LOAN_TYPE");}
			catch{DDL_JNSKREDIT.SelectedValue = "";}

			try{DDL_FACDANA.SelectedValue = conn2.GetFieldValue("BIDANA");}
			catch{DDL_FACDANA.SelectedValue = "";}

			try{DDL_BANK_UTAMA.SelectedValue = conn2.GetFieldValue("BILEAD");}
			catch{DDL_BANK_UTAMA.SelectedValue = "";}

			try{DDL_LOKASI_PROYEK.SelectedValue = conn2.GetFieldValue("BILOKJ");}
			catch{DDL_LOKASI_PROYEK.SelectedValue = "";}

			try{DDL_LOKASI_PROYEK.SelectedValue = conn2.GetFieldValue("BILOKJ");}
			catch{DDL_LOKASI_PROYEK.SelectedValue = "";}

			TXT_NILAI_PROYEK.Text = conn2.GetFieldValue("BIPROJ");
			TXT_ADD_PROYEK.Text = conn2.GetFieldValue("BIADDR");

			try{DDL_GOL_PENJAMIN.SelectedValue = conn2.GetFieldValue("BIPJMN");}
			catch{DDL_GOL_PENJAMIN.SelectedValue = "";}

			TXT_JAMINAN.Text = conn2.GetFieldValue("BIBAGN");

			try{DDL_KOL_BI.SelectedValue = conn2.GetFieldValue("BIKOLE");}
			catch{DDL_KOL_BI.SelectedValue = "";}

			try{DDL_KOL_BM.SelectedValue = conn2.GetFieldValue("BM_KOLE");}
			catch{DDL_KOL_BM.SelectedValue = "";}

			try{DDL_KSBI1.SelectedValue = conn2.GetFieldValue("KSEBI1");}
			catch{DDL_KSBI1.SelectedValue = "";}

			try{DDL_KSBI2.SelectedValue = conn2.GetFieldValue("KSEBI2");}
			catch{DDL_KSBI2.SelectedValue = "";}

			try{DDL_KSBI3.SelectedValue = conn2.GetFieldValue("KSEBI3");}
			catch{DDL_KSBI3.SelectedValue = "";}

			try{DDL_KSBI4.SelectedValue = conn2.GetFieldValue("KSEBI4");}
			catch{DDL_KSBI4.SelectedValue = "";}
		}
		#endregion
        
		/*
		private DQM.SOA.SOA_DQM MainClass = new DQM.SOA.SOA_DQM();
		private DQM.DEPInquiry.body BodyRequest = new DQM.DEPInquiry.body();
		private DQM.DEPInquiry.InfoAssuranceDepositoResponse ResponseClass = new DQM.DEPInquiry.InfoAssuranceDepositoResponse();

		private DQM.DEPMaintenance.body BodyMaintenanceRequest = new DQM.DEPMaintenance.body();
		private DQM.DEPMaintenance.DEPMaintenanceResponse ResponseMaintenanceClass = new DQM.DEPMaintenance.DEPMaintenanceResponse();
		
		private void RetrieveSOA()
		{
			BodyRequest.collateralID = Request.QueryString["acctno"];
			ResponseClass = MainClass.DEPInquiryService(BodyRequest);

			if (ResponseClass.soaHeader.responseCode == 1)
			{
				VAR_SifatKredit = "";
				VAR_JenisPenggunaan = "";
				VAR_OrientasiPenggunaan = "";
				VAR_GolonganKredit = "";
				VAR_JenisKredit = "";
				VAR_FasilitasPenyediaanDana = "";
				VAR_BankUtamaSindikasi = "";
				VAR_LokasiProyek = "";
				VAR_NilaiProyek = "";
				VAR_AlamatProyek = "";
				VAR_GolonganPenjamin = "";
				VAR_BagianyangDijamin = "";
				VAR_KolektibilitasBItigapilar = "";
				VAR_KolektibilitasBM = "";
				VAR_KSEBI1 = "";
				VAR_KSEBI2 = "";
				VAR_KSEBI3 = "";
				VAR_KSEBI4 = "";

				VAR_to_CONTROL();
			}
			else
			{
				Tools.popMessage(this, ResponseClass.soaHeader.responseCode.ToString());
				Response.Redirect("");
			}
		}
		*/
		
		private void VAR_to_CONTROL()
		{
			DDL_SIFATKREDIT.SelectedValue			= VAR_SifatKredit;
			DDL_JNSPENGGUNAAN.SelectedValue			= VAR_JenisPenggunaan;
			DDL_ORIENTASI_PENGGUNAAN.SelectedValue	= VAR_OrientasiPenggunaan;			
			DDL_GOLKREDIT.SelectedValue				= VAR_GolonganKredit;
			DDL_JNSKREDIT.SelectedValue				= VAR_JenisKredit;
			DDL_FACDANA.SelectedValue				= VAR_FasilitasPenyediaanDana;
			DDL_BANK_UTAMA.SelectedValue			= VAR_BankUtamaSindikasi;
			DDL_LOKASI_PROYEK.SelectedValue			= VAR_LokasiProyek;
			TXT_NILAI_PROYEK.Text					= VAR_NilaiProyek;
			TXT_ADD_PROYEK.Text						= VAR_AlamatProyek;
			DDL_GOL_PENJAMIN.SelectedValue			= VAR_GolonganPenjamin;
			TXT_JAMINAN.Text						= VAR_BagianyangDijamin;
			DDL_KOL_BI.SelectedValue				= VAR_KolektibilitasBItigapilar;
			DDL_KOL_BM.SelectedValue				= VAR_KolektibilitasBM;
			DDL_KSBI1.SelectedValue					= VAR_KSEBI1;
			DDL_KSBI2.SelectedValue					= VAR_KSEBI2;
			DDL_KSBI3.SelectedValue					= VAR_KSEBI3;
			DDL_KSBI4.SelectedValue					= VAR_KSEBI4;
		}

		private void CheckError()
		{
			string id = "", id_field = "";

			conn2.QueryString = "EXEC DCM_DATA_ERROR_CHECKING '" + Request.QueryString["acctno"] + "','1'";
			conn2.ExecuteQuery();

			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				string err_msg = conn2.GetFieldValue(i, "ERR_MSG").ToString().Replace(";","");

				conn3.QueryString = "SELECT IDCONTROL FROM DCM_TABLE_ERROR WHERE PAGE = 'LoanBUDetailData.aspx' AND MESSAGE = '" + err_msg.Trim() + "'";
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

		private void ClearData()
		{	
			DDL_SIFATKREDIT.SelectedValue			= "";
			DDL_JNSPENGGUNAAN.SelectedValue			= "";
			DDL_ORIENTASI_PENGGUNAAN.SelectedValue	= "";
			DDL_GOLKREDIT.SelectedValue				= "";
			DDL_JNSKREDIT.SelectedValue				= "";
			DDL_FACDANA.SelectedValue				= "";
			DDL_BANK_UTAMA.SelectedValue			= "";
			DDL_LOKASI_PROYEK.SelectedValue			= "";
			TXT_NILAI_PROYEK.Text					= "";
			TXT_ADD_PROYEK.Text						= "";
			DDL_GOL_PENJAMIN.SelectedValue			= "";
			TXT_JAMINAN.Text						= "";
			DDL_KSBI1.SelectedValue					= "";
			DDL_KSBI2.SelectedValue					= "";
			DDL_KSBI3.SelectedValue					= "";
			DDL_KSBI4.SelectedValue					= "";
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("LoanListDataBU2.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			/*
			BodyMaintenanceRequest.accountType = "";

			ResponseMaintenanceClass = MainClass.DEPMaintenanceService(BodyMaintenanceRequest);
			RetrieveDataFromSOAResponse(ResponseMaintenanceClass);
			 */
		}

		/*
		public void RetrieveDataFromSOAResponse()
		{
			if (response.soaHeader.responseCode.ToString() == "1")
			{
				DDL_SIFATKREDIT.SelectedValue = VAR_SifatKredit;
				DDL_JNSPENGGUNAAN.SelectedValue = VAR_JenisPenggunaan;
				DDL_ORIENTASI_PENGGUNAAN.SelectedValue = VAR_OrientasiPenggunaan;
				DDL_GOLKREDIT.SelectedValue = VAR_GolonganKredit;
				DDL_JNSKREDIT.SelectedValue = VAR_JenisKredit;
				DDL_FACDANA.SelectedValue = VAR_FasilitasPenyediaanDana;
				DDL_BANK_UTAMA.SelectedValue = VAR_BankUtamaSindikasi;
				DDL_LOKASI_PROYEK.SelectedValue = VAR_LokasiProyek;
				TXT_NILAI_PROYEK.Text = VAR_NilaiProyek;
				TXT_ADD_PROYEK.Text = VAR_AlamatProyek;
				DDL_GOL_PENJAMIN.SelectedValue = VAR_GolonganPenjamin;
				TXT_JAMINAN.Text = VAR_BagianyangDijamin;
				DDL_KOL_BI.SelectedValue = VAR_KolektibilitasBItigapilar;
				DDL_KOL_BM.SelectedValue = VAR_KolektibilitasBM;
				DDL_KSBI1.SelectedValue = VAR_KSEBI1;
				DDL_KSBI2.SelectedValue = VAR_KSEBI2;
				DDL_KSBI3.SelectedValue = VAR_KSEBI3;
				DDL_KSBI4.SelectedValue = VAR_KSEBI4;

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
			VAR_SifatKredit					= DDL_SIFATKREDIT.SelectedValue;
			VAR_JenisPenggunaan				= DDL_JNSPENGGUNAAN.SelectedValue;
			VAR_OrientasiPenggunaan			= DDL_ORIENTASI_PENGGUNAAN.SelectedValue;
			VAR_GolonganKredit				= DDL_GOLKREDIT.SelectedValue;
			VAR_JenisKredit					= DDL_JNSKREDIT.SelectedValue;
			VAR_FasilitasPenyediaanDana		= DDL_FACDANA.SelectedValue;
			VAR_BankUtamaSindikasi			= DDL_BANK_UTAMA.SelectedValue;
			VAR_LokasiProyek				= DDL_LOKASI_PROYEK.SelectedValue;
			VAR_NilaiProyek					= TXT_NILAI_PROYEK.Text;
			VAR_AlamatProyek				= TXT_ADD_PROYEK.Text;
			VAR_GolonganPenjamin			= DDL_GOL_PENJAMIN.SelectedValue;
			VAR_BagianyangDijamin			= TXT_JAMINAN.Text;
			VAR_KolektibilitasBItigapilar	= DDL_KOL_BI.SelectedValue;
			VAR_KolektibilitasBM			= DDL_KOL_BM.SelectedValue;
			VAR_KSEBI1						= DDL_KSBI1.SelectedValue;
			VAR_KSEBI2						= DDL_KSBI2.SelectedValue;
			VAR_KSEBI3						= DDL_KSBI3.SelectedValue;
			VAR_KSEBI4						= DDL_KSBI4.SelectedValue;
		}
	}
}
