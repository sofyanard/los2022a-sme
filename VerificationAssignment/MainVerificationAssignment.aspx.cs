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

namespace SME.VerificationAssignment
{
	/// <summary>
	/// Summary description for MainVerificationAssignment.sadfsad
	/// </summary>
	public partial class MainVerificationAssignment : System.Web.UI.Page
	{

		#region " My Variables "

		protected Connection conn;
		protected Tools tool = new Tools();		

		#endregion
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				ViewDataApplication();
			}

			/*
			HyperLink temp = new HyperLink();
			temp.Text = "Data Entry";
			temp.Font.Bold = true;
			temp.NavigateUrl = "/SME/DataEntry/Main.aspx?regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc=003"+"&tc="+Request.QueryString["tc"];
			Menu.Controls.Add(temp);
			Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
			*/

			ViewMenu();
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

		

		private void ViewDataApplication()
		{
			lbl_regno.Text		= Request.QueryString["regno"];
			lbl_curef.Text		= Request.QueryString["curef"];

            conn.QueryString = "SELECT IN_SMALL, IN_MIDDLE, IN_CORPORATE, IN_MICRO FROM RFINITIAL";
			conn.ExecuteQuery();
					 
            //string m_in_small = conn.GetFieldValue("in_small");
            //string m_in_middle = conn.GetFieldValue("in_middle");
            //string m_in_corp = conn.GetFieldValue("in_corporate");

            string mInMicro = conn.GetFieldValue("IN_SMALL");
            string mInSmall = conn.GetFieldValue("IN_MIDDLE");
            string mInCorp = conn.GetFieldValue("IN_CORPORATE");
            string mInCons = conn.GetFieldValue("IN_MICRO");

			conn.QueryString = "select ISNULL(AP_ACQINFOBY,'') as AP_ACQINFOBY, AP_COMPLEVEL from APPLICATION where AP_REGNO = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
			
			string szCpLvl = conn.GetFieldValue("AP_COMPLEVEL");			
			//bool bSiteVisitUser = false;

            //if(szCpLvl == m_in_small) 
            //    //bSiteVisitUser = true;
            //    bSiteVisitUser = false;
            //else if(szCpLvl == m_in_middle)
            //    bSiteVisitUser = false;
            //else if(szCpLvl == m_in_corp)
            //    bSiteVisitUser = false;

			string ISACQINFO = conn.GetFieldValue(0,0).ToString().Trim();
			string StaDe = "1";
			if (ISACQINFO != "")
				StaDe = "1";

			conn.QueryString = "select * from VW_VER_MAINASSIGNMENT where AP_REGNO = '" +Request.QueryString["regno"]+ "'";
			conn.ExecuteQuery();
			TXT_AP_REGNO.Text		= conn.GetFieldValue("AP_REGNO");
			TXT_CU_REF.Text			= conn.GetFieldValue("CU_REF");
			TXT_AP_SIGNDATE.Text	= tool.FormatDate(conn.GetFieldValue("AP_SIGNDATE"));
			TXT_PROGRAMDESC.Text	= conn.GetFieldValue("PROGRAMDESC");
			TXT_BRANCH_NAME.Text	= conn.GetFieldValue("BRANCH_NAME");
			TXT_AP_RELMNGR.Text		= conn.GetFieldValue("SU_FULLNAME");
			LBL_CU_CUSTTYPEID.Text	= conn.GetFieldValue("CU_CUSTTYPEID");
			TXT_AP_BUSINESSUNIT.Text= conn.GetFieldValue("AP_BUSINESSUNIT");
			TXT_AP_TEAMLEADER.Text	= conn.GetFieldValue("AP_TEAMLEADER");
			LBL_AP_PROG_CODE.Text	= conn.GetFieldValue("AP_PROG_CODE");
			ViewDataCustomer();

			//--- Link Struktur Kredit ---
			HyperLink strcre = new HyperLink();
			strcre.Text = "Struktur Kredit";
			strcre.Font.Bold = true;
			strcre.NavigateUrl = "../dataentry/custproduct.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text+"&sta=view&de="+StaDe + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"];
			strcre.Target = "if2";


			//--- Link Tambah Jenis Pengajuan ---
			HyperLink jeniPengajuanBaru = new HyperLink();
			jeniPengajuanBaru.Text = "Tambah/Ubah/Hapus Jenis Pengajuan";
			jeniPengajuanBaru.Font.Bold = true;
			jeniPengajuanBaru.NavigateUrl = "../InitialDataEntry/KetentuanKredit.aspx?regno=" + lbl_regno.Text + "&curef=" + lbl_curef.Text+"&tc="+Request.QueryString["tc"].ToString().Trim()+ "&mc=" +Request.QueryString["mc"] + "&prog=" + LBL_AP_PROG_CODE.Text + "&va=1";


			//--- Link Data Jaminan ---
			HyperLink collateral_peal = new HyperLink();
			collateral_peal.Text = "Data Jaminan";
			collateral_peal.Font.Bold = true;
			collateral_peal.NavigateUrl = "../Dataentry/jaminan_detail.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text+"&de=1&sta=view" + "&mc=" + Request.QueryString["mc"];
			collateral_peal.Target = "if2";


			//--- Link Appraisal Assignment ---
			HyperLink collateral = new HyperLink();
			collateral.Text = "Appraisal Assignment";
			collateral.Font.Bold = true;
			collateral.NavigateUrl = "AppraisalAssignment.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text;
			collateral.Target = "if2";

