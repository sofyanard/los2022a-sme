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
	/// Summary description for RptPosisiAgunan.
	/// </summary>
	public partial class RptPosisiAgunan : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				DDL_BRANCH.Items.Add(new ListItem("-- Pilih --", ""));
				fillBusinessUnit();
				fillArea();
				//fillBranch();
				fillCollateral();
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
			Conn.QueryString = "select bussunitid, bussunitdesc from rfbusinessunit where active='1' order by bussunitid";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_BUSINESSUNIT.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}
		}

		private void fillCollateral()
		{
			DDL_COLLATERAL.Items.Clear();
			DDL_COLLATERAL.Items.Add(new ListItem("-- PILIH --",""));
			Conn.QueryString = "select coltypeseq, coltypedesc from RFCOLLATERALTYPE where active='1'";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_COLLATERAL.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}
		}

		private void fillArea () 
		{
			DDL_AREA.Items.Clear();
			DDL_AREA.Items.Add(new ListItem("-- PILIH --",""));
			Conn.QueryString = "select AREAID, AREANAME from rfarea where active ='1'";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_AREA.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}	
		}

		private void fillBranch() 
		{
			DDL_BRANCH.Items.Clear();
			DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));

			Conn.QueryString = "select branch_code, branch_name from rfbranch where active ='1' and areaid='" + DDL_AREA.SelectedValue + "' order by branch_name";
			
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_BRANCH.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}			
		}

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
			string branch			= DDL_BRANCH.SelectedValue;
			string collateral		= DDL_COLLATERAL.SelectedValue;

			LoadReport_Load(businessunit, area, branch, collateral);
		}

		private void LoadReport_Load(string businessunit, string area, string branch, string collateral)
		{
			string ReportAddr="";
			Conn.QueryString = "select reportaddr from app_parameter";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
			{
				ReportAddr = Conn.GetFieldValue(0,0);
			}
			else
			{
				ReportAddr  = "10.123.12.50";
			}
			
			ReportViewer1.ServerUrl = "http://" + ReportAddr + "/ReportServer";

			ReportViewer1.ReportPath = "/SMEReports/RptDashboardPosisiAgunan&businessunit=" + businessunit +  "&area=" + area + "&branch=" + branch + "&collateral=" + collateral + "&rs:Command=Render";
		}

		protected void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
		
		}

		protected void DDL_AREA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillBranch();
		}
	}
}
