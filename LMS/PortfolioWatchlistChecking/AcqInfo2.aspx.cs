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

namespace SME.LMS.PortfolioWatchlistChecking
{
	/// <summary>
	/// Summary description for AcqInfo2.
	/// </summary>
	public partial class AcqInfo2 : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		private string theForm, theObj;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{				
				ViewData();
			}

			if (Request.QueryString.Count > 0)
			{	
				theForm = Request.QueryString["theForm"];
				theObj = Request.QueryString["theObj"];
			}	
		}

		private void ViewData()
		{
			conn.QueryString = "select * from VW_PORTFOLIO_WC_ACQ_APPTRACK where no_lms='"+Request.QueryString["no_lms"]+"' and trackcode='P2' ";
			conn.ExecuteQuery();	
			TXT_MSG.Text = conn.GetFieldValue("message");
	
			conn.QueryString = "select * from VW_portfolio_wc_apptrack_history where no_lms='"+Request.QueryString["no_lms"]+"' and trackcode='P2'";
			conn.ExecuteQuery();
			if(conn.GetRowCount()>0)
			{
				BTN_CLOSE.Visible = false;
				BTN_SEND.Visible = false;
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

		protected void BTN_CLOSE_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='JavaScript1.2'>window.close();</script>");
		}

		protected void BTN_SEND_Click(object sender, System.EventArgs e)
		{
			string pic_bu;
			string petugas_bu;
			
			/*conn.QueryString = "select * from VW_PORTFOLIO_WC_USER_HISTORY where no_lms='"+ Request.QueryString["no_lms"] +"'";
			conn.ExecuteQuery();
			pic_bu = conn.GetFieldValue("por_trackby");*/

			conn.QueryString = "select * from PORTFOLIO_WC where no_lms='"+ Request.QueryString["no_lms"] +"' ";
			conn.ExecuteQuery();
			petugas_bu = conn.GetFieldValue("analyst_userid");

			conn.QueryString = "select su_upliner from scuser where userid= '"+ petugas_bu +"'";
			conn.ExecuteQuery();
			pic_bu =  conn.GetFieldValue("su_upliner");
			
			conn.QueryString = " exec PORTFOLIO_WC_TRACKUPDATE '" +
				Request.QueryString["no_lms"] +"', 'P2', '" + 				
				Session["UserID"].ToString()+" ', '"+pic_bu+"' ";			
			conn.ExecuteNonQuery();		
	
			conn.QueryString = " exec PORTFOLIO_WC_ACQ_HISTORY '" +
				Request.QueryString["no_lms"] + "', 'P2', '" + 				
				Session["UserID"].ToString()+ " ', '" + pic_bu + "', '" + TXT_MSG.Text + "' ";			
			conn.ExecuteNonQuery();

			string a = "<script language='JavaScript1.2'>window.opener.document." + theForm + "." + theObj + ".value='EXIT'; ";
			string b = "window.opener.document." + theForm + ".submit(); window.close();</script>" ;			
			
			Response.Write("<script language='JavaScript1.2'>window.opener.document." + 
				theForm + "." + theObj + ".value='EXIT'; " +
				"window.opener.document." + theForm + ".submit(); window.close();</script>");

			Response.Write("<script language='JavaScript1.2'>window.close();</script>");
		}
	}
}
