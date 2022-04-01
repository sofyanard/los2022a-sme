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
using DMS.DBConnection;
using Microsoft.VisualBasic;
using DMS.CuBESCore;

namespace SME.HDRS
{
	/// <summary>
	/// Summary description for UnitReporting.
	/// </summary>
	public partial class UnitReporting : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				DDL_SEGMENT.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString = "select * from rfbusinessunit where active='1'";
				conn.ExecuteQuery();	
				for(int i=0; i<conn.GetRowCount(); i++)
					DDL_SEGMENT.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

				DDL_AREA.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString = "select * from rfarea where active='1'";
				conn.ExecuteQuery();	
				for(int i=0; i<conn.GetRowCount(); i++)
					DDL_AREA.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

				DDL_UNIT.Items.Add(new ListItem("--Pilih--",""));
				/*conn.QueryString = "select branch_code, branch_name from rfbranch where active='1'";
				conn.ExecuteQuery();	
				for(int i=0; i<conn.GetRowCount(); i++)
					DDL_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));*/
			}
			
		}

		private void LoadSql(string action)
		{			
			string bussunitid = DDL_SEGMENT.SelectedValue;
			string areaid = DDL_AREA.SelectedValue;
			string su_branch = DDL_UNIT.SelectedValue;	

			LoadReport_Load(bussunitid, areaid, su_branch);			
		}

		private void LoadReport_Load(string bussunitid, string areaid, string su_branch)
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

			ReportViewer2.ServerUrl = "http://" + ReportAddr + "/ReportServer";

			ReportViewer2.ReportPath = "/SMEReports/HlpRptPending&bussunitid=" + bussunitid + "&areaid=" + areaid + "&su_branch=" + su_branch + "&rs:Command=Render";
					
		}


		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			LoadSql("");
		}


		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{			
			DDL_AREA.SelectedValue = "";
			DDL_SEGMENT.SelectedValue = "";
			DDL_UNIT.SelectedValue = "";
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

		protected void BTN_Back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("HelpDeskDashboard.aspx?mc=" + Request.QueryString["mc"]);
		}

		protected void DDL_AREA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewUnit();
		}

		private void ViewUnit()
		{
			DDL_UNIT.Items.Clear();
			DDL_UNIT.Items.Add(new ListItem("- PILIH -", ""));

			conn.QueryString = "select branch_code, branch_name from rfbranch " + 
				"where areaid='" + DDL_AREA.SelectedValue + 
				"' and active='1' order by branch_name";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}
		
	}
}
