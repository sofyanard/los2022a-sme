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

namespace SME.LOW
{
	/// <summary>
	/// Summary description for Renewal.
	/// </summary>
	public partial class Renewal : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPTGASURANSI_YEAR;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_TGASURANSI_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPTGASURANSI_DAY;

		#region " My Variables "

		protected Tools tool = new Tools();
		//protected string mainregno, mainprod_seq, mainproductid;
		protected Connection conn;

		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn			= (Connection) Session["Connection"];

			LBL_MAINREGNO.Text		= Request.QueryString["mainregno"];
			LBL_MAINPROD_SEQ.Text	= Request.QueryString["mainprod_seq"];
			LBL_MAINPRODUCTID.Text = Request.QueryString["mainproductid"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			cekIsView(Request.QueryString["view"]);

			if (!IsPostBack)
			{
				LBL_USERID.Text = Session["UserID"].ToString();				
				LBL_VA.Text		= Request.QueryString["va"];

				//GlobalTools.initDateForm(TXT_CP_TENOR_DAY, DDL_CP_TENOR_MONTH, TXT_CP_TENOR_YEAR, false);
				Tools.initDateForm(TXT_CP_TENOR_DAY, DDL_CP_TENOR_MONTH, TXT_CP_TENOR_YEAR, false);

				DDL_APPTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_FACILITYNO.Items.Add(new ListItem("- PILIH -", "0"));
				DDL_AA_NO.Items.Add(new ListItem("- PILIH -", ""));
				//DDL_CP_TENORCHGTO.Items.Add(new ListItem("- PILIH -", ""));asdf
				DDL_CP_TENORCODE.Items.Add(new ListItem("- PILIH -", ""));

				/// tenorcode
				conn.QueryString = "select tenorcode, tenordesc from rftenorcode where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CP_TENORCODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				DDL_CP_TENORCODE.SelectedValue = "M";

				/// apptype
				conn.QueryString = "select apptypeid, apptypedesc from rfapplicationtype where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_APPTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				DDL_APPTYPE.SelectedValue = Request.QueryString["app"];

				/// aa_no
				if (Request.QueryString["curefchann"] == "" || Request.QueryString["curefchann"] == null) 
					conn.QueryString = "select distinct aa_no from bookedcust where cu_ref='" + Request.QueryString["curef"] + "'";
				else 
					conn.QueryString = "select distinct aa_no from bookedcust where cu_ref='" + Request.QueryString["curefchann"] + "'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_AA_NO.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));

				/// projectname
				GlobalTools.fillRefList(DDL_PRJ_NAME, "select PRJ_CODE, PRJ_NAME from RFPROJECT where ACTIVE = '1'", false, conn);

				//--- Tujuan Penggunaan
				conn.QueryString = "select LOANPURPID, LOANPURPID + ' - ' + LOANPURPDESC as LOANPURPDESC from RFLOANPURPOSE where ACTIVE='1' order by LOANPURPID";
				conn.ExecuteQuery();
				DDL_CP_LOANPURPOSE.Items.Add(new ListItem("- PILIH -", ""));
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CP_LOANPURPOSE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

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
				if (conn.GetFieldValue(0,0) != "1")				
					DDL_APPTYPE.Items.Remove(DDL_APPTYPE.Items.FindByValue("06"));
				

				viewData();

			}
			ViewMenu();
			//BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};if(!SaveMsg()){return false;};");
			Button1.Attributes.Add("onclick","if(!update()){return false;};");
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
			try 
			{
				DDL_APPTYPE.Items.Remove(DDL_APPTYPE.Items.FindByValue("01"));
				//DDL_APPTYPE.SelectedValue = "04";
				DDL_APPTYPE.SelectedValue = Request.QueryString["app"];
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Jenis Pengajuan tidak ditemukan !");
				return;
			}

			//AA_No dan No rekening sudah ditentukan saat menentukan ketentuan kredit
			/***
				conn.QueryString = "select * " +
					"from ketentuan_kredit k " +
					"inner join bookedprod b on k.aa_no = b.aa_no and k.acc_seq = b.acc_seq " +
					"where KET_CODE = '" + Request.QueryString["ket_code"] + "'";
				***/
			conn.QueryString = "select * from KETENTUAN_KREDIT where KET_CODE ='" + Request.QueryString["ket_code"] + "'";
			conn.ExecuteQuery();
			try { DDL_AA_NO.SelectedValue = conn.GetFieldValue("AA_NO"); } 
			catch {}
			LBL_PRODUCTID.Text = conn.GetFieldValue("PRODUCTID");

			DDL_FACILITYNO.Items.Add(new ListItem("- PILIH -",""));
			DDL_FACILITYNO.Items.Add(new ListItem(conn.GetFieldValue("ACC_NO"), conn.GetFieldValue("ACC_SEQ")));
			try { DDL_FACILITYNO.SelectedValue = conn.GetFieldValue("ACC_SEQ"); } 
			catch {}

			DDL_AA_NO.Enabled = false;
			DDL_FACILITYNO.Enabled = false;

			/// get account number
			string _accno = conn.GetFieldValue("ACC_NO");
			if (_accno == null) _accno = "";
			try { _accno = _accno.Trim(); } catch {}
			try 
			{
				//conn.QueryString = "select bp.productid, rp.productdesc, bp.limit, bp.tenor, rt.tenordesc from xxxbookedprod bp left join rftenorcode rt on bp.tenorcode=rt.tenorcode left join rfproduct rp on bp.productid=rp.productid where aa_no='" + DDL_AA_NO.SelectedValue + "' and acc_seq=" + DDL_FACILITYNO.SelectedValue;
				conn.QueryString = "select v.productid, productdesc, limit, tenor, '' as tenordesc, loanpurpid " +
					" from VW_BOOKEDPROD v left join rfproduct p on  v.productid = p.productid " +
					" where aa_no = '" + DDL_AA_NO.SelectedValue + "' " +
					" and acc_seq = '" + DDL_FACILITYNO.SelectedValue + "' " + 
					" and v.productid = '" + LBL_PRODUCTID.Text + "' " + 
					" and acc_no = '" + _accno + "' " +
					" and cu_ref = '" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				Response.Write("../Login.aspx?expire=1");
			}
			catch {
				return;
			}

			if (conn.GetRowCount() > 0)
			{
				TXT_LIMIT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LIMIT"));
				TXT_TENORDESC.Text = conn.GetFieldValue(0, "tenor") + " " + conn.GetFieldValue(0, "TENORDESC");
				TXT_PRODUCTDESC.Text = conn.GetFieldValue(0, "productdesc");
				try {DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue(0, "LOANPURPID");}
				catch {}
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

//				//Kalau dipanggil dari va, jenis pengajuan tidak bisa dihapus
//				if (LBL_VA.Text != "" || LBL_VA.Text != null) 
//				{
//					LinkButton LNK_DEL = (LinkButton) DATAGRID1.Items[i].Cells[11].FindControl("LNK_DELETE");
//					LNK_DEL.Visible = false;
//				}
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

		protected void DDL_AA_NO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*sdafsadffsda
			conn.QueryString = "select productid from bookedcust where cu_ref='" + Request.QueryString["curef"] + "' and aa_no='" + DDL_AA_NO.SelectedValue + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_PRODUCTID.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));		
			*/
			DDL_FACILITYNO.Items.Clear();
			DDL_FACILITYNO.Items.Add(new ListItem("- PILIH -", "0"));

