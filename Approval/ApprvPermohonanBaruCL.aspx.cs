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
using Microsoft.VisualBasic;

namespace SME.Approval
{
	/// <summary>
	/// Summary description for ApprvPermohonanBaruCL.
	/// </summary>
	public partial class ApprvPermohonanBaruCL : System.Web.UI.Page
	{
	
		#region " My Variables "
			private Connection conn;
			private Tools tool = new Tools();
			private string REGNO, CUREF, PRODUCT, APPTYPE, TC, USERID, MC, PROD_SEQ, STA, AD_SEQ, KET_CODE;
		#endregion

		//20070725 add by sofyan for alih debitur

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
			AD_SEQ		= Request.QueryString["ad_seq"];
			KET_CODE	= Request.QueryString["ket_code"];

			if (!IsPostBack) 			
			{
				initializeDropDowns();

				CalculateInstallment();		
				viewDataGeneral();

				//20070725 add by sofyan for alih debitur
				viewdataalihdeb();

				if (STA == "view" ) viewData2();
				else  viewData();
				
				CheckIDC();
				viewIDC();
				secureData();

				kreditAwal.Visible = false;
				tr_confirm_negative.Visible = false;
			}

            btn_override.Attributes.Add("onclick", "if(!cek_mandatory(document.getElementById('Form1'))){return false;};");
			BTN_EBIZCARD.Attributes.Add("onclick", "javascript:PopupPage('../DataEntry/eBizCardPola.aspx?regno=" + REGNO + "&apptype=" + APPTYPE + "&productid=" + PRODUCT + "&prod_seq=" + PROD_SEQ + "','1000','320');");
            btn_override.Click += new EventHandler(btn_override_Click);

			initializeEvents();
            //PUNDI
            setDefault();
            RetrievePundiRateOnPostBack();
		}

        private void setDefault()
        {
            TXT_CP_EXRPLIMIT.Text = "1";
            TXT_CP_EXRPLIMIT.Enabled = true;
            TXT_CP_LIMIT.Enabled = true;
        }

		private void initializeEvents() 
		{
			lb_struc.Click +=new EventHandler(lb_struc_Click);
			//btn_override.Click += new EventHandler(btn_override_Click);
			this.BTN_EARMARK.Click += new System.EventHandler(this.BTN_EARMARK_Click);
			this.BTN_NEGATIVE_YES.Click += new System.EventHandler(this.BTN_NEGATIVE_YES_Click);
			this.BTN_NEGATIVE_NO.Click += new System.EventHandler(this.BTN_NEGATIVE_NO_Click);			
			this.btn_Save.Click += new EventHandler(btn_Save_Click);
			//20070725 add by sofyan for alih debitur
			this.CHK_ALIHDEB.CheckedChanged += new System.EventHandler(this.CHK_ALIHDEB_CheckedChanged);
		}
		
