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
using DMS.DBConnection;

namespace SME.Channeling.SPPKPrint
{
	/// <summary>
	/// Summary description for BICheckingRequestPrint.
	/// </summary>
	public partial class SPPKPrint : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Table TBL_CONTENT;
		protected System.Web.UI.WebControls.Button BTN_PRINT;

		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn ;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			if(!IsPostBack)
			{
				loadData();
			}
		}

		private void loadData()
		{
			/*TBL_CONTENT.Rows.Add(new TableRow());
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[0].Text = "No.";
			TBL_CONTENT.Rows[0].Cells[0].Width = 30;
			TBL_CONTENT.Rows[0].Cells[0].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[1].Text = "No Surat";
			TBL_CONTENT.Rows[0].Cells[1].Width = 120;
			TBL_CONTENT.Rows[0].Cells[1].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[2].Text = "Nama Pejabat";
			TBL_CONTENT.Rows[0].Cells[2].Width = 80;
			TBL_CONTENT.Rows[0].Cells[2].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[3].Text = "No NPWP";
			TBL_CONTENT.Rows[0].Cells[3].Width = 80;
			TBL_CONTENT.Rows[0].Cells[3].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[4].Text = "Jenis Debitur";
			TBL_CONTENT.Rows[0].Cells[4].Width = 20;
			TBL_CONTENT.Rows[0].Cells[4].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[5].Text = "Nama";
			TBL_CONTENT.Rows[0].Cells[5].Width = 150;
			TBL_CONTENT.Rows[0].Cells[5].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[6].Text = "Alamat";
			TBL_CONTENT.Rows[0].Cells[6].Width = 180;
			TBL_CONTENT.Rows[0].Cells[6].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[7].Text = "Kota";
			TBL_CONTENT.Rows[0].Cells[7].Width = 60;
			TBL_CONTENT.Rows[0].Cells[7].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[8].Text = "No KTP/AKTA";
			TBL_CONTENT.Rows[0].Cells[8].Width = 80;
			TBL_CONTENT.Rows[0].Cells[8].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[9].Text = "Tempat Lahir";
			TBL_CONTENT.Rows[0].Cells[9].Width = 60;
			TBL_CONTENT.Rows[0].Cells[9].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[10].Text = "Tgl Lahir/Issuance Akta Pendirian";
			TBL_CONTENT.Rows[0].Cells[10].Width = 80;
			TBL_CONTENT.Rows[0].Cells[10].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[11].Text = "Jabatan";
			TBL_CONTENT.Rows[0].Cells[11].Width = 80;
			TBL_CONTENT.Rows[0].Cells[11].CssClass= "HeaderPrint";*/

			conn.QueryString = "EXEC CHANNELING_PRINT_SPPK '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			LBL_NOMOR_SURAT.Text = conn.GetFieldValue("LBL_NOMOR_SURAT");
			LBL_TANGGAL_SURAT.Text = conn.GetFieldValue("LBL_TANGGAL_SURAT");
			LBL_LAMPIRAN_SURAT.Text = conn.GetFieldValue("LBL_LAMPIRAN_SURAT");
			LBL_KEPADA_YTH.Text = conn.GetFieldValue("LBL_KEPADA_YTH");
			LBL_SDR.Text = conn.GetFieldValue("LBL_SDR");
			LBL_DETAIL_JALAN.Text = conn.GetFieldValue("LBL_DETAIL_JALAN");
			LBL_CHANNELING_AGENT.Text = conn.GetFieldValue("LBL_CHANNELING_AGENT");
			LABEL_PERJANJIAN_KERJASAMA_DENGAN.Text = conn.GetFieldValue("LABEL_PERJANJIAN_KERJASAMA_DENGAN");
			LABEL_NOMOR_PERJANJIAN.Text = conn.GetFieldValue("LABEL_NOMOR_PERJANJIAN");
			LABEL_TANGGAL_PERJANJIAN.Text = conn.GetFieldValue("LABEL_TANGGAL_PERJANJIAN");
			LBL_LIMIT_KREDIT.Text = conn.GetFieldValue("LBL_LIMIT_KREDIT");
			LBL_JENIS_KREDIT.Text = conn.GetFieldValue("LBL_JENIS_KREDIT");
			LBL_SIFAT_KREDIT.Text = conn.GetFieldValue("LBL_SIFAT_KREDIT");
			LBL_TUJUAN_PENGGUNAAN.Text = conn.GetFieldValue("LBL_TUJUAN_PENGGUNAAN");
			LBL_JANGKA_WAKTU.Text = conn.GetFieldValue("LBL_JANGKA_WAKTU");
			LBL_SUKU_BUNGA.Text = conn.GetFieldValue("LBL_SUKU_BUNGA");
			LBL_DENDA.Text = conn.GetFieldValue("LBL_DENDA");
			LBL_PROVISI.Text = conn.GetFieldValue("LBL_PROVISI");
			LBL_BIAYA_ADMINISTRASI.Text = conn.GetFieldValue("LBL_BIAYA_ADMINISTRASI");
			LBL_NAMA_AGENT_CHANNELING_2.Text = conn.GetFieldValue("LBL_NAMA_AGENT_CHANNELING_2");
			LBL_NOMOR_PERJANJIAN_CHANNELING_2.Text = conn.GetFieldValue("LBL_NOMOR_PERJANJIAN_CHANNELING_2");
			LBL_TANGGAL_PERJANJIAN_2.Text = conn.GetFieldValue("LBL_TANGGAL_PERJANJIAN_2");
			LBL_NAMA_UNIT_KERJA.Text = conn.GetFieldValue("LBL_NAMA_UNIT_KERJA");
	
			/*
			 *	LBL_NOMOR_SURAT,
				'' as LBL_TANGGAL_SURAT,
				'' as LBL_LAMPIRAN_SURAT,
				'' as LBL_KEPADA_YTH,
				'' as LBL_SDR,
				'' as LBL_DETAIL_JALAN,
				'' as LBL_CHANNELING_AGENT,
				'' as LABEL_PERJANJIAN_KERJASAMA_DENGAN,
				'' as LABEL_NOMOR_PERJANJIAN,
				'' as LABEL_TANGGAL_PERJANJIAN,
				'' as LBL_LIMIT_KREDIT,
				'' as LBL_JENIS_KREDIT,
				'' as LBL_SIFAT_KREDIT,
				'' as LBL_TUJUAN_PENGGUNAAN,
				'' as LBL_JANGKA_WAKTU,
				'' as LBL_SUKU_BUNGA,
				'' as LBL_DENDA,
				'' as LBL_PROVISI,
				'' as LBL_BIAYA_ADMINISTRASI,
				'' as LBL_NAMA_AGENT_CHANNELING_2,
				'' as LBL_NOMOR_PERJANJIAN_CHANNELING_2,
				'' as LBL_TANGAL_PERJANJIAN_2,
				'' as LBL_NAMA_UNIT_KERJA
			 * */
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
	}
}
