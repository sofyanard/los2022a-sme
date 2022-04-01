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
	/// Summary description for RptOPDetalPrint.
	/// </summary>
	public partial class RptOPDetalPrint : System.Web.UI.Page
	{
		protected Connection conn = new Connection();
		protected Tools tools = new Tools();
	
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

			if(!IsPostBack)
			{
				loadData(tanggal1, tanggal2,region, cbc, branch, rm);
			}
		}

		private void loadData(string tanggal1, string tanggal2,string region, string cbc, string branch, string rm)
		{
			string  cbcname="", branchname=""; 
            string vLimit_Applied ="",vEquiIDR ="",vLimitDisbursed="";

			LBL_PERIODE.Text = tools.FormatDate(tanggal1,false).ToUpper() + " TO " + tools.FormatDate(tanggal2, false).ToUpper();
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

			conn.QueryString = "SELECT * FROM TMP_REPORT_DAILYPOSRPT WHERE userid = '" + Session["UserID"].ToString() + "' order by jml_app, productid";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[0].Text = ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[0].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[1].Text = "&nbsp;" + tools.FormatDate(conn.GetFieldValue(i, "AP_SIGNDATE"),true);
				TBL_CONTENT.Rows[i + 1].Cells[1].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[2].Text = "&nbsp;" + conn.GetFieldValue(i, "BRANCH_NAME");
				TBL_CONTENT.Rows[i + 1].Cells[2].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[3].Text = "&nbsp;" + conn.GetFieldValue(i, "APPLICANT");
				TBL_CONTENT.Rows[i + 1].Cells[3].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[4].Text = "&nbsp;" + conn.GetFieldValue(i, "JML_APP");
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint_d";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[5].Text = "&nbsp;" + conn.GetFieldValue(i, "APPTYPEDESC");
				TBL_CONTENT.Rows[i + 1].Cells[5].CssClass= "ItemPrint_d";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[6].Text = "&nbsp;" + conn.GetFieldValue(i, "INDUSTRI");
				TBL_CONTENT.Rows[i + 1].Cells[6].CssClass= "ItemPrint_d";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[7].Text = "&nbsp;" + conn.GetFieldValue(i, "PRODUCTDESC");
				TBL_CONTENT.Rows[i + 1].Cells[7].CssClass= "ItemPrint_d";

			
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[8].Text = "&nbsp;" + conn.GetFieldValue(i, "CURRENCY");
				TBL_CONTENT.Rows[i + 1].Cells[8].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 1].Cells[8].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[9].Text = "&nbsp;" + tools.ConvertCurr(conn.GetFieldValue(i, "APPLIED_EXRPLIMIT"));
				TBL_CONTENT.Rows[i + 1].Cells[9].HorizontalAlign =HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 1].Cells[9].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[10].Text = "&nbsp;" + tools.ConvertCurr(conn.GetFieldValue(i, "CP_EXRPLIMIT"));
				TBL_CONTENT.Rows[i + 1].Cells[10].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[11].Text = "&nbsp;" + tools.ConvertCurr(conn.GetFieldValue(i, "APPROVED_EXRPLIMIT"));
				TBL_CONTENT.Rows[i + 1].Cells[11].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 1].Cells[11].CssClass= "ItemPrint_d";

				if ((conn.GetFieldValue(i, "STATUS")=="Approved")||(conn.GetFieldValue(i, "STATUS").Trim()==""))
				{
					vLimit_Applied = conn.GetFieldValue(i, "AD_EXLIMITVAL");
				}
				else
				{
					vLimit_Applied = "0";
				}

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[12].Text = "&nbsp;" + tools.ConvertCurr(vLimit_Applied);
				TBL_CONTENT.Rows[i + 1].Cells[12].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 1].Cells[12].CssClass= "ItemPrint_d";

				if ((conn.GetFieldValue(i, "STATUS")=="Approved")||(conn.GetFieldValue(i, "STATUS").Trim()==""))
				{
					vEquiIDR = conn.GetFieldValue(i, "AD_LIMIT");
				}
				else
				{
					vEquiIDR = "0";
				}
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[13].Text = "&nbsp;" + tools.ConvertCurr(vEquiIDR);
				TBL_CONTENT.Rows[i + 1].Cells[13].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 1].Cells[13].CssClass= "ItemPrint_d";

				if ((conn.GetFieldValue(i, "STATUS")=="Approved")||(conn.GetFieldValue(i, "STATUS").Trim()==""))
				{
					vLimitDisbursed = conn.GetFieldValue(i, "CP_LIMITDISBURSED");
				}
				else
				{
					vLimitDisbursed = "0";
				}
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[14].Text = "&nbsp;" + tools.ConvertCurr(vLimitDisbursed);
				TBL_CONTENT.Rows[i + 1].Cells[14].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 1].Cells[14].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[15].Text = "&nbsp;" + conn.GetFieldValue(i, "STATUS");
				TBL_CONTENT.Rows[i + 1].Cells[15].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[16].Text = "&nbsp;" + conn.GetFieldValue(i, "SU_FULLNAME");
				TBL_CONTENT.Rows[i + 1].Cells[16].CssClass= "ItemPrint_d";
			}
			conn.QueryString = "select count(*) as jml, sum(cp_exrplimit) as applied from tmp_REPORT_DAILYPOSRPT  where userid='" + Session["USERID"].ToString() + "' ";
            conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
			{
				lbl_applied.Text = lbl_applied.Text + " #App " + conn.GetFieldValue(0,"jml") + " Amount " + tools.ConvertCurr(conn.GetFieldValue(0,"Applied"));
			}
			
			conn.QueryString = "select sum(case when status='Approved' or status ='' then "+
                               "1 "+
                               "else "+
                               "0 "+
                               "end) as jml, sum(case when status='Approved' or status ='' then "+
                               "cp_exrplimit "+
                               "else "+
                               "0 "+
                               "end) as Approved "+
                               "from tmp_REPORT_DAILYPOSRPT where userid='" + Session["UserID"].ToString() + "' ";
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
			{
				lbl_approved.Text = lbl_approved.Text + " #App " + conn.GetFieldValue(0,"jml") + " Amount " + tools.ConvertCurr(conn.GetFieldValue(0,"Approved"));
			}

			conn.QueryString = "select sum(case when status='Approved' or status ='' then "+
                               "1 "+
                               "else "+
                               "0 "+
                               "end) as jml, "+
                               "sum(case when status='Approved' or status ='' then "+
                               "cp_limitdisbursed "+
                               "else "+
                               "0 end) as disbursed "+
                               "from tmp_REPORT_DAILYPOSRPT where userid='" + Session["UserID"].ToString() + "' ";
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
			{
				lbl_disbursed.Text= lbl_disbursed.Text + " #App " + conn.GetFieldValue(0,"jml") + " Amount " + tools.ConvertCurr(conn.GetFieldValue(0,"disbursed"));
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
