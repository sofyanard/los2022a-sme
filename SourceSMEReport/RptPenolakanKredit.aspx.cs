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
	/// Summary description for RptPenolakanKredit.
	/// </summary>
	public partial class RptPenolakanKredit : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected Tools Tool = new Tools(); 
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Conn = (Connection) Session["Connection"];
			LBL_BU.Text = Request.QueryString["BU"];

			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], Conn))
			//Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
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
			
				FillProgram();
				LBL_BRANCH.Text = Posisi_User().ToString();
				fillCBC();
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
				if (i==0) 
				{
					LBL_PROGRAM.Text = Conn.GetFieldValue(0,0);
				} 
				String s0 = Conn.GetFieldValue(i,0),
					s1 = Conn.GetFieldValue(i,1);
				ListItem li = new ListItem(s1,s0);
				DDL_PROGRAM.Items.Add(li);
			}
			FillProduct();
		}
 
		private void FillProduct()
		{
			Conn.QueryString = "select distinct rfproduct.productid, rfproduct.productdesc from rfproduct left join prog_prod "+
				"on rfproduct.productid= prog_prod.productid  where rfproduct.active='1' and prog_prod.programid= '" + DDL_PROGRAM.SelectedValue.ToString() + "'";
			DDL_Product.Items.Clear();
			DDL_Product.Items.Add(new ListItem("-- PILIH --",""));
			if (DDL_PROGRAM.SelectedValue!="")
			{
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					String s0 = Conn.GetFieldValue(i,0),
						s1 = Conn.GetFieldValue(i,1);
					ListItem li = new ListItem(s1,s0);
					DDL_Product.Items.Add(li);
				}		
			}
		}

		private void fillCBC()
		{
			DDL_CBC.Items.Clear();
			switch(LBL_BRANCH.Text)
			{
				case "1": 
					Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_Code<>'' and b.areaid = '" + Session["AreaID"].ToString() + "' "+
						"and b.Branch_CODE='" + Session["BranchID"].ToString() + "' ";
					break;
				case "2":
					Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_Code<>'' and b.areaid = '" + Session["AreaID"].ToString() + "' "+
						"and b.CBC_code='" + Session["CBC"].ToString() + "' ";
					break;
				case "3": 
					Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b left join rfcity c on b.cityid=c.cityid and b.areaid = c.areaid where cbc_Code is not null and cbc_Code<>'' and b.areaid = " + 
						"(select top 1 AreaID from rfarea where arearegmanager='" + Session["UserID"].ToString() + "') ";
					DDL_CBC.Items.Add(new ListItem("-- PILIH --",""));
					break;
				default:
					Conn.QueryString = "select distinct cbc_code, (select branch_name from rfbranch A where A.branch_code=b.cbc_code) branch_name "+
						"from rfbranch b left join rfcity c on b.cityid=c.cityid where cbc_Code is not null and cbc_Code<>'' ";
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
			DDL_Branch.Items.Clear();
			switch(LBL_BRANCH.Text)
			{
				case "1": 
					Conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cbc_code='" +
						DDL_CBC.SelectedValue + "' and Branch_Code='" + Session["BranchID"].ToString() + "' ";
					break;
				case "2":
					Conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cbc_code='" + 
						DDL_CBC.SelectedValue + "' and areaid='" + Session["AreaID"].ToString() + "' ";
					DDL_Branch.Items.Add(new ListItem("-- PILIH --",""));
					break;
				case "3": 
					Conn.QueryString =  "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cbc_code='" +
						DDL_CBC.SelectedValue + "' and areaid= (select top 1 AreaID from rfarea where " +
						"arearegmanager='" + Session["UserID"].ToString() + "') ";
					DDL_Branch.Items.Add(new ListItem("-- PILIH --",""));
					break;
				default:
					Conn.QueryString =  "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where cbc_code='" + 
						DDL_CBC.SelectedValue + "' ";
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
		}

		private void fillTeamLeader()
		{
			ddl_team.Items.Clear();
			Conn.QueryString = "select distinct a.su_teamleader, b.su_fullname "+
				"from scuser A left join scuser B on b.userid = a.su_teamleader "+
				"where a.su_teamleader is not null and A.su_branch='" + DDL_Branch.SelectedValue + "' ";
			ddl_team.Items.Add(new ListItem("-- PILIH --",""));
			if(DDL_Branch.SelectedValue != "")
			{
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					ddl_team.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
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


		private void Load_ReportViewer(string action,string Start_Date, string End_Date, string CBC, string Branch, string teamleader, string program, string product, string tanggal1_k, string tanggal2_k)
		{
			string kriterianya = "";
			/*
			string tanggal1	= Tool.ConvertDate(Start_Date);
			string tanggal2	= Tool.ConvertDate(End_Date);
			*/
			string tanggal1	= Start_Date;
			string tanggal2	= End_Date;
			tanggal1		= tanggal1.Replace("'","");
			tanggal2		= tanggal2.Replace("'","");

			kriterianya = " AND (convert(varchar, ap_signdate, 112) BETWEEN " + tanggal1_k + " AND " + tanggal2_k + ") ";
			if ((!program.Equals(""))&&(program.ToString()!="All"))
			{
				kriterianya += "AND (prog_code = '" + program + "') ";
			}

			if (!Session["bussunitid2"].Equals(""))    
			{
				kriterianya += "and (businessunit in (" + Session["bussunitid2"].ToString().Replace("''","'") + ")) ";
			}

			if (!Branch.Equals("")&&Branch.ToString()!="All") 
			{
				kriterianya += " AND (Branch_Code = '" + Branch + "')  ";
			}
			else
			{
				if(!CBC.Equals("")&&CBC.ToString()!="All")
				{
					kriterianya += " AND (CBC_CODE = '" + CBC + "') ";
				}

			}
			if ((!teamleader.Equals(""))&&(teamleader.ToString()!="All"))
			{
				kriterianya += " AND (AP_teamleader = '" + teamleader + "') ";
			}
			
			if ((!product.Equals(""))&&(product.ToString()!="All"))
			{
				kriterianya += "AND (productid = '" + product + "') ";
			}

            if (!action.Equals("PRINT"))
            {
                //ReportViewer1.ReportPath = "/SMEReports/RptRejectReason&sql_kondisi=" + kriterianya + "&Start_Date=" + tanggal1 + "&End_Date=" + tanggal2 + "&CBC=" + CBC + "&BRANCH=" + Branch + "&teamleader=" + teamleader + "&program=" + program + "&product=" + product + "&rs:Command=Render&rc:Toolbar=True";

                IReportServerCredentials irsc = new CustomReportCredentials(WebConfigurationManager.AppSettings["ReportUser"].ToString(), WebConfigurationManager.AppSettings["ReportPassword"].ToString(), WebConfigurationManager.AppSettings["DomainName"].ToString());

                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                ReportViewer1.ServerReport.ReportServerCredentials = irsc;
                ReportViewer1.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["ServerUrl"].ToString());
                ReportViewer1.ServerReport.ReportPath = "/SMEReports/RptRejectReason";

                List<ReportParameter> paramList = new List<ReportParameter>();

                paramList.Add(new ReportParameter("sql_kondisi", kriterianya, false));
                paramList.Add(new ReportParameter("CBC", CBC, false));
                paramList.Add(new ReportParameter("BRANCH", Branch, false));
                paramList.Add(new ReportParameter("Start_Date", tanggal1, false));
                paramList.Add(new ReportParameter("End_Date", tanggal2, false));
                paramList.Add(new ReportParameter("teamleader", teamleader, false));
                paramList.Add(new ReportParameter("program", program, false));
                paramList.Add(new ReportParameter("product", product, false));

                ReportViewer1.ServerReport.SetParameters(paramList);
                ReportViewer1.ServerReport.Refresh();
            }
            else
            {
                kriterianya = Server.HtmlEncode(kriterianya.Replace("'", "''"));
                Response.Redirect("RptPenolakanKreditPrint.aspx?sql_kondisi=" + kriterianya + "&tanggal1=" + tanggal1 + "&tanggal2=" + tanggal2 + "&CBC=" + CBC + "&Branch=" + Branch + "&teamleader=" + teamleader + "&program=" + program + "&product=" + product);
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

		protected void BTN_LIHAT_Click(object sender, System.EventArgs e)
		{
			LoadSql("");
		}

		private void LoadSql(string action)
		{
			string Branch = this.DDL_Branch.SelectedValue; 
			string product = DDL_Product.SelectedValue;
			string CBC = this.DDL_CBC.SelectedValue;
			string teamleader = ddl_team.SelectedValue;
			string program  = DDL_PROGRAM.SelectedValue;

			string Start_Date	= "";
			string End_Date		= "";
			
			string tanggal1_k = "";
			string tanggal2_k = "";

			if (Tools.isDateValid(this,TXT_Day1.Text,DDL_Month1.SelectedValue,TXT_Year1.Text)&&Tools.isDateValid(this, TXT_Day2.Text,DDL_Month2.SelectedValue,TXT_Year2.Text))
			{
				tanggal1_k = Tools.toISODate(TXT_Day1,DDL_Month1,TXT_Year1);
				tanggal2_k = Tools.toISODate(TXT_Day2,DDL_Month2,TXT_Year2);

				Start_Date = Tool.ConvertDate(TXT_Day1.Text,DDL_Month1.SelectedValue,TXT_Year1.Text);
				End_Date = Tool.ConvertDate(TXT_Day2.Text,DDL_Month2.SelectedValue,TXT_Year2.Text);
			
				Load_ReportViewer(action,Start_Date,End_Date,CBC,Branch, teamleader, program, product, tanggal1_k, tanggal2_k);		
			}
			else
			{
				Response.Write("<script language='javascript'>alert('Invalid date !')</script>");
			}
		}

		protected void Btn_Print_Click(object sender, System.EventArgs e)
		{
			LoadSql("PRINT");
		}


		protected void DDL_CBC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
				fillBranch();
		}

		protected void DDL_Branch_SelectedIndexChanged(object sender, System.EventArgs e)
		{
				fillTeamLeader();
		}

		protected void ddl_team_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportOR.aspx?mc=" + Request.QueryString["mc"] + "&BU=" + LBL_BU.Text);
		}

		protected void DDL_PROGRAM_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillProduct();
		}
	}
}
