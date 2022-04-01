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

namespace SME.CreditProposal
{
	/// <summary>
	/// Summary description for NotaAnalisa.
	/// </summary>
	public partial class SkalaAngsuranAnuitet : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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

		protected void BTN_HITUNG_Click(object sender, System.EventArgs e)
		{
			try 
			{
				this.hitung();
				this.viewTable();
				this.TXT_LIMIT.Text = tool.MoneyFormat(this.TXT_LIMIT.Text.ToString());
				this.TXT_TOTBUNGA.ReadOnly = false;
				this.TXT_ANGSPOKOK.ReadOnly = false;
				this.BTN_UPDATE.Visible = true;
				this.LBL_TOTAL_BUNGA.Text = this.TXT_TOTBUNGA.Text;

			} 
			catch (Exception ex) 
			{
				string temp = ex.Message.ToString();
			}
		}

		private void hitung() 
		{
			double limit, bunga, bunga1, angsuranpokok; //, saldoawal, totalbunga;
			int tenor, tenor1, gperiode;
			
			limit = Convert.ToDouble(this.TXT_LIMIT.Text);
			tenor = Convert.ToInt16(this.TXT_JANGKAWAKTU.Text);
			gperiode = Convert.ToInt16(this.TXT_GPERIODE.Text);
			bunga = Convert.ToDouble(this.TXT_BUNGA.Text);
			tenor1 = tenor - gperiode;
			bunga1 = bunga / 12;

			//--------- Hitung angsuran pokok ----------------
			angsuranpokok = 0;
			if (bunga > 0) 
				angsuranpokok = limit / ((1 - Math.Pow(1 + (bunga1/100), -tenor1)) / (bunga1/100));				

			this.TXT_ANGSPOKOK.Text = angsuranpokok.ToString("#,##0.00");
		}

		private void viewTable() 
		{
			int tenor = Convert.ToInt16(this.TXT_JANGKAWAKTU.Text);
			double saldoawal = Convert.ToDouble(this.TXT_LIMIT.Text);
			double totalbunga = 0;
			double bunga = Convert.ToDouble(this.TXT_BUNGA.Text);
			double gperiode = Convert.ToDouble(this.TXT_GPERIODE.Text);
			double angsuranpokok = Convert.ToDouble(this.TXT_ANGSPOKOK.Text);

			string[,] angsuran = new string[tenor,6];
			for (int i = 1; i <= tenor; i++) 
			{
				angsuran[i-1,0] = i.ToString();
				angsuran[i-1,1] = saldoawal.ToString("#,##0.00");
				angsuran[i-1,3] = ((saldoawal * (bunga/12))/100).ToString("#,##0.00");
				totalbunga = totalbunga + Convert.ToDouble(angsuran[i-1,3]);
				if (i <= gperiode) 
				{
					angsuran[i-1,2] = "0";
					angsuran[i-1,4] = angsuran[i-1,3];
					angsuran[i-1,5] = saldoawal.ToString("#,##0.00");
				}
				else 
				{
					angsuran[i-1,2] = (angsuranpokok - Convert.ToDouble(angsuran[i-1,3])).ToString("#,##0.00");
					angsuran[i-1,4] = angsuranpokok.ToString("#,###");
					angsuran[i-1,5] = (saldoawal - Convert.ToDouble(angsuran[i-1,2])).ToString("#,##0.00");
					saldoawal = Convert.ToDouble(angsuran[i-1, 5]);
				}
			}

			//------------- sementara pembuatan table dipisah codingnya ---------------------------------
			Table tbl = new Table();
			tbl.CellPadding = 0;
			tbl.CellSpacing = 0;
			for (int i = 1; i <= tenor; i++) 
			{
				TableRow tr = new TableRow();				

				TableCell td1 = new TableCell();				
				td1.Width = 40;
				td1.HorizontalAlign = HorizontalAlign.Right;				
				td1.Text = angsuran[i-1,0];

				//--- Saldo Awal
				TableCell td2 = new TableCell();
				td2.Width = 180;
				td2.HorizontalAlign = HorizontalAlign.Right;
				td2.Text = angsuran[i-1,1];

				//---- Angsuran Pokok
				TableCell td3 = new TableCell();
				td3.Width = 120;
				td3.HorizontalAlign = HorizontalAlign.Right;				
				td3.Text = angsuran[i-1,2];

				//--- Bunga
				TableCell td4 = new TableCell();	
				td4.Width = 100;
				td4.HorizontalAlign = HorizontalAlign.Right;				
				td4.Text = angsuran[i-1,3];

				//--- Total
				TableCell td5 = new TableCell();
				td5.Width = 120;
				td5.HorizontalAlign = HorizontalAlign.Right;
				td5.Text = angsuran[i-1,4];

				//--- Saldo Akhir
				TableCell td6 = new TableCell();
				td6.Width = 120;
				td6.HorizontalAlign = HorizontalAlign.Right;
				td6.Text = angsuran[i-1,5];

				tr.Cells.Add(td1);
				tr.Cells.Add(td2);
				tr.Cells.Add(td3);
				tr.Cells.Add(td4);
				tr.Cells.Add(td5);
				tr.Cells.Add(td6);
				tr.BorderStyle = BorderStyle.Solid;				

				tbl.Rows.Add(tr);
			}

			this.PH_TABEL.Controls.Add(tbl);			
			this.TXT_TOTBUNGA.Text = totalbunga.ToString("#,##0.00");
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			this.TXT_TOTBUNGA.Text = tool.MoneyFormat(this.TXT_TOTBUNGA.Text.ToString());
			this.LBL_TOTAL_BUNGA.Text = this.TXT_TOTBUNGA.Text;
			this.viewTable();
		}
	}
}
