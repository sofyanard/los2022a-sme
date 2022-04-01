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
	/// Summary description for PenilaianJaminanTanah.
	/// </summary>
	public partial class PenilaianJaminanTanah : System.Web.UI.Page
	{

		//protected Tools tool = new Tools();
		protected Connection conn;
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

				GlobalTools.initDateFormINA(txt_AT_ABDATE_dd,ddl_AT_ABDATE_mm,txt_AT_ABDATE_yy);
				GlobalTools.initDateFormINA(txt_AT_APPRDATE_dd,ddl_AT_APPRDATE_mm,txt_AT_APPRDATE_yy);
				GlobalTools.initDateFormINA(txt_AT_BKDATE_dd,ddl_AT_BKDATE_mm,txt_AT_BKDATE_yy);

				GlobalTools.fillRefList(ddl_AT_KUBURAN,"select * from RF_APPR_JARAK where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AT_TWILUTK,"select * from RFLINGKUNGAN where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AT_KONTURTNH,"select * from RF_APPR_CONTOUR where active = '1'",false,conn);

				GlobalTools.fillRefList(ddl_AT_BKTYPE,"select * from RF_APPR_BUKTIKEPEMILIKAN where active = '1' and TIPE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_Tujuan,"select * from RF_APPR_TUJUAN where active = '1' ",false,conn);

				GlobalTools.fillRefList(ddl_AT_MARKET,"select * from RF_APPR_MARKETABILITY where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AT_IKAT,"select * from RF_APPR_IKATSEMPURNA where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AT_MASALAH,"select * from RF_APPR_MASALAH where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AT_KUASA,"select * from RFPENGUASAAN where active = '1'",false,conn);

				ViewData();
				txt_Score.Text = Convert.ToString(HitungScore());
				txt_Score2.Text = txt_Score.Text;
				try {Kalkulasi();}
				catch {}
				EnableUpdate();
        	}

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

		protected void ddl_AT_SWILAYAH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txt_Score.Text = Convert.ToString(HitungScore());
			txt_Score2.Text = txt_Score.Text;
		}

		protected void ddl_AT_SLOKASI_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txt_Score.Text = Convert.ToString(HitungScore());
			txt_Score2.Text = txt_Score.Text;
		}

		protected void ddl_AT_SKUALITAS_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txt_Score.Text = Convert.ToString(HitungScore());
			txt_Score2.Text = txt_Score.Text;
		}

		protected void ddl_AT_SLINGKUNGAN_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txt_Score.Text = Convert.ToString(HitungScore());
			txt_Score2.Text = txt_Score.Text;
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
				btn_Delete.Visible = false;
				btn_UpdateStatus.Visible = false;
				btn_Reentry.Visible = false;
				DisabledEntry();
			}
			else if (STSTOMBOL == "2")
			{
				btn_Save.Visible = false;
				btn_Delete.Visible = false;
				btn_UpdateStatus.Visible = true;
				btn_Reentry.Visible = true;
				DisabledEntry();
			}
			//###################################################################################

			conn.QueryString = "select * from VW_INFOUMUM_APPRAISAL "+
				"where AP_REGNO = '"+ lbl_AP_REGNO.Text + "';";
			conn.ExecuteQuery();
			txt_AT_NMDEBITUR.Text = conn.GetFieldValue("CU_NAME");

			//------------------------------------------------------------------------------------------

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

				//=====================================================================
				txt_AT_KEADAANFSK.Text = conn.GetFieldValue("AT_KEADAANFSK");
				txt_AT_LUASTNH.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AT_LUASTNH"));
				txt_AT_JALAN.Text = conn.GetFieldValue("AT_JALAN");
				txt_AT_KETJALAN.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AT_KETJALAN"));
				try{ddl_AT_LISTRIK.SelectedValue = conn.GetFieldValue("AT_LISTRIK");}
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

				//=====================================================================
				try{ddl_AT_BKTYPE.SelectedValue = conn.GetFieldValue("AT_BKTYPE");}
				catch{}
				txt_AT_BKNO.Text = conn.GetFieldValue("AT_BKNO");
				try {GlobalTools.fillDateForm(txt_AT_BKDATE_dd,ddl_AT_BKDATE_mm,txt_AT_BKDATE_yy,Convert.ToDateTime(conn.GetFieldValue("AT_BKDATE")));}
				catch {}
				txt_AT_BKNAMA.Text = conn.GetFieldValue("AT_BKNAMA");
				txt_AT_BKAKTA.Text = conn.GetFieldValue("AT_BKAKTA");
				txt_AT_BKNOTARIS.Text = conn.GetFieldValue("AT_BKNOTARIS");

				//=====================================================================
				try{ddl_AT_IJTYPE.SelectedValue = conn.GetFieldValue("AT_IJTYPE");}
				catch{}
				txt_AT_IJNO.Text = conn.GetFieldValue("AT_IJNO");
				txt_AT_IJNOTARIS.Text = conn.GetFieldValue("AT_IJNOTARIS");
				txt_AT_IJSERTIFIKAT.Text = conn.GetFieldValue("AT_IJSERTIFIKAT");
				txt_AT_IJPADA.Text = conn.GetFieldValue("AT_IJPADA");
				txt_AT_IJNILAI.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AT_IJNILAI"));

				//=====================================================================
				txt_AT_ABHASIL.Text = conn.GetFieldValue("AT_ABHASIL");
				try {GlobalTools.fillDateForm(txt_AT_ABDATE_dd,ddl_AT_ABDATE_mm,txt_AT_ABDATE_yy,Convert.ToDateTime(conn.GetFieldValue("AT_ABDATE")));}
				catch {}
				txt_AT_ABKANTOR.Text = conn.GetFieldValue("AT_ABKANTOR");
				txt_AT_ABPEJABAT.Text = conn.GetFieldValue("AT_ABPEJABAT");

				//=====================================================================
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
				try{ddl_Tujuan.SelectedValue = conn.GetFieldValue("AT_TUJUAN");}
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
		}


		protected void btn_Save_Click(object sender, System.EventArgs e)
		{
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
				ddl_Tujuan.SelectedValue + "','" +
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
					lbl_CL_SEQ.Text + "','8','Tanah'";
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
		}


		protected void btn_UpdateStatus_Click(object sender, System.EventArgs e)
		{
			if (CekSimpan())
			{
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
					ddl_Tujuan.SelectedValue + "','" +
					ddl_AT_MARKET.SelectedValue + "','" +
					ddl_AT_IKAT.SelectedValue + "','" +
					ddl_AT_MASALAH.SelectedValue + "','" +
					ddl_AT_KUASA.SelectedValue + "','" +
					txt_AT_LAIN.Text + "','1';";

//				try
//				{
					conn.ExecuteNonQuery();

					//-----------------------------------------------------------------simpan ke APPR_LIST
					conn.QueryString = "EXEC SP_APPR_LIST 'Save','" + lbl_AP_REGNO.Text + "','" + lbl_CU_REF.Text + "','" + 
						lbl_CL_SEQ.Text + "','8','Tanah'";
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
			}
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

		private void Kalkulasi()
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

			if (ddl_Tujuan.SelectedItem.ToString() == "Penebusan Agunan")
				SafetyMargin = 0;
			
			if(ddl_AT_ISNEW.SelectedIndex == 0)
				SafetyMargin = 0;


			txt_AT_SFTYMARGIN.Text = Strings.Format(SafetyMargin,"0.0%");


			//hitung: nilai pasar yang dapat di terima bank
			txt_AT_HRGWAJAR.Text =  GlobalTools.MoneyFormat(Convert.ToString(HargaPasar*(1-SafetyMargin)));
		}

		protected void btn_Calc_Click(object sender, System.EventArgs e)
		{
			try
			{
				Kalkulasi();
				EnableUpdate();
			}
			catch
			{
				Response.Write("<script language='javascript'>alert('Data yang mau dihitung belum lengkap');</script>");
			}
		}


		private bool CekSimpan()
		{
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
			return true;
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
			ddl_Tujuan.Enabled = false;
			ddl_AT_MARKET.Enabled = false;
			ddl_AT_IKAT.Enabled = false;
			ddl_AT_KUASA.Enabled = false;
			ddl_AT_MASALAH.Enabled = false;
			txt_AT_LAIN.ReadOnly = true;
		
			btn_Calc.Visible = false;
		}

		private void EnableUpdate()
		{
			double AT_HRGPASAR = 0, AT_HRGWAJAR = 0, AT_SFTYMARGIN = 0;

			try {AT_HRGPASAR = double.Parse(GlobalTools.ConvertFloat(txt_AT_HRGPASAR.Text));}
			catch {}
			try {AT_HRGWAJAR = double.Parse(GlobalTools.ConvertFloat(txt_AT_HRGWAJAR.Text));}
			catch {}
			try {AT_SFTYMARGIN = double.Parse(GlobalTools.ConvertFloat(txt_AT_SFTYMARGIN.Text));}
			catch {}


			if ( (AT_HRGPASAR > 0) && (AT_HRGWAJAR > 0) && (AT_SFTYMARGIN >= 0) )
				btn_UpdateStatus.Enabled = true;
			else
				btn_UpdateStatus.Enabled = false;
		}

		protected void btn_Delete_Click(object sender, System.EventArgs e)
		{
			//-----------------------------------------------------------------hapus dari APPR_TANAH
			conn.QueryString = "SP_APPR_TANAH 'Delete','" + 
				lbl_AP_REGNO.Text + "','"+ 
				lbl_CU_REF.Text + "','" +				
				lbl_CL_SEQ.Text + "'";
			conn.ExecuteNonQuery();

			//-----------------------------------------------------------------hapus dari APPR_LIST
			conn.QueryString = "EXEC SP_APPR_LIST 'Delete','" + lbl_AP_REGNO.Text + "','" + lbl_CU_REF.Text + "','" + 
				lbl_CL_SEQ.Text + "'";
			conn.ExecuteNonQuery();

			//-----------------------------------------------------------------refresh parent
			Response.Write("<script language='javascript'> " +
				"parent.document.Form1.action = 'InfoUmum.aspx?regno=" + lbl_AP_REGNO.Text + "&curef=" + lbl_CU_REF.Text + "&cl_seq=" + lbl_CL_SEQ.Text + "&tc=" + lbl_TC.Text + "&mc=" + lbl_MC.Text + "';" +
				"parent.document.Form1.submit();</script>");
		}


	}
}
