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
	/// Summary description for RptKoperasiPrint.
	/// </summary>
	public partial class RptKoperasiPrint : System.Web.UI.Page
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
			string branch_code = Request.QueryString["branch_code"];
			string area = Request.QueryString["area"];
			string bussgrp = Request.QueryString["bussgrp"];
			loadData(sql_kondisi, Start_Date, End_Date, area, branch_code, bussgrp);
		}

		private void loadData(string sql_kondisi, string Start_Date, string End_Date, string area, string branch_code, string bussgrp)
		{
			LBL_PERIODE.Text = tools.FormatDate(Start_Date, false) + " To " + tools.FormatDate(End_Date,false);
			if(!area.Equals(""))
			{
				Conn.QueryString = "select areaid, areaname  from rfarea where areaid='" + area + "'";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					LBL_REGION.Text = Conn.GetFieldValue(0,"areaname");
				}
			}
			else
			{
				LBL_REGION.Text = "ALL";
			}

			if(!branch_code.Equals(""))
			{
				Conn.QueryString = "select distinct  branch_name  from rfbranch where branch_code ='" + branch_code + "'";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					LBL_BRANCH.Text = Conn.GetFieldValue(0,"branch_name").ToUpper();
				}
			}
			else
			{
				LBL_BRANCH.Text = "ALL";
			}

			if (!bussgrp.Equals(""))
			{   
				Conn.QueryString="select bussunitdesc from rfbusinessunit where active='1' and bussunitid='" + bussgrp.ToString() + "' ";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					lbl_bussgrp.Text = Conn.GetFieldValue(0,"bussunitdesc").ToUpper();
				}
				else
				{
					lbl_bussgrp.Text = "ALL";				
				}
			}
			else
			{
				lbl_bussgrp.Text = "ALL";
			}

			string preMainCIF="", preMainName="", PreMainAp_Regno="", MainAcc_No="";
			int k=0;
			Conn.QueryString = "exec Rpt_Koperasi '" + sql_kondisi.ToString() + "'";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				if ((preMainCIF.ToString()!=Conn.GetFieldValue(i, "MainCIF").ToString())||
					(preMainName.ToString()!=Conn.GetFieldValue(i, "MainName").ToString())||
					(PreMainAp_Regno.ToString()!=Conn.GetFieldValue(i, "MainAp_Regno").ToString())||
					(MainAcc_No.ToString()!=Conn.GetFieldValue(i, "ACC_NO").ToString()))
				{
                     preMainCIF=Conn.GetFieldValue(i, "MainCIF").ToString();
					 preMainName=Conn.GetFieldValue(i, "MainName").ToString();
					 PreMainAp_Regno=Conn.GetFieldValue(i, "MainAp_Regno").ToString();
					 MainAcc_No=Conn.GetFieldValue(i, "ACC_NO").ToString();

					 TBL_CONTENT.Rows.Add(new TableRow());
					 TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
					 TBL_CONTENT.Rows[i + k + 1].Cells[0].Text = "&nbsp;" + Conn.GetFieldValue(i, "MainCIF").Trim();
					 TBL_CONTENT.Rows[i + k + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
					 TBL_CONTENT.Rows[i + k + 1].Cells[0].CssClass= "ItemPrint";
				
					 TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
					 TBL_CONTENT.Rows[i + k + 1].Cells[1].Text = "&nbsp;" +  Conn.GetFieldValue(i, "MainName").Trim();
					 TBL_CONTENT.Rows[i + k + 1].Cells[1].CssClass= "ItemPrint";
				
					 TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
					 TBL_CONTENT.Rows[i + k + 1].Cells[2].Text = "&nbsp;" + Conn.GetFieldValue(i, "MainAp_Regno");
					 TBL_CONTENT.Rows[i + k + 1].Cells[2].CssClass= "ItemPrint";

					 TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
					 TBL_CONTENT.Rows[i + k + 1].Cells[3].Text = "&nbsp;" + Conn.GetFieldValue(i, "ACC_NO");
					 TBL_CONTENT.Rows[i + k + 1].Cells[3].CssClass= "ItemPrint";
					 k+=1;
				}
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[0].Text = "&nbsp;";
				TBL_CONTENT.Rows[i + k + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + k + 1].Cells[0].CssClass= "ItemPrint";
				
				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[1].Text = "&nbsp;";
				TBL_CONTENT.Rows[i + k + 1].Cells[1].CssClass= "ItemPrint";
				
				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[2].Text = "&nbsp;";
				TBL_CONTENT.Rows[i + k + 1].Cells[2].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[3].Text = "&nbsp;";
				TBL_CONTENT.Rows[i + k + 1].Cells[3].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[4].Text = "&nbsp;" + Conn.GetFieldValue(i, "SubAp_Regno");
				TBL_CONTENT.Rows[i + k + 1].Cells[4].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[5].Text = "&nbsp;" + Conn.GetFieldValue(i, "SubName") ;
				TBL_CONTENT.Rows[i + k + 1].Cells[5].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[6].Text = "&nbsp;" + Conn.GetFieldValue(i, "SubCIF") ;
				TBL_CONTENT.Rows[i + k + 1].Cells[6].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[7].Text = "&nbsp;" + Conn.GetFieldValue(i, "AA_NO");
				TBL_CONTENT.Rows[i + k + 1].Cells[7].CssClass= "ItemPrint";
				
				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[8].Text = "&nbsp;" + Conn.GetFieldValue(i, "productdesc");
				TBL_CONTENT.Rows[i + k + 1].Cells[8].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[9].Text = "&nbsp;" + Conn.GetFieldValue(i, "ACC_NOSub");
				TBL_CONTENT.Rows[i + k + 1].Cells[9].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[10].Text = "&nbsp;" + Conn.GetFieldValue(i, "ProductType");
				TBL_CONTENT.Rows[i + k + 1].Cells[10].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + k + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 1].Cells[11].Text = "&nbsp;" + Conn.GetFieldValue(i, "cp_limit");
				TBL_CONTENT.Rows[i + k + 1].Cells[11].CssClass= "ItemPrint";
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
