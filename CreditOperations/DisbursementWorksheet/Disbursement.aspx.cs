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

namespace SourceSMEReport
{
	/// <summary>
	/// Summary description for Disbursement.
	/// </summary>
	public partial class Disbursement : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.204.9.78;Initial Catalog=SME;uid=sa;pwd=");
		protected Connection conn;
		protected System.Web.UI.WebControls.Label LBL_TENOR;
		protected System.Web.UI.WebControls.Label LBL_CPLIMIT;
		protected Tools tools = new Tools();
		
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			if (!IsPostBack)
			{
				LBL_CASH.Text		= Request.QueryString["cash"];
				LBL_APREGNO.Text	= Request.QueryString["regno"];
				LBL_PRODUCTID.Text	= Request.QueryString["prodid"];
				//LBL_APPTYPE1.Text	= Request.QueryString["apptype"];
				LBL_KET_CODE.Text	= Request.QueryString["ket_code"];
				LBL_PROD_SEQ.Text	= Request.QueryString["prod_seq"];
				LBL_PRINT.Text		= tools.FormatDate(DateTime.Today.ToString());
				ViewReport();
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

		private void ViewReport()
		{
			string ket_code = LBL_KET_CODE.Text.Trim();
			ViewCustInfo();
			
			conn.QueryString = "select distinct apptype from custproduct where ket_code = '" + ket_code + "'";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();
	
			for (int i=0;i<dt.Rows.Count;i++)
			{
				if (dt.Rows[i][0].ToString()=="01")
				{
					ViewSK01(dt.Rows[i][0].ToString());
					AltenateRate(dt.Rows[i][0].ToString());
					PaymentSchedule(dt.Rows[i][0].ToString());
					DrawdownSchedule(dt.Rows[i][0].ToString());
					//--new --
					show_nomor(dt.Rows[i][0].ToString());
				}
				else if (dt.Rows[i][0].ToString()=="02")
					ViewSK02(dt.Rows[i][0].ToString());
				else if (dt.Rows[i][0].ToString()=="03")
					ViewSK03(dt.Rows[i][0].ToString());
				else if (dt.Rows[i][0].ToString()=="04")
				{
					ViewSK04(dt.Rows[i][0].ToString());
					AltenateRate(dt.Rows[i][0].ToString());
					PaymentSchedule(dt.Rows[i][0].ToString());
					DrawdownSchedule(dt.Rows[i][0].ToString());
					//--new
					show_nomor(dt.Rows[i][0].ToString());
				}
				else if (dt.Rows[i][0].ToString()=="05")
					ViewSK05(dt.Rows[i][0].ToString());
				else if (dt.Rows[i][0].ToString()=="06")
					ViewSK06(dt.Rows[i][0].ToString());
			}
			ViewBEA();
			ViewCollateral();
			ViewDocument();
			CollateralDetail();
		}
			
		private void ViewCustInfo()
		{
			conn.QueryString = "select CU_CUSTTYPEID, CU_NAME, CU_IDCARD, CU_DOB, CU_CPERSON, CU_PHN, CU_CIF, CU_NPWP "+
				"from VW_CUSTOMER_KETKREDIT where AP_REGNO='"+LBL_APREGNO.Text+"' and PRODUCTID='"+LBL_PRODUCTID.Text+"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			//and KET_CODE='"+LBL_KET_CODE.Text+"' 
			conn.ExecuteQuery();
			LBL_NAME.Text		= conn.GetFieldValue("CU_NAME");
			LBL_IDCARD.Text		= conn.GetFieldValue("CU_IDCARD");
			if (conn.GetFieldValue("CU_CUSTTYPEID").Trim()=="02")
			{
				LBL_DOB.Text		= tools.FormatDate(conn.GetFieldValue("CU_DOB"));
				LBL_DOBTEXT.Text	= "Date Of Birth";
				LBL_ID.Text			= "KTP";
			}
			else
			{
				LBL_DOB.Text		= tools.FormatDate_MonthName(conn.GetFieldValue("CU_DOB"))+" "+tools.FormatDate_Year(conn.GetFieldValue("CU_DOB"));
				LBL_DOBTEXT.Text	= "Berdiri Sejak";
				LBL_ID.Text			= "TDP";
			}
			LBL_CPERSON.Text	= conn.GetFieldValue("CU_CPERSON");
			LBL_PHONE.Text		= conn.GetFieldValue("CU_PHN");
			LBL_CIF.Text		= conn.GetFieldValue("CU_CIF");
			LBL_NPWP.Text		= conn.GetFieldValue("CU_NPWP");
			conn.ClearData();

			conn.QueryString = "select ad_date, su_fullname "+
				"from VW_REPORT_DISBURSHEET1_KETKREDIT a "+
				"where a.ap_regno='"+LBL_APREGNO.Text+"' and a.productid='"+LBL_PRODUCTID.Text+"' and a.ket_code='"+LBL_KET_CODE.Text+"' "+
				"and a.ad_seq=(select max(ad.ad_seq) from VW_REPORT_DISBURSHEET1_KETKREDIT ad "+
				"where ad.ap_regno='"+LBL_APREGNO.Text+"' and ad.productid='"+LBL_PRODUCTID.Text+"' and left(ad.groupid,2)='01') ";
			 //and ad.ket_code='"+LBL_KET_CODE.Text+"'
			conn.ExecuteQuery();
			LBL_BUAPPR.Text	= conn.GetFieldValue("SU_FULLNAME")+", "+tools.FormatDate(conn.GetFieldValue("AD_DATE"));
			conn.ClearData();
		}

		private void Query(string vapptype)
		{
			conn.QueryString = "select * "+
				"from VW_REPORT_DISBURSHEET1_KETKREDIT a "+
				"where a.ap_regno='"+LBL_APREGNO.Text+"' and a.productid='"+LBL_PRODUCTID.Text+"' and a.apptype='"+vapptype+"' "+
				"and a.ad_seq=(select max(ad.ad_seq) from approval_decision ad "+
				"where ad.ap_regno='"+LBL_APREGNO.Text+"' and ad.productid='"+LBL_PRODUCTID.Text+"' and ad.apptype='"+vapptype+"') ";
			conn.ExecuteQuery();
		}

		private void QueryIDC()
		{
			conn.QueryString = "select IDC_CAPAMNT, IDC_CAPRATIO, IDC_JWAKTU, IDC_PRIMEVARCODE, IDC_RATIO "+
				"from custproduct where AP_REGNO='"+LBL_APREGNO.Text+"' and PRODUCTID='"+LBL_PRODUCTID.Text+"'";
			conn.ExecuteQuery();
		}

		private void ViewSK07()
		{
			Panel07.Visible				= true;
			LBL_07TGLTEMPO.Text			= tools.FormatDate(conn.GetFieldValue("CP_DUEDATE"));
			LBL_07TGLTERBIT.Text		= tools.FormatDate(conn.GetFieldValue("CP_ISSUEDATE"));
			LBL_07DASARMOHON.Text		= conn.GetFieldValue("CP_REQUEST");
			LBL_07DITUJUKAN.Text		= conn.GetFieldValue("CP_ISSUETO");
			LBL_07ALAMATTUJU.Text		= conn.GetFieldValue("almt1");
			LBL_07NMBARANG.Text			= conn.GetFieldValue("CP_COMMODITYNAME");
			LBL_07JML.Text				= conn.GetFieldValue("CP_COMMODITYAMNT");
			LBL_07NILAIFOB.Text			= tools.ConvertCurr(conn.GetFieldValue("CP_VALUE"));
			LBL_07BANKKORES.Text		= conn.GetFieldValue("bankname");
			LBL_07ALAMATBANK.Text		= conn.GetFieldValue("almt2");
		}
		private void ViewSK04(string vapptype)
		{
			Panel04.Visible		= true;
			Query(vapptype);
			string flag					= conn.GetFieldValue("IDC_FLAG").Trim();
			TXT_CPKET.Text				= conn.GetFieldValue("AD_KETERANGAN");
			LBL_CRMAPPR.Text			= conn.GetFieldValue("SU_FULLNAME")+", "+tools.FormatDate(conn.GetFieldValue("AD_DATE"));
			LBL_KET_DESC.Text			= conn.GetFieldValue("KET_DESC");
			LBL_APPDESC.Text			= conn.GetFieldValue("APPTYPEDESC");
			LBL_FACILITY.Text			= conn.GetFieldValue("PRODUCTDESC");
			LBL_SIFATKREDIT.Text		= conn.GetFieldValue("revolving");
			LBL_TUJUANPENGGUNAAN.Text	= conn.GetFieldValue("LOANPURPDESC");
			LBL_CURRENCY.Text			= conn.GetFieldValue("CURRENCY");
			LBL_TENORVALUE.Text			= conn.GetFieldValue("OLD_TENOR");
			LBL_ACCOUNT.Text			= conn.GetFieldValue("acc_no");
			LBL_OLDTENOR.Text			= conn.GetFieldValue("AD_TENOR");
			ViewAcc();
			conn.ClearData();
			conn.QueryString = "SELECT LIMIT FROM BOOKEDPROD WHERE AA_NO='"+LBL_ACCAANO.Text+"' AND ACC_SEQ="+tools.ConvertNum(LBL_ACCSEQ.Text)+" AND PRODUCTID='"+LBL_PRODUCTID.Text+"'";
			conn.ExecuteQuery();
			LBL_LIMIT.Text				= tools.MoneyFormat(conn.GetFieldValue("LIMIT"));
			conn.ClearData();
			if (flag=="1")
				ViewSK041();
		}

		private void ViewSK041()
		{
			Panel041.Visible			= true;
			QueryIDC();
			LBL_IDC_CAPAMNT.Text		= tools.MoneyFormat(conn.GetFieldValue("IDC_CAPAMNT"));
			LBL_IDC_CAPRATIO.Text		= tools.MoneyFormat(conn.GetFieldValue("IDC_CAPRATIO"));
			LBL_IDC_PRIMEVARCODE.Text	= conn.GetFieldValue("idc_interestvalue");
			LBL_IDCJWAKTU.Text			= conn.GetFieldValue("IDC_JWAKTU");
			LBL_IDCRATIO.Text			= tools.MoneyFormat(conn.GetFieldValue("IDC_RATIO"));
			conn.ClearData();
		}

		private void ViewSK05(string vapptype)
		{
			Panel05.Visible				= true;
			Query(vapptype);
			TXT_CPKET.Text				= conn.GetFieldValue("AD_KETERANGAN");
			LBL_CRMAPPR.Text			= conn.GetFieldValue("SU_FULLNAME")+", "+tools.FormatDate(conn.GetFieldValue("AD_DATE"));
			LBL_KET_DESC05.Text			= conn.GetFieldValue("KET_DESC");
			LBL_APPDESC05.Text			= conn.GetFieldValue("APPTYPEDESC");
			LBL_FACILITY05.Text			= conn.GetFieldValue("PRODUCTDESC");
			LBL_SIFATKREDIT05.Text		= conn.GetFieldValue("revolving");
			LBL_CURRENCY05.Text			= conn.GetFieldValue("CURRENCY");
			LBL_ACCOUNT05.Text			= conn.GetFieldValue("acc_no");
			ViewAcc();
			conn.ClearData();
			conn.QueryString = "select bp.limit, convert(varchar,bp.tenor)+' '+isnull(rt.TENORDESC,'') as TENOR "+
				"from bookedprod bp left join rftenorcode rt on bp.tenorcode=rt.tenorcode " +
				"where bp.aa_no='" + LBL_ACCAANO.Text + "' and bp.productid='" + LBL_PRODUCTID.Text + "' and bp.acc_seq=" + tools.ConvertNum(LBL_ACCSEQ.Text);
			conn.ExecuteQuery();
			LBL_LIMIT05.Text			= tools.MoneyFormat(conn.GetFieldValue("LIMIT"));
			LBL_TENORVALUE05.Text		= conn.GetFieldValue("TENOR");
			conn.ClearData();
		}

		private void ViewSK01(string vapptype)
		{
			Panel01.Visible				= true;
			Query(vapptype);
			TXT_CPKET.Text				= conn.GetFieldValue("AD_KETERANGAN");
			LBL_CRMAPPR.Text			= conn.GetFieldValue("SU_FULLNAME")+", "+tools.FormatDate(conn.GetFieldValue("AD_DATE"));
			LBL_EXLIMITVAL01.Text		= tools.MoneyFormat(conn.GetFieldValue("AD_EXLIMITVAL"));
			LBL_EXRPLIMIT01.Text		= tools.MoneyFormat(conn.GetFieldValue("AD_EXRPLIMIT"));
			LBL_INSTALLMENT01.Text		= tools.MoneyFormat(conn.GetFieldValue("AD_INSTALLMENT"));
			LBL_INSTALLMENT01.Visible	= true;
			LBL_KET_DESC01.Text			= conn.GetFieldValue("KET_DESC");
			LBL_APPDESC01.Text			= conn.GetFieldValue("APPTYPEDESC");
			LBL_FACILITY01.Text			= conn.GetFieldValue("PRODUCTDESC");
			LBL_SIFATKREDIT01.Text		= conn.GetFieldValue("revolving");
			LBL_TUJUANPENGGUNAAN01.Text	= conn.GetFieldValue("LOANPURPDESC");
			LBL_INSTALLTEXT01.Text		= conn.GetFieldValue("INSTALL");
			LBL_INSTALLTEXT01.Visible	= true;
			LBL_LIMIT01.Text			= tools.MoneyFormat(conn.GetFieldValue("AD_LIMIT"));
			LBL_LOANTERM01.Text			= conn.GetFieldValue("AD_TENOR");
			LBL_INTERESTTYPE01.Text		= conn.GetFieldValue("interesttype");
			LBL_INTEREST01.Text			= conn.GetFieldValue("interestvalue");
			LBL_GRACE01.Text			= conn.GetFieldValue("AD_GRACEPERIOD");
			LBL_REPAYMENT01.Text		= conn.GetFieldValue("paymentdesc");
			ViewAcc();
			if ((LBL_CASH.Text.Trim()=="1") && (conn.GetFieldValue("IDC_FLAG").Trim()=="1"))
				ViewSK011();
			else if (LBL_CASH.Text.Trim()=="0")
			{
				ViewSK07();
				conn.ClearData();
			//	ViewSK011();
			}
			conn.QueryString = "DE_TOTALEXPOSURE '" + LBL_APREGNO.Text + "'";
			conn.ExecuteQuery(300);
			LBL_TOTALEXPLOSURE01.Text	= tools.MoneyFormat(conn.GetFieldValue("exposure"));
			LBL_SUMLIMIT01.Text			= tools.MoneyFormat(conn.GetFieldValue("tot_limit"));
			conn.ClearData();
		}

		private void ViewSK011()
		{
			LBL_IDC_INTEREST01.Text		= conn.GetFieldValue("idc_interestvalue01");
			string tenor				= conn.GetFieldValue("TENORDESC");
			conn.ClearData();
			Panel011.Visible			= true;
			QueryIDC();
			LBL_IDC_PLAFOND01.Text		= tools.MoneyFormat(conn.GetFieldValue("IDC_CAPAMNT"));
			LBL_IDC_KAPITALIS01.Text	= tools.MoneyFormat(conn.GetFieldValue("IDC_CAPRATIO"));
			LBL_IDC_LOANTERM01.Text		= tools.ConvertNum(conn.GetFieldValue("IDC_JWAKTU"))+" "+tenor;
			LBL_IDC_RATIO01.Text		= tools.MoneyFormat(conn.GetFieldValue("IDC_RATIO"));
			conn.ClearData();
		}

		private void ViewSK02(string vapptype)
		{
			Panel02.Visible				= true;
			Query(vapptype);
			string seq					= conn.GetFieldValue("acc_seq");
			TXT_CPKET.Text				= conn.GetFieldValue("AD_KETERANGAN");
			LBL_CRMAPPR.Text			= conn.GetFieldValue("SU_FULLNAME")+", "+tools.FormatDate(conn.GetFieldValue("AD_DATE"));
			LBL_KET_DESC02.Text			= conn.GetFieldValue("KET_DESC");
			LBL_APPDESC02.Text			= conn.GetFieldValue("APPTYPEDESC");
			LBL_FACILITY02.Text			= conn.GetFieldValue("PRODUCTDESC");
			LBL_CURRENCY02.Text			= conn.GetFieldValue("CURRENCY");
			LBL_LIMIT02.Text			= tools.MoneyFormat(conn.GetFieldValue("BC_LOANAMOUNT"));
			LBL_SIFATKREDIT02.Text		= conn.GetFieldValue("revolving");
			LBL_TENOR02.Text			= conn.GetFieldValue("AD_TENOR");
			ViewAcc();
			conn.ClearData();
		}

		private void ViewSK03(string vapptype)
		{
			Panel03.Visible				= true;
			Query(vapptype);
			TXT_CPKET.Text				= conn.GetFieldValue("AD_KETERANGAN");
			LBL_CRMAPPR.Text			= conn.GetFieldValue("SU_FULLNAME")+", "+tools.FormatDate(conn.GetFieldValue("AD_DATE"));
			LBL_KET_DESC03.Text			= conn.GetFieldValue("KET_DESC");
			LBL_APPDESC03.Text			= conn.GetFieldValue("APPTYPEDESC");
			LBL_FACILITY03.Text			= conn.GetFieldValue("PRODUCTDESC");
			LBL_CURRNEW03.Text			= conn.GetFieldValue("CURRENCY");
			LBL_CURROLD03.Text			= LBL_CURRNEW03.Text;
			LBL_LIMIT03.Text			= conn.GetFieldValue("CP_LIMITCHG")+" "+tools.ConvertCurr(conn.GetFieldValue("AD_EXLIMITVAL"));
			LBL_EXRPLIMIT03.Text		= tools.MoneyFormat(conn.GetFieldValue("AD_EXRPLIMIT"));
			LBL_CPLIMIT03.Text			= tools.MoneyFormat(conn.GetFieldValue("AD_LIMIT"));
			ViewAcc();
			conn.ClearData();
			conn.QueryString = "select LIMIT, TENOR, TENORCODE from bookedprod " +  
				"where aa_no='" + LBL_ACCAANO.Text + "' and productid='" + LBL_PRODUCTID.Text + "' and acc_seq='" + tools.ConvertNum(LBL_ACCSEQ.Text) + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
				LBL_OLDLIMIT03.Text = tools.MoneyFormat(conn.GetFieldValue(0, "LIMIT"));
			conn.ClearData();
		}

		private void ViewSK06(string vapptype)
		{
			Panel06.Visible				= true;
			Query(vapptype);
			TXT_CPKET.Text				= conn.GetFieldValue("AD_KETERANGAN");
			LBL_CRMAPPR.Text			= conn.GetFieldValue("SU_FULLNAME")+", "+tools.FormatDate(conn.GetFieldValue("AD_DATE"));
			LBL_KET_DESC06.Text			= conn.GetFieldValue("KET_DESC");
			LBL_APPDESC06.Text			= conn.GetFieldValue("APPTYPEDESC");
			LBL_WITHDRAWLID06.Text		= conn.GetFieldValue("withdrawldesc");
			LBL_FACILITY06.Text			= conn.GetFieldValue("PRODUCTDESC");
			LBL_CURRENCY06.Text			= conn.GetFieldValue("CURRENCY");
			LBL_CURR06.Text				= LBL_CURRENCY06.Text;
			LBL_TENOR06.Text			= conn.GetFieldValue("AD_TENOR");
			LBLCP_LIMIT06.Text			= tools.MoneyFormat(conn.GetFieldValue("CP_LIMIT"));
			LBL_CP_EXRPLIMIT06.Text		= tools.MoneyFormat(conn.GetFieldValue("AD_EXRPLIMIT"));
			LBL_CP_EXLIMITVAL06.Text	= tools.MoneyFormat(conn.GetFieldValue("AD_EXLIMITVAL"));
			LBL_CPINSTALLMENT06.Visible	= true;
			LBL_CPINSTALLMENT06.Text	= tools.MoneyFormat(conn.GetFieldValue("AD_INSTALLMENT"));
			LBL_INTERESTTYPE06.Text		= conn.GetFieldValue("interesttype");
			LBL_INTEREST06.Text			= conn.GetFieldValue("interestvalue");
			ViewAcc();
			conn.ClearData();
		}

		private void ViewAcc()
		{
			string aa_no		= conn.GetFieldValue("AA_NO").Trim();
			string no_fas		= conn.GetFieldValue("SIBS_PRODID").Trim();
			int seq				= int.Parse(tools.ConvertNum(conn.GetFieldValue("ACC_SEQ")));
			if (aa_no!="")
			{
				PanelACC.Visible		= true;
				LBL_ACCAANO.Text		= aa_no;
				LBL_ACCNOFASILITAS.Text	= no_fas;
				LBL_ACCSEQ.Text			= seq.ToString();
			}
		}

		private void ViewBEA()
		{
			conn.QueryString = "select APL_BEAADM, APL_BEAPROVISI, APL_BEANOTARIS, APL_BEAIKAT, APL_BEAMATERAI "+
				"from appproductlegal  "+
				"where ap_regno='"+LBL_APREGNO.Text+"' and productid='"+LBL_PRODUCTID.Text+"' AND APPTYPE IN (select distinct apptype from custproduct " +
								" where ket_code in (select ket_code from ketentuan_kredit where ap_regno = '" + LBL_APREGNO.Text + "'))";
			conn.ExecuteQuery();
			LBL_BIAYA_ADM.Text		= tools.MoneyFormat(conn.GetFieldValue("APL_BEAADM"));
			LBL_BIAYA_NOTARIS.Text	= tools.MoneyFormat(conn.GetFieldValue("APL_BEANOTARIS"));
			LBL_BIAYA_PROVISI.Text	= tools.MoneyFormat(conn.GetFieldValue("APL_BEAPROVISI"));
			LBL_BIAYA_IKAT.Text		= tools.MoneyFormat(conn.GetFieldValue("APL_BEAIKAT"));
			LBL_BIAYA_MATERAI.Text	= tools.MoneyFormat(conn.GetFieldValue("APL_BEAMATERAI"));
			conn.ClearData();
		}

		private void ViewCollateral()
		{
			conn.QueryString = "SELECT SIBS_COLID, isnull(CL_DESC,'')+' ('+isnull(COLTYPEDESC,'')+')' as COLTYPEDESC, LC_VALUE, LC_PERCENTAGE, CL_CURRENCY, COLCLASSDESC, ACTION "+
				"FROM vw_report_DISBURSHEET_COL WHERE AP_REGNO='"+LBL_APREGNO.Text+"' AND PRODUCTID='"+LBL_PRODUCTID.Text+"' ORDER BY COLTYPEID";
			conn.ExecuteQuery();
			if (LBL_APPTYPE1.Text.Trim()=="02")
				oTable.Rows[0].Cells[6].Visible	= true;
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				oTable.Rows.Add(new TableRow());
				oTable.Rows[i+1].Cells.Add(new TableCell());
				oTable.Rows[i+1].Cells[0].Text = conn.GetFieldValue(i, "SIBS_COLID");
				oTable.Rows[i+1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				oTable.Rows[i+1].Cells[0].CssClass	= "ReportList";
				
				oTable.Rows[i+1].Cells.Add(new TableCell());
				oTable.Rows[i+1].Cells[1].Text = conn.GetFieldValue(i, "COLTYPEDESC");
				oTable.Rows[i+1].Cells[1].HorizontalAlign = HorizontalAlign.Center;
				oTable.Rows[i+1].Cells[1].CssClass	= "ReportList";

				oTable.Rows[i+1].Cells.Add(new TableCell());
				oTable.Rows[i+1].Cells[2].Text = tools.MoneyFormat(conn.GetFieldValue(i, "LC_VALUE"));
				oTable.Rows[i+1].Cells[2].HorizontalAlign = HorizontalAlign.Center;
				oTable.Rows[i+1].Cells[2].CssClass	= "ReportList";
				
				oTable.Rows[i+1].Cells.Add(new TableCell());
				oTable.Rows[i+1].Cells[3].Text = conn.GetFieldValue(i, "COLCLASSDESC");
				oTable.Rows[i+1].Cells[3].HorizontalAlign = HorizontalAlign.Center;
				oTable.Rows[i+1].Cells[3].CssClass	= "ReportList";

				oTable.Rows[i+1].Cells.Add(new TableCell());
				oTable.Rows[i+1].Cells[4].Text = conn.GetFieldValue(i, "CL_CURRENCY");
				oTable.Rows[i+1].Cells[4].HorizontalAlign = HorizontalAlign.Center;
				oTable.Rows[i+1].Cells[4].CssClass	= "ReportList";

				oTable.Rows[i+1].Cells.Add(new TableCell());
				oTable.Rows[i+1].Cells[5].Text = tools.ConvertNum(conn.GetFieldValue(i, "LC_PERCENTAGE"))+"%";
				oTable.Rows[i+1].Cells[5].HorizontalAlign = HorizontalAlign.Center;
				oTable.Rows[i+1].Cells[5].CssClass	= "ReportList";

				if (LBL_APPTYPE1.Text.Trim()=="02")
				{
					oTable.Rows[i+1].Cells.Add(new TableCell());
					oTable.Rows[i+1].Cells[6].Text = conn.GetFieldValue(i, "ACTION");
					oTable.Rows[i+1].Cells[6].HorizontalAlign = HorizontalAlign.Center;
					oTable.Rows[i+1].Cells[6].CssClass	= "ReportList";
				}
			}
			conn.ClearData();
		}

		private void ViewDocument()
		{
			conn.QueryString = "SELECT DOCTYPEDESC, DOCDESC, AT_RECEIVEDATE, AT_EXPDATE "+
				"FROM VW_REPORT_DISBURSHEET_TBO WHERE AP_REGNO='"+LBL_APREGNO.Text+"' AND (DOCTYPE in ('1','3') or productid='"+LBL_PRODUCTID.Text+"') order by DOCTYPE"; 
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				oTable1.Rows.Add(new TableRow());
				oTable1.Rows[i+1].Cells.Add(new TableCell());
				oTable1.Rows[i+1].Cells[0].Text = conn.GetFieldValue(i, "DOCTYPEDESC");
				oTable1.Rows[i+1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				oTable1.Rows[i+1].Cells[0].CssClass	= "ReportList";
				
				oTable1.Rows[i+1].Cells.Add(new TableCell());
				oTable1.Rows[i+1].Cells[1].Text = conn.GetFieldValue(i, "DOCDESC");
				oTable1.Rows[i+1].Cells[1].HorizontalAlign = HorizontalAlign.Center;
				oTable1.Rows[i+1].Cells[1].CssClass	= "ReportList";

				oTable1.Rows[i+1].Cells.Add(new TableCell());
				oTable1.Rows[i+1].Cells[2].Text = tools.FormatDate(conn.GetFieldValue(i, "AT_RECEIVEDATE"));
				oTable1.Rows[i+1].Cells[2].HorizontalAlign = HorizontalAlign.Center;
				oTable1.Rows[i+1].Cells[2].CssClass	= "ReportList";
				
				oTable1.Rows[i+1].Cells.Add(new TableCell());
				oTable1.Rows[i+1].Cells[3].Text = tools.FormatDate(conn.GetFieldValue(i, "AT_EXPDATE"));
				oTable1.Rows[i+1].Cells[3].HorizontalAlign = HorizontalAlign.Center;
				oTable1.Rows[i+1].Cells[3].CssClass	= "ReportList";
			}
			conn.ClearData();
		}

		private void CollateralDetail()
		{
			ArrayList a = new ArrayList();
			a.Clear();
			conn.QueryString = "SELECT distinct COLTYPEID "+
			"FROM vw_report_DISBURSHEET_COL "+
				"WHERE AP_REGNO='"+LBL_APREGNO.Text+"' AND PRODUCTID='"+LBL_PRODUCTID.Text+"' ORDER BY COLTYPEID ";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++) 
				a.Add(conn.GetFieldValue(i, "COLTYPEID"));
			conn.ClearData();

			for (int i = 0; i<a.Count; i++)
			{
				string coltype = (string) a[i];
				if (coltype.Trim()=="AR")
					CollAR();
				else if (coltype.Trim()=="BOND")
					CollBOND();
				else if (coltype.Trim()=="DEP")
					CollDEP();
				else if (coltype.Trim()=="INV")
					CollINV();
				else if (coltype.Trim()=="LC")
					CollLC();
				else if (coltype.Trim()=="LSAGR")
					CollLSAGR();
				else if (coltype.Trim()=="MISC")
					CollMISC();
				else if (coltype.Trim()=="PG")
					CollPG();
				else if (coltype.Trim()=="PNCHQ")
					CollPNCHQ();
				else if (coltype.Trim()=="RE")
					CollRE();
				else if (coltype.Trim()=="SPK")
					CollSPK();
				else if (coltype.Trim()=="STOCK")
					CollSTOCK();
				else if (coltype.Trim()=="TRCON")
					CollTRCON();
				else if (coltype.Trim()=="VEH")
					CollVEH();
			}
		}

