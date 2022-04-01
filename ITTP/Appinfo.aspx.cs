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
namespace SME.ITTP
{
	/// <summary>
	/// Summary description for Appinfo.
	/// </summary>
	public partial class Appinfo : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
			
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				ViewData();
				secureData();
			}
		}

		private void secureData() 
		{
			LBL_STA.Text = Request.QueryString["sta"];
			if (LBL_STA.Text.ToUpper() == "VIEW") 
			{
				TXT_CU_CIF.ReadOnly = true;
				TXT_CU_NAME.ReadOnly = true;
				TXT_CU_IDTYPE.ReadOnly = true;
				TXT_CU_IDNUM.ReadOnly = true;
				txt_addr.ReadOnly = true;
				TXT_AP_REGNO.ReadOnly = true;
				TXT_AP_SIGNDATE.ReadOnly = true;
				TXT_AP_RELMNGR.ReadOnly = true;
				TXT_TL.ReadOnly = true;
				TXT_BRANCH_NAME.ReadOnly = true;


				TXT_CU_CIF.BorderStyle = BorderStyle.None;
				TXT_CU_NAME.BorderStyle = BorderStyle.None;
				TXT_CU_IDTYPE.BorderStyle = BorderStyle.None;
				TXT_CU_IDNUM.BorderStyle = BorderStyle.None;
				txt_addr.BorderStyle = BorderStyle.None;
				TXT_AP_REGNO.BorderStyle = BorderStyle.None;
				TXT_AP_SIGNDATE.BorderStyle = BorderStyle.None;
				TXT_AP_RELMNGR.BorderStyle = BorderStyle.None;
				TXT_TL.BorderStyle = BorderStyle.None;
				TXT_BRANCH_NAME.BorderStyle = BorderStyle.None;

			}
		}

		private void ViewData()
		{
			TXT_AP_REGNO.Text		= Request.QueryString["regno"];
			lbl_curef.Text		= Request.QueryString["curef"];
			//lbl_prod.Text		= Request.QueryString["prod"];
			lbl_track.Text		= Request.QueryString["tc"];
			DataTable dt		= new DataTable();
			conn.QueryString	= "select * from vw_it_viewdata2 where ap_regno = '"+TXT_AP_REGNO.Text+"'";
			conn.ExecuteQuery();
			dt	= conn.GetDataTable().Copy();
			TXT_CU_CIF.Text		= conn.GetFieldValue("cu_cif");
			TXT_CU_NAME.Text	= conn.GetFieldValue("nama");
			txt_addr.Text		= conn.GetFieldValue("addr");
			TXT_CU_IDTYPE.Text	= conn.GetFieldValue("idtype");
			TXT_CU_IDNUM.Text	= conn.GetFieldValue("idnum");
			TXT_AP_SIGNDATE.Text	= tool.FormatDate(conn.GetFieldValue("ap_signdate"), false);
			TXT_TL.Text = conn.GetFieldValue("ap_teamleader");
			TXT_AP_RELMNGR.Text	= conn.GetFieldValue("su_fullname");
			TXT_BRANCH_NAME.Text		= conn.GetFieldValue("branch_name");

			//----- mendapatkan analyst
			/*conn.QueryString = "select * from CREDITANALYSIS where ap_regno = '" + lbl_regno.Text + "'";
					conn.ExecuteQuery();
					if (conn.GetRowCount() > 0) txt_analis.Text = conn.GetFieldValue("analyst");*/
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