			TXT_PRODUCTDESC.Text = "";
			TXT_LIMIT.Text = "";
			TXT_TENORDESC.Text = "";

			conn.QueryString = "select acc_seq, acc_no from bookedprod where aa_no='" + DDL_AA_NO.SelectedValue + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_FACILITYNO.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		protected void DDL_FACILITYNO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*
			conn.QueryString = "select bp.LIMIT, rt.TENORVALUE, rt.TENORDESC from bookedprod bp inner join rftenor rt on bp.tenor=rt.tenorseq " + 
				"where bp.aa_no='" + DDL_AA_NO.SelectedValue + "' and bp.productid='" + DDL_PRODUCTID.SelectedValue + "' and bp.acc_seq='" + DDL_FACILITYNO.SelectedValue + "'";
			conn.ExecuteQuery();
			*/
			conn.QueryString = "select bp.productid, rp.productdesc, bp.limit, bp.tenor, rt.tenordesc " + 
				" from bookedprod bp " + 
				" left join rftenorcode rt on bp.tenorcode=rt.tenorcode " +
				" left join rfproduct rp on bp.productid=rp.productid " + 
				" where aa_no = '" + DDL_AA_NO.SelectedValue + "' " + 
				" and acc_seq = '" + DDL_FACILITYNO.SelectedValue + "'";				
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				TXT_LIMIT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LIMIT"));
				TXT_TENORDESC.Text = conn.GetFieldValue(0, "tenor") + " " + conn.GetFieldValue(0, "TENORDESC");
				TXT_PRODUCTDESC.Text = conn.GetFieldValue(0, "productdesc");
				LBL_PRODUCTID.Text = conn.GetFieldValue(0, "productid");
			}
		}

		protected void Button2_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("FairIsaac.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&prog=" + Request.QueryString["prog"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		private void ClearSelections()
		{
//			DDL_AA_NO.SelectedValue = "";
//			DDL_FACILITYNO.SelectedValue = "0";
			TXT_PRODUCTDESC.Text = "";
			LBL_PRODUCTID.Text = "";
			TXT_LIMIT.Text = "";
			TXT_TENORDESC.Text = "";
			TXT_CP_JANGKAWKT.Text = "";
			DDL_CP_TENORCODE.SelectedValue = "";
			TXT_CP_NOTES.Text = "";
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			/***
			conn.QueryString = "select count (*) from cust_product where ap_regno='" + Request.QueryString["regno"] + "' and apptype='" + 
				DDL_APPTYPE.SelectedValue + "' and productid='" + LBL_PRODUCTID.Text + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue(0,0) != "0")
			{
				//ClearSelections();
				Response.Write("<script language='javascript'>alert('Permohonan yg sama pada produk yg diminta!');</script>");
			}

			else
			{
			***/

			//--- validasi Maturity Date ---//
			if (RDO_TENORTYPE.SelectedValue != "1") 
			{
				try 
				{
					int banding = Tools.compareDate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), TXT_CP_TENOR_DAY.Text, DDL_CP_TENOR_MONTH.SelectedValue, TXT_CP_TENOR_YEAR.Text);
					if (banding >= 0) 
					{
						GlobalTools.popMessage(this, "Tanggal Maturity tidak boleh kurang dari Tanggal sekarang");
						return;
					}
				} 
				catch 
				{
					GlobalTools.popMessage(this, "Connection Error!");
					return;
				}
			}
			
			//cek apakah sudah pernah disimpan di custproduct apa belum
			//jika untuk application type dan kode ketentuan kredit yang sama sudah ada maka jangan diinsert lagi
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
			
			//Response.Write(conn.QueryString + "<BR>");
			//Response.Write(LBL_MAINREGNO.Text + " " + LBL_MAINPRODUCTID.Text + " " + LBL_MAINPROD_SEQ.Text + "<BR>");
			
			//------------------------------//

			if (isNewApp) //belum ada ketentuan kredit untuk aplikasi yang dipilih
			{
				try
				{
					if (RDO_TENORTYPE.SelectedValue == "1") // tenor
						conn.QueryString = "exec IDE_LOANINFO_RENEWAL '" + 
							Request.QueryString["regno"] + "', '" + 
							Request.QueryString["curef"] + "', '" + 
							DDL_APPTYPE.SelectedValue + "', '" + 
							TXT_CP_NOTES.Text + "', " + 
							DDL_FACILITYNO.SelectedValue + ", '" + 
							DDL_AA_NO.SelectedValue + "', '" + 
							LBL_PRODUCTID.Text + "', " + 
							TXT_CP_JANGKAWKT.Text + ", '" + 
							DDL_CP_TENORCODE.SelectedValue + "', " + 
							tool.ConvertNull(DDL_PRJ_NAME.SelectedValue) + ", '" + 
							ket_code + "', '" +
							DDL_CP_LOANPURPOSE.SelectedValue + "'";
					else	// maturitydate
						conn.QueryString = "exec IDE_LOANINFO_RENEWAL2 '" + 
							Request.QueryString["regno"] + "', '" + 
							Request.QueryString["curef"] + "', '" + 
							DDL_APPTYPE.SelectedValue + "', '" + 
							TXT_CP_NOTES.Text + "', " + 
							DDL_FACILITYNO.SelectedValue + ", '" + 
							DDL_AA_NO.SelectedValue + "', '" + 
							LBL_PRODUCTID.Text + "', " + 
							GlobalTools.ToSQLDate(TXT_CP_TENOR_DAY.Text.Trim(), DDL_CP_TENOR_MONTH.SelectedValue, TXT_CP_TENOR_YEAR.Text.Trim()) + ", '" + 
							DDL_CP_TENORCODE.SelectedValue + "', " + 
							tool.ConvertNull(DDL_PRJ_NAME.SelectedValue) + ", '" + 
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
						LBL_PRODUCTID.Text + "', '" + 
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

				/***
					* --- YUDI (20041019)
					* Code dibawah dipaket dalam SP
					*				
				conn.QueryString = "insert into apptrack (ap_regno, apptype, productid, ap_currtrack, ap_currtrackdate, ap_currtrackby) " + 
					"values ('" + 
					Request.QueryString["regno"] + "', '" + 
					DDL_APPTYPE.SelectedValue + "', '" + 
					LBL_PRODUCTID.Text + "', '" + 
					Request.QueryString["tc"] + "', getdate(), '" + 
					LBL_USERID.Text + "')";
				conn.ExecuteNonQuery();
		
				conn.QueryString = "select count(*) from track_history where ap_regno='" + Request.QueryString["regno"] + "' and apptype='" + DDL_APPTYPE.SelectedValue + "' and productid='" + LBL_PRODUCTID.Text + "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue(0,0) == "0")
				{
					conn.QueryString = "insert into track_history (ap_regno, apptype, productid, trackcode, th_seq, th_trackdate, th_trackby) values " + 
						"('" + 
						Request.QueryString["regno"] + "', '" + 
						DDL_APPTYPE.SelectedValue + "', '" + 
						LBL_PRODUCTID.Text + "', '" + 
						Request.QueryString["tc"] + "', 1, getdate(), '" + 
						LBL_USERID.Text + "')";						
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

		private void DATAGRID1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					/*
					conn.QueryString = "delete from apptrack where ap_regno='" + Request.QueryString["regno"] + "' and apptype='" + e.Item.Cells[1].Text + "' and productid='" + e.Item.Cells[3].Text + "' and PROD_SEQ = '" + e.Item.Cells[10].Text + "'";
					conn.ExecuteNonQuery();

					conn.QueryString = "delete from custproduct where ap_regno='" + Request.QueryString["regno"] + "' and apptype='" + e.Item.Cells[1].Text + "' and productid='" + e.Item.Cells[3].Text + "' and PROD_SEQ = '" + e.Item.Cells[10].Text + "'";
					conn.ExecuteNonQuery();

					conn.QueryString = "delete from trackhistory where ap_regno='" + Request.QueryString["regno"] + "' and apptype='" + e.Item.Cells[1].Text + "' and productid='" + e.Item.Cells[3].Text + "' and PROD_SEQ = '" + e.Item.Cells[10].Text + "'";
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
							e.Item.Cells[10].Text + "'";		// prod_seq
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

		protected void RDO_TENORTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TXT_CP_JANGKAWKT.Visible = false;
			DDL_CP_TENORCODE.Visible = false;
			TXT_CP_TENOR_DAY.Visible = false;
			DDL_CP_TENOR_MONTH.Visible = false;
			TXT_CP_TENOR_YEAR.Visible = false;

			TXT_CP_JANGKAWKT.CssClass = "";
			DDL_CP_TENORCODE.CssClass = "";
			TXT_CP_TENOR_DAY.CssClass = "";
			DDL_CP_TENOR_MONTH.CssClass = "";
			TXT_CP_TENOR_YEAR.CssClass = "";


			if (RDO_TENORTYPE.SelectedValue == "1")		// Days/Month
			{
				TXT_CP_JANGKAWKT.Visible = true;
				DDL_CP_TENORCODE.Visible = true;

				TXT_CP_JANGKAWKT.CssClass = "mandatory";
				DDL_CP_TENORCODE.CssClass = "mandatory";
			}
			else //Maturity Date
			{
				TXT_CP_TENOR_DAY.Visible = true;
				DDL_CP_TENOR_MONTH.Visible = true;
				TXT_CP_TENOR_YEAR.Visible = true;

				TXT_CP_TENOR_DAY.CssClass = "mandatory";
				DDL_CP_TENOR_MONTH.CssClass = "mandatory";
				TXT_CP_TENOR_YEAR.CssClass = "mandatory";
			}
		}
	}
}
