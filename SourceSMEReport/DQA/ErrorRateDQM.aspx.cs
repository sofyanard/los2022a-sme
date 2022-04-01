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
	/// Summary description for ErrorRateDQM.
	/// </summary>
	public partial class ErrorRateDQM : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tools = new Tools();
		protected Connection Conn = new Connection();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				fillDate();
				fillData();

			}
		}

		private void fillData()
		{
			DDL_JENIS_DATA.Items.Clear();
			DDL_JENIS_DATA.Items.Add(new ListItem("-- PILIH --",""));
			conn.QueryString = "select * from [10.204.7.245].DQA.DBO.DQM_JENIS_DATA";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_JENIS_DATA.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}	
		}

		private void fillDate()
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
			
		}

		private void BTN_LIHAT_Click(object sender, System.EventArgs e)
		{
/*			if(DDL_JENIS_DATA.SelectedValue == "")
			{
				GlobalTools.popMessage(this, "Jenis Data tidak boleh kosong!");
				return;
			}
*/			LoadSql("");
		}

		private void LoadSql(string action)
		{
			string jenis			= DDL_JENIS_DATA.SelectedValue;

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
					LoadReport_Load(tanggal1, tanggal2, jenis);
			}
			else
			{
				Response.Write("<script language='javascript'>alert('Invalid Date !')</script>");
			}			
		}

		private void LoadReport_Load(string tanggal1, string tanggal2, string jenis)
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

			ReportViewer1.ReportPath = "/SMEReports/RptDQMErrorRatePosition&date1="+ tanggal1 + "&date2=" + tanggal2 + "&jenis=" + jenis +  "&rs:Command=Render";
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
	}
}
