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

namespace SME.Facilities
{
	/// <summary>
	/// Summary description for ChangePassword.
	/// </summary>
	public partial class ChangePassword : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = new Connection(ConfigurationSettings.AppSettings["eSecurityConnectString"]);			

//			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
//				Response.Redirect("/SME/Restricted.aspx");
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

		protected void btn_Change_Click(object sender, System.EventArgs e)
		{
			string newPassword = "", oldPassword = "";

			oldPassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txt_OldPwd.Text.Trim(), "sha1");
			conn.QueryString = "select su_pwd from scalluser where userid = '" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			if (oldPassword == conn.GetFieldValue(0, "su_pwd"))
			{
				if (txt_NewPwd.Text.Trim() != txt_ConfirmPwd.Text.Trim())
				{
					Message.Text = "Password mismatch!";
					Clear();
				}
				else
				{
					newPassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txt_NewPwd.Text, "sha1");
					conn.QueryString = "select db_ip, db_nama, db_loginid, db_loginpwd, dbo.ispwdvalid('" +
						Session["UserID"].ToString() + "', '" +
						txt_NewPwd.Text.Trim() + "', '" +
						newPassword + "') msg from rfmodule ";
					conn.ExecuteQuery();

					if (conn.GetFieldValue(0, "msg") != "")
					{
						Message.Text = conn.GetFieldValue(0, "msg");
						Clear();
					}
					else
					{
						conn.QueryString = "exec SU_SCALLUSERPASSWORD '" + Session["UserID"] + "', '" + newPassword + "'";
						conn.ExecuteNonQuery();

						for (int i = 0; i < conn.GetRowCount(); i++)
						{
							try
							{
								string connectionString = "Data Source=" + conn.GetFieldValue(i, "db_ip") +
									";Initial Catalog=" + conn.GetFieldValue(i, "db_nama") +
									";uid=" + conn.GetFieldValue(i, "db_loginid") +
									";pwd=" + conn.GetFieldValue(i, "db_loginpwd");
								Connection lclConn = new Connection(connectionString);
								lclConn.QueryString = "exec SU_SCUSERPASSWORD '" + Session["UserID"] + "', '" + newPassword + "'";
								lclConn.ExecuteNonQuery();
							}
							catch {}
						}

						Message.Text = "";
						Clear();
						Response.Write("<script for=window event=onload language=javascript>\n"+
							"alert('Password Updated!');</script>");
					}
				}
			}
			else
			{
				Message.Text = "Old Password invalid!";
				Clear();
			}
		}

		private void Clear()
		{
			txt_OldPwd.Text = "";
			txt_NewPwd.Text = "";
			txt_ConfirmPwd.Text = "";
		}
	}
}
