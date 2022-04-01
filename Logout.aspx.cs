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
using System.Configuration;


namespace SME
{
	/// <summary>
	/// Summary description for Logout.
	/// </summary>
	public partial class Logout : System.Web.UI.Page
	{
		Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			string userid = "", groupid= "";

            try
            {
                userid = Session["UserID"].ToString();
                groupid = Session["GroupID"].ToString();
            }
            catch
            {
                userid = "";
                groupid = "";
            }

			try 
			{
				Session.Clear();
				Session.Abandon();
			} 
			catch (Exception ex)
			{
				Response.Write("<!-- " + ex.Message + " -->");
			}			

			try
			{
				//conn = (Connection) Session["Connection"];
				conn = new Connection(ConfigurationSettings.AppSettings["eSecurityConnectString"]);

				conn.QueryString = "exec SU_USERACTIVITY '" + userid + "', '" + 
					groupid + "', '0', '0', '0'";
				conn.ExecuteNonQuery();

				conn.QueryString = "exec SU_ALLUSERACTIVITY '" + userid + "', '" + 
					groupid + "', '0', '0', '0'";//, '" + Request.UserHostAddress + "'"; **********
				conn.ExecuteNonQuery();

				FormsAuthentication.SignOut();

				//Response.Redirect("/SME/Login.aspx");
				//Response.Redirect("Login.aspx");
			}
			catch (Exception ex)
			{
				Response.Write("<!-- " + ex.Message + "\n" + ex.StackTrace + "-->");

				//Response.Redirect("/SME/Login.aspx");
				//Response.Redirect("Login.aspx");
			}

			conn.QueryString = "select login_scr from rfmodule where moduleid = '01'";
			conn.ExecuteQuery();

			string lost = ((Request.QueryString.Keys.Count!=0 && Request.QueryString[0]=="login")?
				"?login":"");

			Response.Redirect(conn.GetFieldValue(0, "login_scr") + lost);
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
