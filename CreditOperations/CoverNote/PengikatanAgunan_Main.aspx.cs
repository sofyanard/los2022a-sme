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
//using System.Collections.Specialized;	// Untuk Sementara

namespace SME.CreditProposal
{
	/// <summary>
	/// Summary description for NotaAnalisa.
	/// </summary>
	public partial class PengikatanAgunan_Main : System.Web.UI.Page
	{
	
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

		private void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
		
		}

		private void BTN_PRINT_2_Click(object sender, System.EventArgs e)
		{
		
		}

		private void viewData() 
		{	
			this.TXT_NO_SURAT.Text = Request.Form["TXT_NO_SURAT"];
			this.TXT_TANGGAL.Text = Request.Form["TXT_TANGGAL"];
			this.TXT_LAMPIRAN1.Text = Request.Form["TXT_LAMPIRAN1"];
			this.TXT_NAMA_NOTARIS.Text = Request.Form["TXT_NAMA_NOTARIS"];
			this.TXT_ALAMAT1_NOTARIS.Text = Request.Form["TXT_ALAMAT1_NOTARIS"];
			this.TXT_ALAMAT2_NOTARIS.Text = Request.Form["TXT_ALAMAT2_NOTARIS"];
			this.TXT_ALAMAT3_NOTARIS.Text = Request.Form["TXT_ALAMAT3_NOTARIS"];
			this.TXT_TELP_NOTARIS.Text = Request.Form["TXT_TELP_NOTARIS"];
			this.TXT_NAMA_DEBITUR.Text = Request.Form["TXT_NAMA_DEBITUR"];
			this.TXT_DIIKAT.Text = Request.Form["TXT_DIIKAT"];
			this.TXT_AN.Text = Request.Form["TXT_AN"];
			this.TXT_HAK_TANGGUNG.Text = Request.Form["TXT_HAK_TANGGUNG"];
			this.TXT_JCCO.Text = Request.Form["TXT_JCCO"];
			this.TXT_JUMLAH_IKAT.Text = Request.Form["TXT_JUMLAH_IKAT"];
			this.TXT_JUMLAH_IKAT_TERBILANG.Text = Request.Form["TXT_JUMLAH_IKAT_TERBILANG"];
			this.TXT_CP_BM.Text = Request.Form["TXT_CP_BM"];
			this.TXT_TLP_CP_BM.Text = Request.Form["TXT_TLP_CP_BM"];
			this.TXT_JCCO_TTD.Text = Request.Form["TXT_JCCO_TTD"];
			this.TXT_ALAMAT_JCCO_TTD.Text = Request.Form["TXT_ALAMAT_JCCO_TTD"];
			this.TXT_NAMA_TTD.Text = Request.Form["TXT_NAMA_TTD"];
			this.TXT_DEPT_TTD.Text = Request.Form["TXT_DEPT_TTD"];

			string frame = "<iframe src='PengikatanAgunan_Final.aspx?" +
				"txt_no_surat=" + this.TXT_NO_SURAT.Text + 
				"&txt_tanggal=" + this.TXT_TANGGAL.Text +
				"&txt_lampiran1=" + this.TXT_LAMPIRAN1.Text +
				"&txt_nama_notaris=" + this.TXT_NAMA_NOTARIS.Text +
				"&txt_alamat1_notaris=" + this.TXT_ALAMAT1_NOTARIS.Text +
				"&txt_alamat2_notaris=" + this.TXT_ALAMAT2_NOTARIS.Text +
				"&txt_alamat3_notaris=" + this.TXT_ALAMAT3_NOTARIS.Text +
				"&txt_telp_notaris=" + this.TXT_TELP_NOTARIS.Text +
				"&txt_nama_debitur=" + this.TXT_NAMA_DEBITUR.Text +
				"&txt_diikat=" + this.TXT_DIIKAT.Text +
				"&txt_an=" + this.TXT_AN.Text +
				"&txt_hak_tanggung=" + this.TXT_HAK_TANGGUNG.Text +
				"&txt_jcco=" + this.TXT_JCCO.Text +
				"&txt_jumlah_ikat=" + this.TXT_JUMLAH_IKAT.Text +
				"&txt_jumlah_ikat_terbilang=" + this.TXT_JUMLAH_IKAT_TERBILANG.Text +
				"&txt_cp_bm=" + this.TXT_CP_BM.Text +
				"&txt_tlp_cp_bm=" + this.TXT_TLP_CP_BM.Text +
				"&txt_jcco_ttd=" + this.TXT_JCCO_TTD.Text +
				"&txt_alamat_jcco_ttd=" + this.TXT_ALAMAT_JCCO_TTD.Text +
				"&txt_nama_ttd=" + this.TXT_NAMA_TTD.Text +
				"&txt_dept_ttd=" + this.TXT_DEPT_TTD.Text;

			//----------------------------------------------------------------
			string lampir = Request.Form["TXT_LAMPIRAN"];
			int idx = lampir.IndexOf("\r\n");
			int count = 1;
			try 
			{
				while (idx > 0) 
				{
					string temp = lampir.Substring(0,idx);
					string temp2 = lampir.Substring(idx+2);

					frame = frame + "&lain_lain" + count + "=" + temp;
					count += 1;
					//				Label lbl = new Label();
					//				lbl.Text = temp;				
					//				this.PH_LAMPIRAN.Controls.Add(new LiteralControl("<LI>" + lbl.Text));
					//				this.PH_LAMPIRAN.Controls.Add(new LiteralControl("<BR>"));

					idx = temp2.IndexOf("\r\n");
					lampir = temp2;
				}
			} 
			catch (Exception ex) 
			{
				Console.Write(ex.Message);
			}
			//----------------------------------------------------------------

			frame = frame + "&jumlah_lain=" + (count-1) + "' id='if1' frameborder='0' width=750 height=1150></iframe>";

			this.PH1.Controls.Add(new LiteralControl(frame));
		}

		private void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			this.BTN_CANCEL_CLICKED();
		}

		private void BTN_CANCEL_2_Click(object sender, System.EventArgs e)
		{
			this.BTN_CANCEL_CLICKED();
		}

		private void BTN_CANCEL_CLICKED() 
		{
			
		}
	}
}
