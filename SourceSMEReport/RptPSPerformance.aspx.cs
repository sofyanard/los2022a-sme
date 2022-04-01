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
	/// Summary description for RptPSPerformance.
	/// </summary>
	public partial class RptPSPerformance : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
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
				fillRegion();
			}
			Conn.QueryString = "delete from TMP_REPORT_CUSTRESPONSE where userid='" + Session["UserID"].ToString() + "'";
			Conn.ExecuteQuery();

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
			fillCBC();
		}

		private void fillCBC()
		{
			DDL_CBC.Items.Clear();
			switch(Label1.Text)
			{
				case "1": 
					Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_code <>'' and b.areaid = '" + DDL_REGION.SelectedValue + "' "+
						"and b.Branch_CODE='" + Session["BranchID"].ToString() + "' ";
					break;
				case "2":
					Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_code <>'' and b.areaid = '" + DDL_REGION.SelectedValue + "' "+
						"and b.CBC_code='" + Session["CBC"].ToString() + "' ";
					break;
					/*case "3": 
						Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
							"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and c.areaid = '" + DDL_REGION.SelectedValue + "' "+
							"and b.AreaID='" + Session["AreaID"].ToString() + "' ";
						DDL_CBC.Items.Add(new ListItem("-- PILIH --",""));
						break;*/
				default:
					Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_code <>'' and b.areaid = '" + DDL_REGION.SelectedValue + "' ";
					DDL_CBC.Items.Add(new ListItem("-- PILIH --",""));
					break;
			}
			if(DDL_REGION.SelectedValue != "")
			{
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					DDL_CBC.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
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
					/*case "2":
						Conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cbc_code='" + 
							DDL_CBC.SelectedValue + "' and CBC_Code='" + Session["CBC"].ToString() + "' ";
						DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));
						break;
					case "3": 
						Conn.QueryString =  "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cbc_code='" +
							DDL_CBC.SelectedValue + "' ";//and areaid='" + Session["AreaID"].ToString() + "' ";
						DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));
						break;*/
				default:
					Conn.QueryString =  "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cbc_code='" + 
						DDL_CBC.SelectedValue + "' and areaid='" + DDL_REGION.SelectedValue + "' ";
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
			fillPS();
		}

		private void fillTeamLeader()
		{
			DDL_TEAM.Items.Clear();
			Conn.QueryString = "select distinct a.su_teamleader, b.su_fullname "+
				"from scuser A left join scuser B on b.userid = a.su_teamleader "+
				"where 1=1 and A.su_branch='" + DDL_BRANCH.SelectedValue + "' ";
			Conn.ExecuteQuery();
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

		private void fillPS()
		{
			DDL_PS.Items.Clear();
			Conn.QueryString = "select userid, userfullnm from vw_approvaluser where userbranch='" + DDL_BRANCH.SelectedValue + "' ";
			DDL_PS.Items.Add(new ListItem("-- PILIH --",""));
			if(DDL_BRANCH.SelectedValue != "")
			{
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					DDL_PS.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
			}
		}
		
		private int Posisi_User()
		{
			string area = "";
			int Posisi;
			if (Session["BranchID"].ToString()=="99999")
			{ 
				//Head Office
				Posisi = 0;
			}
			else
			{
				Conn.QueryString = "select * from RFAREA where AREAREGMANAGER ='" + Session["UserID"].ToString() + "' ";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount() > 0) area = "yup";
				else area = "nop";				

				if (area=="yup")
				{
					//User adalah Manager Area
					Posisi=3;
				}
				else
				{
					//if (Session["GroupID"].ToString().StartsWith("01"))
					if (Session["CBC"].ToString().Equals(Session["BranchID"].ToString()))
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

		
		private void Load_ReportViewer(string sql_kondisi, string Start_Date, string End_Date, string region, string CBC, string Branch, string PS, string teamleader)
		{
			string vCompleted="", vPending="";
			/*
			string tanggal1	= tool.ConvertDate(Start_Date);
			string tanggal2	= tool.ConvertDate(End_Date);
			*/
			string tanggal1	= Start_Date;
			string tanggal2	= End_Date;
			tanggal1		= tanggal1.Replace("'","");
			tanggal2		= tanggal2.Replace("'","");

			//ReportViewer1.ReportPath = "/SMEReports/RptPSPerformance&sql_kondisi=" + Server.HtmlEncode(sql_kondisi) + "&Start_Date='" + tanggal1 + "'&End_Date='" + tanggal2 + "'&AREA=" + region + "&CBC=" + CBC + "&BRANCH=" + Branch + "&PS=" + PS + "&teamleader=" + teamleader + "&Complete=" + vCompleted + "&Pending=" + vPending + "&rs:Command=Render&rc:Toolbar=True";

            IReportServerCredentials irsc = new CustomReportCredentials(WebConfigurationManager.AppSettings["ReportUser"].ToString(), WebConfigurationManager.AppSettings["ReportPassword"].ToString(), WebConfigurationManager.AppSettings["DomainName"].ToString());

            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerCredentials = irsc;
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["ServerUrl"].ToString());
            ReportViewer1.ServerReport.ReportPath = "/SMEReports/RptPSPerformance";

            List<ReportParameter> paramList = new List<ReportParameter>();

            paramList.Add(new ReportParameter("sql_kondisi", Server.HtmlEncode(sql_kondisi), false));
            paramList.Add(new ReportParameter("AREA", region, false));
            paramList.Add(new ReportParameter("CBC", CBC, false));
            paramList.Add(new ReportParameter("BRANCH", Branch, false));
            paramList.Add(new ReportParameter("PS", PS, false));
            paramList.Add(new ReportParameter("Start_Date", tanggal1, false));
            paramList.Add(new ReportParameter("End_Date", tanggal2, false));
            paramList.Add(new ReportParameter("teamleader", teamleader, false));
            paramList.Add(new ReportParameter("Complete", vCompleted, false));
            paramList.Add(new ReportParameter("Pending", vPending, false));

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
			string branch	= DDL_BRANCH.SelectedValue;
			string teamleader = DDL_TEAM.SelectedValue;
			string PS		= DDL_PS.SelectedValue;
			string cbc		= DDL_CBC.SelectedValue;
			string region   = DDL_REGION.SelectedValue;
			
			string tanggal1_k = "";
			string tanggal2_k = "";
			string tanggal1 = "";
			string tanggal2 = "";
			
			if (Tools.isDateValid(this,TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text)&&Tools.isDateValid(this, TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text))
			{
				tanggal1_k = Tools.toISODate(TXT_TGL1,DDL_BLN1,TXT_THN1);
				tanggal2_k = Tools.toISODate(TXT_TGL2,DDL_BLN2,TXT_THN2);
				tanggal1 = tool.ConvertDate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);
				tanggal2 = tool.ConvertDate(TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text);

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
					kriterianya = " and convert(varchar, ap_Recvdate, 112) between " + tanggal1_k + " and " + tanggal2_k + " ";
				if (!PS.Equals("")) 
				{ 
					kriterianya += "and (su_fullname = '" + PS + "') ";
				}
				if (!teamleader.Equals(""))
				{
					kriterianya += "and (ap_teamleader = '" + teamleader + "') ";
				}
				if(!branch.Equals(""))
				{
					kriterianya += "and (BRANCH_CODE = '" + branch + "') ";
				}
				if (!cbc.Equals(""))
				{
					kriterianya += "and (CBC_CODE = '" + cbc + "') ";				
				}
				if(!region.Equals(""))
				{
					kriterianya += "and (areaid= '" + region + "') ";				
				}
				
				if (!Session["bussunitid2"].Equals(""))    
				{
					kriterianya += "and (businessunit in (" + Session["bussunitid2"].ToString().Replace("''","'") + ")) ";
				}
				
				if (!action.Equals("PRINT"))
					Load_ReportViewer(kriterianya, tanggal1,tanggal2,region, cbc,branch, PS,teamleader);
				else
					Response.Redirect("RptPSPerformancePrint.aspx?sql_kondisi=" + kriterianya.Replace("'","''") + "&Start_Date=" + tanggal1 + "&End_Date=" + tanggal2 + "&region=" + region + "&cbc=" + cbc + "&branch=" + branch + "&PS=" + PS + "&teamleader=" + teamleader);
				
			}
			else
			{
				Response.Write("<script language='javascript'>alert('Invalid Date !')</script>");
			}
		}

		protected void DDL_BRANCH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillTeamLeader();
			fillPS();
		}

		protected void DDL_REGION_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillCBC();
		}

		protected void DDL_CBC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillBranch();
		}

		protected void btn_Back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportOR.aspx?mc=" + Request.QueryString["mc"] + "&BU=" + LBL_BU.Text);
		}

		protected void Btn_Print_Click(object sender, System.EventArgs e)
		{
			LoadSql("PRINT");	
		}
	}
}
