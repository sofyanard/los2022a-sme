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
	/// Summary description for RptCoNotaryMntr.
	/// </summary>
	public partial class RptCoNotaryMntr : System.Web.UI.Page
	{
		protected Connection Conn;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Conn = (Connection) Session["Connection"];

			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], Conn))
				//Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				LBL_BU.Text = Request.QueryString["BU"];
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

				LBL_RM.Text = "'0002','0004'";
				Conn.QueryString = "select rmcode from app_parameter ";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					LBL_RM.Text = Conn.GetFieldValue(0,0);
				}

				Label1.Text = Posisi_User().ToString();
				fillRegion();
				fillNotary();
			}
			Conn.QueryString = "delete from TMP_REPORT_CONOTARYMONITORING where userid='" + Session["UserID"].ToString() + "'";
			Conn.ExecuteQuery();

			//Load_Data();
			//BTN_LIHAT.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
		}

		private void fillNotary()
		{
			DDL_NOTARY.Items.Clear();
			DDL_NOTARY.Items.Add(new ListItem("-- PILIH --",""));
			Conn.QueryString = "select NTID, NTID + ' - ' + NT_NAME as NT_NAME from rfnotary where ACTIVE='1'";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_NOTARY.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}
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
			fillRM();
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

		

		private void Load_ReportViewer(string Start_Date, string End_Date, string region, string CBC, string Branch, string RM, string teamleader, string notary)
		{
			/*
			string tanggal1	= tool.ConvertDate(Start_Date);
			string tanggal2	= tool.ConvertDate(End_Date);
			*/
			string tanggal1	= Start_Date;
			string tanggal2	= End_Date;
			tanggal1		= tanggal1.Replace("'","");
			tanggal2		= tanggal2.Replace("'","");

            //ReportViewer2.ReportPath = "/SMEReports/RptCoNotaryMnt&userid=" + Session["UserID"].ToString() + "&start_date='" + tanggal1 + "'&end_date='" + tanggal2 + "'&region=" + region + "&cbc=" + CBC + "&branch=" + Branch + "&teamleader=" + teamleader + "&rm=" + RM + "&notary=" + notary + "&rs:Command=Render&rc:Toolbar=True";

            IReportServerCredentials irsc = new CustomReportCredentials(WebConfigurationManager.AppSettings["ReportUser"].ToString(), WebConfigurationManager.AppSettings["ReportPassword"].ToString(), WebConfigurationManager.AppSettings["DomainName"].ToString());

            ReportViewer2.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer2.ServerReport.ReportServerCredentials = irsc;
            ReportViewer2.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["ServerUrl"].ToString());
            ReportViewer2.ServerReport.ReportPath = "/SMEReports/RptCoNotaryMnt";

            List<ReportParameter> paramList = new List<ReportParameter>();

            paramList.Add(new ReportParameter("userid", Session["UserID"].ToString(), false));
            paramList.Add(new ReportParameter("region", region, false));
            paramList.Add(new ReportParameter("CBC", CBC, false));
            paramList.Add(new ReportParameter("branch", Branch, false));
            paramList.Add(new ReportParameter("rm", RM, false));
            paramList.Add(new ReportParameter("start_date", tanggal1, false));
            paramList.Add(new ReportParameter("end_date", tanggal2, false));
            paramList.Add(new ReportParameter("teamleader", teamleader, false));
            paramList.Add(new ReportParameter("notary", notary, false));

            ReportViewer2.ServerReport.SetParameters(paramList);
            ReportViewer2.ServerReport.Refresh();
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

		private void LoadSql(string action )
		{
			
			string kriterianya = "";
			string branch	= DDL_BRANCH.SelectedValue;
			string teamleader = DDL_TEAM.SelectedValue;
			string rm		= DDL_RM.SelectedValue;
			string cbc		= DDL_CBC.SelectedValue;
			string region   = DDL_REGION.SelectedValue;
			string notary   = DDL_NOTARY.SelectedValue;
			string tanggal1 = "";
			string tanggal2 = "";

			string tanggal1_k = "";
			string tanggal2_k = "";
			
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
					Conn.QueryString = "delete from TMP_REPORT_CONOTARYMONITORING where userid='" + Session["UserID"].ToString() + "'";
				Conn.ExecuteQuery();

				if (!rm.Equals("")) 
				{ 
					kriterianya = "and (AP_RelMngr = ''" + rm + "'') ";
				}
				else
				{
					if(!branch.Equals(""))
					{
						kriterianya = "and (BRANCH_CODE = ''"+branch + "'') ";
					}
					else
					{
						if (!cbc.Equals(""))
						{
							kriterianya = "and (CBC_CODE = ''" + cbc + "'') ";				
						}
						else
						{
							if(!region.Equals(""))
							{
								kriterianya = "and (areaid= ''" + region + "'') ";				
							}
							else
							{
								//kriterianya = "and (BS_REQDATE BETWEEN " + tanggal1 + " AND " + tanggal2 + ")";	asdf			    
							}
						}
					}
				}
				if((!teamleader.Equals(""))&&(teamleader.ToString()!="All"))
				{
					kriterianya += "and (su_teamleader= ''" + teamleader + "'') ";
				}
				
				if ((!notary.Equals(""))&&(notary.ToString()!="All"))
				{
					kriterianya += "and (NotaryID= ''" + notary + "'') ";
				}

				if (!Session["bussunitid2"].Equals(""))    
				{
					kriterianya += "and (businessunit in (" + Session["bussunitid2"].ToString() + ")) ";
				}
				Conn.QueryString="exec sp_rpt_CoNotaryMntr '" + Session["UserID"].ToString() + "','" + tanggal1_k + "','" + tanggal2_k + "','" + kriterianya + "'";
				Conn.ExecuteQuery(1800);

                if (!action.Equals("PRINT"))
				Load_ReportViewer(tanggal1,tanggal2,region, cbc,branch,rm, teamleader, notary);
				else
				Response.Redirect("RptCONotaryMntrPrint.aspx?userid=" + Session["UserID"].ToString() + "&tanggal1=" + tanggal1 + "&tanggal2=" + tanggal2 + "&region=" + region + "&cbc=" + cbc + "&branch=" + branch + "&teamleader=" + teamleader + "&rm=" + rm + "&notary=" + notary);
			}
			else
			{
				Response.Write("<script language='javascript'>alert('Invalid Date !')</script>");
			}
		}


		private void GetCBC(string RegionSelect)
		{
			if(!RegionSelect.Equals(""))
			{
				//Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name from rfbranch b where b.cityid = '" + RegionSelect + "'";
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
				//Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name from rfbranch b where b.cityid = '" + RegionSelect + "'";
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
		}

		private void Get_RM(string branchnya)
		{
			if (!branchnya.Equals(""))
			{
				Conn.QueryString = "SELECT DISTINCT APPLICATION.AP_RELMNGR, SCUSER.SU_FULLNAME "+
					"FROM APPLICATION INNER JOIN SCUSER ON APPLICATION.AP_RELMNGR = SCUSER.USERID "+
					"where su_branch='" + branchnya + "' ";
				Conn.ExecuteQuery();
				
				DDL_RM.Items.Clear();
				DDL_RM.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					if (i==0)
						LBL_RM.Text	= Conn.GetFieldValue(i,0);
					DDL_RM.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
			}
			else
			{
				Conn.QueryString = "SELECT DISTINCT APPLICATION.AP_RELMNGR, SCUSER.SU_FULLNAME FROM APPLICATION INNER JOIN SCUSER ON APPLICATION.AP_RELMNGR = SCUSER.USERID";
				Conn.ExecuteQuery();
				DDL_RM.Items.Clear();
				DDL_RM.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					if (i==0)
						LBL_RM.Text	= Conn.GetFieldValue(i,0);
					DDL_RM.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
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

		protected void DDL_BRANCH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillTeamLeader();
			fillRM();
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
