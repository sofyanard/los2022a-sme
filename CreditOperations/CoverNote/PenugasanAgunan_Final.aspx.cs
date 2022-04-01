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
	public partial class PenugasaAgunan_Final : System.Web.UI.Page
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
			this.LBL_NO_SURAT.Text = Request.Form["TXT_NO_SURAT"];
			this.LBL_TANGGAL.Text = Request.Form["TXT_TANGGAL"];
			this.LBL_LAMPIRAN.Text = Request.Form["TXT_LAMPIRAN"];
			this.LBL_NAMA_APPRAISER.Text = Request.Form["TXT_NAMA_APPRAISER"];
			this.LBL_ALAMAT1_APPRAISER.Text = Request.Form["TXT_ALAMAT1_APPRAISER"];
			this.LBL_ALAMAT2_APPRAISER.Text = Request.Form["TXT_ALAMAT2_APPRAISER"];
			this.LBL_ALAMAT3_APPRAISER.Text = Request.Form["TXT_ALAMAT3_APPRAISER"];
			this.LBL_TELP_APPRAISER.Text = Request.Form["TXT_TELP_APPRAISER"];
			this.LBL_UP.Text = Request.Form["TXT_UP"];
			this.LBL_PERIHAL.Text = Request.Form["TXT_PERIHAL"];
			this.LBL_NO_SURAT_REF.Text = Request.Form["TXT_NO_SURAT_REF"];
			this.LBL_TGL_SURAT_REF.Text = Request.Form["TXT_TGL_SURAT_REF"];
			this.LBL_WAKTU_BAYAR.Text = Request.Form["TXT_WAKTU_BAYAR"];
			this.LBL_WAKTU_BAYAR_BILANG.Text = Request.Form["TXT_WAKTU_BAYAR_BILANG"];
			this.LBL_NAMA_COLLATERAL.Text = Request.Form["TXT_NAMA_COLLATERAL"];
			this.LBL_JUMLAH_COLL.Text = Request.Form["TXT_JUMLAH_COLL"];
			this.LBL_WAKTU_LAPORAN.Text = Request.Form["TXT_WAKTU_LAPORAN"];
			this.LBL_WAKTU_LAPORAN_BILANG.Text = Request.Form["TXT_WAKTU_LAPORAN_BILANG"];
			this.LBL_NAMA_COLL_FEE.Text = Request.Form["TXT_NAMA_COLLATERAL"];
			this.LBL_COLL_FEE.Text = Request.Form["TXT_COLL_FEE"];
			this.LBL_JCCO_TTD.Text = Request.Form["TXT_JCCO_TTD"];
			this.LBL_ALAMAT_JCCO_TTD.Text = Request.Form["TXT_ALAMAT_JCCO_TTD"];
			this.LBL_NAMA_TTD.Text = Request.Form["TXT_NAMA_TTD"];
			this.LBL_DEPT_TTD.Text = Request.Form["TXT_DEPT_TTD"];

//			this.LBL_NO_SURAT.Width = Request.Form["TXT_NO_SURAT"].ToString().Length;
//			this.LBL_TANGGAL.Width = Request.Form["TXT_TANGGAL"].ToString().Length;
//			this.LBL_NAMA_APPRAISER.Width = Request.Form["TXT_NAMA_APPRAISER"].ToString().Length;
//			this.LBL_ALAMAT1_APPRAISER.Width = Request.Form["TXT_ALAMAT1_APPRAISER"].ToString().Length;
//			this.LBL_ALAMAT2_APPRAISER.Width = Request.Form["TXT_ALAMAT2_APPRAISER"].ToString().Length;
//			this.LBL_ALAMAT3_APPRAISER.Width = Request.Form["TXT_ALAMAT3_APPRAISER"].ToString().Length;
//			this.LBL_TELP_APPRAISER.Width = Request.Form["TXT_TELP_APPRAISER"].ToString().Length;
//			this.LBL_UP.Width = Request.Form["TXT_UP"].ToString().Length;
//			this.LBL_PERIHAL.Width = Request.Form["TXT_PERIHAL"].ToString().Length;
//			this.LBL_NO_SURAT_REF.Width = Request.Form["TXT_NO_SURAT_REF"].ToString().Length;
//			this.LBL_TGL_SURAT_REF.Width = Request.Form["TXT_TGL_SURAT_REF"].ToString().Length;
//			this.LBL_WAKTU_BAYAR.Width = Request.Form["TXT_WAKTU_BAYAR"].ToString().Length;
//			this.LBL_WAKTU_BAYAR_BILANG.Width = Request.Form["TXT_WAKTU_BAYAR_BILANG"].ToString().Length;
//			this.LBL_NAMA_COLLATERAL.Width = Request.Form["TXT_NAMA_COLLATERAL"].ToString().Length;
//			this.LBL_JUMLAH_COLL.Width = Request.Form["TXT_JUMLAH_COLL"].ToString().Length;
//			this.LBL_WAKTU_LAPORAN.Width = Request.Form["TXT_WAKTU_LAPORAN"].ToString().Length;
//			this.LBL_WAKTU_LAPORAN_BILANG.Width = Request.Form["TXT_WAKTU_LAPORAN_BILANG"].ToString().Length;
//			this.LBL_NAMA_COLL_FEE.Width = Request.Form["TXT_NAMA_COLLATERAL"].ToString().Length;
//			this.LBL_COLL_FEE.Width = Request.Form["TXT_COLL_FEE"].ToString().Length;
//			this.LBL_JCCO_TTD.Width = Request.Form["TXT_JCCO_TTD"].ToString().Length;
//			this.LBL_ALAMAT_JCCO_TTD.Width = Request.Form["TXT_ALAMAT_JCCO_TTD"].ToString().Length;
//			this.LBL_NAMA_TTD.Width = Request.Form["TXT_NAMA_TTD"].ToString().Length;
//			this.LBL_DEPT_TTD.Width = Request.Form["TXT_DEPT_TTD"].ToString().Length;
		}

		private void BTN_CANCEL_2_Click(object sender, System.EventArgs e)
		{
			
		}

	}
}
