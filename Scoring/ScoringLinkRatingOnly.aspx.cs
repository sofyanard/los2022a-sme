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
	/// Summary description for ScoringLinkRatingOnly.
	/// </summary>
	public partial class ScoringLinkRatingOnly : System.Web.UI.Page
	{
		protected Connection conn;
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack) 
			{
				redirect();
			}
		}

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
				else if (scrtype == "6") 
				{
					string link = conn.GetFieldValue("SCR_LINK");
					Response.Redirect(link + "&regno=" + vAP_REGNO + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"]+"&scr="+Request.QueryString["scr"]+"&mode=" + Request.QueryString["mode"]);
				}
				else
				{
					/* 20090616 by sofyan, di-direct ke screen rating aja
					 * 
					Tools.popMessage(this, "Customer tidak termasuk dalam kategori Rating");
					Response.Write("<script language='javascript'>history.back(-1);</script>");
					*/

					string link = "ScoringLinkDummy.aspx?curef=" + Request.QueryString["curef"] + "&regno=" + Request.QueryString["regno"] +
						"&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&sta=" + Request.QueryString["sta"] + 
						"&scr=" + Request.QueryString["scr"] + "&mode=" + Request.QueryString["mode"];
					Response.Redirect(link);
				}
			}
			else 
			{
				/*
				string msg = "Customer has never been scored/rated!";
				msg += "\\nAre you sure to perform scoring/rating?";

				string link = "ScoringLinkDummy.aspx?curef=" + Request.QueryString["tc"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&sta=" + Request.QueryString["sta"];
				string page = "<form name='Form1' action='"+link+"' target='main'></form>";

				Response.Write("<script language='javascript'>");
				Response.Write("conf = confirm('"+msg+"');");
				Response.Write("if (conf) {}");
				Response.Write("else {history.back(-1);}");
				Response.Write("</script>");
				*/

				string link = "ScoringLinkDummy.aspx?curef=" + Request.QueryString["curef"] + "&regno=" + Request.QueryString["regno"] +
					"&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&sta=" + Request.QueryString["sta"] + 
					"&scr=" + Request.QueryString["scr"] + "&mode=" + Request.QueryString["mode"];
				Response.Redirect(link);

				//Response.Write("<script language='javascript'>document.forms[0].Test();</script>");

				//Tools.popMessage(this, "Customer belum pernah scoring/rating!");
				//Response.Write("<script language='javascript'>history.back(-1);</script>");
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
	}
}
