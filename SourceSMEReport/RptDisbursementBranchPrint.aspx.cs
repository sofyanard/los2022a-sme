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
	/// Summary description for RptDisbursementBranchPrint.
	/// </summary>
	public partial class RptDisbursementBranchPrint : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection Conn = new Connection();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Conn = (Connection) Session["Connection"];
			string sql_kondisi = Request.QueryString["sql_kondisi"]; 
			string Start_Date = Request.QueryString["Start_Date"];
			string End_Date = Request.QueryString["End_Date"];
			string region = Request.QueryString["region"];  
			string branch = Request.QueryString["branch"]; 
			string industri = Request.QueryString["industri"]; 
			string program = Request.QueryString["program"];
			string product = Request.QueryString["product"];
			Load_Data(sql_kondisi, Start_Date, End_Date, region, branch, industri, program, product);
		}

		private void Load_Data(string sql_kondisi, string Start_Date, string End_Date, string region, string branch, string industri, string program, string product)
		{
			string regionname="", branchname=""; 
			LBL_PERIODE.Text = tools.FormatDate(Start_Date, false) + " TO " + tools.FormatDate(End_Date, false);
			if(!region.Equals(""))
			{
				Conn.QueryString = "select areaid, areaname  from rfarea where areaid='" + region + "'";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					regionname = Conn.GetFieldValue(0,"areaname");
				}
			}
			else
			{
				regionname = "ALL";
			}
			LBL_REGION.Text = regionname;    

			if(!branch.Equals(""))
			{
				Conn.QueryString = "select distinct  branch_name  from rfbranch where branch_code ='" + branch + "'";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					branchname = Conn.GetFieldValue(0,"branch_name");
					LBL_CBC.Text = branchname.ToUpper();
				}
			}
			else
			{
				branchname = "ALL";
				LBL_CBC.Text = branchname.ToUpper();
			}

			if(!industri.Equals(""))
			{
				Conn.QueryString = "SELECT BUSSTYPEDESC FROM RFBUSINESSTYPE where BUSSTYPEID='" + industri + "'";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					LBL_INDUSTRI.Text = Conn.GetFieldValue(0,0);
				}
			}
			else
			{
				LBL_INDUSTRI.Text = "All";
			}

			if(!program.Equals(""))
			{
				Conn.QueryString = "SELECT DISTINCT PROGRAMDESC FROM RFPROGRAM where PROGRAMID='" + program + "' ";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					LBL_PROGRAM.Text = Conn.GetFieldValue(0,0);
				}
			}
			else
			{
				LBL_PROGRAM.Text = "All";
			}

			if(!product.Equals(""))
			{
				Conn.QueryString = "select productdesc from rfproduct where productid='" + product + "' ";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					LBL_PRODUCT.Text = Conn.GetFieldValue(0,0);
				}
			}
			else
			{
				LBL_PRODUCT.Text = "All";
			}

			Conn.QueryString = "exec Rpt_DisbursementBranchPrint '" + sql_kondisi +  "'";
			Conn.ExecuteQuery();
			string pre_area="";
			int k=0;
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				if (pre_area.ToString()!=Conn.GetFieldValue(i, "areaid").ToString())
				{
					TBL_CONTENT.Rows.Add(new TableRow());
					TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
					TBL_CONTENT.Rows[i + k + 1].Cells[0].Text = "&nbsp;" + Conn.GetFieldValue(i, "areaname").ToString();
					TBL_CONTENT.Rows[i + k + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
					TBL_CONTENT.Rows[i + k + 1].Cells[0].CssClass= "ItemPrint_d";
					k+=1;
					pre_area=Conn.GetFieldValue(i, "areaid").ToString();
				}

				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[0].Text = "&nbsp;";
				TBL_CONTENT.Rows[i + k + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + k + 1].Cells[0].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[1].Text = "&nbsp;" + Conn.GetFieldValue(i, "branch_name").ToString();
				TBL_CONTENT.Rows[i + k + 1].Cells[1].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 1].Cells[1].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[2].Text = "&nbsp;" + tools.ConvertCurr(Conn.GetFieldValue(i, "AD_Limit").ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 1].Cells[2].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 1].Cells[2].CssClass= "ItemPrint_d";
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
