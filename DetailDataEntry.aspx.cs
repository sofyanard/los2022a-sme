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

namespace SME.BGSpan
{
	/// <summary>
	/// Summary description for DetailDataEntry.
	/// </summary>
	public class DetailDataEntry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.TextBox TXT_BRANCH_CODE;
		protected System.Web.UI.WebControls.DropDownList DDL_PROG_CODE;
		protected System.Web.UI.WebControls.TextBox TXT_AP_RELMNGR;
		protected System.Web.UI.WebControls.Label LBL_AP_RELMNGR;
		protected System.Web.UI.WebControls.DropDownList DDL_CHANNEL_CODE;
		protected System.Web.UI.WebControls.TextBox TXT_CON;
		protected System.Web.UI.WebControls.DropDownList DDL_AP_SRCCODE;
		protected System.Web.UI.WebControls.TextBox TXT_AP_SRCNAME;
		protected System.Web.UI.WebControls.DropDownList DDL_AP_GRSALESCURR;
		protected System.Web.UI.WebControls.TextBox TXT_AP_GROSSSALES;
		protected System.Web.UI.WebControls.DropDownList DDL_AP_BOOKINGBRANCH;
		protected System.Web.UI.WebControls.DropDownList DDL_AP_CCOBRANCH;
		protected System.Web.UI.WebControls.TextBox TXT_AP_SIGNDATE_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_AP_SIGNDATE_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_AP_SIGNDATE_YEAR;
		protected System.Web.UI.WebControls.TextBox TXT_AP_RECVDATE;
		protected System.Web.UI.WebControls.DropDownList DDL_AP_BUSINESSUNIT;
		protected System.Web.UI.WebControls.TextBox TXT_AP_REGNO;
		protected System.Web.UI.WebControls.TextBox TXT_CU_REF;
		protected System.Web.UI.WebControls.Label Label_generalinfo1;
		protected System.Web.UI.WebControls.DropDownList DDL_AP_SALESAGENCY;
		protected System.Web.UI.WebControls.TextBox Textbox_skbngpasar;
		protected System.Web.UI.WebControls.Label Label_generalinfo2;
		protected System.Web.UI.WebControls.DropDownList DDL_AP_SALESSUPERV;
		protected System.Web.UI.WebControls.TextBox Textbox_skbngminta;
		protected System.Web.UI.WebControls.Label Label_generalinfo3;
		protected System.Web.UI.WebControls.DropDownList DDL_AP_SALESEXEC;
		protected System.Web.UI.WebControls.TextBox TXT_SURATNSBNO;
		protected System.Web.UI.WebControls.TextBox TXT_SURATNSBTGL_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_SURATNSBTGL_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_SURATNSBTGL_YEAR;
		protected System.Web.UI.WebControls.TextBox TXT_SURATNSBTGLTRM_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_SURATNSBTGLTRM_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_SURATNSBTGLTRM_YEAR;
		protected System.Web.UI.WebControls.TextBox TXT_AUDITDESC_PROG;
		protected System.Web.UI.WebControls.TextBox TXT_AUDITDESC_BICHECK;
		protected System.Web.UI.WebControls.RadioButtonList RDO_CU_PERNAHJDNASABAHBM;
		protected System.Web.UI.WebControls.RadioButtonList RDO_RFCUSTOMERTYPE;
		protected System.Web.UI.WebControls.TextBox TXT_CU_CIF_P;
		protected System.Web.UI.WebControls.TextBox TXT_CU_TITLEBEFORENAME;
		protected System.Web.UI.WebControls.TextBox TXT_CU_FIRSTNAME;
		protected System.Web.UI.WebControls.TextBox TXT_CU_MIDDLENAME;
		protected System.Web.UI.WebControls.TextBox TXT_CU_LASTNAME;
		protected System.Web.UI.WebControls.TextBox TXT_CU_ADDR1;
		protected System.Web.UI.WebControls.TextBox TXT_CU_ADDR2;
		protected System.Web.UI.WebControls.TextBox TXT_CU_ADDR3;
		protected System.Web.UI.WebControls.TextBox TXT_CU_CITY;
		protected System.Web.UI.WebControls.Label LBL_CU_CITY;
		protected System.Web.UI.WebControls.TextBox TXT_CU_ZIPCODE;
		protected System.Web.UI.WebControls.Button BTN_SEARCHPERSONAL;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_HOMESTA;
		protected System.Web.UI.WebControls.TextBox TXT_CU_MULAIMENETAPMM;
		protected System.Web.UI.WebControls.TextBox TXT_CU_MULAIMENETAPYY;
		protected System.Web.UI.WebControls.TextBox TXT_CU_PHNAREA;
		protected System.Web.UI.WebControls.TextBox TXT_CU_PHNNUM;
		protected System.Web.UI.WebControls.TextBox TXT_CU_PHNEXT;
		protected System.Web.UI.WebControls.TextBox TXT_CU_FAXAREA;
		protected System.Web.UI.WebControls.TextBox TXT_CU_FAXNUM;
		protected System.Web.UI.WebControls.TextBox TXT_CU_FAXEXT;
		protected System.Web.UI.WebControls.TextBox TXT_CU_POB;
		protected System.Web.UI.WebControls.TextBox TXT_CU_DOB_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_DOB_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_CU_DOB_YEAR;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_MARITAL;
		protected System.Web.UI.WebControls.TextBox TXT_CU_SPOUSE_FNAME;
		protected System.Web.UI.WebControls.TextBox TXT_CU_SPOUSE_MNAME;
		protected System.Web.UI.WebControls.TextBox TXT_CU_SPOUSE_LNAME;
		protected System.Web.UI.WebControls.TextBox TXT_CU_SPOUSE_IDCARDNUM;
		protected System.Web.UI.WebControls.TextBox TXT_CU_SPOUSE_KTPADDR1;
		protected System.Web.UI.WebControls.TextBox TXT_CU_SPOUSE_KTPADDR2;
		protected System.Web.UI.WebControls.TextBox TXT_CU_SPOUSE_KTPADDR3;
		protected System.Web.UI.WebControls.TextBox TXT_CU_SPOUSE_KTPISSUEDATE_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_SPOUSE_KTPISSUEDATE_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_CU_SPOUSE_KTPISSUEDATE_YEAR;
		protected System.Web.UI.WebControls.TextBox TXT_CU_SPOUSE_KTPEXPDATE_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_SPOUSE_KTPEXPDATE_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_CU_SPOUSE_KTPEXPDATE_YEAR;
		protected System.Web.UI.WebControls.TextBox TXT_CU_NOKARTUKELUARGA;
		protected System.Web.UI.WebControls.TextBox TXT_CU_CHILDREN;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_SEX;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_CITIZENSHIP;
		protected System.Web.UI.WebControls.TextBox TXT_CU_IDCARDNUM;
		protected System.Web.UI.WebControls.TextBox TXT_CU_IDCARDEXP_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_IDCARDEXP_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_CU_IDCARDEXP_YEAR;
		protected System.Web.UI.WebControls.TextBox TXT_CU_KTPADDR1;
		protected System.Web.UI.WebControls.TextBox TXT_CU_KTPADDR2;
		protected System.Web.UI.WebControls.TextBox TXT_CU_KTPADDR3;
		protected System.Web.UI.WebControls.TextBox TXT_CU_KTPCITY;
		protected System.Web.UI.WebControls.Label LBL_CU_KTPCITY;
		protected System.Web.UI.WebControls.TextBox TXT_CU_KTPZIPCODE;
		protected System.Web.UI.WebControls.Button BTN_SEARCHKTPZIP;
		protected System.Web.UI.WebControls.DropDownList DDL_JNSALAMAT_P;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_JNSNASABAH_P;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_EDUCATION;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_JOBTITLE;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_BUSSTYPE;
		protected System.Web.UI.WebControls.TextBox TXT_CU_ESTABLISHDD;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_ESTABLISHMM;
		protected System.Web.UI.WebControls.TextBox TXT_CU_ESTABLISHYY;
		protected System.Web.UI.WebControls.TextBox TXT_CU_NPWP;
		protected System.Web.UI.WebControls.TextBox TXT_CU_NETINCOMEMM;
		protected System.Web.UI.WebControls.TextBox TXT_CU_EMPLOYEE;
		protected System.Web.UI.WebControls.TextBox TXT_CU_MOTHER;
		protected System.Web.UI.WebControls.TextBox TXT_CU_NAMAPELAPORAN;
		protected System.Web.UI.WebControls.CheckBox CHB_CU_NAMAPELAPORAN;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_NEGARADOMISILI;
		protected System.Web.UI.WebControls.TextBox TXT_CU_CIF_C;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_COMPTYPE;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPNAME;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_JNSNASABAH;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPESTABLISHDD;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_COMPESTABLISHMM;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPESTABLISHYY;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPPOB;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPADDR1;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPADDR2;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPADDR3;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPCITY;
		protected System.Web.UI.WebControls.Label LBL_CU_COMPCITY;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPZIPCODE;
		protected System.Web.UI.WebControls.Button BTN_SEARCHCOMP;
		protected System.Web.UI.WebControls.DropDownList DDL_JNSALAMAT_C;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_COMPEXTRATING_BY;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_COMPEXTRATING_CLASS;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPEXTRATING_DATE_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_COMPEXTRATING_DATE_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPEXTRATING_DATE_YEAR;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_COMPLISTINGCODE;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPLISTINGDATE_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_COMPLISTINGDATE_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPLISTINGDATE_YEAR;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_COMPBUSSTYPE;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPAKTAPENDIRIAN;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPTGASURANSI_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_TGASURANSI_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPTGASURANSI_YEAR;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPAKTATERAKHIR_NO;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPAKTATERAKHIR_DATE_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_COMPAKTATERAKHIR_DATE_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPAKTATERAKHIR_DATE_YEAR;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPNOTARYNAME;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPEMPLOYEE;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPPHNAREA;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPPHNNUM;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPPHNEXT;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPFAXAREA;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPFAXNUM;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPFAXEXT;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPNPWP;
		protected System.Web.UI.WebControls.TextBox TXT_CU_TDP;
		protected System.Web.UI.WebControls.TextBox TXT_CU_TGLTERBIT_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_TGLTERBIT_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_CU_TGLTERBIT_YEAR;
		protected System.Web.UI.WebControls.TextBox TXT_CU_TGLJATUHTEMPO_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_TGLJATUHTEMPO_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_CU_TGLJATUHTEMPO_YEAR;
		protected System.Web.UI.WebControls.TextBox TXT_CU_CONTACTPERSON;
		protected System.Web.UI.WebControls.TextBox TXT_CU_CONTACTPHNAREA;
		protected System.Web.UI.WebControls.TextBox TXT_CU_CONTACTPHNNUM;
		protected System.Web.UI.WebControls.TextBox TXT_CU_CONTACTPHNEXT;
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPANGGOTA;
		protected System.Web.UI.WebControls.TextBox DDL_groupnasabah;
		protected System.Web.UI.WebControls.DropDownList DDL_bmsektor;
		protected System.Web.UI.WebControls.DropDownList DDL_bmsubsektor;
		protected System.Web.UI.WebControls.DropDownList DDL_bmsubsubsektor;
		protected System.Web.UI.WebControls.DropDownList DDL_SEKTOREKONOMIBI;
		protected System.Web.UI.WebControls.TextBox TXT_TEMPBI;
		protected System.Web.UI.WebControls.TextBox Textbox_netincome;
		protected System.Web.UI.WebControls.TextBox Textbox_pendapatanoperasional;
		protected System.Web.UI.WebControls.TextBox Textbox_pendapatannon;
		protected System.Web.UI.WebControls.DropDownList DDL_lokasiproyek;
		protected System.Web.UI.WebControls.TextBox Textbox_keyperson;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_LOKASIDATI2;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_HUBEXECBM;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_HUBKELBM;
		protected System.Web.UI.WebControls.TextBox TXT_OUTSTANDING;
		protected System.Web.UI.WebControls.TextBox TXT_RATIO_LIMIT;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox TXT_PENDING;
		protected System.Web.UI.WebControls.TextBox TXT_AVAILABLE;
		protected System.Web.UI.WebControls.TextBox TXT_RATIO_AVAIL;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox TXT_INDUSTRYCLASS;
		protected System.Web.UI.WebControls.TextBox TXT_STATUS;
		protected System.Web.UI.WebControls.Label lbl_ksebi4;
		protected System.Web.UI.WebControls.Button BTN_PORTFOLIO;
		protected System.Web.UI.WebControls.RadioButtonList RDO_BI_CHECKING;
		protected System.Web.UI.WebControls.Label LBL_CO;
		protected System.Web.UI.WebControls.DropDownList DDL_GRPUNIT;
		protected System.Web.UI.WebControls.TextBox TXT_BS_RECVDATE;
		protected System.Web.UI.WebControls.Button BTN_SAVE;
		protected System.Web.UI.WebControls.Button BTN_SAVECON;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_generalinfo3;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_PERSONAL;
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_COMPANY;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_telepon;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_koperasi;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_anggota;
		protected System.Web.UI.WebControls.TextBox TXT_AREAID;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_sektor;
	
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
