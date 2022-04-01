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

namespace  SME.CreditProposal.Channeling
{
	/// <summary>
	/// Summary description for ListInitiation.
	/// </summary>
	public partial class EditNasabah : System.Web.UI.Page
	{
		protected Connection conn;

		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			string mc = Request.QueryString["mc"];
			string groupid = Session["GroupID"].ToString();

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				ViewData("0");

				fillDropDownList();
				IsiTanggal();

				fillDataCIF();
				fillDataKetentuanKredit();
				//fillDataAgunan();
				DATA_JAMINAN_TR.Visible = false;
				//fillDataAgunan();
				fillSandiBI();
			}
		}

		private void IsiTanggal()
		{
			GlobalTools.initDateFormINA(TXT_CU_DOB_DAY_1, DDL_CU_DOB_MONTH_1, TXT_CU_DOB_YEAR_1, true);
			//GlobalTools.initDateFormINA(TXT_CU_DOB_DAY_3, DDL_CU_DOB_MONTH_3, TXT_CU_DOB_YEAR_3, true);
			GlobalTools.initDateFormINA(TXT_CU_IDCARDEXP_DAY_1, TXT_CU_IDCARDEXP_MONTH_1, TXT_CU_IDCARDEXP_YEAR_1, true);
			GlobalTools.initDateFormINA(TXT_CL_PENILAIANDATE_DAY_1, TXT_CL_PENILAIANDATE_MONTH_1, TXT_CL_PENILAIANDATE_YEAR_1, true);
		}

		private void fillDropDownList()
		{
			/*
			 *	conn.QueryString = "select branch_name, branch_code from vw_ccobranch order by branch_code";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_AP_CCOBRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,1) + " - " + conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));
			 * */

			/********************************************** CIF Data Field **************************************************/
			conn.QueryString = "select MARITALDESC, MARITALID from RFMARITAL order by MARITALDESC";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CU_MARITAL_1.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));
			
			conn.QueryString = "select SEXDESC, SEXID from RFSEX order by SEXDESC";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CU_SEX_1.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));
			
			/*conn.QueryString = "select ALAMATDESC, ALAMATID from RFJENISALAMAT order by ALAMATDESC";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CU_JNSALAMAT_1.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));

			conn.QueryString = "select EDUCATIONDESC, EDUCATIONID from RFEDUCATION order by EDUCATIONDESC";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CU_EDUCATION_1.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));
			
			conn.QueryString = "select BUSSTYPEDESC, BUSSTYPEID from RFBUSINESSTYPE order by BUSSTYPEDESC";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CU_BUSSTYPE_1.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));*/

			conn.QueryString = "SELECT * FROM VW_NEGARADOMISILI";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CU_NEGARADOMISILI_1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			
			/*conn.QueryString = "select [BI_SEQ], [BI_DESC] from RFBICODE where BG_GROUP = '4' order by [BI_DESC]";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CU_LOKASIPROYEK_1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));*/

			conn.QueryString = "SELECT [BI_SEQ], [BI_DESC] from RFBICODE where BG_GROUP = '4' order by [BI_DESC]";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CU_LOKASIDATI_2.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString = "select citizenid, citizendesc from rfcitizenship ORDER BY citizendesc";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CU_CITIZENSHIP_1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			
			//Hubungan dg Pejabat Executive BM
			conn.QueryString = "SELECT * FROM VW_HUBUNGANEXECUTIVEBM";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CU_HUBEXECBM_1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			/*GlobalTools.fillRefList(DDL_CU_HOMESTA_1, "select * from RFHOMESTA", true, conn);*/
		
		
			/************************************************* Ketentuan Kredit ***************************************************/
			DDL_CP_KETERANGAN_1.Items.Add(new ListItem("Withdrawal", "0"));
			
			//Jenis Pengajuan
			conn.QueryString = "SELECT APPTYPEDESC, APPTYPEID FROM RFAPPLICATIONTYPE ORDER BY APPTYPEDESC";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_APPTYPE_1.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));

			//Jenis Kredit
			//conn.QueryString = "select PRODUCTID, PRODUCTDESC from VW_PROGPROD_CHANNELING WHERE AREAID = '" + Session["AREAID"] + "' ORDER BY PRODUCTDESC";
			conn.QueryString = "SELECT PRODUCTID + '-' + PRODUCTDESC, PRODUCTID FROM RFPRODUCT";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_BI_JENISKREDIT_2.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));

			conn.QueryString = "select LOANPURPID, LOANPURPDESC from RFLOANPURPOSE ORDER BY LOANPURPDESC";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CP_LOANPURPOSE_1.Items.Add(new ListItem(conn.GetFieldValue(i,0) + "-" +conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));


			/*************************************************  Data Agunan ************************************************/
			conn.QueryString = "SELECT CERTTYPEID, CERTTYPEDESC FROM RFCERTTYPE ORDER BY CERTTYPEDESC";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CL_CERTTYPE_1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString = "SELECT IKATID, IKATDESC FROM RFIKAT ORDER BY IKATDESC";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CL_IKATID_1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			/*conn.QueryString = "SELECT CURRENCYID, CURRENCYDESC FROM RFCURRENCY ORDER BY CURRENCYDESC";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CL_CURRENCY_1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));*/

			conn.QueryString = "SELECT COLTYPESEQ, (COLTYPEID + '-' + COLTYPEDESC) as COLTYPEDESC FROM RFCOLLATERALTYPE WHERE COLTYPEID = 'VEH' OR COLTYPEID = 'RE' order by COLTYPESEQ";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_JENIS_AGUNAN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString = "SELECT ACCRDTODESC, ACCRDTOID FROM RFVALUEACCORDING ORDER BY ACCRDTOID";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CL_PENILAIANBY_1.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));

			/************************************************ Sandi BI ****************************************************/
			conn.QueryString = "SELECT [ID], [DESC] FROM VW_CREOPR_BOOKING_SANDIBI_JENISGUNA";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_BI_JENISPENGGUNAAN_1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			
			conn.QueryString = "SELECT (PRODUCTID + '-' + PRODUCTDESC) as PRODUCTDESC, PRODUCTID FROM RFPRODUCT";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_BI_JENISKREDIT_1.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));
			
			conn.QueryString = "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_ORIENTASIGUNA";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_BI_ORIENTASI_1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString = "select BMSUBSUB_CODE, BMSUBSUB_DESC from RFBMSUBSUBSEKTOREKONOMI";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_BM_SUBSUBSEKTOREKON_1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString = "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_SIFATKREDIT";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_BI_SIFATKREDIT_1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString = "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_FASILITASDANA";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_BI_FASILITAS_1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString = "select [BI_SEQ], [BI_DESC] from RFBICODE where BG_GROUP = '4'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CU_LOKASIPROYEK_2.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString = "select BM_CODE, BM_DESC from RFBMSEKTOREKONOMI";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_BM_SEKTOREKONOMI_1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString = "select BMSUB_CODE, BMSUB_DESC from RFBMSUBSEKTOREKONOMI";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_BM_SUBSEKTOREKON_1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString = "select BMSUBSUB_CODE, BMSUBSUB_DESC from RFBMSUBSUBSEKTOREKONOMI";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_BM_SUBSUBSEKTOREKON_1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString = "SELECT BI_SEQ, BI_DESC FROM RFBICODE where BG_GROUP = '3'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_BI_SEKTOREKONOMI_1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		private void fillDataCIF()
		{
			conn.QueryString = "SELECT * FROM CUST_PERSONAL WHERE CU_REF = '" + Request.QueryString["curefanak"] + "'";
			conn.ExecuteQuery();

			TXT_CU_FIRSTNAME_1.Text = conn.GetFieldValue("CU_FIRSTNAME");
			/*TXT_CU_MIDDLENAME_1.Text = conn.GetFieldValue("CU_MIDDLENAME");
			TXT_CU_LASTENAME_1.Text = conn.GetFieldValue("CU_LASTNAME");*/

			TXT_CU_ADDR_1.Text = conn.GetFieldValue("CU_ADDR1"); 
			/*TXT_CU_ADDR_2.Text = conn.GetFieldValue("CU_ADDR2"); 
			TXT_CU_ADDR_3.Text = conn.GetFieldValue("CU_ADDR3");*/
			TXT_KECAMATAN.Text = conn.GetFieldValue("CU_ADDR3");

			TXT_CU_ZIPCODE_1.Text = conn.GetFieldValue("CU_ZIPCODE");
			LabelIDCity1.Text = conn.GetFieldValue("CU_CITY");
			TXT_CU_PHNAREA_1.Text = conn.GetFieldValue("CU_PHNAREA");
			TXT_CU_PHNNUM_1.Text = conn.GetFieldValue("CU_PHNNUM");
			TXT_CU_POB_1.Text = conn.GetFieldValue("CU_POB");
			TXT_CU_DOB_DAY_1.Text = tool.FormatDate_Day(conn.GetFieldValue("CU_DOB"));
			DDL_CU_DOB_MONTH_1.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("CU_DOB"));
			TXT_CU_DOB_YEAR_1.Text = tool.FormatDate_Year(conn.GetFieldValue("CU_DOB"));
			
			TXT_CU_IDCARDNUM_1.Text = conn.GetFieldValue("CU_IDCARDNUM");
			TXT_CU_IDCARDEXP_DAY_1.Text = tool.FormatDate_Day(conn.GetFieldValue("CU_IDCARDEXP"));
			TXT_CU_IDCARDEXP_MONTH_1.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("CU_IDCARDEXP"));
			TXT_CU_IDCARDEXP_YEAR_1.Text = tool.FormatDate_Year(conn.GetFieldValue("CU_IDCARDEXP"));
			/*TXT_CU_KTPADDR_1.Text = conn.GetFieldValue("CU_KTPADDR1");
			TXT_CU_KTPADDR_2.Text = conn.GetFieldValue("CU_KTPADDR2");
			TXT_CU_KTPADDR_3.Text = conn.GetFieldValue("CU_KTPADDR3");*/
			
			/*LabelIDCity2.Text = conn.GetFieldValue("CU_KTPCITY");
			TXT_CU_KTPCITY_1.Text = conn.GetFieldValue("CU_KTPCITY");
			TXT_CU_KTPZIPCODE_1.Text = conn.GetFieldValue("CU_KTPZIPCODE");
			TXT_CU_EMPLOYEE_1.Text = conn.GetFieldValue("CU_EMPLOYEE");*/
			TXT_CU_MOTHER_1.Text = conn.GetFieldValue("CU_MOTHER");
			TXT_CU_NAMAPELAPORAN_1.Text = conn.GetFieldValue("CU_NAMAPELAPORAN");
			DDL_CU_NEGARADOMISILI_1.SelectedValue = conn.GetFieldValue("CU_NEGARADOMISILI");
			TXT_CU_NETINCOME_1.Text = conn.GetFieldValue("CU_NETINCOMEMM");

			DDL_CU_MARITAL_1.SelectedValue = conn.GetFieldValue("CU_MARITAL");
			DDL_CU_SEX_1.SelectedValue = conn.GetFieldValue("CU_SEX");
			/*DDL_CU_EDUCATION_1.SelectedValue = conn.GetFieldValue("CU_EDUCATION");
			DDL_CU_BUSSTYPE_1.SelectedValue = conn.GetFieldValue("CU_BUSSTYPE");*/
			DDL_CU_CITIZENSHIP_1.SelectedValue = conn.GetFieldValue("CU_CITIZENSHIP");
			/*DDL_CU_HOMESTA_1.SelectedValue = conn.GetFieldValue("CU_HOMESTA");
			TXT_CU_DOB_DAY_3.Text = tool.FormatDate_Day(conn.GetFieldValue("CU_ESTABLISHYY"));
			DDL_CU_DOB_MONTH_3.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("CU_ESTABLISHYY"));
			TXT_CU_DOB_YEAR_3.Text = tool.FormatDate_Year(conn.GetFieldValue("CU_ESTABLISHYY"));*/

			conn.QueryString = "SELECT * FROM CUSTOMER WHERE CU_REF = '" + Request.QueryString["curefanak"] + "'";
			conn.ExecuteQuery();

			TXT_CU_NPWP_1.Text = conn.GetFieldValue("CU_NPWP");
			/*TXT_CU_KEYPERSON_1.Text = conn.GetFieldValue("CU_KEYPERSON");
			DDL_CU_JNSALAMAT_1.SelectedValue = conn.GetFieldValue("CU_JNSALAMAT");
			DDL_CU_LOKASIPROYEK_1.SelectedValue = conn.GetFieldValue("CU_LOKASIPROYEK");*/
			DDL_CU_LOKASIDATI_2.SelectedValue = conn.GetFieldValue("CU_LOKASIDATI2");
			DDL_CU_HUBEXECBM_1.SelectedValue = conn.GetFieldValue("CU_HUBEXECBM");

			conn.QueryString = "select cityid, cityname, description from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + TXT_CU_ZIPCODE_1.Text.ToString() + "'";
			conn.ExecuteQuery();
			TXT_CITYNAME_1.Text = conn.GetFieldValue("cityname");

			/*conn.QueryString = "select cityid, cityname, description from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + TXT_CU_KTPZIPCODE_1.Text.ToString() + "'";
			conn.ExecuteQuery();*/
			//TXT_CU_KTPCITY_1.Text = conn.GetFieldValue("cityname");
		}


		private void fillDataKetentuanKredit()
		{
			conn.QueryString = "SELECT CP_LIMIT, CP_JANGKAWKT, CP_LOANPURPOSE, PRODUCTID FROM CUSTPRODUCT WHERE AP_REGNO = '" + Request.QueryString["regnoanak"] + "'";
			conn.ExecuteQuery();

			DDL_CP_KETERANGAN_1.SelectedValue = "0";
			TXT_CP_LIMIT_1.Text = conn.GetFieldValue("CP_LIMIT");
			TXT_CP_JANGKAWKT_1.Text = conn.GetFieldValue("CP_JANGKAWKT");
			TXT_CL_EXCHANGERATE_1.Text = "1.0";
			DDL_APPTYPE_1.SelectedValue = "01";
			DDL_CP_LOANPURPOSE_1.SelectedValue = conn.GetFieldValue("CP_LOANPURPOSE");

			/*conn.QueryString = "SELECT * FROM COLLATERAL WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			TXT_CL_EXCHANGERATE_1.Text = conn.GetFieldValue("CL_EXCHANGERATE");*/

			//conn.QueryString = "SELECT BI_JENISKREDIT FROM BI_CODE WHERE AP_REGNO = '" + Request.QueryString["regnoanak"] + "'";
			//conn.ExecuteQuery();

			DDL_BI_JENISKREDIT_2.SelectedValue = conn.GetFieldValue("PRODUCTID");
		}

		private void fillDataAgunan()
		{
			/**
			 * COLLATERAL
			 * COLLATERAL_RE
			 * COLLATERAL_VEH
			 * COLLATERAL_DEP
			 * COLLATERAL_BOND
			 * COLLATERAL_PG
			 * COLLATERAL_MISC
			 * COLLATERAL_STOCK
			 * COLLATERAL_AR
			 * COLLATERAL_LC
			 * COLLATERAL_PNCHQ
			 * COLLATERAL_SPK
			 * COLLATERAL_TRCON
			 * COLLATERAL_LSAGR
			 * COLLATERAL_INV
			 * */

			//insert ke tabel : listcollateral, pledgingcollateral 

			conn.QueryString = "SELECT CL_DESC, CL_VALUE, CL_CERTTYPE1, CL_VALUE, CL_IKATID, CL_PENILAIANDATE, CL_CURRENCY, CL_PENILAIANBY, CL_TYPE FROM COLLATERAL WHERE CU_REF = '" + Request.QueryString["curefanak"] + "'";
			conn.ExecuteQuery();

			TXT_CL_DESC_1.Text = conn.GetFieldValue("CL_DESC");
			TXT_CL_VALUE_1.Text = conn.GetFieldValue("CL_VALUE");
			DDL_CL_CERTTYPE_1.SelectedValue = conn.GetFieldValue("CL_CERTTYPE1");
			TXT_CL_VALUE2_1.Text = conn.GetFieldValue("CL_VALUE");
			DDL_CL_IKATID_1.SelectedValue = conn.GetFieldValue("CL_IKATID");
			TXT_CL_PENILAIANDATE_DAY_1.Text = tool.FormatDate_Day(conn.GetFieldValue("CL_PENILAIANDATE"));
			TXT_CL_PENILAIANDATE_MONTH_1.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("CL_PENILAIANDATE"));
			TXT_CL_PENILAIANDATE_YEAR_1.Text = tool.FormatDate_Year(conn.GetFieldValue("CL_PENILAIANDATE"));
			DDL_CL_PENILAIANBY_1.SelectedValue = conn.GetFieldValue("CL_PENILAIANBY");
			DDL_JENIS_AGUNAN.SelectedValue = conn.GetFieldValue("CL_TYPE");
		}

		protected void fillSandiBI()
		{
			conn.QueryString = "SELECT PRODUCTID, BI_SIFATKREDIT, BI_JENISPENGGUNAAN, BI_ORIENTASI, " +
			"BI_JENISKREDIT, BI_SEKTOREKONOMI, BI_FASILITAS, BI_LOKASI, BM_SEKTOREKONOMI, PROD_SEQ, BM_SUBSEKTOREKON, " +
			"BM_SUBSUBSEKTOREKON FROM BI_CODE WHERE AP_REGNO = '" + Request.QueryString["regnoanak"] + "'";
			conn.ExecuteQuery();

			string b = conn.GetFieldValue("BI_JENISPENGGUNAAN");

			DDL_BI_JENISPENGGUNAAN_1.SelectedValue = conn.GetFieldValue("BI_JENISPENGGUNAAN");
			DDL_BI_JENISKREDIT_1.SelectedValue = conn.GetFieldValue("BI_JENISKREDIT");
			DDL_BI_ORIENTASI_1.SelectedValue = conn.GetFieldValue("BI_ORIENTASI");
			DDL_BI_SIFATKREDIT_1.SelectedValue = conn.GetFieldValue("BI_SIFATKREDIT");
			DDL_BI_FASILITAS_1.SelectedValue = conn.GetFieldValue("BI_FASILITAS");
			DDL_BM_SEKTOREKONOMI_1.SelectedValue = conn.GetFieldValue("BM_SEKTOREKONOMI");
			DDL_BM_SUBSEKTOREKON_1.SelectedValue = conn.GetFieldValue("BM_SUBSEKTOREKON");
			DDL_BM_SUBSUBSEKTOREKON_1.SelectedValue = conn.GetFieldValue("BM_SUBSUBSEKTOREKON");
			DDL_BI_SEKTOREKONOMI_1.SelectedValue = conn.GetFieldValue("BI_SEKTOREKONOMI");
			DDL_CU_LOKASIPROYEK_2.SelectedValue = conn.GetFieldValue("BI_LOKASI");
		}

		private void ViewData(string sta)
		{	
			DataTable dt = new DataTable();
			if (sta == "1")
				conn.QueryString = "select * from VW_CHANNELING_INITIATION_LIST where cu_name like ''";
			else
				conn.QueryString = "select * from VW_CHANNELING_INITIATION_LIST";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
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

		private void btn_cari_Click(object sender, System.EventArgs e)
		{
			ViewData("1");
		}

		protected void DDL_BM_SEKTOREKONOMI_1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*
			 *	DDL_bmsubsektor.Items.Clear();
				DDL_bmsubsektor.Items.Add(new ListItem("- PILIH -", ""));

				conn.QueryString = "select bmsub_code,bmsub_code + ' - ' + bmsub_desc as bmsubsektorDESC from RFbmsubsektorekonomi where ACTIVE='1' and BM_CODE = '"  + DDL_bmsektor.SelectedValue + "'	order by bmsub_code";
				//conn.QueryString = "select bmsub_code,bmsub_code + ' - ' + bmsub_desc as bmsubsektorDESC from RFbmsubsektorekonomi where ACTIVE='1' and bm_code='01000000' order by bmsub_code";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_bmsubsektor.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				//GlobalTools.popMessage(this, DDL_bmsektor.SelectedValue);
				conn.ClearData();

				DDL_bmsubsubsektor.Items.Clear();
				DDL_bmsubsubsektor.Items.Add(new ListItem("- PILIH -", ""));

				conn.QueryString = "select bmsubsub_code,bmsubsub_code + ' - ' + bmsubsub_desc as bmsubsektorDESC from RFbmsubsubsektorekonomi where ACTIVE='1' and bmsub_code = '"  + DDL_bmsubsektor.SelectedValue + "'	order by bmsubsub_code";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_bmsubsubsektor.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + DDL_bmsubsubsektor.SelectedValue + "'";
				conn.ExecuteQuery();
				GlobalTools.fillRefList(DDL_SEKTOREKONOMIBI, "SELECT BI_SEQ, BI_DESC FROM RFBICODE WHERE BG_GROUP = '3' AND BI_SEQ = '" + conn.GetFieldValue("BI_SEQ") + "'", true, conn);
				try{DDL_SEKTOREKONOMIBI.SelectedValue = conn.GetFieldValue("BI_SEQ");}
				catch{DDL_SEKTOREKONOMIBI.SelectedValue="";}
			 * */

			DDL_BM_SUBSEKTOREKON_1.Items.Clear();
			DDL_BM_SUBSEKTOREKON_1.Items.Add(new ListItem("- PILIH -", ""));

			conn.QueryString = "select bmsub_code,bmsub_code + ' - ' + bmsub_desc as bmsubsektorDESC from RFbmsubsektorekonomi where ACTIVE='1' and BM_CODE = '"  + DDL_BM_SEKTOREKONOMI_1.SelectedValue + "' order by bmsub_code";
			//conn.QueryString = "select bmsub_code,bmsub_code + ' - ' + bmsub_desc as bmsubsektorDESC from RFbmsubsektorekonomi where ACTIVE='1' and bm_code='01000000' order by bmsub_code";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_BM_SUBSEKTOREKON_1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			//GlobalTools.popMessage(this, DDL_bmsektor.SelectedValue);
			conn.ClearData();

			DDL_BM_SUBSUBSEKTOREKON_1.Items.Clear();
			DDL_BM_SUBSUBSEKTOREKON_1.Items.Add(new ListItem("- PILIH -", ""));

			conn.QueryString = "select bmsubsub_code,bmsubsub_code + ' - ' + bmsubsub_desc as bmsubsektorDESC from RFbmsubsubsektorekonomi where ACTIVE='1' and bmsub_code = '"  + DDL_BM_SUBSEKTOREKON_1.SelectedValue + "' order by bmsubsub_code";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_BM_SUBSUBSEKTOREKON_1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + DDL_BM_SUBSUBSEKTOREKON_1.SelectedValue + "'";
			conn.ExecuteQuery();
			GlobalTools.fillRefList(DDL_BI_SEKTOREKONOMI_1, "SELECT BI_SEQ, BI_DESC FROM RFBICODE WHERE BG_GROUP = '3' AND BI_SEQ = '" + conn.GetFieldValue("BI_SEQ") + "'", true, conn);
			try{DDL_BI_SEKTOREKONOMI_1.SelectedValue = conn.GetFieldValue("BI_SEQ");}
			catch{DDL_BI_SEKTOREKONOMI_1.SelectedValue="";}
		}

		protected void DDL_BM_SUBSEKTOREKON_1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*
			 *	DDL_bmsubsubsektor.Items.Clear();

				conn.QueryString = "select bmsubsub_code,bmsubsub_code + ' - ' + bmsubsub_desc as bmsubsektorDESC from RFbmsubsubsektorekonomi where ACTIVE='1' and bmsub_code = '"  + DDL_bmsubsektor.SelectedValue + "'	order by bmsubsub_code";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_bmsubsubsektor.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + DDL_bmsubsubsektor.SelectedValue + "'";
				conn.ExecuteQuery();
				GlobalTools.fillRefList(DDL_SEKTOREKONOMIBI, "SELECT BI_SEQ, BI_DESC FROM RFBICODE WHERE BG_GROUP = '3' AND BI_SEQ = '" + conn.GetFieldValue("BI_SEQ") + "'", true, conn);
				try{DDL_SEKTOREKONOMIBI.SelectedValue = conn.GetFieldValue("BI_SEQ");}
				catch{DDL_SEKTOREKONOMIBI.SelectedValue="";}	
			 * */

			DDL_BM_SUBSUBSEKTOREKON_1.Items.Clear();

			conn.QueryString = "select bmsubsub_code,bmsubsub_code + ' - ' + bmsubsub_desc as bmsubsektorDESC from RFbmsubsubsektorekonomi where ACTIVE='1' and bmsub_code = '"  + DDL_BM_SUBSEKTOREKON_1.SelectedValue + "' order by bmsubsub_code";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_BM_SUBSUBSEKTOREKON_1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + DDL_BM_SUBSUBSEKTOREKON_1.SelectedValue + "'";
			conn.ExecuteQuery();
			GlobalTools.fillRefList(DDL_BI_SEKTOREKONOMI_1, "SELECT BI_SEQ, BI_DESC FROM RFBICODE WHERE BG_GROUP = '3' AND BI_SEQ = '" + conn.GetFieldValue("BI_SEQ") + "'", true, conn);
			try{DDL_BI_SEKTOREKONOMI_1.SelectedValue = conn.GetFieldValue("BI_SEQ");}
			catch{DDL_BI_SEKTOREKONOMI_1.SelectedValue="";}	

			
		}

		protected void DDL_BM_SUBSUBSEKTOREKON_1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + DDL_BM_SUBSUBSEKTOREKON_1.SelectedValue + "'";
			conn.ExecuteQuery();
			GlobalTools.fillRefList(DDL_BI_SEKTOREKONOMI_1, "SELECT BI_SEQ, BI_DESC FROM RFBICODE WHERE BG_GROUP = '3' AND BI_SEQ = '" + conn.GetFieldValue("BI_SEQ") + "'", true, conn);
			try{DDL_BI_SEKTOREKONOMI_1.SelectedValue = conn.GetFieldValue("BI_SEQ");}
			catch{DDL_BI_SEKTOREKONOMI_1.SelectedValue="";}
		}

		protected void btn_Save_CIF_Data_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC CHANNELING_UPDATE_DATA_CIF " +
					"'" + Request.QueryString["curefanak"] + "'," +

					"'" + TXT_CU_FIRSTNAME_1.Text + "'," +
					"'" + TXT_CU_ADDR_1.Text + "'," +
					"'" + LabelIDCity1.Text + "'," +
					"'" + TXT_CU_ZIPCODE_1.Text + "'," +
				
					"'" + TXT_CU_PHNAREA_1.Text + "'," +
					"'" + TXT_CU_PHNNUM_1.Text  + "'," +
					"'" + TXT_CU_POB_1.Text + "'," +
					"'" + TXT_CU_DOB_DAY_1.Text + "'," +
					"'" + DDL_CU_DOB_MONTH_1.SelectedValue + "'," +
					"'" + TXT_CU_DOB_YEAR_1.Text + "'," +
				
					"'" + TXT_CU_IDCARDNUM_1.Text + "'," +
					"'" + TXT_CU_IDCARDEXP_DAY_1.Text + "'," +
					"'" + TXT_CU_IDCARDEXP_MONTH_1.SelectedValue + "'," +
					"'" + TXT_CU_IDCARDEXP_YEAR_1.Text + "'," +

					"'" + TXT_CU_MOTHER_1.Text + "'," +
					"'" + TXT_CU_NAMAPELAPORAN_1.Text + "'," +
					"'" + DDL_CU_NEGARADOMISILI_1.SelectedValue + "'," +
					"'" + TXT_CU_NETINCOME_1.Text + "'," +
					"'" + DDL_CU_MARITAL_1.SelectedValue + "'," +
					"'" + DDL_CU_SEX_1.SelectedValue + "'," +

					"'" + DDL_CU_CITIZENSHIP_1.SelectedValue + "'," +

					"'" + TXT_CU_NPWP_1.Text + "'," +
					"'" + DDL_CU_LOKASIDATI_2.SelectedValue + "'," +
					"'" + TXT_KECAMATAN.Text + "'";

				/*
				 *	@CU_REF varchar(200),
					@CU_FIRSTNAME varchar(200),
					@CU_ADDR1 varchar(200),
					@CU_CITY varchar(200),
					@CU_ZIPCODE varchar(200),

					@CU_PHNAREA varchar(200),
					@CU_PHNNUM varchar(200),
					@CU_POB varchar(200),
					@CU_DOB_DAY varchar(200),
					@CU_DOB_MONTH varchar(200),
					@CU_DOB_YEAR varchar(200),

					@CU_IDCARDNUM varchar(200),
					@CU_IDCARDEXP_DAY varchar(200),
					@CU_IDCARDEXP_MONTH varchar(200),
					@CU_IDCARDEXP_YEAR varchar(200),

					@CU_MOTHER varchar(200),
					@CU_NAMAPELAPORAN varchar(200),
					@CU_NEGARADOMISILI varchar(200),
					@CU_NETINCOMEMM varchar(200),
					@CU_MARITAL varchar(200),
					@CU_SEX varchar(200),

					@CU_CITIZENSHIP varchar(200),
					@NPWP varchar(100),
					@CU_LOKASIDATI2 varchar(200),
					@KECAMATAN varchar(200)
				 * */

				conn.ExecuteNonQuery();
				fillDataCIF();
			}
			catch
			{
				Tools.popMessage(this, "Pengisian data pada field kurang lengkap !");
			}
		}

		protected void btn_Save_Ketentuan_Kredit_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC CHANNELING_UPDATE_STRUKTUR_KREDIT " +
					"'" + Request.QueryString["regnoanak"] + "'," +	
			
					"'" + DDL_CP_KETERANGAN_1.SelectedItem.Text.ToString()  + "'," +
					"'" + TXT_CP_LIMIT_1.Text.ToString()  + "'," +
					"'" + DDL_APPTYPE_1.SelectedValue  + "'," +
					"'" + TXT_CL_EXCHANGERATE_1.Text.ToString()  + "'," +
					"'" + DDL_BI_JENISKREDIT_2.SelectedValue  + "'," +
					"'" + TXT_CP_JANGKAWKT_1.Text.ToString()  + "'," +
					"'" + DDL_CP_LOANPURPOSE_1.SelectedValue + "'";

				conn.ExecuteNonQuery();
				fillDataKetentuanKredit();
			}
			catch
			{
				Tools.popMessage(this, "Pengisian data pada field kurang lengkap !");
			}
		}

		protected void btn_Save_Data_Agunan_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC CHANNELING_UPDATE_DATA_AGUNAN "+
					"'" + Request.QueryString["curefanak"] + "'," +	

				"'" + TXT_CL_DESC_1.Text + "'," +
				"" + TXT_CL_VALUE_1.Text.ToString() + "," +
				"'" + DDL_CL_CERTTYPE_1.SelectedValue + "'," +
				"'" + TXT_CL_VALUE2_1.Text.ToString() + "'," +
				"" + DDL_CL_IKATID_1.SelectedValue + "," +
				"'" + TXT_CL_PENILAIANDATE_DAY_1.Text.ToString() + "'," +
				"'" + TXT_CL_PENILAIANDATE_MONTH_1.SelectedValue + "'," +
				"'" + TXT_CL_PENILAIANDATE_YEAR_1.Text.ToString() + "'," +
				"'" + DDL_CL_PENILAIANBY_1.SelectedValue + "'," +
				"'" + DDL_JENIS_AGUNAN.SelectedValue + "'";

				conn.ExecuteNonQuery();
				fillDataAgunan();
			}
			catch
			{
				Tools.popMessage(this, "Pengisian data pada field kurang lengkap !");
			}
		}

		protected void btn_Save_Sandi_BI_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC CHANNELING_UPDATE_BI_CODE "+
					"'" + Request.QueryString["regnoanak"] + "'," +	
				"'" + DDL_BI_JENISPENGGUNAAN_1.SelectedValue  + "'," +
				"'" + DDL_BI_JENISKREDIT_1.SelectedValue  + "'," +
				"'" + DDL_BI_ORIENTASI_1.SelectedValue  + "'," +
				"'" + DDL_BI_SIFATKREDIT_1.SelectedValue  + "'," +
				"'" + DDL_BI_FASILITAS_1.SelectedValue  + "'," +
				"'" + DDL_BM_SEKTOREKONOMI_1.SelectedValue  + "'," +
				"'" + DDL_BM_SUBSEKTOREKON_1.SelectedValue  + "'," +
				"'" + DDL_BM_SUBSUBSEKTOREKON_1.SelectedValue  + "'," +
				"'" + DDL_BI_SEKTOREKONOMI_1.SelectedValue  + "'," +
				"'" + DDL_CU_LOKASIPROYEK_2.SelectedValue  + "'";

				conn.ExecuteNonQuery();
				fillSandiBI();
			}
			catch
			{
				Tools.popMessage(this, "Pengisian data pada field kurang lengkap !");
			}
		}

		protected void btn_Clear_CIF_Data_Click(object sender, System.EventArgs e)
		{
			/*TXT_CU_FIRSTNAME_1.Text = "";
			TXT_CU_MIDDLENAME_1.Text = "";
			TXT_CU_LASTENAME_1.Text = "";

			TXT_CU_ADDR_1.Text = "";
			TXT_CU_ADDR_2.Text = "";
			TXT_CU_ADDR_3.Text = "";

			TXT_CITYNAME_1.Text = "";
			TXT_CU_ZIPCODE_1.Text = "";
			
			TXT_CU_PHNAREA_1.Text = "";
			TXT_CU_PHNNUM_1.Text = "";
			TXT_CU_POB_1.Text = "";
			TXT_CU_DOB_DAY_1.Text = "";
			DDL_CU_DOB_MONTH_1.SelectedIndex = 0;
			TXT_CU_DOB_YEAR_1.Text = "";
			
			TXT_CU_IDCARDNUM_1.Text = "";
			TXT_CU_IDCARDEXP_DAY_1.Text = "";
			TXT_CU_IDCARDEXP_MONTH_1.SelectedIndex = 0;
			TXT_CU_IDCARDEXP_YEAR_1.Text = "";
			TXT_CU_KTPADDR_1.Text = "";
			TXT_CU_KTPADDR_2.Text = "";
			TXT_CU_KTPADDR_3.Text = "";
			TXT_CU_KTPCITY_1.Text = "";
			TXT_CU_KTPZIPCODE_1.Text = "";
			TXT_CU_EMPLOYEE_1.Text = "";
			TXT_CU_MOTHER_1.Text = "";
			TXT_CU_NAMAPELAPORAN_1.Text = "";
			TXT_CU_NETINCOME_1.Text = "";
			DDL_CU_MARITAL_1.SelectedIndex = 0;
			DDL_CU_SEX_1.SelectedIndex = 0;
			DDL_CU_EDUCATION_1.SelectedIndex = 0;
			DDL_CU_BUSSTYPE_1.SelectedIndex = 0;
			DDL_CU_HOMESTA_1.SelectedIndex = 0;
			TXT_CU_DOB_DAY_3.Text = "";
			DDL_CU_DOB_MONTH_3.SelectedIndex = 0;
			TXT_CU_DOB_YEAR_3.Text  = "";

			TXT_CU_NPWP_1.Text = "";
			TXT_CU_KEYPERSON_1.Text = "";
			DDL_CU_JNSALAMAT_1.SelectedIndex = 0;
			DDL_CU_LOKASIPROYEK_1.SelectedIndex = 0;
			DDL_CU_LOKASIDATI_2.SelectedIndex = 0;*/

			TXT_CU_FIRSTNAME_1.Text = "";
			TXT_CU_ADDR_1.Text = "";
			TXT_KECAMATAN.Text = "";

			TXT_CITYNAME_1.Text = "";
			TXT_CU_ZIPCODE_1.Text = "";
			
			TXT_CU_PHNAREA_1.Text = "";
			TXT_CU_PHNNUM_1.Text = "";
			TXT_CU_POB_1.Text = "";
			TXT_CU_DOB_DAY_1.Text = "";
			DDL_CU_DOB_MONTH_1.SelectedIndex = 0;
			TXT_CU_DOB_YEAR_1.Text = "";
			
			TXT_CU_IDCARDNUM_1.Text = "";
			TXT_CU_IDCARDEXP_DAY_1.Text = "";
			TXT_CU_IDCARDEXP_MONTH_1.SelectedIndex = 0;
			TXT_CU_IDCARDEXP_YEAR_1.Text = "";
			TXT_CU_MOTHER_1.Text = "";
			TXT_CU_NAMAPELAPORAN_1.Text = "";
			TXT_CU_NETINCOME_1.Text = "";
			DDL_CU_MARITAL_1.SelectedIndex = 0;
			DDL_CU_SEX_1.SelectedIndex = 0;

			TXT_CU_NPWP_1.Text = "";
			DDL_CU_LOKASIDATI_2.SelectedIndex = 0;
		}

		protected void btn_Clear_Ketentuan_Kredit_Click(object sender, System.EventArgs e)
		{
			TXT_CP_LIMIT_1.Text = "";
			DDL_BI_JENISKREDIT_2.SelectedIndex = 0;
			TXT_CP_JANGKAWKT_1.Text = "";
			DDL_CP_LOANPURPOSE_1.SelectedIndex = 0;
		}

		protected void btn_Clear_data_agunan_Click(object sender, System.EventArgs e)
		{
			TXT_CL_VALUE_1.Text = "";
			DDL_CL_CERTTYPE_1.SelectedIndex = 0;
			TXT_CL_VALUE2_1.Text = "";
			DDL_CL_IKATID_1.SelectedIndex = 0;
			TXT_CL_PENILAIANDATE_DAY_1.Text = "";
			TXT_CL_PENILAIANDATE_MONTH_1.SelectedIndex = 0;
			TXT_CL_PENILAIANDATE_YEAR_1.Text = "";
			DDL_JENIS_AGUNAN.SelectedIndex = 0;
		}

		protected void btn_Clear_Sandi_BI_Click(object sender, System.EventArgs e)
		{
			DDL_BI_JENISPENGGUNAAN_1.SelectedIndex = 0;
			DDL_BI_JENISKREDIT_1.SelectedIndex = 0;
			DDL_BM_SEKTOREKONOMI_1.SelectedIndex = 0; 
			DDL_BM_SUBSEKTOREKON_1.SelectedIndex = 0;
			DDL_BM_SUBSUBSEKTOREKON_1.SelectedIndex = 0;
			DDL_CU_LOKASIPROYEK_2.SelectedIndex = 0;
		}

		private void BTN_SEARCH_ZIPCODE_1_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_ZIPCODE_1','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
		}

		private void BTN_SEARCH_ZIPCODE_2_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_KTPZIPCODE_1','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
		}

		private void TXT_CU_ZIPCODE_1_TextChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select cityid, cityname, description from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + 
				TXT_CU_ZIPCODE_1.Text.Trim() + "' ";
			conn.ExecuteQuery();
			try
			{
				LabelIDCity1.Text = conn.GetFieldValue(0,0);
				TXT_CITYNAME_1.Text = conn.GetFieldValue(0,2);
			}
			catch
			{
				TXT_CU_ZIPCODE_1.Text = "";
				TXT_CITYNAME_1.Text = "";
				GlobalTools.popMessage(this, "Invalid Zipcode!");
			}
		}

		private void TXT_CU_KTPZIPCODE_1_TextChanged(object sender, System.EventArgs e)
		{
			/*conn.QueryString = "select cityid, cityname, description from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + 
				TXT_CU_KTPZIPCODE_1.Text.Trim() + "' ";
			conn.ExecuteQuery();
			try
			{
				LabelIDCity2.Text = conn.GetFieldValue(0,0);
				TXT_CU_IDCARDNUM_1.Text = conn.GetFieldValue(0,2);
			}
			catch
			{
				TXT_CU_KTPZIPCODE_1.Text = "";
				TXT_CU_IDCARDNUM_1.Text = "";
				GlobalTools.popMessage(this, "Invalid Zipcode!");
			}*/
		}

		protected void DDL_BI_SEKTOREKONOMI_1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}