			//--- Link Site Visit Assignment ---
			HyperLink SiteVisitAssign = new HyperLink();
			SiteVisitAssign.Text = "Site Visit Assignment";
			SiteVisitAssign.Font.Bold = true;
			SiteVisitAssign.NavigateUrl = "../VerificationAssignment/SiteVisitAssignment.aspx?regno=" + lbl_regno.Text + "&curef=" + lbl_curef.Text + "&mc=" + Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"]; ;
			SiteVisitAssign.Target = "if2";

			//--- Link Site Visit ---
			HyperLink SiteVisit= new HyperLink();
			SiteVisit.Text = "Site Visit";
			SiteVisit.Font.Bold = true;

            if (szCpLvl == mInMicro)
                //SiteVisit.NavigateUrl = "../LKKN/LKKN1.aspx?regno=" + lbl_regno.Text + "&curef=" + lbl_curef.Text + "&mc=" +Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"];
                SiteVisit.NavigateUrl = "../VerificationAssignment/SiteVisit.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text + "&mc=" +Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"];
            else if (szCpLvl == mInSmall)
                SiteVisit.NavigateUrl = "../VerificationAssignment/SiteVisit.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text + "&mc=" +Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"];
            else if (szCpLvl == mInCons)
                SiteVisit.NavigateUrl = "../VerificationAssignment/VerificationInvestigation.aspx?regno=" + lbl_regno.Text + "&curef=" + lbl_curef.Text + "&mc=" + Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"];
            else if (szCpLvl == mInCorp)
                SiteVisit.NavigateUrl = "../VerificationAssignment/SiteVisit.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text + "&mc=" +Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"];

            //if(bSiteVisitUser)
            //    SiteVisit.NavigateUrl = "../LKKN/LKKN1.aspx?regno=" + lbl_regno.Text + "&curef=" + lbl_curef.Text + "&mc=" +Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"];
            //else
            //    SiteVisit.NavigateUrl = "../VerificationAssignment/SiteVisit.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text + "&mc=" +Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"];
			

			//--- Link Acquire Information ---
			HyperLink acqInfo = new HyperLink();
			acqInfo.Text = "Acquire Information";
			acqInfo.Font.Bold = true;
			acqInfo.NavigateUrl = "../Approval/AcqInfo.aspx?regno=" + lbl_regno.Text + "&curef=" + lbl_curef.Text + "&sta=view";
			acqInfo.Target = "if2";


			//--- Link Appraisal ---
			HyperLink Appraisal = new HyperLink();
			Appraisal.Text = "Appraisal";
			Appraisal.Font.Bold = true;
			Appraisal.NavigateUrl = "../Appraisal/InfoUmum.aspx?regno=" + lbl_regno.Text + "&curef=" + lbl_curef.Text+"&tc="+Request.QueryString["tc"].ToString().Trim()+ "&mc=" +Request.QueryString["mc"];

			PlaceHolder1.Controls.Add(strcre);
			PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
			PlaceHolder1.Controls.Add(jeniPengajuanBaru);
			PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
			
			if (ISACQINFO != "")
			{
				PlaceHolder1.Controls.Add(acqInfo);
				PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));

				/***
				PlaceHolder1.Controls.Add(collateral_peal);
				PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				***/
			}
			
			PlaceHolder1.Controls.Add(collateral);
			PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
			PlaceHolder1.Controls.Add(Appraisal);
			PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
			PlaceHolder1.Controls.Add(SiteVisitAssign);
			PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
			PlaceHolder1.Controls.Add(SiteVisit);
		}

		private void ViewDataCustomer()
		{
			if (LBL_CU_CUSTTYPEID.Text == "01") //if company
			{
				conn.QueryString = "select * from VW_CUST_COMPANY where CU_REF = '" +Request.QueryString["curef"]+ "'";
				conn.ExecuteQuery();
				TXT_NAME.Text = conn.GetFieldValue("COMPTYPEDESC").Trim()+" "+conn.GetFieldValue("CU_COMPNAME").Trim();
				TXT_ADDRESS1.Text		= conn.GetFieldValue("CU_COMPADDR1");
				TXT_ADDRESS2.Text		= conn.GetFieldValue("CU_COMPADDR2");
				TXT_ADDRESS3.Text		= conn.GetFieldValue("CU_COMPADDR3");
				TXT_CITY.Text			= conn.GetFieldValue("CITYNAME");
				TXT_PHONENUM.Text		= conn.GetFieldValue("CU_COMPPHNAREA").Trim() + " - "+conn.GetFieldValue("CU_COMPPHNNUM").Trim();
				TXT_BUSINESSTYPE.Text	= conn.GetFieldValue("BUSSTYPEDESC");
			}
			else //if personal
			{
				conn.QueryString = "select * from VW_CUST_PERSONAL where CU_REF = '" +Request.QueryString["curef"]+ "'";
				conn.ExecuteQuery();
				TXT_NAME.Text			= conn.GetFieldValue("CU_FIRSTNAME").Trim()+ " "+conn.GetFieldValue("CU_MIDDLENAME").Trim()+" "+conn.GetFieldValue("CU_LASTNAME").Trim();
				TXT_ADDRESS1.Text		= conn.GetFieldValue("CU_ADDR1");
				TXT_ADDRESS2.Text		= conn.GetFieldValue("CU_ADDR2");
				TXT_ADDRESS3.Text		= conn.GetFieldValue("CU_ADDR3");
				TXT_CITY.Text			= conn.GetFieldValue("CITYNAME");
				TXT_PHONENUM.Text		= conn.GetFieldValue("CU_PHNAREA").Trim() + " - "+conn.GetFieldValue("CU_PHNNUM").Trim();
				TXT_BUSINESSTYPE.Text	= conn.GetFieldValue("BUSSTYPEDESC");
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

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}
	}
}
