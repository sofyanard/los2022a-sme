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
	/// Summary description for RptCOBIRequest.
	/// </summary>
	public partial class RptAuditTrial : System.Web.UI.Page
	{
		protected Connection Conn;
		protected Tools tool = new Tools();
		protected string vRMCODE;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            Conn = (Connection) Session["Connection"];
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
				fillBranch();
			}
		}

		
		private void fillBranch()
		{
			//if(!Session["BranchID"].ToString().Equals(""))
			//Conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where  Branch_Code='" + Session["BranchID"].ToString() + "' ";
			//else
			Conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where  1=1 order by BRANCH_NAME ";
			Conn.ExecuteQuery();
			DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_BRANCH.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}

			////////////////////////////////////////
			/// set default value to the user's
			/// branch
			/// 
			try { DDL_BRANCH.SelectedValue = (string) Session["BranchID"]; } 
			catch {}
			fillRM();
		}

		/// <summary>
		/// Mengisi user person-in-charge dari application
		/// </summary>
		private void fillRM()
		{
			Conn.QueryString = "exec RPT_AUDIT_GETPIC '" + (string) Session["UserID"] + "', '" + (string) Session["BranchID"] + "'";
			Conn.ExecuteQuery();
			
			DDL_RM.Items.Clear();
			DDL_RM.Items.Add(new ListItem("-- PILIH --",""));
			for(int i=0; i < Conn.GetRowCount(); i++) 
			{
				DDL_RM.Items.Add(new ListItem(Conn.GetFieldValue(i, 1), Conn.GetFieldValue(i, 0)));
			}
			
			/*
			Conn.QueryString = "select userid, su_fullname from scuser "+
				"left join rfbranch on scuser.su_branch=rfbranch.branch_code "+
				"where scuser.su_branch='" + DDL_BRANCH.SelectedValue + "' order by su_fullname ";			
			DDL_RM.Items.Add(new ListItem("-- PILIH --",""));
			if(DDL_BRANCH.SelectedValue != "")
			{
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					DDL_RM.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
			}
			*/
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
            this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
		

		

		private void Load_ReportViewer(string kriteria, string ap_regno,string tanggal1,string tanggal2,string branch,string rm)
		{
			/*
            ReportViewer1.ReportPath = "/SMEReports/RptAuditTrial&sql_kondisi=" + kriteria +
				"&ap_regno=" + ap_regno + "&tanggal1=" + tanggal1 + "&tanggal2=" + tanggal2 + 
				"&branch=" + branch + "&rm=" + rm +"&rs:Command=Render&rc:Toolbar=True";
            */

            IReportServerCredentials irsc = new CustomReportCredentials(WebConfigurationManager.AppSettings["ReportUser"].ToString(), WebConfigurationManager.AppSettings["ReportPassword"].ToString(), WebConfigurationManager.AppSettings["DomainName"].ToString());

            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerCredentials = irsc;
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["ServerUrl"].ToString());
            ReportViewer1.ServerReport.ReportPath = "/SMEReports/RptAuditTrial";

            List<ReportParameter> paramList = new List<ReportParameter>();

            paramList.Add(new ReportParameter("sql_kondisi", kriteria, false));
            paramList.Add(new ReportParameter("ap_regno", ap_regno, false));
            paramList.Add(new ReportParameter("tanggal1", tanggal1, false));
            paramList.Add(new ReportParameter("tanggal2", tanggal2, false));

            ReportViewer1.ServerReport.SetParameters(paramList);
            ReportViewer1.ServerReport.Refresh();
		}

	
		private void LOADREPORT(string kond)
		{
			string kriterianya = "";
			string branch	= DDL_BRANCH.SelectedValue;
			string rm		= DDL_RM.SelectedValue;
			string ap_regno = TXT_APREGNO.Text;
			string tanggal1_k = "";
			string tanggal2_k = "";
			string tanggal1 = "";
			string tanggal2 = "";

			////////////////////////////////////////////
			/// Check booking date validity
			/// 
			if (Tools.isDateValid(this,TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text)&&Tools.isDateValid(this, TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text))
			{
				tanggal1_k = Tools.toISODate(TXT_TGL1,DDL_BLN1,TXT_THN1);
				tanggal2_k = Tools.toISODate(TXT_TGL2,DDL_BLN2,TXT_THN2);
				tanggal1 = tool.ConvertDate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);
				tanggal2 = tool.ConvertDate(TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text);
				
				/*
				if (!Information.IsDate(tanggal1) || !Information.IsDate(tanggal2))
				{
					GlobalTools.popMessage(this, "Date is not valid !");
					Response.Write("<Script language='javascript'>history.back();</Script>");

					if (!Information.IsDate(tanggal1))
						GlobalTools.SetFocus(this,TXT_TGL1);
					else
						GlobalTools.SetFocus(this,TXT_TGL2);
				}
				*/
							
				//////////////////////////////////
				/// set track date criteria
				/// 
				tanggal2 = tanggal2.Replace("'","");
				kriterianya = "and a.au_trackdate between " + tanggal1 + " and '" + tanggal2 + " 23:59:59'";
				//////////// end /////////////////

				/// write sp to check this application no (if choose apRegno) is valid
				/// if valid then execute
				/// else sql_kondisi = "1=2"
				///
				Conn.QueryString = "exec RPT_AUDITTRIAL_VALIDATE '" + 
					Session["UserID"] + "', '" + 
					DDL_RM.SelectedValue + "', '" + 
					TXT_APREGNO.Text.Trim() + "'";
				Conn.ExecuteQuery();
				bool appIsValid = false;
				if (Conn.GetFieldValue("RET") == "1") appIsValid = true;


				//////////////////////////////////
				/// set P.I.C criteria
				/// 				
				if (!rm.Equals("")) 
				{ 
					if (appIsValid) kriterianya += " and a.au_trackby = '" + rm + "' ";
					else kriterianya += " and 1=1";

					rm = DDL_RM.SelectedItem.ToString();
				}
				else
					rm = "ALL";
				//////////// end /////////////////

				////////////////////////////////////
				/// set branch criteria
				/// 
				/** // it doesn't straight forward ... there are conditions to fulfill
					* 
				if (!branch.Equals("")) 
				{ 
					kriterianya += " and ap.branch_code = '" + branch + "' ";
					branch = DDL_BRANCH.SelectedItem.ToString();
				}
				else
					branch="ALL";
				**/
				//////////// end /////////////////

				/////////////////////////////////////
				/// set app number criteria
				/// 
				if (!ap_regno.Equals("")) 
				{ 
					if (appIsValid) kriterianya +=" and a.ap_regno = '" + ap_regno + "' ";
					else kriterianya += " and 1=1";

					ap_regno = TXT_APREGNO.Text;
				}
				else
					ap_regno="ALL";
				//////////// end /////////////////
				///

				
				if (kond.Equals("PRINT"))
				{
					kriterianya = kriterianya.Replace("'","''");
					tanggal1 = TXT_TGL1.Text+" "+ DDL_BLN1.SelectedItem +" "+TXT_THN1.Text;
					tanggal2 = TXT_TGL2.Text+" "+ DDL_BLN2.SelectedItem +" "+TXT_THN2.Text;
					Response.Redirect("RptAuditTrialPrint.aspx?sql_kondisi=" + kriterianya + "&regno=" + ap_regno + "&tanggal1=" + tanggal1 + "&tanggal2=" + tanggal2 + "&branch=" + branch + "&rm=" + rm);
				}
				else
					tanggal1 = TXT_TGL1.Text+" "+ DDL_BLN1.SelectedItem +" "+TXT_THN1.Text;
					tanggal2 = TXT_TGL2.Text+" "+ DDL_BLN2.SelectedItem +" "+TXT_THN2.Text;

					Load_ReportViewer(kriterianya, ap_regno, tanggal1, tanggal2, branch, rm); 
			}
			else
			{
				//Response.Write("<script language='javascript'>alert('Invalid Date !')</script>");
				GlobalTools.popMessage(this, "Date is not valid !");
			}
		}

		
		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			LOADREPORT("REPORT");
		}

		
		

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportOR.aspx?mc=" + Request.QueryString["mc"] + "&BU=" + "");
		}

		protected void Btn_Print_Click(object sender, System.EventArgs e)
		{
			LOADREPORT("PRINT");
		}

		protected void DDL_BRANCH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		fillRM();
		}

	}		
}

