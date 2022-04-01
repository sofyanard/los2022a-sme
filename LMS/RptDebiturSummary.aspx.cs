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
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;
using System.Web.Configuration;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Net;
using SME.SourceSMEReport;

namespace SME.LMS
{
	/// <summary>
	/// Summary description for RptDebiturSummary.
	/// </summary>
	public partial class RptDebiturSummary : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				DDL_TGLFROM_MM.Items.Add(new ListItem("-- PILIH --",""));
				DDL_TGLTO_MM.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_TGLFROM_MM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_TGLTO_MM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
				TXT_TGLFROM_DD.Text=DateAndTime.Today.Day.ToString();
				DDL_TGLFROM_MM.SelectedValue=DateAndTime.Today.Month.ToString();
				TXT_TGLFROM_YY.Text=DateAndTime.Today.Year.ToString();
				TXT_TGLTO_DD.Text=DateAndTime.Today.Day.ToString();
				DDL_TGLTO_MM.SelectedValue=DateAndTime.Today.Month.ToString();
				TXT_TGLTO_YY.Text=DateAndTime.Today.Year.ToString();

				FillRegion();
				FillBusinessUnit();
			}
		}

		private void FillBusinessUnit()
		{
			GlobalTools.fillRefList(DDL_BUSINESSUNIT,"EXEC LMS_RPTDEBITURDETAIL_FILLDDLBUSINESSUNIT '" + Session["UserID"].ToString() + "'",false,conn);
		}

		private void FillRegion()
		{
			GlobalTools.fillRefList(DDL_REGION,"EXEC LMS_RPTDEBITURDETAIL_FILLDDLREGION '" + Session["UserID"].ToString() + "'",false,conn);
		}

		private void FillCBC()
		{
			GlobalTools.fillRefList(DDL_CBC,"EXEC LMS_RPTDEBITURDETAIL_FILLDDLCBC '" + Session["UserID"].ToString() + "', '" + DDL_REGION.SelectedValue + "'",false,conn);
		}

		private void FillBranch()
		{
			GlobalTools.fillRefList(DDL_BRANCH,"EXEC LMS_RPTDEBITURDETAIL_FILLDDLBRANCH '" + Session["UserID"].ToString() + "', '" + DDL_CBC.SelectedValue + "'",false,conn);
		}

		private void FillRM()
		{
			GlobalTools.fillRefList(DDL_RM,"EXEC LMS_RPTDEBITURDETAIL_FILLDDLRM '" + Session["UserID"].ToString() + "', '" + DDL_BRANCH.SelectedValue + "'",false,conn);
		}

		private void ClearEntry()
		{
			TXT_TGLFROM_DD.Text = "";
			try { DDL_TGLFROM_MM.SelectedValue = ""; }
			catch {}
			TXT_TGLFROM_YY.Text = "";
			TXT_TGLTO_DD.Text = "";
			try { DDL_TGLTO_MM.SelectedValue = ""; }
			catch {}
			TXT_TGLTO_YY.Text = "";
			try { DDL_BUSINESSUNIT.SelectedValue = ""; }
			catch {}
			try { DDL_REGION.SelectedValue = ""; }
			catch {}
			FillCBC();
		}

		private void LoadReportViewer()
		{
			string uid, tgl1, tgl2, bu, area, cbc, br, rm;
			uid = Session["UserID"].ToString();
			tgl1 = tools.ConvertDate(TXT_TGLFROM_DD.Text,DDL_TGLFROM_MM.SelectedValue,TXT_TGLFROM_YY.Text).Replace("'","");
			tgl2 = tools.ConvertDate(TXT_TGLTO_DD.Text,DDL_TGLTO_MM.SelectedValue,TXT_TGLTO_YY.Text).Replace("'","");
			bu = DDL_BUSINESSUNIT.SelectedValue;
			area = DDL_REGION.SelectedValue;
			cbc = DDL_CBC.SelectedValue;
			br = DDL_BRANCH.SelectedValue;
			rm = DDL_RM.SelectedValue;

			//ReportViewer1.ReportPath = "/SMEReports/LMSRptDebiturSummary&uid=" + uid + "&tgl1=" + tgl1 + "&tgl2=" + tgl2 + "&bu=" + bu + "&area=" + area + "&cbc=" + cbc + "&br=" + br + "&rm=" + rm + "&rs:Command=Render";

            IReportServerCredentials irsc = new CustomReportCredentials(WebConfigurationManager.AppSettings["ReportUser"].ToString(), WebConfigurationManager.AppSettings["ReportPassword"].ToString(), WebConfigurationManager.AppSettings["DomainName"].ToString());

            ReportViewer2.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer2.ServerReport.ReportServerCredentials = irsc;
            ReportViewer2.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["ServerUrl"].ToString());
            ReportViewer2.ServerReport.ReportPath = "/SMEReports/LMSRptDebiturSummary";

            List<ReportParameter> paramList = new List<ReportParameter>();

            paramList.Add(new ReportParameter("uid", uid, false));
            paramList.Add(new ReportParameter("bu", bu, false));
            paramList.Add(new ReportParameter("area", area, false));
            paramList.Add(new ReportParameter("cbc", cbc, false));
            paramList.Add(new ReportParameter("br", br, false));
            paramList.Add(new ReportParameter("rm", rm, false));
            paramList.Add(new ReportParameter("tgl1", tgl1, false));
            paramList.Add(new ReportParameter("tgl2", tgl2, false));

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

		protected void DDL_REGION_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillCBC();
		}

		protected void DDL_CBC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillBranch();
		}

		protected void DDL_BRANCH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillRM();
		}

		protected void btn_clear_Click(object sender, System.EventArgs e)
		{
			ClearEntry();
		}

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			if (TXT_TGLFROM_DD.Text == "" ||
				DDL_TGLFROM_MM.SelectedValue == "" ||
				TXT_TGLFROM_YY.Text == "" ||
				TXT_TGLTO_DD.Text == "" ||
				DDL_TGLTO_MM.SelectedValue == "" ||
				TXT_TGLTO_YY.Text == "")
			{
				GlobalTools.popMessage(this, "Periode harus diisi!");
				return;
			}

			LoadReportViewer();
		}
	}
}
