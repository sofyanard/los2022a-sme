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
namespace SME.ITTP
{
	/// <summary>
	/// Summary description for CustomerInfo.
	/// </summary>
	public partial class CustomerInfo : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		protected Deduplication dedup = new Deduplication();
		protected string MC;
		private string de;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			de = Request.QueryString["de"];


			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{

				LBL_AP_RELMNGR.Text = Session["UserID"].ToString();
				TXT_AP_RELMNGR.Text = Session["FullName"].ToString();

				//pipeline
				temp_userid.Text = Session["UserID"].ToString();
				temp_branchcode.Text = Session["BranchID"].ToString();
				temp_areaid.Text = Session["AreaID"].ToString();
				
				//DDL_AP_SIGNDATE_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_BUSSTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_COMPBUSSTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_DOB_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_IDCARDEXP_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				//DDL_CHANNEL_CODE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_COMPTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_JOBTITLE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_MARITAL.Items.Add(new ListItem("- PILIH -", ""));
				//DDL_PROG_CODE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_SEX.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_CITIZENSHIP.Items.Add(new ListItem("- PILIH -", ""));
				DDL_JNSALAMAT_C.Items.Add(new ListItem("- PILIH -", ""));
				DDL_JNSALAMAT_P.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_JNSNASABAH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_EDUCATION.Items.Add(new ListItem("- PILIH -", ""));
				//TXT_AP_RECVDATE.Text = tool.FormatDate(DateTime.Now.ToString());
				//TXT_BRANCH_CODE.Text = Session["BranchName"].ToString();
				//TXT_AREAID.Text = Session["AreaName"].ToString();
				//DDL_groupnasabah.Items.Add(new ListItem("- PILIH -", ""));
				DDL_bmsektor.Items.Add(new ListItem("- PILIH -", ""));
				DDL_bmsubsektor.Items.Add(new ListItem("- PILIH -", ""));
				DDL_bmsubsubsektor.Items.Add(new ListItem("- PILIH -", ""));

				//2010-04-08 Enhancement 2010
				DDL_CU_LOKASIDATI2.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_HUBEXECBM.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_COMPEXTRATING_BY.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_COMPLISTINGCODE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_NEGARADOMISILI.Items.Add(new ListItem("- PILIH -", ""));

				for (int i = 1; i <= 12; i++)
				{
					//DDL_AP_SIGNDATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CU_DOB_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CU_IDCARDEXP_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				GlobalTools.fillRefList(DDL_CU_HOMESTA, "select * from RFHOMESTA where ACTIVE='1'", true, conn);
				GlobalTools.initDateForm(TXT_CU_SPOUSE_KTPISSUEDATE_DAY, DDL_CU_SPOUSE_KTPISSUEDATE_MONTH, TXT_CU_SPOUSE_KTPISSUEDATE_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_SPOUSE_KTPEXPDATE_DAY, DDL_CU_SPOUSE_KTPEXPDATE_MONTH, TXT_CU_SPOUSE_KTPEXPDATE_YEAR, true);

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

				conn.QueryString = "select BUSSTYPEID, BUSSTYPEID + ' - ' + BUSSTYPEDESC as BUSSTYPEDESC from RFBUSINESSTYPE where ACTIVE='1' AND LEN(BUSSTYPEID) < 3 order by BUSSTYPEID";
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
				DDL_lokasiproyek.Items.Add(new ListItem("- SELECT -", ""));
				for (int i=0; i<conn.GetRowCount(); i++)
					DDL_lokasiproyek.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
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

				TXT_CU_REF.Text = Request.QueryString["curef"];
				TXT_AP_REGNO.Text = Request.QueryString["regno"];

				BTN_SAVECON.Visible = false;

				//Tools.initDateForm(TXT_AP_SIGNDATE_DAY, DDL_AP_SIGNDATE_MONTH, TXT_AP_SIGNDATE_YEAR, false);

				if (Request.QueryString["exist"] == "1")
				{
					//--- if existing customer, user tidak bisa ganti tipe customer
					RDO_RFCUSTOMERTYPE.Enabled = false;			
				}
				ViewData();

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
					TXT_CU_MULAIMENETAPMM.CssClass = "";
					TXT_CU_MULAIMENETAPYY.CssClass = "";

					//setMandatoryFI(RDO_RFCUSTOMERTYPE.SelectedValue, DDL_PROG_CODE.SelectedValue);
				}
				//pipeline
				

			}

			

