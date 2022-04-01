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
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.HistoricalLoanInfo
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

            BTN_BACK.Click += new ImageClickEventHandler(BTN_BACK_Click);

			if (!IsPostBack) 
			{
				TXT_CU_REF.Text = Request.QueryString["curef"];
				TXT_AP_REGNO.Text = Request.QueryString["regno"];

				GlobalTools.initDateForm(TXT_CU_TGLJATUHTEMPO_DAY, DDL_CU_TGLJATUHTEMPO_MONTH, TXT_CU_TGLJATUHTEMPO_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_TGLTERBIT_DAY, DDL_CU_TGLTERBIT_MONTH, TXT_CU_TGLTERBIT_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_DOB_DAY, DDL_CU_DOB_MONTH, TXT_CU_DOB_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_IDCARDEXP_DAY, DDL_CU_IDCARDEXP_MONTH, TXT_CU_IDCARDEXP_YEAR, true);
				GlobalTools.initDateForm(TXT_AP_SIGNDATE_DAY, DDL_AP_SIGNDATE_MONTH, TXT_AP_SIGNDATE_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_SPOUSE_KTPISSUEDATE_DAY, DDL_CU_SPOUSE_KTPISSUEDATE_MONTH, TXT_CU_SPOUSE_KTPISSUEDATE_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_SPOUSE_KTPEXPDATE_DAY, DDL_CU_SPOUSE_KTPEXPDATE_MONTH, TXT_CU_SPOUSE_KTPEXPDATE_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_COMPESTABLISHDD, DDL_CU_COMPESTABLISHMM, TXT_CU_COMPESTABLISHYY, true);
				GlobalTools.initDateForm(TXT_CU_ESTABLISHDD, DDL_CU_ESTABLISHMM, TXT_CU_ESTABLISHYY, true);
				GlobalTools.initDateForm(TXT_CU_COMPTGASURANSI_DAY, DDL_CU_TGASURANSI_MONTH, TXT_CU_COMPTGASURANSI_YEAR, true);


				GlobalTools.fillRefList(DDL_CU_BUSSTYPE, "select BUSSTYPEID, BUSSTYPEDESC from RFBUSINESSTYPE where LEN(BUSSTYPEID) < 3 order by busstypeid", true, conn);
				GlobalTools.fillRefList(DDL_CU_COMPBUSSTYPE, "select BUSSTYPEID, BUSSTYPEDESC from RFBUSINESSTYPE where LEN(BUSSTYPEID) < 3 order by busstypeid", true, conn);
				GlobalTools.fillRefList(DDL_CU_COMPTYPE, "select comptypeid, comptypedesc from rfcomptype ", false, conn);
				GlobalTools.fillRefList(DDL_CU_JOBTITLE, "select jobtitleid, jobtitledesc from rfjobtitle ", false, conn);
				GlobalTools.fillRefList(DDL_CU_MARITAL, "select maritalid, maritaldesc from rfmarital ", false, conn);
				GlobalTools.fillRefList(DDL_CU_SEX, "select sexid, sexdesc from rfsex ", false, conn);
				GlobalTools.fillRefList(DDL_CU_CITIZENSHIP, "select citizenid, citizendesc from rfcitizenship ", false, conn);
				GlobalTools.fillRefList(DDL_JNSALAMAT_C, "select ALAMATID, ALAMATDESC from RFJENISALAMAT order by ALAMATID", true, conn);
				GlobalTools.fillRefList(DDL_JNSALAMAT_P, "select ALAMATID, ALAMATDESC from RFJENISALAMAT order by ALAMATID", false, conn);
				GlobalTools.fillRefList(DDL_CU_JNSNASABAH, "select NASABAHID, NASABAHDESC from RFJENISNASABAH ", true, conn);
				GlobalTools.fillRefList(DDL_CU_EDUCATION, "select educationid, educationdesc from rfeducation ", false, conn);
				GlobalTools.fillRefList(DDL_AP_BOOKINGBRANCH, "select branch_code, branch_name from rfbranch where br_isbookingbranch = '1' order by branch_code", false, conn);
				GlobalTools.fillRefList(DDL_CU_JNSNASABAH_P, "select NASABAHID, NASABAHDESC from RFJENISNASABAH where NASABAHID = 'A'", true, conn);
				GlobalTools.fillRefList(DDL_AP_BUSINESSUNIT, "select * from rfbusinessunit ", false, conn);
				GlobalTools.fillRefList(DDL_CHANNEL_CODE, "select channel_code, channel_desc from rfchannels ", false, conn);
				GlobalTools.fillRefList(DDL_AP_SRCCODE, "select sourcecode, sourcedesc from rfsourcecode ", false, conn);
				GlobalTools.fillRefList(DDL_AP_SALESAGENCY, "select agencyid, agencyname from vw_rfagency where areaid='" + Session["AreaID"].ToString() + "' and agencytypeid='02' ", false, conn);
				GlobalTools.fillRefList(DDL_AP_GRSALESCURR, "select currencyid, currencyid  from rfcurrency ", false, conn);
				GlobalTools.fillRefList(DDL_CU_HOMESTA, "select * from RFHOMESTA where ACTIVE='1'", true, conn);
				GlobalTools.fillRefList(DDL_PROG_CODE, "select programid, programdesc from rfprogram where areaid='" + Session["AreaID"].ToString() + "'", false, conn);

				conn.QueryString = "select CUSTTYPEID, CUSTTYPEDESC from RFCUSTOMERTYPE ";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					RDO_RFCUSTOMERTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//Populate Group Unit
				GlobalTools.fillRefList(DDL_GRPUNIT, "select * from RFGROUPUNIT ", false, conn);
				DDL_GRPUNIT.Items.RemoveAt(0);	//hapus --PILIH--
				DDL_GRPUNIT.SelectedValue = "CO";

				try { DDL_AP_GRSALESCURR.SelectedValue = "IDR"; } catch { }

				viewData();
				ViewDataVisited();
			}

			ViewMenu();
			viewSubMenu();

			TXT_AP_GROSSSALES.Text = tool.MoneyFormat(TXT_AP_GROSSSALES.Text);
			if (RDO_RFCUSTOMERTYPE.SelectedValue != "01")
				TXT_CU_NETINCOMEMM.Text = tool.MoneyFormat(TXT_CU_NETINCOMEMM.Text);
		}

		private void viewData() 
		{
			try 
			{
				//BI Checking
				conn.QueryString = "select AP_CHECKBI, AP_CHECKBIGROUP from APPLICATION where AP_REGNO = '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			if (conn.GetRowCount() > 0) 
			{
				try 
				{
					RDO_BI_CHECKING.SelectedValue	= conn.GetFieldValue("AP_CHECKBI");
					DDL_GRPUNIT.SelectedValue		= conn.GetFieldValue("AP_CHECKBIGROUP");
				} 
				catch {}
			}

			//Data Customer
			conn.QueryString = "select top 1 * from vw_ide_geninfo_history where ap_regno='" + Request.QueryString["regno"] + "' or ap_regno is null order by ap_recvdate desc";
			conn.ExecuteQuery();
			
			string salesExec = conn.GetFieldValue("AP_SALESEXEC"), salesSuperv = conn.GetFieldValue("AP_SALESSUPERV");
			TXT_AREAID.Text = conn.GetFieldValue("AREANAME");
			TXT_BRANCH_CODE.Text = conn.GetFieldValue("BRANCH_NAME");
			TXT_AP_RELMNGR.Text = conn.GetFieldValue("RMFULLNAME");

			if (conn.GetFieldValue("CU_CUSTTYPEID") == "02")
			{
				TR_COMPANY.Visible = false;
				TR_PERSONAL.Visible = true;
				RDO_RFCUSTOMERTYPE.SelectedValue = "02";
				
				TXT_AP_GROSSSALES.Text = conn.GetFieldValue("AP_GROSSSALES");
				try {DDL_AP_BOOKINGBRANCH.SelectedValue = conn.GetFieldValue("AP_BOOKINGBRANCH");} 
				catch {DDL_AP_BOOKINGBRANCH.SelectedValue = "";}

				try {DDL_AP_GRSALESCURR.SelectedValue = conn.GetFieldValue("AP_GROSSSALESCURR");} 
				catch { }

				conn.QueryString = "select seq, ag_officer from rfagencyuser where agencyid='" + DDL_AP_SALESAGENCY.SelectedValue + "' and active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_AP_SALESEXEC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					DDL_AP_SALESSUPERV.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}
				
				conn.QueryString = "select * from VW_CUST_PERSONAL_HISTORY where ap_regno='" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				TXT_CU_CIF_P.Text = conn.GetFieldValue("CU_CIF");
				TXT_CU_FIRSTNAME.Text = conn.GetFieldValue("CU_FIRSTNAME");
				TXT_CU_MIDDLENAME.Text = conn.GetFieldValue("CU_MIDDLENAME");
				TXT_CU_TITLEBEFORENAME.Text = conn.GetFieldValue("CU_TITLEBEFORENAME");
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
				DDL_CU_DOB_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("CU_DOB"));
				TXT_CU_DOB_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("CU_DOB"));
				try {DDL_CU_MARITAL.SelectedValue = conn.GetFieldValue("CU_MARITAL"); }
				catch {DDL_CU_MARITAL.SelectedValue = "";}
				try {DDL_CU_SEX.SelectedValue = conn.GetFieldValue("CU_SEX");} 
				catch {DDL_CU_SEX.SelectedValue = "";}
				TXT_CU_IDCARDNUM.Text = conn.GetFieldValue("CU_IDCARDNUM");
				TXT_CU_IDCARDEXP_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("CU_IDCARDEXP"));
				DDL_CU_IDCARDEXP_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("CU_IDCARDEXP"));
				TXT_CU_IDCARDEXP_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("CU_IDCARDEXP"));
				try {DDL_CU_JOBTITLE.SelectedValue = conn.GetFieldValue("CU_JOBTITLE");} 
				catch {DDL_CU_JOBTITLE.SelectedValue = "";}
				try {DDL_CU_BUSSTYPE.SelectedValue = conn.GetFieldValue("CU_BUSSTYPE");} 
				catch {DDL_CU_BUSSTYPE.SelectedValue = "";}
				TXT_CU_ESTABLISHDD.Text = tool.FormatDate_Day(conn.GetFieldValue("CU_ESTABLISHYY"));	
				try {DDL_CU_ESTABLISHMM.SelectedValue  = tool.FormatDate_Month(conn.GetFieldValue("CU_ESTABLISHYY"));}
				catch {DDL_CU_ESTABLISHMM.SelectedValue = "";}
				TXT_CU_ESTABLISHYY.Text = tool.FormatDate_Year(conn.GetFieldValue("CU_ESTABLISHYY"));	
				TXT_CU_NPWP.Text = conn.GetFieldValue("CU_NPWP");
				try {DDL_CU_CITIZENSHIP.SelectedValue = conn.GetFieldValue("CU_CITIZENSHIP");} 
				catch {DDL_CU_CITIZENSHIP.SelectedValue = "";}
				try {DDL_JNSALAMAT_P.SelectedValue = conn.GetFieldValue("CU_JNSALAMAT");} 
				catch {DDL_JNSALAMAT_P.SelectedValue = "";}
				TXT_CU_KTPADDR1.Text = conn.GetFieldValue("CU_KTPADDR1");
				TXT_CU_KTPADDR2.Text = conn.GetFieldValue("CU_KTPADDR2");
				TXT_CU_KTPADDR3.Text = conn.GetFieldValue("CU_KTPADDR3");
				LBL_CU_KTPCITY.Text = conn.GetFieldValue("CU_KTPCITY");
				TXT_CU_KTPCITY.Text = conn.GetFieldValue("KTPCITY");
				TXT_CU_KTPZIPCODE.Text = conn.GetFieldValue("CU_KTPZIPCODE");
				try {DDL_CU_EDUCATION.SelectedValue = conn.GetFieldValue("CU_EDUCATION");} 
				catch {DDL_CU_EDUCATION.SelectedValue = "";}
				TXT_CU_NETINCOMEMM.Text = conn.GetFieldValue("CU_NETINCOMEMM");				
				TXT_CU_CHILDREN.Text = conn.GetFieldValue("CU_CHILDREN");
				RDO_CU_PERNAHJDNASABAHBM.SelectedValue = (conn.GetFieldValue("CU_PERNAHJDNASABAHBM")==""?"0":conn.GetFieldValue("CU_PERNAHJDNASABAHBM"));
				try {DDL_CU_HOMESTA.SelectedValue = conn.GetFieldValue("CU_HOMESTA");} 
				catch {DDL_CU_HOMESTA.SelectedValue = "";}
				TXT_CU_MULAIMENETAPMM.Text = conn.GetFieldValue("CU_MULAIMENETAPMM");
				TXT_CU_MULAIMENETAPYY.Text = conn.GetFieldValue("CU_MULAIMENETAPYY");
				//--- start of Informasi Spouse ------------------
				TXT_CU_SPOUSE_FNAME.Text		= conn.GetFieldValue("CU_SPOUSE_FNAME");
				TXT_CU_SPOUSE_MNAME.Text		= conn.GetFieldValue("CU_SPOUSE_MNAME");
				TXT_CU_SPOUSE_LNAME.Text		= conn.GetFieldValue("CU_SPOUSE_LNAME");
				TXT_CU_SPOUSE_IDCARDNUM.Text	= conn.GetFieldValue("CU_SPOUSE_IDCARDNUM");
				TXT_CU_SPOUSE_KTPADDR1.Text		= conn.GetFieldValue("CU_SPOUSE_KTPADDR1");
				TXT_CU_SPOUSE_KTPADDR2.Text		= conn.GetFieldValue("CU_SPOUSE_KTPADDR2");
				TXT_CU_SPOUSE_KTPADDR3.Text		= conn.GetFieldValue("CU_SPOUSE_KTPADDR3");
				if (conn.GetFieldValue("CU_SPOUSE_KTPISSUEDATE")!=null && conn.GetFieldValue("CU_SPOUSE_KTPISSUEDATE")!="") GlobalTools.fromSQLDate(conn.GetFieldValue("CU_SPOUSE_KTPISSUEDATE"), TXT_CU_SPOUSE_KTPISSUEDATE_DAY, DDL_CU_SPOUSE_KTPISSUEDATE_MONTH, TXT_CU_SPOUSE_KTPISSUEDATE_YEAR);
				if (conn.GetFieldValue("CU_SPOUSE_KTPEXPDATE")!=null && conn.GetFieldValue("CU_SPOUSE_KTPEXPDATE")!="") GlobalTools.fromSQLDate(conn.GetFieldValue("CU_SPOUSE_KTPEXPDATE"), TXT_CU_SPOUSE_KTPEXPDATE_DAY, DDL_CU_SPOUSE_KTPEXPDATE_MONTH, TXT_CU_SPOUSE_KTPEXPDATE_YEAR);
				TXT_CU_NOKARTUKELUARGA.Text		= conn.GetFieldValue("CU_NOKARTUKELUARGA");
				//-------------- end of spouseinfo --------------
				TXT_CU_EMPLOYEE.Text = conn.GetFieldValue("CU_EMPLOYEE");
			}			
			else
			{
				TR_COMPANY.Visible = true;
				TR_PERSONAL.Visible = false;
				RDO_RFCUSTOMERTYPE.SelectedValue = "01";

				TXT_AP_GROSSSALES.Text = conn.GetFieldValue("AP_GROSSSALES");
				try 
				{
					DDL_AP_BOOKINGBRANCH.SelectedValue = conn.GetFieldValue("AP_BOOKINGBRANCH");
				} 
				catch {DDL_AP_BOOKINGBRANCH.SelectedValue = "";}

				try {DDL_AP_GRSALESCURR.SelectedValue = conn.GetFieldValue("AP_GROSSSALESCURR");} 
				catch { }
				
				conn.QueryString = "select seq, ag_officer from rfagencyuser where agencyid='" + DDL_AP_SALESAGENCY.SelectedValue + "' and active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_AP_SALESEXEC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					DDL_AP_SALESSUPERV.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}
				
				conn.QueryString = "select * from VW_CUST_COMPANY_HISTORY where AP_REGNO='" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
				
				TXT_CU_CIF_C.Text = conn.GetFieldValue("CU_CIF");
				TXT_BRANCH_CODE.Text = Session["BranchName"].ToString();
				try {DDL_CU_COMPTYPE.SelectedValue = conn.GetFieldValue("CU_COMPTYPE");} 
				catch {DDL_CU_COMPTYPE.SelectedValue = "";}
				try {DDL_CU_JNSNASABAH.SelectedValue = conn.GetFieldValue("CU_JNSNASABAH");} 
				catch {DDL_CU_JNSNASABAH.SelectedValue = "";}
				TXT_CU_COMPNAME.Text = conn.GetFieldValue("CU_COMPNAME");
				TXT_CU_COMPADDR1.Text = conn.GetFieldValue("CU_COMPADDR1");
				TXT_CU_COMPADDR2.Text = conn.GetFieldValue("CU_COMPADDR2");
				TXT_CU_COMPADDR3.Text = conn.GetFieldValue("CU_COMPADDR3");
				TXT_CU_COMPCITY.Text = conn.GetFieldValue("CITYNAME");
				LBL_CU_COMPCITY.Text = conn.GetFieldValue("CU_COMPCITY");
				TXT_CU_COMPZIPCODE.Text = conn.GetFieldValue("CU_COMPZIPCODE");
				try {DDL_CU_COMPBUSSTYPE.SelectedValue = conn.GetFieldValue("CU_COMPBUSSTYPE");} 
				catch {DDL_CU_COMPBUSSTYPE.SelectedValue = "";}
				TXT_CU_COMPESTABLISHYY.Text = tool.FormatDate_Year(conn.GetFieldValue("CU_COMPESTABLISH"));
				try {DDL_CU_COMPESTABLISHMM.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("CU_COMPESTABLISH"));}
				catch {DDL_CU_COMPESTABLISHMM.SelectedValue = "";}
				TXT_CU_COMPESTABLISHDD.Text = tool.FormatDate_Day(conn.GetFieldValue("CU_COMPESTABLISH"));
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
				catch {DDL_JNSALAMAT_C.SelectedValue = "";}
				TXT_CU_TDP.Text = conn.GetFieldValue("CU_TDP");
				TXT_CU_COMPAKTAPENDIRIAN.Text = conn.GetFieldValue("CU_COMPAKTAPENDIRIAN");
				RDO_CU_PERNAHJDNASABAHBM.SelectedValue = (conn.GetFieldValue("CU_PERNAHJDNASABAHBM")==""?"0":conn.GetFieldValue("CU_PERNAHJDNASABAHBM"));
				try { GlobalTools.fromSQLDate(conn.GetFieldValue("CU_INSURANCEDATE"), TXT_CU_COMPTGASURANSI_DAY, DDL_CU_TGASURANSI_MONTH, TXT_CU_COMPTGASURANSI_YEAR); }
				catch {}
				try {GlobalTools.fromSQLDate(conn.GetFieldValue("CU_TGLTERBIT"), TXT_CU_TGLTERBIT_DAY, DDL_CU_TGLTERBIT_MONTH, TXT_CU_TGLTERBIT_YEAR);}
				catch{}
				try {GlobalTools.fromSQLDate(conn.GetFieldValue("CU_TGLJATUHTEMPO"), TXT_CU_TGLJATUHTEMPO_DAY, DDL_CU_TGLJATUHTEMPO_MONTH, TXT_CU_TGLJATUHTEMPO_YEAR);}
				catch{}
				TXT_CU_COMPNOTARYNAME.Text	= conn.GetFieldValue("CU_COMPNOTARYNAME");
				TXT_CU_COMPANGGOTA.Text = conn.GetFieldValue("CU_COMPANGGOTA");
			}
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						if (conn.GetFieldValue(i,3).IndexOf("?de=") < 0 && conn.GetFieldValue(i,3).IndexOf("&de=") < 0) 
							strtemp = strtemp + "&de=" + Request.QueryString["de"];	
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"];
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void viewSubMenu() 
		{
			try 
			{
				conn.QueryString = "select * from SCREENSUBMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, "SM_MENUDISPLAY");
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, "SM_LINKNAME").Trim()!= "") 
					{						
						if (conn.GetFieldValue(i,"SM_LINKNAME").IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];

						if (conn.GetFieldValue(i,"SM_LINKNAME").IndexOf("?de=") < 0 && conn.GetFieldValue(i, "SM_LINKNAME").IndexOf("&de=") < 0) 
							strtemp = strtemp + "&de=" + Request.QueryString["de"];	

						if (conn.GetFieldValue(i,"SM_LINKNAME").IndexOf("?par=") < 0 && conn.GetFieldValue(i, "SM_LINKNAME").IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"];
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, "SM_LINKNAME")+strtemp;					
					PH_SUBMENU.Controls.Add(t);
					PH_SUBMENU.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}
		private void ViewDataVisited()
		{
			try 
			{
				conn.QueryString = "select * from APPLICATION where AP_REGNO = '" + TXT_AP_REGNO.Text + "'";
				conn.ExecuteQuery();

				/// Program
				/// 
				try 
				{
					DDL_PROG_CODE.SelectedValue = conn.GetFieldValue("PROG_CODE");
				} 
				catch {DDL_PROG_CODE.SelectedValue = "";}
				DDL_PROG_CODE.Enabled = false;


				/// Source COde
				/// 
				try 
				{
					DDL_AP_SRCCODE.SelectedValue = conn.GetFieldValue("AP_SRCCODE");
				} 
				catch {DDL_AP_SRCCODE.SelectedValue = "";}
				DDL_AP_SRCCODE.Enabled = false;


				/// Booking Branch
				/// 
				try 
				{
					DDL_AP_BOOKINGBRANCH.SelectedValue = conn.GetFieldValue("AP_BOOKINGBRANCH");
				} 
				catch {DDL_AP_BOOKINGBRANCH.SelectedValue = "";}
				DDL_AP_BOOKINGBRANCH.Enabled = false;


				/// Businessunit
				/// 
				try 
				{
					DDL_AP_BUSINESSUNIT.SelectedValue = conn.GetFieldValue("AP_BUSINESSUNIT");
				}
				catch {DDL_AP_BUSINESSUNIT.SelectedValue = "";}
				DDL_AP_BUSINESSUNIT.Enabled = false;


				/// Application Sign Date
				/// 
				DateTime dt = Convert.ToDateTime(conn.GetFieldValue("AP_SIGNDATE"));
				GlobalTools.fillDateForm(TXT_AP_SIGNDATE_DAY, DDL_AP_SIGNDATE_MONTH, TXT_AP_SIGNDATE_YEAR, dt);
				TXT_AP_SIGNDATE_DAY.ReadOnly = true;
				DDL_AP_SIGNDATE_MONTH.Enabled = false;
				TXT_AP_SIGNDATE_YEAR.ReadOnly = true;

				
				/// Application Receieve date
				/// 
				dt = Convert.ToDateTime(conn.GetFieldValue("AP_RECVDATE"));
				TXT_AP_RECVDATE.Text = dt.ToString("dd MMM yyyy");



				RDO_RFCUSTOMERTYPE.Enabled = false;

				/// Channels
				/// 
				try 
				{
					DDL_CHANNEL_CODE.SelectedValue = conn.GetFieldValue("CHANNEL_CODE");
				} 
				catch {DDL_CHANNEL_CODE.SelectedValue = "";}


				/// BI Checking status
				/// 
				try 
				{
					RDO_BI_CHECKING.SelectedValue = conn.GetFieldValue("AP_CHECKBI");
				} 
				catch {RDO_BI_CHECKING.SelectedValue = "0";}
				if (RDO_BI_CHECKING.SelectedValue == "0") 
				{
					LBL_CO.Visible = false;
					DDL_GRPUNIT.Visible = false;
				}
				else 
				{
					//TODO : Isi picklist sesuai dengan save awal
				}
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return;
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

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink("", Request.QueryString["mc"], conn));
		}
	}
}
