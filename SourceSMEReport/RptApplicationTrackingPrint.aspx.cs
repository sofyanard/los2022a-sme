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
	/// Summary description for RptApplicationTrackingPrint.
	/// </summary>
	public partial class RptApplicationTrackingPrint : System.Web.UI.Page
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

			Conn.QueryString = "exec Rpt_Apptracking '" + sql_kondisi.ToString() + "'";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[0].Text = ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[0].CssClass= "ItemPrint";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[1].Text = "&nbsp;" + Conn.GetFieldValue(i, "areaname").Trim();
				TBL_CONTENT.Rows[i + 1].Cells[1].CssClass= "ItemPrint";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[2].Text = "&nbsp;" + Conn.GetFieldValue(i, "branch_name");
				TBL_CONTENT.Rows[i + 1].Cells[2].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[3].Text = "&nbsp;" + Conn.GetFieldValue(i, "PRE_FIRSTNAME") + " " + Conn.GetFieldValue(i, "PRE_MIDDLENAME")  + " " +  Conn.GetFieldValue(i, "PRE_LASTNAME");
				TBL_CONTENT.Rows[i + 1].Cells[3].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[4].Text = "&nbsp;" + Conn.GetFieldValue(i, "AP_REGNO");
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[5].Text = "&nbsp;" + tools.FormatDate(Conn.GetFieldValue(i, "PRE_APPENTRYDATE").ToString(), false) ;
				TBL_CONTENT.Rows[i + 1].Cells[5].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[6].Text = "&nbsp;" + tools.FormatDate(Conn.GetFieldValue(i, "AP_RECVDATE").ToString(), false) ;
				TBL_CONTENT.Rows[i + 1].Cells[6].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[7].Text = "&nbsp;" + tools.MoneyFormat(Conn.GetFieldValue(i, "PRE_APPAMOUNT").ToString()) + "&nbsp;";
                TBL_CONTENT.Rows[i + 1].Cells[7].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 1].Cells[7].CssClass= "ItemPrint";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[8].Text = "&nbsp;" + Conn.GetFieldValue(i, "LAMA") + "&nbsp;" ;
				TBL_CONTENT.Rows[i + 1].Cells[8].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 1].Cells[8].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[9].Text = "&nbsp;" + Conn.GetFieldValue(i, "SU_FULLNAME");
				TBL_CONTENT.Rows[i + 1].Cells[9].CssClass= "ItemPrint";
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
