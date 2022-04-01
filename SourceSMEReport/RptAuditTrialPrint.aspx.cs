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
	/// Summary description for RptCOBIRequestPrint.
	/// </summary>
	public partial class RptAuditTrialPrint : System.Web.UI.Page
	{
		protected Connection conn = new Connection();
		protected System.Web.UI.WebControls.Label lbl_total_completed;
		protected System.Web.UI.WebControls.Label lbl_total_peding;
		protected System.Web.UI.WebControls.Label lbl_ket1;
		protected System.Web.UI.WebControls.Label lbl_ket2;
		protected Tools tools = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
		
			if(!IsPostBack)
			{
				loadData();
			}
		}
		
		private void loadData()
		{
			
			// check first, on whether this users or applications can be displayed 
			// if Yes, execute
			// else set sql_kondisi = "1=2"			


			LBL_PERIODE.Text ="PERIODE "+ Request.QueryString["tanggal1"].ToUpper()+ " TO " + Request.QueryString["tanggal2"].ToUpper() ;
			LBL_REGNO.Text  = "APPL# "+ Request.QueryString["regno"];
			LBL_BRANCH.Text ="BRANCH " + Request.QueryString["branch"].ToUpper();
			LBL_RM.Text = "PERSONAL "+ Request.QueryString["rm"].ToUpper() ;
			
			
			conn.QueryString = "exec Rpt_AuditTrial  '" + Request.QueryString["sql_kondisi"] +  "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[0].Text = ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[0].CssClass= "ItemPrint";
				
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[1].Text = "&nbsp;" + conn.GetFieldValue(i,0);
				TBL_CONTENT.Rows[i + 1].Cells[1].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[2].Text = "&nbsp;" + conn.GetFieldValue(i,1);
				TBL_CONTENT.Rows[i + 1].Cells[2].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[3].Text = "&nbsp;" + conn.GetFieldValue(i,2);
				TBL_CONTENT.Rows[i + 1].Cells[3].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[4].Text = "&nbsp;" + conn.GetFieldValue(i,3);
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[5].Text = "&nbsp;" + conn.GetFieldValue(i,4);
				TBL_CONTENT.Rows[i + 1].Cells[5].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[6].Text = "&nbsp;" + tools.FormatDate(conn.GetFieldValue(i,5),false);
				TBL_CONTENT.Rows[i + 1].Cells[6].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[7].Text = "&nbsp;" + conn.GetFieldValue(i,6);
				TBL_CONTENT.Rows[i + 1].Cells[7].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[8].Text = "&nbsp;" + tools.MoneyFormat(conn.GetFieldValue(i,7));
				TBL_CONTENT.Rows[i + 1].Cells[8].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + 1].Cells[8].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[9].Text = "&nbsp;" + conn.GetFieldValue(i,8);
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
