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
	/// Summary description for CIFUnclean.
	/// </summary>
	public partial class CIFUnclean : System.Web.UI.Page
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
				fillArea();
				// fillStatus();
				fillUnit();
				fillCabang();
			}
			if (Request.QueryString["mc"]=="DQA02" || Request.QueryString["mc"]=="DQA03")
			{
				TR_AREA.Visible = false;
				TR_CABANG.Visible = false;
			}
			else if (Request.QueryString["mc"]=="DQA01")
			{
				TR_UNIT.Visible = false;
				TR_KELOMPOK.Visible = false;
				//TR_AREA.Visible = false;
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
			if(Request.QueryString["mc"]=="DQA01")
			{
				DDL_KELOMPOK.SelectedValue = "MM100";
			}
		}


		private void fillArea () 
		{
			DDL_AREA.Items.Clear();
			DDL_AREA.Items.Add(new ListItem("-- PILIH --",""));

			if (DDL_WILAYAH.SelectedValue=="")
			{
				conn2.QueryString = "select hub_id, hub_nm from par_hub";
			}
			else
			{
				conn.QueryString="select IDDQA from RFAREA where areaid = '" + DDL_WILAYAH.SelectedValue +"'";
				conn.ExecuteQuery();
				conn2.QueryString = "select hub_id, hub_nm from par_hub where wilayah_id = '"+ conn.GetFieldValue("IDDQA")+"'";
			}
			conn2.ExecuteQuery();
			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				DDL_AREA.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
			}	
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

		private void fillCabang()
		{
			DDL_CABANG.Items.Clear();
			DDL_CABANG.Items.Add(new ListItem("-- PILIH --",""));

			if (DDL_AREA.SelectedValue=="")
			{
				conn.QueryString = "select BRANCH_CODE, BRANCH_NAME from rfbranch where BRANCH_TYPE='5' and BRANCH_CODE not in ('BMP01','BMP02','BMP07','BMP08','BMP09','BMP10','BMP11','BMP12','BMP13','BMP15','BMP18','BMP20','BMP21','BMP22','BMP29','BMP30','BMP31','BMP36','CASH','CLPC0','CLPC1','CLPC2','CLPC3','CLPC4','CLPC5','CLPC6','CLPC7','CLPC8','COR10','COR11','COR12','HQ','KANWIL1','KANWIL10','KANWIL2','KANWIL3','KANWIL4','KANWIL6','KANWIL7','KANWIL8','KANWIL9','PSP01','RCCA','RCCB','RCO I','RCO II','RCO III','RCO IV','RCO IX','RCO V','RCO VI','RCO VII','RCO VIII','RCO1','RCO11','RCO2','RCO3','RCO4','RCO5','RCO6','RCO7','RCO8','rrm1','RTM01','RTM06','RTM07','RTM08','RTM101')";
			}
			else
			{
				conn.QueryString = "select BRANCH_CODE, BRANCH_NAME from rfbranch where left(branch_code,3) in (select HUB_ID from DQA..PAR_HUB where HUB_NM = '"+DDL_AREA.SelectedValue+"')";
			}

			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_CABANG.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}					
		}


		private void LoadSql(string action)
		{
			string wilayah = "";
			conn.QueryString="select IDDQA from RFAREA where areaid = '" + DDL_WILAYAH.SelectedValue +"'";
			conn.ExecuteQuery();
			if(conn.GetFieldValue("IDDQA")=="" || conn.GetFieldValue("IDDQA")==null)
			{
				wilayah = "";
			}
			else
			{
				wilayah		= (int.Parse(conn.GetFieldValue("IDDQA"))).ToString();
			}
			string unit			= DDL_UNIT.SelectedValue;
			string area			= DDL_AREA.SelectedValue;
			string kelompok		= DDL_KELOMPOK.SelectedValue;
			// string status		= DDL_STATUS.SelectedValue;
			string cabang		= DDL_CABANG.SelectedValue;
			
			LoadReport_Load(wilayah, unit, area, kelompok, cabang);	//status
		}

		private void LoadReport_Load(string wilayah, string unit, string area, string kelompok, string cabang)	//string status
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

			ReportViewer1.ReportPath = "/SMEReports/DQAControllingCIFUnclean&wilayah="+ wilayah + "&unit=" + unit +  "&area=" + area +  "&kelompok=" + kelompok + "&cabang=" + cabang + "&rs:Command=Render";	// "&status=" + status
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

		protected void DDL_WILAYAH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillArea();
		}

		protected void DDL_KELOMPOK_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillUnit();
		}

		protected void DDL_UNIT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillArea();
		}

		protected void DDL_AREA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillCabang();
		}

	}
}