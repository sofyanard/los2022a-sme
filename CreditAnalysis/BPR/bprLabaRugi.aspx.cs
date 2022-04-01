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
using Excel;
using System.Diagnostics;
using System.IO;


namespace SME.CreditAnalysis.BPR
{
	/// <summary>
	/// Summary description for bprNeraca.
	/// </summary>
	public partial class bprLabaRugi : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txt_B2;
		protected System.Web.UI.WebControls.TextBox txt_C2;
		protected System.Web.UI.WebControls.TextBox txt_D2;
		protected System.Web.UI.WebControls.TextBox txt_BB33;
		protected System.Web.UI.WebControls.DropDownList ddl_B3;
		protected System.Web.UI.WebControls.DropDownList ddl_C3;
		protected System.Web.UI.WebControls.DropDownList ddl_D3;
		protected System.Web.UI.WebControls.TextBox TXT_PSV_TOTAL1;

		protected Connection conn;
		protected Connection2 conn2;
		protected System.Web.UI.WebControls.DataGrid DG_NPLHistory;
		protected System.Web.UI.WebControls.DataGrid dg_NPL;
		//protected Tools tool = new Tools();
	
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			conn2 = new Connection2();
			
			if(!IsPostBack)
			{
				IsiTanggal();
				BindData("DG_LRHistory","EXEC BPR_BIND_LRHISTORY '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'");
				BindData("dg_LR", "EXEC BPR_BIND_LRCURRENT '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'");
			}	

			btn_Save.Attributes.Add("onclick","if(!cek_mandatory3(document.Form1)){return false;};");

