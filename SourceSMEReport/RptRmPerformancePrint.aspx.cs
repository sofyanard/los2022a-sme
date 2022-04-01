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
	/// Summary description for RptRmPerformancePrint.
	/// </summary>
	public partial class RptRmPerformancePrint : System.Web.UI.Page
	{
		protected Connection conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				//Response.Redirect("/SME/Restricted.aspx");

			string tanggal1 = Request.QueryString["Start_Date"];
			string tanggal2 = Request.QueryString["End_Date"];
			string cbc = Request.QueryString["CBC"];
			string branch = Request.QueryString["BRANCH"];
			string teamleader = Request.QueryString["teamleader"];
			string program = Request.QueryString["PROGRAM"];
            string product = Request.QueryString["PRODUCT"];
			string industri = Request.QueryString["INDUSTRI"];

			if(!IsPostBack)
			{
				loadData(tanggal1, tanggal2,cbc, branch, teamleader, program, product, industri);
			}
		}

		private void loadData(string tanggal1, string tanggal2, string cbc, string branch, string teamleader, string program, string product, string industri)
		{
			string cbcname="", branchname="", programname="", productname="", industriname=""; 
			string reject_code = "", accept_code = "";

			LBL_PERIODE.Text = tools.FormatDate(tanggal1,false)+ " TO " + tools.FormatDate(tanggal2,false);
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
				conn.QueryString="select su_fullname from scuser where userid='" + teamleader + "' ";
				conn.ExecuteQuery();
				if(conn.GetRowCount()>0)
				{
					LBL_TEAM.Text = conn.GetFieldValue(0,0).ToUpper();
				}
				else
				{
					LBL_TEAM.Text= "ALL";
				}
			}
			else
			{
				LBL_TEAM.Text= "ALL";
			}

			if(!program.Equals(""))
			{
				conn.QueryString = "SELECT PROGRAMDESC FROM RFPROGRAM  where PROGRAMID='" + program + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					programname = conn.GetFieldValue(0,"PROGRAMDESC");
				}
				else
				{
					programname = "ALL";
				}
			}
			else
			{
				programname = "ALL";
			}
			
			LBL_PROGRAM.Text =  programname.ToString();

			if(!product.Equals(""))
			{ 
				conn.QueryString = "SELECT PRODUCTDESC FROM RFPRODUCT where PRODUCTID='" + product + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					productname = conn.GetFieldValue(0,"PRODUCTDESC");
				}
				else
				{
					productname ="ALL";
				}
			}
			else
			{
				productname ="ALL";
			}
			LBL_PRODUCT.Text = productname;

			if (!industri.Equals(""))
			{
				conn.QueryString = "SELECT BUSSTYPEDESC FROM RFBUSINESSTYPE where BUSSTYPEID='" + industri + "'";
				conn.ExecuteQuery();
				if(conn.GetRowCount()>0)
				{
					industriname = conn.GetFieldValue(0,"BUSSTYPEDESC");
				}
				else
				{
					industriname = "ALL";
				}
			}
			else
			{
				industriname = "ALL";
			}
			LBL_INDUSTRI.Text = industriname;
//			conn.QueryString = "SELECT * FROM TMP_REPORT_RMPERFORMANCE WHERE userid = '" + Session["UserID"].ToString() + "' order by branch_name asc";
			conn.QueryString = "SELECT su_fullname, Branch_Name, ProductDesc, Industri, apptypedesc, sum(jm_app) as jm_app, sum(jumlah) as jumlah, sum(disbursed) as disbursed, PROG_CODE, su_teamleader "+
                               "FROM TMP_REPORT_RMPERFORMANCE where userid='" + Session["UserID"].ToString() + "' "+
                               "group by su_fullname, Branch_Name, ProductDesc, Industri, apptypedesc, PROG_CODE, su_teamleader "+
                               "order by branch_name ";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[0].Text = "&nbsp;" + ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[0].CssClass= "ItemPrint";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[1].Text = "&nbsp;" + conn.GetFieldValue(i, "BRANCH_NAME").Trim();
				TBL_CONTENT.Rows[i + 1].Cells[1].CssClass= "ItemPrint";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[2].Text = "&nbsp;" + conn.GetFieldValue(i, "PRODUCTDESC");
				TBL_CONTENT.Rows[i + 1].Cells[2].CssClass= "ItemPrint";


				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[3].Text = "&nbsp;" + conn.GetFieldValue(i, "INDUSTRI");
				TBL_CONTENT.Rows[i + 1].Cells[3].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[4].Text = "&nbsp;" + conn.GetFieldValue(i, "jm_app");
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[5].Text = "&nbsp;" + tools.ConvertCurr(conn.GetFieldValue(i, "JUMLAH"));
				TBL_CONTENT.Rows[i + 1].Cells[5].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 1].Cells[5].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[6].Text = "&nbsp;" + tools.ConvertCurr(conn.GetFieldValue(i, "DISBURSED"));
				TBL_CONTENT.Rows[i + 1].Cells[6].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 1].Cells[6].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[7].Text = "&nbsp;" + conn.GetFieldValue(i, "su_teamleader");
				TBL_CONTENT.Rows[i + 1].Cells[7].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[8].Text = "&nbsp;" + conn.GetFieldValue(i, "su_fullname");
				TBL_CONTENT.Rows[i + 1].Cells[8].CssClass= "ItemPrint";
			}

			conn.QueryString = "select in_reject, in_approve from rfinitial";
			conn.ExecuteQuery();
			if(conn.GetRowCount()>0)
			{
				reject_code = conn.GetFieldValue(0,"in_reject");
				accept_code = conn.GetFieldValue(0,"in_approve");
			}
			else
			{
				reject_code = "3.8";
				accept_code = "3.7";
			}
			conn.QueryString = "select sum(jm_app) as Accepted from TMP_REPORT_RMPERFORMANCE where userid='" + Session["UserID"].ToString() + "' and cp_decsta='" + accept_code + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
			{
				lbl_total2.Text = lbl_total2.Text + "  " + conn.GetFieldValue(0,"Accepted");
			}
			else
			{
				lbl_total2.Text = lbl_total2.Text + "  " + "0";
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
