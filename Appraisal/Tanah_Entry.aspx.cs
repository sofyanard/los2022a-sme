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
	/// Summary description for Tanah_Entry.
	/// </summary>
	public partial class Tanah_Entry : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_TC.Text = Request.QueryString["tc"];
				LBL_CL_SEQ.Text = Request.QueryString["cl_seq"];

				DDL_AT_APPRDATEMONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AT_COLCLASSIFY.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AT_KEADAANFSK.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AT_LINGKUNGAN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AT_PENGUASAAN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AT_BANJIR.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AT_TEGANGAN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AT_TNHLONGSOR.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AT_PENCEMARAN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AT_JNSHAK.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AT_SERTEXPDATEMONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AT_CEKBPNDATEMONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AT_MSLHYURIDIS.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AT_DIIKATEFEKTIF.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AT_WILAYAH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AT_LOKASI.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AT_MARKETABILITY.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AT_KUALITAS.Items.Add(new ListItem("-- Pilih --", ""));
								
				string nm_bln;
				for (int i=1; i<=12; i++)
				{
					nm_bln = DateAndTime.MonthName(i, false);
					DDL_AT_APPRDATEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_AT_SERTEXPDATEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
				}

				int jml_row;
				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AT_COLCLASSIFY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select LINGID, LINGDESC from RFLINGKUNGAN ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AT_KEADAANFSK.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select LINGID, LINGDESC from RFLINGKUNGAN ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AT_LINGKUNGAN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select KUASAID, KUASADESC from RFPENGUASAAN ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AT_PENGUASAAN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				DDL_AT_BANJIR.Items.Add(new ListItem("Ya", "1"));
				DDL_AT_BANJIR.Items.Add(new ListItem("Tidak", "0"));

				DDL_AT_TEGANGAN.Items.Add(new ListItem("Ya", "1"));
				DDL_AT_TEGANGAN.Items.Add(new ListItem("Tidak", "0"));

				DDL_AT_TNHLONGSOR.Items.Add(new ListItem("Ya", "1"));
				DDL_AT_TNHLONGSOR.Items.Add(new ListItem("Tidak", "0"));

				DDL_AT_PENCEMARAN.Items.Add(new ListItem("Ya", "1"));
				DDL_AT_PENCEMARAN.Items.Add(new ListItem("Tidak", "0"));
				
				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AT_JNSHAK.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AT_MSLHYURIDIS.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				
				DDL_AT_DIIKATEFEKTIF.Items.Add(new ListItem("Dapat", "1"));
				DDL_AT_DIIKATEFEKTIF.Items.Add(new ListItem("Tidak Dapat", "0"));

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AT_WILAYAH.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AT_LOKASI.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AT_KUALITAS.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AT_MARKETABILITY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
			
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
			conn.QueryString = "select * from VW_APPR_TANAH "+
				"where AP_REGNO = '"+ LBL_REGNO.Text +"' and CU_REF  = '"+ LBL_CUREF.Text +"' "+
				"and CL_SEQ  = "+ LBL_CL_SEQ.Text ;
			conn.ExecuteQuery();
			TXT_AT_APPRBY.Text = conn.GetFieldValue("AT_APPRBY");
			TXT_AT_APPRNM.Text = conn.GetFieldValue("AT_APPRNM");
			TXT_AT_APPRBR.Text = conn.GetFieldValue("AT_APPRBR");
			string AT_APPRDATE = conn.GetFieldValue("AT_APPRDATE");
			TXT_AT_APPRDATEDAY.Text = tool.FormatDate_Day(AT_APPRDATE);
			DDL_AT_APPRDATEMONTH.SelectedValue = tool.FormatDate_Month(AT_APPRDATE);
			TXT_AT_APPRDATEYEAR.Text = tool.FormatDate_Year(AT_APPRDATE);
			TXT_CU_NAME.Text = conn.GetFieldValue("CU_NAME");
			TXT_AT_PHNAREA.Text = conn.GetFieldValue("AT_PHNAREA");
			TXT_AT_PHNNUM.Text = conn.GetFieldValue("AT_PHNNUM");
			TXT_AT_PHNEXT.Text = conn.GetFieldValue("AT_PHNEXT");
			DDL_AT_COLCLASSIFY.SelectedValue = conn.GetFieldValue("AT_COLCLASSIFY");
			TXT_AT_ADDRJLN.Text = conn.GetFieldValue("AT_ADDRJLN");
			TXT_AT_ADDRDESA.Text = conn.GetFieldValue("AT_ADDRDESA");
			TXT_AT_ADDRKEC.Text = conn.GetFieldValue("AT_ADDRKEC");
			TXT_AT_ADDRKAB.Text = conn.GetFieldValue("AT_ADDRKAB");
			TXT_AT_LOKJLN.Text = conn.GetFieldValue("AT_LOKJLN");
			TXT_AT_LOKDESA.Text = conn.GetFieldValue("AT_LOKDESA");
			TXT_AT_LOKKEC.Text = conn.GetFieldValue("AT_LOKKEC");
			TXT_AT_LOKKAB.Text = conn.GetFieldValue("AT_LOKKAB");
			TXT_AT_LUASTNH.Text = conn.GetFieldValue("AT_LUASTNH");
			TXT_AT_PJGTNH.Text = conn.GetFieldValue("AT_PJGTNH");
			TXT_AT_LBRTNH.Text = conn.GetFieldValue("AT_LBRTNH");
			DDL_AT_KEADAANFSK.SelectedValue = conn.GetFieldValue("AT_KEADAANFSK");
			DDL_AT_LINGKUNGAN.SelectedValue = conn.GetFieldValue("AT_LINGKUNGAN");
			TXT_AT_KETLINGKUNGAN.Text = conn.GetFieldValue("AT_KETLINGKUNGAN");
			DDL_AT_PENGUASAAN.SelectedValue = conn.GetFieldValue("AT_PENGUASAAN");
			CHB_AT_LISTRIK.Checked = tool.ConvertCheck(conn.GetFieldValue("AT_LISTRIK"));
			TXT_AT_KETLISTRIK.Text = conn.GetFieldValue("AT_KETLISTRIK");
			CHB_AT_AC.Checked = tool.ConvertCheck(conn.GetFieldValue("AT_AC"));
			TXT_AT_KETAC.Text = conn.GetFieldValue("AT_KETAC");
			CHB_AT_AIR.Checked = tool.ConvertCheck(conn.GetFieldValue("AT_AIR"));
			TXT_AT_KETAIR.Text = conn.GetFieldValue("AT_KETAIR");
			CHB_AT_TELPFAX.Checked = tool.ConvertCheck(conn.GetFieldValue("AT_TELPFAX"));
			TXT_AT_KETTELPFAX.Text = conn.GetFieldValue("AT_KETTELPFAX");
			DDL_AT_BANJIR.SelectedValue = conn.GetFieldValue("AT_BANJIR");
			DDL_AT_TEGANGAN.SelectedValue = conn.GetFieldValue("AT_TEGANGAN");
			DDL_AT_TNHLONGSOR.SelectedValue = conn.GetFieldValue("AT_TNHLONGSOR");
			DDL_AT_PENCEMARAN.SelectedValue = conn.GetFieldValue("AT_PENCEMARAN");
			TXT_AT_RESLAIN.Text = conn.GetFieldValue("AT_RESLAIN");
			DDL_AT_JNSHAK.SelectedValue = conn.GetFieldValue("AT_JNSHAK");
			TXT_AT_KETJNSHAK.Text = conn.GetFieldValue("AT_KETJNSHAK");
			CHB_AT_SERTIFIKAT.Checked = tool.ConvertCheck(conn.GetFieldValue("AT_SERTIFIKAT"));
			TXT_AT_SERTNO.Text = conn.GetFieldValue("AT_SERTNO");
			string AT_SERTEXPDATE = conn.GetFieldValue("AT_SERTEXPDATE");
			TXT_AT_SERTEXPDATEDAY.Text = tool.FormatDate_Day(AT_SERTEXPDATE);
			DDL_AT_SERTEXPDATEMONTH.SelectedValue = tool.FormatDate_Month(AT_SERTEXPDATE);
			TXT_AT_SERTEXPDATEYEAR.Text = tool.FormatDate_Year(AT_SERTEXPDATE);
			TXT_AT_SERTATASNAMA.Text = conn.GetFieldValue("AT_SERTATASNAMA");
			CHB_AT_AKTEJLBL.Checked = tool.ConvertCheck(conn.GetFieldValue("AT_AKTEJLBL"));
			TXT_AT_AKTEJLBLNO.Text = conn.GetFieldValue("AT_AKTEJLBLNO");
			TXT_AT_CEKBPNHSL.Text = conn.GetFieldValue("AT_CEKBPNHSL");
			string AT_CEKBPNDATE = conn.GetFieldValue("AT_CEKBPNDATE");
			TXT_AT_CEKBPNDATEDAY.Text = tool.FormatDate_Day(AT_CEKBPNDATE);
			DDL_AT_CEKBPNDATEMONTH.SelectedValue = tool.FormatDate_Month(AT_CEKBPNDATE);
			TXT_AT_CEKBPNDATEYEAR.Text = tool.FormatDate_Year(AT_CEKBPNDATE);
			TXT_AT_PEJABAT.Text = conn.GetFieldValue("AT_PEJABAT");
			CHB_AT_BEBASIKAT.Checked = tool.ConvertCheck(conn.GetFieldValue("AT_BEBASIKAT"));
			TXT_AT_AKTEIKATNO.Text = conn.GetFieldValue("AT_AKTEIKATNO");
			TXT_AT_AKTEIKATADDR.Text = conn.GetFieldValue("AT_AKTEIKATADDR");
			DDL_AT_MSLHYURIDIS.SelectedValue = conn.GetFieldValue("AT_MSLHYURIDIS");
			DDL_AT_DIIKATEFEKTIF.SelectedValue = conn.GetFieldValue("AT_DIIKATEFEKTIF");
			TXT_AT_HRGNJOP.Text = tool.ConvertCurr(conn.GetFieldValue("AT_HRGNJOP"));
			TXT_AT_HRGJUAL.Text = tool.ConvertCurr(conn.GetFieldValue("AT_HRGJUAL"));
			TXT_AT_HRGPASAR.Text = tool.ConvertCurr(conn.GetFieldValue("AT_HRGPASAR"));
			TXT_AT_HRGTAKSASIPERM2.Text = tool.ConvertCurr(conn.GetFieldValue("AT_HRGTAKSASIPERM2"));
			TXT_AT_HRGTAKSASI.Text = tool.ConvertCurr(conn.GetFieldValue("AT_HRGTAKSASI"));
			DDL_AT_WILAYAH.SelectedValue = conn.GetFieldValue("AT_WILAYAH");
			DDL_AT_LOKASI.SelectedValue = conn.GetFieldValue("AT_LOKASI");
			DDL_AT_MARKETABILITY.SelectedValue = conn.GetFieldValue("AT_MARKETABILITY");
			DDL_AT_KUALITAS.SelectedValue = conn.GetFieldValue("AT_KUALITAS");
			TXT_AT_SFTYMARGIN.Text = conn.GetFieldValue("AT_SFTYMARGIN");
			TXT_AT_TAKSASISTLHSMARGIN.Text = tool.ConvertCurr(conn.GetFieldValue("AT_TAKSASISTLHSMARGIN"));
			TXT_AT_TAKSASISTLHSMARGINPERM2.Text = tool.ConvertCurr(conn.GetFieldValue("AT_TAKSASISTLHSMARGINPERM2"));
			CHB_AT_MARKETSALE.Checked = tool.ConvertCheck(conn.GetFieldValue("AT_MARKETSALE"));
			CHB_AT_MARKET.Checked = tool.ConvertCheck(conn.GetFieldValue("AT_MARKET"));
			CHB_AT_BISAIKAT.Checked = tool.ConvertCheck(conn.GetFieldValue("AT_BISAIKAT"));
			CHB_AT_BLMBISAIKAT.Checked = tool.ConvertCheck(conn.GetFieldValue("AT_BLMBISAIKAT"));
			CHB_AT_SENGKETA.Checked = tool.ConvertCheck(conn.GetFieldValue("AT_SENGKETA"));
			CHB_AT_KESLAIN.Checked = tool.ConvertCheck(conn.GetFieldValue("AT_KESLAIN"));
			TXT_AT_KETKESLAIN.Text = conn.GetFieldValue("AT_KETKESLAIN");
			if ((conn.GetFieldValue("AT_APPRBY") == "") || (conn.GetFieldValue("AT_APPRBY").Equals(null)))
			{
				//string USERID = Session["USERID"];
				string USERID = "";
				if (USERID == "")
					USERID = "eva";
				conn.QueryString = "select SU_FULLNAME AT_APPRNM, BR.BRANCH_NAME AT_APPRBR "+
					"from SCUSER SU "+
					"left join RFBRANCH BR on BR.BRANCH_CODE = SU.SU_BRANCH "+
					"where SU.USERID = '"+ USERID +"' ";
				conn.ExecuteQuery();
				
				TXT_AT_APPRBY.Text = USERID;
				TXT_AT_APPRNM.Text = conn.GetFieldValue("AT_APPRNM");
				TXT_AT_APPRBR.Text = conn.GetFieldValue("AT_APPRBR");
				AT_APPRDATE = DateAndTime.Today.ToString();
				TXT_AT_APPRDATEDAY.Text		= tool.FormatDate_Day(AT_APPRDATE);
				DDL_AT_APPRDATEMONTH.SelectedValue	= tool.FormatDate_Month(AT_APPRDATE);
				TXT_AT_APPRDATEYEAR.Text	= tool.FormatDate_Year(AT_APPRDATE);

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
			conn.QueryString = "exec APPR_ENTRY_TANAH '"+ vsta +"', '"+ LBL_REGNO.Text +"', '"+ LBL_CUREF.Text +"', '"+
				LBL_CL_SEQ.Text +"', '"+ TXT_AT_APPRBY.Text +"', "+
				tool.ConvertDate(TXT_AT_APPRDATEDAY.Text, DDL_AT_APPRDATEMONTH.SelectedValue, TXT_AT_APPRDATEYEAR.Text) +", "+
				tool.ConvertNull(DDL_AT_COLCLASSIFY.SelectedValue) +", '"+ TXT_AT_ADDRJLN.Text +"', '"+ TXT_AT_ADDRDESA.Text +"', '"+ 
				TXT_AT_ADDRKEC.Text +"', '"+ TXT_AT_ADDRKAB.Text +"', '"+ TXT_AT_PHNAREA.Text +"', '"+ TXT_AT_PHNNUM.Text +"', '"+
				TXT_AT_PHNEXT.Text +"', '"+ TXT_AT_LOKJLN.Text +"', '"+
				TXT_AT_LOKDESA.Text +"', '"+ TXT_AT_LOKKEC.Text +"', '"+ TXT_AT_LOKKAB.Text +"', "+ 
				tool.ConvertNum(TXT_AT_LUASTNH.Text) +", "+ tool.ConvertNum(TXT_AT_PJGTNH.Text) +", "+ tool.ConvertNum(TXT_AT_LBRTNH.Text) +", "+
				tool.ConvertNull(DDL_AT_KEADAANFSK.SelectedValue) +", "+ tool.ConvertNull(DDL_AT_LINGKUNGAN.SelectedValue) +", '"+ TXT_AT_KETLINGKUNGAN.Text +"', "+ 
				tool.ConvertNull(DDL_AT_PENGUASAAN.SelectedValue) +", '"+ tool.ConvertFlag(CHB_AT_LISTRIK.Checked) +"', "+ 
				tool.ConvertNum(TXT_AT_KETLISTRIK.Text) +", '"+ tool.ConvertFlag(CHB_AT_AC.Checked) +"', "+ 
				tool.ConvertNum(TXT_AT_KETAC.Text) +", '"+ tool.ConvertFlag(CHB_AT_AIR.Checked) +"', '"+ 
				TXT_AT_KETAIR.Text +"', '"+ tool.ConvertFlag(CHB_AT_TELPFAX.Checked) +"', "+ tool.ConvertNum(TXT_AT_KETTELPFAX.Text) +", '"+ 
				DDL_AT_BANJIR.SelectedValue +"', '"+ DDL_AT_TEGANGAN.SelectedValue +"', '"+ DDL_AT_TNHLONGSOR.SelectedValue +"', '"+ DDL_AT_PENCEMARAN.SelectedValue +"', '"+ 
				TXT_AT_RESLAIN.Text +"', "+ tool.ConvertNull(DDL_AT_JNSHAK.SelectedValue) +", '"+ 
				TXT_AT_KETJNSHAK.Text +"', '"+ tool.ConvertFlag(CHB_AT_SERTIFIKAT.Checked) +"', '"+ TXT_AT_SERTNO.Text +"', "+ 
				tool.ConvertDate(TXT_AT_SERTEXPDATEDAY.Text, DDL_AT_SERTEXPDATEMONTH.SelectedValue, TXT_AT_SERTEXPDATEYEAR.Text) +", '"+ 
				TXT_AT_SERTATASNAMA.Text +"', '"+ tool.ConvertFlag(CHB_AT_AKTEJLBL.Checked) +"', '"+ TXT_AT_AKTEJLBLNO.Text +"', '"+ 
				TXT_AT_CEKBPNHSL.Text +"', "+ 
				tool.ConvertDate(TXT_AT_CEKBPNDATEDAY.Text, DDL_AT_CEKBPNDATEMONTH.SelectedValue, TXT_AT_CEKBPNDATEYEAR.Text) +", '"+ 
				TXT_AT_PEJABAT.Text +"', '"+ tool.ConvertFlag(CHB_AT_BEBASIKAT.Checked) +"', '"+ TXT_AT_AKTEIKATNO.Text +"', '"+ 
				TXT_AT_AKTEIKATADDR.Text +"', "+ tool.ConvertNull(DDL_AT_MSLHYURIDIS.SelectedValue) +", '"+ DDL_AT_DIIKATEFEKTIF.SelectedValue +"', "+ 
				tool.ConvertNum(TXT_AT_HRGNJOP.Text) +", "+ tool.ConvertNum(TXT_AT_HRGJUAL.Text) +", "+ tool.ConvertNum(TXT_AT_HRGPASAR.Text) +", "+
				tool.ConvertNum(TXT_AT_HRGTAKSASIPERM2.Text) +", "+ tool.ConvertNum(TXT_AT_HRGTAKSASI.Text) +", "+ 
				tool.ConvertNull(DDL_AT_WILAYAH.SelectedValue) +", "+ tool.ConvertNull(DDL_AT_LOKASI.SelectedValue) +", "+ tool.ConvertNull(DDL_AT_MARKETABILITY.SelectedValue) +", "+ 
				tool.ConvertNull(DDL_AT_KUALITAS.SelectedValue) +", "+ tool.ConvertFloat(TXT_AT_SFTYMARGIN.Text) +", "+ 
				tool.ConvertNum(TXT_AT_TAKSASISTLHSMARGINPERM2.Text) +", "+ tool.ConvertNum(TXT_AT_TAKSASISTLHSMARGIN.Text) +", '"+
				tool.ConvertFlag(CHB_AT_MARKETSALE.Checked) +"', '"+ tool.ConvertFlag(CHB_AT_MARKET.Checked) +"', '"+ 
				tool.ConvertFlag(CHB_AT_BISAIKAT.Checked) +"', '"+ tool.ConvertFlag(CHB_AT_BLMBISAIKAT.Checked) +"', '"+ 
				tool.ConvertFlag(CHB_AT_SENGKETA.Checked) +"', '"+ tool.ConvertFlag(CHB_AT_KESLAIN.Checked) +"', '"+ 
				TXT_AT_KETKESLAIN.Text +"' ";
			
			conn.ExecuteQuery();
			if (vsta == "1")
				ViewData();
			else
			{
				conn.QueryString = "exec UPDATEAPPRAISALRESULT '" + Request.QueryString["regno"] + "', " + Request.QueryString["cl_seq"];
				conn.ExecuteNonQuery();

				Response.Redirect("ListAppraisal.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
				//	Response.Redirect("List_Appraisal.aspx");
			}
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec UPDATEAPPRAISALRESULT '" + Request.QueryString["regno"] + "', " + Request.QueryString["cl_seq"];
			conn.ExecuteNonQuery();

			Response.Redirect("ListAppraisal.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}
	}
}
