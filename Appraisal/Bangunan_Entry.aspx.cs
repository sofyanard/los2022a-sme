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
	/// Summary description for Bangunan_Entry.
	/// </summary>
	public partial class Bangunan_Entry : System.Web.UI.Page
	{
		protected Connection conn;
		protected System.Web.UI.WebControls.TextBox TXT_TXT_AB_SFTYMARGIN;
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

				DDL_AB_IJINDATEMONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AB_KONTRAKDATEMONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AB_RENTSTARTDATEMONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AB_RENTDUEDATEMONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AB_PENGUASAAN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AB_JENISBANGUNAN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AB_PENGUASAAN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AB_PEMELIHARAANBGN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AB_KONTRUKSI.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AB_KAYU.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AB_LANTAI.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AB_KONDISI.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AB_UMUR.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AB_INSRSTATUS.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AB_INSREXPDATEMONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AB_FOTO.Items.Add(new ListItem("-- Pilih --", ""));

				string nm_bln;
				for (int i=1; i<=12; i++)
				{
					nm_bln = DateAndTime.MonthName(i, false);
					DDL_AB_IJINDATEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_AB_KONTRAKDATEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_AB_RENTSTARTDATEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_AB_RENTDUEDATEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_AB_INSREXPDATEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
				}

				int jml_row;
				conn.QueryString = "select KUASAID, KUASADESC from RFPENGUASAAN where ACTIVE = '1' ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AB_PENGUASAAN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select BANGUNANID, BANGUNANDESC from RFJENISBANGUNAN where ACTIVE = '1' ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AB_JENISBANGUNAN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select KUASAID, KUASADESC from RFPENGUASAAN where ACTIVE = '1' ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AB_PENGUASAAN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select PELIHARAID, PELIHARADESC from RFPEMELIHARAANBGN where ACTIVE = '1' ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AB_PEMELIHARAANBGN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select KONTRUKSIID, KONTRUKSIDESC from RFKONTRUKSI where ACTIVE = '1' ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AB_KONTRUKSI.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				
				conn.QueryString = "select KAYUID, KAYUDESC from RFKAYU where ACTIVE = '1' ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AB_KAYU.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select LANTAIID, LANTAIDESC from RFLANTAI where ACTIVE = '1' ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AB_LANTAI.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select KONDISIID, KONDISIDESC from RFKONDISI where ACTIVE = '1' ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AB_KONDISI.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select COLLAGEID, COLLAGEDESC from RFCOLLUMUR where ACTIVE = '1' ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AB_UMUR.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				DDL_AB_INSRSTATUS.Items.Add(new ListItem("Telah", "1"));
				DDL_AB_INSRSTATUS.Items.Add(new ListItem("Belum", "0"));

				DDL_AB_FOTO.Items.Add(new ListItem("Ya", "1"));
				DDL_AB_FOTO.Items.Add(new ListItem("Tidak", "0"));

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
			conn.QueryString = "select * from VW_APPR_BANGUNAN "+
				"where AP_REGNO = '"+ LBL_REGNO.Text +"' and CU_REF  = '"+ LBL_CUREF.Text +"' "+
				"and CL_SEQ  = "+ LBL_CL_SEQ.Text ;
			conn.ExecuteQuery();

			TXT_AB_LUASTNH.Text = conn.GetFieldValue("AB_LUASTNH");
			TXT_AB_LUASBANGUN.Text = conn.GetFieldValue("AB_LUASBANGUN");
			TXT_AB_IJINNO.Text = conn.GetFieldValue("AB_IJINNO");
			string AB_IJINDATE = conn.GetFieldValue("AB_IJINDATE");
			TXT_AB_IJINDATEDAY.Text = tool.FormatDate_Day(AB_IJINDATE);
			DDL_AB_IJINDATEMONTH.SelectedValue = tool.FormatDate_Month(AB_IJINDATE);
			TXT_AB_IJINDATEYEAR.Text = tool.FormatDate_Year(AB_IJINDATE);
			TXT_AB_THNBUAT.Text = conn.GetFieldValue("AB_THNBUAT");
			TXT_AB_PENGEMBANG.Text = conn.GetFieldValue("AB_PENGEMBANG");
			DDL_AB_JENISBANGUNAN.SelectedValue = conn.GetFieldValue("AB_JENISBANGUNAN");
			DDL_AB_PENGUASAAN.SelectedValue = conn.GetFieldValue("AB_PENGUASAAN");
			string AB_KONTRAKDATE = conn.GetFieldValue("AB_KONTRAKDATE");
			TXT_AB_KONTRAKDATEDAY.Text = tool.FormatDate_Day(AB_KONTRAKDATE);
			DDL_AB_KONTRAKDATEMONTH.SelectedValue = tool.FormatDate_Month(AB_KONTRAKDATE);
			TXT_AB_KONTRAKDATEYEAR.Text = tool.FormatDate_Year(AB_KONTRAKDATE);
			string AB_RENTSTARTDATE = conn.GetFieldValue("AB_RENTSTARTDATE");
			TXT_AB_RENTSTARTDATEDAY.Text = tool.FormatDate_Day(AB_RENTSTARTDATE);
			DDL_AB_RENTSTARTDATEMONTH.SelectedValue = tool.FormatDate_Month(AB_RENTSTARTDATE);
			TXT_AB_RENTSTARTDATEYEAR.Text = tool.FormatDate_Year(AB_RENTSTARTDATE);
			string AB_RENTDUEDATE = conn.GetFieldValue("AB_RENTDUEDATE");
			TXT_AB_RENTDUEDATEDAY.Text = tool.FormatDate_Day(AB_RENTDUEDATE);
			DDL_AB_RENTDUEDATEMONTH.SelectedValue = tool.FormatDate_Month(AB_RENTDUEDATE);
			TXT_AB_RENTDUEDATEYEAR.Text = tool.FormatDate_Year(AB_RENTDUEDATE);
			DDL_AB_PEMELIHARAANBGN.SelectedValue = conn.GetFieldValue("AB_PEMELIHARAANBGN");
			DDL_AB_KONTRUKSI.SelectedValue = conn.GetFieldValue("AB_KONTRUKSI");
			DDL_AB_KAYU.SelectedValue = conn.GetFieldValue("AB_KAYU");
			DDL_AB_LANTAI.SelectedValue = conn.GetFieldValue("AB_LANTAI");
			DDL_AB_KONDISI.SelectedValue = conn.GetFieldValue("AB_KONDISI");
			DDL_AB_UMUR.SelectedValue = conn.GetFieldValue("AB_UMUR");
			TXT_AB_SFTYMARGIN.Text = conn.GetFieldValue("AB_SFTYMARGIN");
			CHB_AB_LISTRIK.Checked = tool.ConvertCheck(conn.GetFieldValue("AB_LISTRIK"));
			TXT_AB_KETLISTRIK.Text = conn.GetFieldValue("AB_KETLISTRIK");
			CHB_AB_AC.Checked = tool.ConvertCheck(conn.GetFieldValue("AB_AC"));
			TXT_AB_KETAC.Text = conn.GetFieldValue("AB_KETAC");
			CHB_AB_AIR.Checked = tool.ConvertCheck(conn.GetFieldValue("AB_AIR"));
			TXT_AB_KETAIR.Text = conn.GetFieldValue("AB_KETAIR");
			CHB_AB_TELPFAX.Checked = tool.ConvertCheck(conn.GetFieldValue("AB_TELPFAX"));
			TXT_AB_KETTELPFAX.Text = conn.GetFieldValue("AB_KETTELPFAX");
			CHB_AB_PRASARANALAIN.Checked = tool.ConvertCheck(conn.GetFieldValue("AB_PRASARANALAIN"));
			TXT_AB_KETPRASARANALAIN.Text = conn.GetFieldValue("AB_KETPRASARANALAIN");
			DDL_AB_INSRSTATUS.SelectedValue = conn.GetFieldValue("AB_INSRSTATUS");
			TXT_AB_INSRTUTUP.Text = conn.GetFieldValue("AB_INSRTUTUP");
			TXT_AB_INSRAMOUNT.Text = tool.ConvertCurr(conn.GetFieldValue("AB_INSRAMOUNT"));
			string AB_INSREXPDATE = conn.GetFieldValue("AB_INSREXPDATE");
			TXT_AB_INSREXPDATEDAY.Text = tool.FormatDate_Day(AB_INSREXPDATE);
			DDL_AB_INSREXPDATEMONTH.SelectedValue = tool.FormatDate_Month(AB_INSREXPDATE);
			TXT_AB_INSREXPDATEYEAR.Text = tool.FormatDate_Year(AB_INSREXPDATE);
			TXT_AB_INSRCOMP.Text = conn.GetFieldValue("AB_INSRCOMP");
			TXT_AB_HRGINSTANSI.Text = tool.ConvertCurr(conn.GetFieldValue("AB_HRGINSTANSI"));
			TXT_AB_HRGPENGEMBANG.Text = tool.ConvertCurr(conn.GetFieldValue("AB_HRGPENGEMBANG"));
			TXT_AB_HRGNJOP.Text = tool.ConvertCurr(conn.GetFieldValue("AB_HRGNJOP"));
			TXT_AB_HRGTAKSASIPERM2.Text = tool.ConvertCurr(conn.GetFieldValue("AB_HRGTAKSASIPERM2"));
			TXT_AB_HRGTAKSASI.Text = tool.ConvertCurr(conn.GetFieldValue("AB_HRGTAKSASI"));
			TXT_AB_SFTYMARGIN.Text = conn.GetFieldValue("AB_SFTYMARGIN");
			TXT_AB_TAKSASISTLHSMARGINPERM2.Text = tool.ConvertCurr(conn.GetFieldValue("AB_TAKSASISTLHSMARGINPERM2"));
			TXT_AB_TAKSASISTLHSMARGIN.Text = tool.ConvertCurr(conn.GetFieldValue("AB_TAKSASISTLHSMARGIN"));
			DDL_AB_FOTO.SelectedValue = conn.GetFieldValue("AB_FOTO");
			TXT_AB_KETJAMINAN.Text = conn.GetFieldValue("AB_KETJAMINAN");
		}

		private void Simpan(string vsta)
		{
			conn.QueryString = "exec APPR_ENTRY_BANGUNAN '"+ vsta +"', '"+ LBL_REGNO.Text +"', '"+ LBL_CUREF.Text +"', '"+
				LBL_CL_SEQ.Text +"', "+ tool.ConvertNum(TXT_AB_LUASTNH.Text) +", "+ tool.ConvertNum(TXT_AB_LUASBANGUN.Text) +", '"+ TXT_AB_IJINNO.Text +"', "+
				tool.ConvertDate(TXT_AB_IJINDATEDAY.Text, DDL_AB_IJINDATEMONTH.SelectedValue, TXT_AB_IJINDATEYEAR.Text) +", "+
				tool.ConvertNum(TXT_AB_THNBUAT.Text) +", '"+ TXT_AB_PENGEMBANG.Text +"', "+ tool.ConvertNull(DDL_AB_JENISBANGUNAN.SelectedValue) +", "+
				tool.ConvertNull(DDL_AB_PENGUASAAN.SelectedValue) +", '"+ TXT_AB_KONTRAKNO.Text +"', "+
				tool.ConvertDate(TXT_AB_KONTRAKDATEDAY.Text, DDL_AB_KONTRAKDATEMONTH.SelectedValue, TXT_AB_KONTRAKDATEYEAR.Text) +", "+
				tool.ConvertDate(TXT_AB_RENTSTARTDATEDAY.Text, DDL_AB_RENTSTARTDATEMONTH.SelectedValue, TXT_AB_RENTSTARTDATEYEAR.Text) +", "+
				tool.ConvertDate(TXT_AB_RENTDUEDATEDAY.Text, DDL_AB_RENTDUEDATEMONTH.SelectedValue, TXT_AB_RENTDUEDATEYEAR.Text) +", "+
				tool.ConvertNull(DDL_AB_PEMELIHARAANBGN.SelectedValue) +", "+ tool.ConvertNull(DDL_AB_KONTRUKSI.SelectedValue) +", "+
				tool.ConvertNull(DDL_AB_KAYU.SelectedValue) +", "+ tool.ConvertNull(DDL_AB_LANTAI.SelectedValue) +", "+
				tool.ConvertNull(DDL_AB_KONDISI.SelectedValue) +", "+ tool.ConvertNull(DDL_AB_UMUR.SelectedValue) +", '"+
				tool.ConvertFlag(CHB_AB_LISTRIK.Checked) +"', '"+ TXT_AB_KETLISTRIK.Text +"', '"+
				tool.ConvertFlag(CHB_AB_AC.Checked) +"', '"+ TXT_AB_KETAC.Text +"', '"+ tool.ConvertFlag(CHB_AB_AIR.Checked) +"', '"+
				TXT_AB_KETAIR.Text +"', '"+ tool.ConvertFlag(CHB_AB_TELPFAX.Checked) +"', '"+ TXT_AB_KETTELPFAX.Text +"', '"+
				tool.ConvertFlag(CHB_AB_PRASARANALAIN.Checked) +"', '"+ TXT_AB_KETPRASARANALAIN.Text +"', '"+
				DDL_AB_INSRSTATUS.SelectedValue +"', '"+ TXT_AB_INSRTUTUP.Text +"', '"+ tool.ConvertNum(TXT_AB_INSRAMOUNT.Text) +"', "+
				tool.ConvertDate(TXT_AB_INSREXPDATEDAY.Text, DDL_AB_INSREXPDATEMONTH.SelectedValue, TXT_AB_INSREXPDATEYEAR.Text) +", '"+
				TXT_AB_INSRCOMP.Text +"', "+ tool.ConvertNum(TXT_AB_HRGINSTANSI.Text) +", "+ tool.ConvertNum(TXT_AB_HRGPENGEMBANG.Text) +", "+
				tool.ConvertNum(TXT_AB_HRGNJOP.Text) +", "+ tool.ConvertNum(TXT_AB_HRGTAKSASIPERM2.Text) +", "+
				tool.ConvertNum(TXT_AB_HRGTAKSASI.Text) +", "+ tool.ConvertFloat(TXT_AB_SFTYMARGIN.Text) +", "+
				tool.ConvertNum(TXT_AB_TAKSASISTLHSMARGINPERM2.Text) +", "+ tool.ConvertNum(TXT_AB_TAKSASISTLHSMARGIN.Text) +", '"+
				DDL_AB_FOTO.SelectedValue +"', '"+ TXT_AB_KETJAMINAN.Text +"' ";
			
			conn.ExecuteQuery();
			if (vsta == "1")
				ViewData();
			else
				Response.Redirect("ListAppraisal.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}
	}
}
