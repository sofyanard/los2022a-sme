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
	/// Summary description for PenilaianJaminanBangunan.
	/// </summary>
	public partial class PenilaianJaminanBangunan : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Textbox50;
		protected System.Web.UI.WebControls.TextBox Textbox53;
		protected System.Web.UI.WebControls.TextBox Textbox83;
		protected System.Web.UI.WebControls.DropDownList DropDownList20;
		protected System.Web.UI.WebControls.TextBox Textbox51;
		protected System.Web.UI.WebControls.TextBox txt_NamaDebitur;
		protected System.Web.UI.WebControls.TextBox txt_Jalan;
		protected System.Web.UI.WebControls.TextBox txt_Blok;
		protected System.Web.UI.WebControls.TextBox txt_Klurahn;
		protected System.Web.UI.WebControls.TextBox txt_Kcamatn;
		protected System.Web.UI.WebControls.TextBox txt_Kodya;
		protected System.Web.UI.WebControls.TextBox txt_ScoreKondisi;
		protected System.Web.UI.WebControls.TextBox txt_ScorePrawatn;
		protected System.Web.UI.WebControls.TextBox txt_THNRENOVASI;
		protected System.Web.UI.WebControls.DropDownList txt_AB_ATAP;
		protected System.Web.UI.WebControls.TextBox txt_AB_SCORE1;
		protected System.Web.UI.WebControls.TextBox txt_AB_SCORE2;

		protected Connection conn;
		//protected Tools tool = new Tools();
		

		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			
			if (! IsPostBack)
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

				GlobalTools.initDateFormINA(txt_AB_TGLPERIKSA_DD,ddl_AB_TGLPERIKSA_MM,txt_AB_TGLPERIKSA_YY);
				GlobalTools.initDateFormINA(txt_AB_IJINDATE_DD,ddl_AB_IJINDATE_MM,txt_AB_IJINDATE_YY);
				GlobalTools.initDateFormINA(txt_AB_INSREXPDATE_DD,ddl_AB_INSREXPDATE_MM,txt_AB_INSREXPDATE_YY);

				GlobalTools.fillRefList(ddl_AB_KETAIR,"select * from RF_APPR_AIR where ACTIVE = '1'",false,conn);

				GlobalTools.fillRefList(ddl_AB_GUNA,"select * from RF_APPR_PENGGUNAANBANGUNAN where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AB_JENISBANGUNAN,"select * from RF_APPR_JENISBANGUNAN where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AB_KONTRUKSI,"select * from RFKONTRUKSI where ACTIVE = '1'",false,conn);
				
				GlobalTools.fillRefList(ddl_AB_DINDING,"select * from RF_APPR_DINDING where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AB_ATAP,"select * from RF_APPR_ATAP where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AB_LANTAI,"select * from RFLANTAI where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AB_PINTU,"select * from RF_APPR_PINTU where ACTIVE = '1'",false,conn);

				GlobalTools.fillRefList(ddl_AB_KONDISI,"select * from RFKONDISI where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AB_PEMELIHARAANBGN,"select * from RFKONDISI where ACTIVE = '1'",false,conn);

				GlobalTools.fillRefList(ddl_AB_LOKASI,"select * from RF_APPR_LOKASIBANGUNAN where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_Tujuan,"select * from RF_APPR_TUJUAN where ACTIVE = '1'",false,conn);
				
				ViewData();
				Kalkulasi();
				EnableUpdate();
			}

			//###################################################################
			btn_UpdateStatus.Attributes.Add("onclick","if(!update()){return false;}");
			btn_Reentry.Attributes.Add("onclick","if(!update()){return false;}");
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
			// else if (mGROUP == lbl_GRP_COOFF.Text.Trim() && LA_APPRSTATUS != "2")
			else if (isPetugas(mGROUP) && LA_APPRSTATUS != "2")
				STSTOMBOL = "1";
			//else if (mGROUP == lbl_GRP_CO.Text.Trim() && LA_APPRSTATUS != "5")
			else if (!isPetugas(mGROUP) && (LA_APPRSTATUS != "5" || LA_APPRSTATUS != "6"))
				STSTOMBOL = "1";
			//else if (mGROUP != lbl_GRP_CO.Text.Trim() && mGROUP != lbl_GRP_COOFF.Text.Trim())			
			else
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
				"where AP_REGNO = '"+ lbl_AP_REGNO.Text + "'";
			conn.ExecuteQuery();
			txt_AB_NMDEBITUR.Text = conn.GetFieldValue("CU_NAME");

			//------------------------------------------------------------------------------------------
			conn.QueryString = "select * from VW_APPR_BANGUNAN "+
				"where AP_REGNO = '"+ lbl_AP_REGNO.Text +"' and CU_REF  = '"+ lbl_CU_REF.Text +"' "+
				"and CL_SEQ  = "+ lbl_CL_SEQ.Text;
			conn.ExecuteQuery();
			
			try
			{
				txt_AB_LOKJALAN.Text = conn.GetFieldValue("AB_LOKJALAN");
				txt_AB_LOKKEL.Text = conn.GetFieldValue("AB_LOKKEL");
				txt_AB_LOKKEC.Text = conn.GetFieldValue("AB_LOKKEC");
				txt_AB_LOKKOD.Text = conn.GetFieldValue("AB_LOKKOD");
				try {GlobalTools.fillDateForm(txt_AB_TGLPERIKSA_DD,ddl_AB_TGLPERIKSA_MM,txt_AB_TGLPERIKSA_YY,Convert.ToDateTime(conn.GetFieldValue("AB_APPRDATE")));} catch {}
				txt_AB_PENILAI1.Text = conn.GetFieldValue("AB_APPRBY1");
				txt_AB_PENILAI2.Text = conn.GetFieldValue("AB_APPRBY2");

				//=====================================================================
				txt_AB_LUASBANGUN.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AB_LUASBANGUN"));
				txt_AB_THNBUAT.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AB_THNBUAT"));
				txt_AB_THNRENOVASI.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AB_THNRENOVASI"));
				try{ddl_AB_GUNA.SelectedValue = conn.GetFieldValue("AB_GUNA");} catch{}
				txt_AB_GUNAKET.Text = conn.GetFieldValue("AB_GUNAKET");
				ddl_AB_LISTRIK.SelectedValue = conn.GetFieldValue("AB_LISTRIK");
				txt_AB_KETLISTRIK.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AB_KETLISTRIK"));
				try{ddl_AB_TELPFAX.SelectedValue = conn.GetFieldValue("AB_TELPFAX");} catch{}
				txt_AB_KETTELPFAX.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AB_KETTELPFAX"));
				try{ddl_AB_AIR.SelectedValue = conn.GetFieldValue("AB_AIR");} catch{}
				try{ddl_AB_KETAIR.SelectedValue = conn.GetFieldValue("AB_KETAIR");} catch{}
				try{ddl_AB_AC.SelectedValue = conn.GetFieldValue("AB_AC");} catch{}
				txt_AB_KETAC.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AB_KETAC"));
				try{ddl_AB_PRASARANALAIN.SelectedValue = conn.GetFieldValue("AB_PRASARANALAIN");} catch{}
				txt_AB_KETPRASARANALAIN.Text = conn.GetFieldValue("AB_KETPRASARANALAIN");
				ddl_AB_JENISBANGUNAN.SelectedValue = conn.GetFieldValue("AB_JENISBANGUNAN");
				try{ddl_AB_KONTRUKSI.SelectedValue = conn.GetFieldValue("AB_KONTRUKSI");} catch{}
				try{ddl_AB_DINDING.SelectedValue = conn.GetFieldValue("AB_DINDING");} catch{}
				try{ddl_AB_ATAP.SelectedValue = conn.GetFieldValue("AB_ATAP");} catch{}
				try{ddl_AB_LANTAI.SelectedValue = conn.GetFieldValue("AB_LANTAI");} catch{}
				try{ddl_AB_PINTU.SelectedValue = conn.GetFieldValue("AB_PINTU");} catch{}
				try{ddl_AB_KONDISI.SelectedValue = conn.GetFieldValue("AB_KONDISI");} catch{}
				try{ddl_AB_PEMELIHARAANBGN.SelectedValue = conn.GetFieldValue("AB_PEMELIHARAANBGN");} catch{}
				try{ddl_AB_LOKASI.SelectedValue = conn.GetFieldValue("AB_LOKASI");} catch{}

				//=====================================================================
				try{ddl_AB_IJINSTAT.SelectedValue = conn.GetFieldValue("AB_IJINSTAT");} catch{}
				txt_AB_IJINNO.Text = conn.GetFieldValue("AB_IJINNO");
				try {GlobalTools.fillDateForm(txt_AB_IJINDATE_DD,ddl_AB_IJINDATE_MM,txt_AB_IJINDATE_YY,Convert.ToDateTime(conn.GetFieldValue("AB_IJINDATE")));} catch {}
				txt_AB_IJINDKELUARK.Text = conn.GetFieldValue("AB_IJINDKELUARK");
				txt_AB_IJINLUAS.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AB_IJINLUAS"));

				//=====================================================================
				try{ddl_AB_INSRSTATUS.SelectedValue = conn.GetFieldValue("AB_INSRSTATUS");} catch{}
				txt_AB_INSRTUTUP.Text = conn.GetFieldValue("AB_INSRTUTUP");
				txt_AB_INSRAMOUNT.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AB_INSRAMOUNT"));
				try {GlobalTools.fillDateForm(txt_AB_INSREXPDATE_DD,ddl_AB_INSREXPDATE_MM,txt_AB_INSREXPDATE_YY,Convert.ToDateTime(conn.GetFieldValue("AB_INSREXPDATE")));} catch {}
				txt_AB_INSRCOMP.Text = conn.GetFieldValue("AB_INSRCOMP");

				//=====================================================================
				txt_AB_HRGBARUM2.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AB_HRGBARUM2"));
				txt_AB_UMUREKON.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AB_UMUREKON"));
				try{ddl_Tujuan.SelectedValue = conn.GetFieldValue("AB_TUJUAN");} catch{}
				txt_AB_SUMBERDATA.Text = conn.GetFieldValue("AB_SUMBERDATA");
				txt_AB_KESIMPULAN.Text = conn.GetFieldValue("AB_KESIMPULAN");
				lbl_UpdateStatus.Text = conn.GetFieldValue("UPDATESTAT");
				
			}
			catch{}
		}

		
		protected void btn_Save_Click(object sender, System.EventArgs e)
		{
			
			if (Kalkulasi())
			{
				conn.QueryString = "EXEC SP_APPR_BANGUNAN 'Save','" + 
					lbl_AP_REGNO.Text + "','" + 
					lbl_CU_REF.Text + "','" + 
					lbl_CL_SEQ.Text + "','" + 
					txt_AB_NMDEBITUR.Text + "'," +
					GlobalTools.ToSQLDate(txt_AB_TGLPERIKSA_DD.Text, ddl_AB_TGLPERIKSA_MM.SelectedValue, txt_AB_TGLPERIKSA_YY.Text) + ",'" +
					txt_AB_PENILAI1.Text + "','" + 
					txt_AB_PENILAI2.Text + "','" + 
					txt_AB_LOKJALAN.Text + "','" +
					txt_AB_LOKKEL.Text + "','" + 
					txt_AB_LOKKEC.Text + "','" + 
					txt_AB_LOKKOD.Text +"'," +
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
					ddl_Tujuan.SelectedValue + "','" +
					txt_AB_SUMBERDATA.Text + "','" + 
					txt_AB_KESIMPULAN.Text + "',''";

//				try
//				{
					conn.ExecuteNonQuery();

					//-----------------------------------------------------------------simpan ke APPR_LIST
					conn.QueryString = "EXEC SP_APPR_LIST 'Save','" + lbl_AP_REGNO.Text + "','" + lbl_CU_REF.Text + "','" + 
						lbl_CL_SEQ.Text + "','1','Bangunan'";
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
				if (Kalkulasi())
				{

					conn.QueryString = "EXEC SP_APPR_BANGUNAN 'Save','" + 
						lbl_AP_REGNO.Text + "','" + 
						lbl_CU_REF.Text + "','" + 
						lbl_CL_SEQ.Text + "','" + 
						txt_AB_NMDEBITUR.Text + "'," +
						GlobalTools.ToSQLDate(txt_AB_TGLPERIKSA_DD.Text, ddl_AB_TGLPERIKSA_MM.SelectedValue, txt_AB_TGLPERIKSA_YY.Text) + ",'" +
						txt_AB_PENILAI1.Text + "','" + 
						txt_AB_PENILAI2.Text + "','" + 
						txt_AB_LOKJALAN.Text + "','" +
						txt_AB_LOKKEL.Text + "','" + 
						txt_AB_LOKKEC.Text + "','" + 
						txt_AB_LOKKOD.Text +"'," +
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
						ddl_Tujuan.SelectedValue + "','" +
						txt_AB_SUMBERDATA.Text + "','" + 
						txt_AB_KESIMPULAN.Text + "','1'";
		
//					try
//					{
						conn.ExecuteNonQuery();

						//-----------------------------------------------------------------simpan ke APPR_LIST
						conn.QueryString = "EXEC SP_APPR_LIST 'Save','" + lbl_AP_REGNO.Text + "','" + lbl_CU_REF.Text + "','" + 
							lbl_CL_SEQ.Text + "','1','Bangunan'";
						conn.ExecuteNonQuery();

						//-----------------------------------------------------------------refresh parent
						Response.Write("<script language='javascript'> " +
							"parent.document.Form1.action = 'InfoUmum.aspx?regno=" + lbl_AP_REGNO.Text + "&curef=" + lbl_CU_REF.Text + "&cl_seq=" + lbl_CL_SEQ.Text + "&tc=" + lbl_TC.Text + "&mc=" + lbl_MC.Text + "';" +
							"parent.document.Form1.submit();</script>");

						//########################################## update status
						string mGROUP = Session["GroupID"].ToString();
						string LA_APPRSTATUS = "", TABLENAME = "";

						/// if (mGROUP == lbl_GRP_COOFF.Text.Trim()
						if (isPetugas(mGROUP)) 
						{
							LA_APPRSTATUS = "5";
						}
						// else if (mGROUP == lbl_GRP_CO.Text.Trim())
						else
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
							LA_APPRSTATUS.ToString()+"', "+ GlobalTools.ConvertFloat(txt_AB_HRGBANK.Text)+", "+
							GlobalTools.ConvertFloat(txt_AB_HRGBANGUNAN.Text)+", '" +TABLENAME.Trim()+ "', '"+mStat.ToString().Trim()+"'";
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


		private bool Kalkulasi()
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
				UmurBangunan = Convert.ToDouble(txt_AB_TGLPERIKSA_YY.Text) - Convert.ToDouble(txt_AB_THNBUAT.Text);
				// 2 umur renovasi
				if (txt_AB_THNRENOVASI.Text == "") txt_AB_THNRENOVASI.Text = "0";

				if (Convert.ToDouble(txt_AB_THNRENOVASI.Text) == 0)
					UmurRenovasi = UmurBangunan;
				else
					//UmurRenovasi = Convert.ToDouble(txt_AB_THNRENOVASI.Text) - Convert.ToDouble(txt_AB_THNBUAT.Text);
					UmurRenovasi = Convert.ToDouble(txt_AB_TGLPERIKSA_YY.Text) - Convert.ToDouble(txt_AB_THNRENOVASI.Text);
			
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
		
				/// Kalau tujuan pembangunan adalah Penebusan Agunan atau PPAP, 
				/// maka safety margin = 0				
				/// 
				if (ddl_Tujuan.SelectedItem.ToString() == "Penebusan Agunan" && ddl_Tujuan.SelectedItem.ToString() == "PPAP" || 
					(ddl_Tujuan.SelectedValue == "5" && ddl_Tujuan.SelectedValue == "6"))
					SafetyMargin = 0;				


				/// Kalau tahun appraisal sama dengan tahun pembangunan
				/// maka safety margin = 0
				/// 
				if (txt_AB_TGLPERIKSA_YY.Text.Trim().Equals(txt_AB_THNBUAT.Text.Trim())) 
					SafetyMargin = 0;


				txt_AB_SFTYMARGIN.Text = Strings.Format(SafetyMargin,"0.0%");

		
				//hitung: nilai pasar yang dapat di terima bank
				txt_AB_HRGBANK.Text = GlobalTools.MoneyFormat(Convert.ToString(HargaBangunan * (1 - SafetyMargin)));
			}
			catch{}

			return true;
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
			if (txt_AB_LOKJALAN.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Jalan harus diisi');</script>");
				return false;
			}
			else if (txt_AB_LOKKEL.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Kelurahan harus diisi');</script>");
				return false;
			}
			else if (txt_AB_LOKKEC.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Kecamatan harus diisi');</script>");
				return false;
			}
			else if (txt_AB_LOKKOD.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Kota Madya harus diisi');</script>");
				return false;
			}
			else if (txt_AB_PENILAI1.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Penilai 1 harus diisi');</script>");
				return false;
			}
			else if (txt_AB_TGLPERIKSA_YY.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Tanggal Periksa harus diisi');</script>");
				return false;
			}
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

		private void BackToList() 
		{
			Session.Add("tc", Request.QueryString["tc"]);
			Session.Add("mc", Request.QueryString["mc"]);
			
			string link = "ListAppraisal.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"];
			Response.Write("<form name='Form1' action='"+link+"' target='main'");
			Response.Write("");
			Response.Write("</form>");
			Response.Write("<script language='javascript'>alert('Update Successful!')");
			Response.Write("document.Form2.submit();</script>");			
		}

		protected void btn_Reentry_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "update LISTASSIGNMENT set LA_APPRSTATUS = '2' where AP_REGNO = '" +lbl_AP_REGNO.Text+
				"' and CU_REF = '" + lbl_CU_REF.Text+ "' and CL_SEQ = "+lbl_CL_SEQ.Text;
			conn.ExecuteQuery();
			ViewData();
		}


		private void DisabledEntry()
		{
			txt_AB_LOKJALAN.ReadOnly = true;
			txt_AB_LOKKEL.ReadOnly = true;
			txt_AB_LOKKEC.ReadOnly = true;
			txt_AB_LOKKOD.ReadOnly = true;
			txt_AB_TGLPERIKSA_DD.ReadOnly = true;
            ddl_AB_TGLPERIKSA_MM.Enabled = false;
			txt_AB_TGLPERIKSA_YY.ReadOnly = true;
			txt_AB_PENILAI1.ReadOnly = true;
			txt_AB_PENILAI2.ReadOnly = true;
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
			ddl_Tujuan.Enabled = false;
			txt_AB_SUMBERDATA.ReadOnly = true;
			txt_AB_KESIMPULAN.ReadOnly = true;
		
			btn_Calc.Visible = false;
		}
		
		private void EnableUpdate()
		{
			double AB_HRGBANGUNAN = 0, AB_HRGBANK = 0, AB_SFTYMARGIN = 0;

			try {AB_HRGBANGUNAN = double.Parse(GlobalTools.ConvertFloat(txt_AB_HRGBANGUNAN.Text));}
			catch {}
			try {AB_HRGBANK = double.Parse(GlobalTools.ConvertFloat(txt_AB_HRGBANK.Text));}
			catch {}
			try {AB_SFTYMARGIN = double.Parse(GlobalTools.ConvertFloat(txt_AB_SFTYMARGIN.Text));}
			catch {}


			if ( (AB_HRGBANGUNAN > 0) && (AB_HRGBANK > 0) && (AB_SFTYMARGIN >= 0) )
				btn_UpdateStatus.Enabled = true;
			else
				btn_UpdateStatus.Enabled = false;
		}

		protected void btn_Delete_Click(object sender, System.EventArgs e)
		{
			//-----------------------------------------------------------------hapus dari APPR_BANGUNAN
			conn.QueryString = "EXEC SP_APPR_BANGUNAN 'Delete','" + 
				lbl_AP_REGNO.Text + "','" + 
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
