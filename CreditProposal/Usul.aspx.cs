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

namespace SME.CreditProposal
{
	/// <summary>
	/// Summary description for Usul.
	/// </summary>
	public partial class Usul : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				ViewDataApplication();
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
		private void ViewDataApplication()
		{
			conn.QueryString = "select CP_USUL from VW_CP_MAIN_USUL where AP_REGNO = '" +Request.QueryString["regno"]+ "'";
			conn.ExecuteQuery();
			TXT_CP_USUL.Text	= conn.GetFieldValue("CP_USUL");
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec CP_USUL '" +Request.QueryString["regno"]+ "', '" +TXT_CP_USUL.Text+ "'";
			conn.ExecuteNonQuery();
			ViewDataApplication();
		}
	}
}
