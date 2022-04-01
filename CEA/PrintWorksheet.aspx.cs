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
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;
using DMS.BlackList;

namespace SME.CEA
{
	/// <summary>
	/// Summary description for PrintWorksheet.
	/// </summary>
	public partial class PrintWorksheet : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/../SME/Restricted.aspx");

			if(!IsPostBack)
			{
				ViewData();
			}

		}

		private void ViewData()
		{
			//conn.QueryString = "select namerekanan, address1 + ' ' + address2 + ' ' + city as address from rekanan where rekanan_ref='" + Request.QueryString["rekanan_Ref"] + "'";
			//conn.ExecuteQuery();

			conn.QueryString = "select rekanantypeid from rekanan where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();

			if(conn.GetFieldValue("rekanantypeid")=="01")
				conn.QueryString = "select namerekanan, address1 + ' ' + address2 + ' ' + city as address, rekanandesc from vw_rekanan_company where rekanan_ref='" + Request.QueryString["rekanan_Ref"] + "'";
			else
				conn.QueryString = "select namerekanan, address1 + ' ' + address2 + ' ' + city as address, rekanandesc from vw_rekanan_personal where rekanan_ref='" + Request.QueryString["rekanan_Ref"] + "'";

			conn.ExecuteQuery();


			LBL_ALAMAT.Text = conn.GetFieldValue("address");
			LBL_PERIHAL.Text = conn.GetFieldValue("rekanandesc");
			LBL_PERIHAL2.Text = conn.GetFieldValue("rekanandesc");
			LBL_NAMA.Text = conn.GetFieldValue("namerekanan");
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
