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
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.InitialDataEntry
{
	/// <summary>
	/// Summary description for PerubahanLimit.
	/// </summary>
	public partial class PerubahanLimit : System.Web.UI.Page
	{

		#region " Variables "

		string strWhere;
		protected Tools tool = new Tools();
		DataTable ds1,ds2,ds3,ds4;
		StreamWriter FileTemp;
		protected int i = 0;
		string noTrack;
		protected Connection conn;
		//protected string mainregno, mainprod_seq, mainproductid;

		#endregion


		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			cekIsView(Request.QueryString["view"]);

			if (!IsPostBack)
			{				
				LBL_MAINREGNO.Text = Request.QueryString["mainregno"];
				LBL_MAINPROD_SEQ.Text = Request.QueryString["mainprod_seq"];
				LBL_MAINPRODUCTID.Text = Request.QueryString["mainproductid"];							
				LBL_USERID.Text = Session["UserID"].ToString();

				/* ashari */

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

				/* ashari */			
				

				DDL_APPTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_FACILITYNO.Items.Add(new ListItem("- PILIH -", ""));
				DDL_AA_NO.Items.Add(new ListItem("- PILIH -", ""));
				DDL_PRODUCTID.Items.Add(new ListItem("- PILIH -", ""));

				conn.QueryString = "select apptypeid, apptypedesc from rfapplicationtype where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_APPTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				try { DDL_APPTYPE.SelectedValue = Request.QueryString["app"]; } catch {}

				//--- Tujuan Penggunaan
				conn.QueryString = "select LOANPURPID, LOANPURPID + ' - ' + LOANPURPDESC as LOANPURPDESC from RFLOANPURPOSE where ACTIVE='1' order by LOANPURPID";
				conn.ExecuteQuery();
				DDL_CP_LOANPURPOSE.Items.Add(new ListItem("- PILIH -", ""));
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CP_LOANPURPOSE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				/*
				conn.QueryString = "select distinct(cp_facilityno) from vw_ide_loaninfo where cu_ref='" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_FACILITYNO.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
				*/

				if (Request.QueryString["curefchann"] == "" || Request.QueryString["curefchann"] == null) 
					conn.QueryString = "select distinct aa_no from bookedprod where cu_ref='" + Request.QueryString["curef"] + "'";
				else 
					conn.QueryString = "select distinct aa_no from bookedprod where cu_ref='" + Request.QueryString["curefchann"] + "'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_AA_NO.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));

				ViewApplications();

				/****
				conn.QueryString = "select withfairisaac from rfprogram where programid='" + Request.QueryString["prog"] + "'";
				conn.ExecuteQuery();
				string withFairIsaac = conn.GetFieldValue(0,0);
				if (withFairIsaac == "0")
				{
					Button2.Visible = false;
					Button1.Visible = true;
				}
				else
				{
					conn.QueryString = "select cu_cif from customer where cu_ref='" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();
					if (conn.GetFieldValue(0,0) == "")
					{
						Button2.Visible = true;
						Button1.Visible = false;
					}
					else
					{
						Button2.Visible = false;
						Button1.Visible = true;
					}
				}
				if (DATAGRID1.Items.Count != 0)
				{
					Button1.Enabled = true;
					Button2.Enabled = true;
				}
				****/

				/// If program allows withdrawal ( from his own facility and account ), then
				/// customer is allowed to choose withdrawal
				///  
				conn.QueryString = "select withdrawl from rfprogram where programid='" + Request.QueryString["prog"] + "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue(0,0) == "0")
					DDL_APPTYPE.Items.Remove(DDL_APPTYPE.Items.FindByValue("06"));
				

				viewData();

				ViewState.Add("noTrack",noTrack);
				ViewState.Add("strWhere",strWhere);
			}
			else
			{
				noTrack = (string)ViewState["noTrack"];
				strWhere = (string)ViewState["strWhere"];
			}
			
	
			//DisplayMenu();
			
			//BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
            BTN_SAVE.Attributes.Add("onclick", "if(!cek_mandatory(document.getElementById('Form1'))){return false;};if(!SaveMsg()){return false;};");
			Button1.Attributes.Add("onclick","if(!update()){return false;};");
		}

		private double getInstallmentValue()
		{
			/// PERLU DIPERHATIKAN : Untuk menghitung installment, jenis aplikasi diperhatikan.
			/// o Kalau dalam 1 ketentuan kredit hanya mencakup RENEWAL saja, perhatikan jenis tenornya (Tenor / Maturity Date).
			///   Kalau Maturity Date, maka tenornya adalah Maturity Date - Current Date
			/// o Kalau dalam 1 ketentuan kredit hanya mencakup PERUBAHAN LIMIT saja, maka Tenornya adalah 
			///   Maturity Date di BookedCust - Current Date
			///   

			double result = 0;
			string vISINSTALLMENT = "";

			/// Mengambil flag installment untuk facility yang dipilih
			/// 
			conn.QueryString = "select calcmethod, isinstallment from rfproduct where productid = '" + DDL_PRODUCTID.SelectedValue + "'";
			conn.ExecuteQuery();
			vISINSTALLMENT = conn.GetFieldValue("isinstallment");

			/// Mengambil limit (menggunakan stored procedure yang dipakai di scoring bcg)
			/// Mengambil Tenor
			/// Mengambil interest
			/// 
			conn.QueryString = "exec IDE_LOANINFO_GETINSTALLMENT '" + Request.QueryString["regno"] + 
				"', '" + Request.QueryString["curef"] + 
				"', '" + Request.QueryString["ket_code"] + "'";
			conn.ExecuteQuery();
			string vEXLIMITVAL, vCP_INTEREST, vTENOR;
			vEXLIMITVAL = "0.00";
			vCP_INTEREST = "0.00";
			vTENOR = "0.00";

			if (vISINSTALLMENT == "1") // installment
			{
				vEXLIMITVAL  = conn.GetFieldValue("CP_EXLIMITVAL").ToString().Trim();				
				vCP_INTEREST = conn.GetFieldValue("CP_INTEREST").ToString().Trim();
				vTENOR       = conn.GetFieldValue("TENOR").ToString().Trim();
				result = DMS.CuBESCore.Logic.hitungInstalment(double.Parse(vEXLIMITVAL), int.Parse(vTENOR), double.Parse(vCP_INTEREST), DDL_PRODUCTID.SelectedValue, "M", conn);
			}
			else if (vISINSTALLMENT == "0") // bukan installment
			{
				result = double.Parse(vCP_INTEREST) / 100 * double.Parse(vEXLIMITVAL) / 12;
			}

			return result;
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
			this.DATAGRID1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATAGRID1_ItemCommand);

		}
		#endregion

		private void cekIsView(string view) 
		{
			if (view == "1") 
			{
				TR_JENISPENGAJUAN.Visible = false;
				TR_BUTTONS.Visible = false;
			}
		}

		private void viewData() 
		{
			//-- Yudi
			//Untuk kebutuhan KETENTUAN KREDIT, kalau permohonan baru dalam satu ketentuan kredit
			//tidak bisa bergabung dengan jenis pengajuan lain.				
			DDL_APPTYPE.Items.Remove(DDL_APPTYPE.Items.FindByValue("01"));

			//TODO : Ubah query menjadi view !
			/***
				conn.QueryString = "select * " +
					"from ketentuan_kredit k " +
					"inner join bookedprod b on k.aa_no = b.aa_no and k.acc_seq = b.acc_seq " +
					"where KET_CODE = '" + Request.QueryString["ket_code"] + "'";
				***/
			conn.QueryString = "select * from KETENTUAN_KREDIT where KET_CODE ='" + Request.QueryString["ket_code"] + "'";					
			conn.ExecuteQuery();
				

			try { DDL_AA_NO.SelectedValue = conn.GetFieldValue("AA_NO"); } catch {}

			DDL_PRODUCTID.Items.Add(new ListItem("- PILIH -",""));
			DDL_FACILITYNO.Items.Add(new ListItem("- PILIH -",""));
			DDL_PRODUCTID.Items.Add(new ListItem(conn.GetFieldValue("PRODUCTID"), conn.GetFieldValue("PRODUCTID")));
			DDL_FACILITYNO.Items.Add(new ListItem(conn.GetFieldValue("ACC_SEQ"), conn.GetFieldValue("ACC_SEQ")));

			try { DDL_FACILITYNO.SelectedValue = conn.GetFieldValue("ACC_SEQ"); } catch {}
			try { DDL_PRODUCTID.SelectedValue = conn.GetFieldValue("PRODUCTID"); } catch {}
			LBL_PRODUCTID.Text = conn.GetFieldValue("PRODUCTID");


			DDL_AA_NO.Enabled = false;
			DDL_PRODUCTID.Enabled = false;
			DDL_FACILITYNO.Enabled = false;		

			LBL_PRODUCTID.Text = DDL_PRODUCTID.SelectedValue;

			/// get account number
			string _accno = conn.GetFieldValue("ACC_NO");
			if (_accno == null) _accno = "";
			try { _accno = _accno.Trim(); } 
			catch {}
			
			conn.QueryString = "select a.LIMIT, a.TENOR, a.TENORCODE, rt.tenordesc, PRODUCTDESC, LOANPURPID from bookedprod a " + 
								"inner join rftenorcode rt on a.tenorcode = rt.tenorcode " + 
								"inner join rfproduct rp on a.productid=rp.productid " +
								"where aa_no='" + DDL_AA_NO.SelectedValue + 
									"' and a.productid='" + DDL_PRODUCTID.SelectedValue + 
									"' and acc_seq = '" + DDL_FACILITYNO.SelectedValue +
									"' and a.acc_no = '" + _accno + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				TXT_LIMIT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LIMIT"));
				TXT_TENORDESC.Text = conn.GetFieldValue(0, "TENOR") + " " + conn.GetFieldValue(0, "TENORDESC");
				TXT_PRODUCTDESC.Text = conn.GetFieldValue(0, "productdesc");

				LBL_OLDJANGKAWKT.Text = conn.GetFieldValue(0, "TENOR");
				try {DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue(0, "LOANPURPID");}
				catch {}
			}
		}


		public void Create_teksfile(string gr_id, string strPath,string strfilename,string strheader,string strfooter,string strtable,string strfield,string strcreate,ref int jmlcount)
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
			wheresqlteks = wheresqlteks +" and  apptrack.ap_regno='" + Request.QueryString["regno"] + "'";

			selectsqlteks = selectsqlteks +" "+ formsqlteks +" "+ wheresqlteks;
			bool mandatori_result = true;						
			try
			{
				ds3 = sqlQuery(selectsqlteks);
			}
			catch
			{
				//LST_MEMO.Items.Add("Query Error");								
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
										if (k==1||k==5)
										{
											teksdata = CopyOfChar('0',dt_length - teksdata.Length)+ teksdata;
										}
										else
										{
											teksdata = teksdata + CopyOfChar(' ',dt_length - teksdata.Length);
										}
									}
									FileTemp.Write(teksdata);
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
												if (k==1||k==5)
												{
													teksdata = CopyOfChar('0',dt_length - teksdata.Length)+ teksdata;
												}
												else
												{
													teksdata = teksdata + CopyOfChar(' ',dt_length - teksdata.Length);
												}
											}
											fileTempappend.Write(teksdata);
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
										if (gr_id == "01" && fileTempappend.Peek() != -1)
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
										if (!checkdata(temp_regno) && (fileTempappend.Peek() != -1) )										
										{
											ListBox2.Items.Add(temp);											
										}											
										if (fileTempappend.Peek() == -1)
										{
											ListBox2.Items.Add(temp);
										}
									}	
									n++;
								}							
								fileTempappend.Close();
								//ListBox2.Items[ListBox2.Items.Count -1].Text = "";

								StreamWriter filetempsave;
								filetempsave = File.CreateText(fullfilename);

								for (n = 0;n < ListBox2.Items.Count-1 ;n++)
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
												if (k==1||k==5)
												{
													teksdata = CopyOfChar('0',dt_length - teksdata.Length)+ teksdata;
												}
												else
												{
													teksdata = teksdata + CopyOfChar(' ',dt_length - teksdata.Length);
												}
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

						}					
					}				
				}
				else
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
					}
					else
					{
						if (!Directory.Exists(strPath))
						{
							Directory.CreateDirectory(strPath);
						}						
			
						if (File.Exists(fullfilename)== false)
						{				
							FileTemp = File.CreateText(fullfilename);
							FileTemp.WriteLine(createheader(fullfilename,"0"));
							jmli = 0;
							FileTemp.WriteLine(jmli.ToString("0000"));
							FileTemp.Close();
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

		private bool checkdata(string regno)
		{
			conn.QueryString = "select count(*) jml from uptext_success a join custproduct b on a.ap_regno = b.ap_regno and a.productid= b.productid where b.ap_regno+convert(varchar,cp_seq) = '"+regno+"'";
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

		private string AmbilKondisi()
		{
			conn.QueryString = "select * from rfgrfile where GRFILE_CREATE = '1' and GRFILE_TYPE='1'";
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
				}
				else
				{
					cek = false;
				}
			}
			return lvfield;
		}

		private void viewExchangeRate() 
		{
			try 
			{
				conn.QueryString = "select PRODUCTID, CURRENCY, C.CURRENCYRATE " +
					"from RFPRODUCT p " +
					"left join RFCURRENCY c on P.CURRENCY = C.CURRENCYID " +
					"where C.ACTIVE = '1' and P.ACTIVE = '1' and PRODUCTID = '" + LBL_PRODUCTID.Text + "'";
				conn.ExecuteQuery();

				TXT_CP_EXRPLIMITCHGTO.Text = conn.GetFieldValue("CURRENCYRATE");
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error !");
				return;
			}
		}

		private string getNextStepMsg(string regno) 
		{
			string pesan = "";
			string nextTrack = "";
			try 
			{
				/***
				 * Memunculkan pesan next step
				 ***/
				conn.QueryString = "exec TRACKNEXTMSG '" + regno + "'";
				conn.ExecuteQuery();
				nextTrack = conn.GetFieldValue("TRACKNAME");
				pesan = "Application proceeds to " + nextTrack;
				/***********************************/
			} 
			catch 
			{
				throw new Exception();
			}

			return pesan;
		}

		/*
		private void DisplayMenu()
		{
			HyperLink GeneralInfo = new HyperLink();
			GeneralInfo.Text = "Informasi Umum";
			GeneralInfo.NavigateUrl = "GeneralInfo.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"];

			Menu.Controls.Add(GeneralInfo);
		}
		*/

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			/***
			conn.QueryString = "select count (*) from cust_product where ap_regno='" + Request.QueryString["regno"] + "' and apptype='" + 
				DDL_APPTYPE.SelectedValue + "' and productid='" + DDL_PRODUCTID.SelectedValue + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue(0,0) != "0")
			{
				//ClearSelections();
				Response.Write("<script language='javascript'>alert('Permohonan yg sama pada produk yg diminta!');</script>");
			}

			else
			{
			***/

			/// Check whether the facility is a channeling facility and if it is, then it's only valid
			/// if he himself is a channeling company
			/// 			
			/*
			conn.QueryString = "select * from VW_IDE_CHANNFAC_STATUS where productid = '" + LBL_PRODUCTID.Text + "' and cu_ref = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();			
			if (conn.GetRowCount() > 0) 
			{
			*/
			conn.QueryString = "exec IDE_CEK_CHANNFACILITY '" + Request.QueryString["curef"] + 
				"', '" + DDL_PRODUCTID.SelectedValue + 
				"', '" + DDL_AA_NO.SelectedValue + 
				"', '" + DDL_FACILITYNO.SelectedValue + 
				"', '" + Request.QueryString["ket_code"] + "'";
			conn.ExecuteQuery();

			string isChannFacility = conn.GetFieldValue("ISCHANNFACILITY");
			string ch_channelComp = conn.GetFieldValue("CU_CHANNELCOMP");
			if (isChannFacility == "1" && ch_channelComp == "0")  // condition #1
			{
				/// check condition #2 ... before it can be increased
				/// 
				if (conn.GetFieldValue("HASACCOUNTNUMBER") == "1") 
				{
					GlobalTools.popMessage(this, "Anda tidak bisa melakukan perubahan limit karena facility yang dipilih \\nadalah CHANNELING FACILITY dan Anda bukan CHANNELING COMPANY.");
					return;
				}
				/*
				conn.QueryString = "select * from bookedprod where cu_ref = '" + Request.QueryString["curef"] + "'" +
					" and aa_no = '" + DDL_AA_NO.SelectedValue + 
					"' and productid = '" + DDL_PRODUCTID.SelectedValue + 
					"' and acc_seq = '" + DDL_FACILITYNO.SelectedValue + 
					"' and ( acc_no is null or len(ltrim(rtrim(acc_no))) = 0 ) ";
				conn.ExecuteQuery();
				if ( conn.GetRowCount() == 0 ) 
				{
					GlobalTools.popMessage(this, "Anda tidak bisa melakukan perubahan limit karena facility yang dipilih \\nadalah CHANNELING FACILITY dan Anda bukan CHANNELING COMPANY.");
					return;
				}
				*/
			}

			/*}*/

			//cek apakah sudah pernah disimpan di custproduct apa belum
			//jika untuk application type dan kode kredit yang sama sudah ada maka jangan diinsert lagi
			bool isNewApp = true;
			string ket_code = Request.QueryString["ket_code"];

			try
			{
				if (ket_code == "" || ket_code == null || ket_code == "&nbsp;") 
				{
					conn.QueryString  = "select KET_CODE from KETENTUAN_KREDIT where ";
					conn.QueryString += "AP_REGNO = '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
					ket_code = conn.GetFieldValue("KET_CODE");				
				}

				conn.QueryString  = "select APPTYPE from CUSTPRODUCT where ";
				conn.QueryString += "AP_REGNO = '" + Request.QueryString["regno"] + "' and ";
				conn.QueryString += "KET_CODE = '" + ket_code + "' and ";
				conn.QueryString += "APPTYPE = '" + DDL_APPTYPE.SelectedValue + "'";
				conn.ExecuteQuery();

				//jika sudah pernah ada, flag application type baru = false
				if (conn.GetRowCount() > 0) isNewApp = false;
			}
			catch(Exception)
			{
				GlobalTools.popMessage(this, "Server error");
			}			
			//------------------------------//

			if (isNewApp) //belum ada ketentuan kredit untuk aplikasi yang dipilih
			{
				/// TODO : Disable sementara, nanti dihidupkan lagi
				/// 
				// string vINSTALLMENT = this.getInstallmentValue().ToString();

				try
				{
					conn.QueryString = "exec IDE_LOANINFO_UBAHLIMIT '" + Request.QueryString["regno"] + "', '" + 
						Request.QueryString["curef"] + "', '" + 
						DDL_APPTYPE.SelectedValue + "', " + 
						tool.ConvertFloat(TXT_CP_EXLIMITCHGTO.Text) + ", " + 
						tool.ConvertFloat(TXT_CP_EXRPLIMITCHGTO.Text) + ", " + 
						tool.ConvertFloat(TXT_CP_LIMITCHGTO.Text) + ", '" + 
						TXT_CP_NOTES.Text + "', " + 
						DDL_FACILITYNO.SelectedValue + ", '" + 
						DDL_AA_NO.SelectedValue + "', '" + 
						DDL_PRODUCTID.SelectedValue + "', '" +
						DDL_CP_LIMITCHG.SelectedValue + "', '" + 
						ket_code + "', '" +
						DDL_CP_LOANPURPOSE.SelectedValue + "'";
					conn.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					string errmsg = ex.Message.Replace("'","");
					if (errmsg.IndexOf("Last Query:") > 0)
						errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
					GlobalTools.popMessage(this, errmsg);
					return;
				}

				//--- menyimpan data parent application untuk jika sub application --//
				try 
				{
					conn.QueryString = "exec IDE_LOANINFO_SUBAPP '" + 
						Request.QueryString["regno"] + "', '" + 
						DDL_APPTYPE.SelectedValue + "', '" + 
						DDL_PRODUCTID.SelectedValue + "', '" + 
						LBL_MAINREGNO.Text+ "', '" +
						LBL_MAINPRODUCTID.Text + "', '" + 
						LBL_MAINPROD_SEQ.Text + "'";
					conn.ExecuteNonQuery();					
				} 
				catch (NullReferenceException) 
				{
					GlobalTools.popMessage(this, "Connection Error!");
					return;
				}

				/****
				conn.QueryString = "insert into app_track (ap_regno, apptype, productid, ap_currtrack, ap_currtrackdate, ap_currtrackby) " + 
					"values ('" + Request.QueryString["regno"] + "', '" + 
					DDL_APPTYPE.SelectedValue + "', '" + 
					DDL_PRODUCTID.SelectedValue + "', '" + Request.QueryString["tc"] + "', getdate(), '" + LBL_USERID.Text + "')";
					//DDL_PRODUCTID.SelectedValue + "', '" + Request.QueryString["tc"] + "', getdate(), '" + Session["UserID"].ToString() + "')";
				conn.ExecuteNonQuery();
		
				conn.QueryString = "select count(*) from track_history where ap_regno='" + Request.QueryString["regno"] + "' and apptype='" + DDL_APPTYPE.SelectedValue + "' and productid='" + DDL_PRODUCTID.SelectedValue + "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue(0,0) == "0")
				{
					conn.QueryString = "insert into track_history (ap_regno, apptype, productid, trackcode, th_seq, th_trackdate, th_trackby) values " + 
						"('" + Request.QueryString["regno"] + "', '" + DDL_APPTYPE.SelectedValue + "', '" + DDL_PRODUCTID.SelectedValue + "', '" + Request.QueryString["tc"] + "', 1, getdate(), '" + LBL_USERID.Text + "')";
						//"('" + Request.QueryString["regno"] + "', '" + DDL_APPTYPE.SelectedValue + "', '" + DDL_PRODUCTID.SelectedValue + "', '" + Request.QueryString["tc"] + "', 1, getdate(), '" + Session["UserID"].ToString() + "')";
					conn.ExecuteNonQuery();
				}
				***/
				conn.QueryString = "exec IDE_LOANINFO_GENERAL '" + 
					Request.QueryString["regno"] + "', '" + 
					DDL_APPTYPE.SelectedValue + "', '" + 
					LBL_PRODUCTID.Text + "', '" + 
					Request.QueryString["tc"] + "', '" + 
					LBL_USERID.Text + "'";
				conn.ExecuteNonQuery();

				//ClearSelections();
				ViewApplications();
			}
			else
			{
				GlobalTools.popMessage(this, "Jenis pengajuan pinjaman yang diminta sudah ada!");
			}
			/***}***/


			Button1.Enabled = true;
			Button2.Enabled = true;
		}

		private void ClearSelections()
		{
			DDL_AA_NO.SelectedValue = "";
			DDL_PRODUCTID.SelectedValue = "";
			DDL_FACILITYNO.Visible = false;
			TXT_PRODUCTDESC.Text = "";
			LBL_PRODUCTID.Text = "";
			TXT_LIMIT.Text = "";
			TXT_TENORDESC.Text = "";
			TXT_CP_LIMITCHGTO.Text = "";
			TXT_CP_EXRPLIMITCHGTO.Text = "";
			TXT_CP_EXLIMITCHGTO.Text = "";
			TXT_CP_NOTES.Text = "";
			DDL_CP_LOANPURPOSE.SelectedValue = "";
		}

		protected void Button2_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("FairIsaac.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&prog=" + Request.QueryString["prog"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		private void ViewApplications()
		{
			DataTable dt1 = new DataTable();
			conn.QueryString = "select * from vw_ide_listapplication where ap_regno='" + Request.QueryString["regno"] + "' and KET_CODE = '" + Request.QueryString["ket_code"] + "'";
			conn.ExecuteQuery();
			dt1 = conn.GetDataTable().Copy();
			DATAGRID1.DataSource = dt1;
			DATAGRID1.DataBind();

			for (int i = 0; i < DATAGRID1.Items.Count; i++)
			{
				if (DATAGRID1.Items[i].Cells[5].Text != "&nbsp;")
					DATAGRID1.Items[i].Cells[5].Text = tool.MoneyFormat(DATAGRID1.Items[i].Cells[5].Text);
				if (DATAGRID1.Items[i].Cells[6].Text != "&nbsp;")
					DATAGRID1.Items[i].Cells[6].Text = tool.MoneyFormat(DATAGRID1.Items[i].Cells[6].Text);

				//if (DATAGRID1.Items[i].Cells[8].Text.Trim() != "&nbsp;")
				//	DATAGRID1.Items[i].Cells[8].Text = DATAGRID1.Items[i].Cells[8].Text + " Bulan";
			}
		}

		protected void DDL_APPTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// 20080727, add by sofyan for pipeline corporate
			string dflt = "1";
			conn.QueryString = "SELECT AP_BUSINESSUNIT FROM VW_APPBUSINESSUNIT WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
				if ((conn.GetFieldValue("AP_BUSINESSUNIT") == "CB100") ||
					(conn.GetFieldValue("AP_BUSINESSUNIT") == "MD100") ||
					(conn.GetFieldValue("AP_BUSINESSUNIT") == "SM100") ||
					(conn.GetFieldValue("AP_BUSINESSUNIT") == "CR100") ||
					(conn.GetFieldValue("AP_BUSINESSUNIT") == "MB100"))
					dflt = "2";

			///////////////////////////////////////////////////////////////////////////////////////////
			/// Note: if there are changes on the links below (regno, curef, prog, etc), impact to 
			///		  other pages also apply
			/// 
			if (DDL_APPTYPE.SelectedValue != "")
			{
				//conn.QueryString = "select screenlink from apptypelink where apptypeid='" + DDL_APPTYPE.SelectedValue + "' and fungsiid='IDE' and [default]='1'";
				conn.QueryString = "select screenlink from apptypelink where apptypeid='" + DDL_APPTYPE.SelectedValue + "' and fungsiid='IDE' and [default]='" + dflt + "'";
				conn.ExecuteQuery();
				string link = conn.GetFieldValue(0,0) + "?app=" + DDL_APPTYPE.SelectedValue;
				Response.Redirect(link + 
					"&regno=" + Request.QueryString["regno"] + 
					"&curef=" + Request.QueryString["curef"] + 
					"&prog=" + Request.QueryString["prog"] + 
					"&tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&ket_code=" + Request.QueryString["ket_code"] +
					"&mainregno=" + LBL_MAINREGNO.Text + 
					"&mainprod_seq=" + LBL_MAINPROD_SEQ.Text + 
					"&mainproductid=" + LBL_MAINPRODUCTID.Text + 
					"&curefchann=" + Request.QueryString["curefchann"]);
			}
		}

		protected void DDL_FACILITYNO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//conn.QueryString = "select productid, productdesc, cp_exlimitval, cp_exrplimit, cp_limit, tenordesc from vw_ide_loaninfo where cu_ref='" + Request.QueryString["curef"] + "' and cp_facilityno='" + DDL_FACILITYNO.SelectedValue + "'";
			//conn.ExecuteQuery();
			//TXT_PRODUCTDESC.Text = conn.GetFieldValue("PRODUCTDESC");
			//TXT_CP_LIMIT.Text = tool.MoneyFormat(conn.GetFieldValue("CP_LIMIT"));
			
			//LBL_PRODUCTID.Text = conn.GetFieldValue("PRODUCTID");
			LBL_PRODUCTID.Text = DDL_PRODUCTID.SelectedValue;
			
			//conn.QueryString = "select bp.limit,  from bookedprod bp where aa_no='" + DDL_AA_NO.SelectedValue + "' and productid='" + DDL_PRODUCTID.SelectedValue + "' and acc_seq='" + DDL_FACILITYNO.SelectedValue + "'";
			//conn.QueryString = "select bp.LIMIT, rt.TENORVALUE, rt.TENORDESC from bookedprod bp left join rftenor rt on bp.tenor=rt.tenorseq " + 
			//	"where bp.aa_no='" + DDL_AA_NO.SelectedValue + "' and bp.productid='" + DDL_PRODUCTID.SelectedValue + "' and bp.acc_seq='" + DDL_FACILITYNO.SelectedValue + "'";
			conn.QueryString = "select a.LIMIT, a.TENOR, a.TENORCODE, rt.tenordesc from bookedprod a inner join rftenorcode rt on a.tenorcode = rt.tenorcode where aa_no='" + DDL_AA_NO.SelectedValue + "' and productid='" + DDL_PRODUCTID.SelectedValue + "' and acc_seq=" + DDL_FACILITYNO.SelectedValue;
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				TXT_LIMIT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LIMIT"));
				TXT_TENORDESC.Text = conn.GetFieldValue(0, "TENOR") + " " + conn.GetFieldValue(0, "TENORDESC");
			}
		}

		protected void DDL_AA_NO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DDL_PRODUCTID.Items.Clear();
			DDL_PRODUCTID.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select productid from bookedcust where cu_ref='" + Request.QueryString["curef"] + "' and aa_no='" + DDL_AA_NO.SelectedValue + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_PRODUCTID.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
		}

		protected void DDL_PRODUCTID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DDL_FACILITYNO.Items.Clear();
			DDL_FACILITYNO.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select acc_seq, acc_no from bookedprod where aa_no='" + DDL_AA_NO.SelectedValue + "' and productid='" + DDL_PRODUCTID.SelectedValue + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				//DDL_FACILITYNO.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				DDL_FACILITYNO.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
			
			conn.QueryString = "select productdesc from rfproduct where productid='" + DDL_PRODUCTID.SelectedValue + "'";
			conn.ExecuteQuery();
			TXT_PRODUCTDESC.Text = conn.GetFieldValue("productdesc");

			DDL_FACILITYNO.Visible = true;

			/*
			conn.QueryString = "select bc.bc_loanamount, bc.bc_tenor, rt.tenordesc from bookedcust bc left join rftenorcode rt on bc.bc_tenorcode=rt.tenorcode where cu_ref='" + Request.QueryString["curef"] + "' and aa_no='" + DDL_AA_NO.SelectedValue + "' and productid='" + DDL_PRODUCTID.SelectedValue + "'";
			conn.ExecuteQuery();
			TXT_LIMIT.Text = tool.MoneyFormat(conn.GetFieldValue("bc_loanamount"));
			TXT_TENORDESC.Text = conn.GetFieldValue("bc_tenor") + " " + conn.GetFieldValue("tenordesc");
			*/
		}

		private void DATAGRID1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					/*
					conn.QueryString = "delete from apptrack where ap_regno='" + Request.QueryString["regno"] + "' and apptype='" + e.Item.Cells[1].Text + "' and productid='" + e.Item.Cells[3].Text + "' and PROD_SEQ = '" + e.Item.Cells[9].Text + "'";
					conn.ExecuteNonQuery();

					conn.QueryString = "delete from custproduct where ap_regno='" + Request.QueryString["regno"] + "' and apptype='" + e.Item.Cells[1].Text + "' and productid='" + e.Item.Cells[3].Text + "' and PROD_SEQ = '" + e.Item.Cells[9].Text + "'";
					conn.ExecuteNonQuery();

					conn.QueryString = "delete from trackhistory where ap_regno='" + Request.QueryString["regno"] + "' and apptype='" + e.Item.Cells[1].Text + "' and productid='" + e.Item.Cells[3].Text + "' and PROD_SEQ = '" + e.Item.Cells[9].Text + "'";
					conn.ExecuteNonQuery();
					*/

					/****************************************************************************************
					 * Kalau delete dari selain IDE, tidak bisa dilakukan jika tinggal 1 jenis pengajuan
					 *****************************************************************************************/
					conn.QueryString = "select * from scgroup_init2 where gr_key like '%IDE%' and groupid = '" + Request.QueryString["tc"] + "'";
					conn.ExecuteQuery();
					if (conn.GetRowCount() == 0 && DATAGRID1.Items.Count == 1) 
					{
						GlobalTools.popMessage(this, "Jenis Pengajuan tidak bisa dihapus karena aplikasi akan tidak memiliki kredit !");
						return;
					}
					/****************************************************************************************/


					try 
					{ 
						conn.QueryString = "exec IDE_LOANINFO_DELETE '" + 
							Request.QueryString["regno"] + "', '" + 
							e.Item.Cells[1].Text + "', '" + // apptype
							e.Item.Cells[3].Text + "', '" + // productid
							e.Item.Cells[9].Text + "'";		// prod_seq
						conn.ExecTrans();
						conn.ExecTran_Commit();
					} 
					catch (Exception ex)
					{
						if (conn != null)
							conn.ExecTran_Rollback();
						ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "ERROR DELETE : " + Request.QueryString["regno"]);
					}

					break;
			}
			ViewApplications();
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			//conn.QueryString = "select checkbi from customer where cu_ref='" + Request.QueryString["curef"] + "'";
			conn.QueryString = "select ap_checkbi from application where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				if (conn.GetFieldValue(0,0) == "1")
				{
					conn.QueryString = "insert into bi_status (ap_regno, cu_ref, bs_reqdate, bs_recvdate, bs_bidataavail, bs_complete) " + 
						"values ('" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "', getdate(), null, null, '0')";
					conn.ExecuteQuery();

					/* Start -- calling text file generation -- by ashari -- 20040930 */
				
					ds1 = sqlQuery("select * from rfgrfile where GRFILE_TYPE='1'");			
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
						string lvfield = AmbilKondisi();

						int jmlrec = 0;				
						Create_teksfile(lvgr_id,lvpath,lvfile,lvheader,lvfooter,lvtabel,lvfield,lv_create,ref jmlrec);				
					}

					/* End -- calling text file generation -- by ashari -- 20040930 */
				
				}
			}

			DataTable dt;
			conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + Request.QueryString["regno"] +
				"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				conn.QueryString = "exec TRACKUPDATE '" + 
									Request.QueryString["regno"] + "', '" +
									dt.Rows[i][1].ToString() + "', '" + 
									dt.Rows[i][0].ToString() + "', '" + 
									LBL_USERID.Text + "', '" + dt.Rows[i]["PROD_SEQ"].ToString() + "','"+Request.QueryString["tc"].Trim()+"'";
				conn.ExecuteNonQuery();
			}
			Response.Redirect("FindCustomer.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}
	}
}