		private void CalculateInstallment()
		{
			double result = 0;
			double Rate= 0.0;

			try 
			{
				conn.QueryString = "select calcmethod, isinstallment from rfproduct where productid='" + PRODUCT + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			try
			{
				if (conn.GetFieldValue("isinstallment") == "1")
				{
					LBL_INSTALLMENT.Text = "Installment";
					
					// DAPAT BUNGA DULU SEBELUM PASS DALAM FUNGSI UNTUK HITUNG
					if(ddl_decvarcode.SelectedValue.Trim()=="-")
					{Rate = Convert.ToDouble(LBL_INTEREST.Text) - Convert.ToDouble(txt_decvariance.Text);}

					if(ddl_decvarcode.SelectedValue.Trim()=="+")
					{Rate = Convert.ToDouble(LBL_INTEREST.Text) + Convert.ToDouble(txt_decvariance.Text);}

					if(Rate>0)
					{
						result = DMS.CuBESCore.Logic.hitungInstalment(double.Parse(TXT_CP_EXLIMITVAL.Text), int.Parse(TXT_CP_JANGKAWKT.Text), Rate, PRODUCT, DDL_CP_TENORCODE.SelectedValue, conn);
						LBL_CP_INSTALLMENT.Text = tool.MoneyFormat(result.ToString());
					}
					else
						result=0;

				}
				else if (conn.GetFieldValue("isinstallment") == "0")
				{
					LBL_INSTALLMENT.Text = "Bunga per bulan";
					LBL_CP_INSTALLMENT.Text = "-";
					TXT_CP_JANGKAWKT.AutoPostBack = false;
				}
			}
			catch{}
		}

		private void initializeDropDowns() 
		{
//			GlobalTools.fillRefList(ddl_idcprimevar, "select rateno, rate from RFRATENUMBER where active = '1'", false, conn);
//			GlobalTools.fillRefList(DDL_CP_TENORCODE, "select * from rftenorcode where active='1'", false, conn);
//			GlobalTools.fillRefList(DDL_CP_PAYMENTID, "select paymentid, paymentdesc from rfpaymentfreq where active='1'", false, conn);				
//			GlobalTools.fillRefList(ddl_decrate, "select rateno, rate from RFRATENUMBER where active = '1'", false, conn);
//			GlobalTools.fillRefList(ddl_decovrreason, "select reasonid, reasondesc from RFREASON where reasontype = '2' and active = '1'", false, conn);
//			GlobalTools.fillRefList(ddl_idcprimevar, "select rateno, rate from RFRATENUMBER where active = '1'", false, conn);
//			GlobalTools.fillRefList(DDL_CP_LOANPURPOSE, "select * from rfloanpurpose where active = '1'", false, conn);			
//			GlobalTools.fillRefList(DDL_PROJECT_CODE, "select PRJ_CODE, PRJ_NAME from rfproject where active = '1' and convert(varchar, prj_expiry_date, 112) >= convert(varchar, getdate(), 112) order by PRJ_NAME", false, conn);
//			GlobalTools.fillRefList(DDL_IDC_INTERESTTYPE, "select itypeid, itypedesc from rfinteresttype", false, conn);			
	
			
			if (STA == "view")GlobalTools.fillRefList(ddl_idcprimevar, "select rateno, rate from RFRATENUMBER ", conn);
			else GlobalTools.fillRefList(ddl_idcprimevar, "select rateno, rate from RFRATENUMBER where active = '1'", conn);

			if (STA == "view")GlobalTools.fillRefList(DDL_CP_TENORCODE, "select * from rftenorcode ", conn);
			else GlobalTools.fillRefList(DDL_CP_TENORCODE, "select * from rftenorcode where active='1'", conn);

			if (STA == "view")GlobalTools.fillRefList(DDL_CP_PAYMENTID, "select paymentid, paymentdesc from rfpaymentfreq", conn);				
			else GlobalTools.fillRefList(DDL_CP_PAYMENTID, "select paymentid, paymentdesc from rfpaymentfreq where active='1'", conn);				

			if (STA == "view")GlobalTools.fillRefList(ddl_decrate, "select rateno, rate from RFRATENUMBER ", conn);
			else GlobalTools.fillRefList(ddl_decrate, "select rateno, rate from RFRATENUMBER where active = '1'", conn);

			if (STA == "view")GlobalTools.fillRefList(ddl_decovrreason, "select reasonid, reasondesc from RFREASON where reasontype = '2' ", conn);
			else GlobalTools.fillRefList(ddl_decovrreason, "select reasonid, reasondesc from RFREASON where reasontype = '2' and active = '1'", conn);

			if (STA == "view")GlobalTools.fillRefList(DDL_CP_LOANPURPOSE, "select * from rfloanpurpose", conn);
			else GlobalTools.fillRefList(DDL_CP_LOANPURPOSE, "select * from rfloanpurpose where active = '1'", conn);			
			
			if (STA == "view")GlobalTools.fillRefList(DDL_PROJECT_CODE, "select * from VW_RFPROJECT", conn);
			else GlobalTools.fillRefList(DDL_PROJECT_CODE, "select * from VW_RFPROJECT where active = '1'", false, conn);
			
			GlobalTools.fillRefList(DDL_IDC_INTERESTTYPE, "select itypeid, itypedesc from rfinteresttype", conn);

			ddl_decvarcode.Items.Clear();
			ddl_decvarcode.Items.Add(new ListItem("- SELECT -",""));
			ddl_decvarcode.Items.Add(new ListItem("+", "+"));
			ddl_decvarcode.Items.Add(new ListItem("-", "-"));
		}
		private string getAppealInfo() 
		{
			string var_fromsta = "";

			//Get Credit Info Data
			try 
			{
				conn.QueryString = "select isnull(ap_isappeal,0) ap_isappeal from APPLICATION where AP_REGNO = '" + REGNO + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			var_fromsta = conn.GetFieldValue("ap_isappeal");

			return var_fromsta;
		}

		private void viewDataGeneral() 
		{
			conn.QueryString="select APPTYPEDESC, PRODUCTDESC, CP_LOANPURPOSE, CP_LIMIT, "+
				"CP_installment, CP_EXRPLIMIT, CP_EXLIMITVAL, CP_EXRPCOLL, "+
				"CP_EXCOLLVAL, CP_KETERANGAN, CP_JANGKAWKT, CP_TENORCODE, REVOLVING, "+
				"CP_VARCODE, CP_RATENO, CP_VARIANCE "+
				", CP_DECSTA, AD_VARCODE, AD_VARIANCE, AD_RATENO, CP_REVATACCT, CP_GRACEPERIOD, CP_PAYMENTID, CP_LIMITAWAL, PROJECT_CODE, PRJ_NAME, EARMARK_AMOUNT_PRJ "+
				"from VW_CUSTPRODUCT where ap_regno='"+ REGNO +"' and productid='"+ PRODUCT +"' and apptype='" + APPTYPE + "' and PROD_SEQ = '" + PROD_SEQ + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("CP_REVATACCT") == "1") CHK_CP_REVATACCT.Checked = true;
			else CHK_CP_REVATACCT.Checked = false;
			LBL_APPTYPE_DESC.Text		= conn.GetFieldValue("APPTYPEDESC");
			LBL_PRODUCT_DESC.Text		= conn.GetFieldValue("PRODUCTDESC");
			LBL_CP_LIMIT.Text			= tool.MoneyFormat(conn.GetFieldValue("CP_LIMIT"));
			TXT_CP_LIMIT.Text			= tool.MoneyFormat(conn.GetFieldValue("CP_LIMIT"));
			LBL_CP_INSTALLMENT.Text		= tool.MoneyFormat(conn.GetFieldValue("CP_installment"));
			if (LBL_CP_INSTALLMENT.Text == "0" || LBL_CP_INSTALLMENT.Text == "0,00") LBL_CP_INSTALLMENT.Text = "-";
			TXT_CP_EXRPLIMIT.Text		= tool.MoneyFormat(conn.GetFieldValue("CP_EXRPLIMIT"));
			TXT_CP_EXLIMITVAL.Text		= tool.MoneyFormat(conn.GetFieldValue("CP_EXLIMITVAL"));
			TXT_CP_KETERANGAN.Text		= conn.GetFieldValue("CP_KETERANGAN");
			TXT_CP_JANGKAWKT.Text		= conn.GetFieldValue("CP_JANGKAWKT");
			try {DDL_CP_TENORCODE.SelectedValue = conn.GetFieldValue("CP_TENORCODE");}
			catch {DDL_CP_TENORCODE.SelectedValue = "";}
			LBL_REVOLVING.Text			= conn.GetFieldValue("REVOLVING");
			TXT_CP_GRACEPERIOD.Text		= conn.GetFieldValue("CP_GRACEPERIOD");
			try {DDL_CP_PAYMENTID.SelectedValue = conn.GetFieldValue("CP_PAYMENTID");}
			catch {DDL_CP_PAYMENTID.SelectedValue = "";}
			string CP_DECSTA			= conn.GetFieldValue("CP_DECSTA");
			string AD_VARCODE			= conn.GetFieldValue("AD_VARCODE");
			string AD_VARIANCE			= conn.GetFieldValue("AD_VARIANCE");
			string AD_RATENO			= conn.GetFieldValue("AD_RATENO");
			//if (!conn.GetFieldValue("CP_LOANPURPOSE").Equals("")) DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue("CP_LOANPURPOSE");
			try
			{
				DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue("CP_LOANPURPOSE");
			}
			catch{DDL_CP_LOANPURPOSE.SelectedValue="";}
			/*** Tidak Terpakai ??
			LBL_LC_VALUE.Text		= "0";
			LBL_LC_PERCENTAGE.Text	= "0";
			LBL_ENDVALUE.Text		= "0";
			***/
			TR_IDC.Visible			= false;
			LBL_PRODUCT.Text		= Request.QueryString["teks"];
			LBL_CP_LIMITAWAL.Text   = tool.MoneyFormat(conn.GetFieldValue("CP_LIMITAWAL"));
			try {DDL_PROJECT_CODE.SelectedValue = conn.GetFieldValue("PROJECT_CODE");}
			catch {DDL_PROJECT_CODE.SelectedValue = "";}
			LBL_PRJ_CODE.Text = conn.GetFieldValue("PRJ_NAME");
			LBL_EARMARK_AMOUNT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("EARMARK_AMOUNT_PRJ"));

			conn.ClearData();

			conn.QueryString = "APPROVAL_TOTALEXPOSURE '" + REGNO + "'";
			conn.ExecuteQuery(300);
			LBL_LIMITEXPOSURE.Text	= tool.MoneyFormat(conn.GetFieldValue("exposure"));
			LBL_SUMLIMIT.Text		= tool.MoneyFormat(conn.GetFieldValue("tot_limit"));
			conn.ClearData();				

			//--- Mengisi bunga product (Floating atau Fixed)
			conn.QueryString = "select interesttype from rfproduct where productid='" + PRODUCT + "'";
			conn.ExecuteQuery();
			string interestType = conn.GetFieldValue(0,0);

			try {DDL_IDC_INTERESTTYPE.SelectedValue = interestType;}
			catch {DDL_IDC_INTERESTTYPE.SelectedValue = "";}
			if (interestType == "01" || interestType == "03")
			{
				LBL_IDC_PRIMEVARCODE.Visible = true;
				DDL_IDC_VARCODE.Visible = true;
				LBL_IDC_VARIANCE.Visible = true;

				if (interestType == "03") 
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
					//LBL_RATENO.Text		= conn.GetFieldValue("rateno");					
				}
				else
				{
					LBL_VARCODE.Text	= AD_VARCODE;
					LBL_VARIANCE.Text	= AD_VARIANCE;
					//LBL_RATENO.Text		= AD_RATENO;
				}
			}
			else
			{				
				LBL_IDC_PRIMEVARCODE.Visible = false;
				DDL_IDC_VARCODE.Visible = false;				
				LBL_IDC_VARIANCE.Visible = false;

				LBL_INTERESTTYPE.Text = "Bunga / p.a: Fix";
				conn.QueryString = "select interesttyperate from rfproduct where productid='" + PRODUCT + "'";
				conn.ExecuteQuery();
				LBL_INTEREST.Text = conn.GetFieldValue("interesttyperate");
				LBL_VARIANCE.Visible = false;
			}
		
		}
		private void viewIDC()
		{
			conn.QueryString="select IDC_CAPAMNT, IDC_CAPRATIO, IDC_JWAKTU, "+
				"IDC_PRIMEVARCODE, IDC_RATIO, IDC_VARCODE, IDC_VARIANCE, IDC_FLAG, IDC_INTEREST, IDC_INTERESTTYPE from vw_custproduct_idc "+
				"where ap_regno='"+ REGNO +"' and productid='"+ PRODUCT +"' and apptype='"+APPTYPE+"' and PROD_SEQ = '" + PROD_SEQ + "'";
			conn.ExecuteQuery();
			LBL_IDC_CAPAMNT.Text		= GlobalTools.MoneyFormat(conn.GetFieldValue("IDC_CAPAMNT"));
			LBL_IDC_CAPRATIO.Text		= conn.GetFieldValue("IDC_CAPRATIO");
			LBL_IDC_JWAKTU.Text			= conn.GetFieldValue("IDC_JWAKTU");
			LBL_IDC_PRIMEVARCODE.Text   = LBL_INTEREST.Text;						

			if (!conn.GetFieldValue("IDC_INTEREST").Equals("")) LBL_IDC_PRIMEVARCODE.Text = conn.GetFieldValue("IDC_INTEREST");
			if (!conn.GetFieldValue("IDC_VARCODE").Equals("")) DDL_IDC_VARCODE.SelectedValue	= conn.GetFieldValue("IDC_VARCODE");
			if (DDL_IDC_VARCODE.SelectedValue.Trim() == "") DDL_IDC_VARCODE.SelectedValue	= LBL_VARCODE.Text;
			
			LBL_IDC_VARIANCE.Text		= conn.GetFieldValue("IDC_VARIANCE");
			if (LBL_IDC_VARIANCE.Text.Trim() == "") LBL_IDC_VARIANCE.Text	= LBL_VARIANCE.Text;

			LBL_IDC_RATIO.Text			= conn.GetFieldValue("IDC_RATIO");
			conn.ClearData();
		}
		private void viewData() 
		{
			//string var_fromsta = getAppealInfo();
			///////////////////////////////////////////////////////////////////////////////////
			/// Check between approval_decision (history) with trackhistory
			/// 
			conn.QueryString = "exec APPROVAL_CHECKHISTORY '" + REGNO + "', '" + PRODUCT + "', '" + APPTYPE + "', '" + USERID + "', '" + PROD_SEQ + "'";
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
				
				if (dt_ad.Rows.Count == 0)
				{
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
					try
					{txt_decrate.Text			= Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);}
					catch
					{txt_decrate.Text			= "";}
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

					//input approval decision
					if (PRODUCT != "")
					{
						if (LBL_CP_INSTALLMENT.Text == "-")
							LBL_CP_INSTALLMENT.Text = "0";

						conn.QueryString = "exec input_approvaldecision  '"+REGNO+"', '"+PRODUCT+"', "+
							" '"+APPTYPE+"', '"+USERID+"', "+
							" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+TXT_CP_JANGKAWKT.Text+"','"+DDL_CP_TENORCODE.SelectedValue+"', "+
							" "+tool.ConvertFloat(txt_decfix.Text)+", '"+ddl_decrate.SelectedValue+"', '"+ddl_decvarcode.SelectedValue+"', "+ GlobalTools.ConvertFloat(txt_decvariance.Text)+", "+
							" '', '', '"+txt_decremark.Text+"', "+tool.ConvertFloat(LBL_CP_INSTALLMENT.Text)+", '0', '"+LBL_DECSTA.Text+"', "+
							" "+tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", '"+var_fromsta+"', "+
							" "+tool.ConvertNum(TXT_CP_GRACEPERIOD.Text)+", '"+ DDL_CP_PAYMENTID.SelectedValue+"', '" + PROD_SEQ + "'";
						conn.ExecuteQuery();
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

					/************************/
//					txt_declimit.Text				= tool.MoneyFormat(conn.GetFieldValue("ad_limit"));
//					txt_dectenor.Text				= conn.GetFieldValue("ad_tenor");
//					ddl_dectenorcode.SelectedValue	= conn.GetFieldValue("ad_tenorcode").Trim();					
					LBL_CP_LIMIT.Text				= tool.MoneyFormat(conn.GetFieldValue("ad_limit"));
					TXT_CP_LIMIT.Text				= tool.MoneyFormat(conn.GetFieldValue("ad_limit"));
					TXT_CP_JANGKAWKT.Text			= conn.GetFieldValue("ad_tenor");
					try {DDL_CP_TENORCODE.SelectedValue	= conn.GetFieldValue("ad_tenorcode").Trim();}
					catch {DDL_CP_TENORCODE.SelectedValue	= "";}
					/**************************/

					txt_decfix.Text					= conn.GetFieldValue("ad_interest");
					try {ddl_decrate.SelectedValue		= conn.GetFieldValue("ad_rateno");}
					catch {ddl_decrate.SelectedValue = "";}
					try
					{txt_decrate.Text			= Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);}
					catch
					{txt_decrate.Text			= "";}
					try {ddl_decvarcode.SelectedValue	= conn.GetFieldValue("ad_varcode").Trim();}
					catch {ddl_decvarcode.SelectedValue	= "";}
					txt_decvariance.Text			= conn.GetFieldValue("ad_variance");
					
					/* ////// tidak perlu karena usernya belum pernah visit
					 * 
					if (conn.GetFieldValue("ad_ovrsta") == "0")
						txt_decovrsta.Text			= "No";
					else if (conn.GetFieldValue("ad_ovrsta") == "1")
						txt_decovrsta.Text			= "Yes";
					try {ddl_decovrreason.SelectedValue	= conn.GetFieldValue("ad_ovrreason").Trim();}
					catch {ddl_decovrreason.SelectedValue= "";}
					txt_decovrreason.Text			= conn.GetFieldValue("ad_ovrreasontext");
					txt_decremark.Text				= conn.GetFieldValue("ad_keterangan");
					*/

					/**************************/
//					txt_decinstallment.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_installment"));
//					if ((txt_decinstallment.Text == "0") || (txt_decinstallment.Text == "0,00"))
//						txt_decinstallment.Text = "-";
					LBL_CP_INSTALLMENT.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_installment"));
					if ((LBL_CP_INSTALLMENT.Text == "0") || (LBL_CP_INSTALLMENT.Text == "0,00"))
						LBL_CP_INSTALLMENT.Text = "-";
					/**************************/

					LBL_DECSTA.Text					= conn.GetFieldValue("ad_reject");
					if (LBL_DECSTA.Text == "0")
						txt_decsta.Text				= "APPROVE BY PREVIOUS USER";
					else if (LBL_DECSTA.Text == "1")
						txt_decsta.Text				= "REJECT BY PREVIOUS USER";

					/**************************/
					TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_exlimitval")); 
					TXT_CP_EXRPLIMIT.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_exrplimit")); 
//					txt_declimitchg.Text			= dt_aprvinfo.Rows[0]["cp_limitchg"].ToString();
					TXT_CP_GRACEPERIOD.Text			= conn.GetFieldValue("ad_graceperiod"); 
					try {DDL_CP_PAYMENTID.SelectedValue	= conn.GetFieldValue("ad_paymentid"); }
					catch {DDL_CP_PAYMENTID.SelectedValue	= "";}
//					txt_decexlimitval.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_exlimitval")); 
//					txt_decexrplimit.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_exrplimit")); 
//					txt_declimitchg.Text			= dt_aprvinfo.Rows[0]["cp_limitchg"].ToString();
//					txt_decgraceperiode.Text		= conn.GetFieldValue("ad_graceperiod"); 
//					ddl_decpayfreq.SelectedValue	= conn.GetFieldValue("ad_paymentid"); 
					/**************************/

					//input approval decision
					if (PRODUCT != "")
					{
						/***************************/
//						if (txt_decinstallment.Text == "-")
//							txt_decinstallment.Text = "0";
						if (LBL_CP_INSTALLMENT.Text == "-")
							LBL_CP_INSTALLMENT.Text = "0";
						/***************************/

						/***
						 * Yang ini Phase 2, tapi versi lama ***
						 * 
						conn.QueryString = "exec input__approvaldecision  '"+REGNO+"', '"+PRODUCT+"', "+
							" '"+APPTYPE+"', '"+USERID+"', "+
							" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", "+TXT_CP_JANGKAWKT.Text+",'"+DDL_CP_TENORCODE.SelectedValue+"', "+
							" "+tool.ConvertFloat(txt_decfix.Text)+", '"+ddl_decrate.SelectedValue+"', '"+ddl_decvarcode.SelectedValue+"', "+tool.ConvertFloat(txt_decvariance.Text)+", "+
							" '"+ddl_decovrreason.SelectedValue+"', '"+txt_decovrreason.Text+"', '"+txt_decremark.Text+"', "+
							" "+tool.ConvertFloat(LBL_CP_INSTALLMENT.Text)+", '"+conn.GetFieldValue("ad_ovrsta")+"', '"+LBL_DECSTA.Text+"', "+
							" "+tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", '"+var_fromsta+"', "+
							" "+tool.ConvertNum(TXT_CP_GRACEPERIOD.Text)+", '"+ DDL_CP_PAYMENTID.SelectedValue+"', '" + PROD_SEQ + "'";
						***/

						conn.QueryString = "exec input_approvaldecision  '"+REGNO+"', '"+PRODUCT+"', "+
							" '"+APPTYPE+"', '"+USERID+"', "+
							" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+TXT_CP_JANGKAWKT.Text+"','"+DDL_CP_TENORCODE.SelectedValue+"', "+
							" "+tool.ConvertFloat(txt_decfix.Text)+", '"+ddl_decrate.SelectedValue+"', '"+ddl_decvarcode.SelectedValue+"', "+tool.ConvertFloat(txt_decvariance.Text)+", "+
							" '', '', '"+txt_decremark.Text+"', "+
							" "+tool.ConvertFloat(LBL_CP_INSTALLMENT.Text)+", '0', '"+LBL_DECSTA.Text+"', "+
							" "+tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", '"+var_fromsta+"', "+
							" "+tool.ConvertNum(TXT_CP_GRACEPERIOD.Text)+", '"+ DDL_CP_PAYMENTID.SelectedValue+"', '" + PROD_SEQ + "'";


						conn.ExecuteQuery();
					}
				}
				else if (conn.GetFieldValue("userid") != "")
				{
					// DEBUG
					Response.Write("<!-- else if (conn.GetFieldValue('userid') != '') -->");
					
					///////////////////////////////////////////////////////////////////////////////////
					/// Check between approval_decision (history) with trackhistory
					/// 
					if (dt_chk.Rows[0]["SAME_STATUS"].ToString() == "YES") 
					{
						///////////////////////////////////////////////////////////////////////////////
						/// Approval_decision (history) and trackhistory has the same history,
						/// get the credit description from approval_decision
						/// 
						/**********************/
						/*
						txt_declimit.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_limit"].ToString());
						txt_dectenor.Text				= dt_aprvinfo.Rows[0]["ad_tenor"].ToString();
						ddl_dectenorcode.SelectedValue	= dt_aprvinfo.Rows[0]["ad_tenorcode"].ToString().Trim();
						*/
						LBL_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_limit"].ToString());
						TXT_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_limit"].ToString());
						TXT_CP_JANGKAWKT.Text			= dt_aprvinfo.Rows[0]["ad_tenor"].ToString();
						try {DDL_CP_TENORCODE.SelectedValue	= dt_aprvinfo.Rows[0]["ad_tenorcode"].ToString().Trim();}
						catch {DDL_CP_TENORCODE.SelectedValue	= "";}
						/**********************/

						txt_decfix.Text					= dt_aprvinfo.Rows[0]["ad_interest"].ToString();
						try {ddl_decrate.SelectedValue		= dt_aprvinfo.Rows[0]["ad_rateno"].ToString();}
						catch {ddl_decrate.SelectedValue	= "";}
						try
						{txt_decrate.Text			= Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);}
						catch
						{txt_decrate.Text			= "";}
						try {ddl_decvarcode.SelectedValue	= dt_aprvinfo.Rows[0]["ad_varcode"].ToString().Trim();}
						catch {ddl_decvarcode.SelectedValue = "";}
						txt_decvariance.Text			= dt_aprvinfo.Rows[0]["ad_variance"].ToString();

						txt_decovrsta.Text				= dt_aprvinfo.Rows[0]["ad_ovrsta"].ToString();
						try {ddl_decovrreason.SelectedValue	= dt_aprvinfo.Rows[0]["ad_ovrreason"].ToString().Trim();}
						catch {ddl_decovrreason.SelectedValue	= "";}
						txt_decovrreason.Text			= dt_aprvinfo.Rows[0]["ad_ovrreasontext"].ToString();

						//					txt_decremark.Text				= dt_aprvinfo.Rows[0]["ad_keterangan"].ToString();
						//					txt_decinstallment.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_installment"].ToString());
						//					if ((txt_decinstallment.Text == "0") || (txt_decinstallment.Text == "0,00"))
						//						txt_decinstallment.Text = "-";
						//					txt_decsta.Text					= dt_aprvinfo.Rows[0]["ad_rejectdesc"].ToString();
						//					lbl_decsta.Text					= dt_aprvinfo.Rows[0]["ad_reject"].ToString();
						//					txt_decexlimitval.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_exlimitval"].ToString()); 
						//					txt_decexrplimit.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_exrplimit"].ToString()); 
						//					txt_declimitchg.Text			= dt_aprvinfo.Rows[0]["cp_limitchg"].ToString();
						//					txt_decgraceperiode.Text		= dt_aprvinfo.Rows[0]["ad_graceperiod"].ToString(); 
						//					ddl_decpayfreq.SelectedValue	= dt_aprvinfo.Rows[0]["ad_paymentid"].ToString().Trim(); 
						TXT_CP_KETERANGAN.Text			= dt_aprvinfo.Rows[0]["ad_keterangan"].ToString();
						LBL_CP_INSTALLMENT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_installment"].ToString());
						if ((LBL_CP_INSTALLMENT.Text == "0") || (LBL_CP_INSTALLMENT.Text == "0,00"))
							LBL_CP_INSTALLMENT.Text = "-";
						txt_decsta.Text					= dt_aprvinfo.Rows[0]["ad_rejectdesc"].ToString();
						LBL_DECSTA.Text					= dt_aprvinfo.Rows[0]["ad_reject"].ToString();
						TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_exlimitval"].ToString()); 
						TXT_CP_EXRPLIMIT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_exrplimit"].ToString()); 
						//					txt_declimitchg.Text			= dt_aprvinfo.Rows[0]["cp_limitchg"].ToString(); //Tidak perlu karena permohonan baru
						TXT_CP_GRACEPERIOD.Text			= dt_aprvinfo.Rows[0]["ad_graceperiod"].ToString(); 
						try {DDL_CP_PAYMENTID.SelectedValue	= dt_aprvinfo.Rows[0]["ad_paymentid"].ToString().Trim(); }
						catch {DDL_CP_PAYMENTID.SelectedValue	= "";}
					}
					else 
					{
						//////////////////////////////////////////////////////////////////////////////////////
						///  Approval_decision (history) and trackhistory has the different history,
						///  get the credit description from custproduct
						///  
						LBL_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
						TXT_CP_LIMIT.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
						TXT_CP_JANGKAWKT.Text			= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
						try {DDL_CP_TENORCODE.SelectedValue	= dt_aprvinfo.Rows[0]["cp_tenorcode"].ToString().Trim();}
						catch {DDL_CP_TENORCODE.SelectedValue	= "";}

						txt_decfix.Text					= dt_aprvinfo.Rows[0]["cp_interest"].ToString();
						try {ddl_decrate.SelectedValue		= dt_aprvinfo.Rows[0]["rateno"].ToString();}
						catch {ddl_decrate.SelectedValue	= "";}
						try
						{txt_decrate.Text			= Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);}
						catch
						{txt_decrate.Text			= "";}
						try {ddl_decvarcode.SelectedValue	= dt_aprvinfo.Rows[0]["cp_varcode"].ToString().Trim();}
						catch {ddl_decvarcode.SelectedValue = "";}
						txt_decvariance.Text			= dt_aprvinfo.Rows[0]["cp_variance"].ToString();
						/*
						txt_decovrsta.Text				= dt_aprvinfo.Rows[0]["cp_ovrsta"].ToString();
						try {ddl_decovrreason.SelectedValue	= dt_aprvinfo.Rows[0]["cp_ovrreason"].ToString().Trim();}
						catch {ddl_decovrreason.SelectedValue	= "";}
						txt_decovrreason.Text			= dt_aprvinfo.Rows[0]["cp_ovrreasontext"].ToString();
						*/
						TXT_CP_KETERANGAN.Text			= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString();
						LBL_CP_INSTALLMENT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_installment"].ToString());
						if ((LBL_CP_INSTALLMENT.Text == "0") || (LBL_CP_INSTALLMENT.Text == "0,00"))
							LBL_CP_INSTALLMENT.Text = "-";
						/*
						txt_decsta.Text					= dt_aprvinfo.Rows[0]["cp_rejectdesc"].ToString();
						LBL_DECSTA.Text					= dt_aprvinfo.Rows[0]["cp_reject"].ToString();
						*/
						TXT_CP_EXLIMITVAL.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 
						TXT_CP_EXRPLIMIT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 
						TXT_CP_GRACEPERIOD.Text			= dt_aprvinfo.Rows[0]["cp_graceperiod"].ToString(); 
						try {DDL_CP_PAYMENTID.SelectedValue	= dt_aprvinfo.Rows[0]["cp_paymentid"].ToString().Trim(); }
						catch {DDL_CP_PAYMENTID.SelectedValue	= "";}

						///////////////////////////////////////////////////////////////////////////////////////
						/// Insert a new record into approval_decision with an increment on ad_fromsta field
						/// 
						string ad_fromsta_new = "";
						int _ad_fromsta = 0;
						try { _ad_fromsta = Convert.ToInt16(var_fromsta) + 1; } catch {}
						ad_fromsta_new = _ad_fromsta.ToString();

						conn.QueryString = "exec input_approvaldecision  '"+REGNO+"', '"+PRODUCT+"', "+
							" '"+APPTYPE+"', '"+USERID+"', "+
							" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+TXT_CP_JANGKAWKT.Text+"','"+DDL_CP_TENORCODE.SelectedValue+"', "+
							" "+tool.ConvertFloat(txt_decfix.Text)+", '"+ddl_decrate.SelectedValue+"', '"+ddl_decvarcode.SelectedValue+"', "+tool.ConvertFloat(txt_decvariance.Text)+", "+
							" '', '', '"+txt_decremark.Text+"', "+
							" "+tool.ConvertFloat(LBL_CP_INSTALLMENT.Text)+", '0', '"+LBL_DECSTA.Text+"', "+
							" "+tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", '" + ad_fromsta_new +"', "+
							" "+tool.ConvertNum(TXT_CP_GRACEPERIOD.Text)+", '"+ DDL_CP_PAYMENTID.SelectedValue+"', '" + PROD_SEQ + "'";
						conn.ExecuteNonQuery();
					}
				}

