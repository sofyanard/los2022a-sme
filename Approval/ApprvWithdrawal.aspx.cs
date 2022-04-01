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
	/// Summary description for ApprvWithdrawal.
	/// </summary>
	public partial class ApprvWithdrawal : System.Web.UI.Page
	{

		#region " My Variables "
		private Connection conn;
		private Tools tool = new Tools();
		private string REGNO, CUREF, PRODUCT, APPTYPE, TC, USERID, MC, PROD_SEQ, var_fromsta, TEKS, STA, KET_CODE, AD_SEQ;
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
			TEKS		= Request.QueryString["teks"];
			STA			= Request.QueryString["sta"];			//--jika berasal dari aproval history--//
			KET_CODE	= Request.QueryString["ket_code"];
			AD_SEQ		= Request.QueryString["ad_seq"];

			if (!IsPostBack) 
			{
				LBL_TITLE.Text = TEKS;
				initializeDropDowns();

				viewDataGeneral();
				CalculateInstallment();		
		
				if (STA == "view") viewData2();
				else viewData();

				secureData();

				kreditAwal.Visible = false;
				tr_confirm_negative.Visible = false;
			}

			btn_override.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1)){return false;};");
		}

		private void initializeDropDowns() 
		{
			conn.QueryString = "select * from vw_cs_withdrawl where ap_regno='" + REGNO + 
				"' and apptype = '"  + APPTYPE + 
				"' and productid='" + PRODUCT + 
				"' and PROD_SEQ = '" + PROD_SEQ + "'";
			conn.ExecuteQuery();

			/*
			string query = "select acc_seq, acc_no from bookedprod where aa_no='" + conn.GetFieldValue("AA_NO") + 
				"' and productid='" + PRODUCT + "'";
			*/
			string query = "select '" + conn.GetFieldValue("ACC_SEQ") + "' as acc_seq, '" + conn.GetFieldValue("ACC_SEQ") + "' as acc_seq";
			GlobalTools.fillRefList(DDL_CP_NOREK, query, false, conn);
			try {DDL_CP_NOREK.SelectedValue = conn.GetFieldValue("ACC_SEQ");}
			catch {}

			if (STA == "view") GlobalTools.fillRefList(ddl_decovrreason, "select reasonid, reasondesc from RFREASON where reasontype = '2'", false, conn);
			else GlobalTools.fillRefList(ddl_decovrreason, "select reasonid, reasondesc from RFREASON where reasontype = '2' and active = '1'", false, conn);

			if (STA == "view") GlobalTools.fillRefList(DDL_WITHDRAWLID, "select withdrawlid, withdrawldesc from rfwithdrawltype", false, conn);
			else GlobalTools.fillRefList(DDL_WITHDRAWLID, "select withdrawlid, withdrawldesc from rfwithdrawltype where active='1'", false, conn);

			if (STA == "view") GlobalTools.fillRefList(DDL_CP_TENORCODE, "select tenorcode, tenordesc from rftenorcode", false, conn);
			else GlobalTools.fillRefList(DDL_CP_TENORCODE, "select tenorcode, tenordesc from rftenorcode where active='1'", false, conn);

			if (STA == "view") GlobalTools.fillRefList(ddl_decrate, "select rateno, rate from RFRATENUMBER", false, conn);
			else GlobalTools.fillRefList(ddl_decrate, "select rateno, rate from RFRATENUMBER where active = '1'", false, conn);

			if (STA == "view") GlobalTools.fillRefList(DDL_PROJECT_CODE, "select * from VW_RFPROJECT", conn);
			else GlobalTools.fillRefList(DDL_PROJECT_CODE, "select * from VW_rfproject where active = '1'", false, conn);

			if (STA == "view")GlobalTools.fillRefList(DDL_CP_LOANPURPOSE, "select * from rfloanpurpose", conn);
			else GlobalTools.fillRefList(DDL_CP_LOANPURPOSE, "select * from rfloanpurpose where active = '1'", conn);
		
			DDL_DECVARCODE.Items.Clear();
			DDL_DECVARCODE.Items.Add(new ListItem( "- SELECT -",""));
			DDL_DECVARCODE.Items.Add(new ListItem("+", "+"));
			DDL_DECVARCODE.Items.Add(new ListItem("-", "-"));
		}

		private void CalculateInstallment()
		{
			double result = 0;
			double Rate= 0.0;

			/////////////////////////
			/// First check whether there has been a value or not
			/// 
			conn.QueryString = "select isnull(AD_INSTALLMENT, '') AD_INSTALLMENT from approval_decision " + 
				" where AP_REGNO = '" + REGNO + 
				"' AND APPTYPE = '" + APPTYPE + 
				"' AND PRODUCTID = '" + PRODUCT + 
				"' AND PROD_SEQ = '" + PROD_SEQ + "'" + 
				" AND AD_SEQ = ( SELECT MAX(AD_SEQ) FROM APPROVAL_DECISION WHERE AP_REGNO = '" + REGNO + "')";
			conn.ExecuteQuery();

			try
			{
			    // DAPAT BUNGA DULU SEBELUM PASS DALAM FUNGSI UNTUK HITUNG
				if(DDL_DECVARCODE.SelectedValue.Trim()=="-")
				{Rate = Convert.ToDouble(LBL_INTEREST.Text) - Convert.ToDouble(TXT_DECVARIANCE.Text);}
				
				if(DDL_DECVARCODE.SelectedValue.Trim()=="+")
				{Rate = Convert.ToDouble(LBL_INTEREST.Text) + Convert.ToDouble(TXT_DECVARIANCE.Text);}

				if(Rate > 0 )
				{
					result = DMS.CuBESCore.Logic.hitungInstalment(double.Parse(TXT_CP_EXLIMITVAL.Text), double.Parse(TXT_CP_JANGKAWKT.Text), Rate, PRODUCT, DDL_CP_TENORCODE.SelectedValue, conn);
					TXT_CP_INSTALLMENT.Text = tool.MoneyFormat(result.ToString());
				}
				else
					result=0;
			}
			catch {result = 0;}
			
			if(result <= 1 ) 
			{
				try 
				{
					if (Convert.ToDouble(conn.GetFieldValue("AD_INSTALLMENT")) > 0)
					{
						TXT_CP_INSTALLMENT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("AD_INSTALLMENT"));
						return;
					}
				} 
				catch (Exception ex)
				{
					ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "AP_REGNO : " + REGNO);
				}				
			}

		}
		
		private void viewDataGeneral() 
		{
			/*
			conn.QueryString="select APPTYPEDESC, PRODUCTDESC, CP_LOANPURPOSE, "+
				"CP_LIMIT, CP_installment, CP_EXRPLIMIT, CP_EXLIMITVAL, CP_VARCODE, CP_RATENO, CP_VARIANCE, "+
				"CP_KETERANGAN, ACC_SEQ, CP_JANGKAWKT, CP_TENORCODE, REVOLVING, aa_no+'#'+convert(varchar,acc_seq) as seq "+
				", CP_DECSTA, AD_VARCODE, AD_VARIANCE, AD_RATENO, PRJ_NAME, EARMARK_AMOUNT_PRJ, CP_LIMITAWAL " +
				", withdrawlid, AA_NO, PRODUCTID, currency " +
			*/
			conn.QueryString = "select * from VW_CUSTPRODUCT "+
				"where ap_regno='"+ REGNO +"' and productid='"+ PRODUCT +
				"' and apptype='"+ APPTYPE +"' and PROD_SEQ = '" + PROD_SEQ + "'";
			conn.ExecuteQuery();
			string CP_DECSTA			= conn.GetFieldValue("CP_DECSTA");
			string AD_VARCODE			= conn.GetFieldValue("AD_VARCODE");
			string AD_VARIANCE			= conn.GetFieldValue("AD_VARIANCE");
			string AD_RATENO			= conn.GetFieldValue("AD_RATENO");
			LBL_PRJ_CODE.Text = conn.GetFieldValue("PRJ_NAME");
			LBL_EARMARK_AMOUNT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("EARMARK_AMOUNT_PRJ"));
			LBL_LIMIT_AWAL.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("CP_LIMITAWAL"));
			try {DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue("CP_LOANPURPOSE");}
			catch {DDL_CP_LOANPURPOSE.SelectedValue="";}

			/**
			conn.QueryString = "select * from vw_cs_withdrawl where ap_regno='" + REGNO + 
				"' and apptype = '"  + APPTYPE + 
				"' and productid='" + PRODUCT + 
				"' and PROD_SEQ = '" + PROD_SEQ + "'";
			conn.ExecuteQuery();
			***/
			string aa_no = conn.GetFieldValue("AA_NO"), productid = conn.GetFieldValue("PRODUCTID"), acc_seq = conn.GetFieldValue("ACC_SEQ");

			TXT_APPTYPE.Text				= conn.GetFieldValue("APPTYPEDESC");
			try {DDL_WITHDRAWLID.SelectedValue	= conn.GetFieldValue("withdrawlid");} catch {}
			try {DDL_PROJECT_CODE.SelectedValue = conn.GetFieldValue("PROJECT_CODE");} catch {DDL_PROJECT_CODE.SelectedValue = "";}
			TXT_AA_NO.Text					= conn.GetFieldValue("AA_NO");
			TXT_PRODUCT.Text				= conn.GetFieldValue("PRODUCTDESC");
			TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(conn.GetFieldValue("CP_EXLIMITVAL"));
			TXT_CP_EXRPLIMIT.Text			= tool.MoneyFormat(conn.GetFieldValue("CP_EXRPLIMIT"));
			TXT_CP_LIMIT.Text				= tool.MoneyFormat(conn.GetFieldValue("CP_LIMIT"));
			LBL_CURR2.Text					= conn.GetFieldValue("currency");
			TXT_CP_KETERANGAN.Text			= conn.GetFieldValue("cp_keterangan");
			TXT_PRODUCTID.Text				= conn.GetFieldValue("PRODUCTID");
			TXT_CP_JANGKAWKT.Text			= conn.GetFieldValue("CP_JANGKAWKT");
			try {DDL_CP_TENORCODE.SelectedValue	= conn.GetFieldValue("CP_TENORCODE");}
			catch {}

			///////////////////////////////////////////////////////////////////////////
			/// if withdrawal type is REKENING BARU (03), tenor mandatory
			/// if withdrawal type is PERUBAHAN LIMIT (04), tenor ga mandatory
			/// 
			if (DDL_WITHDRAWLID.SelectedValue == "03") 
			{
				TXT_CP_JANGKAWKT.CssClass = "mandatory";
				DDL_CP_TENORCODE.CssClass = "mandatory";
			}
			else if (DDL_WITHDRAWLID.SelectedValue == "04") 
			{
				TXT_CP_JANGKAWKT.CssClass = "";
				DDL_CP_TENORCODE.CssClass = "";
			}
			/////////////////////////////////////////////////////////////////////////////

			conn.QueryString = "select interesttype, currency from rfproduct where productid='" + PRODUCT + "'";
			conn.ExecuteQuery();
			
			LBL_CURR3.Text = conn.GetFieldValue("currency");

			if (conn.GetFieldValue("interesttype") == "01")
			{
				LBL_INTERESTTYPE.Text = "Bunga / p.a: Floating";
				conn.QueryString = "select * from vw_floatingrate where productid='"+ PRODUCT +"'";
				conn.ExecuteQuery();
				
				LBL_INTEREST.Text	= conn.GetFieldValue("rate");  
				if (CP_DECSTA == "")
				{
					LBL_VARCODE.Text	= conn.GetFieldValue("varcode");  
					LBL_VARIANCE.Text	= conn.GetFieldValue("variance");
					LBL_RATENO.Text		= conn.GetFieldValue("rateno");  
					
					try { DDL_DECVARCODE.SelectedValue = conn.GetFieldValue("varcode");  } catch {}
					TXT_DECVARIANCE.Text	= conn.GetFieldValue("variance");
				}
				else
				{
					LBL_VARCODE.Text	= AD_VARCODE;
					LBL_VARIANCE.Text	= AD_VARIANCE;
					LBL_RATENO.Text		= AD_RATENO;

					try { DDL_DECVARCODE.SelectedValue = AD_VARCODE;  } catch {}
					TXT_DECVARIANCE.Text	= AD_VARIANCE;
				}
			}
			else
			{
				LBL_INTERESTTYPE.Text = "Bunga / p.a: Fix";
				conn.QueryString = "select interesttyperate from rfproduct where productid='" + PRODUCT + "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue("interesttyperate") != "")
					LBL_INTEREST.Text = conn.GetFieldValue("interesttyperate");

				LBL_VARCODE.Visible = false;
				LBL_VARIANCE.Visible = false;
				
				DDL_DECVARCODE.Visible = false;
				TXT_DECVARIANCE.Visible = false;
			}

			//---------- VIEW EXCHANGE RATE ----------------------//
			try 
			{
				conn.QueryString = "select PRODUCTID, CURRENCY, C.CURRENCYRATE " +
					"from RFPRODUCT p " +
					"left join RFCURRENCY c on P.CURRENCY = C.CURRENCYID " +
					"where C.ACTIVE = '1' and P.ACTIVE = '1' and PRODUCTID = '" + PRODUCT + "'";
				conn.ExecuteQuery();

				TXT_CP_EXRPLIMIT.Text = conn.GetFieldValue("CURRENCYRATE");
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error !");
				return;
			}
			//------------------------------------------------------//
		}

		private void viewData() 
		{
			//---------------------- Get Credit Info Data ----------------------------//
			/*
			conn.QueryString = "select isnull(ap_isappeal,0) ap_isappeal from application where ap_regno = '"+ REGNO +"'";
			conn.ExecuteQuery();
			var_fromsta = conn.GetFieldValue("ap_isappeal");
			*/
			///////////////////////////////////////////////////////////////////////////////////
			/// Check between approval_decision (history) with trackhistory
			/// 
			conn.QueryString = "exec APPROVAL_CHECKHISTORY '" + REGNO + "', '" + PRODUCT + "', '" + APPTYPE + "', '" + USERID + "', '" + PROD_SEQ + "'";
			conn.ExecuteQuery();
			DataTable dt_chk = conn.GetDataTable().Copy();

			string var_fromsta = conn.GetFieldValue("CNT_APPROVAL");

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

				conn.QueryString = "select * from approval_decision where ap_regno = '"+REGNO+"' "+
					" and productid = '"+PRODUCT+"' and apptype = '"+APPTYPE+"' "+
					" and PROD_SEQ = '" + PROD_SEQ + "' and ad_fromsta = '"+var_fromsta+"' ";
				conn.ExecuteQuery();
			}

			DataTable dt_ad = new DataTable();
			dt_ad = conn.GetDataTable().Copy();

			conn.QueryString	= "exec approval_info '"+ REGNO +"', '"+ PRODUCT +"', '"+ APPTYPE +"', '"+ USERID +"', '"+ var_fromsta +"' , '" + PROD_SEQ + "', " + GlobalTools.ConvertNull(AD_SEQ);
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
				try {ddl_rate.SelectedValue	= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim();}
				catch {}
				try
				{txt_rate.Text			= Convert.ToString(double.Parse(ddl_rate.SelectedItem.Text) * 100);} 
				catch 
				{txt_rate.Text			= "";}
				try {ddl_varcode.SelectedValue	= dt_aprvinfo.Rows[0]["cp_varcode"].ToString().Trim();}
				catch {}
				txt_variance.Text			= dt_aprvinfo.Rows[0]["cp_variance"].ToString(); 
				txt_totcoll.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["lc_value"].ToString()); 
				txt_remark.Text				= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString(); 
				txt_installment.Text		= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_installment"].ToString()); 
				txt_exlimitval.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 
				txt_exrplimit.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 
				
				if (dt_ad.Rows.Count == 0)
				{
					TXT_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
					TXT_CP_JANGKAWKT.Text			= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
					try {DDL_CP_TENORCODE.SelectedValue	= dt_aprvinfo.Rows[0]["cp_tenorcode"].ToString().Trim();}
					catch {DDL_CP_TENORCODE.SelectedValue = "";}
					//LBL_INTEREST.Text	 			= dt_aprvinfo.Rows[0]["cp_interest"].ToString();
					try {ddl_decrate.SelectedValue	= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim();}
					catch {ddl_decrate.SelectedValue = "";}
					try {txt_decrate.Text = Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);} 
					catch {txt_decrate.Text = "";}
					//LBL_VARCODE.Text				= dt_aprvinfo.Rows[0]["cp_varcode"].ToString().Trim();
					//LBL_VARIANCE.Text				= dt_aprvinfo.Rows[0]["cp_variance"].ToString();
					txt_decremark.Text				= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString();
