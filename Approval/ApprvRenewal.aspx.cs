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
	/// Summary description for ApprvRenewal.
	/// </summary>
	public partial class ApprvRenewal : System.Web.UI.Page
	{
	
		#region " My Variables "
		private Connection conn;
		private Tools tool = new Tools();
		private string REGNO, CUREF, PRODUCT, APPTYPE, TC, USERID, MC, PROD_SEQ, var_fromsta, STA, AD_SEQ, KET_CODE;
		#endregion


		protected void Page_Load(object sender, System.EventArgs e)
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

				tr_confirm_negative.Visible = false;
			}

			btn_override.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1)){return false;};");
			initializeEvents(); 
		}

		private void initializeEvents() 
		{
			this.lb_struc.Click += new System.EventHandler(this.lb_struc_Click);
			this.BTN_EARMARK.Click += new EventHandler(BTN_EARMARK_Click);
			this.BTN_NEGATIVE_YES.Click += new EventHandler(BTN_NEGATIVE_YES_Click);
			this.BTN_NEGATIVE_NO.Click += new EventHandler(BTN_NEGATIVE_NO_Click);
			this.btn_Save.Click += new EventHandler(btn_Save_Click);
			this.btn_override.Click += new EventHandler(btn_override_Click);
		}

		private void initializeDropDowns() 
		{
			conn.QueryString = "select aa_no, cu_ref from application where ap_regno='"+REGNO+"'";
			conn.ExecuteQuery();
			string aa_no		= conn.GetFieldValue("aa_no");
			//TXT_CP_CUREF.Text	= conn.GetFieldValue("cu_ref");

			if (STA == "view") GlobalTools.fillRefList(DDL_PROJECT, "select * from VW_RFPROJECT", false, conn);
			else GlobalTools.fillRefList(DDL_PROJECT, "select * from VW_RFPROJECT where active = '1'", false, conn);

			if (STA == "view") GlobalTools.fillRefList(ddl_decovrreason, "select reasonid, reasondesc from RFREASON where reasontype = '2'", false, conn);
			else GlobalTools.fillRefList(ddl_decovrreason, "select reasonid, reasondesc from RFREASON where reasontype = '2' and active = '1'", false, conn);

			if (STA == "view") GlobalTools.fillRefList(DDL_NEWTENOR, "select tenorcode, tenordesc from rftenorcode ", false, conn);
			else GlobalTools.fillRefList(DDL_NEWTENOR, "select tenorcode, tenordesc from rftenorcode where active='1'", false, conn);

			if (STA == "view") GlobalTools.fillRefList(DDL_CP_LOANPURPOSE, "select LOANPURPID, LOANPURPDESC from RFLOANPURPOSE order by LOANPURPID", true, conn);
			else GlobalTools.fillRefList(DDL_CP_LOANPURPOSE, "select LOANPURPID, LOANPURPDESC from RFLOANPURPOSE where ACTIVE='1' order by LOANPURPID", true, conn);

			if (STA == "view") GlobalTools.fillRefList(ddl_idcprimevar, "select rateno, rate from RFRATENUMBER", false, conn);			
			else GlobalTools.fillRefList(ddl_idcprimevar, "select rateno, rate from RFRATENUMBER where active = '1'", false, conn);

			GlobalTools.initDateForm(TXT_NEWTENOR_DAY, DDL_NEWTENOR_MONTH, TXT_NEWTENOR_YEAR, true);
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
			TXT_CP_INSTALLMENT.Text	= conn.GetFieldValue("CP_INSTALLMENT");
			TXT_CP_KETERANGAN.Text	= conn.GetFieldValue("CP_KETERANGAN");
			LBL_REVOLVING.Text		= conn.GetFieldValue("REVOLVING");
			LBL_CURRENCY.Text		= conn.GetFieldValue("CURRENCY");
			TXT_OLDTENOR.Text		= conn.GetFieldValue("OLDVALUE");
			TXT_NEWTENOR.Text		= conn.GetFieldValue("NEWVALUE");
			LBL_OLDTENOR.Text		= conn.GetFieldValue("TENORDESC");
			LBL_ACC_NO.Text			= conn.GetFieldValue("ACC_NO");
			string CP_DECSTA		= conn.GetFieldValue("CP_DECSTA");
			string AD_VARCODE		= conn.GetFieldValue("AD_VARCODE");
			string AD_VARIANCE		= conn.GetFieldValue("AD_VARIANCE");
			string AD_RATENO		= conn.GetFieldValue("AD_RATENO");

			if (!conn.GetFieldValue("NEWCODE").Equals("")) 
			{ 
				try { DDL_NEWTENOR.SelectedValue	= conn.GetFieldValue("NEWCODE"); } 
				catch {}
			} 			
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
			//jika loan berdasarkan maturity date ...
			if (!conn.GetFieldValue("CP_MATURITYDATE").Equals("")) 
			{
				//isi maturity date
				GlobalTools.fromSQLDate(conn.GetFieldValue("CP_MATURITYDATE"), TXT_NEWTENOR_DAY, DDL_NEWTENOR_MONTH, TXT_NEWTENOR_YEAR);
				RDO_TENORTYPE.SelectedValue = "0";

				//tentukan maturity date sebagai mandatory
				TXT_NEWTENOR_DAY.CssClass	= "mandatory";
				DDL_NEWTENOR_MONTH.CssClass = "mandatory";
				TXT_NEWTENOR_YEAR.CssClass	= "mandatory";
				TXT_NEWTENOR_DAY.Visible	= true;
				DDL_NEWTENOR_MONTH.Visible	= true;
				TXT_NEWTENOR_YEAR.Visible	= true;

				//hide tenor
				TXT_NEWTENOR.CssClass = "";
				DDL_NEWTENOR.CssClass = "";
				TXT_NEWTENOR.Visible	= false;
				DDL_NEWTENOR.Visible	= false;
			}
			//--- Mengambil project
			//			conn.QueryString = "select PROJECT_CODE from CUSTPRODUCT where AP_REGNO = '" + REGNO + 
			//				"' and APPTYPE = '" + APPTYPE + 
			//				"' and PRODUCTID = '" + PRODUCT + 
			//				"' and PROD_SEQ = '" + PROD_SEQ + "'";

			try {DDL_PROJECT.SelectedValue = conn.GetFieldValue("PROJECT_CODE");} 
			catch {DDL_PROJECT.SelectedValue = "";}
			LBL_PRJ_CODE.Text		= conn.GetFieldValue("PRJ_NAME");
			
			LBL_EARMARK_AMOUNT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("EARMARK_AMOUNT_PRJ"));
			conn.ClearData();

			//--- Mengambil limit
			conn.QueryString = "SELECT LIMIT FROM BOOKEDPROD WHERE AA_NO='"+AA_NO+"' AND ACC_SEQ="+GlobalTools.ConvertNum(ACC_SEQ)+" AND PRODUCTID='"+PRODUCT+"'";
			conn.ExecuteQuery();
			LBL_CP_LIMIT.Text				= GlobalTools.MoneyFormat(conn.GetFieldValue("LIMIT"));			
			LBL_PRODUCT.Text				= Request.QueryString["teks"];
			

			conn.ClearData();

			conn.QueryString = "select interesttype from rfproduct where productid='" + PRODUCT + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue(0,0) == "01" || conn.GetFieldValue(0,0) == "03")
			{
				if (conn.GetFieldValue(0,0) == "03") 
				{
					LBL_INTERESTTYPE.Text = "Bunga / p.a: Floating (Alt Rate)";
				}
				else 
				{
					LBL_INTERESTTYPE.Text = "Bunga / p.a: Floating";
				}
				
				conn.QueryString = "select * from vw_floatingrate where productid='" + PRODUCT + "'";
				conn.ExecuteQuery();
				LBL_INTEREST.Text	= conn.GetFieldValue("rate");  
				if (CP_DECSTA == "")
				{
					LBL_VARCODE.Text	= conn.GetFieldValue("varcode");  
					LBL_VARIANCE.Text	= conn.GetFieldValue("variance");
					LBL_RATENO.Text		= conn.GetFieldValue("rateno");
				}
				else
				{
					LBL_VARCODE.Text	= AD_VARCODE;
					LBL_VARIANCE.Text	= AD_VARIANCE;
					LBL_RATENO.Text		= AD_RATENO;
				}
			}
			else
			{
				LBL_INTERESTTYPE.Text = "Bunga / p.a: Fix";
				conn.QueryString = "select interesttyperate from rfproduct where productid='" + PRODUCT + "'";
				conn.ExecuteQuery();
				LBL_INTEREST.Text = conn.GetFieldValue("interesttyperate");
				LBL_VARIANCE.Visible = false;
			}

			
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
				txt_tenorcode.Text			= dt_aprvinfo.Rows[0]["cp_tenorcodedesc"].ToString();
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
					//LBL_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());					
					TXT_NEWTENOR.Text				= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
					DDL_NEWTENOR.SelectedValue		= dt_aprvinfo.Rows[0]["cp_tenorcode"].ToString().Trim();
					//jika loan berdasarkan maturity date ...
					if (!dt_aprvinfo.Rows[0]["cp_maturitydate"].ToString().Equals("")) 						
					{
						//isi maturity date
						GlobalTools.fromSQLDate(dt_aprvinfo.Rows[0]["cp_maturitydate"].ToString(), TXT_NEWTENOR_DAY, DDL_NEWTENOR_MONTH, TXT_NEWTENOR_YEAR);
						RDO_TENORTYPE.SelectedValue = "0";

						//tentukan maturity date sebagai mandatory
						TXT_NEWTENOR_DAY.CssClass	= "mandatory";
						DDL_NEWTENOR_MONTH.CssClass = "mandatory";
						TXT_NEWTENOR_YEAR.CssClass	= "mandatory";
						TXT_NEWTENOR_DAY.Visible	= true;
						DDL_NEWTENOR_MONTH.Visible	= true;
						TXT_NEWTENOR_YEAR.Visible	= true;

						//hide tenor
						TXT_NEWTENOR.CssClass = "";
						DDL_NEWTENOR.CssClass = "";
						TXT_NEWTENOR.Visible	= false;
						DDL_NEWTENOR.Visible	= false;
					}

					LBL_INTEREST.Text	 			= dt_aprvinfo.Rows[0]["cp_interest"].ToString();					
					LBL_RATENO.Text					= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim(); 
					LBL_VARCODE.Text				= dt_aprvinfo.Rows[0]["cp_varcode"].ToString().Trim();					
					LBL_VARIANCE.Text				= dt_aprvinfo.Rows[0]["cp_variance"].ToString();					
					TXT_CP_KETERANGAN.Text			= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString();					
					TXT_CP_INSTALLMENT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_installment"].ToString());					
					if ((TXT_CP_INSTALLMENT.Text == "0") || (TXT_CP_INSTALLMENT.Text == "0,00"))
						TXT_CP_INSTALLMENT.Text = "-";
