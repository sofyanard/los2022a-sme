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
	/// Summary description for RptAccPerformance1Print.
	/// </summary>
	public partial class RptAccPerformance1Print : System.Web.UI.Page
	{
		protected Connection conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
		//		Response.Redirect("/SME/Restricted.aspx");

			string tanggal1 = Request.QueryString["tanggal1"];
			string tanggal2 = Request.QueryString["tanggal2"];
			string region = Request.QueryString["region"];
			string branch = Request.QueryString["branch"];
			string teamleader = Request.QueryString["teamleader"];

			if(!IsPostBack)
			{
				loadData(tanggal1, tanggal2,region, branch, teamleader );
			}
		}
		private void loadData(string tanggal1, string tanggal2,string region, string branch, string teamleader)
		{
			string regionname="", branchname=""; 
			
			LBL_PERIODE.Text = tools.FormatDate(tanggal1, false).ToUpper() + " TO " +  tools.FormatDate(tanggal2, false).ToUpper();
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

			if(!branch.Equals(""))
			{
				conn.QueryString = "select distinct  branch_name  from rfbranch where branch_code ='" + branch + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					branchname = conn.GetFieldValue(0,"branch_name");
				}
			}
			else
			{
				branchname = "ALL";
			}
			this.LBL_BRANCH.Text = branchname.ToUpper();


			if(!teamleader.Equals(""))
			{
				conn.QueryString="select su_fullname from scuser where userid='" + teamleader + "'";
				conn.ExecuteQuery();
				if(conn.GetRowCount()>0)
				{
					lbl_team.Text = conn.GetFieldValue(0,0).ToUpper();
				}
				else
				{
				    lbl_team.Text = "ALL";
				}
			}
			else
			{
				lbl_team.Text = "ALL";
			}
		
			conn.QueryString = "select Branch_name, ap_regno, nama, pk_receivedate, pk_completedate, jml_hari, analis, rm, auditorid, kondisidesc from TMP_REPORT_ACCPERFORM1 where userid='" + Session["UserID"].ToString() + "' order by branch_name, ap_regno ";
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
				TBL_CONTENT.Rows[i + 1].Cells[3].Text = "&nbsp;" + conn.GetFieldValue(i, "NAMA");
				TBL_CONTENT.Rows[i + 1].Cells[3].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[4].Text = "&nbsp;" + conn.GetFieldValue(i, "pk_receivedate");
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[5].Text = "&nbsp;" + conn.GetFieldValue(i, "pk_completedate");
				TBL_CONTENT.Rows[i + 1].Cells[5].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[6].Text = "&nbsp;" + conn.GetFieldValue(i, "jml_hari");
				TBL_CONTENT.Rows[i + 1].Cells[6].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[7].Text = "&nbsp;" + conn.GetFieldValue(i, "ANALIS");
				TBL_CONTENT.Rows[i + 1].Cells[7].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[8].Text = "&nbsp;" + conn.GetFieldValue(i, 8);
				TBL_CONTENT.Rows[i + 1].Cells[8].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[9].Text = "&nbsp;" + conn.GetFieldValue(i, "kondisidesc");
				TBL_CONTENT.Rows[i + 1].Cells[9].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[10].Text = "&nbsp;" + conn.GetFieldValue(i, "rm");
				TBL_CONTENT.Rows[i + 1].Cells[10].CssClass= "ItemPrint";
			}
			conn.QueryString="SELECT COUNT(*) AS jml FROM TMP_REPORT_ACCPERFORM1 "+
                             "WHERE (NOT (jml_hari IS NULL)) AND (userid='" + Session["UserID"].ToString() + "') ";
			conn.ExecuteQuery();
		    if(conn.GetRowCount()>0)
		    {
			   lbl_complete.Text =lbl_complete.Text + "  " + conn.GetFieldValue(0,0);
		    }
			else
			{
				lbl_complete.Text = lbl_complete.Text + " :   0";
			}
			
			conn.QueryString = "SELECT COUNT(AP_REGNO) AS jml FROM TMP_REPORT_ACCPERFORM1 "+
                               "WHERE (jml_hari IS NULL) AND (userid='" + Session["UserID"].ToString() + "') ";
			conn.ExecuteQuery();
			if(conn.GetRowCount()>0)
			{			
				lbl_pending.Text  = lbl_pending.Text  + "  " + conn.GetFieldValue(0,0);
			}
			else
			{
				lbl_pending.Text  = lbl_pending.Text  + " :  0";
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