		private void CollAR()
		{
			oTableAR.Visible	= true;
			conn.QueryString = "select CLDESC, CL_PROPVALUE, CL_DESC, CL_CURRENCY, COLCLASSDESC, CL_COLLNAME, "+
				"CL_ISSUEDATE, CL_REVIEWDATE, CL_AGINGAMNT, CL_EXPDATE, SIBS_COLID "+
				"FROM vw_report_DISBURSHEET_COL_AR "+
				"WHERE AP_REGNO='"+LBL_APREGNO.Text+"' AND PRODUCTID='"+LBL_PRODUCTID.Text+"' ORDER BY ap_regno, productid ";
			conn.ExecuteQuery();
			int j = 0;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				oTableAR.Rows.Add(new TableRow());
				oTableAR.Rows[i+j].Cells.Add(new TableCell());
				oTableAR.Rows[i+j].Cells[0].ColumnSpan	= 2;
				oTableAR.Rows[i+j].Cells[0].CssClass	= "HeaderReportList";
				oTableAR.Rows[i+j].Cells[0].Text		= conn.GetFieldValue(i, "CLDESC");

				oTableAR.Rows.Add(new TableRow());
				oTableAR.Rows[i+j+1].Cells.Add(new TableCell());
				oTableAR.Rows[i+j+1].Cells[0].CssClass	= "TDBGColorValue";
				oTableAR.Rows[i+j+1].Cells[0].Text		= "Keterangan Jaminan";
				oTableAR.Rows[i+j+1].Cells[0].Width		= 280;
				oTableAR.Rows[i+j+1].Cells.Add(new TableCell());
				oTableAR.Rows[i+j+1].Cells[1].CssClass	= "TDBGColorValue";
				oTableAR.Rows[i+j+1].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_DESC");
					
				oTableAR.Rows.Add(new TableRow());
				oTableAR.Rows[i+j+2].Cells.Add(new TableCell());
				oTableAR.Rows[i+j+2].Cells[0].CssClass	= "TDBGColorValue";
				oTableAR.Rows[i+j+2].Cells[0].Text		= "SIBS Collateral ID";
				oTableAR.Rows[i+j+2].Cells.Add(new TableCell());
				oTableAR.Rows[i+j+2].Cells[1].CssClass	= "TDBGColorValue";
				oTableAR.Rows[i+j+2].Cells[1].Text		= ": "+conn.GetFieldValue(i, "SIBS_COLID");

				oTableAR.Rows.Add(new TableRow());
				oTableAR.Rows[i+j+3].Cells.Add(new TableCell());
				oTableAR.Rows[i+j+3].Cells[0].CssClass	= "TDBGColorValue";
				oTableAR.Rows[i+j+3].Cells[0].Text		= "Mata Uang";
				oTableAR.Rows[i+j+3].Cells.Add(new TableCell());
				oTableAR.Rows[i+j+3].Cells[1].CssClass	= "TDBGColorValue";
				oTableAR.Rows[i+j+3].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_CURRENCY");
					
				oTableAR.Rows.Add(new TableRow());
				oTableAR.Rows[i+j+4].Cells.Add(new TableCell());
				oTableAR.Rows[i+j+4].Cells[0].CssClass	= "TDBGColorValue";
				oTableAR.Rows[i+j+4].Cells[0].Text		= "Klasifikasi Jaminan";
				oTableAR.Rows[i+j+4].Cells.Add(new TableCell());
				oTableAR.Rows[i+j+4].Cells[1].CssClass	= "TDBGColorValue";
				oTableAR.Rows[i+j+4].Cells[1].Text		= ": "+conn.GetFieldValue(i, "COLCLASSDESC");

				oTableAR.Rows.Add(new TableRow());
				oTableAR.Rows[i+j+5].Cells.Add(new TableCell());
				oTableAR.Rows[i+j+5].Cells[0].CssClass	= "TDBGColorValue";
				oTableAR.Rows[i+j+5].Cells[0].Text		= "Nama Jaminan";
				oTableAR.Rows[i+j+5].Cells.Add(new TableCell());
				oTableAR.Rows[i+j+5].Cells[1].CssClass	= "TDBGColorValue";
				oTableAR.Rows[i+j+5].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_COLLNAME");

				oTableAR.Rows.Add(new TableRow());
				oTableAR.Rows[i+j+6].Cells.Add(new TableCell());
				oTableAR.Rows[i+j+6].Cells[0].CssClass	= "TDBGColorValue";
				oTableAR.Rows[i+j+6].Cells[0].Text		= "Nilai Jaminan";
				oTableAR.Rows[i+j+6].Cells.Add(new TableCell());
				oTableAR.Rows[i+j+6].Cells[1].CssClass	= "TDBGColorValue";
				oTableAR.Rows[i+j+6].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_PROPVALUE"));

				oTableAR.Rows.Add(new TableRow());
				oTableAR.Rows[i+j+7].Cells.Add(new TableCell());
				oTableAR.Rows[i+j+7].Cells[0].CssClass	= "TDBGColorValue";
				oTableAR.Rows[i+j+7].Cells[0].Text		= "Tanggal Penerbitan";
				oTableAR.Rows[i+j+7].Cells.Add(new TableCell());
				oTableAR.Rows[i+j+7].Cells[1].CssClass	= "TDBGColorValue";
				oTableAR.Rows[i+j+7].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i, "CL_ISSUEDATE"));

				oTableAR.Rows.Add(new TableRow());
				oTableAR.Rows[i+j+8].Cells.Add(new TableCell());
				oTableAR.Rows[i+j+8].Cells[0].CssClass	= "TDBGColorValue";
				oTableAR.Rows[i+j+8].Cells[0].Text		= "Tanggal Review";
				oTableAR.Rows[i+j+8].Cells.Add(new TableCell());
				oTableAR.Rows[i+j+8].Cells[1].CssClass	= "TDBGColorValue";
				oTableAR.Rows[i+j+8].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i, "CL_REVIEWDATE"));

				oTableAR.Rows.Add(new TableRow());
				oTableAR.Rows[i+j+9].Cells.Add(new TableCell());
				oTableAR.Rows[i+j+9].Cells[0].CssClass	= "TDBGColorValue";
				oTableAR.Rows[i+j+9].Cells[0].Text		= "Aging Amount";
				oTableAR.Rows[i+j+9].Cells.Add(new TableCell());
				oTableAR.Rows[i+j+9].Cells[1].CssClass	= "TDBGColorValue";
				oTableAR.Rows[i+j+9].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_AGINGAMNT"));

				oTableAR.Rows.Add(new TableRow());
				oTableAR.Rows[i+j+10].Cells.Add(new TableCell());
				oTableAR.Rows[i+j+10].Cells[0].CssClass	= "TDBGColorValue";
				oTableAR.Rows[i+j+10].Cells[0].Text		= "Tanggal Kadaluarsa";
				oTableAR.Rows[i+j+10].Cells.Add(new TableCell());
				oTableAR.Rows[i+j+10].Cells[1].CssClass	= "TDBGColorValue";
				oTableAR.Rows[i+j+10].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i, "CL_EXPDATE"));
				j = j + 10;
			}
		}

		private void CollBOND()
		{
			oTableBOND.Visible	= true;
			conn.QueryString = "SELECT * "+
				"FROM vw_report_DISBURSHEET_COL_BOND "+
				"WHERE AP_REGNO='"+LBL_APREGNO.Text+"' AND PRODUCTID='"+LBL_PRODUCTID.Text+"' ORDER BY ap_regno, productid ";
			conn.ExecuteQuery();
			int j = 0;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j].Cells[0].ColumnSpan	= 2;
				oTableBOND.Rows[i+j].Cells[0].CssClass		= "HeaderReportList";
				oTableBOND.Rows[i+j].Cells[0].Text			= conn.GetFieldValue(i, "CLDESC");

				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+1].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+1].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+1].Cells[0].Text		= "Keterangan Jaminan";
				oTableBOND.Rows[i+j+1].Cells[0].Width		= 280;
				oTableBOND.Rows[i+j+1].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+1].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+1].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_DESC");
					
				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+2].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+2].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+2].Cells[0].Text		= "Mata Uang";
				oTableBOND.Rows[i+j+2].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+2].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+2].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_CURRENCY");

				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+3].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+3].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+3].Cells[0].Text		= "Klasifikasi Jaminan";
				oTableBOND.Rows[i+j+3].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+3].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+3].Cells[1].Text		= ": "+conn.GetFieldValue(i, "COLCLASSDESC");
					
				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+4].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+4].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+4].Cells[0].Text		= "SIBS Collateral ID";
				oTableBOND.Rows[i+j+4].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+4].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+4].Cells[1].Text		= ": "+conn.GetFieldValue(i, "SIBS_COLID");

				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+5].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+5].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+5].Cells[0].Text		= "Jenis Bond";
				oTableBOND.Rows[i+j+5].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+5].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+5].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_BONDTYPE");

				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+6].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+6].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+6].Cells[0].Text		= "Regitrasi No.";
				oTableBOND.Rows[i+j+6].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+6].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+6].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_REGNO");

				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+7].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+7].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+7].Cells[0].Text		= "Security No.";
				oTableBOND.Rows[i+j+7].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+7].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+7].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_SECURITYNO");

				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+8].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+8].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+8].Cells[0].Text		= "Nilai Jaminan";
				oTableBOND.Rows[i+j+8].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+8].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+8].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_PROPVALUE"));

				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+9].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+9].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+9].Cells[0].Text		= "Nilai Pasar Saat Ini";
				oTableBOND.Rows[i+j+9].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+9].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+9].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_MARKETVALUE"));

				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+10].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+10].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+10].Cells[0].Text		= "Tanggal Pendaftaran";
				oTableBOND.Rows[i+j+10].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+10].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+10].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i, "CL_REGDATE"));

				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+11].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+11].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+11].Cells[0].Text		= "Diterbitkan Oleh";
				oTableBOND.Rows[i+j+11].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+11].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+11].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_ISSUEDBY");
					
				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+12].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+12].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+12].Cells[0].Text		= "Tanggal Penerbitan";
				oTableBOND.Rows[i+j+12].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+12].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+12].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i, "CL_ISSUEDDATE"));

				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+13].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+13].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+13].Cells[0].Text		= "Tanggal Jatuh Tempo";
				oTableBOND.Rows[i+j+13].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+13].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+13].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i, "CL_DUEDATE"));

				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+14].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+14].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+14].Cells[0].Text		= "Kondisi";
				oTableBOND.Rows[i+j+14].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+14].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+14].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_CONDITION");

				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+15].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+15].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+15].Cells[0].Text		= "Nama Pemilik";
				oTableBOND.Rows[i+j+15].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+15].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+15].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_OWNER");

				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+16].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+16].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+16].Cells[0].Text		= "Hubungan";
				oTableBOND.Rows[i+j+16].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+16].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+16].Cells[1].Text		= ": "+conn.GetFieldValue(i, "RELTYPEDESC");

				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+17].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+17].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+17].Cells[0].Text		= "Jumlah / ukuran Agunan";
				oTableBOND.Rows[i+j+17].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+17].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+17].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_COLLAMOUNT"));

				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+18].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+18].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+18].Cells[0].Text		= "Jenis Pengikatan";
				oTableBOND.Rows[i+j+18].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+18].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+18].Cells[1].Text		= ": "+conn.GetFieldValue(i, "IKATDESC");

				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+19].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+19].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+19].Cells[0].Text		= "Penilaian Menurut";
				oTableBOND.Rows[i+j+19].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+19].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+19].Cells[1].Text		= ": "+conn.GetFieldValue(i, "ACCRDTODESC");

				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+20].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+20].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+20].Cells[0].Text		= "Peringkat Surat Berharga";
				oTableBOND.Rows[i+j+20].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+20].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+20].Cells[1].Text		= ": "+conn.GetFieldValue(i, "PSBDESC");

				oTableBOND.Rows.Add(new TableRow());
				oTableBOND.Rows[i+j+21].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+21].Cells[0].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+21].Cells[0].Text		= "Jenis Agunan";
				oTableBOND.Rows[i+j+21].Cells.Add(new TableCell());
				oTableBOND.Rows[i+j+21].Cells[1].CssClass	= "TDBGColorValue";
				oTableBOND.Rows[i+j+21].Cells[1].Text		= ": "+conn.GetFieldValue(i, "AGUNANDESC");
				j = j + 21;
			}
		}

		private void CollDEP()
		{
			oTableDEP.Visible	= true;
			conn.QueryString = "SELECT * "+
				"FROM vw_report_DISBURSHEET_COL_DEP "+
				"WHERE AP_REGNO='"+LBL_APREGNO.Text+"' AND PRODUCTID='"+LBL_PRODUCTID.Text+"' ORDER BY ap_regno, productid ";
			try 
			{
				conn.ExecuteQuery();
			} 
			catch (ApplicationException) 
			{
				Tools.popMessage(this, "Data tidak valid !");
				return;
			}
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Server Error !");
				return;
			}

			int j = 0;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j].Cells[0].ColumnSpan	= 2;
				oTableDEP.Rows[i+j].Cells[0].CssClass	= "HeaderReportList";
				oTableDEP.Rows[i+j].Cells[0].Text		= conn.GetFieldValue(i, "CLDESC");

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+1].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+1].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+1].Cells[0].Text		= "Keterangan Jaminan";
				oTableDEP.Rows[i+j+1].Cells[0].Width	= 280;
				oTableDEP.Rows[i+j+1].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+1].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+1].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_DESC");
					
				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+2].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+2].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+2].Cells[0].Text		= "Mata Uang";
				oTableDEP.Rows[i+j+2].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+2].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+2].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_CURRENCY");

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+3].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+3].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+3].Cells[0].Text		= "Exchange Rate to Rp";
				oTableDEP.Rows[i+j+3].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+3].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+3].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_EXCHANGERATE"));
					
				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+4].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+4].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+4].Cells[0].Text		= "Klasifikasi Jaminan";
				oTableDEP.Rows[i+j+4].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+4].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+4].Cells[1].Text		= ": "+conn.GetFieldValue(i, "COLCLASSDESC");

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+5].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+5].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+5].Cells[0].Text		= "SIBS Collateral ID";
				oTableDEP.Rows[i+j+5].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+5].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+5].Cells[1].Text		= ": "+conn.GetFieldValue(i, "SIBS_COLID");

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+6].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+6].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+6].Cells[0].Text		= "Penilaian Menurut";
				oTableDEP.Rows[i+j+6].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+6].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+6].Cells[1].Text		= ": "+conn.GetFieldValue(i, "ACCRDTODESC");

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+7].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+7].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+7].Cells[0].Text		= "Jenis Agunan";
				oTableDEP.Rows[i+j+7].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+7].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+7].Cells[1].Text		= ": "+conn.GetFieldValue(i, "AGUNANDESC");

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+8].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+8].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+8].Cells[0].Text		= "Jenis Pengikatan";
				oTableDEP.Rows[i+j+8].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+8].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+8].Cells[1].Text		= ": "+conn.GetFieldValue(i, "IKATDESC");

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+9].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+9].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+9].Cells[0].Text		= "Bank/ simpanan tabungan";
				oTableDEP.Rows[i+j+9].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+9].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+9].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_BANK");

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+10].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+10].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+10].Cells[0].Text		= "No. FDR/ No. Rek. Tabungan";
				oTableDEP.Rows[i+j+10].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+10].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+10].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_REKNUM");

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+11].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+11].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+11].Cells[0].Text		= "Jenis Rekening";
				oTableDEP.Rows[i+j+11].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+11].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+11].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_REKTYPE");
					
				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+12].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+12].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+12].Cells[0].Text		= "Jenis Mata Uang";
				oTableDEP.Rows[i+j+12].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+12].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+12].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_REKCURRENCY");

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+13].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+13].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+13].Cells[0].Text		= "Nilai Jaminan";
				oTableDEP.Rows[i+j+13].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+13].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+13].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_PROPVALUE"));

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+14].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+14].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+14].Cells[0].Text		= "Suku bunga FDR";
				oTableDEP.Rows[i+j+14].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+14].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+14].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_FDRRATE")+" %";

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+15].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+15].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+15].Cells[0].Text		= "Penerbit FDR";
				oTableDEP.Rows[i+j+15].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+15].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+15].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_FDRISSUEDBY");

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+16].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+16].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+16].Cells[0].Text		= "Tgl. Penerbitan";
				oTableDEP.Rows[i+j+16].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+16].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+16].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i, "CL_FDRISSUEDDATE"));

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+17].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+17].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+17].Cells[0].Text		= "Tgl. Kadaluarsa FDR";
				oTableDEP.Rows[i+j+17].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+17].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+17].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i, "CL_FDREXPIREDDATE"));

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+18].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+18].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+18].Cells[0].Text		= "Tenor term";
				oTableDEP.Rows[i+j+18].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+18].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+18].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_TENORTERM");

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+19].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+19].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+19].Cells[0].Text		= "Spread Rate";
				oTableDEP.Rows[i+j+19].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+19].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+19].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_SPRDRATE")+" %";

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+20].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+20].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+20].Cells[0].Text		= "No. Buku Tabungan";
				oTableDEP.Rows[i+j+20].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+20].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+20].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_REKBOOKNUM");

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+21].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+21].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+21].Cells[0].Text		= "Hubungan";
				oTableDEP.Rows[i+j+21].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+21].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+21].Cells[1].Text		= ": "+conn.GetFieldValue(i, "RELTYPEDESC");

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+22].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+22].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+22].Cells[0].Text		= "Nama Deposit";
				oTableDEP.Rows[i+j+22].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+22].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+22].Cells[1].Text		= ": "+conn.GetFieldValue(i, "NAMA");

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+23].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+23].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+23].Cells[0].Text		= "Tanggal Review";
				oTableDEP.Rows[i+j+23].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+23].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+23].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i, "CL_REVIEWDATE"));

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+24].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+24].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+24].Cells[0].Text		= "Nilai Garansi";
				oTableDEP.Rows[i+j+24].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+24].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+24].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_GUARANTEEVAL"));

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+25].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+25].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+25].Cells[0].Text		= "Tgl. Jatuh Tempo Garansi";
				oTableDEP.Rows[i+j+25].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+25].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+25].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i, "CL_GUARANTEEDUEDATE"));

				oTableDEP.Rows.Add(new TableRow());
				oTableDEP.Rows[i+j+26].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+26].Cells[0].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+26].Cells[0].Text		= "Instruksi untuk Tgl Due";
				oTableDEP.Rows[i+j+26].Cells.Add(new TableCell());
				oTableDEP.Rows[i+j+26].Cells[1].CssClass	= "TDBGColorValue";
				oTableDEP.Rows[i+j+26].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_INSTDUE");
				j = j + 26;
			}
		}
		
		private void CollINV()
		{
			oTableINV.Visible	= true;
			conn.QueryString = "select CLDESC, CL_DESC, CL_CURRENCY, COLCLASSDESC, CL_NOOFUNITS, "+
				"BERAT, CL_PRICEPERUNIT, CL_REVIEWDATE, CL_TOTALAMOUNT, CL_PROPVALUE, SIBS_COLID "+
				"FROM vw_report_DISBURSHEET_COL_INV "+
				"WHERE AP_REGNO='"+LBL_APREGNO.Text+"' AND PRODUCTID='"+LBL_PRODUCTID.Text+"' ORDER BY ap_regno, productid ";
			conn.ExecuteQuery();
			int j = 0;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				oTableINV.Rows.Add(new TableRow());
				oTableINV.Rows[i+j].Cells.Add(new TableCell());
				oTableINV.Rows[i+j].Cells[0].ColumnSpan	= 2;
				oTableINV.Rows[i+j].Cells[0].CssClass	= "HeaderReportList";
				oTableINV.Rows[i+j].Cells[0].Text		= conn.GetFieldValue(i, "CLDESC");

				oTableINV.Rows.Add(new TableRow());
				oTableINV.Rows[i+j+1].Cells.Add(new TableCell());
				oTableINV.Rows[i+j+1].Cells[0].CssClass	= "TDBGColorValue";
				oTableINV.Rows[i+j+1].Cells[0].Text		= "Keterangan Jaminan";
				oTableINV.Rows[i+j+1].Cells[0].Width	= 280;
				oTableINV.Rows[i+j+1].Cells.Add(new TableCell());
				oTableINV.Rows[i+j+1].Cells[1].CssClass	= "TDBGColorValue";
				oTableINV.Rows[i+j+1].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_DESC");
					
				oTableINV.Rows.Add(new TableRow());
				oTableINV.Rows[i+j+2].Cells.Add(new TableCell());
				oTableINV.Rows[i+j+2].Cells[0].CssClass	= "TDBGColorValue";
				oTableINV.Rows[i+j+2].Cells[0].Text		= "Mata Uang";
				oTableINV.Rows[i+j+2].Cells.Add(new TableCell());
				oTableINV.Rows[i+j+2].Cells[1].CssClass	= "TDBGColorValue";
				oTableINV.Rows[i+j+2].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_CURRENCY");

				oTableINV.Rows.Add(new TableRow());
				oTableINV.Rows[i+j+3].Cells.Add(new TableCell());
				oTableINV.Rows[i+j+3].Cells[0].CssClass	= "TDBGColorValue";
				oTableINV.Rows[i+j+3].Cells[0].Text		= "Klasifikasi Jaminan";
				oTableINV.Rows[i+j+3].Cells.Add(new TableCell());
				oTableINV.Rows[i+j+3].Cells[1].CssClass	= "TDBGColorValue";
				oTableINV.Rows[i+j+3].Cells[1].Text		= ": "+conn.GetFieldValue(i, "COLCLASSDESC");
					
				oTableINV.Rows.Add(new TableRow());
				oTableINV.Rows[i+j+4].Cells.Add(new TableCell());
				oTableINV.Rows[i+j+4].Cells[0].CssClass	= "TDBGColorValue";
				oTableINV.Rows[i+j+4].Cells[0].Text		= "SIBS Collateral ID";
				oTableINV.Rows[i+j+4].Cells.Add(new TableCell());
				oTableINV.Rows[i+j+4].Cells[1].CssClass	= "TDBGColorValue";
				oTableINV.Rows[i+j+4].Cells[1].Text		= ": "+conn.GetFieldValue(i, "SIBS_COLID");

				oTableINV.Rows.Add(new TableRow());
				oTableINV.Rows[i+j+5].Cells.Add(new TableCell());
				oTableINV.Rows[i+j+5].Cells[0].CssClass	= "TDBGColorValue";
				oTableINV.Rows[i+j+5].Cells[0].Text		= "No. Of Units";
				oTableINV.Rows[i+j+5].Cells.Add(new TableCell());
				oTableINV.Rows[i+j+5].Cells[1].CssClass	= "TDBGColorValue";
				oTableINV.Rows[i+j+5].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_NOOFUNITS");

				oTableINV.Rows.Add(new TableRow());
				oTableINV.Rows[i+j+6].Cells.Add(new TableCell());
				oTableINV.Rows[i+j+6].Cells[0].CssClass	= "TDBGColorValue";
				oTableINV.Rows[i+j+6].Cells[0].Text		= "Berat / Jenis Berat";
				oTableINV.Rows[i+j+6].Cells.Add(new TableCell());
				oTableINV.Rows[i+j+6].Cells[1].CssClass	= "TDBGColorValue";
				oTableINV.Rows[i+j+6].Cells[1].Text		= ": "+conn.GetFieldValue(i, "BERAT");

				oTableINV.Rows.Add(new TableRow());
				oTableINV.Rows[i+j+7].Cells.Add(new TableCell());
				oTableINV.Rows[i+j+7].Cells[0].CssClass	= "TDBGColorValue";
				oTableINV.Rows[i+j+7].Cells[0].Text		= "Nilai Jaminan";
				oTableINV.Rows[i+j+7].Cells.Add(new TableCell());
				oTableINV.Rows[i+j+7].Cells[1].CssClass	= "TDBGColorValue";
				oTableINV.Rows[i+j+7].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i,"CL_PROPVALUE"));

				oTableINV.Rows.Add(new TableRow());
				oTableINV.Rows[i+j+8].Cells.Add(new TableCell());
				oTableINV.Rows[i+j+8].Cells[0].CssClass	= "TDBGColorValue";
				oTableINV.Rows[i+j+8].Cells[0].Text		= "Harga Per Unit";
				oTableINV.Rows[i+j+8].Cells.Add(new TableCell());
				oTableINV.Rows[i+j+8].Cells[1].CssClass	= "TDBGColorValue";
				oTableINV.Rows[i+j+8].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i,"CL_PRICEPERUNIT"));

				oTableINV.Rows.Add(new TableRow());
				oTableINV.Rows[i+j+9].Cells.Add(new TableCell());
				oTableINV.Rows[i+j+9].Cells[0].CssClass	= "TDBGColorValue";
				oTableINV.Rows[i+j+9].Cells[0].Text		= "Tanggal Review";
				oTableINV.Rows[i+j+9].Cells.Add(new TableCell());
				oTableINV.Rows[i+j+9].Cells[1].CssClass	= "TDBGColorValue";
				oTableINV.Rows[i+j+9].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i, "CL_REVIEWDATE"));

				oTableINV.Rows.Add(new TableRow());
				oTableINV.Rows[i+j+10].Cells.Add(new TableCell());
				oTableINV.Rows[i+j+10].Cells[0].CssClass	= "TDBGColorValue";
				oTableINV.Rows[i+j+10].Cells[0].Text		= "Total Amount";
				oTableINV.Rows[i+j+10].Cells.Add(new TableCell());
				oTableINV.Rows[i+j+10].Cells[1].CssClass	= "TDBGColorValue";
				oTableINV.Rows[i+j+10].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_TOTALAMOUNT"));
				j = j + 10;
			}
		}
		
		private void CollLC()
		{
			oTableLC.Visible	= true;
			conn.QueryString = "SELECT * "+
				"FROM vw_report_DISBURSHEET_COL_LC "+
				"WHERE AP_REGNO='"+LBL_APREGNO.Text+"' AND PRODUCTID='"+LBL_PRODUCTID.Text+"' ORDER BY ap_regno, productid ";
			conn.ExecuteQuery();
			int j = 0;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				oTableLC.Rows.Add(new TableRow());
				oTableLC.Rows[i+j].Cells.Add(new TableCell());
				oTableLC.Rows[i+j].Cells[0].ColumnSpan	= 2;
				oTableLC.Rows[i+j].Cells[0].CssClass	= "HeaderReportList";
				oTableLC.Rows[i+j].Cells[0].Text		= conn.GetFieldValue(i, "CLDESC");

				oTableLC.Rows.Add(new TableRow());
				oTableLC.Rows[i+j+1].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+1].Cells[0].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+1].Cells[0].Text		= "Keterangan Jaminan";
				oTableLC.Rows[i+j+1].Cells[0].Width		= 280;
				oTableLC.Rows[i+j+1].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+1].Cells[1].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+1].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_DESC");
					
				oTableLC.Rows.Add(new TableRow());
				oTableLC.Rows[i+j+2].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+2].Cells[0].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+2].Cells[0].Text		= "Mata Uang";
				oTableLC.Rows[i+j+2].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+2].Cells[1].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+2].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_CURRENCY");

				oTableLC.Rows.Add(new TableRow());
				oTableLC.Rows[i+j+3].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+3].Cells[0].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+3].Cells[0].Text		= "Klasifikasi Jaminan";
				oTableLC.Rows[i+j+3].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+3].Cells[1].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+3].Cells[1].Text		= ": "+conn.GetFieldValue(i, "COLCLASSDESC");
					
				oTableLC.Rows.Add(new TableRow());
				oTableLC.Rows[i+j+4].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+4].Cells[0].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+4].Cells[0].Text		= "SIBS Collateral ID";
				oTableLC.Rows[i+j+4].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+4].Cells[1].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+4].Cells[1].Text		= ": "+conn.GetFieldValue(i, "SIBS_COLID");

				oTableLC.Rows.Add(new TableRow());
				oTableLC.Rows[i+j+5].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+5].Cells[0].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+5].Cells[0].Text		= "No. Standby L/C";
				oTableLC.Rows[i+j+5].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+5].Cells[1].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+5].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_STANDBYNO");

				oTableLC.Rows.Add(new TableRow());
				oTableLC.Rows[i+j+6].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+6].Cells[0].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+6].Cells[0].Text		= "Nilai Jaminan";
				oTableLC.Rows[i+j+6].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+6].Cells[1].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+6].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_PROPVALUE"));

				oTableLC.Rows.Add(new TableRow());
				oTableLC.Rows[i+j+7].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+7].Cells[0].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+7].Cells[0].Text		= "Exchange Rate";
				oTableLC.Rows[i+j+7].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+7].Cells[1].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+7].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_EXCHGRATE");

				oTableLC.Rows.Add(new TableRow());
				oTableLC.Rows[i+j+8].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+8].Cells[0].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+8].Cells[0].Text		= "Tanggal Penerbitan";
				oTableLC.Rows[i+j+8].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+8].Cells[1].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+8].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i, "CL_ISSUEDATE"));

				oTableLC.Rows.Add(new TableRow());
				oTableLC.Rows[i+j+9].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+9].Cells[0].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+9].Cells[0].Text		= "Tanggal Jatuh Tempo";
				oTableLC.Rows[i+j+9].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+9].Cells[1].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+9].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i,"CL_DUEDATE"));

				oTableLC.Rows.Add(new TableRow());
				oTableLC.Rows[i+j+10].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+10].Cells[0].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+10].Cells[0].Text		= "Bank Penerbit L/C";
				oTableLC.Rows[i+j+10].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+10].Cells[1].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+10].Cells[1].Text		= ": "+conn.GetFieldValue(i, "BNU_DESC");

				oTableLC.Rows.Add(new TableRow());
				oTableLC.Rows[i+j+11].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+11].Cells[0].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+11].Cells[0].Text		= "Nama Penerbit L/C";
				oTableLC.Rows[i+j+11].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+11].Cells[1].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+11].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_ISSUENAME");
					
				oTableLC.Rows.Add(new TableRow());
				oTableLC.Rows[i+j+12].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+12].Cells[0].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+12].Cells[0].Text		= "Kondisi";
				oTableLC.Rows[i+j+12].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+12].Cells[1].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+12].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_CONDITION");

				oTableLC.Rows.Add(new TableRow());
				oTableLC.Rows[i+j+13].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+13].Cells[0].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+13].Cells[0].Text		= "Nama Perusahaan";
				oTableLC.Rows[i+j+13].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+13].Cells[1].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+13].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_COMPNAME");

				oTableLC.Rows.Add(new TableRow());
				oTableLC.Rows[i+j+14].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+14].Cells[0].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+14].Cells[0].Text		= "Nilai Garansi";
				oTableLC.Rows[i+j+14].Cells.Add(new TableCell());
				oTableLC.Rows[i+j+14].Cells[1].CssClass	= "TDBGColorValue";
				oTableLC.Rows[i+j+14].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_GUARANTEEVAL"));
				j = j + 14;
			}
		}

		private void CollLSAGR()
		{
			oTableLSAGR.Visible	= true;
			conn.QueryString = "SELECT * "+
				"FROM vw_report_DISBURSHEET_COL_LSAGR "+
				"WHERE AP_REGNO='"+LBL_APREGNO.Text+"' AND PRODUCTID='"+LBL_PRODUCTID.Text+"' ORDER BY ap_regno, productid ";
			conn.ExecuteQuery();
			int j = 0;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				oTableLSAGR.Rows.Add(new TableRow());
				oTableLSAGR.Rows[i+j].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j].Cells[0].ColumnSpan	= 2;
				oTableLSAGR.Rows[i+j].Cells[0].CssClass	= "HeaderReportList";
				oTableLSAGR.Rows[i+j].Cells[0].Text		= conn.GetFieldValue(i, "CLDESC");

				oTableLSAGR.Rows.Add(new TableRow());
				oTableLSAGR.Rows[i+j+1].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+1].Cells[0].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+1].Cells[0].Text		= "Keterangan Jaminan";
				oTableLSAGR.Rows[i+j+1].Cells[0].Width		= 280;
				oTableLSAGR.Rows[i+j+1].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+1].Cells[1].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+1].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_DESC");
					
				oTableLSAGR.Rows.Add(new TableRow());
				oTableLSAGR.Rows[i+j+2].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+2].Cells[0].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+2].Cells[0].Text		= "Mata Uang";
				oTableLSAGR.Rows[i+j+2].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+2].Cells[1].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+2].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_CURRENCY");

				oTableLSAGR.Rows.Add(new TableRow());
				oTableLSAGR.Rows[i+j+3].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+3].Cells[0].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+3].Cells[0].Text		= "Klasifikasi Jaminan";
				oTableLSAGR.Rows[i+j+3].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+3].Cells[1].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+3].Cells[1].Text		= ": "+conn.GetFieldValue(i, "COLCLASSDESC");
					
				oTableLSAGR.Rows.Add(new TableRow());
				oTableLSAGR.Rows[i+j+4].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+4].Cells[0].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+4].Cells[0].Text		= "SIBS Collateral ID";
				oTableLSAGR.Rows[i+j+4].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+4].Cells[1].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+4].Cells[1].Text		= ": "+conn.GetFieldValue(i, "SIBS_COLID");

				oTableLSAGR.Rows.Add(new TableRow());
				oTableLSAGR.Rows[i+j+5].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+5].Cells[0].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+5].Cells[0].Text		= "Nama Perusahaan Leasing";
				oTableLSAGR.Rows[i+j+5].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+5].Cells[1].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+5].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_COMPNAME");

				oTableLSAGR.Rows.Add(new TableRow());
				oTableLSAGR.Rows[i+j+6].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+6].Cells[0].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+6].Cells[0].Text		= "Building Ownership";
				oTableLSAGR.Rows[i+j+6].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+6].Cells[1].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+6].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_BUILDOWN");

				oTableLSAGR.Rows.Add(new TableRow());
				oTableLSAGR.Rows[i+j+7].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+7].Cells[0].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+7].Cells[0].Text		= "Jenis Property";
				oTableLSAGR.Rows[i+j+7].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+7].Cells[1].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+7].Cells[1].Text		= ": "+conn.GetFieldValue(i, "PROPTYPEDESC");

				oTableLSAGR.Rows.Add(new TableRow());
				oTableLSAGR.Rows[i+j+8].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+8].Cells[0].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+8].Cells[0].Text		= "Tanggal Penerbitan";
				oTableLSAGR.Rows[i+j+8].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+8].Cells[1].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+8].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i, "CL_ISSUEDATE"));

				oTableLSAGR.Rows.Add(new TableRow());
				oTableLSAGR.Rows[i+j+9].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+9].Cells[0].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+9].Cells[0].Text		= "Tanggal Kadaluarsa";
				oTableLSAGR.Rows[i+j+9].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+9].Cells[1].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+9].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i,"CL_EXPDATE"));

				oTableLSAGR.Rows.Add(new TableRow());
				oTableLSAGR.Rows[i+j+10].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+10].Cells[0].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+10].Cells[0].Text		= "Tanggal Penilaian";
				oTableLSAGR.Rows[i+j+10].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+10].Cells[1].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+10].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i, "CL_APPRDATE"));

				oTableLSAGR.Rows.Add(new TableRow());
				oTableLSAGR.Rows[i+j+11].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+11].Cells[0].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+11].Cells[0].Text		= "Nama Penilai";
				oTableLSAGR.Rows[i+j+11].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+11].Cells[1].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+11].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_APPRBY");
					
				oTableLSAGR.Rows.Add(new TableRow());
				oTableLSAGR.Rows[i+j+12].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+12].Cells[0].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+12].Cells[0].Text		= "Hasil Penilaian";
				oTableLSAGR.Rows[i+j+12].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+12].Cells[1].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+12].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_APPRVALUE"));

				oTableLSAGR.Rows.Add(new TableRow());
				oTableLSAGR.Rows[i+j+13].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+13].Cells[0].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+13].Cells[0].Text		= "Nilai Jaminan";
				oTableLSAGR.Rows[i+j+13].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+13].Cells[1].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+13].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_PROPVALUE"));

				oTableLSAGR.Rows.Add(new TableRow());
				oTableLSAGR.Rows[i+j+14].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+14].Cells[0].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+14].Cells[0].Text		= "Nilai Garansi";
				oTableLSAGR.Rows[i+j+14].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+14].Cells[1].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+14].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_GUARANTEEVAL"));

				oTableLSAGR.Rows.Add(new TableRow());
				oTableLSAGR.Rows[i+j+15].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+15].Cells[0].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+15].Cells[0].Text		= "Exchange Rate";
				oTableLSAGR.Rows[i+j+15].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+15].Cells[1].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+15].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_EXCHGRATE"));

				oTableLSAGR.Rows.Add(new TableRow());
				oTableLSAGR.Rows[i+j+16].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+16].Cells[0].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+16].Cells[0].Text		= "Alamat";
				oTableLSAGR.Rows[i+j+16].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+16].Cells[1].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+16].Cells[1].Text		= ": "+conn.GetFieldValue(i, "ALAMAT");

				oTableLSAGR.Rows.Add(new TableRow());
				oTableLSAGR.Rows[i+j+17].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+17].Cells[0].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+17].Cells[0].Text		= "No. Rumah";
				oTableLSAGR.Rows[i+j+17].Cells.Add(new TableCell());
				oTableLSAGR.Rows[i+j+17].Cells[1].CssClass	= "TDBGColorValue";
				oTableLSAGR.Rows[i+j+17].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_HMNUM");
				j = j + 17;
			}
		}

		private void CollMISC()
		{
			oTableMISC.Visible	= true;
			conn.QueryString = "select CLDESC, CL_VALUEDATE, CL_DESC, CL_CURRENCY, COLCLASSDESC, APPRVALUE, "+
				"CL_APPRDATE, CL_APPRBY, AGUNANDESC, CL_PROPVALUE, SIBS_COLID "+
				"FROM vw_report_DISBURSHEET_COL_MISC "+
				"WHERE AP_REGNO='"+LBL_APREGNO.Text+"' AND PRODUCTID='"+LBL_PRODUCTID.Text+"' ORDER BY ap_regno, productid ";
			conn.ExecuteQuery();
			int j = 0;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				oTableMISC.Rows.Add(new TableRow());
				oTableMISC.Rows[i+j].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j].Cells[0].ColumnSpan	= 2;
				oTableMISC.Rows[i+j].Cells[0].CssClass	= "HeaderReportList";
				oTableMISC.Rows[i+j].Cells[0].Text		= conn.GetFieldValue(i, "CLDESC");

				oTableMISC.Rows.Add(new TableRow());
				oTableMISC.Rows[i+j+1].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j+1].Cells[0].CssClass	= "TDBGColorValue";
				oTableMISC.Rows[i+j+1].Cells[0].Text		= "Keterangan Jaminan";
				oTableMISC.Rows[i+j+1].Cells[0].Width		= 280;
				oTableMISC.Rows[i+j+1].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j+1].Cells[1].CssClass	= "TDBGColorValue";
				oTableMISC.Rows[i+j+1].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_DESC");
					
				oTableMISC.Rows.Add(new TableRow());
				oTableMISC.Rows[i+j+2].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j+2].Cells[0].CssClass	= "TDBGColorValue";
				oTableMISC.Rows[i+j+2].Cells[0].Text		= "Mata Uang";
				oTableMISC.Rows[i+j+2].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j+2].Cells[1].CssClass	= "TDBGColorValue";
				oTableMISC.Rows[i+j+2].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_CURRENCY");

				oTableMISC.Rows.Add(new TableRow());
				oTableMISC.Rows[i+j+3].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j+3].Cells[0].CssClass	= "TDBGColorValue";
				oTableMISC.Rows[i+j+3].Cells[0].Text		= "Klasifikasi Jaminan";
				oTableMISC.Rows[i+j+3].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j+3].Cells[1].CssClass	= "TDBGColorValue";
				oTableMISC.Rows[i+j+3].Cells[1].Text		= ": "+conn.GetFieldValue(i, "COLCLASSDESC");
				
				oTableMISC.Rows.Add(new TableRow());
				oTableMISC.Rows[i+j+4].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j+4].Cells[0].CssClass	= "TDBGColorValue";
				oTableMISC.Rows[i+j+4].Cells[0].Text		= "SIBS Collateral ID";
				oTableMISC.Rows[i+j+4].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j+4].Cells[1].CssClass	= "TDBGColorValue";
				oTableMISC.Rows[i+j+4].Cells[1].Text		= ": "+conn.GetFieldValue(i, "SIBS_COLID");

				oTableMISC.Rows.Add(new TableRow());
				oTableMISC.Rows[i+j+5].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j+5].Cells[0].CssClass	= "TDBGColorValue";
				oTableMISC.Rows[i+j+5].Cells[0].Text		= "Nilai Jaminan";
				oTableMISC.Rows[i+j+5].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j+5].Cells[1].CssClass	= "TDBGColorValue";
				oTableMISC.Rows[i+j+5].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_PROPVALUE"));

				oTableMISC.Rows.Add(new TableRow());
				oTableMISC.Rows[i+j+6].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j+6].Cells[0].CssClass	= "TDBGColorValue";
				oTableMISC.Rows[i+j+6].Cells[0].Text		= "Tanggal Penilaian";
				oTableMISC.Rows[i+j+6].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j+6].Cells[1].CssClass	= "TDBGColorValue";
				oTableMISC.Rows[i+j+6].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i, "CL_VALUEDATE"));

				oTableMISC.Rows.Add(new TableRow());
				oTableMISC.Rows[i+j+7].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j+7].Cells[0].CssClass	= "TDBGColorValue";
				oTableMISC.Rows[i+j+7].Cells[0].Text		= "Hasil Penilaian";
				oTableMISC.Rows[i+j+7].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j+7].Cells[1].CssClass	= "TDBGColorValue";
				oTableMISC.Rows[i+j+7].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i,"APPRVALUE"));

				oTableMISC.Rows.Add(new TableRow());
				oTableMISC.Rows[i+j+8].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j+8].Cells[0].CssClass	= "TDBGColorValue";
				oTableMISC.Rows[i+j+8].Cells[0].Text		= "Tanggal Taksiran";
				oTableMISC.Rows[i+j+8].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j+8].Cells[1].CssClass	= "TDBGColorValue";
				oTableMISC.Rows[i+j+8].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i,"CL_APPRDATE"));

				oTableMISC.Rows.Add(new TableRow());
				oTableMISC.Rows[i+j+9].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j+9].Cells[0].CssClass	= "TDBGColorValue";
				oTableMISC.Rows[i+j+9].Cells[0].Text		= "Nama Penilai";
				oTableMISC.Rows[i+j+9].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j+9].Cells[1].CssClass	= "TDBGColorValue";
				oTableMISC.Rows[i+j+9].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_APPRBY");

				oTableMISC.Rows.Add(new TableRow());
				oTableMISC.Rows[i+j+10].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j+10].Cells[0].CssClass	= "TDBGColorValue";
				oTableMISC.Rows[i+j+10].Cells[0].Text		= "Jenis Agunan";
				oTableMISC.Rows[i+j+10].Cells.Add(new TableCell());
				oTableMISC.Rows[i+j+10].Cells[1].CssClass	= "TDBGColorValue";
				oTableMISC.Rows[i+j+10].Cells[1].Text		= ": "+conn.GetFieldValue(i, "AGUNANDESC");
				j = j + 10;
			}
		}

		private void CollPG()
		{
			oTablePG.Visible	= true;
			conn.QueryString = "SELECT * "+
				"FROM vw_report_DISBURSHEET_COL_PG "+
				"WHERE AP_REGNO='"+LBL_APREGNO.Text+"' AND PRODUCTID='"+LBL_PRODUCTID.Text+"' ORDER BY ap_regno, productid ";
			conn.ExecuteQuery();
			int j = 0;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				oTablePG.Rows.Add(new TableRow());
				oTablePG.Rows[i+j].Cells.Add(new TableCell());
				oTablePG.Rows[i+j].Cells[0].ColumnSpan	= 2;
				oTablePG.Rows[i+j].Cells[0].CssClass	= "HeaderReportList";
				oTablePG.Rows[i+j].Cells[0].Text		= conn.GetFieldValue(i, "CLDESC");

				oTablePG.Rows.Add(new TableRow());
				oTablePG.Rows[i+j+1].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+1].Cells[0].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+1].Cells[0].Text		= "Keterangan Jaminan";
				oTablePG.Rows[i+j+1].Cells[0].Width		= 280;
				oTablePG.Rows[i+j+1].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+1].Cells[1].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+1].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_DESC");
					
				oTablePG.Rows.Add(new TableRow());
				oTablePG.Rows[i+j+2].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+2].Cells[0].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+2].Cells[0].Text		= "Mata Uang";
				oTablePG.Rows[i+j+2].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+2].Cells[1].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+2].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_CURRENCY");

				oTablePG.Rows.Add(new TableRow());
				oTablePG.Rows[i+j+3].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+3].Cells[0].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+3].Cells[0].Text		= "Klasifikasi Jaminan";
				oTablePG.Rows[i+j+3].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+3].Cells[1].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+3].Cells[1].Text		= ": "+conn.GetFieldValue(i, "COLCLASSDESC");
					
				oTablePG.Rows.Add(new TableRow());
				oTablePG.Rows[i+j+4].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+4].Cells[0].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+4].Cells[0].Text		= "SIBS Collateral ID";
				oTablePG.Rows[i+j+4].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+4].Cells[1].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+4].Cells[1].Text		= ": "+conn.GetFieldValue(i, "SIBS_COLID");

				oTablePG.Rows.Add(new TableRow());
				oTablePG.Rows[i+j+5].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+5].Cells[0].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+5].Cells[0].Text		= "Hubungan";
				oTablePG.Rows[i+j+5].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+5].Cells[1].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+5].Cells[1].Text		= ": "+conn.GetFieldValue(i, "RELTYPEDESC");

				oTablePG.Rows.Add(new TableRow());
				oTablePG.Rows[i+j+6].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+6].Cells[0].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+6].Cells[0].Text		= "No. Buku Log.";
				oTablePG.Rows[i+j+6].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+6].Cells[1].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+6].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_LOGBOOKNO");

				oTablePG.Rows.Add(new TableRow());
				oTablePG.Rows[i+j+7].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+7].Cells[0].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+7].Cells[0].Text		= "Nilai Jaminan";
				oTablePG.Rows[i+j+7].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+7].Cells[1].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+7].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_PROPVALUE"));

				oTablePG.Rows.Add(new TableRow());
				oTablePG.Rows[i+j+8].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+8].Cells[0].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+8].Cells[0].Text		= "Nilai Garansi";
				oTablePG.Rows[i+j+8].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+8].Cells[1].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+8].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_GUARANTEEVAL"));

				oTablePG.Rows.Add(new TableRow());
				oTablePG.Rows[i+j+9].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+9].Cells[0].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+9].Cells[0].Text		= "Tanggal Kontrak";
				oTablePG.Rows[i+j+9].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+9].Cells[1].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+9].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i,"CL_CONTRACTDATE"));

				oTablePG.Rows.Add(new TableRow());
				oTablePG.Rows[i+j+10].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+10].Cells[0].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+10].Cells[0].Text		= "Tgl. Kadaluarsa";
				oTablePG.Rows[i+j+10].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+10].Cells[1].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+10].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i,"CL_DUEDATE"));

				oTablePG.Rows.Add(new TableRow());
				oTablePG.Rows[i+j+11].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+11].Cells[0].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+11].Cells[0].Text		= "Penilaian Menurut";
				oTablePG.Rows[i+j+11].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+11].Cells[1].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+11].Cells[1].Text		= ": "+conn.GetFieldValue(i, "ACCRDTODESC");
					
				oTablePG.Rows.Add(new TableRow());
				oTablePG.Rows[i+j+12].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+12].Cells[0].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+12].Cells[0].Text		= "Jenis Agunan";
				oTablePG.Rows[i+j+12].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+12].Cells[1].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+12].Cells[1].Text		= ": "+conn.GetFieldValue(i, "AGUNANDESC");

				oTablePG.Rows.Add(new TableRow());
				oTablePG.Rows[i+j+13].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+13].Cells[0].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+13].Cells[0].Text		= "Nama Garansi";
				oTablePG.Rows[i+j+13].Cells.Add(new TableCell());
				oTablePG.Rows[i+j+13].Cells[1].CssClass	= "TDBGColorValue";
				oTablePG.Rows[i+j+13].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_GUARANTEENAME");
				j = j + 13;
			}
		}

		private void CollPNCHQ()
		{
			oTablePNCHQ.Visible	= true;
			conn.QueryString = "SELECT * "+
				"FROM vw_report_DISBURSHEET_COL_PNCHQ "+
				"WHERE AP_REGNO='"+LBL_APREGNO.Text+"' AND PRODUCTID='"+LBL_PRODUCTID.Text+"' ORDER BY ap_regno, productid ";
			conn.ExecuteQuery();
			int j = 0;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				oTablePNCHQ.Rows.Add(new TableRow());
				oTablePNCHQ.Rows[i+j].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j].Cells[0].ColumnSpan	= 2;
				oTablePNCHQ.Rows[i+j].Cells[0].CssClass		= "HeaderReportList";
				oTablePNCHQ.Rows[i+j].Cells[0].Text			= conn.GetFieldValue(i, "CLDESC");

				oTablePNCHQ.Rows.Add(new TableRow());
				oTablePNCHQ.Rows[i+j+1].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+1].Cells[0].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+1].Cells[0].Text		= "Keterangan Jaminan";
				oTablePNCHQ.Rows[i+j+1].Cells[0].Width		= 280;
				oTablePNCHQ.Rows[i+j+1].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+1].Cells[1].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+1].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_DESC");
					
				oTablePNCHQ.Rows.Add(new TableRow());
				oTablePNCHQ.Rows[i+j+2].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+2].Cells[0].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+2].Cells[0].Text		= "Mata Uang";
				oTablePNCHQ.Rows[i+j+2].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+2].Cells[1].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+2].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_CURRENCY");

				oTablePNCHQ.Rows.Add(new TableRow());
				oTablePNCHQ.Rows[i+j+3].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+3].Cells[0].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+3].Cells[0].Text		= "Klasifikasi Jaminan";
				oTablePNCHQ.Rows[i+j+3].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+3].Cells[1].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+3].Cells[1].Text		= ": "+conn.GetFieldValue(i, "COLCLASSDESC");
					
				oTablePNCHQ.Rows.Add(new TableRow());
				oTablePNCHQ.Rows[i+j+4].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+4].Cells[0].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+4].Cells[0].Text		= "SIBS Collateral ID";
				oTablePNCHQ.Rows[i+j+4].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+4].Cells[1].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+4].Cells[1].Text		= ": "+conn.GetFieldValue(i, "SIBS_COLID");

				oTablePNCHQ.Rows.Add(new TableRow());
				oTablePNCHQ.Rows[i+j+5].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+5].Cells[0].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+5].Cells[0].Text		= "No. Cheques";
				oTablePNCHQ.Rows[i+j+5].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+5].Cells[1].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+5].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CHECKNO");

				oTablePNCHQ.Rows.Add(new TableRow());
				oTablePNCHQ.Rows[i+j+6].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+6].Cells[0].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+6].Cells[0].Text		= "Tanggal Cheques";
				oTablePNCHQ.Rows[i+j+6].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+6].Cells[1].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+6].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i, "CL_CHECKDATE"));

				oTablePNCHQ.Rows.Add(new TableRow());
				oTablePNCHQ.Rows[i+j+7].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+7].Cells[0].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+7].Cells[0].Text		= "Nilai Jaminan";
				oTablePNCHQ.Rows[i+j+7].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+7].Cells[1].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+7].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_PROPVALUE"));

				oTablePNCHQ.Rows.Add(new TableRow());
				oTablePNCHQ.Rows[i+j+8].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+8].Cells[0].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+8].Cells[0].Text		= "Jumlah";
				oTablePNCHQ.Rows[i+j+8].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+8].Cells[1].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+8].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_AMOUNT"));

				oTablePNCHQ.Rows.Add(new TableRow());
				oTablePNCHQ.Rows[i+j+9].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+9].Cells[0].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+9].Cells[0].Text		= "Nama Penarik";
				oTablePNCHQ.Rows[i+j+9].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+9].Cells[1].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+9].Cells[1].Text		= ": "+conn.GetFieldValue(i,"CL_CASHEDBY");

				oTablePNCHQ.Rows.Add(new TableRow());
				oTablePNCHQ.Rows[i+j+10].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+10].Cells[0].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+10].Cells[0].Text		= "Endorsers";
				oTablePNCHQ.Rows[i+j+10].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+10].Cells[1].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+10].Cells[1].Text		= ": "+conn.GetFieldValue(i,"CL_ENDORSERS");

				oTablePNCHQ.Rows.Add(new TableRow());
				oTablePNCHQ.Rows[i+j+11].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+11].Cells[0].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+11].Cells[0].Text		= "Nama Holder / Payee";
				oTablePNCHQ.Rows[i+j+11].Cells.Add(new TableCell());
				oTablePNCHQ.Rows[i+j+11].Cells[1].CssClass	= "TDBGColorValue";
				oTablePNCHQ.Rows[i+j+11].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_PAYEE");
				j = j + 11;
			}
		}

		private void CollSPK()
		{
			oTableSPK.Visible	= true;
			conn.QueryString = "select CLDESC, CL_DESC, CL_CURRENCY, COLCLASSDESC, CL_JOBDISTNM, "+
				"CL_ISSUEDATE, CL_EXPDATE, CL_PROPVALUE, SIBS_COLID "+
				"FROM vw_report_DISBURSHEET_COL_SPK "+
				"WHERE AP_REGNO='"+LBL_APREGNO.Text+"' AND PRODUCTID='"+LBL_PRODUCTID.Text+"' ORDER BY ap_regno, productid ";
			conn.ExecuteQuery();
			int j = 0;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				oTableSPK.Rows.Add(new TableRow());
				oTableSPK.Rows[i+j].Cells.Add(new TableCell());
				oTableSPK.Rows[i+j].Cells[0].ColumnSpan	= 2;
				oTableSPK.Rows[i+j].Cells[0].CssClass	= "HeaderReportList";
				oTableSPK.Rows[i+j].Cells[0].Text		= conn.GetFieldValue(i, "CLDESC");

				oTableSPK.Rows.Add(new TableRow());
				oTableSPK.Rows[i+j+1].Cells.Add(new TableCell());
				oTableSPK.Rows[i+j+1].Cells[0].CssClass	= "TDBGColorValue";
				oTableSPK.Rows[i+j+1].Cells[0].Text		= "Keterangan Jaminan";
				oTableSPK.Rows[i+j+1].Cells[0].Width	= 280;
				oTableSPK.Rows[i+j+1].Cells.Add(new TableCell());
				oTableSPK.Rows[i+j+1].Cells[1].CssClass	= "TDBGColorValue";
				oTableSPK.Rows[i+j+1].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_DESC");
					
				oTableSPK.Rows.Add(new TableRow());
				oTableSPK.Rows[i+j+2].Cells.Add(new TableCell());
				oTableSPK.Rows[i+j+2].Cells[0].CssClass	= "TDBGColorValue";
				oTableSPK.Rows[i+j+2].Cells[0].Text		= "Mata Uang";
				oTableSPK.Rows[i+j+2].Cells.Add(new TableCell());
				oTableSPK.Rows[i+j+2].Cells[1].CssClass	= "TDBGColorValue";
				oTableSPK.Rows[i+j+2].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_CURRENCY");

				oTableSPK.Rows.Add(new TableRow());
				oTableSPK.Rows[i+j+3].Cells.Add(new TableCell());
				oTableSPK.Rows[i+j+3].Cells[0].CssClass	= "TDBGColorValue";
				oTableSPK.Rows[i+j+3].Cells[0].Text		= "Klasifikasi Jaminan";
				oTableSPK.Rows[i+j+3].Cells.Add(new TableCell());
				oTableSPK.Rows[i+j+3].Cells[1].CssClass	= "TDBGColorValue";
				oTableSPK.Rows[i+j+3].Cells[1].Text		= ": "+conn.GetFieldValue(i, "COLCLASSDESC");
					
				oTableSPK.Rows.Add(new TableRow());
				oTableSPK.Rows[i+j+4].Cells.Add(new TableCell());
				oTableSPK.Rows[i+j+4].Cells[0].CssClass	= "TDBGColorValue";
				oTableSPK.Rows[i+j+4].Cells[0].Text		= "SIBS Collateral ID";
				oTableSPK.Rows[i+j+4].Cells.Add(new TableCell());
				oTableSPK.Rows[i+j+4].Cells[1].CssClass	= "TDBGColorValue";
				oTableSPK.Rows[i+j+4].Cells[1].Text		= ": "+conn.GetFieldValue(i, "SIBS_COLID");

				oTableSPK.Rows.Add(new TableRow());
				oTableSPK.Rows[i+j+5].Cells.Add(new TableCell());
				oTableSPK.Rows[i+j+5].Cells[0].CssClass	= "TDBGColorValue";
				oTableSPK.Rows[i+j+5].Cells[0].Text		= "Job Distributor's Name";
				oTableSPK.Rows[i+j+5].Cells.Add(new TableCell());
				oTableSPK.Rows[i+j+5].Cells[1].CssClass	= "TDBGColorValue";
				oTableSPK.Rows[i+j+5].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_JOBDISTNM");

				oTableSPK.Rows.Add(new TableRow());
				oTableSPK.Rows[i+j+6].Cells.Add(new TableCell());
				oTableSPK.Rows[i+j+6].Cells[0].CssClass	= "TDBGColorValue";
				oTableSPK.Rows[i+j+6].Cells[0].Text		= "Nilai Jaminan";
				oTableSPK.Rows[i+j+6].Cells.Add(new TableCell());
				oTableSPK.Rows[i+j+6].Cells[1].CssClass	= "TDBGColorValue";
				oTableSPK.Rows[i+j+6].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_PROPVALUE"));

				oTableSPK.Rows.Add(new TableRow());
				oTableSPK.Rows[i+j+7].Cells.Add(new TableCell());
				oTableSPK.Rows[i+j+7].Cells[0].CssClass	= "TDBGColorValue";
				oTableSPK.Rows[i+j+7].Cells[0].Text		= "Tanggal Penerbitan";
				oTableSPK.Rows[i+j+7].Cells.Add(new TableCell());
				oTableSPK.Rows[i+j+7].Cells[1].CssClass	= "TDBGColorValue";
				oTableSPK.Rows[i+j+7].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i,"CL_ISSUEDATE"));
					
				oTableSPK.Rows.Add(new TableRow());
				oTableSPK.Rows[i+j+8].Cells.Add(new TableCell());
				oTableSPK.Rows[i+j+8].Cells[0].CssClass	= "TDBGColorValue";
				oTableSPK.Rows[i+j+8].Cells[0].Text		= "Tanggal Kadaluarsa";
				oTableSPK.Rows[i+j+8].Cells.Add(new TableCell());
				oTableSPK.Rows[i+j+8].Cells[1].CssClass	= "TDBGColorValue";
				oTableSPK.Rows[i+j+8].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i,"CL_EXPDATE"));
				j = j + 8;
			}
		}

		private void CollSTOCK()
		{
			oTableSTOCK.Visible	= true;
			conn.QueryString = "SELECT * "+
				"FROM vw_report_DISBURSHEET_COL_STOCK "+
				"WHERE AP_REGNO='"+LBL_APREGNO.Text+"' AND PRODUCTID='"+LBL_PRODUCTID.Text+"' ORDER BY ap_regno, productid ";
			conn.ExecuteQuery();
			int j = 0;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				oTableSTOCK.Rows.Add(new TableRow());
				oTableSTOCK.Rows[i+j].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j].Cells[0].ColumnSpan	= 2;
				oTableSTOCK.Rows[i+j].Cells[0].CssClass	= "HeaderReportList";
				oTableSTOCK.Rows[i+j].Cells[0].Text		= conn.GetFieldValue(i, "CLDESC");

				oTableSTOCK.Rows.Add(new TableRow());
				oTableSTOCK.Rows[i+j+1].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+1].Cells[0].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+1].Cells[0].Text		= "Keterangan Jaminan";
				oTableSTOCK.Rows[i+j+1].Cells[0].Width		= 280;
				oTableSTOCK.Rows[i+j+1].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+1].Cells[1].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+1].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_DESC");
					
				oTableSTOCK.Rows.Add(new TableRow());
				oTableSTOCK.Rows[i+j+2].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+2].Cells[0].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+2].Cells[0].Text		= "Mata Uang";
				oTableSTOCK.Rows[i+j+2].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+2].Cells[1].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+2].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_CURRENCY");

				oTableSTOCK.Rows.Add(new TableRow());
				oTableSTOCK.Rows[i+j+3].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+3].Cells[0].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+3].Cells[0].Text		= "Klasifikasi Jaminan";
				oTableSTOCK.Rows[i+j+3].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+3].Cells[1].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+3].Cells[1].Text		= ": "+conn.GetFieldValue(i, "COLCLASSDESC");
					
				oTableSTOCK.Rows.Add(new TableRow());
				oTableSTOCK.Rows[i+j+4].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+4].Cells[0].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+4].Cells[0].Text		= "SIBS Collateral ID";
				oTableSTOCK.Rows[i+j+4].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+4].Cells[1].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+4].Cells[1].Text		= ": "+conn.GetFieldValue(i, "SIBS_COLID");

				oTableSTOCK.Rows.Add(new TableRow());
				oTableSTOCK.Rows[i+j+5].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+5].Cells[0].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+5].Cells[0].Text		= "Share Counter";
				oTableSTOCK.Rows[i+j+5].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+5].Cells[1].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+5].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_SHARECNTR");

				oTableSTOCK.Rows.Add(new TableRow());
				oTableSTOCK.Rows[i+j+6].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+6].Cells[0].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+6].Cells[0].Text		= "Share Counter No.";
				oTableSTOCK.Rows[i+j+6].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+6].Cells[1].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+6].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_SHARECNTRNO");

				oTableSTOCK.Rows.Add(new TableRow());
				oTableSTOCK.Rows[i+j+7].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+7].Cells[0].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+7].Cells[0].Text		= "Number Of Share";
				oTableSTOCK.Rows[i+j+7].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+7].Cells[1].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+7].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_NOOFSHARE");

				oTableSTOCK.Rows.Add(new TableRow());
				oTableSTOCK.Rows[i+j+8].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+8].Cells[0].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+8].Cells[0].Text		= "Nilai Jaminan";
				oTableSTOCK.Rows[i+j+8].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+8].Cells[1].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+8].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_PROPVALUE"));

				oTableSTOCK.Rows.Add(new TableRow());
				oTableSTOCK.Rows[i+j+9].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+9].Cells[0].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+9].Cells[0].Text		= "Unit Price";
				oTableSTOCK.Rows[i+j+9].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+9].Cells[1].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+9].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i,"CL_UNITPRICE"));

				oTableSTOCK.Rows.Add(new TableRow());
				oTableSTOCK.Rows[i+j+10].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+10].Cells[0].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+10].Cells[0].Text		= "Tanggal Penilaian";
				oTableSTOCK.Rows[i+j+10].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+10].Cells[1].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+10].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i,"CL_APPRDATE"));

				oTableSTOCK.Rows.Add(new TableRow());
				oTableSTOCK.Rows[i+j+11].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+11].Cells[0].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+11].Cells[0].Text		= "Peringkat Surat Berharga";
				oTableSTOCK.Rows[i+j+11].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+11].Cells[1].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+11].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_PERINGKAT");
					
				oTableSTOCK.Rows.Add(new TableRow());
				oTableSTOCK.Rows[i+j+12].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+12].Cells[0].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+12].Cells[0].Text		= "Jenis Agunan";
				oTableSTOCK.Rows[i+j+12].Cells.Add(new TableCell());
				oTableSTOCK.Rows[i+j+12].Cells[1].CssClass	= "TDBGColorValue";
				oTableSTOCK.Rows[i+j+12].Cells[1].Text		= ": "+conn.GetFieldValue(i, "AGUNANDESC");
				j = j + 12;
			}
		}

		private void CollTRCON()
		{
			oTableTRCON.Visible	= true;
			conn.QueryString = "SELECT * "+
				"FROM vw_report_DISBURSHEET_COL_TRCON "+
				"WHERE AP_REGNO='"+LBL_APREGNO.Text+"' AND PRODUCTID='"+LBL_PRODUCTID.Text+"' ORDER BY ap_regno ";
			conn.ExecuteQuery();
			int j = 0;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				oTableTRCON.Rows.Add(new TableRow());
				oTableTRCON.Rows[i+j].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j].Cells[0].ColumnSpan	= 2;
				oTableTRCON.Rows[i+j].Cells[0].CssClass	= "HeaderReportList";
				oTableTRCON.Rows[i+j].Cells[0].Text		= conn.GetFieldValue(i, "CLDESC");

				oTableTRCON.Rows.Add(new TableRow());
				oTableTRCON.Rows[i+j+1].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+1].Cells[0].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+1].Cells[0].Text		= "Keterangan Jaminan";
				oTableTRCON.Rows[i+j+1].Cells[0].Width		= 280;
				oTableTRCON.Rows[i+j+1].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+1].Cells[1].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+1].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_DESC");
					
				oTableTRCON.Rows.Add(new TableRow());
				oTableTRCON.Rows[i+j+2].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+2].Cells[0].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+2].Cells[0].Text		= "Mata Uang";
				oTableTRCON.Rows[i+j+2].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+2].Cells[1].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+2].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_CURRENCY");

				oTableTRCON.Rows.Add(new TableRow());
				oTableTRCON.Rows[i+j+3].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+3].Cells[0].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+3].Cells[0].Text		= "Klasifikasi Jaminan";
				oTableTRCON.Rows[i+j+3].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+3].Cells[1].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+3].Cells[1].Text		= ": "+conn.GetFieldValue(i, "COLCLASSDESC");
					
				oTableTRCON.Rows.Add(new TableRow());
				oTableTRCON.Rows[i+j+4].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+4].Cells[0].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+4].Cells[0].Text		= "SIBS Collateral ID";
				oTableTRCON.Rows[i+j+4].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+4].Cells[1].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+4].Cells[1].Text		= ": "+conn.GetFieldValue(i, "SIBS_COLID");

				oTableTRCON.Rows.Add(new TableRow());
				oTableTRCON.Rows[i+j+5].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+5].Cells[0].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+5].Cells[0].Text		= "Nama Kontrak";
				oTableTRCON.Rows[i+j+5].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+5].Cells[1].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+5].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_CONTRACTNAME");

				oTableTRCON.Rows.Add(new TableRow());
				oTableTRCON.Rows[i+j+6].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+6].Cells[0].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+6].Cells[0].Text		= "No. Kontrak";
				oTableTRCON.Rows[i+j+6].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+6].Cells[1].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+6].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CHECKNO");

				oTableTRCON.Rows.Add(new TableRow());
				oTableTRCON.Rows[i+j+7].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+7].Cells[0].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+7].Cells[0].Text		= "Jumlah Kontrak";
				oTableTRCON.Rows[i+j+7].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+7].Cells[1].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+7].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_CONTRACTAMNT"));

				oTableTRCON.Rows.Add(new TableRow());
				oTableTRCON.Rows[i+j+8].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+8].Cells[0].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+8].Cells[0].Text		= "Tanggal Penilaian";
				oTableTRCON.Rows[i+j+8].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+8].Cells[1].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+8].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i, "CL_APPRDATE"));

				oTableTRCON.Rows.Add(new TableRow());
				oTableTRCON.Rows[i+j+9].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+9].Cells[0].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+9].Cells[0].Text		= "Dealer";
				oTableTRCON.Rows[i+j+9].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+9].Cells[1].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+9].Cells[1].Text		= ": "+conn.GetFieldValue(i, "DEALERDESC");

				oTableTRCON.Rows.Add(new TableRow());
				oTableTRCON.Rows[i+j+10].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+10].Cells[0].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+10].Cells[0].Text		= "Nilai Jaminan";
				oTableTRCON.Rows[i+j+10].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+10].Cells[1].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+10].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_PROPVALUE"));

				oTableTRCON.Rows.Add(new TableRow());
				oTableTRCON.Rows[i+j+11].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+11].Cells[0].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+11].Cells[0].Text		= "Nilai Garansi";
				oTableTRCON.Rows[i+j+11].Cells.Add(new TableCell());
				oTableTRCON.Rows[i+j+11].Cells[1].CssClass	= "TDBGColorValue";
				oTableTRCON.Rows[i+j+11].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_GUARANTEEVAL"));
				j = j + 11;
			}
		}

		private void CollVEH()
		{
			oTableVEH.Visible	= true;
			conn.QueryString = "SELECT * "+
				"FROM vw_report_DISBURSHEET_COL_VEH "+
				"WHERE AP_REGNO='"+LBL_APREGNO.Text+"' AND PRODUCTID='"+LBL_PRODUCTID.Text+"' ORDER BY ap_regno, productid ";
			conn.ExecuteQuery();
			int j = 0;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j].Cells[0].ColumnSpan	= 2;
				oTableVEH.Rows[i+j].Cells[0].CssClass	= "HeaderReportList";
				oTableVEH.Rows[i+j].Cells[0].Text		= conn.GetFieldValue(i, "CLDESC");

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+1].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+1].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+1].Cells[0].Text		= "Keterangan Jaminan";
				oTableVEH.Rows[i+j+1].Cells[0].Width	= 280;
				oTableVEH.Rows[i+j+1].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+1].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+1].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_DESC");
					
				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+2].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+2].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+2].Cells[0].Text		= "Mata Uang";
				oTableVEH.Rows[i+j+2].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+2].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+2].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_CURRENCY");

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+3].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+3].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+3].Cells[0].Text		= "Klasifikasi Jaminan";
				oTableVEH.Rows[i+j+3].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+3].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+3].Cells[1].Text		= ": "+conn.GetFieldValue(i, "COLCLASSDESC");
					
				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+4].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+4].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+4].Cells[0].Text		= "SIBS Collateral ID";
				oTableVEH.Rows[i+j+4].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+4].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+4].Cells[1].Text		= ": "+conn.GetFieldValue(i, "SIBS_COLID");

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+5].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+5].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+5].Cells[0].Text		= "Dealer";
				oTableVEH.Rows[i+j+5].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+5].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+5].Cells[1].Text		= ": "+conn.GetFieldValue(i, "DEALERDESC");

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+6].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+6].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+6].Cells[0].Text		= "No. Mesin";
				oTableVEH.Rows[i+j+6].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+6].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+6].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_MACHINENO");

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+7].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+7].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+7].Cells[0].Text		= "Number of Unit";
				oTableVEH.Rows[i+j+7].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+7].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+7].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_NOOFUNITS");

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+8].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+8].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+8].Cells[0].Text		= "Manufactured Year";
				oTableVEH.Rows[i+j+8].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+8].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+8].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_MANUFACTUREYY");

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+9].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+9].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+9].Cells[0].Text		= "No. Chasis/ Seri";
				oTableVEH.Rows[i+j+9].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+9].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+9].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_CHASISNO");

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+10].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+10].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+10].Cells[0].Text		= "Jenis Kendaraan";
				oTableVEH.Rows[i+j+10].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+10].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+10].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_JNSMOBIL");

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+11].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+11].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+11].Cells[0].Text		= "Type / Jenis Unit";
				oTableVEH.Rows[i+j+11].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+11].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+11].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CARTYPEDESC");
					
				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+12].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+12].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+12].Cells[0].Text		= "Brand / Model";
				oTableVEH.Rows[i+j+12].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+12].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+12].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_CARBRAND");

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+13].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+13].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+13].Cells[0].Text		= "Owner / Nama BPKB";
				oTableVEH.Rows[i+j+13].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+13].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+13].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_OWNER");

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+14].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+14].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+14].Cells[0].Text		= "Hubungan";
				oTableVEH.Rows[i+j+14].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+14].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+14].Cells[1].Text		= ": "+conn.GetFieldValue(i, "RELTYPEDESC");

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+15].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+15].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+15].Cells[0].Text		= "No. BPKB";
				oTableVEH.Rows[i+j+15].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+15].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+15].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_BPKBNO");

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+16].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+16].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+16].Cells[0].Text		= "No. Polisi";
				oTableVEH.Rows[i+j+16].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+16].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+16].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_PLATEID");

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+17].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+17].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+17].Cells[0].Text		= "Dinilai Oleh";
				oTableVEH.Rows[i+j+17].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+17].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+17].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_APPRBY");

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+18].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+18].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+18].Cells[0].Text		= "Tgl. Penerbitan";
				oTableVEH.Rows[i+j+18].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+18].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+18].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i, "CL_ISSUEDDATE"));

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+19].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+19].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+19].Cells[0].Text		= "Nilai Jaminan";
				oTableVEH.Rows[i+j+19].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+19].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+19].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_PROPVALUE"));

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+20].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+20].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+20].Cells[0].Text		= "Jumlah Penilaian";
				oTableVEH.Rows[i+j+20].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+20].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+20].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_APPRVALUE"));

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+21].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+21].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+21].Cells[0].Text		= "Nilai Pasar";
				oTableVEH.Rows[i+j+21].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+21].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+21].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_MARKETVAL"));

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+22].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+22].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+22].Cells[0].Text		= "Nilai Agunan Untuk PPAP";
				oTableVEH.Rows[i+j+22].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+22].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+22].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_PPAPVAL"));

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+23].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+23].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+23].Cells[0].Text		= "Lokasi Agunan";
				oTableVEH.Rows[i+j+23].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+23].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+23].Cells[1].Text		= ": "+conn.GetFieldValue(i, "LOCATIONDESC");

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+24].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+24].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+24].Cells[0].Text		= "Penilaian Menurut";
				oTableVEH.Rows[i+j+24].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+24].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+24].Cells[1].Text		= ": "+conn.GetFieldValue(i, "ACCRDTODESC");

				oTableVEH.Rows.Add(new TableRow());
				oTableVEH.Rows[i+j+25].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+25].Cells[0].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+25].Cells[0].Text		= "Jenis Agunan";
				oTableVEH.Rows[i+j+25].Cells.Add(new TableCell());
				oTableVEH.Rows[i+j+25].Cells[1].CssClass	= "TDBGColorValue";
				oTableVEH.Rows[i+j+25].Cells[1].Text		= ": "+conn.GetFieldValue(i, "AGUNANDESC");
				j = j + 25;
			}
		}

		private void CollRE()
		{
			oTableRE.Visible	= true;
			conn.QueryString = "SELECT * "+
				"FROM vw_report_DISBURSHEET_COL_RE "+
				"WHERE AP_REGNO='"+LBL_APREGNO.Text+"' AND PRODUCTID='"+LBL_PRODUCTID.Text+"' ORDER BY ap_regno, productid ";
			conn.ExecuteQuery();
			int j = 0;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j].Cells.Add(new TableCell());
				oTableRE.Rows[i+j].Cells[0].ColumnSpan	= 2;
				oTableRE.Rows[i+j].Cells[0].CssClass	= "HeaderReportList";
				oTableRE.Rows[i+j].Cells[0].Text		= conn.GetFieldValue(i, "CLDESC");

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+1].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+1].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+1].Cells[0].Text		= "Keterangan Jaminan";
				oTableRE.Rows[i+j+1].Cells[0].Width		= 280;
				oTableRE.Rows[i+j+1].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+1].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+1].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_DESC");
					
				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+2].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+2].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+2].Cells[0].Text		= "Mata Uang";
				oTableRE.Rows[i+j+2].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+2].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+2].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_CURRENCY");

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+3].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+3].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+3].Cells[0].Text		= "Klasifikasi Jaminan";
				oTableRE.Rows[i+j+3].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+3].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+3].Cells[1].Text		= ": "+conn.GetFieldValue(i, "COLCLASSDESC");
					
				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+4].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+4].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+4].Cells[0].Text		= "SIBS Collateral ID";
				oTableRE.Rows[i+j+4].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+4].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+4].Cells[1].Text		= ": "+conn.GetFieldValue(i, "SIBS_COLID");

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+5].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+5].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+5].Cells[0].Text		= "Bukti Pemilikan Hak";
				oTableRE.Rows[i+j+5].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+5].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+5].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CERTTYPEDESC");

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+6].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+6].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+6].Cells[0].Text		= "Property Type";
				oTableRE.Rows[i+j+6].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+6].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+6].Cells[1].Text		= ": "+conn.GetFieldValue(i, "PROPTYPEDESC");

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+7].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+7].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+7].Cells[0].Text		= "No sertifikat";
				oTableRE.Rows[i+j+7].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+7].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+7].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_CERTNO");

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+8].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+8].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+8].Cells[0].Text		= "Tgl Terbit Sertifikat";
				oTableRE.Rows[i+j+8].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+8].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+8].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i, "CL_CERTISSUE"));

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+9].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+9].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+9].Cells[0].Text		= "Tgl Kadaluarsa Sertifikat";
				oTableRE.Rows[i+j+9].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+9].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+9].Cells[1].Text		= ": "+tools.FormatDate(conn.GetFieldValue(i,"CL_CERTEXPIRE"));

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+10].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+10].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+10].Cells[0].Text		= "Luas Tanah";
				oTableRE.Rows[i+j+10].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+10].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+10].Cells[1].Text		= ": "+conn.GetFieldValue(i, "luastanah");

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+11].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+11].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+11].Cells[0].Text		= "Luas Bangunan";
				oTableRE.Rows[i+j+11].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+11].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+11].Cells[1].Text		= ": "+conn.GetFieldValue(i, "luasbangunan");
					
				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+12].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+12].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+12].Cells[0].Text		= "Nama Pemilik";
				oTableRE.Rows[i+j+12].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+12].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+12].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_OWNER");

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+13].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+13].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+13].Cells[0].Text		= "Hubungan";
				oTableRE.Rows[i+j+13].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+13].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+13].Cells[1].Text		= ": "+conn.GetFieldValue(i, "RELTYPEDESC");

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+14].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+14].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+14].Cells[0].Text		= "Nilai Jaminan";
				oTableRE.Rows[i+j+14].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+14].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+14].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_PROPVALUE"));

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+15].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+15].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+15].Cells[0].Text		= "Hasil Penilaian";
				oTableRE.Rows[i+j+15].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+15].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+15].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_APPRVALUE"));

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+16].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+16].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+16].Cells[0].Text		= "Nilai Pasar";
				oTableRE.Rows[i+j+16].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+16].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+16].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_MARKETVAL"));

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+17].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+17].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+17].Cells[0].Text		= "Nilai Agunan Untuk PPAP";
				oTableRE.Rows[i+j+17].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+17].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+17].Cells[1].Text		= ": "+tools.MoneyFormat(conn.GetFieldValue(i, "CL_PPAPVAL"));

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+18].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+18].Cells[0].ColumnSpan = 2;
				oTableRE.Rows[i+j+18].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+18].Cells[0].Text		= "Location of Lot";
				oTableRE.Rows[i+j+18].Cells[0].Font.Bold	= true;

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+19].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+19].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+19].Cells[0].Text		= "Perum/Jalan";
				oTableRE.Rows[i+j+19].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+19].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+19].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_LOCJLN");

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+20].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+20].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+20].Cells[0].Text		= "RT/RW";
				oTableRE.Rows[i+j+20].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+20].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+20].Cells[1].Text		= ": "+conn.GetFieldValue(i, "rtrw");

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+21].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+21].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+21].Cells[0].Text		= "No. Kapling/rumah";
				oTableRE.Rows[i+j+21].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+21].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+21].Cells[1].Text		= ": "+conn.GetFieldValue(i, "CL_LOCKAVNO");

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+22].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+22].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+22].Cells[0].Text		= "Lokasi Agunan";
				oTableRE.Rows[i+j+22].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+22].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+22].Cells[1].Text		= ": "+conn.GetFieldValue(i, "LOCATIONDESC");

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+23].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+23].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+23].Cells[0].Text		= "Penilaian Menurut";
				oTableRE.Rows[i+j+23].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+23].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+23].Cells[1].Text		= ": "+conn.GetFieldValue(i, "ACCRDTODESC");

				oTableRE.Rows.Add(new TableRow());
				oTableRE.Rows[i+j+24].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+24].Cells[0].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+24].Cells[0].Text		= "Jenis Agunan";
				oTableRE.Rows[i+j+24].Cells.Add(new TableCell());
				oTableRE.Rows[i+j+24].Cells[1].CssClass	= "TDBGColorValue";
				oTableRE.Rows[i+j+24].Cells[1].Text		= ": "+conn.GetFieldValue(i, "AGUNANDESC");
				j = j + 24;
			}
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("DisbursementSheet.aspx?tc="+Request.QueryString["tc"]);
		}

		private void AltenateRate(string vapptype)
		{
			conn.QueryString = "select * from alternaterate where ap_regno in (select ap_regno from custproduct where apptype = '" + vapptype + "' and ap_regno = '" + Request.QueryString["regno"]+ "')";
			conn.ExecuteQuery();
			
			if (conn.GetRowCount() > 0)
				PanelAltenateRate.Visible = true;
			else
				PanelAltenateRate.Visible = false;

			
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
					TblAltenateRate.Rows.Add(new TableRow());
					TblAltenateRate.Rows[i+1].Cells.Add(new TableCell());
					TblAltenateRate.Rows[i+1].Cells[0].Text = conn.GetFieldValue(i, "SEQUENCE");
					TblAltenateRate.Rows[i+1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
					TblAltenateRate.Rows[i+1].Cells[0].CssClass	= "ReportList";

					TblAltenateRate.Rows.Add(new TableRow());
					TblAltenateRate.Rows[i+1].Cells.Add(new TableCell());
					TblAltenateRate.Rows[i+1].Cells[1].Text = conn.GetFieldValue(i, "TENOR");
					TblAltenateRate.Rows[i+1].Cells[1].HorizontalAlign = HorizontalAlign.Center;
					TblAltenateRate.Rows[i+1].Cells[1].CssClass	= "ReportList";	
					
					TblAltenateRate.Rows.Add(new TableRow());
					TblAltenateRate.Rows[i+1].Cells.Add(new TableCell());
					TblAltenateRate.Rows[i+1].Cells[2].Text = conn.GetFieldValue(i, "FIXEDRATE");
					TblAltenateRate.Rows[i+1].Cells[2].HorizontalAlign = HorizontalAlign.Center;
					TblAltenateRate.Rows[i+1].Cells[2].CssClass	= "ReportList";	

					TblAltenateRate.Rows.Add(new TableRow());
					TblAltenateRate.Rows[i+1].Cells.Add(new TableCell());
					TblAltenateRate.Rows[i+1].Cells[3].Text = conn.GetFieldValue(i, "FLOATINGRATE");
					TblAltenateRate.Rows[i+1].Cells[3].HorizontalAlign = HorizontalAlign.Center;
					TblAltenateRate.Rows[i+1].Cells[3].CssClass	= "ReportList";	

					TblAltenateRate.Rows.Add(new TableRow());
					TblAltenateRate.Rows[i+1].Cells.Add(new TableCell());
					TblAltenateRate.Rows[i+1].Cells[4].Text = conn.GetFieldValue(i, "VARCODE");
					TblAltenateRate.Rows[i+1].Cells[4].HorizontalAlign = HorizontalAlign.Center;
					TblAltenateRate.Rows[i+1].Cells[4].CssClass	= "ReportList";	

					TblAltenateRate.Rows.Add(new TableRow());
					TblAltenateRate.Rows[i+1].Cells.Add(new TableCell());
					TblAltenateRate.Rows[i+1].Cells[5].Text = conn.GetFieldValue(i, "VARIANCE");
					TblAltenateRate.Rows[i+1].Cells[5].HorizontalAlign = HorizontalAlign.Center;
					TblAltenateRate.Rows[i+1].Cells[5].CssClass	= "ReportList";	

					TblAltenateRate.Rows.Add(new TableRow());
					TblAltenateRate.Rows[i+1].Cells.Add(new TableCell());
					TblAltenateRate.Rows[i+1].Cells[6].Text = tools.MoneyFormat(conn.GetFieldValue(i, "INSTALLMENT"));
					TblAltenateRate.Rows[i+1].Cells[6].HorizontalAlign = HorizontalAlign.Center;
					TblAltenateRate.Rows[i+1].Cells[6].CssClass	= "ReportList";	

			}

		}

		private void PaymentSchedule(string vapptype)
		{
			conn.QueryString = "select * from alternatepayment where ap_regno in (select ap_regno from custproduct where apptype = '" + vapptype + "' and ap_regno = '" + Request.QueryString["regno"]+ "') and mode = 'AP'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
				PanelPaymentSchedule.Visible = true;
			else
				PanelPaymentSchedule.Visible = false;
			
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				TblPaymentSchedule.Rows.Add(new TableRow());
				TblPaymentSchedule.Rows[i+1].Cells.Add(new TableCell());
				TblPaymentSchedule.Rows[i+1].Cells[0].Text = conn.GetFieldValue(i, "SEQ_MONTH");
				TblPaymentSchedule.Rows[i+1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TblPaymentSchedule.Rows[i+1].Cells[0].CssClass	= "ReportList";

				TblPaymentSchedule.Rows.Add(new TableRow());
				TblPaymentSchedule.Rows[i+1].Cells.Add(new TableCell());
				TblPaymentSchedule.Rows[i+1].Cells[1].Text = conn.GetFieldValue(i, "PERCENTAGE");
				TblPaymentSchedule.Rows[i+1].Cells[1].HorizontalAlign = HorizontalAlign.Center;
				TblPaymentSchedule.Rows[i+1].Cells[1].CssClass	= "ReportList";	
					
				TblPaymentSchedule.Rows.Add(new TableRow());
				TblPaymentSchedule.Rows[i+1].Cells.Add(new TableCell());
				TblPaymentSchedule.Rows[i+1].Cells[2].Text = tools.MoneyFormat(conn.GetFieldValue(i, "ALTERNATE_PAYMENT"));
				TblPaymentSchedule.Rows[i+1].Cells[2].HorizontalAlign = HorizontalAlign.Center;
				TblPaymentSchedule.Rows[i+1].Cells[2].CssClass	= "ReportList";	
			}
		
		}

		private void DrawdownSchedule(string vapptype)
		{
			
			conn.QueryString = "select * from alternatepayment where ap_regno in (select ap_regno from custproduct where apptype = '" + vapptype + "' and ap_regno = '" + Request.QueryString["regno"]+ "') and mode = 'DDS'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
				PanelDrawdownSchedule.Visible = true;
			else
				PanelDrawdownSchedule.Visible = false;
			
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				TblDrawdownSchedule.Rows.Add(new TableRow());
				TblDrawdownSchedule.Rows[i+1].Cells.Add(new TableCell());
				TblDrawdownSchedule.Rows[i+1].Cells[0].Text = conn.GetFieldValue(i, "SEQ_MONTH");
				TblDrawdownSchedule.Rows[i+1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TblDrawdownSchedule.Rows[i+1].Cells[0].CssClass	= "ReportList";

				TblDrawdownSchedule.Rows.Add(new TableRow());
				TblDrawdownSchedule.Rows[i+1].Cells.Add(new TableCell());
				TblDrawdownSchedule.Rows[i+1].Cells[1].Text = conn.GetFieldValue(i, "PERCENTAGE");
				TblDrawdownSchedule.Rows[i+1].Cells[1].HorizontalAlign = HorizontalAlign.Center;
				TblDrawdownSchedule.Rows[i+1].Cells[1].CssClass	= "ReportList";	
					
				TblDrawdownSchedule.Rows.Add(new TableRow());
				TblDrawdownSchedule.Rows[i+1].Cells.Add(new TableCell());
				TblDrawdownSchedule.Rows[i+1].Cells[2].Text = tools.MoneyFormat(conn.GetFieldValue(i, "DRAWDOWN_AMOUNT"));
				TblDrawdownSchedule.Rows[i+1].Cells[2].HorizontalAlign = HorizontalAlign.Center;
				TblDrawdownSchedule.Rows[i+1].Cells[2].CssClass	= "ReportList";	
			}
		
		}

		private void show_nomor(string vapptype)
		{
			
			conn.QueryString = "select * from alternaterate where ap_regno in (select ap_regno from custproduct where apptype = '" + vapptype + "' and ap_regno = '" + Request.QueryString["regno"]+ "')";
			conn.ExecuteQuery();
			System.Data.DataTable dtA = new System.Data.DataTable();
			dtA = conn.GetDataTable().Copy();
			
			conn.QueryString = "select * from alternatepayment where ap_regno in (select ap_regno from custproduct where apptype = '" + vapptype + "' and ap_regno = '" + Request.QueryString["regno"]+ "') and mode = 'AP'";
			conn.ExecuteQuery();
			System.Data.DataTable dtB = new System.Data.DataTable();
			dtB = conn.GetDataTable().Copy();

			conn.QueryString = "select * from alternatepayment where ap_regno in (select ap_regno from custproduct where apptype = '" + vapptype + "' and ap_regno = '" + Request.QueryString["regno"]+ "') and mode = 'DDS'";
			conn.ExecuteQuery();
			System.Data.DataTable dtC = new System.Data.DataTable();
			dtC = conn.GetDataTable().Copy();

			//-- show nomor utk alternate rate, payment schedule, drawdown schedule ---------------------------------
			int text = 6;
			if (dtA.Rows.Count>0)
			{
				LBL_NO_ALTERNATERATE.Visible = true;
				LBL_NO_ALTERNATERATE.Text = text.ToString();
				text++;
			}
			if (dtB.Rows.Count>0)
			{
				LBL_NO_PAYMENTSCHEDULE.Visible = true;
				LBL_NO_PAYMENTSCHEDULE.Text = text.ToString();
				text++;
			}
			if (dtC.Rows.Count>0)
			{
				LBL_NO_DRAWDOWNSCHEDULE.Visible = true;
				LBL_NO_DRAWDOWNSCHEDULE.Text = text.ToString();
				text++;
			}
		}
//------------------------------
	}
}
