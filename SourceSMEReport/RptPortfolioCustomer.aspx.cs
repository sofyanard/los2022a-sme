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
	/// Summary description for RptPortfolioCustomer.
	/// </summary>
	public partial class RptPortfolioCustomer : System.Web.UI.Page
	{

		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			Conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				DDL_SEGMENT.Items.Add(new ListItem("-- PILIH --",""));
				Conn.QueryString = "select BUSSUNITID, BUSSUNITDESC from rfbusinessunit where active='1'";
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
					DDL_SEGMENT.Items.Add(new ListItem(Conn.GetFieldValue(i,1), Conn.GetFieldValue(i,0)));

				DDL_INDUSTRY_NAME.Items.Add(new ListItem("-- PILIH --",""));
				Conn.QueryString = "select PD_INDUSTRY_NAMECD, PD_INDUSTRY_NAME from PD_RF_INDUSTRY_CLASS where active='1' order by convert(int,PD_INDUSTRY_NAMECD)";
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
					DDL_INDUSTRY_NAME.Items.Add(new ListItem(Conn.GetFieldValue(i,0) + " - " + Conn.GetFieldValue(i,1), Conn.GetFieldValue(i,0)));
				
				fillBUC();


			}
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		#region My Method 

		private void fillBUC()
		{
			DDL_BUC.Items.Clear();
			Conn.QueryString = "select DEPT_CODE, DEPT_DESC from  rfdepartmentcode where BUSSUNITID='" + DDL_SEGMENT.SelectedValue + "'and active='1'";
			if(DDL_SEGMENT.SelectedValue != "")
			{
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					DDL_BUC.Items.Add(new ListItem(Conn.GetFieldValue(i,0) + " - " + Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
			}
		}

		#endregion
		////////////////////////////////////////////////////////////////////////////////////////////////////

		private void LoadReport_Load(string industry, string segment, string buc)
		{	
			string ReportAddr="", kriterianya="", tanggal1_k="", tanggal2_k="";

			Conn.QueryString = "select reportaddr from app_parameter";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
				ReportAddr = Conn.GetFieldValue(0,0);
			else
				ReportAddr  = "10.123.12.50";
			
			ReportViewer1.ServerUrl = "http://" + ReportAddr + "/ReportServer";

			//kriterianya += "AND (convert(nvarchar, TgApplikasi, 112) between " + tanggal1_k + " and " + tanggal2_k + ") ";
			/*
						if (!industry.Equals(""))
						{
							kriterianya += "(PD_INDUSTRY_NAMECD = '" + industry + "') ";
						}
						if (!segment.Equals(""))     
						{
							kriterianya += " AND (BUSSUNITID = '" + segment + "') ";
						}
						if (!buc.Equals(""))     
						{
							kriterianya += " AND (PD_BUC_CD = '" + buc + "') ";
						}
			*/
			ReportViewer1.ReportPath = "/SMEReports/RptPortfolioCustomer&industry=" + industry + "&segment=" + segment +  "&buc=" + buc + "&rs:Command=Render&rc:Toolbar=True";
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
			string segment	= DDL_SEGMENT.SelectedValue;
			string buc		= DDL_BUC.SelectedValue;

			LoadReport_Load(industry, segment, buc);
		}

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportPortfolio.aspx?mc=" + Request.QueryString["mc"]);
		}

		protected void DDL_SEGMENT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DDL_BUC.Items.Clear();
			Conn.QueryString = "select DEPT_CODE, DEPT_DESC from  rfdepartmentcode where BUSSUNITID='"+DDL_SEGMENT.SelectedValue+"'and active='1' order by dept_desc";
			DDL_BUC.Items.Add(new ListItem("-- PILIH --",""));
			if(DDL_SEGMENT.SelectedValue != "")
			{
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					DDL_BUC.Items.Add(new ListItem(Conn.GetFieldValue(i,0) + " - " + Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
			}
		}
	}
}