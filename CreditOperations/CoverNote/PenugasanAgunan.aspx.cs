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


namespace SME.CreditProposal
{
	/// <summary>
	/// Summary description for .
	/// </summary>
	public partial class PenugasanAgunan : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
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

		protected void BTN_VIEW_2_Click(object sender, System.EventArgs e)
		{
			this.viewFinal();
		}

		private void viewFinal() 
		{
			Server.Transfer("PenugasanAgunan_Final.aspx");
		}

		private void viewData() 
		{
			this.TXT_TANGGAL.Text = DateTime.Now.ToString("dd MMM yyyy");

			string seq = Request["seq"].ToString().Trim();
			string regno = Request["regno"].ToString().Trim();
			string cu_ref = Request["cu_ref"].ToString().Trim();
			string agency_id = Request["agency_id"].ToString().Trim();
			string officer_id = Request["officer_id"];

			conn.QueryString = "select AGENCYID, AGENCYNAME from RFAGENCY where AGENCYID = '" + agency_id + "'";
			conn.ExecuteQuery();
			this.TXT_NAMA_APPRAISER.Text = conn.GetFieldValue("AGENCYNAME").ToString().Trim();

			TXT_NAMA_TTD.Text = (string) Session["FullName"];
			TXT_ALAMAT_JCCO_TTD.Text = (string) Session["BranchName"];

			/*
			conn.QueryString = "select USERID, SU_FULLNAME from SCUSER where USERID = '" + officer_id + "'";
			conn.ExecuteQuery();
			this.TXT_UP.Text = conn.GetFieldValue("SU_FULLNAME").ToString().Trim();
			*/

			conn.QueryString = "select COLTYPEDESC from COLLATERAL, RFCOLLATERALTYPE where CU_REF = '" + cu_ref + 
							   "' and CL_SEQ = '" + seq + 
							   "' AND cast(COLTYPESEQ as varchar) = cast(CL_TYPE as varchar)";
			conn.ExecuteQuery();
			this.TXT_NAMA_COLLATERAL.Text = conn.GetFieldValue("COLTYPEDESC");
			this.TXT_NAMA_COLL_FEE.Text = this.TXT_NAMA_COLLATERAL.Text;
		}
	}
}
