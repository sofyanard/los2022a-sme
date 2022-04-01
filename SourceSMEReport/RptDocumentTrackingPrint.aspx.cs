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

namespace SME.SourceSMEReport
{
	/// <summary>
	/// Summary description for RptDocumentTrackingPrint.
	/// </summary>
	public partial class RptDocumentTrackingPrint : System.Web.UI.Page
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
			string cbc  = Request.QueryString["cbc"];
			string branch  = Request.QueryString["branch"];
			string teamleader  = Request.QueryString["teamleader"];

			Load_Data(sql_kondisi, Start_Date, End_Date, cbc, branch, teamleader);
		}

		private void Load_Data(string sql_kondisi, string Start_Date, string End_Date, string cbc, string branch, string teamleader)
		{
			string branchname="", teamleadername=""; 
			LBL_PERIODE.Text = tools.FormatDate(Start_Date, false) + " TO " + tools.FormatDate(End_Date, false);
		
			if(!branch.Equals(""))
			{
				Conn.QueryString = "select distinct  branch_name  from rfbranch where branch_code ='" + branch + "'";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					branchname = Conn.GetFieldValue(0,"branch_name");
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
				Conn.QueryString = "select su_fullname from scuser where userid='" + teamleader + "' ";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					teamleadername = Conn.GetFieldValue(0,"su_fullname");
					this.LBL_TEAM.Text = teamleadername.ToUpper();
				}
			}
			else
			{
				teamleadername = "ALL";
				this.LBL_TEAM.Text = teamleadername.ToUpper();
			}            

			Conn.QueryString = "exec Rpt_DocumentTracking '" + sql_kondisi + "'";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[0].Text = ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[0].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[1].Text = "&nbsp;" +  Conn.GetFieldValue(i, "branch_name");
				TBL_CONTENT.Rows[i + 1].Cells[1].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[1].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[2].Text = "&nbsp;" + Conn.GetFieldValue(i, "ap_Regno");
				TBL_CONTENT.Rows[i + 1].Cells[2].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[2].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[3].Text = "&nbsp;" + Conn.GetFieldValue(i, "Applicant");
				TBL_CONTENT.Rows[i + 1].Cells[3].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[4].Text = "&nbsp;" + Conn.GetFieldValue(i, "senddate");
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[5].Text = "&nbsp;" + Conn.GetFieldValue(i, "recdate");
				TBL_CONTENT.Rows[i + 1].Cells[5].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[6].Text = "&nbsp;" ;//+ Conn.GetFieldValue(i, "stagefrom");
				TBL_CONTENT.Rows[i + 1].Cells[6].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[7].Text = "&nbsp;" ;//+ Conn.GetFieldValue(i, "stageto");
				TBL_CONTENT.Rows[i + 1].Cells[7].CssClass= "ItemPrint_d";
			}
			Conn.QueryString = "exec Rpt_DocumentTrackingFooter '" + sql_kondisi + "' ";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
			{
				LBL_APPL.Text = Conn.GetFieldValue(0,0);
			}
			else
			{
				LBL_APPL.Text = "0";
			}

            string sent="0", recv="0";
			Conn.QueryString = "exec Rpt_DocumentTrackingFooter ' and recdate is not null " + sql_kondisi + "' ";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
			{
				sent = Conn.GetFieldValue(0,0);
			}
			else
			{
				sent  = "0";
			}
			LBL_SENT.Text = sent.ToString();
			
			Conn.QueryString = "exec Rpt_DocumentTrackingFooter ' and recdate is null " + sql_kondisi + "' ";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
			{
				recv = Conn.GetFieldValue(0,0);
			}
			else
			{
				recv  = "0";
			}
			LBL_SENT.Text = recv.ToString();
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
