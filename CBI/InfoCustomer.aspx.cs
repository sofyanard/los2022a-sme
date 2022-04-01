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
using Microsoft.VisualBasic;

namespace SME.InitialDataEntry
{
	/// <summary>
	/// Summary description for InfoCustomer.
	/// </summary>
	public partial class CBIInsert : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			string a = Request.QueryString["mc"];
			string b = Session["GroupID"].ToString();
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				DDL_CU_BUSSTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_COMPBUSSTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_DOB_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_IDCARDEXP_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_COMPTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_JOBTITLE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_MARITAL.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_SEX.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_CITIZENSHIP.Items.Add(new ListItem("- PILIH -", ""));

				for (int i = 1; i <= 12; i++)
				{
					DDL_CU_DOB_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CU_IDCARDEXP_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					//DDL_ISSUANCEDATE.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
				
				GlobalTools.initDateForm(TXT_CU_ISSUANCEDATE_DAY,DDL_CU_ISSUANCEDATE_MONTH,TXT_CU_ISSUANCEDATE_YEAR);
				GlobalTools.initDateForm(TXT_CU_SPOUSE_KTPISSUEDATE_DAY, DDL_CU_SPOUSE_KTPISSUEDATE_MONTH, TXT_CU_SPOUSE_KTPISSUEDATE_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_SPOUSE_KTPEXPDATE_DAY, DDL_CU_SPOUSE_KTPEXPDATE_MONTH, TXT_CU_SPOUSE_KTPEXPDATE_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_TGLJATUHTEMPO_DAY, DDL_CU_TGLJATUHTEMPO_MONTH, TXT_CU_TGLJATUHTEMPO_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_TGLTERBIT_DAY, DDL_CU_TGLTERBIT_MONTH, TXT_CU_TGLTERBIT_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_ESTABLISHDD, DDL_CU_ESTABLISHMM, TXT_CU_ESTABLISHYY, true);
				GlobalTools.initDateForm(TXT_CU_COMPESTABLISHDD, DDL_CU_COMPESTABLISHMM, TXT_CU_COMPESTABLISHYY, true);
				GlobalTools.initDateForm(TXT_MATURITY_DAY, DDL_MATURITY_MONTH, TXT_MATURITY_YEAR, true);
				GlobalTools.fillRefList(DDL_CU_HOMESTA, "select * from RFHOMESTA where ACTIVE='1'", true, conn); //ahmad


				conn.QueryString = "select custtypeid, custtypedesc from rfcustomertype where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					RDO_RFCUSTOMERTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				conn.ClearData();

				RDO_RFCUSTOMERTYPE.SelectedIndex = 0;
				TR_PERSONAL.Visible = false;	TR_COMPANY.Visible = true;

				conn.QueryString = "select sexid, sexdesc from rfsex where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_SEX.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				conn.ClearData();

				conn.QueryString = "select maritalid, maritaldesc from rfmarital where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_MARITAL.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				conn.ClearData();

				conn.QueryString = "select jobtitleid, jobtitledesc from rfjobtitle where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_JOBTITLE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				conn.ClearData();

				conn.QueryString = "select BUSSTYPEID, BUSSTYPEID + ' - ' + BUSSTYPEDESC from RFBUSINESSTYPE where ACTIVE='1' AND LEN(BUSSTYPEID) < 3 ORDER BY BUSSTYPEID";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_CU_BUSSTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					DDL_CU_COMPBUSSTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}
				conn.ClearData();

				conn.QueryString = "select comptypeid, comptypedesc from rfcomptype where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_COMPTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				conn.ClearData();

				//GlobalTools.fillRefList(DDL_AI_FACILITY, "select PRODUCTID, SIBS_PRODID + ' | ' + PRODUCTDESC as PRODUCTDESC from RFPRODUCT where ACTIVE = '1'", false, conn);

				//GlobalTools.fillRefList(DDL_AI_FACILITY, "select SIBS_PRODID, SIBS_PRODID + ' | ' + PRODUCTDESC as PRODUCTDESC from RFPRODUCT where ACTIVE = '1'", false, conn);
				GlobalTools.fillRefList(DDL_AI_FACILITY, "select distinct SIBS_PRODID, SIBS_PRODID from RFPRODUCT where ACTIVE = '1'", false, conn);
				//menambahkan picklist product
				GlobalTools.fillRefList(DDL_PRODUCT, "select PRODUCTID, PRODUCTID + ' | ' + PRODUCTDESC as PRODUCTDESC from RFPRODUCT where ACTIVE = '1'", false, conn);
				GlobalTools.fillRefList(DDL_CU_JNSNASABAH, "select NASABAHID, NASABAHDESC from RFJENISNASABAH where ACTIVE='1' order by NASABAHID", true, conn);
				GlobalTools.fillRefList(DDL_JNSALAMAT_C, "select ALAMATID, ALAMATDESC from RFJENISALAMAT where ACTIVE='1' order by ALAMATID", true, conn);
				GlobalTools.fillRefList(DDL_CP_LOANPURPOSE, "select LOANPURPID, LOANPURPID + ' - ' + LOANPURPDESC as LOANPURPDESC from RFLOANPURPOSE where ACTIVE='1' order by LOANPURPID", false, conn);
		
				conn.QueryString = "select citizenid, citizendesc from rfcitizenship where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_CITIZENSHIP.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				conn.ClearData();
				LBL_STA.Text		= Request.QueryString["sta"];
				LBL_CU_REF.Text		= Request.QueryString["curef"];
				BTN_NEW.Enabled		= false;
				if (LBL_STA.Text=="exist")
				{
					BTN_NEW.Enabled				= true;
					RDO_RFCUSTOMERTYPE.Enabled	= false;
					//TXT_CU_CIF_P.ReadOnly		= true;
					//TXT_CU_CIF_C.ReadOnly		= true;dsfs
					ViewData();
					ViewWaspada();
				}
				
