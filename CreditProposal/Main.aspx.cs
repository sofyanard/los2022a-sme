using System;
using System.IO;
using System.Runtime.Remoting;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.CreditProposal
{	
	/// <summary>
	/// Summary description for Main.
	/// </summary>
	public partial class Main : System.Web.UI.Page
	{
		protected Connection conn;
		protected Connection conn2;
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.DataGrid DATAGRID1;
		protected System.Web.UI.WebControls.TextBox TXT_FILE_NAME;
		string var_direct;
		string var_user, var_idExport1, var_idExport2, var_Nota, var_branch, var_group, var_Name;
		string m_in_small=string.Empty;
		string m_in_middle =string.Empty;
		string m_in_corporate =string.Empty;
		string m_in_crg =string.Empty;
		string m_in_micro =string.Empty;
		string prog_code =string.Empty;

        private SMEExportImport.WordClient client;

		protected void Page_Load(object sender, System.EventArgs e)
		{	
			conn = (Connection) Session["Connection"];
			conn2 = new Connection("Data Source=10.123.13.18;Initial Catalog=LOSSME;uid=psa;pwd=dmscorp;Pooling=true");

            client = new SMEExportImport.WordClient();

			var_user = (string)Session["UserID"];
			var_group = (string)Session["GroupID"];
			var_branch = (string)Session["BranchID"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			conn.QueryString = "Select PROG_CODE from APPLICATION where AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			prog_code = conn.GetFieldValue("PROG_CODE");

			conn.QueryString = "select in_small, in_middle, in_corporate, in_crg, in_micro from rfinitial";
			conn.ExecuteQuery();

			m_in_small = conn.GetFieldValue("in_small");
			m_in_middle = conn.GetFieldValue("in_middle");
			m_in_corporate = conn.GetFieldValue("in_corporate");
			m_in_crg = conn.GetFieldValue("in_crg");
			m_in_micro = conn.GetFieldValue("in_micro");
			
			if (!IsPostBack)
			{
				ViewDataApplication();
				ViewFileUpload();
				
				var_Nota = "select NOTA_ID, NOTA_DESC from NOTA_ANALISA where PROGRAMID = '" + prog_code + " 'order by NOTA_DESC";
				GlobalTools.fillRefList(DDL_FORMAT_TYPE, var_Nota , false, conn);

				if(conn.GetRowCount()>0)
				{
					var_Nota = "select KET_CODE, KET_DESC from KETENTUAN_KREDIT where AP_REGNO = '" + Request.QueryString["regno"] + " '";
					GlobalTools.fillRefList(DDL_KETENTUAN, var_Nota , false, conn);
				}

				var_Nota = "exec CP_GET_BOD_LIST '" + Request.QueryString["regno"] + "', '" + var_user + "'";
				GlobalTools.fillRefList(ddl_nextendorse, var_Nota , false, conn);
				
				ViewFileExport();

                DocumentExportCP.GroupTemplate = "CREDPROP";
			}

			SecureData();
			ViewMenu();
			setButtonsStatus();
			BTN_EXPORT.Attributes.Add("onclick", "if (!exportInProgress()) { return false; }");
			//updatestatus.Attributes.Add("onclick", "if (!confirmFwd()) { return false; }");
			updatestatus.Attributes.Add("onclick", "if (!updateMsgF()) { return false; }");



			var_idExport1 = DDL_FORMAT_TYPE.SelectedValue;
			var_idExport2 = DDL_KETENTUAN.SelectedValue;

			conn.QueryString = "select KET_CODE, KET_DESC from KETENTUAN_KREDIT where AP_REGNO = '" + Request.QueryString["regno"] + "' and KET_CODE = '" + var_idExport2 + "'";
			conn.ExecuteQuery();

			var_Name  = conn.GetFieldValue("KET_DESC");

			/*
			if(var_idExport1==string.Empty)
				BTN_EXPORT.Enabled = false;
			else
				BTN_EXPORT.Enabled = true;
				*/
		}

		private void CekPortfolio()
		{
			conn.QueryString = "select CU_BMSUBSUBSEKTOREKONOMI from customer where cu_ref='"+Request.QueryString["curef"]+"'";
			conn.ExecuteQuery();
				lbl_sekom3.Text = conn.GetFieldValue("CU_BMSUBSUBSEKTOREKONOMI");
			conn.QueryString = "SELECT BI_SEQ FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + lbl_sekom3.Text + "'";
				conn.ExecuteQuery();
			lbl_ksebi4.Text = conn.GetFieldValue("BI_SEQ");
			if (lbl_ksebi4.Text!="")
			{
				DataTable dt				= new DataTable();
				conn2.QueryString			= "exec PORTFOLIO_LIMIT '"+lbl_ksebi4.Text+"'";
				conn2.ExecuteQuery();
				dt							= conn2.GetDataTable().Copy();
				TXT_OUTSTANDING.Text		= conn2.GetFieldValue("OUT_BAL");
				TXT_PENDING.Text			= conn2.GetFieldValue("PENDING_LIMIT");
				TXT_AVAILABLE.Text			= conn2.GetFieldValue("AVAILABLE_LIMIT");
				TXT_RATIO_LIMIT.Text		= conn2.GetFieldValue("RATIO_LIMIT");
				TXT_RATIO_AVAIL.Text		= conn2.GetFieldValue("AVAILABLE_RATIO");
				TXT_INDUSTRYCLASS.Text		= conn2.GetFieldValue("PD_INDUSTRYCLASS_DESC");
				TXT_STATUS.Text				= conn2.GetFieldValue("STATUS");

				TXT_OUTSTANDING.Text = tool.MoneyFormat(TXT_OUTSTANDING.Text);
				TXT_PENDING.Text = tool.MoneyFormat(TXT_PENDING.Text);
				TXT_AVAILABLE.Text = tool.MoneyFormat(TXT_AVAILABLE.Text);
				TXT_RATIO_LIMIT.Text = tool.MoneyFormat(TXT_RATIO_LIMIT.Text);
				TXT_RATIO_AVAIL.Text = tool.MoneyFormat(TXT_RATIO_AVAIL.Text);
			}
		}

		private bool CheckUpdateStatus()
		{
			bool isComplete = true;
			string bod = "";
			if (chk_more2person.Checked == true)
				bod = "1";
			else
				bod = "0";

			try
			{
				conn.QueryString = "EXEC CP_CHECKUPDATESTATUS '" + Request.QueryString["regno"] + "', '" +
					ddl_manual.SelectedValue.Trim() + "', '" +
					bod + "', '" +
					ddl_nextendorse.SelectedValue.Trim() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					if (conn.GetFieldValue("OK") == "1")
						isComplete = true;
					else
						isComplete = false;
				}
				else
					isComplete = false;
			}
			catch (Exception e)
			{
				isComplete = false;
				//Response.Write("<!-- " + e.Message + "\n" + e.StackTrace + " -->\n" );
                exceptionString = "<script language='javascript'> window.onload = function () {alert('" + e.Message.ToString().Replace("'", "").Replace("\"", "") + "');}</script>";
			}

			return isComplete;
		}

		private void setButtonsStatus()
		{
			conn.QueryString = "exec CP_SETBUTTONMAIN '" + Request.QueryString["regno"] + "', '" +
				DDL_KETENTUAN.SelectedValue + "', '" + DDL_FORMAT_TYPE.SelectedValue + "' ";
			conn.ExecuteQuery();
			BTN_UPLOAD.Enabled = false;
			BTN_EXPORT.Enabled = false;
			BTN_SAVE.Enabled = false;
			updatestatus.Enabled = false;
			btn_PrintScoringResult.Enabled = false;
			try
			{
				if(conn.GetFieldValue(0,"UPLOAD") == "1")
					BTN_UPLOAD.Enabled = true;
				if(conn.GetFieldValue(0,"EXPORT") == "1")
					BTN_EXPORT.Enabled = true;
				if(conn.GetFieldValue(0,"SAVE") == "1")
					BTN_SAVE.Enabled = true;
				if(conn.GetFieldValue(0,"FWDAPPR") == "1")
					updatestatus.Enabled = true;
				if(conn.GetFieldValue(0,"PRINTSCORINGRESULT") == "1")
					btn_PrintScoringResult.Enabled = true;
				if(conn.GetFieldValue(0,"MSG") != "")
					GlobalTools.popMessage(this, conn.GetFieldValue(0,"MSG"));
			} 
			catch {}
		}

		private bool isDirekturBanking(string userid) 
		{
			bool retValue = false;
			string isDirekturBanking = "";

			/// memeriksa apakah user merupakan direktur banking
			/// 
			conn.QueryString = "exec APPROVAL_ISDIREKTURBANKING '" + userid + "'";
			conn.ExecuteQuery();
			isDirekturBanking = conn.GetFieldValue("isdirekturbanking");
			
			/// cek return valuenya
			/// 
			if (isDirekturBanking == "TRUE") retValue = true;
			else if (isDirekturBanking == "FALSE") retValue = false;

			return retValue;
		}

		private void SecureData() 
		{
			string cp = Request.QueryString["cp"];
					
			if (cp == "0")
			{
				TXT_FILE_UPLOAD.Disabled = true;
				int index = -1;

				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for(int j=0; j<coll.Count; j++) 
				{
					if (coll[j] is HtmlForm) 
					{
						index = j;
						break;
					}
				}


				/// kalau index = -1, berarti ada yang salah
				/// maka disable secara manual
				/// 
				if (index == -1) 
				{
					BTN_UPLOAD.Visible = false;
					BTN_SAVE.Visible = false;
					btn_PrintScoringResult.Visible = false;
					BTN_EXPORT.Visible = false;
					updatestatus.Visible = false;

					TXT_CP_BLMDIPENUHI.ReadOnly = true;
					TXT_CP_EXCEPTION.ReadOnly = true;
					TXT_CP_PERMASALAHAN.ReadOnly = true;
					ddl_manual.Enabled = false;
					ddl_nextendorse.Enabled = false;
					DDL_KETENTUAN.Enabled = false;
					DDL_FORMAT_TYPE.Enabled = false;

					chk_more2person.Enabled = false;
					return;
				}

				for (int i = 0; i < coll[index].Controls.Count; i++) 
				{
					if (coll[index].Controls[i] is System.Web.UI.WebControls.TextBox) 
					{
						System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) coll[index].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[index].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[index].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[index].Controls[i] is System.Web.UI.WebControls.Button)
					{
						System.Web.UI.WebControls.Button btn = (System.Web.UI.WebControls.Button) coll[index].Controls[i];
						btn.Visible = false;
					}
					else if (coll[index].Controls[i] is System.Web.UI.WebControls.RadioButtonList) 
					{
						System.Web.UI.WebControls.RadioButtonList rbl = (System.Web.UI.WebControls.RadioButtonList) coll[index].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[index].Controls[i] is System.Web.UI.WebControls.RadioButton) 
					{
						System.Web.UI.WebControls.RadioButton rb = (System.Web.UI.WebControls.RadioButton) coll[index].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[index].Controls[i] is System.Web.UI.WebControls.CheckBox)
					{
						System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) coll[index].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[index].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[index].Controls[i];

						for (int j=0; j < htr.Controls.Count; j++) 
						{							
							for (int jj = 0; jj < htr.Controls[j].Controls.Count; jj++) 
							{
								if (htr.Controls[j].Controls[jj] is System.Web.UI.WebControls.TextBox) 
								{
									System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) htr.Controls[j].Controls[jj];
									txt.ReadOnly = true;
								}
								else if (htr.Controls[j].Controls[jj] is System.Web.UI.WebControls.DropDownList) 
								{
									System.Web.UI.WebControls.DropDownList ddl = (System.Web.UI.WebControls.DropDownList) htr.Controls[j].Controls[jj];
									ddl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is System.Web.UI.WebControls.Button)
								{
									System.Web.UI.WebControls.Button btn = (System.Web.UI.WebControls.Button) htr.Controls[j].Controls[jj];
									btn.Visible = false;
								}
								else if (htr.Controls[j].Controls[jj] is System.Web.UI.WebControls.RadioButtonList) 
								{
									System.Web.UI.WebControls.RadioButtonList rbl = (System.Web.UI.WebControls.RadioButtonList) htr.Controls[j].Controls[jj];
									rbl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is System.Web.UI.WebControls.RadioButton) 
								{
									System.Web.UI.WebControls.RadioButton rb = (System.Web.UI.WebControls.RadioButton) htr.Controls[j].Controls[jj];
									rb.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is System.Web.UI.WebControls.CheckBox)
								{
									System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) htr.Controls[j].Controls[jj];
									cb.Enabled = false;
								}					
							}
						}
					}
				}
				//20071003 add by sofyan
				//dioverride utk approval, fungsi upload dokumen diaktifkan
				string ap = Request.QueryString["ap"];
				if (ap == "1")
				{
					TXT_FILE_UPLOAD.Disabled = false;
					BTN_UPLOAD.Visible = true;
				}
			}
		}

		private void ViewDataApplication()
		{
			conn.QueryString = "select * from VW_CP_MAIN_USUL where AP_REGNO = '" +Request.QueryString["regno"]+ "'";
			conn.ExecuteQuery();
			TXT_AP_REGNO.Text		= conn.GetFieldValue("AP_REGNO");
			TXT_CU_REF.Text			= conn.GetFieldValue("CU_REF");
			TXT_AP_SIGNDATE.Text	= tool.FormatDate(conn.GetFieldValue("AP_SIGNDATE"));
			TXT_PROGRAMDESC.Text	= conn.GetFieldValue("PROGRAMDESC");
			TXT_BRANCH_NAME.Text	= conn.GetFieldValue("BRANCH_NAME");
			TXT_AP_RELMNGR.Text		= conn.GetFieldValue("SU_FULLNAME");
			LBL_CU_CUSTTYPEID.Text	= conn.GetFieldValue("CU_CUSTTYPEID");
			TXT_CP_PERMASALAHAN.Text= conn.GetFieldValue("CP_PERMASALAHAN");
			TXT_CP_EXCEPTION.Text	= conn.GetFieldValue("CP_EXCEPTION");
			TXT_CP_BLMDIPENUHI.Text	= conn.GetFieldValue("CP_BLMDIPENUHI");
			TXT_TL.Text = conn.GetFieldValue("AP_TEAMLEADER");
			ViewDataCustomer();

			//get DropDownList data
			if (!IsPostBack)
			{
				try
				{
					conn.QueryString = "EXEC CP_FILLDDLMANUAL '" + Request.QueryString["regno"] + "', '" + Session["UserID"].ToString() + "'";
					conn.ExecuteQuery(150);

					if (conn.GetRowCount() > 0)
					{
						for (int i = 0; i < conn.GetRowCount();i++)
						{
							ddl_manual.Items.Add(new ListItem(conn.GetFieldValue(i,"USERNAME"), conn.GetFieldValue(i,"USERID")));
						}
					}

					if (conn.GetFieldValue("BOD") == "1")
					{
						ddl_manual.Enabled = false;
						chk_more2person.Checked = true;
						ddl_nextendorse.Enabled = true;
					}
				}
				catch (Exception ex)
				{
					string errmsg = ex.Message.Replace("'","");
					if (errmsg.IndexOf("Last Query:") > 0)
						errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
					GlobalTools.popMessage(this, errmsg);
					return;
				}				
			}

			rb_auto.Checked		= false;
			rb_manual.Checked	= true;
		}
		
		/// <summary>
		/// Setelah list USER APPROVAL MANUAL diisi, maka set nilai defaultnya berdasarkan :
		/// 1. Data di application, kalau ada
		/// 2. Data di approval decision
		/// </summary>
		private void setManualUserApproval() 
		{
		}

		private void ViewDataCustomer()
		{
			if (LBL_CU_CUSTTYPEID.Text == "01") //if company
			{
				conn.QueryString = "select * from VW_CUST_COMPANY where CU_REF = '" +Request.QueryString["curef"]+ "'";
				conn.ExecuteQuery();
				TXT_NAME.Text = conn.GetFieldValue("COMPTYPEDESC").Trim()+" "+conn.GetFieldValue("CU_COMPNAME").Trim();
				TXT_ADDRESS1.Text		= conn.GetFieldValue("CU_COMPADDR1");
				TXT_ADDRESS2.Text		= conn.GetFieldValue("CU_COMPADDR2");
				TXT_ADDRESS3.Text		= conn.GetFieldValue("CU_COMPADDR3");
				TXT_CITY.Text			= conn.GetFieldValue("CITYNAME");
				TXT_PHONENUM.Text		= conn.GetFieldValue("CU_COMPPHNAREA").Trim() + " - "+conn.GetFieldValue("CU_COMPPHNNUM").Trim();
				TXT_BUSINESSTYPE.Text	= conn.GetFieldValue("BUSSTYPEDESC");
			}
			else //if personal
			{
				conn.QueryString = "select * from VW_CUST_PERSONAL where CU_REF = '" +Request.QueryString["curef"]+ "'";
				conn.ExecuteQuery();
				TXT_NAME.Text			= conn.GetFieldValue("CU_FIRSTNAME").Trim()+ " "+conn.GetFieldValue("CU_MIDDLENAME").Trim()+" "+conn.GetFieldValue("CU_LASTNAME").Trim();
				TXT_ADDRESS1.Text		= conn.GetFieldValue("CU_ADDR1");
				TXT_ADDRESS2.Text		= conn.GetFieldValue("CU_ADDR2");
				TXT_ADDRESS3.Text		= conn.GetFieldValue("CU_ADDR3");
				TXT_CITY.Text			= conn.GetFieldValue("CITYNAME");
				TXT_PHONENUM.Text		= conn.GetFieldValue("CU_PHNAREA").Trim() + " - "+conn.GetFieldValue("CU_PHNNUM").Trim();
				TXT_BUSINESSTYPE.Text	= conn.GetFieldValue("BUSSTYPEDESC");
			}
		}

		private void ViewFileUpload()
		{
			conn.QueryString = "select CREDANALYSIS_DIR from APP_PARAMETER";
			conn.ExecuteQuery();
			string path = "/SME/" + conn.GetFieldValue("CREDANALYSIS_DIR").ToString().Trim().Replace("\\", "/");
			
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "select AP_REGNO, SEQ, FU_FILENAME, FU_USERID from FILE_UPLOAD where AP_REGNO ='"+ Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrid.DataSource = dt;
			try 
			{
				DatGrid.DataBind();
			} 
			catch 
			{
				DatGrid.CurrentPageIndex = 0;
				DatGrid.DataBind();
			}
			for (int i = 1; i <= DatGrid.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DatGrid.Items[i-1].Cells[3].FindControl("HL_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DatGrid.Items[i-1].Cells[4].FindControl("LinkButton1");
				HpDownload.NavigateUrl = path + DatGrid.Items[i-1].Cells[2].Text.Trim();
				DatGrid.Items[i-1].Cells[1].Text = i.ToString();
				if (Session["UserID"].ToString().Trim() != DatGrid.Items[i-1].Cells[5].Text)
					HpDelete.Visible	= false;

				if (Request.QueryString["cp"] == "0") 
				{
					//HpDownload.Enabled = false;
					HpDelete.Enabled = false;

					//20071003 add by sofyan
					//dioverride utk approval, fungsi upload dokumen diaktifkan
					string ap = Request.QueryString["ap"];
					if (ap == "1")
					{
						HpDelete.Enabled = true;
					}
				}
			}
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = string.Empty;
					if (conn.GetFieldValue(i, 3).Trim()!= string.Empty) 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						if (conn.GetFieldValue(i,3).IndexOf("cp=") < 0) strtemp += "&"+Request.QueryString["cp"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = string.Empty;
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

		private void setApprovalCommitee(string AprvCommittee) 
		{
			conn.QueryString = "update APPLICATION set AP_APRVCOMMITEE = " + tool.ConvertNull(AprvCommittee) + 
				" where AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteNonQuery();
		}

		private void approval_first()
		{
			string var_uplineruser  = string.Empty;
			string var_uplinertrack = string.Empty;
			string var_aprvuntil = string.Empty;
			string bod = "";
			if (chk_more2person.Checked == true)
				bod = "1";
			else
				bod = "0";

			try 
			{
				conn.QueryString = "EXEC CP_UPDATEAPPROVAL '" + Request.QueryString["regno"] + "', '" +
					Session["UserID"].ToString() + "', '" +
					ddl_manual.SelectedValue.Trim() + "', '" +
					bod + "', '" +
					ddl_nextendorse.SelectedValue.Trim() + "'";
				conn.ExecuteQuery();

				var_uplineruser = conn.GetFieldValue("UPLINERUSER");
				var_uplinertrack = conn.GetFieldValue("UPLINERTRACK");
				var_aprvuntil = conn.GetFieldValue("APRVUNTIL");
			} 
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}

			conn.QueryString = "select * from vw_currtrack where ap_regno = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
			System.Data.DataTable dt_currtrack = new System.Data.DataTable();
			dt_currtrack = conn.GetDataTable().Copy();
			for (int i = 0; i < dt_currtrack.Rows.Count;i++) 
			{
				string var_apptype		= dt_currtrack.Rows[i]["apptype"].ToString();
				string var_prod			= dt_currtrack.Rows[i]["productid"].ToString();
				string var_currtrack	= dt_currtrack.Rows[i]["ap_currtrack"].ToString();
				string PROD_SEQ     	= dt_currtrack.Rows[i]["PROD_SEQ"].ToString();
					
				if (var_uplineruser != string.Empty)
				{
					var_direct = "1";
					try 
					{
						conn.QueryString = "exec approval_nexttrack '"+
							Request.QueryString["regno"].ToString()+"', '"+		//regno
							var_prod+"', '"+									//product
							var_apptype+"', '"+									//apptype
							Session["UserID"].ToString()+"', '"+				//userid
							var_uplineruser+"', '"+								//upliner user
							var_uplinertrack+"', " +							//upliner track
							"'0', '"+											//aprvup
							var_aprvuntil+"', '" +								//aprvuntil
							PROD_SEQ + "'";										//prod_seq
						conn.ExecuteQuery();
					} 
					catch (Exception ex)
					{
						ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "App#: " + Request.QueryString["regno"].ToString());
						GlobalTools.popMessage(this, TXT_ERRMSG.Text);
					}
				}
				else
				{
					//GlobalTools.popMessage(this, "Cannot update status, this user has no upliner!");
					GlobalTools.popMessage(this, "Update Status gagal, user tidak punya upliner!");
				}
			}
		}

		private string getNextStepMsg(string regno) 
		{
			string pesan = string.Empty;
			string nextTrack = string.Empty;
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

		private void ViewFileExport()
		{
			conn.QueryString = "Select NOTA_URL from NOTA_ANALISA ";
			conn.ExecuteQuery();
			
			if (conn.GetRowCount() > 0) 
			{
				string url = conn.GetFieldValue("NOTA_URL");
			
				System.Data.DataTable dt = new System.Data.DataTable();
				conn.QueryString = "select * from NOTA_EXPORT where AP_REGNO ='"+ Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
				dt = conn.GetDataTable().Copy();
				DATA_EXPORT.DataSource = dt;
				try 
				{
					DATA_EXPORT.DataBind();
				} 
				catch 
				{
					DATA_EXPORT.CurrentPageIndex = 0;
					DATA_EXPORT.DataBind();
				}
				for (int i = 1; i <= DATA_EXPORT.Items.Count; i++)
				{
					HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("HL_DOWNLOAD");
					LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[3].FindControl("LinkButton1");
					HpDownload.NavigateUrl = url + DATA_EXPORT.Items[i-1].Cells[1].Text.Trim();
					if (var_user.ToString().Trim() != DATA_EXPORT.Items[i-1].Cells[4].Text)
						HpDelete.Visible	= false;

					if (Request.QueryString["cp"] == "0") 
					{
						//HpDownload.Enabled = false;
						HpDelete.Enabled = false;
					}
				}
			}
		}


		private void saveProcessWord(Word.Application wordApp, ArrayList newId, ArrayList orgId) 
		{
			if(wordApp!=null)
			{
				/*
				wordApp.Application.Quit(ref oMissingObject, ref oMissingObject, ref oMissingObject);
				wordApp=null;
				*/

				/// Saving process into database
				/// 
				for(int x = 0; x < newId.Count; x++)
				{
					Process xnewId = (Process)newId[x];
				
					bool bSameId = false;
					for(int z = 0; z < orgId.Count; z++)
					{
						Process xoldId = (Process)orgId[z];
		
						if(xnewId.Id == xoldId.Id) 
						{
							bSameId = true;
							break;
						}
					}

					if (!bSameId) 
					{
						conn.QueryString = "exec SP_STARTPROCESS '" + xnewId.Id + "', '" + xnewId.ProcessName + "', " + GlobalTools.ToSQLDate(xnewId.StartTime.ToString()) + ", 'WORD'";
						conn.ExecuteNonQuery();
						break;

					}
				}

			}
		}

		private void saveProcessExcel(Excel.Application excelApp, ArrayList newId, ArrayList orgId) 
		{
			if(excelApp!=null)
			{
				/*
				excelApp.Workbooks.Close();
				excelApp.Application.Quit();
				excelApp=null;
				*/

				/// Saving process into database
				/// 
				for(int x = 0; x < newId.Count; x++)
				{
					Process xnewId = (Process)newId[x];
								
					bool bSameId = false;
					for(int z = 0; z < orgId.Count; z++)
					{
						Process xoldId = (Process)orgId[z];						
						
						if(xnewId.Id == xoldId.Id) 
						{
							bSameId = true;
							break;
						}
					}

					if (!bSameId) 
					{						
						conn.QueryString = "exec SP_STARTPROCESS '" + xnewId.Id + "', '" + xnewId.ProcessName + "', " + GlobalTools.ToSQLDate(xnewId.StartTime.ToString()) + ", 'EXCEL'";
						conn.ExecuteNonQuery();
						break;
					}
				}
			}
		}


		/// <summary>
		/// Menghapus file hasil upload
		/// </summary>
		/// <param name="directory">directory yang menyimpan file</param>
		/// <param name="filename">nama file saja</param>
		private void deleteFile(string directory, string filename) 
		{
			if (File.Exists(directory + filename)) 
			{
				File.Delete(directory + filename);
			}
		}


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			base.OnInit(e);
            if (!this.DesignMode)
            {
                InitializeComponent();
            }
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.DatGrid.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrid_ItemCommand);
			this.DATA_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_ItemCommand);

		}
		#endregion

		
		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec CP_MAIN '" +
				Request.QueryString["regno"]+ "', '" +
				TXT_CP_PERMASALAHAN.Text+ "', '" +
				TXT_CP_EXCEPTION.Text+ "', '" +
				TXT_CP_BLMDIPENUHI.Text+ "'";
			conn.ExecuteNonQuery();
			ViewDataApplication();
		}

		private void BTN_VIEWNOTA_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('NotaAnalisaMiddle.aspx','NotaAnalisaMiddle','status=no,scrollbars=yes,width=1000,height=700');</script>");
		}

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string path, mStatus = string.Empty, mStatusReport = string.Empty;
			conn.QueryString = "select APP_ROOT, CREDANALYSIS_DIR from APP_PARAMETER";
			conn.ExecuteQuery();
			path = conn.GetFieldValue("APP_ROOT").ToString().Trim()+ conn.GetFieldValue("CREDANALYSIS_DIR").ToString().Trim();
 
			HttpFileCollection uploadedFiles = Request.Files;
			
			int counter = 0, mField = 0;
			LBL_STATUS.Text = string.Empty;
			LBL_STATUSREPORT.Text = string.Empty;
			for (int i = 0; i < uploadedFiles.Count; i++)
			{
				HttpPostedFile userPostedFile = uploadedFiles[i];
				counter = i + 1;
				try
				{
					if (userPostedFile.ContentLength > 0)
					{
						userPostedFile.SaveAs(path + Request.QueryString["regno"].Trim() + "-"+Session["USERID"].ToString()+"-" + Path.GetFileName(userPostedFile.FileName));
						LBL_STATUS.ForeColor = Color.Black;
						LBL_STATUSREPORT.ForeColor = Color.Black;
						mStatus = "Upload Successful!";
						mStatusReport = "<u>File #" + counter.ToString() + "</u><br>" + 
							"File Content Type: " + userPostedFile.ContentType + "<br>" + 
							"File Size: " + userPostedFile.ContentLength + "kb<br>" + 
							"File Name: " + userPostedFile.FileName + "<br>";
						mStatusReport += "Location Where Saved: " + path + Request.QueryString["regno"].Trim() + "-"+Session["USERID"].ToString()+"-" + Path.GetFileName(userPostedFile.FileName) + "<p>";

						int lket = Request.QueryString["regno"].Trim().Length + Session["USERID"].ToString().Trim().Length + 2;
						conn.QueryString = "select FU_FILENAME from FILE_UPLOAD where AP_REGNO = '" +Request.QueryString["regno"]+ "' and FU_USERID = '"+Session["USERID"].ToString()+"'";
						conn.ExecuteQuery();
						for (int j = 0; j < conn.GetRowCount(); j++)
						{
							string fileNameDB = conn.GetFieldValue(j,0).Substring(lket, conn.GetFieldValue(j,0).Trim().Length - lket);
							if (fileNameDB.Trim() == Path.GetFileName(userPostedFile.FileName).Trim())
							{
								mField = mField + 1;
							}
						}


						if (mField == 0)
						{
							conn.QueryString = "exec CA_FILE_UPLOAD '" +Request.QueryString["regno"]+ "', '', '" +Request.QueryString["regno"].Trim() +
								"-"+Session["USERID"].ToString()+"-" + Path.GetFileName(userPostedFile.FileName)+ "', '" +Session["USERID"].ToString()+ "', '1'";
							conn.ExecuteNonQuery();
							ViewFileUpload();
						}
					}
				}

				catch (Exception ex)
				{
					LBL_STATUS.ForeColor = Color.Red;
					LBL_STATUSREPORT.ForeColor = Color.Red;
					mStatus		  = "Error Uploading File";
					mStatusReport = ex.ToString();
				}
				
				LBL_STATUS.Text			= mStatus.Trim();
				LBL_STATUSREPORT.Text	= mStatusReport.Trim();
			
			}
		}

		private void DatGrid_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					/// Function delete file fisik
					/// 
					try 
					{					
						string directory = @"C:\";
						conn.QueryString = "select APP_ROOT + CREDANALYSIS_DIR as FULLPATH from APP_PARAMETER";
						conn.ExecuteQuery();
						directory = conn.GetFieldValue("FULLPATH");						

						deleteFile(directory, e.Item.Cells[2].Text);
						Response.Write("<!-- file : " + directory + e.Item.Cells[2].Text + " -->");
						Response.Write("<!-- file is deleted. -->");
					} 
					catch (Exception ex) 
					{
						Response.Write("<!-- Delete File Error: " + ex.Message.ToString() + " -->");
					}


					conn.QueryString = "exec CA_FILE_UPLOAD '" +Request.QueryString["regno"]+ "', '" +e.Item.Cells[0].Text+ "','','','2'";
					conn.ExecuteNonQuery();
					ViewFileUpload();					
					break;
			}
		}

        private string exceptionString = "";
        public string popUp = "";
        protected void updatestatus_Click(object sender, System.EventArgs e)
		{
            if (!CheckUpdateStatus())
            {
                popUp = exceptionString;
            }
            else
            {
                popUp = "<script for=window event=onload language='javascript'>PopupPage('../VerifyUser.aspx?userid=" + var_user + "&theForm=Form1&theObj=TXT_VERIFY', '430','150');</script>";
            }

            //Response.Write("<script for=window event=onload language='javascript'>PopupPage('../VerifyUser.aspx?userid=" + var_user + "&theForm=Form1&theObj=TXT_VERIFY', '430','150');</script>");
            //popUp = "<script for=window event=onload language='javascript'>PopupPage('../VerifyUser.aspx?userid=" + var_user + "&theForm=Form1&theObj=TXT_VERIFY', '430','150');</script>";
		}
		
		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string backlink = "Body.aspx";

			backlink = DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn);
			Response.Redirect("/SME/" + backlink);
		}

		protected void TXT_VERIFY_TextChanged(object sender, System.EventArgs e)
		{
			if(this.TXT_VERIFY.Text != string.Empty)
			{
				this.TXT_VERIFY.Text = string.Empty;
				
				bool STAUPDATE = true;

				if (STAUPDATE)
				{
					approval_first();

					//////////////////////////////////////////////////////////////////////
					/// audit trail
					try
					{
						conn.QueryString = "SP_AUDITTRAIL_APP '" + 
							Request.QueryString["regno"] + "',null,null,null,'" + 
							Request.QueryString["curef"] + "','" + 
							Request.QueryString["tc"] + "','Credit Proposal - Forward to Approval - '"+ ddl_manual.SelectedItem.Text + ",'"+ 
							ddl_manual.SelectedItem.Text + "','" +  
							Session["userid"].ToString() + "',null,null";
						conn.ExecuteNonQuery();
					}
					catch (Exception ex)
					{ 
						Response.Write("<!-- generate err: " + ex.Message + " -->");
					}
					//// END Audit Trail ////////
					

					if (var_direct == "1")
					{
						string msg = getNextStepMsg(Request.QueryString["regno"]);
						Response.Redirect("ListCreditProposal.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
					}
				}
			}
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					/// Function delete file fisik
					/// 
					try 
					{					
						string directory = @"C:\";
						conn.QueryString = "Select NOTA_PATH from NOTA_ANALISA where nota_id = '" + e.Item.Cells[0].Text + "'";
						conn.ExecuteQuery();
						directory = conn.GetFieldValue("NOTA_PATH");

						deleteFile(directory, e.Item.Cells[2].Text);
						Response.Write("<!-- file : " + directory + e.Item.Cells[2].Text + " -->");
						Response.Write("<!-- file is deleted. -->");
					} 
					catch (Exception ex) 
					{
						Response.Write("<!-- Delete File Error: " + ex.Message.ToString() + " -->");
					}

					conn.QueryString = "exec CP_NOTA_EXPORT '" + e.Item.Cells[0].Text +"','" + Request.QueryString["regno"] + "', '" + e.Item.Cells[5].Text + "','','" + Session["UserID"].ToString() + "', '2'";
					conn.ExecuteQuery();

					ViewFileExport();
					//tambahkan function untuk delete file
					break;
			}
		}

		protected void BTN_EXPORT_Click(object sender, System.EventArgs e)
		{

			string szId = tool.ConvertNull(DDL_FORMAT_TYPE.SelectedValue);
			string mStatus = string.Empty ;
			string mStatusReport = string.Empty;
			
			var_idExport2 = DDL_KETENTUAN.SelectedValue;

			try
			{
				string szUser = ddl_manual.SelectedValue;

				conn.QueryString = "Select * from NOTA_ANALISA where NOTA_ID = '" + var_idExport1 + "'";
				conn.ExecuteQuery();
				
				if (conn.GetRowCount() > 0) 
				{
					string nota = conn.GetFieldValue("NOTA_SHEET");
					string b_unit = conn.GetFieldValue("B_UNIT");

					// Always already when using Export Excel file format
					
					System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
					System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
					
					if(nota=="ANALISA")
					{
                        //if (b_unit.ToUpper() == m_in_small.ToUpper())
                        //    mStatus = p_CreateNotaExcel();
                        //else // call here !!!!
                            //mStatus = p_CreateNotaWord();
                            //mStatus = Export_Word();
                            mStatus = client.CreditProposalMainExport_Word(Request.QueryString["regno"], Session["UserID"].ToString(), var_idExport1, var_idExport2);
					}
					if(nota=="ANALISA2") mStatus = Export_Word();

					if(nota=="NEW") mStatus = p_CreateNew();
					if(nota=="EXIST") mStatus = p_CreateExist();

					// Adding for Word Export
					
					if(nota=="SYARAT") mStatus = p_CreateSyarat();
					if(nota=="SYARAT2") mStatus = p_CreateSyarat2();
					if(nota=="BANK") mStatus = p_CreateBank();
					if(nota=="RATA") mStatus = p_CreateRata();
					if(nota=="URUS") mStatus = p_CreateUrus();
					
					ViewFileExport();

				}
			}
			catch (Exception ex)
			{
				LBL_STATUS_EXPORT.ForeColor = Color.Red;
				LBL_STATUSEXPORT.ForeColor = Color.Red;
				mStatus		  = "Error Exporting File";
				mStatusReport = ex.ToString();
			}
			finally
			{
				LBL_STATUS_EXPORT.Text = mStatus.Trim();
				LBL_STATUSEXPORT.Text = mStatusReport.Trim();
			}
		}

		protected void chk_more2person_CheckedChanged(object sender, System.EventArgs e)
		{
			/// Kalau "if more then 2 person" di pilih, enable PIC dan 
			/// pastikan approval sampai ke direktur banking
			/// 
			if (chk_more2person.Checked == true)  
			{
				ddl_manual.Enabled = false;
				ddl_nextendorse.Enabled = true;	
				try { ddl_manual.SelectedIndex = ddl_manual.Items.Count - 1; } // approval s.d dir banking
				catch {}
			}
			else 
			{
				ddl_manual.Enabled = true;
				ddl_nextendorse.Enabled = false;
			}
			GlobalTools.SetFocus(this, ddl_nextendorse);
		}


		#region p_CreateNotaWord return string
		private string p_CreateNotaWord()
		{
			string szUser = ddl_manual.SelectedValue;
			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			string mStatus = string.Empty;
			string mNotaNumber = string.Empty;
			short Step = 0;
			object objType = Type.Missing;
			bool bSukses = true;
			object objValue = null;					

			System.Data.DataTable dt_field = null;

			conn.QueryString = "Select * from NOTA_ANALISA where NOTA_ID = '" + var_idExport1 + "'";
			conn.ExecuteQuery();
				
			if (conn.GetRowCount() > 0) 
			{
				string nota = conn.GetFieldValue("NOTA_ID");
				string sheet = conn.GetFieldValue("NOTA_SHEET");
				string path = conn.GetFieldValue("NOTA_PATH");
				string file_doc = nota + ".DOT";
				string url = conn.GetFieldValue("NOTA_URL");
				string b_unit = conn.GetFieldValue("B_UNIT");
				string drill = conn.GetFieldValue("DRILL");

				int iItem = 0;

				object oMissingObject = System.Reflection.Missing.Value;
		
				Word.Application wordApp = null;
				Word.Document wordDoc = null;

				ArrayList orgId = new ArrayList();
				ArrayList newId = new ArrayList();
		
				//Collecting Existing Winword in Taskbar

				Process[] oldProcess = Process.GetProcessesByName("WINWORD");
				foreach(Process thisProcess in oldProcess)
					orgId.Add(thisProcess);
		
				try
				{

					wordApp = new Word.ApplicationClass();
					wordApp.Visible = false;

					//Collecting Existing Winword in Taskbar 

					Process[] newProcess = Process.GetProcessesByName("WINWORD");
					foreach(Process thisProcess in newProcess)
						newId.Add(thisProcess);

					/// Save process into database
					/// 					
					//SupportTools.saveProcessWord(wordApp, newId, orgId, conn);

					iItem = 0;
		
					fileNm = Request.QueryString["regno"] + "-" + nota + "-" + var_user + ".DOC";

					object objFileIn = path + file_doc;
					object objFileOut = path + fileNm;
		
					//fileResult = url + fileNm;

					wordDoc = wordApp.Documents.Open(ref objFileIn, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, 
						ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject);

					wordDoc.Activate();
					Word.Bookmarks wordBookMark = (Word.Bookmarks)wordDoc.Bookmarks;

					#region Step Fill General Info
					// Step 1 - mask out the old codes .... dangerous 
					//conn.QueryString = "Select * from NOTA_ANALISA_DETAIL where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.QueryString = "Select NOTA_ID,SEQ,NOTA_COL,NOTA_ROW,NOTA_FIELD,[DESCRIPTION] from NOTA_ANALISA_DETAIL where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_WORD '" + Session["BranchName"] + "', '" + Session["FullName"] + "', '" + Request.QueryString["regno"] + "', '" + var_idExport2 + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							object Cell = dt_field.Rows[i][2];
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(Field);
				
							string strObject = objValue.ToString();

							if(wordBookMark.Exists(Cell.ToString())) 
							{
								try
								{
									strObject = Convert.ToDateTime(objValue).ToShortDateString();
								}
								catch
								{}
								Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook.Select();
								oBook.Range.Text = strObject;
							}
							iItem++;
						}
					}
					#endregion
					#region Step Fill Credit Rating Summary

					//conn.QueryString = "Select * from NOTA_ANALISA_DETAIL2 where NOTA_ROW = 1 and NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.QueryString = "Select NOTA_ID,SEQ,NOTA_COL,NOTA_ROW,NOTA_FIELD,[DESCRIPTION] from NOTA_ANALISA_DETAIL2 where NOTA_ROW = 1 and NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_WORD1_2A '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							object Cell = dt_field.Rows[i][2];
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							string strObject = objValue.ToString();

							if(wordBookMark.Exists(Cell.ToString())) 
							{
								Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook.Select();
								oBook.Range.Text = strObject;
							}
							iItem++;
						}
					}

					//conn.QueryString = "Select * from NOTA_ANALISA_DETAIL2 where NOTA_ROW = 0 and NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.QueryString = "Select NOTA_ID,SEQ,NOTA_COL,NOTA_ROW,NOTA_FIELD,[DESCRIPTION] from NOTA_ANALISA_DETAIL2 where NOTA_ROW = 0 and NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_WORD1_2B '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							object Cell = dt_field.Rows[i][2];
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							string strObject = objValue.ToString();

							if(wordBookMark.Exists(Cell.ToString())) 
							{
								Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook.Select();
								oBook.Range.Text = strObject;
							}
							iItem++;
						}
					}
					#endregion
					#region Step Fill Yang Memutuskan
					conn.QueryString = "Select NOTA_ID,SEQ,NOTA_COL,NOTA_ROW,NOTA_FIELD,[DESCRIPTION] from NOTA_ANALISA_DETAIL9 where NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_WORD9 '" + Request.QueryString["regno"] + "', '" + var_user + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							object Cell = dt_field.Rows[i][2];
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							string strObject = objValue.ToString();

							if(wordBookMark.Exists(Cell.ToString())) 
							{
								Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook.Select();
								oBook.Range.Text = strObject;
							}
							iItem++;
						}
					}
					#endregion
					#region Step Fill Ratio
					conn.QueryString = "Select NOTA_ID,SEQ,STEP,NOTA_COL,NOTA_ROW,NOTA_FIELD,[DESCRIPTION] from NOTA_ANALISA_DETAIL3 where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();
					
					if (drill=="0") 
						conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_WORD3_1 '" + Request.QueryString["regno"] + "', '0'";
					else				
						conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_WORD3_2 '" + Request.QueryString["regno"] + "'";

					conn.ExecuteQuery();

					Step = 0;
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							Step = (short)dt_field.Rows[i][2];
			
							if(Step==j+1)
							{
								object Cell = dt_field.Rows[i][3];
								string Field = dt_field.Rows[i][5].ToString();

								objValue = conn.GetFieldValue(j, Field);

								string strObject = objValue.ToString();

								if(wordBookMark.Exists(Cell.ToString())) 
								{
									Word.Bookmark oBook = wordBookMark.Item(ref Cell);
									oBook.Select();
									oBook.Range.Text = strObject;
								}
								iItem++;
							}
						}
					}

					// fill projection ratio (if exist)
					if (drill=="0")
					{
						conn.QueryString = "Select NOTA_ID,SEQ,STEP,NOTA_COL,NOTA_ROW,NOTA_FIELD,[DESCRIPTION] from NOTA_ANALISA_DETAIL3 where SEQ = 3 and NOTA_ID = '" + nota + "' order by NOTA_ID";
						conn.ExecuteQuery();

						dt_field = conn.GetDataTable().Copy();

						conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_WORD3_1 '" + Request.QueryString["regno"] + "', '1'";
						conn.ExecuteQuery();

						for(int j = 0; j < conn.GetRowCount(); j++)
						{
							for(int i = 0; i < dt_field.Rows.Count; i++)
							{
								object Cell = dt_field.Rows[i][3];
								string Field = dt_field.Rows[i][5].ToString();

								objValue = conn.GetFieldValue(j, Field);

								string strObject = objValue.ToString();

								if(wordBookMark.Exists(Cell.ToString())) 
								{
									Word.Bookmark oBook = wordBookMark.Item(ref Cell);
									oBook.Select();
									oBook.Range.Text = strObject;
								}
								iItem++;
							}
						}
					}
					#endregion
					#region Step Fill Aspek
					conn.QueryString = "Select NOTA_ID,SEQ,NOTA_COL,NOTA_ROW,NOTA_FIELD,[DESCRIPTION] from NOTA_ANALISA_DETAIL2 where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA2 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
			
					string szField = string.Empty;
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						szField = conn.GetFieldValue(j ,"Control");

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							object Cell = dt_field.Rows[i][2];
							string Field = dt_field.Rows[i][4].ToString();

							//objValue = conn.GetFieldValue(Field);
				
							if (Field==szField)
							{
								objValue = conn.GetFieldValue(j, "Nilai");
				
								if(objValue.ToString() == "1") 
									objValue = "X";
								else if(objValue.ToString() == "0")
									objValue = string.Empty;

								string strObject = objValue.ToString();

								if(wordBookMark.Exists(Cell.ToString())) 
								{
									Word.Bookmark oBook = wordBookMark.Item(ref Cell);
									oBook.Select();
									oBook.Range.Text = strObject;
								}

								iItem++;

								break;
							}
						}
					}
					#endregion
					#region Step Fill BU Signature
					// Step 1
					conn.QueryString = "Select NOTA_ID,SEQ,STEP,NOTA_COL,NOTA_ROW,NOTA_FIELD,[DESCRIPTION] from NOTA_ANALISA_DETAIL10 where Step = 1 and NOTA_ID = '" + nota + "'";
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_BU '" + szUser + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							object Cell = dt_field.Rows[i][3];
							string Field = dt_field.Rows[i][5].ToString();

							objValue = conn.GetFieldValue(j, Field);

							string strObject = objValue.ToString();

							if(wordBookMark.Exists(Cell.ToString())) 
							{
								Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook.Select();
								oBook.Range.Text = strObject;
							}

							iItem++;
						}
					}
					#endregion 
					#region Step Fill RM Signature
					// Step 1
					conn.QueryString = "Select NOTA_ID,SEQ,STEP,NOTA_COL,NOTA_ROW,NOTA_FIELD,[DESCRIPTION] from NOTA_ANALISA_DETAIL10 where Step = 2 and NOTA_ID = '" + nota + "'";
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_RM '" + szUser + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							object Cell = dt_field.Rows[i][3];
							string Field = dt_field.Rows[i][5].ToString();

							objValue = conn.GetFieldValue(j, Field);

							string strObject = objValue.ToString();

							if(wordBookMark.Exists(Cell.ToString())) 
							{
								Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook.Select();
								oBook.Range.Text = strObject;
							}

							iItem++;
						}
					}
					#endregion 
					#region Step Fill BU FRONT Signature
					// Step 1
					conn.QueryString = "Select NOTA_ID,SEQ,STEP,NOTA_COL,NOTA_ROW,NOTA_FIELD,[DESCRIPTION] from NOTA_ANALISA_DETAIL10 where Step = 3 and NOTA_ID = '" + nota + "'";
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_BUFRONT '" + szUser + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							object Cell = dt_field.Rows[i][3];
							string Field = dt_field.Rows[i][5].ToString();

							objValue = conn.GetFieldValue(j, Field);

							string strObject = objValue.ToString();

							if(wordBookMark.Exists(Cell.ToString())) 
							{
								Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook.Select();
								oBook.Range.Text = strObject;
							}

							iItem++;
						}
					}
					#endregion 
					#region Step Fill RM FRONT Signature
					// Step 1
					conn.QueryString = "Select NOTA_ID,SEQ,STEP,NOTA_COL,NOTA_ROW,NOTA_FIELD,[DESCRIPTION] from NOTA_ANALISA_DETAIL10 where Step = 4 and NOTA_ID = '" + nota + "'";
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_RMFRONT '" + szUser + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							object Cell = dt_field.Rows[i][3];
							string Field = dt_field.Rows[i][5].ToString();

							objValue = conn.GetFieldValue(j, Field);

							string strObject = objValue.ToString();

							if(wordBookMark.Exists(Cell.ToString())) 
							{
								Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook.Select();
								oBook.Range.Text = strObject;
							}

							iItem++;
						}
					}
					#endregion 

					if(iItem > 0) 
					{
						wordDoc.SaveAs(ref objFileOut, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, 
							ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject);

						System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));  																					 
						bSukses = true;
					}
					else
						bSukses = false;

					if(bSukses)	
					{
						// Maintenance Table Nota_Export

						if(var_idExport2==string.Empty)
							conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','NOTA','" + fileNm + "','" + Session["UserID"] + "', '1'";
						else
							conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','" + var_idExport2 + "','" + fileNm + "', '" + Session["UserID"] + "', '1'";

						conn.ExecuteQuery();
						mStatus = "Export Succesfully";

					}
					else
					{
						mStatus = "No Data to Export";
					}
				}
				catch (Exception e)
				{
					Response.Write("<!-- " + e.Message + "\n" + e.StackTrace + " -->\n" );
				}
				finally
				{

					if(wordDoc!=null)
					{
						wordDoc.Close(ref oMissingObject, ref oMissingObject, ref oMissingObject);
						wordDoc=null;
					}
					if(wordApp!=null)
					{
						wordApp.Application.Quit(ref oMissingObject, ref oMissingObject, ref oMissingObject);
						wordApp=null;
					}
				}
				
				try 
				{
					for(int x = 0; x < newId.Count; x++)
					{
						Process xnewId = (Process)newId[x];
				
						bool bSameId = false;
						for(int z = 0; z < orgId.Count; z++)
						{
							Process xoldId = (Process)orgId[z];
		
							if(xnewId.Id == xoldId.Id) 
							{
								bSameId = true;
								break;
							}
						}
                        if (!bSameId)
                        {
                            try
                            {
                                xnewId.Kill();
                            }
                            catch (Exception e)
                            {
                                continue;
                            }
                        }
					}
				}
				catch { }
						// Killing Proses after Export					
					
				
			}
			return mStatus;
		}
		#endregion
		#region p_CreateNotaExcel return string
		private string p_CreateNotaExcel()
		{	
			string szUser = ddl_manual.SelectedValue;
			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			string mNotaNumber = string.Empty;
			short Step = 0;
			object objPaste = null;
			object objCopy = null;
			bool bSukses = true;
			object objValue = null;
			object objType = Type.Missing;		
			string mStatus = string.Empty;
			int iItem = 0;
			int iItemOther = 0;
			int iItemPosition = 0;
			int m_Row = 0;

			System.Data.DataTable dt_field = null;

			conn.QueryString = "Select * from NOTA_ANALISA where NOTA_ID = '" + var_idExport1 + "'";
			conn.ExecuteQuery();
				
			if (conn.GetRowCount() > 0) 
			{
				string nota = conn.GetFieldValue("NOTA_ID");
				string sheet = conn.GetFieldValue("NOTA_SHEET");
				string path = conn.GetFieldValue("NOTA_PATH");
				string file_xls = nota + ".XLT";
				string url = conn.GetFieldValue("NOTA_URL");
			
				Excel.Application excelApp = null;
				Excel.Workbook excelWorkBook = null;
				Excel.Sheets excelSheet = null;

				ArrayList orgId = new ArrayList();
				ArrayList newId = new ArrayList();
				
				//Collecting Existing Excel in Taskbar

				Process[] oldProcess = Process.GetProcessesByName("EXCEL");
				foreach(Process thisProcess in oldProcess)
					orgId.Add(thisProcess);

				try
				{
					excelApp = new Excel.ApplicationClass();
					excelApp.Visible = false;
					excelApp.DisplayAlerts = false;					

					//Collectiong Existing Excel in Taskbar
					
					Process[] newProcess = Process.GetProcessesByName("EXCEL");
					foreach(Process thisProcess in newProcess)
						newId.Add(thisProcess);

					/// Save process into database
					/// 					
					//SupportTools.saveProcessExcel(excelApp, newId, orgId, conn);
					
							
					fileIn = path + file_xls;

					excelWorkBook = excelApp.Workbooks.Open(fileIn, 0, false, 5, string.Empty, string.Empty, true, Excel.XlPlatform.xlWindows, "\t|",
						false, false, 0, true);

					excelSheet = excelWorkBook.Worksheets;

					Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheet);
						
					var_idExport2 = string.Empty;
					fileNm = Request.QueryString["regno"] + "-" + nota + "-" +  var_user + ".XLS";
					fileOut = path + fileNm;

					// Sheet ANALISA
					#region Step Fill General Info
					// Step 1
					conn.QueryString = "Select NOTA_ID, SEQ, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();
	
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA '" + Session["BranchName"] + "', '" + Session["FullName"] + "', '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3]);
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;
		
							iItem++;
						}
					}
					#endregion 
					#region Step Fill Multi Ketentuan Kredit
					// Step 2.1
					conn.QueryString = "Select NOTA_ID, SEQ, STEP, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL1_0 where NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();
	
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA1_0 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
				
					if((conn.GetRowCount()>1) && (dt_field.Rows.Count>1))
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][4]);

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(),
								"IV" + iItemPosition.ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
							iItemOther = iItemPosition + j;
						}

						Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemOther + 1).ToString().Trim(), "IV" + (iItemOther + 1).ToString().Trim());
						objCopy = exlCopy.Copy(objType);

						Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemOther.ToString().Trim());
						objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
					}

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 1;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][3].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][4])+ m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][5].ToString();

							if(Field == "NUM")
								objValue = j + 1 ;
							else
								objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;

							iItem++;
						}
					}
					#endregion
					#region Step Fill Hubungan dengan Bank Mandiri 1
					// Step 2.1
					conn.QueryString = "Select NOTA_ID, SEQ, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL1_1 where NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();
	
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA1_1 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
				
					if((conn.GetRowCount()>1) && (dt_field.Rows.Count>1))
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][3]) + m_Row;

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + iItemPosition.ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
							iItemOther = iItemPosition + j;
						}

						Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemOther + 1).ToString().Trim(), "IV" + (iItemOther + 1).ToString().Trim());
						objCopy = exlCopy.Copy(objType);

						Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemOther.ToString().Trim());
						objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
					}
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 1;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3]) + m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();
							if(Field == "NUM")
								objValue = j + 1 ;
							else
								objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;

							iItem++;
						}
					}
					#endregion
					#region Step Fill Hubungan dengan Bank Mandiri 2
					// Step 2.2
					conn.QueryString = "Select NOTA_ID, SEQ, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL1_2 where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();
	
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA1_2 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();

					if((conn.GetRowCount()>1) && (dt_field.Rows.Count>1))
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][3]) +  m_Row;

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + iItemPosition.ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
							iItemOther = iItemPosition + j;
						}

						Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemOther + 1).ToString().Trim(), "IV" + (iItemOther + 1).ToString().Trim());
						objCopy = exlCopy.Copy(objType);

						Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemOther.ToString().Trim());
						objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
					}		
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 1;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3]) + m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();
							if(Field == "NUM")
								objValue = j + 1 ;
							else
								objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;
						}
					}
					#endregion		
					#region Step Fill Hubungan dengan Bank Lain
					// Step 2.3
					conn.QueryString = "Select NOTA_ID, SEQ, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL1_3 where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();
	
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA1_3 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();

					if((conn.GetRowCount()>1) && (dt_field.Rows.Count>1))
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][3]) +  m_Row;

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + iItemPosition.ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
							iItemOther = iItemPosition + j;
						}

						Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemOther + 1).ToString().Trim(), "IV" + (iItemOther + 1).ToString().Trim());
						objCopy = exlCopy.Copy(objType);

						Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemOther.ToString().Trim());
						objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
					}		
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 1;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3]) + m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;
						}
					}
					#endregion
					#region Step Fill Aspek
					conn.QueryString = "Select NOTA_ID, SEQ, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL2 where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();
	
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA2 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
					
					string szField = string.Empty;
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						//szField = conn.GetFieldValue(j ,"Control");

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							try
							{
								string Col = dt_field.Rows[i][2].ToString().Trim();
								int Row = Convert.ToInt32(dt_field.Rows[i][3]) + m_Row;
								string Cell = Col + Row.ToString().Trim();
								string Field = dt_field.Rows[i][4].ToString();

								objValue = conn.GetFieldValue(j,Field);		
								Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
								excelCell.Value2 = objValue;
							} 
							catch {}
							/*
							if (Field==szField)
							{
								objValue = conn.GetFieldValue(j, "Nilai");

								if(objValue.ToString() == "1") 
									objValue = "X";
								else if(objValue.ToString() == "0")
									objValue = string.Empty;


								Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
								excelCell.Value2 = objValue;

								iItem++;

								break;
							}*/
						}
					}
					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA2E '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
					
					szField = string.Empty;
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						szField = conn.GetFieldValue(j ,"Control");

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3]) + m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();
							if (Field==szField)
							{
								objValue = conn.GetFieldValue(j, "Nilai");

								if(objValue.ToString() == "1") 
									objValue = "X";
								else if(objValue.ToString() == "0")
									objValue = string.Empty;

								Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
								excelCell.Value2 = objValue;

								iItem++;

								break;
							}
						}
					}

					#endregion
					#region Step Fill Ratio
					conn.QueryString = "Select NOTA_ID, SEQ, STEP, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL3 where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();
	
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA3 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();

					Step = 0;
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							Step = (short)dt_field.Rows[i][2];
					
							if(Step==j+1)
							{
								string Col = dt_field.Rows[i][3].ToString().Trim();
								int Row = Convert.ToInt32(dt_field.Rows[i][4]) + m_Row;
								string Cell = Col + Row.ToString().Trim();
								string Field = dt_field.Rows[i][5].ToString();

								objValue = conn.GetFieldValue(j, Field);

								Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
								excelCell.Value2 = objValue;
		
								iItem++;
							}
						}
					}
					#endregion
					#region Step Fill Signature
					// Step 2.2
					conn.QueryString = "Select NOTA_ID, SEQ, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL9 where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();
	
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA9 '" + Request.QueryString["regno"] + "', '" + var_user + "'" ;
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3]) + m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;
						}
					}
					#endregion		
					#region Step Fill BU Signature
					// Step 1
					conn.QueryString = "Select NOTA_ID, SEQ, STEP, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL10 where Step = 1 and NOTA_ID = '" + nota + "'";
					conn.ExecuteQuery();
	
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_BU '" + szUser + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][3].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][4]) + m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][5].ToString();

							objValue = conn.GetFieldValue(Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;
		
							iItem++;
						}
					}
					#endregion 
					#region Step Fill RM Signature
					// Step 1
					conn.QueryString = "Select NOTA_ID, SEQ, STEP, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL10 where Step = 2 and NOTA_ID = '" + nota + "'";
					conn.ExecuteQuery();
	
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_RM '" + szUser + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][3].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][4]) + m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][5].ToString();

							objValue = conn.GetFieldValue(Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;
		
							iItem++;
						}
					}
					#endregion 

					if(iItem > 0) 
					{
						excelWorkBook.SaveAs(fileOut, Excel.XlFileFormat.xlWorkbookNormal, null, null, null, null,
							Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, true);
						
						System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));  																					 
						bSukses = true;
					}
					else
						bSukses = false;

					if(bSukses)	
					{
						// Maintenance Table Nota_Export
							
						if(var_idExport2==string.Empty)
							conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','NOTA','" + fileNm + "','" + Session["UserID"] + "', '1'";
						else
							conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','" + var_idExport2 + "','" + fileNm + "', '" + Session["UserID"] + "', '1'";
							
						conn.ExecuteQuery();
						mStatus = "Export Succesfully";

					}
					else
					{
						mStatus = "No Data to Export";
					}
				}
				catch (Exception e)
				{
					Response.Write("<!-- " + e.Message + "\n" + e.StackTrace + " -->\n" );
				}
				finally
				{
					if(excelWorkBook!=null)
					{
						excelWorkBook.Close(true , fileOut, null);
						excelWorkBook=null;
					}
					if(excelApp!=null)
					{
						excelApp.Workbooks.Close();
						excelApp.Application.Quit();
						excelApp=null;
					}
				}
				try 
				{
					// Killing Proses after Export
					for(int x = 0; x < newId.Count; x++)
					{
						Process xnewId = (Process)newId[x];
								
						bool bSameId = false;
						for(int z = 0; z < orgId.Count; z++)
						{
							Process xoldId = (Process)orgId[z];
						
							if(xnewId.Id == xoldId.Id) 
							{
								bSameId = true;
								break;
							}
						}
                        if (!bSameId)
                        {
                            try
                            {
                                xnewId.Kill();
                            }
                            catch (Exception e)
                            {
                                continue;
                            }
                        }
					}
				}
				catch { }				
		}
			return mStatus;
		}
		#endregion
		#region p_CreateNew return string
		private string p_CreateNew()
		{
			string szUser = ddl_manual.SelectedValue;

			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			object objPaste = null;
			object objCopy = null;
			bool bSukses = true;
			object objValue = null;
			object objType = Type.Missing;		
			string mStatus = string.Empty;
			int iItem = 0;
			int iItemOther = 0;
			int iItemPosition = 0;
			int m_Row = 0;


			System.Data.DataTable dt_field = null;
			System.Data.DataTable dt_field2 = null;

			conn.QueryString = "Select * from NOTA_ANALISA where NOTA_ID = '" + var_idExport1 + "'";
			conn.ExecuteQuery();
				
			if (conn.GetRowCount() > 0) 
			{
				string nota = conn.GetFieldValue("NOTA_ID");
				string sheet = conn.GetFieldValue("NOTA_SHEET");
				string path = conn.GetFieldValue("NOTA_PATH");
				string file_xls = nota + ".XLT";
				string url = conn.GetFieldValue("NOTA_URL");

				Excel.Application excelApp = null;
				Excel.Workbook excelWorkBook = null;
				Excel.Sheets excelSheet = null;

				ArrayList orgId = new ArrayList();
				ArrayList newId = new ArrayList();
						
				Process[] oldProcess = Process.GetProcessesByName("EXCEL");
				foreach(Process thisProcess in oldProcess)
					orgId.Add(thisProcess);

				if(var_idExport2!=string.Empty)
				{
					try
					{
						excelApp = new Excel.ApplicationClass();
						excelApp.Visible = false;
						excelApp.DisplayAlerts = false;						

						Process[] newProcess = Process.GetProcessesByName("EXCEL");
						foreach(Process thisProcess in newProcess)
							newId.Add(thisProcess);

						/// Save process into database
						/// 
						//SupportTools.saveProcessExcel(excelApp, newId, orgId, conn);
							
						fileIn = path + file_xls;

						excelWorkBook = excelApp.Workbooks.Open(fileIn, 0, false, 5, string.Empty, string.Empty, true, Excel.XlPlatform.xlWindows, "\t|",
							false, false, 0, true);

						excelSheet = excelWorkBook.Worksheets;

						Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheet);
						Excel.Worksheet excelWorkSheetWork = (Excel.Worksheet)excelSheet.get_Item("WORK");
						
						fileNm = Request.QueryString["regno"] + "-" + nota + "-" + var_Name + "-" + prog_code + "-" + var_user + ".XLS";
						fileOut = path + fileNm;
						//fileResult = url + fileNm;

						// Sheet NEW
						#region Step Fill MultiKetentuan New
							
						// Step 2.1

						conn.QueryString = "Select NOTA_ID, SEQ, STEP, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL7 where step = 0 and NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
						conn.ExecuteQuery();
				
						dt_field = conn.GetDataTable().Copy();

						conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA7_0 '" + Request.QueryString["regno"] + "', '" + var_idExport2 + "'";
						conn.ExecuteQuery();
							
						m_Row = 0;

						for(int j = 0; j < conn.GetRowCount(); j++)
						{
							for(int i = 0; i < dt_field.Rows.Count; i++)
							{
								string Col = dt_field.Rows[i][3].ToString().Trim();
								int Row = Convert.ToInt32(dt_field.Rows[i][4]) ;
								string Cell = Col + Row.ToString().Trim();
								string Field = dt_field.Rows[i][5].ToString();

								objValue = conn.GetFieldValue(j, Field);

								Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
								excelCell.Value2 = objValue;

								iItem++;
							}
						}


						// Step 2.2

						conn.QueryString = "Select NOTA_ID, SEQ, STEP, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL7 where step = 1 and NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
						conn.ExecuteQuery();
				
						dt_field = conn.GetDataTable().Copy();

						conn.QueryString = "exec DE_TOTALEXPOSURE '" + Request.QueryString["regno"] + "'";
						conn.ExecuteQuery(300);
							
						m_Row = 0;

						for(int j = 0; j < conn.GetRowCount(); j++)
						{
							for(int i = 0; i < dt_field.Rows.Count; i++)
							{
								string Col = dt_field.Rows[i][3].ToString().Trim();
								int Row = Convert.ToInt32(dt_field.Rows[i][4]) ;
								string Cell = Col + Row.ToString().Trim();
								string Field = dt_field.Rows[i][5].ToString();

								objValue = conn.GetFieldValue(Field);

								Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
								excelCell.Value2 = objValue;

								iItem++;
							}
						}

						#region Include Agunan
						// Step 2.1
						conn.QueryString = "Select NOTA_ID, SEQ, STEP, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL4 where NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
						conn.ExecuteQuery();
			
						dt_field2 = conn.GetDataTable().Copy();

						conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA4_1 '" + Request.QueryString["regno"] + "','" + var_idExport2 + "','01'";
						conn.ExecuteQuery();
						#region OLD_INSERTION
						/***** MASK OUT OLEH DENNY ------
						if((conn.GetRowCount()>1) && (dt_field2.Rows.Count>1))
						{
							#region Inserting
							// Ini insert untuk Sheet New
							iItemPosition = Convert.ToInt32(dt_field2.Rows[0][4]) + 1;

							//Prepare Empty Row with all Formats
							for(int k = 0; k < conn.GetRowCount()-1; k++)
							{
								Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + iItemPosition.ToString().Trim()).EntireRow;
								excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

								Excel.Range excelRangeWork = excelWorkSheetWork.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + iItemPosition.ToString().Trim()).EntireRow;
								excelRangeWork.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
								
								iItemOther = iItemPosition + k;
							}

							Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemPosition - 1).ToString().Trim(), "IV" + (iItemPosition - 1).ToString().Trim());
							objCopy = exlCopy.Copy(objType);

							Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemOther.ToString().Trim());
							objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

							Excel.Range exlCopyWork = excelWorkSheetWork.get_Range("A" + (iItemPosition - 1).ToString().Trim(), "IV" + (iItemPosition - 1).ToString().Trim());
							objCopy = exlCopyWork.Copy(objType);

							Excel.Range exlPasteWork = excelWorkSheetWork.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemOther.ToString().Trim());
							objPaste = exlPasteWork.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
							#endregion
						}
						****/
						#endregion
						for(int k = 0; k < conn.GetRowCount(); k++)
						{
							if(k > 0) m_Row = m_Row + 1;

							for(int l = 0; l < dt_field2.Rows.Count; l++)
							{
								string Col1 = dt_field2.Rows[l][3].ToString().Trim();
								int Row1 = Convert.ToInt32(dt_field2.Rows[l][4]) + m_Row;
								string Cell1 = Col1 + Row1.ToString().Trim();
								string Field1 = dt_field2.Rows[l][5].ToString();
								if(Field1 == "NUM")
									objValue = k + 1 ;
								else
									objValue = conn.GetFieldValue(k, Field1);

								Excel.Range excelCell1 = (Excel.Range)excelWorkSheet.get_Range(Cell1, Cell1);
								excelCell1.Value2 = objValue;

								iItem++;
							}
						}
						#endregion
						#endregion

						if(iItem > 0) 
						{
							excelWorkSheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;
							excelWorkBook.SaveAs(fileOut, Excel.XlFileFormat.xlWorkbookNormal, null, null, null, null,
								Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, true);
						
							System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));  																					 
							bSukses = true;
						}
						else
							bSukses = false;

						if(bSukses)	
						{
							// Maintenance Table Nota_Export
							
							if(var_idExport2==string.Empty)
								conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','NOTA','" + fileNm + "','" + Session["UserID"] + "', '1'";
							else
								conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','" + var_idExport2 + "','" + fileNm + "', '" + Session["UserID"] + "', '1'";
							
							conn.ExecuteQuery();

							mStatus = "Export Succesfully";

						}
						else
						{
							mStatus = "No Data to Export";
						}
					}
					catch (Exception e) 
					{
						Response.Write("<!-- " + e.Message + "\n" + e.StackTrace + " -->\n" );
					}
					finally
					{
						if(excelWorkBook!=null)
						{
							excelWorkBook.Close(true , fileOut, null);
							excelWorkBook=null;
						}
						if(excelApp!=null)
						{
							excelApp.Workbooks.Close();
							excelApp.Application.Quit();
							excelApp=null;
						}
					}
					try 
					{
						for(int x = 0; x < newId.Count; x++)
						{
							Process xnewId = (Process)newId[x];
								
							bool bSameId = false;
							for(int z = 0; z < orgId.Count; z++)
							{
								Process xoldId = (Process)orgId[z];
						
								if(xnewId.Id == xoldId.Id) 
								{
									bSameId = true;
									break;
								}
							}
                            if (!bSameId)
                            {
                                try
                                {
                                    xnewId.Kill();
                                }
                                catch (Exception e)
                                {
                                    continue;
                                }
                            }
						}
					}
					catch { }											
				}
				else
					GlobalTools.popMessage(this, "Ketentuan tidak boleh kosong!");
					//GlobalTools.popMessage(this, "Ketentuan must be filled");


			}
			return mStatus;
		}
		#endregion
		#region p_CreateExist return string
		private string p_CreateExist() 
		{
			string szUser = ddl_manual.SelectedValue;

			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			string mStatus = string.Empty;
			object objPaste = null;
			object objCopy = null;
			bool bSukses = true;
			object objValue = null;
			object objType = Type.Missing;		
			int iItem = 0;
			int iItemOther = 0;
			int iItemPosition = 0;
			int m_Row = 0;

			System.Data.DataTable dt_field = null;
			System.Data.DataTable dt_field1 = null;
			System.Data.DataTable dt_field2 = null;

			conn.QueryString = "Select * from NOTA_ANALISA where NOTA_ID = '" + var_idExport1 + "'";
			conn.ExecuteQuery();
				
			if (conn.GetRowCount() > 0) 
			{
				string nota = conn.GetFieldValue("NOTA_ID");
				string sheet = conn.GetFieldValue("NOTA_SHEET");
				string path = conn.GetFieldValue("NOTA_PATH");
				string file_xls = nota + ".XLT";
				string url = conn.GetFieldValue("NOTA_URL");
			
				Excel.Application excelApp = null;
				Excel.Workbook excelWorkBook = null;
				Excel.Sheets excelSheet = null;

				ArrayList orgId = new ArrayList();
				ArrayList newId = new ArrayList();
						
				Process[] oldProcess = Process.GetProcessesByName("EXCEL");
				foreach(Process thisProcess in oldProcess)
					orgId.Add(thisProcess);

				if(var_idExport2!=string.Empty)
				{
					try
					{
						excelApp = new Excel.ApplicationClass();
						excelApp.Visible = false;
						excelApp.DisplayAlerts = false;
							
						Process[] newProcess = Process.GetProcessesByName("EXCEL");
						foreach(Process thisProcess in newProcess)
							newId.Add(thisProcess);

						/// Save process into database
						/// 
						//SupportTools.saveProcessExcel(excelApp, newId, orgId, conn);
	
						fileIn = path + file_xls;

						excelWorkBook = excelApp.Workbooks.Open(fileIn, 0, false, 5, string.Empty, string.Empty, true, Excel.XlPlatform.xlWindows, "\t|",
							false, false, 0, true);

						excelSheet = excelWorkBook.Worksheets;

						Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheet);
						Excel.Worksheet excelWorkSheetWork = (Excel.Worksheet)excelSheet.get_Item("WORK");

						fileNm = Request.QueryString["regno"] + "-" + nota + "-" + var_Name + "-" + prog_code + "-" + var_user + ".XLS";
						fileOut = path + fileNm;
						//fileResult = url + fileNm;

						#region Step Fill Header
						// Step 2.1

						conn.QueryString = "Select NOTA_ID, SEQ, STEP, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL6 where NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
						conn.ExecuteQuery();
											
						dt_field = conn.GetDataTable().Copy();

						conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA7_1 '" + Request.QueryString["regno"] + "', '" + var_idExport2 + "'";
						conn.ExecuteQuery();
								
						for(int j = 0; j < conn.GetRowCount(); j++)
						{
							for(int i = 0; i < dt_field.Rows.Count; i++)
							{
								string Col = dt_field.Rows[i][3].ToString().Trim();
								int Row = Convert.ToInt32(dt_field.Rows[i][4]);
								string Cell = Col + Row.ToString().Trim();
								string Field = dt_field.Rows[i][5].ToString();

								objValue = conn.GetFieldValue(Field);

								Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
								excelCell.Value2 = objValue;
				
								iItem++;
							}
						}
						#endregion
						#region Step Fill Withdrawal
						conn.QueryString = "Select NOTA_ID, SEQ, STEP, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL7 where Step = 0 and NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
						conn.ExecuteQuery();
				
						dt_field = conn.GetDataTable().Copy();

						conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA7_2 '" + Request.QueryString["regno"] + "', '" + var_idExport2 + "'";
						conn.ExecuteQuery();
							
						dt_field1 = conn.GetDataTable().Copy();

						m_Row = 0;

						for(int j = 0; j < dt_field1.Rows.Count; j++)
						{
							if(j > 0) m_Row = m_Row + 26;

							for(int i = 0; i < dt_field.Rows.Count; i++)
							{
								string Col = dt_field.Rows[i][3].ToString().Trim();
								int Row = Convert.ToInt32(dt_field.Rows[i][4])+ m_Row;
								string Cell = Col + Row.ToString().Trim();
								string Field = dt_field.Rows[i][5].ToString();

								objValue = dt_field1.Rows[j][Field];

								Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
								excelCell.Value2 = objValue;

								iItem++;
							}
						}
						#endregion
						#region Step Fill Renewal
						// Step 2.1

						conn.QueryString = "Select NOTA_ID, SEQ, STEP, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL7 where Step = 1 and NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
						conn.ExecuteQuery();
			
						dt_field = conn.GetDataTable().Copy();

						conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA7_3 '" + Request.QueryString["regno"] + "', '" + var_idExport2 + "'";
						conn.ExecuteQuery();

						for(int j = 0; j < conn.GetRowCount(); j++)
						{
							for(int i = 0; i < dt_field.Rows.Count; i++)
							{
								string Col = dt_field.Rows[i][3].ToString().Trim();
								int Row = Convert.ToInt32(dt_field.Rows[i][4]) + m_Row;
								string Cell = Col + Row.ToString().Trim();
								string Field = dt_field.Rows[i][5].ToString();

								objValue = conn.GetFieldValue(Field);

								Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
								excelCell.Value2 = objValue;
				
								iItem++;
							}
						}
						#endregion
						#region Step Fill Limit Changes
						// Step 2.1

						conn.QueryString = "Select NOTA_ID, SEQ, STEP, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL7 where Step = 2 and NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
						conn.ExecuteQuery();
			
						dt_field = conn.GetDataTable().Copy();

						conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA7_4 '" + Request.QueryString["regno"] + "', '" + var_idExport2 + "'";
						conn.ExecuteQuery();

						for(int j = 0; j < conn.GetRowCount(); j++)
						{
							for(int i = 0; i < dt_field.Rows.Count; i++)
							{
								string Col = dt_field.Rows[i][3].ToString().Trim();
								int Row = Convert.ToInt32(dt_field.Rows[i][4]) + m_Row;
								string Cell = Col + Row.ToString().Trim();
								string Field = dt_field.Rows[i][5].ToString();

								objValue = conn.GetFieldValue(Field);

								Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
								excelCell.Value2 = objValue;
				
								iItem++;
							}
						}
						#endregion
						#region Step Fill Change Collateral
								
						#region Include Exiting Agunan
						// Step untuk Exisiting adalah 1 karena belum dapat result query maka step diganti 4
						conn.QueryString = "Select NOTA_ID, SEQ, STEP, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL4 where STEP = 1 and NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
						conn.ExecuteQuery();
					
						dt_field2 = conn.GetDataTable().Copy();

						conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA4_0 '" + Request.QueryString["regno"] + "', '" + var_idExport2 + "','07'";
						conn.ExecuteQuery();

						#region INSERT_OLD_ROWS
						/**** remove by Denny
						if((conn.GetRowCount()>1) && (dt_field2.Rows.Count>1))
						{
							iItemPosition = Convert.ToInt32(dt_field2.Rows[0][4]) + m_Row + 1;

							//Prepare Empty Row with all Formats
							for(int k = 0; k < conn.GetRowCount()-1; k++)
							{
								Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + iItemPosition.ToString().Trim()).EntireRow;
								excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

								Excel.Range excelRangeWork = excelWorkSheetWork.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + iItemPosition.ToString().Trim()).EntireRow;
								excelRangeWork.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
								
								iItemOther = iItemPosition + k;
							}

							Excel.Range exlCopyOld = excelWorkSheet.get_Range("A" + (iItemPosition - 1).ToString().Trim(), "IV" + (iItemPosition - 1).ToString().Trim());
							objCopy = exlCopyOld.Copy(objType);

							Excel.Range exlPasteOld = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemOther.ToString().Trim());
							objPaste = exlPasteOld.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

							Excel.Range exlCopyWork1 = excelWorkSheetWork.get_Range("A" + (iItemPosition - 1).ToString().Trim(), "IV" + (iItemPosition - 1).ToString().Trim());
							objCopy = exlCopyWork1.Copy(objType);

							Excel.Range exlPasteWork1 = excelWorkSheetWork.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemOther.ToString().Trim());
							objPaste = exlPasteWork1.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
						}	
						***/
						#endregion
						//						if((conn.GetRowCount()>1) && (dt_field2.Rows.Count>1))
						//						{
						//							iItemPosition = Convert.ToInt32(dt_field2.Rows[0][4]) + m_Row;
						//
						//							//Prepare Empty Row with all Formats
						//							for(int k = 0; k < conn.GetRowCount()-1; k++)
						//							{
						//								Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + iItemPosition.ToString().Trim()).EntireRow;
						//								excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
						//								iItemOther = iItemPosition + k;
						//							}
						//
						//							Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemOther + 1).ToString().Trim(), "IV" + (iItemOther + 1).ToString().Trim());
						//							objCopy = exlCopy.Copy(objType);
						//
						//							Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemOther.ToString().Trim());
						//							objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
						//						}
						for(int k = 0; k < conn.GetRowCount(); k++)
						{
							if(k > 0) m_Row = m_Row + 1;

							for(int l = 0; l < dt_field2.Rows.Count; l++)
							{
								string Col1 = dt_field2.Rows[l][3].ToString().Trim();
								int Row1 = Convert.ToInt32(dt_field2.Rows[l][4]) + m_Row;
								string Cell1 = Col1 + Row1.ToString().Trim();
								string Field1 = dt_field2.Rows[l][5].ToString();
								if(Field1 == "NUM")
									objValue = k + 1 ;
								else
									objValue = conn.GetFieldValue(k, Field1);

								Excel.Range excelCell1 = (Excel.Range)excelWorkSheet.get_Range(Cell1, Cell1);
								excelCell1.Value2 = objValue;

								iItem++;
							}
						}

						#endregion
						#region Include New Agunan
						// Step 2.1
						conn.QueryString = "Select NOTA_ID, SEQ, STEP, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL4 where STEP = 2 and NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
						conn.ExecuteQuery();
					
						dt_field2 = conn.GetDataTable().Copy();

						conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA4_1 '" + Request.QueryString["regno"] + "', '" + var_idExport2 + "','02'";
						conn.ExecuteQuery();

						// init here because we are no longer adding rows in above ....
						m_Row = 0;

						iItemPosition = Convert.ToInt32(dt_field2.Rows[0][4]) + m_Row + 1;
						iItemOther = iItemPosition;

						//Prepare Empty Row with all Formats
						#region insert_posisi
						/***
						for(int k = 0; k < conn.GetRowCount()-1; k++)
						{
							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + iItemPosition.ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

							Excel.Range excelRangeWork = excelWorkSheetWork.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + iItemPosition.ToString().Trim()).EntireRow;
							excelRangeWork.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
								
							iItemOther = iItemPosition + k;
						}

						Excel.Range exlCopyNew = excelWorkSheet.get_Range("A" + (iItemPosition - 1).ToString().Trim(), "IV" + (iItemPosition - 1).ToString().Trim());
						objCopy = exlCopyNew.Copy(objType);

						Excel.Range exlPasteNew = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemOther.ToString().Trim());
						objPaste = exlPasteNew.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

						Excel.Range exlCopyWork2 = excelWorkSheetWork.get_Range("A" + (iItemPosition - 1).ToString().Trim(), "IV" + (iItemPosition - 1).ToString().Trim());
						objCopy = exlCopyWork2.Copy(objType);

						Excel.Range exlPasteWork2 = excelWorkSheetWork.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemOther.ToString().Trim());
						objPaste = exlPasteWork2.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
						***/
						#endregion
		
						//						if((conn.GetRowCount()>1) && (dt_field2.Rows.Count>1))
						//						{
						//							iItemPosition = Convert.ToInt32(dt_field2.Rows[0][4]) + m_Row;
						//
						//							//Prepare Empty Row with all Formats
						//							for(int k = 0; k < conn.GetRowCount()-1; k++)
						//							{
						//								Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + iItemPosition.ToString().Trim()).EntireRow;
						//								excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
						//								iItemOther = iItemPosition + k;
						//							}
						//
						//							Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemOther + 1).ToString().Trim(), "IV" + (iItemOther + 1).ToString().Trim());
						//							objCopy = exlCopy.Copy(objType);
						//
						//							Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemOther.ToString().Trim());
						//							objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
						//						}
						for(int k = 0; k < conn.GetRowCount(); k++)
						{
							if(k > 0) m_Row = m_Row + 1;

							for(int l = 0; l < dt_field2.Rows.Count; l++)
							{
								string Col1 = dt_field2.Rows[l][3].ToString().Trim();
								int Row1 = Convert.ToInt32(dt_field2.Rows[l][4]) + m_Row;
								string Cell1 = Col1 + Row1.ToString().Trim();
								string Field1 = dt_field2.Rows[l][5].ToString();
								if(Field1 == "NUM")
									objValue = k + 1 ;
								else
									objValue = conn.GetFieldValue(k, Field1);

								Excel.Range excelCell1 = (Excel.Range)excelWorkSheet.get_Range(Cell1, Cell1);
								excelCell1.Value2 = objValue;

								iItem++;
							}
						}
						#endregion
						#region Step Fill Syarat

						// Step 2.1
						conn.QueryString = "Select NOTA_ID, SEQ, STEP, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL7 where Step = 4 and NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
						conn.ExecuteQuery();
					
						dt_field = conn.GetDataTable().Copy();

						conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA7_7 '" + Request.QueryString["regno"] + "', '" + var_idExport2 + "'";
						conn.ExecuteQuery();
								
						for(int j = 0; j < conn.GetRowCount(); j++)
						{
							for(int i = 0; i < dt_field.Rows.Count; i++)
							{
								string Col = dt_field.Rows[i][3].ToString().Trim();
								int Row = Convert.ToInt32(dt_field.Rows[i][4])+ m_Row;
								string Cell = Col + Row.ToString().Trim();
								string Field = dt_field.Rows[i][5].ToString();

								objValue = conn.GetFieldValue(j, Field);

								Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
								excelCell.Value2 = objValue;

								iItem++;
							}
						}
						#endregion

						#endregion
						#region Step Fill Perubahan Syarat

						// Step 2.1
						conn.QueryString = "Select NOTA_ID, SEQ, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL8 where NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
						conn.ExecuteQuery();
			
						dt_field = conn.GetDataTable().Copy();

						conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA7_6 '" + Request.QueryString["regno"] + "', '" + var_idExport2 + "'";
						conn.ExecuteQuery();
						
						for(int j = 0; j < conn.GetRowCount(); j++)
						{
							for(int i = 0; i < dt_field.Rows.Count; i++)
							{
								string Col = dt_field.Rows[i][2].ToString().Trim();
								int Row = Convert.ToInt32(dt_field.Rows[i][3])+ m_Row;
								string Cell = Col + Row.ToString().Trim();
								string Field = dt_field.Rows[i][4].ToString();

								objValue = conn.GetFieldValue(j, Field);

								Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
								excelCell.Value2 = objValue;

								iItem++;
							}
						}
						#endregion

						if(iItem > 0) 
						{
							excelWorkSheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;
							excelWorkBook.SaveAs(fileOut, Excel.XlFileFormat.xlWorkbookNormal, null, null, null, null,
								Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, true);
						
							System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));  																					 
							bSukses = true;
						}
						else
							bSukses = false;

						if(bSukses)	
						{
							// Maintenance Table Nota_Export
							
							if(var_idExport2==string.Empty)
								conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','NOTA','" + fileNm + "','" + Session["UserID"] + "', '1'";
							else
								conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','" + var_idExport2 + "','" + fileNm + "', '" + Session["UserID"] + "', '1'";
							
							conn.ExecuteQuery();
							mStatus = "Export Succesfully";
						}
						else
						{
							mStatus = "No Data to Export";
						}
					}
					catch (Exception e)
					{
						Response.Write("<!-- " + e.Message + "\n" + e.StackTrace + " -->\n" );
					}
					finally
					{
						if(excelWorkBook!=null)
						{
							excelWorkBook.Close(true , fileOut, null);
							excelWorkBook=null;
						}
						if(excelApp!=null)
						{
							excelApp.Workbooks.Close();
							excelApp.Application.Quit();
							excelApp=null;
						}
					}
					try 
					{ 
						for(int x = 0; x < newId.Count; x++)
						{
							Process xnewId = (Process)newId[x];
								
							bool bSameId = false;
							for(int z = 0; z < orgId.Count; z++)
							{
								Process xoldId = (Process)orgId[z];
						
								if(xnewId.Id == xoldId.Id) 
								{
									bSameId = true;
									break;
								}
							}
                            if (!bSameId)
                            {
                                try
                                {
                                    xnewId.Kill();
                                }
                                catch (Exception e)
                                {
                                    continue;
                                }
                            }
						}
					}
					catch { }				
				}
				else
					GlobalTools.popMessage(this, "Ketentuan tidak boleh kosong!");					

			}
			return mStatus;
		}
		#endregion
		#region p_CreateSyarat return string
		private string p_CreateSyarat()
		{
			string szUser = ddl_manual.SelectedValue;

			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			object objPaste = null;
			object objCopy = null;
			bool bSukses = true;
			object objValue = null;
			object objType = Type.Missing;		
			string mStatus = string.Empty;
			int iItem = 0;
			int iItemOther = 0;
			int iItemPosition = 0;
			int m_Row = 0;

			System.Data.DataTable dt_field = null;
			
			conn.QueryString = "Select * from NOTA_ANALISA where NOTA_ID = '" + var_idExport1 + "'";
			conn.ExecuteQuery();
				
			if (conn.GetRowCount() > 0) 
			{
				string nota = conn.GetFieldValue("NOTA_ID");
				string sheet = conn.GetFieldValue("NOTA_SHEET");
				string path = conn.GetFieldValue("NOTA_PATH");
				string file_xls = nota + ".XLT";
				string url = conn.GetFieldValue("NOTA_URL");

				Excel.Application excelApp = null;
				Excel.Workbook excelWorkBook = null;
				Excel.Sheets excelSheet = null;

				ArrayList orgId = new ArrayList();
				ArrayList newId = new ArrayList();
						
				Process[] oldProcess = Process.GetProcessesByName("EXCEL");
				foreach(Process thisProcess in oldProcess)
					orgId.Add(thisProcess);

				try
				{
					excelApp = new Excel.ApplicationClass();
					excelApp.Visible = false;
					excelApp.DisplayAlerts = false;
						
					Process[] newProcess = Process.GetProcessesByName("EXCEL");
					foreach(Process thisProcess in newProcess)
						newId.Add(thisProcess);
						
					/// Save process into database
					/// 
					//SupportTools.saveProcessExcel(excelApp, newId, orgId, conn);

					fileIn = path + file_xls;

					excelWorkBook = excelApp.Workbooks.Open(fileIn, 0, false, 5, string.Empty, string.Empty, true, Excel.XlPlatform.xlWindows, "\t|",
						false, false, 0, true);

					excelSheet = excelWorkBook.Worksheets;

					Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheet);
					
					fileNm = Request.QueryString["regno"] + "-" + nota + "-" +  var_user + ".XLS";
					fileOut = path + fileNm;
					//fileResult = url + fileNm;

					m_Row = 0;

					// Sheet SYARAT
					#region Step Fill Syarat Perjanjian Kredit

					// Step 2.1
					conn.QueryString = "Select NOTA_ID, SEQ, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL8 where SEQ = 1 and NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA8_1 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
					

					if(conn.GetRowCount()>1)
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][3]) +  m_Row;

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + (iItemPosition + 1).ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

							Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemPosition + 2).ToString().Trim(), "IV" + (iItemPosition + 3).ToString().Trim());
							objCopy = exlCopy.Copy(objType);

							Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemPosition.ToString().Trim());
							objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
						}
					}		
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 2;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3])+ m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;

							iItem++;
						}
					}

					#endregion
					#region Step Fill Syarat Penarikan Kredit

					// Step 2.1
					conn.QueryString = "Select NOTA_ID, SEQ, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL8 where SEQ = 2 and NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA8_2 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
					

					if(conn.GetRowCount()>1)
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][3]) +  m_Row;

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							iItemOther = iItemPosition + j;

							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + (iItemPosition + 1).ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

							Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemPosition + 2).ToString().Trim(), "IV" + (iItemPosition + 3).ToString().Trim());
							objCopy = exlCopy.Copy(objType);

							Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemPosition.ToString().Trim());
							objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
						}
					}		
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 2;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3])+ m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;

							iItem++;
						}
					}

					#endregion
					#region Step Fill Syarat Lain

					// Step 2.1
					conn.QueryString = "Select NOTA_ID, SEQ, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL8 where SEQ = 3 and NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA8_3 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
					

					if(conn.GetRowCount()>1)
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][3]) +  m_Row;

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							iItemOther = iItemPosition + j;

							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + (iItemPosition + 1).ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

							Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemPosition + 2).ToString().Trim(), "IV" + (iItemPosition + 3).ToString().Trim());
							objCopy = exlCopy.Copy(objType);

							Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemPosition.ToString().Trim());
							objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
						}
					}		
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 2;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3])+ m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;

							iItem++;
						}
					}

					#endregion

					if(iItem > 0) 
					{
						excelWorkBook.SaveAs(fileOut, Excel.XlFileFormat.xlWorkbookNormal, null, null, null, null,
							Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, true);
					
						System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));  																					 
						bSukses = true;
					}
					else
						bSukses = false;

					if(bSukses)	
					{
						// Maintenance Table Nota_Export
						
						if(var_idExport2==string.Empty)
							conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','NOTA','" + fileNm + "','" + Session["UserID"] + "', '1'";
						else
							conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','" + var_idExport2 + "','" + fileNm + "', '" + Session["UserID"] + "', '1'";
						
						conn.ExecuteQuery();
						mStatus = "Export Succesfully";

					}
					else
					{
						mStatus = "No Data to Export";
					}
				}
				catch (Exception e)
				{
					Response.Write("<!-- " + e.Message + "\n" + e.StackTrace + " -->\n" );
				}
				finally
				{
					if(excelWorkBook!=null)
					{
						excelWorkBook.Close(true , fileOut, null);
						excelWorkBook=null;
					}
					if(excelApp!=null)
					{
						excelApp.Workbooks.Close();
						excelApp.Application.Quit();
						excelApp=null;
					}
				}

				try 
				{ 
					for(int x = 0; x < newId.Count; x++)
					{
						Process xnewId = (Process)newId[x];
							
						bool bSameId = false;
						for(int z = 0; z < orgId.Count; z++)
						{
							Process xoldId = (Process)orgId[z];
					
							if(xnewId.Id == xoldId.Id) 
							{
								bSameId = true;
								break;
							}
						}
                        if (!bSameId)
                        {
                            try
                            {
                                xnewId.Kill();
                            }
                            catch (Exception e)
                            {
                                continue;
                            }
                        }
					}
				}
				catch { }
			}
			return mStatus;
		}
		#endregion
		#region p_CreateSyarat2 return string
		private string p_CreateSyarat2()
		{
			string szUser = ddl_manual.SelectedValue;

			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			object objPaste = null;
			object objCopy = null;
			bool bSukses = true;
			object objValue = null;
			object objType = Type.Missing;		
			string mStatus = string.Empty;
			int iItem = 0;
			int iItemOther = 0;
			int iItemPosition = 0;
			int m_Row = 0;

			System.Data.DataTable dt_field = null;
			
			conn.QueryString = "Select * from NOTA_ANALISA where NOTA_ID = '" + var_idExport1 + "'";
			conn.ExecuteQuery();
				
			if (conn.GetRowCount() > 0) 
			{
				string nota = conn.GetFieldValue("NOTA_ID");
				string sheet = conn.GetFieldValue("NOTA_SHEET");
				string path = conn.GetFieldValue("NOTA_PATH");
				string file_xls = nota + ".XLT";
				string url = conn.GetFieldValue("NOTA_URL");

				Excel.Application excelApp = null;
				Excel.Workbook excelWorkBook = null;
				Excel.Sheets excelSheet = null;

				ArrayList orgId = new ArrayList();
				ArrayList newId = new ArrayList();
						
				Process[] oldProcess = Process.GetProcessesByName("EXCEL");
				foreach(Process thisProcess in oldProcess)
					orgId.Add(thisProcess);

				try
				{
					excelApp = new Excel.ApplicationClass();
					excelApp.Visible = false;
					excelApp.DisplayAlerts = false;
						
					Process[] newProcess = Process.GetProcessesByName("EXCEL");
					foreach(Process thisProcess in newProcess)
						newId.Add(thisProcess);
						
					/// Save process into database
					/// 
					//SupportTools.saveProcessExcel(excelApp, newId, orgId, conn);

					fileIn = path + file_xls;

					excelWorkBook = excelApp.Workbooks.Open(fileIn, 0, false, 5, string.Empty, string.Empty, true, Excel.XlPlatform.xlWindows, "\t|",
						false, false, 0, true);

					excelSheet = excelWorkBook.Worksheets;

					Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheet);
					
					fileNm = Request.QueryString["regno"] + "-" + nota + "-" +  var_user + ".XLS";
					fileOut = path + fileNm;
					//fileResult = url + fileNm;

					m_Row = 0;

					// Sheet SYARAT
					#region Step Fill Syarat Perjanjian Kredit

					// Step 2.1
					conn.QueryString = "Select NOTA_ID, SEQ, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL8 where SEQ = 1 and NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA8_1 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
					

					if(conn.GetRowCount()>1)
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][3]) +  m_Row;

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + (iItemPosition + 1).ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

							Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemPosition + 2).ToString().Trim(), "IV" + (iItemPosition + 3).ToString().Trim());
							objCopy = exlCopy.Copy(objType);

							Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemPosition.ToString().Trim());
							objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
						}
					}		
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 2;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3])+ m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;

							iItem++;
						}
					}

					#endregion
					#region Step Fill Syarat Penarikan Kredit
					#region Step Fill Syarat CL

					// Step 2.1
					conn.QueryString = "Select NOTA_ID, SEQ, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL8 where SEQ = 2 and NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA8_2A '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
					

					if(conn.GetRowCount()>1)
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][3]) +  m_Row;

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							iItemOther = iItemPosition + j;

							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + (iItemPosition + 1).ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

							Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemPosition + 2).ToString().Trim(), "IV" + (iItemPosition + 3).ToString().Trim());
							objCopy = exlCopy.Copy(objType);

							Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemPosition.ToString().Trim());
							objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
						}
					}		
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 2;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3])+ m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;

							iItem++;
						}
					}

					#endregion
					#region Step Fill Syarat NCL

					// Step 2.1
					conn.QueryString = "Select NOTA_ID, SEQ, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL8 where SEQ = 3 and NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA8_2B '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
					

					if(conn.GetRowCount()>1)
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][3]) +  m_Row;

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							iItemOther = iItemPosition + j;

							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + (iItemPosition + 1).ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

							Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemPosition + 2).ToString().Trim(), "IV" + (iItemPosition + 3).ToString().Trim());
							objCopy = exlCopy.Copy(objType);

							Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemPosition.ToString().Trim());
							objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
						}
					}		
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 2;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3])+ m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;

							iItem++;
						}
					}

					#endregion

					#endregion
					#region Step Fill Syarat Lain

					// Step 2.1
					conn.QueryString = "Select NOTA_ID, SEQ, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL8 where SEQ = 4 and NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA8_3 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
					

					if(conn.GetRowCount()>1)
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][3]) +  m_Row;

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							iItemOther = iItemPosition + j;

							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + (iItemPosition + 1).ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

							Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemPosition + 2).ToString().Trim(), "IV" + (iItemPosition + 3).ToString().Trim());
							objCopy = exlCopy.Copy(objType);

							Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemPosition.ToString().Trim());
							objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
						}
					}		
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 2;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3])+ m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;

							iItem++;
						}
					}

					#endregion

					if(iItem > 0) 
					{
						excelWorkBook.SaveAs(fileOut, Excel.XlFileFormat.xlWorkbookNormal, null, null, null, null,
							Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, true);
					
						System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));  																					 
						bSukses = true;
					}
					else
						bSukses = false;

					if(bSukses)	
					{
						// Maintenance Table Nota_Export
						
						if(var_idExport2==string.Empty)
							conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','NOTA','" + fileNm + "','" + Session["UserID"] + "', '1'";
						else
							conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','" + var_idExport2 + "','" + fileNm + "', '" + Session["UserID"] + "', '1'";
						
						conn.ExecuteQuery();
						mStatus = "Export Succesfully";

					}
					else
					{
						mStatus = "No Data to Export";
					}
				}
				catch (Exception e)
				{
					Response.Write("<!-- " + e.Message + "\n" + e.StackTrace + " -->\n" );
				}
				finally
				{
					if(excelWorkBook!=null)
					{
						excelWorkBook.Close(true , fileOut, null);
						excelWorkBook=null;
					}
					if(excelApp!=null)
					{
						excelApp.Workbooks.Close();
						excelApp.Application.Quit();
						excelApp=null;
					}
				}

				try 
				{ 
					for(int x = 0; x < newId.Count; x++)
					{
						Process xnewId = (Process)newId[x];
							
						bool bSameId = false;
						for(int z = 0; z < orgId.Count; z++)
						{
							Process xoldId = (Process)orgId[z];
					
							if(xnewId.Id == xoldId.Id) 
							{
								bSameId = true;
								break;
							}
						}
                        if (!bSameId)
                        {
                            try
                            {
                                xnewId.Kill();
                            }
                            catch (Exception e)
                            {
                                continue;
                            }
                        }
					}
				}
				catch { }					
				}
			return mStatus;
		}
		#endregion
		#region p_CreateRata return string
		private string p_CreateRata()
		{
			string szUser = ddl_manual.SelectedValue;

			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			bool bSukses = true;
			object objValue = null;					
			string mStatus = string.Empty;

			conn.QueryString = "Select * from NOTA_ANALISA where NOTA_ID = '" + var_idExport1 + "'";
			conn.ExecuteQuery();
				
			if (conn.GetRowCount() > 0) 
			{
				string nota = conn.GetFieldValue("NOTA_ID");
				string sheet = conn.GetFieldValue("NOTA_SHEET");
				string path = conn.GetFieldValue("NOTA_PATH");
				string file_xls = nota + ".XLT";
				string url = conn.GetFieldValue("NOTA_URL");
			
				fileNm = Request.QueryString["regno"] + "-" + nota + "-" +  var_user + ".XLS";
				fileOut = path + fileNm;

				System.Data.DataTable dt_field = null;

				Excel.Application excelApp = null;
				Excel.Workbook excelWorkBook = null;
				Excel.Sheets excelSheet = null;

				ArrayList orgId = new ArrayList();
				ArrayList newId = new ArrayList();
						
				Process[] oldProcess = Process.GetProcessesByName("EXCEL");
				foreach(Process thisProcess in oldProcess)
					orgId.Add(thisProcess);

				try
				{
					excelApp = new Excel.ApplicationClass();
					excelApp.Visible = false;
					excelApp.DisplayAlerts = false;
						
					Process[] newProcess = Process.GetProcessesByName("EXCEL");
					foreach(Process thisProcess in newProcess)
						newId.Add(thisProcess);
			
					/// Save process into database
					/// 
					//SupportTools.saveProcessExcel(excelApp, newId, orgId, conn);
					
					fileIn = path + file_xls;

					excelWorkBook = excelApp.Workbooks.Open(fileIn, 0, false, 5, string.Empty, string.Empty, true, Excel.XlPlatform.xlWindows, "\t|",
						false, false, 0, true);

					excelSheet = excelWorkBook.Worksheets;
					Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheet);
							
					#region Step Fill Rata-Rata 

					int iItem = 0;
					// Step 1
					conn.QueryString = "Select NOTA_ID, SEQ, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL9 where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_BANK '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3]);
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;
			
							iItem++;
						}
					}

					#endregion 
					if(iItem > 0)
					{
						excelWorkBook.SaveAs(fileOut, Excel.XlFileFormat.xlWorkbookNormal, null, null, null, null,
							Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, true);
					
						System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));  																					 
						bSukses = true;
					}
					else
						bSukses = false;

					if(bSukses)	
					{
		
						// Maintenance Table Nota_Export

						if(var_idExport2==string.Empty)
							conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','NOTA','" + fileNm + "','" + Session["UserID"] + "', '1'";
						else
							conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','" + var_idExport2 + "','" + fileNm + "', '" + Session["UserID"] + "', '1'";

						conn.ExecuteQuery();
						mStatus = "Export Succesfully";

					}
					else
					{
						mStatus = "No Data to Export";
					}

				}
				catch (Exception e)
				{
					Response.Write("<!-- " + e.Message + "\n" + e.StackTrace + " -->\n" );
				}
				finally
				{
					if(excelWorkBook!=null)
					{
						excelWorkBook.Close(true , fileOut, null);
						excelWorkBook=null;
					}
					if(excelApp!=null)
					{
						excelApp.Workbooks.Close();
						excelApp.Application.Quit();
						excelApp=null;
					}
				}

				try 
				{
					for(int x = 0; x < newId.Count; x++)
					{
						Process xnewId = (Process)newId[x];
							
						bool bSameId = false;
						for(int z = 0; z < orgId.Count; z++)
						{
							Process xoldId = (Process)orgId[z];
					
							if(xnewId.Id == xoldId.Id) 
							{
								bSameId = true;
								break;
							}
						}
                        if (!bSameId)
                        {
                            try
                            {
                                xnewId.Kill();
                            }
                            catch (Exception e)
                            {
                                continue;
                            }
                        }
					}

				}
				catch { }								
			}
			return mStatus;
		}
		#endregion
		#region p_CreateBank return string 
		private string p_CreateBank()
		{
			string szUser = ddl_manual.SelectedValue;

			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			int m_Row = 0;
			object objPaste = null;
			object objCopy = null;
			object objType = Type.Missing;		
			bool bSukses = true;
			object objValue = null;					
			string mStatus = string.Empty;

			conn.QueryString = "Select * from NOTA_ANALISA where NOTA_ID = '" + var_idExport1 + "'";
			conn.ExecuteQuery();
				
			if (conn.GetRowCount() > 0) 
			{
				string nota = conn.GetFieldValue("NOTA_ID");
				string sheet = conn.GetFieldValue("NOTA_SHEET");
				string path = conn.GetFieldValue("NOTA_PATH");
				string file_xls = nota + ".XLT";
				string url = conn.GetFieldValue("NOTA_URL");
			
				fileNm = Request.QueryString["regno"] + "-" + nota + "-" + var_user + ".XLS";
				fileOut = path + fileNm;

				System.Data.DataTable dt_field = null;

				int iItem = 0;
				int iItemOther = 0;
				int iItemPosition = 0;

				Excel.Application excelApp = null;
				Excel.Workbook excelWorkBook = null;
				Excel.Sheets excelSheet = null;

				ArrayList orgId = new ArrayList();
				ArrayList newId = new ArrayList();
						
				Process[] oldProcess = Process.GetProcessesByName("EXCEL");
				foreach(Process thisProcess in oldProcess)
					orgId.Add(thisProcess);

				try
				{
					excelApp = new Excel.ApplicationClass();
					excelApp.Visible = false;
					excelApp.DisplayAlerts = false;
						
					Process[] newProcess = Process.GetProcessesByName("EXCEL");
					foreach(Process thisProcess in newProcess)
						newId.Add(thisProcess);

					/// Save process into database
					/// 
					//SupportTools.saveProcessExcel(excelApp, newId, orgId, conn);

					fileIn = path + file_xls;

					excelWorkBook = excelApp.Workbooks.Open(fileIn, 0, false, 5, string.Empty, string.Empty, true, Excel.XlPlatform.xlWindows, "\t|",
						false, false, 0, true);

					excelSheet = excelWorkBook.Worksheets;
					Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheet);

				
					#region Step Fill General Info
					// Step 1
					conn.QueryString = "Select NOTA_ID, SEQ, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA '" + Session["BranchName"] + "', '" + Session["FullName"] + "', '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3]);
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;
			
							iItem++;
						}
					}
					#endregion 
					#region Step Fill Hubungan dengan Bank Mandiri 1
					// Step 2.1
					conn.QueryString = "Select NOTA_ID, SEQ, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL1_1 where NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA1_1 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
					
					if((conn.GetRowCount()>1) && (dt_field.Rows.Count>1))
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][3]) + m_Row;

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + iItemPosition.ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
							iItemOther = iItemPosition + j;
						}

						Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemOther + 1).ToString().Trim(), "IV" + (iItemOther + 1).ToString().Trim());
						objCopy = exlCopy.Copy(objType);

						Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemOther.ToString().Trim());
						objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
					}
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 1;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3]) + m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();
							if(Field == "NUM")
								objValue = j + 1 ;
							else
								objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;

							iItem++;
						}
					}
					#endregion
					#region Step Fill Hubungan dengan Bank Mandiri 2
					// Step 2.2
					conn.QueryString = "Select NOTA_ID, SEQ, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL1_2 where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA1_2 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();

					if((conn.GetRowCount()>1) && (dt_field.Rows.Count>1))
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][3]) +  m_Row;

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + iItemPosition.ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
							iItemOther = iItemPosition + j;
						}

						Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemOther + 1).ToString().Trim(), "IV" + (iItemOther + 1).ToString().Trim());
						objCopy = exlCopy.Copy(objType);

						Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemOther.ToString().Trim());
						objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
					}		
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 1;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3]) + m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();
							if(Field == "NUM")
								objValue = j + 1 ;
							else
								objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;
						}
					}
					#endregion		
					#region Step Fill Hubungan dengan Bank Lain
					// Step 2.3
					conn.QueryString = "Select NOTA_ID, SEQ, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL1_3 where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA1_3 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();

					if((conn.GetRowCount()>1) && (dt_field.Rows.Count>1))
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][3]) +  m_Row;

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + iItemPosition.ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
							iItemOther = iItemPosition + j;
						}

						Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemOther + 1).ToString().Trim(), "IV" + (iItemOther + 1).ToString().Trim());
						objCopy = exlCopy.Copy(objType);

						Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemOther.ToString().Trim());
						objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
					}		
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 1;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3]) + m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;
						}
					}
					#endregion

					if(iItem > 0)
					{
						excelWorkBook.SaveAs(fileOut, Excel.XlFileFormat.xlWorkbookNormal, null, null, null, null,
							Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, true);
					
						System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));  																					 
						bSukses = true;
					}
					else
						bSukses = false;

					if(bSukses)	
					{
		
						// Maintenance Table Nota_Export

						if(var_idExport2==string.Empty)
							conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','NOTA','" + fileNm + "','" + Session["UserID"] + "', '1'";
						else
							conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','" + var_idExport2 + "','" + fileNm + "', '" + Session["UserID"] + "', '1'";

						conn.ExecuteQuery();
						mStatus = "Export Succesfully";

					}
					else
					{
						mStatus = "No Data to Export";
					}
				}
				catch (Exception e)
				{
					Response.Write("<!-- " + e.Message + "\n" + e.StackTrace + " -->\n" );
				}
				finally
				{
					if(excelWorkBook!=null)
					{
						excelWorkBook.Close(true , fileOut, null);
						excelWorkBook=null;
					}
					if(excelApp!=null)
					{
						excelApp.Workbooks.Close();
						excelApp.Application.Quit();
						excelApp=null;
					}
				}
				try 
				{ 
					for(int x = 0; x < newId.Count; x++)
					{
						Process xnewId = (Process)newId[x];
							
						bool bSameId = false;
						for(int z = 0; z < orgId.Count; z++)
						{
							Process xoldId = (Process)orgId[z];
					
							if(xnewId.Id == xoldId.Id) 
							{
								bSameId = true;
								break;
							}
						}
                        if (!bSameId)
                        {
                            try
                            {
                                xnewId.Kill();
                            }
                            catch (Exception e)
                            {
                                continue;
                            }
                        }
					}
				}
				catch { }					
			}
			return mStatus;
		}

		#endregion
		#region p_CreateUrus return string
		private string p_CreateUrus()
		{
			string szUser = ddl_manual.SelectedValue;

			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			object objPaste = null;
			object objCopy = null;
			bool bSukses = true;
			object objValue = null;
			object objType = Type.Missing;		
			string mStatus = string.Empty;
			int iItem = 0;
			int iItemOther = 0;
			int iItemPosition = 0;
			int m_Row = 0;


			System.Data.DataTable dt_field = null;

			conn.QueryString = "Select * from NOTA_ANALISA where NOTA_ID = '" + var_idExport1 + "'";
			conn.ExecuteQuery();
				
			if (conn.GetRowCount() > 0) 
			{
				string nota = conn.GetFieldValue("NOTA_ID");
				string sheet = conn.GetFieldValue("NOTA_SHEET");
				string path = conn.GetFieldValue("NOTA_PATH");
				string file_xls = nota + ".XLT";
				string url = conn.GetFieldValue("NOTA_URL");

				Excel.Application excelApp = null;
				Excel.Workbook excelWorkBook = null;
				Excel.Sheets excelSheet = null;

				ArrayList orgId = new ArrayList();
				ArrayList newId = new ArrayList();
						
				Process[] oldProcess = Process.GetProcessesByName("EXCEL");
				foreach(Process thisProcess in oldProcess)
					orgId.Add(thisProcess);

				try
				{
					excelApp = new Excel.ApplicationClass();
					excelApp.Visible = false;
					excelApp.DisplayAlerts = false;
							
					Process[] newProcess = Process.GetProcessesByName("EXCEL");
					foreach(Process thisProcess in newProcess)
						newId.Add(thisProcess);
							
					/// Save process into database
					/// 
					//SupportTools.saveProcessExcel(excelApp, newId, orgId, conn);

					fileIn = path + file_xls;

					excelWorkBook = excelApp.Workbooks.Open(fileIn, 0, false, 5, string.Empty, string.Empty, true, Excel.XlPlatform.xlWindows, "\t|",
						false, false, 0, true);

					excelSheet = excelWorkBook.Worksheets;

					Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheet);
						
					fileNm = Request.QueryString["regno"] + "-" + nota + "-" + var_user + ".XLS";
					fileOut = path + fileNm;
					//fileResult = url + fileNm;

					#region Step Fill Multi Ketentuan Kredit
					// Step 2.1

					conn.QueryString = "Select NOTA_ID, SEQ, STEP, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL1_0 where STEP = 1 AND NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();
	
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_WORD6 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
				
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][3].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][4]);
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][5].ToString();

							objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;

							iItem++;
						}
					}

						
					// sTE 2.2
					conn.QueryString = "Select NOTA_ID, SEQ, STEP, NOTA_COL, NOTA_ROW, NOTA_FIELD, [DESCRIPTION] from NOTA_ANALISA_DETAIL1_0 where STEP = 0 AND NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();
	
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_WORD6 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
				
					if((conn.GetRowCount()>1) && (dt_field.Rows.Count>1))
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][4]);

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + iItemPosition.ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
							iItemOther = iItemPosition + j;
						}

						Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemOther + 1).ToString().Trim(), "IV" + (iItemOther + 1).ToString().Trim());
						objCopy = exlCopy.Copy(objType);

						Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemOther.ToString().Trim());
						objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
					}

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 1;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][3].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][4])+ m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][5].ToString();

							if(Field == "NUM")
								objValue = j + 1 ;
							else
								objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;

							iItem++;
						}
					}
					#endregion


					if(iItem > 0) 
					{
						excelWorkBook.SaveAs(fileOut, Excel.XlFileFormat.xlWorkbookNormal, null, null, null, null,
							Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, true);
						
						System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));  																					 
						bSukses = true;
					}
					else
						bSukses = false;

					if(bSukses)	
					{
						// Maintenance Table Nota_Export
							
						if(var_idExport2==string.Empty)
							conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','NOTA','" + fileNm + "','" + Session["UserID"] + "', '1'";
						else
							conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','" + var_idExport2 + "','" + fileNm + "', '" + Session["UserID"] + "', '1'";
							
						conn.ExecuteQuery();

						mStatus = "Export Succesfully";

					}
					else
					{
						mStatus = "No Data to Export";
					}
				}
				catch (Exception e)
				{
					Response.Write("<!-- " + e.Message + "\n" + e.StackTrace + " -->\n" );
				}
				finally
				{
					if(excelWorkBook!=null)
					{
						excelWorkBook.Close(true , fileOut, null);
						excelWorkBook=null;
					}
					if(excelApp!=null)
					{
						excelApp.Workbooks.Close();
						excelApp.Application.Quit();
						excelApp=null;
					}
				}
				try 
				{ 
					for(int x = 0; x < newId.Count; x++)
					{
						Process xnewId = (Process)newId[x];
								
						bool bSameId = false;
						for(int z = 0; z < orgId.Count; z++)
						{
							Process xoldId = (Process)orgId[z];
						
							if(xnewId.Id == xoldId.Id) 
							{
								bSameId = true;
								break;
							}
						}
                        if (!bSameId)
                        {
                            try
                            {
                                xnewId.Kill();
                            }
                            catch (Exception e)
                            {
                                continue;
                            }
                        }
					}

				}
				catch { }
			}
			return mStatus;
		}
		#endregion



		private string Export_Word()
		{
			
			System.Data.DataTable dt_field = null;

			/*
			string areaid=null;
			string branchid=null;
			*/

			string data_id=null;
			string prgid=null;
			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			object objPaste = null;
			object objCopy = null;
			bool bSukses = true;
			object objValue = null;
			object objType = Type.Missing;		
			string mStatus = string.Empty;
			int iItem = 0;
			int iItemOther = 0;
			int iItemPosition = 0;
			int m_Row = 0;
			
			ArrayList orgId = new ArrayList();
			ArrayList newId = new ArrayList();
			
			

			/// Mengambil application root
			/// 
			conn.QueryString = "select APP_ROOT from APP_PARAMETER";
			conn.ExecuteQuery();
			string vAPP_ROOT = conn.GetFieldValue("APP_ROOT");	

			 //--- INIT DATA_ID => 
			conn.QueryString = "Select nota_id,programid from NOTA_ANALISA where NOTA_ID = '" + var_idExport1 + "'";
			conn.ExecuteQuery();
			data_id = conn.GetFieldValue("nota_id").ToString();
			prgid = conn.GetFieldValue("programid").ToString();

			/// Mengambil nilai parameter
			/// 
			conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_WORDPROC '" + data_id + "', '" + prgid + "'";
			conn.ExecuteQuery(); 
			System.Data.DataTable dtProc = new System.Data.DataTable();
			dtProc = conn.GetDataTable().Copy();

			if (conn.GetRowCount() == 0)  
			{
				GlobalTools.popMessage(this, "Data Referensi nota analisa word kosong!");
				//return ;
			}

			string nota = data_id;											// nama file hasil export
			string sheet = conn.GetFieldValue("nota_id");			
			//string path = vAPP_ROOT + conn.GetFieldValue("nota_PATH");	// directory WORD hasil export			
			string path = conn.GetFieldValue("nota_PATH");
			string file_xls = nota + ".dot";								// nama file WORD template
			string template = conn.GetFieldValue("nota_id");				// directory WORD template
			string template_path = conn.GetFieldValue("TEMPLATE_PATH");				// directory WORD template
			
			string url = conn.GetFieldValue("nota_URL");					// url (link) untuk download

			string[] procedure_name = new string[100];
			
			/*
			for(int den=0; den < dtProc.Rows.Count; den++) 
			{
				procedure_name[den] = conn.GetFieldValue(den, "STOREDPROCEDURE");
			}
			*/


			fileNm = Request.QueryString["regno"] + "-" + nota + "-" + Session["userid"] + ".DOC";

			object objFileIn = template_path + file_xls;
			object objFileOut = path + fileNm;
		
			//fileResult = url + fileNm;



			/// Cek apakah file templatenya (input) ada atau tidak
			/// 
			//if (!File.Exists(template + file_xls)) 
			if (!File.Exists(template_path+file_xls)) 
			{
				GlobalTools.popMessage(this, "File Template tidak ada!");
				//return ;
			}

			/// Cek direktori untuk menyimpan file hasil export (output)
			/// 
			if (!Directory.Exists(path)) 
			{
				// create directory if does not exist
				Directory.CreateDirectory(path);
			}


			/// dapatkan semua fields to populate
			/// 			
										

			object oMissingObject = System.Reflection.Missing.Value;
		
			Word.Application wordApp = null;
			Word.Document wordDoc = null;

			
			Process[] oldProcess = Process.GetProcessesByName("WINWORD");				
			foreach(Process thisProcess in oldProcess)
				orgId.Add(thisProcess);

	
			// Always already when using Export Excel file format					
			System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
			System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");


			wordApp = new Word.ApplicationClass();
			wordApp.Visible = false;

			//Collecting Existing Winword in Taskbar 

			Process[] newProcess = Process.GetProcessesByName("WINWORD");
			foreach(Process thisProcess in newProcess)
				newId.Add(thisProcess);

			/// Save process into database
			/// 					
			//SupportTools.saveProcessWord(wordApp, newId, orgId, conn);	
					
			
			wordDoc = wordApp.Documents.Open(ref objFileIn, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, 
				ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject);
			wordDoc.Activate();
			Word.Bookmarks wordBookMark = (Word.Bookmarks)wordDoc.Bookmarks;

							
			int counter  = 0;
			string Col ;
			int Row = 3  ;
			string Cell ;
			string Field ;


			int procedure_cnt = 0;  // for the moment, we handle 9 store procedures			
			string exe_procedure;

			object oCell ;
			string tempField ;
			object sField ;
			string strObject;
							

			/*
            conn.QueryString = " exec CP_EXPORT_NOTA_ANALISA_WORDPROC '" + data_id + "','" + prgid + "'"; 
			conn.ExecuteQuery();
			
			
			
			for(int den=0; den < conn.GetRowCount(); den++) 
			{
				procedure_name[den] = conn.GetFieldValue(den, "STOREDPROCEDURE");
			}
			*/
			

			for ( procedure_cnt = 0; procedure_cnt < dtProc.Rows.Count; procedure_cnt++ ) 
			{
		
				exe_procedure = dtProc.Rows[procedure_cnt]["STOREDPROCEDURE"].ToString();
				if (  Strings.Len(exe_procedure.Trim()) == 0 ) continue;	
							
				/*
				conn.QueryString = "Select SEQ, nota_COL, nota_ROW, nota_FIELD, [group] from nota_analisa_detail " + 
					" where nota_ID = '" + nota + 
					"' and category = " + procedure_cnt.ToString() +
					" order by SEQ";
				conn.ExecuteQuery();
				*/
				/*
				conn.QueryString = "select d.NOTA_ID,d.SEQ,d.NOTA_COL,d.NOTA_ROW," +
								"d.NOTA_FIELD,d.[DESCRIPTION],d.[Group],d.category," +
								"p.STOREDPROCEDURE " +
								" from  nota_analisa_detail d left join rfnotaanalisaproc p on " +
								"d.nota_id = p.nota_id and " +
								"d.category = p.seq " +
								"where d.nota_id = '" + nota + "' and category = " + 
					             procedure_cnt.ToString()        
					             + " order by d.SEQ ";
								 */
				conn.QueryString = "select d.NOTA_ID,d.SEQ,d.NOTA_COL,d.NOTA_ROW," +
					"d.NOTA_FIELD,d.[DESCRIPTION],d.[Group],d.category," +
					"p.STOREDPROCEDURE " +
					" from  nota_analisa_detail d left join rfnotaanalisaproc p on " +
					"d.nota_id = p.nota_id and " +
					"d.category = p.seq " +
					"where d.nota_id = '" + nota + "' and p.STOREDPROCEDURE = '" + 
					exe_procedure.ToString() + "' order by d.SEQ ";					
				conn.ExecuteQuery();
				dt_field = conn.GetDataTable().Copy();			


				conn.QueryString = " exec " + exe_procedure + " '" + Request.QueryString["regno"] + "'" ; 					 
				conn.ExecuteQuery();
				
				for(int j = 0; j < conn.GetRowCount(); j++)
				{							          
                       
					for(int i = 0; i < dt_field.Rows.Count; i++)
					{		
												
						try 
						{
							oCell = dt_field.Rows[i]["nota_col"];
							tempField = dt_field.Rows[i]["nota_field"].ToString();
							sField = dt_field.Rows[i]["nota_field"].ToString();
							

							objValue = conn.GetFieldValue(j,tempField);		
							
							//if(wordBookMark.Exists(oCell.ToString())) 
							if(wordBookMark.Exists(sField.ToString())) 
							{
								
								if (dt_field.Rows[i]["Group"].ToString() != "0") strObject = objValue.ToString();
								else strObject = objValue.ToString() + "\n";
									
								//Word.Bookmark oBook = wordBookMark.Item(ref oCell);
								Word.Bookmark oBook = wordBookMark.Item(ref sField);
								oBook.Select();
								oBook.Range.Text = strObject;								
								
							
							}	
						}
						catch { }								
												
					}  // end of for i loop				

				}  // end of j 
				// close the objects					
			}  // end of procedure_cnt


			try 
			{
				/// Save file fisik hasil export
				/// 
				//excelWorkSheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;
				
				wordDoc.SaveAs(ref objFileOut, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, 
					ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject);

				System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));  	
				
				conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','" + var_idExport2 + "','" + fileNm + "', '" + Session["UserID"] + "', '1'";

				conn.ExecuteQuery();
				mStatus = "Export Succesfully";												 				
				
			/*  mungkin return value didalam calling fucntion ....
				/// Save data file hasil export ke database
				/// 
				Conn.QueryString = "exec RPT_EXPORT_DATAANALYSIS '" + 
					data_id + "', '" + 
					fileNm + "', '" + 
					var_userid + " ', '1', 'R-C'";
				Conn.ExecuteNonQuery();					
				*/
									
				
			}
			catch  // (Exception exp2)
			{ 
				// LBL_STATUS_EXPORT.Text = "Export File gagal!";
				//LBL_STATUSEXPORT.Text = exp2.ToString();
				//return;
			}

			// try to close word dulu ...
			try 
			{ 
				if(wordDoc!=null)
				{
					wordDoc.Close(ref oMissingObject, ref oMissingObject, ref oMissingObject);
					wordDoc=null;
				}
				if(wordApp!=null)
				{
					wordApp.Application.Quit(ref oMissingObject, ref oMissingObject, ref oMissingObject);
					wordApp=null;
				}
			}
			catch { }


			/// Kill process
			/// 
			try 
			{
						
					// Killing Proses after Export
					for(int x = 0; x < newId.Count; x++)
					{
						Process xnewId = (Process)newId[x];
				
						bool bSameId = false;
						for(int z = 0; z < orgId.Count; z++)
						{
							Process xoldId = (Process)orgId[z];
		
							if(xnewId.Id == xoldId.Id) 
							{
								bSameId = true;
								break;
							}
						}
                        if (!bSameId)
                        {
                            try
                            {
                                xnewId.Kill();
                            }
                            catch (Exception e)
                            {
                                continue;
                            }
                        }
				
					} // end x		
			}
			catch   { 	}	

			return mStatus;
		}

		protected void btn_PrintScoringResult_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../Scoring/ScoringPrint.aspx?regno="+ Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&mc=" + Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"]);
		}

		protected void BTN_PORTFOLIO_Click(object sender, System.EventArgs e)
		{
			CekPortfolio();
		}

        protected void btn_acquireInfo_Click(object sender, EventArgs e)
        {
            conn.QueryString = "UPDATE APPTRACK SET AP_CURRTRACK = 'BP5.0' WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
            conn.ExecuteQuery();

            Response.Redirect("ListCreditProposal.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + Request.QueryString["regno"] + " telah dikembalikan ke Verification Assignment !");
        }
	}
}
