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
	/// Summary description for RptPipeLine1.
	/// </summary>
	public partial class RptPipeLine1 : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Conn = (Connection) Session["Connection"];

			string vRMCODE ="";
			Conn = (Connection) Session["Connection"];

			Conn.QueryString = "select rmcode from app_parameter ";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
			{
				vRMCODE = Conn.GetFieldValue(0,0);
			}

			if (!IsPostBack)
			{
				LBL_BU.Text = Request.QueryString["BU"];
				Label1.Text = Posisi_User().ToString();
				LBL_RM.Text = "'0002','0004'";
				Conn.QueryString = "select rmcode from app_parameter ";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					LBL_RM.Text = Conn.GetFieldValue(0,0);
				}

				fillDate();
				fillRegion();
				fillBusinessUnit();
				//FillProgram();

				Conn.QueryString = "select userid, su_fullname from scuser where groupID in (" + vRMCODE + ")";
				Conn.ExecuteQuery();
				DDL_RM.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					DDL_RM.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
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

		private void Load_Data()
		{
			string region = "", businessunit="";
			string branch	= DDL_BRANCH.SelectedValue;
			string rm		= DDL_RM.SelectedValue;
			string teamleader = DDL_TEAM.SelectedValue;			
			string cbc      = DDL_CBC.SelectedValue;
			//string program  = DDL_PROGRAM.SelectedValue;
			string date1 = TXT_TGL1.Text + " - " + DDL_BLN1.SelectedItem + " - " + TXT_THN1.Text;
			string date2 = TXT_TGL2.Text + " - " + DDL_BLN2.SelectedItem + " - " + TXT_THN2.Text;

			region      = DDL_REGION.SelectedValue;
			businessunit = DDL_BUSINESSUNIT.SelectedValue;

			Load_ReportViewer(date1, date2, "", region, businessunit, branch, rm, cbc, teamleader);
		}

		private void Load_ReportViewer(string date1, string date2,string sql_kondisi, string region, string businessunit, string branch, string rm, string cbc, string teamleader)
		{
			if (!LBL_BU.Text.Equals(""))
			{
				sql_kondisi+= " and businessunit='" + LBL_BU.Text + "' ";
			}

			//ReportViewer1.ReportPath = "/SMEReports/RptPipeLine1&date1=" + date1 + "&date2=" + date2 +"&sql_kondisi=" + sql_kondisi + "&region=" + region + "&BU=" + businessunit.ToString() +"&rm=" + rm + "&cbc=" + cbc +	"&branch=" + branch + "&teamleader=" + teamleader +"&rs:Command=Render&rc:Toolbar=True";

            IReportServerCredentials irsc = new CustomReportCredentials(WebConfigurationManager.AppSettings["ReportUser"].ToString(), WebConfigurationManager.AppSettings["ReportPassword"].ToString(), WebConfigurationManager.AppSettings["DomainName"].ToString());

            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerCredentials = irsc;
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["ServerUrl"].ToString());
            ReportViewer1.ServerReport.ReportPath = "/SMEReports/RptPipeLine1";

            List<ReportParameter> paramList = new List<ReportParameter>();

            paramList.Add(new ReportParameter("sql_kondisi", sql_kondisi, false));
            paramList.Add(new ReportParameter("BU", businessunit.ToString(), false));
            paramList.Add(new ReportParameter("region", region, false));
            paramList.Add(new ReportParameter("cbc", cbc, false));
            paramList.Add(new ReportParameter("branch", branch, false));
            paramList.Add(new ReportParameter("rm", rm, false));
            paramList.Add(new ReportParameter("date1", date1, false));
            paramList.Add(new ReportParameter("date2", date2, false));
            paramList.Add(new ReportParameter("teamleader", teamleader, false));

            ReportViewer1.ServerReport.SetParameters(paramList);
            ReportViewer1.ServerReport.Refresh();
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

		private void fillBusinessUnit()
		{
			DDL_BUSINESSUNIT.Items.Clear();
			switch(LBL_BU.Text)
			{
				case "CB100": case "2":
					Conn.QueryString = "select bussunitid, bussunitdesc from rfbusinessunit where bussunitid='CB100' order by bussunitid ";
					break;
				default: 
					DDL_BUSINESSUNIT.Items.Add(new ListItem("-- PILIH --",""));
					Conn.QueryString = "select bussunitid, bussunitdesc from rfbusinessunit where bussunitid<>'CB100' order by bussunitid ";
					break;
			}
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_BUSINESSUNIT.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}
		}
		/*

		private void FillProgram()
		{
			string BusinessUnit ="";
			try 
			{
				BusinessUnit = Request.QueryString["BU"];
			}
			catch{ BusinessUnit =""; }

			if (BusinessUnit.ToString().Trim() == "CB100")
				Conn.QueryString = "SELECT DISTINCT PROGRAMID, PROGRAMDESC FROM RFPROGRAM " + 
					" where businessunit = 'CB100' ORDER BY PROGRAMDESC";
			else 
				Conn.QueryString = "SELECT DISTINCT PROGRAMID, PROGRAMDESC FROM RFPROGRAM " + 
					" where businessunit <> 'CB100' ORDER BY PROGRAMDESC";

			Conn.ExecuteQuery();
			DDL_PROGRAM.Items.Clear();
			DDL_PROGRAM.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				String s0 = Conn.GetFieldValue(i,0),
					s1 = Conn.GetFieldValue(i,1);
				ListItem li = new ListItem(s1,s0);
				DDL_PROGRAM.Items.Add(li);
			}
		}

*/
		private void fillRM()
		{
			DDL_RM.Items.Clear();
			Conn.QueryString = "select userid, su_fullname from scuser "+
				"left join rfbranch on scuser.su_branch=rfbranch.branch_code "+
				"where groupid in (" + LBL_RM.Text + ") and areaid='" + DDL_REGION.SelectedValue +
				"' and scuser.su_branch='" + DDL_BRANCH.SelectedValue + "' ";
			DDL_RM.Items.Add(new ListItem("-- PILIH --",""));
			if(DDL_BRANCH.SelectedValue != "")
			{
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					DDL_RM.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
			}
		}

		private void fillCBC()
		{
			GlobalTools.fillRefList(DDL_CBC, "exec rpt_getcbc '" + Session["UserID"].ToString() + "','" + DDL_REGION.SelectedValue + "'",Conn);
			fillBranch();

//			DDL_CBC.Items.Clear();
//			switch(Label1.Text)
//			{
//				case "1": 
//					/*
//					Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
//						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_code <>'' and b.areaid = '" + DDL_REGION.SelectedValue + "' "+
//						"and b.Branch_CODE='" + Session["BranchID"].ToString() + "' ";
//						*/
//					Conn.QueryString = "select cbc.branch_code as cbc_code, cbc.branch_name as branch_name  from rfbranch b " +
//						" left join rfbranch cbc on cbc.branch_code = b.cbc_code " +
//						" where b.Branch_CODE='" + Session["BranchID"].ToString() + "' ";
//
//					break;
//
//				case "2":
//					/* 
//					Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
//						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_code <>'' and b.areaid = '" + DDL_REGION.SelectedValue + "' "+
//						"and b.CBC_code='" + Session["CBC"].ToString() + "' ";
//						*/
//					Conn.QueryString = "select branch_code as cbc_code, branch_name as branch_name  from rfbranch  " +
//						" where branch_code = cbc_code and CBC_code='" + Session["CBC"].ToString() + "' ";
//					break;
//
//				case "3":
//					Conn.QueryString = "select branch_code as cbc_code, branch_name as branch_name  from rfbranch  " +
//						" where branch_code = cbc_code and areaid  ='" + Session["AreaID"].ToString() + "' ";
//					break;
//					/*case "3": 
//						Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
//							"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and c.areaid = '" + DDL_REGION.SelectedValue + "' "+
//							"and b.AreaID='" + Session["AreaID"].ToString() + "' ";
//						DDL_CBC.Items.Add(new ListItem("-- PILIH --",""));
//						break;*/
//
//				default:
//					Conn.QueryString = "select branch_code as cbc_code, branch_name as branch_name  from rfbranch  " +
//						" where branch_code = cbc_code and areaid ='" +  DDL_REGION.SelectedValue  + "' ";
//					/*Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
//						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_code <>'' and b.areaid = '" + DDL_REGION.SelectedValue + "' ";
//						*/
//					DDL_CBC.Items.Add(new ListItem("-- PILIH --",""));
//					break;
//			}
//
//			if(DDL_REGION.SelectedValue != "")
//			{
//				Conn.ExecuteQuery();
//				for (int i = 0; i < Conn.GetRowCount(); i++)
//				{
//					DDL_CBC.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
//				}
//			}
			
		}

		private void fillBranch()
		{ 
			
			GlobalTools.fillRefList(DDL_BRANCH," exec rpt_getbranch '" + Session["UserID"].ToString() + "', " +
						" '"+DDL_REGION.SelectedValue+"', '" + DDL_CBC.SelectedValue + "'",Conn);
			
//			DDL_BRANCH.Items.Clear();
//			switch(Label1.Text)
//			{
//				case "1": 
//					Conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cbc_code='" +
//						DDL_CBC.SelectedValue + "' and Branch_Code='" + Session["BranchID"].ToString() + "' ";
//					break;
//					/*case "2":
//						Conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cbc_code='" + 
//							DDL_CBC.SelectedValue + "' and CBC_Code='" + Session["CBC"].ToString() + "' ";
//						DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));
//						break;
//					case "3": 
//						Conn.QueryString =  "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cbc_code='" +
//							DDL_CBC.SelectedValue + "' ";//and areaid='" + Session["AreaID"].ToString() + "' ";
//						DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));
//						break;*/
//				default:
//					Conn.QueryString =  "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cbc_code='" + 
//						DDL_CBC.SelectedValue + "'";
//					DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));
//					break;
//			}
//			if(DDL_CBC.SelectedValue != "")
//			{
//				Conn.ExecuteQuery();
//				for (int i = 0; i < Conn.GetRowCount(); i++)
//				{
//					DDL_BRANCH.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
//				}
//			}
//			fillTeamLeader();
			//fillRM();
		}

		private void fillTeamLeader()
		{
			GlobalTools.fillRefList(DDL_TEAM,"exec RPT_GETTEAMLEADER '" + DDL_BRANCH.SelectedValue + "'",Conn);

//			DDL_TEAM.Items.Clear();
//			Conn.QueryString = "select distinct a.su_teamleader, b.su_fullname "+
//				"from scuser A left join scuser B on b.userid = a.su_teamleader "+
//				"where a.su_teamleader is not null and A.su_branch='" + DDL_BRANCH.SelectedValue + "' ";
//			DDL_TEAM.Items.Add(new ListItem("-- PILIH --",""));
//			if(DDL_BRANCH.SelectedValue != "")
//			{
//				Conn.ExecuteQuery();
//				for (int i = 0; i < Conn.GetRowCount(); i++)
//				{
//					DDL_TEAM.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
//				}
//			}
		}



		private void fillRegion()
		{
			GlobalTools.fillRefList(DDL_REGION,"exec rpt_getarea '" + Session["UserID"].ToString() + "' ",Conn);

//			DDL_REGION.Items.Clear();
//			switch(Label1.Text)
//			{
//				case "1": case "2":
//					Conn.QueryString = "select AreaID, AREANAME from rfarea where AreaID='" + Session["AreaID"].ToString() + "' ";
//					break;
//				case "3": 
//					Conn.QueryString = "select AreaID, AREANAME from rfarea where arearegmanager='" + Session["UserID"].ToString() + "' ";
//					break;
//				default:
//					Conn.QueryString = "select AreaID, AREANAME from rfarea";
//					DDL_REGION.Items.Add(new ListItem("-- PILIH --",""));
//					break;
//			}
//			Conn.ExecuteQuery();
//			for (int i = 0; i < Conn.GetRowCount(); i++)
//			{
//				DDL_REGION.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
//			}
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
			string region   = DDL_REGION.SelectedValue;
			string businessunit = DDL_BUSINESSUNIT.SelectedValue;
			string branch	= DDL_BRANCH.SelectedValue;
			string rm		= DDL_RM.SelectedValue;
			string teamleader = DDL_TEAM.SelectedValue;			
			string cbc      = DDL_CBC.SelectedValue;
			//string program  = DDL_PROGRAM.SelectedValue;

			string title_area = ( DDL_REGION.SelectedValue == "" ? "ALL" : DDL_REGION.SelectedItem.Text );
			string title_bu = ( DDL_BUSINESSUNIT.SelectedValue == "" ? "ALL" : DDL_BUSINESSUNIT.SelectedItem.Text );
			string title_branch	= ( DDL_BRANCH.SelectedValue == "" ? "ALL" : DDL_BRANCH.SelectedItem.Text );
			string title_rm		= ( DDL_RM.SelectedValue == "" ? "ALL" : DDL_RM.SelectedItem.Text );
			string title_tl = ( DDL_TEAM.SelectedValue == "" ? "ALL" : DDL_TEAM.SelectedItem.Text );
			string title_cbc      = ( DDL_CBC.SelectedValue == "" ? "ALL" : DDL_CBC.SelectedItem.Text );
			//string title_program  = ( DDL_PROGRAM.SelectedValue == "" ? "ALL" : DDL_PROGRAM.SelectedItem.Text );
						
			string tanggal1 = tools.ConvertDate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);
			string tanggal2 = tools.ConvertDate(TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text);

			string date1 = TXT_TGL1.Text + " - " + DDL_BLN1.SelectedItem + " - " + TXT_THN1.Text;
			string date2 = TXT_TGL2.Text + " - " + DDL_BLN2.SelectedItem + " - " + TXT_THN2.Text;

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
				kriterianya+="and ap_recvdate between "+tanggal1+" and '"+tanggal2.Replace("'","")+" 23:59:59'  " ;
			
				if (!region.Equals(""))
				{
					kriterianya+="and (areaid = '" + region + "' )";
				}
				if (!Session["bussunitid"].Equals(""))    
				{
					kriterianya += "and (businessunit in (" + Session["bussunitid"].ToString() + ")) ";
				}
				if (!rm.Equals(""))
				{
					kriterianya += "AND (ap_relmngr = '" + rm + "') ";
				}
				if (!cbc.Equals(""))
				{
					kriterianya += " AND (CBC_CODE = '" + cbc + "') ";
				}
				if (!branch.Equals(""))
				{
					kriterianya += "and (branch_code = '" + branch + "') ";
				}
				if (!teamleader.Equals(""))
				{
					kriterianya += " AND (ap_teamleader = '" + teamleader + "') ";
				}
//				if (!program.Equals(""))
//				{
//					kriterianya += " AND (prog_code = '" + program + "') ";
//				}


				if(!action.Equals("PRINT"))
					Load_ReportViewer(date1, date2, kriterianya, title_area, title_bu, title_branch, title_rm, title_cbc, title_tl);					
				else
				   Response.Redirect("RptPipeLine1Print.aspx?date1=" + tanggal1 + "&date2=" + tanggal2 + "&sql_kondisi=" + kriterianya.Replace("'","''") + "&region=" + region + "&businessunit=" + businessunit+ "&cbc=" + cbc + "&branch=" + branch + "&rm=" + rm + "&teamleader=" + teamleader);
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
			fillRM();
		}

		protected void DDL_CBC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillBranch();
		}

		protected void DDL_REGION_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillCBC();
		}
	}
}
