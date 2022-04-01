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

namespace SME.RejectMaintenanceDE
{
	/// <summary>
	/// Summary description for M21M22Withdrawl.
	/// </summary>
	public partial class M21M22Withdrawl : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_REGNO.Text	= Request.QueryString["regno"];
				LBL_PRODID.Text	= Request.QueryString["prodid"];
				LBL_APPTYPE.Text= Request.QueryString["apptype"];
				LBL_PRODUCT.Text= Request.QueryString["teks"];
				LBL_PROD_SEQ.Text= Request.QueryString["prod_seq"];

				DDL_CP_TENORCODE.Items.Add(new ListItem("- PILIH -", ""));

				DDL_CP_NOREK.Items.Add(new ListItem("- PILIH -", ""));				
				DDL_WITHDRAWLID.Items.Add(new ListItem("- PILIH -", ""));

				conn.QueryString = "select cu_ref from application where ap_regno='" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
				LBL_CU_REF.Text = conn.GetFieldValue("cu_ref");

				conn.QueryString = "select withdrawlid, withdrawldesc from rfwithdrawltype where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_WITHDRAWLID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select tenorcode, tenordesc from rftenorcode where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CP_TENORCODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select cp_decsta from custproduct where ap_regno='" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
				try
				{
					if (conn.GetFieldValue(0,0) == "")
						LBL_DECSTA.Text = "0";
					else
						LBL_DECSTA.Text = "1";
				}
				catch
				{
					LBL_DECSTA.Text = "0";
				}