//				txt_idcratio.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["idc_ratio"].ToString());	
//				txt_idcterm.Text				= dt_aprvinfo.Rows[0]["idc_jwaktu"].ToString();
//				txt_idccapratio.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["idc_capratio"].ToString());
//				txt_idccapamt.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["idc_capamnt"].ToString());
//				ddl_idcinttype.SelectedValue	= dt_aprvinfo.Rows[0]["idc_interesttype"].ToString().Trim();
//				if (ddl_idcinttype.SelectedValue == "01")
//				{
//					ddl_idcprimevar.SelectedValue	= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim();
//					try
//					{txt_idcprimevar.Text		= Convert.ToString(double.Parse(ddl_idcprimevar.SelectedItem.Text) * 100);}
//					catch
//					{txt_idcprimevar.Text		= "";}
//					ddl_idcvarcode.SelectedValue	= dt_aprvinfo.Rows[0]["idc_varcode"].ToString().Trim();
//					txt_idcvariance.Text			= dt_aprvinfo.Rows[0]["idc_variance"].ToString();
//				}
//				else if (ddl_idcinttype.SelectedValue == "02")
//				{
//					txt_idcvariance.Text					= dt_aprvinfo.Rows[0]["idc_interest"].ToString();
//				}
				LBL_IDC_RATIO.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["idc_ratio"].ToString());	
				LBL_IDC_JWAKTU.Text				= dt_aprvinfo.Rows[0]["idc_jwaktu"].ToString();
				LBL_IDC_CAPRATIO.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["idc_capratio"].ToString());				
				LBL_IDC_CAPAMNT.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["idc_capamnt"].ToString());
				try {DDL_IDC_INTERESTTYPE.SelectedValue	= dt_aprvinfo.Rows[0]["idc_interesttype"].ToString().Trim();}
				catch {DDL_IDC_INTERESTTYPE.SelectedValue	= "";}
				if (DDL_IDC_INTERESTTYPE.SelectedValue == "01")
				{
					try {ddl_idcprimevar.SelectedValue	= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim();	}
					catch {ddl_idcprimevar.SelectedValue= "";}
					try {LBL_IDC_PRIMEVARCODE.Text	= Convert.ToString(double.Parse(ddl_idcprimevar.SelectedItem.Text) * 100);}
					catch {LBL_IDC_PRIMEVARCODE.Text = "";}
					try {DDL_IDC_VARCODE.SelectedValue	= dt_aprvinfo.Rows[0]["idc_varcode"].ToString().Trim();}
					catch {DDL_IDC_VARCODE.SelectedValue= "";}
					LBL_IDC_VARIANCE.Text			= dt_aprvinfo.Rows[0]["idc_variance"].ToString();					
				}
				else if (DDL_IDC_INTERESTTYPE.SelectedValue == "02")
				{
					LBL_IDC_VARIANCE.Text			= dt_aprvinfo.Rows[0]["idc_interest"].ToString();
				}

				conn.ClearData();
			}

			conn.QueryString = "select interesttype from rfproduct where productid = '"+PRODUCT+"'";
			conn.ExecuteQuery();
			string var_inttype = conn.GetFieldValue("interesttype");
			if (var_inttype == "01")
			{
				tr_decfix.Visible = false;
			}
			else if (var_inttype == "02")
			{
				tr_decfloat.Visible = false;
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
				
		private void CheckIDC()
		{
			conn.QueryString = "select idc_flag, IDC_INTERESTTYPE from custproduct where ap_regno='" + REGNO + 
				"' and apptype='" + APPTYPE + 
				"' and productid='" + PRODUCT + 
				"' and prod_seq = '" + PROD_SEQ + "'";
			conn.ExecuteQuery();

			if (conn.GetFieldValue(0,0) == "1")
			{
				CHECK_IDC.Checked				= true;
				TR_IDC.Visible					= true;
//				TXT_IDC_RATIO.CssClass			= "mandatory";
//				TXT_IDC_JWAKTU.CssClass			= "mandatory";
//				TXT_IDC_CAPAMNT.CssClass		= "mandatory";
//				TXT_IDC_PRIMEVARCODE.CssClass	= "mandatory";
				DDL_IDC_INTERESTTYPE.CssClass	= "mandatory";
				
				if (!conn.GetFieldValue("IDC_INTERESTTYPE").Equals(""))
				{
					DDL_IDC_INTERESTTYPE.SelectedValue = conn.GetFieldValue("IDC_INTERESTTYPE");
					if (conn.GetFieldValue("IDC_INTERESTTYPE") == "01")
					{
						//TXT_IDC_PRIMEVARCODE.ReadOnly = true;
						DDL_IDC_VARCODE.Visible = true;
						LBL_IDC_VARIANCE.Visible = true;	//TXT_IDC_VARIANCE.Visible = true;
					}
					else
					{
						//TXT_IDC_PRIMEVARCODE.ReadOnly = false;
						DDL_IDC_VARCODE.Visible = false;
						LBL_IDC_VARIANCE.Visible = false;	//TXT_IDC_VARIANCE.Visible = false;
					}
				}
			}
		}

		//20070725 add by sofyan for alih debitur
		private void viewdataalihdeb()
		{
			conn.QueryString = "exec DE_ALIHDEB_VIEW '"+ REGNO +"', '"+ PRODUCT +"', '"+APPTYPE+"', '" + PROD_SEQ + "'";
			conn.ExecuteQuery();
			
			if (conn.GetFieldValue("CP_ALIHDEBFLAG") == "1")
			{
				CHK_ALIHDEB.Checked = true;
				TR_OLDCIFNO.Visible = true;
				TXT_OLDCIFNO.Text = conn.GetFieldValue("CP_OLDCIFNO");
				TR_OLDACCNO.Visible = true;
				TXT_OLDACCNO.Text = conn.GetFieldValue("CP_OLDACCNO");
			}
			else
			{
				CHK_ALIHDEB.Checked = false;
				TR_OLDCIFNO.Visible = false;
				TR_OLDACCNO.Visible = false;
			}
		}
		
		//20070725 add by sofyan for alih debitur
		private void savealihdeb()
		{
			string alihdeb;
			if (CHK_ALIHDEB.Checked == true)
				alihdeb = "1";
			else
				alihdeb = "0";
			conn.QueryString = "exec DE_ALIHDEBITUR_SAVE '" + 
				REGNO + "', '" + 
				PRODUCT + "', '" +
				APPTYPE + "', '" + 
				PROD_SEQ + "', '" +
				alihdeb + "', '" +
				TXT_OLDCIFNO.Text + "', '" +
				TXT_OLDACCNO.Text + "'";
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

			/*****
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
			***/
			
			Response.Write("<script language='javascript'>window.open('../dataentry/CustProduct.aspx?regno=" + REGNO + "&curef=" + CUREF + "&sta=view','StrukturKredit','status=no,scrollbars=yes,width=800,height=600');</script>");

			//Response.Write("<script for=window event=onload language='javascript'>PopupPage('/SME/DataEntry/" + conn.GetFieldValue("screenlink")+"?regno="+REGNO+"&apptype="+APPTYPE+ "&prodid="+PRODUCT+"&prod_seq="+ PROD_SEQ +"&teks="+var_text+ "&de=0" + "', '900', '500');</script>");			
			//Response.Write("<script language='javascript'>window.open('/SME/DataEntry/" + conn.GetFieldValue("screenlink")+"?regno="+REGNO+"&apptype="+APPTYPE+ "&prodid="+PRODUCT+"&teks="+var_text+ "&de=0" + "', 'CreditStructure', 'status=yes,scrollbars=yes,width=900,height=500');</script>");
		}

		private void btn_override_Click(object sender, System.EventArgs e)
		{
			string var_fromsta = "";
			/***
			 * Cheng : Don't control limit changes by user
			 * 
			if (double.Parse(TXT_CP_EXLIMITVAL.Text) > double.Parse(txt_exlimitval.Text))
			{
				GlobalTools.popMessage(this, "Approval limit Cannot greater than Requested Limit");
				return;
			}
			***/
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
				if (double.Parse(TXT_CP_LIMIT.Text) > double.Parse(conn.GetFieldValue("su_emaslimit").ToString()))
				{
					GlobalTools.popMessage(this, "Limit in rupiah cannot greater than eMas Limit");
					return;
				}
			}
			***/

			//////////////////////////////////////////////////////////////
			/// Check tenor validity
			/// 
			if (((int.Parse(TXT_CP_JANGKAWKT.Text) < 30) && (DDL_CP_TENORCODE.SelectedValue == "D")) || ((int.Parse(TXT_CP_JANGKAWKT.Text) < 1) && (DDL_CP_TENORCODE.SelectedValue == "M")))
			{
				GlobalTools.popMessage(this, "Tenor Cannot below 30 days or 1 month");
				return;
			}

			///////////////////////////////////////////////////////////////////
			///	Kalau aplikasi punya sub aplikasi :
			///	cek kalau limit diubah, pastikan tidak kurang dari jumlah
			///	limit sub aplikasi
			///	
			double CP_LIMIT_MAIN = 0;
			double CP_LIMIT_ALL_SUB = 0;
			
			try { CP_LIMIT_MAIN =  Convert.ToDouble(tool.ConvertFloat(TXT_CP_LIMIT.Text)); } 
			catch {}
			/**
			 * Mengambil limit semua sub application
			 */
			conn.QueryString = "select sum(CP_LIMIT) as CP_LIMIT_ALL_SUB from CUSTPRODUCT where MAINAP_REGNO = '" + REGNO + 
				"' and MAINPRODUCTID = '" + PRODUCT + 
				"' and MAINPROD_SEQ = '" + PROD_SEQ + "'";
			conn.ExecuteQuery();			

			try {CP_LIMIT_ALL_SUB = Convert.ToDouble(conn.GetFieldValue("CP_LIMIT_ALL_SUB"));}
			catch {}

			/*
			 * Kalau LIMIT SUB + LIMIT SEMUA SUB > LIMIT MAIN ....
			 */
			if (CP_LIMIT_ALL_SUB > CP_LIMIT_MAIN) 
			{
				GlobalTools.popMessage(this, "Limit Main aplikasi kurang dari limit sub aplikasi!");
				return;
			}
			//////////////////////////////////////////////////////////////
			

			///////////////////////////////////////////////////////////////////////////////////////////////
			/// Get Approval count of related-user
			/// 
			/*
			conn.QueryString = "select isnull(ap_isappeal,0) ap_isappeal from application where ap_regno = '" + REGNO + "'";
			conn.ExecuteQuery();
			var_fromsta = conn.GetFieldValue("ap_isappeal");
			*/
			conn.QueryString = "exec APPROVAL_CHECKHISTORY '" + REGNO + "', '" + PRODUCT + "', '" + APPTYPE + "', '" + USERID + "', '" + PROD_SEQ + "'";
			conn.ExecuteQuery();

			var_fromsta = conn.GetFieldValue("CNT_APPROVAL");


			LBL_CP_LIMIT.Text = Convert.ToString((double.Parse(TXT_CP_EXLIMITVAL.Text)*double.Parse(TXT_CP_EXRPLIMIT.Text)));
			TXT_CP_LIMIT.Text = Convert.ToString((double.Parse(TXT_CP_EXLIMITVAL.Text)*double.Parse(TXT_CP_EXRPLIMIT.Text)));
			CalculateInstallment();
			if (LBL_CP_INSTALLMENT.Text == "-")
				LBL_CP_INSTALLMENT.Text = "0";

			conn.QueryString = "exec input_approvaldecision  '" + REGNO + "', '" + PRODUCT + "', "+
				" '" + APPTYPE + "', '" + USERID + "', "+
				" "+tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+TXT_CP_JANGKAWKT.Text+"','"+DDL_CP_TENORCODE.SelectedValue+"', "+
				" "+tool.ConvertFloat(txt_decfix.Text)+", '"+ddl_decrate.SelectedValue+"', '"+ddl_decvarcode.SelectedValue+"', "+tool.ConvertFloat(txt_decvariance.Text)+", "+
				" '"+ddl_decovrreason.SelectedValue+"', '"+txt_decovrreason.Text+"', '"+txt_decremark.Text+"', "+tool.ConvertFloat(LBL_CP_INSTALLMENT.Text)+", "+
				" '1', '"+LBL_DECSTA.Text+"', "+tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", '"+var_fromsta+"', "+
				" "+tool.ConvertNum(TXT_CP_GRACEPERIOD.Text)+", '"+DDL_CP_PAYMENTID.SelectedValue+"', '" + PROD_SEQ + "'";
			conn.ExecuteQuery();

			if (LBL_IDC_VARIANCE.Text == "")
				LBL_IDC_VARIANCE.Text = "0";

			if (DDL_IDC_INTERESTTYPE.SelectedValue == "01")
			{
				conn.QueryString = "update custproduct set idc_interesttype = '" + DDL_IDC_INTERESTTYPE.SelectedValue +
					"', idc_varcode = '" + DDL_IDC_VARCODE.SelectedValue +
					"', idc_variance = " + tool.ConvertFloat(LBL_IDC_VARIANCE.Text) + " "+
					" where ap_regno = '" + REGNO + "' and productid = '" + PRODUCT +
					"' and apptype = '" + APPTYPE + "' and PROD_SEQ = '" + PROD_SEQ + "'";
			}
			else if (DDL_IDC_INTERESTTYPE.SelectedValue == "02")
			{
				conn.QueryString = "update custproduct set idc_interesttype = '" + DDL_IDC_INTERESTTYPE.SelectedValue +
					"', idc_interest = " + tool.ConvertFloat(LBL_IDC_VARIANCE.Text) + " " +
					" where ap_regno = '" + REGNO + "' and productid = '" + PRODUCT +
					"' and apptype = '" + APPTYPE + "' and PROD_SEQ = '" + PROD_SEQ + "'";
			}
			conn.ExecuteQuery();

			//20070313 add by sofyan for alih debitur
			savealihdeb();

			/////////////////////////////////////////////////////////
			///	Menghitung ulang Total Application Value dan
			///	Total Limit Exposure
			///	
			conn.QueryString = "APPROVAL_TOTALEXPOSURE '" + REGNO + "'";
			conn.ExecuteQuery(300);
			LBL_LIMITEXPOSURE.Text	= tool.MoneyFormat(conn.GetFieldValue("exposure"));
			LBL_SUMLIMIT.Text		= tool.MoneyFormat(conn.GetFieldValue("tot_limit"));
			conn.ClearData();

            //CalculateRate();
		}

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
		private void CHK_ALIHDEB_CheckedChanged(object sender, System.EventArgs e)
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
		}

        public void RetrievePundiRateOnPostBack()
        {
            TR_ANUITY_ISNTALMENT.Visible = false;

            /****************************************************************** RATE ************************************************************************/
            conn.QueryString = "SELECT RATE FROM RFRATENUMBER, RFPRODUCT WHERE RFPRODUCT.PRODUCTID = '" + PRODUCT + "' AND RFPRODUCT.RATENO = RFRATENUMBER.RATENO";
            conn.ExecuteQuery();

            if (TXT_RATE_FLAT_PUNDI.Text == "0" || TXT_RATE_FLAT_PUNDI.Text == "" || TXT_RATE_FLAT_PUNDI.Text == "0,00")
            {
                TXT_RATE_FLAT_PUNDI.Text = (float.Parse(conn.GetFieldValue(0, 0))).ToString();
            }

            conn.QueryString = "SELECT CP_RATE, CP_FLAT_INSTALMENT, CP_ANUITY_INSTALMENT, CP_RATE_ANUITY FROM CUSTPRODUCT WHERE AP_REGNO = '" + REGNO + "' AND APPTYPE = '" + APPTYPE + "' AND PRODUCTID = '" + PRODUCT + "' AND PROD_SEQ = '" + PROD_SEQ + "'";
            conn.ExecuteQuery();

            try
            {
                float rate_chg = 0;
                if (FlatRate.Text == "0" || FlatRate.Text == "" || FlatRate.Text == "0,00")
                {
                    //20170515//FlatRate.Text = ((float.Parse(conn.GetFieldValue(0, 0)) * 100) / 12).ToString();
                    FlatRate.Text = ((float.Parse(conn.GetFieldValue(0, 0)) * 100)).ToString();
                }

                if (TXT_RATE_CHG.Text == "" || TXT_RATE_CHG.Text == "0" || TXT_RATE_CHG.Text == "0,00")
                {
                    if ((float.Parse(conn.GetFieldValue(0, 0)) * 100) > float.Parse(TXT_RATE_FLAT_PUNDI.Text))
                    {
                        rate_chg = (float.Parse(conn.GetFieldValue(0, 0)) * 100) - float.Parse(TXT_RATE_FLAT_PUNDI.Text);
                        DDL_Operator.SelectedValue = "+";
                    }
                    else
                    {
                        rate_chg = float.Parse(TXT_RATE_FLAT_PUNDI.Text) - (float.Parse(conn.GetFieldValue(0, 0)) * 100);
                        DDL_Operator.SelectedValue = "-";
                    }
                    TXT_RATE_CHG.Text = rate_chg.ToString();
                }
            }
            catch
            {
                TXT_RATE_CHG.Text = "0";
            }

            try
            {
                if (TXT_ANN_INSTALMENT.Text == "" || TXT_ANN_INSTALMENT.Text == "0" || TXT_ANN_INSTALMENT.Text == "0,00")
                {
                    TXT_ANN_INSTALMENT.Text = (float.Parse(conn.GetFieldValue(0, 3)) * 100).ToString();
                }
            }
            catch
            {
                TXT_ANN_INSTALMENT.Text = "0";
            }
            /****************************************************************** END ************************************************************************/

            //jumlah angsuran
            if (TXT_FLAT_INSTALMENT.Text == "" || TXT_FLAT_INSTALMENT.Text == "0,00" || TXT_FLAT_INSTALMENT.Text == "0")
            {
                TXT_FLAT_INSTALMENT.Text = tool.MoneyFormat(conn.GetFieldValue(0, 1));
            }

            if (TXT_ANUITY_INSTALMENT.Text == "" || TXT_ANUITY_INSTALMENT.Text == "0,00" || TXT_ANUITY_INSTALMENT.Text == "0")
            {
                TXT_ANUITY_INSTALMENT.Text = tool.MoneyFormat(conn.GetFieldValue(0, 2));
            }
        }

        public void RetrievePundiRate()
        {
            TR_ANUITY_ISNTALMENT.Visible = false;

            /****************************************************************** RATE ************************************************************************/
            conn.QueryString = "SELECT RATE FROM RFRATENUMBER, RFPRODUCT WHERE RFPRODUCT.PRODUCTID = '" + PRODUCT + "' AND RFPRODUCT.RATENO = RFRATENUMBER.RATENO";
            conn.ExecuteQuery();

            TXT_RATE_FLAT_PUNDI.Text = (float.Parse(conn.GetFieldValue(0, 0))).ToString();

            conn.QueryString = "SELECT CP_RATE, CP_FLAT_INSTALMENT, CP_ANUITY_INSTALMENT, CP_RATE_ANUITY FROM CUSTPRODUCT WHERE AP_REGNO = '" + REGNO + "' AND APPTYPE = '" + APPTYPE + "' AND PRODUCTID = '" + PRODUCT + "' AND PROD_SEQ = '" + PROD_SEQ + "'";
            conn.ExecuteQuery();

            try
            {
                float rate_chg = 0;
                //20170515//FlatRate.Text = ((float.Parse(conn.GetFieldValue(0, 0)) * 100) / 12).ToString();
                FlatRate.Text = ((float.Parse(conn.GetFieldValue(0, 0)) * 100)).ToString();

                if ((float.Parse(conn.GetFieldValue(0, 0)) * 100) > float.Parse(TXT_RATE_FLAT_PUNDI.Text))
                {
                    rate_chg = (float.Parse(conn.GetFieldValue(0, 0)) * 100) - float.Parse(TXT_RATE_FLAT_PUNDI.Text);
                    DDL_Operator.SelectedValue = "+";
                }
                else
                {
                    rate_chg = float.Parse(TXT_RATE_FLAT_PUNDI.Text) - (float.Parse(conn.GetFieldValue(0, 0)) * 100);
                    DDL_Operator.SelectedValue = "-";
                }
                TXT_RATE_CHG.Text = rate_chg.ToString();
            }
            catch
            {
                TXT_RATE_CHG.Text = "0";
            }

            try
            {
                TXT_ANN_INSTALMENT.Text = (float.Parse(conn.GetFieldValue(0, 3)) * 100).ToString();
            }
            catch
            {
                TXT_ANN_INSTALMENT.Text = "0";
            }
            /****************************************************************** END ************************************************************************/

            //jumlah angsuran
            TXT_FLAT_INSTALMENT.Text = tool.MoneyFormat(conn.GetFieldValue(0, 1));
            TXT_ANUITY_INSTALMENT.Text = tool.MoneyFormat(conn.GetFieldValue(0, 2));
        }

        private void CalculateRate()
        {
            try
            {

                //konversi yg dimasukin cuman FLAT RATE
                //20170515//float flatrate = float.Parse(FlatRate.Text) * 12;
                float flatrate = float.Parse(FlatRate.Text) / 100;
                //20170515//float hiddenTXT_RATE = float.Parse(TXT_RATE_FLAT_PUNDI.Text);
                float hiddenTXT_RATE = float.Parse(TXT_RATE_FLAT_PUNDI.Text);

                if (flatrate >= hiddenTXT_RATE)
                {
                    float selisih = flatrate - hiddenTXT_RATE;
                    //TXT_RATE.Text
                    //TXT_RATE_CHG.Text
                    //DDL_Operator.SelectedValue

                    DDL_Operator.SelectedValue = "+";
                    TXT_RATE_CHG.Text = selisih.ToString();
                }
                else
                {
                    float selisih = hiddenTXT_RATE - flatrate;

                    DDL_Operator.SelectedValue = "-";
                    TXT_RATE_CHG.Text = selisih.ToString();
                }

                //supaya selalu berhasil
                /*
                if ((float.Parse(TXT_RATE_CHG.Text) % 0.5) == 0)
                {
                    TXT_RATE_CHG.Text = (float.Parse(TXT_RATE_CHG.Text) + float.Parse("0,0001")).ToString();
                }
                */

                float tenor = 0;

                if (DDL_CP_TENORCODE.SelectedValue == "M")
                {
                    tenor = float.Parse(TXT_CP_JANGKAWKT.Text);
                }
                else if (DDL_CP_TENORCODE.SelectedValue == "D")
                {
                    tenor = float.Parse(TXT_CP_JANGKAWKT.Text) / 30;
                    tenor = float.Parse(Math.Round(tenor).ToString());
                }

                float TotalRate = 0;

                if (DDL_Operator.SelectedValue == "+")
                {
                    TotalRate = float.Parse(TXT_RATE_FLAT_PUNDI.Text) + float.Parse(TXT_RATE_CHG.Text);
                }
                else
                {
                    float rate1 = float.Parse(TXT_RATE_FLAT_PUNDI.Text);
                    float rate2 = float.Parse(TXT_RATE_CHG.Text);
                    TotalRate = rate1 - rate2;
                }
                //20170515//TotalRate = TotalRate / 100;
                TotalRate = TotalRate;

                //TotalRate dimasukin langsung ke field FlatRate

                float AngsuranPokok = float.Parse(TXT_CP_LIMIT.Text) / tenor;
                float AngsuranBunga = (float.Parse(TXT_CP_LIMIT.Text) * TotalRate) / tenor;
                float flat_installment = 0;

                flat_installment = (((float.Parse(TXT_CP_LIMIT.Text) * TotalRate) * (tenor / 12)) + float.Parse(TXT_CP_LIMIT.Text)) / tenor;

                //20170515//double ann_installment = -1 * Financial.Pmt(System.Convert.ToDouble(TotalRate / 12), System.Convert.ToDouble(tenor), System.Convert.ToDouble(TXT_CP_LIMIT.Text), 0, DueDate.EndOfPeriod);
                double ann_installment = -1 * Financial.Pmt(System.Convert.ToDouble(TotalRate), System.Convert.ToDouble(tenor), System.Convert.ToDouble(TXT_CP_LIMIT.Text), 0, DueDate.EndOfPeriod);

                TXT_FLAT_INSTALMENT.Text = tool.MoneyFormat(flat_installment.ToString());
                TXT_ANUITY_INSTALMENT.Text = tool.MoneyFormat(ann_installment.ToString());

                //konversi dari flat rate ke annuity rate
                //TXT_ANN_INSTALMENT

                double param1 = System.Convert.ToDouble(tenor);
                double param2 = System.Convert.ToDouble(TXT_FLAT_INSTALMENT.Text);
                double param3 = System.Convert.ToDouble(TXT_CP_LIMIT.Text);

                double rate = Financial.Rate(param1, -param2, param3);
                rate = (rate * 100) * 12;

                /*double usagePanels = 3.0;
                double rate = 3.17;

                double annRate = (Math.Pow((1 + rate / 100), usagePanels) * ((1 + rate / 100) - 1) / (Math.Pow(1 + rate / 100, (usagePanels)) - 1)) * 100;*/

                TXT_ANN_INSTALMENT.Text = rate.ToString();

                /*
                    CP_RATE
                    CP_FLAT_INSTALMENT
                    CP_ANUITY_INSTALMENT
                    CP_RATE_ANUITY
                 */

                string TotalRateString = "";
                string rateString = "";
                string TXT_FLAT_INSTALMENT_String = "";
                string TXT_ANN_INSTALMENT_String = "";

                if (TotalRate.ToString().EndsWith(",00"))
                {
                    TotalRate = TotalRate * 100;
                    TotalRateString = TotalRate.ToString().Remove(TotalRate.ToString().Length - 3).Replace(".", "");
                }
                else
                {
                    TotalRateString = TotalRate.ToString().Replace(".", "");
                }

                if (rate.ToString().EndsWith(",00"))
                {
                    rateString = (rate / 100).ToString().Remove(rate.ToString().Length - 3).Replace(".", "");
                }
                else
                {
                    rateString = (rate / 100).ToString().Replace(".", "");
                }

                if (TXT_FLAT_INSTALMENT.Text.ToString().EndsWith(",00"))
                {
                    TXT_FLAT_INSTALMENT_String = TXT_FLAT_INSTALMENT.Text.ToString().Remove(TXT_FLAT_INSTALMENT.Text.ToString().Length - 3).Replace(".", "");
                }
                else
                {
                    TXT_FLAT_INSTALMENT_String = TXT_FLAT_INSTALMENT.Text.ToString().Replace(".", "");
                }

                if (TXT_ANN_INSTALMENT.Text.ToString().EndsWith(",00"))
                {
                    TXT_ANN_INSTALMENT_String = TXT_ANUITY_INSTALMENT.Text.ToString().Remove(TXT_ANUITY_INSTALMENT.Text.ToString().Length - 3).Replace(".", "");
                }
                else
                {
                    TXT_ANN_INSTALMENT_String = TXT_ANUITY_INSTALMENT.Text.ToString().Replace(".", "");
                }

                conn.QueryString = "UPDATE CUSTPRODUCT SET CP_RATE = " + TotalRateString.Replace(",", ".") + ", CP_RATE_ANUITY = " + rateString.Replace(",", ".") + ", CP_FLAT_INSTALMENT = " + TXT_FLAT_INSTALMENT_String.Replace(",", ".") + ", CP_ANUITY_INSTALMENT = " + TXT_ANN_INSTALMENT_String.ToString().Replace(",", ".") + " WHERE AP_REGNO = '" + REGNO + "' AND APPTYPE = '" + APPTYPE + "' AND PRODUCTID = '" + PRODUCT + "' AND PROD_SEQ = '" + PROD_SEQ + "'";
                conn.ExecuteQuery();

                RetrievePundiRate();

                GlobalTools.popMessage(this, "Kalkulasi Berhasil !");
            }
            catch
            {
                Tools.popMessage(this, "Inputan tidak valid !");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CalculateRate();
        }


	}
}
