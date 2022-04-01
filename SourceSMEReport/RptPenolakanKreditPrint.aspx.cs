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
	/// Summary description for RptInsuranceMntrPrint.
	/// </summary>
	public partial class RptPenolakanKreditPrint : System.Web.UI.Page
	{
		protected Connection conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			string sql_kondisi = Request.QueryString["sql_kondisi"];
			string tanggal1 = Request.QueryString["tanggal1"];
			string tanggal2 = Request.QueryString["tanggal2"];
			string CBC = Request.QueryString["CBC"];
			string BRANCH = Request.QueryString["BRANCH"];
			string teamleader = Request.QueryString["teamleader"];
			string program = Request.QueryString["program"];
			string product = Request.QueryString["product"];
			Load_Data(sql_kondisi, tanggal1, tanggal2, CBC, BRANCH, teamleader, program, product);
		}


		private void Load_Data(string sql_kondisi, string tanggal1, string tanggal2, string CBC, string BRANCH, string teamleader, string program, string product)
		{
			string branchname="", teamleadername="", programname=""; 
			LBL_PERIODE.Text = tools.FormatDate(tanggal1, false) + " TO " + tools.FormatDate(tanggal2, false);

			if(!CBC.Equals(""))
			{
				conn.QueryString = "select distinct  branch_name  from rfbranch where branch_code ='" + CBC + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					branchname = conn.GetFieldValue(0,"branch_name");
					this.LBL_CBC.Text = branchname.ToUpper();
				}
			}
			else
			{
				branchname = "All Branch";
				this.LBL_CBC.Text = branchname.ToUpper();
			}

			if(!BRANCH.Equals(""))
			{
				conn.QueryString = "select distinct  branch_name  from rfbranch where branch_code ='" + BRANCH + "'";
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

			if(!program.Equals(""))
			{
				conn.QueryString = "select programdesc from rfprogram where programid='" + program + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					programname = conn.GetFieldValue(0,"programdesc");
					LBL_PROGRAM.Text = teamleadername.ToUpper();
				}
			}
			else
			{
				programname = "All";
				LBL_PROGRAM.Text = teamleadername.ToUpper();
			}       

			if(!product.Equals(""))
			{
				conn.QueryString = "select productdesc from rfproduct where productid='" + product + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					LBL_PRODUCT.Text = conn.GetFieldValue(0,"productdesc").ToUpper();
				}
			}
			else
			{
				LBL_PRODUCT.Text = "All";
			}

			conn.QueryString = "exec Rpt_RejectReason '" + sql_kondisi + "'";
			//conn.QueryString = "exec Rpt_InsuranceMonitoring ''";
			conn.ExecuteQuery();
            double Total_Pembagi=0;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				Total_Pembagi += double.Parse(conn.GetFieldValue(i,"Total_Amount").ToString());
			}

			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[0].Text = ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[0].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[1].Text = conn.GetFieldValue(i,"Branch_Name");
				TBL_CONTENT.Rows[i + 1].Cells[1].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 1].Cells[1].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[2].Text = conn.GetFieldValue(i,"ProductDesc");
				TBL_CONTENT.Rows[i + 1].Cells[2].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 1].Cells[2].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[3].Text = conn.GetFieldValue(i,"Reject_Reason");
				TBL_CONTENT.Rows[i + 1].Cells[3].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 1].Cells[3].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[4].Text = tools.MoneyFormat(conn.GetFieldValue(i,"Total_Amount").ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + 1].Cells[4].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				double vPersen=0;
				if (Total_Pembagi!=0)
				{vPersen = (double.Parse(conn.GetFieldValue(i,"Total_Amount").ToString())/Total_Pembagi)*100;}
				else
				{vPersen = 0;}
				TBL_CONTENT.Rows[i + 1].Cells[5].Text = vPersen.ToString() + "&nbsp;%&nbsp;";//(double.Parse(conn.GetFieldValue(i,"Percentage").ToString()) * 100) + "&nbsp;";
				TBL_CONTENT.Rows[i + 1].Cells[5].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 1].Cells[5].CssClass= "ItemPrint_d";
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
