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

namespace SME.InitialDataEntry
{
	/// <summary>
	/// Summary description for Withdrawal
	/// </summary>
	public partial class Withdrawal : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			LBL_MAINREGNO.Text = Request.QueryString["mainregno"];
			LBL_MAINPROD_SEQ.Text = Request.QueryString["mainprod_seq"];
			LBL_MAINPRODUCTID.Text = Request.QueryString["mainproductid"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				LBL_USERID.Text = Session["UserID"].ToString();

				initializeDropDowns();
				viewData();

//				//Populate Initialization
//				fillAppType();
//				fillAppNo(); 
//				viewCIF();


				ViewApplications();

//
//				//---------------------------- KETENTUAN KREDIT -----------------------------------------//
//				//Untuk kebutuhan KETENTUAN KREDIT, kalau permohonan baru dalam satu ketentuan kredit
//				//tidak bisa bergabung dengan jenis pengajuan lain.				
//				DDL_APPTYPE.Items.Remove(DDL_APPTYPE.Items.FindByValue("01"));
//
//				conn.QueryString = "select * from KETENTUAN_KREDIT where KET_CODE ='" + Request.QueryString["ket_code"] + "'";
//				conn.ExecuteQuery();
//
//				try {DDL_AA_NO.SelectedValue = conn.GetFieldValue("AA_NO");}
//				catch {DDL_AA_NO.SelectedValue = "";}
//				DDL_PRODUCTID.Items.Add(new ListItem(conn.GetFieldValue("PRODUCTID"), conn.GetFieldValue("PRODUCTID")));
//				DDL_PRODUCTID.SelectedValue = conn.GetFieldValue("PRODUCTID");
//				LBL_PRODUCTID.Text = conn.GetFieldValue("PRODUCTID");
//				DDL_FACILITYNO.Items.Add(new ListItem(conn.GetFieldValue("ACC_SEQ"), conn.GetFieldValue("ACC_SEQ")));
//				DDL_FACILITYNO.SelectedValue = conn.GetFieldValue("ACC_SEQ");
//				DDL_AA_NO.Enabled = false;
//				DDL_PRODUCTID.Enabled = false;
//				DDL_FACILITYNO.Enabled = false;
//				//---------------------------------------------------------------------------------------------//
//
//				//Get product description (Yudi)
//				conn.QueryString = "select PRODUCTDESC from RFPRODUCT where PRODUCTID='" + DDL_PRODUCTID.SelectedValue + "'";
//				conn.ExecuteQuery();
//				TXT_PRODUCTDESC.Text = conn.GetFieldValue("PRODUCTDESC");

			}

			viewExchangeRate();
			ViewMenu();	
			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			Button1.Attributes.Add("onclick","if(!update()){return false;};");

