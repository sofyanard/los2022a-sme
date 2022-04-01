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
using System.Configuration;
using System.Web.Security;

namespace SME
{
	/// <summary>
	/// Summary description for authenticate.
	/// </summary>
	public partial class authenticate : System.Web.UI.Page
	{
		protected Connection connESecurity = new Connection(ConfigurationSettings.AppSettings["eSecurityConnectString"]);
		protected Connection conn;
		protected string token;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			string connectionString;

			connESecurity.QueryString = "select * from VW_ES_APPTOKEN where token = '" + Request.QueryString["tkn"] + "'";
			connESecurity.ExecuteQuery();

			if (connESecurity.GetRowCount() > 0)
			{
				FormsAuthentication.SignOut();
				FormsAuthentication.SetAuthCookie(connESecurity.GetFieldValue(0, "userid"), false);

				Session.Remove("UserID");
				Session.Remove("FullName");
				Session.Remove("GroupID");
				Session.Remove("BranchID");
				Session.Remove("AreaID");
				Session.Remove("CBC");
				Session.Remove("PWD");

				Session.Add("UserID", connESecurity.GetFieldValue("USERID"));
				Session.Add("FullName", connESecurity.GetFieldValue("FULLNAME"));
				Session.Add("GroupID", connESecurity.GetFieldValue("GROUPID"));
				Session.Add("BranchID", connESecurity.GetFieldValue("BRANCHID"));
				Session.Add("AreaID", connESecurity.GetFieldValue("AREAID"));
				Session.Add("CBC", connESecurity.GetFieldValue("CBC"));
				Session.Add("PWD", connESecurity.GetFieldValue("PWD"));

				connectionString = ConfigurationSettings.AppSettings["connectionString"] + Session["UserID"].ToString() + ";pwd=" + Session["PWD"].ToString() + ";Pooling=true";
				Session.Add("ConnString", connectionString);

				connESecurity.QueryString = "select db_ip, db_nama, db_loginid, db_loginpwd from rfmodule where moduleid = '" + ConfigurationSettings.AppSettings["ModuleID"] + "'";
				connESecurity.ExecuteQuery();

				connectionString = "Data Source=" + connESecurity.GetFieldValue(0, "db_ip") + ";Initial Catalog=" + connESecurity.GetFieldValue(0, "db_nama") + ";uid=" + connESecurity.GetFieldValue(0, "db_loginid") + ";pwd=" + connESecurity.GetFieldValue(0, "db_loginpwd") + ";Pooling=true";
				Session.Add("ConnString", connectionString);

				connESecurity.QueryString = "exec ES_APPTOKEN_DELETE '" + Request.QueryString["tkn"] + "'";
				connESecurity.ExecuteNonQuery();

				conn = new Connection(connectionString);
				Session.Add("Connection", conn);
				AddSession(Session["UserID"].ToString());

				Response.Redirect("main.html");
			}
			else
			{
				connESecurity.QueryString = "select top 1 login_scr from rfmodule";
				connESecurity.ExecuteQuery();
				Response.Redirect(connESecurity.GetFieldValue(0, "login_scr"));
			}
		}

		private void AddSession(string USERID)
		{
			conn.QueryString = "SELECT * FROM VW_SESSION WHERE USERID='" + USERID + "'";
			conn.ExecuteQuery();
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
			//Session.Add("Connection", conn);
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
