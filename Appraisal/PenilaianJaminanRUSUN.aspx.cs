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
	/// Summary description for PenilaianJaminanRUSUN.
	/// </summary>
	public partial class PenilaianJaminanRUSUN : System.Web.UI.Page
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

				GlobalTools.initDateFormINA(txt_AR_ABDATE_DD,ddl_AR_ABDATE_MM,txt_AR_ABDATE_YY);
				GlobalTools.initDateFormINA(txt_AR_APPRDATE_DD,ddl_AR_APPRDATE_MM,txt_AR_APPRDATE_YY);
				GlobalTools.initDateFormINA(txt_AR_BKDATE_DD,ddl_AR_BKDATE_MM,txt_AR_BKDATE_YY);
				GlobalTools.initDateFormINA(txt_AR_IMBDATE_DD,ddl_AR_IMBDATE_MM,txt_AR_IMBDATE_YY);
				GlobalTools.initDateFormINA(txt_AR_INSRDATE_DD,ddl_AR_INSRDATE_MM,txt_AR_INSRDATE_YY);

				GlobalTools.fillRefList(ddl_AR_KETAIR,"select * from RF_APPR_AIR where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AR_LOKASI,"select * from RF_APPR_LANTAIBANGUNAN where ACTIVE = '1'",false,conn);

				GlobalTools.fillRefList(ddl_AR_KUALITAS,"select * from RFKONDISI where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AR_PERAWATAN,"select * from RFKONDISI where ACTIVE = '1'",false,conn);

				GlobalTools.fillRefList(ddl_AR_PRASARANAUMUM,"select * from RF_APPR_KELENGKAPAN where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AR_BKTYPE,"select * from RF_APPR_BUKTIKEPEMILIKAN where ACTIVE = '1' and TIPE = '1'",false,conn);

				GlobalTools.fillRefList(ddl_AR_LINGKUNGAN,"select * from RFLINGKUNGAN where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_Tujuan,"select * from RF_APPR_TUJUAN where ACTIVE = '1'",false,conn);

				GlobalTools.fillRefList(ddl_AR_MARKET,"select * from RF_APPR_MARKETABILITY where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AR_IKAT,"select * from RF_APPR_IKATSEMPURNA where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AR_MASALAH,"select * from RF_APPR_MASALAH where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AR_KUASA,"select * from RFPENGUASAAN where ACTIVE = '1'",false,conn);

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


		protected void ddl_AR_SWILAYAH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txt_Score.Text = Convert.ToString(HitungScore());
			txt_Score2.Text = txt_Score.Text;
		}

		protected void ddl_AR_SLOKASI_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txt_Score.Text = Convert.ToString(HitungScore());
			txt_Score2.Text = txt_Score.Text;
		}

		protected void ddl_AR_SBANGUNAN_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txt_Score.Text = Convert.ToString(HitungScore());
			txt_Score2.Text = txt_Score.Text;
		}

		protected void ddl_AR_SLINGKUNGAN_SelectedIndexChanged(object sender, System.EventArgs e)
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
			txt_AR_NMDEBITUR.Text = conn.GetFieldValue("CU_NAME");

			//------------------------------------------------------------------------------------------
			conn.QueryString = "select * from VW_APPR_RUSUN "+
				"where AP_REGNO = '"+ lbl_AP_REGNO.Text +"' and CU_REF  = '"+ lbl_CU_REF.Text +"' "+
				"and CL_SEQ  = "+ lbl_CL_SEQ.Text ;
			conn.ExecuteQuery();

			try
			{
				//=====================================================================
				txt_AR_LOKJLN.Text = conn.GetFieldValue("AR_LOKJLN");
				txt_AR_LOKDESA.Text = conn.GetFieldValue("AR_LOKDESA");
				txt_AR_LOKBLOK.Text = conn.GetFieldValue("AR_LOKBLOK");
				txt_AR_LOKKEC.Text = conn.GetFieldValue("AR_LOKKEC");
				txt_AR_LOKKAB.Text = conn.GetFieldValue("AR_LOKKAB");
				try {GlobalTools.fillDateForm(txt_AR_APPRDATE_DD,ddl_AR_APPRDATE_MM,txt_AR_APPRDATE_YY,Convert.ToDateTime(conn.GetFieldValue("AR_APPRDATE")));} catch {}
				txt_AR_APPRBY1.Text = conn.GetFieldValue("AR_APPRBY1");
				txt_AR_APPRBY2.Text = conn.GetFieldValue("AR_APPRBY2");

				//=====================================================================
				txt_AR_LUASBANGUN.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AR_LUASBANGUN"));
				txt_AR_THNBUAT.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AR_THNBUAT"));
				try{ddl_AR_ISNEW.SelectedValue = conn.GetFieldValue("AR_ISNEW");} catch{}
				txt_AR_PENGEMBANG.Text = conn.GetFieldValue("AR_PENGEMBANG");
				txt_AR_JALAN.Text = conn.GetFieldValue("AR_JALAN");
				txt_AR_KETJALAN.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AR_KETJALAN"));
				try{ddl_AR_LISTRIK.SelectedValue = conn.GetFieldValue("AR_LISTRIK");} catch{}
				txt_AR_KETLISTRIK.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AR_KETLISTRIK"));
				try{ddl_AR_TELPFAX.SelectedValue = conn.GetFieldValue("AR_TELPFAX");} catch{}
				txt_AR_KETTELPFAX.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AR_KETTELPFAX"));
				try{ddl_AR_AIR.SelectedValue = conn.GetFieldValue("AR_AIR");} catch{}
				try{ddl_AR_KETAIR.SelectedValue = conn.GetFieldValue("AR_KETAIR");} catch{}
				try{ddl_AR_AC.SelectedValue = conn.GetFieldValue("AR_AC");} catch{}
				txt_AR_KETAC.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AR_KETAC"));
				try{ddl_AR_PRASARANAUMUM.SelectedValue = conn.GetFieldValue("AR_PRASARANAUMUM");} catch{}
				try{ddl_AR_LOKASI.SelectedValue = conn.GetFieldValue("AR_LOKASI");} catch{}
				try{ddl_AR_KUALITAS.SelectedValue = conn.GetFieldValue("AR_KUALITAS");} catch{}
				txt_AR_WILAYAH.Text = conn.GetFieldValue("AR_WILAYAH");

				try{ddl_AR_LINGKUNGAN.SelectedValue = conn.GetFieldValue("AR_LINGKUNGAN");} catch{}
				try{ddl_AR_BANJIR.SelectedValue = conn.GetFieldValue("AR_BANJIR");} catch{}
				try{ddl_AR_TEGANGAN.SelectedValue = conn.GetFieldValue("AR_TEGANGAN");} catch{}
				try{ddl_AR_TNHLONGSOR.SelectedValue = conn.GetFieldValue("AR_TNHLONGSOR");} catch{}
				try{ddl_AR_PENCEMARAN.SelectedValue = conn.GetFieldValue("AR_PENCEMARAN");} catch{}
				txt_AR_KONDISI.Text = conn.GetFieldValue("AR_KONDISI");
				try{ddl_AR_PERAWATAN.SelectedValue = conn.GetFieldValue("AR_PERAWATAN");} catch{}

				try{ddl_AR_SWILAYAH.SelectedIndex = Convert.ToByte(conn.GetFieldValue("AR_SWILAYAH"));} catch{}
				try{ddl_AR_SLOKASI.SelectedIndex =  Convert.ToByte(conn.GetFieldValue("AR_SLOKASI"));} catch{}
				try{ddl_AR_SBANGUNAN.SelectedIndex = Convert.ToByte(conn.GetFieldValue("AR_SBANGUNAN"));} catch{}
				try{ddl_AR_SLINGKUNGAN.SelectedIndex = Convert.ToByte(conn.GetFieldValue("AR_SLINGKUNGAN"));} catch{}

				//=====================================================================
				try{ddl_AR_BKTYPE.SelectedValue = conn.GetFieldValue("AR_BKTYPE");} catch{}
				try{txt_AR_BKNO.Text = conn.GetFieldValue("AR_BKNO");} catch{}
				try {GlobalTools.fillDateForm(txt_AR_BKDATE_DD,ddl_AR_BKDATE_MM,txt_AR_BKDATE_YY,Convert.ToDateTime(conn.GetFieldValue("AR_BKDATE")));}	catch {}
				txt_AR_BKNAMA.Text = conn.GetFieldValue("AR_BKNAMA");
				txt_AR_BKAKTA.Text = conn.GetFieldValue("AR_BKAKTA");
				txt_AR_BKNOTARIS.Text = conn.GetFieldValue("AR_BKNOTARIS");

				//=====================================================================
				try{ddl_AR_IJTYPE.SelectedValue = conn.GetFieldValue("AR_IJTYPE");} catch{}
				txt_AR_IJNO.Text = conn.GetFieldValue("AR_IJNO");
				txt_AR_IJNOTARIS.Text = conn.GetFieldValue("AR_IJNOTARIS");
				txt_AR_IJPADA.Text = conn.GetFieldValue("AR_IJPADA");
				txt_AR_IJNILAI.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AR_IJNILAI"));

				//=====================================================================
				txt_AR_ABHASIL.Text = conn.GetFieldValue("AR_ABHASIL");
				try {GlobalTools.fillDateForm(txt_AR_ABDATE_DD,ddl_AR_ABDATE_MM,txt_AR_ABDATE_YY,Convert.ToDateTime(conn.GetFieldValue("AR_ABDATE")));}	catch {}
				txt_AR_ABKANTOR.Text = conn.GetFieldValue("AR_ABKANTOR");
				txt_AR_ABPEJABAT.Text = conn.GetFieldValue("AR_ABPEJABAT");

				//=====================================================================
				try{ddl_AR_IMBSTAT.SelectedValue = conn.GetFieldValue("AR_IMBSTAT");} catch{}
				txt_AR_IMBNO.Text = conn.GetFieldValue("AR_IMBNO");
				try {GlobalTools.fillDateForm(txt_AR_IMBDATE_DD,ddl_AR_IMBDATE_MM,txt_AR_IMBDATE_YY,Convert.ToDateTime(conn.GetFieldValue("AR_IMBDATE")));}	catch {}
                txt_AR_IMBDKELUARK.Text = conn.GetFieldValue("AR_IMBDKELUARK");

				//=====================================================================
				try{ddl_AR_INSRSTAT.SelectedValue = conn.GetFieldValue("AR_INSRSTAT");} catch{}
				txt_AR_INSRTUTUP.Text = conn.GetFieldValue("AR_INSRTUTUP");
				txt_AR_INSRAMOUNT.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AR_INSRAMOUNT"));
				try {GlobalTools.fillDateForm(txt_AR_INSRDATE_DD,ddl_AR_INSRDATE_MM,txt_AR_INSRDATE_YY,Convert.ToDateTime(conn.GetFieldValue("AR_INSRDATE")));}	catch {}
				txt_AR_INSRCOMP.Text = conn.GetFieldValue("AR_INSRCOMP");

				//=====================================================================
				txt_AR_DATA1.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AR_DATA1"));
				txt_AR_DATA2.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AR_DATA2"));
				txt_AR_DATA3.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AR_DATA3"));
				txt_AR_INFO1.Text = conn.GetFieldValue("AR_INFO1");
				txt_AR_INFO2.Text = conn.GetFieldValue("AR_INFO2");
				txt_AR_INFO3.Text = conn.GetFieldValue("AR_INFO3");
				txt_AR_SUMBERD1.Text= conn.GetFieldValue("AR_SUMBERD1");
				txt_AR_SUMBERD2.Text = conn.GetFieldValue("AR_SUMBERD2");
				txt_AR_SUMBERD3.Text = conn.GetFieldValue("AR_SUMBERD3");
				ddl_Tujuan.SelectedValue = conn.GetFieldValue("AR_TUJUAN");

				//=====================================================================
				try{ddl_AR_MARKET.SelectedValue = conn.GetFieldValue("AR_MARKET");} catch{}
				try{ddl_AR_IKAT.SelectedValue = conn.GetFieldValue("AR_IKAT");} catch{}
				try{ddl_AR_KUASA.SelectedValue = conn.GetFieldValue("AR_KUASA");} catch{}
				try{ddl_AR_MASALAH.SelectedValue = conn.GetFieldValue("AR_MASALAH");} catch{}
				txt_AR_LAIN.Text = conn.GetFieldValue("AR_LAIN");
				txt_AR_PENDAPAT.Text = conn.GetFieldValue("AR_PENDAPAT");
				lbl_UpdateStatus.Text = conn.GetFieldValue("UPDATESTAT");
			}
			catch {}	
		}


		protected void btn_Save_Click(object sender, System.EventArgs e)
		{
			if (ddl_AR_SWILAYAH.SelectedIndex == 0) ddl_AR_SWILAYAH.SelectedIndex = 1;

			if (ddl_AR_SLOKASI.SelectedIndex == 0) ddl_AR_SLOKASI.SelectedIndex = 1;
                	
			if (ddl_AR_SBANGUNAN.SelectedIndex == 0) ddl_AR_SBANGUNAN.SelectedIndex = 1;

			if (ddl_AR_SLINGKUNGAN.SelectedIndex == 0) ddl_AR_SLINGKUNGAN.SelectedIndex = 1;

			conn.QueryString = "SP_APPR_RUSUN 'Save','" + 
				lbl_AP_REGNO.Text + "','" + 
				lbl_CU_REF.Text + "'," + 
				lbl_CL_SEQ.Text + ",'" + 
				txt_AR_NMDEBITUR.Text + "','" +
				txt_AR_APPRBY1.Text + "','" + 
				txt_AR_APPRBY2.Text + "'," +
				GlobalTools.ToSQLDate(txt_AR_APPRDATE_DD.Text, ddl_AR_APPRDATE_MM.SelectedValue, txt_AR_APPRDATE_YY.Text) + ",'" +
				txt_AR_LOKJLN.Text + "','" + 
				txt_AR_LOKBLOK.Text + "','" + 
				txt_AR_LOKDESA.Text + "','" +
				txt_AR_LOKKEC.Text + "','" + 
				txt_AR_LOKKAB.Text + "'," + 
				GlobalTools.ConvertNull(txt_AR_LUASBANGUN.Text) + "," +
				GlobalTools.ConvertNull(txt_AR_THNBUAT.Text) + ",'" + 
				ddl_AR_ISNEW.SelectedValue + "','" +  
				txt_AR_PENGEMBANG.Text + "','" +
				txt_AR_JALAN.Text + "'," + 
				GlobalTools.ConvertFloat(txt_AR_KETJALAN.Text) + ",'" + 
				ddl_AR_LISTRIK.SelectedValue + "'," +
				txt_AR_KETLISTRIK.Text + ",'" + 
				ddl_AR_TELPFAX.SelectedValue + "'," + 
				txt_AR_KETTELPFAX.Text + ",'" +
				ddl_AR_AIR.SelectedValue + "','" + 
				ddl_AR_KETAIR.SelectedValue + "','" + 
				ddl_AR_AC.SelectedValue + "'," +
				txt_AR_KETAC.Text + ",'" + 
				ddl_AR_PRASARANAUMUM.SelectedValue + "','" + 
				ddl_AR_LOKASI.SelectedValue + "','" +
				ddl_AR_KUALITAS.SelectedValue + "','" + 
				txt_AR_WILAYAH.Text + "','" + 
				ddl_AR_LINGKUNGAN.SelectedValue + "','" +
				ddl_AR_BANJIR.SelectedValue + "','" + 
				ddl_AR_TEGANGAN.SelectedValue + "','" + 
				ddl_AR_TNHLONGSOR.SelectedValue + "','" +
				ddl_AR_PENCEMARAN.SelectedValue + "','" + 
				txt_AR_KONDISI.Text + "','" + 
				ddl_AR_PERAWATAN.SelectedValue + "'," +
				ddl_AR_SWILAYAH.SelectedItem + "," + 
				ddl_AR_SLOKASI.SelectedItem + "," + 
				ddl_AR_SBANGUNAN.SelectedItem + "," +
				ddl_AR_SLINGKUNGAN.SelectedItem + ",'" + 
				ddl_AR_BKTYPE.SelectedValue + "','" + 
				txt_AR_BKNO.Text + "'," +
				GlobalTools.ToSQLDate(txt_AR_BKDATE_DD.Text, ddl_AR_BKDATE_MM.SelectedValue, txt_AR_BKDATE_YY.Text) + ",'" +
				txt_AR_BKNAMA.Text + "','" + 
				txt_AR_BKAKTA.Text + "','" + 
				txt_AR_BKNOTARIS.Text + "','" +
				ddl_AR_IJTYPE.SelectedValue + "','" + 
				txt_AR_IJNO.Text + "'," + 
				GlobalTools.ConvertNull(txt_AR_IJNILAI.Text) + ",'" +
				txt_AR_IJNOTARIS.Text + "','" + 
				txt_AR_IJPADA.Text + "','" + 
				txt_AR_ABHASIL.Text + "'," +
				GlobalTools.ToSQLDate(txt_AR_ABDATE_DD.Text, ddl_AR_ABDATE_MM.SelectedValue, txt_AR_ABDATE_YY.Text) + ",'" +
				txt_AR_ABKANTOR.Text + "','" + 
				txt_AR_ABPEJABAT.Text + "','" + 
				ddl_AR_IMBSTAT.SelectedValue + "','" + 
				txt_AR_IMBNO.Text + "'," +
				GlobalTools.ToSQLDate(txt_AR_IMBDATE_DD.Text, ddl_AR_IMBDATE_MM.SelectedValue, txt_AR_IMBDATE_YY.Text) + ",'" +
				txt_AR_IMBDKELUARK.Text + "','" + 
				ddl_AR_INSRSTAT.SelectedValue + "','" +
				txt_AR_INSRTUTUP.Text + "'," + 
				GlobalTools.ConvertNull(txt_AR_INSRAMOUNT.Text) + "," +
				GlobalTools.ToSQLDate(txt_AR_INSRDATE_DD.Text, ddl_AR_INSRDATE_MM.SelectedValue, txt_AR_INSRDATE_YY.Text) + ",'" + 
				txt_AR_INSRCOMP.Text + "'," + 
				GlobalTools.ConvertNull(txt_AR_DATA1.Text) + "," + 
				GlobalTools.ConvertNull(txt_AR_DATA2.Text) + "," +
				GlobalTools.ConvertNull(txt_AR_DATA3.Text) + ",'" + 
				txt_AR_INFO1.Text + "','" + 
				txt_AR_INFO2.Text + "','" + 
				txt_AR_INFO3.Text + "','" + 
				txt_AR_SUMBERD1.Text + "','" + 
				txt_AR_SUMBERD2.Text + "','" +
				txt_AR_SUMBERD3.Text + "','" + 
				ddl_Tujuan.SelectedValue + "','" +
				ddl_AR_MARKET.SelectedValue + "','" + 
				ddl_AR_IKAT.SelectedValue + "','" +
				ddl_AR_MASALAH.SelectedValue + "','" + 
				ddl_AR_KUASA.SelectedValue + "','" + 
				txt_AR_LAIN.Text + "','" +
				txt_AR_PENDAPAT.Text + "','';";
//			try
//			{
				conn.ExecuteNonQuery();

				//-----------------------------------------------------------------simpan ke APPR_LIST
				conn.QueryString = "EXEC SP_APPR_LIST 'Save','" + lbl_AP_REGNO.Text + "','" + lbl_CU_REF.Text + "','" + 
					lbl_CL_SEQ.Text + "','5','RUSUN'";
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

				conn.QueryString = "SP_APPR_RUSUN 'Save','" + 
					lbl_AP_REGNO.Text + "','" + 
					lbl_CU_REF.Text + "'," + 
					lbl_CL_SEQ.Text + ",'" + 
					txt_AR_NMDEBITUR.Text + "','" +
					txt_AR_APPRBY1.Text + "','" + 
					txt_AR_APPRBY2.Text + "'," +
					GlobalTools.ToSQLDate(txt_AR_APPRDATE_DD.Text, ddl_AR_APPRDATE_MM.SelectedValue, txt_AR_APPRDATE_YY.Text) + ",'" +
					txt_AR_LOKJLN.Text + "','" + 
					txt_AR_LOKBLOK.Text + "','" + 
					txt_AR_LOKDESA.Text + "','" +
					txt_AR_LOKKEC.Text + "','" + 
					txt_AR_LOKKAB.Text + "'," + 
					GlobalTools.ConvertNull(txt_AR_LUASBANGUN.Text) + "," +
					GlobalTools.ConvertNull(txt_AR_THNBUAT.Text) + ",'" + 
					ddl_AR_ISNEW.SelectedValue + "','" +  
					txt_AR_PENGEMBANG.Text + "','" +
					txt_AR_JALAN.Text + "'," + 
					GlobalTools.ConvertFloat(txt_AR_KETJALAN.Text) + ",'" + 
					ddl_AR_LISTRIK.SelectedValue + "'," +
					txt_AR_KETLISTRIK.Text + ",'" + 
					ddl_AR_TELPFAX.SelectedValue + "'," + 
					txt_AR_KETTELPFAX.Text + ",'" +
					ddl_AR_AIR.SelectedValue + "','" + 
					ddl_AR_KETAIR.SelectedValue + "','" + 
					ddl_AR_AC.SelectedValue + "'," +
					txt_AR_KETAC.Text + ",'" + 
					ddl_AR_PRASARANAUMUM.SelectedValue + "','" + 
					ddl_AR_LOKASI.SelectedValue + "','" +
					ddl_AR_KUALITAS.SelectedValue + "','" + 
					txt_AR_WILAYAH.Text + "','" + 
					ddl_AR_LINGKUNGAN.SelectedValue + "','" +
					ddl_AR_BANJIR.SelectedValue + "','" + 
					ddl_AR_TEGANGAN.SelectedValue + "','" + 
					ddl_AR_TNHLONGSOR.SelectedValue + "','" +
					ddl_AR_PENCEMARAN.SelectedValue + "','" + 
					txt_AR_KONDISI.Text + "','" + 
					ddl_AR_PERAWATAN.SelectedValue + "'," +
					ddl_AR_SWILAYAH.SelectedItem + "," + 
					ddl_AR_SLOKASI.SelectedItem + "," + 
					ddl_AR_SBANGUNAN.SelectedItem + "," +
					ddl_AR_SLINGKUNGAN.SelectedItem + ",'" + 
					ddl_AR_BKTYPE.SelectedValue + "','" + 
					txt_AR_BKNO.Text + "'," +
					GlobalTools.ToSQLDate(txt_AR_BKDATE_DD.Text, ddl_AR_BKDATE_MM.SelectedValue, txt_AR_BKDATE_YY.Text) + ",'" +
					txt_AR_BKNAMA.Text + "','" + 
					txt_AR_BKAKTA.Text + "','" + 
					txt_AR_BKNOTARIS.Text + "','" +
					ddl_AR_IJTYPE.SelectedValue + "','" + 
					txt_AR_IJNO.Text + "'," + 
					GlobalTools.ConvertNull(txt_AR_IJNILAI.Text) + ",'" +
					txt_AR_IJNOTARIS.Text + "','" + 
					txt_AR_IJPADA.Text + "','" + 
					txt_AR_ABHASIL.Text + "'," +
					GlobalTools.ToSQLDate(txt_AR_ABDATE_DD.Text, ddl_AR_ABDATE_MM.SelectedValue, txt_AR_ABDATE_YY.Text) + ",'" +
					txt_AR_ABKANTOR.Text + "','" + 
					txt_AR_ABPEJABAT.Text + "','" + 
					ddl_AR_IMBSTAT.SelectedValue + "','" + 
					txt_AR_IMBNO.Text + "'," +
					GlobalTools.ToSQLDate(txt_AR_IMBDATE_DD.Text, ddl_AR_IMBDATE_MM.SelectedValue, txt_AR_IMBDATE_YY.Text) + ",'" +
					txt_AR_IMBDKELUARK.Text + "','" + 
					ddl_AR_INSRSTAT.SelectedValue + "','" +
					txt_AR_INSRTUTUP.Text + "'," + 
					GlobalTools.ConvertNull(txt_AR_INSRAMOUNT.Text) + "," +
					GlobalTools.ToSQLDate(txt_AR_INSRDATE_DD.Text, ddl_AR_INSRDATE_MM.SelectedValue, txt_AR_INSRDATE_YY.Text) + ",'" + 
					txt_AR_INSRCOMP.Text + "'," + 
					GlobalTools.ConvertNull(txt_AR_DATA1.Text) + "," + 
					GlobalTools.ConvertNull(txt_AR_DATA2.Text) + "," +
					GlobalTools.ConvertNull(txt_AR_DATA3.Text) + ",'" + 
					txt_AR_INFO1.Text + "','" + 
					txt_AR_INFO2.Text + "','" + 
					txt_AR_INFO3.Text + "','" + 
					txt_AR_SUMBERD1.Text + "','" + 
					txt_AR_SUMBERD2.Text + "','" +
					txt_AR_SUMBERD3.Text + "','" + 
					ddl_Tujuan.SelectedValue + "','" +
					ddl_AR_MARKET.SelectedValue + "','" + 
					ddl_AR_IKAT.SelectedValue + "','" +
					ddl_AR_MASALAH.SelectedValue + "','" + 
					ddl_AR_KUASA.SelectedValue + "','" + 
					txt_AR_LAIN.Text + "','" +
					txt_AR_PENDAPAT.Text + "','1';";
//				try
//				{
					conn.ExecuteNonQuery();

					//-----------------------------------------------------------------simpan ke APPR_LIST
					conn.QueryString = "EXEC SP_APPR_LIST 'Save','" + lbl_AP_REGNO.Text + "','" + lbl_CU_REF.Text + "','" + 
						lbl_CL_SEQ.Text + "','5','RUSUN'";
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
						LA_APPRSTATUS.ToString()+"', "+ GlobalTools.ConvertFloat(txt_AR_HRGPASAR.Text)+", "+
						GlobalTools.ConvertFloat(txt_AR_HRGWAJAR.Text)+", '" +TABLENAME.Trim()+ "', '"+mStat.ToString().Trim()+"'";
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

			txt_AR_WILAYAH.Text = ddl_AR_SWILAYAH.SelectedValue.ToString();
			txt_AR_JALAN.Text = ddl_AR_SLOKASI.SelectedValue.ToString();
			txt_AR_KONDISI.Text = ddl_AR_SBANGUNAN.SelectedValue.ToString();
			
			//hitung: score
			try {nWilayah = Convert.ToByte(ddl_AR_SWILAYAH.SelectedItem.Text);}
			catch {nWilayah = 0;}

			try {nLokasi = Convert.ToByte(ddl_AR_SLOKASI.SelectedItem.Text);}
			catch {nLokasi = 0;}

			try {nBangunan = Convert.ToByte(ddl_AR_SBANGUNAN.SelectedItem.Text);}
			catch {nBangunan = 0;}

			try {nLingkungan = Convert.ToByte(ddl_AR_SLINGKUNGAN.SelectedItem.Text);}
			catch {nLingkungan = 0;}

			nHasil = nWilayah + nLokasi + nBangunan + nLingkungan;
			Score =  nHasil;

			return nHasil;
		}

		private void Kalkulasi()
		{
			double HargaPasar, SafetyMargin;
			double Score = HitungScore();

			//hitung: harga pasar keseluruhan
			HargaPasar = Convert.ToDouble(txt_AR_DATA1.Text) * 0.30 + 
				Convert.ToDouble(txt_AR_DATA2.Text) * 0.30 + 
				Convert.ToDouble(txt_AR_DATA3.Text) * 0.40;
			txt_AR_HRGPASAR.Text = GlobalTools.MoneyFormat(HargaPasar.ToString());

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


			if (ddl_Tujuan.SelectedItem.ToString() == "Penebusan Agunan")
				SafetyMargin = 0;

			if (ddl_AR_ISNEW.SelectedIndex == 0)
				SafetyMargin = 0;

			txt_AR_SFTYMARGIN.Text = Strings.Format(SafetyMargin,"0.0%");


			//hitung: nilai pasar yang dapat di terima bank
			txt_AR_HRGWAJAR.Text =  GlobalTools.MoneyFormat(Convert.ToString(HargaPasar * (1 - SafetyMargin)));
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
			if (txt_AR_LOKJLN.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Jalan harus diisi');</script>");
				return false;
			}
			if (txt_AR_LOKBLOK.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Blok atau Lantai harus diisi');</script>");
				return false;
			}
			else if (txt_AR_LOKDESA.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Kelurahan harus diisi');</script>");
				return false;
			}
			else if (txt_AR_LOKKEC.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Kecamatan harus diisi');</script>");
				return false;
			}
			else if (txt_AR_LOKKAB.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Kota Madya harus diisi');</script>");
				return false;
			}
			else if (txt_AR_APPRBY1.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Penilai 1 harus diisi');</script>");
				return false;
			}
			else if (txt_AR_APPRDATE_YY.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Tanggal Periksa harus diisi');</script>");
				return false;
			}
			else if (txt_AR_LUASBANGUN.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Luas Bangunan harus diisi');</script>");
				return false;
			}
			else if (txt_AR_THNBUAT.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Tahun Pembuatan harus diisi');</script>");
				return false;
			}
			else if (txt_AR_KETJALAN.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Panjang Jalan harus diisi');</script>");
				return false;
			}
			else if (ddl_AR_SWILAYAH.SelectedValue == "0")
			{
				Response.Write("<script language='javascript'>alert('Wilayah harus dipilih');</script>");
				return false;
			}
			else if (ddl_AR_SLOKASI.SelectedValue == "0")
			{
				Response.Write("<script language='javascript'>alert('Lokasi harus dipilih');</script>");
				return false;
			}
			else if (ddl_AR_SBANGUNAN.SelectedValue == "0")
			{
				Response.Write("<script language='javascript'>alert('Bangunan harus dipilih');</script>");
				return false;
			}
			else if (ddl_AR_SLINGKUNGAN.SelectedValue == "0")
			{
				Response.Write("<script language='javascript'>alert('Lingkungan harus dipilih');</script>");
				return false;
			}
			else if (txt_AR_DATA1.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Data I harus diisi');</script>");
				return false;
			}
			else if (txt_AR_DATA2.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Data II harus diisi');</script>");
				return false;
			}
			else if (txt_AR_DATA3.Text == "")
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
			txt_AR_LOKJLN.ReadOnly = true;
			txt_AR_LOKDESA.ReadOnly = true;
			txt_AR_LOKBLOK.ReadOnly = true;
			txt_AR_LOKKEC.ReadOnly = true;
			txt_AR_LOKKAB.ReadOnly = true;
			txt_AR_APPRDATE_DD.ReadOnly = true;
			ddl_AR_APPRDATE_MM.Enabled = false;
			txt_AR_APPRDATE_YY.ReadOnly = true;
			txt_AR_APPRBY1.ReadOnly = true;
			txt_AR_APPRBY2.ReadOnly = true;
			txt_AR_LUASBANGUN.ReadOnly = true;
			txt_AR_THNBUAT.ReadOnly = true;
			ddl_AR_ISNEW.Enabled = false;
			txt_AR_PENGEMBANG.ReadOnly = true;
			txt_AR_JALAN.ReadOnly = true;
			txt_AR_KETJALAN.ReadOnly = true;
			ddl_AR_LISTRIK.Enabled = false;
			txt_AR_KETLISTRIK.ReadOnly = true;
			ddl_AR_TELPFAX.Enabled = false;
			txt_AR_KETTELPFAX.ReadOnly = true;
			ddl_AR_AIR.Enabled = false;
			ddl_AR_KETAIR.Enabled = false;
			ddl_AR_AC.Enabled = false;
			txt_AR_KETAC.ReadOnly = true;
			ddl_AR_PRASARANAUMUM.Enabled = false;
			ddl_AR_LOKASI.Enabled = false;
			ddl_AR_KUALITAS.Enabled = false;
			txt_AR_WILAYAH.ReadOnly = true;
			ddl_AR_LINGKUNGAN.Enabled = false;
			ddl_AR_BANJIR.Enabled = false;
			ddl_AR_TEGANGAN.Enabled = false;
			ddl_AR_TNHLONGSOR.Enabled = false;
			ddl_AR_PENCEMARAN.Enabled = false;
			txt_AR_KONDISI.ReadOnly = true;
			ddl_AR_PERAWATAN.Enabled = false;
			ddl_AR_SWILAYAH.Enabled = false;
			ddl_AR_SLOKASI.Enabled = false;
			ddl_AR_SBANGUNAN.Enabled = false;
			ddl_AR_SLINGKUNGAN.Enabled = false;
			ddl_AR_BKTYPE.Enabled = false;
			txt_AR_BKNO.ReadOnly = true;
			txt_AR_BKDATE_DD.ReadOnly = true;
			ddl_AR_BKDATE_MM.Enabled = false;
			txt_AR_BKDATE_YY.ReadOnly = true;
			txt_AR_BKNAMA.ReadOnly = true;
			txt_AR_BKAKTA.ReadOnly = true;
			txt_AR_BKNOTARIS.ReadOnly = true;
			ddl_AR_IJTYPE.Enabled = false;
			txt_AR_IJNO.ReadOnly = true;
			txt_AR_IJNOTARIS.ReadOnly = true;
			txt_AR_IJPADA.ReadOnly = true;
			txt_AR_IJNILAI.ReadOnly = true;
			txt_AR_ABHASIL.ReadOnly = true;
			txt_AR_ABDATE_DD.ReadOnly = true;
			ddl_AR_ABDATE_MM.Enabled = false;
			txt_AR_ABDATE_YY.ReadOnly = true;
			txt_AR_ABKANTOR.ReadOnly = true;
			txt_AR_ABPEJABAT.ReadOnly = true;
			ddl_AR_IMBSTAT.Enabled = false;
			txt_AR_IMBNO.ReadOnly = true;
			txt_AR_IMBDATE_DD.ReadOnly = true;
			ddl_AR_IMBDATE_MM.Enabled = false;
			txt_AR_IMBDATE_YY.ReadOnly = true;
			txt_AR_IMBDKELUARK.ReadOnly = true;
			ddl_AR_INSRSTAT.Enabled = false;
			txt_AR_INSRAMOUNT.ReadOnly = true;
			txt_AR_INSRDATE_DD.ReadOnly = true;
			ddl_AR_INSRDATE_MM.Enabled = false;
			txt_AR_INSRDATE_YY.ReadOnly = true;
			txt_AR_INSRCOMP.ReadOnly = true;
			txt_AR_DATA1.ReadOnly = true;
			txt_AR_DATA2.ReadOnly = true;
			txt_AR_DATA3.ReadOnly = true;
			txt_AR_INFO1.ReadOnly = true;
			txt_AR_INFO2.ReadOnly = true;
			txt_AR_INFO3.ReadOnly = true;
			txt_AR_SUMBERD1.ReadOnly = true;
			txt_AR_SUMBERD2.ReadOnly = true;
			txt_AR_SUMBERD3.ReadOnly = true;
			ddl_Tujuan.Enabled = false;
			ddl_AR_MARKET.Enabled = false;
			ddl_AR_IKAT.Enabled = false;
			ddl_AR_KUASA.Enabled = false;
			ddl_AR_MASALAH.Enabled = false;
			txt_AR_LAIN.ReadOnly = true;
			txt_AR_PENDAPAT.ReadOnly = true;
		
			btn_Calc.Visible = false;
		}

		private void EnableUpdate()
		{
			double AR_HRGPASAR = 0, AR_HRGWAJAR = 0, AR_SFTYMARGIN = 0;

			try {AR_HRGPASAR = double.Parse(GlobalTools.ConvertFloat(txt_AR_HRGPASAR.Text));}
			catch {}
			try {AR_HRGWAJAR = double.Parse(GlobalTools.ConvertFloat(txt_AR_HRGWAJAR.Text));}
			catch {}
			try {AR_SFTYMARGIN = double.Parse(GlobalTools.ConvertFloat(txt_AR_SFTYMARGIN.Text));}
			catch {}


			if ( (AR_HRGPASAR > 0) && (AR_HRGWAJAR > 0) && (AR_SFTYMARGIN >= 0) )
				btn_UpdateStatus.Enabled = true;
			else
				btn_UpdateStatus.Enabled = false;
		}

		protected void btn_Delete_Click(object sender, System.EventArgs e)
		{
			//-----------------------------------------------------------------hapus dari APPR_RUSUN
			conn.QueryString = "SP_APPR_RUSUN 'Delete','" + 
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
