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
	/// Summary description for NotaAnalisa.
	/// </summary>
	public partial class AsuransiKredit_Final : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn = new Connection();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack) 
			{
				this.viewData();
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

		private void BTN_PRINT_1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void BTN_PRINT_2_Click(object sender, System.EventArgs e)
		{
		
		}

		private void viewData() 
		{
			this.LBL_NO_SURAT.Text = Request.Form["TXT_NO_SURAT"];
			this.LBL_TANGGAL.Text = Request.Form["TXT_TANGGAL"];
			this.LBL_LAMPIRAN.Text = Request.Form["TXT_LAMPIRAN"];
			this.LBL_NAMA_PT.Text = Request.Form["TXT_NAMA_PT"];
			this.LBL_ALAMAT1_PT.Text = Request.Form["TXT_ALAMAT1_PT"];
			this.LBL_ALAMAT2_PT.Text = Request.Form["TXT_ALAMAT2_PT"];
			this.LBL_ALAMAT3_PT.Text = Request.Form["TXT_ALAMAT3_PT"];
			this.LBL_TELP_PT.Text = Request.Form["TXT_TELP_PT"];
			this.LBL_UP.Text = Request.Form["TXT_UP"];
			this.LBL_DEBITUR.Text = Request.Form["TXT_DEBITUR"];
			this.LBL_DEBITUR_NAME.Text = Request.Form["TXT_CU_NAME"];
			this.LBL_DEBITUR_DOB.Text = Request.Form["TXT_CU_DOB"];
			this.LBL_DEBITUR_AGE.Text = Request.Form["TXT_CU_AGE"];
			this.LBL_UANG_TANGGUNG.Text = Request.Form["TXT_ALI_AMOUNT"];
			this.LBL_MASA_TANGGUNG.Text = Request.Form["TXT_ALI_DURATION"];
			this.LBL_PREMI.Text = Request.Form["TXT_ALI_PREMI"];
			this.LBL_DEBITUR_ADDR.Text = Request.Form["TXT_CU_ADDR"];
			this.LBL_DEBITUR_PHN.Text = Request.Form["TXT_CU_PHN"];
			this.LBL_JCCO_TTD.Text = Request.Form["TXT_JCCO_TTD"];
			this.LBL_ALAMAT_JCCO_TTD.Text = Request.Form["TXT_ALAMAT_JCCO_TTD"];
			this.LBL_NAMA_TTD.Text = Request.Form["TXT_NAMA_TTD"];
			this.LBL_DEPT_TTD.Text = Request.Form["TXT_DEPT_TTD"];
		}

	}
}
