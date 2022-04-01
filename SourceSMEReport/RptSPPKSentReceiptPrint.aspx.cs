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
	/// Summary description for RptSPPKSentReceiptPrint.
	/// </summary>
	public partial class RptSPPKSentReceiptPrint : System.Web.UI.Page
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
			string teamleader = Request.QueryString["teamleader"];
			if(!IsPostBack)
			{
				loadData(sql_kondisi, Start_Date, End_Date, region, cbc, branch, teamleader);
			}
		}

		private void loadData(string sql_kondisi, string Start_Date, string End_Date,string region, string cbc, string branch, string teamleader)
		{
			string haridisp=""; 
			LBL_PERIODE.Text = tools.FormatDate(Start_Date, false).ToUpper() + " To " + tools.FormatDate(End_Date,false).ToUpper();
			if(!region.Equals(""))
			{
				Conn.QueryString = "select areaid, areaname  from rfarea where areaid='" + region + "'";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					LBL_REGION.Text = Conn.GetFieldValue(0,"areaname");
				}
			}
			else
			{
				LBL_REGION.Text = "All";
			}
            
			if(!cbc.Equals(""))
			{
				Conn.QueryString = "select distinct  branch_name  from rfbranch where branch_code ='" + cbc + "'";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					LBL_CBC.Text = Conn.GetFieldValue(0,"branch_name");
				}
			}
			else
			{
				LBL_CBC.Text = "ALL";
			}

			if(!branch.Equals(""))
			{
				Conn.QueryString = "select distinct  branch_name  from rfbranch where branch_code ='" + branch + "'";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					LBL_BRANCH.Text = Conn.GetFieldValue(0,"branch_name");
				}
			}
			else
			{
				LBL_BRANCH.Text = "All";
			}
			
			if (!teamleader.Equals(""))
			{
				Conn.QueryString="select su_fullname from scuser where userid='" + teamleader + "' ";
				Conn.ExecuteQuery();
				if(Conn.GetRowCount()>0)
				{
					lbl_team.Text = Conn.GetFieldValue(0,0).ToUpper();
				}
				else
				{
					lbl_team.Text = "ALL";
				}
			}
			else
			{
				lbl_team.Text = "ALL";
			}
			Conn.QueryString = "exec Rpt_SPPKSentReceipt '" + sql_kondisi + "' ";
			Conn.ExecuteQuery(1800);
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				switch(Conn.GetFieldValue(i, "hari"))
				{
					case "1" : 
						haridisp = "=1";
						break;
					case "2" :
						haridisp = "=2";
						break;
					case "3" :
						haridisp = "=3";
						break;
					case "5" :
						haridisp = "<=5";
						break;
					case "10" :
						haridisp = "<=10";
						break;
					case "20" :
						haridisp = "<=20";
						break;
					case "40" :
						haridisp = "<=40";
						break;
					case "60" :
						haridisp = "<=60";
						break;
					default :
						haridisp = ">61";
						break;
				}
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[0].Text = "&nbsp;" + haridisp; 
				TBL_CONTENT.Rows[i + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[0].CssClass= "ItemPrint";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[1].Text = "&nbsp;" + Conn.GetFieldValue(i, 1).Trim();
				TBL_CONTENT.Rows[i + 1].Cells[1].CssClass= "ItemPrint";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[2].Text = "&nbsp;" + tools.ConvertCurr(Conn.GetFieldValue(i, 2));
				TBL_CONTENT.Rows[i + 1].Cells[2].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 1].Cells[2].CssClass= "ItemPrint";
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
