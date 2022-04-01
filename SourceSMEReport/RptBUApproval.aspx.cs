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
	/// Summary description for RptBUApproval.
	/// </summary>
	public partial class RptBUApproval : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
//		protected Connection Conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection Conn = new Connection(); 

		protected void Page_Load(object sender, System.EventArgs e)
		{
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

				////// approval tergantung dari branch
				///
//				Conn.QueryString = "select userid, su_fullname from scuser where groupid like '02%'";
//				Conn.ExecuteQuery();
//				ddl_approval.Items.Clear();
//				ddl_approval.Items.Add(new ListItem("-- PILIH --",""));
//				for (int i = 0; i < Conn.GetRowCount(); i++)
//				{
//					String s0 = Conn.GetFieldValue(i,0),
//						s1 = Conn.GetFieldValue(i,1);
//					ListItem li = new ListItem(s1,s0);
//					ddl_approval.Items.Add(li);
//				}
//				DDL_TEAM.Items.Clear();
//				DDL_TEAM.Items.Add(new ListItem("-- PILIH --",""));
				FillProgram();
				FillEkonomy();
			}
		
		}

		
		private void Load_ReportViewer(string action,string sql_kondisi, string Start_Date, string End_Date, string region, string CBC, string Branch, string teamleader, string approval, string  program, string ekonomi)
		{
			string tanggal1	= Start_Date;
			string tanggal2	= End_Date;
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
			sql_kondisi += "AND (convert(nvarchar, ap_signdate, 112) between " + tanggal1_k + " and " + tanggal2_k + ") ";
			
			/*
            if (!Session["bussunitid2"].Equals(""))    
			{
				sql_kondisi += "and (businessunit in (" + Session["bussunitid2"].ToString().Replace("''","'") + ")) ";
			}
            */
            if ((!Session["BussUnit"].Equals("")) && (Session["BussUnit"] != null))
            {
                sql_kondisi += "and (businessunit in ('" + Session["BussUnit"].ToString() + "')) ";
            }

            IReportServerCredentials irsc = new CustomReportCredentials(WebConfigurationManager.AppSettings["ReportUser"].ToString(), WebConfigurationManager.AppSettings["ReportPassword"].ToString(), WebConfigurationManager.AppSettings["DomainName"].ToString());

            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerCredentials = irsc;
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["ServerUrl"].ToString());

            if (!action.Equals("PRINT"))
            {
                //ReportViewer1.ReportPath = "/SMEReports/RptBUApproval&sql_kondisi=" + sql_kondisi + "&Start_Date=" + tanggal1 + "&End_Date=" + tanggal2 + "&region=" + region + "&CBC=" + CBC + "&BRANCH=" + Branch + "&teamleader=" + teamleader + "&approval=" + approval + "&program=" + program + "&ekonomi=" + ekonomi + "&rs:Command=Render&rc:Toolbar=True";
                ReportViewer1.ServerReport.ReportPath = "/SMEReports/RptBUApproval";

                List<ReportParameter> paramList = new List<ReportParameter>();

                paramList.Add(new ReportParameter("sql_kondisi", sql_kondisi, false));
                paramList.Add(new ReportParameter("region", region, false));
                paramList.Add(new ReportParameter("CBC", CBC, false));
                paramList.Add(new ReportParameter("BRANCH", Branch, false));
                paramList.Add(new ReportParameter("Start_Date", tanggal1, false));
                paramList.Add(new ReportParameter("End_Date", tanggal2, false));
                paramList.Add(new ReportParameter("teamleader", teamleader, false));
                paramList.Add(new ReportParameter("approval", approval, false));
                paramList.Add(new ReportParameter("program", program, false));
                paramList.Add(new ReportParameter("ekonomi", ekonomi, false));

                ReportViewer1.ServerReport.SetParameters(paramList);
                ReportViewer1.ServerReport.Refresh();
            }
            else
            {
                int vAccept = 0, vReject = 0, vCompleted = 0, vPending = 0;
                Conn.QueryString = "exec rpt_buapproval '" + sql_kondisi.Replace("'", "''") + "' ";
                Conn.ExecuteQuery(1800);
                for (int i = 0; i < Conn.GetRowCount(); i++)
                {
                    vAccept += int.Parse(Conn.GetFieldValue(i, "jum_accept"));
                    vReject += int.Parse(Conn.GetFieldValue(i, "jum_reject"));
                    vCompleted += int.Parse(Conn.GetFieldValue(i, "jum_Completed"));
                    vPending += int.Parse(Conn.GetFieldValue(i, "jum_Pending "));
                }
                sql_kondisi = sql_kondisi.Replace("'", "''");
                sql_kondisi = Server.HtmlEncode(sql_kondisi);
                Response.Redirect("RptBUApprovalPrint.aspx?sql_kondisi=" + sql_kondisi + "&Start_Date=" + tanggal1 + "&End_Date=" + tanggal2 + "&region=" + region + "&CBC=" + CBC + "&BRANCH=" + Branch + "&teamleader=" + teamleader + "&approval=" + approval + "&program=" + program + "&ekonomi=" + ekonomi + "&Accept=" + vAccept.ToString() + "&Reject=" + vReject.ToString() + "&Completed=" + vCompleted.ToString() + "&Pending=" + vPending.ToString() + " ");
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


	
		private void fillRegion()
		{
			DDL_REGION.Items.Clear();
			switch(Label1.Text)
			{
				case "1": case "2":
					Conn.QueryString = "select AreaID, AREANAME from rfarea where AreaID='" + Session["AreaID"].ToString() + "' order by AREANAME ";
					break;
				case "3": 
					Conn.QueryString = "select AreaID, AREANAME from rfarea where arearegmanager='" + Session["UserID"].ToString() + "' order by AREANAME ";
					break;
				default:
					Conn.QueryString = "select AreaID, AREANAME from rfarea order by AREANAME";
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
						"and b.Branch_CODE='" + Session["BranchID"].ToString() + "' order by branch_name ";
					break;
				case "2":
					Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_code <>'' and b.areaid = '" + DDL_REGION.SelectedValue + "' "+
						"and b.CBC_code='" + Session["CBC"].ToString() + "' order by branch_name ";
					break;
				default:
					Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_code <>'' and b.areaid = '" + DDL_REGION.SelectedValue + "' order by branch_name ";
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
			DDL_Branch.Items.Clear();
			switch(Label1.Text)
			{
				case "1": 
					Conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cbc_code='" +
						DDL_CBC.SelectedValue + "' and Branch_Code='" + Session["BranchID"].ToString() + "' order by BRANCH_NAME";
					break;
				default:
					Conn.QueryString =  "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cbc_code='" + 
						DDL_CBC.SelectedValue + "' and areaid='" + DDL_REGION.SelectedValue + "' order by BRANCH_NAME";
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
			fillTeamLeader();
			fillApproval();
		}

	
		private void fillApproval()
		{
			//GlobalTools.popMessage(this,DDL_Branch.SelectedValue);
			ddl_approval.Items.Clear();
			Conn.QueryString = "exec Rpt_BUApproval_list '"+ DDL_Branch.SelectedValue +"' ";
			ddl_approval.Items.Add(new ListItem("-- PILIH --",""));
			if(DDL_Branch.SelectedValue != "")
			{
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					ddl_approval.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
			}
//			
//			if (DDL_Branch.SelectedValue != "")
//			{
//				GlobalTools.fillRefList(ddl_approval,"select userid, su_fullname from scuser where groupid like '02%'"+
//					" and su_branch = ' " + DDL_Branch.SelectedValue + " '",true, Conn);
//			}
		}

		private void fillTeamLeader()
		{
			DDL_TEAM.Items.Clear();
			Conn.QueryString = "select distinct a.su_teamleader, b.su_fullname fullname"+
				" from scuser A left join scuser B on b.userid = a.su_teamleader "+
				"where a.su_teamleader is not null and A.su_branch='" + DDL_Branch.SelectedValue + "' order by fullname";
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


		private void FillEkonomy()
		{
			Conn.QueryString = "SELECT busstypeid, busstypedesc  FROM RFBusinessType where active = '1' AND LEN(BUSSTYPEID) < 3 order by busstypeid asc ";
			Conn.ExecuteQuery();
			DDL_EKONOMY.Items.Clear();
			DDL_EKONOMY.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				String s0 = Conn.GetFieldValue(i,0),
					s1 = Conn.GetFieldValue(i,1);
				ListItem li = new ListItem(s1,s0);
				DDL_EKONOMY.Items.Add(li);
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

		
		protected void BTN_LIHAT_Click(object sender, System.EventArgs e)
		{
			LoadSql("");
		}

		private void LoadSql(string action)
		{
			string kriterianya = "";
			string branch	= DDL_Branch.SelectedValue;
			string cbc		= DDL_CBC.SelectedValue;
			string region   = DDL_REGION.SelectedValue;
			string teamleader = DDL_TEAM.SelectedValue;
			string approval = ddl_approval.SelectedValue;
			string ekonomy = DDL_EKONOMY.SelectedValue;
			string program = DDL_PROGRAM.SelectedValue;
			string tanggal1 = tools.ConvertDate(TXT_Day1.Text,DDL_Month1.SelectedValue,TXT_Year1.Text);
			string tanggal2 = tools.ConvertDate(TXT_Day2.Text,DDL_Month2.SelectedValue,TXT_Year2.Text);
			
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
				if (!region.Equals(""))
				{
					kriterianya+="and (areaid = '" + region + "' )";
				}
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
					kriterianya+="and (ap_teamleader= '" + teamleader + "')";
				}
				if (!approval.Equals(""))
				{
					kriterianya+="and (th_trackby = '" + approval + "') ";
				}
				if (!program.Equals(""))
				{
					kriterianya+="and (prog_code='" + program + "') ";
				}
				if (!ekonomy.Equals(""))
				{
					kriterianya+="and (EkonomyID='" + ekonomy + "') ";
				}
				Load_ReportViewer(action,kriterianya, tanggal1, tanggal2,region, cbc,branch, teamleader, approval, program, ekonomy);
			}
		}

	
		protected void DDL_REGION_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillCBC();
		}

		private void DDL_CBC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillBranch();
		}

		

		private void DDL_PROGRAM_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		}

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportOR.aspx?mc=" + Request.QueryString["mc"] + "&BU=" + LBL_BU.Text);
		}

		protected void Btn_Print_Click(object sender, System.EventArgs e)
		{
			LoadSql("PRINT");
		}

		protected void DDL_Branch_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//GlobalTools.popMessage(this,DDL_Branch.SelectedValue);
			fillTeamLeader();
			fillApproval();
		}

		

		
	}
}
