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
using DMS.BlackList;
using System.Xml;
using System.IO;

namespace SME.InitialDataEntry
{
	/// <summary>
	/// Summary description for GeneralInfo.
	/// Created by: Andri I. Gani
	/// Continued by : Yudi Adhitiya
	/// </summary>
	public partial class GeneralInfo : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.TextBox Textbox9;
		protected System.Web.UI.WebControls.DropDownList DDL_netincome;
		protected System.Web.UI.WebControls.DropDownList DDL_pendapatanoperasional;
		protected System.Web.UI.WebControls.DropDownList DDL_pendapatannon;
		protected System.Web.UI.WebControls.DropDownList DDL_keyperson;
		protected Deduplication dedup = new Deduplication();
		protected System.Web.UI.WebControls.TextBox TXT_OUTSTANDING;
		protected System.Web.UI.WebControls.TextBox TXT_RATIO_LIMIT;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox TXT_PENDING;
		protected System.Web.UI.WebControls.TextBox TXT_AVAILABLE;
		protected System.Web.UI.WebControls.TextBox TXT_RATIO_AVAIL;
		protected System.Web.UI.WebControls.TextBox TXT_INDUSTRYCLASS;
		protected System.Web.UI.WebControls.TextBox TXT_STATUS;
		protected System.Web.UI.WebControls.Label lbl_ksebi4;
		protected System.Web.UI.WebControls.Button BTN_PORTFOLIO;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected CommonForm.DocumentUpload DocUpload1;
	
		//string temp_grpunit;
		//string temp_userid;
		//string temp_branchcode;
		//string temp_areaid;
        string pin_small, pin_middle, pin_corporate, pin_crg, pin_micro;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (DDL_CHANNEL_CODE.SelectedIndex > 0)
            {
                TR_Source_Code.Visible = true;
                TR_Referal_NAME.Visible = true;
            }
            else
            {
                TR_Source_Code.Visible = false;
                TR_Referal_NAME.Visible = false;
            }

