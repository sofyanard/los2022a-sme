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

namespace SME.Approval
{
	/// <summary>
	/// Summary description for ApprovalCondition.
	/// </summary>
	public partial class ApprovalCondition : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		string var_user, approval_user, var_groupid,
			var_complevel, var_uplineruser, var_uplinertrack,
			var_reject, var_reject1, var_approve, var_cancelcust, var_cancelbank, var_prrk,
			var_kreditbaru, var_ubahjaminan, var_ubahlimit, var_renewal, var_ubahsyarat,
			var_sgprrk, var_small, var_middle, groupid, var_appeal, var_corp, var_crg, var_micro,
			var_accept, var_greyzone, var_decline, var_fairissac, var_progfoureyes,
			var_inbranch, var_appbranch, var_area, var_cbc, var_aprvuntil, var_aprvnextby, var_aprveye;
		string msg, company_curef;
		double var_userlimit, var_lineamount, var_limitexp;	
		double var_smlminappeal, var_smlmaxappeal;
		DataTable dt_init	 = new DataTable();
		DataTable dt_aprvdec = new DataTable();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			approval_user = Session["USERID"].ToString();

			ViewMenu();
			ViewData();

			if (!IsPostBack)
			{
				fillAcquireInformation();
				approval2();
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

		private void ViewData()
		{
			#region initialize_page
			lbl_regno.Text	= Request.QueryString["regno"];
			lbl_curef.Text	= Request.QueryString["curef"];
			lbl_prod.Text	= Request.QueryString["prod"];
			lbl_apptype.Text	= Request.QueryString["apptype"];
			LBL_PROD_SEQ.Text	= Request.QueryString["prod_seq"];
			lbl_track.Text	= Request.QueryString["tc"];
			lbl_userid.Text	= Session["USERID"].ToString();
			mc.Text			= Request.QueryString["mc"];
			var_groupid		= Session["GROUPID"].ToString();
			groupid			= var_groupid;

			//initial
			conn.QueryString	= "select * from rfinitial";
			conn.ExecuteQuery();
			dt_init				= conn.GetDataTable().Copy();
			var_approve			= dt_init.Rows[0]["in_approve"].ToString();
			var_reject			= dt_init.Rows[0]["in_reject"].ToString();//Reject
			var_reject1			= dt_init.Rows[0]["in_TrckReject"].ToString();//Dispose
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
					if ((conn.GetFieldValue("ad_reject") == "1") && (groupid.Substring(0,2) != "01"))
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

				prod.NavigateUrl = conn.GetFieldValue("screenlink") + "?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text+"&prod="+l_prod+"&apptype="+l_apptype+"&mc="+mc.Text+"&prod_seq=" + l_prod_seq + "&teks=" + prod.Text + "&ket_code=" + _ket_code;
				prod.Target		 = "if2";

				this.tbl_prod.Rows.Add(new TableRow());
				this.tbl_prod.Rows[i].Cells.Add(new TableCell());
				this.tbl_prod.Rows[i].Cells[0].Controls.Add(prod);				
			}

			conn.ClearData();
	
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

			#region Approval_With_Picklist
			//Approve With
			conn.QueryString = "select userid, su_fullname from scuser where userid = '" + Session["UserID"].ToString() + "' ";
			conn.ExecuteQuery();			
			ddl_aprvwith.Items.Add(new ListItem(conn.GetFieldValue("su_fullname"),conn.GetFieldValue("userid")));
				
			#endregion

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
		}

		private bool isCanApprove2(string userid) 
		{
			bool canApprove = false;

			conn.QueryString = "exec APPROVALCOND_ISCANAPPROVE2 '" + Request.QueryString["regno"] + "', '" + userid + "'";
			conn.ExecuteQuery(300);

			if (conn.GetRowCount() > 0)
				if (conn.GetFieldValue("ISCANAPPROVE") == "1")
					canApprove = true;

			return canApprove;
		}

