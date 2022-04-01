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

namespace SME.Scoring
{
	/// <summary>
	/// Summary description for ScoringLink.
	/// </summary>
	public partial class ScoringLink : System.Web.UI.Page
	{
		protected Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{			
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack) 
			{
				redirect();
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

		private void redirect() 
		{
			if (Request.QueryString["regno"] != null && Request.QueryString["regno"] != "") 
			{
				conn.QueryString = "select * from VW_SCR_PROGSCR where AP_REGNO = '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
			} 
			else 
			{
				conn.QueryString = "select * from VW_SCR_PROGSCR2 where CU_REF = '" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();
			}

			string vAP_REGNO = conn.GetFieldValue("AP_REGNO");
			string scrtype = conn.GetFieldValue("SCRID");
			if (conn.GetRowCount() > 0) 
			{
				if (scrtype == "0") 
				{
					Tools.popMessage(this, "Customer termasuk dalam kategori No Scoring");
					Response.Write("<script language='javascript'>history.back(-1);</script>");
				}
				else 
				{
					string link = conn.GetFieldValue("SCR_LINK");
					Response.Redirect(link + "&regno=" + vAP_REGNO + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"]+"&scr="+Request.QueryString["scr"]+"&mode=" + Request.QueryString["mode"]);
				}
			}
			else 
			{
				string link = "ScoringLinkDummy.aspx?curef=" + Request.QueryString["curef"] + 
					"&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&sta=" + Request.QueryString["sta"] + 
					"&scr=" + Request.QueryString["scr"] + "&mode=" + Request.QueryString["mode"];
				Response.Redirect(link);

				//Tools.popMessage(this, "Customer belum pernah scoring/rating!");
				//Response.Write("<script language='javascript'>history.back(-1);</script>");
			}
		}
	}
}
