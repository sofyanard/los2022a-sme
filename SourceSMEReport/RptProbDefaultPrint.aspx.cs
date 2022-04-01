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
	/// Summary description for RptProbDefaultPrint.
	/// </summary>
	public partial class RptProbDefaultPrint : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();
	
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
			double recentyear=0, Distribution=0;
			LBL_PERIODE.Text = "PERIODE " + end_year.ToString();
			//double vRecentYear=0, vPastYear=0, Recent_Sub_Past=0, Recent_Div_Past=0, ExF=0;
			Conn.QueryString = "exec Rpt_ProbDefault '" + sql_kondisi + "' ";
			Conn.ExecuteQuery();
			
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				recentyear += double.Parse(Conn.GetFieldValue(i,"RecentYear").ToString()) ;
			}

			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				//urut, Attribut, [year], Risk_Class, PD, Customers
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[0].Text = "&nbsp;" + Conn.GetFieldValue(i,"Attribut");
				TBL_CONTENT.Rows[i + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[0].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[1].Text = "&nbsp;" + Conn.GetFieldValue(i,"Risk_Class");
				TBL_CONTENT.Rows[i + 1].Cells[1].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[1].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[2].Text = "&nbsp;" + Conn.GetFieldValue(i,"PD").ToString();
				TBL_CONTENT.Rows[i + 1].Cells[2].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[2].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[3].Text = "&nbsp;" + Conn.GetFieldValue(i,"Customers").ToString();
				TBL_CONTENT.Rows[i + 1].Cells[3].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[3].CssClass= "ItemPrint_d";

				Distribution = double.Parse(Conn.GetFieldValue(i,"Customers").ToString())/recentyear;
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[4].Text = "&nbsp;" + Distribution.ToString();
				TBL_CONTENT.Rows[i + 1].Cells[4].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint_d";
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