//					TXT_CP_INSTALLMENT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_installment"].ToString());
//					if ((TXT_CP_INSTALLMENT.Text == "0") || (TXT_CP_INSTALLMENT.Text == "0,00"))
//						TXT_CP_INSTALLMENT.Text = "-";
					TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 
					TXT_CP_EXRPLIMIT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 
//					txt_declimitchg.Text			= dt_aprvinfo.Rows[0]["cp_limitchg"].ToString();
//					txt_decgraceperiode.Text		= dt_aprvinfo.Rows[0]["cp_graceperiod"].ToString(); 
//					ddl_decpayfreq.SelectedValue	= dt_aprvinfo.Rows[0]["cp_paymentid"].ToString().Trim(); 

					//input approval decision -- ini comment
					if (PRODUCT != "")
					{
						if (TXT_CP_INSTALLMENT.Text == "-")
							TXT_CP_INSTALLMENT.Text = "0";
						conn.QueryString = "exec input_approvaldecision  '"+ REGNO +"', '"+ PRODUCT +"', "+
							" '"+ APPTYPE +"', '"+ USERID +"', "+
							" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+TXT_CP_JANGKAWKT.Text+"','"+DDL_CP_TENORCODE.SelectedValue+"', "+
							" "+tool.ConvertFloat(LBL_INTEREST.Text)+", '"+ddl_decrate.SelectedValue+"', '"+ DDL_DECVARCODE.SelectedValue +"', "+ tool.ConvertFloat(TXT_DECVARIANCE.Text)+", "+
							" '', '', '"+ txt_decremark.Text +"', "+ tool.ConvertFloat(TXT_CP_INSTALLMENT.Text) +", '0', '"+ lbl_decsta.Text +"', "+
							" "+tool.ConvertFloat(txt_exlimitval.Text)+", "+tool.ConvertFloat(txt_exrplimit.Text)+", '"+var_fromsta+"', "+
							" null, null, '" + PROD_SEQ + "'";
						conn.ExecuteQuery();
					}
				}
				else if (dt_aprvinfo.Rows[0]["userid"].ToString() == "")
				{
					conn.QueryString = "select * from approval_decision where ap_regno = '"+REGNO+"' "+
						" and productid = '"+ PRODUCT +"' and apptype = '"+APPTYPE+"' and PROD_SEQ = '" + PROD_SEQ + "' " +
						" and ad_seq = (select max(ad_seq) from approval_decision ad where approval_decision.ap_regno = ad.ap_regno "+
						" and approval_decision.productid = ad.productid and approval_decision.apptype = ad.apptype and approval_decision.PROD_SEQ = ad.PROD_SEQ) ";
					conn.ExecuteQuery();

					TXT_CP_LIMIT.Text				= tool.MoneyFormat(conn.GetFieldValue("ad_limit"));
					TXT_CP_JANGKAWKT.Text			= conn.GetFieldValue("ad_tenor");
					DDL_CP_TENORCODE.SelectedValue	= conn.GetFieldValue("ad_tenorcode").Trim();
					LBL_INTEREST.Text				= conn.GetFieldValue("ad_interest");
					ddl_decrate.SelectedValue		= conn.GetFieldValue("ad_rateno");
					try {txt_decrate.Text = Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);}
					catch {txt_decrate.Text = "";}

					LBL_VARCODE.Text				= conn.GetFieldValue("ad_varcode").Trim();
					LBL_VARIANCE.Text				= conn.GetFieldValue("ad_variance");
					try { DDL_DECVARCODE.SelectedValue = conn.GetFieldValue("ad_varcode").Trim(); } catch {}
					TXT_DECVARIANCE.Text			= conn.GetFieldValue("ad_variance");

					/* ////// tidak perlu karena usernya belum pernah visit
					 * 
					if (conn.GetFieldValue("ad_ovrsta") == "0")
						txt_decovrsta.Text			= "No";
					else if (conn.GetFieldValue("ad_ovrsta") == "1")
						txt_decovrsta.Text			= "Yes";
					ddl_decovrreason.SelectedValue	= conn.GetFieldValue("ad_ovrreason").Trim();
					txt_decovrreason.Text			= conn.GetFieldValue("ad_ovrreasontext");
					txt_decremark.Text				= conn.GetFieldValue("ad_keterangan");
					*/