//					txt_decexlimitval.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 					
//					txt_decexrplimit.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 
//					txt_declimitchg.Text			= dt_aprvinfo.Rows[0]["cp_limitchg"].ToString();
//					txt_decgraceperiode.Text		= dt_aprvinfo.Rows[0]["cp_graceperiod"].ToString(); 
//					ddl_decpayfreq.SelectedValue	= dt_aprvinfo.Rows[0]["cp_paymentid"].ToString().Trim(); 

					//input approval decision
					if (PRODUCT != "")
					{
						if (TXT_CP_INSTALLMENT.Text == "-")
							TXT_CP_INSTALLMENT.Text = "0";
						conn.QueryString = "exec input_approvaldecision  '"+REGNO+"', '"+PRODUCT+"', "+
							" '"+APPTYPE+"', '"+USERID+"', "+
							" "+tool.ConvertFloat(txt_limit.Text)+", "+tool.ConvertNull(TXT_NEWTENOR.Text)+","+tool.ConvertNull(DDL_NEWTENOR.SelectedValue)+", "+
							" "+tool.ConvertFloat(txt_fix.Text)+", '"+txt_rate.Text+"', '"+ddl_rate.SelectedValue+"', "+ GlobalTools.ConvertFloat(txt_variance.Text) +", "+
							" '', '', '"+TXT_CP_KETERANGAN.Text+"', "+tool.ConvertFloat(txt_installment.Text)+", '0', '"+lbl_decsta.Text+"', "+
							" "+tool.ConvertFloat("")+", "+tool.ConvertFloat("")+", '"+var_fromsta+"', "+
							" null, null, '" + PROD_SEQ + "', " + GlobalTools.ToSQLDate(TXT_NEWTENOR_DAY.Text, DDL_NEWTENOR_MONTH.SelectedValue, TXT_NEWTENOR_YEAR.Text) + "";
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

					//LBL_CP_LIMIT.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_limit"));
					TXT_NEWTENOR.Text			= conn.GetFieldValue("ad_tenor");
					DDL_NEWTENOR.SelectedValue	= conn.GetFieldValue("ad_tenorcode").Trim();
					LBL_INTEREST.Text			= conn.GetFieldValue("ad_interest");
					LBL_RATENO.Text				= conn.GetFieldValue("ad_rateno");
//					try
//					{txt_decrate.Text			= Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);}
//					catch
//					{txt_decrate.Text			= "";}
					LBL_VARCODE.Text			= conn.GetFieldValue("ad_varcode").Trim();
					LBL_VARIANCE.Text			= conn.GetFieldValue("ad_variance");

					/* ////// tidak perlu karena usernya belum pernah visit
					 * 
					if (conn.GetFieldValue("ad_ovrsta") == "0")
						txt_decovrsta.Text			= "No";
					else if (conn.GetFieldValue("ad_ovrsta") == "1")
						txt_decovrsta.Text			= "Yes";
					ddl_decovrreason.SelectedValue	= conn.GetFieldValue("ad_ovrreason").Trim();
					txt_decovrreason.Text			= conn.GetFieldValue("ad_ovrreasontext");
					TXT_CP_KETERANGAN.Text				= conn.GetFieldValue("ad_keterangan");
					*/

					TXT_CP_INSTALLMENT.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_installment"));
					if ((TXT_CP_INSTALLMENT.Text == "0") || (TXT_CP_INSTALLMENT.Text == "0,00"))
						TXT_CP_INSTALLMENT.Text = "-";
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
						if (TXT_CP_INSTALLMENT.Text == "-")
							TXT_CP_INSTALLMENT.Text = "0";
						conn.QueryString = "exec input_approvaldecision  '"+REGNO+"', '"+PRODUCT+"', "+
							" '"+APPTYPE+"', '"+USERID+"', "+
							" "+tool.ConvertFloat(txt_limit.Text)+", "+tool.ConvertNull(TXT_NEWTENOR.Text)+","+tool.ConvertNull(DDL_NEWTENOR.SelectedValue)+", "+
							" "+tool.ConvertFloat(txt_fix.Text)+", '"+txt_rate.Text+"', '"+ddl_varcode.SelectedValue+"', "+tool.ConvertFloat(txt_variance.Text)+", "+
							" '"+ddl_decovrreason.SelectedValue+"', '"+txt_decovrreason.Text+"', '"+TXT_CP_KETERANGAN.Text+"', "+
							" "+tool.ConvertFloat(txt_installment.Text)+", '0', '"+lbl_decsta.Text+"', "+
							" "+tool.ConvertFloat("")+", "+tool.ConvertFloat("")+", '"+var_fromsta+"', "+
							" null, null, '" + PROD_SEQ + "', " + GlobalTools.ToSQLDate(TXT_NEWTENOR_DAY.Text, DDL_NEWTENOR_MONTH.SelectedValue, TXT_NEWTENOR_YEAR.Text) + "";
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
						/*LBL_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_limit"].ToString());*/

						TXT_NEWTENOR.Text				= dt_aprvinfo.Rows[0]["ad_tenor"].ToString();
						DDL_NEWTENOR.SelectedValue		= dt_aprvinfo.Rows[0]["ad_tenorcode"].ToString().Trim();
						LBL_INTEREST.Text				= dt_aprvinfo.Rows[0]["ad_interest"].ToString();
						LBL_RATENO.Text					= dt_aprvinfo.Rows[0]["ad_rateno"].ToString();
						/*
						try
						{txt_decrate.Text			= Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);}
						catch
						{txt_decrate.Text			= "";}
						*/
						LBL_VARCODE.Text				= dt_aprvinfo.Rows[0]["ad_varcode"].ToString().Trim();
						LBL_VARIANCE.Text				= dt_aprvinfo.Rows[0]["ad_variance"].ToString();
						txt_decovrsta.Text				= dt_aprvinfo.Rows[0]["ad_ovrsta"].ToString();
						ddl_decovrreason.SelectedValue	= dt_aprvinfo.Rows[0]["ad_ovrreason"].ToString().Trim();
						txt_decovrreason.Text			= dt_aprvinfo.Rows[0]["ad_ovrreasontext"].ToString();
						TXT_CP_KETERANGAN.Text			= dt_aprvinfo.Rows[0]["ad_keterangan"].ToString();
						TXT_CP_INSTALLMENT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_installment"].ToString());
						if ((TXT_CP_INSTALLMENT.Text == "0") || (TXT_CP_INSTALLMENT.Text == "0,00"))
							TXT_CP_INSTALLMENT.Text = "-";
						txt_decsta.Text					= dt_aprvinfo.Rows[0]["ad_rejectdesc"].ToString();
						lbl_decsta.Text					= dt_aprvinfo.Rows[0]["ad_reject"].ToString();
						/*
						txt_decexlimitval.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_exlimitval"].ToString()); 
						txt_decexrplimit.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_exrplimit"].ToString()); 
						txt_declimitchg.Text			= dt_aprvinfo.Rows[0]["cp_limitchg"].ToString();
						txt_decgraceperiode.Text		= dt_aprvinfo.Rows[0]["ad_graceperiod"].ToString(); 
						ddl_decpayfreq.SelectedValue	= dt_aprvinfo.Rows[0]["ad_paymentid"].ToString().Trim(); 
						*/
					} 
					else 
					{
						TXT_NEWTENOR.Text				= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
						DDL_NEWTENOR.SelectedValue		= dt_aprvinfo.Rows[0]["cp_tenorcode"].ToString().Trim();
						//jika loan berdasarkan maturity date ...
						if (!dt_aprvinfo.Rows[0]["cp_maturitydate"].ToString().Equals("")) 						
						{
							//isi maturity date
							GlobalTools.fromSQLDate(dt_aprvinfo.Rows[0]["cp_maturitydate"].ToString(), TXT_NEWTENOR_DAY, DDL_NEWTENOR_MONTH, TXT_NEWTENOR_YEAR);
							RDO_TENORTYPE.SelectedValue = "0";

							//tentukan maturity date sebagai mandatory
							TXT_NEWTENOR_DAY.CssClass	= "mandatory";
							DDL_NEWTENOR_MONTH.CssClass = "mandatory";
							TXT_NEWTENOR_YEAR.CssClass	= "mandatory";
							TXT_NEWTENOR_DAY.Visible	= true;
							DDL_NEWTENOR_MONTH.Visible	= true;
							TXT_NEWTENOR_YEAR.Visible	= true;

							//hide tenor
							TXT_NEWTENOR.CssClass = "";
							DDL_NEWTENOR.CssClass = "";
							TXT_NEWTENOR.Visible	= false;
							DDL_NEWTENOR.Visible	= false;
						}

						LBL_INTEREST.Text	 			= dt_aprvinfo.Rows[0]["cp_interest"].ToString();					
						LBL_RATENO.Text					= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim(); 
						LBL_VARCODE.Text				= dt_aprvinfo.Rows[0]["cp_varcode"].ToString().Trim();					
						LBL_VARIANCE.Text				= dt_aprvinfo.Rows[0]["cp_variance"].ToString();					
						TXT_CP_KETERANGAN.Text			= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString();					
						TXT_CP_INSTALLMENT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_installment"].ToString());					
						if ((TXT_CP_INSTALLMENT.Text == "0") || (TXT_CP_INSTALLMENT.Text == "0,00"))
							TXT_CP_INSTALLMENT.Text = "-";

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
							if (TXT_CP_INSTALLMENT.Text == "-")
								TXT_CP_INSTALLMENT.Text = "0";
							conn.QueryString = "exec input_approvaldecision  '"+REGNO+"', '"+PRODUCT+"', "+
								" '"+APPTYPE+"', '"+USERID+"', "+
								" "+tool.ConvertFloat(txt_limit.Text)+", "+tool.ConvertNull(TXT_NEWTENOR.Text)+","+tool.ConvertNull(DDL_NEWTENOR.SelectedValue)+", "+
								" "+tool.ConvertFloat(txt_fix.Text)+", '"+txt_rate.Text+"', '"+ddl_rate.SelectedValue+"', "+txt_variance.Text+", "+
								" '', '', '"+TXT_CP_KETERANGAN.Text+"', "+tool.ConvertFloat(txt_installment.Text)+", '0', '"+lbl_decsta.Text+"', "+
								" "+tool.ConvertFloat("")+", "+tool.ConvertFloat("")+", '"+ad_fromsta_new+"', "+
								" null, null, '" + PROD_SEQ + "', " + GlobalTools.ToSQLDate(TXT_NEWTENOR_DAY.Text, DDL_NEWTENOR_MONTH.SelectedValue, TXT_NEWTENOR_YEAR.Text) + "";
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

//			conn.QueryString = "select interesttype from rfproduct where productid = '"+PRODUCT+"'";
//			conn.ExecuteQuery();
//			string var_inttype = conn.GetFieldValue("interesttype");
//			if (var_inttype == "01")
//			{
//				tr_fix.Visible	  = false;
//				tr_decfix.Visible = false;
//			}
//			else if (var_inttype == "02")
//			{
//				tr_float.Visible    = false;
//				tr_decfloat.Visible = false;
//			}
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

		private void viewDataEarmark() 
		{
			//////////////////////////////////////////////////////////
			/// Refresh earmark amount on user's view
			/// 
			conn.QueryString = "select PROJECT_CODE, PRJ_NAME, EARMARK_AMOUNT_PRJ "+
				"from VW_CUSTPRODUCT where ap_regno='"+ REGNO +"' and productid='"+ PRODUCT +"' and apptype='" + APPTYPE + "' and PROD_SEQ = '" + PROD_SEQ + "'";
			conn.ExecuteQuery();
			LBL_EARMARK_AMOUNT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("EARMARK_AMOUNT_PRJ"));		


			//////////////////////////////////////////////////////////
			/// Update Earmark Amount on Approval_Decision
			/// 
			conn.QueryString = "update approval_decision " + 
				" set ad_earmark_amount = '" + conn.GetFieldValue("EARMARK_AMOUNT_PRJ") + "' " + 
				" where ap_Regno = '" + REGNO + "' " + 
				" and apptype = '" + APPTYPE + "' " + 
				" and productid = '" + PRODUCT + "' " + 
				" and prod_seq = '" + PROD_SEQ + "'";
			conn.ExecuteNonQuery();
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

		private void lb_struc_Click(object sender, System.EventArgs e)
		{
			if ((PRODUCT == "") && (APPTYPE == ""))
			{
				Tools.popMessage(this, "Check Facilities of Structure Credit First!");
				return;
			}

			/***
			try 
			{
				conn.QueryString = "select productid+' '+productdesc+'('+apptypedesc+')' proddesc "+
					" from rfproduct, rfapplicationtype "+
					" where productid = '"+PRODUCT+"' "+
					" and apptypeid = '"+APPTYPE+"'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			string var_text = conn.GetFieldValue("proddesc");
			if (APPTYPE == "01")
			{
				conn.QueryString = "select iscashloan from rfproduct where productid = '"+PRODUCT+ "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue(0,0) == "0")
					conn.QueryString = "select screenlink from apptypelink where APPTYPEID = '"+APPTYPE+ "' and PRODUCTID='" + "M21" + "' and fungsiId='CS' and iscashloan='0'";
				else	
					conn.QueryString = "select screenlink from apptypelink where APPTYPEID = '"+APPTYPE+ "' and PRODUCTID='" + "M21" + "' and fungsiId='CS' and iscashloan='1'";
			}
			else
				conn.QueryString = "select screenlink from apptypelink where APPTYPEID = '"+APPTYPE+ "' and PRODUCTID='" + "M21" + "' and fungsiId='CS' ";
			conn.ExecuteQuery();

			Response.Write("<script for=window event=onload language='javascript'>PopupPage('/SME/DataEntry/" + conn.GetFieldValue("screenlink")+"?regno="+REGNO+"&apptype="+APPTYPE+ "&prodid="+PRODUCT +"&prod_seq="+ PROD_SEQ +"&teks="+var_text+ "&de=0" + "', '900', '500');</script>");			
			***/

			Response.Write("<script language='javascript'>window.open('../dataentry/CustProduct.aspx?regno=" + REGNO + "&curef=" + CUREF + "&sta=view','StrukturKredit','status=no,scrollbars=yes,width=800,height=600');</script>");
		}

		private void btn_override_Click(object sender, System.EventArgs e)
		{
			string var_fromsta = "";

//			if (double.Parse(TXT_CP_EXLIMITVAL.Text) > double.Parse(txt_exlimitval.Text))
//			{
//				GlobalTools.popMessage(this, "Approval limit Cannot greater than Requested Limit");
//				return;
//			}

//			conn.QueryString = "select in_kreditbaru from rfinitial";
//			conn.ExecuteQuery();
//			if (APPTYPE == conn.GetFieldValue("in_kreditbaru"))
//			{
//				conn.QueryString = "select isnull(su_emaslimit, 0)su_emaslimit from scuser "+
//					" where userid = '" + USERID + "'";
//				conn.ExecuteQuery();
//				//if (double.Parse(txt_declimit.Text) > double.Parse(conn.GetFieldValue("su_emaslimit").ToString()))
//				if (double.Parse(TXT_CP_LIMIT.Text) > double.Parse(conn.GetFieldValue("su_emaslimit").ToString()))
//				{
//					GlobalTools.popMessage(this, "Limit in rupiah cannot greater than eMas Limit");
//					return;
//				}
//			}

			if (RDO_TENORTYPE.SelectedValue == "1") //Kalau tipe request tenor : Days/Month
			{
				if (((int.Parse(TXT_NEWTENOR.Text) < 30) && (DDL_NEWTENOR.SelectedValue == "D")) || ((int.Parse(TXT_NEWTENOR.Text) < 1) && (DDL_NEWTENOR.SelectedValue == "M")))
				{
					GlobalTools.popMessage(this, "Tenor Cannot below 30 days or 1 month!");
					return;
				}
			}
			else //Kalau tipe request tenor : Maturity Date
			{
				if (!GlobalTools.isDateValid(TXT_NEWTENOR_DAY.Text.Trim(), DDL_NEWTENOR_MONTH.SelectedValue, TXT_NEWTENOR_YEAR.Text.Trim()))
				{
					GlobalTools.popMessage(this, "Tanggal Maturity Date tidak valid!");
					return;
				}
			}

			/*
			conn.QueryString = "select isnull(ap_isappeal,0) ap_isappeal from application where ap_regno = '" + REGNO + "'";
			conn.ExecuteQuery();
			var_fromsta = conn.GetFieldValue("ap_isappeal");
			*/
			conn.QueryString = "exec APPROVAL_CHECKHISTORY '" + REGNO + "', '" + PRODUCT + "', '" + APPTYPE + "', '" + USERID + "', '" + PROD_SEQ + "'";
			conn.ExecuteQuery();
			var_fromsta = conn.GetFieldValue("CNT_APPROVAL");

//			//txt_declimit.Text = Convert.ToString((double.Parse(txt_decexlimitval.Text)*double.Parse(txt_decexrplimit.Text)));
//			LBL_CP_LIMIT.Text = Convert.ToString((double.Parse(TXT_CP_EXLIMITVAL.Text)*double.Parse(TXT_CP_EXRPLIMIT.Text)));
//			TXT_CP_LIMIT.Text = Convert.ToString((double.Parse(TXT_CP_EXLIMITVAL.Text)*double.Parse(TXT_CP_EXRPLIMIT.Text)));
//			//CalculateInstallment();
//			//if (LBL_CP_INSTALLMENT.Text == "-")
//			//	LBL_CP_INSTALLMENT.Text = "0";
			
			conn.QueryString = "exec input_approvaldecision  '" + REGNO + "', '" + PRODUCT + "', "+
				" '" + APPTYPE + "', '" + USERID + "', "+
				" "+tool.ConvertFloat(txt_limit.Text)+", "+tool.ConvertNull(TXT_NEWTENOR.Text)+","+tool.ConvertNull(DDL_NEWTENOR.SelectedValue)+", "+
				" "+tool.ConvertFloat(txt_fix.Text)+", '"+ddl_rate.SelectedValue+"', '"+ddl_varcode.SelectedValue+"', "+tool.ConvertFloat(txt_variance.Text)+", "+
				" '"+ddl_decovrreason.SelectedValue+"', '"+txt_decovrreason.Text+"', '"+txt_decremark.Text+"', "+tool.ConvertFloat(txt_installment.Text)+", "+
				" '1', '"+lbl_decsta.Text+"', "+tool.ConvertFloat(txt_exlimitval.Text)+", "+tool.ConvertFloat(txt_exrplimit.Text)+", '"+var_fromsta+"', "+
				" null, null, '" + PROD_SEQ + "', " + GlobalTools.ToSQLDate( TXT_NEWTENOR_DAY.Text.Trim(), DDL_NEWTENOR_MONTH.SelectedValue, TXT_NEWTENOR_YEAR.Text.Trim()) + "";
			conn.ExecuteQuery();

			//if (LBL_IDC_VARIANCE.Text == "")
			//	LBL_IDC_VARIANCE.Text = "0";

			/***
			//if (ddl_idcinttype.SelectedValue == "01")			
			if (DDL_IDC_INTERESTTYPE.SelectedValue == "01")
			{
				conn.QueryString = "update custproduct set idc_interesttype = '" + DDL_IDC_INTERESTTYPE.SelectedValue +
					"', idc_varcode = '" + DDL_IDC_VARCODE.SelectedValue +
					"', idc_variance = " + LBL_IDC_VARIANCE.Text + " "+
					" where ap_regno = '" + REGNO + "' and productid = '" + PRODUCT +
					"' and apptype = '" + APPTYPE + "' and PROD_SEQ = '" + PROD_SEQ + "'";
			}
			else if (DDL_IDC_INTERESTTYPE.SelectedValue == "02")
			{
				conn.QueryString = "update custproduct set idc_interesttype = '" + DDL_IDC_INTERESTTYPE.SelectedValue +
					"', idc_interest = " + LBL_IDC_VARIANCE.Text + " " +
					" where ap_regno = '" + REGNO + "' and productid = '" + PRODUCT +
					"' and apptype = '" + APPTYPE + "' and PROD_SEQ = '" + PROD_SEQ + "'";
			}
			conn.ExecuteQuery();
			***/

//			string link	= "Approval.aspx?regno="+REGNO+"&curef="+CUREF+"&tc="+TC+"&mc="+MC;
//			string autoLoadScript = "<script language='javascript'>GetOut('"+link+"');</script>";
//			Page.RegisterStartupScript("LoadScript ", autoLoadScript);
		}

		private void BTN_EARMARK_Click(object sender, EventArgs e)
		{			
			try 
			{
				/// Reverse dulu
				/// 
				Earmarking.Earmarking.reverseEarmark(REGNO, KET_CODE, conn);

				/// re-calculate earmark amount
				/// 
				Earmarking.Earmarking.calculateEarmarkLimit(REGNO, KET_CODE, conn);

				/// Update Ketentuan Kredit
				/// 				
				conn.QueryString = "UPDATE KETENTUAN_KREDIT SET PRJ_CODE = " + GlobalTools.ConvertNull(DDL_PROJECT.SelectedValue) + " WHERE KET_CODE = '" + KET_CODE + "'";
				conn.ExecTrans();					

				/// Do Earmark
				/// 
				if (TXT_NEGATIVE.Text == "NO")
					Earmarking.Earmarking.doEarmark(REGNO, KET_CODE, conn);
				else
					Earmarking.Earmarking.doEarmark(REGNO, KET_CODE, conn, "1", "");

				conn.ExecTran_Commit();
			} 
			catch (Earmarking.NegativeLimitException ex1) 
			{
				if (conn != null) conn.ExecTran_Rollback();
				if (ex1.getMessage() == "FACILITY") 
				{
					GlobalTools.popMessage(this, "Earmarking by facility failed. Remaining limit become negative!");
					return;
				} 
				if (TXT_NEGATIVE.Text == "NO") tr_confirm_negative.Visible = false;
				return;
			}
			catch (Exception ex)
			{
				ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, REGNO);
				if (conn != null) conn.ExecTran_Rollback();
			}			

			/// Refresh earmark data
			/// 
			viewDataEarmark();
		}

		protected void btn_Save_Click(object sender, System.EventArgs e)
		{
			if (DDL_PROJECT.SelectedValue == "")
			{
				GlobalTools.popMessage(this, "Project Info must be Filled");
			}
			else
			{
				try 
				{
					/// Reverse dulu
					/// 
					Earmarking.Earmarking.reverseEarmark(REGNO, KET_CODE, conn);

					/// re-calculate earmark amount
					/// 
					Earmarking.Earmarking.calculateEarmarkLimit(REGNO, KET_CODE, conn);

					/// Update Ketentuan Kredit
					/// 		
					//GlobalTools.popMessage(this,DDL_PROJECT.SelectedValue);
					conn.QueryString = "UPDATE KETENTUAN_KREDIT SET PRJ_CODE = " + GlobalTools.ConvertNull(DDL_PROJECT.SelectedValue) + " WHERE KET_CODE = '" + KET_CODE + "'";
					conn.ExecTrans();

					/// Do Earmark
					/// 
					if (TXT_NEGATIVE.Text == "NO")
						Earmarking.Earmarking.doEarmark(REGNO, KET_CODE, conn);
					else
						Earmarking.Earmarking.doEarmark(REGNO, KET_CODE, conn, "1", "");

					conn.ExecTran_Commit();
				} 
				catch (Earmarking.NegativeLimitException ex1) 
				{
					if (conn != null) conn.ExecTran_Rollback();
					if (ex1.getMessage() == "FACILITY") 
					{
						GlobalTools.popMessage(this, "Earmarking by facility failed. Remaining limit become negative!");
						return;
					} 
					if (TXT_NEGATIVE.Text == "NO") tr_confirm_negative.Visible = false;
					return;
				}
				catch (Exception ex)
				{
					ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, REGNO);
					if (conn != null) conn.ExecTran_Rollback();
				}

				/// Refresh earmark data
				/// 
				viewDataEarmark();
			}
		}

		private void BTN_NEGATIVE_YES_Click(object sender, EventArgs e)
		{
			TXT_NEGATIVE.Text = "YES";
			BTN_EARMARK_Click(sender, e);
			TXT_NEGATIVE.Text = "NO";
			tr_confirm_negative.Visible = false;
		}

		private void BTN_NEGATIVE_NO_Click(object sender, EventArgs e)
		{
			tr_confirm_negative.Visible = false;
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
				txt_tenorcode.Text			= dt_aprvinfo.Rows[0]["cp_tenorcodedesc"].ToString();
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
	}
}
