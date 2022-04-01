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
namespace SME.SPPK
{
	/// <summary>
	/// Summary description for AppInfo. Blahhhh!
	/// </summary>
	public partial class AppInfo : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SME;uid=sa;pwd=");
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
				txt_addr.ReadOnly = true;
				txt_analis.ReadOnly = true;
				txt_branch.ReadOnly = true;
				txt_busunit.ReadOnly = true;
				txt_city.ReadOnly = true;
				txt_curef.ReadOnly = true;
				txt_jobarea.ReadOnly = true;
				txt_nama.ReadOnly = true;
				txt_phnarea.ReadOnly = true;
				txt_phnnum.ReadOnly = true;
				txt_regno.ReadOnly = true;
				txt_relmngr.ReadOnly = true;
				txt_signdate.ReadOnly = true;
				txt_teamleader.ReadOnly = true;
				txt_zipcode.ReadOnly = true;				

				txt_addr.BorderStyle = BorderStyle.None;
				txt_analis.BorderStyle = BorderStyle.None;
				txt_branch.BorderStyle = BorderStyle.None;
				txt_busunit.BorderStyle = BorderStyle.None;
				txt_city.BorderStyle = BorderStyle.None;
				txt_curef.BorderStyle = BorderStyle.None;
				txt_jobarea.BorderStyle = BorderStyle.None;
				txt_nama.BorderStyle = BorderStyle.None;
				txt_phnarea.BorderStyle = BorderStyle.None;
				txt_phnnum.BorderStyle = BorderStyle.None;
				txt_regno.BorderStyle = BorderStyle.None;
				txt_relmngr.BorderStyle = BorderStyle.None;
				txt_signdate.BorderStyle = BorderStyle.None;
				txt_teamleader.BorderStyle = BorderStyle.None;
				txt_zipcode.BorderStyle = BorderStyle.None;				

			}
		}

		private void ViewData()
		{
			lbl_regno.Text		= Request.QueryString["regno"];
			lbl_curef.Text		= Request.QueryString["curef"];
			lbl_prod.Text		= Request.QueryString["prod"];
			lbl_track.Text		= Request.QueryString["tc"];
			DataTable dt		= new DataTable();
			conn.QueryString	= "select * from vw_viewdata where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();
			dt	= conn.GetDataTable().Copy();
			txt_nama.Text		= conn.GetFieldValue("nama");
			txt_addr.Text		= conn.GetFieldValue("addr");
			txt_city.Text		= conn.GetFieldValue("cityname");
			txt_zipcode.Text	= conn.GetFieldValue("zipcode");
			txt_phnarea.Text	= conn.GetFieldValue("phnarea");
			txt_phnnum.Text		= conn.GetFieldValue("phnnum");
			txt_jobarea.Text	= conn.GetFieldValue("busstypedesc");
			txt_signdate.Text	= tool.FormatDate(conn.GetFieldValue("ap_signdate"), false);
			txt_regno.Text		= conn.GetFieldValue("ap_regno");
			txt_curef.Text		= conn.GetFieldValue("cu_ref");
			txt_branch.Text		= conn.GetFieldValue("branch_name");
			txt_teamleader.Text = conn.GetFieldValue("ap_teamleader");
			txt_relmngr.Text	= conn.GetFieldValue("su_fullname");
			txt_analis.Text		= conn.GetFieldValue("analyst");
			txt_busunit.Text	= conn.GetFieldValue("bussunitdesc");

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
