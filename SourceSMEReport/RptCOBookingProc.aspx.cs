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
	/// Summary description for RptCOBookingProc.
	/// </summary>
	public partial class RptCOBookingProc : System.Web.UI.Page
	{

		protected Tools tools = new Tools();
		protected Connection Conn;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Conn = (Connection) Session["Connection"];
			
			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], Conn))
			//Response.Redirect("/SME/Restricted.aspx");

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
				Conn.QueryString = "Delete from TMP_REPORT_COBOOKINGPROC where userid='" + Session["UserID"].ToString() + "'";
				Conn.ExecuteQuery();
			}
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		#region My Method 

		private void fillRegion()
		{
			DDL_REGION.Items.Clear();
			switch(Label1.Text)
			{
				case "1": case "2": case "3":
					Conn.QueryString = "select AreaID, AREANAME from rfarea where AreaID='" + Session["AreaID"].ToString() + "' ";
					break;
					/*
				case "3": 
					Conn.QueryString = "select AreaID, AREANAME from rfarea where arearegmanager='" + Session["UserID"].ToString() + "' ";
					break;
					*/
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
					/*
					Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_code <>'' and b.areaid = '" + DDL_REGION.SelectedValue + "' "+
						"and b.Branch_CODE='" + Session["BranchID"].ToString() + "' ";
						*/
					Conn.QueryString = "select cbc.branch_code as cbc_code, cbc.branch_name as branch_name  from rfbranch b " +
						" left join rfbranch cbc on cbc.branch_code = b.cbc_code " +
						" where b.Branch_CODE='" + Session["BranchID"].ToString() + "' ";

					break;

				case "2":
					/* 
					Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_code <>'' and b.areaid = '" + DDL_REGION.SelectedValue + "' "+
						"and b.CBC_code='" + Session["CBC"].ToString() + "' ";
						*/
					Conn.QueryString = "select branch_code as cbc_code, branch_name as branch_name  from rfbranch  " +
						" where branch_code = cbc_code and CBC_code='" + Session["CBC"].ToString() + "' ";
					break;

				case "3":
					Conn.QueryString = "select branch_code as cbc_code, branch_name as branch_name  from rfbranch  " +
						" where branch_code = cbc_code and areaid  ='" + Session["AreaID"].ToString() + "' ";
					break;
					/*case "3": 
						Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
							"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and c.areaid = '" + DDL_REGION.SelectedValue + "' "+
							"and b.AreaID='" + Session["AreaID"].ToString() + "' ";
						DDL_CBC.Items.Add(new ListItem("-- PILIH --",""));
						break;*/

				default:
					Conn.QueryString = "select branch_code as cbc_code, branch_name as branch_name  from rfbranch  " +
						" where branch_code = cbc_code and areaid ='" +  DDL_REGION.SelectedValue  + "' ";
					/*Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_code <>'' and b.areaid = '" + DDL_REGION.SelectedValue + "' ";
						*/
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
						DDL_CBC.SelectedValue + "'";
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
			//fillRM();
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
				// Area Manager ....
				//Conn.QueryString = "select * from rfarea where arearegmanager='" + Session["UserID"].ToString() + "' ";
				Conn.QueryString = "select * from scuser where userid ='" + Session["UserID"].ToString() + "' " +
					"and groupid in ( select groupid from scgroup_init2 where GR_KEY = 'AREA_MGR')";
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
		
		#endregion
		////////////////////////////////////////////////////////////////////////////////////////////////////


		
		private void Isi_DDLBranch(string CBC)
		{
			
			Conn.QueryString = "select AREAID, AREANAME from RFAREA where AREAID='" + Session["AreaID"].ToString() + "' ";
			Conn.ExecuteQuery();
			DDL_REGION.Items.Clear();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_REGION.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}
			

			Conn.QueryString = "select distinct A.CBC_CODE, B.BRANCH_NAME from RFBRANCH A inner join RFBRANCH B on A.CBC_CODE=B.BRANCH_CODE "+
				"where A.CBC_CODE='" + Session["CBC"].ToString() + "' order by B.BRANCH_NAME";
			Conn.ExecuteQuery();
			DDL_CBC.Items.Clear();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_CBC.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}

			DDL_Month1.Items.Add(new ListItem("-- PILIH --",""));
			DDL_Month2.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 1; i <= 12; i++)
			{
				DDL_Month1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_Month2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}

			if (CBC=="CBC")
			{
				Conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME, cbc_code FROM RFBRANCH where CBC_CODE='" + Session["CBC"].ToString() + "' ";
				DDL_BRANCH.Items.Clear();
				DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));	
			}
			else
			{
				Conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME, cbc_code FROM RFBRANCH where BRANCH_CODE='" + Session["BranchID"].ToString() + "' ";                
				DDL_BRANCH.Items.Clear();
			}
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				if (i==0)
					LBL_BRANCH.Text		= Conn.GetFieldValue(i,0);
				DDL_BRANCH.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}

			
			if (CBC=="CBC")
			{
				Conn.QueryString = "select distinct A.su_teamleader, B.SU_FULLNAME "+
					"from SCUSER A join SCUSER B on B.USERID = A.SU_UPLINER "+
					"left join rfbranch C on A.su_branch=C.Branch_code "+
					"where A.SU_UPLINER is not null and C.CBC_Code='" + Session["CBC"].ToString() + "'";
			}
			else
			{
				Conn.QueryString = "select distinct A.su_teamleader, B.SU_FULLNAME "+
					"from SCUSER A join SCUSER B on B.USERID = A.SU_UPLINER "+
					"left join rfbranch C on A.su_branch=C.Branch_code "+
					"where A.SU_UPLINER is not null and A.Su_Branch='" + Session["BranchID"].ToString() + "' ";
			}
			Conn.ExecuteQuery();
			DDL_TEAM.Items.Clear();
			DDL_TEAM.Items.Add(new ListItem("-- PILIH --",""));
			for(int i=0; i<Conn.GetRowCount(); i++) 
				DDL_TEAM.Items.Add(new ListItem(Conn.GetFieldValue(i,1), Conn.GetFieldValue(i,0)));
			
		}

		private void Isi_DDLRegion()
		{   
			//string vRMCODE = "";

			
			Conn.QueryString = "select AreaID, AREANAME from rfarea where arearegmanager='" + Session["UserID"].ToString() + "' ";
			Conn.ExecuteQuery();
			DDL_REGION.Items.Clear();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				if (i==0)
					LBL_REGION.Text	= Conn.GetFieldValue(i,0);
				DDL_REGION.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}
			

			Conn.QueryString = "select distinct a.cbc_code, b.branch_name from rfbranch a inner join rfbranch b on a.cbc_code=b.branch_code "+
				"where a.Areaid='" + Session["AreaID"].ToString() + "' order by b.branch_name";
			Conn.ExecuteQuery();
			DDL_CBC.Items.Clear();
			DDL_CBC.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				if (i==0)
					LBL_CBC.Text	= Conn.GetFieldValue(i,0);
				DDL_CBC.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}

			DDL_Month1.Items.Add(new ListItem("-- PILIH --",""));
			DDL_Month2.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 1; i <= 12; i++)
			{
				DDL_Month1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_Month2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}

			Conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME, cbc_code FROM RFBRANCH where areaid='" + Session["AreaID"].ToString() + "' ";
			Conn.ExecuteQuery();
			DDL_BRANCH.Items.Clear();
			DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				if (i==0)
					LBL_BRANCH.Text		= Conn.GetFieldValue(i,0);
				DDL_BRANCH.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}

			Conn.QueryString = "select distinct A.su_teamleader, B.SU_FULLNAME "+
					"from SCUSER A join SCUSER B on B.USERID = A.SU_UPLINER "+
					"left join rfbranch C on A.su_branch=C.Branch_code "+
					"where A.SU_UPLINER is not null and C.AreaID='" + Session["AreaID"].ToString() + "' ";
			Conn.ExecuteQuery();
			DDL_TEAM.Items.Clear();
			DDL_TEAM.Items.Add(new ListItem("-- PILIH --",""));
			for(int i=0; i<Conn.GetRowCount(); i++) 
				DDL_TEAM.Items.Add(new ListItem(Conn.GetFieldValue(i,1), Conn.GetFieldValue(i,0)));

		}

		private void Isi_DDLHO()
		{
			Conn.QueryString = "select AreaID, AREANAME from rfarea";
			Conn.ExecuteQuery();
			DDL_REGION.Items.Clear();
			DDL_REGION.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				if (i==0)
					LBL_REGION.Text	= Conn.GetFieldValue(i,0);
				DDL_REGION.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}

			Conn.QueryString = "select distinct a.cbc_code, b.branch_name from rfbranch a inner join rfbranch b on a.cbc_code=b.branch_code order by b.branch_name";
			Conn.ExecuteQuery();
			DDL_CBC.Items.Clear();
			DDL_CBC.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				if (i==0)
					LBL_CBC.Text	= Conn.GetFieldValue(i,0);
				DDL_CBC.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}

			DDL_Month1.Items.Add(new ListItem("-- PILIH --",""));
			DDL_Month2.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 1; i <= 12; i++)
			{
				DDL_Month1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_Month2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}

			Conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME, cbc_code FROM RFBRANCH";
			Conn.ExecuteQuery();
			DDL_BRANCH.Items.Clear();
			DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				if (i==0)
					LBL_BRANCH.Text		= Conn.GetFieldValue(i,0);
				DDL_BRANCH.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}


		    Conn.QueryString = "select distinct A.su_teamleader, B.SU_FULLNAME "+
					"from SCUSER A join SCUSER B on B.USERID = A.SU_UPLINER "+
					"left join rfbranch C on A.su_branch=C.Branch_code "+
					"where A.SU_UPLINER is not null ";
			Conn.ExecuteQuery();
			DDL_TEAM.Items.Clear();
			DDL_TEAM.Items.Add(new ListItem("-- PILIH --",""));
			for(int i=0; i<Conn.GetRowCount(); i++) 
				DDL_TEAM.Items.Add(new ListItem(Conn.GetFieldValue(i,1), Conn.GetFieldValue(i,0)));
		}

		

		private void Load_ReportViewer(string Start_Date, string End_Date, string region, string CBC, string Branch, string teamleader)
		{
			/*
			string tanggal1	= tools.ConvertDate(Start_Date);
			string tanggal2	= tools.ConvertDate(End_Date);
			*/
			string tanggal1	= Start_Date;
			string tanggal2	= End_Date;
			tanggal1		= tanggal1.Replace("'","");
			tanggal2		= tanggal2.Replace("'","");
			
            //ReportViewer1.ReportPath = "/SMEReports/SLACOBookingProc&userid=" + Session["UserID"].ToString() + "&Start_Date=" + tanggal1 + "&End_Date=" + tanggal2 + "&region=" + region + "&CBC=" + CBC + "&BRANCH=" + Branch + "&teamleader=" + teamleader + "&rs:Command=Render&rc:Toolbar=True";

            IReportServerCredentials irsc = new CustomReportCredentials(WebConfigurationManager.AppSettings["ReportUser"].ToString(), WebConfigurationManager.AppSettings["ReportPassword"].ToString(), WebConfigurationManager.AppSettings["DomainName"].ToString());

            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerCredentials = irsc;
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["ServerUrl"].ToString());
            ReportViewer1.ServerReport.ReportPath = "/SMEReports/SLACOBookingProc";

            List<ReportParameter> paramList = new List<ReportParameter>();

            paramList.Add(new ReportParameter("userid", Session["UserID"].ToString(), false));
            paramList.Add(new ReportParameter("region", region, false));
            paramList.Add(new ReportParameter("CBC", CBC, false));
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
			string branch	= DDL_BRANCH.SelectedValue;
			string cbc		= DDL_CBC.SelectedValue;
			string teamleader = DDL_TEAM.SelectedValue;
			string region   = DDL_REGION.SelectedValue;
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
					kriterianya="and (branch_Code = '" + branch + "')";
				}
				else
				{
					if(!cbc.Equals(""))
					{
						kriterianya="and (cbc_code = '" + cbc + "' )";
					}
					else
					{
						if (!region.Equals(""))
						{
							kriterianya="and (areaid = '" + region + "' )";
						}
						else
						{
							kriterianya="";
						}
					}
				}
				if (!teamleader.Equals(""))
				{
					kriterianya+="and (su_teamleader= '" + teamleader + "')";
				}

				if (!Session["bussunitid"].Equals(""))    
				{
					kriterianya += "and (businessunit in (" + Session["bussunitid"].ToString() + ")) ";
				}
				Conn.QueryString = "Delete from TMP_REPORT_COBOOKINGPROC where userid='" + Session["UserID"].ToString() + "'";
				Conn.ExecuteQuery();

				Conn.QueryString = "insert into TMP_REPORT_COBOOKINGPROC "+
					"SELECT hari, COUNT([#application]) AS [#application], SUM([TOTAL AMOUNT])AS [TOTAL AMOUNT] , '" + Session["UserID"].ToString() + "' AS userid from VW_REPORT_COBOOKINGPROC3 "+
					"WHERE  (convert(varchar, Startdate, 112) BETWEEN " + tanggal1_k + " AND " + tanggal2_k + ") AND (convert(varchar, enddate, 112) BETWEEN " + tanggal1_k + " AND " + tanggal2_k + ") " + kriterianya + " "+
					"GROUP BY hari";
				Conn.ExecuteQuery(1800);
				if (!action.Equals("PRINT"))
					Load_ReportViewer(tanggal1,tanggal2,region, cbc,branch, teamleader);
				else
					Response.Redirect("RptCOBookingProcPrint.aspx?userid=" + Session["UserID"].ToString() + "&tanggal1=" + tanggal1 + "&tanggal2=" + tanggal2 + "&region=" + region + "&cbc=" + cbc + "&branch=" + branch + "&teamleader=" + teamleader);

			}
		}

		private void GetCBC(string RegionSelect)
		{
			if(!RegionSelect.Equals(""))
			{
				Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
					"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and c.areaid = '" + RegionSelect + "' ";
				Conn.ExecuteQuery();
				DDL_CBC.Items.Clear();
				DDL_CBC.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					if (i==0)
						LBL_BRANCH.Text	= Conn.GetFieldValue(i,0);
					DDL_CBC.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
			}
			else
			{

				Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
					"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null ";
				Conn.ExecuteQuery();
				DDL_CBC.Items.Clear();
				DDL_CBC.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					if (i==0)
						LBL_BRANCH.Text	= Conn.GetFieldValue(i,0);
					DDL_CBC.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
			}
		}
		private void GetBranch(string code, string param)
		{   //DDL_CBC.SelectedValue
			string querynya;
			if(!param.Equals(""))
			{
				if (code=="BR")
				{
					querynya = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cbc_code='" + param + "'";
				}
				else
				{
					if (code=="RG")
					{
						//querynya = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cityid='" + param + "'";
						querynya = "select distinct branch_code, branch_name from rfbranch "+
							"inner join rfcity on rfbranch.cityid= rfcity.cityid where rfcity.areaid='" + param + "' ";
					}
					else
					{
						querynya = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH ";
					}
				}

				Conn.QueryString =  querynya;
				Conn.ExecuteQuery();
				DDL_BRANCH.Items.Clear();
				DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					if (i==0)
						LBL_BRANCH.Text	= Conn.GetFieldValue(i,0);
					DDL_BRANCH.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
			}
			else
			{
				if (code=="BR")
				{
					querynya = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH ";
				}
				else
				{
					if (code=="RG")
					{
						querynya = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH ";
					}
					else
					{
						querynya = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH ";
					}
				}

				Conn.QueryString =  querynya;
				Conn.ExecuteQuery();
				DDL_BRANCH.Items.Clear();
				DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					if (i==0)
						LBL_BRANCH.Text	= Conn.GetFieldValue(i,0);
					DDL_BRANCH.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
			}
		}

		protected void DDL_REGION_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillCBC();
		}

		protected void DDL_CBC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillBranch();
		}

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportSLA.aspx?mc=" + Request.QueryString["mc"]);
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
