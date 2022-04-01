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
	public partial class PengikatanAgunan_Final : System.Web.UI.Page
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
			this.LBL_NO_SURAT.Text = Request.Form["TXT_NO_SURAT"];
			this.LBL_TANGGAL.Text = Request.Form["TXT_TANGGAL"];
			this.LBL_LAMPIRAN1.Text = Request.Form["TXT_LAMPIRAN1"];
			this.LBL_NAMA_NOTARIS.Text = Request.Form["TXT_NAMA_NOTARIS"];
			this.LBL_ALAMAT1_NOTARIS.Text = Request.Form["TXT_ALAMAT1_NOTARIS"];
			this.LBL_ALAMAT2_NOTARIS.Text = Request.Form["TXT_ALAMAT2_NOTARIS"];
			this.LBL_ALAMAT3_NOTARIS.Text = Request.Form["TXT_ALAMAT3_NOTARIS"];
			this.LBL_TELP_NOTARIS.Text = Request.Form["TXT_TELP_NOTARIS"];
			this.LBL_NAMA_DEBITUR.Text = Request.Form["TXT_NAMA_DEBITUR"];
			this.LBL_DIIKAT.Text = Request.Form["TXT_DIIKAT"];
			this.LBL_AN.Text = Request.Form["TXT_AN"];
			this.LBL_HAK_TANGGUNG.Text = Request.Form["TXT_HAK_TANGGUNG"];
			this.LBL_JCCO.Text = Request.Form["TXT_JCCO"];
			this.LBL_JUMLAH_IKAT.Text = Request.Form["TXT_JUMLAH_IKAT"];
			this.LBL_JUMLAH_IKAT_TERBILANG.Text = Request.Form["TXT_JUMLAH_IKAT_TERBILANG"];

			//this.LBL_LAMPIRAN.Text = Request.Form["TXT_LAMPIRAN"];

			this.LBL_CP_BM.Text = Request.Form["TXT_CP_BM"];
			this.LBL_TLP_CP_BM.Text = Request.Form["TXT_TLP_CP_BM"];
			this.LBL_JCCO_TTD.Text = Request.Form["TXT_JCCO_TTD"];
			this.LBL_ALAMAT_JCCO_TTD.Text = Request.Form["TXT_ALAMAT_JCCO_TTD"];
			this.LBL_NAMA_TTD.Text = Request.Form["TXT_NAMA_TTD"];
			this.LBL_DEPT_TTD.Text = Request.Form["TXT_DEPT_TTD"];

			//----------------------------------------------------------------
			string lampir = Request.Form["TXT_LAMPIRAN"];
			int idx = lampir.IndexOf("\r\n");
			//int idx2;

			while (idx > 0) 
			{
				string temp = lampir.Substring(0,idx);
				string temp2 = lampir.Substring(idx+2);

				Label lbl = new Label();
				lbl.Text = temp;				
				//this.PH_LAMPIRAN.Controls.Add(lbl);
				this.PH_LAMPIRAN.Controls.Add(new LiteralControl("<LI>" + lbl.Text));
				this.PH_LAMPIRAN.Controls.Add(new LiteralControl("<BR>"));

				idx = temp2.IndexOf("\r\n");
				lampir = temp2;
			}

//			if (idx > 0) 
//			{
//				string temp = lampir.Substring(0,idx);
//				string temp2 = lampir.Substring(idx+2);
//
//				Label lbl = new Label();
//				lbl.Text = temp;
//				this.PH_LAMPIRAN.Controls.Add(lbl);
//				this.PH_LAMPIRAN.Controls.Add(new LiteralControl("<BR>"));
//
//				//idx2 = lampir.IndexOf("\r\n",4);
//				idx2 = temp2.IndexOf("\r\n");
//				if (idx2 > 0) 
//				{				
//					//temp = lampir.Substring(idx2+2, idx2);
//					temp = temp2.Substring(0,idx2);
//
//					lbl = new Label();
//					lbl.Text = temp;
//					this.PH_LAMPIRAN.Controls.Add(lbl);
//					this.PH_LAMPIRAN.Controls.Add(new LiteralControl("<BR>"));
//				}
//				else 
//				{
//					lbl = new Label();
//					lbl.Text = temp2;
//					this.PH_LAMPIRAN.Controls.Add(lbl);
//					this.PH_LAMPIRAN.Controls.Add(new LiteralControl("<BR>"));
//				}
//			}
			//----------------------------------------------------------------
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