//					TXT_CP_INSTALLMENT.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_installment"));
//					if ((TXT_CP_INSTALLMENT.Text == "0") || (TXT_CP_INSTALLMENT.Text == "0,00"))
//						TXT_CP_INSTALLMENT.Text = "-";
					lbl_decsta.Text					= conn.GetFieldValue("ad_reject");
					if (lbl_decsta.Text == "0")
						txt_decsta.Text				= "APPROVE BY PREVIOUS USER";
					else if (lbl_decsta.Text == "1")
						txt_decsta.Text				= "REJECT BY PREVIOUS USER";
					TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_exlimitval")); 
					TXT_CP_EXRPLIMIT.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_exrplimit")); 

					//input approval decision
					if (PRODUCT != "")
					{
						if (TXT_CP_INSTALLMENT.Text == "-")
							TXT_CP_INSTALLMENT.Text = "0";
						conn.QueryString = "exec input_approvaldecision  '"+REGNO+"', '"+ PRODUCT +"', "+
							" '"+APPTYPE+"', '"+USERID+"', "+
							" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+TXT_CP_JANGKAWKT.Text+"','"+DDL_CP_TENORCODE.SelectedValue+"', "+
							" "+tool.ConvertFloat(LBL_INTEREST.Text)+", '"+ddl_decrate.SelectedValue+"', '"+ DDL_DECVARCODE.SelectedValue +"', "+tool.ConvertFloat(TXT_DECVARIANCE.Text)+", "+
							" '"+ddl_decovrreason.SelectedValue+"', '"+txt_decovrreason.Text+"', '"+txt_decremark.Text+"', "+
							" "+tool.ConvertFloat(TXT_CP_INSTALLMENT.Text)+", '0', '"+lbl_decsta.Text+"', "+
							" "+tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", '"+var_fromsta+"', "+
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
						TXT_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_limit"].ToString());
						TXT_CP_JANGKAWKT.Text			= dt_aprvinfo.Rows[0]["ad_tenor"].ToString();
						DDL_CP_TENORCODE.SelectedValue	= dt_aprvinfo.Rows[0]["ad_tenorcode"].ToString().Trim();
						LBL_INTEREST.Text				= dt_aprvinfo.Rows[0]["ad_interest"].ToString();
						ddl_decrate.SelectedValue		= dt_aprvinfo.Rows[0]["ad_rateno"].ToString();
						try
						{txt_decrate.Text			= Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);}
						catch
						{txt_decrate.Text			= "";}

						LBL_VARCODE.Text			= dt_aprvinfo.Rows[0]["ad_varcode"].ToString().Trim();
						LBL_VARIANCE.Text			= dt_aprvinfo.Rows[0]["ad_variance"].ToString();
						try { DDL_DECVARCODE.SelectedValue = dt_aprvinfo.Rows[0]["ad_varcode"].ToString().Trim(); } catch {}
						TXT_DECVARIANCE.Text			= dt_aprvinfo.Rows[0]["ad_variance"].ToString();

						txt_decovrsta.Text				= dt_aprvinfo.Rows[0]["ad_ovrsta"].ToString();
						ddl_decovrreason.SelectedValue	= dt_aprvinfo.Rows[0]["ad_ovrreason"].ToString().Trim();
						txt_decovrreason.Text			= dt_aprvinfo.Rows[0]["ad_ovrreasontext"].ToString();
						txt_decremark.Text				= dt_aprvinfo.Rows[0]["ad_keterangan"].ToString();
						/*
						TXT_CP_INSTALLMENT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_installment"].ToString());
						if ((TXT_CP_INSTALLMENT.Text == "0") || (TXT_CP_INSTALLMENT.Text == "0,00"))
							TXT_CP_INSTALLMENT.Text = "-";
						*/
						txt_decsta.Text					= dt_aprvinfo.Rows[0]["ad_rejectdesc"].ToString();
						lbl_decsta.Text					= dt_aprvinfo.Rows[0]["ad_reject"].ToString();
						TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_exlimitval"].ToString()); 
						TXT_CP_EXRPLIMIT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_exrplimit"].ToString()); 					
					} 
					else 
					{
						TXT_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
						TXT_CP_JANGKAWKT.Text			= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
						DDL_CP_TENORCODE.SelectedValue	= dt_aprvinfo.Rows[0]["cp_tenorcode"].ToString().Trim();
						ddl_decrate.SelectedValue		= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim(); 
						try {txt_decrate.Text = Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);} 
						catch {txt_decrate.Text = "";}
						txt_decremark.Text				= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString();
						TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 
						TXT_CP_EXRPLIMIT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 

						///////////////////////////////////////////////////////////////////////////////////////
						/// Insert a new record into approval_decision with an increment on ad_fromsta field
						/// 
						string ad_fromsta_new = "";
						int _ad_fromsta = 0;
						try { _ad_fromsta = Convert.ToInt16(var_fromsta) + 1; } 
						catch {}
						ad_fromsta_new = _ad_fromsta.ToString();

						/// input approval decision
						if (PRODUCT != "")
						{
							if (TXT_CP_INSTALLMENT.Text == "-")
								TXT_CP_INSTALLMENT.Text = "0";
							conn.QueryString = "exec input_approvaldecision  '"+ REGNO +"', '"+ PRODUCT +"', "+
								" '"+ APPTYPE +"', '"+ USERID +"', "+
								" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+TXT_CP_JANGKAWKT.Text+"','"+DDL_CP_TENORCODE.SelectedValue+"', "+
								" "+tool.ConvertFloat(LBL_INTEREST.Text)+", '"+ddl_decrate.SelectedValue+"', '"+ DDL_DECVARCODE.SelectedValue +"', "+ tool.ConvertFloat(TXT_DECVARIANCE.Text) + ", "+
								" '', '', '"+ txt_decremark.Text +"', "+ tool.ConvertFloat(TXT_CP_INSTALLMENT.Text) +", '0', '"+ lbl_decsta.Text +"', "+
								" "+tool.ConvertFloat(txt_exlimitval.Text)+", "+tool.ConvertFloat(txt_exrplimit.Text)+", '"+ad_fromsta_new+"', "+
								" null, null, '" + PROD_SEQ + "'";
							conn.ExecuteQuery();
						}
					}
				}
			}

			conn.QueryString = "select interesttype from rfproduct where productid = '"+ PRODUCT +"'";
			conn.ExecuteQuery();
			string var_inttype = conn.GetFieldValue("interesttype");
			if (var_inttype == "01")	//--- floating ---//
			{
				tr_fix.Visible	  = false;
				//tr_decfix.Visible = false;
			}
			else if (var_inttype == "02")	//--- fix ---//
			{
				tr_float.Visible    = false;
				//tr_decfloat.Visible = false;
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

		}
		#endregion

		protected void lb_struc_Click(object sender, System.EventArgs e)
		{
			if ((PRODUCT == "") && (APPTYPE == ""))
			{
				Tools.popMessage(this, "Check Facilities of Structure Credit First!");
				return;
			}

			/************
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
				if (conn.GetFieldValue("iscashloan") == "0")
					conn.QueryString = "select screenlink from apptypelink where APPTYPEID = '"+APPTYPE+ "' and PRODUCTID='" + "M21" + "' and fungsiId='CS' and iscashloan='0'";
				else	
					conn.QueryString = "select screenlink from apptypelink where APPTYPEID = '"+APPTYPE+ "' and PRODUCTID='" + "M21" + "' and fungsiId='CS' and iscashloan='1'";
			}
			else
				conn.QueryString = "select screenlink from apptypelink where APPTYPEID = '"+APPTYPE+ "' and PRODUCTID='" + "M21" + "' and fungsiId='CS' ";
			conn.ExecuteQuery();

			Response.Write("<script for=window event=onload language='javascript'>PopupPage('/SME/DataEntry/" + conn.GetFieldValue("screenlink")+"?regno="+REGNO+"&apptype="+APPTYPE+ "&prodid="+PRODUCT +"&prod_seq="+ PROD_SEQ +"&teks="+var_text+ "&de=0" + "', '900', '500');</script>");			
			*****************/

			Response.Write("<script language='javascript'>window.open('../dataentry/CustProduct.aspx?regno=" + REGNO + "&curef=" + CUREF + "&sta=view','StrukturKredit','status=no,scrollbars=yes,width=800,height=600');</script>");
		}

		protected void btn_override_Click(object sender, System.EventArgs e)
		{
			if (double.Parse(TXT_CP_EXLIMITVAL.Text) > double.Parse(txt_exlimitval.Text))
			{
				Tools.popMessage(this, "Approval limit Cannot greater than Requested Limit");
				return;
			}
			if (txt_decovrreason.Text.Trim() == "")
			{
				GlobalTools.popMessage(this, "Override reason harus diisi!");
				return;
			}

			conn.QueryString = "select in_kreditbaru from rfinitial";
			conn.ExecuteQuery();
			if (APPTYPE == conn.GetFieldValue("in_kreditbaru"))
			{
				conn.QueryString = "select isnull(su_emaslimit, 0)su_emaslimit from scuser "+
					" where userid = '"+ USERID +"'";
				conn.ExecuteQuery();
				if (double.Parse(TXT_CP_LIMIT.Text) > double.Parse(conn.GetFieldValue("su_emaslimit").ToString()))
				{
					GlobalTools.popMessage(this, "Limit in rupiah cannot greater than eMas Limit");
					return;
				}
			}

			if (((int.Parse(TXT_CP_JANGKAWKT.Text) < 30) && (DDL_CP_TENORCODE.SelectedValue == "D")) || ((int.Parse(TXT_CP_JANGKAWKT.Text) < 1) && (DDL_CP_TENORCODE.SelectedValue == "M")))
			{
				GlobalTools.popMessage(this, "Tenor Cannot below 30 days or 1 month");
				return;
			}
			
			/*conn.QueryString = "select isnull(ap_isappeal,0) ap_isappeal from application where ap_regno = '"+ REGNO +"'";
			conn.ExecuteQuery();
			var_fromsta = conn.GetFieldValue("ap_isappeal");*/

			conn.QueryString = "exec APPROVAL_CHECKHISTORY '" + REGNO + "', '" + PRODUCT + "', '" + APPTYPE + "', '" + USERID + "', '" + PROD_SEQ + "'";
			conn.ExecuteQuery();
			var_fromsta = conn.GetFieldValue("CNT_APPROVAL");

			TXT_CP_LIMIT.Text = Convert.ToString((double.Parse(TXT_CP_EXLIMITVAL.Text)*double.Parse(TXT_CP_EXRPLIMIT.Text)));

			Response.Write("KALKULASI EARMARK AMOUNT ...."); 
			CalculateInstallment();
			if (TXT_CP_INSTALLMENT.Text == "-")
				TXT_CP_INSTALLMENT.Text = "0";

			conn.QueryString = "exec input_approvaldecision  '"+ REGNO +"', '"+ PRODUCT +"', "+
				" '"+ APPTYPE +"', '"+ USERID +"', "+
				" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+TXT_CP_JANGKAWKT.Text+"','"+DDL_CP_TENORCODE.SelectedValue+"', "+
				" "+tool.ConvertFloat(LBL_INTEREST.Text)+", '"+LBL_RATENO.Text+"', '"+ DDL_DECVARCODE.SelectedValue +"', "+ tool.ConvertFloat(TXT_DECVARIANCE.Text)+", "+
				" '"+ddl_decovrreason.SelectedValue+"', '"+txt_decovrreason.Text+"', '"+txt_decremark.Text+"', "+tool.ConvertFloat(TXT_CP_INSTALLMENT.Text)+", "+
				" '1', '"+lbl_decsta.Text+"', "+tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", '"+var_fromsta+"', "+
				" null, null, '" + PROD_SEQ + "'";
			conn.ExecuteQuery();			
		}

		protected void BTN_EARMARK_Click(object sender, System.EventArgs e)
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
				conn.QueryString = "UPDATE KETENTUAN_KREDIT SET PRJ_CODE = " + GlobalTools.ConvertNull(DDL_PROJECT_CODE.SelectedValue) + " WHERE KET_CODE = '" + KET_CODE + "'";
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

		protected void BTN_NEGATIVE_YES_Click(object sender, System.EventArgs e)
		{
			TXT_NEGATIVE.Text = "YES";
			BTN_EARMARK_Click(sender, e);
			TXT_NEGATIVE.Text = "NO";
			tr_confirm_negative.Visible = false;
		}

		protected void BTN_NEGATIVE_NO_Click(object sender, System.EventArgs e)
		{
			tr_confirm_negative.Visible = false;
		}

		protected void btn_Save_Click(object sender, System.EventArgs e)
		{
			if (DDL_PROJECT_CODE.SelectedValue == "")
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
					conn.QueryString = "UPDATE KETENTUAN_KREDIT SET PRJ_CODE = " + GlobalTools.ConvertNull(DDL_PROJECT_CODE.SelectedValue) + " WHERE KET_CODE = '" + KET_CODE + "'";
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

		protected void DDL_DECVARCODE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CalculateInstallment();
		}

		protected void TXT_DECVARIANCE_TextChanged(object sender, System.EventArgs e)
		{
			CalculateInstallment();
		}

		private void viewData2()
		{
			conn.QueryString	= "exec approval_info_view2 '"+ REGNO +"', '"+ PRODUCT +"', '"+ APPTYPE +"', '"+ USERID +"','" + PROD_SEQ + "'";
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
				
				TXT_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
				TXT_CP_JANGKAWKT.Text			= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
				DDL_CP_TENORCODE.SelectedValue	= dt_aprvinfo.Rows[0]["cp_tenorcode"].ToString().Trim();
				ddl_decrate.SelectedValue		= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim(); 
				txt_decremark.Text				= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString();
				TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 
				TXT_CP_EXRPLIMIT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 
			}
		}
	}
}
