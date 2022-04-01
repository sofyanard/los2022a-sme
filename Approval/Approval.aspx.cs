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
using System.Web.Configuration;
using System.Configuration;
using System.Collections.Generic;

namespace SME.Approval
{
	/// <summary>
	/// Summary description for Approval.
	/// </summary>
	public partial class Approval : System.Web.UI.Page
	{
		protected Connection conn;
		protected System.Web.UI.WebControls.TextBox txt_tenor;
		protected System.Web.UI.WebControls.TextBox txt_int;
		protected System.Web.UI.WebControls.TextBox txt_inttype;
		protected System.Web.UI.WebControls.TextBox txt_sifat;
		protected System.Web.UI.WebControls.TextBox txt_purpose;
		protected System.Web.UI.WebControls.TextBox txt_exclimit;
		protected System.Web.UI.WebControls.TextBox txt_equlimit;
		protected System.Web.UI.WebControls.TextBox txt_exccol;
		protected System.Web.UI.WebControls.TextBox txt_totcol;
		protected System.Web.UI.WebControls.TextBox txt_ovrsta;
		protected System.Web.UI.WebControls.DropDownList ddl_ovreason;
		protected System.Web.UI.WebControls.TextBox txt_ovreason;
		protected System.Web.UI.WebControls.TextBox txt_labaop;
		protected System.Web.UI.WebControls.TextBox txt_total;
		protected System.Web.UI.WebControls.CheckBox chk_idc;
		protected System.Web.UI.WebControls.TextBox txt_idcratio;
		protected System.Web.UI.WebControls.TextBox txt_idcterm;
		protected System.Web.UI.WebControls.TextBox txt_idcexpdate;
		protected System.Web.UI.WebControls.TextBox txt_idcint;
		protected System.Web.UI.WebControls.TextBox txt_idcprimerate;
		protected System.Web.UI.WebControls.TextBox txt_idcprimevar;
		protected System.Web.UI.WebControls.TextBox txt_idccapamt;
		protected System.Web.UI.WebControls.TextBox txt_idccapratio;
		protected System.Web.UI.WebControls.TextBox txt_idcprimevarcode;
		protected Tools tool = new Tools();
		string var_complevel, var_uplineruser, var_uplinertrack;
		string var_reject, var_reject1, var_approve, var_cancelcust, var_cancelbank, var_prrk;
		string var_kreditbaru, var_ubahjaminan, var_ubahlimit, var_renewal, var_ubahsyarat;
		string var_sgprrk, var_small, var_middle, groupid, var_appeal, var_corp, var_crg, var_micro;
		string var_accept, var_greyzone, var_decline, var_fairissac, var_progfoureyes;
		string var_inbranch, var_appbranch, var_area, var_cbc, var_aprvuntil, var_aprvnextby, var_aprveye;
		string msg, company_curef;
		double var_userlimit, var_lineamount, var_limitexp; //, var_ddluserlimit;	
		double var_smlminappeal, var_smlmaxappeal;
		protected System.Web.UI.WebControls.Button btn_aprvby;
		DataTable dt_init	 = new DataTable();
		protected System.Web.UI.WebControls.CheckBoxList Checkboxlist1;
		DataTable dt_aprvdec = new DataTable();
		protected System.Web.UI.WebControls.Button btn_tes;
		string var_user, approval_user, var_groupid;
		protected System.Web.UI.WebControls.TextBox TXT_OUTSTANDING;
		protected System.Web.UI.WebControls.TextBox TXT_RATIO_LIMIT;
		protected System.Web.UI.WebControls.Label lbl_sekom3;
		protected System.Web.UI.WebControls.TextBox TXT_PENDING;
		protected System.Web.UI.WebControls.TextBox TXT_AVAILABLE;
		protected System.Web.UI.WebControls.TextBox TXT_RATIO_AVAIL;
		protected System.Web.UI.WebControls.TextBox TXT_INDUSTRYCLASS;
		protected System.Web.UI.WebControls.TextBox TXT_STATUS;
		protected System.Web.UI.WebControls.Label lbl_ksebi4;
		protected System.Web.UI.WebControls.Button BTN_REEARMARK;
		protected System.Web.UI.WebControls.Label percent;
		protected System.Web.UI.WebControls.Label percent2;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			//var_user = Session["USERID"].ToString();
			
			/// Get next approval user of application
			/// 
			conn.QueryString = " select ap_aprvnextby from application where ap_regno = '"+ Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0 ) var_user = conn.GetFieldValue("ap_aprvnextby");	// user diganti
			else var_user = Session["USERID"].ToString();
			
			/// Get approval user login
			/// 
			approval_user = Session["USERID"].ToString();  // user pengganti


