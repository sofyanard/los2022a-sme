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
using System.Configuration;

namespace SME.DCM.DataCompleteness
{
	/// <summary>
	/// Summary description for CandMEXIMBILL.
	/// </summary>
	public partial class CandMEXIMBILL : System.Web.UI.Page
	{
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if(!IsPostBack)
			{
				FillDDLUnit();
				FillDDLStatus();
			}
		}

		private void FillDDLUnit()
		{
			DDL_UNIT.Items.Clear();
			DDL_UNIT.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "select DEPT_CODE, DEPT_DESC from  rfdepartmentcode order by dept_desc";
			conn.ExecuteQuery();
			
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLStatus()
		{
			DDL_STATUS.Items.Clear();
			DDL_STATUS.Items.Add(new ListItem("-- PILIH --",""));
			DDL_STATUS.Items.Add(new ListItem("DATA ERROR","DATA ERROR"));
			DDL_STATUS.Items.Add(new ListItem("NULL","NULL"));
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

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			string unit = DDL_UNIT.SelectedValue;
			string status = DDL_STATUS.SelectedValue;

			LoadReport_Load(unit, status);
		}

		private void LoadReport_Load(string unit, string status)
		{
			string ReportAddr = "";

			conn2.QueryString = "SELECT REPORTADDR FROM APP_PARAMETER";
			conn2.ExecuteQuery();
			if(conn2.GetRowCount() > 0)
			{
				ReportAddr = conn2.GetFieldValue(0,0);
			}
			else
			{
				ReportAddr = "10.123.12.50";
			}

			Reportviewer1.ServerUrl = "http://" + ReportAddr + "/ReportServer";
			Reportviewer1.ReportPath = "/SMEReports/RptCandMEXIMBILL&unit=" + unit + "&status=" + status + "&rs:Command=Render";
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			DDL_UNIT.SelectedValue = "";
			DDL_STATUS.SelectedValue = "";
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ControlAndMonitoring.aspx?mc=" + Request.QueryString["mc"]);
		}
	}
}
