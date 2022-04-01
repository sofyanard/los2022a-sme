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

namespace SME.LMS.PortfolioWatchlistChecking
{
	/// <summary>
	/// Summary description for PerformancePortfolioBBC.
	/// </summary>
	public partial class PerformancePortfolioBBC : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			if (!IsPostBack)
			{
				DDL_BLN1.Items.Add(new ListItem("-- PILIH --",""));				
				for (int i = 1; i <= 12; i++)
				{
					DDL_BLN1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));					
				}				
				/*TXT_TGL1.Text=DateAndTime.Today.Day.ToString();
				DDL_BLN1.SelectedValue=DateAndTime.Today.Month.ToString();
				TXT_THN1.Text=DateAndTime.Today.Year.ToString();*/

				DDL_BBC.Items.Add(new ListItem("--Pilih--",""));
				DDL_REGION.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString = "select areaid, areaid + '-' + areaname as areaname from rfarea where active='1'";
				conn.ExecuteQuery();	
				for(int i=0; i<conn.GetRowCount(); i++)
					DDL_REGION.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
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

		protected void DDL_REGION_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewBBC();
		}

		private void ViewBBC()
		{
			DDL_BBC.Items.Clear();
			DDL_BBC.Items.Add(new ListItem("- PILIH -", ""));
			
			conn.QueryString = "select * from rfbranch where areaid='" + DDL_REGION.SelectedValue + "' and active='1' order by branch_name";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_BBC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			if (TXT_TGL1.Text=="" || DDL_BLN1.SelectedValue=="" || TXT_THN1.Text=="")
			{
				GlobalTools.popMessage(this, "Isi terlebih dahulu Periode Data!");
				return;	
			}
			LoadSql("");
		}

		private void LoadSql(string action)
		{
			string areaid = DDL_REGION.SelectedValue;
			string bbc = DDL_BBC.SelectedValue;			
			
			string periode_data = "";			
			
			if (Tools.isDateValid(this,TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text))
			{
				periode_data = tools.ConvertDate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);				

				if (!Information.IsDate(periode_data))
				{
					Tools.popMessage(this,"Invalid date");
					if (!Information.IsDate(periode_data))
						Tools.SetFocus(this,TXT_TGL1);
					
				}
				else
					LoadReport_Load(periode_data, areaid, bbc);
			}
			else
			{
				Response.Write("<script language='javascript'>alert('Invalid Date !')</script>");
			}
			
		}

		private void LoadReport_Load(string periode_data, string areaid, string bbc)
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
			
			ReportViewer2.ReportPath = "/SMEReports/PortfolioRptPerformance&periode_data="+ periode_data + "&areaid=" + areaid +  "&bbc=" + bbc + "&rs:Command=Render";
					
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			TXT_TGL1.Text = "";
			DDL_BLN1.SelectedValue = "";
			TXT_THN1.Text = "";
			DDL_REGION.SelectedValue = "";
			DDL_BBC.SelectedValue = "";
		}

	}
}
