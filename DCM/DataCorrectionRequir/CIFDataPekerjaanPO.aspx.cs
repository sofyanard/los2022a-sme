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
	/// Summary description for CIFDataPekerjaanPO.
	/// </summary>
	public partial class CIFDataPekerjaanPO : System.Web.UI.Page
	{
		protected Connection2 conn3;
		protected Connection2 conn2;
		protected Connection conn;

		/* Deklarasi variable */
		private string VAR_NamaPerusahaan;
		private string VAR_TglMulaiBekerjaDay;
		private string VAR_TglMulaiBekerjaMonth;
		private string VAR_TglMulaiBekerjaYear;
		private string VAR_TglBerhentiBekerjaDay;
		private string VAR_TglBerhentiBekerjaMonth;
		private string VAR_TglBerhentiBekerjaYear;
		private string VAR_KodeIndustri;
		private string VAR_Jabatan;
		private string VAR_KodePekerjaan;
		private string VAR_CurrentSalary;
		private string VAR_Currency;

		/*
		 * Connect class SOA
		private DQM.SOA.SOA_DQM MainClass = new DQM.SOA.SOA_DQM();

		private DQM.CIFInquiry.body CIFInquiryBody;
		private DQM.CIFInquiry.CIFInquiryResponse CIFInquiryResponse;
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
				DDL_BLN_START.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_BLN_STOP.Items.Add(new ListItem("Pilih--", ""));
				DDL_INDUSTRY_CD.Items.Add(new ListItem("--Pilih--", ""));
				DDL_JABATAN.Items.Add(new ListItem("--Pilih--",""));				
				DDL_KODE_JOB.Items.Add(new ListItem("--Pilih--",""));
				DDL_CURR.Items.Add(new ListItem("--Pilih--", ""));

				for (int i=1; i<=12; i++)
				{
					DDL_BLN_START.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_STOP.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));					
				}

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_KODEINDUSTRI";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_INDUSTRY_CD.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_VALUTA";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_CURR.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				/* kurang DDL kode jabatan sama kode pekerjaan belum
 
				conn2.QueryString = "";
				conn2.ExecuteQuery();
				for (int i = 0; i < conn2.GetRowCount(); i++)
					DDL_JABATAN.Items.Add(new ListItem(conn2.GetFieldValue(i, 1), conn2.GetFieldValue(i, 0)));

				conn2.QueryString = "";
				conn2.ExecuteQuery();
				for (int i = 0; i < conn2.GetRowCount(); i++)
					DDL_KODE_JOB.Items.Add(new ListItem(conn2.GetFieldValue(i, 1), conn2.GetFieldValue(i, 0)));
				*/

				/*************************************************************************************************/
				//RetrieveSOA();

				/*Cek error message*/
				CheckError();
			}
			ViewMenu();
		}

		private void ViewField()
		{
			TXT_COMP_NAME.Enabled = false;
			TXT_TGL_START.Enabled = false;
			DDL_BLN_START.Enabled = false;
			TXT_THN_START.Enabled = false;
			TXT_TGL_STOP.Enabled = false;
			DDL_BLN_STOP.Enabled = false;
			TXT_THN_STOP.Enabled = false;
			DDL_INDUSTRY_CD.Enabled = false;
			DDL_JABATAN.Enabled = false;
			DDL_KODE_JOB.Enabled = false;
			TXT_SALARY.Enabled = false;
			DDL_CURR.Enabled = false;
		}

		private void CheckError()
		{
			string id = "", id_field = "";

			conn2.QueryString = "EXEC DCM_DATA_ERROR_CHECKING '" + Request.QueryString["cifno"] + "','1'";
			conn2.ExecuteQuery();

			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				string err_msg = conn2.GetFieldValue(i, "ERR_MSG").ToString().Replace(";","");

				conn3.QueryString = "SELECT IDCONTROL FROM DCM_TABLE_ERROR WHERE PAGE = 'CIFDataPekerjaanPO.aspx' AND MESSAGE = '" + err_msg.Trim() + "'";
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
			CIFInquiryBody              = new DQM.CIFInquiry.body();
			CIFInquiryBody.CIFNumber    = Request.QueryString["cifno"];
			CIFInquiryResponse          = MainClass.CIFMandatoryInquiryService(CIFInquiryBody);

			if (CIFInquiryResponse.soaHeader.responseCode == 1)
			{
				try { VAR_NamaPerusahaan            = ""; }
				catch { VAR_NamaPerusahaan          = ""; }
				try { VAR_TglMulaiBekerjaDay        = ""; }
				catch { VAR_TglMulaiBekerjaDay      = ""; }
				try { VAR_TglMulaiBekerjaMonth      = ""; }
				catch { VAR_TglMulaiBekerjaMonth    = ""; }
				try { VAR_TglMulaiBekerjaYear       = ""; }
				catch { VAR_TglMulaiBekerjaYear     = ""; }
				try { VAR_TglBerhentiBekerjaDay     = ""; }
				catch { VAR_TglBerhentiBekerjaDay   = ""; }
				try { VAR_TglBerhentiBekerjaMonth   = ""; }
				catch { VAR_TglBerhentiBekerjaMonth = ""; }
				try { VAR_TglBerhentiBekerjaYear    = ""; }
				catch { VAR_TglBerhentiBekerjaYear  = ""; }
				try { VAR_KodeIndustri              = CIFInquiryResponse.body.internalIndustryCode.ToString(); }
				catch { VAR_KodeIndustri            = ""; }
				try { VAR_Jabatan                   = ""; }
				catch { VAR_Jabatan                 = ""; }
				try { VAR_KodePekerjaan             = CIFInquiryResponse.body.occupationCode.ToString(); }
				catch { VAR_KodePekerjaan           = ""; }
				try { VAR_CurrentSalary             = ""; }
				catch { VAR_CurrentSalary           = ""; }
				try { VAR_Currency                  = CIFInquiryResponse.body.codeCurrency1.ToString(); }
				catch { VAR_Currency                = ""; }

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
		}*/

		private void VAR_to_CONTROL()
		{
			TXT_COMP_NAME.Text              = VAR_NamaPerusahaan;
			TXT_TGL_START.Text              = VAR_TglMulaiBekerjaDay;
			DDL_BLN_START.SelectedValue     = VAR_TglMulaiBekerjaMonth;
			TXT_THN_START.Text              = VAR_TglMulaiBekerjaYear;
			TXT_TGL_STOP.Text               = VAR_TglBerhentiBekerjaDay;
			DDL_BLN_STOP.SelectedValue      = VAR_TglBerhentiBekerjaMonth;
			TXT_THN_STOP.Text               = VAR_TglBerhentiBekerjaYear;
			DDL_INDUSTRY_CD.SelectedValue   = VAR_KodeIndustri;
			DDL_JABATAN.SelectedValue       = VAR_Jabatan;
			DDL_KODE_JOB.SelectedValue      = VAR_KodePekerjaan;
			TXT_SALARY.Text                 = VAR_CurrentSalary;
			DDL_CURR.SelectedValue          = VAR_Currency;
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{
			TXT_COMP_NAME.Text              = "";
			TXT_TGL_START.Text              = "";
			DDL_BLN_START.SelectedValue     = "";
			TXT_THN_START.Text              = "";
			TXT_TGL_STOP.Text               = "";
			DDL_BLN_STOP.SelectedValue      = "";
			TXT_THN_STOP.Text               = "";
			DDL_INDUSTRY_CD.SelectedValue   = "";
			DDL_JABATAN.SelectedValue       = "";
			DDL_KODE_JOB.SelectedValue      = "";
			TXT_SALARY.Text                 = "";
			DDL_CURR.SelectedValue          = "";

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
			BodyMaintenanceRequest.addressLine1                 = "";
			BodyMaintenanceRequest.addressLine2                 = "";
			BodyMaintenanceRequest.addressLine3                 = "";
			BodyMaintenanceRequest.addressLine4                 = "";
			BodyMaintenanceRequest.amount                       = "";
			BodyMaintenanceRequest.amount1                      = "";
			BodyMaintenanceRequest.amount2                      = "";
			BodyMaintenanceRequest.bankNumber                   = "";
			BodyMaintenanceRequest.birthIncorporationPlace      = "";
			BodyMaintenanceRequest.branchNumber                 = "";
			BodyMaintenanceRequest.businessUnitCode             = "";
			BodyMaintenanceRequest.code1                        = "";
			BodyMaintenanceRequest.codeField_C3                 = "";
			BodyMaintenanceRequest.codeField_T3                 = "";
			BodyMaintenanceRequest.codeField1                   = "";
			BodyMaintenanceRequest.codeField1_T2                = "";
			BodyMaintenanceRequest.codeField5                   = "";
			BodyMaintenanceRequest.codeField5_C2                = "";
			BodyMaintenanceRequest.countryOfCitizenship         = "";
			BodyMaintenanceRequest.currencyCode                 = VAR_Currency;
			BodyMaintenanceRequest.currencyCode1                = "";
			BodyMaintenanceRequest.currencyCode2                = "";
			BodyMaintenanceRequest.currencyCode3                = "";
			BodyMaintenanceRequest.currentSalary                = VAR_CurrentSalary;
			BodyMaintenanceRequest.customerName                 = "";
			BodyMaintenanceRequest.customerNumber               = "";
			BodyMaintenanceRequest.customerTypeCode             = "";
			BodyMaintenanceRequest.custPreviousName1            = "";
			BodyMaintenanceRequest.custPreviousName2            = "";
			BodyMaintenanceRequest.dobDDMMYYYY                  = "";
			BodyMaintenanceRequest.employeeDirectSuperiorName1  = "";
			BodyMaintenanceRequest.employeeDirectSuperiorName2  = "";
			BodyMaintenanceRequest.employementEndDate           = VAR_TglBerhentiBekerjaDay + VAR_TglBerhentiBekerjaMonth + VAR_TglBerhentiBekerjaYear;
			BodyMaintenanceRequest.employementStartDate         = VAR_TglMulaiBekerjaDay + VAR_TglMulaiBekerjaMonth + VAR_TglMulaiBekerjaYear;
			BodyMaintenanceRequest.employerIndustryCode         = VAR_KodeIndustri;
			BodyMaintenanceRequest.employerName                 = VAR_NamaPerusahaan;
			BodyMaintenanceRequest.fax                          = "";
			BodyMaintenanceRequest.genderCode                   = "";
			BodyMaintenanceRequest.handphone                    = "";
			BodyMaintenanceRequest.hubunganDenganBank           = "";
			BodyMaintenanceRequest.hubunganKeluarga             = "";
			BodyMaintenanceRequest.idIssuePlace                 = "";
			BodyMaintenanceRequest.idNumber                     = "";
			BodyMaintenanceRequest.idtypeCode                   = "";
			BodyMaintenanceRequest.informationDate              = "";
			BodyMaintenanceRequest.jenisDebitur                 = "";
			BodyMaintenanceRequest.jobDesignationCode           = VAR_Jabatan;
			BodyMaintenanceRequest.lokasiI                      = "";
			BodyMaintenanceRequest.memberOfKoperasi             = "";
			BodyMaintenanceRequest.motherMaidenName             = "";
			BodyMaintenanceRequest.occupationCode               = VAR_KodePekerjaan;
			BodyMaintenanceRequest.pemilikDebitur               = "";
			BodyMaintenanceRequest.postalCode                   = "";
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
			BodyMaintenanceRequest.telephone                    = "";
			BodyMaintenanceRequest.titleAfterName               = "";
			BodyMaintenanceRequest.titleBeforName               = "";
			BodyMaintenanceRequest.uicUserDefined               = "";
			BodyMaintenanceRequest.wilayahTLahir                = "";

			ResponseMaintenanceClass = MainClass.CIFMandatoryMaintenanceService(BodyMaintenanceRequest);
			RetrieveDataFromSOAResponse(ResponseMaintenanceClass);
			*/
		}

		private void CONTROL_to_VAR()
		{
			VAR_NamaPerusahaan          = TXT_COMP_NAME.Text;
			VAR_TglMulaiBekerjaDay      = TXT_TGL_START.Text;
			VAR_TglMulaiBekerjaMonth    = DDL_BLN_START.SelectedValue;
			VAR_TglMulaiBekerjaYear     = TXT_THN_START.Text;
			VAR_TglBerhentiBekerjaDay   = TXT_TGL_STOP.Text;
			VAR_TglBerhentiBekerjaMonth = DDL_BLN_STOP.SelectedValue;
			VAR_TglBerhentiBekerjaYear  = TXT_THN_STOP.Text;
			VAR_KodeIndustri            = DDL_INDUSTRY_CD.SelectedValue;
			VAR_Jabatan                 = DDL_JABATAN.SelectedValue;
			VAR_KodePekerjaan           = DDL_KODE_JOB.SelectedValue;
			VAR_CurrentSalary           = TXT_SALARY.Text;
			VAR_Currency                = DDL_CURR.SelectedValue;
		}

		/*
		public void RetrieveDataFromSOAResponse(DQM.CIFMandatoryMaintenance.CIFMandatoryMaintenanceResponse response)
		{
			if (response.soaHeader.responseCode.ToString() == "1")
			{
				try { VAR_NamaPerusahaan            = response.body.employerName.ToString(); }
				catch { VAR_NamaPerusahaan          = ""; }
				try { VAR_TglMulaiBekerjaDay        = DateTime.Parse(response.body.employementStartDate).Day.ToString(); }
				catch { VAR_TglMulaiBekerjaDay      = ""; }
				try { VAR_TglMulaiBekerjaMonth      = DateTime.Parse(response.body.employementStartDate).Month.ToString(); }
				catch { VAR_TglMulaiBekerjaMonth    = ""; }
				try { VAR_TglMulaiBekerjaYear       = DateTime.Parse(response.body.employementStartDate).Year.ToString(); }
				catch { VAR_TglMulaiBekerjaYear     = ""; }
				try { VAR_TglBerhentiBekerjaDay     = DateTime.Parse(response.body.employementEndDate).Day.ToString(); }
				catch { VAR_TglBerhentiBekerjaDay   = ""; }
				try { VAR_TglBerhentiBekerjaMonth   = DateTime.Parse(response.body.employementEndDate).Month.ToString(); }
				catch { VAR_TglBerhentiBekerjaMonth = ""; }
				try { VAR_TglBerhentiBekerjaYear    = DateTime.Parse(response.body.employementEndDate).Year.ToString(); }
				catch { VAR_TglBerhentiBekerjaYear  = ""; }
				try { VAR_KodeIndustri              = response.body.employerIndustryCode.ToString(); }
				catch { VAR_KodeIndustri            = ""; }
				try { VAR_Jabatan                   = response.body.jobDesignationCode.ToString(); }
				catch { VAR_Jabatan                 = ""; }
				try { VAR_KodePekerjaan             = response.body.occupationCode.ToString(); }
				catch { VAR_KodePekerjaan           = ""; }
				try { VAR_CurrentSalary             = response.body.currentSalary.ToString(); }
				catch { VAR_CurrentSalary           = ""; }
				try { VAR_Currency                  = response.body.currencyCode.ToString(); }
				catch { VAR_Currency                = ""; }

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
