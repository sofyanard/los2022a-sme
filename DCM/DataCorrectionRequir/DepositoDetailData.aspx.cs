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
	/// Summary description for DepositoDetailData.
	/// </summary>
	public partial class DepositoDetailData : System.Web.UI.Page
	{
		protected Connection conn;
		protected Connection2 conn2;
		protected Connection2 conn3;

		/*Deklarasi variable*/
		private string VAR_NomorRekening;
		private string VAR_NamaNasabah;
		private string VAR_BUC;
		private string VAR_TujuanPenggunaanDana;
		private string VAR_TujuanPembukaanRekening;
		private string VAR_RangePendapatan;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			ViewField();

			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			conn2 = new Connection2(ConfigurationSettings.AppSettings["conn2"]);
			conn3 = new Connection2(ConfigurationSettings.AppSettings["conn2"]);

			if(!IsPostBack)
			{
				DDL_TUJ_PENG_DN.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_TUJ_PEM_REK.Items.Add(new ListItem("--Pilih--", ""));
				DDL_RANGE.Items.Add(new ListItem("--Pilih--", ""));

				conn2.QueryString = "select * from VW_DCM_DANA_DDL_PENGGUNADANA where active='1'";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_TUJ_PENG_DN.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_DANA_DDL_PEMBUKAAN_REKG where active='1'";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_TUJ_PEM_REK.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_DANA_DDL_SALARY_RANGE where active='1'";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_RANGE.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				/*************************************************************************************************/
				ViewData();

				//RetrieveSOA();

				/*Cek error message*/
				CheckError();
			}
		}

		private void ViewField()
		{
			DDL_TUJ_PENG_DN.Enabled = false;
			DDL_TUJ_PEM_REK.Enabled = false;
			DDL_RANGE.Enabled = false;
		}

		private void ViewData()
		{
			conn2.QueryString = "SELECT * FROM VW_DANA_LIST_DATA WHERE ACCTNO = '" + Request.QueryString["acctno"] + "' ";
			conn2.ExecuteQuery();
			TXT_NO_REK.Text     = conn2.GetFieldValue("ACCTNO");
			TXT_NM_NASABAH.Text = conn2.GetFieldValue("CUST_NAME");
			TXT_BUC.Text        = conn2.GetFieldValue("BUC");
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
				//VAR_NomorRekening           = "";
				//VAR_NamaNasabah             = "";
				//VAR_BUC                     = "";
				VAR_TujuanPenggunaanDana    = "";
				VAR_TujuanPembukaanRekening = "";
				VAR_RangePendapatan         = "";

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
			//TXT_NO_REK.Text                 = VAR_NomorRekening;			
			//TXT_NM_NASABAH.Text             = VAR_NamaNasabah;
			//TXT_BUC.Text                    = VAR_BUC;
			DDL_TUJ_PENG_DN.SelectedValue   = VAR_TujuanPenggunaanDana;
			DDL_TUJ_PEM_REK.SelectedValue   = VAR_TujuanPembukaanRekening;
			DDL_RANGE.SelectedValue         = VAR_RangePendapatan;
		}

		private void CheckError()
		{
			/*
			string id = "";

			conn2.QueryString = "EXEC DCM_DATA_ERROR_CHECKING '" + Request.QueryString["acctno"] + "','2'";
			conn2.ExecuteQuery();

			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				string err_msg = conn2.GetFieldValue(i, "ERR_MSG").ToString().Replace(";","");

				conn3.QueryString = "SELECT IDCONTROL FROM DCM_TABLE_ERROR WHERE PAGE = 'DepositoDetailData.aspx' AND MESSAGE = '" + err_msg.Trim() + "'";
				conn3.ExecuteQuery();

				if (conn3.GetFieldValue("IDCONTROL") != "")
				{
					id = "LBL_" + conn3.GetFieldValue("IDCONTROL");
					((Label)this.Page.FindControl(id)).ForeColor = Color.Red;
				}
			}
			*/

			string id = "", id_field = "";

			conn2.QueryString = "EXEC DCM_DATA_ERROR_CHECKING '" + Request.QueryString["acctno"] + "','1'";
			conn2.ExecuteQuery();

			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				string err_msg = conn2.GetFieldValue(i, "ERR_MSG").ToString().Replace(";","");

				conn3.QueryString = "SELECT IDCONTROL FROM DCM_TABLE_ERROR WHERE PAGE = 'DepositoDetailData.aspx' AND MESSAGE = '" + err_msg.Trim() + "'";
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
			DDL_TUJ_PENG_DN.SelectedValue   = "";
			DDL_TUJ_PEM_REK.SelectedValue   = "";
			DDL_RANGE.SelectedValue         = "";
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			/*
			BodyMaintenanceRequest.accountType = "";
			BodyMaintenanceRequest.agreementSigned = "";
			BodyMaintenanceRequest.amount1 = "";
			BodyMaintenanceRequest.appraisedName = "";
			BodyMaintenanceRequest.appraisedValue = "";
			BodyMaintenanceRequest.bagianDijamin = "";
			BodyMaintenanceRequest.bankOtherFD = "";
			BodyMaintenanceRequest.branchNumber = "";
			BodyMaintenanceRequest.buildingOwnership = "";
			BodyMaintenanceRequest.codeC2 = "";
			BodyMaintenanceRequest.codeT1 = "";
			BodyMaintenanceRequest.codeT2 = "";
			BodyMaintenanceRequest.collateralCode = "";
			BodyMaintenanceRequest.collateralDescription = "";
			BodyMaintenanceRequest.collateralID = "";
			BodyMaintenanceRequest.collateralYN = "";
			BodyMaintenanceRequest.collectionDt6 = "";
			BodyMaintenanceRequest.collectionDt7 = "";
			BodyMaintenanceRequest.collectionOfficer = "";
			BodyMaintenanceRequest.collectionStatus = "";
			BodyMaintenanceRequest.currency = "";
			BodyMaintenanceRequest.depositorName1 = "";
			BodyMaintenanceRequest.depositorName2 = "";
			BodyMaintenanceRequest.depositorName3 = "";
			BodyMaintenanceRequest.dueDateInstruction = "";
			BodyMaintenanceRequest.fdrAmount = "";
			BodyMaintenanceRequest.FDRExpiryDate = "";
			BodyMaintenanceRequest.fdrNo = "";
			BodyMaintenanceRequest.fdrRateQuoted = "";
			BodyMaintenanceRequest.guaranteeAmount = "";
			BodyMaintenanceRequest.institutionFDRIssued = "";
			BodyMaintenanceRequest.issueDate = "";
			BodyMaintenanceRequest.jenisAgunan = "";
			BodyMaintenanceRequest.jenisPengikatan = "";
			BodyMaintenanceRequest.liquidateValue = "";
			BodyMaintenanceRequest.locationofLotLine1 = "";
			BodyMaintenanceRequest.locationofLotLine2 = "";
			BodyMaintenanceRequest.locationofLotLine3 = "";
			BodyMaintenanceRequest.logBookNo = "";
			BodyMaintenanceRequest.lokasiAgunan = "";
			BodyMaintenanceRequest.mukimDistTown = "";
			BodyMaintenanceRequest.nilaiPengikatan = "";
			BodyMaintenanceRequest.nomorPengikatan = "";
			BodyMaintenanceRequest.paripasu = "";
			BodyMaintenanceRequest.penilaianMenurut = "";
			BodyMaintenanceRequest.privateCaveatExpDate = "";
			BodyMaintenanceRequest.registeredOwnerCIF = "";
			BodyMaintenanceRequest.relationship = "";
			BodyMaintenanceRequest.reviewDate = "";
			BodyMaintenanceRequest.spreadRate = "";
			BodyMaintenanceRequest.tenureTerm = "";
			BodyMaintenanceRequest.tenureTermCode = "";
			BodyMaintenanceRequest.tglPengikatan6 = "";
			BodyMaintenanceRequest.valuationDate = "";

			ResponseMaintenanceClass = MainClass.DEPMaintenanceService(BodyMaintenanceRequest);
			RetrieveDataFromSOAResponse(ResponseMaintenanceClass);
			*/
		}

		/*
		public void RetrieveDataFromSOAResponse(DQM.DEPMaintenance.DEPMaintenanceResponse response)
		{
			if (response.soaHeader.responseCode.ToString() == "1")
			{
				//TXT_NO_REK.Text                 = VAR_NomorRekening;			
				//TXT_NM_NASABAH.Text             = VAR_NamaNasabah;
				//TXT_BUC.Text                    = VAR_BUC;
				DDL_TUJ_PENG_DN.SelectedValue   = VAR_TujuanPenggunaanDana;
				DDL_TUJ_PEM_REK.SelectedValue   = VAR_TujuanPembukaanRekening;
				DDL_RANGE.SelectedValue         = VAR_RangePendapatan;

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
			VAR_NomorRekening           = TXT_NO_REK.Text;
			VAR_NamaNasabah             = TXT_NM_NASABAH.Text;
			VAR_BUC                     = TXT_BUC.Text;
			VAR_TujuanPenggunaanDana    = DDL_TUJ_PENG_DN.SelectedValue;
			VAR_TujuanPembukaanRekening = DDL_TUJ_PEM_REK.SelectedValue;
			VAR_RangePendapatan         = DDL_RANGE.SelectedValue;
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("DanaListData.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}
	}
}
