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

namespace SME.InitialDataEntry
{ 
	public partial class AIP1 : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected System.Web.UI.WebControls.TextBox TXT_;
		protected string akhir;
		protected string  koma;
		protected bool adakoma;
		protected string StringUtamaPLUS;
		protected string hasilnya;
		protected string PRODUCTDESC1;
		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			
			if (!IsPostBack)
			{
				string regno		= Request.QueryString["regno"].ToString();
				string apptype		= Request.QueryString["apptype"].ToString();

				conn.QueryString = "SELECT WAKTU = DATENAME(DAY, getDATE())+ ' '+" +
					"DATENAME(MONTH, getDATE()) +' '+ " +
					"DATENAME(YEAR, getDATE())" ;
				conn.ExecuteQuery();
				TXT_CURTIME.Text = conn.GetFieldValue("WAKTU");

			

				conn.QueryString = " SELECT AP_REGNO, APPTYPE, NAMA, ALAMAT, KOTA," + 
					"ZIPCODE, CP_LIMIT, PRODUCTDESC, CU_CUSTTYPEID, " +
					"ALAMAT1, ALAMAT2, ALAMAT3, ZIPDESC, SR_LIMIT " + 
					"FROM VW_AIP_VIEW " +
					"WHERE AP_REGNO ='" + regno + "'and APPTYPE ='" + apptype + "' " ;
				conn.ExecuteQuery();
		

				TXT_CUST_NAME.Text	= conn.GetFieldValue("NAMA");
				//TXT_ADDR.Text		= conn.GetFieldValue("ALAMAT");
				TXT_ADDR.Text		= conn.GetFieldValue("ALAMAT1");
				TXT_ADDR2.Text		= conn.GetFieldValue("ALAMAT2");
				TXT_ADDR3.Text		= conn.GetFieldValue("ALAMAT3");
				TXT_CITY.Text		= conn.GetFieldValue("ZIPDESC") + " " + conn.GetFieldValue("KOTA");
				TXT_POSTCODE.Text	= conn.GetFieldValue("ZIPCODE");
				TXT_CP_LIMIT.Text	= tools.MoneyFormat(conn.GetFieldValue("SR_LIMIT"));
				string CU_CUSTTYPEID = conn.GetFieldValue("CU_CUSTTYPEID");
				string ProductDesc = conn.GetFieldValue("PRODUCTDESC");
						
				/*
				conn.QueryString = "SELECT  SUM(CP_LIMIT) AS TOTAL_LIMIT" +
					" FROM VW_AIP_VIEW " +
					" WHERE AP_REGNO ='" + regno + "'and APPTYPE ='" + apptype + "' ";
				conn.ExecuteQuery();
				TXT_CP_LIMIT.Text	= tools.MoneyFormat(conn.GetFieldValue("TOTAL_LIMIT"));
				//PANGGIL PROSEDUR U/ AMBIL NOMINALNYA.
				SeleksiKonversi(conn.GetFieldValue("TOTAL_LIMIT"));
				*/
											
				conn.QueryString = "SELECT  PRODUCTDESC FROM VW_AIP_VIEW " +
					" WHERE AP_REGNO ='" + regno + "' AND APPTYPE ='" + apptype + "' ";
				conn.ExecuteQuery();
				int j = conn.GetRowCount();
				int i = 0;
				
				DataTable dt = conn.GetDataTable();
				foreach(DataRow dr in dt.Rows) 
				{
					string[] test = new string[j];
				
					test[i] = dr["PRODUCTDESC"].ToString();
					if (j == 1)
					{
						PRODUCTDESC1= test[0];
					} 
					else	
						if (j == 2) 
					{
						string a = test[0];
						PRODUCTDESC1 += a;
						if (i == 1 )
						{
							PRODUCTDESC1 += " dan " + test[1];
						
						}
					}
					else
					{
						
						if (i == (j-1)) 
						{
							PRODUCTDESC1 += " dan " + test[i];
						
						}
						else
						{
							PRODUCTDESC1 += test[i] + ", ";
						}
											
					}

					i++;
				}	
				TXT_PRODUCTDESC1.Text = PRODUCTDESC1;
				TXT_PRODUCTDESC2.Text = TXT_PRODUCTDESC3.Text = TXT_PRODUCTDESC1.Text;
				//				TXT_PRODUCTDESC1.Width = ((PRODUCTDESC1.Length)*8);
				//				TXT_PRODUCTDESC2.Width = ((PRODUCTDESC1.Length)*8);
				//				TXT_PRODUCTDESC3.Width = ((PRODUCTDESC1.Length)*8);
				try
				{
					conn.QueryString = "select su_fullname , branch_name, jb_desc "+
						"from scuser su left join rfbranch b on b.branch_code = su.su_branch "+
						"left join rfjabatan j on j.jb_code = su.jb_code "+
						"where userid = '" + Session["USERID"].ToString().Trim() + "' ";
					conn.ExecuteQuery();
					TXT_OFFICER.Text = conn.GetFieldValue(0,0).Trim();
					TXT_BRANCH.Text = conn.GetFieldValue(0,1).Trim();
					TXT_BO.Text = conn.GetFieldValue(0,2).Trim();
				} 
				catch {}

				TXT_BRANCH.Text = (string) Session["BranchName"];
				TXT_OFFICER.Text = (string) Session["FullName"];
				TXT_BO.Text = (string) Session["GroupName"];
			
				setNomorSurat();

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

		private void setNomorSurat() 
		{
			/* *******************************************************
			* Menentukan NOMOR SURAT untuk AIP LETTER
			* ********************************************************/
			string no_surat;
			string USERID		= (string) Session["UserID"];

			conn.QueryString = "select * from LETTER where USERID = '"+USERID+"' and AP_REGNO = '"+Request.QueryString["regno"]+"' and LETTERTYPE = '1'";
			conn.ExecuteQuery();
			int nomor		= conn.GetRowCount()+1;
			string Now_Year = System.DateTime.Now.Year.ToString();
				
			no_surat	= TXT_BRANCH.Text + "/" + nomor + "/" + Now_Year;
			TXT_NO.Text = no_surat;
			/*----------------------------------------------------------*/	
		}


		protected void PrintBtn_Click(object sender, System.EventArgs e)
		{
		
			Response.Redirect("AIPBPrint.aspx?TXT_NO=" + TXT_NO.Text + "&TXT_CURTIME= " + TXT_CURTIME.Text + "&TXT_LAMP=" + TXT_LAMP.Text + 
				"&TXT_PRODUCTDESC1= " + TXT_PRODUCTDESC1.Text + "&TXT_PRODUCTDESC2= " + TXT_PRODUCTDESC2.Text + 
				"&TXT_PRODUCTDESC3= " + TXT_PRODUCTDESC3.Text + "&TXT_LGL= " + TXT_LGL.Text +
				"&TXT_CP_LIMIT=" + TXT_CP_LIMIT.Text +"&TXT_NOMINAL_CP_LIMIT= " + TXT_NOMINAL_CP_LIMIT.Text + 
				"&TXT_BRANCH= " + TXT_BRANCH.Text + "&TXT_OFFICER= " + TXT_OFFICER.Text +
				"&TXT_CUST_NAME= " + TXT_CUST_NAME.Text + 
				"&TXT_ADDR= " + TXT_ADDR.Text +
				"&TXT_ADDR2= " + TXT_ADDR2.Text +
				"&TXT_ADDR3= " + TXT_ADDR3.Text +
				"&TXT_CITY= " + TXT_CITY.Text + "&TXT_POSTCODE= " + TXT_POSTCODE.Text +
				"&TXT_BO= " + TXT_BO.Text + 
				"&regno=" + Request.QueryString["regno"]);
		}
		
		private void SeleksiKonversi(string StringUtama)
		{
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
				{konversi(StringUtama);	} 
				else
				{konversi(StringUtamaPLUS);}
			}
		}

		private void konversi(string u)
		{
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
			TXT_NOMINAL_CP_LIMIT.Text = hasilnya;
			TXT_NOMINAL_CP_LIMIT.Width = ((hasilnya.Length)*7);
		}
	
	}
}
