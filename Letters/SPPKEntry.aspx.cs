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

namespace SME.Letters
{
	/// <summary>
	/// Summary description for SPPKEntry.
	/// </summary>
	public partial class SPPKEntry_new : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected string regno;
		protected string akhir;
		protected string koma;
		protected bool adakoma;
		protected string StringUtamaPLUS;
		protected string hasilnya;
		protected Connection conn;
		protected string var_user;
//		protected string vTXT_TAHUNTARGET;
//		protected string vTXT_ANGKATARGET;
//		protected string vTXT_KMK1;
//		protected string vTXT_KM1;
//		protected string vTXT_SF1;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			//regno = "06102004CBC1000004";
			//conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV2;uid=sa;pwd=dmscorp;Pooling=true");
			conn = (Connection) Session["Connection"];
			regno = Request.QueryString["regno"];		
			
//			setLetterNo();
//			ViewIdentity(regno);
//			ViewData(regno);
//			ViewSomeData(regno);

			ViewData(regno);
			ViewSomeData(regno);
			
			if (!IsPostBack) 
			{

				conn.QueryString = "select * from rfinitial";
				conn.ExecuteQuery();
				string var_small = conn.GetFieldValue("in_small");
				string var_middle = conn.GetFieldValue("in_middle");

				conn.QueryString = "select * from scUser where userid = '" + Session["UserID"].ToString() +"'";
				conn.ExecuteQuery();

				var_user = "";

				string bu = Request.QueryString["bu"];
				if(bu.ToUpper().Trim() == var_small.ToUpper().Trim())
					var_user = conn.GetFieldValue("SU_UPLINER");
				else if(bu.ToUpper().Trim() == var_middle.ToUpper().Trim())
					var_user = conn.GetFieldValue("SU_MIDUPLINER");

				conn.QueryString = "select * from scUser where userid = '" + var_user +"'";
				conn.ExecuteQuery();
					
				TXT_BRANCH.Text = (string) Session["BranchName"];
				TXT_MANAGER.Text = conn.GetFieldValue("SU_FULLNAME");
				TXT_BRANCHMANAGER.Text = (string) Session["GroupName"];

				setLetterNo();
				ViewIdentity(regno);
//				try
//				{
//					conn.QueryString = "select su_fullname , branch_name, jb_desc "+
//						"from scuser su left join rfbranch b on b.branch_code = su.su_branch "+
//						"left join rfjabatan j on j.jb_code = su.jb_code "+
//						"where userid = '" + Session["USERID"].ToString().Trim() + "' ";
//					conn.ExecuteQuery();
//					TXT_MANAGER.Text = conn.GetFieldValue(0,0).Trim();
//					TXT_BRANCH.Text = conn.GetFieldValue(0,1).Trim();
//					TXT_BRANCHMANAGER.Text = conn.GetFieldValue(0,2).Trim();
//				} 
//				catch {}
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

		private void ViewData(string regno)
		{	
			conn.QueryString = "SELECT  DISTINCT PRODUCTID,PRODUCTDESC FROM VW_SPPK_VIEW2" +
				" WHERE AP_REGNO ='" + regno + "'";
			conn.ExecuteQuery();
			int jml_product = conn.GetRowCount();

			//ambil data ketentuan kredit desc yang dimiliki customer
			string[] PRODUCTID = new string[jml_product];
			int p = 0;
			DataTable dt = conn.GetDataTable();
			foreach(DataRow dr in dt.Rows) 
			{
				PRODUCTID[p] = dr["PRODUCTID"].ToString();
				p++;
			}

			for (int a = 0 ; a < jml_product ; a++ )
			{
				conn.QueryString = "SELECT  DISTINCT APPTYPE, APPTYPEDESC FROM VW_SPPK_VIEW2" +
					" WHERE AP_REGNO ='" + regno + "' AND PRODUCTID = '" + PRODUCTID[a] + "' ORDER BY APPTYPE";
				conn.ExecuteQuery();
				
				int jml_app = conn.GetRowCount();

				string[] APPTYPEDESC = new string[jml_app];
				int aa = 0;
				DataTable dta = conn.GetDataTable();
				
				foreach(DataRow dra in dta.Rows) 
				{
					APPTYPEDESC[aa] = dra["APPTYPEDESC"].ToString();
					aa++;
				}


				string xxx = "";
				for (int b = 0 ; b < jml_app ; b++)
				{
					xxx += (xxx==""?APPTYPEDESC[b]:", "+APPTYPEDESC[b]);
				}
				Label LBL_NO = new Label();
				LBL_NO.Text = (a+1)+ ". ";
				LBL_NO.Font.Bold = true;
				Label LBL_APPTYPEDESC = new Label();
				LBL_APPTYPEDESC.ID = "LBL_APPTYPEDESC"+a;
				LBL_APPTYPEDESC.Text = xxx;
				LBL_APPTYPEDESC.Font.Bold = true;
				LBL_APPTYPEDESC.Font.Underline = true;


				Table TabelA = new Table();
				TabelA.ID = "TabelA"+a;
				int h1 = 0;
				TabelA.Rows.Add(new TableRow());
				TabelA.Rows[h1].Cells.Add (new TableCell());
				TabelA.Rows[h1].Cells.Add (new TableCell());
				TabelA.Rows[h1].Cells[0].Controls.Add(LBL_NO);
				TabelA.Rows[h1].Cells[1].Controls.Add(LBL_APPTYPEDESC);
				TabelA.Rows[h1].Cells[0].Font.Size = FontUnit.XSmall;
				TabelA.Rows[h1].Cells[1].Font.Size = FontUnit.XSmall;
				TabelA.Rows[h1].VerticalAlign = VerticalAlign.Top;
				
				PH1.Controls.Add(TabelA);
				
				/***********************************************************************************/
				conn.QueryString = "SELECT distinct PRODUCTID,PRODUCTDESC " +
					" 	FROM VW_SPPK_VIEW2	"+
					" WHERE AP_REGNO ='" + regno + "' AND PRODUCTID= '" +PRODUCTID[a]+ "' ";
				conn.ExecuteQuery();
			
				int jml_tipeproduct = conn.GetRowCount();

				string[] PRODID = new string[jml_tipeproduct];
				string[] PRODUCTDESC = new string[jml_tipeproduct];
				int bb = 0;
				DataTable dtb = conn.GetDataTable();
				foreach(DataRow drb in dtb.Rows) 
				{
					PRODID[bb] = drb["PRODUCTID"].ToString();
					PRODUCTDESC[bb] = drb["PRODUCTDESC"].ToString();
					bb++;
				}

				for (int c = 0 ; c < jml_tipeproduct ; c++)
				{
					Label LBL_PRODUCTDESC = new Label();
					LBL_PRODUCTDESC.ID = "LBL_PRODUCTDESC"+a+c;
					LBL_PRODUCTDESC.Text = PRODUCTDESC[c];
					LBL_PRODUCTDESC.Font.Bold = true; 

					Table TabelB = new Table();
					TabelB.ID = "TabelB"+a+c;
					int jk = 0;
					TabelB.Rows.Add(new TableRow());
					TabelB.Rows[jk].Cells.Add (new TableCell());
					TabelB.Rows[jk].Cells.Add (new TableCell());
					TabelB.Rows[jk].Cells[0].Text = " * ";
					TabelB.Rows[jk].Cells[1].Controls.Add(LBL_PRODUCTDESC);
					TabelB.Rows[jk].Cells[0].Font.Size = FontUnit.XSmall;
					TabelB.Rows[jk].Cells[1].Font.Size = FontUnit.XSmall;
					TabelB.Rows[jk].VerticalAlign = VerticalAlign.Top;

					PH1.Controls.Add(TabelB);

					/**************************************************************************************************************/
					
					conn.QueryString = " select distinct apptype from VW_SPPK_VIEW2 " +
						" where ap_regno = '" + regno + "' and productid = '" + PRODID[c] + "' ";
					conn.ExecuteQuery();
					
					int jml_row = conn.GetRowCount();
					int vv = 0;
					DataTable dtv = conn.GetDataTable();
					string[] vAPPTYPE = new string[jml_row];
					
					foreach(DataRow drv in dtv.Rows) 
					{
						vAPPTYPE[vv] = drv["APPTYPE"].ToString();
						vv++;
					}
					
					string vt = "";
					for (int cnt = 0 ; cnt < jml_row ; cnt++)
					{
						vt += (vt==""?vAPPTYPE[cnt]:", "+vAPPTYPE[cnt]);
					}
					
					int abc = Strings.InStr(1,vt.ToString(),"03",CompareMethod.Text);

					string vSQL; 
					int sgm, n_baris;
					
					if (abc > 0) 
					{
						conn.QueryString = "select cp_limitchg from custproduct where ap_regno = '" + regno + "' and apptype = '03'";
						conn.ExecuteQuery();

						if (conn.GetFieldValue("cp_limitchg")=="+")
						{
							vSQL = "select a.limit cp_limit,b.cp_limit cp_limitchgto,c.ad_limit,(a.limit + c.ad_limit) limit_akhir from bookedprod a, custproduct b, approval_decision c " +
								" where a.aa_no in (select aa_no from bookedcust where cu_ref in (select cu_ref from application where ap_regno = '"+ regno +"')) " +
								" and a.productid = '"+ PRODID[c] +"' " +
								" and b.ap_regno = '"+ regno +"' and b.productid = '"+ PRODID[c] +"' and b.apptype = '03' " +
								" and c.ap_regno = '"+ regno +"' and c.productid = '"+ PRODID[c] +"' and c.apptype = '03'";
						}
						else
						{
							vSQL = "select a.limit cp_limit,b.cp_limit cp_limitchgto,c.ad_limit,(a.limit - c.ad_limit) limit_akhir from bookedprod a, custproduct b, approval_decision c " +
								" where a.aa_no in (select aa_no from bookedcust where cu_ref in (select cu_ref from application where ap_regno = '"+ regno +"')) " +
								" and a.productid = '"+ PRODID[c] +"' " +
								" and b.ap_regno = '"+ regno +"' and b.productid = '"+ PRODID[c] +"' and b.apptype = '03' " +
								" and c.ap_regno = '"+ regno +"' and c.productid = '"+ PRODID[c] +"' and c.apptype = '03'";
						}
						n_baris = 18;
					}
					else
					{
//						vSQL = "select a.limit cp_limit, 0 cp_limitchgto, 0 limit_akhir from bookedprod a"+
//							" where a.aa_no in (select aa_no from bookedcust where cu_ref in (select cu_ref from application where ap_regno = '" + regno + "'))" +
//							" and productid in (" +
//							" select distinct productid from vw_sppk_view2" + 
//							" where productid not in (" +
//							" select distinct productid from vw_sppk_view2" + 
//							" where apptype = '03' and ap_regno = '"+ regno +"')" +
//							" and ap_regno = '"+ regno +"')";

						vSQL = "SELECT A.AD_LIMIT cp_limit, 0 cp_limitchgto, 0 limit_akhir FROM APPROVAL_DECISION A where A.ap_regno = '" + regno + "' " +
								" AND A.AD_SEQ IN (SELECT MAX(AD_SEQ) AD_SEQ FROM APPROVAL_DECISION where ap_regno = '" + regno + "') ";
						n_baris = 17;
					}
					
					conn.QueryString = vSQL;
					conn.ExecuteQuery();

					sgm = n_baris + 5;

					Label LBL_LIMITCHGTO = new Label();
					LBL_LIMITCHGTO.ID = "LBL_LIMITCHGTO"+a+c;
					LBL_LIMITCHGTO.Text = tools.MoneyFormat(conn.GetFieldValue("CP_LIMITCHGTO"));

					Label LBL_LIMITAKHIR = new Label();
					LBL_LIMITAKHIR.ID = "LBL_LIMITAKHIR"+a+c;
					LBL_LIMITAKHIR.Text = tools.MoneyFormat(conn.GetFieldValue("limit_akhir"));	
					
					string CP_LIMIT = tools.MoneyFormat(conn.GetFieldValue("CP_LIMIT"));

					Label LBL_CP_LIMIT	= new Label();
					LBL_CP_LIMIT.ID = "LBL_CP_LIMIT"+a+c;
					LBL_CP_LIMIT.Text = CP_LIMIT + " ";

					string cp_installment,loanpurposedesc;
					conn.QueryString = "SELECT DISTINCT APPTYPE, CU_REF, AP_SIGNDATE, LOANPURPDESC, PRODUCTID" +
						",CURRENCY, APPTYPEDESC, REVOLVING, CP_REVATACCT, CL_DESC,COLTYPEDESC,CL_COLCLASSIFY,COLCLASSDESC" +
						",CP_LIMIT,CP_TENOR, CP_LOANPURPOSE, ISINSTALLMENT, CP_INSTALLMENT, ISAPPROVAL, apl_beaprovisi_pct" +
						" FROM VW_SPPK_VIEW2	"+
						" WHERE AP_REGNO ='" + regno + "' AND PRODUCTDESC= '" +PRODUCTDESC[c]+ "' "; 
					conn.ExecuteQuery();
					
					string CURRENCY = conn.GetFieldValue("CURRENCY");
					loanpurposedesc = conn.GetFieldValue("LOANPURPDESC");	
					
					Table TabelC = new Table();
					TabelC.ID = "TabelC"+a+c;
					int n = 0;
					
					/***************************************************************************************************/
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

					Label LBL_REVOLVING		= new Label();
					Label LBL_CP_TENOR		= new Label();
					
					LBL_REVOLVING.ID = "LBL_REVOLVING"+a+c;
					LBL_REVOLVING.Text = revolvingtemp;
					
					int CP_TENOR = 0;
					try 
					{
						CP_TENOR = Convert.ToInt16(conn.GetFieldValue("CP_TENOR"));
					} 
					catch {}
					string Data_Tenor = "Bulan/tahun/tmt, sejak ";
					TextBox sd = new TextBox ();
					TextBox TXT_FROM = new TextBox();
					TextBox TXT_TO = new TextBox();
					sd.ID = "sd"+a+c;
					sd.Text = " s.d ";
					TXT_FROM.ID = "TXT_FROM"+a+c;
					TXT_FROM.Width =60;
					TXT_FROM.ForeColor = Color.Black;
					TXT_FROM.MaxLength = 10;
					TXT_TO.ID = "TXT_TO"+a+c;
					TXT_TO.Width = 60;
					TXT_TO.ForeColor = Color.Black;
					TXT_TO.MaxLength = 10;

					LBL_CP_TENOR.ID = "LBL_CP_TENOR"+a+c;
					//LBL_CP_TENOR.Text = CP_TENOR + "  " +Data_Tenor + ".... s/d .....";
					LBL_CP_TENOR.Text = CP_TENOR + "  " +Data_Tenor + " ";
						//+TXT_FROM.Text+ " s.d "+TXT_TO.Text;

					
					Label LBL_CP_INSTALLMENT	= new Label();
					LBL_CP_INSTALLMENT.ID = "LBL_CP_INSTALLMENT"+a+c;
					LBL_CP_INSTALLMENT.Text = LBL_CURRENCY.Text + " " + tools.MoneyFormat(cp_installment);

					Label LBL_PROVISI = new Label();
					LBL_PROVISI.ID = "LBL_PROVISI"+a+c;
					LBL_PROVISI.Width = 30;
					LBL_PROVISI.ForeColor = Color.Black;
					LBL_PROVISI.Attributes.Add("onkeypress","return numbersonly();");
					LBL_PROVISI.Text = conn.GetFieldValue("apl_beaprovisi_pct");

					Label LBL_PROVISI_DESC = new Label();
					LBL_PROVISI_DESC.ID = "LBL_PROVISI_DESC"+a+c;
					LBL_PROVISI_DESC.Width = 400;
					LBL_PROVISI_DESC.ForeColor = Color.Black;
					LBL_PROVISI_DESC.Text = " % p.a, dibayar pada saat penandatanganan Akta Perjanjian Kredit ";
					
					TextBox TXT_TAHUNTARGET = new TextBox();
					TXT_TAHUNTARGET.ID = "TXT_TAHUNTARGET"+a+c;
					TXT_TAHUNTARGET.Width = 60;
					TXT_TAHUNTARGET.ForeColor = Color.Black;
					TXT_TAHUNTARGET.MaxLength = 4;
					//vTXT_TAHUNTARGET = TXT_TAHUNTARGET.Text;

					TextBox TXT_SUKUBUNGA = new TextBox();
					TextBox TXT_SUKUBUNGA_DESC = new TextBox();		
					//---
					TXT_SUKUBUNGA.ID = "TXT_SUKUBUNGA"+a+c;
					TXT_SUKUBUNGA.Width = 60;
					TXT_SUKUBUNGA.ForeColor = Color.Black;
					TXT_SUKUBUNGA.MaxLength = 4;
					//---
					TXT_SUKUBUNGA_DESC.ID = "TXT_SUKUBUNGA_DESC"+a+c;
					TXT_SUKUBUNGA_DESC.TextMode = TextBoxMode.MultiLine ;
					TXT_SUKUBUNGA_DESC.Width = 400;
					TXT_SUKUBUNGA_DESC.Text	= " % p.a, dibayar efektif dan dibayar pada tanggal setiap bulan dan dapat berubah sewaktu-waktu sesuai ketentuan yang berlaku di Bank Mandiri, perubahan tersebut mengikat Debitur maupun Penjamin cukup dengan cara pemberitahuan tertulis kepada Debitur.";
			
					TextBox TXT_ANGKATARGET = new TextBox(),TXT_STOCK = new TextBox();
					TXT_ANGKATARGET.ID = "TXT_ANGKATARGET"+a+c;
					TXT_ANGKATARGET.ForeColor = Color.Black;
					TXT_ANGKATARGET.MaxLength = 15;
					TXT_STOCK.ID = "TXT_STOCK"+c;
					TXT_STOCK.MaxLength = 15;
					//vTXT_ANGKATARGET = TXT_ANGKATARGET.Text;

					Label LBL_IDC_RATIO = new Label(),LBL_IDC_JWAKTU = new Label(),LBL_IDC_CAPAMNT = new Label();
					Label LBL_IDC_CAPRATIO = new Label(),LBL_IDC_PRIMEVARCODE = new Label(),LBL_IDC_VARIANCE = new Label(),LBL_IDC_INTEREST = new Label();
					System.Web.UI.HtmlControls.HtmlInputHidden TXT_IDC_CAPAM = new System.Web.UI.HtmlControls.HtmlInputHidden();

					/* START HIDDEN TEXTBOX UTK PASSING PARAM KE PAGE PRINT SPPK */
					TXT_IDC_CAPAM.ID = "TXT_IDC_CAPAMNT"+a+c;
					//TXT_IDC_CAPAM.Visible = true;
					/* END HIDDEN TEXTBOX UTK PASSING PARAM KE PAGE PRINT SPPK */

					LBL_IDC_CAPAMNT.ID = "LBL_IDC_CAPAMNT"+a+c;
					LBL_IDC_JWAKTU.ID = "LBL_IDC_JWAKTU"+a+c;
					LBL_IDC_RATIO.ID = "LBL_IDC_RATIO"+a+c;
					LBL_IDC_CAPRATIO.ID = "LBL_IDC_CAPRATIO"+a+c;
					LBL_IDC_INTEREST.ID = "LBL_IDC_INTEREST"+a+c;

					LBL_IDC_CAPAMNT.Text= "IDC a/c - Plafond";
					LBL_IDC_JWAKTU.Text = "IDC Loan Term";
					LBL_IDC_RATIO.Text = "Main a/c - IDC Ratio";
					LBL_IDC_CAPRATIO.Text = "IDC a/c - % Kapitalis";
					LBL_IDC_INTEREST.Text = "IDC Interest";

					Label LBL_TARGET1 = new Label(),LBL_TARGET2 = new Label(),LBL_TARGET3 = new Label();
					LBL_TARGET1.ID ="LBL_TARGET1"+a+c;
					LBL_TARGET1.Text = "Rata-rata per bulan tahun ";
					LBL_TARGET2.ID ="LBL_TARGET2"+a+c;
					LBL_TARGET2.Text = " minimal sebesar Rp. ";
					LBL_TARGET3.ID ="LBL_TARGET3"+a+c;
					LBL_TARGET3.Text = " harus dapat dicapai dan harus tercermin pada rekening Saudara di Bank kami." ;
					
					Label LBL_PENARIKAN = new Label();
					LBL_PENARIKAN.ID = "LBL_PENARIKAN"+a+c;
					LBL_PENARIKAN.Text = "Sesuai kebutuhan dan baki debet harus tercover oleh rumus/komposisi pembiayaan kredit sebagai berikut: ";	
					
					Label LBL_KMK1 = new Label(),LBL_KMK2  = new Label(),LBL_KMK3 = new Label();
					Label LBL_KMK4 = new Label(),LBL_KMK5 = new Label(),LBL_KMK6 = new Label();
					LBL_KMK1.ID = "LBL_KMK1"+a+c;
					LBL_KMK1.Text = "KMK Perdagangan/Industri tercover ";
					LBL_KMK2.ID = "LBL_KMK2"+a+c;
					LBL_KMK2.Text = " % Stock dan ";
					LBL_KMK3.ID = "LBL_KMK3"+a+c;
					LBL_KMK3.Text = " % Piutang dagang";
					LBL_KMK4.ID = "LBL_KMK4"+a+c;
					LBL_KMK4.Text = "KMK Kontraktor = ";
					LBL_KMK5.ID = "LBL_KMK5"+a+c;
					LBL_KMK5.Text = " (% x {Prestasi Proyek - Uang muka + Termin)}";

					TextBox TXT_STOCK1 = new TextBox(), TXT_PIUTANG = new TextBox();
					TXT_STOCK1.ID = "TXT_STOCK1"+a+c;
					TXT_STOCK1.Width = 30;
					TXT_STOCK1.ForeColor = Color.Black;
					TXT_STOCK1.MaxLength = 15;
					TXT_PIUTANG.ID = "TXT_PIUTANG"+a+c;
					TXT_PIUTANG.Width = 30;
					TXT_PIUTANG.ForeColor = Color.Black;
					TXT_PIUTANG.MaxLength = 15;
								
					TextBox TXT_KMK1 = new TextBox(),TXT_KM1 = new TextBox(),TXT_SF1 = new TextBox();
					TXT_KMK1.ID = "TXT_KMK1"+a+c;
					TXT_KMK1.Width = 30;
					TXT_KMK1.ForeColor = Color.Black;
					TXT_KMK1.MaxLength = 100;
					//vTXT_KMK1 = TXT_KMK1.Text;

					TXT_KM1.ID = "TXT_KM1"+a+c;
					TXT_KM1.Width = 30;
					TXT_KM1.ForeColor = Color.Black;
					TXT_KM1.MaxLength = 100;
					//vTXT_KM1 = TXT_KM1.Text;

					TXT_SF1.ID = "TXT_SF1"+a+c;
					TXT_SF1.Width = 30;
					TXT_SF1.ForeColor = Color.Black;
					TXT_SF1.MaxLength = 100;
					//vTXT_SF1 = TXT_SF1.Text;

					Label LBL_KI1 = new Label(),LBL_KI2 = new Label(),LBL_KI3 = new Label();
					LBL_KI1.ID = "LBL_KI1"+a+c;
					//LBL_KI1.Text = "* KI sesuai kebutuhan progres proyek dengan komposisi kredit maksimal ";
					LBL_KI1.Text = "KI sesuai kebutuhan progres proyek dengan komposisi kredit maksimal ";
					LBL_KI2.ID = "LBL_KI2"+a+c;
					LBL_KI2.Text = " % dan Self Finanding (SF) ";
					LBL_KI3.ID = "LBL_KI3"+a+c;
					LBL_KI3.Text = " % ";

					/****(((((((((((((((((()))))))))))))))))))))))))))******************************************/
					Label LBL_JAMINANUTAMA = new Label(), LBL_JAMINANTAMBAHAN = new Label();
					LBL_JAMINANUTAMA.ID = "LBL_JAMINANUTAMA"+a+c;
					LBL_JAMINANTAMBAHAN.ID = "LBL_JAMINANTAMBAHAN"+a+c;

					Label LBL_JAMINAN = new Label();
					LBL_JAMINAN.ID = "LBL_JAMINAN"+a+c;
					LBL_JAMINAN.Text = "Atas jaminan yang diserahkan akan diikat secara yuridis sempurna sesuai ketentuan" +
						" dan perundang-undangan yang berlaku, biaya pengikatan jaminan menjadi" +
						" beban Debitur.";

					Label LBL_ASURANSI = new Label();
					LBL_ASURANSI.ID = "LBL_ASURANSI"+a+c;
					LBL_ASURANSI.Text = "Selama kredit belum lunas, terhadap barang jaminan yang dapat" +
						" diasuransikan harus diasuransikan kepada perusahaan asuransi rekanan" +
						" PT Bank Mandiri (Persero) dengan syarat Banker's Clause PT Bank Mandiri" +
						" (Persero). Nilai pertanggungan sebesar nilai wajar barang jaminan atas" +
						" persetujuan PT Bank Mandiri (Persero), biaya penutupan asuransi menjadi" +
						" beban Debitur.";
					/***************************************************************************************************/
					
					for (int rr = 0 ; rr < sgm; rr++)
					{
						TabelC.Rows.Add(new TableRow());
						for ( int z = 0 ; z < 6; z++ )
						{
							TabelC.Rows[rr].Cells.Add (new TableCell());
							TabelC.Rows[rr].Cells[z].Font.Size = FontUnit.XSmall;
							TabelC.Rows[rr].Cells[z].VerticalAlign = VerticalAlign.Top;
						}
					}
					
					TabelC.Rows[n].Cells[0].Text = "a.";
					TabelC.Rows[n].Cells[1].Text = "Limit Kredit ";
					TabelC.Rows[n].Cells[2].Text = " : ";
					TabelC.Rows[n].Cells[3].Controls.Add(LBL_CP_LIMIT);
					n++;
					
					/******************************************************************************************/
					if (conn.GetFieldValue("APPTYPE")!="01")
					{
						if (abc > 0)
						{
							TabelC.Rows[n].Cells[0].Text = " ";
							TabelC.Rows[n].Cells[1].Text = "Limit Perubahan";
							TabelC.Rows[n].Cells[2].Text = " : ";
							TabelC.Rows[n].Cells[3].Text = " ";
							TabelC.Rows[n].Cells[3].Controls.Add(LBL_LIMITCHGTO);
							n++;

							TabelC.Rows[n].Cells[0].Text = " ";
							TabelC.Rows[n].Cells[1].Text = "Limit Akhir";
							TabelC.Rows[n].Cells[2].Text = " : ";
							TabelC.Rows[n].Cells[3].Text = " ";
							TabelC.Rows[n].Cells[3].Controls.Add(LBL_LIMITAKHIR);
							n++;
						}
						else
						{
							TabelC.Rows[n].Cells[0].Text = " ";
							TabelC.Rows[n].Cells[1].Text = "Limit Tambahan";
							TabelC.Rows[n].Cells[2].Text = " : ";
							TabelC.Rows[n].Cells[3].Text = " ";
							TabelC.Rows[n].Cells[3].Controls.Add(LBL_LIMITCHGTO);
							n++;
						}
					}
					/******************************************************************************************/

					TabelC.Rows[n].Cells[0].Text = "b.";
					TabelC.Rows[n].Cells[1].Text = "Jenis Kredit ";
					TabelC.Rows[n].Cells[2].Text = " : ";
					TabelC.Rows[n].Cells[3].Text = PRODUCTDESC[c];
					n++;

					TabelC.Rows[n].Cells[0].Text = "c.";
					TabelC.Rows[n].Cells[1].Text = "Sifat Kredit ";
					TabelC.Rows[n].Cells[2].Text = " : ";
					TabelC.Rows[n].Cells[3].Controls.Add(LBL_REVOLVING);
					n++;

					TabelC.Rows[n].Cells[0].Text = "d.";
					TabelC.Rows[n].Cells[1].Text = "Tujuan Penggunaan ";
					TabelC.Rows[n].Cells[2].Text = " : ";
					TabelC.Rows[n].Cells[3].Text = loanpurposedesc;
					n++;

					TabelC.Rows[n].Cells[0].Text = "e.";
					TabelC.Rows[n].Cells[1].Text = "Jangka Waktu ";
					TabelC.Rows[n].Cells[2].Text = " : ";

					if (CP_TENOR > 0) 
					{
						TabelC.Rows[n].Cells[3].Controls.Add(LBL_CP_TENOR);
						TabelC.Rows[n].Cells[3].Controls.Add(TXT_FROM);
						TabelC.Rows[n].Cells[3].Controls.Add(sd);
						TabelC.Rows[n].Cells[3].Controls.Add(TXT_TO);
					}
					else 
					{
						LBL_CP_TENOR.Text = "-";
						TabelC.Rows[n].Cells[3].Controls.Add(LBL_CP_TENOR);
						TabelC.Rows[n].Cells[3].Controls.Add(TXT_FROM);
						TabelC.Rows[n].Cells[3].Controls.Add(sd);
						TabelC.Rows[n].Cells[3].Controls.Add(TXT_TO);
					}
					n++;

					TabelC.Rows[n].Cells[0].Text = "f.";
					TabelC.Rows[n].Cells[1].Text = "Angsuran ";
					TabelC.Rows[n].Cells[2].Text = " : ";
					if (cp_installment != "" && Convert.ToDouble(cp_installment) > 0) 
					{
						TabelC.Rows[n].Cells[3].Controls.Add(LBL_CP_INSTALLMENT);
					}
					else 
					{
						LBL_CP_INSTALLMENT.Text = "-";
						TabelC.Rows[n].Cells[3].Controls.Add(LBL_CP_INSTALLMENT);
					}
					n++;

					TabelC.Rows[n].Cells[0].Text = "g.";
					TabelC.Rows[n].Cells[1].Text = "Suku Bunga ";
					TabelC.Rows[n].Cells[2].Text = " : ";
					//TabelC.Rows[n].Cells[3].Text = " - ";
					TabelC.Rows[n].Cells[3].Controls.Add(TXT_SUKUBUNGA);
					n++;

					TabelC.Rows[n].Cells[0].Text = "h.";
					TabelC.Rows[n].Cells[1].Text = " Provisi/Commitment Fee ";
					TabelC.Rows[n].Cells[2].Text = " : ";
					TabelC.Rows[n].Cells[3].Text = "  ";
					TabelC.Rows[n].Cells[3].Controls.Add(LBL_PROVISI);
					TabelC.Rows[n].Cells[3].Controls.Add(LBL_PROVISI_DESC);
					n++;

					conn.QueryString = "Select  IDC_RATIO, IDC_JWAKTU, IDC_CAPAMNT, IDC_CAPRATIO, IDC_PRIMEVARCODE, IDC_VARIANCE, IDC_INTEREST,IDC_INTERESTTYPE " +
						" from CUSTPRODUCT where ap_regno = '" + regno + "' and IDC_RATIO is not null";

					conn.ExecuteQuery();

					TabelC.Rows[n].Cells[0].Text = "i.";
					TabelC.Rows[n].Cells[1].Text = "Interest During Construction :";

					string a1 = conn.GetFieldValue("IDC_CAPAMNT");
					/*
					string a2 = conn.GetFieldValue("IDC_JWAKTU");
					string a3 = conn.GetFieldValue("IDC_RATIO");
					string a4 = conn.GetFieldValue("IDC_CAPRATIO");
					string a5 = conn.GetFieldValue("IDC_INTERESTTYPE") + '-' + conn.GetFieldValue("IDC_PRIMEVARCODE") + '-' + conn.GetFieldValue("IDC_VARIANCE");
					*/

					TabelC.Rows[n].Cells[2].Controls.Add(new LiteralControl("<LI>"));
					TabelC.Rows[n].Cells[2].VerticalAlign = VerticalAlign.Top;
					TabelC.Rows[n].Cells[3].Text = LBL_IDC_CAPAMNT.Text + " = " + GlobalTools.MoneyFormat(a1);
					TabelC.Rows[n].Cells[3].VerticalAlign = VerticalAlign.Top;
					TabelC.Rows[n].Cells[3].HorizontalAlign = HorizontalAlign.Left;
					TXT_IDC_CAPAM.Value = LBL_IDC_CAPAMNT.Text + " = " + GlobalTools.MoneyFormat(a1);
					TabelC.Rows[n].Cells[4].Controls.Add(TXT_IDC_CAPAM);
					n++;
				
					/*
					TabelC.Rows[n].Cells[2].Controls.Add(new LiteralControl("<LI>"));
					TabelC.Rows[n].Cells[2].VerticalAlign = VerticalAlign.Top;
					TabelC.Rows[n].Cells[3].Text = LBL_IDC_JWAKTU.Text + " = " + a2;
					TabelC.Rows[n].Cells[3].VerticalAlign = VerticalAlign.Top;
					TabelC.Rows[n].Cells[3].HorizontalAlign = HorizontalAlign.Left;
					n++;

					TabelC.Rows[n].Cells[2].Controls.Add(new LiteralControl("<LI>"));
					TabelC.Rows[n].Cells[2].VerticalAlign = VerticalAlign.Top;
					TabelC.Rows[n].Cells[3].Text = LBL_IDC_RATIO.Text + " = " + a3;
					TabelC.Rows[n].Cells[3].VerticalAlign = VerticalAlign.Top;
					TabelC.Rows[n].Cells[3].HorizontalAlign = HorizontalAlign.Left;
					n++;
					
					TabelC.Rows[n].Cells[2].Controls.Add(new LiteralControl("<LI>"));
					TabelC.Rows[n].Cells[2].VerticalAlign = VerticalAlign.Top;
					TabelC.Rows[n].Cells[3].Text = LBL_IDC_CAPRATIO.Text + " = " + a4;
					TabelC.Rows[n].Cells[3].VerticalAlign = VerticalAlign.Top;
					TabelC.Rows[n].Cells[3].HorizontalAlign = HorizontalAlign.Left;
					n++;

					TabelC.Rows[n].Cells[2].Controls.Add(new LiteralControl("<LI>"));
					TabelC.Rows[n].Cells[2].VerticalAlign = VerticalAlign.Top;
					TabelC.Rows[n].Cells[3].Text = LBL_IDC_INTEREST.Text + " = " + a5;
					TabelC.Rows[n].Cells[3].VerticalAlign = VerticalAlign.Top;
					TabelC.Rows[n].Cells[3].HorizontalAlign = HorizontalAlign.Left;
					n++;
					*/
					
					TabelC.Rows[n].Cells[0].Text = "j.";
					TabelC.Rows[n].Cells[1].Text = "Target Penjualan ";
					TabelC.Rows[n].Cells[2].Text = " : ";
					TabelC.Rows[n].Cells[3].Controls.Add(LBL_TARGET1);
					TabelC.Rows[n].Cells[3].Controls.Add(TXT_TAHUNTARGET);
					TabelC.Rows[n].Cells[3].Controls.Add(LBL_TARGET2);
					TabelC.Rows[n].Cells[3].Controls.Add(TXT_ANGKATARGET);
					TabelC.Rows[n].Cells[3].Controls.Add(LBL_TARGET3);
					n++;

					TabelC.Rows[n].Cells[0].Text = "k.";
					TabelC.Rows[n].Cells[1].Text = "Penarikan kredit ";
					TabelC.Rows[n].Cells[2].Text = " : ";
					TabelC.Rows[n].Cells[3].Controls.Add(LBL_PENARIKAN);
					n++;

					TabelC.Rows[n].Cells[0].Text = "";
					TabelC.Rows[n].Cells[1].Text = "";
					TabelC.Rows[n].Cells[2].Text = "";
					TabelC.Rows[n].Cells[3].Controls.Add(new LiteralControl("<LI>"));
					TabelC.Rows[n].Cells[3].Controls.Add(LBL_KMK4);
					TabelC.Rows[n].Cells[3].Controls.Add(TXT_KMK1);
					TabelC.Rows[n].Cells[3].Controls.Add(LBL_KMK5);

					n++;
					TabelC.Rows[n].Cells[0].Text = "";
					TabelC.Rows[n].Cells[1].Text = "";
					TabelC.Rows[n].Cells[2].Text = "";
					TabelC.Rows[n].Cells[3].Controls.Add(new LiteralControl("<LI>"));
					TabelC.Rows[n].Cells[3].Controls.Add(LBL_KI1);
					TabelC.Rows[n].Cells[3].Controls.Add(TXT_KM1);
				
					TabelC.Rows[n].Cells[3].Controls.Add(LBL_KI2);
					TabelC.Rows[n].Cells[3].Controls.Add(TXT_SF1);
					TabelC.Rows[n].Cells[3].Controls.Add(LBL_KI3);
					
					n++;

					TabelC.Rows[n].Cells[0].Text = "l.";
					TabelC.Rows[n].Cells[1].Text = "Jaminan Kredit ";
					TabelC.Rows[n].Cells[2].Text = " : ";
					TabelC.Rows[n].Cells[3].Text = "  ";
					n++;
					/*******************************************************************************************************************************************/
					//Ambil nilai JAMINAN UTAMA... CL_COLCLASIFY =01
						
					conn.QueryString = "SELECT DISTINCT CL_DESC,COLTYPEDESC FROM  VW_SPPK_VIEW2 " +
						"WHERE AP_REGNO ='" + regno + "' AND  CL_COLCLASSIFY='01' " +
						" AND PRODUCTDESC ='" + PRODUCTDESC[c]+"' ";
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
									string ab = DESC[0] + " (" + TYPE[0]+  ")";
									UTAMA[m] = ab;
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
						" AND PRODUCTDESC ='" + PRODUCTDESC[c]+"' ";
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
							{
								if (t == (s-1)) 
								{
									TAMBAHAN[t] += " dan " + DESCT[t] + " (" + TYPET[t]+  ")";
									LBL_JAMINANTAMBAHAN.Text += TAMBAHAN[t];
									if (s == 2) 
									{
										string cb = DESCT[0] + " (" + TYPET[0]+  ")";
										TAMBAHAN[t] = cb;
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

					TabelC.Rows[n].Cells[0].Text = "";
					TabelC.Rows[n].Cells[1].Text = " - Jaminan Utama ";
					TabelC.Rows[n].Cells[2].Text = " : ";
					TabelC.Rows[n].Cells[3].Controls.Add(LBL_JAMINANUTAMA);
							
					n++;
					TabelC.Rows[n].Cells[0].Text = "";
					TabelC.Rows[n].Cells[1].Text = " - Jaminan Tambahan ";
					TabelC.Rows[n].Cells[2].Text = " : ";
					TabelC.Rows[n].Cells[3].Controls.Add(LBL_JAMINANTAMBAHAN);
					n++;
					TabelC.Rows[n].Cells[0].Text = "";
					TabelC.Rows[n].Cells[1].Text = "";
					TabelC.Rows[n].Cells[2].Text = "";
					TabelC.Rows[n].Cells[3].Controls.Add(LBL_JAMINAN);
					/*******************************************************************************************************************************************/		

					TabelC.Rows[n].Cells[0].Text = "m.";
					TabelC.Rows[n].Cells[1].Text = "Asuransi ";
					TabelC.Rows[n].Cells[2].Text = " : ";
					TabelC.Rows[n].Cells[3].Text = "  ";
					n++;

					Table Tabelk = new Table();
					Tabelk.ID = "Tabelk"+a+c;
					Tabelk.Rows.Add(new TableRow());
					Tabelk.Rows[0].Cells.Add (new TableCell());
					Tabelk.Rows[0].Cells.Add (new TableCell());
					Tabelk.Rows[0].Cells[0].Text = "  ";
					Tabelk.Rows[0].Cells[1].Controls.Add(LBL_ASURANSI);
					Tabelk.Rows[0].Cells[1].Font.Size = FontUnit.XSmall;
					Tabelk.Rows[0].Cells[1].VerticalAlign = VerticalAlign.Top;

					//---------------------------------------------

					PH1.Controls.Add(TabelC);
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

			conn.QueryString = "select * from rfinitial";
			conn.ExecuteQuery();
			string var_small = conn.GetFieldValue("in_small");
			string var_middle = conn.GetFieldValue("in_middle");

			string bu = Request.QueryString["bu"];
			if(bu.ToUpper().Trim() == var_small.ToUpper().Trim())
			{
				conn.QueryString = "select SYARAT_DOCTYPEDESC, isnull(SY_JENISPRODUCT,'') as SY_JENISPRODUCT from VW_SYARAT_SPPK " +
					"WHERE AP_REGNO ='" + regno + "' and doctypeid='5' and SY_JENISPRODUCT is null order by SY_JENISPRODUCT";
			
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
			
					TBL_SYARAT_PKR.Rows[j].Cells[0].Controls.Add(new LiteralControl("<LI>"));
					TBL_SYARAT_PKR.Rows[j].Cells[0].VerticalAlign = VerticalAlign.Top;
					TBL_SYARAT_PKR.Rows[j].Cells[1].Text = sy5[j];
					TBL_SYARAT_PKR.Rows[j].Cells[1].HorizontalAlign = HorizontalAlign.Justify;
					j++;
				}
			}
			else if(bu.ToUpper().Trim() == var_middle.ToUpper().Trim())
			{

				conn.QueryString = "select distinct SY_JENISPRODUCT from VW_SYARAT_SPPK " +
					"WHERE AP_REGNO ='" + regno + "' and doctypeid='5' and (SY_JENISPRODUCT is not null or SY_JENISPRODUCT<>'') order by SY_JENISPRODUCT";
				conn.ExecuteQuery();

				DataTable dtx = conn.GetDataTable();
				string CL = "";
				int x = 0;
				foreach(DataRow drx in dtx.Rows)
				{
					CL = drx["SY_JENISPRODUCT"].ToString();

					TBL_SYARAT_PKR.Rows.Add(new TableRow());
					TBL_SYARAT_PKR.Rows[x].Cells.Add(new TableCell());
					TBL_SYARAT_PKR.Rows[x].Cells.Add(new TableCell());
					TBL_SYARAT_PKR.Rows[x].Cells.Add(new TableCell());

					TBL_SYARAT_PKR.Rows[x].Cells[0].Controls.Add(new LiteralControl("<LI>"));
					TBL_SYARAT_PKR.Rows[x].Cells[0].VerticalAlign = VerticalAlign.Top;
					TBL_SYARAT_PKR.Rows[x].Cells[1].Text = CL;
					TBL_SYARAT_PKR.Rows[x].Cells[1].VerticalAlign = VerticalAlign.Top;
					TBL_SYARAT_PKR.Rows[x].Cells[1].HorizontalAlign = HorizontalAlign.Justify;

					//Step 1
					conn.QueryString = "select SY_JENISPRODUCT, SYARAT_DOCTYPEDESC  from VW_SYARAT_SPPK " +
						"WHERE SY_JENISPRODUCT = '" + CL + "' and AP_REGNO ='" + regno + "' and doctypeid='5' and (SY_JENISPRODUCT is not null or SY_JENISPRODUCT<>'') order by SY_JENISPRODUCT";

					conn.ExecuteQuery();
					
					DataTable dtx1 = conn.GetDataTable();
					string DESC = "";
					
					x++;

					int j = 1;
					foreach(DataRow drx1 in dtx1.Rows)
					{
						DESC = drx1["SYARAT_DOCTYPEDESC"].ToString();
					
						TBL_SYARAT_PKR.Rows.Add(new TableRow());
						TBL_SYARAT_PKR.Rows[x].Cells.Add(new TableCell());
						TBL_SYARAT_PKR.Rows[x].Cells.Add(new TableCell());
						TBL_SYARAT_PKR.Rows[x].Cells.Add(new TableCell());
					
						TBL_SYARAT_PKR.Rows[x].Cells[1].Text = j.ToString();
						TBL_SYARAT_PKR.Rows[x].Cells[1].VerticalAlign = VerticalAlign.Top;
						TBL_SYARAT_PKR.Rows[x].Cells[2].Text = DESC;
						TBL_SYARAT_PKR.Rows[x].Cells[2].VerticalAlign = VerticalAlign.Top;
						TBL_SYARAT_PKR.Rows[x].Cells[2].HorizontalAlign = HorizontalAlign.Justify;
						j++;
						x++;
					}
				}
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

		protected void BTN_PREVIEW_Click(object sender, System.EventArgs e)
		{
			
			//--tamabahan nur untuk save SPPK------------
				conn.QueryString = "exec SPPK_SAVE '"+regno+"', '"+TXT_NO.Text+"','"+Session["UserID"]+"'";
				conn.ExecuteNonQuery();
			//-------------------------------------------
			

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
				"&MANAGER=" + TXT_MANAGER.Text + query.Value +
				"&BRANCHMANAGER=" + TXT_BRANCHMANAGER.Text + 
				"&TEMBUSAN=" + TEMBUSAN + 
				"&JUMTEMBUSAN=" + (count-1) + 
				"&MATERAI=" + TXT_MATERAI.Text +
				"&regno=" + regno ;
			//GlobalTools.popMessage(this, link);

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
				"&MANAGER=" + TXT_MANAGER.Text + query.Value +
				"&BRANCHMANAGER=" + TXT_BRANCHMANAGER.Text + 
				"&TEMBUSAN=" + TEMBUSAN + 
				"&JUMTEMBUSAN=" + (count-1) + 
				"&MATERAI=" + TXT_MATERAI.Text +
				"&regno=" + regno );
		}

	}
}
