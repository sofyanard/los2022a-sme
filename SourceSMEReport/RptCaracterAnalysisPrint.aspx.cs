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
	/// Summary description for RptCaracterAnalysisPrint.
	/// </summary>
	public partial class RptCaracterAnalysisPrint : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Conn = (Connection) Session["Connection"];

			
			//string sql_kondisi = Request.QueryString["sql_kondisi"];

			//Load_Data(sql_kondisi);

			/*
			string start_year = Request.QueryString["start_year"];
			string end_year = Request.QueryString["end_year"];			
			*/

			string vUserID = (string) Session["UserID"];
			string vPastStartDate, vPastEndDate, vRecentEndDate, vNotaID, vProgramID;

			vPastStartDate = Request.QueryString["past_start_date"];
			vPastEndDate = Request.QueryString["past_end_date"];
			vRecentEndDate = Request.QueryString["recent_end_date"];
			vNotaID = Request.QueryString["nota_id"];
			vProgramID = Request.QueryString["programid"];			

			Load_Data(vPastStartDate, vPastEndDate, vRecentEndDate, vNotaID, vProgramID, vUserID);


			//Load_Data(sql_kondisi, start_year, end_year);
		}


		/// <summary>
		/// Fungsi ini untuk me-load data.
		/// (Sudah tidak dipakai lagi)
		/// </summary>
		/// <param name="sql_kondisi"></param>
		/// <param name="start_year"></param>
		/// <param name="end_year"></param>
		private void Load_Data(string sql_kondisi, string start_year, string end_year)
		{
			double recentyear=0, pastyear=0, recentyear_persen=0, pastyear_persen=0; //, Distribution=0
			LBL_PERIODE.Text = "PERIODE" + end_year.ToString();
			//double vRecentYear=0, vPastYear=0, Recent_Sub_Past=0, Recent_Div_Past=0, ExF=0;
			Conn.QueryString = "exec Rpt_CaracteristicAnalisis '" + sql_kondisi + "' ";
			Conn.ExecuteQuery();
			
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				recentyear += double.Parse(Conn.GetFieldValue(i,"RecentCustomer").ToString()) ;
				pastyear += double.Parse(Conn.GetFieldValue(i,"PastCustomer").ToString()) ;
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
				TBL_CONTENT.Rows[i + 1].Cells[1].Text = "&nbsp;" + Conn.GetFieldValue(i,"PastCustomer");
				TBL_CONTENT.Rows[i + 1].Cells[1].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 1].Cells[1].CssClass= "ItemPrint_d";

				pastyear_persen = (double.Parse(Conn.GetFieldValue(i,"PastCustomer").ToString())/pastyear);
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[2].Text = "&nbsp;" + pastyear_persen.ToString()+ "&nbsp;";
				TBL_CONTENT.Rows[i + 1].Cells[2].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 1].Cells[2].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[3].Text = "&nbsp;" + Conn.GetFieldValue(i,"RecentCustomer").ToString();
				TBL_CONTENT.Rows[i + 1].Cells[3].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[3].CssClass= "ItemPrint_d";

				recentyear_persen = double.Parse(Conn.GetFieldValue(i,"RecentCustomer").ToString())/recentyear;
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[4].Text = "&nbsp;" + recentyear_persen + "&nbsp;";
				TBL_CONTENT.Rows[i + 1].Cells[4].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint_d";
			}
		}
	
		
		/// <summary>
		/// Fungsi ini untuk me-load data
		/// </summary>
		/// <param name="vPastStartDate"></param>
		/// <param name="vPastEndDate"></param>
		/// <param name="vRecentEndDate"></param>
		/// <param name="vNotaID"></param>
		/// <param name="vProgramID"></param>
		private void Load_Data(string vPastStartDate, string vPastEndDate, string vRecentEndDate, string vNotaID, string vProgramID, string vUserID)
		{
			//double recentyear=0, pastyear=0; //recentyear_persen=0, pastyear_persen=0, Distribution=0;					

			Conn.QueryString = "exec SP_RPT_CHARACTERISTIC_REPORT '" + 
				vPastStartDate + "', '" + 
				vPastEndDate + "', '" + 
				vRecentEndDate + "', '" + 
				vNotaID + "', '" + 
				vProgramID + "', '" + 
				vUserID + "'";
			Conn.ExecuteQuery();
			
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{				
				TBL_CONTENT.Rows.Add(new TableRow());

				for (int j=0; j < Conn.GetColumnCount(); j++) 
				{
					string namaKolom = "";
					namaKolom = Conn.GetDataTable().Columns[j].ToString();

					TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
					TBL_CONTENT.Rows[i + 1].Cells[j].Text = "&nbsp;" + Conn.GetFieldValue(i, namaKolom);
					TBL_CONTENT.Rows[i + 1].Cells[j].HorizontalAlign = HorizontalAlign.Center;
					TBL_CONTENT.Rows[i + 1].Cells[j].CssClass= "ItemPrint_d";
				}
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
