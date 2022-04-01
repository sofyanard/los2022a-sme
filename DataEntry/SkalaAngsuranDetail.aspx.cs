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
	public partial class SkalaAngsuranDetail : System.Web.UI.Page
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
				this.TXT_ANGSPOKOK.ReadOnly = false;
				this.BTN_UPDATE.Visible = true;
				this.TXT_LIMIT_KREDIT.Text = tool.MoneyFormat(this.TXT_LIMIT_KREDIT.Text.ToString());
			}
			catch (Exception ex) 
			{
				string temp = ex.Message.ToString();
			}
		}

		private void hitung() 
		{
			double bunga, tenor, blnan, gperiode, limit;
			double row, angspokok, perblnan, saldoawal;
			int rowgperiode;

			bunga		= Convert.ToDouble(this.TXT_BUNGA.Text);
			tenor		= Convert.ToDouble(this.TXT_TENOR.Text);
			blnan		= Convert.ToDouble(this.TXT_BULANAN.Text);
			gperiode	= Convert.ToDouble(this.TXT_GRACE_PERIOD.Text);
			limit		= Convert.ToDouble(this.TXT_LIMIT_KREDIT.Text);

			if (tenor > 0 && blnan > 0) 
				row = tenor / blnan;
			else 
				row = 0;

			angspokok = limit / (row - (gperiode / blnan));
			if (blnan > 0)
				perblnan = tenor / blnan;
			else
				perblnan = 0;

			saldoawal = limit;
			rowgperiode = Convert.ToInt16(Math.Round(gperiode / blnan));

			//double temp = Math.Round(angspokok);
			double temp = angspokok;
			this.LBL_JUML_ANGSURAN.Text			= perblnan.ToString("#,###");
			this.LBL_BULAN_PER.Text				= blnan.ToString("#,###");			
			this.LBL_ANGSURAN_PER_PERIODE.Text	= temp.ToString("#,##0.00"); //temp.ToString("#,###");
			this.TXT_ANGSPOKOK.Text             = this.LBL_ANGSURAN_PER_PERIODE.Text;

			this.LBL_ROW.Text			= row.ToString();
			this.LBL_ROWGPERIODE.Text	= rowgperiode.ToString();
		}

		private void viewTable() 
		{
			double v_bunga, saldoawal, saldoakhir, sumbunga = 0;			
			string v_angspokok	= "";	

			int row				= Convert.ToInt16(this.LBL_ROW.Text);
			int rowgperiode		= Convert.ToInt16(this.LBL_ROWGPERIODE.Text);
			double bunga		= Convert.ToDouble(this.TXT_BUNGA.Text);					
			string[,] tabel = new string[row,5];

			saldoawal = Convert.ToDouble(this.TXT_LIMIT_KREDIT.Text);
			for (int i = 1; i <= row; i++) 
			{
				if (i <= rowgperiode)
					v_angspokok = "-";
				else
					v_angspokok = this.LBL_ANGSURAN_PER_PERIODE.Text;

				if (v_angspokok.Equals("-"))
					saldoakhir = saldoawal - 0;
				else
					saldoakhir = saldoawal - Convert.ToDouble(v_angspokok);

				v_bunga = saldoawal * ((bunga / 100) / 12);

				tabel[i-1,0] = i.ToString();
				tabel[i-1,1] = saldoawal.ToString("#,##0.00"); //tabel[i-1,1] = Math.Round(saldoawal).ToString("#,###") ;				
				tabel[i-1,2] = v_angspokok;
				tabel[i-1,3] = v_bunga.ToString("#,##0.00"); //tabel[i-1,3] = Math.Round(v_bunga).ToString("#,###");				
				tabel[i-1,4] = saldoakhir.ToString("#,##0.00"); //Math.Round(saldoakhir, 1).ToString("#,###");

				saldoawal	= saldoakhir;
				sumbunga	= v_bunga + sumbunga;
			}

			//------------- sementara pembuatan table dipisah codingnya ---------------------------------
			Table tbl = new Table();
			tbl.CellPadding = 0;
			tbl.CellSpacing = 0;
			for (int i = 1; i <= row; i++) 
			{
				TableRow tr = new TableRow();
				tr.Font.Name = this.LBL_ROW.Font.Name;

				TableCell td1 = new TableCell();				
				td1.Width = 40;
				td1.HorizontalAlign = HorizontalAlign.Right;				
				td1.Text = tabel[i-1,0];

				//--- Saldo Awal
				TableCell td2 = new TableCell();
				td2.Width = 180;
				td2.HorizontalAlign = HorizontalAlign.Right;
				td2.Text = tabel[i-1,1];

				//---- Angsuran Pokok
				TableCell td3 = new TableCell();
				td3.Width = 120;
				td3.HorizontalAlign = HorizontalAlign.Right;				
				td3.Text = tabel[i-1,2];

				//--- Bunga
				TableCell td4 = new TableCell();	
				td4.Width = 100;
				td4.HorizontalAlign = HorizontalAlign.Right;				
				td4.Text = tabel[i-1,3];

				//--- Saldo Akhir
				TableCell td5 = new TableCell();
				td5.Width = 120;
				td5.HorizontalAlign = HorizontalAlign.Right;
				td5.Text = tabel[i-1,4];

				tr.Cells.Add(td1);
				tr.Cells.Add(td2);
				tr.Cells.Add(td3);
				tr.Cells.Add(td4);
				tr.Cells.Add(td5);
				tr.BorderStyle = BorderStyle.Solid;				

				tbl.Rows.Add(tr);
			}

			this.PH_TABEL_ANGSURAN.Controls.Add(tbl);
			this.LBL_TOTAL_BUNGA.Text = Math.Round(sumbunga, 0).ToString("#,###"); //sumbunga.ToString();
			//-------------------------------------------------------------------------------------------
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			//this.LBL_ANGSURAN_PER_PERIODE.Text = this.TXT_ANGSPOKOK.Text;
			double temp;
			try 
			{
				temp = Convert.ToDouble(this.TXT_ANGSPOKOK.Text);
			} 
			catch (Exception) 
			{
				temp = 0;
			}
			//this.LBL_ANGSURAN_PER_PERIODE.Text = temp.ToString("#,###");
			this.LBL_ANGSURAN_PER_PERIODE.Text = tool.MoneyFormat(temp.ToString());
			this.viewTable();
			this.TXT_ANGSPOKOK.Text = tool.MoneyFormat(this.TXT_ANGSPOKOK.Text.ToString());
		}
	}
}
