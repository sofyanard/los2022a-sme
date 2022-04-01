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
using DMS.DBConnection;


namespace SME.CreditProposal
{
	/// <summary>
	/// Summary description for NotaAnalisa.
	/// </summary>
	public partial class PengikatanAgunan : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
		protected string akhir;
		protected string  koma;
		protected bool adakoma;
		protected string StringUtamaPLUS;
		protected string hasilnya;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			// Put user code to initialize the page here
			if (!IsPostBack) 
			{				
				TXT_NAMA_TTD.Text = (string) Session["FullName"];
				TXT_DEPT_TTD.Text = (string) Session["GroupName"];
				TXT_ALAMAT_JCCO_TTD.Text = (string) Session["BranchName"];

				viewData();
				viewNomorSurat();
				viewCollateral();
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

		protected void BTN_VIEW_Click(object sender, System.EventArgs e)
		{
			this.viewFinal();
		}

		protected void BTN_VIEW_2_Click(object sender, System.EventArgs e)
		{
			this.viewFinal();
		}

		private void viewFinal() 
		{
			Server.Transfer("PengikatanAgunan_Final.aspx");
		}

		private void viewData() 
		{
			string regno = Request.QueryString["regno"];
			string cu_ref = Request.QueryString["cu_ref"];

			conn.QueryString = "SELECT " +
					"APPLICATION.CU_REF, " +
					"APPLICATION.AP_REGNO, " +
					"CASE CUSTOMER.CU_CUSTTYPEID WHEN '01' " +
					"THEN isnull(COMPTYPEDESC, '') + ' ' + isnull(CU_COMPNAME, '') " +
					"ELSE isnull(CU_FIRSTNAME, '') + ' ' + isnull(CU_MIDDLENAME, '') + ' ' + isnull(CU_LASTNAME, '') END AS CU_NAME " +
				"FROM " +
					"APPLICATION LEFT OUTER JOIN " +
					"CUSTOMER ON APPLICATION.CU_REF = CUSTOMER.CU_REF LEFT OUTER JOIN " +
					"CUST_COMPANY ON APPLICATION.CU_REF = CUST_COMPANY.CU_REF LEFT OUTER JOIN " +
					"RFCOMPTYPE ON CUST_COMPANY.CU_COMPTYPE = RFCOMPTYPE.COMPTYPEID LEFT OUTER JOIN " +
					"CUST_PERSONAL ON APPLICATION.CU_REF = CUST_PERSONAL.CU_REF " +
				"WHERE APPLICATION.AP_REGNO = '" + regno + "'";
			conn.ExecuteQuery();
			this.TXT_NAMA_DEBITUR.Text = conn.GetFieldValue("CU_NAME");

			conn.QueryString = "select * from RFNOTARY " +
							   "where NTID like (select NTID from NOTARYASSIGN where AP_REGNO = '" + regno + "')";
			conn.ExecuteQuery();
            this.TXT_TANGGAL.Text = DateTime.Today.ToString("dd MMM yyyy");
			this.TXT_NAMA_NOTARIS.Text = conn.GetFieldValue("NT_NAME");
			this.TXT_ALAMAT1_NOTARIS.Text = conn.GetFieldValue("NT_ADDR1");
			this.TXT_ALAMAT2_NOTARIS.Text = conn.GetFieldValue("NT_ADDR2");
			this.TXT_ALAMAT3_NOTARIS.Text = conn.GetFieldValue("NT_ADDR3");
			this.TXT_TELP_NOTARIS.Text = "Telp/Fax. " + conn.GetFieldValue("NT_PHNAREA") + 
										 conn.GetFieldValue("NT_PHNNUM") + 
										 conn.GetFieldValue("NT_PHNEXT") + "/ " +
										 conn.GetFieldValue("NT_FAXAREA") +
										 conn.GetFieldValue("NT_FAXNUM");
		}		

		private void viewNomorSurat() 
		{
			/* *******************************************************
			* Menentukan NOMOR SURAT untuk PENGIKATAN AGUNAN
			* ********************************************************/
			string no_surat;
			string USERID		= (string) Session["UserID"];
			string BRANCH		= (string) Session["BranchName"];

			conn.QueryString = "select isnull(LTR_NO,0) LTR_NO from RFLETTERNUMBER where LTR_USERID = '"+USERID+"' and LTR_LETTERTYPE = 'IKAT_AGUNAN'";
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
				
			no_surat = BRANCH + "/" + nomor + "/" + Now_Year;
			TXT_NO_SURAT.Text = no_surat;
			/*----------------------------------------------------------*/
		}

		private void viewCollateral() 
		{
			string regno  = Request.QueryString["regno"];
			string cu_ref = Request.QueryString["cu_ref"];
			string cl_seq = Request.QueryString["cl_seq"];

			conn.QueryString = "select *, cast(LC_VALUE as float) LC_VALUE_FLOAT from VW_CO_IKAT_AGUNAN where AP_REGNO = '"+regno+"' and cl_seq = '"+cl_seq+"'";
			conn.ExecuteQuery();

			TXT_DIIKAT.Text			= conn.GetFieldValue("CL_DESC");
			TXT_JCCO.Text			= TXT_ALAMAT_JCCO_TTD.Text;
			TXT_JUMLAH_IKAT.Text	= tool.MoneyFormat(conn.GetFieldValue("LC_VALUE_FLOAT"));
			TXT_JUMLAH_IKAT_TERBILANG.Text = SeleksiKonversi(conn.GetFieldValue("LC_VALUE"));
		}

		private string SeleksiKonversi(string StringUtama)
		{
				string output = "";
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
	}
}
