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
	/// Summary description for ApprovalPermohonan.
	/// </summary>
	public partial class ApprovalPermohonan : System.Web.UI.Page
	{
		#region " My Variables "
		private Connection conn;
		private Tools tool = new Tools();
		private string REGNO, CUREF, PRODUCT, APPTYPE, TC, USERID, MC, PROD_SEQ, STA, AD_SEQ, KET_CODE;
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
			STA			= Request.QueryString["sta"];		//--- dipanggil dari approval history --//

			if (!IsPostBack) 			
			{
				initializeDropDowns();
				viewDataGeneral();
				secureData();

				if (STA == "view" ) viewData2();
				else  viewData();

				if (DDL_PRODUCTID.SelectedValue == "CRP1")
				{
					btn_override.Visible = false;
				}
			}

			btn_override.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1)){return false;};");

			LBL_APPTYPE_DESC.Visible = false;
			LBL_PRODUCT_DESC.Visible =false;
			//initializeEvents();
		}

		private void initializeDropDowns() 
		{	

			if (STA == "view")GlobalTools.fillRefList(DDL_CP_TENORCODE, "select * from rftenorcode ", conn);
			else GlobalTools.fillRefList(DDL_CP_TENORCODE, "select * from rftenorcode where active='1'", conn);

			if (STA == "view")GlobalTools.fillRefList(DDL_PRODUCTID, "select productid, productdesc from rfproduct", conn);				
			else GlobalTools.fillRefList(DDL_PRODUCTID, "select productid, productdesc from rfproduct where active='1'", conn);				

			if (STA == "view")GlobalTools.fillRefList(ddl_decovrreason, "select reasonid, reasondesc from RFREASON where reasontype = '2' ", conn);
			else GlobalTools.fillRefList(ddl_decovrreason, "select reasonid, reasondesc from RFREASON where reasontype = '2' and active = '1'", conn);

			if (STA == "view")GlobalTools.fillRefList(DDL_CP_LOANPURPOSE, "select * from rfloanpurpose", conn);
			else GlobalTools.fillRefList(DDL_CP_LOANPURPOSE, "select * from rfloanpurpose where active = '1'", conn);	
		}


		private void viewData2()
		{

			try 
			{
				conn.QueryString	= "exec IT_APPROVAL_INFO2_View2 '"+REGNO+"', '"+PRODUCT+"', '"+APPTYPE+"', '"+USERID+"' , '" + PROD_SEQ + "'";
				conn.ExecuteQuery();

				//DEBUG
				Response.Write("<!-- " + conn.QueryString.ToString() + " -->");
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			DataTable dt_aprvinfo = new DataTable();
			dt_aprvinfo = conn.GetDataTable().Copy();

			//txt_limit.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());				
			TXT_CP_JANGKAWKT.Text		= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
			//txt_tenorcode.Text			= dt_aprvinfo.Rows[0]["cp_tenorcodedesc"].ToString();
			//txt_purpose.Text			= dt_aprvinfo.Rows[0]["cp_loanpurpdesc"].ToString(); 
			//txt_sifat.Text				= dt_aprvinfo.Rows[0]["cp_skreditdesc"].ToString(); 
			//txt_fix.Text				= dt_aprvinfo.Rows[0]["cp_interest"].ToString(); 
			//ddl_rate.SelectedValue		= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim();
			//try
			//{txt_rate.Text			= Convert.ToString(double.Parse(ddl_rate.SelectedItem.Text) * 100);} 
			//catch 
			//{txt_rate.Text			= "";}
			//ddl_varcode.SelectedValue	= dt_aprvinfo.Rows[0]["cp_varcode"].ToString().Trim(); 
			//txt_variance.Text			= dt_aprvinfo.Rows[0]["cp_variance"].ToString(); 
			//txt_totcoll.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["lc_value"].ToString()); 
			//txt_remark.Text				= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString(); 
			//txt_installment.Text		= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_installment"].ToString()); 
			TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 
			//txt_exrplimit.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 
				
			//			if (dt_ad.Rows.Count == 0)
			//			{
			// DEBUG
			Response.Write("<!-- if (dt_ad.Rows.Count == 0) -->");

			//					txt_declimit.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
			//					txt_dectenor.Text				= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
			//					ddl_dectenorcode.SelectedValue	= dt_aprvinfo.Rows[0]["cp_tenorcode"].ToString().Trim();
			//					txt_decfix.Text	 				= dt_aprvinfo.Rows[0]["cp_interest"].ToString();
			//					ddl_decrate.SelectedValue		= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim(); 
			//					try
			//					{txt_decrate.Text			= Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);}
			//					catch
			//					{txt_decrate.Text			= "";}
			//					ddl_decvarcode.SelectedValue	= dt_aprvinfo.Rows[0]["cp_varcode"].ToString().Trim();
			//					txt_decvariance.Text			= dt_aprvinfo.Rows[0]["cp_variance"].ToString();
			//					txt_decremark.Text				= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString();
			//					txt_decinstallment.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_installment"].ToString());
			//					if ((txt_decinstallment.Text == "0") || (txt_decinstallment.Text == "0,00"))
			//						txt_decinstallment.Text = "-";
			//					txt_decexlimitval.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 
			//					txt_decexrplimit.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 
			//					txt_declimitchg.Text			= dt_aprvinfo.Rows[0]["cp_limitchg"].ToString();
			//					txt_decgraceperiode.Text		= dt_aprvinfo.Rows[0]["cp_graceperiod"].ToString(); 
			//					ddl_decpayfreq.SelectedValue	= dt_aprvinfo.Rows[0]["cp_paymentid"].ToString().Trim();

			//LBL_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
			//TXT_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
			TXT_CP_JANGKAWKT.Text			= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
			try {DDL_CP_TENORCODE.SelectedValue  = dt_aprvinfo.Rows[0]["cp_tenorcode"].ToString().Trim();}
			catch{DDL_CP_TENORCODE.SelectedValue  = "";}
			//txt_decfix.Text	 				= dt_aprvinfo.Rows[0]["cp_interest"].ToString();
			//try {ddl_decrate.SelectedValue		= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim();}
			//catch {ddl_decrate.SelectedValue = "";}
			//				try
			//				{txt_decrate.Text			= Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);}
			//				catch
			//				{txt_decrate.Text			= "";}
			//try {ddl_decvarcode.SelectedValue	= dt_aprvinfo.Rows[0]["cp_varcode"].ToString().Trim();}
			//catch {ddl_decvarcode.SelectedValue	= "";}
			//txt_decvariance.Text			= dt_aprvinfo.Rows[0]["cp_variance"].ToString();
			//TXT_CP_KETERANGAN.Text			= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString();
			//LBL_CP_INSTALLMENT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_installment"].ToString());
			//if ((LBL_CP_INSTALLMENT.Text == "0") || (LBL_CP_INSTALLMENT.Text == "0,00"))
			//	LBL_CP_INSTALLMENT.Text = "-";
			TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 
			//TXT_CP_EXRPLIMIT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 
			//					txt_declimitchg.Text			= dt_aprvinfo.Rows[0]["cp_limitchg"].ToString(); //Tidak perlu karena permohonan baru
			//TXT_CP_GRACEPERIOD.Text			= dt_aprvinfo.Rows[0]["cp_graceperiod"].ToString(); 
			//try {DDL_CP_PAYMENTID.SelectedValue	= dt_aprvinfo.Rows[0]["cp_paymentid"].ToString().Trim();}
			//catch {DDL_CP_PAYMENTID.SelectedValue	= "";}
			//			}
		}
			

		private void viewDataGeneral() 
		{
			conn.QueryString="select PRODUCTID, APPTYPEDESC, PRODUCTDESC, CP_LOANPURPOSE, "+
				"CP_LIMIT, "+
				"CP_KETERANGAN, CP_JANGKAWKT, CP_TENORCODE "+
				"from VW_CUSTPRODUCT where ap_regno='"+ REGNO +"' and productid='"+ PRODUCT +"' and apptype='" + APPTYPE + "' and PROD_SEQ = '" + PROD_SEQ + "'";
			conn.ExecuteQuery();

			LBL_APPTYPE_DESC.Text		= conn.GetFieldValue("APPTYPEDESC");
			LBL_PRODUCT_DESC.Text		= conn.GetFieldValue("PRODUCTDESC");
			DDL_PRODUCTID.SelectedValue = conn.GetFieldValue("PRODUCTID");
			TXT_CP_EXLIMITVAL.Text		= tool.MoneyFormat(conn.GetFieldValue("CP_LIMIT"));
			TXT_CP_JANGKAWKT.Text		= conn.GetFieldValue("CP_JANGKAWKT");
			try {DDL_CP_TENORCODE.SelectedValue = conn.GetFieldValue("CP_TENORCODE");}
			catch {DDL_CP_TENORCODE.SelectedValue = "";}

			if (!conn.GetFieldValue("CP_LOANPURPOSE").Equals("")) DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue("CP_LOANPURPOSE");
			try
			{
				DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue("CP_LOANPURPOSE");
			}
			catch{DDL_CP_LOANPURPOSE.SelectedValue="";}

			conn.ClearData();
			conn.QueryString= "select ad_ovrreason, ad_ovrreasontext from APPROVAL_DECISION where ap_regno='"+ REGNO +"'";
			conn.ExecuteQuery();
			ddl_decovrreason.SelectedValue = conn.GetFieldValue("ad_ovrreason");
			txt_decovrreason.Text = conn.GetFieldValue("ad_ovrreasontext");


			conn.QueryString = "exec IT_APPROVAL_CHECKHISTORY2 '" + REGNO + "', '" + PRODUCT + "', '" + APPTYPE + "', '" + USERID + "', '" + PROD_SEQ + "'";
			conn.ExecuteQuery();
			DataTable dt_chk = conn.GetDataTable().Copy();

	

			string var_fromsta = conn.GetFieldValue("CNT_APPROVAL");
			try 
			{
				// DEBUG
				Response.Write("<!-- AD_SEQ: " + AD_SEQ + " -->");

				//
				// berarti dipanggil dari approval decision history 
				//
				if (AD_SEQ != "" && AD_SEQ != null) 
				{
					// DEBUG
					Response.Write("<!-- AD_SEQ is not empty and not null -->");

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
					// DEBUG
					Response.Write("<!-- AD_SEQ is empty or null -->");

					conn.QueryString = "select * from approval_decision where ap_regno = '" + REGNO + "' "+
						" and productid = '" + PRODUCT + 
						"' and apptype = '" + APPTYPE + "' "+
						" and PROD_SEQ = '" + PROD_SEQ + 
						"' and ad_fromsta = '" + var_fromsta + "' ";
					conn.ExecuteQuery();
				}
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}
/*
			conn.QueryString = "exec it_input_approvaldecision  '" + REGNO + "', '" + PRODUCT + "', "+
				" '" + APPTYPE + "', '" + USERID + "', '"+
				//" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+
				TXT_CP_JANGKAWKT.Text+"','"+DDL_CP_TENORCODE.SelectedValue+"', "+
				//" "+tool.ConvertFloat(txt_decfix.Text)+", '"+ddl_decrate.SelectedValue+"', '"+ddl_decvarcode.SelectedValue+"', "+tool.ConvertFloat(txt_decvariance.Text)+", "+
				" '"+ddl_decovrreason.SelectedValue+"', '"+txt_decovrreason.Text+"', "+//txt_decremark.Text+"', "+tool.ConvertFloat(LBL_CP_INSTALLMENT.Text)+", "+
				//" '1', '"+LBL_DECSTA.Text+"', "+
				tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", '"+//tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", '"+
				var_fromsta+"', "+
				//" "+tool.ConvertNum(TXT_CP_GRACEPERIOD.Text)+", '"+DDL_CP_PAYMENTID.SelectedValue+"', '" + 
				PROD_SEQ + "";
			conn.ExecuteQuery();
*/
/*
			DataTable dt_ad = new DataTable();
			dt_ad = conn.GetDataTable().Copy();

			try 
			{
				conn.QueryString	= "exec approval_info '"+REGNO+"', '"+PRODUCT+"', '"+APPTYPE+"', '"+USERID+"', '"+var_fromsta+"' , '" + PROD_SEQ + "', " + GlobalTools.ConvertNull(AD_SEQ);
				conn.ExecuteQuery();

				//DEBUG
				Response.Write("<!-- " + conn.QueryString.ToString() + " -->");
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}
*/
		}

		private void viewData() 
		{
			//string var_fromsta = getAppealInfo();
			///////////////////////////////////////////////////////////////////////////////////
			/// Check between it_approval_decision (history) with trackhistory
			/// 
			conn.QueryString = "exec IT_APPROVAL_CHECKHISTORY2 '" + REGNO + "', '" + PRODUCT + "', '" + APPTYPE + "', '" + USERID + "', '" + PROD_SEQ + "'";
			conn.ExecuteQuery();
			DataTable dt_chk = conn.GetDataTable().Copy();

			string var_fromsta = conn.GetFieldValue("CNT_APPROVAL");
			try 
			{
				// DEBUG
				Response.Write("<!-- AD_SEQ: " + AD_SEQ + " -->");

				//
				// berarti dipanggil dari approval decision history 
				//
				if (AD_SEQ != "" && AD_SEQ != null) 
				{
					// DEBUG
					Response.Write("<!-- AD_SEQ is not empty and not null -->");

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
					// DEBUG
					Response.Write("<!-- AD_SEQ is empty or null -->");

					conn.QueryString = "select * from approval_decision where ap_regno = '" + REGNO + "' "+
						" and productid = '" + PRODUCT + 
						"' and apptype = '" + APPTYPE + "' "+
						" and PROD_SEQ = '" + PROD_SEQ + 
						"' and ad_fromsta = '" + var_fromsta + "' ";
					conn.ExecuteQuery();
				}
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			DataTable dt_ad = new DataTable();
			dt_ad = conn.GetDataTable().Copy();

			try 
			{
				conn.QueryString	= "exec it_approval_info2 '"+REGNO+"', '"+PRODUCT+"', '"+APPTYPE+"', '"+USERID+"', '"+var_fromsta+"' , '" + PROD_SEQ + "', " + GlobalTools.ConvertNull(AD_SEQ);
				conn.ExecuteQuery();

				//DEBUG
				Response.Write("<!-- " + conn.QueryString.ToString() + " -->");
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			DataTable dt_aprvinfo = new DataTable();
			dt_aprvinfo = conn.GetDataTable().Copy();

			if (dt_aprvinfo.Rows.Count != 0)
			{
				//txt_limit.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());				
				//txt_tenor.Text				= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
				TXT_CP_JANGKAWKT.Text		= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
				//txt_tenorcode.Text			= dt_aprvinfo.Rows[0]["cp_tenorcodedesc"].ToString();
				//txt_purpose.Text			= dt_aprvinfo.Rows[0]["cp_loanpurpdesc"].ToString(); 
				//txt_sifat.Text				= dt_aprvinfo.Rows[0]["cp_skreditdesc"].ToString(); 
				//txt_fix.Text				= dt_aprvinfo.Rows[0]["cp_interest"].ToString(); 
				//ddl_rate.SelectedValue		= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim();
				//try
				//{txt_rate.Text			= Convert.ToString(double.Parse(ddl_rate.SelectedItem.Text) * 100);} 
				//catch 
				//{txt_rate.Text			= "";}
				//ddl_varcode.SelectedValue	= dt_aprvinfo.Rows[0]["cp_varcode"].ToString().Trim(); 
				//txt_variance.Text			= dt_aprvinfo.Rows[0]["cp_variance"].ToString(); 
				//txt_totcoll.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["lc_value"].ToString()); 
				//txt_remark.Text				= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString(); 
				//txt_installment.Text		= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_installment"].ToString()); 
				TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 
				//txt_exrplimit.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 
				
				if (dt_ad.Rows.Count == 0)
				{
					// DEBUG
					Response.Write("<!-- if (dt_ad.Rows.Count == 0) -->");

					//LBL_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
					//TXT_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
					TXT_CP_JANGKAWKT.Text			= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
					try {DDL_CP_TENORCODE.SelectedValue  = dt_aprvinfo.Rows[0]["cp_tenorcode"].ToString().Trim();}
					catch{DDL_CP_TENORCODE.SelectedValue  = "";}
					//txt_decfix.Text	 				= dt_aprvinfo.Rows[0]["cp_interest"].ToString();
					//try {ddl_decrate.SelectedValue		= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim();}
					//catch {ddl_decrate.SelectedValue = "";}
					//try
					//{txt_decrate.Text			= Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);}
					//catch
					//{txt_decrate.Text			= "";}
					//try {ddl_decvarcode.SelectedValue	= dt_aprvinfo.Rows[0]["cp_varcode"].ToString().Trim();}
					//catch {ddl_decvarcode.SelectedValue	= "";}
					//txt_decvariance.Text			= dt_aprvinfo.Rows[0]["cp_variance"].ToString();
					//TXT_CP_KETERANGAN.Text			= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString();
					//LBL_CP_INSTALLMENT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_installment"].ToString());
					//if ((LBL_CP_INSTALLMENT.Text == "0") || (LBL_CP_INSTALLMENT.Text == "0,00"))
					//	LBL_CP_INSTALLMENT.Text = "-";
					TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 
					//TXT_CP_EXRPLIMIT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 
					//txt_declimitchg.Text			= dt_aprvinfo.Rows[0]["cp_limitchg"].ToString(); //Tidak perlu karena permohonan baru
					//TXT_CP_GRACEPERIOD.Text			= dt_aprvinfo.Rows[0]["cp_graceperiod"].ToString(); 
					//try {DDL_CP_PAYMENTID.SelectedValue	= dt_aprvinfo.Rows[0]["cp_paymentid"].ToString().Trim();}
					//catch {DDL_CP_PAYMENTID.SelectedValue	= "";}

					//input approval decision
					if (PRODUCT != "")
					{
						//if (LBL_CP_INSTALLMENT.Text == "-")
						//	LBL_CP_INSTALLMENT.Text = "0";

						conn.QueryString = "exec it_input_approvaldecision3  '" + REGNO + "', '" + PRODUCT + "', "+
							" '" + APPTYPE + "', '" + USERID + "', '"+
							//" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+
							TXT_CP_JANGKAWKT.Text+"','"+DDL_CP_TENORCODE.SelectedValue+"', "+
							//" "+tool.ConvertFloat(txt_decfix.Text)+", '"+ddl_decrate.SelectedValue+"', '"+ddl_decvarcode.SelectedValue+"', "+tool.ConvertFloat(txt_decvariance.Text)+", "+
							" '"+ddl_decovrreason.SelectedValue+"', '"+txt_decovrreason.Text+"', "+//txt_decremark.Text+"', "+tool.ConvertFloat(LBL_CP_INSTALLMENT.Text)+", "+
							" '1', '"+LBL_DECSTA.Text+"', "+
							tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", '"+//tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", '"+
							var_fromsta+"', "+
							//" "+tool.ConvertNum(TXT_CP_GRACEPERIOD.Text)+", '"+DDL_CP_PAYMENTID.SelectedValue+"', '" + 
							PROD_SEQ + "";
						conn.ExecuteQuery();

/*
						conn.QueryString = "exec input_approvaldecision  '"+REGNO+"', '"+PRODUCT+"', "+
							" '"+APPTYPE+"', '"+USERID+"', "+
							" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+TXT_CP_JANGKAWKT.Text+"','"+DDL_CP_TENORCODE.SelectedValue+"', "+
							" "+tool.ConvertFloat(txt_decfix.Text)+", '"+ddl_decrate.SelectedValue+"', '"+ddl_decvarcode.SelectedValue+"', "+ GlobalTools.ConvertFloat(txt_decvariance.Text)+", "+
							" '', '', '"+txt_decremark.Text+"', "+tool.ConvertFloat(LBL_CP_INSTALLMENT.Text)+", '0', '"+LBL_DECSTA.Text+"', "+
							" "+tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", '"+var_fromsta+"', "+
							" "+tool.ConvertNum(TXT_CP_GRACEPERIOD.Text)+", '"+ DDL_CP_PAYMENTID.SelectedValue+"', '" + PROD_SEQ + "'";
						conn.ExecuteQuery();
*/
					}
				}
				else if (dt_aprvinfo.Rows[0]["userid"].ToString() == "")
				{
					// DEBUG
					Response.Write("<!-- else if (dt_aprvinfo.Rows[0]['userid'].ToString() == '') -->");

					conn.QueryString = "select * from approval_decision where ap_regno = '"+REGNO+"' "+
						" and productid = '"+PRODUCT+"' and apptype = '"+APPTYPE+"' and PROD_SEQ = '" + PROD_SEQ + "' " +
						" and ad_seq = (select max(ad_seq) from approval_decision ad where approval_decision.ap_regno = ad.ap_regno "+
						" and approval_decision.productid = ad.productid and approval_decision.apptype = ad.apptype and approval_decision.PROD_SEQ = ad.PROD_SEQ) ";
					conn.ExecuteQuery();
				
					//LBL_CP_LIMIT.Text				= tool.MoneyFormat(conn.GetFieldValue("ad_limit"));
					//TXT_CP_LIMIT.Text				= tool.MoneyFormat(conn.GetFieldValue("ad_limit"));
					TXT_CP_JANGKAWKT.Text			= conn.GetFieldValue("ad_tenor");
					try {DDL_CP_TENORCODE.SelectedValue	= conn.GetFieldValue("ad_tenorcode").Trim();}
					catch {DDL_CP_TENORCODE.SelectedValue	= "";}
					/**************************/

					//txt_decfix.Text					= conn.GetFieldValue("ad_interest");
					//try {ddl_decrate.SelectedValue		= conn.GetFieldValue("ad_rateno");}
					//catch {ddl_decrate.SelectedValue = "";}
					//try
					//{txt_decrate.Text			= Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);}
					//catch
					//{txt_decrate.Text			= "";}
					//try {ddl_decvarcode.SelectedValue	= conn.GetFieldValue("ad_varcode").Trim();}
					//catch {ddl_decvarcode.SelectedValue	= "";}
					//txt_decvariance.Text			= conn.GetFieldValue("ad_variance");
					//						txt_decinstallment.Text = "-";
					//LBL_CP_INSTALLMENT.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_installment"));
					//if ((LBL_CP_INSTALLMENT.Text == "0") || (LBL_CP_INSTALLMENT.Text == "0,00"))
					//	LBL_CP_INSTALLMENT.Text = "-";
					/**************************/

					LBL_DECSTA.Text					= conn.GetFieldValue("ad_reject");
					//if (LBL_DECSTA.Text == "0")
					//	txt_decsta.Text				= "APPROVE BY PREVIOUS USER";
					//else if (LBL_DECSTA.Text == "1")
					//	txt_decsta.Text				= "REJECT BY PREVIOUS USER";

					/**************************/
					TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_exlimitval")); 
					//TXT_CP_EXRPLIMIT.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_exrplimit")); 

					//TXT_CP_GRACEPERIOD.Text			= conn.GetFieldValue("ad_graceperiod"); 
					//try {DDL_CP_PAYMENTID.SelectedValue	= conn.GetFieldValue("ad_paymentid"); }
					//catch {DDL_CP_PAYMENTID.SelectedValue	= "";}

					if (PRODUCT != "")
					{

						//if (LBL_CP_INSTALLMENT.Text == "-")
						//	LBL_CP_INSTALLMENT.Text = "0";

						conn.QueryString = "exec it_input_approvaldecision3  '" + REGNO + "', '" + PRODUCT + "', "+
							" '" + APPTYPE + "', '" + USERID + "', '"+
							//" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+
							TXT_CP_JANGKAWKT.Text+"','"+DDL_CP_TENORCODE.SelectedValue+"', "+
							//" "+tool.ConvertFloat(txt_decfix.Text)+", '"+ddl_decrate.SelectedValue+"', '"+ddl_decvarcode.SelectedValue+"', "+tool.ConvertFloat(txt_decvariance.Text)+", "+
							" '"+ddl_decovrreason.SelectedValue+"', '"+txt_decovrreason.Text+"', '"+//txt_decremark.Text+"', "+tool.ConvertFloat(LBL_CP_INSTALLMENT.Text)+", "+
							" '1', '"+
							LBL_DECSTA.Text+"', "+
							tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", '"+//tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", '"+
							var_fromsta+"', "+
							//" "+tool.ConvertNum(TXT_CP_GRACEPERIOD.Text)+", '"+DDL_CP_PAYMENTID.SelectedValue+"', '" + 
							PROD_SEQ + "";
						conn.ExecuteQuery();

/*
						conn.QueryString = "exec input_approvaldecision  '"+REGNO+"', '"+PRODUCT+"', "+
							" '"+APPTYPE+"', '"+USERID+"', "+
							" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+TXT_CP_JANGKAWKT.Text+"','"+DDL_CP_TENORCODE.SelectedValue+"', "+
							" "+tool.ConvertFloat(txt_decfix.Text)+", '"+ddl_decrate.SelectedValue+"', '"+ddl_decvarcode.SelectedValue+"', "+tool.ConvertFloat(txt_decvariance.Text)+", "+
							" '', '', '"+txt_decremark.Text+"', "+
							" "+tool.ConvertFloat(LBL_CP_INSTALLMENT.Text)+", '0', '"+LBL_DECSTA.Text+"', "+
							" "+tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", '"+var_fromsta+"', "+
							" "+tool.ConvertNum(TXT_CP_GRACEPERIOD.Text)+", '"+ DDL_CP_PAYMENTID.SelectedValue+"', '" + PROD_SEQ + "'";
						conn.ExecuteQuery();
*/
					}
				}
				else if (conn.GetFieldValue("userid") != "")
				{
					// DEBUG
					Response.Write("<!-- else if (conn.GetFieldValue('userid') != '') -->");
					
					///////////////////////////////////////////////////////////////////////////////////
					/// Check between it_approval_decision (history) with trackhistory
					/// 
					if (dt_chk.Rows[0]["SAME_STATUS"].ToString() == "YES") 
					{
						///////////////////////////////////////////////////////////////////////////////
						/// it_approval_decision (history) and trackhistory has the same history,
						/// get the credit description from it_approval_decision

						//LBL_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_limit"].ToString());
						//TXT_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_limit"].ToString());
						TXT_CP_JANGKAWKT.Text			= dt_aprvinfo.Rows[0]["ad_tenor"].ToString();
						try {DDL_CP_TENORCODE.SelectedValue	= dt_aprvinfo.Rows[0]["ad_tenorcode"].ToString().Trim();}
						catch {DDL_CP_TENORCODE.SelectedValue	= "";}
						/**********************/

						//txt_decfix.Text					= dt_aprvinfo.Rows[0]["ad_interest"].ToString();
						//try {ddl_decrate.SelectedValue		= dt_aprvinfo.Rows[0]["ad_rateno"].ToString();}
						//catch {ddl_decrate.SelectedValue	= "";}
						//try
						//{txt_decrate.Text			= Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);}
						//catch
						//{txt_decrate.Text			= "";}
						//try {ddl_decvarcode.SelectedValue	= dt_aprvinfo.Rows[0]["ad_varcode"].ToString().Trim();}
						//catch {ddl_decvarcode.SelectedValue = "";}
						//txt_decvariance.Text			= dt_aprvinfo.Rows[0]["ad_variance"].ToString();

						//txt_decovrsta.Text				= dt_aprvinfo.Rows[0]["ad_ovrsta"].ToString();
						try {ddl_decovrreason.SelectedValue	= dt_aprvinfo.Rows[0]["ad_ovrreason"].ToString().Trim();}
						catch {ddl_decovrreason.SelectedValue	= "";}
						txt_decovrreason.Text			= dt_aprvinfo.Rows[0]["ad_ovrreasontext"].ToString();

						//TXT_CP_KETERANGAN.Text			= dt_aprvinfo.Rows[0]["ad_keterangan"].ToString();
						//LBL_CP_INSTALLMENT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_installment"].ToString());
						//if ((LBL_CP_INSTALLMENT.Text == "0") || (LBL_CP_INSTALLMENT.Text == "0,00"))
						//	LBL_CP_INSTALLMENT.Text = "-";
						//txt_decsta.Text					= dt_aprvinfo.Rows[0]["ad_rejectdesc"].ToString();
						LBL_DECSTA.Text					= dt_aprvinfo.Rows[0]["ad_reject"].ToString();
						TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_exlimitval"].ToString()); 
						//TXT_CP_EXRPLIMIT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_exrplimit"].ToString()); 
						//					txt_declimitchg.Text			= dt_aprvinfo.Rows[0]["cp_limitchg"].ToString(); //Tidak perlu karena permohonan baru
						//TXT_CP_GRACEPERIOD.Text			= dt_aprvinfo.Rows[0]["ad_graceperiod"].ToString(); 
						//try {DDL_CP_PAYMENTID.SelectedValue	= dt_aprvinfo.Rows[0]["ad_paymentid"].ToString().Trim(); }
						//catch {DDL_CP_PAYMENTID.SelectedValue	= "";}
					}
					else 
					{
						//////////////////////////////////////////////////////////////////////////////////////
						///  it_approval_decision (history) and trackhistory has the different history,
						///  get the credit description from custproduct
						///  
						//LBL_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
						//TXT_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
						TXT_CP_JANGKAWKT.Text			= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
						try {DDL_CP_TENORCODE.SelectedValue	= dt_aprvinfo.Rows[0]["cp_tenorcode"].ToString().Trim();}
						catch {DDL_CP_TENORCODE.SelectedValue	= "";}

						//txt_decfix.Text					= dt_aprvinfo.Rows[0]["cp_interest"].ToString();
						//try {ddl_decrate.SelectedValue		= dt_aprvinfo.Rows[0]["rateno"].ToString();}
						//catch {ddl_decrate.SelectedValue	= "";}
						//try
						//{txt_decrate.Text			= Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);}
						//catch
						//{txt_decrate.Text			= "";}
						//try {ddl_decvarcode.SelectedValue	= dt_aprvinfo.Rows[0]["cp_varcode"].ToString().Trim();}
						//catch {ddl_decvarcode.SelectedValue = "";}
						//txt_decvariance.Text			= dt_aprvinfo.Rows[0]["cp_variance"].ToString();

						//TXT_CP_KETERANGAN.Text			= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString();
						//LBL_CP_INSTALLMENT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_installment"].ToString());
						//if ((LBL_CP_INSTALLMENT.Text == "0") || (LBL_CP_INSTALLMENT.Text == "0,00"))
						//	LBL_CP_INSTALLMENT.Text = "-";

						TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 
						//TXT_CP_EXRPLIMIT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 
						//TXT_CP_GRACEPERIOD.Text			= dt_aprvinfo.Rows[0]["cp_graceperiod"].ToString(); 
						//try {DDL_CP_PAYMENTID.SelectedValue	= dt_aprvinfo.Rows[0]["cp_paymentid"].ToString().Trim(); }
						//catch {DDL_CP_PAYMENTID.SelectedValue	= "";}

						///////////////////////////////////////////////////////////////////////////////////////
						/// Insert a new record into it_approval_decision with an increment on ad_fromsta field
						/// 
						string ad_fromsta_new = "";
						int _ad_fromsta = 0;
						try { _ad_fromsta = Convert.ToInt16(var_fromsta) + 1; } 
						catch {}
						ad_fromsta_new = _ad_fromsta.ToString();

						conn.QueryString = "exec it_input_approvaldecision3  '" + REGNO + "', '" + PRODUCT + "', "+
							" '" + APPTYPE + "', '" + USERID + "', '"+
							//" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+
							TXT_CP_JANGKAWKT.Text+"','"+DDL_CP_TENORCODE.SelectedValue+"', "+
							//" "+tool.ConvertFloat(txt_decfix.Text)+", '"+ddl_decrate.SelectedValue+"', '"+ddl_decvarcode.SelectedValue+"', "+tool.ConvertFloat(txt_decvariance.Text)+", "+
							" '"+ddl_decovrreason.SelectedValue+"', '"+txt_decovrreason.Text+"', "+//txt_decremark.Text+"', "+tool.ConvertFloat(LBL_CP_INSTALLMENT.Text)+", "+
							" '1', '"+LBL_DECSTA.Text+"', "+
							tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", '"+//tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", '"+
							var_fromsta+"', "+
							//" "+tool.ConvertNum(TXT_CP_GRACEPERIOD.Text)+", '"+DDL_CP_PAYMENTID.SelectedValue+"', '" + 
							PROD_SEQ + "";
						conn.ExecuteQuery();
/*
						conn.QueryString = "exec input_approvaldecision  '"+REGNO+"', '"+PRODUCT+"', "+
							" '"+APPTYPE+"', '"+USERID+"', "+
							" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+TXT_CP_JANGKAWKT.Text+"','"+DDL_CP_TENORCODE.SelectedValue+"', "+
							" "+tool.ConvertFloat(txt_decfix.Text)+", '"+ddl_decrate.SelectedValue+"', '"+ddl_decvarcode.SelectedValue+"', "+tool.ConvertFloat(txt_decvariance.Text)+", "+
							" '', '', '"+txt_decremark.Text+"', "+
							" "+tool.ConvertFloat(LBL_CP_INSTALLMENT.Text)+", '0', '"+LBL_DECSTA.Text+"', "+
							" "+tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", '" + ad_fromsta_new +"', "+
							" "+tool.ConvertNum(TXT_CP_GRACEPERIOD.Text)+", '"+ DDL_CP_PAYMENTID.SelectedValue+"', '" + PROD_SEQ + "'";
						conn.ExecuteNonQuery();
*/
					}
				}

				//LBL_IDC_RATIO.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["idc_ratio"].ToString());	
				//LBL_IDC_JWAKTU.Text				= dt_aprvinfo.Rows[0]["idc_jwaktu"].ToString();
				//LBL_IDC_CAPRATIO.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["idc_capratio"].ToString());				
				//LBL_IDC_CAPAMNT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["idc_capamnt"].ToString());
				//try {DDL_IDC_INTERESTTYPE.SelectedValue	= dt_aprvinfo.Rows[0]["idc_interesttype"].ToString().Trim();}
				//catch {DDL_IDC_INTERESTTYPE.SelectedValue	= "";}
				//if (DDL_IDC_INTERESTTYPE.SelectedValue == "01")
				//{
				//	try {ddl_idcprimevar.SelectedValue	= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim();	}
				//	catch {ddl_idcprimevar.SelectedValue= "";}
				//	try {LBL_IDC_PRIMEVARCODE.Text	= Convert.ToString(double.Parse(ddl_idcprimevar.SelectedItem.Text) * 100);}
				//	catch {LBL_IDC_PRIMEVARCODE.Text = "";}
				//	try {DDL_IDC_VARCODE.SelectedValue	= dt_aprvinfo.Rows[0]["idc_varcode"].ToString().Trim();}
				//	catch {DDL_IDC_VARCODE.SelectedValue= "";}
				//	LBL_IDC_VARIANCE.Text			= dt_aprvinfo.Rows[0]["idc_variance"].ToString();					
				//}
				//else if (DDL_IDC_INTERESTTYPE.SelectedValue == "02")
				//{
				//	LBL_IDC_VARIANCE.Text			= dt_aprvinfo.Rows[0]["idc_interest"].ToString();
				//}

				conn.ClearData();
			}

			//conn.QueryString = "select interesttype from rfproduct where productid = '"+PRODUCT+"'";
			//conn.ExecuteQuery();
			//string var_inttype = conn.GetFieldValue("interesttype");
			//if (var_inttype == "01")
			//{
			//	tr_decfix.Visible = false;
			//}
			//else if (var_inttype == "02")
			//{
			//	tr_decfloat.Visible = false;
			//}
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

		protected void BTN_OVERRIDE_Click(object sender, System.EventArgs e)
		{
			string var_fromsta = "";

			/*
			if (((int.Parse(TXT_CP_JANGKAWKT.Text) < 30) && (DDL_CP_TENORCODE.SelectedValue == "D")) || ((int.Parse(TXT_CP_JANGKAWKT.Text) < 1) && (DDL_CP_TENORCODE.SelectedValue == "M")))
			{
				GlobalTools.popMessage(this, "Tenor Cannot below 30 days or 1 month");
				return;
			}
			*/

			conn.QueryString = "exec IT_APPROVAL_CHECKHISTORY2 '" + REGNO + "', '" + PRODUCT + "', '" + APPTYPE + "', '" + USERID + "', '" + PROD_SEQ + "'";
			conn.ExecuteQuery();

			var_fromsta = conn.GetFieldValue("CNT_APPROVAL");

			conn.QueryString = "exec it_input_approvaldecision3  '" + REGNO + "', '" + PRODUCT + "', "+
				" '" + APPTYPE + "', '" + USERID + "', '"+
				//" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+
				TXT_CP_JANGKAWKT.Text+"','"+DDL_CP_TENORCODE.SelectedValue+"', "+
				//" "+tool.ConvertFloat(txt_decfix.Text)+", '"+ddl_decrate.SelectedValue+"', '"+ddl_decvarcode.SelectedValue+"', "+tool.ConvertFloat(txt_decvariance.Text)+", "+
				" '"+ddl_decovrreason.SelectedValue+"', '"+txt_decovrreason.Text+"',"+  
				//txt_decremark.Text+"', "+tool.ConvertFloat(LBL_CP_INSTALLMENT.Text)+", "+
				"'1', '"+
				LBL_DECSTA.Text+"', "+
				tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", '"+//tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", '"+
				var_fromsta+"', "+
				//" "+tool.ConvertNum(TXT_CP_GRACEPERIOD.Text)+", '"+DDL_CP_PAYMENTID.SelectedValue+"', '" + 
				PROD_SEQ + "";
			conn.ExecuteQuery();
		}


/*
		private void BTN_EARMARK_Click(object sender, System.EventArgs e)
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

				if (ex1.getMessage() == "PROJECT") 
				{
					GlobalTools.popMessage(this, "Earmarking by project failed. Remaining limit become negative!");
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
			//viewDataEarmark();
		}
/*
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
			/// Update Earmark Amount on it_approval_decision
			/// 
			conn.QueryString = "update it_approval_decision " + 
				" set ad_earmark_amount = '" + conn.GetFieldValue("EARMARK_AMOUNT_PRJ") + "' " + 
				" where ap_Regno = '" + REGNO + "' " + 
				" and apptype = '" + APPTYPE + "' " + 
				" and productid = '" + PRODUCT + "' " + 
				" and prod_seq = '" + PROD_SEQ + "'";
			conn.ExecuteNonQuery();
*/		}

/*
		private void BTN_NEGATIVE_YES_Click(object sender, System.EventArgs e)
		{
			TXT_NEGATIVE.Text = "YES";
			BTN_EARMARK_Click(sender, e);
			TXT_NEGATIVE.Text = "NO";
			tr_confirm_negative.Visible = false;
		}


		private void btn_Save_Click(object sender, System.EventArgs e)
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

		private void BTN_NEGATIVE_NO_Click(object sender, System.EventArgs e)
		{
			tr_confirm_negative.Visible = false;
		}

		private void viewData2()
		{

			try 
			{
				conn.QueryString	= "exec APPROVAL_INFO_View2 '"+REGNO+"', '"+PRODUCT+"', '"+APPTYPE+"', '"+USERID+"' , '" + PROD_SEQ + "'";
				conn.ExecuteQuery();
	
				//DEBUG
				Response.Write("<!-- " + conn.QueryString.ToString() + " -->");
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}
		
			DataTable dt_aprvinfo = new DataTable();
			dt_aprvinfo = conn.GetDataTable().Copy();

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
				
			//			if (dt_ad.Rows.Count == 0)
			//			{
			// DEBUG
			Response.Write("<!-- if (dt_ad.Rows.Count == 0) -->");

			//					txt_declimit.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
			//					txt_dectenor.Text				= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
			//					ddl_dectenorcode.SelectedValue	= dt_aprvinfo.Rows[0]["cp_tenorcode"].ToString().Trim();
			//					txt_decfix.Text	 				= dt_aprvinfo.Rows[0]["cp_interest"].ToString();
			//					ddl_decrate.SelectedValue		= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim(); 
			//					try
			//					{txt_decrate.Text			= Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);}
			//					catch
			//					{txt_decrate.Text			= "";}
			//					ddl_decvarcode.SelectedValue	= dt_aprvinfo.Rows[0]["cp_varcode"].ToString().Trim();
			//					txt_decvariance.Text			= dt_aprvinfo.Rows[0]["cp_variance"].ToString();
			//					txt_decremark.Text				= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString();
			//					txt_decinstallment.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_installment"].ToString());
			//					if ((txt_decinstallment.Text == "0") || (txt_decinstallment.Text == "0,00"))
			//						txt_decinstallment.Text = "-";
			//					txt_decexlimitval.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 
			//					txt_decexrplimit.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 
			//					txt_declimitchg.Text			= dt_aprvinfo.Rows[0]["cp_limitchg"].ToString();
			//					txt_decgraceperiode.Text		= dt_aprvinfo.Rows[0]["cp_graceperiod"].ToString(); 
			//					ddl_decpayfreq.SelectedValue	= dt_aprvinfo.Rows[0]["cp_paymentid"].ToString().Trim();

			LBL_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
			TXT_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
			TXT_CP_JANGKAWKT.Text			= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
			try {DDL_CP_TENORCODE.SelectedValue  = dt_aprvinfo.Rows[0]["cp_tenorcode"].ToString().Trim();}
			catch{DDL_CP_TENORCODE.SelectedValue  = "";}
			txt_decfix.Text	 				= dt_aprvinfo.Rows[0]["cp_interest"].ToString();
			try {ddl_decrate.SelectedValue		= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim();}
			catch {ddl_decrate.SelectedValue = "";}
			//				try
			//				{txt_decrate.Text			= Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);}
			//				catch
			//				{txt_decrate.Text			= "";}
			try {ddl_decvarcode.SelectedValue	= dt_aprvinfo.Rows[0]["cp_varcode"].ToString().Trim();}
			catch {ddl_decvarcode.SelectedValue	= "";}
			txt_decvariance.Text			= dt_aprvinfo.Rows[0]["cp_variance"].ToString();
			TXT_CP_KETERANGAN.Text			= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString();
			LBL_CP_INSTALLMENT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_installment"].ToString());
			if ((LBL_CP_INSTALLMENT.Text == "0") || (LBL_CP_INSTALLMENT.Text == "0,00"))
				LBL_CP_INSTALLMENT.Text = "-";
			TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 
			TXT_CP_EXRPLIMIT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 
			//					txt_declimitchg.Text			= dt_aprvinfo.Rows[0]["cp_limitchg"].ToString(); //Tidak perlu karena permohonan baru
			TXT_CP_GRACEPERIOD.Text			= dt_aprvinfo.Rows[0]["cp_graceperiod"].ToString(); 
			try {DDL_CP_PAYMENTID.SelectedValue	= dt_aprvinfo.Rows[0]["cp_paymentid"].ToString().Trim();}
			catch {DDL_CP_PAYMENTID.SelectedValue	= "";}
			//			}
		}

		//20070725 add by sofyan for alih debitur
	/*	private void CHK_ALIHDEB_CheckedChanged(object sender, System.EventArgs e)
		{
			if (CHK_ALIHDEB.Checked == true)
			{
				TR_OLDCIFNO.Visible = true;
				TR_OLDACCNO.Visible = true;
			}
			else
			{
				TR_OLDCIFNO.Visible = false;
				TR_OLDACCNO.Visible = false;
			}
		}*/
	}