			//--- Kalau baru masuk pertama kali ke screen, maka
			//--- screen tidak perlu diperlihatkan
			//if (Request.QueryString["gi"] != "" && Request.QueryString["gi"] != null)
				ViewMenu();

			//TXT_AP_GROSSSALES.Text = tool.MoneyFormat(TXT_AP_GROSSSALES.Text);
			if (RDO_RFCUSTOMERTYPE.SelectedValue != "01")
				TXT_CU_NETINCOMEMM.Text = tool.MoneyFormat(TXT_CU_NETINCOMEMM.Text);
			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			BTN_SAVECON.Attributes.Add("onclick","if(!cek_mandatory2(document.Form1)){return false;};"); 

			MC = Request.QueryString["mc"];
			if ( MC=="T0504" )
			{
				TR_VIEW.Visible = false;
			}
			
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
				//TXT_AREAID.CssClass = "mandatory";
				//TXT_BRANCH_CODE.CssClass = "mandatory";
				//DDL_PROG_CODE.CssClass = "mandatory";
				//DDL_AP_SRCCODE.CssClass = "mandatory";
				//TXT_AP_GROSSSALES.CssClass = "mandatory";
				//DDL_AP_GRSALESCURR.CssClass = "mandatory";
				//DDL_AP_BOOKINGBRANCH.CssClass = "mandatory";
				//TXT_AP_SIGNDATE_DAY.CssClass = "mandatory";
				//DDL_AP_SIGNDATE_MONTH.CssClass = "mandatory";
				//TXT_AP_SIGNDATE_YEAR.CssClass = "mandatory";
				//DDL_AP_BUSINESSUNIT.CssClass = "mandatory";
			}
			else
			{
				BTN_SAVECON.Visible = true;
				BTN_SAVE.Visible = false;
				TR_COMPANY.Visible = false;
				TR_PERSONAL.Visible = true;
				//TXT_AREAID.CssClass = "mandatory2";
				//TXT_BRANCH_CODE.CssClass = "mandatory2";
				//DDL_PROG_CODE.CssClass = "mandatory2";
				//DDL_AP_SRCCODE.CssClass = "mandatory2";
				//TXT_AP_GROSSSALES.CssClass = "mandatory2";
				//DDL_AP_GRSALESCURR.CssClass = "mandatory2";
				//DDL_AP_BOOKINGBRANCH.CssClass = "mandatory2";
				//TXT_AP_SIGNDATE_DAY.CssClass = "mandatory2";
				//DDL_AP_SIGNDATE_MONTH.CssClass = "mandatory2";
				//TXT_AP_SIGNDATE_YEAR.CssClass = "mandatory2";
				//DDL_AP_BUSINESSUNIT.CssClass = "mandatory2";
			}
		}
		
		private void ViewData()
		{

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
			catch (Exception ex) {string exm = ex.ToString();}
			try {DDL_CU_HUBEXECBM.SelectedValue = conn.GetFieldValue("CU_HUBEXECBM");}
			catch {}

			try {DDL_bmsektor.SelectedValue=conn.GetFieldValue("CU_bmsektorekonomi");}
			catch {}
			//sub sektor
			GlobalTools.fillRefList(DDL_bmsubsektor, "select BMSUB_CODE, BMSUB_DESC from RFBMSUBSEKTOREKONOMI where ACTIVE = '1' and BM_CODE = '" + DDL_bmsektor.SelectedValue + "'", true, conn);
			try {DDL_bmsubsektor.SelectedValue=bm_subsektor;}
			catch {}
			//sub sub sektor
			GlobalTools.fillRefList(DDL_bmsubsubsektor, "select BMSUBSUB_CODE, BMSUBSUB_DESC from RFBMSUBSUBSEKTOREKONOMI where ACTIVE = '1' and BMSUB_CODE = '" + DDL_bmsubsektor.SelectedValue + "'", true, conn);
			try {DDL_bmsubsubsektor.SelectedValue=bm_subsubsektor;}
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
				//RDO_CU_PERNAHJDNASABAHBM.SelectedValue = (conn.GetFieldValue("CU_PERNAHJDNASABAHBM")==""?"0":conn.GetFieldValue("CU_PERNAHJDNASABAHBM"));
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
				try {DDL_CU_NEGARADOMISILI.SelectedValue = conn.GetFieldValue("CU_NEGARADOMISILI");}
				catch {}
			}			
			else
			{
				TR_COMPANY.Visible = true;
				TR_PERSONAL.Visible = false;
				RDO_RFCUSTOMERTYPE.SelectedValue = "01";

				conn.QueryString = "select * from VW_CUST_COMPANY where CU_REF='" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();
				
				TXT_CU_CIF_C.Text = conn.GetFieldValue("CU_CIF");
				//TXT_BRANCH_CODE.Text = Session["BranchName"].ToString();
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
				//RDO_CU_PERNAHJDNASABAHBM.SelectedValue = (conn.GetFieldValue("CU_PERNAHJDNASABAHBM")==""?"0":conn.GetFieldValue("CU_PERNAHJDNASABAHBM"));
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
				try {DDL_CU_COMPEXTRATING_BY.SelectedValue = conn.GetFieldValue("CU_COMPEXTRATING_BY");}
				catch {}
				TXT_CU_COMPEXTRATING_CLASS.Text = conn.GetFieldValue("CU_COMPEXTRATING_CLASS");
				try { GlobalTools.fromSQLDate(conn.GetFieldValue("CU_COMPEXTRATING_DATE"), TXT_CU_COMPEXTRATING_DATE_DAY, DDL_CU_COMPEXTRATING_DATE_MONTH, TXT_CU_COMPEXTRATING_DATE_YEAR); }
				catch {}
				try {DDL_CU_COMPLISTINGCODE.SelectedValue = conn.GetFieldValue("CU_COMPLISTINGCODE");}
				catch {}
				try { GlobalTools.fromSQLDate(conn.GetFieldValue("CU_COMPLISTINGDATE"), TXT_CU_COMPLISTINGDATE_DAY, DDL_CU_COMPLISTINGDATE_MONTH, TXT_CU_COMPLISTINGDATE_YEAR); }
				catch {}
			}
		}

		private void ViewDataVisited()
		{
			try 
			{
				conn.QueryString = "select * from APPLICATION where AP_REGNO = '" + TXT_AP_REGNO.Text + "'";
				conn.ExecuteQuery();
				RDO_RFCUSTOMERTYPE.Enabled = false;

			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return;
			}
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			
			string curef = TXT_CU_REF.Text;
			
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())),
				compEstablish, personalEstablish;

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
					conn.QueryString = "exec IT_IDE_GENINFO_COMP_INSERT '" + 
						Request.QueryString["regno"] + "', '" + 
						TXT_CU_REF.Text + "', '" +
						//Session["AreaID"].ToString() + "', '" +
						//temp_areaid.Text + "', '" +
						//DDL_PROG_CODE.SelectedValue + "', '" +
						//Session["BranchID"].ToString() + "', '" + 
						//temp_branchcode.Text + "', '" + 
						LBL_AP_RELMNGR.Text + "', '" + 
						//tool.ConvertNull(DDL_CHANNEL_CODE.SelectedValue) + ", '" + 
						//DDL_AP_SRCCODE.SelectedValue + "', " + 
						//tool.ConvertFloat(TXT_AP_GROSSSALES.Text) + ", " + 
						//tool.ConvertDate(TXT_AP_SIGNDATE_DAY.Text, DDL_AP_SIGNDATE_MONTH.SelectedValue, TXT_AP_SIGNDATE_YEAR.Text) + ", " +
						//tool.ConvertNull(DDL_AP_SALESAGENCY.SelectedValue) + ", " + 
						//tool.ConvertNull(DDL_AP_SALESSUPERV.SelectedValue) + ", " + 
						//tool.ConvertNull(DDL_AP_SALESEXEC.SelectedValue) + ", '" +					
						//Session["UserID"].ToString() + "', '" + 
						//temp_userid.Text + "', '" + 
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
						TXT_CU_CONTACTPHNEXT.Text + "', " + 
						//RDO_BI_CHECKING.SelectedValue + "', '0', " + 
						tool.ConvertNull(TXT_CU_COMPEMPLOYEE.Text.Trim()) + ", " + 
						tool.ConvertNull(DDL_JNSALAMAT_C.SelectedValue) + ", '" + 
						TXT_CU_TDP.Text + "', "
						+ tool.ConvertNull(DDL_CU_JNSNASABAH.SelectedValue) + ", " + 
						//DDL_AP_BUSINESSUNIT.SelectedValue + "', '" + 
						//DDL_AP_BOOKINGBRANCH.SelectedValue + "', null, '" + 
						//RDO_CU_PERNAHJDNASABAHBM.SelectedValue + "', " + 
						tool.ConvertNull(TXT_CU_COMPAKTAPENDIRIAN.Text.Trim()) + ", '" + 
						//DDL_GRPUNIT.SelectedValue + "', '" + DDL_AP_GRSALESCURR.SelectedValue + "', '" + DDL_AP_CCOBRANCH.SelectedValue + "', " +
						//pipeline
						//tool.ConvertFloat(Textbox_skbngpasar.Text) + ", " + tool.ConvertFloat(Textbox_skbngminta.Text) + ", '" + 
						DDL_groupnasabah.Text + "', '" +
						DDL_bmsektor.SelectedValue + "', '" +
						DDL_bmsubsektor.SelectedValue + "', '" +
						DDL_bmsubsubsektor.SelectedValue + "', " +
						tool.ConvertFloat(Textbox_netincome.Text) + ", " +
						tool.ConvertFloat(Textbox_pendapatanoperasional.Text) + ", " +
						tool.ConvertFloat(Textbox_pendapatannon.Text) + ", '" +
						Textbox_keyperson.Text  + "', '" + 
						DDL_lokasiproyek.SelectedValue + "', '" +
						TXT_CU_COMPPOB.Text + "', '" +
						//DDL_AP_SRCNAME.SelectedValue + "', '" +
						DDL_CU_LOKASIDATI2.SelectedValue + "', '" +
						DDL_CU_HUBEXECBM.SelectedValue + "', '" +
						TXT_CU_COMPAKTATERAKHIR_NO.Text + "', " +
						tool.ConvertDate(TXT_CU_COMPAKTATERAKHIR_DATE_DAY.Text, DDL_CU_COMPAKTATERAKHIR_DATE_MONTH.SelectedValue, TXT_CU_COMPAKTATERAKHIR_DATE_YEAR.Text) + ", '" +
						DDL_CU_COMPEXTRATING_BY.SelectedValue + "', '" +
						TXT_CU_COMPEXTRATING_CLASS.Text + "', " +
						tool.ConvertDate(TXT_CU_COMPEXTRATING_DATE_DAY.Text, DDL_CU_COMPEXTRATING_DATE_MONTH.SelectedValue, TXT_CU_COMPEXTRATING_DATE_YEAR.Text) + ", '" +
						DDL_CU_COMPLISTINGCODE.SelectedValue + "', " +
						tool.ConvertDate(TXT_CU_COMPLISTINGDATE_DAY.Text, DDL_CU_COMPLISTINGDATE_MONTH.SelectedValue, TXT_CU_COMPLISTINGDATE_YEAR.Text);
					conn.ExecuteNonQuery();


				} 
				catch (NullReferenceException)
				{
					GlobalTools.popMessage(this, "Connection Error!");
					Response.Redirect("../Login.aspx?expire=1");
				}

			}
				///////////////////////////////////////////////////////////////////////
				/// PERORANGAN
				/// 
			else	
			{
				//////////////////////////////////////////////////////////////
				///	VALIDASI BERDIRI SEJAK
				///	
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
				if (!GlobalTools.isDateValid("1", TXT_CU_MULAIMENETAPMM.Text, TXT_CU_MULAIMENETAPYY.Text)) 
				{
					GlobalTools.popMessage(this, "Mulai Menetap tidak valid!");
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
					conn.QueryString = "exec IT_IDE_GENINFO_PERSON_INSERT '" + 
						Request.QueryString["regno"] + "', '" +
						TXT_CU_REF.Text + "', '" + 
						//Session["AreaID"].ToString() + "', '" +
						//DDL_PROG_CODE.SelectedValue + "', '" +
						//Session["BranchID"].ToString() + "', '" + 
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
						tool.ConvertDate(TXT_CU_ESTABLISHDD.Text, DDL_CU_ESTABLISHMM.SelectedValue, TXT_CU_ESTABLISHYY.Text) + ", '" + TXT_CU_NPWP.Text + "', '" + 
						DDL_CU_CITIZENSHIP.SelectedValue + "', " + 
						//RDO_BI_CHECKING.SelectedValue + "', '0', " + 
						tool.ConvertNull(DDL_JNSALAMAT_P.SelectedValue) + ", '" + 
						TXT_CU_KTPADDR1.Text + "', '" + 
						TXT_CU_KTPADDR2.Text + "', '" + 
						TXT_CU_KTPADDR3.Text + "', '" + 
						LBL_CU_KTPCITY.Text + "', '" + 
						TXT_CU_KTPZIPCODE.Text + "', " + 
						tool.ConvertNull(DDL_CU_EDUCATION.SelectedValue) + ", " +
						tool.ConvertFloat(TXT_CU_NETINCOMEMM.Text) + ", " + 
						tool.ConvertNull(TXT_CU_CHILDREN.Text) + ", '" + 
						TXT_CU_TITLEBEFORENAME.Text+"', '" + //DDL_AP_CCOBRANCH.SelectedValue + "','"+
						TXT_CU_MOTHER.Text+"','"+
						//pipeline
						//tool.ConvertFloat(Textbox_skbngpasar.Text) + ", " + tool.ConvertFloat(Textbox_skbngminta.Text) + ", '" + 
						DDL_groupnasabah.Text + "', '" +
						DDL_bmsektor.SelectedValue + "', '" +
						DDL_bmsubsektor.SelectedValue + "', '" +
						DDL_bmsubsubsektor.SelectedValue + "', " +
						tool.ConvertFloat(Textbox_netincome.Text) + ", " +
						tool.ConvertFloat(Textbox_pendapatanoperasional.Text) + ", " +
						tool.ConvertFloat(Textbox_pendapatannon.Text) + ", '" +
						Textbox_keyperson.Text  + "', '" + 
						DDL_lokasiproyek.SelectedValue + "', '" +
						//DDL_AP_SRCNAME.SelectedValue + "', '" +
						DDL_CU_LOKASIDATI2.SelectedValue + "', '" +
						DDL_CU_HUBEXECBM.SelectedValue + "', '" +
						TXT_CU_NAMAPELAPORAN.Text + "', '" +
						DDL_CU_NEGARADOMISILI.SelectedValue + "'";
					conn.ExecuteNonQuery();

					//--- untuk memecah kebanyak argumen
					conn.QueryString = "exec IT_IDE_GENINFO_PERSON_INSERT2 '" + TXT_CU_REF.Text + "', " + 
						tool.ConvertNull(DDL_CU_HOMESTA.SelectedValue) + ", " + 
						tool.ConvertNull(TXT_CU_MULAIMENETAPMM.Text) + ", " + 
						tool.ConvertNull(TXT_CU_MULAIMENETAPYY.Text) + ", " +
						tool.ConvertNull(TXT_CU_EMPLOYEE.Text.Trim()) + "";
					conn.ExecuteNonQuery();

					//--- untuk menyimpan informasi spouse/pasangan
					conn.QueryString = "exec IT_IDE_GENINFO_PERSON_INSERT3 '" + TXT_CU_REF.Text + "', " + 
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
			}

			//if (TXT_PROG_CODE.Text == "01")
			//{
			//	Response.Redirect("RatingCustomer.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
			//}
			//else
			//{

			if ( MC!="T0504" )
			{
				Response.Redirect("Process.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&prog=" + Request.QueryString["prog"] + "&view=1");
			}

			//}
		}

		private void ClearEntries()
		{
			/*
			DDL_PROG_CODE.SelectedValue = "";
			DDL_CHANNEL_CODE.SelectedValue = "";
			//TXT_AP_SRCCODE.Text = "";
			DDL_AP_SRCCODE.SelectedValue = "";
			DDL_AP_SRCNAME.SelectedValue = "";
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
			*/

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
				//Textbox_skbngpasar.Text="";
				//Textbox_skbngminta.Text="";
				DDL_groupnasabah.Text="";
				Textbox_netincome.Text="";
				Textbox_pendapatanoperasional.Text="";
				Textbox_pendapatannon.Text="";
				DDL_lokasiproyek.SelectedValue="";
				Textbox_keyperson.Text="";
				TXT_CU_NAMAPELAPORAN.Text = "";
				DDL_CU_NEGARADOMISILI.SelectedValue = "";
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
				//Textbox_skbngpasar.Text="";
				//Textbox_skbngminta.Text="";
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
				TXT_CU_COMPEXTRATING_CLASS.Text = "";
				TXT_CU_COMPEXTRATING_DATE_DAY.Text = "";
				DDL_CU_COMPEXTRATING_DATE_MONTH.SelectedValue = "";
				TXT_CU_COMPEXTRATING_DATE_YEAR.Text = "";
				DDL_CU_COMPLISTINGCODE.SelectedValue = "";
				TXT_CU_COMPLISTINGDATE_DAY.Text = "";
				DDL_CU_COMPLISTINGDATE_MONTH.SelectedValue = "";
				TXT_CU_COMPLISTINGDATE_YEAR.Text = "";
			}
		}

		protected void BTN_SEARCHPERSONAL_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('SearchZipCode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_ZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
		}

		protected void BTN_SEARCHCOMP_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('SearchZipCode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_COMPZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
		}

		protected void BTN_SEARCHKTPZIP_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('SearchZipCode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_KTPZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
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
				LBL_CU_CITY.Text = conn.GetFieldValue(0,0);
				TXT_CU_CITY.Text = conn.GetFieldValue(0,2);
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
				LBL_CU_KTPCITY.Text = conn.GetFieldValue(0,0);
				TXT_CU_KTPCITY.Text = conn.GetFieldValue(0,2);
			}
			catch
			{
				TXT_CU_KTPZIPCODE.Text = "";
				TXT_CU_KTPCITY.Text = "";
				GlobalTools.popMessage(this, "Invalid Zipcode!");
			}
		}

		protected void DDL_bmsektor_SelectedIndexChanged(object sender, System.EventArgs e)
		{

			DDL_bmsubsektor.Items.Clear();
			DDL_bmsubsektor.Items.Add(new ListItem("- PILIH -", ""));

			conn.QueryString = "select bmsub_code,bmsub_code + ' - ' + bmsub_desc as bmsubsektorDESC from RFbmsubsektorekonomi where ACTIVE='1' and BM_CODE = '"  + DDL_bmsektor.SelectedValue + "'	order by bmsub_code";
			//conn.QueryString = "select bmsub_code,bmsub_code + ' - ' + bmsub_desc as bmsubsektorDESC from RFbmsubsektorekonomi where ACTIVE='1' and bm_code='01000000' order by bmsub_code";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_bmsubsektor.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			//GlobalTools.popMessage(this, DDL_bmsektor.SelectedValue);
			conn.ClearData();

			DDL_bmsubsubsektor.Items.Clear();
			DDL_bmsubsubsektor.Items.Add(new ListItem("- PILIH -", ""));

			conn.QueryString = "select bmsubsub_code,bmsubsub_code + ' - ' + bmsubsub_desc as bmsubsektorDESC from RFbmsubsubsektorekonomi where ACTIVE='1' and bmsub_code = '"  + DDL_bmsubsektor.SelectedValue + "'	order by bmsubsub_code";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_bmsubsubsektor.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + DDL_bmsubsubsektor.SelectedValue + "'";
			conn.ExecuteQuery();
			GlobalTools.fillRefList(DDL_SEKTOREKONOMIBI, "SELECT BI_SEQ, BI_DESC FROM RFBICODE WHERE BG_GROUP = '3' AND BI_SEQ = '" + conn.GetFieldValue("BI_SEQ") + "'", true, conn);
			try{DDL_SEKTOREKONOMIBI.SelectedValue = conn.GetFieldValue("BI_SEQ");}
			catch{DDL_SEKTOREKONOMIBI.SelectedValue="";}
		}

		protected void DDL_bmsubsektor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DDL_bmsubsubsektor.Items.Clear();

			conn.QueryString = "select bmsubsub_code,bmsubsub_code + ' - ' + bmsubsub_desc as bmsubsektorDESC from RFbmsubsubsektorekonomi where ACTIVE='1' and bmsub_code = '"  + DDL_bmsubsektor.SelectedValue + "'	order by bmsubsub_code";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_bmsubsubsektor.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + DDL_bmsubsubsektor.SelectedValue + "'";
			conn.ExecuteQuery();
			GlobalTools.fillRefList(DDL_SEKTOREKONOMIBI, "SELECT BI_SEQ, BI_DESC FROM RFBICODE WHERE BG_GROUP = '3' AND BI_SEQ = '" + conn.GetFieldValue("BI_SEQ") + "'", true, conn);
			try{DDL_SEKTOREKONOMIBI.SelectedValue = conn.GetFieldValue("BI_SEQ");}
			catch{DDL_SEKTOREKONOMIBI.SelectedValue="";}
			
		}

		protected void DDL_bmsubsubsektor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + DDL_bmsubsubsektor.SelectedValue + "'";
			conn.ExecuteQuery();
			GlobalTools.fillRefList(DDL_SEKTOREKONOMIBI, "SELECT BI_SEQ, BI_DESC FROM RFBICODE WHERE BG_GROUP = '3' AND BI_SEQ = '" + conn.GetFieldValue("BI_SEQ") + "'", true, conn);
			try{DDL_SEKTOREKONOMIBI.SelectedValue = conn.GetFieldValue("BI_SEQ");}
			catch{DDL_SEKTOREKONOMIBI.SelectedValue="";}
		}

		protected void CHB_CU_NAMAPELAPORAN_CheckedChanged(object sender, System.EventArgs e)
		{
			if (CHB_CU_NAMAPELAPORAN.Checked == true)
			{
				TXT_CU_NAMAPELAPORAN.Text = TXT_CU_FIRSTNAME.Text;
			}
		}	

		private void secureData() 
		{
			if (de == "1")
			{
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for (int i = 0; i < coll[5].Controls.Count; i++) 
				{
					if (coll[5].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[5].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[5].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[5].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[5].Controls[i] is Button)
					{
						Button btn = (Button) coll[5].Controls[i];
						btn.Visible = false;
					}
					else if (coll[5].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[5].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[5].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[5].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[5].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[5].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[5].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[5].Controls[i];

						for (int j=0; j < htr.Controls.Count; j++) 
						{							
							for (int jj = 0; jj < htr.Controls[j].Controls.Count; jj++) 
							{
								if (htr.Controls[j].Controls[jj] is TextBox) 
								{
									TextBox txt = (TextBox) htr.Controls[j].Controls[jj];
									txt.ReadOnly = true;
								}
								else if (htr.Controls[j].Controls[jj] is DropDownList) 
								{
									DropDownList ddl = (DropDownList) htr.Controls[j].Controls[jj];
									ddl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is Button)
								{
									Button btn = (Button) htr.Controls[j].Controls[jj];
									btn.Visible = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButtonList) 
								{
									RadioButtonList rbl = (RadioButtonList) htr.Controls[j].Controls[jj];
									rbl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButton) 
								{
									RadioButton rb = (RadioButton) htr.Controls[j].Controls[jj];
									rb.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is CheckBox)
								{
									CheckBox cb = (CheckBox) htr.Controls[j].Controls[jj];
									cb.Enabled = false;
								}					
							}
						}
					}
				}
			}
		}
	}
}