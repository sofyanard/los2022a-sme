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
	/// Summary description for PenilaianJaminanStand.
	/// </summary>
	public partial class PenilaianJaminanStand : System.Web.UI.Page
	{
		
		protected System.Web.UI.WebControls.TextBox txt_AK_KUASA;

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

				GlobalTools.initDateFormINA(txt_AK_ABDATE_dd,ddl_AK_ABDATE_mm,txt_AK_ABDATE_yy);
				GlobalTools.initDateFormINA(txt_AK_APPRDATE_dd,ddl_AK_APPRDATE_mm,txt_AK_APPRDATE_yy);
				GlobalTools.initDateFormINA(txt_AK_BKDATE_dd,ddl_AK_BKDATE_mm,txt_AK_BKDATE_yy);
				GlobalTools.initDateFormINA(txt_AK_INSREXPDATE_dd,ddl_AK_INSREXPDATE_mm,txt_AK_INSREXPDATE_yy);

				GlobalTools.fillRefList(ddl_AK_KETAIR,"select * from RF_APPR_AIR where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AK_LOKASI,"select * from RF_APPR_LANTAIBANGUNAN where active = '1' ",false,conn);
				GlobalTools.fillRefList(ddl_AK_PRASARANA,"select * from RF_APPR_KELENGKAPAN where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AK_BANGUNAN,"select * from RF_APPR_JENISBANGUNAN where active = '1'",false,conn);
				
				GlobalTools.fillRefList(ddl_AK_KUALITAS,"select * from RFKONDISI where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AK_PERAWATAN,"select * from RFKONDISI where active = '1'",false,conn);

				GlobalTools.fillRefList(ddl_AK_LINGKUNGAN,"select * from RFLINGKUNGAN where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AK_LOKPINTU,"select * from RF_APPR_JARAKDEKAT where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AK_BKTYPE,"select * from RF_APPR_BUKTIKEPEMILIKAN where active = '1' and TIPE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_Tujuan,"select * from RF_APPR_TUJUAN where active = '1' ",false,conn);

				GlobalTools.fillRefList(ddl_AK_MARKET,"select * from RF_APPR_MARKETABILITY where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AK_IKAT,"select * from RF_APPR_IKATSEMPURNA where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AK_MASALAH,"select * from RF_APPR_MASALAH where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AK_KUASA, "select * from RFPENGUASAAN where active = '1'", false, conn);

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


		protected void ddl_AK_SWILAYAH_SelectedIndexChanged(object sender, System.EventArgs e)
		{	
			txt_Score.Text = Convert.ToString(HitungScore());
			txt_Score2.Text = txt_Score.Text;
			
		}


		protected void ddl_AK_SLOKASI_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txt_Score.Text = Convert.ToString(HitungScore());
			txt_Score2.Text = txt_Score.Text;
			
		}


		protected void ddl_AK_SBANGUNAN_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txt_Score.Text = Convert.ToString(HitungScore());
			txt_Score2.Text = txt_Score.Text;
			
		}


		protected void ddl_AK_SLINGKUNGAN_SelectedIndexChanged(object sender, System.EventArgs e)
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
			txt_AK_NMDEBITUR.Text = conn.GetFieldValue("CU_NAME");

			//------------------------------------------------------------------------------------------
	
			conn.QueryString = "select * from VW_APPR_KIOS "+
				"where AP_REGNO = '"+ lbl_AP_REGNO.Text +"' and CU_REF  = '"+ lbl_CU_REF.Text +"' "+
				"and CL_SEQ  = "+ lbl_CL_SEQ.Text ;
			conn.ExecuteQuery();

			try
			{
				//=====================================================================
				txt_AK_LOKJLN.Text = conn.GetFieldValue("AK_LOKJLN");
				txt_AK_LOKBLOK.Text = conn.GetFieldValue("AK_LOKBLOK");
				txt_AK_LOKDESA.Text = conn.GetFieldValue("AK_LOKDESA");
				txt_AK_LOKKEC.Text = conn.GetFieldValue("AK_LOKKEC");
				txt_AK_LOKKAB.Text = conn.GetFieldValue("AK_LOKKAB");
				try {GlobalTools.fillDateForm(txt_AK_APPRDATE_dd,ddl_AK_APPRDATE_mm,txt_AK_APPRDATE_yy,Convert.ToDateTime(conn.GetFieldValue("AK_APPRDATE")));}
				catch {}
				txt_AK_APPRBY1.Text = conn.GetFieldValue("AK_APPRBY1");
				txt_AK_APPRBY2.Text = conn.GetFieldValue("AK_APPRBY2");

				//=====================================================================
				txt_AK_LUASBANGUN.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AK_LUASBANGUN"));
				txt_AK_THNBUAT.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AK_THNBUAT"));
				try{ddl_AK_ISNEW.SelectedValue = conn.GetFieldValue("AK_ISNEW");}
				catch{}
				txt_AK_PENGELOLA.Text = conn.GetFieldValue("AK_PENGELOLA");
				txt_AK_JALAN.Text = conn.GetFieldValue("AK_JALAN");
				txt_AK_KETJALAN.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AK_KETJALAN"));
				try{ddl_AK_LISTRIK.SelectedValue = conn.GetFieldValue("AK_LISTRIK");}
				catch{}
				txt_AK_KETLISTRIK.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AK_KETLISTRIK"));
				try{ddl_AK_TELPFAX.SelectedValue = conn.GetFieldValue("AK_TELPFAX");}
				catch{}
				txt_AK_KETTELPFAX.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AK_KETTELPFAX"));
				try{ddl_AK_AIR.SelectedValue = conn.GetFieldValue("AK_AIR");}
				catch{}
				try{ddl_AK_KETAIR.SelectedValue = conn.GetFieldValue("AK_KETAIR");}
				catch{}
				try{ddl_AK_AC.SelectedValue = conn.GetFieldValue("AK_AC");}
				catch{}
				txt_AK_KETAC.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AK_KETAC"));
				try{ddl_AK_LOKASI.SelectedValue = conn.GetFieldValue("AK_LOKASI");}
				catch{}
				try{ddl_AK_BANGUNAN.SelectedValue = conn.GetFieldValue("AK_BANGUNAN");}
				catch{}
				try{ddl_AK_PRASARANA.SelectedValue = conn.GetFieldValue("AK_PRASARANA");}
				catch{}
				try{ddl_AK_KUALITAS.SelectedValue = conn.GetFieldValue("AK_KUALITAS");}
				catch{}

				txt_AK_WILAYAH.Text = conn.GetFieldValue("AK_WILAYAH");
				try{ddl_AK_LINGKUNGAN.SelectedValue = conn.GetFieldValue("AK_LINGKUNGAN");}
				catch{}
				try{ddl_AK_BANJIR.SelectedValue = conn.GetFieldValue("AK_BANJIR");}
				catch{}
				try{ddl_AK_TEGANGAN.SelectedValue = conn.GetFieldValue("AK_TEGANGAN");}
				catch{}
				try{ddl_AK_TNHLONGSOR.SelectedValue = conn.GetFieldValue("AK_TNHLONGSOR");}
				catch{}
				try{ddl_AK_PENCEMARAN.SelectedValue = conn.GetFieldValue("AK_PENCEMARAN");}
				catch{}
				txt_AK_KONDISI.Text = conn.GetFieldValue("AK_KONDISI");
				try{ddl_AK_PERAWATAN.SelectedValue = conn.GetFieldValue("AK_PERAWATAN");}
				catch{}
				try{ddl_AK_LOKPINTU.SelectedValue = conn.GetFieldValue("AK_LOKPINTU");}
				catch{}
				try{ddl_AK_SWILAYAH.SelectedIndex = Convert.ToByte(conn.GetFieldValue("AK_SWILAYAH"));}
				catch{}
				try{ddl_AK_SLOKASI.SelectedIndex = Convert.ToByte(conn.GetFieldValue("AK_SLOKASI"));}
				catch{}
				try{ddl_AK_SBANGUNAN.SelectedIndex = Convert.ToByte(conn.GetFieldValue("AK_SBANGUNAN"));}
				catch{}
				try{ddl_AK_SLINGKUNGAN.SelectedIndex = Convert.ToByte(conn.GetFieldValue("AK_SLINGKUNGAN"));}
				catch{}

				//=====================================================================
				try{ddl_AK_BKTYPE.SelectedValue = conn.GetFieldValue("AK_BKTYPE");}
				catch{}
				txt_AK_BKNO.Text = conn.GetFieldValue("AK_BKNO");
				try {GlobalTools.fillDateForm(txt_AK_BKDATE_dd,ddl_AK_BKDATE_mm,txt_AK_BKDATE_yy,Convert.ToDateTime(conn.GetFieldValue("AK_BKDATE")));}
				catch {}
				txt_AK_BKNAMA.Text = conn.GetFieldValue("AK_BKNAMA");
				txt_AK_BKAKTA.Text = conn.GetFieldValue("AK_BKAKTA");
				txt_AK_BKNOTARIS.Text = conn.GetFieldValue("AK_BKNOTARIS");

				//=====================================================================
				try{ddl_AK_IJTYPE.SelectedValue = conn.GetFieldValue("AK_IJTYPE");}
				catch{}
				txt_AK_IJNO.Text = conn.GetFieldValue("AK_IJNO");
				txt_AK_IJNOTARIS.Text = conn.GetFieldValue("AK_IJNOTARIS");
				txt_AK_IJPADA.Text = conn.GetFieldValue("AK_IJPADA");
				txt_AK_IJNILAI.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AK_IJNILAI"));

				//=====================================================================
				txt_AK_ABHASIL.Text = conn.GetFieldValue("AK_ABHASIL");
				try {GlobalTools.fillDateForm(txt_AK_ABDATE_dd,ddl_AK_ABDATE_mm,txt_AK_ABDATE_yy,Convert.ToDateTime(conn.GetFieldValue("AK_ABDATE")));}
				catch {}
				txt_AK_ABPEJABAT.Text = conn.GetFieldValue("AK_ABPEJABAT");

				//=====================================================================
				try{ddl_AK_INSRSTATUS.SelectedValue = conn.GetFieldValue("AK_INSRSTATUS");}
				catch{}
				txt_AK_INSRTUTUP.Text = conn.GetFieldValue("AK_INSRTUTUP");
				txt_AK_INSRAMOUNT.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AK_INSRAMOUNT"));
				try {GlobalTools.fillDateForm(txt_AK_INSREXPDATE_dd,ddl_AK_INSREXPDATE_mm,txt_AK_INSREXPDATE_yy,Convert.ToDateTime(conn.GetFieldValue("AK_INSREXPDATE")));}
				catch {}
				txt_AK_INSRCOMP.Text = conn.GetFieldValue("AK_INSRCOMP");

				//=====================================================================
				txt_AK_DATA1.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AK_DATA1"));
				txt_AK_DATA2.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AK_DATA2"));
				txt_AK_DATA3.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AK_DATA3"));
				txt_AK_INFO1.Text = conn.GetFieldValue("AK_INFO1");
				txt_AK_INFO2.Text = conn.GetFieldValue("AK_INFO2");
				txt_AK_INFO3.Text = conn.GetFieldValue("AK_INFO3");
				txt_AK_SUMBERD1.Text = conn.GetFieldValue("AK_SUMBERD1");
				txt_AK_SUMBERD2.Text = conn.GetFieldValue("AK_SUMBERD2");
				txt_AK_SUMBERD3.Text = conn.GetFieldValue("AK_SUMBERD3");
				try{ddl_Tujuan.SelectedValue = conn.GetFieldValue("AK_TUJUAN");}
				catch{}

				//=====================================================================
				try{ddl_AK_MARKET.SelectedValue = conn.GetFieldValue("AK_MARKET");}
				catch{}
				try{ddl_AK_IKAT.SelectedValue = conn.GetFieldValue("AK_IKAT");}
				catch{}
				try{ddl_AK_KUASA.SelectedValue = conn.GetFieldValue("AK_KUASA");}
				catch{}
				try{ddl_AK_MASALAH.SelectedValue = conn.GetFieldValue("AK_MASALAH");}
				catch{}
				txt_AK_LAIN.Text = conn.GetFieldValue("AK_LAIN");
				txt_AK_PENDAPAT.Text = conn.GetFieldValue("AK_PENDAPAT");
				lbl_UpdateStatus.Text = conn.GetFieldValue("UPDATESTAT");
			}
			catch {}
		}


		protected void btn_Save_Click(object sender, System.EventArgs e)
		{
			if (ddl_AK_SWILAYAH.SelectedIndex == 0) ddl_AK_SWILAYAH.SelectedIndex = 1;

			if (ddl_AK_SLOKASI.SelectedIndex == 0) ddl_AK_SLOKASI.SelectedIndex = 1;

			if (ddl_AK_SBANGUNAN.SelectedIndex == 0) ddl_AK_SBANGUNAN.SelectedIndex = 1;

			if (ddl_AK_SLINGKUNGAN.SelectedIndex == 0) ddl_AK_SLINGKUNGAN.SelectedIndex = 1;

			conn.QueryString = "SP_APPR_KIOS 'Save','" + 
				lbl_AP_REGNO.Text + "','" + 
				lbl_CU_REF.Text + "'," +
				lbl_CL_SEQ.Text + ",'" + 
				txt_AK_NMDEBITUR.Text + "','" + 
				txt_AK_APPRBY1.Text + "','" + 
				txt_AK_APPRBY2.Text + "'," + 
				GlobalTools.ToSQLDate(txt_AK_APPRDATE_dd.Text, ddl_AK_APPRDATE_mm.SelectedValue,txt_AK_APPRDATE_yy.Text) + ",'" + 
				txt_AK_LOKJLN.Text + "','" + 
				txt_AK_LOKBLOK.Text + "','" + 
				txt_AK_LOKDESA.Text + "','" + 
				txt_AK_LOKKEC.Text + "','" + 
				txt_AK_LOKKAB.Text + "'," + 
				GlobalTools.ConvertNull(txt_AK_LUASBANGUN.Text) + "," + 
				GlobalTools.ConvertNull(txt_AK_THNBUAT.Text) + ",'" + 
				ddl_AK_ISNEW.SelectedValue + "','" + 
				txt_AK_PENGELOLA.Text + "','" + 
				txt_AK_JALAN.Text + "'," + 
				GlobalTools.ConvertNull(txt_AK_KETJALAN.Text) + ",'" +
				ddl_AK_LISTRIK.SelectedValue + "'," + 
				txt_AK_KETLISTRIK.Text + ",'" + 
				ddl_AK_TELPFAX.SelectedValue + "'," + 
				txt_AK_KETTELPFAX.Text + ",'" +
				ddl_AK_AIR.SelectedValue + "','" + 
				ddl_AK_KETAIR.SelectedValue + "','" + 
				ddl_AK_AC.SelectedValue + "'," + 
				txt_AK_KETAC.Text + ",'" + 
				ddl_AK_LOKASI.SelectedValue + "','" + 
				ddl_AK_PRASARANA.SelectedValue + "','" + 
				ddl_AK_BANGUNAN.SelectedValue + "','" + 
				ddl_AK_KUALITAS.SelectedValue + "','" + 
				ddl_AK_LINGKUNGAN.SelectedValue + "','" + 
				txt_AK_WILAYAH.Text + "','" + 
				ddl_AK_BANJIR.SelectedValue  + "','" + 
				ddl_AK_TEGANGAN.SelectedValue + "','" + 
				ddl_AK_TNHLONGSOR.SelectedValue + "','" + 
				ddl_AK_PENCEMARAN.SelectedValue + "','" +
				txt_AK_KONDISI.Text + "','" + 
				ddl_AK_PERAWATAN.SelectedValue + "','" + 
				ddl_AK_LOKPINTU.SelectedValue + "'," + 
				ddl_AK_SWILAYAH.SelectedItem + "," +
				ddl_AK_SLOKASI.SelectedItem + "," +
				ddl_AK_SBANGUNAN.SelectedItem + "," +
				ddl_AK_SLINGKUNGAN.SelectedItem + ",'" +
				ddl_AK_BKTYPE.SelectedValue + "','" + 
				txt_AK_BKNO.Text + "'," + 
				GlobalTools.ToSQLDate(txt_AK_BKDATE_dd.Text,ddl_AK_BKDATE_mm.SelectedValue,txt_AK_BKDATE_yy.Text)  + ",'" + 
				txt_AK_BKNAMA.Text + "','" + 
				txt_AK_BKAKTA.Text + "','" + 
				txt_AK_BKNOTARIS.Text + "','" + 
				ddl_AK_IJTYPE.SelectedValue + "','" + 
				txt_AK_IJNO.Text + "','" + 
				txt_AK_IJPADA.Text + "','" + 
				txt_AK_IJNOTARIS.Text + "'," + 
				GlobalTools.ConvertNull(txt_AK_IJNILAI.Text) + ",'" +
				txt_AK_ABHASIL.Text + "'," + 
				GlobalTools.ToSQLDate(txt_AK_ABDATE_dd.Text, ddl_AK_ABDATE_mm.SelectedValue, txt_AK_ABDATE_yy.Text) + ",'" + 
				txt_AK_ABPEJABAT.Text + "','" +
				ddl_AK_INSRSTATUS.SelectedValue + "','" + 
				txt_AK_INSRTUTUP.Text + "'," + 
				GlobalTools.ConvertNull(txt_AK_INSRAMOUNT.Text) + "," + 
				GlobalTools.ToSQLDate(txt_AK_INSREXPDATE_dd.Text, ddl_AK_INSREXPDATE_mm.SelectedValue, txt_AK_INSREXPDATE_yy.Text) + ",'" + 
				txt_AK_INSRCOMP.Text + "'," + 
				GlobalTools.ConvertNull(txt_AK_DATA1.Text) + "," + 
				GlobalTools.ConvertNull(txt_AK_DATA2.Text) + "," + 
				GlobalTools.ConvertNull(txt_AK_DATA3.Text) + ",'" + 
				txt_AK_INFO1.Text + "','" + 
				txt_AK_INFO2.Text + "','" + 
				txt_AK_INFO3.Text + "','" + 
				txt_AK_SUMBERD1.Text + "','" + 
				txt_AK_SUMBERD2.Text + "','" + 
				txt_AK_SUMBERD3.Text + "','" + 
				ddl_Tujuan.SelectedValue + "','" + 
				ddl_AK_MARKET.SelectedValue + "','" + 
				ddl_AK_IKAT.SelectedValue + "','" + 
				ddl_AK_KUASA.SelectedValue + "','" + 
				ddl_AK_MASALAH.SelectedValue + "','" + 
				txt_AK_LAIN.Text + "','" + 
				txt_AK_PENDAPAT.Text + "','';";

//			try
//			{
				conn.ExecuteNonQuery();

				//-----------------------------------------------------------------simpan ke APPR_LIST
				conn.QueryString = "EXEC SP_APPR_LIST 'Save','" + lbl_AP_REGNO.Text + "','" + lbl_CU_REF.Text + "','" + 
					lbl_CL_SEQ.Text + "','3','Kios'";
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
				conn.QueryString = "SP_APPR_KIOS 'Save','" + 
					lbl_AP_REGNO.Text + "','" + 
					lbl_CU_REF.Text + "'," +
					lbl_CL_SEQ.Text + ",'" + 
					txt_AK_NMDEBITUR.Text + "','" + 
					txt_AK_APPRBY1.Text + "','" + 
					txt_AK_APPRBY2.Text + "'," + 
					GlobalTools.ToSQLDate(txt_AK_APPRDATE_dd.Text, ddl_AK_APPRDATE_mm.SelectedValue,txt_AK_APPRDATE_yy.Text) + ",'" + 
					txt_AK_LOKJLN.Text + "','" + 
					txt_AK_LOKBLOK.Text + "','" + 
					txt_AK_LOKDESA.Text + "','" + 
					txt_AK_LOKKEC.Text + "','" + 
					txt_AK_LOKKAB.Text + "'," + 
					GlobalTools.ConvertNull(txt_AK_LUASBANGUN.Text) + "," + 
					GlobalTools.ConvertNull(txt_AK_THNBUAT.Text) + ",'" + 
					ddl_AK_ISNEW.SelectedValue + "','" + 
					txt_AK_PENGELOLA.Text + "','" + 
					txt_AK_JALAN.Text + "'," + 
					GlobalTools.ConvertNull(txt_AK_KETJALAN.Text) + ",'" +
					ddl_AK_LISTRIK.SelectedValue + "'," + 
					txt_AK_KETLISTRIK.Text + ",'" + 
					ddl_AK_TELPFAX.SelectedValue + "'," + 
					txt_AK_KETTELPFAX.Text + ",'" +
					ddl_AK_AIR.SelectedValue + "','" + 
					ddl_AK_KETAIR.SelectedValue + "','" + 
					ddl_AK_AC.SelectedValue + "'," + 
					txt_AK_KETAC.Text + ",'" + 
					ddl_AK_LOKASI.SelectedValue + "','" + 
					ddl_AK_PRASARANA.SelectedValue + "','" + 
					ddl_AK_BANGUNAN.SelectedValue + "','" + 
					ddl_AK_KUALITAS.SelectedValue + "','" + 
					ddl_AK_LINGKUNGAN.SelectedValue + "','" + 
					txt_AK_WILAYAH.Text + "','" + 
					ddl_AK_BANJIR.SelectedValue  + "','" + 
					ddl_AK_TEGANGAN.SelectedValue + "','" + 
					ddl_AK_TNHLONGSOR.SelectedValue + "','" + 
					ddl_AK_PENCEMARAN.SelectedValue + "','" +
					txt_AK_KONDISI.Text + "','" + 
					ddl_AK_PERAWATAN.SelectedValue + "','" + 
					ddl_AK_LOKPINTU.SelectedValue + "'," + 
					ddl_AK_SWILAYAH.SelectedItem + "," +
					ddl_AK_SLOKASI.SelectedItem + "," +
					ddl_AK_SBANGUNAN.SelectedItem + "," +
					ddl_AK_SLINGKUNGAN.SelectedItem + ",'" +
					ddl_AK_BKTYPE.SelectedValue + "','" + 
					txt_AK_BKNO.Text + "'," + 
					GlobalTools.ToSQLDate(txt_AK_BKDATE_dd.Text,ddl_AK_BKDATE_mm.SelectedValue,txt_AK_BKDATE_yy.Text)  + ",'" + 
					txt_AK_BKNAMA.Text + "','" + 
					txt_AK_BKAKTA.Text + "','" + 
					txt_AK_BKNOTARIS.Text + "','" + 
					ddl_AK_IJTYPE.SelectedValue + "','" + 
					txt_AK_IJNO.Text + "','" + 
					txt_AK_IJPADA.Text + "','" + 
					txt_AK_IJNOTARIS.Text + "'," + 
					GlobalTools.ConvertNull(txt_AK_IJNILAI.Text) + ",'" +
					txt_AK_ABHASIL.Text + "'," + 
					GlobalTools.ToSQLDate(txt_AK_ABDATE_dd.Text, ddl_AK_ABDATE_mm.SelectedValue, txt_AK_ABDATE_yy.Text) + ",'" + 
					txt_AK_ABPEJABAT.Text + "','" +
					ddl_AK_INSRSTATUS.SelectedValue + "','" + 
					txt_AK_INSRTUTUP.Text + "'," + 
					GlobalTools.ConvertNull(txt_AK_INSRAMOUNT.Text) + "," + 
					GlobalTools.ToSQLDate(txt_AK_INSREXPDATE_dd.Text, ddl_AK_INSREXPDATE_mm.SelectedValue, txt_AK_INSREXPDATE_yy.Text) + ",'" + 
					txt_AK_INSRCOMP.Text + "'," + 
					GlobalTools.ConvertNull(txt_AK_DATA1.Text) + "," + 
					GlobalTools.ConvertNull(txt_AK_DATA2.Text) + "," + 
					GlobalTools.ConvertNull(txt_AK_DATA3.Text) + ",'" + 
					txt_AK_INFO1.Text + "','" + 
					txt_AK_INFO2.Text + "','" + 
					txt_AK_INFO3.Text + "','" + 
					txt_AK_SUMBERD1.Text + "','" + 
					txt_AK_SUMBERD2.Text + "','" + 
					txt_AK_SUMBERD3.Text + "','" + 
					ddl_Tujuan.SelectedValue + "','" + 
					ddl_AK_MARKET.SelectedValue + "','" + 
					ddl_AK_IKAT.SelectedValue + "','" + 
					ddl_AK_KUASA.SelectedValue + "','" + 
					ddl_AK_MASALAH.SelectedValue + "','" + 
					txt_AK_LAIN.Text + "','" + 
					txt_AK_PENDAPAT.Text + "','1';";
//				try
//				{
					conn.ExecuteNonQuery();

					//-----------------------------------------------------------------simpan ke APPR_LIST
					conn.QueryString = "EXEC SP_APPR_LIST 'Save','" + lbl_AP_REGNO.Text + "','" + lbl_CU_REF.Text + "','" + 
						lbl_CL_SEQ.Text + "','3','Kios'";
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
						LA_APPRSTATUS.ToString()+"', "+ GlobalTools.ConvertFloat(txt_AK_HRGPASAR.Text)+", "+
						GlobalTools.ConvertFloat(txt_AK_HRGWAJAR.Text)+", '" +TABLENAME.Trim()+ "', '"+mStat.ToString().Trim()+"'";
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
			int nWilayah, nLokasi, nBangunan, nLingkungan, nHasil;

			txt_AK_WILAYAH.Text = ddl_AK_SWILAYAH.SelectedValue.ToString();
			txt_AK_JALAN.Text = ddl_AK_SLOKASI.SelectedValue.ToString();
			txt_AK_KONDISI.Text = ddl_AK_SBANGUNAN.SelectedValue.ToString();
			
			//hitung: score
			try {nWilayah = Convert.ToByte(ddl_AK_SWILAYAH.SelectedItem.Text);}
			catch {nWilayah = 0;}

			try {nLokasi = Convert.ToByte(ddl_AK_SLOKASI.SelectedItem.Text);}
			catch {nLokasi = 0;}

			try {nBangunan = Convert.ToByte(ddl_AK_SBANGUNAN.SelectedItem.Text);}
			catch {nBangunan = 0;}

			try {nLingkungan = Convert.ToByte(ddl_AK_SLINGKUNGAN.SelectedItem.Text);}
			catch {nLingkungan = 0;}
			
			nHasil = nWilayah + nLokasi + nBangunan + nLingkungan;
			Score = nHasil;

			return nHasil;
		}


		private void Kalkulasi()
		{
			double HargaPasar, SafetyMargin;
			double Score = HitungScore();

			//hitung: harga pasar keseluruhan
			HargaPasar = Convert.ToDouble(txt_AK_DATA1.Text) * 0.30 + 
				Convert.ToDouble(txt_AK_DATA2.Text) * 0.30 + 
				Convert.ToDouble(txt_AK_DATA3.Text) * 0.40;
			txt_AK_HRGPASAR.Text = GlobalTools.MoneyFormat(HargaPasar.ToString());

			//hitung: safety margin
//			if (Score <= 3)
//				SafetyMargin = 0.15;
//			else if (Score > 3 && Score < 6)
//				SafetyMargin = 0.20;
//			else if (Score == 6)
//				SafetyMargin = 0.25;
//			else if (Score == 7)
//				SafetyMargin = 0.30;
//			else if (Score == 8)
//				SafetyMargin = 0.35;
//			else if (Score == 9)
//				SafetyMargin = 0.50;
//			else
//				SafetyMargin = 0.75;

			if (Score <= 3)
				SafetyMargin = 0.15;
			else if (Score > 3 && Score < 6)
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

			if (ddl_Tujuan.SelectedItem.Text == "Penebusan Agunan")
				SafetyMargin = 0;

			if (ddl_AK_ISNEW.SelectedIndex == 0)
				SafetyMargin = 0;


			txt_AK_SFTYMARGIN.Text = Strings.Format(SafetyMargin,"0.0%");


			//hitung: nilai pasar yang dapat di terima bank
			txt_AK_HRGWAJAR.Text =  GlobalTools.MoneyFormat(Convert.ToString(HargaPasar * (1 - SafetyMargin)));
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
			if (txt_AK_LOKJLN.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Jalan harus diisi');</script>");
				return false;
			}
			if (txt_AK_LOKBLOK.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Blok atau Lantai harus diisi');</script>");
				return false;
			}
			else if (txt_AK_LOKDESA.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Kelurahan harus diisi');</script>");
				return false;
			}
			else if (txt_AK_LOKKEC.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Kecamatan harus diisi');</script>");
				return false;
			}
			else if (txt_AK_LOKKAB.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Kota Madya harus diisi');</script>");
				return false;
			}
			else if (txt_AK_APPRBY1.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Penilai 1 harus diisi');</script>");
				return false;
			}
			else if (txt_AK_APPRDATE_yy.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Tanggal Periksa harus diisi');</script>");
				return false;
			}
			else if (txt_AK_LUASBANGUN.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Luas Bangunan harus diisi');</script>");
				return false;
			}
			else if (txt_AK_THNBUAT.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Tahun Pembuatan harus diisi');</script>");
				return false;
			}
			else if (txt_AK_KETJALAN.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Panjang Jalan harus diisi');</script>");
				return false;
			}
			else if (ddl_AK_SWILAYAH.SelectedValue == "0")
			{
				Response.Write("<script language='javascript'>alert('Wilayah harus dipilih');</script>");
				return false;
			}
			else if (ddl_AK_SLOKASI.SelectedValue == "0")
			{
				Response.Write("<script language='javascript'>alert('Lokasi harus dipilih');</script>");
				return false;
			}
			else if (ddl_AK_SBANGUNAN.SelectedValue == "0")
			{
				Response.Write("<script language='javascript'>alert('Bangunan harus dipilih');</script>");
				return false;
			}
			else if (ddl_AK_SLINGKUNGAN.SelectedValue == "0")
			{
				Response.Write("<script language='javascript'>alert('Lingkungan harus dipilih');</script>");
				return false;
			}
			else if (txt_AK_DATA1.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Data I harus diisi');</script>");
				return false;
			}
			else if (txt_AK_DATA2.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Data II harus diisi');</script>");
				return false;
			}
			else if (txt_AK_DATA3.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Data III harus diisi');</script>");
				return false;
			}
			return true;
		}

		private void btn_Reentry_Click(object sender, System.EventArgs e)
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
			txt_AK_LOKJLN.ReadOnly = true;
			txt_AK_LOKBLOK.ReadOnly = true;
			txt_AK_LOKDESA.ReadOnly = true;
			txt_AK_LOKKEC.ReadOnly = true;
			txt_AK_LOKKAB.ReadOnly = true;
			txt_AK_APPRDATE_dd.ReadOnly = true;
			ddl_AK_APPRDATE_mm.Enabled = false;
			txt_AK_APPRDATE_yy.ReadOnly = true;
			txt_AK_APPRBY1.ReadOnly = true;
			txt_AK_APPRBY2.ReadOnly = true;
			txt_AK_LUASBANGUN.ReadOnly = true;
			txt_AK_THNBUAT.ReadOnly = true;
			ddl_AK_ISNEW.Enabled = false;
			txt_AK_PENGELOLA.ReadOnly = true;
			txt_AK_JALAN.ReadOnly = true;
			txt_AK_KETJALAN.ReadOnly = true;
			ddl_AK_LISTRIK.Enabled = false;
			txt_AK_KETLISTRIK.ReadOnly = true;
			ddl_AK_TELPFAX.Enabled = false;
			txt_AK_KETTELPFAX.ReadOnly = true;
			ddl_AK_AIR.Enabled = false;
			ddl_AK_KETAIR.Enabled = false;
			ddl_AK_AC.Enabled = false;
			txt_AK_KETAC.ReadOnly = true;
			ddl_AK_LOKASI.Enabled = false;
			ddl_AK_BANGUNAN.Enabled = false;
			ddl_AK_PRASARANA.Enabled = false;
			ddl_AK_KUALITAS.Enabled = false;
			txt_AK_WILAYAH.ReadOnly = true;
			ddl_AK_LINGKUNGAN.Enabled = false;
			ddl_AK_BANJIR.Enabled = false;
			ddl_AK_TEGANGAN.Enabled = false;
			ddl_AK_TNHLONGSOR.Enabled = false;
			ddl_AK_PENCEMARAN.Enabled = false;
			txt_AK_KONDISI.ReadOnly = true;
			ddl_AK_PERAWATAN.Enabled = false;
			ddl_AK_LOKPINTU.Enabled = false;
			ddl_AK_SWILAYAH.Enabled = false;
			ddl_AK_SLOKASI.Enabled = false;
			ddl_AK_SBANGUNAN.Enabled = false;
			ddl_AK_SLINGKUNGAN.Enabled = false;
			ddl_AK_BKTYPE.Enabled = false;
			txt_AK_BKNO.ReadOnly = true;
			txt_AK_BKDATE_dd.ReadOnly = true;
			ddl_AK_BKDATE_mm.Enabled = false;
			txt_AK_BKDATE_yy.ReadOnly = true;
			txt_AK_BKNAMA.ReadOnly = true;
			txt_AK_BKAKTA.ReadOnly = true;
			txt_AK_BKNOTARIS.ReadOnly = true;
			ddl_AK_IJTYPE.Enabled = false;
			txt_AK_IJNO.ReadOnly = true;
			txt_AK_IJNOTARIS.ReadOnly = true;
			txt_AK_IJPADA.ReadOnly = true;
			txt_AK_IJNILAI.ReadOnly = true;
			txt_AK_ABHASIL.ReadOnly = true;
			txt_AK_ABDATE_dd.ReadOnly = true;
			ddl_AK_ABDATE_mm.Enabled = false;
			txt_AK_ABDATE_yy.ReadOnly = true;
			txt_AK_ABPEJABAT.ReadOnly = true;
			ddl_AK_INSRSTATUS.Enabled = false;
			txt_AK_INSRTUTUP.ReadOnly = true;
			txt_AK_INSRAMOUNT.ReadOnly = true;
			txt_AK_INSREXPDATE_dd.ReadOnly = true;
			ddl_AK_INSREXPDATE_mm.Enabled = false;
			txt_AK_INSREXPDATE_yy.ReadOnly = true;
			txt_AK_INSRCOMP.ReadOnly = true;
			txt_AK_DATA1.ReadOnly = true;
			txt_AK_DATA2.ReadOnly = true;
			txt_AK_DATA3.ReadOnly = true;
			txt_AK_INFO1.ReadOnly = true;
			txt_AK_INFO2.ReadOnly = true;
			txt_AK_INFO3.ReadOnly = true;
			txt_AK_SUMBERD1.ReadOnly = true;
			txt_AK_SUMBERD2.ReadOnly = true;
			txt_AK_SUMBERD3.ReadOnly = true;
			ddl_Tujuan.Enabled = false;
			ddl_AK_MARKET.Enabled = false;
			ddl_AK_IKAT.Enabled = false;
			ddl_AK_KUASA.Enabled = false;
			ddl_AK_MASALAH.Enabled = false;
			txt_AK_LAIN.ReadOnly = true;
			txt_AK_PENDAPAT.ReadOnly = true;
		
			btn_Calc.Visible = false;
		}

		private void EnableUpdate()
		{
			double AK_HRGPASAR = 0, AK_HRGWAJAR = 0, AK_SFTYMARGIN = 0;

			try {AK_HRGPASAR = double.Parse(GlobalTools.ConvertFloat(txt_AK_HRGPASAR.Text));}
			catch {}
			try {AK_HRGWAJAR = double.Parse(GlobalTools.ConvertFloat(txt_AK_HRGWAJAR.Text));}
			catch {}
			try {AK_SFTYMARGIN = double.Parse(GlobalTools.ConvertFloat(txt_AK_SFTYMARGIN.Text));}
			catch {}


			if ( (AK_HRGPASAR > 0) && (AK_HRGWAJAR > 0) && (AK_SFTYMARGIN >= 0) )
				btn_UpdateStatus.Enabled = true;
			else
				btn_UpdateStatus.Enabled = false;
		}

		protected void btn_Delete_Click(object sender, System.EventArgs e)
		{
			//-----------------------------------------------------------------hapus dari APPR_KIOS
			conn.QueryString = "SP_APPR_KIOS 'Delete','" + 
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
