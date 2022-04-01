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

namespace SME.Verificator
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

//			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
//				Response.Redirect("/SME/Restricted.aspx");

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
			lbl_curef.Text  = Request.QueryString["curef"].ToString();
			lbl_userid.Text = Session["UserID"].ToString();
			LBL_APRV.Text	= Request.QueryString["aprv"];

			conn.QueryString = "select ap_acqinfo from application where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();
			txt_acqinfo.Text = conn.GetFieldValue("ap_acqinfo");

			if (Request.QueryString["sta"] == "view") 
			{
				txt_acqinfo.ReadOnly = true;
				btn_send.Visible = false;
				//BTN_CLOSE.Visible = false;
			}
		}

		protected void btn_send_Click(object sender, System.EventArgs e)
		{
			if (txt_acqinfo.Text.Trim().Length <= 1) 
			{
				GlobalTools.popMessage(this, "Informasi tidak boleh kosong (min 2 karaketer)!");
				return;
			}

			//mengambil rm aplikasi ybs
			string acquireInfoFrom = "";
			string acquireInfoFrom_NAME = "";

			conn.QueryString = "select ap_relmngr, scuser.su_fullname " + 
				" from application left join scuser on application.ap_relmngr = scuser.userid " + 
				" where ap_regno = '" + lbl_regno.Text + "'";
			conn.ExecuteQuery();
			acquireInfoFrom = conn.GetFieldValue("ap_relmngr");
			acquireInfoFrom_NAME = conn.GetFieldValue("su_fullname");

			conn.QueryString = "exec VERIFICATOR_ACQUIREINFO '" + Request.QueryString["regno"] + "', '" + Session["USERID"].ToString() + "', '" +
				txt_acqinfo.Text + "'";
			conn.ExecuteNonQuery();

			//----------------- Start AUDIT TRAIL ----------------------
			string trackname = "";
			conn.QueryString = "exec SP_AUDITTRAIL_TRACKNAMEAPPRV '" + lbl_regno.Text + "'";
			conn.ExecuteQuery();
			trackname = conn.GetFieldValue("TRACKNAME");

			try 
			{ 
				conn.QueryString = "exec SP_AUDITTRAIL_APP '" + 
					lbl_regno.Text + "', NULL, NULL, NULL, '" + 
					lbl_curef.Text + "', NULL, " + 
					"'Acquire Information ...', '" + "', '" + 
					lbl_userid.Text + "', NULL, 'N', '" + 
					trackname + "'";
				conn.ExecuteNonQuery();
			} 
			catch 
			{ }
			//----------------- End AUDIT TRAIL ----------------------

			Response.Write("<script language='JavaScript1.2'>window.opener.document." + 
				theForm + "." + theObj + ".value='" + acquireInfoFrom_NAME + "'; " +
				"window.opener.document." + theForm + ".submit(); </script>");
		}

		private void BTN_CLOSE_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='JavaScript1.2'>window.close();</script>");
		}
	}
}
