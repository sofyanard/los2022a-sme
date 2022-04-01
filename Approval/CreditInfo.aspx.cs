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
	/// Summary description for CreditInfo.
	/// </summary>
	public partial class CreditInfo : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn;
		protected System.Web.UI.WebControls.TextBox txt_exclimit;
		protected System.Web.UI.WebControls.TextBox txt_equlimit;
		protected Tools tool = new Tools();
		string var_fromsta;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				viewdata();
				endi.Visible = false;
			}
		}

		private void viewdata()
		{
			lbl_regno.Text	 = Request.QueryString["regno"];
			lbl_curef.Text	 = Request.QueryString["curef"];
			lbl_prod.Text	 = Request.QueryString["prod"];
			lbl_apptype.Text = Request.QueryString["apptype"];
			lbl_track.Text	 = Request.QueryString["tc"];
			lbl_userid.Text	 = Session["USERID"].ToString();
			mc.Text			 = Request.QueryString["mc"];
			LBL_PROD_SEQ.Text = Request.QueryString["prod_seq"];

			conn.QueryString = "select idc_interesttype, idc_interest, idc_flag from custproduct where ap_regno = '"+lbl_regno.Text+"'"+
				" and productid = '"+lbl_prod.Text+"' and apptype = '"+lbl_apptype.Text+"'  and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("idc_interesttype") == "01")
			{
				txt_idcprimevar.Visible	= true;
				ddl_idcvarcode.Visible	= true;
			}
			else if (conn.GetFieldValue("idc_interesttype") == "02")
			{
				txt_idcprimevar.Visible	= false;
				ddl_idcvarcode.Visible	= false;
			}

			if (conn.GetFieldValue("idc_flag") == "1")
			{
				ddl_idcinttype.Enabled	= true;
				ddl_idcvarcode.Enabled	= true;
				txt_idcvariance.ReadOnly= false;
			}
			else 
			{
				ddl_idcinttype.Enabled	= false;
				ddl_idcvarcode.Enabled	= false;
				txt_idcvariance.ReadOnly= true;
			}

			conn.QueryString = "select in_renewal, in_ubahjaminan, in_ubahlimit, in_ubahsyarat from rfinitial";
			conn.ExecuteQuery();
			if (lbl_apptype.Text == conn.GetFieldValue("in_renewal"))
			{
				tr_decinstall.Visible			= false;
				tr_decgraceperiode.Visible		= false;
				tr_decpayfreq.Visible			= false;
				txt_decexlimitval.ReadOnly		= true;
				ddl_decvarcode.Enabled			= false;
				txt_decvariance.ReadOnly		= true;
			}
			else if (lbl_apptype.Text == conn.GetFieldValue("in_ubahjaminan"))
			{
				tr_decinstall.Visible			= false;
				tr_decgraceperiode.Visible		= false;
				tr_decpayfreq.Visible			= false;
				txt_dectenor.ReadOnly			= true;
				ddl_dectenorcode.Enabled		= false;
				ddl_decvarcode.Enabled			= false;
				txt_decvariance.ReadOnly		= true;
				txt_decexlimitval.ReadOnly		= true;
			}
			else if (lbl_apptype.Text == conn.GetFieldValue("in_ubahlimit"))
			{
				tr_decinstall.Visible			= false;
				tr_decgraceperiode.Visible		= false;
				tr_decpayfreq.Visible			= false;
				txt_dectenor.ReadOnly			= true;
				ddl_dectenorcode.Enabled		= false;
				ddl_decvarcode.Enabled			= false;
				txt_decvariance.ReadOnly		= true;
				txt_dectenor.Text				= "0";
				ddl_dectenorcode.SelectedValue	= "";
				txt_declimitchg.Visible			= true;
			}
			else if (lbl_apptype.Text == conn.GetFieldValue("in_ubahsyarat"))
			{
				tr_decinstall.Visible			= false;
				tr_decgraceperiode.Visible		= false;
				tr_decpayfreq.Visible			= false;
				txt_dectenor.ReadOnly			= true;
				ddl_dectenorcode.Enabled		= false;
				ddl_decvarcode.Enabled			= false;
				txt_decvariance.ReadOnly		= true;
				txt_decexlimitval.ReadOnly		= true;
			}
			
			//Get DropDownList Data
			ddl_dectenorcode.Items.Add(new ListItem("-- Pilih --",""));
			conn.QueryString = "select * from RFTENORCODE where active = '1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount();i++)
				ddl_dectenorcode.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

			ddl_decovrreason.Items.Add(new ListItem("-- Pilih --",""));
			conn.QueryString = "select * from RFREASON where reasontype = '2' and active = '1' ";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount();i++)
				ddl_decovrreason.Items.Add(new ListItem(conn.GetFieldValue(i,2),conn.GetFieldValue(i,0)));

			ddl_rate.Items.Add(new ListItem("-- Pilih --",""));
			ddl_decrate.Items.Add(new ListItem("-- Pilih --",""));
			ddl_idcprimevar.Items.Add(new ListItem("-- Pilih --",""));
			conn.QueryString = "select rateno, rate from RFRATENUMBER where active = '1' ";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount();i++)
			{
				ddl_rate.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
				ddl_decrate.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
				ddl_idcprimevar.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}

			ddl_idcinttype.Items.Add(new ListItem("-- Pilih --",""));
			conn.QueryString = "select itypeid, itypedesc from rfinteresttype";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount();i++)
			{
				ddl_idcinttype.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}

			ddl_decpayfreq.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select paymentid, paymentdesc from rfpaymentfreq where active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				ddl_decpayfreq.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			ddl_varcode.Items.Add(new ListItem("-- Pilih --",""));
			ddl_varcode.Items.Add(new ListItem("+", "+"));
			ddl_varcode.Items.Add(new ListItem("-", "-"));
			ddl_decvarcode.Items.Add(new ListItem("-- Pilih --",""));
			ddl_decvarcode.Items.Add(new ListItem("+", "+"));
			ddl_decvarcode.Items.Add(new ListItem("-", "-"));
			ddl_idcvarcode.Items.Add(new ListItem("-- Pilih --",""));
			ddl_idcvarcode.Items.Add(new ListItem("+", "+"));
			ddl_idcvarcode.Items.Add(new ListItem("-", "-"));

			//Get Credit Info Data
			conn.QueryString = "select isnull(ap_isappeal,0) ap_isappeal from application where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();
			var_fromsta = conn.GetFieldValue("ap_isappeal");

			conn.QueryString = "select * from approval_decision where ap_regno = '"+lbl_regno.Text+"' "+
							   " and productid = '"+lbl_prod.Text+"' and apptype = '"+lbl_apptype.Text+"' "+
							   " and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "' and ad_fromsta = '"+var_fromsta+"' ";
			conn.ExecuteQuery();
			DataTable dt_ad = new DataTable();
			dt_ad = conn.GetDataTable().Copy();

			conn.QueryString	= "exec approval_info '"+lbl_regno.Text+"', '"+lbl_prod.Text+"', '"+lbl_apptype.Text+"', '"+lbl_userid.Text+"', '"+var_fromsta+"' , '" + LBL_PROD_SEQ.Text + "'";
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
				
				if (dt_ad.Rows.Count == 0)
				{
					txt_declimit.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
					txt_dectenor.Text				= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
					ddl_dectenorcode.SelectedValue	= dt_aprvinfo.Rows[0]["cp_tenorcode"].ToString().Trim();
					txt_decfix.Text	 				= dt_aprvinfo.Rows[0]["cp_interest"].ToString();
					ddl_decrate.SelectedValue		= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim(); 
					try
						{txt_decrate.Text			= Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);}
					catch
						{txt_decrate.Text			= "";}
					ddl_decvarcode.SelectedValue	= dt_aprvinfo.Rows[0]["cp_varcode"].ToString().Trim();
					txt_decvariance.Text			= dt_aprvinfo.Rows[0]["cp_variance"].ToString();
					txt_decremark.Text				= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString();
					txt_decinstallment.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_installment"].ToString());
					if ((txt_decinstallment.Text == "0") || (txt_decinstallment.Text == "0,00"))
						txt_decinstallment.Text = "-";
					txt_decexlimitval.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 
					txt_decexrplimit.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 
					txt_declimitchg.Text			= dt_aprvinfo.Rows[0]["cp_limitchg"].ToString();
					txt_decgraceperiode.Text		= dt_aprvinfo.Rows[0]["cp_graceperiod"].ToString(); 
					ddl_decpayfreq.SelectedValue	= dt_aprvinfo.Rows[0]["cp_paymentid"].ToString().Trim(); 

					//input approval decision
					if (lbl_prod.Text != "")
					{
						if (txt_decinstallment.Text == "-")
							txt_decinstallment.Text = "0";
						conn.QueryString = "exec input_approvaldecision  '"+lbl_regno.Text+"', '"+lbl_prod.Text+"', "+
							" '"+lbl_apptype.Text+"', '"+lbl_userid.Text+"', "+
							" "+tool.ConvertFloat(txt_declimit.Text)+", "+txt_dectenor.Text+",'"+ddl_dectenorcode.SelectedValue+"', "+
							" "+tool.ConvertFloat(txt_decfix.Text)+", '"+ddl_decrate.SelectedValue+"', '"+ddl_decvarcode.SelectedValue+"', "+txt_decvariance.Text+", "+
							" '', '', '"+txt_decremark.Text+"', "+tool.ConvertFloat(txt_decinstallment.Text)+", '0', '"+lbl_decsta.Text+"', "+
							" "+tool.ConvertFloat(txt_exlimitval.Text)+", "+tool.ConvertFloat(txt_exrplimit.Text)+", '"+var_fromsta+"', "+
							" "+tool.ConvertNum(txt_decgraceperiode.Text)+", '"+ddl_decpayfreq.SelectedValue+"', '" + LBL_PROD_SEQ.Text + "'";
						conn.ExecuteQuery();
					}
				}
				else if (dt_aprvinfo.Rows[0]["userid"].ToString() == "")
				{
					conn.QueryString = "select * from approval_decision where ap_regno = '"+lbl_regno.Text+"' "+
						" and productid = '"+lbl_prod.Text+"' and apptype = '"+lbl_apptype.Text+"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "' " +
						" and ad_seq = (select max(ad_seq) from approval_decision ad where approval_decision.ap_regno = ad.ap_regno "+
						" and approval_decision.productid = ad.productid and approval_decision.apptype = ad.apptype and approval_decision.PROD_SEQ = ad.PROD_SEQ) ";
					conn.ExecuteQuery();

					txt_declimit.Text				= tool.MoneyFormat(conn.GetFieldValue("ad_limit"));
					txt_dectenor.Text				= conn.GetFieldValue("ad_tenor");
					ddl_dectenorcode.SelectedValue	= conn.GetFieldValue("ad_tenorcode").Trim();
					txt_decfix.Text					= conn.GetFieldValue("ad_interest");
					ddl_decrate.SelectedValue		= conn.GetFieldValue("ad_rateno");
					try
						{txt_decrate.Text			= Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);}
					catch
						{txt_decrate.Text			= "";}
					ddl_decvarcode.SelectedValue	= conn.GetFieldValue("ad_varcode").Trim();
					txt_decvariance.Text			= conn.GetFieldValue("ad_variance");
					if (conn.GetFieldValue("ad_ovrsta") == "0")
						txt_decovrsta.Text			= "No";
					else if (conn.GetFieldValue("ad_ovrsta") == "1")
						txt_decovrsta.Text			= "Yes";
					ddl_decovrreason.SelectedValue	= conn.GetFieldValue("ad_ovrreason").Trim();
					txt_decovrreason.Text			= conn.GetFieldValue("ad_ovrreasontext");
					txt_decremark.Text				= conn.GetFieldValue("ad_keterangan");
					txt_decinstallment.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_installment"));
					if ((txt_decinstallment.Text == "0") || (txt_decinstallment.Text == "0,00"))
						txt_decinstallment.Text = "-";
					lbl_decsta.Text					= conn.GetFieldValue("ad_reject");
					if (lbl_decsta.Text == "0")
						txt_decsta.Text				= "APPROVE BY PREVIOUS USER";
					else if (lbl_decsta.Text == "1")
						txt_decsta.Text				= "REJECT BY PREVIOUS USER";
					txt_decexlimitval.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_exlimitval")); 
					txt_decexrplimit.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_exrplimit")); 
					txt_declimitchg.Text			= dt_aprvinfo.Rows[0]["cp_limitchg"].ToString();
					txt_decgraceperiode.Text		= conn.GetFieldValue("ad_graceperiod"); 
					ddl_decpayfreq.SelectedValue	= conn.GetFieldValue("ad_paymentid"); 

					//input approval decision
					if (lbl_prod.Text != "")
					{
						if (txt_decinstallment.Text == "-")
							txt_decinstallment.Text = "0";
						conn.QueryString = "exec input_approvaldecision  '"+lbl_regno.Text+"', '"+lbl_prod.Text+"', "+
							" '"+lbl_apptype.Text+"', '"+lbl_userid.Text+"', "+
							" "+tool.ConvertFloat(txt_declimit.Text)+", "+txt_dectenor.Text+",'"+ddl_dectenorcode.SelectedValue+"', "+
							" "+tool.ConvertFloat(txt_decfix.Text)+", '"+ddl_decrate.SelectedValue+"', '"+ddl_decvarcode.SelectedValue+"', "+tool.ConvertFloat(txt_decvariance.Text)+", "+
							" '"+ddl_decovrreason.SelectedValue+"', '"+txt_decovrreason.Text+"', '"+txt_decremark.Text+"', "+
							" "+tool.ConvertFloat(txt_decinstallment.Text)+", '"+conn.GetFieldValue("ad_ovrsta")+"', '"+lbl_decsta.Text+"', "+
							" "+tool.ConvertFloat(txt_decexlimitval.Text)+", "+tool.ConvertFloat(txt_decexrplimit.Text)+", '"+var_fromsta+"', "+
							" "+tool.ConvertNum(txt_decgraceperiode.Text)+", '"+ddl_decpayfreq.SelectedValue+"', '" + LBL_PROD_SEQ.Text + "'";
						conn.ExecuteQuery();
					}
				}
				else if (conn.GetFieldValue("userid") != "")
				{
					txt_declimit.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_limit"].ToString());
					txt_dectenor.Text				= dt_aprvinfo.Rows[0]["ad_tenor"].ToString();
					ddl_dectenorcode.SelectedValue	= dt_aprvinfo.Rows[0]["ad_tenorcode"].ToString().Trim();
					txt_decfix.Text					= dt_aprvinfo.Rows[0]["ad_interest"].ToString();
					ddl_decrate.SelectedValue		= dt_aprvinfo.Rows[0]["ad_rateno"].ToString();
					try
						{txt_decrate.Text			= Convert.ToString(double.Parse(ddl_decrate.SelectedItem.Text) * 100);}
					catch
						{txt_decrate.Text			= "";}
					ddl_decvarcode.SelectedValue	= dt_aprvinfo.Rows[0]["ad_varcode"].ToString().Trim();
					txt_decvariance.Text			= dt_aprvinfo.Rows[0]["ad_variance"].ToString();
					txt_decovrsta.Text				= dt_aprvinfo.Rows[0]["ad_ovrsta"].ToString();
					ddl_decovrreason.SelectedValue	= dt_aprvinfo.Rows[0]["ad_ovrreason"].ToString().Trim();
					txt_decovrreason.Text			= dt_aprvinfo.Rows[0]["ad_ovrreasontext"].ToString();
					txt_decremark.Text				= dt_aprvinfo.Rows[0]["ad_keterangan"].ToString();
					txt_decinstallment.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_installment"].ToString());
					if ((txt_decinstallment.Text == "0") || (txt_decinstallment.Text == "0,00"))
						txt_decinstallment.Text = "-";
					txt_decsta.Text					= dt_aprvinfo.Rows[0]["ad_rejectdesc"].ToString();
					lbl_decsta.Text					= dt_aprvinfo.Rows[0]["ad_reject"].ToString();
					txt_decexlimitval.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_exlimitval"].ToString()); 
					txt_decexrplimit.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_exrplimit"].ToString()); 
					txt_declimitchg.Text			= dt_aprvinfo.Rows[0]["cp_limitchg"].ToString();
					txt_decgraceperiode.Text		= dt_aprvinfo.Rows[0]["ad_graceperiod"].ToString(); 
					ddl_decpayfreq.SelectedValue	= dt_aprvinfo.Rows[0]["ad_paymentid"].ToString().Trim(); 
				}

				txt_idcratio.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["idc_ratio"].ToString());	
				txt_idcterm.Text				= dt_aprvinfo.Rows[0]["idc_jwaktu"].ToString();
				txt_idccapratio.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["idc_capratio"].ToString());
				txt_idccapamt.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["idc_capamnt"].ToString());
				ddl_idcinttype.SelectedValue	= dt_aprvinfo.Rows[0]["idc_interesttype"].ToString().Trim();
				if (ddl_idcinttype.SelectedValue == "01")
				{
					ddl_idcprimevar.SelectedValue	= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim();
					try
						{txt_idcprimevar.Text		= Convert.ToString(double.Parse(ddl_idcprimevar.SelectedItem.Text) * 100);}
					catch
						{txt_idcprimevar.Text		= "";}
					ddl_idcvarcode.SelectedValue	= dt_aprvinfo.Rows[0]["idc_varcode"].ToString().Trim();
					txt_idcvariance.Text			= dt_aprvinfo.Rows[0]["idc_variance"].ToString();
				}
				else if (ddl_idcinttype.SelectedValue == "02")
				{
					txt_idcvariance.Text					= dt_aprvinfo.Rows[0]["idc_interest"].ToString();
				}
				conn.ClearData();
			}

			conn.QueryString = "select interesttype from rfproduct where productid = '"+lbl_prod.Text+"'";
			conn.ExecuteQuery();
			string var_inttype = conn.GetFieldValue("interesttype");
			if (var_inttype == "01")
			{
				tr_fix.Visible	  = false;
				tr_decfix.Visible = false;
			}
			else if (var_inttype == "02")
			{
				tr_float.Visible    = false;
				tr_decfloat.Visible = false;
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

		protected void btn_override_Click(object sender, System.EventArgs e)
		{
			if (double.Parse(txt_decexlimitval.Text) > double.Parse(txt_exlimitval.Text))
			{
				Tools.popMessage(this, "Approval limit Cannot greater than Requested Limit");
				return;
			}
			if ((ddl_decovrreason.SelectedIndex == 0) || (txt_decovrreason.Text.Trim() == ""))
			{
				GlobalTools.popMessage(this, "Override reason must be choosed and filled");
				return;
			}

			conn.QueryString = "select in_kreditbaru from rfinitial";
			conn.ExecuteQuery();
			if (lbl_apptype.Text == conn.GetFieldValue("in_kreditbaru"))
			{
				conn.QueryString = "select isnull(su_emaslimit, 0)su_emaslimit from scuser "+
								   " where userid = '"+lbl_userid.Text+"'";
				conn.ExecuteQuery();
				if (double.Parse(txt_declimit.Text) > double.Parse(conn.GetFieldValue("su_emaslimit").ToString()))
				{
					Tools.popMessage(this, "Limit in rupiah cannot greater than eMas Limit");
					return;
				}
			}

			if (((int.Parse(txt_dectenor.Text) < 30) && (ddl_dectenorcode.SelectedValue == "D")) || ((int.Parse(txt_dectenor.Text) < 1) && (ddl_dectenorcode.SelectedValue == "M")))
			{
				Tools.popMessage(this, "Tenor Cannot below 30 days or 1 month");
				return;
			}

			if (ddl_decovrreason.SelectedValue == "")
			{
				Tools.popMessage(this, "Override Reason should be filled");	
				return;
			}
			
			conn.QueryString = "select isnull(ap_isappeal,0) ap_isappeal from application where ap_regno = '"+lbl_regno.Text+"'";
			conn.ExecuteQuery();
			var_fromsta = conn.GetFieldValue("ap_isappeal");

			//txt_decexlimitval.Text = Convert.ToString((double.Parse(txt_declimit.Text)/double.Parse(txt_decexrplimit.Text)));
			txt_declimit.Text = Convert.ToString((double.Parse(txt_decexlimitval.Text)*double.Parse(txt_decexrplimit.Text)));
			CalculateInstallment();
			if (txt_decinstallment.Text == "-")
				txt_decinstallment.Text = "0";

			conn.QueryString = "exec input_approvaldecision  '"+lbl_regno.Text+"', '"+lbl_prod.Text+"', "+
						  	   " '"+lbl_apptype.Text+"', '"+lbl_userid.Text+"', "+
							   " "+tool.ConvertFloat(txt_declimit.Text)+", "+txt_dectenor.Text+",'"+ddl_dectenorcode.SelectedValue+"', "+
							   " "+tool.ConvertFloat(txt_decfix.Text)+", '"+ddl_decrate.SelectedValue+"', '"+ddl_decvarcode.SelectedValue+"', "+tool.ConvertFloat(txt_decvariance.Text)+", "+
							   " '"+ddl_decovrreason.SelectedValue+"', '"+txt_decovrreason.Text+"', '"+txt_decremark.Text+"', "+tool.ConvertFloat(txt_decinstallment.Text)+", "+
							   " '1', '"+lbl_decsta.Text+"', "+tool.ConvertFloat(txt_decexlimitval.Text)+", "+tool.ConvertFloat(txt_decexrplimit.Text)+", '"+var_fromsta+"', "+
						       " "+tool.ConvertNum(txt_decgraceperiode.Text)+", '"+ddl_decpayfreq.SelectedValue+"', '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();

			if (txt_idcvariance.Text == "")
				txt_idcvariance.Text = "0";

			if (ddl_idcinttype.SelectedValue == "01")
			{
				conn.QueryString = "update custproduct set idc_interesttype = '"+ddl_idcinttype.SelectedValue+"', idc_varcode = '"+ddl_idcvarcode.SelectedValue+"', idc_variance = "+txt_idcvariance.Text+" "+
					" where ap_regno = '"+lbl_regno.Text+"' and productid = '"+lbl_prod.Text+
					"' and apptype = '"+lbl_apptype.Text+"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			}
			else if (ddl_idcinttype.SelectedValue == "02")
			{
				conn.QueryString = "update custproduct set idc_interesttype = '"+ddl_idcinttype.SelectedValue+"', idc_interest = "+txt_idcvariance.Text+" "+
					" where ap_regno = '"+lbl_regno.Text+"' and productid = '"+lbl_prod.Text+
					"' and apptype = '"+lbl_apptype.Text+"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			}
			conn.ExecuteQuery();

			//conn.QueryString = "update application set ap_aprveyes = '1' where ap_regno = '"+lbl_regno.Text+"' ";
			//conn.ExecuteQuery();

			string link	= "Approval.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text+"&tc="+lbl_track.Text+"&mc="+mc.Text;
			string autoLoadScript = "<script language='javascript'>GetOut('"+link+"');</script>";
			Page.RegisterStartupScript("LoadScript ", autoLoadScript);
			//Response.Write("<script language='JavaScript'>window.parent.document.getElementById('main').src='InfoCollateral.aspx?sta="+Request.QueryString["sta"]+"&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"]+"';</script>");
		}

		private void CalculateInstallment()
		{
			double result = 0;

			conn.QueryString = "select calcmethod, isinstallment, interesttype, interesttyperate from rfproduct where productid = '" +lbl_prod.Text+ "'";
			conn.ExecuteQuery();
			DataTable dt_rfprod = new DataTable();
			dt_rfprod = conn.GetDataTable().Copy();
			if (dt_rfprod.Rows[0]["interesttype"].ToString() == "01") 
			{
				lbl_interest.Text = Convert.ToString(tool.ConvertFloat(txt_decrate.Text) +  ddl_decvarcode.SelectedValue + double.Parse(txt_decvariance.Text));
				//double interest = Convert.ToDouble(lbl_interest.Text);
				conn.QueryString = "select " + lbl_interest.Text + " interest" ;
				conn.ExecuteQuery();
				lbl_interest.Text = conn.GetFieldValue("interest");							
			}
			else if (dt_rfprod.Rows[0]["interesttype"].ToString() == "02") 
			{
				lbl_interest.Text	= dt_rfprod.Rows[0]["interesttyperate"].ToString();
			}
			
			if (dt_rfprod.Rows[0]["isinstallment"].ToString() == "1") //&& (dt_rfprod.Rows[0]["calcmethod"].ToString() == "Annuity"))
			{
				result = DMS.CuBESCore.Logic.hitungInstalment(double.Parse(txt_decexlimitval.Text), int.Parse(txt_dectenor.Text), double.Parse(lbl_interest.Text), lbl_prod.Text, ddl_dectenorcode.SelectedValue, conn);
				txt_decinstallment.Text = tool.MoneyFormat(result.ToString());
				/*result = DMS.CuBESCore.Logic.hitungSkalaAngsuran(double.Parse(tool.ConvertFloat(txt_declimit.Text)), int.Parse(txt_dectenor.Text), 1, double.Parse(lbl_interest.Text));
				txt_decinstallment.Text = result.ToString();*/
			}	
			/*else if ((dt_rfprod.Rows[0]["isinstallment"].ToString() == "1") && (dt_rfprod.Rows[0]["calcmethod"].ToString()  == "Daily"))
			{
				result = DMS.CuBESCore.Logic.hitungSkalaAngsuran(double.Parse(tool.ConvertFloat(txt_declimit.Text)), int.Parse(txt_dectenor.Text), double.Parse(lbl_interest.Text), 1);
				txt_decinstallment.Text = result.ToString();
			}*/
			else if (dt_rfprod.Rows[0]["isinstallment"].ToString() == "0")
			{
				txt_decinstallment.Text = "-";
				//result = double.Parse(lbl_interest.Text)/100 * double.Parse(txt_decexlimitval.Text);
				//txt_decinstallment.Text = tool.MoneyFormat(result.ToString());
				//txt_dectenor.AutoPostBack = false;
				/*result = double.Parse(lbl_interest.Text) / 100 * double.Parse(lbl_exlimitval.Text);
				txt_decinstallment.Text = result.ToString();*/
			}
		}

		protected void lb_struc_Click(object sender, System.EventArgs e)
		{
			if ((lbl_prod.Text == "") && (lbl_apptype.Text == ""))
			{
				Tools.popMessage(this, "Check Facilities of Structure Credit First!");
				return;
			}

			conn.QueryString = "select productid+' '+productdesc+'('+apptypedesc+')' proddesc "+
							   " from rfproduct, rfapplicationtype "+
							   " where productid = '"+lbl_prod.Text+"' "+
							   " and apptypeid = '"+lbl_apptype.Text+"'";
			conn.ExecuteQuery();
			string var_text = conn.GetFieldValue("proddesc");
			if (lbl_apptype.Text == "01")
			{
				conn.QueryString = "select iscashloan from rfproduct where productid = '"+lbl_prod.Text+ "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue(0,0) == "0")
					conn.QueryString = "select screenlink from apptypelink where APPTYPEID = '"+lbl_apptype.Text+ "' and PRODUCTID='" + "M21"/*+ dt.Rows[i+j][1]*/ + "' and fungsiId='CS' and iscashloan='0'";
				else	
					conn.QueryString = "select screenlink from apptypelink where APPTYPEID = '"+lbl_apptype.Text+ "' and PRODUCTID='" + "M21"/*+ dt.Rows[i+j][1]*/ + "' and fungsiId='CS' and iscashloan='1'";
			}
			else
				conn.QueryString = "select screenlink from apptypelink where APPTYPEID = '"+lbl_apptype.Text+ "' and PRODUCTID='" + "M21"/*+ dt.Rows[i+j][1]*/ + "' and fungsiId='CS' ";
			conn.ExecuteQuery();
			Response.Write("<script language='javascript'>window.open('/SME/DataEntry/" + conn.GetFieldValue("screenlink")+"?regno="+lbl_regno.Text+"&apptype="+lbl_apptype.Text+ "&prodid="+lbl_prod.Text+"&teks="+var_text+ "&de=0" + "', 'CreditStructure', 'status=yes,scrollbars=yes,width=900,height=500');</script>");
		}

		protected void ddl_idcinttype_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (ddl_idcinttype.SelectedValue == "01")
			{
				txt_idcprimevar.Visible			= true;
				ddl_idcvarcode.Visible			= true;
			}
			else if (ddl_idcinttype.SelectedValue == "02")
			{
				txt_idcprimevar.Visible			= false;
				ddl_idcvarcode.Visible			= false;
			}
		}

		protected void txt_decexlimitval_TextChanged(object sender, System.EventArgs e)
		{
			string decexlimitval = txt_decexlimitval.Text;
			string decexrplimit =  txt_decexrplimit.Text;
			float hasil = 0;
			
			try 
			{
				hasil = float.Parse(decexlimitval) * float.Parse(decexrplimit);
				txt_declimit.Text = hasil.ToString("##,##0.00");
			} 
			catch 
			{
				txt_declimit.Text = "0,00";
			}
		}
	}
}
