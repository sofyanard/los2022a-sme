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


namespace SME.CreditOperations
{
	/// <summary>
	/// Summary description for NotaAnalisa.
	/// </summary>
	public partial class AsuransiJaminan_Final : System.Web.UI.Page
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

		private void BTN_VIEW_Click(object sender, System.EventArgs e)
		{
			this.viewFinal();
		}

		private void viewFinal() 
		{
			Server.Transfer("AsuransiJaminan_Final.aspx");
		}

		private void viewData() 
		{
			this.LBL_NO_SURAT.Text = Request.QueryString["TXT_NO_SURAT"];
			this.LBL_TANGGAL.Text = Request.QueryString["TXT_TANGGAL"];
			this.LBL_LAMPIRAN.Text = Request.QueryString["TXT_LAMPIRAN"];
			this.LBL_NAMA_PT.Text = Request.QueryString["TXT_NAMA_PT"];
			this.LBL_ALAMAT1_PT.Text = Request.QueryString["TXT_ALAMAT1_PT"];
			this.LBL_ALAMAT2_PT.Text = Request.QueryString["TXT_ALAMAT2_PT"];
			this.LBL_ALAMAT3_PT.Text = Request.QueryString["TXT_ALAMAT3_PT"];
			this.LBL_TELP_PT.Text = Request.QueryString["TXT_TELP_PT"];
			this.LBL_UP.Text = Request.QueryString["TXT_UP"];
			this.LBL_DEBITUR.Text = Request.QueryString["TXT_DEBITUR"];
			this.LBL_NAMA_TANGGUNG.Text = Request.QueryString["TXT_DEBITUR_NAME"];
			this.LBL_ALAMAT_TANGGUNG.Text = Request.QueryString["TXT_DEBITUR_ADDR"];
			this.LBL_OBYEK_TANGGUNG.Text = Request.QueryString["TXT_OBYEK_TANGGUNG"];
			this.LBL_NILAI_TANGGUNG.Text = Request.QueryString["TXT_ACA_AMOUNT"];
			this.LBL_LOKASI_TANGGUNG.Text = Request.QueryString["TXT_LOKASI_TANGGUNG"];
			this.LBL_WAKTU_TANGGUNG.Text = Request.QueryString["TXT_ACA_DURATION"];
			//this.LBL_BANKER.Text = Request.QueryString["TXT_BANKER"];
			//this.TXT_LAIN_LAIN.Text = Request.QueryString["TXT_LAIN_LAIN"];
			this.LBL_CP_BM.Text = Request.QueryString["TXT_CP_BM"];
			this.LBL_CP_BM_PHN.Text = Request.QueryString["TXT_CP_BM_PHN"];
			this.LBL_JCCO_TTD.Text = Request.QueryString["TXT_JCCO_TTD"];
			this.LBL_ALAMAT_JCCO_TTD.Text = Request.QueryString["TXT_ALAMAT_JCCO_TTD"];
			this.LBL_NAMA_TTD.Text = Request.QueryString["TXT_NAMA_TTD"];
			this.LBL_DEPT_TTD.Text = Request.QueryString["TXT_DEPT_TTD"];			
			//string lain_lain = Request.QueryString["TXT_LAIN_LAIN"];

			string lain_lain = "";
			string jumlah_lain = Request.QueryString["JUMLAH_LAIN"];
			int jumlah = Convert.ToInt16(jumlah_lain);
			
			try 
			{
				for (int i = 1; i <= jumlah; i++)
				{					
					lain_lain = Request.QueryString["lain_lain" + i];
					Label lbl = new Label();
					lbl.Text = lain_lain;
					this.PH_LAIN_LAIN.Controls.Add(new LiteralControl("<LI>" + lbl.Text));
					this.PH_LAIN_LAIN.Controls.Add(new LiteralControl("<BR>"));					
				}
			}
			catch (Exception ex) 
			{
				Console.Write(ex.Message);
			}

//			this.LBL_NO_SURAT.Text = Request.Form["TXT_NO_SURAT"];
//			this.LBL_TANGGAL.Text = Request.Form["TXT_TANGGAL"];
//			this.LBL_LAMPIRAN.Text = Request.Form["TXT_LAMPIRAN"];
//			this.LBL_NAMA_PT.Text = Request.Form["TXT_NAMA_PT"];
//			this.LBL_ALAMAT1_PT.Text = Request.Form["TXT_ALAMAT1_PT"];
//			this.LBL_ALAMAT2_PT.Text = Request.Form["TXT_ALAMAT2_PT"];
//			this.LBL_ALAMAT3_PT.Text = Request.Form["TXT_ALAMAT3_PT"];
//			this.LBL_TELP_PT.Text = Request.Form["TXT_TELP_PT"];
//			this.LBL_UP.Text = Request.Form["TXT_UP"];
//			this.LBL_DEBITUR.Text = Request.Form["TXT_DEBITUR"];
//			this.LBL_NAMA_TANGGUNG.Text = Request.Form["TXT_DEBITUR_NAME"];
//			this.LBL_ALAMAT_TANGGUNG.Text = Request.Form["TXT_DEBITUR_ADDR"];
//			this.LBL_OBYEK_TANGGUNG.Text = Request.Form["TXT_OBYEK_TANGGUNG"];
//			this.LBL_NILAI_TANGGUNG.Text = Request.Form["TXT_ACA_AMOUNT"];
//			this.LBL_LOKASI_TANGGUNG.Text = Request.Form["TXT_LOKASI_TANGGUNG"];
//			this.LBL_WAKTU_TANGGUNG.Text = Request.Form["TXT_ACA_DURATION"];
//			//this.LBL_BANKER.Text = Request.Form["TXT_BANKER"];
//			//this.TXT_LAIN_LAIN.Text = Request.Form["TXT_LAIN_LAIN"];
//			this.LBL_CP_BM.Text = Request.Form["TXT_CP_BM"];
//			this.LBL_CP_BM_PHN.Text = Request.Form["TXT_CP_BM_PHN"];
//			this.LBL_JCCO_TTD.Text = Request.Form["TXT_JCCO_TTD"];
//			this.LBL_ALAMAT_JCCO_TTD.Text = Request.Form["TXT_ALAMAT_JCCO_TTD"];
//			this.LBL_NAMA_TTD.Text = Request.Form["TXT_NAMA_TTD"];
//			this.LBL_DEPT_TTD.Text = Request.Form["TXT_DEPT_TTD"];		
//			string lain_lain = Request.Form["TXT_LAIN_LAIN"];

//			try 
//			{				
//				int idx = lain_lain.IndexOf("\r\n");
//				while (idx > 0) 
//				{
//					string temp = lain_lain.Substring(0,idx);
//					string temp2 = lain_lain.Substring(idx+2);
//
//					Label lbl = new Label();
//					lbl.Text = temp;
//					//this.PH_LAIN_LAIN.Controls.Add(lbl);
//					this.PH_LAIN_LAIN.Controls.Add(new LiteralControl("<LI>" + lbl.Text));
//					this.PH_LAIN_LAIN.Controls.Add(new LiteralControl("<BR>"));
//
//					idx = temp2.IndexOf("\r\n");
//					lain_lain = temp2;
//				}
//			}
//			catch (Exception ex) 
//			{
//				Console.Write(ex.Message);
//			}
		}

		private void BTN_VIEW_2_Click(object sender, System.EventArgs e)
		{
			this.viewFinal();
		}

	}
}
