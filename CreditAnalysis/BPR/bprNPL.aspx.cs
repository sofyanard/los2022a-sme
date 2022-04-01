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
	public partial class bprNPL : System.Web.UI.Page
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
		private double totalAktiva;
		protected System.Web.UI.WebControls.TextBox Textbox13;
		protected System.Web.UI.WebControls.TextBox Textbox14;
		protected System.Web.UI.WebControls.TextBox Textbox15;
		private double totalPasiva;
		//protected Tools tool = new Tools();
	
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			conn2 = new Connection2();
			
			if(!IsPostBack)
			{
				IsiTanggal();
				BindData("DG_NPLHistory","EXEC BPR_BIND_NPLHISTORY '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'");
				BindData("DG_NPL", "EXEC BPR_BIND_NPLCURRENT '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'");
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
				conn.QueryString = "SELECT TOP 2 DAY(POSISI_TGL) DDAY, MONTH(POSISI_TGL) DMONTH, YEAR(POSISI_TGL) DYEAR, * FROM CA_NPL_BPR WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND POSISI_TGL <= '" + tahun + "' ORDER BY POSISI_TGL DESC";
				conn.ExecuteQuery();

				ViewData();
				CalculateTotalAktivaProd();
				CalculateTotalPPAP();
				CalculateTotalRest();
				CalculatePertumbuhan();
				ViewRestInPercent();
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
			this.DG_NPLHistory.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_NeracaHistory_ItemCommand);
			this.dg_NPL.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dg_NPL_ItemCommand);

		}
		#endregion


		/// <summary>
		/// Menyimpan data neraca dari form input ke database
		/// </summary>
		private void SaveNPL()
		{

			conn.QueryString = "EXEC SP_BPR_NPL 'Save','" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'," +
				GlobalTools.ToSQLDate(txt_DD_B1.Text, ddl_MM_B1.SelectedValue.ToString(), txt_YY_B1.Text) + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_APYD_LANCAR1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_APYD_KURANG_LANCAR1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_APYD_DIRAGUKAN1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_APYD_MACET1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_PPAP_LANCAR1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_PPAP_KURANG_LANCAR1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_PPAP_DIRAGUKAN1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_PPAP_MACET1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_APYD_TOTAL1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_PPAP_TOTAL1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_PPAP_YG_SEHARUSNYA_DIBENTUK1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_KELEBIHAN_KEKURANGAN_PEMBENTUKAN_PPAP1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTIVA_PRODUKTIF_YANG_DIKLASIFIKASIKAN1.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PENYISIHAN_PENGHAPUSAN_AKTIVA_PRODUKTIF1.Text.ToString().Replace(",",".")).ToString().Replace(",",".");
				conn.ExecuteNonQuery();

			conn.QueryString = "SP_BPR_NPL 'Save','" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'," +
				GlobalTools.ToSQLDate(txt_DD_B2.Text, ddl_MM_B2.SelectedValue.ToString(), txt_YY_B2.Text).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_APYD_LANCAR2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_APYD_KURANG_LANCAR2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_APYD_DIRAGUKAN2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_APYD_MACET2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_PPAP_LANCAR2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_PPAP_KURANG_LANCAR2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_PPAP_DIRAGUKAN2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_PPAP_MACET2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_APYD_TOTAL2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_PPAP_TOTAL2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_PPAP_YG_SEHARUSNYA_DIBENTUK2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_NPL_KELEBIHAN_KEKURANGAN_PEMBENTUKAN_PPAP2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_AKTIVA_PRODUKTIF_YANG_DIKLASIFIKASIKAN2.Text.ToString().Replace(",",".")).ToString().Replace(",",".") + "," +
				MyConnection.ConvertToDouble2(TXT_PENYISIHAN_PENGHAPUSAN_AKTIVA_PRODUKTIF2.Text.ToString().Replace(",",".")).ToString().Replace(",",".");
			conn.ExecuteNonQuery();
		}

		private void ViewData()
		{
			conn2.QueryString = "SELECT SYSCOLUMNS.[name] FROM SYSOBJECTS, SYSCOLUMNS WHERE SYSOBJECTS.[name] = 'CA_NPL_BPR' AND SYSCOLUMNS.[ID] = SYSOBJECTS.[ID] AND SYSCOLUMNS.[name] not in ('CU_REF','AP_REGNO','SEQ')";
			conn2.ExecuteQuery();

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				string tes = conn2.GetFieldValue(i,"name").ToString();
				string a = tes;

				if(conn2.GetFieldValue(i,"name") != "POSISI_TGL" && conn2.GetFieldValue(i,"name") != "DDAY" && conn2.GetFieldValue(i,"name") != "DMONTH" && conn2.GetFieldValue(i,"name") != "DYEAR")
				{
					System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "1");
					System.Web.UI.WebControls.TextBox txt2 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "2");

					txt1.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(1,conn2.GetFieldValue(i,"name")));
					txt2.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,conn2.GetFieldValue(i,"name")));
				}
				else
				{
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
			conn2.QueryString = "SELECT SYSCOLUMNS.[name] FROM SYSOBJECTS, SYSCOLUMNS WHERE SYSOBJECTS.[name] = 'CA_NPL_BPR' AND SYSCOLUMNS.[ID] = SYSOBJECTS.[ID] AND SYSCOLUMNS.[name] not in ('CU_REF','AP_REGNO','SEQ','POSISI_TGL','JML_BLN')";
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

		private void CalculateTotalAktivaProd()
		{
			conn2.QueryString = "SELECT SYSCOLUMNS.[name] FROM SYSOBJECTS, SYSCOLUMNS WHERE SYSOBJECTS.[name] = 'CA_NPL_BPR' AND SYSCOLUMNS.[ID] = SYSOBJECTS.[ID] AND SYSCOLUMNS.[name] like '%APYD%' AND SYSCOLUMNS.[name] not in ('CU_REF','AP_REGNO','POSISI_TGL','NPL_APYD_TOTAL')";
			conn2.ExecuteQuery();

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "1");
				totalAktiva += MyConnection.ConvertToDouble2(txt1.Text.Replace(",","."));
			}

			TXT_NPL_APYD_TOTAL1.Text = GlobalTools.MoneyFormat(totalAktiva.ToString());
			totalAktiva = 0.0;

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "2");
				totalAktiva += MyConnection.ConvertToDouble2(txt1.Text.Replace(",","."));
			}

			TXT_NPL_APYD_TOTAL2.Text = GlobalTools.MoneyFormat(totalAktiva.ToString());
			totalAktiva = 0.0;
		}

		private void CalculateTotalPPAP()
		{
			conn2.QueryString = "SELECT SYSCOLUMNS.[name] FROM SYSOBJECTS, SYSCOLUMNS WHERE SYSOBJECTS.[name] = 'CA_NPL_BPR' AND SYSCOLUMNS.[ID] = SYSOBJECTS.[ID] AND SYSCOLUMNS.[name] like '%PPAP%' AND SYSCOLUMNS.[name] not in ('CU_REF','AP_REGNO','POSISI_TGL','NPL_KELEBIHAN_KEKURANGAN_PEMBENTUKAN_PPAP','NPL_PPAP_YG_SEHARUSNYA_DIBENTUK','NPL_PPAP_TOTAL')";
			conn2.ExecuteQuery();

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				if(conn2.GetFieldValue("name") != "PSV_TOTAL")
				{
					System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "1");
					totalPasiva += MyConnection.ConvertToDouble2(txt1.Text.Replace(",","."));
				}
			}

			TXT_NPL_PPAP_TOTAL1.Text = GlobalTools.MoneyFormat(totalPasiva.ToString());
			totalPasiva = 0.0;

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				if(conn2.GetFieldValue("name") != "PSV_TOTAL")
				{
					System.Web.UI.WebControls.TextBox txt2 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "2");
					totalPasiva += MyConnection.ConvertToDouble2(txt2.Text.Replace(",","."));
				}
			}

			TXT_NPL_PPAP_TOTAL2.Text = GlobalTools.MoneyFormat(totalPasiva.ToString());
			totalPasiva = 0.0;
		}

		private void CalculateTotalRest()
		{
			double PPAPYSD1 = 0.0;
			double PPAPYSD2 = 0.0;

			PPAPYSD1 = (MyConnection.ConvertToDouble2(TXT_NPL_APYD_LANCAR1.Text.Replace(",",".")) * 0.005) + 
				(MyConnection.ConvertToDouble2(TXT_NPL_APYD_KURANG_LANCAR1.Text.Replace(",",".")) * 0.1) +
				(MyConnection.ConvertToDouble2(TXT_NPL_APYD_DIRAGUKAN1.Text.Replace(",",".")) * 0.5) + 
				(MyConnection.ConvertToDouble2(TXT_NPL_APYD_MACET1.Text.Replace(",",".")) * 1.0);

			PPAPYSD2 = (MyConnection.ConvertToDouble2(TXT_NPL_APYD_LANCAR2.Text.Replace(",",".")) * 0.005) + 
				(MyConnection.ConvertToDouble2(TXT_NPL_APYD_KURANG_LANCAR2.Text.Replace(",",".")) * 0.1) +
				(MyConnection.ConvertToDouble2(TXT_NPL_APYD_DIRAGUKAN2.Text.Replace(",","."))* 0.5) + 
				(MyConnection.ConvertToDouble2(TXT_NPL_APYD_MACET2.Text.Replace(",",".")) * 1);

			TXT_NPL_PPAP_YG_SEHARUSNYA_DIBENTUK1.Text = PPAPYSD1.ToString();
			TXT_NPL_PPAP_YG_SEHARUSNYA_DIBENTUK2.Text = PPAPYSD2.ToString();

			double KKPPPAP1 = 0.0;
			double KKPPPAP2 = 0.0;

			KKPPPAP1 = MyConnection.ConvertToDouble2(TXT_NPL_PPAP_TOTAL1.Text.Replace(",",".")) - MyConnection.ConvertToDouble2(TXT_NPL_PPAP_YG_SEHARUSNYA_DIBENTUK1.Text.Replace(",","."));
			KKPPPAP2 = MyConnection.ConvertToDouble2(TXT_NPL_PPAP_TOTAL2.Text.Replace(",",".")) - MyConnection.ConvertToDouble2(TXT_NPL_PPAP_YG_SEHARUSNYA_DIBENTUK2.Text.Replace(",","."));
		
			TXT_NPL_KELEBIHAN_KEKURANGAN_PEMBENTUKAN_PPAP1.Text = KKPPPAP1.ToString();
			TXT_NPL_KELEBIHAN_KEKURANGAN_PEMBENTUKAN_PPAP2.Text = KKPPPAP2.ToString();

			double APYD1 = 0.0;
			double APYD2 = 0.0;
			
			APYD1 = MyConnection.ConvertToDouble2(TXT_NPL_APYD_KURANG_LANCAR1.Text.Replace(",",".")) + MyConnection.ConvertToDouble2(TXT_NPL_APYD_DIRAGUKAN1.Text.Replace(",",".")) + MyConnection.ConvertToDouble2(TXT_NPL_APYD_MACET1.Text.Replace(",","."));
			APYD2 = MyConnection.ConvertToDouble2(TXT_NPL_APYD_KURANG_LANCAR2.Text.Replace(",",".")) + MyConnection.ConvertToDouble2(TXT_NPL_APYD_DIRAGUKAN2.Text.Replace(",",".")) + MyConnection.ConvertToDouble2(TXT_NPL_APYD_MACET2.Text.Replace(",","."));

			APYD1 = APYD1 / MyConnection.ConvertToDouble2(TXT_NPL_APYD_TOTAL1.Text.Replace(",","."));
			APYD2 = APYD1 /MyConnection.ConvertToDouble2(TXT_NPL_APYD_TOTAL2.Text.Replace(",","."));

			TXT_AKTIVA_PRODUKTIF_YANG_DIKLASIFIKASIKAN1.Text = APYD1.ToString();
			TXT_AKTIVA_PRODUKTIF_YANG_DIKLASIFIKASIKAN2.Text = APYD2.ToString();

			double PPAP1 = 0.0;
			double PPAP2 = 0.0;


			PPAP1 = MyConnection.ConvertToDouble2(TXT_NPL_APYD_KURANG_LANCAR1.Text.Replace(",",".")) + MyConnection.ConvertToDouble2(TXT_NPL_APYD_DIRAGUKAN1.Text.Replace(",",".")) + MyConnection.ConvertToDouble2(TXT_NPL_APYD_MACET1.Text.Replace(",","."));
			PPAP2 = MyConnection.ConvertToDouble2(TXT_NPL_APYD_KURANG_LANCAR2.Text.Replace(",",".")) + MyConnection.ConvertToDouble2(TXT_NPL_APYD_DIRAGUKAN2.Text.Replace(",",".")) + MyConnection.ConvertToDouble2(TXT_NPL_APYD_MACET2.Text.Replace(",","."));
			
			if(PPAP1 != 0.0)
			{
				PPAP1 = MyConnection.ConvertToDouble2(TXT_NPL_PPAP_TOTAL1.Text.Replace(",",".")) / PPAP1;
			}
			else
			{
				PPAP1 = 0.0;
			}

			if(PPAP2 != 0.0)
			{
				PPAP2 = MyConnection.ConvertToDouble2(TXT_NPL_PPAP_TOTAL2.Text.Replace(",",".")) / PPAP1;
			}
			else
			{
				PPAP2 = 0.0;
			}

			TXT_PENYISIHAN_PENGHAPUSAN_AKTIVA_PRODUKTIF1.Text = PPAP1.ToString();
			TXT_PENYISIHAN_PENGHAPUSAN_AKTIVA_PRODUKTIF2.Text = PPAP2.ToString();
		}

		private void ViewRestInPercent()
		{
			double PPAPYSD1 = 0.0;
			double PPAPYSD2 = 0.0;

			PPAPYSD1 = (MyConnection.ConvertToDouble2(TXT_NPL_APYD_LANCAR1.Text.Replace(",",".")) * 0.005) + 
				(MyConnection.ConvertToDouble2(TXT_NPL_APYD_KURANG_LANCAR1.Text.Replace(",",".")) * 0.1) +
				(MyConnection.ConvertToDouble2(TXT_NPL_APYD_DIRAGUKAN1.Text.Replace(",",".")) * 0.5) + 
				(MyConnection.ConvertToDouble2(TXT_NPL_APYD_MACET1.Text.Replace(",",".")) * 1.0);

			PPAPYSD2 = (MyConnection.ConvertToDouble2(TXT_NPL_APYD_LANCAR2.Text.Replace(",",".")) * 0.005) + 
				(MyConnection.ConvertToDouble2(TXT_NPL_APYD_KURANG_LANCAR2.Text.Replace(",",".")) * 0.1) +
				(MyConnection.ConvertToDouble2(TXT_NPL_APYD_DIRAGUKAN2.Text.Replace(",","."))* 0.5) + 
				(MyConnection.ConvertToDouble2(TXT_NPL_APYD_MACET2.Text.Replace(",",".")) * 1);

			TXT_NPL_PPAP_YG_SEHARUSNYA_DIBENTUK1.Text = GlobalTools.MoneyFormat(PPAPYSD1.ToString());
			TXT_NPL_PPAP_YG_SEHARUSNYA_DIBENTUK2.Text = GlobalTools.MoneyFormat(PPAPYSD2.ToString());

			double KKPPPAP1 = 0.0;
			double KKPPPAP2 = 0.0;

			KKPPPAP1 = MyConnection.ConvertToDouble2(TXT_NPL_PPAP_TOTAL1.Text.Replace(",",".")) - MyConnection.ConvertToDouble2(TXT_NPL_PPAP_YG_SEHARUSNYA_DIBENTUK1.Text.Replace(",","."));
			KKPPPAP2 = MyConnection.ConvertToDouble2(TXT_NPL_PPAP_TOTAL2.Text.Replace(",",".")) - MyConnection.ConvertToDouble2(TXT_NPL_PPAP_YG_SEHARUSNYA_DIBENTUK2.Text.Replace(",","."));
		
			TXT_NPL_KELEBIHAN_KEKURANGAN_PEMBENTUKAN_PPAP1.Text = GlobalTools.MoneyFormat(KKPPPAP1.ToString());
			TXT_NPL_KELEBIHAN_KEKURANGAN_PEMBENTUKAN_PPAP2.Text = GlobalTools.MoneyFormat(KKPPPAP2.ToString());

			double APYD1 = 0.0;
			double APYD2 = 0.0;
			
			APYD1 = MyConnection.ConvertToDouble2(TXT_NPL_APYD_KURANG_LANCAR1.Text.Replace(",",".")) + MyConnection.ConvertToDouble2(TXT_NPL_APYD_DIRAGUKAN1.Text.Replace(",",".")) + MyConnection.ConvertToDouble2(TXT_NPL_APYD_MACET1.Text.Replace(",","."));
			APYD2 = MyConnection.ConvertToDouble2(TXT_NPL_APYD_KURANG_LANCAR2.Text.Replace(",",".")) + MyConnection.ConvertToDouble2(TXT_NPL_APYD_DIRAGUKAN2.Text.Replace(",",".")) + MyConnection.ConvertToDouble2(TXT_NPL_APYD_MACET2.Text.Replace(",","."));

			APYD1 = APYD1 / MyConnection.ConvertToDouble2(TXT_NPL_APYD_TOTAL1.Text.Replace(",","."));
			APYD2 = APYD1 /MyConnection.ConvertToDouble2(TXT_NPL_APYD_TOTAL2.Text.Replace(",","."));

			TXT_AKTIVA_PRODUKTIF_YANG_DIKLASIFIKASIKAN1.Text = GlobalTools.MoneyFormat(((double)(APYD1 * 100)).ToString()) + " %";
			TXT_AKTIVA_PRODUKTIF_YANG_DIKLASIFIKASIKAN2.Text = GlobalTools.MoneyFormat(((double)(APYD2 * 100)).ToString()) + " %";

			double PPAP1 = 0.0;
			double PPAP2 = 0.0;


			PPAP1 = MyConnection.ConvertToDouble2(TXT_NPL_APYD_KURANG_LANCAR1.Text.Replace(",",".")) + MyConnection.ConvertToDouble2(TXT_NPL_APYD_DIRAGUKAN1.Text.Replace(",",".")) + MyConnection.ConvertToDouble2(TXT_NPL_APYD_MACET1.Text.Replace(",","."));
			PPAP2 = MyConnection.ConvertToDouble2(TXT_NPL_APYD_KURANG_LANCAR2.Text.Replace(",",".")) + MyConnection.ConvertToDouble2(TXT_NPL_APYD_DIRAGUKAN2.Text.Replace(",",".")) + MyConnection.ConvertToDouble2(TXT_NPL_APYD_MACET2.Text.Replace(",","."));
			
			if(PPAP1 != 0.0)
			{
				PPAP1 = MyConnection.ConvertToDouble2(TXT_NPL_PPAP_TOTAL1.Text.Replace(",",".")) / PPAP1;
			}
			else
			{
				PPAP1 = 0.0;
			}

			if(PPAP2 != 0.0)
			{
				PPAP2 = MyConnection.ConvertToDouble2(TXT_NPL_PPAP_TOTAL2.Text.Replace(",",".")) / PPAP1;
			}
			else
			{
				PPAP2 = 0.0;
			}

			TXT_PENYISIHAN_PENGHAPUSAN_AKTIVA_PRODUKTIF1.Text = GlobalTools.MoneyFormat(((double)(PPAP1 * 100)).ToString()) + " %";
			TXT_PENYISIHAN_PENGHAPUSAN_AKTIVA_PRODUKTIF2.Text = GlobalTools.MoneyFormat(((double)(PPAP2 * 100)).ToString()) + " %";
		}

		protected void btn_Save_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!cekTanggal())
					return;

				CalculateTotalAktivaProd();
				CalculateTotalPPAP();
				CalculateTotalRest();
				CalculatePertumbuhan();
				SaveNPL();
				ViewRestInPercent();
				BindData("DG_NPL", "EXEC BPR_BIND_NPLCURRENT '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'");
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

		private void CalculateRatio()
		{
			conn.QueryString = "EXEC CALCULATE_BPR_RATIO '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
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
			conn2.QueryString = "SELECT SYSCOLUMNS.[name] FROM SYSOBJECTS, SYSCOLUMNS WHERE SYSOBJECTS.[name] = 'CA_NPL_BPR' AND SYSCOLUMNS.[ID] = SYSOBJECTS.[ID] AND SYSCOLUMNS.[name] not in ('CU_REF','AP_REGNO','SEQ')";
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

			//conn.QueryString = "EXEC BPR_GETNPL '" + curef + "','" + regno + "','" + tahun + "'";
			//conn.ExecuteQuery();

			conn.QueryString = "SELECT TOP 2 DAY(POSISI_TGL) DDAY, MONTH(POSISI_TGL) DMONTH, YEAR(POSISI_TGL) DYEAR, * FROM CA_NPL_BPR WHERE AP_REGNO = '" + regno + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND POSISI_TGL <= '" + tahun + "' ORDER BY POSISI_TGL DESC";
			conn.ExecuteQuery();

			ViewData();
			CalculateTotalAktivaProd();
			CalculateTotalPPAP();
			CalculateTotalRest();
			CalculatePertumbuhan();
			ViewRestInPercent();
		}

		private void DG_NeracaHistory_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;
			switch (cmd)
			{		  
				case "retrieve_history"	:
					//Response.Redirect("bprNPL.aspx?tahun=" + e.Item.Cells[1].Text +"&mode=retrieve&regno="+Request.QueryString["regno"]+"&curef="+Request.QueryString["curef"]+ "&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]);
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
					conn.QueryString = "EXEC BPR_DEL_NPL '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "','" + e.Item.Cells[1].Text + "'";
					BindData("DG_NPLHistory", "EXEC BPR_BIND_NPLHISTORY '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'");
					break;
			}
		}

		private void dg_NPL_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;
			switch (cmd)
			{		  
				case "retrieve"	:
					//Response.Redirect("bprNPL.aspx?tahun=" + e.Item.Cells[1].Text +"&mode=retrieve&regno="+Request.QueryString["regno"]+"&curef="+Request.QueryString["curef"]+ "&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]);
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
					conn.QueryString = "EXEC BPR_DEL_NPL '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "','" + e.Item.Cells[2].Text + "'";
					conn.ExecuteQuery();
					BindData("dg_NPL", "EXEC BPR_BIND_NPLCURRENT '" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'");
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