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
using System.IO;
using System.Configuration;

namespace SME.Synchronization
{
	/// <summary>
	/// Summary description for GenerateText.
	/// </summary>
	public partial class GenerateText : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		DataTable ds1,ds2,ds3,ds4;
		string strWhere = "";
		string currheader = "0";
		StreamWriter FileTemp;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			conn.ExecuteQuery(600);
			return conn.GetDataTable().Copy();
		}

		private string CopyOfChar(char ch, int i)
		{
			if ( i < 1) return "";
			return new string(ch, i);
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

		private void BackupFiles()
		{
			try
			{
				conn.QueryString = "SELECT * FROM VW_EMASSYNC_PARAM";
				conn.ExecuteQuery();
				string backup_folder = conn.GetFieldValue("BACKUP_FOLDER");

				if (!Directory.Exists(backup_folder)) 
				{
					Directory.CreateDirectory(backup_folder);
				}

				conn.QueryString = "SELECT CONVERT(VARCHAR,GETDATE(),112) + REPLACE(CONVERT(VARCHAR,GETDATE(),108),':','') DATETIME";
				conn.ExecuteQuery();
				string currDateTime = conn.GetFieldValue("DATETIME");

				conn.QueryString = "SELECT * FROM RFGRFILE WHERE GRFILE_TYPE = '4' AND GRFILE_CREATE = '1'";
				conn.ExecuteQuery();

				for(int i=0; i<conn.GetRowCount(); i++) 
				{
					string grfile_dir = "", grfile_filename = "", fullpath = "";

					grfile_dir = conn.GetFieldValue(i, "GRFILE_DIR");
					grfile_filename = conn.GetFieldValue(i, "GRFILE_FILENAME");
					fullpath = @grfile_dir + grfile_filename;

					string backupFullpath = "";
					try 
					{
						if (File.Exists(fullpath)) 
						{
							backupFullpath = backup_folder + grfile_filename + currDateTime;
							File.Copy(fullpath, backupFullpath, true);
						}
					} 
					catch (Exception ex) 
					{
						Response.Write("<!-- " + ex.Message + " -->");
						Response.Write("<!-- fullpath: " + fullpath + " -->");
						Response.Write("<!-- backupFullpath: " + backupFullpath + " -->");
					}
				}
			}
			catch (Exception e)
			{
				Response.Write("<!--" + e.ToString() + "-->");
				return;
			}
		}

		private void GenerateTextFile()
		{
			ds1 = sqlQuery("SELECT * FROM RFGRFILE WHERE GRFILE_TYPE = '4' AND GRFILE_CREATE = '1'");
			for (int i = 0;i < GetRowCount(ds1);i++)
			{			    				
				string lvgr_id = GetFieldValue(ds1,i,"GRFILE_ID");
				string lvpath = GetFieldValue(ds1,i,"GRFILE_DIR");
				string lvfilename = GetFieldValue(ds1,i,"GRFILE_NAME");				
				string lvfile = GetFieldValue(ds1,i,"GRFILE_FILENAME");
				string lvheader = GetFieldValue(ds1,i,"GRFILE_HEADER");
				string lvfooter = GetFieldValue(ds1,i,"GRFILE_FOOTER");
				string lv_create = GetFieldValue(ds1,i,"GRFILE_CREATE");
				string lvtabel = GetFieldValue(ds1,i,"GRFILE_TABLECOND");					
				string lvfield = strWhere;

				int jmlrec = 0;				
				Create_teksfile(lvgr_id,lvpath,lvfile,lvheader,lvfooter,lvtabel,lvfield,lv_create,ref jmlrec);				
				LST_MEMO.Items.Add("Create '"+ lvfilename +"' file record count : "+jmlrec);
				currheader = lvheader;
			}
		}

		public void Create_teksfile(string gr_id, string strPath, string strfilename,string strheader,string strfooter,string strtable,string strfield,string strcreate,ref int jmlcount)
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
			int oldJmli; 
			
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
						if (GetFieldValue(ds2,i,"DTFILE_FIELDPARAMKEY").IndexOf(",",j) > 0 )
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
			wheresqlteks = wheresqlteks/* +" and "+ strfield*/;

			selectsqlteks = selectsqlteks +" "+ formsqlteks +" "+ wheresqlteks;

			bool mandatori_result = true;
			try
			{
				ds3 = sqlQuery(selectsqlteks);
			}
			catch
			{
				LST_MEMO.Items.Add("Query Error");				
				//Response.Write("query :" + selectsqlteks+"<BR>");
			}																
			
			if (mandatori_result)
			{
				fullfilename = strPath +"\\"+ strfilename;
				if (GetRowCount(ds3) > 0)
				{				
					//create New if not exist
					if (!Directory.Exists(strPath))
					{
						Directory.CreateDirectory(strPath);
					}						
			
					//if (File.Exists(fullfilename)== false)
					if (true)
					{
						FileTemp = File.CreateText(fullfilename);
						//FileTemp.WriteLine(createheader(fullfilename,"0"));
						FileTemp.WriteLine(strheader);					//mod by nyoman
						for (int i = 0;i < GetRowCount(ds3);i++)
						{				
							for (k = 0;k < GetColCount(ds3);k++)
							{					
								string dt_name=GetFieldValue(ds2,k,"DTFILE_NAME");
								string dt_type = GetFieldValue(ds2,k,"DTFILE_ATTRIBUTE");
								int dt_length = Convert.ToInt32(GetFieldValue(ds2,k,"DTFILE_LENGTH"));
								int dt_dec = Convert.ToInt32(GetFieldValue(ds2,k,"DTFILE_DEC"));
								string dt_format = GetFieldValue(ds2,k,"DTFILE_FORMAT");
								string dt_mandatory = GetFieldValue(ds2,k,"DTFILE_MANDATORY");	
								bool negative;
								negative = false;

								teksdata = GetFieldValuecol(ds3,i,k);																						

								if (dt_type == "C")
								{
									if (teksdata.Length>= dt_length)
									{
										teksdata = teksdata.Substring(0,dt_length);
									}
										//									else if(dt_name == "CIF NUMBER")
										//									{														
										//										teksdata = CopyOfChar('0',dt_length - teksdata.Length) + teksdata;
										//									}
									else
									{														
										teksdata = teksdata + CopyOfChar(' ',dt_length - teksdata.Length);
									}
									FileTemp.Write(teksdata);
								}

								if (dt_type == "A") //alphanumeric rata kanan
								{
									if (teksdata.Length>= dt_length)
									{
										teksdata = teksdata.Substring(0,dt_length);
									}
									else
									{														
										teksdata = CopyOfChar(' ',dt_length - teksdata.Length) + teksdata;
									}
									FileTemp.Write(teksdata);
								}
						
								if (dt_type == "N")
								{
									if (teksdata.Length > dt_length)
									{
										if (teksdata.IndexOf(",",0) > 0 )
										{
											teksdata = teksdata.Substring(0,dt_length);
											string fdepan = teksdata.Substring(0,teksdata.IndexOf(",",0));
											string fbelakang = teksdata.Substring(teksdata.IndexOf(",",0)+1,teksdata.Length-(teksdata.IndexOf(",",0)+1));
											teksdata = CopyOfChar('0',dt_length - dt_dec - fdepan.Length)+fdepan+fbelakang+CopyOfChar('0',dt_dec - fbelakang.Length);								
										}
										else
										{
											teksdata = teksdata.Substring(0,dt_length);
										}
									}
									else
									{														
										dt_length = dt_length - dt_dec;
										if (teksdata.IndexOf(",",0) > 0 )
										{
											string fdepan = teksdata.Substring(0,teksdata.IndexOf(",",0));
											string fbelakang = teksdata.Substring(teksdata.IndexOf(",",0)+1,teksdata.Length-(teksdata.IndexOf(",",0)+1));
											teksdata = CopyOfChar('0',dt_length - fdepan.Length)+fdepan+fbelakang+CopyOfChar('0',dt_dec - fbelakang.Length);								
										}
										else
										{
											teksdata = CopyOfChar('0',dt_length - teksdata.Length)+teksdata+CopyOfChar('0',dt_dec);								
										}											
									}
									FileTemp.Write(teksdata);
								}
								/*
																if (dt_type == "AN")
																{
																	teksdata = teksdata.Replace(".",",");

																	if (teksdata==""){teksdata="0";}
																	if (Convert.ToDouble(teksdata)<0)
																	{
																		teksdata = teksdata.Replace("-","");
																		negative= true;
																	}

																	if (teksdata.Length > dt_length)
																	{
																		if (teksdata.IndexOf(",",0) > 0 )
																		{
																			string fdepan = teksdata.Substring(0,teksdata.IndexOf(",",0));
																			string fbelakang = teksdata.Substring(teksdata.IndexOf(",",0)+1,teksdata.Length-(teksdata.IndexOf(",",0)+1));
																			//teksdata = CopyOfChar('0',dt_length - fdepan.Length)+fdepan+fbelakang+CopyOfChar('0',dt_dec - fbelakang.Length);								
																			teksdata = fdepan+CopyOfChar('0',dt_length - fdepan.Length);
																		}
																		else
																		{
																			teksdata = teksdata.Substring(0,dt_length);
																		}
																	}
																	else
																	{														
																		dt_length = dt_length - dt_dec;
																		if (teksdata.IndexOf(",",0) > 0 )
																		{
																			string fdepan = teksdata.Substring(0,teksdata.IndexOf(",",0));
																			string fbelakang = teksdata.Substring(teksdata.IndexOf(",",0)+1,teksdata.Length-(teksdata.IndexOf(",",0)+1));
																			teksdata = CopyOfChar('0',dt_length - fdepan.Length)+fdepan+fbelakang+CopyOfChar('0',dt_dec - fbelakang.Length);								
																		}
																		else
																		{
																			teksdata = CopyOfChar('0',dt_length - teksdata.Length)+teksdata+CopyOfChar('0',dt_dec);								
																		}											
																	}
																	if (negative)
																	{
																		teksdata=teksdata+"-";
																	}
																	else
																	{
																		teksdata=teksdata+" ";
																	}

																	FileTemp.Write(teksdata);
																}
								*/

								if (dt_type == "AN")
								{
									teksdata = teksdata.Replace(".",",");

									if (teksdata==""){teksdata="0";}
									if (System.Convert.ToDouble(teksdata)<0)
									{
										teksdata = teksdata.Replace("-","");
										negative= true;
									}

									if (teksdata.IndexOf(",",0) > 0 ) // Kalau DATANYA memiliki koma
									{

										string fdepan = teksdata.Substring(0,teksdata.IndexOf(",",0));
										string fbelakang = teksdata.Substring(teksdata.IndexOf(",",0)+1,teksdata.Length-(teksdata.IndexOf(",",0)+1));

										//Sesuaikan digit depan
										if (fdepan.Length <= (dt_length-dt_dec))  
										{
											teksdata = CopyOfChar('0',(dt_length-dt_dec) - fdepan.Length)+fdepan;
										} 
										else
										{
											teksdata = fdepan.Substring(0,(dt_length-dt_dec));
										}

										//Sesuaikan digit belakang
										if (fbelakang.Length <= dt_dec)
										{					
											teksdata = teksdata + fbelakang + CopyOfChar('0',dt_dec - fbelakang.Length);
										}
										else
										{
											teksdata = teksdata + fbelakang.Substring(0,dt_dec);
										}
									}
									else
									{
										//Kalau DATANYA tidak ada komanya
										//Sesuaikan digit depan
										string fdepan = teksdata;
										if (fdepan.Length <= (dt_length-dt_dec))  
										{
											teksdata = CopyOfChar('0',(dt_length-dt_dec) - fdepan.Length)+fdepan+CopyOfChar('0',dt_dec);
										} 
										else
										{
											teksdata = fdepan.Substring(0,(dt_length-dt_dec))+CopyOfChar('0',dt_dec);
										}				
									}

									if (negative)
									{
										teksdata=teksdata+"-";
									}
									else
									{
										teksdata=teksdata+" ";
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
						/*
						ds4 = sqlQuery("select * from RFFILE_REFERANCE where FL_TYPE = '0'");
						string filename = GetFieldValuecol(ds4,0,2);
						string dir = GetFieldValuecol(ds4,0,3)+"\\";
						string pathfile = dir + filename;				
						if (File.Exists(pathfile) || !File.Exists(pathfile))
						{								
							string fileContent = "";
							if (File.Exists(pathfile))
							{
								StreamReader FileTempinput = new StreamReader(pathfile);
								fileContent = FileTempinput.ReadLine();
								FileTempinput.Close();
								fileContent = fileContent.Substring(0,16);
							}								
							mod by nyoman */
						StreamReader FileTempoutput = new StreamReader(fullfilename);						
						//ArrayList arraylst = new ArrayList();
						string fileheader = FileTempoutput.ReadLine();
						FileTempoutput.Close();
						fileheader = fileheader.Substring(0,16);
						
						//if (fileContent == fileheader)
						if (fileheader == strheader)
						{
							//ListBox1.Items.Add("Header Sama");	--> append to file 
							string strFileTmp = fullfilename + "_TMP", line, nextline;
							StreamWriter objFileTmp = new StreamWriter(strFileTmp);
							objFileTmp.WriteLine (strheader);

							StreamReader objFile = new StreamReader(fullfilename);
							line = objFile.ReadLine();	//read header
							if (line == null)
								oldJmli = 0;
							else
							{
								oldJmli = 0;
								nextline = objFile.ReadLine();
								while (nextline != null)	//read next lines
								{
									line = nextline;
									nextline = objFile.ReadLine();
									if (nextline == null)	//line contain the last line (footer)
										break;
									objFileTmp.WriteLine (line);
									oldJmli++;
								}
							}
							objFile.Close();
							objFileTmp.Close();
							File.Copy(strFileTmp,fullfilename,true);	//overwrite old file 
							File.Delete(strFileTmp);					//delete temp file 

							StreamWriter fileTempappend = new StreamWriter(fullfilename,true);	//append to file 
							//fileTempappend.WriteLine(createheader(fullfilename,"0"));
							for (int i = 0;i < GetRowCount(ds3);i++)
							{
								for (k = 0;k < GetColCount(ds3);k++)
								{
									string dt_name=GetFieldValue(ds2,k,"DTFILE_NAME");
									string dt_type = GetFieldValue(ds2,k,"DTFILE_ATTRIBUTE");
									int dt_length = Convert.ToInt32(GetFieldValue(ds2,k,"DTFILE_LENGTH"));
									int dt_dec = Convert.ToInt32(GetFieldValue(ds2,k,"DTFILE_DEC"));
									string dt_format = GetFieldValue(ds2,k,"DTFILE_FORMAT");
									string dt_mandatory = GetFieldValue(ds2,k,"DTFILE_MANDATORY");
									bool negative;
									negative = false;

						
									teksdata = GetFieldValuecol(ds3,i,k);															
										
									if (dt_type == "C")
									{
										if (teksdata.Length>= dt_length)
										{
											teksdata = teksdata.Substring(0,dt_length);
										}
										else if(dt_name == "CIF NUMBER")
										{														
											teksdata = CopyOfChar('0',dt_length - teksdata.Length) + teksdata;
										}
										else
										{														
											teksdata = teksdata + CopyOfChar(' ',dt_length - teksdata.Length);
										}
										fileTempappend.Write(teksdata);
									}

									if (dt_type == "A") //alphanumeric rata kanan
									{
										if (teksdata.Length>= dt_length)
										{
											teksdata = teksdata.Substring(0,dt_length);
										}
										else
										{														
											teksdata = CopyOfChar(' ',dt_length - teksdata.Length) + teksdata;
										}
										fileTempappend.Write(teksdata);
									}
						
									if (dt_type == "N")
									{
										if (teksdata.Length > dt_length)
										{
											if (teksdata.IndexOf(",",0) > 0 )
											{
												string fdepan = teksdata.Substring(0,teksdata.IndexOf(",",0));
												string fbelakang = teksdata.Substring(teksdata.IndexOf(",",0)+1,teksdata.Length-(teksdata.IndexOf(",",0)+1));
												teksdata = CopyOfChar('0',dt_length - fdepan.Length)+fdepan+fbelakang+CopyOfChar('0',dt_dec - fbelakang.Length);								
											}
											else
											{
												teksdata = teksdata.Substring(0,dt_length);
											}
										}
										else
										{														
											dt_length = dt_length - dt_dec;
											if (teksdata.IndexOf(",",0) > 0 )
											{
												string fdepan = teksdata.Substring(0,teksdata.IndexOf(",",0));
												string fbelakang = teksdata.Substring(teksdata.IndexOf(",",0)+1,teksdata.Length-(teksdata.IndexOf(",",0)+1));
												teksdata = CopyOfChar('0',dt_length - fdepan.Length)+fdepan+fbelakang+CopyOfChar('0',dt_dec - fbelakang.Length);								
											}
											else
											{
												teksdata = CopyOfChar('0',dt_length - teksdata.Length)+teksdata+CopyOfChar('0',dt_dec);								
											}											
										}
										FileTemp.Write(teksdata);
									}
									/*
																		if (dt_type == "AN")
																		{
																			teksdata = teksdata.Replace(".",",");

																			if (teksdata==""){teksdata="0";}

																			if (Convert.ToDouble(teksdata)<0)
																			{
																				teksdata = teksdata.Replace("-","");
																				negative= true;
																			}


																			if (teksdata.Length > dt_length)
																			{
																				if (teksdata.IndexOf(",",0) > 0 )
																				{
																					string fdepan = teksdata.Substring(0,teksdata.IndexOf(",",0));
																					string fbelakang = teksdata.Substring(teksdata.IndexOf(",",0)+1,teksdata.Length-(teksdata.IndexOf(",",0)+1));
																					teksdata = CopyOfChar('0',dt_length - fdepan.Length)+fdepan+fbelakang+CopyOfChar('0',dt_dec - fbelakang.Length);								
																				}
																				else
																				{
																					teksdata = teksdata.Substring(0,dt_length);
																				}
																			}
																			else
																			{														
																				dt_length = dt_length - dt_dec;
																				if (teksdata.IndexOf(",",0) > 0 )
																				{
																					string fdepan = teksdata.Substring(0,teksdata.IndexOf(",",0));
																					string fbelakang = teksdata.Substring(teksdata.IndexOf(",",0)+1,teksdata.Length-(teksdata.IndexOf(",",0)+1));
																					teksdata = CopyOfChar('0',dt_length - fdepan.Length)+fdepan+fbelakang+CopyOfChar('0',dt_dec - fbelakang.Length);								
																				}
																				else
																				{
																					teksdata = CopyOfChar('0',dt_length - teksdata.Length)+teksdata+CopyOfChar('0',dt_dec);								
																				}											
																			}
																			if (negative)
																			{
																				teksdata=teksdata+"-";
																			}
																			else
																			{
																				teksdata=teksdata+" ";
																			}

																			FileTemp.Write(teksdata);
																		}
									*/

									if (dt_type == "AN")
									{
										teksdata = teksdata.Replace(".",",");

										if (teksdata==""){teksdata="0";}
										if (System.Convert.ToDouble(teksdata)<0)
										{
											teksdata = teksdata.Replace("-","");
											negative= true;
										}

										if (teksdata.IndexOf(",",0) > 0 ) // Kalau DATANYA memiliki koma
										{

											string fdepan = teksdata.Substring(0,teksdata.IndexOf(",",0));
											string fbelakang = teksdata.Substring(teksdata.IndexOf(",",0)+1,teksdata.Length-(teksdata.IndexOf(",",0)+1));

											//Sesuaikan digit depan
											if (fdepan.Length <= (dt_length-dt_dec))  
											{
												teksdata = CopyOfChar('0',(dt_length-dt_dec) - fdepan.Length)+fdepan;
											} 
											else
											{
												teksdata = fdepan.Substring(0,(dt_length-dt_dec));
											}

											//Sesuaikan digit belakang
											if (fbelakang.Length <= dt_dec)
											{					
												teksdata = teksdata + fbelakang + CopyOfChar('0',dt_dec - fbelakang.Length);
											}
											else
											{
												teksdata = teksdata + fbelakang.Substring(0,dt_dec);
											}
										}
										else
										{
											//Kalau DATANYA tidak ada komanya
											//Sesuaikan digit depan
											string fdepan = teksdata;
											if (fdepan.Length <= (dt_length-dt_dec))  
											{
												teksdata = CopyOfChar('0',(dt_length-dt_dec) - fdepan.Length)+fdepan+CopyOfChar('0',dt_dec);
											} 
											else
											{
												teksdata = fdepan.Substring(0,(dt_length-dt_dec))+CopyOfChar('0',dt_dec);
											}				
										}

										if (negative)
										{
											teksdata=teksdata+"-";
										}
										else
										{
											teksdata=teksdata+" ";
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
								jmli = i + oldJmli;
							}
							jmli = jmli + 1;
							fileTempappend.WriteLine(jmli.ToString("0000"));
							fileTempappend.Close();

						}
						else  // string header in file(s) is not the same as in database
						{
							//ListBox1.Items.Add("Header Beda");							
							//ArrayList arraylst = new ArrayList();
							//string sheader = createheader(fullfilename,"1");
							string sheader = strheader;
							//arraylst.Add(sheader);
							StreamReader fileTempappend = new StreamReader(fullfilename);							
							int n = 0;
							string temp = "";
							string temp_regno = "";
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
									/*if (gr_id == "01" && fileTempappend.Peek() != -1)
										{
											temp_regno = temp.Substring(266,20);																								
										}	
										else if (gr_id == "02" && fileTempappend.Peek() != -1)
										{
											temp_regno = temp.Substring(0,20);
										}
										else if (gr_id == "03" && fileTempappend.Peek() != -1)
										{
											temp_regno = temp.Substring(0,20);
										}
										else if (gr_id == "04" && fileTempappend.Peek() != -1)
										{
											temp_regno = temp.Substring(170,20);
										}
										else if (gr_id == "05" && fileTempappend.Peek() != -1)
										{
											temp_regno = temp.Substring(155,20);
										}
										else if (gr_id == "06" && fileTempappend.Peek() != -1)
										{
											temp_regno = temp.Substring(0,20);
										}
										else if (gr_id == "07" && fileTempappend.Peek() != -1)
										{
											temp_regno = temp.Substring(27,20);
										}
										else if (gr_id == "08" && fileTempappend.Peek() != -1)
										{
											temp_regno = temp.Substring(19,20);
										}
										*/
									conn.QueryString = "select isnull(grfile_regnooffset,0) from rfgrfile " +
										"where grfile_id = '" + gr_id + "' ";
									conn.ExecuteQuery();
									try
									{
										if (fileTempappend.Peek() != -1)
										{
											temp_regno = temp.Substring(int.Parse(conn.GetFieldValue(0,0)),20);
										}
									} 
									catch {}
								}	
								n++;
							}							
							fileTempappend.Close();
							//ListBox2.Items[ListBox2.Items.Count -1].Text = "";

							StreamWriter filetempsave;
							filetempsave = File.CreateText(fullfilename);
							/*
							for (n = 0;n < ListBox2.Items.Count ;n++)
							{								
								filetempsave.WriteLine(ListBox2.Items[n]);	
							}
							-------------  
							Cheng - the program always fall into here ...
							please check with Upload Text File, HEADER is now forever can never
							be the SAME again.
							Hence, forget about appending for the moment, later we will change it to EXTRACT
							ALL RECORDS from pending eMAS.
							------------*/
													
							/// Masukkan header
							filetempsave.WriteLine(ListBox2.Items[0]);	
							n = 1;	// header counter

							jmli = 0;
							jmli = (jmli + n)-1;
							for (int i = 0;i < GetRowCount(ds3);i++)
							{				
								for (k = 0;k < GetColCount(ds3);k++)
								{
									string dt_name=GetFieldValue(ds2,k,"DTFILE_NAME");
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
										else if(dt_name == "CIF NUMBER")
										{														
											teksdata = CopyOfChar('0',dt_length - teksdata.Length) + teksdata;
										}
										else
										{														
											teksdata = teksdata + CopyOfChar(' ',dt_length - teksdata.Length);
										}
										filetempsave.Write(teksdata);
									}

									if (dt_type == "A") //alphanumeric rata kanan
									{
										if (teksdata.Length>= dt_length)
										{
											teksdata = teksdata.Substring(0,dt_length);
										}
										else
										{														
											teksdata = CopyOfChar(' ',dt_length - teksdata.Length) + teksdata;
										}
										filetempsave.Write(teksdata);
									}
						
									if (dt_type == "N")
									{
										if (teksdata.Length >= dt_length)
										{
											if (teksdata.IndexOf(",",0) > 0 )
											{
												string fdepan = teksdata.Substring(0,teksdata.IndexOf(",",0));
												string fbelakang = teksdata.Substring(teksdata.IndexOf(",",0)+1,teksdata.Length-(teksdata.IndexOf(",",0)+1));
												teksdata = CopyOfChar('0',dt_length - fdepan.Length)+fdepan+fbelakang+CopyOfChar('0',dt_dec - fbelakang.Length);								
											}
											else
											{
												teksdata = teksdata.Substring(0,dt_length);
											}
										}
										else
										{														
											dt_length = dt_length - dt_dec;
											if (teksdata.IndexOf(",",0) > 0 )
											{
												string fdepan = teksdata.Substring(0,teksdata.IndexOf(",",0));
												string fbelakang = teksdata.Substring(teksdata.IndexOf(",",0)+1,teksdata.Length-(teksdata.IndexOf(",",0)+1));
												teksdata = CopyOfChar('0',dt_length - fdepan.Length)+fdepan+fbelakang+CopyOfChar('0',dt_dec - fbelakang.Length);								
											}
											else
											{
												teksdata = CopyOfChar('0',dt_length - teksdata.Length)+teksdata+CopyOfChar('0',dt_dec);								
											}
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

						//}					
					}
				}
				else	//GetRowCount(ds3) == 0
				{
					if (strcreate == "0") 
					{
						if (!Directory.Exists(strPath))
						{
							Directory.CreateDirectory(strPath);
						}						
			
						if (File.Exists(fullfilename)== false)
						{				
							FileTemp = File.CreateText(fullfilename);
							FileTemp.Close();
						}
						else
						{
							try
							{
								StreamReader FileTemp2 = new StreamReader(fullfilename);
								string oldheader = FileTemp2.ReadLine();
								FileTemp2.Close();
								oldheader = oldheader.Substring(0,16);
								if (oldheader != strheader)
								{
									FileTemp = File.CreateText(fullfilename);
									//FileTemp.WriteLine(createheader(fullfilename,"0"));
									FileTemp.WriteLine(strheader);
									jmli = 0;
									FileTemp.WriteLine(jmli.ToString("0000"));
									FileTemp.Close();
								}
							}
							catch {}
						}
					}
					else	//strcreate != "0"
					{
						if (!Directory.Exists(strPath))
						{
							Directory.CreateDirectory(strPath);
						}						
			
						if (File.Exists(fullfilename)== false)
						{				
							FileTemp = File.CreateText(fullfilename);
							//FileTemp.WriteLine(createheader(fullfilename,"0"));
							FileTemp.WriteLine(strheader);
							jmli = 0;
							FileTemp.WriteLine(jmli.ToString("0000"));
							FileTemp.Close();
						}
						else
						{
							try
							{
								StreamReader FileTemp2 = new StreamReader(fullfilename);
								string oldheader = FileTemp2.ReadLine();
								FileTemp2.Close();
								oldheader = oldheader.Substring(0,16);
								if (oldheader != strheader)
								{
									FileTemp = File.CreateText(fullfilename);
									//FileTemp.WriteLine(createheader(fullfilename,"0"));
									FileTemp.WriteLine(strheader);
									jmli = 0;
									FileTemp.WriteLine(jmli.ToString("0000"));
									FileTemp.Close();
								}
							} 
							catch {}
						}
					}
				}
				jmlcount = jmli;	
			}// end mandatori_result == true  
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

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			BackupFiles();
			GenerateTextFile();
		}
	}
}
