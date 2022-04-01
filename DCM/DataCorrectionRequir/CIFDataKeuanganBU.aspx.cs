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
	/// Summary description for CIFDataKeuanganBU.
	/// </summary>
	public partial class CIFDataKeuanganBU : System.Web.UI.Page
	{
		protected Connection conn;
		protected Connection2 conn2;
		protected Connection2 conn3;

		/* Deklarasi Variable*/
		private string VAR_PosisiLaporanKeuanganDay;
		private string VAR_PosisiLaporanKeuanganMonth;
		private string VAR_PosisiLaporanKeuanganYear;
		private string VAR_PinjamanLuarNegeri;
		private string VAR_Denominasi;
		private string VAR_AuditedUnaudited;
		private string VAR_Currency;
		private string VAR_JumlahBulan;
		private string VAR_AktivaLancar;
		private string VAR_TotalAktiva;
		private string VAR_KewajibankepadaBank;
		private string VAR_KewajibanLancar;
		private string VAR_TotalKewajiban;
		private string VAR_Modal;
		private string VAR_Penjualan;
		private string VAR_PendapatanOperasional;
		private string VAR_BiayaOperasional;
		private string VAR_PendapatanNonOperasional;
		private string VAR_BiayaNonOperasional;
		private string VAR_LabaRugiThnLaluStlhPajak;
		private string VAR_LabaRugiThnLaluSblmPajak;

		/*
		 * Connect class SOA
		private DQM.SOA.SOA_DQM MainClass = new DQM.SOA.SOA_DQM();

		private DQM.CIFFinancialInformationDetail.body CIFFinancialInformationDetailBody;
		private DQM.CIFFinancialInformationDetail.CIFFinancialInformationResponse CIFFinancialInformationDetailResponse;
		*/
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewField();

			conn = (Connection) Session["Connection"];
			conn2 = new Connection2(ConfigurationSettings.AppSettings["conn2"]);
			conn3 = new Connection2(ConfigurationSettings.AppSettings["conn2"]);

			if(!IsPostBack)
			{
				DDL_BLN_LAP.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_DENO.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_AUDITED.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_CURR.Items.Add(new ListItem ("--Pilih--", ""));
				for (int i=1; i<=12; i++)
				{
					DDL_BLN_LAP.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));					
				}
				conn2.QueryString = "SELECT * FROM DENOMINATOR";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_DENO.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));

				conn.QueryString = "SELECT CURRENCYID,CURRENCYDESC FROM RFCURRENCY WHERE ACTIVE ='1' ORDER BY CURRENCYDESC";
				conn.ExecuteQuery();
				for (int j=0; j<conn.GetRowCount(); j++)
					DDL_CURR.Items.Add(new ListItem(conn.GetFieldValue(j,1),conn.GetFieldValue(j,0)));

				conn2.QueryString = "SELECT * FROM RFAUDIT";
				conn2.ExecuteQuery();
				for (int k=0; k<conn2.GetRowCount(); k++)
					DDL_AUDITED.Items.Add(new ListItem(conn2.GetFieldValue(k,1),conn2.GetFieldValue(k,0)));

				/*************************************************************************************************/
				//RetrieveSOA();

				/*Cek error message*/
				CheckError();
			}

			ViewMenu();
		}

		private void ViewField()
		{
			TXT_TGL_LAP.Enabled = false;
			DDL_BLN_LAP.Enabled = false;
			RDO_PINJAMAN_LN.Enabled = false;
			DDL_DENO.Enabled = false;
			DDL_AUDITED.Enabled = false;
			DDL_CURR.Enabled = false;
			TXT_JML_BLN.Enabled = false;
			TXT_ACTIVA.Enabled = false;
			TXT_TOT_ACTIVA.Enabled = false;
			TXT_WJB_BANK.Enabled = false;
			TXT_WJB_LANCAR.Enabled = false;
			TXT_TOT_WJB.Enabled = false;
			TXT_MODAL.Enabled = false;
			TXT_PENJUALAN.Enabled = false;
			TXT_POP.Enabled = false;
			TXT_BOP.Enabled = false;
			TXT_NON_POP.Enabled = false;
			TXT_NON_BOP.Enabled = false;
			LR_AFTER.Enabled = false;
			LR_BEFORE.Enabled = false;
		}

		private void ViewMenu()
		{
			MenuCIF.Controls.Clear();
			try
			{
				conn.QueryString = "SELECT * FROM SCREENMENU WHERE MENUCODE = '" + Request.QueryString["mc"] + "' AND SM_ID IN ('DCM010101','DCM010102','DCM010103')";
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

		private void CheckError()
		{
			string id = "", id_field = "";

			conn2.QueryString = "EXEC DCM_DATA_ERROR_CHECKING '" + Request.QueryString["cifno"] + "','1'";
			conn2.ExecuteQuery();

			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				string err_msg = conn2.GetFieldValue(i, "ERR_MSG").ToString().Replace(";","");

				conn3.QueryString = "SELECT IDCONTROL FROM DCM_TABLE_ERROR WHERE PAGE = 'CIFDataKeuanganBU.aspx' AND MESSAGE = '" + err_msg.Trim() + "'";
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

		/*
		private void RetrieveSOA()
		{
			CIFFinancialInformationDetailBody = new DQM.CIFFinancialInformationDetail.body();
			CIFFinancialInformationDetailBody.customerNumber = Request.QueryString["cifno"];
			CIFFinancialInformationDetailResponse = MainClass.CIFInquiryDataKeuanganService(CIFFinancialInformationDetailBody);

			if (CIFFinancialInformationDetailResponse.soaHeader.responseCode == 1)
			{
				try { VAR_PosisiLaporanKeuanganDay      = ""; }
				catch { VAR_PosisiLaporanKeuanganDay = ""; }
				try { VAR_PosisiLaporanKeuanganMonth    = ""; }
				catch { VAR_PosisiLaporanKeuanganMonth = ""; }
				try { VAR_PosisiLaporanKeuanganYear     = ""; }
				catch { VAR_PosisiLaporanKeuanganYear = ""; }
				try { VAR_PinjamanLuarNegeri            = CIFFinancialInformationDetailResponse.body.pinjamanLuarNegeri.ToString(); }
				catch { VAR_PinjamanLuarNegeri = ""; }
				try { VAR_Denominasi                    = ""; }
				catch { VAR_Denominasi = ""; }
				try { VAR_AuditedUnaudited              = CIFFinancialInformationDetailResponse.body.auditedNotAudited.ToString(); }
				catch { VAR_AuditedUnaudited = ""; }
				try { VAR_Currency                      = ""; }
				catch { VAR_Currency = ""; }
				try { VAR_JumlahBulan                   = CIFFinancialInformationDetailResponse.body.jumlahBulan.ToString(); }
				catch { VAR_JumlahBulan = ""; }
				try { VAR_AktivaLancar                  = CIFFinancialInformationDetailResponse.body.aktivaLancar.ToString(); }
				catch { VAR_AktivaLancar = ""; }
				try { VAR_TotalAktiva                   = CIFFinancialInformationDetailResponse.body.totalAktiva.ToString(); }
				catch { VAR_TotalAktiva = ""; }
				try { VAR_KewajibankepadaBank           = CIFFinancialInformationDetailResponse.body.kewajibanJkPanjang.ToString(); }
				catch { VAR_KewajibankepadaBank = ""; }
				try { VAR_KewajibanLancar               = CIFFinancialInformationDetailResponse.body.hutang.ToString(); }
				catch { VAR_KewajibanLancar = ""; }
				try { VAR_TotalKewajiban                = CIFFinancialInformationDetailResponse.body.totalKewajiban.ToString(); }
				catch { VAR_TotalKewajiban = ""; }
				try { VAR_Modal                         = CIFFinancialInformationDetailResponse.body.totalModal.ToString(); }
				catch { VAR_Modal = ""; }
				try { VAR_Penjualan                     = CIFFinancialInformationDetailResponse.body.penjualanNetto.ToString(); }
				catch { VAR_Penjualan = ""; }
				try { VAR_PendapatanOperasional         = CIFFinancialInformationDetailResponse.body.pendapatanNettoBersih.ToString(); }
				catch { VAR_PendapatanOperasional = ""; }
				try { VAR_BiayaOperasional              = CIFFinancialInformationDetailResponse.body.biayaDibayarDimuka.ToString(); }
				catch { VAR_BiayaOperasional = ""; }
				try { VAR_PendapatanNonOperasional      = CIFFinancialInformationDetailResponse.body.pendapatanLainLainBebanNetto.ToString(); }
				catch { VAR_PendapatanNonOperasional = ""; }
				try { VAR_BiayaNonOperasional           = CIFFinancialInformationDetailResponse.body.biayaPenjualanADMDanUmum.ToString(); }
				catch { VAR_BiayaNonOperasional = ""; }
				try { VAR_LabaRugiThnLaluStlhPajak      = CIFFinancialInformationDetailResponse.body.labaDitahan.ToString(); }
				catch { VAR_LabaRugiThnLaluStlhPajak = ""; }
				try { VAR_LabaRugiThnLaluSblmPajak      = CIFFinancialInformationDetailResponse.body.labaKotor.ToString(); }
				catch { VAR_LabaRugiThnLaluSblmPajak = ""; }

				Put hidden variable here
				try
				{
                    
				}
				catch
				{
                    
				}
			}
			else
			{
				Tools.popMessage(this, CIFFinancialInformationDetailResponse.soaHeader.responseMessage.ToString());
				Response.Redirect("");
			}
			VAR_to_CONTROL();
		}
		*/

		private void VAR_to_CONTROL()
		{
			TXT_TGL_LAP.Text                = VAR_PosisiLaporanKeuanganDay;
			DDL_BLN_LAP.SelectedValue       = VAR_PosisiLaporanKeuanganMonth;
			TXT_THN_LAP.Text                = VAR_PosisiLaporanKeuanganYear;
			RDO_PINJAMAN_LN.SelectedValue   = VAR_PinjamanLuarNegeri;
			DDL_DENO.SelectedValue          = VAR_Denominasi;
			DDL_AUDITED.SelectedValue       = VAR_AuditedUnaudited;
			DDL_CURR.SelectedValue          = VAR_Currency;
			TXT_JML_BLN.Text                = VAR_JumlahBulan;
			TXT_ACTIVA.Text                 = VAR_AktivaLancar;
			TXT_TOT_ACTIVA.Text             = VAR_TotalAktiva;
			TXT_WJB_BANK.Text               = VAR_KewajibankepadaBank;
			TXT_WJB_LANCAR.Text             = VAR_KewajibanLancar;
			TXT_TOT_WJB.Text                = VAR_TotalKewajiban;
			TXT_MODAL.Text                  = VAR_Modal;
			TXT_PENJUALAN.Text              = VAR_Penjualan;
			TXT_POP.Text                    = VAR_PendapatanOperasional;
			TXT_BOP.Text                    = VAR_BiayaOperasional;
			TXT_NON_POP.Text                = VAR_PendapatanNonOperasional;
			TXT_NON_BOP.Text                = VAR_BiayaNonOperasional;
			LR_AFTER.Text                   = VAR_LabaRugiThnLaluStlhPajak;
			LR_BEFORE.Text                  = VAR_LabaRugiThnLaluSblmPajak;
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()

		{
			TXT_TGL_LAP.Text                = "";
			DDL_BLN_LAP.SelectedValue       = "";
			TXT_THN_LAP.Text                = "";
			RDO_PINJAMAN_LN.SelectedValue   = "Y";
			DDL_DENO.SelectedValue          = "";
			DDL_AUDITED.SelectedValue       = "";
			DDL_CURR.SelectedValue          = "";
			TXT_JML_BLN.Text                = "";
			TXT_ACTIVA.Text                 = "";
			TXT_TOT_ACTIVA.Text             = "";
			TXT_WJB_BANK.Text               = "";
			TXT_WJB_LANCAR.Text             = "";
			TXT_TOT_WJB.Text                = "";
			TXT_MODAL.Text                  = "";
			TXT_PENJUALAN.Text              = "";
			TXT_POP.Text                    = "";
			TXT_BOP.Text                    = "";
			TXT_NON_POP.Text                = "";
			TXT_NON_BOP.Text                = "";
			LR_AFTER.Text                   = "";
			LR_BEFORE.Text                  = "";

			/* Hidden Variable
             
			 */
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("CIFListData2.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		/*
		private DQM.CIFFinancialInformationMaintenance.body BodyMaintenanceRequest = new DQM.CIFFinancialInformationMaintenance.body();
		private DQM.CIFFinancialInformationMaintenance.AccountInfoMaintenanceResponse ResponseMaintenanceClass = new DQM.CIFFinancialInformationMaintenance.AccountInfoMaintenanceResponse();
		*/

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			/*
			CONTROL_to_VAR();

			BodyMaintenanceRequest.aktivaBersihTakBerwujud          = "";
			BodyMaintenanceRequest.aktivaLancar                     = VAR_AktivaLancar;
			BodyMaintenanceRequest.aktivaLancarLainnya              = "";
			BodyMaintenanceRequest.aktivaNonLancarBersihLainnya     = "";
			BodyMaintenanceRequest.aktivaTetapBersih                = "";
			BodyMaintenanceRequest.amortisasiNonAktivaLancarLainnya = "";
			BodyMaintenanceRequest.amortisasiTakBerwujud            = "";
			BodyMaintenanceRequest.auditedNotAudited                = VAR_AuditedUnaudited;
			BodyMaintenanceRequest.bebanBunga                       = "";
			BodyMaintenanceRequest.biayaDibayarDimuka               = VAR_BiayaOperasional;
			BodyMaintenanceRequest.biayaPenjualanADMdanUmum         = VAR_BiayaNonOperasional;
			BodyMaintenanceRequest.biayaYgHarusDibayar              = "";
			BodyMaintenanceRequest.brandName1                       = "";
			BodyMaintenanceRequest.brandName2                       = "";
			BodyMaintenanceRequest.businessCondition1               = "";
			BodyMaintenanceRequest.businessCondition2               = "";
			BodyMaintenanceRequest.businessCondition3               = "";
			BodyMaintenanceRequest.businessCondition4               = "";
			BodyMaintenanceRequest.businessCondition5               = "";
			BodyMaintenanceRequest.capitalAdequacyRatio             = "";
			BodyMaintenanceRequest.capitalSubscribed                = "";
			BodyMaintenanceRequest.currencyCode                     = VAR_Currency;
			BodyMaintenanceRequest.currentRatio                     = "";
			BodyMaintenanceRequest.customerNumber                   = "";
			BodyMaintenanceRequest.debSrviceCoverage                = "";
			BodyMaintenanceRequest.employeesMgmt                    = "";
			BodyMaintenanceRequest.employessLabor                   = "";
			BodyMaintenanceRequest.equity                           = "";
			BodyMaintenanceRequest.financialYear                    = "";
			BodyMaintenanceRequest.hargaPokokPenjualan              = "";
			BodyMaintenanceRequest.hutang                           = VAR_KewajibanLancar;
			BodyMaintenanceRequest.hutangBankJgkPendek              = "";
			BodyMaintenanceRequest.hutangJangkaPanjang              = "";
			BodyMaintenanceRequest.hutangJkPanjangYgAkanJatuhTempo  = "";
			BodyMaintenanceRequest.hutangJKPjgLainnya               = "";
			BodyMaintenanceRequest.hutangTerafiliasi                = "";
			BodyMaintenanceRequest.investasi                        = "";
			BodyMaintenanceRequest.jumlahBulan                      = VAR_JumlahBulan;
			BodyMaintenanceRequest.jumlahSatuan                     = "";
			BodyMaintenanceRequest.kasDanBank                       = "";
			BodyMaintenanceRequest.kewajibanJkPanjang               = VAR_KewajibankepadaBank;
			BodyMaintenanceRequest.labaDitahan                      = VAR_LabaRugiThnLaluStlhPajak;
			BodyMaintenanceRequest.labaKotor                        = VAR_LabaRugiThnLaluSblmPajak;
			BodyMaintenanceRequest.labaOperasi                      = "";
			BodyMaintenanceRequest.ldr                              = "";
			BodyMaintenanceRequest.leverageJangkaPanjang            = "";
			BodyMaintenanceRequest.lokasi                           = "";
			BodyMaintenanceRequest.marketShare                      = "";
			BodyMaintenanceRequest.namAuditor2                      = "";
			BodyMaintenanceRequest.nameAuditor1                     = "";
			BodyMaintenanceRequest.pajangTerhutang                  = "";
			BodyMaintenanceRequest.pasivaLancar                     = "";
			BodyMaintenanceRequest.pdptLainSebelumMinusPjkDanBunga  = "";
			BodyMaintenanceRequest.pdptSebelumPajak                 = "";
			BodyMaintenanceRequest.pendapatanLainLainNetto          = VAR_PendapatanNonOperasional;
			BodyMaintenanceRequest.pendapatanNetto                  = "";
			BodyMaintenanceRequest.pendapatanNettoAktiva            = VAR_PendapatanOperasional;
			BodyMaintenanceRequest.pendapatanNettoModalNetto        = "";
			BodyMaintenanceRequest.penjaualanNetto                  = VAR_Penjualan;
			BodyMaintenanceRequest.penjualanThdKredit               = "";
			BodyMaintenanceRequest.penyusutanAktivatetap            = "";
			BodyMaintenanceRequest.perputaranHutang                 = "";
			BodyMaintenanceRequest.perputaranPersediaan             = "";
			BodyMaintenanceRequest.perputaranPiutang                = "";
			BodyMaintenanceRequest.perputaranUsaha                  = "";
			BodyMaintenanceRequest.persediaan                       = "";
			BodyMaintenanceRequest.persentasePenjualanA             = "";
			BodyMaintenanceRequest.persentasePenjualanB             = "";
			BodyMaintenanceRequest.persentasePenjualanC             = "";
			BodyMaintenanceRequest.persentasePenjualanD             = "";
			BodyMaintenanceRequest.persentasePenjualanE             = "";
			BodyMaintenanceRequest.persentasePenjualanF             = "";
			BodyMaintenanceRequest.pinjamanLuarNegeri               = VAR_PinjamanLuarNegeri;
			BodyMaintenanceRequest.piutanfTerafiliasi               = "";
			BodyMaintenanceRequest.piutang                          = "";
			BodyMaintenanceRequest.piutangTerafiliasi               = "";
			BodyMaintenanceRequest.pjkYgTelahDiBayar                = "";
			BodyMaintenanceRequest.posPosLuarBiasa                  = "";
			BodyMaintenanceRequest.quickAssetRatio                  = "";
			BodyMaintenanceRequest.rasioHutangTerhadapModal         = "";
			BodyMaintenanceRequest.rataRataAktiva                   = "";
			BodyMaintenanceRequest.rataRataHutangBank               = "";
			BodyMaintenanceRequest.reinstatedDate                   = "";
			BodyMaintenanceRequest.remarkLine1                      = "";
			BodyMaintenanceRequest.remarkLine2                      = "";
			BodyMaintenanceRequest.reviewDate                       = "";
			BodyMaintenanceRequest.sahamBiasa                       = "";
			BodyMaintenanceRequest.salesItem                        = "";
			BodyMaintenanceRequest.suratBerharga                    = "";
			BodyMaintenanceRequest.surplusDanCadangan               = "";
			BodyMaintenanceRequest.tanggalEntryDMY                  = "";
			BodyMaintenanceRequest.timeInterestEarned               = "";
			BodyMaintenanceRequest.tingkatPertumbuhanPenjualan      = "";
			BodyMaintenanceRequest.totalAktiva                      = VAR_TotalAktiva;
			BodyMaintenanceRequest.totalAktivaNonLancar             = "";
			BodyMaintenanceRequest.totalCapacity                    = "";
			BodyMaintenanceRequest.totalKewajiban                   = VAR_TotalKewajiban;
			BodyMaintenanceRequest.totalModal                       = VAR_Modal;
			BodyMaintenanceRequest.totalPasiva                      = "";

			ResponseMaintenanceClass = MainClass.CIFMaintenanceDataKeuanganService(BodyMaintenanceRequest);
			RetrieveDataFromSOAResponse(ResponseMaintenanceClass);
			*/
		}

		private void CONTROL_to_VAR()
		{
			VAR_PosisiLaporanKeuanganDay    = TXT_TGL_LAP.Text.ToString();
			VAR_PosisiLaporanKeuanganMonth  = DDL_BLN_LAP.SelectedValue.ToString();
			VAR_PosisiLaporanKeuanganYear   = TXT_THN_LAP.Text.ToString();
			VAR_PinjamanLuarNegeri          = RDO_PINJAMAN_LN.SelectedValue.ToString();
			VAR_Denominasi                  = DDL_DENO.SelectedValue.ToString();
			VAR_AuditedUnaudited            = DDL_AUDITED.SelectedValue.ToString();
			VAR_Currency                    = DDL_CURR.SelectedValue.ToString();
			VAR_JumlahBulan                 = TXT_JML_BLN.Text.ToString();
			VAR_AktivaLancar                = TXT_ACTIVA.Text.ToString();
			VAR_TotalAktiva                 = TXT_TOT_ACTIVA.Text.ToString();
			VAR_KewajibankepadaBank         = TXT_WJB_BANK.Text.ToString();
			VAR_KewajibanLancar             = TXT_WJB_LANCAR.Text.ToString();
			VAR_TotalKewajiban              = TXT_TOT_WJB.Text.ToString();
			VAR_Modal                       = TXT_MODAL.Text.ToString();
			VAR_Penjualan                   = TXT_PENJUALAN.Text.ToString();
			VAR_PendapatanOperasional       = TXT_POP.Text.ToString();
			VAR_BiayaOperasional            = TXT_BOP.Text.ToString();
			VAR_PendapatanNonOperasional    = TXT_NON_POP.Text.ToString();
			VAR_BiayaNonOperasional         = TXT_NON_BOP.Text.ToString();
			VAR_LabaRugiThnLaluStlhPajak    = LR_AFTER.Text.ToString();
			VAR_LabaRugiThnLaluSblmPajak    = LR_BEFORE.Text.ToString();
		}

		/*
		public void RetrieveDataFromSOAResponse(DQM.CIFFinancialInformationMaintenance.AccountInfoMaintenanceResponse response)
		{
			if (response.soaHeader.responseCode.ToString() == "1")
			{
				try { VAR_PosisiLaporanKeuanganDay          = ""; }
				catch { VAR_PosisiLaporanKeuanganDay = ""; }
				try { VAR_PosisiLaporanKeuanganMonth        = ""; }
				catch { VAR_PosisiLaporanKeuanganMonth = ""; }
				try { VAR_PosisiLaporanKeuanganYear         = ""; }
				catch { VAR_PosisiLaporanKeuanganYear = ""; }
				try { VAR_PinjamanLuarNegeri                = response.body.pinjamanLuarNegeri.ToString(); }
				catch { VAR_PinjamanLuarNegeri = ""; }
				try { VAR_Denominasi                        = ""; }
				catch { VAR_Denominasi = ""; }
				try { VAR_AuditedUnaudited                  = response.body.auditedNotAudited.ToString(); }
				catch { VAR_AuditedUnaudited = ""; }
				try { VAR_Currency                          = response.body.currencyCode.ToString(); }
				catch { VAR_Currency = ""; }
				try { VAR_JumlahBulan                       = response.body.jumlahBulan.ToString(); }
				catch { VAR_JumlahBulan = ""; }
				try { VAR_AktivaLancar                      = response.body.aktivaLancar.ToString(); }
				catch { VAR_AktivaLancar = ""; }
				try { VAR_TotalAktiva                       = response.body.totalAktiva.ToString(); }
				catch { VAR_TotalAktiva = ""; }
				try { VAR_KewajibankepadaBank               = response.body.kewajibanJkPanjang.ToString(); }
				catch { VAR_KewajibankepadaBank = ""; }
				try { VAR_KewajibanLancar                   = response.body.hutang.ToString(); }
				catch { VAR_KewajibanLancar = ""; }
				try { VAR_TotalKewajiban                    = response.body.totalKewajiban.ToString(); }
				catch { VAR_TotalKewajiban = ""; }
				try { VAR_Modal                             = response.body.totalModal.ToString(); }
				catch { VAR_Modal = ""; }
				try { VAR_Penjualan                         = response.body.penjaualanNetto.ToString(); }
				catch { VAR_Penjualan = ""; }
				try { VAR_PendapatanOperasional             = response.body.pendapatanNettoAktiva.ToString(); }
				catch { VAR_PendapatanOperasional = ""; }
				try { VAR_BiayaOperasional                  = response.body.biayaDibayarDimuka.ToString(); }
				catch { VAR_BiayaOperasional = ""; }
				try { VAR_PendapatanNonOperasional          = response.body.pendapatanLainLainNetto.ToString(); }
				catch { VAR_PendapatanNonOperasional = ""; }
				try { VAR_BiayaNonOperasional               = response.body.biayaPenjualanADMdanUmum.ToString(); }
				catch { VAR_BiayaNonOperasional = ""; }
				try { VAR_LabaRugiThnLaluStlhPajak          = response.body.labaDitahan.ToString(); }
				catch { VAR_LabaRugiThnLaluStlhPajak = ""; }
				try { VAR_LabaRugiThnLaluSblmPajak          = response.body.labaKotor.ToString(); }
				catch { VAR_LabaRugiThnLaluSblmPajak = ""; }

				Put hidden variable here
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
	}
}
