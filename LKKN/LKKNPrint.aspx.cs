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
using DMS.CuBESCore;
using Microsoft.VisualBasic;

namespace SME.LKKN1
{
	public partial class LKKNPrint : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected System.Web.UI.WebControls.CheckBoxList CheckBoxList1;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			if (!IsPostBack)
             {
			
				string regno		= Request.QueryString["regno"];
			
				ViewData(regno);
				ViewDataGrid(regno);
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

		private void ViewDataGrid (string regno)
		{
		

			DataTable dt1 = new DataTable();
			conn.QueryString = "select * from LKKNPENGURUS where ap_regno='" + regno + "'";
			conn.ExecuteQuery();
			dt1 = conn.GetDataTable().Copy();
			DATAGRID1.DataSource = dt1;
			DATAGRID1.DataBind();

			DataTable dt2 = new DataTable();
			conn.QueryString = "select * from LKKNAGUNAN where ap_regno='" + regno + "'";
			conn.ExecuteQuery();
			dt2 = conn.GetDataTable().Copy();
			DATAGRID2.DataSource = dt2;
			DATAGRID2.DataBind();

		}

		private void ViewData (string regno )
		{
			
			conn.QueryString = "SELECT NAMA,ALAMAT,TELP=(PHNAREA+'-'+PHNNUM+'-'+PHNEXT) " +
				"FROM VW_LKKN1 WHERE AP_REGNO ='" + regno + "'";
			conn.ExecuteQuery();
			
			LBL_CUST_NAME.Text = conn.GetFieldValue("NAMA");
			LBL_CU_ADDR1.Text	=	conn.GetFieldValue("ALAMAT");
			LBL_CU_PHN.Text	=	conn.GetFieldValue("TELP");
			
		   	LBL_BRANCH.Text = Request.QueryString["BRANCH"];

			conn.QueryString= " SELECT * FROM LKKN WHERE AP_REGNO ='"+ regno +"'" ;
			conn.ExecuteQuery();
			
						
			LBL_BO.Text = conn.GetFieldValue("SBO");
			LBL_CONTACTPERSON.Text = conn.GetFieldValue("CONTACTPERSON");
			LBL_KM_LAIN.Text = conn.GetFieldValue("KM_LAIN");
			LBL_OP_PENGALAMAN.Text = conn.GetFieldValue("OP_PENGALAMAN");
			LBL_OP_LAIN.Text = conn.GetFieldValue("OP_LAIN");
			LBL_OAT_LUASTANAH.Text = conn.GetFieldValue("OAT_LUASTANAH");
			LBL_OAT_LUASBGN.Text = conn.GetFieldValue("OAT_LUASBANGUNAN");
			
			try {CBL_KM_PENGALAMAN.SelectedValue = conn.GetFieldValue("KM_PENGALAMAN");}catch {}
			try{CBL_KM_ADMKEUANGAN.SelectedValue = conn.GetFieldValue("KM_ADMKEUANGAN"); }catch {}
			try {CBL_KM_KUALIFIKASI.SelectedValue = conn.GetFieldValue("KM_KUALIFIKASI"); }catch {}
			try {CBL_OP_SIFAT.SelectedValue = conn.GetFieldValue("OP_SIFAT"); }catch {}
			try	{CBL_OP_KARAKTER.SelectedValue = conn.GetFieldValue("OP_KARAKTER");}catch {}
			try {CBL_OP_ORGANISASI.SelectedValue = conn.GetFieldValue("OP_ORGANISASI");}catch {}
			
			try {CBL_OAT_DAERAH.SelectedValue = conn.GetFieldValue("OAT_DAERAH");}catch {}
			try {CBL_OAT_LOKASI.SelectedValue = conn.GetFieldValue("OAT_LOKASI");}catch {}
		 
			try {CBL_OAT_KONDISI.SelectedValue = conn.GetFieldValue("OAT_KONDISI");}catch {}
			try {CBL_OAT_STATUS.SelectedValue = conn.GetFieldValue("OAT_STATUS");}catch {}
			try {CBL_OAT_UTILISASI.SelectedValue = conn.GetFieldValue("OAT_UTILISASI");}catch {}
			try {CBL_OAT_PERALATAN.SelectedValue = conn.GetFieldValue("OAT_PERALATAN");}catch {}
			try {CBL_OAT_PRASARANA.SelectedValue = conn.GetFieldValue("OAT_PRASARANA");}catch {}
			try {CBL_OAT_BAHANBAKU.SelectedValue = conn.GetFieldValue("OAT_BAHANBAKU");}catch {}
		 
			LBL_OAT_PROSESPROD.Text = conn.GetFieldValue("OAT_PROSESPROD");
			LBL_OAT_SUPLIER.Text = conn.GetFieldValue("OAT_SUPLIER");
			LBL_OAT_REALISASIKUAN.Text = conn.GetFieldValue("OAT_REALISASIKUANTUM");
			LBL_OAT_REALISASINILAI.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAT_REALISASINILAI"));
			LBL_OAT_TARGETKUAN.Text = conn.GetFieldValue("OAT_TARGETKUANTUM");
			LBL_OAT_TARGETNILAI.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAT_TARGETNILAI"));
			LBL_OAT_BIAYA.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAT_BIAYA"));
			LBL_OAT_KARYAWAN.Text = conn.GetFieldValue("OAT_KARYAWAN");
			LBL_OAT_LAIN.Text = conn.GetFieldValue("OAT_LAIN");
			
			LBL_OAP_PRODUK.Text = conn.GetFieldValue("OAP_PRODUK");
		 
			try {CBL_OAP_PROSPEK.SelectedValue = conn.GetFieldValue("OAP_PROSPEK");}catch {}
			LBL_OAP_PELANGGAN.Text = conn.GetFieldValue("OAP_PELANGGAN");
			try {CBL_OAP_PERSAINGAN.SelectedValue = conn.GetFieldValue("OAP_PERSAINGAN");}catch {}
			LBL_OAP_PESAING.Text= conn.GetFieldValue("OAP_PESAING");
			LBL_OAP_LOKASIPESAING.Text = conn.GetFieldValue("OAP_LOKASIPESAING");
			try {CBL_OAP_HARGA.SelectedValue = conn.GetFieldValue("OAP_HARGA");}catch {}
			try {CBL_OAP_DISTRIBUSI.SelectedValue = conn.GetFieldValue("OAP_DISTRIBUSI");}catch {}
			try {CBL_OAP_PENJUALAN.SelectedValue = conn.GetFieldValue("OAP_PENJUALAN");}catch {}
			LBL_OAP_PENJUALANLAIN.Text = conn.GetFieldValue("OAP_PENJUALAN");
			try {CBL_OAP_PROMOSI.SelectedValue = conn.GetFieldValue("OAP_PROMOSI");}catch {}
			LBL_OAP_REALISASIKUAN.Text = conn.GetFieldValue("OAP_JUALKUANTUM");
			LBL_OAP_REALISASINILAI.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAP_JUALNILAI"));
			LBL_OAP_TARGETKUAN.Text = conn.GetFieldValue("OAP_TARGETKUANTUM");
			LBL_OAP_TARGETNILAI.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAP_TARGETNILAI"));
			LBL_OAP_LAIN.Text = conn.GetFieldValue("OAP_LAIN");
			LBL_OAP_DISTRIBUSILAIN.Text = conn.GetFieldValue("OAP_DISTRIBUSILAIN");
			LBL_OAP_PENJUALANLAIN.Text = conn.GetFieldValue("OAP_PENJUALANLAIN");
			LBL_OAP_PROMOSILAIN.Text = conn.GetFieldValue("OAP_PROMOSILAIN");
						
			LBL_OAK_POSISI.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAK_POSISI"));
			LBL_OAK_KAS.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAK_KAS"));
			LBL_OAK_HTGDAGANG.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAK_HTGDAGANG"));
			LBL_OAK_PIUTANG.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAK_PIUTANG"));
			LBL_OAK_HTGBANK.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAK_HTGBANK"));
			LBL_OAK_PERSEDIAAN.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAK_PERSEDIAAN"));
			LBL_OAK_MODAL.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAK_MODAL"));
			LBL_OAK_AKTIVATTP.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAK_AKTIVATTP"));
			LBL_OAK_BIAYAPROYEK.Text = conn.GetFieldValue("OAK_BIAYAPROYEK");
			try {CBL_OLL_JUMLAH.SelectedValue = conn.GetFieldValue("OLL_JUMLAH");}catch {}
			LBL_OLL_JUMLAHLAIN.Text = conn.GetFieldValue("OLL_JUMLAHLAIN");
			try {CBL_OLL_KEADAAN.SelectedValue = conn.GetFieldValue("OLL_KEADAAN");}catch {}
			try {CBL_OLL_DAMPAK.SelectedValue = conn.GetFieldValue("OLL_DAMPAK");}catch {}
			LBL_KETERANGAN.Text = conn.GetFieldValue("KETERANGAN");
			LBL_TINDAKLANJUT.Text = conn.GetFieldValue("TINDAKLANJUT");
			
			
			LBL_ATASAN.Text = conn.GetFieldValue("ATASAN");
			LBL_PEMBUAT.Text = conn.GetFieldValue("PEMBUAT");

			conn.QueryString=("SELECT VISITDAY = DATENAME(DAY, VISITDATE)+' '+ " +
					"DATENAME(MONTH, VISITDATE) +' '+ DATENAME(YEAR, VISITDATE)" +
				",ENTRYDAY = DATENAME(DAY, ENTRYDATE)+' '+ " +
					"DATENAME(MONTH, ENTRYDATE) +' '+ DATENAME(YEAR, ENTRYDATE)" +
				",TARGET = DATENAME(DAY, TARGETSELESAI)+' '+ " +
					"DATENAME(MONTH, TARGETSELESAI) +' '+ DATENAME(YEAR, TARGETSELESAI)" +
				"FROM LKKN WHERE AP_REGNO ='" + regno + "'");
			conn.ExecuteQuery();
			LBL_VISITDATE.Text = conn.GetFieldValue("VISITDAY");
			LBL_ENTRYDATE.Text = conn.GetFieldValue("ENTRYDAY");
			LBL_TARGETSELESAI.Text = conn.GetFieldValue("TARGET");
		}
		
	}
}
