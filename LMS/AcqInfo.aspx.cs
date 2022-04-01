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
	/// Summary description for AcqInfo.
	/// </summary>
	public partial class AcqInfo : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		string theForm = "";
		string theObj = "";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (Request.QueryString.Count > 0)
			{	
				theForm = Request.QueryString["theForm"];
				theObj = Request.QueryString["theObj"];
			}

			if (!IsPostBack)
			{
				ViewData();
			}
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT LMS_ACQINFO FROM LMS_APPLICATION WHERE LMS_REGNO = '" + Request.QueryString["lmsreg"] + "'";
			conn.ExecuteQuery();
			txt_acqinfo.Text = conn.GetFieldValue("LMS_ACQINFO");
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

		protected void btn_send_Click(object sender, System.EventArgs e)
		{
			string msg = "";
			try
			{
				conn.QueryString = "exec LMS_ACQINFO_SAVE '" + 
					Request.QueryString["lmsreg"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "', '" +
					txt_acqinfo.Text + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					msg = conn.GetFieldValue("MSG");
				}

                Response.Write("<script language='JavaScript'>window.opener.document.getElementById('" +
                    theObj + "').value='" + msg + "'; " +
                    "window.opener.document.getElementById('" + theForm + "').submit(); window.close();</script>");
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}
	}
}
