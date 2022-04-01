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
using Earmarking;
using SME;


namespace ketentuankredit.loan
{
	/// <summary>
	/// Summary description for KetentuanKredit.
	/// </summary>
	public partial class KetentuanKredit : System.Web.UI.Page
	{
	
		#region " My Variables "

		private Tools tool = new Tools();
		private DataTable ds1, ds2, ds3;
		string strWhere;
		protected int i = 0;
		string noTrack;
		bool iscorpapp = false;
		private string regno, curef, prog, tc, mc, mainregno, exist, va, presco, mainprod_seq, mainproductid;
		protected Connection conn;

		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
            
			mainregno		= Request.QueryString["mainregno"];		//optional!, berasal dari sub application (DE)
			mainprod_seq	= Request.QueryString["mainprod_seq"];	//idem
			mainproductid	= Request.QueryString["mainproductid"];	//idem
			regno			= Request.QueryString["regno"];			//mandatory!
			curef			= Request.QueryString["curef"];			//mandatory!
			prog			= Request.QueryString["prog"];			//mandatory!
			if ((prog == null) || (prog == ""))
			{
				conn.QueryString = "select prog_code from application where ap_regno = '" + regno + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0)
					prog = conn.GetFieldValue("prog_code");
			}
			tc				= Request.QueryString["tc"];			//mandatory!
			mc				= Request.QueryString["mc"];			//mandatory!
			exist			= Request.QueryString["exist"];
			va				= Request.QueryString["va"];			//flag bahwa page ini dipanggil dari va
			presco			= Request.QueryString["presco"];		//flag bahwa page ini dipanggil dari prescoring
			LBL_AP_REGNO.Text = regno;
						

			if (mainregno == "" || mainregno == null) ViewMenu();				
			if (exist == "" || exist == null) 
			{
				BTN_BACK.Visible = true;
				BTN_UPDATE_STATUS.Visible = false;			
			}

            BTN_ADD.Attributes.Add("onclick", "if(!cek_mandatory(document.getElementById('Form1'))){return false;};");
			BTN_UPDATE_STATUS.Attributes.Add("onclick", "if(!update()){return false;};");
			//BTN_UPDATE_STATUS.Attributes.Add("onclick", "if(!updateMsg('B')){return false;};");

			if (!IsPostBack) 
			{
				

				/*------------------- ashari -------------------------------*/

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

				/*------------------- ashari -------------------------------*/



				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];				
				LBL_USERID.Text = (string) Session["UserID"];

				TBL_DETAIL.Visible = false;

				GlobalTools.fillRefList(DDL_AANO, "select distinct aa_no, aa_no from bookedcust where cu_ref='" + Request.QueryString["curef"] + "'", false, conn);
				GlobalTools.fillRefList(DDL_PRJ_CODE, "select PRJ_CODE, PRJ_NAME from rfproject where active = '1' and convert(varchar, prj_expiry_date, 112) >= convert(varchar, getdate(), 112)", false, conn);

				GlobalTools.fillRefList(DDL_CHANNCOMP, "exec CHANN_GETCOMPANY '" + Session["UserID"].ToString() + "'", false, conn);
				//DDL_CHANNCOMP.Items.RemoveAt(0);	// remove -SELECT-, default value is the first company

				viewData();
				viewDataGeneral();

				ViewState.Add("noTrack",noTrack);
				ViewState.Add("strWhere",strWhere);
			}
			else
			{
				noTrack = (string)ViewState["noTrack"];
				strWhere = (string)ViewState["strWhere"];
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
			this.DGR_KETENTUANKREDIT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_KETENTUANKREDIT_ItemCommand);
			this.DGR_KETENTUANKREDIT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_KETENTUANKREDIT_PageIndexChanged);

		}
		#endregion


		/* Start -- Procedur Create Text File and Others -- by ashari -- 20041004 */


		public void Create_teksfile(string gr_id, string strPath,string strfilename,string strheader,string strfooter,string strtable,string strfield,string strcreate,ref int jmlcount)
		{			
			//string fullfilename;
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
			wheresqlteks = wheresqlteks +" and  cs.cu_ref='" + Request.QueryString["curef"] + 
				"' and len(rtrim(ltrim(isnull(acc_no,'')))) > 0";

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
			

			string strFileText="";
			if (mandatori_result)
			{
				//fullfilename = strPath +"\\"+ strfilename;
				if (GetRowCount(ds3) > 0	)
				{				
					//create New if not exist
					
					/*
					if (!Directory.Exists(strPath))
					{
						Directory.CreateDirectory(strPath);
					}
					*/						
			

					//--ashari--if (File.Exists(fullfilename)== false)
					//--ashari--{				
					//--ashari--FileTemp = File.CreateText(fullfilename);
					//--ashari--FileTemp.WriteLine(createheader(fullfilename,"0"));					
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
								//--ashari--FileTemp.Write(teksdata);
								strFileText=strFileText+teksdata;
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
								//--ashari--FileTemp.Write(teksdata);
								strFileText=strFileText+teksdata;
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
								//--ashari--FileTemp.Write(teksdata);
								strFileText=strFileText+teksdata;
							}
						
						}				
						//--ashari--FileTemp.WriteLine();
						jmli = i;
						if (strFileText.Trim()!="")
						{
//							conn.QueryString = "insert into TextFile_Queue values('" + strFileText + "', '" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "')";
//							conn.ExecuteNonQuery();								
							conn.QueryString="select * from textfile_queue where text_contain like '%" + strFileText.Substring(0,20) + "%'"; 
							conn.ExecuteQuery();
							if (conn.GetRowCount()==0)
							{
								conn.QueryString="insert into TextFile_Queue values('" + strFileText + "', '" + LBL_REGNO.Text + "', '" + LBL_CUREF.Text + "')";
								conn.ExecuteNonQuery();								
							}
						}
						strFileText="";
					}	
					jmli = jmli + 1;
				}
			
				jmlcount = jmli;	
