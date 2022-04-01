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
namespace SME
{
	/// <summary>
	/// Summary description for PortfolioGuidelineInfo.
	/// </summary>
	public partial class PortfolioGuidelineInfo : System.Web.UI.Page
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
			TXT_OUTSTANDING.ReadOnly = true;
			TXT_PENDING.ReadOnly = true;
			TXT_AVAILABLE.ReadOnly = true;
			TXT_INDUSTRYCLASS.ReadOnly = true;
			TXT_STATUS.ReadOnly = true;
			TXT_RATIO_LIMIT.ReadOnly = true;
			TXT_RATIO_AVAIL.ReadOnly = true;
		}

		private void ViewData()
		{
			//lbl_ksebi4.Text				= Request.QueryString["ksebi"];
			lbl_ksebi4.Text = ((System.Web.UI.WebControls.TextBox)this.Parent.Page.FindControl("RISAN")).Text.ToString();

			DataTable dt				= new DataTable();
			conn.QueryString			= "exec PORTFOLIO_LIMIT '"+lbl_ksebi4.Text+"'";
			conn.ExecuteQuery();
			dt							= conn.GetDataTable().Copy();
			TXT_OUTSTANDING.Text		= conn.GetFieldValue("OUT_BAL");
			TXT_PENDING.Text			= conn.GetFieldValue("PENDING_LIMIT");
			TXT_AVAILABLE.Text			= conn.GetFieldValue("AVAILABLE_LIMIT");
			TXT_RATIO_LIMIT.Text		= conn.GetFieldValue("RATIO_LIMIT");
			TXT_RATIO_AVAIL.Text		= conn.GetFieldValue("AVAILABLE_RATIO");
			TXT_INDUSTRYCLASS.Text		= conn.GetFieldValue("PD_INDUSTRYCLASS_DESC");
			//TXT_STATUS.Text				= conn.GetFieldValue("nama");
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