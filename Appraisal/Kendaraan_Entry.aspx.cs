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
	/// Summary description for Kendaraan_Entry.
	/// </summary>
	public partial class Kendaraan_Entry : System.Web.UI.Page
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
				DDL_AK_EXPDATEMONTH.Items.Add(new ListItem("-- Pilih --", ""));
				
				DDL_AK_COLCLASSIFY.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_JNSAGUNAN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_ISNEW.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_KONDISI.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_UMUR.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_INSRSTATUS.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_BANJIR.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_PENCURIAN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_KEBAKARAN.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_AK_FOTO.Items.Add(new ListItem("-- Pilih --", ""));

				string nm_bln;
				int jml_row;
				for (int i=1; i<=12; i++)
				{
					nm_bln = DateAndTime.MonthName(i, false);
					DDL_AK_APPRDATEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_AK_EXPDATEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));

				}

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AK_COLCLASSIFY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//--- Jenis Agunan
				conn.QueryString = "select AGUNANID, AGUNANID+' - '+AGUNANDESC from RFJENISAGUNAN where ACTIVE='1' order by AGUNANID";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AK_JNSAGUNAN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				DDL_AK_ISNEW.Items.Add(new ListItem("Ya", "0"));
				DDL_AK_ISNEW.Items.Add(new ListItem("Tidak", "1"));

				conn.QueryString = "select COLSTAID, COLSTADESC from RFCOLLSTATUS";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AK_KONDISI.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select COLLAGEID, COLLAGEDESC from RFCOLLUMUR ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_AK_UMUR.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				DDL_AK_INSRSTATUS.Items.Add(new ListItem("Telah", "1"));
				DDL_AK_INSRSTATUS.Items.Add(new ListItem("Belum", "0"));

				DDL_AK_BANJIR.Items.Add(new ListItem("Besar", "1"));
				DDL_AK_BANJIR.Items.Add(new ListItem("Sedang", "2"));
				DDL_AK_BANJIR.Items.Add(new ListItem("Kecil", "3"));
				
				DDL_AK_PENCURIAN.Items.Add(new ListItem("Besar", "1"));
				DDL_AK_PENCURIAN.Items.Add(new ListItem("Sedang", "2"));
				DDL_AK_PENCURIAN.Items.Add(new ListItem("Kecil", "3"));
					
				DDL_AK_KEBAKARAN.Items.Add(new ListItem("Besar", "1"));
				DDL_AK_KEBAKARAN.Items.Add(new ListItem("Sedang", "2"));
				DDL_AK_KEBAKARAN.Items.Add(new ListItem("Kecil", "3"));

				DDL_AK_FOTO.Items.Add(new ListItem("Ada", "1"));
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
			conn.QueryString = "select * from VW_APPR_KENDARAAN "+
				"where AP_REGNO = '"+ LBL_REGNO.Text +"' and CU_REF = '"+ LBL_CUREF.Text
				+"' and CL_SEQ = "+ LBL_CL_SEQ.Text;
			conn.ExecuteQuery();
			
			TXT_AK_APPRBY.Text = conn.GetFieldValue("AK_APPRBY");
			TXT_AK_APPRNM.Text = conn.GetFieldValue("AK_APPRNM");
			TXT_AK_APPRBR.Text = conn.GetFieldValue("AK_APPRBR");
			string AK_APPRDATE = conn.GetFieldValue("AK_APPRDATE");
			TXT_AK_APPRDATEDAY.Text		= tool.FormatDate_Day(AK_APPRDATE);
			DDL_AK_APPRDATEMONTH.SelectedValue	= tool.FormatDate_Month(AK_APPRDATE);
			TXT_AK_APPRDATEYEAR.Text	= tool.FormatDate_Year(AK_APPRDATE);
			TXT_CU_NAME.Text = conn.GetFieldValue("CU_NAME");
			TXT_AK_PHNAREA.Text = conn.GetFieldValue("AK_PHNAREA");
			TXT_AK_PHNNUM.Text = conn.GetFieldValue("AK_PHNNUM");
			TXT_AK_PHNEXT.Text = conn.GetFieldValue("AK_PHNEXT");
			TXT_AK_ADDRJLN.Text = conn.GetFieldValue("AK_ADDRJLN");
			TXT_AK_ADDRDESA.Text = conn.GetFieldValue("AK_ADDRDESA");
			TXT_AK_ADDRKEC.Text = conn.GetFieldValue("AK_ADDRKEC");
			TXT_AK_ADDRKAB.Text = conn.GetFieldValue("AK_ADDRKAB");
			DDL_AK_COLCLASSIFY.SelectedValue = conn.GetFieldValue("AK_COLCLASSIFY");
			DDL_AK_JNSAGUNAN.SelectedValue = conn.GetFieldValue("AK_JNSAGUNAN");
			DDL_AK_ISNEW.SelectedValue = conn.GetFieldValue("AK_ISNEW");

			TXT_AK_KETAGUNAN.Text = conn.GetFieldValue("AK_KETAGUNAN");
			TXT_AK_LOKJLN.Text = conn.GetFieldValue("AK_LOKJLN");
			TXT_AK_LOKDESA.Text = conn.GetFieldValue("AK_LOKDESA");
			TXT_AK_LOKKEC.Text = conn.GetFieldValue("AK_LOKKEC");
			TXT_AK_LOKKAB.Text = conn.GetFieldValue("AK_LOKKAB");
			TXT_AK_LOKPHNAREA.Text = conn.GetFieldValue("AK_LOKPHNAREA");
			TXT_AK_LOKPHNNUM.Text = conn.GetFieldValue("AK_LOKPHNNUM");
			TXT_AK_LOKPHNEXT.Text = conn.GetFieldValue("AK_LOKPHNEXT");
			CHB_AK_BPKB.Checked = tool.ConvertCheck(conn.GetFieldValue("AK_BPKB"));
			CHB_AK_FAKTURBRG.Checked = tool.ConvertCheck(conn.GetFieldValue("AK_FAKTURBRG"));
			CHB_AK_BUKTILAIN.Checked = tool.ConvertCheck(conn.GetFieldValue("AK_BUKTILAIN"));
			TXT_AK_KETBUKTILAIN.Text = conn.GetFieldValue("AK_KETBUKTILAIN");
			DDL_AK_KONDISI.SelectedValue = conn.GetFieldValue("AK_KONDISI");
			DDL_AK_UMUR.SelectedValue = conn.GetFieldValue("AK_UMUR");
			CHB_AK_KEPOLISIAN.Checked = tool.ConvertCheck(conn.GetFieldValue("AK_KEPOLISIAN"));
			CHB_AK_SUPPLIER.Checked = tool.ConvertCheck(conn.GetFieldValue("AK_SUPPLIER"));
			CHB_AK_CEKLAIN.Checked = tool.ConvertCheck(conn.GetFieldValue("AK_CEKLAIN"));
			TXT_AK_KETCEKLAIN.Text = conn.GetFieldValue("AK_KETCEKLAIN");
			DDL_AK_INSRSTATUS.SelectedValue = conn.GetFieldValue("AK_INSRSTATUS");
			TXT_AK_KETINSR.Text = conn.GetFieldValue("AK_KETINSR");
			TXT_AK_INSRAMOUNT.Text = tool.ConvertCurr(conn.GetFieldValue("AK_INSRAMOUNT"));
			TXT_AK_INSRCOMP.Text = conn.GetFieldValue("AK_INSRCOMP");
			string AK_EXPDATE = conn.GetFieldValue("AK_EXPDATE");
			TXT_AK_EXPDATEDAY.Text		= tool.FormatDate_Day(AK_EXPDATE);
			DDL_AK_EXPDATEMONTH.SelectedValue	= tool.FormatDate_Month(AK_EXPDATE);
			TXT_AK_EXPDATEYEAR.Text	= tool.FormatDate_Year(AK_EXPDATE);			
			DDL_AK_BANJIR.SelectedValue = conn.GetFieldValue("AK_BANJIR");
			DDL_AK_PENCURIAN.SelectedValue = conn.GetFieldValue("AK_PENCURIAN");
			DDL_AK_KEBAKARAN.SelectedValue = conn.GetFieldValue("AK_KEBAKARAN");
			DDL_AK_FOTO.SelectedValue = conn.GetFieldValue("AK_FOTO");
			TXT_AK_HRGPASAR.Text = tool.ConvertCurr(conn.GetFieldValue("AK_HRGPASAR"));
			TXT_AK_HRGBALIKNM.Text = tool.ConvertCurr(conn.GetFieldValue("AK_HRGBALIKNM"));
			TXT_AK_HRGSMBRLN.Text = tool.ConvertCurr(conn.GetFieldValue("AK_HRGSMBRLN"));
			TXT_AK_SBLMSMARGIN.Text = tool.ConvertCurr(conn.GetFieldValue("AK_SBLMSMARGIN"));
			TXT_AK_SFTYMARGIN.Text = tool.ConvertCurr(conn.GetFieldValue("AK_SFTYMARGIN"));
			TXT_AK_STLHSMARGIN.Text = tool.ConvertCurr(conn.GetFieldValue("AK_STLHSMARGIN"));
			TXT_AK_KETJAMINAN.Text = tool.ConvertCurr(conn.GetFieldValue("AK_KETJAMINAN"));
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
			conn.QueryString = "exec APPR_ENTRY_KENDARAAN '"+ vsta +"', '"+ LBL_REGNO.Text +"', '"+ LBL_CUREF.Text +"', "+
				LBL_CL_SEQ.Text +", '"+ TXT_AK_APPRBY.Text +"', "+
				tool.ConvertDate(TXT_AK_APPRDATEDAY.Text , DDL_AK_APPRDATEMONTH.SelectedValue, TXT_AK_APPRDATEYEAR.Text) +", '"+
				TXT_AK_ADDRJLN.Text +"', '"+ TXT_AK_ADDRDESA.Text +"', '"+ TXT_AK_ADDRKEC.Text +"', '"+ TXT_AK_ADDRKAB.Text +"', '"+
				TXT_AK_PHNAREA.Text +"', '"+ TXT_AK_PHNNUM.Text +"', '"+ TXT_AK_PHNEXT.Text +"', "+
				tool.ConvertNull(DDL_AK_COLCLASSIFY.SelectedValue) +", "+ tool.ConvertNull(DDL_AK_JNSAGUNAN.SelectedValue) +", '"+
				DDL_AK_ISNEW.SelectedValue +"', '"+ TXT_AK_KETAGUNAN.Text +"', '"+ TXT_AK_LOKJLN.Text +"', '"+ TXT_AK_LOKDESA.Text +"', '"+
				TXT_AK_LOKKEC.Text +"', '"+ TXT_AK_LOKKAB.Text +"', '"+ TXT_AK_LOKPHNAREA.Text +"', '"+ TXT_AK_LOKPHNNUM.Text +"', '"+
				TXT_AK_LOKPHNEXT.Text +"', '"+ tool.ConvertFlag(CHB_AK_BPKB.Checked) +"', '"+ tool.ConvertFlag(CHB_AK_FAKTURBRG.Checked) +"', '"+
				tool.ConvertFlag(CHB_AK_BUKTILAIN.Checked) +"', '"+ TXT_AK_KETBUKTILAIN.Text +"', "+ tool.ConvertNull(DDL_AK_KONDISI.SelectedValue) +", "+
				tool.ConvertNull(DDL_AK_UMUR.SelectedValue) +", '"+ tool.ConvertFlag(CHB_AK_KEPOLISIAN.Checked) +"', '"+
				tool.ConvertFlag(CHB_AK_SUPPLIER.Checked) +"', '"+ tool.ConvertFlag(CHB_AK_CEKLAIN.Checked) +"', '"+
				TXT_AK_KETCEKLAIN.Text +"', '"+ DDL_AK_INSRSTATUS.SelectedValue +"', '"+ TXT_AK_KETINSR.Text +"', "+
				tool.ConvertNum(TXT_AK_INSRAMOUNT.Text) +", '"+ TXT_AK_INSRCOMP.Text +"', "+
				tool.ConvertDate(TXT_AK_EXPDATEDAY.Text, DDL_AK_EXPDATEMONTH.SelectedValue, TXT_AK_EXPDATEYEAR.Text) +", '"+
				DDL_AK_BANJIR.SelectedValue +"', '"+ DDL_AK_PENCURIAN.SelectedValue +"', '"+ DDL_AK_KEBAKARAN.SelectedValue +"', '"+
				DDL_AK_FOTO.SelectedValue +"', "+ tool.ConvertNum(TXT_AK_HRGPASAR.Text) +", "+ tool.ConvertNum(TXT_AK_HRGBALIKNM.Text) +", "+
				tool.ConvertNum(TXT_AK_HRGSMBRLN.Text) +", "+ tool.ConvertNum(TXT_AK_SBLMSMARGIN.Text) +", "+ tool.ConvertFloat(TXT_AK_SFTYMARGIN.Text) +", "+
				tool.ConvertNum(TXT_AK_STLHSMARGIN.Text) +", '"+ TXT_AK_KETJAMINAN.Text +"' ";
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

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}
	}
}
