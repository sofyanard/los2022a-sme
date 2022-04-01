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

namespace SME.SourceSMEReport
{
	/// <summary>
	/// Summary description for RptScorePerformancePrint.
	/// </summary>
	public partial class RptScorePerformancePrint : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Conn = (Connection) Session["Connection"];
            string sql_kondisi = Request.QueryString["sql_kondisi"];
			string Start_Date  = Request.QueryString["Start_Date"];
			string End_Date  = Request.QueryString["End_Date"];
			string region  = Request.QueryString["region"];
		    string CBC  = Request.QueryString["CBC"];
			string branch  = Request.QueryString["branch"];
			string teamleader  = Request.QueryString["teamleader"];
			Load_Data(sql_kondisi, Start_Date, End_Date, region, CBC, branch, teamleader);
		}

		private void Load_Data(string sql_kondisi, string Start_Date, string End_Date, string region, string CBC, string branch, string teamleader)
		{
			string regionname="", branchname=""; 
			LBL_PERIODE.Text = tools.FormatDate(Start_Date, false) + " TO " + tools.FormatDate(End_Date, false);
			if(!region.Equals(""))
			{
				Conn.QueryString = "select areaid, areaname  from rfarea where areaid='" + region + "'";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					regionname = Conn.GetFieldValue(0,"areaname");
				}
			}
			else
			{
				regionname = "All";
			}
			LBL_REGION.Text = regionname;    

			if(!CBC.Equals(""))
			{
				Conn.QueryString = "select distinct  branch_name  from rfbranch where branch_code ='" + branch + "'";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					branchname = Conn.GetFieldValue(0,"branch_name");
					LBL_CBC.Text = branchname.ToUpper();
				}
			}
			else
			{
				branchname = "All";
				LBL_CBC.Text = branchname.ToUpper();
			}

			if(!branch.Equals(""))
			{
				Conn.QueryString = "select distinct  branch_name  from rfbranch where branch_code ='" + branch + "'";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					branchname = Conn.GetFieldValue(0,"branch_name");
					LBL_BRANCH.Text = branchname.ToUpper();
				}
			}
			else
			{
				branchname = "All";
				LBL_BRANCH.Text = branchname.ToUpper();
			}

			if(!teamleader.Equals(""))
			{
				Conn.QueryString = "select su_fullname from scuser where userid='" + teamleader + "'";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					LBL_TEAM.Text = Conn.GetFieldValue(0,"su_fullname");
				}
			}
			else
			{
				LBL_TEAM.Text = "All";
			}

			Conn.QueryString = "exec Rpt_ScorePerformance '" + sql_kondisi +  "'";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 2].Cells[0].Text = "&nbsp;" + "&nbsp;" + ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + 2].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 2].Cells[0].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 2].Cells[1].Text = "&nbsp;" + Conn.GetFieldValue(i, "branch_name").ToString();
				TBL_CONTENT.Rows[i + 2].Cells[1].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 2].Cells[1].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 2].Cells[2].Text = "&nbsp;" + Conn.GetFieldValue(i, "ap_regno").ToString();
				TBL_CONTENT.Rows[i + 2].Cells[2].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 2].Cells[2].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 2].Cells[3].Text = "&nbsp;" + Conn.GetFieldValue(i, "Applicant").ToString();
				TBL_CONTENT.Rows[i + 2].Cells[3].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 2].Cells[3].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 2].Cells[4].Text = "&nbsp;" + tools.FormatDate(Conn.GetFieldValue(i, "InitialScoringDate").ToString(),false);
				TBL_CONTENT.Rows[i + 2].Cells[4].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 2].Cells[4].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 2].Cells[5].Text = "&nbsp;" + Conn.GetFieldValue(i, "fairisaacscoreinitial").ToString();
				TBL_CONTENT.Rows[i + 2].Cells[5].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 2].Cells[5].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 2].Cells[6].Text = "&nbsp;" + Conn.GetFieldValue(i, "colourinitial").ToString();
				TBL_CONTENT.Rows[i + 2].Cells[6].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 2].Cells[6].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 2].Cells[7].Text = "&nbsp;" + Conn.GetFieldValue(i, "finalScoringDate").ToString();
				TBL_CONTENT.Rows[i + 2].Cells[7].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 2].Cells[7].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 2].Cells[8].Text = "&nbsp;" + Conn.GetFieldValue(i, "fairisaacscorefinal").ToString();
				TBL_CONTENT.Rows[i + 2].Cells[8].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 2].Cells[8].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 2].Cells[9].Text = "&nbsp;" + Conn.GetFieldValue(i, "KU_score").ToString();
				TBL_CONTENT.Rows[i + 2].Cells[9].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 2].Cells[9].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 2].Cells[10].Text = "&nbsp;" + Conn.GetFieldValue(i, "bcg_score").ToString();
				TBL_CONTENT.Rows[i + 2].Cells[10].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 2].Cells[10].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 2].Cells[11].Text = "&nbsp;" + Conn.GetFieldValue(i, "bpr_score").ToString();
				TBL_CONTENT.Rows[i + 2].Cells[11].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 2].Cells[11].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 2].Cells[12].Text = "&nbsp;" + Conn.GetFieldValue(i, "Result").ToString();
				TBL_CONTENT.Rows[i + 2].Cells[12].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 2].Cells[12].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 2].Cells[13].Text = "&nbsp;" + tools.MoneyFormat(Conn.GetFieldValue(i, "LimitFinal").ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + 2].Cells[13].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 2].Cells[13].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 2].Cells[14].Text = "&nbsp;" + Conn.GetFieldValue(i, "PIC").ToString();
				TBL_CONTENT.Rows[i + 2].Cells[14].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 2].Cells[14].CssClass= "ItemPrint_d";
			}

			string vAcceptI="", vRejectI="", vAcceptF="", vGreyzoneF="", vRejectF="", vAmount="";
			//Conn.QueryString = "select count(*) jml from vw_report_scoreperformance where fairisaacscoreinitial='Accept' " + sql_kondisi;
			Conn.QueryString = "exec Rpt_ScorePerformanceFooter '" + "and fairisaacscoreinitial=''Accept'' " + sql_kondisi + "' ";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
			{vAcceptI=Conn.GetFieldValue(0,"jml");}
			else
			{vAcceptI="0";}
			LBL_AcceptedI.Text =  vAcceptI.ToString();

