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
using Microsoft.VisualBasic;
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.HistoricalLoanInfo
{
	/// <summary>
	/// Summary description for BankRelation.
	/// </summary>
	public partial class BankRelation : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

            BTN_BACK.Click += new ImageClickEventHandler(BTN_BACK_Click);

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack) 
			{
			}

			viewProsesSaldoRataRata();
			viewLinkAtasNama();
			ViewMandiriLoan();
			ViewOtherLoan();
			viewGroup();
			ViewSaldoRata();
			ViewSaldoRataOB();			

			try 
			{
				if (Request.QueryString["code"] == null )
					LBL_CM_ATASNAMA.Text = "0";
				else
					LBL_CM_ATASNAMA.Text = Request.QueryString["code"];
			}
			catch 
			{
			}
			
			LBL_PAR.Text = Request.QueryString["par"];			

			if (Request.QueryString["code"] == "1")				
				TRGroup.Visible = true;
			else
				TRGroup.Visible = false;

			CheckNama();
			viewDDL();
			ViewMenu();
			viewSubMenu();
			ViewDebiturSejak();
			ViewData();
		}


		private void viewGroup()
		{
			conn.QueryString = "select * from backup_cust_grpmandirifac where ap_regno='"+ Request.QueryString["regno"] +"'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				TXT_CG_CASHLOAN.Text		= conn.GetFieldValue(0, "cg_cashloan");
				TXT_CG_NONCASHLOAN.Text		= conn.GetFieldValue(0, "cg_noncashloan");
				TXT_CG_OTHERS.Text			= conn.GetFieldValue(0, "cg_others");
				TXT_CG_TOTAL.Text			= conn.GetFieldValue(0, "cg_total");
				TXT_CG_COMMITTED.Text		= conn.GetFieldValue(0, "CG_COMMITTED");
				TXT_CG_UNCOMMITTED.Text		= conn.GetFieldValue(0, "CG_UNCOMMITTED");
			}

		}

		private void viewProsesSaldoRataRata()
		{

			GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MR_M1_BLN_mm, this.txt_MR_M1_BLN_yy);
			GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MR_M2_BLN_mm, this.txt_MR_M2_BLN_yy);
			GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MR_M3_BLN_mm, this.txt_MR_M3_BLN_yy);
			GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MR_M4_BLN_mm, this.txt_MR_M4_BLN_yy);
			GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MR_M5_BLN_mm, this.txt_MR_M5_BLN_yy);
			GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MR_M6_BLN_mm, this.txt_MR_M6_BLN_yy);

			GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MO_M1_BLN_mm, this.txt_MO_M1_BLN_yy);
			GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MO_M2_BLN_mm, this.txt_MO_M2_BLN_yy);
			GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MO_M3_BLN_mm, this.txt_MO_M3_BLN_yy);
			GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MO_M4_BLN_mm, this.txt_MO_M4_BLN_yy);
			GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MO_M5_BLN_mm, this.txt_MO_M5_BLN_yy);
			GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MO_M6_BLN_mm, this.txt_MO_M6_BLN_yy);


			ViewSaldoRata();
			try {HitungSaldo();} 
			catch {}

			ViewSaldoRataOB();
			try {HitungSaldoOB();} 
			catch {}

		}

		private void HitungSaldo()
		{
			double TotSaldo, TotDebet, TotDebetF, TotKredit, TotKreditF,
				_MR_M1_SLDRATA, _MR_M2_SLDRATA, _MR_M3_SLDRATA, _MR_M4_SLDRATA, _MR_M5_SLDRATA, _MR_M6_SLDRATA,
				_MR_M1_DEBET, _MR_M2_DEBET, _MR_M3_DEBET, _MR_M4_DEBET, _MR_M5_DEBET, _MR_M6_DEBET,
				_MR_M1_DEBETF, _MR_M2_DEBETF, _MR_M3_DEBETF, _MR_M4_DEBETF, _MR_M5_DEBETF, _MR_M6_DEBETF,
				_MR_M1_KREDIT, _MR_M2_KREDIT, _MR_M3_KREDIT, _MR_M4_KREDIT, _MR_M5_KREDIT, _MR_M6_KREDIT,
				_MR_M1_KREDITF, _MR_M2_KREDITF, _MR_M3_KREDITF, _MR_M4_KREDITF, _MR_M5_KREDITF, _MR_M6_KREDITF, 
				BagiSaldo, BagiDebet, BagiDebetF, BagiKredit, BagiKreditF, RataSaldo, _MR_LIMITKREDIT;

			BagiSaldo = 0;
			BagiDebet = 0;
			BagiDebetF = 0;
			BagiKredit = 0;
			BagiKreditF = 0;

			//-----------------------------------------------------------------saldo rata-rata
			try {_MR_M1_SLDRATA = Double.Parse(this.txt_MR_M1_SLDRATA.Text);} 
			catch {_MR_M1_SLDRATA = 0;}
			if (_MR_M1_SLDRATA != 0) BagiSaldo++;

			try {_MR_M2_SLDRATA = Double.Parse(this.txt_MR_M2_SLDRATA.Text);} 
			catch {_MR_M2_SLDRATA = 0;}
			if (_MR_M2_SLDRATA != 0) BagiSaldo++;

			try {_MR_M3_SLDRATA = Double.Parse(this.txt_MR_M3_SLDRATA.Text);} 
			catch {_MR_M3_SLDRATA = 0;}
			if (_MR_M3_SLDRATA != 0) BagiSaldo++;

			try {_MR_M4_SLDRATA = Double.Parse(this.txt_MR_M4_SLDRATA.Text);} 
			catch {_MR_M4_SLDRATA = 0;}
			if (_MR_M4_SLDRATA != 0) BagiSaldo++;

			try {_MR_M5_SLDRATA = Double.Parse(this.txt_MR_M5_SLDRATA.Text);} 
			catch {_MR_M5_SLDRATA = 0;}
			if (_MR_M5_SLDRATA != 0) BagiSaldo++;

			try {_MR_M6_SLDRATA = Double.Parse(this.txt_MR_M6_SLDRATA.Text);} 
			catch {_MR_M6_SLDRATA = 0;}
			if (_MR_M6_SLDRATA != 0) BagiSaldo++;

			//-----------------------------------------------------------------debet
			try {_MR_M1_DEBET = Double.Parse(this.txt_MR_M1_DEBET.Text);} 
			catch {_MR_M1_DEBET = 0;}
			if (_MR_M1_DEBET != 0) BagiDebet++;

			try {_MR_M2_DEBET = Double.Parse(this.txt_MR_M2_DEBET.Text);} 
			catch {_MR_M2_DEBET = 0;}
			if (_MR_M2_DEBET != 0) BagiDebet++;

			try {_MR_M3_DEBET = Double.Parse(this.txt_MR_M3_DEBET.Text);} 
			catch {_MR_M3_DEBET = 0;}
			if (_MR_M3_DEBET != 0) BagiDebet++;

			try {_MR_M4_DEBET = Double.Parse(this.txt_MR_M4_DEBET.Text);} 
			catch {_MR_M4_DEBET = 0;}
			if (_MR_M4_DEBET != 0) BagiDebet++;

			try {_MR_M5_DEBET = Double.Parse(this.txt_MR_M5_DEBET.Text);} 
			catch {_MR_M5_DEBET = 0;}
			if (_MR_M5_DEBET != 0) BagiDebet++;

			try {_MR_M6_DEBET = Double.Parse(this.txt_MR_M6_DEBET.Text);} 
			catch {_MR_M6_DEBET = 0;}
			if (_MR_M6_DEBET != 0) BagiDebet++;

			//-----------------------------------------------------------------frekuensi debet
			try {_MR_M1_DEBETF = Double.Parse(this.txt_MR_M1_DEBETF.Text);} 
			catch {_MR_M1_DEBETF = 0;}
			if (_MR_M1_DEBETF != 0) BagiDebetF++;

			try {_MR_M2_DEBETF = Double.Parse(this.txt_MR_M2_DEBETF.Text);} 
			catch {_MR_M2_DEBETF = 0;}
			if (_MR_M2_DEBETF != 0) BagiDebetF++;

			try {_MR_M3_DEBETF = Double.Parse(this.txt_MR_M3_DEBETF.Text);} 
			catch {_MR_M3_DEBETF = 0;}
			if (_MR_M3_DEBETF != 0) BagiDebetF++;

			try {_MR_M4_DEBETF = Double.Parse(this.txt_MR_M4_DEBETF.Text);} 
			catch {_MR_M4_DEBETF = 0;}
			if (_MR_M4_DEBETF != 0) BagiDebetF++;

			try {_MR_M5_DEBETF = Double.Parse(this.txt_MR_M5_DEBETF.Text);} 
			catch {_MR_M5_DEBETF = 0;}
			if (_MR_M5_DEBETF != 0) BagiDebetF++;

			try {_MR_M6_DEBETF = Double.Parse(this.txt_MR_M6_DEBETF.Text);} 
			catch {_MR_M6_DEBETF = 0;}
			if (_MR_M6_DEBETF != 0) BagiDebetF++;

			//-----------------------------------------------------------------kredit
			try {_MR_M1_KREDIT = Double.Parse(this.txt_MR_M1_KREDIT.Text);} 
			catch {_MR_M1_KREDIT = 0;}
			if (_MR_M1_KREDIT != 0) BagiKredit++;

			try {_MR_M2_KREDIT = Double.Parse(this.txt_MR_M2_KREDIT.Text);} 
			catch {_MR_M2_KREDIT = 0;}
			if (_MR_M2_KREDIT != 0) BagiKredit++;

			try {_MR_M3_KREDIT = Double.Parse(this.txt_MR_M3_KREDIT.Text);} 
			catch {_MR_M3_KREDIT = 0;}
			if (_MR_M3_KREDIT != 0) BagiKredit++;

			try {_MR_M4_KREDIT = Double.Parse(this.txt_MR_M4_KREDIT.Text);} 
			catch {_MR_M4_KREDIT = 0;}
			if (_MR_M4_KREDIT != 0) BagiKredit++;

			try {_MR_M5_KREDIT = Double.Parse(this.txt_MR_M5_KREDIT.Text);} 
			catch {_MR_M5_KREDIT = 0;}
			if (_MR_M5_KREDIT != 0) BagiKredit++;

			try {_MR_M6_KREDIT = Double.Parse(this.txt_MR_M6_KREDIT.Text);} 
			catch {_MR_M6_KREDIT = 0;}
			if (_MR_M6_KREDIT != 0) BagiKredit++;

			//-----------------------------------------------------------------frekuensi kredit
			try {_MR_M1_KREDITF = Double.Parse(this.txt_MR_M1_KREDITF.Text);} 
			catch {_MR_M1_KREDITF = 0;}
			if (_MR_M1_KREDITF != 0) BagiKreditF++;

			try {_MR_M2_KREDITF = Double.Parse(this.txt_MR_M2_KREDITF.Text);} 
			catch {_MR_M2_KREDITF = 0;}
			if (_MR_M2_KREDITF != 0) BagiKreditF++;

			try {_MR_M3_KREDITF = Double.Parse(this.txt_MR_M3_KREDITF.Text);} 
			catch {_MR_M3_KREDITF = 0;}
			if (_MR_M3_KREDITF != 0) BagiKreditF++;

			try {_MR_M4_KREDITF = Double.Parse(this.txt_MR_M4_KREDITF.Text);} 
			catch {_MR_M4_KREDITF = 0;}
			if (_MR_M4_KREDITF != 0) BagiKreditF++;

			try {_MR_M5_KREDITF = Double.Parse(this.txt_MR_M5_KREDITF.Text);} 
			catch {_MR_M5_KREDITF = 0;}
			if (_MR_M5_KREDITF != 0) BagiKreditF++;

			try {_MR_M6_KREDITF = Double.Parse(this.txt_MR_M6_KREDITF.Text);} 
			catch {_MR_M6_KREDITF = 0;}
			if (_MR_M6_KREDITF != 0) BagiKreditF++;

			try {_MR_LIMITKREDIT  = Double.Parse(this.txt_MR_LIMITKREDIT .Text);} 
			catch {_MR_LIMITKREDIT  = 0;}


			//-----------------------------------------------------------------
			TotSaldo = _MR_M1_SLDRATA + _MR_M2_SLDRATA + _MR_M3_SLDRATA + _MR_M4_SLDRATA + _MR_M5_SLDRATA + _MR_M6_SLDRATA;

			TotDebet = _MR_M1_DEBET + _MR_M2_DEBET + _MR_M3_DEBET + _MR_M4_DEBET + _MR_M5_DEBET + _MR_M6_DEBET;

			TotDebetF = _MR_M1_DEBETF + _MR_M2_DEBETF + _MR_M3_DEBETF + _MR_M4_DEBETF + _MR_M5_DEBETF + _MR_M6_DEBETF;

			TotKredit = _MR_M1_KREDIT + _MR_M2_KREDIT + _MR_M3_KREDIT + _MR_M4_KREDIT + _MR_M5_KREDIT + _MR_M6_KREDIT;

			TotKreditF = _MR_M1_KREDITF + _MR_M2_KREDITF + _MR_M3_KREDITF + _MR_M4_KREDITF + _MR_M5_KREDITF + _MR_M6_KREDITF;

			this.txt_TotSaldo.Text = tool.MoneyFormat(Convert.ToString(TotSaldo));
			this.txt_TotDebet.Text = tool.MoneyFormat(Convert.ToString(TotDebet));
			this.txt_TotDebetF.Text = Convert.ToString(TotDebetF);
			this.txt_TotKredit.Text = tool.MoneyFormat(Convert.ToString(TotKredit));
			this.txt_TotKreditF.Text = Convert.ToString(TotKreditF);

			
			RataSaldo = TotSaldo / (BagiSaldo == 0 ? 1 : BagiSaldo);
			this.txt_RataSaldo.Text = tool.MoneyFormat(Convert.ToString(RataSaldo));
			this.txt_RataDebet.Text = tool.MoneyFormat(Convert.ToString(TotDebet / (BagiDebet == 0 ? 1 : BagiDebet)));
			this.txt_RataDebetF.Text = tool.MoneyFormat(Convert.ToString(TotDebetF /(BagiDebetF == 0 ? 1 : BagiDebetF)));
			this.txt_RataKredit.Text = tool.MoneyFormat(Convert.ToString(TotKredit /(BagiKredit == 0 ? 1 : BagiKredit)));
			this.txt_RataKreditF.Text = tool.MoneyFormat(Convert.ToString(TotKreditF /(BagiKreditF == 0 ? 1 : BagiKreditF)));

			if (RataSaldo == 0)
				this.txt_MR_PRSNSALDO.Text = "0";
			else
				this.txt_MR_PRSNSALDO.Text = tool.MoneyFormat(Convert.ToString(_MR_LIMITKREDIT / RataSaldo));
		}

		private void HitungSaldoOB()
		{
			double TotSaldo, TotDebet, TotDebetF, TotKredit, TotKreditF,
				_MO_M1_SLDRATA, _MO_M2_SLDRATA, _MO_M3_SLDRATA, _MO_M4_SLDRATA, _MO_M5_SLDRATA, _MO_M6_SLDRATA,
				_MO_M1_DEBET, _MO_M2_DEBET, _MO_M3_DEBET, _MO_M4_DEBET, _MO_M5_DEBET, _MO_M6_DEBET,
				_MO_M1_DEBETF, _MO_M2_DEBETF, _MO_M3_DEBETF, _MO_M4_DEBETF, _MO_M5_DEBETF, _MO_M6_DEBETF,
				_MO_M1_KREDIT, _MO_M2_KREDIT, _MO_M3_KREDIT, _MO_M4_KREDIT, _MO_M5_KREDIT, _MO_M6_KREDIT,
				_MO_M1_KREDITF, _MO_M2_KREDITF, _MO_M3_KREDITF, _MO_M4_KREDITF, _MO_M5_KREDITF, _MO_M6_KREDITF, 
				BagiSaldo, BagiDebet, BagiDebetF, BagiKredit, BagiKreditF, RataSaldo, _MO_LIMITKREDIT;

			BagiSaldo = 0;
			BagiDebet = 0;
			BagiDebetF = 0;
			BagiKredit = 0;
			BagiKreditF = 0;

			//-----------------------------------------------------------------saldo rata-rata
			try {_MO_M1_SLDRATA = Double.Parse(this.txt_MO_M1_SLDRATA.Text);} 
			catch {_MO_M1_SLDRATA = 0;}
			if (_MO_M1_SLDRATA != 0) BagiSaldo++;

			try {_MO_M2_SLDRATA = Double.Parse(this.txt_MO_M2_SLDRATA.Text);} 
			catch {_MO_M2_SLDRATA = 0;}
			if (_MO_M2_SLDRATA != 0) BagiSaldo++;

			try {_MO_M3_SLDRATA = Double.Parse(this.txt_MO_M3_SLDRATA.Text);} 
			catch {_MO_M3_SLDRATA = 0;}
			if (_MO_M3_SLDRATA != 0) BagiSaldo++;

			try {_MO_M4_SLDRATA = Double.Parse(this.txt_MO_M4_SLDRATA.Text);} 
			catch {_MO_M4_SLDRATA = 0;}
			if (_MO_M4_SLDRATA != 0) BagiSaldo++;

			try {_MO_M5_SLDRATA = Double.Parse(this.txt_MO_M5_SLDRATA.Text);} 
			catch {_MO_M5_SLDRATA = 0;}
			if (_MO_M5_SLDRATA != 0) BagiSaldo++;

			try {_MO_M6_SLDRATA = Double.Parse(this.txt_MO_M6_SLDRATA.Text);} 
			catch {_MO_M6_SLDRATA = 0;}
			if (_MO_M6_SLDRATA != 0) BagiSaldo++;

			//-----------------------------------------------------------------debet
			try {_MO_M1_DEBET = Double.Parse(this.txt_MO_M1_DEBET.Text);} 
			catch {_MO_M1_DEBET = 0;}
			if (_MO_M1_DEBET != 0) BagiDebet++;

			try {_MO_M2_DEBET = Double.Parse(this.txt_MO_M2_DEBET.Text);} 
			catch {_MO_M2_DEBET = 0;}
			if (_MO_M2_DEBET != 0) BagiDebet++;

			try {_MO_M3_DEBET = Double.Parse(this.txt_MO_M3_DEBET.Text);} 
			catch {_MO_M3_DEBET = 0;}
			if (_MO_M3_DEBET != 0) BagiDebet++;

			try {_MO_M4_DEBET = Double.Parse(this.txt_MO_M4_DEBET.Text);} 
			catch {_MO_M4_DEBET = 0;}
			if (_MO_M4_DEBET != 0) BagiDebet++;

			try {_MO_M5_DEBET = Double.Parse(this.txt_MO_M5_DEBET.Text);} 
			catch {_MO_M5_DEBET = 0;}
			if (_MO_M5_DEBET != 0) BagiDebet++;

			try {_MO_M6_DEBET = Double.Parse(this.txt_MO_M6_DEBET.Text);} 
			catch {_MO_M6_DEBET = 0;}
			if (_MO_M6_DEBET != 0) BagiDebet++;

			//-----------------------------------------------------------------frekuensi debet
			try {_MO_M1_DEBETF = Double.Parse(this.txt_MO_M1_DEBETF.Text);} 
			catch {_MO_M1_DEBETF = 0;}
			if (_MO_M1_DEBETF != 0) BagiDebetF++;

			try {_MO_M2_DEBETF = Double.Parse(this.txt_MO_M2_DEBETF.Text);} 
			catch {_MO_M2_DEBETF = 0;}
			if (_MO_M2_DEBETF != 0) BagiDebetF++;

			try {_MO_M3_DEBETF = Double.Parse(this.txt_MO_M3_DEBETF.Text);} 
			catch {_MO_M3_DEBETF = 0;}
			if (_MO_M3_DEBETF != 0) BagiDebetF++;

			try {_MO_M4_DEBETF = Double.Parse(this.txt_MO_M4_DEBETF.Text);} 
			catch {_MO_M4_DEBETF = 0;}
			if (_MO_M4_DEBETF != 0) BagiDebetF++;

			try {_MO_M5_DEBETF = Double.Parse(this.txt_MO_M5_DEBETF.Text);} 
			catch {_MO_M5_DEBETF = 0;}
			if (_MO_M5_DEBETF != 0) BagiDebetF++;

			try {_MO_M6_DEBETF = Double.Parse(this.txt_MO_M6_DEBETF.Text);} 
			catch {_MO_M6_DEBETF = 0;}
			if (_MO_M6_DEBETF != 0) BagiDebetF++;

			//-----------------------------------------------------------------kredit
			try {_MO_M1_KREDIT = Double.Parse(this.txt_MO_M1_KREDIT.Text);} 
			catch {_MO_M1_KREDIT = 0;}
			if (_MO_M1_KREDIT != 0) BagiKredit++;

			try {_MO_M2_KREDIT = Double.Parse(this.txt_MO_M2_KREDIT.Text);} 
			catch {_MO_M2_KREDIT = 0;}
			if (_MO_M2_KREDIT != 0) BagiKredit++;

			try {_MO_M3_KREDIT = Double.Parse(this.txt_MO_M3_KREDIT.Text);} 
			catch {_MO_M3_KREDIT = 0;}
			if (_MO_M3_KREDIT != 0) BagiKredit++;

			try {_MO_M4_KREDIT = Double.Parse(this.txt_MO_M4_KREDIT.Text);} 
			catch {_MO_M4_KREDIT = 0;}
			if (_MO_M4_KREDIT != 0) BagiKredit++;

			try {_MO_M5_KREDIT = Double.Parse(this.txt_MO_M5_KREDIT.Text);} 
			catch {_MO_M5_KREDIT = 0;}
			if (_MO_M5_KREDIT != 0) BagiKredit++;

			try {_MO_M6_KREDIT = Double.Parse(this.txt_MO_M6_KREDIT.Text);} 
			catch {_MO_M6_KREDIT = 0;}
			if (_MO_M6_KREDIT != 0) BagiKredit++;

			//-----------------------------------------------------------------frekuensi kredit
			try {_MO_M1_KREDITF = Double.Parse(this.txt_MO_M1_KREDITF.Text);} 
			catch {_MO_M1_KREDITF = 0;}
			if (_MO_M1_KREDITF != 0) BagiKreditF++;

			try {_MO_M2_KREDITF = Double.Parse(this.txt_MO_M2_KREDITF.Text);} 
			catch {_MO_M2_KREDITF = 0;}
			if (_MO_M2_KREDITF != 0) BagiKreditF++;

			try {_MO_M3_KREDITF = Double.Parse(this.txt_MO_M3_KREDITF.Text);} 
			catch {_MO_M3_KREDITF = 0;}
			if (_MO_M3_KREDITF != 0) BagiKreditF++;

			try {_MO_M4_KREDITF = Double.Parse(this.txt_MO_M4_KREDITF.Text);} 
			catch {_MO_M4_KREDITF = 0;}
			if (_MO_M4_KREDITF != 0) BagiKreditF++;

			try {_MO_M5_KREDITF = Double.Parse(this.txt_MO_M5_KREDITF.Text);} 
			catch {_MO_M5_KREDITF = 0;}
			if (_MO_M5_KREDITF != 0) BagiKreditF++;

			try {_MO_M6_KREDITF = Double.Parse(this.txt_MO_M6_KREDITF.Text);} 
			catch {_MO_M6_KREDITF = 0;}
			if (_MO_M6_KREDITF != 0) BagiKreditF++;

			try {_MO_LIMITKREDIT  = Double.Parse(this.txt_MO_LIMITKREDIT.Text);} 
			catch {_MO_LIMITKREDIT  = 0;}


			//-----------------------------------------------------------------
			TotSaldo = _MO_M1_SLDRATA + _MO_M2_SLDRATA + _MO_M3_SLDRATA + _MO_M4_SLDRATA + _MO_M5_SLDRATA + _MO_M6_SLDRATA;

			TotDebet = _MO_M1_DEBET + _MO_M2_DEBET + _MO_M3_DEBET + _MO_M4_DEBET + _MO_M5_DEBET + _MO_M6_DEBET;

			TotDebetF = _MO_M1_DEBETF + _MO_M2_DEBETF + _MO_M3_DEBETF + _MO_M4_DEBETF + _MO_M5_DEBETF + _MO_M6_DEBETF;

			TotKredit = _MO_M1_KREDIT + _MO_M2_KREDIT + _MO_M3_KREDIT + _MO_M4_KREDIT + _MO_M5_KREDIT + _MO_M6_KREDIT;

			TotKreditF = _MO_M1_KREDITF + _MO_M2_KREDITF + _MO_M3_KREDITF + _MO_M4_KREDITF + _MO_M5_KREDITF + _MO_M6_KREDITF;

			this.txt_TotSaldoOB.Text = tool.MoneyFormat(Convert.ToString(TotSaldo));
			this.txt_TotDebetOB.Text = tool.MoneyFormat(Convert.ToString(TotDebet));
			this.txt_TotDebetFOB.Text = Convert.ToString(TotDebetF);
			this.txt_TotKreditOB.Text = tool.MoneyFormat(Convert.ToString(TotKredit));
			this.txt_TotKreditFOB.Text = Convert.ToString(TotKreditF);


			RataSaldo = TotSaldo / (BagiSaldo == 0 ? 1 : BagiSaldo);
			this.txt_RataSaldoOB.Text = tool.MoneyFormat(Convert.ToString(RataSaldo));
			this.txt_RataDebetOB.Text = tool.MoneyFormat(Convert.ToString(TotDebet / (BagiDebet == 0 ? 1 : BagiDebet)));
			this.txt_RataDebetFOB.Text = tool.MoneyFormat(Convert.ToString(TotDebetF /(BagiDebetF == 0 ? 1 : BagiDebetF)));
			this.txt_RataKreditOB.Text = tool.MoneyFormat(Convert.ToString(TotKredit /(BagiKredit == 0 ? 1 : BagiKredit)));
			this.txt_RataKreditFOB.Text = tool.MoneyFormat(Convert.ToString(TotKreditF /(BagiKreditF == 0 ? 1 : BagiKreditF)));

			if (RataSaldo == 0)
				this.txt_MO_PRSNSALDO.Text = "0";
			else
				this.txt_MO_PRSNSALDO.Text = tool.MoneyFormat(Convert.ToString(_MO_LIMITKREDIT / RataSaldo));

		}

		private void ViewSaldoRata()
		{ 
			conn.QueryString = "select * from VW_MUTASI_REKENING where AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			try
			{
				try {Tools.fromSQLDate(conn.GetFieldValue("MR_M1_BLN"), this.txt_TempDD, this.ddl_MR_M1_BLN_mm, this.txt_MR_M1_BLN_yy);}
				catch {}
				this.txt_MR_M1_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M1_SLDRATA"));
				this.txt_MR_M1_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M1_DEBET"));
				this.txt_MR_M1_DEBETF.Text = conn.GetFieldValue("MR_M1_DEBETF");
				this.txt_MR_M1_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M1_KREDIT"));
				this.txt_MR_M1_KREDITF.Text = conn.GetFieldValue("MR_M1_KREDITF");
 
				try {Tools.fromSQLDate(conn.GetFieldValue("MR_M2_BLN"), this.txt_TempDD, this.ddl_MR_M2_BLN_mm, this.txt_MR_M2_BLN_yy);}
				catch {}
				this.txt_MR_M2_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M2_SLDRATA"));
				this.txt_MR_M2_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M2_DEBET"));
				this.txt_MR_M2_DEBETF.Text = conn.GetFieldValue("MR_M2_DEBETF");
				this.txt_MR_M2_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M2_KREDIT"));
				this.txt_MR_M2_KREDITF.Text = conn.GetFieldValue("MR_M2_KREDITF");

				try {Tools.fromSQLDate(conn.GetFieldValue("MR_M3_BLN"), this.txt_TempDD, this.ddl_MR_M3_BLN_mm, this.txt_MR_M3_BLN_yy);}
				catch {}
				this.txt_MR_M3_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M3_SLDRATA"));
				this.txt_MR_M3_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M3_DEBET"));
				this.txt_MR_M3_DEBETF.Text = conn.GetFieldValue("MR_M3_DEBETF");
				this.txt_MR_M3_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M3_KREDIT"));
				this.txt_MR_M3_KREDITF.Text = conn.GetFieldValue("MR_M3_KREDITF");

				try {Tools.fromSQLDate(conn.GetFieldValue("MR_M4_BLN"), this.txt_TempDD, this.ddl_MR_M4_BLN_mm, this.txt_MR_M4_BLN_yy);}
				catch {}
				this.txt_MR_M4_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M4_SLDRATA"));
				this.txt_MR_M4_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M4_DEBET"));
				this.txt_MR_M4_DEBETF.Text = conn.GetFieldValue("MR_M4_DEBETF");
				this.txt_MR_M4_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M4_KREDIT"));
				this.txt_MR_M4_KREDITF.Text = conn.GetFieldValue("MR_M4_KREDITF");

				try {Tools.fromSQLDate(conn.GetFieldValue("MR_M5_BLN"), this.txt_TempDD, this.ddl_MR_M5_BLN_mm, this.txt_MR_M5_BLN_yy);}
				catch {}
				this.txt_MR_M5_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M5_SLDRATA"));
				this.txt_MR_M5_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M5_DEBET"));
				this.txt_MR_M5_DEBETF.Text = conn.GetFieldValue("MR_M5_DEBETF");
				this.txt_MR_M5_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M5_KREDIT"));
				this.txt_MR_M5_KREDITF.Text = conn.GetFieldValue("MR_M5_KREDITF");

				try {Tools.fromSQLDate(conn.GetFieldValue("MR_M6_BLN"), this.txt_TempDD, this.ddl_MR_M6_BLN_mm, this.txt_MR_M6_BLN_yy);}
				catch {}
				this.txt_MR_M6_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M6_SLDRATA"));
				this.txt_MR_M6_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M6_DEBET"));
				this.txt_MR_M6_DEBETF.Text = conn.GetFieldValue("MR_M6_DEBETF");
				this.txt_MR_M6_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M6_KREDIT"));
				this.txt_MR_M6_KREDITF.Text = conn.GetFieldValue("MR_M6_KREDITF");
				
				this.txt_MR_M1_SALDO.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M1_SALDO"));
				this.txt_MR_LIMITKREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MR_LIMITKREDIT"));
				this.txt_MR_PRSNSALDO.Text = conn.GetFieldValue("MR_PRSNSALDO");
				this.txt_MR_CATATAN.Text = conn.GetFieldValue("MR_CATATAN");
			}
			catch {}
		}

		private void ViewSaldoRataOB()
		{ 
			conn.QueryString = "select * from VW_MUTASI_REKENING_OTHER_BANK where AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			try
			{

				try {GlobalTools.fillDateForm(this.txt_TempDD, this.ddl_MO_M1_BLN_mm, this.txt_MO_M1_BLN_yy, Convert.ToDateTime(conn.GetFieldValue("MO_M1_BLN")));}
				catch {}
				this.txt_MO_M1_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M1_SLDRATA"));
				this.txt_MO_M1_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M1_DEBET"));
				this.txt_MO_M1_DEBETF.Text = conn.GetFieldValue("MO_M1_DEBETF");
				this.txt_MO_M1_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M1_KREDIT"));
				this.txt_MO_M1_KREDITF.Text = conn.GetFieldValue("MO_M1_KREDITF");
 
				try {GlobalTools.fillDateForm(this.txt_TempDD, this.ddl_MO_M2_BLN_mm, this.txt_MO_M2_BLN_yy, Convert.ToDateTime(conn.GetFieldValue("MO_M2_BLN")));}
				catch {}
				this.txt_MO_M2_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M2_SLDRATA"));
				this.txt_MO_M2_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M2_DEBET"));
				this.txt_MO_M2_DEBETF.Text = conn.GetFieldValue("MO_M2_DEBETF");
				this.txt_MO_M2_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M2_KREDIT"));
				this.txt_MO_M2_KREDITF.Text = conn.GetFieldValue("MO_M2_KREDITF");

				try {GlobalTools.fillDateForm(this.txt_TempDD, this.ddl_MO_M3_BLN_mm, this.txt_MO_M3_BLN_yy, Convert.ToDateTime(conn.GetFieldValue("MO_M3_BLN")));}
				catch {}
				this.txt_MO_M3_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M3_SLDRATA"));
				this.txt_MO_M3_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M3_DEBET"));
				this.txt_MO_M3_DEBETF.Text = conn.GetFieldValue("MO_M3_DEBETF");
				this.txt_MO_M3_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M3_KREDIT"));
				this.txt_MO_M3_KREDITF.Text = conn.GetFieldValue("MO_M3_KREDITF");

				try {GlobalTools.fillDateForm(this.txt_TempDD, this.ddl_MO_M4_BLN_mm, this.txt_MO_M4_BLN_yy, Convert.ToDateTime(conn.GetFieldValue("MO_M4_BLN")));}
				catch {}
				this.txt_MO_M4_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M4_SLDRATA"));
				this.txt_MO_M4_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M4_DEBET"));
				this.txt_MO_M4_DEBETF.Text = conn.GetFieldValue("MO_M4_DEBETF");
				this.txt_MO_M4_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M4_KREDIT"));
				this.txt_MO_M4_KREDITF.Text = conn.GetFieldValue("MO_M4_KREDITF");

				try {GlobalTools.fillDateForm(this.txt_TempDD, this.ddl_MO_M5_BLN_mm, this.txt_MO_M5_BLN_yy, Convert.ToDateTime(conn.GetFieldValue("MO_M5_BLN")));}
				catch {}
				this.txt_MO_M5_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M5_SLDRATA"));
				this.txt_MO_M5_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M5_DEBET"));
				this.txt_MO_M5_DEBETF.Text = conn.GetFieldValue("MO_M5_DEBETF");
				this.txt_MO_M5_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M5_KREDIT"));
				this.txt_MO_M5_KREDITF.Text = conn.GetFieldValue("MO_M5_KREDITF");

				try {GlobalTools.fillDateForm(this.txt_TempDD, this.ddl_MO_M6_BLN_mm, this.txt_MO_M6_BLN_yy, Convert.ToDateTime(conn.GetFieldValue("MO_M6_BLN")));}
				catch {}
				this.txt_MO_M6_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M6_SLDRATA"));
				this.txt_MO_M6_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M6_DEBET"));
				this.txt_MO_M6_DEBETF.Text = conn.GetFieldValue("MO_M6_DEBETF");
				this.txt_MO_M6_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M6_KREDIT"));
				this.txt_MO_M6_KREDITF.Text = conn.GetFieldValue("MO_M6_KREDITF");

				this.txt_MO_M1_SALDO.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M1_SALDO"));
				this.txt_MO_LIMITKREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MO_LIMITKREDIT"));
				this.txt_MO_PRSNSALDO.Text = conn.GetFieldValue("MO_PRSNSALDO");
				this.txt_MO_CATATAN.Text = conn.GetFieldValue("MO_CATATAN");
			}
			catch {}
		}

		private void CheckNama()
		{
			string CM_ATASNAMA;

			if (LBL_CM_ATASNAMA.Text == "1")		// Atas Nama Group
			{
				LBL_ATASNAMA.Text	= "Atas Nama Group";
				CM_ATASNAMA	= LBL_CM_ATASNAMA.Text;
//				namaPerusahaan.Visible = true;
				DatGridMandiriLoan.Columns[1].Visible = true;
				this.TBL_SALDO_RATA.Visible = false;
				this.TBL_SALDO_RATA_OB.Visible = false;

				this.br00.Visible = true;
				this.br01.Visible = true;
				this.br02.Visible = true;
				this.br03.Visible = true;
				this.br04.Visible = true;
				this.br05.Visible = true;
				this.br06.Visible = true;
				this.br07.Visible = true;
				this.br08.Visible = true;
				this.br09.Visible = true;
//				this.br10.Visible = true;
//				this.br11.Visible = true;
//				this.brtombol.Visible = true;

			}
			else if (LBL_CM_ATASNAMA.Text == "2")	// Saldo Rata-rata
			{
				
				LBL_ATASNAMA.Text	= "Saldo Rata-Rata";
				CM_ATASNAMA	= LBL_CM_ATASNAMA.Text;
//				namaPerusahaan.Visible = false;
				DatGridMandiriLoan.Columns[1].Visible = false;
				this.TBL_SALDO_RATA.Visible = true;
				this.TBL_SALDO_RATA_OB.Visible = true;

				this.br00.Visible = false;
				this.br01.Visible = false;
				this.br02.Visible = false;
				this.br03.Visible = false;
				this.br04.Visible = false;
				this.br05.Visible = false;
				this.br06.Visible = false;
				this.br07.Visible = false;
				this.br08.Visible = false;
				this.br09.Visible = false;
//				this.br10.Visible = false;
//				this.br11.Visible = false;
//				this.brtombol.Visible = false;


			}
			else if (LBL_CM_ATASNAMA.Text == "0")	// Atas Nama Nasabah
			{
				LBL_ATASNAMA.Text	= "Atas Nama Nasabah";
				LBL_CM_ATASNAMA.Text = "0";
				CM_ATASNAMA	= "0";
//				namaPerusahaan.Visible = false;
				DatGridMandiriLoan.Columns[1].Visible = false;
				this.TBL_SALDO_RATA.Visible = false;
				this.TBL_SALDO_RATA_OB.Visible = false;

				this.br00.Visible = true;
				this.br01.Visible = true;
				this.br02.Visible = true;
				this.br03.Visible = true;
				this.br04.Visible = true;
				this.br05.Visible = true;
				this.br06.Visible = true;
				this.br07.Visible = true;
				this.br08.Visible = true;
				this.br09.Visible = true;
//				this.br10.Visible = true;
//				this.br11.Visible = true;
//				this.brtombol.Visible = true;

			}
			else 
			{
				LBL_ATASNAMA.Text	= "Atas Nama -";
				LBL_CM_ATASNAMA.Text = "";
				CM_ATASNAMA	= "";
			}
		}

		private void ViewMandiriLoan()
		{
			//string CM_ATASNAMA = LBL_CM_ATASNAMA.Text;
			string CM_ATASNAMA ="";
			if (Request.QueryString["code"]!=null)
			{
				CM_ATASNAMA = Request.QueryString["code"];
			}
			else
			{
				CM_ATASNAMA = "0";
			}
			double TotLimit = 0, bakiDebet = 0;
			double Total = 0;

			DataTable dt = new DataTable();
			conn.QueryString = "select * from VW_BACKUP_CUSTMANDIRILOAN where CM_ATASNAMA = '" +CM_ATASNAMA+ "' and ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGridMandiriLoan.DataSource = dt;
			DatGridMandiriLoan.DataBind();
			for (int i = 0; i < DatGridMandiriLoan.Items.Count; i++)
			{
				DatGridMandiriLoan.Items[i].Cells[4].Text = tool.MoneyFormat(DatGridMandiriLoan.Items[i].Cells[4].Text);
				DatGridMandiriLoan.Items[i].Cells[5].Text = tool.MoneyFormat(DatGridMandiriLoan.Items[i].Cells[5].Text);
				DatGridMandiriLoan.Items[i].Cells[6].Text = tool.MoneyFormat(DatGridMandiriLoan.Items[i].Cells[6].Text);
				DatGridMandiriLoan.Items[i].Cells[7].Text = tool.MoneyFormat(DatGridMandiriLoan.Items[i].Cells[7].Text);
				TotLimit = TotLimit + double.Parse(DatGridMandiriLoan.Items[i].Cells[4].Text);
				bakiDebet = bakiDebet + double.Parse(DatGridMandiriLoan.Items[i].Cells[5].Text);
				// endi 
				if (DatGridMandiriLoan.Items[i].Cells[5].Text != "0,00")
					Total = Total + double.Parse(DatGridMandiriLoan.Items[i].Cells[5].Text);
				else
					Total = Total + double.Parse(DatGridMandiriLoan.Items[i].Cells[4].Text);

				//---------- Protection Screen -----------------------------dsafaf
				if (Request.QueryString["de"] != "1") 
				{
					LinkButton LNK_DELETE	= (LinkButton) DatGridMandiriLoan.Items[i].FindControl("LinkButton1");
					LNK_DELETE.Visible		= false;
				}
				//---------- Protection Screen -----------------------------
			}
			//TotLimit = TotLimit + bakiDebet;
			//LBL_SUBTOTAL.Text	= "Sum of Limit Kredit " + " Above";//+ LBL_ATASNAMA.Text;sadfsda

			TXT_SUBTOTAL.Text   = tool.MoneyFormat(TotLimit.ToString());

			conn.QueryString = "exec DE_CALCULATE_TOTALEXPOSURE '" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			TXT_TOTAL.Text = tool.MoneyFormat(conn.GetFieldValue(0,"GROUP_EXPOSURE"));

		}

		private void ViewOtherLoan()
		{
			DataTable dt = new DataTable();
			conn.QueryString = "select * from VW_BACKUP_CUSTOTHERLOAN where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGridOtherLoan.DataSource = dt;
			DatGridOtherLoan.DataBind();
			for (int i = 0; i < DatGridOtherLoan.Items.Count; i++)
			{
				DatGridOtherLoan.Items[i].Cells[4].Text = tool.MoneyFormat(DatGridOtherLoan.Items[i].Cells[4].Text);
				DatGridOtherLoan.Items[i].Cells[5].Text = tool.MoneyFormat(DatGridOtherLoan.Items[i].Cells[5].Text);
				DatGridOtherLoan.Items[i].Cells[6].Text = tool.MoneyFormat(DatGridOtherLoan.Items[i].Cells[6].Text);
				DatGridOtherLoan.Items[i].Cells[7].Text = tool.MoneyFormat(DatGridOtherLoan.Items[i].Cells[7].Text);
				//DatGridOtherLoan.Items[i].Cells[10].Text = DatGrid

				//---------- Protection Screen -----------------------------//
				if (Request.QueryString["de"] != "1") 
				{
					LinkButton LNK_DELETE	= (LinkButton) DatGridOtherLoan.Items[i].FindControl("LNK_DELETE");
					LNK_DELETE.Visible		= false;
					//DatGridOtherLoan.Items[i].Cells[12].Text = "Delete";
					//DatGridOtherLoan.Items[i].Cells[12].Enabled = false;
				}
				//---------- Protection Screen -----------------------------//
			}
		}

		private void viewDDL()
		{
			GlobalTools.initDateForm(TXT_CI_BMDEBITUR_DAY, DDL_CI_BMDEBITUR_MONTH, TXT_CI_BMDEBITUR_YEAR);
			GlobalTools.initDateForm(TXT_CI_BMGIRO_DAY, DDL_CI_BMGIRO_MONTH, TXT_CI_BMGIRO_YEAR);
			GlobalTools.initDateForm(TXT_CI_BMSAVING_DAY, DDL_CI_BMSAVING_MONTH, TXT_CI_BMSAVING_YEAR);

			/*
			string nm_bln=""; 
			DDL_CI_BMGIRO_MONTH.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CI_BMSAVING_MONTH.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CI_BMDEBITUR_MONTH.Items.Add(new ListItem("- PILIH -", ""));
			for (int i=1; i<=12; i++) {
				nm_bln = DateAndTime.MonthName(i, false);
				DDL_CI_BMGIRO_MONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
				DDL_CI_BMSAVING_MONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
				DDL_CI_BMDEBITUR_MONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
			}
			*/
		}

		private void viewLinkAtasNama()
		{
			try
			{
				HPL_ATASNAMA0.NavigateUrl = "BankRelation.aspx?regno="+Request.QueryString["regno"]+"&curef="+Request.QueryString["curef"]+"&code=0"+"&mc="+Request.QueryString["mc"] + "&de=" + Request.QueryString["de"]+"&tc="+Request.QueryString["tc"]+"&par="+Request.QueryString["par"];
				HPL_ATASNAMA1.NavigateUrl = "BankRelation.aspx?regno="+Request.QueryString["regno"]+"&curef="+Request.QueryString["curef"]+"&code=1"+"&mc="+Request.QueryString["mc"] + "&de=" + Request.QueryString["de"]+"&tc="+Request.QueryString["tc"]+"&par="+Request.QueryString["par"];
				HPL_SALDORATA.NavigateUrl = "BankRelation.aspx?regno="+Request.QueryString["regno"]+"&curef="+Request.QueryString["curef"]+"&code=2"+"&mc="+Request.QueryString["mc"] + "&de=" + Request.QueryString["de"]+"&tc="+Request.QueryString["tc"]+"&par="+Request.QueryString["par"];
			}
			catch
			{
			}

		}

		private void ViewDebiturSejak()
		{
			conn.QueryString = "select * from BACKUP_COMPANY_INFO "+
				" where ap_regno = '"+ Request.QueryString["regno"] +"' " ;
			conn.ExecuteQuery();
			string CI_BMGIRO			= conn.GetFieldValue("CI_BMGIRO");
			TXT_CI_BMGIRO_DAY.Text		= tool.FormatDate_Day(CI_BMGIRO);
			DDL_CI_BMGIRO_MONTH.SelectedValue = tool.FormatDate_Month(CI_BMGIRO);
			TXT_CI_BMGIRO_YEAR.Text		= tool.FormatDate_Year(CI_BMGIRO);
			string CI_BMSAVING			= conn.GetFieldValue("CI_BMSAVING");
			TXT_CI_BMSAVING_DAY.Text		= tool.FormatDate_Day(CI_BMSAVING);
			DDL_CI_BMSAVING_MONTH.SelectedValue = tool.FormatDate_Month(CI_BMSAVING);
			TXT_CI_BMSAVING_YEAR.Text	= tool.FormatDate_Year(CI_BMSAVING);
			string CI_BMDEBITUR			= conn.GetFieldValue("CI_BMDEBITUR");
			TXT_CI_BMDEBITUR_DAY.Text	= tool.FormatDate_Day(CI_BMDEBITUR);
			DDL_CI_BMDEBITUR_MONTH.SelectedValue = tool.FormatDate_Month(CI_BMDEBITUR);
			TXT_CI_BMDEBITUR_YEAR.Text	= tool.FormatDate_Year(CI_BMDEBITUR);
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						if (conn.GetFieldValue(i,3).IndexOf("?de=") < 0 && conn.GetFieldValue(i,3).IndexOf("&de=") < 0) 
							strtemp = strtemp + "&de=" + Request.QueryString["de"];	
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"];
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}
		private void viewSubMenu() 
		{
			try 
			{
				conn.QueryString = "select * from SCREENSUBMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, "SM_MENUDISPLAY");
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, "SM_LINKNAME").Trim()!= "") 
					{						
						if (conn.GetFieldValue(i,"SM_LINKNAME").IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];

						if (conn.GetFieldValue(i,"SM_LINKNAME").IndexOf("?de=") < 0 && conn.GetFieldValue(i, "SM_LINKNAME").IndexOf("&de=") < 0) 
							strtemp = strtemp + "&de=" + Request.QueryString["de"];	

						if (conn.GetFieldValue(i,"SM_LINKNAME").IndexOf("?par=") < 0 && conn.GetFieldValue(i, "SM_LINKNAME").IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"];
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, "SM_LINKNAME")+strtemp;					
					PH_SUBMENU.Controls.Add(t);
					PH_SUBMENU.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void ViewData()
		{
			conn.QueryString = "select * from VW_DE_HUBUNGANBANK_HISTORY where AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			TXT_CI_BMGIRO_DAY.Text					= tool.FormatDate_Day(conn.GetFieldValue("CI_BMGIRO"));
			DDL_CI_BMGIRO_MONTH.SelectedValue		= tool.FormatDate_Month(conn.GetFieldValue("CI_BMGIRO"));
			TXT_CI_BMGIRO_YEAR.Text					= tool.FormatDate_Year(conn.GetFieldValue("CI_BMGIRO"));
			TXT_CI_BMSAVING_DAY.Text				= tool.FormatDate_Day(conn.GetFieldValue("CI_BMSAVING"));
			DDL_CI_BMSAVING_MONTH.SelectedValue		= tool.FormatDate_Month(conn.GetFieldValue("CI_BMSAVING"));
			TXT_CI_BMSAVING_YEAR.Text				= tool.FormatDate_Year(conn.GetFieldValue("CI_BMSAVING"));
			TXT_CI_BMDEBITUR_DAY.Text				= tool.FormatDate_Day(conn.GetFieldValue("CI_BMDEBITUR"));
			DDL_CI_BMDEBITUR_MONTH.SelectedValue	= tool.FormatDate_Month(conn.GetFieldValue("CI_BMDEBITUR"));
			TXT_CI_BMDEBITUR_YEAR.Text				= tool.FormatDate_Year(conn.GetFieldValue("CI_BMDEBITUR"));
			TXT_CA_NOTE.Text						= conn.GetFieldValue("CA_NOTE");
			if (conn.GetFieldValue("CA_ACCOUNTSTATUS") == "1")
				RDO_CA_ACCOUNTSTATUS1.Checked = true;
			else
				RDO_CA_ACCOUNTSTATUS0.Checked = true;
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

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink("", Request.QueryString["mc"], conn));
		}
	}
}
