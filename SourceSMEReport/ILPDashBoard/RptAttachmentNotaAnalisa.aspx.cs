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

namespace SME.SourceSMEReport.ILPDashBoard
{
	/// <summary>
	/// Summary description for RptAttachmentNotaAnalisa.
	/// </summary>
	public partial class RptAttachmentNotaAnalisa : System.Web.UI.Page
	{
		protected Connection conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				fillBusinessUnit();
				fillArea();
				//fillBranch();
				DDL_UNIT.Items.Add(new ListItem("-- PILIH --", ""));
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

		private void fillBusinessUnit()
		{
			DDL_BUSINESSUNIT.Items.Clear();
			DDL_BUSINESSUNIT.Items.Add(new ListItem("-- PILIH --",""));
			conn.QueryString = "select bussunitid, bussunitdesc from rfbusinessunit where active='1' order by bussunitid";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_BUSINESSUNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
		}

		private void fillArea () 
		{
			DDL_AREA.Items.Clear();
			DDL_AREA.Items.Add(new ListItem("-- PILIH --",""));
			conn.QueryString = "select AREAID, AREANAME from rfarea where active ='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_AREA.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}	
		}

		protected void DDL_AREA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewUnit();
		}

		private void ViewUnit()
		{
			DDL_UNIT.Items.Clear();
			DDL_UNIT.Items.Add(new ListItem("-- PILIH --", ""));

			conn.QueryString = "select branch_code, branch_name from rfbranch " + 
				"where areaid='" + DDL_AREA.SelectedValue + 
				"' and active='1' order by branch_name";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		/*private void fillBranch() 
		{
			DDL_BRANCH.Items.Clear();
			DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));

			Conn.QueryString = "select branch_code, branch_name from rfbranch where active ='1'";
			
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_BRANCH.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}			
		}*/

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ILPDashboard.aspx?mc=" + Request.QueryString["mc"]);
		}

		protected void BTN_LIHAT_Click(object sender, System.EventArgs e)
		{
			LoadSql("");
		}

		private void LoadSql(string action)
		{
			string businessunit		= DDL_BUSINESSUNIT.SelectedValue;
			string area				= DDL_AREA.SelectedValue;
			string branch			= DDL_UNIT.SelectedValue;

			LoadReport_Load(businessunit, area, branch);
		}

		private void LoadReport_Load(string businessunit, string area, string branch)
		{
			string ReportAddr="";
			conn.QueryString = "select reportaddr from app_parameter";
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
			{
				ReportAddr = conn.GetFieldValue(0,0);
			}
			else
			{
				ReportAddr  = "10.123.12.50";
			}
			
			ReportViewer1.ServerUrl = "http://" + ReportAddr + "/ReportServer";

			ReportViewer1.ReportPath = "/SMEReports/RptDashboardAttachNotaAnalisa&businessunit=" + businessunit +  "&areaid=" + area + "&branch_code=" + branch + "&rs:Command=Render";
		}

		protected void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
		
		}

		
	}
}
