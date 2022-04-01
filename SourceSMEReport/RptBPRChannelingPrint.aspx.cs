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
	/// Summary description for RptBPRChannelingPrint.
	/// </summary>
	public partial class RptBPRChannelingPrint : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected System.Web.UI.WebControls.Label LBL_BATCHNO;
		protected Tools tools = new Tools(); 
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Conn = (Connection) Session["Connection"];
			string sql_kondisi = Request.QueryString["sql_kondisi"].Replace("]","+") ;
			string BPRName = Request.QueryString["BPRName"];
			string Facility = Request.QueryString["Facility"];
			string Date = Request.QueryString["date"];
			Load_Data(sql_kondisi, BPRName, Facility,Date);
		}
	
		private void Load_Data(string sql_kondisi, string BPRName, string Facility, string Date)
		{
			LBL_BPRNAME.Text = BPRName;
			LBL_FACILITY.Text = Facility;
			LBL_PERIODE.Text = Date;
			float T_Submit=0, Am_Submit=0, T_Accepted=0, Am_Accepted=0, T_Rejected=0, Am_Rejected=0, Am_Bank=0;	
			Conn.QueryString = "exec Rpt_BPRChanneling '" + sql_kondisi + "' ";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[0].Text = "&nbsp;" + Conn.GetFieldValue(i,"CH_NAMA");
				TBL_CONTENT.Rows[i + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[0].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[1].Text = "&nbsp;" + Conn.GetFieldValue(i,"CH_IDENTITAS");
				TBL_CONTENT.Rows[i + 1].Cells[1].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[1].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[2].Text = "&nbsp;" + Conn.GetFieldValue(i,"CH_LIMIT");
				TBL_CONTENT.Rows[i + 1].Cells[2].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[2].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[3].Text = "&nbsp;" + Conn.GetFieldValue(i,"tujuan");
				TBL_CONTENT.Rows[i + 1].Cells[3].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[3].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[4].Text = "&nbsp;" + Conn.GetFieldValue(i,"status");
				TBL_CONTENT.Rows[i + 1].Cells[4].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint_d";

				T_Submit+=int.Parse(Conn.GetFieldValue(i,"tot"));
				Am_Submit+=float.Parse(Conn.GetFieldValue(i,"CH_LIMIT"));
				T_Accepted+=int.Parse(Conn.GetFieldValue(i,"jumlah"));
				Am_Accepted+=float.Parse(Conn.GetFieldValue(i,"amount"));
				Am_Bank+=float.Parse(Conn.GetFieldValue(i,"DANA_DARI_BANK"));
			}

			T_Rejected=T_Submit-T_Accepted;
			Am_Rejected=Am_Submit-Am_Accepted;
		
			LBL_SUBMIT.Text = GlobalTools.MoneyFormat(T_Submit.ToString());
			LBL_AMTSUBMITED.Text = GlobalTools.MoneyFormat(Am_Submit.ToString());

			LBL_ACCEPTED.Text =  GlobalTools.MoneyFormat(T_Accepted.ToString());
			LBL_AMTACCEPTED.Text = GlobalTools.MoneyFormat(Am_Accepted.ToString());
			
			LBL_REJECTED.Text = GlobalTools.MoneyFormat(T_Rejected.ToString());
			LBL_AMTREJECTED.Text = GlobalTools.MoneyFormat(Am_Rejected.ToString());
			LBL_BANK.Text = GlobalTools.MoneyFormat(Am_Bank.ToString());
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
