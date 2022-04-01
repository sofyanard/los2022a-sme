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
	/// Summary description for RptPipelinePerProductStage.
	/// </summary>
	public partial class RptPipelinePerProductStage : System.Web.UI.Page
	{
		protected Connection conn = new Connection();
		protected Connection Conn = new Connection();	
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_BU.Text = Request.QueryString["BU"];
				Label1.Text = Posisi_User().ToString();
				fillDate();
				//fillJenisProduct();
				fillBusinessUnit();
				fillDropDowns();
			}
			
		}

		private void fillDropDowns() 
		{
			fillArea();
			fillCBC();
			fillBranch();
			fillStage();
		}

		private void fillArea () 
		{
			DDL_AREA.Items.Clear();
			DDL_AREA.Items.Add(new ListItem("-- PILIH --",""));
			Conn.QueryString = "select AREAID, AREANAME from rfarea where active ='1'";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_AREA.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}	
		}

		private void fillCBC () 
		{
			DDL_CBC.Items.Clear();
			DDL_CBC.Items.Add(new ListItem("-- PILIH --",""));

			if (DDL_AREA.SelectedValue=="")
			{
				Conn.QueryString = "select branch_code, branch_name from rfbranch where active ='1' and branch_type='3'";
			}
			else
			{
				Conn.QueryString = "select branch_code, branch_name from rfbranch where active ='1' and branch_type='3' and areaid = '"+DDL_AREA.SelectedValue+"'";
			}
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_CBC.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}	
		}

		private void fillBranch() 
		{
			DDL_BRANCH.Items.Clear();
			DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));

			if (DDL_CBC.SelectedValue=="")
			{
			Conn.QueryString = "select branch_code, branch_name from rfbranch where active ='1'";
			}
			else
			{
				Conn.QueryString = "select branch_code, branch_name from rfbranch where active ='1' and cbc_code = '"+DDL_CBC.SelectedValue+"'";
			}

			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_BRANCH.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}			
		}

		private void fillStage() 
		{
			DDL_STAGE.Items.Clear();
			DDL_STAGE.Items.Add(new ListItem("-- PILIH --",""));
			Conn.QueryString = "select stage_name from RPT_PIPELINE_STAGE";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_STAGE.Items.Add(new ListItem(Conn.GetFieldValue(i,0),Conn.GetFieldValue(i,0)));
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
/*
		private void ViewData()
		{
			string qry = "SELECT sum (case when apptype='01' then isnull(CP_LIMIT,0) else 0 end) BARU, sum(case when apptype = '03' then case when cp_limitchg ='+' then isnull(CP_LIMIT,0) else -1*isnull(CP_LIMIT,0) end else 0 end) TAMBAHAN FROM VW_PIPELINE_STAGE";

			qry = qry + " WHERE AP_RECVDATE BETWEEN '" + Tools.toSQLDate(TXT_TGL1, DDL_BLN1, TXT_THN1 ) + "' AND '" + Tools.toSQLDate(TXT_TGL2, DDL_BLN2, TXT_THN2 ) + "' ";

			if (DDL_BUSINESSUNIT.SelectedValue != "")
				qry = qry + " AND AP_BUSINESSUNIT = '" + DDL_BUSINESSUNIT.SelectedValue + "' ";

			if (DDL_AREA.SelectedValue!= "")
				qry = qry + " AND AREAID = '" + DDL_AREA.SelectedValue + "' ";

			if (DDL_BRANCH.SelectedValue != "")
				qry = qry + " AND branch_code = '" + DDL_BRANCH.SelectedValue + "' ";

			if (DDL_CBC.SelectedValue != "")
				qry = qry + " AND cbc_code = '" + DDL_CBC.SelectedValue + "' ";
			
			if (DDL_STAGE.SelectedValue != "")
				qry = qry + " AND stage = '" + DDL_STAGE.SelectedValue + "' ";

			//order

			qry = qry + "GROUP BY AP_BUSINESSUNIT";
//			if (DDL_BUSINESSUNIT.SelectedValue != "")
//				qry = qry + "AP_BUSINESSUNIT,";

			if (DDL_AREA.SelectedValue!= "")
				qry = qry + ",AREAID";

			if (DDL_BRANCH.SelectedValue != "")
				qry = qry + ",branch_code";

			if (DDL_CBC.SelectedValue != "")
				qry = qry + ",cbc_code";
			
			if (DDL_STAGE.SelectedValue != "")
				qry = qry + ",stage";


			conn.QueryString = qry;
			conn.ExecuteQuery();
			
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = 0;
				DatGrd.DataBind();
			}
		}

*/

		private void LoadSql(string action)
		{
			string businessunit		= DDL_BUSINESSUNIT.SelectedValue;
			string area				= DDL_AREA.SelectedValue;
			string cbc				= DDL_CBC.SelectedValue;
			string branch			= DDL_BRANCH.SelectedValue;
			string stage			= DDL_STAGE.SelectedValue;

			string tanggal1 = "";
			string tanggal2 = "";
			
			if (Tools.isDateValid(this,TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text)&&Tools.isDateValid(this, TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text))
			{
				tanggal1 = tools.ConvertDate(TXT_TGL1.Text, DDL_BLN1.SelectedValue, TXT_THN1.Text).Replace("'","");
                tanggal2 = tools.ConvertDate(TXT_TGL2.Text, DDL_BLN2.SelectedValue, TXT_THN2.Text).Replace("'", "");

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
					LoadReport_Load(tanggal1, tanggal2, businessunit, area, cbc, branch, stage);
			}
			else
			{
				Response.Write("<script language='javascript'>alert('Invalid Date !')</script>");
			}
			
		}

		private void LoadReport_Load(string tanggal1, string tanggal2, string businessunit, string area, string cbc, string branch, string stage)
		{
			//ReportViewer1.ReportPath = "/SMEReports/RptPipelineProductStage&date1="+ tanggal1 + "&date2=" + tanggal2 + "&businessunit=" + businessunit +  "&area=" + area + "&cbc=" + cbc + "&branch=" + branch + "&stage=" + stage + "&rs:Command=Render&rc:Toolbar=True";

            IReportServerCredentials irsc = new CustomReportCredentials(WebConfigurationManager.AppSettings["ReportUser"].ToString(), WebConfigurationManager.AppSettings["ReportPassword"].ToString(), WebConfigurationManager.AppSettings["DomainName"].ToString());

            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerCredentials = irsc;
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["ServerUrl"].ToString());
            ReportViewer1.ServerReport.ReportPath = "/SMEReports/RptPipelineProductStage";

            List<ReportParameter> paramList = new List<ReportParameter>();

            paramList.Add(new ReportParameter("businessunit", businessunit, false));
            paramList.Add(new ReportParameter("area", area, false));
            paramList.Add(new ReportParameter("cbc", cbc, false));
            paramList.Add(new ReportParameter("branch", branch, false));
            paramList.Add(new ReportParameter("stage", stage, false));
            paramList.Add(new ReportParameter("date1", tanggal1, false));
            paramList.Add(new ReportParameter("date2", tanggal2, false));

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
			DDL_BUSINESSUNIT.Items.Add(new ListItem("-- PILIH --",""));
			Conn.QueryString = "select bussunitid, bussunitdesc from rfbusinessunit order by bussunitid ";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_BUSINESSUNIT.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
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

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportOR.aspx?mc=" + Request.QueryString["mc"] + "&BU=" + LBL_BU.Text);
		}

		protected void BTN_LIHAT_Click(object sender, System.EventArgs e)
		{
			LoadSql("");
		}

		protected void DDL_AREA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillCBC();
			fillBranch();
		}

		protected void DDL_CBC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillBranch();
		}

	}
}
