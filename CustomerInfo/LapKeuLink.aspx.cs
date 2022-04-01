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

namespace SME.CustomerInfo
{
	/// <summary>
	/// Summary description for LapKeuLink.
	/// </summary>
	public partial class LapKeuLink : System.Web.UI.Page
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
			try
			{
				conn.QueryString = "EXEC CUSTINFO_LAPKEULINK '" + Request.QueryString["regno"] + "', '" + 
					Request.QueryString["curef"] + "', '" + Session["UserID"].ToString() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0) 
				{
					string link = conn.GetFieldValue("SCR_LINK");
					if (Request.QueryString["tc"] != null)
						link = link + "&tc=" + Request.QueryString["tc"];
					if (Request.QueryString["mc"] != null)
						link = link + "&mc=" + Request.QueryString["mc"];
					if (Request.QueryString["scr"] != null)
						link = link + "&scr=" + Request.QueryString["scr"];
					if (Request.QueryString["mode"] != null)
						link = link + "&mode=" + Request.QueryString["mode"];
					Response.Redirect(link);
				}
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				Tools.popMessage(this, errmsg);
				Response.Write("<script language='javascript'>history.back(-1);</script>");
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
