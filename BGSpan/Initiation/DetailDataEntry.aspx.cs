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
using Microsoft.VisualBasic;
using System.Configuration ;

namespace SME.BGSpan.Initiation
{
	/// <summary>
	/// Summary description for DetailDataEntry.
	/// </summary>
	public class DetailDataEntry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.Label LBL_NONOTA;
		protected System.Web.UI.WebControls.Label LBL_TXT_TGLNOTA;
		protected System.Web.UI.WebControls.TextBox TXT_TGLNOTA_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_TGLNOTA_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_TGLNOTA_YEAR;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist1;
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected System.Web.UI.WebControls.Label LBL_TXT_BUSUNIT;
		protected System.Web.UI.WebControls.DropDownList DDL_BUSUNIT;
		protected System.Web.UI.WebControls.Label LBL_TXT_PROGRAM;
		protected System.Web.UI.WebControls.DropDownList DDL_PROGRAM;
		protected System.Web.UI.WebControls.Label LBL_TXT_OPUNIT;
		protected System.Web.UI.WebControls.DropDownList DDL_OPUNIT;
		protected System.Web.UI.WebControls.Label LBL_TXT_APP_DATE;
		protected System.Web.UI.WebControls.TextBox TXT_TGL_TARGET_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_APP_DATE_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_TGL_TARGET_YEAR;
		protected System.Web.UI.WebControls.Label LBL_TXT_APPNUMBER;
		protected System.Web.UI.WebControls.TextBox APPNUMBER;
		protected System.Web.UI.WebControls.Label LBL_SEQ;
		protected System.Web.UI.WebControls.Button BTN_SAVE;
		protected System.Web.UI.WebControls.Label LBL_DOCEXPORT;
		protected System.Web.UI.WebControls.Button BTN_UPLOAD;
		protected System.Web.UI.WebControls.TextBox txt_nama_doc;
		protected System.Web.UI.WebControls.DataGrid dg_non_cash;
		protected System.Web.UI.WebControls.Button btn_insert;
		protected System.Web.UI.WebControls.DataGrid Datagrid1;
		protected System.Web.UI.WebControls.TextBox txt_filename;
		protected System.Web.UI.WebControls.Button btn_browse;
		protected System.Web.UI.WebControls.TextBox txt_status_file;
		protected System.Web.UI.WebControls.Button btn_upload;
		protected System.Web.UI.WebControls.TextBox txt_jns_permohonan;
		protected System.Web.UI.WebControls.DropDownList ddl_jns_fasilitas;
		protected System.Web.UI.WebControls.TextBox txt_limit_rp;
		protected System.Web.UI.WebControls.TextBox txt_limit;
		protected System.Web.UI.WebControls.TextBox txt_exchange;
		protected System.Web.UI.WebControls.TextBox txt_tgl_jangka;
		protected System.Web.UI.WebControls.DropDownList ddl_jangka_wkt;
		protected System.Web.UI.WebControls.DropDownList ddl_tujuan_peng;
		protected System.Web.UI.WebControls.TextBox txt_provisi;
		protected System.Web.UI.WebControls.DataGrid dg_detail;
		protected System.Web.UI.WebControls.TextBox TXT_NONOTA;
		protected System.Web.UI.WebControls.Label LBL_TXT_NOSURATNSBH;
		protected System.Web.UI.WebControls.TextBox TXT_NOSURAT;
		protected System.Web.UI.WebControls.Label LBL_TXT_TGLSURAT;
		protected System.Web.UI.WebControls.TextBox TXT_TGLSURAT_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_TGLSURAT_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_TGLSURAT_YEAR;
		protected System.Web.UI.WebControls.Label LBL_TXT_TGLTRIMA;
		protected System.Web.UI.WebControls.TextBox TXT_TGLTRIMA_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_TGLTRIMA_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_TGLTRIMA_YEAR;
		protected System.Web.UI.WebControls.TextBox TXT_APPNUMBER;
		protected System.Web.UI.WebControls.TextBox TXT_UNITKERJA;
		protected System.Web.UI.WebControls.Label LBL_TXT_PENGUSUL;
		protected System.Web.UI.WebControls.TextBox TXT_PENGUSUL;
		protected System.Web.UI.WebControls.Label LBL_TXT_PEMUTUS;
		protected System.Web.UI.WebControls.TextBox TXT_PEMUTUS;
		protected System.Web.UI.WebControls.Label LBL_TXT_UNITKERJA;
		protected System.Web.UI.WebControls.CheckBox CHK_COLLATERAL;
		protected System.Web.UI.WebControls.RadioButtonList RDO_COLLATERAL;
		protected System.Web.UI.WebControls.DropDownList DDL_CL_TYPE;
		protected System.Web.UI.WebControls.DropDownList DDL_CL_TYPE_EXISTING;
		protected System.Web.UI.WebControls.Label LBL_SISAUTILIZATION;
		protected System.Web.UI.WebControls.TextBox TXT_LC_PERCENTAGE;
		protected System.Web.UI.WebControls.TextBox TXT_CL_DESC;
		protected System.Web.UI.WebControls.TextBox TXT_COL_ID;
		protected System.Web.UI.WebControls.DropDownList DDL_BUKTI_KEPEMILIKAN;
		protected System.Web.UI.WebControls.DropDownList DDL_BENTUK_PENGIKATAN;
		protected System.Web.UI.WebControls.DropDownList DDL_CL_COLCLASSIFY;
		protected System.Web.UI.WebControls.DropDownList DDL_CL_CURRENCY;
		protected System.Web.UI.WebControls.TextBox TXT_CL_EXCHANGERATE;
		protected System.Web.UI.WebControls.TextBox TXT_CL_FOREIGNVAL;
		protected System.Web.UI.WebControls.TextBox TXT_CL_VALUE;
		protected System.Web.UI.WebControls.TextBox TXT_CL_FOREIGNVAL2;
		protected System.Web.UI.WebControls.TextBox TXT_CL_VALUE2;
		protected System.Web.UI.WebControls.TextBox TXT_CL_FOREIGNVALINS;
		protected System.Web.UI.WebControls.TextBox TXT_CL_VALUEINS;
		protected System.Web.UI.WebControls.TextBox TXT_CL_FOREIGNVALIKAT;
		protected System.Web.UI.WebControls.TextBox TXT_CL_VALUEIKAT;
		protected System.Web.UI.WebControls.TextBox TXT_CL_FOREIGNVALPPA;
		protected System.Web.UI.WebControls.TextBox TXT_CL_VALUEPPA;
		protected System.Web.UI.WebControls.TextBox TXT_CL_FOREIGNVALLIQ;
		protected System.Web.UI.WebControls.TextBox TXT_CL_VALUELIQ;
		protected System.Web.UI.WebControls.TextBox TXT_TGLPENILAIAN_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_TGLPENILAIAN_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_TGLPENILAIAN_YEAR;
		protected System.Web.UI.WebControls.DropDownList DDL_PENILAI_OLEH;
		protected System.Web.UI.WebControls.Button BTN_INSCOLL;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_BUTTONS;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.RadioButtonList RDO_RFCUSTOMERTYPE;
		protected System.Web.UI.WebControls.TextBox TXT_CU_CIF_P;
		protected System.Web.UI.WebControls.Label LBL_AP_RELMNGR;
		protected System.Web.UI.WebControls.Label TXT_CU_REF;
		protected System.Web.UI.WebControls.TextBox TXT_CU_TITLEBEFORENAME;
		protected System.Web.UI.WebControls.Label TXT_AP_REGNO;
		protected System.Web.UI.WebControls.Label TXT_AP_RELMNGR;
		protected System.Web.UI.WebControls.TextBox TXT_CU_FIRSTNAME;
		protected System.Web.UI.WebControls.Label TXT_PROG_CODE;
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
		protected System.Web.UI.WebControls.TextBox TXT_CU_COMPEXTRATING_CLASS;
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
		protected System.Web.UI.WebControls.Label temp_userid;
		protected System.Web.UI.WebControls.Label temp_branchcode;
		protected System.Web.UI.WebControls.Label temp_areaid;
		protected System.Web.UI.WebControls.TextBox Textbox_netincome;
		protected System.Web.UI.WebControls.TextBox Textbox_pendapatanoperasional;
		protected System.Web.UI.WebControls.TextBox Textbox_pendapatannon;
		protected System.Web.UI.WebControls.DropDownList DDL_lokasiproyek;
		protected System.Web.UI.WebControls.TextBox Textbox_keyperson;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_LOKASIDATI2;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_HUBEXECBM;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button BTN_SAVECON;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_PERSONAL;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_COMPANY;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_telepon;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_koperasi;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_anggota;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_sektor;
		protected System.Web.UI.WebControls.TextBox TXT_CI_BMSAVING_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_CI_BMSAVING_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_CI_BMSAVING_YEAR;
		protected System.Web.UI.WebControls.TextBox TXT_CI_BMDEBITUR_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_CI_BMDEBITUR_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_CI_BMDEBITUR_YEAR;
		protected System.Web.UI.WebControls.TextBox TXT_CI_BMGIRO_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_CI_BMGIRO_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_CI_BMGIRO_YEAR;
		protected System.Web.UI.WebControls.Label LBL_SUBTOTAL;
		protected System.Web.UI.WebControls.TextBox TXT_SUBTOTAL;
		protected System.Web.UI.WebControls.TextBox TXT_TOTAL;
		protected System.Web.UI.WebControls.DropDownList DDL_CM_CREDITTYPE;
		protected System.Web.UI.WebControls.TextBox TXT_CM_COMPNAME;
		protected System.Web.UI.WebControls.TextBox TXT_CM_LIMIT;
		protected System.Web.UI.WebControls.TextBox TXT_CM_OUTSTANDING;
		protected System.Web.UI.WebControls.TextBox TXT_CM_TGKPOKOK;
		protected System.Web.UI.WebControls.TextBox TXT_CM_TGLPOSISI_D;
		protected System.Web.UI.WebControls.DropDownList DDL_CM_TGLPOSISI_M;
		protected System.Web.UI.WebControls.TextBox TXT_CM_TGLPOSISI_Y;
		protected System.Web.UI.WebControls.TextBox TXT_CM_TGKBUNGA;
		protected System.Web.UI.WebControls.TextBox TXT_CM_LAMATGK;
		protected System.Web.UI.WebControls.TextBox TXT_CM_DUEDATE_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_CM_DUEDATE_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_CM_DUEDATE_YEAR;
		protected System.Web.UI.WebControls.DropDownList DDL_CM_COLLECTABILITY;
		protected System.Web.UI.WebControls.TextBox TXT_CM_ACCNO;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.WebControls.DataGrid DatGridOtherLoan;
		protected System.Web.UI.WebControls.TextBox TXT_CO_CREDTYPE;
		protected System.Web.UI.WebControls.DropDownList DDL_CO_BANKNAME;
		protected System.Web.UI.WebControls.TextBox TXT_CO_LIMIT;
		protected System.Web.UI.WebControls.TextBox TXT_CO_BAKIDEBET;
		protected System.Web.UI.WebControls.TextBox TXT_CO_TGLPOSISI_D;
		protected System.Web.UI.WebControls.DropDownList DDL_CO_TGLPOSISI_M;
		protected System.Web.UI.WebControls.TextBox TXT_CO_TGLPOSISI_Y;
		protected System.Web.UI.WebControls.TextBox TXT_CO_TGLDEBITUR_D;
		protected System.Web.UI.WebControls.DropDownList DDL_CO_TGLDEBITUR_M;
		protected System.Web.UI.WebControls.TextBox TXT_CO_TGLDEBITUR_Y;
		protected System.Web.UI.WebControls.TextBox TXT_CO_TGKPOKOK;
		protected System.Web.UI.WebControls.TextBox TXT_CO_TGKBUNGA;
		protected System.Web.UI.WebControls.TextBox TXT_CO_DUEDATE_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_CO_DUEDATE_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_CO_DUEDATE_YEAR;
		protected System.Web.UI.WebControls.DropDownList DDL_CO_COLLECTABILITY;
		protected System.Web.UI.WebControls.DropDownList DDL_RFJENISPRODUCT;
		protected System.Web.UI.WebControls.Label LBL_PAR;
		protected System.Web.UI.WebControls.Button BtnInsert1;
		protected System.Web.UI.WebControls.Button Button4;
		protected System.Web.UI.HtmlControls.HtmlTableRow br01;
		protected System.Web.UI.HtmlControls.HtmlTableRow br02;
		protected System.Web.UI.HtmlControls.HtmlTableRow br04;
		protected System.Web.UI.HtmlControls.HtmlTableRow br05;
		protected System.Web.UI.HtmlControls.HtmlTableRow namaPerusahaan;
		protected System.Web.UI.HtmlControls.HtmlTableRow br08;
		protected System.Web.UI.HtmlControls.HtmlTableRow br09;
		protected System.Web.UI.HtmlControls.HtmlTableRow br10;
		protected System.Web.UI.HtmlControls.HtmlTableRow br11;
		protected System.Web.UI.HtmlControls.HtmlTableRow brtombol;
		protected System.Web.UI.WebControls.RadioButtonList Radiobuttonlist1;
		protected System.Web.UI.WebControls.TextBox TXT_CS_FIRSTNAME;
		protected System.Web.UI.WebControls.TextBox TXT_CS_MIDDLENAME;
		protected System.Web.UI.WebControls.TextBox TXT_CS_LASTNAME;
		protected System.Web.UI.WebControls.TextBox TXT_CS_IDCARDNUM;
		protected System.Web.UI.WebControls.TextBox TXT_CS_ADDR1;
		protected System.Web.UI.WebControls.TextBox TXT_CS_ADDR2;
		protected System.Web.UI.WebControls.TextBox TXT_CS_ADDR3;
		protected System.Web.UI.WebControls.TextBox TXT_CS_CITY;
		protected System.Web.UI.WebControls.TextBox TXT_CS_ZIPCODE;
		protected System.Web.UI.WebControls.Button Button5;
		protected System.Web.UI.WebControls.DropDownList DDL_CS_HOMESTA;
		protected System.Web.UI.WebControls.TextBox TXT_CS_REMARK;
		protected System.Web.UI.WebControls.Label SEQ;
		protected System.Web.UI.WebControls.TextBox TXT_CS_EMAS_CIF;
		protected System.Web.UI.WebControls.TextBox TXT_CS_DOB_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_CS_DOB_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_CS_DOB_YEAR;
		protected System.Web.UI.WebControls.DropDownList DDL_CS_EDUCATION;
		protected System.Web.UI.WebControls.TextBox TXT_CS_NPWP;
		protected System.Web.UI.WebControls.DropDownList DDL_CS_JOBTITLE;
		protected System.Web.UI.WebControls.DropDownList DDL_CS_EXPERIENCE;
		protected System.Web.UI.WebControls.TextBox TXT_CS_STOCKPERC;
		protected System.Web.UI.WebControls.Label LBL_TOTPERC;
		protected System.Web.UI.WebControls.RadioButton RDO_CS_NATSTAT0;
		protected System.Web.UI.WebControls.RadioButton RDO_CS_NATSTAT1;
		protected System.Web.UI.WebControls.DropDownList DDL_CS_SEX;
		protected System.Web.UI.WebControls.DropDownList DDL_CS_MARITAL;
		protected System.Web.UI.WebControls.TextBox TXT_CS_CHILDREN;
		protected System.Web.UI.WebControls.TextBox TXT_CS_MULAIMENETAPMM;
		protected System.Web.UI.WebControls.TextBox TXT_CS_MULAIMENETAPYY;
		protected System.Web.UI.WebControls.RadioButtonList RDO_KEY_PERSON;
		protected System.Web.UI.WebControls.CheckBox CHK_REMOVED;
		protected System.Web.UI.WebControls.Button BTN_STOCKHOLDER;
		protected System.Web.UI.WebControls.DataGrid DatGridPengurus;
		protected System.Web.UI.WebControls.TextBox TXT_CIF;
		protected System.Web.UI.WebControls.TextBox TXT_CS_NAMA;
		protected System.Web.UI.WebControls.TextBox TXT_CS_TYPE;
		protected System.Web.UI.WebControls.TextBox TXT_CS_BOD_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_CS_BOD_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_CS_BOD_YEAR;
		protected System.Web.UI.WebControls.DropDownList DDL_CS_JENISID;
		protected System.Web.UI.WebControls.TextBox TXT_CS_NOID;
		protected System.Web.UI.WebControls.TextBox TXT_CS_EXPR_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_CS_EXPR_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_CS_EXPR_YEAR;
		protected System.Web.UI.WebControls.TextBox TXT_CS_ALAMAT;
		protected System.Web.UI.WebControls.TextBox TXT_CS_KODEPOS;
		protected System.Web.UI.WebControls.DropDownList DDL_CS_BUC;
		protected System.Web.UI.WebControls.DropDownList DDL_KODEHUB;
		protected System.Web.UI.WebControls.Button BTN_CLEAR;
		protected System.Web.UI.WebControls.DropDownList DDL_BG;
		protected System.Web.UI.WebControls.Label LBL_TXT_PENERIMABG;
		protected System.Web.UI.WebControls.TextBox TXT_PENERIMABG;
		protected System.Web.UI.WebControls.Label LBL_TXT_TGLLAKUBG;
		protected System.Web.UI.WebControls.TextBox TXT_TGLLAKUBG_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_TGLLAKU_MONTH;
		protected System.Web.UI.WebControls.Label LBL_TXT_NILAIPROYEK;
		protected System.Web.UI.WebControls.TextBox TXT_NILAIPROYEK;
		protected System.Web.UI.WebControls.DropDownList DDL_SIFATBG;
		protected System.Web.UI.WebControls.DropDownList DDL_JenisBG;
		protected System.Web.UI.WebControls.Label LBL_TXT_SYARATBG;
		protected System.Web.UI.WebControls.TextBox TXT_SYARATBG;
		protected System.Web.UI.WebControls.Label LBL_TXT_TTDBG;
		protected System.Web.UI.WebControls.TextBox TXT_TTDBG;
		protected System.Web.UI.WebControls.DropDownList DDL_Jabatan;
		protected System.Web.UI.WebControls.Label LBL_TXT_KEBBG;
		protected System.Web.UI.WebControls.TextBox TXT_KEBBG;
		protected System.Web.UI.WebControls.Label LBL_persen;
		protected System.Web.UI.WebControls.Label LBL_TXT_SETORJAMINAN;
		protected System.Web.UI.WebControls.TextBox TXT_SETORJAMINAN;
		protected System.Web.UI.WebControls.DropDownList DDL_ASPEK;
		protected System.Web.UI.WebControls.Button Button6;
		protected System.Web.UI.WebControls.DataGrid DGR_RAC;
		protected System.Web.UI.WebControls.Button BTN_SAVERAC;
		protected System.Web.UI.HtmlControls.HtmlTable FORMAT_G;
		protected System.Web.UI.HtmlControls.HtmlTable Table9;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.Button BTN_ADD;
		protected System.Web.UI.WebControls.Button BTN_CANCEL;
		protected System.Web.UI.WebControls.DataGrid Datagrid2;
		protected System.Web.UI.WebControls.ListBox ListBox2;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_COLL4;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_COLL3;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_BUTTONS1;
		protected System.Web.UI.WebControls.Button BTN_SAVEREQ;
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			ViewMenu();
			// Put user code to initialize the page here
			if(!IsPostBack)
			{

			}
		}

		private void isiGeneralInfo(){
			TXT_APPNUMBER.Text=Request.QueryString["ap_number"];
			TXT_PENGUSUL.Text=Session["FullName"].ToString();





		}

		private void ViewMenu()
		{
			Menu.Controls.Clear();
			try 
			{
				conn.QueryString = "SELECT * FROM SCREENMENU WHERE MENUCODE = '" + Request.QueryString["mc"] + "'";
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
							strtemp = "&curef=" + Request.QueryString["curef"] + "&cif=" + Request.QueryString["cif"] + "&exist=" + Request.QueryString["exist"];
						else	
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&curef=" + Request.QueryString["curef"] + "&cif=" + Request.QueryString["cif"] + "&exist=" + Request.QueryString["exist"];
					}
					else 
					{
						strtemp = ""; 
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
			this.TXT_NONOTA.TextChanged += new System.EventHandler(this.TXT_NONOTA_TextChanged);
			this.TXT_APPNUMBER.TextChanged += new System.EventHandler(this.TXT_APPNUMBER_TextChanged);
			this.CHK_REMOVED.CheckedChanged += new System.EventHandler(this.CHK_REMOVED_CheckedChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void NONOTA_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void CHK_REMOVED_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void TXT_APPNUMBER_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void TXT_NONOTA_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
