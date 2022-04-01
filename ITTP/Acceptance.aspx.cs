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
namespace SME.ITTP
{
	/// <summary>
	/// Summary description for Acceptance.
	/// </summary>
	public partial class Acceptance : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
		string var_user, approval_user, var_groupid, groupid, var_approve;
		string var_reject, var_reject1, msg;
		DataTable dt_init	 = new DataTable();
		DataTable dt_aprvdec = new DataTable();


		protected void Page_Load(object sender, System.EventArgs e)
			
		{
			conn = (Connection) Session["Connection"];
		
			approval_user = Session["USERID"].ToString();  // user pengganti

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			ViewMenu();
			viewdata();

			if (!IsPostBack)
			{
				TR_INFO_CRM.Visible = false;

				fillAcquireInformation();
			}
	
			if (lbl_prod.Text == "CRP1")
			{ 
				//btn_info.Visible = false;
				btn_decision.Visible = false;
			}

			btn_aprvrej.Attributes.Add("onclick", "if(!continueApproval('Approve')) {return false;};");			
			btn_reject.Attributes.Add("onclick", "if(!continueApproval('Reject')) {return false;};");

			txt_aprvwith.Text = lbl_userid.Text;
			txt_aprvwith.Enabled = false;

			ddl_rjreason.Items.Add(new ListItem("-- Pilih --",""));
			conn.QueryString = "select REASONID, REASONTYPE, REASONID + ' - ' + REASONDESC AS REASONDESC, ACTIVE from RFREASON where reasontype = '0' and active = '1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount();i++)
				ddl_rjreason.Items.Add(new ListItem(conn.GetFieldValue(i,2),conn.GetFieldValue(i,0)));

		}

		private void fillAcquireInformation() 
		{			
			try 
			{
				conn.QueryString = "select AP_ACQINFO, isnull(AP_ACQINFOBY,'') as AP_ACQINFOBY from APPLICATION where AP_REGNO = '" + lbl_regno.Text + "'";
				conn.ExecuteQuery();

				txt_acqinfo.Text = conn.GetFieldValue("ap_acqinfo");
				
				if (conn.GetFieldValue("AP_ACQINFOBY") != "") 
				{
					TR_INFO_CRM.Visible = true;
				}
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
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
			this.TXT_VERIFY.TextChanged += new EventHandler(TXT_VERIFY_TextChanged);
			this.TXT_TEMP.TextChanged += new EventHandler(TXT_TEMP_TextChanged);
		}
		#endregion



		private void viewdata()
		{
			lbl_regno.Text	 = Request.QueryString["regno"];
			lbl_curef.Text	 = Request.QueryString["curef"];
			lbl_prod.Text	 = Request.QueryString["prod"];
			lbl_apptype.Text = Request.QueryString["apptype"];
			LBL_PROD_SEQ.Text = Request.QueryString["prod_seq"];
			lbl_track.Text	 = Request.QueryString["tc"];
			lbl_userid.Text	 = Session["USERID"].ToString();
			mc.Text			 = Request.QueryString["mc"];
			groupid			 = Session["GROUPID"].ToString();
			groupid			 = var_groupid;

			//initial
			conn.QueryString	= "select * from rfinitial";
			conn.ExecuteQuery();
			dt_init				= conn.GetDataTable().Copy();
			var_approve			= dt_init.Rows[0]["it_in_approve"].ToString();
			var_reject			= dt_init.Rows[0]["in_reject_it"].ToString();//Reject
			var_reject1			= dt_init.Rows[0]["in_TrckReject"].ToString();//Dispose

			//Get Applicant Product
			conn.QueryString = "select * from vw_it_currtrack2 "+
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
					if (conn.GetFieldValue("ad_reject") == "1")
					{
						//cbl_prod.Items[i].Selected = false;
						cbl_prodrej.Items.Add(new ListItem(dt_currtrack.Rows[i]["prodapptype"].ToString(), dt_currtrack.Rows[i]["prodapptypecode"].ToString()));
						cbl_prodrej.Items[cbl_prodrej_count].Selected = false;
						//cbl_prodrej.Enabled = false;
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

				prod.NavigateUrl = "ApprovalPermohonan.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text+"&prod="+l_prod+"&apptype="+l_apptype+"&mc="+mc.Text+"&prod_seq=" + l_prod_seq + "&teks=" + prod.Text + "&ket_code=" + _ket_code;
				prod.Target		 = "if2";

				this.tbl_prod.Rows.Add(new TableRow());
				this.tbl_prod.Rows[i].Cells.Add(new TableCell());
				this.tbl_prod.Rows[i].Cells[0].Controls.Add(prod);				
			}

			conn.QueryString = "exec IT_DE_CALCULATE_TOTALEXPOSURE '" + lbl_regno.Text + "', '" + lbl_curef.Text + "'";
			conn.ExecuteQuery();
			dt_aprvdec = conn.GetDataTable().Copy();
			if (dt_aprvdec.Rows.Count > 0)
			{
				lbl_limexp.Text		= tool.MoneyFormat(Convert.ToString(conn.GetFieldValue("GROUP_EXPOSURE")));
				lbl_reqlim.Text		= tool.MoneyFormat(conn.GetFieldValue("tot_limit"));
			}

			conn.ClearData();
		}
	

		protected void btn_aprvrej_Click(object sender, System.EventArgs e)
		{
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
				if (var_check == "0")
				{
					GlobalTools.popMessage(this, "Check the request to approve");
					return;
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
					GlobalTools.popMessage(this, "Uncheck request to reject");
					return;
				}
			}
			//SaveRemark();
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

			Response.Write("<script for=window event=onload language='javascript'>PopupPage('../VerifyUser.aspx?userid=" + approval_user + "&theForm=Form1&theObj=TXT_VERIFY', '400','170');</script>");
		}

