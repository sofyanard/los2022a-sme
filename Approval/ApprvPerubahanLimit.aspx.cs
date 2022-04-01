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
	/// Summary description for ApprvPerubahanLimit.
	/// </summary>
	public partial class ApprvPerubahanLimit : System.Web.UI.Page
	{
	
		#region " My Variables "
		private Connection conn;
		private Tools tool = new Tools();
		private string REGNO, CUREF, PRODUCT, APPTYPE, TC, USERID, MC, PROD_SEQ, var_fromsta, TEKS, STA, AD_SEQ, KET_CODE;
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
			STA			= Request.QueryString["sta"];
			AD_SEQ		= Request.QueryString["ad_seq"];
			KET_CODE	= Request.QueryString["ket_code"];
	
			if (!IsPostBack) 			
			{
				kreditAwal.Visible = false;
				initializeDropDowns();

				viewDataGeneral();

				if(STA=="view") viewData2();
				else viewData();

				secureData(); 

				tr_confirm_negative.Visible = false;
			}

			btn_override.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1)){return false;};");
		}

		private void initializeDropDowns() 
		{
			/*
			GlobalTools.fillRefList(ddl_decovrreason, "select reasonid, reasondesc from RFREASON where reasontype = '2' and active = '1'", false, conn);
			GlobalTools.fillRefList(DDL_PROJECT_CODE, "select * from VW_RFPROJECT where active = '1'", false, conn);
			*/

			if (STA == "view") GlobalTools.fillRefList(ddl_decovrreason, "select reasonid, reasondesc from RFREASON where reasontype = '2'", false, conn);
			else GlobalTools.fillRefList(ddl_decovrreason, "select reasonid, reasondesc from RFREASON where reasontype = '2' and active = '1'", false, conn);

			if (STA == "view") GlobalTools.fillRefList(DDL_PROJECT_CODE, "select * from VW_RFPROJECT", conn);
			else GlobalTools.fillRefList(DDL_PROJECT_CODE, "select * from VW_rfproject where active = '1'", false, conn);

			if (STA == "view")GlobalTools.fillRefList(DDL_CP_LOANPURPOSE, "select * from rfloanpurpose", conn);
			else GlobalTools.fillRefList(DDL_CP_LOANPURPOSE, "select * from rfloanpurpose where active = '1'", conn);
		}

		private void viewDataGeneral() 
		{
			//--- ISIDDL ---
			try 
			{
				conn.QueryString="select cu_ref from application where ap_regno='"+REGNO+"'";	
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}
			TXT_CP_CUREF.Text	= conn.GetFieldValue("cu_ref");
			
			try 
			{
				conn.QueryString = "select aa_no, acc_seq from custproduct where ap_regno='" + REGNO + "' and productid='" + PRODUCT + "' and apptype='" + APPTYPE + "' and prod_seq = '" + PROD_SEQ + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}
			LBL_AA_NO.Text = conn.GetFieldValue("AA_NO");			

			//DDL_CP_NOREK.Items.Add(new ListItem(conn.GetFieldValue("acc_seq"), conn.GetFieldValue("acc_seq")));
			//DDL_CP_NOREK.SelectedValue = conn.GetFieldValue("acc_seq");
			//TXT_PRODUCTID.Text = PRODUCT;			

			conn.QueryString = "select LIMIT, TENOR, TENORCODE, ACC_NO from bookedprod " +  
				"where aa_no='" + conn.GetFieldValue("aa_no") + 
				"' and productid='" + PRODUCT + 
				"' and acc_seq='" + conn.GetFieldValue("acc_seq") + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				LBL_ACC_NO.Text			= conn.GetFieldValue("ACC_NO");
				LBL_CP_LIMITLAMA.Text	= tool.MoneyFormat(conn.GetFieldValue(0, "LIMIT"));
				TXT_NEWTENOR.Text		= conn.GetFieldValue(0, "TENOR");
				LBL_NEWTENORCODE.Text	= conn.GetFieldValue(0, "TENORCODE");
			}

			//--- DATA GENERAL ---
			try 
			{
				/*
				conn.QueryString="select APPTYPEDESC, PRODUCTDESC, CP_LOANPURPOSE, "+
					"CP_LIMIT, CP_installment, CP_EXRPLIMIT, CP_EXLIMITVAL, CP_VARCODE, CP_RATENO, CP_VARIANCE, "+
					"CP_KETERANGAN, ACC_SEQ, CP_JANGKAWKT, CP_TENORCODE, REVOLVING, aa_no+'#'+convert(varchar,acc_seq) as seq "+
					", CP_DECSTA, AD_VARCODE, AD_VARIANCE, AD_RATENO, CP_LIMITCHG, PRJ_NAME, EARMARK_AMOUNT_PRJ "+
				*/
				conn.QueryString = "select * from VW_CUSTPRODUCT "+
					"where ap_regno='"+ REGNO +"' and productid='"+ PRODUCT +"' and apptype='" + APPTYPE + "' and PROD_SEQ = '" + PROD_SEQ + "'";
				conn.ExecuteQuery();
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			LBL_APPTYPE.Text			= conn.GetFieldValue("APPTYPEDESC");
			LBL_PRODUCT.Text			= conn.GetFieldValue("PRODUCTDESC");
			LBL_CP_LIMIT.Text			= tool.MoneyFormat(conn.GetFieldValue("CP_LIMIT"));
			TXT_CP_LIMIT.Text			= tool.MoneyFormat(conn.GetFieldValue("CP_LIMIT"));
			TXT_CP_INSTALLMENT.Text		= tool.MoneyFormat(conn.GetFieldValue("CP_installment"));
			TXT_CP_EXRPLIMIT.Text		= tool.MoneyFormat(conn.GetFieldValue("CP_EXRPLIMIT"));
			TXT_CP_EXLIMITVAL.Text		= tool.MoneyFormat(conn.GetFieldValue("CP_EXLIMITVAL"));
			TXT_CP_KETERANGAN.Text		= conn.GetFieldValue("CP_KETERANGAN");
			try {DDL_CP_LIMITCHG.SelectedValue = conn.GetFieldValue("CP_LIMITCHG");}
			catch {DDL_CP_LIMITCHG.SelectedValue = "+";}
			try {DDL_PROJECT_CODE.SelectedValue = conn.GetFieldValue("PROJECT_CODE");}
			catch {DDL_PROJECT_CODE.SelectedValue = "";}
			try {DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue("CP_LOANPURPOSE");}
			catch {DDL_CP_LOANPURPOSE.SelectedValue="";}
			string CP_DECSTA			= conn.GetFieldValue("CP_DECSTA");
			string AD_VARCODE			= conn.GetFieldValue("AD_VARCODE");
			string AD_VARIANCE			= conn.GetFieldValue("AD_VARIANCE");
			string AD_RATENO			= conn.GetFieldValue("AD_RATENO");
			/***
			for (int g=0; g<DDL_CP_NOREK.Items.Count; g++)
			{
				if (DDL_CP_NOREK.Items[g].Value.ToString()== conn.GetFieldValue("SEQ").ToString())
					DDL_CP_NOREK.SelectedValue		= conn.GetFieldValue("SEQ");				
			}
			***/
			LBL_PRJ_CODE.Text		= conn.GetFieldValue("PRJ_NAME");
			LBL_EARMARK_AMOUNT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("EARMARK_AMOUNT_PRJ"));
			conn.ClearData();

			LBL_TITLE.Text		= TEKS;
			LBL_PRODUCTID.Text	= PRODUCT;

			/***
			 * TODO : Tidak Perlu ???
			try 
			{
				conn.QueryString = "select interesttype, currency from rfproduct where productid='" + LBL_PRODID.Text + "'";
				conn.ExecuteQuery();
			}			
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}
			
			LBL_CURR1.Text = conn.GetFieldValue("currency");
			LBL_CURR2.Text = conn.GetFieldValue("currency");
			LBL_CURR3.Text = conn.GetFieldValue("currency");

			if (conn.GetFieldValue(0,0) == "01")
			{
				LBL_INTERESTTYPE.Text = "Bunga / p.a: Floating";
				conn.QueryString = "select * from vw_floatingrate where productid='" + LBL_PRODID.Text + "'";
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
				conn.QueryString = "select interesttyperate from rfproduct where productid='" + LBL_PRODID.Text + "'";
				conn.ExecuteQuery();
				LBL_INTEREST.Text = conn.GetFieldValue("interesttyperate");
				LBL_VARIANCE.Visible = false;
			}
			***/
		}

		private void viewData() 
		{
			//////////////////////////////////////////////////////////////////////////////
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

				conn.QueryString = "select * from approval_decision where ap_regno = '"+REGNO+"' "+
					" and productid = '"+PRODUCT+"' and apptype = '"+APPTYPE+"' "+
					" and PROD_SEQ = '" + PROD_SEQ + "' and ad_fromsta = '"+var_fromsta+"' ";
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
				Response.Write("<!-- dt_aprvinfo.Rows.Count != 0 -->");

				LBL_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
				TXT_NEWTENOR.Text				= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
				LBL_NEWTENORCODE.Text			= dt_aprvinfo.Rows[0]["cp_tenorcodedesc"].ToString();				
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
				
				if (dt_ad.Rows.Count == 0)
				{
					LBL_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
					TXT_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
					TXT_NEWTENOR.Text				= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
					LBL_NEWTENORCODE.Text			= dt_aprvinfo.Rows[0]["cp_tenorcode"].ToString().Trim();
					LBL_INTEREST.Text	 			= dt_aprvinfo.Rows[0]["cp_interest"].ToString();
					LBL_RATENO.Text					= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim(); 
					LBL_VARCODE.Text				= dt_aprvinfo.Rows[0]["cp_varcode"].ToString().Trim();
					LBL_VARIANCE.Text				= dt_aprvinfo.Rows[0]["cp_variance"].ToString();
					TXT_CP_KETERANGAN.Text			= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString();
					TXT_CP_INSTALLMENT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_installment"].ToString());
					if ((TXT_CP_INSTALLMENT.Text == "0") || (TXT_CP_INSTALLMENT.Text == "0,00"))
						TXT_CP_INSTALLMENT.Text = "-";
					TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 
					TXT_CP_EXRPLIMIT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 
					try {DDL_CP_LIMITCHG.SelectedValue   = dt_aprvinfo.Rows[0]["cp_limitchg"].ToString();}
					catch {DDL_CP_LIMITCHG.SelectedValue = "+";}

					//input approval decision
					if (PRODUCT != "")
					{
						if (TXT_CP_INSTALLMENT.Text == "-")
							TXT_CP_INSTALLMENT.Text = "0";
						conn.QueryString = "exec input_approvaldecision  '"+REGNO+"', '"+PRODUCT+"', "+
							" '"+APPTYPE+"', '"+USERID+"', "+
							" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+TXT_NEWTENOR.Text+"','"+LBL_NEWTENORCODE.Text+"', "+
							" "+tool.ConvertFloat(LBL_INTEREST.Text)+", '"+LBL_RATENO.Text+"', '"+LBL_VARCODE.Text+"', "+ GlobalTools.ConvertFloat(LBL_VARIANCE.Text) +", "+
							" '', '', '"+TXT_CP_KETERANGAN.Text+"', "+tool.ConvertFloat(LBL_INSTALLMENT.Text)+", '0', '"+LBL_DECSTA.Text+"', "+
							" "+tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", '"+var_fromsta+"', "+
							" null, null, '" + PROD_SEQ + "'";
						conn.ExecuteQuery();
					}
				}
				else if (dt_aprvinfo.Rows[0]["userid"].ToString() == "")
				{
					Response.Write("<!-- dt_aprvinfo.Rows[0][userid].ToString() == '' -->");

					conn.QueryString = "select * from approval_decision where ap_regno = '"+REGNO+"' "+
						" and productid = '"+PRODUCT+"' and apptype = '"+APPTYPE+"' and PROD_SEQ = '" + PROD_SEQ + "' " +
						" and ad_seq = (select max(ad_seq) from approval_decision ad where approval_decision.ap_regno = ad.ap_regno "+
						" and approval_decision.productid = ad.productid and approval_decision.apptype = ad.apptype and approval_decision.PROD_SEQ = ad.PROD_SEQ) ";
					conn.ExecuteQuery();

					LBL_CP_LIMIT.Text				= tool.MoneyFormat(conn.GetFieldValue("ad_limit"));
					TXT_CP_LIMIT.Text				= tool.MoneyFormat(conn.GetFieldValue("ad_limit"));
					TXT_NEWTENOR.Text				= conn.GetFieldValue("ad_tenor");
					LBL_NEWTENORCODE.Text			= conn.GetFieldValue("ad_tenorcode").Trim();
					LBL_INTEREST.Text				= conn.GetFieldValue("ad_interest");
					LBL_RATENO.Text					= conn.GetFieldValue("ad_rateno");
//					try
//					{txt_decrate.Text				= Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);}
//					catch
//					{txt_decrate.Text				= "";}
					LBL_VARCODE.Text				= conn.GetFieldValue("ad_varcode").Trim();
					LBL_VARIANCE.Text				= conn.GetFieldValue("ad_variance");

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

					LBL_INSTALLMENT.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_installment"));
					if ((LBL_INSTALLMENT.Text == "0") || (LBL_INSTALLMENT.Text == "0,00"))
						LBL_INSTALLMENT.Text = "-";
					LBL_DECSTA.Text					= conn.GetFieldValue("ad_reject");
					if (LBL_DECSTA.Text == "0")
						txt_decsta.Text				= "APPROVE BY PREVIOUS USER";
					else if (LBL_DECSTA.Text == "1")
						txt_decsta.Text				= "REJECT BY PREVIOUS USER";
					TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_exlimitval")); 
					TXT_CP_EXRPLIMIT.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_exrplimit")); 
					try {DDL_CP_LIMITCHG.SelectedValue   = dt_aprvinfo.Rows[0]["cp_limitchg"].ToString();}
					catch {DDL_CP_LIMITCHG.SelectedValue = "+";}
//					txt_decgraceperiode.Text		= conn.GetFieldValue("ad_graceperiod"); 
//					ddl_decpayfreq.SelectedValue	= conn.GetFieldValue("ad_paymentid"); 

					//input approval decision
					if (PRODUCT != "")
					{
						if (LBL_INSTALLMENT.Text == "-")
							LBL_INSTALLMENT.Text = "0";
						conn.QueryString = "exec input_approvaldecision  '"+REGNO+"', '"+PRODUCT+"', "+
							" '"+APPTYPE+"', '"+USERID+"', "+
							" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+TXT_NEWTENOR.Text+"','"+LBL_NEWTENORCODE.Text+"', "+
							" "+tool.ConvertFloat(LBL_INTEREST.Text)+", '"+LBL_RATENO.Text+"', '"+LBL_VARCODE.Text+"', "+tool.ConvertFloat(LBL_VARIANCE.Text)+", "+
							" '"+ddl_decovrreason.SelectedValue+"', '"+txt_decovrreason.Text+"', '"+txt_decremark.Text+"', "+
							" "+tool.ConvertFloat(LBL_INSTALLMENT.Text)+", '0', '"+LBL_DECSTA.Text+"', "+
							" "+tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", '"+var_fromsta+"', "+
							" null, null, '" + PROD_SEQ + "'";
						conn.ExecuteQuery();
					}
				}
				else if (conn.GetFieldValue("userid") != "")
				{
					Response.Write("<!-- conn.GetFieldValue('userid') != '' -->");

					///////////////////////////////////////////////////////////////////////////////////
					/// Check between approval_decision (history) with trackhistory
					/// 
					if (dt_chk.Rows[0]["SAME_STATUS"].ToString() == "YES") 
					{
						LBL_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_limit"].ToString());
						TXT_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_limit"].ToString());
						TXT_NEWTENOR.Text				= dt_aprvinfo.Rows[0]["ad_tenor"].ToString();
						LBL_NEWTENORCODE.Text			= dt_aprvinfo.Rows[0]["ad_tenorcode"].ToString().Trim();
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
						txt_decremark.Text				= dt_aprvinfo.Rows[0]["ad_keterangan"].ToString();
						LBL_INSTALLMENT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_installment"].ToString());
						if ((LBL_INSTALLMENT.Text == "0") || (LBL_INSTALLMENT.Text == "0,00"))
							LBL_INSTALLMENT.Text = "-";
						txt_decsta.Text					= dt_aprvinfo.Rows[0]["ad_rejectdesc"].ToString();
						LBL_DECSTA.Text					= dt_aprvinfo.Rows[0]["ad_reject"].ToString();
						TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_exlimitval"].ToString()); 
						TXT_CP_EXRPLIMIT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_exrplimit"].ToString()); 
						try {DDL_CP_LIMITCHG.SelectedValue   = dt_aprvinfo.Rows[0]["cp_limitchg"].ToString();}
						catch {DDL_CP_LIMITCHG.SelectedValue = "+";}
							/*
						txt_decgraceperiode.Text		= dt_aprvinfo.Rows[0]["ad_graceperiod"].ToString(); 
						ddl_decpayfreq.SelectedValue	= dt_aprvinfo.Rows[0]["ad_paymentid"].ToString().Trim(); 
							*/
					}
					else 
					{
						LBL_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
						TXT_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
						TXT_NEWTENOR.Text				= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
						LBL_NEWTENORCODE.Text			= dt_aprvinfo.Rows[0]["cp_tenorcode"].ToString().Trim();
						LBL_INTEREST.Text	 			= dt_aprvinfo.Rows[0]["cp_interest"].ToString();
						LBL_RATENO.Text					= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim(); 
						LBL_VARCODE.Text				= dt_aprvinfo.Rows[0]["cp_varcode"].ToString().Trim();
						LBL_VARIANCE.Text				= dt_aprvinfo.Rows[0]["cp_variance"].ToString();
						TXT_CP_KETERANGAN.Text			= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString();
						TXT_CP_INSTALLMENT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_installment"].ToString());
						if ((TXT_CP_INSTALLMENT.Text == "0") || (TXT_CP_INSTALLMENT.Text == "0,00"))
							TXT_CP_INSTALLMENT.Text = "-";
						TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 
						TXT_CP_EXRPLIMIT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 
						try {DDL_CP_LIMITCHG.SelectedValue   = dt_aprvinfo.Rows[0]["cp_limitchg"].ToString();}
						catch {DDL_CP_LIMITCHG.SelectedValue = "+";}

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
								" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+TXT_NEWTENOR.Text+"','"+LBL_NEWTENORCODE.Text+"', "+
								" "+tool.ConvertFloat(LBL_INTEREST.Text)+", '"+LBL_RATENO.Text+"', '"+LBL_VARCODE.Text+"', "+LBL_VARIANCE.Text+", "+
								" '', '', '"+TXT_CP_KETERANGAN.Text+"', "+tool.ConvertFloat(LBL_INSTALLMENT.Text)+", '0', '"+LBL_DECSTA.Text+"', "+
								" "+tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", '"+ad_fromsta_new+"', "+
								" null, null, '" + PROD_SEQ + "'";
							conn.ExecuteQuery();
						}
					}
				}

				conn.ClearData();
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

			/*********
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
			****/

			Response.Write("<script language='javascript'>window.open('../dataentry/CustProduct.aspx?regno=" + REGNO + "&curef=" + CUREF + "&sta=view','StrukturKredit','status=no,scrollbars=yes,width=800,height=600');</script>");

			//Response.Write("<script for=window event=onload language='javascript'>PopupPage('/SME/DataEntry/" + conn.GetFieldValue("screenlink")+"?regno="+REGNO+"&apptype="+APPTYPE+ "&prodid="+ PRODUCT +"&prod_seq="+ PROD_SEQ +"&teks="+var_text+ "&de=0" + "', '900', '500');</script>");
			//Response.Write("<script language='javascript'>window.open('/SME/DataEntry/" + conn.GetFieldValue("screenlink")+"?regno="+REGNO+"&apptype="+APPTYPE+ "&prodid="+PRODUCT+"&teks="+var_text+ "&de=0" + "', 'CreditStructure', 'status=yes,scrollbars=yes,width=900,height=500');</script>");
		}

		protected void btn_override_Click(object sender, System.EventArgs e)
		{
			string var_fromsta = "";

			if (double.Parse(TXT_CP_EXLIMITVAL.Text) > double.Parse(txt_exlimitval.Text))
			{
				GlobalTools.popMessage(this, "Approval limit Cannot greater than Requested Limit");
				return;
			}

			/***
			 * Tidak perlu cek eMAS limit user dengan limit aplikasi (kata pa Cheng)
			 * 
			conn.QueryString = "select in_kreditbaru from rfinitial";
			conn.ExecuteQuery();
			if (APPTYPE == conn.GetFieldValue("in_kreditbaru"))
			{
				conn.QueryString = "select isnull(su_emaslimit, 0)su_emaslimit from scuser "+
					" where userid = '" + USERID + "'";
				conn.ExecuteQuery();
				//if (double.Parse(txt_declimit.Text) > double.Parse(conn.GetFieldValue("su_emaslimit").ToString()))
				if (double.Parse(TXT_CP_LIMIT.Text) > double.Parse(conn.GetFieldValue("su_emaslimit").ToString()))
				{
					GlobalTools.popMessage(this, "Limit in rupiah cannot greater than eMas Limit");
					return;
				}
			}
			***/

			//if (((int.Parse(txt_dectenor.Text) < 30) && (ddl_dectenorcode.SelectedValue == "D")) || ((int.Parse(txt_dectenor.Text) < 1) && (ddl_dectenorcode.SelectedValue == "M")))
			if (((int.Parse(TXT_NEWTENOR.Text) < 30) && (LBL_NEWTENORCODE.Text == "D")) || ((int.Parse(TXT_NEWTENOR.Text) < 1) && (LBL_NEWTENORCODE.Text == "M")))
			{
				GlobalTools.popMessage(this, "Tenor Cannot below 30 days or 1 month");
				return;
			}
				
			/*
			conn.QueryString = "select isnull(ap_isappeal,0) ap_isappeal from application where ap_regno = '" + REGNO + "'";
			conn.ExecuteQuery();
			var_fromsta = conn.GetFieldValue("ap_isappeal");
			*/
			conn.QueryString = "exec APPROVAL_CHECKHISTORY '" + REGNO + "', '" + PRODUCT + "', '" + APPTYPE + "', '" + USERID + "', '" + PROD_SEQ + "'";
			conn.ExecuteQuery();
			var_fromsta = conn.GetFieldValue("CNT_APPROVAL");

			//txt_declimit.Text = Convert.ToString((double.Parse(txt_decexlimitval.Text)*double.Parse(txt_decexrplimit.Text)));
			LBL_CP_LIMIT.Text = Convert.ToString((double.Parse(TXT_CP_EXLIMITVAL.Text)*double.Parse(TXT_CP_EXRPLIMIT.Text)));
			TXT_CP_LIMIT.Text = Convert.ToString((double.Parse(TXT_CP_EXLIMITVAL.Text)*double.Parse(TXT_CP_EXRPLIMIT.Text)));
			//CalculateInstallment();
			//if (LBL_CP_INSTALLMENT.Text == "-")
			//	LBL_CP_INSTALLMENT.Text = "0";
			
			conn.QueryString = "exec input_approvaldecision  '" + REGNO + "', '" + PRODUCT + "', "+
				" '" + APPTYPE + "', '" + USERID + "', "+
				" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+TXT_NEWTENOR.Text+"','"+LBL_NEWTENORCODE.Text+"', "+
				" "+tool.ConvertFloat(txt_fix.Text)+", '"+ddl_rate.SelectedValue+"', '"+ddl_varcode.SelectedValue+"', "+tool.ConvertFloat(txt_variance.Text)+", "+
				" '"+ddl_decovrreason.SelectedValue+"', '"+txt_decovrreason.Text+"', '"+txt_decremark.Text+"', "+tool.ConvertFloat(LBL_INSTALLMENT.Text)+", "+
				" '1', '"+LBL_DECSTA.Text+"', "+tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", '"+var_fromsta+"', "+
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

		private void viewData2()
		{
			conn.QueryString	= "exec approval_info_view2 '"+REGNO+"', '"+PRODUCT+"', '"+APPTYPE+"', '"+USERID+"', '" + PROD_SEQ + "'";
			conn.ExecuteQuery();
			DataTable dt_aprvinfo = new DataTable();
			dt_aprvinfo = conn.GetDataTable().Copy();

			if (dt_aprvinfo.Rows.Count != 0)
			{
				Response.Write("<!-- dt_aprvinfo.Rows.Count != 0 -->");

				LBL_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
				TXT_NEWTENOR.Text				= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
				LBL_NEWTENORCODE.Text			= dt_aprvinfo.Rows[0]["cp_tenorcodedesc"].ToString();				
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
			}
		}
	}
}
