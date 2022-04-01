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

namespace SME.DCM.DataCompleteness
{
	/// <summary>
	/// Summary description for CIFDataComplet.
	/// </summary>
	public class CIFDataComplet : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_CUST_NAME;
		protected System.Web.UI.WebControls.RadioButtonList RDO_CIF_DEBITUR_TYPE;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_BUC;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_OWNER_UNIT;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_REPORT_NAME;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_BOD_ESTABLISH_DATE_DD;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_BOD_ESTABLISH_DATE_MM;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_BOD_ESTABLISH_DATE_YY;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_PLACE_BOD_STABLISH;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_MAIN_ID_TYPE;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_MAIN_ID;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_GOL_CUSTOMER;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_DEBITUR_TYPE;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_HUBUNGAN;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_ADDRESS_LINE1;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_KECAMATAN;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_ZIP;
		protected System.Web.UI.WebControls.Button BTN_CIF_ZIP;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_DATI2;
		protected System.Web.UI.WebControls.RadioButtonList RDO_PH;
		protected System.Web.UI.WebControls.TextBox TXT_PH;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_APP;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_APP_DATE_DD;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_APP_DATE_MM;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_APP_YY;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_APT;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_APT_DATE_DD;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_APT_DATE_MM;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_APT_DATE_YY;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_PENDAPATAN_OPR;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_PEDAPATAN_NOPR;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_RATING_COMP;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_RATING_RESULT;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_RATING_DATE_DD;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_RATING_DATE_MM;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_RATING_DATE_YY;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_BUSINESS_TYPE;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_SEX_TYPE;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_MOTHER_NM;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_PREFIK_NAME;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_CUST_COMP_NAME;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_BIDANG_USAHA;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_JOB_TITLE;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_CUST_OCCUPATION;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_SALARY;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_MAIN_INCOME;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_OTHER_INCOME;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_CITIZEN;
		protected System.Web.UI.WebControls.DropDownList DDL_CIF_MARITAL;
		protected System.Web.UI.WebControls.TextBox TXT_CIF_CIF;
		protected System.Web.UI.WebControls.TextBox TXT_TGL_KADALUARSA_ID;
		protected System.Web.UI.WebControls.DropDownList DDL_VALUTA;
		protected System.Web.UI.WebControls.Label LBL_TXT_CIF_CIF;
		protected System.Web.UI.WebControls.Label LBL_TXT_CIF_CUST_NAME;
		protected System.Web.UI.WebControls.Label LBL_RDO_CIF_DEBITUR_TYPE;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_BUC;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_OWNER_UNIT;
		protected System.Web.UI.WebControls.Label LBL_TXT_CIF_REPORT_NAME;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_BOD_ESTABLISH_DATE_MM;
		protected System.Web.UI.WebControls.Label LBL_TXT_CIF_PLACE_BOD_STABLISH;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_MAIN_ID_TYPE;
		protected System.Web.UI.WebControls.Label LBL_TXT_CIF_MAIN_ID;
		protected System.Web.UI.WebControls.Label LBL_TXT_TGL_KADALUARSA_ID;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_GOL_CUSTOMER;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_DEBITUR_TYPE;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_HUBUNGAN;
		protected System.Web.UI.WebControls.Label LBL_TXT_CIF_ADDRESS_LINE1;
		protected System.Web.UI.WebControls.Label LBL_TXT_CIF_KECAMATAN;
		protected System.Web.UI.WebControls.Label LBL_TXT_CIF_ZIP;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_DATI2;
		protected System.Web.UI.WebControls.Label LBL_TXT_PH;
		protected System.Web.UI.WebControls.Label LBL_DDL_VALUTA;
		protected System.Web.UI.WebControls.Label LBL_TXT_CIF_APP;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_APP_DATE_MM;
		protected System.Web.UI.WebControls.Label LBL_TXT_CIF_APT;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_APT_DATE_MM;
		protected System.Web.UI.WebControls.Label LBL_TXT_CIF_PENDAPATAN_OPR;
		protected System.Web.UI.WebControls.Label LBL_TXT_CIF_PEDAPATAN_NOPR;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_RATING_COMP;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_RATING_RESULT;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_RATING_DATE_MM;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_BUSINESS_TYPE;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_SEX_TYPE;
		protected System.Web.UI.WebControls.Label LBL_TXT_CIF_MOTHER_NM;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_PREFIK_NAME;
		protected System.Web.UI.WebControls.Label LBL_TXT_CIF_CUST_COMP_NAME;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_BIDANG_USAHA;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_JOB_TITLE;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_CUST_OCCUPATION;
		protected System.Web.UI.WebControls.Label LBL_TXT_CIF_SALARY;
		protected System.Web.UI.WebControls.Label LBL_TXT_CIF_MAIN_INCOME;
		protected System.Web.UI.WebControls.Label LBL_TXT_CIF_OTHER_INCOME;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_CITIZEN;
		protected System.Web.UI.WebControls.Label LBL_DDL_CIF_MARITAL;
		protected System.Web.UI.WebControls.DataGrid DatGridDataPerusahaan;
		protected System.Web.UI.WebControls.TextBox TXT_TOT_SAHAM;
		protected System.Web.UI.WebControls.TextBox TXT_CIF;
		protected System.Web.UI.WebControls.TextBox TXT_NAMA;
		protected System.Web.UI.WebControls.DropDownList DDL_JNS_NASABAH;
		protected System.Web.UI.WebControls.TextBox TXT_TGL_COMP;
		protected System.Web.UI.WebControls.DropDownList DDL_BLN_COMP;
		protected System.Web.UI.WebControls.TextBox TXT_THN_COMP;
		protected System.Web.UI.WebControls.DropDownList DDL_JNS_KELAMIN;
		protected System.Web.UI.WebControls.TextBox TXT_SAHAM;
		protected System.Web.UI.WebControls.DropDownList DDL_JNS_ID;
		protected System.Web.UI.WebControls.TextBox TXT_ID_UTAMA;
		protected System.Web.UI.WebControls.TextBox TXT_EXP_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_BLN_EXP;
		protected System.Web.UI.WebControls.TextBox TXT_EXP_YEAR;
		protected System.Web.UI.WebControls.TextBox TXT_ALAMAT;
		protected System.Web.UI.WebControls.TextBox TXT_CU_ZIPCODE;
		protected System.Web.UI.WebControls.Button BTN_SEARCHCOMP;
		protected System.Web.UI.WebControls.DropDownList DDL_BUC;
		protected System.Web.UI.WebControls.DropDownList DDL_KODE_HUB;
		protected System.Web.UI.WebControls.CheckBox CHK_REMOVED;
		protected System.Web.UI.WebControls.TextBox TXT_TGL_LAP;
		protected System.Web.UI.WebControls.DropDownList DDL_BLN_LAP;
		protected System.Web.UI.WebControls.TextBox TXT_THN_LAP;
		protected System.Web.UI.WebControls.RadioButtonList RDO_PINJAMAN_LN;
		protected System.Web.UI.WebControls.DropDownList DDL_DENO;
		protected System.Web.UI.WebControls.DropDownList DDL_AUDITED;
		protected System.Web.UI.WebControls.DropDownList DDL_CURR;
		protected System.Web.UI.WebControls.Label LBL_TXT_CIF;
		protected System.Web.UI.WebControls.Label LBL_TXT_NAMA;
		protected System.Web.UI.WebControls.Label LBL_DDL_JNS_NASABAH;
		protected System.Web.UI.WebControls.Label LBL_DDL_BLN_COMP;
		protected System.Web.UI.WebControls.Label LBL_DDL_JNS_KELAMIN;
		protected System.Web.UI.WebControls.Label LBL_TXT_SAHAM;
		protected System.Web.UI.WebControls.Label LBL_DDL_JNS_ID;
		protected System.Web.UI.WebControls.Label LBL_TXT_ID_UTAMA;
		protected System.Web.UI.WebControls.Label LBL_DDL_BLN_EXP;
		protected System.Web.UI.WebControls.Label LBL_TXT_ALAMAT;
		protected System.Web.UI.WebControls.Label LBL_TXT_CU_ZIPCODE;
		protected System.Web.UI.WebControls.Label LBL_DDL_BUC;
		protected System.Web.UI.WebControls.Label LBL_DDL_KODE_HUB;
		protected System.Web.UI.WebControls.Label LBL_CHK_REMOVED;
		protected System.Web.UI.WebControls.Label LBL_DDL_BLN_LAP;
		protected System.Web.UI.WebControls.Label LBL_RDO_PINJAMAN_LN;
		protected System.Web.UI.WebControls.Label LBL_DDL_DENO;
		protected System.Web.UI.WebControls.Label LBL_DDL_AUDITED;
		protected System.Web.UI.WebControls.Label LBL_DDL_CURR;
		protected System.Web.UI.WebControls.Label LBL_TXT_JML_BLN;
		protected System.Web.UI.WebControls.TextBox TXT_JML_BLN;
		protected System.Web.UI.WebControls.TextBox TXT_ACTIVA;
		protected System.Web.UI.WebControls.TextBox TXT_TOT_ACTIVA;
		protected System.Web.UI.WebControls.TextBox TXT_WJB_BANK;
		protected System.Web.UI.WebControls.TextBox TXT_WJB_LANCAR;
		protected System.Web.UI.WebControls.TextBox TXT_TOT_WJB;
		protected System.Web.UI.WebControls.TextBox TXT_MODAL;
		protected System.Web.UI.WebControls.TextBox TXT_PENJUALAN;
		protected System.Web.UI.WebControls.TextBox TXT_POP;
		protected System.Web.UI.WebControls.TextBox TXT_BOP;
		protected System.Web.UI.WebControls.TextBox TXT_NON_POP;
		protected System.Web.UI.WebControls.TextBox TXT_NON_BOP;
		protected System.Web.UI.WebControls.TextBox LR_AFTER;
		protected System.Web.UI.WebControls.TextBox LR_BEFORE;
		protected System.Web.UI.WebControls.Label LBL_TXT_ACTIVA;
		protected System.Web.UI.WebControls.Label LBL_TXT_TOT_ACTIVA;
		protected System.Web.UI.WebControls.Label LBL_TXT_WJB_BANK;
		protected System.Web.UI.WebControls.Label LBL_TXT_WJB_LANCAR;
		protected System.Web.UI.WebControls.Label LBL_TXT_TOT_WJB;
		protected System.Web.UI.WebControls.Label LBL_TXT_MODAL;
		protected System.Web.UI.WebControls.Label LBL_TXT_PENJUALAN;
		protected System.Web.UI.WebControls.Label LBL_TXT_POP;
		protected System.Web.UI.WebControls.Label LBL_TXT_BOP;
		protected System.Web.UI.WebControls.Label LBL_TXT_NON_POP;
		protected System.Web.UI.WebControls.Label LBL_TXT_NON_BOP;
		protected System.Web.UI.WebControls.Label LBL_LR_AFTER;
		protected System.Web.UI.WebControls.Button BTN_SAVE_GENERALDATA;
		protected System.Web.UI.WebControls.Button BTN_CLEAR_GENERALDATA;
		protected System.Web.UI.WebControls.Button BTN_UPDATE_STATUS_GENERALDATA;
		protected System.Web.UI.WebControls.Button BTN_ADD_DATAPENGURUS;
		protected System.Web.UI.WebControls.Button BTN_UPDATE_DATAPENGURUS;
		protected System.Web.UI.WebControls.Button BTN_CLEAR_DATAPENGURUS;
		protected System.Web.UI.WebControls.Button BTN_SAVE_DATAKEUANGAN;
		protected System.Web.UI.WebControls.Button BTN_CLEAR__DATAKEUANGAN;
		protected System.Web.UI.WebControls.Label LBL_LR_BEFORE;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.DDL_CIF_DEBITUR_TYPE.SelectedIndexChanged += new System.EventHandler(this.Dropdownlist26_SelectedIndexChanged);
			this.BTN_SAVE_GENERALDATA.Click += new System.EventHandler(this.BTN_SAVE_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Dropdownlist26_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
