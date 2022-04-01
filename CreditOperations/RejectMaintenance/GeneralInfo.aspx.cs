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

namespace SME.CreditOperations.RejectMaintenance
{
	/// <summary>
	/// Summary description for GeneralInfo.
	/// </summary>
	public partial class GeneralInfo : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				TXT_CU_REF.Text = Request.QueryString["curef"];
				TXT_AP_REGNO.Text = Request.QueryString["regno"];

				GlobalTools.initDateForm(TXT_CU_TGLJATUHTEMPO_DAY, DDL_CU_TGLJATUHTEMPO_MONTH, TXT_CU_TGLJATUHTEMPO_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_TGLTERBIT_DAY, DDL_CU_TGLTERBIT_MONTH, TXT_CU_TGLTERBIT_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_COMPAKTATERAKHIR_DATE_DAY, DDL_CU_COMPAKTATERAKHIR_DATE_MONTH, TXT_CU_COMPAKTATERAKHIR_DATE_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_COMPEXTRATING_DATE_DAY, DDL_CU_COMPEXTRATING_DATE_MONTH, TXT_CU_COMPEXTRATING_DATE_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_COMPLISTINGDATE_DAY, DDL_CU_COMPLISTINGDATE_MONTH, TXT_CU_COMPLISTINGDATE_YEAR, true);

				DDL_AP_SIGNDATE_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_BUSSTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_COMPBUSSTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_DOB_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_IDCARDEXP_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_COMPTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_JOBTITLE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_MARITAL.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_SEX.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_CITIZENSHIP.Items.Add(new ListItem("- PILIH -", ""));
				DDL_JNSALAMAT_C.Items.Add(new ListItem("- PILIH -", ""));
				DDL_JNSALAMAT_P.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_JNSNASABAH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_EDUCATION.Items.Add(new ListItem("- PILIH -", ""));
				DDL_AP_BOOKINGBRANCH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_JNSNASABAH_P.Items.Add(new ListItem("- PILIH -", ""));
				//20070814 add by sofyan for cco branch
				DDL_AP_CCOBRANCH.Items.Add(new ListItem("- PILIH -", ""));
				
