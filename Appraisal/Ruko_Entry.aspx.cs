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
	/// Summary description for Ruko_Entry.
	/// </summary>
	public partial class Ruko_Entry : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.DropDownList DDL_UMUR;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_TC.Text = Request.QueryString["tc"];
				LBL_CL_SEQ.Text = Request.QueryString["cl_seq"];
				
				DDL_AR_APPRDATEMONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_COLCLASSIFY.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_LINGKUNGAN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_PENGUASAAN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_BANJIR.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_TEGANGAN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_TNHLONGSOR.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_PENCEMARAN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_PEMELIHARAANBGN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_JNSHAK.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_INSRSTATUS.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_INSREXPDATEMONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_SERTEXPDATEMONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_CEKBPNDATEMONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_MSLHYURIDIS.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_DIIKATEFEKTIF.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_WILAYAH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_LOKASI.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_MARKETABILITY.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_KONDISI.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_KAYU.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_LANTAI.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_UMUR.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AR_FOTO.Items.Add(new ListItem("-- Pilih --", ""));
				
				string nm_bln;
				for (int i=1; i<=12; i++)
				{
					nm_bln = DateAndTime.MonthName(i, false);
					DDL_AR_APPRDATEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_AR_INSREXPDATEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_AR_SERTEXPDATEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
				}

				int jml_row;
				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AR_COLCLASSIFY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select LINGID, LINGDESC from RFLINGKUNGAN ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AR_LINGKUNGAN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select KUASAID, KUASADESC from RFPENGUASAAN ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AR_PENGUASAAN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				DDL_AR_BANJIR.Items.Add(new ListItem("Ya", "1"));
				DDL_AR_BANJIR.Items.Add(new ListItem("Tidak", "0"));

				DDL_AR_TEGANGAN.Items.Add(new ListItem("Ya", "1"));
				DDL_AR_TEGANGAN.Items.Add(new ListItem("Tidak", "0"));

				DDL_AR_TNHLONGSOR.Items.Add(new ListItem("Ya", "1"));
				DDL_AR_TNHLONGSOR.Items.Add(new ListItem("Tidak", "0"));

				DDL_AR_PENCEMARAN.Items.Add(new ListItem("Ya", "1"));
				DDL_AR_PENCEMARAN.Items.Add(new ListItem("Tidak", "0"));
				

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AR_PEMELIHARAANBGN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AR_JNSHAK.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				DDL_AR_INSRSTATUS.Items.Add(new ListItem("Telah", "1"));
				DDL_AR_INSRSTATUS.Items.Add(new ListItem("Belum", "0"));
					
				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AR_MSLHYURIDIS.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				
				DDL_AR_DIIKATEFEKTIF.Items.Add(new ListItem("Dapat", "1"));
				DDL_AR_DIIKATEFEKTIF.Items.Add(new ListItem("Tidak Dapat", "0"));

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AR_WILAYAH.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AR_LOKASI.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AR_KONDISI.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AR_KAYU.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AR_LANTAI.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AR_UMUR.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				
				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AR_MARKETABILITY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				DDL_AR_FOTO.Items.Add(new ListItem("Ya", "1"));
				DDL_AR_FOTO.Items.Add(new ListItem("Tidak", "0"));

				ViewData();
			}
			else
			{
				string V_STA = Request.Form["V_STA"];
				LBL_STA.Text = V_STA;
				Simpan(V_STA);
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

		private void ViewData()
		{
			conn.QueryString = "select * from VW_APPR_RUKO "+
				"where AP_REGNO = '"+ LBL_REGNO.Text +"' and CU_REF  = '"+ LBL_CUREF.Text +"' "+
				"and CL_SEQ  = "+ LBL_CL_SEQ.Text ;
			conn.ExecuteQuery();
			TXT_AR_APPRBY.Text = conn.GetFieldValue("AR_APPRBY");
			TXT_AR_APPRNM.Text = conn.GetFieldValue("AR_APPRNM");
			TXT_AR_APPRBR.Text = conn.GetFieldValue("AR_APPRBR");
			string AR_APPRDATE = conn.GetFieldValue("AR_APPRDATE");
			TXT_AR_APPRDATEDAY.Text = tool.FormatDate_Day(AR_APPRDATE);
			DDL_AR_APPRDATEMONTH.SelectedValue = tool.FormatDate_Month(AR_APPRDATE);
			TXT_AR_APPRDATEYEAR.Text = tool.FormatDate_Year(AR_APPRDATE);
			TXT_CU_NAME.Text = conn.GetFieldValue("CU_NAME");
			TXT_AR_PHNAREA.Text = conn.GetFieldValue("AR_PHNAREA");
			TXT_AR_PHNNUM.Text = conn.GetFieldValue("AR_PHNNUM");
			TXT_AR_PHNEXT.Text = conn.GetFieldValue("AR_PHNEXT");
			DDL_AR_COLCLASSIFY.SelectedValue = conn.GetFieldValue("AR_COLCLASSIFY");
			TXT_AR_ADDRJLN.Text = conn.GetFieldValue("AR_ADDRJLN");
			TXT_AR_ADDRDESA.Text = conn.GetFieldValue("AR_ADDRDESA");
			TXT_AR_ADDRKEC.Text = conn.GetFieldValue("AR_ADDRKEC");
			TXT_AR_ADDRKAB.Text = conn.GetFieldValue("AR_ADDRKAB");
			TXT_AR_LOKJLN.Text = conn.GetFieldValue("AR_LOKJLN");
			TXT_AR_LOKDESA.Text = conn.GetFieldValue("AR_LOKDESA");
			TXT_AR_LOKKEC.Text = conn.GetFieldValue("AR_LOKKEC");
			TXT_AR_LOKKAB.Text = conn.GetFieldValue("AR_LOKKAB");
			TXT_AR_LNTBLOK.Text = conn.GetFieldValue("AR_LNTBLOK");
			TXT_AR_LUASBANGUN.Text = conn.GetFieldValue("AR_LUASBANGUN");
			TXT_AR_IJINNO.Text = conn.GetFieldValue("AR_IJINNO");
			TXT_AR_THNBUAT.Text = conn.GetFieldValue("AR_THNBUAT");
			TXT_AR_PENGEMBANG.Text = conn.GetFieldValue("AR_PENGEMBANG");
			DDL_AR_LINGKUNGAN.SelectedValue = conn.GetFieldValue("AR_LINGKUNGAN");
			TXT_AR_KETLINGKUNGAN.Text = conn.GetFieldValue("AR_KETLINGKUNGAN");
			DDL_AR_PENGUASAAN.SelectedValue = conn.GetFieldValue("AR_PENGUASAAN");
			CHB_AR_LISTRIK.Checked = tool.ConvertCheck(conn.GetFieldValue("AR_LISTRIK"));
			TXT_AR_KETLISTRIK.Text = conn.GetFieldValue("AR_KETLISTRIK");
			CHB_AR_AC.Checked = tool.ConvertCheck(conn.GetFieldValue("AR_AC"));
			TXT_AR_KETAC.Text = conn.GetFieldValue("AR_KETAC");
			CHB_AR_AIR.Checked = tool.ConvertCheck(conn.GetFieldValue("AR_AIR"));
			TXT_AR_KETAIR.Text = conn.GetFieldValue("AR_KETAIR");
			CHB_AR_TELPFAX.Checked = tool.ConvertCheck(conn.GetFieldValue("AR_TELPFAX"));
			TXT_AR_KETTELPFAX.Text = conn.GetFieldValue("AR_KETTELPFAX");
			CHB_AR_PRASARANALAIN.Checked = tool.ConvertCheck(conn.GetFieldValue("AR_PRASARANALAIN"));
			TXT_AR_KETPRASARANALAIN.Text = conn.GetFieldValue("AR_KETPRASARANALAIN");
			DDL_AR_BANJIR.SelectedValue = conn.GetFieldValue("AR_BANJIR");
			DDL_AR_TEGANGAN.SelectedValue = conn.GetFieldValue("AR_TEGANGAN");
			DDL_AR_TNHLONGSOR.SelectedValue = conn.GetFieldValue("AR_TNHLONGSOR");
			DDL_AR_PENCEMARAN.SelectedValue = conn.GetFieldValue("AR_PENCEMARAN");
			TXT_AR_RESLAIN.Text = conn.GetFieldValue("AR_RESLAIN");
			DDL_AR_PEMELIHARAANBGN.SelectedValue = conn.GetFieldValue("AR_PEMELIHARAANBGN");
			DDL_AR_JNSHAK.SelectedValue = conn.GetFieldValue("AR_JNSHAK");
			TXT_AR_KETJNSHAK.Text = conn.GetFieldValue("AR_KETJNSHAK");
			DDL_AR_INSRSTATUS.SelectedValue = conn.GetFieldValue("AR_INSRSTATUS");
			TXT_AR_INSRTUTUP.Text = conn.GetFieldValue("AR_INSRTUTUP");
			TXT_AR_INSRAMOUNT.Text = tool.ConvertCurr(conn.GetFieldValue("AR_INSRAMOUNT"));
			string AR_INSREXPDATE = conn.GetFieldValue("AR_INSREXPDATE");
			TXT_AR_INSREXPDATEDAY.Text = tool.FormatDate_Day(AR_INSREXPDATE);
			DDL_AR_INSREXPDATEMONTH.SelectedValue = tool.FormatDate_Month(AR_INSREXPDATE);
			TXT_AR_INSREXPDATEYEAR.Text = tool.FormatDate_Year(AR_INSREXPDATE);
			TXT_AR_INSRCOMP.Text = conn.GetFieldValue("AR_INSRCOMP");
			CHB_AR_SERTIFIKAT.Checked = tool.ConvertCheck(conn.GetFieldValue("AR_SERTIFIKAT"));
			TXT_AR_SERTNO.Text = conn.GetFieldValue("AR_SERTNO");
			string AR_SERTEXPDATE = conn.GetFieldValue("AR_SERTEXPDATE");
			TXT_AR_SERTEXPDATEDAY.Text = tool.FormatDate_Day(AR_SERTEXPDATE);
			DDL_AR_SERTEXPDATEMONTH.SelectedValue = tool.FormatDate_Month(AR_SERTEXPDATE);
			TXT_AR_SERTEXPDATEYEAR.Text = tool.FormatDate_Year(AR_SERTEXPDATE);
			TXT_AR_SERTATASNAMA.Text = conn.GetFieldValue("AR_SERTATASNAMA");
			CHB_AR_AKTEJLBL.Checked = tool.ConvertCheck(conn.GetFieldValue("AR_AKTEJLBL"));
			TXT_AR_AKTEJLBLNO.Text = conn.GetFieldValue("AR_AKTEJLBLNO");
			TXT_AR_CEKBPNHSL.Text = conn.GetFieldValue("AR_CEKBPNHSL");
			string AR_CEKBPNDATE = conn.GetFieldValue("AR_CEKBPNDATE");
			TXT_AR_CEKBPNDATEDAY.Text = tool.FormatDate_Day(AR_CEKBPNDATE);
			DDL_AR_CEKBPNDATEMONTH.SelectedValue = tool.FormatDate_Month(AR_CEKBPNDATE);
			TXT_AR_CEKBPNDATEYEAR.Text = tool.FormatDate_Year(AR_CEKBPNDATE);
			TXT_AR_PEJABAT.Text = conn.GetFieldValue("AR_PEJABAT");
			CHB_AR_BEBASIKAT.Checked = tool.ConvertCheck(conn.GetFieldValue("AR_BEBASIKAT"));
			TXT_AR_AKTEIKATNO.Text = conn.GetFieldValue("AR_AKTEIKATNO");
			TXT_AR_AKTEIKATADDR.Text = conn.GetFieldValue("AR_AKTEIKATADDR");
			DDL_AR_MSLHYURIDIS.SelectedValue = conn.GetFieldValue("AR_MSLHYURIDIS");
			DDL_AR_DIIKATEFEKTIF.SelectedValue = conn.GetFieldValue("AR_DIIKATEFEKTIF");
			TXT_AR_HRGNJOP.Text = tool.ConvertCurr(conn.GetFieldValue("AR_HRGNJOP"));
			TXT_AR_HRGPASAR.Text = tool.ConvertCurr(conn.GetFieldValue("AR_HRGPASAR"));
			TXT_AR_HRGTAKSASI.Text = tool.ConvertCurr(conn.GetFieldValue("AR_HRGTAKSASI"));
			DDL_AR_WILAYAH.SelectedValue = conn.GetFieldValue("AR_WILAYAH");
			DDL_AR_LOKASI.SelectedValue = conn.GetFieldValue("AR_LOKASI");
			DDL_AR_MARKETABILITY.SelectedValue = conn.GetFieldValue("AR_MARKETABILITY");
			DDL_AR_KONDISI.SelectedValue = conn.GetFieldValue("AR_KONDISI");
			DDL_AR_KAYU.SelectedValue = conn.GetFieldValue("AR_KAYU");
			DDL_AR_LANTAI.SelectedValue = conn.GetFieldValue("AR_LANTAI");
			DDL_AR_UMUR.SelectedValue = conn.GetFieldValue("AR_UMUR");
			TXT_AR_SFTYMARGIN.Text = conn.GetFieldValue("AR_SFTYMARGIN");
			TXT_AR_TAKSASISTLHSMARGIN.Text = tool.ConvertCurr(conn.GetFieldValue("AR_TAKSASISTLHSMARGIN"));
			DDL_AR_FOTO.SelectedValue = conn.GetFieldValue("AR_FOTO");
			TXT_AR_KETJAMINAN.Text = conn.GetFieldValue("AR_KETJAMINAN");
			CHB_AR_MARKETSALE.Checked = tool.ConvertCheck(conn.GetFieldValue("AR_MARKETSALE"));
			CHB_AR_MARKET.Checked = tool.ConvertCheck(conn.GetFieldValue("AR_MARKET"));
			CHB_AR_BISAIKAT.Checked = tool.ConvertCheck(conn.GetFieldValue("AR_BISAIKAT"));
			CHB_AR_BLMBISAIKAT.Checked = tool.ConvertCheck(conn.GetFieldValue("AR_BLMBISAIKAT"));
			CHB_AR_SENGKETA.Checked = tool.ConvertCheck(conn.GetFieldValue("AR_SENGKETA"));
			CHB_AR_KESLAIN.Checked = tool.ConvertCheck(conn.GetFieldValue("AR_KESLAIN"));
			TXT_AR_KETKESLAIN.Text = conn.GetFieldValue("AR_KETKESLAIN");
			if ((conn.GetFieldValue("AR_APPRBY") == "") || (conn.GetFieldValue("AR_APPRBY").Equals(null)))
			{
				//string USERID = Session["USERID"];
				string USERID = "";
				if (USERID == "")
					USERID = "eva";
				conn.QueryString = "select SU_FULLNAME AR_APPRNM, BR.BRANCH_NAME AR_APPRBR "+
					"from SCUSER SU "+
					"left join RFBRANCH BR on BR.BRANCH_CODE = SU.SU_BRANCH "+
					"where SU.USERID = '"+ USERID +"' ";
				conn.ExecuteQuery();
				
				TXT_AR_APPRBY.Text = USERID;
				TXT_AR_APPRNM.Text = conn.GetFieldValue("AR_APPRNM");
				TXT_AR_APPRBR.Text = conn.GetFieldValue("AR_APPRBR");
				AR_APPRDATE = DateAndTime.Today.ToString();
				TXT_AR_APPRDATEDAY.Text		= tool.FormatDate_Day(AR_APPRDATE);
				DDL_AR_APPRDATEMONTH.SelectedValue	= tool.FormatDate_Month(AR_APPRDATE);
				TXT_AR_APPRDATEYEAR.Text	= tool.FormatDate_Year(AR_APPRDATE);

				conn.QueryString = "select case when isnull(CU_COMPNAME, '') = ''  "+
					"then CU_FIRSTNAME +' '+ CU_MIDDLENAME +' '+ CU_LASTNAME "+
					"else isnull(CU_COMPNAME, '') end CU_NAME "+
					"from CUSTOMER CU "+
					"left join CUST_COMPANY CC on CU.CU_REF = CC.CU_REF "+
					"left join CUST_PERSONAL CP on CU.CU_REF = CP.CU_REF "+
					"where CU.CU_REF = '"+ LBL_CUREF.Text +"' ";
				conn.ExecuteQuery();
				TXT_CU_NAME.Text = conn.GetFieldValue("CU_NAME");
			}
		}

		private void Simpan(string vsta)
		{
			conn.QueryString = "exec APPR_ENTRY_RUKO '"+ vsta +"', '"+ LBL_REGNO.Text +"', '"+ LBL_CUREF.Text +"', '"+
				LBL_CL_SEQ.Text +"', '"+ TXT_AR_APPRBY.Text +"', "+
				tool.ConvertDate(TXT_AR_APPRDATEDAY.Text, DDL_AR_APPRDATEMONTH.SelectedValue, TXT_AR_APPRDATEYEAR.Text) +", "+
				tool.ConvertNull(DDL_AR_COLCLASSIFY.SelectedValue) +", '"+ TXT_AR_ADDRJLN.Text +"', '"+ TXT_AR_ADDRDESA.Text +"', '"+ 
				TXT_AR_ADDRKEC.Text +"', '"+ TXT_AR_ADDRKAB.Text +"', '"+ TXT_AR_PHNAREA.Text +"', '"+ TXT_AR_PHNNUM.Text +"', '"+
				TXT_AR_PHNEXT.Text +"', '"+ TXT_AR_LOKJLN.Text +"', '"+
				TXT_AR_LOKDESA.Text +"', '"+ TXT_AR_LOKKEC.Text +"', '"+ TXT_AR_LOKKAB.Text +"', '"+ 
				TXT_AR_LNTBLOK.Text +"', "+ tool.ConvertNum(TXT_AR_LUASBANGUN.Text) +", '"+ TXT_AR_IJINNO.Text +"', "+ 
				tool.ConvertNum(TXT_AR_THNBUAT.Text) +", '"+ TXT_AR_PENGEMBANG.Text +"', "+ 
				tool.ConvertNull(DDL_AR_LINGKUNGAN.SelectedValue) +", '"+ TXT_AR_KETLINGKUNGAN.Text +"', "+ 
				tool.ConvertNull(DDL_AR_PENGUASAAN.SelectedValue) +", '"+ tool.ConvertFlag(CHB_AR_LISTRIK.Checked) +"', "+ 
				tool.ConvertNum(TXT_AR_KETLISTRIK.Text) +", '"+ tool.ConvertFlag(CHB_AR_AC.Checked) +"', "+ 
				tool.ConvertNum(TXT_AR_KETAC.Text) +", '"+ tool.ConvertFlag(CHB_AR_AIR.Checked) +"', '"+ 
				TXT_AR_KETAIR.Text +"', '"+ tool.ConvertFlag(CHB_AR_TELPFAX.Checked) +"', "+ tool.ConvertNum(TXT_AR_KETTELPFAX.Text) +", '"+ 
				tool.ConvertFlag(CHB_AR_PRASARANALAIN.Checked) +"', '"+ TXT_AR_KETPRASARANALAIN.Text +"', '"+ 
				DDL_AR_BANJIR.SelectedValue +"', '"+ DDL_AR_TEGANGAN.SelectedValue +"', '"+ DDL_AR_TNHLONGSOR.SelectedValue +"', '"+ DDL_AR_PENCEMARAN.SelectedValue +"', '"+ 
				TXT_AR_RESLAIN.Text +"', "+ tool.ConvertNull(DDL_AR_PEMELIHARAANBGN.SelectedValue) +", "+ tool.ConvertNull(DDL_AR_JNSHAK.SelectedValue) +", '"+ 
				TXT_AR_KETJNSHAK.Text +"', '"+ DDL_AR_INSRSTATUS.SelectedValue +"', '"+ TXT_AR_INSRTUTUP.Text +"', "+ 
				tool.ConvertNum(TXT_AR_INSRAMOUNT.Text) +", "+ 
				tool.ConvertDate(TXT_AR_INSREXPDATEDAY.Text, DDL_AR_INSREXPDATEMONTH.SelectedValue, TXT_AR_INSREXPDATEYEAR.Text) +", '"+ 
				TXT_AR_INSRCOMP.Text +"', '"+ tool.ConvertFlag(CHB_AR_SERTIFIKAT.Checked) +"', '"+ TXT_AR_SERTNO.Text +"', "+ 
				tool.ConvertDate(TXT_AR_SERTEXPDATEDAY.Text, DDL_AR_SERTEXPDATEMONTH.SelectedValue, TXT_AR_SERTEXPDATEYEAR.Text) +", '"+ 
				TXT_AR_SERTATASNAMA.Text +"', '"+ tool.ConvertFlag(CHB_AR_AKTEJLBL.Checked) +"', '"+ TXT_AR_AKTEJLBLNO.Text +"', '"+ 
				TXT_AR_CEKBPNHSL.Text +"', "+ 
				tool.ConvertDate(TXT_AR_CEKBPNDATEDAY.Text, DDL_AR_CEKBPNDATEMONTH.SelectedValue, TXT_AR_CEKBPNDATEYEAR.Text) +", '"+ 
				TXT_AR_PEJABAT.Text +"', '"+ tool.ConvertFlag(CHB_AR_BEBASIKAT.Checked) +"', '"+ TXT_AR_AKTEIKATNO.Text +"', '"+ 
				TXT_AR_AKTEIKATADDR.Text +"', "+ tool.ConvertNull(DDL_AR_MSLHYURIDIS.SelectedValue) +", '"+ DDL_AR_DIIKATEFEKTIF.SelectedValue +"', "+ 
				tool.ConvertNum(TXT_AR_HRGNJOP.Text) +", "+ tool.ConvertNum(TXT_AR_HRGPASAR.Text) +", "+ tool.ConvertNum(TXT_AR_HRGTAKSASI.Text) +", "+ 
				tool.ConvertNull(DDL_AR_WILAYAH.SelectedValue) +", "+ tool.ConvertNull(DDL_AR_LOKASI.SelectedValue) +", "+ tool.ConvertNull(DDL_AR_MARKETABILITY.SelectedValue) +", "+ 
				tool.ConvertNull(DDL_AR_KONDISI.SelectedValue) +", "+ tool.ConvertNull(DDL_AR_KAYU.SelectedValue) +", "+ tool.ConvertNull(DDL_AR_LANTAI.SelectedValue) +", "+ 
				tool.ConvertNull(DDL_AR_UMUR.SelectedValue) +", "+ tool.ConvertFloat(TXT_AR_SFTYMARGIN.Text) +", "+ 
				tool.ConvertNum(TXT_AR_TAKSASISTLHSMARGIN.Text) +", '"+ DDL_AR_FOTO.SelectedValue +"', '"+ TXT_AR_KETJAMINAN.Text +"', '"+ 
				tool.ConvertFlag(CHB_AR_MARKETSALE.Checked) +"', '"+ tool.ConvertFlag(CHB_AR_MARKET.Checked) +"', '"+ 
				tool.ConvertFlag(CHB_AR_BISAIKAT.Checked) +"', '"+ tool.ConvertFlag(CHB_AR_BLMBISAIKAT.Checked) +"', '"+ 
				tool.ConvertFlag(CHB_AR_SENGKETA.Checked) +"', '"+ tool.ConvertFlag(CHB_AR_KESLAIN.Checked) +"', '"+ 
				TXT_AR_KETKESLAIN.Text +"' ";
			
			conn.ExecuteQuery();
			if (vsta == "1")
				ViewData();
			else
			{
				conn.QueryString = "exec UPDATEAPPRAISALRESULT '" + Request.QueryString["regno"] + "', " + Request.QueryString["cl_seq"];
				conn.ExecuteNonQuery();

				Response.Redirect("ListAppraisal.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
				//Response.Redirect("List_Appraisal.aspx");
			}
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec UPDATEAPPRAISALRESULT '" + Request.QueryString["regno"] + "', " + Request.QueryString["cl_seq"];
			conn.ExecuteNonQuery();

			Response.Redirect("ListAppraisal.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}
	}
}

