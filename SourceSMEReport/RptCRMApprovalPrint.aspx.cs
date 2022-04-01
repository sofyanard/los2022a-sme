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

namespace SME.SourceSMEReport
{
	/// <summary>
	/// Summary description for RptPenolakanKreditPrint.
	/// </summary>
	public partial class RptCRMApprovalPrint : System.Web.UI.Page
	{
		
		protected Connection conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"]; 
			string sql_kondisi = Request.QueryString["sql_kondisi"];
			string tanggal1 = Request.QueryString["Start_Date"];
			string tanggal2 = Request.QueryString["End_Date"];
			string CBC = Request.QueryString["CBC"];
			string BRANCH = Request.QueryString["BRANCH"];
			string teamleader = Request.QueryString["teamleader"];
			string program =" ";//   Request.QueryString["program"];
			Label8.Text=Request.QueryString["Accept"];
			Label9.Text=Request.QueryString["Reject"];
			Label10.Text=Request.QueryString["Completed"];
			Label11.Text=Request.QueryString["Pending"];
	       //&region=" + region + "&CBC=" + CBC + "&BRANCH=" + Branch + "&teamleader=" + teamleader + "&approval=" + approval + "&Accept=" + vAccept+ "&Reject=" + vReject + "&Completed=" + vCompleted + "&Pending=" + vPending + "&rs:Command=Render&rc:Toolbar=True";
			//string product = Request.QueryString["product"];
			//sql_kondisi=" + sql_kondisi + "&Start_Date=" + tanggal1 + "&End_Date=" + tanggal2 + "&region=" + region + "&CBC=" + CBC + "&BRANCH=" + Branch + "&teamleader=" + teamleader + "&approval=" + approval + "&program=" + program + "&ekonomi=" + ekonomi + "&Accept=" + vAccept+ "&Reject=" + vReject + "&Completed=" + vCompleted + "&Pending=" + vPending + " ");
			Load_Data(sql_kondisi, tanggal1, tanggal2, CBC, BRANCH, teamleader, program);
		}

		private void Load_Data(string sql_kondisi, string tanggal1, string tanggal2, string CBC, string BRANCH, string teamleader, string program)
		{
			string branchname="", teamleadername="", programname=""; 
			LBL_PERIODE.Text = tools.FormatDate(tanggal1, false) + " TO " + tools.FormatDate(tanggal2, false);

			if(!CBC.Equals(""))
			{
				conn.QueryString = "select distinct  branch_name  from rfbranch where branch_code ='" + CBC + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					branchname = conn.GetFieldValue(0,"branch_name");
					this.LBL_CBC.Text = branchname.ToUpper();
				}
			}
			else
			{
				branchname = "All Branch";
				this.LBL_CBC.Text = branchname.ToUpper();
			}

			if(!BRANCH.Equals(""))
			{
				conn.QueryString = "select distinct  branch_name  from rfbranch where branch_code ='" + BRANCH + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					branchname = conn.GetFieldValue(0,"branch_name");
					this.LBL_BRANCH.Text = branchname.ToUpper();
				}
			}
			else
			{
				branchname = "All Branch";
				this.LBL_BRANCH.Text = branchname.ToUpper();
			}

			if(!teamleader.Equals(""))
			{
				conn.QueryString = "select su_fullname from scuser where userid='" + teamleader + "' ";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					teamleadername = conn.GetFieldValue(0,"su_fullname");
					LBL_TEAM.Text = teamleadername.ToUpper();
				}
			}
			else
			{
				teamleadername = "ALL Team Leader";
				this.LBL_TEAM.Text = teamleadername.ToUpper();
			}            

			if(!program.Equals(""))
			{
				conn.QueryString = "select programdesc from rfprogram where programid='" + program + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					programname = conn.GetFieldValue(0,"programdesc");
					LBL_PROGRAM.Text = programname.ToUpper();
				}
			}
			else
			{
				programname = "All Program";
				LBL_PROGRAM.Text = programname.ToUpper();
			}       

		

			conn.QueryString = "exec Rpt_RMApproval  '" + sql_kondisi + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[0].Text = ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[0].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[1].Text = conn.GetFieldValue(i,"branch_name");
				TBL_CONTENT.Rows[i + 1].Cells[1].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 1].Cells[1].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[2].Text = conn.GetFieldValue(i,"ap_regno");
				TBL_CONTENT.Rows[i + 1].Cells[2].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 1].Cells[2].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[3].Text = conn.GetFieldValue(i,"CustomerName");
				TBL_CONTENT.Rows[i + 1].Cells[3].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 1].Cells[3].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				//TBL_CONTENT.Rows[i + 1].Cells[4].Text = conn.GetFieldValue(i,"");
				TBL_CONTENT.Rows[i + 1].Cells[4].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				//TBL_CONTENT.Rows[i + 1].Cells[5].Text = conn.GetFieldValue(i,"");
				TBL_CONTENT.Rows[i + 1].Cells[5].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 1].Cells[5].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[6].Text =tools.FormatDate(conn.GetFieldValue(i,"BUApprovedDate"), false);
				TBL_CONTENT.Rows[i + 1].Cells[6].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 1].Cells[6].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[7].Text =tools.FormatDate(conn.GetFieldValue(i,"RMApprovedDate"),false);
				TBL_CONTENT.Rows[i + 1].Cells[7].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 1].Cells[7].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[8].Text = conn.GetFieldValue(i,"SLA");
				TBL_CONTENT.Rows[i + 1].Cells[8].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 1].Cells[8].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[9].Text = conn.GetFieldValue(i,"AD_Status");
				TBL_CONTENT.Rows[i + 1].Cells[9].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 1].Cells[9].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[10].Text = conn.GetFieldValue(i,"RM_Name");
				TBL_CONTENT.Rows[i + 1].Cells[10].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 1].Cells[10].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[11].Text = conn.GetFieldValue(i,"BU_Name");
				TBL_CONTENT.Rows[i + 1].Cells[11].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 1].Cells[11].CssClass= "ItemPrint_d";

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
	}
}
