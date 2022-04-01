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
	/// Summary description for RptBusinessUnitPrint.
	/// </summary>
	public partial class RptBusinessUnitPrint : System.Web.UI.Page
	{
		protected Connection conn = new Connection();
		protected Tools tools = new Tools();
	    protected string querynya = ""; 
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
			string teamleader = Request.QueryString["teamleader"];
            string rm = Request.QueryString["rm"];

			if(!IsPostBack)
			{
				loadData(tanggal1, tanggal2,region, cbc, branch, teamleader, rm);
			}
		}

		private void loadData(string tanggal1, string tanggal2,string region, string cbc, string branch, string teamleader, string rm)
		{
			string regionname="", cbcname="", branchname="", rmname=""; 
			LBL_PERIODE.Text = tools.FormatDate(tanggal1,false).ToUpper() + " TO " + tools.FormatDate(tanggal2,false).ToUpper();
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
					cbcname = conn.GetFieldValue(0,"branch_name");
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

			if (!teamleader.Equals(""))
			{
				conn.QueryString = "select su_fullname from scuser where userid='" + teamleader + "' ";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					LBL_TEAM.Text = conn.GetFieldValue(0,0).ToUpper();
				}
				else
				{
					LBL_TEAM.Text = "ALL";
				}
			}
			else
			{
				LBL_TEAM.Text = "ALL";
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

			conn.QueryString = "SELECT AP_REGNO, BRANCH_NAME, CU_NAME, BS_REQDATE, BS_RECVDATE, SU_FULLNAME, JML_HARI FROM TMP_TBLBUSINESSUNIT WHERE userid = '" + Session["UserID"].ToString() + "' ORDER BY BRANCH_NAME, AP_REGNO";
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
				TBL_CONTENT.Rows[i + 1].Cells[3].Text = "&nbsp;" + conn.GetFieldValue(i, "CU_NAME");
				TBL_CONTENT.Rows[i + 1].Cells[3].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[4].Text = "&nbsp;" + conn.GetFieldValue(i, "BS_REQDATE");
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[5].Text = "&nbsp;" + conn.GetFieldValue(i, "BS_RECVDATE");
				TBL_CONTENT.Rows[i + 1].Cells[5].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[6].Text = "&nbsp;" + conn.GetFieldValue(i, "JML_HARI");
				TBL_CONTENT.Rows[i + 1].Cells[6].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[7].Text = "&nbsp;" + conn.GetFieldValue(i, "SU_FULLNAME");
				TBL_CONTENT.Rows[i + 1].Cells[7].CssClass= "ItemPrint";
			}

			conn.QueryString = "SELECT COUNT(AP_REGNO) AS jml FROM TMP_TBLBUSINESSUNIT WHERE (userid = '" + Session["UserID"].ToString() + "') AND (jml_hari IS NOT NULL) ";
			conn.ExecuteQuery();
			if(conn.GetRowCount()>0)
			{
				lbl_total_completed.Text = lbl_total_completed.Text + "  " + conn.GetFieldValue(0,"jml"); 
			}
			else
			{
				lbl_total_completed.Text = lbl_total_completed.Text + "  " + "0"; 
			}

			conn.QueryString = "SELECT COUNT(AP_REGNO) AS jml FROM TMP_TBLBUSINESSUNIT WHERE (userid='" + Session["UserID"].ToString() + "') AND (jml_hari IS NULL)";
			conn.ExecuteQuery();
			if(conn.GetRowCount()>0)
			{
				lbl_total_pending.Text = lbl_total_pending.Text + "  " + conn.GetFieldValue(0,"jml"); 
			}
			else
			{
				lbl_total_pending.Text = lbl_total_pending.Text + "  " + "0"; 
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
