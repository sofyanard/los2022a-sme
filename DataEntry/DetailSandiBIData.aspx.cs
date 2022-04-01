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

namespace SME.CreditOperations.Booking
{
	/// <summary>
	/// Summary description for DetailSandiBIData.
	/// </summary>
	public partial class DetailSandiBIData : System.Web.UI.Page
	{
	
		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");

		
		/////////////////////////////////////////////////////////////////////
		/// new views uses in this module:
		/// VW_CREOPR_BOOKING_SANDIBI_JENISGUNA_ALL
		/// VW_CREOPR_BOOKING_SANDIBI_JENISKREDIT_ALL
		/// VW_CREOPR_BOOKING_SANDIBI_ORIENTASIGUNA_ALL
		/// VW_CREOPR_BOOKING_SANDIBI_SIFATKREDIT_ALL
		/// VW_CREOPR_BOOKING_SANDIBI_LOKASIPROYEK_ALL
		/// VW_CREOPR_BOOKING_SANDIBI_FASILITASDANA_ALL
		/// 
		

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_PRODUCTID.Text = Request.QueryString["productid"];
				LBL_TC.Text = Request.QueryString["tc"];
				LBL_PROD_SEQ.Text = Request.QueryString["PROD_SEQ"];
				
				initDropDowns();

				ViewData();
			}
			SecureData();
			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
		}

		private void initDropDowns() 
		{
			string de = Request.QueryString["de"];

			//RFJenisPenggunaan
			if (de != "1") conn.QueryString = "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_JENISGUNA_ALL";
			else conn.QueryString = "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_JENISGUNA";
			conn.ExecuteQuery();
			DDL_JenisPenggunaan.Items.Clear();
			DDL_JenisPenggunaan.Items.Add(new ListItem("- SELECT -", ""));
			for (int i=0; i<conn.GetRowCount(); i++)
				DDL_JenisPenggunaan.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			//RFJenisKredit   
			if (de != "1") conn.QueryString = "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_JENISKREDIT_ALL";
			else conn.QueryString = "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_JENISKREDIT ";
			conn.ExecuteQuery();
			DDL_JenisKredit.Items.Clear();
			DDL_JenisKredit.Items.Add(new ListItem("- SELECT -", ""));
			for (int i=0; i<conn.GetRowCount(); i++)
				DDL_JenisKredit.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			//RFSektorEkonomi   
			/***
			conn.QueryString = "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_SEKTOREKONOMI ";
			conn.ExecuteQuery();
			DDL_SektorEkonomi.Items.Clear();
			DDL_SektorEkonomi.Items.Add(new ListItem("- SELECT -", ""));
			for (int i=0; i<conn.GetRowCount(); i++)
				DDL_SektorEkonomi.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
			***/

			//RFOrientasiPenggunaan   
			if (de != "1") conn.QueryString = "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_ORIENTASIGUNA_ALL";
			else conn.QueryString = "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_ORIENTASIGUNA ";
			conn.ExecuteQuery();
			DDL_OrientasiPenggunaan.Items.Clear();
			DDL_OrientasiPenggunaan.Items.Add(new ListItem("- SELECT -", ""));
			for (int i=0; i<conn.GetRowCount(); i++)
				DDL_OrientasiPenggunaan.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			//RFSifatKredit   
			if (de != "1") conn.QueryString = "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_SIFATKREDIT_ALL";
			else conn.QueryString = "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_SIFATKREDIT";
			conn.ExecuteQuery();
			DDL_SifatKredit.Items.Clear();
			DDL_SifatKredit.Items.Add(new ListItem("- SELECT -", ""));
			for (int i=0; i<conn.GetRowCount(); i++)
				DDL_SifatKredit.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			//RFLokasiProyek   
			if (de != "1") conn.QueryString = "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_LOKASIPROYEK_ALL";
			else conn.QueryString = "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_LOKASIPROYEK ";
			conn.ExecuteQuery();
			DDL_LokasiProyek.Items.Clear();
			DDL_LokasiProyek.Items.Add(new ListItem("- SELECT -", ""));
			for (int i=0; i<conn.GetRowCount(); i++)
				DDL_LokasiProyek.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			//RFFasilitasPenyediaanDana 
			if (de != "1") conn.QueryString = "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_FASILITASDANA_ALL";
			else conn.QueryString = "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_FASILITASDANA ";
			conn.ExecuteQuery();
			DDL_FasilitasDana.Items.Clear();
			DDL_FasilitasDana.Items.Add(new ListItem("- SELECT -", ""));
			for (int i=0; i<conn.GetRowCount(); i++)
				DDL_FasilitasDana.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));


			//RFBMSEKTOREKONOMI (SEKTOR EKONOMI BM)
			if (de != "1") GlobalTools.fillRefList(DDL_SektorEkonomi, "select BM_CODE, BM_DESC from RFBMSEKTOREKONOMI", true, conn);
			else GlobalTools.fillRefList(DDL_SektorEkonomi, "select BM_CODE, BM_DESC from RFBMSEKTOREKONOMI where ACTIVE = '1'", true, conn);