		protected void btn_decision_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script for=window event=onload language='javascript'>PopupPage('ApprovalHistory.aspx?regno=" + lbl_regno.Text + "&curef=" + lbl_curef.Text + "', '800','300');</script>");
		}

		protected void btn_info_Click(object sender, System.EventArgs e)
		{
			preAcquireInfo();		

			Response.Write("<script for=window event=onload language='javascript'>PopupPage('AcqInfo.aspx?regno=" + lbl_regno.Text + "&curef=" + lbl_curef.Text + "&aprv=BU&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>");
		}

		private void preAcquireInfo() 
		{
			//
			// mengambil last status approval_decision
			//
			/*
			conn.QueryString = "select isnull(ap_isappeal,0) ap_isappeal from application where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();
			string var_fromsta = conn.GetFieldValue("ap_isappeal");
			*/
			conn.QueryString = "exec IT_APPROVAL_CHECKHISTORY2 '" + lbl_regno.Text + "', '" + lbl_prod.Text + "', '" + lbl_apptype.Text + "', '" + lbl_userid.Text + "', '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			string var_fromsta = conn.GetFieldValue("CNT_APPROVAL");

			
			conn.QueryString = "select * from vw_it_currtrack2 where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();
			int cnttrack = conn.GetRowCount();

			conn.QueryString = "select * from approval_decision where ap_regno = '"+lbl_regno.Text+"' "+
				" and userid = '" + lbl_userid.Text + "' and ad_fromsta = '"+var_fromsta+"'";
			conn.ExecuteQuery();
			int cntad = conn.GetRowCount();

			if (cnttrack != cntad)
			{
				GlobalTools.popMessage(this, "Check Approval Structure Credit First!");
				return;
			}
		}

		private void TXT_TEMP_TextChanged(object sender, EventArgs e)
		{
			if (TXT_TEMP.Text != "") 
			{
				string msg = "";
				msg = "Application acquire information from " + TXT_TEMP.Text + " !";
				Response.Redirect("ListReview.aspx?msg="+msg+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]);
			}
		}

		private void TXT_VERIFY_TextChanged(object sender, System.EventArgs e)
		{
			if(this.TXT_VERIFY.Text != "")
			{
				this.TXT_VERIFY.Text = "";
				
				conn.QueryString = "exec IT_APPROVAL_CHECKHISTORY2 '" + lbl_regno.Text + "', '" + lbl_prod.Text + "', '" + lbl_apptype.Text + "', '" + lbl_userid.Text + "', '" + LBL_PROD_SEQ.Text + "'";
				conn.ExecuteQuery();
				Response.Write("<!-- query var_fromsta: " + conn.QueryString + " -->");
				string var_fromsta = conn.GetFieldValue("CNT_APPROVAL");

				conn.QueryString = "select * from vw_it_currtrack2 where ap_regno = '"+lbl_regno.Text+"'";
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
					GlobalTools.popMessage(this, "Check Approval Structure First!");
					return;
				}


				//conn.QueryString = "select * from vw_currtrack where ap_regno = '"+lbl_regno.Text+"' and isnull(cp_decsta,'') <> '"+var_reject+"'";
				conn.QueryString = "select * from vw_it_currtrack2 where ap_regno = '"+lbl_regno.Text+"' and isnull(cp_decsta,'') not in ('"+var_reject+"', '"+var_reject1+"')";
				conn.ExecuteQuery();
				DataTable dt_currtrack = new DataTable();
				dt_currtrack = conn.GetDataTable().Copy();
				/*			
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
										//if (var_adlimit > var_emaslimit && vAP_APRVCOMMITEE.Trim() == "" && addcheck.Trim() == "FALSE")
										//{
										//	GlobalTools.popMessage(this, "Limit in rupiah cannot greater than eMas Limit");
										//	return;
										//}
									}
								}
				*/
				// Button check Prevoius
				/*
								conn.QueryString = "update application set ap_aprvremark = '"+txt_remark.Text+"' where ap_regno = '"+lbl_regno.Text+"'";
								conn.ExecuteQuery();
				*/			
				if ((txt_aprvwith.Text != "")) //|| (var_aprveye == "0"))
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
						string var_product, var_apptype1, var_tenorcode, var_prod_seq;//, var_rateno, var_varcode, var_graceperiode,  var_maturitydate;
						string var_ovrreason, var_ovrreasontext, var_ovrsta, var_decsta;// var_remark, var_payment
						double var_limit, var_variance, var_exlimitval;// var_interest, var_installment, var_exrplimit;
						int var_tenor;

						var_tenor = 0;
						//var_maturitydate = null;

						var_product			= dt_aprvdec.Rows[j]["productid"].ToString();
						var_apptype1		= dt_aprvdec.Rows[j]["apptype"].ToString();
						var_prod_seq		= dt_aprvdec.Rows[j]["prod_seq"].ToString();
						var_limit			= double.Parse(dt_aprvdec.Rows[j]["ad_limit"].ToString());
						//try {var_tenor	= int.Parse(dt_aprvdec.Rows[j]["ad_tenor"].ToString());}
						var_tenor			= int.Parse(dt_aprvdec.Rows[j]["ad_tenor"].ToString());
						//catch {var_maturitydate	= dt_aprvdec.Rows[j]["ad_maturitydate"].ToString();}
						var_tenorcode		= dt_aprvdec.Rows[j]["ad_tenorcode"].ToString();
						//var_interest		= double.Parse(dt_aprvdec.Rows[j]["ad_interest"].ToString());
						//var_rateno		= dt_aprvdec.Rows[j]["ad_rateno"].ToString();
						//var_varcode		= dt_aprvdec.Rows[j]["ad_varcode"].ToString();
						//var_variance		= double.Parse(dt_aprvdec.Rows[j]["ad_variance"].ToString());
						var_ovrsta			= dt_aprvdec.Rows[j]["ad_ovrsta"].ToString();
						var_ovrreason		= dt_aprvdec.Rows[j]["ad_ovrreason"].ToString();
						var_ovrreasontext	= dt_aprvdec.Rows[j]["ad_ovrreasontext"].ToString();
						//var_remark		= dt_aprvdec.Rows[j]["ad_keterangan"].ToString();
						//var_installment	= double.Parse(dt_aprvdec.Rows[j]["ad_installment"].ToString());
						var_decsta			= dt_aprvdec.Rows[j]["ad_reject"].ToString();
						var_exlimitval		= double.Parse(dt_aprvdec.Rows[j]["ad_exlimitval"].ToString());
						//var_exrplimit		= double.Parse(dt_aprvdec.Rows[j]["ad_exrplimit"].ToString());
						var_fromsta			= dt_aprvdec.Rows[j]["ad_fromsta"].ToString();
						//var_graceperiode	= dt_aprvdec.Rows[j]["ad_graceperiod"].ToString();
						//var_payment		= dt_aprvdec.Rows[j]["ad_paymentid"].ToString();						

						//string s_var_maturitydate = "";
						//if (var_maturitydate != null) s_var_maturitydate = GlobalTools.ToSQLDate(var_maturitydate);

						if (txt_aprvwith.Text != "") 
						{
							if (txt_aprvwith.Text != lbl_userid.Text)
							{
								try 
								{
									conn.QueryString = "exec input_approvaldecision3  '"+lbl_regno.Text+"', '"+var_product+"', "+
										" '"+var_apptype1+"', '"+txt_aprvwith.Text+"', "+
										" '"+var_limit+"', '"+var_tenor+"','"+var_tenorcode+"', "+
										//" "+tool.ConvertFloat(var_interest.ToString())+", '"+var_rateno+"', '"+var_varcode+"', "+tool.ConvertFloat(var_variance.ToString())+", "+
										" '"+var_ovrreason+"', '"+var_ovrreasontext+"', "+//'"+var_remark+"', "+tool.ConvertFloat(var_installment.ToString())+", "+
										" '"+var_ovrsta+"', '"+var_decsta+"', "+tool.ConvertFloat(var_exlimitval.ToString())+", "+
										//" "+tool.ConvertFloat(var_exrplimit.ToString())+", 
										" '"+var_fromsta+"', "+
										//" "+tool.ConvertNum(var_graceperiode)+", '"+var_payment+"', "+
										" '" + var_prod_seq + "'";//, " + s_var_maturitydate + "";
									conn.ExecuteQuery();
								} 
								catch 
								{
									conn.QueryString = "exec input_approvaldecision3  '"+lbl_regno.Text+"', '"+var_product+"', "+
										" '"+var_apptype1+"', '"+txt_aprvwith.Text+"', "+
										" '"+var_limit+"', '"+var_tenor+"','"+var_tenorcode+"', "+
										//" "+tool.ConvertFloat(var_interest.ToString())+", '"+var_rateno+"', '"+var_varcode+"', "+tool.ConvertFloat(var_variance.ToString())+", "+
										" '"+var_ovrreason+"', '"+var_ovrreasontext+"', "+//'"+var_remark+"', "+tool.ConvertFloat(var_installment.ToString())+", "+
										" '"+var_ovrsta+"', '"+var_decsta+"', "+tool.ConvertFloat(var_exlimitval.ToString())+", "+
										//" "+tool.ConvertFloat(var_exrplimit.ToString())+", 
										" '"+var_fromsta+"', "+
										//" "+tool.ConvertNum(var_graceperiode)+", '"+var_payment+"', "+
										" '" + var_prod_seq + "'";//, " + s_var_maturitydate + "";
									conn.ExecuteQuery();
								}
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
				/*
								conn.QueryString = "select ap_aprveyes from application where ap_regno = '"+lbl_regno.Text+"'";
								conn.ExecuteQuery();
								var_aprveye = conn.GetFieldValue("ap_aprveyes");
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

				//if (var_check == "1")
				//{
/*
				for (int i = 0; i < dt_currtrack.Rows.Count;i++) 
				{
					string var_apptype		= dt_currtrack.Rows[i]["apptype"].ToString();
					string var_prod			= dt_currtrack.Rows[i]["productid"].ToString();
					string var_currtrack	= dt_currtrack.Rows[i]["ap_currtrack"].ToString();
					string var_PROD_SEQ 	= dt_currtrack.Rows[i]["PROD_SEQ"].ToString();
					try
					{
						/*
						conn.QueryString = "select * from vw_it_currtrack2 "+
							" where ap_regno = '"+lbl_regno.Text+"' ";
						conn.ExecuteQuery();
						DataTable dt_currtrackt = new DataTable();
						dt_currtrackt		   = conn.GetDataTable().Copy();
						*/
			
//						if (cbl_prod.Items[i].Selected)
						//for (int i = 0; i < row; i++)
//			{
				//string l_prod		= dt_currtrack.Rows[i]["productid"].ToString();
				//string l_apptype	= dt_currtrack.Rows[i]["apptype"].ToString();
				//string l_prod_seq	= dt_currtrack.Rows[i]["prod_seq"].ToString();
				/*
											conn.QueryString = "exec ITTP_ACCEPT2 '" + 
												Request.QueryString["regno"] + "', '" +
												var_prod + "', '" +
												var_apptype + "', '" +
												Request.QueryString["tc"] + "', '" +
												Session["UserID"].ToString() + "', '" +
												var_PROD_SEQ +"'";
											conn.ExecuteQuery();
										}
										//string msg = conn.GetFieldValue("MSG");

										//Response.Redirect("SearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
										//	"&mc=" + Request.QueryString["mc"] + 
										//	"&msg=" + msg +
										//	"&scr=" + Request.QueryString["scr"]);
									}
									catch (Exception ex)
									{
										Response.Write("<!--" + ex.Message + "-->");
									}
								}
				*/				//}



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
							conn.QueryString = "exec ITTP_ACCEPT2 '" + 
								Request.QueryString["regno"] + "', '" +
								var_prod + "', '" +
								var_apptype + "', '" +
								Request.QueryString["tc"] + "', '" +
								Session["UserID"].ToString() + "', '" +
								var_PROD_SEQ +"'";
							conn.ExecuteQuery();

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
									conn.QueryString = "exec it_approval_proddecision '"+lbl_regno.Text+"', '"+var_prod+"', '"+var_apptype+"', '"+lbl_userid.Text+"', '0', '"+var_reject1+"', '"+ddl_rjreason.SelectedValue.ToString()+"', '"+txt_rjreason.Text+"', '" + var_PROD_SEQ + "'";
									conn.ExecuteQuery();
								}
								else 
								{
									conn.QueryString = "exec it_approval_proddecision '"+lbl_regno.Text+"', '"+var_prod+"', '"+var_apptype+"', '"+lbl_userid.Text+"', '0', '"+var_reject+"', '"+ddl_rjreason.SelectedValue.ToString()+"', '"+txt_rjreason.Text+"', '" + var_PROD_SEQ + "'";
									conn.ExecuteQuery();
								}

							//	DataTable dt;
							//	conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + Request.QueryString["regno"] +"'";
								//					"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
							//	conn.ExecuteQuery();
							//	dt = conn.GetDataTable().Copy();
							//	for (int i = 0; i < dt.Rows.Count; i++)
							//	{
									// tracupdate execution
							conn.QueryString = "exec IT_TRACK_REJECT_UPDATE '" + 
								Request.QueryString["regno"] + "', '" +	// AP_REGNO
								var_prod + "', '" +		// PRODUCTID
								var_apptype + "', '" +		// APPTYPE
								Session["UserID"].ToString() + "', '" +				// USERID
								var_PROD_SEQ + "'";
							//,"+ // PROD_SEQ "'"+Request.QueryString["tc"].Trim()+"'";// PAGE TRACK
							conn.ExecuteNonQuery();
							//	}

							conn.QueryString = "update approval_decision set ad_status = '2', ad_reject = '1' where ap_regno = '"+lbl_regno.Text+"' "+
								" and productid = '"+var_prod+"' and apptype = '"+var_apptype+"' and PROD_SEQ = '" + var_PROD_SEQ + "' " +
								" and userid = '"+lbl_userid.Text+"' ";                                                                                                                                                                                                                                                                                  
							conn.ExecuteQuery();
							}
						}
					}
					catch {}
				
					//check if all product reject then application is rejected
					conn.QueryString = "select * from vw_it_currtrack2 where ap_regno = '"+lbl_regno.Text+"'";
					conn.ExecuteQuery();
					int cntprod = conn.GetRowCount();

					conn.QueryString = "select * from vw_it_currtrack2 where ap_regno = '"+lbl_regno.Text+"' and cp_decsta = '"+var_reject+"'";
					conn.ExecuteQuery();
					int cntprodrej = conn.GetRowCount();

					if (cntprod == cntprodrej)
					{
						conn.QueryString = "update application set ap_reject = '1' where ap_regno = '"+lbl_regno.Text+"'";
						conn.ExecuteQuery();	
						conn.QueryString = "update custproduct set cp_reject = '1' where ap_regno = '"+lbl_regno.Text+"'";
						conn.ExecuteQuery();	
					}

				}	
			}
			Response.Redirect("ListReview.aspx?msg="+msg+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]);
		}

	}
}
