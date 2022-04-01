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


namespace SME.InitialDataEntry
{
	/// <summary>
	/// Summary description for PreScoringPrint.
	/// </summary>
	public partial class PreScoringPrint : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TXT_JML_PEGAWAI;
		protected System.Web.UI.WebControls.DropDownList DDL_MULAIUSAHA_MM;
		protected System.Web.UI.WebControls.TextBox TXT_MULAIUSAHA_YY;
		protected System.Web.UI.WebControls.TextBox TXT_MULAIUSAHA_DD;
		protected System.Web.UI.WebControls.TextBox TXT_EXIST_WC_LIMIT_OTHERBANK;
		protected System.Web.UI.WebControls.TextBox TXT_PSRL_LABAOPERASI;
		protected System.Web.UI.WebControls.TextBox TXT_PSRL_BIAYABUNGA;
		protected System.Web.UI.WebControls.TextBox TXT_PSRL_BIAYAPENYUSUTAN;
		protected System.Web.UI.WebControls.TextBox TXT_PSRL_BIAYALAIN;
		protected System.Web.UI.WebControls.TextBox TXT_PEND_LAIN;
		protected System.Web.UI.WebControls.TextBox TXT_LABASBLMPAJAK;
		protected System.Web.UI.WebControls.TextBox TXT_PAJAK;
		protected System.Web.UI.WebControls.TextBox TXT_LABABERSIH;
		protected System.Web.UI.WebControls.TextBox TXT_SLSWKR;
		protected System.Web.UI.WebControls.TextBox TXT_DNWR;
		protected System.Web.UI.WebControls.TextBox TXT_CURRENTRATIO;
		protected System.Web.UI.WebControls.TextBox TXT_BUSSDEBTSRATIO;
		protected System.Web.UI.WebControls.TextBox TXT_LABABERSIHRATA2;
		protected System.Web.UI.WebControls.TextBox TXT_CASH_VELOCITY;
		protected System.Web.UI.WebControls.TextBox TXT_DAYS_RECEIVABLE;
		protected System.Web.UI.WebControls.TextBox TXT_DAYS_INVENTORY;
		protected System.Web.UI.WebControls.TextBox TXT_DAYS_ACCPAYABLE;
		protected System.Web.UI.WebControls.TextBox TXT_NETWORKING_CAPITAL;
		protected System.Web.UI.WebControls.TextBox TXT_TOTALASSET_TO;
		protected System.Web.UI.WebControls.TextBox TXT_PSRL_PENJUALANTAHUNAN_2;
		protected System.Web.UI.WebControls.TextBox TXT_PSRL_HPP_2;
		protected System.Web.UI.WebControls.TextBox TXT_PSRL_BIAYAUMUMADM_2;

		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			TBL_HIDDEN_DLL.Visible = false;
			SetFormBYBussinesType();

			if (!IsPostBack) 
			{
				IsiDDL();
				viewData();
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

		private void IsiDDL()
		{
			string str;

			////////////////////////////////////////////////////////////////////////////////////////////////////
			/// hubungan dengan bank
			/// 
			str="select COLLECTIBILITY,DESCRIPTION from RFCOLLECTIBILITYSCORING";
			GlobalTools.fillRefList(DDL_BUSINESS_BM_COLL_W12, str, conn);
			GlobalTools.fillRefList(DDL_MGM_BM_COLL_CURR, str, conn);
			GlobalTools.fillRefList(DDL_APP_BM_COLL_CURR, str, conn);
			GlobalTools.fillRefList(DDL_KEY_BM_COLL, str, conn);

			str="select COLLLEVEL,DESCRIPTION from RFCOLLECTIBILITYLEVELSCORING";
			GlobalTools.fillRefList(DDL_APP_BI_COLL_CURR, str, conn);
			GlobalTools.fillRefList(DDL_KEY_BI_COLL_LVL, str, conn);
			GlobalTools.fillRefList(DDL_MGM_BI_COLL_LVL, str, conn);

			str="select FACILITYFLAG,DESCRIPTION from RFFACILITYFLAGSCORING";
			GlobalTools.fillRefList(DDL_FACKREDIT, str, conn);

			////////////////////////////////////////////////////////////////////////////////////////////////////
			/// info umum
			///
			str = "select JNSPERMOHONANID,JNSPERMOHONAN from RFPERMOHONANSCORING";
			GlobalTools.fillRefList(DDL_JNSPERMOHONAN, str, conn);

			str="select KREDITID,KREDIT from RFKREDITSCORING";
			GlobalTools.fillRefList(DDL_JNSKREDIT, str, conn);

			str="select EDUCATIONID,EDUCATIONDESC from RFEDUCATION";
			GlobalTools.fillRefList(DDL_PENDAKHIR, str, conn);			

			str = "select MARITALID,MARITALDESC from rfmarital";
			GlobalTools.fillRefList(DDL_STATUSKAWIN, str, conn);

			str = "SELECT TIPEPERUSAHAANID,TIPEPERUSAHAANDESC FROM RFSCORINGTIPEPERUSH";
			GlobalTools.fillRefList(DDL_JNSPERUSH, str, conn);
						
			str = "select * from VW_SCORING_CREDITSCHEME where AP_REGNO = '" + Request.QueryString["regno"] + "'";
			GlobalTools.fillRefList(DDL_SKEMAKREDIT, str, conn);

			str = "select ProductID,Product from RFEXISTINGPRODUCTSCORING  ";
			GlobalTools.fillRefList(DDL_PRODUCTEXIST, str, conn);

			str = "select * from RFSCR_FI_EXISTINGFACILITY where active = '1'";
			GlobalTools.fillRefList(DDL_EXISTING_FAC, str, conn);
		}

		private void viewData()
		{
			string str;

			//==============================================================================
			// isi data grid
			conn.QueryString = "select * from VW_IDT_RULE_REASON where AP_REGNO='"+ Request.QueryString["regno"] +"'";
			conn.ExecuteQuery();
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();

			dtGrid.DataSource = dt;				
			dtGrid.DataBind();

			////////////////////////////////////////////////////////////////////////////////////////////////////
			/// header
			/// 

			conn.QueryString ="exec SP_PRINT_SCORING '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

//			conn.QueryString ="select * from vw_prescoring_main where ap_regno='" + Request.QueryString["regno"] + "'";
//			conn.ExecuteQuery();
			lbl_HD_APREGNO.Text = conn.GetFieldValue("AP_REGNO");
			lbl_HD_CUREF.Text = conn.GetFieldValue("CU_REF");
			lbl_HD_TGLAPP.Text = conn.GetFieldValue("AP_SIGNDATE");
			lbl_HD_PROGRAM.Text = conn.GetFieldValue("PROGRAMDESC");
			lbl_HD_BUSUNIT.Text = conn.GetFieldValue("AP_BUSINESSUNIT");
			lbl_HD_CABANG.Text = conn.GetFieldValue("BRANCH_NAME");

			lbl_HD_SRCCODE.Text = conn.GetFieldValue("branch_name_source"); //ahmad

			lbl_HD_NAMARM.Text = conn.GetFieldValue("AP_RELMNGR");
			lbl_HD_NAMATL.Text = conn.GetFieldValue("AP_CA"); // the label NAMATL is referring AP_CA field 
			lbl_HD_PEMOHON.Text = conn.GetFieldValue("CU_NAME");
			lbl_HD_ALAMAT.Text = conn.GetFieldValue("CU_ADDR1");
			lbl_HD_KOTA.Text = conn.GetFieldValue("CITYNAME");
			lbl_HD_BUSTYPE.Text = conn.GetFieldValue("BUSINESSTYPE");

			////////////////////////////////////////////////////////////////////////////////////////////////////
			/// scoring result
			///
//			conn.QueryString = "select * from scoring_response_tbl where ap_Regno like '%"+ Request.QueryString["regno"] +"%'";
//			conn.ExecuteQuery();
//			if ( conn.GetRowCount() > 0 )
//			{
				lbl_SR_OVERALLSW.Text = getScoringResultDesc("OVERALL",conn.GetFieldValue(0,"OHD_SYS_DECISION"));
				lbl_SR_SCORECLASS.Text = getScoringResultDesc("SCRCLASS",conn.GetFieldValue(0,"A1401"));
				lbl_SR_VISITINDICATOR.Text = getScoringResultDesc("VISITIND",conn.GetFieldValue(0,"A1402")); 
				lbl_SR_FINANCIAL.Text = getScoringResultDesc("FINFORMAT",conn.GetFieldValue(0,"A1403")); 
				lbl_SR_MANUALREV.Text = getScoringResultDesc("MANREVIEW",conn.GetFieldValue(0,"A1404"));
				lbl_SR_PRICINGCLASS_ID.Text = conn.GetFieldValue("A1405");
				lbl_SR_PERINCREASE.Text = conn.GetFieldValue("G0001");
				lbl_SR_STATRES.Text = conn.GetFieldValue("OHD_SYS_DECISION") == "XX" ? "Fail" : "Success";

				//==============================================================================
				// micro / low line
				lbl_LO_WCLIMIT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("G0002"));
				lbl_LO_WCKUMLTA.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("G0004"));
				lbl_LO_WCMICRO.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("G0005"));
				lbl_LO_INVLOAN.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("G0006"));
				lbl_LO_INVMICRO.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("G0007"));
				lbl_LO_INVKUMLTA.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("G0008"));

				//==============================================================================
				// PUKK
				lbl_PU_WCPUKK.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0003"));
				lbl_PU_TOTASSET.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0031"));

				//==============================================================================
				// small
				lbl_SM_INVLOAN.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0006"));
				lbl_SM_WCCROUTINE.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0009"));
				lbl_SM_WCCTERMYN.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0010"));
				lbl_SM_WCCTRUNKEY.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0011"));
				lbl_SM_WCSB100.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0012"));
				lbl_SM_WCSB500.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0013"));
				lbl_SM_PRCSBBID.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0014"));
				lbl_SM_PRCSBADV.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0015"));
				lbl_SM_PRCSBPERF.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0016"));
				lbl_SM_PRCSBRET.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0017"));
				lbl_SM_PRCSBPURCH.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0018"));
				lbl_SM_SBTOTBG.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0019"));
				lbl_SM_SBPLAFOND.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0020"));

				//==============================================================================
				// middle
				lbl_MI_INVLOAN.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0006"));
				lbl_MI_WCLIMIT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0021"));
				lbl_MI_CONTURKEY.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0022"));
				lbl_MI_CONPROGRESS.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0023"));
				lbl_MI_CONPLAFOND.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0011"));
				lbl_MI_PRCBID.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0024"));
				lbl_MI_PRCADV.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0025"));
				lbl_MI_PRCPERF.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0026"));
				lbl_MI_PRCRET.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0027"));
				lbl_MI_PRCBOND.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0028"));
				lbl_MI_NONCASHBG.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0029"));
				lbl_MI_LCLIMIT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0030"));

