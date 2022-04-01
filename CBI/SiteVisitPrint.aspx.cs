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

namespace SME.CBI
{
	/// <summary>
	/// Summary description for SiteVisit.
	/// </summary>
	public partial class SiteVisitPrint : System.Web.UI.Page
	{
//		protected System.Web.UI.WebControls.Button BTN_PRINT;	
		protected Connection conn;
		protected System.Web.UI.WebControls.Label label5;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{

			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{

//				DDL_SV_DATE_MONTH.Items.Add(new ListItem("- Select -", ""));
//				string nm_bln;
//				for (int i=1; i<=12; i++)
//				{
//					nm_bln = DateAndTime.MonthName(i, false);
//					DDL_SV_DATE_MONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
//				}
				ViewDataApplication();
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
		private void ViewDataApplication()
		{
			conn.QueryString = "select * from VW_CUST_FOR_SITEVISIT where AP_REGNO = '" +Request.QueryString["regno"]+ "'";
			conn.ExecuteQuery();
			LBL_AP_RELMNGR.Text		= conn.GetFieldValue("SU_FULLNAME");
			LBL_BRANCH_CODE.Text	= conn.GetFieldValue("BRANCH_NAME");
			LBL_CU_NAME.Text		= conn.GetFieldValue("CU_NAME");
			LBL_CU_ADDR.Text		= conn.GetFieldValue("CU_ADDR1") + " " + conn.GetFieldValue("CU_ADDR2") + " " + conn.GetFieldValue("CU_ADDR3");
			LBL_CU_CONTACTPERSON.Text	= conn.GetFieldValue("CU_CONTACTPERSON");
			LBL_GROUP_.Text	= conn.GetFieldValue("CU_GROUP");
			LBL_CREDIT_ANALIS_.Text	= conn.GetFieldValue("CREDIT_ANALIS");

			conn.QueryString = "select * from CUST_SITEVISIT where AP_REGNO = '" +Request.QueryString["regno"]+ "'";
			conn.ExecuteQuery();

			LBL_SV_DATE.Text        = 
				tool.FormatDate_Day(conn.GetFieldValue("SV_DATE")) + " " + 
				tool.FormatDate_MonthName(conn.GetFieldValue("SV_DATE")) + " " + 
				tool.FormatDate_Year(conn.GetFieldValue("SV_DATE"));
			LBL_SV_NAME.Text		= conn.GetFieldValue("SV_NAME");
			LBL_SV_TUJUAN.Text		= conn.GetFieldValue("SV_TUJUAN");
			LBL_SV_NASABAH.Text		= conn.GetFieldValue("SV_NASABAH");
			LBL_SV_BANK.Text		= conn.GetFieldValue("SV_BANK");
			LBL_SV_OFFICE.Text		= conn.GetFieldValue("SV_OFFICE");
			LBL_SV_FACTORY.Text		= conn.GetFieldValue("SV_FACTORY");
			LBL_SV_MANAGEMENT.Text  = conn.GetFieldValue("SV_MANAGEMENT");
			LBL_SV_PRODUKSI.Text	= conn.GetFieldValue("SV_PRODUKSI");
			LBL_SV_PEMASARAN.Text	= conn.GetFieldValue("SV_PEMASARAN");
			LBL_SV_KEUANGAN.Text	= conn.GetFieldValue("SV_KEUANGAN");
			LBL_SV_AGUNAN.Text		= conn.GetFieldValue("SV_AGUNAN");
			LBL_SV_PERSOALAN.Text	= conn.GetFieldValue("SV_PERSOALAN");
			LBL_SV_TARGETDATE.Text  = 
				tool.FormatDate_Day(conn.GetFieldValue("TG_DATE")) + " " + 
				tool.FormatDate_MonthName(conn.GetFieldValue("TG_DATE")) + " " + 
				tool.FormatDate_Year(conn.GetFieldValue("TG_DATE"));

		}

//		private void BTN_PRINT_Click(object sender, System.EventArgs e)
//		{
//			// Execution of Print		
//		}

	}
}
