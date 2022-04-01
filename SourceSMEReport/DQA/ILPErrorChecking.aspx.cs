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

namespace SME.SourceSMEReport.DQA
{
	/// <summary>
	/// Summary description for ILPErrorChecking.
	/// </summary>
	public partial class ILPErrorChecking : System.Web.UI.Page
	{
		protected Connection conn = new Connection();
		protected Connection Conn = new Connection();	
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				fillDropDowns();
			}			
		}

		private void fillDropDowns() 
		{
			fillArea();
			fillCBC();
			fillStatus();
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

		private void fillCBC () 
		{
			DDL_CBC.Items.Clear();
			DDL_CBC.Items.Add(new ListItem("-- PILIH --",""));

			if (DDL_AREA.SelectedValue=="")
			{
				Conn.QueryString = "select branch_code, branch_name from rfbranch where active ='1' and branch_type='3'";
			}
			else
			{
				Conn.QueryString = "select branch_code, branch_name from rfbranch where active ='1' and branch_type='3' and areaid = '"+DDL_AREA.SelectedValue+"'";
			}
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_CBC.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}	
		}

		private void fillStatus() 
		{
			DDL_STATUS.Items.Clear();
			DDL_STATUS.Items.Add(new ListItem("-- PILIH --",""));
			DDL_STATUS.Items.Add(new ListItem("ACTIVE","ACTIVE"));
			DDL_STATUS.Items.Add(new ListItem("NOT ACTIVE","NOT ACTIVE"));
		}

		private void LoadSql(string action)
		{
			string area				= DDL_AREA.SelectedValue;
			string cbc				= DDL_CBC.SelectedValue;
			string status			= DDL_STATUS.SelectedValue;

			LoadReport_Load(area, cbc, status);
			
		}

		private void LoadReport_Load(string area, string cbc, string status)
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

			ReportViewer1.ReportPath = "/SMEReports/RptILPError&area=" + area + "&cbc=" + cbc + "&status=" + status + "&rs:Command=Render";
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

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportDQA.aspx?mc=" + Request.QueryString["mc"]);
		}

		protected void BTN_LIHAT_Click(object sender, System.EventArgs e)
		{
			LoadSql("");
		}

		protected void DDL_AREA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillCBC();
		}

	}
}