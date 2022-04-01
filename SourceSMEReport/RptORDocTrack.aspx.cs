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
using DMS.CuBESCore;
using Microsoft.VisualBasic;

namespace SourceSMEReport
{
	/// <summary>
	/// Summary description for RptORDocTrack.
	/// </summary>
	public partial class RptORDocTrack : System.Web.UI.Page
	{
		//protected Connection Conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Tools tools = new Tools();
		protected Connection Conn;
			
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Conn = (Connection) Session["Connection"];
			if (!IsPostBack)
			{
				string branch="", gfrom=""; //, gto="";
				DDL_BLN1.Items.Add(new ListItem("-- PILIH --",""));
				DDL_BLN2.Items.Add(new ListItem("-- PILIH --",""));
				DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));
				DDL_FROM.Items.Add(new ListItem("-- PILIH --",""));
				DDL_TO.Items.Add(new ListItem("-- PILIH --",""));
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
			
				Conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH order by BRANCH_NAME";
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					DDL_BRANCH.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
					branch	= Conn.GetFieldValue(i,0);
				}

				Conn.QueryString = "SELECT DISTINCT GROUPID, SG_GRPNAME FROM SCGROUP ORDER BY SG_GRPNAME";
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					DDL_FROM.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
					DDL_TO.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
					gfrom	= Conn.GetFieldValue(i,0);
				}
				
				ddl_team.Items.Clear();
				ddl_team.Items.Add(new ListItem("-- PILIH --",""));

			//	LoadReport(DateTime.Today.ToString(),DateTime.Today.ToString(),branch,gfrom,gfrom);
			}
			//else
			//	ViewReport();
		//	BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
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

		private void ViewReport()
		{
			string branch	= DDL_BRANCH.SelectedValue;
			string gfrom	= DDL_FROM.SelectedValue;
			string gto		= DDL_TO.SelectedValue;
			string tanggal1 = tools.ConvertDate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);
			string tanggal2 = tools.ConvertDate(TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text);
			
			/*
			if (!Information.IsDate(tanggal1) || !Information.IsDate(tanggal2))
			{
				Tools.popMessage(this,"Invalid date");
				Response.Write("<Script language='javascript'>history.back();</Script>");
				if (!Information.IsDate(tanggal1))
					Tools.SetFocus(this,TXT_TGL1);
				else
					Tools.SetFocus(this,TXT_TGL2);
			}
			else
			*/
				LoadReport(tanggal1,tanggal2,branch,gfrom,gto);
		}

		private void ViewReportPrint()
		{
			string branch	= DDL_BRANCH.SelectedValue;
			string gfrom	= DDL_FROM.SelectedValue;
			string gto		= DDL_TO.SelectedValue;
			string tanggal1 = tools.ConvertDate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);
			string tanggal2 = tools.ConvertDate(TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text);
			
			/*
			if (!Information.IsDate(tanggal1) || !Information.IsDate(tanggal2))
			{
				Tools.popMessage(this,"Invalid date");
				Response.Write("<Script language='javascript'>history.back();</Script>");
				if (!Information.IsDate(tanggal1))
					Tools.SetFocus(this,TXT_TGL1);
				else
					Tools.SetFocus(this,TXT_TGL2);
			}
			else
			*/
				LoadReportPrint(tanggal1,tanggal2,branch,gfrom,gto);
		}

		private void LoadReport(string tgl1, string tgl2, string branch, string gfrom, string gto)
		{
			string ReportAddr="", kriterianya="";
			string tanggal1 = tools.ConvertDate(tgl1);
			string tanggal2 = tools.ConvertDate(tgl2);
			Conn.QueryString = "select reportaddr from app_parameter";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
				ReportAddr = Conn.GetFieldValue(0,0);
			else
				ReportAddr  = "10.123.12.50";

			if(!branch.Equals(""))
			{
				kriterianya = "AND (branch_code = '" + branch + "')";
			}
			else
			{
				kriterianya ="";
			}
			Conn.QueryString = "INSERT INTO TMP_REPORT_DOCUMENTTRACK " +
                               "SELECT ap_regno, branch_name, nama, CASE WHEN SEND_DATE IS NULL OR "+
                               "SEND_DATE = '' THEN '' ELSE CONVERT(varchar, SEND_DATE, 106) END AS SEND_DATE, CASE WHEN RECEIVE_DATE IS NULL OR "+
                               "RECEIVE_DATE = '' THEN '' ELSE CONVERT(varchar, RECEIVE_DATE, 106) END AS RECEIVE_DATE, GFromName, GToName, '" + Session["UserID"].ToString() + "' as Userid "+
                               "FROM VW_REPORT_DOCTRACK "+
                               "WHERE (GFrom = '" + gfrom + "') AND (GTo = '" + gto + "') AND (SEND_DATE BETWEEN " + tanggal1 + " AND " + tanggal2 + ") " + kriterianya + " ";
            Conn.ExecuteQuery();                               
			ReportViewer1.ServerUrl = "http://" + ReportAddr + "/ReportServer";
			ReportViewer1.ReportPath = "/SMEReports/RptORDocTrack&userid=" + Session["UserID"].ToString() + "&tgl1=" + tanggal1 + "&tgl2=" + tanggal2 + "&branch=" + branch + "&GFrom=" + gfrom + "&GTo=" + gto + "&rs:Command=Render&rc:Toolbar=True";
		}

		private void LoadReportPrint(string tgl1, string tgl2, string branch, string gfrom, string gto)
		{
			string ReportAddr="", kriterianya="";
			string tanggal1 = tools.ConvertDate(tgl1);
			string tanggal2 = tools.ConvertDate(tgl2);
			Conn.QueryString = "select reportaddr from app_parameter";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
				ReportAddr = Conn.GetFieldValue(0,0);
			else
				ReportAddr  = "10.123.12.50";

			if(!branch.Equals(""))
			{
				kriterianya = "AND (branch_code = '" + branch + "')";
			}
			else
			{
				kriterianya ="";
			}
			Conn.QueryString = "INSERT INTO TMP_REPORT_DOCUMENTTRACK " +
				"SELECT ap_regno, branch_name, nama, CASE WHEN SEND_DATE IS NULL OR "+
				"SEND_DATE = '' THEN '' ELSE CONVERT(varchar, SEND_DATE, 106) END AS SEND_DATE, CASE WHEN RECEIVE_DATE IS NULL OR "+
				"RECEIVE_DATE = '' THEN '' ELSE CONVERT(varchar, RECEIVE_DATE, 106) END AS RECEIVE_DATE, GFromName, GToName, '" + Session["UserID"].ToString() + "' as Userid "+
				"FROM VW_REPORT_DOCTRACK "+
				"WHERE (GFrom = '" + gfrom + "') AND (GTo = '" + gto + "') AND (SEND_DATE BETWEEN " + tanggal1 + " AND " + tanggal2 + ") " + kriterianya + " ";
			Conn.ExecuteQuery();                               
			Response.Redirect("RptOrdDocTrackPrint.aspx?tgl1=" + tanggal1 + "&tgl2=" + tanggal2 + "&branch=" + branch + "&GFrom=" + gfrom + "&GTo=" + gto);
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			ViewReport();
		}

		protected void Btn_Print_Click(object sender, System.EventArgs e)
		{
			ViewReportPrint();
		}
	}
}
