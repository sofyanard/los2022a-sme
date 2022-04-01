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


namespace SME.InitialDataEntry
{
	/// <summary>
	/// Summary description for Neraca.
	/// </summary>
	public partial class PreScoringNeracaRL : System.Web.UI.Page
	{
		protected Connection conn;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected System.Web.UI.WebControls.TextBox Textbox3;
		protected System.Web.UI.WebControls.TextBox Textbox4;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				LBL_APREGNO.Text=Request.QueryString["regno"];

				if (Request.QueryString["curef"].Equals(""))
				{
					conn.QueryString = "select cu_ref from application where ap_regno = '" +LBL_APREGNO.Text+ "'";
					conn.ExecuteQuery();
					LBL_CUREF.Text = conn.GetFieldValue("cu_ref").ToString();
				}	
				else
				{
					LBL_CUREF.Text=Request.QueryString["curef"];
				}
				GlobalTools.initDateForm(TXT_POSISITGL_DD,DDL_POSISITGL_MM,TXT_POSISITGL_YY);
				viewInitial();
				toggle_button(false);

				///////////////////////////////////////////////
				///	SET MANDATORY FIELDS
				///	
				setMandatoryFields("N");


				///////////////////////////////////////////////
				///	SET DISABLED FIELDS
				///	
				setDisabledFields("N");
			}
			//BTN_SAVE.Attributes.Add("onclick","if(!valid_scoringNeracaRL()){return false;};");
			BTN_SAVE.Attributes.Add("onclick","Hitung()");
		}

		//Procedure ini melakukan setting terhadap properti 'ENABLE' dari kontrol-kontrol yang ada 
		//sesuai dengan program yang dipilih
		private void setDisabledFields(string FAIRISAAC_SUBMODULE) 
		{
			conn.QueryString = "select * from VW_SCORING_DISABLED_FIELDS " + 
				"where FAIRISAAC_SUBMODULE = '" + FAIRISAAC_SUBMODULE + 
				"' and AP_REGNO = '" + Request.QueryString["regno"] +
				"' and ACTIVE = '1'";
			conn.ExecuteQuery();

			for(int i=0; i < conn.GetRowCount(); i++) 
			{
				string CONTROLID = conn.GetFieldValue(i, "FAIRISAAC_CONTROLID");
			
				if (CONTROLID.IndexOf(",") == 0) 
				{
					if (CONTROLID.StartsWith("TXT_")) 
					{
						TextBox TXT_CONTROL = (TextBox) Page.FindControl(CONTROLID);
						try 
						{
							TXT_CONTROL.ReadOnly = true;
							TXT_CONTROL.BackColor = Color.Gainsboro;
						} 
						catch (NullReferenceException) {}
					}
					else if (CONTROLID.StartsWith("DDL_")) 
					{
						DropDownList DDL_CONTROL = (DropDownList) Page.FindControl(CONTROLID);
						try 
						{
							DDL_CONTROL.Enabled = false;
							DDL_CONTROL.BackColor = Color.Gainsboro;
						} 
						catch (NullReferenceException) {}
					}
				} 
				else 
				{
					string CONTROL;
					string[] split = CONTROLID.Split(new Char[] {','});
				
					foreach(string s in split) 
					{
						if (s.Trim() != "") 
						{
							CONTROL = s;
							if (CONTROL.StartsWith("TXT_")) 
							{
								TextBox TXT_CONTROL = (TextBox) Page.FindControl(CONTROL);
								try 
								{
									TXT_CONTROL.ReadOnly = true;
									TXT_CONTROL.BackColor = Color.Gainsboro;
								} 
								catch (NullReferenceException) {}
							}
							else if (CONTROL.StartsWith("DDL_")) 
							{
								DropDownList DDL_CONTROL = (DropDownList) Page.FindControl(CONTROL);
								try 
								{
									DDL_CONTROL.Enabled = false;
									DDL_CONTROL.BackColor = Color.Gainsboro;
								}
								catch (NullReferenceException) {}
							}
						}
					}
				}
			}
		}

		//Procedure ini melakukan setting terhadap properti 'ENABLE' dari kontrol-kontrol yang ada 
		//sesuai dengan program yang dipilih
		private void setMandatoryFields(string FAIRISAAC_SUBMODULE) 
		{
			conn.QueryString = "select * from VW_SCORING_MANDATORY_FIELDS " + 
				"where FAIRISAAC_SUBMODULE = '" + FAIRISAAC_SUBMODULE + 
				"' and AP_REGNO = '" + Request.QueryString["regno"] +
				"' and ACTIVE = '1'";
			conn.ExecuteQuery();

			for(int i=0; i < conn.GetRowCount(); i++) 
			{
				string CONTROLID = conn.GetFieldValue(i, "FAIRISAAC_CONTROLID");
			
				if (CONTROLID.IndexOf(",") == 0) 
				{
					if (CONTROLID.StartsWith("TXT_")) 
					{
						TextBox TXT_CONTROL = (TextBox) Page.FindControl(CONTROLID);
						try {TXT_CONTROL.CssClass = "mandatory";}
						catch (NullReferenceException) {}
					}
					else if (CONTROLID.StartsWith("DDL_")) 
					{
						DropDownList DDL_CONTROL = (DropDownList) Page.FindControl(CONTROLID);
						try {DDL_CONTROL.CssClass = "mandatory";}
						catch {}
					}
				} 
				else 
				{
					string CONTROL;
					string[] split = CONTROLID.Split(new Char[] {','});
				
					foreach(string s in split) 
					{
						if (s.Trim() != "") 
						{
							CONTROL = s;
							if (CONTROL.StartsWith("TXT_")) 
							{
								TextBox TXT_CONTROL = (TextBox) Page.FindControl(CONTROL);
								try {TXT_CONTROL.CssClass = "mandatory";}
								catch (NullReferenceException) {}
							}
							else if (CONTROL.StartsWith("DDL_")) 
							{
								DropDownList DDL_CONTROL = (DropDownList) Page.FindControl(CONTROL);
								try {DDL_CONTROL.CssClass = "mandatory";}
								catch {}
							}
						}
					}
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
		private void toggle_button(bool x)
		{
			BTN_SAVE.Enabled = x;
			BTN_HITUNG.Enabled = !x;
		}

		//Mempopulate semua kontrol dengan database dan default ke nol untuk field-field yang kosong
		void viewInitial()
		{
				//inisialisasi semua kontrol neraca rugi laba dengan nol
				TXT_PSN_KASBANK.Text="0";
				TXT_PSN_PIUTANGDAGANG.Text="0";
				TXT_PSN_PERSEDIAAN.Text="0";
				TXT_PSN_TTLAKTIVALCR.Text="0";
				TXT_PSN_TNHBGN.Text="0";
				TXT_PSN_MSNPRLTN.Text="0";
				TXT_PSN_INVKNDRN.Text="0";
				TXT_PSN_AKTIVATTPLAIN.Text="0";
				TXT_PSN_AKUMSUSUT.Text="0";
				TXT_PSN_NETAKTIVATTP.Text="0";
				TXT_PSN_BIAYADITANGGUHKAN.Text="0";
				TXT_PSN_AKUMAMORTISASI.Text="0";
				TXT_PSN_AKTIVALAIN.Text="0";
				TXT_PSN_TTLAKTIVALAIN.Text="0";
				TXT_PSN_TTLAKTIVA.Text="0";
				TXT_PSRL_PENJUALANTAHUNAN.Text="0";
				TXT_PSRL_HPP.Text="0";
				TXT_PSRL_BIAYAUMUMADM.Text="0";
				TXT_PSRL_LABAOPERASI.Text="0";
				TXT_PSRL_BIAYABUNGA.Text="0";
				TXT_PSRL_BIAYAPENYUSUTAN.Text="0";
				TXT_JMLBLN.Text="12";
				TXT_SALESONCREDIT.Text="0";
				TXT_PSRL_BIAYALAIN.Text="0";
				TXT_HUTBANK.Text="0";
				TXT_HUTDAGANG.Text="0";
				TXT_KI12BLN.Text="0";
				TXT_HUTLANCARLAIN.Text="0";
				TXT_TOTHUTLANCAR.Text="0";
				TXT_HUTPS.Text="0";
				TXT_HUTJKPJG.Text="0";
				TXT_HUTPJGLAIN.Text="0";
				TXT_TOTHUTJKPJG.Text="0";
				TXT_HUTANG.Text="0";
				TXT_MODALDISETOR.Text="0";
				TXT_LABADITAHAN.Text="0";
				TXT_LABABERJALAN.Text="0";
				TXT_TOTMODAL.Text="0";
				TXT_TOTPASIVA.Text="0";
				TXT_PEND_LAIN.Text="0";
				TXT_LABASBLMPAJAK.Text="0";
				TXT_PAJAK.Text="0";
				TXT_LABABERSIH.Text="0";
				TXT_PSN_AKTIVALCRLAIN.Text="0";
				TXT_SLSWKR.Text="0";
				TXT_DNWR.Text="0";
				//TXT_CURRENTRATIO.Text="0";
				//TXT_BUSSDEBTSRATIO.Text="0";
				//TXT_PROSENPENINGKATANPENJUALAN.Text="0";
				//TXT_PROSENNETINCOME.Text="0";
				//TXT_TRADECYCLEDAYS.Text="0";
				TXT_PUCHASEPLAN.Text="0";
				TXT_LIMITWCBM.Text="0";
				TXT_LABABERSIHRATA2.Text="0";
			

			double x;
			string str;
			str="select * from ca_neraca_small where ap_regno='"+ Request.QueryString["regno"] +"'";
            conn.QueryString=str;
			conn.ExecuteQuery();
			if(conn.GetRowCount()>0)
			{

				if (!conn.GetFieldValue("POSISI_TGL").Equals(null)||(!conn.GetFieldValue("POSISI_TGL").Equals(""))) 
				{
					DateTime a = Convert.ToDateTime(conn.GetFieldValue("POSISI_TGL"));
					TXT_POSISITGL_DD.Text=a.Day.ToString();
					DDL_POSISITGL_MM.SelectedValue=a.Month.ToString();
					TXT_POSISITGL_YY.Text=a.Year.ToString();
				}
				DDL_AUDITED.SelectedValue=conn.GetFieldValue("JNS_LAP");

		
				
				x=0;
				if (conn.GetFieldValue("AKTV_KASBANK")!="")
				{
					x = Convert.ToDouble(conn.GetFieldValue("AKTV_KASBANK"));
				}
				TXT_PSN_KASBANK.Text=x.ToString("#0");

				x=0;
				if (conn.GetFieldValue("AKTV_PIUDGN")!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("AKTV_PIUDGN"));
				}
				TXT_PSN_PIUTANGDAGANG.Text=x.ToString("#0");

				x=0;
				if (conn.GetFieldValue("AKTV_PERSEDIAAN")!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("AKTV_PERSEDIAAN"));
				}
				TXT_PSN_PERSEDIAAN.Text=x.ToString("#0");

				x=0;
				if (conn.GetFieldValue("AKTV_TTLAKTLCR")!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("AKTV_TTLAKTLCR"));
				}
				TXT_PSN_TTLAKTIVALCR.Text=x.ToString("#0");
				//TXT_PSN_TTLAKTIVALCR.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("AKTV_TTLAKTLCR"));

				x=0;
				if (conn.GetFieldValue("AKTV_LCRLAIN")!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("AKTV_LCRLAIN"));
				}
				TXT_PSN_AKTIVALCRLAIN.Text=x.ToString("#0");

				x=0;
				if (conn.GetFieldValue("AKTV_TNHBGN")!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("AKTV_TNHBGN"));
				}
				TXT_PSN_TNHBGN.Text=x.ToString("#0");

				x=0;
				if (conn.GetFieldValue("AKTV_MSNALAT")!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("AKTV_MSNALAT"));
				}
				TXT_PSN_MSNPRLTN.Text=x.ToString("#0");

				x=0;
				if (conn.GetFieldValue("AKTV_INVKNDRN")!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("AKTV_INVKNDRN"));
				}
				TXT_PSN_INVKNDRN.Text=x.ToString("#0");

				x=0;
				if (conn.GetFieldValue("AKTV_TTPLAIN")!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("AKTV_TTPLAIN"));
				}
				TXT_PSN_AKTIVATTPLAIN.Text=x.ToString("#0");

				x=0;
				if (conn.GetFieldValue("AKTV_AKUMSUSUT")!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("AKTV_AKUMSUSUT"));
				}
				TXT_PSN_AKUMSUSUT.Text=x.ToString("#0");

				x=0;
				if (conn.GetFieldValue("AKTV_NETAKTVTTP")!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("AKTV_NETAKTVTTP"));
				}
				TXT_PSN_NETAKTIVATTP.Text=x.ToString("#0");

				x=0;
				if (conn.GetFieldValue("AKTV_BIAYATANGGUH")!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("AKTV_BIAYATANGGUH"));
				}
				TXT_PSN_BIAYADITANGGUHKAN.Text=x.ToString("#0");

				x=0;
				if (conn.GetFieldValue("AKTV_AKUMAMOR")!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("AKTV_AKUMAMOR"));
				}
				TXT_PSN_AKUMAMORTISASI.Text=x.ToString("#0");

				x=0;
				if (conn.GetFieldValue("AKTV_AKTVLAIN")!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("AKTV_AKTVLAIN"));
				}
				TXT_PSN_AKTIVALAIN.Text=x.ToString("#0");

				x=0;
				if (conn.GetFieldValue("AKTV_TTLAKTVLAIN").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("AKTV_TTLAKTVLAIN"));
				}
				TXT_PSN_TTLAKTIVALAIN.Text=x.ToString("#0");

				x=0;
				if (conn.GetFieldValue("AKTV_TTLAKTV").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("AKTV_TTLAKTV"));
				}
				TXT_PSN_TTLAKTIVA.Text=x.ToString("#0");

				TXT_JMLBLN.Text="12";

				x=0;
				if (conn.GetFieldValue("SALES_ONCREDIT").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("SALES_ONCREDIT"));
				}
				TXT_SALESONCREDIT.Text=x.ToString("#0");

				x=0;
				if (conn.GetFieldValue("PASV_HTBANK").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("PASV_HTBANK"));
				}
				TXT_HUTBANK.Text=x.ToString("#0");

				x=0;
				if (conn.GetFieldValue("PASV_HTDG").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("PASV_HTDG"));
				}
				TXT_HUTDAGANG.Text=x.ToString("#0");

				x=0;
				if (conn.GetFieldValue("PASV_KIJTHTEMPO").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("PASV_KIJTHTEMPO"));
				}
				TXT_KI12BLN.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("PASV_HTLNCR").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("PASV_HTLNCR"));
				}
				TXT_HUTLANCARLAIN.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("PASV_TTLHTLNCR").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("PASV_TTLHTLNCR"));
				}
				TXT_TOTHUTLANCAR.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("PASV_HTPMGANGSHM").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("PASV_HTPMGANGSHM"));
				}
				TXT_HUTPS.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("PASV_HTJKPJG").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("PASV_HTJKPJG"));
				}
				TXT_HUTJKPJG.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("PASV_JKPJGLAIN")!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("PASV_JKPJGLAIN"));
				}
				TXT_HUTPJGLAIN.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("PASV_TTLHTJKPJG").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("PASV_TTLHTJKPJG"));
				}
				TXT_TOTHUTJKPJG.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("PASV_TTLHT").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("PASV_TTLHT"));
				}
				TXT_HUTANG.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("PASV_MODALSTR").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("PASV_MODALSTR"));
				}
				TXT_MODALDISETOR.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("PASV_LBRG").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("PASV_LBRG"));
				}
				TXT_LABADITAHAN.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("PASV_LBRGJALAN").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("PASV_LBRGJALAN"));
				}
				TXT_LABABERJALAN.Text=x.ToString("#0");

				x=0;
				if (conn.GetFieldValue("PASV_TTLMODAL").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("PASV_TTLMODAL"));
				}
				TXT_TOTMODAL.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("PASV_TTLPASIVA").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("PASV_TTLPASIVA"));
				}
				TXT_TOTPASIVA.Text=x.ToString("#0");
			}

			
			str="select * from ca_labarugi_small where ap_regno='"+ Request.QueryString["regno"] +"'";
			conn.QueryString=str;
			conn.ExecuteQuery();
			if(conn.GetRowCount()>0)
			{
				x=0;
				if (conn.GetFieldValue("IS_PENJ").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("IS_PENJ"));
				}
				TXT_PSRL_PENJUALANTAHUNAN.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("IS_ADMOPR").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("IS_ADMOPR"));
				}
				TXT_PSRL_BIAYAUMUMADM.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("IS_BIAYA_LAIN").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("IS_BIAYA_LAIN"));
				}
				TXT_PSRL_BIAYALAIN.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("IS_PNDPTN").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("IS_PNDPTN"));
				}
				TXT_PEND_LAIN.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("IS_LABA_SBLPJK").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("IS_LABA_SBLPJK"));
				}
				TXT_LABASBLMPAJAK.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("IS_PJK").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("IS_PJK"));
				}
				TXT_PAJAK.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("IS_LABA_BRSH").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("IS_LABA_BRSH"));
				}
				TXT_LABABERSIH.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("IS_HPP").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("IS_HPP"));
				}
				TXT_PSRL_HPP.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("IS_LABAOPR").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("IS_LABAOPR"));
				}
				TXT_PSRL_LABAOPERASI.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("IS_BUNGA").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("IS_BUNGA"));
				}
				TXT_PSRL_BIAYABUNGA.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("IS_TTLSUSUT").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("IS_TTLSUSUT"));
				}
				TXT_PSRL_BIAYAPENYUSUTAN.Text=x.ToString("#0");
				
				x=0;
				if (conn.GetFieldValue("IS_LABA_BRSH").Trim()!="")
				{
					x=Convert.ToDouble(conn.GetFieldValue("IS_LABA_BRSH"));
					x = x / 12.0;
				}
				TXT_LABABERSIHRATA2.Text = x.ToString("#0");
			}


			//////////////////////////////////////////////////////////////////
			///	Inisialisasi kelompok rasio dengan nol
			TXT_SLSWKR.Text = "0";
			TXT_DNWR.Text = "0";
			TXT_CURRENTRATIO.Text = "0";
			TXT_BUSSDEBTSRATIO.Text = "0";
			TXT_DAYS_RECEIVABLE.Text = "0";
			TXT_CASH_VELOCITY.Text = "0";
			TXT_DAYS_INVENTORY.Text = "0";
			TXT_DAYS_ACCPAYABLE.Text = "0";
			TXT_NETWORKING_CAPITAL.Text = "0";
			TXT_TOTALASSET_TO.Text = "0";
			/////////////////////////////////////////////////////////////////

			str="select * from ca_ratio_small where ap_regno='"+ Request.QueryString["regno"] +"' and sumberdata = 'PreScoring'";
			conn.QueryString=str;
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{

				TXT_SLSWKR.Text="0";
				if (conn.GetFieldValue("SALES_TO_WK_CAPITAL").Trim()!="")
				{
					TXT_SLSWKR.Text = conn.GetFieldValue("SALES_TO_WK_CAPITAL").ToString();
				}

				TXT_DNWR.Text="0";
				if (conn.GetFieldValue("DEBT_TO_NETWORTH").Trim()!="")
				{
					TXT_DNWR.Text = conn.GetFieldValue("DEBT_TO_NETWORTH").ToString();
				}
				
				TXT_CURRENTRATIO.Text="0";
				if (conn.GetFieldValue("CURRENT_RATIO").Trim()!="")
				{
					TXT_CURRENTRATIO.Text = conn.GetFieldValue("CURRENT_RATIO").ToString();
				}
				
				TXT_BUSSDEBTSRATIO.Text ="0";
				if (conn.GetFieldValue("BUSINESS_DEBT_SERVICE_RATIO").Trim()!="")
				{
					TXT_BUSSDEBTSRATIO.Text = conn.GetFieldValue("BUSINESS_DEBT_SERVICE_RATIO").ToString();
				}
				
				TXT_DAYS_RECEIVABLE.Text ="0";
				if (conn.GetFieldValue("DAYS_RECEIVABLE").Trim()!="")
				{
					TXT_DAYS_RECEIVABLE.Text = conn.GetFieldValue("DAYS_RECEIVABLE").ToString();
				}
				
				TXT_CASH_VELOCITY.Text="0";
				if (conn.GetFieldValue("CASH_VELOCITY").Trim()!="")
				{
					TXT_CASH_VELOCITY.Text = conn.GetFieldValue("CASH_VELOCITY").ToString();	
				}
				
				TXT_DAYS_INVENTORY.Text ="0";
				if (conn.GetFieldValue("DAYS_INVENTORY").Trim()!="")
				{
					TXT_DAYS_INVENTORY.Text = conn.GetFieldValue("DAYS_INVENTORY").ToString();
				}
				
				TXT_DAYS_ACCPAYABLE.Text ="0";
				if (conn.GetFieldValue("DAYS_ACCPAYABLE").Trim()!="")
				{
					TXT_DAYS_ACCPAYABLE.Text = conn.GetFieldValue("DAYS_ACCPAYABLE").ToString();
				}
				
				TXT_NETWORKING_CAPITAL.Text ="0";
				if (conn.GetFieldValue("NETWORKING_CAPITAL").Trim()!="")
				{
					TXT_NETWORKING_CAPITAL.Text = conn.GetFieldValue("NETWORKING_CAPITAL").ToString();
				}
				
				//TXT_ROI.Text = conn.GetFieldValue("RETURN_ON_INVESTMENT").ToString();
				
				TXT_TRADECYCLEDAYS.Text="0";
				if (conn.GetFieldValue("TRADE_CYCLE").Trim()!="")
				{
					TXT_TRADECYCLEDAYS.Text=conn.GetFieldValue("TRADE_CYCLE").ToString();
				}
				
				TXT_TOTALASSET_TO.Text ="0";
				if (conn.GetFieldValue("TTL_ASSET_TURN_OVER").Trim()!="")
				{
					TXT_TOTALASSET_TO.Text = conn.GetFieldValue("TTL_ASSET_TURN_OVER").ToString();
				}
			}	
		}



		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			BTN_HITUNG_Click(sender, e);

			if (LBL_HITUNG.Text == "1") 
			{
				hitung_ratio();
				viewInitial();
			}
		}

		//Melakukan perhitungan ratio dan default ke nol untuk data kosong
		private void hitung_ratio()
		{
			if(TXT_PSN_TTLAKTIVA.Text.Equals("")||TXT_TOTPASIVA.Text.Equals(""))
			{
				GlobalTools.popMessage(this,"Jumlah aktiva dan pasiva tidak boleh kosong.!!");
				return;
			}

			if (!GlobalTools.isDateValid(this,TXT_POSISITGL_DD.Text,DDL_POSISITGL_MM.SelectedValue,TXT_POSISITGL_YY.Text))
			{
				GlobalTools.popMessage(this,"Ada kesalahan pada pengisian tanggal.");
				return;
			}

			double dTotalHTLancar=0;
			if(TXT_TOTHUTLANCAR.Text.Trim()!="")
			{
				dTotalHTLancar = Convert.ToDouble(TXT_TOTHUTLANCAR.Text);
			}
			double dLabaBersih =0;
			if(TXT_LABABERSIH.Text.Trim()!="")
			{
				dLabaBersih = Convert.ToDouble(TXT_LABABERSIH.Text);
			}
			double dTotalAktivaLancar=0;
			if(TXT_PSN_TTLAKTIVALCR.Text.Trim()!="")
			{
				dTotalAktivaLancar = Convert.ToDouble(TXT_PSN_TTLAKTIVALCR.Text);
			}
			double dPenjualanTahunan=0;
			if(TXT_PSRL_PENJUALANTAHUNAN.Text.Trim()!="")
			{
				dPenjualanTahunan = Convert.ToDouble(TXT_PSRL_PENJUALANTAHUNAN.Text);
			}
			double dTotalModal=0;
			if(TXT_TOTMODAL.Text.Trim()!="")
			{
				dTotalModal = Convert.ToDouble(TXT_TOTMODAL.Text);
			}
			double dTotalHTJkPjg=0;
			if(TXT_TOTHUTJKPJG.Text.Trim()!="")
			{
				dTotalHTJkPjg = Convert.ToDouble(TXT_TOTHUTJKPJG.Text);
			}
			double dAkumSusut=0;
			if(TXT_PSN_AKUMSUSUT.Text.Trim()!="")
			{
				dAkumSusut = Convert.ToDouble(TXT_PSN_AKUMSUSUT.Text);
			}
			double dAkumAmortisasi=0;
			if(TXT_PSN_AKUMAMORTISASI.Text.Trim()!="")
			{
				dAkumAmortisasi = Convert.ToDouble(TXT_PSN_AKUMAMORTISASI.Text);
			}
			double dKasBank=0;
			if(TXT_PSN_KASBANK.Text.Trim()!="")
			{
				dKasBank = Convert.ToDouble(TXT_PSN_KASBANK.Text);
			}
			double dPiutangDagang=0;
			if(TXT_PSN_PIUTANGDAGANG.Text.Trim()!="")
			{
				dPiutangDagang = Convert.ToDouble(TXT_PSN_PIUTANGDAGANG.Text);
			}
			double dPersediaan=0;
			if(TXT_PSN_PERSEDIAAN.Text.Trim()!="")
			{
				dPersediaan = Convert.ToDouble(TXT_PSN_PERSEDIAAN.Text);
			}
			double dHPP=0;
			if(TXT_PSRL_HPP.Text.Trim()!="")
			{
				dHPP = Convert.ToDouble(TXT_PSRL_HPP.Text);
			}
			double dHutangDagang=0;
			if(TXT_HUTDAGANG.Text.Trim()!="")
			{
				dHutangDagang = Convert.ToDouble(TXT_HUTDAGANG.Text);
			}
			double dTotalAktiva=0;
			if(TXT_PSN_TTLAKTIVA.Text.Trim()!="")
			{
				dTotalAktiva = Convert.ToDouble(TXT_PSN_TTLAKTIVA.Text);
			}


			double dDaysReceivable = 0;
			double dDaysInventory = 0;
			double dDaysAccPayable = 0;

			double dAktivaLancarLain =0;
			if(TXT_PSN_AKTIVALCRLAIN.Text.Trim()!="")
			{
				dAktivaLancarLain = Convert.ToDouble(TXT_PSN_AKTIVALCRLAIN.Text);
			}
			double dCurrPortLTDebt =0;
			if(TXT_KI12BLN.Text.Trim()!="")
			{
				dCurrPortLTDebt = Convert.ToDouble(TXT_KI12BLN.Text);
			}

			//double dAktivaLancarLain = Convert.ToDouble(TXT_PSN_AKTIVALCRLAIN.Text);
			//double dCurrPortLTDebt = Convert.ToDouble(TXT_KI12BLN.Text);

			// cek untuk Debt / Net Worth Ratio
			if (( dTotalModal > 0 ) || ( dTotalModal < 0 ))
				TXT_DNWR.Text = GlobalTools.MoneyFormat(Convert.ToString((dTotalHTLancar+dTotalHTJkPjg)/dTotalModal));
			else
				TXT_DNWR.Text="0,00";

			// cek untuk Current Ratio
			if (( dTotalHTLancar > 0) || ( dTotalHTLancar < 0 ))
				TXT_CURRENTRATIO.Text=GlobalTools.MoneyFormat(Convert.ToString(Math.Abs(dTotalAktivaLancar/dTotalHTLancar)));
				//TXT_CURRENTRATIO.Text = Convert.ToString(Math.Abs(Convert.ToDouble(TXT_PSN_TTLAKTIVALCR.Text) / dTotalHTLancar ));
			else
				TXT_CURRENTRATIO.Text="0,00";
			
			// cek untuk Sales / Working Capital Ratio
			double dPenyebut_SalesToWkCap = Convert.ToDouble(TXT_PSN_TTLAKTIVALCR.Text) - Convert.ToDouble(TXT_TOTHUTLANCAR.Text);
			if ((dPenyebut_SalesToWkCap>0) || (dPenyebut_SalesToWkCap < 0))
				//TXT_SLSWKR.Text=GlobalTools.MoneyFormat(Convert.ToString(Math.Abs(bil4/bil5)));
				TXT_SLSWKR.Text = GlobalTools.MoneyFormat(Convert.ToString(dPenjualanTahunan/dPenyebut_SalesToWkCap)) ;
			else
				TXT_SLSWKR.Text="0,00";
			
			// business debt service ratio
			if (dCurrPortLTDebt > 0 || dCurrPortLTDebt < 0)
				//TXT_BUSSDEBTSRATIO.Text = Convert.ToString(Convert.ToDouble(TXT_LABABERSIH.Text) +  Convert.ToDouble(TXT_PSN_AKUMSUSUT.Text) + Convert.ToDouble(TXT_PSN_AKUMAMORTISASI.Text) /  Convert.ToDouble(TXT_TOTHUTJKPJG.Text)); 
				TXT_BUSSDEBTSRATIO.Text = GlobalTools.MoneyFormat(Convert.ToString((dLabaBersih+dAkumSusut+dAkumAmortisasi)/dCurrPortLTDebt)); 
			else
				TXT_BUSSDEBTSRATIO.Text = "0,00";
			
			

			if (dPenjualanTahunan > 0 || dPenjualanTahunan < 0 )
				//TXT_CASH_VELOCITY.Text = Convert.ToString((Convert.ToDouble(TXT_PSN_KASBANK.Text) / Convert.ToDouble(TXT_PSRL_PENJUALANTAHUNAN.Text))* 360);
				TXT_CASH_VELOCITY.Text = GlobalTools.MoneyFormat(Convert.ToString((dKasBank/dPenjualanTahunan)*360));
			else
				TXT_CASH_VELOCITY.Text = "0,00";

			if (dPenjualanTahunan > 0 || dPenjualanTahunan < 0 )
				//TXT_DAYS_RECEIVABLE.Text = Convert.ToString((Convert.ToDouble(TXT_PSN_PIUTANGDAGANG.Text) / Convert.ToDouble(TXT_PSRL_PENJUALANTAHUNAN.Text)) * 360);
				TXT_DAYS_RECEIVABLE.Text = GlobalTools.MoneyFormat(Convert.ToString((dPiutangDagang/dPenjualanTahunan)*360));
			else
				TXT_DAYS_RECEIVABLE.Text= "0,00";

			if (dHPP > 0 || dHPP < 0)
				//TXT_DAYS_INVENTORY.Text = Convert.ToString((Convert.ToDouble(TXT_PSN_PERSEDIAAN.Text) / Convert.ToDouble(TXT_PSRL_HPP.Text))*360);
				TXT_DAYS_INVENTORY.Text =  GlobalTools.MoneyFormat(Convert.ToString((dPersediaan/dHPP)*360));
			else
				TXT_DAYS_INVENTORY.Text = "0,00";

			if (dHPP > 0 || dHPP < 0)
				//TXT_DAYS_ACCPAYABLE.Text = Convert.ToString(Convert.ToDouble(TXT_HUTDAGANG.Text) / Convert.ToDouble(TXT_PSRL_HPP.Text));
				TXT_DAYS_ACCPAYABLE.Text = GlobalTools.MoneyFormat(Convert.ToString((dHutangDagang/dHPP)*360));
			else
				TXT_DAYS_ACCPAYABLE.Text = "0,00";

			try {dDaysReceivable = Convert.ToDouble(TXT_DAYS_RECEIVABLE.Text);}
			catch {}
			try {dDaysInventory = Convert.ToDouble(TXT_DAYS_INVENTORY.Text);}
			catch {}
			try {dDaysAccPayable = Convert.ToDouble(TXT_DAYS_ACCPAYABLE.Text);}
			catch {}

			TXT_TRADECYCLEDAYS.Text =  GlobalTools.MoneyFormat(Convert.ToString(Math.Abs(dDaysReceivable+dDaysInventory-dDaysAccPayable)));

			//TXT_NETWORKING_CAPITAL.Text = Convert.ToString(Convert.ToDouble(TXT_PSN_TTLAKTIVALCR.Text) - Convert.ToDouble(TXT_TOTHUTLANCAR.Text));
			TXT_NETWORKING_CAPITAL.Text = GlobalTools.MoneyFormat(Convert.ToString(dTotalAktivaLancar-dTotalHTLancar));

			/*
			if (dTotalAktiva > 0 || dTotalAktiva < 0)
				//TXT_ROI.Text = Convert.ToString(Convert.ToDouble(TXT_LABABERSIH.Text) * Convert.ToDouble(TXT_PSN_AKTIVALCRLAIN.Text) / Convert.ToDouble(TXT_PSN_TTLAKTIVA.Text));	
				TXT_ROI.Text = GlobalTools.MoneyFormat(Convert.ToString((dLabaBersih*dAktivaLancarLain)/dTotalAktiva));	
			else
				TXT_ROI.Text = "0,00";
			*/


			if (dTotalAktiva > 0 || dTotalAktiva < 0)
				TXT_TOTALASSET_TO.Text = GlobalTools.MoneyFormat(Convert.ToString(dPenjualanTahunan/dTotalAktiva));
			else
				TXT_TOTALASSET_TO.Text = "0,00";
			
			/*TXT_DNWR.Text=GlobalTools.MoneyFormat(Convert.ToString(Convert.ToDouble(TXT_TOTHUTLANCAR.Text)/Convert.ToDouble(TXT_LABABERSIH.Text)));
			TXT_CURRENTRATIO.Text=GlobalTools.MoneyFormat(Convert.ToString(Convert.ToDouble(TXT_PSN_TTLAKTIVALCR.Text)/Convert.ToDouble(TXT_TOTHUTLANCAR.Text)));
			TXT_SLSWKR.Text=GlobalTools.MoneyFormat(Convert.ToString(Convert.ToDouble(TXT_PSRL_PENJUALANTAHUNAN.Text)/Convert.ToDouble(TXT_TOTMODAL.Text)));*/

			//simpan data rasio prescoring small
			conn.QueryString = "exec CA_RATIO_SMALL_SP 'sv_prescr','" + Request.QueryString["curef"] + "','" + Request.QueryString["regno"] + "'," +
				GlobalTools.ToSQLDate(TXT_POSISITGL_DD.Text,DDL_POSISITGL_MM.SelectedValue,TXT_POSISITGL_YY.Text) + "," + tool.ConvertFloat(TXT_JMLBLN.Text) + ",'" +
				DDL_AUDITED.SelectedValue + "'," + tool.ConvertFloat(TXT_CURRENTRATIO.Text) + ",0,0," + tool.ConvertFloat(TXT_TOTMODAL.Text) + "," +
				tool.ConvertFloat(TXT_CASH_VELOCITY.Text) + "," + tool.ConvertFloat(TXT_DAYS_RECEIVABLE.Text) + "," + tool.ConvertFloat(TXT_DAYS_INVENTORY.Text) + "," +
				tool.ConvertFloat(TXT_DAYS_ACCPAYABLE.Text) + "," + tool.ConvertFloat(TXT_TRADECYCLEDAYS.Text) + "," + tool.ConvertFloat(TXT_NETWORKING_CAPITAL.Text) + "," +
				//tool.ConvertFloat(TXT_ROI.Text) + ",0," + tool.ConvertFloat(TXT_TOTALASSET_TO.Text) + ",0,0,0,0,0,0,0," + tool.ConvertFloat(TXT_SLSWKR.Text) + "," +
				"0,0," + tool.ConvertFloat(TXT_TOTALASSET_TO.Text) + ",0,0,0,0,0,0,0," + tool.ConvertFloat(TXT_SLSWKR.Text) + "," +
				tool.ConvertFloat(TXT_DNWR.Text) + "," + tool.ConvertFloat(TXT_BUSSDEBTSRATIO.Text) + ",''";  
			conn.ExecuteNonQuery();

			//toggle_button(true);
			toggle_button(false);
		}

		
		protected void BTN_HITUNG_Click(object sender, System.EventArgs e)
		{
			if(TXT_PSN_TTLAKTIVA.Text.Equals("")||TXT_TOTPASIVA.Text.Equals(""))
			{
				LBL_HITUNG.Text = "0";
				GlobalTools.popMessage(this,"Jumlah aktiva dan pasiva tidak boleh kosong.!!");				
				return;
			}
			else if (TXT_PSN_TTLAKTIVA.Text != TXT_TOTPASIVA.Text)
			{
				LBL_HITUNG.Text = "0";
				GlobalTools.popMessage(this, "Jumlah aktiva dan pasiva tidak seimbang.!!");				
				return;
			}
			

			if (!GlobalTools.isDateValid(this,TXT_POSISITGL_DD.Text,DDL_POSISITGL_MM.SelectedValue,TXT_POSISITGL_YY.Text))
			{
				LBL_HITUNG.Text = "0";
				GlobalTools.popMessage(this,"Ada kesalahan pada pengisian tanggal.");
				return;
			}

			string str;
			conn.QueryString="select * from ca_neraca_small where sumberdata='PreScoring' and ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			
			if(conn.GetRowCount()>0)
			{
				conn.QueryString="delete from ca_neraca_small where sumberdata='PreScoring' and ap_regno='" + Request.QueryString["regno"] + "'";
				conn.ExecuteNonQuery();
			}

			if(GlobalTools.isFuture(TXT_POSISITGL_DD.Text,DDL_POSISITGL_MM.SelectedValue,TXT_POSISITGL_YY.Text))
			{
				LBL_HITUNG.Text = "0";
				GlobalTools.popMessage(this,"Tanggal tidak boleh lebih dari hari ini.");
				return;
			}



			string SALESONCREDIT,KASBANK,PIUTANGDAGANG,PERSEDIAAN,AKTIVALCRLAIN,TTLAKTIVALCR,TNHBGN,MSNPRLTN,INVKNDRN,
				AKTIVATTPLAIN,AKUMSUSUT,NETAKTIVATTP,BIAYADITANGGUHKAN,AKUMAMORTISASI,AKTIVALAIN,TTLAKTIVALAIN,
				TTLAKTIVA,HUTDAGANG,HUTBANK,KI12BLN,HUTLANCARLAIN,TOTHUTLANCAR,HUTANG,HUTJKPJG,HUTPS,HUTPJGLAIN,TOTHUTJKPJG,
				MODALDISETOR,LABADITAHAN,LABABERJALAN,TOTMODAL,TOTPASIVA;

			if(TXT_SALESONCREDIT.Text.Trim()=="")
			{
				SALESONCREDIT = "0";
			}
			else
			{
				SALESONCREDIT = tool.ConvertFloat(TXT_SALESONCREDIT.Text);
			}
			if(TXT_PSN_KASBANK.Text.Trim()=="")
			{
				KASBANK ="0";
			}
			else
			{
				KASBANK = tool.ConvertFloat(TXT_PSN_KASBANK.Text);
			}
			if(TXT_PSN_PIUTANGDAGANG.Text.Trim()=="")
			{
				PIUTANGDAGANG = "0";
			}
			else
			{
				PIUTANGDAGANG = tool.ConvertFloat(TXT_PSN_PIUTANGDAGANG.Text);
			}
			if(TXT_PSN_PERSEDIAAN.Text.Trim()=="")
			{
				PERSEDIAAN = "0";
			}
			else
			{
				PERSEDIAAN = tool.ConvertFloat(TXT_PSN_PERSEDIAAN.Text);
			}
			if(TXT_PSN_AKTIVALCRLAIN.Text.Trim()=="")
			{
				AKTIVALCRLAIN = "0";
			}
			else
			{
				AKTIVALCRLAIN = tool.ConvertFloat(TXT_PSN_AKTIVALCRLAIN.Text);
			}
			if(TXT_PSN_TTLAKTIVALCR.Text.Trim()=="")
			{
				TTLAKTIVALCR = "0";
			}
			else
			{
				TTLAKTIVALCR = tool.ConvertFloat(TXT_PSN_TTLAKTIVALCR.Text);
			}
			if(TXT_PSN_TNHBGN.Text.Trim()=="")
			{
				TNHBGN = "0";
			}
			else
			{
				TNHBGN = tool.ConvertFloat(TXT_PSN_TNHBGN.Text);
			}
			if(TXT_PSN_MSNPRLTN.Text.Trim()=="")
			{
				MSNPRLTN = "0";
			}
			else
			{
				MSNPRLTN = tool.ConvertFloat(TXT_PSN_MSNPRLTN.Text);
			}
			if(TXT_PSN_INVKNDRN.Text.Trim()=="")
			{
				INVKNDRN = "0";
			}
			else
			{
				INVKNDRN = tool.ConvertFloat(TXT_PSN_INVKNDRN.Text);
			}
			if(TXT_PSN_AKTIVATTPLAIN.Text.Trim()=="")
			{
				AKTIVATTPLAIN ="0";
			}
			else
			{
				AKTIVATTPLAIN = tool.ConvertFloat(TXT_PSN_AKTIVATTPLAIN.Text);
			}
			if(TXT_PSN_AKUMSUSUT.Text.Trim()=="")
			{
				AKUMSUSUT = "0";
			}
			else
			{
				AKUMSUSUT = tool.ConvertFloat(TXT_PSN_AKUMSUSUT.Text);
			}
			if(TXT_PSN_NETAKTIVATTP.Text.Trim()=="")
			{
				NETAKTIVATTP = "0";
			}
			else
			{
				NETAKTIVATTP = tool.ConvertFloat(TXT_PSN_NETAKTIVATTP.Text);
			}
			if(TXT_PSN_BIAYADITANGGUHKAN.Text.Trim()=="")
			{
				BIAYADITANGGUHKAN = "0";
			}
			else
			{
				BIAYADITANGGUHKAN = tool.ConvertFloat(TXT_PSN_BIAYADITANGGUHKAN.Text);
			}
			if(TXT_PSN_AKUMAMORTISASI.Text.Trim()=="")
			{
				AKUMAMORTISASI = "0";
			}
			else
			{
				AKUMAMORTISASI = tool.ConvertFloat(TXT_PSN_AKUMAMORTISASI.Text);
			}
			if(TXT_PSN_AKTIVALAIN.Text.Trim()=="")
			{
				AKTIVALAIN = "0";
			}
			else
			{
				AKTIVALAIN = tool.ConvertFloat(TXT_PSN_AKTIVALAIN.Text);
			}
			if(TXT_PSN_TTLAKTIVALAIN.Text.Trim()=="")
			{
				TTLAKTIVALAIN = "0";
			}
			else
			{
				TTLAKTIVALAIN = tool.ConvertFloat(TXT_PSN_TTLAKTIVALAIN.Text);
			}

			if(TXT_PSN_TTLAKTIVA.Text.Trim()=="")
			{
				TTLAKTIVA="0";
			}
			else
			{
				TTLAKTIVA=tool.ConvertFloat(TXT_PSN_TTLAKTIVA.Text);
			}

			if(TXT_HUTDAGANG.Text.Trim()=="")
			{
				HUTDAGANG="0";
			}
			else
			{
				HUTDAGANG=tool.ConvertFloat(TXT_HUTDAGANG.Text);
			}

			if(TXT_HUTBANK.Text.Trim()=="")
			{
				HUTBANK="0";
			}
			else
			{
				HUTBANK=tool.ConvertFloat(TXT_HUTBANK.Text);
			}

			if(TXT_KI12BLN.Text.Trim()=="")
			{
				KI12BLN="0";
			}
			else
			{
				KI12BLN=tool.ConvertFloat(TXT_KI12BLN.Text);
			}

			if(TXT_HUTLANCARLAIN.Text.Trim()=="")
			{
				HUTLANCARLAIN="0";
			}
			else
			{
				HUTLANCARLAIN=tool.ConvertFloat(TXT_HUTLANCARLAIN.Text);
			}

			if(TXT_TOTHUTLANCAR.Text.Trim()=="")
			{
				TOTHUTLANCAR="0";
			}
			else
			{
				TOTHUTLANCAR=tool.ConvertFloat(TXT_TOTHUTLANCAR.Text);
			}

			if(TXT_HUTJKPJG.Text.Trim()=="")
			{
				HUTJKPJG="0";
			}
			else
			{
				HUTJKPJG=tool.ConvertFloat(TXT_HUTJKPJG.Text);
			}

			if(TXT_HUTPS.Text.Trim()=="")
			{
				HUTPS="0";
			}
			else
			{
				HUTPS=tool.ConvertFloat(TXT_HUTPS.Text);
			}

			if(TXT_HUTPJGLAIN.Text.Trim()=="")
			{
				HUTPJGLAIN="0";
			}
			else
			{
				HUTPJGLAIN=tool.ConvertFloat(TXT_HUTPJGLAIN.Text);
			}

			if(TXT_TOTHUTJKPJG.Text.Trim()=="")
			{
				TOTHUTJKPJG="0";
			}
			else
			{
				TOTHUTJKPJG=tool.ConvertFloat(TXT_TOTHUTJKPJG.Text);
			}

			if(TXT_TOTHUTLANCAR.Text.Trim()=="")
			{
				TOTHUTLANCAR="0";
			}
			else
			{
				TOTHUTLANCAR=tool.ConvertFloat(TXT_TOTHUTLANCAR.Text);
			}

			if(TXT_HUTANG.Text.Trim()=="")
			{
				HUTANG="0";
			}
			else
			{
				HUTANG=tool.ConvertFloat(TXT_HUTANG.Text);
			}

			if(TXT_MODALDISETOR.Text.Trim()=="")
			{
				MODALDISETOR="0";
			}
			else
			{
				MODALDISETOR=tool.ConvertFloat(TXT_MODALDISETOR.Text);
			}

			if(TXT_LABADITAHAN.Text.Trim()=="")
			{
				LABADITAHAN="0";
			}
			else
			{
				LABADITAHAN=tool.ConvertFloat(TXT_LABADITAHAN.Text);
			}

			if(TXT_LABABERJALAN.Text.Trim()=="")
			{
				LABABERJALAN="0";
			}
			else
			{
				LABABERJALAN=tool.ConvertFloat(TXT_LABABERJALAN.Text);
			}

			if(TXT_TOTMODAL.Text.Trim()=="")
			{
				TOTMODAL="0";
			}
			else
			{
				TOTMODAL=tool.ConvertFloat(TXT_TOTMODAL.Text);
			}

			if(TXT_TOTPASIVA.Text.Trim()=="")
			{
				TOTPASIVA="0";
			}
			else
			{
				TOTPASIVA=tool.ConvertFloat(TXT_TOTPASIVA.Text);
			}

			//Simpan data Neraca prescoring small
			conn.QueryString = "exec IDE_PRESCORE_CA_NERACA_SMALL '" + 
				LBL_CUREF.Text  + "','" + 
				Request.QueryString["regno"] +"'," +  
				GlobalTools.ToSQLDate(TXT_POSISITGL_DD.Text,DDL_POSISITGL_MM.SelectedValue,TXT_POSISITGL_YY.Text) +"," + 
				TXT_JMLBLN.Text + ",'" + 
				DDL_AUDITED.SelectedValue  + "'," + 
				SALESONCREDIT  + "," + 
				KASBANK   + "," + 
				PIUTANGDAGANG + "," + 
				PERSEDIAAN  + "," + 
				AKTIVALCRLAIN  + "," + 
				TTLAKTIVALCR + "," + 
				TNHBGN  + "," + 
				MSNPRLTN  + "," + 
				INVKNDRN  + "," + 
				AKTIVATTPLAIN  + "," + 
				AKUMSUSUT + "," + 
				NETAKTIVATTP  + "," + 
				BIAYADITANGGUHKAN  + "," + 
				AKUMAMORTISASI  + "," + 
				AKTIVALAIN + "," + 
				TTLAKTIVALAIN  + "," + 
				TTLAKTIVA  + "," + 
				HUTDAGANG  + "," + 
				HUTBANK + "," +
				KI12BLN  + "," + 
				HUTLANCARLAIN + "," + 
				TOTHUTLANCAR  + "," + 
				HUTJKPJG + "," + 
				HUTPS + "," + 
				HUTPJGLAIN + "," + 
				TOTHUTJKPJG + "," + 
				HUTANG  + "," + 
				MODALDISETOR + "," + 
				LABADITAHAN  + "," + 
				TOTMODAL  + "," + 
				TOTPASIVA  + "," +
				LABABERJALAN  + ", 'PreScoring', '1'";
			conn.ExecuteNonQuery();

			//Response.Write("<BR>Panggil IDE_PRESCORE_CA_NERACA_SMALL selesai!");

			
			
			if (!GlobalTools.isDateValid(this,TXT_POSISITGL_DD.Text,DDL_POSISITGL_MM.SelectedValue,TXT_POSISITGL_YY.Text))
			{
				LBL_HITUNG.Text = "0";
				GlobalTools.popMessage(this,"Ada kesalahan pada pengisian tanggal.");
				return;
			}


			string PENJUALANTAHUNAN,HPP,BIAYAUMUMADM,LABAOPERASI,BIAYAPENYUSUTAN,PEND_LAIN,BIAYALAIN,BIAYABUNGA,LABASBLMPAJAK,PAJAK,LABABERSIH;

			
			if(TXT_PSRL_PENJUALANTAHUNAN.Text.Trim()=="")
			{
				PENJUALANTAHUNAN="0";
			}
			else
			{
				PENJUALANTAHUNAN=tool.ConvertFloat(TXT_PSRL_PENJUALANTAHUNAN.Text);
			}
			if(TXT_PSRL_HPP.Text=="")
			{
				HPP="0";
			}
			else
			{
				HPP=tool.ConvertFloat(TXT_PSRL_HPP.Text);
			}
			if(TXT_PSRL_BIAYAUMUMADM.Text.Trim()=="")
			{
				BIAYAUMUMADM="0";
			}
			else
			{
				BIAYAUMUMADM=tool.ConvertFloat(TXT_PSRL_BIAYAUMUMADM.Text);
			}
			if(TXT_PSRL_LABAOPERASI.Text.Trim()=="")
			{
				LABAOPERASI="0";
			}
			else
			{
				LABAOPERASI=tool.ConvertFloat(TXT_PSRL_LABAOPERASI.Text);
			}
			if(TXT_PSRL_BIAYAPENYUSUTAN.Text.Trim()=="")
			{
				BIAYAPENYUSUTAN="0";
			}
			else
			{
				BIAYAPENYUSUTAN=tool.ConvertFloat(TXT_PSRL_BIAYAPENYUSUTAN.Text);
			}
			if(TXT_PEND_LAIN.Text.Trim()=="")
			{
				PEND_LAIN="0";
			}
			else
			{
				PEND_LAIN=tool.ConvertFloat(TXT_PEND_LAIN.Text);
			}
			if(TXT_PSRL_BIAYALAIN.Text.Trim()=="")
			{
				BIAYALAIN="0";
			}
			else
			{
				BIAYALAIN=tool.ConvertFloat(TXT_PSRL_BIAYALAIN.Text);
			}
			if(TXT_LABABERSIH.Text.Trim()=="")
			{
				LABABERSIH="0";
			}
			else
			{
				LABABERSIH=tool.ConvertFloat(TXT_LABABERSIH.Text);
			}
			if(TXT_PAJAK.Text.Trim()=="")
			{
				PAJAK="0";
			}
			else
			{
				PAJAK=tool.ConvertFloat(TXT_PAJAK.Text);
			}
			if(TXT_LABASBLMPAJAK.Text.Trim()=="")
			{
				LABASBLMPAJAK="0";
			}
			else
			{
				LABASBLMPAJAK=tool.ConvertFloat(TXT_LABASBLMPAJAK.Text);
			}
			if(TXT_PSRL_BIAYABUNGA.Text.Trim()=="")
			{
				BIAYABUNGA="0";
			}
			else
			{
				BIAYABUNGA=tool.ConvertFloat(TXT_PSRL_BIAYABUNGA.Text);
			}



			//Simpan data Laba Rugi prescoring small
			conn.QueryString="delete from ca_labarugi_small where sumberdata='PreScoring' and ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteNonQuery();

			str="insert into ca_labarugi_small " +
				" (CU_REF,AP_REGNO,POSISI_TGL,JML_BLN,JNS_LAP,IS_PENJ,IS_HPP, " +
				" IS_ADMOPR,IS_LABAOPR,IS_TTLSUSUT,IS_PNDPTN,IS_BIAYA_LAIN," +
				" IS_BUNGA,IS_LABA_SBLPJK,IS_PJK,IS_LABA_BRSH,SUMBERDATA) " +
				" values ('" + LBL_CUREF.Text  +"','"+ Request.QueryString["regno"] +"'," +  
				GlobalTools.ToSQLDate(TXT_POSISITGL_DD.Text,DDL_POSISITGL_MM.SelectedValue,TXT_POSISITGL_YY.Text) +",'" + 
				TXT_JMLBLN.Text + "','" + DDL_AUDITED.SelectedValue  + "'," + 
				PENJUALANTAHUNAN + "," +
				HPP + "," +
				BIAYAUMUMADM + "," +
				LABAOPERASI + "," +
				BIAYAPENYUSUTAN + "," +
				PEND_LAIN + "," +
				BIAYALAIN + "," +
				BIAYABUNGA + "," +
				LABASBLMPAJAK + "," +
				PAJAK + "," +
				LABABERSIH + ",'PreScoring')";

			conn.QueryString=str;
			conn.ExecuteNonQuery();


			/*
			conn.QueryString="select * from SCORING_RATIO where  ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if(conn.GetRowCount()>0)
			{
				conn.QueryString="delete from SCORING_RATIO where  ap_regno='" + Request.QueryString["regno"] + "'";
				conn.ExecuteNonQuery();
			}

			*/

			string SLSWKR,DNWR,CURRENTRATIO,BUSSDEBTSRATIO,TRADECYCLEDAYS,PUCHASEPLAN,LIMITWCBM,LABABERSIHRATA2;


			
			if(TXT_SLSWKR.Text.Trim()=="")
			{
				SLSWKR="0";
			}
			else
			{
				SLSWKR=tool.ConvertFloat(TXT_SLSWKR.Text);
			}
			if(TXT_DNWR.Text.Trim()=="")
			{
				DNWR="0";
			}
			else
			{
				DNWR=tool.ConvertFloat(TXT_DNWR.Text);
			}
			if(TXT_CURRENTRATIO.Text.Trim()=="")
			{
				CURRENTRATIO="0";
			}
			else
			{
				CURRENTRATIO=tool.ConvertFloat(TXT_CURRENTRATIO.Text);
			}
			if(TXT_BUSSDEBTSRATIO.Text.Trim()=="")
			{
				BUSSDEBTSRATIO="0";
			}
			else
			{
				BUSSDEBTSRATIO=tool.ConvertFloat(TXT_BUSSDEBTSRATIO.Text);
			}

			if(TXT_TRADECYCLEDAYS.Text.Trim()=="")
			{
				TRADECYCLEDAYS="0";
			}
			else
			{
				TRADECYCLEDAYS=tool.ConvertFloat(TXT_TRADECYCLEDAYS.Text);
			}

			if(TXT_PUCHASEPLAN.Text.Trim()=="")
			{
				PUCHASEPLAN="0";
			}
			else
			{
				PUCHASEPLAN=tool.ConvertFloat(TXT_PUCHASEPLAN.Text);
			}

			if(TXT_LIMITWCBM.Text.Trim()=="")
			{
				LIMITWCBM="0";
			}
			else
			{
				LIMITWCBM=tool.ConvertFloat(TXT_LIMITWCBM.Text);
			}

			if(TXT_LABABERSIHRATA2.Text.Trim()=="")
			{
				LABABERSIHRATA2 = "0";
			}
			else
			{
				LABABERSIHRATA2 = tool.ConvertFloat(TXT_LABABERSIHRATA2.Text);
			}
			
			
			//PROSENPENINGKATANPENJUALAN=tool.ConvertFloat(TXT_PROSENPENINGKATANPENJUALAN.Text);
			//PROSENNETINCOME=tool.ConvertFloat(TXT_PROSENNETINCOME.Text);

			
			/*
			conn.QueryString="delete from SCORING_RATIO where  ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteNonQuery();
			
			str="insert into SCORING_RATIO(AP_REGNO,SALESWCRATIO,DEBTNETRATIO," +
			"CURRRATIO,BUSSINESSDEBTRATIO,INCPROSENTASEPENJUALAN,INCPROSENNETINCOME," +
			"TRADECYCLEDAYS,PURCHASINGPLANT,LIMITWCBM,NETPROFITAVG) values('" +
			Request.QueryString["regno"] + "'," +
			SLSWKR + "," +
			DNWR + "," +
			CURRENTRATIO + "," +
			BUSSDEBTSRATIO + "," +
			PROSENPENINGKATANPENJUALAN + "," +
			PROSENNETINCOME + "," +
			TRADECYCLEDAYS + "," +
			PUCHASEPLAN + "," +
			LIMITWCBM + "," +
			LABABERSIHRATA2  + ")";

			conn.QueryString=str;
			conn.ExecuteNonQuery();
			*/
			hitung_ratio();
			toggle_button(true);
			viewInitial();
			
			LBL_HITUNG.Text = "1";
		}
		
	}
}
