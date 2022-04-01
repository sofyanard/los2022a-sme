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


namespace SME.CreditOperations
{
	/// <summary>
	/// Summary description for NotaAnalisa.
	/// </summary>
	public partial class AsuransiKredit : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			// Put user code to initialize the page here
			if (!IsPostBack) 
			{
				this.viewData();	
				TXT_NAMA_TTD.Text			= (string) Session["FullName"];
				TXT_ALAMAT_JCCO_TTD.Text	= (string) Session["BranchName"];
				TXT_DEPT_TTD.Text			= (string) Session["GroupName"];
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

		protected void BTN_VIEW_Click(object sender, System.EventArgs e)
		{
			this.viewFinal();
		}

		private void viewFinal() 
		{
			Server.Transfer("AsuransiJiwa_Final.aspx");
		}

		private void viewData() 
		{
			this.TXT_TANGGAL.Text = DateTime.Today.ToString("dd MMM yyyy");

			string ic_id = "";
			string ap_regno = Request.QueryString["regno"];
			string cu_ref = Request.QueryString["cu_ref"];
			string seq = Request.QueryString["seq"];

			conn.QueryString = "select * " +
				"from VW_CREOPR_NOTARYASSIGN_CREDASU " +
				"where  " +
				"ap_regno = '" + ap_regno + "' " +
				"and seq = '" + seq + "'";
			conn.ExecuteQuery();

			this.TXT_ALI_AMOUNT.Text = conn.GetFieldValue("ACR_AMOUNT");
			this.TXT_ALI_DURATION.Text = conn.GetFieldValue("ACR_DURATION");
			this.TXT_ALI_PREMI.Text = conn.GetFieldValue("ACR_PREMI");
			ic_id = conn.GetFieldValue("IC_ID");

			conn.QueryString = "select * from RFINSURANCECOMPANY where IC_ID = '" + ic_id + "'";
			conn.ExecuteQuery();		
			this.TXT_NAMA_PT.Text = conn.GetFieldValue("IC_DESC");
			this.TXT_ALAMAT1_PT.Text = conn.GetFieldValue("IC_ADDR1");
			this.TXT_ALAMAT2_PT.Text = conn.GetFieldValue("IC_ADDR2");
			this.TXT_ALAMAT3_PT.Text = conn.GetFieldValue("IC_ADDR3");
			this.TXT_UP.Text = conn.GetFieldValue("IC_CONTACT");


//			conn.QueryString = "select " +
//				"isnull(cu_firstname,'') + ' ' + isnull(cu_middlename,'') + ' ' + isnull(cu_lastname,'') as name, " +
//				"isnull(cu_dob,'') as dob, " +
//				"isnull(cu_addr1,'') + ' ' + isnull(cu_addr2,'') + ' ' + isnull(cu_addr3,'') + ' ' + isnull(cu_city,'') as addr, " +
//				"isnull(cu_phnarea,'') + ' ' + isnull(cu_phnnum,'') + ' ' + isnull(cu_phnext,'') as phone, " +
//				"isnull(year(getdate()) - year(cu_dob),'') as umur " +
//				"from cust_personal where cu_ref = '" + cu_ref + "'";

			conn.QueryString = "SELECT " +
					"APPLICATION.CU_REF, " +
					"APPLICATION.AP_REGNO, " +
					"CUSTOMER.CU_CUSTTYPEID, " +
					"CASE CUSTOMER.CU_CUSTTYPEID WHEN '01' " +
						"THEN isnull(COMPTYPEDESC, '') + ' ' + isnull(CU_COMPNAME, '') " +
						"ELSE isnull(CU_FIRSTNAME, '') + ' ' + isnull(CU_MIDDLENAME, '') + ' ' + isnull(CU_LASTNAME, '') END AS CU_NAME, " +
					"CASE CUSTOMER.CU_CUSTTYPEID WHEN '01' " +
						"THEN isnull(CU_COMPADDR1, '') + ' ' + isnull(CU_COMPADDR2, '') + ' ' + isnull(CU_COMPADDR3,'') + ' ' + isnull(CU_COMPCITY,'') " +
						"ELSE isnull(CU_ADDR1, '') + ' ' + isnull(CU_ADDR2, '') + ' ' + isnull(CU_ADDR3,'') + ' ' + isnull(CU_CITY,'') END AS CU_ADDR, " +
					"CASE CUSTOMER.CU_CUSTTYPEID WHEN '01' " +
						"THEN isnull(CU_COMPPHNAREA, '') +  ' ' + isnull(CU_COMPPHNNUM, '') + ' ' + ISNULL(CU_COMPPHNEXT,'') " +
						"ELSE isnull(CU_PHNAREA, '') + ' ' + isnull(CU_PHNNUM, '') + ' ' +  isnull(CU_PHNEXT, '') END AS CU_PHN, " +
					"CASE CUSTOMER.CU_CUSTTYPEID WHEN '01'  " +
						"THEN null " +
						"ELSE isnull(cu_dob,'') end as CU_DOB, " +
					"isnull(year(getdate()) - year(cu_dob),'') as CU_AGE " +
				"FROM " +
					"APPLICATION LEFT OUTER JOIN " +
					"CUSTOMER ON APPLICATION.CU_REF = CUSTOMER.CU_REF LEFT OUTER JOIN " +
					"CUST_COMPANY ON APPLICATION.CU_REF = CUST_COMPANY.CU_REF LEFT OUTER JOIN " +
					"RFCOMPTYPE ON CUST_COMPANY.CU_COMPTYPE = RFCOMPTYPE.COMPTYPEID LEFT OUTER JOIN " +
					"CUST_PERSONAL ON APPLICATION.CU_REF = CUST_PERSONAL.CU_REF " +
				"WHERE APPLICATION.AP_REGNO = '" + ap_regno + "'";
			conn.ExecuteQuery();

			this.TXT_DEBITUR.Text = conn.GetFieldValue("CU_NAME").ToUpper();
			this.TXT_CU_NAME.Text = conn.GetFieldValue("CU_NAME").ToUpper();

			string custtype = conn.GetFieldValue("CU_CUSTTYPEID");
			if (custtype != "01") 
			{
				this.TXT_CU_DOB.Text = tool.FormatDate(conn.GetFieldValue("CU_DOB"),false);
				this.TXT_CU_AGE.Text = conn.GetFieldValue("CU_AGE");
			}
			this.TXT_CU_ADDR.Text = conn.GetFieldValue("CU_ADDR").ToUpper();
			this.TXT_CU_PHN.Text = conn.GetFieldValue("CU_PHN");
		}

		protected void BTN_VIEW_2_Click(object sender, System.EventArgs e)
		{
			this.viewFinal();
		}
	}
}