//			}

//			if (lbl_SR_PRICINGCLASS_ID.Text.Trim() != "")
//			{
//				conn.QueryString="select * from rfscoringresultparam where stw_code='" + lbl_SR_PRICINGCLASS_ID.Text + "' and stw_type='pricing'";
//				conn.ExecuteQuery();
				lbl_SR_PRICINGCLASS.Text=lbl_SR_PRICINGCLASS_ID.Text + " - " + conn.GetFieldValue("stw_desc");
//			}


			////////////////////////////////////////////////////////////////////////////////////////////////////
			/// hubungan dengan bank
			///
//			conn.QueryString="select * from SCORING_HUBBANK_HISTORY where ap_regno='" + Request.QueryString["regno"] + "' and " + 
//				"sumberdata = ''";
//			conn.ExecuteQuery();
//			if( conn.GetRowCount() > 0 )
//			{
				try{DDL_FACKREDIT.SelectedValue = conn.GetFieldValue(0,"FACKREDIT");}
				catch{}
				try{DDL_APP_BI_COLL_CURR.SelectedValue = conn.GetFieldValue("APP_BI_COLL_CURR");}
				catch{}
				try{DDL_APP_BM_COLL_CURR.SelectedValue = conn.GetFieldValue("APP_BM_COLL_CURR");}
				catch{}
				try{DDL_BUSINESS_BM_COLL_W12.SelectedValue = conn.GetFieldValue("APP_BM_COLL_W12");}
				catch{}
				try{DDL_KEY_BM_COLL.SelectedValue = conn.GetFieldValue("KEY_BM_COLL");}
				catch{}
				try{DDL_KEY_BI_COLL_LVL.SelectedValue = conn.GetFieldValue("KEY_BI_COLL_LVL");}
				catch{}
				try{DDL_MGM_BM_COLL_CURR.SelectedValue = conn.GetFieldValue("MGM_BM_COLL_CURR");}
				catch{}
				try{DDL_MGM_BI_COLL_LVL.SelectedValue = conn.GetFieldValue("MGM_BI_COLL_LVL");}
				catch{}

				//########################################################################################

				//==============================================================================
				// Hubungan Dengan Bank
				lbl_LOHB_ISNASABAHBM.Text = conn.GetFieldValue("BUSINESS_CURR_BM") == "N" ? "Tidak" : conn.GetFieldValue("BUSINESS_CURR_BM") == "Y" ? "Ya" : "-";
				lbl_PUHB_ISNASABAHBM.Text = conn.GetFieldValue("BUSINESS_CURR_BM") == "N" ? "Tidak" : conn.GetFieldValue("BUSINESS_CURR_BM") == "Y" ? "Ya" : "-";
				lbl_SMHB_ISNASABAHBM.Text = conn.GetFieldValue("BUSINESS_CURR_BM") == "N" ? "Tidak" : conn.GetFieldValue("BUSINESS_CURR_BM") == "Y" ? "Ya" : "-";
				lbl_MIHB_ISNASABAHBM.Text = conn.GetFieldValue("BUSINESS_CURR_BM") == "N" ? "Tidak" : conn.GetFieldValue("BUSINESS_CURR_BM") == "Y" ? "Ya" : "-";

				lbl_LOHB_MULAINASABAH.Text = conn.GetFieldValue("MULAI_BM_MM") +"/" +conn.GetFieldValue("MULAI_BM_YY");
				lbl_PUHB_MULAINASABAH.Text = conn.GetFieldValue("MULAI_BM_MM") +"/" +conn.GetFieldValue("MULAI_BM_YY");
				lbl_SMHB_MULAINASABAH.Text = conn.GetFieldValue("MULAI_BM_MM") +"/" +conn.GetFieldValue("MULAI_BM_YY");
				lbl_MIHB_MULAINASABAH.Text = conn.GetFieldValue("MULAI_BM_MM") +"/" +conn.GetFieldValue("MULAI_BM_YY");

				lbl_LOHB_FASKREDIT.Text = DDL_FACKREDIT.SelectedIndex == 0 ? "-" : DDL_FACKREDIT.SelectedItem.Text;
				lbl_PUHB_FASKREDIT.Text = DDL_FACKREDIT.SelectedIndex == 0 ? "-" : DDL_FACKREDIT.SelectedItem.Text;
				lbl_SMHB_FASKREDIT.Text = DDL_FACKREDIT.SelectedIndex == 0 ? "-" : DDL_FACKREDIT.SelectedItem.Text;
				lbl_MIHB_FASKREDIT.Text = DDL_FACKREDIT.SelectedIndex == 0 ? "-" : DDL_FACKREDIT.SelectedItem.Text;

				lbl_LOHB_LIMITKREDIT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("LMT_CREDIT_CURR"));
				lbl_PUHB_LIMITKREDIT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("LMT_CREDIT_CURR"));
				lbl_SMHB_LIMITKREDIT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("LMT_CREDIT_CURR"));
				lbl_MIHB_LIMITKREDIT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("LMT_CREDIT_CURR"));

				//==============================================================================
				// Applicant
				lbl_LOAP_KOLPERSBL.Text = DDL_APP_BI_COLL_CURR.SelectedIndex == 0 ? "-" : DDL_APP_BI_COLL_CURR.SelectedItem.Text;
				lbl_PUAP_KOLPERSBL.Text = DDL_APP_BI_COLL_CURR.SelectedIndex == 0 ? "-" : DDL_APP_BI_COLL_CURR.SelectedItem.Text;
				lbl_SMAP_KOLPERSBL.Text = DDL_APP_BI_COLL_CURR.SelectedIndex == 0 ? "-" : DDL_APP_BI_COLL_CURR.SelectedItem.Text;
				lbl_MIAP_KOLPERSBL.Text = DDL_APP_BI_COLL_CURR.SelectedIndex == 0 ? "-" : DDL_APP_BI_COLL_CURR.SelectedItem.Text;

				lbl_LOAP_KOLPERSBM.Text = DDL_APP_BM_COLL_CURR.SelectedIndex == 0 ? "-" : DDL_APP_BM_COLL_CURR.SelectedItem.Text;
				lbl_PUAP_KOLPERSBM.Text = DDL_APP_BM_COLL_CURR.SelectedIndex == 0 ? "-" : DDL_APP_BM_COLL_CURR.SelectedItem.Text;
				lbl_SMAP_KOLPERSBM.Text = DDL_APP_BM_COLL_CURR.SelectedIndex == 0 ? "-" : DDL_APP_BM_COLL_CURR.SelectedItem.Text;
				lbl_MIAP_KOLPERSBM.Text = DDL_APP_BM_COLL_CURR.SelectedIndex == 0 ? "-" : DDL_APP_BM_COLL_CURR.SelectedItem.Text;

				lbl_LOAP_KOLBURUK.Text = DDL_BUSINESS_BM_COLL_W12.SelectedIndex == 0 ? "-" : DDL_BUSINESS_BM_COLL_W12.SelectedItem.Text;
				lbl_PUAP_KOLBURUK.Text = DDL_BUSINESS_BM_COLL_W12.SelectedIndex == 0 ? "-" : DDL_BUSINESS_BM_COLL_W12.SelectedItem.Text;
				lbl_SMAP_KOLBURUK.Text = DDL_BUSINESS_BM_COLL_W12.SelectedIndex == 0 ? "-" : DDL_BUSINESS_BM_COLL_W12.SelectedItem.Text;
				lbl_MIAP_KOLBURUK.Text = DDL_BUSINESS_BM_COLL_W12.SelectedIndex == 0 ? "-" : DDL_BUSINESS_BM_COLL_W12.SelectedItem.Text;

				lbl_LOAP_KOLPERS_2A.Text = conn.GetFieldValue("NUM_APP_COLL_12_2A");
				lbl_PUAP_KOLPERS_2A.Text = conn.GetFieldValue("NUM_APP_COLL_12_2A");
				lbl_SMAP_KOLPERS_2A.Text = conn.GetFieldValue("NUM_APP_COLL_12_2A");
				lbl_MIAP_KOLPERS_2A.Text = conn.GetFieldValue("NUM_APP_COLL_12_2A");

				lbl_LOAP_KOLPERS_2B.Text = conn.GetFieldValue("NUM_APP_COLL_12_2B");
				lbl_PUAP_KOLPERS_2B.Text = conn.GetFieldValue("NUM_APP_COLL_12_2B");
				lbl_SMAP_KOLPERS_2B.Text = conn.GetFieldValue("NUM_APP_COLL_12_2B");
				lbl_MIAP_KOLPERS_2B.Text = conn.GetFieldValue("NUM_APP_COLL_12_2B");

				lbl_LOAP_KOLPERS_2C.Text = conn.GetFieldValue("NUM_APP_COLL_12_2C");
				lbl_PUAP_KOLPERS_2C.Text = conn.GetFieldValue("NUM_APP_COLL_12_2C");
				lbl_SMAP_KOLPERS_2C.Text = conn.GetFieldValue("NUM_APP_COLL_12_2C");
				lbl_MIAP_KOLPERS_2C.Text = conn.GetFieldValue("NUM_APP_COLL_12_2C");

				lbl_LOAP_KOLPERS_3.Text = conn.GetFieldValue("NUM_APP_COLL_12_3PLUS");
				lbl_PUAP_KOLPERS_3.Text = conn.GetFieldValue("NUM_APP_COLL_12_3PLUS");
				lbl_SMAP_KOLPERS_3.Text = conn.GetFieldValue("NUM_APP_COLL_12_3PLUS");
				lbl_MIAP_KOLPERS_3.Text = conn.GetFieldValue("NUM_APP_COLL_12_3PLUS");
				
				lbl_LOAP_DHITAMBM.Text = conn.GetFieldValue("PERUSH_BLBM_CURR") == "N" ? "Tidak" : conn.GetFieldValue("PERUSH_BLBM_CURR") == "Y" ? "Ya" : "-";
				lbl_PUAP_DHITAMBM.Text = conn.GetFieldValue("PERUSH_BLBM_CURR") == "N" ? "Tidak" : conn.GetFieldValue("PERUSH_BLBM_CURR") == "Y" ? "Ya" : "-";
				lbl_SMAP_DHITAMBM.Text = conn.GetFieldValue("PERUSH_BLBM_CURR") == "N" ? "Tidak" : conn.GetFieldValue("PERUSH_BLBM_CURR") == "Y" ? "Ya" : "-";
				lbl_MIAP_DHITAMBM.Text = conn.GetFieldValue("PERUSH_BLBM_CURR") == "N" ? "Tidak" : conn.GetFieldValue("PERUSH_BLBM_CURR") == "Y" ? "Ya" : "-";

				lbl_LOAP_DHITAMBI.Text = conn.GetFieldValue("PERUSH_BLBI_CURR") == "N" ? "Tidak" : conn.GetFieldValue("PERUSH_BLBI_CURR") == "Y" ? "Ya" : "-";
				lbl_PUAP_DHITAMBI.Text = conn.GetFieldValue("PERUSH_BLBI_CURR") == "N" ? "Tidak" : conn.GetFieldValue("PERUSH_BLBI_CURR") == "Y" ? "Ya" : "-";
				lbl_SMAP_DHITAMBI.Text = conn.GetFieldValue("PERUSH_BLBI_CURR") == "N" ? "Tidak" : conn.GetFieldValue("PERUSH_BLBI_CURR") == "Y" ? "Ya" : "-";
				lbl_MIAP_DHITAMBI.Text = conn.GetFieldValue("PERUSH_BLBI_CURR") == "N" ? "Tidak" : conn.GetFieldValue("PERUSH_BLBI_CURR") == "Y" ? "Ya" : "-";

				lbl_LOAP_WACTHLIST.Text = conn.GetFieldValue("WATCH_LIST") == "N" ? "Tidak" : conn.GetFieldValue("WATCH_LIST") == "Y" ? "Ya" : "-";
				lbl_PUAP_WACTHLIST.Text = conn.GetFieldValue("WATCH_LIST") == "N" ? "Tidak" : conn.GetFieldValue("WATCH_LIST") == "Y" ? "Ya" : "-";
				lbl_SMAP_WACTHLIST.Text = conn.GetFieldValue("WATCH_LIST") == "N" ? "Tidak" : conn.GetFieldValue("WATCH_LIST") == "Y" ? "Ya" : "-";
				lbl_MIAP_WACTHLIST.Text = conn.GetFieldValue("WATCH_LIST") == "N" ? "Tidak" : conn.GetFieldValue("WATCH_LIST") == "Y" ? "Ya" : "-";

				//==============================================================================
				// Pemilik
				lbl_LOPM_KOLBM.Text = DDL_KEY_BM_COLL.SelectedIndex == 0 ? "-" : DDL_KEY_BM_COLL.SelectedItem.Text;
				lbl_PUPM_KOLBM.Text = DDL_KEY_BM_COLL.SelectedIndex == 0 ? "-" : DDL_KEY_BM_COLL.SelectedItem.Text;
				lbl_SMPM_KOLBM.Text = DDL_KEY_BM_COLL.SelectedIndex == 0 ? "-" : DDL_KEY_BM_COLL.SelectedItem.Text;
				lbl_MIPM_KOLBM.Text = DDL_KEY_BM_COLL.SelectedIndex == 0 ? "-" : DDL_KEY_BM_COLL.SelectedItem.Text;

				lbl_LOPM_FREKKOL_2C.Text = conn.GetFieldValue("KEY_BM_COLL_2C");
				lbl_PUPM_FREKKOL_2C.Text = conn.GetFieldValue("KEY_BM_COLL_2C");
				lbl_SMPM_FREKKOL_2C.Text = conn.GetFieldValue("KEY_BM_COLL_2C");
				lbl_MIPM_FREKKOL_2C.Text = conn.GetFieldValue("KEY_BM_COLL_2C");

				lbl_LOPM_DHITAMBM.Text = conn.GetFieldValue("KEY_BM_BL") == "N" ? "Tidak" : conn.GetFieldValue("KEY_BM_BL") == "Y" ? "Ya" : "-";
				lbl_PUPM_DHITAMBM.Text = conn.GetFieldValue("KEY_BM_BL") == "N" ? "Tidak" : conn.GetFieldValue("KEY_BM_BL") == "Y" ? "Ya" : "-";
				lbl_SMPM_DHITAMBM.Text = conn.GetFieldValue("KEY_BM_BL") == "N" ? "Tidak" : conn.GetFieldValue("KEY_BM_BL") == "Y" ? "Ya" : "-";
				lbl_MIPM_DHITAMBM.Text = conn.GetFieldValue("KEY_BM_BL") == "N" ? "Tidak" : conn.GetFieldValue("KEY_BM_BL") == "Y" ? "Ya" : "-";

				lbl_LOPM_DHITAMBI.Text = conn.GetFieldValue("KEY_BI_BM") == "N" ? "Tidak" : conn.GetFieldValue("KEY_BI_BM") == "Y" ? "Ya" : "-";
				lbl_PUPM_DHITAMBI.Text = conn.GetFieldValue("KEY_BI_BM") == "N" ? "Tidak" : conn.GetFieldValue("KEY_BI_BM") == "Y" ? "Ya" : "-";
				lbl_SMPM_DHITAMBI.Text = conn.GetFieldValue("KEY_BI_BM") == "N" ? "Tidak" : conn.GetFieldValue("KEY_BI_BM") == "Y" ? "Ya" : "-";
				lbl_MIPM_DHITAMBI.Text = conn.GetFieldValue("KEY_BI_BM") == "N" ? "Tidak" : conn.GetFieldValue("KEY_BI_BM") == "Y" ? "Ya" : "-";

				lbl_LOPM_KOLBL.Text = DDL_KEY_BI_COLL_LVL.SelectedIndex == 0 ? "-" : DDL_KEY_BI_COLL_LVL.SelectedItem.Text;
				lbl_PUPM_KOLBL.Text = DDL_KEY_BI_COLL_LVL.SelectedIndex == 0 ? "-" : DDL_KEY_BI_COLL_LVL.SelectedItem.Text;
				lbl_SMPM_KOLBL.Text = DDL_KEY_BI_COLL_LVL.SelectedIndex == 0 ? "-" : DDL_KEY_BI_COLL_LVL.SelectedItem.Text;
				lbl_MIPM_KOLBL.Text = DDL_KEY_BI_COLL_LVL.SelectedIndex == 0 ? "-" : DDL_KEY_BI_COLL_LVL.SelectedItem.Text;

				//==============================================================================
				// Key Person
				lbl_LOKP_KOLBM.Text = DDL_MGM_BM_COLL_CURR.SelectedIndex == 0 ? "-" : DDL_MGM_BM_COLL_CURR.SelectedItem.Text;
				lbl_PUKP_KOLBM.Text = DDL_MGM_BM_COLL_CURR.SelectedIndex == 0 ? "-" : DDL_MGM_BM_COLL_CURR.SelectedItem.Text;
				lbl_SMKP_KOLBM.Text = DDL_MGM_BM_COLL_CURR.SelectedIndex == 0 ? "-" : DDL_MGM_BM_COLL_CURR.SelectedItem.Text;
				lbl_MIKP_KOLBM.Text = DDL_MGM_BM_COLL_CURR.SelectedIndex == 0 ? "-" : DDL_MGM_BM_COLL_CURR.SelectedItem.Text;

				lbl_LOKP_FREKKOL_2C.Text = conn.GetFieldValue("MGM_BM_COLL_2C");
				lbl_PUKP_FREKKOL_2C.Text = conn.GetFieldValue("MGM_BM_COLL_2C");
				lbl_SMKP_FREKKOL_2C.Text = conn.GetFieldValue("MGM_BM_COLL_2C");
				lbl_MIKP_FREKKOL_2C.Text = conn.GetFieldValue("MGM_BM_COLL_2C");

				lbl_LOKP_DHITAMBI.Text = conn.GetFieldValue("MGM_BLBI") == "N" ? "Tidak" : conn.GetFieldValue("MGM_BLBI") == "Y" ? "Ya" : "-";
				lbl_PUKP_DHITAMBI.Text = conn.GetFieldValue("MGM_BLBI") == "N" ? "Tidak" : conn.GetFieldValue("MGM_BLBI") == "Y" ? "Ya" : "-";
				lbl_SMKP_DHITAMBI.Text = conn.GetFieldValue("MGM_BLBI") == "N" ? "Tidak" : conn.GetFieldValue("MGM_BLBI") == "Y" ? "Ya" : "-";
				lbl_MIKP_DHITAMBI.Text = conn.GetFieldValue("MGM_BLBI") == "N" ? "Tidak" : conn.GetFieldValue("MGM_BLBI") == "Y" ? "Ya" : "-";

				lbl_LOKP_DHITAMBL.Text = DDL_MGM_BI_COLL_LVL.SelectedIndex == 0 ? "-" : DDL_MGM_BI_COLL_LVL.SelectedItem.Text;
				lbl_PUKP_DHITAMBL.Text = DDL_MGM_BI_COLL_LVL.SelectedIndex == 0 ? "-" : DDL_MGM_BI_COLL_LVL.SelectedItem.Text;
				lbl_SMKP_DHITAMBL.Text = DDL_MGM_BI_COLL_LVL.SelectedIndex == 0 ? "-" : DDL_MGM_BI_COLL_LVL.SelectedItem.Text;
				lbl_MIKP_DHITAMBL.Text = DDL_MGM_BI_COLL_LVL.SelectedIndex == 0 ? "-" : DDL_MGM_BI_COLL_LVL.SelectedItem.Text;

				lbl_LOKP_DHITAMBM.Text = conn.GetFieldValue("MGM_BLBM") == "N" ? "Tidak" : conn.GetFieldValue("MGM_BLBM") == "Y" ? "Ya" : "-";
				lbl_PUKP_DHITAMBM.Text = conn.GetFieldValue("MGM_BLBM") == "N" ? "Tidak" : conn.GetFieldValue("MGM_BLBM") == "Y" ? "Ya" : "-";
				lbl_SMKP_DHITAMBM.Text = conn.GetFieldValue("MGM_BLBM") == "N" ? "Tidak" : conn.GetFieldValue("MGM_BLBM") == "Y" ? "Ya" : "-";
				lbl_MIKP_DHITAMBM.Text = conn.GetFieldValue("MGM_BLBM") == "N" ? "Tidak" : conn.GetFieldValue("MGM_BLBM") == "Y" ? "Ya" : "-";
