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
	/// Summary description for Kios_Entry.
	/// </summary>
	public partial class Kios_Entry : System.Web.UI.Page
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
				DDL_AK_APPRDATEMONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_INSREXPDATEMONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_SERTEXPDATEMONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_CEKPENGELOLADATEMONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_COLCLASSIFY.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_LINGKUNGAN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_PENGUASAAN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_BANJIR.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_TEGANGAN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_TNHLONGSOR.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_PENCEMARAN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_PEMELIHARAANBGN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_JNSHAK.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_INSRSTATUS.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_MSLHYURIDIS.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_KUALITAS.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_MARKETABILITY.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_SISAWAKTU.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_FOTO.Items.Add(new ListItem("-- Pilih --", ""));

				int jml_row;
				string nm_bln;
				for (int i=1; i<=12; i++)
				{
					nm_bln = DateAndTime.MonthName(i, false);
					DDL_AK_APPRDATEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_AK_INSREXPDATEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_AK_SERTEXPDATEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_AK_CEKPENGELOLADATEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
				}

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AK_COLCLASSIFY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select LINGID, LINGDESC from RFLINGKUNGAN ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AK_LINGKUNGAN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select KUASAID, KUASADESC from RFPENGUASAAN ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AK_PENGUASAAN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				DDL_AK_BANJIR.Items.Add(new ListItem("Ya", "1"));
				DDL_AK_BANJIR.Items.Add(new ListItem("Tidak", "0"));

				DDL_AK_TEGANGAN.Items.Add(new ListItem("Ya", "1"));
				DDL_AK_TEGANGAN.Items.Add(new ListItem("Tidak", "0"));

				DDL_AK_TNHLONGSOR.Items.Add(new ListItem("Ya", "1"));
				DDL_AK_TNHLONGSOR.Items.Add(new ListItem("Tidak", "0"));

				DDL_AK_PENCEMARAN.Items.Add(new ListItem("Ya", "1"));
				DDL_AK_PENCEMARAN.Items.Add(new ListItem("Tidak", "0"));
				

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AK_PEMELIHARAANBGN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AK_JNSHAK.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				DDL_AK_INSRSTATUS.Items.Add(new ListItem("Telah", "1"));
				DDL_AK_INSRSTATUS.Items.Add(new ListItem("Belum", "0"));
					
				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AK_MSLHYURIDIS.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AK_KUALITAS.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AK_MARKETABILITY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AK_SISAWAKTU.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				DDL_AK_FOTO.Items.Add(new ListItem("Ya", "1"));
				DDL_AK_FOTO.Items.Add(new ListItem("Tidak", "0"));

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

			conn.QueryString = "select * from VW_APPR_KIOS "+
				"where AP_REGNO = '"+ LBL_REGNO.Text +"' and CU_REF = '"+ LBL_CUREF.Text +"' and CL_SEQ = "+ LBL_CL_SEQ.Text ;
			conn.ExecuteQuery();

			TXT_AK_APPRBY.Text = conn.GetFieldValue("AK_APPRBY");
			TXT_AK_APPRNM.Text = conn.GetFieldValue("AK_APPRNM");
			TXT_AK_APPRBR.Text = conn.GetFieldValue("AK_APPRBR");
			string AK_APPRDATE = conn.GetFieldValue("AK_APPRDATE");
			TXT_AK_APPRDATEDAY.Text = tool.FormatDate_Day(AK_APPRDATE);
			DDL_AK_APPRDATEMONTH.SelectedValue = tool.FormatDate_Month(AK_APPRDATE);
			TXT_AK_APPRDATEYEAR.Text = tool.FormatDate_Year(AK_APPRDATE);
			TXT_CU_NAME.Text = conn.GetFieldValue("CU_NAME");
			TXT_AK_PHNAREA.Text = conn.GetFieldValue("AK_PHNAREA");
			TXT_AK_PHNNUM.Text = conn.GetFieldValue("AK_PHNNUM");
			TXT_AK_PHNEXT.Text = conn.GetFieldValue("AK_PHNEXT");
			DDL_AK_COLCLASSIFY.SelectedValue = conn.GetFieldValue("AK_COLCLASSIFY");
			TXT_AK_ADDRJLN.Text = conn.GetFieldValue("AK_ADDRJLN");
			TXT_AK_ADDRDESA.Text = conn.GetFieldValue("AK_ADDRDESA");
			TXT_AK_ADDRKEC.Text = conn.GetFieldValue("AK_ADDRKEC");
			TXT_AK_ADDRKAB.Text = conn.GetFieldValue("AK_ADDRKAB");
			TXT_AK_PASARMALL.Text = conn.GetFieldValue("AK_PASARMALL");
			TXT_AK_LOKJLN.Text = conn.GetFieldValue("AK_LOKJLN");
			TXT_AK_LOKDESA.Text = conn.GetFieldValue("AK_LOKDESA");
			TXT_AK_LOKKEC.Text = conn.GetFieldValue("AK_LOKKEC");
			TXT_AK_LOKKAB.Text = conn.GetFieldValue("AK_LOKKAB");
			TXT_AK_BLOKLOS.Text = conn.GetFieldValue("AK_BLOKLOS");
			TXT_AK_LUASBANGUN.Text = conn.GetFieldValue("AK_LUASBANGUN");
			TXT_AK_PENGELOLA.Text = conn.GetFieldValue("AK_PENGELOLA");
			DDL_AK_LINGKUNGAN.SelectedValue = conn.GetFieldValue("AK_LINGKUNGAN");
			TXT_AK_KETLINGKUNGAN.Text = conn.GetFieldValue("AK_KETLINGKUNGAN");
			DDL_AK_PENGUASAAN.SelectedValue = conn.GetFieldValue("AK_PENGUASAAN");
			CHB_AK_LISTRIK.Checked = tool.ConvertCheck(conn.GetFieldValue("AK_LISTRIK"));
			TXT_AK_KETLISTRIK.Text = conn.GetFieldValue("AK_KETLISTRIK");
			CHB_AK_AC.Checked = tool.ConvertCheck(conn.GetFieldValue("AK_AC"));
			TXT_AK_KETAC.Text = conn.GetFieldValue("AK_KETAC");
			CHB_AK_AIR.Checked = tool.ConvertCheck(conn.GetFieldValue("AK_AIR"));
			TXT_AK_KETAIR.Text = conn.GetFieldValue("AK_KETAIR");
			CHB_AK_TELPFAX.Checked = tool.ConvertCheck(conn.GetFieldValue("AK_TELPFAX"));
			TXT_AK_KETTELPFAX.Text = conn.GetFieldValue("AK_KETTELPFAX");
			CHB_AK_PRASARANALAIN.Checked = tool.ConvertCheck(conn.GetFieldValue("AK_PRASARANALAIN"));
			TXT_AK_KETPRASARANALAIN.Text = conn.GetFieldValue("AK_KETPRASARANALAIN");
			DDL_AK_BANJIR.SelectedValue = conn.GetFieldValue("AK_BANJIR");
			DDL_AK_TEGANGAN.SelectedValue = conn.GetFieldValue("AK_TEGANGAN");
			DDL_AK_TNHLONGSOR.SelectedValue = conn.GetFieldValue("AK_TNHLONGSOR");
			DDL_AK_PENCEMARAN.SelectedValue = conn.GetFieldValue("AK_PENCEMARAN");
			TXT_AK_RESLAIN.Text = conn.GetFieldValue("AK_RESLAIN");
			DDL_AK_PEMELIHARAANBGN.SelectedValue = conn.GetFieldValue("AK_PEMELIHARAANBGN");
			DDL_AK_JNSHAK.SelectedValue = conn.GetFieldValue("AK_JNSHAK");
			TXT_AK_KETJNSHAK.Text = conn.GetFieldValue("AK_KETJNSHAK");
			DDL_AK_INSRSTATUS.SelectedValue = conn.GetFieldValue("AK_INSRSTATUS");
			TXT_AK_INSRTUTUP.Text = conn.GetFieldValue("AK_INSRTUTUP");
			TXT_AK_INSRAMOUNT.Text = tool.ConvertCurr(conn.GetFieldValue("AK_INSRAMOUNT"));
			string AK_INSREXPDATE = conn.GetFieldValue("AK_INSREXPDATE");
			TXT_AK_INSREXPDATEDAY.Text = tool.FormatDate_Day(AK_INSREXPDATE);
			DDL_AK_INSREXPDATEMONTH.SelectedValue = tool.FormatDate_Month(AK_INSREXPDATE);
			TXT_AK_INSREXPDATEYEAR.Text = tool.FormatDate_Year(AK_INSREXPDATE);
			TXT_AK_INSRCOMP.Text = conn.GetFieldValue("AK_INSRCOMP");
			CHB_AK_SERTIFIKAT.Checked = tool.ConvertCheck(conn.GetFieldValue("AK_SERTIFIKAT"));
			TXT_AK_SERTNO.Text = conn.GetFieldValue("AK_SERTNO");
			string AK_SERTEXPDATE = conn.GetFieldValue("AK_SERTEXPDATE");
			TXT_AK_SERTEXPDATEDAY.Text = tool.FormatDate_Day(AK_SERTEXPDATE);
			DDL_AK_SERTEXPDATEMONTH.SelectedValue = tool.FormatDate_Month(AK_SERTEXPDATE);
			TXT_AK_SERTEXPDATEYEAR.Text = tool.FormatDate_Year(AK_SERTEXPDATE);
			TXT_AK_SERTATASNAMA.Text = conn.GetFieldValue("AK_SERTATASNAMA");
			CHB_AK_AKTEJLBL.Checked = tool.ConvertCheck(conn.GetFieldValue("AK_AKTEJLBL"));
			TXT_AK_AKTEJLBLNO.Text = conn.GetFieldValue("AK_AKTEJLBLNO");
			TXT_AK_CEKPENGELOLAHSL.Text = conn.GetFieldValue("AK_CEKPENGELOLAHSL");
			string AK_CEKPENGELOLADATE = conn.GetFieldValue("AK_CEKPENGELOLADATE");
			TXT_AK_CEKPENGELOLADATEDAY.Text = tool.FormatDate_Day(AK_CEKPENGELOLADATE);
			DDL_AK_CEKPENGELOLADATEMONTH.SelectedValue = tool.FormatDate_Month(AK_CEKPENGELOLADATE);
			TXT_AK_CEKPENGELOLADATEYEAR.Text = tool.FormatDate_Year(AK_CEKPENGELOLADATE);
			TXT_AK_PEJABAT.Text = conn.GetFieldValue("AK_PEJABAT");
			CHB_AK_BEBASIKAT.Checked = tool.ConvertCheck(conn.GetFieldValue("AK_BEBASIKAT"));
			TXT_AK_AKTEIKATNO.Text = conn.GetFieldValue("AK_AKTEIKATNO");
			TXT_AK_AKTEIKATADDR.Text = conn.GetFieldValue("AK_AKTEIKATADDR");
			DDL_AK_MSLHYURIDIS.SelectedValue = conn.GetFieldValue("AK_MSLHYURIDIS");
			TXT_AK_HRGPENGELOLA.Text = conn.GetFieldValue("AK_HRGPENGELOLA");
			TXT_AK_HRGPASAR.Text = tool.ConvertCurr(conn.GetFieldValue("AK_HRGPASAR"));
			TXT_AK_HRGTAKSASI.Text = tool.ConvertCurr(conn.GetFieldValue("AK_HRGTAKSASI"));
			DDL_AK_KUALITAS.SelectedValue = conn.GetFieldValue("AK_KUALITAS");
			DDL_AK_MARKETABILITY.SelectedValue = conn.GetFieldValue("AK_MARKETABILITY");
			DDL_AK_SISAWAKTU.SelectedValue = conn.GetFieldValue("AK_SISAWAKTU");
			TXT_AK_SFTYMARGIN.Text = conn.GetFieldValue("AK_SFTYMARGIN");
			TXT_AK_TAKSASISTLHSMARGIN.Text = tool.ConvertCurr(conn.GetFieldValue("AK_TAKSASISTLHSMARGIN"));
			DDL_AK_FOTO.SelectedValue = conn.GetFieldValue("AK_FOTO");
			TXT_AK_KETJAMINAN.Text = conn.GetFieldValue("AK_KETJAMINAN");
			CHB_AK_MARKETSALE.Checked = tool.ConvertCheck(conn.GetFieldValue("AK_MARKETSALE"));
			CHB_AK_MARKET.Checked = tool.ConvertCheck(conn.GetFieldValue("AK_MARKET"));
			CHB_AK_BISAIKAT.Checked = tool.ConvertCheck(conn.GetFieldValue("AK_BISAIKAT"));
			CHB_AK_BLMBISAIKAT.Checked = tool.ConvertCheck(conn.GetFieldValue("AK_BLMBISAIKAT"));
			CHB_AK_SENGKETA.Checked = tool.ConvertCheck(conn.GetFieldValue("AK_SENGKETA"));
			CHB_AK_KESLAIN.Checked = tool.ConvertCheck(conn.GetFieldValue("AK_KESLAIN"));
			TXT_AK_KETKESLAIN.Text = conn.GetFieldValue("AK_KETKESLAIN");

			if ((conn.GetFieldValue("AK_APPRBY") == "") || (conn.GetFieldValue("AK_APPRBY").Equals(null)))
			{
				//string USERID = Session["USERID"];
				string USERID = "";
				if (USERID == "")
					USERID = "eva";
				conn.QueryString = "select SU_FULLNAME AK_APPRNM, BR.BRANCH_NAME AK_APPRBR "+
					"from SCUSER SU "+
					"left join RFBRANCH BR on BR.BRANCH_CODE = SU.SU_BRANCH "+
					"where SU.USERID = '"+ USERID +"' ";
				conn.ExecuteQuery();
				
				TXT_AK_APPRBY.Text = USERID;
				TXT_AK_APPRNM.Text = conn.GetFieldValue("AK_APPRNM");
				TXT_AK_APPRBR.Text = conn.GetFieldValue("AK_APPRBR");
				AK_APPRDATE = DateAndTime.Today.ToString();
				TXT_AK_APPRDATEDAY.Text		= tool.FormatDate_Day(AK_APPRDATE);
				DDL_AK_APPRDATEMONTH.SelectedValue	= tool.FormatDate_Month(AK_APPRDATE);
				TXT_AK_APPRDATEYEAR.Text	= tool.FormatDate_Year(AK_APPRDATE);

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
			conn.QueryString = "exec APPR_ENTRY_KIOS '"+ vsta +"', '"+ LBL_REGNO.Text +"', '"+ LBL_CUREF.Text +"', '"+
				LBL_CL_SEQ.Text +"', '"+ TXT_AK_APPRBY.Text +"', "+
				tool.ConvertDate(TXT_AK_APPRDATEDAY.Text, DDL_AK_APPRDATEMONTH.SelectedValue, TXT_AK_APPRDATEYEAR.Text) +", "+
				tool.ConvertNull(DDL_AK_COLCLASSIFY.SelectedValue) +", '"+ TXT_AK_ADDRJLN.Text +"', '"+ TXT_AK_ADDRDESA.Text +"', '"+ 
				TXT_AK_ADDRKEC.Text +"', '"+ TXT_AK_ADDRKAB.Text +"', '"+ TXT_AK_PHNAREA.Text +"', '"+ TXT_AK_PHNNUM.Text +"', '"+
				TXT_AK_PHNEXT.Text +"', '"+ TXT_AK_PASARMALL.Text +"', '"+ TXT_AK_LOKJLN.Text +"', '"+
				TXT_AK_LOKDESA.Text +"', '"+ TXT_AK_LOKKEC.Text +"', '"+ TXT_AK_LOKKAB.Text +"', '"+ TXT_AK_BLOKLOS.Text +"', "+
				TXT_AK_LUASBANGUN.Text +", '"+ TXT_AK_PENGELOLA.Text +"', "+ tool.ConvertNull(DDL_AK_LINGKUNGAN.SelectedValue) +", '"+ 
				TXT_AK_KETLINGKUNGAN.Text +"', "+ tool.ConvertNull(DDL_AK_PENGUASAAN.SelectedValue) +", '"+ tool.ConvertFlag(CHB_AK_LISTRIK.Checked) +"', "+
				tool.ConvertNum(TXT_AK_KETLISTRIK.Text) +", '"+ tool.ConvertFlag(CHB_AK_AC.Checked) +"', "+ tool.ConvertNum(TXT_AK_KETAC.Text) +", '"+
				tool.ConvertFlag(CHB_AK_AIR.Checked) +"', '"+ TXT_AK_KETAIR.Text +"', '"+ tool.ConvertFlag(CHB_AK_TELPFAX.Checked) +"', "+
				tool.ConvertNum(TXT_AK_KETTELPFAX.Text) +", '"+ tool.ConvertFlag(CHB_AK_PRASARANALAIN.Checked) +"', '"+ TXT_AK_KETPRASARANALAIN.Text +"', '"+ 
				DDL_AK_BANJIR.SelectedValue +"', '"+ DDL_AK_TEGANGAN.SelectedValue +"', '"+ DDL_AK_TNHLONGSOR.SelectedValue +"', '"+ 
				DDL_AK_PENCEMARAN.SelectedValue +"', '"+ TXT_AK_RESLAIN.Text +"', "+ tool.ConvertNull(DDL_AK_PEMELIHARAANBGN.SelectedValue) +", "+ 
				tool.ConvertNull(DDL_AK_JNSHAK.SelectedValue) +", '"+ TXT_AK_KETJNSHAK.Text +"', '"+ DDL_AK_INSRSTATUS.SelectedValue +"', '"+
				TXT_AK_INSRTUTUP.Text +"', "+ tool.ConvertNum(TXT_AK_INSRAMOUNT.Text) +", "+ 
				tool.ConvertDate(TXT_AK_INSREXPDATEDAY.Text, DDL_AK_INSREXPDATEMONTH.SelectedValue, TXT_AK_INSREXPDATEYEAR.Text) +", '"+ 
				TXT_AK_INSRCOMP.Text +"', '"+ tool.ConvertFlag(CHB_AK_SERTIFIKAT.Checked) +"', '"+ TXT_AK_SERTNO.Text +"', "+ 
				tool.ConvertDate(TXT_AK_SERTEXPDATEDAY.Text, DDL_AK_SERTEXPDATEMONTH.SelectedValue, TXT_AK_SERTEXPDATEYEAR.Text) +", '"+ 
				TXT_AK_SERTATASNAMA.Text +"', '"+ tool.ConvertFlag(CHB_AK_AKTEJLBL.Checked) +"', '"+ TXT_AK_AKTEJLBLNO.Text +"', '"+ 
				TXT_AK_CEKPENGELOLAHSL.Text +"', "+ 
				tool.ConvertDate(TXT_AK_CEKPENGELOLADATEDAY.Text, DDL_AK_CEKPENGELOLADATEMONTH.SelectedValue, TXT_AK_CEKPENGELOLADATEYEAR.Text) +", '"+ 
				TXT_AK_PEJABAT.Text +"', '"+ tool.ConvertFlag(CHB_AK_BEBASIKAT.Checked) +"', '"+ TXT_AK_AKTEIKATNO.Text +"', '"+ 
				TXT_AK_AKTEIKATADDR.Text +"', "+ tool.ConvertNull(DDL_AK_MSLHYURIDIS.SelectedValue) +", "+
				tool.ConvertNum(TXT_AK_HRGPENGELOLA.Text) +", "+ tool.ConvertNum(TXT_AK_HRGPASAR.Text) +", "+ 
				tool.ConvertNum(TXT_AK_HRGTAKSASI.Text) +", "+ tool.ConvertNull(DDL_AK_KUALITAS.SelectedValue) +", "+ 
				tool.ConvertNull(DDL_AK_MARKETABILITY.SelectedValue) +", "+ tool.ConvertNull(DDL_AK_SISAWAKTU.SelectedValue) +", "+ 
				tool.ConvertFloat(TXT_AK_SFTYMARGIN.Text) +", "+ tool.ConvertNum(TXT_AK_TAKSASISTLHSMARGIN.Text) +", '"+ 
				DDL_AK_FOTO.SelectedValue +"', '"+ TXT_AK_KETJAMINAN.Text +"', '"+ tool.ConvertFlag(CHB_AK_MARKETSALE.Checked) +"', '"+ 
				tool.ConvertFlag(CHB_AK_MARKET.Checked) +"', '"+ tool.ConvertFlag(CHB_AK_BISAIKAT.Checked) +"', '"+
				tool.ConvertFlag(CHB_AK_BLMBISAIKAT.Checked) +"', '"+ tool.ConvertFlag(CHB_AK_SENGKETA.Checked) +"', '"+
				tool.ConvertFlag(CHB_AK_KESLAIN.Checked) +"', '"+ TXT_AK_KETKESLAIN.Text +"' ";
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
