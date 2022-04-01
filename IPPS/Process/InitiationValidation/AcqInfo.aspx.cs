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
using System.Configuration;
using DMS.DBConnection;
using DMS.CuBESCore;
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;

namespace SME.IPPS.Process.InitiationValidation
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
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (Request.QueryString.Count > 0)
			{	
				theForm = Request.QueryString["theForm"];
				theObj = Request.QueryString["theObj"];
			}	

			if (!IsPostBack)
			{
				viewdata();
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
		
		private void viewdata()
		{
			lbl_regno.Text	= Request.QueryString["regno"].ToString();
			lbl_userid.Text = Session["UserID"].ToString();

			conn.QueryString = "select acqinfo from ipps_application where ipps_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();
			txt_acqinfo.Text = conn.GetFieldValue("acqinfo");

			
		}

		protected void btn_send_Click(object sender, System.EventArgs e)
		{
			string msg="";
			
				try
				{
					conn.QueryString = "exec IPPS_SENDMESSAGE '" + 
						Request.QueryString["regno"] + "', '" +
						lbl_userid.Text + "', '" +
						txt_acqinfo.Text+ "', '" +
						Request.QueryString["tcnext"] + "', '" +
						Request.QueryString["nextuser"] +"'";
					conn.ExecuteQuery();

					if (conn.GetRowCount() > 0)
					{
						msg = conn.GetFieldValue("MSG");
					}
					
//					Response.Write("<script language='JavaScript1.2'>window.opener.document." + 
//						theForm + "." + theObj + ".value='" + msg + "'; " +
//						"window.opener.document." + theForm + ".submit(); </script>");
//			
					Response.Write("<script language='JavaScript1.2'>window.opener.document." + 
						theForm + "." + theObj + ".value='" + msg + "'; " +
						"window.opener.document." + theForm + ".submit(); </script>");
				}
				catch (Exception ex)
				{
					Response.Write("<!--" + ex.Message + "-->");
					return;
				}
			
		}

		private void BTN_CLOSE_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='JavaScript1.2'>window.close();</script>");
		}
	}
}