				DDL_TENORCODE.Items.Add(new ListItem("-- PILIH --", ""));
				conn.QueryString = "select tenorcode, tenordesc from rftenorcode where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_TENORCODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				AddAccount();
				ViewGrid();
			}

			viewMenu();
			HL_ACCOUNT.NavigateUrl = "InfoCustomer.aspx?sta="+LBL_STA.Text+"&curef="+LBL_CU_REF.Text+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"];
			HL_COLLATERAL.NavigateUrl = "Collateral_detail.aspx?sta="+LBL_STA.Text+"&curef="+LBL_CU_REF.Text+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"];
			HL_HISTORY.NavigateUrl = "CustHistory.aspx?sta="+LBL_STA.Text+"&curef="+LBL_CU_REF.Text+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"];
			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			BTN_NEW.Attributes.Add("onclick", "if(!cek_mandatory2(document.Form1)){return false;};");

			//DatGrd.ItemCommand += new DataGridCommandEventHandler(DatGrd_ItemCommand);
			//DatGrd.PageIndexChanged += new DataGridPageChangedEventHandler(DatGrd_PageIndexChanged);
		}

		private void SaveWaspada()
		{
			string waspada;
			try
			{
				if (CB_WASPADA.Checked == true)
					waspada = "1";
				else
					waspada = "";

				conn.QueryString = "EXEC CUSTINFO_SAVEWASPADA '" +
					LBL_CU_REF.Text + "', '" +
					waspada + "'";
				conn.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
				Tools.popMessage(this,"Insert Error!!");
			}
		}

		private void ViewWaspada()
		{
			conn.QueryString = "SELECT WASPADA FROM CUSTOMER WHERE CU_REF ='" + LBL_CU_REF.Text + "'";
			conn.ExecuteQuery();

			if (conn.GetFieldValue("WASPADA") == "1")
			{
				CB_WASPADA.Checked = true;
				TXT_CU_CIF_P.CssClass = "";
				TXT_CU_CIF_C.CssClass = "";
			}
			else
			{
				CB_WASPADA.Checked = false;
				TXT_CU_CIF_P.CssClass = "mandatory";
				TXT_CU_CIF_C.CssClass = "mandatory";
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);

		}
		#endregion

		private void viewMenu() 
		{
			string strtemp = "";

//			HyperLink t1		= new HyperLink();
//			t1.Text				= "Account Customer";
//			t1.Font.Bold		= true;			
//			strtemp				= "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"];			
//			t1.NavigateUrl		= "/SME/CustomerInfo/InfoCustomer.aspx?sta=exist&" + strtemp;
//			Menu.Controls.Add(t1);
//			Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
//
//			t1 = new HyperLink();
//			t1.Text = "Collateral Customer";
//			t1.Font.Bold = true;			
//			strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"];			
//			t1.NavigateUrl = "/SME/CustomerInfo/Collateral_detail.aspx?sta=exist&" + strtemp;
//			Menu.Controls.Add(t1);
//			Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));

			/*** 
			 * Untuk sementara saja, kebutuhan presentasi Corporate Customer
			 * ***/
//			t = new HyperLink();
//			t.Text = "DTBO";
//			t.Font.Bold = true;			
//			strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"];			
//			t.NavigateUrl = "/SME/DTBO/dtbo.aspx?" + strtemp;
//			Menu.Controls.Add(t);
//			Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
//
//			t = new HyperLink();
//			t.Text = "Nasabah/Group Info";
//			t.Font.Bold = true;			
//			strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"];			
//			t.NavigateUrl = "/SME/DataEntry/NasabahGroupInfo.aspx?de=1&" + strtemp;
//			Menu.Controls.Add(t);
//			Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
//
//			t = new HyperLink();
//			t.Text = "Hubungan Dengan Bank";
//			t.Font.Bold = true;			
//			strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"];			
//			t.NavigateUrl = "/SME/DataEntry/BankRelation.aspx?code=0&de=1&" + strtemp;
//			Menu.Controls.Add(t);
//			Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
//
//
//			t = new HyperLink();
//			t.Text = "Analysis History";
//			t.Font.Bold = true;			
//			strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"];			
//			t.NavigateUrl = "/SME/CreditAnalysis/MainCreditAnalysis.aspx?" + strtemp;
//			Menu.Controls.Add(t);
//			Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
//
//			t = new HyperLink();
//			t.Text = "Qualitative Analysis";
//			t.Font.Bold = true;			
//			strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"];			
//			t.NavigateUrl = "" + strtemp;
//			Menu.Controls.Add(t);
//			Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
//
//			t = new HyperLink();
//			t.Text = "Loan Application";
//			t.Font.Bold = true;			
//			strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"];			
//			t.NavigateUrl = "/SME/CustomerInfo/CustApplication.aspx?" + strtemp;
//			Menu.Controls.Add(t);
//			Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));

			
			// View Link dari sub-modul
			try 
			{
				//--- Membuat menu dari DATABASE
				conn.QueryString = "select * from SCREENMENU where menucode = '" + Request.QueryString["mc"] + "'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
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
				Console.Write(ex.Message);
			}			
		}

		protected void RDO_RFCUSTOMERTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (RDO_RFCUSTOMERTYPE.SelectedValue == "01")
			{
				TR_COMPANY.Visible	= true;
				TR_PERSONAL.Visible = false;
			}
			else
			{
				TR_COMPANY.Visible	= false;
				TR_PERSONAL.Visible = true;
			}		
		}

		private void ViewData()
		{
			string curef = LBL_CU_REF.Text;
			conn.QueryString = "select CU_CUSTTYPEID from customer where cu_ref='" + curef + "'";
			conn.ExecuteQuery();
			string cust_type = conn.GetFieldValue("CU_CUSTTYPEID");
			conn.ClearData();
			if (cust_type.Trim() == "02")
			{ // tipe customer = PERORANGAN
				TR_COMPANY.Visible					= false;
				TR_PERSONAL.Visible					= true;
				RDO_RFCUSTOMERTYPE.SelectedValue	= "02";
				
				conn.QueryString = "select * from vw_cust_personal where cu_ref='" + curef + "'";
				conn.ExecuteQuery();

				TXT_CU_CIF_P.Text		= conn.GetFieldValue("CU_CIF");
				TXT_CU_TITLEBEFORENAME.Text = conn.GetFieldValue("CU_TITLEBEFORENAME");
				TXT_CU_FIRSTNAME.Text	= conn.GetFieldValue("CU_FIRSTNAME");
				TXT_CU_MIDDLENAME.Text	= conn.GetFieldValue("CU_MIDDLENAME");
				TXT_CU_LASTNAME.Text	= conn.GetFieldValue("CU_LASTNAME");
				TXT_CU_ADDR1.Text		= conn.GetFieldValue("CU_ADDR1");
				TXT_CU_ADDR2.Text		= conn.GetFieldValue("CU_ADDR2");
				TXT_CU_ADDR3.Text		= conn.GetFieldValue("CU_ADDR3");
				TXT_CU_CITY.Text		= conn.GetFieldValue("CITYNAME");
				LBL_CU_CITY.Text		= conn.GetFieldValue("CU_CITY");
				TXT_CU_ZIPCODE.Text		= conn.GetFieldValue("CU_ZIPCODE");
				TXT_CU_PHNAREA.Text		= conn.GetFieldValue("CU_PHNAREA");
				TXT_CU_PHNNUM.Text		= conn.GetFieldValue("CU_PHNNUM");
				TXT_CU_PHNEXT.Text		= conn.GetFieldValue("CU_PHNEXT");
				TXT_CU_FAXAREA.Text		= conn.GetFieldValue("CU_FAXAREA");
				TXT_CU_FAXNUM.Text		= conn.GetFieldValue("CU_FAXNUM");
				TXT_CU_FAXEXT.Text		= conn.GetFieldValue("CU_FAXEXT");
				string dob				= conn.GetFieldValue("CU_DOB");
				TXT_CU_POB.Text			= conn.GetFieldValue("CU_POB");
				TXT_CU_DOB_DAY.Text		= tool.FormatDate_Day(dob);
				DDL_CU_DOB_MONTH.SelectedValue	= tool.FormatDate_Month(dob);
				TXT_CU_DOB_YEAR.Text			= tool.FormatDate_Year(dob);
				try { DDL_CU_MARITAL.SelectedValue	= conn.GetFieldValue("CU_MARITAL"); } 
				catch {}
				try {DDL_CU_SEX.SelectedValue		= conn.GetFieldValue("CU_SEX");} 
				catch {}
				TXT_CU_IDCARDNUM.Text			= conn.GetFieldValue("CU_IDCARDNUM");
				string expid					= conn.GetFieldValue("CU_IDCARDEXP");
				TXT_CU_IDCARDEXP_DAY.Text		= tool.FormatDate_Day(expid);
				try {DDL_CU_IDCARDEXP_MONTH.SelectedValue = tool.FormatDate_Month(expid);} 
				catch {}
				TXT_CU_IDCARDEXP_YEAR.Text		= tool.FormatDate_Year(expid);
				try {DDL_CU_JOBTITLE.SelectedValue	= conn.GetFieldValue("CU_JOBTITLE");} 
				catch {}
				try {DDL_CU_BUSSTYPE.SelectedValue	= conn.GetFieldValue("CU_BUSSTYPE"); }
				catch {}
				string esta						= conn.GetFieldValue("CU_ESTABLISHYY");
				TXT_CU_ESTABLISHDD.Text			= tool.FormatDate_Day(esta);
				try {DDL_CU_ESTABLISHMM.SelectedValue = tool.FormatDate_Month(esta);}
				catch {DDL_CU_ESTABLISHMM.SelectedValue = "";}
				TXT_CU_ESTABLISHYY.Text			= tool.FormatDate_Year(esta);
				TXT_CU_NPWP.Text				= conn.GetFieldValue("CU_NPWP");
				try {DDL_CU_CITIZENSHIP.SelectedValue = conn.GetFieldValue("CU_CITIZENSHIP");}
				catch {}
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
				try {DDL_CU_HOMESTA.SelectedValue = conn.GetFieldValue("CU_HOMESTA");} 
				catch {DDL_CU_HOMESTA.SelectedValue = "";}
				TXT_CU_MULAIMENETAPMM.Text = conn.GetFieldValue("CU_MULAIMENETAPMM");
				TXT_CU_MULAIMENETAPYY.Text = conn.GetFieldValue("CU_MULAIMENETAPYY");
				TXT_CU_EMPLOYEE.Text = conn.GetFieldValue("CU_EMPLOYEE");
			}
			else
			{ // tipe customer = BADAN USAHA
				TR_COMPANY.Visible					= true;
				TR_PERSONAL.Visible					= false;
				RDO_RFCUSTOMERTYPE.SelectedValue	= "01";

				conn.QueryString = "select * from vw_cust_company where cu_ref='" + curef + "'";
				conn.ExecuteQuery();
				
				if (conn.GetFieldValue("CU_CHANNELCOMP").Trim()=="1")
					CB_CU_CHANNEL.Checked			= true;
				TXT_CU_CIF_C.Text					= conn.GetFieldValue("CU_CIF");
				try { DDL_CU_COMPTYPE.SelectedValue		= conn.GetFieldValue("CU_COMPTYPE"); } 
				catch {}
				TXT_CU_COMPNAME.Text				= conn.GetFieldValue("CU_COMPNAME");
				TXT_CU_COMPADDR1.Text				= conn.GetFieldValue("CU_COMPADDR1");
				TXT_CU_COMPADDR2.Text				= conn.GetFieldValue("CU_COMPADDR2");
				TXT_CU_COMPADDR3.Text				= conn.GetFieldValue("CU_COMPADDR3");
				TXT_CU_COMPCITY.Text				= conn.GetFieldValue("CITYNAME");
				LBL_CU_COMPCITY.Text				= conn.GetFieldValue("CU_COMPCITY");
				TXT_CU_COMPZIPCODE.Text				= conn.GetFieldValue("CU_COMPZIPCODE");
				try {DDL_CU_COMPBUSSTYPE.SelectedValue	= conn.GetFieldValue("CU_COMPBUSSTYPE");}
				catch {}
				string esta							= conn.GetFieldValue("CU_COMPESTABLISH");
				TXT_CU_COMPESTABLISHYY.Text			= tool.FormatDate_Year(esta);
				try {DDL_CU_COMPESTABLISHMM.SelectedValue = tool.FormatDate_Month(esta);}
				catch {DDL_CU_COMPESTABLISHMM.SelectedValue = "";}
				TXT_CU_COMPESTABLISHDD.Text			= tool.FormatDate_Day(esta);
				TXT_CU_COMPPHNAREA.Text				= conn.GetFieldValue("CU_COMPPHNAREA");
				TXT_CU_COMPPHNNUM.Text				= conn.GetFieldValue("CU_COMPPHNNUM");
				TXT_CU_COMPPHNEXT.Text				= conn.GetFieldValue("CU_COMPPHNEXT");
				TXT_CU_COMPFAXAREA.Text				= conn.GetFieldValue("CU_COMPFAXAREA");
				TXT_CU_COMPFAXNUM.Text				= conn.GetFieldValue("CU_COMPFAXNUM");
				TXT_CU_COMPFAXEXT.Text				= conn.GetFieldValue("CU_COMPFAXEXT");
				TXT_CU_COMPNPWP.Text				= conn.GetFieldValue("CU_NPWP");
				TXT_CU_CONTACTPERSON.Text			= conn.GetFieldValue("CU_CONTACTPERSON");
				TXT_CU_CONTACTPHNAREA.Text			= conn.GetFieldValue("CU_CONTACTPHNAREA");
				TXT_CU_CONTACTPHNNUM.Text			= conn.GetFieldValue("CU_CONTACTPHNNUM");
				TXT_CU_CONTACTPHNEXT.Text			= conn.GetFieldValue("CU_CONTACTPHNEXT");
				TXT_CU_COMPEMPLOYEE.Text			= conn.GetFieldValue("CU_COMPEMPLOYEE");
				TXT_CU_COMPAKTAPENDIRIAN.Text		= conn.GetFieldValue("CU_COMPAKTAPENDIRIAN");
				try {DDL_CU_JNSNASABAH.SelectedValue = conn.GetFieldValue("CU_JNSNASABAH");}
				catch {}
				TXT_CU_TDP.Text						= conn.GetFieldValue("CU_TDP");
				try {DDL_JNSALAMAT_C.SelectedValue = conn.GetFieldValue("CU_JNSALAMAT");}
				catch {}
				try {GlobalTools.fromSQLDate(conn.GetFieldValue("CU_INSURANCEDATE"), TXT_CU_ISSUANCEDATE_DAY, DDL_CU_ISSUANCEDATE_MONTH, TXT_CU_ISSUANCEDATE_YEAR);}
				catch{}
				try {GlobalTools.fromSQLDate(conn.GetFieldValue("CU_TGLTERBIT"), TXT_CU_TGLTERBIT_DAY, DDL_CU_TGLTERBIT_MONTH, TXT_CU_TGLTERBIT_YEAR);}
				catch{}
				try {GlobalTools.fromSQLDate(conn.GetFieldValue("CU_TGLJATUHTEMPO"), TXT_CU_TGLJATUHTEMPO_DAY, DDL_CU_TGLJATUHTEMPO_MONTH, TXT_CU_TGLJATUHTEMPO_YEAR);}
				catch{}
				TXT_CU_COMPNOTARYNAME.Text		= conn.GetFieldValue("CU_COMPNOTARYNAME");
				TXT_CU_COMPANGGOTA.Text = conn.GetFieldValue("CU_COMPANGGOTA");
				TXT_CU_COMPPOB.Text = conn.GetFieldValue("CU_COMPPOB");
			}
		}

		protected void Radiobuttonlist1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (RB_ACCOUNT.SelectedValue == "0")
			{
				DDL_AI_AA_NO.Visible	= true;
				TXT_AI_AA_NO.Visible	= false;
				//TXT_LOANAMOUNT.ReadOnly	= true;
				//TXT_TENOR.ReadOnly		= true;
				//DDL_TENORCODE.Enabled	= false;
				//GetLimitValue();
			}
			else
			{
				DDL_AI_AA_NO.Visible	= false;
				TXT_AI_AA_NO.Visible	= true;
				//TXT_LOANAMOUNT.ReadOnly	= false;
				//TXT_TENOR.ReadOnly		= false;
				//DDL_TENORCODE.Enabled	= true;jkhlkhsfddsf
			}
		}

		private void ViewGrid()
		{
			conn.QueryString = "SELECT * from VW_BOOKEDPROD a Left Join rftenorcode b on a.bc_tenorcode=b.tenorcode where cu_ref='"+LBL_CU_REF.Text+"'";																					  
			conn.ExecuteQuery();

			DataTable d = new DataTable();
			d			= conn.GetDataTable().Copy();
			DatGrd.DataSource	= d;
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = 0;
				DatGrd.DataBind();
			}
		}

		private string getStatus(bool ISCHANNFACILITY) 
		{
			if (ISCHANNFACILITY) return "1";
			else return "0";
		}

		private bool getStatus(string ISCHANNFACILITY) 
		{
			if (ISCHANNFACILITY == "1") return true;
			else return false;
		}

		private void channFacilityReqCheck()
		{
			// 1. a Channeling-Facility		
			// - Nomor rekening must be empty and disable
			// - Maturity Date is mandatory
			
			// 2. NOT-a Channeling Facility
			// - Persentase dari Bank disable
			// - Remaining eMAS limit disable
			// - Pending Accept Limit disable

			if (CHK_ISCHANNFACILITY.Checked) 
			{
				TXT_AI_NOREK.Text = "";				

				TXT_AI_NOREK.ReadOnly = true;
				TXT_BANK_PERCENTAGE.ReadOnly = false;
				TXT_REMAINING_EMAS_LIMIT.ReadOnly = false;

				TXT_AI_NOREK.Enabled = false;
				TXT_BANK_PERCENTAGE.Enabled = true;
				TXT_REMAINING_EMAS_LIMIT.Enabled = true;
			}
			else 
			{				
				TXT_BANK_PERCENTAGE.Text = "";
				TXT_REMAINING_EMAS_LIMIT.Text = "";
			
				TXT_AI_NOREK.ReadOnly = false;
				TXT_BANK_PERCENTAGE.ReadOnly = true;
				TXT_REMAINING_EMAS_LIMIT.ReadOnly = true;				

				TXT_AI_NOREK.Enabled = true;
				TXT_BANK_PERCENTAGE.Enabled = false;
				TXT_REMAINING_EMAS_LIMIT.Enabled = false;
			}		
		}

		private bool channFacilityReqComplete() 
		{
			// 1. a Channeling-Facility		
			// - Nomor rekening must be empty and disable
			// - Maturity Date is mandatory
			
			// 2. NOT-a Channeling Facility
			// - Persentase dari Bank disable
			// - Remaining eMAS limit disable
			// - Pending Accept Limit disable

			bool retval = true;

			if (CHK_ISCHANNFACILITY.Checked) 
			{
				if (TXT_AI_NOREK.Text.Trim().Length > 0) 
				{
					GlobalTools.popMessage(this, "Nomor Rekening harus kosong!");
					TXT_AI_NOREK.Text = "";
					retval = false;
				}
				if (TXT_MATURITY_DAY.Text.Trim().Length == 0 || 
					DDL_MATURITY_MONTH.SelectedValue.Trim().Length == 0 || 
					TXT_MATURITY_YEAR.Text.Trim().Length == 0) 
				{
					GlobalTools.popMessage(this, "Maturity Date tidak boleh kosong!");
					retval = false;
				}
			}

			return retval;
		}

		protected void BTN_NEW_Click(object sender, System.EventArgs e)
		{
			if (RB_ACCOUNT.SelectedValue == "0" && DDL_AI_AA_NO.SelectedValue.Trim()=="")
			{
				Tools.popMessage(this,"AA No. harus dipilih !");
				Tools.SetFocus(this,DDL_AI_AA_NO);
			}
			else if (RB_ACCOUNT.SelectedValue == "1" && TXT_AI_AA_NO.Text.Trim()=="")
			{
				Tools.popMessage(this,"AA No. harus diisi !");
				Tools.SetFocus(this,TXT_AI_AA_NO);
			}
			else if (DDL_AI_FACILITY.SelectedValue.Trim()=="")
			{
				Tools.popMessage(this,"Kode Fasilitas harus diisi !");
				Tools.SetFocus(this,DDL_AI_FACILITY);
			}
			else if (TXT_AI_SEQ.Text.Trim()=="")
			{
				Tools.popMessage(this,"Sequence harus diisi !");
				Tools.SetFocus(this,TXT_AI_SEQ);
			}
			else if (RB_ACCOUNT.SelectedValue == "1" && TXT_LOANAMOUNT.Text.Trim()=="")
			{
				Tools.popMessage(this,"Total Loan Amount harus diisi !");
				Tools.SetFocus(this,TXT_LOANAMOUNT);
			}
			else if (TXT_TENOR.Text.Trim()=="")
			{
				Tools.popMessage(this,"Tenor harus diisi !");
				Tools.SetFocus(this,TXT_TENOR);
			}
			else if (DDL_TENORCODE.SelectedValue.Trim()=="")
			{
				Tools.popMessage(this,"Kode tenor harus diisi !");
				Tools.SetFocus(this,DDL_TENORCODE);
			}
			else if ((TXT_MATURITY_DAY.Text != "" || DDL_MATURITY_MONTH.SelectedValue != "" || 
				TXT_MATURITY_YEAR.Text != "") && 
				!GlobalTools.isDateValid(TXT_MATURITY_DAY.Text.Trim(), DDL_MATURITY_MONTH.SelectedValue, TXT_MATURITY_YEAR.Text.Trim()))
			{
				GlobalTools.popMessage(this, "Tanggal Maturity tidak valid !");
				Tools.SetFocus(this, TXT_MATURITY_DAY);
			}
				/*
				 * This part of code is disabled to accomodate expired-date entry
				 * 
				else if (Tools.compareDate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), TXT_MATURITY_DAY.Text, DDL_MATURITY_MONTH.SelectedValue, TXT_MATURITY_YEAR.Text) >= 0)
				{
					GlobalTools.popMessage(this, "Tanggal Maturity tidak boleh kurang dari Tanggal sekarang");
					Tools.SetFocus(this, TXT_MATURITY_DAY);
				}
				*/
			else if (channFacilityReqComplete() == false) 
			{
				// do nothing, just exit this function ....
			}
			else
			{
				string aa_no;
				if (RB_ACCOUNT.SelectedValue == "0")
					aa_no	= DDL_AI_AA_NO.SelectedValue;
				else
					aa_no	= TXT_AI_AA_NO.Text;


				/// If user insert new record, 
				/// CHECK for existing account (the same AANo, FacilityCode, AccSeq and AccNo)
				/// 
				if (TXT_STATUS.Text.Trim() == "insert") 
				{
					try 
					{
						/*
						conn.QueryString = "SELECT ACC_NO FROM BOOKEDPROD WHERE CU_REF = '" + LBL_CU_REF.Text + 
							"' and PRODUCTID = '" + DDL_AI_FACILITY.SelectedValue + 
							"' AND AA_NO = '" + aa_no + 
							"' AND ACC_SEQ = '" + TXT_AI_SEQ.Text.Trim() + 
							"' AND convert(bigint, ACC_NO) = '" + TXT_AI_NOREK.Text.Trim() + "'";
						*/
						conn.QueryString = "exec CUSTOMER_INFO_CEKBOOKEDPROD '" + 
							LBL_CU_REF.Text + "', '" + 
							DDL_AI_FACILITY.SelectedValue + "', '" + 
							aa_no + "', '" + 
							TXT_AI_SEQ.Text.Trim() + "', '" + 
							TXT_AI_NOREK.Text.Trim() + "', '" + 
							getStatus(CHK_ISCHANNFACILITY.Checked) + "', '1'";
						conn.ExecuteQuery();
					} 
					catch (Exception ex)
					{
						Response.Write("<!-- Error Check Existing Account | Desc: " + ex.ToString() + " -->");

						conn.QueryString = "SELECT ACC_NO FROM BOOKEDPROD WHERE CU_REF = '" + LBL_CU_REF.Text + 
							"' and PRODUCTID = '" + DDL_AI_FACILITY.SelectedValue + 
							"' AND AA_NO = '" + aa_no + 
							"' AND ACC_SEQ = '" + TXT_AI_SEQ.Text.Trim() + 
							"' AND isnull(ACC_NO,'') = '" + TXT_AI_NOREK.Text.Trim() + "'";
						conn.ExecuteQuery();
					}

					if (conn.GetRowCount() > 0) 
					{
						GlobalTools.popMessage(this, "The specified account already exist!");
						return;
					}
				}


				/// Check for existing AA No
				/// 
				/*
				 * This code is disabled becuase of withdrawal req
				 * 
				conn.QueryString = "select sta = case when cu_ref='"+LBL_CU_REF.Text+"' then 'true' else 'false' end "+
					"from bookedcust where aa_no='"+aa_no+"' ";
				*/
				conn.QueryString = "select 'true'";
				conn.ExecuteQuery();

				int row = conn.GetRowCount();
				if (row>0)
				{
					if (conn.GetFieldValue(0,0)=="true")
					{
						if (TXT_STATUS.Text == "insert")
							conn.QueryString = "exec IN_BOOKEDPROD '"+aa_no+"', '"+
								DDL_AI_FACILITY.SelectedValue+"', '"+
								TXT_AI_NOREK.Text.Trim()+"', "+
								tool.ConvertNum(TXT_AI_SEQ.Text)+", "+
								tool.ConvertFloat("0")+", '"+
								LBL_CU_REF.Text+"', "+
								tool.ConvertFloat(TXT_LOANAMOUNT.Text.Trim())+", "+
								tool.ConvertNum(TXT_TENOR.Text.Trim())+", '"+
								DDL_TENORCODE.SelectedValue+"', " + 
								tool.ConvertNull(DDL_PRODUCT.SelectedValue) + ", 0, '" + 
								getStatus(CHK_ISCHANNFACILITY.Checked) + "', " + 
								GlobalTools.ToSQLDate(TXT_MATURITY_DAY.Text.Trim(), DDL_MATURITY_MONTH.SelectedValue, TXT_MATURITY_YEAR.Text.Trim()) + ", " + 
								tool.ConvertFloat(TXT_BAKIDEBET.Text.Trim()) + ", " + 
								GlobalTools.ConvertFloat(TXT_BANK_PERCENTAGE.Text.Trim()) + ", " +
								GlobalTools.ConvertFloat(TXT_REMAINING_EMAS_LIMIT.Text.Trim()) + ","+
								GlobalTools.ConvertFloat(TXT_PENDING_ACCEPT_LIMIT.Text.Trim()) + ", NULL, '" +
								DDL_CP_LOANPURPOSE.SelectedValue + "'";
						else
							conn.QueryString = "exec IN_BOOKEDPROD '"+aa_no+"', '"+
								DDL_AI_FACILITY.SelectedValue+"', '"+
								TXT_AI_NOREK.Text.Trim()+"', "+
								tool.ConvertNum(TXT_AI_SEQ.Text.Trim())+", "+
								tool.ConvertFloat("0")+", '"+
								LBL_CU_REF.Text+"', "+
								tool.ConvertFloat(TXT_LOANAMOUNT.Text.Trim())+", "+
								tool.ConvertNum(TXT_TENOR.Text.Trim())+", '"+
								DDL_TENORCODE.SelectedValue+"', " + 
								tool.ConvertNull(DDL_PRODUCT.SelectedValue)+ ", 1, '" + 
								getStatus(CHK_ISCHANNFACILITY.Checked) + "', " +
								GlobalTools.ToSQLDate(TXT_MATURITY_DAY.Text.Trim(), DDL_MATURITY_MONTH.SelectedValue, TXT_MATURITY_YEAR.Text.Trim()) + ", " + 
								tool.ConvertFloat(TXT_BAKIDEBET.Text.Trim()) + ", " + 
								GlobalTools.ConvertFloat(TXT_BANK_PERCENTAGE.Text.Trim()) + ", " +
								GlobalTools.ConvertFloat(TXT_REMAINING_EMAS_LIMIT.Text.Trim()) + " ,"+
								GlobalTools.ConvertFloat(TXT_PENDING_ACCEPT_LIMIT.Text.Trim()) + ", '" + 
								TXT_AI_NOREK_OLD.Text.Trim() + "', '" +
								DDL_CP_LOANPURPOSE.SelectedValue + "'";
						conn.ExecuteNonQuery();

						//TXT_LOANAMOUNT.ReadOnly	= true;
						//TXT_TENOR.ReadOnly		= true;
						//DDL_TENORCODE.Enabled	= false;
						RB_ACCOUNT.Enabled		= true;
						AddAccount();
						TXT_STATUS.Text			= "insert";
						ClearItems();
						ChangeSta(true);
						ViewGrid();
					}
					else
						Tools.popMessage(this,"AA No. "+aa_no+" already exist with another customer !");
				}
				else
				{
					if (TXT_STATUS.Text == "insert")
						conn.QueryString = "exec IN_BOOKEDPROD '"+aa_no+"', '"+
							DDL_AI_FACILITY.SelectedValue+"', '"+
							TXT_AI_NOREK.Text.Trim()+"', "+
							tool.ConvertNum(TXT_AI_SEQ.Text.Trim())+", "+
							tool.ConvertFloat("00")+", '"+
							LBL_CU_REF.Text+"', "+
							tool.ConvertFloat(TXT_LOANAMOUNT.Text.Trim())+", "+
							tool.ConvertNum(TXT_TENOR.Text.Trim())+", '"+
							DDL_TENORCODE.SelectedValue+"', " + 
							tool.ConvertNull(DDL_PRODUCT.SelectedValue) + ", 0, '" + 
							getStatus(CHK_ISCHANNFACILITY.Checked) + "', " +
							GlobalTools.ToSQLDate(TXT_MATURITY_DAY.Text.Trim(), DDL_MATURITY_MONTH.SelectedValue, TXT_MATURITY_YEAR.Text.Trim()) + ", " + 
							tool.ConvertFloat(TXT_BAKIDEBET.Text.Trim()) + ", null,"+
							tool.ConvertFloat(TXT_REMAINING_EMAS_LIMIT.Text.Trim())+ " ,"+
							tool.ConvertFloat(TXT_PENDING_ACCEPT_LIMIT.Text.Trim())+ ", NULL, '" +
							DDL_CP_LOANPURPOSE.SelectedValue + "'";
					else
						conn.QueryString = "exec IN_BOOKEDPROD '"+
							aa_no+"', '"+
							DDL_AI_FACILITY.SelectedValue+"', '"+
							TXT_AI_NOREK.Text.Trim()+"', "+
							tool.ConvertNum(TXT_AI_SEQ.Text.Trim())+", "+
							tool.ConvertFloat("0")+", '"+
							LBL_CU_REF.Text+"', "+
							tool.ConvertFloat(TXT_LOANAMOUNT.Text.Trim())+", "+
							tool.ConvertNum(TXT_TENOR.Text.Trim())+", '"+
							DDL_TENORCODE.SelectedValue+"', '" + 
							tool.ConvertNull(DDL_PRODUCT.SelectedValue) + "', 1, '" + 
							getStatus(CHK_ISCHANNFACILITY.Checked) + "', " +
							GlobalTools.ToSQLDate(TXT_MATURITY_DAY.Text.Trim(), DDL_MATURITY_MONTH.SelectedValue, TXT_MATURITY_YEAR.Text.Trim()) + ", " + 
							tool.ConvertFloat(TXT_BAKIDEBET.Text.Trim()) + ", null,"+
							tool.ConvertFloat(TXT_REMAINING_EMAS_LIMIT.Text.Trim())+ "  ,"+
							tool.ConvertFloat(TXT_PENDING_ACCEPT_LIMIT.Text.Trim())+ ", '" + 
							TXT_AI_NOREK_OLD.Text.Trim() + "', '" +
							DDL_CP_LOANPURPOSE.SelectedValue + "'";
					conn.ExecuteNonQuery();

					//TXT_LOANAMOUNT.ReadOnly	= true;
					//TXT_TENOR.ReadOnly		= true;
					//DDL_TENORCODE.Enabled	= false;
					RB_ACCOUNT.Enabled		= true;
					AddAccount();
					TXT_STATUS.Text			= "insert";
					ClearItems();
					ChangeSta(true);
					ViewGrid();
				}
				conn.ClearData();
			}	
		}

		private void ChangeSta(bool sta)
		{
			DDL_AI_AA_NO.Enabled	= sta;
			DDL_AI_FACILITY.Enabled	= sta;
			TXT_AI_SEQ.Enabled		= sta;
			RB_ACCOUNT.Enabled		= sta;
			CHK_ISCHANNFACILITY.Enabled = sta;
		}

		private void ClearItems()
		{
			RB_ACCOUNT.SelectedValue		= "0";
			TXT_AI_AA_NO.Visible			= false;
			DDL_AI_AA_NO.Visible			= true;
			TXT_AI_AA_NO.Text				= "";
			DDL_AI_AA_NO.SelectedValue		= "";
			DDL_AI_FACILITY.SelectedValue	= "";
			TXT_AI_NOREK.Text				= "";
			TXT_AI_NOREK.Enabled			= true;
			TXT_AI_NOREK.ReadOnly			= false;
			DDL_TENORCODE.SelectedValue		= "";
			TXT_TENOR.Text					= "";
			TXT_AI_SEQ.Text					= "";
			//TXT_AI_LIMIT.Text				= "0";
			TXT_LOANAMOUNT.Text				= "0";

			DDL_PRODUCT.SelectedValue		= "";
			TXT_BAKIDEBET.Text = "";
			TXT_MATURITY_DAY.Text = "";
			DDL_MATURITY_MONTH.SelectedValue = "";
			TXT_MATURITY_YEAR.Text = "";

			TXT_BANK_PERCENTAGE.Text = "";
			TXT_BANK_PERCENTAGE.Enabled = false;
			TXT_BANK_PERCENTAGE.ReadOnly = true;

			TXT_REMAINING_EMAS_LIMIT.Text = "";
			TXT_REMAINING_EMAS_LIMIT.Enabled = false;
			TXT_REMAINING_EMAS_LIMIT.ReadOnly = true;

			TXT_PENDING_ACCEPT_LIMIT.Text = "";
			CHK_ISCHANNFACILITY.Checked = false;
			DDL_CP_LOANPURPOSE.SelectedValue = "";
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			
			string losproductid = "", norek = "";
			
			try
			{
				norek = e.Item.Cells[4].Text.Trim();
			} 
			catch {}

			if (norek=="&nbsp;")
			{	
				norek	= "";
			}

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Delete":
					//cari LOSPRODUCT dulu
					conn.QueryString = "select LOSPRODUCTID from BOOKEDPROD " +
						"where AA_NO = '" + e.Item.Cells[0].Text + "' and " +
						"PRODUCTID = '" + e.Item.Cells[1].Text + "' and " +
						"ACC_SEQ = '" + tool.ConvertNum(e.Item.Cells[5].Text) + 
						"' and isnull(ACC_NO,'') = '" + e.Item.Cells[4].Text.Trim() + 
						"' and CU_REF = '" + LBL_CU_REF.Text + "'";
					conn.ExecuteQuery();
					losproductid = conn.GetFieldValue("LOSPRODUCTID");

					//
					// Sebelum hapus, cek dulu relationship table dengan tabel lain
					//

					// Relationship dengan table Ketentuan_Kredit //
					try 
					{
						/*
						conn.QueryString = "select * from KETENTUAN_KREDIT A left join APPLICATION B" +
							" on A.AP_REGNO = B.AP_REGNO where A.AA_NO = '" + e.Item.Cells[0].Text + 
							"' and A.PRODUCTID = '" + e.Item.Cells[1].Text + 
							"' and A.ACC_SEQ = '" + e.Item.Cells[5].Text + 
							"' and A.ACC_NO = '" + e.Item.Cells[4].Text.Replace("&nbsp;","") + 
							"' and B.CU_REF <> '" + LBL_CU_REF.Text + "'";
						*/
						conn.QueryString = "exec CUSTOMER_INFO_CEKBOOKEDPROD '" + 
							LBL_CU_REF.Text + "', '" + 
							e.Item.Cells[1].Text.Trim() + "', '" + 
							e.Item.Cells[0].Text.Trim() + "', '" + 
							e.Item.Cells[5].Text.Trim() + "', '" + 
							e.Item.Cells[4].Text.Trim().Replace("&nbsp;","") + "', '" + 
							e.Item.Cells[11].Text.Trim() + "', '0'";
						conn.ExecuteQuery();

						//Response.Write("<!-- delete cek: " + conn.QueryString.ToString() + " -->");
					} 
					catch (NullReferenceException) 
					{
						GlobalTools.popMessage(this, "Connection Error!");
						Response.Redirect("../Login.aspx?expire=1");
					}
					if (conn.GetRowCount() > 0) 
					{
						GlobalTools.popMessage(this, "Account tidak bisa dihapus karena sudah terpakai!");
						return;
					}

					// Relationship dengan table Channeling //
					try 
					{
						conn.QueryString = "select * from CHANNELING  where CH_AA_NO = '" + e.Item.Cells[0].Text + 
							"' and CH_PRODUCTID = '" + e.Item.Cells[1].Text + 
							"' and CH_ACC_SEQ = '" + e.Item.Cells[5].Text + "'";
						conn.ExecuteQuery();
					} 
					catch (NullReferenceException) 
					{
						GlobalTools.popMessage(this, "Connection Error!");
						Response.Redirect("../Login.aspx?expire=1");
					}
					if (conn.GetRowCount() > 0) 
					{
						GlobalTools.popMessage(this, "Account tidak bisa dihapus karena sudah terpakai!");
						return;
					}

						
					conn.QueryString = "exec IN_BOOKEDPROD '" + 
						e.Item.Cells[0].Text.Trim() + "', '" + // AA_NO
						e.Item.Cells[1].Text.Trim() + "', '" + // PRODID
						e.Item.Cells[4].Text.Trim().Replace("&nbsp;","") +"', " +	// ACC_NO
						tool.ConvertNum(e.Item.Cells[5].Text.Trim()) + ", " +	// ACC_SEQ
						tool.ConvertFloat(e.Item.Cells[6].Text.Trim())+", '" + // LIMIT
						LBL_CU_REF.Text + "', '" + // CUREF
						tool.ConvertFloat(TXT_LOANAMOUNT.Text.Trim()) + "', '" + // LOAN
						e.Item.Cells[9].Text + "', '" + //BC_TENOR
						e.Item.Cells[10].Text + "', '" + // BC_TENORCODE
						losproductid + "', " + // LOSPRODUCTID
						"2, null, null, null,null, "+ //2 = Delete, null = ischannfacility
						tool.ConvertFloat(TXT_REMAINING_EMAS_LIMIT.Text.Trim())+", "+ 
						tool.ConvertFloat(TXT_PENDING_ACCEPT_LIMIT.Text.Trim())+", null, null"; 
					conn.ExecuteNonQuery();
					//Response.Write(conn.QueryString);
					AddAccount();
					int index = DatGrd.Items.Count;			
					int jml = (index % 3)-1;
					if (jml == 0)
						DatGrd.CurrentPageIndex = index/3;
					ViewGrid();
					break;

				case "Edit":
					//cari LOSPRODUCT dulu
					conn.QueryString = "select LOSPRODUCTID from BOOKEDPROD " +
						"where AA_NO = '" + e.Item.Cells[0].Text.Trim() + "' and " +
						"PRODUCTID = '" + e.Item.Cells[1].Text.Trim() + "' and " +
						"ACC_SEQ = '" + tool.ConvertNum(e.Item.Cells[5].Text.Trim()) + 
						"' and isnull(ACC_NO,'') = '" + norek + 
						"' and CU_REF = '" + LBL_CU_REF.Text + "'";
					conn.ExecuteQuery();
					losproductid = conn.GetFieldValue("LOSPRODUCTID");

					RB_ACCOUNT.SelectedValue		= "0";
					string loan						= e.Item.Cells[2].Text.Trim();
					if (loan=="&nbsp;")
						loan	= "0";
					string tenorcode				= e.Item.Cells[10].Text.Trim();
					if (tenorcode=="&nbsp;")
						tenorcode	= "";

					try { DDL_TENORCODE.SelectedValue		= tenorcode; } 
					catch {}
					try { DDL_AI_AA_NO.SelectedValue		= e.Item.Cells[0].Text.Trim(); } 
					catch {}
					try { DDL_AI_FACILITY.SelectedValue	= e.Item.Cells[1].Text.Trim(); } 
					catch {}
					TXT_LOANAMOUNT.Text				= loan;
					TXT_AI_NOREK.Text				= norek;
					TXT_AI_NOREK_OLD.Text			= norek;

					TXT_AI_SEQ.Text					= e.Item.Cells[5].Text.Trim();
					TXT_TENOR.Text					= e.Item.Cells[9].Text.Trim();
					//TXT_EMAS_LIMIT.Text				= e.Item.Cells[11].Text.Trim();

					try {DDL_PRODUCT.SelectedValue = losproductid;}
					catch {}

					TXT_STATUS.Text					= "edit";
					DDL_AI_AA_NO.Visible			= true;
					TXT_AI_AA_NO.Visible			= false;
					RB_ACCOUNT.Enabled				= false;
					//TXT_AI_NOREK.Enabled			= false;
					ChangeSta(false);

					////
					/// populate BAKI_DEBET, MATURITY_DATE, BANK_PERCENTAGE, and ISCHANNFACILITY
					/// 
					conn.QueryString = "select * from BOOKEDPROD where AA_NO = '" + e.Item.Cells[0].Text + 
						"' and PRODUCTID = '" + e.Item.Cells[1].Text + 
						"' and ACC_SEQ = '" + e.Item.Cells[5].Text + 
						"' and isnull(ACC_NO,'') = '" + norek + 
						"' and CU_REF = '" + LBL_CU_REF.Text + "'";
					conn.ExecuteQuery();
					TXT_BAKIDEBET.Text					= tool.MoneyFormat(conn.GetFieldValue("BAKI_DEBET"));
					TXT_MATURITY_DAY.Text				= GlobalTools.FormatDate_Day(conn.GetFieldValue("MATURITYDATE"));
					DDL_MATURITY_MONTH.SelectedValue	= GlobalTools.FormatDate_Month(conn.GetFieldValue("MATURITYDATE"));
					TXT_MATURITY_YEAR.Text				= GlobalTools.FormatDate_Year(conn.GetFieldValue("MATURITYDATE"));
					TXT_BANK_PERCENTAGE.Text			= GlobalTools.MoneyFormat(conn.GetFieldValue("BANK_PERCENTAGE"));
					TXT_REMAINING_EMAS_LIMIT.Text		= GlobalTools.MoneyFormat(conn.GetFieldValue("REMAINING_EMAS_LIMIT"));
					TXT_PENDING_ACCEPT_LIMIT.Text		= GlobalTools.MoneyFormat(conn.GetFieldValue("PENDING_ACCEPT_LIMIT"));
					CHK_ISCHANNFACILITY.Checked			= getStatus(conn.GetFieldValue("ISCHANNFACILITY"));
					try {DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue("LOANPURPID");}
					catch {}

					channFacilityReqCheck();
					break;
			}
		
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			TXT_STATUS.Text		= "insert";
			ClearItems();
			ChangeSta(true);
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex	= e.NewPageIndex;
			ViewGrid();
		}

		private void AddAccount()
		{
			DDL_AI_AA_NO.Items.Clear();
			DDL_AI_AA_NO.Items.Add(new ListItem("- PILIH -", ""));

			//conn.QueryString = "select distinct aa_no from BOOKEDCUST where cu_ref='"+LBL_CU_REF.Text+"'";			
			conn.QueryString = "select distinct AA_NO from BOOKEDPROD where cu_ref = '" + LBL_CU_REF.Text.Trim() + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_AI_AA_NO.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
			conn.ClearData();
		}

		// Dibuat oleh Yudi (2004/09/18) 
		// Untuk memeriksa validitas input sebelum save data ke database
		private bool isInputValid(string customerType) 
		{
			string CU_REF = Request.QueryString["curef"];
			bool validkah = true;

			if (customerType == "01") // company
			{
				//--- Cek NPWP Perusahaan
				conn.QueryString = "select count (*) from CUSTOMER where CU_REF <> '" + CU_REF + "' and CU_NPWP = '" + TXT_CU_COMPNPWP.Text + "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue(0,0) != "0")
				{
					Response.Write("<script language='javascript'>alert('Customer with NPWP: " + TXT_CU_COMPNPWP.Text + " exists in the system!');</script>");
					GlobalTools.SetFocus(this, TXT_CU_NPWP);
					return false;
				}

				//--- Cek Berdiri Sejak		
				if(!GlobalTools.isDateValid(this,TXT_CU_COMPESTABLISHDD.Text, DDL_CU_COMPESTABLISHMM.SelectedValue,TXT_CU_COMPESTABLISHYY.Text))
				{
					Response.Write("<script language='javascript'>alert('Tanggal berdiri sejak tidak valid!');</script>");
					GlobalTools.SetFocus(this, TXT_CU_COMPESTABLISHDD);
					return false;
				}
						
			}
			else	// personal
			{
				//--- Cek tanggal lahir
				if (!GlobalTools.isDateValid(this, TXT_CU_DOB_DAY.Text.Trim(), DDL_CU_DOB_MONTH.SelectedValue, TXT_CU_DOB_YEAR.Text.Trim())) 
				{
					Response.Write("<script language='javascript'>alert('Tanggal Lahir tidak valid');</script>");
					GlobalTools.SetFocus(this, TXT_CU_DOB_DAY);
					return false;
				}
				if (GlobalTools.isFuture(TXT_CU_DOB_DAY.Text.Trim(), DDL_CU_DOB_MONTH.SelectedValue, TXT_CU_DOB_YEAR.Text.Trim())) 
				{
					Response.Write("<script language='javascript'>alert('Tanggal Lahir melewati Tanggal sekarang!');</script>");
					GlobalTools.SetFocus(this, TXT_CU_DOB_DAY);
					return false;
				}

				string TGL_KTP = GlobalTools.ToSQLDate(TXT_CU_IDCARDEXP_DAY.Text.Trim(), DDL_CU_IDCARDEXP_MONTH.SelectedValue, TXT_CU_IDCARDEXP_YEAR.Text.Trim());
				conn.QueryString = "select count (*) from cust_personal where CU_REF <> '" + CU_REF + "' and CU_IDCARDNUM='" + TXT_CU_IDCARDNUM.Text + "' and CU_IDCARDEXP = " + TGL_KTP + "";
				conn.ExecuteQuery();

				if (conn.GetFieldValue(0,0) != "0")
				{
					Response.Write("<script language='javascript'>alert('Customer with KTP: " + TXT_CU_IDCARDNUM.Text + " and Expire Date: " + TGL_KTP.Replace("'","") + " exists in the system!');</script>");
					GlobalTools.SetFocus(this, TXT_CU_IDCARDNUM);
					return false;
				}				

				//--- Cek berdiri sejak
				if(!GlobalTools.isDateValid(this,TXT_CU_ESTABLISHDD.Text, DDL_CU_ESTABLISHMM.SelectedValue, TXT_CU_ESTABLISHYY.Text))
				{
					Response.Write("<script language='javascript'>alert('Tanggal berdiri sejak tidak valid!');</script>");
					GlobalTools.SetFocus(this, TXT_CU_ESTABLISHDD);
					return false;
				}
				
				Int64 personalEstablish;
				Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString()));

				//////////////////////////////////////////////////////////////
				///	VALIDASI BERDIRI SEJAK
				///	
				if (int.Parse(DDL_CU_ESTABLISHMM.SelectedValue) > 12)
				{
					GlobalTools.popMessage(this, "Berdiri Sejak (MM) tidak valid");
					return false;
				}
				try 
				{
					personalEstablish = Int64.Parse(Tools.toISODate(TXT_CU_ESTABLISHDD.Text, DDL_CU_ESTABLISHMM.SelectedValue, TXT_CU_ESTABLISHYY.Text));
				}
				catch 
				{
					GlobalTools.popMessage(this, "Berdiri Sejak tidak valid!");
					return false;
				}
				if (personalEstablish > now)
				{
					GlobalTools.popMessage(this, "Berdiri Sejak cannot be greater than current date!");
					return false;
				}

				//////////////////////////////////////////////////////////////////
				/// VALIDASI TANGGAL LAHIR
				/// 
				if (!GlobalTools.isDateValid(TXT_CU_DOB_DAY.Text, DDL_CU_DOB_MONTH.SelectedValue, TXT_CU_DOB_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Lahir tidak valid!");
					return false;
				}

				////////////////////////////////////////////////////////////////////
				///	VALIDASI TANGGAL BERAKHIR KTP
				///	
				if (!GlobalTools.isDateValid(TXT_CU_IDCARDEXP_DAY.Text, DDL_CU_IDCARDEXP_MONTH.SelectedValue, TXT_CU_IDCARDEXP_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Berakhir KTP tidak valid!");
					return false;
				}

				Int64 idcardexp = Int64.Parse(Tools.toISODate(TXT_CU_IDCARDEXP_DAY.Text, DDL_CU_IDCARDEXP_MONTH.SelectedValue, TXT_CU_IDCARDEXP_YEAR.Text));
				if (idcardexp < now) 
				{
					GlobalTools.popMessage(this, "Tanggal Berakhir KTP tidak boleh kurang dari tanggal sekarang!");
					return false;
				}

				////////////////////////////////////////////////////////////////////
				///	VALIDASI TANGGAL BERAKHIR KTP SPOUSE
				///	
				if (TXT_CU_SPOUSE_KTPEXPDATE_DAY.Text != "" && DDL_CU_SPOUSE_KTPEXPDATE_MONTH.SelectedValue != "" && TXT_CU_SPOUSE_KTPEXPDATE_YEAR.Text != "") 
				{
					if (!GlobalTools.isDateValid(TXT_CU_SPOUSE_KTPEXPDATE_DAY.Text, DDL_CU_SPOUSE_KTPEXPDATE_MONTH.SelectedValue, TXT_CU_SPOUSE_KTPEXPDATE_YEAR.Text)) 
					{
						GlobalTools.popMessage(this, "Tanggal Berakhir KTP Spouse tidak valid!");
						return false;
					}
				}
				int banding = Tools.compareDate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), TXT_CU_SPOUSE_KTPEXPDATE_DAY.Text, DDL_CU_SPOUSE_KTPEXPDATE_MONTH.SelectedValue, TXT_CU_SPOUSE_KTPEXPDATE_YEAR.Text);
				if (banding >= 0) 
				{
					GlobalTools.popMessage(this, "Tanggal Berakhir KTP Spouse tidak boleh kurang dari tanggal sekarang!");
					return false;
				}
				
				////////////////////////////////////////////////////////////////////
				///	VALIDASI TANGGAL ISSUANCE KTP
				///	
				if (TXT_CU_SPOUSE_KTPISSUEDATE_DAY.Text != "" && DDL_CU_SPOUSE_KTPISSUEDATE_MONTH.SelectedValue != "" && TXT_CU_SPOUSE_KTPISSUEDATE_YEAR.Text != "") 
				{
					if (!GlobalTools.isDateValid(TXT_CU_SPOUSE_KTPISSUEDATE_DAY.Text, DDL_CU_SPOUSE_KTPISSUEDATE_MONTH.SelectedValue, TXT_CU_SPOUSE_KTPISSUEDATE_YEAR.Text)) 
					{
						GlobalTools.popMessage(this, "Tanggal Issuance KTP Spouse tidak valid!");
						return false;
					}
				}				


			}

			return validkah;
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			string curef = LBL_CU_REF.Text;			
			if (!isInputValid(RDO_RFCUSTOMERTYPE.SelectedValue)) return;

			if (RDO_RFCUSTOMERTYPE.SelectedValue == "01")
			{ // kasus customer merupakan Badan Usaha
				conn.QueryString = "select cu_npwp from customer where cu_npwp='"+TXT_CU_COMPNPWP.Text+"' and cu_ref<>'"+curef+"' ";
				conn.ExecuteQuery();
				int row = conn.GetRowCount();
				if (row>0)
				{
					Tools.popMessage(this,"NPWP "+TXT_CU_COMPNPWP.Text+" already exist with another customer !");
					Tools.SetFocus(this,TXT_CU_COMPNPWP);
				}
				else
				{
					string channel = "0";
					if (CB_CU_CHANNEL.Checked)
						channel = "1";
					conn.QueryString = "exec IN_INFOCUST_COMPANY '" + 
						curef + "', '" +RDO_RFCUSTOMERTYPE.SelectedValue + "', '" +
						TXT_CU_CIF_C.Text + "', '" + 
						TXT_CU_COMPNPWP.Text + "', '" + 
						DDL_CU_COMPTYPE.SelectedValue + "', '" +
						TXT_CU_COMPNAME.Text + "', '" + 
						TXT_CU_COMPADDR1.Text + "', '" + TXT_CU_COMPADDR2.Text + "', '" + TXT_CU_COMPADDR3.Text + "', '" + 
						LBL_CU_COMPCITY.Text + "', '" + TXT_CU_COMPZIPCODE.Text + "', " +
						tool.ConvertNull(DDL_CU_COMPBUSSTYPE.SelectedValue) + ", " + 
						tool.ConvertDate(TXT_CU_COMPESTABLISHDD.Text, DDL_CU_COMPESTABLISHMM.SelectedValue ,TXT_CU_COMPESTABLISHYY.Text) + ", '" +
						TXT_CU_COMPPHNAREA.Text + "', '" + TXT_CU_COMPPHNNUM.Text + "', '" + 
						TXT_CU_COMPPHNEXT.Text + "', '" +
						TXT_CU_COMPFAXAREA.Text + "', '" + TXT_CU_COMPFAXNUM.Text + "', '" + 
						TXT_CU_COMPFAXEXT.Text + "', '" + 
						TXT_CU_CONTACTPERSON.Text + "', '" +
						TXT_CU_CONTACTPHNAREA.Text + "', '" + TXT_CU_CONTACTPHNNUM.Text + "', '" + 
						TXT_CU_CONTACTPHNEXT.Text + "', '" +TXT_CU_COMPEMPLOYEE.Text+"', '" +
						TXT_CU_COMPAKTAPENDIRIAN.Text + "', " + // akta pendirian
						tool.ConvertDate(TXT_CU_ISSUANCEDATE_DAY.Text,DDL_CU_ISSUANCEDATE_MONTH.SelectedValue,TXT_CU_ISSUANCEDATE_YEAR.Text) + ", '" + // tanggal issuance
						Session["UserID"].ToString() + "', '"+channel+"', " + 
						tool.ConvertNull(DDL_CU_JNSNASABAH.SelectedValue) + ", " + 
						tool.ConvertNull(TXT_CU_TDP.Text) + ", " + 
						tool.ConvertNull(DDL_JNSALAMAT_C.SelectedValue) + ", '" + TXT_CU_COMPPOB.Text + "'";
					conn.ExecuteNonQuery();

					conn.QueryString = "exec IDE_GENINFO_COMP_INSERT2 '" + 
						curef + "', " + 
						tool.ConvertDate(TXT_CU_ISSUANCEDATE_DAY.Text,DDL_CU_ISSUANCEDATE_MONTH.SelectedValue,TXT_CU_ISSUANCEDATE_YEAR.Text) + ", " + // tanggal issuance
						tool.ConvertDate(TXT_CU_TGLJATUHTEMPO_DAY.Text, DDL_CU_TGLJATUHTEMPO_MONTH.SelectedValue, TXT_CU_TGLJATUHTEMPO_YEAR.Text) + ", " + // tanggal jatuh tempo
						tool.ConvertDate(TXT_CU_TGLTERBIT_DAY.Text, DDL_CU_TGLTERBIT_MONTH.SelectedValue, TXT_CU_TGLJATUHTEMPO_YEAR.Text) + ", " + // tgl penerbitan
						tool.ConvertNull(TXT_CU_COMPNOTARYNAME.Text.Trim()) + ", " +	// nama notaris
						tool.ConvertNull(TXT_CU_COMPANGGOTA.Text.Trim());
					conn.ExecuteNonQuery();


					RDO_RFCUSTOMERTYPE.Enabled = false;
					LBL_STA.Text	= "exist";
					BTN_NEW.Enabled	= true;
					ViewData();

					SaveWaspada();
					ViewWaspada();
				}
			}				
			else
			{

				conn.QueryString = "select cu_npwp from customer where cu_npwp='" + TXT_CU_NPWP.Text + "' and cu_ref<>'" + curef + "' and cu_npwp <> ''";
				conn.ExecuteQuery();
				int row = conn.GetRowCount();
				if (row>0)
				{
					Tools.popMessage(this,"NPWP "+TXT_CU_NPWP.Text+" already exist with another customer !");
					Tools.SetFocus(this,TXT_CU_NPWP);
				}
				else
				{
					conn.QueryString = "exec IN_INFOCUST_PERSONAL '" + 
						curef + "', '" + RDO_RFCUSTOMERTYPE.SelectedValue + "', '" +
						TXT_CU_CIF_P.Text + "', '" +
						TXT_CU_NPWP.Text +"', '" +
						TXT_CU_FIRSTNAME.Text + "', '" + TXT_CU_MIDDLENAME.Text + "', '" + TXT_CU_LASTNAME.Text + "', '" + 
						TXT_CU_ADDR1.Text + "', '" + TXT_CU_ADDR2.Text + "', '" + TXT_CU_ADDR3.Text + "', '" + 
						LBL_CU_CITY.Text + "', '" + TXT_CU_ZIPCODE.Text + "', '" + 
						TXT_CU_PHNAREA.Text + "', '" + TXT_CU_PHNNUM.Text + "', '" + 
						TXT_CU_PHNEXT.Text + "', '" + TXT_CU_FAXAREA.Text + "', '" + 
						TXT_CU_FAXNUM.Text + "', '" + TXT_CU_FAXEXT.Text + "', '" +
						TXT_CU_POB.Text + "', " + tool.ConvertDate(TXT_CU_DOB_DAY.Text, DDL_CU_DOB_MONTH.SelectedValue, TXT_CU_DOB_YEAR.Text) + ", " +
						tool.ConvertNull(DDL_CU_MARITAL.SelectedValue) + ", " + tool.ConvertNull(DDL_CU_SEX.SelectedValue) + ", '" + 
						TXT_CU_IDCARDNUM.Text + "', " + tool.ConvertDate(TXT_CU_IDCARDEXP_DAY.Text, DDL_CU_IDCARDEXP_MONTH.SelectedValue, TXT_CU_IDCARDEXP_YEAR.Text) + ", " + 
						tool.ConvertNull(DDL_CU_JOBTITLE.SelectedValue) + ", " + tool.ConvertNull(DDL_CU_BUSSTYPE.SelectedValue) + ", " +
						tool.ConvertDate(TXT_CU_ESTABLISHDD.Text, DDL_CU_ESTABLISHMM.SelectedValue ,TXT_CU_ESTABLISHYY.Text) + ", " + 
						tool.ConvertNull(DDL_CU_CITIZENSHIP.SelectedValue)+", '" +
						Session["UserID"].ToString() + "', '"+TXT_CU_TITLEBEFORENAME.Text+"' ";
					conn.ExecuteNonQuery();

					//--- untuk menyimpan informasi spouse/pasangan
					conn.QueryString = "exec IDE_GENINFO_PERSON_INSERT3 '" + Request.QueryString["curef"] + "', " + 
						tool.ConvertNull(TXT_CU_SPOUSE_FNAME.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_SPOUSE_MNAME.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_SPOUSE_LNAME.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_SPOUSE_IDCARDNUM.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_SPOUSE_KTPADDR1.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_SPOUSE_KTPADDR2.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_SPOUSE_KTPADDR3.Text.Trim()) + ", " + 
						tool.ConvertDate(TXT_CU_SPOUSE_KTPISSUEDATE_DAY.Text, DDL_CU_SPOUSE_KTPISSUEDATE_MONTH.SelectedValue, TXT_CU_SPOUSE_KTPISSUEDATE_YEAR.Text) + ", " + 
						tool.ConvertDate(TXT_CU_SPOUSE_KTPEXPDATE_DAY.Text, DDL_CU_SPOUSE_KTPEXPDATE_MONTH.SelectedValue, TXT_CU_SPOUSE_KTPEXPDATE_YEAR.Text) + " , " + 
						tool.ConvertNull(TXT_CU_NOKARTUKELUARGA.Text.Trim()) + "";
					conn.ExecuteNonQuery();

					conn.QueryString = "exec IDE_GENINFO_PERSON_INSERT2 '" + curef + "', " + 
						tool.ConvertNull(DDL_CU_HOMESTA.SelectedValue) + ", " + 
						tool.ConvertNull(TXT_CU_MULAIMENETAPMM.Text) + ", " + 
						tool.ConvertNull(TXT_CU_MULAIMENETAPYY.Text) + ", " +
						tool.ConvertNull(TXT_CU_EMPLOYEE.Text.Trim());
					conn.ExecuteNonQuery();


					RDO_RFCUSTOMERTYPE.Enabled = false;
					LBL_STA.Text	= "exist";
					BTN_NEW.Enabled	= true;
					ViewData();

					SaveWaspada();
					ViewWaspada();
				}
			}
		}

		protected void BTN_SEARCHPERSONAL_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_ZIPCODE','SearchZipcode','status=no,scrollbars=yes,width=420,height=200');</script>");
		}

		protected void BTN_SEARCHCOMP_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_COMPZIPCODE','SearchZipcode','status=no,scrollbars=yes,width=420,height=200');</script>");
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
			//Response.Redirect("SearchCorporateCustomer.aspx?mc=030");

			Response.Redirect("SearchCustomer.aspx?mc=030");
		}

		protected void TXT_CU_ZIPCODE_TextChanged(object sender, System.EventArgs e)
		{
			LBL_CU_CITY.Text = "";
			TXT_CU_CITY.Text = "";
			conn.QueryString = "select cityid, cityname, [description] from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + 
				TXT_CU_ZIPCODE.Text.Trim() + "' ";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				LBL_CU_CITY.Text = conn.GetFieldValue(i,0);
				TXT_CU_CITY.Text = conn.GetFieldValue(i,2);
			}
		}

		protected void TXT_CU_COMPZIPCODE_TextChanged(object sender, System.EventArgs e)
		{
			LBL_CU_COMPCITY.Text = "";
			TXT_CU_COMPCITY.Text = "";
			conn.QueryString = "select cityid, cityname, [description] from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + 
				TXT_CU_COMPZIPCODE.Text.Trim() + "' ";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				LBL_CU_COMPCITY.Text = conn.GetFieldValue(i,0);
				TXT_CU_COMPCITY.Text = conn.GetFieldValue(i,2);
			}
		}

