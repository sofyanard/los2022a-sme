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
	/// Summary description for RptAccPerformancePrint.
	/// </summary>
	public partial class RptAccPerformancePrint : System.Web.UI.Page
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

			if(!IsPostBack)
			{
				loadData(tanggal1, tanggal2,region, branch );
			}
		}

		private void loadData(string tanggal1, string tanggal2,string region, string branch)
		{
			string regionname="", branchname=""; 
			
			LBL_PERIODE.Text = tools.FormatDate(tanggal1, false) + " TO " +  tools.FormatDate(tanggal2, false);
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
/*
			TBL_CONTENT.Rows.Add(new TableRow());
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[0].Text = "No.";
			TBL_CONTENT.Rows[0].Cells[0].Width = 30;
			TBL_CONTENT.Rows[0].Cells[0].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[1].Text = "BRANCH";
			TBL_CONTENT.Rows[0].Cells[1].Width = 120;
			TBL_CONTENT.Rows[0].Cells[1].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[2].Text = "APPL#";
			TBL_CONTENT.Rows[0].Cells[2].Width = 80;
			TBL_CONTENT.Rows[0].Cells[2].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[3].Text = "APPLICANTS";
			TBL_CONTENT.Rows[0].Cells[3].Width = 80;
			TBL_CONTENT.Rows[0].Cells[3].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[4].Text = "REQUEST";
			TBL_CONTENT.Rows[0].Cells[4].Width = 100;
			TBL_CONTENT.Rows[0].Cells[4].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[5].Text = "RECEIVE";
			TBL_CONTENT.Rows[0].Cells[5].Width = 100;
			TBL_CONTENT.Rows[0].Cells[5].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[6].Text = "#OF DAYS";
			TBL_CONTENT.Rows[0].Cells[6].Width = 80;
			TBL_CONTENT.Rows[0].Cells[6].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[7].Text = "RM";
			TBL_CONTENT.Rows[0].Cells[7].Width = 80;
			TBL_CONTENT.Rows[0].Cells[7].CssClass= "HeaderPrint";
*/
			conn.QueryString = "SELECT BRANCH_NAME, AP_REGNO, NAMA, CA_STARTDATE, CA_ENDDATE, JML_HARI, ANALIS, COMMENTS, ACCOUNTANT, OPINI, RM "+
				                "FROM TMP_REPORT_ACCPERFORMANCE WHERE UserID='" + Session["UserID"].ToString() + "'";
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
				TBL_CONTENT.Rows[i + 1].Cells[4].Text = "&nbsp;" + conn.GetFieldValue(i, "CA_STARTDATE");
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[5].Text = "&nbsp;" + conn.GetFieldValue(i, "CA_ENDDATE");
				TBL_CONTENT.Rows[i + 1].Cells[5].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[6].Text = "&nbsp;" + conn.GetFieldValue(i, "JML_HARI");
				TBL_CONTENT.Rows[i + 1].Cells[6].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[7].Text = "&nbsp;" + conn.GetFieldValue(i, "ANALIS");
				TBL_CONTENT.Rows[i + 1].Cells[7].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[8].Text = "&nbsp;" + conn.GetFieldValue(i, "COMMENTS");
				TBL_CONTENT.Rows[i + 1].Cells[8].CssClass= "ItemPrint";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[8].Text = "&nbsp;" + conn.GetFieldValue(i, "ACCOUNTANT");
				TBL_CONTENT.Rows[i + 1].Cells[8].CssClass= "ItemPrint";

			    TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[8].Text = "&nbsp;" + conn.GetFieldValue(i, "OPINI");
				TBL_CONTENT.Rows[i + 1].Cells[8].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[8].Text = "&nbsp;" + conn.GetFieldValue(i, "RM");
				TBL_CONTENT.Rows[i + 1].Cells[8].CssClass= "ItemPrint";
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
