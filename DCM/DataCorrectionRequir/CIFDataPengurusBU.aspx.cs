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
	/// Summary description for CIFDataPengurusBU.
	/// </summary>
	public partial class CIFDataPengurusBU : System.Web.UI.Page
	{
		protected Connection conn;
		protected Connection2 conn2;
		protected Connection2 conn3;

		/*Deklarasi variable*/
		private string VAR_CIFNo;
		private string VAR_Nama;
		private string VAR_JenisNasabah;
		private string VAR_BODBerdiriSejakDay;
		private string VAR_BODBerdiriSejakMonth;
		private string VAR_BODBerdiriSejakYear;
		private string VAR_JenisKelamin;
		private string VAR_ShareSaham;		
		private string VAR_JenisIDUtama;
		private string VAR_NoIDUtama;
		private string VAR_ExpiredDateIDUtamaDay;
		private string VAR_ExpiredDateIDUtamaMonth;
		private string VAR_ExpiredDateIDUtamaYear;
		private string VAR_NPWP;
		private string VAR_LokasiDatiII;
		private string VAR_Alamat;
		private string VAR_KodePos;
		private string VAR_Kecamatan;
		private string VAR_BUC;
		private string VAR_KodeHubungan;
		//private string VAR_RemoveLink;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewField();
			conn = (Connection) Session["Connection"];
			conn2 = new Connection2(ConfigurationSettings.AppSettings["conn2"]);
			conn3 = new Connection2(ConfigurationSettings.AppSettings["conn2"]);

			if(!IsPostBack)
			{
				DDL_BLN_COMP.Items.Add(new ListItem("--Pilih--", ""));
				DDL_BLN_EXP.Items.Add(new ListItem("--Pilih--", ""));
				
				for (int i=1; i<=12; i++)
				{
					DDL_BLN_COMP.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_EXP.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));					
				}

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_BU";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JNS_NASABAH.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_JENISKELAMIN";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JNS_KELAMIN.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_JENISID";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JNS_ID.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_BUC";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_BUC.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT * FROM VW_DCM_CIF_DDL_KODEHUBUNGAN";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_KODE_HUB.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				/*************************************************************************************************/
               
				//ini dilakukan begitu ada data di grid
				/*RetrieveSOA();*/

				/*Cek error message*/
				/*string strconn = "select *, case isnull(CS_NATSTAT,'0') when '0' then 'WNI' when '1' then 'WNA' end as STATUS_DESC, case isnull(CS_KEYPERSON,'0') when '0' then 'TIDAK' when '1' then 'YA' end as CS_KEYPERSON " +
					"from VW_CUST_STOCKHOLDER " +
					"where EMAS_CIF ='" + Request.QueryString["nocif"] + "'";
				BindData(DatGridDataPerusahaan.ID, strconn);*/

				CheckError();
			}

			ViewMenu();

			//TesSOA();
		}

		private void ViewField()
		{
			TXT_TOT_SAHAM.Enabled = false;
			TXT_CIF.Enabled = false;
			TXT_NAMA.Enabled = false;
			DDL_JNS_NASABAH.Enabled = false;
			TXT_TGL_COMP.Enabled = false;
			DDL_BLN_COMP.Enabled = false;
			TXT_THN_COMP.Enabled = false;
			DDL_JNS_KELAMIN.Enabled = false;
			TXT_SAHAM.Enabled = false;
			TXT_NPWP.Enabled = false;
			DDL_JNS_ID.Enabled = false;
			TXT_ID_UTAMA.Enabled = false;
			DDL_DATI.Enabled = false;
			TXT_ALAMAT.Enabled = false;
			TXT_KECAMATAN.Enabled = false;
			TXT_CU_ZIPCODE.Enabled = false;
			BTN_SEARCHCOMP.Enabled = false;
			DDL_BUC.Enabled = false;
			DDL_KODE_HUB.Enabled = false;
			CHK_REMOVED.Enabled = false;
		}

		/*
		private DQM.SOA.SOA_DQM MainClass = new DQM.SOA.SOA_DQM();
		private DQM.HubunganAntarNasabah.body HubunganAntarNasabahBody;
		private DQM.HubunganAntarNasabah.RelationBetweenCustomerResponse HubunganAntarNasabahResponse;
		*/
		
		/*
		public void TesSOA()
		{
			HubunganAntarNasabahBody = new DQM.HubunganAntarNasabah.body();
			HubunganAntarNasabahBody.customerNumber = "1000018787";
			HubunganAntarNasabahBody.relatedCIFNumber = "1000019172";
			HubunganAntarNasabahBody.relationshipTypeCode = "DR";

			HubunganAntarNasabahResponse = MainClass.HubunganAntarNasabahService(HubunganAntarNasabahBody);

			string ab = HubunganAntarNasabahResponse.body.corporateRelationshipDescription.ToString();
			string cd = HubunganAntarNasabahResponse.body.shareholdingPercentage.ToString();
			string ef = HubunganAntarNasabahResponse.body.shortName.ToString();
		}
		*/

		private void BindData(string dataGridName, string strconn)
		{
			DMS.CuBESCore.Tools tools = new Tools();

			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();

				System.Data.DataTable dt = new System.Data.DataTable();
				dt = conn.GetDataTable().Copy();

				System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);
				dg.DataSource = dt;

				try
				{
					dg.DataBind();
				}
				catch
				{
					dg.CurrentPageIndex = dg.PageCount - 1;	
					dg.DataBind();
				}

				for (int i = 0; i < dg.Items.Count; i++)
				{
					dg.Items[i].Cells[6].Text =  tools.MoneyFormat(dg.Items[i].Cells[6].Text);
				} 

				conn.ClearData();
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

				conn3.QueryString = "SELECT IDCONTROL FROM DCM_TABLE_ERROR WHERE PAGE = 'CIFDataPengurusBU.aspx' AND MESSAGE = '" + err_msg.Trim() + "'";
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

		/*
		private DQM.HubunganAntarNasabah.body BodyRequest = new DQM.HubunganAntarNasabah.body();
		private DQM.HubunganAntarNasabah.RelationBetweenCustomerResponse ResponseClass = new DQM.HubunganAntarNasabah.RelationBetweenCustomerResponse();
        
		private void RetrieveSOA()
		{
			BodyRequest.customerNumber = Request.QueryString["cifno"];
			BodyRequest.relatedCIFNumber = "";
			BodyRequest.relationshipTypeCode = "";

			ResponseClass = MainClass.HubunganAntarNasabahService(BodyRequest);

			if (ResponseClass.soaHeader.responseCode == 1)
			{
				VAR_CIFNo = "";
				VAR_Nama = "";
				VAR_JenisNasabah = "";
				VAR_BODBerdiriSejakDay = "";
				VAR_BODBerdiriSejakMonth = "";
				VAR_BODBerdiriSejakYear = "";
				VAR_JenisKelamin = "";
				VAR_ShareSaham = "";
				VAR_JenisIDUtama = "";
				VAR_NoIDUtama = "";
				VAR_ExpiredDateIDUtamaDay = "";
				VAR_ExpiredDateIDUtamaMonth = "";
				VAR_ExpiredDateIDUtamaYear = "";
				VAR_NPWP = "";
				VAR_LokasiDatiII = "";
				VAR_Alamat = "";
				VAR_KodePos = "";
				VAR_Kecamatan = "";
				VAR_BUC = "";
				VAR_KodeHubungan = "";
				//VAR_RemoveLink            = "";

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
			TXT_CIF.Text                    = VAR_CIFNo;
			TXT_NAMA.Text                   = VAR_Nama;
			DDL_JNS_NASABAH.SelectedValue   = VAR_JenisNasabah;
			TXT_TGL_COMP.Text               = VAR_BODBerdiriSejakDay;
			DDL_BLN_COMP.SelectedValue      = VAR_BODBerdiriSejakMonth;
			TXT_THN_COMP.Text               = VAR_BODBerdiriSejakYear;
			DDL_JNS_KELAMIN.SelectedValue   = VAR_JenisKelamin;
			TXT_SAHAM.Text                  = VAR_ShareSaham;
			DDL_JNS_ID.SelectedValue        = VAR_JenisIDUtama;
			TXT_ID_UTAMA.Text               = VAR_NoIDUtama;
			TXT_EXP_DAY.Text                = VAR_ExpiredDateIDUtamaDay;
			DDL_BLN_EXP.SelectedValue       = VAR_ExpiredDateIDUtamaMonth;
			TXT_EXP_YEAR.Text               = VAR_ExpiredDateIDUtamaYear;
			TXT_NPWP.Text                   = VAR_NPWP;
			DDL_DATI.SelectedValue          = VAR_LokasiDatiII;
			TXT_ALAMAT.Text                 = VAR_Alamat;
			TXT_CU_ZIPCODE.Text             = VAR_KodePos;
			TXT_KECAMATAN.Text              = VAR_Kecamatan;
			DDL_BUC.SelectedValue           = VAR_BUC;
			DDL_KODE_HUB.SelectedValue      = VAR_KodeHubungan;
			//CHK_REMOVED.Checked           = VAR_RemoveLink;
		}

		/*
		private void CONTROL_to_VAR()
		{
			VAR_CIFNo                   = TXT_CIF.Text.ToString();
			VAR_Nama                    = TXT_NAMA.Text.ToString();
			VAR_JenisNasabah            = DDL_JNS_NASABAH.SelectedValue.ToString();
			VAR_BODBerdiriSejakDay      = TXT_TGL_COMP.Text.ToString();
			VAR_BODBerdiriSejakMonth    = DDL_BLN_COMP.SelectedValue.ToString();
			VAR_BODBerdiriSejakYear     = TXT_THN_COMP.Text.ToString();
			VAR_JenisKelamin            = DDL_JNS_KELAMIN.SelectedValue.ToString();
			VAR_ShareSaham              = TXT_SAHAM.Text.ToString();
			VAR_JenisIDUtama            = DDL_JNS_ID.SelectedValue.ToString();
			VAR_NoIDUtama               = TXT_ID_UTAMA.Text.ToString();
			VAR_ExpiredDateIDUtamaDay   = TXT_EXP_DAY.Text.ToString();
			DDL_BLN_EXP.SelectedValue   = VAR_ExpiredDateIDUtamaMonth.ToString();
			VAR_ExpiredDateIDUtamaYear  = TXT_EXP_YEAR.Text.ToString();
			VAR_NPWP                    = TXT_NPWP.Text.ToString();
			VAR_LokasiDatiII            = DDL_DATI.SelectedValue.ToString();
			VAR_Alamat                  = TXT_ALAMAT.Text.ToString();
			VAR_KodePos                 = TXT_CU_ZIPCODE.Text.ToString();
			VAR_Kecamatan               = TXT_KECAMATAN.Text.ToString();
			VAR_BUC                     = DDL_BUC.SelectedValue.ToString();
			VAR_KodeHubungan            = DDL_KODE_HUB.SelectedValue.ToString();
			//VAR_RemoveLink            = CHK_REMOVED.Checked.ToString();
		}
		*/
		
		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
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
						if (conn.GetFieldValue(i, 3).IndexOf("mc=") >= 0)
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

		private void ClearData()
		{
			TXT_CIF.Text                    = "";
			TXT_NAMA.Text                   = "";
			DDL_JNS_NASABAH.SelectedValue   = "";
			TXT_TGL_COMP.Text               = "";
			DDL_BLN_COMP.SelectedValue      = "";
			TXT_THN_COMP.Text               = "";
			DDL_JNS_KELAMIN.SelectedValue   = "";
			TXT_SAHAM.Text                  = "";
			DDL_JNS_ID.SelectedValue        = "";
			TXT_ID_UTAMA.Text               = "";
			TXT_EXP_DAY.Text                = "";
			DDL_BLN_EXP.SelectedValue       = "";
			TXT_EXP_YEAR.Text               = "";
			TXT_ALAMAT.Text                 = "";
			TXT_CU_ZIPCODE.Text             = "";
			DDL_BUC.SelectedValue           = "";
			DDL_KODE_HUB.SelectedValue      = "";
			CHK_REMOVED.Checked             = false;
			TXT_NPWP.Text                   = "";
			TXT_KECAMATAN.Text              = "";
		}

		protected void BTN_SEARCHCOMP_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_COMPZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("CIFListData2.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}
	}
}
