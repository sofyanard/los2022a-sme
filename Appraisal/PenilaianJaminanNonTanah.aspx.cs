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
	/// Summary description for PenilaianJaminanNonTanah.
	/// </summary>
	public partial class PenilaianJaminanNonTanah : System.Web.UI.Page
	{

		//protected Tools GlobalTools. = new Tools();
		protected Connection conn;

	
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

				GlobalTools.initDateFormINA(txt_AK_APPRDATE_DD,ddl_AK_APPRDATE_MM,txt_AK_APPRDATE_YY);
				GlobalTools.initDateFormINA(txt_AK_BKDATE_DD,ddl_AK_BKDATE_MM,txt_AK_BKDATE_YY);
				GlobalTools.initDateFormINA(txt_AK_IKATDATE_DD,ddl_AK_IKATDATE_MM,txt_AK_IKATDATE_YY);
				GlobalTools.initDateFormINA(txt_AK_ABDATE_DD,ddl_AK_ABDATE_MM,txt_AK_ABDATE_YY);
				GlobalTools.initDateFormINA(txt_AK_INSRDATE_DD,ddl_AK_INSRDATE_MM,txt_AK_INSRDATE_YY);
								
				GlobalTools.fillRefList(ddl_AK_JNSAGUNAN,"select * from RF_APPR_JENISOBYEK where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AK_UMUR,"select * from RF_APPR_UMUR where ACTIVE = '1'",false,conn);
				
				GlobalTools.fillRefList(ddl_AK_KONDISI,"select * from RFKONDISI where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AK_PERWATAN,"select * from RFKONDISI where ACTIVE = '1'",false,conn);

				GlobalTools.fillRefList(ddl_AK_BANJIR,"select * from RFRISIKO where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AK_PENCURIAN,"select * from RFRISIKO where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AK_KEBAKARAN,"select * from RFRISIKO where ACTIVE = '1'",false,conn);

				GlobalTools.fillRefList(ddl_AK_BPKB,"select * from RF_APPR_BUKTIKEPEMILIKAN where ACTIVE = '1' and TIPE = '2'",false,conn);
				
				GlobalTools.fillRefList(ddl_Tujuan,"select * from RF_APPR_TUJUAN where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AK_MARKET,"select * from RF_APPR_MARKETABILITY where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AK_IKATAN,"select * from RF_APPR_IKATSEMPURNA where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AK_MASALAH,"select * from RF_APPR_MASALAH where ACTIVE = '1'",false,conn);
				GlobalTools.fillRefList(ddl_AK_KUASA,"select * from RFPENGUASAAN where ACTIVE = '1'",false,conn);

				ViewData();
				try {Kalkulasi();}
				catch {}
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
			//else if (mGROUP == lbl_GRP_COOFF.Text.Trim() && LA_APPRSTATUS != "2")
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
			txt_AK_NMDEBITUR.Text = conn.GetFieldValue("CU_NAME");

			//------------------------------------------------------------------------------------------

			conn.QueryString = "select * from VW_APPR_KENDARAAN "+
				"where AP_REGNO = '"+ lbl_AP_REGNO.Text +"' and CU_REF  = '"+ lbl_CU_REF.Text +"' "+
				"and CL_SEQ  = "+ lbl_CL_SEQ.Text ;
			conn.ExecuteQuery();

			try
			{
				txt_AK_LOKJLN.Text = conn.GetFieldValue("AK_LOKJLN");
				txt_AK_LOKDESA.Text = conn.GetFieldValue("AK_LOKDESA");
				txt_AK_LOKKEC.Text = conn.GetFieldValue("AK_LOKKEC");
				txt_AK_LOKKAB.Text = conn.GetFieldValue("AK_LOKKAB");
				try {GlobalTools.fillDateForm(txt_AK_APPRDATE_DD,ddl_AK_APPRDATE_MM,txt_AK_APPRDATE_YY,Convert.ToDateTime(conn.GetFieldValue("AK_APPRDATE")));}
				catch {}
				txt_AK_APPRBY1.Text = conn.GetFieldValue("AK_APPRBY1");
				txt_AK_APPRBY2.Text = conn.GetFieldValue("AK_APPRBY2");

				//=====================================================================
				try{ddl_AK_JNSAGUNAN.SelectedValue = conn.GetFieldValue("AK_JNSAGUNAN");} catch{}
				txt_AK_THNBELI.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AK_THNBELI"));
				try{ddl_AK_ISNEW.SelectedValue = conn.GetFieldValue("AK_ISNEW");} catch{}
				try{ddl_AK_UMUR.SelectedValue = conn.GetFieldValue("AK_UMUR");} catch{}
				txt_AK_MERK.Text = conn.GetFieldValue("AK_MERK");
				txt_AK_TIPE.Text = conn.GetFieldValue("AK_TIPE");
				txt_AK_JENIS.Text = conn.GetFieldValue("AK_JENIS");
				try{ddl_AK_KONDISI.SelectedValue = conn.GetFieldValue("AK_KONDISI");} catch{}
				try{ddl_AK_PERWATAN.SelectedValue = conn.GetFieldValue("AK_PERAWATAN");} catch{}
				try{ddl_AK_BANJIR.SelectedValue = conn.GetFieldValue("AK_BANJIR");} catch{}
				try{ddl_AK_PENCURIAN.SelectedValue = conn.GetFieldValue("AK_PENCURIAN");} catch{}
				try{ddl_AK_KEBAKARAN.SelectedValue = conn.GetFieldValue("AK_KEBAKARAN");} catch{}

				//=====================================================================
				try{ddl_AK_BPKB.SelectedValue = conn.GetFieldValue("AK_BPKB");} catch{}
				txt_AK_BKNO.Text = conn.GetFieldValue("AK_BKNO");
				try {GlobalTools.fillDateForm(txt_AK_BKDATE_DD,ddl_AK_BKDATE_MM,txt_AK_BKDATE_YY,Convert.ToDateTime(conn.GetFieldValue("AK_BKDATE")));}	catch {}
				txt_AK_FAKTURBRG.Text = conn.GetFieldValue("AK_FAKTURBRG");

				//=====================================================================
				try{ddl_AK_IKATSTAT.SelectedValue = conn.GetFieldValue("AK_IKATSTAT");} catch{}
				txt_AK_IKATNO.Text = conn.GetFieldValue("AK_IKATNO");
				txt_AK_IKATNOTARIS.Text = conn.GetFieldValue("AK_IKATNOTARIS");
				txt_AK_IKATFEO.Text = conn.GetFieldValue("AK_IKATFEO");
				try {GlobalTools.fillDateForm(txt_AK_IKATDATE_DD,ddl_AK_IKATDATE_MM,txt_AK_IKATDATE_YY,Convert.ToDateTime(conn.GetFieldValue("AK_IKATDATE")));} catch {}
				txt_AK_IKATNILAI.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AK_IKATNILAI"));
				txt_AK_IKATPADA.Text = conn.GetFieldValue("AK_IKATPADA");

				//=====================================================================
				txt_AK_ABHASIL.Text = conn.GetFieldValue("AK_ABHASIL");
				try {GlobalTools.fillDateForm(txt_AK_ABDATE_DD,ddl_AK_ABDATE_MM,txt_AK_ABDATE_YY,Convert.ToDateTime(conn.GetFieldValue("AK_ABDATE")));}
				catch {}
				txt_AK_ABKANTOR.Text = conn.GetFieldValue("AK_ABKANTOR");
				txt_AK_ABPEJABAT.Text = conn.GetFieldValue("AK_ABPEJABAT");

				//=====================================================================
				try{ddl_AK_INSRSTATUS.SelectedValue = conn.GetFieldValue("AK_INSRSTATUS");} catch{}
				txt_AK_INSRCOVER.Text = conn.GetFieldValue("AK_INSRCOVER");
				txt_AK_INSRAMOUNT.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AK_INSRAMOUNT"));
				try {GlobalTools.fillDateForm(txt_AK_INSRDATE_DD,ddl_AK_INSRDATE_MM,txt_AK_INSRDATE_YY,Convert.ToDateTime(conn.GetFieldValue("AK_INSRDATE")));} catch {}
				txt_AK_INSRCOMP.Text = conn.GetFieldValue("AK_INSRCOMP");

				//=====================================================================
				txt_AK_DATA1.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AK_DATA1"));
				txt_AK_DATA2.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AK_DATA2"));
				txt_AK_DATA3.Text = GlobalTools.ConvertFloat(conn.GetFieldValue("AK_DATA3"));
				txt_AK_NAMA1.Text = conn.GetFieldValue("AK_NAMA1");
				txt_AK_NAMA2.Text = conn.GetFieldValue("AK_NAMA2");
				txt_AK_NAMA3.Text = conn.GetFieldValue("AK_NAMA3");
				txt_AK_ALAMAT1.Text = conn.GetFieldValue("AK_ALAMAT1");
				txt_AK_ALAMAT2.Text = conn.GetFieldValue("AK_ALAMAT2");
				txt_AK_ALAMAT3.Text = conn.GetFieldValue("AK_ALAMAT3");
				txt_AK_TGL1.Text = conn.GetFieldValue("AK_TGL1");
				txt_AK_TGL2.Text = conn.GetFieldValue("AK_TGL1");
				txt_AK_TGL3.Text = conn.GetFieldValue("AK_TGL1");
			
				//=====================================================================
				try{ddl_Tujuan.SelectedValue = conn.GetFieldValue("AK_TUJUAN");} catch{}
				try{ddl_AK_MARKET.SelectedValue = conn.GetFieldValue("AK_MARKET");} catch{}
				try{ddl_AK_IKATAN.SelectedValue = conn.GetFieldValue("AK_IKATAN");} catch{}
				try{ddl_AK_MASALAH.SelectedValue = conn.GetFieldValue("AK_MASALAH");} catch{}
				try{ddl_AK_KUASA.SelectedValue = conn.GetFieldValue("AK_KUASA");} catch{}
				txt_AK_LAIN.Text = conn.GetFieldValue("AK_LAIN");
				txt_AK_PENDAPAT.Text = conn.GetFieldValue("AK_PENDAPAT");
				lbl_UpdateStatus.Text = conn.GetFieldValue("UPDATESTAT");

			}
			catch{}
		}

		protected void btn_Save_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "SP_APPR_KENDARAAN 'Save','" + 
				lbl_AP_REGNO.Text + "','"+ 
				lbl_CU_REF.Text + "','" +				
				lbl_CL_SEQ.Text + "','" +  
				txt_AK_APPRBY1.Text + "','" + 
				txt_AK_APPRBY2.Text + "'," +
				GlobalTools.ToSQLDate(txt_AK_APPRDATE_DD.Text, ddl_AK_APPRDATE_MM.SelectedValue, txt_AK_APPRDATE_YY.Text) + ",'" +
				txt_AK_NMDEBITUR.Text + "','" + 
				txt_AK_LOKJLN.Text + "','" + 
				txt_AK_LOKDESA.Text + "','" +  
				txt_AK_LOKKEC.Text + "','" +
				txt_AK_LOKKAB.Text + "','" + 
				ddl_AK_JNSAGUNAN.SelectedValue + "','" +	
				ddl_AK_ISNEW.SelectedValue + "','" +
				ddl_AK_UMUR.SelectedValue + "','" +
				txt_AK_MERK.Text + "','" +	 
				txt_AK_TIPE.Text + "','" + 
				txt_AK_JENIS.Text + "'," + 
				GlobalTools.ConvertNull(txt_AK_THNBELI.Text) + ",'" +
				ddl_AK_KONDISI.SelectedValue + "','" +	
				ddl_AK_PERWATAN.SelectedValue + "','" + 
				ddl_AK_BANJIR.SelectedValue + "','" +
				ddl_AK_PENCURIAN.SelectedValue + "','" + 
				ddl_AK_KEBAKARAN.SelectedValue + "','" +	
				ddl_AK_BPKB.SelectedValue + "','" + 
				txt_AK_BKNO.Text + "'," +					
				GlobalTools.ToSQLDate(txt_AK_BKDATE_DD.Text, ddl_AK_BKDATE_MM.SelectedValue, txt_AK_BKDATE_YY.Text) + ",'" +
				txt_AK_FAKTURBRG.Text + "','" + 
				ddl_AK_IKATSTAT.SelectedValue + "','" + 
				txt_AK_IKATNO.Text + "','" +
				txt_AK_IKATNOTARIS.Text + "','" + 
				txt_AK_IKATFEO.Text + "'," + 
				GlobalTools.ConvertNull(txt_AK_IKATNILAI.Text) + "," +				
				GlobalTools.ToSQLDate(txt_AK_IKATDATE_DD.Text, ddl_AK_IKATDATE_MM.SelectedValue, txt_AK_IKATDATE_YY.Text) + ",'" +
				txt_AK_IKATPADA.Text + "','" +	
				txt_AK_ABHASIL.Text + "'," +
				GlobalTools.ToSQLDate(txt_AK_ABDATE_DD.Text, ddl_AK_ABDATE_MM.SelectedValue, txt_AK_ABDATE_YY.Text) + ",'" +
				txt_AK_ABKANTOR.Text + "','" + 
				txt_AK_ABPEJABAT.Text + "','" + 
				ddl_AK_INSRSTATUS.SelectedValue + "','" +	
				txt_AK_INSRCOVER.Text + "'," +	
				GlobalTools.ConvertNull(txt_AK_INSRAMOUNT.Text) + ",'" + 
				txt_AK_INSRCOMP.Text + "'," +
				GlobalTools.ToSQLDate(txt_AK_INSRDATE_DD.Text, ddl_AK_INSRDATE_MM.SelectedValue, txt_AK_INSRDATE_YY.Text) + "," +
				GlobalTools.ConvertNull(txt_AK_DATA1.Text) + "," + 
				GlobalTools.ConvertNull(txt_AK_DATA2.Text) + "," + 
				GlobalTools.ConvertNull(txt_AK_DATA3.Text) + ",'" +	
				txt_AK_NAMA1.Text + "','" + 
				txt_AK_NAMA2.Text + "','" + 
				txt_AK_NAMA3.Text + "','" +
				txt_AK_ALAMAT1.Text + "','" + 
				txt_AK_ALAMAT2.Text + "','" + 
				txt_AK_ALAMAT3.Text + "','" +
				txt_AK_TGL1.Text + "','" + 
				txt_AK_TGL2.Text + "','" +	
				txt_AK_TGL3.Text + "','" +
				ddl_Tujuan.SelectedValue + "','" +
				ddl_AK_MARKET.SelectedValue + "','" + 
				ddl_AK_IKATAN.SelectedValue + "','" + 
				ddl_AK_MASALAH.SelectedValue + "','" +				
				ddl_AK_KUASA.SelectedValue + "','" + 
				txt_AK_LAIN.Text + "','" + 
				txt_AK_PENDAPAT.Text +"',''";			
	
//			try
//			{
				conn.ExecuteNonQuery();

				//-----------------------------------------------------------------simpan ke APPR_LIST
				conn.QueryString = "EXEC SP_APPR_LIST 'Save','" + lbl_AP_REGNO.Text + "','" + lbl_CU_REF.Text + "','" + 
					lbl_CL_SEQ.Text + "','2','Kendaraan'";
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
				conn.QueryString = "SP_APPR_KENDARAAN 'Save','" + 
					lbl_AP_REGNO.Text + "','"+ 
					lbl_CU_REF.Text + "','" +				
					lbl_CL_SEQ.Text + "','" +  
					txt_AK_APPRBY1.Text + "','" + 
					txt_AK_APPRBY2.Text + "'," +
					GlobalTools.ToSQLDate(txt_AK_APPRDATE_DD.Text, ddl_AK_APPRDATE_MM.SelectedValue, txt_AK_APPRDATE_YY.Text) + ",'" +
					txt_AK_NMDEBITUR.Text + "','" + 
					txt_AK_LOKJLN.Text + "','" + 
					txt_AK_LOKDESA.Text + "','" +  
					txt_AK_LOKKEC.Text + "','" +
					txt_AK_LOKKAB.Text + "','" + 
					ddl_AK_JNSAGUNAN.SelectedValue + "','" +	
					ddl_AK_ISNEW.SelectedValue + "','" +
					ddl_AK_UMUR.SelectedValue + "','" +
					txt_AK_MERK.Text + "','" +	 
					txt_AK_TIPE.Text + "','" + 
					txt_AK_JENIS.Text + "'," + 
					GlobalTools.ConvertNull(txt_AK_THNBELI.Text) + ",'" +
					ddl_AK_KONDISI.SelectedValue + "','" +	
					ddl_AK_PERWATAN.SelectedValue + "','" + 
					ddl_AK_BANJIR.SelectedValue + "','" +
					ddl_AK_PENCURIAN.SelectedValue + "','" + 
					ddl_AK_KEBAKARAN.SelectedValue + "','" +	
					ddl_AK_BPKB.SelectedValue + "','" + 
					txt_AK_BKNO.Text + "'," +					
					GlobalTools.ToSQLDate(txt_AK_BKDATE_DD.Text, ddl_AK_BKDATE_MM.SelectedValue, txt_AK_BKDATE_YY.Text) + ",'" +
					txt_AK_FAKTURBRG.Text + "','" + 
					ddl_AK_IKATSTAT.SelectedValue + "','" + 
					txt_AK_IKATNO.Text + "','" +
					txt_AK_IKATNOTARIS.Text + "','" + 
					txt_AK_IKATFEO.Text + "'," + 
					GlobalTools.ConvertNull(txt_AK_IKATNILAI.Text) + "," +				
					GlobalTools.ToSQLDate(txt_AK_IKATDATE_DD.Text, ddl_AK_IKATDATE_MM.SelectedValue, txt_AK_IKATDATE_YY.Text) + ",'" +
					txt_AK_IKATPADA.Text + "','" +	
					txt_AK_ABHASIL.Text + "'," +
					GlobalTools.ToSQLDate(txt_AK_ABDATE_DD.Text, ddl_AK_ABDATE_MM.SelectedValue, txt_AK_ABDATE_YY.Text) + ",'" +
					txt_AK_ABKANTOR.Text + "','" + 
					txt_AK_ABPEJABAT.Text + "','" + 
					ddl_AK_INSRSTATUS.SelectedValue + "','" +	
					txt_AK_INSRCOVER.Text + "'," +	
					GlobalTools.ConvertNull(txt_AK_INSRAMOUNT.Text) + ",'" + 
					txt_AK_INSRCOMP.Text + "'," +
					GlobalTools.ToSQLDate(txt_AK_INSRDATE_DD.Text, ddl_AK_INSRDATE_MM.SelectedValue, txt_AK_INSRDATE_YY.Text) + "," +
					GlobalTools.ConvertNull(txt_AK_DATA1.Text) + "," + 
					GlobalTools.ConvertNull(txt_AK_DATA2.Text) + "," + 
					GlobalTools.ConvertNull(txt_AK_DATA3.Text) + ",'" +	
					txt_AK_NAMA1.Text + "','" + 
					txt_AK_NAMA2.Text + "','" + 
					txt_AK_NAMA3.Text + "','" +
					txt_AK_ALAMAT1.Text + "','" + 
					txt_AK_ALAMAT2.Text + "','" + 
					txt_AK_ALAMAT3.Text + "','" +
					txt_AK_TGL1.Text + "','" + 
					txt_AK_TGL2.Text + "','" +	
					txt_AK_TGL3.Text + "','" +
					ddl_Tujuan.SelectedValue + "','" +
					ddl_AK_MARKET.SelectedValue + "','" + 
					ddl_AK_IKATAN.SelectedValue + "','" + 
					ddl_AK_MASALAH.SelectedValue + "','" +				
					ddl_AK_KUASA.SelectedValue + "','" + 
					txt_AK_LAIN.Text + "','" + 
					txt_AK_PENDAPAT.Text +"','1'";			

//				try
//				{
					conn.ExecuteNonQuery();

					//-----------------------------------------------------------------simpan ke APPR_LIST
					conn.QueryString = "EXEC SP_APPR_LIST 'Save','" + lbl_AP_REGNO.Text + "','" + lbl_CU_REF.Text + "','" + 
						lbl_CL_SEQ.Text + "','2','Kendaraan'";
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

		private void Kalkulasi()
		{
			int Kondisi, Perawatan,Score;
			double HargaPasar, SafetyMargin;

			//hitung: kondisi
			Kondisi = int.Parse(ddl_AK_KONDISI.SelectedValue);

			//hitung: perawatan
			Perawatan = int.Parse(ddl_AK_PERWATAN.SelectedValue);

			//hitung: score
			Score = Kondisi + Perawatan;
			txt_Score.Text = Score.ToString();
		

			//hitung: harga pasar keseluruhan
			HargaPasar = Double.Parse(txt_AK_DATA1.Text) * 0.30 + 
				Double.Parse(txt_AK_DATA2.Text) * 0.30 + 
				Double.Parse(txt_AK_DATA3.Text) * 0.40;
			txt_AK_HRGPASAR.Text = GlobalTools.MoneyFormat(HargaPasar.ToString());


			//hitung: safety margin
			if (ddl_AK_JNSAGUNAN.SelectedItem.Text == "Kendaraan Umum")
			{
				if (Score <= 3)
					SafetyMargin = 0.20;
				else if (Score > 3 && Score < 6)
					SafetyMargin = 0.25;
				else if (Score == 6)
					SafetyMargin = 0.30;
				else if (Score == 7)
					SafetyMargin = 0.35;
				else if (Score == 8)
					SafetyMargin = 0.40;
				else if (Score == 9)
					SafetyMargin = 0.50;
				else
					SafetyMargin = 0.75;
			}
			else
			{
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
			}

			if (ddl_Tujuan.SelectedItem.ToString() == "Penebusan Agunan")
				SafetyMargin = 0;

			if (ddl_AK_ISNEW.SelectedIndex == 0)
				SafetyMargin = 0;

			txt_AK_SFTYMARGIN.Text = Strings.Format(SafetyMargin,"0.0%");

		
			//hitung: nilai pasar yang dapat di terima bank
			txt_AK_HRGWAJAR.Text =  GlobalTools.MoneyFormat(Convert.ToString((HargaPasar * (1 - SafetyMargin))));
		
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
			else if (txt_AK_APPRDATE_YY.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Tanggal Periksa harus diisi');</script>");
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


		private void DisabledEntry()
		{
			txt_AK_LOKJLN.ReadOnly = true;
			txt_AK_LOKDESA.ReadOnly = true;
			txt_AK_LOKKEC.ReadOnly = true;
			txt_AK_LOKKAB.ReadOnly = true;
			txt_AK_APPRDATE_DD.ReadOnly = true;
			ddl_AK_APPRDATE_MM.Enabled = false;
			txt_AK_APPRDATE_YY.ReadOnly = true;
			txt_AK_APPRBY1.ReadOnly = true;
			txt_AK_APPRBY2.ReadOnly = true;
			ddl_AK_JNSAGUNAN.Enabled = false;
			txt_AK_THNBELI.ReadOnly = true;
			ddl_AK_ISNEW.Enabled = false;
			ddl_AK_UMUR.Enabled = false;
			txt_AK_MERK.ReadOnly = true;
			txt_AK_TIPE.ReadOnly = true;
			txt_AK_JENIS.ReadOnly = true;
			ddl_AK_KONDISI.Enabled = false;
			ddl_AK_PERWATAN.Enabled = false;
			ddl_AK_BANJIR.Enabled = false;
			ddl_AK_PENCURIAN.Enabled = false;
			ddl_AK_KEBAKARAN.Enabled = false;
			ddl_AK_BPKB.Enabled = false;
			txt_AK_BKNO.ReadOnly = true;
			txt_AK_BKDATE_DD.ReadOnly = true;
			ddl_AK_BKDATE_MM.Enabled = false;
			txt_AK_BKDATE_YY.ReadOnly = true;
			txt_AK_FAKTURBRG.ReadOnly = true;
			ddl_AK_IKATSTAT.Enabled = false;
			txt_AK_IKATNO.ReadOnly = true;
			txt_AK_IKATNOTARIS.ReadOnly = true;
			txt_AK_IKATFEO.ReadOnly = true;
			txt_AK_IKATDATE_DD.ReadOnly = true;
			ddl_AK_IKATDATE_MM.Enabled = false;
			txt_AK_IKATDATE_YY.ReadOnly = true;
			txt_AK_IKATNILAI.ReadOnly = true;
			txt_AK_IKATPADA.ReadOnly = true;
			txt_AK_ABHASIL.ReadOnly = true;
			txt_AK_ABDATE_DD.ReadOnly = true;
			ddl_AK_ABDATE_MM.Enabled = false;
			txt_AK_ABDATE_YY.ReadOnly = true;
			txt_AK_ABKANTOR.ReadOnly = true;
			txt_AK_ABPEJABAT.ReadOnly = true;
			ddl_AK_INSRSTATUS.Enabled = false;
			txt_AK_INSRCOVER.ReadOnly = true;
			txt_AK_INSRAMOUNT.ReadOnly = true;
			txt_AK_INSRDATE_DD.ReadOnly = true;
			ddl_AK_INSRDATE_MM.Enabled = false;
			txt_AK_INSRDATE_YY.ReadOnly = true;
			txt_AK_INSRCOMP.ReadOnly = true;
			txt_AK_DATA1.ReadOnly = true;
			txt_AK_DATA2.ReadOnly = true;
			txt_AK_DATA3.ReadOnly = true;
			txt_AK_NAMA1.ReadOnly = true;
			txt_AK_NAMA2.ReadOnly = true;
			txt_AK_NAMA3.ReadOnly = true;
			txt_AK_ALAMAT1.ReadOnly = true;
			txt_AK_ALAMAT2.ReadOnly = true;
			txt_AK_ALAMAT3.ReadOnly = true;
			txt_AK_TGL1.ReadOnly = true;
			txt_AK_TGL2.ReadOnly = true;
			txt_AK_TGL3.ReadOnly = true;
			ddl_Tujuan.Enabled = false;
			ddl_AK_MARKET.Enabled = false;
			ddl_AK_IKATAN.Enabled = false;
			ddl_AK_MASALAH.Enabled = false;
			ddl_AK_KUASA.Enabled = false;
			txt_AK_LAIN.ReadOnly = true;
			txt_AK_PENDAPAT.ReadOnly = true;
		
			btn_Calc.Visible = false;
		}


		private void btn_Reentry_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "update LISTASSIGNMENT set LA_APPRSTATUS = '2' where AP_REGNO = '" +lbl_AP_REGNO.Text+
				"' and CU_REF = '" + lbl_CU_REF.Text+ "' and CL_SEQ = "+lbl_CL_SEQ.Text;
			conn.ExecuteQuery();
			ViewData();
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
			//-----------------------------------------------------------------hapus dari APPR_KENDARAAN
			conn.QueryString = "SP_APPR_KENDARAAN 'Delete','" + 
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
