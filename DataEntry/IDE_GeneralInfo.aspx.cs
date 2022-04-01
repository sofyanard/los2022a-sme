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
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for IDE_GeneralInfo.
	/// </summary>
	public partial class IDE_GeneralInfo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected System.Web.UI.WebControls.TextBox Textbox1;

		#region " My Variables "
		private string mainregno, maincuref, regno, curef, userID, tc, mc, exist, gi, mainprod_seq, mainproductid;
		private Connection conn;
		private Tools tool = new Tools();

		#endregion
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn			= (Connection) Session["Connection"];
			mainregno		= Request.QueryString["mainregno"];
			mainprod_seq	= Request.QueryString["mainprod_seq"];
			mainproductid	= Request.QueryString["mainproductid"];
			maincuref		= Request.QueryString["maincuref"];
			regno			= Request.QueryString["regno"];
			curef			= Request.QueryString["curef"];
			tc				= Request.QueryString["tc"];
			mc				= Request.QueryString["mc"];
			exist			= Request.QueryString["exist"];
			gi				= Request.QueryString["gi"];
			userID			= Request.QueryString["rm"];

			//userID			= (string) Session["UserID"];

			TXT_AP_REGNO.Text		= Request.QueryString["regno"];
			TXT_CU_REF.Text			= Request.QueryString["curef"];
			LBL_AP_RELMNGR.Text		= Request.QueryString["rm"];
			//LBL_AP_RELMNGR.Text		= Session["UserID"].ToString();
			TXT_AP_RECVDATE.Text	= tool.FormatDate(DateTime.Now.ToString());
			TXT_BRANCH_CODE.Text	= Session["BranchName"].ToString();
			TXT_AREAID.Text			= Session["AreaName"].ToString();

			TXT_AP_SIGNDATE_DAY.Text			= DateTime.Today.Day.ToString();
			DDL_AP_SIGNDATE_MONTH.SelectedValue = DateTime.Today.Month.ToString();
			TXT_AP_SIGNDATE_YEAR.Text			= DateTime.Today.Year.ToString();

			if (!IsPostBack)
			{
				CheckBusinessUnit();
				
				GlobalTools.fillRefList(DDL_AP_GRSALESCURR, "select currencyid, currencyid from rfcurrency where active = '1'", false, conn);
				GlobalTools.initDateForm(TXT_AP_SIGNDATE_DAY, DDL_AP_SIGNDATE_MONTH, TXT_AP_SIGNDATE_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_IDCARDEXP_DAY, DDL_CU_IDCARDEXP_MONTH, TXT_CU_IDCARDEXP_YEAR, true);
				GlobalTools.fillRefList(DDL_CU_BUSSTYPE, "select BUSSTYPEID, BUSSTYPEDESC from RFBUSINESSTYPE where ACTIVE='1' AND LEN(BUSSTYPEID) < 3 order by BUSSTYPEID", true, conn);
				GlobalTools.fillRefList(DDL_CU_COMPBUSSTYPE, "select BUSSTYPEID, BUSSTYPEDESC from RFBUSINESSTYPE where ACTIVE='1' AND LEN(BUSSTYPEID) < 3 order by BUSSTYPEID", true, conn);				
				GlobalTools.initDateForm(TXT_CU_DOB_DAY, DDL_CU_DOB_MONTH, TXT_CU_DOB_YEAR, true);
				GlobalTools.fillRefList(DDL_CHANNEL_CODE, "select channel_code, channel_desc from rfchannels where active='1'", false, conn);
				GlobalTools.fillRefList(DDL_CU_COMPTYPE, "select comptypeid, comptypedesc from rfcomptype where active='1'", false, conn);
				GlobalTools.fillRefList(DDL_CU_JOBTITLE, "select jobtitleid, jobtitledesc from rfjobtitle where active='1'", false, conn);
				GlobalTools.fillRefList(DDL_CU_MARITAL, "select maritalid, maritaldesc from rfmarital where active='1'", false, conn);
				//GlobalTools.fillRefList(DDL_PROG_CODE, "select * from rfprogram where areaid='" + Session["AreaID"].ToString() + "' and active='1' and businessunit='" + DDL_AP_BUSINESSUNIT.SelectedValue + "'", false, conn);
				GlobalTools.fillRefList(DDL_PROG_CODE, "select * from VW_DE_PROGRAMSUBAPP where areaid='" + Session["AreaID"].ToString() + "' and active='1' and businessunit='" + DDL_AP_BUSINESSUNIT.SelectedValue + "'", false, conn);
				GlobalTools.fillRefList(DDL_AP_SALESAGENCY, "select agencyid, agencyname from vw_rfagency where areaid='" + Session["AreaID"].ToString() + "' and agencytypeid='02' and active='1'", false, conn);
				//GlobalTools.fillRefList(DDL_AP_SALESEXEC, "", false, conn);
				//GlobalTools.fillRefList(DDL_AP_SALESSUPERV, "", false, conn);
				GlobalTools.fillRefList(DDL_CU_SEX, "select sexid, sexdesc from rfsex where active='1'", false, conn);
				GlobalTools.fillRefList(DDL_JNSALAMAT_C, "select ALAMATID, ALAMATDESC from RFJENISALAMAT where ACTIVE='1' order by ALAMATID", true, conn);
				GlobalTools.fillRefList(DDL_JNSALAMAT_P, "select ALAMATID, ALAMATDESC from RFJENISALAMAT where ACTIVE='1' order by ALAMATID", true, conn);
				GlobalTools.fillRefList(DDL_CU_JNSNASABAH, "select NASABAHID, NASABAHDESC from RFJENISNASABAH where ACTIVE='1'", true, conn);
				GlobalTools.fillRefList(DDL_CU_JNSNASABAH_P, "select NASABAHID, NASABAHDESC from RFJENISNASABAH where NASABAHID = 'A'", true, conn);
				GlobalTools.fillRefList(DDL_CU_EDUCATION, "select educationid, educationdesc from rfeducation where active='1'", false, conn);
				GlobalTools.fillRefList(DDL_AP_BOOKINGBRANCH, "select branch_code, branch_name from rfbranch where active='1' order by branch_code", true, conn);
				GlobalTools.fillRefList(DDL_AP_SRCCODE, "select sourcecode, sourcedesc from rfsourcecode where active='1'", false, conn);
				GlobalTools.fillRefList(DDL_CU_HOMESTA, "select * from RFHOMESTA where ACTIVE='1'", true, conn);
				GlobalTools.fillRefList(DDL_CU_CITIZENSHIP, "select citizenid, citizendesc from rfcitizenship where active='1'", false, conn);
				

				GlobalTools.initDateForm(TXT_CU_SPOUSE_KTPISSUEDATE_DAY, DDL_CU_SPOUSE_KTPISSUEDATE_MONTH, TXT_CU_SPOUSE_KTPISSUEDATE_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_SPOUSE_KTPEXPDATE_DAY, DDL_CU_SPOUSE_KTPEXPDATE_MONTH, TXT_CU_SPOUSE_KTPEXPDATE_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_COMPTGASURANSI_DAY, DDL_CU_TGASURANSI_MONTH, TXT_CU_COMPTGASURANSI_YEAR);
				GlobalTools.initDateForm(TXT_CU_TGLJATUHTEMPO_DAY, DDL_CU_TGLJATUHTEMPO_MONTH, TXT_CU_TGLJATUHTEMPO_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_TGLTERBIT_DAY, DDL_CU_TGLTERBIT_MONTH, TXT_CU_TGLTERBIT_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_COMPESTABLISHDD, DDL_CU_COMPESTABLISHMM, TXT_CU_COMPESTABLISHYY, true);
				GlobalTools.initDateForm(TXT_CU_ESTABLISHDD, DDL_CU_ESTABLISHMM, TXT_CU_ESTABLISHYY, true);


				///////////////////////////////////////
				///	mengambil nama RM
				///	
				conn.QueryString = "select SU_FULLNAME from SCUSER where USERID = '" + LBL_AP_RELMNGR.Text + "'";
				conn.ExecuteQuery();
				TXT_AP_RELMNGR.Text = conn.GetFieldValue("SU_FULLNAME");



				conn.QueryString = "select custtypeid, custtypedesc from rfcustomertype where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					RDO_RFCUSTOMERTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				RDO_RFCUSTOMERTYPE.SelectedIndex = 0;

				try { DDL_AP_GRSALESCURR.SelectedValue = "IDR"; } catch { }

				TR_PERSONAL.Visible		= false;	
				TR_COMPANY.Visible		= true;
				BTN_SAVECON.Visible		= false;

				if (Request.QueryString["exist"] == "1") {
					//--- if existing customer, user tidak bisa ganti tipe customer
					RDO_RFCUSTOMERTYPE.Enabled = false;
				}

				ViewData();

				if (DDL_AP_BUSINESSUNIT.Items.Count == 0)
					Response.Write("<script language='javascript'>alert('User Does not have upliner! Cannot proceed!');</script>");

				SetMandatory(RDO_RFCUSTOMERTYPE.SelectedValue);
			}

			//--- Kalau screen ini sudah dikunjungi, maka disable beberapa field
			if (Request.QueryString["gi"]=="0") ViewDataVisited();

			TXT_AP_GROSSSALES.Text = tool.MoneyFormat(TXT_AP_GROSSSALES.Text);
			if (RDO_RFCUSTOMERTYPE.SelectedValue != "01")  {
				TXT_CU_NETINCOMEMM.Text = tool.MoneyFormat(TXT_CU_NETINCOMEMM.Text);
			}

			secureData();

			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			BTN_SAVECON.Attributes.Add("onclick","if(!cek_mandatory2(document.Form1)){return false;};"); 
		}

		private void secureData() 
		{
			if (Request.QueryString["de"] != "1") 
			{
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for (int i = 0; i < coll[3].Controls.Count; i++) 
				{
					if (coll[3].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[3].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[3].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[3].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[3].Controls[i] is Button)
					{
						Button btn = (Button) coll[3].Controls[i];
						btn.Visible = false;
					}
				}
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
			// If Company
			conn.QueryString = "select top 1 * from vw_ide_geninfo where cu_ref='" + Request.QueryString["curef"] + "' order by ap_recvdate desc";
			conn.ExecuteQuery();
			
			string salesExec = conn.GetFieldValue("AP_SALESEXEC"), salesSuperv = conn.GetFieldValue("AP_SALESSUPERV");

			if (conn.GetFieldValue("CU_CUSTTYPEID") == "02")
			{
				TR_COMPANY.Visible = false;
				TR_PERSONAL.Visible = true;
				RDO_RFCUSTOMERTYPE.SelectedValue = "02";
				
				TXT_AP_GROSSSALES.Text = conn.GetFieldValue("AP_GROSSSALES");
				DDL_AP_BOOKINGBRANCH.SelectedValue = conn.GetFieldValue("AP_BOOKINGBRANCH");

				conn.QueryString = "select seq, ag_officer from rfagencyuser where agencyid='" + DDL_AP_SALESAGENCY.SelectedValue + "' and active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_AP_SALESEXEC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					DDL_AP_SALESSUPERV.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}
				
				conn.QueryString = "select * from vw_cust_personal where cu_ref='" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();

				TXT_CU_CIF_P.Text = conn.GetFieldValue("CU_CIF");
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
				try {DDL_CU_ESTABLISHMM.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("CU_ESTABLISHYY"));}
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
				try {DDL_AP_GRSALESCURR.SelectedValue = conn.GetFieldValue("AP_GROSSSALESCURR");} 
				catch { }
				TXT_CU_EMPLOYEE.Text = conn.GetFieldValue("CU_EMPLOYEE");
			}
			
			else
			{
				TR_COMPANY.Visible = true;
				TR_PERSONAL.Visible = false;
				RDO_RFCUSTOMERTYPE.SelectedValue = "01";

				TXT_AP_GROSSSALES.Text = conn.GetFieldValue("AP_GROSSSALES");
				DDL_AP_BOOKINGBRANCH.SelectedValue = conn.GetFieldValue("AP_BOOKINGBRANCH");
				
				conn.QueryString = "select seq, ag_officer from rfagencyuser where agencyid='" + DDL_AP_SALESAGENCY.SelectedValue + "' and active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_AP_SALESEXEC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					DDL_AP_SALESSUPERV.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}
				
				conn.QueryString = "select * from vw_cust_company where cu_ref='" + Request.QueryString["curef"] + "'";
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
				TXT_CU_COMPNOTARYNAME.Text = conn.GetFieldValue("CU_COMPNOTARYNAME");
				try {DDL_AP_GRSALESCURR.SelectedValue = conn.GetFieldValue("AP_GROSSSALESCURR");} 
				catch { }

			}
		}

		private void ViewDataVisited()
		{
			try 
			{
				conn.QueryString = "select * from APPLICATION where AP_REGNO = '" + mainregno + "'";
				conn.ExecuteQuery();

				DDL_AP_BUSINESSUNIT.SelectedValue = conn.GetFieldValue("AP_BUSINESSUNIT");
				DDL_AP_BUSINESSUNIT.Enabled = false;

				//--- field yang bisa diubah lagi
				DateTime dt = Convert.ToDateTime(conn.GetFieldValue("AP_SIGNDATE"));
				GlobalTools.fillDateForm(TXT_AP_SIGNDATE_DAY, DDL_AP_SIGNDATE_MONTH, TXT_AP_SIGNDATE_YEAR, dt);

				try {DDL_PROG_CODE.SelectedValue = conn.GetFieldValue("PROG_CODE");}
				catch {DDL_PROG_CODE.SelectedValue = "";}

				DDL_AP_SRCCODE.SelectedValue = conn.GetFieldValue("AP_SRCCODE");		
				DDL_AP_BOOKINGBRANCH.SelectedValue = conn.GetFieldValue("AP_BOOKINGBRANCH");		
				DDL_CHANNEL_CODE.SelectedValue = conn.GetFieldValue("CHANNEL_CODE");
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return;
			}
		}

		private void SetMandatory(string custType)
		{
			if (custType == "01")
			{
				BTN_SAVE.Visible				= true;
				BTN_SAVECON.Visible				= false;
				TR_COMPANY.Visible				= true;
				TR_PERSONAL.Visible				= false;
				TXT_AREAID.CssClass				= "mandatory";
				TXT_BRANCH_CODE.CssClass		= "mandatory";
				DDL_PROG_CODE.CssClass			= "mandatory";
				DDL_AP_SRCCODE.CssClass			= "mandatory";
				TXT_AP_GROSSSALES.CssClass		= "mandatory";
				DDL_AP_BOOKINGBRANCH.CssClass	= "mandatory";
				TXT_AP_SIGNDATE_DAY.CssClass	= "mandatory";
				DDL_AP_SIGNDATE_MONTH.CssClass	= "mandatory";
				TXT_AP_SIGNDATE_YEAR.CssClass	= "mandatory";
				DDL_AP_BUSINESSUNIT.CssClass	= "mandatory";
				DDL_AP_GRSALESCURR.CssClass		= "mandatory";
			}
			else
			{
				BTN_SAVECON.Visible				= true;
				BTN_SAVE.Visible				= false;
				TR_COMPANY.Visible				= false;
				TR_PERSONAL.Visible				= true;
				TXT_AREAID.CssClass				= "mandatory2";
				TXT_BRANCH_CODE.CssClass		= "mandatory2";
				DDL_PROG_CODE.CssClass			= "mandatory2";
				DDL_AP_SRCCODE.CssClass			= "mandatory2";
				TXT_AP_GROSSSALES.CssClass		= "mandatory2";
				DDL_AP_BOOKINGBRANCH.CssClass	= "mandatory2";
				TXT_AP_SIGNDATE_DAY.CssClass	= "mandatory2";
				DDL_AP_SIGNDATE_MONTH.CssClass	= "mandatory2";
				TXT_AP_SIGNDATE_YEAR.CssClass	= "mandatory2";
				DDL_AP_BUSINESSUNIT.CssClass	= "mandatory2";
				DDL_AP_GRSALESCURR.CssClass		= "mandatory2";
			}
		}


		private void CheckBusinessUnit()
		{
			conn.QueryString = "select su_upliner, su_midupliner, su_corupliner, su_crgupliner, su_mcrupliner from scuser where userid='" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			string upliner = conn.GetFieldValue(0,0);
			string midupliner = conn.GetFieldValue(0,1);
			string corupliner = conn.GetFieldValue(0, "SU_CORUPLINER");
			string crgupliner = conn.GetFieldValue(0, "SU_CRGUPLINER");
			string mcrupliner = conn.GetFieldValue(0, "SU_MCRUPLINER");

			if (upliner != "")	DDL_AP_BUSINESSUNIT.Items.Add(new ListItem("Small Business Group", "SM100"));
			if (midupliner != "") DDL_AP_BUSINESSUNIT.Items.Add(new ListItem("Middle Business Group", "MD100"));
			if (corupliner != "") DDL_AP_BUSINESSUNIT.Items.Add(new ListItem("Corporate", "CB100"));
			if (crgupliner != "") DDL_AP_BUSINESSUNIT.Items.Add(new ListItem("Credit Recovery", "CR100"));
			if (mcrupliner != "") DDL_AP_BUSINESSUNIT.Items.Add(new ListItem("Micro Banking", "MB100"));
		}

		protected void BTN_SEARCHPERSONAL_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_ZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");		
		}

		protected void BTN_SEARCHKTPZIP_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_KTPZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");		
		}

		protected void BTN_SEARCHCOMP_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_COMPZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");		
		}

		protected void RDO_RFCUSTOMERTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetMandatory(RDO_RFCUSTOMERTYPE.SelectedValue);
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{			
			Int64 signDate = Int64.Parse(Tools.toISODate(TXT_AP_SIGNDATE_DAY, DDL_AP_SIGNDATE_MONTH, TXT_AP_SIGNDATE_YEAR)),
				now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())),
				compEstablish, personalEstablish;

			/* Check Existing Customer or Not */
			if (Request.QueryString["exist"] == "0")
			{
				if (RDO_RFCUSTOMERTYPE.SelectedValue == "01")
				{
					//conn.QueryString = "select count (*) from customer where cu_npwp = '" + TXT_CU_COMPNPWP.Text + "'";

					conn.QueryString = "select count (*) from customer " + 
						"left join cust_company on customer.cu_ref = cust_company.cu_ref " + 
						"where cu_npwp = '" + TXT_CU_COMPNPWP.Text + 
							"' and customer.CU_REF <> '" + TXT_CU_REF.Text + 
							"' and cu_compname like '%" + TXT_CU_COMPNAME.Text.Trim() + "%'";
					conn.ExecuteQuery();
					if (conn.GetFieldValue(0,0) != "0")
					{
						Response.Write("<script language='javascript'>alert('Customer with NPWP: " + TXT_CU_COMPNPWP.Text + " exists in the system!');</script>");
						return;
					}
				}
				else
				{
					//--- modif by Yudi (2004/09/17) ---
					string TGL_KTP = GlobalTools.ToSQLDate(TXT_CU_IDCARDEXP_DAY.Text.Trim(), DDL_CU_IDCARDEXP_MONTH.SelectedValue, TXT_CU_IDCARDEXP_YEAR.Text.Trim());
					conn.QueryString = "select count (*) from cust_personal where CU_IDCARDNUM='" + TXT_CU_IDCARDNUM.Text + "' and CU_IDCARDEXP = " + TGL_KTP + "";
					//----------------------------------
					conn.ExecuteQuery();
					if (conn.GetFieldValue(0,0) != "0")
					{
						Response.Write("<script language='javascript'>alert('Customer with KTP: " + TXT_CU_IDCARDNUM.Text + " and Expire Date: " + TGL_KTP.Replace("'","") + " exists in the system!');</script>");
						return;
					}
				}
			}
			
			//--- START VALIDATION ---
			if (signDate > now)
			{
				GlobalTools.popMessage(this, "Sign Date cannot be greater than current date!");
				return;
			}
			
			if (RDO_RFCUSTOMERTYPE.SelectedValue == "01")
			{
//				if (int.Parse(TXT_CU_COMPESTABLISHMM.Text) > 12)
//				{
//					GlobalTools.popMessage(this, "Berdiri Sejak (MM) tidak valid");
//					return;
//				}

				try 
				{
					compEstablish = Int64.Parse(Tools.toISODate(TXT_CU_COMPESTABLISHDD.Text, DDL_CU_COMPESTABLISHMM.SelectedValue, TXT_CU_COMPESTABLISHYY.Text));
				} 
				catch 
				{
					GlobalTools.popMessage(this, "Berdiri Sejak tidak valid!");
					return;
				}

				if (compEstablish > now)
				{
					GlobalTools.popMessage(this, "Berdiri Sejak cannot be greater than current date!");
					return;
				}
				try 
				{
					conn.QueryString = "exec IDE_sub_GENINFO_COMP_INSERT '" + 
						Request.QueryString["regno"] + "', '" + 
						TXT_CU_REF.Text + "', '" +
						Session["AreaID"].ToString() + "', '" +
						DDL_PROG_CODE.SelectedValue + "', '" +
						Session["BranchID"].ToString() + "', '" + 
						LBL_AP_RELMNGR.Text + "', " + 
						tool.ConvertNull(DDL_CHANNEL_CODE.SelectedValue) + ", '" + 
						//TXT_AP_SRCCODE.Text + "', " + 
						DDL_AP_SRCCODE.SelectedValue + "', " + 
						tool.ConvertFloat(TXT_AP_GROSSSALES.Text) + ", " + 
						tool.ConvertDate(TXT_AP_SIGNDATE_DAY.Text, DDL_AP_SIGNDATE_MONTH.SelectedValue, TXT_AP_SIGNDATE_YEAR.Text) + ", " +
						tool.ConvertNull(DDL_AP_SALESAGENCY.SelectedValue) + ", " + 
						tool.ConvertNull(DDL_AP_SALESSUPERV.SelectedValue) + ", " + 
						tool.ConvertNull(DDL_AP_SALESEXEC.SelectedValue) + ", '" +					
						LBL_AP_RELMNGR.Text + "', '" + 
						//Session["UserID"].ToString() + "', '" + 
						RDO_RFCUSTOMERTYPE.SelectedValue + "', '" +
						TXT_CU_CIF_C.Text + "', '" + DDL_CU_COMPTYPE.SelectedValue + "', '" +
						TXT_CU_COMPNAME.Text + "', '" + 
						TXT_CU_COMPADDR1.Text + "', '" + TXT_CU_COMPADDR2.Text + "', '" + TXT_CU_COMPADDR3.Text + "', '" + 
						LBL_CU_COMPCITY.Text + "', '" + TXT_CU_COMPZIPCODE.Text + "', '" +
						DDL_CU_COMPBUSSTYPE.SelectedValue + "', " + 
						tool.ConvertDate(TXT_CU_COMPESTABLISHDD.Text, DDL_CU_COMPESTABLISHMM.SelectedValue, TXT_CU_COMPESTABLISHYY.Text) + ", '" +
						TXT_CU_COMPPHNAREA.Text + "', '" + TXT_CU_COMPPHNNUM.Text + "', '" + 
						TXT_CU_COMPPHNEXT.Text + "', '" +
						TXT_CU_COMPFAXAREA.Text + "', '" + TXT_CU_COMPFAXNUM.Text + "', '" + 
						TXT_CU_COMPFAXEXT.Text + "', '" + 
						TXT_CU_COMPNPWP.Text + "', '" + TXT_CU_CONTACTPERSON.Text + "', '" +
						TXT_CU_CONTACTPHNAREA.Text + "', '" + TXT_CU_CONTACTPHNNUM.Text + "', '" + 
						TXT_CU_CONTACTPHNEXT.Text + "', null, '0', " + 
						tool.ConvertNull(TXT_CU_COMPEMPLOYEE.Text) + ", " + 
						tool.ConvertNull(DDL_JNSALAMAT_C.SelectedValue) + ", '" + 
						TXT_CU_TDP.Text + "', "
						+ tool.ConvertNull(DDL_CU_JNSNASABAH.SelectedValue) + ", '" + 
						DDL_AP_BUSINESSUNIT.SelectedValue + "', '" + 
						DDL_AP_BOOKINGBRANCH.SelectedValue + "', '" + 
						mainregno + "', '" + 
						RDO_CU_PERNAHJDNASABAHBM.SelectedValue + "', " + 
						tool.ConvertNull(TXT_CU_COMPAKTAPENDIRIAN.Text.Trim()) + ", null, '" + 
						DDL_AP_GRSALESCURR.SelectedValue + "'";
					conn.ExecuteNonQuery();

					//--- untuk memecah kebanyakan argumen
					conn.QueryString = "exec IDE_GENINFO_COMP_INSERT2 '" + 
						curef + "', " + 
						tool.ConvertDate(TXT_CU_COMPTGASURANSI_DAY.Text, DDL_CU_TGASURANSI_MONTH.SelectedValue, TXT_CU_COMPTGASURANSI_YEAR.Text) + ", " + // tanggal issuance
						tool.ConvertDate(TXT_CU_TGLJATUHTEMPO_DAY.Text, DDL_CU_TGLJATUHTEMPO_MONTH.SelectedValue, TXT_CU_TGLJATUHTEMPO_YEAR.Text) + ", " + // tanggal jatuh tempo
						tool.ConvertDate(TXT_CU_TGLTERBIT_DAY.Text, DDL_CU_TGLTERBIT_MONTH.SelectedValue, TXT_CU_TGLJATUHTEMPO_YEAR.Text) + ", " + // tgl penerbitan
						tool.ConvertNull(TXT_CU_COMPNOTARYNAME.Text.Trim()) + ", " +	// nama notaris
						tool.ConvertNull(TXT_CU_COMPANGGOTA.Text.Trim());
					conn.ExecuteNonQuery();
				} 
				catch (NullReferenceException)
				{
					GlobalTools.popMessage(this, "Connection Error!");
					return;
				}
			}
				
			else
			{
//				if (int.Parse(TXT_CU_ESTABLISHMM.Text) > 12)
//				{
//					GlobalTools.popMessage(this, "Berdiri Sejak (MM) tidak valid");
//					return;
//				}
				try 
				{
					personalEstablish = Int64.Parse(Tools.toISODate(TXT_CU_ESTABLISHDD.Text, DDL_CU_ESTABLISHMM.SelectedValue, TXT_CU_ESTABLISHYY.Text));
				}
				catch 
				{
					GlobalTools.popMessage(this, "Berdiri Sejak tidak valid!");
					return;
				}
				if (personalEstablish > now)
				{
					GlobalTools.popMessage(this, "Berdiri Sejak cannot be greater than current date!");
					return;
				}
				try 
				{
					conn.QueryString = "exec IDE_sub_GENINFO_PERSON_INSERT '" + 
						Request.QueryString["regno"] + "', '" + 
						TXT_CU_REF.Text + "', '" + 
						Session["AreaID"].ToString() + "', '" +
						DDL_PROG_CODE.SelectedValue + "', '" +
						Session["BranchID"].ToString() + "', '" + 
						LBL_AP_RELMNGR.Text + "', " + 
						tool.ConvertNull(DDL_CHANNEL_CODE.SelectedValue) + ", '" + 
						DDL_AP_SRCCODE.SelectedValue + "', " +
						tool.ConvertFloat(TXT_AP_GROSSSALES.Text) + ", " +
						tool.ConvertDate(TXT_AP_SIGNDATE_DAY.Text, DDL_AP_SIGNDATE_MONTH.SelectedValue, TXT_AP_SIGNDATE_YEAR.Text) + ", " +
						tool.ConvertNull(DDL_AP_SALESAGENCY.SelectedValue) + ", " + 
						tool.ConvertNull(DDL_AP_SALESSUPERV.SelectedValue) + ", " + 
						tool.ConvertNull(DDL_AP_SALESEXEC.SelectedValue) + ", '" +					
						LBL_AP_RELMNGR.Text + "', '" +
						//Session["UserID"] + "', '" + 
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
						tool.ConvertDate(TXT_CU_ESTABLISHDD.Text , DDL_CU_ESTABLISHMM.SelectedValue , TXT_CU_ESTABLISHYY.Text) + ", '" + TXT_CU_NPWP.Text + "', '" + 
						DDL_CU_CITIZENSHIP.SelectedValue + "', null, '0', " + 
						tool.ConvertNull(DDL_JNSALAMAT_P.SelectedValue) + ", '" + 
						TXT_CU_KTPADDR1.Text + "', '" + 
						TXT_CU_KTPADDR2.Text + "', '" + 
						TXT_CU_KTPADDR3.Text + "', '" + 
						LBL_CU_KTPCITY.Text + "', '" + 
						TXT_CU_KTPZIPCODE.Text + "', " + 
						tool.ConvertNull(DDL_CU_EDUCATION.SelectedValue) + ", " +
						tool.ConvertFloat(TXT_CU_NETINCOMEMM.Text) + ", " + 
						tool.ConvertNull(TXT_CU_CHILDREN.Text) + ", '" + 
						DDL_AP_BUSINESSUNIT.SelectedValue + "', '" + 
						DDL_AP_BOOKINGBRANCH.SelectedValue + "', " + 
						tool.ConvertNull(DDL_CU_JNSNASABAH_P.SelectedValue) + ",'" + 
						mainregno + "', '" + 
						RDO_CU_PERNAHJDNASABAHBM.SelectedValue + "', null, '" + 
						DDL_AP_GRSALESCURR.SelectedValue + "'";
					conn.ExecuteNonQuery();

					//--- untuk memecah kebanyak argumen
					conn.QueryString = "exec IDE_GENINFO_PERSON_INSERT2 '" + TXT_CU_REF.Text + "', " + 
						tool.ConvertNull(DDL_CU_HOMESTA.SelectedValue) + ", " + 
						tool.ConvertNull(TXT_CU_MULAIMENETAPMM.Text) + ", " + 
						tool.ConvertNull(TXT_CU_MULAIMENETAPYY.Text) + ", " +
						tool.ConvertNull(TXT_CU_EMPLOYEE.Text.Trim());
					conn.ExecuteNonQuery();

					//--- untuk menyimpan informasi spouse/pasangan
					conn.QueryString = "exec IDE_GENINFO_PERSON_INSERT3 '" + TXT_CU_REF.Text + "', " + 
						tool.ConvertNull(TXT_CU_SPOUSE_FNAME.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_SPOUSE_MNAME.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_SPOUSE_LNAME.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_SPOUSE_IDCARDNUM.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_SPOUSE_KTPADDR1.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_SPOUSE_KTPADDR2.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_SPOUSE_KTPADDR3.Text.Trim()) + ", " + 												
						tool.ConvertDate(TXT_CU_SPOUSE_KTPISSUEDATE_DAY.Text.Trim(), DDL_CU_SPOUSE_KTPISSUEDATE_MONTH.SelectedValue, TXT_CU_SPOUSE_KTPISSUEDATE_YEAR.Text.Trim()) + ", " + 
						tool.ConvertDate(TXT_CU_SPOUSE_KTPEXPDATE_DAY.Text.Trim(), DDL_CU_SPOUSE_KTPEXPDATE_MONTH.SelectedValue, TXT_CU_SPOUSE_KTPEXPDATE_YEAR.Text.Trim()) + " , " + 
						tool.ConvertNull(TXT_CU_NOKARTUKELUARGA.Text.Trim()) + "";
					conn.ExecuteNonQuery();
				} 
				catch (NullReferenceException) 
				{
					GlobalTools.popMessage(this, "Connection Error!");
					return;
				}
			}
			Response.Redirect("IDE_InfoPerusahaan.aspx?" + 
				"mainregno=" + mainregno +
				"&mainprod_seq=" + mainprod_seq +
				"&mainproductid=" + mainproductid +
				"&regno=" + regno + 
				"&curef=" + curef + 
				"&prog=" + DDL_PROG_CODE.SelectedValue + 
				"&tc=" + tc + 
				"&mc=" + mc + 
				"&exist=" + exist);
		}

		protected void BTN_SAVECON_Click(object sender, System.EventArgs e)
		{
			BTN_SAVE_Click(sender, e);
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
				TXT_CU_CITY.Text = "";
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
				TXT_CU_KTPCITY.Text = "";
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
				TXT_CU_COMPCITY.Text = "";
				Response.Write("<script language='javascript'>alert('Invalid Zipcode!');</script>");
			}
		}
	}
}
