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
	/// Summary description for RptProdPerformPrint.
	/// </summary>
	public partial class RptProdPerformPrint : System.Web.UI.Page
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
			string cbc = Request.QueryString["CBC"];
			string branch = Request.QueryString["Branch"];
			string teamleader = Request.QueryString["teamleader"];
			string program = Request.QueryString["program"];
            string product = Request.QueryString["product"];
			string industri = Request.QueryString["industri"];
			string reject_code = Request.QueryString["reject_code"];
			string accept_code = Request.QueryString["accept_code"];
			if(!IsPostBack)
			{
				loadData(tanggal1, tanggal2,cbc, branch, teamleader, program, product, industri, accept_code, reject_code);
			}
		}

		private void loadData(string tanggal1, string tanggal2, string cbc, string branch, string teamleader, string program, string product, string industri, string accept_code, string reject_code)
		{
			string cbcname="", branchname="", programname="", productname="", industriname=""; 
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
				conn.QueryString = "select su_fullname from scuser where userid='" + teamleader + "' ";
				conn.ExecuteQuery();
				if(conn.GetRowCount()>0)
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
			//conn.QueryString = "SELECT * FROM TMP_REPORT_PRODPERFORMANCE WHERE userid = '" + Session["UserID"].ToString() + "' order by branch_name asc";
			conn.QueryString = "SELECT Branch_Name, ProductDesc, Industri, apptypedesc, sum(jm_app) as jm_app, sum(jumlah) as jumlah, sum(disbursed) as disbursed, PROG_CODE "+
                               "FROM TMP_REPORT_PRODPERFORMANCE where userid='" + Session["UserID"].ToString() + "' "+
                               "group by Branch_Name, ProductDesc, Industri, apptypedesc, PROG_CODE "+
                               "order by branch_name, productdesc ";
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
				TBL_CONTENT.Rows[i + 1].Cells[4].Text = "&nbsp;" + conn.GetFieldValue(i, "APPTYPEDESC");
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[5].Text = "&nbsp;" + conn.GetFieldValue(i, "JM_APP");
				TBL_CONTENT.Rows[i + 1].Cells[5].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[6].Text = "&nbsp;" + tools.ConvertCurr(conn.GetFieldValue(i, "JUMLAH"));
				TBL_CONTENT.Rows[i + 1].Cells[6].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 1].Cells[6].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[7].Text = "&nbsp;" + tools.ConvertCurr(conn.GetFieldValue(i, "DISBURSED"));
				TBL_CONTENT.Rows[i + 1].Cells[7].HorizontalAlign= HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 1].Cells[7].CssClass= "ItemPrint";
			}
			
			conn.QueryString = "select sum(jm_app) as Total from TMP_REPORT_PRODPERFORMANCE where userid='" + Session["UserID"].ToString() + "' ";
			conn.ExecuteQuery();
			if(conn.GetRowCount()>0)
			{
				lbl_total.Text = lbl_total.Text  + " " + conn.GetFieldValue(0,"Total");
			}
			if(accept_code.Equals(""))
			{
			  accept_code="3.7";
			}
			conn.QueryString = "select sum(jm_app) as Accept from TMP_REPORT_PRODPERFORMANCE where cp_decsta='" + accept_code + "' and userid='" + Session["UserID"].ToString() + "' ";
			conn.ExecuteQuery();
			if(conn.GetRowCount()>0)
			{
				lbl_accepted.Text = lbl_accepted.Text + " " + conn.GetFieldValue(0,"Accept");
			}
			if(reject_code.Equals(""))
			{
				reject_code="3.8";
			}
			conn.QueryString = "select sum(jm_app) as Reject from TMP_REPORT_PRODPERFORMANCE where cp_decsta='" + reject_code + "' and userid='" + Session["UserID"].ToString() + "' ";
			conn.ExecuteQuery();
			if(conn.GetRowCount()>0)
			{
				lbl_rejected.Text =  lbl_rejected.Text + " " + conn.GetFieldValue(0,"Reject");
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
