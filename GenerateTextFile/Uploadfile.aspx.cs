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
using System.IO;
using DMS.CuBESCore;
using DMS.DBConnection;
using System.Data.SqlClient; 



namespace Upload_File_booking
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public partial class Create_File : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.204.9.78;Initial Catalog=SME;uid=sa;pwd=");
		
		protected string vg_header;
		protected string vg_footer;
		protected string vg_tablecond;
		protected string vg_fieldcond;
		DataSet dsnew = new DataSet();
		DataTable ds2,ds3,ds4; //ds1,
		protected int i = 0;
		StreamWriter FileTemp;
		bool fileexistsc = false;
		bool fileexistrr = false;
		bool fileexistcl = false;
		protected Connection conn;						
		protected Connection conn1;	
		protected Connection dmsConn;			

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here					
			conn = (Connection) Session["Connection"];			
			conn1 = (Connection) Session["Connection"];			
			DataTable dt1 = new DataTable();
			string sql = "select * from rffile_referance where FL_TYPE <> '0'";
			conn.QueryString = sql;
			conn.ExecuteQuery();						
			dt1 = conn.GetDataTable().Copy();
			DataGrid1.DataSource = dt1;
			DataGrid1.DataBind();
			string fullname = "";
			for(int i = 0; i < DataGrid1.Items.Count; i++)
			{
				fullname = conn.GetFieldValue(i,"FL_DIR")+"\\"+conn.GetFieldValue(i,"FL_NAME");
				if (find_file(fullname))
				{
					DataGrid1.Items[i].Cells[2].Text = "ok";
					if (conn.GetFieldValue(i,"FL_TYPE") == "1" )
					{
						fileexistsc = true;
					}
					else if (conn.GetFieldValue(i,"FL_TYPE") == "2" )
					{
						fileexistrr = true;
					}
					else  if (conn.GetFieldValue(i,"FL_TYPE") == "3" )
					{
						fileexistcl= true;
					}
				}				
				else
				{
					DataGrid1.Items[i].Cells[2].Text = "Not Found";
					if (conn.GetFieldValue(i,"FL_TYPE") == "1" )
					{
						fileexistsc = false;
					}
					else if (conn.GetFieldValue(i,"FL_TYPE") == "2" )
					{
						fileexistrr = false;
					}
					else  if (conn.GetFieldValue(i,"FL_TYPE") == "3" )
					{
						fileexistcl= false;
					}
				}
			}												
			LST_MEMO.Items.Clear();

			Button3.Attributes.Add("onclick", "if (!interfaceMsg('Upload')) { return false; };");
		}

		bool find_file(string path)
		{
			return File.Exists(path);
		}

		string GetFieldValue(DataTable dt, int idx, string col)
		{
			return dt.Rows[idx][col].ToString().Trim();
		}

		string GetFieldValuecol(DataTable dt, int idx, int col)
		{
			return dt.Rows[idx][col].ToString().Trim();
		}

		int GetRowCount(DataTable dt)
		{
			return dt.Rows.Count;
		}

		int GetColCount(DataTable dt)
		{
			return dt.Columns.Count;
		}

		DataTable sqlQuery(string str)
		{
			conn.QueryString=str;
			conn.ExecuteQuery();
			return conn.GetDataTable().Copy();
		}

		private void backupFile() 
		{
			////////////////////////////////
			///
			/// Backup File
			/// 

			// ambil tanggal dan waktu
			conn.QueryString = "select convert(varchar,getdate(),112) + replace(convert(varchar,getdate(),108),':','') date";
			conn.ExecuteQuery();			
			string filename = "";

			filename = @"C:\Inetpub\ftproot\LCUCACT";
			if (File.Exists("c:\\backup\\LCUCACT"+conn.GetFieldValue("date")))
			{
				File.Delete("c:\\backup\\LCUCACT"+conn.GetFieldValue("date"));
			}
			File.Move(filename,"c:\\backup\\LCUCACT"+conn.GetFieldValue("date"));

			filename = @"C:\Inetpub\ftproot\LCUCKOL";
			if (File.Exists("c:\\backup\\LCUCKOL"+conn.GetFieldValue("date")))
			{
				File.Delete("c:\\backup\\LCUCKOL"+conn.GetFieldValue("date"));
			}
			File.Move(filename,"c:\\backup\\LCUCKOL"+conn.GetFieldValue("date"));
		}

		/// <summary>
		/// Fungsi untuk men-download parameter dengan memakai stored procedure
		/// Author			: Yudi Adhitiya
		/// Creation Date	: 19/07/2005
		/// </summary>
		/// <param name="_filePtr"></param>
		private void downloadParameter2(StreamWriter _filePtr) 
		{
			string _connstring = "";
			_connstring = (string) Session["connString"];

			dmsConn = new Connection(_connstring);
			Connection connMNT = new Connection();

			/////////////////////////////////////////////////////////////////////////////////////////////////////
			/// Get LOSMNT Connection
			/// 
			dmsConn.QueryString = "select moduleid, db_ip, db_nama, db_loginid, db_loginpwd " + 
				" from rfmodule where moduleid in ('99')";
			dmsConn.ExecuteQuery();
			
			connMNT = new Connection("Data Source=" + dmsConn.GetFieldValue(i, "db_ip") + ";Initial Catalog=" + dmsConn.GetFieldValue(i, "db_nama") + ";uid=" + dmsConn.GetFieldValue(i, "db_loginid") + ";pwd=" + dmsConn.GetFieldValue(i, "db_loginpwd") + ";Pooling=true");

			try 
			{ 
				////////////////////////////////////////////////////////////////////////////////////////////////////
				/// Copy para_upload from LOSSME to LOSMNT
				/// 
				dmsConn.QueryString = "exec PARAM_DL_PARA_UPLOAD_COPY";
				dmsConn.ExecuteNonQuery();

				_filePtr.WriteLine(DateTime.Now.ToString());
				_filePtr.WriteLine("Copying para_upload from SME to MNT ended successfully ...");
				_filePtr.WriteLine("=================================================================================================================================eof");


				////////////////////////////////////////////////////////////////////////////////////////////////////
				/// Execute stored procedure on LOSSME
				/// 
				dmsConn.QueryString = "exec PARAM_DL_DOWNLOADPARAM";
				dmsConn.ExecTrans();

				_filePtr.WriteLine(DateTime.Now.ToString());
				_filePtr.WriteLine("Download parameter to SME ended successfully ...");
				_filePtr.WriteLine("=================================================================================================================================eof");


				////////////////////////////////////////////////////////////////////////////////////////////////////
				/// Execute stored procedure on LOSMNT
				/// 
				connMNT.QueryString = "exec PARAM_DL_DOWNLOADPARAM";
				connMNT.ExecTrans();

				_filePtr.WriteLine(DateTime.Now.ToString());
				_filePtr.WriteLine("Download parameter to MNT ended successfully ...");
				_filePtr.WriteLine("=================================================================================================================================eof");

				dmsConn.ExecTran_Commit();
				connMNT.ExecTran_Commit();
			} 
			catch (Exception ex) 
			{
				_filePtr.WriteLine(DateTime.Now.ToString());
				_filePtr.WriteLine("downloadParameter2() ERROR :");
				_filePtr.WriteLine(ex.ToString());
				_filePtr.WriteLine("=================================================================================================================================eof");

				if (dmsConn != null) dmsConn.ExecTran_Rollback();
				if (connMNT != null) connMNT.ExecTran_Rollback();
			}


			/// Close Connection
			/// 
			try { if (connMNT != null) connMNT.CloseConnection(); } 
			catch {}
		}

		private void downloadParameter(StreamWriter _filePtr) 
		{
			string _connstring = "";
			_connstring = (string) Session["connString"];
			dmsConn = new Connection(_connstring);
			Connection	connSME = new Connection(), 
				connCON = new Connection(), 
				connCC = new Connection();			

			try 
			{ 
				/////////////////////////////////////////////////////////////////////////////////////////////
				/// Loop per each module, to create Connection objects
				/// 01 : SME
				/// 20 : Credit Card
				/// 40 : Consumer
				/// 
				dmsConn.QueryString = "select moduleid, db_ip, db_nama, db_loginid, db_loginpwd " + 
					" from rfmodule where moduleid in ('01', '20', '40')";
				dmsConn.ExecuteQuery();

				for (int i = 0; i < dmsConn.GetRowCount(); i++)
				{
					if (dmsConn.GetFieldValue(i, "moduleid") == "01")
						connSME = new Connection("Data Source=" + dmsConn.GetFieldValue(i, "db_ip") + ";Initial Catalog=" + dmsConn.GetFieldValue(i, "db_nama") + ";uid=" + dmsConn.GetFieldValue(i, "db_loginid") + ";pwd=" + dmsConn.GetFieldValue(i, "db_loginpwd") + ";Pooling=true");
					else if (dmsConn.GetFieldValue(i, "moduleid") == "20")
						connCC = new Connection("Data Source=" + dmsConn.GetFieldValue(i, "db_ip") + ";Initial Catalog=" + dmsConn.GetFieldValue(i, "db_nama") + ";uid=" + dmsConn.GetFieldValue(i, "db_loginid") + ";pwd=" + dmsConn.GetFieldValue(i, "db_loginpwd") + ";Pooling=true");
					else if (dmsConn.GetFieldValue(i, "moduleid") == "40")
						connCON = new Connection("Data Source=" + dmsConn.GetFieldValue(i, "db_ip") + ";Initial Catalog=" + dmsConn.GetFieldValue(i, "db_nama") + ";uid=" + dmsConn.GetFieldValue(i, "db_loginid") + ";pwd=" + dmsConn.GetFieldValue(i, "db_loginpwd") + ";Pooling=true");
				}


				////////////////////////////////////////////////////////////////////////////////////////////////////
				/// Get eMAS table definition
				/// 
				dmsConn.QueryString = "select distinct eMAS_FILENAME from param_def";
				dmsConn.ExecuteQuery();
				DataTable dtParam = dmsConn.GetDataTable().Copy();
				DataTable dttc;
				string smeQuery = "", conQuery = "", ccQuery = "", paramQuery = "",
					smeTable = "", conTable = "", ccTable = "";

				for (int i = 0; i < dtParam.Rows.Count; i++)
				{
					smeTable = ""; conTable = ""; ccTable = "";

					dmsConn.QueryString = "select emas_desc, sme_table, sme_column, con_table, con_column, cc_table, cc_column, stored_proc " + 
						" from param_def where eMAS_FILENAME='" + dtParam.Rows[i]["emas_filename"].ToString() + "'";
					dmsConn.ExecuteQuery();
					dttc= dmsConn.GetDataTable().Copy();

					///////////////////////////////////////////////////////////////////////////////////////
					/// Build query untuk insert records
					/// Use "insert into" for regular insert, exec stored_proc to use stored procedure
					/// 
					if (dmsConn.GetRowCount() > 0)
					{
						if ((dmsConn.GetFieldValue(0, "sme_table") != "") && (dmsConn.GetFieldValue(0, "sme_column") != ""))
						{
							//smeQuery = "insert into " + dmsConn.GetFieldValue(0, "sme_table") + " (";
							smeQuery = "exec " + dmsConn.GetFieldValue(0, "stored_proc") + " ";
							smeTable = dmsConn.GetFieldValue(0, "sme_table");
						}
						if ((dmsConn.GetFieldValue(0, "con_table") != "") && (dmsConn.GetFieldValue(0, "con_column") != ""))
						{
							//conQuery = "insert into " + dmsConn.GetFieldValue(0, "con_table") + " (";
							conQuery = "exec " + dmsConn.GetFieldValue(0, "stored_proc") + " ";
							conTable = dmsConn.GetFieldValue(0, "con_table");
						}
						if ((dmsConn.GetFieldValue(0, "cc_table") != "") && (dmsConn.GetFieldValue(0, "cc_column") != ""))
						{
							//ccQuery = "insert into " + dmsConn.GetFieldValue(0, "cc_table") + " (";
							ccQuery = "exec " + dmsConn.GetFieldValue(0, "stored_proc") + " ";
							ccTable = dmsConn.GetFieldValue(0, "cc_table");
						}

						paramQuery = "select ";
					
						/////////////////////////////////////////////////////////////////////////////////
						/// Loop nge-build query untuk select values di para_upload
						/// 
						for (int blah = 0; blah < dmsConn.GetRowCount(); blah++)
						{
							if (blah == (dmsConn.GetRowCount() - 1))
								paramQuery += dmsConn.GetFieldValue(blah, "emas_desc") + " from para_upload where fileName = '" + dtParam.Rows[i]["emas_filename"].ToString() + "'";
							else
								paramQuery += dmsConn.GetFieldValue(blah, "emas_desc") + ", ";
						}
					}

					// Loop nge-build query untuk insert
					// If using stored procedure comment this loop
					/*
					for (int j = 0; j < dttc.Rows.Count; j++)
					{
						if ((dttc.Rows[j]["sme_table"].ToString() != "") && (dttc.Rows[j]["sme_column"].ToString() != ""))
						{
							if (j == (dttc.Rows.Count - 1))
								smeQuery += dttc.Rows[j]["sme_column"].ToString() + ") values ('";
							else
								smeQuery += dttc.Rows[j]["sme_column"].ToString() + ", ";
						}

						if ((dttc.Rows[j]["con_table"].ToString() != "") && (dttc.Rows[j]["con_column"].ToString() != ""))
						{
							if (j == (dttc.Rows.Count - 1))
								conQuery += dttc.Rows[j]["con_column"].ToString() + ") values ('";
							else
								conQuery += dttc.Rows[j]["con_column"].ToString() + ", ";
						}

						if ((dttc.Rows[j]["cc_table"].ToString() != "") && (dttc.Rows[j]["cc_column"].ToString() != ""))
						{
							if (j == (dttc.Rows.Count - 1))
								ccQuery += dttc.Rows[j]["cc_column"].ToString() + ") values ('";
							else
								ccQuery += dttc.Rows[j]["cc_column"].ToString() + ", ";
						}
					}
					*/
			
					//////////////////////////////////////////////////////////////
					/// Loop nge-build values untuk di-insert
					/// 
					dmsConn.QueryString = paramQuery;
					dmsConn.ExecuteQuery();
					DataTable dtInsert = dmsConn.GetDataTable().Copy();

					/////////////////////////////////////////////////////////////////////////
					/// if later on eMAS send status if it's update, insert or delete...
					/// Remove these 3 lines below and fix the logic
					/// 
					if (smeTable != "")
					{
						connSME.QueryString = "update " + smeTable + " set active = '0'";
						connSME.ExecuteNonQuery();
					}
					if (conTable != "")
					{
						connCON.QueryString = "update " + conTable + " set active = '0'";
						connCON.ExecuteNonQuery();
					}
					if (ccTable != "")
					{
						connCC.QueryString = "update " + ccTable + " set active = '0'";
						connCC.ExecuteNonQuery();
					}

					try 
					{ 
						for (int k = 0; k < dtInsert.Rows.Count; k++)
						{
							string insertQuery = "";

							if (smeQuery.Trim() != "")
							{
								//insertQuery = smeQuery + dtInsert.Rows[k][0].ToString() + "', '" + dtInsert.Rows[k][1].ToString() + "')";
								insertQuery = smeQuery + "'" + dtInsert.Rows[k][0].ToString() + "', '" + dtInsert.Rows[k][1].ToString() + "'";
								connSME.QueryString = insertQuery;
								connSME.ExecuteNonQuery();
							}
							if (conQuery.Trim() != "")
							{
								//insertQuery = conQuery + dtInsert.Rows[k][0].ToString() + "', '" + dtInsert.Rows[k][1].ToString() + "')";
								insertQuery = conQuery + "'" + dtInsert.Rows[k][0].ToString() + "', '" + dtInsert.Rows[k][1].ToString() + "'";
								connCON.QueryString = insertQuery;
								connCON.ExecuteNonQuery();
							}
							if (ccQuery.Trim() != "")
							{
								//insertQuery = ccQuery + dtInsert.Rows[k][0].ToString() + "', '" + dtInsert.Rows[k][1].ToString() + "')";
								insertQuery = ccQuery + "'" + dtInsert.Rows[k][0].ToString() + "', '" + dtInsert.Rows[k][1].ToString() + "'";
								connCC.QueryString = insertQuery;
								connCC.ExecuteNonQuery();
							}
							//dmsConn.ExecuteNonQuery();
						}

						if (smeTable != "")
						{
							_filePtr.WriteLine("Insert " + smeTable + " successfully ...");
						}
						if (conTable != "")
						{
							_filePtr.WriteLine("Insert " + conTable + " successfully ...");
						}
						if (ccTable != "")
						{
							_filePtr.WriteLine("Insert " + ccTable + " successfully ...");
						}
						_filePtr.WriteLine("=================================================================================================================================");
					} 
					catch (Exception ex1) 
					{
						_filePtr.WriteLine("downloadParameter() ERROR1 :");
						_filePtr.WriteLine(ex1.ToString());
						_filePtr.WriteLine("=================================================================================================================================");
					}
				}

				_filePtr.WriteLine("Populate data into table parameter ended ...");
				_filePtr.WriteLine("=================================================================================================================================eof");

			} 
			catch (Exception ex) 
			{
				_filePtr.WriteLine("downloadParameter() ERROR2 :");
				_filePtr.WriteLine(ex.ToString());
				_filePtr.WriteLine("=================================================================================================================================eof");
			}

			try { if (dmsConn != null) dmsConn.CloseConnection(); } 
			catch {}
			try { if (connSME != null) connSME.CloseConnection(); } 
			catch {}
			try { if (connCC != null) connCC.CloseConnection(); } 
			catch {}
			try { if (connCON != null) connCON.CloseConnection(); } 
			catch {}
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

		private void Create_teksfile(string gr_id, string strPath,string strfilename,string strheader,string strfooter,string strtable,string strfield,ref int jmlcount)
		{			
			string fullfilename;
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
			
			ds2 = sqlQuery("select * from rfdtfile where grfile_id = '"+ gr_id +"'");

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
						//indextable = GetFieldValue(ds2,i,"DTFILE_KEYTABLE").IndexOf(",",0);
						//temptable = GetFieldValue(ds2,i,"DTFILE_KEYTABLE").Substring(0,indextable);
						//if (formsqlteks.IndexOf(temptable,0) <= 0)
						//{
						//	formsqlteks = formsqlteks + temptable + ",";
						//}
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
			wheresqlteks = wheresqlteks +" and "+ strtable +"."+ strfield;

			selectsqlteks = selectsqlteks +" "+ formsqlteks +" "+ wheresqlteks;
			
			//query table		
			ds3 = sqlQuery(selectsqlteks);
			
			//check mandatori
			int seq = 1;
			bool mandatori_result = true;
			for (int i = 0;i < GetRowCount(ds3);i++)
			{				
				for (k = 0;k < GetColCount(ds3);k++)
				{
					string dt_mandatory1 = GetFieldValue(ds2,k,"DTFILE_MANDATORY");														
					string teksdata1 = GetFieldValuecol(ds3,i,k);											
					if (dt_mandatory1 == "M")
					{
						if ((teksdata1 == "") || (teksdata1 == null)) 
						{
							LST_MEMO.Items.Add(i++ +" : "+GetFieldValue(ds2,k,"DTFILE_NAME")+" is Mandatory Field");									
							mandatori_result = false;
							break;
						}
					}
				}
			}
						
			if (mandatori_result)
			{
				fullfilename = strPath +"\\"+ strfilename;
				if (GetRowCount(ds3) > 0	)
				{				
					//create New if not exist
					if (!Directory.Exists(strPath))
					{
						Directory.CreateDirectory(strPath);
					}						
			
					if (File.Exists(fullfilename)== false)
					{				
						FileTemp = File.CreateText(fullfilename);
						FileTemp.WriteLine(createheader(fullfilename,"0"));					
						seq = 1;
						for (int i = 0;i < GetRowCount(ds3);i++)
						{				
							for (k = 0;k < GetColCount(ds3);k++)
							{
								string dt_type = GetFieldValue(ds2,k,"DTFILE_ATTRIBUTE");
								int dt_length = Convert.ToInt32(GetFieldValue(ds2,k,"DTFILE_LENGTH"));
								int dt_dec = Convert.ToInt32(GetFieldValue(ds2,k,"DTFILE_DEC"));
								string dt_format = GetFieldValue(ds2,k,"DTFILE_FORMAT");
								string dt_mandatory = GetFieldValue(ds2,k,"DTFILE_MANDATORY");							
							
								teksdata = GetFieldValuecol(ds3,i,k);														

								if (dt_type == "C")
								{
									if (teksdata.Length>= dt_length)
									{
										teksdata = teksdata.Substring(0,dt_length);
									}
									else
									{														
										teksdata = teksdata + CopyOfChar(' ',dt_length - teksdata.Length);
									}
									FileTemp.Write(teksdata);
								}					
						
								if (dt_type == "N")
								{
									if (teksdata.Length >= dt_length)
									{
										teksdata = teksdata.Substring(0,dt_length);
									}
									else
									{														
										dt_length = dt_length - dt_dec;
										teksdata = CopyOfChar('0',dt_length - teksdata.Length)+teksdata+CopyOfChar('0',dt_dec);								
									}
									FileTemp.Write(teksdata);
								}
								if (dt_type == "D")
								{
									if (dt_format != "")
									{						
										teksdata = formatdate(dt_format,teksdata);
									}
									if (teksdata.Length >= dt_length)
									{
										teksdata = teksdata.Substring(0,dt_length);
									}
									else
									{														
										teksdata = CopyOfChar('0',dt_length - teksdata.Length)+teksdata;
									}
									FileTemp.Write(teksdata);
								}
						
							}				
							FileTemp.WriteLine();
							jmli = i;
						}	
						jmli = jmli + 1;
						FileTemp.WriteLine(jmli.ToString("0000"));
						FileTemp.Close();						
					}			
					else
					{				
						ds4 = sqlQuery("select * from RFFILE_REFERANCE where FL_TYPE = '0'");
						string filename = GetFieldValuecol(ds4,0,2);
						string dir = GetFieldValuecol(ds4,0,3)+"\\";
						string pathfile = dir + filename;				
						if (File.Exists(pathfile))
						{
							StreamReader FileTempinput = new StreamReader(pathfile);
							string fileContent = FileTempinput.ReadLine();
							FileTempinput.Close();
							fileContent = fileContent.Substring(0,16);
					
							StreamReader FileTempoutput = new StreamReader(fullfilename);						
							//ArrayList arraylst = new ArrayList();
							string fileheader = FileTempoutput.ReadLine();
							FileTempoutput.Close();
							fileheader = fileheader.Substring(0,16);
					
							if (fileContent == fileheader)
							{
								//ListBox1.Items.Add("Header Sama");							
								StreamWriter fileTempappend;							
								fileTempappend = File.CreateText(fullfilename);
								fileTempappend.WriteLine(createheader(fullfilename,"0"));
								for (int i = 0;i < GetRowCount(ds3);i++)
								{				
									for (k = 0;k < GetColCount(ds3);k++)
									{
										string dt_type = GetFieldValue(ds2,k,"DTFILE_ATTRIBUTE");
										int dt_length = Convert.ToInt32(GetFieldValue(ds2,k,"DTFILE_LENGTH"));
										int dt_dec = Convert.ToInt32(GetFieldValue(ds2,k,"DTFILE_DEC"));
										string dt_format = GetFieldValue(ds2,k,"DTFILE_FORMAT");
										string dt_mandatory = GetFieldValue(ds2,k,"DTFILE_MANDATORY");
						
										teksdata = GetFieldValuecol(ds3,i,k);															
										
										if (dt_type == "C")
										{
											if (teksdata.Length>= dt_length)
											{
												teksdata = teksdata.Substring(0,dt_length);
											}
											else
											{														
												teksdata = teksdata + CopyOfChar(' ',dt_length - teksdata.Length);
											}
											fileTempappend.Write(teksdata);
										}					
						
										if (dt_type == "N")
										{
											if (teksdata.Length >= dt_length)
											{
												teksdata = teksdata.Substring(0,dt_length);
											}
											else
											{														
												dt_length = dt_length - dt_dec;
												teksdata = CopyOfChar('0',dt_length - teksdata.Length)+teksdata+CopyOfChar('0',dt_dec);								
											}
											fileTempappend.Write(teksdata);
										}
										if (dt_type == "D")
										{
											if (dt_format != "")
											{						
												teksdata = formatdate(dt_format,teksdata);
											}
											if (teksdata.Length >= dt_length)
											{
												teksdata = teksdata.Substring(0,dt_length);
											}
											else
											{														
												teksdata = CopyOfChar('0',dt_length - teksdata.Length)+teksdata;
											}
											fileTempappend.Write(teksdata);
										}
						
									}				
									fileTempappend.WriteLine();
									jmli = i;
								}
								jmli = jmli + 1;
								fileTempappend.WriteLine(jmli.ToString("0000"));
								fileTempappend.Close();

							}
							else
							{
								//ListBox1.Items.Add("Header Beda");							
								//ArrayList arraylst = new ArrayList();
								string sheader = createheader(fullfilename,"1");
								//arraylst.Add(sheader);
								StreamReader fileTempappend = new StreamReader(fullfilename);							
								int n = 0;
								string temp = "";
								ListBox2.Items.Clear();
								while (fileTempappend.Peek() != -1)
								{								
									temp = fileTempappend.ReadLine();
									if (n == 0)
									{
										ListBox2.Items.Add(sheader);									
									}																	
									else
									{
										ListBox2.Items.Add(temp);
									}	
									n++;
								}							
								fileTempappend.Close();
								//ListBox2.Items[ListBox2.Items.Count -1].Text = "";

								StreamWriter filetempsave;
								filetempsave = File.CreateText(fullfilename);

								for (n = 0;n < ListBox2.Items.Count-1;n++)
								{								
									filetempsave.WriteLine(ListBox2.Items[n]);	
								}
								jmli = 0;
								jmli = (jmli + n)-1;
								for (int i = 0;i < GetRowCount(ds3);i++)
								{				
									for (k = 0;k < GetColCount(ds3);k++)
									{
										string dt_type = GetFieldValue(ds2,k,"DTFILE_ATTRIBUTE");
										int dt_length = Convert.ToInt32(GetFieldValue(ds2,k,"DTFILE_LENGTH"));
										int dt_dec = Convert.ToInt32(GetFieldValue(ds2,k,"DTFILE_DEC"));
										string dt_format = GetFieldValue(ds2,k,"DTFILE_FORMAT");
										string dt_mandatory = GetFieldValue(ds2,k,"DTFILE_MANDATORY");
						
										teksdata = GetFieldValuecol(ds3,i,k);																

										if (dt_type == "C")
										{
											if (teksdata.Length>= dt_length)
											{
												teksdata = teksdata.Substring(0,dt_length);
											}
											else
											{														
												teksdata = teksdata + CopyOfChar(' ',dt_length - teksdata.Length);
											}
											filetempsave.Write(teksdata);
										}					
						
										if (dt_type == "N")
										{
											if (teksdata.Length >= dt_length)
											{
												teksdata = teksdata.Substring(0,dt_length);
											}
											else
											{														
												dt_length = dt_length - dt_dec;
												teksdata = CopyOfChar('0',dt_length - teksdata.Length)+teksdata+CopyOfChar('0',dt_dec);								
											}
											filetempsave.Write(teksdata);
										}
										if (dt_type == "D")
										{
											if (dt_format != "")
											{						
												teksdata = formatdate(dt_format,teksdata);
											}
											if (teksdata.Length >= dt_length)
											{
												teksdata = teksdata.Substring(0,dt_length);
											}
											else
											{														
												teksdata = CopyOfChar('0',dt_length - teksdata.Length)+teksdata;
											}
											filetempsave.Write(teksdata);
										}
						
									}				
									filetempsave.WriteLine();
									jmli = jmli + 1;
								}									
								//jmli = jmli + 1;
								filetempsave.WriteLine(jmli.ToString("0000"));
								filetempsave.Close();
							}

						}					
					}				
				}
				jmlcount = jmli;
			}
		}

		private string CopyOfChar(char ch, int i)
		{
			if ( i < 1) return "";
			return new string(ch, i);
		}

		private string createheader(string filename,string cheader)
		{
			if (cheader == "0")
			{
				DateTime dt = DateTime.Now;
				return dt.ToString("ddMMyy")+dt.ToString("hhmmss")+"0001";
			}
			else if (cheader == "1")
			{
				StreamReader rd = new StreamReader(filename);
				string sheader = rd.ReadLine();
				sheader = sheader.Substring(12,4);
				
				int iheader = int.Parse(sheader)+1;
				string snumber = iheader.ToString("0000");
				DateTime dt = DateTime.Now;
				rd.Close();
				return sheader = dt.ToString("ddMMyy")+dt.ToString("hhmmss") + snumber;				
			}
			else if (cheader == "3")
			{
				DateTime dt = DateTime.Now;
				return dt.ToString("ddMMyyyyhhmmss")+"01";
			}
			else
			{
				return "0";
			}
		}
		private string formatdate(string format, string tgl )
		{						
			if (tgl.Length == 8)
			{
				int yer1 = Convert.ToInt32(tgl.Substring(0,4));
				int bln1 = Convert.ToInt32(tgl.Substring(4,2));
				int tgl1 = Convert.ToInt32(tgl.Substring(6,2));
							
				DateTime dt = new DateTime(yer1,bln1,tgl1);
				return dt.ToString(format);
			}
			else
			{
				return tgl;
			}

		}

		private void upload_filesuccess()
		{
			ds2 = sqlQuery("select * from RFFILE_REFERANCE where FL_TYPE = '1'");
			string filename = GetFieldValue(ds2,0,"FL_DIR")+GetFieldValue(ds2,0,"FL_NAME");
			StreamReader file_succ = new StreamReader(filename);			

			/// Membaca dari textfile
			/// 
			while (file_succ.Peek() != -1)
			{
				string filetemp = file_succ.ReadLine();		

				/// fl_ap_regno adalah string ap_regno + cp_seq										
				/// 
				string fl_ap_regno = filetemp.Substring(0,20);
				fl_ap_regno = fl_ap_regno.Trim();
				
				//string fl_cpseq = fl_ap_regno.Substring(fl_ap_regno.Length-1,1);  // assuming 1 char long in CP-SEQ				
				//fl_ap_regno = fl_ap_regno.Substring(0,fl_ap_regno.Length - 1);				

				string fl_cifno = trim_char(filetemp.Substring(20,19));			
				string fl_accno = filetemp.Substring(39,19);			
				fl_accno = fl_accno.Substring((fl_accno.Length - 13),13);
				string fl_aano = filetemp.Substring(58,20);			
				string fl_fac = filetemp.Substring(78,3);			


//				string fl_seq = filetemp.Substring(81,9);			
//				string fl_loanammount = filetemp.Substring(90,17);			

				/// Application limit is not sent by eMAS
				/// The limit can be retrieved from cp_limitapproved (custproduct table)
				/// (yudi)
				/// 
//				string fl_loanammount = "0";
//				double fl_loanammount_num = 0.00;
//				try { fl_loanammount_num = Convert.ToDouble(filetemp.Substring(90,17)); } 
//				catch {}
//				fl_loanammount = fl_loanammount_num.ToString();


				string fl_seq = "0";
				int fl_seq_num = 0;

				try { fl_seq_num = Convert.ToInt32(filetemp.Substring(81,9)); } 
				catch {}

				fl_seq = fl_seq_num.ToString();

				string fl_disbdate = filetemp.Substring(107,6);			
				
				/// Membaca dari database LOS
				/// 
				conn.QueryString = "select a.ap_regno, a.PRODUCTID, a.PROD_SEQ, a.cp_seq, " + 
					" ltrim(rtrim(isnull(a.CP_LIMITCHG,''))) as CP_LIMITCHG, a.CP_LIMITAPPROVED, A.APPTYPE " +
					" from custproduct a  " +
					"where (a.ap_regno+convert(varchar,a.cp_seq)) = '" + fl_ap_regno + "' and a.apptype in ('01', '03')" ;
				conn.ExecuteQuery();
				//conn.ExecuteQuery = "exec UPLOAD_CREDITSUCCEED '" + fl_ap_regno + "'";
				
				//added by rene 08062006
				string productid = "";
				string limit = "0.00" ;
				string fl_cpseq = "";
				string pseq = "";
				string log = "";
				string apptype = "";

				//string limit = conn.GetFieldValue("AD_LIMIT").Trim();
				//string limit = fl_loanammount;

				if ( conn.GetRowCount() > 0  ) 
				{
					/// Retrieve all values from database
					/// 
					productid	= conn.GetFieldValue("PRODUCTID").Trim();
					limit		= GlobalTools.ConvertFloat(conn.GetFieldValue("CP_LIMITAPPROVED")).ToString();
					fl_ap_regno = conn.GetFieldValue("AP_REGNO");
					fl_cpseq	= conn.GetFieldValue("CP_SEQ");
					pseq		= conn.GetFieldValue("PROD_SEQ").Trim();
					apptype 	= conn.GetFieldValue("APPTYPE").Trim();
					log			= "1";

				}
				else 
				{
					/// Retrieve all values directly from file 
					/// 
					productid	= fl_fac;
					try { limit	= Convert.ToDouble(filetemp.Substring(90,17)).ToString(); } catch {}
					fl_cpseq	= fl_ap_regno.Substring(fl_ap_regno.Length-1,1);	// (a)  // (a) and (b) must be ordered ...
					fl_ap_regno = fl_ap_regno.Substring(0,fl_ap_regno.Length - 1);	// (b)				
					pseq		= "0";
					log			= "2";
					
				}

				/// Construct query for insert values into uptext_success
				/// 
				string filequery = "'"+fl_ap_regno+"','"+fl_cifno+"','"+fl_accno+"','"+fl_aano+"','"+fl_fac+"','"+fl_seq+"','"+limit+"','"+fl_disbdate+"','"+productid+"','0','"+pseq+"', '" + fl_cpseq + "'";
								
				try
				{	
					/// Insert rows into uptext_success
					/// 				
					string sql = "insert into uptext_success(AP_REGNO, US_CIFNO, US_ACCNO, US_AANO, US_FAC, US_SEQ, US_LOANAMMOUNT, US_DISBDATE, PRODUCTID, FLAG, PROD_SEQ, CP_SEQ) values ("+filequery+")";
					
					
					try 
					{
						conn.QueryString = sql;				
						//conn.ExecuteNonQuery();
						conn.ExecuteQuery();
					}
					catch { }

					// update bookcust & bookprod 


					//  update customer -> CIF #, application AA#
					conn.QueryString = "EXEC uploadtext_file_appcust " +
							"'" +fl_ap_regno+ "',"+
							"'" + apptype + "',"+
							"'" + productid+"',"+
							"" + pseq+","+
							"'" + fl_aano+"',"+
							"" + fl_seq + ","+
							"" + limit +","+
							"'" + fl_cifno +"'";

					try 
					{
						conn.ExecuteQuery();
					}
					catch { }

					// try the same way ... for bookprod & bookcust
					conn.QueryString = "EXEC uploadtext_file_bookcustprod " +
						"'" +fl_ap_regno+ "',"+
						"'" + apptype + "',"+
						"'" + productid+"',"+
						"" + pseq+","+
						"'" + fl_aano+"',"+
						"" + fl_seq + ","+
						"" + limit +","+
						"'" + fl_accno +"'";

					try 
					{
						conn.ExecuteQuery();
					}
					catch { }


					/// Update customer debitur date
					/// 
					sql = "update company_info set CI_BMDEBITUR = getdate() where cu_ref = (select cu_ref from application where ap_regno = '"+fl_ap_regno+"') and CI_BMDEBITUR is null";
					conn.QueryString = sql;				
					conn.ExecuteNonQuery();					
						
					/// Update application track
					/// 
//					string sql1 = " select apptype, productid, prod_seq from custproduct where ap_regno='" + fl_ap_regno + 
//									"' and productid = '"+ productid +
//									"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'') <> '1'";

					//added by rene
					string sql1 = "";
					if (log == "1")
					{
//						sql1 = " select cp.apptype, cp.productid, cp.prod_seq from custproduct cp " +
//							"join apptrack t on t.ap_regno = cp.ap_regno and t.apptype = cp.apptype " +
//							"and t.productid = cp.productid and t.prod_seq = cp.prod_seq " +
//							"where cp.ap_regno = '" + fl_ap_regno + "' " +
//							"	and cp.productid = '"+ productid + "' " +
//							"	and isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'') <> '1' " +
//							"	and t.ap_currtrack <> '5.6' and cp.cp_seq = '"+ fl_cpseq +"'";										// don't touch rows that has been marked successfull
						sql1 = " select apptype, productid, prod_seq from custproduct where ap_regno='" + fl_ap_regno + 
							"' and productid = '"+ productid +
							"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'') <> '1' and cp_seq = '"+ fl_cpseq +"'";


					}
					else if (log == "2")
					{
						sql1 = " select apptype, productid, prod_seq from custproduct where ap_regno='" + fl_ap_regno + 
										"' and productid = '"+ productid +
										"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'') <> '1'";
					}
					//Response.Write(sql1);
					DataTable vds1 = sqlQuery(sql1);				
					for (int j = 0; j < GetRowCount(vds1); j++)
					{
						//conn.QueryString = "update application set AP_BOOKFLAG = '2' from application where ap_regno =  '"+fl_ap_regno+"'";

						//added by rene
						conn.QueryString = "update application set AP_BOOKFLAG = '2' " +
							" where ap_regno =  '" + fl_ap_regno + "' ";
//							"	and ap_regno not in (select a.ap_regno from application a " +	// set success only if all track has been successfull
//							"				join apptrack t on t.ap_Regno = a.ap_regno " +
//							"			where a.ap_regno = application.ap_regno " +
//							"             and isnull(ap_currtrack,'5.6') <> '5.6')";
						//Response.Write(conn.QueryString);
						conn.ExecuteNonQuery();

						//vds2 = sqlQuery(sql2);										
						string sql2 = "exec TRACKUPDATE '" + fl_ap_regno + "','"+ productid + "', '" + GetFieldValue(vds1,j,"apptype") + "','su2', " + GetFieldValue(vds1,j,"prod_seq") + ", '5.2'";
						//'"+ Session["UserID"].ToString() + "'";
						//GetFieldValue(vds1,j,"productid") //'"+ Session["UserID"].ToString() + "'";
						DataTable vds2 = sqlQuery(sql2);

					}					
					updatetoreport(fl_ap_regno,"2",productid);
				}
				catch (Exception e)
				{ 
					Response.Write("<!-- filesuccess: " + e.Message + " -->");
					Response.Write("<!-- filequery: " + filequery + " -->");
					LST_MEMO.Items.Add("Generate Application no '"+fl_ap_regno+"' Duplicate");													
				}

			}									
			file_succ.Close();	
			//Response.End();
			conn.QueryString = "select convert(varchar,getdate(),112) + replace(convert(varchar,getdate(),108),':','') date";
			conn.ExecuteQuery();
			
			if (File.Exists("c:\\backup\\"+GetFieldValue(ds2,0,"FL_NAME")+conn.GetFieldValue("date")))
			{
				File.Delete("c:\\backup\\"+GetFieldValue(ds2,0,"FL_NAME")+conn.GetFieldValue("date"));
			}
			File.Move(filename,"c:\\backup\\"+GetFieldValue(ds2,0,"FL_NAME")+conn.GetFieldValue("date"));

		}

		string trim_char(string karakter)
		{						
			string hasil = "";
			bool flag = false;
			for (int i = 0;i < karakter.Length;i++)
			{
				if ((karakter.Substring(i,1) != "0") && (!flag))
				{
					hasil = hasil + karakter.Substring(i).ToString();					
					break;
				}				
			}		
			return hasil;														
		}

		private void upload_filefail()
		{
			ds2 = sqlQuery("select * from RFFILE_REFERANCE where FL_TYPE = '2'");
			string filename = GetFieldValue(ds2,0,"FL_DIR")+GetFieldValue(ds2,0,"FL_NAME");
			StreamReader file_fail = new StreamReader(filename);			
			while (file_fail.Peek() != -1)
			{			
				string filetemp = file_fail.ReadLine();																
				string p_proc_date = "", p_branch = "", p_ap_regno = "", fl_cpseq = "", p_name = "", 
					p_err_type = "", p_err_cd = "", p_err_desc = "", p_err_data = "", p_seq_f = "";
				try 
				{ 
					p_proc_date	= filetemp.Substring(0,6);			
					p_branch	= filetemp.Substring(6,5);			
					p_ap_regno = filetemp.Substring(11,20);			
					p_ap_regno = p_ap_regno.Trim();
					fl_cpseq = p_ap_regno.Substring(p_ap_regno.Length-1,1);
					p_ap_regno = p_ap_regno.Substring(0,p_ap_regno.Length - 1);
					p_name		= filetemp.Substring(31,40);
					p_err_type	= filetemp.Substring(71,3);			
					p_err_cd		= filetemp.Substring(74,3);			
					p_err_desc	= filetemp.Substring(77,60).Replace("'","''");			
					p_err_data	= filetemp.Substring(137,60);			
					p_seq_f		= filetemp.Substring(197,4);																		
				} 
				catch (Exception ex1)
				{
					throw new Exception("[" + filetemp+ "]_" + ex1.Message);
				}

				/*
				////////////////////////////////////////////////////////////////////
				/// sebelum tambah fail baru,
				/// hapus dulu fail lama agar tidak ada duplicate fail-message
				/// 
				conn.QueryString = "delete from uptext_fail where ap_regno = '" + p_ap_regno + 
					"' and uf_cpseq = '" + fl_cpseq + 
					"' and uf_errorcd = '" + p_err_cd + "'";
				conn.ExecuteNonQuery();
				//this function moved to generate text file -- nyoman
				*/
				
				conn.QueryString = "select productid from custproduct where ap_regno = '"+p_ap_regno+"' and cp_seq = '"+fl_cpseq+"'";
				conn.ExecuteQuery();
				string productid = conn.GetFieldValue("productid");
				conn.QueryString = "select * from uptext_fail where ap_regno = '"+p_ap_regno+"'";
				conn.ExecuteQuery();
				int seq = 1;
				if (conn.GetRowCount() > 0)
				{
					conn.QueryString = "select isnull(max(UF_SEQLOCAL),0)+1 from uptext_fail where ap_regno = '"+p_ap_regno+"'";
					conn.ExecuteQuery();
					seq = int.Parse(conn.GetFieldValue(0,0));
				}				

				string filequery = ""+seq+",'"+p_proc_date+"','"+p_branch+"','"+p_ap_regno+"','"+p_name+"','"+p_err_type+"','"+p_err_cd+"','"+p_err_desc+"','"+p_err_data+"','"+p_seq_f+"',"+fl_cpseq+"";				
				try
				{
					string sql2 = "insert into uptext_fail(UF_SEQLOCAL,UF_DATE,UF_BRANCH,AP_REGNO,UF_NAME,UF_ERRORTYPE,UF_ERRORCD,UF_DESC,UF_DATA,UF_SEQ,UF_CPSEQ) values ("+filequery+")";				
					DataTable vdt1 = sqlQuery(sql2);										
					sql2 = "update application set AP_BOOKFLAG = '3' from application where ap_regno =  '"+p_ap_regno+"'";
					vdt1 = sqlQuery(sql2);										

					updatetoreport(p_ap_regno,"3",productid);
				}
				catch (Exception e)
				{
					Response.Write("<!-- filefail: " + e.Message + " -->");
					LST_MEMO.Items.Add("Generate Application no '"+p_ap_regno+"' Duplicate");													
				}				

				///////////////////////////////////////////////////////////
				///	mengupdate track ke fail track (REJECT SIBS)
				///	
//				string sql1 = "select apptype, productid, prod_seq from custproduct where ap_regno='" + p_ap_regno + 
//					"' and productid = '"+ productid +
//					"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'') <> '1'";
				string sql1 = " select cp.apptype, cp.productid, cp.prod_seq from custproduct cp " +
					"join apptrack t on t.ap_regno = cp.ap_regno and t.apptype = cp.apptype " +
					"and t.productid = cp.productid and t.prod_seq = cp.prod_seq " +
					"where cp.ap_regno = '" + p_ap_regno + "' " +
					"	and cp.productid = '"+ productid + "' " +
					"	and isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'') <> '1' " +
					"	and t.ap_currtrack <> '5.6' and cp.cp_seq = '"+ fl_cpseq +"'";
				DataTable vds1 = sqlQuery(sql1);
				for (int j = 0; j < GetRowCount(vds1); j++)
				{
					string sql3 = "exec TRACKUPDATE_FAIL '" + p_ap_regno + "','"+ productid + "', '" + GetFieldValue(vds1,j,"apptype") + "','su2', '" + GetFieldValue(vds1,j,"prod_seq") + "','5.2'";
					conn.QueryString = sql3;
					conn.ExecuteNonQuery();
				}		
			}				
			file_fail.Close();
			conn.QueryString = "select convert(varchar,getdate(),112) + replace(convert(varchar,getdate(),108),':','') date";
			conn.ExecuteQuery();
			if (File.Exists("c:\\backup\\"+GetFieldValue(ds2,0,"FL_NAME")+conn.GetFieldValue("date")))
			{
				File.Delete("c:\\backup\\"+GetFieldValue(ds2,0,"FL_NAME")+conn.GetFieldValue("date"));
			}
			File.Move(filename,"c:\\backup\\"+GetFieldValue(ds2,0,"FL_NAME")+conn.GetFieldValue("date"));
		}

		private void upload_filecol()
		{
			ds2 = sqlQuery("select * from RFFILE_REFERANCE where FL_TYPE = '3'");
			string filename = GetFieldValue(ds2,0,"FL_DIR")+GetFieldValue(ds2,0,"FL_NAME");
			StreamReader file_fail = new StreamReader(filename);			
			while (file_fail.Peek() != -1)
			{								
				string filetemp = file_fail.ReadLine();
				string p_ap_regno = filetemp.Substring(0,20);			
				p_ap_regno = p_ap_regno.Trim();
				string fl_cpseq = p_ap_regno.Substring(p_ap_regno.Length-1,1);
				p_ap_regno = p_ap_regno.Substring(0,p_ap_regno.Length - 1);				
				string coll_id		= filetemp.Substring(20,35);							
				string coll_seq		= filetemp.Substring(55,5);																		
				conn.QueryString = "select PRODUCTID from custproduct where ap_regno = '"+p_ap_regno+"' and cp_seq = '"+fl_cpseq+"'";
				conn.ExecuteQuery();
				string productid = conn.GetFieldValue("PRODUCTID").Trim();				
				string filequery = "'"+p_ap_regno+"','"+coll_id+"',"+coll_seq+",'"+productid+"'";				
				try
				{
					string sql2 = "insert into uptext_collateral(AP_REGNO,COLL_ID,COLL_SEQ,PRODUCTID) values ("+filequery+")";				
					DataTable vdt1 = sqlQuery(sql2);																				
				}
				catch (Exception e)
				{
					Response.Write("<!-- filecol: " + e.Message + " -->");
					LST_MEMO.Items.Add("Generate Application no '"+p_ap_regno+"' Duplicate");													
				}								
			}				
			file_fail.Close();
			
			/****************************************************************************************************
			 * These 4 operations are wrapped into one new stored procedure, UPLOAD_COLLUPDATE (yudi, 2005-06-13)
			 * 
			 * */
			/*
			conn.QueryString =  "insert into bookedcollateral " +
				"select US_AANO,a.PRODUCTID,COLL_SEQ,US_SEQ,LC_PERCENTAGE,LC_VALUE,COLL_ID,CL_CURRENCY from uptext_collateral a join uptext_success b  " +
				"on a.ap_regno = b.ap_regno and a.productid = b.productid " +
				"join listcollateral c on a.ap_regno = c.ap_regno and a.productid = c.productid and a.COLL_SEQ = c.CL_SEQ and a.PROD_SEQ = c.PROD_SEQ " +
				"join collateral d on c.cu_ref = d.cu_ref and c.cl_seq = d.cl_seq where isnull(b.flag,'0') = '0' ";
			conn.ExecuteNonQuery();
			
			conn.QueryString =  "update collateral set SIBS_COLID = COLL_ID " +
				"from listcollateral a join collateral b on a.cu_ref = b.cu_ref and a.cl_seq = b.cl_seq " +
				"join uptext_collateral c on a.ap_regno = c.ap_regno and a.cl_seq = c.coll_seq and a.productid = c.productid and a.PROD_SEQ = c.PROD_SEQ where isnull(c.flag,'0') = '0' ";
			conn.ExecuteNonQuery();			
			
			conn.QueryString =  "update uptext_success set FLAG = '1' where isnull(FLAG,'0') = '0'";
			conn.ExecuteNonQuery();

			conn.QueryString =  "update uptext_collateral set FLAG = '1' where isnull(FLAG,'0') = '0'";
			conn.ExecuteNonQuery();
			*/

			conn.QueryString = "exec UPLOAD_COLLUPDATE";
			conn.ExecuteNonQuery();

			conn.QueryString = "select convert(varchar,getdate(),112) + replace(convert(varchar,getdate(),108),':','') date";
			conn.ExecuteQuery();
			if (File.Exists("c:\\backup\\"+GetFieldValue(ds2,0,"FL_NAME")+conn.GetFieldValue("date")))
			{
				File.Delete("c:\\backup\\"+GetFieldValue(ds2,0,"FL_NAME")+conn.GetFieldValue("date"));
			}
			File.Move(filename,"c:\\backup\\"+GetFieldValue(ds2,0,"FL_NAME")+conn.GetFieldValue("date"));
		}
		
		private void updatetoreport(string regno,string result,string productid)
		{
			//conn.QueryString = "select isnull(max(seq),0) seq from bookingreport where ap_regno = '"+ regno +"'";
			//conn.ExecuteQuery();			
			conn.QueryString = "update bookingreport set result = '"+result+"' where ap_regno = '"+regno+"' and productid = '"+ productid +"' and seq = " +
				" (select isnull(max(seq),0) from bookingreport where ap_regno = '"+ regno +"' ) ";
			conn.ExecuteNonQuery();						
		}

		protected void Button3_Click(object sender, System.EventArgs e)
		{						
			
			if (!Directory.Exists("c:\\backup"))
			{
				Directory.CreateDirectory("c:\\backup");
			}
			
			try 
			{
				if (fileexistsc)
				{
					upload_filesuccess();				
					LST_MEMO.Items.Add("Generate File LCUBCRT done");													
				}
			} 
			catch (Exception ex)
			{
				LST_MEMO.Items.Add("Generate File LCUBCRT FAILED ... !");													
				ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "UPLOAD LCUBCRT FAILED");
			}
			
			try 
			{ 
				if (fileexistrr)
				{
					upload_filefail();
					LST_MEMO.Items.Add("Generate File LCUBERR done");									
				}	
			} 
			catch (Exception ex)
			{
				LST_MEMO.Items.Add("Generate File LCUBERR FAILED ... !");				
				ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "UPLOAD LCUBERR FAILED");
			}

			try 
			{ 
				if (fileexistcl)
				{
					upload_filecol();
					LST_MEMO.Items.Add("Generate File LCUBCOL done");									
				}			
			} 
			catch (Exception ex)
			{
				LST_MEMO.Items.Add("Generate File LCUBCOL FAILED ... !");
				ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "UPLOAD LCUBCOL FAILED");
			}

			try 
			{ 
				UpdateFileHeader();
			} 
			catch (Exception ex)
			{
				LST_MEMO.Items.Add("Upload File Header FAILED ... !");
				ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "UPLOAD FILE HEADER FAILED");
			}

			try 
			{ 
				UploadTextFileAccount();
			} 
			catch (Exception ex)
			{
				LST_MEMO.Items.Add("Upload File Account FAILED ... !");
				ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "UPLOAD FILE ACCOUNT FAILED");
			}

			//////////////////////////////////////////////
			/// audit trail
			try
			{
				conn.QueryString = "SP_AUDITTRAIL_APP " + 
					"null, null, null, null," + 
					"null, null, '" + TXT_AUDITDESC.Text + "',"+ 
					"null,"  +  
					"'"+ Session["UserID"].ToString() + "','xxxx',null,null,null";
				conn.ExecuteNonQuery();
			}
			catch (Exception ex)
			{ 	
				Response.Write("<!-- upload err: " + ex.Message + " -->");
				ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "UPLOAD AUDITTRAIL FAILED");
			}
		}

		private void UpdateFileHeader()
		{
			string newhdr = createheader("","3");
			conn.QueryString = "update rfgrfile set grfile_header = '" + newhdr + "' where GRFILE_TYPE='0'";
			conn.ExecuteNonQuery();
		}

		private void UploadTextFileAccount()
		{

			#region Upload Account

			//Upload Account Info
			if (!File.Exists(@"C:\Inetpub\ftproot\LCUCACT")) 
			{
				GlobalTools.popMessage(this, "File C:\\Inetpub\\ftproot\\LCUCACT tidak ditemukan !");
				return;
			}
			StreamReader sr1 = File.OpenText(@"C:\Inetpub\ftproot\LCUCACT");
			string strHasil,strCekNol="";
			int l1,l2;
			string x,xTemp;

			SqlConnection con = new  SqlConnection();	
			
			con.ConnectionString = conn.connString;
			con.Open();

			SqlCommand cmd = con.CreateCommand();
			SqlCommand cmdIn= con.CreateCommand();

			string szAccNo = "";
			string szCu_Ref = "";

			/* Delete semua data di acc_info dulu */
			cmd.CommandText="delete from ACC_INFO";
			cmd.ExecuteNonQuery();

			
			while ((strHasil=sr1.ReadLine())!=null)
			{
				try
				{
					szAccNo = strHasil.Substring(6,13).Trim();
					szCu_Ref = strHasil.Substring(230,18).Trim();
				}
				catch 
				{
					continue;
				}

				cmd.CommandText = "Select * from acc_info where acc_no = '" + szAccNo + "' and cu_ref = '" + szCu_Ref + "'";
				SqlDataReader a = cmd.ExecuteReader();
				if(!a.HasRows)
				{
					x="insert into acc_info(acc_no,acc_type,dept_code,acc_currency," + 
						"original_ammount,current_balance,accrual_interest,accrual_late_charge," +
						"billed_principle,billed_interest,billed_late_charge,billed_other_charge," +
						"billed_misc,coll_bi,coll_bm,npl_stat,acc_stat,tgl_jth_tempo,"+
						"tgl_byr_tghn_pokok,"+
						"tgl_byr_tghn_bunga,loan_term,loan_term_code,suku_bunga," +
						"lama_tunggakan_pokok,lama_tunggakan_bunga, cu_ref) values(";
				}
				else
				{
					a.Close();
					continue;
				}
				a.Close();

				//tolong check, pri key cu_ref +acc_no
				
				cmd.CommandText = "Select * from RFUPFILE where upfile_name='ACCOUNT NUMBER' and UPFILE_GROUP='0' order by upfile_id ASC";
				SqlDataReader dr = cmd.ExecuteReader();
				dr.Read();
				l2=dr.GetInt32(3);
				dr.Close();

				xTemp=strHasil.Substring(0,l2);				
				cmd.CommandText="select * from ACC_INFO where ACC_NO='" + xTemp + "'";
				dr=cmd.ExecuteReader();
				if(dr.HasRows)
				{
					dr.Close();
					cmd.CommandText="delete from ACC_INFO where ACC_NO='" + xTemp + "'";
					cmd.ExecuteNonQuery();
				}
				else
				{
					dr.Close();
				}

				int pos=0;
				//cmd.CommandText = "Select * from RFUPFILE where UPFILE_GROUP='0' order by upfile_id ASC";
				cmd.CommandText = "Select UPFILE_ID, UPFILE_NAME, UPFILE_TYPE, UPFILE_LENGTH, UPFILE_DEC, UPFILE_FORMAT, UPFILE_GROUP, UPFILE_CODE " + 
					" from RFUPFILE where UPFILE_GROUP='0' order by upfile_id ASC";
				
				dr = cmd.ExecuteReader();
				while(dr.Read())
				{
					int intStart,intLength = 0;
					intStart=pos;
					intLength = dr.GetInt32(3);
					if(dr.GetString(2)=="N")
					{
						xTemp=strHasil.Substring(pos,intLength);
						l1=dr.GetInt32(4);
						if(l1>0)
						{
							xTemp=xTemp.Substring(0,intLength-l1)+"."+ xTemp.Substring(intLength-l1,l1);
						}
						x=x+xTemp;
					}
					else if(dr.GetString(2)=="C")
					{
						int xxx = strHasil.Length;
						int length_baca = intLength;
						
						if ( (xxx - pos) < intLength)
							length_baca = xxx - pos; 

						xTemp=strHasil.Substring(pos,length_baca);
						if(dr.GetString(1)=="ACCOUNT NUMBER")
						{
							strCekNol=strHasil.Substring(pos,intLength).Trim();
							/*
							for(int i=0;i<strCekNol.Length;i++)
							{
								if(strCekNol.Substring(0+i,1).Equals("0"))
								{
								}
								else
								{
									strCekNol=strCekNol.Substring(i,strCekNol.Length-i);
									i=strCekNol.Length;
								}
							}
							*/
							xTemp=strCekNol.Substring(6,13);
						}
						x=x+"'"+xTemp+"'";
					}
					else if(dr.GetString(2)=="D")
					{
						string strTgl;
						strTgl=	strHasil.Substring(pos,intLength);
						if (strTgl.Equals("00000000"))
						{
							strTgl="null";
							x=x+strTgl;
						}
						else
						{
							strTgl=strTgl.Substring(2,2)+"/"+strTgl.Substring(0,2)+"/"+strTgl.Substring(4,4);
							x=x+"'"+strTgl+"'";
						}
					}
					pos=pos+intLength;
					if(pos<strHasil.Length)
					{
						x=x+",";
					}
					else
					{
						x=x+")";
					}
				}
				dr.Close(); 
			
				try 
				{
					////////////////////////////////////
					/// Kalau sudah punya account,
					/// tidak perlu dimasukkan lagi
					/// 
					cmdIn.CommandText=x;
					cmdIn.ExecuteNonQuery();
				} 
				catch {}

				/*
				cmdIn.CommandText = "exec SP_UPLOAD_ACCOUNTINFO '" + strCekNol + "'";
				cmdIn.ExecuteNonQuery();
				*/

				/// New Update Upload
				/// 
				cmdIn.CommandText = "exec UP_LOAD_NEW"; // It New Storeprocedure
				cmdIn.ExecuteNonQuery();
				

				
				/****
				cmdIn.CommandText="delete from acc_info where acc_no='" + strCekNol  + "'";
				cmdIn.ExecuteNonQuery();

				cmdIn.CommandText=x;
				cmdIn.ExecuteNonQuery();
				cmdIn.CommandText="delete from custmandiriloan where cm_accno='" + strCekNol  + "' and cu_ref=(select c.cu_ref " +
					" from acc_info a  inner join bookedprod b on a.acc_no=b.acc_no " +
					" inner join bookedcust c on b.aa_no=c.aa_no and b.acc_no='" + strCekNol + "')";
				cmdIn.ExecuteNonQuery();

				cmdIn.CommandText="insert into custmandiriloan (CM_ATASNAMA,cm_credittype,cm_limit,cm_outstanding," +
					" cm_tgkpokok,cm_tgkbunga,cm_lamatgk,cm_duedate,cm_collectability," +
					" cm_tglposisi,cu_ref,cm_accno) (select '0',b.productid,a.current_balance,a.original_ammount,a.billed_principle,a.billed_interest," +
					" a.lama_tunggakan_pokok,a.tgl_jth_tempo," +
					" a.coll_bi,getdate(),c.cu_ref,b.acc_no from acc_info a " +
					" inner join bookedprod b on a.acc_no=b.acc_no " +
					" inner join bookedcust c on b.aa_no=c.aa_no where b.acc_no='" + strCekNol + "')";
				cmdIn.ExecuteNonQuery();
				***/

			}

			//string y;

			/***
			y=" update a set a.cu_ref=c.cu_ref from acc_info a inner join bookedprod b on a.acc_no=b.acc_no inner join bookedcust c on b.aa_no=c.aa_no ";
			cmdIn.CommandText=y;
			cmdIn.ExecuteNonQuery();
				
			y=" update a set a.cu_ref=b.cu_ref from acc_info a inner join cust_stockholder_acc b on a.acc_no=b.hold_acc_no ";
			cmdIn.CommandText=y;
			cmdIn.ExecuteNonQuery();
			***/

			#endregion
			
			#region Upload Account Kolektibilitas
			//Upload Account Kolektibilitas
			if (!File.Exists(@"C:\Inetpub\ftproot\LCUCKOL")) 
			{
				GlobalTools.popMessage(this, "File C:\\Inetpub\\ftproot\\LCUCKOL tidak ditemukan !");
				return;
			}
			StreamReader sr2=File.OpenText(@"C:\Inetpub\ftproot\LCUCKOL");
			strHasil="";
			l1=0;l2=0;
			x="";xTemp="";
			int sudahCek=0;
			
			string szAccNo1 = "";
			string szColl_Code = "";
			string tanggal = "";			

			while ((strHasil=sr2.ReadLine())!=null)
			{
				// CHECK DUPLICATION 
				try
				{
					szAccNo1 = strHasil.Substring(6,13);
					szColl_Code = strHasil.Substring(20,1);
					tanggal = strHasil.Substring(25,4) + '-' + strHasil.Substring(23,2) + '-' + strHasil.Substring(21,2);
				}
				catch 
				{
					continue;
				}

				cmd.CommandText = "Select * from acc_coll where acc_no = '" + szAccNo1 + "' and coll_code = '" + szColl_Code + "' and tgl_perubahan_coll ='" + tanggal + "'";
				SqlDataReader a = cmd.ExecuteReader();
				if(!a.HasRows)
				{
					x="insert into acc_coll(acc_no,acc_type,coll_code,tgl_perubahan_coll,user_id)" +
						" values(";
				}
				else
				{
					a.Close();
					continue;
				}
				a.Close();

				cmd.CommandText = "Select * from RFUPFILE where upfile_name='ACCOUNT NUMBER' and UPFILE_GROUP='1' order by upfile_id ASC";

				a.Close();
				a = null;
				SqlDataReader dr = cmd.ExecuteReader();
				dr.Read();
				l2=dr.GetInt32(3);
				xTemp=strHasil.Substring(0,l2);
				dr.Close();				
				
				if(sudahCek==0) 
				{
					cmd.CommandText="select * from ACC_COLL where ACC_NO='" + xTemp + "'";
					dr=cmd.ExecuteReader();
					if(dr.HasRows)
					{
						dr.Close();
						cmd.CommandText="delete from ACC_COLL where ACC_NO='" + xTemp + "'";
						cmd.ExecuteNonQuery();
					}
					else
					{
						dr.Close();
					}
					sudahCek=1;
				}
				int pos=0;
				cmd.CommandText = "Select * from RFUPFILE where UPFILE_GROUP='1' order by upfile_id ASC";
				dr = cmd.ExecuteReader();
				while(dr.Read())
				{
					int intStart,intLength = 0;
					intStart=pos;
					intLength=dr.GetInt32(3);
					if(dr.GetString(2)=="N")
					{
						xTemp=strHasil.Substring(pos,intLength);
						l1=dr.GetInt32(4);
						if(l1>0)
						{
							xTemp=xTemp.Substring(0,intLength-l1)+"."+ xTemp.Substring(intLength-l1,l1);
						}
						x=x+xTemp;
					}
					else if(dr.GetString(2)=="C")
					{
						try
						   {
							   xTemp=strHasil.Substring(pos,intLength);
							   if(dr.GetString(1)=="ACCOUNT NUMBER")
							   {
								   strCekNol=strHasil.Substring(pos,intLength);
								   for(int i=0;i<strCekNol.Length;i++)
								   {
									   if(strCekNol.Substring(0+i,1).Equals("0"))
									   {
									   }
									   else
									   {
										   strCekNol=strCekNol.Substring(i,strCekNol.Length-i);
										   i=strCekNol.Length;
									   }
								   }
								   xTemp=strCekNol;
							   }
						   }
						catch (Exception)
						{

						}
						x=x+"'"+xTemp+"'";
						
						
						//x=x+"'"+strHasil.Substring(pos,intLength)+"'";
					}
					else if(dr.GetString(2)=="D")
					{
						string strTgl;
						strTgl=	strHasil.Substring(pos,intLength);
						strTgl=strTgl.Substring(2,2)+"/"+strTgl.Substring(0,2)+"/"+strTgl.Substring(4,4);
						x=x+"'"+strTgl+"'";
					}
					pos=pos+intLength;
					if(pos<strHasil.Length)
					{
						x=x+",";
					}
					else
					{
						x=x+")";
					}
				}
				dr.Close(); 
				try 
				{
					cmdIn.CommandText=x;
					cmdIn.ExecuteNonQuery();
				}
				catch{}

			}
			#endregion			

			#region Upload Parameter

			/////////////////////////////////////////////////////////////////////////////////////////
			/// Create file for history log
			/// filename : PARAMDOWNLOAD_<date>.LOG
			/// directory : C:\ParamdownloadLog
			/// 
			StreamWriter _filePtr = null;

			string _logfilename = "PARAMDOWNLOAD_";
			_logfilename = _logfilename + DateTime.Now.ToString("yyyyMMMddmmss") + ".LOG";			

			string _logdir = @"C:\LOSSME_ParamdownloadLog";

			if (!Directory.Exists(_logdir)) 
				Directory.CreateDirectory(_logdir);			

			_filePtr = File.CreateText(_logdir + "\\" + _logfilename);

			///////////////////// END OF CREATE FILE ////////////////////////////////////////////////
			

			string upFile_Group = "3";
			string seqFlag = "1";
			//SqlDataReader dr1;
			DataTable dt1;
			int noRec=0;
			/*************************************************************************
			 * Use standard database connection, by using Connection object (yudi)
			 * ***********************************************************************
			SqlConnection con1 = new  SqlConnection();	
			con1.ConnectionString = conn.connString;
			con1.Open();
			SqlCommand cmd1 = con1.CreateCommand();
			*/

			/***************************************************************************************************
			 * Get Parameter Download status to decide (APP_PARAMETER)
			 * 1 : On
			 * 0 : Off
			 ***************************************************************************************************/
			conn.QueryString = "select PARAMDOWNLOAD_STATUS from app_parameter";
			conn.ExecuteQuery(); 
			if (conn.GetFieldValue("PARAMDOWNLOAD_STATUS")=="1")
			{
				//////////////////////////////////////////////////////////////////////////////
				/// Upload Paramtere from Host (eMas)
				/// 
				if (!File.Exists(@"C:\Inetpub\ftproot\LCUCPARA")) 
				{
					GlobalTools.popMessage(this, "File C:\\Inetpub\\ftproot\\LCUCPARA tidak ditemukan !");
					return;
				}

				StreamReader sr3 = File.OpenText(@"C:\Inetpub\ftproot\LCUCPARA");
				strHasil = "";
				l1 = 0; l2 = 0;
				x = "";xTemp = "";
				sudahCek = 0;

				/*
				cmd1.CommandText = "delete from para_upload";
				cmd1.ExecuteNonQuery();
				*/
				conn.QueryString = "delete from para_upload";
				conn.ExecuteNonQuery();
			
				int k = 0;
				while ((strHasil = sr3.ReadLine()) != null)
				{
					noRec++;
					x = "insert into para_upload(paraid,filename,detail1,detail2,detail3,detail4,detail5," +
						"detail6,detail7,detail8,detail9,detail10,detail11,detail12,detail13,detail14,detail15,detail16,detail17,uploadflag) values(";
					int pos = 0;

					//////////////////////////////////////////////////////////////////////////////
					/// Mengambil panjang string
					/// 
					conn1.QueryString = "EXEC SP_UPFILE_TTL_LENGTH_GET '" + upFile_Group + "'";
					conn1.ExecuteQuery();
					int intNormalLength = 0;
					try { intNormalLength = Convert.ToInt32(conn1.GetFieldValue("Jum"));  } 
					catch {}

					/*
					cmd1.CommandText = "Select * from RFUPFILE where UPFILE_GROUP='3'";
					dr1 = cmd1.ExecuteReader();
					*/
					conn.QueryString = "select * from RFUPFILE where UPFILE_GROUP = '3'";
					conn.ExecuteQuery();
					dt1 = conn.GetDataTable().Copy();

					if (seqFlag == "1") 
					{
						x = x + noRec + ",";
					}

					//while(dr1.Read())
					for(int i=0; i < dt1.Rows.Count; i++)
					{
						int intStart, intLength = 0;
						intStart = pos;

						//intLength = dr1.GetInt32(3);
						try { intLength = Convert.ToInt32(dt1.Rows[i][3]); } 
						catch {}

						//if(dr1.GetString(2) == "N")
						if (dt1.Rows[i][2].ToString() == "N")	//////////// Numeric Data Type
						{
							//Pernah, muncul karaketer aneh di LCUCPARA, yaitu : "Ã"						

							xTemp = strHasil.Substring(pos,intLength);

							//////////////////////////////////////////
							/// Get decimal point
							//l1 = dr1.GetInt32(4);
							try { l1 = Convert.ToInt32(dt1.Rows[i][4].ToString()); } 
							catch {}

							if(l1>0)
							{
								xTemp = xTemp.Substring(0,intLength-l1) + "." + xTemp.Substring(intLength-l1,l1);
							}
							x = x + xTemp;
						}
						//else if(dr1.GetString(2)=="C")
						else if (dt1.Rows[i][2].ToString() == "C")	////////////////// Character Data Type
						{
							if(pos < strHasil.Length)
							{
								try
								{
									/////////////////////////////////////////////////////////////////
									/// Note : karaketer apostrop (') diganti dengan string kosong
									/// 
									x = x + "'" + strHasil.Substring(pos,intLength).Trim().Replace("'","") + "'";
								}
								catch (Exception exc) 
								{									
									_filePtr.WriteLine(DateTime.Now.ToString());
									_filePtr.WriteLine("UploadTextFileAccount() ERROR1 :");
									_filePtr.WriteLine(exc.ToString());
									_filePtr.WriteLine("=================================================================================================================================");					
								}
							}
						}
						//else if(dr1.GetString(2)=="D")
						else if (dt1.Rows[i][2].ToString() == "D") ///////////////// Date Data Type
						{
							/////////////////////////////////////////////
							/// Construct date format : dd/mm/yyyy
							/// 
							string strTgl;
							strTgl = strHasil.Substring(pos,intLength);
							strTgl = strTgl.Substring(2,2) + "/"+strTgl.Substring(0,2) + "/"+strTgl.Substring(4,4);
							x = x + "'" + strTgl + "'";
						}
						pos = pos + intLength;
						if(pos < intNormalLength)	
						{
							x = x + ",";
						}
						else
						{
							x = x + ")";
						}
					}

					//dr1.Close(); 					

					k++;

					conn.QueryString = x;
					try 
					{ 
						conn.ExecuteNonQuery();
					} 
					catch (Exception ex1) 
					{
						_filePtr.WriteLine(DateTime.Now.ToString());
						_filePtr.WriteLine("UploadTextFileAccount() ERROR2 :");
						_filePtr.WriteLine(ex1.ToString());
						_filePtr.WriteLine("=================================================================================================================================");					
					}

					/*
					cmdIn = con.CreateCommand();
					cmdIn.CommandText=x;
					try {
						cmdIn.ExecuteNonQuery();
					}
					catch(Exception) {
						//sr3.Close(); 
					}
					*/

				}//end read line

				_filePtr.WriteLine(DateTime.Now.ToString());
				_filePtr.WriteLine("Read LCUCPARA file ended ...");
				_filePtr.WriteLine("=================================================================================================================================eof");
				
				if (sr1 != null) sr1.Close(); 
				if (sr2 != null) sr2.Close(); 
				if (sr3 != null) sr3.Close();

				downloadParameter2(_filePtr);

				/////////////////////////////////////////
				/// backup file
				/// 
				/// "C:\Inetpub\ftproot\LCUCPARA"
				/// 
				try 
				{ 
					conn.QueryString = "select convert(varchar,getdate(),112) + replace(convert(varchar,getdate(),108),':','') date";
					conn.ExecuteQuery();			

					File.Move(@"C:\Inetpub\ftproot\LCUCPARA", @"C:\backup2\LCUCPARA" + conn.GetFieldValue("date")); 

					_filePtr.WriteLine(DateTime.Now.ToString());
					_filePtr.WriteLine("Moving file LCUCPARA ended ...");
					_filePtr.WriteLine("=================================================================================================================================eof");
				} 
				catch (Exception ex)
				{
					_filePtr.WriteLine(DateTime.Now.ToString());
					_filePtr.WriteLine("UploadTextFileAccount() ERROR3 :");
					_filePtr.WriteLine(ex.ToString());
					_filePtr.WriteLine("=================================================================================================================================eof");
				}


				/// Close Log File pointer
				/// 
				if (_filePtr != null) _filePtr.Close();
			}

			#endregion

		}
	}
}
