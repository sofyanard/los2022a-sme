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
using System.Web.Configuration;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Net;
using SME.SourceSMEReport;

namespace SME.SourceSMEReport
{
	/// <summary>
	/// Summary description for RptOpeDetail.
	/// </summary>
	public partial class RptOpeDetail : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection Conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Conn = (Connection) Session["Connection"];



			if (!IsPostBack)
			{
				LBL_BU.Text =Request.QueryString["BU"];
				DDL_Month1.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_Month1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
			
				DDL_Month2.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_Month2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
		
				TXT_Day1.Text=DateAndTime.Today.Day.ToString();
				DDL_Month1.SelectedValue=DateAndTime.Today.Month.ToString();
				TXT_Year1.Text=DateAndTime.Today.Year.ToString();
				TXT_Day2.Text=DateAndTime.Today.Day.ToString();
				DDL_Month2.SelectedValue=DateAndTime.Today.Month.ToString();
				TXT_Year2.Text=DateAndTime.Today.Year.ToString();

				Label1.Text = Posisi_User().ToString();
				fillCBC();
			}
            /*
			Conn.QueryString = "Delete from TMP_REPORT_DAILYPOSRPT where userid='" + Session["UserID"].ToString() + "'";
			Conn.ExecuteQuery();
            */
		}

		private int Posisi_User()
		{
			string area="";
			int Posisi;
            if ((Session["BranchID"].ToString() == "000") || (Session["BranchID"].ToString() == "001"))
			{ 
				//Head Office
				Posisi = 0;
			}
			else
			{
				Conn.QueryString = "select * from rfarea where arearegmanager='" + Session["UserID"].ToString() + "' ";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
					area="yup";
				else
					area="nop";

				if (area=="yup")
				{
					Posisi=3;
				}//aa
				else
				{
					if (Session["BranchID"].ToString()==Session["CBC"].ToString()) //(Session["GroupID"].ToString().StartsWith("01"))
					{
						//CBC
						Posisi=2;
					}
					else
					{
						//Branch
						Posisi = 1;
					}
				}
			}
			return Posisi;
		}

		private void fillCBC()
		{
			DDL_CBC.Items.Clear();
			switch(Label1.Text)
			{
				case "1": 
					Conn.QueryString = "select distinct cbc_code, (select branch_code + ' - ' + branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_Code<>'' and CBC_CODE = '" + Session["CBC"].ToString() + "' "+
						"and b.Branch_CODE='" + Session["BranchID"].ToString() + "' ";
					break;
				case "2":
                    Conn.QueryString = "select distinct cbc_code, (select branch_code + ' - ' + branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name " +
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_Code<>'' and b.areaid = '" + Session["AreaID"].ToString() + "' "+
						"and b.CBC_code='" + Session["CBC"].ToString() + "' ";
					break;
				case "3":
                    Conn.QueryString = "select distinct cbc_code, (select branch_code + ' - ' + branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name " +
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_Code<>'' "+
						"and b.AreaID='" + Session["AreaID"].ToString() + "' ";
					DDL_CBC.Items.Add(new ListItem("-- PILIH --",""));
					break;
				default:
                    Conn.QueryString = "select distinct cbc_code, (select branch_code + ' - ' + branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name " +
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_Code<>'' ";
					//and b.areaid = '" + DDL_REGION.SelectedValue + "'
					DDL_CBC.Items.Add(new ListItem("-- PILIH --",""));
					break;
			}
			
			//			if(DDL_REGION.SelectedValue != "")
			//{
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_CBC.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}
			//}
			fillBranch();
		}

		private void fillBranch()
		{
			DDL_Branch.Items.Clear();
			switch(Label1.Text)
			{
				case "1":
                    Conn.QueryString = "SELECT BRANCH_CODE, BRANCH_CODE + ' - ' + BRANCH_NAME FROM RFBRANCH where cbc_code='" +
						DDL_CBC.SelectedValue + "' and Branch_Code='" + Session["BranchID"].ToString() + "' ";
					break;
				default:
                    Conn.QueryString = "SELECT BRANCH_CODE, BRANCH_CODE + ' - ' + BRANCH_NAME FROM RFBRANCH where cbc_code='" + 
						DDL_CBC.SelectedValue + "' ";//and areaid='" + DDL_REGION.SelectedValue + "' ";
					DDL_Branch.Items.Add(new ListItem("-- PILIH --",""));
					break;
			}
			if(DDL_CBC.SelectedValue != "")
			{
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					DDL_Branch.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
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
		private void Load_Data()
		{
			string tanggal1="", tanggal2="", cbc="", branch="";
			branch		= DDL_Branch.SelectedValue;
			cbc			= DDL_CBC.SelectedValue;
			tanggal1	= tools.ConvertDate(TXT_Day1.Text,DDL_Month1.SelectedValue,TXT_Year1.Text);
			tanggal2	= tools.ConvertDate(TXT_Day2.Text,DDL_Month2.SelectedValue,TXT_Year2.Text);
			if (branch.Equals(""))
				branch	= "All"; //LBL_BRANCH.Text;
			if (cbc.Equals(""))
				cbc	= "All"; //LBL_CBC.Text;
			/*
			if (!Information.IsDate(tanggal1))
				tanggal1	= DateTime.Today.ToString();
			if (!Information.IsDate(tanggal2))
				tanggal2	= DateTime.Today.ToString();
			*/
			Load_ReportViewer(tanggal1,tanggal2,cbc,branch);
		}

		private void Load_ReportViewer(string Start_Date, string End_Date, string CBC, string Branch)
		{
			/*
			string tanggal1	= tools.ConvertDate(Start_Date);
			string tanggal2	= tools.ConvertDate(End_Date);
			*/
			string tanggal1	= Start_Date;
			string tanggal2	= End_Date;
			tanggal1		= tanggal1.Replace("'","");
			tanggal2		= tanggal2.Replace("'","");

            //ReportViewer1.ReportPath = "/SMEReports/RptDailyOpr&userid=" + Session["UserID"].ToString() + "&Start_Date=" + tanggal1 + "&End_Date=" + tanggal2 + "&CBC=" + CBC + "&BRANCH=" + Branch + "&rs:Command=Render&rc:Toolbar=True";

            IReportServerCredentials irsc = new CustomReportCredentials(WebConfigurationManager.AppSettings["ReportUser"].ToString(), WebConfigurationManager.AppSettings["ReportPassword"].ToString(), WebConfigurationManager.AppSettings["DomainName"].ToString());

            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerCredentials = irsc;
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["ServerUrl"].ToString());
            ReportViewer1.ServerReport.ReportPath = "/SMEReports/RptDailyOpr";

            List<ReportParameter> paramList = new List<ReportParameter>();

            paramList.Add(new ReportParameter("userid", Session["UserID"].ToString(), false));
            paramList.Add(new ReportParameter("CBC", CBC, false));
            paramList.Add(new ReportParameter("BRANCH", Branch, false));
            paramList.Add(new ReportParameter("Start_Date", tanggal1, false));
            paramList.Add(new ReportParameter("End_Date", tanggal2, false));

            ReportViewer1.ServerReport.SetParameters(paramList);
            ReportViewer1.ServerReport.Refresh();
		}

		protected void BTN_LIHAT_Click(object sender, System.EventArgs e)
		{
			LoadSql("");
		}

		private void LoadSql(string action)
		{
			string kriterianya = "";
			string rmcode = "";
			string co_grp = "";
			string appr_code = "";			
			string rejk_code = "";
			string branch	= DDL_Branch.SelectedValue;
			string cbc		= DDL_CBC.SelectedValue;

			string tanggal1 = tools.ConvertDate(TXT_Day1.Text,DDL_Month1.SelectedValue,TXT_Year1.Text);
			string tanggal2 = tools.ConvertDate(TXT_Day2.Text,DDL_Month2.SelectedValue,TXT_Year2.Text);

			string tanggal1_k = Tools.toISODate(TXT_Day1,DDL_Month1,TXT_Year1);
			string tanggal2_k = Tools.toISODate(TXT_Day2,DDL_Month2,TXT_Year2);

			/*
			if (!Information.IsDate(tanggal1) || !Information.IsDate(tanggal2))
			{
				Tools.popMessage(this,"Invalid date");
				Response.Write("<Script language='javascript'>history.back();</Script>");
				if (!Information.IsDate(tanggal1))
					Tools.SetFocus(this,TXT_Day1);
				else
					Tools.SetFocus(this,TXT_Day2);
			}
			else 
			*/
			{
				if(!branch.Equals(""))
				{
					kriterianya="and (branch_Code = ''" + branch + "'')";
				}
				else
				{
					if(!cbc.Equals(""))
					{
						kriterianya="and (cbc_code = ''" + cbc + "'' )";
					}
					else
					{
						kriterianya="";
					}
				}
				
				/*
                if (!Session["bussunitid2"].Equals("")) //ahmad
				{
					kriterianya += "and (businessunit in (" + Session["bussunitid2"].ToString() + ")) ";
				}
                */
                if ((!Session["BussUnit"].Equals("")) && (Session["BussUnit"] != null))
                {
                    kriterianya += "and (businessunit in (''" + Session["BussUnit"].ToString() + "'')) ";
                }

				Conn.QueryString = "Delete from TMP_REPORT_DAILYPOSRPT where userid='" + Session["UserID"].ToString() + "'";
				Conn.ExecuteQuery();
				
				Conn.QueryString = "select rmcode, GRP_CO, GRP_COOFF from app_parameter";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					rmcode = Conn.GetFieldValue(0,0).Replace("'","''");
					co_grp = "''" + Conn.GetFieldValue(0,1) + "'',''" + Conn.GetFieldValue(0,2) + "'' " ;
				}
				else
				{
					rmcode= "''";
					co_grp = "''";
				}

				Conn.QueryString = "select in_reject, in_approve from rfinitial";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					appr_code = Conn.GetFieldValue(0,0);
					rejk_code = Conn.GetFieldValue(0,1);
				}
				else
				{
					appr_code = "''";			
					rejk_code = "''";
				}

				Conn.QueryString = " exec RPT_DAILYPOSITION '" + appr_code + "','" + rejk_code + "','" + rmcode + "','" + co_grp + "','''" + 
					Session["UserID"].ToString() + "''','''" + tanggal1_k + "''','''" + tanggal2_k  + "''','" + kriterianya + "'";
				Conn.ExecuteQuery();
				if (!action.Equals("PRINT"))
					Load_ReportViewer(tanggal1,tanggal2,cbc,branch);
				else
					Response.Redirect("RptOPDetalPrint.aspx?userid=" + Session["UserID"].ToString() + "&tanggal1=" + tanggal1 + "&tanggal2=" + tanggal2 + "&cbc=" + cbc + "&branch=" + branch);
			}

		}

		protected void DDL_CBC_SelectedIndexChanged(object sender, System.EventArgs e)
		{

			fillBranch();
		}

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportOR.aspx?mc=" + Request.QueryString["mc"] + "&BU=" + LBL_BU.Text);
		}

		protected void Btn_Print_Click(object sender, System.EventArgs e)
		{
			LoadSql("PRINT");
		}
	}
}
