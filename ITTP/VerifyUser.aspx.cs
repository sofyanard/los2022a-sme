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
using System.Web.Security;
using DMS.DBConnection;
using DMS.CuBESCore;
using System.Configuration;
namespace SME.ITTP
{
	/// <summary>
	/// Summary description for VerifyUser.
	/// </summary>
	public partial class VerifyUser : System.Web.UI.Page
	{

		protected Logic logic = new Logic();
		string theForm = "";
		string theObj = "";


		protected Connection conn = new Connection();
		protected Connection eSec_conn = null;


	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			try { eSec_conn = new Connection(ConfigurationSettings.AppSettings["eSecurityConnectString"]); } 
			catch {}

			GlobalTools.SetFocus(this, TXT_USER);

			if (Request.QueryString.Count > 0)
			{	
				theForm = Request.QueryString["theForm"];
				theObj = Request.QueryString["theObj"];
			}	

			if (!IsPostBack)
			{
				TXT_USER.Text = Request.QueryString["userid"];
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

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			string userid = Request.QueryString["userid"];
			
			/// user memasukkan userid yang tidak sama userid untuk login
			/// 
			if (TXT_USER.Text.ToLower() != userid.ToLower()) 
			{
				Label1.Text = "Invalid UserID";
				return;
			}

			/// Validate password entry against database
			/// 
			int flag = 0;

			/// check on LOS-Login database
			if (eSec_conn != null) 
			{
				flag = logic.ValidateLogin(TXT_USER.Text, System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(TXT_PASSWORD.Text, "sha1"), eSec_conn);
			}
				// else check on LOSSME database
			else 
			{
				flag = logic.ValidateLogin(TXT_USER.Text, System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(TXT_PASSWORD.Text, "sha1"), conn);
			}

			/*if (flag == 0)
				Label1.Text += " Invalid Password";
			else Label1.Text += " Verify OK ^_^";*/

			if (flag == 0)
				Label1.Text = "Invalid Password";
			else if (flag == 3)
				Label1.Text = "User: " + TXT_USER.Text + " is locked!";
			else if (flag == 1 || flag == 2)
			{
				Response.Write("<script language='JavaScript1.2'>window.opener.document." + 
					theForm + "." + theObj + ".value='" + TXT_USER.Text.Trim() + "'; " +
					"window.opener.document." + theForm + ".submit(); </script>");

				BTN_SAVE.Enabled = false;
			}

		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			BTN_SAVE.Enabled=false;
		}
	}
}
