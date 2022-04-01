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
	public partial class AsuransiJiwa_Main : System.Web.UI.Page
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
			this.TXT_NO_SURAT.Text = Request.Form["TXT_NO_SURAT"];
			this.TXT_TANGGAL.Text = Request.Form["TXT_TANGGAL"];
			this.TXT_LAMPIRAN.Text = Request.Form["TXT_LAMPIRAN"];
			this.TXT_NAMA_PT.Text = Request.Form["TXT_NAMA_PT"];
			this.TXT_ALAMAT1_PT.Text = Request.Form["TXT_ALAMAT1_PT"];
			this.TXT_ALAMAT2_PT.Text = Request.Form["TXT_ALAMAT2_PT"];
			this.TXT_ALAMAT3_PT.Text = Request.Form["TXT_ALAMAT3_PT"];
			this.TXT_TELP_PT.Text = Request.Form["TXT_TELP_PT"];
			this.TXT_UP.Text = Request.Form["TXT_UP"];
			this.TXT_DEBITUR.Text = Request.Form["TXT_DEBITUR"];
			this.TXT_CU_NAME.Text = Request.Form["TXT_CU_NAME"];
			this.TXT_CU_DOB.Text = Request.Form["TXT_CU_DOB"];
			this.TXT_CU_AGE.Text = Request.Form["TXT_CU_AGE"];
			this.TXT_ALI_AMOUNT.Text = Request.Form["TXT_ALI_AMOUNT"];
			this.TXT_ALI_DURATION.Text = Request.Form["TXT_ALI_DURATION"];
			this.TXT_ALI_PREMI.Text = Request.Form["TXT_ALI_PREMI"];
			this.TXT_CU_ADDR.Text = Request.Form["TXT_CU_ADDR"];
			this.TXT_CU_PHN.Text = Request.Form["TXT_CU_PHN"];
			this.TXT_JCCO_TTD.Text = Request.Form["TXT_JCCO_TTD"];
			this.TXT_ALAMAT_JCCO_TTD.Text = Request.Form["TXT_ALAMAT_JCCO_TTD"];
			this.TXT_NAMA_TTD.Text = Request.Form["TXT_NAMA_TTD"];
			this.TXT_DEPT_TTD.Text = Request.Form["TXT_DEPT_TTD"];

			string frame = "<iframe src='AsuransiJiwa_Final.aspx?" + 
				"txt_no_surat=" + this.TXT_NO_SURAT.Text +
				"&txt_tanggal=" + this.TXT_TANGGAL.Text +
				"&txt_lampiran=" + this.TXT_LAMPIRAN.Text +
				"&txt_nama_pt=" + this.TXT_NAMA_PT.Text +
				"&txt_alamat1_pt=" + this.TXT_ALAMAT1_PT.Text +
				"&txt_alamat2_pt=" + this.TXT_ALAMAT2_PT.Text +
				"&txt_alamat3_pt=" + this.TXT_ALAMAT3_PT.Text +
				"&txt_telp_pt=" + this.TXT_TELP_PT.Text +
				"&txt_up=" + this.TXT_UP.Text +
				"&txt_debitur=" + this.TXT_DEBITUR.Text +
				"&txt_cu_name=" + this.TXT_CU_NAME.Text +
				"&txt_cu_dob=" + this.TXT_CU_DOB.Text +
				"&txt_cu_age=" + this.TXT_CU_AGE.Text +
				"&txt_ali_amount=" + this.TXT_ALI_AMOUNT.Text +
				"&txt_ali_duration=" + this.TXT_ALI_DURATION.Text +
				"&txt_ali_premi=" + this.TXT_ALI_PREMI.Text +
				"&txt_cu_addr=" + this.TXT_CU_ADDR.Text +
				"&txt_cu_phn=" + this.TXT_CU_PHN.Text + 
				"&txt_jcco_ttd=" + this.TXT_JCCO_TTD.Text + 
				"&txt_alamat_jcco_ttd=" + this.TXT_ALAMAT_JCCO_TTD.Text +
				"&txt_nama_ttd=" + this.TXT_NAMA_TTD.Text +
				"&txt_dept_ttd=" + this.TXT_DEPT_TTD.Text +
				"' id='if1' frameborder='0' width=750 height=1150></iframe>";

			this.PH1.Controls.Add(new LiteralControl(frame));
		}

	}
}
