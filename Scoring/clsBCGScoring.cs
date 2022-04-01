using System;
using System.Data;
using System.IO;
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.Scoring
{
	/// <summary>
	/// Summary description for clsBCGScoring.
	/// </summary>
	public class clsBCGScoring
	{
		private Connection conn;
		private DataTable ds1, ds2, ds3;
		public clsBCGScoring(Connection conn)
		{
			this.conn = conn;
		}

		#region Conversion Functions
		private string trimZero(string par)
		{
			/********************************************************
			 *  menghilangkan padding 0 yang berada di depan angka  *
			*********************************************************/
			string r = "";
			string sign = "";

			try
			{
				par = par.Trim();
				int x = par.Length-1; 

				if (par.Substring(0,1) == "-") 
				{
					//					sign = "-";
					//					par  = par.Substring(1, par.Length);
					r = par.Trim();
				}
				else if ((par == "") || (par == "0"))
				{
					r = par;
				}
				else
				{
				
					for (int i=0; i <= x; i++)
					{ // 000601
						string cur = par.Substring(i,1);
						if ((cur == "0") && (i == x))
						{
							r = "0";
							break;
						}
						else if ( cur == "0") 
						{
							if ((par.Substring(i+1,1) == "."))
							{  // menghandle 0 di depan titik desimal
								sign += "0";
							}
							continue;
						}
						else 
						{
							r = par.Substring(i);
							break;
						}
					}
				}
			} 
			catch { r = ""; }
			return sign + r;
		}

		private string trimZeroRangeData(string par)
		{
			/********************************************************
			 *  menghilangkan padding 0 yang berada di depan angka  *
			*********************************************************/
			string r = "";
			string sign = "";

			try
			{
				par = par.Trim();
				int x = par.Length-1; 

				if (par.Substring(0,1) == "-") 
				{
					//					sign = "-";
					//					par  = par.Substring(1, par.Length);
					r = par.Trim();
				}
				else if ((par == "") || (par == "0"))
				{
					r = par;
				}
				else
				{
				
					for (int i=0; i <= x; i++)
					{ // 000601
						string cur = par.Substring(i,1);
						if ((cur == "0") && (i == x))
						{
							r = "0";
							break;
						}
						else if ( cur == "0") 
						{
							if ((par.Substring(i+1,1) == "."))
							{  // menghandle 0 di depan titik desimal
								sign += "0";
							}
							continue;
						}
						else 
						{
							r = par.Substring(i);
							break;
						}
					}
				}
			} 
			catch { r = ""; }
			//antisipasi untuk data berupa range... misal 0-0.5% dan 0<>100
			//supaya nol didepan angka tidak hilang...
			string retval = sign + r;
			try 
			{
				if (retval.Substring(0,3)== "-0.")
					retval = "0-0." + retval.Substring(3);
			} 
			catch {}
			try
			{
				if (retval.Substring(0,2)== "<>")
					retval = "0<>" + retval.Substring(2);
			} 
			catch{}
			return retval;
		}

		private string CovFromEBCDIC(string strTemp)
		{
			string strX;
			if ((strTemp == null) || (strTemp == "")) return "";
			strX = strTemp;

			if(strX.Substring(strX.Length-1,1).Equals("{"))
				strX=strX.Substring(0,strX.Length-1)+"0";
			else if (strX.Substring(strX.Length-1,1).Equals("A"))
				strX=strX.Substring(0,strX.Length-1)+"1";
			else if (strX.Substring(strX.Length-1,1).Equals("B"))
				strX=strX.Substring(0,strX.Length-1)+"2";
			else if (strX.Substring(strX.Length-1,1).Equals("C"))
				strX=strX.Substring(0,strX.Length-1)+"3";
			else if (strX.Substring(strX.Length-1,1).Equals("D"))
				strX=strX.Substring(0,strX.Length-1)+"4";
			else if (strX.Substring(strX.Length-1,1).Equals("E"))
				strX=strX.Substring(0,strX.Length-1)+"5";
			else if (strX.Substring(strX.Length-1,1).Equals("F"))
				strX=strX.Substring(0,strX.Length-1)+"6";
			else if (strX.Substring(strX.Length-1,1).Equals("G"))
				strX=strX.Substring(0,strX.Length-1)+"7";
			else if (strX.Substring(strX.Length-1,1).Equals("H"))
				strX=strX.Substring(0,strX.Length-1)+"8";
			else if (strX.Substring(strX.Length-1,1).Equals("I"))
				strX=strX.Substring(0,strX.Length-1)+"9";

			else if(strX.Substring(strX.Length-1,1).Equals("}"))
				strX="-"+strX.Substring(0,strX.Length-1)+"0";
			else if (strX.Substring(strX.Length-1,1).Equals("J"))
				strX="-"+strX.Substring(0,strX.Length-1)+"1";
			else if (strX.Substring(strX.Length-1,1).Equals("K"))
				strX="-"+strX.Substring(0,strX.Length-1)+"2";
			else if (strX.Substring(strX.Length-1,1).Equals("L"))
				strX="-"+strX.Substring(0,strX.Length-1)+"3";
			else if (strX.Substring(strX.Length-1,1).Equals("M"))
				strX="-"+strX.Substring(0,strX.Length-1)+"4";
			else if (strX.Substring(strX.Length-1,1).Equals("N"))
				strX="-"+strX.Substring(0,strX.Length-1)+"5";
			else if (strX.Substring(strX.Length-1,1).Equals("O"))
				strX="-"+strX.Substring(0,strX.Length-1)+"6";
			else if (strX.Substring(strX.Length-1,1).Equals("P"))
				strX="-"+strX.Substring(0,strX.Length-1)+"7";
			else if (strX.Substring(strX.Length-1,1).Equals("Q"))
				strX="-"+strX.Substring(0,strX.Length-1)+"8";
			else if (strX.Substring(strX.Length-1,1).Equals("R"))
				strX="-"+strX.Substring(0,strX.Length-1)+"9";

			return strX;
		}

		private string CovToEBCDIC(string strTemp,int dt_length)
		{
			string strX;
			double dblX;// = 0;
			if ((strTemp == null) || (strTemp == "")) return ""; // strTemp = "0";
			strX = GlobalTools.ConvertFloat(strTemp);
			//try 
			//{
				dblX = Convert.ToDouble(strTemp);
			/*} 
			catch 
			{
				string st = dt_id + "***" +strTemp.ToString() + "*** "+ strX.ToString();
				//GlobalTools.popMessage(this,st);
				conn.QueryString = "insert into tempCheck values ('" + st + "') ";
				conn.ExecuteNonQuery();
			}*/

			if (dt_length == 1 ){
				if (dblX > 9){  strX = "I"; return strX;  }
				if( dblX < -9 ) {  strX = "R"; return strX;  }
			}
			else if (dt_length == 2 )
			{
				if (dblX > 99){  strX = "9I"; return strX;  }
				if( dblX < -99 ) {  strX = "9R"; return strX;  }
			}
			else if (dt_length == 3 )
			{
				if (dblX > 999){  strX = "99I"; return strX;  }
				if( dblX < -999 ) {  strX = "99R"; return strX;  }
			}
			else if (dt_length == 4 )
			{
				if (dblX > 9999){  strX = "999I"; return strX;  }
				if( dblX < -9999 ) {  strX = "999R"; return strX;  }
			}
			else if (dt_length == 5 )
			{
				if (dblX > 99999){  strX = "9999I"; return strX;  }
				if( dblX < -99999 ) {  strX = "9999R"; return strX;  }
			}
			else if (dt_length == 6 )
			{
				if (dblX > 999999){  strX = "99999I"; return strX;  }
				if( dblX < -999999 ) {  strX = "99999R"; return strX;  }
			}
			else if (dt_length == 7 )
			{
				if (dblX > 9999999){  strX = "999999I"; return strX;  }
				if( dblX < -9999999 ) {  strX = "999999R"; return strX;  }
			}
			else if (dt_length == 8 )
			{
				if (dblX > 99999999){  strX = "9999999I"; return strX;  }
				if( dblX < -99999999 ) {  strX = "9999999R"; return strX;  }
			}



			if (dblX>=0)
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

		private string toSQLdecimal(double x)
		{
			string r = x.ToString();
			r = r.Replace(",",".");
			return r;
		}
	
		private string SignToConvertion(string str)
		{
			string retval = "";
			switch (str)
			{
				case "0": retval = "{";break;
				case "1": retval = "A";break;
				case "2": retval = "B";break;
				case "3": retval = "C";break;
				case "4": retval = "D";break;
				case "5": retval = "E";break;
				case "6": retval = "F";break;
				case "7": retval = "G";break;
				case "8": retval = "H";break;
				case "9": retval = "I";break;
				case "-0": retval = "}";break;
				case "-1": retval = "J";break;
				case "-2": retval = "K";break;
				case "-3": retval = "L";break;
				case "-4": retval = "M";break;
				case "-5": retval = "N";break;
				case "-6": retval = "O";break;
				case "-7": retval = "P";break;
				case "-8": retval = "Q";break;
				case "-9": retval = "R";break;
				default : break;
			}
			return retval;
		}

		private string FromSignConvertion(string str)
		{
			string retval = "";
			switch (str)
			{
				case "{": retval = "0";break;
				case "1": retval = "1";break;
				case "2": retval = "2";break;
				case "3": retval = "3";break;
				case "4": retval = "4";break;
				case "5": retval = "5";break;
				case "6": retval = "6";break;
				case "7": retval = "7";break;
				case "8": retval = "8";break;
				case "9": retval = "9";break;
				case "}": retval = "0";break;
				case "J": retval = "-1";break;
				case "K": retval = "-2";break;
				case "L": retval = "-3";break;
				case "M": retval = "-4";break;
				case "N": retval = "-5";break;
				case "O": retval = "-6";break;
				case "P": retval = "-7";break;
				case "Q": retval = "-8";break;
				case "R": retval = "-9";break;
				default: break;
			}
			return retval;
		}

		private string ToYesNoConvertion(string str)
		{
			string retval = "";
			switch (str)
			{
				case "1": retval = "Y";break;
				case "0": retval = "N";break;
				default: break;
			}
			return retval;
		}

		private string Multiply100(string str)
		{
			double num;string retval;
			try
			{
				num = (Convert.ToDouble(str.Trim())*100);
			} 
			catch 
			{
				num = 0;
			}
			retval = num.ToString("##,#0.00");
			return retval;
		}

		private string Devide100(string str)
		{
			double num;string retval;
			try
			{
				num = (Convert.ToDouble(str.Trim())/100);
			} 
			catch 
			{
				num = 0;
			}
			retval = num.ToString("##,#0.00");
			return retval;
		}

		/* mengembalikan representasi string dari karakter */
		private string CopyOfChar(char ch, int i)
		{
			if ( i < 1) return "";
			return new string(ch, i);
		}
		#endregion
		
		#region Other Functions/Procs
		private DataTable sqlQuery(string str)
		{
			conn.QueryString=str;
			conn.ExecuteQuery();
			return conn.GetDataTable().Copy();
		}
		private string GetFieldValue(DataTable dt, int idx, string col)
		{
			return dt.Rows[idx][col].ToString().Trim();
		}

		private string GetFieldValuecol(DataTable dt, int idx, int col)
		{
			return dt.Rows[idx][col].ToString().Trim();
		}

		private int GetRowCount(DataTable dt)
		{
			return dt.Rows.Count;
		}

		private int GetColCount(DataTable dt)
		{
			return dt.Columns.Count;
		}

		#endregion

		public void GenerateSendTextFile(string regno, string tc)
		{
			GenerateSendTextFile(regno, tc, "0");
		}

		public void GenerateSendTextFile(string regno, string tc, string ketcode)
		{
			/**
			 * Ambil data yang akan digenerate:
			 * 
			 * */
			//create,send,and get textfile;
			//translate the data before save!...
			/**/
			// hapus data rating terdahulu dari user ybs
			//			conn.QueryString  = "delete from SCOREBCG_TEXT_MESSAGE where ";
			//			conn.QueryString += "CU_REF = '" + Request.QueryString["curef"] + "'";
			//			conn.ExecuteNonQuery();

			ds1 = sqlQuery("select * from RFGRFILE where GRFILE_TYPE='3'");			
			for (int i = 0;i < GetRowCount(ds1);i++)
			{
				string lvgr_id		= GetFieldValue(ds1,i,"GRFILE_ID");
				string lvpath		= GetFieldValue(ds1,i,"GRFILE_DIR");
				string lvfilename	= GetFieldValue(ds1,i,"GRFILE_NAME");				
				string lvfile		= GetFieldValue(ds1,i,"GRFILE_FILENAME");
				string lvheader		= GetFieldValue(ds1,i,"GRFILE_HEADER");
				string lvfooter		= GetFieldValue(ds1,i,"GRFILE_FOOTER");
				string lv_create	= GetFieldValue(ds1,i,"GRFILE_CREATE");
				string lvtabel		= GetFieldValue(ds1,i,"GRFILE_TABLECOND");					
				string lvfield		= ambilKondisi(tc);

				int jmlrec = 0;
				Create_teksfile(regno,lvgr_id,lvpath,lvfile,lvheader,lvfooter,lvtabel,lvfield,lv_create,ref jmlrec,ketcode);
			}
		}

		private string ambilKondisi(string tc)
		{
			string noTrack = "'"+ tc+"'";
			conn.QueryString = "select * from RFGRFILE where GRFILE_CREATE = '1' and GRFILE_TYPE='3'";
			conn.ExecuteQuery();
			string lvfield		= conn.GetFieldValue("GRFILE_FIELDCOND");				
			string templvfield	= lvfield;
			int lenindex		= templvfield.IndexOf("#",1); //cari #
			bool cek = true;
			if (lenindex > 0)
			{	 				
				if ((noTrack.Trim() != "")&& (noTrack.Trim() != "''"))
				{
					templvfield = lvfield.Substring(0,lenindex-1);					
					int lentanda = lvfield.IndexOf("$",0);					
					lvfield = templvfield +  noTrack + lvfield.Substring(lentanda+1);					
				}
				else
				{
					cek = false;
				}
			}
			return lvfield; // mengembalikan kondisi dalam bentuk seperti: (ap_currtrack = '1.1.1')
		}

		private void Create_teksfile(string regno, string gr_id, string strPath,string strfilename,string strheader,string strfooter,string strtable,string strfield,string strcreate,ref int jmlcount,string ketcode)
		{
			string selectsqlteks = "select "; 
			string formsqlteks = "from "; 
			string wheresqlteks = "where "; 
			string temptable = "";
			string tempfield = "";
			string teksdata = "";
			
			DateTime dt = new DateTime();
			int indextable = 0;
			int j;
			int k;
			int jmli = 0;
			
			////////////////////////////
			/// mengambil CU_REF
			/// 
			DataTable dtTemp = sqlQuery("select CU_REF from APPLICATION where AP_REGNO = '" + regno + "'");			
			string curef = dtTemp.Rows[0]["CU_REF"].ToString();
		
			ds2 = sqlQuery("select * from RFDTFILE where GRFILE_ID = '"+ gr_id +"'");

			for (int i = 0;i < ds2.Rows.Count ;i++)
			{								
				if (ds2.Rows[i]["DTFILE_KEYFORMULA"].ToString().Trim() == "")
				{
					k = 0;
					j = 0;
					while (GetFieldValue(ds2,i,"DTFILE_FIELDPARAMKEY").IndexOf(",",k) > 0 )
					{						
						indextable = GetFieldValue(ds2,i,"DTFILE_FIELDPARAMKEY").IndexOf(",",k);
						indextable = indextable - k;
						tempfield = GetFieldValue(ds2,i,"DTFILE_FIELDPARAMKEY").Substring(k,indextable);
						k = k + indextable + 1;
						if (GetFieldValue(ds2,i,"DTFILE_KEYTABLE").IndexOf(",",j) > 0 )
						{
							indextable = GetFieldValue(ds2,i,"DTFILE_KEYTABLE").IndexOf(",",j);
							indextable = indextable - j;
							temptable = GetFieldValue(ds2,i,"DTFILE_KEYTABLE").Substring(j,indextable);
							j = j + indextable + 1;
						}						
						if (selectsqlteks == "select ")
						{
							selectsqlteks = selectsqlteks + temptable+"."+tempfield;
						}				
						else
						{
							selectsqlteks = selectsqlteks +","+ temptable+"."+tempfield;
						}
					}
				}
				else
				{

					if (selectsqlteks == "select ")
					{
						selectsqlteks = selectsqlteks + GetFieldValue(ds2,i,"DTFILE_KEYFORMULA");
					}
					else
					{
						selectsqlteks = selectsqlteks +" , "+ GetFieldValue(ds2,i,"DTFILE_KEYFORMULA");
					}
				}		
	
				//create from query
				j = 0;
				k = 0;
				if (GetFieldValue(ds2,i,"DTFILE_KEYTABLE").IndexOf(",",j) > 0 )
				{
					if (GetFieldValue(ds2,i,"DTFILE_LINKKEY").Trim() == "")
					{						
					}
					else
					{						
						j = 0;
						while (GetFieldValue(ds2,i,"DTFILE_KEYTABLE").IndexOf(",",j) > 0 )
						{							
							indextable = GetFieldValue(ds2,i,"DTFILE_KEYTABLE").IndexOf(",",j);
							indextable = indextable - j;
							temptable = GetFieldValue(ds2,i,"DTFILE_KEYTABLE").Substring(j,indextable);
							j = j + indextable + 1;
							if (formsqlteks.IndexOf(temptable,0) <= 0)
							{								
								if (formsqlteks == "from ")
								{
									formsqlteks = formsqlteks + temptable;
								}						
								else
								{
									formsqlteks = formsqlteks + "," + temptable;
								}
							}	
						}						
					}										
				}
				else
				{
					temptable = GetFieldValue(ds2,i,"DTFILE_KEYTABLE");
					if (formsqlteks.IndexOf(temptable,0) <= 0)
					{
						if (formsqlteks == "from ")
						{
							formsqlteks = formsqlteks + temptable;
						}						
						else
						{
							formsqlteks = formsqlteks + "," + temptable;
						}
					}					
				}

				//create where query
				j = 0;
				k = 0;
				if (GetFieldValue(ds2,i,"DTFILE_LINKKEY").Trim() != "")
				{
					if (wheresqlteks == "where ")
					{
						wheresqlteks = wheresqlteks + GetFieldValue(ds2,i,"DTFILE_LINKKEY");
					}
					else
					{
						if (wheresqlteks.IndexOf(GetFieldValue(ds2,i,"DTFILE_LINKKEY"),0) <= 0 )
						{
							wheresqlteks = wheresqlteks + " and " + GetFieldValue(ds2,i,"DTFILE_LINKKEY");
						}
					}
				}
			}
			
			formsqlteks = formsqlteks + "," + strtable;					
			wheresqlteks = wheresqlteks +" and "+ strfield;
			wheresqlteks = wheresqlteks +" and  SCOREBCG_INPUT.AP_REGNO = '" + regno + "'";
			
			// mengambil data dari dbase berdasarkan ketentuan di rfdtfile
			selectsqlteks = selectsqlteks +" "+ formsqlteks +" "+ wheresqlteks;
			
			bool mandatori_result = true;						
			try 
			{
				ds3 = sqlQuery( selectsqlteks );
			} 
			catch { }																
			
			string strFileText=""; 
			SME.Scoring.clsDSSHeader objDSSHeader = new SME.Scoring.clsDSSHeader(conn, regno, curef);
			
			if (mandatori_result)
			{
				if (GetRowCount(ds3) > 0	)
				{				
					for (int i = 0;i < GetRowCount(ds3);i++)
					{				
						for (k = 0;k < GetColCount(ds3);k++)
						{
							string dt_type		= GetFieldValue(ds2,k,"DTFILE_ATTRIBUTE");
							string dt_id		= GetFieldValue(ds2,k,"DTFILE_ID");
							int dt_length		= Convert.ToInt32(GetFieldValue(ds2,k,"DTFILE_LENGTH"));
							int dt_dec			= Convert.ToInt32(GetFieldValue(ds2,k,"DTFILE_DEC"));
							string dt_format	= GetFieldValue(ds2,k,"DTFILE_FORMAT");
							string dt_mandatory = GetFieldValue(ds2,k,"DTFILE_MANDATORY");
							
							teksdata = GetFieldValuecol(ds3,i,k);
							//if (dt_type != "X") teksdata = GetFieldValuecol(ds3,i,k);

							if (dt_type == "X")
							{ // jika tipe data = X maka itu space filler, isi spasi sebanyak dt_length
								teksdata = CopyOfChar(' ', dt_length-teksdata.Length) + teksdata;
								strFileText += teksdata;
							} 
							else if (dt_type == "C")
							{ // perlakuan terhadap character alias A(lphanumeric)
								if (teksdata.Length >= dt_length)
								{ // jika panjang data berlebih, ambil sepanjang max pjng data yg dibutuhkan
									teksdata = teksdata.Substring(0,dt_length);
								} 
								else
								{ // jika kurang dari max pjng data, isi previous dengan spasi
									teksdata = CopyOfChar(' ', dt_length - teksdata.Length) + teksdata;
								}
								//strFileText = strFileText + teksdata;
								strFileText = strFileText + teksdata;
							}

							else if (dt_type == "B")
							{ // perlakuan terhadap tipe B(oolean)
								if (teksdata == "1") teksdata = "Y";
								else teksdata = "N"; 
								//strFileText = strFileText + teksdata;
								strFileText = strFileText + teksdata;
							}

							else if (dt_type == "N")
							{ // perlakuan untuk Numeric yang diganti 
								double appValue = 0;
								try
								{
									appValue =  Convert.ToDouble(teksdata);	
								}
								catch {}

								int SendValue = Convert.ToInt32(Math.Round(appValue));

								string tempStr = Convert.ToString(SendValue);
								//teksdata = CopyOfChar('0',dt_length - tempStr.Length) + tempStr;
								string inEBCDIC	 = CovToEBCDIC(tempStr,dt_length);
								teksdata = CopyOfChar('0',dt_length - inEBCDIC.Length) + inEBCDIC;
								/*
								if (teksdata.Length >= dt_length)
								{
									if (teksdata.Substring(0,1) == "-" && teksdata.Length > dt_length)
									{
										teksdata = "-" + teksdata.Substring(1,dt_length);
									} 
									else teksdata = teksdata.Substring(0,dt_length);

									if (teksdata.IndexOf(".",0) > 0 )
									{
										string fdepan	 = teksdata.Substring(0,teksdata.IndexOf(".",0));
										string fbelakang = teksdata.Substring(teksdata.IndexOf(".",0) + 1, teksdata.Length-(teksdata.IndexOf(".",0)+1));
										string inEBCDIC	 = CovToEBCDIC( fdepan,dt_length);
										teksdata = CopyOfChar('0',dt_length - inEBCDIC.Length) + inEBCDIC + fbelakang + CopyOfChar('0',dt_dec - fbelakang.Length);
									}
									else
									{//edited!!
										//try
										//{
										string inEBCDIC	 = CovToEBCDIC( teksdata,dt_length );
										/*}
										catch 
										{
											string st = "Ada error :" + strTemp.ToString() + "*** "+ strX.ToString();
											//GlobalTools.popMessage(this,st);
											conn.QueryString = "insert into tempCheck values ('" + st + "') ";
											conn.ExecuteNonQuery();
			
										}*//*
										teksdata = CopyOfChar('0',dt_length - inEBCDIC.Length) + inEBCDIC;
									}
								}
								else
								{														
									dt_length = dt_length - dt_dec;
									if (teksdata.IndexOf(".",0) > 0 )
									{
										string fdepan = teksdata.Substring(0,teksdata.IndexOf(".",0));
										string fbelakang = teksdata.Substring(teksdata.IndexOf(".",0)+1,teksdata.Length-(teksdata.IndexOf(".",0)+1));
										string inEBCDIC	 = CovToEBCDIC( fdepan,dt_length );
										teksdata = CopyOfChar('0',dt_length - inEBCDIC.Length) + inEBCDIC + fbelakang + CopyOfChar('0',dt_dec - fbelakang.Length);
									}
									else
									{
										string inEBCDIC	 = CovToEBCDIC( teksdata,dt_length );
										teksdata = CopyOfChar('0',dt_length - inEBCDIC.Length) + inEBCDIC + CopyOfChar('0',dt_dec);
								
									}											
								}
								*/
								strFileText = strFileText + teksdata;
							}

							else if (dt_type == "U")
							{
								double appValue = 0;
								try
								{
									appValue =  Convert.ToDouble(teksdata);	
								}
								catch {}

								int SendValue = Convert.ToInt32(Math.Round(appValue));

								if (Convert.ToString(SendValue).Length > dt_length)
									teksdata = new string('9', dt_length);
								else
								{
									string tempStr = Convert.ToString(SendValue);
									teksdata = CopyOfChar('0',dt_length - tempStr.Length) + tempStr;
								}
								/*
								if (teksdata.Length >= dt_length)
								{
									if (teksdata.Substring(0,1) == "-")
									{
										teksdata = "-" + teksdata.Substring(1,dt_length);
									} 
									else teksdata = teksdata.Substring(0,dt_length);

									if (teksdata.IndexOf(".",0) > 0 )
									{
										string fdepan = teksdata.Substring(0,teksdata.IndexOf(".",0));
										string fbelakang = teksdata.Substring(teksdata.IndexOf(".",0)+1,teksdata.Length-(teksdata.IndexOf(".",0)+1));
										teksdata = CopyOfChar('0',dt_length - fdepan.Length) + fdepan + fbelakang + CopyOfChar('0',dt_dec - fbelakang.Length);
									}
									else
									{
										teksdata = CopyOfChar('0',dt_length - teksdata.Length) + teksdata;
									}
								}
								else
								{			
									dt_length = dt_length - dt_dec;
									if (teksdata.IndexOf(".",0) > 0 )
									{
										string fdepan = teksdata.Substring(0,teksdata.IndexOf(".",0));
										string fbelakang = teksdata.Substring(teksdata.IndexOf(".",0)+1,teksdata.Length-(teksdata.IndexOf(".",0)+1));
										teksdata = CopyOfChar('0',dt_length - fdepan.Length)+fdepan+fbelakang+CopyOfChar('0',dt_dec - fbelakang.Length);								
									}
									else
									{
										teksdata = CopyOfChar('0',dt_length - teksdata.Length) + teksdata + CopyOfChar('0',dt_dec);
									}											
								}
								*/
								strFileText = strFileText + teksdata;
							}
						}
						//--ashari--FileTemp.WriteLine();
						jmli = i;
						if (strFileText.Trim()!="")
						{
							//							conn.QueryString  = "insert into SCOREBCG_TEXT_MESSAGE(CU_REF, TEXT_MESSAGE) values ";
							//							conn.QueryString += "('" + Request.QueryString["curef"] + "', '" + strFileText + "')";
							// hapus data lama jika ada
							conn.QueryString  = "delete from SCORING_MESSAGE where AP_REGNO='" + regno + "' ";
							if(ketcode == "0")
								conn.QueryString += " and SUMBERDATA = 'RATINGCUSTOMER'";
							else
								conn.QueryString += " and SUMBERDATA = 'RATINGFACILITY'";
							conn.ExecuteNonQuery();

							// perbarui SCORING_MESSAGE
							// untuk rating customer, input key yang digunakan adalah CUREF 
							string aaa = "";
							if (ketcode == "0")
								aaa = objDSSHeader.addDSSHeader("C");
							else
								aaa = objDSSHeader.addDSSHeader("F");

							conn.QueryString  = "insert into SCORING_MESSAGE(AP_REGNO, MESSAGE, SUMBERDATA, SENT) values ";
							conn.QueryString += "('" + regno + "', ";
							conn.QueryString += "'" + aaa + createHeader(regno) ;
							conn.QueryString += strFileText + "', ";
							if(ketcode == "0")
								conn.QueryString += "'RATINGCUSTOMER', '0')";
							else
								conn.QueryString += "'RATINGFACILITY', '0')";
							conn.ExecuteNonQuery();

						}
						strFileText="";
					}	
					jmli = jmli + 1;
				}
			
				jmlcount = jmli;	
			}
			CreateTextFile(regno, ketcode); // cuba tulis ke file
		}

		
		/***************************************************
		 * membuat textfile dari queue -- tidak digunakan  *
		 ***************************************************/
		private void CreateTextFile(string regno, string ketcode)
		{
			if(ketcode == "0")
				conn.QueryString  = "select * from SCORING_MESSAGE where AP_REGNO = '" + regno + "' " +
					"and SUMBERDATA = 'RATINGCUSTOMER'"; //SCOREBCG_TEXT_MESSAGE";
			else
				conn.QueryString  = "select * from SCORING_MESSAGE where AP_REGNO = '" + regno + "' " +
					"and SUMBERDATA = 'RATINGFACILITY'"; //SCOREBCG_TEXT_MESSAGE";

			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
			{
				StreamWriter fileTemp;							
				fileTemp = File.CreateText(@"C:\Inetpub\ftproot\LCUCRATING");
				//fileTemp.WriteLine(createHeader(Request.QueryString["curef"]));
				for(int i=0;i<conn.GetRowCount();i++)
				{
					fileTemp.Write(conn.GetFieldValue(i,1));
					fileTemp.WriteLine();
				}
				int x = conn.GetRowCount();
				string hasil;
				string s = x.ToString();
				hasil	 = s;
				for (int i = 0; i < 4 - s.Length; i++) hasil = "0" + hasil;
				fileTemp.Write(hasil);
				fileTemp.Close();
			}
			//conn.QueryString = "delete from SCOREBCG_TEXT_MESSAGE";
		}

		
		/*************************************************************
		 *  membuat header sebagai bagian dari message yang dikirim  *
		 *************************************************************/
		private string createHeader(string inputKey)
		{
			string retval = "";
			DateTime dt  = DateTime.Now;
						
			retval += "BM3"; // INP-SYSTEM-ID
			retval += "9999"; // INP-KEY-GRP-VAL
			retval += CopyOfChar('0', 20 - inputKey.Length) + inputKey; //INP-KEY-INQY-ID
			retval += "01"; // INP-REL-CB-NBR
			retval += "0000"; // INP-SPID
			retval += "01"; // INP-FUNCTION
			retval += "00"; // INP-SAMP-DIGITS
			retval += "N"; // INP-DIGITS-ASSIGNED-IND
			retval += CopyOfChar(' ', 20); // INP-BUS-UNIT
			retval += dt.ToString("yyyyMMdd"); // INP-DATE-PROCESSED
			retval += dt.ToString("HHmmsshh"); // INP-TIME-PROCESSED
			retval += CopyOfChar(' ', 8); // INP-SOURCE-CD
			retval += "20"; // INP-NBR-RTRN-RULE-SETS
			retval += "20"; // INP-NBR-RTRN-DECSN-SCEN
			retval += "20"; // INP-NBR-RTRN-PRICING-SCEN
			retval += "20"; // INP-NBR-RTRN-SCORING-SCEN
			retval += "01701"; // INP-RTRN-ATTR-START
			retval += "00400"; // INP-RTRN-ATTR-LENGTH
			retval += CopyOfChar(' ', 1179); // filler other field; 1179 adalah panjang other field
			retval += "02100"; // INP-ATTR-AREA-LENGTH				

			return retval;
		}

		
		/******************************************************
		 *  translate response message and display on screen  *
		 * ****************************************************/
		public bool UploadResponse(System.Web.UI.Page page, string regno, string curef)
		{
			return UploadResponse(page, regno, curef, "0");
		}

		public bool UploadResponse(System.Web.UI.Page page, string regno, string curef, string ketcode)
		{
			bool status = false;
			string strHasil;
			string strRegno = regno;	
			
			// menunggu respon server
			System.Threading.Thread.Sleep(2900); // waiting for 2.7 seconds

			conn.QueryString  = "select * from SCORING_RESPONSE where received = '0' ";
			conn.QueryString += "and AP_REGNO like '%"+ strRegno +"%'";
			//conn.QueryString += "and SUMBERDATA = 'RATINGCUSTOMER' ";
			//conn.QueryString += "and AP_REGNO like '%"+ strRegno +"%'";
			conn.ExecuteQuery();
			if (conn.GetRowCount()==0)
			{
				// tunggu 5 seconds, TO DO
				GlobalTools.popMessage(page,"Response dari Strategy Ware belum diterima. Tunggu beberapa detik lagi.");
				return status;
			}

			status = true; // response diterima

			strHasil = conn.GetFieldValue("msgresponse");
			string strDate, strTime, strOrs, strOst, strOsc, strOpr, strFACOHD, OHD_SYS_DECISION;
			int startCalcPos, Pos, lenFACOSC, intFACOSC;

			if (strHasil.Trim().Length == 0)
			{
				GlobalTools.popMessage(page,"Hasil response kosong.");
				return false;
			}

			
			//strRegno=strHasil.Substring(10,20);
			strDate	= strHasil.Substring(61,8);
			strTime	= strHasil.Substring(69,8);
			//			Response.Write("Date: " + strDate + "\n Time: "+strTime);
			
			strOrs	= strHasil.Substring(85,2); //OHD-NBR-RTRN-RULE-SETS * 63
			strOst	= strHasil.Substring(87,2); // OHD-NBR-RTRN-DECSN-SCEN * 117 
			strOpr	= strHasil.Substring(89,2); // OHD-NBR-RTRN-PRICING-SCEN * 202
			strOsc	= strHasil.Substring(91,2); //	OHD-NBR-RTRN-SCORING-SCEN * 691
			//			Response.Write(strOpr + " " + strOrs + " " + strOsc + " " + strOst);

			
			// posisi awalCOAT
			startCalcPos  = 1922 + (int.Parse(strOrs)*63) + (int.Parse(strOst)*117);
			startCalcPos += (int.Parse(strOsc)*691) + (int.Parse(strOpr)*202) ;
			//			Response.Write("Data Start Pos: "+ startCalcPos + "\n");

			intFACOSC    = 1922 + (int.Parse(strOrs)*63) + (int.Parse(strOst)*117);
			lenFACOSC    = (int.Parse(strOsc)*691);

			// Cek Error Code yang dikirim oleh STW
			// Blank 5 char : sukses
			strFACOHD    = strHasil.Substring(0,1921); // FIACOHD
			string strErrorCode = strFACOHD.Substring(1579,5);
			if (strErrorCode.Trim()!="")
			{
				conn.QueryString = "select * from RF_STW_LOS_ERROR where ERROR_CODE='"+ strErrorCode.Trim() +"'";
				conn.ExecuteQuery();
				if (conn.GetRowCount()!=0)
					GlobalTools.popMessage(page, "Error code from STW: - " + conn.GetFieldValue(0,1).ToString());
				else
					GlobalTools.popMessage(page, "Error code from STW: - Undefined error has been occured");
				status = false;
			}

			// -- Kalau Ada Error Code dari FairIsaac
			//    Non Aktif Tombol Update Status dan Print 
			/*if (blSuccess)
			{
				btnRate.Enabled = true;
				btnUpdateStatus.Enabled = true;
			} 
			else
			{
				btnRate.Enabled = true; //false;
				btnUpdateStatus.Enabled = false;
			}*/
			

			//			// Overal Strategy Ware Decision
			OHD_SYS_DECISION = strHasil.Substring(258,2);             // 259 - 260 ( 2 char)
			string OHD_RULE_REASON_CODE = strHasil.Substring(297,40); // 298 - 337 ( 40 char)
		
			Pos = startCalcPos;
			//			Response.Write("Data Start Pos: "+ Pos + "\n");

			string FIACOAT = "";
			try
			{
				// note: spasi di belakang digunakan untuk mencegah error pada saat pengambilan
				// substring data terakhir
				FIACOAT = strHasil.Substring(Pos,strHasil.Length-Pos) + "                    ";
			}
			catch{};
			//			Response.Write("Data Length: " + FIACOAT.Length + "\n");
			//			Response.Write(FIACOAT + "\n");

			if(status)
			{//record result only if no error
				string G0001 = "";			string G0002 = "";			string G0003 = "";
				string G0004 = "";			string G0005 = "";			string G0006 = "";
				string G0007 = "";			string G0008 = "";			string G0009 = "";
				string G0010 = "";			string G0011 = "";			string G0012 = "";
				string G0013 = "";			string G0014 = "";			string G0015 = "";
				string G0016 = "";			string G0017 = "";			string G0018 = "";
				string G0019 = "";			string G0020 = "";			string G0021 = "";
				string G0022 = "";			string G0023 = "";			string G0024 = "";
				string G0025 = "";			string G0026 = "";			string G0027 = "";
				string G0028 = "";			string G0029 = "";			string G0030 = "";
				string G0031 = "";			string A0601 = "";			string A0602 = "";
				string A0603 = "";			string A0701 = "";			string A0801 = "";
				string A0802 = "";			string A0901 = "";			string A1001 = "";
				string A1002 = "";			string A1003 = "";			string A1012 = "";
				string A1004 = "";			string A1011 = "";			string A1013 = "";

				try
				{
					int intPos = 8;
					//G0001	Operating CF to Debt Score	9	15	7
					G0001 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7) ) );
					intPos = intPos + 7;
					if ((G0001 == "") || (G0001 == null)) G0001 = "0";
					//				Response.Write(CovFromEBCDIC(G0001) + "\n");

					//G0002	Current Ratio Score	16	22	7
					G0002 = CovFromEBCDIC( trimZero (FIACOAT.Substring(intPos,7)));
					intPos = intPos + 7;
					if ((G0002 == "") || (G0002 == null)) G0002 = "0";
					//				Response.Write(CovFromEBCDIC(G0002) + "\n");
				
					//G0003	Debt to Equity Score	23	29	7
					G0003 = CovFromEBCDIC(trimZero( FIACOAT.Substring(intPos,7) ));
					intPos = intPos + 7;
					if ((G0003 == "") || (G0003 == null)) G0003 = "0";
					//				Response.Write(CovFromEBCDIC(G0003) + "\n");
				
					//G0004	Debt to Assets Score	30	36	7
					G0004 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7)) );
					intPos = intPos + 7;
					if ((G0004 == "") || (G0004 == null)) G0004 = "0";
					//				Response.Write(CovFromEBCDIC(G0004) + "\n");
				
					//G0005	EBITDA to Interest Expense Score	37	43	7
					G0005 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7) ) );
					intPos = intPos + 7;
					if ((G0005 == "") || (G0005 == null)) G0005 = "0";
					//				Response.Write(CovFromEBCDIC(G0005) + "\n");
				
					//G0006	Return on Average Equity Score	44	50	7
					G0006 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7) ) );
					intPos = intPos + 7;
					if ((G0006 == "") || (G0006 == null)) G0006 = "0";
					//				Response.Write(CovFromEBCDIC(G0006) + "\n");
				
					//G0007	Net Margin Score	51	57	7
					G0007 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7)) );
					intPos = intPos + 7;
					if ((G0007 == "") || (G0007 == null)) G0007 = "0";
					//				Response.Write(CovFromEBCDIC(G0007) + "\n");
				
					//G0008	Assets Turn over Score	58	64	7
					G0008 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7)) );
					intPos = intPos + 7;
					if ((G0008 == "") || (G0008 == null)) G0008 = "0";
					//				Response.Write(CovFromEBCDIC(G0008) + "\n");
				
					//G0009	Inventory Turn over Score	65	71	7
					G0009 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7)) );
					intPos = intPos + 7;
					if ((G0009 == "") || (G0009 == null)) G0009 = "0";
					//				Response.Write(CovFromEBCDIC(G0009) + "\n");
				
					//G0010	EBITDA Growth Score	72	78	7
					G0010 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7) ) );
					intPos = intPos + 7;
					if ((G0010 == "") || (G0010 == null)) G0010 = "0";
					//				Response.Write(CovFromEBCDIC(G0010) + "\n");
				
					//G0011	Net Income Growth Score	79	85	7
					G0011 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7) ) );
					intPos = intPos + 7;
					if ((G0011 == "") || (G0011 == null)) G0011 = "0";
					//				Response.Write(CovFromEBCDIC(G0011) + "\n");

					//G0012	Quick Ratio Score	86	92	7
					G0012 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7) ) );
					intPos = intPos + 7;
					if ((G0012 == "") || (G0012 == null)) G0012 = "0";
					//				Response.Write(CovFromEBCDIC(G0012) + "\n");

					//G0013	Debt to Capital Score	93	99	7
					G0013 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7) ) );
					intPos = intPos + 7;
					if ((G0013 == "") || (G0013 == null)) G0013 = "0";
					//				Response.Write(CovFromEBCDIC(G0013) + "\n");

					//G0014	Long Term Debt to Equity Score	100	106	7
					G0014 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7) ) );
					intPos = intPos + 7;
					if ((G0014 == "") || (G0014== null)) G0014 = "0";
					//				Response.Write(CovFromEBCDIC(G0014) + "\n");

					//G0015	EBITDA to Debt Score	107	113	7
					G0015 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7) ) );
					intPos = intPos + 7;
					if ((G0015 == "") || (G0015 == null)) G0015 = "0";
					//				Response.Write(CovFromEBCDIC(G0015) + "\n");

					//G0016	EBITDA to Liabilities Score	114	120	7
					G0016 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7) ) );
					intPos = intPos + 7;
					if ((G0016 == "") || (G0016 == null)) G0016 = "0";
					//				Response.Write(CovFromEBCDIC(G0016) + "\n");

					//G0017	Recivables Turn over Score	121	127	7
					G0017 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7) ) );
					intPos = intPos + 7;
					if ((G0017 == "") || (G0017 == null)) G0017 = "0";
					//				Response.Write(CovFromEBCDIC(G0017) + "\n");

					//G0018	Fixed Assets Turn over Score	128	134	7
					G0018 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7) ) );
					intPos = intPos + 7;
					if ((G0018 == "") || (G0018 == null)) G0018 = "0";
					double x = Convert.ToDouble(G0018);
					string y = toSQLdecimal(x);
					//				Response.Write(CovFromEBCDIC(G0018) + "\n");

					//G0019	Operating Margin Score	135	141	7
					G0019 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7) ) );
					intPos = intPos + 7;
					if ((G0019 == "") || (G0019 == null)) G0019 = "0";
					//				Response.Write(CovFromEBCDIC(G0019) + "\n");

					//G0020	Sales Growth Score	142	148	7
					G0020 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7) ) );
					intPos = intPos + 7;
					if ((G0020 == "") || (G0020 == null)) G0020 = "0";
					//				Response.Write(CovFromEBCDIC(G0020) + "\n");

					//G0021	Return on Average Assets Score	149	155	7
					G0021 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7) ) );
					intPos = intPos + 7;
					if ((G0021 == "") || (G0021 == null)) G0021 = "0";
					//				Response.Write(CovFromEBCDIC(G0021) + "\n");

					//G0022	Operating CF to Interest Expense Score	156	162	7
					G0022 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7) ) );
					intPos = intPos + 7;
					if ((G0022 == "") || (G0022 == null)) G0022 = "0";
					//				Response.Write(CovFromEBCDIC(G0022) + "\n");

					//G0023	Financial Raw Score - Total (x100000)	163	169	7
					G0023 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7) ) );
					intPos = intPos + 7;
					if ((G0023 == "") || (G0023 == null)) G0023 = "0";
					//				Response.Write(CovFromEBCDIC(G0023) + "\n");

					//G0024	Financial Score 	170	172	3
					G0024 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,3) ) );
					intPos = intPos + 3;
					if ((G0024 == "") || (G0024 == null)) G0024 = "0";
					//				Response.Write(CovFromEBCDIC(G0024) + "\n");

					//G0025	Total Management Quality Score	173	173	1
					G0025 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,1) ) );
					intPos = intPos + 1;
					//				Response.Write(CovFromEBCDIC(G0025) + "\n");

					//G0026	Total Business Outlook Score	174	174	1
					G0026 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,1) ) );
					intPos = intPos + 1;
					//				Response.Write(CovFromEBCDIC(G0026) + "\n");

					//G0027	Qualitative Score	175	175	1
					G0027 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,1) ) );
					intPos = intPos + 1;
					//				Response.Write(CovFromEBCDIC(G0027) + "\n");

					//G0028	Coll.coverage (% dan x100)	176	182	7
					G0028 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7) ) );
					intPos = intPos + 7;
					if ((G0028 == "") || (G0028 == null)) G0028 = "0";
					//				Response.Write(CovFromEBCDIC(G0028) + "%\n");

					//G0029	LGD (% dan x100)	183	189	7
					G0029 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7) ) );
					intPos = intPos + 7;
					if ((G0029 == "") || (G0029 == null)) G0029 = "0";
					//				Response.Write(CovFromEBCDIC(G0029) + "\n");

					//G0030	EL (% dan x100)	190	196	7
					G0030 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,7) ) );
					intPos = intPos + 7;
					if ((G0030 == "") || (G0030 == null)) G0030 = "0";
					//				Response.Write(CovFromEBCDIC(G0030) + "\n");

					//G0031	Customer Rating	197	198	2
					G0031 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,2) ) );
					intPos = intPos + 2;
					//				Response.Write(CovFromEBCDIC(G0031) + "\n");

					//Filler	199	308	110
					intPos += 110;

					//A0601	Total Score Range-Financial	309	316	8
					//A0601 = trimZero( FIACOAT.Substring(intPos,8) );
					A0601 = this.trimZeroRangeData( FIACOAT.Substring(intPos,8) );
					intPos = intPos + 8;

					//A0602	Risk Class-Financial	317	319	3
					A0602 = trimZero( FIACOAT.Substring(intPos,3) );
					intPos = intPos + 3;
					//				Response.Write(CovFromEBCDIC(A0602) + "RCF\n");

					//A0603	PD Range-Financial	320	327	8
					//A0603 = trimZero( FIACOAT.Substring(intPos,8) );
					A0603 = this.trimZeroRangeData( FIACOAT.Substring(intPos,8) );
					intPos = intPos + 8;
					//				Response.Write(CovFromEBCDIC(A0603) + "\n");

					//Filler	328	328	1
					intPos = intPos + 1;

					//A0701	PH Recommendation	329	330	2
					A0701 = CovFromEBCDIC (trimZero( FIACOAT.Substring(intPos,2) ));
					intPos = intPos + 2;
					//				Response.Write(CovFromEBCDIC(A0701) + "PHR\n");

					//Filler	331	338	8
					intPos += 8;

					//A0801	Industrial Score	339	339	1
					A0801 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,1) ) );
					intPos = intPos + 1;

					//A0802	Industrial Recommendation	340	340	1
					A0802 = trimZero( FIACOAT.Substring(intPos,1) );
					intPos = intPos + 1;

					//Filler	341	348	8
					intPos += 8;

					//A0901	Qualitative Recommendation	349	349	1
					A0901 = trimZero( FIACOAT.Substring(intPos,1) );
					intPos = intPos + 1;

					//Filler	350	358	9
					intPos += 9;

					//A1001	Total Adjustment	359	360	2
					A1001 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,2) ) );
					intPos = intPos + 2;

					//A1002	Pre-Customer Risk Class	361	363	3
					A1002 = trimZero( FIACOAT.Substring(intPos,3) );
					intPos = intPos + 3;

					//A1003	Final Customer Risk Class	364	366	3
					//A1003 = trimZero( FIACOAT.Substring(intPos,3) );
					A1003 = this.trimZeroRangeData( FIACOAT.Substring(intPos,3) );
					intPos = intPos + 3;

					//A1004	PD Range-Customer	367	374	8
					//A1004 = trimZero( FIACOAT.Substring(intPos,8) );
					A1004 = FIACOAT.Substring(intPos,8);
					intPos = intPos + 8;

					//Filler	375	378	4
					intPos = intPos + 4;

					//A1011	Average  PD (% dan x100)	379	383	5
					A1011 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,5) ) );
					intPos = intPos + 5;
					if ((A1011 == "") || (A1011 == null)) A1011 = "0";

					//A1012	EAD 	384	388	5
					A1012 = CovFromEBCDIC( trimZero( FIACOAT.Substring(intPos,5) ) );
					intPos = intPos + 5;
					if ((A1012 == "") || (A1012 == null)) A1012 = "0";

					//A1013	Risk Class - Facility	389	391	3
					A1013 = trimZero( FIACOAT.Substring(intPos,3) );
					intPos = intPos + 3;
				} 
				catch{};

				// masukkan data hasil upload ke database 
				string sketcode = "NULL";
				if (ketcode != "0")
					sketcode = "'" + ketcode + "'";
				conn.QueryString  = "exec SCOREBCG_RESULT_SAVE '" + 
					regno + "','" + 
					curef + "'," +
					sketcode + "," + 
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0001)) + "," + 
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0002)) + "," + //5
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0003)) + "," +
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0004)) + "," + 
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0005)) + "," + 
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0006)) + "," + 
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0007)) + "," + //10
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0008)) + "," + 
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0009)) + "," + 
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0010)) + "," + 
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0011)) + "," + 
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0012)) + "," + //15
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0013)) + "," + 
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0014)) + "," + 
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0015)) + "," + 
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0016)) + "," + 
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0017)) + "," + //20
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0018)) + "," + 
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0019)) + "," + 
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0020)) + "," + 
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0021)) + "," + 
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0022)) + "," + //25
					GlobalTools.ConvertFloat(strFromDoublePer100000(G0023)) + "," + 
					GlobalTools.ConvertFloat(strFromDouble(G0024)) + ",'" + 
					G0025 + "','" + 
					G0026 + "','" + 
					G0027 + "'," + //30
					GlobalTools.ConvertFloat(strFromDoublePer100(G0028)) + "," + 
					GlobalTools.ConvertFloat(strFromDoublePer100(G0029)) + "," + 
					GlobalTools.ConvertFloat(strFromDoublePer1000(G0030)) + ",'" + 
					G0031 + "','" + 
					A0601 + "','" + //35
					A0602 + "','" + 
					A0603 + "','" + 
					A0701 + "','" + // translate to text
					A0801 + "','" + 
					A0802 + "','" + // 0 - Netral; 1 - Upgrade 1 Class //40
					A0901 + "','" + // 0 - Netral; 1 - Upgrade 1 Class
					A1001 + "','" + 
					A1002 + "','" + 
					A1003 + "','" + 
					A1004 + "'," + //45
					GlobalTools.ConvertFloat(strFromDoublePer100(A1011)) + "," + 
					//GlobalTools.ConvertFloat(strFromDouble(A1012)) + ",'" + 
					//nilai A1012=EAD selalu 100 ... latest ed!
					GlobalTools.ConvertFloat("100")+ ",'"+
					//GlobalTools.ConvertFloat(strFromDoublePer100(A1012)) + ",'" +  // yudi !
					A1013 + "'";
				//Response.Write(conn.QueryString);
				conn.ExecuteNonQuery();
			}

			string strTemp = "";
			if(ketcode == "0")
				conn.QueryString = "delete OHD_RULE_REASON_CODE where sumberdata='RATINGCUSTOMER' and ap_regno='"+ strRegno +"'";
			else
				conn.QueryString = "delete OHD_RULE_REASON_CODE where sumberdata='RATINGFACILITY' and ap_regno='"+ strRegno +"'";
			conn.ExecuteNonQuery();
			for (int i=0; i<20; i+=2)
			{
				strTemp = "";
				strTemp = OHD_RULE_REASON_CODE.Substring(i,2);
				if (strTemp.Trim()!="")
				{
					try
					{
						if(ketcode == "0")
							conn.QueryString = "insert into OHD_RULE_REASON_CODE values ('"+ strRegno +"','"+ strTemp +"','RATINGCUSTOMER')";
						else
							conn.QueryString = "insert into OHD_RULE_REASON_CODE values ('"+ strRegno +"','"+ strTemp +"','RATINGFACILITY')";
						conn.ExecuteNonQuery();
					}
					catch {}
				}
			}

			// hapus data di scoring_response
			//conn.QueryString  = "delete from SCORING_MESSAGE where AP_REGNO = '" + Request.QueryString["regno"] + "' ";
			//conn.QueryString += "and SUMBERDATA = 'RATINGCUSTOMER'"; //SCOREBCG_TEXT_MESSAGE";
			//conn.ExecuteNonQuery();
			conn.QueryString  = "delete from SCORING_RESPONSE where AP_REGNO like '%" + regno + "%' ";
			//conn.QueryString += "and SUMBERDATA = 'RATINGCUSTOMER'"; //SCOREBCG_TEXT_MESSAGE";
			conn.ExecuteNonQuery();

			return status;
		}

		#region Calculation Functions
		private static string strFromDoublePer100000( string var )
		{
			string r = "";
			try 
			{
				r = (Convert.ToDouble(var)/100000).ToString();
			} 
			catch { r = "0";}
			return r;
		}

		private static string strFromDoublePer1000( string var )
		{
			string r = "";
			try 
			{
				r = (Convert.ToDouble(var)/1000).ToString();
			} 
			catch { r = "0";}
			return r;
		}

		private static string strFromDoublePer100( string var )
		{
			string r = "";
			try 
			{
				r = (Convert.ToDouble(var)/100).ToString();
			} 
			catch { r = "0";}
			return r;
		}

		private static string strFromDouble( string var )
		{
			string r = "";
			try 
			{
				r = Convert.ToDouble(var).ToString();
			} 
			catch { r = "0";}
			return r;
		}
		#endregion
	}
}
