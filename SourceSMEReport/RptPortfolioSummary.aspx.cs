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

namespace SME.SourceSMEReport
{
	/// <summary>
	/// Summary description for RptPortfolioSummary.
	/// </summary>
	public partial class RptPortfolioSummary : System.Web.UI.Page
	{

		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				DDL_BLN1.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_BLN1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				TXT_TGL1.Text=DateAndTime.Today.Day.ToString();
				DDL_BLN1.SelectedValue=DateAndTime.Today.Month.ToString();
				TXT_THN1.Text=DateAndTime.Today.Year.ToString();				
			}
		}

		private void LoadReport_Load(string action,string tgl1)
		{	
			string ReportAddr="", kriterianya="", tanggal1_k="";
			//string tanggal1	= tools.ConvertDate(tgl1);
			string tanggal1	= tgl1;
			 
			tanggal1		= tanggal1.Replace("'","");

			Conn.QueryString = "select reportaddr from app_parameter";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
				ReportAddr = Conn.GetFieldValue(0,0);
			else
				ReportAddr  = "10.123.12.50";
			
			ReportViewer1.ServerUrl = "http://" + ReportAddr + "/ReportServer";
			/*
			if (!Information.IsDate(tanggal1))
			{
				tanggal1	= DateTime.Today.ToString();
				tanggal1_k = Tools.toISODate(DateTime.Today.Day.ToString(),DateTime.Today.Month.ToString() ,DateTime.Today.Year.ToString());
			}
			else
			*/
			{
				tanggal1_k = Tools.toISODate(DateTime.Parse(tanggal1.ToString()).Day.ToString(),DateTime.Parse(tanggal1.ToString()).Month.ToString(), DateTime.Parse(tanggal1.ToString()).Year.ToString());
			}

			kriterianya = tanggal1_k;

			ReportViewer1.ReportPath = "/SMEReports/RptPortfolioSummary&sql_kondisi="+kriterianya+ "&Start_Date="+ tanggal1 +"&rs:Command=Render&rc:Toolbar=True";

		}
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
		
		private void InitializeComponent()
		{    
		}
		#endregion

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			LoadSql("");
		}

		private void LoadSql(string action)
		{
			string tanggal1 = "";
			
			if (Tools.isDateValid(this,TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text))
			{
				tanggal1 = tools.ConvertDate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);

				/*
				if (!Information.IsDate(tanggal1))
				{
					Tools.popMessage(this,"Invalid date");
					if (!Information.IsDate(tanggal1))
						Tools.SetFocus(this,TXT_TGL1);
					else
						Tools.SetFocus(this,TXT_TGL1);
				}
				else
				*/
					LoadReport_Load(action,tanggal1);
			}
			else
			{
				Response.Write("<script language='javascript'>alert('Invalid Date !')</script>");
			}
		}

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportPortfolio.aspx?mc=" + Request.QueryString["mc"]);
		}


	}
}
