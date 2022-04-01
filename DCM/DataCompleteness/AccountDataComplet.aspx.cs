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
	/// Summary description for AccountDataComplet.
	/// </summary>
	public class AccountDataComplet : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button BTN_SAVE;
		protected System.Web.UI.WebControls.TextBox Textbox31;
		protected System.Web.UI.WebControls.TextBox Textbox32;
		protected System.Web.UI.WebControls.TextBox Textbox33;
		protected System.Web.UI.WebControls.TextBox Textbox34;
		protected System.Web.UI.WebControls.DropDownList DDL_SIFAT_KREDIT;
		protected System.Web.UI.WebControls.DropDownList DDL_JENIS_PENGGUNAAN;
		protected System.Web.UI.WebControls.DropDownList DDL_ORIENTASI;
		protected System.Web.UI.WebControls.DropDownList DDL_GOL_KREDIT;
		protected System.Web.UI.WebControls.DropDownList DDL_JENIS_KREDIT;
		protected System.Web.UI.WebControls.DropDownList DDL_FAS_DANA;
		protected System.Web.UI.WebControls.DropDownList DDL_BANK_SINDIKASI;
		protected System.Web.UI.WebControls.DropDownList DDL_GOL_PENJAMIN;
		protected System.Web.UI.WebControls.DropDownList DDL_KSEBI1;
		protected System.Web.UI.WebControls.DropDownList DDL_KSEBI2;
		protected System.Web.UI.WebControls.DropDownList DDL_KSEBI3;
		protected System.Web.UI.WebControls.DropDownList DDL_KSEBI4;
		protected System.Web.UI.WebControls.DropDownList DDL_BULAN_PKAKHIR;
		protected System.Web.UI.WebControls.TextBox TXT_NOMOR_REKENING;
		protected System.Web.UI.WebControls.DropDownList DDL_LOAN_TYPE;
		protected System.Web.UI.WebControls.Label LBL_TXT_NOMOR_REKENING;
		protected System.Web.UI.WebControls.Label LBL_DDL_LOAN_TYPE;
		protected System.Web.UI.WebControls.Label LBL_DDL_SIFAT_KREDIT;
		protected System.Web.UI.WebControls.Label LBL_DDL_JENIS_PENGGUNAAN;
		protected System.Web.UI.WebControls.Label LBL_DDL_ORIENTASI;
		protected System.Web.UI.WebControls.Label LBL_DDL_GOL_KREDIT;
		protected System.Web.UI.WebControls.Label LBL_DDL_JENIS_KREDIT;
		protected System.Web.UI.WebControls.Label LBL_DDL_FAS_DANA;
		protected System.Web.UI.WebControls.TextBox TXT_LOKASIPROYEK;
		protected System.Web.UI.WebControls.Label LBL_DDL_BANK_SINDIKASI;
		protected System.Web.UI.WebControls.Label LBL_TXT_LOKASIPROYEK;
		protected System.Web.UI.WebControls.TextBox TXT_ALAMATPROJ;
		protected System.Web.UI.WebControls.Label LBL_TXT_ALAMATPROJ;
		protected System.Web.UI.WebControls.DropDownList DDL_NILAIPROJ;
		protected System.Web.UI.WebControls.DropDownList DDL_NEGARAASAL;
		protected System.Web.UI.WebControls.TextBox TXT_JMLREK;
		protected System.Web.UI.WebControls.Label LBL_DDL_NILAIPROJ;
		protected System.Web.UI.WebControls.Label LBL_DDL_NEGARAASAL;
		protected System.Web.UI.WebControls.Label LBL_TXT_JMLREK;
		protected System.Web.UI.WebControls.TextBox TXT_STATUSDEBITUR;
		protected System.Web.UI.WebControls.TextBox TXT_KTGR_DEBTR;
		protected System.Web.UI.WebControls.Label LBL_TXT_STATUSDEBITUR;
		protected System.Web.UI.WebControls.Label LBL_TXT_KTGR_DEBTR;
		protected System.Web.UI.WebControls.DropDownList DDL_JNSVALIND;
		protected System.Web.UI.WebControls.DropDownList DDL_JNSVALFAL;
		protected System.Web.UI.WebControls.Label LBL_TXT_KTGR_PORT;
		protected System.Web.UI.WebControls.Label LBL_DDL_JNSVALIND;
		protected System.Web.UI.WebControls.Label LBL_DDL_JNSVALFAL;
		protected System.Web.UI.WebControls.TextBox TXT_TGKNPOKOK;
		protected System.Web.UI.WebControls.Label LBL_TXT_TGKNPOKOK;
		protected System.Web.UI.WebControls.TextBox TXT_TGLTGKN;
		protected System.Web.UI.WebControls.TextBox TXT_FREKTGKPOKOK;
		protected System.Web.UI.WebControls.Label LBL_TXT_TGLTGKN;
		protected System.Web.UI.WebControls.Label LBL_TXT_FREKTGKPOKOK;
		protected System.Web.UI.WebControls.TextBox TXT_BAGYGDIJMN;
		protected System.Web.UI.WebControls.Label LBL_DDL_GOL_PENJAMIN;
		protected System.Web.UI.WebControls.Label LBL_TXT_BAGYGDIJMN;
		protected System.Web.UI.WebControls.Label LBL_DDL_KSEBI1;
		protected System.Web.UI.WebControls.Label LBL_DDL_KSEBI2;
		protected System.Web.UI.WebControls.Label LBL_DDL_KSEBI3;
		protected System.Web.UI.WebControls.Label LBL_DDL_KSEBI4;
		protected System.Web.UI.WebControls.DropDownList DDL_BULAN_PKPERTAMA;
		protected System.Web.UI.WebControls.Label LBL_DDL_BULAN_PK1;
		protected System.Web.UI.WebControls.TextBox TXT_NOPKPERTAMA;
		protected System.Web.UI.WebControls.TextBox TXT_NOPKTERAKHIR;
		protected System.Web.UI.WebControls.RadioButtonList RDO_PERHT_PPA;
		protected System.Web.UI.WebControls.RadioButtonList RDO_OTOM_KOL;
		protected System.Web.UI.WebControls.Label LBL_TXT_NOPKPERTAMA;
		protected System.Web.UI.WebControls.Label LBL_DDL_BULAN_PKAKHIR;
		protected System.Web.UI.WebControls.Label LBL_TXT_NOPKTERAKHIR;
		protected System.Web.UI.WebControls.Label LBL_DDL_MM_KOLEKTIBILITAS;
		protected System.Web.UI.WebControls.Label LBL_RDO_PERHT_PPA;
		protected System.Web.UI.WebControls.Label LBL_RDO_OTOM_KOL;
		protected System.Web.UI.WebControls.TextBox TXT_CTGRPENGUKURAN;
		protected System.Web.UI.WebControls.TextBox TXT_SUKBUNGINDUK;
		protected System.Web.UI.WebControls.TextBox TXT_SUKBUNGPERFAL;
		protected System.Web.UI.WebControls.Label LBL_TXT_CTGRPENGUKURAN;
		protected System.Web.UI.WebControls.Label LBL_TXT_SUKBUNGINDUK;
		protected System.Web.UI.WebControls.Label LBL_TXT_SUKBUNGPERFAL;
		protected System.Web.UI.WebControls.DropDownList DDL_KOLEKTIBILITAS;
		protected System.Web.UI.WebControls.DropDownList DDL_JNS_SUKBUNG;
		protected System.Web.UI.WebControls.Label LBL_DDL_JNS_SUKBUNG;
		protected System.Web.UI.WebControls.TextBox TXT_PLFINDUK;
		protected System.Web.UI.WebControls.TextBox TXT_PLAFOND;
		protected System.Web.UI.WebControls.TextBox TXT_TGKNBUNGAINTRA;
		protected System.Web.UI.WebControls.TextBox TXT_TGKNBNGEKSTRA;
		protected System.Web.UI.WebControls.TextBox TXT_FREKTGKNBNG;
		protected System.Web.UI.WebControls.Label LBL_TXT_PLFINDUK;
		protected System.Web.UI.WebControls.Label LBL_TXT_PLAFOND;
		protected System.Web.UI.WebControls.Label LBL_TXT_TGKNBUNGAINTRA;
		protected System.Web.UI.WebControls.Label LBL_TXT_TGKNBNGEKSTRA;
		protected System.Web.UI.WebControls.Label LBL_TXT_FREKTGKNBNG;
		protected System.Web.UI.WebControls.RadioButtonList RDO_ONEENTITY;
		protected System.Web.UI.WebControls.RadioButtonList RDO_RESTRUKTURISASI;
		protected System.Web.UI.WebControls.Label LBL_RDO_ONEENTITY;
		protected System.Web.UI.WebControls.Label LBL_RDO_RESTRUKTURISASI;
		protected System.Web.UI.WebControls.DropDownList DDL_JENISRESTRU;
		protected System.Web.UI.WebControls.Label LBL_DDL_JENISRESTRU;
		protected System.Web.UI.WebControls.TextBox TXT_DD_RESTRUAWAL;
		protected System.Web.UI.WebControls.DropDownList DDL_MM_RESTRUAWAL;
		protected System.Web.UI.WebControls.TextBox TXT_YY_RESTRUAWAL;
		protected System.Web.UI.WebControls.TextBox TXT_DD_RESTRUAKHIR;
		protected System.Web.UI.WebControls.TextBox TXT_YY_RESTRUAKHIR;
		protected System.Web.UI.WebControls.DropDownList DDL_MM_RESTRUAKHIR;
		protected System.Web.UI.WebControls.TextBox TXT_DD_RESTRUREVIEW;
		protected System.Web.UI.WebControls.DropDownList DDL_MM_RESTRUREVIEW;
		protected System.Web.UI.WebControls.TextBox TXT_YY_RESTRUREVIEW;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox TXT_RESTRUKE;
		protected System.Web.UI.WebControls.Label LBL_TXT_RESTRUKE;
		protected System.Web.UI.WebControls.DropDownList DDL_KETRESTRU;
		protected System.Web.UI.WebControls.Label LBL_DDL_KETRESTRU;
		protected System.Web.UI.WebControls.DropDownList DDL_SANDIKODEPOSISI;
		protected System.Web.UI.WebControls.Label LBL_DDL_SANDIKODEPOSISI;
		protected System.Web.UI.WebControls.TextBox TXT_YY_TGLPOSISI;
		protected System.Web.UI.WebControls.TextBox TXT_DD_TGLPOSISI;
		protected System.Web.UI.WebControls.DropDownList DDL_MM_TGLPOSISI;
		protected System.Web.UI.WebControls.Label LBL_DDL_MM_TGLPOSISI;
		protected System.Web.UI.WebControls.DropDownList DDL_SEBABMACET;
		protected System.Web.UI.WebControls.Label LBL_DDL_SEBABMACET;
		protected System.Web.UI.WebControls.TextBox TXT_DD_TGLMACET;
		protected System.Web.UI.WebControls.DropDownList DDL_MM_TGLMACET;
		protected System.Web.UI.WebControls.TextBox TXT_YY_TGLMACET;
		protected System.Web.UI.WebControls.TextBox TXT_BAKIDEBET;
		protected System.Web.UI.WebControls.Label LBL_DDL_MM_TGLMACET;
		protected System.Web.UI.WebControls.Label LBL_TXT_BAKIDEBET;
		protected System.Web.UI.WebControls.RadioButtonList RDO_COMMITTED;
		protected System.Web.UI.WebControls.RadioButtonList RDO_UNCOMMITED;
		protected System.Web.UI.WebControls.Label LBL_RDO_COMMITTED;
		protected System.Web.UI.WebControls.Label LBL_RDO_UNCOMMITED;
		protected System.Web.UI.WebControls.TextBox TXT_PDPTBUNGAYAD;
		protected System.Web.UI.WebControls.TextBox TXT_PDPTDITANGGUHKAN;
		protected System.Web.UI.WebControls.Label LBL_TXT_PDPTBUNGAYAD;
		protected System.Web.UI.WebControls.Label LBL_TXT_PDPTDITANGGUHKAN;
		protected System.Web.UI.WebControls.RadioButtonList RDO_INDIVIDUAL;
		protected System.Web.UI.WebControls.RadioButtonList RDO_KOLEKTIF;
		protected System.Web.UI.WebControls.RadioButtonList RDO_JNSPENGAJUAN;
		protected System.Web.UI.WebControls.Label LBL_RDO_INDIVIDUAL;
		protected System.Web.UI.WebControls.Label LBL_RDO_KOLEKTIF;
		protected System.Web.UI.WebControls.Label LBL_RDO_JNSPENGAJUAN;
		protected System.Web.UI.WebControls.Button BTN_CLR;
		protected System.Web.UI.WebControls.TextBox TXT_KTGR_PORT;
	
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