//				if (strFileText.Trim()!="")
//				{
//					conn.QueryString="select * from textfile_queue where text_contain like '%" + strFileText.Substring(0,20) + "%'"; 
//					conn.ExecuteQuery();
//					if (conn.GetRowCount()==0)
//					{
//						conn.QueryString="insert into TextFile_Queue values('" + strFileText + "', '" + Request.QueryString["regno"] + "')";
//						conn.ExecuteNonQuery();
//					}
//				}
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





		/* End -- Procedur Create Text File and Others -- by ashari -- 20041004 */




		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				string mc1 = Request.QueryString["mc"];
				string mc2 = Request.QueryString["mc"];
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						//t.ForeColor = Color.MidnightBlue; 
						if (conn.GetFieldValue(i,3).IndexOf("?de=") < 0 && conn.GetFieldValue(i,3).IndexOf("&de=") < 0) 
							strtemp = strtemp + "&de=" + Request.QueryString["de"];	
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"];
						//---  untuk general info
						if (conn.GetFieldValue(i,3).IndexOf("?exist=") < 0 && conn.GetFieldValue(i,3).IndexOf("&exist=") < 0) 
							strtemp = strtemp + "&exist=" + Request.QueryString["exist"];	

						//--- untuk program yang dipilih
						if (conn.GetFieldValue(i,3).IndexOf("?prog=") < 0 && conn.GetFieldValue(i,3).IndexOf("&prog=") < 0) 
							strtemp = strtemp + "&prog=" + prog;	

					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		
		protected void BTN_ADD_Click(object sender, System.EventArgs e)
		{

//			//////////////////////////////////////////////////////////////
//			///	sebelum add loan, cek dulu jumlah ketentuan kredit
//			///	maksimal jumlah ketentuan kredit adalah 2
//			///	
//			conn.QueryString = "select count(*) JUMLAH from KETENTUAN_KREDIT where AP_REGNO = '" + LBL_REGNO.Text + "'";
//			conn.ExecuteQuery();
//			if (conn.GetFieldValue("JUMLAH") == "2") 
//			{
//				return;
//			}
//			//////////////////////////////////////////////////////////////


			//////////////////////////////////////////////////////////////
			///	cek dulu untuk existing loan. 1 Ketentuan Kredit hanya
			///	untuk 1 no rekening.
			///	
			if (LBL_ACC_NOVAL.Text != "" && LBL_ACC_NOVAL.Text != "-") 
			{
				conn.QueryString = "select count(*) jumlah from ketentuan_kredit " + 
					"where ap_regno = '" + LBL_REGNO.Text + 
					"' and acc_no = '" + LBL_ACC_NOVAL.Text + "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue("jumlah") != "0") 
				{
					GlobalTools.popMessage(this, "Satu Ketentuan hanya untuk satu rekening!");
					return;
				}
			}
			//////////////////////////////////////////////////////////////
			

			//////////////////////////////////////////////////////////////
			///	Untuk penambahan ketentuan kredit dari va, maka
			///	penambahan permohonan baru tidak bisa, karena sudah
			///	melewati sandi bi (checking)
			///	TERNYATA, boleh .... :(
			///	di credit analysis ditambah link ke Sandi BI, tapi belum
			///	ada validasi.
			///	
			/*
			if (va != "" && va != null && RDO_PBARU.SelectedValue == "1") 
			{
				return;
			}
			*/


			TBL_DETAIL.Visible = true;
			BTN_ADD.Visible = false;			
			BTN_CANCEL.Visible = true;

			RDO_PBARU.Enabled = false;
			DDL_AANO.Enabled = false;
			DDL_PRODUCTID.Enabled = false;
			DDL_ACC_SEQ.Enabled = false;

			DDL_ACC_NO.Enabled = false;

			TXT_KETKREDIT_DESC.ReadOnly = true;
			BTN_SAVE.Enabled = true;			
			DDL_PRJ_CODE.Enabled = false;

			DDL_CHANNCOMP.Enabled = false;
			//LBL_REMAINING_EMAS_LIMIT.Text = "";

			//Menambah ke ketentuan kredit saja
			addLoan();

			LBL_KETENTUAN_KREDIT.Visible = true;
			LBL_KETENTUAN_KREDIT.Text = TXT_KETKREDIT_DESC.Text;

			conn.QueryString = "select KET_CODE from KETENTUAN_KREDIT where AP_REGNO = '" + regno + "' order by KET_CODE desc";
			conn.ExecuteQuery();
			LBL_KET_CODE.Text = conn.GetFieldValue(0, "KET_CODE");

			/////////////////////////////////////////////////////////////////////////////////////
			/// Get CU_REF Channeling Company
			/// 
			string _curefchann = "";
			if (RDO_PBARU.SelectedValue == "2")	// withdrawal
			{
				_curefchann = DDL_CHANNCOMP.SelectedValue;
			}
			else 
			{
				_curefchann = LBL_CU_REF.Text;
			}
			///////////////////////////////////////

            //PUNDI
            string takeover = "0";
            if(CB_IsTakeOver.Checked)
            {
                takeover = "1";
            }

			if (RDO_PBARU.SelectedValue == "1")
                creddetail.Attributes.Add("src", "PermohonanBaru2.aspx?regno=" + regno + 
                    "&curef=" + curef + 
                    "&prog=" + prog + 
                    "&tc=" + tc + 
                    "&mc=" + mc + 
                    "&ket_code=" + conn.GetFieldValue(0, "KET_CODE") + 
                    "&mainregno=" + mainregno + 
                    "&mainprod_seq=" + mainprod_seq + 
                    "&mainproductid=" + mainproductid +
                    "&takeover=" + takeover);
				//creddetail.Attributes.Add("src", "PermohonanBaru.aspx?regno=" + regno + "&curef=" + curef + "&prog=" + prog + "&tc=" + tc + "&mc=" + mc + "&ket_code=" + conn.GetFieldValue(0,"KET_CODE") + "&mainregno=" + mainregno + "&mainprod_seq="+ mainprod_seq +"&mainproductid="+ mainproductid);
			else if (RDO_PBARU.SelectedValue == "0")
				creddetail.Attributes.Add("src", "Renewal.aspx?regno=" + regno + 
					"&curef=" + curef + "&prog=" + prog + "&tc=" + tc + "&mc=" + mc + 
					"&ket_code=" + conn.GetFieldValue(0,"KET_CODE") + 
					"&mainregno=" + mainregno + 
					"&mainprod_seq=" + mainprod_seq + 
					"&mainproductid=" + mainproductid + 
					"&curefchann=" + _curefchann +
                    "&takeover=" + takeover);
			else if (RDO_PBARU.SelectedValue == "2")
				creddetail.Attributes.Add("src", "Withdrawal.aspx?regno=" + regno + 
					"&curef=" + curef + "&prog=" + prog + "&tc=" + tc + "&mc=" + mc + 
					"&ket_code=" + conn.GetFieldValue(0,"KET_CODE") + 
					"&mainregno=" + mainregno + 
					"&mainprod_seq=" + mainprod_seq + 
					"&mainproductid=" + mainproductid +
                    "&curefchann=" + _curefchann +
                    "&takeover=" + takeover);
			else if (RDO_PBARU.SelectedValue == "3")
				creddetail.Attributes.Add("src", "PostFin.aspx?regno=" + regno + 
					"&curef=" + curef + "&prog=" + prog + "&tc=" + tc + "&mc=" + mc + 
					"&ket_code=" + conn.GetFieldValue(0,"KET_CODE") + 
					"&mainregno=" + mainregno + 
					"&mainprod_seq=" + mainprod_seq + 
					"&mainproductid=" + mainproductid + 
					"&curefchann=" + _curefchann +
					"&app=09" +
                    "&ncl=" + DDL_NCLPROD.SelectedValue +
                    "&takeover=" + takeover);
			/*
			else if (RDO_PBARU.SelectedValue == "4")
				creddetail.Attributes.Add("src", "PeriodicScoring.aspx?regno=" + regno + 
					"&curef=" + curef + "&prog=" + prog + "&tc=" + tc + "&mc=" + mc + 
					"&ket_code=" + conn.GetFieldValue(0,"KET_CODE") + 
					"&mainregno=" + mainregno + 
					"&mainprod_seq=" + mainprod_seq + 
					"&mainproductid=" + mainproductid + 
					"&curefchann=" + _curefchann +
					"&app=10");
			*/
			
			//creddetail.Attributes.Add("style","");			
			creddetail.Attributes.Add("height", "600");
		}


		private void addLoan() 
		{
			try 
			{
				//Memasukkan data ke tabel KETENTUAN_KREDIT								
				conn.QueryString = "exec KET_KREDIT '','" + 
								TXT_KETKREDIT_DESC.Text + "','" + 
								LBL_REGNO.Text + "'," + 
								GlobalTools.ConvertNull(DDL_AANO.SelectedValue) + "," + 
								GlobalTools.ConvertNull(DDL_PRODUCTID.SelectedValue) + "," + 
								GlobalTools.ConvertNull(DDL_ACC_SEQ.SelectedValue) + "," + 
								GlobalTools.ConvertNull(LBL_ACC_NOVAL.Text) + ", '0', " + 
								GlobalTools.ConvertNull(DDL_PRJ_CODE.SelectedValue) + ", " +
								GlobalTools.ConvertNull(DDL_CHANNCOMP.SelectedValue) + "";
				conn.ExecuteNonQuery();
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error !");
				return;
			}
		}


		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			//////////////////////////////////////////////////////////////////
			/// For the sake of safety, check first whether it needs
			/// earmarking or not
			/// 
			conn.QueryString = "exec EARMARK_CEK '" + LBL_AP_REGNO.Text + "', '" + LBL_KET_CODE.Text + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("NEED_EARMARK") == "1") 
			{
				try 
				{
					/// Calculate Earmark Limit
					/// 
					Earmarking.Earmarking.calculateEarmarkLimit(LBL_REGNO.Text, LBL_KET_CODE.Text, conn);

					/// Earmark project value
					/// 
					Earmarking.Earmarking.doEarmark(LBL_REGNO.Text, LBL_KET_CODE.Text, conn);

					conn.ExecTran_Commit();
				} 
				catch (NegativeLimitException ex1) 
				{
					if (ex1.getMessage() == "FACILITY") 
					{
						if (conn != null) conn.ExecTran_Rollback();
						GlobalTools.popMessage(this, "Earmarking failed. Remaining limit become negative!");				
						return;
					} 
					else if (ex1.getMessage() == "PROJECT") 
					{
						GlobalTools.popMessage(this, "Earmarking proceed although remaining limit will be negative!");

						/// Calculate Earmark Limit
						/// 
						Earmarking.Earmarking.calculateEarmarkLimit(LBL_REGNO.Text, LBL_KET_CODE.Text, conn);

						/// Earmark project value
						/// 
						Earmarking.Earmarking.doEarmark(LBL_REGNO.Text, LBL_KET_CODE.Text, conn, "1", "");

						conn.ExecTran_Commit();
					}
				}
				catch (Exception ex) 
				{
					ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, LBL_REGNO.Text);
					if (conn != null) conn.ExecTran_Rollback();
				}
			}


			BTN_ADD.Visible = true;
			BTN_CANCEL.Visible = false;
			BTN_CANCEL_ADD.Visible = false;

			RDO_PBARU.Enabled = true;
			RDO_PBARU.SelectedValue = "1";

			DDL_AANO.ClearSelection();
			DDL_PRODUCTID.ClearSelection();
			DDL_ACC_SEQ.ClearSelection();
			DDL_ACC_NO.ClearSelection();
			LBL_ACC_NO.Text = "";
			LBL_ACC_NOVAL.Text = "";

			DDL_AANO.CssClass = "";
			DDL_PRODUCTID.CssClass = "";
			DDL_ACC_SEQ.CssClass = "";
			DDL_ACC_NO.CssClass = "";
			DDL_PRJ_CODE.Enabled = true;
			DDL_PRJ_CODE.SelectedValue = "";

			TXT_KETKREDIT_DESC.ReadOnly = false;
			TXT_KETKREDIT_DESC.Text = "";
			LBL_KETENTUAN_KREDIT.Text = "";

			LBL_PRODUCTID.Visible = false;
			LBL_SEQ.Visible = false;

			BTN_UPDATE_STATUS.Enabled = true;
			BTN_SAVE.Enabled = false;

			TBL_DETAIL.Visible = false;
			//			creddetail.Attributes.Add("src", "");
			//			creddetail.Attributes.Add("height", "600");

			viewData();
		}	


		private void viewDataGeneral()
		{
			double limitExposure = 0;
			conn.QueryString = "select * from VW_DE_MAIN where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			LBL_AP_REGNO.Text		= conn.GetFieldValue("AP_REGNO");
			LBL_CU_REF.Text			= conn.GetFieldValue("CU_REF");
			LBL_AP_SIGNDATE.Text	= tool.FormatDate(conn.GetFieldValue("AP_SIGNDATE"));			
			LBL_PROGRAMDESC.Text	= conn.GetFieldValue("PROGRAMDESC");
			LBL_BRANCH_NAME.Text	= conn.GetFieldValue("BRANCH_NAME");
			LBL_AP_RELMNGR.Text		= conn.GetFieldValue("SU_FULLNAME");
			try 
			{
				limitExposure = double.Parse(conn.GetFieldValue("LIMITEXPOSURE"));
			} 
			catch {}
			LBL_CHANNEL_DESC.Text	= (conn.GetFieldValue("CHANNEL_DESC")==""?"-":conn.GetFieldValue("CHANNEL_DESC"));
			LBL_AP_SRCCODE.Text		= (conn.GetFieldValue("AP_SRCCODE")==""?"-":conn.GetFieldValue("AP_SRCCODE"));
			LBL_AP_SALESAGENCY.Text = (conn.GetFieldValue("AGENCYNAME")==""?"-":conn.GetFieldValue("AGENCYNAME"));
			LBL_GR_BUSINESSUNIT.Text = conn.GetFieldValue("BUSSUNITDESC");
			LBL_AP_TEAMLEADER.Text = conn.GetFieldValue("AP_TEAMLEADER");			
		}

		private void cekKetKreditForEmptyLoan() 
		{
			try 
			{
				conn.QueryString = "exec IDE_KETKREDIT_NOLOAN '" + LBL_REGNO.Text + "'";
				conn.ExecuteNonQuery();
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}
		}
	
		private void adjustGridFunction() 
		{		
			//Kalau berasal dari va, cek apakah ketentuan kredit tersebut yang terakhir
			//kalau yang terakhir, set tombol delete selanjutnya konfirmasi hapus untuk reject aplikasi
			if (va != "" && va != null) 
			{
				if (DGR_KETENTUANKREDIT.Items.Count == 1) 
				{
					for(int i=0; i<DGR_KETENTUANKREDIT.Items.Count; i++) 
					{
						LinkButton LNK_DEL = (LinkButton) DGR_KETENTUANKREDIT.Items[i].Cells[4].FindControl("LNK_DELETE");
						LinkButton lb = (LinkButton) DGR_KETENTUANKREDIT.Items[i].Cells[4].FindControl("LNK_ADD");
						string ketCode = DGR_KETENTUANKREDIT.Items[i].Cells[0].Text.Trim();
						conn.QueryString = "select apptype from custproduct where ap_regno ='"+LBL_AP_REGNO.Text.Trim()+"' and ket_code = '"+ketCode+"'";
						conn.ExecuteQuery();
						if(conn.GetFieldValue("apptype").Trim() == "01") lb.Visible = false;

						LNK_DEL.Attributes.Add("onclick", "if(!konfirHapus()){return false;};");
					}
				}								
			}		
		}

		private void cekBIChecking() 
		{				
			conn.QueryString = "select * from VW_IDE_CEKQUEUE where AP_REGNO='" + LBL_REGNO.Text + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				string BMDEBITUR = conn.GetFieldValue("CI_BMDEBITUR");
				if (BMDEBITUR != null) BMDEBITUR = BMDEBITUR.ToString().Trim();
				else BMDEBITUR = "";

				if (conn.GetFieldValue(0,"WITHFAIRISAAC") == "0" || BMDEBITUR.Length == 0) 
				{
					/* Start -- calling text file generation -- by ashari -- 20041004 */
					/* Gatot: hapus dulu data yang lama dengan curef yang sama */
					conn.QueryString = "delete from textfile_queue where cu_ref = '" + LBL_CUREF.Text + "'";
					conn.ExecuteNonQuery();

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

			/***
			conn.QueryString = "select AP_CHECKBI, P.WITHFAIRISAAC from APPLICATION a left join RFPROGRAM p on A.PROG_CODE = P.PROGRAMID where AP_REGNO='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
			
				
				if (conn.GetFieldValue(0,"WITHFAIRISAAC") == "0" && conn.GetFieldValue(0,"AP_CHECKBI") == "1")
				{
					conn.QueryString = "insert into BI_STATUS (ap_regno, cu_ref, bs_reqdate, bs_recvdate, bs_bidataavail, bs_complete) " + 
						"values ('" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "', getdate(), null, null, '0')";
					conn.ExecuteQuery();
				}
			}
			***/

			conn.QueryString = "select * from VW_IDE_CEKQUEUE where AP_REGNO='" + LBL_REGNO.Text + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				string BMDEBITUR = conn.GetFieldValue("CI_BMDEBITUR");
				if (BMDEBITUR != null) BMDEBITUR = BMDEBITUR.ToString().Trim();
				else BMDEBITUR = "";

				//if ((conn.GetFieldValue(0,"WITHFAIRISAAC") == "0" || BMDEBITUR.Length == 0) && conn.GetFieldValue(0,"AP_CHECKBI") == "1") 				
				if ( (conn.GetFieldValue(0, "WITHFAIRISAAC") == "1" && BMDEBITUR.Length == 0) )
				{
					// do nothing ....
				}
				else 
				{
					if (conn.GetFieldValue(0,"AP_CHECKBI") == "1") 
					{
						conn.QueryString = "insert into BI_STATUS (ap_regno, cu_ref, bs_reqdate, bs_recvdate, bs_bidataavail, bs_complete) " + 
							"values ('" + LBL_REGNO.Text + "', '" + LBL_CUREF.Text + "', getdate(), null, null, '0')";
						conn.ExecuteQuery();
					}
				}
			}
		}

		private void viewData() 
		{
			/*
			DataTable dt = new DataTable();

			dt.Columns.Add(new DataColumn("KET_CODE"));
			dt.Columns.Add(new DataColumn("KET_DESC"));
			dt.Columns.Add(new DataColumn("AA_NO"));
			dt.Columns.Add(new DataColumn("ACC_NO"));
			*/

			conn.QueryString = "select * " + 
								"from VW_KET_KREDIT where AP_REGNO = '" + LBL_REGNO.Text + "'";
			conn.ExecuteQuery();			

			/*
			for(int i=0; i < conn.GetRowCount(); i++) 
			{
				DataRow dr = dt.NewRow();
				dr[0] = conn.GetFieldValue(i, "KET_CODE");
				dr[1] = conn.GetFieldValue(i, "KET_DESC");
				dr[2] = conn.GetFieldValue(i, "AA_NO");
				dr[3] = conn.GetFieldValue(i, "ACC_NO");

				dt.Rows.Add(dr);
			}
			*/		

			DGR_KETENTUANKREDIT.DataSource = conn.GetDataTable().DefaultView;
			try 
			{
				DGR_KETENTUANKREDIT.DataBind();
			} 
			catch 
			{
				DGR_KETENTUANKREDIT.CurrentPageIndex = 0;
				DGR_KETENTUANKREDIT.DataBind();
			}

			

			//Cek kalau ada ketentuan kredit, enable UPDATE STATUS
			if (conn.GetRowCount() > 0) BTN_UPDATE_STATUS.Enabled = true;
			else BTN_UPDATE_STATUS.Enabled = false;

			cekKetKreditForEmptyLoan();
			adjustGridFunction();

			for(int i=0; i<DGR_KETENTUANKREDIT.Items.Count; i++) 
			{			
				LinkButton lb = (LinkButton) DGR_KETENTUANKREDIT.Items[i].Cells[4].FindControl("LNK_ADD");
				string ketCode = DGR_KETENTUANKREDIT.Items[i].Cells[0].Text.Trim();
				conn.QueryString = "select apptype from custproduct where ap_regno ='"+LBL_AP_REGNO.Text.Trim()+"' and ket_code = '"+ketCode+"'";
				conn.ExecuteQuery();
				if(conn.GetFieldValue("apptype").Trim() == "01") lb.Visible = false;			
			}
		}		

		

		protected void RDO_PBARU_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			DDL_CHANNCOMP.Enabled = false;
			DDL_CHANNCOMP.SelectedValue = "";
			LBL_REMAINING_EMAS_LIMIT.Text = "";
			DDL_NCLPROD.Enabled = false;
			DDL_NCLPROD.SelectedValue = "";
			LBL_REMAINING_NCL_LIMIT.Text = "";

			if ((RDO_PBARU.SelectedValue == "1") ||	(RDO_PBARU.SelectedValue == "4"))//--- Permohonan Baru / Periodik Scoring
			{
				AA_NO.Enabled = false;
				DDL_AANO.Enabled = false;
				DDL_AANO.CssClass = "";
				try { DDL_AANO.SelectedValue = ""; } catch {}

				LBL_FACILITY_CODE.Enabled = false;
				DDL_PRODUCTID.Enabled = false;
				try { DDL_PRODUCTID.SelectedValue = ""; } catch {}
				DDL_PRODUCTID.CssClass = "";				

				DDL_ACC_SEQ.Enabled = false;
				try { DDL_ACC_SEQ.SelectedValue = ""; } catch {}
				DDL_ACC_SEQ.CssClass = "";

				//LBL_ACC_NO.Enabled = false;
				LBL_ACC_NOVAL.Visible = false;
				DDL_ACC_NO.Enabled = false;
				//DDL_ACC_NO.CssClass = "";		// account number is not mandatory
				try { DDL_ACC_NO.SelectedValue = ""; } catch {}

				LBL_PRODUCTID.Visible = false;

				LBL_SEQ_TITLE.Enabled = false;
				LBL_SEQ.Visible = false;

				DDL_NCLPROD.Enabled = false;
				DDL_NCLPROD.CssClass = "";
				LBL_REMAINING_NCL_LIMIT.Text = "";
			}
			//else if (RDO_PBARU.SelectedValue == "0" || RDO_PBARU.SelectedValue == "2")//---- Bukan Permohonan Baru
			else if (RDO_PBARU.SelectedValue == "0" || RDO_PBARU.SelectedValue == "2" || RDO_PBARU.SelectedValue == "3")//---- Bukan Permohonan Baru
			{
				AA_NO.Enabled = true;
				DDL_AANO.Enabled = true;
				DDL_AANO.CssClass = "mandatory";

				LBL_FACILITY_CODE.Enabled = true;
				DDL_PRODUCTID.Enabled = true;
				DDL_PRODUCTID.CssClass = "mandatory";
				
				DDL_ACC_SEQ.Enabled = true;
				DDL_ACC_SEQ.CssClass = "mandatory";

				//LBL_ACC_NO.Enabled = true;
				LBL_ACC_NOVAL.Visible = true;
				LBL_ACC_NOVAL.Text = "";
				DDL_ACC_NO.Enabled = true;
				//DDL_ACC_NO.CssClass = "mandatory";	// account number is not mandatory

				LBL_PRODUCTID.Visible = true;
				LBL_PRODUCTID.Text = "";
				LBL_SEQ.Text = "";

				LBL_SEQ_TITLE.Enabled = true;
				LBL_SEQ.Visible = true;				

				GlobalTools.fillRefList(DDL_AANO, "select distinct aa_no, aa_no from bookedcust where cu_ref = '" + Request.QueryString["curef"] + "'", false, conn);

				/// withdrawal
				/// 
				if (RDO_PBARU.SelectedValue == "2") 
				{
					DDL_CHANNCOMP.Enabled = true;
					GlobalTools.fillRefList(DDL_AANO, "select distinct aa_no, aa_no from bookedcust where cu_ref = '" + DDL_CHANNCOMP.SelectedValue + "'", false, conn);

					DDL_NCLPROD.Enabled = false;
					DDL_NCLPROD.CssClass = "";
					LBL_REMAINING_NCL_LIMIT.Text = "";
				}

					//2007-10-09 add by sofyan for Post Fin
					/// withdrawal
					/// 
				else if (RDO_PBARU.SelectedValue == "3") 
				{
					GlobalTools.fillRefList(DDL_NCLPROD, "EXEC IDE_POSTFIN_GETNCLPRODUCT '" + Request.QueryString["curef"] + "'", false, conn);
					DDL_NCLPROD.Enabled = true;
					DDL_NCLPROD.CssClass = "mandatory";

					DDL_CHANNCOMP.Enabled = false;
					DDL_AANO.Enabled = false;
					DDL_PRODUCTID.Enabled = false;
					DDL_ACC_SEQ.Enabled = false;
					DDL_ACC_NO.Enabled = false;

					DDL_CHANNCOMP.CssClass = "";
					DDL_AANO.CssClass = "";
					DDL_PRODUCTID.CssClass = "";
					DDL_ACC_SEQ.CssClass = "";
					DDL_ACC_NO.CssClass = "";
				}
				else
				{
					DDL_NCLPROD.Enabled = false;
					DDL_NCLPROD.CssClass = "";
					LBL_REMAINING_NCL_LIMIT.Text = "";
				}
			}


			TBL_DETAIL.Visible = false;
