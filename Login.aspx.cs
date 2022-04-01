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

namespace SME
{
	/// <summary>
	/// Summary description for Login. dafasfdasdf
	/// </summary>
	public partial class Login : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection2 conn2 = new Connection2(ConfigurationSettings.AppSettings["conn"]);
		//protected Connection2 conn2 = new Connection2(ConfigurationSettings.AppSettings["conn"]);
		//protected Connection conn = new Connection("Data Source=(local);Initial Catalog=SME;uid=sa;pwd=;Pooling=true");
		protected Logic logic = new Logic();
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (Request.QueryString.Count > 0)
			{
				if (Request.QueryString["menu"] == "0")
					Label1.Text = "Menu Access Not Yet Defined For This User";
				else 
				{
					/***
					 * Modified By Yudi (2004-08-27)
					 * Jika session habis, set waktu logout user
					 */
					try 
					{
						conn.QueryString = "exec SU_USERACTIVITY '" + Session["USERID"].ToString() + "', '" + 
						Session["GROUPID"].ToString() + "', '0', '0', '0'";
						conn.ExecuteNonQuery();
						Label1.Text = "Session Lost... Please Login";
					} 
					catch (NullReferenceException) 
					{
						Label1.Text = "Connection Error !";
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

		protected void BTN_SUBMIT_Click(object sender, System.EventArgs e)
		{
			/***
			bool login = logic.ValidateLogin(TXT_USERNAME.Text, System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(TXT_PASSWORD.Text, "sha1"), conn);
			if (login)
			{	
				AddSession();
				conn.QueryString = "update scuser set su_logon='1' where userid='" + TXT_USERNAME.Text + "'";
				conn.ExecuteQuery();
				FormsAuthentication.RedirectFromLoginPage(TXT_USERNAME.Text, false);
				Response.Redirect("main.html");
			}
			***/	

			//--- Modified By Yudi (2004-08-27) ----------
			/***
			 * Periksa apakah user active/inactive
			 ***/			
			if (!isActive(TXT_USERNAME.Text.Trim())) 
			{
				Label1.Text = "User is not active!";				
			}
			else 
			{			
				int flag = logic.ValidateLogin(TXT_USERNAME.Text, System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(TXT_PASSWORD.Text, "sha1"), conn);
				if (flag == 0)
					Label1.Text = "Invalid Username/Password";
				else if (flag == 1 || flag == 2)
				{
					AddSession();
					conn.QueryString = "update scuser set su_logon='1' where userid='" + TXT_USERNAME.Text + "'";
					conn.ExecuteNonQuery();

					FormsAuthentication.RedirectFromLoginPage(TXT_USERNAME.Text, false);
					//FormsAuthentication.SetAuthCookie(TXT_USERNAME.Text, false);

					Response.Redirect("main.html");
				}
					/*
					else if (flag == 2)sdfasfdasdfasfd
						Label1.Text = "User: " + TXT_USERNAME.Text + " is currently logged in!";
					*/
				else if (flag == 3)
					Label1.Text = "User: " + TXT_USERNAME.Text + " is locked!";
			}
		}

		private bool isActive(string userid) 
		{
			//--- Modified By Yudi (2004-08-27) ----------
			/***
			 * Periksa apakah user active/inactive
			***/			
			conn.QueryString = "select SU_ACTIVE from SCUSER where USERID='" + userid + "'";
			try 
			{
				conn.ExecuteQuery();
			} 
			catch  (NullReferenceException)
			{
				throw new NullReferenceException ("Server Error !");
			}

			bool isActive = false;
			if (conn.GetFieldValue("SU_ACTIVE") == "1") isActive = true;

			return isActive;
		}

		private void AddSession()
		{
			conn.QueryString = "SELECT * FROM VW_SESSION WHERE USERID='" + TXT_USERNAME.Text + "'";
			conn.ExecuteQuery();
			//conn2.QueryString = "SELECT * FROM VW_SESSION WHERE USERID='" + TXT_USERNAME.Text + "'";
			//conn2.ExecuteQuery();
			Session.Add("UserID", conn.GetFieldValue("USERID"));
			Session.Add("GroupID", conn.GetFieldValue("GROUPID"));
			Session.Add("GroupName", conn.GetFieldValue("SG_GRPNAME"));
			Session.Add("FullName", conn.GetFieldValue("SU_FULLNAME"));
			Session.Add("BranchID", conn.GetFieldValue("SU_BRANCH"));
			Session.Add("BranchName", conn.GetFieldValue("BRANCH_NAME"));
			Session.Add("AreaID", conn.GetFieldValue("AREAID"));
			Session.Add("AreaName", conn.GetFieldValue("AREANAME"));
			Session.Add("LoginTime", System.DateTime.Now.ToString());
			Session.Add("BussUnit", conn.GetFieldValue("SG_BUSSUNITID"));
			Session.Add("CBC", conn.GetFieldValue("CBC_CODE"));
			Session.Add("Connection", conn);
			Session.Add("Connection2", conn2);
			//Session.Add("Connection2", conn2);
			Session.Add("ConnString", ConfigurationSettings.AppSettings["conn"]);
		}
	}
}
