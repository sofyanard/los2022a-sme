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

namespace SME.SourceSMEReport
{
	/// <summary>
	/// Summary description for RpteBizCardPrint.
	/// </summary>
	public partial class RpteBizCardPrint : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Conn = (Connection) Session["Connection"];
            string sql_kondisi = Request.QueryString["sql_kondisi"];
			string tanggal1 = Request.QueryString["Start_Date"];
			string tanggal2 = Request.QueryString["End_Date"];
			string region = Request.QueryString["Region"];
			string CBC = Request.QueryString["CBC"];
			string branch = Request.QueryString["Branch"];
			if(!IsPostBack)
			{
				loadData(sql_kondisi, tanggal1, tanggal2,region, CBC, branch);
			}
		}

		private void loadData(string sql_kondisi, string tanggal1, string tanggal2, string region, string CBC, string branch)
		{
			string regionname="", branchname=""; 
			LBL_PERIODE.Text = tools.FormatDate(tanggal1, false) + " TO " + tools.FormatDate(tanggal2, false);
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

			if(!CBC.Equals(""))
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

			if(!branch.Equals(""))
			{
				Conn.QueryString = "select distinct  branch_name  from rfbranch where branch_code ='" + branch + "'";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					branchname = Conn.GetFieldValue(0,"branch_name");
					LBL_BRANCH.Text = branchname.ToUpper();
				}
			}
			else
			{
				branchname = "ALL";
				LBL_BRANCH.Text = branchname.ToUpper();
			}

			Conn.QueryString = "exec Rpt_EbizCard '" + sql_kondisi +  "'";
			Conn.ExecuteQuery();
			string pre_applicant="";
			int k=0;
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				if (pre_applicant.ToString()!=Conn.GetFieldValue(i, "Applicant").ToString())
				{
					TBL_CONTENT.Rows.Add(new TableRow());
					TBL_CONTENT.Rows[i + k + 2].Cells.Add(new TableCell());
					TBL_CONTENT.Rows[i + k + 2].Cells[0].Text = "&nbsp;" + Conn.GetFieldValue(i, "Applicant").ToString();
					TBL_CONTENT.Rows[i + k + 2].Cells[0].HorizontalAlign = HorizontalAlign.Center;
					TBL_CONTENT.Rows[i + k + 2].Cells[0].CssClass= "ItemPrint_d";
					k+=1;
					pre_applicant=Conn.GetFieldValue(i, "Applicant").ToString();
				}

				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + k + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 2].Cells[0].Text = "&nbsp;";
				TBL_CONTENT.Rows[i + k + 2].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + k + 2].Cells[0].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + k + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 2].Cells[1].Text = "&nbsp;" + Conn.GetFieldValue(i, "ap_regno").ToString();
				TBL_CONTENT.Rows[i + k + 2].Cells[1].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + k + 2].Cells[1].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 2].Cells[2].Text = "&nbsp;" + Conn.GetFieldValue(i, "productdesc").ToString();
				TBL_CONTENT.Rows[i + k + 2].Cells[2].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + k + 2].Cells[2].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 2].Cells[3].Text = "&nbsp;" + Conn.GetFieldValue(i, "issuancedate").ToString();
				TBL_CONTENT.Rows[i + k + 2].Cells[3].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + k + 2].Cells[3].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + k + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 2].Cells[4].Text = "&nbsp;" + Conn.GetFieldValue(i, "CardHolder").ToString();
				TBL_CONTENT.Rows[i + k + 2].Cells[4].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + k + 2].Cells[4].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 2].Cells[5].Text = "&nbsp;" + Conn.GetFieldValue(i, "endorsename_1").ToString();
				TBL_CONTENT.Rows[i + k + 2].Cells[5].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + k + 2].Cells[5].CssClass= "ItemPrint_d";
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
