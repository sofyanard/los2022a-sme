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

namespace SME.CEA
{
	/// <summary>
	/// Summary description for AcqInfoRekanan.
	/// </summary>
	public partial class AcqInfoRekanan : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();

		string theForm="";
		string theObj="";
	
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

		private void viewdata()
		{
			lbl_regnum.Text	= Request.QueryString["regnum"].ToString();
			lbl_rekananref.Text  = Request.QueryString["rekanan_ref"].ToString();
			lbl_userid.Text = Session["UserID"].ToString();
			//LBL_APRV.Text	= Request.QueryString["aprv"];

			conn.QueryString = "select acqinfo from application_rekanan where regnum = '"+lbl_regnum.Text+"'";
			conn.ExecuteQuery();
			txt_acqinfo.Text = conn.GetFieldValue("acqinfo");

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

			try
			{
				conn.QueryString = "exec REKANAN_ACQUIRE_INFO '" + 
					//LBL_APRV.Text + "', '" +
					lbl_regnum.Text + "', '" +
					lbl_userid.Text + "', '" +
					txt_acqinfo.Text.Trim() + "'";
				conn.ExecuteQuery();
				string acquireInfoFrom_NAME = conn.GetFieldValue("ACQINFONAME");

				Response.Write("<script language='JavaScript1.2'>window.opener.document." + 
					theForm + "." + theObj + ".value='" + acquireInfoFrom_NAME + "'; " +
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