//			}

			////////////////////////////////////////////////////////////////////////////////////////////////////
			/// info umum
			///
//			str="select * from SCORING_INFOUMUM_HISTORY where ap_regno='"+Request.QueryString["regno"]+"'";
//			conn.QueryString=str;
//			conn.ExecuteQuery();
//			if( conn.GetRowCount() > 0 )
//			{
				try {DDL_JNSPERMOHONAN.SelectedValue = conn.GetFieldValue("JENIS_PERMOHONAN");} 
				catch {}
				try {DDL_JNSKREDIT.SelectedValue = conn.GetFieldValue("JENIS_KREDIT");} 
				catch {}
				try {DDL_SKEMAKREDIT.SelectedValue = conn.GetFieldValue("SKEMA_KREDIT");} 
				catch {}
				try {DDL_PENDAKHIR.SelectedValue = conn.GetFieldValue("PENDIDIKAN_TERAKHIR");}
				catch {}
				try {DDL_STATUSKAWIN.SelectedValue = conn.GetFieldValue("STATUS_KAWIN");} 
				catch {}
				try {DDL_JNSPERUSH.SelectedValue = conn.GetFieldValue("JNS_USAHA");} 
				catch {}				
				try {DDL_EXISTING_FAC.SelectedValue = conn.GetFieldValue("ML_EXFAS");} 
				catch {}

				//########################################################################################

				//==============================================================================
				// Header
				lbl_HD_JNSMOHON.Text = DDL_JNSPERMOHONAN.SelectedIndex == 0 ? "-" : DDL_JNSPERMOHONAN.SelectedItem.Text;
				lbl_HD_JNSKREDIT.Text = DDL_JNSKREDIT.SelectedIndex == 0 ? "-" : DDL_JNSKREDIT.SelectedItem.Text;
				lbl_HD_CREDITSCM.Text = DDL_SKEMAKREDIT.SelectedIndex == 0 ? "-" : DDL_SKEMAKREDIT.SelectedItem.Text;
				lbl_HD_TOTEXPOSURE.Text = tool.MoneyFormat(conn.GetFieldValue("JML_KREDIT"));
				lbl_HD_REQAMMT.Text = tool.MoneyFormat(conn.GetFieldValue("REQUESTED_AMOUNT"));
				//lbl_HD_BIDUSAHA.Text;

				//==============================================================================
				// Informasi Key Person
				lbl_LOIK_PEMOHON.Text = conn.GetFieldValue("NAMA_PEMOHON");
				lbl_PUIK_PEMOHON.Text = conn.GetFieldValue("NAMA_PEMOHON");
				lbl_SMIK_PEMOHON.Text = conn.GetFieldValue("NAMA_PEMOHON");
				lbl_MIIK_PEMOHON.Text = conn.GetFieldValue("NAMA_PEMOHON");

				lbl_LOIK_TGLLAHIR.Text = conn.GetFieldValue("TGL_LAHIR");
				lbl_PUIK_TGLLAHIR.Text = conn.GetFieldValue("TGL_LAHIR");
				lbl_SMIK_TGLLAHIR.Text = conn.GetFieldValue("TGL_LAHIR");
				lbl_MIIK_TGLLAHIR.Text = conn.GetFieldValue("TGL_LAHIR");
				
				lbl_LOIK_JENKEL.Text = conn.GetFieldValue("JENIS_KELAMIN") == "L" ? "Laki-laki" : conn.GetFieldValue("JENIS_KELAMIN") == "P" ? "Perempuan" : "-";
				lbl_PUIK_JENKEL.Text = conn.GetFieldValue("JENIS_KELAMIN") == "L" ? "Laki-laki" : conn.GetFieldValue("JENIS_KELAMIN") == "P" ? "Perempuan" : "-";
				lbl_SMIK_JENKEL.Text = conn.GetFieldValue("JENIS_KELAMIN") == "L" ? "Laki-laki" : conn.GetFieldValue("JENIS_KELAMIN") == "P" ? "Perempuan" : "-";
				lbl_MIIK_JENKEL.Text = conn.GetFieldValue("JENIS_KELAMIN") == "L" ? "Laki-laki" : conn.GetFieldValue("JENIS_KELAMIN") == "P" ? "Perempuan" : "-";
			
				lbl_LOIK_PENDIDIKAN.Text = DDL_PENDAKHIR.SelectedIndex == 0 ? "-" : DDL_PENDAKHIR.SelectedItem.Text;
				lbl_PUIK_PENDIDIKAN.Text = DDL_PENDAKHIR.SelectedIndex == 0 ? "-" : DDL_PENDAKHIR.SelectedItem.Text;
				lbl_SMIK_PENDIDIKAN.Text = DDL_PENDAKHIR.SelectedIndex == 0 ? "-" : DDL_PENDAKHIR.SelectedItem.Text;
				lbl_MIIK_PENDIDIKAN.Text = DDL_PENDAKHIR.SelectedIndex == 0 ? "-" : DDL_PENDAKHIR.SelectedItem.Text;

				lbl_LOIK_KAWIN.Text = DDL_STATUSKAWIN.SelectedIndex == 0 ? "-" : DDL_STATUSKAWIN.SelectedItem.Text;
				lbl_PUIK_KAWIN.Text = DDL_STATUSKAWIN.SelectedIndex == 0 ? "-" : DDL_STATUSKAWIN.SelectedItem.Text;
				lbl_SMIK_KAWIN.Text = DDL_STATUSKAWIN.SelectedIndex == 0 ? "-" : DDL_STATUSKAWIN.SelectedItem.Text;
				lbl_MIIK_KAWIN.Text = DDL_STATUSKAWIN.SelectedIndex == 0 ? "-" : DDL_STATUSKAWIN.SelectedItem.Text;

				lbl_LOIK_ANAK.Text = conn.GetFieldValue("JML_ANAK");
				lbl_PUIK_ANAK.Text = conn.GetFieldValue("JML_ANAK");
				lbl_SMIK_ANAK.Text = conn.GetFieldValue("JML_ANAK");
				lbl_MIIK_ANAK.Text = conn.GetFieldValue("JML_ANAK");

				lbl_LOIK_TGLMENETAP.Text = conn.GetFieldValue("MULAI_MENETAP");
				lbl_PUIK_TGLMENETAP.Text = conn.GetFieldValue("MULAI_MENETAP");
				lbl_SMIK_TGLMENETAP.Text = conn.GetFieldValue("MULAI_MENETAP");
				lbl_MIIK_TGLMENETAP.Text = conn.GetFieldValue("MULAI_MENETAP");
				
				lbl_LOIK_ISRUMAH.Text = conn.GetFieldValue("IUM_HOMEOWNEDCUST") == "Y" ? "Ya" : conn.GetFieldValue("IUM_HOMEOWNEDCUST") == "N" ? "Tidak" : "-";
				lbl_PUIK_ISRUMAH.Text = conn.GetFieldValue("IUM_HOMEOWNEDCUST") == "Y" ? "Ya" : conn.GetFieldValue("IUM_HOMEOWNEDCUST") == "N" ? "Tidak" : "-";
				lbl_SMIK_ISRUMAH.Text = conn.GetFieldValue("IUM_HOMEOWNEDCUST") == "Y" ? "Ya" : conn.GetFieldValue("IUM_HOMEOWNEDCUST") == "N" ? "Tidak" : "-";
				lbl_MIIK_ISRUMAH.Text = conn.GetFieldValue("IUM_HOMEOWNEDCUST") == "Y" ? "Ya" : conn.GetFieldValue("IUM_HOMEOWNEDCUST") == "N" ? "Tidak" : "-";

				//ahmad
				lbl_LOIK_UMUR.Text = conn.GetFieldValue("Umur");
				lbl_PUIK_UMUR.Text = conn.GetFieldValue("Umur");
				lbl_SMIK_UMUR.Text = conn.GetFieldValue("Umur");
				lbl_MIIK_UMUR.Text = conn.GetFieldValue("Umur");

				lbl_LOIK_SAHAM.Text = conn.GetFieldValue("PROSEN_SAHAM");
				lbl_PUIK_SAHAM.Text = conn.GetFieldValue("PROSEN_SAHAM");
				lbl_SMIK_SAHAM.Text = conn.GetFieldValue("PROSEN_SAHAM");
				lbl_MIIK_SAHAM.Text = conn.GetFieldValue("PROSEN_SAHAM");

				//==============================================================================
				// Informasi Usaha
				lbl_LOIU_JNSUSAHA.Text = DDL_JNSPERUSH.SelectedIndex == 0 ? "-" : DDL_JNSPERUSH.SelectedItem.Text;
				lbl_PUIU_JNSUSAHA.Text = DDL_JNSPERUSH.SelectedIndex == 0 ? "-" : DDL_JNSPERUSH.SelectedItem.Text;
				lbl_SMIU_JNSUSAHA.Text = DDL_JNSPERUSH.SelectedIndex == 0 ? "-" : DDL_JNSPERUSH.SelectedItem.Text;
				lbl_MIIU_JNSUSAHA.Text = DDL_JNSPERUSH.SelectedIndex == 0 ? "-" : DDL_JNSPERUSH.SelectedItem.Text;

				lbl_LOIU_JMLPEG.Text = conn.GetFieldValue("JML_PEGAWAI");
				lbl_PUIU_JMLPEG.Text = conn.GetFieldValue("JML_PEGAWAI");
				lbl_SMIU_JMLPEG.Text = conn.GetFieldValue("JML_PEGAWAI");
				lbl_MIIU_JMLPEG.Text = conn.GetFieldValue("JML_PEGAWAI");

				lbl_LOIU_MULAIUSAHA.Text = conn.GetFieldValue("MULAI_USAHA");
				lbl_PUIU_MULAIUSAHA.Text = conn.GetFieldValue("MULAI_USAHA");
				lbl_SMIU_MULAIUSAHA.Text = conn.GetFieldValue("MULAI_USAHA");
				lbl_MIIU_MULAIUSAHA.Text = conn.GetFieldValue("MULAI_USAHA");

				//ahmad
				lbl_LOIU_LAMAUSAHA.Text = conn.GetFieldValue("LamaMilikUsaha");
				lbl_PUIU_LAMAUSAHA.Text = conn.GetFieldValue("LamaMilikUsaha");
				lbl_SMIU_LAMAUSAHA.Text = conn.GetFieldValue("LamaMilikUsaha");
				lbl_MIIU_LAMAUSAHA.Text = conn.GetFieldValue("LamaMilikUsaha");
				
				lbl_LOIU_WCOBANK.Text = tool.MoneyFormat(conn.GetFieldValue("IU_EXWORKCAP"));
				lbl_PUIU_WCOBANK.Text = tool.MoneyFormat(conn.GetFieldValue("IU_EXWORKCAP"));
				lbl_SMIU_WCOBANK.Text = tool.MoneyFormat(conn.GetFieldValue("IU_EXWORKCAP"));
				lbl_MIIU_WCOBANK.Text = tool.MoneyFormat(conn.GetFieldValue("IU_EXWORKCAP"));

				lbl_LOHB_LEGAL.Text = conn.GetFieldValue("LEGAL_LAWSUIT") == "N" ? "Tidak" : conn.GetFieldValue("LEGAL_LAWSUIT") == "Y" ? "Ya" : "-";
				lbl_PUHB_LEGAL.Text = conn.GetFieldValue("LEGAL_LAWSUIT") == "N" ? "Tidak" : conn.GetFieldValue("LEGAL_LAWSUIT") == "Y" ? "Ya" : "-";
				lbl_SMHB_LEGAL.Text = conn.GetFieldValue("LEGAL_LAWSUIT") == "N" ? "Tidak" : conn.GetFieldValue("LEGAL_LAWSUIT") == "Y" ? "Ya" : "-";
				lbl_MIHB_LEGAL.Text = conn.GetFieldValue("LEGAL_LAWSUIT") == "N" ? "Tidak" : conn.GetFieldValue("LEGAL_LAWSUIT") == "Y" ? "Ya" : "-";

				//==============================================================================
				// Contractor Loan
				lbl_SMCL_1APROJCOST.Text = tool.MoneyFormat(conn.GetFieldValue("ACCEPT_PROJ_COST"));
				lbl_MICL_1APROJCOST.Text = tool.MoneyFormat(conn.GetFieldValue("ACCEPT_PROJ_COST"));

				lbl_SMCL_2PROJCOST.Text = tool.MoneyFormat(conn.GetFieldValue("PROJ_COST"));
				lbl_SMCL_2NOTERMYN.Text = conn.GetFieldValue("NUM_TERMYN");
				lbl_SMCL_3TOTVALPROJ.Text = tool.MoneyFormat(conn.GetFieldValue("PLAFOND_TOT_VAL_PROJECTS"));
				lbl_SMCL_3PRCPROJCOST.Text = tool.MoneyFormat(conn.GetFieldValue("PLAFOND_PRSN_PROJ_COST"));
				lbl_SMCL_3DPAMOUNT.Text = tool.MoneyFormat(conn.GetFieldValue("PLAFOND_DP"));
				lbl_SMCL_3WCPLAFONDBM.Text = tool.MoneyFormat(conn.GetFieldValue("CL_EXIST_WC_BM"));
				lbl_SMCL_3WCPLAFONDBL.Text = tool.MoneyFormat(conn.GetFieldValue("CL_EXIST_WC_OBANK"));

