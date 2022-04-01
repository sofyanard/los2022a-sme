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
	/// Summary description for RptRatingMigrationPrint.
	/// </summary>
	public partial class RptRatingMigrationPrint : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection Conn = new Connection();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Conn = (Connection) Session["Connection"];
			string sql_kondisi = Request.QueryString["sql_kondisi"];
			string start_year = Request.QueryString["start_year"];
			string end_year = Request.QueryString["end_year"];
			Load_Data(sql_kondisi, start_year, end_year);
		}

		private void Load_Data(string sql_kondisi, string start_year, string end_year)
		{
			Conn.QueryString = "exec Rpt_RatingMigration '" + sql_kondisi + "' ";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[0].Text = ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[0].CssClass= "ItemPrint_d";

				//cu_ref, nasabah, industri, [year], sb_total_score, sb_pd, sb_custrating, sb_facrating, sb_exploss, sr_bcgfinrating 
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[1].Text = "&nbsp;" + Conn.GetFieldValue(0,"nasabah");
				TBL_CONTENT.Rows[i + 1].Cells[1].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[1].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[2].Text = "&nbsp;" + Conn.GetFieldValue(0,"industri");
				TBL_CONTENT.Rows[i + 1].Cells[2].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[2].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[3].Text = "&nbsp;" + Conn.GetFieldValue(0,"sb_total_score");
				TBL_CONTENT.Rows[i + 1].Cells[3].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[3].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[4].Text = "&nbsp;" + Conn.GetFieldValue(0,"sb_pd");
				TBL_CONTENT.Rows[i + 1].Cells[4].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[5].Text = "&nbsp;" + Conn.GetFieldValue(0,"sr_bcgfinrating");
				TBL_CONTENT.Rows[i + 1].Cells[5].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[5].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[6].Text = "&nbsp;" + Conn.GetFieldValue(0,"sb_custrating");
				TBL_CONTENT.Rows[i + 1].Cells[6].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[6].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[7].Text = "&nbsp;" + Conn.GetFieldValue(0,"sb_facrating");
				TBL_CONTENT.Rows[i + 1].Cells[7].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[7].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[8].Text = "&nbsp;" + Conn.GetFieldValue(0,"sb_exploss");
				TBL_CONTENT.Rows[i + 1].Cells[8].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[8].CssClass= "ItemPrint_d";
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