				ViewData();
			}

			if (LBL_DECSTA.Text == "0")
				CalculateInstallment();

			TXT_CP_INSTALLMENT.Text = tool.MoneyFormat(TXT_CP_INSTALLMENT.Text);
			TXT_CP_LIMIT.Text		= tool.MoneyFormat(TXT_CP_LIMIT.Text);
			TXT_CP_EXRPLIMIT.Text	= tool.MoneyFormat(TXT_CP_EXRPLIMIT.Text);
			TXT_CP_EXLIMITVAL.Text	= tool.MoneyFormat(TXT_CP_EXLIMITVAL.Text);
		}

		private void CalculateInstallment()
		{
			/////////////////////////
			/// First check whether there has been a value or not
			/// 
			conn.QueryString = "select isnull(CP_INSTALLMENT, '') CP_INSTALLMENT from CUSTPRODUCT " + 
				" where AP_REGNO = '" + LBL_REGNO.Text + 
				"' AND APPTYPE = '" + LBL_APPTYPE.Text + 
				"' AND PRODUCTID = '" + LBL_PRODID.Text + 
				"' AND PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			try 
			{
				if (Convert.ToDouble(conn.GetFieldValue("CP_INSTALLMENT")) > 0)
				{
					TXT_CP_INSTALLMENT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("CP_INSTALLMENT"));
					return;
				}
			} 
			catch (Exception ex)
			{
				ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "AP_REGNO : " + LBL_REGNO.Text);
			}
			//////////////////////////////////


			double result = 0;

			//conn.QueryString = "select calcmethod, isinstallment from rfproduct where productid='" + LBL_PRODID.Text + "'";
			//conn.ExecuteQuery();
			//if ((conn.GetFieldValue("isinstallment") == "1") /*&& (conn.GetFieldValue("calcmethod") == "Annuity") sadfsdf*/) 
			//{
			//	LBL_INSTALLMENT.Text = "Installment";
			try
			{
				result = DMS.CuBESCore.Logic.hitungInstalment(double.Parse(TXT_CP_EXLIMITVAL.Text), int.Parse(TXT_CP_JANGKAWKT.Text), double.Parse(LBL_INTEREST.Text), LBL_PRODID.Text, DDL_CP_TENORCODE.SelectedValue, conn);
			}
			catch
			{
			}
			//	TXT_CP_INSTALLMENT.Text = result.ToString();
			//}
			//else if (conn.GetFieldValue("isinstallment") == "0")
			//{
			//	LBL_INSTALLMENT.Text = "Bunga per bulan";
			//	result = double.Parse(LBL_INTEREST.Text) / 100 * double.Parse(TXT_CP_EXLIMITVAL.Text) / 12;
			//	TXT_CP_INSTALLMENT.Text = result.ToString();
			//	TXT_NEWTENOR.AutoPostBack = false;
			//}

		}

		private void ViewData()
		{
			conn.QueryString="select APPTYPEDESC, PRODUCTDESC, CP_LOANPURPOSE, "+
				"CP_LIMIT, CP_installment, CP_EXRPLIMIT, CP_EXLIMITVAL, CP_VARCODE, CP_RATENO, CP_VARIANCE, "+
				"CP_KETERANGAN, ACC_SEQ, CP_JANGKAWKT, CP_TENORCODE, REVOLVING, aa_no+'#'+convert(varchar,acc_seq) as seq "+
				", CP_DECSTA, AD_VARCODE, AD_VARIANCE, AD_RATENO "+
				", CP_LIMITAWAL, withdrawlid, AA_NO, PRODUCTID, currency " +
				"from VW_CUSTPRODUCT "+
				"where ap_regno='"+ LBL_REGNO.Text +"' and productid='"+ LBL_PRODID.Text +"' and apptype='"+LBL_APPTYPE.Text+"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			string CP_DECSTA			= conn.GetFieldValue("CP_DECSTA");
			string AD_VARCODE			= conn.GetFieldValue("AD_VARCODE");
			string AD_VARIANCE			= conn.GetFieldValue("AD_VARIANCE");
			string AD_RATENO			= conn.GetFieldValue("AD_RATENO");
			LBL_PRJ_CODE.Text = conn.GetFieldValue("PRJ_NAME");
			LBL_EARMARK_AMOUNT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("EARMARK_AMOUNT_PRJ"));
			LBL_LIMIT_AWAL.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("CP_LIMITAWAL"));

			/**
			conn.QueryString = "select * from vw_cs_withdrawl where ap_regno='" + Request.QueryString["regno"] + "' and apptype = '"  + Request.QueryString["apptype"] + "' and productid='" + Request.QueryString["prodid"] + "' and PROD_SEQ = '" + Request.QueryString["prod_seq"] + "'";
			conn.ExecuteQuery();
			**/
			string aa_no = conn.GetFieldValue("AA_NO"), productid = conn.GetFieldValue("PRODUCTID"), acc_seq = conn.GetFieldValue("ACC_SEQ");

			TXT_APPTYPE.Text = conn.GetFieldValue("APPTYPEDESC");
			try { DDL_WITHDRAWLID.SelectedValue = conn.GetFieldValue("withdrawlid"); } 
			catch {}
			TXT_AA_NO.Text = conn.GetFieldValue("AA_NO");
			TXT_PRODUCT.Text = conn.GetFieldValue("PRODUCTDESC");
			TXT_CP_EXLIMITVAL.Text = tool.MoneyFormat(conn.GetFieldValue("CP_EXLIMITVAL"));
			TXT_CP_EXRPLIMIT.Text = tool.MoneyFormat(conn.GetFieldValue("CP_EXRPLIMIT"));
			TXT_CP_LIMIT.Text = tool.MoneyFormat(conn.GetFieldValue("CP_LIMIT"));
			LBL_CURR2.Text = conn.GetFieldValue("currency");
			TXT_CP_KETERANGAN.Text = conn.GetFieldValue("cp_keterangan");
			TXT_PRODUCTID.Text = conn.GetFieldValue("PRODUCTID");
			TXT_CP_JANGKAWKT.Text = conn.GetFieldValue("CP_JANGKAWKT");
			try { DDL_CP_TENORCODE.SelectedValue = conn.GetFieldValue("CP_TENORCODE"); } 
			catch {}
			//DDL_PRODUCTID.SelectedValue = conn.GetFieldValue("PRODUCTID");

			conn.QueryString = "select acc_seq from bookedprod where aa_no='" + aa_no + "' and productid='" + productid + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CP_NOREK.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
			try { DDL_CP_NOREK.SelectedValue = acc_seq; } 
			catch {}

			conn.QueryString = "select interesttype, currency from rfproduct where productid='" + LBL_PRODID.Text + "'";
			conn.ExecuteQuery();
			
			//LBL_CURR1.Text = conn.GetFieldValue("currency");
			//LBL_CURR2.Text = conn.GetFieldValue("currency");
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
				if (conn.GetFieldValue(0,0) != "")
					LBL_INTEREST.Text = conn.GetFieldValue("interesttyperate");
				LBL_VARIANCE.Visible = false;
				//TXT_CP_INTEREST.Visible = true;
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

		protected void update_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec DE_SC_WITHDRAWL_AD '" + Request.QueryString["regno"] + "', '" +
				TXT_AA_NO.Text + "', " +
				tool.ConvertNull(DDL_CP_NOREK.SelectedValue) + ", " +
				tool.ConvertFloat(TXT_CP_LIMIT.Text) + ", " + 
				tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text) + ", " + 
				tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text) + ", '" + 
				TXT_CP_KETERANGAN.Text + "', " + 
				tool.ConvertNull(DDL_WITHDRAWLID.SelectedValue) + ", '" + 
				TXT_PRODUCTID.Text + "', " + 
				tool.ConvertFloat(TXT_CP_INSTALLMENT.Text) + ", " + 
				tool.ConvertFloat(LBL_INTEREST.Text) + ", '" + 
				LBL_VARCODE.Text + "', '" + LBL_VARIANCE.Text + "', '" + 
				LBL_RATENO.Text + "', '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteNonQuery();
		}
	}
}