//			}

			////////////////////////////////////////////////////////////////////////////////////////////////////
			/// neraca - small
			///
//			str="select * from ca_neraca_small where ap_regno = '" + Request.QueryString["regno"] + "'";
//			conn.QueryString=str;
//			conn.ExecuteQuery();
//			if( conn.GetRowCount() > 0 )
//			{

			lbl_SMNE_PERTGL.Text = conn.GetFieldValue("POSISI_TGL_NE");

				//==============================================================================
				// aktiva
				lbl_SMNE_KASBANK.Text = tool.MoneyFormat(conn.GetFieldValue("AKTV_KASBANK"));
				lbl_SMNE_PIUTANGD.Text = tool.MoneyFormat(conn.GetFieldValue("AKTV_PIUDGN"));
				lbl_SMNE_PERSEDIAAN.Text = tool.MoneyFormat(conn.GetFieldValue("AKTV_PERSEDIAAN"));
				lbl_SMNE_AKTLCRLAIN.Text = tool.MoneyFormat(conn.GetFieldValue("AKTV_LCRLAIN"));
				lbl_SMNE_TOTAKTLCR.Text = tool.MoneyFormat(conn.GetFieldValue("AKTV_TTLAKTLCR"));

				lbl_SMNE_TANAHB.Text = tool.MoneyFormat(conn.GetFieldValue("AKTV_TNHBGN"));
				lbl_SMNE_MESINP.Text = tool.MoneyFormat(conn.GetFieldValue("AKTV_MSNALAT"));
				lbl_SMNE_INVENTK.Text = tool.MoneyFormat(conn.GetFieldValue("AKTV_INVKNDRN"));
				lbl_SMNE_AKTTTPLAIN.Text = tool.MoneyFormat(conn.GetFieldValue("AKTV_TTPLAIN"));
				lbl_SMNE_AKUMSUSUT.Text = tool.MoneyFormat(conn.GetFieldValue("AKTV_AKUMSUSUT"));
				lbl_SMNE_TOTAKTTTP.Text = tool.MoneyFormat(conn.GetFieldValue("AKTV_NETAKTVTTP"));

				lbl_SMNE_BEBAN.Text = tool.MoneyFormat(conn.GetFieldValue("AKTV_BIAYATANGGUH"));
				lbl_SMNE_AKUMAMORT.Text = tool.MoneyFormat(conn.GetFieldValue("AKTV_AKUMAMOR"));
				lbl_SMNE_AKTLAIN.Text = tool.MoneyFormat(conn.GetFieldValue("AKTV_AKTVLAIN"));
				lbl_SMNE_TOTAKTLAIN.Text = tool.MoneyFormat(conn.GetFieldValue("AKTV_TTLAKTVLAIN"));
				lbl_SMNE_TOTAKT.Text = tool.MoneyFormat(conn.GetFieldValue("AKTV_TTLAKTV"));

				//==============================================================================
				// pasiva
				lbl_SMNE_HUTDAG.Text = tool.MoneyFormat(conn.GetFieldValue("PASV_HTDG"));
				lbl_SMNE_HUTBANK.Text = tool.MoneyFormat(conn.GetFieldValue("PASV_HTBANK"));
				lbl_SMNE_BAGIANKI.Text = tool.MoneyFormat(conn.GetFieldValue("PASV_KIJTHTEMPO"));
				lbl_SMNE_HUTLCRLAIN.Text = tool.MoneyFormat(conn.GetFieldValue("PASV_HTLNCR"));
				lbl_SMNE_TOTHUTLCR.Text = tool.MoneyFormat(conn.GetFieldValue("PASV_TTLHTLNCR"));

				lbl_SMNE_HUTJP.Text = tool.MoneyFormat(conn.GetFieldValue("PASV_HTJKPJG"));
				lbl_SMNE_HUTSAHAM.Text = tool.MoneyFormat(conn.GetFieldValue("PASV_HTPMGANGSHM"));
				lbl_SMNE_HUTJPLAIN.Text = tool.MoneyFormat(conn.GetFieldValue("PASV_JKPJGLAIN"));
				lbl_SMNE_TOTHUTJP.Text = tool.MoneyFormat(conn.GetFieldValue("PASV_TTLHTJKPJG"));
				lbl_SMNE_TOTHUT.Text = tool.MoneyFormat(conn.GetFieldValue("PASV_TTLHT"));

				lbl_SMNE_MODALD.Text = tool.MoneyFormat(conn.GetFieldValue("PASV_MODALSTR"));
				lbl_SMNE_LR.Text = tool.MoneyFormat(conn.GetFieldValue("PASV_LBRG"));
				lbl_SMNE_MODAL.Text = tool.MoneyFormat(conn.GetFieldValue("PASV_TTLMODAL"));

				lbl_SMNE_TOTPAS.Text = tool.MoneyFormat(conn.GetFieldValue("PASV_TTLPASIVA"));