			/// Get user group of approval user of application
			/// 
			conn.QueryString = " select  groupid from scuser where userid = '"+ var_user + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0 ) var_groupid = conn.GetFieldValue("groupid");
			else var_groupid = Session["GROUPID"].ToString();


			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			ViewMenu();
			viewdata();

			if (!IsPostBack)
			{
				TR_INFO_CRM.Visible = false;	// by default, hide the info from CRM

				fillAcquireInformation();
				approval2();
			}

			//20070725 add by sofyan for new approval routing
			//if ((LBL_APRV_ROUTING.Text == "four eyes") && (var_complevel == var_middle || var_complevel == var_corp || var_complevel == var_crg))
			/*
			if (LBL_APRV_ROUTING.Text == "four eyes")
			{
				fillDdlForward4eyes();
			}
			*/

			/// Set Button Attributes for onClick
			/// 
			btn_appeal.Attributes.Add("onclick", "if(!continueApproval('Appeal')) {return false;};");						
			btn_aprvrej.Attributes.Add("onclick", "if(!continueApproval('Approve')) {return false;};");			
			btn_fwdrej.Attributes.Add("onclick", "if(!continueApproval('Approval Assigned To')) {return false;};");
			btn_fwdrisk.Attributes.Add("onclick", "if(!continueApproval('Forward to Risk Unit')) {return false;};");
			btn_reject.Attributes.Add("onclick", "if(!continueApproval('Reject')) {return false;};");
			btn_pprk.Attributes.Add("onclick", "if(!continueApproval('PRRK')) {return false;};");

			InitializeEvent();

            //pundi update
            //cek BM atau CR
            BMorCRChecker();
		}

        private void BMorCRChecker()
        {
            string GROUPID = "";
            conn.QueryString = "SELECT SCUSER.GROUPID, SCUSER.SU_BRANCH, RFBRANCH.CBC_CODE, RFBRANCH.AREAID FROM SCUSER, RFBRANCH " +
                "WHERE SCUSER.USERID = '" + lbl_userid.Text + "' " +
                "AND SCUSER.SU_BRANCH = RFBRANCH.BRANCH_CODE ";
            conn.ExecuteQuery();
            GROUPID = conn.GetFieldValue(0, 0);

            conn.QueryString = "SELECT AP_BUSINESSUNIT FROM APPLICATION WHERE AP_REGNO = '" + lbl_regno.Text + "'";
            conn.ExecuteQuery();
            string segment = conn.GetFieldValue(0, 0);

            string[] GROUPIDPAIRLIST = WebConfigurationManager.AppSettings["crpairing-" + segment].ToString().Split(new string[] { "#" }, StringSplitOptions.None);
            string[] GROUPIDPAIRRESULTLIST;
            string GROUPIDPAIR = "";

            //tampilkan review utk groupid yg nggak masuk ke crpairing
            bool viewrev = false;

            if ((GROUPIDPAIRLIST.Length > 0) & (GROUPIDPAIRLIST[0] != ""))
            {
                for (int i = 0; i < GROUPIDPAIRLIST.Length; i++)
                {
                    GROUPIDPAIR = GROUPIDPAIRLIST[i];
                    GROUPIDPAIRRESULTLIST = GROUPIDPAIR.Split(new string[] { "-" }, StringSplitOptions.None);

                    //BU
                    if (GROUPID == GROUPIDPAIRRESULTLIST[0].ToString())
                    {
                        IsReadyToApproved(segment);
                        viewrev = true;
                        break;
                    }
                    //RISK
                    else if (GROUPID == GROUPIDPAIRRESULTLIST[1].ToString())
                    {
                        IsReadyToApprovedCR(segment);
                        Button1.Click += new EventHandler(Button1_Click);
                        viewrev = true;
                        break;
                    }
                }
            }

            if (viewrev == false)
            {
                //Tampilkan semua review
                conn.QueryString = "SELECT NIP, COMMENT, AP_REGNO, SU_FULLNAME FROM PUNDI_CR_PAIR WHERE AP_REGNO = '" + lbl_regno.Text + "'";
                conn.ExecuteQuery();

                int k = 0;
                if (conn.GetRowCount() > 0)
                {
                    //creatingTableNote("", 1, "");
                    for (int i = 0; i < conn.GetRowCount(); i++)
                    {
                        creatingTableNote(conn.GetFieldValue(i, 3) + "-" + conn.GetFieldValue(i, 0), i.ToString(), conn.GetFieldValue(i, 1), true);
                        k = i;
                    }
                }
            }
        }

        void Button1_Click(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)this.FindControl("textbox" + lbl_userid.Text);

            if (tb.Text.Trim() == "")
            {
                GlobalTools.popMessage(this, "Comment Review Harus Diisi !");
            }
            else
            {
                conn.QueryString = "SELECT SU_FULLNAME FROM SCUSER WHERE USERID = '" + lbl_userid.Text + "'";
                conn.ExecuteQuery();

                string name = conn.GetFieldValue(0,0);

                conn.QueryString = "EXEC [PUNDI_CR_COVENANT] '" + lbl_userid.Text + "','" + tb.Text + "','" + lbl_regno.Text + "','" + name + "'";
                conn.ExecuteQuery();

                GlobalTools.popMessage(this, "Comment Review Berhasil Disimpan !");
            }
        }

        private void creatingTableNote(string from, string index, string text, bool isreadonly)
        {
            /*
            <tr>
				<td class="tdHeader1" style="WIDTH: 910px" width="910"><b>Note From</b></td>
			</tr>
			<tr>
				<td style="WIDTH: 910px; HEIGHT: 76px" vAlign="top">
					<P><asp:textbox onkeypress="return kutip_satu()" id="Textbox1" Width="991px" Runat="server" Height="97px"
							TextMode="MultiLine"></asp:textbox></P>
				</td>
			</tr>
             */

            tableNote.Width = "100%";

            TextBox tb;
            System.Web.UI.HtmlControls.HtmlTableRow TR;
            System.Web.UI.HtmlControls.HtmlTableCell TD;

            TR = new HtmlTableRow();
            TD = new HtmlTableCell();
            TD.Attributes.Add("class", "tdHeader1");
            TD.Attributes.Add("width", "910px");
            TD.InnerHtml = "<b>Covenant From " + from + "</b>";
            TR.Cells.Add(TD);

            tableNote.Rows.Add(TR);

            TR = new HtmlTableRow();
            TD = new HtmlTableCell();
            TD.Attributes.Add("style", "WIDTH: 910px; HEIGHT: 76px");
            TD.Attributes.Add("vAlign", "top");

            tb = new TextBox();
            tb.Attributes.Add("onkeypress", "return kutip_satu()");
            tb.Width = new Unit(100, UnitType.Percentage);
            tb.Height = 97;
            tb.ID = "textbox" + index.ToString();
            tb.TextMode = TextBoxMode.MultiLine;
            tb.CssClass = "mandatory";
            tb.ReadOnly = isreadonly;
            tb.Text = text;
            TD.Controls.Add(tb);
            TR.Cells.Add(TD);

            tableNote.Rows.Add(TR);
        }

        //RISK
        private void IsReadyToApprovedCR(string segment)
        {
            //cek udah diisi belum ama CR pairingnya
            conn.QueryString = "SELECT NIP, COMMENT, AP_REGNO, SU_FULLNAME FROM PUNDI_CR_PAIR WHERE AP_REGNO = '" + lbl_regno.Text + "' AND NIP <> '" + lbl_userid.Text + "'";
            conn.ExecuteQuery();

            int k = 0;
            if (conn.GetRowCount() > 0)
            {
                //creatingTableNote("", 1, "");
                for (int i = 0; i < conn.GetRowCount(); i++)
                {
                    creatingTableNote(conn.GetFieldValue(i, 3) + "-" + conn.GetFieldValue(i, 0), i.ToString(), conn.GetFieldValue(i, 1), true);
                    k = i;
                }
            }

            string comment = "";

            conn.QueryString = "SELECT COMMENT FROM PUNDI_CR_PAIR WHERE NIP = '" + lbl_userid.Text + "' AND AP_REGNO = '" + lbl_regno.Text + "'";
            conn.ExecuteQuery();

            try
            {
                comment = conn.GetFieldValue(0, 0);
            }
            catch
            {
                comment = "";
            }

            creatingTableNote(lbl_userid.Text, lbl_userid.Text, comment, false);

            lbl_warning.Visible = false;
            rows_warning.Visible = true;
            DECISION_PANEL.Visible = false;
            cbList.Visible = false;
            trDecision.Visible = false;
            header.Visible = false;
            Button1.Visible = true;
        }

        //BU
        private void IsReadyToApproved(string segment)
        {
            //ambil NIP CR PAIR DARI USER INI
            //BPSMCR, BPMCCR

            conn.QueryString = "SELECT SCUSER.GROUPID, SCUSER.SU_BRANCH, RFBRANCH.CBC_CODE, RFBRANCH.AREAID FROM SCUSER, RFBRANCH " +
                "WHERE SCUSER.USERID = '" + lbl_userid.Text + "' " +
                "AND SCUSER.SU_BRANCH = RFBRANCH.BRANCH_CODE ";
            conn.ExecuteQuery();

            string GROUPID = conn.GetFieldValue(0, 0);
            string SUBRANCH = conn.GetFieldValue(0, 1);
            string CBCCODE = conn.GetFieldValue(0, 2);
            string AREAID = conn.GetFieldValue(0, 3);

            string[] GROUPIDPAIRLIST = WebConfigurationManager.AppSettings["crpairing-" + segment].ToString().Split(new string[] { "#" }, StringSplitOptions.None);
            string GROUPIDPAIRRESULT = "";
            string[] GROUPIDPAIRRESULTLIST;
            string GROUPIDPAIR = "";
            string[] GROUPIDPAIRRESULTLOOP;
            List<string> myList = new List<string>();

            if ((GROUPIDPAIRLIST.Length > 0) & (GROUPIDPAIRLIST[0] != ""))
            {
                for (int i = 0; i < GROUPIDPAIRLIST.Length; i++)
                {
                    GROUPIDPAIR = GROUPIDPAIRLIST[i];
                    GROUPIDPAIRRESULTLIST = GROUPIDPAIR.Split(new string[] { "-" }, StringSplitOptions.None);

                    if (GROUPID == GROUPIDPAIRRESULTLIST[0].ToString())
                    {
                        GROUPIDPAIRRESULT = GROUPIDPAIRRESULTLIST[1].ToString();
                        //break;
                        myList.Add(GROUPIDPAIRRESULT);
                    }
                }
            }

            GROUPIDPAIRRESULTLOOP = myList.ToArray();

            //Tampilkan semua review
            conn.QueryString = "SELECT NIP, COMMENT, AP_REGNO, SU_FULLNAME FROM PUNDI_CR_PAIR WHERE AP_REGNO = '" + lbl_regno.Text + "'";
            conn.ExecuteQuery();

            int k = 0;
            if (conn.GetRowCount() > 0)
            {
                //creatingTableNote("", 1, "");
                for (int i = 0; i < conn.GetRowCount(); i++)
                {
                    creatingTableNote(conn.GetFieldValue(i, 3) + "-" + conn.GetFieldValue(i, 0), i.ToString(), conn.GetFieldValue(i, 1), true);
                    k = i;
                }
            }

            //Loop buat cek apakah masing-masing group pairing sudah input review atau belum
            int mustreviewcount = GROUPIDPAIRRESULTLOOP.Length;
            int reviewcount = 0;
            string tempgroupid = "";

            for (int i = 0; i < GROUPIDPAIRRESULTLOOP.Length; i++)
            {
                conn.QueryString = "SELECT 1 FROM PUNDI_CR_PAIR A JOIN SCUSER B ON A.NIP = B.USERID WHERE A.AP_REGNO = '" + lbl_regno.Text + "' AND B.GROUPID = '" + GROUPIDPAIRRESULTLOOP[i] + "'";
                conn.ExecuteQuery();

                if (conn.GetRowCount() > 0)
                {
                    reviewcount++;
                }
                else
                {
                    tempgroupid = GROUPIDPAIRRESULTLOOP[i];
                }
            }

            if (reviewcount == mustreviewcount)
            {
                DECISION_PANEL.Visible = true;
                cbList.Visible = true;
                trDecision.Visible = true;
                header.Visible = true;
                rows_warning.Visible = false;
                Button1.Visible = false;
            }
            else
            {
                conn.QueryString = "SELECT SG_GRPNAME FROM SCGROUP WHERE GROUPID = '" + tempgroupid + "'";
                conn.ExecuteQuery();

                if (conn.GetRowCount() > 0)
                {
                    string GROUPNAME = conn.GetFieldValue(0, 0);
                    lbl_warning.Text = "APPROVAL SEDANG MENUNGGU PROSES REVIEW DARI " + GROUPNAME + "";
                }

                rows_warning.Visible = true;
                DECISION_PANEL.Visible = false;
                cbList.Visible = false;
                trDecision.Visible = false;
                header.Visible = false;
                Button1.Visible = false;
            }
        }

		private void fillAcquireInformation() 
		{			
			try 
			{
				conn.QueryString = "select AP_ACQINFO, isnull(AP_ACQINFOBY,'') as AP_ACQINFOBY from APPLICATION where AP_REGNO = '" + lbl_regno.Text + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			txt_acqinfo.Text = conn.GetFieldValue("ap_acqinfo");

			///////////////////////////////////////////////////////////////////////////
			///	Kalau User Login adalah BU dan Acquire Info dari CRM, 
			///	maka munculkan informasi CRM tersebut
			///	
			//if (Session["GroupID"].ToString().StartsWith("01")) 
			if (var_groupid.StartsWith("01")) 
			{
				if (conn.GetFieldValue("AP_ACQINFOBY") != "") 
				{
					TR_INFO_CRM.Visible = true;
				}
			}
			///////////////////////////////////////////////////////////////////////////			
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

		/// <summary>
		/// This function check whether the user can approve the application or not
		/// comparing the user's approval limit and the application's limit
		/// </summary>
		/// <param name="userid"></param>
		/// <returns></returns>
		private bool isCanApprove(string userid) 
		{
			double LIMIT;
			bool canApprove = false;

			conn.QueryString = "select * from VW_APPROVALUSER where USERID = '" + userid + "'";
			conn.ExecuteQuery();

			/// Get user approval limit
			/// 
			try {
				LIMIT = Convert.ToDouble(conn.GetFieldValue("userlimit"));
			} 
			catch { LIMIT = 0; }			
			

			/// sebelum cek limit, cek dulu apakah group tersebut ada di hardcode (direktur banking)
			/// 

			/// kalau user tersebut adalah direktur banking, maka user tersebut boleh approve
			/// (tidak perlu cek limit)
			/// 
			if (this.isDirekturBanking(userid)) 
			{
				/// Boleh approve !
				/// 
				canApprove = true;
			}
			else
			{
				/// kalau user tersebut bukan direktur banking, maka cek limit
				/// 
				if (LIMIT >= var_limitexp)
				{
					/// Boleh approve
					/// 
					canApprove = true;
				}
			}

			return canApprove;
		}

		private bool isCanApprove2(string userid) 
		{
			bool canApprove = false;

			conn.QueryString = "exec APPROVAL_ISCANAPPROVE2 '" + Request.QueryString["regno"] + "', '" + userid + "'";
			conn.ExecuteQuery(300);

			if (conn.GetRowCount() > 0)
				if (conn.GetFieldValue("ISCANAPPROVE") == "1")
					canApprove = true;

			return canApprove;
		}

		private void InitializeEvent()
		{
			this.BTN_BACK.Click += new System.Web.UI.ImageClickEventHandler(this.BTN_BACK_Click);
			this.btn_pprk.Click += new System.EventHandler(this.btn_pprk_Click);
			this.btn_appeal.Click += new System.EventHandler(this.btn_appeal_Click);
			this.btn_fwdrej.Click += new System.EventHandler(this.btn_fwdrej_Click);
			this.btn_fwdrisk.Click += new System.EventHandler(this.btn_fwdrisk_Click);
			this.btn_aprvrej.Click += new System.EventHandler(this.btn_aprvrej_Click);
			this.btn_reject.Click += new System.EventHandler(this.btn_aprvrej_Click);
			this.btn_info.Click += new System.EventHandler(this.btn_info_Click);
			this.btn_backtover.Click += new System.EventHandler(this.btn_backtover_Click);
			this.btn_decision.Click += new System.EventHandler(this.btn_decision_Click);
			this.TXT_VERIFY.TextChanged += new EventHandler(TXT_VERIFY_TextChanged);
			this.TXT_TEMP.TextChanged += new EventHandler(TXT_TEMP_TextChanged);
			this.BTN_PROJECTLIST.Click +=new EventHandler(BTN_PROJECTLIST_Click);
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

		private void viewdata()
		{
			#region initialize_page
			lbl_regno.Text	 = Request.QueryString["regno"];
			lbl_curef.Text	 = Request.QueryString["curef"];
			lbl_prod.Text	 = Request.QueryString["prod"];
			lbl_apptype.Text = Request.QueryString["apptype"];
			LBL_PROD_SEQ.Text = Request.QueryString["prod_seq"];
			lbl_track.Text	 = Request.QueryString["tc"];
			lbl_userid.Text	 = Session["USERID"].ToString();
			mc.Text			 = Request.QueryString["mc"];
			//groupid			 = Session["GROUPID"].ToString();
			groupid			 = var_groupid;

			////////////////////////////////////////////////
			/// Mengambil aproval user BU terakhir
			conn.QueryString = "select ap_aprvuntil from application where ap_regno = '" + lbl_regno.Text + "'";
			conn.ExecuteQuery();
			lbl_aprvuntil.Text  = conn.GetFieldValue("ap_aprvuntil");

			//initial
			conn.QueryString	= "select * from rfinitial";
			conn.ExecuteQuery();
			dt_init				= conn.GetDataTable().Copy();
			var_approve			= dt_init.Rows[0]["in_approve"].ToString();
			/*****************************************************************
			 * By Fajar
			 * 20 April 2006
			 * Desc : application has 2 'jenis pengajuan' 
			 *		  1. if one of JP rejected then dispose
			 *		  2. if all JP rejected then move to sppk reject letter
			*/
			var_reject			= dt_init.Rows[0]["in_reject"].ToString();//Reject
			var_reject1			= dt_init.Rows[0]["in_TrckReject"].ToString();//Dispose
			/******************************************************************/
			var_cancelcust		= dt_init.Rows[0]["in_cancelcust"].ToString();
			var_cancelbank		= dt_init.Rows[0]["in_cancelbank"].ToString();
			var_prrk			= dt_init.Rows[0]["in_prrk"].ToString();
			var_lineamount		= double.Parse(dt_init.Rows[0]["in_lineamount"].ToString());
			var_kreditbaru		= dt_init.Rows[0]["in_kreditbaru"].ToString();
			var_ubahjaminan		= dt_init.Rows[0]["in_ubahjaminan"].ToString();
			var_ubahlimit		= dt_init.Rows[0]["in_ubahlimit"].ToString();
			var_renewal			= dt_init.Rows[0]["in_renewal"].ToString();
			var_ubahsyarat		= dt_init.Rows[0]["in_ubahsyarat"].ToString();
			var_smlminappeal	= double.Parse(dt_init.Rows[0]["in_smlminappeal"].ToString());
			var_smlmaxappeal	= double.Parse(dt_init.Rows[0]["in_smlmaxappeal"].ToString());
			var_sgprrk			= dt_init.Rows[0]["in_sgprrk"].ToString();
			var_small			= dt_init.Rows[0]["in_small"].ToString();
			var_middle			= dt_init.Rows[0]["in_middle"].ToString();
			var_corp			= dt_init.Rows[0]["in_corporate"].ToString();
			var_crg				= dt_init.Rows[0]["in_crg"].ToString();
			var_micro			= dt_init.Rows[0]["in_micro"].ToString();
			var_accept			= dt_init.Rows[0]["in_accept"].ToString();
			var_greyzone		= dt_init.Rows[0]["in_greyzone"].ToString();
			var_decline			= dt_init.Rows[0]["in_decline"].ToString();
			var_inbranch		= dt_init.Rows[0]["in_branchpusat"].ToString();
		
			//Get Applicant Product
			conn.QueryString = "select * from vw_currtrack "+
							   " where ap_regno = '"+lbl_regno.Text+"' ";
			conn.ExecuteQuery();
			DataTable dt_currtrack = new DataTable();
			dt_currtrack		   = conn.GetDataTable().Copy();

			int row = dt_currtrack.Rows.Count;
			int rowtemp = row;
			int no;
			int cbl_prod_count = 0;
			int cbl_prodrej_count = 0;
			for (int i = 0; i < row; i++)
			{
				if(!IsPostBack)
				{
					conn.QueryString = "select * from approval_decision "+
										" where ap_regno = '"+lbl_regno.Text+
										"' and productid = '"+dt_currtrack.Rows[i]["productid"].ToString()+
										"' and apptype = '"+dt_currtrack.Rows[i]["apptype"].ToString()+
										"' and PROD_SEQ = '" + dt_currtrack.Rows[i]["PROD_SEQ"].ToString() + "' " +
										" and ad_seq = (select max(ad_seq) from approval_decision ad where approval_decision.ap_regno = ad.ap_regno and approval_decision.productid = ad.productid and approval_decision.apptype = ad.apptype) ";
					conn.ExecuteQuery();
					/* if ((conn.GetFieldValue("ad_reject") == "1") && (groupid.Substring(0,2) != "01")) */
					if (conn.GetFieldValue("ad_reject") == "1")
					{
						//cbl_prod.Items[i].Selected = false;
						cbl_prodrej.Items.Add(new ListItem(dt_currtrack.Rows[i]["prodapptype"].ToString(), dt_currtrack.Rows[i]["prodapptypecode"].ToString()));
						cbl_prodrej.Items[cbl_prodrej_count].Selected = false;
						cbl_prodrej.Enabled = false;
						cbl_prodrej_count++;
					}
					else if (conn.GetFieldValue("ad_reject") == "0")
					{
						cbl_prod.Items.Add(new ListItem(dt_currtrack.Rows[i]["prodapptype"].ToString(), dt_currtrack.Rows[i]["prodapptypecode"].ToString()));
						cbl_prod.Items[cbl_prod_count].Selected = true;
						cbl_prod_count++;
					}
					else 
					{
						cbl_prod.Items.Add(new ListItem(dt_currtrack.Rows[i]["prodapptype"].ToString(), dt_currtrack.Rows[i]["prodapptypecode"].ToString()));
						cbl_prod_count++;
					}
				}
				
				string queryLink = "";
				string l_prod		= dt_currtrack.Rows[i]["productid"].ToString();
				string l_apptype	= dt_currtrack.Rows[i]["apptype"].ToString();
				string l_prod_seq	= dt_currtrack.Rows[i]["prod_seq"].ToString();
				string _ket_code	= dt_currtrack.Rows[i]["ket_code"].ToString();

				if (lbl_prod.Text.Trim() == "") lbl_prod.Text = l_prod;
				if (lbl_apptype.Text.Trim() == "") lbl_apptype.Text = l_apptype;
				if (LBL_PROD_SEQ.Text.Trim() == "") LBL_PROD_SEQ.Text = l_prod_seq;

				HyperLink prod	 = new HyperLink();
				no = i+1;
				prod.Text = no.ToString() +". "+dt_currtrack.Rows[i]["prodapptype"].ToString();
				prod.CssClass	 = "TDBGColor1";
				prod.Font.Bold	 = true;

				if (l_apptype == "01") //Permohonan Baru 
				{
					conn.QueryString = "select iscashloan from rfproduct where productid='" + l_prod + "'";
					conn.ExecuteQuery();
					if (conn.GetFieldValue(0,0) == "0")	//Non Cash Loan
						queryLink = "select screenlink from apptypelink where APPTYPEID = '"+ l_apptype + "' and fungsiId='APPRV' and iscashloan='0'";
					else	// Cash Loan
						queryLink = "select screenlink from apptypelink where APPTYPEID = '"+ l_apptype + "' and fungsiId='APPRV' and iscashloan='1'";
				}
				else //Non Permohonan Baru
				{
					queryLink = "select screenlink from apptypelink where APPTYPEID = '"+ l_apptype + "' and fungsiId='APPRV' ";
				}

				try 
				{
					conn.QueryString = queryLink;
					conn.ExecuteQuery();
				} 
				catch (NullReferenceException) 
				{
					GlobalTools.popMessage(this, "Connection Error!");
					Response.Redirect("../Login.aspx?expire=1");
				}				

				//prod.NavigateUrl = conn.GetFieldValue("screenlink") + "?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text+"&prod="+l_prod+"&apptype="+l_apptype+"&mc="+mc.Text+"&prod_seq=" + l_prod_seq + "&sta=view&teks=" + prod.Text;

				prod.NavigateUrl = conn.GetFieldValue("screenlink") + "?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text+"&prod="+l_prod+"&apptype="+l_apptype+"&mc="+mc.Text+"&prod_seq=" + l_prod_seq + "&teks=" + prod.Text + "&ket_code=" + _ket_code;
				prod.Target		 = "if2";

				/***
				prod.NavigateUrl = "creditinfo.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text+"&prod="+l_prod+"&apptype="+l_apptype+"&mc="+mc.Text+"&sta=view";
				prod.Target		 = "if2";
				***/

				this.tbl_prod.Rows.Add(new TableRow());
				this.tbl_prod.Rows[i].Cells.Add(new TableCell());
				this.tbl_prod.Rows[i].Cells[0].Controls.Add(prod);				
			}

			conn.ClearData();
	

			//Get Credit Info Data
			conn.QueryString		= "select * from vw_approvalinfo where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();
			
			txt_roa.Text			= conn.GetFieldValue("pr_roa");
			txt_roe.Text			= conn.GetFieldValue("pr_roe");
			txt_netprofit.Text		= conn.GetFieldValue("pr_netprofitmargin");
			txt_roi.Text			= conn.GetFieldValue("pr_roi");
			txt_networth.Text		= conn.GetFieldValue("pr_networth");
			txt_jual.Text			= conn.GetFieldValue("pr_penjualan");
			txt_laba.Text			= conn.GetFieldValue("pr_lababersih");
			txt_der.Text			= conn.GetFieldValue("pr_debtequity");
			txt_totakt.Text			= conn.GetFieldValue("pr_totalaktiva");
			txt_colcov.Text			= conn.GetFieldValue("pr_collateralcov");
			txt_curratio.Text		= conn.GetFieldValue("pr_currentratio");
			txt_dsc.Text			= conn.GetFieldValue("pr_debtservice");
			txt_cashvel.Text		= conn.GetFieldValue("pr_cashvelocity");
			txt_dayrec.Text			= conn.GetFieldValue("pr_daysreceivable");
			txt_dayinv.Text			= conn.GetFieldValue("pr_daysinventory");
			txt_dayaccpay.Text		= conn.GetFieldValue("pr_daysaccountpay");
			txt_trade.Text			= conn.GetFieldValue("pr_tradecycle");
			txt_totaset.Text		= conn.GetFieldValue("pr_totalasset");
			txt_labakotor.Text		= conn.GetFieldValue("pr_labakotor");
			txt_biayaadm.Text		= conn.GetFieldValue("pr_biayaadm");
			#endregion

			conn.QueryString = "select ap_isappeal, ap_complevel, isnull(limitexposure,0) limitexposure, "+
							   " application.branch_code, application.areaid, cbc_code, ap_aprvremark from application "+
							   " left join customer on application.cu_ref = customer.cu_ref "+
							   " left join rfbranch on application.branch_code = rfbranch.branch_code "+
				               " where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();

			var_appeal		= conn.GetFieldValue("ap_isappeal");
			var_complevel	= conn.GetFieldValue("ap_complevel");
			var_appbranch	= conn.GetFieldValue("branch_code");
			var_area		= conn.GetFieldValue("areaid");
			var_cbc			= conn.GetFieldValue("cbc_code");	
			if (txt_remark.Text == "")
				txt_remark.Text	= conn.GetFieldValue("ap_aprvremark");			
			else
				txt_remark.Text = txt_remark.Text;
	
			/// Menghitung Limit Exposure : Aplikasi, Nasabah dan Group
			/// 
			conn.QueryString = "exec DE_CALCULATE_TOTALEXPOSURE '" + lbl_regno.Text + "', '" + lbl_curef.Text + "'";
			conn.ExecuteQuery(300);
			dt_aprvdec = conn.GetDataTable().Copy();
			if (dt_aprvdec.Rows.Count > 0)
			{
				lbl_limexp.Text		= tool.MoneyFormat(Convert.ToString(conn.GetFieldValue("GROUP_EXPOSURE")));
				lbl_reqlim.Text		= tool.MoneyFormat(conn.GetFieldValue("tot_limit"));

				try { var_limitexp = Convert.ToDouble(conn.GetFieldValue("GROUP_EXPOSURE")); } 
				catch {}
			}

			tr_appeal.Visible = false;

			/* if (groupid.Substring(0,2) == "01")	// BU */
			if (1==1)	// BU
			{
				btn_info.Visible	 = false;
				tr_prrk.Visible		 = false;
				ddl_aprvwith.Enabled = false;

				////
				/// kalau application is appeal, dan current login is BU
				/// maka hide button approve
				/// 
				#region button_control_for_appeal
				if (var_appeal == "1")
				{					
					tr_approve.Visible = false;
					
					//////////////////////////////////////////////////////////
					/// kalau application is appeal, dan current login (BU)
					/// adalah approval user terakhir, maka
					/// unhide appeal button
					/// 
					/// Rule Tambahan : kalau approval user terakhir adalah regional manager,
					/// appeal button di-hide
					/// 
					if (lbl_userid.Text == lbl_aprvuntil.Text) 
					{					
						/// Mengambil group Regional Manager dari hardcode table
						/// 
						//conn.QueryString = "select groupid from scgroup_init2 where gr_key like '%AREA_MGR%' and groupid = '" + Session["GroupID"] + "'";
						conn.QueryString = "select groupid from scgroup_init2 where gr_key like '%AREA_MGR%' and groupid = '" + var_groupid + "'";
						conn.ExecuteQuery();

						if (conn.GetRowCount() == 0) 
						{
							tr_appeal.Visible = true;
						}
						else 
						{
							tr_approve.Visible = true;
						}
					}
					else 
					{
						tr_appeal.Visible = false;
					}
				}
				else if (var_appeal == "0")
				{
					tr_appeal.Visible = false;
				}
				#endregion
			}
			else if (groupid.Substring(0,2) == "02")	// RM
			{
				conn.QueryString="SELECT * FROM ALLOW_ACQUIRE_INFORMATION WHERE AP_REGNO = '" + Request.QueryString["regno"] +"'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue("ALLOWACQINFO") == "0")
				{
					btn_info.Visible	 = false;
				}
				btn_backtover.Visible= false;
				tr_appeal.Visible = false;
			}

			rb_auto.Visible = false;
			rb_auto.Checked = false;
			rb_manual.Checked = true;

			//Get DropDownList Data
			//reject reason			
			if(!IsPostBack)
			{
				#region Build_RejectPicklist
				ddl_rjreason.Items.Add(new ListItem("-- Pilih --",""));
				conn.QueryString = "select REASONID, REASONTYPE, REASONID + ' - ' + REASONDESC AS REASONDESC, ACTIVE from RFREASON where reasontype = '0' and active = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount();i++)
					ddl_rjreason.Items.Add(new ListItem(conn.GetFieldValue(i,2),conn.GetFieldValue(i,0)));

				conn.QueryString = "select * from reject_cancel "+
								   " where ap_regno = '"+lbl_regno.Text+"' "+
								   " and rcanceldate = (select max(rcanceldate) from reject_cancel rc where reject_cancel.ap_regno = rc.ap_regno)";
				conn.ExecuteQuery();
				if (conn.GetRowCount() != 0)
				{
					try{ddl_rjreason.SelectedValue = conn.GetFieldValue("reasonid");}
					catch{}
					txt_rjreason.Text		   = conn.GetFieldValue("rejecttext");
				}
				#endregion
			
				#region prrk picklist
				//prrk
				//conn.QueryString = "select * from vw_approvaluser where userid = '"+lbl_userid.Text+"' ";
				conn.QueryString = "select * from vw_approvaluser where userid = '" + var_user + "' ";
				conn.ExecuteQuery();			
				ddl_prrk.Items.Add(new ListItem(conn.GetFieldValue("userfullnm"),conn.GetFieldValue("userid")));

				string grouptemp, sgdown;
				//grouptemp = Session["GROUPID"].ToString();
				grouptemp = var_groupid;
				sgdown = "(";
				string koma = "";
				int iii=0;
				while (grouptemp != "" && iii <= 15) 
				{
					iii++;
					if (var_complevel == var_small)			// small
					{
						conn.QueryString = "select distinct groupid from vw_approvaluser where smlupgroup = '"+grouptemp+"'"+
							" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
							" and su_active = '1' ";
					}
					else if (var_complevel == var_middle)	// middle
					{
						conn.QueryString = "select distinct groupid from vw_approvaluser where midupgroup = '"+grouptemp+"'"+
							" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
							" and su_active = '1' ";
					}
					else if (var_complevel == var_corp)		// corporate
					{
						conn.QueryString = "select distinct groupid from vw_approvaluser where corupgroup = '"+grouptemp+"'"+
							" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
							" and su_active = '1' ";
					}
					else if (var_complevel == var_crg)		// credit recovery
					{
						conn.QueryString = "select distinct groupid from vw_approvaluser where crgupgroup = '"+grouptemp+"'"+
							" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
							" and su_active = '1' ";
					}
					else if (var_complevel == var_micro)	// micro
					{
						conn.QueryString = "select distinct groupid from vw_approvaluser where mcrupgroup = '"+grouptemp+"'"+
							" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
							" and su_active = '1' ";
					}

					conn.ExecuteQuery();

					if (conn.GetRowCount() == 0)
						grouptemp = "";
				
					for (int i = 0; i < conn.GetRowCount();i++)
					{
						if (conn.GetFieldValue(i,"groupid") != "")
						{
							sgdown = sgdown + koma + "'"+conn.GetFieldValue(i,"groupid")+"'";	
							koma = ",";
						}
						grouptemp = conn.GetFieldValue(i,"groupid");				
					}
				}
				if (sgdown == "(")
					sgdown = sgdown + "''";
				sgdown = sgdown + ")";
			
				conn.QueryString = "select * from vw_approvaluser where (groupid in "+sgdown+" "+
					" or groupid = '"+var_sgprrk+"') "+
					" and (usercbc = '"+var_cbc+"' or userbranch =  '"+var_inbranch+"') "+
					" and su_active = '1' ";
				conn.ExecuteQuery();

				//ddl_prrk.Items.Add(new ListItem(lbl_userid.Text));
				for (int i = 0; i < conn.GetRowCount();i++)
					ddl_prrk.Items.Add(new ListItem(conn.GetFieldValue(i,2),conn.GetFieldValue(i,0)));
				#endregion

				#region Forward_name_Picklist
				//forward manual 
				
				#endregion

				//--- Mengisi Approval user manual
				#region non_withdrawal
				{	
					//string USERID = (string) Session["UserID"];
					string USERID = (string) var_user;
					string UPLINER = USERID;
					string FULLNAME = "";
					double LIMIT = 0;
					int ii = 0;

					conn.QueryString = "select count(*) as others from custproduct where  apptype in ( '01','02','03','04','05') and ap_regno = '" + Request.QueryString["regno"] + "'" ;
					conn.ExecuteQuery();
					int count = Convert.ToInt32(conn.GetFieldValue("others"));
					if(count==0){ var_limitexp = 0;}

					conn.QueryString = "EXEC APPROVAL_FILLDDLMANUAL '" + Request.QueryString["regno"] + "', '" + Session["UserID"].ToString() + "'";
					conn.ExecuteQuery(300);

					string fwdriskmode = conn.GetFieldValue("FWDRISKMODE");
					string riskunitname = conn.GetFieldValue("RISKUNITNAME");

					if (fwdriskmode == "0")
					{
						tr_fwdmanual.Visible = true;
						tr_fwdrisk.Visible = false;
					}
					else if (fwdriskmode == "1")
					{
						tr_fwdmanual.Visible = false;
						tr_fwdrisk.Visible = true;
					}
					else
					{
						tr_fwdmanual.Visible = false;
						tr_fwdrisk.Visible = false;
					}

					for (int i = 0; i < conn.GetRowCount();i++)
					{
						ddl_manual.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
					}

					LBL_RISKUNITNAME.Text = riskunitname;
				}
				#endregion

				#region Approval_With_Picklist
				//Approve With
				conn.QueryString = "select userid, su_fullname from scuser where userid = '" + Session["UserID"].ToString() + "' ";
				conn.ExecuteQuery();			
				ddl_aprvwith.Items.Add(new ListItem(conn.GetFieldValue("su_fullname"),conn.GetFieldValue("userid")));
				
				#endregion
				////////////////////////////////////////////////////////////
				///	FILL APPEAL USER
				///	
				#region HardCode_RegionManager_No_Rules_Apply (Only Appeal )
				////
				///	REGIONAL MANAGER
				///	
				//conn.QueryString = "select arearegmanager, su_fullname from rfarea left join scuser on rfarea.arearegmanager = scuser.userid "+
				//				   " where areaid = '"+var_area+"' and  active = '1'";
				conn.QueryString = "select userid, su_fullname from scuser " +
								   " left join scgroup_init2 init2 on init2.groupid = scuser.groupid "+
								   " left join rfbranch on rfbranch.branch_code = scuser.su_branch " +
								   " where areaid = '"+var_area+"' and  active = '1' and init2.GR_KEY like '%AREA_MGR%'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount();i++)
				{
					ddl_appeal.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
				}
				#endregion

				////
				/// MITRA RM
				/// 
//				conn.QueryString = "select * from vw_approvaluser where groupid = '"+Session["GroupID"].ToString()+"' "+
//								   " and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') and su_active = '1'";

				#region Continue_Appeal_Picklist
				conn.QueryString = "select u.su_mitrarm, u2.su_fullname from scuser u " + 
					"inner join scuser u2 on u.su_mitrarm = u2.userid where u.userid = '" + var_user + "'";
				conn.ExecuteQuery();
				string var_mitrarm = conn.GetFieldValue("su_mitrarm");
				ddl_appeal.Items.Add(new ListItem(conn.GetFieldValue("su_fullname"),conn.GetFieldValue("su_mitrarm")));

				

				for (int ii=0; ii< 2; ii++)
				{
					conn.QueryString = "sp_approvaluser_risk '" + var_mitrarm + "', '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();					

					if (conn.GetRowCount() > 0) 
					{
						ddl_appeal.Items.Add(new ListItem(conn.GetFieldValue("fullname"),conn.GetFieldValue("upliner")));
						var_mitrarm = conn.GetFieldValue("upliner");
					}					
				}

				//sgmitra	= conn.GetFieldValue("mitragroup");
				/*
				conn.QueryString = "select * from vw_approvaluser where groupid = '"+sgmitra+"' "+
								   " and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') and su_active = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount();i++)
				{
					ddl_appeal.Items.Add(new ListItem(conn.GetFieldValue(i,2),conn.GetFieldValue(i,0)));
				}
				*/


				//default value appeal adalah upliner mitra rm BU
//				conn.QueryString = "";
//				conn.ExecuteQuery();
//				try { ddl_appeal.SelectedValue = ""; }
//				catch {}

				////
				///	UPLINER MITRA RM
				///	
				/****
				sgup = "(";
				koma = "";
				while (sgmitra != "") 
				{
					conn.QueryString = "select * from vw_approvaluser where groupid = '"+sgmitra+"' "+
									   " and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') and su_active = '1'";
					conn.ExecuteQuery();

					if (conn.GetRowCount() == 0)
						sgmitra = "";
				
					for (int i = 0; i < conn.GetRowCount();i++)
					{
						if (var_complevel == var_small)
						{
							sgup = sgup + koma + "'"+conn.GetFieldValue(i,"smlupgroup")+"'";	
							koma = ",";
							sgmitra = conn.GetFieldValue(i,"smlupgroup");	
						}
						else if (var_complevel == var_middle)
						{
							sgup = sgup + koma + "'"+conn.GetFieldValue(i,"midupgroup")+"'";	
							koma = ",";
							sgmitra = conn.GetFieldValue(i,"midupgroup");
						}
						else if (var_complevel == var_corp)
						{
							sgup = sgup + koma + "'"+conn.GetFieldValue(i,"corupgroup")+"'";	
							koma = ",";
							sgmitra = conn.GetFieldValue(i,"corupgroup");
						}
					}
				}
	
				if (sgup == "(")
					sgup = sgup + "''";
				sgup = sgup + ")";
			
				conn.QueryString = "select * from vw_approvaluser where userid = '"+lbl_userid.Text+"' ";
				conn.ExecuteQuery();
				double var_appeallimit = double.Parse(conn.GetFieldValue("userlimit"));

				conn.QueryString = "select * from vw_approvaluser where groupid in "+sgup+" "+
					" and userlimit >= " + tool.ConvertFloat(var_appeallimit.ToString()) + " "+	
					" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
					" and su_active = '1' ";
				conn.ExecuteQuery();

				for (int i = 0;	i < conn.GetRowCount();i++)
				{
					ddl_appeal.Items.Add(new ListItem(conn.GetFieldValue(i,2),conn.GetFieldValue(i,0)));
				}
				***/
				////////////////////////////////////////////////////////////
				
				
				////////////////////////////////////////////////////////////////////////////////////
				///	SET APPEAL USER DEFAULT KE UPLINER MITRA
				///	
				conn.QueryString = "select * " + 
					"from VW_APPROVAL_UPLINERMITRA where AP_REGNO = '" + lbl_regno.Text + "'";
				conn.ExecuteQuery();

				if (conn.GetFieldValue("AP_BUSINESSUNIT") == var_small) 
				{
					try { ddl_appeal.SelectedValue = conn.GetFieldValue("SU_UPLINER"); }
					catch {}
				}
				else if (conn.GetFieldValue("AP_BUSINESSUNIT") == var_middle) 
				{
					try { ddl_appeal.SelectedValue = conn.GetFieldValue("SU_MIDUPLINER"); }
					catch {}
				}
				else if (conn.GetFieldValue("AP_BUSINESSUNIT") == var_corp)
				{
					try { ddl_appeal.SelectedValue = conn.GetFieldValue("SU_CORUPLINER"); }
					catch {}
				}
				else if (conn.GetFieldValue("AP_BUSINESSUNIT") == var_crg)
				{
					try { ddl_appeal.SelectedValue = conn.GetFieldValue("SU_CRGUPLINER"); }
					catch {}
				}
				else if (conn.GetFieldValue("AP_BUSINESSUNIT") == var_micro)
				{
					try { ddl_appeal.SelectedValue = conn.GetFieldValue("SU_MCRUPLINER"); }
					catch {}
				}
				////////////////////////////////////////////////////////////////////////////////////								
				///
				#endregion
			}
			

		}

		private string getPICApprovalCommitee() 
		{
			try 
			{
				//conn.QueryString = "select isnull(AP_APRVCOMMITEE,'') as AP_APRVCOMMITEE from APPLICATION where AP_REGNO = '" + lbl_regno.Text + "'";
				conn.QueryString = "exec APPROVAL_PIC_APPRVCOMMITEE '" + lbl_regno.Text + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			return conn.GetFieldValue("AP_APRVCOMMITEE");
		}

		private void preAcquireInfo() 
		{
			//
			// mengambil last status approval_decision
			//
			
			conn.QueryString = "select 1 from vw_currtrack where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();
			int cnttrack = conn.GetRowCount();

			conn.QueryString = "select 1 from approval_decision ad where ad.ap_regno = '" + lbl_regno.Text + "' " +
				" and ad.userid = '" + lbl_userid.Text + "' " +
				" and ad.ad_seq = (select max(ad_seq) from approval_decision ad2 " +
				" where ad.ap_regno = ad2.ap_regno and ad.apptype = ad2.apptype and ad.productid = ad2.productid and ad.prod_seq = ad2.prod_seq)";
			conn.ExecuteQuery();
			int cntad = conn.GetRowCount();

			if (cnttrack != cntad)
			{
				GlobalTools.popMessage(this, "Check Approval Structure Credit First!");
				return;
			}


			//
			//	mengisi remark approval
			//
			conn.QueryString = "update application set ap_aprvremark = '"+txt_remark.Text+"' where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();
		}

		//20070725 add by sofyan for new approval routing
		private void fillDdlForward4eyes()
		{
			conn.QueryString = "EXEC APPROVAL_NEWROUTING_FOUREYES_FILLDDLFORWARD '" +
				lbl_regno.Text + "', '" +
				lbl_userid.Text + "', '" +
				groupid + "', '" +
				var_cbc + "', '" +
				var_inbranch + "'";
			Response.Write("<!--"+conn.QueryString+"-->");
			conn.ExecuteQuery();
			ddl_manual.Items.Clear();
			for (int i = 0; i < conn.GetRowCount();i++)
			{
				ddl_manual.Items.Add(new ListItem(conn.GetFieldValue(i,2),conn.GetFieldValue(i,0)));
			}

			conn.QueryString = "EXEC APPROVAL_NEWROUTING_FOUREYES_SELECTDDLFORWARD '" +
				lbl_regno.Text + "', '" +
				lbl_userid.Text + "', '" +
				groupid + "', '" +
				var_cbc + "', '" +
				var_inbranch + "'";
			conn.ExecuteQuery();
			try
			{
				ddl_manual.SelectedValue = conn.GetFieldValue("NEXTUSER");
			}
			catch
			{}
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

		private void btn_decision_Click(object sender, System.EventArgs e)
		{
			//Response.Redirect("ApprovalDecisions.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text+"&prod="+lbl_prod.Text+"&apptype="+lbl_apptype.Text+"&tc="+lbl_track.Text+"&mc="+Request.QueryString["mc"]);
			Response.Redirect("ApprovalHistory.aspx?regno="+ lbl_regno.Text +"&curef="+ lbl_curef.Text +"&tc="+lbl_track.Text+"&mc="+Request.QueryString["mc"]);
		}

		private void approval2()
		{
			string var_eye, var_eye1, var_routingreject;
			
			//Get Approval Group/User
			conn.QueryString = "SELECT AP_APRVNEXTBY, AP_APRVUNTIL FROM APPLICATION WHERE AP_REGNO = '" + lbl_regno.Text + "'";
			conn.ExecuteQuery();
			string var_aprvnextby = conn.GetFieldValue("AP_APRVNEXTBY");
			string var_aprvuntil = conn.GetFieldValue("AP_APRVUNTIL");
			
			try
			{
				conn.QueryString = "EXEC APPROVAL_ROUTING '" + Request.QueryString["regno"] + "', '" + Session["UserID"].ToString() + "'";
				conn.ExecuteQuery(300);

				if (conn.GetRowCount() > 0)
				{
					var_eye = conn.GetFieldValue("var_eye");
					var_eye1 = conn.GetFieldValue("var_eye1");
					LBL_APRV_ROUTING.Text = (var_eye==""?"(undefined)":var_eye) + " eyes";

					var_routingreject = conn.GetFieldValue("var_reject");
					if (var_routingreject == "1")
					{
						tr_approve.Visible = false;
					}
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

			//--- Kalau orang akhir tidak sama dengan orang selanjutnya
			if (var_aprvnextby != var_aprvuntil)
			{
				tr_approve.Visible = false;
				tr_reject.Visible = false;
				tr_reject1.Visible = false;
			}
			else if (var_aprvnextby == var_aprvuntil)
			{
				tr_approve.Visible = true;
				tr_fwdmanual.Visible = false;
				tr_fwdrisk.Visible = false;
			}
		}

		private void btn_fwdrej_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "select 1 from vw_currtrack where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();
			int cnttrack = conn.GetRowCount();

			conn.QueryString = "select 1 from approval_decision ad where ad.ap_regno = '" + lbl_regno.Text + "' " +
				" and ad.userid = '" + lbl_userid.Text + "' " +
				" and ad.ad_seq = (select max(ad_seq) from approval_decision ad2 " +
				" where ad.ap_regno = ad2.ap_regno and ad.apptype = ad2.apptype and ad.productid = ad2.productid and ad.prod_seq = ad2.prod_seq)";
			conn.ExecuteQuery();
			int cntad = conn.GetRowCount();

			if (cnttrack != cntad)
			{
				GlobalTools.popMessage(this, "Check Facilities of Structure Credit First!");
				return;
			}

			if (ddl_manual.SelectedValue == "")
			{
				GlobalTools.popMessage(this, "There is no user to forward!");
				return;
			}

			conn.QueryString = "update application set ap_aprvremark = '"+txt_remark.Text+"' where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();

			string var_userup	= var_user; //lbl_userid.Text;
			string var_groupup	= "";
			string var_trackup	= "";
			string var_username	= "";

			//if (rb_auto.Checked == true)
			if (false )  // to ensure it never hit this part of codes
			{
				#region automatic ( never run )
				//conn.QueryString = "select * from vw_approvaluser where userid = '"+lbl_userid.Text+"'";
				conn.QueryString = "select * from vw_approvaluser where userid = '" + var_user + "'";
				conn.ExecuteQuery();
				if (var_complevel == var_small)
				{
					var_userup  = conn.GetFieldValue("su_upliner");
					var_groupup = conn.GetFieldValue("smlupgroup");
					var_trackup = conn.GetFieldValue("smluptrack");
				}
				else if (var_complevel == var_middle)
				{
					var_userup  = conn.GetFieldValue("su_midupliner");
					var_groupup = conn.GetFieldValue("midupgroup");
					var_trackup = conn.GetFieldValue("miduptrack");
				}
				else if (var_complevel == var_corp)
				{
					var_userup  = conn.GetFieldValue("su_corupliner");
					var_groupup = conn.GetFieldValue("corupgroup");
					var_trackup = conn.GetFieldValue("coruptrack");
				}
				else if (var_complevel == var_crg)
				{
					var_userup  = conn.GetFieldValue("su_crgupliner");
					var_groupup = conn.GetFieldValue("crgupgroup");
					var_trackup = conn.GetFieldValue("crguptrack");
				}
				else if (var_complevel == var_micro)
				{
					var_userup  = conn.GetFieldValue("su_mcrupliner");
					var_groupup = conn.GetFieldValue("mcrupgroup");
					var_trackup = conn.GetFieldValue("mcruptrack");
				}
				
				//--- Added By Yudi (2004-08-26) ---
				if (var_userup == "") 
				{
					GlobalTools.popMessage(this, "User tidak punya upliner !");
					return;
				}
				//----------------------------------				

				//update track
				conn.QueryString = "select * from vw_currtrack where ap_regno = '"+lbl_regno.Text+"'";
				conn.ExecuteQuery();
				DataTable dt_currtrack = new DataTable();
				dt_currtrack = conn.GetDataTable().Copy();
				int CountApp = 0;

				//check if there's any product reject
				for (int i = 0; i < dt_currtrack.Rows.Count;i++) 
				{	
					if (!cbl_prod.Items[i].Selected)
					{
						if (ddl_rjreason.SelectedValue == "")
						{
							GlobalTools.popMessage(this, "Reject Reason should be filled");
							return;
						}
						CountApp++;
					}
				}

				for (int i = 0; i < dt_currtrack.Rows.Count;i++) 
				{
					string var_apptype		= dt_currtrack.Rows[i]["apptype"].ToString();
					string var_prod			= dt_currtrack.Rows[i]["productid"].ToString();
					string var_currtrack	= dt_currtrack.Rows[i]["ap_currtrack"].ToString();
					string PROD_SEQ			= dt_currtrack.Rows[i]["PROD_SEQ"].ToString();
						
					if (cbl_prod.Items[i].Selected)
					{
						conn.QueryString = "exec approval_nexttrack '"+
							lbl_regno.Text+"', '"+
							var_prod+"', '"+
							var_apptype+"', '"+
							lbl_userid.Text+"', '"+
							var_userup+"', '"+
							var_trackup+"', " + 
							"'1', '"+
							var_userup+"', '" + 
							PROD_SEQ + "'";
						conn.ExecuteQuery();
					}
					else
					{
						if(CountApp != dt_currtrack.Rows.Count )
						{
							conn.QueryString = "exec approval_proddecision '"+lbl_regno.Text+"', '"+var_prod+"', '"+var_apptype+"', '"+lbl_userid.Text+"', '0', '"+var_reject1+"', '"+ddl_rjreason.SelectedValue.ToString()+"', '"+txt_rjreason.Text+"', '" + PROD_SEQ + "'";
							conn.ExecuteQuery();
						}
						else
						{
							conn.QueryString = "exec approval_proddecision '"+lbl_regno.Text+"', '"+var_prod+"', '"+var_apptype+"', '"+lbl_userid.Text+"', '0', '"+var_reject+"', '"+ddl_rjreason.SelectedValue.ToString()+"', '"+txt_rjreason.Text+"', '" + PROD_SEQ + "'";
							conn.ExecuteQuery();
						}
					}
				}
				#endregion
			}		
			else
			{
				#region Update_Selected_People_To_Forward_Or_Assign
				////////////////////////////////////////////////////////
				/// mendapatkan groupid corporate yang dihardcode
				/// 
				string corprm_up_id = "";
				string corprm_up_fullname = "";
				string corprm_up_groupid = "";
				string corprm_up_aprvtrack = "";
				DataTable dtCor1, dtCor2;

				int isCorpDeptHead = 0;
				//conn.QueryString = "select * from SCGROUP_INIT2 where GROUPID = '" + Session["GroupID"] + "' and GR_KEY like '%DEPTHEAD%'";
				conn.QueryString = "select * from SCGROUP_INIT2 where GROUPID = '" + var_groupid + "' and GR_KEY like '%DEPTHEAD%'";
				conn.ExecuteQuery();
				dtCor1 = conn.GetDataTable().Copy();
				if (dtCor1.Rows.Count > 0) 
				{
					isCorpDeptHead = 1;
					conn.QueryString = "select * from VW_APPROVAL_CORPRMUPLINER where AP_REGNO = '" + lbl_regno.Text + "'";
					conn.ExecuteQuery();
					dtCor2 = conn.GetDataTable().Copy();					
					if (dtCor2.Rows.Count > 0) 
					{
						corprm_up_id = dtCor2.Rows[0]["SU_CORUPLINER"].ToString();
						corprm_up_fullname = dtCor2.Rows[0]["SU_FULLNAME"].ToString();
						corprm_up_groupid = dtCor2.Rows[0]["GROUPID"].ToString();
						corprm_up_aprvtrack = dtCor2.Rows[0]["SG_APRVTRACK"].ToString();
					}
					dtCor2.Clear();
				}
				dtCor1.Clear();				

				string var_useruntil = ddl_manual.SelectedItem.Value;
				/*** Sofyan 2010-11-05, diganti procedure dibawah
				 * 
				//groupid = Session["GROUPID"].ToString();
				groupid = var_groupid;
				if (groupid.Substring(0,2) == "01")
				{
					//conn.QueryString = "select * from vw_approvaluser where userid = '" + lbl_userid.Text + "'";
					conn.QueryString = "select * from vw_approvaluser where userid = '" + var_user + "'";
					conn.ExecuteQuery();
					if (var_complevel == var_small)
					{
						var_userup	 = conn.GetFieldValue("su_upliner");
						var_username = conn.GetFieldValue("smlupfullnm");
						var_groupup  = conn.GetFieldValue("smlupgroup");
						var_trackup  = conn.GetFieldValue("smluptrack");
					}
					else if (var_complevel == var_middle)
					{
						var_userup   = conn.GetFieldValue("su_midupliner");
						var_username = conn.GetFieldValue("midupfullnm");
						var_groupup  = conn.GetFieldValue("midupgroup");
						var_trackup  = conn.GetFieldValue("miduptrack");
					}
					else if (var_complevel == var_corp)
					{
						// cek dulu apa groupid-nya
						// (1) kalau groupid = DEPTHEAD dan key = DEPTHEAD dalam SCGROUP_INIT2 (sudah diperiksa diatas), maka
						// route ke upliner CORP RM
						// (2) kalau bukan, ikut route seperti biasa
						if (isCorpDeptHead == 1) 
						{
							var_userup = corprm_up_id;
							var_username = corprm_up_fullname;
							var_groupup = corprm_up_groupid;
							var_trackup = corprm_up_aprvtrack;
						}
						else 
						{
							var_userup   = conn.GetFieldValue("su_corupliner");
							var_username = conn.GetFieldValue("corupfullnm");
							var_groupup  = conn.GetFieldValue("corupgroup");
							var_trackup  = conn.GetFieldValue("coruptrack");
						}
					}
					else if (var_complevel == var_crg)
					{
						var_userup   = conn.GetFieldValue("su_crgupliner");
						var_username = conn.GetFieldValue("crgupfullnm");
						var_groupup  = conn.GetFieldValue("crgupgroup");
						var_trackup  = conn.GetFieldValue("crguptrack");
					}
				}
				else if (groupid.Substring(0,2) == "02")
				{
					conn.QueryString = "select * from vw_approvaluser where userid = '"+ddl_manual.SelectedItem.Value+"'";
					conn.ExecuteQuery();
				
					var_userup	 = conn.GetFieldValue("userid");
					var_username = conn.GetFieldValue("userfullnm");
					var_groupup  = conn.GetFieldValue("groupid");
					var_trackup  = conn.GetFieldValue("usertrack");
				}
				*
				***/
				try 
				{
					conn.QueryString = "EXEC APPROVAL_NEXTUSER '" + 
						lbl_regno.Text + "', '" + 
						Session["UserID"].ToString() + "', '" +
						ddl_manual.SelectedItem.Value + "'";
					conn.ExecuteQuery();

					var_userup = conn.GetFieldValue("APRVNEXTBY");
					var_username = conn.GetFieldValue("APRVNEXTBYNAME");
					var_trackup = conn.GetFieldValue("NEXTTRACK");
					var_useruntil = conn.GetFieldValue("APRVUNTIL");
				} 
				catch (NullReferenceException) 
				{
					GlobalTools.popMessage(this, "Connection Error !");
					return;
				}

				//--- Added By Yudi (2004-08-26) ---
				if (var_userup == "") 
				{
					GlobalTools.popMessage(this, "User tidak punya upliner !");
					return;
				}
				//----------------------------------

				//update track
				conn.QueryString = "select * from vw_currtrack where ap_regno = '"+lbl_regno.Text+"'";
				conn.ExecuteQuery();
				DataTable dt_currtrack = new DataTable();
				dt_currtrack = conn.GetDataTable().Copy();

				for (int i = 0; i < dt_currtrack.Rows.Count;i++) 
				{
					string var_apptype		= dt_currtrack.Rows[i]["apptype"].ToString();
					string var_prod			= dt_currtrack.Rows[i]["productid"].ToString();
					string var_currtrack	= dt_currtrack.Rows[i]["ap_currtrack"].ToString();
					string PROD_SEQ			= dt_currtrack.Rows[i]["PROD_SEQ"].ToString();

					/*
					//20070725 add by sofyan for new approval routing
					//if ((LBL_APRV_ROUTING.Text == "four eyes") && (var_complevel == var_middle || var_complevel == var_corp || var_complevel == var_crg))
					if (LBL_APRV_ROUTING.Text == "four eyes")
					{
						conn.QueryString = "EXEC APPROVAL_NEWROUTING_FOUREYES '" +
							lbl_regno.Text + "', '" +
							var_apptype + "', '" +
							var_prod + "', '" +
							PROD_SEQ + "', '" +
							var_currtrack + "', '" +
							lbl_userid.Text+"'";
						conn.ExecuteQuery();

						var_trackup = conn.GetFieldValue("nexttrack");
						var_userup = conn.GetFieldValue("nextuser");
						var_username = conn.GetFieldValue("nextusername");
						var_useruntil = conn.GetFieldValue("nextuseruntil");
					}
					*/
						
					//if (cbl_prod.Items[i].Selected)
					//{
					conn.QueryString = "exec approval_nexttrack '"+
						lbl_regno.Text+"', '"+
						var_prod+"', '"+
						var_apptype+"', '"+
						lbl_userid.Text+"', '"+
						var_userup+"', '"+
						var_trackup+"', '1', '"+
						var_useruntil+"', '" + 
						PROD_SEQ + "'";
					try 
					{
						conn.ExecuteQuery();
					} 
					catch (NullReferenceException) 
					{
						GlobalTools.popMessage(this, "Connection Error !");
						return;
					}

					conn.QueryString = "update approval_decision set ad_status = '0' where ap_regno = '"+lbl_regno.Text+"' "+
						" and productid = '"+var_prod+"' and apptype = '"+var_apptype+"' and PROD_SEQ = '" + PROD_SEQ + "' " + 
						" and userid = '"+lbl_userid.Text+"' ";
					conn.ExecuteQuery();

					//20070725 add by sofyan for new approval routing
					//last forward by bu
					/* if (groupid.Substring(0,2) == "01") */
					if (1==1)
					{
						conn.QueryString = "update application set ap_lastfwdbuby = '" + lbl_userid.Text +
							"' where ap_regno = '" + lbl_regno.Text + "'";
						conn.ExecuteNonQuery();
					}

				}
				#endregion

			}					
			msg = "Application forward to : "+var_username+" for next approval";				
			Response.Redirect("ListApproval.aspx?msg="+msg+"&mc="+Request.QueryString["mc"]+"&tc=" + Request.QueryString["tc"]);
		}

		private void btn_fwdrisk_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "select 1 from vw_currtrack where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();
			int cnttrack = conn.GetRowCount();

			conn.QueryString = "select 1 from approval_decision ad where ad.ap_regno = '" + lbl_regno.Text + "' " +
				" and ad.userid = '" + lbl_userid.Text + "' " +
				" and ad.ad_seq = (select max(ad_seq) from approval_decision ad2 " +
				" where ad.ap_regno = ad2.ap_regno and ad.apptype = ad2.apptype and ad.productid = ad2.productid and ad.prod_seq = ad2.prod_seq)";
			conn.ExecuteQuery();
			int cntad = conn.GetRowCount();

			if (cnttrack != cntad)
			{
				GlobalTools.popMessage(this, "Check Facilities of Structure Credit First!");
				return;
			}

			conn.QueryString = "update application set ap_aprvremark = '"+txt_remark.Text+"' where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();

			/***/

			conn.QueryString = "select * from vw_currtrack where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();
			DataTable dt_currtrack = new DataTable();
			dt_currtrack = conn.GetDataTable().Copy();

			for (int i = 0; i < dt_currtrack.Rows.Count;i++) 
			{
				string var_apptype		= dt_currtrack.Rows[i]["apptype"].ToString();
				string var_prod			= dt_currtrack.Rows[i]["productid"].ToString();
				string var_currtrack	= dt_currtrack.Rows[i]["ap_currtrack"].ToString();
				string PROD_SEQ			= dt_currtrack.Rows[i]["PROD_SEQ"].ToString();

				conn.QueryString = "EXEC APPROVAL_FWDTORISKUNIT '" +
					lbl_regno.Text + "', '" +
					var_apptype + "', '" +
					var_prod + "', '" +
					PROD_SEQ + "', '" +
					lbl_userid.Text + "', '" +
					Request.QueryString["tc"] + "'";
				try 
				{
					conn.ExecuteQuery();
				} 
				catch (NullReferenceException) 
				{
					GlobalTools.popMessage(this, "Connection Error !");
					return;
				}

				conn.QueryString = "update approval_decision set ad_status = '0' where ap_regno = '"+lbl_regno.Text+"' "+
					" and productid = '"+var_prod+"' and apptype = '"+var_apptype+"' and PROD_SEQ = '" + PROD_SEQ + "' " + 
					" and userid = '"+lbl_userid.Text+"' ";
				conn.ExecuteQuery();

				//20070725 add by sofyan for new approval routing
				//last forward by bu
				/* if (groupid.Substring(0,2) == "01") */
				if (1==1)
				{
					conn.QueryString = "update application set ap_lastfwdbuby = '" + lbl_userid.Text +
						"' where ap_regno = '" + lbl_regno.Text + "'";
					conn.ExecuteNonQuery();
				}
			}

			msg = "Application forward to : " + LBL_RISKUNITNAME.Text + " for next approval";
			Response.Redirect("ListApproval.aspx?msg="+msg+"&mc="+Request.QueryString["mc"]+"&tc=" + Request.QueryString["tc"]);
		}

		private void btn_appeal_Click(object sender, System.EventArgs e)
		{
			/*****
			 * 
			 * Appeal Routing :
			 * Appeal adalah dari BU ke CRM. 
			 * Routingnya adalah dari BU ke upliner dari mitra BU tersebut
			 * 
			 * **/
			
			string msg = "";
			
			conn.QueryString = "select 1 from vw_currtrack where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();
			int cnttrack = conn.GetRowCount();

			conn.QueryString = "select 1 from approval_decision ad where ad.ap_regno = '" + lbl_regno.Text + "' " +
				" and ad.userid = '" + lbl_userid.Text + "' " +
				" and ad.ad_seq = (select max(ad_seq) from approval_decision ad2 " +
				" where ad.ap_regno = ad2.ap_regno and ad.apptype = ad2.apptype and ad.productid = ad2.productid and ad.prod_seq = ad2.prod_seq)";
			conn.ExecuteQuery();
			int cntad = conn.GetRowCount();

			if (cnttrack != cntad)
			{
				GlobalTools.popMessage(this, "Check Approval Structure Credit First!");
				return;
			}


			/// Check whether the user-destination for appeal is defined
			/// 
			if (ddl_appeal.SelectedValue == "") 
			{
				GlobalTools.popMessage(this, "There is no user defined for appeal!");
				return;
			}

			///////////////////////////////////////////////////////////////
			/// update approval remark and ap_isappeal flag = 1
			/// 
			conn.QueryString = "update application set ap_isappeal = '1', ap_aprvremark = '"+txt_remark.Text+"' where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();
			///////////////////////////////////////////////////////////////



			conn.QueryString = "select * from vw_currtrack where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();
			DataTable dt_currtrack = new DataTable();
			dt_currtrack = conn.GetDataTable().Copy();
			for (int i = 0; i < dt_currtrack.Rows.Count;i++) 
			{
				string var_apptype		= dt_currtrack.Rows[i]["apptype"].ToString();
				string var_prod			= dt_currtrack.Rows[i]["productid"].ToString();
				string var_currtrack	= dt_currtrack.Rows[i]["ap_currtrack"].ToString();
				string prod_seq     	= dt_currtrack.Rows[i]["prod_seq"].ToString();
					
				conn.QueryString = "exec approval_appeal '"+lbl_regno.Text+"', '"+var_prod+"', '"+var_apptype+"', '"+ddl_appeal.SelectedValue+"', '"+lbl_userid.Text+"', '" + prod_seq + "'";
				conn.ExecuteQuery();
			}

			msg = "Application is appealed to " + ddl_appeal.SelectedItem.Text + "!";
			Response.Redirect("ListApproval.aspx?tc=" + Request.QueryString["tc"] + "&mc="+Request.QueryString["mc"]+"&msg=" + msg);
		}

        public string popUp = "";
        private void btn_aprvrej_Click(object sender, System.EventArgs e)
		{
			//check Approve
			string var_check = "";
			Button btn = (Button) sender;
			if (btn.Text == "Approve") 
			{
				for (int i = 0; i < cbl_prod.Items.Count;i++) 
				{
					if (cbl_prod.Items[i].Selected == true)
						var_check = "1";
					else if ((var_check != "1") && (cbl_prod.Items[i].Selected == false))
						var_check = "0";	   
				}

				/// User has not decide which facilities to approved
				/// 
				if (var_check == "0")
				{
					GlobalTools.popMessage(this, "Check the facilities to approve");
					return;
				}
				else 
				{
					/// User has decide which facilities to approved
					/// then check whether the user's limit exceed the application's limit
					/// 
					//if (!isCanApprove(var_user)) 
					if (!isCanApprove2(approval_user)) 
					{
						/// User's limit does not exceed application's limit
						/// 						
						GlobalTools.popMessage(this, "User can not approve. \\nApplication limit exceeds user limit!\\n");
						return;
					}
					else 
					{
						/// Prevent user from approving 4-eyes-application is user doesn't have
						/// mitra CRM. So, check the eyes-status and mitra CRM ...
						/// 

						/// Get eyes-status application
						/// 
						conn.QueryString = "select isnull(ap_aprveyes,'0') ap_aprveyes from application where ap_regno = '" + lbl_regno.Text + "'";
						conn.ExecuteQuery();
						string ap_aprveyes = conn.GetFieldValue("ap_aprveyes");

						/// Get Mitra RM 
						/// 
						//conn.QueryString = "select * from vw_approvaluser where userid = '" + lbl_userid.Text + "'";
						conn.QueryString = "select * from vw_approvaluser where userid = '" + var_user + "'";
						conn.ExecuteQuery();
						
						string sgmitra		= conn.GetFieldValue("su_mitrarm"); 
						string mitratrack	= conn.GetFieldValue("mitratrack");
						string grpunit		= conn.GetFieldValue("userid_sg_grpunit");
						string groupid		= conn.GetFieldValue("groupid");

						/*
                        if ((grpunit == "BU" || groupid.StartsWith("01")) && (sgmitra == "" || mitratrack == ""))
						{
							/// Approval is 4 eyes, but BU approval user doesn't have mitra CRM
							/// 
							GlobalTools.popMessage(this, "Current Approval User does not have Mitra CRM for 4-eyes-Approval or \\nMitra CRM User has no track defined.");
							return;
						}
                        */
					}
				}
			}
			else if (btn.Text == "Reject") 
			{
				for (int i = 0; i < cbl_prod.Items.Count;i++) 
				{
					if (cbl_prod.Items[i].Selected == false)
						var_check = "1";
					else if ((var_check != "1") && (cbl_prod.Items[i].Selected == true))
						var_check = "0";	   
				}

				if (var_check == "0")
				{
					GlobalTools.popMessage(this, "Uncheck the facilities to reject");
					return;
				}
			}

			//Response.Write("<script for=window event=onload language='javascript'>PopupPage('../VerifyUser.aspx?userid=" + approval_user + "&theForm=Form1&theObj=TXT_VERIFY', '400','170');</script>");
            popUp = "<script for=window event=onload language='javascript'>PopupPage('../VerifyUser.aspx?userid=" + approval_user + "&theForm=Form1&theObj=TXT_VERIFY', '430','170');</script>";
		}

		private void btn_pprk_Click(object sender, System.EventArgs e)
		{
			/// Get Current Track
			/// 
			conn.QueryString = "select 1 from vw_currtrack where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();
			int cnttrack = conn.GetRowCount();

			conn.QueryString = "select 1 from approval_decision ad where ad.ap_regno = '" + lbl_regno.Text + "' " +
				" and ad.userid = '" + lbl_userid.Text + "' " +
				" and ad.ad_seq = (select max(ad_seq) from approval_decision ad2 " +
				" where ad.ap_regno = ad2.ap_regno and ad.apptype = ad2.apptype and ad.productid = ad2.productid and ad.prod_seq = ad2.prod_seq)";
			conn.ExecuteQuery();
			int cntad = conn.GetRowCount();

			if (cnttrack != cntad)
			{
				GlobalTools.popMessage(this, "Check Approval Structure Credit First!");
				return;
			}

			
			conn.QueryString = "update application set ap_aprvremark = '"+txt_remark.Text+"' where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();

			conn.QueryString = "update application set ap_prrkby = '"+ddl_prrk.SelectedItem.Value+"', "+
				" ap_aprvnextby = '', ap_aprvup = '', ap_joinapproval = null, ap_joinaprvseq = null "+
				" where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();
			
			//update track
			conn.QueryString = "select * from vw_currtrack where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();
			DataTable dt_currtrack = new DataTable();
			dt_currtrack = conn.GetDataTable().Copy();
			for (int i = 0; i < dt_currtrack.Rows.Count;i++) 
			{
				string var_apptype		= dt_currtrack.Rows[i]["apptype"].ToString();
				string var_prod			= dt_currtrack.Rows[i]["productid"].ToString();
				string var_currtrack	= dt_currtrack.Rows[i]["ap_currtrack"].ToString();
				string PROD_SEQ		    = dt_currtrack.Rows[i]["PROD_SEQ"].ToString();
											
				conn.QueryString = "update apptrack set ap_currtrack = '"+var_prrk+"', ap_currtrackdate = getdate(), "+
					" ap_currtrackby = '"+lbl_userid.Text+"' "+
					" where ap_regno = '"+lbl_regno.Text+"' "+
					" and apptype = '"+var_apptype+"' "+
					" and productid = '"+var_prod+"' " +
					" and PROD_SEQ = '" + PROD_SEQ + "'";
				conn.ExecuteQuery();
					
				/// insert into track history
				/// 
				conn.QueryString = "select max(th_seq)+1 th_seq from trackhistory "+
					" where ap_regno = '"+lbl_regno.Text+"' and productid = '"+var_prod+"' and apptype = '"+var_apptype+"' and PROD_SEQ = '" + PROD_SEQ + "'";
				conn.ExecuteQuery();
				int var_seq = Convert.ToInt16(conn.GetFieldValue("th_seq"));

				conn.QueryString = "insert trackhistory(ap_regno, apptype, productid, trackcode, th_seq, th_trackdate, th_trackby, PROD_SEQ , TH_TRACKNEXTBY) "+
					" values('"+lbl_regno.Text+"', '"+var_apptype+"', '"+var_prod+"', '"+var_prrk+"', '"+var_seq+"', getdate(), '"+lbl_userid.Text+"', '" + PROD_SEQ + "' , '" + ddl_prrk.SelectedItem.Value + "')";
				conn.ExecuteQuery();

				conn.QueryString = "update overall_sla_responsetime set userid = '" + ddl_prrk.SelectedItem.Value + 
					"', ap_currtrack = '" + var_prrk + "' where ap_regno = '" + lbl_regno.Text + "' ";
				conn.ExecuteNonQuery();

				/// Get approval track for audit trail
				string trackname = "";
				conn.QueryString = "exec SP_AUDITTRAIL_TRACKNAMEAPPRV '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
				trackname = conn.GetFieldValue("TRACKNAME");

				/// Log Audit trail tracking application
				/// 
				try 
				{ 
					conn.QueryString = "exec SP_AUDITTRAIL_APP '" + 
						Request.QueryString["regno"] + "', '" + 
						var_apptype + "', '" + 
						var_prod + "', '" + 
						PROD_SEQ + "', '" + 
						Request.QueryString["curef"] + "', NULL, " + 
						"'" + TXT_AUDITTRAIL_DESC.Text + ddl_prrk.SelectedItem.Text + "', NULL, '" + 
						Session["USERID"].ToString() + "', NULL, 'Y', '" + 
						trackname + "'";
					conn.ExecuteNonQuery();
				} 
				catch (Exception ex)
				{
					/// TODO : 
					/// Try .. catch harus diberikan informasi lebih lengkap 				
					/// Sekarang dikosongkan dulu karena belum migrasi, tapi sudah UAT
					/// 
					Response.Write("<!-- " + ex.Message.ToString() + "-->");
				}
			}

			Response.Redirect("ListApproval.aspx?mc="+Request.QueryString["mc"]+"&tc=" + Request.QueryString["tc"]);
		}

		private void btn_info_Click(object sender, System.EventArgs e)
		{
			preAcquireInfo();		

			//Response.Write("<script for=window event=onload language='javascript'>PopupPage('AcqInfo.aspx?regno=" + lbl_regno.Text + "&curef=" + lbl_curef.Text + "&aprv=CRM&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>");
            popUp = "<script for=window event=onload language='javascript'>PopupPage('AcqInfo.aspx?regno=" + lbl_regno.Text + "&curef=" + lbl_curef.Text + "&aprv=CRM&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>";
            //popUp = "<script for=window event=onload language='javascript'>PopupPage('../VerifyUser.aspx?userid=" + approval_user + "&theForm=Form1&theObj=TXT_VERIFY', '430','170');</script>";

			//msg = "Application acquire information from " + var_trby + "!";
			//Response.Redirect("ListApproval.aspx?mc="+Request.QueryString["mc"]+"&tc=" + Request.QueryString["tc"]+"&msg="+msg);
			//Response.Redirect("AcqInfo.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text+"&prod="+lbl_prod.Text+"&apptype="+lbl_apptype.Text+"&tc="+lbl_track.Text+"&mc="+Request.QueryString["mc"]);
		}

        private void btn_backtover_Click(object sender, System.EventArgs e)
		{
			preAcquireInfo();
			
			//Response.Write("<script for=window event=onload language='javascript'>PopupPage('AcqInfo.aspx?regno=" + lbl_regno.Text + "&curef=" + lbl_curef.Text + "&aprv=BU&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>");

            popUp = "<script for=window event=onload language='javascript'>PopupPage('AcqInfo.aspx?regno=" + lbl_regno.Text + "&curef=" + lbl_curef.Text + "&aprv=BU&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>";

			//msg = "Application acquire information from " + AP_RELMNGR + "!";
			//Response.Redirect("ListApproval.aspx?mc="+Request.QueryString["mc"]+"&tc=" + Request.QueryString["tc"]+"&msg="+msg);
		}

		private void btn_aprvby_Click(object sender, System.EventArgs e)
		{
			//Response.Redirect("AprvBy.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text+"&prod="+lbl_prod.Text+"&apptype="+lbl_apptype.Text+"&tc="+lbl_track.Text);
		}

		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//Response.Redirect("ListApproval.aspx");
			Response.Redirect("ListApproval.aspx?tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"]);
		}		

		private void TXT_VERIFY_TextChanged(object sender, System.EventArgs e)
		{
			if(this.TXT_VERIFY.Text != "")
			{
				this.TXT_VERIFY.Text = "";

				string var_kreditbaru, vAP_APRVCOMMITEE, vAP_APRVCOND;
				double var_emaslimit, var_adlimit;
				string var_fromsta;

				conn.QueryString = "SELECT ISNULL(AP_APRVEYES,'0') as AP_APRVEYES, " + 
					" ISNULL(AP_APRVCOMMITEE,'') AS AP_APRVCOMMITEE, " + 
					" ISNULL(AP_APRVCOND,'0') AS AP_APRVCOND " + 
					" FROM APPLICATION WHERE AP_REGNO = '" + lbl_regno.Text + "'";
				conn.ExecuteQuery();
				var_aprveye = conn.GetFieldValue("ap_aprveyes");
				vAP_APRVCOMMITEE = conn.GetFieldValue("AP_APRVCOMMITEE");
				vAP_APRVCOND = conn.GetFieldValue("AP_APRVCOND");
				
				conn.QueryString = "select 1 from vw_currtrack where ap_regno = '"+lbl_regno.Text+"'";
				conn.ExecuteQuery();
				Response.Write("<!-- query cnttrack: " + conn.QueryString + " -->");
				int cnttrack = conn.GetRowCount();

				conn.QueryString = "select 1 from approval_decision ad where ad.ap_regno = '" + lbl_regno.Text + "' " +
					" and ad.userid = '" + lbl_userid.Text + "' " +
					" and ad.ad_seq = (select max(ad_seq) from approval_decision ad2 " +
					" where ad.ap_regno = ad2.ap_regno and ad.apptype = ad2.apptype and ad.productid = ad2.productid and ad.prod_seq = ad2.prod_seq)";
				conn.ExecuteQuery();
				Response.Write("<!-- query cntad: " + conn.QueryString + " -->");
				int cntad = conn.GetRowCount();

				Response.Write("<!-- cnttrack: " + cnttrack + " -->");
				Response.Write("<!-- cntad: " + cntad + " -->");

				if (cnttrack != cntad)
				{
					GlobalTools.popMessage(this, "Check Approval Structure Credit First!");
					return;
				}

				//2007-10-26 for additional check
				conn.QueryString = "EXEC APPROVAL_ADDITIONAL_CHECK '" + lbl_regno.Text + "', '"+lbl_userid.Text+"'";
				conn.ExecuteQuery();
				string addcheck = conn.GetFieldValue("ISCANAPPROVE");

				/// mengambil apptype untuk permohonan baru
				/// 
				conn.QueryString = "select in_kreditbaru from rfinitial";
				conn.ExecuteQuery();
				var_kreditbaru = conn.GetFieldValue("in_kreditbaru");

				/// mengambil emas limit user yang login
				/// 
				conn.QueryString = "select isnull(su_emaslimit, 0)su_emaslimit from scuser "+
					" where userid = '"+lbl_userid.Text+"'";
				conn.ExecuteQuery();
				var_emaslimit = double.Parse(conn.GetFieldValue("su_emaslimit"));
				

				//conn.QueryString = "select * from vw_currtrack where ap_regno = '"+lbl_regno.Text+"' and isnull(cp_decsta,'') <> '"+var_reject+"'";
				conn.QueryString = "select * from vw_currtrack where ap_regno = '"+lbl_regno.Text+"' and isnull(cp_decsta,'') not in ('"+var_reject+"', '"+var_reject1+"')";
				conn.ExecuteQuery();
				DataTable dt_currtrack = new DataTable();
				dt_currtrack = conn.GetDataTable().Copy();
			
				for (int cnt = 0; cnt < dt_currtrack.Rows.Count;cnt++) 
				{
					if (dt_currtrack.Rows[cnt]["apptype"].ToString() == var_kreditbaru)
					{
						conn.QueryString = "select * from approval_decision "+
							" where ap_regno = '"+lbl_regno.Text+"'"+
							" and apptype = '"+dt_currtrack.Rows[cnt]["apptype"].ToString()+"' "+
							" and productid = '"+dt_currtrack.Rows[cnt]["productid"].ToString()+"' "+
							" and PROD_SEQ = '" + dt_currtrack.Rows[cnt]["PROD_SEQ"].ToString() + "' " +
							" and ad_seq = (select max(ad_seq) from approval_decision ad where approval_decision.ap_regno = ad.ap_regno and approval_decision.productid = ad.productid and approval_decision.apptype = ad.apptype and approval_decision.PROD_SEQ = ad.PROD_SEQ) ";
						conn.ExecuteQuery();
						var_adlimit = double.Parse(conn.GetFieldValue("ad_limit"));
						

						//if (var_adlimit > var_emaslimit && vAP_APRVCOMMITEE.Trim() == "")
						//2007-10-26 di-hardcode, additional check
						if (var_adlimit > var_emaslimit && vAP_APRVCOMMITEE.Trim() == "" && addcheck.Trim() == "FALSE")
						{
							GlobalTools.popMessage(this, "Limit in rupiah cannot greater than eMas Limit");
							return;
						}
					}
				}

				// Button check Prevoius

				conn.QueryString = "update application set ap_aprvremark = '"+txt_remark.Text+"' where ap_regno = '"+lbl_regno.Text+"'";
				conn.ExecuteQuery();
			
				if ((ddl_aprvwith.SelectedValue != "") || (var_aprveye == "0"))
				{
					//insert approval decision for userid (approve with)
					/*conn.QueryString = "select * from approval_decision "+
						" where ad_seq = (select max(ad_seq) from approval_decision ad "+
						" where approval_decision.ap_regno = ad.ap_regno "+
						" and approval_decision.productid = ad.productid "+
						" and approval_decision.apptype = ad.apptype " + 
						" and approval_decision.PROD_SEQ = ad.PROD_SEQ ) "+
						" and ap_regno = '"+lbl_regno.Text+"' "+
						" and userid = '"+lbl_userid.Text+"'";*/
					conn.QueryString = "select * from approval_decision "+
						" where ad_seq = (select max(ad_seq) from approval_decision ad "+
						" where approval_decision.ap_regno = ad.ap_regno "+
						" and approval_decision.productid = ad.productid "+
						" and approval_decision.apptype = ad.apptype "+ 
						" and approval_decision.PROD_SEQ = ad.PROD_SEQ "+
						" and approval_decision.userid = ad.userid) "+
						" and ap_regno = '"+lbl_regno.Text+"' "+
						" and userid = '"+lbl_userid.Text+"'";

					conn.ExecuteQuery();
					DataTable dt_aprvdec = new DataTable();
					dt_aprvdec = conn.GetDataTable().Copy();
					for (int j = 0; j < dt_aprvdec.Rows.Count;j++) 
					{
						string var_product, var_apptype1, var_rateno, var_varcode, var_tenorcode, var_graceperiode, var_prod_seq, var_maturitydate;
						string var_ovrreason, var_ovrreasontext, var_ovrsta, var_remark, var_payment, var_decsta;
						double var_limit, var_variance, var_interest, var_installment, var_exlimitval, var_exrplimit;
						int var_tenor;

						var_tenor = 0;
						var_maturitydate = null;

						var_product			= dt_aprvdec.Rows[j]["productid"].ToString();
						var_apptype1		= dt_aprvdec.Rows[j]["apptype"].ToString();
						var_prod_seq		= dt_aprvdec.Rows[j]["prod_seq"].ToString();
						var_limit			= double.Parse(dt_aprvdec.Rows[j]["ad_limit"].ToString());
						try {var_tenor			= int.Parse(dt_aprvdec.Rows[j]["ad_tenor"].ToString());}
						catch {var_maturitydate	= dt_aprvdec.Rows[j]["ad_maturitydate"].ToString();}
						var_tenorcode		= dt_aprvdec.Rows[j]["ad_tenorcode"].ToString();
						var_interest		= double.Parse(dt_aprvdec.Rows[j]["ad_interest"].ToString());
						var_rateno			= dt_aprvdec.Rows[j]["ad_rateno"].ToString();
						var_varcode			= dt_aprvdec.Rows[j]["ad_varcode"].ToString();
						var_variance		= double.Parse(dt_aprvdec.Rows[j]["ad_variance"].ToString());
						var_ovrsta			= dt_aprvdec.Rows[j]["ad_ovrsta"].ToString();
						var_ovrreason		= dt_aprvdec.Rows[j]["ad_ovrreason"].ToString();
						var_ovrreasontext	= dt_aprvdec.Rows[j]["ad_ovrreasontext"].ToString();
						var_remark			= dt_aprvdec.Rows[j]["ad_keterangan"].ToString();
						var_installment		= double.Parse(dt_aprvdec.Rows[j]["ad_installment"].ToString());
						var_decsta			= dt_aprvdec.Rows[j]["ad_reject"].ToString();
						var_exlimitval		= double.Parse(dt_aprvdec.Rows[j]["ad_exlimitval"].ToString());
						var_exrplimit		= double.Parse(dt_aprvdec.Rows[j]["ad_exrplimit"].ToString());
						var_fromsta			= dt_aprvdec.Rows[j]["ad_fromsta"].ToString();
						var_graceperiode	= dt_aprvdec.Rows[j]["ad_graceperiod"].ToString();
						var_payment			= dt_aprvdec.Rows[j]["ad_paymentid"].ToString();						

						string s_var_maturitydate = "";
						if (var_maturitydate != null) s_var_maturitydate = GlobalTools.ToSQLDate(var_maturitydate);

						if (ddl_aprvwith.SelectedValue != "") 
						{
							if (ddl_aprvwith.SelectedValue != lbl_userid.Text)
							{
								try 
								{
									conn.QueryString = "exec input_approvaldecision  '"+lbl_regno.Text+"', '"+var_product+"', "+
										" '"+var_apptype1+"', '"+ddl_aprvwith.SelectedValue+"', "+
										" '"+var_limit+"', '"+var_tenor+"','"+var_tenorcode+"', "+
										" "+tool.ConvertFloat(var_interest.ToString())+", '"+var_rateno+"', '"+var_varcode+"', "+tool.ConvertFloat(var_variance.ToString())+", "+
										" '"+var_ovrreason+"', '"+var_ovrreasontext+"', '"+var_remark+"', "+tool.ConvertFloat(var_installment.ToString())+", "+
										" '"+var_ovrsta+"', '"+var_decsta+"', "+tool.ConvertFloat(var_exlimitval.ToString())+", "+
										" "+tool.ConvertFloat(var_exrplimit.ToString())+", '"+var_fromsta+"', "+
										" "+tool.ConvertNum(var_graceperiode)+", '"+var_payment+"', '" + var_prod_seq + "', " + s_var_maturitydate + "";
									conn.ExecuteQuery();
								} 
								catch (Exception ex)
								{
									conn.QueryString = "exec input_approvaldecision  '"+lbl_regno.Text+"', '"+var_product+"', "+
										" '"+var_apptype1+"', '"+ddl_aprvwith.SelectedValue+"', "+
										" '"+var_limit+"', '"+var_tenor+"','"+var_tenorcode+"', "+
										" "+tool.ConvertFloat(var_interest.ToString())+", '"+var_rateno+"', '"+var_varcode+"', "+tool.ConvertFloat(var_variance.ToString())+", "+
										" '"+var_ovrreason+"', '"+var_ovrreasontext+"', '"+var_remark+"', "+tool.ConvertFloat(var_installment.ToString())+", "+
										" '"+var_ovrsta+"', '"+var_decsta+"', "+tool.ConvertFloat(var_exlimitval.ToString())+", "+
										" "+tool.ConvertFloat(var_exrplimit.ToString())+", '"+var_fromsta+"', "+
										" "+tool.ConvertNum(var_graceperiode)+", '"+var_payment+"', '" + var_prod_seq + "', null";
									conn.ExecuteQuery();
								}
							}
						}

						//insert approval decision for two eyes (CRM default to SYSTEM, needed for upload to Back end)
						if (var_aprveye == "0")
						{
							try 
							{
								conn.QueryString = "exec input_approvaldecision  '"+lbl_regno.Text+"', '"+var_product+"', "+
									" '"+var_apptype1+"', 'SYSTEM', "+
									" '"+var_limit+"', '"+var_tenor+"','"+var_tenorcode+"', "+
									" "+tool.ConvertFloat(var_interest.ToString())+", '"+var_rateno+"', '"+var_varcode+"', "+tool.ConvertFloat(var_variance.ToString())+", "+
									" '"+var_ovrreason+"', '"+var_ovrreasontext+"', '"+var_remark+"', "+tool.ConvertFloat(var_installment.ToString())+", "+
									" '"+var_ovrsta+"' , '"+var_decsta+"', "+tool.ConvertFloat(var_exlimitval.ToString())+", "+
									" "+tool.ConvertFloat(var_exrplimit.ToString())+", '"+var_fromsta+"', "+
									" "+tool.ConvertNum(var_graceperiode)+", '"+var_payment+"', '" + var_prod_seq + "', " + s_var_maturitydate + "";
								conn.ExecuteQuery();
							} 
							catch  (Exception ex)
							{
								conn.QueryString = "exec input_approvaldecision  '"+lbl_regno.Text+"', '"+var_product+"', "+
									" '"+var_apptype1+"', 'SYSTEM', "+
									" '"+var_limit+"', '"+var_tenor+"','"+var_tenorcode+"', "+
									" "+tool.ConvertFloat(var_interest.ToString())+", '"+var_rateno+"', '"+var_varcode+"', "+tool.ConvertFloat(var_variance.ToString())+", "+
									" '"+var_ovrreason+"', '"+var_ovrreasontext+"', '"+var_remark+"', "+tool.ConvertFloat(var_installment.ToString())+", "+
									" '"+var_ovrsta+"' , '"+var_decsta+"', "+tool.ConvertFloat(var_exlimitval.ToString())+", "+
									" "+tool.ConvertFloat(var_exrplimit.ToString())+", '"+var_fromsta+"', "+
									" "+tool.ConvertNum(var_graceperiode)+", '"+var_payment+"', '" + var_prod_seq + "', null";
								conn.ExecuteQuery();
							}
						}
					}
				}

				//update track
				/*conn.QueryString = "select * from vw_currtrack where ap_regno = '"+lbl_regno.Text+"'";
				conn.ExecuteQuery();
				DataTable dt_currtrack = new DataTable();
				dt_currtrack = conn.GetDataTable().Copy();*/
			
				//check if there's any product reject
				for (int i = 0; i < cbl_prod.Items.Count;i++) 
				{	
					if (!cbl_prod.Items[i].Selected)
					{
						if (ddl_rjreason.SelectedValue == "")
						{
							GlobalTools.popMessage(this, "Reject Reason should be filled");
							return;
						}
					}
				}

				int itemApprove = 0;
				
				// to obtain the items has already approved.
				for (int ii = 0; ii < dt_currtrack.Rows.Count;ii++) 
				{
					if (cbl_prod.Items[ii].Selected)
					{
						if (dt_currtrack.Rows[ii]["cp_decsta"].ToString() != var_reject)
						{
							itemApprove  = itemApprove + 1;
						}
					}
				}// end of i loop

				for (int i = 0; i < dt_currtrack.Rows.Count;i++) 
				{
					string var_apptype		= dt_currtrack.Rows[i]["apptype"].ToString();
					string var_prod			= dt_currtrack.Rows[i]["productid"].ToString();
					string var_currtrack	= dt_currtrack.Rows[i]["ap_currtrack"].ToString();
					string var_PROD_SEQ 	= dt_currtrack.Rows[i]["PROD_SEQ"].ToString();

					try
					{
						if (cbl_prod.Items[i].Selected)
						{
							/* if (((groupid.Substring(0,2) == "01") && (var_aprveye == "0")) || (groupid.Substring(0,2) == "02")) */
							if (var_aprveye == "0")
							{
								if (dt_currtrack.Rows[i]["cp_decsta"].ToString() != var_reject)
								{
									//jika approval membutuhkan lebih dari 2 orang
									if (vAP_APRVCOMMITEE != "") 
									{
										string PICAprvCommitee = getPICApprovalCommitee();
										
										conn.QueryString = "exec SP_APPROVAL_COMMITEE_NEXTTRACK '" + 
											lbl_regno.Text + "', '" + 
											var_apptype + "', '" + 
											var_prod + "', '" + 
											var_PROD_SEQ + "', '" + 
											lbl_userid.Text + "', '1', '" + 
											lbl_track.Text + "'";
										conn.ExecuteQuery();

										msg = "Application is Approved and need Approval Commitee to " + PICAprvCommitee;
									}
										// 2012-02-15, Approval Condition for Business Banking
									else if (vAP_APRVCOND == "1")
									{
										string PICAprvCond = "";
										try
										{
											conn.QueryString  = "EXEC APPROVAL_CONDITION_NEXTTRACK '" + 
												lbl_regno.Text + "', '" + 
												var_apptype + "', '" + 
												var_prod + "', '" + 
												var_PROD_SEQ + "', '" + 
												lbl_userid.Text + "', '1', '" + 
												lbl_track.Text + "'";
											conn.ExecuteQuery();

											PICAprvCond = conn.GetFieldValue("AP_APRVCONDBY");
											msg = "Application is Approved and need Condition Acceptance to " + PICAprvCond;
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
									else 
									{
										conn.QueryString = "exec approval_proddecision '"+lbl_regno.Text+"', '"+var_prod+"', '"+var_apptype+"', '"+lbl_userid.Text+"', '1', '"+var_approve+"', '', '', '" + var_PROD_SEQ + "'";
										conn.ExecuteQuery();

										msg = "Application is Approved";

                                        /************************************************** EMAIL ************************************************************/

                                        conn.QueryString = "SELECT PRODUCTDESC FROM RFPRODUCT WHERE PRODUCTID = '" + var_prod + "'";
                                        conn.ExecuteQuery();

                                        string Produk = "\tNama Produk : " + conn.GetFieldValue(0, 0) + Environment.NewLine;
                                        string NomorAplikasi = "\tNomor Aplikasi : " + lbl_regno.Text + Environment.NewLine;

                                        //cek ada BP9.2 ada g
                                        conn.QueryString = "SELECT AD_LIMIT FROM APPROVAL_DECISION WHERE AD_SEQ = " +
                                        "(SELECT MAX(AD_SEQ) as AD_SEQ FROM APPROVAL_DECISION WHERE AP_REGNO = '" + lbl_regno.Text + "')" +
                                        "AND AP_REGNO = '" + lbl_regno.Text + "'";
                                        conn.ExecuteQuery();

                                        string Plafond = "\tPlafond : " + tool.MoneyFormat(conn.GetFieldValue("AD_LIMIT")) + Environment.NewLine;

                                        conn.QueryString = "SELECT SU_FULLNAME FROM SCUSER WHERE USERID = '" + lbl_userid.Text + "'";
                                        conn.ExecuteQuery();
                                        string PemutusTerakhir = "\tPemutus : " + conn.GetFieldValue("SU_FULLNAME") + " - " + lbl_userid.Text + Environment.NewLine;

                                        conn.QueryString = "SELECT CP_RATE FROM CUSTPRODUCT WHERE AP_REGNO = '" + lbl_regno.Text + "' AND APPTYPE = '" + lbl_apptype.Text + "' AND PRODUCTID = '" + lbl_prod.Text + "' AND PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
                                        conn.ExecuteQuery();

                                        string Rate = "\tRate : " + ((float.Parse(conn.GetFieldValue("CP_RATE")) * 100) / 12).ToString() + " %" + Environment.NewLine;

                                        conn.QueryString = "SELECT BRANCH_NAME as BRANCH, CBC_CODE, AREAID FROM RFBRANCH WHERE BRANCH_CODE = '" + var_appbranch + "'";
                                        conn.ExecuteQuery();

                                        string branch = conn.GetFieldValue("BRANCH");
                                        string cbc_code = conn.GetFieldValue("CBC_CODE");
                                        string areaid = conn.GetFieldValue("AREAID");

                                        conn.QueryString = "SELECT BRANCH_NAME as AREA FROM RFBRANCH WHERE BRANCH_CODE = '" + cbc_code + "'";
                                        conn.ExecuteQuery();
                                        string area = conn.GetFieldValue("AREA");

                                        conn.QueryString = "SELECT AREANAME as REGION FROM RFAREA WHERE AREAID = '" + areaid + "'";
                                        conn.ExecuteQuery();
                                        string region = conn.GetFieldValue("REGION");

                                        string CabangPengaju = "\tCabang pengaju : " + branch + "; Area : " + area + "; Region : " + region + Environment.NewLine;

                                        conn.QueryString = "SELECT CU_COMPNAME FROM CUST_COMPANY WHERE CU_REF = '" + lbl_curef.Text + "'";
                                        conn.ExecuteQuery();

                                        if (conn.GetRowCount() < 1)
                                        {
                                            conn.QueryString = "SELECT CU_FIRSTNAME + ' ' + CU_MIDDLENAME + ' ' + CU_LASTNAME as CU_COMPNAME FROM CUST_PERSONAL WHERE CU_REF = '" + lbl_curef.Text + "'";
                                            conn.ExecuteQuery();
                                        }

                                        string NamaNasabah = "\tNama Nasabah : " + conn.GetFieldValue("CU_COMPNAME") + Environment.NewLine;
                                        string TanggalDanJamApprove = "\tDiapprove pada Tanggal " + DateTime.Now.Date.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + "; Jam " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + Environment.NewLine + Environment.NewLine;
                                        string SentBy = "Sent by Bank Pundi Loan Origination System Automated Mail " + Environment.NewLine + Environment.NewLine;
                                        string peringatan = "NOTE : Dimohon untuk tidak membalas email ini, karena email ini digenerate oleh system.";

                                        string header = "Telah terjadi proses Approval Aplikasi LOS dengan detail sbb : " + Environment.NewLine + Environment.NewLine;
                                        string messageMail = header + NamaNasabah + NomorAplikasi + Produk + Plafond + Rate + CabangPengaju + TanggalDanJamApprove + SentBy + peringatan;

                                        //email approval terakhir
                                        //email approval BM

                                        conn.QueryString = "SELECT SU_EMAIL FROM SCUSER WHERE USERID = '" + lbl_userid.Text + "'";
                                        conn.ExecuteQuery();
                                        string emailApprovalAkhir = conn.GetFieldValue("SU_EMAIL");

                                        conn.QueryString = "SELECT DISTINCT(USERID) as USERID FROM APPROVAL_DECISION WHERE AD_SEQ =" +
                                        "(SELECT MIN(AD_SEQ) as AD_SEQ FROM APPROVAL_DECISION WHERE AP_REGNO = '" + lbl_regno.Text + "' AND AD_APRVTRACK in ('BP9.2','BP9.3'))" +
                                        "AND AP_REGNO = '" + lbl_regno.Text + "'";
                                        conn.ExecuteQuery();

                                        string NIPBM = conn.GetFieldValue("USERID");

                                        conn.QueryString = "SELECT SU_EMAIL FROM SCUSER WHERE USERID = '" + NIPBM + "'";
                                        conn.ExecuteQuery();

                                        string emailApprovalBM = conn.GetFieldValue("SU_EMAIL");
                                        string toMail = emailApprovalBM + "," + emailApprovalAkhir;
                                        myMail kirimEmail = new myMail();

                                        if (toMail.StartsWith(","))
                                        {
                                            toMail = toMail.Remove(0,1);
                                        }
                                        if (toMail.EndsWith(","))
                                        {
                                            toMail = toMail.Remove(toMail.Length-1,1);
                                        }


                                        try
                                        {
                                            kirimEmail.SendMail(messageMail, toMail, "", "", "" + "[NO REPLY]LOS Approval", null);
                                        }
                                        catch
                                        {
                                            GlobalTools.popMessage(this, "Pengiriman Email gagal, server email error !");
                                        }
									}
								}
							}
							else
							{
								try
								{
									conn.QueryString  = "EXEC APPROVAL_NEXTTRACK_NEW '" + 
										lbl_regno.Text + "', '" + 
										var_apptype + "', '" + 
										var_prod + "', '" + 
										var_PROD_SEQ + "', '" + 
										lbl_userid.Text + "'";
									conn.ExecuteQuery();

									msg = conn.GetFieldValue("APRVMSG");
								}
								catch (Exception ex)
								{
									string errmsg = ex.Message.Replace("'","");
									if (errmsg.IndexOf("Last Query:") > 0)
										errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
									GlobalTools.popMessage(this, errmsg);
									return;
								}
								
								/*******/
								/*
								string sgmitra, mitratrack, mitraname;
								conn.QueryString = "select * from vw_approvaluser where userid = '"+lbl_userid.Text+"'";
								conn.ExecuteQuery();
						
								sgmitra		= conn.GetFieldValue("su_mitrarm"); 
								mitratrack	= conn.GetFieldValue("mitratrack");
								mitraname	= conn.GetFieldValue("mitrafullnm");
								if (sgmitra != "")
								{
									conn.QueryString = "exec approval_nexttrack '"+
										lbl_regno.Text+"', '"+
										var_prod+"', '"+
										var_apptype+"', '"+
										lbl_userid.Text+"', '"+
										sgmitra+"', '"+
										mitratrack+"', " + 
										"'1', '"+
										sgmitra+"', '" + 
										var_PROD_SEQ + "'";
									conn.ExecuteQuery();
									msg = "Application is approved by BU and need CRM approval to "+mitraname;
								}
								else
								{
									//jika approval membutuhkan lebih dari 2 orang
									if (vAP_APRVCOMMITEE != "") 
									{
										string PICAprvCommitee = getPICApprovalCommitee();

										conn.QueryString = "exec SP_APPROVAL_COMMITEE_NEXTTRACK '" + 
											lbl_regno.Text + "', '" + 
											var_apptype + "', '" + 
											var_prod + "', '" + 
											var_PROD_SEQ + "', '" + 
											lbl_userid.Text + "', '1', '" + 
											lbl_track.Text + "'";
										conn.ExecuteQuery();

										msg = "Application is Approved and need Approval Commitee to " + PICAprvCommitee;
									}
									else 
									{
										/// Approval is 4 eyes, but BU approval user doesn't have mitra CRM
										/// 
										GlobalTools.popMessage(this, "BU Approval User does not have Mitra CRM for 4-eyes-Approval");
										return;
									}
								}
								*/
								/*******/
							}
							conn.QueryString = "update approval_decision set ad_status = '1', ad_reject = '0' where ap_regno = '"+lbl_regno.Text+"' "+
								" and productid = '"+var_prod+"' and apptype = '"+var_apptype+"' and PROD_SEQ = '" + var_PROD_SEQ + "' " +
								" and userid = '"+lbl_userid.Text+"' ";
							conn.ExecuteQuery();
						}				
						else
						{
							if (dt_currtrack.Rows[i]["cp_decsta"].ToString() != var_reject)
							{
								
								if (itemApprove > 0 ) 
								{
									conn.QueryString = "exec approval_proddecision '"+lbl_regno.Text+"', '"+var_prod+"', '"+var_apptype+"', '"+lbl_userid.Text+"', '0', '"+var_reject1+"', '"+ddl_rjreason.SelectedValue.ToString()+"', '"+txt_rjreason.Text+"', '" + var_PROD_SEQ + "'";
									conn.ExecuteQuery();
								}
								else 
								{
									conn.QueryString = "exec approval_proddecision '"+lbl_regno.Text+"', '"+var_prod+"', '"+var_apptype+"', '"+lbl_userid.Text+"', '0', '"+var_reject+"', '"+ddl_rjreason.SelectedValue.ToString()+"', '"+txt_rjreason.Text+"', '" + var_PROD_SEQ + "'";
									conn.ExecuteQuery();
								}

								conn.QueryString = "update approval_decision set ad_status = '2', ad_reject = '1' where ap_regno = '"+lbl_regno.Text+"' "+
									" and productid = '"+var_prod+"' and apptype = '"+var_apptype+"' and PROD_SEQ = '" + var_PROD_SEQ + "' " +
									" and userid = '"+lbl_userid.Text+"' ";
								conn.ExecuteQuery();
							}
						}
					}
					catch(Exception x) 
                    {
                        GlobalTools.popMessage(this, x.Message);
                    }
				
					//check if all product reject then application is rejected
					conn.QueryString = "select * from vw_currtrack where ap_regno = '"+lbl_regno.Text+"'";
					conn.ExecuteQuery();
					int cntprod = conn.GetRowCount();

					conn.QueryString = "select * from vw_currtrack where ap_regno = '"+lbl_regno.Text+"' and cp_decsta = '"+var_reject+"'";
					conn.ExecuteQuery();
					int cntprodrej = conn.GetRowCount();

					if (cntprod == cntprodrej)
					{
						conn.QueryString = "update application set ap_reject = '1' where ap_regno = '"+lbl_regno.Text+"'";
						conn.ExecuteQuery();
					}
				}	
				Response.Redirect("ListApproval.aspx?msg="+msg+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]);

			}
		}

		private void TXT_TEMP_TextChanged(object sender, EventArgs e)
		{
			if (TXT_TEMP.Text != "") 
			{
				string msg = "";
				msg = "Application acquire information from " + TXT_TEMP.Text + " !";
				Response.Redirect("ListApproval.aspx?mc="+Request.QueryString["mc"]+"&tc=" + Request.QueryString["tc"]+"&msg="+msg);
			}
		}

		protected void BTN_PROJECTLIST_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script for=window event=onload language='javascript'>PopupPage('../ProjectInfo.aspx?targetFormID=Form1', '800','600');</script>");
		}
	}
}
