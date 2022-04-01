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
	/// Summary description for LoanDetailDataCO2.
	/// </summary>
	public partial class LoanDetailDataCO2 : System.Web.UI.Page
	{
		protected Connection conn;
		protected Connection2 conn2;
		protected Connection2 conn3;

		/* Deklarasi Variable */
		private string VAR_TanggalPKPertamaDay;
		private string VAR_TanggalPKPertamaMonth;
		private string VAR_TanggalPKPertamaYear;
		private string VAR_NoPKPertama;
		private string VAR_TanggalPKTerakhirDay;
		private string VAR_TanggalPKTerakhirMonth;
		private string VAR_TanggalPKTerakhirYear;
		private string VAR_NoPKTerakhir;
		private string VAR_PerhitunganPPA;
		private string VAR_OtomatisKolektibilitas;
		private string VAR_OneEntityFlag;
		private string VAR_Restrukturisasi;
		private string VAR_TglRestrukturisasiAwalDay;
		private string VAR_TglRestrukturisasiAwalMonth;
		private string VAR_TglRestrukturisasiAwalYear;
		private string VAR_TglRestrukturisasiAkhirDay;
		private string VAR_TglRestrukturisasiAkhirMonth;
		private string VAR_TglRestrukturisasiAkhirYear;
		private string VAR_JenisRestrukturisasi;
		private string VAR_KolektibilitasBItigapilar;
		private string VAR_TglReviewRestrukturisasiDay;
		private string VAR_TglReviewRestrukturisasiMonth;
		private string VAR_TglReviewRestrukturisasiYear;
		private string VAR_Restrukturisasike;
		private string VAR_KeteranganRestrukturisasi;
		private string VAR_SandiKodePosisi;
		private string VAR_TglPosisiDay;
		private string VAR_TglPosisiMonth;
		private string VAR_TglPosisiYear;
		private string VAR_SebabMacet;
		private string VAR_TanggalMacetDay;
		private string VAR_TanggalMacetMonth;
		private string VAR_TanggalMacetYear;
		private string VAR_MelanggarBMPK;
		private string VAR_MelampauiBMPK;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewField();
			conn = (Connection) Session["Connection"];
			conn2 = new Connection2(ConfigurationSettings.AppSettings["conn2"]);
			conn3 = new Connection2(ConfigurationSettings.AppSettings["conn2"]);

			if(!IsPostBack)
			{
				DDL_BLN_PK_AWAL.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_BLN_PK_AKHIR.Items.Add(new ListItem("Pilih--", ""));
				DDL_BLN_REST_AW.Items.Add(new ListItem("--Pilih--", ""));
				DDL_BLN_REST_AKH.Items.Add(new ListItem("--Pilih--",""));		
				DDL_JNS_REST.Items.Add(new ListItem("--Pilih--",""));
				DDL_KOLE.Items.Add(new ListItem("--Pilih--", ""));
				DDL_BLN_RVW.Items.Add(new ListItem("--Pilih--", ""));
				DDL_KET_REST.Items.Add(new ListItem("--Pilih--", ""));
				DDL_SANDI.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_BLN_POS.Items.Add(new ListItem("Pilih--", ""));
				DDL_MACET.Items.Add(new ListItem("--Pilih--", ""));
				DDL_BLN_MCT.Items.Add(new ListItem("--Pilih--",""));

				for (int i=1; i<=12; i++)
				{
					DDL_BLN_PK_AWAL.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_PK_AKHIR.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_REST_AW.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));				
					DDL_BLN_REST_AKH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_RVW.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_POS.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));	
					DDL_BLN_MCT.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));	
				}

				conn2.QueryString = "select * from VW_DCM_LOANCO_DDL_JNS_RESTRU";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JNS_REST.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_LOANBU_KOL_BI";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_KOLE.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_LOANCO_DDL_RESTRU";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_KET_REST.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_LOANCO_DDL_SANDI";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_SANDI.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));
				
				conn2.QueryString = "select * from VW_DCM_LOANCO_DDL_SEBABMACET";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_MACET.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				/*************************************************************************************************/
				//RetrieveSOA();

				/*Cek error message*/
				CheckError();
			}
		}

		private void ViewField()
		{
			TXT_TGL_PK_AWAL.Enabled = false;
			DDL_BLN_PK_AWAL.Enabled = false;
			TXT_THN_PK_AWAL.Enabled = false;
			TXT_NOPK_AWAL.Enabled = false;
			TXT_TGL_PK_AKHIR.Enabled = false;
			DDL_BLN_PK_AKHIR.Enabled = false;
			TXT_THN_PK_AKHIR.Enabled = false;
			TXT_NOPK_AKHIR.Enabled = false;
			RDO_PPA.Enabled = false;
			RDO_KOLE.Enabled = false;
			RDO_FLAG.Enabled = false;
			RDO_RESTRU.Enabled = false;
			TXT_TGL_REST_AW.Enabled = false;
			DDL_BLN_REST_AW.Enabled = false;
			TXT_THN_REST_AW.Enabled = false;
			TXT_TGL_REST_AKH.Enabled = false;
			DDL_BLN_REST_AKH.Enabled = false;
			TXT_THN_REST_AKH.Enabled = false;
			DDL_JNS_REST.Enabled = false;
			DDL_KOLE.Enabled = false;
			TXT_TGL_RVW.Enabled = false;
			DDL_BLN_RVW.Enabled = false;
			TXT_THN_RVW.Enabled = false;
			TXT_REST_KE.Enabled = false;
			DDL_KET_REST.Enabled = false;
			DDL_SANDI.Enabled = false;
			TXT_TGL_POS.Enabled = false;
			DDL_BLN_POS.Enabled = false;
			TXT_THN_POS.Enabled = false;
			DDL_MACET.Enabled = false;
			TXT_TGL_MCT.Enabled = false;
			DDL_BLN_MCT.Enabled = false;
			TXT_THN_MCT.Enabled = false;
			RDO_MELAMPAUI.Enabled = false;
			RDO_MELANGGAR.Enabled = false;
		}

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
				VAR_TanggalPKPertamaDay = "";
				VAR_TanggalPKPertamaMonth = "";
				VAR_TanggalPKPertamaYear = "";
				VAR_NoPKPertama = "";
				VAR_TanggalPKTerakhirDay = "";
				VAR_TanggalPKTerakhirMonth = "";
				VAR_TanggalPKTerakhirYear = "";
				VAR_NoPKTerakhir = "";
				VAR_PerhitunganPPA = "";
				VAR_OtomatisKolektibilitas = "";
				VAR_OneEntityFlag = "";
				VAR_Restrukturisasi = "";
				VAR_TglRestrukturisasiAwalDay = "";
				VAR_TglRestrukturisasiAwalMonth = "";
				VAR_TglRestrukturisasiAwalYear = "";
				VAR_TglRestrukturisasiAkhirDay = "";
				VAR_TglRestrukturisasiAkhirMonth = "";
				VAR_TglRestrukturisasiAkhirYear = "";
				VAR_JenisRestrukturisasi = "";
				VAR_KolektibilitasBItigapilar = "";
				VAR_TglReviewRestrukturisasiDay = "";
				VAR_TglReviewRestrukturisasiMonth = "";
				VAR_TglReviewRestrukturisasiYear = "";
				VAR_Restrukturisasike = "";
				VAR_KeteranganRestrukturisasi = "";
				VAR_SandiKodePosisi = "";
				VAR_TglPosisiDay = "";
				VAR_TglPosisiMonth = "";
				VAR_TglPosisiYear = "";
				VAR_SebabMacet = "";
				VAR_TanggalMacetDay = "";
				VAR_TanggalMacetMonth = "";
				VAR_TanggalMacetYear = "";
				VAR_MelanggarBMPK = "";			
				VAR_MelampauiBMPK = "";

				VAR_to_CONTROL();
			}
			else
			{
				Tools.popMessage(this, ResponseClass.soaHeader.responseCode.ToString());
				Response.Redirect("");
			}
		}
		*/

		private void CheckError()
		{
			string id = "", id_field = "";

			conn2.QueryString = "EXEC DCM_DATA_ERROR_CHECKING '" + Request.QueryString["acctno"] + "','1'";
			conn2.ExecuteQuery();

			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				string err_msg = conn2.GetFieldValue(i, "ERR_MSG").ToString().Replace(";","");

				conn3.QueryString = "SELECT IDCONTROL FROM DCM_TABLE_ERROR WHERE PAGE = 'LoanDetailDataCO2.aspx' AND MESSAGE = '" + err_msg.Trim() + "'";
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
			TXT_TGL_PK_AWAL.Text			= "";
			DDL_BLN_PK_AWAL.SelectedValue	= "";
			TXT_THN_PK_AWAL.Text			= "";
			TXT_NOPK_AWAL.Text				= "";
			TXT_TGL_PK_AKHIR.Text			= "";
			DDL_BLN_PK_AKHIR.SelectedValue	= "";
			TXT_THN_PK_AKHIR.Text			= "";
			TXT_NOPK_AKHIR.Text				= "";
			RDO_PPA.SelectedValue			= "0";
			RDO_KOLE.SelectedValue			= "0";
			RDO_FLAG.SelectedValue			= "0";
			RDO_RESTRU.SelectedValue		= "0";
			TXT_TGL_REST_AW.Text			= "";
			DDL_BLN_REST_AW.SelectedValue	= "";
			TXT_THN_REST_AW.Text			= "";
			TXT_TGL_REST_AKH.Text			= "";
			DDL_BLN_REST_AKH.SelectedValue	= "";
			TXT_THN_REST_AKH.Text			= "";
			DDL_JNS_REST.SelectedValue		= "";
			DDL_KOLE.SelectedValue			= "";
			TXT_TGL_RVW.Text				= "";
			DDL_BLN_RVW.SelectedValue		= "";
			TXT_THN_RVW.Text				= "";
			TXT_REST_KE.Text				= "";
			DDL_KET_REST.SelectedValue		= "";
			DDL_SANDI.SelectedValue			= "";
			TXT_TGL_POS.Text				= "";
			DDL_BLN_POS.SelectedValue		= "";
			TXT_THN_POS.Text				= "";
			DDL_MACET.SelectedValue			= "";
			TXT_TGL_MCT.Text				= "";
			DDL_BLN_MCT.SelectedValue		= "";
			TXT_THN_MCT.Text				= "";
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("LoanListDataCO2.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
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
				TXT_TGL_PK_AWAL.Text			= VAR_TanggalPKPertamaDay;
				DDL_BLN_PK_AWAL.SelectedValue	= VAR_TanggalPKPertamaMonth;
				TXT_TGL_PK_AKHIR.Text			= VAR_TanggalPKPertamaYear;
				TXT_NOPK_AWAL.Text				= VAR_NoPKPertama;
				TXT_TGL_PK_AKHIR.Text			= VAR_TanggalPKTerakhirDay;
				DDL_BLN_PK_AKHIR.SelectedValue	= VAR_TanggalPKTerakhirMonth;
				TXT_THN_PK_AKHIR.Text			= VAR_TanggalPKTerakhirYear;
				TXT_NOPK_AKHIR.Text				= VAR_NoPKTerakhir;
				RDO_PPA.SelectedValue			= VAR_PerhitunganPPA;
				RDO_KOLE.SelectedValue			= VAR_OtomatisKolektibilitas;
				RDO_FLAG.SelectedValue			= VAR_OneEntityFlag;
				RDO_RESTRU.SelectedValue		= VAR_Restrukturisasi;
				TXT_TGL_REST_AW.Text			= VAR_TglRestrukturisasiAwalDay;
				DDL_BLN_REST_AW.SelectedValue	= VAR_TglRestrukturisasiAwalMonth;
				TXT_THN_REST_AW.Text			= VAR_TglRestrukturisasiAwalYear;
				TXT_TGL_REST_AKH.Text			= VAR_TglRestrukturisasiAkhirDay;
				DDL_BLN_REST_AKH.SelectedValue	= VAR_TglRestrukturisasiAkhirMonth;
				TXT_THN_REST_AKH.Text			= VAR_TglRestrukturisasiAkhirYear;
				DDL_JNS_REST.SelectedValue		= VAR_JenisRestrukturisasi;
				DDL_KOLE.SelectedValue			= VAR_KolektibilitasBItigapilar;
				TXT_TGL_RVW.Text				= VAR_TglReviewRestrukturisasiDay;
				DDL_BLN_RVW.SelectedValue		= VAR_TglReviewRestrukturisasiMonth;
				TXT_THN_RVW.Text				= VAR_TglReviewRestrukturisasiYear;
				TXT_REST_KE.Text				= VAR_Restrukturisasike;
				DDL_KET_REST.SelectedValue		= VAR_KeteranganRestrukturisasi;
				DDL_SANDI.SelectedValue			= VAR_SandiKodePosisi;
				TXT_TGL_POS.Text				= VAR_TglPosisiDay;
				DDL_BLN_POS.SelectedValue		= VAR_TglPosisiMonth;
				TXT_THN_POS.Text				= VAR_TglPosisiYear;
				DDL_MACET.SelectedValue			= VAR_SebabMacet;
				TXT_TGL_MCT.Text				= VAR_TanggalMacetDay;
				DDL_BLN_MCT.SelectedValue		= VAR_TanggalMacetMonth;
				TXT_THN_MCT.Text				= VAR_TanggalMacetYear;
				RDO_MELANGGAR.SelectedValue		= VAR_MelanggarBMPK;
				RDO_MELAMPAUI.SelectedValue		= VAR_MelampauiBMPK;

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
			VAR_TanggalPKPertamaDay				= TXT_TGL_PK_AWAL.Text;
			VAR_TanggalPKPertamaMonth			= DDL_BLN_PK_AWAL.SelectedValue;
			VAR_TanggalPKPertamaYear			= TXT_TGL_PK_AKHIR.Text;
			VAR_NoPKPertama						= TXT_NOPK_AWAL.Text;
			VAR_TanggalPKTerakhirDay			= TXT_TGL_PK_AKHIR.Text;
			VAR_TanggalPKTerakhirMonth			= DDL_BLN_PK_AKHIR.SelectedValue;
			VAR_TanggalPKTerakhirYear			= TXT_TGL_PK_AKHIR.Text;
			VAR_NoPKTerakhir					= TXT_NOPK_AKHIR.Text;
			VAR_PerhitunganPPA					= RDO_PPA.SelectedValue;
			VAR_OtomatisKolektibilitas			= RDO_KOLE.SelectedValue;
			VAR_OneEntityFlag					= RDO_FLAG.SelectedValue;
			VAR_Restrukturisasi					= RDO_RESTRU.SelectedValue;
			VAR_TglRestrukturisasiAwalDay		= TXT_TGL_REST_AW.Text;
			VAR_TglRestrukturisasiAwalMonth		= DDL_BLN_REST_AW.SelectedValue;
			VAR_TglRestrukturisasiAwalYear		= TXT_THN_REST_AW.Text;
			VAR_TglRestrukturisasiAkhirDay		= TXT_TGL_REST_AKH.Text;
			VAR_TglRestrukturisasiAkhirMonth	= DDL_BLN_REST_AKH.SelectedValue;
			VAR_TglRestrukturisasiAkhirYear		= TXT_THN_REST_AKH.Text;
			VAR_JenisRestrukturisasi			= DDL_JNS_REST.SelectedValue;
			VAR_KolektibilitasBItigapilar		= DDL_KOLE.SelectedValue;
			VAR_TglReviewRestrukturisasiDay		= TXT_TGL_RVW.Text;
			VAR_TglReviewRestrukturisasiMonth	= DDL_BLN_RVW.SelectedValue;
			VAR_TglReviewRestrukturisasiYear	= TXT_THN_RVW.Text;
			VAR_Restrukturisasike				= TXT_REST_KE.Text;
			VAR_KeteranganRestrukturisasi		= DDL_KET_REST.SelectedValue;
			VAR_SandiKodePosisi					= DDL_SANDI.SelectedValue;
			VAR_TglPosisiDay					= TXT_TGL_POS.Text;
			VAR_TglPosisiMonth					= DDL_BLN_POS.SelectedValue;
			VAR_TglPosisiYear					= TXT_THN_POS.Text;
			VAR_SebabMacet						= DDL_MACET.SelectedValue;
			VAR_TanggalMacetDay					= TXT_TGL_MCT.Text;
			VAR_TanggalMacetMonth				= DDL_BLN_MCT.SelectedValue;
			VAR_TanggalMacetYear				= TXT_THN_MCT.Text;
			VAR_MelanggarBMPK					= RDO_MELANGGAR.SelectedValue;
			VAR_MelampauiBMPK					= RDO_MELAMPAUI.SelectedValue;
		}
	}
}