//			}

			////////////////////////////////////////////////////////////////////////////////////////////////////
			/// laba rugi - small
			///
//			str="select * from ca_labarugi_small where ap_regno = '" + Request.QueryString["regno"] + "'";			conn.QueryString=str;
//			conn.ExecuteQuery();
//			if( conn.GetRowCount() > 0 )
//			{
				lbl_SMLR_PERTGL.Text = conn.GetFieldValue("POSISI_TGL_LR");

				lbl_SMLR_JUALTHN.Text = tool.MoneyFormat(conn.GetFieldValue("IS_PENJ"));
				lbl_SMLR_HPP.Text = tool.MoneyFormat(conn.GetFieldValue("IS_HPP"));
				lbl_SMLR_BUADM.Text = tool.MoneyFormat(conn.GetFieldValue("IS_ADMOPR"));
				lbl_SMLR_LABAOPR.Text = tool.MoneyFormat(conn.GetFieldValue("IS_LABAOPR"));
				lbl_SMLR_BBUNGA.Text = tool.MoneyFormat(conn.GetFieldValue("IS_BUNGA"));
				lbl_SMLR_BSUSUT.Text = tool.MoneyFormat(conn.GetFieldValue("IS_TTLSUSUT"));
				lbl_SMLR_BLAIN.Text = tool.MoneyFormat(conn.GetFieldValue("IS_BIAYa_LAIN"));
				lbl_SMLR_PDPTLAIN.Text = tool.MoneyFormat(conn.GetFieldValue("IS_PNDPTN"));
				lbl_SMLR_LABABPAJAK.Text = tool.MoneyFormat(conn.GetFieldValue("IS_LABA_SBLPJK"));
				lbl_SMLR_PAJAK.Text = tool.MoneyFormat(conn.GetFieldValue("IS_PJK"));
				lbl_SMLR_LABA.Text = tool.MoneyFormat(conn.GetFieldValue("IS_LABA_BRSH"));
