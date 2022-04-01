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

namespace SME.SourceSMEReport
{
	/// <summary>
	/// Summary description for RptCustRepornsePrint.
	/// </summary>
	public partial class RptCustRepornsePrint : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
	    protected Connection conn = new Connection();
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			
			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				//Response.Redirect("/SME/Restricted.aspx");

			string tanggal1 = Request.QueryString["tanggal1"];
			string tanggal2 = Request.QueryString["tanggal2"];
			string region = Request.QueryString["region"];
			string cbc = Request.QueryString["cbc"];
			string branch = Request.QueryString["branch"];
			string rm = Request.QueryString["rm"];
            string teamleader = Request.QueryString["teamleader"];
			
			if(!IsPostBack)
			{
				loadData(tanggal1, tanggal2,region, cbc, branch, teamleader, rm);
			}
		}
		private void loadData(string tanggal1, string tanggal2,string region, string cbc, string branch, string teamleader, string rm)
		{
			string regionname="", cbcname="", branchname="", rmname=""; 
			string vttl_accepted="", var_rejected="", var_completed="", var_pending="";

			LBL_PERIODE.Text = tools.FormatDate(tanggal1, false) + " TO " + tools.FormatDate(tanggal2, false);
			if(!region.Equals(""))
			{
				conn.QueryString = "select areaid, areaname  from rfarea where areaid='" + region + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					regionname = conn.GetFieldValue(0,"areaname").ToUpper();;
				}
			}
			else
			{
				regionname = "ALL";
			}
            
			if (!regionname.Equals(""))
			{
				this.LBL_REGION.Text = regionname.ToUpper();;
			}
			else
			{
				this.LBL_REGION.Text = "ALL";
			}


			if(!cbc.Equals(""))
			{
				conn.QueryString = "select distinct  branch_name  from rfbranch where branch_code ='" + cbc + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					cbcname = conn.GetFieldValue(0,"branch_name").ToUpper();
				}
			}
			else
			{
				cbcname = "ALL";
			}
			if(!cbc.Equals(""))
			{
				this.LBL_CBC.Text = cbcname;
			}
			else
			{
				this.LBL_CBC.Text = "ALL";
			}
			
			
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
				branchname = "ALL";
				this.LBL_BRANCH.Text = branchname.ToUpper();
			}

			if(!teamleader.Equals(""))
			{
				conn.QueryString="select su_fullanme from scuser where userid='" + teamleader + "' ";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0) 
				{
				    lbl_team.Text = conn.GetFieldValue(0,0).ToUpper();
				}
				else
				{
				  lbl_team.Text ="ALL";
				}
			}
			else
			{
				lbl_team.Text ="ALL";
			}

			if(!rm.Equals(""))
			{
				conn.QueryString = "select userid, su_fullname from scuser where userid = '" + rm + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					rmname = conn.GetFieldValue(0,"su_fullname");
					this.LBL_RM.Text = rmname.ToUpper();
				}
			}
			else
			{
				rmname  = "ALL";
				this.LBL_RM.Text = rmname.ToUpper();
			}
			conn.QueryString = "SELECT * FROM TMP_REPORT_CUSTRESPONSE WHERE userid = '" + Session["UserID"].ToString() + "' ORDER BY AREAID, CBC_CODE, branch_Code, AP_REGNO";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[0].Text = ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[0].CssClass= "ItemPrint";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[1].Text = "&nbsp;" + conn.GetFieldValue(i, "BRANCH_NAME").Trim();
				TBL_CONTENT.Rows[i + 1].Cells[1].CssClass= "ItemPrint";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[2].Text = "&nbsp;" + conn.GetFieldValue(i, "AP_REGNO");
				TBL_CONTENT.Rows[i + 1].Cells[2].CssClass= "ItemPrint";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[3].Text = "&nbsp;" + conn.GetFieldValue(i, "APPLICANT");
				TBL_CONTENT.Rows[i + 1].Cells[3].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[4].Text = "&nbsp;" + tools.FormatDate(conn.GetFieldValue(i, "TS_SPPKDATE"),false);
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[5].Text = "&nbsp;" + tools.FormatDate(conn.GetFieldValue(i, "TS_SPPKRETURNDATE"),false);
				TBL_CONTENT.Rows[i + 1].Cells[5].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[6].Text = "&nbsp;" + conn.GetFieldValue(i, "#DAYS");
				TBL_CONTENT.Rows[i + 1].Cells[6].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[7].Text = "&nbsp;" + conn.GetFieldValue(i, "RESULT");
				TBL_CONTENT.Rows[i + 1].Cells[7].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[8].Text = "&nbsp;" + conn.GetFieldValue(i, "SU_FULLNAME");
				TBL_CONTENT.Rows[i + 1].Cells[8].CssClass= "ItemPrint";
			}
            conn.QueryString = "SELECT COUNT(*) AS Accepted FROM  TMP_REPORT_CUSTRESPONSE WHERE (userid = '" + Session["UserID"].ToString() + "') AND (ap_reject <> 1) AND (TS_SPPKRETURNDATE IS NOT NULL)";
			conn.ExecuteQuery();
			if(conn.GetRowCount()>0)
			{
                vttl_accepted =  conn.GetFieldValue(0,0).ToString();
				lbl_accepted.Text = lbl_accepted.Text + "  " + conn.GetFieldValue(0,0).ToString();
				
			}
			else
			{
				vttl_accepted = "0";
				lbl_accepted.Text = lbl_accepted.Text + "   0";
			}
            
			
			conn.QueryString = "SELECT COUNT(*) AS Reject FROM TMP_REPORT_CUSTRESPONSE WHERE (ap_reject = 1) AND (userid = '" + Session["UserID"].ToString() + "') AND (TS_SPPKRETURNDATE IS NOT NULL)";
            conn.ExecuteQuery();  
			if(conn.GetRowCount()>0)
			{
				var_rejected =  conn.GetFieldValue(0,0);
			}
			else
			{
				var_rejected = "0";
			}
            lbl_rejected.Text = lbl_rejected.Text + "  " + var_rejected;

			conn.QueryString = "SELECT COUNT(*) AS Completed FROM TMP_REPORT_CUSTRESPONSE WHERE (userid = '" + Session["UserID"].ToString() + "') AND (TS_SPPKRETURNDATE IS NOT NULL)";
            conn.ExecuteQuery(); 
			if(conn.GetRowCount()>0)
			{
				var_completed =  conn.GetFieldValue(0,0);
			}
			else
			{
				var_completed = "0";
			}
            LBL_completed.Text = LBL_completed.Text + "  " + var_completed;

			conn.QueryString = "SELECT COUNT(*) AS Pending FROM TMP_REPORT_CUSTRESPONSE WHERE (userid = '" + Session["UserID"].ToString() + "') AND (TS_SPPKRETURNDATE IS NULL)";
			conn.ExecuteQuery();
			if(conn.GetRowCount()>0)
			{
				var_pending =  conn.GetFieldValue(0,0);
			}
			else
			{
				var_pending = "0";
			}
            lbl_pending.Text = lbl_pending.Text + "  " + var_pending;
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
