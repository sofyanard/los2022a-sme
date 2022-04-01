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
	public partial class bprNeraca : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txt_B2;
		protected System.Web.UI.WebControls.TextBox txt_C2;
		protected System.Web.UI.WebControls.TextBox txt_D2;
		protected System.Web.UI.WebControls.TextBox txt_BB33;
		protected System.Web.UI.WebControls.DropDownList ddl_B3;
		protected System.Web.UI.WebControls.DropDownList ddl_C3;
		protected System.Web.UI.WebControls.DropDownList ddl_D3;
		protected System.Web.UI.WebControls.TextBox txt_B31;
		protected System.Web.UI.WebControls.TextBox txt_B32;
		protected System.Web.UI.WebControls.TextBox txt_B33;
		protected System.Web.UI.WebControls.TextBox txt_B34;
		protected System.Web.UI.WebControls.TextBox txt_B35;
		protected System.Web.UI.WebControls.TextBox txt_B36;
		protected System.Web.UI.WebControls.TextBox txt_B37;
		protected System.Web.UI.WebControls.TextBox txt_B38;
		protected System.Web.UI.WebControls.TextBox txt_B39;
		protected System.Web.UI.WebControls.TextBox txt_B40;
		protected System.Web.UI.WebControls.TextBox txt_B41;
		protected System.Web.UI.WebControls.TextBox txt_B42;
		protected System.Web.UI.WebControls.TextBox txt_B43;
		protected System.Web.UI.WebControls.TextBox txt_B45;
		protected System.Web.UI.WebControls.TextBox txt_B46;
		protected System.Web.UI.WebControls.TextBox txt_B47;
		protected System.Web.UI.WebControls.TextBox txt_B48;
		protected System.Web.UI.WebControls.TextBox txt_B49;
		protected System.Web.UI.WebControls.TextBox txt_B50;
		protected System.Web.UI.WebControls.TextBox txt_B51;
		protected System.Web.UI.WebControls.TextBox txt_B52;
		protected System.Web.UI.WebControls.TextBox txt_B53;
		protected System.Web.UI.WebControls.TextBox txt_B54;
		protected System.Web.UI.WebControls.TextBox txt_B55;
		protected System.Web.UI.WebControls.TextBox txt_B56;
		protected System.Web.UI.WebControls.TextBox txt_B57;
		protected System.Web.UI.WebControls.TextBox txt_B58;
		protected System.Web.UI.WebControls.TextBox txt_B59;
		protected System.Web.UI.WebControls.TextBox txt_B60;
		protected System.Web.UI.WebControls.TextBox txt_C31;
		protected System.Web.UI.WebControls.TextBox txt_C32;
		protected System.Web.UI.WebControls.TextBox txt_C33;
		protected System.Web.UI.WebControls.TextBox txt_C34;
		protected System.Web.UI.WebControls.TextBox txt_C35;
		protected System.Web.UI.WebControls.TextBox txt_C36;
		protected System.Web.UI.WebControls.TextBox txt_C37;
		protected System.Web.UI.WebControls.TextBox txt_C38;
		protected System.Web.UI.WebControls.TextBox txt_C39;
		protected System.Web.UI.WebControls.TextBox txt_C40;
		protected System.Web.UI.WebControls.TextBox txt_C41;
		protected System.Web.UI.WebControls.TextBox txt_C42;
		protected System.Web.UI.WebControls.TextBox txt_C43;
		protected System.Web.UI.WebControls.TextBox txt_C44;
		protected System.Web.UI.WebControls.TextBox txt_C45;
		protected System.Web.UI.WebControls.TextBox txt_C46;
		protected System.Web.UI.WebControls.TextBox txt_C47;
		protected System.Web.UI.WebControls.TextBox txt_C48;
		protected System.Web.UI.WebControls.TextBox txt_C49;
		protected System.Web.UI.WebControls.TextBox txt_C50;
		protected System.Web.UI.WebControls.TextBox txt_C51;
		protected System.Web.UI.WebControls.TextBox txt_C52;
		protected System.Web.UI.WebControls.TextBox txt_C53;
		protected System.Web.UI.WebControls.TextBox txt_C54;
		protected System.Web.UI.WebControls.TextBox txt_C55;
		protected System.Web.UI.WebControls.TextBox txt_C56;
		protected System.Web.UI.WebControls.TextBox txt_C57;
		protected System.Web.UI.WebControls.TextBox txt_C58;
		protected System.Web.UI.WebControls.TextBox txt_C59;
		protected System.Web.UI.WebControls.TextBox txt_C60;
		protected System.Web.UI.WebControls.TextBox txt_D31;
		protected System.Web.UI.WebControls.TextBox txt_D32;
		protected System.Web.UI.WebControls.TextBox txt_D33;
		protected System.Web.UI.WebControls.TextBox txt_D34;
		protected System.Web.UI.WebControls.TextBox txt_D35;
		protected System.Web.UI.WebControls.TextBox txt_D36;
		protected System.Web.UI.WebControls.TextBox txt_D37;
		protected System.Web.UI.WebControls.TextBox txt_D38;
		protected System.Web.UI.WebControls.TextBox txt_D39;
		protected System.Web.UI.WebControls.TextBox txt_D40;
		protected System.Web.UI.WebControls.TextBox txt_D41;
		protected System.Web.UI.WebControls.TextBox txt_D42;
		protected System.Web.UI.WebControls.TextBox txt_D43;
		protected System.Web.UI.WebControls.TextBox txt_D44;
		protected System.Web.UI.WebControls.TextBox txt_D45;
		protected System.Web.UI.WebControls.TextBox txt_D46;
		protected System.Web.UI.WebControls.TextBox txt_D47;
		protected System.Web.UI.WebControls.TextBox txt_D48;
		protected System.Web.UI.WebControls.TextBox txt_D49;
		protected System.Web.UI.WebControls.TextBox txt_D50;
		protected System.Web.UI.WebControls.TextBox txt_D51;
		protected System.Web.UI.WebControls.TextBox txt_D52;
		protected System.Web.UI.WebControls.TextBox txt_D53;
		protected System.Web.UI.WebControls.TextBox txt_D54;
		protected System.Web.UI.WebControls.TextBox txt_D55;
		protected System.Web.UI.WebControls.TextBox txt_D56;
		protected System.Web.UI.WebControls.TextBox txt_D57;
		protected System.Web.UI.WebControls.TextBox txt_D58;
		protected System.Web.UI.WebControls.TextBox txt_D59;
		protected System.Web.UI.WebControls.TextBox txt_D60;
		protected System.Web.UI.WebControls.TextBox txt_B29;
		protected System.Web.UI.WebControls.TextBox txt_B30;
		protected System.Web.UI.WebControls.TextBox txt_C29;
		protected System.Web.UI.WebControls.TextBox txt_C30;
		protected System.Web.UI.WebControls.TextBox txt_D29;
		protected System.Web.UI.WebControls.TextBox txt_D30;
		protected System.Web.UI.WebControls.TextBox txt_B44;
		private double totalAktiva;
		private double totalPasiva;

		protected Connection conn;
		protected Connection2 conn2;
		//protected Tools tool = new Tools();
	
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			conn2 = new Connection2();
			
			if(!IsPostBack)
			{
				IsiTanggal();
				BindData("dg_Neraca","EXEC BPR_BIND_NERACACURRENT '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'");
				BindData("DG_NeracaHistory", "EXEC BPR_BIND_NERACAHISTORY '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'");
			}	

			btn_Save.Attributes.Add("onclick","if(!cek_mandatory3(document.Form1)){return false;};");
			btnCalculateRatio.Visible = false;

			ViewMenu();
			ViewSubMenu();
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
			this.DG_NeracaHistory.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_NeracaHistory_ItemCommand);
			this.dg_Neraca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dg_Neraca_ItemCommand);

		}
		#endregion


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
				conn.QueryString = "SELECT TOP 2 DAY(POSISI_TGL) DDAY, MONTH(POSISI_TGL) DMONTH, YEAR(POSISI_TGL) DYEAR, * FROM CA_NERACA_BPR WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND POSISI_TGL <= '" + tahun + "' ORDER BY POSISI_TGL DESC";
				conn.ExecuteQuery();

				ViewData();
				CalculateTotalAktiva();
				CalculateTotalPasiva();
				CalculatePertumbuhan();
			}
			catch
			{
				Tools.popMessage(this, "Baris data neraca pada posisi tanggal ini adalah yang paling akhir ! Silahkan pilih posisi tanggal yang lebih awal !");
			}
		}

		/// <summary>
		/// Menyimpan data neraca dari form input ke database
		/// </summary>
		private void SaveNeraca()
		{
			double a = MyConnection.ConvertToDouble2(TXT_AKTV_SBI2.Text.ToString().Replace(",","."));

			conn.QueryString = "EXEC SP_BPR_NERACA 'Save','" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'," +
				GlobalTools.ToSQLDate(txt_DD_B1.Text, ddl_MM_B1.SelectedValue, txt_YY_B1.Text) + "," +
				int.Parse(TXT_JML_BLN1.Text.Replace(",00","")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_KAS1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_SBI1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_ANTAR_BANK_AKTIVA1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_KREDIT_YANG_DIBERIKAN1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_PPAP1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_AKTIVA_TETAP_DAN_INVENTARIS1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_ANTAR_KANTOR_AKTIVA1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_RUPA2_AKTVIVA1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_KEWAJIBAN_YANG_SEGERA_DAPAT_DIBAYAR1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_TABUNGAN1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_DEPOSITO_BERJANGKA1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_BI_KMK1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_ANTAR_BANK_PASSIVA1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_PINJAMAN_SUBORDINASI1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_PINJAMAN_LAINNYA_LB3BULAN1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_ANTAR_KANTOR_PASSIVA1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_RUPA2_PASIVA1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_MODAL_DISETOR1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_MODAL_PINJAMAN_SUMBANGAN1.Text.ToString().Replace(",",".")).ToString().Replace(",",".")  + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_CADANGAN1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_LABA_THN_BERJALAN1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_TOTAL1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_TOTAL1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_LABA_DITAHAN1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_ANTAR_BANK_AKTIVA_GIRO1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_ANTAR_BANK_AKTIVA_TABUNGAN1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_ANTAR_BANK_AKTIVA_LAINNYA1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_ANTAR_BANK_PASSIVA_PINJAMAN1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_ANTAR_BANK_PASSIVA_DEPOSITO_LEBIH_3BULAN1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_ANTAR_BANK_PASSIVA_DEPOSITO_SD_3BULAN1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_ANTAR_BANK_PASSIVA_TABUNGAN1.Text.ToString().Replace(",",".")).ToString().Replace(",",".");

			conn.ExecuteNonQuery();

			conn.QueryString = "SP_BPR_NERACA 'Save','" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'," +
				GlobalTools.ToSQLDate(txt_DD_B2.Text, ddl_MM_B2.SelectedValue, txt_YY_B2.Text) + "," +
				int.Parse(TXT_JML_BLN2.Text.Replace(",00","")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_KAS2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_SBI2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_ANTAR_BANK_AKTIVA2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_KREDIT_YANG_DIBERIKAN2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_PPAP2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_AKTIVA_TETAP_DAN_INVENTARIS2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_ANTAR_KANTOR_AKTIVA2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_RUPA2_AKTVIVA2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_KEWAJIBAN_YANG_SEGERA_DAPAT_DIBAYAR2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_TABUNGAN2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_DEPOSITO_BERJANGKA2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_BI_KMK2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_ANTAR_BANK_PASSIVA2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_PINJAMAN_SUBORDINASI2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_PINJAMAN_LAINNYA_LB3BULAN2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_ANTAR_KANTOR_PASSIVA2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_RUPA2_PASIVA2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_MODAL_DISETOR2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_MODAL_PINJAMAN_SUMBANGAN2.Text.ToString().Replace(",",".")).ToString().Replace(",",".")  + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_CADANGAN2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_LABA_THN_BERJALAN2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_TOTAL2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_TOTAL2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_LABA_DITAHAN2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_ANTAR_BANK_AKTIVA_GIRO2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_ANTAR_BANK_AKTIVA_TABUNGAN2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTV_ANTAR_BANK_AKTIVA_LAINNYA2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_ANTAR_BANK_PASSIVA_PINJAMAN2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_ANTAR_BANK_PASSIVA_DEPOSITO_LEBIH_3BULAN2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_ANTAR_BANK_PASSIVA_DEPOSITO_SD_3BULAN2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PSV_ANTAR_BANK_PASSIVA_TABUNGAN2.Text.ToString().Replace(",",".")).ToString().Replace(",",".");
			conn.ExecuteNonQuery();
		}

		private void ViewData()
		{
			conn2.QueryString = "SELECT SYSCOLUMNS.[name] FROM SYSOBJECTS, SYSCOLUMNS WHERE SYSOBJECTS.[name] = 'CA_NERACA_BPR' AND SYSCOLUMNS.[ID] = SYSOBJECTS.[ID] AND SYSCOLUMNS.[name] not in ('CU_REF','AP_REGNO','SEQ')";
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
					System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "1");
					System.Web.UI.WebControls.TextBox txt2 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "2");
				
					string namatabel = conn2.GetFieldValue(i,"name").ToString();

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
			conn2.QueryString = "SELECT SYSCOLUMNS.[name] FROM SYSOBJECTS, SYSCOLUMNS WHERE SYSOBJECTS.[name] = 'CA_NERACA_BPR' AND SYSCOLUMNS.[ID] = SYSOBJECTS.[ID] AND SYSCOLUMNS.[name] not in ('CU_REF','AP_REGNO','SEQ','POSISI_TGL','JML_BLN')";
			conn2.ExecuteQuery();
			double pertumbuhan;

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "1");
				System.Web.UI.WebControls.TextBox txt2 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "2");
				System.Web.UI.WebControls.TextBox txt3 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "3");

				string id1 = txt1.ID;
				string id2 = txt2.ID;

				string isi1 = txt1.Text.ToString();
				string isi2 = txt2.Text.ToString();

				//txt1.Text = conn.GetFieldValue(0,conn2.GetFieldValue("name"));
				//txt2.Text = conn.GetFieldValue(1,conn2.GetFieldValue("name"));
				/*double a = MyConnection.ConvertToDouble2(txt1.Text);
				double b = MyConnection.ConvertToDouble2(txt2.Text);*/

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

		private void CalculateTotalAktiva()
		{
			double totalAntarBankAktiva = 0.0;

			conn2.QueryString = "SELECT SYSCOLUMNS.[name] FROM SYSOBJECTS, SYSCOLUMNS WHERE SYSOBJECTS.[name] = 'CA_NERACA_BPR' AND SYSCOLUMNS.[ID] = SYSOBJECTS.[ID] AND SYSCOLUMNS.[name] like '%AKTV%' AND SYSCOLUMNS.[name] not in ('CU_REF','AP_REGNO','SEQ','POSISI_TGL','JML_BLN')";
			conn2.ExecuteQuery();

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				if(	conn2.GetFieldValue(i,"name") == "AKTV_ANTAR_BANK_AKTIVA_GIRO" ||
					conn2.GetFieldValue(i,"name") == "AKTV_ANTAR_BANK_AKTIVA_TABUNGAN" ||
					conn2.GetFieldValue(i,"name") == "AKTV_ANTAR_BANK_AKTIVA_LAINNYA")
				{
					System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "1");
					string id = txt1.ID;
					string isi = txt1.Text;
					totalAntarBankAktiva += MyConnection.ConvertToDouble2(txt1.Text.Replace(",","."));
				}
			}

			TXT_AKTV_ANTAR_BANK_AKTIVA1.Text = GlobalTools.MoneyFormat(totalAntarBankAktiva.ToString());
			totalAntarBankAktiva = 0.0;

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				if(conn2.GetFieldValue(i,"name") != "AKTV_TOTAL" && conn2.GetFieldValue(i,"name") != "AKTV_ANTAR_BANK_AKTIVA")
				{
					System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "1");
					string id = txt1.ID;
					string isi = txt1.Text;
					totalAktiva += MyConnection.ConvertToDouble2(txt1.Text.Replace(",","."));
				}
			}

			TXT_AKTV_TOTAL1.Text = GlobalTools.MoneyFormat(totalAktiva.ToString());
			totalAktiva = 0.0;

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				if(	conn2.GetFieldValue(i,"name") == "AKTV_ANTAR_BANK_AKTIVA_GIRO" ||
					conn2.GetFieldValue(i,"name") == "AKTV_ANTAR_BANK_AKTIVA_TABUNGAN" ||
					conn2.GetFieldValue(i,"name") == "AKTV_ANTAR_BANK_AKTIVA_LAINNYA")
				{
					System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "2");
					string id = txt1.ID;
					string isi = txt1.Text;
					totalAntarBankAktiva += MyConnection.ConvertToDouble2(txt1.Text.Replace(",","."));
				}
			}

			TXT_AKTV_ANTAR_BANK_AKTIVA2.Text = GlobalTools.MoneyFormat(totalAntarBankAktiva.ToString());

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				if(conn2.GetFieldValue(i,"name") != "AKTV_TOTAL"  && conn2.GetFieldValue(i,"name") != "AKTV_ANTAR_BANK_AKTIVA")
				{
					System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "2");
					string id = txt1.ID;
					string isi = txt1.Text;
					totalAktiva += MyConnection.ConvertToDouble2(txt1.Text.Replace(",","."));
				}
			}

			TXT_AKTV_TOTAL2.Text = GlobalTools.MoneyFormat(totalAktiva.ToString());
			totalAktiva = 0.0;
		}

		private void CalculateTotalPasiva()
		{

			double totalAntarBankPasiva = 0.0;
			conn2.QueryString = "SELECT SYSCOLUMNS.[name] FROM SYSOBJECTS, SYSCOLUMNS WHERE SYSOBJECTS.[name] = 'CA_NERACA_BPR' AND SYSCOLUMNS.[ID] = SYSOBJECTS.[ID] AND SYSCOLUMNS.[name] like '%PSV%' AND SYSCOLUMNS.[name] not in ('CU_REF','AP_REGNO','SEQ','POSISI_TGL','JML_BLN')";
			conn2.ExecuteQuery();

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				if(	conn2.GetFieldValue(i,"name") == "PSV_ANTAR_BANK_PASSIVA_PINJAMAN" ||
					conn2.GetFieldValue(i,"name") == "PSV_ANTAR_BANK_PASSIVA_DEPOSITO_LEBIH_3BULAN" ||
					conn2.GetFieldValue(i,"name") == "PSV_ANTAR_BANK_PASSIVA_DEPOSITO_SD_3BULAN" ||
					conn2.GetFieldValue(i,"name") == "PSV_ANTAR_BANK_PASSIVA_TABUNGAN")
				{
					System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "1");
					string id = txt1.ID;
					string isi = txt1.Text;
					totalAntarBankPasiva += MyConnection.ConvertToDouble2(txt1.Text.Replace(",","."));
				}
			}

			TXT_PSV_ANTAR_BANK_PASSIVA1.Text = GlobalTools.MoneyFormat(totalAntarBankPasiva.ToString());
			totalAntarBankPasiva = 0.0;

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				if(conn2.GetFieldValue(i,"name") != "PSV_TOTAL" && conn2.GetFieldValue(i,"name") != "PSV_ANTAR_BANK_PASSIVA")
				{
					System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "1");
					string id = txt1.ID;
					string isi = txt1.Text;
					totalPasiva += MyConnection.ConvertToDouble2(txt1.Text.Replace(",","."));
				}
			}

			TXT_PSV_TOTAL1.Text = GlobalTools.MoneyFormat(totalPasiva.ToString());
			totalPasiva = 0.0;

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				if(	conn2.GetFieldValue(i,"name") == "PSV_ANTAR_BANK_PASSIVA_PINJAMAN" ||
					conn2.GetFieldValue(i,"name") == "PSV_ANTAR_BANK_PASSIVA_DEPOSITO_LEBIH_3BULAN" ||
					conn2.GetFieldValue(i,"name") == "PSV_ANTAR_BANK_PASSIVA_DEPOSITO_SD_3BULAN" ||
					conn2.GetFieldValue(i,"name") == "PSV_ANTAR_BANK_PASSIVA_TABUNGAN")
				{
					System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "2");
					string id = txt1.ID;
					string isi = txt1.Text;
					totalAntarBankPasiva += MyConnection.ConvertToDouble2(txt1.Text.Replace(",","."));
				}
			}

			TXT_PSV_ANTAR_BANK_PASSIVA2.Text = GlobalTools.MoneyFormat(totalAntarBankPasiva.ToString());
			totalAntarBankPasiva = 0.0;

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				if(conn2.GetFieldValue(i,"name") != "PSV_TOTAL"  && conn2.GetFieldValue(i,"name") != "PSV_ANTAR_BANK_PASSIVA")
				{
					System.Web.UI.WebControls.TextBox txt2 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "2");
					string id = txt2.ID;
					string isi = txt2.Text;
					totalPasiva += MyConnection.ConvertToDouble2(txt2.Text.Replace(",","."));
				}
			}

			TXT_PSV_TOTAL2.Text = GlobalTools.MoneyFormat(totalPasiva.ToString());
			totalPasiva = 0.0;
		}

		private bool cekMandatory()
		{
			conn2.QueryString = "SELECT SYSCOLUMNS.[name] FROM SYSOBJECTS, SYSCOLUMNS WHERE SYSOBJECTS.[name] = 'CA_NERACA_BPR' AND SYSCOLUMNS.[ID] = SYSOBJECTS.[ID] AND SYSCOLUMNS.[name] not in ('CU_REF','AP_REGNO','SEQ')";
			conn2.ExecuteQuery();

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "1");
				System.Web.UI.WebControls.TextBox txt2 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "2");
				
				string id2 = conn2.GetFieldValue(i,"name");

				if(conn2.GetFieldValue(i,"name") != "POSISI_TGL" && conn2.GetFieldValue(i,"name") != "DDAY" && conn2.GetFieldValue(i,"name") != "DMONTH" && conn2.GetFieldValue(i,"name") != "DYEAR")
				{
					string id = txt1.ID.ToString();
					string cssClass = txt1.CssClass.ToString();

					if(txt1.Text.ToString().Replace(" ","") == "")
					{
						if(txt1.CssClass == "mandatory")
						{
							Tools.popMessage(this, "Field " + txt1.ID.ToString() + " belum terisi !");
							return false;
						}
					}

					if(txt2.Text.ToString().Replace(" ","") == "")
					{
						if(txt2.CssClass == "mandatory")
						{
							Tools.popMessage(this, "Field " + txt2.ID.ToString() + " belum terisi !");
							return false;
						}
					}
				}
				else
				{
					if(conn2.GetFieldValue(i,"name") == "POSISI_TGL")
					{
						//GlobalTools.ToSQLDate(txt_DD_B1.Text, ddl_MM_B1.SelectedValue, txt_YY_B1.Text) 
						if(txt_DD_B1.CssClass == "mandatory")
						{
							if(txt_DD_B1.Text.ToString().Replace(" ","") == "")
							{
								Tools.popMessage(this, "Field " + txt_DD_B1.ID.ToString() + " belum terisi lengkap !");
								return false;
							}
						}

						if(txt_DD_B2.CssClass == "mandatory")
						{
							if(txt_DD_B2.Text.ToString().Replace(" ","") == "")
							{
								Tools.popMessage(this, "Field " + txt_DD_B2.ID.ToString() + " belum terisi lengkap !");
								return false;
							}
						}


						if(ddl_MM_B1.CssClass == "mandatory")
						{
							if(ddl_MM_B1.SelectedValue.ToString().Replace(" ","") == "")
							{
								Tools.popMessage(this, "Field " + ddl_MM_B1.ID.ToString() + " belum terisi lengkap !");
								return false;
							}
						}

						if(ddl_MM_B2.CssClass == "mandatory")
						{
							if(ddl_MM_B2.SelectedValue.ToString().Replace(" ","") == "")
							{
								Tools.popMessage(this, "Field " + ddl_MM_B2.ID.ToString() + " belum terisi lengkap !");
								return false;
							}
						}

						if(txt_YY_B1.CssClass == "mandatory")
						{
							if(txt_YY_B1.Text.ToString().Replace(" ","") == "")
							{
								Tools.popMessage(this, "Field " + txt_YY_B1.ID.ToString() + " belum terisi lengkap !");
								return false;
							}
						}

						if(txt_YY_B2.CssClass == "mandatory")
						{
							if(txt_YY_B2.Text.ToString().Replace(" ","") == "")
							{
								Tools.popMessage(this, "Field " + txt_YY_B2.ID.ToString() + " belum terisi lengkap !");
								return false;
							}
						}
					}
				}
			}

			return true;
		}

		protected void btn_Save_Click(object sender, System.EventArgs e)
		{
			if (!cekTanggal())
				return;

			if(cekMandatory())
			{
				//cek dulu periode sama ato gak ?
				CalculateTotalAktiva();
				CalculateTotalPasiva();
				CalculatePertumbuhan();
				if(CekAktivaPasivaBalance())
				{
					SaveNeraca();
					Tools.popMessage(this,"Data has been saved  !");

					BindData("dg_Neraca","EXEC BPR_BIND_NERACACURRENT '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'");
					BindData("DG_NeracaHistory", "EXEC BPR_BIND_NERACAHISTORY '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'");
				}
				else
				{
					Tools.popMessage(this,"Total Aktiva dan Total Pasiva tidak Balance  !");
				}
			}
		}

		private bool CekAktivaPasivaBalance()
		{
			if((TXT_PSV_TOTAL1.Text.ToString() == TXT_AKTV_TOTAL1.Text.ToString()) && (TXT_AKTV_TOTAL2.Text.ToString() == TXT_PSV_TOTAL2.Text.ToString()))
			{
				return true;
			}
			
			return false;
		}


		/// <summary>
		/// Mengisi dropdown tanggal
		/// </summary>
		private void IsiTanggal()
		{
			GlobalTools.initDateFormINA(txt_DD_B1, ddl_MM_B1, txt_YY_B1, true);
			GlobalTools.initDateFormINA(txt_DD_B2, ddl_MM_B2, txt_YY_B2, true);
		}

		private void CalculateRatio()
		{
			try
			{
				conn.QueryString = "EXEC CALCULATE_BPR_RATIO '" + Request.QueryString["regno"] + "','" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();
			}
			catch (Exception ex)
			{
				GlobalTools.popMessage(this, "Data neraca / laba rugi / komdal belum lengkap !");
				Response.Write("<!--" + ex.Message + "-->");
				return;
			}
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
			conn2.QueryString = "SELECT SYSCOLUMNS.[name] FROM SYSOBJECTS, SYSCOLUMNS WHERE SYSOBJECTS.[name] = 'CA_NERACA_BPR' AND SYSCOLUMNS.[ID] = SYSOBJECTS.[ID] AND SYSCOLUMNS.[name] not in ('CU_REF','AP_REGNO','SEQ')";
			conn2.ExecuteQuery();

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "1");
				System.Web.UI.WebControls.TextBox txt2 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "2");
				System.Web.UI.WebControls.TextBox txt3 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "3");
				
				if(conn2.GetFieldValue(i,"name") != "POSISI_TGL" || conn2.GetFieldValue(i,"name") != "DDAY" || conn2.GetFieldValue(i,"name") != "DMONTH" || conn2.GetFieldValue(i,"name") != "DYEAR")
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
					if(conn2.GetFieldValue(i,"name") == "DDAY")
					{
						txt_DD_B1.Text = "";
						txt_DD_B2.Text = "";
					}
					else if(conn2.GetFieldValue(i,"name") == "DMONTH")
					{
						ddl_MM_B1.SelectedValue = "0";
						ddl_MM_B2.SelectedValue = "0";
					}
					else if(conn2.GetFieldValue(i,"name") == "DYEAR")
					{
						txt_YY_B1.Text = "";
						txt_YY_B2.Text = "";
					}
				}
			}
		}

		private void dg_Neraca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;
			switch (cmd)
			{		  
				case "retrieve" :
					//Response.Redirect("bprNeraca.aspx?tahun=" + e.Item.Cells[1].Text +"&mode=retrieve&regno="+Request.QueryString["regno"]+"&curef="+Request.QueryString["curef"]+ "&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]);
					try
					{
						retrieveData(e.Item.Cells[1].Text.ToString());
					}
					catch
					{
						Tools.popMessage(this, "Baris data neraca pada posisi tanggal ini adalah yang paling akhir ! Silahkan pilih posisi tanggal yang lebih awal !");
					}
					break;
				case "delete"	:
					conn.QueryString = "EXEC BPR_DEL_NERACA '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "','" + e.Item.Cells[1].Text + "'";
					conn.ExecuteQuery();
					BindData("dg_Neraca","EXEC BPR_BIND_NERACACURRENT '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'");
					break;
			}	
		}

		private void retrieve_data(string tahun, string regno)
		{
			string curef = Request.QueryString["curef"];

			//conn.QueryString = "EXEC BPR_GETNERACA '" + curef + "','" + regno + "','" + tahun + "'";
			//conn.ExecuteQuery();

			conn.QueryString = "SELECT TOP 2 DAY(POSISI_TGL) DDAY, MONTH(POSISI_TGL) DMONTH, YEAR(POSISI_TGL) DYEAR, * FROM CA_NERACA_BPR WHERE AP_REGNO = '" + regno + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND POSISI_TGL <= '" + tahun + "' ORDER BY POSISI_TGL DESC";
			conn.ExecuteQuery();

			ViewData();
			CalculateTotalAktiva();
			CalculateTotalPasiva();
			CalculatePertumbuhan();
		}

		private void DG_NeracaHistory_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;
			switch (cmd)
			{		  
				case "retrieve_history"	:
					//Response.Redirect("bprNeraca.aspx?tahun=" + e.Item.Cells[1].Text +"&mode=retrieve&regno="+Request.QueryString["regno"]+"&curef="+Request.QueryString["curef"]+ "&menucode="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]);
					//clearData();
					try
					{
						retrieve_data(e.Item.Cells[1].Text.ToString(),e.Item.Cells[0].Text.ToString());
					}
					catch
					{
						Tools.popMessage(this, "Baris data neraca pada posisi tanggal ini adalah yang paling akhir ! Silahkan pilih posisi tanggal yang lebih awal !");
					}
					break;
				case "delete"	:
					conn.QueryString = "EXEC BPR_DEL_NERACA '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "','" + e.Item.Cells[1].Text + "'";
					conn.ExecuteQuery();
					BindData("DG_NeracaHistory", "EXEC BPR_BIND_NERACAHISTORY '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'");
					break;
			}
		}

		protected void btnCalculateRatio_Click(object sender, System.EventArgs e)
		{
			CalculateRatio();
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