//			creddetail.Attributes.Add("src", "");
//			creddetail.Attributes.Add("src", "600");
//			creddetail.Attributes.Add("style","VISIBILITY: hidden");

			//creddetail.Visible = false;
		}

		protected void DDL_AANO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string _CUREF = "";
			if (RDO_PBARU.SelectedValue == "2") _CUREF = DDL_CHANNCOMP.SelectedValue;
			else _CUREF = LBL_CUREF.Text;
			
			DDL_ACC_NO.Items.Clear();

			//--- versi 1
			// Mendapatkan account no dari facility code dan sequence
			GlobalTools.fillRefList(DDL_PRODUCTID, "select distinct PRODUCTID, PRODUCTID from BOOKEDPROD where AA_NO = '" + DDL_AANO.SelectedValue + "' and CU_REF = '" + _CUREF + "'", false, conn);
			DDL_ACC_SEQ.SelectedValue = "";
			LBL_ACC_NOVAL.Text = "";

			//--- versi 2
			// Mendapatkan facilit code dan sequence dari account number
			//GlobalTools.fillRefList(DDL_ACC_NO, "select ACC_NO, ACC_NO from BOOKEDPROD where AA_NO = '" + DDL_AANO.SelectedValue + "'", false, conn);
			LBL_PRODUCTID.Text = "";
			LBL_SEQ.Text = "";

			/***
			DDL_PRODUCTID.Items.Clear();
			DDL_PRODUCTID.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select productid from bookedcust where cu_ref='" + Request.QueryString["curef"] + "' and aa_no='" + DDL_AANO.SelectedValue + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_PRODUCTID.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
			***/
		}

		protected void DDL_FACILITY_CODE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string _CUREF = "";
			if (RDO_PBARU.SelectedValue == "2") _CUREF = DDL_CHANNCOMP.SelectedValue;
			else _CUREF = LBL_CUREF.Text;

			DDL_ACC_SEQ.Items.Clear();
			DDL_ACC_SEQ.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select distinct ACC_SEQ, ACC_SEQ from bookedprod " + 
				" where aa_no='" + DDL_AANO.SelectedValue + 
				"' and productid='" + DDL_PRODUCTID.SelectedValue + "' " + 
				" and cu_ref = '" + _CUREF + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_ACC_SEQ.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
			