//			}

			////////////////////////////////////////////////////////////////////////
			/// rasio - small
			/// 
//			str="select * from ca_ratio_small where ap_regno = '" + Request.QueryString["regno"] + "'";
//			conn.QueryString=str;
//			conn.ExecuteQuery();
//			if( conn.GetRowCount() > 0 )
//			{
				lbl_SMRA_PERTGL.Text = conn.GetFieldValue("POSISI_TGL_RA");

				lbl_SMRA_SALESWC.Text = tool.MoneyFormat(conn.GetFieldValue("SALES_TO_WK_CAPITAL"));
				lbl_SMRA_DEBTNW.Text = tool.MoneyFormat(conn.GetFieldValue("DEBT_TO_NETWORTH"));
				lbl_SMRA_CURRATIO.Text = tool.MoneyFormat(conn.GetFieldValue("CURRENT_RATIO"));
				lbl_SMRA_BUSDEBT.Text = tool.MoneyFormat(conn.GetFieldValue("BUSINESS_DEBT_SERVICE_RATIO"));
				lbl_SMRA_TRADECYC.Text = tool.MoneyFormat(conn.GetFieldValue("TRADE_CYCLE"));
				lbl_SMRA_AVGNETPROF.Text = tool.MoneyFormat(conn.GetFieldValue("AVERAGE_NETPROFIT"));
				lbl_SMRA_CASHV.Text = tool.MoneyFormat(conn.GetFieldValue("CASH_VELOCITY"));
				lbl_SMRA_DAYRECEIVE.Text = tool.MoneyFormat(conn.GetFieldValue("DAYS_RECEIVABLE"));
				lbl_SMRA_DAYINVENT.Text = tool.MoneyFormat(conn.GetFieldValue("DAYS_INVENTORY"));
				lbl_SMRA_DAYAP.Text = tool.MoneyFormat(conn.GetFieldValue("DAYS_ACCPAYABLE"));
				lbl_SMRA_NETWC.Text = tool.MoneyFormat(conn.GetFieldValue("NETWORKING_CAPITAL"));
				lbl_SMRA_TOTASSTO.Text = tool.MoneyFormat(conn.GetFieldValue("TTL_ASSET_TURN_OVER"));
//			}


			////////////////////////////////////////////////////////////////////////////////////////////////////
			/// neraca - middle
			///
