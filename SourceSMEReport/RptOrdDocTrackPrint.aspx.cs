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
	/// Summary description for RptOrdDocTrackPrint.
	/// </summary>
	public partial class RptOrdDocTrackPrint : System.Web.UI.Page
	{
		protected Connection conn = new Connection();
		protected Tools tools =  new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			string tanggal1 = Request.QueryString["tgl1"];
			string tanggal2 = Request.QueryString["tgl2"];
			string branch = Request.QueryString["branch"];
			string gfrom  = Request.QueryString["GFrom"];
			string gto = Request.QueryString["GTo"];
			if(!IsPostBack)
			{
				loadData(tanggal1, tanggal2, branch, gfrom, gto);
			}
		}

		private void loadData(string tanggal1, string tanggal2, string branch, string gfrom, string gto)
		{
			string branchname="", gfromname="", gtoname=""; 
            LBL_PERIODE.Text = tools.FormatDate(tanggal1,false).ToUpper() + " TO " + tools.FormatDate(tanggal2, false).ToUpper();
			if(!gfrom.Equals(""))
			{
                conn.QueryString = "SELECT DISTINCT SG_GRPNAME FROM SCGROUP where GROUPID='" + gfrom + "' ";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					gfromname = conn.GetFieldValue(0,"SG_GRPNAME");
				}
			}
			else
			{
				gfromname = "ALL";
			}
			LBL_FROM.Text = gfromname.ToUpper();
			
			if(!gto.Equals(""))
			{
				conn.QueryString = "SELECT DISTINCT SG_GRPNAME FROM SCGROUP where GROUPID='" + gto + "' ";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					gtoname = conn.GetFieldValue(0,"SG_GRPNAME");
				}
			}
			else
			{
				gtoname = "ALL";
			}

			LBL_TO.Text = gtoname; 
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

 		   conn.QueryString = "SELECT ap_regno, branch_name, nama, CASE WHEN SEND_DATE IS NULL OR "+
                               "SEND_DATE = '' THEN '' ELSE CONVERT(varchar, SEND_DATE, 106) END AS SEND_DATE, CASE WHEN RECEIVE_DATE IS NULL OR "+
                               "RECEIVE_DATE = '' THEN '' ELSE CONVERT(varchar, RECEIVE_DATE, 106) END AS RECEIVE_DATE, GFromName, GToName "+
                               "FROM TMP_REPORT_DOCUMENTTRACK "+
                               "WHERE (Userid ='" + Session["UserID"].ToString() + "') ORDER BY branch_name, ap_regno";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[0].Text = "&nbsp;" + ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[0].CssClass= "ItemPrint";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[1].Text = "&nbsp;" + conn.GetFieldValue(i, "branch_name").Trim();
				TBL_CONTENT.Rows[i + 1].Cells[1].CssClass= "ItemPrint";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[2].Text = "&nbsp;" + conn.GetFieldValue(i, "ap_regno");
				TBL_CONTENT.Rows[i + 1].Cells[2].CssClass= "ItemPrint";


				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[3].Text = "&nbsp;" + conn.GetFieldValue(i, "nama");
				TBL_CONTENT.Rows[i + 1].Cells[3].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[4].Text = "&nbsp;" + conn.GetFieldValue(i, "SEND_DATE");
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[5].Text = "&nbsp;" + conn.GetFieldValue(i, "RECEIVE_DATE");
				TBL_CONTENT.Rows[i + 1].Cells[5].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[6].Text = "&nbsp;" + tools.ConvertCurr(conn.GetFieldValue(i, "GFromName"));
				TBL_CONTENT.Rows[i + 1].Cells[6].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[7].Text = "&nbsp;" + tools.ConvertCurr(conn.GetFieldValue(i, "GToName"));
				TBL_CONTENT.Rows[i + 1].Cells[7].CssClass= "ItemPrint";
			}

			conn.QueryString = "SELECT COUNT(ap_regno) AS jml FROM TMP_REPORT_DOCUMENTTRACK WHERE (Userid = '" + Session["UserID"].ToString() + "')";
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
			{
				lbl_total.Text = lbl_total.Text + " " + conn.GetFieldValue(0,"jml");
			}

			conn.QueryString = "SELECT COUNT(SEND_DATE) AS jml FROM TMP_REPORT_DOCUMENTTRACK "+
                               "WHERE (Userid = '" + Session["UserID"].ToString() + "') AND (NOT (SEND_DATE IS NULL OR "+
                               "SEND_DATE = '')) AND (SEND_DATE BETWEEN " + tanggal1 + " AND " + tanggal2 + ")";
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
			{
				lbl_send.Text = lbl_send.Text + " " + conn.GetFieldValue(0,"jml");
			}

			conn.QueryString = "SELECT COUNT(RECEIVE_DATE) AS jml FROM TMP_REPORT_DOCUMENTTRACK "+
                               "WHERE (Userid = '" + Session["UserID"].ToString() + "') AND (NOT (RECEIVE_DATE IS NULL OR "+
                               "RECEIVE_DATE = '')) AND (SEND_DATE BETWEEN " + tanggal1 + " AND " + tanggal2 + ")";
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
			{
				lbl_receive.Text = lbl_receive.Text + " " + conn.GetFieldValue(0,"jml");
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
