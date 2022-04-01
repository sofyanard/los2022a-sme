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

namespace SME.Scoring
{
	/// <summary>
	/// Summary description for RptPRRKPreparationPrint.
	/// </summary>
	public partial class RptPRRKPreparationPrint : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Conn = (Connection) Session["Connection"];
			string sql_kondisi = Request.QueryString["sql_kondisi"];
			string Start_Date = Request.QueryString["Start_Date"];
			string End_Date = Request.QueryString["End_Date"];
			string region = Request.QueryString["region"];
			string cbc = Request.QueryString["cbc"];
			string branch = Request.QueryString["branch"];
			string PS = Request.QueryString["PS"];
			string teamleader = Request.QueryString["teamleader"];
			Load_Data(sql_kondisi, Start_Date, End_Date, region, cbc,	branch,	PS,	teamleader);
		}
        
		private void Load_Data(string sql_kondisi, string Start_Date, string End_Date, string region, string cbc,string branch,string PS,string teamleader)
		{
			string regionname="", branchname="", teamleadername=""; 
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
				regionname = "All Region";
			}
			LBL_REGION.Text = regionname;    
			
			if(!cbc.Equals(""))
			{
				Conn.QueryString = "select distinct  branch_name  from rfbranch where branch_code ='" + cbc + "'";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					branchname = Conn.GetFieldValue(0,"branch_name");
					LBL_CBC.Text = branchname.ToUpper();
				}
			}
			else
			{
				branchname = "All CBC";
				LBL_CBC.Text = branchname.ToUpper();
			}

			if(!branch.Equals(""))
			{
				Conn.QueryString = "select distinct  branch_name  from rfbranch where branch_code ='" + branch + "'";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					branchname = Conn.GetFieldValue(0,"branch_name");
					this.LBL_BRANCH.Text = branchname.ToUpper();
				}
			}
			else
			{
				branchname = "All Branch";
				this.LBL_BRANCH.Text = branchname.ToUpper();
			}

			if(!PS.Equals(""))
			{
				Conn.QueryString = "select su_fullname from scuser where userid='" + PS + "' ";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					LBL_PS.Text = Conn.GetFieldValue(0,"su_fullname");
				}
			}
			else
			{
				LBL_PS.Text = "All";
			}

			if(!teamleader.Equals(""))
			{
				Conn.QueryString = "select su_fullname from scuser where userid='" + teamleader + "' ";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					teamleadername = Conn.GetFieldValue(0,"su_fullname");
					LBL_TEAM.Text = teamleadername.ToUpper();
				}
			}
			else
			{
				teamleadername = "ALL";
				this.LBL_TEAM.Text = teamleadername.ToUpper();
			}

			Conn.QueryString = "exec Rpt_PRRKPreparation '" + sql_kondisi + "' ";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[0].Text = ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[0].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[1].Text = "&nbsp;" + Conn.GetFieldValue(0,"branch_name");
				TBL_CONTENT.Rows[i + 1].Cells[1].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[1].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[2].Text = "&nbsp;" + Conn.GetFieldValue(0,"ap_Regno");
				TBL_CONTENT.Rows[i + 1].Cells[2].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[2].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[3].Text = "&nbsp;" + Conn.GetFieldValue(0,"Applicant");
				TBL_CONTENT.Rows[i + 1].Cells[3].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[3].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[4].Text = "&nbsp;";
				TBL_CONTENT.Rows[i + 1].Cells[4].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[5].Text = "&nbsp;";
				TBL_CONTENT.Rows[i + 1].Cells[5].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[5].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[6].Text = "&nbsp;" + tools.FormatDate(Conn.GetFieldValue(0,"Start_Date"), false);
				TBL_CONTENT.Rows[i + 1].Cells[6].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[6].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[7].Text = "&nbsp;" + tools.FormatDate(Conn.GetFieldValue(0,"End_Date"), false);
				TBL_CONTENT.Rows[i + 1].Cells[7].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[7].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[8].Text = "&nbsp;" + Conn.GetFieldValue(0,"Jml_Hari");
				TBL_CONTENT.Rows[i + 1].Cells[8].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[8].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[9].Text = "&nbsp;" + Conn.GetFieldValue(0,"su_fullname");
				TBL_CONTENT.Rows[i + 1].Cells[9].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[9].CssClass= "ItemPrint_d";
			}
			
			Conn.QueryString = "exec Rpt_PRRKPreparationFooter '" + " and End_Date is not null and End_Date<>'''' " + sql_kondisi + "' ";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
			{
				LBL_COMPLETED.Text = Conn.GetFieldValue(0,"jml");
			}
			else {LBL_COMPLETED.Text= "0";}
			
			Conn.QueryString = "exec Rpt_PRRKPreparationFooter '" + " and (End_Date is null or End_Date<>'''') " + sql_kondisi + "' ";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
			{
				LBL_PENDING.Text = Conn.GetFieldValue(0,"jml");
			}
			else {LBL_PENDING.Text="0";}

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