            //PUNDI
            setDefault();
		}

        private void setDefault()
        {
            TXT_CP_EXRPLIMITCHGTO.Text = "1";
        }

		/// <summary>
		/// Set dropdown accordingly (based on ketentuan kredit defined)
		/// </summary>
		private void viewData() 
		{
			/// Default Application type is ME (Withdrawal)
			/// 
			try { DDL_APPTYPE.SelectedValue = "06"; } catch {}


			/// CIF
			/// 
			conn.QueryString = "select CU_CIF from CUSTOMER where CU_REF = '" + Request.QueryString["curefchann"]+ "'";
			conn.ExecuteQuery();

			string cifNo = "";
			cifNo = conn.GetFieldValue("CU_CIF");
			try { DDL_CU_CHANNELCOMP.SelectedValue = cifNo; } 
			catch {}
	
			/// AA Number (AA_NO), PRODUCTID, Account Number (ACC_NO)
			/// 
			conn.QueryString = "IDE_KETKREDIT_WITHDRAWAL '" + Request.QueryString["ket_code"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				try { DDL_AA_NO.SelectedValue = conn.GetFieldValue("AA_NO"); } catch {}
				try { DDL_PRODUCTID.SelectedValue = conn.GetFieldValue("PRODUCTID"); } catch {}				
				TXT_PRODUCTDESC.Text = conn.GetFieldValue("PRODUCTDESC");

				/// Re-load DDL_FACILITYNO to get the specific result
				/// 
				//string query = "select acc_seq, acc_seq from bookedprod where aa_no = '' and productid = '' and acc_seq = '' and cu_ref = ''";
				string query = "select acc_seq, acc_seq from ketentuan_kredit where ket_code = '" + Request.QueryString["ket_code"] + "'";
				GlobalTools.fillRefList(DDL_FACILITYNO, query, false, conn);
				try { DDL_FACILITYNO.SelectedIndex = 1; } catch {}
			}
		}

		/// <summary>
		/// Manual Initialize DropDowns in form
		/// </summary>
		private void initializeDropDowns() 
		{
			/*
			string query = "select cu_cif, cu_cif from vw_channelcomp where cu_channelcomp = '1' and cu_ref = '" + Request.QueryString["curefchann"] + "'";
			GlobalTools.fillRefList(DDL_CU_CHANNELCOMP, query, false, conn);

			if (DDL_CU_CHANNELCOMP.Items.Count == 1) 
			{
				GlobalTools.popMessage(this, "Perusaahaan adalah Perusahaan Non-Channeling!");
				//Response.Write("<script language='javascript'>history.back(-1);</script>");
				return;
			}
			*/

			if (Request.QueryString["curef"] != Request.QueryString["curefchann"]) 
			{
				/// kalau dari fasilitas orang lain
				GlobalTools.fillRefList(DDL_APPTYPE, "select apptypeid, apptypedesc from rfapplicationtype where active='1' AND apptypeid <> '01' and channeling = '1'", false, conn);
			}
			else 
			{
				/// kalau dari account sendiri
				GlobalTools.fillRefList(DDL_APPTYPE, "select apptypeid, apptypedesc from rfapplicationtype where active='1' AND apptypeid <> '01'", false, conn);
			}

			GlobalTools.fillRefList(DDL_AA_NO, "select distinct aa_no, aa_no from vw_cifproduct", false, conn);			
			GlobalTools.fillRefList(DDL_CP_TENORCODE, "select tenorcode, tenordesc from rftenorcode where active='1'", false, conn);

			//GlobalTools.fillRefList(DDL_FACILITYNO, "select acc_seq, acc_no from bookedprod where aa_no = ''", false, conn);
			GlobalTools.fillRefList(DDL_FACILITYNO, "select acc_seq, acc_no from bookedprod", false, conn);

			//GlobalTools.fillRefList(DDL_PRODUCTID, "select productid from vw_cifproduct where cu_cif = ''", false, conn);
			GlobalTools.fillRefList(DDL_PRODUCTID, "select productid, productid from vw_cifproduct", false, conn);

			GlobalTools.fillRefList(DDL_WITHDRAWLID, "select withdrawlid, withdrawldesc from rfwithdrawltype where active='1'", false, conn);

			try { DDL_CP_TENORCODE.SelectedValue = "M"; } 
			catch {}

			//--- Tujuan Penggunaan
			GlobalTools.fillRefList(DDL_CP_LOANPURPOSE, "select LOANPURPID, LOANPURPID + ' - ' + LOANPURPDESC as LOANPURPDESC from RFLOANPURPOSE where ACTIVE='1' order by LOANPURPID", false, conn);
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

		
		/// <summary>
		/// Display Exchange Rate according to product selected
		/// </summary>
		private void viewExchangeRate() 
		{
			try 
			{
				conn.QueryString = "select PRODUCTID, CURRENCY, C.CURRENCYRATE " +
					"from RFPRODUCT p " +
					"left join RFCURRENCY c on P.CURRENCY = C.CURRENCYID " +
					"where C.ACTIVE = '1' and P.ACTIVE = '1' and PRODUCTID = '" + DDL_PRODUCTID.SelectedValue + "'";
				conn.ExecuteQuery();

				TXT_CP_EXRPLIMITCHGTO.Text = (conn.GetRowCount()>0?conn.GetFieldValue("CURRENCYRATE"):"1.0");
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error !");
				return;
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
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						//t.ForeColor = Color.MidnightBlue; 
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

		private void viewCIF() 
		{
			/*
			conn.QueryString = "select CU_CIF from CUSTOMER where CU_REF = '" +Request.QueryString["curefchann"]+ "'";
			conn.ExecuteQuery();

			string cifNo = "";
			cifNo = conn.GetFieldValue("CU_CIF");
			try 
			{
				DDL_CU_CHANNELCOMP.SelectedValue = cifNo;
			} 
			catch (IndexOutOfRangeException) 
			{
				GlobalTools.popMessage(this, "Perusaahaan adalah Perusahaan Non-Channeling!");
				//Response.Write("<script language='javascript'>history.back(-1);</script>");
			}
			catch (ArgumentOutOfRangeException) 
			{
				GlobalTools.popMessage(this, "Perusaahaan adalah Perusahaan Non-Channeling!");
				//Response.Write("<script language='javascript'>history.back(-1);</script>");
			}
			*/

			if (DDL_CU_CHANNELCOMP.SelectedValue != "")
			{
				try 
				{
					conn.QueryString = "select distinct aa_no from vw_cifproduct where cu_cif='" + DDL_CU_CHANNELCOMP.SelectedValue + "'";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						DDL_AA_NO.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
				} 
				catch (NullReferenceException) 
				{
					GlobalTools.popMessage(this, "Connection Error!");
					Response.Redirect("../Login.aspx?expire=1");
				}
			}
		}

		private void setButtonVisibility() 
		{
			/* *			  
			 * 
			 * Button1 => UPDATE_STATUS
			 * Button2 => NEXT			
			 * 
			 * */

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
		}

		private void fillAppType() 
		{
			DDL_APPTYPE.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select apptypeid, apptypedesc from rfapplicationtype where active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_APPTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			DDL_APPTYPE.SelectedValue = Request.QueryString["app"];
		}

		private void fillAppNo() 
		{
			//DDL_AA_NO.Items.Add(new ListItem("- PILIH -", ""));
			//conn.QueryString = "select distinct aa_no from bookedcust where cu_ref='" + Request.QueryString["curef"] + "'";
			if (DDL_CU_CHANNELCOMP.SelectedValue != "")
			{
				conn.QueryString = "select distinct aa_no from vw_cifproduct where cu_cif='" + DDL_CU_CHANNELCOMP.SelectedValue + "'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_AA_NO.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
			}
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
			////////////////////////////////////////////////////////////////////////////////////////////////
			/// If withdrawal is applied from his own account, 
			/// Cek whether the facility is a channeling facility
			/// Withdrawal can be done only-if the facility is a channeling facility
			/// 
			if (Request.QueryString["curef"] == Request.QueryString["curefchann"]) 
			{
				conn.QueryString = "exec IDE_CEK_CHANNFACILITY '" + Request.QueryString["curef"] + 
					"', '" + DDL_PRODUCTID.SelectedValue + 
					"', '" + DDL_AA_NO.SelectedValue + 
					"', '" + DDL_FACILITYNO.SelectedItem.Text.Trim() + 
					"', '" + Request.QueryString["ket_code"] + "'";
				conn.ExecuteQuery();

				Response.Write("<!-- fac check: " + conn.QueryString.ToString() + " -->");

				string _isChannFacility = conn.GetFieldValue("ISCHANNFACILITY");
				if (_isChannFacility == "0") 
				{
					GlobalTools.popMessage(this, "Facility yang dipilih bukan channeling facility!");
					return;
				}
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////


			//cek apakah sudah pernah disimpan di custproduct apa belum
			//jika untuk application type dan kode ketentuan kredit yang sama sudah ada maka jangan diinsert lagi
			bool isNewApp = true;
			try
			{
				conn.QueryString  = "select KET_CODE from KETENTUAN_KREDIT where ";
				conn.QueryString += "AP_REGNO = '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
				string ket_code = conn.GetFieldValue("KET_CODE");

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
				try
				{
					conn.QueryString = "exec IDE_LOANINFO_WITHDRAWL '" + Request.QueryString["regno"] + "', '" +
						DDL_AA_NO.SelectedValue + "', " +
						tool.ConvertNull(DDL_FACILITYNO.SelectedValue) + ", '" +
						DDL_APPTYPE.SelectedValue + "', " +
						tool.ConvertFloat(TXT_CP_LIMITCHGTO.Text) + ", " + 
						tool.ConvertFloat(TXT_CP_EXRPLIMITCHGTO.Text) + ", " + 
						tool.ConvertFloat(TXT_CP_EXLIMITCHGTO.Text) + ", '" + 
						TXT_CP_NOTES.Text + "', " + 
						tool.ConvertNull(DDL_WITHDRAWLID.SelectedValue) + ", '" + 
						DDL_PRODUCTID.SelectedValue + "', " + TXT_CP_JANGKAWKT.Text + ", '" +
						DDL_CP_TENORCODE.SelectedValue + "', '" +
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
						LBL_MAINREGNO.Text + "', '" +
						LBL_MAINPRODUCTID.Text + "', '" + 
						LBL_MAINPROD_SEQ.Text + "'";
					conn.ExecuteNonQuery();					
				} 
				catch (NullReferenceException) 
				{
					GlobalTools.popMessage(this, "Connection Error!");
					return;
				}

                conn.QueryString = "UPDATE KETENTUAN_KREDIT SET TAKEOVER_FLAG = '" + Request.QueryString["takeover"] +
                "' WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' " +
                "AND KET_CODE = '" + Request.QueryString["ket_code"] + "'";
                conn.ExecuteQuery();


				/****
				 * --- YUDI (20041019)
				 * Code dibawah diganti dengan SP
				 * 
				conn.QueryString = "insert into apptrack (ap_regno, apptype, productid, ap_currtrack, ap_currtrackdate, ap_currtrackby) " + 
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
					DDL_PRODUCTID.SelectedValue + "', '" + 
					Request.QueryString["tc"] + "', '" + 
					LBL_USERID.Text + "'";
				conn.ExecuteNonQuery();

				ViewApplications();
			}
			else
			{
				GlobalTools.popMessage(this, "Jenis pengajuan pinjaman yang diminta sudah ada!");
			}

		}

		private void ClearSelections()
		{
			DDL_AA_NO.SelectedValue = "";
			DDL_PRODUCTID.SelectedValue = "";
			DDL_FACILITYNO.Visible = false;
			TXT_PRODUCTDESC.Text = "";
			//LBL_PRODUCTID.Text = "";			
			TXT_CP_LIMITCHGTO.Text = "";
			TXT_CP_EXRPLIMITCHGTO.Text = "";
			TXT_CP_EXLIMITCHGTO.Text = "";
			TXT_CP_NOTES.Text = "";
			TXT_CP_JANGKAWKT.Text = "";
			DDL_CP_TENORCODE.SelectedValue = "";
			DDL_CP_LOANPURPOSE.SelectedValue = "";
		}

		protected void Button2_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("FairIsaac.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&prog=" + Request.QueryString["prog"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		private void ViewApplications()
		{
			conn.QueryString = "select KET_CODE from KETENTUAN_KREDIT where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			string KET_CODE = conn.GetFieldValue("KET_CODE");
			
			DataTable dt1 = new DataTable();
			conn.QueryString = "select * from VW_IDE_LISTAPPLICATION where AP_REGNO='" + Request.QueryString["regno"] + "' and KET_CODE = '" + KET_CODE + "'";
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
			//TXT_PRODUCTDESC.Text = conn.GetFieldValue("PRODUCTDESC");sadffsd
			//TXT_CP_LIMIT.Text = tool.MoneyFormat(conn.GetFieldValue("CP_LIMIT"));
			
			//LBL_PRODUCTID.Text = conn.GetFieldValue("PRODUCTID");

			/*
			//conn.QueryString = "select bp.limit,  from bookedprod bp where aa_no='" + DDL_AA_NO.SelectedValue + "' and productid='" + DDL_PRODUCTID.SelectedValue + "' and acc_seq='" + DDL_FACILITYNO.SelectedValue + "'";
			conn.QueryString = "select bp.LIMIT, rt.TENORVALUE, rt.TENORDESC from bookedprod bp left join rftenor rt on bp.tenor=rt.tenorseq " + 
				"where bp.aa_no='" + DDL_AA_NO.SelectedValue + "' and bp.productid='" + DDL_PRODUCTID.SelectedValue + "' and bp.acc_seq='" + DDL_FACILITYNO.SelectedValue + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				TXT_LIMIT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LIMIT"));
				TXT_TENORDESC.Text = conn.GetFieldValue(0, "TENORDESC");
			}
			*/
		}

		protected void DDL_AA_NO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//conn.QueryString = "select productid from bookedcust where cu_ref='" + Request.QueryString["curef"] + "' and aa_no='" + DDL_AA_NO.SelectedValue + "'";
			conn.QueryString = "select productid from vw_cifproduct where cu_cif='" + DDL_CU_CHANNELCOMP.SelectedValue + "' and aa_no='" + DDL_AA_NO.SelectedValue + "'";
			conn.ExecuteQuery();

			DDL_PRODUCTID.Items.Clear();	
			DDL_PRODUCTID.Items.Add(new ListItem("- PILIH -", ""));

			DDL_FACILITYNO.Items.Clear();	
			DDL_FACILITYNO.Items.Add(new ListItem("- PILIH -", ""));

			if (DDL_AA_NO.SelectedValue != "") 
			{
				DDL_PRODUCTID.Enabled = true;
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_PRODUCTID.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
			}
			else 
			{
				DDL_PRODUCTID.Enabled = false;
				DDL_FACILITYNO.Enabled = false;
				TXT_PRODUCTDESC.Text = "";
			}
		}

		protected void DDL_PRODUCTID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DDL_FACILITYNO.Items.Clear();
			DDL_FACILITYNO.Items.Add(new ListItem("- PILIH -", ""));
			if (DDL_PRODUCTID.SelectedValue != "") 
			{
				conn.QueryString = "select acc_seq, acc_no from bookedprod where aa_no='" + DDL_AA_NO.SelectedValue + "' and productid='" + DDL_PRODUCTID.SelectedValue + "'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					//DDL_FACILITYNO.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					DDL_FACILITYNO.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
			
				conn.QueryString = "select productdesc from rfproduct where productid='" + DDL_PRODUCTID.SelectedValue + "'";
				conn.ExecuteQuery();
				TXT_PRODUCTDESC.Text = conn.GetFieldValue("productdesc");

				DDL_FACILITYNO.Enabled = true;
			}
			else 
			{
				DDL_FACILITYNO.Enabled = false;
				TXT_PRODUCTDESC.Text = "";
			}
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
				}
			}

			DataTable dt;
			conn.QueryString = "select apptype, productid from custproduct where ap_regno='" + Request.QueryString["regno"] +
				"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				conn.QueryString = "exec TRACKUPDATE '" + Request.QueryString["regno"] + "', '" +
					dt.Rows[i][1].ToString() + "', '" + dt.Rows[i][0].ToString() + "', '" + LBL_USERID.Text + "'";
					//dt.Rows[i][1].ToString() + "', '" + dt.Rows[i][0].ToString() + "', '" + Session["UserID"].ToString() + "'";
				conn.ExecuteNonQuery();
			}
			Response.Redirect("FindCustomer.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		protected void DDL_CU_CHANNELCOMP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DDL_AA_NO.Items.Clear();
			DDL_AA_NO.Items.Add(new ListItem("- PILIH -", ""));
			if (DDL_CU_CHANNELCOMP.SelectedValue != "")
			{
				conn.QueryString = "select aa_no from vw_withdrawl_cif where cu_cif='" + DDL_CU_CHANNELCOMP.SelectedValue + "'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_AA_NO.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
			}
		}
	}
}
