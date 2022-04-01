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

namespace SourceSMEReport
{
	/// <summary>
	/// Summary description for RptCustResponse.
	/// </summary>
	public partial class RptCustResponse : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.Button BTN_CANCEL;
		protected Connection Conn;
		protected Tools tool = new Tools();
        protected string vRMCODE  = ""; 

		protected void Page_Load(object sender, System.EventArgs e)
		{
			Conn = (Connection) Session["Connection"];
			
			LBL_BU.Text = Request.QueryString["BU"];

			Conn.QueryString = "select rmcode from app_parameter ";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
			{
				vRMCODE = Conn.GetFieldValue(0,0);
			}

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

				LBL_RM.Text = "'0002','0004'";
				Conn.QueryString = "select rmcode from app_parameter ";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					LBL_RM.Text = Conn.GetFieldValue(0,0);
				}

				Label1.Text = Posisi_User().ToString();
				fillRegion();
			}
            /*
			Conn.QueryString = "delete from TMP_REPORT_CUSTRESPONSE where userid='" + Session["UserID"].ToString() + "'";
			Conn.ExecuteQuery();
            */
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
						"from rfbranch b  where cbc_Code is not null and cbc_code <>'' and b.areaid = '" + DDL_REGION.SelectedValue + "' "+
						"and b.Branch_CODE='" + Session["BranchID"].ToString() + "' ";
					break;
				case "2":
					Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b where cbc_Code is not null and cbc_code <>'' and b.areaid = '" + DDL_REGION.SelectedValue + "' "+
						"and b.CBC_code='" + Session["CBC"].ToString() + "' ";
					break;
				
				default:
					Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b  where cbc_Code is not null and cbc_code <>'' and b.areaid = '" + DDL_REGION.SelectedValue + "' ";
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
            if ((Session["BranchID"].ToString() == "000") || (Session["BranchID"].ToString() == "001"))
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

		private void Load_Data()
		{
			string tanggal1="", tanggal2="", cbc="", branch="", rm="", region="", teamleader="";
			branch		= DDL_BRANCH.SelectedValue;
			teamleader  = DDL_TEAM.SelectedValue;
			rm			= DDL_RM.SelectedValue;
			cbc			= DDL_CBC.SelectedValue;
			region      = DDL_REGION.SelectedValue;
			tanggal1	= tool.ConvertDate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);
			tanggal2	= tool.ConvertDate(TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text);
			if (region.Equals(""))
				region = "All"; // LBL_REGION.Text; 
			if (branch.Equals(""))
				branch	= "All"; // LBL_BRANCH.Text;
			if (rm.Equals(""))
				rm	= "All"; // LBL_RM.Text;
			if (cbc.Equals(""))
				cbc	= "All"; // LBL_CBC.Text;
			if (!teamleader.Equals(""))
				teamleader="All";

			/*
			if (!Information.IsDate(tanggal1))
				tanggal1	= DateTime.Today.ToString();
			if (!Information.IsDate(tanggal2))
				tanggal2	= DateTime.Today.ToString();
			*/
			Load_ReportViewer(tanggal1,tanggal2,region, cbc,branch,rm, teamleader);
		}

		private void Load_ReportViewer(string Start_Date, string End_Date, string region, string CBC, string Branch, string RM, string teamleader)
		{
			/*
			string tanggal1	= Tool.ConvertDate(Start_Date);
			string tanggal2	= Tool.ConvertDate(End_Date);
			*/
			string tanggal1 = Start_Date;
			string tanggal2 = End_Date;
			tanggal1		= tanggal1.Replace("'","");
			tanggal2		= tanggal2.Replace("'","");

            //ReportViewer1.ReportPath = "/SMEReports/CustrResponseRpt&userid=" + Session["UserID"].ToString() + "&Start_Date=" + tanggal1 + "&End_Date=" + tanggal2 + "&AREA=" + region + "&CBC=" + CBC + "&BRANCH=" + Branch + "&RM=" + RM + "&teamleader=" + teamleader + "&rs:Command=Render&rc:Toolbar=True";

            IReportServerCredentials irsc = new CustomReportCredentials(WebConfigurationManager.AppSettings["ReportUser"].ToString(), WebConfigurationManager.AppSettings["ReportPassword"].ToString(), WebConfigurationManager.AppSettings["DomainName"].ToString());

            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerCredentials = irsc;
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["ServerUrl"].ToString());
            ReportViewer1.ServerReport.ReportPath = "/SMEReports/CustrResponseRpt";

            List<ReportParameter> paramList = new List<ReportParameter>();

            paramList.Add(new ReportParameter("userid", Session["UserID"].ToString(), false));
            paramList.Add(new ReportParameter("AREA", region, false));
            paramList.Add(new ReportParameter("CBC", CBC, false));
            paramList.Add(new ReportParameter("BRANCH", Branch, false));
            paramList.Add(new ReportParameter("RM", RM, false));
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
			string teamleader = DDL_TEAM.SelectedValue;
			string rm		= DDL_RM.SelectedValue;
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
					Conn.QueryString = "delete from TMP_REPORT_CUSTRESPONSE where userid='" + Session["UserID"].ToString() + "'";
				Conn.ExecuteQuery();

				if (!rm.Equals("")) 
				{ 
					kriterianya = "and (AP_RelMngr = ''" + rm + "'') ";
					if (!teamleader.Equals(""))
					{
						kriterianya += "and (su_teamleader = ''" + teamleader + "'') ";
					}
				}
				else
				{
					if(!branch.Equals(""))
					{
						kriterianya = "and (BRANCH_CODE = ''" + branch + "'') ";
						if (!teamleader.Equals(""))
						{
							kriterianya += "and (su_teamleader = ''" + teamleader + "'') ";
						}
					}
					else
					{
						if (!cbc.Equals(""))
						{
							kriterianya = "and (CBC_CODE = ''" + cbc + "'') ";				
							if (!teamleader.Equals(""))
							{
								kriterianya += "and (su_teamleader = ''" + teamleader + "'') ";
							}
						}
						else
						{
							if(!region.Equals(""))
							{
								kriterianya = "and (areaid= ''" + region + "'') ";				
								if (!teamleader.Equals(""))
								{
									kriterianya += "and (su_teamleader = ''" + teamleader + "'') ";
								}
							}
							else
							{
								if (!teamleader.Equals(""))
								{
									kriterianya += "and (su_teamleader = ''" + teamleader + "'') ";
								}
							}
						}
					}
				}

				/*
                if (!Session["bussunitid2"].Equals("")) //ahmad: pake bussunitid2
				{
					kriterianya += "and (businessunit in (" + Session["bussunitid2"].ToString() + ")) ";
				}
                */
                if ((!Session["BussUnit"].Equals("")) && (Session["BussUnit"] != null))
                {
                    kriterianya += "and (businessunit in (''" + Session["BussUnit"].ToString() + "'')) ";
                }
			
				Conn.QueryString = "exec RPT_CUSTRESPONSE '" + Session["UserID"].ToString() + "','" + tanggal1_k + "','" + tanggal2_k + "','" + kriterianya + "'";
				Conn.ExecuteQuery(1800);
                if (!action.Equals("PRINT")) 
				Load_ReportViewer(tanggal1,tanggal2,region, cbc,branch,rm, teamleader);
				else
				Response.Redirect("RptCustRepornsePrint.aspx?userid=" + Session["UserID"].ToString() + "&tanggal1=" + tanggal1 + "&tanggal2=" + tanggal2 + "&region=" + region + "&cbc=" + cbc + "&branch=" + branch + "&teamleader=" + teamleader + "&rm=" + rm);
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
		{  
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

		
		private void GetRM(string caller, string paramnya)
		{
			if(!paramnya.Equals(""))
			{
				if (caller=="RG") 
				{   
					Conn.QueryString = "select userid, su_fullname "+
						"from SCUSER A inner join RFBRANCH B on A.Su_Branch=B.Branch_Code "+
						"inner join rfcity C on B.CityID=C.CityID "+ 
						"inner join RFArea D on C.AreaID = D.AreaID "+
						"where A.Groupid in (" + vRMCODE + ") and D.AreaID='" + paramnya + "' ";
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
					if (caller=="CBC") 
					{
						Conn.QueryString = "select distinct userid, su_fullname "+
							"from SCUSER A inner join RFBRANCH B on A.Su_Branch=B.Branch_Code "+
							"where A.Groupid in (" + vRMCODE + ") and B.CBC_code='" + paramnya + "' ";
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
						if (caller=="BR")
						{
							Conn.QueryString = "select userid, su_fullname "+
								"from SCUSER A inner join RFBRANCH B on A.Su_Branch=B.Branch_Code "+
								"where A.Groupid in (" + vRMCODE + ") and B.branch_code='" + paramnya + "' ";
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
							Conn.QueryString = "select userid, su_fullname "+
								"from SCUSER where Groupid in (" + vRMCODE + ") ";
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
				}
			}
			else
			{
				Conn.QueryString = "select userid, su_fullname "+
					"from SCUSER where Groupid in (" + vRMCODE + ") ";
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

		protected void DDL_CBC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillBranch();
		}

		protected void DDL_REGION_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillCBC();
		}

		protected void DDL_BRANCH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
           fillTeamLeader();
			fillRM();
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
