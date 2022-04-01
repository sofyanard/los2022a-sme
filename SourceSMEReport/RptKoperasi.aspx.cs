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
	/// Summary description for RptKoperasi.
	/// </summary>
	public partial class RptKoperasi : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();
	
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

				Label1.Text = Posisi_User().ToString();
				fillRegion();
				fillbusinessunit();
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
			DDL_BRANCH.Items.Clear();
			switch(Label1.Text)
			{
				case "1": 
					Conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where areaid='" +
						DDL_AREA.SelectedValue + "' and Branch_Code='" + Session["BranchID"].ToString() + "' ";
					break;
				default:
					Conn.QueryString =  "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH where areaid='" + DDL_AREA.SelectedValue + "' ";
					DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));
					break;
			}
			if(DDL_AREA.SelectedValue != "")
			{
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					DDL_BRANCH.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
			}
		}

		public void fillbusinessunit()
		{
			DDL_BUSSGRP.Items.Clear();
			if(!Session["bussunitid2"].Equals(""))
			{
				Conn.QueryString = "select bussunitid, bussunitdesc from rfbusinessunit where active='1' and bussunitid in (" + Session["bussunitid2"].ToString().Replace("''","'") + ") ";
				DDL_BUSSGRP.Items.Add(new ListItem("-- PILIH --",""));
			}
			else
			{
				Conn.QueryString = "select bussunitid, bussunitdesc from rfbusinessunit where active='1' ";
				DDL_BUSSGRP.Items.Add(new ListItem("-- PILIH --",""));
			}
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_BUSSGRP.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
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

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			LoadSql("");
		}

		private void LoadSql(string action)
		{
			string branch	= DDL_BRANCH.SelectedValue;
			string area		= DDL_AREA.SelectedValue;
			string bussgrp  = DDL_BUSSGRP.SelectedValue;

			string tanggal1_k = "";
			string tanggal2_k = "";

			string tanggal1 = "";
			string tanggal2 = "";
			
			if (Tools.isDateValid(this,TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text)&&Tools.isDateValid(this, TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text))
			{
				tanggal1_k = Tools.toISODate(TXT_TGL1,DDL_BLN1,TXT_THN1);
				tanggal2_k = Tools.toISODate(TXT_TGL2,DDL_BLN2,TXT_THN2);
				tanggal1 = tools.ConvertDate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);
				tanggal2 = tools.ConvertDate(TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text);

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
					LoadReport(action, tanggal1,tanggal2,branch,area, bussgrp, tanggal1_k, tanggal2_k);
			}
			else
			{
				Response.Write("<script language='javascript'>alert('Invalid Date !')</script>");
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
	

		private void LoadReport(string action, string tgl1, string tgl2, string branch, string area, string bussgrp, string  tanggal1_k, string tanggal2_k)
		{	
			string kriterianya="";
			/*
			string tanggal1	= tools.ConvertDate(tgl1);
			string tanggal2	= tools.ConvertDate(tgl2);
			*/
			string tanggal1	= tgl1;
			string tanggal2	= tgl2;
			 
			tanggal1		= tanggal1.Replace("'","");
			tanggal2		= tanggal2.Replace("'","");

			if (!tanggal1_k.Equals("") && !tanggal2_k.Equals(""))
			{
				kriterianya += " and (convert(varchar, ap_recvdate, 112) between " + tanggal1_k + " and " + tanggal2_k + ") ";
			}

            IReportServerCredentials irsc = new CustomReportCredentials(WebConfigurationManager.AppSettings["ReportUser"].ToString(), WebConfigurationManager.AppSettings["ReportPassword"].ToString(), WebConfigurationManager.AppSettings["DomainName"].ToString());

            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerCredentials = irsc;
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["ServerUrl"].ToString());

			if (!branch.Equals(""))
			{
				kriterianya += " and (branch_code='" + branch + "') ";
			}
			if (!area.Equals(""))     
			{
				kriterianya += " AND (areaid='" + area + "') ";
			}
			if (!bussgrp.Equals(""))     
			{
				kriterianya += " AND (businessunit='" + bussgrp + "') ";
			}
			if (!Session["bussunitid2"].Equals(""))    
			{
				kriterianya += "and (businessunit in (" + Session["bussunitid2"].ToString().Replace("''","'") + ")) ";
			}

            if (!action.Equals("PRINT"))
            {
                //ReportViewer1.ReportPath = "/SMEReports/RptKoperasi&sql_kondisi=" + Server.HtmlEncode(kriterianya) + "&Start_Date=" + tanggal1 + "&End_Date=" + tanggal2 + "&BRANCH=" + branch + "&region=" + area + "&bussgrp=" + bussgrp + "&rs:Command=Render&rc:Toolbar=True";
                ReportViewer1.ServerReport.ReportPath = "/SMEReports/RptKoperasi";

                List<ReportParameter> paramList = new List<ReportParameter>();

                paramList.Add(new ReportParameter("sql_kondisi", Server.HtmlEncode(kriterianya), false));
                paramList.Add(new ReportParameter("region", area, false));
                paramList.Add(new ReportParameter("bussgrp", bussgrp, false));
                paramList.Add(new ReportParameter("Start_Date", tanggal1, false));
                paramList.Add(new ReportParameter("End_Date", tanggal2, false));

                ReportViewer1.ServerReport.SetParameters(paramList);
                ReportViewer1.ServerReport.Refresh();
            }
            else
                Response.Redirect("RptKoperasiPrint.aspx?sql_kondisi=" + Server.HtmlEncode(kriterianya.Replace("'", "''")) + "&Start_Date=" + tanggal1 + "&End_Date=" + tanggal2 + "&branch_code=" + branch + "&area=" + area + "&bussgrp=" + bussgrp);
			
		}

		protected void DDL_AREA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillBranch();
		}

		protected void Btn_Print_Click(object sender, System.EventArgs e)
		{
			LoadSql("PRINT");
		}

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportOR.aspx?mc=" + Request.QueryString["mc"] + "&BU=" + LBL_BU.Text);
		}
	}
}
