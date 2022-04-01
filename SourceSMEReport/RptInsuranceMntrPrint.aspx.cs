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
	public partial class RptInsuranceMntrPrint : System.Web.UI.Page
	{
		protected Connection conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			string mc = Request.QueryString["mc"];
			string BU = Request.QueryString["BU"];
			string sql_kondisi = Request.QueryString["sql_kondisi"];
			string tanggal1 = Request.QueryString["tanggal1"];
			string tanggal2 = Request.QueryString["tanggal2"];
			string region = Request.QueryString["region"];
			string branch = Request.QueryString["branch"];
			string teamleader = Request.QueryString["teamleader"];
			Load_Data(sql_kondisi, tanggal1, tanggal2, region, branch, teamleader);
		}

		private void Load_Data(string sql_kondisi, string tanggal1, string tanggal2, string region, string branch, string teamleader)
		{
			/*			tanggal1
						tanggal2
						region
						branch
						teamleader
			*/			
			string regionname="", branchname="", teamleadername=""; 
			string vBranch_Name="", vAp_Regno="", vPre_Branch_Name="", vPre_Ap_Regno="";
			int k;
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
				regionname = "All Region";
			}
			LBL_REGION.Text = regionname;    

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
					this.LBL_TEAM.Text = teamleadername.ToUpper();
				}
			}
			else
			{
				teamleadername = "ALL";
				this.LBL_TEAM.Text = teamleadername.ToUpper();
			}            

			conn.QueryString = "exec Rpt_InsuranceMonitoring '" + sql_kondisi + "'";
			conn.ExecuteQuery();
			k = 0;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				vBranch_Name = conn.GetFieldValue(i, "Branch_Name").Trim();
				vAp_Regno    = conn.GetFieldValue(i, "Ap_Regno").Trim();
				if (vPre_Branch_Name.ToString() != conn.GetFieldValue(i, "Branch_Name").Trim())
				{
				    TBL_CONTENT.Rows.Add(new TableRow());
					vPre_Branch_Name = conn.GetFieldValue(i, "Branch_Name").Trim();
					TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
					TBL_CONTENT.Rows[i + k + 1].Cells[0].Text = "&nbsp;";
					TBL_CONTENT.Rows[i + k + 1].Cells[0].CssClass= "ItemPrint_d";

					TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
					TBL_CONTENT.Rows[i + k + 1].Cells[1].Text = "&nbsp;" + vPre_Branch_Name.ToString();
					TBL_CONTENT.Rows[i + k + 1].Cells[1].CssClass= "ItemPrint_d";
					k += 1;
				}

				if (vPre_Ap_Regno != conn.GetFieldValue(i, "Ap_Regno"))
				{
					TBL_CONTENT.Rows.Add(new TableRow());	
				    TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				    TBL_CONTENT.Rows[i + k + 1].Cells[0].Text = "&nbsp;";
				    TBL_CONTENT.Rows[i + k + 1].Cells[0].CssClass= "ItemPrint_d";

				    TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				    TBL_CONTENT.Rows[i + k + 1].Cells[1].Text = "&nbsp;";
				    TBL_CONTENT.Rows[i + k + 1].Cells[1].CssClass= "ItemPrint_d";

				    vPre_Ap_Regno = conn.GetFieldValue(i, "Ap_Regno").Trim();
					TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
					TBL_CONTENT.Rows[i + k + 1].Cells[2].Text = "&nbsp;" + vPre_Ap_Regno.ToString();
					TBL_CONTENT.Rows[i + k + 1].Cells[2].CssClass= "ItemPrint_d";
					k += 1;
				}

				/*				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[1].Text = "&nbsp;" + conn.GetFieldValue(i, "Branch_Name").Trim();
				TBL_CONTENT.Rows[i + k + 1].Cells[1].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[2].Text = "&nbsp;" + conn.GetFieldValue(i, "Ap_Regno").Trim();
				TBL_CONTENT.Rows[i + k + 1].Cells[2].CssClass= "ItemPrint_d";
*/
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[0].Text = ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + k + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + k + 1].Cells[0].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[1].Text = "&nbsp;";
				TBL_CONTENT.Rows[i + k + 1].Cells[1].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + k + 1].Cells[1].CssClass= "ItemPrint_d";

				string JnsAssuransi = "";
				if(conn.GetFieldValue(i, "Urut").ToString()=="1")
				{JnsAssuransi = "Jiwa";}
				else
				{
					if(conn.GetFieldValue(i, "Urut").ToString()=="1")
				      {JnsAssuransi = "Collateral";}
					else
				      {JnsAssuransi = "Credit";}
				}
				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[2].Text = "&nbsp;" + JnsAssuransi.ToString();
				TBL_CONTENT.Rows[i + k + 1].Cells[2].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + k + 1].Cells[2].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[3].Text = "&nbsp;" + conn.GetFieldValue(i, "Applicants").Trim();
				TBL_CONTENT.Rows[i + k + 1].Cells[3].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[4].Text = "&nbsp;" + conn.GetFieldValue(i, "ic_Desc").Trim();
				TBL_CONTENT.Rows[i + k + 1].Cells[4].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[5].Text = "&nbsp;" + tools.FormatDate(conn.GetFieldValue(i, "ALI_DateStart").Trim(),false);
				TBL_CONTENT.Rows[i + k + 1].Cells[5].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[6].Text = "&nbsp;" + conn.GetFieldValue(i, "CurrencyDesc").Trim();
				TBL_CONTENT.Rows[i + k + 1].Cells[6].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[7].HorizontalAlign = HorizontalAlign.Right; 
				TBL_CONTENT.Rows[i + k + 1].Cells[7].Text = "&nbsp;" + tools.MoneyFormat(conn.GetFieldValue(i, "ALI_amount").Trim());
				TBL_CONTENT.Rows[i + k + 1].Cells[7].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[8].Text = "&nbsp;" + conn.GetFieldValue(i, "RATEDesc").Trim();
				TBL_CONTENT.Rows[i + k + 1].Cells[8].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[9].Text = "&nbsp;" + conn.GetFieldValue(i, "RM_Name").Trim();
				TBL_CONTENT.Rows[i + k + 1].Cells[9].CssClass= "ItemPrint_d";
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