		private void approval2()
		{
			string var_eye, var_eye1, var_routingreject;
			
			//Get Approval Group/User
			conn.QueryString = "SELECT AP_APRVNEXTBY, AP_APRVCONDBY FROM APPLICATION WHERE AP_REGNO = '" + lbl_regno.Text + "'";
			conn.ExecuteQuery();
			string var_aprvnextby = conn.GetFieldValue("AP_APRVNEXTBY");
			string var_aprvcondby = conn.GetFieldValue("AP_APRVCONDBY");

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
			if (var_aprvnextby != var_aprvcondby)
			{
				//btn_aprvrej.Visible = false;
				tr_approve.Visible = false;
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

		protected void btn_aprvrej_Click(object sender, System.EventArgs e)
		{
			string var_check = "";
			
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
				if (!isCanApprove2(approval_user)) 
				{
					/// User's limit does not exceed application's limit
					/// 						
					GlobalTools.popMessage(this, "User can not approve. \\nApplication limit exceeds user limit!\\n");
					return;
				}
			}

			Response.Write("<script for=window event=onload language='javascript'>PopupPage('../VerifyUser.aspx?userid=" + approval_user + "&theForm=Form1&theObj=TXT_VERIFY', '400','170');</script>");
		}

		protected void TXT_VERIFY_TextChanged(object sender, System.EventArgs e)
		{
			if(this.TXT_VERIFY.Text != "")
			{
				this.TXT_VERIFY.Text = "";

				string var_kreditbaru, vAP_APRVCOMMITEE, vAP_APRVCOND;
				double var_emaslimit, var_adlimit;

				conn.QueryString = "SELECT ISNULL(AP_APRVEYES,'0') as AP_APRVEYES, " + 
					" ISNULL(AP_APRVCOMMITEE,'') AS AP_APRVCOMMITEE, " + 
					" ISNULL(AP_APRVCOND,'0') AS AP_APRVCOND " + 
					" FROM APPLICATION WHERE AP_REGNO = '" + lbl_regno.Text + "'";
				conn.ExecuteQuery();
				var_aprveye = conn.GetFieldValue("ap_aprveyes");
				vAP_APRVCOMMITEE = conn.GetFieldValue("AP_APRVCOMMITEE");
				vAP_APRVCOND = conn.GetFieldValue("AP_APRVCOND");

				conn.QueryString = "exec APPROVAL_CHECKHISTORY '" + lbl_regno.Text + "', '" + lbl_prod.Text + "', '" + lbl_apptype.Text + "', '" + lbl_userid.Text + "', '" + LBL_PROD_SEQ.Text + "'";
				conn.ExecuteQuery();
				Response.Write("<!-- query var_fromsta: " + conn.QueryString + " -->");
				string var_fromsta = conn.GetFieldValue("CNT_APPROVAL");

				conn.QueryString = "select * from vw_currtrack where ap_regno = '"+lbl_regno.Text+"'";
				conn.ExecuteQuery();
				Response.Write("<!-- query cnttrack: " + conn.QueryString + " -->");
				int cnttrack = conn.GetRowCount();

				conn.QueryString = "select * from approval_decision where ap_regno = '"+lbl_regno.Text+"' "+
					" and userid = '"+lbl_userid.Text+"' and ad_fromsta = '"+var_fromsta+"'";
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

						if (var_adlimit > var_emaslimit && vAP_APRVCOMMITEE.Trim() == "")
						{
							GlobalTools.popMessage(this, "Limit in rupiah cannot greater than eMas Limit");
							return;
						}
					}
				}

				conn.QueryString = "update application set ap_aprvremark = '"+txt_remark.Text+"' where ap_regno = '"+lbl_regno.Text+"'";
				conn.ExecuteQuery();

				if ((ddl_aprvwith.SelectedValue != "") || (var_aprveye == "0"))
				{
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
							catch (Exception ex)
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

				//check if there's any product reject
				/*
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
				*/

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
							conn.QueryString = "exec approval_proddecision '"+lbl_regno.Text+"', '"+var_prod+"', '"+var_apptype+"', '"+lbl_userid.Text+"', '1', '"+var_approve+"', '', '', '" + var_PROD_SEQ + "'";
							conn.ExecuteQuery();

							msg = "Application is Approved";
							
							conn.QueryString = "update approval_decision set ad_status = '1', ad_reject = '0' where ap_regno = '"+lbl_regno.Text+"' "+
								" and productid = '"+var_prod+"' and apptype = '"+var_apptype+"' and PROD_SEQ = '" + var_PROD_SEQ + "' " +
								" and userid = '"+lbl_userid.Text+"' ";
							conn.ExecuteQuery();
						}				
						else
						{
							//reject
						}
					}
					catch {}
				
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

				Response.Redirect("ListApprovalCondition.aspx?msg="+msg+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]);
			}
		}
	}
}