//			conn.QueryString = "select productdesc from rfproduct where productid='" + DDL_PRODUCTID.SelectedValue + "'";
//			conn.ExecuteQuery();

			DDL_ACC_SEQ.Visible = true;
		}

		protected void BTN_UPDATE_STATUS_Click(object sender, System.EventArgs e)
		{
			//disini baru dicek eksposurnya
			conn.QueryString = "EXEC DE_CALCULATE_TOTALEXPOSURE '" + Request.QueryString["regno"] + "','" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery(300);

			double totaleksposure =  MyConnection.ConvertToDouble2(conn.GetFieldValue("TOT_LIMIT_SMALL"));

			//disini cek subsegment
			conn.QueryString = "SELECT PROG_CODE FROM APPLICATION WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			string progcode = conn.GetFieldValue("PROG_CODE");

			bool bisa = true;

			conn.QueryString = "SELECT CP_LIMITCHG, CP_LIMIT FROM CUSTPRODUCT WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND APPTYPE = '03'";
			conn.ExecuteQuery();
			string operators;
			double cp_limit;

			double firsteksposure = totaleksposure;

			double largest = 0.0;

			for(int i = 0; i<conn.GetRowCount(); i++)
			{
				operators = conn.GetFieldValue(i, "CP_LIMITCHG");
				cp_limit = MyConnection.ConvertToDouble2(conn.GetFieldValue(i, "CP_LIMIT"));

				if(operators == "+")
				{
					firsteksposure -= cp_limit;
				}
				else if(operators == "-")
				{
					firsteksposure += cp_limit;
				}
			}

			if(firsteksposure > totaleksposure)
			{
				largest = firsteksposure;
			}
			else if(totaleksposure > firsteksposure)
			{
				largest = totaleksposure;
			}
			else
			{
				largest = totaleksposure;
			}	

			//sd 2M
			/*if((progcode == "0321" || progcode == "0323") && ((largest <= 1000000000) || (largest > 2000000000)))
			{
				bisa = false;
			}*/
			if((progcode == "0321" || progcode == "0323") && (largest > 2000000000))
			{
				bisa = false;
			}
			/*else if((progcode == "0321" || progcode == "0323") && (largest > 2000000000))
			{
				bisa = false;
			}*/
			else if((progcode == "0322" || progcode == "0324") && ((largest <= 2000000000) || (largest > 5000000000)))
			{
				bisa = false;
			}
			/*else if((progcode == "0325") && largest > 1000000000)
			{
				bisa = false;
			}*/
			
			if(bisa == true)
			{
				try 
				{
					/***
					 * ------------------------------------------------
					 * --- BI Checking setelah IDE atau Pre-Scoring ---
					 * ------------------------------------------------		
					***/
					cekBIChecking();

					DataTable dt;
					conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + Request.QueryString["regno"] +
						"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
					conn.ExecuteQuery();
					dt = conn.GetDataTable().Copy();
					for (int i = 0; i < dt.Rows.Count; i++)
					{
						// tracupdate execution
						conn.QueryString = "exec TRACKUPDATE '" + 
							LBL_REGNO.Text + "', '" +	// AP_REGNO
							dt.Rows[i][1].ToString() + "', '" +		// PRODUCTID
							dt.Rows[i][0].ToString() + "', '" +		// APPTYPE
							LBL_USERID.Text + "', '" +				// USERID
							dt.Rows[i]["PROD_SEQ"].ToString() + "',"+ // PROD_SEQ
							"'"+Request.QueryString["tc"].Trim()+"'";// PAGE TRACK
						conn.ExecuteNonQuery();
					}
				
					////////////////////////////////////////////////
					///	Cek Customer di Pre Initial Entry
					///	
					conn.QueryString = "select cu_ref from application where ap_regno = '"+LBL_AP_REGNO.Text.Trim()+"'";
					conn.ExecuteQuery();

					string cuRef = conn.GetFieldValue("cu_ref").Trim();
					conn.QueryString = "select max(PRE_SEQSURAT) seq FROM CUSTOMER_PRE_ENTRY where cu_ref = '"+cuRef+"'";
					conn.ExecuteQuery();

					string seq = conn.GetFieldValue("seq").Trim();
					conn.QueryString = "exec IDE_CEK_PRE_ENTRY '" + cuRef + "','"+seq+"'";
					conn.ExecuteNonQuery();

				} 
				catch (NullReferenceException) 
				{
					GlobalTools.popMessage(this, "Connection Error !");
					Response.Redirect("../Login.aspx?expire=1");
				}

				// mengirimkan strng pesan
				string msg = getNextStepMsg(LBL_AP_REGNO.Text);
				Response.Redirect("FindCustomer.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
			}	
			else
			{
				Tools.popMessage(this,"Eksposure tidak sesuai dengan Sub-Segment/Program !");
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

		private void DGR_KETENTUANKREDIT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string KET_CODE = "";

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					KET_CODE = e.Item.Cells[0].Text;
					conn.QueryString = "select APPTYPE from CUSTPRODUCT where KET_CODE = '" + KET_CODE + "'";
					conn.ExecuteQuery();
					string link = "";
					//parameter 'view' untuk flag bahwa ketentuan kredit cuma bisa view saja
					if (conn.GetFieldValue("APPTYPE") == "01")
						link = "PermohonanBaru2.aspx?regno=" + regno + "&curef=" + curef + "&prog=" + prog + "&tc=" + tc + "&mc=" + mc + "&ket_code=" + KET_CODE + "&view=1";
						//link = "PermohonanBaru.aspx?regno=" + regno + "&curef=" + curef + "&prog=" + prog + "&tc=" + tc + "&mc=" + mc + "&ket_code=" + KET_CODE + "&view=1";
					else
						link = "Renewal.aspx?regno=" + regno + "&curef=" + curef + "&prog=" + prog + 
							"&tc=" + tc + "&mc=" + mc + "&ket_code=" + KET_CODE + "&view=1&va=" + va;
					creddetail.Attributes.Add("src", link);

					TBL_DETAIL.Visible = true;
					creddetail.Attributes.Add("height", "200");

					LBL_KETENTUAN_KREDIT.Text = e.Item.Cells[1].Text;
					LBL_KETENTUAN_KREDIT.Visible = true;
					TBL_DETAIL.Visible = true;
					break;

				case "delete":					
					KET_CODE = e.Item.Cells[0].Text;

					if (va == "1") 
					{
						////////////////////////////////////////////////////////////
						///	kalau hapus ketentuan kredit dari ver assignment,
						///	cek dulu apakah ada collateral yang attach ke product
						///	
						conn.QueryString = "select count(*) as JUMLAH from VW_VER_ASSIGN_COLLAPPR where ap_regno = '" + LBL_AP_REGNO.Text + "' and ket_code = '" + KET_CODE + "'";
						conn.ExecuteQuery();

						if (conn.GetFieldValue("JUMLAH") != "0") 
						{
							GlobalTools.popMessage(this, "Terdapat collateral sedang di appraise!");
							break;
						}
					}


					/////////////////////////////////////////////////////////////////////////
					/// Reverse Earmarking
					/// 
					//Response.Write("<!-- regno: " + LBL_AP_REGNO.Text + " -->");
					//Response.Write("<!-- ketcode: " + KET_CODE + " -->");
					try 
					{
						Earmarking.Earmarking.reverseEarmark(LBL_AP_REGNO.Text, KET_CODE, conn);

						conn.ExecTran_Commit();
					} 
					catch (Exception ex)
					{
						ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, LBL_AP_REGNO.Text);
						if (conn != null)
							conn.ExecTran_Rollback();
					}


					////////////////////////////////////////////////////////////////////////////////////////
					/// Delete kredit from tables
					/// 
					conn.QueryString = "exec KET_KREDIT '" +KET_CODE  + "',null,null,null,null,null,null,'2'";
					conn.ExecuteNonQuery();
					viewData();
					//TBL_DETAIL.Visible = false;



					if (va == "1") 
					{
						//
						//cek kalau ngga punya ketentuan kredit lagi, berarti aplikasi itu rejected
						//
						conn.QueryString = "select * from CUSTPRODUCT where AP_REGNO = '" + regno + "'";
						conn.ExecuteQuery();
						if (conn.GetRowCount() == 0) 
						{
							//
							//Kalau setelah konfir hapus dan reject aplikasi (di VA), 
							//maka reject aplikasi					
							//
							conn.QueryString = "update APPLICATION set AP_REJECT = '1' where AP_REGNO = '" + regno + "'";
							conn.ExecuteNonQuery();
							Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
						}
					}
					break;
				
				case "add":
					KET_CODE = e.Item.Cells[0].Text;
					conn.QueryString = "select APPTYPE from CUSTPRODUCT where KET_CODE = '" + KET_CODE + "'";
					conn.ExecuteQuery();
					link = "";
					//parameter 'view' untuk flag bahwa ketentuan kredit cuma bisa view saja
					if (conn.GetFieldValue("APPTYPE") == "01")
						link = "PermohonanBaru2.aspx?regno=" + regno + "&curef=" + curef + "&prog=" + prog + "&tc=" + tc + "&mc=" + mc + "&ket_code=" + KET_CODE;
						//link = "PermohonanBaru.aspx?regno=" + regno + "&curef=" + curef + "&prog=" + prog + "&tc=" + tc + "&mc=" + mc + "&ket_code=" + KET_CODE;
					else
						link = "Renewal.aspx?regno=" + regno + "&curef=" + curef + "&prog=" + prog + 
							"&tc=" + tc + "&mc=" + mc + "&ket_code=" + KET_CODE + "&va=" + va;
					creddetail.Attributes.Add("src", link);

					TBL_DETAIL.Visible = true;
					creddetail.Attributes.Add("height", "600");

					LBL_KETENTUAN_KREDIT.Text = e.Item.Cells[1].Text;
					LBL_KETENTUAN_KREDIT.Visible = true;
					TBL_DETAIL.Visible = true;
					TBL_DETAIL.Visible = true;

					BTN_ADD.Visible = false;
					
					BTN_CANCEL_ADD.Visible = true;

					RDO_PBARU.Enabled = false;
					DDL_AANO.Enabled = false;
					DDL_PRODUCTID.Enabled = false;
					DDL_ACC_SEQ.Enabled = false;

					DDL_ACC_NO.Enabled = false;
					DDL_PRJ_CODE.Enabled = false;

					TXT_KETKREDIT_DESC.ReadOnly = true;
					BTN_SAVE.Enabled = true;
					break;

			}
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			try 
			{
				conn.QueryString = "select KET_CODE from KETENTUAN_KREDIT where AP_REGNO = '" + regno + "' order by KET_CODE desc";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			string KET_CODE = conn.GetFieldValue(0,"KET_CODE");
			try 
			{
				conn.QueryString = "exec KET_KREDIT '" +KET_CODE  + "',null,null,null,null,null,null,'2'";
				conn.ExecuteNonQuery();			
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}


			//creddetail.Attributes.Add("src","");
			TBL_DETAIL.Visible = false;

			BTN_ADD.Visible = true;
			BTN_CANCEL.Visible = false;

			RDO_PBARU.Enabled = true;
			TXT_KETKREDIT_DESC.ReadOnly = false;

			LBL_KETENTUAN_KREDIT.Visible = false;
			BTN_SAVE.Enabled = false;
			DDL_PRJ_CODE.Enabled = true;

			if (RDO_PBARU.SelectedValue != "1")		//--- Bukan Permohonan Baru
			{
				AA_NO.Enabled = true;
				DDL_AANO.Enabled = true;

				DDL_PRODUCTID.Enabled	= true;
				DDL_ACC_SEQ.Enabled		= true;

				//LBL_ACC_NO.Enabled		= true;
				LBL_ACC_NOVAL.Visible	= true;
				DDL_ACC_NO.Enabled		= true;

				LBL_PRODUCTID.Visible = true;
				LBL_SEQ.Visible = true;				

				if (RDO_PBARU.SelectedValue == "2") DDL_CHANNCOMP.Enabled = true;				
			}
		}

		protected void DDL_ACC_NO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LBL_ACC_NOVAL.Text = DDL_ACC_NO.SelectedValue;

			/***
			 * This Checking is no longer needed because this picklist doesn't need sort-of-validation
			 * (yudi)
			try 
			{
				conn.QueryString = "select PRODUCTID, ACC_SEQ from BOOKEDPROD " + 
									"where AA_NO = '" + DDL_AANO.SelectedValue + 
									"' and ACC_NO = '" + DDL_ACC_NO.SelectedValue + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() == 1) 
				{
					LBL_PRODUCTID.Text = conn.GetFieldValue("PRODUCTID");
					LBL_SEQ.Text = conn.GetFieldValue("ACC_SEQ");
				}
				else 
				{
					Tools.popMessage(this, "Jumlah Facility lebih dari satu !");
					return;
				}
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				Response.Redirect("../Login.aspx?expire=1");
			}
			***/
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}

		protected void DDL_ACC_SEQ_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try 
			{
				conn.QueryString = "select ACC_NO, ACC_NO, AA_NO from BOOKEDPROD " + 
					" where AA_NO = '" + DDL_AANO.SelectedValue + 
					"' and PRODUCTID = '" + DDL_PRODUCTID.SelectedValue + 
					"' and ACC_SEQ = '" + DDL_ACC_SEQ.SelectedValue + 
					"' and CU_REF = '" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			///////////////////////////////////////////////////////
			///	Get the account number of customer
			///	
			if (conn.GetRowCount() > 0) 
			{
				LBL_ACC_NOVAL.Text = conn.GetFieldValue("ACC_NO");

				//DDL_ACC_NO.Items.Add(new ListItem(conn.GetFieldValue("ACC_NO"), conn.GetFieldValue("ACC_NO")));
				GlobalTools.fillRefList(DDL_ACC_NO, conn.QueryString.ToString(), false, conn);
				DDL_ACC_NO.Items.RemoveAt(0);
				try { DDL_ACC_NO.SelectedValue	= conn.GetFieldValue("ACC_NO"); } 
				catch {}
			}
			else 
			{
				LBL_ACC_NOVAL.Text = "";
				DDL_ACC_NO.Items.Clear();
				DDL_ACC_NO.Items.Add(new ListItem("- PILIH -", ""));
			}

			////////////////////////////////////////////////////////
			/// Get the remainig eMAS limit of channeling company
			/// if user decide to make withdrawal credit
			/// 			
			if (RDO_PBARU.SelectedValue == "2") 
			{
				conn.QueryString = "select isnull(REMAINING_EMAS_LIMIT, 0) REMAINING_EMAS_LIMIT from BOOKEDPROD " + 
					" where ISCHANNFACILITY = '1' " + 
					" and AA_NO = '" + DDL_AANO.SelectedValue + 
					"' and PRODUCTID = '" + DDL_PRODUCTID.SelectedValue + 
					"' and ACC_SEQ = '" + DDL_ACC_SEQ.SelectedValue + 
					"' and CU_REF = '" + DDL_CHANNCOMP.SelectedValue + "'";
				conn.ExecuteQuery();

				LBL_REMAINING_EMAS_LIMIT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("REMAINING_EMAS_LIMIT"));
			}
		}

		private void DGR_KETENTUANKREDIT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_KETENTUANKREDIT.CurrentPageIndex = e.NewPageIndex;
			viewData();
		}

		protected void BTN_CANCEL_ADD_Click(object sender, System.EventArgs e)
		{
			//creddetail.Attributes.Add("src","");
			TXT_KETKREDIT_DESC.Text = "";
			TBL_DETAIL.Visible = false;

			BTN_ADD.Visible = true;
			BTN_CANCEL_ADD.Visible = false;

			RDO_PBARU.Enabled = true;
			TXT_KETKREDIT_DESC.ReadOnly = false;

			LBL_KETENTUAN_KREDIT.Visible = false;
			BTN_SAVE.Enabled = false;
			DDL_PRJ_CODE.Enabled = true;

			DDL_CHANNCOMP.Enabled = false;
			LBL_REMAINING_EMAS_LIMIT.Text = "";

			if (RDO_PBARU.SelectedValue != "1")		//--- Bukan Permohonan Baru
			{
				AA_NO.Enabled = true;
				DDL_AANO.Enabled = true;

				DDL_PRODUCTID.Enabled	= true;
				DDL_ACC_SEQ.Enabled		= true;

				//LBL_ACC_NO.Enabled		= true;
				LBL_ACC_NOVAL.Visible	= true;
				DDL_ACC_NO.Enabled		= true;

				LBL_PRODUCTID.Visible = true;
				LBL_SEQ.Visible = true;	
			}

			if (RDO_PBARU.SelectedValue == "2") 
			{
				DDL_CHANNCOMP.Enabled = true;
			}
		}


		private void BTN_PROJECTLIST_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script for=window event=onload language='javascript'>PopupPage('../ProjectInfo.aspx?targetFormID=Form1', '800','600');</script>");
			//Response.Write("<script language='javascript'>window.open('../ProjectInfo.aspx?regno=" + LBL_REGNO.Text + "&curef=" + LBL_CUREF.Text + "&sta=view','ProjectInfo','status=no,scrollbars=yes,width=800,height=600');</script>");
		}


		protected void DDL_CHANNCOMP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			GlobalTools.fillRefList(DDL_AANO, "select distinct AA_NO, AA_NO from VW_CHANN_FAC where cu_ref = '" + DDL_CHANNCOMP.SelectedValue + "'", false, conn);
			LBL_REMAINING_EMAS_LIMIT.Text = "";
		}

		protected void DDL_NCLPROD_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (DDL_NCLPROD.SelectedValue != "")
			{
				conn.QueryString = "EXEC IDE_POSTFIN_GETNCLLIMIT '" + DDL_NCLPROD.SelectedValue + "'";
				conn.ExecuteQuery();

				LBL_REMAINING_NCL_LIMIT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("CP_LIMIT"));
			}
			else
			{
				LBL_REMAINING_NCL_LIMIT.Text = "";
			}
		}
	}
}
