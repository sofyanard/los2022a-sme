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

namespace SME
{
	/// <summary>
	/// Summary description for EmailChecker.
	/// </summary>
	public class EmailChecker : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		
			string breakSpace = "\n";
			string NamaNasabah = "Nama Nasabah : ";
			NamaNasabah += "Prasetyo Wibowo";
			string NamaBank = "Nama Bank : ";
			NamaBank += "Bank Mandiri";
			string NamaDokumen = "Nama Dokumen : ";
			NamaDokumen += "SKMHT";
			string KelompokDokumen = "Kelompok Dokumen : ";
			KelompokDokumen += "Dokumen Pengikatan";
			string TanggalJatuhTempo = "Tanggal Jatuh Tempo : ";
			TanggalJatuhTempo += "01-01-2010";

			string Content = NamaNasabah + breakSpace + NamaBank + breakSpace + NamaDokumen + breakSpace + KelompokDokumen + breakSpace + TanggalJatuhTempo;
			Content += breakSpace;
			Content += "-----------------------------------------------------------";

			Content += breakSpace;

			/*
			 *	Prasetyo Wibowo 
				PT BANK MANDIRI (PERSERO) TBK.
				Policy, System & Procedure Group
				Business Process & System Reengineering Dept
				Plaza Mandiri
				Jl. Jend Gatot Subroto Kav 36-38 26th Floor
				Jakarta 12190
				TELEPHONE OFFICE | +62 21 524 5008
			 * */

			string footer = "Pembina System IPS";
			footer += breakSpace;
			footer += "PT BANK MANDIRI (PERSERO) TBK.";
			footer += breakSpace;
			footer += "Policy, System and Procedure Group";
			footer += breakSpace;
			footer += "Business Process and System Reengineering Dept";
			footer += breakSpace;
			Content += footer;
			footer = "Plaza Mandiri";
			footer += breakSpace;
			footer += "Jl. Jend Gatot Subroto Kav 36-38 26th Floor";
			footer += breakSpace;
			footer += "Jakarta 12190";
			footer += breakSpace;
			footer += "TELEPHONE OFFICE | +62 21 524 5008";
			Content += footer;

			string from = "kampret@bankmandiri.co.id";
			string to = "prasetyo.wibowo@bankmandiri.co.id";
			string subject = "Laporan Dokumen yang Akan Jatuh Tempo";


			MyConnection.SendEmail(from, to, subject, Content);
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