			ViewMenu();
			ViewSubMenu();
		}

		private void retrieveData(string tahun)
		{
			/*Tes doang !*/
			string a = Request.QueryString["tahun"]; 
			string b = Request.QueryString["mode"];
			string c = Request.QueryString["regno"];
			string d = Request.QueryString["curef"];
			string k = Request.QueryString["mc"]; 
			string f = Request.QueryString["tc"];
			string g = Request.QueryString["jnsnasabah"];
			string h = Request.QueryString["programid"];
			string i = Request.QueryString["lmsreg"];
			string j = Request.QueryString["scr"];

			try
			{
				conn.QueryString = "SELECT TOP 2 DAY(POSISI_TGL) DDAY, MONTH(POSISI_TGL) DMONTH, YEAR(POSISI_TGL) DYEAR, * FROM CA_LABARUGI_BPR WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND POSISI_TGL <= '" + tahun + "' ORDER BY POSISI_TGL DESC";
				conn.ExecuteQuery();

				ViewData();
				CalculateTotal();
				CalculatePertumbuhan();
			}
			catch
			{
				Tools.popMessage(this, "Baris data neraca pada posisi tanggal ini adalah yang paling akhir ! Silahkan pilih posisi tanggal yang lebih awal !");
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
			this.DG_LRHistory.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_LRHistory_ItemCommand);
			this.dg_LR.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dg_LR_ItemCommand);

		}
		#endregion


		/// <summary>
		/// Menyimpan data neraca dari form input ke database
		/// </summary>
		private void SaveLabaRugi()
		{
			double LRL_PO_PENDAPATAN_BUNGA_DARI_BANK =	MyConnection.ConvertToDouble2(TXT_LRL_PO_PENDAPATAN_BUNGA_DARI_BANK1.Text.ToString().Replace(",","."));
			double LRL_PO_PENDAPATAN_BUNGA_DARI_PIHAK_KE3_BUKAN_BANK = MyConnection.ConvertToDouble2(TXT_LRL_PO_PENDAPATAN_BUNGA_DARI_PIHAK_KE3_BUKAN_BANK1.Text.ToString().Replace(",","."));
			double LRL_PO_PROVISI_DAN_KOMISI = MyConnection.ConvertToDouble2(TXT_LRL_PO_PROVISI_DAN_KOMISI1.Text.ToString().Replace(",","."));
			double LRL_PO_TOTAL = MyConnection.ConvertToDouble2(TXT_LRL_PO_TOTAL1.Text.ToString().Replace(",","."));
			double LRL_BO_BIAYA_BUNGA_KEPADA_BI = MyConnection.ConvertToDouble2(TXT_LRL_BO_BIAYA_BUNGA_KEPADA_BI1.Text.ToString().Replace(",","."));
			double LRL_BO_BIAYA_BUNGA_KEPADA_BANK_LAIN = MyConnection.ConvertToDouble2(TXT_LRL_BO_BIAYA_BUNGA_KEPADA_BANK_LAIN1.Text.ToString().Replace(",","."));
			double LRL_BO_BIAYA_BUNGA_KEPADA_PIHAK_KE3_BUKAN_BANK =	MyConnection.ConvertToDouble2(TXT_LRL_BO_BIAYA_BUNGA_KEPADA_PIHAK_KE3_BUKAN_BANK1.Text.ToString().Replace(",","."));
			double LRL_BO_TOTAL_BIAYA_OPERASIONAL = MyConnection.ConvertToDouble2(TXT_LRL_BO_TOTAL_BIAYA_OPERASIONAL1.Text.ToString().Replace(",","."));
			double LRL_BO_PENDAPATAN_OPERASIONAL_BERSIH = MyConnection.ConvertToDouble2(TXT_LRL_BO_PENDAPATAN_OPERASIONAL_BERSIH1.Text.ToString().Replace(",","."));
			double LRL_POL_PROVISI_DAN_KOMISI_DITERIMA_BUKAN_DARI_KREDIT = MyConnection.ConvertToDouble2(TXT_LRL_POL_PROVISI_DAN_KOMISI_DITERIMA_BUKAN_DARI_KREDIT1.Text.ToString().Replace(",","."));
			double LRL_POL_LAIN2 = MyConnection.ConvertToDouble2(TXT_LRL_POL_LAIN21.Text.ToString().Replace(",","."));
			double LRL_POL_TOTAL = MyConnection.ConvertToDouble2(TXT_LRL_POL_TOTAL1.Text.ToString().Replace(",","."));
			double LRL_BOL_BIAYA_UMUM_DAN_ADMINISTRASI = MyConnection.ConvertToDouble2(TXT_LRL_BOL_BIAYA_UMUM_DAN_ADMINISTRASI1.Text.ToString().Replace(",","."));
			double LRL_BOL_BIAYA_TENAGA_KERJA =	MyConnection.ConvertToDouble2(TXT_LRL_BOL_BIAYA_TENAGA_KERJA1.Text.ToString().Replace(",","."));
			double LRL_BOL_BIAYA_PEMELIHARAAN_DAN_PERBAIKAN = MyConnection.ConvertToDouble2(TXT_LRL_BOL_BIAYA_PEMELIHARAAN_DAN_PERBAIKAN1.Text.ToString().Replace(",","."));
			double LRL_BOL_BIAYA_PENYUSUTAN_PENGHAPUSAN_AKTIVA_PRODUKTIF = MyConnection.ConvertToDouble2(TXT_LRL_BOL_BIAYA_PENYUSUTAN_PENGHAPUSAN_AKTIVA_PRODUKTIF1.Text.ToString().Replace(",","."));
			double LRL_BOL_DEPRESIASI_DAN_AMORTISASI = MyConnection.ConvertToDouble2(TXT_LRL_BOL_DEPRESIASI_DAN_AMORTISASI1.Text.ToString().Replace(",","."));
			double LRL_BOL_LAIN2 = MyConnection.ConvertToDouble2(TXT_LRL_BOL_LAIN21.Text.ToString().Replace(",","."));
			double LRL_BOL_TOTAL = MyConnection.ConvertToDouble2(TXT_LRL_BOL_TOTAL1.Text.ToString().Replace(",","."));
			double LRL_POL_TOTAL_NET = MyConnection.ConvertToDouble2(TXT_LRL_POL_TOTAL_NET1.Text.ToString().Replace(",","."));
			double LRL_LABA_OPERASIONAL = MyConnection.ConvertToDouble2(TXT_LRL_LABA_OPERASIONAL1.Text.ToString().Replace(",","."));
			double LRL_PENDAPATAN_DAN_BIAYA_NON_OPERASIONAL_NET = MyConnection.ConvertToDouble2(TXT_LRL_PENDAPATAN_DAN_BIAYA_NON_OPERASIONAL_NET1.Text.ToString().Replace(",","."));
			double LRL_PENDAPATAN_SEBELUM_PAJAK_EBIT = MyConnection.ConvertToDouble2(TXT_LRL_PENDAPATAN_SEBELUM_PAJAK_EBIT1.Text.ToString().Replace(",","."));
			double LRL_PAJAK_PENGHASILAN = MyConnection.ConvertToDouble2(TXT_LRL_PAJAK_PENGHASILAN1.Text.ToString().Replace(",","."));
			double LRL_SALDO_KAS_AWAL =	MyConnection.ConvertToDouble2(TXT_LRL_SALDO_KAS_AWAL1.Text.ToString().Replace(",","."));
			double LRL_DIVIDEN = MyConnection.ConvertToDouble2(TXT_LRL_DIVIDEN1.Text.ToString().Replace(",","."));
			double LRL_PENDAPATAN_BERSIH_EAT = MyConnection.ConvertToDouble2(TXT_LRL_PENDAPATAN_BERSIH_EAT1.Text.ToString().Replace(",","."));
			double LRL_LABA_DITAHAN_PADA_AKHIR_TAHUN = MyConnection.ConvertToDouble2(TXT_LRL_LABA_DITAHAN_PADA_AKHIR_TAHUN1.Text.ToString().Replace(",","."));


			conn2.QueryString = "EXEC SP_BPR_LABARUGI 'Save','" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'," +
				GlobalTools.ToSQLDate(txt_DD_B1.Text.ToString(), ddl_MM_B1.SelectedValue.ToString(), txt_YY_B1.Text.ToString()) + "," +
				LRL_PO_PENDAPATAN_BUNGA_DARI_BANK.ToString().Replace(",",".") + "," +
				LRL_PO_PENDAPATAN_BUNGA_DARI_PIHAK_KE3_BUKAN_BANK.ToString().Replace(",",".") + "," +
				LRL_PO_PROVISI_DAN_KOMISI.ToString().Replace(",",".") + "," +
				LRL_PO_TOTAL.ToString().Replace(",",".") + "," +
				LRL_BO_BIAYA_BUNGA_KEPADA_BI.ToString().Replace(",",".") + "," +
				LRL_BO_BIAYA_BUNGA_KEPADA_BANK_LAIN.ToString().Replace(",",".") + "," +
				LRL_BO_BIAYA_BUNGA_KEPADA_PIHAK_KE3_BUKAN_BANK.ToString().Replace(",",".") + "," +
				LRL_BO_TOTAL_BIAYA_OPERASIONAL.ToString().Replace(",",".") + "," +
				LRL_BO_PENDAPATAN_OPERASIONAL_BERSIH.ToString().Replace(",",".") + "," +
				LRL_POL_PROVISI_DAN_KOMISI_DITERIMA_BUKAN_DARI_KREDIT.ToString().Replace(",",".") + "," +
				LRL_POL_LAIN2.ToString().Replace(",",".") + "," +
				LRL_POL_TOTAL.ToString().Replace(",",".") + "," +
				LRL_BOL_BIAYA_UMUM_DAN_ADMINISTRASI.ToString().Replace(",",".") + "," +
				LRL_BOL_BIAYA_TENAGA_KERJA.ToString().Replace(",",".") + "," +
				LRL_BOL_BIAYA_PEMELIHARAAN_DAN_PERBAIKAN.ToString().Replace(",",".") + "," +
				LRL_BOL_BIAYA_PENYUSUTAN_PENGHAPUSAN_AKTIVA_PRODUKTIF.ToString().Replace(",",".") + "," +
				LRL_BOL_DEPRESIASI_DAN_AMORTISASI.ToString().Replace(",",".") + "," +
				LRL_BOL_LAIN2.ToString().Replace(",",".") + "," +
				LRL_BOL_TOTAL.ToString().Replace(",",".") + "," +
				LRL_POL_TOTAL_NET.ToString().Replace(",",".") + "," +
				LRL_LABA_OPERASIONAL.ToString().Replace(",",".") + "," +
				LRL_PENDAPATAN_DAN_BIAYA_NON_OPERASIONAL_NET.ToString().Replace(",",".") + "," +
				LRL_PENDAPATAN_SEBELUM_PAJAK_EBIT.ToString().Replace(",",".") + "," +
				LRL_PAJAK_PENGHASILAN.ToString().Replace(",",".") + "," +
				LRL_SALDO_KAS_AWAL.ToString().Replace(",",".") + "," +
				LRL_DIVIDEN.ToString().Replace(",",".") + "," +
				LRL_PENDAPATAN_BERSIH_EAT.ToString().Replace(",",".") + "," +
				LRL_LABA_DITAHAN_PADA_AKHIR_TAHUN.ToString().Replace(",",".") + "," +
					int.Parse(TXT_JML_BLN1.Text.ToString().Replace(",00","")).ToString().Replace(",",".");
			conn2.ExecuteNonQuery();

			conn2.QueryString = "EXEC SP_BPR_LABARUGI 'Save','" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'," +
				GlobalTools.ToSQLDate(txt_DD_B2.Text.ToString(), ddl_MM_B2.SelectedValue.ToString(), txt_YY_B2.Text.ToString()) + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_PO_PENDAPATAN_BUNGA_DARI_BANK2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_PO_PENDAPATAN_BUNGA_DARI_PIHAK_KE3_BUKAN_BANK2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_PO_PROVISI_DAN_KOMISI2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_PO_TOTAL2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_BO_BIAYA_BUNGA_KEPADA_BI2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToFloat(TXT_LRL_BO_BIAYA_BUNGA_KEPADA_BANK_LAIN2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_BO_BIAYA_BUNGA_KEPADA_PIHAK_KE3_BUKAN_BANK2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_BO_TOTAL_BIAYA_OPERASIONAL2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_BO_PENDAPATAN_OPERASIONAL_BERSIH2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_POL_PROVISI_DAN_KOMISI_DITERIMA_BUKAN_DARI_KREDIT2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_POL_LAIN22.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_POL_TOTAL2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_BOL_BIAYA_UMUM_DAN_ADMINISTRASI2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_BOL_BIAYA_TENAGA_KERJA2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_BOL_BIAYA_PEMELIHARAAN_DAN_PERBAIKAN2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_BOL_BIAYA_PENYUSUTAN_PENGHAPUSAN_AKTIVA_PRODUKTIF2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_BOL_DEPRESIASI_DAN_AMORTISASI2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_BOL_LAIN22.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_BOL_TOTAL2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_POL_TOTAL_NET2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_LABA_OPERASIONAL2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_PENDAPATAN_DAN_BIAYA_NON_OPERASIONAL_NET2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_PENDAPATAN_SEBELUM_PAJAK_EBIT2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_PAJAK_PENGHASILAN2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_SALDO_KAS_AWAL2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_DIVIDEN2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_PENDAPATAN_BERSIH_EAT2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_LRL_LABA_DITAHAN_PADA_AKHIR_TAHUN2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				int.Parse(TXT_JML_BLN2.Text.ToString().Replace(",00","")).ToString();
			conn2.ExecuteNonQuery();
		}

		private void ViewData()
		{
			conn2.QueryString = "SELECT SYSCOLUMNS.[name] FROM SYSOBJECTS, SYSCOLUMNS WHERE SYSOBJECTS.[name] = 'CA_LABARUGI_BPR' AND SYSCOLUMNS.[ID] = SYSOBJECTS.[ID] AND SYSCOLUMNS.[name] not in ('CU_REF','AP_REGNO','SEQ')";
			conn2.ExecuteQuery();

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
	
				if(conn2.GetFieldValue(i,"name") != "POSISI_TGL" && conn2.GetFieldValue(i,"name") != "DDAY" && conn2.GetFieldValue(i,"name") != "DMONTH" && conn2.GetFieldValue(i,"name") != "DYEAR")
				{
					System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "1");
					System.Web.UI.WebControls.TextBox txt2 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "2");
				

					string namatabel = conn2.GetFieldValue(i,"name").ToString();

					txt1.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(1,conn2.GetFieldValue(i,"name")));
					txt2.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,conn2.GetFieldValue(i,"name")));
				}
				else
				{
					string namatabel = conn2.GetFieldValue(i,"name").ToString();

					System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "1");
					System.Web.UI.WebControls.TextBox txt2 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "2");
				
					//GlobalTools.ToSQLDate(txt_DD_B1.Text, ddl_MM_B1.SelectedValue, txt_YY_B1.Text) 

					txt_DD_B1.Text = conn.GetFieldValue(1,"DDAY");
					txt_DD_B2.Text = conn.GetFieldValue(0,"DDAY");

					ddl_MM_B1.SelectedValue = conn.GetFieldValue(1,"DMONTH");
					ddl_MM_B2.SelectedValue = conn.GetFieldValue(0,"DMONTH");

					txt_YY_B1.Text = conn.GetFieldValue(1,"DYEAR");
					txt_YY_B2.Text = conn.GetFieldValue(0,"DYEAR");
				}
			}
		}


		/// <summary>
		/// Memeriksa validitas tanggal dari form input
		/// </summary>
		/// <returns></returns>
		private bool cekTanggal()
		{
			if (txt_DD_B1.Text != "" && ddl_MM_B1.SelectedIndex > 0 && txt_YY_B1.Text != "")
				if(!GlobalTools.isDateValid(this,txt_DD_B1.Text,ddl_MM_B1.SelectedValue,txt_YY_B1.Text))
				{
					GlobalTools.popMessage(this, "Data/Number of Months tidak valid!");
					return false;
				}
			
			if (txt_DD_B2.Text != "" && ddl_MM_B2.SelectedIndex > 0 && txt_YY_B2.Text != "")
				if(!GlobalTools.isDateValid(this,txt_DD_B2.Text,ddl_MM_B2.SelectedValue,txt_YY_B2.Text))
				{
					GlobalTools.popMessage(this, "Data/Number of Months tidak valid!");
					return false;
				}

			return true;
		}

		private void CalculatePertumbuhan()
		{
			conn2.QueryString = "SELECT SYSCOLUMNS.[name] FROM SYSOBJECTS, SYSCOLUMNS WHERE SYSOBJECTS.[name] = 'CA_LABARUGI_BPR' AND SYSCOLUMNS.[ID] = SYSOBJECTS.[ID] AND SYSCOLUMNS.[name] not in ('CU_REF','AP_REGNO','SEQ','POSISI_TGL','JML_BLN')";
			conn2.ExecuteQuery();
			double pertumbuhan;

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "1");
				System.Web.UI.WebControls.TextBox txt2 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "2");
				System.Web.UI.WebControls.TextBox txt3 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "3");

				/*double a = MyConnection.ConvertToDouble2(txt1.Text);
				double b = MyConnection.ConvertToDouble2(txt2.Text);*/

				string id1 = txt1.ID;
				string id2 = txt2.ID;
				string id3 = txt3.ID;

				if(MyConnection.ConvertToDouble2(txt1.Text.Replace(",",".")) > 0.00 || MyConnection.ConvertToDouble2(txt1.Text.Replace(",",".")) < 0.00)
				{
					pertumbuhan = (MyConnection.ConvertToDouble2(txt2.Text.Replace(",",".")) - MyConnection.ConvertToDouble2(txt1.Text.Replace(",","."))) / MyConnection.ConvertToDouble2(txt1.Text.Replace(",",".")) * 100;
				}
				else
				{
					if(MyConnection.ConvertToDouble2(txt2.Text.Replace(",",".")) > 0.00 || MyConnection.ConvertToDouble2(txt2.Text.Replace(",",".")) < 0.00)
					{
						pertumbuhan = (MyConnection.ConvertToDouble2(txt2.Text.Replace(",",".")) / 1.00) * 100;
					}
					else
					{
						pertumbuhan = 0.0;
					}
				}
				txt3.Text = GlobalTools.MoneyFormat(pertumbuhan.ToString()) + "%";
			}
		}

		private void CalculateTotal()
		{
			double TPO1 = 0.0;
			double TPO2 = 0.0;

			TPO1 = MyConnection.ConvertToDouble2(TXT_LRL_PO_PENDAPATAN_BUNGA_DARI_BANK1.Text.ToString().Replace(",",".")) + 
				MyConnection.ConvertToDouble2(TXT_LRL_PO_PENDAPATAN_BUNGA_DARI_PIHAK_KE3_BUKAN_BANK1.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_PO_PROVISI_DAN_KOMISI1.Text.ToString().Replace(",","."));

			TPO2 = MyConnection.ConvertToDouble2(TXT_LRL_PO_PENDAPATAN_BUNGA_DARI_BANK2.Text.ToString().Replace(",",".")) + 
				MyConnection.ConvertToDouble2(TXT_LRL_PO_PENDAPATAN_BUNGA_DARI_PIHAK_KE3_BUKAN_BANK2.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_PO_PROVISI_DAN_KOMISI2.Text.ToString().Replace(",","."));

			TXT_LRL_PO_TOTAL1.Text = GlobalTools.MoneyFormat(TPO1.ToString());
			TXT_LRL_PO_TOTAL2.Text = GlobalTools.MoneyFormat(TPO2.ToString());

			//--------------------------------------------------------------------------------------//
		
			double TBO1 = 0.0;
			double TBO2 = 0.0;

			TBO1 = MyConnection.ConvertToDouble2(TXT_LRL_BO_BIAYA_BUNGA_KEPADA_BI1.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_BO_BIAYA_BUNGA_KEPADA_BANK_LAIN1.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_BO_BIAYA_BUNGA_KEPADA_PIHAK_KE3_BUKAN_BANK1.Text.ToString().Replace(",","."));

			TBO2 = MyConnection.ConvertToDouble2(TXT_LRL_BO_BIAYA_BUNGA_KEPADA_BI2.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_BO_BIAYA_BUNGA_KEPADA_BANK_LAIN2.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_BO_BIAYA_BUNGA_KEPADA_PIHAK_KE3_BUKAN_BANK2.Text.ToString().Replace(",","."));
		
			TXT_LRL_BO_TOTAL_BIAYA_OPERASIONAL1.Text = GlobalTools.MoneyFormat(TBO1.ToString());
			TXT_LRL_BO_TOTAL_BIAYA_OPERASIONAL2.Text = GlobalTools.MoneyFormat(TBO2.ToString());

			TXT_LRL_BO_PENDAPATAN_OPERASIONAL_BERSIH1.Text = GlobalTools.MoneyFormat((TPO1 - TBO1).ToString());
			TXT_LRL_BO_PENDAPATAN_OPERASIONAL_BERSIH2.Text = GlobalTools.MoneyFormat((TPO2 - TBO2).ToString());

			//----------------------------------------------------------------------------------------//

			double TPOL1 = 0.0;
			double TPOL2 = 0.0;

			TPOL1 = MyConnection.ConvertToDouble2(TXT_LRL_POL_PROVISI_DAN_KOMISI_DITERIMA_BUKAN_DARI_KREDIT1.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_POL_LAIN21.Text.ToString().Replace(",","."));

			TPOL2 = MyConnection.ConvertToDouble2(TXT_LRL_POL_PROVISI_DAN_KOMISI_DITERIMA_BUKAN_DARI_KREDIT2.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_POL_LAIN22.Text.ToString().Replace(",","."));

			TXT_LRL_POL_TOTAL1.Text = GlobalTools.MoneyFormat(TPOL1.ToString());
			TXT_LRL_POL_TOTAL2.Text = GlobalTools.MoneyFormat(TPOL2.ToString());

			//-------------------------------------------------------------------------------------------//

			double TBOL1 = 0.0;
			double TBOL2 = 0.0;

			TBOL1 = MyConnection.ConvertToDouble2(TXT_LRL_BOL_BIAYA_UMUM_DAN_ADMINISTRASI1.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_BOL_BIAYA_TENAGA_KERJA1.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_BOL_BIAYA_PEMELIHARAAN_DAN_PERBAIKAN1.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_BOL_BIAYA_PENYUSUTAN_PENGHAPUSAN_AKTIVA_PRODUKTIF1.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_BOL_DEPRESIASI_DAN_AMORTISASI1.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_BOL_LAIN21.Text.ToString().Replace(",","."));

			TBOL2 = MyConnection.ConvertToDouble2(TXT_LRL_BOL_BIAYA_UMUM_DAN_ADMINISTRASI2.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_BOL_BIAYA_TENAGA_KERJA2.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_BOL_BIAYA_PEMELIHARAAN_DAN_PERBAIKAN2.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_BOL_BIAYA_PENYUSUTAN_PENGHAPUSAN_AKTIVA_PRODUKTIF2.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_BOL_DEPRESIASI_DAN_AMORTISASI2.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_BOL_LAIN22.Text.ToString().Replace(",","."));

			TXT_LRL_BOL_TOTAL1.Text = GlobalTools.MoneyFormat(TBOL1.ToString());
			TXT_LRL_BOL_TOTAL2.Text = GlobalTools.MoneyFormat(TBOL2.ToString());

			//----------------------------------------------------------------------------------------------//

			TXT_LRL_POL_TOTAL_NET1.Text = GlobalTools.MoneyFormat(((double)(TPOL1 - TBOL1)).ToString());
			TXT_LRL_POL_TOTAL_NET2.Text = GlobalTools.MoneyFormat(((double)(TPOL2 - TBOL2)).ToString());

			TXT_LRL_LABA_OPERASIONAL1.Text = GlobalTools.MoneyFormat(((double)(MyConnection.ConvertToDouble2(TXT_LRL_BO_PENDAPATAN_OPERASIONAL_BERSIH1.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_POL_TOTAL_NET1.Text.Replace(",",".")))).ToString());

			TXT_LRL_LABA_OPERASIONAL2.Text = GlobalTools.MoneyFormat(((double)(MyConnection.ConvertToDouble2(TXT_LRL_BO_PENDAPATAN_OPERASIONAL_BERSIH2.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_POL_TOTAL_NET2.Text.Replace(",",".")))).ToString());

			TXT_LRL_PENDAPATAN_SEBELUM_PAJAK_EBIT1.Text = GlobalTools.MoneyFormat(((double)(MyConnection.ConvertToDouble2(TXT_LRL_PENDAPATAN_DAN_BIAYA_NON_OPERASIONAL_NET1.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_LABA_OPERASIONAL1.Text.ToString().Replace(",",".")))).ToString());
			
			TXT_LRL_PENDAPATAN_SEBELUM_PAJAK_EBIT2.Text = GlobalTools.MoneyFormat(((double)(MyConnection.ConvertToDouble2(TXT_LRL_PENDAPATAN_DAN_BIAYA_NON_OPERASIONAL_NET2.Text.ToString().Replace(",",".")) +
				MyConnection.ConvertToDouble2(TXT_LRL_LABA_OPERASIONAL2.Text.ToString().Replace(",",".")))).ToString());

			TXT_LRL_PENDAPATAN_BERSIH_EAT1.Text = GlobalTools.MoneyFormat(((double)(MyConnection.ConvertToDouble2(TXT_LRL_PENDAPATAN_SEBELUM_PAJAK_EBIT1.Text.ToString().Replace(",",".")) -
				MyConnection.ConvertToDouble2(TXT_LRL_PAJAK_PENGHASILAN1.Text.ToString().Replace(",",".")))).ToString());

			TXT_LRL_PENDAPATAN_BERSIH_EAT2.Text = GlobalTools.MoneyFormat(((double)(MyConnection.ConvertToDouble2(TXT_LRL_PENDAPATAN_SEBELUM_PAJAK_EBIT2.Text.ToString().Replace(",",".")) -
				MyConnection.ConvertToDouble2(TXT_LRL_PAJAK_PENGHASILAN2.Text.ToString().Replace(",",".")))).ToString());

			TXT_LRL_LABA_DITAHAN_PADA_AKHIR_TAHUN1.Text = GlobalTools.MoneyFormat(((double)(MyConnection.ConvertToDouble2(TXT_LRL_PENDAPATAN_BERSIH_EAT1.Text.ToString().Replace(",",".")) + 
				MyConnection.ConvertToDouble2(TXT_LRL_SALDO_KAS_AWAL1.Text.ToString().Replace(",",".")) -
				MyConnection.ConvertToDouble2(TXT_LRL_DIVIDEN1.Text.ToString().Replace(",",".")))).ToString());

			TXT_LRL_LABA_DITAHAN_PADA_AKHIR_TAHUN2.Text = GlobalTools.MoneyFormat(((double)(MyConnection.ConvertToDouble2(TXT_LRL_PENDAPATAN_BERSIH_EAT2.Text.ToString().Replace(",",".")) + 
				MyConnection.ConvertToDouble2(TXT_LRL_SALDO_KAS_AWAL2.Text.ToString().Replace(",",".")) -
				MyConnection.ConvertToDouble2(TXT_LRL_DIVIDEN2.Text.ToString().Replace(",",".")))).ToString());
		}

		protected void btn_Save_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!cekTanggal())
					return;

				CalculateTotal();
				CalculatePertumbuhan();
				SaveLabaRugi();
				BindData("dg_LR", "EXEC BPR_BIND_LRCURRENT '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'");
				Tools.popMessage(this,"Data has been saved !");
			}
			catch
			{
				Tools.popMessage(this, "Data mandatory (field merah) tidak terisi lengkap !");
			}

		}


		/// <summary>
		/// Mengisi dropdown tanggal
		/// </summary>
		private void IsiTanggal()
		{
			GlobalTools.initDateFormINA(txt_DD_B1, ddl_MM_B1, txt_YY_B1, true);
			GlobalTools.initDateFormINA(txt_DD_B2, ddl_MM_B2, txt_YY_B2, true);
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink("",Request.QueryString["mc"].ToString(), conn));
		}

		private void secureData() 
		{
			if (Request.QueryString["ca"]=="0") 
			{
				int kk = 0, index = -1;
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for (kk = 0; kk < coll.Count; kk++) 
				{
					if (coll[kk] is System.Web.UI.HtmlControls.HtmlForm) 
					{
						index = kk;
						break;
					}
				}

				if (index == -1) return;
				if (kk == coll.Count) return;

				for (int i = 0; i < coll[index].Controls.Count; i++) 
				{
					if (coll[index].Controls[i] is System.Web.UI.WebControls.TextBox) 
					{
						System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) coll[index].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[index].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[index].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[index].Controls[i] is System.Web.UI.WebControls.Button)
					{
						System.Web.UI.WebControls.Button btn = (System.Web.UI.WebControls.Button) coll[index].Controls[i];
						btn.Visible = false;
					}
					else if (coll[index].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[index].Controls[i];

						for (int j=0; j < htr.Controls.Count; j++) 
						{							
							for (int jj = 0; jj < htr.Controls[j].Controls.Count; jj++) 
							{
								if (htr.Controls[j].Controls[jj] is System.Web.UI.WebControls.TextBox) 
								{
									System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) htr.Controls[j].Controls[jj];
									txt.ReadOnly = true;
								}
								else if (htr.Controls[j].Controls[jj] is DropDownList) 
								{
									DropDownList ddl = (DropDownList) htr.Controls[j].Controls[jj];
									ddl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is System.Web.UI.WebControls.Button)
								{
									System.Web.UI.WebControls.Button btn = (System.Web.UI.WebControls.Button) htr.Controls[j].Controls[jj];
									btn.Visible = false;
								}
							}
						}
					}
				}
			}
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);

			dg.DataSource = dt;				

			try
			{
				dg.DataBind();
			}
			catch 
			{
				dg.CurrentPageIndex = dg.PageCount - 1;
				dg.DataBind();
			}

			conn.ClearData();
		}

		private void clearData()
		{
			conn2.QueryString = "SELECT SYSCOLUMNS.[name] FROM SYSOBJECTS, SYSCOLUMNS WHERE SYSOBJECTS.[name] = 'CA_LABARUGI_BPR' AND SYSCOLUMNS.[ID] = SYSOBJECTS.[ID] AND SYSCOLUMNS.[name] not in ('CU_REF','AP_REGNO','SEQ')";
			conn2.ExecuteQuery();

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue("name") + "1");
				System.Web.UI.WebControls.TextBox txt2 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue("name") + "2");
				System.Web.UI.WebControls.TextBox txt3 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue("name") + "3");

				if(conn2.GetFieldValue("name") != "POSISI_TGL" || conn2.GetFieldValue("name") != "DDAY" || conn2.GetFieldValue("name") != "DMONTH" || conn2.GetFieldValue("name") != "DYEAR")
				{
					txt1.Text = "";
					txt2.Text = "";

					if(txt3 != null)
					{
						txt3.Text = "";
					}
				}
				else
				{
					//GlobalTools.ToSQLDate(txt_DD_B1.Text, ddl_MM_B1.SelectedValue, txt_YY_B1.Text) 
					if(conn2.GetFieldValue("name") == "DDAY")
					{
						txt_DD_B1.Text = "";
						txt_DD_B2.Text = "";
					}
					else if(conn2.GetFieldValue("name") == "DMONTH")
					{
						ddl_MM_B1.SelectedValue = conn.GetFieldValue(0,conn2.GetFieldValue("DMONTH"));
						ddl_MM_B2.SelectedValue = conn.GetFieldValue(1,conn2.GetFieldValue("DMONTH"));
					}
					else if(conn2.GetFieldValue("name") == "DYEAR")
					{
						txt_YY_B1.Text = "";
						txt_YY_B2.Text = "";
					}
				}
			}
		}


		private void retrieve_data(string tahun, string regno)
		{
			string curef = Request.QueryString["curef"];

			//conn.QueryString = "EXEC BPR_GETLABARUGI '" + curef + "','" + regno + "','" + tahun + "'";
			//conn.ExecuteQuery();

			conn.QueryString = "SELECT TOP 2 DAY(POSISI_TGL) DDAY, MONTH(POSISI_TGL) DMONTH, YEAR(POSISI_TGL) DYEAR, * FROM CA_LABARUGI_BPR WHERE AP_REGNO = '" + regno + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND POSISI_TGL <= '" + tahun + "' ORDER BY POSISI_TGL DESC";
			conn.ExecuteQuery();

			ViewData();
			CalculateTotal();
			CalculatePertumbuhan();
		}

		private void dg_LR_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;
			switch (cmd)
			{		  
				case "retrieve"	:
					//Response.Redirect("bprLabaRugi.aspx?tahun=" + e.Item.Cells[1].Text +"&mode=retrieve&regno="+Request.QueryString["regno"]+"&curef="+Request.QueryString["curef"]+ "&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]);
					try
					{
						retrieveData(e.Item.Cells[1].Text);
					}
					catch
					{
						Tools.popMessage(this, "Baris data neraca pada posisi tanggal ini adalah yang paling akhir ! Silahkan pilih posisi tanggal yang lebih awal !");
					}
					//clearData();
					//retrieve_data();
					break;
				case "delete"	:
					conn.QueryString = "EXEC BPR_DEL_LABARUGI '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "','" + e.Item.Cells[1].Text + "'";
					conn.ExecuteQuery();
					BindData("dg_LR", "EXEC BPR_BIND_LRCURRENT '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'");
					break;
			}
		}

		private void DG_LRHistory_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;
			switch (cmd)
			{		  
				case "retrieve_history"	:
					//Response.Redirect("bprLabaRugi.aspx?tahun=" + e.Item.Cells[1].Text +"&mode=retrieve&regno="+Request.QueryString["regno"]+"&curef="+Request.QueryString["curef"]+ "&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]);
					//clearData();
					try
					{
						retrieve_data(e.Item.Cells[1].Text, e.Item.Cells[0].Text);
					}
					catch
					{
						Tools.popMessage(this, "Baris data neraca pada posisi tanggal ini adalah yang paling akhir ! Silahkan pilih posisi tanggal yang lebih awal !");
					}
					break;
				case "delete"	:
					conn.QueryString = "EXEC BPR_DEL_LABARUGI '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "','" + e.Item.Cells[1].Text + "'";
					BindData("DG_LRHistory", "EXEC BPR_BIND_LRHISTORY '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'");
					break;
			}
		}
	
		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select SM_ID,MENUCODE,SM_MENUDISPLAY,SM_LINKNAME from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						else	
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = "../" + conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}
		
	
		private void ViewSubMenu()
		{
			try 
			{
				string sProgramID,sJnsNasabah;

				conn.QueryString = "select distinct top 1 cu_jnsnasabah from customer where cu_ref in (Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+ "')";
				conn.ExecuteQuery();
				sJnsNasabah = conn.GetFieldValue("cu_jnsnasabah").ToString();
				//------------------------------------------------------------------------------
					
				conn.QueryString = "select distinct top 1 programid from rfprogram where programid in (select prog_code from application where ap_regno = '"+Request.QueryString["regno"]+ "')";
				conn.ExecuteQuery();
				sProgramID = conn.GetFieldValue("programid").ToString();

				//conn.QueryString = "select * from screensubmenu where lg_code in (select distinct lg_code from rfcafinstatement where programid = '"+Request.QueryString["programid"]+"' and nasabahid = '" +Request.QueryString["jnsnasabah"]+"') and menucode = '" +Request.QueryString["mc"]+ "' and programid = '"+Request.QueryString["programid"]+"'";

				conn.QueryString = "select MENUCODE,BUSSUNITID,PROGRAMID,PROGRAMID_SEQ,SM_MENUDISPLAY,SM_LINKNAME,LG_CODE from screensubmenu where lg_code in (select distinct lg_code from rfcafinstatement where programid = '" + sProgramID + "' and nasabahid = '" + sJnsNasabah + "') and menucode = '" + Request.QueryString["mc"]+ "' and programid = '" + sProgramID + "'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 4);
					string strtemp = "";
					strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&tc="+Request.QueryString["tc"]+"&tahun="+Request.QueryString["tahun"]+"&mode="+Request.QueryString["mode"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
					t.NavigateUrl = conn.GetFieldValue(i, 5)+strtemp;
					SubMenu.Controls.Add(t);
					SubMenu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}
	}
}