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

namespace SME.CreditOperations.CoverNote
{
	/// <summary>
	/// Summary description for AsuransiJaminan_Main.
	/// </summary>
	public partial class AsuransiJaminan_Main : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack) 
			{
				this.ViewData();
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

		private void ViewData() 
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
			this.TXT_DEBITUR_NAME.Text = Request.Form["TXT_DEBITUR_NAME"];
			this.TXT_DEBITUR_ADDR.Text = Request.Form["TXT_DEBITUR_ADDR"];
			this.TXT_OBYEK_TANGGUNG.Text = Request.Form["TXT_OBYEK_TANGGUNG"];
			this.TXT_ACA_AMOUNT.Text = Request.Form["TXT_ACA_AMOUNT"];
			this.TXT_LOKASI_TANGGUNG.Text = Request.Form["TXT_LOKASI_TANGGUNG"];
			this.TXT_ACA_DURATION.Text = Request.Form["TXT_ACA_DURATION"];
			this.TXT_CP_BM.Text = Request.Form["TXT_CP_BM"];
			this.TXT_CP_BM_PHN.Text = Request.Form["TXT_CP_BM_PHN"];
			this.TXT_JCCO_TTD.Text = Request.Form["TXT_JCCO_TTD"];
			this.TXT_ALAMAT_JCCO_TTD.Text = Request.Form["TXT_ALAMAT_JCCO_TTD"];
			this.TXT_NAMA_TTD.Text = Request.Form["TXT_NAMA_TTD"];
			this.TXT_DEPT_TTD.Text = Request.Form["TXT_DEPT_TTD"];
			this.TXT_LAIN_LAIN.Text = Request.Form["TXT_LAIN_LAIN"];			

			string frame = "<iframe src='AsuransiJaminan_Final.aspx?" + 
				"txt_no_surat=" + this.TXT_NO_SURAT.Text +
				"&txt_tanggal=" + this.TXT_TANGGAL.Text + 
				"&txt_lampiran=" + this.TXT_NAMA_PT.Text +
				"&txt_nama_pt=" + this.TXT_NAMA_PT.Text +
				"&txt_alamat1_pt= " + this.TXT_ALAMAT1_PT.Text +
				"&txt_alamat2_pt= " + this.TXT_ALAMAT2_PT.Text +
				"&txt_alamat3_pt= " + this.TXT_ALAMAT3_PT.Text +
				"&txt_telp_pt=" + this.TXT_TELP_PT.Text + 
				"&txt_up=" + this.TXT_UP.Text +
				"&txt_debitur=" + this.TXT_DEBITUR.Text +
				"&txt_debitur_name=" + this.TXT_DEBITUR_NAME.Text +
				"&txt_debitur_addr=" + this.TXT_DEBITUR_ADDR.Text +
				"&txt_obyek_tanggung=" + this.TXT_OBYEK_TANGGUNG.Text +
				"&txt_aca_amount=" + this.TXT_ACA_AMOUNT.Text +
				"&txt_lokasi_tanggung=" + this.TXT_LOKASI_TANGGUNG.Text +
				"&txt_aca_duration=" + this.TXT_ACA_DURATION.Text +
				"&txt_cp_bm=" + this.TXT_CP_BM.Text +
				"&txt_jcco_ttd=" + this.TXT_JCCO_TTD.Text +
				"&txt_alamat_jcco_ttd=" + this.TXT_ALAMAT_JCCO_TTD.Text +
				"&txt_nama_ttd=" + this.TXT_NAMA_TTD.Text +
				"&txt_dept_ttd=" + this.TXT_DEPT_TTD.Text;
				//"&txt_lain_lain=" + this.TXT_LAIN_LAIN.Text +

			int count = 1;
			try 
			{
				string lain_lain = this.TXT_LAIN_LAIN.Text;
				int idx = lain_lain.IndexOf("\r\n");
				
				while (idx > 0) 
				{					
					string temp = lain_lain.Substring(0,idx);
					string temp2 = lain_lain.Substring(idx+2);
					frame = frame + "&lain_lain" + count + "=" + temp;
					idx = temp2.IndexOf("\r\n");
					lain_lain = temp2;
					count += 1;
				}
			}
			catch (Exception ex) 
			{
				Console.Write(ex.Message);
			}

			frame = frame + "&jumlah_lain=" + (count-1) + "' id='if1' frameborder='0' width=800 height=900></iframe>";

			this.PH.Controls.Add(new LiteralControl(frame));
		}		
	}
}
