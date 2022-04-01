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
	/// Summary description for RptRMApprovalAppealPrint.
	/// </summary>
	public partial class RptRMApprovalAppealPrint : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			string sql_kondisi = Request.QueryString["sql_kondisi"];
			string tanggal1 = Request.QueryString["tanggal1"];
			string tanggal2 = Request.QueryString["tanggal2"];
			string region = Request.QueryString["region"];
			string branch = Request.QueryString["branch"];
			string teamleader = Request.QueryString["teamleader"];
			string approval = Request.QueryString["approval"];
			Load_Data(sql_kondisi,tanggal1,tanggal2,region,branch,teamleader,approval);
		}

		private void Load_Data(string sql_kondisi, string tanggal1, string tanggal2, string region, string branch, string teamleader, string approval)
		{
			string regionname="", branchname="", teamleadername=""; 
			LBL_PERIODE.Text = tools.FormatDate(tanggal1, false) + " TO " + tools.FormatDate(tanggal2, false);

			if(!region.Equals(""))
			{
				conn.QueryString = "select areaid, areaname  from rfarea where areaid='" + region + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					regionname = conn.GetFieldValue(0,"areaname");
				}
			}
			else
			{
				regionname = "All Region";
			}
			LBL_REGION.Text = regionname;    

			if(!branch.Equals(""))
			{
				conn.QueryString = "select distinct  branch_name  from rfbranch where branch_code ='" + branch + "'";
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
				teamleadername = "ALL";
				this.LBL_TEAM.Text = teamleadername.ToUpper();
			}            

			if(!approval.Equals(""))
			{
				conn.QueryString = "select su_fullname from scuser where groupid like '01%' or groupid like '02%' and userid='" + approval + "' ";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					teamleadername = conn.GetFieldValue(0,"su_fullname");
					LBL_APPROVAL.Text = teamleadername.ToUpper();
				}
			}
			else
			{
				teamleadername = "All";
				this.LBL_APPROVAL.Text = teamleadername.ToUpper();
			}       

			conn.QueryString = "exec Rpt_RMApprovalApeal '" + sql_kondisi + "' ";
			conn.ExecuteQuery(1800);
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[0].Text = ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[0].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[1].Text = "&nbsp;" + conn.GetFieldValue(i, "branch_name").Trim();
				TBL_CONTENT.Rows[i + 1].Cells[1].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[2].Text = "&nbsp;" + conn.GetFieldValue(i, "ap_regno").Trim();
				TBL_CONTENT.Rows[i + 1].Cells[2].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[3].Text = "&nbsp;" + conn.GetFieldValue(i, "CustomerName").Trim();
				TBL_CONTENT.Rows[i + 1].Cells[3].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[4].Text = "&nbsp;" + tools.FormatDate(conn.GetFieldValue(i, "BUApprovedDate").Trim(),false);
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[5].Text = "&nbsp;" + tools.FormatDate(conn.GetFieldValue(i, "RMApprovedDate").Trim(),false);
				TBL_CONTENT.Rows[i + 1].Cells[5].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[6].Text = "&nbsp;" + conn.GetFieldValue(i, "SLA").Trim();
				TBL_CONTENT.Rows[i + 1].Cells[6].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[7].Text = "&nbsp;" + conn.GetFieldValue(i, "limit_req").Trim();
				TBL_CONTENT.Rows[i + 1].Cells[7].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[8].Text = "&nbsp;" + conn.GetFieldValue(i, "limit_apprv").Trim();
				TBL_CONTENT.Rows[i + 1].Cells[8].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[9].Text = "&nbsp;" + conn.GetFieldValue(i, "su_fullname").Trim();
				TBL_CONTENT.Rows[i + 1].Cells[9].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[10].Text = "&nbsp;" + conn.GetFieldValue(i, "AD_Status").Trim();
				TBL_CONTENT.Rows[i + 1].Cells[10].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[11].Text = "&nbsp;" + conn.GetFieldValue(i, "RM_Name1").Trim();
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
