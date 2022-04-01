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
	/// Summary description for ApprvPeriodicScoring.
	/// </summary>
	public class ApprvPeriodicScoring : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LBL_PRODUCT;
		protected System.Web.UI.WebControls.TextBox txt_tenor;
		protected System.Web.UI.WebControls.TextBox txt_fix;
		protected System.Web.UI.WebControls.DropDownList ddl_rate;
		protected System.Web.UI.WebControls.TextBox txt_rate;
		protected System.Web.UI.WebControls.DropDownList ddl_varcode;
		protected System.Web.UI.WebControls.TextBox txt_variance;
		protected System.Web.UI.WebControls.TextBox txt_installment;
		protected System.Web.UI.WebControls.TextBox txt_purpose;
		protected System.Web.UI.WebControls.TextBox txt_sifat;
		protected System.Web.UI.WebControls.TextBox txt_totcoll;
		protected System.Web.UI.WebControls.TextBox txt_exrplimit;
		protected System.Web.UI.WebControls.TextBox txt_exlimitval;
		protected System.Web.UI.WebControls.Label lbl_exlimitval;
		protected System.Web.UI.WebControls.TextBox txt_remark;
		protected System.Web.UI.HtmlControls.HtmlTable kreditAwal;
		protected System.Web.UI.HtmlControls.HtmlTableRow tr_fix;
		protected System.Web.UI.HtmlControls.HtmlTableRow tr_float;
		protected System.Web.UI.WebControls.Label lbl_decsta;
		protected System.Web.UI.WebControls.TextBox TXT_LIMIT;
		protected System.Web.UI.WebControls.DropDownList DDL_CP_LOANPURPOSE;
		protected System.Web.UI.WebControls.TextBox txt_decsta;
		protected System.Web.UI.WebControls.TextBox txt_decovrsta;
		protected System.Web.UI.WebControls.DropDownList ddl_decovrreason;
		protected System.Web.UI.WebControls.TextBox txt_decovrreason;
		protected System.Web.UI.WebControls.TextBox txt_decremark;
		protected System.Web.UI.WebControls.TextBox txt_limit;
		protected System.Web.UI.WebControls.TextBox txt_tenor_year;
		protected System.Web.UI.WebControls.TextBox txt_tenor_day;
		protected System.Web.UI.WebControls.DropDownList ddl_tenor_month;
		protected System.Web.UI.WebControls.Label LBL_IDC_RATIO;
		protected System.Web.UI.WebControls.Label LBL_IDC_JWAKTU;
		protected System.Web.UI.WebControls.Label LBL_IDC_CAPRATIO;
		protected System.Web.UI.WebControls.DropDownList ddl_idcprimevar;
		protected System.Web.UI.WebControls.DropDownList ddl_idcvarcode;
		protected System.Web.UI.WebControls.Label LBL_IDC_VARIANCE;
		protected System.Web.UI.WebControls.DropDownList ddl_idcinttype;
		protected System.Web.UI.WebControls.Label LBL_IDC_PRIMEVAR;
		protected System.Web.UI.WebControls.Label LBL_IDC_CAPAMNT;
		protected System.Web.UI.WebControls.TextBox TXT_CP_CUREF;
		protected System.Web.UI.WebControls.Label LBL_RATENO;
		protected System.Web.UI.WebControls.Label LBL_APPTYPE;
		protected System.Web.UI.WebControls.Label LBL_PRODUCT_DESC;
		protected System.Web.UI.WebControls.Label LBL_REVOLVING;
		protected System.Web.UI.WebControls.Label LBL_CURRENCY;
		protected System.Web.UI.WebControls.Label LBL_CP_LIMIT;
		protected System.Web.UI.WebControls.TextBox TXT_OLDTENOR;
		protected System.Web.UI.WebControls.Label LBL_OLDTENOR;
		protected System.Web.UI.WebControls.TextBox TXT_CP_KETERANGAN;
		protected System.Web.UI.WebControls.DropDownList DDL_CP_NOREK;
		protected System.Web.UI.WebControls.Label LBL_ACC_NO;
		protected System.Web.UI.WebControls.Label lbl_usergroup;
		protected System.Web.UI.WebControls.TextBox TXT_NEGATIVE;
		protected System.Web.UI.WebControls.Button btn_override;
		protected System.Web.UI.HtmlControls.HtmlTable tbl_idc;
		protected System.Web.UI.HtmlControls.HtmlInputButton BTN_EBIZCARD;
		protected System.Web.UI.HtmlControls.HtmlTableRow tr_install;
		#region " My Variables "
		private Connection conn;
		private Tools tool = new Tools();
		private string REGNO, CUREF, PRODUCT, APPTYPE, TC, USERID, MC, PROD_SEQ, var_fromsta, STA, AD_SEQ, KET_CODE;
		#endregion
		protected System.Web.UI.WebControls.TextBox txt_tenorcode;
		protected System.Web.UI.WebControls.TextBox txt_tenorcodedesc;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			REGNO		= Request.QueryString["regno"];
			CUREF		= Request.QueryString["curef"];
			PRODUCT		= Request.QueryString["prod"];
			APPTYPE		= Request.QueryString["apptype"];
			TC			= Request.QueryString["tc"];
			USERID		= Session["USERID"].ToString();
			MC			= Request.QueryString["mc"];
			PROD_SEQ	= Request.QueryString["prod_seq"];
			STA			= Request.QueryString["sta"];
			AD_SEQ		= Request.QueryString["ad_seq"];
			KET_CODE	= Request.QueryString["ket_code"];

			if (!IsPostBack) 			
			{
				kreditAwal.Visible	= false;
				tbl_idc.Visible		= false;
				initializeDropDowns();
				
				viewDataGeneral();
				
				if(STA=="view") viewData2();
				else viewData();

				secureData(); 
			}

			btn_override.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1)){return false;};");
			initializeEvents();
		}

		private void initializeEvents() 
		{
			this.btn_override.Click += new EventHandler(btn_override_Click);
		}

		private void initializeDropDowns() 
		{
			conn.QueryString = "select aa_no, cu_ref from application where ap_regno='"+REGNO+"'";
			conn.ExecuteQuery();
			string aa_no		= conn.GetFieldValue("aa_no");
			//TXT_CP_CUREF.Text	= conn.GetFieldValue("cu_ref");

			if (STA == "view") GlobalTools.fillRefList(ddl_decovrreason, "select reasonid, reasondesc from RFREASON where reasontype = '2'", false, conn);
			else GlobalTools.fillRefList(ddl_decovrreason, "select reasonid, reasondesc from RFREASON where reasontype = '2' and active = '1'", false, conn);

			if (STA == "view") GlobalTools.fillRefList(DDL_CP_LOANPURPOSE, "select LOANPURPID, LOANPURPDESC from RFLOANPURPOSE order by LOANPURPID", true, conn);
			else GlobalTools.fillRefList(DDL_CP_LOANPURPOSE, "select LOANPURPID, LOANPURPDESC from RFLOANPURPOSE where ACTIVE='1' order by LOANPURPID", true, conn);

			if (STA == "view") GlobalTools.fillRefList(ddl_idcprimevar, "select rateno, rate from RFRATENUMBER", false, conn);			
			else GlobalTools.fillRefList(ddl_idcprimevar, "select rateno, rate from RFRATENUMBER where active = '1'", false, conn);

			GlobalTools.fillRefList(DDL_CP_NOREK, "select acc_seq, acc_no from BOOKEDPROD where productid='"+PRODUCT+"' and aa_no='"+aa_no+"'", false, conn);
			GlobalTools.initDateForm(txt_tenor_day, ddl_tenor_month, txt_tenor_year, true);
		}

		private void viewDataGeneral() 
		{
			conn.QueryString="select APPTYPEDESC, PRODUCTDESC, CP_LOANPURPOSE, "+
				"CP_LIMIT, CP_installment, AA_NO, ACC_SEQ, "+
				"CP_KETERANGAN, ACC_NO, CP_VARCODE, CP_RATENO, CP_VARIANCE,PROJECT_CODE, "+
				"REVOLVING, CURRENCY, NEWVALUE, NEWCODE, OLDVALUE, OLDCODE, b.tenordesc "+
				", CP_DECSTA, AD_VARCODE, AD_VARIANCE, AD_RATENO, CP_MATURITYDATE, PRJ_NAME, EARMARK_AMOUNT_PRJ "+
				"from VW_CUSTPRODUCT a "+
				"left join RFTENORCODE B on B.TENORCODE=A.OLDCODE "+
				"where AP_REGNO='"+ REGNO +"' and PRODUCTID='"+ PRODUCT +"' and APPTYPE='"+ APPTYPE +"' and PROD_SEQ = '" + PROD_SEQ + "'";
			conn.ExecuteQuery();
			LBL_APPTYPE.Text		= conn.GetFieldValue("APPTYPEDESC");
			LBL_PRODUCT_DESC.Text	= conn.GetFieldValue("PRODUCTDESC");
			TXT_CP_KETERANGAN.Text	= conn.GetFieldValue("CP_KETERANGAN");
			LBL_REVOLVING.Text		= conn.GetFieldValue("REVOLVING");
			LBL_CURRENCY.Text		= conn.GetFieldValue("CURRENCY");
			//TXT_OLDTENOR.Text		= conn.GetFieldValue("OLDVALUE");
			//LBL_OLDTENOR.Text		= conn.GetFieldValue("TENORDESC");
			LBL_ACC_NO.Text			= conn.GetFieldValue("ACC_NO");
			string CP_DECSTA		= conn.GetFieldValue("CP_DECSTA");
			string AD_VARCODE		= conn.GetFieldValue("AD_VARCODE");
			string AD_VARIANCE		= conn.GetFieldValue("AD_VARIANCE");
			string AD_RATENO		= conn.GetFieldValue("AD_RATENO");

			if (!conn.GetFieldValue("CP_LOANPURPOSE").Equals("")) 
			{
				try { DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue("CP_LOANPURPOSE"); } 
				catch {}
			}
			string seq = conn.GetFieldValue("ACC_SEQ");
			for (int g=0; g<DDL_CP_NOREK.Items.Count; g++) 
			{
				if (DDL_CP_NOREK.Items[g].Value.ToString()== seq.ToString()) 
				{
					try { DDL_CP_NOREK.SelectedValue = seq; } 
					catch {}
				}
			}
			string AA_NO	= conn.GetFieldValue("AA_NO");
			string ACC_SEQ	= conn.GetFieldValue("ACC_SEQ");

			conn.ClearData();

			//--- Mengambil limit
			conn.QueryString = "SELECT LIMIT, TENOR FROM BOOKEDPROD WHERE AA_NO='"+AA_NO+"' AND ACC_SEQ="+GlobalTools.ConvertNum(ACC_SEQ)+" AND PRODUCTID='"+PRODUCT+"'";
			conn.ExecuteQuery();
			LBL_CP_LIMIT.Text				= GlobalTools.MoneyFormat(conn.GetFieldValue("LIMIT"));			
			TXT_OLDTENOR.Text				= conn.GetFieldValue("TENOR");
			LBL_PRODUCT.Text				= Request.QueryString["teks"];
			

			conn.ClearData();
		}

		private void viewData() 
		{
			////////////////////////////////////////////////////////////////////////////////////////////////////
			///	Get Credit Info Data
			///	

			/*
			conn.QueryString = "select isnull(ap_isappeal,0) ap_isappeal from application where ap_regno = '"+REGNO+"'";
			conn.ExecuteQuery();
			var_fromsta = conn.GetFieldValue("ap_isappeal");
			*/
			conn.QueryString = "exec APPROVAL_CHECKHISTORY '" + REGNO + "', '" + PRODUCT + "', '" + APPTYPE + "', '" + USERID + "', '" + PROD_SEQ + "'";
			conn.ExecuteQuery();
			DataTable dt_chk = conn.GetDataTable().Copy();

			var_fromsta = conn.GetFieldValue("CNT_APPROVAL");

			//
			// berarti dipanggil dari approval decision history 
			//
			if (AD_SEQ != "" && AD_SEQ != null) 
			{
				conn.QueryString = "select * from approval_decision where ap_regno = '" + REGNO + "' "+
					" and productid = '" + PRODUCT + 
					"' and apptype = '" + APPTYPE + "' "+
					" and PROD_SEQ = '" + PROD_SEQ + 
					//"' and ad_fromsta = '" + var_fromsta +  // tidak diperlukan, sudah ada AD_SEQ !
					"' and ad_seq = '" + AD_SEQ + "'";
				conn.ExecuteQuery();

				//////////////////////////////////////////////////
				/// Mengambil AD_FROMSTA yang bersangkutan aja
				/// 
				var_fromsta = conn.GetFieldValue("ad_fromsta");
			}
			else 
			{
				AD_SEQ = "";

				conn.QueryString = "select * from approval_decision where ap_regno = '" + REGNO + "' "+
					" and productid = '" + PRODUCT + "' and apptype = '" + APPTYPE + "' "+
					" and PROD_SEQ = '" + PROD_SEQ + "' and ad_fromsta = '" + var_fromsta + "' ";
				conn.ExecuteQuery();
			}

			DataTable dt_ad = new DataTable();
			dt_ad = conn.GetDataTable().Copy();

			conn.QueryString	= "exec approval_info '"+REGNO+"', '"+PRODUCT+"', '"+APPTYPE+"', '"+USERID+"', '"+var_fromsta+"' , '" + PROD_SEQ + "', " + GlobalTools.ConvertNull(AD_SEQ);
			conn.ExecuteQuery();
			DataTable dt_aprvinfo = new DataTable();
			dt_aprvinfo = conn.GetDataTable().Copy();

			if (dt_aprvinfo.Rows.Count != 0)
			{
				txt_limit.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
				txt_tenor.Text				= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
				txt_tenorcode.Text			= dt_aprvinfo.Rows[0]["cp_tenorcode"].ToString();
				txt_tenorcodedesc.Text		= dt_aprvinfo.Rows[0]["cp_tenorcodedesc"].ToString();
				txt_purpose.Text			= dt_aprvinfo.Rows[0]["cp_loanpurpdesc"].ToString(); 
				txt_sifat.Text				= dt_aprvinfo.Rows[0]["cp_skreditdesc"].ToString(); 
				txt_fix.Text				= dt_aprvinfo.Rows[0]["cp_interest"].ToString(); 
				ddl_rate.SelectedValue		= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim();
				try
				{txt_rate.Text			= Convert.ToString(double.Parse(ddl_rate.SelectedItem.Text) * 100);} 
				catch 
				{txt_rate.Text			= "";}
				ddl_varcode.SelectedValue	= dt_aprvinfo.Rows[0]["cp_varcode"].ToString().Trim(); 
				txt_variance.Text			= dt_aprvinfo.Rows[0]["cp_variance"].ToString(); 
				txt_totcoll.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["lc_value"].ToString()); 
				txt_remark.Text				= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString(); 
				txt_installment.Text		= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_installment"].ToString()); 
				txt_exlimitval.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 
				txt_exrplimit.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 
				try 
				{GlobalTools.fromSQLDate(dt_aprvinfo.Rows[0]["cp_maturitydate"].ToString(), txt_tenor_day, ddl_tenor_month, txt_tenor_year);}
				catch {}
				
				if (dt_ad.Rows.Count == 0)
				{
					//input approval decision
					if (PRODUCT != "")
					{
						conn.QueryString = "exec input_approvaldecision  '"+REGNO+"', '"+PRODUCT+"', "+
							" '"+APPTYPE+"', '"+USERID+"', "+
							" "+tool.ConvertFloat(txt_limit.Text)+", "+tool.ConvertNull(txt_tenor.Text)+","+tool.ConvertNull(txt_tenorcode.Text)+", "+
							" "+tool.ConvertFloat(txt_fix.Text)+", '"+txt_rate.Text+"', '"+ddl_rate.SelectedValue+"', "+ GlobalTools.ConvertFloat(txt_variance.Text) +", "+
							" '', '', '"+TXT_CP_KETERANGAN.Text+"', "+tool.ConvertFloat(txt_installment.Text)+", '0', '"+lbl_decsta.Text+"', "+
							" "+tool.ConvertFloat("")+", "+tool.ConvertFloat("")+", '"+var_fromsta+"', "+
							" null, null, '" + PROD_SEQ + "'";
						conn.ExecuteQuery();
					}
				}
				else if (dt_aprvinfo.Rows[0]["userid"].ToString() == "")
				{
					conn.QueryString = "select * from approval_decision where ap_regno = '"+REGNO+"' "+
						" and productid = '"+PRODUCT+"' and apptype = '"+APPTYPE+"' and PROD_SEQ = '" + PROD_SEQ + "' " +
						" and ad_seq = (select max(ad_seq) from approval_decision ad where approval_decision.ap_regno = ad.ap_regno "+
						" and approval_decision.productid = ad.productid and approval_decision.apptype = ad.apptype and approval_decision.PROD_SEQ = ad.PROD_SEQ) ";
					conn.ExecuteQuery();

					lbl_decsta.Text					= conn.GetFieldValue("ad_reject");
					if (lbl_decsta.Text == "0")
						txt_decsta.Text				= "APPROVE BY PREVIOUS USER";
					else if (lbl_decsta.Text == "1")
						txt_decsta.Text				= "REJECT BY PREVIOUS USER";
					//					txt_decexlimitval.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_exlimitval")); 
					//					txt_decexrplimit.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_exrplimit")); 
					//					txt_declimitchg.Text			= dt_aprvinfo.Rows[0]["cp_limitchg"].ToString();
					//					txt_decgraceperiode.Text		= conn.GetFieldValue("ad_graceperiod"); 
					//					ddl_decpayfreq.SelectedValue	= conn.GetFieldValue("ad_paymentid"); 

					//input approval decision
					if (PRODUCT != "")
					{
						conn.QueryString = "exec input_approvaldecision  '"+REGNO+"', '"+PRODUCT+"', "+
							" '"+APPTYPE+"', '"+USERID+"', "+
							" "+tool.ConvertFloat(txt_limit.Text)+", "+tool.ConvertNull(txt_tenor.Text)+","+tool.ConvertNull(txt_tenorcode.Text)+", "+
							" "+tool.ConvertFloat(txt_fix.Text)+", '"+txt_rate.Text+"', '"+ddl_varcode.SelectedValue+"', "+tool.ConvertFloat(txt_variance.Text)+", "+
							" '"+ddl_decovrreason.SelectedValue+"', '"+txt_decovrreason.Text+"', '"+TXT_CP_KETERANGAN.Text+"', "+
							" "+tool.ConvertFloat(txt_installment.Text)+", '0', '"+lbl_decsta.Text+"', "+
							" "+tool.ConvertFloat("")+", "+tool.ConvertFloat("")+", '"+var_fromsta+"', "+
							" null, null, '" + PROD_SEQ + "'";
						conn.ExecuteQuery();
					}
				}
				else if (conn.GetFieldValue("userid") != "")
				{
					///////////////////////////////////////////////////////////////////////////////////
					/// Check between approval_decision (history) with trackhistory
					/// 
					if (dt_chk.Rows[0]["SAME_STATUS"].ToString() == "YES") 
					{
						txt_decovrsta.Text				= dt_aprvinfo.Rows[0]["ad_ovrsta"].ToString();
						ddl_decovrreason.SelectedValue	= dt_aprvinfo.Rows[0]["ad_ovrreason"].ToString().Trim();
						txt_decovrreason.Text			= dt_aprvinfo.Rows[0]["ad_ovrreasontext"].ToString();
						TXT_CP_KETERANGAN.Text			= dt_aprvinfo.Rows[0]["ad_keterangan"].ToString();
						txt_decsta.Text					= dt_aprvinfo.Rows[0]["ad_rejectdesc"].ToString();
						lbl_decsta.Text					= dt_aprvinfo.Rows[0]["ad_reject"].ToString();
					} 
					else 
					{
						LBL_RATENO.Text					= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim(); 
						TXT_CP_KETERANGAN.Text			= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString();					

						///////////////////////////////////////////////////////////////////////////////////////
						/// Insert a new record into approval_decision with an increment on ad_fromsta field
						/// 
						string ad_fromsta_new = "";
						int _ad_fromsta = 0;
						try { _ad_fromsta = Convert.ToInt16(var_fromsta) + 1; } 
						catch {}
						ad_fromsta_new = _ad_fromsta.ToString();

						if (PRODUCT != "")
						{
							conn.QueryString = "exec input_approvaldecision  '"+REGNO+"', '"+PRODUCT+"', "+
								" '"+APPTYPE+"', '"+USERID+"', "+
								" "+tool.ConvertFloat(txt_limit.Text)+", "+tool.ConvertNull(txt_tenor.Text)+","+tool.ConvertNull(txt_tenorcode.Text)+", "+
								" "+tool.ConvertFloat(txt_fix.Text)+", '"+txt_rate.Text+"', '"+ddl_rate.SelectedValue+"', "+txt_variance.Text+", "+
								" '', '', '"+TXT_CP_KETERANGAN.Text+"', "+tool.ConvertFloat(txt_installment.Text)+", '0', '"+lbl_decsta.Text+"', "+
								" "+tool.ConvertFloat("")+", "+tool.ConvertFloat("")+", '"+ad_fromsta_new+"', "+
								" null, null, '" + PROD_SEQ + "'";
							conn.ExecuteQuery();
						}
					}
				}

				LBL_IDC_RATIO.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["idc_ratio"].ToString());	
				LBL_IDC_JWAKTU.Text				= dt_aprvinfo.Rows[0]["idc_jwaktu"].ToString();
				LBL_IDC_CAPRATIO.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["idc_capratio"].ToString());
				LBL_IDC_CAPAMNT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["idc_capamnt"].ToString());
				ddl_idcinttype.SelectedValue	= dt_aprvinfo.Rows[0]["idc_interesttype"].ToString().Trim();
				if (ddl_idcinttype.SelectedValue == "01")
				{
					ddl_idcprimevar.SelectedValue	= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim();
					try
					{LBL_IDC_PRIMEVAR.Text			= Convert.ToString(double.Parse(ddl_idcprimevar.SelectedItem.Text) * 100);}
					catch
					{LBL_IDC_PRIMEVAR.Text = "";}
					ddl_idcvarcode.SelectedValue	= dt_aprvinfo.Rows[0]["idc_varcode"].ToString().Trim();
					LBL_IDC_VARIANCE.Text			= dt_aprvinfo.Rows[0]["idc_variance"].ToString();
				}
				else if (ddl_idcinttype.SelectedValue == "02")
				{
					LBL_IDC_VARIANCE.Text			= dt_aprvinfo.Rows[0]["idc_interest"].ToString();
				}
				conn.ClearData();
			}
		}

		private void viewData2()
		{
			conn.QueryString	= "exec approval_info_view2 '"+REGNO+"', '"+PRODUCT+"', '"+APPTYPE+"', '"+USERID+"', '" + PROD_SEQ + "'";
			conn.ExecuteQuery();
			DataTable dt_aprvinfo = new DataTable();
			dt_aprvinfo = conn.GetDataTable().Copy();

			if (dt_aprvinfo.Rows.Count != 0)
			{
				txt_limit.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
				txt_tenor.Text				= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
				txt_tenorcode.Text			= dt_aprvinfo.Rows[0]["cp_tenorcode"].ToString();
				txt_tenorcodedesc.Text		= dt_aprvinfo.Rows[0]["cp_tenorcodedesc"].ToString();
				txt_purpose.Text			= dt_aprvinfo.Rows[0]["cp_loanpurpdesc"].ToString(); 
				txt_sifat.Text				= dt_aprvinfo.Rows[0]["cp_skreditdesc"].ToString(); 
				txt_fix.Text				= dt_aprvinfo.Rows[0]["cp_interest"].ToString(); 
				ddl_rate.SelectedValue		= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim();
				try
				{txt_rate.Text			= Convert.ToString(double.Parse(ddl_rate.SelectedItem.Text) * 100);} 
				catch 
				{txt_rate.Text			= "";}
				ddl_varcode.SelectedValue	= dt_aprvinfo.Rows[0]["cp_varcode"].ToString().Trim(); 
				txt_variance.Text			= dt_aprvinfo.Rows[0]["cp_variance"].ToString(); 
				txt_totcoll.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["lc_value"].ToString()); 
				txt_remark.Text				= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString(); 
				txt_installment.Text		= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_installment"].ToString()); 
				txt_exlimitval.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 
				txt_exrplimit.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 
				try 
				{GlobalTools.fromSQLDate(dt_aprvinfo.Rows[0]["cp_maturitydate"].ToString(), txt_tenor_day, ddl_tenor_month, txt_tenor_year);}
				catch {}
			}
		}

		private void secureData() 
		{
			if (STA == "view")
			{
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for (int i = 0; i < coll[5].Controls.Count; i++) 
				{
					if (coll[5].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[5].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[5].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[5].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[5].Controls[i] is Button)
					{
						Button btn = (Button) coll[5].Controls[i];
						btn.Visible = false;
					}
					else if (coll[5].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[5].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[5].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[5].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[5].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[5].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[5].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[5].Controls[i];

						for (int j=0; j < htr.Controls.Count; j++) 
						{							
							for (int jj = 0; jj < htr.Controls[j].Controls.Count; jj++) 
							{
								if (htr.Controls[j].Controls[jj] is TextBox) 
								{
									TextBox txt = (TextBox) htr.Controls[j].Controls[jj];
									txt.ReadOnly = true;
								}
								else if (htr.Controls[j].Controls[jj] is DropDownList) 
								{
									DropDownList ddl = (DropDownList) htr.Controls[j].Controls[jj];
									ddl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is Button)
								{
									Button btn = (Button) htr.Controls[j].Controls[jj];
									btn.Visible = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButtonList) 
								{
									RadioButtonList rbl = (RadioButtonList) htr.Controls[j].Controls[jj];
									rbl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButton) 
								{
									RadioButton rb = (RadioButton) htr.Controls[j].Controls[jj];
									rb.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is CheckBox)
								{
									CheckBox cb = (CheckBox) htr.Controls[j].Controls[jj];
									cb.Enabled = false;
								}					
							}
						}
					}
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
			this.btn_override.Click += new System.EventHandler(this.btn_override_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lb_struc_Click(object sender, System.EventArgs e)
		{
			if ((PRODUCT == "") && (APPTYPE == ""))
			{
				Tools.popMessage(this, "Check Facilities of Structure Credit First!");
				return;
			}

			Response.Write("<script language='javascript'>window.open('../dataentry/CustProduct.aspx?regno=" + REGNO + "&curef=" + CUREF + "&sta=view','StrukturKredit','status=no,scrollbars=yes,width=800,height=600');</script>");
		}

		private void btn_override_Click(object sender, System.EventArgs e)
		{
			string var_fromsta = "";

			conn.QueryString = "select isnull(ap_isappeal,0) ap_isappeal from application where ap_regno = '" + REGNO + "'";
			conn.ExecuteQuery();
			var_fromsta = conn.GetFieldValue("ap_isappeal");

			conn.QueryString = "exec input_approvaldecision  '" + REGNO + "', '" + PRODUCT + "', "+
				" '" + APPTYPE + "', '" + USERID + "', "+
				" "+tool.ConvertFloat(txt_limit.Text)+", "+tool.ConvertNull(txt_tenor.Text)+","+tool.ConvertNull(txt_tenorcode.Text)+", "+
				" "+tool.ConvertFloat(txt_fix.Text)+", '"+ddl_rate.SelectedValue+"', '"+ddl_varcode.SelectedValue+"', "+tool.ConvertFloat(txt_variance.Text)+", "+
				" '"+ddl_decovrreason.SelectedValue+"', '"+txt_decovrreason.Text+"', '"+txt_decremark.Text+"', "+tool.ConvertFloat(txt_installment.Text)+", "+
				" '1', '"+lbl_decsta.Text+"', "+tool.ConvertFloat(txt_exlimitval.Text)+", "+tool.ConvertFloat(txt_exrplimit.Text)+", '"+var_fromsta+"', "+
				" null, null, '" + PROD_SEQ + "'";
			conn.ExecuteQuery();
		}
	}
}
