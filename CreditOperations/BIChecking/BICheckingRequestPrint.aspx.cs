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

namespace SME.CreditOperations.BIChecking
{
	/// <summary>
	/// Summary description for BICheckingRequestPrint.
	/// </summary>
	public partial class BICheckingRequestPrint : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button BTN_PRINT;

		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn ;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			if(!IsPostBack)
			{
				loadData();
			}
		}

		private void loadData()
		{
			TBL_CONTENT.Rows.Add(new TableRow());
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[0].Text = "No.";
			TBL_CONTENT.Rows[0].Cells[0].Width = 30;
			TBL_CONTENT.Rows[0].Cells[0].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[1].Text = "No Surat";
			TBL_CONTENT.Rows[0].Cells[1].Width = 120;
			TBL_CONTENT.Rows[0].Cells[1].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[2].Text = "Nama Pejabat";
			TBL_CONTENT.Rows[0].Cells[2].Width = 80;
			TBL_CONTENT.Rows[0].Cells[2].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[3].Text = "No NPWP";
			TBL_CONTENT.Rows[0].Cells[3].Width = 80;
			TBL_CONTENT.Rows[0].Cells[3].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[4].Text = "Jenis Debitur";
			TBL_CONTENT.Rows[0].Cells[4].Width = 20;
			TBL_CONTENT.Rows[0].Cells[4].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[5].Text = "Nama";
			TBL_CONTENT.Rows[0].Cells[5].Width = 150;
			TBL_CONTENT.Rows[0].Cells[5].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[6].Text = "Alamat";
			TBL_CONTENT.Rows[0].Cells[6].Width = 180;
			TBL_CONTENT.Rows[0].Cells[6].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[7].Text = "Kota";
			TBL_CONTENT.Rows[0].Cells[7].Width = 60;
			TBL_CONTENT.Rows[0].Cells[7].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[8].Text = "No KTP/AKTA";
			TBL_CONTENT.Rows[0].Cells[8].Width = 80;
			TBL_CONTENT.Rows[0].Cells[8].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[9].Text = "Tempat Lahir";
			TBL_CONTENT.Rows[0].Cells[9].Width = 60;
			TBL_CONTENT.Rows[0].Cells[9].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[10].Text = "Tgl Lahir/Issuance Akta Pendirian";
			TBL_CONTENT.Rows[0].Cells[10].Width = 80;
			TBL_CONTENT.Rows[0].Cells[10].CssClass= "HeaderPrint";
			TBL_CONTENT.Rows[0].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[0].Cells[11].Text = "Jabatan";
			TBL_CONTENT.Rows[0].Cells[11].Width = 80;
			TBL_CONTENT.Rows[0].Cells[11].CssClass= "HeaderPrint";

			conn.QueryString = "select NOSURAT, PEJABAT, NPWP, JENISDEBITUR, " +
				"NAMA, ALAMAT, KOTA, KTP, POB, convert(varchar,DOB,103) DOB, JABATAN " +
                "from VW_CREOPR_BICHECK_REQUESTPRINT " +
				"where ap_regno = '" + Request.QueryString["regno"] + "' ";
			conn.ExecuteQuery();

			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[0].Text = ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[0].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				if (conn.GetFieldValue(i, "NOSURAT").Trim() == "1")
					TBL_CONTENT.Rows[i + 1].Cells[1].Text = "&nbsp;" + Request.QueryString["nosurat"];
				TBL_CONTENT.Rows[i + 1].Cells[1].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[2].Text = "&nbsp;" + conn.GetFieldValue(i, "PEJABAT");
				TBL_CONTENT.Rows[i + 1].Cells[2].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[3].Text = "&nbsp;" + conn.GetFieldValue(i, "NPWP");
				TBL_CONTENT.Rows[i + 1].Cells[3].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[4].Text = "&nbsp;" + conn.GetFieldValue(i, "JENISDEBITUR");
				TBL_CONTENT.Rows[i + 1].Cells[4].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[5].Text = "&nbsp;" + conn.GetFieldValue(i, "NAMA");
				TBL_CONTENT.Rows[i + 1].Cells[5].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[6].Text = "&nbsp;" + conn.GetFieldValue(i, "ALAMAT");
				TBL_CONTENT.Rows[i + 1].Cells[6].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[7].Text = "&nbsp;" + conn.GetFieldValue(i, "KOTA");
				TBL_CONTENT.Rows[i + 1].Cells[7].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[8].Text = "&nbsp;" + conn.GetFieldValue(i, "KTP");
				TBL_CONTENT.Rows[i + 1].Cells[8].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[9].Text = "&nbsp;" + conn.GetFieldValue(i, "POB");
				TBL_CONTENT.Rows[i + 1].Cells[9].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[10].Text = conn.GetFieldValue(i, "DOB");
				TBL_CONTENT.Rows[i + 1].Cells[10].CssClass= "ItemPrint";
				TBL_CONTENT.Rows[i + 1].Cells[10].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[11].Text = "&nbsp;" + conn.GetFieldValue(i, "JABATAN");
				TBL_CONTENT.Rows[i + 1].Cells[11].CssClass= "ItemPrint";
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