/*		private void TXT_AI_LIMIT_TextChanged(object sender, System.EventArgs e)
		{
			float tot_limit=0, tot_amount=float.Parse(tool.ConvertFloat(TXT_LOANAMOUNT.Text));
			if (RB_ACCOUNT.SelectedValue == "0")
			{
																conn.QueryString = "select bc_loanamount from bookedcust "+
																	"where cu_ref='"+LBL_CU_REF.Text+"' and productid='"+DDL_AI_FACILITY.SelectedValue+"' and aa_no='"+DDL_AI_AA_NO.SelectedValue+"'";
																conn.ExecuteQuery();
																if (conn.GetRowCount()>0)
																{
																	conn.QueryString = "select limit = case when sum(limit) is null then 0 else sum(limit)-(select limit from bookedprod where productid='"+DDL_AI_FACILITY.SelectedValue+"' and aa_no='"+DDL_AI_AA_NO.SelectedValue+"' and acc_seq="+tool.ConvertNum(TXT_AI_SEQ.Text)+" ) end from bookedprod "+
																		"where productid='"+DDL_AI_FACILITY.SelectedValue+"' and aa_no='"+DDL_AI_AA_NO.SelectedValue+"'";
																	conn.ExecuteQuery();
																	tot_limit = float.Parse(tool.ConvertFloat(conn.GetFieldValue("limit")));
																	conn.ClearData();
																}
															}
			float limit		= float.Parse(tool.ConvertFloat(TXT_AI_LIMIT.Text));
			float total		= limit+tot_limit;
			if (total>tot_amount)
			{
				Tools.popMessage(this,"Limit yang diminta melebihi limit loan amount");
				TXT_AI_LIMIT.Text		= "0";
				Tools.SetFocus(this,TXT_AI_LIMIT);
			}
		}
*/
		protected void DDL_AI_AA_NO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//GetLimitValue();
			//string a = "a";
		}

		private void GetLimitValue()
		{
			if (RB_ACCOUNT.SelectedValue == "0")
			{
				conn.QueryString = "select bc_loanamount, bc_tenor, bc_tenorcode from bookedcust "+
					"where cu_ref='"+LBL_CU_REF.Text+"' and productid='"+DDL_AI_FACILITY.SelectedValue+"' and aa_no='"+DDL_AI_AA_NO.SelectedValue+"'";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					TXT_LOANAMOUNT.Text			= conn.GetFieldValue("bc_loanamount");
					TXT_LOANAMOUNT.ReadOnly		= true;
					TXT_TENOR.Text				= conn.GetFieldValue("bc_tenor");
					TXT_TENOR.ReadOnly			= true;
					DDL_TENORCODE.SelectedValue = conn.GetFieldValue("bc_tenorcode");
					DDL_TENORCODE.Enabled		= false;
				}
				else
				{
				TXT_LOANAMOUNT.Text			= "0";
				TXT_LOANAMOUNT.ReadOnly		= false;
				TXT_TENOR.Text				= "0";
				TXT_TENOR.ReadOnly			= false;
				DDL_TENORCODE.SelectedValue = "";
				DDL_TENORCODE.Enabled		= true;
				}
				conn.ClearData();
			}
			else
			{
				TXT_LOANAMOUNT.Text			= "0";
				TXT_LOANAMOUNT.ReadOnly		= false;
				TXT_TENOR.Text				= "0";
				TXT_TENOR.ReadOnly			= false;
				DDL_TENORCODE.SelectedValue = "";
				DDL_TENORCODE.Enabled		= true;
			}
		}

		protected void DDL_AI_FACILITY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//GetLimitValue();
			//string a ="a";
			Tools.SetFocus(this, TXT_AI_SEQ);
		}

		protected void CHK_ISCHANNFACILITY_CheckedChanged(object sender, System.EventArgs e)
		{
			channFacilityReqCheck();
			GlobalTools.SetFocus(this, TXT_AI_SEQ);
		}

		protected void CB_WASPADA_CheckedChanged(object sender, System.EventArgs e)
		{
			if (CB_WASPADA.Checked == true)
			{
				TXT_CU_CIF_P.CssClass = "";
				TXT_CU_CIF_C.CssClass = "";
			}
			else
			{
				TXT_CU_CIF_P.CssClass = "mandatory";
				TXT_CU_CIF_C.CssClass = "mandatory";
			}
		}
	}
}
