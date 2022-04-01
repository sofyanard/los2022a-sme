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
namespace SME.SourceSMEReport.DQA
{
	/// <summary>
	/// Summary description for Perkreditan.
	/// </summary>
	public partial class Perkreditan : System.Web.UI.Page
	{
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if (!IsPostBack)
			{
				fillWilayah();
				fillKelompok();
				//fillArea();
				fillStatus();
				fillUnit();
				fillRCO();
			}
			if (Request.QueryString["mc"]=="DQA03")
			{
				TR_AREA.Visible = false;
			}
			else if (Request.QueryString["mc"]=="DQA02")
			{
				TR_AREA.Visible = false;
				LBL_RCO.Visible = false;
				DDL_RCO.Visible = false;
			}
			else if (Request.QueryString["mc"]=="DQA01")
			{
				TR_UNIT.Visible = false;
			}			
		}

		private void fillWilayah()
		{
			DDL_WILAYAH.Items.Clear();
			DDL_WILAYAH.Items.Add(new ListItem("-- PILIH --",""));
			conn.QueryString = "select AREAID, AREANAME from rfarea where active ='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_WILAYAH.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}	
		}

		private void fillKelompok()
		{
			DDL_KELOMPOK.Items.Clear();
			DDL_KELOMPOK.Items.Add(new ListItem("-- PILIH --",""));
			conn.QueryString = "select bussunitid, bussunitdesc from rfbusinessunit order by bussunitid ";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_KELOMPOK.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
		}

		/*
				private void fillArea () 
				{
					DDL_AREA.Items.Clear();
					DDL_AREA.Items.Add(new ListItem("-- PILIH --",""));

					if (DDL_WILAYAH.SelectedValue=="")
					{
						conn2.QueryString = "select hub_nm, hub_nm from par_hub";
					}
					else
					{
						conn2.QueryString = "select hub_nm, hub_nm from par_hub where wilayah_id = '"+DDL_WILAYAH.SelectedValue+"'";
					}
					conn2.ExecuteQuery();
					for (int i = 0; i < conn2.GetRowCount(); i++)
					{
						DDL_AREA.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
					}	
				}
		*/

		private void fillRCO()
		{
			DDL_RCO.Items.Clear();
			DDL_RCO.Items.Add(new ListItem("-- PILIH --",""));
			conn2.QueryString = "select distinct RCO, RCO from PAR_RCO";
			conn2.ExecuteQuery();
			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				DDL_RCO.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
			}	
		}

		private void fillStatus() 
		{
			DDL_STATUS.Items.Clear();
			DDL_STATUS.Items.Add(new ListItem("DATA ERROR","ERROR"));
			DDL_STATUS.Items.Add(new ListItem("OK","OK"));
			DDL_STATUS.Items.Add(new ListItem("-- PILIH --",""));
		}

		private void fillUnit() 
		{
			DDL_UNIT.Items.Clear();
			DDL_UNIT.Items.Add(new ListItem("-- PILIH --",""));

			if (DDL_KELOMPOK.SelectedValue=="")
			{
				conn.QueryString = "select DEPT_CODE, DEPT_DESC from  rfdepartmentcode order by dept_desc";
			}
			else
			{
				conn.QueryString = "select DEPT_CODE, DEPT_DESC from  rfdepartmentcode where BUSSUNITID='"+DDL_KELOMPOK.SelectedValue+"'order by dept_desc";
			}

			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}			
		}

		private void LoadSql(string action)
		{
			conn.QueryString="select IDDQA from RFAREA where areaid = '" + DDL_WILAYAH.SelectedValue +"'";
			conn.ExecuteQuery();
			
			string wilayah		= conn.GetFieldValue("IDDQA");
			string unit			= DDL_UNIT.SelectedValue;
			string kelompok		= DDL_KELOMPOK.SelectedValue;
			string rco			= DDL_RCO.SelectedValue;
			string status		= DDL_STATUS.SelectedValue;
			
			LoadReport_Load(wilayah, unit, kelompok, rco, status);	
		}

		private void LoadReport_Load(string wilayah, string unit, string kelompok, string rco, string status)
		{
			string ReportAddr="";
			conn2.QueryString = "select reportaddr from app_parameter";
			conn2.ExecuteQuery();
			if (conn2.GetRowCount()>0)
			{
				ReportAddr = conn2.GetFieldValue(0,0);
			}
			else
			{
				ReportAddr  = "10.123.12.50";
			}
			ReportViewer1.ServerUrl = "http://" + ReportAddr + "/ReportServer";

			ReportViewer1.ReportPath = "/SMEReports/DQAControllingPerkreditan&wilayah="+ wilayah + "&unit=" + unit +  "&kelompok=" + kelompok +  "&rco=" + rco + "&status=" + status + "&rs:Command=Render";
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
		/*
				private void DDL_WILAYAH_SelectedIndexChanged(object sender, System.EventArgs e)
				{
					fillArea();
				}
		*/
		protected void DDL_KELOMPOK_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillUnit();
		}
		/*
				private void DDL_UNIT_SelectedIndexChanged(object sender, System.EventArgs e)
				{
					fillArea();
		
				}
		*/
	}
}
