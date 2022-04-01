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

namespace SME.SPPK
{
	public partial class SPPKPrint_old : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected string regno;
		protected string akhir;
		protected string  koma;
		protected bool adakoma;
		protected string StringUtamaPLUS;
		protected string hasilnya;
		protected Connection conn;// = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");

			
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			regno = Request.QueryString["regno"];

			ViewData(regno);
			ViewSomeData(regno);

			if (!IsPostBack) 
			{
				LBL_NO.Text = Request.QueryString["NO"];
				LBL_CURTIME.Text = Request.QueryString["CURTIME"];
				LBL_LAMP.Text = Request.QueryString["LAMP"];
				LBL_CUST_NAME.Text = Request.QueryString["CUST_NAME"];
				LBL_ADDR.Text = Request.QueryString["ADDR"];
				LBL_ADDR2.Text = Request.QueryString["ADDR2"];
				LBL_ADDR3.Text = Request.QueryString["ADDR3"];
				LBL_CITY.Text = Request.QueryString["CITY"];
				LBL_POSTCODE.Text = Request.QueryString["POSTCODE"];
				LBL_AP_DATE.Text = Request.QueryString["AP_DATE"];
				LBL_BRANCH.Text = Request.QueryString["BRANCH"];
				LBL_MANAGER.Text = Request.QueryString["MANAGER"];
				LBL_BRANCHMANAGER.Text= Request.QueryString["BRANCHMANAGER"];
				LBL_TEMBUSAN.Text = Request.QueryString["TEMBUSAN"];
				LBL_MATERAI.Text = Request.QueryString["MATERAI"];
			}		
		}

		private void ViewData(string regno)
		{						
			conn.QueryString = "SELECT  DISTINCT PRODUCTID,PRODUCTDESC FROM VW_SPPK_VIEW2" +
				" WHERE AP_REGNO ='" + regno + "'";
			conn.ExecuteQuery();
			int jml_product = conn.GetRowCount();

					
			//ambil data product desc yang dimiliki customer
			string[] PRODUCTDESC = new string[jml_product];
			int p = 0;
			DataTable dt = conn.GetDataTable();
			foreach(DataRow dr in dt.Rows) 
			{
				PRODUCTDESC[p] = dr["PRODUCTDESC"].ToString();
				p++;
			}
			

			string Data_Tenor = "Bulan/tahun/tmt, sejak ";
			
			for (int u = 0 ; u < jml_product; u++)
			{
				//untuk judul produk 
				Label LBL_NO = new Label();
				LBL_NO.Text = (u+1)+ ". ";
				LBL_NO.Font.Bold = true;
				Label LBL_PRODUCTDESC = new Label();
				LBL_PRODUCTDESC.ID = "LBL_PRODUCTDESC"+u;
				LBL_PRODUCTDESC.Text = PRODUCTDESC[u];
				LBL_PRODUCTDESC.Font.Bold = true;
				LBL_PRODUCTDESC.Font.Underline = true;
				Table Tabelm = new Table();
				Tabelm.ID = "Tabelm"+u;
				int mn = 0;
				Tabelm.Rows.Add(new TableRow());
				Tabelm.Rows[mn].Cells.Add (new TableCell());
				Tabelm.Rows[mn].Cells.Add (new TableCell());
				Tabelm.Rows[mn].Cells[0].Controls.Add(LBL_NO);
				Tabelm.Rows[mn].Cells[1].Controls.Add(LBL_PRODUCTDESC);
				Tabelm.Rows[mn].Cells[0].Font.Size = FontUnit.XSmall;
				Tabelm.Rows[mn].Cells[1].Font.Size = FontUnit.XSmall;
				Tabelm.Rows[mn].VerticalAlign = VerticalAlign.Top;
				
				PH1.Controls.Add(Tabelm);

				conn.QueryString = "SELECT distinct APPTYPEDESC " +
					" 	FROM VW_SPPK_VIEW2	"+
					" WHERE AP_REGNO ='" + regno + "' AND PRODUCTDESC= '" +PRODUCTDESC[u]+ "' ";
				conn.ExecuteQuery();
			
				int jml_tipeproduct = conn.GetRowCount();

				string[] APPTYPE = new string[jml_tipeproduct];
				int y = 0;
				DataTable dt3 = conn.GetDataTable();
				foreach(DataRow dr3 in dt3.Rows) 
				{
					APPTYPE[y] = dr3["APPTYPEDESC"].ToString();
					y++;
				}

			
				for (int i=0; i < jml_tipeproduct; i++)
				{

					string loanpurposedesc, cp_installment;
					string ISINSTALLMENT = "";
					conn.QueryString = "SELECT APPTYPE, CU_REF, AP_SIGNDATE, LOANPURPDESC, PRODUCTID" +
						",CURRENCY, APPTYPEDESC,REVOLVING,CP_REVATACCT,CL_DESC,COLTYPEDESC,CL_COLCLASSIFY,COLCLASSDESC" +
						",CP_LIMIT,CP_TENOR,CP_LOANPURPOSE, ISINSTALLMENT, CP_INSTALLMENT, ISAPPROVAL " +
						" 	FROM VW_SPPK_VIEW2	"+
						" WHERE AP_REGNO ='" + regno + "' AND PRODUCTDESC= '" +PRODUCTDESC[u]+ "' " +
						" AND APPTYPEDESC='" + APPTYPE[i] + "' ";
					conn.ExecuteQuery();
					loanpurposedesc = conn.GetFieldValue("LOANPURPDESC");					
					ISINSTALLMENT	= conn.GetFieldValue("ISINSTALLMENT");

					//tabelj untuk menampilkan apptypedesc dan Tabel u/ menampilkan item2 ...
					Table Tabel = new Table(), Tabelj = new Table();
					Tabel.ID = "Tabel"+u+i;
					Tabelj.ID = "Tabelj"+u+i;
	
					//--- CURRENCY
					LBL_CURRENCY.Text = conn.GetFieldValue("CURRENCY");

					//--- periksa IS_REVOLVING
					//    if (REVOLVING == 1 or REKENING_KORAN == 1) then REVOLVING
					//    else then NON-REVOLVING
					string revolvingtemp;
					if (conn.GetFieldValue("REVOLVING") == "1" || conn.GetFieldValue("CP_REVATACCT") == "1") 
					{
						revolvingtemp = "Revolving";
					}
					else 
					{
						revolvingtemp = "Non revolving";
					}

					//--- ANGSURAN (awal) ---
					//Angsuran/Installment ada kalau : NON-REVOLVING dan ISINSTALLMENT
					//-----------------------
					if (revolvingtemp.ToUpper()!="REVOLVING" && conn.GetFieldValue("ISINSTALLMENT") == "1") 
					{
						cp_installment = conn.GetFieldValue("CP_INSTALLMENT");
					}
					else 
					{
						cp_installment = "";
					}

					//Label LBL_REVOLVING		= new Label();
					//Label LBL_CP_TENOR		= new Label();
					Label LBL_REVOLVING		= new Label();
					Label LBL_CP_TENOR		= new Label();

					//LBL_REVOLVING.ID = "LBL_REVOLVING"+u+i;
					//LBL_REVOLVING.Text = revolvingtemp;
					LBL_REVOLVING.ID = "LBL_REVOLVING"+u+i;
					LBL_REVOLVING.Text = revolvingtemp;

					//--- TENOR
					int CP_TENOR = 0;
					try 
					{
						CP_TENOR = Convert.ToInt16(conn.GetFieldValue("CP_TENOR"));
					} 
					catch {}
					LBL_CP_TENOR.ID = "LBL_CP_TENOR"+u+i;
					LBL_CP_TENOR.Text = CP_TENOR + "  " + Data_Tenor + " .... s/d .....";
					//LBL_CP_TENOR.ID = "LBL_CP_TENOR"+u+i;
					//LBL_CP_TENOR.Text = CP_TENOR + "  " +Data_Tenor + "  ";

					Label LBL_SD = new Label();
					LBL_SD.ID = "LBL_SD"+u+i;
					LBL_SD.Text = " s/d ";
								
					Label LBL_TGL1 = new Label(), LBL_THN1 = new Label();
					Label LBL_TGL2 = new Label(), LBL_THN2 = new Label();
					LBL_TGL1.ID = "LBL_TGL1"+u+i;
					LBL_TGL1.ForeColor = Color.Black;
					LBL_TGL1.Attributes.Add("onkeypress","return numbersonly();");					
					LBL_THN1.ID = "LBL_THN1"+u+i;
					LBL_THN1.ForeColor = Color.Black;
					LBL_THN1.Attributes.Add("onkeypress","return numbersonly();");
					LBL_TGL2.ID = "LBL_TGL2"+u+i;
					LBL_TGL2.ForeColor = Color.Black;
					LBL_TGL2.Attributes.Add("onkeypress","return numbersonly();");
					LBL_THN2.ID = "LBL_THN2"+u+i;
					LBL_THN2.ForeColor = Color.Black;
					LBL_THN2.Attributes.Add("onkeypress","return numbersonly();");
				
					DropDownList DDL_BLN1 = new DropDownList(), DDL_BLN2 = new DropDownList();
					DDL_BLN1.ID = "DDL_BLN1"+u+i;
					DDL_BLN2.ID = "DDL_BLN2"+u+i;
				
					for (int r = 1; r <= 12; r++)
					{
						DDL_BLN1.Items.Add(new ListItem(DateAndTime.MonthName(r, false), r.ToString()));
						DDL_BLN2.Items.Add(new ListItem(DateAndTime.MonthName(r, false), r.ToString()));
					}
				
					//--- SUKU BUNGA / INTEREST
					Label LBL_SUKUBUNGA = new Label(), LBL_PROVISI = new Label();
					Label LBL_SUKUBUNGA_DUEDATE = new Label();
					LBL_SUKUBUNGA.ID = "LBL_SUKUBUNGA"+u+i;
					LBL_SUKUBUNGA.ForeColor = Color.Black;
					LBL_SUKUBUNGA.Attributes.Add("onkeypress","return numbersonly();");

					LBL_SUKUBUNGA_DUEDATE.ID = "LBL_SUKUBUNGA_DUEDATE"+u+i;
					LBL_SUKUBUNGA_DUEDATE.ForeColor = Color.Black;
					LBL_SUKUBUNGA_DUEDATE.Text = "25";	//---by default 25

					LBL_PROVISI.ID = "LBL_PROVISI"+u+i;
					LBL_PROVISI.ForeColor = Color.Black;
					LBL_PROVISI.Attributes.Add("onkeypress","return numbersonly();");

					Label LBL_PROVISI_DESC = new Label();
					LBL_PROVISI_DESC.ID = "LBL_PROVISI_DESC"+u+i;
					LBL_PROVISI_DESC.ForeColor = Color.Black;
					LBL_PROVISI_DESC.Text = " % p.a, dibayar pada saat penandatanganan Akta Perjanjian Kredit ";
																			
					Label LBL_JAMINANUTAMA = new Label(), LBL_JAMINANTAMBAHAN = new Label();
					LBL_JAMINANUTAMA.ID = "LBL_JAMINANUTAMA"+u+i;
					LBL_JAMINANTAMBAHAN.ID = "LBL_JAMINANTAMBAHAN"+u+i;

					Label LBL_JAMINAN = new Label();
					LBL_JAMINAN.ID = "LBL_JAMINAN"+u+i;
					LBL_JAMINAN.Text = "Atas jaminan yang diserahkan akan diikat secara yuridis sempurna sesuai ketentuan" +
						" dan perundang-undangan yang berlaku, biaya pengikatan jaminan menjadi" +
						" beban Debitur.";
			
					Label LBL_ASURANSI = new Label();
					LBL_ASURANSI.ID = "LBL_ASURANSI"+u+i;
					LBL_ASURANSI.Text = "Selama kredit belum lunas, terhadap barang jaminan yang dapat" +
						" diasuransikan harus diasuransikan kepada perusahaan asuransi rekanan" +
						" PT Bank Mandiri (Persero) dengan syarat Banker's Clause PT Bank Mandiri" +
						" (Persero). Nilai pertanggungan sebesar nilai wajar barang jaminan atas" +
						" persetujuan PT Bank Mandiri (Persero), biaya penutupan asuransi menjadi" +
						" beban Debitur.";

					
					Label LBL_TAHUNTARGET = new Label();
					LBL_TAHUNTARGET.ID = "LBL_TAHUNTARGET"+u+i;
					LBL_TAHUNTARGET.ForeColor = Color.Black;

					Label LBL_SUKUBUNGA_DESC = new Label();		
					LBL_SUKUBUNGA_DESC.ID = "LBL_SUKUBUNGA_DESC"+u+i;
					LBL_SUKUBUNGA_DESC.Text	= " % p.a, dibayar efektif dan dibayar pada tanggal setiap bulan dan dapat berubah sewaktu-waktu sesuai ketentuan yang berlaku di Bank Mandiri, perubahan tersebut mengikat Debitur maupun Penjamin cukup dengan cara pemberitahuan tertulis kepada Debitur.";
			
					Label LBL_ANGKATARGET = new Label(),LBL_STOCK = new Label();
					LBL_ANGKATARGET.ID = "LBL_ANGKATARGET"+u+i;
					LBL_ANGKATARGET.ForeColor = Color.Black;
					LBL_STOCK.ID = "LBL_STOCK"+u+i;
				
					Label LBL_TARGET1 = new Label(),LBL_TARGET2 = new Label(),LBL_TARGET3 = new Label();
					LBL_TARGET1.ID ="LBL_TARGET1"+u+i;
					LBL_TARGET1.Text = "Rata-rata per bulan tahun ";
					LBL_TARGET2.ID ="LBL_TARGET2"+u+i;
					LBL_TARGET2.Text = " minimal sebesar Rp. ";
					LBL_TARGET3.ID ="LBL_TARGET3"+u+i;
					LBL_TARGET3.Text = " harus dapat dicapai dan harus tercermin pada rekening Saudara di Bank kami." ;
			
					Label LBL_PENARIKAN = new Label();
					LBL_PENARIKAN.ID = "LBL_PENARIKAN"+u+i;
					LBL_PENARIKAN.Text = "Sesuai kebutuhan dan baki debet harus tercover oleh rumus/komposisi pembiayaan kredit sebagai berikut: ";
				
					Label LBL_KMK1 = new Label(),LBL_KMK2  = new Label(),LBL_KMK3 = new Label();
					Label LBL_KMK4 = new Label(),LBL_KMK5 = new Label(),LBL_KMK6 = new Label();
					LBL_KMK1.ID = "LBL_KMK1"+u+i;
					LBL_KMK1.Text = "KMK Perdagangan/Industri tercover ";
					LBL_KMK2.ID = "LBL_KMK2"+u+i;
					LBL_KMK2.Text = " % Stock dan ";
					LBL_KMK3.ID = "LBL_KMK3"+u+i;
					LBL_KMK3.Text = " % Piutang dagang";
					LBL_KMK4.ID = "LBL_KMK4"+u+i;
					LBL_KMK4.Text = "KMK Kontraktor = ";
					LBL_KMK5.ID = "LBL_KMK5"+u+i;
					LBL_KMK5.Text = " (% x {Prestasi Proyek - Uang muka + Termin)}";

					Label LBL_STOCK1 = new Label(), LBL_PIUTANG = new Label();
					LBL_STOCK1.ID = "LBL_STOCK1"+u+i;
					LBL_STOCK1.ForeColor = Color.Black;
					LBL_PIUTANG.ID = "LBL_PIUTANG"+u+i;
					LBL_PIUTANG.ForeColor = Color.Black;
								
					Label LBL_KMK1DATA = new Label(),LBL_KM1 = new Label(),LBL_SF1 = new Label();
					LBL_KMK1DATA.ID = "LBL_KMK1"+u+i;
					LBL_KMK1DATA.ForeColor = Color.Black;
					LBL_KM1.ID = "LBL_KM1"+u+i;
					LBL_KM1.ForeColor = Color.Black;
					LBL_SF1.ID = "LBL_SF1"+u+i;
					LBL_SF1.ForeColor = Color.Black;

					Label LBL_KI1 = new Label(),LBL_KI2 = new Label(),LBL_KI3 = new Label();
					LBL_KI1.ID = "LBL_KI1"+u+i;
					LBL_KI1.Text = "* KI sesuai kebutuhan progres proyek dengan komposisi kredit maksimal ";
					LBL_KI2.ID = "LBL_KI2"+u+i;
					LBL_KI2.Text = " % dan Self Finanding (SF) ";
					LBL_KI3.ID = "LBL_KI3"+u+i;
					LBL_KI3.Text = " % ";

			
					//Response.Write("LBL_TGL1 = "+ LBL_TGL1.ID +"<br>");
											
					
					Label LBL_APPTYPE = new Label();
					LBL_APPTYPE.ID = "LBL_APPTYPE"+u+i;
					LBL_APPTYPE.Text = APPTYPE[i];
					LBL_APPTYPE.Font.Bold = true; 
					
					//AMBIL NILAI CP_LIMIT DAN KONVERSI TERBILANG...
					string CP_LIMIT = tools.MoneyFormat(conn.GetFieldValue("CP_LIMIT"));					
					//Label LBL_CP_LIMIT		= new Label();
					//Label LBL_NOMINAL_LIMIT = new Label();
					//Label LBL_KURUNG1		= new Label();
					//Label LBL_KURUNG2		= new Label();					
					//LBL_CP_LIMIT.ID = "LBL_CP_LIMIT"+u+i;
					//LBL_CP_LIMIT.Text = LBL_CURRENCY.Text + " " + CP_LIMIT + " ";
					Label LBL_CP_LIMIT	= new Label();
					LBL_CP_LIMIT.ID = "LBL_CP_LIMIT"+u+i;
					LBL_CP_LIMIT.Text = LBL_CURRENCY.Text + " " + CP_LIMIT + " ";
					//LBL_NOMINAL_LIMIT.ID = "LBL_NOMINAL_LIMIT"+u+i;
					//LBL_NOMINAL_LIMIT.Text = SeleksiKonversi(conn.GetFieldValue("CP_LIMIT"));
					//LBL_KURUNG1.ID = "LBL_KURUNG1"+u+i;
					//LBL_KURUNG1.Text = "(";
					//LBL_KURUNG2.ID = "LBL_KURUNG2"+u+i;
					//LBL_KURUNG2.Text = ")";
	
					int jk = 0;
					Tabelj.Rows.Add(new TableRow());
					Tabelj.Rows[jk].Cells.Add (new TableCell());
					Tabelj.Rows[jk].Cells.Add (new TableCell());
					Tabelj.Rows[jk].Cells[0].Text = " * ";
					Tabelj.Rows[jk].Cells[1].Controls.Add(LBL_APPTYPE);
					Tabelj.Rows[jk].Cells[0].Font.Size = FontUnit.XSmall;
					Tabelj.Rows[jk].Cells[1].Font.Size = FontUnit.XSmall;
					Tabelj.Rows[jk].VerticalAlign = VerticalAlign.Top;
				
				
					for (int yy = 0 ; yy < 18; yy++)
					{
					
						Tabel.Rows.Add(new TableRow());

						for ( int z = 0 ; z < 5; z++ )
						{
							Tabel.Rows[yy].Cells.Add (new TableCell());
							Tabel.Rows[yy].Cells[z].Font.Size = FontUnit.XSmall;
							Tabel.Rows[yy].Cells[z].VerticalAlign = VerticalAlign.Top;
						}
					}
					int n = 0;

					/**************************************************************************************
					 * Menghitung Limit Kredit
					 * Kalau PERUBAHAN BARU / WITHDRAWAL
					 *	- dari APPROVAL_DECISION
					 * Kalau SELAIN ITU :
					 *	- dari Customer Information
					 * *************************************************************************************/
					if (conn.GetFieldValue("ISAPPROVAL") == "1")
					{
						string productid, apptype, ad_varcode;
						double rate = 0.00, ad_variance = 0.00;
						productid	= conn.GetFieldValue("PRODUCTID");
						apptype		= conn.GetFieldValue("APPTYPE");
						conn.QueryString = "select APPROVAL_DECISION.*, RATE, INTERESTTYPE " +
							"from APPROVAL_DECISION " +
							"LEFT JOIN RFRATENUMBER on RATENO = AD_RATENO " +
							"LEFT JOIN RFPRODUCT ON RFPRODUCT.PRODUCTID = approval_decision.PRODUCTID " +
							"where AP_REGNO = '"+regno+"' and approval_decision.PRODUCTID = '"+productid+"' and APPTYPE = '"+apptype+ "'" +
							" and ad_seq = (select isnull(max(ad_seq),0) from APPROVAL_DECISION ad1 where ad1.ap_regno = APPROVAL_DECISION.ap_regno and ad1.productid = APPROVAL_DECISION.productid and ad1.apptype = APPROVAL_DECISION.apptype)" +
							" order by AD_SEQ desc";
						conn.ExecuteQuery();

						//---- MENGHITUNG LIMIT KREDIT
						CP_LIMIT = tools.MoneyFormat(conn.GetFieldValue("AD_EXLIMITVAL"));
						LBL_CP_LIMIT.Text = LBL_CURRENCY.Text + " " + CP_LIMIT + " ";
						//LBL_CP_LIMIT.Text = LBL_CURRENCY.Text + " " + CP_LIMIT + " ";
						//LBL_NOMINAL_LIMIT.Text = SeleksiKonversi(conn.GetFieldValue("AD_EXLIMITVAL"));

						//---- MENGHITUNG ANGSURAN
						//     Angsuran ada kalau : NOT-REVOLVING dan (atau?) ISINSTALLMENT
						double AD_INSTALLMENT = 0, AD_EXRPLIMIT = 0, INSTALLMENT;
						if (revolvingtemp.ToUpper()!="REVOLVING" && ISINSTALLMENT == "1") 
						{
							try 
							{
								AD_INSTALLMENT	= Convert.ToDouble(conn.GetFieldValue("AD_INSTALLMENT"));
							} 
							catch {}
							try 
							{
								AD_EXRPLIMIT	= Convert.ToDouble(conn.GetFieldValue("AD_EXRPLIMIT"));
							} 
							catch {}
							INSTALLMENT = AD_INSTALLMENT * AD_EXRPLIMIT;
							cp_installment = INSTALLMENT.ToString();
						}
						
						//---- MENGHITUNG SUKU BUNGA
						if (conn.GetFieldValue("INTERESTTYPE") == "01") 
						{
							// Floating
							try 
							{
								rate		= Convert.ToDouble(conn.GetFieldValue("RATE")) * 100;
							} 
							catch {}
							ad_varcode	= conn.GetFieldValue("AD_VARCODE");
							try 
							{
								ad_variance = Convert.ToDouble(conn.GetFieldValue("AD_VARIANCE"));
							} 
							catch {}							

							LBL_SUKUBUNGA.Text = (ad_varcode == "+" ? rate+ad_variance : (ad_varcode == "-" ? rate-ad_variance : rate)) + "";
						}
						else 
						{
							// Fixed
							LBL_SUKUBUNGA.Text = conn.GetFieldValue("AD_INTEREST");
						}
					}
					else 
					{
						string curef, productid;
						curef		= conn.GetFieldValue("CU_REF");
						productid	= conn.GetFieldValue("PRODUCTID");
						conn.QueryString = "select * from BOOKEDCUST where CU_REF = '"+curef+"' and PRODUCTID = '"+productid+"'";
						conn.ExecuteQuery();

						CP_LIMIT = tools.MoneyFormat(conn.GetFieldValue("BC_LOANAMOUNT"));						
						LBL_CP_LIMIT.Text = LBL_CURRENCY.Text + " " + CP_LIMIT + " ";
						//LBL_CP_LIMIT.Text = LBL_CURRENCY.Text + " " + CP_LIMIT + " ";
						//LBL_NOMINAL_LIMIT.Text = SeleksiKonversi(conn.GetFieldValue("BC_LOANAMOUNT"));
					}
					/*******************************************************************************************/

					Label LBL_CP_INSTALLMENT	= new Label();
					LBL_CP_INSTALLMENT.ID = "LBL_CP_INSTALLMENT"+u+i;
					LBL_CP_INSTALLMENT.Text = LBL_CURRENCY.Text + " " + tools.MoneyFormat(cp_installment);


					Tabel.Rows[n].Cells[0].Text = "a.";
					Tabel.Rows[n].Cells[1].Text = "Limit Kredit ";
					Tabel.Rows[n].Cells[2].Text = " : ";
					if (CP_LIMIT != "" && Convert.ToDouble(CP_LIMIT) > 0) 
					{
						Tabel.Rows[n].Cells[3].Controls.Add(LBL_CP_LIMIT);
						/*
						Tabel.Rows[n].Cells[3].Controls.Add(LBL_CP_LIMIT);
						Tabel.Rows[n].Cells[3].Controls.Add(LBL_KURUNG1);
						Tabel.Rows[n].Cells[3].Controls.Add(LBL_NOMINAL_LIMIT);
						Tabel.Rows[n].Cells[3].Controls.Add(LBL_KURUNG2);
						*/
					}
					else 
					{
						//Tabel.Rows[n].Cells[3].Text = "-";
						LBL_CP_LIMIT.Text = "-";
						Tabel.Rows[n].Cells[3].Controls.Add(LBL_CP_LIMIT);
					}

					n++;
					Tabel.Rows[n].Cells[0].Text = "b.";
					Tabel.Rows[n].Cells[1].Text = "Jenis Kredit ";
					Tabel.Rows[n].Cells[2].Text = " : ";
					Tabel.Rows[n].Cells[3].Text = PRODUCTDESC[u];

					n++;
					Tabel.Rows[n].Cells[0].Text = "c.";
					Tabel.Rows[n].Cells[1].Text = "Sifat Kredit ";
					Tabel.Rows[n].Cells[2].Text = " : ";
					//Tabel.Rows[n].Cells[3].Controls.Add(LBL_REVOLVING);
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_REVOLVING);

					n++;
					Tabel.Rows[n].Cells[0].Text = "d.";
					Tabel.Rows[n].Cells[1].Text = "Tujuan Penggunaan  ";
					Tabel.Rows[n].Cells[2].Text = " : ";
					Tabel.Rows[n].Cells[3].Text = loanpurposedesc;
					//Tabel.Rows[n].Cells[3].Text = conn.GetFieldValue("LOANPURPDESC");

					n++;	
					Tabel.Rows[n].Cells[0].Text = "e.";
					Tabel.Rows[n].Cells[1].Text = "Jangka Waktu ";
					Tabel.Rows[n].Cells[2].Text = " : ";					
					if (CP_TENOR > 0) 
					{
						Tabel.Rows[n].Cells[3].Controls.Add(LBL_CP_TENOR);
						/*
						Tabel.Rows[n].Cells[3].Controls.Add(LBL_CP_TENOR);
						Tabel.Rows[n].Cells[3].Controls.Add(LBL_TGL1);
						Tabel.Rows[n].Cells[3].Controls.Add (DDL_BLN1);
						Tabel.Rows[n].Cells[3].Controls.Add (LBL_THN1);
						Tabel.Rows[n].Cells[3].Controls.Add(LBL_SD);
						Tabel.Rows[n].Cells[3].Controls.Add (LBL_TGL2);
						Tabel.Rows[n].Cells[3].Controls.Add (DDL_BLN2);
						Tabel.Rows[n].Cells[3].Controls.Add (LBL_THN2);
						*/
					}
					else 
					{
						//Tabel.Rows[n].Cells[3].Text = "-";
						LBL_CP_TENOR.Text = "-";
						Tabel.Rows[n].Cells[3].Controls.Add(LBL_CP_TENOR);
					}
	
					n++;
					Tabel.Rows[n].Cells[0].Text = "f.";
					Tabel.Rows[n].Cells[1].Text = "Angsuran ";
					Tabel.Rows[n].Cells[2].Text = " : ";					
					if (cp_installment != "" && Convert.ToDouble(cp_installment) > 0) 
					{
						Tabel.Rows[n].Cells[3].Controls.Add(LBL_CP_INSTALLMENT);
					}
					else 
					{
						LBL_CP_INSTALLMENT.Text = "-";
						Tabel.Rows[n].Cells[3].Controls.Add(LBL_CP_INSTALLMENT);
					}

					n++;
					Tabel.Rows[n].Cells[0].Text = "g.";
					Tabel.Rows[n].Cells[1].Text = "Suku Bunga ";
					Tabel.Rows[n].Cells[2].Text = " : ";
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_SUKUBUNGA);
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_SUKUBUNGA_DESC);
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_SUKUBUNGA_DUEDATE);
					//					Tabel.Rows[n].Cells[3].Controls.Add(LBL_SUKUBUNGA_DESC2);

					n++;
					Tabel.Rows[n].Cells[0].Text = "h.";
					Tabel.Rows[n].Cells[1].Text = " Provisi/Commitment Fee ";
					Tabel.Rows[n].Cells[2].Text = " : ";
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_PROVISI);
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_PROVISI_DESC);

					n++;
					Tabel.Rows[n].Cells[0].Text = "i.";
					Tabel.Rows[n].Cells[1].Text = "Jaminan kredit ";
					Tabel.Rows[n].Cells[2].Text = " : ";
					Tabel.Rows[n].Cells[3].Text = "";
				
					//Ambil nilai JAMINAN UTAMA... CL_COLCLASIFY =01
			
					conn.QueryString = "SELECT DISTINCT CL_DESC,COLTYPEDESC FROM  VW_SPPK_VIEW2 " +
						"WHERE AP_REGNO ='" + regno + "' AND  CL_COLCLASSIFY='01' " +
						" AND PRODUCTDESC ='" + PRODUCTDESC[u]+"' "  +
						" AND APPTYPEDESC='" + APPTYPE[i] + "' ";
					conn.ExecuteQuery();
					int k = conn.GetRowCount();//JUMLAH DATA
					int m = 0;//URUTAN DATA DARI NOL
					if (k == 0)
					{
						LBL_JAMINANUTAMA.Text = "- ";
					}
					else
					{
						string[] UTAMA = new string[k];
						string[] DESC = new string[k];
						string[] TYPE = new string[k];
			
						DataTable dt2 = conn.GetDataTable();
						foreach(DataRow dr in dt2.Rows) 
						{
				
							DESC[m] = dr["CL_DESC"].ToString();
							TYPE[m] = dr["COLTYPEDESC"].ToString();
							if (k == 1)
							{
								LBL_JAMINANUTAMA.Text = DESC[0] + " (" + TYPE[0]+  ")";
							}
								//							else
								//								if (k == 2) 
								//							{
								//								string a = DESC[0] + " (" + TYPE[0]+  ")";
								//								UTAMA[m] = a;
								//								LBL_JAMINANUTAMA.Text = UTAMA[m];
								//								if (m == 1 )
								//								{
								//									UTAMA[m] += " dan " + DESC[1] + " (" + TYPE[1]+  ")";
								//									LBL_JAMINANUTAMA.Text += UTAMA[m];
								//								}
								//							}
							else
							{
								if (m == (k-1)) 
								{
									UTAMA[m] += " dan " + DESC[m] + " (" + TYPE[m]+  ")";
									LBL_JAMINANUTAMA.Text += UTAMA[m];
									
								}
								else
									if (k == 2) 
								{
									string a = DESC[0] + " (" + TYPE[0]+  ")";
									UTAMA[m] = a;
									LBL_JAMINANUTAMA.Text = UTAMA[m];
									if (m == 1 )
									{
										UTAMA[m] = " dan " + DESC[1] + " (" + TYPE[1]+  ")";
										LBL_JAMINANUTAMA.Text += UTAMA[m];
									}
								}
								else
								{
									UTAMA[m] += DESC[m] + " (" + TYPE[m]+  "), ";
									LBL_JAMINANUTAMA.Text += UTAMA[m];
								}
							}
							m++;
						}	
					}//end else if

					//Ambil nilai JAMINAN TAMBAHAN... CL_COLCLASIFY = 02
			 
					conn.QueryString = "SELECT DISTINCT CL_DESC,COLTYPEDESC FROM  VW_SPPK_VIEW2 " +
						"WHERE AP_REGNO ='" + regno + "' AND  CL_COLCLASSIFY='02' " +
						" AND PRODUCTDESC ='" + PRODUCTDESC[u]+"' " +
						" AND APPTYPEDESC='" + APPTYPE[i] + "' ";
					conn.ExecuteQuery();
					int s = conn.GetRowCount();
									
					if (s == 0)
					{
						LBL_JAMINANTAMBAHAN.Text = "- ";
					}
					else
			
					{			
						string[] TAMBAHAN = new string[s];
						string[] DESCT = new string[s];
						string[] TYPET = new string[s];
						int t = 0;
						DataTable dt1 = conn.GetDataTable();
						foreach(DataRow dr in dt1.Rows) 
						{
				
							DESCT[t] = dr["CL_DESC"].ToString();
							TYPET[t] = dr["COLTYPEDESC"].ToString();
							if (s == 1)
							{
								LBL_JAMINANTAMBAHAN.Text= DESCT[0] + " (" + TYPET[0]+  ")";
							} 
							else					
								//								if (s == 2) 
								//							{
								//								string c = DESCT[0] + " (" + TYPET[0]+  ")";
								//								TAMBAHAN[t] = c;
								//								LBL_JAMINANTAMBAHAN.Text = TAMBAHAN[t];
								//						
								//								if (t == 1 )
								//								{
								//									TAMBAHAN[t] += " dan " + DESCT[1] + " (" + TYPET[1]+  ")";
								//									LBL_JAMINANTAMBAHAN.Text += TAMBAHAN[t];
								//						
								//								}
								//							}
								//							else
							{
								if (t == (s-1)) 
								{
									TAMBAHAN[t] += " dan " + DESCT[t] + " (" + TYPET[t]+  ")";
									LBL_JAMINANTAMBAHAN.Text += TAMBAHAN[t];
									if (s == 2) 
									{
										string c = DESCT[0] + " (" + TYPET[0]+  ")";
										TAMBAHAN[t] = c;
										LBL_JAMINANTAMBAHAN.Text = TAMBAHAN[t];
						
										if (t == 1 )
										{
											TAMBAHAN[t] = " dan " + DESCT[1] + " (" + TYPET[1]+  ")";
											LBL_JAMINANTAMBAHAN.Text += TAMBAHAN[t];
						
										}
									}
						
								}
								else
								{
									TAMBAHAN[t] += DESCT[t] + " (" + TYPET[t]+  "), ";
									LBL_JAMINANTAMBAHAN.Text += TAMBAHAN[t];
								}
							}
							t++;
							
						}
					
					}

					n++;
					Tabel.Rows[n].Cells[0].Text = "";
					Tabel.Rows[n].Cells[1].Text = " - Jaminan Utama ";
					Tabel.Rows[n].Cells[2].Text = " : ";
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_JAMINANUTAMA);
				
					n++;
					Tabel.Rows[n].Cells[0].Text = "";
					Tabel.Rows[n].Cells[1].Text = " - Jaminan Tambahan ";
					Tabel.Rows[n].Cells[2].Text = " : ";
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_JAMINANTAMBAHAN);
					n++;
					Tabel.Rows[n].Cells[0].Text = "";
					Tabel.Rows[n].Cells[1].Text = "";
					Tabel.Rows[n].Cells[2].Text = "";
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_JAMINAN);

					n++;
					Tabel.Rows[n].Cells[0].Text = "j.";
					Tabel.Rows[n].Cells[1].Text = "Target penjualan ";
					Tabel.Rows[n].Cells[2].Text = " : ";
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_TARGET1);
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_TAHUNTARGET);
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_TARGET2);
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_ANGKATARGET);
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_TARGET3);
			
					n++;
					Tabel.Rows[n].Cells[0].Text = "k.";
					Tabel.Rows[n].Cells[1].Text = "Penarikan kredit ";
					Tabel.Rows[n].Cells[2].Text = " : ";
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_PENARIKAN);

					n++;
					Tabel.Rows[n].Cells[0].Text = "";
					Tabel.Rows[n].Cells[1].Text = "";
					Tabel.Rows[n].Cells[2].Text = "";
					Tabel.Rows[n].Cells[3].Controls.Add(new LiteralControl("<LI>"));
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_KMK1);
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_STOCK1);
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_KMK2);
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_PIUTANG);
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_KMK3);

					n++;
					Tabel.Rows[n].Cells[0].Text = "";
					Tabel.Rows[n].Cells[1].Text = "";
					Tabel.Rows[n].Cells[2].Text = "";
					Tabel.Rows[n].Cells[3].Controls.Add(new LiteralControl("<LI>"));
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_KMK4);
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_KMK1);
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_KMK5);

					n++;
					Tabel.Rows[11].Cells[0].Text = "";
					Tabel.Rows[11].Cells[1].Text = "";
					Tabel.Rows[11].Cells[2].Text = "";
					Tabel.Rows[11].Cells[3].Controls.Add(LBL_KI1);
					Tabel.Rows[11].Cells[3].Controls.Add(LBL_KM1);
				
					Tabel.Rows[11].Cells[3].Controls.Add(LBL_KI2);
					Tabel.Rows[11].Cells[3].Controls.Add(LBL_SF1);
					Tabel.Rows[11].Cells[3].Controls.Add(LBL_KI3);

					n++;
					Tabel.Rows[n].Cells[0].Text = "l.";
					Tabel.Rows[n].Cells[1].Text = "Asuransi";
					Tabel.Rows[n].Cells[2].Text = " : ";
					Tabel.Rows[n].Cells[3].Text = "";

					Table Tabelk = new Table();
					Tabelk.ID = "Tabelk"+u+i;
					Tabelk.Rows.Add(new TableRow());
					Tabelk.Rows[0].Cells.Add (new TableCell());
					Tabelk.Rows[0].Cells.Add (new TableCell());
					Tabelk.Rows[0].Cells[0].Text = "  ";
					Tabelk.Rows[0].Cells[1].Controls.Add(LBL_ASURANSI);
					Tabelk.Rows[0].Cells[1].Font.Size = FontUnit.XSmall;
					Tabelk.Rows[0].Cells[1].VerticalAlign = VerticalAlign.Top;
									
					//end  pembuatan tabel
					
					PH1.Controls.Add(Tabelj);
					PH1.Controls.Add(Tabel);
					PH1.Controls.Add(Tabelk);
			
				}
											
			}
		

		}

		private void ViewSomeData(string regno)//tampilan untuk syaratnya dalam tabel
		{
							
			conn.QueryString = "select SYARAT_DOCTYPEDESC from VW_SYARAT_SPPK " +
				"WHERE AP_REGNO ='" + regno + "' AND "  + " doctypeid='4' ";
			conn.ExecuteQuery();
			
			int jml_sy4 = conn.GetRowCount();
			DataTable dt4 = conn.GetDataTable();
			string[] sy4 = new string[jml_sy4];
			int i = 0;
			foreach(DataRow dr4 in dt4.Rows) 
			{
				sy4[i] = dr4["SYARAT_DOCTYPEDESC"].ToString();
				TBL_SYARAT_PK.Rows.Add(new TableRow());
				TBL_SYARAT_PK.Rows[i].Cells.Add(new TableCell());
				TBL_SYARAT_PK.Rows[i].Cells.Add(new TableCell());
			
				//TBL_SYARAT_PK.Rows[i].Cells[0].Text = "o";
				TBL_SYARAT_PK.Rows[i].Cells[0].Controls.Add(new LiteralControl("<LI>"));
				TBL_SYARAT_PK.Rows[i].Cells[0].VerticalAlign = VerticalAlign.Top;
				TBL_SYARAT_PK.Rows[i].Cells[1].Text = sy4[i];
				TBL_SYARAT_PK.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
				i++;
			}

			conn.QueryString = "select SYARAT_DOCTYPEDESC from VW_SYARAT_SPPK " +
				"WHERE AP_REGNO ='" + regno + "' and doctypeid='5'";
			conn.ExecuteQuery();
			int jml_sy5 = conn.GetRowCount();
			DataTable dt5 = conn.GetDataTable();
			string[] sy5 = new string[jml_sy5];
			int j = 0;
			foreach(DataRow dr5 in dt5.Rows) 
			{
				sy5[j] = dr5["SYARAT_DOCTYPEDESC"].ToString();
				TBL_SYARAT_PKR.Rows.Add(new TableRow());
				TBL_SYARAT_PKR.Rows[j].Cells.Add(new TableCell());
				TBL_SYARAT_PKR.Rows[j].Cells.Add(new TableCell());
			
				//TBL_SYARAT_PKR.Rows[j].Cells[0].Text = "o";
				TBL_SYARAT_PKR.Rows[j].Cells[0].Controls.Add(new LiteralControl("<LI>"));
				TBL_SYARAT_PKR.Rows[j].Cells[0].VerticalAlign = VerticalAlign.Top;
				TBL_SYARAT_PKR.Rows[j].Cells[1].Text = sy5[j];
				TBL_SYARAT_PKR.Rows[j].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
				j++;
			}

			conn.QueryString = "select SYARAT_DOCTYPEDESC from VW_SYARAT_SPPK " +
				"WHERE AP_REGNO ='" + regno + "' and doctypeid='6'";
			conn.ExecuteQuery();
		
			int jml_sy6 = conn.GetRowCount();
			DataTable dt6 = conn.GetDataTable();
			string[] sy6 = new string[jml_sy6];
			int k = 0;
			foreach(DataRow dr6 in dt6.Rows) 
			{
				sy6[k] = dr6["SYARAT_DOCTYPEDESC"].ToString();
				TBL_SYARAT_LAIN.Rows.Add(new TableRow());
				TBL_SYARAT_LAIN.Rows[k].Cells.Add(new TableCell());
				TBL_SYARAT_LAIN.Rows[k].Cells.Add(new TableCell());
			
				//TBL_SYARAT_LAIN.Rows[k].Cells[0].Text = "o";
				TBL_SYARAT_LAIN.Rows[k].Cells[0].Controls.Add(new LiteralControl("<LI>"));
				TBL_SYARAT_LAIN.Rows[k].Cells[0].VerticalAlign = VerticalAlign.Top;
				TBL_SYARAT_LAIN.Rows[k].Cells[1].Text = sy6[k];
				TBL_SYARAT_LAIN.Rows[k].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
				k++;
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
		
		
		private void InitializeComponent()
		{    

		}
		#endregion

	}
}