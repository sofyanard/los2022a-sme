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
	public partial class AsuransiJaminan : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn = new Connection();
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			// Put user code to initialize the page here
			if (!IsPostBack) 
			{
				this.viewData();
				TXT_NAMA_TTD.Text = (string) Session["FullName"];
				TXT_ALAMAT_JCCO_TTD.Text = (string) Session["BranchName"];
				TXT_DEPT_TTD.Text = (string) Session["GroupName"];
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
			//Server.Transfer("AsuransiJaminan_Final.aspx");			
			Server.Transfer("AsuransiJaminan_Main.aspx");			
		}

		private void viewData() 
		{
			this.TXT_TANGGAL.Text = DateTime.Today.ToString("dd MMM yyyy");

			string ic_id = "";
			string ap_regno = Request.QueryString["regno"];
			string cu_ref = Request.QueryString["cu_ref"];
			string seq = Request.QueryString["seq"];
			string productid = Request.QueryString["productid"];
			string cl_seq = Request.QueryString["cl_seq"];

			conn.QueryString = "select 	" +
					"rf.coltypedesc, " +
					"c.cl_desc,	" +
					"collinktable " +
				"from collateral c left outer join rfcollateraltype rf " +
					"on c.cl_type = rf.coltypeseq " +
				"where " +
					"cu_ref = '" + cu_ref + "' " +
					"and cl_seq = '" + cl_seq + "'";
			conn.ExecuteQuery();
			this.TXT_OBYEK_TANGGUNG.Text = conn.GetFieldValue("CL_DESC");
			string collinktable = conn.GetFieldValue("COLLINKTABLE");

			conn.QueryString = "select * from " + collinktable + " where CU_REF = '" + cu_ref + "' and CL_SEQ = '" + cl_seq + "'";
			conn.ExecuteQuery();
			if (collinktable.ToUpper().Trim() == "COLLATERAL_RE") 
			{
				this.TXT_LOKASI_TANGGUNG.Text = conn.GetFieldValue("CL_LOCJLN") + ' ' + 
					conn.GetFieldValue("CL_LOCRT") + ' ' + 
					conn.GetFieldValue("CL_LOCRW") + ' ' +
					conn.GetFieldValue("CL_LOCKAVNO") + ' ' +
					conn.GetFieldValue("CL_COLLOC");
			}

			/*
			conn.QueryString = "select * " +
				"from APPCOLASURANCE " +
				"where  " +
				"ap_regno = '" + ap_regno + "' " +
				"and seq = '" + seq + "' " +
				"and productid = '" + productid + "' " +
				"and cl_seq = '" + cl_seq + "'";
			*/
			conn.QueryString = "select distinct * " +
				"from APPCOLASURANCE " +
				"where  " +
				"ap_regno = '" + ap_regno + "' " +
				"and seq = '" + seq + "' " +				
				"and cl_seq = '" + cl_seq + "'";
			conn.ExecuteQuery();
			this.TXT_ACA_AMOUNT.Text = conn.GetFieldValue("ACA_AMOUNT");
			this.TXT_ACA_DURATION.Text = conn.GetFieldValue("ACA_DURATION");
			ic_id = conn.GetFieldValue("IC_ID");

			conn.QueryString = "select * from RFINSURANCECOMPANY where IC_ID = '" + ic_id + "'";
			conn.ExecuteQuery();		
			this.TXT_NAMA_PT.Text = conn.GetFieldValue("IC_DESC");
			this.TXT_ALAMAT1_PT.Text = conn.GetFieldValue("IC_ADDR1");
			this.TXT_ALAMAT2_PT.Text = conn.GetFieldValue("IC_ADDR2");
			this.TXT_ALAMAT3_PT.Text = conn.GetFieldValue("IC_ADDR3");
			this.TXT_UP.Text = conn.GetFieldValue("IC_CONTACT");

			conn.QueryString = "SELECT " +
				"APPLICATION.CU_REF, " +
				"APPLICATION.AP_REGNO, " +
				"CASE CUSTOMER.CU_CUSTTYPEID WHEN '01' " +
					"THEN isnull(COMPTYPEDESC, '') + ' ' + isnull(CU_COMPNAME, '') " +
					"ELSE isnull(CU_FIRSTNAME, '') + ' ' + isnull(CU_MIDDLENAME, '') + ' ' + isnull(CU_LASTNAME, '') END AS CU_NAME, " +
				"CASE CUSTOMER.CU_CUSTTYPEID WHEN '01' " +
					"THEN isnull(CU_COMPADDR1, '') + ' ' + isnull(CU_COMPADDR2, '') + ' ' + isnull(CU_COMPADDR3,'') + ' ' + isnull(CU_COMPCITY,'') " +
					"ELSE isnull(CU_ADDR1, '') + ' ' + isnull(CU_ADDR2, '') + ' ' + isnull(CU_ADDR3,'') + ' ' + isnull(CU_CITY,'') END AS CU_ADDR " +
				"FROM " +
					"APPLICATION LEFT OUTER JOIN " +
					"CUSTOMER ON APPLICATION.CU_REF = CUSTOMER.CU_REF LEFT OUTER JOIN " +
					"CUST_COMPANY ON APPLICATION.CU_REF = CUST_COMPANY.CU_REF LEFT OUTER JOIN " +
					"RFCOMPTYPE ON CUST_COMPANY.CU_COMPTYPE = RFCOMPTYPE.COMPTYPEID LEFT OUTER JOIN " +
					"CUST_PERSONAL ON APPLICATION.CU_REF = CUST_PERSONAL.CU_REF " +
				"WHERE APPLICATION.AP_REGNO = '" + ap_regno + "'";

			conn.ExecuteQuery();			
			this.TXT_DEBITUR.Text = conn.GetFieldValue("CU_NAME");
			this.TXT_DEBITUR_NAME.Text = conn.GetFieldValue("CU_NAME");
			this.TXT_DEBITUR_ADDR.Text = conn.GetFieldValue("CU_ADDR");
		}

		protected void BTN_VIEW_2_Click(object sender, System.EventArgs e)
		{
			this.viewFinal();
		}
	}
}
