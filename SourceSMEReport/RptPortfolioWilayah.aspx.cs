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
using Microsoft.VisualBasic;
namespace SME.SourceSMEReport
{
	/// <summary>
	/// Summary description for RptPortfolioWilayah.
	/// </summary>
	public partial class RptPortfolioWilayah : System.Web.UI.Page
	{

		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				DDL_WILAYAH.Items.Add(new ListItem("-- PILIH --",""));
				Conn.QueryString = "select BI_SEQ, convert(varchar,BI_SEQ) +'-'+ BI_DESC as BI_DESC from rfbicode where bg_group = '4' and active = '1'";
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
					DDL_WILAYAH.Items.Add(new ListItem(Conn.GetFieldValue(i,1), Conn.GetFieldValue(i,0)));

				DDL_INDUSTRY_NAME.Items.Add(new ListItem("-- PILIH --",""));
				Conn.QueryString = "select PD_INDUSTRY_NAMECD, PD_INDUSTRY_NAME from PD_RF_INDUSTRY_CLASS where active='1' order by convert(int,PD_INDUSTRY_NAMECD)";
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
					DDL_INDUSTRY_NAME.Items.Add(new ListItem(Conn.GetFieldValue(i,0) + " - " + Conn.GetFieldValue(i,1), Conn.GetFieldValue(i,0)));
			}
		}

		private void LoadReport_Load(string industry, string wilayah)
		{	
			string ReportAddr="", kriterianya="";

			Conn.QueryString = "select reportaddr from app_parameter";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
				ReportAddr = Conn.GetFieldValue(0,0);
			else
				ReportAddr  = "10.123.12.50";
			
			ReportViewer1.ServerUrl = "http://" + ReportAddr + "/ReportServer";

			ReportViewer1.ReportPath = "/SMEReports/RptPortfolioWilayah&industry=" + industry + "&wilayah=" + wilayah + "&rs:Command=Render&rc:Toolbar=True";
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

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			LoadSql("");
		}

		private void LoadSql(string action)
		{
			string industry	= DDL_INDUSTRY_NAME.SelectedValue;
			string wilayah	= DDL_WILAYAH.SelectedValue;

			LoadReport_Load(industry, wilayah);
		}

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportPortfolio.aspx?mc=" + Request.QueryString["mc"]);
		}
	}
}
