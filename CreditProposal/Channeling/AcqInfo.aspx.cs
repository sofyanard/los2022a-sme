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

namespace  SME.CreditProposal.Channeling
{
	/// <summary>
	/// Summary description for AcqInfo.
	/// </summary>
	public partial class AcqInfo : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();

		string theForm = "";
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

//			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
//				Response.Redirect("/SME/Restricted.aspx");

			if (Request.QueryString.Count > 0)
			{	
				theForm = Request.QueryString["theForm"];
			}	

			if (!IsPostBack)
			{
				
			}

			viewdata();
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
			txt_acqinfo.Text	= Request.QueryString["pesan"].ToString();
		}

		protected void btn_send_Click(object sender, System.EventArgs e)
		{

		}

		private void BTN_CLOSE_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='JavaScript1.2'>window.close();</script>");
		}

		private void Button1_ServerClick(object sender, System.EventArgs e)
		{
			Response.Write("<script language='JavaScript1.2'>window.close();</script>");
		}
	}
}
