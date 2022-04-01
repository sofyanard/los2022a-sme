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
using System.Configuration;
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;

namespace SME.AccountPlanning.Dashboard
{
	/// <summary>
	/// Summary description for DashboardReport.
	/// </summary>
	public partial class DashboardReport : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				DDL_ANCHOR.Items.Add(new ListItem("--Select--",""));
				DDL_GROUP.Items.Add(new ListItem("--Select--",""));
				DDL_BLN.Items.Add(new ListItem("-- Select --",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_BLN.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
				FillAnchor();
				FillGroup();
				
				DDL_TYPE.Items.Add(new ListItem("-- Select --",""));
				DDL_TYPE.Items.Add(new ListItem("VOLUME","VOLUME"));
				DDL_TYPE.Items.Add(new ListItem("INCOME","INCOME"));
			}
		}

		private void FillAnchor()
		{
			DDL_ANCHOR.Items.Clear();
			DDL_ANCHOR.Items.Add(new ListItem("--Select--",""));

			conn.QueryString = "SELECT DISTINCT CIF#, CUSTOMER_GROUP FROM AP_ANCHOR_INFO WHERE ACTIVE='1' ORDER BY CUSTOMER_GROUP";
			conn.ExecuteQuery();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_ANCHOR.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillGroup()
		{
			DDL_GROUP.Items.Clear();
			DDL_GROUP.Items.Add(new ListItem("--Pilih--",""));

			conn.QueryString = "SELECT DISTINCT * FROM RFBUSINESSUNIT WHERE ACTIVE='1' ORDER BY BUSSUNITDESC";
			conn.ExecuteQuery();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_GROUP.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
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

		protected void BTN_Find_Click(object sender, System.EventArgs e)
		{
			string type			= DDL_TYPE.SelectedValue;
			string anchor		= DDL_ANCHOR.SelectedValue;
			string group		= DDL_GROUP.SelectedValue;
			string bulan		= DDL_BLN.SelectedValue;
			string tahun		= TXT_THN.Text;

			if(type != "" && anchor != "" && bulan != "" && tahun != "")
			{
				LoadReport_Load(type, anchor, bulan, tahun, group);
			}
			else
			{
				GlobalTools.popMessage(this, "Check Mandatory!");
			}
		}

		private void LoadReport_Load(string type, string anchor, string bulan, string tahun, string group)
		{	
			string ReportAddr="";
			conn.QueryString = "SELECT REPORTADDR FROM APP_PARAMETER";
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

			ReportViewer1.ReportPath = "/SMEReports/RptAPDashboard&type=" + type + "&cif=" + anchor + "&bulan=" + bulan + "&tahun=" + tahun + "&group=" + group;
		}

		protected void BTN_Cancel_Click(object sender, System.EventArgs e)
		{
			DDL_ANCHOR.SelectedValue	= "";
			DDL_TYPE.SelectedValue		= "";
			DDL_GROUP.SelectedValue		= "";
			DDL_BLN.SelectedValue		= "";
			TXT_THN.Text				= "";
		}
	}
}
