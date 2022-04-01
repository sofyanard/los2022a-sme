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
using DMS.CuBESCore;
using Microsoft.VisualBasic;
using System.Web.Configuration;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Net;
using SME.SourceSMEReport;

namespace SourceSMEReport
{
	/// <summary>
	/// Summary description for RptAccPerfomance.
	/// </summary>
	public partial class RptAccPerfomance : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection Conn = new Connection();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			string branch ="", area="", teamleader="";
			Conn = (Connection) Session["Connection"];

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

				Label1.Text = Posisi_User().ToString();
				fillRegion();

				if(branch.Equals(""))
                   branch="All";
				if(area.Equals(""))
                   area = "All";
				if (teamleader.Equals(""))
					teamleader="All";
           		
			}
		}

		private void fillRegion()
		{
			DDL_AREA.Items.Clear();
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
					DDL_AREA.Items.Add(new ListItem("-- PILIH --",""));
					break;
			}
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_AREA.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
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
						Session["CBC"].ToString() + "' and Branch_Code='" + Session["BranchID"].ToString() + "' ";
					break;
					
				default:
					Conn.QueryString =  "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where areaid='" + DDL_AREA.SelectedValue + "' ";
					DDL_Branch.Items.Add(new ListItem("-- PILIH --",""));
					break;
			}
			if(DDL_AREA.SelectedValue != "")
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

		

		private void ViewReport(string action)
		{
			string branch	= DDL_Branch.SelectedValue;
			string area		= DDL_AREA.SelectedValue;
			string teamleader = DDL_TEAM.SelectedValue;

			string tanggal1 = tools.ConvertDate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);
			tanggal1		= tanggal1.Substring(1,tanggal1.Length-2).ToString();
			string tanggal2 = tools.ConvertDate(TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text);
			tanggal2		= tanggal2.Substring(1,tanggal2.Length-2).ToString();
			
			string tanggal1_k = Tools.toISODate(TXT_TGL1,DDL_BLN1,TXT_THN1);
			string tanggal2_k = Tools.toISODate(TXT_TGL2,DDL_BLN2,TXT_THN2);

			/*
			if (!Information.IsDate(tanggal1) || !Information.IsDate(tanggal2))
				{
					Tools.popMessage(this,"Invalid date");
					if (!Information.IsDate(tanggal1))
						Tools.SetFocus(this,TXT_TGL1);
					else
						Tools.SetFocus(this,TXT_TGL2);
				}
				else
			*/
					LoadReport(action,tanggal1,tanggal2,branch,area, teamleader, tanggal1_k, tanggal2_k);
		}

		

		private void LoadReport(string action,string tgl1, string tgl2, string branch, string area, string teamleader, string tanggal1_k, string tanggal2_k)
		{   string kriterianya;
			string tanggal1 = tools.ConvertDate(tgl1);
			string tanggal2 = tools.ConvertDate(tgl2);
			tanggal1	= tanggal1.Replace("'","");
			tanggal2	= tanggal2.Replace("'","");

            IReportServerCredentials irsc = new CustomReportCredentials(WebConfigurationManager.AppSettings["ReportUser"].ToString(), WebConfigurationManager.AppSettings["ReportPassword"].ToString(), WebConfigurationManager.AppSettings["DomainName"].ToString());

            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerCredentials = irsc;
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["ServerUrl"].ToString());

				if (!branch.Equals(""))
				{
					kriterianya = "and (BRANCH_CODE= ''" + branch + "'') ";
				}
				else
				{
					if (!area.Equals(""))
					{
						kriterianya = "and (areaid= ''" + area + "'') ";				
					}
					else
					{
						kriterianya="";
					}
				}
				if (!teamleader.Equals(""))
				{
					kriterianya = "and (su_teamleader= ''" + teamleader + "'') ";
				}
				else
				{
					teamleader = "All";
				}

			    if (!Session["bussunitid2"].Equals("")) //ahmad: pake bussunitid2  
				{
					kriterianya += "and (businessunit in (" + Session["bussunitid2"].ToString() + ")) ";
				}
				Conn.QueryString = "delete from TMP_REPORT_ACCPERFORM1 where userid='" + Session["UserID"].ToString()+ "' ";
				Conn.ExecuteQuery();


				Conn.QueryString = " exec RPT_ACCPERFORMANCE '" + Session["UserID"].ToString() + "','" + tanggal1_k + "','" + tanggal2_k  + "','" + kriterianya + "'";
                Conn.ExecuteQuery(1800);

                if (!action.Equals("PRINT"))
                {
                    //ReportViewer1.ReportPath = "/SMEReports/RptAccPerfomancePS&userid=" + Session["UserID"].ToString() + "&tgl1=" + tanggal1 + "&tgl2=" + tanggal2 + "&branch=" + branch + "&teamleader=" + teamleader + "&area=" + area + "&rs:Command=Render&rc:Toolbar=True";
                    ReportViewer1.ServerReport.ReportPath = "/SMEReports/RptAccPerfomancePS";

                    List<ReportParameter> paramList = new List<ReportParameter>();

                    paramList.Add(new ReportParameter("userid", Session["UserID"].ToString(), false));
                    paramList.Add(new ReportParameter("area", area, false));
                    paramList.Add(new ReportParameter("branch", branch, false));
                    paramList.Add(new ReportParameter("tgl1", tanggal1, false));
                    paramList.Add(new ReportParameter("tgl2", tanggal2, false));
                    paramList.Add(new ReportParameter("teamleader", teamleader, false));

                    ReportViewer1.ServerReport.SetParameters(paramList);
                    ReportViewer1.ServerReport.Refresh();
                }
                else
                    Response.Redirect("RptAccPerformance1Print.aspx?userid=" + Session["UserID"].ToString() + "&tanggal1=" + tanggal1 + "&tanggal2=" + tanggal2 + "&region=" + area + "&branch=" + branch + "&teamleader=" + teamleader);
   	}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			ViewReport("");
		}

		protected void DDL_Branch_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillTeamLeader();
		}
		private void GetCBC(string RegionSelect)
		{
			if(!RegionSelect.Equals(""))
			{
            	Conn.QueryString = "select distinct branch_code, branch_name from rfbranch "+
                                   "inner join rfcity on rfbranch.cityid= rfcity.cityid where rfcity.areaid='" + RegionSelect + "' ";
				Conn.ExecuteQuery();
				DDL_Branch.Items.Clear();
				DDL_Branch.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					DDL_Branch.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
			}
			else
			{
				Conn.QueryString = "select distinct branch_code, branch_name from rfbranch "+
					"inner join rfcity on rfbranch.cityid= rfcity.cityid ";				
				Conn.ExecuteQuery();
				DDL_Branch.Items.Clear();
				DDL_Branch.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					DDL_Branch.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
			}
		}

		protected void DDL_AREA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillBranch();
		}

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportOR.aspx?mc=" + Request.QueryString["mc"] + "&BU=" + LBL_BU.Text);
		}

		


		protected void Btn_Print_Click(object sender, System.EventArgs e)
		{
			ViewReport("PRINT");
		}
	}
}