//			str="select * from ca_neraca_middle where ap_regno = '" + Request.QueryString["regno"] + "'";
//			conn.QueryString=str;
//			conn.ExecuteQuery();
//			if( conn.GetRowCount() > 0 )
//			{
				lbl_MINE_PERTGL.Text = conn.GetFieldValue("BS_DATE_PERIODE");

				//==============================================================================
				// Assets
				lbl_MINE_CASHBANK.Text = tool.MoneyFormat(conn.GetFieldValue("BS_CASH_BANK"));
				lbl_MINE_MARKETSEC.Text = tool.MoneyFormat(conn.GetFieldValue("BS_MARKET_SECUR"));
				lbl_MINE_AR.Text = tool.MoneyFormat(conn.GetFieldValue("BS_AR"));
				lbl_MINE_ARAFF.Text = tool.MoneyFormat(conn.GetFieldValue("BS_AR_FRAFFIL"));
				lbl_MINE_INVENTORY.Text = tool.MoneyFormat(conn.GetFieldValue("BS_INVENTORY"));
				lbl_MINE_OTHERCASS.Text = tool.MoneyFormat(conn.GetFieldValue("BS_OTH_CURASST"));
				lbl_MINE_PREPAIDEX.Text = tool.MoneyFormat(conn.GetFieldValue("BS_PREPAID_EXP"));
				lbl_MINE_CURRASSET.Text = tool.MoneyFormat(conn.GetFieldValue("BS_CURRASST"));
				lbl_MINE_NETFIXASS.Text = tool.MoneyFormat(conn.GetFieldValue("BS_NETFIXASST"));
				lbl_MINE_INVESTMENT.Text = tool.MoneyFormat(conn.GetFieldValue("BS_INVESTMENT"));
				lbl_MINE_NETOTHER.Text = tool.MoneyFormat(conn.GetFieldValue("BS_NONCA"));
				lbl_MINE_NETINT.Text = tool.MoneyFormat(conn.GetFieldValue("BS_NI"));

				lbl_MINE_TOTNON.Text = tool.MoneyFormat(conn.GetFieldValue("BS_TTL_NONCA"));
				lbl_MINE_TOTASSET.Text = tool.MoneyFormat(conn.GetFieldValue("BS_TTL_ASST"));

				//==============================================================================
				// Liabilities
				lbl_MINE_DUEBANK.Text = tool.MoneyFormat(conn.GetFieldValue("BS_DBST"));
				lbl_MINE_AP.Text = tool.MoneyFormat(conn.GetFieldValue("BS_AP"));
				lbl_MINE_APAFF.Text = tool.MoneyFormat(conn.GetFieldValue("BS_AP_TOAFFL"));
				lbl_MINE_ACCRUAL.Text = tool.MoneyFormat(conn.GetFieldValue("BS_ACCRUALS"));
				lbl_MINE_TAXPAYABLE.Text = tool.MoneyFormat(conn.GetFieldValue("BS_TAXPAY"));
				lbl_MINE_OTHERCLIAB.Text = tool.MoneyFormat(conn.GetFieldValue("BS_OTH_CURLIAB"));
				lbl_MINE_CURRPORTION.Text = tool.MoneyFormat(conn.GetFieldValue("BS_CURR_PORTLTDEBT"));
				lbl_MINE_CURRLIAB.Text = tool.MoneyFormat(conn.GetFieldValue("BS_CURR_LIAB"));

				lbl_MINE_LTDEBT.Text = tool.MoneyFormat(conn.GetFieldValue("BS_LONGTERM_DEBT"));
				lbl_MINE_OTHERLIAB.Text = tool.MoneyFormat(conn.GetFieldValue("BS_OTH_LIAB"));
				lbl_MINE_LTLIAB.Text = tool.MoneyFormat(conn.GetFieldValue("BS_LONGTERM_LIAB"));
				lbl_MINE_TOTLIAB.Text = tool.MoneyFormat(conn.GetFieldValue("BS_TTL_LIAB"));

				lbl_MINE_COMSTOCK.Text = tool.MoneyFormat(conn.GetFieldValue("BS_CMN_STK"));
				lbl_MINE_SURPLUSR.Text = tool.MoneyFormat(conn.GetFieldValue("BS_SURP_RESRV"));
				lbl_MINE_RETEARN.Text = tool.MoneyFormat(conn.GetFieldValue("BS_RET_EARN"));

				lbl_MINE_TOTNETW.Text = tool.MoneyFormat(conn.GetFieldValue("BS_TTL_NETWORTH"));
				lbl_MINE_LIABNETW.Text = tool.MoneyFormat(conn.GetFieldValue("BS_LIAB_NETWORTH"));
//			}

			////////////////////////////////////////////////////////////////////////////////////////////////////
			/// laba rugi - middle
			///
//			str="select * from ca_labarugi_middle where ap_regno = '" + Request.QueryString["regno"] + "'";
//			conn.QueryString=str;
//			conn.ExecuteQuery();
//			if( conn.GetRowCount() > 0 )
//			{
				lbl_MIIS_PERTGL.Text = conn.GetFieldValue("IS_DATE_PERIODE");

				lbl_MIIS_SALECRE.Text = tool.MoneyFormat(conn.GetFieldValue("IS_SALES_ONCR"));
				lbl_MIIS_NETSALE.Text = tool.MoneyFormat(conn.GetFieldValue("IS_NET_SALES"));
				lbl_MIIS_COSTGOOD.Text = tool.MoneyFormat(conn.GetFieldValue("IS_COST_GS"));
				lbl_MIIS_PRCSALE_1.Text = tool.MoneyFormat(conn.GetFieldValue("IS_PROSEN1"));

				lbl_MIIS_GROSSM.Text = tool.MoneyFormat(conn.GetFieldValue("IS_GROSS_MARGIN"));
				lbl_MIIS_PRCSALE_2.Text = tool.MoneyFormat(conn.GetFieldValue("IS_PROSEN2"));

				lbl_MIIS_SELLING.Text = tool.MoneyFormat(conn.GetFieldValue("IS_SELLING_GENADM"));
				lbl_MIIS_PRCSALE_3.Text = tool.MoneyFormat(conn.GetFieldValue("IS_PROSEN3"));

				lbl_MIIS_OPREARN.Text = tool.MoneyFormat(conn.GetFieldValue("IS_OPR_EARN"));
				lbl_MIIS_PRCSALE_4.Text = tool.MoneyFormat(conn.GetFieldValue("IS_PROSEN4"));

				lbl_MIIS_DEPRECIATE.Text = tool.MoneyFormat(conn.GetFieldValue("IS_DEPRECIATE"));
				lbl_MIIS_AMORT_1.Text = tool.MoneyFormat(conn.GetFieldValue("IS_AMORTIZATION1"));
				lbl_MIIS_AMORT_2.Text = tool.MoneyFormat(conn.GetFieldValue("IS_AMORTIZATION2"));
				lbl_MIIS_OTHERINC.Text = tool.MoneyFormat(conn.GetFieldValue("IS_OTH_INCM_NET"));
				lbl_MIIS_EXORDITEM.Text = tool.MoneyFormat(conn.GetFieldValue("IS_EXTRAORD"));
				lbl_MIIS_EARNBTAX.Text = tool.MoneyFormat(conn.GetFieldValue("IS_EARN_BIT"));
				lbl_MIIS_INTEREST.Text = tool.MoneyFormat(conn.GetFieldValue("IS_INTRST_EXP"));
//			}

			////////////////////////////////////////////////////////////////////////////////////////////////////
			/// rasio - middle
			/// 
//			str="select * from ca_ratio_middle where ap_regno = '" + Request.QueryString["regno"] + "'";
//			conn.QueryString=str;
//			conn.ExecuteQuery();
//			if( conn.GetRowCount() > 0 )
//			{
				lbl_MIRA_PERTGL.Text = conn.GetFieldValue("DATE_PERIODE");

				lbl_MIRA_SALEGROW.Text = tool.MoneyFormat(conn.GetFieldValue("SALES_GROWTH_RATE"));
				lbl_MIRA_ROE.Text = tool.MoneyFormat(conn.GetFieldValue("ROE"));
				lbl_MIRA_ROA.Text = tool.MoneyFormat(conn.GetFieldValue("ROA"));
				lbl_MIRA_INTEREST.Text = tool.MoneyFormat(conn.GetFieldValue("INTEREST_AVEBANKDEBT"));
				lbl_MIRA_SALES.Text = tool.MoneyFormat(conn.GetFieldValue("SALES_AVEASSET"));
				lbl_MIRA_CURRATIO.Text = tool.MoneyFormat(conn.GetFieldValue("CURRENT_RATIO"));
				lbl_MIRA_QUICKASS.Text = tool.MoneyFormat(conn.GetFieldValue("QUICK_ASSET_RATIO"));
				lbl_MIRA_DRECEIVE.Text = tool.MoneyFormat(conn.GetFieldValue("DAYS_RECEIVABLE"));
				lbl_MIRA_DINVENT.Text = tool.MoneyFormat(conn.GetFieldValue("DAYS_INVENTORY"));
				lbl_MIRA_DAYPAY.Text = tool.MoneyFormat(conn.GetFieldValue("DAYS_PAYABLE"));
				lbl_MIRA_DAYTC.Text = tool.MoneyFormat(conn.GetFieldValue("DAYS_TC"));
				lbl_MIRA_DEBTEQ.Text = tool.MoneyFormat(conn.GetFieldValue("DEBT_EQUITY_RATIO"));
				lbl_MIRA_LTLEVER.Text = tool.MoneyFormat(conn.GetFieldValue("LONG_TERM_LVRG"));
				lbl_MIRA_TIMEINT.Text = tool.MoneyFormat(conn.GetFieldValue("EBITDA"));
				lbl_MIRA_DEBTSERV.Text = tool.MoneyFormat(conn.GetFieldValue("DEBT_SERV_COVERAGE"));
				lbl_MIRA_NETWORTH.Text = tool.MoneyFormat(conn.GetFieldValue("NET_WORTH"));
				lbl_MIRA_SALESWC.Text = tool.MoneyFormat(conn.GetFieldValue("SALES_TO_WK_CAPITAL"));
				lbl_MIRA_DEBTNW.Text = tool.MoneyFormat(conn.GetFieldValue("DEBT_TO_NETWORTH"));
				lbl_MIRA_BUSDEBT.Text = tool.MoneyFormat(conn.GetFieldValue("BUSINESS_DEBT_SERV_RATIO"));