//			//RFBMSUBSEKTOREKONOMI (SUB SEKTOR EKONOMI BM)
//			GlobalTools.fillRefList(DDL_SUBSEKTORBM, "select BMSUB_CODE, BMSUB_DESC from RFBMSUBSEKTOREKONOMI where ACTIVE = '1'", true, conn);
//
//			//RFBMSUBSUBSEKTOREKONOMI (SUB-SUB SEKTOR EKONOMI BM)
//			GlobalTools.fillRefList(DDL_SUBSUBSEKTORBM, "select BMSUBSUB_CODE, BMSUBSUB_DESC from RFBMSUBSUBSEKTOREKONOMI where ACTIVE = '1'", true, conn);
//
//			//RFBICODE (SEKTOR EKONOMI BI)
//			GlobalTools.fillRefList(DDL_SEKTOREKONOMIBI, "select BI_SEQ, BI_DESC from RFBICODE where ACTIVE = '1' and BG_GROUP = '3'", true, conn);
		}

		private void SecureData() 
		{
			// Jika yang memanggil bukan dalam scope DataEntry, maka disable semua control input
			// Flag :
			//		Nama  = de
			//		Value ==  1 --> Parent DataEntry
			//			  !=  1 --> Parent non-DataEntry
			string de = Request.QueryString["de"];
			if (de != "1") 
			{
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for (int i = 0; i < coll[3].Controls.Count; i++) 
				{
					if (coll[3].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[3].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[3].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[3].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[3].Controls[i] is Button)
					{
						Button btn = (Button) coll[3].Controls[i];
						btn.Visible = false;
					}
				}
			}
		}

		private void ViewData()
		{

			string de = Request.QueryString["de"];

			conn.QueryString = "select * from VW_SEARCHSEKTOREKONOMI "+
				"where AP_REGNO = '"+ LBL_REGNO.Text.Trim() +"' AND PRODUCTID = '" + 
				LBL_PRODUCTID.Text.Trim() + "' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();

			/////////////////////////////////////////////////
			/// JENIS PENGGUNAAN
			/// 
			try
			{
				DDL_JenisPenggunaan.SelectedValue = conn.GetFieldValue("BI_JENISPENGGUNAAN");
			}
			catch { Response.Write("Jenis Penggunaan "+conn.GetFieldValue("BI_JENISPENGGUNAAN")); }

			/////////////////////////////////////////////////
			/// JENIS KREDIT
			/// 
			try
			{
				DDL_JenisKredit.SelectedValue = conn.GetFieldValue("BI_JENISKREDIT");
			}
			catch { Response.Write("Jenis Kredit "+conn.GetFieldValue("BI_JENISKREDIT")); }

			///////////////////////////////////////////////////////
			/// ORIENTASI PENGGUNAAN
			/// 
			try
			{
				DDL_OrientasiPenggunaan.SelectedValue = conn.GetFieldValue("BI_ORIENTASI");
			}
			catch { Response.Write("Orientasi Penggunaan "+conn.GetFieldValue("BI_ORIENTASI")); }


			////////////////////////////////////////////////////////
			/// SIFAT KREDIT
			/// 
			try
			{
				DDL_SifatKredit.SelectedValue = conn.GetFieldValue("BI_SIFATKREDIT");
			}
			catch { Response.Write("Sifat Kredit "+conn.GetFieldValue("BI_SIFATKREDIT")); }


			////////////////////////////////////////////////////////
			///	LOKASI
			try
			{
				DDL_LokasiProyek.SelectedValue = conn.GetFieldValue("BI_LOKASI");
			}
			catch { Response.Write("Lokasi Proyek "+conn.GetFieldValue("BI_LOKASI")); }


			/////////////////////////////////////////////////////////
			/// FASILITAS
			/// 
			try
			{
				DDL_FasilitasDana.SelectedValue = conn.GetFieldValue("BI_FASILITAS");
			}
			catch { Response.Write("Fasilitas Dana "+conn.GetFieldValue("BI_FASILITAS")); }

			//pipeline
			


			//try { DDL_SUBSUBSEKTORBM.SelectedValue = conn.GetFieldValue("BM_SUBSUBSEKTOREKON"); }
			//catch {}

			

			string BM_SEKTOREKONOMI = conn.GetFieldValue("BM_SEKTOREKONOMI");
			string BM_SUBSEKTOREKONOMI = conn.GetFieldValue("BM_SUBSEKTOREKON");
			string BM_SUBSUBSEKTOREKONOMI = conn.GetFieldValue("BM_SUBSUBSEKTOREKON");
			string BI_SEKTOREKONOMI = conn.GetFieldValue("BI_SEKTOREKONOMI");
			if (BI_SEKTOREKONOMI == "")
			{
				//conn.QueryString = "select Bi_seq, BMSUBSUB_DESC from RFBMSUBSUBSEKTOREKONOMI where BMSUB_CODE = '" + BM_SUBSEKTOREKONOMI + "'";
				conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + BM_SUBSUBSEKTOREKONOMI + "'";
				conn.ExecuteQuery();
				BI_SEKTOREKONOMI = conn.GetFieldValue("BI_SEQ");
			}
			//string BI_SEKTOREKONOMI = "";

			///////////////////////////////////////////////////////
			///	SEKTOR EKONOMI BM
			///	
			try {DDL_SektorEkonomi.SelectedValue = BM_SEKTOREKONOMI;}
			catch {DDL_SektorEkonomi.SelectedValue="";}


			///////////////////////////////////////////////////////
			/// SUB SEKTOR EKONOMI BM
			/// 
			if (de != "1")  GlobalTools.fillRefList(DDL_SUBSEKTORBM, "select BMSUB_CODE, BMSUB_DESC from RFBMSUBSEKTOREKONOMI where BM_CODE = '" + DDL_SektorEkonomi.SelectedValue + "'", true, conn);				
			else GlobalTools.fillRefList(DDL_SUBSEKTORBM, "select BMSUB_CODE, BMSUB_DESC from RFBMSUBSEKTOREKONOMI where ACTIVE = '1' and BM_CODE = '" + DDL_SektorEkonomi.SelectedValue + "'", true, conn);				
			try{DDL_SUBSEKTORBM.SelectedValue = BM_SUBSEKTOREKONOMI;}
			catch{DDL_SUBSEKTORBM.SelectedValue="";}


			//////////////////////////////////////////////////////
			/// SUB-SUB SEKTOR EKONOMI BM
			/// 
			if (de != "1") GlobalTools.fillRefList(DDL_SUBSUBSEKTORBM, "select BMSUBSUB_CODE, BMSUBSUB_DESC from RFBMSUBSUBSEKTOREKONOMI where BMSUB_CODE = '" + DDL_SUBSEKTORBM.SelectedValue + "'", true, conn);
			else GlobalTools.fillRefList(DDL_SUBSUBSEKTORBM, "select BMSUBSUB_CODE, BMSUBSUB_DESC from RFBMSUBSUBSEKTOREKONOMI where ACTIVE = '1' and BMSUB_CODE = '" + DDL_SUBSEKTORBM.SelectedValue + "'", true, conn);
			try{DDL_SUBSUBSEKTORBM.SelectedValue = BM_SUBSUBSEKTOREKONOMI;}
			catch{DDL_SUBSUBSEKTORBM.SelectedValue="";}


			//////////////////////////////////////////////////////
			///	SEKTOR EKONOMI BI
			///	
			if (de != "1") GlobalTools.fillRefList(DDL_SEKTOREKONOMIBI, "select BI_SEQ, BI_DESC from RFBICODE where BG_GROUP = '3' and BI_SEQ = '" + BI_SEKTOREKONOMI + "'", true, conn);
			else GlobalTools.fillRefList(DDL_SEKTOREKONOMIBI, "select BI_SEQ, BI_DESC from RFBICODE where ACTIVE = '1' and BG_GROUP = '3' and BI_SEQ = '" + BI_SEKTOREKONOMI + "'", true, conn);
			try{DDL_SEKTOREKONOMIBI.SelectedValue = BI_SEKTOREKONOMI;}
			catch{DDL_SEKTOREKONOMIBI.SelectedValue="";}
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

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
//			string jg = DDL_JenisPenggunaan.SelectedValue.Trim(),
//				jk = DDL_JenisKredit.SelectedValue.Trim(),
//				se = DDL_SektorEkonomi.SelectedValue.Trim(),
//				og = DDL_OrientasiPenggunaan.SelectedValue.Trim(),
//				sk = DDL_SifatKredit.SelectedValue.Trim(),
//				lp = DDL_LokasiProyek.SelectedValue.Trim(),
//				fd = DDL_FasilitasDana.SelectedValue.Trim();
				
			/*Response.Write (jg+"<br>");
			Response.Write (sk+"<br>");
			Response.Write (se+"<br>");
			Response.Write (og+"<br>");
			Response.Write (lp+"<br>");
			Response.Write (fd+"<br>");*/

			conn.QueryString = "exec BOOKING_SANDIBI_SAVE '" + LBL_REGNO.Text + "', '" +
				LBL_PRODUCTID.Text + "', '" + 
				DDL_JenisPenggunaan.SelectedValue.Trim() + "', '" + 
				DDL_JenisKredit.SelectedValue.Trim() + "', '" + 
				DDL_SEKTOREKONOMIBI.SelectedValue.Trim() + "', '" + 
				DDL_OrientasiPenggunaan.SelectedValue.Trim() + "', '" + 
				DDL_SifatKredit.SelectedValue.Trim() + "', '" + 
				DDL_LokasiProyek.SelectedValue.Trim() + "', '" + 
				DDL_FasilitasDana.SelectedValue.Trim() + "' , '" + 
				LBL_PROD_SEQ.Text + "', '" + 
				DDL_SektorEkonomi.SelectedValue + "', '" + 
				DDL_SUBSEKTORBM.SelectedValue + "', '" + 
				DDL_SUBSUBSEKTORBM.SelectedValue + "'";
			conn.ExecuteNonQuery();			
		}

		protected void DDL_SEKTOREKONOMIBI_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//GlobalTools.fillRefList(DDL_SektorEkonomi, "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_SEKTOREKONOMI where BI_CODE = '" + DDL_SEKTOREKONOMIBI.SelectedValue + "'", true, conn);
		}

		protected void DDL_BUSSTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
		}

		protected void DDL_SektorEkonomi_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string de = Request.QueryString["de"];

