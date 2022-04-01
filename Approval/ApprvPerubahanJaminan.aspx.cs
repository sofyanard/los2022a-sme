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
	/// Summary description for ApprvPerubahanJaminan.
	/// </summary>
	public partial class ApprvPerubahanJaminan : System.Web.UI.Page
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
				tr_ad_title.Visible = false;
				tr_ad_override.Visible = false;
				kreditAwal.Visible = false;

				initializeDropDowns();

				viewDataGeneral();
				isiGrid();
				isiGrid1();
				
				if(STA == "view") viewData2();
				else viewData();

				tr_confirm_negative.Visible = false;
			}
		}

		private void initializeDropDowns() 
		{
			GlobalTools.fillRefList(ddl_decovrreason, "select reasonid, reasondesc from RFREASON where reasontype = '2' and active = '1'", false, conn);
			GlobalTools.fillRefList(DDL_PRJ_CODE, "select PRJ_CODE, PRJ_NAME from rfproject where active = '1' and convert(varchar, prj_expiry_date, 112) >= convert(varchar, getdate(), 112) order by PRJ_NAME", false, conn);
			if (STA == "view")GlobalTools.fillRefList(DDL_CP_LOANPURPOSE, "select * from rfloanpurpose", conn);
			else GlobalTools.fillRefList(DDL_CP_LOANPURPOSE, "select * from rfloanpurpose where active = '1'", conn);
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

		private void viewDataGeneral() 
		{
			conn.QueryString="select APPTYPEDESC, PRODUCTDESC, CP_LOANPURPOSE, "+
				"BC_LOANAMOUNT, CURRENCY, AA_NO, PROJECT_CODE, "+
				"CP_KETERANGAN, CP_JANGKAWKT, CP_TENORCODE, REVOLVING, PRJ_NAME, EARMARK_AMOUNT_PRJ "+
				"from VW_CUSTPRODUCT where ap_regno='"+ REGNO + 
				"' and productid='" + PRODUCT + 
				"' and apptype='" + APPTYPE + 
				"' and PROD_SEQ = '" + PROD_SEQ + "'";
			conn.ExecuteQuery();
			TXT_APPTYPE.Text				= conn.GetFieldValue("APPTYPEDESC");
			TXT_PRODUCT.Text				= conn.GetFieldValue("PRODUCTDESC");
			TXT_REVOLVING.Text				= conn.GetFieldValue("REVOLVING");
			TXT_CP_LIMIT.Text				= tool.MoneyFormat(conn.GetFieldValue("BC_LOANAMOUNT"));
			LBL_CURRENCY.Text				= conn.GetFieldValue("CURRENCY");
			TXT_JANGKAWAKTU.Text			= conn.GetFieldValue("CP_JANGKAWKT");
			LBL_AA_NO.Text					= conn.GetFieldValue("AA_NO");
			string tenor					= conn.GetFieldValue("CP_TENORCODE");
			TXT_CP_KETERANGAN.Text			= conn.GetFieldValue("CP_KETERANGAN");
			LBL_PRJ_CODE.Text				= conn.GetFieldValue("PRJ_NAME");
			LBL_EARMARK_AMOUNT.Text			= GlobalTools.MoneyFormat(conn.GetFieldValue("EARMARK_AMOUNT_PRJ"));
			try {DDL_PRJ_CODE.SelectedValue = conn.GetFieldValue("PROJECT_CODE");} 
			catch {DDL_PRJ_CODE.SelectedValue = "";}
			try {DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue("CP_LOANPURPOSE");}
			catch {DDL_CP_LOANPURPOSE.SelectedValue="";}
			conn.ClearData();

			conn.QueryString = "select TENORDESC from RFTENORCODE where TENORCODE='"+tenor+"'";
			conn.ExecuteQuery();
			LBL_TENORCODE.Text				= conn.GetFieldValue("TENORDESC");
			conn.ClearData();

			
			LBL_PRODUCT.Text			 = TEKS;
		}

		private void viewData() 
		{
			///////////////////////////////////////////////////////////////////////////////////////////////////
			///	Get Credit Info Data
			///	

			/*
			conn.QueryString = "select isnull(ap_isappeal,0) ap_isappeal from application where ap_regno = '"+REGNO+"'";
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
				conn.QueryString = "select * from approval_decision where ap_regno = '"+REGNO+"' "+
					" and productid = '"+PRODUCT+"' and apptype = '"+APPTYPE+"' "+
					" and PROD_SEQ = '" + PROD_SEQ + "' and ad_fromsta = '"+var_fromsta+"' ";
				conn.ExecuteQuery();
			}

			DataTable dt_ad = new DataTable();
			dt_ad = conn.GetDataTable().Copy();

			conn.QueryString	= "exec approval_info '"+REGNO+"', '"+PRODUCT+"', '"+APPTYPE+"', '"+USERID+"', '"+var_fromsta+"' , '" + PROD_SEQ + "'";
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
					txt_limit.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
					txt_tenor.Text				= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
					txt_tenorcode.Text			= dt_aprvinfo.Rows[0]["cp_tenorcode"].ToString().Trim();
					txt_fix.Text	 			= dt_aprvinfo.Rows[0]["cp_interest"].ToString();
					txt_rate.Text				= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim(); 
					ddl_varcode.SelectedValue	= dt_aprvinfo.Rows[0]["cp_varcode"].ToString().Trim();
					txt_variance.Text			= dt_aprvinfo.Rows[0]["cp_variance"].ToString();
					txt_remark.Text				= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString();
					txt_installment.Text		= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_installment"].ToString());
					if ((txt_installment.Text == "0") || (txt_installment.Text == "0,00"))
						txt_installment.Text = "-";
					txt_exlimitval.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 
					txt_exrplimit.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 

					//input approval decision
					if (PRODUCT != "")
					{
						if (txt_installment.Text == "-")
							txt_installment.Text = "0";
						conn.QueryString = "exec input_approvaldecision  '"+REGNO+"', '"+PRODUCT+"', "+
							" '"+APPTYPE+"', '"+USERID+"', "+
							" "+tool.ConvertFloat(txt_limit.Text)+", '"+txt_tenor.Text+"','"+txt_tenorcode.Text+"', "+
							" "+tool.ConvertFloat(txt_fix.Text)+", '"+txt_rate.Text+"', '"+ddl_varcode.SelectedValue+"', "+ GlobalTools.ConvertFloat(txt_variance.Text) +", "+
							" '', '', '"+txt_remark.Text+"', "+tool.ConvertFloat(txt_installment.Text)+", '0', '"+lbl_decsta.Text+"', "+
							" "+tool.ConvertFloat(txt_exlimitval.Text)+", "+tool.ConvertFloat(txt_exrplimit.Text)+", '"+var_fromsta+"', "+
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

					txt_limit.Text				= tool.MoneyFormat(conn.GetFieldValue("ad_limit"));
					txt_tenor.Text				= conn.GetFieldValue("ad_tenor");
					txt_tenorcode.Text			= conn.GetFieldValue("ad_tenorcode").Trim();
					txt_fix.Text				= conn.GetFieldValue("ad_interest");
					txt_rate.Text					= conn.GetFieldValue("ad_rateno");
					ddl_varcode.SelectedValue				= conn.GetFieldValue("ad_varcode").Trim();
					txt_variance.Text				= conn.GetFieldValue("ad_variance");
					if (conn.GetFieldValue("ad_ovrsta") == "0")
						txt_decovrsta.Text			= "No";
					else if (conn.GetFieldValue("ad_ovrsta") == "1")
						txt_decovrsta.Text			= "Yes";
					ddl_decovrreason.SelectedValue	= conn.GetFieldValue("ad_ovrreason").Trim();
					txt_decovrreason.Text			= conn.GetFieldValue("ad_ovrreasontext");
					txt_decremark.Text				= conn.GetFieldValue("ad_keterangan");
					txt_installment.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_installment"));
					if ((txt_installment.Text == "0") || (txt_installment.Text == "0,00"))
						txt_installment.Text = "-";
					lbl_decsta.Text					= conn.GetFieldValue("ad_reject");
					if (lbl_decsta.Text == "0")
						txt_decsta.Text				= "APPROVE BY PREVIOUS USER";
					else if (lbl_decsta.Text == "1")
						txt_decsta.Text				= "REJECT BY PREVIOUS USER";
					txt_exlimitval.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_exlimitval")); 
					txt_exrplimit.Text			= tool.MoneyFormat(conn.GetFieldValue("ad_exrplimit")); 

					//input approval decision
					if (PRODUCT != "")
					{
						if (txt_installment.Text == "-")
							txt_installment.Text = "0";
						conn.QueryString = "exec input_approvaldecision  '"+REGNO+"', '"+PRODUCT+"', "+
							" '"+APPTYPE+"', '"+USERID+"', "+
							" "+tool.ConvertFloat(txt_limit.Text)+", '"+txt_tenor.Text+"','"+txt_tenorcode.Text+"', "+
							" "+tool.ConvertFloat(txt_fix.Text)+", '"+txt_rate.Text+"', '"+ddl_rate.SelectedValue+"', "+tool.ConvertFloat(txt_variance.Text)+", "+
							" '"+ddl_decovrreason.SelectedValue+"', '"+txt_decovrreason.Text+"', '"+txt_decremark.Text+"', "+
							" "+tool.ConvertFloat(txt_installment.Text)+", '"+conn.GetFieldValue("ad_ovrsta")+"', '"+lbl_decsta.Text+"', "+
							" "+tool.ConvertFloat(txt_exlimitval.Text)+", "+tool.ConvertFloat(txt_exrplimit.Text)+", '"+var_fromsta+"', "+
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
						txt_limit.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_limit"].ToString());
						txt_tenor.Text				= dt_aprvinfo.Rows[0]["ad_tenor"].ToString();
						txt_tenorcode.Text			= dt_aprvinfo.Rows[0]["ad_tenorcode"].ToString().Trim();
						txt_fix.Text				= dt_aprvinfo.Rows[0]["ad_interest"].ToString();
						txt_rate.Text					= dt_aprvinfo.Rows[0]["ad_rateno"].ToString();
						ddl_varcode.SelectedValue				= dt_aprvinfo.Rows[0]["ad_varcode"].ToString().Trim();
						txt_variance.Text				= dt_aprvinfo.Rows[0]["ad_variance"].ToString();
						txt_decovrsta.Text				= dt_aprvinfo.Rows[0]["ad_ovrsta"].ToString();
						ddl_decovrreason.SelectedValue	= dt_aprvinfo.Rows[0]["ad_ovrreason"].ToString().Trim();
						txt_decovrreason.Text			= dt_aprvinfo.Rows[0]["ad_ovrreasontext"].ToString();
						txt_decremark.Text				= dt_aprvinfo.Rows[0]["ad_keterangan"].ToString();
						txt_installment.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_installment"].ToString());
						if ((txt_installment.Text == "0") || (txt_installment.Text == "0,00"))
							txt_installment.Text = "-";
						txt_decsta.Text					= dt_aprvinfo.Rows[0]["ad_rejectdesc"].ToString();
						lbl_decsta.Text					= dt_aprvinfo.Rows[0]["ad_reject"].ToString();
						txt_exlimitval.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_exlimitval"].ToString()); 
						txt_exrplimit.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["ad_exrplimit"].ToString()); 
					} 
					else 
					{
						txt_limit.Text				= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_limit"].ToString());
						txt_tenor.Text				= dt_aprvinfo.Rows[0]["cp_jangkawkt"].ToString();
						txt_tenorcode.Text			= dt_aprvinfo.Rows[0]["cp_tenorcode"].ToString().Trim();
						txt_fix.Text	 			= dt_aprvinfo.Rows[0]["cp_interest"].ToString();
						txt_rate.Text				= dt_aprvinfo.Rows[0]["rateno"].ToString().Trim(); 
						ddl_varcode.SelectedValue	= dt_aprvinfo.Rows[0]["cp_varcode"].ToString().Trim();
						txt_variance.Text			= dt_aprvinfo.Rows[0]["cp_variance"].ToString();
						txt_remark.Text				= dt_aprvinfo.Rows[0]["cp_keterangan"].ToString();
						txt_installment.Text		= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_installment"].ToString());
						if ((txt_installment.Text == "0") || (txt_installment.Text == "0,00"))
							txt_installment.Text = "-";
						txt_exlimitval.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exlimitval"].ToString()); 
						txt_exrplimit.Text			= tool.MoneyFormat(dt_aprvinfo.Rows[0]["cp_exrplimit"].ToString()); 

						///////////////////////////////////////////////////////////////////////////////////////
						/// Insert a new record into approval_decision with an increment on ad_fromsta field
						/// 
						string ad_fromsta_new = "";
						int _ad_fromsta = 0;
						try { _ad_fromsta = Convert.ToInt16(var_fromsta) + 1; } 
						catch {}
						ad_fromsta_new = _ad_fromsta.ToString();

						//input approval decision
						if (PRODUCT != "")
						{
							if (txt_installment.Text == "-")
								txt_installment.Text = "0";
							conn.QueryString = "exec input_approvaldecision  '"+REGNO+"', '"+PRODUCT+"', "+
								" '"+APPTYPE+"', '"+USERID+"', "+
								" "+tool.ConvertFloat(txt_limit.Text)+", '"+txt_tenor.Text+"','"+txt_tenorcode.Text+"', "+
								" "+tool.ConvertFloat(txt_fix.Text)+", '"+txt_rate.Text+"', '"+ddl_varcode.SelectedValue+"', "+txt_variance.Text+", "+
								" '', '', '"+txt_remark.Text+"', "+tool.ConvertFloat(txt_installment.Text)+", '0', '"+lbl_decsta.Text+"', "+
								" "+tool.ConvertFloat(txt_exlimitval.Text)+", "+tool.ConvertFloat(txt_exrplimit.Text)+", '"+ad_fromsta_new+"', "+
								" null, null, '" + PROD_SEQ + "'";
							conn.ExecuteQuery();
						}
					}
				}

				conn.ClearData();
			}
		}

		private void isiGrid() 
		{
			DataTable dt = new DataTable();
			conn.QueryString = "select cl_seq, cl_desc, coltypedesc, cl_percent, cl_value " +
				"from vw_bookedcollateral where aa_no='" + LBL_AA_NO.Text + "' and " +
				"productid='" + PRODUCT + "' ";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			DatGrd.DataBind();
			double nilaiAkhir = 0;

			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				nilaiAkhir = double.Parse(DatGrd.Items[i].Cells[3].Text) * (double.Parse(DatGrd.Items[i].Cells[2].Text) / 100);
				DatGrd.Items[i].Cells[3].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[3].Text);
				DatGrd.Items[i].Cells[4].Text = tool.MoneyFormat(nilaiAkhir.ToString());
				DatGrd.Items[i].Cells[2].Text = DatGrd.Items[i].Cells[2].Text+" %";
			}
		}

		private void isiGrid1() 
		{
			DataTable dt = new DataTable();
			conn.QueryString="select a.ap_regno, a.cl_seq, a.productid,c.coltypedesc, a.lc_percentage, b.cl_value, lc_value, b.cl_desc, "+
				"action = case when a.LC_ACTION='1' then 'Add' when a.LC_ACTION='2' then 'Remove' when a.LC_ACTION='3' then 'Re-Appraise' end "+
				"from listcollateral a inner join collateral b on " +
				"a.cl_seq = b.cl_seq inner join rfcollateraltype c on b.cl_type = c.coltypeseq " +
				"inner join application d on a.ap_regno = d.ap_regno and b.cu_ref=d.cu_ref "+
				"where a.ap_regno = '" + REGNO + "' and a.productid='" + PRODUCT + "' ";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrd1.DataSource = dt;
			DatGrd1.DataBind();
			for (int i = 0; i < DatGrd1.Items.Count; i++)
			{
				DatGrd1.Items[i].Cells[3].Text = DatGrd1.Items[i].Cells[3].Text+" %";
				DatGrd1.Items[i].Cells[4].Text = tool.MoneyFormat(tool.ConvertFloat(DatGrd1.Items[i].Cells[4].Text));
				DatGrd1.Items[i].Cells[5].Text = tool.MoneyFormat(tool.ConvertFloat(DatGrd1.Items[i].Cells[5].Text));
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
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);
			this.DatGrd1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd1_PageIndexChanged);

		}
		#endregion

		protected void lb_struc_Click(object sender, System.EventArgs e)
		{
			if ((PRODUCT == "") && (APPTYPE == ""))
			{
				Tools.popMessage(this, "Check Facilities of Structure Credit First!");
				return;
			}

			/****
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
		}

		protected void BTN_EARMARK_Click(object sender, System.EventArgs e)
		{
			
		}

		protected void BTN_NEGATIVE_YES_Click(object sender, System.EventArgs e)
		{
		
		}

		protected void BTN_NEGATIVE_NO_Click(object sender, System.EventArgs e)
		{
		
		}

		protected void btn_override_Click(object sender, System.EventArgs e)
		{
		
		}

		protected void btn_Save_Click(object sender, System.EventArgs e)
		{
			/*
			 * I disable this because I assume for Perubahan Jaminan there's no earmarking
			 * 
			if (DDL_PRJ_CODE.SelectedValue == "")
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
					conn.QueryString = "UPDATE KETENTUAN_KREDIT SET PRJ_CODE = " + GlobalTools.ConvertNull(DDL_PRJ_CODE.SelectedValue) + " WHERE KET_CODE = '" + KET_CODE + "'";
					conn.ExecTrans();

					/// Do Earmark
					/// 
					if (TXT_NEGATIVE.Text == "NO")
						Earmarking.Earmarking.doEarmark(REGNO, KET_CODE, conn);
					else
						Earmarking.Earmarking.doEarmark(REGNO, KET_CODE, conn, "1", "1");

					conn.ExecTran_Commit();
				} 
				catch (Earmarking.NegativeLimitException) 
				{
					if (conn != null) 
					{
						conn.ExecTran_Rollback();
					}				

					if (TXT_NEGATIVE.Text == "NO") 
					{
						tr_confirm_negative.Visible = true;
					}
					return;
				}
				catch (Exception ex)
				{
					ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, REGNO);
					if (conn != null) 
					{
						conn.ExecTran_Rollback();
					}
				}
				/// Refresh earmark data
				/// 
				viewDataEarmark();
			}
			*/
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
			}
		}

		
		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			isiGrid();
		}

		private void DatGrd1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd1.CurrentPageIndex = e.NewPageIndex;
			isiGrid1();
		}

		
		
	}
}
