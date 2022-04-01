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
	/// Summary description for RptDataAnalysisPrint.
	/// </summary>
	public partial class RptDataAnalysisPrint : System.Web.UI.Page
	{
		protected Connection conn  = new Connection(); 
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				//Response.Redirect("/SME/Restricted.aspx");

			string tanggal1 = Request.QueryString["Start_Date"];
			string tanggal2 = Request.QueryString["End_Date"];
			string region = Request.QueryString["Region"];
			string branch = Request.QueryString["Branch"];
			string Score_Value = Request.QueryString["Score_Value"];

			if(!IsPostBack)
			{
				loadData(tanggal1, tanggal2,region, branch, Score_Value);
			}
		}

		private void loadData(string tanggal1, string tanggal2,string region, string branch, string Score_Value)
		{
			string regionname="", branchname=""; //, rmname="", Score_ValueName=""; 
            LBL_PERIODE.Text = tools.FormatDate(tanggal1, false) + " TO " + tools.FormatDate(tanggal2, false);
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
            LBL_REGION.Text = regionname;    

			if(!branch.Equals(""))
			{
				conn.QueryString = "select distinct  branch_name  from rfbranch where branch_code ='" + branch + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					branchname = conn.GetFieldValue(0,"branch_name");
					this.LBL_CBC.Text = branchname.ToUpper();
				}
			}
			else
			{
				branchname = "ALL";
				this.LBL_CBC.Text = branchname.ToUpper();
			}
            
			if(!Score_Value.Equals(""))
			{
				conn.QueryString = "SELECT WAREDESC FROM RFSCRSTRATEGYWARE where WAREID='" + Score_Value.ToString() + "' ";
				conn.ExecuteQuery();
				if(conn.GetRowCount()>0)
				{
					LBL_SCORE.Text = conn.GetFieldValue(0,"WAREDESC");
				}
				else
				{
					LBL_SCORE.Text = "ALL";
				}
			}
			else
			{
				LBL_SCORE.Text = "ALL";
			}

		   	conn.QueryString = "select * from TMP_REPORT_DATAANALISIS where userid = '" + Session["UserID"].ToString()  + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[0].Text = ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[0].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[1].Text = "&nbsp;" + conn.GetFieldValue(i, "AP_REGNO").Trim();
				TBL_CONTENT.Rows[i + 1].Cells[1].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[2].Text = "&nbsp;" + conn.GetFieldValue(i, 7);
				TBL_CONTENT.Rows[i + 1].Cells[2].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[3].Text = "&nbsp;" + conn.GetFieldValue(i, "COLLATERAL TYPE");
				TBL_CONTENT.Rows[i + 1].Cells[3].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[4].Text = "&nbsp;" + conn.GetFieldValue(i, "AREANAME");
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[5].Text = "&nbsp;" + conn.GetFieldValue(i, "COMPANY NAME");
				TBL_CONTENT.Rows[i + 1].Cells[5].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[6].Text = "&nbsp;" + conn.GetFieldValue(i, "CBC/BRANCH");
				TBL_CONTENT.Rows[i + 1].Cells[6].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[7].Text = "&nbsp;" + conn.GetFieldValue(i, "COMPANY LEGAL TYPE");
				TBL_CONTENT.Rows[i + 1].Cells[7].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[8].Text = "&nbsp;" + conn.GetFieldValue(i, "COMPANY GROUP");
				TBL_CONTENT.Rows[i + 1].Cells[8].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[9].Text = "&nbsp;" + conn.GetFieldValue(i, "APPTYPE");
				TBL_CONTENT.Rows[i + 1].Cells[9].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[10].Text = "&nbsp;" + tools.ConvertCurr(conn.GetFieldValue(i, "CP_LIMIT"));
                TBL_CONTENT.Rows[i + 1].Cells[10].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 1].Cells[10].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[11].Text = "&nbsp;" + tools.ConvertCurr(conn.GetFieldValue(i, "LIMITEXPOSURE"));
                TBL_CONTENT.Rows[i + 1].Cells[11].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 1].Cells[11].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[12].Text = "&nbsp;" + tools.FormatDate(conn.GetFieldValue(i, "KEY PERSON DOB"),false);
				TBL_CONTENT.Rows[i + 1].Cells[12].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[13].Text = "&nbsp;" + conn.GetFieldValue(i, "KEY PERSON SEX");
				TBL_CONTENT.Rows[i + 1].Cells[13].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[14].Text = "&nbsp;" + conn.GetFieldValue(i, "KEY PERSON EDUCATION");
				TBL_CONTENT.Rows[i + 1].Cells[14].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[15].Text = "&nbsp;" + conn.GetFieldValue(i, "KEY PERSON MARITAL");
				TBL_CONTENT.Rows[i + 1].Cells[15].CssClass= "ItemPrint_d";

                TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[16].Text = "&nbsp;" + conn.GetFieldValue(i, "KEY PERSON #CHILDREN");
				TBL_CONTENT.Rows[i + 1].Cells[16].CssClass= "ItemPrint_d";

/*				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[17].Text = "&nbsp;" + ""; //conn.GetFieldValue(i, 16);
				TBL_CONTENT.Rows[i + 1].Cells[17].CssClass= "ItemPrint_d";
*/
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[17].Text = "&nbsp;" + conn.GetFieldValue(i, "CU_JNSALAMAT");
				TBL_CONTENT.Rows[i + 1].Cells[17].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[18].Text = "&nbsp;" + conn.GetFieldValue(i, "ECONOMY SECTOR");
				TBL_CONTENT.Rows[i + 1].Cells[18].CssClass= "ItemPrint_d";			

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[19].Text = "&nbsp;" + tools.FormatDate(conn.GetFieldValue(i, "TIME AT BUSINESS"),false);
				TBL_CONTENT.Rows[i + 1].Cells[19].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[20].Text = "&nbsp;" + conn.GetFieldValue(i, 28);
				TBL_CONTENT.Rows[i + 1].Cells[20].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[21].Text = "&nbsp;" + conn.GetFieldValue(i, "YEAR RELATIONSHIP WITH BANK MANDIRI");
				TBL_CONTENT.Rows[i + 1].Cells[21].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				//other bank name
				TBL_CONTENT.Rows[i + 1].Cells[22].Text = "&nbsp;" + conn.GetFieldValue(i, "co_bankname");
				TBL_CONTENT.Rows[i + 1].Cells[22].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[23].Text = "&nbsp;" + tools.ConvertCurr(conn.GetFieldValue(i, "COLLATERAL VALUE"));
				TBL_CONTENT.Rows[i + 1].Cells[23].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 1].Cells[23].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[24].Text = "&nbsp;" + conn.GetFieldValue(i, "COLLATERAL OWNERSHIP");
				TBL_CONTENT.Rows[i + 1].Cells[24].CssClass= "ItemPrint_d";
			
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[25].Text = "&nbsp;" + conn.GetFieldValue(i, 24);
				TBL_CONTENT.Rows[i + 1].Cells[25].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[26].Text = "&nbsp;" + conn.GetFieldValue(i, "internalcollect");
				TBL_CONTENT.Rows[i + 1].Cells[26].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[27].Text = "&nbsp;" + conn.GetFieldValue(i, "FINANCIAL YEAR");
				TBL_CONTENT.Rows[i + 1].Cells[27].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[28].Text = "&nbsp;" + conn.GetFieldValue(i, "FINANCIAL YEAR POS 1");
				TBL_CONTENT.Rows[i + 1].Cells[28].CssClass= "ItemPrint_d";
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