//			string query = "select BMSUB_CODE, BMSUB_DESC from RFBMSUBSEKTOREKONOMI where ACTIVE = '1' and BM_CODE = '" + DDL_SektorEkonomi.SelectedValue + "'";
//			GlobalTools.fillRefList(DDL_SUBSEKTORBM, query, true, conn);

			if (de != "1")  GlobalTools.fillRefList(DDL_SUBSEKTORBM, "select BMSUB_CODE, BMSUB_DESC from RFBMSUBSEKTOREKONOMI where BM_CODE = '" + DDL_SektorEkonomi.SelectedValue + "'", true, conn);				
			else GlobalTools.fillRefList(DDL_SUBSEKTORBM, "select BMSUB_CODE, BMSUB_DESC from RFBMSUBSEKTOREKONOMI where ACTIVE = '1' and BM_CODE = '" + DDL_SektorEkonomi.SelectedValue + "'", true, conn);				
			
		}

		protected void DDL_SUBSEKTORBM_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string de = Request.QueryString["de"];

//			string query = "select BMSUBSUB_CODE, BMSUBSUB_DESC from RFBMSUBSUBSEKTOREKONOMI where ACTIVE = '1' and BMSUB_CODE = '" + DDL_SUBSEKTORBM.SelectedValue + "'";
//			GlobalTools.fillRefList(DDL_SUBSUBSEKTORBM, query, true, conn);	
			
			if (de != "1") GlobalTools.fillRefList(DDL_SUBSUBSEKTORBM, "select BMSUBSUB_CODE, BMSUBSUB_DESC from RFBMSUBSUBSEKTOREKONOMI where BMSUB_CODE = '" + DDL_SUBSEKTORBM.SelectedValue + "'", true, conn);
			else GlobalTools.fillRefList(DDL_SUBSUBSEKTORBM, "select BMSUBSUB_CODE, BMSUBSUB_DESC from RFBMSUBSUBSEKTOREKONOMI where ACTIVE = '1' and BMSUB_CODE = '" + DDL_SUBSEKTORBM.SelectedValue + "'", true, conn);
			
		}

		protected void DDL_SUBSUBSEKTORBM_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string de = Request.QueryString["de"];

			if (de != "1")
			{

				//conn.QueryString = "select Bi_seq, BMSUBSUB_DESC from RFBMSUBSUBSEKTOREKONOMI where BMSUB_CODE = '" + DDL_SUBSEKTORBM.SelectedValue + "'";
				conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + DDL_SUBSUBSEKTORBM.SelectedValue + "'";
				conn.ExecuteQuery();
				GlobalTools.fillRefList(DDL_SEKTOREKONOMIBI, "SELECT BI_SEQ, BI_DESC FROM RFBICODE WHERE BG_GROUP = '3' AND BI_SEQ = '" + conn.GetFieldValue("BI_SEQ") + "'", true, conn);
				try{DDL_SEKTOREKONOMIBI.SelectedValue = conn.GetFieldValue("BI_SEQ");}
				catch{DDL_SEKTOREKONOMIBI.SelectedValue="";}


				//GlobalTools.fillRefList(DDL_SEKTOREKONOMIBI,"SELECT ss.BI_SEQ, b.BI_DESC FROM RFBMSUBSUBSEKTOREKONOMI ss left join RFBICODE b on SS.BI_SEQ = B.BI_SEQ " + 
					//"and BMSUBSUB_CODE = '" + DDL_SUBSUBSEKTORBM.SelectedValue + "' " + 
					//"and BMSUB_CODE = '" + DDL_SUBSEKTORBM.SelectedValue + "'",true, conn);
			}
			else
			{
				/*
				GlobalTools.fillRefList(DDL_SEKTOREKONOMIBI,"SELECT ss.BI_SEQ, b.BI_DESC FROM RFBMSUBSUBSEKTOREKONOMI ss left join RFBICODE b on SS.BI_SEQ = B.BI_SEQ " + 
					"where ss.active = '1' " + 
					"and BMSUBSUB_CODE = '" + DDL_SUBSUBSEKTORBM.SelectedValue + "' " + 
					"and BMSUB_CODE = '" + DDL_SUBSEKTORBM.SelectedValue + "'",true, conn);
				*/
				conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + DDL_SUBSUBSEKTORBM.SelectedValue + "' AND ACTIVE = '1'";
				conn.ExecuteQuery();
				GlobalTools.fillRefList(DDL_SEKTOREKONOMIBI, "SELECT BI_SEQ, BI_DESC FROM RFBICODE WHERE BG_GROUP = '3' AND BI_SEQ = '" + conn.GetFieldValue("BI_SEQ") + "'", true, conn);
				try{DDL_SEKTOREKONOMIBI.SelectedValue = conn.GetFieldValue("BI_SEQ");}
				catch{DDL_SEKTOREKONOMIBI.SelectedValue="";}
			}
            
//			string query = "SELECT ss.BI_SEQ, b.BI_DESC FROM RFBMSUBSUBSEKTOREKONOMI ss left join RFBICODE b on SS.BI_SEQ = B.BI_SEQ " + 
//				"where ss.active = '1' " + 
//				"and BMSUBSUB_CODE = '" + DDL_SUBSUBSEKTORBM.SelectedValue + "' " + 
//				"and BMSUB_CODE = '" + DDL_SUBSEKTORBM.SelectedValue + "'";
//			GlobalTools.fillRefList(DDL_SEKTOREKONOMIBI, query, true, conn);
		}
	}
}
