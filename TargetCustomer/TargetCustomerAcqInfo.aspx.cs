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

namespace SME.TargetCustomer
{
	/// <summary>
	/// Summary description for TargetCustomerAcqInfo.
	/// </summary>
	public partial class TargetCustomerAcqInfo : System.Web.UI.Page
	{
		protected Connection conn;
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
				viewdata();
			}
		}

		private void viewdata()
		{
			lbl_trgcuref.Text = Request.QueryString["trgcuref"].ToString();
			lbl_aprv.Text = Request.QueryString["aprv"];

			conn.QueryString = "SELECT ACQINFO FROM TRG_CUSTOMER WHERE TRG_CU_REF = '" + lbl_trgcuref.Text + "'";
			conn.ExecuteQuery();
			txt_acqinfo.Text = conn.GetFieldValue("ACQINFO");
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
			if (txt_acqinfo.Text.Trim().Length <= 1) 
			{
				GlobalTools.popMessage(this, "Informasi tidak boleh kosong!");
				return;
			}

			try
			{
				conn.QueryString = "exec TARGETCUST_ACQINFO '" + 
					lbl_aprv.Text + "', '" +
					lbl_trgcuref.Text + "', '" +
					Session["UserID"].ToString() + "', '" +
					txt_acqinfo.Text.Trim() + "'";
				conn.ExecuteQuery();
				string acquireInfoFrom_NAME = conn.GetFieldValue("ACQINFONAME");

                Response.Write("<script language='JavaScript'>window.opener.document.getElementById('" +
                    theObj + "').value='" + acquireInfoFrom_NAME + "'; " +
                    "window.opener.document.getElementById('" + theForm + "').submit();window.close(); </script>");
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
				return;
			}
		}
	}
}
