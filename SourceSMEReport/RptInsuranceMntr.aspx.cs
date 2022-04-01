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
using System.Web.Configuration;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Net;
using SME.SourceSMEReport;

namespace SME.SourceSMEReport
{
	/// <summary>
	/// Summary description for RptInsuranceMntr.
	/// </summary>
	public partial class RptInsuranceMntr : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			/*
						Conn = (Connection) Session["Connection"];
						if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], Conn))
						Response.Redirect("/SME/Restricted.aspx");
			*/
			Conn = (Connection) Session["Connection"];
			if (!IsPostBack)
			{
				LBL_BU.Text = Request.QueryString["BU"];
				DDL_Month1.Items.Add(new ListItem("-- PILIH --",""));
				DDL_Month2.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_Month1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_Month2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
				TXT_Day1.Text=DateAndTime.Today.Day.ToString();
				DDL_Month1.SelectedValue=DateAndTime.Today.Month.ToString();
				TXT_Year1.Text=DateAndTime.Today.Year.ToString();
				TXT_Day2.Text=DateAndTime.Today.Day.ToString();
				DDL_Month2.SelectedValue=DateAndTime.Today.Month.ToString();
				TXT_Year2.Text=DateAndTime.Today.Year.ToString();

				Label1.Text = Posisi_User().ToString();
				fillRegion();
			}
		//	Load_Data();
			//BTN_LIHAT.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
		}

		private void Load_Data()
		{
			string tanggal1="", tanggal2="", branch="", region = "", approval = "", teamleader ="", kriterianya="";
			branch		= DDL_Branch.SelectedValue;
			teamleader  = DDL_TEAM.SelectedValue;
			region      = DDL_REGION.SelectedValue;
			tanggal1	= tools.ConvertDate(TXT_Day1.Text,DDL_Month1.SelectedValue,TXT_Year1.Text);
			tanggal2	= tools.ConvertDate(TXT_Day2.Text,DDL_Month2.SelectedValue,TXT_Year2.Text);
			if (region.Equals(""))
				region = ""; //"All"; //LBL_REGION.Text; 
			if (branch.Equals(""))
				branch	= ""; // "All"; //LBL_BRANCH.Text;
			if (approval.Equals(""))
				approval = ""; // "All";
			if (teamleader.Equals(""))
				teamleader = ""; // "All";

			/*
			if (!Information.IsDate(tanggal1))
				tanggal1	= DateTime.Today.ToString();
			if (!Information.IsDate(tanggal2))
				tanggal2	= DateTime.Today.ToString();
			*/
			kriterianya= " and (convert(varchar, Ap_Recvdate, 112) BETWEEN convert(varchar, '" + DateTime.Today.ToString() + "',112) AND convert(varchar, '" + DateTime.Today.ToString() + "',112)) ";
			Load_ReportViewer(kriterianya, tanggal1,tanggal2,region, branch, teamleader);
		}

		private void fillRegion()
		{
			DDL_REGION.Items.Clear();
			switch(Label1.Text)
			{
				case "1": case "2":
					Conn.QueryString = "select AreaID, AREANAME from rfarea where AreaID='" + Session["AreaID"].ToString() + "' ";
					break;
				case "3": 
					Conn.QueryString = "select AreaID, AREANAME from rfarea where arearegmanager='" + Session["UserID"].ToString() + "' ";
					break;
				default:
					Conn.QueryString = "select AreaID, AREANAME from rfarea";
					DDL_REGION.Items.Add(new ListItem("-- PILIH --",""));
					break;
			}
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_REGION.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}
			fillBranch();
		}

		private void fillBranch()
		{
			DDL_Branch.Items.Clear();
			switch(Label1.Text)
			{
				case "1": 
					Conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where AreaID='" +
						DDL_REGION.SelectedValue + "' and Branch_Code='" + Session["BranchID"].ToString() + "' ";
					break;
				default:
					Conn.QueryString =  "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where areaid='" + DDL_REGION.SelectedValue + "' ";
					DDL_Branch.Items.Add(new ListItem("-- PILIH --",""));
					break;
			}
			if(DDL_REGION.SelectedValue != "")
			{
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					DDL_Branch.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
			}
			fillTeamLeader();
		}
		private void fillTeamLeader()
		{
			DDL_TEAM.Items.Clear();
			Conn.QueryString = "select distinct a.su_teamleader, b.su_fullname "+
				"from scuser A left join scuser B on b.userid = a.su_teamleader "+
				"where a.su_teamleader is not null and A.su_branch='" + DDL_Branch.SelectedValue + "' ";
			DDL_TEAM.Items.Add(new ListItem("-- PILIH --",""));
			if(DDL_Branch.SelectedValue != "")
			{
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					DDL_TEAM.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
			}
		}

		private int Posisi_User()
		{
			string area="";
			int Posisi;
			if (Session["BranchID"].ToString()=="99999")
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
				}
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

		private void Load_ReportViewer(string sql_kondisi, string Start_Date, string End_Date, string region, string Branch, string teamleader)
		{
			/*
			string tanggal1	= tools.ConvertDate(Start_Date);
			string tanggal2	= tools.ConvertDate(End_Date);
			*/
			string tanggal1	= Start_Date;
			string tanggal2	= End_Date;
			tanggal1		= tanggal1.Replace("'","");
			tanggal2		= tanggal2.Replace("'","");

			//ReportViewer1.ReportPath = "/SMEReports/RptInsuranceMntr&sql_kondisi=" + sql_kondisi + "&Start_Date=" + tanggal1 + "&End_Date=" + tanggal2 + "&region=" + region + "&BRANCH=" + Branch + "&teamleader=" + teamleader + "&rs:Command=Render&rc:Toolbar=True";

            IReportServerCredentials irsc = new CustomReportCredentials(WebConfigurationManager.AppSettings["ReportUser"].ToString(), WebConfigurationManager.AppSettings["ReportPassword"].ToString(), WebConfigurationManager.AppSettings["DomainName"].ToString());

            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerCredentials = irsc;
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["ServerUrl"].ToString());
            ReportViewer1.ServerReport.ReportPath = "/SMEReports/RptInsuranceMntr";

            List<ReportParameter> paramList = new List<ReportParameter>();

            paramList.Add(new ReportParameter("sql_kondisi", sql_kondisi, false));
            paramList.Add(new ReportParameter("region", region, false));
            paramList.Add(new ReportParameter("BRANCH", Branch, false));
            paramList.Add(new ReportParameter("Start_Date", tanggal1, false));
            paramList.Add(new ReportParameter("End_Date", tanggal2, false));
            paramList.Add(new ReportParameter("teamleader", teamleader, false));

            ReportViewer1.ServerReport.SetParameters(paramList);
            ReportViewer1.ServerReport.Refresh();
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

		protected void BTN_LIHAT_Click(object sender, System.EventArgs e)
		{
			LoadSql("");	
		}

		private void LoadSql(string action)
		{
			string kriterianya = "";
			string branch	= DDL_Branch.SelectedValue;
			string region   = DDL_REGION.SelectedValue;
			string teamleader = DDL_TEAM.SelectedValue;
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
				kriterianya= " and (convert(varchar, Ap_Recvdate, 112) BETWEEN " + tanggal1_k + " AND " + tanggal2_k + ") ";
				if (!region.Equals(""))
				{
					kriterianya += "and (areaid = '" + region + "' )";
				}
				if(!branch.Equals(""))
				{
					kriterianya += "and (branch_Code = '" + branch + "') ";
				}
				if (!teamleader.Equals(""))
				{
					kriterianya+="and (ap_teamleader= '" + teamleader + "')";
				}

				if (!Session["bussunitid2"].Equals(""))    
				{
					kriterianya += "and (businessunit in (" + Session["bussunitid2"].ToString().Replace("''","'") + ")) ";
				}
				if(!action.Equals("PRINT"))
					Load_ReportViewer(kriterianya, tanggal1,tanggal2,region, branch, teamleader);
				else
				{
					kriterianya = Server.UrlEncode(kriterianya.Replace("'","''"));
					Response.Redirect("RptInsuranceMntrPrint.aspx?mc=" + Request.QueryString["mc"] + "&BU=" + LBL_BU.Text + "&sql_kondisi=" + kriterianya + "&tanggal1=" + tanggal1 + "&tanggal2=" + tanggal2 + "&region=" + region + "&branch=" + branch + "&teamleader=" + teamleader);
				}

			}
		}

		protected void DDL_REGION_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillBranch();
		}

		protected void DDL_Branch_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillTeamLeader();
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