			TR_GROSSSALES.Visible=false;
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack && Request.QueryString["udah"] != "123")
			{
                conn.QueryString = "SELECT IN_SMALL, IN_MIDDLE, IN_CORPORATE, IN_CRG, IN_MICRO FROM RFINITIAL";
                conn.ExecuteQuery();

                pin_small = conn.GetFieldValue("IN_SMALL");
                pin_middle = conn.GetFieldValue("IN_MIDDLE");
                pin_corporate = conn.GetFieldValue("IN_CORPORATE");
                pin_crg = conn.GetFieldValue("IN_CRG");
                pin_micro = conn.GetFieldValue("IN_MICRO");
                
                conn.QueryString = "SELECT sg_BUSSUNITid,sg_grpunit FROM scgroup WHERE groupid = '" + Session["GroupID"].ToString() + "'";
				conn.ExecuteQuery();
				temp_grpunit.Text = conn.GetFieldValue("sg_grpunit");
				temp_areaid.Visible=false;
				temp_userid.Visible=false;
				temp_branchcode.Visible=false;
				temp_grpunit.Visible=false;

                if ((conn.GetFieldValue("sg_BUSSUNITid") != "") && ((conn.GetFieldValue("sg_BUSSUNITid") == pin_small) ||
					(conn.GetFieldValue("sg_BUSSUNITid") == pin_middle) ||
                    (conn.GetFieldValue("sg_BUSSUNITid") == pin_corporate) ||
                    (conn.GetFieldValue("sg_BUSSUNITid") == pin_crg) ||
                    (conn.GetFieldValue("sg_BUSSUNITid") == pin_micro)))
				{
					Label_generalinfo1.Text="Suku Bunga Pasar";
					Textbox_skbngpasar.Visible=true;
					DDL_AP_SALESAGENCY.Visible=false;
					Label_generalinfo2.Text="Suku Bunga yang diminta";
					Textbox_skbngminta.Visible=true;
					DDL_AP_SALESSUPERV.Visible=false;
					DDL_AP_SALESEXEC.Visible=false;
					TR_generalinfo3.Visible=false;
					TR_telepon.Visible=false;
					TR_koperasi.Visible=false;
					TR_anggota.Visible=false;
					TR_sektor.Visible=true;
				}
				else
				{
					Label_generalinfo1.Text="Nama Sales Agency";
					Textbox_skbngpasar.Visible=false;
					DDL_AP_SALESAGENCY.Visible=true;
					Label_generalinfo2.Text="Nama Sales Supervisor";
					Textbox_skbngminta.Visible=false;
					DDL_AP_SALESSUPERV.Visible=true;
					Label_generalinfo3.Text="Nama Sales Executive";
					DDL_AP_SALESEXEC.Visible=true;
					TR_sektor.Visible=false;
				}
				if (Request.QueryString["gi"] == "" || Request.QueryString["gi"] == null)
					if (temp_grpunit.Text != "CO")
						Response.Write("<script for=window event=onload language='javascript'>PopupPage('Artikel230.aspx?targetFormID=Form1&targetObjectID=TXT_CON', '1000','450');</script>");

				LBL_AP_RELMNGR.Text = Session["UserID"].ToString();
				TXT_AP_RELMNGR.Text = Session["FullName"].ToString();

				//pipeline
				temp_userid.Text = Session["UserID"].ToString();
				temp_branchcode.Text = Session["BranchID"].ToString();
				temp_areaid.Text = Session["AreaID"].ToString();
				
				DDL_AP_SIGNDATE_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_BUSSTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_COMPBUSSTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_DOB_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_IDCARDEXP_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CHANNEL_CODE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_COMPTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_JOBTITLE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_MARITAL.Items.Add(new ListItem("- PILIH -", ""));
				DDL_PROG_CODE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_AP_SALESAGENCY.Items.Add(new ListItem("- PILIH -", ""));
				DDL_AP_SALESEXEC.Items.Add(new ListItem("- PILIH -", ""));
				DDL_AP_SALESSUPERV.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_SEX.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_CITIZENSHIP.Items.Add(new ListItem("- PILIH -", ""));
				DDL_JNSALAMAT_C.Items.Add(new ListItem("- PILIH -", ""));
				DDL_JNSALAMAT_P.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_JNSNASABAH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_EDUCATION.Items.Add(new ListItem("- PILIH -", ""));
				DDL_AP_BOOKINGBRANCH.Items.Add(new ListItem("- PILIH -", ""));
				//20070725 add by sofyan for cco branch
				DDL_AP_CCOBRANCH.Items.Add(new ListItem("- PILIH -", ""));
				TXT_AP_RECVDATE.Text = tool.FormatDate(DateTime.Now.ToString());
				TXT_BRANCH_CODE.Text = Session["BranchName"].ToString();
				TXT_AREAID.Text = Session["AreaName"].ToString();
				DDL_AP_SRCCODE.Items.Add(new ListItem("- PILIH -", ""));
				//20080716 pipeline
				//DDL_groupnasabah.Items.Add(new ListItem("- PILIH -", ""));
				DDL_bmsektor.Items.Add(new ListItem("- PILIH -", ""));
				DDL_bmsubsektor.Items.Add(new ListItem("- PILIH -", ""));
				DDL_bmsubsubsektor.Items.Add(new ListItem("- PILIH -", ""));

				//2010-04-08 Enhancement 2010
				DDL_CU_LOKASIDATI2.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_HUBEXECBM.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_HUBKELBM.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_COMPEXTRATING_BY.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_COMPLISTINGCODE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_NEGARADOMISILI.Items.Add(new ListItem("- PILIH -", ""));

				DDL_SURATNSBTGL_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_SURATNSBTGLTRM_MONTH.Items.Add(new ListItem("- PILIH -", ""));
                DDL_CU_KODEINSTANSI.Items.Add(new ListItem("- PILIH -", ""));

				for (int i = 1; i <= 12; i++)
				{
					DDL_AP_SIGNDATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CU_DOB_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CU_IDCARDEXP_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_SURATNSBTGL_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_SURATNSBTGLTRM_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				GlobalTools.fillRefList(DDL_CU_HOMESTA, "select * from RFHOMESTA where ACTIVE='1'", true, conn);
				GlobalTools.initDateForm(TXT_CU_SPOUSE_KTPISSUEDATE_DAY, DDL_CU_SPOUSE_KTPISSUEDATE_MONTH, TXT_CU_SPOUSE_KTPISSUEDATE_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_SPOUSE_KTPEXPDATE_DAY, DDL_CU_SPOUSE_KTPEXPDATE_MONTH, TXT_CU_SPOUSE_KTPEXPDATE_YEAR, true);
					
				conn.QueryString = "select sourcecode, sourcedesc from rfsourcecode where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_AP_SRCCODE.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select agencyid, agencyname from vw_rfagency where areaid='" + Session["AreaID"].ToString() + "' and agencytypeid='02' and active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_AP_SALESAGENCY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				
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

				RDO_RFCUSTOMERTYPE.SelectedIndex = 0;
				TR_PERSONAL.Visible = false;	TR_COMPANY.Visible = true;

				conn.QueryString = "select channel_code, channel_desc from rfchannels where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CHANNEL_CODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

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

				conn.QueryString = "select BUSSTYPEID, BUSSTYPEID + ' - ' + BUSSTYPEDESC as BUSSTYPEDESC from RFBUSINESSTYPE where ACTIVE='1' order by BUSSTYPEID";
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

				conn.QueryString = "select branch_name, branch_code from rfbranch where active='1' and br_isbookingbranch = '1' order by branch_code";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_AP_BOOKINGBRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,1) + " - " + conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));

				//20070725 add by sofyan for cco branch
				conn.QueryString = "select branch_name, branch_code from rfbranch order by branch_code";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_AP_CCOBRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,1) + " - " + conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));
				//set default cco branch
				conn.QueryString = "select br_ccobranch from rfbranch where branch_code = '" + Session["BranchID"].ToString() + "'";
				conn.ExecuteQuery();
				try { DDL_AP_CCOBRANCH.SelectedValue = conn.GetFieldValue("br_ccobranch"); }
				catch {}

				conn.QueryString = "select currencyid from rfcurrency where active = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_AP_GRSALESCURR.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));

				try { DDL_AP_GRSALESCURR.SelectedValue = "IDR"; } catch { }


				//20080716 pipeline
				//bm sektor ekonomi
				conn.QueryString = "select bm_code,bm_code + ' - ' + bm_desc as bmsektorDESC from RFbmsektorekonomi where ACTIVE='1' order by bm_code";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_bmsektor.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					//DDL_bmsektor.SelectedValue=conn.GetFieldValue("bm_code");
				//bm sub sektor

                conn.QueryString = "select bmsub_code,bmsub_code + ' - ' + bmsub_desc as bmsubsektorDESC from RFbmsubsektorekonomi where ACTIVE='1' and BM_CODE = '"  + DDL_bmsektor.SelectedValue + "'	order by bmsub_code";
                //conn.QueryString = "select bmsub_code,bmsub_code + ' - ' + bmsub_desc as bmsubsektorDESC from RFbmsubsektorekonomi where ACTIVE='1' and bm_code='01000000' order by bmsub_code";
                conn.ExecuteQuery();
                for (int i = 0; i < conn.GetRowCount(); i++)
                    DDL_bmsubsektor.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
                    //GlobalTools.popMessage(this, DDL_bmsektor.SelectedValue);

				//lokasi proyek
				conn.QueryString = "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_LOKASIPROYEK_ALL";
				//else conn.QueryString = "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_LOKASIPROYEK ";
				conn.ExecuteQuery();
				DDL_lokasiproyek.Items.Clear();
                DDL_lokasiproyek.Items.Add(new ListItem("- PILIH -", ""));
				for (int i=0; i<conn.GetRowCount(); i++)
					DDL_lokasiproyek.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				//lokasi proyek end
				/*--nggak jadi pipeline
				conn.QueryString = "select bussunitid,bussunitdesc from rfbusinessunit where active = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_AP_BUSINESSUNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				--nggak jadi pipeline */
				//conn.QueryString = "select programid, programdesc from rfprogram where active='1' and businessunit='" + DDL_AP_BUSINESSUNIT.SelectedValue + "'";
				//conn.ExecuteQuery();
				//for (int i = 0; i < conn.GetRowCount(); i++)
				//	DDL_PROG_CODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				conn.ClearData();

				GlobalTools.initDateForm(TXT_CU_COMPTGASURANSI_DAY, DDL_CU_TGASURANSI_MONTH, TXT_CU_COMPTGASURANSI_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_TGLJATUHTEMPO_DAY, DDL_CU_TGLJATUHTEMPO_MONTH, TXT_CU_TGLJATUHTEMPO_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_TGLTERBIT_DAY, DDL_CU_TGLTERBIT_MONTH, TXT_CU_TGLTERBIT_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_ESTABLISHDD, DDL_CU_ESTABLISHMM, TXT_CU_ESTABLISHYY, true);
				GlobalTools.initDateForm(TXT_CU_COMPESTABLISHDD, DDL_CU_COMPESTABLISHMM, TXT_CU_COMPESTABLISHYY, true);
				GlobalTools.initDateForm(TXT_CU_COMPAKTATERAKHIR_DATE_DAY, DDL_CU_COMPAKTATERAKHIR_DATE_MONTH, TXT_CU_COMPAKTATERAKHIR_DATE_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_COMPEXTRATING_DATE_DAY, DDL_CU_COMPEXTRATING_DATE_MONTH, TXT_CU_COMPEXTRATING_DATE_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_COMPLISTINGDATE_DAY, DDL_CU_COMPLISTINGDATE_MONTH, TXT_CU_COMPLISTINGDATE_YEAR, true);

				//2010-04-08 Enhancement 2010
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

                //Kode Instansi
                conn.QueryString = "select agencyid, agencyname from vw_rfagency where areaid='" + Session["AreaID"].ToString() + "' and agencytypeid='03' and active='1'";
                conn.ExecuteQuery();
                for (int i = 0; i < conn.GetRowCount(); i++)
                    DDL_CU_KODEINSTANSI.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				TXT_CU_REF.Text = Request.QueryString["curef"];
				TXT_AP_REGNO.Text = Request.QueryString["regno"];

				BTN_SAVECON.Visible = false;

				Tools.initDateForm(TXT_AP_SIGNDATE_DAY, DDL_AP_SIGNDATE_MONTH, TXT_AP_SIGNDATE_YEAR, false);

				if (Request.QueryString["exist"] == "1")
				{
					conn.QueryString = "select top 1 bs_recvdate from bi_status where cu_ref='" + Request.QueryString["curef"] + "' order by bs_recvdate desc";
					conn.ExecuteQuery();
					try
					{
						TXT_BS_RECVDATE.Text = tool.FormatDate(conn.GetFieldValue(0,0), true);
					}
					catch{}

					//--- if existing customer, user tidak bisa ganti tipe customer
					RDO_RFCUSTOMERTYPE.Enabled = false;

					conn.QueryString = "select PRE_APPENTRYDATE from CUSTOMER_PRE_ENTRY where cu_ref = '"+TXT_CU_REF.Text+"' and PRE_SEQSURAT = '"+Request.QueryString["seq"]+"'";
					conn.ExecuteQuery();

					if(conn.GetRowCount() != 0) 
					{

						TXT_AP_SIGNDATE_DAY.Text			= GlobalTools.FormatDate_Day(conn.GetFieldValue("PRE_APPENTRYDATE"));   
						DDL_AP_SIGNDATE_MONTH.SelectedValue = GlobalTools.FormatDate_Month(conn.GetFieldValue("PRE_APPENTRYDATE"));   
						TXT_AP_SIGNDATE_YEAR.Text			= GlobalTools.FormatDate_Year(conn.GetFieldValue("PRE_APPENTRYDATE")); 
					}
				}

				ViewData();
				
				CheckBusinessUnit();
				if (DDL_AP_BUSINESSUNIT.Items.Count == 0)
					if (temp_grpunit.Text != "CO")
					Response.Write("<script language='javascript'>alert('User Does not have upliner! Cannot proceed!');</script>");

				/* **********************************************************************
				 * Initialize program
				 * */
				/*
				conn.QueryString = "select programid, programdesc from rfprogram where areaid='" + Session["AreaID"].ToString() + 
									"' and active='1' and businessunit='" + DDL_AP_BUSINESSUNIT.SelectedValue + "'";
				*/
				conn.QueryString = "exec SP_IDE_GENINFO_PROGRAMLIST '" + 
					Session["AreaID"] + "', '" + 
					DDL_AP_BUSINESSUNIT.SelectedValue	+ "', '" + 
					Session["GroupID"] + "'";
				conn.ExecuteQuery();
                for (int i = 0; i < conn.GetRowCount(); i++)
                    DDL_PROG_CODE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

                /*
				 * ***********************************************************************
				 * */

				//Populate Group Unit
				GlobalTools.fillRefList(DDL_GRPUNIT, "select * from RFGROUPUNIT where ACTIVE ='1'", false, conn);
				DDL_GRPUNIT.Items.RemoveAt(0);	//hapus --PILIH--
				DDL_GRPUNIT.SelectedValue = "CO";

				this.SetMandatory(RDO_RFCUSTOMERTYPE.SelectedValue);				
				//this.setMandatoryFI(RDO_RFCUSTOMERTYPE.SelectedValue, DDL_PROG_CODE.SelectedValue);

				//--- Kalau screen ini sudah dikunjungi, maka disable beberapa field
				if (Request.QueryString["gi"]=="0") 
				{
					ViewDataVisited();
				
					//////////////////////////////////////////////
					/// TODO : Please don't hard code !!!!
					/// 			
					TXT_CU_CHILDREN.CssClass = "";
					//TXT_CU_MULAIMENETAPMM.CssClass = "";
					//TXT_CU_MULAIMENETAPYY.CssClass = "";

					setMandatoryFI(RDO_RFCUSTOMERTYPE.SelectedValue, DDL_PROG_CODE.SelectedValue);
				}
				//pipeline			

				ViewDataSurat();

				DocUpload1.GroupTemplate = "IDE_SURAT";
				DocUpload1.WithReadExcel = false;
			}

			//--- Kalau baru masuk pertama kali ke screen, maka
			//--- screen tidak perlu diperlihatkan
			if (Request.QueryString["gi"] != "" && Request.QueryString["gi"] != null)
				ViewMenu();

			TR_GROSSSALES.Visible = false;
			TXT_AP_GROSSSALES.Text = tool.MoneyFormat(TXT_AP_GROSSSALES.Text);
			if (RDO_RFCUSTOMERTYPE.SelectedValue != "01")
				TXT_CU_NETINCOMEMM.Text = tool.MoneyFormat(TXT_CU_NETINCOMEMM.Text);
			//BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			//BTN_SAVECON.Attributes.Add("onclick","if(!cek_mandatory2(document.Form1)){return false;};"); 

            BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.getElementById('Form1'))){return false;};");
			BTN_SAVECON.Attributes.Add("onclick","if(!cek_mandatory2(document.getElementById('Form1'))){return false;};");
		}

		private bool CheckDocument()
		{
			conn.QueryString = "EXEC IDE_CHECKDOCUMENT '" + 
				Request.QueryString["regno"] + "', '" + 
				Request.QueryString["curef"] + "', '" + 
				Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
				return true;
			else
				return false;
		}

		private void setMandatoryFI(string custType, string programid)
		{
			/////////////////////////////////////////////////////
			///	setMandatoryFI(custType, ap_regno)
			/// Men-set field mandatory untuk Fair Isaac (FI)
			/// 

			// menentukan nama mandatory
			string namaMandatory = "";
			if (custType == "02") namaMandatory = "mandatory2";
			else namaMandatory = "mandatory";

			// mencari field yang mandatory ....
			conn.QueryString = "select * from VW_SCORING_MANDATORY_FIELDS2 " + 
				"where FAIRISAAC_SUBMODULE = 'U'" +
				" and PROGRAMID = '" + programid +
				"' and ACTIVE = '1' " +
				" and GR_KEY like '%SCR_IDE%'";
			conn.ExecuteQuery();

			for(int i=0; i < conn.GetRowCount(); i++) 
			{
				string CONTROLID = conn.GetFieldValue(i, "FAIRISAAC_CONTROLID");
			
				if (CONTROLID.IndexOf(",") == 0) 
				{
					if (CONTROLID.StartsWith("TXT_")) 
					{
						TextBox TXT_CONTROL = (TextBox) Page.FindControl(CONTROLID);
						try {TXT_CONTROL.CssClass = namaMandatory;}
						catch (NullReferenceException) {}
					}
					else if (CONTROLID.StartsWith("DDL_")) 
					{
						DropDownList DDL_CONTROL = (DropDownList) Page.FindControl(CONTROLID);
						try {DDL_CONTROL.CssClass = namaMandatory;}
						catch {}
					}
				} 
				else 
				{
					string CONTROL;
					string[] split = CONTROLID.Split(new Char[] {','});
				
					foreach(string s in split) 
					{
						if (s.Trim() != "") 
						{
							CONTROL = s;
							if (CONTROL.StartsWith("TXT_")) 
							{
								TextBox TXT_CONTROL = (TextBox) Page.FindControl(CONTROL);
								try {TXT_CONTROL.CssClass = namaMandatory;}
								catch (NullReferenceException) {}
							}
							else if (CONTROL.StartsWith("DDL_")) 
							{
								DropDownList DDL_CONTROL = (DropDownList) Page.FindControl(CONTROL);
								try {DDL_CONTROL.CssClass = namaMandatory;}
								catch {}
							}
						}
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


		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				string mc1 = Request.QueryString["mc"];
				string mc2 = Request.QueryString["mc"];
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

						//---  untuk general info
						if (conn.GetFieldValue(i,3).IndexOf("?exist=") < 0 && conn.GetFieldValue(i,3).IndexOf("&exist=") < 0) 
							strtemp = strtemp + "&exist=" + Request.QueryString["exist"];	

						//--- untuk program yang dipilih
						if (conn.GetFieldValue(i,3).IndexOf("?prog=") < 0 && conn.GetFieldValue(i,3).IndexOf("&prog=") < 0) 
							strtemp = strtemp + "&prog=" + Request.QueryString["prog"];	

						//t.ForeColor = Color.MidnightBlue; 
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


		private void CheckBusinessUnit()
		{
            if (temp_grpunit.Text != "CO") 
			{
                DataTable dt_rfbusinessunit = new DataTable();
                DataTable dt_rfinitial = new DataTable();
                DataTable dt_scuserupliner = new DataTable();

                conn.QueryString = "SELECT BUSSUNITID, BUSSUNITDESC FROM RFBUSINESSUNIT WHERE ACTIVE = '1'";
                conn.ExecuteQuery();

                dt_rfbusinessunit = conn.GetDataTable().Copy();

                conn.QueryString = "SELECT IN_SMALL, IN_MIDDLE, IN_CORPORATE, IN_CRG, IN_MICRO FROM RFINITIAL";
                conn.ExecuteQuery();

                dt_rfinitial = conn.GetDataTable().Copy();

				conn.QueryString = "SELECT SU_UPLINER, SU_MIDUPLINER, SU_CORUPLINER, SU_CRGUPLINER, SU_MCRUPLINER FROM SCUSER WHERE USERID = '" + Session["UserID"].ToString() + "'";
				conn.ExecuteQuery();

                dt_scuserupliner = conn.GetDataTable().Copy();

                DataTable dt_merge = new DataTable();
                dt_merge.Columns.Add();
                dt_merge.Columns.Add();
                dt_merge.Columns.Add();
                dt_merge.Columns.Add();
                dt_merge.Columns.Add();

                DataRow dr1;
                DataRow dr2;

                dr1 = dt_rfinitial.Rows[0];
                dr2 = dt_scuserupliner.Rows[0];

                dt_merge.Rows.Add(dr1.ItemArray);
                dt_merge.Rows.Add(dr2.ItemArray);

                for (int i = 0; i < dt_rfbusinessunit.Rows.Count; i++)
                {
                    for (int j = 0; j < dt_merge.Columns.Count; j++)
                    {
                        if ((dt_rfbusinessunit.Rows[i][0].ToString() == dt_merge.Rows[0][j].ToString()) && (dt_merge.Rows[1][j].ToString() != ""))
                        {
                            DDL_AP_BUSINESSUNIT.Items.Add(new ListItem(dt_rfbusinessunit.Rows[i][1].ToString(), dt_rfbusinessunit.Rows[i][0].ToString()));
                        }
                    }
                }
			}

			conn.QueryString = "SELECT SG_BUSSUNITID FROM SCGROUP WHERE GROUPID = '" + Session["GroupID"].ToString() + "'";
			conn.ExecuteQuery();

			try { DDL_AP_BUSINESSUNIT.SelectedValue = conn.GetFieldValue("SG_BUSSUNITID"); }
			catch { DDL_AP_BUSINESSUNIT.SelectedIndex = 0; }
		}
		protected void RDO_RFCUSTOMERTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetMandatory(RDO_RFCUSTOMERTYPE.SelectedValue);
			return;
		}

		private void SetMandatory(string custType)
		{
			if (custType == "01")
			{
				BTN_SAVE.Visible = true;
				BTN_SAVECON.Visible = false;
				TR_COMPANY.Visible = true;
				TR_PERSONAL.Visible = false;
				TXT_AREAID.CssClass = "mandatory";
				TXT_BRANCH_CODE.CssClass = "mandatory";
				DDL_PROG_CODE.CssClass = "mandatory";
				DDL_AP_SRCCODE.CssClass = "";
				TXT_AP_GROSSSALES.CssClass = "";
				DDL_AP_GRSALESCURR.CssClass = "";
                DDL_AP_BOOKINGBRANCH.CssClass = "mandatory";
                DDL_AP_CCOBRANCH.CssClass = "mandatory";
				TXT_AP_SIGNDATE_DAY.CssClass = "mandatory";
				DDL_AP_SIGNDATE_MONTH.CssClass = "mandatory";
				TXT_AP_SIGNDATE_YEAR.CssClass = "mandatory";
				DDL_AP_BUSINESSUNIT.CssClass = "mandatory";
				TXT_SURATNSBNO.CssClass = "mandatory";
				TXT_SURATNSBTGL_DAY.CssClass = "mandatory";
				DDL_SURATNSBTGL_MONTH.CssClass = "mandatory";
				TXT_SURATNSBTGL_YEAR.CssClass = "mandatory";
				TXT_SURATNSBTGLTRM_DAY.CssClass = "mandatory";
				DDL_SURATNSBTGLTRM_MONTH.CssClass = "mandatory";
				TXT_SURATNSBTGLTRM_YEAR.CssClass = "mandatory";
                DDL_bmsektor.CssClass = "selectpicker mandatory";
                DDL_bmsubsektor.CssClass = "selectpicker mandatory";
                DDL_bmsubsubsektor.CssClass = "selectpicker mandatory";
                DDL_SEKTOREKONOMIBI.CssClass = "mandatory";
                Textbox_netincome.CssClass = "mandatory";
                DDL_lokasiproyek.CssClass = "selectpicker mandatory";
                Textbox_keyperson.CssClass = "mandatory";
                DDL_CU_LOKASIDATI2.CssClass = "selectpicker mandatory";
                DDL_CU_HUBEXECBM.CssClass = "mandatory";
			}
			else
			{
				BTN_SAVECON.Visible = true;
				BTN_SAVE.Visible = false;
				TR_COMPANY.Visible = false;
				TR_PERSONAL.Visible = true;
				TXT_AREAID.CssClass = "mandatory2";
				TXT_BRANCH_CODE.CssClass = "mandatory2";
				DDL_PROG_CODE.CssClass = "mandatory2";
				DDL_AP_SRCCODE.CssClass = "";
				TXT_AP_GROSSSALES.CssClass = "";
				DDL_AP_GRSALESCURR.CssClass = "";
                DDL_AP_BOOKINGBRANCH.CssClass = "mandatory2";
                DDL_AP_CCOBRANCH.CssClass = "mandatory";
				TXT_AP_SIGNDATE_DAY.CssClass = "mandatory2";
				DDL_AP_SIGNDATE_MONTH.CssClass = "mandatory2";
				TXT_AP_SIGNDATE_YEAR.CssClass = "mandatory2";
				DDL_AP_BUSINESSUNIT.CssClass = "mandatory2";
				TXT_SURATNSBNO.CssClass = "mandatory2";
				TXT_SURATNSBTGL_DAY.CssClass = "mandatory2";
				DDL_SURATNSBTGL_MONTH.CssClass = "mandatory2";
				TXT_SURATNSBTGL_YEAR.CssClass = "mandatory2";
				TXT_SURATNSBTGLTRM_DAY.CssClass = "mandatory2";
				DDL_SURATNSBTGLTRM_MONTH.CssClass = "mandatory2";
				TXT_SURATNSBTGLTRM_YEAR.CssClass = "mandatory2";
                DDL_bmsektor.CssClass = "selectpicker mandatory2";
                DDL_bmsubsektor.CssClass = "selectpicker mandatory2";
                DDL_bmsubsubsektor.CssClass = "selectpicker mandatory2";
                DDL_SEKTOREKONOMIBI.CssClass = "mandatory2";
                Textbox_netincome.CssClass = "mandatory2";
                DDL_lokasiproyek.CssClass = "selectpicker mandatory2";
                Textbox_keyperson.CssClass = "mandatory2";
                DDL_CU_LOKASIDATI2.CssClass = "selectpicker mandatory2";
                DDL_CU_HUBEXECBM.CssClass = "mandatory2";
			}
		}

		private void ViewData()
		{
			try 
			{
				//BI Checking
				conn.QueryString = "select AP_CHECKBI, AP_CHECKBIGROUP from APPLICATION where AP_REGNO = '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				if(conn.GetRowCount() <= 0)
				{
					conn.QueryString = "select AP_CHECKBI, AP_CHECKBIGROUP from APPLICATION where AP_REGNO = '" + Request.QueryString["curef"] + "C'";
					conn.ExecuteQuery();
				}
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

            //data application
			

			//Data Customer
			string temp_curef = TXT_CU_REF.Text;
			conn.QueryString = "select top 1 * from vw_ide_geninfo where cu_ref='" + Request.QueryString["curef"] + "' or cu_ref is null order by ap_recvdate desc";
			conn.ExecuteQuery();
			//pipeline
			string bm_subsektor = conn.GetFieldValue("CU_bmsubsektorekonomi");
			string bm_subsubsektor = conn.GetFieldValue("CU_bmsubsubsektorekonomi");
			string BI_SEKTOREKONOMI = conn.GetFieldValue("BI_SEKTOREKONOMI");
			if (BI_SEKTOREKONOMI == "")
			{
				//conn.QueryString = "select Bi_seq, BMSUBSUB_DESC from RFBMSUBSUBSEKTOREKONOMI where BMSUB_CODE = '" + BM_SUBSEKTOREKONOMI + "'";
				conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + bm_subsubsektor + "'";
				conn.ExecuteQuery();
				BI_SEKTOREKONOMI = conn.GetFieldValue("BI_SEQ");
			}
			//Textbox_skbngpasar.Text=conn.GetFieldValue("CU_skbngpasar");
			//Textbox_skbngminta.Text= conn.GetFieldValue("CU_skbngdiminta");
			DDL_groupnasabah.Text=conn.GetFieldValue("CU_groupnasabah");
			Textbox_netincome.Text=conn.GetFieldValue("CU_netincome");
			Textbox_pendapatanoperasional.Text=conn.GetFieldValue("CU_pendoperasional");
			Textbox_pendapatannon.Text=conn.GetFieldValue("CU_pendnonoperasional");
			DDL_lokasiproyek.SelectedValue=conn.GetFieldValue("CU_lokasiproyek");
			Textbox_keyperson.Text=conn.GetFieldValue("CU_keyperson");

			//2010-04-08 Enhancement 2010
			try {DDL_CU_LOKASIDATI2.SelectedValue = conn.GetFieldValue("CU_LOKASIDATI2");}
			catch {}
			try {DDL_CU_HUBEXECBM.SelectedValue = conn.GetFieldValue("CU_HUBEXECBM");}
			catch {}
			try {DDL_CU_HUBKELBM.SelectedValue = conn.GetFieldValue("CU_HUBKELBM");}
			catch {}

			try {DDL_bmsektor.SelectedValue=conn.GetFieldValue("CU_bmsektorekonomi");}
			catch {}
			    //sub sektor
			GlobalTools.fillRefList(DDL_bmsubsektor, "select BMSUB_CODE, BMSUB_DESC from RFBMSUBSEKTOREKONOMI where ACTIVE = '1' and BM_CODE = '" + DDL_bmsektor.SelectedValue + "'", true, conn);
			try
            {
                DDL_bmsubsektor.SelectedValue=bm_subsektor;
                TXT_bmsubsektor.Text = bm_subsektor;
            }
			catch {}
			   //sub sub sektor
			GlobalTools.fillRefList(DDL_bmsubsubsektor, "select BMSUBSUB_CODE, BMSUBSUB_DESC from RFBMSUBSUBSEKTOREKONOMI where ACTIVE = '1' and BMSUB_CODE = '" + DDL_bmsubsektor.SelectedValue + "'", true, conn);
			try
            {
                DDL_bmsubsubsektor.SelectedValue=bm_subsubsektor;
                TXT_bmsubsubsektor.Text = bm_subsubsektor;
            }
			catch {}
				//bi sektor
			GlobalTools.fillRefList(DDL_SEKTOREKONOMIBI, "select BI_SEQ, BI_DESC from RFBICODE where BG_GROUP = '3' and BI_SEQ = '" + BI_SEKTOREKONOMI + "'", true, conn);
			try{DDL_SEKTOREKONOMIBI.SelectedValue = BI_SEKTOREKONOMI;}
			catch{DDL_SEKTOREKONOMIBI.SelectedValue="";}

			
			
			//pipeline

			//Data Customer lagi setelah bm sektor
			//string temp_curef = conn.GetFieldValue("cu_ref");
			conn.QueryString = "select top 1 * from vw_ide_geninfo where cu_ref='" + temp_curef + "' or cu_ref is null order by ap_recvdate desc";
			conn.ExecuteQuery();
			string salesExec = conn.GetFieldValue("AP_SALESEXEC"), salesSuperv = conn.GetFieldValue("AP_SALESSUPERV");

			if (conn.GetFieldValue("CU_CUSTTYPEID") == "02")
			{
				TR_COMPANY.Visible = false;
				TR_PERSONAL.Visible = true;
				RDO_RFCUSTOMERTYPE.SelectedValue = "02";
				
				TXT_AP_GROSSSALES.Text = conn.GetFieldValue("AP_GROSSSALES");
				try {DDL_AP_BOOKINGBRANCH.SelectedValue = conn.GetFieldValue("AP_BOOKINGBRANCH");} 
				catch {DDL_AP_BOOKINGBRANCH.SelectedValue = "";}

				//20070725 add by sofyan for cco branch
				try {DDL_AP_CCOBRANCH.SelectedValue = conn.GetFieldValue("AP_CCOBRANCH");} 
				catch {DDL_AP_CCOBRANCH.SelectedValue = "";}

				try {DDL_AP_GRSALESCURR.SelectedValue = conn.GetFieldValue("AP_GROSSSALESCURR");} 
				catch { }

				conn.QueryString = "select seq, ag_officer from rfagencyuser where agencyid='" + DDL_AP_SALESAGENCY.SelectedValue + "' and active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_AP_SALESEXEC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					DDL_AP_SALESSUPERV.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}
				
				conn.QueryString = "select * from VW_CUST_PERSONAL where CU_REF='" + Request.QueryString["curef"] + "'";
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
				TXT_CU_MOTHER.Text = conn.GetFieldValue("CU_MOTHER");
				//2010-04-08 Enhancement 2010
				TXT_CU_NAMAPELAPORAN.Text = conn.GetFieldValue("CU_NAMAPELAPORAN");
				TXT_CU_ALIASNAME.Text = conn.GetFieldValue("CU_ALIASNAME");
				try {DDL_CU_NEGARADOMISILI.SelectedValue = conn.GetFieldValue("CU_NEGARADOMISILI");}
				catch {}
                TXT_CU_TEMPATKERJA.Text = conn.GetFieldValue("CU_TEMPATKERJA");
                try { DDL_CU_KODEINSTANSI.SelectedValue = conn.GetFieldValue("CU_KODEINSTANSI"); }
                catch { }
                TXT_CU_NOPEGAWAI.Text = conn.GetFieldValue("CU_NOPEGAWAI");
			}			
			else if (conn.GetFieldValue("CU_CUSTTYPEID") == "01")
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

				//20070725 add by sofyan for cco branch
				try 
				{
					DDL_AP_CCOBRANCH.SelectedValue = conn.GetFieldValue("AP_CCOBRANCH");
				} 
				catch {DDL_AP_CCOBRANCH.SelectedValue = "";}

				try {DDL_AP_GRSALESCURR.SelectedValue = conn.GetFieldValue("AP_GROSSSALESCURR");} 
				catch { }
				
				conn.QueryString = "select seq, ag_officer from rfagencyuser where agencyid='" + DDL_AP_SALESAGENCY.SelectedValue + "' and active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_AP_SALESEXEC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					DDL_AP_SALESSUPERV.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}
				
				conn.QueryString = "select * from VW_CUST_COMPANY where CU_REF='" + Request.QueryString["curef"] + "'";
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
				TXT_CU_COMPPOB.Text = conn.GetFieldValue("CU_COMPPOB");
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
			//pipeline
			if (temp_grpunit.Text == "CO")
			{
				//ViewMenu();
				conn.QueryString = " select top 1 * from application where ap_regno='" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
				if(conn.GetRowCount() <= 0)
				{
					conn.QueryString = " select top 1 * from application where ap_regno='" + Request.QueryString["curef"] + "C'";
					conn.ExecuteQuery();
				}
				string temp_bookingbranch = conn.GetFieldValue("ap_bookingbranch");
				string temp_ccobranch = conn.GetFieldValue("ap_ccobranch");
				string temp_srccode = conn.GetFieldValue("ap_srccode");
				string temp_srcname = conn.GetFieldValue("ap_srcname");
				string temp_grsalescurr = conn.GetFieldValue("ap_grosssalescurr");
				string temp_progcode = conn.GetFieldValue("prog_code");
				string temp_businessunit = conn.GetFieldValue("ap_businessunit");
				temp_areaid.Text = conn.GetFieldValue("areaid");
				temp_branchcode.Text = conn.GetFieldValue("branch_code");
				temp_userid.Text = conn.GetFieldValue("ap_username");
				string temp_channelcode = conn.GetFieldValue("channel_code");
				Textbox_skbngpasar.Text=conn.GetFieldValue("ap_skbngpasar");
				Textbox_skbngminta.Text= conn.GetFieldValue("ap_skbngdiminta");
				TXT_AP_SIGNDATE_DAY.Text=tool.FormatDate_Day(conn.GetFieldValue("ap_signdate"));
				DDL_AP_SIGNDATE_MONTH.SelectedValue=tool.FormatDate_Month(conn.GetFieldValue("ap_signdate"));
				TXT_AP_SIGNDATE_YEAR.Text=tool.FormatDate_Year(conn.GetFieldValue("ap_signdate"));
				TXT_AP_RECVDATE.Text = tool.FormatDate(conn.GetFieldValue("ap_recvdate"));
				TXT_AP_GROSSSALES.Text=conn.GetFieldValue("ap_grosssales");
				LBL_AP_RELMNGR.Text = conn.GetFieldValue("ap_relmngr") ;
				//RDO_BI_CHECKING.SelectedValue = conn.GetFieldValue("ap_checkbi");

				if (RDO_BI_CHECKING.SelectedValue == "0") // No Request BI Checking
				{
					LBL_CO.Visible = false;
					DDL_GRPUNIT.Visible = false;
					DDL_GRPUNIT.CssClass = "";
				}
				else // Request BI Checking
				{
					LBL_CO.Visible = true;
					DDL_GRPUNIT.Visible = true;
					DDL_GRPUNIT.CssClass = "";
				}

				//TXT_AP_RELMNGR.Text = conn.GetFieldValue("ap_username");


                if ((conn.GetFieldValue("ap_businessunit") != "") && ((conn.GetFieldValue("ap_businessunit") == pin_small) ||
					(conn.GetFieldValue("ap_businessunit") == pin_middle) ||
					(conn.GetFieldValue("ap_businessunit") == pin_corporate) ||
					(conn.GetFieldValue("ap_businessunit") == pin_crg) ||
					(conn.GetFieldValue("ap_businessunit") == pin_micro)))
						
				{
					Label_generalinfo1.Text="Suku Bunga Pasar";
					Textbox_skbngpasar.Visible=true;
					DDL_AP_SALESAGENCY.Visible=false;
					Label_generalinfo2.Text="Suku Bunga yang diminta";
					Textbox_skbngminta.Visible=true;
					DDL_AP_SALESSUPERV.Visible=false;
					DDL_AP_SALESEXEC.Visible=false;
					TR_generalinfo3.Visible=false;
					TR_telepon.Visible=false;
					TR_koperasi.Visible=false;
					TR_anggota.Visible=false;
					TR_sektor.Visible=true;
				}
				else
				{
					Label_generalinfo1.Text="Nama Sales Agency";
					Textbox_skbngpasar.Visible=false;
					DDL_AP_SALESAGENCY.Visible=true;
					Label_generalinfo2.Text="Nama Sales Supervisor";
					Textbox_skbngminta.Visible=false;
					DDL_AP_SALESSUPERV.Visible=true;
					Label_generalinfo3.Text="Nama Sales Executive";
					DDL_AP_SALESEXEC.Visible=true;
					TR_sektor.Visible=false;
				}				
				conn.QueryString = " select top 1 * from scuser where userid='" + conn.GetFieldValue("ap_relmngr") + "'";
				conn.ExecuteQuery();
				TXT_AP_RELMNGR.Text = conn.GetFieldValue("su_fullname");
                
								
				
				//area
				conn.QueryString = "select top 1 * from rfarea where areaid= '" + temp_areaid.Text + "'";
				conn.ExecuteQuery();
				TXT_AREAID.Text = conn.GetFieldValue("areaname");
				//branch
				conn.QueryString = "select top 1 * from rfbranch where branch_code= '" + temp_branchcode.Text + "'";
				conn.ExecuteQuery();
				TXT_BRANCH_CODE.Text = conn.GetFieldValue("branch_name");
				//businessunit
				conn.QueryString = "select top 1 * from rfbusinessunit where bussunitid = '" + temp_businessunit + "'";
				conn.ExecuteQuery();
				DDL_AP_BUSINESSUNIT.Items.Add(new ListItem(conn.GetFieldValue(0,1), conn.GetFieldValue(0,0)));
				try 
				{
					DDL_AP_BUSINESSUNIT.SelectedValue = temp_businessunit;
				} 
				catch {DDL_AP_BUSINESSUNIT.SelectedValue = "";}
				//program
				GlobalTools.fillRefList(DDL_PROG_CODE, "select programid, programdesc from rfprogram where ACTIVE = '1' and areaid='" + temp_areaid.Text + "' and businessunit='" + temp_businessunit + "'", false, conn);
				try {DDL_PROG_CODE.SelectedValue=temp_progcode;}
				catch {}
				//sourcecode
				GlobalTools.fillRefList(DDL_AP_SRCCODE, "select sourcecode, sourcedesc from rfsourcecode where ACTIVE = '1' and sourcecode='" + temp_srccode + "'", false, conn);
				try {DDL_AP_SRCCODE.SelectedValue=temp_srccode;}
				catch {}
				//sourcename
				TXT_AP_SRCNAME.Text = temp_srcname;
				//channels
				GlobalTools.fillRefList(DDL_CHANNEL_CODE, "select channel_code, channel_desc from rfchannels where ACTIVE = '1' and channel_code='" + temp_channelcode + "'", false, conn);
				try {DDL_CHANNEL_CODE.SelectedValue=temp_channelcode;}
				catch {}
				
				
				
				
				
				//disable item app
				TXT_BRANCH_CODE.Enabled=false;
				TXT_AREAID.Enabled=false;
				TXT_AP_GROSSSALES.Enabled=false;
				DDL_AP_GRSALESCURR.Enabled=false;
				DDL_AP_BUSINESSUNIT.Enabled=false;
				DDL_PROG_CODE.Enabled=false;
				DDL_AP_SRCCODE.Enabled=false;
				TXT_AP_SRCNAME.Enabled=false;
				TXT_AP_SIGNDATE_DAY.Enabled=false;
				TXT_AP_SIGNDATE_YEAR.Enabled=false;
				DDL_AP_SIGNDATE_MONTH.Enabled=false;
				Textbox_skbngpasar.Enabled=false;
				Textbox_skbngminta.Enabled=false;
				DDL_CHANNEL_CODE.Enabled=false;
				RDO_RFCUSTOMERTYPE.Enabled=false;
				RDO_BI_CHECKING.Enabled=false;
				RDO_CU_PERNAHJDNASABAHBM.Enabled=false;
				DDL_GRPUNIT.Enabled=false;
				//disable item customer

			}
		}

		private void ViewDataVisited()
		{
			try 
			{
				conn.QueryString = "select * from APPLICATION where AP_REGNO = '" + TXT_AP_REGNO.Text + "'";
				conn.ExecuteQuery();

				if(conn.GetRowCount() <= 0)
				{
					conn.QueryString = "select * from APPLICATION where AP_REGNO = '" + TXT_CU_REF.Text + "C'";
					conn.ExecuteQuery();
				}

				try 
				{
					DDL_PROG_CODE.SelectedValue = conn.GetFieldValue("PROG_CODE");
				} 
				catch {DDL_PROG_CODE.SelectedValue = "";}
				DDL_PROG_CODE.Enabled = false;

				try 
				{
					DDL_AP_SRCCODE.SelectedValue = conn.GetFieldValue("AP_SRCCODE");
				} 
				catch {DDL_AP_SRCCODE.SelectedValue = "";}
				DDL_AP_SRCCODE.Enabled = false;

				TXT_AP_SRCNAME.Text = conn.GetFieldValue("AP_SRCNAME");
				TXT_AP_SRCNAME.Enabled = false;

				try 
				{
					DDL_AP_BOOKINGBRANCH.SelectedValue = conn.GetFieldValue("AP_BOOKINGBRANCH");
				} 
				catch {DDL_AP_BOOKINGBRANCH.SelectedValue = "";}
				DDL_AP_BOOKINGBRANCH.Enabled = false;

				//20070725 add by sofyan for cco branch
				try 
				{
					DDL_AP_CCOBRANCH.SelectedValue = conn.GetFieldValue("AP_CCOBRANCH");
				} 
				catch {DDL_AP_CCOBRANCH.SelectedValue = "";}
				DDL_AP_CCOBRANCH.Enabled = false;

				try 
				{
					DDL_AP_BUSINESSUNIT.SelectedValue = conn.GetFieldValue("AP_BUSINESSUNIT");
				}
				catch {DDL_AP_BUSINESSUNIT.SelectedValue = "";}
				DDL_AP_BUSINESSUNIT.Enabled = false;

				DateTime dt = Convert.ToDateTime(conn.GetFieldValue("AP_SIGNDATE"));
				GlobalTools.fillDateForm(TXT_AP_SIGNDATE_DAY, DDL_AP_SIGNDATE_MONTH, TXT_AP_SIGNDATE_YEAR, dt);
				TXT_AP_SIGNDATE_DAY.ReadOnly = true;
				DDL_AP_SIGNDATE_MONTH.Enabled = false;
				TXT_AP_SIGNDATE_YEAR.ReadOnly = true;

				RDO_RFCUSTOMERTYPE.Enabled = false;

				//--- field yang bisa diubah lagi
				try 
				{
					DDL_CHANNEL_CODE.SelectedValue = conn.GetFieldValue("CHANNEL_CODE");
				} 
				catch {DDL_CHANNEL_CODE.SelectedValue = "";}
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

		private void ViewDataSurat()
		{
			try 
			{
				conn.QueryString = "SELECT * FROM APPLICATION WHERE AP_REGNO = '" + TXT_AP_REGNO.Text + "'";
				conn.ExecuteQuery();

				TXT_SURATNSBNO.Text = conn.GetFieldValue("AP_SURATNSBNO");
				TXT_SURATNSBTGL_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("AP_SURATNSBTGL"));
				try {DDL_SURATNSBTGL_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("AP_SURATNSBTGL"));}
				catch {}
				TXT_SURATNSBTGL_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("AP_SURATNSBTGL"));
				TXT_SURATNSBTGLTRM_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("AP_SURATNSBTGLTRM"));
				try {DDL_SURATNSBTGLTRM_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("AP_SURATNSBTGLTRM"));}
				catch {}
				TXT_SURATNSBTGLTRM_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("AP_SURATNSBTGLTRM"));

				if (Request.QueryString["gi"] == "0")
				{
					TXT_SURATNSBNO.CssClass = "";
					TXT_SURATNSBTGL_DAY.CssClass = "";
					DDL_SURATNSBTGL_MONTH.CssClass = "";
					TXT_SURATNSBTGL_YEAR.CssClass = "";
					TXT_SURATNSBTGLTRM_DAY.CssClass = "";
					DDL_SURATNSBTGLTRM_MONTH.CssClass = "";
					TXT_SURATNSBTGLTRM_YEAR.CssClass = "";
				}
			}
			catch{}
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			/* 2017-10-25 Bank Papua
            if (Request.QueryString["gi"] == "" || Request.QueryString["gi"] == null)
				if (!CheckDocument())
				{
					GlobalTools.popMessage(this, "Please upload document first!");
					return;
				}
            */
			
			string curef = TXT_CU_REF.Text;
			
			Int64 signDate = Int64.Parse(Tools.toISODate(TXT_AP_SIGNDATE_DAY, DDL_AP_SIGNDATE_MONTH, TXT_AP_SIGNDATE_YEAR)),
				now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())),
				compEstablish, personalEstablish;

			/* Check Existing Customer or Not */
			if (Request.QueryString["exist"] == "0")
			{
				if (RDO_RFCUSTOMERTYPE.SelectedValue == "01")
				{
					//conn.QueryString = "select count (*) from customer left join cust_company on customer.cu_ref = cust_company.cu_ref where cu_npwp = '" + TXT_CU_COMPNPWP.Text + "' and customer.CU_REF <> '" + TXT_CU_REF.Text + "' and cu_compname like '%" + TXT_CU_COMPNAME.Text.Trim() + "%'";
					conn.QueryString = "select count (*) from customer where cu_npwp = '" + TXT_CU_COMPNPWP.Text + "' and customer.CU_REF <> '" + TXT_CU_REF.Text + "'";
					conn.ExecuteQuery();
					if (conn.GetFieldValue(0,0) != "0")
					{
						GlobalTools.popMessage(this, "Customer with NPWP: " + TXT_CU_COMPNPWP.Text + " exists in the system!");
						return;
					}
				}
				else
				{
					//--- modif by Yudi (2004/09/17) ---
					//conn.QueryString = "select count (*) from cust_personal where CU_IDCARDNUM='" + TXT_CU_IDCARDNUM.Text + "'";
					string TGL_KTP = GlobalTools.ToSQLDate(TXT_CU_IDCARDEXP_DAY.Text.Trim(), DDL_CU_IDCARDEXP_MONTH.SelectedValue, TXT_CU_IDCARDEXP_YEAR.Text.Trim());										
					conn.QueryString = "select count (*) from cust_personal where CU_IDCARDNUM='" + TXT_CU_IDCARDNUM.Text + "' and CU_IDCARDEXP = " + TGL_KTP + " and CU_REF <> '" + TXT_CU_REF.Text + "'";
					//----------------------------------
					conn.ExecuteQuery();
					if (conn.GetFieldValue(0,0) != "0")
					{
						GlobalTools.popMessage(this, "Customer with KTP: " + TXT_CU_IDCARDNUM.Text + " and Expire Date: " + TGL_KTP.Replace("'","") + " exists in the system!");
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
			
			//--- Validasi Jenis Badan Usaha vs Program
			try 
			{				
				string CU_JNSNASABAH;

				//TODO : Sedikit hardcode nih ...
				if (RDO_RFCUSTOMERTYPE.SelectedValue == "01") //badan usaha
					CU_JNSNASABAH = DDL_CU_JNSNASABAH.SelectedValue;				
				else
					CU_JNSNASABAH = "A";	

				conn.QueryString = "select LG_CODE from RFCAFINSTATEMENT where " +
					"PROGRAMID = '" + DDL_PROG_CODE.SelectedValue + "' and " + 
					"AREAID = '" + (string) Session["AreaID"] + "' and " +
					"NASABAHID = '" + CU_JNSNASABAH + "'";				
				conn.ExecuteQuery();

				if (conn.GetFieldValue("LG_CODE") == "" || conn.GetFieldValue("LG_CODE") == null) 
				{
					GlobalTools.popMessage(this, "Program yang dipilih tidak sesuai dengan Jenis Badan Usaha !");
					return;
				}
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return;
			}			


			/////////////////////////////////////////////////////////////////////
			///	BADAN USAHA
			///			
			if (RDO_RFCUSTOMERTYPE.SelectedValue == "01")	// badan usaha
			{
				////////////////////////////////////////////////////////////
				///	VALIDASI BERDIRI SEJAK
				///	
				if (int.Parse(DDL_CU_COMPESTABLISHMM.SelectedValue) > 12)
				{
					GlobalTools.popMessage(this, "Berdiri Sejak (MM) tidak valid");
					return;
				}
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

				//////////////////////////////////////////////////////////////////////
				///	VALIDASI TANGGAL APLIKASI
				///	
				if (!GlobalTools.isDateValid(TXT_AP_SIGNDATE_DAY.Text, DDL_AP_SIGNDATE_MONTH.SelectedValue, TXT_AP_SIGNDATE_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Aplikasi tidak valid!");
					return;
				}

				//////////////////////////////////////////////////////////////
				///	VALIDASI TANGGAL ISSUANCE
				///	
				if (TXT_CU_COMPTGASURANSI_DAY.Text != "" && DDL_CU_TGASURANSI_MONTH.SelectedValue != "" && TXT_CU_COMPTGASURANSI_YEAR.Text != "") 
				{
					if (!GlobalTools.isDateValid(TXT_CU_COMPTGASURANSI_DAY.Text, DDL_CU_TGASURANSI_MONTH.SelectedValue, TXT_CU_COMPTGASURANSI_YEAR.Text)) 
					{
						GlobalTools.popMessage(this, "Tanggal Issuance tidak valid!");
						return;
					}
				}
				

				/////////////////////////////////////////////////////////////////////
				///	VALIDASI TANGGAL JATUH TEMPO
				///	
				if (TXT_CU_TGLJATUHTEMPO_DAY.Text != "" && DDL_CU_TGLJATUHTEMPO_MONTH.SelectedValue != "" && TXT_CU_TGLJATUHTEMPO_YEAR.Text != "") 
				{
					if (!GlobalTools.isDateValid(TXT_CU_TGLJATUHTEMPO_DAY.Text, DDL_CU_TGLJATUHTEMPO_MONTH.SelectedValue, TXT_CU_TGLJATUHTEMPO_YEAR.Text)) 
					{
						GlobalTools.popMessage(this, "Tanggal Jatuh Tempo tidak valid!");
						return;
					}
				}
				

				////////////////////////////////////////////////////////////////////////
				///	VALIDASI TANGGAL PENERBITAN
				///	
				if (TXT_CU_TGLTERBIT_DAY.Text != "" && DDL_CU_TGLTERBIT_MONTH.SelectedValue != "" && TXT_CU_TGLTERBIT_YEAR.Text != "") 
				{
					if (!GlobalTools.isDateValid(TXT_CU_TGLTERBIT_DAY.Text, DDL_CU_TGLTERBIT_MONTH.SelectedValue, TXT_CU_TGLTERBIT_YEAR.Text)) 
					{
						GlobalTools.popMessage(this, "Tanggal Penerbitan tidak valid!");
						return;
					}
				}
				

				try 
				{
					conn.QueryString = "exec IDE_GENINFO_COMP_INSERT '" + 
						Request.QueryString["regno"] + "', '" + 
						TXT_CU_REF.Text + "', '" +
						//Session["AreaID"].ToString() + "', '" +
						temp_areaid.Text + "', '" +
						DDL_PROG_CODE.SelectedValue + "', '" +
						//Session["BranchID"].ToString() + "', '" + 
						temp_branchcode.Text + "', '" + 
						LBL_AP_RELMNGR.Text + "', " + 
						tool.ConvertNull(DDL_CHANNEL_CODE.SelectedValue) + ", '" + 
						DDL_AP_SRCCODE.SelectedValue + "', " + 
						tool.ConvertFloat(TXT_AP_GROSSSALES.Text) + ", " + 
						tool.ConvertDate(TXT_AP_SIGNDATE_DAY.Text, DDL_AP_SIGNDATE_MONTH.SelectedValue, TXT_AP_SIGNDATE_YEAR.Text) + ", " +
						tool.ConvertNull(DDL_AP_SALESAGENCY.SelectedValue) + ", " + 
						tool.ConvertNull(DDL_AP_SALESSUPERV.SelectedValue) + ", " + 
						tool.ConvertNull(DDL_AP_SALESEXEC.SelectedValue) + ", '" +					
						//Session["UserID"].ToString() + "', '" + 
						temp_userid.Text + "', '" + 
						RDO_RFCUSTOMERTYPE.SelectedValue + "', '" +
						TXT_CU_CIF_C.Text + "', '" + DDL_CU_COMPTYPE.SelectedValue + "', '" +
						TXT_CU_COMPNAME.Text + "', '" + 
						TXT_CU_COMPADDR1.Text + "', '" + TXT_CU_COMPADDR2.Text + "', '" + TXT_CU_COMPADDR3.Text + "', '" + 
						LBL_CU_COMPCITY.Text + "', '" + TXT_CU_COMPZIPCODE.Text + "', '" +
						DDL_CU_COMPBUSSTYPE.SelectedValue + "', " + 
						tool.ConvertDate(TXT_CU_COMPESTABLISHDD.Text,DDL_CU_COMPESTABLISHMM.SelectedValue,TXT_CU_COMPESTABLISHYY.Text) + ", '" +
						TXT_CU_COMPPHNAREA.Text + "', '" + TXT_CU_COMPPHNNUM.Text + "', '" + 
						TXT_CU_COMPPHNEXT.Text + "', '" +
						TXT_CU_COMPFAXAREA.Text + "', '" + TXT_CU_COMPFAXNUM.Text + "', '" + 
						TXT_CU_COMPFAXEXT.Text + "', '" + 
						TXT_CU_COMPNPWP.Text + "', '" + TXT_CU_CONTACTPERSON.Text + "', '" +
						TXT_CU_CONTACTPHNAREA.Text + "', '" + TXT_CU_CONTACTPHNNUM.Text + "', '" + 
						TXT_CU_CONTACTPHNEXT.Text + "', '" + 
						RDO_BI_CHECKING.SelectedValue + "', '0', " + tool.ConvertNull(TXT_CU_COMPEMPLOYEE.Text.Trim()) + ", " + 
						tool.ConvertNull(DDL_JNSALAMAT_C.SelectedValue) + ", '" + 
						TXT_CU_TDP.Text + "', "
						+ tool.ConvertNull(DDL_CU_JNSNASABAH.SelectedValue) + ", '" + 
						DDL_AP_BUSINESSUNIT.SelectedValue + "', '" + 
						DDL_AP_BOOKINGBRANCH.SelectedValue + "', null, '" + 
						RDO_CU_PERNAHJDNASABAHBM.SelectedValue + "', " + 
						tool.ConvertNull(TXT_CU_COMPAKTAPENDIRIAN.Text.Trim()) + ", '" + 
						DDL_GRPUNIT.SelectedValue + "', '" + DDL_AP_GRSALESCURR.SelectedValue + "', '" + DDL_AP_CCOBRANCH.SelectedValue + "', " +
						//pipeline
						tool.ConvertFloat(Textbox_skbngpasar.Text) + ", " + tool.ConvertFloat(Textbox_skbngminta.Text) + ", '" + 
						DDL_groupnasabah.Text + "', '" +
						DDL_bmsektor.SelectedValue + "', '" +
                        TXT_bmsubsektor.Text + "', '" + //DDL_bmsubsektor.SelectedValue + "', '" + //BankPapua20171118
                        TXT_bmsubsubsektor.Text + "', " + //DDL_bmsubsubsektor.SelectedValue + "', " + //BankPapua20171118
						tool.ConvertFloat(Textbox_netincome.Text) + ", " +
						tool.ConvertFloat(Textbox_pendapatanoperasional.Text) + ", " +
						tool.ConvertFloat(Textbox_pendapatannon.Text) + ", '" +
						Textbox_keyperson.Text  + "', '" + 
						DDL_lokasiproyek.SelectedValue + "', '" +
						TXT_CU_COMPPOB.Text + "', '" +
						TXT_AP_SRCNAME.Text + "', '" +
						DDL_CU_LOKASIDATI2.SelectedValue + "', '" +
						DDL_CU_HUBEXECBM.SelectedValue + "', '" +
						DDL_CU_HUBKELBM.SelectedValue + "', '" +
						TXT_CU_COMPAKTATERAKHIR_NO.Text + "', " +
						tool.ConvertDate(TXT_CU_COMPAKTATERAKHIR_DATE_DAY.Text, DDL_CU_COMPAKTATERAKHIR_DATE_MONTH.SelectedValue, TXT_CU_COMPAKTATERAKHIR_DATE_YEAR.Text) + ", '" +
						DDL_CU_COMPEXTRATING_BY.SelectedValue + "', '" +
						DDL_CU_COMPEXTRATING_CLASS.SelectedValue + "', " +
						tool.ConvertDate(TXT_CU_COMPEXTRATING_DATE_DAY.Text, DDL_CU_COMPEXTRATING_DATE_MONTH.SelectedValue, TXT_CU_COMPEXTRATING_DATE_YEAR.Text) + ", '" +
						DDL_CU_COMPLISTINGCODE.SelectedValue + "', " +
						tool.ConvertDate(TXT_CU_COMPLISTINGDATE_DAY.Text, DDL_CU_COMPLISTINGDATE_MONTH.SelectedValue, TXT_CU_COMPLISTINGDATE_YEAR.Text) + ", '" +
						TXT_SURATNSBNO.Text + "', " +
						tool.ConvertDate(TXT_SURATNSBTGL_DAY.Text, DDL_SURATNSBTGL_MONTH.SelectedValue, TXT_SURATNSBTGL_YEAR.Text) + ", " +
						tool.ConvertDate(TXT_SURATNSBTGLTRM_DAY.Text, DDL_SURATNSBTGLTRM_MONTH.SelectedValue, TXT_SURATNSBTGLTRM_YEAR.Text);
					conn.ExecuteNonQuery();

					//--- untuk memecah kebanyakan argumen
					conn.QueryString = "exec IDE_GENINFO_COMP_INSERT2 '" + 
						curef + "', " + 
						tool.ConvertDate(TXT_CU_COMPTGASURANSI_DAY.Text,DDL_CU_TGASURANSI_MONTH.SelectedValue, TXT_CU_COMPTGASURANSI_YEAR.Text) + ", " + // tanggal issuance
						tool.ConvertDate(TXT_CU_TGLJATUHTEMPO_DAY.Text, DDL_CU_TGLJATUHTEMPO_MONTH.SelectedValue, TXT_CU_TGLJATUHTEMPO_YEAR.Text) + ", " + // tanggal jatuh tempo
						tool.ConvertDate(TXT_CU_TGLTERBIT_DAY.Text, DDL_CU_TGLTERBIT_MONTH.SelectedValue, TXT_CU_TGLTERBIT_YEAR.Text) + ", " + // tgl penerbitan
						tool.ConvertNull(TXT_CU_COMPNOTARYNAME.Text.Trim()) + ", " + // nama notaris
						tool.ConvertNull(TXT_CU_COMPANGGOTA.Text.Trim());
					conn.ExecuteNonQuery();
				} 
				catch (NullReferenceException)
				{
					GlobalTools.popMessage(this, "Connection Error!");
					Response.Redirect("../Login.aspx?expire=1");
				}
//				catch 
//				{
//					GlobalTools.popMessage(this, "Cek Tanggal keluar batas atau Invalid Character di Input Fields!");
//					return;
//				}
			}
				///////////////////////////////////////////////////////////////////////
				/// PERORANGAN
				/// 
			else	
			{
				//////////////////////////////////////////////////////////////
				///	VALIDASI BERDIRI SEJAK
				///	
                // Bank Papua 20171003
                if ((TXT_CU_ESTABLISHDD.Text != "") || (DDL_CU_ESTABLISHMM.SelectedValue != "") || (TXT_CU_ESTABLISHYY.Text != ""))
                {
                    if (int.Parse(DDL_CU_ESTABLISHMM.SelectedValue) > 12)
                    {
                        GlobalTools.popMessage(this, "Berdiri Sejak (MM) tidak valid");
                        return;
                    }
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
                }
                else
                {

                }

				//////////////////////////////////////////////////////////////////
				/// VALIDASI TANGGAL LAHIR
				/// 
				if (!GlobalTools.isDateValid(TXT_CU_DOB_DAY.Text, DDL_CU_DOB_MONTH.SelectedValue, TXT_CU_DOB_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Lahir tidak valid!");
					return;
				}
				else 
				{
					Int64 tanggalLahir;
					tanggalLahir = Int64.Parse(Tools.toISODate(TXT_CU_DOB_DAY.Text, DDL_CU_DOB_MONTH.SelectedValue, TXT_CU_DOB_YEAR.Text));

					if (tanggalLahir > now) 
					{
						GlobalTools.popMessage(this, "DOB cannot be greater than current date!!");
						return;
					}
				}


				////////////////////////////////////////////////////////////////////
				/// VALIDASI MULAI MENETAP
				/// 
                // Bank Papua 20171003
                if ((TXT_CU_MULAIMENETAPMM.Text != "") || (TXT_CU_MULAIMENETAPYY.Text != ""))
                {
                    if (!GlobalTools.isDateValid("1", TXT_CU_MULAIMENETAPMM.Text, TXT_CU_MULAIMENETAPYY.Text)) 
				    {
					    GlobalTools.popMessage(this, "Mulai Menetap tidak valid!");
					    return;
				    }
                }
				


				////////////////////////////////////////////////////////////////////
				///	VALIDASI TANGGAL BERAKHIR KTP
				///	
				if (!GlobalTools.isDateValid(TXT_CU_IDCARDEXP_DAY.Text, DDL_CU_IDCARDEXP_MONTH.SelectedValue, TXT_CU_IDCARDEXP_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Berakhir KTP tidak valid!");
					return;
				}

				int banding = Tools.compareDate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), TXT_CU_IDCARDEXP_DAY.Text, DDL_CU_IDCARDEXP_MONTH.SelectedValue, TXT_CU_IDCARDEXP_YEAR.Text);
				if (banding >= 0) 
				{
					GlobalTools.popMessage(this, "Tanggal Berakhir KTP tidak boleh kurang dari tanggal sekarang!");
					return;
				}

				////////////////////////////////////////////////////////////////////
				///	VALIDASI TANGGAL BERAKHIR KTP SPOUSE
				///	
				if (TXT_CU_SPOUSE_KTPEXPDATE_DAY.Text != "" && DDL_CU_SPOUSE_KTPEXPDATE_MONTH.SelectedValue != "" && TXT_CU_SPOUSE_KTPEXPDATE_YEAR.Text != "") 
				{
					if (!GlobalTools.isDateValid(TXT_CU_SPOUSE_KTPEXPDATE_DAY.Text, DDL_CU_SPOUSE_KTPEXPDATE_MONTH.SelectedValue, TXT_CU_SPOUSE_KTPEXPDATE_YEAR.Text)) 
					{
						GlobalTools.popMessage(this, "Tanggal Berakhir KTP Spouse tidak valid!");
						return;
					}
				}
				banding = Tools.compareDate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), TXT_CU_SPOUSE_KTPEXPDATE_DAY.Text, DDL_CU_SPOUSE_KTPEXPDATE_MONTH.SelectedValue, TXT_CU_SPOUSE_KTPEXPDATE_YEAR.Text);
				if (banding >= 0) 
				{
					GlobalTools.popMessage(this, "Tanggal Berakhir KTP Spouse tidak boleh kurang dari tanggal sekarang!");
					return;
				}
				
				////////////////////////////////////////////////////////////////////
				///	VALIDASI TANGGAL ISSUANCE KTP
				///	
				if (TXT_CU_SPOUSE_KTPISSUEDATE_DAY.Text != "" && DDL_CU_SPOUSE_KTPISSUEDATE_MONTH.SelectedValue != "" && TXT_CU_SPOUSE_KTPISSUEDATE_YEAR.Text != "") 
				{
					if (!GlobalTools.isDateValid(TXT_CU_SPOUSE_KTPISSUEDATE_DAY.Text, DDL_CU_SPOUSE_KTPISSUEDATE_MONTH.SelectedValue, TXT_CU_SPOUSE_KTPISSUEDATE_YEAR.Text)) 
					{
						GlobalTools.popMessage(this, "Tanggal Issuance KTP Spouse tidak valid!");
						return;
					}
				}				

				try 
				{
					conn.QueryString = "exec IDE_GENINFO_PERSON_INSERT '" + 
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
						tool.ConvertDate(TXT_CU_ESTABLISHDD.Text, DDL_CU_ESTABLISHMM.SelectedValue, TXT_CU_ESTABLISHYY.Text) + ", '" + TXT_CU_NPWP.Text + "', '" + 
						DDL_CU_CITIZENSHIP.SelectedValue + "', '" + 
						RDO_BI_CHECKING.SelectedValue + "', '0', " + 
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
						tool.ConvertNull(DDL_CU_JNSNASABAH_P.SelectedValue) + ", null, '" + 
						RDO_CU_PERNAHJDNASABAHBM.SelectedValue + "', '" + 
						DDL_GRPUNIT.SelectedValue + "', " + DDL_AP_GRSALESCURR.SelectedValue + ", '"+
						TXT_CU_TITLEBEFORENAME.Text+"', '" + DDL_AP_CCOBRANCH.SelectedValue + "','"+
						TXT_CU_MOTHER.Text+"',"+
						//pipeline
						tool.ConvertFloat(Textbox_skbngpasar.Text) + ", " + tool.ConvertFloat(Textbox_skbngminta.Text) + ", '" + 
						DDL_groupnasabah.Text + "', '" +
						DDL_bmsektor.SelectedValue + "', '" +
                        TXT_bmsubsektor.Text + "', '" + //DDL_bmsubsektor.SelectedValue + "', '" + //BankPapua20171118
                        TXT_bmsubsubsektor.Text + "', " + //DDL_bmsubsubsektor.SelectedValue + "', " + //BankPapua20171118
						tool.ConvertFloat(Textbox_netincome.Text) + ", " +
						tool.ConvertFloat(Textbox_pendapatanoperasional.Text) + ", " +
						tool.ConvertFloat(Textbox_pendapatannon.Text) + ", '" +
						Textbox_keyperson.Text  + "', '" + 
						DDL_lokasiproyek.SelectedValue + "', '" +
						TXT_AP_SRCNAME.Text + "', '" +
						DDL_CU_LOKASIDATI2.SelectedValue + "', '" +
						DDL_CU_HUBEXECBM.SelectedValue + "', '" +
						DDL_CU_HUBKELBM.SelectedValue + "', '" +
						TXT_CU_NAMAPELAPORAN.Text + "', '" +
						TXT_CU_ALIASNAME.Text + "', '" +
						DDL_CU_NEGARADOMISILI.SelectedValue + "', '" +
						TXT_SURATNSBNO.Text + "', " +
						tool.ConvertDate(TXT_SURATNSBTGL_DAY.Text, DDL_SURATNSBTGL_MONTH.SelectedValue, TXT_SURATNSBTGL_YEAR.Text) + ", " +
						tool.ConvertDate(TXT_SURATNSBTGLTRM_DAY.Text, DDL_SURATNSBTGLTRM_MONTH.SelectedValue, TXT_SURATNSBTGLTRM_YEAR.Text) + ", '" +
                        TXT_CU_TEMPATKERJA.Text + "', '" +
                        DDL_CU_KODEINSTANSI.SelectedValue + "', '" +
                        TXT_CU_NOPEGAWAI.Text + "'";
						conn.ExecuteNonQuery();

					//--- untuk memecah kebanyak argumen
					conn.QueryString = "exec IDE_GENINFO_PERSON_INSERT2 '" + TXT_CU_REF.Text + "', " + 
							tool.ConvertNull(DDL_CU_HOMESTA.SelectedValue) + ", " + 
							tool.ConvertNull(TXT_CU_MULAIMENETAPMM.Text) + ", " + 
							tool.ConvertNull(TXT_CU_MULAIMENETAPYY.Text) + ", " +
							tool.ConvertNull(TXT_CU_EMPLOYEE.Text.Trim()) + "";
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
					Response.Redirect("../Login.aspx?expire=1");
				}
//				catch 
//				{
//					GlobalTools.popMessage(this, "Cek Tanggal keluar batas atau Invalid Character di Input Fields!");
//					return;
//				}
			}

			/////////////////////////////////////////////////////////////////
			/// store procedure audittrail dipisah karena di pakai
			/// di initial data entry
			/// 
	
			//ahmad

			try 
			{
				/// Program
				/// 
				conn.QueryString = "SP_AUDITTRAIL_APP '" + 
					Request.QueryString["regno"] + "',null,null,null,'" + 
					TXT_CU_REF.Text + "','" + 
					Request.QueryString["tc"] + "','" + TXT_AUDITDESC_PROG.Text +DDL_PROG_CODE.SelectedItem.Text+ "' , '"+ 
					DDL_PROG_CODE.SelectedItem.Text + "','" +  
					LBL_AP_RELMNGR.Text + "',null,null";
				conn.ExecTrans();


				/// BI Checking
				/// 

				if (RDO_BI_CHECKING.SelectedIndex == 0)
				{

					conn.QueryString = "SP_AUDITTRAIL_APP '" + 
						Request.QueryString["regno"] + "',null,null,null,'" + 
						TXT_CU_REF.Text + "','" + 
						Request.QueryString["tc"] + "','" + TXT_AUDITDESC_BICHECK.Text + DDL_GRPUNIT.SelectedItem.Text + "','"+ 
						DDL_GRPUNIT.SelectedItem.Text + "','" +  
						LBL_AP_RELMNGR.Text + "',null,null";
					conn.ExecTrans();
				}


				conn.ExecTran_Commit();
			} 
			catch 
			{
				if (conn != null)
					conn.ExecTran_Rollback();
			}

			if (Request.QueryString["sta"] != "prev")
			{
				if (temp_grpunit.Text !="CO")
				    Response.Redirect("InfoPerusahaan.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&prog=" + DDL_PROG_CODE.SelectedValue + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&exist=" + Request.QueryString["exist"]);
				//else
				//{
					//ViewMenu();
				//{
			}
			//if (temp_grpunit.Text =="CO")
			//	ViewMenu();
		}

		private void ClearEntries()
		{
			DDL_PROG_CODE.SelectedValue = "";
			DDL_CHANNEL_CODE.SelectedValue = "";
			//TXT_AP_SRCCODE.Text = "";
			DDL_AP_SRCCODE.SelectedValue = "";
			TXT_AP_SRCNAME.Text = "";
			TXT_AP_GROSSSALES.Text = "";
			//TXT_GR_BUSINESSUNIT.Text = "";
			TXT_AP_SIGNDATE_DAY.Text = "";
			DDL_AP_SIGNDATE_MONTH.SelectedValue = "";
			TXT_AP_SIGNDATE_YEAR.Text = "";
			DDL_AP_SALESAGENCY.SelectedValue = "";
			DDL_AP_SALESEXEC.SelectedValue = "";
			DDL_AP_SALESSUPERV.SelectedValue = "";
			DDL_CU_LOKASIDATI2.SelectedValue = "";
			DDL_CU_HUBEXECBM.SelectedValue = "";
			DDL_CU_HUBKELBM.SelectedValue = "";
			TXT_SURATNSBNO.Text = "";
			TXT_SURATNSBTGL_DAY.Text = "";
			DDL_SURATNSBTGL_MONTH.SelectedValue = "";
			TXT_SURATNSBTGL_YEAR.Text = "";
			TXT_SURATNSBTGLTRM_DAY.Text = "";
			DDL_SURATNSBTGLTRM_MONTH.SelectedValue = "";
			TXT_SURATNSBTGLTRM_YEAR.Text = "";
			
			if (RDO_RFCUSTOMERTYPE.SelectedValue == "02")
			{
				TXT_CU_CIF_P.Text = "";
				TXT_CU_TITLEBEFORENAME.Text = "";
				TXT_CU_FIRSTNAME.Text = "";
				TXT_CU_MIDDLENAME.Text = "";
				TXT_CU_LASTNAME.Text = "";
				TXT_CU_ADDR1.Text = "";
				TXT_CU_ADDR2.Text = "";
				TXT_CU_ADDR3.Text = "";
				TXT_CU_CITY.Text = "";
				LBL_CU_CITY.Text = "";
				TXT_CU_ZIPCODE.Text = "";
				TXT_CU_PHNAREA.Text = "";
				TXT_CU_PHNNUM.Text = "";
				TXT_CU_PHNEXT.Text = "";
				TXT_CU_FAXAREA.Text = "";
				TXT_CU_FAXNUM.Text = "";
				TXT_CU_FAXEXT.Text = "";
				TXT_CU_POB.Text = "";
				TXT_CU_DOB_DAY.Text = "";
				DDL_CU_DOB_MONTH.SelectedValue = "";
				TXT_CU_DOB_YEAR.Text = "";
				DDL_CU_MARITAL.SelectedValue = "";
				DDL_CU_SEX.SelectedValue = "";
				TXT_CU_IDCARDNUM.Text = "";
				TXT_CU_IDCARDEXP_DAY.Text = "";
				DDL_CU_IDCARDEXP_MONTH.SelectedValue = "";
				TXT_CU_IDCARDEXP_YEAR.Text = "";
				DDL_CU_JOBTITLE.SelectedValue = "";
				DDL_CU_BUSSTYPE.SelectedValue = "";
				TXT_CU_ESTABLISHDD.Text = "";
				DDL_CU_ESTABLISHMM.SelectedValue = "";
				TXT_CU_ESTABLISHYY.Text = "";
				TXT_CU_NPWP.Text = "";
				DDL_CU_CITIZENSHIP.SelectedValue = "";
				TXT_CU_MOTHER.Text = "";
				DDL_bmsektor.SelectedValue="";
				DDL_bmsubsektor.SelectedValue="";
				DDL_bmsubsubsektor.SelectedValue="";
				Textbox_skbngpasar.Text="";
				Textbox_skbngminta.Text="";
				DDL_groupnasabah.Text="";
				Textbox_netincome.Text="";
				Textbox_pendapatanoperasional.Text="";
				Textbox_pendapatannon.Text="";
				DDL_lokasiproyek.SelectedValue="";
				Textbox_keyperson.Text="";
				TXT_CU_NAMAPELAPORAN.Text = "";
				TXT_CU_ALIASNAME.Text = "";
				DDL_CU_NEGARADOMISILI.SelectedValue = "";
                TXT_CU_TEMPATKERJA.Text = "";
                DDL_CU_KODEINSTANSI.SelectedValue = "";
                TXT_CU_NOPEGAWAI.Text = "";
			}
			else if (RDO_RFCUSTOMERTYPE.SelectedValue == "01")
			{
				TXT_CU_CIF_C.Text = "";
				DDL_CU_COMPTYPE.SelectedValue = "";
				TXT_CU_COMPNAME.Text = "";
				TXT_CU_COMPADDR1.Text = "";
				TXT_CU_COMPADDR2.Text = "";
				TXT_CU_COMPADDR3.Text = "";
				TXT_CU_COMPCITY.Text = "";
				LBL_CU_COMPCITY.Text = "";
				TXT_CU_COMPZIPCODE.Text = "";
				DDL_CU_COMPBUSSTYPE.SelectedValue = "";
				TXT_CU_COMPESTABLISHDD.Text = "";
				DDL_CU_COMPESTABLISHMM.SelectedValue = "";
				TXT_CU_COMPESTABLISHYY.Text = "";
				TXT_CU_COMPPHNAREA.Text = "";
				TXT_CU_COMPPHNNUM.Text = "";
				TXT_CU_COMPPHNEXT.Text = "";
				TXT_CU_COMPFAXAREA.Text = "";
				TXT_CU_COMPFAXNUM.Text = "";
				TXT_CU_COMPFAXEXT.Text = "";
				TXT_CU_COMPNPWP.Text = "";
				TXT_CU_CONTACTPERSON.Text = "";
				TXT_CU_CONTACTPHNAREA.Text = "";
				TXT_CU_CONTACTPHNNUM.Text = "";
				TXT_CU_CONTACTPHNEXT.Text = "";
				DDL_bmsektor.SelectedValue="";
				DDL_bmsubsektor.SelectedValue="";
				DDL_bmsubsubsektor.SelectedValue="";
				Textbox_skbngpasar.Text="";
				Textbox_skbngminta.Text="";
				DDL_groupnasabah.Text="";
				Textbox_netincome.Text="";
				Textbox_pendapatanoperasional.Text="";
				Textbox_pendapatannon.Text="";
				DDL_lokasiproyek.SelectedValue="";
				Textbox_keyperson.Text="";
				TXT_CU_COMPPOB.Text = "";
				TXT_CU_COMPAKTATERAKHIR_NO.Text = "";
				TXT_CU_COMPAKTATERAKHIR_DATE_DAY.Text = "";
				DDL_CU_COMPAKTATERAKHIR_DATE_MONTH.SelectedValue = "";
				TXT_CU_COMPAKTATERAKHIR_DATE_YEAR.Text = "";
				DDL_CU_COMPEXTRATING_BY.SelectedValue = "";
				DDL_CU_COMPEXTRATING_CLASS.SelectedValue = "";
				TXT_CU_COMPEXTRATING_DATE_DAY.Text = "";
				DDL_CU_COMPEXTRATING_DATE_MONTH.SelectedValue = "";
				TXT_CU_COMPEXTRATING_DATE_YEAR.Text = "";
				DDL_CU_COMPLISTINGCODE.SelectedValue = "";
				TXT_CU_COMPLISTINGDATE_DAY.Text = "";
				DDL_CU_COMPLISTINGDATE_MONTH.SelectedValue = "";
				TXT_CU_COMPLISTINGDATE_YEAR.Text = "";
			}
		}

		protected void DDL_AP_BUSINESSUNIT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DDL_PROG_CODE.Items.Clear();
			DDL_PROG_CODE.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select programid, programdesc from rfprogram where areaid='" + Session["AreaID"].ToString() + 
								"' and active='1' and businessunit='" + DDL_AP_BUSINESSUNIT.SelectedValue + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_PROG_CODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		protected void DDL_AP_SALESAGENCY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DDL_AP_SALESEXEC.Items.Clear();
			DDL_AP_SALESEXEC.Items.Add(new ListItem("- PILIH -", ""));
			DDL_AP_SALESSUPERV.Items.Clear();
			DDL_AP_SALESSUPERV.Items.Add(new ListItem("- PILIH -", ""));
			
			conn.QueryString = "select seq, ag_officer from rfagencyuser where agencyid='" + DDL_AP_SALESAGENCY.SelectedValue + "' and active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_AP_SALESEXEC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				DDL_AP_SALESSUPERV.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		protected void BTN_SEARCHPERSONAL_Click(object sender, System.EventArgs e)
		{
            /* 2017-11-08 Bank Papua
			Response.Write("<script language='javascript'>window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_ZIPCODE','SearchZipcode','status=no,scrollbars=no,width=640,height=480');</script>");
            */
            Response.Write("<script language='javascript'>window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_ZIPCODE&trgObjID2=TXT_CU_ADDR3&trgObjID3=TXT_CU_CITY&trgObjID4=LBL_CU_CITY','SearchZipcode','status=no,scrollbars=no,width=640,height=480');</script>");
		}

		protected void BTN_SEARCHCOMP_Click(object sender, System.EventArgs e)
		{
            /* 2017-11-08 Bank Papua
			Response.Write("<script language='javascript'>window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_COMPZIPCODE','SearchZipcode','status=no,scrollbars=no,width=640,height=480');</script>");
            */
            Response.Write("<script language='javascript'>window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_COMPZIPCODE&trgObjID2=TXT_CU_COMPADDR3&trgObjID3=TXT_CU_COMPCITY&trgObjID4=LBL_CU_COMPCITY','SearchZipcode','status=no,scrollbars=no,width=640,height=480');</script>");
		}

		protected void BTN_SEARCHKTPZIP_Click(object sender, System.EventArgs e)
		{
            /* 2017-11-08 Bank Papua
			Response.Write("<script language='javascript'>window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_KTPZIPCODE','SearchZipcode','status=no,scrollbars=no,width=640,height=480');</script>");
            */
            Response.Write("<script language='javascript'>window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_KTPZIPCODE&trgObjID2=TXT_CU_KTPADDR3&trgObjID3=TXT_CU_KTPCITY&trgObjID4=LBL_CU_KTPCITY','SearchZipcode','status=no,scrollbars=no,width=640,height=480');</script>");
		}

		protected void TXT_CU_COMPZIPCODE_TextChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select cityid, cityname, description from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + 
				TXT_CU_COMPZIPCODE.Text.Trim() + "' ";
			conn.ExecuteQuery();
			try
			{
				LBL_CU_COMPCITY.Text = conn.GetFieldValue(0, 0);
				TXT_CU_COMPCITY.Text = conn.GetFieldValue(0, 1);
                TXT_CU_COMPADDR3.Text = conn.GetFieldValue(0, 2);
			}
			catch
			{
				TXT_CU_COMPZIPCODE.Text = "";
				TXT_CU_COMPCITY.Text = "";
				GlobalTools.popMessage(this, "Invalid Zipcode!");
			}
		}

		protected void TXT_CU_ZIPCODE_TextChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select cityid, cityname, description from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + 
				TXT_CU_ZIPCODE.Text.Trim() + "' ";
			conn.ExecuteQuery();
			try
			{
                LBL_CU_CITY.Text = conn.GetFieldValue(0, 0);
                TXT_CU_CITY.Text = conn.GetFieldValue(0, 1);
                TXT_CU_ADDR3.Text = conn.GetFieldValue(0, 2);
			}
			catch
			{
				TXT_CU_ZIPCODE.Text = "";
				TXT_CU_CITY.Text = "";
				GlobalTools.popMessage(this, "Invalid Zipcode!");
			}
		}

		protected void TXT_CU_KTPZIPCODE_TextChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select cityid, cityname, description from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + 
				TXT_CU_KTPZIPCODE.Text.Trim() + "' ";
			conn.ExecuteQuery();
			try
			{
				LBL_CU_KTPCITY.Text = conn.GetFieldValue(0, 0);
				TXT_CU_KTPCITY.Text = conn.GetFieldValue(0, 1);
                TXT_CU_KTPADDR3.Text = conn.GetFieldValue(0, 2);
			}
			catch
			{
				TXT_CU_KTPZIPCODE.Text = "";
				TXT_CU_KTPCITY.Text = "";
				GlobalTools.popMessage(this, "Invalid Zipcode!");
			}
		}

		protected void RDO_BI_CHECKING_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (RDO_BI_CHECKING.SelectedValue == "0") // No Request BI Checking
			{
				LBL_CO.Visible = false;
				DDL_GRPUNIT.Visible = false;
				DDL_GRPUNIT.CssClass = "";
			}
			else // Request BI Checking
			{
				LBL_CO.Visible = true;
				DDL_GRPUNIT.Visible = true;
				DDL_GRPUNIT.CssClass = "";
			}
		}

		private void LNK_KETENTUAN230_Click(object sender, System.EventArgs e)
		{
			if (temp_grpunit.Text != "CO")
			{
				Response.Write("<script for=window event=onload language='javascript'>PopupPage('Artikel230.aspx', '1000','700');</script>");
		
			}
		}
		protected void TXT_CON_TextChanged(object sender, System.EventArgs e)
		{
			Response.Redirect("../InitialDataEntry/FindCustomer.aspx?mc="+Request.QueryString["mc"]+"&tc=" + Request.QueryString["tc"]);
		}

		protected void DDL_PROG_CODE_SelectedIndexChanged(object sender, System.EventArgs e)
		{				
			//////////////////////////////////////////////
			/// TODO : Please don't hard code !!!!
			/// 			
			TXT_CU_CHILDREN.CssClass = "";
			//TXT_CU_MULAIMENETAPMM.CssClass = "";
			//TXT_CU_MULAIMENETAPYY.CssClass = "";

//			if (DDL_PROG_CODE.SelectedValue == "15" || 
//				DDL_PROG_CODE.SelectedValue == "16" || 
//				DDL_PROG_CODE.SelectedValue == "19") 
//			{
//				TXT_CU_CHILDREN.CssClass = "mandatory2";
//				TXT_CU_MULAIMENETAPMM.CssClass = "mandatory2";
//				TXT_CU_MULAIMENETAPYY.CssClass = "mandatory2";				
//			}		

			setMandatoryFI(RDO_RFCUSTOMERTYPE.SelectedValue, DDL_PROG_CODE.SelectedValue);

			Tools.SetFocus(this, DDL_PROG_CODE);
		}

		protected void CHB_CU_NAMAPELAPORAN_CheckedChanged(object sender, System.EventArgs e)
		{
			if (CHB_CU_NAMAPELAPORAN.Checked == true)
			{
				TXT_CU_NAMAPELAPORAN.Text = TXT_CU_FIRSTNAME.Text;
			}
		}

		protected void DDL_CU_COMPEXTRATING_BY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			GlobalTools.fillRefList(DDL_CU_COMPEXTRATING_CLASS, "SELECT RTGCLASS_CODE, RTGCLASS_DESC FROM RFEXTERNALRATINGCLASS WHERE RTGCOMP_CODE = '" + DDL_CU_COMPEXTRATING_BY.SelectedValue + "' ORDER BY RTGCLASS_CODE", false, conn);
		}

		protected void TXT_TEMPBI_TextChanged(object sender, System.EventArgs e)
		{
			string biall, bi1, bi2, bi3, bi4;
			int x, y;
			if(this.TXT_TEMPBI.Text != "")
			{
				try
				{
					biall = TXT_TEMPBI.Text.Trim();
					y = biall.Length;

					x = biall.IndexOf("|");
					bi1 = biall.Substring(0, x);
					biall = biall.Substring(x+1, y-x-1);
					y = biall.Length;

					x = biall.IndexOf("|");
					bi2 = biall.Substring(0, x);
					biall = biall.Substring(x+1, y-x-1);
					y = biall.Length;

					x = biall.IndexOf("|");
					bi3 = biall.Substring(0, x);
					biall = biall.Substring(x+1, y-x-1);

					bi4 = biall;

					DDL_bmsektor.SelectedValue = bi1;

					DDL_bmsubsektor.Items.Clear();
					DDL_bmsubsektor.Items.Add(new ListItem("- PILIH -", ""));
					conn.QueryString = "select bmsub_code,bmsub_code + ' - ' + bmsub_desc as bmsubsektorDESC from RFbmsubsektorekonomi where ACTIVE='1' and BM_CODE = '"  + bi1 + "' order by bmsub_code";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						DDL_bmsubsektor.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

					DDL_bmsubsektor.SelectedValue = bi2;

					DDL_bmsubsubsektor.Items.Clear();
					DDL_bmsubsubsektor.Items.Add(new ListItem("- PILIH -", ""));
					conn.QueryString = "select bmsubsub_code,bmsubsub_code + ' - ' + bmsubsub_desc as bmsubsektorDESC from RFbmsubsubsektorekonomi where ACTIVE='1' and bmsub_code = '"  + bi2 + "' order by bmsubsub_code";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						DDL_bmsubsubsektor.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

					DDL_bmsubsubsektor.SelectedValue = bi3;

					DDL_SEKTOREKONOMIBI.Items.Clear();
					conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + bi3 + "'";
					conn.ExecuteQuery();
					GlobalTools.fillRefList(DDL_SEKTOREKONOMIBI, "SELECT BI_SEQ, BI_DESC FROM RFBICODE WHERE BG_GROUP = '3' AND BI_SEQ = '" + conn.GetFieldValue("BI_SEQ") + "'", true, conn);

					DDL_SEKTOREKONOMIBI.SelectedValue = bi4;

                    TXT_bmsubsektor.Text = bi2;
                    TXT_bmsubsubsektor.Text = bi3;
				}
				catch (Exception ex)
				{
					Response.Write("<!--" + ex.ToString() + "-->");
				}
			}
		}

		protected void DDL_CU_HUBEXECBM_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ((DDL_CU_HUBEXECBM.SelectedValue == "501") || (DDL_CU_HUBEXECBM.SelectedValue == "502") || (DDL_CU_HUBEXECBM.SelectedValue == "501"))
			{
				//DDL_CU_HUBKELBM.Enabled = true;
				DDL_CU_HUBKELBM.CssClass = "mandatory";
			}
			else
			{
				//DDL_CU_HUBKELBM.Enabled = false;
				DDL_CU_HUBKELBM.CssClass = "";
				//try {DDL_CU_HUBKELBM.SelectedValue = "";}
				//catch {}
			}
		}

        protected void CHB_CU_KTPADDR_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_CU_KTPADDR.Checked == true)
            {
                TXT_CU_KTPADDR1.Text = TXT_CU_ADDR1.Text;
                TXT_CU_KTPADDR2.Text = TXT_CU_ADDR2.Text;
                TXT_CU_KTPADDR3.Text = TXT_CU_ADDR3.Text;
                TXT_CU_KTPCITY.Text = TXT_CU_CITY.Text;
                LBL_CU_KTPCITY.Text = LBL_CU_KTPCITY.Text;
                TXT_CU_KTPZIPCODE.Text = TXT_CU_ZIPCODE.Text;
            }
        }

        protected void DDL_CU_MARITAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDL_CU_MARITAL.SelectedValue == "A")
            {
                TXT_CU_SPOUSE_FNAME.CssClass = "mandatory2";
            }
            else
            {
                TXT_CU_SPOUSE_FNAME.CssClass = "";
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            string content = string.Empty;

            using (var stringWriter = new StringWriter())
            using (var htmlWriter = new HtmlTextWriter(stringWriter))
            {
                base.Render(htmlWriter);
                htmlWriter.Close();
                content = stringWriter.ToString();
            }

            string newContent = LoopTextboxes(this.Page, content);
            writer.Write(newContent);
        }

        private string LoopTextboxes(Control page, string contents)
        {
            string element = "";

            foreach (Control control in page.Controls)
            {
                if (control is TextBox || control is Label)
                {
                    element = control.ID;
                    contents = NetMigrationEmpat(contents, element);
                }

                if (control.HasControls())
                {
                    contents = LoopTextboxes(control, contents);
                }
            }

            return contents;
        }

        private string NetMigrationEmpat(string content, string element)
        {
            string EditedRender = content;

            EditedRender = EditedRender.Replace("document." + this.Form.ID + "." + element, "document.getElementById('" + element + "')");

            return EditedRender;
        }

        private void DDL_CHANNEL_CODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDL_CHANNEL_CODE.SelectedIndex > 0)
            {
                TR_Source_Code.Visible = true;
                TR_Referal_NAME.Visible = true;
            }
            else
            {
                TR_Source_Code.Visible = false;
                TR_Referal_NAME.Visible = false;
            }
        }
	}
}
