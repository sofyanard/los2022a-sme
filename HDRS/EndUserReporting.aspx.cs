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
	/// Summary description for EndUserReporting.
	/// </summary>
	public partial class EndUserReporting : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			if (!IsPostBack)
			{
				DDL_BLN1.Items.Add(new ListItem("-- PILIH --",""));
				DDL_BLN2.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_BLN1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}				
				TXT_TGL1.Text=DateAndTime.Today.Day.ToString();
				DDL_BLN1.SelectedValue=DateAndTime.Today.Month.ToString();
				TXT_THN1.Text=DateAndTime.Today.Year.ToString();
				TXT_TGL2.Text=DateAndTime.Today.Day.ToString();
				DDL_BLN2.SelectedValue=DateAndTime.Today.Month.ToString();
				TXT_THN2.Text=DateAndTime.Today.Year.ToString();				
				
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
				conn.QueryString = "select branch_code, branch_name from rfbranch where active='1'";
				conn.ExecuteQuery();	
				for(int i=0; i<conn.GetRowCount(); i++)
					DDL_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}

		}

		/*private void Load_ReportViewer(string kriteria)
		{
			string ReportAddr;

			conn.QueryString = "select reportaddr from app_parameter";
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
				ReportAddr = conn.GetFieldValue(0,0);
			else
				ReportAddr  = "10.123.12.50";
			ReportViewer2.ServerUrl = "http://" + ReportAddr + "/ReportServer";
			ReportViewer2.ReportPath = "/SMEReports/HlpRptPerformReporting&sql_kondisi=" + kriteria;
		}*/


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

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			DDL_AREA.SelectedValue = "";
			DDL_SEGMENT.SelectedValue = "";
			DDL_UNIT.SelectedValue = "";
			TXT_TGL1.Text="";
			DDL_BLN1.SelectedValue="";
			TXT_THN1.Text="";
			TXT_TGL2.Text="";
			DDL_BLN2.SelectedValue="";
			TXT_THN2.Text="";
		}
		
		private void LoadSql(string action)
		{			
			string bussunitid = DDL_SEGMENT.SelectedValue;
			string areaid = DDL_AREA.SelectedValue;
			string su_branch = DDL_UNIT.SelectedValue;
			
			string tanggal1 = "";
			string tanggal2 = "";
			
			if (Tools.isDateValid(this,TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text)&&Tools.isDateValid(this, TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text))
			{
				tanggal1 = tools.ConvertDate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);
				tanggal2 = tools.ConvertDate(TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text);

				if (!Information.IsDate(tanggal1) || !Information.IsDate(tanggal2))
				{
					Tools.popMessage(this,"Invalid date");
					if (!Information.IsDate(tanggal1))
						Tools.SetFocus(this,TXT_TGL1);
					else
						Tools.SetFocus(this,TXT_TGL2);
				}
				else
					LoadReport_Load(tanggal1, tanggal2, bussunitid, areaid, su_branch);
			}
			else
			{
				Response.Write("<script language='javascript'>alert('Invalid Date !')</script>");
			}
			
		}

		private void LoadReport_Load(string tanggal1, string tanggal2, string bussunitid, string areaid, string su_branch)
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

			ReportViewer2.ReportPath = "/SMEReports/HlpRptPerformReporting&date1="+ tanggal1 + "&date2=" + tanggal2 + "&bussunitid=" + bussunitid + "&areaid=" + areaid + "&su_branch=" + su_branch + "&rs:Command=Render";
					
		}


		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{			
			if (TXT_TGL1.Text=="" || DDL_BLN1.SelectedValue=="" || TXT_THN1.Text=="" || TXT_TGL2.Text=="" || DDL_BLN2.SelectedValue=="" || TXT_THN2.Text=="")
			{
				GlobalTools.popMessage(this, "Isi terlebih dahulu HRS Received Date!");
				return;	
			}
			LoadSql("");
		}

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

		protected void DDL_SEGMENT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}
