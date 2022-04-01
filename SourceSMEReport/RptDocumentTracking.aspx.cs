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
	/// Summary description for RptDocumentTracking.
	/// </summary>
	public partial class RptDocumentTracking : System.Web.UI.Page
	{
		protected Connection Conn =new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Conn = (Connection) Session["Connection"];
			LBL_BU.Text = Request.QueryString["BU"];
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

				Label1.Text = Posisi_User().ToString();
                fillCBC();
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
		
		

		private void Load_ReportViewer(string action,string sql_kondisi, string Start_Date, string End_Date, string CBC, string branch, string teamleader)
		{
			string tanggal1	= Start_Date;
			string tanggal2	= End_Date;//tools.ConvertDate(End_Date);
			string tanggal1_k="", tanggal2_k="";
			tanggal1		= tanggal1.Replace("'","");
			tanggal2		= tanggal2.Replace("'","");

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
			/*
			if (!Information.IsDate(tanggal2))
			{
				tanggal2	= DateTime.Today.ToString();
				tanggal2_k = Tools.toISODate(DateTime.Today.Day.ToString(),DateTime.Today.Month.ToString() ,DateTime.Today.Year.ToString());
			}
			else
			*/
			{
				tanggal2_k = Tools.toISODate(DateTime.Parse(tanggal2.ToString()).Day.ToString(), DateTime.Parse(tanggal2.ToString()).Month.ToString(), DateTime.Parse(tanggal2.ToString()).Year.ToString());
			}
			sql_kondisi += "AND (convert(nvarchar, ap_recvdate, 112) between " + tanggal1_k + " and " + tanggal2_k + ") ";
			if (Session["sg_grpunit"].ToString()=="CO")
			{
				sql_kondisi += "and (businessunit in ('CB100')) ";
			}

            IReportServerCredentials irsc = new CustomReportCredentials(WebConfigurationManager.AppSettings["ReportUser"].ToString(), WebConfigurationManager.AppSettings["ReportPassword"].ToString(), WebConfigurationManager.AppSettings["DomainName"].ToString());

            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerCredentials = irsc;
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["ServerUrl"].ToString());

            if (!action.Equals("PRINT"))
            {
                //ReportViewer1.ReportPath = "/SMEReports/RptDocumentTracking&sql_kondisi=" + sql_kondisi + "&Start_Date=" + tanggal1 + "&End_Date=" + tanggal2 + "&CBC=" + CBC + "&BRANCH=" + branch + "&teamleader=" + teamleader + "&rs:Command=Render&rc:Toolbar=True";
                ReportViewer1.ServerReport.ReportPath = "/SMEReports/RptDocumentTracking";

                List<ReportParameter> paramList = new List<ReportParameter>();

                paramList.Add(new ReportParameter("sql_kondisi", sql_kondisi, false));
                paramList.Add(new ReportParameter("CBC", CBC, false));
                paramList.Add(new ReportParameter("BRANCH", branch, false));
                paramList.Add(new ReportParameter("Start_Date", tanggal1, false));
                paramList.Add(new ReportParameter("End_Date", tanggal2, false));
                paramList.Add(new ReportParameter("teamleader", teamleader, false));

                ReportViewer1.ServerReport.SetParameters(paramList);
                ReportViewer1.ServerReport.Refresh();
            }
            else
                Response.Redirect("RptDocumentTrackingPrint.aspx?sql_kondisi=" + sql_kondisi.Replace("'", "''") + "&Start_Date=" + tanggal1 + "&End_Date=" + tanggal2 + "&cbc=" + CBC + "&branch=" + branch + "&teamleader=" + teamleader);
		}

		private void fillCBC()
		{
			DDL_CBC.Items.Clear();
			switch(Label1.Text)
			{
				case "1": 
					Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_code <>'' "+
						"and b.Branch_CODE='" + Session["BranchID"].ToString() + "' ";
					break;
				case "2":
					Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_code <>'' "+
						"and b.CBC_code='" + Session["CBC"].ToString() + "' ";
					break;
				default:
					Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_code <>'' ";
					DDL_CBC.Items.Add(new ListItem("-- PILIH --",""));
					break;
			}
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_CBC.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}
			fillBranch();
		}

		private void fillBranch()
		{
			DDL_BRANCH.Items.Clear();
			switch(Label1.Text)
			{
				case "1": 
					Conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cbc_code='" +
						DDL_CBC.SelectedValue + "' and Branch_Code='" + Session["BranchID"].ToString() + "' ";
					break;
				default:
					Conn.QueryString =  "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cbc_code='" + 
						DDL_CBC.SelectedValue + "' ";
					DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));
					break;
			}
			if(DDL_CBC.SelectedValue != "")
			{
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					DDL_BRANCH.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
			}
			fillTeamLeader();
		}

		private void fillTeamLeader()
		{
			DDL_TEAM.Items.Clear();
			Conn.QueryString = "select distinct a.su_teamleader, b.su_fullname "+
				"from scuser A left join scuser B on b.userid = a.su_teamleader "+
				"where a.su_teamleader is not null and A.su_branch='" + DDL_BRANCH.SelectedValue + "' ";
			DDL_TEAM.Items.Add(new ListItem("-- PILIH --",""));
			if(DDL_BRANCH.SelectedValue != "")
			{
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					DDL_TEAM.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
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

		protected void DDL_CBC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillBranch();
		}

		protected void BTN_LIHAT_Click(object sender, System.EventArgs e)
		{
			LoadSql("");
		}

		private void LoadSql(string action)
		{
			string kriterianya = "";
			string cbc		= DDL_CBC.SelectedValue;
			string branch	= DDL_BRANCH.SelectedValue;
			string teamleader = DDL_TEAM.SelectedValue; 			

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
			{
				if(!cbc.Equals(""))
				{
					kriterianya+="and (cbc_code = '" + cbc + "' )";
				}
				if(!branch.Equals(""))
				{
					kriterianya+="and (branch_Code = '" + branch + "') ";
				}
				if (!teamleader.Equals(""))
				{
					kriterianya+="and (ap_teamleader = '" + teamleader + "' )";
				}
				if (!Session["bussunitid2"].Equals(""))    
				{
					kriterianya += "and (businessunit in (" + Session["bussunitid2"].ToString().Replace("''","'") + ")) ";
				}
				Load_ReportViewer(action,kriterianya, tanggal1, tanggal2,cbc,branch, teamleader);
			}
		}

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportOR.aspx?mc=" + Request.QueryString["mc"] + "&BU=" + LBL_BU.Text);
		}

		protected void Btn_Print_Click(object sender, System.EventArgs e)
		{
			LoadSql("PRINT");
		}

		protected void DDL_BRANCH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillTeamLeader();
		}
	}
}
