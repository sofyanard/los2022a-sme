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
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace SME.Scoring
{
	/// <summary>
	/// Summary description for Neraca.
	/// asdlfjl;kjds
	/// </summary>
	public partial class ScoringInformasiUmum : System.Web.UI.Page
	{
		protected Connection conn;
		protected System.Web.UI.WebControls.TextBox TXT_PSRL_SBLMPAJAK;
		protected System.Web.UI.WebControls.TextBox TXT_PSRL_PAJAK;
		protected System.Web.UI.WebControls.TextBox TextBox6;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;

		protected System.Web.UI.WebControls.TextBox TextBox7;
		protected System.Web.UI.WebControls.TextBox TextBox4;
		protected System.Web.UI.WebControls.TextBox TextBox10;
		protected System.Web.UI.WebControls.TextBox TextBox11;
		protected System.Web.UI.WebControls.TextBox TextBox5;
		protected System.Web.UI.WebControls.DropDownList DropDownList6;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox TextBox8;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.WebControls.TextBox TextBox9;
		protected System.Web.UI.WebControls.TextBox TextBox12;
		protected System.Web.UI.WebControls.TextBox TextBox13;
		protected System.Web.UI.WebControls.TextBox TextBox14;
		protected System.Web.UI.WebControls.TextBox TextBox15;
		protected System.Web.UI.WebControls.TextBox TextBox16;
		protected System.Web.UI.WebControls.TextBox TextBox17;
		protected System.Web.UI.WebControls.TextBox TextBox18;
		protected System.Web.UI.WebControls.TextBox TextBox19;
		protected System.Web.UI.WebControls.TextBox TextBox21;
		protected System.Web.UI.WebControls.TextBox TextBox20;
		protected System.Web.UI.WebControls.TextBox TextBox22;
		protected System.Web.UI.WebControls.TextBox TextBox23;
		protected System.Web.UI.WebControls.TextBox TextBox24;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.TextBox TextBox25;
		protected System.Web.UI.WebControls.TextBox TextBox26;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			if(!IsPostBack)
			{
				GlobalTools.initDateForm(TXT_TGLLAHIR,DDL_BULANLAHIR,TXT_THN_LAHIR);
				GlobalTools.initDateForm(TXT_TGL_MENETAP,DDL_BLN_MENETAP,TXT_THN_MENETAP);
				GlobalTools.initDateForm(TXT_TGL_USAHA,DDL_BLN_USAHA,TXT_THN_USAHA);
				LBL_REGNO.Text=Request.QueryString["regno"];

				viewDDL();

				///////////////////////////////////////////////
				///	VIEW DATA DARI BERBAGAI TABEL
				///	
				viewPopulate();

				///////////////////////////////////////////////
				///	VIEW DATA DARI SCORING_INFOUMUM
				///	
				viewInitialData();

				///////////////////////////////////////////////
				///	SET MANDATORY FIELDS
				///	
				setMandatoryFields("I");


				///////////////////////////////////////////////
				///	SET DISABLED FIELDS
				///	
				setDisabledFields("I");

				//add session
				if((Session["SaveHub"] == null) || ((string)Session["SaveHub"] == ""))
				{
					Session.Add("SaveHub","0");
				}

			}

			// disable or enable PUKK or MICRO
			SetEnabledPUKKMICRO();





			BTN_SAVE.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1)){return false;};");			
			//BTN_SND_FAIRISAAC.Attributes.Add("onclick", "return updateParent('" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "', '" + Request.QueryString["tc"] + "', '" + Request.QueryString["mc"] + "', '" + Request.QueryString["cekdata"] + "');");

			TR_MICRO.Visible = false;
			TR_PUKK.Visible = false;
			TR_KI.Visible = false;
			TR_CONTRACTOR.Visible = false;
			TR_NCL.Visible = false;
		}

		//Procedure ini melakukan setting disabled terhadap field field di scoring info umum Final Scoring
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

		//Procedure ini melakukan setting mandatory terhadap field field di scoring info umum Final Scoring
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

		//Procedure ini menampilkan data neraca dan rugilaba dari database ke layar info umum  final scoring
		private void viewFromNeracaLabaRugi() 
		{
			//////////////////////////////////////////////////////////////////////////
			/// LABA RUGI (SMALL)
			/// TODO : MIDDLE BELUM
			/// 
			string strSmall;
			conn.QueryString="select * from vw_cek_smdm where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if(conn.GetFieldValue("businessunit")=="SM100")
			{strSmall="1";}
			else
			{strSmall="0";}
			
			//cek business unit : small atau middle
			/*
			if (strSmall=="1")
			{
				conn.QueryString = "select IS_PENJ,IS_ADMOPR,IS_HPP from CA_LABARUGI_SMALL where AP_REGNO = '" + LBL_REGNO.Text + "'" +
					" AND (IS_PROYEKSI IS NULL OR RTRIM(LTRIM(IS_PROYEKSI)) = '') " +
					" AND YEAR(POSISI_TGL) = (SELECT MAX(YEAR(POSISI_TGL))  " +
					" FROM CA_LABARUGI_SMALL WHERE AP_REGNO= '" + LBL_REGNO.Text + "'" +
					" AND (IS_PROYEKSI IS NULL OR RTRIM(LTRIM(IS_PROYEKSI)) = ''))";
			}
			else
			{
				conn.QueryString = "select IS_NET_SALES as IS_PENJ,IS_SELLING_GENADM as IS_ADMOPR, IS_COST_GS as IS_HPP from CA_LABARUGI_MIDDLE where AP_REGNO = '" + LBL_REGNO.Text + "'" +
					" AND (IS_ISPROYEKSI IS NULL OR RTRIM(LTRIM(IS_ISPROYEKSI)) = '' OR RTRIM(LTRIM(IS_ISPROYEKSI)) = '0') " +
					" AND YEAR(IS_DATE_PERIODE) = (SELECT MAX(YEAR(IS_DATE_PERIODE))  " +
					" FROM CA_LABARUGI_MIDDLE WHERE AP_REGNO= '" + LBL_REGNO.Text + "' " +
					" AND (IS_ISPROYEKSI IS NULL OR RTRIM(LTRIM(IS_ISPROYEKSI)) = '' OR RTRIM(LTRIM(IS_ISPROYEKSI)) = '0')) ";
			}
			*/
			conn.QueryString = "exec SP_CA_LABARUGI '" + LBL_REGNO.Text + "'";
			conn.ExecuteQuery();

			if(conn.GetRowCount()>0)
			{
				double x = Convert.ToDouble(conn.GetFieldValue("IS_PENJ"));
				double x_satuan = 0;
				TXT_PSRL_PENJUALANTAHUNAN.Text = x.ToString("##,##0.00");
				x_satuan = x / 1000;
				x_satuan = Math.Round(x_satuan);
				TXT_PSRL_PENJUALANTAHUNAN_INSATUAN.Text = x_satuan.ToString("##,##0.00");

				x = Convert.ToDouble(conn.GetFieldValue("IS_ADMOPR"));
				TXT_PSRL_BIAYAUMUMADM.Text = x.ToString("##,##0.00");				
				

				//				x = Convert.ToDouble(conn.GetFieldValue("IS_BIAYA_LAIN"));
				//				TXT_PSRL_BIAYALAIN.Text = x.ToString("##,##0.00");
				//				x = Convert.ToDouble(conn.GetFieldValue("IS_PNDPTN"));
				//				TXT_PEND_LAIN.Text = x.ToString("##,##0.00");
				//				x = Convert.ToDouble(conn.GetFieldValue("IS_LABA_SBLPJK"));
				//				TXT_LABASBLMPAJAK.Text = x.ToString("##,##0.00");
				//				x = Convert.ToDouble(conn.GetFieldValue("IS_PJK"));
				//				TXT_PAJAK.Text = x.ToString("##,##0.00");
				//				x = Convert.ToDouble(conn.GetFieldValue("IS_LABA_BRSH"));
				//				TXT_LABABERSIH.Text = x.ToString("##,##0.00");

				x = Convert.ToDouble(conn.GetFieldValue("IS_HPP"));
				TXT_PSRL_HPP.Text = x.ToString("##,##0.00");
				x_satuan = x / 1000;
				x_satuan = Math.Round(x_satuan);
				TXT_PSRL_HPP_INSATUAN.Text = x_satuan.ToString("##,##0.00");

				//				x = Convert.ToDouble(conn.GetFieldValue("IS_LABAOPR"));
				//				TXT_PSRL_LABAOPERASI.Text = x.ToString("##,##0.00");
				//				x = Convert.ToDouble(conn.GetFieldValue("IS_BUNGA"));
				//				TXT_PSRL_BIAYABUNGA.Text = x.ToString("##,##0.00");
				//				x = Convert.ToDouble(conn.GetFieldValue("IS_TTLSUSUT"));
				//				TXT_PSRL_BIAYAPENYUSUTAN.Text = x.ToString("##,##0.00");

				double laba_bersih = 0;
				try { laba_bersih = Convert.ToDouble(conn.GetFieldValue("IS_LABA_BRSH")); } 
				catch {}
				try { TXT_AVG_NET_PROFIT.Text = Convert.ToString(Convert.ToInt32(Math.Round(laba_bersih/12.0))); } 
				catch {}
			}

			////////////////////////////////////////////////////////////////////////////////
			///	NERACA (SMALL)
			///	
			/*
			if (strSmall=="1")
			{
				
				conn.QueryString = "select AKTV_KASBANK,AKTV_TTLAKTLCR,AKTV_TNHBGN,PASV_TTLHT,PASV_TTLMODAL,AKTV_TTLAKTV from CA_NERACA_SMALL where AP_REGNO = '" + LBL_REGNO.Text + "'" +
					" AND (IS_PROYEKSI IS NULL OR RTRIM(LTRIM(IS_PROYEKSI)) = '') " +
					" AND YEAR(POSISI_TGL) = (SELECT MAX(YEAR(POSISI_TGL)) " +
					" FROM CA_NERACA_SMALL WHERE AP_REGNO= '" + LBL_REGNO.Text + "'" +
					" AND (IS_PROYEKSI IS NULL OR RTRIM(LTRIM(IS_PROYEKSI)) = '')) "; 
				

			}
			else
			{
				conn.QueryString = "select BS_CASH_BANK as AKTV_KASBANK,BS_CURRASST as AKTV_TTLAKTLCR,BS_NETFIXASST as AKTV_TNHBGN,BS_TTL_LIAB as PASV_TTLHT,BS_TTL_NETWORTH as PASV_TTLMODAL, BS_TTL_ASST as AKTV_TTLAKTV  from CA_NERACA_MIDDLE where AP_REGNO = '" + LBL_REGNO.Text + "'" +
					" AND (BS_ISPROYEKSI IS NULL OR RTRIM(LTRIM(BS_ISPROYEKSI)) = '' OR RTRIM(LTRIM(BS_ISPROYEKSI)) = '0') " +
					" AND YEAR(BS_DATE_PERIODE) = (SELECT MAX(YEAR(BS_DATE_PERIODE))  "  +
					" FROM CA_NERACA_MIDDLE WHERE AP_REGNO= '" + LBL_REGNO.Text + "'" +
					" AND (BS_ISPROYEKSI IS NULL OR RTRIM(LTRIM(BS_ISPROYEKSI)) = '' OR RTRIM(LTRIM(BS_ISPROYEKSI)) = '0' ))";
			}
			*/
			conn.QueryString = "exec SP_CA_NERACA '" + LBL_REGNO.Text + "'";			
			conn.ExecuteQuery();

			if(conn.GetRowCount()>0)
			{
				double x = Convert.ToDouble(conn.GetFieldValue("AKTV_KASBANK"));
				double x_satuan = 0;

				x_satuan = x / 1000;
				x_satuan = Math.Round(x_satuan);
				TXT_PSN_KASBANK.Text = x.ToString("##,##0.00");
				TXT_PSN_KASBANK.Text = conn.GetFieldValue("AKTV_KASBANK");
				TXT_PSN_KASBANK_INSATUAN.Text = x_satuan.ToString("##,##0.00");
				
				x = Convert.ToDouble(conn.GetFieldValue("AKTV_TTLAKTLCR"));
				x_satuan = x / 1000;
				x_satuan = Math.Round(x_satuan);
				TXT_PSN_TTLAKTIVALCR.Text = x.ToString("##,##0.00");
				TXT_PSN_TTLAKTIVALCR_INSATUAN.Text = x_satuan.ToString("##,##0.00");

				x = Convert.ToDouble(conn.GetFieldValue("AKTV_TNHBGN"));
				TXT_PSN_TNHBGN.Text = x.ToString("##,##0.00");

				x = Convert.ToDouble(conn.GetFieldValue("PASV_TTLHT"));
				x_satuan = x / 1000;
				x_satuan = Math.Round(x_satuan);
				TXT_HUTANG.Text = x.ToString("##,##0.00");
				TXT_HUTANG_INSATUAN.Text = x_satuan.ToString("##,##0.00");

				x = Convert.ToDouble(conn.GetFieldValue("PASV_TTLMODAL"));
				x_satuan = x / 1000;
				x_satuan = Math.Round(x_satuan);
				TXT_TOTMODAL.Text = x.ToString("##,##0.00");
				TXT_TOTMODAL_INSATUAN.Text = x_satuan.ToString("##,##0.00");

				x = Convert.ToDouble(conn.GetFieldValue("AKTV_TTLAKTV"));
				TXT_PSN_TTLAKTIVA.Text = x.ToString("##,##0.00");
			}

			/////
			///Penambahan Sales Increase
			///
			if (strSmall=="1") 
			{
				TXT_PROSEN_SALES_INCREASE.Text= "100";
			}
			else 
			{   // ubah ini jadikan pick up neraca small !!! !!!
				//				string incStr;
				//				string sql = "exec SP_SLS_NEI_INC '" + Request.QueryString["regno"] + "'";
				//				conn.QueryString = sql;
				//				conn.ExecuteQuery();
				//				double salesInc = 0;
				//				if(conn.GetRowCount()>0)
				//				{
				//					DataTable dt6 = conn.GetDataTable().Copy();
				//					double salesYear2=0;
				//					double salesYear1=0;
				//					if (dt6.Rows.Count > 0) 
				//					{
				//						salesYear2 = Double.Parse(conn.GetFieldValue(dt6, 0, "IS_NET_SALES"));
				//						if (dt6.Rows.Count > 1) 
				//						{
				//							salesYear1 = Double.Parse(conn.GetFieldValue(dt6, 1, "IS_NET_SALES"));
				//						}
				//						salesInc =	(salesYear2 - salesYear1) / salesYear1;
				//					}
				//					incStr=Math.Round(salesInc*100).ToString();
				////					if (incStr.Length>3)
				////					{
				////						incStr="999";				
				////					}
				//					//tTxt=tTxt + Pjg(CovToEBCDIC(incStr),3);
				//				}
				//				else
				//				{
				//					incStr="100";
				//				}
				/*
				if (strSmall=="1")
				{
					conn.QueryString="select top 1 * from ca_ratio_small where ap_regno='" + Request.QueryString["regno"] + "'" + 
					" and jns_lap != 'Proyeksi' and jml_bln = 12 and posisi_tgl < getdate() " +
					" order by posisi_tgl desc " ;
				}
				else
				{
					conn.QueryString="select top 1 * from ca_ratio_middle where ap_regno='" + Request.QueryString["regno"] + "'" +
						" and reporttype != 'Proyeksi' and numberofmonth = 12 and date_periode < getdate() " +
						" order by date_periode desc ";
				}*/
				conn.QueryString = "exec SP_CA_RATIO '" + LBL_REGNO.Text + "'";
				conn.ExecuteQuery();
				TXT_PROSEN_SALES_INCREASE.Text=conn.GetFieldValue("sales_increase");
				
				/*
				conn.QueryString = "exec SP_CA_LABARUGI '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
				double laba_bersih = 0;
				try { laba_bersih = Convert.ToDouble(conn.GetFieldValue("IS_LABA_BRSH")); } 
				catch {}
				try { TXT_AVG_NET_PROFIT.Text = Convert.ToString(Convert.ToInt32(Math.Round(laba_bersih/12.0))); } 
				catch {}
				//TXT_AVG_NET_PROFIT.Text=conn.GetFieldValue("average_netprofit");  // salah
				*/

			}			

		}

		//Procedure ini menambahkan nilai "0" di depan strTmp shg length strTmp menjadi intJml
		String Pjg(string strTmp,int intJml)
		{
			for(int i=0;i<=intJml;i++)
			{
				if (i>strTmp.Length)
				{
					strTmp="0"+strTmp;
				}
			}			

			return strTmp;
		}



		//		String Pjg_w_Control(string strTmp,int intJml)
		//		{
		//			if (strTmp.Length <= intJml)
		//			{
		//				for(int i=0;i<=intJml;i++)
		//				{
		//					if (i>strTmp.Length)
		//					{
		//						strTmp="0"+strTmp;
		//					}
		//				}			
		//			}
		//			else 
		//			{  // fields overflow ....
		//
		//				if (intJml == 3 ) strTmp = "999";
		//				else if (intJml == 1 ) strTmp = "9";
		//				else if (intJml == 2 ) strTmp = "99";
		//				else if (intJml == 4 ) strTmp = "9999";
		//				else if (intJml == 5 ) strTmp = "99999";
		//				else if (intJml == 6 ) strTmp = "999999";
		//				else if (intJml == 7 ) strTmp = "9999999";
		//				else if (intJml == 8 ) strTmp = "99999999";
		//				else strTmp = "999999999";
		//			}
		//
		//			return strTmp;
		//		}


		//Procedure ini melakukan penambahan nilai "0" di depan strTmp shg length dari strTmp sama dengan intJml
		//dan juga menghandle nilai strTmp yang overflow(melebihi intJml) dengan memotong panjang strTmp shg sama 
		//dgn panjang intJml dan juga mengkonversi nilai strTmp yang sign sesuai dengan kaidah EBCIDC 
		String Pjg_w_Control(string strTmp,int intJml)
		{
			if (strTmp.Length <= intJml)
			{
				for(int i=0;i<=intJml;i++)
				{
					if (i>strTmp.Length)
					{
						strTmp="0"+strTmp;
					}
				}			
			}
			else 
			{  // fields overflow ....
				int lenStr=strTmp.Length;
				string sLst=strTmp.Substring(lenStr-1,1);
				if (sLst=="{"||sLst=="A"||sLst=="B"||sLst=="C"||sLst=="D"||sLst=="E"||sLst=="F"||sLst=="G"||sLst=="H"||sLst=="I")
				{
					if (intJml == 1 ) strTmp = "I";
					else if (intJml == 2 ) strTmp = "9I";
					else if (intJml == 3 ) strTmp = "99I";
					else if (intJml == 4 ) strTmp = "999I";
					else if (intJml == 5 ) strTmp = "9999I";
					else if (intJml == 6 ) strTmp = "99999I";
					else if (intJml == 7 ) strTmp = "999999I";
					else if (intJml == 8 ) strTmp = "9999999I";
					else strTmp = "99999999I";
				}
				else if (sLst=="}"||sLst=="J"||sLst=="K"||sLst=="L"||sLst=="M"||sLst=="N"||sLst=="O"||sLst=="P"||sLst=="Q"||sLst=="R")
				{
					if (intJml == 1 ) strTmp = "R";
					else if (intJml == 2 ) strTmp = "9R";
					else if (intJml == 3 ) strTmp = "99R";
					else if (intJml == 4 ) strTmp = "999R";
					else if (intJml == 5 ) strTmp = "9999R";
					else if (intJml == 6 ) strTmp = "99999R";
					else if (intJml == 7 ) strTmp = "999999R";
					else if (intJml == 8 ) strTmp = "9999999R";
					else strTmp = "99999999R";
				}
				else
				{
					if (intJml == 1 ) strTmp = "9";
					else if (intJml == 2 ) strTmp = "99";
					else if (intJml == 3 ) strTmp = "999";
					else if (intJml == 4 ) strTmp = "9999";
					else if (intJml == 5 ) strTmp = "99999";
					else if (intJml == 6 ) strTmp = "999999";
					else if (intJml == 7 ) strTmp = "9999999";
					else if (intJml == 8 ) strTmp = "99999999";
					else strTmp = "999999999";
				}
			}
			return strTmp;
		}



		//Procedure ini melakukan penambahan nilai " " (spasi kosong) 
		//di belakang strTmp shg length dari strTmp sama dengan intJml
		String Pjg_space(string strTmp,int intJml)
		{
			for(int i=0;i<=intJml;i++)
			{
				if (i>strTmp.Length)
				{
					strTmp=strTmp+" ";
				}
			}			

			return strTmp;
		}


		//Procedure ini menambahkan nilai " " (spasi kosong) sehingga panjangnya menjadi intJml
		String IsiBlank(int intJml)
		{
			String strTmp="";
			for(int i=0;i<intJml;i++)
			{
				strTmp=strTmp+ " ";
			}
			return strTmp;
		}

		String IsiBintang(int intJml)
		{
			String strTmp="";
			for(int i=0;i<intJml;i++)
			{
				strTmp=strTmp+ "*";
			}
			return strTmp;
		}

		//Fungsi ini melakukan konversi dari suatu nilai sign number menjadi EBCDIC number
		//Contoh : -85691 menjadi 8569J (Keterangan lebih lanjut ada pada document pendamping DD STW
		string CovToEBCDIC(string strTemp)
		{
			string strX;
			double dblX;

			if ((strTemp == null) || (strTemp == "")) strTemp = "0";
			// strX = tool.ConvertFloat(strTemp);
			try 
			{
				dblX = Double.Parse(strTemp);			
				strX = strTemp;
			}
			catch 
			{
				strX = "0";
				dblX = 0;
			}
			

			if (dblX >=0)
			{
				if(strX.Substring(strX.Length-1,1).Equals("0"))
					strX=strX.Substring(0,strX.Length-1)+"{";
				else if (strX.Substring(strX.Length-1,1).Equals("1"))
					strX=strX.Substring(0,strX.Length-1)+"A";
				else if (strX.Substring(strX.Length-1,1).Equals("2"))
					strX=strX.Substring(0,strX.Length-1)+"B";
				else if (strX.Substring(strX.Length-1,1).Equals("3"))
					strX=strX.Substring(0,strX.Length-1)+"C";
					//strX.Replace(strX.Substring(strX.Length-1,1),"C");
				else if (strX.Substring(strX.Length-1,1).Equals("4"))
					strX=strX.Substring(0,strX.Length-1)+"D";
				else if (strX.Substring(strX.Length-1,1).Equals("5"))
					strX=strX.Substring(0,strX.Length-1)+"E";
				else if (strX.Substring(strX.Length-1,1).Equals("6"))
					strX=strX.Substring(0,strX.Length-1)+"F";
				else if (strX.Substring(strX.Length-1,1).Equals("7"))
					strX=strX.Substring(0,strX.Length-1)+"G";
				else if (strX.Substring(strX.Length-1,1).Equals("8"))
					strX=strX.Substring(0,strX.Length-1)+"H";
				else if (strX.Substring(strX.Length-1,1).Equals("9"))
					strX=strX.Substring(0,strX.Length-1)+"I";
			}
			else if(dblX<0)
			{
				if(strX.Substring(strX.Length-1,1).Equals("0"))
					strX=strX.Substring(1,strX.Length-2)+"}";
				else if (strX.Substring(strX.Length-1,1).Equals("1"))
					strX=strX.Substring(1,strX.Length-2)+"J";
				else if (strX.Substring(strX.Length-1,1).Equals("2"))
					strX=strX.Substring(1,strX.Length-2)+"K";
				else if (strX.Substring(strX.Length-1,1).Equals("3"))
					strX=strX.Substring(1,strX.Length-2)+"L";
					//strX.Replace(strX.Substring(strX.Length-1,1),"C");
				else if (strX.Substring(strX.Length-1,1).Equals("4"))
					strX=strX.Substring(1,strX.Length-2)+"M";
				else if (strX.Substring(strX.Length-1,1).Equals("5"))
					strX=strX.Substring(1,strX.Length-2)+"N";
				else if (strX.Substring(strX.Length-1,1).Equals("6"))
					strX=strX.Substring(1,strX.Length-2)+"O";
				else if (strX.Substring(strX.Length-1,1).Equals("7"))
					strX=strX.Substring(1,strX.Length-2)+"P";
				else if (strX.Substring(strX.Length-1,1).Equals("8"))
					strX=strX.Substring(1,strX.Length-2)+"Q";
				else if (strX.Substring(strX.Length-1,1).Equals("9"))
					strX=strX.Substring(1,strX.Length-2)+"R";
			}
			return strX;
		}


		/* Generasi string untuk dikirim ke Strategy Ware sesuai dengan Data Dictionary */
		private bool CreateTextFile()
		{
			//StreamWriter Sw;
			String tTxt,sql,strSmall;
			int iThn,iBln;

			tTxt="";

			//tTxt=tTxt+"START OF FILE--";

			//DSS
			
			///	// --start -- by ashari 20041227
			//	//panggil fungsi DSSHeader dari class DSSHeader 
			SME.Scoring.clsDSSHeader objDSSHeader = new SME.Scoring.clsDSSHeader(conn, (string)Request.QueryString["regno"], (string)Request.QueryString["curef"]);
			tTxt=objDSSHeader.addDSSHeader("S");
			//	// --end -- by ashari 20041227


			//Bagian Header 

			//INP-SYSTEM-ID
			//tTxt=tTxt+"--INP-SYSTEM-ID--";
			tTxt=tTxt+="BM2";
			//INP-KEY-GRP-VAL
			//tTxt=tTxt+"--INP-KEY-GRP-VAL--";
			tTxt=tTxt + "9999";
			//INP-KEY-INQY-ID
			//tTxt=tTxt+"--INP-KEY-INQY-ID--";
			tTxt=tTxt + Pjg(Request.QueryString["regno"],20);
			//INP-REL-CB-NBR
			//tTxt=tTxt+"--INP-REL-CB-NBR--";
			tTxt=tTxt + "01";
			//INP-INP-SPID
			//tTxt=tTxt+"--INP-INP-SPID--";
			tTxt=tTxt + "0000";
			//INP-FUNCTION
			//tTxt=tTxt+"--INP-FUNCTION--";
			tTxt=tTxt + "01";

			//INP-SAMP-DIGITS
			//tTxt=tTxt+"--INP-SAMP-DIGITS--";
			tTxt=tTxt + "00";
			//INP-DIGITS-ASSIGNED-IND
			//tTxt=tTxt+"--INP-DIGITS-ASSIGNED-IND--";
			tTxt=tTxt + "N";
			//INP-BUS-UNIT
			//tTxt=tTxt+"--INP-BUS-UNIT--";
			tTxt=tTxt + IsiBlank(20);
			//INP-DATE-PROCESSED
			string strDate,strTime;
			DateTime a=DateTime.Now; 
			strDate = a.Year.ToString()  + Pjg(a.Month.ToString(),2)+ Pjg(a.Day.ToString(),2);
			//tTxt=tTxt+"--INP-DATE-PROCESSED--";
			tTxt=tTxt + strDate;
			//INP-TIME-PROCESSED
			strTime=Pjg(a.Hour.ToString(),2)+Pjg(a.Minute.ToString(),2)+Pjg(a.Second.ToString(),2)+a.Millisecond.ToString().Substring(a.Millisecond.ToString().Length-2,2); 
			//tTxt=tTxt+"--INP-TIME-PROCESSED--";
			tTxt=tTxt + strTime;
			//INP-SOUCE-CD
			//tTxt=tTxt+"--INP-SOUCE-CD--";
			tTxt=tTxt + IsiBlank(8);
			//INP-NBR-RTRN-RULE-SETS
			//tTxt=tTxt+"--INP-NBR-RTRN-RULE-SETS--";
			tTxt=tTxt + "20";
			//INP-NBR-RTRN-DECSN-SCEN
			//tTxt=tTxt+"--INP-NBR-RTRN-DECSN-SCEN--";
			tTxt=tTxt + "20";
			//INP-NBR-RTRN-PRICING-SCEN
			//tTxt=tTxt+"--INP-NBR-RTRN-PRICING-SCEN--";
			tTxt=tTxt + "20";
			//INP-NBR-RTRN-SCORING-SCEN
			//tTxt=tTxt+"--INP-NBR-RTRN-SCORING-SCEN--";
			tTxt=tTxt + "20";
			//INP-RTRN-ATTR-START
			//tTxt=tTxt+"--INP-RTRN-ATTR-START--";
			tTxt=tTxt + "01701";
			//INP-RTRN-ATTR-LENGTH
			//tTxt=tTxt+"--INP-RTRN-ATTR-LENGTH--";
			tTxt=tTxt + "01000";
			//FILLER ---------
			//tTxt=tTxt+"--FILLER--";
			tTxt=tTxt + IsiBlank(72);
			//-- END HEADER ----
			//BEGIN OTHER FIELD
			//tTxt=tTxt+"--OTHFIELD--";
			tTxt=tTxt + IsiBlank(1107);
			//INP-ATTR-AREA-LENGTH
			//tTxt=tTxt+"--INP-ATTR-AREA-LENGTH--";
			tTxt=tTxt + "03000";
			//END OTHER FIELD
			

			conn.QueryString="select * from vw_cek_smdm where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if(conn.GetFieldValue("businessunit")=="SM100")
			{strSmall="1";}
			else
			{strSmall="0";}


			

			sql="select *,datediff(m,mulai_usaha,getdate()) as Diff_Month_Mulai_Usaha,isnull(datediff(m,MULAI_MENETAP,getdate()),0) as Diff_Month_Mulai_Menetap from scoring_infoumum where ap_regno='" + Request.QueryString["regno"] + "'";
			//sql="select * from scoring_infoumum where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DataTable dt1 = conn.GetDataTable().Copy();
			if (dt1.Rows.Count == 0) 
			{
				
				GlobalTools.popMessage(this, "Data Informasi Umum belum lengkap!");
				return false;
				
			}

			

			/////////////////////////////////////////////////////
			///	NERACA
			///	
			//			sql = "select * from ca_neraca_small where ap_regno= '" + Request.QueryString["regno"] + "' " +
			//				" and is_proyeksi <> '1' and year(posisi_tgl) = (" +
			//				" select max(year(posisi_tgl)) from ca_neraca_small where ap_regno= '" + Request.QueryString["regno"] +"'" +
			//				" and is_proyeksi <> '1' )";

			sql = "exec SP_CA_NERACA '" + Request.QueryString["regno"] + "'";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DataTable dt2 = conn.GetDataTable().Copy();
			if (dt2.Rows.Count == 0) 
			{
				GlobalTools.popMessage(this, "Data Neraca belum lengkap!");
				return false;
			}



			///////////////////////////////////////////////////////
			///	LABA-RUGI
			///	
			//			sql = "select * from ca_labarugi_small where ap_regno= '" + Request.QueryString["regno"] + "'" +
			//					" and year(posisi_tgl) = (" +
			//					" select max(year(posisi_tgl)) from ca_labarugi_small where ap_regno = '" + Request.QueryString["regno"] + "'" +
			//					" and is_proyeksi <> '1')";

			sql = "exec SP_CA_LABARUGI '" + Request.QueryString["regno"] + "'";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DataTable dt3 = conn.GetDataTable().Copy();
			if (dt3.Rows.Count == 0) 
			{
				GlobalTools.popMessage(this, "Data Laba-Rugi belum lengkap!");
				return false;
			}
			double vIS_LABA_BRSH = 0;
			try { vIS_LABA_BRSH = Convert.ToDouble(conn.GetFieldValue(dt3, 0, "IS_LABA_BRSH")); } 
			catch {}		
		
			/****
			if (strSmall=="1" )
			{
				sql="select SALES_TO_WK_CAPITAL,DEBT_TO_NETWORTH,CURRENT_RATIO,BUSINESS_DEBT_SERVICE_RATIO,TRADE_CYCLE,isnull(SALES_INCREASE,0) as SALES_INCREASE,isnull(NETINCOME_INCREASE,0) as NETINCOME_INCREASE,isnull(AVERAGE_NETPROFIT,0) as AVERAGE_NETPROFIT  from CA_ratio_SMALL where ap_regno = '" + Request.QueryString["regno"] + "' and JML_BLN = 12 " +
					" and (is_proyeksi is null or rtrim(ltrim(is_proyeksi)) = ''   OR RTRIM(LTRIM(IS_PROYEKSI)) = '0' ) " + 
					"and year(posisi_tgl) = (select max(year(posisi_tgl)) from CA_ratio_SMALL where " + 
					" ap_regno = '" + Request.QueryString["regno"] + "'" +
					" and (is_proyeksi is null or rtrim(ltrim(is_proyeksi)) = ''   OR RTRIM(LTRIM(IS_PROYEKSI)) = '0' )  )";
			}
			else
			{
				sql="select  top 1 SALES_TO_WK_CAPITAL,DEBT_TO_NETWORTH,CURRENT_RATIO," + 
					" BUSINESS_DEBT_SERV_RATIO as BUSINESS_DEBT_SERVICE_RATIO ,DAYS_TC as TRADE_CYCLE,isnull(SALES_INCREASE,0) as SALES_INCREASE,isnull(NETINCOME_INCREASE,0) as NETINCOME_INCREASE,isnull(AVERAGE_NETPROFIT,0) as AVERAGE_NETPROFIT   from CA_ratio_MIDDLE where ap_regno = '" + Request.QueryString["regno"] + "' and NUMBEROFMONTH = 12 " +
					" and (is_proyeksi is null or rtrim(ltrim(is_proyeksi)) = ''  OR RTRIM(LTRIM(IS_PROYEKSI)) = '0' ) " + 
					"and year(DATE_PERIODE) = (select max(year(DATE_PERIODE)) from CA_ratio_MIDDLE  where " + 
					"ap_regno = '" + Request.QueryString["regno"] + 
					"' and (is_proyeksi is null or rtrim(ltrim(is_proyeksi)) = ''  OR RTRIM(LTRIM(IS_PROYEKSI)) = '0' ))";
			}
			*/

			conn.QueryString = "exec SP_CA_RATIO '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			DataTable dt4 = conn.GetDataTable().Copy();
			if (dt4.Rows.Count == 0) 
			{
				GlobalTools.popMessage(this, "Data Ratio Keuangan belum lengkap atau \\nTidak terdapat jumlah bulan 12 bulan!");
				return false;
			}




			//DT5 watchlist
			sql="select cu_inwatchlist = case when isnull(cu_inwatchlist,'0') = '0' then 'N' else 'Y' end " + 
				" from customer where cu_ref='" + Request.QueryString["curef"] + "'";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DataTable dt5 = conn.GetDataTable().Copy();



			//sql = "select datediff(m,Cast(MULAI_BM_MM as varchar)+'/01/'+ cast(MULAI_BM_YY as varchar),getdate()) as Diff_Month_Mulai_NasabahBM,* from scoring_hubbank  where ap_regno='" + Request.QueryString["regno"] + "'";

			/* Mask Out .... get direct from source as Yudi -----
			sql = "select * from scoring_hubbank  where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.QueryString = sql;
			conn.ExecuteQuery();

			DataTable dt5 = conn.GetDataTable().Copy();
			if (dt5.Rows.Count == 0) 
			{
				GlobalTools.popMessage(this, "Data Hubungan Dengan Bank belum lengkap!");
				return false;
			}
			*/
			
			//20090325 tambahan scoring EBITDA
			//DT6 Additional
			sql="SELECT * FROM VW_SCORING_INFOUMUM_ADDITIONALDATA WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DataTable dt6 = conn.GetDataTable().Copy();
			

			/*
			//A0001 - Total Exposure
			//tTxt=tTxt+"--A0001--";
			if (Convert.ToString(Math.Round(Double.Parse(conn.GetFieldValue(dt5,0,"TTL_EXP_MILL")))).Length > 8)
			{
				tTxt=tTxt + "99999999";
			}
			else
			{
				tTxt=tTxt+ Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt5,0,"TTL_EXP_MILL"))).ToString(),8);
			}
			*/
			//A0001 - Total Exposure
			double existingExposure;
			double appValue;

			conn.QueryString = "FAIRISAAC_EXISTINGEXPOSURE '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				existingExposure =  Convert.ToDouble(conn.GetFieldValue("existing_exposure"));	
				
			}
			else existingExposure = 0;

			conn.QueryString = "DE_TOTALEXPOSURE '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery(300);
			if (conn.GetRowCount() > 0) 
			{
				appValue =  Convert.ToDouble(conn.GetFieldValue("tot_limit"));	
				
			}
			else appValue = 0;

			//int SendValue = Convert.ToInt32(Math.Round((appValue + existingExposure)/1000.0));
			long SendValue = 0; 
			try { SendValue = Convert.ToInt64(Math.Round((appValue + existingExposure)/1000.0)); } 
			catch {}

			if (Convert.ToString(SendValue).Length > 8)
			{
				tTxt=tTxt + "99999999";
			}
			else
			{
				tTxt=tTxt+ Pjg(Convert.ToString(SendValue),8);
			}		
			


			//A0002 - Type of Request
			//tTxt=tTxt+"--A0002--";
			if (conn.GetRowCount(dt1) > 0 ) 
				tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"JENIS_PERMOHONAN"),1);
			else 
				tTxt=tTxt + "9";  // tolong ubah

			//A0003 - Requested Product
			//tTxt=tTxt+"--A0003--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"JENIS_KREDIT"), 2);

			//A0004 - Contractor requested
			//tTxt=tTxt+"--A0004--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"CONTRACTOR_TYPE"), 1);

			//A0005 - Credit Scheme
			//tTxt=tTxt+"--A0005--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"SKEMA_KREDIT"), 2);

			//A0006 - Existing Product
			//tTxt=tTxt+"--A0006--";
			//tTxt=tTxt + conn.GetFieldValue(dt1,0,"PRODUCT_EXISTING"); //ahmad
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"PRODUCT_EXISTING"), 2);

			//A0007 - Existing Exposure
			//tTxt=tTxt+"--A0007--";
			//tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"LMT_CREDIT_CURR"),8);
			//double appValue = Convert.ToDouble(conn.GetFieldValue(dt5, 0, "LMT_CREDIT_CURR_MILL"));
			//double totalExposure = Convert.ToDouble(conn.GetFieldValue(dt5, 0, "TTL_EXP_MILL"));
			//total exposure
			try { SendValue = Convert.ToInt32(Math.Round(existingExposure / 1000.0));  }
			catch {}

			
			tTxt=tTxt + Pjg_w_Control(SendValue.ToString(),8);			

			//A0008 - Additional Collateral Flag
			//tTxt=tTxt+"--A0008--";
			tTxt=tTxt + conn.GetFieldValue(dt1,0,"JAMINAN_TAMBAHAN");

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(175);


			//ahmad: sampe sini
			
			
			//A0201 - Number of Children of Main Owner
			//tTxt=tTxt+"--A0201--";
			if ((conn.GetFieldValue(dt1,0,"JML_ANAK")== null )||(conn.GetFieldValue(dt1,0,"JML_ANAK")==""))
			{
				tTxt=tTxt+"99";
			}
			else
			{
				tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"JML_ANAK"),2);
			}

			//A0202 - Sex of Main Owner
			//tTxt=tTxt+"--A0202--";
			tTxt=tTxt + conn.GetFieldValue(dt1,0,"JENIS_KELAMIN");

			//A0203 - Time at Residence of Main Owner (yymm)
			//tTxt=tTxt+"--A0203--";
			string strBulan;
			if (conn.GetFieldValue(dt1,0,"MULAI_MENETAP") == null || conn.GetFieldValue(dt1,0,"MULAI_MENETAP") == "" )
			{
				tTxt=tTxt+"9999";
			}
			else
			{
				//				tTxt=tTxt + GlobalTools.FormatDate_Year(conn.GetFieldValue(dt1,0,"MULAI_MENETAP")).Substring(2,2); 
				//				strBulan = GlobalTools.FormatDate_Month(conn.GetFieldValue(dt1,0,"MULAI_MENETAP"));
				//				if (strBulan.Length==1) {strBulan="0"+strBulan;}
				//				tTxt=tTxt + strBulan;
				try { iThn=Convert.ToInt32(conn.GetFieldValue(dt1,0,"Diff_Month_Mulai_Menetap"))/12; } 
				catch { iThn = 0; }
				try { iBln=Convert.ToInt32(conn.GetFieldValue(dt1,0,"Diff_Month_Mulai_Menetap"))%12; } 
				catch { iBln = 0; }
				tTxt=tTxt+Pjg_w_Control(iThn.ToString(),2);
				tTxt=tTxt+Pjg_w_Control(iBln.ToString(),2);
			}


			//tTxt=tTxt + strBulan;
			//A0204 - Years as BM customer
			//tTxt=tTxt+"--A0204--";
			//			tTxt=tTxt + Pjg((conn.GetFieldValue(dt5,0,"MULAI_BM_YY")),2); // year
			//			tTxt=tTxt + Pjg((conn.GetFieldValue(dt5,0,"MULAI_BM_MM")),2); // month
			//			if (conn.GetFieldValue(dt5,0,"MULAI_BM_YY") == null || conn.GetFieldValue(dt5,0,"MULAI_BM_YY") == "" )
			//			{
			//				tTxt=tTxt+"9999";
			//			}
			//			else
			//			{
			//				iThn=Convert.ToInt32(conn.GetFieldValue(dt5,0,"Diff_Month_Mulai_NasabahBM"))/12;
			//				iBln=Convert.ToInt32(conn.GetFieldValue(dt5,0,"Diff_Month_Mulai_NasabahBM"))%12;
			//				tTxt=tTxt+Pjg(iThn.ToString(),2);
			//				tTxt=tTxt+Pjg(iBln.ToString(),2);
			//			}
			if (conn.GetFieldValue(dt1,0,"LAMA_NASABAH_BM") == null || conn.GetFieldValue(dt1,0,"LAMA_NASABAH_BM") == "" )
			{
				tTxt=tTxt+"9999";
			}
			else
			{
				tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"LAMA_NASABAH_BM"),4);		// customer baru, maka 0000
			}

			//A0205 - Age of Business (yymm)
			//tTxt=tTxt+"--A0205--";
			if (conn.GetFieldValue(dt1,0,"MULAI_USAHA") == null || conn.GetFieldValue(dt1,0,"MULAI_USAHA") == "" )
			{
				tTxt=tTxt+"9999";
			}
			else
			{
				//				tTxt=tTxt + GlobalTools.FormatDate_Year(conn.GetFieldValue(dt1,0,"MULAI_USAHA")).Substring(2,2); 
				//				strBulan = GlobalTools.FormatDate_Month(conn.GetFieldValue(dt1,0,"MULAI_USAHA"));
				//				if (strBulan.Length==1) {strBulan="0"+strBulan;}
				//				tTxt=tTxt + strBulan;
				try { iThn=Convert.ToInt32(conn.GetFieldValue(dt1,0,"Diff_Month_Mulai_Usaha"))/12; } 
				catch { iThn = 0; }
				try { iBln=Convert.ToInt32(conn.GetFieldValue(dt1,0,"Diff_Month_Mulai_Usaha"))%12; } 
				catch { iBln = 0; }
				tTxt=tTxt+Pjg_w_Control(iThn.ToString(),2);
				tTxt=tTxt+Pjg_w_Control(iBln.ToString(),2);
			}

			//A0206 - Sales (Millions)
			//tTxt=tTxt+"--A0206--";			
			//if (conn.GetFieldValue(dt3,0,"IS_PENJ") == null || conn.GetFieldValue(dt3,0,"IS_PENJ") == "" )
			if (conn.GetFieldValue(dt1,0,"IU_PSRL_PENJUALANTAHUNAN_SATUAN") == null || 
				conn.GetFieldValue(dt1,0,"IU_PSRL_PENJUALANTAHUNAN_SATUAN") == "" )
			{
				tTxt=tTxt+"99999999";
			}
			else if(Convert.ToString(Math.Abs(Convert.ToInt64(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_PSRL_PENJUALANTAHUNAN_SATUAN")))))).Length > 8)
			{
				tTxt=tTxt + "99999998";
			}
			else
			{
				//tTxt=tTxt + Pjg((conn.GetFieldValue(dt3,0,"IS_PENJ")),8);
				double vIU_PSRL_PENJUALANTAHUNAN_SATUAN = 0;
				long vIU_PSRL_PENJUALANTAHUNAN_SATUAN_int = 0;
				try { vIU_PSRL_PENJUALANTAHUNAN_SATUAN = Convert.ToDouble(conn.GetFieldValue(dt1,0,"IU_PSRL_PENJUALANTAHUNAN_SATUAN"));  }
				catch {}
				try { vIU_PSRL_PENJUALANTAHUNAN_SATUAN_int = Convert.ToInt64(Math.Round(vIU_PSRL_PENJUALANTAHUNAN_SATUAN,0)); } 
				catch {}
				tTxt=tTxt + Pjg(vIU_PSRL_PENJUALANTAHUNAN_SATUAN_int.ToString(),8);
			}


			//A0207 - Total Liabilities (Millions)
			//tTxt=tTxt+"--A0207--";			
			//if (conn.GetFieldValue(dt2,0,"PASV_TTLHT") == null || conn.GetFieldValue(dt2,0,"PASV_TTLHT") == "" )
			if (conn.GetFieldValue(dt1,0,"IU_HUTANG_SATUAN") == null || 
				conn.GetFieldValue(dt1,0,"IU_HUTANG_SATUAN") == "" )
			{
				tTxt=tTxt+"99999999";
			}
			else if(Convert.ToString(Math.Abs(Convert.ToInt64(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_HUTANG_SATUAN")))))).Length > 8)
			{
				tTxt=tTxt + "99999998";
			}
			else
			{
				//tTxt=tTxt + Pjg((conn.GetFieldValue(dt2,0,"PASV_TTLHT")),8);
				double vIU_HUTANG_SATUAN = 0;
				long vIU_HUTANG_SATUAN_int = 0;
				try { vIU_HUTANG_SATUAN = Convert.ToDouble(conn.GetFieldValue(dt1,0,"IU_HUTANG_SATUAN")); } 
				catch {}
				try { vIU_HUTANG_SATUAN_int = Convert.ToInt64(Math.Round(vIU_HUTANG_SATUAN,0)); } 
				catch {}
				tTxt=tTxt + Pjg(vIU_HUTANG_SATUAN_int.ToString(),8);
			}



			//A0208 - Cash 
			//tTxt=tTxt+"--A0208--";			
			//if (conn.GetFieldValue(dt2,0,"AKTV_KASBANK") == null || conn.GetFieldValue(dt2,0,"AKTV_KASBANK") == "" )
			if (conn.GetFieldValue(dt1,0,"IU_PSN_KASBANK") == null || 
				conn.GetFieldValue(dt1,0,"IU_PSN_KASBANK") == "" )
			{
				tTxt=tTxt+"99999999";
			}
			else if(Convert.ToString(Math.Abs(Convert.ToInt64(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_PSN_KASBANK")))))).Length > 8)
			{
				tTxt=tTxt + "99999998";
			}
			else
			{
				double vIU_PSN_KASBANK = 0;
				long vIU_PSN_KASBANK_int = 0;
				try { vIU_PSN_KASBANK = Convert.ToDouble(conn.GetFieldValue(dt1,0,"IU_PSN_KASBANK")); } 
				catch {}
				try { vIU_PSN_KASBANK_int = Convert.ToInt64(Math.Round(vIU_PSN_KASBANK,0)); } 
				catch {}
				tTxt=tTxt + Pjg(vIU_PSN_KASBANK_int.ToString(),8);
			}


			//A0209 - Company Legal Type 
			//tTxt=tTxt+"--A0209--";
			tTxt=tTxt + conn.GetFieldValue(dt1,0,"JNS_USAHA");


			//A0210 - Current Assets (Millions)
			//tTxt=tTxt+"--A0210--";
			//if (conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == null || conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == "" )
			if (conn.GetFieldValue(dt1,0,"IU_PSN_TTLAKTIVALCR_SATUAN") == null || 
				conn.GetFieldValue(dt1,0,"IU_PSN_TTLAKTIVALCR_SATUAN") == "" )
			{
				tTxt=tTxt+"99999999";
			}

			else if(Convert.ToString(Math.Abs(Convert.ToInt64(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_PSN_TTLAKTIVALCR_SATUAN")))))).Length > 8)
			{
				tTxt=tTxt + "99999998";
			}
			
			else 
			{
				double vIU_PSN_TTLAKTIVALCR_SATUAN = 0.0;
				long vIU_PSN_TTLAKTIVALCR_SATUAN_int = 0;
				try { vIU_PSN_TTLAKTIVALCR_SATUAN = Convert.ToDouble(conn.GetFieldValue(dt1,0,"IU_PSN_TTLAKTIVALCR_SATUAN")); } 
				catch {}
				try { vIU_PSN_TTLAKTIVALCR_SATUAN_int = Convert.ToInt64(Math.Round(vIU_PSN_TTLAKTIVALCR_SATUAN, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(vIU_PSN_TTLAKTIVALCR_SATUAN_int.ToString(),8);
			}

			

			//A0211 - Net Worth 
			//tTxt=tTxt+"--A0211--";
			//if (conn.GetFieldValue(dt2,0,"PASV_TTLMODAL") == null || conn.GetFieldValue(dt2,0,"PASV_TTLMODAL") == "" )
			if (conn.GetFieldValue(dt1,0,"IU_TOTMODAL") == null || 
				conn.GetFieldValue(dt1,0,"IU_TOTMODAL") == "" )
			{
				//tTxt=tTxt+"99999999"; //ahmad: panjangnya 7 bukan 8
				tTxt=tTxt+"9999999";
			}
			else if(Convert.ToString(Math.Abs(Convert.ToInt64(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_TOTMODAL")))))).Length > 7)
			{
				if (Double.Parse(conn.GetFieldValue(dt1,0,"IU_TOTMODAL"))>=0)
				{
					tTxt=tTxt + CovToEBCDIC("9999998");
				}
				else
				{
					tTxt=tTxt + CovToEBCDIC("-9999999");
				}
			}

			else
			{
				//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_TOTMODAL_SATUAN"))).ToString()),7);
				double vIU_TOTMODAL = 0.0;
				long vIU_TOTMODAL_int = 0;
				try { vIU_TOTMODAL = Convert.ToDouble(conn.GetFieldValue(dt1,0,"IU_TOTMODAL")); } 
				catch {}
				try { vIU_TOTMODAL_int = Convert.ToInt64(Math.Round(vIU_TOTMODAL, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(CovToEBCDIC(vIU_TOTMODAL_int.ToString()),7);
			}

			

			//A0212 - Sales / Working Capital %
			//tTxt=tTxt+"--A0212--";
			double AKTV_TTLAKTLCR = 0;
			double PASV_HTLNCR = 0;
			try {AKTV_TTLAKTLCR = Double.Parse(conn.GetFieldValue(dt2,0, "AKTV_TTLAKTLCR"));}
			catch {}
			try { PASV_HTLNCR = Double.Parse(conn.GetFieldValue(dt2,0, "PASV_HTLNCR")); }
			catch {}
			if(conn.GetFieldValue(dt3,0,"IS_PENJ") == null || conn.GetFieldValue(dt3,0,"IS_PENJ") == "" ) 
			{tTxt=tTxt+ "9995";}
			else if(conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == null || conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == "" || 
				conn.GetFieldValue(dt2,0,"PASV_HTLNCR") == null || conn.GetFieldValue(dt2,0,"PASV_HTLNCR") == "")
			{tTxt=tTxt+ "9996";}
			else if((conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == null || conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == "") && 
				(conn.GetFieldValue(dt2,0,"PASV_HTLNCR") == null || conn.GetFieldValue(dt2,0,"PASV_HTLNCR") == ""))
			{tTxt=tTxt+ "9997";}
			else if (AKTV_TTLAKTLCR - PASV_HTLNCR == 0)
			{tTxt=tTxt+ "9998";}
			else if (conn.GetFieldValue(dt4,0,"SALES_TO_WK_CAPITAL") == null || conn.GetFieldValue(dt4,0,"SALES_TO_WK_CAPITAL") == "")
			{tTxt=tTxt+ "9999";}
			else
			{
				if (Convert.ToString(Math.Abs(Convert.ToInt64(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"SALES_TO_WK_CAPITAL"))*100)))).Length > 4)
				{
					if (Double.Parse(conn.GetFieldValue(dt4,0,"SALES_TO_WK_CAPITAL"))>=0)
					{
						tTxt=tTxt + CovToEBCDIC("9994");
					}
					else
					{
						tTxt=tTxt + CovToEBCDIC("-9999");
					}
				}
				else
				{
					double vSALES_TO_WK_CAPITAL = 0.0;
					long vSALES_TO_WK_CAPITAL_int = 0;
					try { vSALES_TO_WK_CAPITAL = Convert.ToDouble(conn.GetFieldValue(dt4,0,"SALES_TO_WK_CAPITAL")); } 
					catch {}
					vSALES_TO_WK_CAPITAL = vSALES_TO_WK_CAPITAL * 100;
					try { vSALES_TO_WK_CAPITAL_int = Convert.ToInt64(Math.Round(vSALES_TO_WK_CAPITAL, 0)); } 
					catch {}
					tTxt=tTxt + Pjg(CovToEBCDIC(vSALES_TO_WK_CAPITAL_int.ToString()),4);
				}
			}



			//A0213 - Debt / Net Worth %
			//tTxt=tTxt+"--A0213--";
			if(conn.GetFieldValue(dt1,0,"IU_HUTANG_SATUAN") == null || conn.GetFieldValue(dt1,0,"IU_HUTANG_SATUAN") == "" ) 
			{tTxt=tTxt+ "996";}
			else if(conn.GetFieldValue(dt2,0,"PASV_TTLMODAL") == null || conn.GetFieldValue(dt2,0,"PASV_TTLMODAL") == "" ) 
			{tTxt=tTxt+ "997";}
			else if(Double.Parse(conn.GetFieldValue(dt2,0,"PASV_TTLMODAL")) == 0) 
			{tTxt=tTxt+ "998";}
			else if(conn.GetFieldValue(dt4,0,"DEBT_TO_NETWORTH") == null || conn.GetFieldValue(dt4,0,"DEBT_TO_NETWORTH") == "" ) 
			{tTxt=tTxt+ "997";}
			else 
			{
				int iDnet = 0;
				try { iDnet = Convert.ToInt32(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"DEBT_TO_NETWORTH"))*100)); } 
				catch {}
				if (Convert.ToString(Math.Abs(iDnet)).Length > 3)
				{
					if (Double.Parse(conn.GetFieldValue(dt4,0,"DEBT_TO_NETWORTH"))>=0)
					{
						tTxt=tTxt + CovToEBCDIC("995");
					}
					else
					{
						tTxt=tTxt + CovToEBCDIC("-999");
					}
				}
				else
				{
					//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"DEBT_TO_NETWORTH"))*100).ToString()),3);
					double vDEBT_TO_NETWORTH = 0;
					int vDEBT_TO_NETWORTH_int = 0;
					try { vDEBT_TO_NETWORTH = Convert.ToDouble(conn.GetFieldValue(dt4,0,"DEBT_TO_NETWORTH")); } 
					catch {}
					vDEBT_TO_NETWORTH = vDEBT_TO_NETWORTH * 100;
					try { vDEBT_TO_NETWORTH_int = Convert.ToInt32(Math.Round(vDEBT_TO_NETWORTH, 0)); } 
					catch {}
					tTxt=tTxt + Pjg(CovToEBCDIC(vDEBT_TO_NETWORTH_int.ToString()),3);
				}
			}


			//A0214 - Current Ratio %
			//tTxt=tTxt+"--A0214--";
			if(conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == null || conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == "" ) 
			{tTxt=tTxt+ "996";}
			else if(conn.GetFieldValue(dt2,0,"PASV_TTLHTLNCR") == null || conn.GetFieldValue(dt2,0,"PASV_TTLHTLNCR") == "" )
			{tTxt=tTxt+ "997";}
			else if(Double.Parse(conn.GetFieldValue(dt2,0,"PASV_TTLHTLNCR")) == 0)
			{tTxt=tTxt+ "998";}
			else if(conn.GetFieldValue(dt4,0,"CURRENT_RATIO") == null || conn.GetFieldValue(dt4,0,"CURRENT_RATIO") == "" )
			{tTxt=tTxt+ "999";}
			else 
			{
				if (Convert.ToString(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"CURRENT_RATIO"))*100)).Length > 3)
				{
					tTxt=tTxt + "995";
				}
				else
				{
					//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"CURRENT_RATIO"))*100).ToString(),3);
					double vCURRENT_RATIO = 0;
					double vCURRENT_RATIO_int = 0;
					try { vCURRENT_RATIO  =  Convert.ToDouble(conn.GetFieldValue(dt4,0,"CURRENT_RATIO")); } 
					catch {}
					vCURRENT_RATIO = vCURRENT_RATIO  * 100;
					try { vCURRENT_RATIO_int = Convert.ToInt32(Math.Round(vCURRENT_RATIO, 0)); } 
					catch {}
					tTxt=tTxt + Pjg(vCURRENT_RATIO_int.ToString(),3);
				}

			}

			//A0215 - Business Debt Service Ratio %
			//tTxt=tTxt+"--A0215--";
			if(conn.GetFieldValue(dt3,0,"IS_LABA_BRSH") == null || conn.GetFieldValue(dt3,0,"IS_LABA_BRSH") == "" ) 
			{tTxt=tTxt+ "996";}
			else if(conn.GetFieldValue(dt2,0,"PASV_KIJTHTEMPO") == null || conn.GetFieldValue(dt2,0,"PASV_KIJTHTEMPO") == "" )
			{tTxt=tTxt+ "997";}
			else if(Double.Parse(conn.GetFieldValue(dt2,0,"PASV_KIJTHTEMPO")) == 0)
			{tTxt=tTxt+ "998";}
			else if(conn.GetFieldValue(dt4,0,"BUSINESS_DEBT_SERVICE_RATIO") == null || conn.GetFieldValue(dt4,0,"BUSINESS_DEBT_SERVICE_RATIO") == "" )
			{tTxt=tTxt+ "997";}
			else 
			{
				if (Convert.ToString(Math.Abs(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"BUSINESS_DEBT_SERVICE_RATIO"))*100))).Length>3)
				{
					if(Double.Parse(conn.GetFieldValue(dt4,0,"BUSINESS_DEBT_SERVICE_RATIO"))>=0)
					{
						tTxt=tTxt + CovToEBCDIC("995");
					}
					else
					{
						tTxt=tTxt + CovToEBCDIC("-999");
					}
				}
				else
				{
					//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"BUSINESS_DEBT_SERVICE_RATIO"))*100).ToString()),3);
					double vBUSINESS_DEBT_SERVICE_RATIO = 0;
					int vBUSINESS_DEBT_SERVICE_RATIO_int = 0;
					try { vBUSINESS_DEBT_SERVICE_RATIO = Convert.ToDouble(conn.GetFieldValue(dt4,0,"BUSINESS_DEBT_SERVICE_RATIO")); } 
					catch {}
					vBUSINESS_DEBT_SERVICE_RATIO = vBUSINESS_DEBT_SERVICE_RATIO * 100;
					try { vBUSINESS_DEBT_SERVICE_RATIO_int = Convert.ToInt32(Math.Round(vBUSINESS_DEBT_SERVICE_RATIO, 0)); } 
					catch {}
					tTxt=tTxt + Pjg(CovToEBCDIC(vBUSINESS_DEBT_SERVICE_RATIO_int.ToString()),3);
				}
			}
			
			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(32);

			//A0301 - Legal Lawsuit Flag
			//tTxt=tTxt+"--A0301--";
			tTxt=tTxt + conn.GetFieldValue(dt1,0,"LEGAL_LAWSUIT");



			//A0302 - Existing Working Capital in other bank
			//tTxt=tTxt+"--A0302--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"LIMIT_DIBANKLAIN"))).ToString(),8);
			double vLIMIT_DIBANKLAIN = 0;
			int vLIMIT_DIBANKLAIN_int = 0;
			try { vLIMIT_DIBANKLAIN = Convert.ToDouble(conn.GetFieldValue(dt1,0,"LIMIT_DIBANKLAIN")); } 
			catch {}
			try { vLIMIT_DIBANKLAIN_int = Convert.ToInt32(Math.Round(vLIMIT_DIBANKLAIN, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vLIMIT_DIBANKLAIN_int.ToString(),8);



			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(91);
			
			//A0401 - Age of Primary Owner (yymm)
			//tTxt=tTxt+"--A0401--";
			tTxt=tTxt + Pjg_w_Control(conn.GetFieldValue(dt1,0,"UMUR_OWNER"),4);

			//A0402 - Current PUKK facility from state flag
			//tTxt=tTxt+"--A0402--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"PUKK_CURR"),1);

			//A0403 - Past PUKK facility from state flag
			//tTxt=tTxt+"--A0403--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"PUKK_PAST"),1);

			//A0404 - Any business license flag
			//tTxt=tTxt+"--A0404--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"LISENSI_BISNIS"),1);

			//A0405 - Share - main owner
			//tTxt=tTxt+"--A0405--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"PROSEN_SAHAM"),3);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(190);
			
			//A0601 - Worst 12 Month BM Collectibility on previous/existing loan
			//tTxt=tTxt+"--A0601--";			
			
			

			//applicant 2a,2b,2c,3+			
			string worst_col_12b;  // worst 12 month  A601
			string col_bm_curr;   //  current kolekblitas A602
			string app_col_2a;    //  2a
			string app_col_2b; 
			string app_col_2c;
			string bm_bl_usaha;   // a606
			string app_col_3;     // a609
			
			// pemilik			
			string bm_bl_pemilik;   //a701
			string collbm_curr_pemilik;   // a702			
			string coll_2c_12_pemilik;    // a703
			

			// key person - previously management
			string bm_key_person;  // a801
			string col_bm_mgt;   //a802
			string col_bm_2c;    // a803

			string bi_usaha;       // c001
			string kol_bi_usaha;		//C002
			string bi_bl_pemilik;  // c100
			string kol_bi_pemilik;  // c101

			string bi_key_person;  // c200
			string kol_bi_key;    // c201

			
			conn.QueryString = "select AP_BLBIACCBK, AP_BLBIOCBK, AP_BLBIMCBKS " + 
				"from APPLICATION where AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			

			//Kolektibilitas pemilik saat ini di bank lain (IDI BI) - C101
			try { kol_bi_pemilik = conn.GetFieldValue("AP_BLBIOCBK"); } 
			catch {kol_bi_pemilik  = "0";  }

			
			//C200  Kolektibilitas perusahaan saat ini di bank lain (IDI BI)			
			try { kol_bi_usaha = conn.GetFieldValue("AP_BLBIACCBK"); } 
			catch {kol_bi_usaha = "0"; }

			
			
			//C0100			
			try { kol_bi_key = conn.GetFieldValue("AP_BLBIMCBKS"); } 
			catch { kol_bi_key = "0"; }


			conn.QueryString="select * from VW_BLACKLIST_FI WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0) 
			{
				
				
				bm_bl_usaha =conn.GetFieldValue("AP_BLBMUSAHA");
				bm_bl_pemilik =conn.GetFieldValue("AP_BLBMPEMILIK");				
				bm_key_person =conn.GetFieldValue("AP_BLBMMGMT");

				bi_usaha =conn.GetFieldValue("AP_BLBIUSAHA");				
				bi_bl_pemilik =conn.GetFieldValue("AP_BLBIPEMILIK");			
				bi_key_person =conn.GetFieldValue("AP_BLBIMGMT");
			}
			else 
			{
				bm_bl_usaha = "N";
				bm_bl_pemilik = "N";				
				bm_key_person = "N";

				bi_usaha = "N";
				bi_bl_pemilik = "N";			
				bi_key_person = "N";
			}	 
			
			
			conn.QueryString = "select * from VW_COLLECTIBILITY where cu_ref='"+ Request.QueryString["curef"] +"'";
			conn.ExecuteQuery();			
			
			// A601 - Kolekblistas - Alpha
			try { worst_col_12b = conn.GetFieldValue("COLLBM_WORST_12B");} 
			catch 
			{
				worst_col_12b = "0 ";
			}			

			// A602 - Kolekblistas - Alpha
			try { col_bm_curr = conn.GetFieldValue("COLLBM_CURR_CUST"); } 
			catch 
			{
				col_bm_curr = "0 ";
			}

			

			try {app_col_2a = conn.GetFieldValue("NUM_COLL_2A");}
			catch
			{
				app_col_2a ="0";
			}
			
			try {app_col_2b = conn.GetFieldValue("NUM_COLL_2B");}
			catch
			{
				app_col_2b ="0";
			}
			
			try {app_col_2c = conn.GetFieldValue("NUM_COLL_2C");}
			catch
			{
				app_col_2c ="0";
			}
			
			try {app_col_3 = conn.GetFieldValue("NUM_COLL_3PLUS");}
			catch
			{
				app_col_3 ="0";
			}
			

			

			//Main Owner
			//try {DDL_KEY_BM_COLL.SelectedValue = conn.GetFieldValue("COLL_CURR_KP");}		
			

			try { collbm_curr_pemilik = conn.GetFieldValue("COLLBM_CURR_KP");}
			catch 
			{
				collbm_curr_pemilik = "0 ";
			}

			coll_2c_12_pemilik = conn.GetFieldValue("COLL_2C_12_KP");
			//management
			//try {DDL_MGM_BM_COLL_CURR.SelectedValue = conn.GetFieldValue("COLL_CURR_MGM");}
			
			try { col_bm_mgt = conn.GetFieldValue("COLLBM_CURR_MGMG");}				
			catch 
			{
				col_bm_mgt = "0 ";
			}

			col_bm_2c  = conn.GetFieldValue("COLL_2C_12_MGM");
			
			//601
			if (worst_col_12b.Trim()=="")
			{
				worst_col_12b="0";
			}
			tTxt=tTxt + Pjg_space(worst_col_12b,2);

			//string col_bm_curr;
			//A0602 - Current Collectibility
			//tTxt=tTxt+"--A0602--";
			if (col_bm_curr.Trim()=="")
			{
				col_bm_curr="0";
			}
			tTxt=tTxt + Pjg_space(col_bm_curr,2);
		
			

			//A0603 - Times Collectibility 2A last 12 Months
			//tTxt=tTxt+"--A0603--";
			tTxt=tTxt + Pjg_w_Control(app_col_2a,1);

			//A0604 - Times Collectibility 2B last 12 Months
			//tTxt=tTxt+"--A0604--";
			tTxt=tTxt + Pjg_w_Control(app_col_2b,1);
	            
			//A0605 - Times Collectibility 2C last 12 Months
			//tTxt=tTxt+"--A0605--";
			tTxt=tTxt + Pjg_w_Control(app_col_2c,1);

			//A0606 - Business Currently in Black List at Bank Mandiri
			//tTxt=tTxt+"--A0606--";
			tTxt=tTxt + Pjg_w_Control(bm_bl_usaha ,1);

			//A0607 - Past PUKK loan with BM flag
			//tTxt=tTxt+"--A0607--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"PUKK_PAST_BM").ToString(),1);			

			//A0608 - Watchlist flag
			//tTxt=tTxt+"--A0608--";
			//tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"WATCH_LIST").ToString(),1);
			string myWatchList = conn.GetFieldValue(dt5,0,"CU_INWATCHLIST");
			tTxt=tTxt + myWatchList;
							
			//A0609 - Times Collectibility 3+ last 12 month
			//tTxt=tTxt+"--A0609--";
			tTxt=tTxt + Pjg(app_col_3,1);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(89);


			
			
			//A0701 - Owner Currently in Black LIst at Bank Mandiri
			//tTxt=tTxt+"--A0701--";
			tTxt=tTxt + Pjg(bm_bl_pemilik,1);

			//A0702 - Owner Currently Collectibility at Bank Mandiri
			//tTxt=tTxt+"--A0702--";
			// Koleblistas - A701

			if (collbm_curr_pemilik.Trim()=="")
			{
				collbm_curr_pemilik="0";
			}
			tTxt=tTxt + Pjg_space(collbm_curr_pemilik,2);

			//A0703 - Owner Times Collectibility 2C+ Last 12 Month
			//tTxt=tTxt+"--A0703--";
			tTxt=tTxt + Pjg(coll_2c_12_pemilik,1);

			//A0704 - Home Owned by Customer ?
			//tTxt=tTxt+"--A0704--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0, "IUM_HOMEOWNEDCUST"),1);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(95);
				
			
			

			//A0801 - Management Currently in Black LIst at Bank Mandiri
			//tTxt=tTxt+"--A0801--";
			tTxt=tTxt + Pjg(bm_key_person,1);

			//A0802 - Management Currently Collectibility at Bank Mandiri
			//tTxt=tTxt+"--A0802--";
			//string col_bm_mgt;B
			// Kolekblistas BM - A802
			if (col_bm_mgt.Trim()=="")
			{
				col_bm_mgt="0";
			}
			tTxt=tTxt + Pjg_space(col_bm_mgt,2);

			//A0803 - Management Times Collectibility 2C+ Last 12 Month
			//tTxt=tTxt+"--A0803--";
			tTxt=tTxt + Pjg_w_Control(col_bm_2c,1);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(96);			
			
			
			
			
			//C0001 - Business Currently in Black List at Central Bank 
			//tTxt=tTxt+"--C0001--";
			tTxt=tTxt + Pjg(bi_usaha,1);

			
			
			//C0002 - Business Central Bank Collectibility Level
			//tTxt=tTxt+"--C0002--";
			tTxt=tTxt + Pjg(kol_bi_usaha,1);  // ??? - salah

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(98);		
			
			
			//C0100 - Owner Currently in Black List at Central Bank 
			//tTxt=tTxt+"--C0100--";
			tTxt=tTxt + Pjg(bi_bl_pemilik,1);		


			//C0101 - Owner Central Bank Collectibility Level
			//tTxt=tTxt+"--C0101--";
			tTxt=tTxt + Pjg(kol_bi_pemilik,1);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(98);

			//C0200 - Management Currently in Black List at Central Bank 
			//tTxt=tTxt+"--C0200--";
			tTxt=tTxt + Pjg(bi_key_person,1);

			//C0201 - Management Central Bank Collectibility Level
			//tTxt=tTxt+"--C0201--";
			tTxt=tTxt + Pjg(kol_bi_key,1);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(98);



			//A0901 - Assets : Total Assets 
			//tTxt=tTxt+"--A0901--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt2,0,"AKTV_TTLAKTV"))).ToString(),8);
			
			if(Convert.ToString(Math.Abs(Convert.ToInt64(Math.Round(Double.Parse(conn.GetFieldValue(dt2,0,"AKTV_TTLAKTV")))))).Length > 8)
			{
				tTxt=tTxt + "99999999";
			}
			else
			{
				double vAKTV_TTLAKTV = 0.0;
				long vAKTV_TTLAKTV_int = 0;
				try { vAKTV_TTLAKTV = Convert.ToDouble(conn.GetFieldValue(dt2,0,"AKTV_TTLAKTV")); } 
				catch {}
				try { vAKTV_TTLAKTV_int = Convert.ToInt64(Math.Round(vAKTV_TTLAKTV, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(vAKTV_TTLAKTV_int.ToString(),8);
			}


			//A0902 - Fixed Assets : Land & Billing 
			//tTxt=tTxt+"--A0902--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt2,0,"AKTV_TNHBGN"))).ToString(),8);

			if(Convert.ToString(Math.Abs(Convert.ToInt64(Math.Round(Double.Parse(conn.GetFieldValue(dt2,0,"AKTV_TNHBGN")))))).Length > 8)
			{
				tTxt=tTxt + "99999999";
			}
			else
			{
				double vAKTV_TNHBGN = 0.0;
				long vAKTV_TNHBGN_int = 0;
				try { vAKTV_TNHBGN = Convert.ToDouble(conn.GetFieldValue(dt2,0,"AKTV_TNHBGN")); } 
				catch {}
				try { vAKTV_TNHBGN_int = Convert.ToInt64(Math.Round(vAKTV_TNHBGN, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(vAKTV_TNHBGN_int.ToString(),8);
			}
		

			//A0903 - % Sales Increase
			//tTxt=tTxt+"--A0903--";
			//Plus
			//A0904 - % Net Income Increase
			//tTxt=tTxt+"--A0904--";
			// check also for middle 

			// for middle only !!!!
			// check small run this code for if 

			//			DataTable dt6;
			//			string incStr;
			//
			//			if (strSmall=="0" )
			//			{
			//				sql = "exec SP_SLS_NEI_INC '" + Request.QueryString["regno"] + "'";
			//				conn.QueryString = sql;
			//				conn.ExecuteQuery();
			//				dt6 = conn.GetDataTable().Copy();
			//
			//				double salesInc = 0;
			//				double incomeInc = 0;
			//				if (dt6.Rows.Count > 0) 
			//				{
			//					double salesYear2 = Double.Parse(conn.GetFieldValue(dt6, 0, "IS_NET_SALES"));
			//					double salesYear1 = Double.Parse(conn.GetFieldValue(dt6, 1, "IS_NET_SALES"));
			//					salesInc =	(salesYear2 - salesYear1) / salesYear1;
			//					double incomeYear2 = Double.Parse(conn.GetFieldValue(dt6, 0, "IS_NET_INCM"));
			//					double incomeYear1 = Double.Parse(conn.GetFieldValue(dt6, 1, "IS_NET_INCM"));
			//					incomeInc = (incomeYear2 - incomeYear1) / incomeYear1;
			//				}
			//
			//				incStr=Math.Round(salesInc*100).ToString();
			//				if (incStr.Length>3)
			//				{
			//					incStr=Pjg(CovToEBCDIC("999"),3);				
			//				}
			//				tTxt=tTxt + Pjg(CovToEBCDIC(incStr),3);
			//
			//				incStr=Math.Round(incomeInc*100).ToString();
			//				if (incStr.Length>3)
			//				{
			//					incStr=Pjg(CovToEBCDIC("999"),3);				
			//				}
			//				tTxt=tTxt + Pjg(CovToEBCDIC(incStr),3);
			//			}
			//			else 
			//			{
			//				incStr = "100";
			//				tTxt=tTxt + Pjg(CovToEBCDIC(incStr),3);
			//				tTxt=tTxt + Pjg(CovToEBCDIC(incStr),3);
			//			}
			/*
				//A0903 - % Sales Increase
				//tTxt=tTxt+"--A0903--";
				if (strSmall=="0" )
				{
					if (Convert.ToString(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"SALES_INCREASE"))*100)).Length > 3)
					{
						tTxt=tTxt + CovToEBCDIC("999");
					}
					else
					{
						tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"SALES_INCREASE"))*100).ToString()),3);
					}
				}
				else
				{
					tTxt=tTxt + CovToEBCDIC("100");
				}

				//A0904 - % Net Income Increase
				//tTxt=tTxt+"--A0904--";
				if (strSmall=="0" )
				{
					if (Convert.ToString(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"NETINCOME_INCREASE"))*100)).Length > 3)
					{
						tTxt=tTxt + "999";
					}
					else
					{
						tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"NETINCOME_INCREASE"))*100).ToString(),3);
					}
				}
				else
				{
					tTxt=tTxt + CovToEBCDIC("100");
				}
				*/
			
			if (Convert.ToString(Math.Abs(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"SALES_INCREASE"))*100))).Length > 3)
			{
				if (Double.Parse(conn.GetFieldValue(dt4,0,"SALES_INCREASE"))>=0)
				{
					tTxt=tTxt + CovToEBCDIC("999");
				}
				else
				{
					tTxt=tTxt + CovToEBCDIC("-999");
				}
			}
			else
			{
				//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"SALES_INCREASE"))*100).ToString()),3);
				double vSALES_INCREASE = 0.0;
				int vSALES_INCREASE_int = 0;
				try { vSALES_INCREASE = Convert.ToDouble(conn.GetFieldValue(dt4,0,"SALES_INCREASE")); } 
				catch {}
				vSALES_INCREASE = vSALES_INCREASE * 100;
				try { vSALES_INCREASE_int = Convert.ToInt32(Math.Round(vSALES_INCREASE, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(CovToEBCDIC(vSALES_INCREASE_int.ToString()),3);
			}



			if (Convert.ToString(Math.Abs(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"NETINCOME_INCREASE"))*100))).Length > 3)
			{
				if(Double.Parse(conn.GetFieldValue(dt4,0,"NETINCOME_INCREASE"))>=0)
				{
					tTxt=tTxt + CovToEBCDIC("999");
				}
				else
				{
					tTxt=tTxt + CovToEBCDIC("-999");
				}
			}
			else
			{
				//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"NETINCOME_INCREASE"))*100).ToString()),3);
				double vNETINCOME_INCREASE = 0.0;
				int vNETINCOME_INCREASE_int = 0;
				try { vNETINCOME_INCREASE = Convert.ToDouble(conn.GetFieldValue(dt4,0,"NETINCOME_INCREASE")); } 
				catch {}
				vNETINCOME_INCREASE = vNETINCOME_INCREASE * 100;
				try { vNETINCOME_INCREASE_int = Convert.ToInt32(Math.Round(vNETINCOME_INCREASE, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(CovToEBCDIC(vNETINCOME_INCREASE_int.ToString()),3);
			}



			//A0905 - Cost of goods sold amt (Millions)
			//tTxt=tTxt+"--A0905--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_PSRL_HPP_SATUAN"))).ToString(),8);
			if(Convert.ToString(Math.Abs(Convert.ToInt64(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_PSRL_HPP_SATUAN")))))).Length > 8)
			{
				tTxt=tTxt + "99999999";
			}
			else
			{
				double vIU_PSRL_HPP_SATUAN = 0;
				long vIU_PSRL_HPP_SATUAN_int = 0;
				try { vIU_PSRL_HPP_SATUAN = Convert.ToDouble(conn.GetFieldValue(dt1,0,"IU_PSRL_HPP_SATUAN")); } 
				catch {}
				try { vIU_PSRL_HPP_SATUAN_int = Convert.ToInt64(Math.Round(vIU_PSRL_HPP_SATUAN, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(vIU_PSRL_HPP_SATUAN_int.ToString(),8);
			}


			//A0906 - General Expense & Administration Ammount
			//tTxt=tTxt+"--A0906--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_PSRL_BIAYAUMUMADM"))).ToString(),8);
			if(Convert.ToString(Math.Abs(Convert.ToInt64(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_PSRL_BIAYAUMUMADM")))))).Length > 8)
			{
				tTxt=tTxt + "99999999";
			}
			else
			{
				double vIU_PSRL_BIAYAUMUMADM = 0.0;
				long vIU_PSRL_BIAYAUMUMADM_int = 0;
				try { vIU_PSRL_BIAYAUMUMADM = Convert.ToDouble(conn.GetFieldValue(dt1,0,"IU_PSRL_BIAYAUMUMADM")); } 
				catch {}
				try { vIU_PSRL_BIAYAUMUMADM_int = Convert.ToInt64(Math.Round(vIU_PSRL_BIAYAUMUMADM, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(vIU_PSRL_BIAYAUMUMADM_int.ToString(),8);
			}


			//A0907 - TC : Trade Cycle Days
			//tTxt=tTxt+"--A0907--";
			//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"TRADE_CYCLE"))).ToString()),3);
			if (Convert.ToString(Math.Abs(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"TRADE_CYCLE"))))).Length > 3)
			{
				if(Double.Parse(conn.GetFieldValue(dt4,0,"TRADE_CYCLE"))>=0)
				{
					tTxt=tTxt + CovToEBCDIC("999");
				}
				else
				{
					tTxt=tTxt + CovToEBCDIC("-999");
				}
			}
			else
			{
				//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"TRADE_CYCLE"))).ToString()),3);
				double vTRADE_CYCLE = 0;
				int vTRADE_CYCLE_int = 0;
				try { vTRADE_CYCLE = Convert.ToDouble(conn.GetFieldValue(dt4,0,"TRADE_CYCLE")); } 
				catch {}
				try { vTRADE_CYCLE_int = Convert.ToInt32(Math.Round(vTRADE_CYCLE, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(CovToEBCDIC(vTRADE_CYCLE_int.ToString()),3);
			}



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0908 - Purchasing Plan Amount
			//tTxt=tTxt+"--A0908--"; 
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PURCHASING_PLANT_AMOUNT_M"))).ToString(),8);
			double vPURCHASING_PLANT_AMOUNT_M = 0;
			int vPURCHASING_PLANT_AMOUNT_M_int = 0;
			try { vPURCHASING_PLANT_AMOUNT_M = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PURCHASING_PLANT_AMOUNT_M")); } 
			catch {}
			try { vPURCHASING_PLANT_AMOUNT_M_int = Convert.ToInt32(Math.Round(vPURCHASING_PLANT_AMOUNT_M, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vPURCHASING_PLANT_AMOUNT_M_int.ToString(),8);




			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0909 - Existing W/C limit in BM
			//tTxt=tTxt+"--A0909--";
			conn.QueryString = "exec FAIRISAAC_EXISTINGEXPOSURE_KMKONLY '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			double vKMK_LMT_BM_CURR = 0;
			int vKMK_LMT_BM_CURR_int = 0;
			try { vKMK_LMT_BM_CURR = Convert.ToDouble(conn.GetFieldValue("EXISTINGEXPOSURE_KMK")); } 
			catch {}
			vKMK_LMT_BM_CURR = vKMK_LMT_BM_CURR / 1000;
			try { vKMK_LMT_BM_CURR_int = Convert.ToInt32(Math.Round(vKMK_LMT_BM_CURR, 0)); } 
			catch {}			
			tTxt=tTxt + Pjg_w_Control(vKMK_LMT_BM_CURR_int.ToString(),8);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0910 - Avg Net Profit
			//tTxt=tTxt+"--A0910--";			
			//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt1, 0, "ML_AVGNET"))).ToString()),7);
			double vIS_LABA_BRSH_RATA2 = vIS_LABA_BRSH / 12;
			int vIS_LABA_BRSH_RATA2_int = 0;
			try { vIS_LABA_BRSH_RATA2_int = Convert.ToInt32(Math.Round(vIS_LABA_BRSH_RATA2,0)); } 
			catch {}
			string tmp = vIS_LABA_BRSH_RATA2_int.ToString();
			tTxt=tTxt + Pjg_w_Control(CovToEBCDIC(tmp),7);




			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0911 - Existing Facility Flag
			//tTxt=tTxt+"--A0911--";
			if (conn.GetFieldValue(dt1,0,"ML_EXFAS")==""||conn.GetFieldValue(dt1,0,"ML_EXFAS")=="0")
			{
				tTxt=tTxt + "A";
			}
			else
			{
				tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"ML_EXFAS").ToString(),1);
			}




			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0912 - % Interest pa (x100)
			//tTxt=tTxt+"--A0912--";
			//tTxt=tTxt + Pjg((100.00*(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PRSN_INTEREST_PA")))).ToString()),4);
			double vPRSN_INTEREST_PA = 0;
			try { vPRSN_INTEREST_PA = Double.Parse(conn.GetFieldValue(dt1,0,"PRSN_INTEREST_PA")); }
			catch {vPRSN_INTEREST_PA = 0;}
			vPRSN_INTEREST_PA = vPRSN_INTEREST_PA * 100;
			int vPRSN_INTEREST_PA_int  = 0;
			try { vPRSN_INTEREST_PA_int = Convert.ToInt32(Math.Round(vPRSN_INTEREST_PA, 0)); } 
			catch {vPRSN_INTEREST_PA_int = 0;}
			tTxt=tTxt + Pjg_w_Control(vPRSN_INTEREST_PA_int.ToString(),4);


			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0913 - Ters in months
			//tTxt=tTxt+"--A0913--";
			tTxt=tTxt + Pjg_w_Control(conn.GetFieldValue(dt1,0,"TERMYN_MONTH").ToString(),2);


			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0914 - Acceptable Project Cost
			//tTxt=tTxt+"--A0914--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"ACCEPT_PROJECT_COST_KI"))).ToString(),8);
			double vACCEPT_PROJECT_COST_KI = 0.0;
			int vACCEPT_PROJECT_COST_KI_int = 0;
			try { vACCEPT_PROJECT_COST_KI = Convert.ToDouble(conn.GetFieldValue(dt1,0,"ACCEPT_PROJECT_COST_KI")); } 
			catch {}
			try { vACCEPT_PROJECT_COST_KI_int = Convert.ToInt32(Math.Round(vACCEPT_PROJECT_COST_KI, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vACCEPT_PROJECT_COST_KI_int.ToString(),8);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0915 - Contractor Plafond : Tot Value of Projects 
			//tTxt=tTxt+"--A0915--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PLAFOND_TOT_VAL_PROJECTS"))).ToString(),8);
			double vPLAFOND_TOT_VAL_PROJECTS = 0.0;
			int vPLAFOND_TOT_VAL_PROJECTS_int = 0;
			try { vPLAFOND_TOT_VAL_PROJECTS = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PLAFOND_TOT_VAL_PROJECTS")); } 
			catch {}
			try { vPLAFOND_TOT_VAL_PROJECTS_int = Convert.ToInt32(Math.Round(vPLAFOND_TOT_VAL_PROJECTS, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vPLAFOND_TOT_VAL_PROJECTS_int.ToString(),8);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0916 - Contractor Plafond : % project cost
			//tTxt=tTxt+"--A0916--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PLAFOND_PRSN_PROJ_COST"))).ToString(),3);
			double vPLAFOND_PRSN_PROJ_COST = 0.0;
			int vPLAFOND_PRSN_PROJ_COST_int = 0;
			try { vPLAFOND_PRSN_PROJ_COST = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PLAFOND_PRSN_PROJ_COST")); } 
			catch {}
			try { vPLAFOND_PRSN_PROJ_COST_int = Convert.ToInt32(Math.Round(vPLAFOND_PRSN_PROJ_COST, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vPLAFOND_PRSN_PROJ_COST_int.ToString(),3);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0917 - Contractor Plafond " terma of payment (months)
			//tTxt=tTxt+"--A0917--";
			tTxt=tTxt + Pjg_w_Control(conn.GetFieldValue(dt1,0,"PLAFOND_TOP").ToString(),2);
			

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0918 - Contractor Plafond : downpayment amount
			//tTxt=tTxt+"--A0918--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PLAFOND_DP"))).ToString(),8);
			double vPLAFOND_DP = 0;
			int vPLAFOND_DP_int = 0;
			try { vPLAFOND_DP = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PLAFOND_DP")); } 
			catch {}
			try { vPLAFOND_DP_int = Convert.ToInt32(Math.Round(vPLAFOND_DP, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vPLAFOND_DP_int.ToString(),8);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0919 - Existing WC plafond limit in BM
			//tTxt=tTxt+"--A0919--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"CL_EXIST_WC_BM"))).ToString(),8);
			double vCL_EXIST_WC_BM = 0;
			int vCL_EXIST_WC_BM_int = 0;
			try { vCL_EXIST_WC_BM = Convert.ToDouble(conn.GetFieldValue(dt1,0,"CL_EXIST_WC_BM")); } 
			catch {}
			try { vCL_EXIST_WC_BM_int = Convert.ToInt32(Math.Round(vCL_EXIST_WC_BM, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vCL_EXIST_WC_BM_int.ToString(),8);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0920 - Existing WC Plafond limit in other bank
			//tTxt=tTxt+"--A0920--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1, 0, "CL_EXIST_WC_OBANK"))).ToString(),8);
			double vCL_EXIST_WC_OBANK = 0.0;
			int vCL_EXIST_WC_OBANK_int = 0;
			try { vCL_EXIST_WC_OBANK = Convert.ToDouble(conn.GetFieldValue(dt1, 0, "CL_EXIST_WC_OBANK")); } 
			catch {}
			try { vCL_EXIST_WC_OBANK_int = Convert.ToInt32(Math.Round(vCL_EXIST_WC_OBANK, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vCL_EXIST_WC_OBANK_int.ToString(),8);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0921 - Contrctor Termyn : Project Cost ( 1 Project)
			//tTxt=tTxt+"--A0921--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PROJ_COST"))).ToString(),8);
			double vPROJ_COST = 0;
			int vPROJ_COST_int = 0;
			try { vPROJ_COST = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PROJ_COST")); } 
			catch {}
			try { vPROJ_COST_int = Convert.ToInt32(Math.Round(vPROJ_COST, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vPROJ_COST_int.ToString(),8);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0922 - Contractor Termyn : Number of Termyn 
			//tTxt=tTxt+"--A0922--";
			tTxt=tTxt + Pjg_w_Control(conn.GetFieldValue(dt1,0,"NUM_TERMYN").ToString(),2);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0923 - SB Non Cash Value of Peoject Pa - General
			//tTxt=tTxt+"--A0923--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"SB_NC_PROJ_PA_GENERAL"))).ToString(),8);
			double vSB_NC_PROJ_PA_GENERAL = 0.0;
			int vSB_NC_PROJ_PA_GENERAL_int = 0;
			try { vSB_NC_PROJ_PA_GENERAL = Convert.ToDouble(conn.GetFieldValue(dt1,0,"SB_NC_PROJ_PA_GENERAL")); } 
			catch {}
			try { vSB_NC_PROJ_PA_GENERAL_int = Convert.ToInt32(Math.Round(vSB_NC_PROJ_PA_GENERAL, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vSB_NC_PROJ_PA_GENERAL_int.ToString(),8);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0924 - SB Non Cash Value of Project pa - Purchase bbond
			//tTxt=tTxt+"--A0924--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"NC_PROJ_PA_PURCHASE_BOND"))).ToString(),8);
			double vNC_PROJ_PA_PURCHASE_BOND = 0;
			int vNC_PROJ_PA_PURCHASE_BOND_int = 0;
			try { vNC_PROJ_PA_PURCHASE_BOND = Convert.ToDouble(conn.GetFieldValue(dt1,0,"NC_PROJ_PA_PURCHASE_BOND")); } 
			catch {}
			try { vNC_PROJ_PA_PURCHASE_BOND_int = Convert.ToInt32(Math.Round(vNC_PROJ_PA_PURCHASE_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vNC_PROJ_PA_PURCHASE_BOND_int.ToString(),8);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0925 - SB % Probability of Success bid bond
			//tTxt=tTxt+"--A0925--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PRSN_PROB_SUCCESS_BID_BOND"))).ToString(),3);
			double vPRSN_PROB_SUCCESS_BID_BOND = 0;
			int vPRSN_PROB_SUCCESS_BID_BOND_int = 0;
			try { vPRSN_PROB_SUCCESS_BID_BOND = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PRSN_PROB_SUCCESS_BID_BOND")); } 
			catch {}
			try { vPRSN_PROB_SUCCESS_BID_BOND_int = Convert.ToInt32(Math.Round(vPRSN_PROB_SUCCESS_BID_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vPRSN_PROB_SUCCESS_BID_BOND_int.ToString(),3);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0926 - % Bid Bond
			//tTxt=tTxt+"--A0926--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"BID_BOND"))).ToString(),3);
			double vBID_BOND = 0;
			int vBID_BOND_int = 0;
			try { vBID_BOND = Convert.ToDouble(conn.GetFieldValue(dt1,0,"BID_BOND")); } 
			catch {}
			try { vBID_BOND_int = Convert.ToInt32(Math.Round(vBID_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vBID_BOND_int.ToString(),3);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0927 - % Advance Bond
			//tTxt=tTxt+"--A0927--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"ADV_BOND"))).ToString(),3);
			double vADV_BOND = 0;
			int vADV_BOND_int = 0;
			try { vADV_BOND = Convert.ToDouble(conn.GetFieldValue(dt1,0,"ADV_BOND")); } 
			catch {}
			try { vADV_BOND_int = Convert.ToInt32(Math.Round(vADV_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vADV_BOND_int.ToString(),3);




			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0928 - % Performance Bond
			//tTxt=tTxt+"--A0928--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PRFRMN_BOND"))).ToString(),3);
			double vPRFRMN_BOND = 0;
			int vPRFRMN_BOND_int = 0;
			try { vPRFRMN_BOND = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PRFRMN_BOND")); } 
			catch {}
			try { vPRFRMN_BOND_int = Convert.ToInt32(Math.Round(vPRFRMN_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vPRFRMN_BOND_int.ToString(),3);




			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0929 - % Retention Bond
			//tTxt=tTxt+"--A0929--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PRSN_RET_BOND"))).ToString(),3);
			double vPRSN_RET_BOND = 0;
			int vPRSN_RET_BOND_int = 0;
			try { vPRSN_RET_BOND = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PRSN_RET_BOND")); } 
			catch {}
			try { vPRSN_RET_BOND_int = Convert.ToInt32(Math.Round(vPRSN_RET_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vPRSN_RET_BOND_int.ToString(),3);




			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0930 - % Purchase Bond
			//tTxt=tTxt+"--A0930--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PRSN_PURCHASE_BOND"))).ToString(),3);
			double vPRSN_PURCHASE_BOND = 0;
			int vPRSN_PURCHASE_BOND_int = 0;
			try { vPRSN_PURCHASE_BOND = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PRSN_PURCHASE_BOND")); } 
			catch {}
			try { vPRSN_PURCHASE_BOND_int = Convert.ToInt32(Math.Round(vPRSN_PURCHASE_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vPRSN_PURCHASE_BOND_int.ToString(),3);
			


			//vtTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0931 - SB Avg Value L/C in a year
			//tTxt=tTxt+"--A0931--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"SB_AVG_VALUELC_YEAR"))).ToString(),8);
			double vSB_AVG_VALUELC_YEAR = 0;
			int vSB_AVG_VALUELC_YEAR_int = 0;
			try { vSB_AVG_VALUELC_YEAR = Convert.ToDouble(conn.GetFieldValue(dt1,0,"SB_AVG_VALUELC_YEAR")); } 
			catch {}
			try { vSB_AVG_VALUELC_YEAR_int = Convert.ToInt32(Math.Round(vSB_AVG_VALUELC_YEAR, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vSB_AVG_VALUELC_YEAR_int.ToString(),8);




			//			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//			//A0932 - SB Avg term of L/C in a year (turnover in months)
			//			//tTxt=tTxt+"--A0932--";
			//			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"SB_AVG_TERMLC"))).ToString(),3);
			//
			//
			//			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//			//A0933 - MC Contractor Peak deficit cash flow
			//			//tTxt=tTxt+"--A0933--";
			//			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"MC_CONT_PEAK_DEFICIT_CF"))).ToString(),8);
			//
			//
			//			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//			//A0934 - MC Non Cash Total Amount of Contract in Millions
			//			//tTxt=tTxt+"--A0934--";
			//			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"MC_NC_TOTAMOUNT"))).ToString(),8);
			//
			//
			//			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//			//A0934 - Contractor Turnkey Project Cost
			//			//tTxt=tTxt+"--A0935--";
			//			tTxt=tTxt + Pjg(Math.Round(Convert.ToDouble(conn.GetFieldValue(dt1,0,"CONTR_TURNKEY_PROJ_COST"))).ToString(),8);


			//A0932 - SB Avg term of L/C in a year (turnover in months)
			//tTxt=tTxt+"--A0932--";
			double vSB_AVG_TERMLC= 0;
			int vSB_AVG_TERMLC_int = 0;
			try { vSB_AVG_TERMLC = Convert.ToDouble(conn.GetFieldValue(dt1,0,"SB_AVG_TERMLC")); } 
			catch {}
			try { vSB_AVG_TERMLC_int= Convert.ToInt32(Math.Round(vSB_AVG_TERMLC, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vSB_AVG_TERMLC_int.ToString(),3);
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"SB_AVG_TERMLC"))).ToString(),3);


			//A0933 - MC Contractor Peak deficit cash flow
			//tTxt=tTxt+"--A0933--";
			double vMC_CONT_PEAK_DEFICIT_CF= 0;
			int vMC_CONT_PEAK_DEFICIT_CF_int = 0;
			try { vMC_CONT_PEAK_DEFICIT_CF = Convert.ToDouble(conn.GetFieldValue(dt1,0,"MC_CONT_PEAK_DEFICIT_CF")); } 
			catch {}
			try { vMC_CONT_PEAK_DEFICIT_CF_int= Convert.ToInt32(Math.Round(vMC_CONT_PEAK_DEFICIT_CF, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vMC_CONT_PEAK_DEFICIT_CF_int.ToString(),8);
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"MC_CONT_PEAK_DEFICIT_CF"))).ToString(),8);


			//A0934 - MC Non Cash Total Amount of Contract in Millions
			//tTxt=tTxt+"--A0934--";
			double vMC_NC_TOTAMOUNT= 0;
			int vMC_NC_TOTAMOUNT_int = 0;
			try { vMC_NC_TOTAMOUNT = Convert.ToDouble(conn.GetFieldValue(dt1,0,"MC_NC_TOTAMOUNT")); } 
			catch {}
			vMC_NC_TOTAMOUNT = vMC_NC_TOTAMOUNT / 1000;
			try { vMC_NC_TOTAMOUNT_int= Convert.ToInt32(Math.Round(vMC_NC_TOTAMOUNT, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vMC_NC_TOTAMOUNT_int.ToString(),8);
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"MC_NC_TOTAMOUNT"))).ToString(),8);


			//A0934 - Contractor Turnkey Project Cost
			//tTxt=tTxt+"--A0935--";
			double vCONTR_TURNKEY_PROJ_COST= 0;
			int vCONTR_TURNKEY_PROJ_COST_int = 0;
			try { vCONTR_TURNKEY_PROJ_COST = Convert.ToDouble(conn.GetFieldValue(dt1,0,"CONTR_TURNKEY_PROJ_COST")); } 
			catch {}
			try { vCONTR_TURNKEY_PROJ_COST_int= Convert.ToInt32(Math.Round(vCONTR_TURNKEY_PROJ_COST, 0)); } 
			catch {}
			tTxt=tTxt + Pjg_w_Control(vCONTR_TURNKEY_PROJ_COST_int.ToString(),8);
			//tTxt=tTxt + Pjg(Math.Round(Convert.ToDouble(conn.GetFieldValue(dt1,0,"CONTR_TURNKEY_PROJ_COST"))).ToString(),8);





			//Isi Filler
			tTxt=tTxt+IsiBlank(305);


			//----Format Response 
			tTxt=tTxt+FillResponseToSend();
			//----End of Format Response

			//20090325 tambahan scoring EBITDA
			//A1420 - Total Employee
			if ((conn.GetFieldValue(dt6,0,"TOTAL_EMPLOYEE")== null )||(conn.GetFieldValue(dt6,0,"TOTAL_EMPLOYEE")==""))
			{
				tTxt=tTxt+"99999";
			}
			else
			{
				tTxt=tTxt + Pjg(conn.GetFieldValue(dt6,0,"TOTAL_EMPLOYEE"),5);
			}

			//A1421 - Net Operating Profit = 1 - ((A0905 + A0906) / A0206)
			if (Convert.ToString(Math.Abs(Convert.ToInt64(Math.Round(Double.Parse(conn.GetFieldValue(dt6,0,"NET_OPERATING_PROFIT"))*100)))).Length > 6)
			{
				if (Double.Parse(conn.GetFieldValue(dt6,0,"NET_OPERATING_PROFIT"))>=0)
				{
					tTxt=tTxt + CovToEBCDIC("999999");
				}
				else
				{
					tTxt=tTxt + CovToEBCDIC("-999999");
				}
			}
			else
			{
				double vNET_OPERATING_PROFIT = 0.0;
				long vNET_OPERATING_PROFIT_int = 0;
				try { vNET_OPERATING_PROFIT = Convert.ToDouble(conn.GetFieldValue(dt6,0,"NET_OPERATING_PROFIT")); } 
				catch {}
				vNET_OPERATING_PROFIT = vNET_OPERATING_PROFIT * 10000;
				try { vNET_OPERATING_PROFIT_int = Convert.ToInt64(Math.Round(vNET_OPERATING_PROFIT, 2)); } 
				catch {}
				tTxt=tTxt + Pjg(CovToEBCDIC(vNET_OPERATING_PROFIT_int.ToString()),6);
			}

			//A1422 - Cash Bank to Hutang Bank Dagang Ratio
			if (Convert.ToString(Math.Abs(Convert.ToInt64(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"KASBANK_TO_HTBANKDG"))*100)))).Length > 6)
			{
				if (Double.Parse(conn.GetFieldValue(dt4,0,"KASBANK_TO_HTBANKDG"))>=0)
				{
					tTxt=tTxt + CovToEBCDIC("999999");
				}
				else
				{
					tTxt=tTxt + CovToEBCDIC("-999999");
				}
			}
			else
			{
				double vKASBANK_TO_HTBANKDG = 0.0;
				long vKASBANK_TO_HTBANKDG_int = 0;
				try { vKASBANK_TO_HTBANKDG = Convert.ToDouble(conn.GetFieldValue(dt4,0,"KASBANK_TO_HTBANKDG")); } 
				catch {}
				vKASBANK_TO_HTBANKDG = vKASBANK_TO_HTBANKDG * 100;
				try { vKASBANK_TO_HTBANKDG_int = Convert.ToInt64(Math.Round(vKASBANK_TO_HTBANKDG, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(CovToEBCDIC(vKASBANK_TO_HTBANKDG_int.ToString()),6);
			}

			//A1423 - Hutang Bank Dagang to Laba Operasional Ratio
			if (Convert.ToString(Math.Abs(Convert.ToInt64(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"HTBANKDG_TO_LABAOPR"))*100)))).Length > 6)
			{
				if (Double.Parse(conn.GetFieldValue(dt4,0,"HTBANKDG_TO_LABAOPR"))>=0)
				{
					tTxt=tTxt + CovToEBCDIC("999999");
				}
				else
				{
					tTxt=tTxt + CovToEBCDIC("-999999");
				}
			}
			else
			{
				double vHTBANKDG_TO_LABAOPR = 0.0;
				long vHTBANKDG_TO_LABAOPR_int = 0;
				try { vHTBANKDG_TO_LABAOPR = Convert.ToDouble(conn.GetFieldValue(dt4,0,"HTBANKDG_TO_LABAOPR")); } 
				catch {}
				vHTBANKDG_TO_LABAOPR = vHTBANKDG_TO_LABAOPR * 100;
				try { vHTBANKDG_TO_LABAOPR_int = Convert.ToInt64(Math.Round(vHTBANKDG_TO_LABAOPR, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(CovToEBCDIC(vHTBANKDG_TO_LABAOPR_int.ToString()),6);
			}

			//A1424 - Konstanta
			tTxt=tTxt + "000";

			//A1425 - Konstanta
			tTxt=tTxt + "000";

			tTxt=tTxt+IsiBlank(31);

			//----Format Response 2
			tTxt=tTxt+FillResponseToSend2();
			//----End of Format Response 2


			//Isi Filler
			tTxt=tTxt+IsiBlank(957);

			//tTxt=tTxt+"--END OF FILE";

			///////////////////////////////////////////////////////////
			///	mengambil direktori penyimpan hasil FairIsaac
			///	
			//			conn.QueryString = "select FAIRISAAC_DIR from APP_PARAMETER";
			//			conn.ExecuteQuery();

			//			StreamWriter Sw;
			//			String strFileName;
			//			strFileName = @conn.GetFieldValue("FAIRISAAC_DIR");
			//			Sw = File.CreateText(strFileName);
			//			Sw.WriteLine(tTxt);
			//			Sw.Close();
			
			conn.QueryString="delete from SCORING_MESSAGE where ap_regno='" + Request.QueryString["regno"] + "' and sumberdata = 'FINALSCORING'";
			conn.ExecuteNonQuery();

			conn.QueryString="insert into SCORING_MESSAGE values('" + Request.QueryString["regno"] + "','" + tTxt + "','FINALSCORING','0')";
			conn.ExecuteNonQuery();

			return true;
		}


		//Procedure ini mengisi nilai "0" 
		private string FillResponseToSend()
		{
			string strTmp="";
			//A1401-A1402
			strTmp=strTmp+IsiBlank(2);
			
			//A1403 Financial Analysis Format
			strTmp=strTmp+"0";

			//A1404-A1406
			strTmp=strTmp+IsiBlank(4);

			//A1407-A1415
			strTmp=strTmp+"000";
			strTmp=strTmp+"000";
			strTmp=strTmp+"000";
			strTmp=strTmp+"000";
			strTmp=strTmp+"000";
			strTmp=strTmp+"000";
			strTmp=strTmp+"000";
			strTmp=strTmp+"000";
			strTmp=strTmp+"000";

			//A1416-A1418
			strTmp=strTmp+IsiBlank(3);

			//A1419 MC NCash L/C Plfnd Multi %
			strTmp=strTmp+"000";

			/*
			//Isi Filler
			strTmp=strTmp+IsiBlank(60);
		
			//G0001 % increase requested
			strTmp=strTmp+CovToEBCDIC("000");

			//G0002-G0020
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";

			//G0021 - MC W/C Limit

			strTmp=strTmp+CovToEBCDIC("0000000");

			//Isi Filler
			strTmp=strTmp+IsiBlank(1);

			//G0022-G0031
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			*/

			return strTmp;
		}

		//20090325 tambahan scoring EBITDA
		//Procedure ini mengisi nilai "0" 
		private string FillResponseToSend2()
		{
			string strTmp="";
			/*
			//A1401-A1402
			strTmp=strTmp+IsiBlank(2);
			
			//A1403 Financial Analysis Format
			strTmp=strTmp+"0";

			//A1404-A1406
			strTmp=strTmp+IsiBlank(4);

			//A1407-A1415
			strTmp=strTmp+"000";
			strTmp=strTmp+"000";
			strTmp=strTmp+"000";
			strTmp=strTmp+"000";
			strTmp=strTmp+"000";
			strTmp=strTmp+"000";
			strTmp=strTmp+"000";
			strTmp=strTmp+"000";
			strTmp=strTmp+"000";

			//A1416-A1418
			strTmp=strTmp+IsiBlank(3);

			//A1419 MC NCash L/C Plfnd Multi %
			strTmp=strTmp+"000";

			//Isi Filler
			strTmp=strTmp+IsiBlank(60);
			*/

			//G0001 % increase requested
			strTmp=strTmp+CovToEBCDIC("000");

			//G0002-G0020
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";

			//G0021 - MC W/C Limit

			strTmp=strTmp+CovToEBCDIC("0000000");

			//Isi Filler
			strTmp=strTmp+IsiBlank(1);

			//G0022-G0031
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";
			strTmp=strTmp+"00000000";

			return strTmp;
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

		void viewInitialData()
		{
					
			string str,strSmall;

			conn.QueryString="select * from vw_cek_smdm where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if(conn.GetFieldValue("businessunit")=="SM100")
			{strSmall="1";}
			else
			{strSmall="0";}


			str="select * from scoring_infoumum  where ap_regno='"+Request.QueryString["regno"]+"'";
			conn.QueryString=str;
			conn.ExecuteQuery();
			if(conn.GetRowCount()>0)
			{
				//				if (!conn.GetFieldValue("TGL_LAHIR").Equals(null)&&(!conn.GetFieldValue("TGL_LAHIR").Equals(""))) 
				//				{
				//					DateTime a = Convert.ToDateTime(conn.GetFieldValue("TGL_LAHIR"));
				//					TXT_TGLLAHIR.Text=a.Day.ToString();
				//					DDL_BULANLAHIR.SelectedValue=a.Month.ToString();
				//					TXT_THN_LAHIR.Text=a.Year.ToString();
				//				}

				//				if (!conn.GetFieldValue("MULAI_USAHA").Equals(null)&&(!conn.GetFieldValue("MULAI_USAHA").Equals(""))) 
				//				{
				//					DateTime a = Convert.ToDateTime(conn.GetFieldValue("MULAI_USAHA"));
				//					DDL_BLN_USAHA.SelectedValue=a.Month.ToString();
				//					TXT_THN_USAHA.Text=a.Year.ToString();
				//				}

				//				if (!conn.GetFieldValue("MULAI_MENETAP").Equals(null)&&(!conn.GetFieldValue("MULAI_MENETAP").Equals(""))) 
				//				{
				//					DateTime a = Convert.ToDateTime(conn.GetFieldValue("MULAI_MENETAP"));
				//					DDL_BLN_MENETAP.SelectedValue=a.Month.ToString();
				//					TXT_THN_MENETAP.Text=a.Year.ToString();
				//				}

				// JENIS PERUSAHAAN
				//try { DDL_JNSPERUSH.SelectedValue = conn.GetFieldValue("JNS_USAHA"); } catch {}


				//				TXT_JML_PEGAWAI.Text=conn.GetFieldValue("JML_PEGAWAI");
				//				TXT_THN_MILIKUSAHA.Text=conn.GetFieldValue("LAMA_MILIKUSAHA_THN");
				//				TXT_BLN_MILIKUSAHA.Text=conn.GetFieldValue("LAMA_MILIKUSAHA_BLN");
				//				TXT_KODEPOS.Text=conn.GetFieldValue("KODE_POSKTR");
				//				try { DDL_SEKTOREKONOMIBI.SelectedValue=conn.GetFieldValue("KODE_SEKTOREKONOMIBI"); } catch {}
				//				TXT_NAMAPEMOHON.Text=conn.GetFieldValue("NAMA_PEMOHON");
				//				TXT_JML_ANAK.Text=conn.GetFieldValue("JML_ANAK");
				//				TXT_NAMA_PERUSHAAN.Text=conn.GetFieldValue("NAMA_PERUSAHAAN");
				//				TXT_JML_KREDIT.Text=GlobalTools.MoneyFormat(conn.GetFieldValue("JML_KREDIT"));
				//				TXT_LIMITOTHERBANK.Text = conn.GetFieldValue("LIMIT_DIBANKLAIN");
				//				TXT_UMURKEYPERSON.Text=conn.GetFieldValue("UMUR_OWNER");
				//				TXT_PROSENSAHAM.Text=conn.GetFieldValue("PROSEN_SAHAM");
				//				TXT_EXPOSUREEXISTING.Text=conn.GetFieldValue("EXPOSURE_EXISTING");
				//				if (TXT_EXPOSUREEXISTING.Text.Trim()=="")
				//				{
				//					TXT_EXPOSUREEXISTING.Text="0";
				//				}
				//				if (TXT_LAMAJADINASABAH.Text=="")
				//					TXT_LAMAJADINASABAH.Text=conn.GetFieldValue("LAMA_NASABAH_BM");


				try { DDL_JNSPERMOHONAN.SelectedValue=conn.GetFieldValue("JENIS_PERMOHONAN"); } 
				catch {}
				try { DDL_JNSKREDIT.SelectedValue=conn.GetFieldValue("JENIS_KREDIT"); } 
				catch {}


				//DDL_JNSKELAMIN.SelectedValue=conn.GetFieldValue("JENIS_KELAMIN");
				//DDL_PENDAKHIR.SelectedValue=conn.GetFieldValue("PENDIDIKAN_TERAKHIR");
				//DDL_STATUSKAWIN.SelectedValue=conn.GetFieldValue("STATUS_KAWIN");
				//DDL_STATMILIKRMH.SelectedValue=conn.GetFieldValue("STAT_MILIKRUMAH");


				try { DDL_CONTRACTORREQLINETYPE.SelectedValue=conn.GetFieldValue("CONTRACTOR_TYPE"); } 
				catch {}
				try { DDL_SKEMAKREDIT.SelectedValue=conn.GetFieldValue("SKEMA_KREDIT"); } 
				catch {}
				try { DDL_JAMINANTAMBAHAN.SelectedValue=conn.GetFieldValue("JAMINAN_TAMBAHAN"); } 
				catch {}
				try { DDL_PUKKCURR.SelectedValue=conn.GetFieldValue("PUKK_CURR"); } 
				catch {}
				try { DDL_PUKKPAST.SelectedValue=conn.GetFieldValue("PUKK_PAST"); } 
				catch {}
				try { DDL_PRODUCTEXIST.SelectedValue=conn.GetFieldValue("PRODUCT_EXISTING"); } 
				catch {}

				//				try { DDL_LGLLAWSUIT.SelectedValue=conn.GetFieldValue("LEGAL_LAWSUIT"); } // ambil dari customer (yudi)
				//				catch {}

				try { DDL_LISENSI.SelectedValue=conn.GetFieldValue("LISENSI_BISNIS"); } 
				catch {}
				fillData(TXT_PURCHASING_PLANT_AMOUNT_M,conn.GetFieldValue("PURCHASING_PLANT_AMOUNT_M"),"1");
				fillData(TXT_PRSN_INTEREST_PA,conn.GetFieldValue("PRSN_INTEREST_PA"),"1");
				fillData(TXT_TERMYN_MONTH,conn.GetFieldValue("TERMYN_MONTH"),"0");
				fillData(TXT_PURCHASING_PLANT_AMOUNT_PUKK,conn.GetFieldValue("PURCHASING_PLANT_AMOUNT_PUKK"),"1");
				fillData(TXT_ACCEPT_PROJ_COST,conn.GetFieldValue("ACCEPT_PROJ_COST"),"1");
				fillData(TXT_PLAFOND_TOT_VAL_PROJECTS,conn.GetFieldValue("PLAFOND_TOT_VAL_PROJECTS"),"1");
				fillData(TXT_PLAFOND_PRSN_PROJ_COST,conn.GetFieldValue("PLAFOND_PRSN_PROJ_COST"),"1");
				fillData(TXT_PLAFOND_TOP,conn.GetFieldValue("PLAFOND_TOP"),"0");
				fillData(TXT_PLAFOND_DP,conn.GetFieldValue("PLAFOND_DP"),"1");
				fillData(TXT_PROJ_COST,conn.GetFieldValue("PROJ_COST"),"1");
				fillData(TXT_NUM_TERMYN,conn.GetFieldValue("NUM_TERMYN"),"0");
				fillData(TXT_SB_NC_PROJ_PA_GENERAL,conn.GetFieldValue("SB_NC_PROJ_PA_GENERAL"),"1");
				fillData(TXT_NC_PROJ_PA_PURCHASE_BOND,conn.GetFieldValue("NC_PROJ_PA_PURCHASE_BOND"),"1");
				fillData(TXT_PRSN_PROB_SUCCESS_BID_BOND,conn.GetFieldValue("PRSN_PROB_SUCCESS_BID_BOND"),"1");
				fillData(TXT_BID_BOND,conn.GetFieldValue("BID_BOND"),"1");
				fillData(TXT_ADV_BOND,conn.GetFieldValue("ADV_BOND"),"1");
				fillData(TXT_PRFRMN_BOND,conn.GetFieldValue("PRFRMN_BOND"),"1");
				fillData(TXT_PRSN_RET_BOND,conn.GetFieldValue("PRSN_RET_BOND"),"1");
				fillData(TXT_PRSN_PURCHASE_BOND,conn.GetFieldValue("PRSN_PURCHASE_BOND"),"1");
				fillData(SB_AVG_VALUELC_YEAR,conn.GetFieldValue("SB_AVG_VALUELC_YEAR"),"1");
				fillData(TXT_SB_AVG_TERMLC,conn.GetFieldValue("SB_AVG_TERMLC"),"1");
				fillData(TXT_MC_NC_TOTAMOUNT,conn.GetFieldValue("MC_NC_TOTAMOUNT"),"1");
				fillData(TXTMC_CONT_PEAK_DEFICIT_CF,conn.GetFieldValue("MC_CONT_PEAK_DEFICIT_CF"),"1");
				fillData(TXTMC_CONT_PEAK_DEFICIT_CF2,conn.GetFieldValue("MC_CONT_PEAK_DEFICIT_CF"),"1");
				fillData(TXTMC_CONT_PEAK_DEFICIT_CF3,conn.GetFieldValue("MC_CONT_PEAK_DEFICIT_CF"),"1");
				fillData(TXT_ACCEPT_PROJ_COST_KI,conn.GetFieldValue("ACCEPT_PROJECT_COST_KI"),"1");
				try
				{
					DDL_PUKKCURR.SelectedValue = conn.GetFieldValue("PUKKCURR");
					DDL_PUKK_PAST_BM.SelectedValue = conn.GetFieldValue("PUKK_PAST_BM");
				}
				catch
				{
					DDL_PUKKCURR.SelectedIndex = 0;
					DDL_PUKK_PAST_BM.SelectedIndex = 0;
				}

				///////////////////////////////////////////////////////////
				/// data ditampilkan kalau ada di scoring_infoumum,
				/// kalau tidak ada ambil dari ca_neraca_small
				/// 
				//fillData(TXT_PSRL_PENJUALANTAHUNAN, conn.GetFieldValue("IU_PSRL_PENJUALANTAHUNAN"), "1");
				//				fillData(TXT_PSRL_PENJUALANTAHUNAN_INSATUAN, conn.GetFieldValue("IU_PSRL_PENJUALANTAHUNAN_SATUAN"), "1");
				//				//fillData(TXT_PSRL_HPP, conn.GetFieldValue("IU_PSRL_HPP"), "1");
				//				fillData(TXT_PSRL_HPP_INSATUAN, conn.GetFieldValue("IU_PSRL_HPP_SATUAN"), "1");
				//				fillData(TXT_PSRL_BIAYAUMUMADM, conn.GetFieldValue("IU_PSRL_BIAYAUMUMADM"), "1");
				//				//fillData(TXT_HUTANG, conn.GetFieldValue("IU_HUTANG"), "1");
				//				fillData(TXT_HUTANG_INSATUAN, conn.GetFieldValue("IU_HUTANG_SATUAN"), "1");
				//				//fillData(TXT_PSN_KASBANK, conn.GetFieldValue("IU_PSN_KASBANK"), "1");
				//				fillData(TXT_PSN_KASBANK_INSATUAN, conn.GetFieldValue("IU_PSN_KASBANK_SATUAN"), "1");
				//				//fillData(TXT_PSN_TTLAKTIVALCR, conn.GetFieldValue("IU_PSN_TTLAKTIVALCR"), "1");
				//				fillData(TXT_PSN_TTLAKTIVALCR_INSATUAN, conn.GetFieldValue("IU_PSN_TTLAKTIVALCR_SATUAN"), "1");
				//				//fillData(TXT_PSN_TNHBGN, conn.GetFieldValue("IU_PSN_TNHBGN"), "1");
				//				//fillData(TXT_PSN_TTLAKTIVA, conn.GetFieldValue("IU_PSN_TTLAKTIVA"), "1");
				//				//fillData(TXT_TOTMODAL, conn.GetFieldValue("IU_TOTMODAL"), "1");
				//				fillData(TXT_TOTMODAL_INSATUAN, conn.GetFieldValue("IU_TOTMODAL_SATUAN"), "1");

				//				try {DDL_IUM_HOMEOWNEDCUST.SelectedValue = conn.GetFieldValue("IUM_HOMEOWNEDCUST");}
				//				catch {}
			}
			else
			{
				fillData(TXT_PURCHASING_PLANT_AMOUNT_M,conn.GetFieldValue("PURCHASING_PLANT_AMOUNT_M"),"1");
				fillData(TXT_PRSN_INTEREST_PA,conn.GetFieldValue("PRSN_INTEREST_PA"),"1");
				fillData(TXT_TERMYN_MONTH,conn.GetFieldValue("TERMYN_MONTH"),"0");
				fillData(TXT_PURCHASING_PLANT_AMOUNT_PUKK,conn.GetFieldValue("PURCHASING_PLANT_AMOUNT_PUKK"),"1");
				fillData(TXT_ACCEPT_PROJ_COST,conn.GetFieldValue("ACCEPT_PROJ_COST"),"1");
				fillData(TXT_PLAFOND_TOT_VAL_PROJECTS,conn.GetFieldValue("PLAFOND_TOT_VAL_PROJECTS"),"1");
				fillData(TXT_PLAFOND_PRSN_PROJ_COST,conn.GetFieldValue("PLAFOND_PRSN_PROJ_COST"),"1");
				fillData(TXT_PLAFOND_TOP,conn.GetFieldValue("PLAFOND_TOP"),"0");
				fillData(TXT_PLAFOND_DP,conn.GetFieldValue("PLAFOND_DP"),"1");
				fillData(TXT_PROJ_COST,conn.GetFieldValue("PROJ_COST"),"1");
				fillData(TXT_NUM_TERMYN,conn.GetFieldValue("NUM_TERMYN"),"0");
				fillData(TXT_SB_NC_PROJ_PA_GENERAL,conn.GetFieldValue("SB_NC_PROJ_PA_GENERAL"),"1");
				fillData(TXT_NC_PROJ_PA_PURCHASE_BOND,conn.GetFieldValue("NC_PROJ_PA_PURCHASE_BOND"),"1");
				fillData(TXT_PRSN_PROB_SUCCESS_BID_BOND,conn.GetFieldValue("PRSN_PROB_SUCCESS_BID_BOND"),"1");
				fillData(TXT_BID_BOND,conn.GetFieldValue("BID_BOND"),"1");
				fillData(TXT_ADV_BOND,conn.GetFieldValue("ADV_BOND"),"1");
				fillData(TXT_PRFRMN_BOND,conn.GetFieldValue("PRFRMN_BOND"),"1");
				fillData(TXT_PRSN_RET_BOND,conn.GetFieldValue("PRSN_RET_BOND"),"1");
				fillData(TXT_PRSN_PURCHASE_BOND,conn.GetFieldValue("PRSN_PURCHASE_BOND"),"1");
				fillData(SB_AVG_VALUELC_YEAR,conn.GetFieldValue("SB_AVG_VALUELC_YEAR"),"1");
				fillData(TXT_SB_AVG_TERMLC,conn.GetFieldValue("SB_AVG_TERMLC"),"1");
				fillData(TXT_MC_NC_TOTAMOUNT,conn.GetFieldValue("MC_NC_TOTAMOUNT"),"1");
				fillData(TXTMC_CONT_PEAK_DEFICIT_CF,conn.GetFieldValue("MC_CONT_PEAK_DEFICIT_CF"),"1");
				fillData(TXTMC_CONT_PEAK_DEFICIT_CF2,conn.GetFieldValue("MC_CONT_PEAK_DEFICIT_CF"),"1");
				fillData(TXTMC_CONT_PEAK_DEFICIT_CF3,conn.GetFieldValue("MC_CONT_PEAK_DEFICIT_CF"),"1");
				fillData(TXT_ACCEPT_PROJ_COST_KI,conn.GetFieldValue("ACCEPT_PROJECT_COST"),"1"); //ahmad
			}

			//fillData(TXT_EXIST_WC_LIMIT_OTHERBANK_INMILLION, conn.GetFieldValue("IU_EXWORKCAP"), "1");
			//fillData(TXT_EXIST_WC_LIMIT_OTHERBANK_INSATUAN, conn.GetFieldValue("IU_EXWORKCAP_SATUAN"), "1");

			fillData(TXT_AVG_NET_PROFIT, conn.GetFieldValue("ML_AVGNET"), "1");
			fillData(TXT_CL_EXIST_WC_BM, conn.GetFieldValue("CL_EXIST_WC_BM"), "1");
			fillData(TXT_CL_EXIST_WC_OBANK, conn.GetFieldValue("CL_EXIST_WC_OBANK"), "1");
			try { DDL_EXISTING_FAC.SelectedValue = conn.GetFieldValue("ML_EXFAS"); }
			catch {}
			fillData(TXT_CONTR_TURNKEY_PROJ_COST, conn.GetFieldValue("CONTR_TURNKEY_PROJ_COST"), "1");
		}

		void CekMandatory()
		{
		}

		//Mengisi DDL dengan tabel reference
		void viewDDL()
		{
			string str;
			str = "select JNSPERMOHONANID,JNSPERMOHONAN from RFPERMOHONANSCORING";
			if (Request.QueryString["tc"] == "1.7") str = str + " where active = '1'";
			conn.QueryString = str;
			conn.ExecuteQuery();
			for(int i=0; i<conn.GetRowCount(); i++) 
			{
				DDL_JNSPERMOHONAN.Items.Add(new ListItem(conn.GetFieldValue(i, "JNSPERMOHONAN"), conn.GetFieldValue(i, "JNSPERMOHONANID")));
			}

			str="select KREDITID,KREDIT from RFKREDITSCORING";
			if (Request.QueryString["tc"] == "1.7") str = str + " where active = '1'";
			GlobalTools.fillRefList(DDL_JNSKREDIT,str,conn);


			str="select EDUCATIONID,EDUCATIONDESC from RFEDUCATION";
			if (Request.QueryString["tc"] == "1.7") str = str + " where active = '1'";
			GlobalTools.fillRefList(DDL_PENDAKHIR,str,conn);			

			//str="select SEXID,SEXDESC from RFSEX";
			//GlobalTools.fillRefList(DDL_JNSKELAMIN,str,conn);

			str = "select MARITALID,MARITALDESC from rfmarital";
			if (Request.QueryString["tc"] == "1.7") str = str + " where active = '1'";
			GlobalTools.fillRefList(DDL_STATUSKAWIN,str,conn);

			str = "select HM_CODE,HM_DESC from rfhomesta";
			if (Request.QueryString["tc"] == "1.7") str = str + " where active = '1'";
			GlobalTools.fillRefList(DDL_STATMILIKRMH,str,conn);

			str = "SELECT TIPEPERUSAHAANID,TIPEPERUSAHAANDESC FROM RFSCORINGTIPEPERUSH";
			if (Request.QueryString["tc"] == "1.7") str = str + " where active = '1'";
			conn.QueryString = str;
			conn.ExecuteQuery();
			for(int i=0; i<conn.GetRowCount(); i++) 
			{
				DDL_JNSPERUSH.Items.Add(new ListItem(conn.GetFieldValue(i,"TIPEPERUSAHAANDESC"), conn.GetFieldValue(i, "TIPEPERUSAHAANID")));
			}

			
			str = "select ContractorReqLineTypeID,ContractorReqLineType from RFCONTRACTORPRESCORING";
			if (Request.QueryString["tc"] == "1.7") str = str + " where active = '1'";
			conn.QueryString = str;
			conn.ExecuteQuery();
			for(int i=0; i<conn.GetRowCount(); i++) 
			{
				DDL_CONTRACTORREQLINETYPE.Items.Add(new ListItem(conn.GetFieldValue(i, "ContractorReqLineType"), conn.GetFieldValue(i, "ContractorReqLineTypeID")));
			}

			// code ini tidak perlu lagi, karena sudah difilter di bawah ....
			//			//str="select CreditSchemeID,CreditScheme from RFCREDITSCHEMESCORING";
			//			str = "select * from VW_SCORING_CREDITSCHEME where AP_REGNO = '" + Request.QueryString["regno"] + "'";
			//			GlobalTools.fillRefList(DDL_SKEMAKREDIT, str, conn);

			//ahmad: begin
			//######################################################################### ddl skema kredit
			conn.QueryString = "select ap_businessunit  from application where ap_regno = '"+Request.QueryString["regno"]+
				"' and cu_ref = '"+Request.QueryString["curef"]+"'";
			conn.ExecuteQuery();

			string Jenis = conn.GetFieldValue("ap_businessunit");

			if (Jenis == "SM100")	// small
			{
				DDL_SKEMAKREDIT.Items.Clear();
				conn.QueryString = "select * from VW_SCORING_CREDITSCHEME where AP_REGNO = '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
				for(int i=0; i<conn.GetRowCount(); i++) 
				{
					DDL_SKEMAKREDIT.Items.Add(new ListItem(conn.GetFieldValue(i, "CREDITSCHEME"), conn.GetFieldValue(i, "CREDITSCHEMEID")));
				}
			}
			else if (Jenis == "MD100")	// middle
			{
				DDL_SKEMAKREDIT.Items.Clear();
				DDL_SKEMAKREDIT.Items.Add(new ListItem("- SELECT - ", ""));
			}
			//ahmad: end



			str = "select ProductID,Product from RFEXISTINGPRODUCTSCORING  ";
			if (Request.QueryString["tc"] == "1.7") str = str + " where active = '1'";
			conn.QueryString = str;
			conn.ExecuteQuery();
			for(int i=0; i<conn.GetRowCount(); i++) 
			{
				DDL_PRODUCTEXIST.Items.Add(new ListItem(conn.GetFieldValue(i, "Product"), conn.GetFieldValue(i, "ProductID")));
			}	


			str="select BI_SEQ, BI_DESC from rfbicode ";
			if (Request.QueryString["tc"] == "1.7") str = str + " where active = '1'";
			GlobalTools.fillRefList(DDL_SEKTOREKONOMIBI,str,conn);

			str = "select * from RFSCR_FI_EXISTINGFACILITY ";
			if (Request.QueryString["tc"] == "1.7") str = str + " where active = '1'";
			conn.QueryString = str;
			conn.ExecuteQuery();
			for(int i=0; i<conn.GetRowCount(); i++) 
			{
				DDL_EXISTING_FAC.Items.Add(new ListItem(conn.GetFieldValue(i, "FAC_DESC"), conn.GetFieldValue(i, "FAC_ID")));
			}
		}

		//Procedure ini manampilkan data data informasi customer meliputi data pribadi, data usaha, 
		//data hubungan dengan bank dan data keuangan
		private void viewPopulate()
		{

			//////////////////////////////////////////////////////////////////////////////////////
			///	Mengambil Jenis Perusahaan dari General Info
			///	
			conn.QueryString="select cu_ref from application where ap_regno='" + LBL_REGNO.Text + "'";
			conn.ExecuteQuery();
			string cuRef=conn.GetFieldValue("cu_ref");
			conn.QueryString = "exec SP_JNS_PERUSH_SCORING '" + cuRef + "'";
			conn.ExecuteQuery();
			try { DDL_JNSPERUSH.SelectedValue = conn.GetFieldValue("tipeperushscoring"); } 
			catch {}

			string UmurThn,UmurBln,Umur;

			//ahmad: start ##############################################################
			/////////////////////////////////////////////
			/// hitung Lama menjadi nasabah BM
			/// 
			
			conn.QueryString="SP_SCORING_TGL '"+ Request.QueryString["curef"] +"'";
			conn.ExecuteQuery();

			string Tahun = conn.GetFieldValue("TAHUN").ToString();
			string Bulan = conn.GetFieldValue("BULAN").ToString();

			TXT_LAMAJADINASABAH.Text = Strings.Right(("0000" + Tahun),2) + Strings.Right(("0000"+ Bulan),2);

			//			if(TXT_LAMAJADINASABAH.Text=="0000")
			//				TXT_LAMAJADINASABAH.Text = "";


			conn.QueryString="select cu_custtypeid, cu_compproblem = case when isnull(cu_compproblem,'0') = '0' then 'N' else 'Y' end " + 
				" from customer where cu_ref = '"+Request.QueryString["curef"]+"'";
			conn.ExecuteQuery();

			/////////////////////////////////////////////////////
			/// jika perseorangan maka persentase share = 100%
			/// 
			if (conn.GetFieldValue("cu_custtypeid") == "02")
				this.TXT_PROSENSAHAM.Text = "100";

			////////////////////////////////////////////////////
			///	Customer terlibat dalam masalah hukum 
			///	
			try { DDL_LGLLAWSUIT.SelectedValue = conn.GetFieldValue("cu_compproblem"); } 
			catch {}



			//ahmad: start ##############################################################


			/////////////////////////////////////////
			///	LIMIT W/C DI BANK LAIN (RIBUAN)
			///	
			conn.QueryString = "select * from VW_FAIRISAAC_EXIST_WC_OTHERBANK where CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0) 
			{
				double vLIMITOTHERBANK = 0;
				try { vLIMITOTHERBANK = Convert.ToDouble(conn.GetFieldValue("CO_LIMIT")); }
				catch {}
				vLIMITOTHERBANK = vLIMITOTHERBANK / 1000;
				TXT_LIMITOTHERBANK.Text = GlobalTools.MoneyFormat(vLIMITOTHERBANK.ToString());
			}
			else	
				TXT_LIMITOTHERBANK.Text = "0";


			
			//////////////////////////////////////////
			/// Existing Exposure
			/// 
			double vEXPOSUREEXISTING = 0;
			conn.QueryString = "FAIRISAAC_EXISTINGEXPOSURE '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0) 
			{
				try { vEXPOSUREEXISTING = Convert.ToDouble(conn.GetFieldValue("EXISTING_EXPOSURE")); } 
				catch {}
				vEXPOSUREEXISTING = vEXPOSUREEXISTING / 1000;
				TXT_EXPOSUREEXISTING.Text = tool.MoneyFormat(vEXPOSUREEXISTING.ToString());
				//TXT_EXPOSUREEXISTING.Text = Convert.ToString(Math.Round(Convert.ToDouble(conn.GetFieldValue("EXISTING_EXPOSURE"))/1000.0));
			}
			else 
			{
				TXT_EXPOSUREEXISTING.Text = "0";
			}


			string str="select cu_custtypeid from customer a inner join application b on a.cu_ref=b.cu_ref where b.ap_regno='" + Request.QueryString["regno"] + "'";
			conn.QueryString=str;
			conn.ExecuteQuery();
			if(conn.GetFieldValue("cu_custtypeid")=="02")	// perorangan
			{
				str="select *,cast((isnull(datediff(m,tgllahir,getdate()),0)/12) as varchar) as UmurThn, cast((isnull(datediff(m,tgllahir,getdate()),0)%12) as varchar)  as UmurBln " + 
					"from VW_PRESCORING_POPULATE_PERSONAL " + 
					"where ap_regno='" + Request.QueryString["regno"] + "'";
				//str="select * from VW_PRESCORING_POPULATE_PERSONAL where ap_regno='" + Request.QueryString["regno"] + "'";
				conn.QueryString=str;
				conn.ExecuteQuery();
				TXT_NAMA_PERUSHAAN.Text=conn.GetFieldValue("NamaPerusahaan");
				//TXT_JML_KREDIT.Text=conn.GetFieldValue("Limit");
				TXT_NAMAPEMOHON.Text=conn.GetFieldValue("NamaKeyPerson");
				if (conn.GetFieldValue("TglLahir").Equals(null)||(!conn.GetFieldValue("TglLahir").Equals(""))) 
				{
					DateTime a = Convert.ToDateTime(conn.GetFieldValue("TglLahir"));
					TXT_TGLLAHIR.Text=a.Day.ToString();
					DDL_BULANLAHIR.SelectedValue=a.Month.ToString();
					TXT_THN_LAHIR.Text=a.Year.ToString();
				}
				if (conn.GetFieldValue("JenisKelamin")=="01")
				{
					DDL_JNSKELAMIN.SelectedValue="L";
				}
				else if (conn.GetFieldValue("JenisKelamin")=="02")
				{
					DDL_JNSKELAMIN.SelectedValue="P";
				}
				TXT_JML_ANAK.Text = conn.GetFieldValue("JmlAnak");
				DDL_BLN_MENETAP.SelectedValue=conn.GetFieldValue("BulanMenetap");
				TXT_THN_MENETAP.Text=conn.GetFieldValue("TahunMenetap");
				try { DDL_STATMILIKRMH.SelectedValue = conn.GetFieldValue("HM_STW"); } // <-- yudi
				catch {}
				//DDL_STATMILIKRMH.SelectedValue=conn.GetFieldValue("StatusRumah");

				UmurThn=conn.GetFieldValue("UmurThn");
				if (UmurThn.Length<2){UmurThn="0"+UmurThn;}
				UmurBln=conn.GetFieldValue("UmurBln");
				if (UmurBln.Length<2){UmurBln="0"+UmurBln;}
				Umur=UmurThn+UmurBln;
				TXT_UMURKEYPERSON.Text=Umur;



				try { DDL_STATUSKAWIN.SelectedValue=conn.GetFieldValue("StatusKawin"); } 
				catch {}
				try { DDL_PENDAKHIR.SelectedValue=conn.GetFieldValue("Pendidikan"); } 
				catch {}
				TXT_KOTAUSAHA.Text=conn.GetFieldValue("KotaLokasiUsaha");
				TXT_KODEPOS.Text=conn.GetFieldValue("KodePosLokasiUsaha");
				TXT_THN_MILIKUSAHA.Text=conn.GetFieldValue("LamaMilikTahun");
				TXT_BLN_MILIKUSAHA.Text=conn.GetFieldValue("LamaMilikBulan");
				//TXT_LAMAJADINASABAH.Text="0"; //ahmad
				TXT_PROSENSAHAM.Text="100";
				if (conn.GetFieldValue("TglPendirian").Equals(null)||(!conn.GetFieldValue("TglPendirian").Equals(""))) 
				{
					DateTime a = Convert.ToDateTime(conn.GetFieldValue("TglPendirian"));
					TXT_TGL_USAHA.Text=a.Day.ToString();
					DDL_BLN_USAHA.SelectedValue=a.Month.ToString();
					TXT_THN_USAHA.Text=a.Year.ToString();
				}
				TXT_JML_PEGAWAI.Text=conn.GetFieldValue("JmlKaryawan");
				try { DDL_IUM_HOMEOWNEDCUST.SelectedValue = conn.GetFieldValue("HM_STW"); } 
				catch {}
			}
			else if (conn.GetFieldValue("cu_custtypeid")=="01")	// badan usaha
			{
				//str="select * from VW_PRESCORING_POPULATE_COMPANY where ap_regno='" + Request.QueryString["regno"] + "'";
				str="select *,cast((isnull(datediff(m,tgllahir,getdate()),0)/12) as varchar) as UmurThn, cast((isnull(datediff(m,tgllahir,getdate()),0)%12) as varchar)  as UmurBln  " + 
					"from VW_PRESCORING_POPULATE_company where ap_regno='" + Request.QueryString["regno"] + "'";
				conn.QueryString=str;
				conn.ExecuteQuery();
				TXT_NAMA_PERUSHAAN.Text=conn.GetFieldValue("NamaPerusahaan");
				//TXT_JML_KREDIT.Text=conn.GetFieldValue("Limit");
				TXT_NAMAPEMOHON.Text=conn.GetFieldValue("NamaKeyPerson");
				if (conn.GetFieldValue("TglLahir").Equals(null)||(!conn.GetFieldValue("TglLahir").Equals(""))) 
				{
					DateTime a = Convert.ToDateTime(conn.GetFieldValue("TglLahir"));
					TXT_TGLLAHIR.Text=a.Day.ToString();
					DDL_BULANLAHIR.SelectedValue=a.Month.ToString();
					TXT_THN_LAHIR.Text=a.Year.ToString();
				}
				if (conn.GetFieldValue("JenisKelamin")=="01")
				{
					DDL_JNSKELAMIN.SelectedValue="L";
				}
				else if (conn.GetFieldValue("JenisKelamin")=="02")
				{
					DDL_JNSKELAMIN.SelectedValue="P";
				}
				// TXT_JML_ANAK.Text="0"; versi Azhari
				TXT_JML_ANAK.Text = conn.GetFieldValue("JmlAnak"); // versi Gatot
				DDL_BLN_MENETAP.SelectedValue=conn.GetFieldValue("BulanMenetap");
				TXT_THN_MENETAP.Text=conn.GetFieldValue("TahunMenetap");
				try { DDL_STATMILIKRMH.SelectedValue = conn.GetFieldValue("HM_STW"); } // .. yudi tea !
				catch {}
				//DDL_STATMILIKRMH.SelectedValue=conn.GetFieldValue("StatusRumah");
				
				UmurThn=conn.GetFieldValue("UmurThn");
				if (UmurThn.Length<2){UmurThn="0"+UmurThn;}
				UmurBln=conn.GetFieldValue("UmurBln");
				if (UmurBln.Length<2){UmurBln="0"+UmurBln;}
				Umur=UmurThn+UmurBln;
				TXT_UMURKEYPERSON.Text=Umur;
				
				TXT_PROSENSAHAM.Text=conn.GetFieldValue("PersenSaham");
				try { DDL_STATUSKAWIN.SelectedValue=conn.GetFieldValue("StatusKawin"); } 
				catch {}
				try { DDL_PENDAKHIR.SelectedValue=conn.GetFieldValue("Pendidikan"); } 
				catch {}
				TXT_JML_PEGAWAI.Text =conn.GetFieldValue("JmlKaryawan");
				TXT_KOTAUSAHA.Text=conn.GetFieldValue("KotaLokasiUsaha");
				TXT_KODEPOS.Text=conn.GetFieldValue("KodePosLokasiUsaha");
				TXT_THN_MILIKUSAHA.Text=conn.GetFieldValue("LamaMilikTahun");
				TXT_BLN_MILIKUSAHA.Text=conn.GetFieldValue("LamaMilikBulan");
				//TXT_LAMAJADINASABAH.Text="0";
				try { DDL_STATMILIKRMH.SelectedValue=conn.GetFieldValue("StatusMilikRumah"); } 
				catch {}
				if (conn.GetFieldValue("TglPendirian").Equals(null)||(!conn.GetFieldValue("TglPendirian").Equals(""))) 
				{
					DateTime a = Convert.ToDateTime(conn.GetFieldValue("TglPendirian"));
					TXT_TGL_USAHA.Text=a.Day.ToString();
					DDL_BLN_USAHA.SelectedValue=a.Month.ToString();
					TXT_THN_USAHA.Text=a.Year.ToString();
				}
				try { DDL_IUM_HOMEOWNEDCUST.SelectedValue = conn.GetFieldValue("HM_STW"); } 
				catch {}

			}

			//////////////////////////////////////////////////////////////////////////////////////
			///	Mengambil TOTAL EXPOSURE = APPLICATION VALUE + TOTAL EXISTING EXPOSURE (FI)
			///	
			conn.QueryString = "DE_TOTALEXPOSURE '" + LBL_REGNO.Text + "'";
			conn.ExecuteQuery(300);
			double vAPPLIMIT = 0, vSUMLIMIT = 0;
			try { vAPPLIMIT = Convert.ToDouble(conn.GetFieldValue("tot_limit")); } 
			catch {}
			try { vEXPOSUREEXISTING = Convert.ToDouble(TXT_EXPOSUREEXISTING.Text.Trim()); } 
			catch {}
			vSUMLIMIT = Math.Round(vAPPLIMIT/1000.0) + vEXPOSUREEXISTING;
			TXT_JML_KREDIT.Text = tool.MoneyFormat(vSUMLIMIT.ToString());


			//////////////////////////////////////////////////
			///	Jenis Permohonan
			///	Untuk Customer baru (tidak punya Tanggal Debitur), maka 
			///	set nilai default ke kode 1, Debitur Baru
			///	
			conn.QueryString = "select ci_bmdebitur from company_info where cu_ref = '" + Request.QueryString["curef"] + "' and ci_bmdebitur is null";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0) 
			{
				try 
				{ 
					DDL_JNSPERMOHONAN.SelectedValue = "1"; 
					DDL_JNSPERMOHONAN.Enabled = false;
				} 
				catch {}
				

				try 
				{
					DDL_PRODUCTEXIST.SelectedValue = "16"; 					
					DDL_PRODUCTEXIST.Enabled = false;
				}
				catch {}
			}
			else 
			{
				double vJML_KREDIT = 0; //vEXPOSUREEXISTING;
				try { vJML_KREDIT = Convert.ToDouble(TXT_JML_KREDIT.Text.Trim()); } 
				catch {}
				if (vJML_KREDIT > vEXPOSUREEXISTING)
				{
					try { DDL_JNSPERMOHONAN.SelectedValue="2"; } 
					catch {}
					DDL_JNSPERMOHONAN.Enabled=false;
				}
			}
			//////////////////////////////////////////////////			

			
			////////////////////////////////////////////////////////////////////////////////////////
			/// Existing Working Capital (W/C) Limit in Other Bank
			/// 
			/*conn.QueryString = "select isnull(CO_LIMIT,0) as CO_LIMIT " + 
				"from CUSTOTHERLOAN " + 
				"where CU_REF = '" + Request.QueryString["curef"] + "' and CO_JENISID = 'KMK'";
			conn.ExecuteQuery();
			double vCO_LIMIT = 0, vCO_LIMIT_SATUAN = 0;
			try { vCO_LIMIT = Convert.ToDouble(conn.GetFieldValue("CO_LIMIT")); } 
			catch {}
			vCO_LIMIT_SATUAN = vCO_LIMIT / 1000;
			TXT_EXIST_WC_LIMIT_OTHERBANK_INMILLION.Text = tool.MoneyFormat(vCO_LIMIT.ToString());
			TXT_EXIST_WC_LIMIT_OTHERBANK_INSATUAN.Text = vCO_LIMIT_SATUAN.ToString();*/
			
			double vCO_LIMIT = 0, vCO_LIMIT_SATUAN = 0;
			double vCO_LIMITTEMP = 0, vCO_LIMIT_SATUANTEMP = 0;

			SqlDataReader reader2;
			MyConnection con2 = new MyConnection();

			con2.OpenConnection();
			reader2 = con2.Query("select isnull(CO_LIMIT,0) as CO_LIMIT " + 
				"from CUSTOTHERLOAN " + 
				"where CU_REF = '" + Request.QueryString["curef"] + "' and CO_JENISID = 'KMK'");
			
			if(reader2.HasRows)
			{
				while(reader2.Read())
				{
					vCO_LIMITTEMP = MyConnection.ConvertToDouble(reader2[0].ToString());
					vCO_LIMIT += vCO_LIMITTEMP;

					vCO_LIMIT_SATUANTEMP = MyConnection.ConvertToDouble(reader2[0].ToString())/1000;
					vCO_LIMIT_SATUAN += vCO_LIMIT_SATUANTEMP;
				}
			}

			con2.CloseConnection();

			TXT_EXIST_WC_LIMIT_OTHERBANK_INMILLION.Text = tool.MoneyFormat(vCO_LIMIT.ToString());
			TXT_EXIST_WC_LIMIT_OTHERBANK_INSATUAN.Text = vCO_LIMIT_SATUAN.ToString();

			//////////////////////////////////////
			///	view data neraca & laba rugi
			///	
			viewFromNeracaLabaRugi();
		}

		private void fillData(System.Web.UI.WebControls.TextBox a, string theData, string Stat)
		{
			if (Stat=="1")//kalau type data float
				if ((theData=="")||(theData==null)) //kalau kosong atau null
					a.Text="0,00";
				else
					a.Text=theData;
			else //type data lain selain float
				if((Stat=="0")&&((theData=="")||(theData==null)))//type integer dan data kosong/null
				a.Text="0";
			else
				a.Text=theData;
		}

		//Menyimpan data info umum 
		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{

			if ((string)Session["SaveHub"]=="0")
			{
				GlobalTools.popMessage(this,"Hubungan dengan Bank harus disimpan lebih dulu.");
				return;
			}

			Session["SaveHub"]="0";


			/* --- mask by cheng - validation according to Arrudy's Spec
			if (DDL_PENDAKHIR.SelectedValue.Trim() == "")
				Tools.popMessage(this,"Pendidikan Terakhir Tidak Boleh Kosong");
			else if (DDL_STATUSKAWIN.SelectedValue.Trim() == "")
				Tools.popMessage(this,"Status Perkawinan Tidak Boleh Kosong");
			else
			{
			*/

			/////////////////////////////////////
			///	Validasi % Interest pa
			///	
			double vPRSN_INTEREST_PA = 0;
			try { vPRSN_INTEREST_PA = Double.Parse(TXT_PRSN_INTEREST_PA.Text); }
			catch {}
			if (vPRSN_INTEREST_PA > 100) 
			{
				GlobalTools.popMessage(this, "% Interest pa tidak valid!");			
				return;
			}
			
			conn.QueryString = "exec scoring_infoumum_sp0 '" + LBL_REGNO.Text + "','";
			conn.QueryString += TXT_NAMA_PERUSHAAN.Text + "','";
			conn.QueryString += DDL_JNSPERMOHONAN.SelectedValue  + "','";
			conn.QueryString += DDL_JNSKREDIT.SelectedValue  + "',";
			conn.QueryString += tool.ConvertFloat(TXT_JML_KREDIT.Text) + ",'";
			conn.QueryString += TXT_NAMAPEMOHON.Text + "',";
			conn.QueryString += GlobalTools.ToSQLDate(TXT_TGLLAHIR.Text,DDL_BULANLAHIR.SelectedValue,TXT_THN_LAHIR.Text) + ",'" ;
			conn.QueryString += DDL_JNSKELAMIN.SelectedValue  + "','" ;
			conn.QueryString += DDL_PENDAKHIR.SelectedValue  + "','" ;
			conn.QueryString += DDL_STATUSKAWIN.SelectedValue  + "'," ;
			conn.QueryString += TXT_JML_ANAK.Text + "," ;
			conn.QueryString += GlobalTools.ToSQLDate("1",DDL_BLN_MENETAP.SelectedValue,TXT_THN_MENETAP.Text) + ",'" ;
			conn.QueryString += DDL_STATMILIKRMH.SelectedValue  + "','" ;
			conn.QueryString += DDL_JNSPERUSH.SelectedValue  + "'," ;
			conn.QueryString += TXT_JML_PEGAWAI.Text + "," ;
			conn.QueryString += GlobalTools.ToSQLDate(TXT_TGL_USAHA.Text,DDL_BLN_USAHA.SelectedValue,TXT_THN_USAHA.Text) + ",'" ;
			conn.QueryString += TXT_KODEPOS.Text + "'," ;
			conn.QueryString += TXT_THN_MILIKUSAHA.Text + "," ;
			conn.QueryString += TXT_BLN_MILIKUSAHA.Text + ",'" ;
			conn.QueryString += DDL_SEKTOREKONOMIBI.SelectedValue ;
			conn.QueryString += "','FINALSCORING','" ;
			conn.QueryString += DDL_CONTRACTORREQLINETYPE.SelectedValue  + "','" ;
			conn.QueryString += DDL_SKEMAKREDIT.SelectedValue  + "','" ;
			conn.QueryString += DDL_PRODUCTEXIST.SelectedValue  + "'," ;
			conn.QueryString += tool.ConvertFloat(TXT_EXPOSUREEXISTING.Text) + ",'" ;
			conn.QueryString += DDL_JAMINANTAMBAHAN.SelectedValue  + "'," ;
			conn.QueryString += TXT_LAMAJADINASABAH.Text + ",'" ;
			conn.QueryString += DDL_LGLLAWSUIT.SelectedValue  + "'," ;
			conn.QueryString += tool.ConvertFloat(TXT_LIMITOTHERBANK.Text) + "," ;
			conn.QueryString += TXT_UMURKEYPERSON.Text + "," ;
			conn.QueryString += tool.ConvertFloat(TXT_PROSENSAHAM.Text) + "";
			conn.ExecuteNonQuery();


			conn.QueryString = "exec scoring_infoumum_sp1 '" + LBL_REGNO.Text + 
				"', 'FINALSCORING','" +					
				DDL_PUKKCURR.SelectedValue  + "','" +
				DDL_PUKKPAST.SelectedValue  + "','" +
				DDL_LISENSI.SelectedValue + "'," + 
				tool.ConvertFloat(TXT_PURCHASING_PLANT_AMOUNT_M.Text) + "," + 
				tool.ConvertFloat(TXT_PRSN_INTEREST_PA.Text) + "," + 
				Int32.Parse(TXT_TERMYN_MONTH.Text) + "," + 
				tool.ConvertFloat(TXT_PURCHASING_PLANT_AMOUNT_PUKK.Text) + "," + 
				//tool.ConvertFloat(TXT_ACCEPT_PROJ_COST.Text) + "," + 
				"0," + 
				tool.ConvertFloat(TXT_PLAFOND_TOT_VAL_PROJECTS.Text) + "," + 
				tool.ConvertFloat(TXT_PLAFOND_PRSN_PROJ_COST.Text) + "," + 
				Convert.ToInt16(TXT_PLAFOND_TOP.Text) + "," + 
				tool.ConvertFloat(TXT_PLAFOND_DP.Text) + "," + 
				tool.ConvertFloat(TXT_PROJ_COST.Text) + "," + 
				tool.ConvertFloat(TXT_NUM_TERMYN.Text) + "," + 
				tool.ConvertFloat(TXT_SB_NC_PROJ_PA_GENERAL.Text) + "," + 
				tool.ConvertFloat(TXT_NC_PROJ_PA_PURCHASE_BOND.Text) + "," + 
				tool.ConvertFloat(TXT_PRSN_PROB_SUCCESS_BID_BOND.Text) + "," + 
				tool.ConvertFloat(TXT_BID_BOND.Text) + "," + 
				tool.ConvertFloat(TXT_ADV_BOND.Text) + "," + 
				tool.ConvertFloat(TXT_PRFRMN_BOND.Text) + "," + 
				tool.ConvertFloat(TXT_PRSN_RET_BOND.Text) + "," + 
				tool.ConvertFloat(TXT_PRSN_PURCHASE_BOND.Text) + "," + 
				tool.ConvertFloat(SB_AVG_VALUELC_YEAR.Text) + "," + 
				tool.ConvertFloat(TXT_SB_AVG_TERMLC.Text) + "," + 
				tool.ConvertFloat(TXT_MC_NC_TOTAMOUNT.Text) + ",'" + 
				DDL_PUKKCURR.SelectedValue  + "','" +
				DDL_PUKK_PAST_BM.SelectedValue  + "'," +
				tool.ConvertFloat(TXTMC_CONT_PEAK_DEFICIT_CF.Text) + "," +
				tool.ConvertFloat(TXT_ACCEPT_PROJ_COST_KI.Text);			
			conn.ExecuteNonQuery();

			conn.QueryString = "exec SCORING_INFOUMUM_SP2 " +
				"'" + LBL_REGNO.Text + "', 'FINALSCORING', " +
				"" + tool.ConvertNull(DDL_AL_MINTANAS.SelectedValue) + ", " +
				"" + tool.ConvertFloat(TXT_CL_EXIST_WC_BM.Text) + ", " +
				"" + tool.ConvertFloat(TXT_CL_EXIST_WC_OBANK.Text) + ", " +
				"" + tool.ConvertFloat(TXT_EXIST_WC_LIMIT_OTHERBANK_INMILLION.Text) + ", " +
				"" + tool.ConvertFloat(TXT_EXIST_WC_LIMIT_OTHERBANK_INSATUAN.Text) + ", " +
				"" + tool.ConvertNull(DDL_IUM_HOMEOWNEDCUST.SelectedValue) + ", " +
				"" + tool.ConvertFloat(TXT_CONTR_TURNKEY_PROJ_COST.Text) + "";
			conn.ExecuteNonQuery();
		
			//Response.Write("TXT_PSN_TTLAKTIVALCR_INSATUAN : " + TXT_PSN_TTLAKTIVALCR_INSATUAN.Text);
			conn.QueryString = "exec SCORING_INFOUMUM_SP3 " +
				"'" + LBL_REGNO.Text + "', 'FINALSCORING', " +
				"" + tool.ConvertFloat(TXT_HUTANG.Text) + ", " +
				"" + tool.ConvertFloat(TXT_HUTANG_INSATUAN.Text) + ", " +
				"" + tool.ConvertFloat(TXT_PSN_KASBANK.Text) + ", " +
				"" + tool.ConvertFloat(TXT_PSN_KASBANK_INSATUAN.Text) + ", " +
				"" + tool.ConvertFloat(TXT_PSRL_PENJUALANTAHUNAN.Text) + ", " +
				"" + tool.ConvertFloat(TXT_PSRL_PENJUALANTAHUNAN_INSATUAN.Text) + ", " +
				"" + tool.ConvertFloat(TXT_PSN_TNHBGN.Text) + ", " +
				"" + tool.ConvertFloat(TXT_PSN_TTLAKTIVA.Text) + ", " +
				"" + tool.ConvertFloat(TXT_PSN_TTLAKTIVALCR.Text) + ", " +
				"" + tool.ConvertFloat(TXT_PSN_TTLAKTIVALCR_INSATUAN.Text) + "";
			conn.ExecuteNonQuery();

			conn.QueryString = "exec SCORING_INFOUMUM_SP4 " +
				"'" + LBL_REGNO.Text + "', 'FINALSCORING', " +
				"" + tool.ConvertFloat(TXT_PSRL_BIAYAUMUMADM.Text) + ", " +
				"" + tool.ConvertFloat(TXT_PSRL_HPP.Text) + ", " +
				"" + tool.ConvertFloat(TXT_PSRL_HPP_INSATUAN.Text) + ", " +
				"" + tool.ConvertFloat(TXT_TOTMODAL.Text) + ", " +
				"" + tool.ConvertFloat(TXT_TOTMODAL_INSATUAN.Text) + ", " +
				"" + tool.ConvertFloat(TXT_AVG_NET_PROFIT.Text) + ", " +
				"" + tool.ConvertNull(DDL_EXISTING_FAC.SelectedValue) + "";
			conn.ExecuteNonQuery();
			// }

			BTN_SND_FAIRISAAC.Enabled = true;
		}

		//Procedure ini melakukan hal-hal sbb : 
		//1. validasi infoumum dan ratio
		//2. create string untuk strategy ware
		//3. mengisi history pengiriman string ke fairisaac
		protected void BTN_SND_FAIRISAAC_Click(object sender, System.EventArgs e)
		{
			//ambil semua parameter

			conn.QueryString = "SELECT PScounter, FScounter FROM SCORING_COUNTER " + 
				"WHERE AP_REGNO = '" + Request.QueryString["REGNO"] + "'";
			conn.ExecuteQuery();

			if(conn.GetRowCount() == 0)
			{
				conn.QueryString = "INSERT INTO SCORING_COUNTER VALUES('" + Request.QueryString["REGNO"] + "',0,0,0,0)";
				conn.ExecuteQuery();
			}

			conn.QueryString = "SELECT PScounter, FScounter FROM SCORING_COUNTER " + 
				"WHERE AP_REGNO = '" + Request.QueryString["REGNO"] + "'";
			conn.ExecuteQuery();

			int PScounter = Convert.ToInt32(conn.GetFieldValue("PScounter").ToString());
			int FScounter = Convert.ToInt32(conn.GetFieldValue("FScounter").ToString());

			conn.QueryString = "SELECT MAX_SCORING FROM APP_PARAMETER";
			conn.ExecuteQuery();
			int max = Convert.ToInt32(conn.GetFieldValue("MAX_SCORING").ToString());

			if(FScounter < max)
			{
				SqlDataReader reader2;
				MyConnection con2 = new MyConnection();

				double result = 0;

				conn.QueryString = "EXEC SCORING_INSERTRFSCORINGRESULTHISTORY '" + Request.QueryString["regno"] +"','FINALSCORING'";
				conn.ExecuteQuery();

				//ubah ini, cek sub segment programnya baru cek scoringnya.
				conn.QueryString = "SELECT PROG_CODE FROM APPLICATION WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				con2.OpenConnection();
				reader2 = con2.Query("SELECT [CONDITION], [PARAMETER], [COLUMN], [RESULT], [ID], [OPERATOR] FROM RFSCORINGPROGTOCONDITION WHERE [IDPROGRAM] = '" + conn.GetFieldValue("PROG_CODE") + "' AND [CONDITION] <> ''");

				int isfound = -2;
				string idRFSCORINGPROGTOCONDITION = "-1";

				if(reader2.HasRows)
				{
					while(reader2.Read())
					{
						string condition = reader2[0].ToString();
						string parameter = reader2[1].ToString();
						string column = reader2[2].ToString();
						string results = reader2[3].ToString();
						string op = reader2[5].ToString();
						
						string query = condition + " '" + Request.QueryString[parameter].ToString() + "'";
						conn.QueryString = query;
						conn.ExecuteQuery();

						if(op == "=")
						{
							if(results == conn.GetFieldValue(column).ToString())
							{
								idRFSCORINGPROGTOCONDITION = reader2[4].ToString();
								isfound = -1;
								break;
							}
						}
						else if(op == "!=")
						{
							if(results != conn.GetFieldValue(column).ToString())
							{
								idRFSCORINGPROGTOCONDITION = reader2[4].ToString();
								isfound = -1;
								break;
							}
						}
						else if(op == ">")
						{
							if(MyConnection.ConvertToDouble(conn.GetFieldValue(column).ToString()) > MyConnection.ConvertToDouble(results))
							{
								idRFSCORINGPROGTOCONDITION = reader2[4].ToString();
								isfound = -1;
								break;
							}
						}
						else if(op == "<")
						{
							if(MyConnection.ConvertToDouble(conn.GetFieldValue(column).ToString()) < MyConnection.ConvertToDouble(results))
							{
								idRFSCORINGPROGTOCONDITION = reader2[4].ToString();
								isfound = -1;
								break;
							}
						}
						else if(op == "<=")
						{
							if(MyConnection.ConvertToDouble(conn.GetFieldValue(column).ToString()) <= MyConnection.ConvertToDouble(results))
							{
								idRFSCORINGPROGTOCONDITION = reader2[4].ToString();
								isfound = -1;
								break;
							}
						}
						else if(op == ">=")
						{
							if(MyConnection.ConvertToDouble(conn.GetFieldValue(column).ToString()) >= MyConnection.ConvertToDouble(results))
							{
								idRFSCORINGPROGTOCONDITION = reader2[4].ToString();
								isfound = -1;
								break;
							}
						}
					}
				}
				con2.CloseConnection();

				if(isfound == -2)
				{
					conn.QueryString = "SELECT PROG_CODE FROM APPLICATION WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();

					string prog_code = conn.GetFieldValue("PROG_CODE");

					conn.QueryString = ("SELECT [CONDITION], [PARAMETER], [COLUMN], [RESULT], [ID] FROM RFSCORINGPROGTOCONDITION WHERE [IDPROGRAM] = '" + prog_code + "' AND [CONDITION] = ''");
					conn.ExecuteQuery();
					idRFSCORINGPROGTOCONDITION = conn.GetFieldValue("ID");
				}
					
				conn.QueryString = "SELECT [IDTEMPLATE] FROM RFSCORINGPROGTOCONDITION WHERE [ID] = '" + idRFSCORINGPROGTOCONDITION + "'";
				conn.ExecuteQuery();
				string id = conn.GetFieldValue("IDTEMPLATE").ToString();

				conn.QueryString = "SELECT [DESC] FROM RFSCORINGTEMPLATE WHERE [ID] = '" + id + "'";
				conn.ExecuteQuery();
				TXT_MODEL.Text = conn.GetFieldValue("DESC");

				conn.QueryString = "EXEC SCORING_INSERTRFSCORINGCOMPOS '" + Request.QueryString["regno"] + "','" + id + "','FINALSCORING'";
				conn.ExecuteQuery();

				conn.QueryString = "SELECT ID FROM RFSCORINGCOMPOST WHERE APREGNO = '" + Request.QueryString["regno"] + "' AND SUMBERDATA = 'FINALSCORING'";
				conn.ExecuteQuery();

				string idRFSCORINGCOMPOST = conn.GetFieldValue("ID");

				conn.QueryString = "DELETE RFSCORINGCOMPOSDETAIL WHERE IDRFCOMPOS = '" + idRFSCORINGCOMPOST + "'";
				conn.ExecuteNonQuery();
				
				con2.OpenConnection();
				reader2 = con2.Query("SELECT IDATTRIBUTE FROM RFSCORINGTEMPATT WHERE IDTEMPLATE = '" + id + "'");

				if(reader2.HasRows)
				{
					while(reader2.Read())
					{
						//sampai sini
						conn.QueryString = "SELECT ID, COLUMNNAME, QUERYTXT, PARAMNAME, DESCRIPT FROM RFSCORINGATTRIBUTE WHERE ID = '" + reader2[0].ToString() + "'";
						conn.ExecuteQuery();
					
						string idatt = conn.GetFieldValue("ID");
						string query = conn.GetFieldValue("QUERYTXT");
						string param = conn.GetFieldValue("PARAMNAME");
						string namakolom = conn.GetFieldValue("COLUMNNAME");
						string deskripsi = conn.GetFieldValue("DESCRIPT");

						conn.QueryString = query + " '" + Request.QueryString[param].ToString() + "'";
						conn.ExecuteQuery();

						//Tools.popMessage(this, namakolom.ToString() + conn.GetFieldValue(namakolom).ToString());

						//id itu id template
						//idatt itu id attribute
						//nilai yang akan dibandingkan
						double resultweight = GetScore(idatt, conn.GetFieldValue(namakolom).ToString(),id);

						conn.QueryString = "EXEC SCORING_INSERTRFSCORINGCOMPOSDETAIL '" + idRFSCORINGCOMPOST + "','" + deskripsi + " :','" + resultweight + "'";
						conn.ExecuteQuery();

						result += resultweight;
					}
				}

				con2.CloseConnection();

				//Tools.popMessage(this, result.ToString());

				conn.QueryString = "SELECT BASEPOINT FROM RFSCORINGTEMPLATE WHERE [ID] = '" + id + "'";
				conn.ExecuteQuery();

				result += MyConnection.ConvertToDouble(conn.GetFieldValue("BASEPOINT"));

				conn.QueryString = "EXEC SCORING_INSERTRFSCORING_SCORE '" + Request.QueryString["regno"] + "','" + result + "','FINALSCORING'";
				conn.ExecuteQuery();

				string proporsi;
				string iditem;
				string resultscore = getScoreTotal(result, out proporsi, id, out iditem);

				conn.QueryString = "SELECT MIN(convert(float,HIGHESTSCORE)) as L FROM RFSCORINGCUTOFFSCORE WHERE IDITEM =" + iditem;
				conn.ExecuteQuery();

				//masukin lowest score 
				getRule(MyConnection.ConvertToDouble(conn.GetFieldValue("L").ToString().Replace(",",".")), result, resultscore, id);

				//Tools.popMessage(this, a.ToString());
				Tools.popMessage(this, "Calculation has done !");
			}
			else
			{
				
				conn.QueryString = "SELECT COUNT(AP_REGNO) as TOT FROM RFSCORINGRESULT WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND SUMBERDATA = 'FINALSCORING'";
				conn.ExecuteQuery();

				if(conn.GetFieldValue("TOT").ToString() == "0")
				{
					string IDOVERALL = "";
					string IDSCORECUTOFF = "";

					conn.QueryString = "SELECT IDOVERALL, IDSCORECUTOFF FROM RFSCORINGRESULT WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND SUMBERDATA = 'PRESCORING'";
					conn.ExecuteQuery();

					IDOVERALL = conn.GetFieldValue("IDOVERALL").ToString();
					IDSCORECUTOFF = conn.GetFieldValue("IDSCORECUTOFF").ToString();

					conn.QueryString = "EXEC SCORING_INSERTSCORINGRESULT '" + Request.QueryString["REGNO"] + "','" + IDOVERALL + "','" + IDSCORECUTOFF + "','FINALSCORING'";
					conn.ExecuteNonQuery();
				}

				conn.QueryString = "EXEC SCORING_INSERTRFSCORINGRULERESULTHISTORY '" + Request.QueryString["REGNO"] + "','FINALSCORING'";
				conn.ExecuteNonQuery();

				SqlDataReader reader2;
				MyConnection con2 = new MyConnection();

				con2.OpenConnection();
				reader2 = con2.Query("SELECT IDRULEREASON FROM RFSCORINGRULEREASONRESULT " + 
					"WHERE APREGNO = '" + Request.QueryString["regno"] + "' AND SUMBERDATA = 'PRESCORING'");

				if(reader2.HasRows)
				{
					while(reader2.Read())
					{
						conn.QueryString = "DELETE RFSCORINGRULEREASONRESULT WHERE APREGNO = '" + Request.QueryString["regno"] + "' AND SUMBERDATA = 'FINALSCORING'";
						conn.ExecuteQuery();

						//reader2[0].ToString()
						conn.QueryString = "EXEC SCORING_INSERTSCORINGRULEREASONRESULT '" + Request.QueryString["REGNO"] + "','" + reader2[0].ToString() + "','FINALSCORING'";
						conn.ExecuteNonQuery();
					}
				}

				con2.CloseConnection();

				Tools.popMessage(this, "Fail ! Your chance is 0 !");
			}
		}

		private void getRule(double lowestscore, double resulttotal, string idresult, string idTemplate)
		{
			int hitornot = 0;
			/*int max = 0;*/

			SqlDataReader reader2;
			MyConnection con2 = new MyConnection();

			con2.OpenConnection();
			reader2 = con2.Query("SELECT * FROM RFSCORINGRULEREASONRESULT " + 
				"WHERE APREGNO = '" + Request.QueryString["regno"] + "' AND SUMBERDATA = 'FINALSCORING'");

			if(reader2.HasRows)
			{
				conn.QueryString = "EXEC SCORING_INSERTRFSCORINGRULERESULTHISTORY '" + Request.QueryString["REGNO"] + "','FINALSCORING'";
				conn.ExecuteNonQuery();
			}

			conn.QueryString = "DELETE FROM RFSCORINGRULEREASONRESULT WHERE APREGNO = '" + Request.QueryString["REGNO"] + "' AND SUMBERDATA = 'FINALSCORING'";
			conn.ExecuteNonQuery();

			
			SqlDataReader reader;
			MyConnection con = new MyConnection();
			con.OpenConnection();
			//reader = con.Query("SELECT * FROM RFSCORINGRULEREASON WHERE ISACTIVE = '1'");

			/*SELECT RFSCORINGRULEREASON.*, RFSCORINGRULEREASONPERTEMPLATE.QUERYCOMPARATION as QUERYCOMPARATION2
			FROM RFSCORINGRULEREASON, RFSCORINGRULEREASONPERTEMPLATE 
			WHERE RFSCORINGRULEREASON.ISACTIVE = '1'
			AND RFSCORINGRULEREASONPERTEMPLATE.IDTEMPLATE = '1'
			AND RFSCORINGRULEREASONPERTEMPLATE.IDRFSCORINGRULEREASON = RFSCORINGRULEREASON.[ID]*/

			reader = con.Query("SELECT RFSCORINGRULEREASON.[ID]," +
				"RFSCORINGRULEREASON.[DESCRIPTION], RFSCORINGRULEREASON.[REASON_CODE]," +
				"RFSCORINGRULEREASON.ISACTIVE, RFSCORINGRULEREASON.QUERYGETVALUE," +
				"RFSCORINGRULEREASONPERTEMPLATE.QUERYCOMPARATION, RFSCORINGRULEREASON.ISQUERY, RFSCORINGRULEREASON.COLUMNNAME " +
				"FROM RFSCORINGRULEREASON, RFSCORINGRULEREASONPERTEMPLATE " +
				"WHERE RFSCORINGRULEREASON.ISACTIVE = '1'" +
				"AND RFSCORINGRULEREASONPERTEMPLATE.IDTEMPLATE = '" + idTemplate + "' " +
				"AND RFSCORINGRULEREASONPERTEMPLATE.IDRFSCORINGRULEREASON = RFSCORINGRULEREASON.[ID]");
		
			if(reader.HasRows)
			{
				while(reader.Read())
				{
					if(reader[6].ToString().Replace(" ","").Equals("0"))
					{
						conn.QueryString = reader[4].ToString() + "'" + Request.QueryString[reader[7].ToString()] + "'";
						conn.ExecuteQuery();

						if(conn.GetRowCount() != 0)
						{
							if(conn.GetFieldValue(0,0).ToString() == reader[5].ToString())
							{
								conn.QueryString = "EXEC SCORING_INSERTSCORINGRULEREASONRESULT '" + Request.QueryString["REGNO"] + "','" + reader[0].ToString() + "','FINALSCORING'";
								conn.ExecuteNonQuery();

								hitornot = 1;
							}
						}
					}
					else if(reader[6].ToString().Replace(" ","").Equals("1"))
					{
						conn.QueryString = reader[4].ToString() + "'" + Request.QueryString[reader[7].ToString()] + "'";
						conn.ExecuteQuery();

						if(conn.GetRowCount() != 0)
						{
							
							if(MyConnection.ConvertToDouble(conn.GetFieldValue(0,0).ToString().Replace(",",".")) < MyConnection.ConvertToDouble(reader[5].ToString().Replace(",",".")))
							{
								conn.QueryString = "EXEC SCORING_INSERTSCORINGRULEREASONRESULT '" + Request.QueryString["REGNO"] + "','" + reader[0].ToString() + "','FINALSCORING'";
								conn.ExecuteNonQuery();

								hitornot = 1;
							}
						}
					}
					else if(reader[6].ToString().Replace(" ","").Equals("2"))
					{
						conn.QueryString = reader[4].ToString() + "'" + Request.QueryString[reader[7].ToString()] + "'";
						conn.ExecuteQuery();

						if(conn.GetRowCount() != 0)
						{
							
							if(MyConnection.ConvertToDouble(conn.GetFieldValue(0,0).ToString().Replace(",",".")) > MyConnection.ConvertToDouble(reader[5].ToString().Replace(",",".")))
							{
								conn.QueryString = "EXEC SCORING_INSERTSCORINGRULEREASONRESULT '" + Request.QueryString["REGNO"] + "','" + reader[0].ToString() + "','FINALSCORING'";
								conn.ExecuteNonQuery();

								hitornot = 1;
							}
						}
					}
					else if(reader[6].ToString().Replace(" ","").Equals("3"))
					{
						conn.QueryString = reader[4].ToString() + "'" + Request.QueryString[reader[7].ToString()] + "'";
						conn.ExecuteQuery();

						if(conn.GetRowCount() != 0)
						{
							if(MyConnection.ConvertToDouble(conn.GetFieldValue(0,0).ToString().Replace(",",".")) >= MyConnection.ConvertToDouble(reader[5].ToString().Replace(",",".")))
							{
								conn.QueryString = "EXEC SCORING_INSERTSCORINGRULEREASONRESULT '" + Request.QueryString["REGNO"] + "','" + reader[0].ToString() + "','FINALSCORING'";
								conn.ExecuteNonQuery();

								hitornot = 1;
							}
						}
					}
					else if(reader[6].ToString().Replace(" ","").Equals("4"))
					{
						if(resulttotal <= MyConnection.ConvertToDouble(reader[5].ToString().Replace(",",".")))
						{
							conn.QueryString = "EXEC SCORING_INSERTSCORINGRULEREASONRESULT '" + Request.QueryString["REGNO"] + "','" + reader[0].ToString() + "','FINALSCORING'";
							conn.ExecuteNonQuery();

							hitornot = 1;
						}
					}
				}
			}

			int idrfscoringoverallresult;
			if(lowestscore > resulttotal || hitornot == 1)
			{
				idrfscoringoverallresult = 0;
			}
			else
			{
				idrfscoringoverallresult = 1;
			}


			conn.QueryString = "EXEC SCORING_INSERTSCORINGRESULT '" + Request.QueryString["REGNO"] + "','" + idrfscoringoverallresult + "','" + idresult + "','FINALSCORING'";
			conn.ExecuteNonQuery();
		
			conn.QueryString = "SELECT PScounter, FScounter FROM SCORING_COUNTER " + 
				"WHERE AP_REGNO = '" + Request.QueryString["REGNO"] + "'";
			conn.ExecuteQuery();

			int PScounter = Convert.ToInt32(conn.GetFieldValue("PScounter").ToString());
			int FScounter = Convert.ToInt32(conn.GetFieldValue("FScounter").ToString());
			int total = PScounter + FScounter;

			conn.QueryString = "SELECT MAX_SCORING FROM APP_PARAMETER";
			conn.ExecuteQuery();
			int max = Convert.ToInt32(conn.GetFieldValue("MAX_SCORING").ToString());

			if(FScounter < max)
			{
				FScounter = max - FScounter;
				Tools.popMessage(this,"Success ! You have " + FScounter.ToString() + " left chance to do prescoring and finalscoring !");
			}
			else if(FScounter >= max)
			{
				Tools.popMessage(this,"Success ! Your chance is 0 ! You can't do any scoring anymore !");
			}
		}

		private string getScoreTotal(double result, out string proprosiaccount, string idTemplate, out string iditem)
		{
			SqlDataReader reader;
			MyConnection con = new MyConnection();
			con.OpenConnection();
			string resultstr = "";
			string idItem = "";
			iditem = "";
			/*reader = con.Query("SELECT ID, LOWESTSCORE, HIGHESTSCORE, SCORERESULT, PROPORSIACCOUNT, ISHIGHEST, ISLOWEST " + 
				"FROM RFSCORINGCUTOFFSCORE, RFSCORINGCUTOFFITEMPERTEMPLATE WHERE ISACTIVE = '1'");*/

			reader = con.Query("SELECT IDITEM,IDTEMPLATE,CONDITION,PARAMETER,COLUMNNAME,RESULT,OPERATOR FROM RFSCORINGCUTOFFITEMPERTEMPLATE WHERE [IDTEMPLATE] = '" + idTemplate + "' AND CONDITION <> ''");

			if(reader.HasRows)
			{
				while(reader.Read())
				{
					string condition = reader[2].ToString();
					string parameter = reader[3].ToString();
					string columnname = reader[4].ToString();

					conn.QueryString = condition + " '" + Request.QueryString[parameter].ToString() + "'";
					conn.ExecuteQuery();

					if(reader[6].ToString() == "=")
					{
						if(reader[5].ToString() == conn.GetFieldValue(columnname))
						{
							idItem = reader[0].ToString();
							iditem = idItem;
							break;
						}
					}
					else if(reader[6].ToString() == "!=")
					{
						if(reader[5].ToString() != conn.GetFieldValue(columnname))
						{
							idItem = reader[0].ToString();
							iditem = idItem;
							break;
						}
					}
					else if(reader[6].ToString() == ">")
					{
						if(MyConnection.ConvertToDouble(reader[5].ToString()) > MyConnection.ConvertToDouble(conn.GetFieldValue(columnname)))
						{
							idItem = reader[0].ToString();
							iditem = idItem;
							break;
						}
					}
					else if(reader[6].ToString() == "<")
					{
						if(MyConnection.ConvertToDouble(reader[5].ToString()) < MyConnection.ConvertToDouble(conn.GetFieldValue(columnname)))
						{
							idItem = reader[0].ToString();
							iditem = idItem;
							break;
						}
					}
					else if(reader[6].ToString() == "<=")
					{
						if(MyConnection.ConvertToDouble(reader[5].ToString()) <= MyConnection.ConvertToDouble(conn.GetFieldValue(columnname)))
						{
							idItem = reader[0].ToString();
							iditem = idItem;
							break;
						}
					}
					else if(reader[6].ToString() == ">=")
					{
						if(MyConnection.ConvertToDouble(reader[5].ToString()) >= MyConnection.ConvertToDouble(conn.GetFieldValue(columnname)))
						{
							idItem = reader[0].ToString();
							iditem = idItem;
							break;
						}
					}
				}
			}

			reader.Close();

			if(idItem == "")
			{
				reader = con.Query("SELECT IDITEM,IDTEMPLATE,CONDITION,PARAMETER,COLUMNNAME,RESULT,OPERATOR FROM RFSCORINGCUTOFFITEMPERTEMPLATE WHERE [IDTEMPLATE] = '" + idTemplate + "' AND CONDITION = ''");

				if(reader.HasRows)
				{
					while(reader.Read())
					{
						idItem = reader[0].ToString();
						iditem = idItem;
						break;
					}
				}

				reader.Close();
			}

			reader = con.Query("SELECT RFSCORINGCUTOFFSCORE.ID, RFSCORINGCUTOFFSCORE.LOWESTSCORE, " + 
				"RFSCORINGCUTOFFSCORE.HIGHESTSCORE, RFSCORINGCUTOFFSCORE.SCORERESULT, " + 
				"RFSCORINGCUTOFFSCORE.PROPORSIACCOUNT, RFSCORINGCUTOFFSCORE.ISHIGHEST, " +
				"RFSCORINGCUTOFFSCORE.ISLOWEST " +
				"FROM RFSCORINGCUTOFFSCORE " +
				"WHERE RFSCORINGCUTOFFSCORE.IDITEM =" + idItem + " " +
				"AND RFSCORINGCUTOFFSCORE.ISACTIVE = '1'");
		
			if(reader.HasRows)
			{
				while(reader.Read())
				{

					if(reader[5].ToString().Equals("1"))
					{
						if((result >= MyConnection.ConvertToDouble(reader[1].ToString().Replace(",",".")) &&
							result <= MyConnection.ConvertToDouble(reader[2].ToString().Replace(",","."))) ||
							result >= MyConnection.ConvertToDouble(reader[1].ToString().Replace(",",".")))
						{
							proprosiaccount = reader[4].ToString();
							resultstr = reader[0].ToString();
							con.CloseConnection();
							return resultstr;
						}
					}
					else if(reader[6].ToString().Equals("1"))
					{
						if(result <= MyConnection.ConvertToDouble(reader[2].ToString().Replace(",",".")))
						{
							proprosiaccount = reader[4].ToString();
							resultstr = reader[0].ToString();
							con.CloseConnection();
							return resultstr;
						}
					}
					else
					{
						if(result >= MyConnection.ConvertToDouble(reader[1].ToString().Replace(",",".")) &&
							result <= MyConnection.ConvertToDouble(reader[2].ToString().Replace(",",".")))
						{
							proprosiaccount = reader[4].ToString();
							resultstr = reader[0].ToString();
							con.CloseConnection();
							return resultstr;
						}
					}
				}
			}
			con.CloseConnection();
			proprosiaccount = "";
			return "";
		}

		//id itu idattribute
		//vals itu nilai yang akan dibandingkan
		private double GetScore(string id, string valss, string idtemplate)
		{
			double vals = -9999999999.0;

			if(valss != "")
			{
				vals = MyConnection.ConvertToDouble(valss.Replace(",","."));
			}

			conn.QueryString = "SELECT ID, ISRANGE FROM RFSCORINGATTRIBUTE WHERE ISACTIVE = '1' AND ID = '" + id + "'";
			conn.ExecuteQuery();
			
			SqlDataReader reader;
			MyConnection con = new MyConnection();
			int isrange = Convert.ToInt32(conn.GetFieldValue("ISRANGE").ToString());

			if(isrange == 1)
			{
				con.OpenConnection();
				/*reader = con.Query("SELECT LOWESTSCORE, HIGHESTSCORE, WEIGHT " + 
					"FROM RFSCORINGWEIGHTRANGEATTRIBUTE WHERE IDATTRIBUTE = '" + id + "' AND IDTEMPLATE = '" + idtemplate + "'");*/
				reader = con.Query("SELECT LOWESTSCORE, HIGHESTSCORE, WEIGHT FROM RFSCORING_RANGEATTPERTEMPLATE " +
					"WHERE IDATTRIBUTERANGE = '" + id + "' AND IDTEMPLATE = '" + idtemplate + "'");

				if(reader.HasRows)
				{
					while(reader.Read())
					{

						if(reader[0].ToString().Replace(" ","").ToUpper().Equals("NOINFORMATION") && 
							reader[1].ToString().Replace(" ","").ToUpper().Equals("NOINFORMATION"))
						{
							if(valss == "")
							{
								return MyConnection.ConvertToDouble(reader[2].ToString().Replace(",","."));
							}
						}
						else
						{
							if(reader[0].ToString().Equals("BELOW"))
							{
								if(valss != "")
								{
									if(vals <= MyConnection.ConvertToDouble(reader[1].ToString().Replace(",",".")))
									{
										return MyConnection.ConvertToDouble(reader[2].ToString().Replace(",","."));
									}
								}
							}
							else if(reader[1].ToString().Equals("HIGH"))
							{
								if(valss != "")
								{
									if(vals >= MyConnection.ConvertToDouble(reader[0].ToString().Replace(",",".")))
									{
										return MyConnection.ConvertToDouble(reader[2].ToString().Replace(",","."));
									}
								}
							}
							else 
							{
								if(valss != "")
								{
									if(vals >= MyConnection.ConvertToDouble(reader[0].ToString().Replace(",",".")) &&
										vals <= MyConnection.ConvertToDouble(reader[1].ToString().Replace(",",".")))
									{
										return MyConnection.ConvertToDouble(reader[2].ToString().Replace(",","."));
									}
								}
								else if(valss == "")
								{
									conn.QueryString = "SELECT LOWESTSCORE, HIGHESTSCORE, WEIGHT FROM RFSCORING_RANGEATTPERTEMPLATE " +
										"WHERE IDATTRIBUTERANGE = '" + id + "' AND IDTEMPLATE = '" + idtemplate + "' AND LOWESTSCORE = 'BELOW'";
									conn.ExecuteQuery();

									return MyConnection.ConvertToDouble(conn.GetFieldValue("WEIGHT"));
								}
							}
						}
					}
				}
				else
				{
					Tools.popMessage(this,"JENIS VARIABLE TIDAK TERDAFTAR DALAM DATABASE SCORING !");
				}
				con.CloseConnection();
			}
			else if(isrange == 0)
			{
				con.OpenConnection();
				/*reader = con.Query("SELECT WEIGHT " + 
					"FROM RFSCORINGWEIGHTNONRANGEATTRIBUTE WHERE IDATTRIBUTE = '" + id + "'" +
					" AND [VALUE] = '" + vals + "' AND IDTEMPLATE = '" + idtemplate + "'");*/
				
				reader = con.Query("SELECT RFSCORING_NONRANGEATTPERTEMPLATE.WEIGHT " +
					"FROM RFSCORING_NONRANGEATTPERTEMPLATE, RFSCORINGWEIGHTNONRANGEATTRIBUTE " +
					"WHERE RFSCORING_NONRANGEATTPERTEMPLATE.IDTEMPLATE = '" + idtemplate + "'" +
					"AND RFSCORINGWEIGHTNONRANGEATTRIBUTE.ID = RFSCORING_NONRANGEATTPERTEMPLATE.IDATTRIBUTENONRANGE " +
					"AND RFSCORINGWEIGHTNONRANGEATTRIBUTE.[VALUE] = '" + valss + "'" +
					"AND RFSCORINGWEIGHTNONRANGEATTRIBUTE.IDATTRIBUTE = '" + id + "'");

				if(reader.HasRows)
				{
					while(reader.Read())
					{
						return MyConnection.ConvertToDouble(reader[0].ToString().Replace(",","."));
					}
				}

				con.CloseConnection();
			}

			if(isrange == 0)
			{
				conn.QueryString  = "SELECT min(convert(float,RFSCORING_NONRANGEATTPERTEMPLATE.WEIGHT)) as WEIGHT " +
					"FROM RFSCORING_NONRANGEATTPERTEMPLATE " +
					"WHERE RFSCORING_NONRANGEATTPERTEMPLATE.IDTEMPLATE = '" + idtemplate + "'" +
					"AND RFSCORING_NONRANGEATTPERTEMPLATE.IDATTRIBUTENONRANGE = '" + id + "'";
				conn.ExecuteQuery();

				return MyConnection.ConvertToDouble(conn.GetFieldValue("WEIGHT").ToString().Replace(",","."));
			}
			else
			{
				conn.QueryString  = "SELECT min(convert(float,RFSCORING_RANGEATTPERTEMPLATE.WEIGHT)) as WEIGHT " +
					"FROM RFSCORING_RANGEATTPERTEMPLATE " +
					"WHERE RFSCORING_RANGEATTPERTEMPLATE.IDTEMPLATE = '" + idtemplate + "'" +
					"AND RFSCORING_RANGEATTPERTEMPLATE.IDATTRIBUTERANGE = '" + id + "'";

				conn.ExecuteQuery();

				return MyConnection.ConvertToDouble(conn.GetFieldValue("WEIGHT").ToString().Replace(",","."));
			}
			//return MyConnection.ConvertToDouble(Convert.ToString(-1.0).Replace(",","."));
		}


		//Procedure ini melakukan setting disable pada kelompok Contractor scoring infoumum
		private void setDisableContractor()
		{
			TXT_PLAFOND_DP.ReadOnly=true;
			TXT_PLAFOND_DP.BackColor = Color.Gainsboro;
			TXTMC_CONT_PEAK_DEFICIT_CF.ReadOnly=true;
			TXTMC_CONT_PEAK_DEFICIT_CF.BackColor=Color.Gainsboro;
			TXT_PLAFOND_TOT_VAL_PROJECTS.ReadOnly=true; 
			TXT_PLAFOND_TOT_VAL_PROJECTS.BackColor = Color.Gainsboro;
			TXT_PLAFOND_PRSN_PROJ_COST.ReadOnly =true;
			TXT_PLAFOND_PRSN_PROJ_COST.BackColor = Color.Gainsboro;
			TXT_PLAFOND_TOP.ReadOnly =true;
			TXT_PLAFOND_TOP.BackColor = Color.Gainsboro;
			TXT_CL_EXIST_WC_BM.ReadOnly =true;
			TXT_CL_EXIST_WC_BM.BackColor = Color.Gainsboro;
			TXT_CL_EXIST_WC_OBANK.ReadOnly =true;
			TXT_CL_EXIST_WC_OBANK.BackColor = Color.Gainsboro;
			TXT_PROJ_COST.ReadOnly=true;
			TXT_PROJ_COST.BackColor = Color.Gainsboro;
			TXTMC_CONT_PEAK_DEFICIT_CF2.ReadOnly=true;
			TXTMC_CONT_PEAK_DEFICIT_CF2.BackColor=Color.Gainsboro;
			TXT_NUM_TERMYN.ReadOnly=true;
			TXT_NUM_TERMYN.BackColor = Color.Gainsboro;
			TXT_CONTR_TURNKEY_PROJ_COST.ReadOnly=true;
			TXT_CONTR_TURNKEY_PROJ_COST.BackColor = Color.Gainsboro;
			TXT_PLAFOND_DP.ReadOnly=true;
			TXT_PLAFOND_DP.BackColor = Color.Gainsboro;
		}


		//Procedure ini melakukan setting disable pada kelompok Non Cash Loan scoring infoumum
		private void setDisabledNCL()
		{
			TXT_SB_NC_PROJ_PA_GENERAL.ReadOnly=true;
			TXT_SB_NC_PROJ_PA_GENERAL.BackColor = Color.Gainsboro;
			TXT_NC_PROJ_PA_PURCHASE_BOND.ReadOnly=true;
			TXT_NC_PROJ_PA_PURCHASE_BOND.BackColor = Color.Gainsboro;
			TXT_BID_BOND.ReadOnly=true;
			TXT_BID_BOND.BackColor = Color.Gainsboro;
			TXT_PRSN_PROB_SUCCESS_BID_BOND.ReadOnly=true;
			TXT_PRSN_PROB_SUCCESS_BID_BOND.BackColor = Color.Gainsboro;
			TXT_ADV_BOND.ReadOnly=true;
			TXT_ADV_BOND.BackColor = Color.Gainsboro;
			TXT_PRFRMN_BOND.ReadOnly=true;
			TXT_PRFRMN_BOND.BackColor = Color.Gainsboro;
			TXT_PRSN_RET_BOND.ReadOnly=true;
			TXT_PRSN_RET_BOND.BackColor = Color.Gainsboro;
			TXT_MC_NC_TOTAMOUNT.ReadOnly=true;
			TXT_MC_NC_TOTAMOUNT.BackColor = Color.Gainsboro;
			TXT_PRSN_PURCHASE_BOND.ReadOnly=true;
			TXT_PRSN_PURCHASE_BOND.BackColor = Color.Gainsboro;
			TXTMC_CONT_PEAK_DEFICIT_CF3.ReadOnly=true;
			TXTMC_CONT_PEAK_DEFICIT_CF3.BackColor=Color.Gainsboro;
			SB_AVG_VALUELC_YEAR.ReadOnly=true;
			SB_AVG_VALUELC_YEAR.BackColor = Color.Gainsboro;
			TXT_SB_AVG_TERMLC.ReadOnly=true;
			TXT_SB_AVG_TERMLC.BackColor = Color.Gainsboro;
		}


		//Procedure ini melakukan setting enable pada kelompok Non Cash Loan scoring infoumum
		private void setEnabledNCL()
		{
			string vIN_SMALL, vIN_MIDDLE;

			// mengambil tipe bisnis unit dari initial
			
			conn.QueryString = "select * from rfinitial";
			conn.ExecuteQuery();
			vIN_SMALL = conn.GetFieldValue("IN_SMALL");
			vIN_MIDDLE = conn.GetFieldValue("IN_MIDDLE");
			



			// mengambil tipe bisnis unit dari aplikasi
			conn.QueryString = "select ap_regno,ap_businessunit from application where ap_regno = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			string tipeBusiness = conn.GetFieldValue("ap_businessunit");

			// field untuk small
			if (tipeBusiness == vIN_SMALL)
			{
				TXT_SB_NC_PROJ_PA_GENERAL.ReadOnly=false;
				TXT_SB_NC_PROJ_PA_GENERAL.BackColor = Color.White;
				TXT_NC_PROJ_PA_PURCHASE_BOND.ReadOnly=false;
				TXT_NC_PROJ_PA_PURCHASE_BOND.BackColor = Color.White;
				TXT_BID_BOND.ReadOnly=false;
				TXT_BID_BOND.BackColor = Color.White;
				TXT_PRSN_PROB_SUCCESS_BID_BOND.ReadOnly=false;
				TXT_PRSN_PROB_SUCCESS_BID_BOND.BackColor = Color.White;
				TXT_ADV_BOND.ReadOnly=false;
				TXT_ADV_BOND.BackColor = Color.White;
				TXT_PRFRMN_BOND.ReadOnly=false;
				TXT_PRFRMN_BOND.BackColor = Color.White;
				TXT_PRSN_RET_BOND.ReadOnly=false;
				TXT_PRSN_RET_BOND.BackColor = Color.White;
				TXT_PRSN_PURCHASE_BOND.ReadOnly=false;
				TXT_PRSN_PURCHASE_BOND.BackColor = Color.White;
				SB_AVG_VALUELC_YEAR.ReadOnly=false;
				SB_AVG_VALUELC_YEAR.BackColor = Color.White;
				TXT_SB_AVG_TERMLC.ReadOnly=false;
				TXT_SB_AVG_TERMLC.BackColor = Color.White;
				lblPurchaseBondSml.Visible=true;
				lblBondOtherMdl.Visible=false;
			}
				// field untuk middle
			else if (tipeBusiness == vIN_MIDDLE)
			{
				TXT_BID_BOND.ReadOnly=false;
				TXT_BID_BOND.BackColor = Color.White;
				TXT_ADV_BOND.ReadOnly=false;
				TXT_ADV_BOND.BackColor = Color.White;
				TXT_PRFRMN_BOND.ReadOnly=false;
				TXT_PRFRMN_BOND.BackColor = Color.White;
				TXT_PRSN_RET_BOND.ReadOnly=false;
				TXT_PRSN_RET_BOND.BackColor = Color.White;
				TXT_MC_NC_TOTAMOUNT.ReadOnly=false;
				TXT_MC_NC_TOTAMOUNT.BackColor = Color.White;
				TXT_PRSN_PURCHASE_BOND.ReadOnly=false;
				TXT_PRSN_PURCHASE_BOND.BackColor = Color.White;
				TXTMC_CONT_PEAK_DEFICIT_CF3.ReadOnly=false;
				TXTMC_CONT_PEAK_DEFICIT_CF3.BackColor=Color.White;
				SB_AVG_VALUELC_YEAR.ReadOnly=false;
				SB_AVG_VALUELC_YEAR.BackColor = Color.White;
				TXT_SB_AVG_TERMLC.ReadOnly=false;
				TXT_SB_AVG_TERMLC.BackColor = Color.White;
				lblPurchaseBondSml.Visible=false;
				lblBondOtherMdl.Visible=true;
			}
		}

		//Procedure ini melakukan setting disable pada kelompok Contractor scoring infoumum
		private void setEnableContractor()
		{
			//cek small middle
			conn.QueryString="select ap_regno,ap_businessunit from application where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			string tipeBusiness=conn.GetFieldValue("ap_businessunit");

			//cek picklist contractor line type
			switch(DDL_CONTRACTORREQLINETYPE.SelectedValue)
			{ 
				case "2" : 
					if(tipeBusiness.Trim()=="SM100")
					{
						TXT_PLAFOND_DP.ReadOnly=false;
						TXT_PLAFOND_DP.BackColor = Color.White;
						TXT_PLAFOND_TOT_VAL_PROJECTS.ReadOnly=false; 
						TXT_PLAFOND_TOT_VAL_PROJECTS.BackColor = Color.White;
						TXT_PLAFOND_PRSN_PROJ_COST.ReadOnly  =false;
						TXT_PLAFOND_PRSN_PROJ_COST.BackColor = Color.White;
						TXT_PLAFOND_TOP.ReadOnly  =false;
						TXT_PLAFOND_TOP.BackColor = Color.White;
						TXT_CL_EXIST_WC_BM.ReadOnly  =false;
						TXT_CL_EXIST_WC_BM.BackColor = Color.White;
						TXT_CL_EXIST_WC_OBANK.ReadOnly  =false;
						TXT_CL_EXIST_WC_OBANK.BackColor = Color.White;
					}
					else if(tipeBusiness.Trim()=="MD100")
					{
						TXTMC_CONT_PEAK_DEFICIT_CF2.ReadOnly=false;
						TXTMC_CONT_PEAK_DEFICIT_CF2.BackColor=Color.White;
					}
					break;
				case "3" :
					if(tipeBusiness.Trim()=="SM100")
					{
						TXT_PLAFOND_DP.ReadOnly=false;
						TXT_PLAFOND_DP.BackColor = Color.White;
						TXT_PROJ_COST.ReadOnly=false;
						TXT_PROJ_COST.BackColor = Color.White;
						TXT_NUM_TERMYN.ReadOnly=false;
						TXT_NUM_TERMYN.BackColor = Color.White;
					}
					else if(tipeBusiness.Trim()=="MD100")
					{
					}
					break;
				case "4" :
					TXT_PLAFOND_DP.ReadOnly=false;
					TXT_PLAFOND_DP.BackColor = Color.White;
					TXT_CONTR_TURNKEY_PROJ_COST.ReadOnly=false;
					TXT_CONTR_TURNKEY_PROJ_COST.BackColor = Color.White;
					break;
				case "5" :
					if(tipeBusiness.Trim()=="MD100")
					{
						TXTMC_CONT_PEAK_DEFICIT_CF.ReadOnly=false;					
						TXTMC_CONT_PEAK_DEFICIT_CF.BackColor = Color.White;
					}
					break;
			}			
		}


		//Procedure ini melakukan setting enable pada kelompok PUKK dan MICRO pada scoring infoumum
		private void SetEnabledPUKKMICRO()
		{
			string tipeBusiness="";
			conn.QueryString="exec SP_GETBUSINESSTYPE '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			tipeBusiness=conn.GetFieldValue("tipeKey");
			if (tipeBusiness.Equals("SMALL_SCR"))
			{
				TXT_PURCHASING_PLANT_AMOUNT_M.ReadOnly=true;
				TXT_PURCHASING_PLANT_AMOUNT_M.BackColor = Color.Gainsboro;
				TXT_PRSN_INTEREST_PA.ReadOnly=true;
				TXT_PRSN_INTEREST_PA.BackColor = Color.Gainsboro;
				TXT_TERMYN_MONTH.ReadOnly=true;
				TXT_TERMYN_MONTH.BackColor = Color.Gainsboro;
				TXT_AVG_NET_PROFIT.ReadOnly=true;
				TXT_AVG_NET_PROFIT.BackColor = Color.Gainsboro;
				DDL_EXISTING_FAC.Enabled=false;
				DDL_EXISTING_FAC.BackColor = Color.Gainsboro;
				TXT_PURCHASING_PLANT_AMOUNT_PUKK.ReadOnly=true;
				TXT_PURCHASING_PLANT_AMOUNT_PUKK.BackColor = Color.Gainsboro;
				DDL_JAMINANTAMBAHAN.Enabled=false;
				DDL_JAMINANTAMBAHAN.BackColor = Color.Gainsboro;
				DDL_PUKKCURR.Enabled=false;
				DDL_PUKKCURR.BackColor = Color.Gainsboro;
				DDL_PUKKPAST.Enabled=false;
				DDL_PUKKPAST.BackColor = Color.Gainsboro;
				DDL_LISENSI.Enabled=false;
				DDL_LISENSI.BackColor = Color.Gainsboro;
				DDL_PUKK_PAST_BM.Enabled=false;
				DDL_PUKK_PAST_BM.BackColor = Color.Gainsboro;


				// disable semua field untuk Contractor
				setDisableContractor();

				// disable (dulu) semua field untuk NCL
				setDisabledNCL();

				// enable field untuk NCL (tergantun bisnis unit)
				setEnabledNCL();	

			}
			else if (tipeBusiness.Equals("MIDDLE_SCR"))
			{
				TXT_PURCHASING_PLANT_AMOUNT_M.ReadOnly=true;
				TXT_PURCHASING_PLANT_AMOUNT_M.BackColor = Color.Gainsboro;
				TXT_PRSN_INTEREST_PA.ReadOnly=true;
				TXT_PRSN_INTEREST_PA.BackColor = Color.Gainsboro;
				TXT_TERMYN_MONTH.ReadOnly=true;
				TXT_TERMYN_MONTH.BackColor = Color.Gainsboro;
				TXT_AVG_NET_PROFIT.ReadOnly=true;
				TXT_AVG_NET_PROFIT.BackColor = Color.Gainsboro;
				DDL_EXISTING_FAC.Enabled=false;
				DDL_EXISTING_FAC.BackColor = Color.Gainsboro;
				TXT_PURCHASING_PLANT_AMOUNT_PUKK.ReadOnly=true;
				TXT_PURCHASING_PLANT_AMOUNT_PUKK.BackColor = Color.Gainsboro;
				DDL_JAMINANTAMBAHAN.Enabled=false;
				DDL_JAMINANTAMBAHAN.BackColor = Color.Gainsboro;
				DDL_PUKKCURR.Enabled=false;
				DDL_PUKKCURR.BackColor = Color.Gainsboro;
				DDL_PUKKPAST.Enabled=false;
				DDL_PUKKPAST.BackColor = Color.Gainsboro;
				DDL_LISENSI.Enabled=false;
				DDL_LISENSI.BackColor = Color.Gainsboro;
				DDL_PUKK_PAST_BM.Enabled=false;
				DDL_PUKK_PAST_BM.BackColor = Color.Gainsboro;

				// disable semua field untuk Contractor
				setDisableContractor();

				// disable (dulu) semua field untuk NCL
				setDisabledNCL();

				
				// enable field untuk NCL (tergantun bisnis unit)
				setEnabledNCL();	

			}
			else if (tipeBusiness.Equals("MICRO_SCR")||tipeBusiness.Equals("LOWLINE_SCR"))
			{
				TXT_PURCHASING_PLANT_AMOUNT_PUKK.ReadOnly=true;
				TXT_PURCHASING_PLANT_AMOUNT_PUKK.BackColor = Color.Gainsboro;
				DDL_JAMINANTAMBAHAN.Enabled=false;
				DDL_JAMINANTAMBAHAN.BackColor = Color.Gainsboro;
				DDL_PUKKCURR.Enabled=false;
				DDL_PUKKCURR.BackColor = Color.Gainsboro;
				DDL_PUKKPAST.Enabled=false;
				DDL_PUKKPAST.BackColor = Color.Gainsboro;
				DDL_LISENSI.Enabled=false;
				DDL_LISENSI.BackColor = Color.Gainsboro;
				DDL_PUKK_PAST_BM.Enabled=false;
				DDL_PUKK_PAST_BM.BackColor = Color.Gainsboro;
				TXT_ACCEPT_PROJ_COST_KI.ReadOnly=true;
				TXT_ACCEPT_PROJ_COST_KI.BackColor = Color.Gainsboro;

				// disable semua field untuk Contractor
				setDisableContractor();

				// disable (dulu) semua field untuk NCL
				setDisabledNCL();

			}
			else if (tipeBusiness.Equals("PUKK_SCR"))
			{
				TXT_PURCHASING_PLANT_AMOUNT_M.ReadOnly=true;
				TXT_PURCHASING_PLANT_AMOUNT_M.BackColor = Color.Gainsboro;
				TXT_PRSN_INTEREST_PA.ReadOnly=true;
				TXT_PRSN_INTEREST_PA.BackColor = Color.Gainsboro;
				TXT_TERMYN_MONTH.ReadOnly=true;
				TXT_TERMYN_MONTH.BackColor = Color.Gainsboro;
				TXT_AVG_NET_PROFIT.ReadOnly=true;
				TXT_AVG_NET_PROFIT.BackColor = Color.Gainsboro;
				DDL_EXISTING_FAC.Enabled=false;
				DDL_EXISTING_FAC.BackColor = Color.Gainsboro;
				TXT_ACCEPT_PROJ_COST_KI.ReadOnly=true;
				TXT_ACCEPT_PROJ_COST_KI.BackColor = Color.Gainsboro;

				// disable semua field untuk Contractor
				setDisableContractor();

				// disable (dulu) semua field untuk NCL
				setDisabledNCL();
			
			}
		}


		protected void DDL_CONTRACTORREQLINETYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//set disable pada kelompok Contractor scoring infoumum
			setEnableContractor();
		}

	}
}
