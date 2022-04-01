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
using Microsoft.VisualBasic;

namespace SME.SourceSMEReport
{
	/// <summary>
	/// Summary description for RptOverideTrackingPrint.
	/// </summary>
	public partial class RptOverideTrackingPrint : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		   Conn = (Connection) Session["Connection"];

		   string sql_kondisi = Request.QueryString["sql_kondisi"];
		   string Start_Date = Request.QueryString["Start_Date"];
		   string End_Date =Request.QueryString["End_Date"];
           string region = Request.QueryString["region"];
		   string product = Request.QueryString["product"];
		   Load_Data(sql_kondisi, Start_Date, End_Date, region, product);
		}

		private void Load_Data(string sql_kondisi, string Start_Date, string End_Date, string region, string product)
		{
			LBL_PERIODE.Text = tools.FormatDate(Start_Date, false) + " TO " + tools.FormatDate(End_Date, false);
	        if(!product.Equals(""))
			{
				Conn.QueryString = "select productdesc from rfproduct where productid='" + product + "'";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					LBL_PRODUCT.Text = Conn.GetFieldValue(0,"productdesc").ToUpper();
				}
			}
			else
			{
				LBL_PRODUCT.Text = "All";
			}

			if(!region.Equals(""))
			{
				Conn.QueryString = "select areaname from rfarea where areaid = '" + region + "' ";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					LBL_REGION.Text = Conn.GetFieldValue(0,"areaname").ToString();
				}
			}
			else
			{
				LBL_REGION.Text = "All";
			}


			Conn.QueryString = "exec Rpt_OvrTracking '" + sql_kondisi + "'";
			//conn.QueryString = "exec Rpt_InsuranceMonitoring ''";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 2].Cells[0].Text =  "&nbsp;&nbsp;&nbsp;&nbsp;" + Conn.GetFieldValue(i,"Reasondesc");
				TBL_CONTENT.Rows[i + 2].Cells[0].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + 2].Cells[0].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 2].Cells[1].Text = "&nbsp;" + Conn.GetFieldValue(i,"Approved") + "&nbsp;";
				TBL_CONTENT.Rows[i + 2].Cells[1].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 2].Cells[1].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 2].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 2].Cells[2].Text = "&nbsp;" + Conn.GetFieldValue(i,"Reject") + "&nbsp;";
				TBL_CONTENT.Rows[i + 2].Cells[2].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 2].Cells[2].CssClass= "ItemPrint_d";
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
