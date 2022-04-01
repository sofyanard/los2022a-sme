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

namespace SME.CreditOperations.RejectMaintenance
{
	/// <summary>
	/// Summary description for DTBO.
	/// </summary>
	public partial class DTBO : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected Tools tool = new Tools();
		protected Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_TC.Text = Request.QueryString["tc"];

				conn.QueryString = "select case when CU_JNSNASABAH = 'A' then CU_JNSNASABAH else 'B' end CU_JNSNASABAH from customer where cu_ref = '"+LBL_CUREF.Text+"'";
				conn.ExecuteQuery();
				string jnsnasabah = conn.GetFieldValue("CU_JNSNASABAH");
				conn.QueryString = "exec DTBO_MDTRY '"+ LBL_REGNO.Text +"', '"+ LBL_CUREF.Text +"','"+ jnsnasabah +"' ";
				conn.ExecuteNonQuery();
				ViewData();

				HyperLink h1 = new HyperLink();
				h1.Text = "Dokumen Umum";
				h1.Font.Bold = true;
				h1.NavigateUrl = "../../DTBO/DocUmum.aspx?regno="+ LBL_REGNO.Text +"&curef="+ LBL_CUREF.Text +"&tc="+ LBL_TC.Text;
				h1.Target = "IFR_DTBO";

				HyperLink h2 = new HyperLink();
				h2.Text = "Dokumen Fasilitas";
				h2.Font.Bold = true;
				h2.NavigateUrl = "../../DTBO/DocFasilitas.aspx?regno="+ LBL_REGNO.Text +"&curef="+ LBL_CUREF.Text +"&tc="+ LBL_TC.Text;
				h2.Target = "IFR_DTBO";

				HyperLink h3 = new HyperLink();
				h3.Text = "Dokumen Jaminan";
				h3.Font.Bold = true;
				h3.NavigateUrl = "../../DTBO/DocJaminan.aspx?regno="+ LBL_REGNO.Text +"&curef="+ LBL_CUREF.Text +"&tc="+ LBL_TC.Text;
				h3.Target = "IFR_DTBO";

				PLH_DTBO.Controls.Add(h1);
				PLH_DTBO.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
				PLH_DTBO.Controls.Add(h2);
				PLH_DTBO.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
				PLH_DTBO.Controls.Add(h3);
				PLH_DTBO.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
			}
		}

		private void ViewData()
		{
			conn.QueryString = "select * from VW_DTBOCUINFO "+
				"where ap_regno = '"+ LBL_REGNO.Text +"'";
			conn.ExecuteQuery();
			
			TXT_BRANCH_NAME.Text = conn.GetFieldValue("BR_NAME");
			TXT_AP_RELMNGR.Text = conn.GetFieldValue("AP_RELMNGRNM");
			TXT_CU_NAME.Text = conn.GetFieldValue("CU_NAME");
			//TXT_SU_FULLNAME.Text = conn.GetFieldValue("BU");
			//TXT_BU.Text = conn.GetFieldValue("BU");
			TXT_AP_REGNO.Text = conn.GetFieldValue("AP_REGNO");
			TXT_AP_SIGNDATE.Text = tool.FormatDate_GetDate(conn.GetFieldValue("AP_SIGNDATE"));
			TXT_PROGRAMDESC.Text = conn.GetFieldValue("PROG_DESC");
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
