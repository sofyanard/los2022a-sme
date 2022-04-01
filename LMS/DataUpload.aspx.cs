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

namespace SME.LMS
{
	/// <summary>
	/// Summary description for DataUpload.
	/// </summary>
	public partial class DataUpload : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{

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

		protected void BTN_PROCESS_Click(object sender, System.EventArgs e)
		{
			BTN_PROCESS.Enabled = false;
			TXT_RESULT.Text = "Please Wait!!";

			try
			{
				conn.QueryString = "exec LMS_PROCESSUPLOADDATA ";
				conn.ExecuteQuery();
				string msg = conn.GetFieldValue("MSG");
				TXT_RESULT.Text = msg;
			}
			catch (Exception ex)
			{
				//Response.Write("<!--" + ex.Message + "-->");
				TXT_RESULT.Text = ex.Message;
			}
		}
	}
}
