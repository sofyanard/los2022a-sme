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
	public partial class SPPKEntry : System.Web.UI.Page
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

			//regno	= "19042004001000001";//"20062004001000026";//"19042004001000001";//"2706200400600000010";

			ViewData(regno);
			ViewSomeData(regno);
			
			if (!IsPostBack) 
			{
				TXT_BRANCH.Text = (string) Session["BranchName"];
				TXT_MANAGER.Text = (string) Session["FullName"];
				TXT_BRANCHMANAGER.Text = (string) Session["GroupName"];

				setLetterNo();
				ViewIdentity(regno);
				try
				{
							conn.QueryString = "select su_fullname , branch_name, jb_desc "+
								"from scuser su left join rfbranch b on b.branch_code = su.su_branch "+
								"left join rfjabatan j on j.jb_code = su.jb_code "+
								"where userid = '" + Session["USERID"].ToString().Trim() + "' ";
							conn.ExecuteQuery();
							TXT_MANAGER.Text = conn.GetFieldValue(0,0).Trim();
							TXT_BRANCH.Text = conn.GetFieldValue(0,1).Trim();
							TXT_BRANCHMANAGER.Text = conn.GetFieldValue(0,2).Trim();
				} 
				catch {}
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

		private void setLetterNo() 
		{
			/* *******************************************************
				 * Menentukan NOMOR SURAT untuk SPPK
				 * ********************************************************/
			string no_surat;
			string USERID		= (string) Session["UserID"];

			conn.QueryString = "select isnull(LTR_NO,0) LTR_NO from RFLETTERNUMBER where LTR_USERID = '"+USERID+"' and LTR_LETTERTYPE = 'SPPK'";
			conn.ExecuteQuery();
			int nomor;
			try 
			{
				nomor = Convert.ToInt16(conn.GetFieldValue("LTR_NO")) + 1;
			} 
			catch 
			{
				nomor = 1;
			}
			string Now_Year = System.DateTime.Now.Year.ToString();
				
			no_surat = TXT_BRANCH.Text + "/" + nomor + "/" + Now_Year;
			TXT_NO.Text = no_surat;
			/*----------------------------------------------------------*/
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
					TextBox TXT_REVOLVING		= new TextBox();
					TextBox TXT_CP_TENOR		= new TextBox();

					//LBL_REVOLVING.ID = "LBL_REVOLVING"+u+i;
					//LBL_REVOLVING.Text = revolvingtemp;
					TXT_REVOLVING.ID = "TXT_REVOLVING"+u+i;
					TXT_REVOLVING.Text = revolvingtemp;
					TXT_REVOLVING.MaxLength = 100;

					//--- TENOR
					int CP_TENOR = 0;
					try 
					{
						CP_TENOR = Convert.ToInt16(conn.GetFieldValue("CP_TENOR"));
					} 
					catch {}
					TXT_CP_TENOR.ID = "TXT_CP_TENOR"+u+i;
					TXT_CP_TENOR.Text = CP_TENOR + "  " + Data_Tenor + " .... s/d .....";
					TXT_CP_TENOR.Width = 400;
					TXT_CP_TENOR.MaxLength = 100;
					//LBL_CP_TENOR.ID = "LBL_CP_TENOR"+u+i;
					//LBL_CP_TENOR.Text = CP_TENOR + "  " +Data_Tenor + "  ";

					Label LBL_SD = new Label();
					LBL_SD.ID = "LBL_SD"+u+i;
					LBL_SD.Text = " s/d ";
								
					TextBox TXT_TGL1 = new TextBox(), TXT_THN1 = new TextBox();
					TextBox TXT_TGL2 = new TextBox(), TXT_THN2 = new TextBox();
					TXT_TGL1.ID = "TXT_TGL1"+u+i;
					TXT_TGL1.Width = 30;
					TXT_TGL1.MaxLength = 2;
					TXT_TGL1.ForeColor = Color.Black;
					TXT_TGL1.Attributes.Add("onkeypress","return numbersonly();");					
					TXT_THN1.ID = "TXT_THN1"+u+i;
					TXT_THN1.Width = 60;
					TXT_THN1.ForeColor = Color.Black;
					TXT_THN1.MaxLength = 4;
					TXT_THN1.Attributes.Add("onkeypress","return numbersonly();");
					TXT_TGL2.ID = "TXT_TGL2"+u+i;
					TXT_TGL2.Width = 30;
					TXT_TGL2.ForeColor = Color.Black;
					TXT_TGL2.MaxLength = 2;
					TXT_TGL2.Attributes.Add("onkeypress","return numbersonly();");
					TXT_THN2.ID = "TXT_THN2"+u+i;
					TXT_THN2.Width = 60;
					TXT_THN2.ForeColor = Color.Black;
					TXT_THN2.MaxLength = 4;
					TXT_THN2.Attributes.Add("onkeypress","return numbersonly();");
				
					DropDownList DDL_BLN1 = new DropDownList(), DDL_BLN2 = new DropDownList();
					DDL_BLN1.ID = "DDL_BLN1"+u+i;
					DDL_BLN2.ID = "DDL_BLN2"+u+i;
				
					for (int r = 1; r <= 12; r++)
					{
						DDL_BLN1.Items.Add(new ListItem(DateAndTime.MonthName(r, false), r.ToString()));
						DDL_BLN2.Items.Add(new ListItem(DateAndTime.MonthName(r, false), r.ToString()));
					}
				
					//--- SUKU BUNGA / INTEREST
					TextBox TXT_SUKUBUNGA = new TextBox(), TXT_PROVISI = new TextBox();
					TextBox TXT_SUKUBUNGA_DUEDATE = new TextBox();
					TXT_SUKUBUNGA.ID = "TXT_SUKUBUNGA"+u+i;
					TXT_SUKUBUNGA.Width = 30;
					TXT_SUKUBUNGA.ForeColor = Color.Black;
					TXT_SUKUBUNGA.MaxLength = 15;
					TXT_SUKUBUNGA.Attributes.Add("onkeypress","return numbersonly();");
					TXT_SUKUBUNGA_DUEDATE.ID = "TXT_SUKUBUNGA_DUEDATE"+u+i;
					TXT_SUKUBUNGA_DUEDATE.Width = 30;
					TXT_SUKUBUNGA_DUEDATE.ForeColor = Color.Black;
					TXT_SUKUBUNGA_DUEDATE.MaxLength = 2;
					TXT_SUKUBUNGA_DUEDATE.Text = "25";	//---by default 25

					TXT_PROVISI.ID = "TXT_PROVISI"+u+i;
					TXT_PROVISI.Width = 30;
					TXT_PROVISI.ForeColor = Color.Black;
					TXT_PROVISI.MaxLength = 15;
					TXT_PROVISI.Attributes.Add("onkeypress","return numbersonly();");

					TextBox TXT_PROVISI_DESC = new TextBox();
					TXT_PROVISI_DESC.ID = "TXT_PROVISI_DESC"+u+i;
					TXT_PROVISI_DESC.Width = 400;
					TXT_PROVISI_DESC.ForeColor = Color.Black;
					TXT_PROVISI_DESC.TextMode = TextBoxMode.MultiLine;
					TXT_PROVISI_DESC.Text = " % p.a, dibayar pada saat penandatanganan Akta Perjanjian Kredit ";
																			
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

					
					TextBox TXT_TAHUNTARGET = new TextBox();
					TXT_TAHUNTARGET.ID = "TXT_TAHUNTARGET"+u+i;
					TXT_TAHUNTARGET.Width = 60;
					TXT_TAHUNTARGET.ForeColor = Color.Black;
					TXT_TAHUNTARGET.MaxLength = 4;

					TextBox TXT_SUKUBUNGA_DESC = new TextBox();		
					TXT_SUKUBUNGA_DESC.ID = "TXT_SUKUBUNGA_DESC"+u+i;
					TXT_SUKUBUNGA_DESC.TextMode = TextBoxMode.MultiLine ;
					TXT_SUKUBUNGA_DESC.Width = 400;
					TXT_SUKUBUNGA_DESC.Text	= " % p.a, dibayar efektif dan dibayar pada tanggal setiap bulan dan dapat berubah sewaktu-waktu sesuai ketentuan yang berlaku di Bank Mandiri, perubahan tersebut mengikat Debitur maupun Penjamin cukup dengan cara pemberitahuan tertulis kepada Debitur.";
			
					TextBox TXT_ANGKATARGET = new TextBox(),TXT_STOCK = new TextBox();
					TXT_ANGKATARGET.ID = "TXT_ANGKATARGET"+u+i;
					TXT_ANGKATARGET.ForeColor = Color.Black;
					TXT_ANGKATARGET.MaxLength = 15;
					TXT_STOCK.ID = "TXT_STOCK"+u+i;
					TXT_STOCK.MaxLength = 15;
				
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

					TextBox TXT_STOCK1 = new TextBox(), TXT_PIUTANG = new TextBox();
					TXT_STOCK1.ID = "TXT_STOCK1"+u+i;
					TXT_STOCK1.Width = 30;
					TXT_STOCK1.ForeColor = Color.Black;
					TXT_STOCK1.MaxLength = 15;
					TXT_PIUTANG.ID = "TXT_PIUTANG"+u+i;
					TXT_PIUTANG.Width = 30;
					TXT_PIUTANG.ForeColor = Color.Black;
					TXT_PIUTANG.MaxLength = 15;
								
					TextBox TXT_KMK1 = new TextBox(),TXT_KM1 = new TextBox(),TXT_SF1 = new TextBox();
					TXT_KMK1.ID = "TXT_KMK1"+u+i;
					TXT_KMK1.Width = 30;
					TXT_KMK1.ForeColor = Color.Black;
					TXT_KMK1.MaxLength = 100;
					TXT_KM1.ID = "TXT_KM1"+u+i;
					TXT_KM1.Width = 30;
					TXT_KM1.ForeColor = Color.Black;
					TXT_KM1.MaxLength = 100;
					TXT_SF1.ID = "TXT_SF1"+u+i;
					TXT_SF1.Width = 30;
					TXT_SF1.ForeColor = Color.Black;
					TXT_SF1.MaxLength = 100;

					Label LBL_KI1 = new Label(),LBL_KI2 = new Label(),LBL_KI3 = new Label();
					LBL_KI1.ID = "LBL_KI1"+u+i;
					LBL_KI1.Text = "* KI sesuai kebutuhan progres proyek dengan komposisi kredit maksimal ";
					LBL_KI2.ID = "LBL_KI2"+u+i;
					LBL_KI2.Text = " % dan Self Finanding (SF) ";
					LBL_KI3.ID = "LBL_KI3"+u+i;
					LBL_KI3.Text = " % ";

			
					//Response.Write("TXT_TGL1 = "+ TXT_TGL1.ID +"<br>");
											
					
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
					TextBox TXT_CP_LIMIT	= new TextBox();
					TXT_CP_LIMIT.ID = "TXT_CP_LIMIT"+u+i;
					TXT_CP_LIMIT.Text = LBL_CURRENCY.Text + " " + CP_LIMIT + " ";
					TXT_CP_LIMIT.MaxLength = 15;
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
						TXT_CP_LIMIT.Text = LBL_CURRENCY.Text + " " + CP_LIMIT + " ";
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

							TXT_SUKUBUNGA.Text = (ad_varcode == "+" ? rate+ad_variance : (ad_varcode == "-" ? rate-ad_variance : rate)) + "";
						}
						else 
						{
							// Fixed
							TXT_SUKUBUNGA.Text = conn.GetFieldValue("AD_INTEREST");
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
						TXT_CP_LIMIT.Text = LBL_CURRENCY.Text + " " + CP_LIMIT + " ";
						//LBL_CP_LIMIT.Text = LBL_CURRENCY.Text + " " + CP_LIMIT + " ";
						//LBL_NOMINAL_LIMIT.Text = SeleksiKonversi(conn.GetFieldValue("BC_LOANAMOUNT"));
					}
					/*******************************************************************************************/

					TextBox TXT_CP_INSTALLMENT	= new TextBox();
					TXT_CP_INSTALLMENT.ID = "TXT_CP_INSTALLMENT"+u+i;
					TXT_CP_INSTALLMENT.MaxLength = 15;
					TXT_CP_INSTALLMENT.Text = LBL_CURRENCY.Text + " " + tools.MoneyFormat(cp_installment);


					Tabel.Rows[n].Cells[0].Text = "a.";
					Tabel.Rows[n].Cells[1].Text = "Limit Kredit ";
					Tabel.Rows[n].Cells[2].Text = " : ";
					if (CP_LIMIT != "" && Convert.ToDouble(CP_LIMIT) > 0) 
					{
						Tabel.Rows[n].Cells[3].Controls.Add(TXT_CP_LIMIT);
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
						TXT_CP_LIMIT.Text = "-";
						Tabel.Rows[n].Cells[3].Controls.Add(TXT_CP_LIMIT);
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
					Tabel.Rows[n].Cells[3].Controls.Add(TXT_REVOLVING);

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
						Tabel.Rows[n].Cells[3].Controls.Add(TXT_CP_TENOR);
						/*
						Tabel.Rows[n].Cells[3].Controls.Add(LBL_CP_TENOR);
						Tabel.Rows[n].Cells[3].Controls.Add(TXT_TGL1);
						Tabel.Rows[n].Cells[3].Controls.Add (DDL_BLN1);
						Tabel.Rows[n].Cells[3].Controls.Add (TXT_THN1);
						Tabel.Rows[n].Cells[3].Controls.Add(LBL_SD);
						Tabel.Rows[n].Cells[3].Controls.Add (TXT_TGL2);
						Tabel.Rows[n].Cells[3].Controls.Add (DDL_BLN2);
						Tabel.Rows[n].Cells[3].Controls.Add (TXT_THN2);
						*/
					}
					else 
					{
						//Tabel.Rows[n].Cells[3].Text = "-";
						TXT_CP_TENOR.Text = "-";
						Tabel.Rows[n].Cells[3].Controls.Add(TXT_CP_TENOR);
					}
	
					n++;
					Tabel.Rows[n].Cells[0].Text = "f.";
					Tabel.Rows[n].Cells[1].Text = "Angsuran ";
					Tabel.Rows[n].Cells[2].Text = " : ";					
					if (cp_installment != "" && Convert.ToDouble(cp_installment) > 0) 
					{
						Tabel.Rows[n].Cells[3].Controls.Add(TXT_CP_INSTALLMENT);
					}
					else 
					{
						TXT_CP_INSTALLMENT.Text = "-";
						Tabel.Rows[n].Cells[3].Controls.Add(TXT_CP_INSTALLMENT);
					}

					n++;
					Tabel.Rows[n].Cells[0].Text = "g.";
					Tabel.Rows[n].Cells[1].Text = "Suku Bunga ";
					Tabel.Rows[n].Cells[2].Text = " : ";
					Tabel.Rows[n].Cells[3].Controls.Add(TXT_SUKUBUNGA);
					Tabel.Rows[n].Cells[3].Controls.Add(TXT_SUKUBUNGA_DESC);
					Tabel.Rows[n].Cells[3].Controls.Add(TXT_SUKUBUNGA_DUEDATE);
//					Tabel.Rows[n].Cells[3].Controls.Add(TXT_SUKUBUNGA_DESC2);

					n++;
					Tabel.Rows[n].Cells[0].Text = "h.";
					Tabel.Rows[n].Cells[1].Text = " Provisi/Commitment Fee ";
					Tabel.Rows[n].Cells[2].Text = " : ";
					Tabel.Rows[n].Cells[3].Controls.Add(TXT_PROVISI);
					Tabel.Rows[n].Cells[3].Controls.Add(TXT_PROVISI_DESC);

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
					Tabel.Rows[n].Cells[3].Controls.Add(TXT_TAHUNTARGET);
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_TARGET2);
					Tabel.Rows[n].Cells[3].Controls.Add(TXT_ANGKATARGET);
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
					Tabel.Rows[n].Cells[3].Controls.Add(TXT_STOCK1);
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_KMK2);
					Tabel.Rows[n].Cells[3].Controls.Add(TXT_PIUTANG);
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_KMK3);

					n++;
					Tabel.Rows[n].Cells[0].Text = "";
					Tabel.Rows[n].Cells[1].Text = "";
					Tabel.Rows[n].Cells[2].Text = "";
					Tabel.Rows[n].Cells[3].Controls.Add(new LiteralControl("<LI>"));
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_KMK4);
					Tabel.Rows[n].Cells[3].Controls.Add(TXT_KMK1);
					Tabel.Rows[n].Cells[3].Controls.Add(LBL_KMK5);

					n++;
					Tabel.Rows[11].Cells[0].Text = "";
					Tabel.Rows[11].Cells[1].Text = "";
					Tabel.Rows[11].Cells[2].Text = "";
					Tabel.Rows[11].Cells[3].Controls.Add(LBL_KI1);
					Tabel.Rows[11].Cells[3].Controls.Add(TXT_KM1);
				
					Tabel.Rows[11].Cells[3].Controls.Add(LBL_KI2);
					Tabel.Rows[11].Cells[3].Controls.Add(TXT_SF1);
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

		private void ViewIdentity(string regno)
		{
			conn.QueryString = "SELECT WAKTU = DATENAME(DAY, getDATE())+ ' '+" +
				"DATENAME(MONTH, getDATE()) +' '+ " +
				"DATENAME(YEAR, getDATE())" ;
			conn.ExecuteQuery();
			TXT_CURTIME.Text = conn.GetFieldValue("WAKTU");

			conn.QueryString = "SELECT DISTINCT NAMA, ALAMAT1, ALAMAT2, ALAMAT3, KOTA, ZIPDESC, ZIPCODE, AP_SIGNDATE " +
				"FROM VW_SPPK_VIEW " +
				"WHERE AP_REGNO ='" + regno + "' " ;
			conn.ExecuteQuery();

			string AP_SIGNDATETEMP; 
			AP_SIGNDATETEMP =	conn.GetFieldValue("AP_SIGNDATE");
			TXT_AP_DATE.Text	= tools.FormatDate(AP_SIGNDATETEMP);

			TXT_CUST_NAME.Text	= conn.GetFieldValue("NAMA");
			//TXT_ADDR.Text		= conn.GetFieldValue("ALAMAT");
			TXT_ADDR.Text		= conn.GetFieldValue("ALAMAT1");
			TXT_ADDR2.Text		= conn.GetFieldValue("ALAMAT2");
			TXT_ADDR3.Text		= conn.GetFieldValue("ALAMAT3");
			TXT_CITY.Text		= conn.GetFieldValue("ZIPDESC") + " " + conn.GetFieldValue("KOTA");
			TXT_POSTCODE.Text	= conn.GetFieldValue("ZIPCODE");
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

//		private void PrintOld()
//        {
//			PH1.Visible = true;
//			//string regno = Request.QueryString["regno"];
//			//string regno	= "19042004001000001";
//			conn.QueryString = "SELECT  DISTINCT PRODUCTID,PRODUCTDESC FROM VW_SPPK_VIEW2" +
//				" WHERE AP_REGNO ='" + regno + "'";
//			conn.ExecuteQuery();
//			int jml_product = conn.GetRowCount();
//
//			string[] PRODUCTDESC = new string[jml_product];
//			int p = 0;
//			DataTable dt = conn.GetDataTable();
//			foreach(DataRow dr in dt.Rows) 
//			{
//				PRODUCTDESC[p] = dr["PRODUCTDESC"].ToString();
//				p++;
//			}
//					
//			
//			for (int k = 0 ; k < jml_product ; k++)
//			{
//				/*
//				//--tamabahan nur untuk save SPPK------------
//				conn.QueryString = "exec SPPK_SAVE '"+regno+"', '"+TXT_NO.Text+"','"+Session["UserID"]+"'";
//				conn.ExecuteNonQuery();
//				//-------------------------------------------
//				*/
//
//				conn.QueryString = "SELECT distinct APPTYPEDESC " +
//					" 	FROM VW_SPPK_VIEW2	"+
//					" WHERE AP_REGNO ='" + regno + "' AND PRODUCTDESC= '" +PRODUCTDESC[k]+ "' ";
//				conn.ExecuteQuery();
//			
//				int jml_tipeproduct = conn.GetRowCount();
//				
//				TextBox [,] TXT_CP_LIMIT = new TextBox[jml_product, jml_tipeproduct];
//				TextBox [,] TXT_CP_TENOR = new TextBox[jml_product, jml_tipeproduct];
//				TextBox [,] TXT_REVOLVING = new TextBox[jml_product, jml_tipeproduct];
//				TextBox [,] TXT_TGL1 = new TextBox[jml_product,jml_tipeproduct];
//				TextBox [,] TXT_THN1 = new TextBox[jml_product,jml_tipeproduct];
//				TextBox [,] TXT_TGL2 = new TextBox[jml_product, jml_tipeproduct];
//				TextBox [,] TXT_THN2 = new TextBox[jml_product, jml_tipeproduct];
//				TextBox [,] DDL_BLN1 = new TextBox[jml_product, jml_tipeproduct];
//				TextBox [,] DDL_BLN2 = new TextBox[jml_product, jml_tipeproduct];
//				DropDownList [,] DDL_BLNA = new DropDownList[jml_product, jml_tipeproduct];
//				DropDownList [,] DDL_BLNB = new DropDownList[jml_product, jml_tipeproduct];
//				TextBox [,] TXT_CP_INSTALLMENT = new TextBox[jml_product, jml_tipeproduct];
//				TextBox [,] TXT_SUKUBUNGA = new TextBox[jml_product, jml_tipeproduct];
//				TextBox [,] TXT_SUKUBUNGA_DUEDATE = new TextBox[jml_product, jml_tipeproduct];
//				TextBox [,] TXT_PROVISI = new TextBox[jml_product, jml_tipeproduct];
//				string [,] waktu1 = new string[jml_product, jml_tipeproduct];
//				string [,] waktu2 = new string[jml_product, jml_tipeproduct];
//				TextBox [,] TXT_TAHUNTARGET = new TextBox[jml_product, jml_tipeproduct];
//				TextBox [,] TXT_ANGKATARGET = new TextBox[jml_product, jml_tipeproduct];
//				TextBox [,] TXT_STOCK1 = new TextBox[jml_product, jml_tipeproduct];
//				TextBox [,] TXT_PIUTANG = new TextBox[jml_product, jml_tipeproduct];
//				TextBox [,] TXT_KMK1 = new TextBox[jml_product, jml_tipeproduct];
//				TextBox [,] TXT_KM1 = new TextBox[jml_product, jml_tipeproduct];
//				TextBox [,] TXT_SF1 = new TextBox[jml_product, jml_tipeproduct];
//				Label [,] LBL_JAMINANUTAMA = new Label[jml_product, jml_tipeproduct];
//				Label [,] LBL_JAMINANTAMBAHAN = new Label[jml_product, jml_tipeproduct];
//
//				for (int i = 0 ; i < jml_tipeproduct ; i++)
//				{
//					Table Tabel = (Table) this.PH1.FindControl("Tabel" + k.ToString() + i.ToString());
//					TXT_CP_LIMIT[k,i] = (TextBox) Tabel.Rows[3].Cells[3].FindControl("TXT_CP_LIMIT"+k+i);
//					TXT_CP_TENOR[k,i] = (TextBox) Tabel.Rows[3].Cells[3].FindControl("TXT_CP_TENOR"+k+i);
//					TXT_REVOLVING[k,i] = (TextBox) Tabel.Rows[3].Cells[3].FindControl("TXT_REVOLVING"+k+i);
//					TXT_TGL1[k,i] = (TextBox) Tabel.Rows[3].Cells[3].FindControl("TXT_TGL1"+k+i);
//					TXT_THN1[k,i] = (TextBox) Tabel.Rows[3].Cells[3].FindControl("TXT_THN1"+k+i);
//					TXT_TGL2[k,i] = (TextBox) Tabel.Rows[3].Cells[3].FindControl("TXT_TGL2"+k+i);
//					TXT_THN2[k,i] = (TextBox) Tabel.Rows[3].Cells[3].FindControl("TXT_THN2"+k+i);
//					DDL_BLNA[k,i] = (DropDownList) Tabel.Rows[3].Cells[3].FindControl("DDL_BLN1"+k+i);
//					DDL_BLNB[k,i] = (DropDownList) Tabel.Rows[3].Cells[3].FindControl("DDL_BLN2"+k+i);
//				
//					try 
//					{
//						waktu1[k,i]= TXT_TGL1[k,i].Text + " " + DDL_BLNA[k,i].SelectedItem.Text + " " + TXT_THN1[k,i].Text;
//						waktu2[k,i]= TXT_TGL2[k,i].Text + " " + DDL_BLNB[k,i].SelectedItem.Text + " " + TXT_THN2[k,i].Text;
//					}
//					catch {
//						waktu1[k,i] = "";
//						waktu2[k,i] = "";
//					}
//				
//					TXT_CP_INSTALLMENT[k,i] = (TextBox) Tabel.Rows[5].Cells[3].FindControl("TXT_CP_INSTALLMENT"+k+i);
//					TXT_SUKUBUNGA[k,i] = (TextBox) Tabel.Rows[5].Cells[3].FindControl("TXT_SUKUBUNGA"+k+i);
//					TXT_SUKUBUNGA_DUEDATE[k,i] = (TextBox) Tabel.Rows[5].Cells[3].FindControl("TXT_SUKUBUNGA_DUEDATE"+k+i);
//					TXT_PROVISI[k,i] = (TextBox) Tabel.Rows[6].Cells[3].FindControl("TXT_PROVISI"+k+i);		
//				
//					TXT_TAHUNTARGET[k,i] = (TextBox) Tabel.Rows[7].Cells[3].FindControl("TXT_TAHUNTARGET"+k+i);
//					TXT_ANGKATARGET[k,i] = (TextBox) Tabel.Rows[7].Cells[3].FindControl("TXT_ANGKATARGET"+k+i);	
//
//					TXT_STOCK1[k,i] = (TextBox) Tabel.Rows[9].Cells[3].FindControl("TXT_STOCK1"+k+i);
//					TXT_PIUTANG[k,i] = (TextBox) Tabel.Rows[9].Cells[3].FindControl("TXT_PIUTANG"+k+i);
//					TXT_KMK1[k,i] = (TextBox) Tabel.Rows[10].Cells[3].FindControl("TXT_KMK1"+k+i);
//					TXT_KM1[k,i] = (TextBox) Tabel.Rows[11].Cells[3].FindControl("TXT_KM1"+k+i);
//
//					TXT_SF1[k,i] = (TextBox) Tabel.Rows[11].Cells[3].FindControl("TXT_SF1"+k+i);
//									
//					Label1.Text += "&TXT_CP_LIMIT" + k.ToString() + i.ToString() + "=" + TXT_CP_LIMIT[k,i].Text + 
//						"&TXT_CP_TENOR" + k.ToString()+i.ToString() + "=" + TXT_CP_TENOR[k,i].Text +
//						"&TXT_REVOLVING" + k.ToString() + i.ToString() + "=" + TXT_REVOLVING[k,i].Text +
//						"&WAKTU1" + k.ToString()+i.ToString() + "= " + waktu1[k,i] + 
//						"&WAKTU2" + k.ToString()+i.ToString() + "= " + waktu2[k,i] +
//						"&TXT_CP_INSTALLMENT" + k.ToString() + i.ToString() + "=" + TXT_CP_INSTALLMENT[k,i].Text +
//						"&SUKUBUNGA" + k.ToString()+i.ToString() + "= " + TXT_SUKUBUNGA[k,i].Text + 
//						"&TXT_SUKUBUNGA_DUEDATE" + k.ToString() + i.ToString() + "= " + TXT_SUKUBUNGA_DUEDATE[k,i].Text +
//						"&TXT_PROVISI" + k.ToString()+i.ToString() + "= " + TXT_PROVISI[k,i].Text + 
//						"&TXT_TAHUNTARGET" + k.ToString() + i.ToString() +  "= " + TXT_TAHUNTARGET[k,i].Text + 
//						"&TXT_ANGKATARGET" + k.ToString() + i.ToString() +  "= " + TXT_ANGKATARGET[k,i].Text + 
//						"&TXT_STOCK1" + k.ToString()+i.ToString() + "= " + TXT_STOCK1[k,i].Text +
//						"&TXT_PIUTANG" + k.ToString() + i.ToString() +  "= " + TXT_PIUTANG[k,i].Text +
//						"&TXT_KMK1" + k.ToString() + i.ToString() +  "= " + TXT_KMK1[k,i].Text +
//						"&TXT_KM1" + k.ToString() + i.ToString() +  "= " + TXT_KM1[k,i].Text +
//						"&TXT_SF1" + k.ToString() + i.ToString() +  "= " + TXT_SF1[k,i].Text ;
//				
//					}
//				}
//
//			/*
//			Response.Redirect("SPPKBPrint.aspx?TXT_NO=" + TXT_NO.Text + "&TXT_CURTIME=" + TXT_CURTIME.Text + "&TXT_LAMP=" + TXT_LAMP.Text + 
//				"&TXT_CUST_NAME=" + TXT_CUST_NAME.Text + "&TXT_ADDR=" + TXT_ADDR.Text+ "&TXT_CITY=" + TXT_CITY.Text + "&TXT_POSTCODE=" + TXT_POSTCODE.Text +
//				"&TXT_AP_DATE=" + TXT_AP_DATE.Text +"&TXT_BRANCH=" + TXT_BRANCH.Text + "&TXT_MANAGER=" + TXT_MANAGER.Text +
//				"&TXT_BRANCHMANAGER=" + TXT_BRANCHMANAGER.Text +"&TXT_CRM=" + TXT_CRM.Text + Label1.Text+ "&TXT_TEMBUSAN="+TXT_TEMBUSAN.Text+
//				"&regno=" + regno );
//			*/
//			//---------------------------------------------------------------
//			// Untuk mem-pass TEMBUSAN
//			//----------------------------------------------------------------
//			string lampir = TXT_TEMBUSAN.Text;
//			int idx = lampir.IndexOf("\r\n");
//
//			while (idx > 0) 
//			{
//				string temp = lampir.Substring(0,idx);
//				string temp2 = lampir.Substring(idx+2);
//
//				Label lbl = new Label();
//				lbl.Text = temp;				
//				TEMBUSAN = TEMBUSAN + "&TXT_TEMBUSAN" + count + "=" + lbl.Text;
//
////				//this.PH_LAMPIRAN.Controls.Add(lbl);
////				PH_TEMBUSAN.Controls.Add(new LiteralControl("<LI>" + lbl.Text));
////				PH_TEMBUSAN.Controls.Add(new LiteralControl("<BR>"));
//
//				idx = temp2.IndexOf("\r\n");
//				lampir = temp2;
//				count += 1;
//			}			
//			//----------------------------------------------------------------
//			
//
//			Response.Redirect("SPPKBPrint.aspx?TXT_NO=" + TXT_NO.Text + "&TXT_CURTIME=" + TXT_CURTIME.Text + "&TXT_LAMP=" + TXT_LAMP.Text + 
//				"&TXT_CUST_NAME=" + TXT_CUST_NAME.Text + 
//				"&TXT_ADDR=" + TXT_ADDR.Text+ 
//				"&TXT_ADDR2=" + TXT_ADDR2.Text+ 
//				"&TXT_ADDR3=" + TXT_ADDR3.Text+ 
//				"&TXT_CITY=" + TXT_CITY.Text + "&TXT_POSTCODE=" + TXT_POSTCODE.Text +
//				"&TXT_AP_DATE=" + TXT_AP_DATE.Text +"&TXT_BRANCH=" + TXT_BRANCH.Text + "&TXT_MANAGER=" + TXT_MANAGER.Text + Label1.Text +
//				"&TXT_BRANCHMANAGER=" + TXT_BRANCHMANAGER.Text + TEMBUSAN + "&JUMTEMBUSAN=" + (count-1) + 
//				"&TXT_MATERAI=" + TXT_MATERAI.Text +
//				"&regno=" + regno );
//
//		}
//			

		private string SeleksiKonversi(string StringUtama)
		{	string output = "";
			if (!(StringUtama==""))
			{
				int jstring = StringUtama.Length;
				char[] kar1 = new char[jstring];
				string[] StringUtamatemp = new string[jstring];
				for (int i = 0; i < jstring;i++)
				{
					kar1[i]=StringUtama[i];		
					//Label3.Text += kar1[i] + " " ;
				}
						
				for (int h = 0; h < jstring; h++)
				{
					if (!(kar1[h] == '.'))
					{
						adakoma = false;
						StringUtamaPLUS = StringUtama + ".00";
					}
					else
					{adakoma = true;}
				}
		
				if (adakoma == true)
				{output = konversi(StringUtama);	} 
				else
				{output = konversi(StringUtamaPLUS);}
				
			}return output;
		}

		private string konversi(string u)
		{
			akhir = koma = hasilnya = "";
			char[] sep3 = new char[]{'.'};
			string [] bilangan = new string[6];
			int n = 0;
			foreach (string ss in u.Split(sep3))
			{
				bilangan[n]= ss;
				n++;	
			}

			
			//belajar konversi angka mata uang ke huruf tapi tanpa koma
			string terbilang = bilangan[0], terbilang2 = "";
			for(int z = terbilang.Length - 1; z >= 0; z--)
			{
				terbilang2 += terbilang.Substring(z,1);
			}
			int terbilangLength = terbilang2.Length;
		
			string[] temp = new string[terbilangLength];
			char [] kar = new char[terbilangLength];
			string [] kitabilang = new string [terbilangLength];
			
			for (int j= 0 ; j < terbilangLength ;j++)
			{
				kar[j] = terbilang2[j];
				
			}
		
		
			for (int i = 0 ; i < terbilangLength; i++)
			{
			
				switch (kar[i])
				{
					
					case '1': kitabilang[i] = "satu";break;
					case '2': kitabilang[i] = "dua";break;
					case '3': kitabilang[i] = "tiga";break;
					case '4': kitabilang[i] = "empat";break;
					case '5': kitabilang[i] = "lima";break;
					case '6': kitabilang[i] = "enam";break;
					case '7': kitabilang[i] = "tujuh";break;
					case '8': kitabilang[i] = "delapan";break;
					case '9': kitabilang[i] = "sembilan";break;
					default : kitabilang[i] = ""; break;
																			
				}
				
				switch (i)
				{
					case 1 : 
						if (kitabilang[i] == "satu")
						{
							temp[i] = " sepuluh ";
						}
						else 
							if (kitabilang[i] == "")
						{
							temp[i] = "";
						}
						else 
							temp[i] = kitabilang[i].ToString() + " puluh ";break;
					case 2 : 
						if (kitabilang[i]== "satu")
						{
							temp[i] = " seratus ";
						}
						else
							if (kitabilang[i] == "")
						{
							temp[i] = "";
						}
						else 
							temp[i] = kitabilang[i].ToString() + " ratus ";break;
					case 3 : 
						temp[i] = kitabilang[i].ToString() + " ribu ";break;
					case 4 : 
						if (kitabilang[i]=="satu")
						{
							temp[i] = " sepuluh ";
						}
						else
							if (kitabilang[i] == "")
						{
							temp[i] = "";
						}
						else 
							temp[i] = kitabilang[i].ToString() + " puluh ";break;
					case 5 : 
						if (kitabilang[i]=="satu")
						{
							temp[i] = " seratus ";
						}
						else
							if ((kitabilang[i] == "")&& (kitabilang[i-1] == "")&&(kitabilang[i-2] == ""))
						{
							temp[i-2] = "";
						}
						else 
							temp[i] = kitabilang[i].ToString() + " ratus ";break;
					case 6 :
						temp[i] = kitabilang[i].ToString() + " juta ";break;
					case 7 : 
						if (kitabilang[i] == "")
						{
							temp[i] = "";
						}
						else 
							if (kitabilang[i]=="satu")
						{
							temp[i] = " sepuluh ";
						}
						else
							temp[i] = kitabilang[i].ToString() + " puluh ";break;
					case 8 :
						if ((kitabilang[i] == "")&& (kitabilang[i-1] == "")&&(kitabilang[i-2] == ""))
						{
							temp[i-2] = "";
						}
						else 
							if (kitabilang[i]=="satu")
						{
							temp[i] = " seratus ";
						}
						else
							temp[i] = kitabilang[i].ToString() + " ratus ";break;
					case 9 :
						if ((kitabilang[i] == "")&&(kitabilang[i+1] == "")&&(kitabilang[i+2] == ""))
						{
							temp[i] = "";
						}
						else 
							temp[i] = kitabilang[i].ToString() + " milyar ";break;
					case 10 : 
						if (kitabilang[i]=="satu")
						{
							temp[i] = " sepuluh ";
						}
						else
							if (kitabilang[i] == "")
						{
							temp[i] = "";
						}
						else 
							temp[i] = kitabilang[i].ToString() + " puluh ";break;
					case 11 :
						if (kitabilang[i]=="satu")
						{
							temp[i] = " seratus ";
						}
						else
							if ((kitabilang[i] == "")&& (kitabilang[i-1] == "")&&(kitabilang[i-2] == ""))
						{
							temp[i-2] = "";
						}
						else 
							temp[i] = kitabilang[i].ToString() + " ratus ";break;
					case 12 :
						if ((kitabilang[i] == "")&&(kitabilang[i+1] == "")&&(kitabilang[i+2] == ""))
						{
							temp[i] = "";
						}
						else 
							temp[i] = kitabilang[i].ToString() + " trilyun ";break;
					case 13 :
						if (kitabilang[i] == "")
						{
							temp[i] = "";
						}
						else 
							if (kitabilang[i]=="satu")
						{
							temp[i] = " sepuluh ";
						}
						else						
							temp[i] = kitabilang[i].ToString() + " puluh ";break;
					case 14 :
						if (kitabilang[i] == "")
						{
							temp[i] = "";
						}
						else 
							if (kitabilang[i]=="satu")
						{
							temp[i] = " seratus ";
						}
						else
							temp[i] = kitabilang[i].ToString() + " ratus ";break;
					
					default: temp[i] = kitabilang[i].ToString() + " ";break;
				}
				//Label1.Text +=temp[i];
			
				if ((i > 8) && (kitabilang[0]=="") && (kitabilang[1]=="") && (kitabilang[2]=="") && (kitabilang[3]=="")  && (kitabilang[4]=="")  && (kitabilang[5]=="") && (kitabilang[6]=="")  && (kitabilang[7]=="") && (kitabilang[8]=="") )
				{
					for (int p=0 ; p < 8; p++)
					{
						temp[p] = "";
					}
				}
			
			}//end for
					
			
			for (int m = 0 ; m < (terbilangLength-1); m++)
			{
			
				if (temp[m+1] == " sepuluh ")
				{
					switch (temp[m])
					{
						case "satu "	    : temp[m]= ""; temp[m+1]= " sebelas ";break;
						case "dua "		    : temp[m]= ""; temp[m+1]= " dua belas ";break;
						case "tiga "		: temp[m]= ""; temp[m+1]= " tiga belas ";break;
						case "empat "		: temp[m]= ""; temp[m+1]= " empat belas ";break;
						case "lima "		: temp[m]= ""; temp[m+1]= " lima belas ";break;
						case "enam "		: temp[m]= ""; temp[m+1]= " enam belas ";break;
						case "tujuh "		: temp[m]= ""; temp[m+1]= " tujuh belas ";break;
						case "delapan "		: temp[m]= ""; temp[m+1]= " delapan belas ";break;
						case "sembilan "	: temp[m]= ""; temp[m+1]= " sembilan belas ";break;
						case "satu ribu "	    : temp[m]= ""; temp[m+1]= " sebelas ribu";break;
						case "dua ribu "		: temp[m]= ""; temp[m+1]= " dua belas ribu";break;
						case "tiga ribu "		: temp[m]= ""; temp[m+1]= " tiga belas ribu";break;
						case "empat ribu "		: temp[m]= ""; temp[m+1]= " empat belas ribu";break;
						case "lima ribu "		: temp[m]= ""; temp[m+1]= " lima belas ribu";break;
						case "enam ribu "		: temp[m]= ""; temp[m+1]= " enam belas ribu";break;
						case "tujuh ribu "		: temp[m]= ""; temp[m+1]= " tujuh belas ribu";break;
						case "delapan ribu "	: temp[m]= ""; temp[m+1]= " delapan belas ribu";break;
						case "sembilan ribu "	: temp[m]= ""; temp[m+1]= " sembilan belas ribu";break;
						case "satu juta "	    : temp[m]= ""; temp[m+1]= " sebelas juta";break;
						case "dua juta "		: temp[m]= ""; temp[m+1]= " dua belas juta";break;
						case "tiga juta "		: temp[m]= ""; temp[m+1]= " tiga belas juta";break;
						case "empat juta "		: temp[m]= ""; temp[m+1]= " empat belas juta";break;
						case "lima juta "		: temp[m]= ""; temp[m+1]= " lima belas juta";break;
						case "enam juta "		: temp[m]= ""; temp[m+1]= " enam belas juta";break;
						case "tujuh juta "		: temp[m]= ""; temp[m+1]= " tujuh belas juta";break;
						case "delapan juta "	: temp[m]= ""; temp[m+1]= " delapan belas juta";break;
						case "sembilan juta "	: temp[m]= ""; temp[m+1]= " sembilan belas juta";break;
						case "satu milyar "	    : temp[m]= ""; temp[m+1]= " sebelas milyar";break;
						case "dua milyar "		: temp[m]= ""; temp[m+1]= " dua belas milyar";break;
						case "tiga milyar "		: temp[m]= ""; temp[m+1]= " tiga belas milyar";break;
						case "empat milyar "	: temp[m]= ""; temp[m+1]= " empat belas milyar";break;
						case "lima milyar "		: temp[m]= ""; temp[m+1]= " lima belas milyar";break;
						case "enam milyar "		: temp[m]= ""; temp[m+1]= " enam belas milyar";break;
						case "tujuh milyar "	: temp[m]= ""; temp[m+1]= " tujuh belas milyar";break;
						case "delapan milyar "	: temp[m]= ""; temp[m+1]= " delapan belas milyar";break;
						case "sembilan milyar "	: temp[m]= ""; temp[m+1]= " sembilan belas milyar";break;
						case "satu trilyun "	: temp[m]= ""; temp[m+1]= " sebelas trilyun";break;
						case "dua trilyun "		: temp[m]= ""; temp[m+1]= " dua belas trilyun";break;
						case "tiga trilyun "	: temp[m]= ""; temp[m+1]= " tiga belas trilyun";break;
						case "empat trilyun "	: temp[m]= ""; temp[m+1]= " empat belas trilyun";break;
						case "lima trilyun "	: temp[m]= ""; temp[m+1]= " lima belas trilyun";break;
						case "enam trilyun "	: temp[m]= ""; temp[m+1]= " enam belas trilyun";break;
						case "tujuh trilyun "	: temp[m]= ""; temp[m+1]= " tujuh belas trilyun";break;
						case "delapan trilyun "	: temp[m]= ""; temp[m+1]= " delapan belas trilyun";break;
						case "sembilan trilyun ": temp[m]= ""; temp[m+1]= " sembilan belas trilyun";break;
									
					}
				}
				else
				{
					temp[m] = temp[m];
					temp[m+1] = temp[m+1];
				}
				
			}//end for


			//koma2an
			string terbilangkoma = bilangan[1];
			int terbilangkomaLength = terbilangkoma.Length;
			char [] kom = new char[terbilangkomaLength];
			string [] bilangkoma = new string [terbilangkomaLength];
			
			for (int j= 0 ; j < terbilangkomaLength ;j++)
			{
				kom[j] = terbilangkoma[j];
			}
		
		
			for (int i = 0 ; i < terbilangkomaLength; i++)
			{
				switch (kom[i])
				{
					case '1': bilangkoma[i] = "satu";break;
					case '2': bilangkoma[i] = "dua";break;
					case '3': bilangkoma[i] = "tiga";break;
					case '4': bilangkoma[i] = "empat";break;
					case '5': bilangkoma[i] = "lima";break;
					case '6': bilangkoma[i] = "enam";break;
					case '7': bilangkoma[i] = "tujuh";break;
					case '8': bilangkoma[i] = "delapan";break;
					case '9': bilangkoma[i] = "sembilan";break;
					default : bilangkoma[i] = "nol"; break;
				}
				koma += bilangkoma[i] + " " ;
			}
			
			//Hasil akhirnya....

			for (int p = (terbilangLength-1) ; p >= 0; p-- )
			{akhir += temp[p] + " " ;}	

			if (akhir == "  ")
			{hasilnya = "nol";} 
			else
			{hasilnya  = akhir + " Rupiah";	}
			return hasilnya;
			
		}

		protected void BTN_PREVIEW_Click(object sender, System.EventArgs e)
		{
			PH1.Visible = true;
			//string regno = Request.QueryString["regno"];
			//string regno	= "19042004001000001";
			conn.QueryString = "SELECT  DISTINCT PRODUCTID,PRODUCTDESC FROM VW_SPPK_VIEW2" +
				" WHERE AP_REGNO ='" + regno + "'";
			conn.ExecuteQuery();
			int jml_product = conn.GetRowCount();

			string[] PRODUCTDESC = new string[jml_product];
			int p = 0;
			DataTable dt = conn.GetDataTable();
			foreach(DataRow dr in dt.Rows) 
			{
				PRODUCTDESC[p] = dr["PRODUCTDESC"].ToString();
				p++;
			}
					
			
			for (int k = 0 ; k < jml_product ; k++)
			{
				/*
				//--tamabahan nur untuk save SPPK------------
				conn.QueryString = "exec SPPK_SAVE '"+regno+"', '"+TXT_NO.Text+"','"+Session["UserID"]+"'";
				conn.ExecuteNonQuery();
				//-------------------------------------------
				*/

				conn.QueryString = "SELECT distinct APPTYPEDESC " +
					" 	FROM VW_SPPK_VIEW2	"+
					" WHERE AP_REGNO ='" + regno + "' AND PRODUCTDESC= '" +PRODUCTDESC[k]+ "' ";
				conn.ExecuteQuery();
			
				int jml_tipeproduct = conn.GetRowCount();
				
				TextBox [,] TXT_CP_LIMIT = new TextBox[jml_product, jml_tipeproduct];
				TextBox [,] TXT_CP_TENOR = new TextBox[jml_product, jml_tipeproduct];
				TextBox [,] TXT_REVOLVING = new TextBox[jml_product, jml_tipeproduct];
				TextBox [,] TXT_TGL1 = new TextBox[jml_product,jml_tipeproduct];
				TextBox [,] TXT_THN1 = new TextBox[jml_product,jml_tipeproduct];
				TextBox [,] TXT_TGL2 = new TextBox[jml_product, jml_tipeproduct];
				TextBox [,] TXT_THN2 = new TextBox[jml_product, jml_tipeproduct];
				TextBox [,] DDL_BLN1 = new TextBox[jml_product, jml_tipeproduct];
				TextBox [,] DDL_BLN2 = new TextBox[jml_product, jml_tipeproduct];
				DropDownList [,] DDL_BLNA = new DropDownList[jml_product, jml_tipeproduct];
				DropDownList [,] DDL_BLNB = new DropDownList[jml_product, jml_tipeproduct];
				TextBox [,] TXT_CP_INSTALLMENT = new TextBox[jml_product, jml_tipeproduct];
				TextBox [,] TXT_SUKUBUNGA = new TextBox[jml_product, jml_tipeproduct];
				TextBox [,] TXT_SUKUBUNGA_DUEDATE = new TextBox[jml_product, jml_tipeproduct];
				TextBox [,] TXT_PROVISI = new TextBox[jml_product, jml_tipeproduct];
				string [,] waktu1 = new string[jml_product, jml_tipeproduct];
				string [,] waktu2 = new string[jml_product, jml_tipeproduct];
				TextBox [,] TXT_TAHUNTARGET = new TextBox[jml_product, jml_tipeproduct];
				TextBox [,] TXT_ANGKATARGET = new TextBox[jml_product, jml_tipeproduct];
				TextBox [,] TXT_STOCK1 = new TextBox[jml_product, jml_tipeproduct];
				TextBox [,] TXT_PIUTANG = new TextBox[jml_product, jml_tipeproduct];
				TextBox [,] TXT_KMK1 = new TextBox[jml_product, jml_tipeproduct];
				TextBox [,] TXT_KM1 = new TextBox[jml_product, jml_tipeproduct];
				TextBox [,] TXT_SF1 = new TextBox[jml_product, jml_tipeproduct];
				Label [,] LBL_JAMINANUTAMA = new Label[jml_product, jml_tipeproduct];
				Label [,] LBL_JAMINANTAMBAHAN = new Label[jml_product, jml_tipeproduct];

				for (int i = 0 ; i < jml_tipeproduct ; i++)
				{
					Table Tabel = (Table) this.PH1.FindControl("Tabel" + k.ToString() + i.ToString());
					TXT_CP_LIMIT[k,i] = (TextBox) Tabel.Rows[3].Cells[3].FindControl("TXT_CP_LIMIT"+k+i);
					TXT_CP_TENOR[k,i] = (TextBox) Tabel.Rows[3].Cells[3].FindControl("TXT_CP_TENOR"+k+i);
					TXT_REVOLVING[k,i] = (TextBox) Tabel.Rows[3].Cells[3].FindControl("TXT_REVOLVING"+k+i);
					TXT_TGL1[k,i] = (TextBox) Tabel.Rows[3].Cells[3].FindControl("TXT_TGL1"+k+i);
					TXT_THN1[k,i] = (TextBox) Tabel.Rows[3].Cells[3].FindControl("TXT_THN1"+k+i);
					TXT_TGL2[k,i] = (TextBox) Tabel.Rows[3].Cells[3].FindControl("TXT_TGL2"+k+i);
					TXT_THN2[k,i] = (TextBox) Tabel.Rows[3].Cells[3].FindControl("TXT_THN2"+k+i);
					DDL_BLNA[k,i] = (DropDownList) Tabel.Rows[3].Cells[3].FindControl("DDL_BLN1"+k+i);
					DDL_BLNB[k,i] = (DropDownList) Tabel.Rows[3].Cells[3].FindControl("DDL_BLN2"+k+i);
				
					try 
					{
						waktu1[k,i]= TXT_TGL1[k,i].Text + " " + DDL_BLNA[k,i].SelectedItem.Text + " " + TXT_THN1[k,i].Text;
						waktu2[k,i]= TXT_TGL2[k,i].Text + " " + DDL_BLNB[k,i].SelectedItem.Text + " " + TXT_THN2[k,i].Text;
					}
					catch 
					{
						waktu1[k,i] = "";
						waktu2[k,i] = "";
					}
				
					TXT_CP_INSTALLMENT[k,i] = (TextBox) Tabel.Rows[5].Cells[3].FindControl("TXT_CP_INSTALLMENT"+k+i);
					TXT_SUKUBUNGA[k,i] = (TextBox) Tabel.Rows[5].Cells[3].FindControl("TXT_SUKUBUNGA"+k+i);
					TXT_SUKUBUNGA_DUEDATE[k,i] = (TextBox) Tabel.Rows[5].Cells[3].FindControl("TXT_SUKUBUNGA_DUEDATE"+k+i);
					TXT_PROVISI[k,i] = (TextBox) Tabel.Rows[6].Cells[3].FindControl("TXT_PROVISI"+k+i);		
				
					TXT_TAHUNTARGET[k,i] = (TextBox) Tabel.Rows[7].Cells[3].FindControl("TXT_TAHUNTARGET"+k+i);
					TXT_ANGKATARGET[k,i] = (TextBox) Tabel.Rows[7].Cells[3].FindControl("TXT_ANGKATARGET"+k+i);	

					TXT_STOCK1[k,i] = (TextBox) Tabel.Rows[9].Cells[3].FindControl("TXT_STOCK1"+k+i);
					TXT_PIUTANG[k,i] = (TextBox) Tabel.Rows[9].Cells[3].FindControl("TXT_PIUTANG"+k+i);
					TXT_KMK1[k,i] = (TextBox) Tabel.Rows[10].Cells[3].FindControl("TXT_KMK1"+k+i);
					TXT_KM1[k,i] = (TextBox) Tabel.Rows[11].Cells[3].FindControl("TXT_KM1"+k+i);

					TXT_SF1[k,i] = (TextBox) Tabel.Rows[11].Cells[3].FindControl("TXT_SF1"+k+i);
									
					Label1.Text += "&TXT_CP_LIMIT" + k.ToString() + i.ToString() + "=" + TXT_CP_LIMIT[k,i].Text + 
						"&TXT_CP_TENOR" + k.ToString()+i.ToString() + "=" + TXT_CP_TENOR[k,i].Text +
						"&TXT_REVOLVING" + k.ToString() + i.ToString() + "=" + TXT_REVOLVING[k,i].Text +
						"&WAKTU1" + k.ToString()+i.ToString() + "= " + waktu1[k,i] + 
						"&WAKTU2" + k.ToString()+i.ToString() + "= " + waktu2[k,i] +
						"&TXT_CP_INSTALLMENT" + k.ToString() + i.ToString() + "=" + TXT_CP_INSTALLMENT[k,i].Text +
						"&SUKUBUNGA" + k.ToString()+i.ToString() + "= " + TXT_SUKUBUNGA[k,i].Text + 
						"&TXT_SUKUBUNGA_DUEDATE" + k.ToString() + i.ToString() + "= " + TXT_SUKUBUNGA_DUEDATE[k,i].Text +
						"&TXT_PROVISI" + k.ToString()+i.ToString() + "= " + TXT_PROVISI[k,i].Text + 
						"&TXT_TAHUNTARGET" + k.ToString() + i.ToString() +  "= " + TXT_TAHUNTARGET[k,i].Text + 
						"&TXT_ANGKATARGET" + k.ToString() + i.ToString() +  "= " + TXT_ANGKATARGET[k,i].Text + 
						"&TXT_STOCK1" + k.ToString()+i.ToString() + "= " + TXT_STOCK1[k,i].Text +
						"&TXT_PIUTANG" + k.ToString() + i.ToString() +  "= " + TXT_PIUTANG[k,i].Text +
						"&TXT_KMK1" + k.ToString() + i.ToString() +  "= " + TXT_KMK1[k,i].Text +
						"&TXT_KM1" + k.ToString() + i.ToString() +  "= " + TXT_KM1[k,i].Text +
						"&TXT_SF1" + k.ToString() + i.ToString() +  "= " + TXT_SF1[k,i].Text ;
				
				}
			}


			//---------------------------------------------------------------
			// Untuk mem-pass TEMBUSAN
			//----------------------------------------------------------------
			string lampir = TXT_TEMBUSAN.Text;
			int idx = lampir.IndexOf("\r\n");
			string TEMBUSAN = "";			
			int count = 1;

			while (idx > 0) 
			{
				string temp = lampir.Substring(0,idx);
				string temp2 = lampir.Substring(idx+2);

				Label lbl = new Label();
				lbl.Text = temp;				
				TEMBUSAN = TEMBUSAN + "&TXT_TEMBUSAN" + count + "=" + lbl.Text;

				idx = temp2.IndexOf("\r\n");
				lampir = temp2;
				count += 1;
			}			

			string link = "SPPKPrint.aspx?NO=" + TXT_NO.Text + 
				"&CURTIME=" + TXT_CURTIME.Text + 
				"&LAMP=" + TXT_LAMP.Text + 
				"&CUST_NAME=" + TXT_CUST_NAME.Text + 
				"&ADDR=" + TXT_ADDR.Text+ 
				"&ADDR2=" + TXT_ADDR2.Text+ 
				"&ADDR3=" + TXT_ADDR3.Text+ 
				"&CITY=" + TXT_CITY.Text + 
				"&POSTCODE=" + TXT_POSTCODE.Text +
				"&AP_DATE=" + TXT_AP_DATE.Text +
				"&BRANCH=" + TXT_BRANCH.Text + 
				"&MANAGER=" + TXT_MANAGER.Text + Label1.Text +
 				"&BRANCHMANAGER=" + TXT_BRANCHMANAGER.Text + 
				"&TEMBUSAN=" + TEMBUSAN + 
				"&JUMTEMBUSAN=" + (count-1) + 
				"&MATERAI=" + TXT_MATERAI.Text +
				"&regno=" + regno;
			Tools.popMessage(this, link);

			Response.Redirect("SPPKPrint.aspx?NO=" + TXT_NO.Text + 
				"&CURTIME=" + TXT_CURTIME.Text + 
				"&LAMP=" + TXT_LAMP.Text + 
				"&CUST_NAME=" + TXT_CUST_NAME.Text + 
				"&ADDR=" + TXT_ADDR.Text+ 
				"&ADDR2=" + TXT_ADDR2.Text+ 
				"&ADDR3=" + TXT_ADDR3.Text+ 
				"&CITY=" + TXT_CITY.Text + 
				"&POSTCODE=" + TXT_POSTCODE.Text +
				"&AP_DATE=" + TXT_AP_DATE.Text +
				"&BRANCH=" + TXT_BRANCH.Text + 
				"&MANAGER=" + TXT_MANAGER.Text + Label1.Text +
 				"&BRANCHMANAGER=" + TXT_BRANCHMANAGER.Text + 
				"&TEMBUSAN=" + TEMBUSAN + 
				"&JUMTEMBUSAN=" + (count-1) + 
				"&MATERAI=" + TXT_MATERAI.Text +
				"&regno=" + regno );
		}

	
	}
}
