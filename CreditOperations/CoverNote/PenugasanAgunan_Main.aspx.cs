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


namespace SME.CreditProposal
{
	/// <summary>
	/// Summary description for NotaAnalisa.
	/// </summary>
	public partial class PenugasaAgunan_Main : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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

		private void viewData() 
		{
			this.TXT_NO_SURAT.Text = Request.Form["TXT_NO_SURAT"];
			this.TXT_TANGGAL.Text = Request.Form["TXT_TANGGAL"];
			this.TXT_LAMPIRAN.Text = Request.Form["TXT_LAMPIRAN"];
			this.TXT_NAMA_APPRAISER.Text = Request.Form["TXT_NAMA_APPRAISER"];
			this.TXT_ALAMAT1_APPRAISER.Text = Request.Form["TXT_ALAMAT1_APPRAISER"];
			this.TXT_ALAMAT2_APPRAISER.Text = Request.Form["TXT_ALAMAT2_APPRAISER"];
			this.TXT_ALAMAT3_APPRAISER.Text = Request.Form["TXT_ALAMAT3_APPRAISER"];
			this.TXT_TELP_APPRAISER.Text = Request.Form["TXT_TELP_APPRAISER"];
			this.TXT_UP.Text = Request.Form["TXT_UP"];
			this.TXT_PERIHAL.Text = Request.Form["TXT_PERIHAL"];
			this.TXT_NO_SURAT_REF.Text = Request.Form["TXT_NO_SURAT_REF"];
			this.TXT_TGL_SURAT_REF.Text = Request.Form["TXT_TGL_SURAT_REF"];
			this.TXT_WAKTU_BAYAR.Text = Request.Form["TXT_WAKTU_BAYAR"];
			this.TXT_WAKTU_BAYAR_BILANG.Text = Request.Form["TXT_WAKTU_BAYAR_BILANG"];
			this.TXT_NAMA_COLLATERAL.Text = Request.Form["TXT_NAMA_COLLATERAL"];
			this.TXT_JUMLAH_COLL.Text = Request.Form["TXT_JUMLAH_COLL"];
			this.TXT_WAKTU_LAPORAN.Text = Request.Form["TXT_WAKTU_LAPORAN"];
			this.TXT_WAKTU_LAPORAN_BILANG.Text = Request.Form["TXT_WAKTU_LAPORAN_BILANG"];
			this.TXT_NAMA_COLL_FEE.Text = Request.Form["TXT_NAMA_COLL_FEE"];
			this.TXT_COLL_FEE.Text = Request.Form["TXT_COLL_FEE"];
			this.TXT_JCCO_TTD.Text = Request.Form["TXT_JCCO_TTD"];
			this.TXT_ALAMAT_JCCO_TTD.Text = Request.Form["TXT_ALAMAT_JCCO_TTD"];
			this.TXT_NAMA_TTD.Text = Request.Form["TXT_NAMA_TTD"];
			this.TXT_DEPT_TTD.Text = Request.Form["TXT_DEPT_TTD"];

			string frame = "<iframe src='PenugasanAgunan_Final.aspx?" +
				"txt_no_surat=" + this.TXT_NO_SURAT.Text +
				"&txt_tanggal=" + this.TXT_TANGGAL.Text +
				"&txt_lampiran=" + this.TXT_LAMPIRAN.Text +
				"&txt_nama_appraiser=" + this.TXT_NAMA_APPRAISER.Text +
				"&txt_alamat1_appraiser=" + this.TXT_ALAMAT1_APPRAISER.Text +
				"&txt_alamat2_appraiser=" + this.TXT_ALAMAT2_APPRAISER.Text +
				"&txt_alamat3_appraiser=" + this.TXT_ALAMAT3_APPRAISER.Text +
				"&txt_telp_appraiser=" + this.TXT_TELP_APPRAISER.Text +
				"&txt_up=" + this.TXT_UP.Text +
				"&txt_perihal=" + this.TXT_PERIHAL.Text +
				"&txt_no_surat_ref=" + this.TXT_NO_SURAT_REF.Text +
				"&txt_tgl_surat_ref=" + this.TXT_TGL_SURAT_REF.Text +
				"&txt_waktu_bayar= " + this.TXT_WAKTU_BAYAR.Text +
				"&txt_waktu_bayar_bilang=" + this.TXT_WAKTU_BAYAR_BILANG.Text +
				"&txt_nama_collateral=" + this.TXT_NAMA_COLLATERAL.Text +
				"&txt_jumlah_coll=" + this.TXT_JUMLAH_COLL.Text +
				"&txt_waktu_laporan=" + this.TXT_WAKTU_LAPORAN.Text +
				"&txt_waktu_laporan_bilang=" + this.TXT_WAKTU_LAPORAN_BILANG.Text +
				"&txt_nama_coll_fee=" + this.TXT_NAMA_COLL_FEE.Text +
				"&txt_coll_fee=" + this.TXT_COLL_FEE.Text + 
				"&txt_jcco_ttd=" + this.TXT_JCCO_TTD.Text +
				"&txt_alamat_jcco_ttd=" + this.TXT_ALAMAT_JCCO_TTD.Text +
				"&txt_nama_ttd= " + this.TXT_NAMA_TTD.Text +
				"&txt_dept_ttd= " + this.TXT_DEPT_TTD.Text +
				"' id='if1' frameborder='0' width=750 height=1150></iframe>";

			this.PH1.Controls.Add(new LiteralControl(frame));
		}

		private void BTN_CANCEL_2_Click(object sender, System.EventArgs e)
		{
			
		}

	}
}
