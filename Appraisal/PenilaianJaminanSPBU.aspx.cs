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
	/// Summary description for PenilaianJaminanSPBU.
	/// </summary>
	public partial class PenilaianJaminanSPBU : System.Web.UI.Page
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

				GlobalTools.initDateFormINA(txt_AS_ABDATE_dd,ddl_AS_ABDATE_mm,txt_AS_ABDATE_yy);
				GlobalTools.initDateFormINA(txt_AS_APPRDATE_dd,ddl_AS_APPRDATE_mm,txt_AS_APPRDATE_yy);
				GlobalTools.initDateFormINA(txt_AS_APPRDATE_dd,ddl_AS_BKDATE_mm,txt_AS_BKDATE_yy);
				GlobalTools.initDateFormINA(txt_AS_IMBDATE_dd,ddl_AS_IMBDATE_mm,txt_AS_IMBDATE_yy);
				GlobalTools.initDateFormINA(txt_AS_PSDATE_dd,ddl_AS_PSDATE_mm,txt_AS_PSDATE_yy);
				GlobalTools.initDateFormINA(txt_AS_INSRDATE_dd,ddl_AS_INSRDATE_mm,txt_AS_INSRDATE_yy);

				GlobalTools.fillRefList(ddl_AS_JALAN,"select * from RF_APPR_JALAN where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AS_PERAWATAN,"select * from RFKONDISI where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AS_LINGKUNGAN,"select * from RFLINGKUNGAN where active = '1'",false,conn);

				GlobalTools.fillRefList(ddl_AS_BKTYPE,"select * from RF_APPR_BUKTIKEPEMILIKAN where active = '1' and TIPE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_Tujuan,"select * from RF_APPR_TUJUAN where active = '1'",false,conn);

				GlobalTools.fillRefList(ddl_AS_MARKET,"select * from RF_APPR_MARKETABILITY where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AS_IKAT,"select * from RF_APPR_IKATSEMPURNA where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AS_MASALAH,"select * from RF_APPR_MASALAH where active = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AS_KUASA,"select * from RFPENGUASAAN where active = '1'",false,conn);

				ViewData();
				txt_Score.Text = Convert.ToString(HitungScore());
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
		

		protected void ddl_AS_SWILAYAH_SelectedIndexChanged(object sender, System.EventArgs e)
		{	
			txt_Score.Text = Convert.ToString(HitungScore());
		}

		protected void ddl_AS_SLOKASI_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txt_Score.Text = Convert.ToString(HitungScore());
		}

		protected void ddl_AS_SFREK_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txt_Score.Text = Convert.ToString(HitungScore());
		}

		protected void ddl_AS_SKONDISI_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txt_Score.Text = Convert.ToString(HitungScore());
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
			txt_AS_NMDEBITUR.Text = conn.GetFieldValue("CU_NAME");

			//------------------------------------------------------------------------------------------

			conn.QueryString = "select * from VW_APPR_SPBU "+
				"where AP_REGNO = '"+ lbl_AP_REGNO.Text +"' and CU_REF  = '"+ lbl_CU_REF.Text +"' "+
				"and CL_SEQ  = "+ lbl_CL_SEQ.Text ;
			conn.ExecuteQuery();

			try
			{
				//=====================================================================
				txt_AS_LOKJLN.Text = conn.GetFieldValue("AS_LOKJLN");
				txt_AS_LOKDESA.Text = conn.GetFieldValue("AS_LOKDESA");
				txt_AS_LOKKEC.Text = conn.GetFieldValue("AS_LOKKEC");
				txt_AS_LOKKAB.Text = conn.GetFieldValue("AS_LOKKAB");
				try {GlobalTools.fillDateForm(txt_AS_APPRDATE_dd,ddl_AS_APPRDATE_mm,txt_AS_APPRDATE_yy,Convert.ToDateTime(conn.GetFieldValue("AS_APPRDATE")));}
				catch {}
				txt_AS_APPRBY1.Text = conn.GetFieldValue("AS_APPRBY1");
				txt_AS_APPRBY2.Text = conn.GetFieldValue("AS_APPRBY2");

				//=====================================================================
				txt_AS_LUASTNH.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AS_LUASTNH"));
				try{ddl_AS_JALAN.SelectedValue = conn.GetFieldValue("AS_JALAN");}
				catch{}
				txt_AS_KETJALAN.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AS_KETJALAN"));
				txt_AS_JNSJALAN.Text = conn.GetFieldValue("AS_JNSJALAN");
				try{ddl_AS_LISTRIK.SelectedValue = conn.GetFieldValue("AS_LISTRIK");}
				catch{}
				txt_AS_KETLISTRIK.Text= GlobalTools.ConvertFloat(conn.GetFieldValue("AS_KETLISTRIK"));
				try{ddl_AS_TELP.SelectedValue = conn.GetFieldValue("AS_TELP");}
				catch{}
				txt_AS_KETTELP.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AS_KETTELP"));
				try{ddl_AS_PAM.SelectedValue = conn.GetFieldValue("AS_PAM");}
				catch{}
				txt_AS_FREKKDRN.Text = conn.GetFieldValue("AS_FREKKDRN");
				txt_AS_KONDISI.Text = conn.GetFieldValue("AS_KONDISI");
				try{ddl_AS_PERAWATAN.SelectedValue = conn.GetFieldValue("AS_PERAWATAN");}
				catch{}
				txt_AS_WILAYAH.Text = conn.GetFieldValue("AS_WILAYAH");
	
				try{ddl_AS_LINGKUNGAN.SelectedValue = conn.GetFieldValue("AS_LINGKUNGAN");}
				catch{}
				try{ddl_AS_BANJIR.SelectedValue = conn.GetFieldValue("AS_BANJIR");}
				catch{}
				try{ddl_AS_TEGANGAN.SelectedValue = conn.GetFieldValue("AS_TEGANGAN");}
				catch{}
				try{ddl_AS_LONGSOR.SelectedValue = conn.GetFieldValue("AS_LONGSOR");}
				catch{}
				try{ddl_AS_POLUSI.SelectedValue = conn.GetFieldValue("AS_POLUSI");}
				catch{}

				try{ddl_AS_SWILAYAH.SelectedIndex = Convert.ToByte(conn.GetFieldValue("AS_SWILAYAH"));}
				catch{}
				try{ddl_AS_SLOKASI.SelectedIndex = Convert.ToByte(conn.GetFieldValue("AS_SLOKASI"));}
				catch{}
				try{ddl_AS_SFREK.SelectedIndex = Convert.ToByte(conn.GetFieldValue("AS_SFREK"));}
				catch{}
				try{ddl_AS_SKONDISI.SelectedIndex = Convert.ToByte(conn.GetFieldValue("AS_SKONDISI"));}
				catch{}

				//=====================================================================
				try{ddl_AS_BKTYPE.SelectedValue = conn.GetFieldValue("AS_BKTYPE");}
				catch{}
				txt_AS_BKNO.Text = conn.GetFieldValue("AS_BKNO");
				try {GlobalTools.fillDateForm(txt_AS_BKDATE_dd,ddl_AS_BKDATE_mm,txt_AS_BKDATE_yy,Convert.ToDateTime(conn.GetFieldValue("AS_BKDATE")));}
				catch {}
				txt_AS_BKNAMA.Text = conn.GetFieldValue("AS_BKNAMA");
				txt_AS_BKAKTA.Text = conn.GetFieldValue("AS_BKAKTA");
				txt_AS_BKNOTARIS.Text = conn.GetFieldValue("AS_BKNOTARIS");

				//=====================================================================
				try{ddl_AS_IJTYPE.SelectedValue = conn.GetFieldValue("AS_IJTYPE");}
				catch{}
				txt_AS_IJNO.Text = conn.GetFieldValue("AS_IJNO");
				txt_AS_IJSERTIFIKAT.Text = conn.GetFieldValue("AS_IJSERTIFIKAT");
				txt_AS_IJNOTARIS.Text = conn.GetFieldValue("AS_IJNOTARIS");
				txt_AS_IJPADA.Text = conn.GetFieldValue("AS_IJPADA");
				txt_AS_IJNILAI.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AS_IJNILAI"));

				//=====================================================================
				txt_AS_ABHASIL.Text = conn.GetFieldValue("AS_ABHASIL");
				try {GlobalTools.fillDateForm(txt_AS_ABDATE_dd,ddl_AS_ABDATE_mm,txt_AS_ABDATE_yy,Convert.ToDateTime(conn.GetFieldValue("AS_ABDATE")));}
				catch {}
				txt_AS_ABKANTOR.Text = conn.GetFieldValue("AS_ABKANTOR");
				txt_AS_ABPEJABAT.Text = conn.GetFieldValue("AS_ABPEJABAT");

				//=====================================================================
				try{ddl_AS_PSSTAT.SelectedValue = conn.GetFieldValue("AS_PSSTAT");}
				catch{}
				txt_AS_PSNO.Text = conn.GetFieldValue("AS_PSNO");
				txt_AS_PSNAMA.Text = conn.GetFieldValue("AS_PSNAMA");
				try {GlobalTools.fillDateForm(txt_AS_PSDATE_dd,ddl_AS_PSDATE_mm,txt_AS_PSDATE_yy,Convert.ToDateTime(conn.GetFieldValue("AS_PSDATE")));}
				catch {}

				//=====================================================================
				try{ddl_AS_IMBSTAT.SelectedValue = conn.GetFieldValue("AS_IMBSTAT");}
				catch{}
				txt_AS_IMBNO.Text = conn.GetFieldValue("AS_IMBNO");
				try {GlobalTools.fillDateForm(txt_AS_IMBDATE_dd,ddl_AS_IMBDATE_mm,txt_AS_IMBDATE_yy,Convert.ToDateTime(conn.GetFieldValue("AS_IMBDATE")));}
				catch {}
				txt_AS_IMBDKELUARK.Text = conn.GetFieldValue("AS_IMBDKELUARK");

				//=====================================================================
				try{ddl_AS_INSRSTAT.SelectedValue = conn.GetFieldValue("AS_INSRSTAT");}
				catch{}
				txt_AS_INSRTUTUP.Text = conn.GetFieldValue("AS_INSRTUTUP");
				txt_AS_INSRNILAI.Text = conn.GetFieldValue("AS_INSRNILAI");
				try {GlobalTools.fillDateForm(txt_AS_INSRDATE_dd,ddl_AS_INSRDATE_mm,txt_AS_INSRDATE_yy,Convert.ToDateTime(conn.GetFieldValue("AS_INSRDATE")));}
				catch {}
				txt_AS_INSRCOMP.Text = conn.GetFieldValue("AS_INSRCOMP");			

				//=====================================================================
				txt_AS_DATA1.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AS_DATA1"));
				txt_AS_DATA2.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AS_DATA2"));

				try{ddl_Tujuan.SelectedValue = conn.GetFieldValue("AS_TUJUAN");}
				catch{}
				
				//=====================================================================
				try{ddl_AS_MARKET.SelectedValue = conn.GetFieldValue("AS_MARKET");}
				catch{}
				try{ddl_AS_IKAT.SelectedValue = conn.GetFieldValue("AS_IKAT");}
				catch{}
				try{ddl_AS_KUASA.SelectedValue = conn.GetFieldValue("AS_KUASA");}
				catch{}
				try{ddl_AS_MASALAH.SelectedValue = conn.GetFieldValue("AS_MASALAH");}
				catch{}
				txt_AS_LAIN.Text = conn.GetFieldValue("AS_LAIN");
				lbl_UpdateStatus.Text = conn.GetFieldValue("UPDATESTAT");
			}
			catch {}
		}


		protected void btn_Save_Click(object sender, System.EventArgs e)
		{
			if (ddl_AS_SWILAYAH.SelectedIndex == 0) ddl_AS_SWILAYAH.SelectedIndex = 1;

			if (ddl_AS_SLOKASI.SelectedIndex == 0) ddl_AS_SLOKASI.SelectedIndex = 1;
		        
			if (ddl_AS_SFREK.SelectedIndex == 0) ddl_AS_SFREK.SelectedIndex = 1;

			if (ddl_AS_SKONDISI.SelectedIndex == 0) ddl_AS_SKONDISI.SelectedIndex = 1;

			conn.QueryString = "SP_APPR_SPBU 'Save','" + lbl_AP_REGNO.Text + "','" + lbl_CU_REF.Text + "'," + 
				lbl_CL_SEQ.Text + ",'" + 
				txt_AS_NMDEBITUR.Text + "','" + 
				txt_AS_APPRBY1.Text + "','" + 
				txt_AS_APPRBY2.Text + "'," +
				GlobalTools.ToSQLDate(txt_AS_APPRDATE_dd.Text, ddl_AS_APPRDATE_mm.SelectedValue, txt_AS_APPRDATE_yy.Text) + ",'" +
				txt_AS_LOKJLN.Text + "','" + 
				txt_AS_LOKDESA.Text + "','" + 
				txt_AS_LOKKEC.Text + "','" + 
				txt_AS_LOKKAB.Text + "'," + 
				GlobalTools.ConvertNull(txt_AS_LUASTNH.Text) + ",'" + 
				ddl_AS_JALAN.SelectedValue + "'," +
				GlobalTools.ConvertNull(txt_AS_KETJALAN.Text) + ",'" + 
				txt_AS_JNSJALAN.Text + "','" + 
				ddl_AS_LISTRIK.SelectedValue + "'," +
				txt_AS_KETLISTRIK.Text + ",'" + 
				ddl_AS_TELP.SelectedValue + "'," + 
				txt_AS_KETTELP.Text + ",'" +
				ddl_AS_PAM.SelectedValue + "','" + 
				txt_AS_FREKKDRN.Text + "','" + 
				txt_AS_KONDISI.Text + "','" +
				ddl_AS_PERAWATAN.SelectedValue + "','" + 
				txt_AS_WILAYAH.Text + "','" + 
				ddl_AS_LINGKUNGAN.SelectedValue + "','" +
				ddl_AS_BANJIR.SelectedValue + "','" + 
				ddl_AS_TEGANGAN.SelectedValue + "','" + 
				ddl_AS_LONGSOR.SelectedValue + "','" +
				ddl_AS_POLUSI.SelectedValue + "','" + 
				ddl_AS_SWILAYAH.SelectedItem + "','" + 
				ddl_AS_SLOKASI.SelectedItem + "','" +
				ddl_AS_SFREK.SelectedItem + "','" + 
				ddl_AS_SKONDISI.SelectedItem + "','" + 
				ddl_AS_BKTYPE.SelectedValue + "','" +
				txt_AS_BKNO.Text + "','" + 
				txt_AS_BKNAMA.Text + "'," +
				GlobalTools.ToSQLDate(txt_AS_BKDATE_dd.Text, ddl_AS_BKDATE_mm.SelectedValue, txt_AS_BKDATE_yy.Text) + ",'" +
				txt_AS_BKAKTA.Text + "','" + 
				txt_AS_BKNOTARIS.Text + "','" + 
				ddl_AS_IJTYPE.SelectedValue + "','" +
				txt_AS_IJNO.Text + "','" + 
				txt_AS_IJSERTIFIKAT.Text + "'," + 
				GlobalTools.ConvertNull(txt_AS_IJNILAI.Text) + ",'" +
				txt_AS_IJNOTARIS.Text + "','" + 
				txt_AS_IJPADA.Text + "','" + 
				txt_AS_ABHASIL.Text + "'," +
				GlobalTools.ToSQLDate(txt_AS_ABDATE_dd.Text, ddl_AS_ABDATE_mm.SelectedValue, txt_AS_ABDATE_yy.Text) + ",'" +
				txt_AS_ABKANTOR.Text + "','" + 
				txt_AS_ABPEJABAT.Text + "','" + 
				ddl_AS_PSSTAT.SelectedValue + "','" + 
				txt_AS_PSNO.Text + "'," +
				GlobalTools.ToSQLDate(txt_AS_PSDATE_dd.Text, ddl_AS_PSDATE_mm.SelectedValue, txt_AS_PSDATE_yy.Text) + ",'" +
				txt_AS_PSNAMA.Text + "','" + 
				ddl_AS_IMBSTAT.SelectedValue + "','" + 
				txt_AS_IMBNO.Text + "'," +
				GlobalTools.ToSQLDate(txt_AS_IMBDATE_dd.Text, ddl_AS_IMBDATE_mm.SelectedValue, txt_AS_IMBDATE_yy.Text) + ",'" +
				txt_AS_IMBDKELUARK.Text + "','" + 
				ddl_AS_INSRSTAT.SelectedValue + "','" + 
				txt_AS_INSRTUTUP.Text + "'," + 
				GlobalTools.ConvertNull(txt_AS_INSRNILAI.Text) + "," +
				GlobalTools.ToSQLDate(txt_AS_INSRDATE_dd.Text, ddl_AS_INSRDATE_mm.SelectedValue, txt_AS_INSRDATE_yy.Text) + ",'" +
				txt_AS_INSRCOMP.Text + "'," + 
				GlobalTools.ConvertNull(txt_AS_DATA1.Text) + "," + 
				GlobalTools.ConvertNull(txt_AS_DATA2.Text) + ",'" +
				ddl_Tujuan.SelectedValue + "','" +
				ddl_AS_MARKET.SelectedValue + "','" + 
				ddl_AS_IKAT.SelectedValue + "','" + 
				ddl_AS_MASALAH.SelectedValue + "','" +
				ddl_AS_KUASA.SelectedValue + "','" + 
				txt_AS_LAIN.Text + "','';";
//			try
//			{
				conn.ExecuteNonQuery();

				//-----------------------------------------------------------------simpan ke APPR_LIST
				conn.QueryString = "EXEC SP_APPR_LIST 'Save','" + lbl_AP_REGNO.Text + "','" + lbl_CU_REF.Text + "','" + 
					lbl_CL_SEQ.Text + "','7','SPBU'";
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

				conn.QueryString = "SP_APPR_SPBU 'Save','" + lbl_AP_REGNO.Text + "','" + lbl_CU_REF.Text + "'," + 
					lbl_CL_SEQ.Text + ",'" + 
					txt_AS_NMDEBITUR.Text + "','" + 
					txt_AS_APPRBY1.Text + "','" + 
					txt_AS_APPRBY2.Text + "'," +
					GlobalTools.ToSQLDate(txt_AS_APPRDATE_dd.Text, ddl_AS_APPRDATE_mm.SelectedValue, txt_AS_APPRDATE_yy.Text) + ",'" +
					txt_AS_LOKJLN.Text + "','" + 
					txt_AS_LOKDESA.Text + "','" + 
					txt_AS_LOKKEC.Text + "','" + 
					txt_AS_LOKKAB.Text + "'," + 
					GlobalTools.ConvertNull(txt_AS_LUASTNH.Text) + ",'" + 
					ddl_AS_JALAN.SelectedValue + "'," +
					GlobalTools.ConvertNull(txt_AS_KETJALAN.Text) + ",'" + 
					txt_AS_JNSJALAN.Text + "','" + 
					ddl_AS_LISTRIK.SelectedValue + "'," +
					txt_AS_KETLISTRIK.Text + ",'" + 
					ddl_AS_TELP.SelectedValue + "'," + 
					txt_AS_KETTELP.Text + ",'" +
					ddl_AS_PAM.SelectedValue + "','" + 
					txt_AS_FREKKDRN.Text + "','" + 
					txt_AS_KONDISI.Text + "','" +
					ddl_AS_PERAWATAN.SelectedValue + "','" + 
					txt_AS_WILAYAH.Text + "','" + 
					ddl_AS_LINGKUNGAN.SelectedValue + "','" +
					ddl_AS_BANJIR.SelectedValue + "','" + 
					ddl_AS_TEGANGAN.SelectedValue + "','" + 
					ddl_AS_LONGSOR.SelectedValue + "','" +
					ddl_AS_POLUSI.SelectedValue + "','" + 
					ddl_AS_SWILAYAH.SelectedItem + "','" + 
					ddl_AS_SLOKASI.SelectedItem + "','" +
					ddl_AS_SFREK.SelectedItem + "','" + 
					ddl_AS_SKONDISI.SelectedItem + "','" + 
					ddl_AS_BKTYPE.SelectedValue + "','" +
					txt_AS_BKNO.Text + "','" + 
					txt_AS_BKNAMA.Text + "'," +
					GlobalTools.ToSQLDate(txt_AS_BKDATE_dd.Text, ddl_AS_BKDATE_mm.SelectedValue, txt_AS_BKDATE_yy.Text) + ",'" +
					txt_AS_BKAKTA.Text + "','" + 
					txt_AS_BKNOTARIS.Text + "','" + 
					ddl_AS_IJTYPE.SelectedValue + "','" +
					txt_AS_IJNO.Text + "','" + 
					txt_AS_IJSERTIFIKAT.Text + "'," + 
					GlobalTools.ConvertNull(txt_AS_IJNILAI.Text) + ",'" +
					txt_AS_IJNOTARIS.Text + "','" + 
					txt_AS_IJPADA.Text + "','" + 
					txt_AS_ABHASIL.Text + "'," +
					GlobalTools.ToSQLDate(txt_AS_ABDATE_dd.Text, ddl_AS_ABDATE_mm.SelectedValue, txt_AS_ABDATE_yy.Text) + ",'" +
					txt_AS_ABKANTOR.Text + "','" + 
					txt_AS_ABPEJABAT.Text + "','" + 
					ddl_AS_PSSTAT.SelectedValue + "','" + 
					txt_AS_PSNO.Text + "'," +
					GlobalTools.ToSQLDate(txt_AS_PSDATE_dd.Text, ddl_AS_PSDATE_mm.SelectedValue, txt_AS_PSDATE_yy.Text) + ",'" +
					txt_AS_PSNAMA.Text + "','" + 
					ddl_AS_IMBSTAT.SelectedValue + "','" + 
					txt_AS_IMBNO.Text + "'," +
					GlobalTools.ToSQLDate(txt_AS_IMBDATE_dd.Text, ddl_AS_IMBDATE_mm.SelectedValue, txt_AS_IMBDATE_yy.Text) + ",'" +
					txt_AS_IMBDKELUARK.Text + "','" + 
					ddl_AS_INSRSTAT.SelectedValue + "','" + 
					txt_AS_INSRTUTUP.Text + "'," + 
					GlobalTools.ConvertNull(txt_AS_INSRNILAI.Text) + "," +
					GlobalTools.ToSQLDate(txt_AS_INSRDATE_dd.Text, ddl_AS_INSRDATE_mm.SelectedValue, txt_AS_INSRDATE_yy.Text) + ",'" +
					txt_AS_INSRCOMP.Text + "'," + 
					GlobalTools.ConvertNull(txt_AS_DATA1.Text) + "," + 
					GlobalTools.ConvertNull(txt_AS_DATA2.Text) + ",'" +
					ddl_Tujuan.SelectedValue + "','" +
					ddl_AS_MARKET.SelectedValue + "','" + 
					ddl_AS_IKAT.SelectedValue + "','" + 
					ddl_AS_MASALAH.SelectedValue + "','" +
					ddl_AS_KUASA.SelectedValue + "','" + 
					txt_AS_LAIN.Text + "','1';";
//				try
//				{
					conn.ExecuteNonQuery();

					//-----------------------------------------------------------------simpan ke APPR_LIST
					conn.QueryString = "EXEC SP_APPR_LIST 'Save','" + lbl_AP_REGNO.Text + "','" + lbl_CU_REF.Text + "','" + 
						lbl_CL_SEQ.Text + "','7','SPBU'";
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
						LA_APPRSTATUS.ToString()+"', "+ GlobalTools.ConvertFloat(txt_AS_HRGPASAR.Text)+", "+
						GlobalTools.ConvertFloat(txt_AS_HRGWAJAR.Text)+", '" +TABLENAME.Trim()+ "', '"+mStat.ToString().Trim()+"'";
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
			int nWilayah, nLokasi, nFrekuensi, nKondisi, nHasil;

			txt_AS_WILAYAH.Text = ddl_AS_SWILAYAH.SelectedValue.ToString();
			txt_AS_JNSJALAN.Text = ddl_AS_SLOKASI.SelectedValue.ToString();
			txt_AS_FREKKDRN.Text = ddl_AS_SFREK.SelectedValue.ToString();
			txt_AS_KONDISI.Text = ddl_AS_SKONDISI.SelectedValue.ToString();
			
			//hitung: score		
			try {nWilayah = Convert.ToByte(ddl_AS_SWILAYAH.SelectedItem.Text);}
			catch {nWilayah = 0;}

			try {nLokasi = Convert.ToByte(ddl_AS_SLOKASI.SelectedItem.Text);}
			catch {nLokasi = 0;}

			try {nFrekuensi = Convert.ToByte(ddl_AS_SFREK.SelectedItem.Text);}
			catch {nFrekuensi = 0;}

			try {nKondisi = Convert.ToByte(ddl_AS_SKONDISI.SelectedItem.Text);}
			catch {nKondisi = 0;}

			nHasil = nWilayah + nLokasi + nFrekuensi + nKondisi;
			Score = nHasil;

			return nHasil;
		}


		private void Kalkulasi()
		{
			double HargaPasar, SafetyMargin;
			double Score = HitungScore();

			//hitung: harga pasar keseluruhan
			HargaPasar = Convert.ToDouble(txt_AS_DATA1.Text) * 0.50 + 
				Convert.ToDouble(txt_AS_DATA2.Text) * 0.50;
			txt_AS_HRGPASAR.Text = GlobalTools.MoneyFormat(HargaPasar.ToString());

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

			txt_AS_SFTYMARGIN.Text = Strings.Format(SafetyMargin,"0.0%");


			//hitung: nilai pasar yang dapat di terima bank
			txt_AS_HRGWAJAR.Text =  GlobalTools.MoneyFormat(Convert.ToString(HargaPasar * (1 - SafetyMargin)));
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
			if (txt_AS_LOKJLN.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Jalan harus diisi');</script>");
				return false;
			}
			else if (txt_AS_LOKDESA.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Kelurahan harus diisi');</script>");
				return false;
			}
			else if (txt_AS_LOKKEC.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Kecamatan harus diisi');</script>");
				return false;
			}
			else if (txt_AS_LOKKAB.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Kota Madya harus diisi');</script>");
				return false;
			}
			else if (txt_AS_APPRBY1.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Penilai 1 harus diisi');</script>");
				return false;
			}
			else if (txt_AS_APPRDATE_yy.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Tanggal Periksa harus diisi');</script>");
				return false;
			}
			else if (txt_AS_LUASTNH.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Luas Bangunan harus diisi');</script>");
				return false;
			}
			else if (txt_AS_KETJALAN.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Panjang Jalan harus diisi');</script>");
				return false;
			}
			else if (ddl_AS_SWILAYAH.SelectedValue == "0")
			{
				Response.Write("<script language='javascript'>alert('Wilayah harus dipilih');</script>");
				return false;
			}
			else if (ddl_AS_SLOKASI.SelectedValue == "0")
			{
				Response.Write("<script language='javascript'>alert('Lokasi harus dipilih');</script>");
				return false;
			}
			else if (ddl_AS_SFREK.SelectedValue == "0")
			{
				Response.Write("<script language='javascript'>alert('Frekuensi harus dipilih');</script>");
				return false;
			}
			else if (ddl_AS_SKONDISI.SelectedValue == "0")
			{
				Response.Write("<script language='javascript'>alert('Lingkungan harus dipilih');</script>");
				return false;
			}
			else if (txt_AS_DATA1.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Metode I harus diisi');</script>");
				return false;
			}
			else if (txt_AS_DATA2.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Metode II harus diisi');</script>");
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
			txt_AS_LOKJLN.ReadOnly = true;
			txt_AS_LOKDESA.ReadOnly = true;
			txt_AS_LOKKEC.ReadOnly = true;
			txt_AS_LOKKAB.ReadOnly = true;
			txt_AS_APPRDATE_dd.ReadOnly = true;
			ddl_AS_APPRDATE_mm.Enabled = false;
			txt_AS_APPRDATE_yy.ReadOnly = true;
			txt_AS_APPRBY1.ReadOnly = true;
			txt_AS_APPRBY2.ReadOnly = true;
			txt_AS_LUASTNH.ReadOnly = true;
			ddl_AS_JALAN.Enabled = false;
			txt_AS_KETJALAN.ReadOnly = true;
			txt_AS_JNSJALAN.ReadOnly = true;
			ddl_AS_LISTRIK.Enabled = false;
			txt_AS_KETLISTRIK.ReadOnly = true;
			ddl_AS_TELP.Enabled = false;
			txt_AS_KETTELP.ReadOnly = true;
			ddl_AS_PAM.Enabled = false;
			txt_AS_FREKKDRN.ReadOnly = true;
			txt_AS_KONDISI.ReadOnly = true;
			ddl_AS_PERAWATAN.Enabled = false;
			txt_AS_WILAYAH.ReadOnly = true;
			ddl_AS_LINGKUNGAN.Enabled = false;
			ddl_AS_BANJIR.Enabled = false;
			ddl_AS_TEGANGAN.Enabled = false;
			ddl_AS_LONGSOR.Enabled = false;
			ddl_AS_POLUSI.Enabled = false;
			ddl_AS_SWILAYAH.Enabled = false;
			ddl_AS_SLOKASI.Enabled = false;
			ddl_AS_SFREK.Enabled = false;
			ddl_AS_SKONDISI.Enabled = false;
			ddl_AS_BKTYPE.Enabled = false;
			txt_AS_BKNO.ReadOnly = true;
			txt_AS_BKDATE_dd.ReadOnly = true;
			ddl_AS_BKDATE_mm.Enabled = false;
			txt_AS_BKDATE_yy.ReadOnly = true;
			txt_AS_BKNAMA.ReadOnly = true;
			txt_AS_BKAKTA.ReadOnly = true;
			txt_AS_BKNOTARIS.ReadOnly = true;
			ddl_AS_IJTYPE.Enabled = false;
			txt_AS_IJNO.ReadOnly = true;
			txt_AS_IJSERTIFIKAT.ReadOnly = true;
			txt_AS_IJNOTARIS.ReadOnly = true;
			txt_AS_IJPADA.ReadOnly = true;
			txt_AS_IJNILAI.ReadOnly = true;
			txt_AS_ABHASIL.ReadOnly = true;
			txt_AS_ABDATE_dd.ReadOnly = true;
			ddl_AS_ABDATE_mm.Enabled = false;
			txt_AS_ABDATE_yy.ReadOnly = true;
			txt_AS_ABKANTOR.ReadOnly = true;
			txt_AS_ABPEJABAT.ReadOnly = true;
			ddl_AS_PSSTAT.Enabled = false;
			txt_AS_PSNO.ReadOnly = true;
			txt_AS_PSNAMA.ReadOnly = true;
			txt_AS_PSDATE_dd.ReadOnly = true;
			ddl_AS_PSDATE_mm.Enabled = false;
			txt_AS_PSDATE_yy.ReadOnly = true;
			ddl_AS_IMBSTAT.Enabled = false;
			txt_AS_IMBNO.ReadOnly = true;
			txt_AS_IMBDATE_dd.ReadOnly = true;
			ddl_AS_IMBDATE_mm.Enabled = false;
			txt_AS_IMBDATE_yy.ReadOnly = true;
			txt_AS_IMBDKELUARK.ReadOnly = true;
			ddl_AS_INSRSTAT.Enabled = false;
			txt_AS_INSRTUTUP.ReadOnly = true;
			txt_AS_INSRNILAI.ReadOnly = true;
			txt_AS_INSRDATE_dd.ReadOnly = true;
			ddl_AS_INSRDATE_mm.Enabled = false;
			txt_AS_INSRDATE_yy.ReadOnly = true;
			txt_AS_INSRCOMP.ReadOnly = true;
			txt_AS_DATA1.ReadOnly = true;
			txt_AS_DATA2.ReadOnly = true;
			ddl_Tujuan.Enabled = false;
			ddl_AS_MARKET.Enabled = false;
			ddl_AS_IKAT.Enabled = false;
			ddl_AS_KUASA.Enabled = false;
			ddl_AS_MASALAH.Enabled = false;
			txt_AS_LAIN.ReadOnly = true;
		
			btn_Calc.Visible = false;
		}

		private void EnableUpdate()
		{
			double AS_HRGPASAR = 0, AS_HRGWAJAR = 0, AS_SFTYMARGIN = 0;

			try {AS_HRGPASAR = double.Parse(GlobalTools.ConvertFloat(txt_AS_HRGPASAR.Text));}
			catch {}
			try {AS_HRGWAJAR = double.Parse(GlobalTools.ConvertFloat(txt_AS_HRGWAJAR.Text));}
			catch {}
			try {AS_SFTYMARGIN = double.Parse(GlobalTools.ConvertFloat(txt_AS_SFTYMARGIN.Text));}
			catch {}


			if ( (AS_HRGPASAR > 0) && (AS_HRGWAJAR > 0) && (AS_SFTYMARGIN >= 0) )
				btn_UpdateStatus.Enabled = true;
			else
				btn_UpdateStatus.Enabled = false;
		}

		protected void btn_Delete_Click(object sender, System.EventArgs e)
		{
			//-----------------------------------------------------------------hapus dari APPR_SPBU
			conn.QueryString = "SP_APPR_SPBU 'Delete','" + 
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