//			Conn.QueryString = "select count(*) jml from vw_report_scoreperformance where (fairisaacscoreinitial='Grey Zone' or fairisaacscoreinitial='Decline') " + sql_kondisi;
			Conn.QueryString = "exec Rpt_ScorePerformanceFooter '" + "and (fairisaacscoreinitial=''Grey Zone'' or fairisaacscoreinitial=''Decline'') " + sql_kondisi + "' ";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
			{vRejectI=Conn.GetFieldValue(0,"jml");}
			else
			{vRejectI="0";}
			LBL_RejectedI.Text = vRejectI.ToString();

//			Conn.QueryString = "select count(*) jml from vw_report_scoreperformance where fairisaacscorefinal='Accept' " + sql_kondisi;
			Conn.QueryString = "exec Rpt_ScorePerformanceFooter '" + "and fairisaacscorefinal=''Accept'' " + sql_kondisi + "' ";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
			{vAcceptF=Conn.GetFieldValue(0,"jml");}
			else
			{vAcceptF="0";}
			LBL_AcceptedF.Text = vAcceptF.ToString();

//			Conn.QueryString = "select count(*) jml from vw_report_scoreperformance where fairisaacscorefinal='Grey Zone' " + sql_kondisi;
			Conn.QueryString = "exec Rpt_ScorePerformanceFooter '" + "and fairisaacscorefinal=''Grey Zone'' " + sql_kondisi + "' ";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
			{vGreyzoneF=Conn.GetFieldValue(0,"jml");}
			else
			{vGreyzoneF="0";}
			LBL_GreyZoneF.Text = vGreyzoneF.ToString();

//			Conn.QueryString = "select count(*) jml from vw_report_scoreperformance where fairisaacscorefinal='Decline' " + sql_kondisi;
			Conn.QueryString = "exec Rpt_ScorePerformanceFooter '" + "and fairisaacscorefinal=''Decline'' " + sql_kondisi + "' ";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
			{vRejectF=Conn.GetFieldValue(0,"jml");}
			else
			{vRejectF="0";}
			LBL_RejectedF.Text = vRejectF.ToString();
			
			//Conn.QueryString = "select count(*) jml from vw_report_scoreperformance where fairisaacscorefinal='Decline' " + sql_kondisi;
			Conn.QueryString = "exec Rpt_ScorePerformanceFooter '" + sql_kondisi + "' ";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
			{vAmount=Conn.GetFieldValue(0,"limit");}
			else
			{vAmount="0";}
			LBL_Amount.Text = tools.MoneyFormat(vAmount.ToString());
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
	}
}
