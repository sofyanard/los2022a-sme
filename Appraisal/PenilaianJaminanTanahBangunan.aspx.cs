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
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.Appraisal
{
	/// <summary>
	/// Summary description for PenilaianJaminanTanahBangunan.
	/// </summary>
	public partial class PenilaianJaminanTanahBangunan : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btn_Calc;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist2;

		//protected Tools tool = new Tools();
		protected Connection conn;
		string JenisForm;
		
		double Score;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			
			if (!IsPostBack)
			{
				lbl_CU_REF.Text = Request.QueryString["curef"];
				lbl_AP_REGNO.Text = Request.QueryString["regno"];
				lbl_CL_SEQ.Text = Request.QueryString["cl_seq"];
				lbl_TC.Text = Request.QueryString["tc"];
				lbl_MC.Text = Request.QueryString["mc"];

				//###################################################################
				conn.QueryString = "select GRP_CO, GRP_COOFF from APP_PARAMETER";
				conn.ExecuteQuery();
				lbl_GRP_CO.Text		= conn.GetFieldValue("GRP_CO").ToString();
				lbl_GRP_COOFF.Text	= conn.GetFieldValue("GRP_COOFF").ToString();
				//###################################################################

				//======================================================================================= tanah
				GlobalTools.initDateForm(txt_AT_ABDATE_dd,ddl_AT_ABDATE_mm,txt_AT_ABDATE_yy);
				GlobalTools.initDateForm(txt_AT_APPRDATE_dd,ddl_AT_APPRDATE_mm,txt_AT_APPRDATE_yy);
				GlobalTools.initDateForm(txt_AT_BKDATE_dd,ddl_AT_BKDATE_mm,txt_AT_BKDATE_yy);

				GlobalTools.fillRefList(ddl_AT_KUBURAN,"select * from RF_APPR_JARAK where active = '1' ",false,conn);
				GlobalTools.fillRefList(ddl_AT_TWILUTK,"select * from RFLINGKUNGAN where active = '1' ",false,conn);
				GlobalTools.fillRefList(ddl_AT_KONTURTNH,"select * from RF_APPR_CONTOUR where active = '1' ",false,conn);

				GlobalTools.fillRefList(ddl_AT_BKTYPE,"select * from RF_APPR_BUKTIKEPEMILIKAN where TIPE = '1' and active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AT_TUJUAN,"select * from RF_APPR_TUJUAN where active = '1'",false,conn);

				GlobalTools.fillRefList(ddl_AT_MARKET,"select * from RF_APPR_MARKETABILITY where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AT_IKAT,"select * from RF_APPR_IKATSEMPURNA where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AT_MASALAH,"select * from RF_APPR_MASALAH where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AT_KUASA,"select * from RFPENGUASAAN where active = '1'",false,conn);

				//======================================================================================= bangunan
				GlobalTools.initDateForm(txt_AB_IJINDATE_DD,ddl_AB_IJINDATE_MM,txt_AB_IJINDATE_YY);
				GlobalTools.initDateForm(txt_AB_INSREXPDATE_DD,ddl_AB_INSREXPDATE_MM,txt_AB_INSREXPDATE_YY);

				GlobalTools.fillRefList(ddl_AB_KETAIR,"select * from RF_APPR_AIR where active = '1'",false,conn);

				GlobalTools.fillRefList(ddl_AB_GUNA,"select * from RF_APPR_PENGGUNAANBANGUNAN where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AB_JENISBANGUNAN,"select * from RF_APPR_JENISBANGUNAN where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AB_KONTRUKSI,"select * from RFKONTRUKSI where active = '1' ",false,conn);
				
				GlobalTools.fillRefList(ddl_AB_DINDING,"select * from RF_APPR_DINDING where active = '1' ",false,conn);
				GlobalTools.fillRefList(ddl_AB_ATAP,"select * from RF_APPR_ATAP where active = '1' ",false,conn);
				GlobalTools.fillRefList(ddl_AB_LANTAI,"select * from RFLANTAI where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AB_PINTU,"select * from RF_APPR_PINTU where active = '1'",false,conn);

				GlobalTools.fillRefList(ddl_AB_KONDISI,"select * from RFKONDISI where active = '1' ",false,conn);
				GlobalTools.fillRefList(ddl_AB_PEMELIHARAANBGN,"select * from RFKONDISI where active = '1'",false,conn);

				GlobalTools.fillRefList(ddl_AB_LOKASI,"select * from RF_APPR_LOKASIBANGUNAN where active = '1' ",false,conn);
				GlobalTools.fillRefList(ddl_AB_TUJUAN,"select * from RF_APPR_TUJUAN where active = '1'",false,conn);

				
				ViewData();
				txt_Score.Text = Convert.ToString(HitungScore());
				txt_ScoreTanah.Text = txt_Score.Text;
				try {KalkulasiTanah();} 
				catch {}

				KalkulasiBangunan();

				try {txt_TotHargaBank.Text = GlobalTools.MoneyFormat(Convert.ToString(Double.Parse(txt_AT_HRGWAJAR.Text) + Double.Parse(txt_AB_HRGBANK.Text)));} 
				catch {}
				EnableUpdate();
			}

			ViewLink();

			//###################################################################
			btn_UpdateStatus.Attributes.Add("onclick","if(!update()){return false;};");
			btn_Reentry.Attributes.Add("onclick","if(!update()){return false;};");
			//###################################################################
		}


		private bool isPetugas(string groupid)
		{
			bool petugas = false;

			conn.QueryString = "select groupid from scgroup where sg_grpupliner = '" + groupid + "'";
			conn.ExecuteQuery();
			
			if (conn.GetRowCount() == 0) petugas = true;

			return petugas;
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


		private void ViewLink()
		{
			hpl_Tanah.NavigateUrl ="PenilaianJaminanTanahBangunan.aspx?form=tanah&regno=" + lbl_AP_REGNO.Text + "&curef=" + lbl_CU_REF.Text + "&cl_seq=" + lbl_CL_SEQ.Text + "&tc=" + lbl_TC.Text + "&mc=" + lbl_MC.Text;
			hpl_Bangunan.NavigateUrl="PenilaianJaminanTanahBangunan.aspx?form=bangunan&regno=" + lbl_AP_REGNO.Text + "&curef=" + lbl_CU_REF.Text + "&cl_seq=" + lbl_CL_SEQ.Text + "&tc=" + lbl_TC.Text + "&mc=" + lbl_MC.Text;

			JenisForm = Request.QueryString["form"];
			if (JenisForm == "tanah")
			{
				tbl_Tanah.Visible = true;
				tbl_Bangunan.Visible = false;
			}
			else if (JenisForm == "bangunan")
			{
				tbl_Tanah.Visible = false;
				tbl_Bangunan.Visible = true;
			}
			else
			{
				tbl_Tanah.Visible = true;
				tbl_Bangunan.Visible = false;
			}

		}

		protected void ddl_AT_SWILAYAH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txt_Score.Text = Convert.ToString(HitungScore());
			txt_ScoreTanah.Text = txt_Score.Text;
		}

		protected void ddl_AT_SLOKASI_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txt_Score.Text = Convert.ToString(HitungScore());
			txt_ScoreTanah.Text = txt_Score.Text;
		}

		protected void ddl_AT_SKUALITAS_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txt_Score.Text = Convert.ToString(HitungScore());
			txt_ScoreTanah.Text = txt_Score.Text;
		}

		protected void ddl_AT_SLINGKUNGAN_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txt_Score.Text = Convert.ToString(HitungScore());
			txt_ScoreTanah.Text = txt_Score.Text;
		}

		private int HitungScore()
		{
			int nWilayah, nLokasi, nKualitas, nLingkungan, nHasil;

			txt_AT_WILAYAH.Text = ddl_AT_SWILAYAH.SelectedValue.ToString();
			txt_AT_JALAN.Text = ddl_AT_SLOKASI.SelectedValue.ToString();
			txt_AT_KUALITAS.Text = ddl_AT_SKUALITAS.SelectedValue.ToString();
			
			//hitung: score		
			try {nWilayah = Convert.ToByte(ddl_AT_SWILAYAH.SelectedItem.Text);}
			catch {nWilayah = 0;}
			
			try {nLokasi = Convert.ToByte(ddl_AT_SLOKASI.SelectedItem.Text);}
			catch {nLokasi = 0;}

			try {nKualitas = Convert.ToByte(ddl_AT_SKUALITAS.SelectedItem.Text);}
			catch {nKualitas = 0;}

			try {nLingkungan = Convert.ToByte(ddl_AT_SLINGKUNGAN.SelectedItem.Text);}
			catch {nLingkungan = 0;}

			nHasil = nWilayah + nLokasi + nKualitas + nLingkungan;
			Score = nHasil;

			return nHasil;
		}


		private void ViewData()
		{
			//###################################################################################
			conn.QueryString = " select * from VW_APPRAISAL_RESULT where AP_REGNO = '" +lbl_AP_REGNO.Text+
				"' and CU_REF = '" + lbl_CU_REF.Text+ "' and CL_SEQ = "+ lbl_CL_SEQ.Text;
			conn.ExecuteQuery();
			string LA_APPRSTATUS = conn.GetFieldValue("LA_APPRSTATUS");
			string OFFICERSEQ	 = conn.GetFieldValue("OFFICERSEQ");

			string mGROUP = Session["GroupID"].ToString();
			string USERID = Session["UserID"].ToString();

			string STSTOMBOL = "0";
			if (LA_APPRSTATUS == "3")
				STSTOMBOL = "1";
			//else if (mGROUP == lbl_GRP_COOFF.Text.Trim() && LA_APPRSTATUS != "2")
			else if (isPetugas(mGROUP) && LA_APPRSTATUS != "2")
				STSTOMBOL = "1";
			//else if (mGROUP == lbl_GRP_CO.Text.Trim() && LA_APPRSTATUS != "5")
			else if (!isPetugas(mGROUP) && (LA_APPRSTATUS != "5" || LA_APPRSTATUS != "6"))
				STSTOMBOL = "1";
			else // if (mGROUP != lbl_GRP_CO.Text.Trim() && mGROUP != lbl_GRP_COOFF.Text.Trim())
				STSTOMBOL = "1";

			if (LA_APPRSTATUS == "2" && USERID == OFFICERSEQ)
				STSTOMBOL = "0";

			//if (LA_APPRSTATUS == "5" && mGROUP == lbl_GRP_CO.Text.Trim())
			if ((LA_APPRSTATUS == "5" || LA_APPRSTATUS == "6") && !isPetugas(mGROUP))
				STSTOMBOL = "2";

			if (STSTOMBOL == "1")
			{
				btn_Save.Visible = false;
				btn_UpdateStatus.Visible = false;
				btn_Reentry.Visible = false;
				DisabledEntry();
			}
			else if (STSTOMBOL == "2")
			{
				btn_Save.Visible = false;
				btn_UpdateStatus.Visible = true;
				btn_Reentry.Visible = true;
				DisabledEntry();
			}
			//###################################################################################

			conn.QueryString = "select * from VW_INFOUMUM_APPRAISAL "+
				"where AP_REGNO = '"+ lbl_AP_REGNO.Text + "';";
			conn.ExecuteQuery();
			txt_AT_NMDEBITUR.Text = conn.GetFieldValue("CU_NAME");


			//======================================================================================= tanah
			conn.QueryString = "select * from VW_APPR_TANAH "+
				"where AP_REGNO = '"+ lbl_AP_REGNO.Text +"' and CU_REF  = '"+ lbl_CU_REF.Text +"' "+
				"and CL_SEQ  = "+ lbl_CL_SEQ.Text ;
			conn.ExecuteQuery();
			
			try
			{
				txt_AT_LOKJLN.Text = conn.GetFieldValue("AT_LOKJLN");
				txt_AT_LOKDESA.Text = conn.GetFieldValue("AT_LOKDESA");
				txt_AT_LOKKEC.Text = conn.GetFieldValue("AT_LOKKEC");
				txt_AT_LOKKAB.Text = conn.GetFieldValue("AT_LOKKAB");
				try {GlobalTools.fillDateForm(txt_AT_APPRDATE_dd,ddl_AT_APPRDATE_mm,txt_AT_APPRDATE_yy,Convert.ToDateTime(conn.GetFieldValue("AT_APPRDATE")));} 
				catch {}
				txt_AT_APPRBY1.Text = conn.GetFieldValue("AT_APPRBY1");
				txt_AT_APPRBY2.Text = conn.GetFieldValue("AT_APPRBY2");

				//----------------------------------------------------------------------------------------------
				txt_AT_KEADAANFSK.Text = conn.GetFieldValue("AT_KEADAANFSK");
				txt_AT_LUASTNH.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AT_LUASTNH"));
				txt_AT_JALAN.Text = conn.GetFieldValue("AT_JALAN");
				txt_AT_KETJALAN.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AT_KETJALAN"));
				try{ ddl_AT_LISTRIK.SelectedValue = conn.GetFieldValue("AT_LISTRIK");}
				catch{}
				try{ddl_AT_TELP.SelectedValue = conn.GetFieldValue("AT_TELP");}
				catch{}
				try{ddl_AT_TAIR.SelectedValue = conn.GetFieldValue("AT_TAIR");}
				catch{}
				try{ddl_AT_TSEKOLAH.SelectedValue = conn.GetFieldValue("AT_TSEKOLAH");}
				catch{}
				try{ddl_AT_TPASAR.SelectedValue = conn.GetFieldValue("AT_TPASAR");}
				catch{}
				try{ddl_AT_TWILUTK.SelectedValue = conn.GetFieldValue("AT_TWILUTK");}
				catch{}
				try{ddl_AT_SPBU.SelectedValue = conn.GetFieldValue("AT_SPBU");}
				catch{}
				try{ddl_AT_IBADAH.SelectedValue = conn.GetFieldValue("AT_IBADAH");}
				catch{}
				try{ddl_AT_HIBURAN.SelectedValue = conn.GetFieldValue("AT_HIBURAN");}
				catch{}
				try{ddl_AT_KUBURAN.SelectedValue = conn.GetFieldValue("AT_KUBURAN");}
				catch{}

				try{ddl_AT_ISNEW.SelectedValue = conn.GetFieldValue("AT_ISNEW");}
				catch{}
				txt_AT_THNBELI.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AT_THNBELI"));
				txt_AT_WILAYAH.Text = conn.GetFieldValue("AT_WILAYAH");
				try{ddl_AT_BANJIR.SelectedValue = conn.GetFieldValue("AT_BANJIR");}
				catch{}
				try{ddl_AT_TEGANGAN.SelectedValue = conn.GetFieldValue("AT_TEGANGAN");}
				catch{}
				try{ddl_AT_TNHLONGSOR.SelectedValue = conn.GetFieldValue("AT_TNHLONGSOR");}
				catch{}
				try{ddl_AT_PENCEMARAN.SelectedValue = conn.GetFieldValue("AT_PENCEMARAN");}
				catch{}
				txt_AT_KUALITAS.Text = conn.GetFieldValue("AT_KUALITAS");
				try{ddl_AT_KONTURTNH.SelectedValue = conn.GetFieldValue("AT_KONTURTNH");}
				catch{}
				try{ddl_AT_SWILAYAH.SelectedIndex = Convert.ToByte(conn.GetFieldValue("AT_SWILAYAH"));}
				catch{}
				try{ddl_AT_SLOKASI.SelectedIndex = Convert.ToByte(conn.GetFieldValue("AT_SLOKASI"));}
				catch{}
				try{ddl_AT_SKUALITAS.SelectedIndex = Convert.ToByte(conn.GetFieldValue("AT_SKUALITAS"));}
				catch{}
				try{ddl_AT_SLINGKUNGAN.SelectedIndex = Convert.ToByte(conn.GetFieldValue("AT_SLINGKUNGAN"));}
				catch{}

				//----------------------------------------------------------------------------------------------
				try{ddl_AT_BKTYPE.SelectedValue = conn.GetFieldValue("AT_BKTYPE");}
				catch{}
				txt_AT_BKNO.Text = conn.GetFieldValue("AT_BKNO");
				try {GlobalTools.fillDateForm(txt_AT_BKDATE_dd,ddl_AT_BKDATE_mm,txt_AT_BKDATE_yy,Convert.ToDateTime(conn.GetFieldValue("AT_BKDATE")));} 
				catch {}
				txt_AT_BKNAMA.Text = conn.GetFieldValue("AT_BKNAMA");
				txt_AT_BKAKTA.Text = conn.GetFieldValue("AT_BKAKTA");
				txt_AT_BKNOTARIS.Text = conn.GetFieldValue("AT_BKNOTARIS");

				//----------------------------------------------------------------------------------------------
				try{ddl_AT_IJTYPE.SelectedValue = conn.GetFieldValue("AT_IJTYPE");}
				catch{}
				txt_AT_IJNO.Text = conn.GetFieldValue("AT_IJNO");
				txt_AT_IJNOTARIS.Text = conn.GetFieldValue("AT_IJNOTARIS");
				txt_AT_IJSERTIFIKAT.Text = conn.GetFieldValue("AT_IJSERTIFIKAT");
				txt_AT_IJPADA.Text = conn.GetFieldValue("AT_IJPADA");
				txt_AT_IJNILAI.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AT_IJNILAI"));

				//----------------------------------------------------------------------------------------------
				txt_AT_ABHASIL.Text = conn.GetFieldValue("AT_ABHASIL");
				try {GlobalTools.fillDateForm(txt_AT_ABDATE_dd,ddl_AT_ABDATE_mm,txt_AT_ABDATE_yy,Convert.ToDateTime(conn.GetFieldValue("AT_ABDATE")));} 
				catch {}
				txt_AT_ABKANTOR.Text = conn.GetFieldValue("AT_ABKANTOR");
				txt_AT_ABPEJABAT.Text = conn.GetFieldValue("AT_ABPEJABAT");

				//----------------------------------------------------------------------------------------------
				txt_AT_DATA1.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AT_DATA1"));
				txt_AT_DATA2.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AT_DATA2"));
				txt_AT_DATA3.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AT_DATA3"));
				txt_AT_NAMA1.Text = conn.GetFieldValue("AT_NAMA1");
				txt_AT_NAMA2.Text = conn.GetFieldValue("AT_NAMA2");
				txt_AT_NAMA3.Text = conn.GetFieldValue("AT_NAMA3");
				txt_AT_ALAMAT1.Text = conn.GetFieldValue("AT_ALAMAT1");
				txt_AT_ALAMAT2.Text = conn.GetFieldValue("AT_ALAMAT2");
				txt_AT_ALAMAT3.Text = conn.GetFieldValue("AT_ALAMAT3");
				txt_AT_TGL1.Text = conn.GetFieldValue("AT_TGL1");
				txt_AT_TGL2.Text = conn.GetFieldValue("AT_TGL2");
				txt_AT_TGL3.Text = conn.GetFieldValue("AT_TGL3");
				try{ddl_AT_TUJUAN.SelectedValue = conn.GetFieldValue("AT_TUJUAN");}
				catch{}
				try{ddl_AT_MARKET.SelectedValue = conn.GetFieldValue("AT_MARKET");}
				catch{}
				try{ddl_AT_IKAT.SelectedValue = conn.GetFieldValue("AT_IKAT");}
				catch{}
				try{ddl_AT_KUASA.SelectedValue = conn.GetFieldValue("AT_KUASA");}
				catch{}
				try{ddl_AT_MASALAH.SelectedValue = conn.GetFieldValue("AT_MASALAH");}
				catch{}
				txt_AT_LAIN.Text = conn.GetFieldValue("AT_LAIN");
				lbl_UpdateStatus.Text = conn.GetFieldValue("UPDATESTAT");
			}
			catch {}

			//======================================================================================= bangunan
			conn.QueryString = "select * from VW_APPR_BANGUNAN "+
				"where AP_REGNO = '"+ lbl_AP_REGNO.Text +"' and CU_REF  = '"+ lbl_CU_REF.Text +"' "+
				"and CL_SEQ  = "+ lbl_CL_SEQ.Text;
			conn.ExecuteQuery();
			
			try
			{
				//----------------------------------------------------------------------------------------------
				txt_AB_LUASBANGUN.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AB_LUASBANGUN"));
				txt_AB_THNBUAT.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AB_THNBUAT"));
				txt_AB_THNRENOVASI.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AB_THNRENOVASI"));
				try{ddl_AB_GUNA.SelectedValue = conn.GetFieldValue("AB_GUNA");}
				catch{}
				txt_AB_GUNAKET.Text = conn.GetFieldValue("AB_GUNAKET");
				try{ddl_AB_LISTRIK.SelectedValue = conn.GetFieldValue("AB_LISTRIK");}
				catch{}
				txt_AB_KETLISTRIK.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AB_KETLISTRIK"));
				try{ddl_AB_TELPFAX.SelectedValue = conn.GetFieldValue("AB_TELPFAX");}
				catch{}
				txt_AB_KETTELPFAX.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AB_KETTELPFAX"));
				try{ddl_AB_AIR.SelectedValue = conn.GetFieldValue("AB_AIR");}
				catch{}
				try{ddl_AB_KETAIR.SelectedValue = conn.GetFieldValue("AB_KETAIR");}
				catch{}
				try{ddl_AB_AC.SelectedValue = conn.GetFieldValue("AB_AC");}
				catch{}
				txt_AB_KETAC.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AB_KETAC"));
				try{ddl_AB_PRASARANALAIN.SelectedValue = conn.GetFieldValue("AB_PRASARANALAIN");}
				catch{}
				txt_AB_KETPRASARANALAIN.Text = conn.GetFieldValue("AB_KETPRASARANALAIN");
				try{ddl_AB_JENISBANGUNAN.SelectedValue = conn.GetFieldValue("AB_JENISBANGUNAN");}
				catch{}
				try{ddl_AB_KONTRUKSI.SelectedValue = conn.GetFieldValue("AB_KONTRUKSI");}
				catch{}
				try{ddl_AB_DINDING.SelectedValue = conn.GetFieldValue("AB_DINDING");}
				catch{}
				try{ddl_AB_ATAP.SelectedValue = conn.GetFieldValue("AB_ATAP");}
				catch{}
				try{ddl_AB_LANTAI.SelectedValue = conn.GetFieldValue("AB_LANTAI");}
				catch{}
				try{ddl_AB_PINTU.SelectedValue = conn.GetFieldValue("AB_PINTU");}
				catch{}
				try{ddl_AB_KONDISI.SelectedValue = conn.GetFieldValue("AB_KONDISI");}
				catch{}
				try{ddl_AB_PEMELIHARAANBGN.SelectedValue = conn.GetFieldValue("AB_PEMELIHARAANBGN");}
				catch{}
				try{ddl_AB_LOKASI.SelectedValue = conn.GetFieldValue("AB_LOKASI");}
				catch{}

				//----------------------------------------------------------------------------------------------
				try{ddl_AB_IJINSTAT.SelectedValue = conn.GetFieldValue("AB_IJINSTAT");}
				catch{}
				txt_AB_IJINNO.Text = conn.GetFieldValue("AB_IJINNO");
				try {GlobalTools.fillDateForm(txt_AB_IJINDATE_DD,ddl_AB_IJINDATE_MM,txt_AB_IJINDATE_YY,Convert.ToDateTime(conn.GetFieldValue("AB_IJINDATE")));} 
				catch {}
				txt_AB_IJINDKELUARK.Text = conn.GetFieldValue("AB_IJINDKELUARK");
				txt_AB_IJINLUAS.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AB_IJINLUAS"));

				//----------------------------------------------------------------------------------------------
				try{ddl_AB_INSRSTATUS.SelectedValue = conn.GetFieldValue("AB_INSRSTATUS");}
				catch{}
				txt_AB_INSRTUTUP.Text = conn.GetFieldValue("AB_INSRTUTUP");
				txt_AB_INSRAMOUNT.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AB_INSRAMOUNT"));
				try {GlobalTools.fillDateForm(txt_AB_INSREXPDATE_DD,ddl_AB_INSREXPDATE_MM,txt_AB_INSREXPDATE_YY,Convert.ToDateTime(conn.GetFieldValue("AB_INSREXPDATE")));} 
				catch {}
				txt_AB_INSRCOMP.Text = conn.GetFieldValue("AB_INSRCOMP");
				//----------------------------------------------------------------------------------------------
				txt_AB_HRGBARUM2.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AB_HRGBARUM2"));
				txt_AB_UMUREKON.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AB_UMUREKON"));
				try{ddl_AB_TUJUAN.SelectedValue = conn.GetFieldValue("AB_TUJUAN"); }
				catch{}
				txt_AB_SUMBERDATA.Text = conn.GetFieldValue("AB_SUMBERDATA");
				txt_AB_KESIMPULAN.Text = conn.GetFieldValue("AB_KESIMPULAN");
				lbl_UpdateStatus.Text = conn.GetFieldValue("UPDATESTAT");
			}
			catch{}
		}


		private void KalkulasiTanah()
		{
			double NilaiPasarPerM2, HargaPasar, SafetyMargin;
			double Score = HitungScore();

			//hitung: harga pasar per M2
			NilaiPasarPerM2 = Convert.ToDouble(txt_AT_DATA1.Text) * 0.30 + 
				Convert.ToDouble(txt_AT_DATA2.Text) * 0.30 + 
				Convert.ToDouble(txt_AT_DATA3.Text) * 0.40;
			txt_AT_NILPASAR.Text = GlobalTools.MoneyFormat(NilaiPasarPerM2.ToString());

			//hitung: harg pasar
			HargaPasar = NilaiPasarPerM2 * Convert.ToDouble(txt_AT_LUASTNH.Text);
			txt_AT_HRGPASAR.Text = GlobalTools.MoneyFormat(HargaPasar.ToString());

			//hitung: safety margin
			if (Score <= 5)
				SafetyMargin = 0.10;
			else if (Score == 6)
				SafetyMargin = 0.15;
			else if (Score == 7)
				SafetyMargin = 0.20;
			else if (Score == 8)
				SafetyMargin = 0.25;
			else if (Score == 9)
				SafetyMargin = 0.30;
			else if (Score == 10)
				SafetyMargin = 0.40;
			else if (Score == 11)
				SafetyMargin = 0.50;
			else
				SafetyMargin = 0.75;

			if (ddl_AT_TUJUAN.SelectedItem.ToString() == "Penebusan Agunan")
				SafetyMargin = 0;

			if(ddl_AT_ISNEW.SelectedIndex == 0)
				SafetyMargin = 0;

			txt_AT_SFTYMARGIN.Text = Strings.Format(SafetyMargin,"0.0%");


			//hitung: nilai pasar yang dapat di terima bank
			txt_AT_HRGWAJAR.Text =  GlobalTools.MoneyFormat(Convert.ToString(HargaPasar*(1-SafetyMargin)));
		}

		private bool KalkulasiBangunan()
		{
			double UmurEkonomis, UmurEfektif, UmurRenovasi, UmurBangunan, SusutPerTahun, AkumSusut, PersenAkumSusut,
				SafetyMargin, HargaBangunBaru, HargaBangunan, Score;
			try
			{

				//hitung: biaya pembangunan baru
				HargaBangunBaru = Convert.ToDouble(txt_AB_LUASBANGUN.Text) * Convert.ToDouble(txt_AB_HRGBARUM2.Text);
				txt_AB_HRGBANGUNBARU.Text = GlobalTools.MoneyFormat(HargaBangunBaru.ToString());

				//hitung: umur ekonomis
				UmurEkonomis = Double.Parse(txt_AB_UMUREKON.Text);
				if (ddl_AB_JENISBANGUNAN.SelectedValue == "1")
				{
					if (UmurEkonomis > 40)
					{
						Response.Write("<script language='javascript'>alert('Umur Ekonomis maximum 40 tahun jika jenis bangunan permanen');</script>");
						UmurEkonomis = 40;
						txt_AB_UMUREKON.Text = UmurEkonomis.ToString();
					}
				}
				else
				{
					if (UmurEkonomis > 20)
					{
						Response.Write("<script language='javascript'>alert('Umur Ekonomis maximum 20 tahun jika jenis bangunan semi permanen & permanen sederhana');</script>");
						UmurEkonomis = 20;
						txt_AB_UMUREKON.Text = UmurEkonomis.ToString();
					}
				}

				//hitung: umur efektif
				// 1 umur bangunan
				UmurBangunan = Convert.ToDouble(txt_AT_APPRDATE_yy.Text) - Convert.ToDouble(txt_AB_THNBUAT.Text);
				// 2 umur renovasi
				if (txt_AB_THNRENOVASI.Text == "") txt_AB_THNRENOVASI.Text = "0";

				if (Convert.ToDouble(txt_AB_THNRENOVASI.Text) == 0)
					UmurRenovasi = UmurBangunan;
				else
					UmurRenovasi = Convert.ToDouble(txt_AB_THNRENOVASI.Text) - Convert.ToDouble(txt_AB_THNBUAT.Text);
			
				if (UmurRenovasi < 0)
				{
					Response.Write("<script language='javascript'>alert('Tahun Renovasi harus lebih dari Tahun Pembangunan');</script>");
					return false;
				}


				// 3 umur efektif
				UmurEfektif = 0.25 * UmurBangunan + 0.75 * UmurRenovasi;
				txt_AB_UMUREFEKTIF.Text = UmurEfektif.ToString();

				//hitung: Score
				// 1 kondisi
				txt_Score1.Text = ddl_AB_KONDISI.SelectedValue;
				//2 perawatan
				txt_Score2.Text = ddl_AB_PEMELIHARAANBGN.SelectedValue;
				//3 total
				Score = Convert.ToDouble(txt_Score1.Text) + Convert.ToDouble(txt_Score2.Text);
				txt_TOTALSCORE.Text = Score.ToString();
		

				//hitung: penyusutan per tahun
				SusutPerTahun = 1/Convert.ToDouble(txt_AB_UMUREKON.Text);
				txt_AB_SUSUTPERTHN.Text = Strings.Format(SusutPerTahun,"0.0%");

				//hitung: persen akumulasi penyusutan
				if (UmurEfektif * SusutPerTahun > 1)
					PersenAkumSusut = 1;
				else
					PersenAkumSusut = UmurEfektif * SusutPerTahun;
				txt_AB_AKUMSUSUTP.Text = Strings.Format(PersenAkumSusut,"0.0%");

				//hitung: akumulasi penyusutan
				AkumSusut = PersenAkumSusut * HargaBangunBaru;
				txt_AB_AKUMSUSUT.Text = GlobalTools.MoneyFormat(AkumSusut.ToString());

				//hitung: harga bangunan
				HargaBangunan = HargaBangunBaru - AkumSusut;
				txt_AB_HRGBANGUNAN.Text = GlobalTools.MoneyFormat(HargaBangunan.ToString());

				//hitung: safety margin
				if (Score <= 3)
					SafetyMargin = 0.15;
				else if (Score > 3 && Score < 6)
					SafetyMargin = 0.20;
				else if (Score == 6)
					SafetyMargin = 0.25;
				else if (Score == 7)
					SafetyMargin = 0.30;
				else if (Score == 8)
					SafetyMargin = 0.35;
				else if (Score == 9)
					SafetyMargin = 0.50;
				else
					SafetyMargin = 0.75;
		
				if (ddl_AB_TUJUAN.SelectedItem.ToString() == "Penebusan Agunan")
					SafetyMargin = 0;

				txt_AB_SFTYMARGIN.Text = Strings.Format(SafetyMargin,"0.0%");

		
				//hitung: nilai pasar yang dapat di terima bank
				txt_AB_HRGBANK.Text = GlobalTools.MoneyFormat(Convert.ToString(HargaBangunan * (1 - SafetyMargin)));
			}
			catch{}

			

			return true;
		}

		protected void btn_CalcTanah_Click(object sender, System.EventArgs e)
		{
			try
			{
				KalkulasiTanah();
				EnableUpdate();
			}
			catch
			{
				Response.Write("<script language='javascript'>alert('Data yang mau dihitung belum lengkap');</script>");
			}
		}

		protected void btn_CalcBangunan_Click(object sender, System.EventArgs e)
		{
			try
			{
				KalkulasiBangunan();
				EnableUpdate();
			}
			catch
			{
				Response.Write("<script language='javascript'>alert('Data yang mau dihitung belum lengkap');</script>");
			}
		}

		private bool CekSimpan()
		{
			//======================================================================================= tanah
			if (txt_AT_LOKJLN.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Jalan harus diisi');</script>");
				return false;
			}
			else if (txt_AT_LOKDESA.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Kelurahan harus diisi');</script>");
				return false;
			}
			else if (txt_AT_LOKKEC.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Kecamatan harus diisi');</script>");
				return false;
			}
			else if (txt_AT_LOKKAB.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Kota Madya harus diisi');</script>");
				return false;
			}
			else if (txt_AT_APPRBY1.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Penilai 1 harus diisi');</script>");
				return false;
			}
			else if (txt_AT_APPRDATE_yy.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Tanggal Periksa harus diisi');</script>");
				return false;
			}
			else if (txt_AT_LUASTNH.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Luas Tanah harus diisi');</script>");
				return false;
			}
			else if (txt_AT_THNBELI.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Tahun Pembelian harus diisi');</script>");
				return false;
			}
			else if (txt_AT_KETJALAN.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Panjang Jalan harus diisi');</script>");
				return false;
			}
			else if (ddl_AT_SWILAYAH.SelectedValue == "0")
			{
				Response.Write("<script language='javascript'>alert('Wilayah harus dipilih');</script>");
				return false;
			}
			else if (ddl_AT_SLOKASI.SelectedValue == "0")
			{
				Response.Write("<script language='javascript'>alert('Lokasi harus dipilih');</script>");
				return false;
			}
			else if (ddl_AT_SKUALITAS.SelectedValue == "0")
			{
				Response.Write("<script language='javascript'>alert('Bangunan harus dipilih');</script>");
				return false;
			}
			else if (ddl_AT_SLINGKUNGAN.SelectedValue == "0")
			{
				Response.Write("<script language='javascript'>alert('Lingkungan harus dipilih');</script>");
				return false;
			}
			else if (txt_AT_DATA1.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Data I harus diisi');</script>");
				return false;
			}
			else if (txt_AT_DATA2.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Data II harus diisi');</script>");
				return false;
			}
			else if (txt_AT_DATA3.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Data III harus diisi');</script>");
				return false;
			} 
				//======================================================================================= bangunan
			else if (txt_AB_LUASBANGUN.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Luas Bangunan harus diisi');</script>");
				return false;
			}
			else if (txt_AB_THNBUAT.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Tahun Pembangunan harus diisi');</script>");
				return false;
			}
			else if (txt_AB_HRGBARUM2.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Harga Pasar Baru per M2 harus diisi harus diisi');</script>");
				return false;
			}
			return true;
		}

		protected void btn_Save_Click(object sender, System.EventArgs e)
		{
			//======================================================================================= tanah
			if (ddl_AT_SWILAYAH.SelectedIndex == 0) ddl_AT_SWILAYAH.SelectedIndex = 1;

			if (ddl_AT_SLOKASI.SelectedIndex == 0) ddl_AT_SLOKASI.SelectedIndex = 1;

			if (ddl_AT_SKUALITAS.SelectedIndex == 0) ddl_AT_SKUALITAS.SelectedIndex = 1;

			if (ddl_AT_SLINGKUNGAN.SelectedIndex == 0) ddl_AT_SLINGKUNGAN.SelectedIndex = 1;

			conn.QueryString = "SP_APPR_TANAH 'Save','" + lbl_AP_REGNO.Text + "','" + lbl_CU_REF.Text + "'," +
				lbl_CL_SEQ.Text + ",'" +
				txt_AT_NMDEBITUR.Text + "','" +
				txt_AT_APPRBY1.Text + "','" +
				txt_AT_APPRBY2.Text + "'," +
				GlobalTools.ToSQLDate(txt_AT_APPRDATE_dd.Text, ddl_AT_APPRDATE_mm.SelectedValue, txt_AT_APPRDATE_yy.Text) + ",'" +
				txt_AT_LOKJLN.Text + "','" +
				txt_AT_LOKDESA.Text + "','" +
				txt_AT_LOKKEC.Text + "','" +
				txt_AT_LOKKAB.Text + "','" +
				txt_AT_KEADAANFSK.Text + "'," +
				GlobalTools.ConvertNull(txt_AT_LUASTNH.Text) + ",'" +
				txt_AT_JALAN.Text + "'," +
				GlobalTools.ConvertNull(txt_AT_KETJALAN.Text) + ",'" +
				ddl_AT_LISTRIK.SelectedValue + "','" +
				ddl_AT_TELP.SelectedValue + "','" +
				//--------------------------------------------------------------
				ddl_AT_TAIR.SelectedValue + "','" +
				ddl_AT_SPBU.SelectedValue + "','" +
				ddl_AT_IBADAH.SelectedValue + "','" +
				ddl_AT_HIBURAN.SelectedValue + "','" +
				ddl_AT_KUBURAN.SelectedValue + "','" +
				ddl_AT_TSEKOLAH.SelectedValue + "','" +
				ddl_AT_TPASAR.SelectedValue + "','" +
				ddl_AT_ISNEW.SelectedValue + "'," +
				GlobalTools.ConvertNull(txt_AT_THNBELI.Text) + ",'" +
				txt_AT_WILAYAH.Text + "','" +
				ddl_AT_TWILUTK.SelectedValue + "','" +
				//---------------------------------------------------------------
				ddl_AT_BANJIR.SelectedValue + "','" +
				ddl_AT_TEGANGAN.SelectedValue + "','" +
				ddl_AT_TNHLONGSOR.SelectedValue + "','" +
				ddl_AT_PENCEMARAN.SelectedValue + "','" +
				txt_AT_KUALITAS.Text + "','" +
				ddl_AT_KONTURTNH.SelectedValue + "','" +
				ddl_AT_SWILAYAH.SelectedItem + "','" +
				ddl_AT_SLOKASI.SelectedItem + "','" +
				ddl_AT_SKUALITAS.SelectedItem + "','" +
				ddl_AT_SLINGKUNGAN.SelectedItem + "','" +
				ddl_AT_BKTYPE.SelectedValue + "','" +
				txt_AT_BKNO.Text + "','" +
				txt_AT_BKNAMA.Text + "'," +
				GlobalTools.ToSQLDate(txt_AT_BKDATE_dd.Text,ddl_AT_BKDATE_mm.SelectedValue,txt_AT_BKDATE_yy.Text) + ",'" +
				txt_AT_BKAKTA.Text + "','" +
				txt_AT_BKNOTARIS.Text + "','" +
				ddl_AT_IJTYPE.SelectedValue + "','" +
				txt_AT_IJNO.Text + "','" +
				txt_AT_IJNOTARIS.Text + "','" +
				txt_AT_IJSERTIFIKAT.Text + "'," +
				GlobalTools.ConvertNull(txt_AT_IJNILAI.Text) + ",'" +
				txt_AT_IJPADA.Text + "','" +
				txt_AT_ABHASIL.Text + "'," +
				GlobalTools.ToSQLDate(txt_AT_ABDATE_dd.Text,ddl_AT_ABDATE_mm.SelectedValue,txt_AT_ABDATE_yy.Text) + ",'" +
				txt_AT_ABKANTOR.Text + "','" +
				txt_AT_ABPEJABAT.Text + "'," +
				GlobalTools.ConvertNull(txt_AT_DATA1.Text) + "," +
				GlobalTools.ConvertNull(txt_AT_DATA2.Text) + "," +
				GlobalTools.ConvertNull(txt_AT_DATA3.Text) + ",'" +
				txt_AT_NAMA1.Text + "','" +
				txt_AT_NAMA2.Text + "','" +
				txt_AT_NAMA3.Text + "','" +
				txt_AT_ALAMAT1.Text + "','" +
				txt_AT_ALAMAT2.Text + "','" +
				txt_AT_ALAMAT3.Text + "','" +
				txt_AT_TGL1.Text + "','" +
				txt_AT_TGL2.Text + "','" +
				txt_AT_TGL3.Text + "','" +
				ddl_AT_TUJUAN.SelectedValue + "','" +
				ddl_AT_MARKET.SelectedValue + "','" +
				ddl_AT_IKAT.SelectedValue + "','" +
				ddl_AT_MASALAH.SelectedValue + "','" +
				ddl_AT_KUASA.SelectedValue + "','" +
				txt_AT_LAIN.Text + "','';";
			//			try
			//			{
			conn.ExecuteNonQuery();

			//-----------------------------------------------------------------simpan ke APPR_LIST
			conn.QueryString = "EXEC SP_APPR_LIST 'Save','" + lbl_AP_REGNO.Text + "','" + lbl_CU_REF.Text + "','" + 
				lbl_CL_SEQ.Text + "','9','Tanah Bangunan'";
			conn.ExecuteNonQuery();

			//-----------------------------------------------------------------refresh parent
			Response.Write("<script language='javascript'> " +
				"parent.document.Form1.action = 'InfoUmum.aspx?regno=" + lbl_AP_REGNO.Text + "&curef=" + lbl_CU_REF.Text + "&cl_seq=" + lbl_CL_SEQ.Text + "&tc=" + lbl_TC.Text + "&mc=" + lbl_MC.Text + "';" +
				"parent.document.Form1.submit();</script>");
			//			}
			//			catch
			//			{
			//				Response.Write("<script language='javascript'>alert('Ada masalah waktu penyimpanan');</script>");
			//			}

			//======================================================================================= bangunan
			if (KalkulasiBangunan())
			{
				conn.QueryString = "EXEC SP_APPR_BANGUNAN 'Save','" + 
					lbl_AP_REGNO.Text + "','" + 
					lbl_CU_REF.Text + "','" + 
					lbl_CL_SEQ.Text + "','" + 
					txt_AT_NMDEBITUR.Text + "'," +
					GlobalTools.ToSQLDate(txt_AT_APPRDATE_dd.Text, ddl_AT_APPRDATE_mm.SelectedValue, txt_AT_APPRDATE_yy.Text) + ",'" +
					txt_AT_APPRBY1.Text + "','" + 
					txt_AT_APPRBY2.Text + "','" + 
					txt_AT_LOKJLN.Text + "','" +
					txt_AT_LOKDESA.Text + "','" + 
					txt_AT_LOKKEC.Text + "','" + 
					txt_AT_LOKKAB.Text +"'," +
					GlobalTools.ConvertNull(txt_AB_LUASBANGUN.Text) + "," + 
					GlobalTools.ConvertNull(txt_AB_THNBUAT.Text) + "," + 
					GlobalTools.ConvertNull(txt_AB_THNRENOVASI.Text) + ",'" +
					ddl_AB_GUNA.SelectedValue + "','" + 
					txt_AB_GUNAKET.Text + "','" + 
					ddl_AB_IJINSTAT.SelectedValue + "','" +
					txt_AB_IJINNO.Text + "','" + 
					txt_AB_IJINDKELUARK.Text + "'," + 
					GlobalTools.ToSQLDate(txt_AB_IJINDATE_DD.Text, ddl_AB_IJINDATE_MM.SelectedValue, txt_AB_IJINDATE_YY.Text) + "," +
					GlobalTools.ConvertNull(txt_AB_IJINLUAS.Text) + ",'" + 
					ddl_AB_JENISBANGUNAN.SelectedValue + "','" + 
					ddl_AB_PEMELIHARAANBGN.SelectedValue + "','" + 
					ddl_AB_KONTRUKSI.SelectedValue + "','" + 
					ddl_AB_DINDING.SelectedValue + "','" + 
					ddl_AB_LANTAI.SelectedValue + "','" + 
					ddl_AB_ATAP.SelectedValue + "','" + 
					ddl_AB_PINTU.SelectedValue + "','" + 
					ddl_AB_LOKASI.SelectedValue + "','" + 
					ddl_AB_KONDISI.SelectedValue + "','" + 
					ddl_AB_LISTRIK.SelectedValue + "','" + 
					txt_AB_KETLISTRIK.Text + "','" + 
					ddl_AB_AC.SelectedValue + "','" + 
					txt_AB_KETAC.Text + "','" + 
					ddl_AB_AIR.SelectedValue +"','" + 
					ddl_AB_KETAIR.SelectedValue + "','" + 
					ddl_AB_TELPFAX.SelectedValue + "','" +
					txt_AB_KETTELPFAX.Text + "','" + 
					ddl_AB_PRASARANALAIN.SelectedValue + "','" +
					txt_AB_KETPRASARANALAIN.Text + "','" + 
					ddl_AB_INSRSTATUS.SelectedValue + "','" + 
					txt_AB_INSRTUTUP.Text + "'," +
					GlobalTools.ConvertNull(txt_AB_INSRAMOUNT.Text) + "," +
					GlobalTools.ToSQLDate(txt_AB_INSREXPDATE_DD.Text, ddl_AB_INSREXPDATE_MM.SelectedValue, txt_AB_INSREXPDATE_YY.Text) + ",'" +
					txt_AB_INSRCOMP.Text + "'," + 
					GlobalTools.ConvertNull(txt_AB_HRGBARUM2.Text) + "," + 
					GlobalTools.ConvertNull(txt_AB_UMUREKON.Text) + ",'" + 
					ddl_AB_TUJUAN.SelectedValue + "','" +
					txt_AB_SUMBERDATA.Text + "','" + 
					txt_AB_KESIMPULAN.Text + "','';";

				//				try
				//				{
				conn.ExecuteNonQuery();

				//-----------------------------------------------------------------simpan ke APPR_LIST
				conn.QueryString = "EXEC SP_APPR_LIST 'Save','" + lbl_AP_REGNO.Text + "','" + lbl_CU_REF.Text + "','" + 
					lbl_CL_SEQ.Text + "','9','Tanah Bangunan'";
				conn.ExecuteNonQuery();

				//-----------------------------------------------------------------refresh parent
				Response.Write("<script language='javascript'> " +
					"parent.document.Form1.action = 'InfoUmum.aspx?regno=" + lbl_AP_REGNO.Text + "&curef=" + lbl_CU_REF.Text + "&cl_seq=" + lbl_CL_SEQ.Text + "&tc=" + lbl_TC.Text + "&mc=" + lbl_MC.Text + "';" +
					"parent.document.Form1.submit();</script>");

				//				}
				//				catch
				//				{
				//					Response.Write("<script language='javascript'>alert('Ada masalah waktu penyimpanan');</script>");
				//				}
			}
		}

		protected void btn_UpdateStatus_Click(object sender, System.EventArgs e)
		{
			if (CekSimpan())
			{
				//======================================================================================= tanah
				if (ddl_AT_SWILAYAH.SelectedIndex == 0) ddl_AT_SWILAYAH.SelectedIndex = 1;

				if (ddl_AT_SLOKASI.SelectedIndex == 0) ddl_AT_SLOKASI.SelectedIndex = 1;

				if (ddl_AT_SKUALITAS.SelectedIndex == 0) ddl_AT_SKUALITAS.SelectedIndex = 1;

				if (ddl_AT_SLINGKUNGAN.SelectedIndex == 0) ddl_AT_SLINGKUNGAN.SelectedIndex = 1;

				conn.QueryString = "SP_APPR_TANAH 'Save','" + lbl_AP_REGNO.Text + "','" + lbl_CU_REF.Text + "'," +
					lbl_CL_SEQ.Text + ",'" +
					txt_AT_NMDEBITUR.Text + "','" +
					txt_AT_APPRBY1.Text + "','" +
					txt_AT_APPRBY2.Text + "'," +
					GlobalTools.ToSQLDate(txt_AT_APPRDATE_dd.Text, ddl_AT_APPRDATE_mm.SelectedValue, txt_AT_APPRDATE_yy.Text) + ",'" +
					txt_AT_LOKJLN.Text + "','" +
					txt_AT_LOKDESA.Text + "','" +
					txt_AT_LOKKEC.Text + "','" +
					txt_AT_LOKKAB.Text + "','" +
					txt_AT_KEADAANFSK.Text + "'," +
					GlobalTools.ConvertNull(txt_AT_LUASTNH.Text) + ",'" +
					txt_AT_JALAN.Text + "'," +
					GlobalTools.ConvertNull(txt_AT_KETJALAN.Text) + ",'" +
					ddl_AT_LISTRIK.SelectedValue + "','" +
					ddl_AT_TELP.SelectedValue + "','" +
					//--------------------------------------------------------------
					ddl_AT_TAIR.SelectedValue + "','" +
					ddl_AT_SPBU.SelectedValue + "','" +
					ddl_AT_IBADAH.SelectedValue + "','" +
					ddl_AT_HIBURAN.SelectedValue + "','" +
					ddl_AT_KUBURAN.SelectedValue + "','" +
					ddl_AT_TSEKOLAH.SelectedValue + "','" +
					ddl_AT_TPASAR.SelectedValue + "','" +
					ddl_AT_ISNEW.SelectedValue + "'," +
					GlobalTools.ConvertNull(txt_AT_THNBELI.Text) + ",'" +
					txt_AT_WILAYAH.Text + "','" +
					ddl_AT_TWILUTK.SelectedValue + "','" +
					//---------------------------------------------------------------
					ddl_AT_BANJIR.SelectedValue + "','" +
					ddl_AT_TEGANGAN.SelectedValue + "','" +
					ddl_AT_TNHLONGSOR.SelectedValue + "','" +
					ddl_AT_PENCEMARAN.SelectedValue + "','" +
					txt_AT_KUALITAS.Text + "','" +
					ddl_AT_KONTURTNH.SelectedValue + "','" +
					ddl_AT_SWILAYAH.SelectedItem + "','" +
					ddl_AT_SLOKASI.SelectedItem + "','" +
					ddl_AT_SKUALITAS.SelectedItem + "','" +
					ddl_AT_SLINGKUNGAN.SelectedItem + "','" +
					ddl_AT_BKTYPE.SelectedValue + "','" +
					txt_AT_BKNO.Text + "','" +
					txt_AT_BKNAMA.Text + "'," +
					GlobalTools.ToSQLDate(txt_AT_BKDATE_dd.Text,ddl_AT_BKDATE_mm.SelectedValue,txt_AT_BKDATE_yy.Text) + ",'" +
					txt_AT_BKAKTA.Text + "','" +
					txt_AT_BKNOTARIS.Text + "','" +
					ddl_AT_IJTYPE.SelectedValue + "','" +
					txt_AT_IJNO.Text + "','" +
					txt_AT_IJNOTARIS.Text + "','" +
					txt_AT_IJSERTIFIKAT.Text + "'," +
					GlobalTools.ConvertNull(txt_AT_IJNILAI.Text) + ",'" +
					txt_AT_IJPADA.Text + "','" +
					txt_AT_ABHASIL.Text + "'," +
					GlobalTools.ToSQLDate(txt_AT_ABDATE_dd.Text,ddl_AT_ABDATE_mm.SelectedValue,txt_AT_ABDATE_yy.Text) + ",'" +
					txt_AT_ABKANTOR.Text + "','" +
					txt_AT_ABPEJABAT.Text + "'," +
					GlobalTools.ConvertNull(txt_AT_DATA1.Text) + "," +
					GlobalTools.ConvertNull(txt_AT_DATA2.Text) + "," +
					GlobalTools.ConvertNull(txt_AT_DATA3.Text) + ",'" +
					txt_AT_NAMA1.Text + "','" +
					txt_AT_NAMA2.Text + "','" +
					txt_AT_NAMA3.Text + "','" +
					txt_AT_ALAMAT1.Text + "','" +
					txt_AT_ALAMAT2.Text + "','" +
					txt_AT_ALAMAT3.Text + "','" +
					txt_AT_TGL1.Text + "','" +
					txt_AT_TGL2.Text + "','" +
					txt_AT_TGL3.Text + "','" +
					ddl_AT_TUJUAN.SelectedValue + "','" +
					ddl_AT_MARKET.SelectedValue + "','" +
					ddl_AT_IKAT.SelectedValue + "','" +
					ddl_AT_MASALAH.SelectedValue + "','" +
					ddl_AT_KUASA.SelectedValue + "','" +
					txt_AT_LAIN.Text + "','';";
				//				try
				//				{
				conn.ExecuteNonQuery();

				//-----------------------------------------------------------------simpan ke APPR_LIST
				conn.QueryString = "EXEC SP_APPR_LIST 'Save','" + lbl_AP_REGNO.Text + "','" + lbl_CU_REF.Text + "','" + 
					lbl_CL_SEQ.Text + "','9','Tanah Bangunan'";
				conn.ExecuteNonQuery();

				//-----------------------------------------------------------------refresh parent
				Response.Write("<script language='javascript'> " +
					"parent.document.Form1.action = 'InfoUmum.aspx?regno=" + lbl_AP_REGNO.Text + "&curef=" + lbl_CU_REF.Text + "&cl_seq=" + lbl_CL_SEQ.Text + "&tc=" + lbl_TC.Text + "&mc=" + lbl_MC.Text + "';" +
					"parent.document.Form1.submit();</script>");

				//########################################## update status
				string mGROUP = Session["GroupID"].ToString();
				string LA_APPRSTATUS = "", TABLENAME = "";

				// if (mGROUP == lbl_GRP_COOFF.Text.Trim())
				if (isPetugas(mGROUP)) 
				{
					LA_APPRSTATUS = "5";
				}
				else // if (mGROUP == lbl_GRP_CO.Text.Trim())
				{
					LA_APPRSTATUS = "3";
				}
				conn.QueryString = "select COLLINKTABLE from COLLATERAL cl "+
					"left join RFCOLLATERALTYPE rf on cl.CL_TYPE = rf.COLTYPESEQ "+
					"where CU_REF = '"+lbl_CU_REF.Text+"' and CL_SEQ = "+ lbl_CL_SEQ.Text;
				conn.ExecuteQuery();
				TABLENAME	= conn.GetFieldValue("COLLINKTABLE");

				conn.QueryString = "select count(*) from "+TABLENAME+" where CU_REF = '"+lbl_CU_REF.Text+"' and CL_SEQ = "+lbl_CL_SEQ.Text;
				conn.ExecuteQuery();
				string mStat = conn.GetFieldValue(0,0).ToString();

				conn.QueryString = "exec APPRAISAL_UPDATESTATUS '" +lbl_AP_REGNO.Text+ "', '"+lbl_CU_REF.Text+"', " +lbl_CL_SEQ.Text+ ", '"+
					LA_APPRSTATUS.ToString()+"', "+ GlobalTools.ConvertFloat(txt_AT_HRGPASAR.Text)+", "+
					GlobalTools.ConvertFloat(txt_AT_HRGWAJAR.Text)+", '" +TABLENAME.Trim()+ "', '"+mStat.ToString().Trim()+"'";
				conn.ExecuteQuery();

				if (LA_APPRSTATUS == "5")
					BackToList();
				else if (LA_APPRSTATUS == "3")
					ViewData();
				//###################################################akhir update status
				//				}
				//				catch
				//				{
				//					Response.Write("<script language='javascript'>alert('Ada masalah waktu penyimpanan');</script>");
				//				}

				//======================================================================================= bangunan
				if (KalkulasiBangunan())
				{
					conn.QueryString = "EXEC SP_APPR_BANGUNAN 'Save','" + 
						lbl_AP_REGNO.Text + "','" + 
						lbl_CU_REF.Text + "','" + 
						lbl_CL_SEQ.Text + "','" + 
						txt_AT_NMDEBITUR.Text + "'," +
						GlobalTools.ToSQLDate(txt_AT_APPRDATE_dd.Text, ddl_AT_APPRDATE_mm.SelectedValue, txt_AT_APPRDATE_yy.Text) + ",'" +
						txt_AT_APPRBY1.Text + "','" + 
						txt_AT_APPRBY2.Text + "','" + 
						txt_AT_LOKJLN.Text + "','" +
						txt_AT_LOKDESA.Text + "','" + 
						txt_AT_LOKKEC.Text + "','" + 
						txt_AT_LOKKAB.Text +"'," +
						GlobalTools.ConvertNull(txt_AB_LUASBANGUN.Text) + "," + 
						GlobalTools.ConvertNull(txt_AB_THNBUAT.Text) + "," + 
						GlobalTools.ConvertNull(txt_AB_THNRENOVASI.Text) + ",'" +
						ddl_AB_GUNA.SelectedValue + "','" + 
						txt_AB_GUNAKET.Text + "','" + 
						ddl_AB_IJINSTAT.SelectedValue + "','" +
						txt_AB_IJINNO.Text + "','" + 
						txt_AB_IJINDKELUARK.Text + "'," + 
						GlobalTools.ToSQLDate(txt_AB_IJINDATE_DD.Text, ddl_AB_IJINDATE_MM.SelectedValue, txt_AB_IJINDATE_YY.Text) + "," +
						GlobalTools.ConvertNull(txt_AB_IJINLUAS.Text) + ",'" + 
						ddl_AB_JENISBANGUNAN.SelectedValue + "','" + 
						ddl_AB_PEMELIHARAANBGN.SelectedValue + "','" + 
						ddl_AB_KONTRUKSI.SelectedValue + "','" + 
						ddl_AB_DINDING.SelectedValue + "','" + 
						ddl_AB_LANTAI.SelectedValue + "','" + 
						ddl_AB_ATAP.SelectedValue + "','" + 
						ddl_AB_PINTU.SelectedValue + "','" + 
						ddl_AB_LOKASI.SelectedValue + "','" + 
						ddl_AB_KONDISI.SelectedValue + "','" + 
						ddl_AB_LISTRIK.SelectedValue + "','" + 
						txt_AB_KETLISTRIK.Text + "','" + 
						ddl_AB_AC.SelectedValue + "','" + 
						txt_AB_KETAC.Text + "','" + 
						ddl_AB_AIR.SelectedValue +"','" + 
						ddl_AB_KETAIR.SelectedValue + "','" + 
						ddl_AB_TELPFAX.SelectedValue + "','" +
						txt_AB_KETTELPFAX.Text + "','" + 
						ddl_AB_PRASARANALAIN.SelectedValue + "','" +
						txt_AB_KETPRASARANALAIN.Text + "','" + 
						ddl_AB_INSRSTATUS.SelectedValue + "','" + 
						txt_AB_INSRTUTUP.Text + "'," +
						GlobalTools.ConvertNull(txt_AB_INSRAMOUNT.Text) + "," +
						GlobalTools.ToSQLDate(txt_AB_INSREXPDATE_DD.Text, ddl_AB_INSREXPDATE_MM.SelectedValue, txt_AB_INSREXPDATE_YY.Text) + ",'" +
						txt_AB_INSRCOMP.Text + "'," + 
						GlobalTools.ConvertNull(txt_AB_HRGBARUM2.Text) + "," + 
						GlobalTools.ConvertNull(txt_AB_UMUREKON.Text) + ",'" + 
						ddl_AB_TUJUAN.SelectedValue + "','" +
						txt_AB_SUMBERDATA.Text + "','" + 
						txt_AB_KESIMPULAN.Text + "','';";

					//					try
					//					{
					conn.ExecuteNonQuery();

					//-----------------------------------------------------------------simpan ke APPR_LIST
					conn.QueryString = "EXEC SP_APPR_LIST 'Save','" + lbl_AP_REGNO.Text + "','" + lbl_CU_REF.Text + "','" + 
						lbl_CL_SEQ.Text + "','9','Tanah Bangunan'";
					conn.ExecuteNonQuery();

					//-----------------------------------------------------------------refresh parent
					Response.Write("<script language='javascript'> " +
						"parent.document.Form1.action = 'InfoUmum.aspx?regno=" + lbl_AP_REGNO.Text + "&curef=" + lbl_CU_REF.Text + "&cl_seq=" + lbl_CL_SEQ.Text + "&tc=" + lbl_TC.Text + "&mc=" + lbl_MC.Text + "';" +
						"parent.document.Form1.submit();</script>");

					//########################################## update status
					mGROUP = Session["GroupID"].ToString(); //ahmad
					LA_APPRSTATUS = "";
					TABLENAME = "";

					// if (mGROUP == lbl_GRP_COOFF.Text.Trim())
					if (isPetugas(mGROUP)) 
					{
						LA_APPRSTATUS = "5";
					}
					else // if (mGROUP == lbl_GRP_CO.Text.Trim())
					{
						LA_APPRSTATUS = "3";
					}
					conn.QueryString = "select COLLINKTABLE from COLLATERAL cl "+
						"left join RFCOLLATERALTYPE rf on cl.CL_TYPE = rf.COLTYPESEQ "+
						"where CU_REF = '"+lbl_CU_REF.Text+"' and CL_SEQ = "+ lbl_CL_SEQ.Text;
					conn.ExecuteQuery();
					TABLENAME	= conn.GetFieldValue("COLLINKTABLE");

					conn.QueryString = "select count(*) from "+TABLENAME+" where CU_REF = '"+lbl_CU_REF.Text+"' and CL_SEQ = "+lbl_CL_SEQ.Text;
					conn.ExecuteQuery();
					mStat = conn.GetFieldValue(0,0).ToString(); //ahmad

					conn.QueryString = "exec APPRAISAL_UPDATESTATUS '" +lbl_AP_REGNO.Text+ "', '"+lbl_CU_REF.Text+"', " +lbl_CL_SEQ.Text+ ", '"+
						LA_APPRSTATUS.ToString()+"', "+ GlobalTools.ConvertFloat(txt_AT_HRGPASAR.Text)+", "+
						GlobalTools.ConvertFloat(txt_AT_HRGWAJAR.Text)+", '" +TABLENAME.Trim()+ "', '"+mStat.ToString().Trim()+"'";
					conn.ExecuteQuery();

					if (LA_APPRSTATUS == "5")
						BackToList();
					else if (LA_APPRSTATUS == "3")
						ViewData();
					//###################################################akhir update status
					//					}
					//					catch
					//					{
					//						Response.Write("<script language='javascript'>alert('Ada masalah waktu penyimpanan');</script>");
					//					}
				}

			}

		}

		protected void btn_Reentry_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "update LISTASSIGNMENT set LA_APPRSTATUS = '2' where AP_REGNO = '" +lbl_AP_REGNO.Text+
				"' and CU_REF = '" + lbl_CU_REF.Text+ "' and CL_SEQ = "+lbl_CL_SEQ.Text;
			conn.ExecuteQuery();
			ViewData();
		}

		private void BackToList() 
		{
			Session.Add("tc", Request.QueryString["tc"]);
			Session.Add("mc", Request.QueryString["mc"]);
			
			string link = "ListAppraisal.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"];
			Response.Write("<form name='Form1' action='"+link+"' target='main'");
			Response.Write("");
			Response.Write("</form>");
			Response.Write("<script language='javascript'>alert('Update Successful!');");
			Response.Write("document.Form2.submit();</script>");			
		}

		private void DisabledEntry()
		{
			//======================================================================================= tanah
			txt_AT_LOKJLN.ReadOnly = true;
			txt_AT_LOKDESA.ReadOnly = true;
			txt_AT_LOKKEC.ReadOnly = true;
			txt_AT_LOKKAB.ReadOnly = true;
			txt_AT_APPRDATE_dd.ReadOnly = true;
			ddl_AT_APPRDATE_mm.Enabled = false;
			txt_AT_APPRDATE_yy.ReadOnly = true;
			txt_AT_APPRBY1.ReadOnly = true;
			txt_AT_APPRBY2.ReadOnly = true;
			txt_AT_KEADAANFSK.ReadOnly = true;
			txt_AT_LUASTNH.ReadOnly = true;
			txt_AT_JALAN.ReadOnly = true;
			txt_AT_KETJALAN.ReadOnly = true;
			ddl_AT_LISTRIK.Enabled = false;
			ddl_AT_TELP.Enabled = false;
			ddl_AT_TAIR.Enabled = false;
			ddl_AT_TSEKOLAH.Enabled = false;
			ddl_AT_TPASAR.Enabled = false;
			ddl_AT_TWILUTK.Enabled = false;
			ddl_AT_SPBU.Enabled = false;
			ddl_AT_IBADAH.Enabled = false;
			ddl_AT_HIBURAN.Enabled = false;
			ddl_AT_KUBURAN.Enabled = false;
			ddl_AT_ISNEW.Enabled = false;
			txt_AT_THNBELI.ReadOnly = true;
			txt_AT_WILAYAH.ReadOnly = false;
			ddl_AT_BANJIR.Enabled = false;
			ddl_AT_TEGANGAN.Enabled = false;
			ddl_AT_TNHLONGSOR.Enabled = false;
			ddl_AT_PENCEMARAN.Enabled = false;
			txt_AT_KUALITAS.ReadOnly = true;
			ddl_AT_KONTURTNH.Enabled = false;
			ddl_AT_SWILAYAH.Enabled = false;
			ddl_AT_SLOKASI.Enabled = false;
			ddl_AT_SKUALITAS.Enabled = false;
			ddl_AT_SLINGKUNGAN.Enabled = false;
			ddl_AT_BKTYPE.Enabled = false;
			txt_AT_BKNO.ReadOnly = true;
			txt_AT_BKDATE_dd.ReadOnly = true;
			ddl_AT_BKDATE_mm.Enabled = false;
			txt_AT_BKDATE_yy.ReadOnly = true;
			txt_AT_BKNAMA.ReadOnly = true;
			txt_AT_BKAKTA.ReadOnly = true;
			txt_AT_BKNOTARIS.ReadOnly = true;
			ddl_AT_IJTYPE.Enabled = false;
			txt_AT_IJNO.ReadOnly = true;
			txt_AT_IJNOTARIS.ReadOnly = true;
			txt_AT_IJSERTIFIKAT.ReadOnly = true;
			txt_AT_IJPADA.ReadOnly = true;
			txt_AT_IJNILAI.ReadOnly = true;
			txt_AT_ABHASIL.ReadOnly = true;
			txt_AT_ABDATE_dd.ReadOnly = true;
			ddl_AT_ABDATE_mm.Enabled = false;
			txt_AT_ABDATE_yy.ReadOnly = true;
			txt_AT_ABKANTOR.ReadOnly = true;
			txt_AT_ABPEJABAT.ReadOnly = true;
			txt_AT_DATA1.ReadOnly = true;
			txt_AT_DATA2.ReadOnly = true;
			txt_AT_DATA3.ReadOnly = true;
			txt_AT_NAMA1.ReadOnly = true;
			txt_AT_NAMA2.ReadOnly = true;
			txt_AT_NAMA3.ReadOnly = true;
			txt_AT_ALAMAT1.ReadOnly = true;
			txt_AT_ALAMAT2.ReadOnly = true;
			txt_AT_ALAMAT3.ReadOnly = true;
			txt_AT_TGL1.ReadOnly = true;
			txt_AT_TGL2.ReadOnly = true;
			txt_AT_TGL3.ReadOnly = true;
			ddl_AT_TUJUAN.Enabled = false;
			ddl_AT_MARKET.Enabled = false;
			ddl_AT_IKAT.Enabled = false;
			ddl_AT_KUASA.Enabled = false;
			ddl_AT_MASALAH.Enabled = false;
			txt_AT_LAIN.ReadOnly = true;
		
			btn_CalcTanah.Visible = false;

			//======================================================================================= bangunan
			txt_AB_LUASBANGUN.ReadOnly = true;
			txt_AB_THNBUAT.ReadOnly = true;
			txt_AB_THNRENOVASI.ReadOnly = true;
			ddl_AB_GUNA.Enabled = false;
			txt_AB_GUNAKET.ReadOnly = true;
			ddl_AB_LISTRIK.Enabled = false;
			txt_AB_KETLISTRIK.ReadOnly = true;
			ddl_AB_TELPFAX.Enabled = false;
			txt_AB_KETTELPFAX.ReadOnly = true;
			ddl_AB_AIR.Enabled = false;
			ddl_AB_KETAIR.Enabled = false;
			ddl_AB_AC.Enabled = false;
			txt_AB_KETAC.ReadOnly = true;
			ddl_AB_PRASARANALAIN.Enabled = false;
			txt_AB_KETPRASARANALAIN.ReadOnly = true;
			ddl_AB_JENISBANGUNAN.Enabled = false;
			ddl_AB_KONTRUKSI.Enabled = false;
			ddl_AB_DINDING.Enabled = false;
			ddl_AB_ATAP.Enabled = false;
			ddl_AB_LANTAI.Enabled = false;
			ddl_AB_PINTU.Enabled = false;
			ddl_AB_KONDISI.Enabled = false;
			ddl_AB_PEMELIHARAANBGN.Enabled = false;
			ddl_AB_LOKASI.Enabled = false;
			ddl_AB_IJINSTAT.Enabled = false;
			txt_AB_IJINNO.ReadOnly = true;
			txt_AB_IJINDATE_DD.ReadOnly = true;
			ddl_AB_IJINDATE_MM.Enabled = false;
			txt_AB_IJINDATE_YY.ReadOnly = true;
			txt_AB_IJINDKELUARK.ReadOnly = true;
			txt_AB_IJINLUAS.ReadOnly = true;
			ddl_AB_INSRSTATUS.Enabled = false;
			txt_AB_INSRTUTUP.ReadOnly = true;
			txt_AB_INSRAMOUNT.ReadOnly = true;
			txt_AB_INSREXPDATE_DD.ReadOnly = true;
			ddl_AB_INSREXPDATE_MM.Enabled = false;
			txt_AB_INSREXPDATE_YY.ReadOnly = true;
			txt_AB_INSRCOMP.ReadOnly = true;
			txt_AB_HRGBARUM2.ReadOnly = true;
			txt_AB_UMUREKON.ReadOnly = true;
			ddl_AB_TUJUAN.Enabled = false;
			txt_AB_SUMBERDATA.ReadOnly = true;
			txt_AB_KESIMPULAN.ReadOnly = true;
		
			btn_CalcBangunan.Visible = false;
		}

		private void EnableUpdate()
		{
			double AT_HRGPASAR = 0, AT_HRGWAJAR = 0, AT_SFTYMARGIN = 0;
			double AB_HRGBANGUNAN = 0, AB_HRGBANK = 0, AB_SFTYMARGIN = 0;

			try {AT_HRGPASAR = double.Parse(GlobalTools.ConvertFloat(txt_AT_HRGPASAR.Text));}
			catch {}
			try {AT_HRGWAJAR = double.Parse(GlobalTools.ConvertFloat(txt_AT_HRGWAJAR.Text));}
			catch {}
			try {AT_SFTYMARGIN = double.Parse(GlobalTools.ConvertFloat(txt_AT_SFTYMARGIN.Text));}
			catch {}
			try {AB_HRGBANGUNAN = double.Parse(GlobalTools.ConvertFloat(txt_AB_HRGBANGUNAN.Text));}
			catch {}
			try {AB_HRGBANK = double.Parse(GlobalTools.ConvertFloat(txt_AB_HRGBANK.Text));}
			catch {}
			try {AB_SFTYMARGIN = double.Parse(GlobalTools.ConvertFloat(txt_AB_SFTYMARGIN.Text));}
			catch {}


			if ( (AT_HRGPASAR > 0) && (AT_HRGWAJAR > 0) && (AT_SFTYMARGIN >= 0) && (AB_HRGBANGUNAN > 0) && (AB_HRGBANK > 0) && (AB_SFTYMARGIN >= 0) )
				btn_UpdateStatus.Enabled = true;
			else
				btn_UpdateStatus.Enabled = false;
		}

	}
}