//			}
		}

		/// <summary>
		/// Get result description of STW interface
		/// </summary>
		/// <param name="stw_type"></param>
		/// <param name="stw_code"></param>
		/// <returns></returns>
		private string getScoringResultDesc(string stw_type,string stw_code)
		{
			string scoringResultDesc="";

			Connection conn2 = new Connection(conn.connString);			
			conn2.QueryString="EXEC SP_SCORING_RESULT_DESC_GET '" + stw_type + "','" + stw_code + "'";
			conn2.ExecuteQuery();

			if (conn2.GetRowCount() > 0) 
			{
				scoringResultDesc= stw_code + " - " + conn2.GetFieldValue("STW_DESC");
			}

			conn2.ClearData();
			conn2.CloseConnection();
			return scoringResultDesc;
		}

		/*
		private string getScoreClass(string strCode)
		{
			string strRes = " ";
			if (strCode.Trim()=="R")
				strRes = "R - Red";
			else if (strCode.Trim()=="Y")
				strRes = "Y - Yellow";
			else if (strCode.Trim()=="G")
				strRes = "G - Green";
			else if (strCode.Trim()=="D")
				strRes = "D - Dark Green";
			return strRes;
		}

		private string getVisitIndicator(string strCode)
		{
			string strRes = " ";
			if (strCode.Trim()=="P")
				strRes = "P - Phone";
			else if (strCode.Trim()=="V")
				strRes = "V - Visit";
			return strRes;
		}

		private string getFinancialAnalisi(string strCode)
		{
			string strRes = " ";
			if (strCode.Trim()=="1")
				strRes = "1 - Pukk format";
			else if (strCode.Trim()=="2")
				strRes = "2 - Micro format";
			else if (strCode.Trim()=="3")
				strRes = "3 - Std SB low line format (<=100 Mill)";
			else if (strCode.Trim()=="4")
				strRes = "4 - Std SB 100-500 Mill";
			else if (strCode.Trim()=="5")
				strRes = "5 - Std SB >500 Mill";
			else if (strCode.Trim()=="6")
				strRes = "6 - MC new/exposure increase";
			else if (strCode.Trim()=="7")
				strRes = "7 - MC exposure extension";
			return strRes;
		}

		private string getManualReview(string strCode)
		{
			string strRes = " ";
			if (strCode.Trim()=="B")
				strRes = "B - Business Unit only";
			else if (strCode.Trim()=="R")
				strRes = "R - Risk and Business Unit";
			return strRes;
		}

		private string getOHD_SYS_DECISION(string strCode)
		{
			string strRes = " ";
			if (strCode.Trim()=="AC")
				strRes = "AC - Accept";
			else if (strCode.Trim()=="DL")
				strRes = "DL - Decline";
			else if (strCode.Trim()=="GZ")
				strRes = "GZ - Grayzone/Review";
			else 
				strRes = strCode;
			return strRes;
		}
		*/

		private void SetFormBYBussinesType()
		{
			string tipeBusiness="";
			conn.QueryString="exec SP_GETBUSINESSTYPE '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			tipeBusiness=conn.GetFieldValue("tipeKey");
			if ( tipeBusiness.Equals("MICRO_SCR") || tipeBusiness.Equals("LOWLINE_SCR"))
			{
				//==============================================================================
				// scoring result
				TBL_DT_MICRO_H.Visible = true;
				TBL_DT_MICRO.Visible = true;

				TBL_DT_PUKK_H.Visible = false;
				TBL_DT_PUKK.Visible = false;

				TBL_DT_SMALL_H.Visible = false;
				TBL_DT_SMALL.Visible = false;

				TBL_DT_MIDDLE_H.Visible = false;
				TBL_DT_MIDDLE.Visible = false;

				//==============================================================================
				// general information
				TBL_GI_MICRO_H.Visible = true;
				TBL_GI_MICRO.Visible = true;

				TBL_GI_PUKK_H.Visible = false;
				TBL_GI_PUKK.Visible = false;

				TBL_GI_SMALL_H.Visible = false;
				TBL_GI_SMALL.Visible = false;

				TBL_GI_MIDDLE_H.Visible = false;
				TBL_GI_MIDDLE.Visible = false;

				//==============================================================================
				// neraca
				TBL_NE_SMALL_H.Visible = true;
				TBL_NE_SMALL.Visible = true;

				TBL_NE_MIDDLE_H.Visible = false;
				TBL_NE_MIDDLE.Visible = false;

				//==============================================================================
				// laba rugi/income statement & rasio
				TBL_IR_SMALL_H.Visible = true;
				TBL_IR_SMALL.Visible = true;

				TBL_IR_MIDDLE_H.Visible = false;
				TBL_IR_MIDDLE.Visible = false;
			}
			else if (tipeBusiness.Equals("PUKK_SCR"))
			{
				//==============================================================================
				// scoring result
				TBL_DT_MICRO_H.Visible = false;
				TBL_DT_MICRO.Visible = false;

				TBL_DT_PUKK_H.Visible = true;
				TBL_DT_PUKK.Visible = true;

				TBL_DT_SMALL_H.Visible = false;
				TBL_DT_SMALL.Visible = false;

				TBL_DT_MIDDLE_H.Visible = false;
				TBL_DT_MIDDLE.Visible = false;

				//==============================================================================
				// general information
				TBL_GI_MICRO_H.Visible = false;
				TBL_GI_MICRO.Visible = false;

				TBL_GI_PUKK_H.Visible = true;
				TBL_GI_PUKK.Visible = true;

				TBL_GI_SMALL_H.Visible = false;
				TBL_GI_SMALL.Visible = false;

				TBL_GI_MIDDLE_H.Visible = false;
				TBL_GI_MIDDLE.Visible = false;

				//==============================================================================
				// neraca
				TBL_NE_SMALL_H.Visible = true;
				TBL_NE_SMALL.Visible = true;

				TBL_NE_MIDDLE_H.Visible = false;
				TBL_NE_MIDDLE.Visible = false;

				//==============================================================================
				// laba rugi/income statement & rasio
				TBL_IR_SMALL_H.Visible = true;
				TBL_IR_SMALL.Visible = true;

				TBL_IR_MIDDLE_H.Visible = false;
				TBL_IR_MIDDLE.Visible = false;
			}
			else if (tipeBusiness.Equals("SMALL_SCR"))
			{
				//==============================================================================
				// scoring result
				TBL_DT_MICRO_H.Visible = false;
				TBL_DT_MICRO.Visible = false;

				TBL_DT_PUKK_H.Visible = false;
				TBL_DT_PUKK.Visible = false;

				TBL_DT_SMALL_H.Visible = true;
				TBL_DT_SMALL.Visible = true;

				TBL_DT_MIDDLE_H.Visible = false;
				TBL_DT_MIDDLE.Visible = false;

				//==============================================================================
				// general information
				TBL_GI_MICRO_H.Visible = false;
				TBL_GI_MICRO.Visible = false;

				TBL_GI_PUKK_H.Visible = false;
				TBL_GI_PUKK.Visible = false;

				TBL_GI_SMALL_H.Visible = true;
				TBL_GI_SMALL.Visible = true;

				TBL_GI_MIDDLE_H.Visible = false;
				TBL_GI_MIDDLE.Visible = false;

				//==============================================================================
				// neraca
				TBL_NE_SMALL_H.Visible = true;
				TBL_NE_SMALL.Visible = true;

				TBL_NE_MIDDLE_H.Visible = false;
				TBL_NE_MIDDLE.Visible = false;

				//==============================================================================
				// laba rugi/income statement & rasio
				TBL_IR_SMALL_H.Visible = true;
				TBL_IR_SMALL.Visible = true;

				TBL_IR_MIDDLE_H.Visible = false;
				TBL_IR_MIDDLE.Visible = false;
			}
			else if (tipeBusiness.Equals("MIDDLE_SCR"))
			{
				//==============================================================================
				// scoring result
				TBL_DT_MICRO_H.Visible = false;
				TBL_DT_MICRO.Visible = false;

				TBL_DT_PUKK_H.Visible = false;
				TBL_DT_PUKK.Visible = false;

				TBL_DT_SMALL_H.Visible = false;
				TBL_DT_SMALL.Visible = false;

				TBL_DT_MIDDLE_H.Visible = true;
				TBL_DT_MIDDLE.Visible = true;

				//==============================================================================
				// general information
				TBL_GI_MICRO_H.Visible = false;
				TBL_GI_MICRO.Visible = false;

				TBL_GI_PUKK_H.Visible = false;
				TBL_GI_PUKK.Visible = false;

				TBL_GI_SMALL_H.Visible = false;
				TBL_GI_SMALL.Visible = false;

				TBL_GI_MIDDLE_H.Visible = true;
				TBL_GI_MIDDLE.Visible = true;

				//==============================================================================
				// neraca
				TBL_NE_SMALL_H.Visible = false;
				TBL_NE_SMALL.Visible = false;

				TBL_NE_MIDDLE_H.Visible = true;
				TBL_NE_MIDDLE.Visible = true;

				//==============================================================================
				// laba rugi/income statement & rasio
				TBL_IR_SMALL_H.Visible = false;
				TBL_IR_SMALL.Visible = false;

				TBL_IR_MIDDLE_H.Visible = true;
				TBL_IR_MIDDLE.Visible = true;
			}
		}

		protected void btn_BACK_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("PreScoringResult.aspx?regno="+ Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&mc=" + Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"]);
		}

	}
}