				for (int i = 1; i <= 12; i++)
				{
					DDL_AP_SIGNDATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_AP_RECVDATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CU_DOB_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CU_IDCARDEXP_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				conn.QueryString = "select custtypeid, custtypedesc from rfcustomertype where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					RDO_RFCUSTOMERTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select ALAMATID, ALAMATID + ' - ' + ALAMATDESC as ALAMATDESC from RFJENISALAMAT where ACTIVE='1' order by ALAMATID";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_JNSALAMAT_C.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					DDL_JNSALAMAT_P.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				conn.QueryString = "select sexid, sexdesc from rfsex where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_SEX.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select maritalid, maritaldesc from rfmarital where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_MARITAL.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select jobtitleid, jobtitledesc from rfjobtitle where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_JOBTITLE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select BUSSTYPEID, BUSSTYPEID + ' - ' + BUSSTYPEDESC as BUSSTYPEDESC from RFBUSINESSTYPE where ACTIVE='1' order by busstypeid";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_CU_BUSSTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					DDL_CU_COMPBUSSTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				conn.QueryString = "select comptypeid, comptypedesc from rfcomptype where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_COMPTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select citizenid, citizendesc from rfcitizenship where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_CITIZENSHIP.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select NASABAHID, NASABAHID + ' - ' + NASABAHDESC as NASABAHDESC from RFJENISNASABAH where ACTIVE='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_CU_JNSNASABAH.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					//DDL_CU_JNSNASABAH_P.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				conn.QueryString = "select NASABAHID, NASABAHID + ' - ' + NASABAHDESC as NASABAHDESC from RFJENISNASABAH where NASABAHID = 'A'";
				conn.ExecuteQuery();
				DDL_CU_JNSNASABAH_P.Items.Add(new ListItem(conn.GetFieldValue(0,1), conn.GetFieldValue(0,0)));


				conn.QueryString = "select educationid, educationdesc from rfeducation where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_EDUCATION.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select branch_code + ' - ' + branch_name, branch_code from rfbranch where active = '1' order by branch_code";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_AP_BOOKINGBRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));

				//20070814 add by sofyan for cco branch
				conn.QueryString = "select branch_name, branch_code from vw_ccobranch order by branch_code";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_AP_CCOBRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,1) + " - " + conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));

				DDL_CU_LOKASIDATI2.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_HUBEXECBM.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_HUBKELBM.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_COMPEXTRATING_BY.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_COMPLISTINGCODE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_NEGARADOMISILI.Items.Add(new ListItem("- PILIH -", ""));

				//Lokasi Dati II
				conn.QueryString = "SELECT * FROM VW_LOKASIDATI2";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_LOKASIDATI2.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//Hubungan dg Pejabat Executive BM
				conn.QueryString = "SELECT * FROM VW_HUBUNGANEXECUTIVEBM";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_HUBEXECBM.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//Hubungan dg Keluarga
				conn.QueryString = "SELECT * FROM VW_HUBUNGANKELUARGABM";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_HUBKELBM.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//External Rating
				conn.QueryString = "SELECT * FROM VW_EXTERNALRATINGCOMPANY";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_COMPEXTRATING_BY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//Kode Listing Bursa
				conn.QueryString = "SELECT * FROM VW_KODELISTINGBURSA";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_COMPLISTINGCODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//Negara Domisili
				conn.QueryString = "SELECT * FROM VW_NEGARADOMISILI";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_NEGARADOMISILI.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				ViewData();
			}
			TXT_AP_GROSSSALES.Text = tool.MoneyFormat(TXT_AP_GROSSSALES.Text);
			if (RDO_RFCUSTOMERTYPE.SelectedValue != "01")
				TXT_CU_NETINCOMEMM.Text = tool.MoneyFormat(TXT_CU_NETINCOMEMM.Text);
		}

		private void ViewData()
		{
			// If Company
			conn.QueryString = "select top 1 bs_recvdate from bi_status where cu_ref='" +
				Request.QueryString["curef"] + "' order by bs_recvdate desc";
			conn.ExecuteQuery();
			try
			{
				TXT_BS_RECVDATE.Text = tool.FormatDate(conn.GetFieldValue(0,0), true);
			}
			catch{}
			conn.QueryString = "select top 1 a.*, s.su_fullname , b.branch_name , ar.areaname , " +
				"ag.agencyname, p.programdesc , c.channel_desc , p.BUSINESSUNIT , bu.BUSSUNITDESC " +
				"from vw_ide_geninfo a left join scuser s on a.ap_relmngr = s.userid " +
				"left join rfbranch b on a.branch_code = b.branch_code " +
				"left join rfarea ar on a.areaid = ar.areaid " +
				"left join rfagency ag on a.ap_salesagency = ag.agencyid " +
				"left join rfprogram p on a.prog_code = p.programid and a.areaid = p.areaid " +
				"left join rfchannels c on a.channel_code = c.channel_code " +
				"left join rfbusinessunit bu on p.BUSINESSUNIT = bu.BUSSUNITID " +
				"where ap_regno='" + Request.QueryString["regno"] + "' " ;
			conn.ExecuteQuery();
			
			LBL_AP_RELMNGR.Text = conn.GetFieldValue("AP_RELMNGR");
			TXT_AP_RELMNGR.Text = conn.GetFieldValue("SU_FULLNAME");
			LBL_AREAID.Text = conn.GetFieldValue("AREAID");
			TXT_AREAID.Text = conn.GetFieldValue("AREANAME");
			LBL_BRANCH_CODE.Text = conn.GetFieldValue("BRANCH_CODE");
			TXT_BRANCH_CODE.Text = conn.GetFieldValue("BRANCH_NAME");
			LBL_AP_SALESAGENCY.Text = conn.GetFieldValue("AP_SALESAGENCY");
			TXT_AP_SALESAGENCY.Text = conn.GetFieldValue("AGENCYNAME");
			LBL_PROG_CODE.Text = conn.GetFieldValue("PROG_CODE");
			TXT_PROG_CODE.Text = conn.GetFieldValue("PROGRAMDESC");
			LBL_CHANNEL_CODE.Text = conn.GetFieldValue("CHANNEL_CODE");
			TXT_CHANNEL_CODE.Text = conn.GetFieldValue("CHANNEL_DESC");
			LBL_AP_BUSINESSUNIT.Text = conn.GetFieldValue("BUSINESSUNIT");
			TXT_AP_BUSINESSUNIT.Text = conn.GetFieldValue("BUSSUNITDESC");

			LBL_AP_SALESEXEC.Text = conn.GetFieldValue("AP_SALESEXEC");
			LBL_AP_SALESSUPERV.Text = conn.GetFieldValue("AP_SALESSUPERV");

			TXT_AP_SRCCODE.Text = conn.GetFieldValue("AP_SRCCODE");
			TXT_AP_GROSSSALES.Text = tool.MoneyFormat(conn.GetFieldValue("AP_GROSSSALES"));
			try
			{
				DDL_AP_BOOKINGBRANCH.SelectedValue = conn.GetFieldValue("AP_BOOKINGBRANCH");
			} 
			catch {}

			//20070725 add by sofyan for cco branch
			try {DDL_AP_CCOBRANCH.SelectedValue = conn.GetFieldValue("AP_CCOBRANCH");} 
			catch {DDL_AP_CCOBRANCH.SelectedValue = "";}

			string AP_SIGNDATE = conn.GetFieldValue("AP_SIGNDATE"),
				AP_RECVDATE = conn.GetFieldValue("AP_RECVDATE");
			TXT_AP_SIGNDATE_DAY.Text = tool.FormatDate_Day(AP_SIGNDATE);
			try
			{
				DDL_AP_SIGNDATE_MONTH.SelectedValue = tool.FormatDate_Month(AP_SIGNDATE);
			} 
			catch {}
			TXT_AP_SIGNDATE_YEAR.Text = tool.FormatDate_Year(AP_SIGNDATE);
			TXT_AP_RECVDATE_DAY.Text = tool.FormatDate_Day(AP_RECVDATE);
			try
			{
				DDL_AP_RECVDATE_MONTH.SelectedValue = tool.FormatDate_Month(AP_RECVDATE);
			}
			catch {}
			TXT_AP_RECVDATE_YEAR.Text = tool.FormatDate_Year(AP_RECVDATE);

			try {DDL_CU_LOKASIDATI2.SelectedValue = conn.GetFieldValue("CU_LOKASIDATI2");}
			catch {}
			try {DDL_CU_HUBEXECBM.SelectedValue = conn.GetFieldValue("CU_HUBEXECBM");}
			catch {}
			try {DDL_CU_HUBKELBM.SelectedValue = conn.GetFieldValue("CU_HUBKELBM");}
			catch {}

			if (conn.GetFieldValue("CU_CUSTTYPEID") == "02")
			{
				TR_COMPANY.Visible = false;
				TR_PERSONAL.Visible = true;
				try
				{
					RDO_RFCUSTOMERTYPE.SelectedValue = "02";
				} 
				catch {}

				conn.QueryString = "select * from vw_cust_personal where cu_ref='" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();

				TXT_CU_CIF_P.Text = conn.GetFieldValue("CU_CIF");
				TXT_CU_TITLEBEFORENAME.Text = conn.GetFieldValue("CU_TITLEBEFORENAME");
				TXT_CU_FIRSTNAME.Text = conn.GetFieldValue("CU_FIRSTNAME");
				TXT_CU_MIDDLENAME.Text = conn.GetFieldValue("CU_MIDDLENAME");
				TXT_CU_LASTNAME.Text = conn.GetFieldValue("CU_LASTNAME");
				TXT_CU_ADDR1.Text = conn.GetFieldValue("CU_ADDR1");
				TXT_CU_ADDR2.Text = conn.GetFieldValue("CU_ADDR2");
				TXT_CU_ADDR3.Text = conn.GetFieldValue("CU_ADDR3");
				TXT_CU_CITY.Text = conn.GetFieldValue("CITYNAME");
				LBL_CU_CITY.Text = conn.GetFieldValue("CU_CITY");
				TXT_CU_ZIPCODE.Text = conn.GetFieldValue("CU_ZIPCODE");
				TXT_CU_PHNAREA.Text = conn.GetFieldValue("CU_PHNAREA");
				TXT_CU_PHNNUM.Text = conn.GetFieldValue("CU_PHNNUM");
				TXT_CU_PHNEXT.Text = conn.GetFieldValue("CU_PHNEXT");
				TXT_CU_FAXAREA.Text = conn.GetFieldValue("CU_FAXAREA");
				TXT_CU_FAXNUM.Text = conn.GetFieldValue("CU_FAXNUM");
				TXT_CU_FAXEXT.Text = conn.GetFieldValue("CU_FAXEXT");
				TXT_CU_POB.Text = conn.GetFieldValue("CU_POB");
				TXT_CU_DOB_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("CU_DOB"));
				try
				{
					DDL_CU_DOB_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("CU_DOB"));
				} 
				catch {}
				TXT_CU_DOB_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("CU_DOB"));
				try
				{
					DDL_CU_MARITAL.SelectedValue = conn.GetFieldValue("CU_MARITAL");
				} 
				catch {}
				try
				{
					DDL_CU_SEX.SelectedValue = conn.GetFieldValue("CU_SEX");
				} 
				catch {}
				TXT_CU_IDCARDNUM.Text = conn.GetFieldValue("CU_IDCARDNUM");
				TXT_CU_IDCARDEXP_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("CU_IDCARDEXP"));
				try
				{
					DDL_CU_IDCARDEXP_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("CU_IDCARDEXP"));
				} 
				catch {}
				TXT_CU_IDCARDEXP_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("CU_IDCARDEXP"));
				try
				{
					DDL_CU_JOBTITLE.SelectedValue = conn.GetFieldValue("CU_JOBTITLE");
				} 
				catch {}
				try
				{
					DDL_CU_BUSSTYPE.SelectedValue = conn.GetFieldValue("CU_BUSSTYPE");
				} 
				catch {}
				TXT_CU_ESTABLISHMM.Text = tool.FormatDate_Month(conn.GetFieldValue("CU_ESTABLISHYY"));
				TXT_CU_ESTABLISHYY.Text = tool.FormatDate_Year(conn.GetFieldValue("CU_ESTABLISHYY"));
				TXT_CU_NPWP.Text = conn.GetFieldValue("CU_NPWP");
				try
				{
					DDL_CU_CITIZENSHIP.SelectedValue = conn.GetFieldValue("CU_CITIZENSHIP");
				} 
				catch {}
				try
				{
					DDL_JNSALAMAT_P.SelectedValue = conn.GetFieldValue("CU_JNSALAMAT");
				} 
				catch {}
				TXT_CU_KTPADDR1.Text = conn.GetFieldValue("CU_KTPADDR1");
				TXT_CU_KTPADDR2.Text = conn.GetFieldValue("CU_KTPADDR2");
				TXT_CU_KTPADDR3.Text = conn.GetFieldValue("CU_KTPADDR3");
				LBL_CU_KTPCITY.Text = conn.GetFieldValue("CU_KTPCITY");
				TXT_CU_KTPCITY.Text = conn.GetFieldValue("KTPCITY");
				TXT_CU_KTPZIPCODE.Text = conn.GetFieldValue("CU_KTPZIPCODE");
				try
				{
					DDL_CU_EDUCATION.SelectedValue = conn.GetFieldValue("CU_EDUCATION");
				} 
				catch {}
				TXT_CU_NETINCOMEMM.Text = tool.MoneyFormat(conn.GetFieldValue("CU_NETINCOMEMM"));
				TXT_CU_CHILDREN.Text = conn.GetFieldValue("CU_CHILDREN");
				try
				{
					DDL_CU_JNSNASABAH_P.SelectedValue = conn.GetFieldValue("CU_JNSNASABAH");
				} 
				catch {}
				RDO_CU_PERNAHJDNASABAHBM.SelectedValue = (conn.GetFieldValue("CU_PERNAHJDNASABAHBM")==""?"0":conn.GetFieldValue("CU_PERNAHJDNASABAHBM"));
				TXT_CU_MOTHER.Text = conn.GetFieldValue("CU_MOTHER");

				TXT_CU_NAMAPELAPORAN.Text = conn.GetFieldValue("CU_NAMAPELAPORAN");
				try {DDL_CU_NEGARADOMISILI.SelectedValue = conn.GetFieldValue("CU_NEGARADOMISILI");}
				catch {}
			}
			
			else
			{
				TR_COMPANY.Visible = true;
				TR_PERSONAL.Visible = false;
				try
				{
					RDO_RFCUSTOMERTYPE.SelectedValue = "01";
				}
				catch {}

				conn.QueryString = "select * from vw_cust_company where cu_ref='" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();
				
				TXT_CU_CIF_C.Text = conn.GetFieldValue("CU_CIF");
				try
				{
					DDL_CU_COMPTYPE.SelectedValue = conn.GetFieldValue("CU_COMPTYPE");
				}
				catch {}
				try
				{
					DDL_CU_JNSNASABAH.SelectedValue = conn.GetFieldValue("CU_JNSNASABAH");
				}
				catch {}
				TXT_CU_COMPNAME.Text = conn.GetFieldValue("CU_COMPNAME");
				TXT_CU_COMPADDR1.Text = conn.GetFieldValue("CU_COMPADDR1");
				TXT_CU_COMPADDR2.Text = conn.GetFieldValue("CU_COMPADDR2");
				TXT_CU_COMPADDR3.Text = conn.GetFieldValue("CU_COMPADDR3");
				TXT_CU_COMPCITY.Text = conn.GetFieldValue("CITYNAME");
				LBL_CU_COMPCITY.Text = conn.GetFieldValue("CU_COMPCITY");
				TXT_CU_COMPZIPCODE.Text = conn.GetFieldValue("CU_COMPZIPCODE");
				try
				{
					DDL_CU_COMPBUSSTYPE.SelectedValue = conn.GetFieldValue("CU_COMPBUSSTYPE");
				}
				catch {}
				TXT_CU_COMPESTABLISH.Text = tool.FormatDate_Year(conn.GetFieldValue("CU_COMPESTABLISH"));
				TXT_CU_COMPESTABLISHMM.Text = tool.FormatDate_Month(conn.GetFieldValue("CU_COMPESTABLISH"));
				TXT_CU_COMPPHNAREA.Text = conn.GetFieldValue("CU_COMPPHNAREA");
				TXT_CU_COMPPHNNUM.Text = conn.GetFieldValue("CU_COMPPHNNUM");
				TXT_CU_COMPPHNEXT.Text = conn.GetFieldValue("CU_COMPPHNEXT");
				TXT_CU_COMPFAXAREA.Text = conn.GetFieldValue("CU_COMPFAXAREA");
				TXT_CU_COMPFAXNUM.Text = conn.GetFieldValue("CU_COMPFAXNUM");
				TXT_CU_COMPFAXEXT.Text = conn.GetFieldValue("CU_COMPFAXEXT");
				TXT_CU_COMPNPWP.Text = conn.GetFieldValue("CU_NPWP");
				TXT_CU_CONTACTPERSON.Text = conn.GetFieldValue("CU_CONTACTPERSON");
				TXT_CU_CONTACTPHNAREA.Text = conn.GetFieldValue("CU_CONTACTPHNAREA");
				TXT_CU_CONTACTPHNNUM.Text = conn.GetFieldValue("CU_CONTACTPHNNUM");
				TXT_CU_CONTACTPHNEXT.Text = conn.GetFieldValue("CU_CONTACTPHNEXT");
				TXT_CU_COMPEMPLOYEE.Text = conn.GetFieldValue("CU_COMPEMPLOYEE");
				try {DDL_JNSALAMAT_C.SelectedValue = conn.GetFieldValue("CU_JNSALAMAT");}
				catch {}
				TXT_CU_TDP.Text = conn.GetFieldValue("CU_TDP");
//				try {GlobalTools.fromSQLDate(conn.GetFieldValue("CU_INSURANCEDATE").ToString(), TXT_CU_COMPTGASURANSI_DAY, DDL_CU_TGASURANSI_MONTH, TXT_CU_COMPTGASURANSI_YEAR);}
//				catch {}
				try {GlobalTools.fromSQLDate(conn.GetFieldValue("CU_TGLTERBIT"), TXT_CU_TGLTERBIT_DAY, DDL_CU_TGLTERBIT_MONTH, TXT_CU_TGLTERBIT_YEAR);}
				catch{}
				try {GlobalTools.fromSQLDate(conn.GetFieldValue("CU_TGLJATUHTEMPO"), TXT_CU_TGLJATUHTEMPO_DAY, DDL_CU_TGLJATUHTEMPO_MONTH, TXT_CU_TGLJATUHTEMPO_YEAR);}
				catch{}
				TXT_CU_COMPNOTARYNAME.Text = conn.GetFieldValue("CU_COMPNOTARYNAME");
				RDO_CU_PERNAHJDNASABAHBM.SelectedValue = (conn.GetFieldValue("CU_PERNAHJDNASABAHBM")==""?"0":conn.GetFieldValue("CU_PERNAHJDNASABAHBM"));
				TXT_CU_COMPANGGOTA.Text = conn.GetFieldValue("CU_COMPANGGOTA");
				TXT_CU_COMPPOB.Text = conn.GetFieldValue("CU_COMPPOB");
				TXT_CU_COMPAKTAPENDIRIAN.Text = conn.GetFieldValue("CU_COMPAKTAPENDIRIAN");

				TXT_CU_COMPAKTATERAKHIR_NO.Text = conn.GetFieldValue("CU_COMPAKTATERAKHIR_NO");
				try { GlobalTools.fromSQLDate(conn.GetFieldValue("CU_COMPAKTATERAKHIR_DATE"), TXT_CU_COMPAKTATERAKHIR_DATE_DAY, DDL_CU_COMPAKTATERAKHIR_DATE_MONTH, TXT_CU_COMPAKTATERAKHIR_DATE_YEAR); }
				catch {}
				try { GlobalTools.fromSQLDate(conn.GetFieldValue("CU_COMPEXTRATING_DATE"), TXT_CU_COMPEXTRATING_DATE_DAY, DDL_CU_COMPEXTRATING_DATE_MONTH, TXT_CU_COMPEXTRATING_DATE_YEAR); }
				catch {}
				try {DDL_CU_COMPLISTINGCODE.SelectedValue = conn.GetFieldValue("CU_COMPLISTINGCODE");}
				catch {}
				try { GlobalTools.fromSQLDate(conn.GetFieldValue("CU_COMPLISTINGDATE"), TXT_CU_COMPLISTINGDATE_DAY, DDL_CU_COMPLISTINGDATE_MONTH, TXT_CU_COMPLISTINGDATE_YEAR); }
				catch {}
				try {DDL_CU_COMPEXTRATING_BY.SelectedValue = conn.GetFieldValue("CU_COMPEXTRATING_BY");}
				catch {}
				string cu_comprating_class = conn.GetFieldValue("CU_COMPEXTRATING_CLASS");
				GlobalTools.fillRefList(DDL_CU_COMPEXTRATING_CLASS, "SELECT RTGCLASS_CODE, RTGCLASS_DESC FROM RFEXTERNALRATINGCLASS WHERE RTGCOMP_CODE = '" + DDL_CU_COMPEXTRATING_BY.SelectedValue + "' ORDER BY RTGCLASS_CODE", false, conn);
				try {DDL_CU_COMPEXTRATING_CLASS.SelectedValue = cu_comprating_class;}
				catch {}
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

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			string curef = TXT_CU_REF.Text;
			
			Int64 signDate = Int64.Parse(Tools.toISODate(TXT_AP_SIGNDATE_DAY, DDL_AP_SIGNDATE_MONTH, TXT_AP_SIGNDATE_YEAR)),
				now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())),
				compEstablish, personalEstablish;
			
			if (signDate > now)
			{
				Tools.popMessage(this, "Sign Date cannot be greater than current date!");
				return;
			}
			
			if (RDO_RFCUSTOMERTYPE.SelectedValue == "01")
			{
				if (int.Parse(TXT_CU_COMPESTABLISHMM.Text) > 12)
				{
					Tools.popMessage(this, "Berdiri Sejak (MM) tidak valid");
					return;
				}
				compEstablish = Int64.Parse(Tools.toISODate("01", TXT_CU_COMPESTABLISHMM.Text, TXT_CU_COMPESTABLISH.Text));
				if (compEstablish > now)
				{
					Tools.popMessage(this, "Berdiri Sejak cannot be greater than current date!");
					return;
				}
				conn.QueryString = "exec IDE_GENINFO_COMP_INSERT_reject '" + 
					TXT_AP_REGNO.Text + "', '" + 
					TXT_CU_REF.Text + "', '" +
					LBL_AREAID.Text.Trim() + "', '" +
					LBL_PROG_CODE.Text + "', '" +
					LBL_BRANCH_CODE.Text + "', '" + 
					LBL_AP_RELMNGR.Text + "', " + 
					tool.ConvertNull(LBL_CHANNEL_CODE.Text) + ", '" + 
					TXT_AP_SRCCODE.Text + "', " + 
					tool.ConvertFloat(TXT_AP_GROSSSALES.Text) + ", " + 
					tool.ConvertDate(TXT_AP_SIGNDATE_DAY.Text, DDL_AP_SIGNDATE_MONTH.SelectedValue, TXT_AP_SIGNDATE_YEAR.Text) + ", " +
					tool.ConvertNull(LBL_AP_SALESAGENCY.Text) + ", " + 
					tool.ConvertNull(LBL_AP_SALESSUPERV.Text) + ", " + 
					tool.ConvertNull(LBL_AP_SALESEXEC.Text) + ", '" +					
					Session["UserID"].ToString() + "', '" + 
					RDO_RFCUSTOMERTYPE.SelectedValue + "', '" +
					TXT_CU_CIF_C.Text + "', '" + DDL_CU_COMPTYPE.SelectedValue + "', '" +
					TXT_CU_COMPNAME.Text + "', '" + 
					TXT_CU_COMPADDR1.Text + "', '" + TXT_CU_COMPADDR2.Text + "', '" + TXT_CU_COMPADDR3.Text + "', '" + 
					LBL_CU_COMPCITY.Text + "', '" + TXT_CU_COMPZIPCODE.Text + "', '" +
					DDL_CU_COMPBUSSTYPE.SelectedValue + "', " + 
					tool.ConvertDate("1", TXT_CU_COMPESTABLISHMM.Text, TXT_CU_COMPESTABLISH.Text) + ", '" +
					TXT_CU_COMPPHNAREA.Text + "', '" + TXT_CU_COMPPHNNUM.Text + "', '" + 
					TXT_CU_COMPPHNEXT.Text + "', '" +
					TXT_CU_COMPFAXAREA.Text + "', '" + TXT_CU_COMPFAXNUM.Text + "', '" + 
					TXT_CU_COMPFAXEXT.Text + "', '" + 
					TXT_CU_COMPNPWP.Text + "', '" + TXT_CU_CONTACTPERSON.Text + "', '" +
					TXT_CU_CONTACTPHNAREA.Text + "', '" + TXT_CU_CONTACTPHNNUM.Text + "', '" + 
					TXT_CU_CONTACTPHNEXT.Text + "', '" + 
					RDO_BI_CHECKING.SelectedValue + "', '0', '" + TXT_CU_COMPEMPLOYEE.Text + "', " + 
					tool.ConvertNull(DDL_JNSALAMAT_C.SelectedValue) + ", '" + 
					TXT_CU_TDP.Text + "', "
					+ tool.ConvertNull(DDL_CU_JNSNASABAH.SelectedValue) + ", '" + 
					LBL_AP_BUSINESSUNIT.Text + "', '" + 
					DDL_AP_BOOKINGBRANCH.SelectedValue + "', null, '" + 
					RDO_CU_PERNAHJDNASABAHBM.SelectedValue + "', " + 
					tool.ConvertNull(TXT_CU_COMPAKTAPENDIRIAN.Text.Trim()) + ", " +
					"null, null, '" + DDL_AP_CCOBRANCH.SelectedValue + "', '" + 
					TXT_CU_COMPPOB.Text + "', '" +
					DDL_CU_LOKASIDATI2.SelectedValue + "', '" +
					DDL_CU_HUBEXECBM.SelectedValue + "', '" +
					DDL_CU_HUBKELBM.SelectedValue + "', '" +
					TXT_CU_COMPAKTATERAKHIR_NO.Text + "', " +
					tool.ConvertDate(TXT_CU_COMPAKTATERAKHIR_DATE_DAY.Text, DDL_CU_COMPAKTATERAKHIR_DATE_MONTH.SelectedValue, TXT_CU_COMPAKTATERAKHIR_DATE_YEAR.Text) + ", '" +
					DDL_CU_COMPEXTRATING_BY.SelectedValue + "', '" +
					DDL_CU_COMPEXTRATING_CLASS.SelectedValue + "', " +
					tool.ConvertDate(TXT_CU_COMPEXTRATING_DATE_DAY.Text, DDL_CU_COMPEXTRATING_DATE_MONTH.SelectedValue, TXT_CU_COMPEXTRATING_DATE_YEAR.Text) + ", '" +
					DDL_CU_COMPLISTINGCODE.SelectedValue + "', " +
					tool.ConvertDate(TXT_CU_COMPLISTINGDATE_DAY.Text, DDL_CU_COMPLISTINGDATE_MONTH.SelectedValue, TXT_CU_COMPLISTINGDATE_YEAR.Text);
				conn.ExecuteNonQuery();

				//--- untuk memecah kebanyakan argumen
				conn.QueryString = "exec IDE_GENINFO_COMP_INSERT2 '" + 
					curef + "', null, " + 				
					tool.ConvertDate(TXT_CU_TGLJATUHTEMPO_DAY.Text, DDL_CU_TGLJATUHTEMPO_MONTH.SelectedValue, TXT_CU_TGLJATUHTEMPO_YEAR.Text) + ", " + // tanggal jatuh tempo
					tool.ConvertDate(TXT_CU_TGLTERBIT_DAY.Text, DDL_CU_TGLTERBIT_MONTH.SelectedValue, TXT_CU_TGLJATUHTEMPO_YEAR.Text) + ", " + // tgl penerbitan
					tool.ConvertNull(TXT_CU_COMPNOTARYNAME.Text.Trim()) + ", " +	// nama notaris
					tool.ConvertNull(TXT_CU_COMPANGGOTA.Text.Trim());
				conn.ExecuteNonQuery();

			}
			else
			{
				if (int.Parse(TXT_CU_ESTABLISHMM.Text) > 12)
				{
					Tools.popMessage(this, "Berdiri Sejak (MM) tidak valid");
					return;
				}
				personalEstablish = Int64.Parse(Tools.toISODate("01", TXT_CU_ESTABLISHMM.Text, TXT_CU_ESTABLISHYY.Text));
				if (personalEstablish > now)
				{
					Tools.popMessage(this, "Berdiri Sejak cannot be greater than current date!");
					return;
				}				

				//////////////////////////////////////////////////////////////////
				/// VALIDASI TANGGAL LAHIR
				/// 
				if (!GlobalTools.isDateValid(TXT_CU_DOB_DAY.Text, DDL_CU_DOB_MONTH.SelectedValue, TXT_CU_DOB_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Lahir tidak valid!");
					return;
				}

				////////////////////////////////////////////////////////////////////
				///	VALIDASI TANGGAL BERAKHIR KTP
				///	
				if (!GlobalTools.isDateValid(TXT_CU_IDCARDEXP_DAY.Text, DDL_CU_IDCARDEXP_MONTH.SelectedValue, TXT_CU_IDCARDEXP_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Berakhir KTP tidak valid!");
					return;
				}

				Int64 idcardexp = Int64.Parse(Tools.toISODate(TXT_CU_IDCARDEXP_DAY.Text, DDL_CU_IDCARDEXP_MONTH.SelectedValue, TXT_CU_IDCARDEXP_YEAR.Text));
				if (idcardexp < now) 
				{
					GlobalTools.popMessage(this, "Tanggal Berakhir KTP tidak boleh kurang dari tanggal sekarang!");
					return;
				}

//				////////////////////////////////////////////////////////////////////
//				///	VALIDASI TANGGAL BERAKHIR KTP SPOUSE
//				///	
//				if (TXT_CU_SPOUSE_KTPEXPDATE_DAY.Text != "" && DDL_CU_SPOUSE_KTPEXPDATE_MONTH.SelectedValue != "" && TXT_CU_SPOUSE_KTPEXPDATE_YEAR.Text != "") 
//				{
//					if (!GlobalTools.isDateValid(TXT_CU_SPOUSE_KTPEXPDATE_DAY.Text, DDL_CU_SPOUSE_KTPEXPDATE_MONTH.SelectedValue, TXT_CU_SPOUSE_KTPEXPDATE_YEAR.Text)) 
//					{
//						GlobalTools.popMessage(this, "Tanggal Berakhir KTP Spouse tidak valid!");
//						return;
//					}
//				}
//				Int64 idcardexp_spouse = Int64.Parse(Tools.toISODate(TXT_CU_SPOUSE_KTPEXPDATE_DAY.Text, DDL_CU_SPOUSE_KTPEXPDATE_MONTH.SelectedValue, TXT_CU_SPOUSE_KTPEXPDATE_YEAR.Text));
//				if (idcardexp_spouse < now) 
//				{
//					GlobalTools.popMessage(this, "Tanggal Berakhir KTP Spouse tidak boleh kurang dari tanggal sekarang!");
//					return;
//				}
//				
//				////////////////////////////////////////////////////////////////////
//				///	VALIDASI TANGGAL ISSUANCE KTP
//				///	
//				if (TXT_CU_SPOUSE_KTPISSUEDATE_DAY.Text != "" && DDL_CU_SPOUSE_KTPISSUEDATE_MONTH.SelectedValue != "" && TXT_CU_SPOUSE_KTPISSUEDATE_YEAR.Text != "") 
//				{
//					if (!GlobalTools.isDateValid(TXT_CU_SPOUSE_KTPISSUEDATE_DAY.Text, DDL_CU_SPOUSE_KTPISSUEDATE_MONTH.SelectedValue, TXT_CU_SPOUSE_KTPISSUEDATE_YEAR.Text)) 
//					{
//						GlobalTools.popMessage(this, "Tanggal Issuance KTP Spouse tidak valid!");
//						return;
//					}
//				}	

				conn.QueryString = "exec IDE_GENINFO_PERSON_INSERT_reject '" + 
					TXT_AP_REGNO.Text + "', '" +
					TXT_CU_REF.Text + "', '" + 
					LBL_AREAID.Text + "', '" +
					LBL_PROG_CODE.Text + "', '" +
					LBL_BRANCH_CODE.Text + "', '" + 
					LBL_AP_RELMNGR.Text + "', " + 
					tool.ConvertNull(LBL_CHANNEL_CODE.Text) + ", '" + 
					TXT_AP_SRCCODE.Text + "', " + 
					tool.ConvertFloat(TXT_AP_GROSSSALES.Text) + ", " +
					tool.ConvertDate(TXT_AP_SIGNDATE_DAY.Text, DDL_AP_SIGNDATE_MONTH.SelectedValue, TXT_AP_SIGNDATE_YEAR.Text) + ", " +
					tool.ConvertNull(LBL_AP_SALESAGENCY.Text) + ", " + 
					tool.ConvertNull(LBL_AP_SALESSUPERV.Text) + ", " + 
					tool.ConvertNull(LBL_AP_SALESEXEC.Text) + ", '" +					
					Session["UserID"] + "', '" + 
					RDO_RFCUSTOMERTYPE.SelectedValue + "', '" +
					TXT_CU_CIF_P.Text + "', '" +
					TXT_CU_FIRSTNAME.Text + "', '" + 
					TXT_CU_MIDDLENAME.Text + "', '" + 
					TXT_CU_LASTNAME.Text + "', '" + 
					TXT_CU_ADDR1.Text + "', '" + 
					TXT_CU_ADDR2.Text + "', '" + 
					TXT_CU_ADDR3.Text + "', '" + 
					LBL_CU_CITY.Text + "', '" + TXT_CU_ZIPCODE.Text + "', '" + 
					TXT_CU_PHNAREA.Text + "', '" + TXT_CU_PHNNUM.Text + "', '" + 
					TXT_CU_PHNEXT.Text + "', '" + TXT_CU_FAXAREA.Text + "', '" + 
					TXT_CU_FAXNUM.Text + "', '" + TXT_CU_FAXEXT.Text + "', '" +
					TXT_CU_POB.Text + "', " + tool.ConvertDate(TXT_CU_DOB_DAY.Text, DDL_CU_DOB_MONTH.SelectedValue, TXT_CU_DOB_YEAR.Text) + ", '" +
					DDL_CU_MARITAL.SelectedValue + "', '" + DDL_CU_SEX.SelectedValue + "', '" + 
					TXT_CU_IDCARDNUM.Text + "', " + tool.ConvertDate(TXT_CU_IDCARDEXP_DAY.Text, DDL_CU_IDCARDEXP_MONTH.SelectedValue, TXT_CU_IDCARDEXP_YEAR.Text) + ", " + 
					tool.ConvertNull(DDL_CU_JOBTITLE.SelectedValue) + ", '" + DDL_CU_BUSSTYPE.SelectedValue + "', " +
					tool.ConvertDate("1", TXT_CU_ESTABLISHMM.Text, TXT_CU_ESTABLISHYY.Text) + ", '" + TXT_CU_NPWP.Text + "', '" + 
					DDL_CU_CITIZENSHIP.SelectedValue + "', '" + 
					RDO_BI_CHECKING.SelectedValue + "', '0', " + 
					tool.ConvertNull(DDL_JNSALAMAT_P.SelectedValue) + ", '" + 
					TXT_CU_KTPADDR1.Text + "', '" + 
					TXT_CU_KTPADDR2.Text + "', '" + 
					TXT_CU_KTPADDR3.Text + "', '" + 
					LBL_CU_KTPCITY.Text + "', '" + 
					TXT_CU_KTPZIPCODE.Text + "', " + 
					tool.ConvertNull(DDL_CU_EDUCATION.SelectedValue) + ", " +
					tool.ConvertFloat(TXT_CU_NETINCOMEMM.Text) + ", '" + 
					TXT_CU_CHILDREN.Text + "', '" + 
					LBL_AP_BUSINESSUNIT.Text + "', '" + 
					DDL_AP_BOOKINGBRANCH.SelectedValue + "', " + 
					tool.ConvertNull(DDL_CU_JNSNASABAH_P.SelectedValue) + ", null, '" + 
					RDO_CU_PERNAHJDNASABAHBM.SelectedValue + "', null, null, '" + 
					TXT_CU_TITLEBEFORENAME.Text+"', '" + DDL_AP_CCOBRANCH.SelectedValue + "','"+
					TXT_CU_MOTHER.Text +"', '" +
					DDL_CU_LOKASIDATI2.SelectedValue + "', '" +
					DDL_CU_HUBEXECBM.SelectedValue + "', '" +
					DDL_CU_HUBKELBM.SelectedValue + "', '" +
					TXT_CU_NAMAPELAPORAN.Text + "', '" +
					DDL_CU_NEGARADOMISILI.SelectedValue + "'";
					conn.ExecuteNonQuery();
			}
			conn.QueryString = "update application set AP_RECVDATE = " +
				tool.ConvertDate(TXT_AP_RECVDATE_DAY.Text, DDL_AP_RECVDATE_MONTH.SelectedValue, TXT_AP_RECVDATE_YEAR.Text) +
				", AP_SIGNDATE = " + tool.ConvertDate(TXT_AP_SIGNDATE_DAY.Text, DDL_AP_SIGNDATE_MONTH.SelectedValue, TXT_AP_SIGNDATE_YEAR.Text) +
				" where ap_regno = '" + TXT_AP_REGNO.Text + "' ";
			conn.ExecuteNonQuery();
		}

		protected void BTN_SEARCHPERSONAL_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('../../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_ZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
		}

		protected void BTN_SEARCHCOMP_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('../../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_COMPZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
		}

		protected void BTN_SEARCHKTPZIP_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('../../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_KTPZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
		}

		protected void TXT_CU_ZIPCODE_TextChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select cityid, cityname, description from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + 
				TXT_CU_ZIPCODE.Text.Trim() + "' ";
			conn.ExecuteQuery();
			try
			{
				LBL_CU_CITY.Text = conn.GetFieldValue(0,0);
				TXT_CU_CITY.Text = conn.GetFieldValue(0,2);
			}
			catch
			{
				TXT_CU_ZIPCODE.Text = "";
				Response.Write("<script language='javascript'>alert('Invalid Zipcode!');</script>");
			}
		}

		protected void TXT_CU_COMPZIPCODE_TextChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select cityid, cityname, description from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + 
				TXT_CU_COMPZIPCODE.Text.Trim() + "' ";
			conn.ExecuteQuery();
			try
			{
				LBL_CU_COMPCITY.Text = conn.GetFieldValue(0,0);
				TXT_CU_COMPCITY.Text = conn.GetFieldValue(0,2);
			}
			catch
			{
				TXT_CU_COMPZIPCODE.Text = "";
				Response.Write("<script language='javascript'>alert('Invalid Zipcode!');</script>");
			}
		}

		protected void TXT_CU_KTPZIPCODE_TextChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select cityid, cityname, description from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + 
				TXT_CU_KTPZIPCODE.Text.Trim() + "' ";
			conn.ExecuteQuery();
			try
			{
				LBL_CU_KTPCITY.Text = conn.GetFieldValue(0,0);
				TXT_CU_KTPCITY.Text = conn.GetFieldValue(0,2);
			}
			catch
			{
				TXT_CU_KTPZIPCODE.Text = "";
				Response.Write("<script language='javascript'>alert('Invalid Zipcode!');</script>");
			}
		}

		protected void TXT_AP_SRCCODE_TextChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select count(*) from rfsourcecode where sourcecode='" + TXT_AP_SRCCODE.Text + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue(0,0) == "0")
			{
				TXT_AP_SRCCODE.Text = "";
				Response.Write("<script language='javascript'>alert('Invalid Source Code!');</script>");
			}	
		}

		protected void DDL_CU_COMPEXTRATING_BY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			GlobalTools.fillRefList(DDL_CU_COMPEXTRATING_CLASS, "SELECT RTGCLASS_CODE, RTGCLASS_DESC FROM RFEXTERNALRATINGCLASS WHERE RTGCOMP_CODE = '" + DDL_CU_COMPEXTRATING_BY.SelectedValue + "' ORDER BY RTGCLASS_CODE", false, conn);
		}

	}
}
