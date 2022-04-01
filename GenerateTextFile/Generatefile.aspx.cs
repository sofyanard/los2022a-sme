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
using System.Diagnostics;



namespace Create_text_booking
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
		DataTable ds1,ds2,ds3,ds4;
		protected int i = 0;
		StreamWriter FileTemp;
		protected System.Web.UI.WebControls.Button Button2;
		//string trackno;
		protected Connection conn;		
		string noTrack;
		string strWhere;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here		
			conn = (Connection) Session["Connection"];			
			
			if (!IsPostBack)
			{
				noTrack = "'"+ Request.QueryString["tc"]+"'";
				conn.QueryString = "select * from rfgrfile where GRFILE_CREATE = '1' and GRFILE_TYPE='0'";
				conn.ExecuteQuery();
				string lvfield = conn.GetFieldValue("GRFILE_FIELDCOND");				
				string templvfield =lvfield;
				int lenindex = templvfield.IndexOf("#",1); //cari #
				bool cek = true;
				if (lenindex > 0)
				{	 				
					if ((noTrack.Trim() != "")&& (noTrack.Trim() != "''"))
					{
						templvfield = lvfield.Substring(0,lenindex-1);					
						int lentanda = lvfield.IndexOf("$",0);					
						lvfield = templvfield +  noTrack + lvfield.Substring(lentanda+1);					
						strWhere = lvfield;
					}
					else
					{
						cek = false;
					}
				}
				else
				{
					strWhere = lvfield;
				}
				
				if (cek == true)
				{
					DataTable dt1 = new DataTable();
					conn.QueryString =	"select application.AP_REGNO, " +
						"application.CU_REF, " +
						"AP_RECVDATE, " +
						"case when CU_COMPNAME is null then CU_FIRSTNAME+' '+case when isnull(CU_MIDDLENAME,'')='' then ' ' else CU_MIDDLENAME+' ' end +CU_LASTNAME else CU_COMPNAME end name, " +
						"APPTYPEDESC, " +
						"custproduct.PRODUCTID,  " +
						"custproduct.PROD_SEQ " +
						"from application  " +
						"left join cust_personal on application.cu_ref = cust_personal.cu_ref  " +
						"left join cust_company on application.cu_ref = cust_company.cu_ref " +
						"left join APPTRACK on application.ap_regno = apptrack.ap_regno  " +
						"left join CUSTPRODUCT on application.ap_regno = custproduct.ap_regno and apptrack.productid = custproduct.productid and apptrack.prod_seq = custproduct.prod_seq " +
						"join rfapplicationtype on CUSTPRODUCT.APPTYPE = rfapplicationtype.APPTYPEID and apptrack.apptype = custproduct.apptype and (custproduct.apptype = '01' or custproduct.apptype = '03'or custproduct.apptype = '09' or custproduct.apptype = 'T01') " +
						"join rfproduct on rfproduct.productid = custproduct.productid and (rfproduct.ISCASHLOAN = '1' OR isnull(rfproduct.NCL_CODE,'') <> '') " +
						"where " +lvfield; 
					conn.ExecuteQuery();
					dt1 = conn.GetDataTable().Copy();
					DataGrid1.DataSource = dt1;
					DataGrid1.DataBind();					
					LST_MEMO.Items.Clear();
					for (int i = 0;i < GetRowCount(dt1);i++)
					{
						string sql1 = "select max(isnull(CP_SEQ,0)) + 1 jml from custproduct where ap_regno = '"+GetFieldValue(dt1,i,"AP_REGNO")+"'";						
						DataTable dt2 = sqlQuery(sql1);
						conn.QueryString = "update custproduct set CP_SEQ = "+GetFieldValue(dt2,0,"jml")+" where ap_regno = '"+GetFieldValue(dt1,i,"AP_REGNO")+"' and PRODUCTID = '"+GetFieldValue(dt1,i,"PRODUCTID")+"' and PROD_SEQ = '" + GetFieldValue(dt1, i, "PROD_SEQ") + "' and (CP_SEQ is null or CP_SEQ = 0)";
						conn.ExecuteQuery();						
					}	
				}
				else
				{
					LST_MEMO.Items.Add("Track Not Found");
				}
				strWhere += " and custproduct.cp_seq is not null ";
				ViewState.Add("noTrack",noTrack);
				ViewState.Add("strWhere",strWhere);
			}
			else
			{
				noTrack = (string)ViewState["noTrack"];
				strWhere = (string)ViewState["strWhere"];
			}

			Button1.Attributes.Add("onclick", "if(!generateonce()) { return false; };");
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

		/// <summary>
		/// Before generate text file (to be sent to eMAS), backup first the previous file(s)
		/// into backup directory (C:\backup2)
		/// </summary>
		private void backupFiles() 
		{
			/// Check whether the backup directory is exist or not
			/// 
			if (!Directory.Exists("C:\\backup2")) 
			{
				Directory.CreateDirectory("C:\\backup2");
			}

			/// Get the current DateTime (format ddmmyyhhmmss)
			/// 
			conn.QueryString = "select convert(varchar,getdate(),112) + replace(convert(varchar,getdate(),108),':','') datetime";
			conn.ExecuteQuery();
			string currDateTime = conn.GetFieldValue("datetime");


			/// Get Filename(s) information from database
			/// 
			conn.QueryString = "select * from rfgrfile where grfile_type = '0' and grfile_create = '1'";
			conn.ExecuteQuery();

			/// Loop for each interface file, for backing up
			/// 
			for(int i=0; i<conn.GetRowCount(); i++) 
			{
				string grfile_dir = "", grfile_filename = "", fullpath = "";

				/// Construct full path file name
				/// 
				grfile_dir = conn.GetFieldValue(i, "grfile_dir");
				grfile_filename = conn.GetFieldValue(i, "grfile_filename");
				fullpath = @grfile_dir + grfile_filename;

				string backupFullpath = "";
				try 
				{
					/// Check whether the filename exist or not
					/// 
					if (File.Exists(fullpath)) 
					{
						backupFullpath = "C:\\backup2\\" + grfile_filename + currDateTime;
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

		private void killProcesses() 
		{
			/// Fungsi ini untuk meng-kill process yang mengambang sebagai task.
			/// Process yang diambil adalah yang tanggalnya <= tanggal (dan jam) sekarang
			/// 
			conn.QueryString = "select * from PROCESSMANAGER where dateadd(hour, 1, PDATE) <= getdate()";
			conn.ExecuteQuery();
			DataTable dt = conn.GetDataTable();

			System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
			System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
			
			for(int i=0; i<dt.Rows.Count; i++) 
			{
				// Kalau ada process yang mengambang, kill process tersebut
				try 
				{
					int procId = 0;
					try { procId = Convert.ToInt32(dt.Rows[i]["PID"].ToString()); } 
					catch {}
					Process proc = Process.GetProcessById(procId);				
					if (proc != null) proc.Kill();
				} 
				catch (ArgumentException ae) 
				{
					// process already killed or doesn't exist!
				}
				catch (Exception ex) 
				{
					// untuk exception lain, ... ??
				}
				finally 
				{
					/// delete excel/word process from database
					/// per yesterdays
					/// 
					conn.QueryString = "delete from processmanager where pid = '" + dt.Rows[i]["PID"] + "' and convert(varchar, pdate, 112) < convert(varchar, getdate(), 112)";
					conn.ExecuteNonQuery();
				}

				//if (!proc.HasExited) proc.Kill();
			}
		}
	
		private void createChannelingFacilityRemainingLimitTextFile() 
		{
			/// Request for Channeling Facility remaining eMAS limit, only once per day
			/// 
			//conn.QueryString = "select distinct convert(varchar, send_date, 112) from bookingreport where convert(varchar, send_date, 112) = convert(varchar, getdate(), 112)";
			conn.QueryString = "select distinct convert(varchar, au_trackdate, 112) from audittrail_app " + 
				" where au_desc like '%generate text%' " +
				" and convert(varchar, au_trackdate, 112) = convert(varchar, getdate(), 112)";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0) return;


			System.Data.DataTable dt_string = null;
			string strFileText = "";
			string ap_regno = "", cu_ref = "";

			/// Get string text file
			/// 
			conn.QueryString = "exec UPLOAD_CHANNFACILITY_QUERY";
			conn.ExecuteQuery();			
			dt_string = conn.GetDataTable().Copy();			


			/// Insert into textfile_queue
			/// 
			for( int i = 0; i < dt_string.Rows.Count; i++) 
			{
				strFileText = dt_string.Rows[i]["TEXTFILE"].ToString();
				ap_regno	= dt_string.Rows[i]["AP_REGNO"].ToString();
				cu_ref		= dt_string.Rows[i]["CU_REF"].ToString();

				conn.QueryString = "select * from textfile_queue where text_contain like '%" + strFileText + "%'"; 
				conn.ExecuteQuery();
				if (conn.GetRowCount() == 0)
				{
					conn.QueryString = "insert into TextFile_Queue values('" + strFileText + "', '" + ap_regno + "', '" + cu_ref + "')";
					conn.ExecuteNonQuery();								
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

		private void sqlConnection1_InfoMessage(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e)
		{
		
		}

		private void check_mandatory(string gr_id,string strtable,string strfield, ref bool stop )
		{		
			string selectsqlteks = "select "; 
			string formsqlteks = "from "; 
			string wheresqlteks = "where "; 
			string temptable = "";
			string tempfield = "";			
			
			DateTime dt = new DateTime();
			int indextable = 0;
			int j;
			int k;			
												
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

			selectsqlteks = selectsqlteks +" "+ formsqlteks +" "+ wheresqlteks;
			stop = true;			
			//query table					
			try
			{
				ds3 = sqlQuery(selectsqlteks);
			}
			catch
			{
				LST_MEMO.Items.Add("Query Error");								
			}
			

			
			//check mandatori
			//int seq = 1;								
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
							stop = false;
							break;
						}
					}
				}
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
			wheresqlteks = wheresqlteks +" and "+ strfield;

			selectsqlteks = selectsqlteks +" "+ formsqlteks +" "+ wheresqlteks;

			if (gr_id=="01")
			{
				//Response.Write("query :" + strfield+"<BR>");
				//Response.Write("query :" + selectsqlteks+"<BR>");
				//Response.End();
			}

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

									/// Check whether the application has already uploaded to eMAS
									/// 
									if (!checkdata(temp_regno) && (fileTempappend.Peek() != -1) )										
									{
										ListBox2.Items.Add(temp);											
									}											
									/*if (fileTempappend.Peek() == -1)
									{
										ListBox2.Items.Add(temp);
									}*/
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
	
		
		private string CopyOfChar(char ch, int i)
		{
			if ( i < 1) return "";
			return new string(ch, i);
		}

		/// <summary>
		/// Check whether the application has already uploaded to eMAS
		/// TRUE	=> Uploaded to eMAS
		/// FALSE	=> Not Uploaded to eMAS yet
		/// </summary>
		/// <param name="regno"></param>
		/// <returns></returns>
		private bool checkdata(string regno)
		{
			conn.QueryString = "select count(*) jml from uptext_success a " + 
				"join custproduct b " + 
				"on a.ap_regno = b.ap_regno and a.productid= b.productid " + 
				"and a.prod_seq = b.prod_seq " +
				"where b.ap_regno+convert(varchar, b.cp_seq) = '"+regno+"'";
			conn.ExecuteQuery();
			bool ada = false;
			int jml =  Convert.ToInt32(conn.GetFieldValue("jml"));
			if (jml <= 0 )
			{
				conn.QueryString = "select count(*) jml from uptext_fail where ap_regno+convert(varchar,uf_cpseq) = '"+regno+"'";
				conn.ExecuteQuery();
				jml =  Convert.ToInt32(conn.GetFieldValue("jml"));
				if (jml > 0 )
				{
					ada = true;
				}

			}
			else
			{
				ada = true;
			}
			return(ada);
		}

		private void updatetoreport(string regno,string productid)
		{
			conn.QueryString = "select isnull(max(seq),0)+1 seq from bookingreport where ap_regno = '"+ regno +"' and productid = '"+ productid +"' ";
			conn.ExecuteQuery();
			string seq = conn.GetFieldValue("seq");
			try
			{
				conn.QueryString = "insert into bookingreport(ap_regno,seq,send_date,result,productid) values('"+regno+"','"+seq+"',getdate(),'1','"+ productid +"')";
				conn.ExecuteNonQuery();			
			}
			catch
			{}
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

		protected void Button1_Click(object sender, System.EventArgs e)
		{	
			try 
			{ 
				/// Before generate, backup file(s) first
				/// 
				backupFiles();
			} 
			catch (Exception ex)
			{
				try { ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "Backup Files on Generate"); } 
				catch {}
			}
										
			bool Chk_mandatory = true;
			string currheader = "0";


			/*ds1 = sqlQuery("select * from rfgrfile where GRFILE_CREATE = '1'");						
			for (int i = 0;i < GetRowCount(ds1);i++)
			{
				string lvgr_id = GetFieldValue(ds1,i,"GRFILE_ID");				
				string lvtabel = GetFieldValue(ds1,i,"GRFILE_TABLECOND");				
				string lvfield = strWhere;
				LST_MEMO.Items.Clear();
				//check_mandatory(lvgr_id,lvtabel,lvfield,ref Chk_mandatory);				
				if (Chk_mandatory==false)
				{
					break;
				}				
			}*/
			if (Chk_mandatory)
			{
				LST_MEMO.Items.Clear();

				////////////////////////////////////////////////////////////////////
				/// hapus fail lama agar tidak ada duplicate fail-message
				/// 
				conn.QueryString = "exec UPLOAD_DELUPFAIL '" + strWhere.Replace("'","''") + "' ";
				conn.ExecuteNonQuery();

				//ds1 = sqlQuery("select * from rfgrfile where GRFILE_CREATE = '1'");			
				ds1 = sqlQuery("select * from rfgrfile where GRFILE_TYPE='0'");			
				for (int i = 0;i < GetRowCount(ds1);i++)
				{			    				
					//string lvgr_id = GetFieldValue(ds1,i,"GRFILE_ID");
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

				//creating reference file 
				conn.QueryString = "select FL_NAME, FL_DIR from RFFILE_REFERANCE where FL_TYPE = '0'";
				conn.ExecuteQuery();
				string filename = conn.GetFieldValue(0,0);
				string dir = conn.GetFieldValue(0,1)+"\\";
				string pathfile = dir + filename;
				FileTemp = File.CreateText(pathfile);
				FileTemp.WriteLine(currheader);
				FileTemp.Close();
				
				string dttable = GetFieldValue(ds1,1,"GRFILE_TABLECOND");				
				string dtfield = strWhere;

				/*string sql = "select * from application a join apptrack b on a.ap_regno = b.ap_regno where "+dtfield;
				DataTable vds5 = sqlQuery(sql);						
				string regno = "";
				for (int i = 0;i < GetRowCount(vds5);i++)
				{
					regno = GetFieldValue(vds5,i,"AP_REGNO");
					string sql1 = "select apptype, productid from cust_product where ap_regno='" + regno +
								  "' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'') <> '1'";
					DataTable vds1 = sqlQuery(sql1);				
					for (int j = 0; j < GetRowCount(vds1); j++)
					{
						string sql2 = "exec TRACKUPDATE '" + regno + "','"+ GetFieldValue(vds1,j,"productid") + "', '" + GetFieldValue(vds1,j,"apptype") + "', '" + "endi"//Session["UserID"].ToString() 
							+ "'";
						DataTable vds2 = sqlQuery(sql2);										
					}
				}*/

				try 
				{
					/// fungsi untuk create channeling facility remaining eMAS limit
					/// dilakukan 1 hari 1 kali
					/// 
					createChannelingFacilityRemainingLimitTextFile();
				}
				catch (Exception ex)
				{
					try { ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "Create Chann Fac on Generate"); } 
					catch {}
				}


				DataTable dt1 = new DataTable();
				//String str,strKondisi;
				
				//conn.QueryString="select * from rfgrfile";
				//strKondisi=conn.ExecuteQuery(); 

				conn.QueryString =	"select distinct application.AP_REGNO,custproduct.productid " +				
					"from application  " +
					"left join cust_personal on application.cu_ref = cust_personal.cu_ref  " +
					"left join cust_company on application.cu_ref = cust_company.cu_ref " +
					"left join APPTRACK on application.ap_regno = apptrack.ap_regno  " +
					"left join CUSTPRODUCT on application.ap_regno = custproduct.ap_regno and apptrack.productid = custproduct.productid and apptrack.prod_seq = custproduct.prod_seq " +
					"join rfapplicationtype on CUSTPRODUCT.APPTYPE = rfapplicationtype.APPTYPEID and apptrack.apptype = custproduct.apptype and (custproduct.apptype = '01' or custproduct.apptype = '03'or custproduct.apptype = '09' or custproduct.apptype = 'T01') " +
					"join rfproduct on rfproduct.productid = custproduct.productid and rfproduct.ISCASHLOAN = '1' " +
					"where " +dtfield; 
				conn.ExecuteQuery();
				ds4 = conn.GetDataTable().Copy();
				for(int j = 0; j < GetRowCount(ds4) ;j++)
				{
					updatetoreport(GetFieldValue(ds4,j,"AP_REGNO"),GetFieldValue(ds4,j,"productid"));
				}
				
				conn.QueryString = "update application set AP_BOOKFLAG = '1' from apptrack, custproduct " + 
					"where application.ap_regno = apptrack.ap_regno " + 
					"and application.ap_regno = custproduct.ap_regno " + 
					"and apptrack.productid = custproduct.productid  " +
					"and apptrack.prod_seq = custproduct.prod_Seq and " +
					dtfield;
				conn.ExecuteNonQuery();
				conn.QueryString =	"select application.AP_REGNO,application.CU_REF,AP_RECVDATE, " +
					"case when CU_COMPNAME is null then CU_FIRSTNAME+' '+case when isnull(CU_MIDDLENAME,'')='' then ' ' else CU_MIDDLENAME+' ' end +CU_LASTNAME else CU_COMPNAME end name, " +
					"apptypedesc " +
					"from application left join cust_personal on application.cu_ref = cust_personal.cu_ref " +
					"join custproduct on application.ap_regno = custproduct.ap_regno " +
					"left join cust_company on application.cu_ref = cust_company.cu_ref " +
					"left join rfapplicationtype atp on atp.apptypeid = custproduct.apptype " +
					"left join APPTRACK on application.ap_regno = apptrack.ap_regno and apptrack.productid = custproduct.productid and apptrack.prod_seq = custproduct.prod_seq where " +dtfield;
				conn.ExecuteQuery();
				dt1 = conn.GetDataTable().Copy();
				DataGrid1.DataSource = dt1;
				DataGrid1.DataBind();
				

				/// Create account request
				/// 
				CreateAccountRequestTextFile();
			}
			else
			{
				LST_MEMO.Items.Add("Generate Text Stop");
			}

			try 
			{ 
				/// Meng-kill process yang mengambang
				/// 
				killProcesses(); 
			}
			catch (Exception ex)
			{
				try { ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "Kill Proc on Generate"); } 
				catch {}
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
				try { ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "Audit on Generate"); } 
				catch {}
			}
		}

		private void upload_filesuccess()
		{
			ds2 = sqlQuery("select * from RFFILE_REFERANCE where FL_TYPE = '1'");
			string filename = GetFieldValue(ds2,0,"FL_DIR")+GetFieldValue(ds2,0,"FL_NAME");
			StreamReader file_succ = new StreamReader(filename);			
			while (file_succ.Peek() != -1)
			{
				string filetemp = file_succ.ReadLine();																
				string fl_ap_regno = filetemp.Substring(0,20);			
				string fl_cifno = filetemp.Substring(20,19);			
				string fl_accno = filetemp.Substring(39,19);			
				string fl_aano = filetemp.Substring(58,20);			
				string fl_fac = filetemp.Substring(78,3);			
				string fl_seq = filetemp.Substring(81,9);			
				string fl_loanammount = filetemp.Substring(90,17);			
				string fl_disbdate = filetemp.Substring(107,6);			
				
				string filequery = "'"+fl_ap_regno+"','"+fl_cifno+"','"+fl_accno+"','"+fl_aano+"','"+fl_fac+"','"+fl_seq+"','"+fl_loanammount+"','"+fl_disbdate+"'";
				conn.QueryString = "insert into uptext_success(AP_REGNO,US_CIFNO,US_ACCNO,US_AANO,US_FAC,US_SEQ,US_LOANAMMOUNT,US_DISBDATE) values ("+filequery+")";				
				try
				{
					conn.ExecuteNonQuery();
				}
				catch
				{
					
				}

			}						
		}

		private void upload_filefail()
		{
			ds2 = sqlQuery("select * from RFFILE_REFERANCE where FL_TYPE = '2'");
			string filename = GetFieldValue(ds2,0,"FL_DIR")+GetFieldValue(ds2,0,"FL_NAME");
			StreamReader file_fail = new StreamReader(filename);			
			while (file_fail.Peek() != -1)
			{
				
				string filetemp = file_fail.ReadLine();																
				string p_proc_date	= filetemp.Substring(0,6);			
				string p_branch	= filetemp.Substring(6,5);			
				string p_ap_regno = filetemp.Substring(11,20);			
				string p_name		= filetemp.Substring(31,40);			
				string p_err_type	= filetemp.Substring(71,3);			
				string p_err_cd	= filetemp.Substring(74,3);			
				string p_err_desc	= filetemp.Substring(77,60);			
				string p_err_data	= filetemp.Substring(137,60);			
				string p_seq_f		= filetemp.Substring(197,4);																		
				
				conn.QueryString = "select * from uptext_fail where ap_regno = '"+p_ap_regno+"'";
				conn.ExecuteQuery();
				int seq = 1;
				if (conn.GetRowCount() > 0)
				{
					conn.QueryString = "select max(UF_SEQLOCAL)+1 from uptext_fail where ap_regno = '"+p_ap_regno+"'";
					conn.ExecuteQuery();
					seq = int.Parse(conn.GetFieldValue(0,0));
				}				

				string filequery = ""+seq+",'"+p_proc_date+"','"+p_branch+"','"+p_ap_regno+"','"+p_name+"','"+p_err_type+"','"+p_err_cd+"','"+p_err_desc+"','"+p_err_data+"','"+p_seq_f+"'";
				conn.QueryString = "insert into uptext_fail(UF_SEQLOCAL,UF_DATE,UF_BRANCH,AP_REGNO,UF_NAME,UF_ERRORTYPE,UF_ERRORCD,UF_DESC,UF_DATA,UF_SEQ) values ("+filequery+")";				
				try
				{
					conn.ExecuteNonQuery();
				}
				catch
				{
					
				}
				
				

			}						
		}


		void CreateAccountRequestTextFile()
		{
			conn.QueryString="select * from textfile_queue";
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
			{
				StreamWriter fileTemp;							
				fileTemp = File.CreateText(@"C:\Inetpub\ftproot\LCUCINQTX");
				fileTemp.WriteLine(createheader("C:\\Inetpub\\ftproot\\LCUCINQTX","0"));
				for(int i=0;i<conn.GetRowCount();i++)
				{
					fileTemp.Write(conn.GetFieldValue(i,0));
					fileTemp.WriteLine();
				}
				int x = conn.GetRowCount();
				string hasil;
				string s=x.ToString();
				hasil=s;
				for (int i = 0; i < 4 - s.Length; i++)
					hasil = "0" + hasil;
				fileTemp.Write(hasil);
				fileTemp.Close();
			}
			LST_MEMO.Items.Add("Create LCUCINQTX file record count : " + conn.GetRowCount());																	
			conn.QueryString="delete from textfile_queue";
			conn.ExecuteNonQuery();
		}
		

		protected void ListBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
		}

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}


		protected void ListBox2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	
	}
}
