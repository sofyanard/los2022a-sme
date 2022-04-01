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


namespace SME.LKKN1
{
	
	public partial class LKNGeneral : System.Web.UI.Page
	{
		
		protected Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack) 
			{
				this.view();
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

		private void view() 
		{

			string regno = Request.QueryString["regno"];
			string curef = Request.QueryString["curef"];
			string mc = Request.QueryString["mc"];
			string tc = Request.QueryString["tc"];
			string lkkn = Request.QueryString["lkkn"];

			conn.QueryString = "select AP_COMPLEVEL from APPLICATION where AP_REGNO = '" + regno + "'";
			conn.ExecuteQuery();
			
			string szCpLvl = conn.GetFieldValue("AP_COMPLEVEL");			

			conn.QueryString = "select in_small, in_middle, in_corporate, in_micro from rfinitial";
			conn.ExecuteQuery();
					 
			//string m_in_small = conn.GetFieldValue("in_small");
			//string m_in_middle = conn.GetFieldValue("in_middle");
			//string m_in_corp = conn.GetFieldValue("in_corporate");

            string mInMicro = conn.GetFieldValue("IN_SMALL");
            string mInSmall = conn.GetFieldValue("IN_MIDDLE");
            string mInCorp = conn.GetFieldValue("IN_CORPORATE");
            string mInCons = conn.GetFieldValue("IN_MICRO");

			/*
            bool bSiteVisitUser = false;

			if(szCpLvl == m_in_small) 
				//bSiteVisitUser = true;
                bSiteVisitUser = false;
			else if(szCpLvl == m_in_middle)
				bSiteVisitUser = false;
			else if(szCpLvl == m_in_corp)
				bSiteVisitUser = false;

            if(bSiteVisitUser)
				Response.Redirect("../LKKN/LKKN1.aspx?lkkn=" + lkkn + "&regno=" + regno + "&curef=" + curef + "&mc=" + mc + "&tc=" + tc);
			else
				Response.Redirect("../VerificationAssignment/SiteVisit.aspx?lkkn=" + lkkn + "&regno=" + regno +"&curef=" + curef + "&mc=" +mc + "&tc=" + tc);
            */

            if (szCpLvl == mInMicro)
                //Response.Redirect("../LKKN/LKKN1.aspx?regno=" + lbl_regno.Text + "&curef=" + lbl_curef.Text + "&mc=" +Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"];
                Response.Redirect("../VerificationAssignment/SiteVisit.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&mc=" + Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"]);
            else if (szCpLvl == mInSmall)
                Response.Redirect("../VerificationAssignment/SiteVisit.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&mc=" + Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"]);
            else if (szCpLvl == mInCons)
                Response.Redirect("../VerificationAssignment/VerificationInvestigation.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&mc=" + Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"]);
            else if (szCpLvl == mInCorp)
                Response.Redirect("../VerificationAssignment/SiteVisit.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&mc=" + Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"]);
		}
	}
}
