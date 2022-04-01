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

namespace SME.DCM.CollateralDataCompleteness
{
	/// <summary>
	/// Summary description for CollateralDataComplet.
	/// </summary>
	public class CollateralDataComplet : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.Table TBL_FASILITAS;
		protected System.Web.UI.WebControls.Label LBL_REGNO;
		protected System.Web.UI.WebControls.Label LBL_CUREF;
		protected System.Web.UI.WebControls.Label LBL_TC;
		protected System.Web.UI.WebControls.Button BTN_SAVE;
		protected System.Web.UI.WebControls.DropDownList DDL_TYPE_AGUNAN;
		protected System.Web.UI.WebControls.TextBox TXT_KET_AGUNAN;
		protected System.Web.UI.WebControls.DropDownList DDL_SIFAT_AGUNAN;
		protected System.Web.UI.WebControls.TextBox TXT_NMPEMILIK_COLL;
		protected System.Web.UI.WebControls.DropDownList DDL_BUKTI_KEPEMILIKAN;
		protected System.Web.UI.WebControls.DropDownList DDL_STATUS_KEPEMILIKAN;
		protected System.Web.UI.WebControls.TextBox TXT_DD_TGLTERBITSERT;
		protected System.Web.UI.WebControls.DropDownList DDL_MM_TGLTERBITSERTF;
		protected System.Web.UI.WebControls.TextBox TXT_YY_TGLTERBITSERTF;
		protected System.Web.UI.WebControls.TextBox TXT_DD_EXPSERTF;
		protected System.Web.UI.WebControls.DropDownList DDL_MM_EXPSERTF;
		protected System.Web.UI.WebControls.TextBox TXT_YY_EXPSERTF;
		protected System.Web.UI.WebControls.TextBox TXT_ALAMAT_AGUNAN;
		protected System.Web.UI.WebControls.DropDownList DDL_LKS_DATI2;
		protected System.Web.UI.WebControls.DropDownList DDL_KODE_MATAUANG;
		protected System.Web.UI.WebControls.TextBox TXT_NILAIPASAR;
		protected System.Web.UI.WebControls.TextBox TXT_NILAIAPPRAISAL;
		protected System.Web.UI.WebControls.TextBox TXT_NILAILIKUIDASI;
		protected System.Web.UI.WebControls.TextBox TXT_NILAINJOP;
		protected System.Web.UI.WebControls.TextBox TXT_PENERBITAGUNAN;
		protected System.Web.UI.WebControls.TextBox TXT_LEMBAGA_PRKT;
		protected System.Web.UI.WebControls.TextBox TXT_PRKT_PNRBT_COLL;
		protected System.Web.UI.WebControls.DropDownList DDL_TGL_PEMERINGKATAN;
		protected System.Web.UI.WebControls.TextBox TXT_NILAI_IKAT;
		protected System.Web.UI.WebControls.TextBox TXT_NO_IKAT;
		protected System.Web.UI.WebControls.TextBox TXT_DD_PNLN_KE1;
		protected System.Web.UI.WebControls.DropDownList DDL_MM_PNLN_KE1;
		protected System.Web.UI.WebControls.TextBox TXT_YY_PNLN_KE1;
		protected System.Web.UI.WebControls.TextBox TXT_DD_PNLN_KE2;
		protected System.Web.UI.WebControls.DropDownList DDL_MM_PNLN_KE2;
		protected System.Web.UI.WebControls.TextBox TXT_YY_PNLN_KE2;
		protected System.Web.UI.WebControls.DropDownList DDL_PENILAIANOLEH;
		protected System.Web.UI.WebControls.DropDownList DDL_JENISIKAT;
		protected System.Web.UI.WebControls.TextBox TXT_DD_TGLIKAT;
		protected System.Web.UI.WebControls.DropDownList DDL_MM_TGLIKAT;
		protected System.Web.UI.WebControls.TextBox TXT_YY_TGLIKAT;
		protected System.Web.UI.WebControls.DropDownList DDL_JENISAGUNAN;
		protected System.Web.UI.WebControls.RadioButtonList RDO_ASURANSI;
		protected System.Web.UI.WebControls.DropDownList DDL_PRKT_SRT_BERHARGA;
		protected System.Web.UI.WebControls.TextBox TXT_DD_TGLPRKT;
		protected System.Web.UI.WebControls.DropDownList DDL_MM_TGLPRKT;
		protected System.Web.UI.WebControls.TextBox TXT_YY_TGLPRKT;
		protected System.Web.UI.WebControls.DropDownList DDL_PNRBTN_SRT_BRHRG;
		protected System.Web.UI.WebControls.DropDownList DDL_MM_TGLTERBIT;
		protected System.Web.UI.WebControls.TextBox TXT_DD_TGLTERBIT;
		protected System.Web.UI.WebControls.TextBox TXT_MM_TGLTERBIT;
		protected System.Web.UI.WebControls.TextBox TXT_DD_JTHTEMPO;
		protected System.Web.UI.WebControls.DropDownList DDL_MM_JTHTEMPO;
		protected System.Web.UI.WebControls.TextBox TXT_YY_JTHTEMPO;
		protected System.Web.UI.WebControls.TextBox TXT_PLDAMTTOLIMIT;
		protected System.Web.UI.WebControls.TextBox TXT_PLDAMTTOAVALIMIT;
		protected System.Web.UI.WebControls.TextBox TXT_PPA_CADUM;
		protected System.Web.UI.WebControls.TextBox TXT_PPA_CADKUS;
		protected System.Web.UI.WebControls.Label LBL_DDL_TYPE_AGUNAN;
		protected System.Web.UI.WebControls.Label LBL_TXT_KET_AGUNAN;
		protected System.Web.UI.WebControls.Label LBL_DDL_SIFAT_AGUNAN;
		protected System.Web.UI.WebControls.Label LBL_TXT_NMPEMILIK_COLL;
		protected System.Web.UI.WebControls.Label LBL_DDL_BUKTI_KEPEMILIKAN;
		protected System.Web.UI.WebControls.Label LBL_DDL_STATUS_KEPEMILIKAN;
		protected System.Web.UI.WebControls.Label LBL_DDL_MM_TGLTERBITSERTF;
		protected System.Web.UI.WebControls.Label LBL_DDL_MM_EXPSERTF;
		protected System.Web.UI.WebControls.Label LBL_TXT_ALAMAT_AGUNAN;
		protected System.Web.UI.WebControls.Label LBL_DDL_LKS_DATI2;
		protected System.Web.UI.WebControls.Label LBL_DDL_KODE_MATAUANG;
		protected System.Web.UI.WebControls.Label LBL_TXT_NILAIPASAR;
		protected System.Web.UI.WebControls.Label LBL_TXT_NILAIAPPRAISAL;
		protected System.Web.UI.WebControls.Label LBL_TXT_NILAILIKUIDASI;
		protected System.Web.UI.WebControls.Label LBL_TXT_NILAINJOP;
		protected System.Web.UI.WebControls.Label LBL_TXT_PENERBITAGUNAN;
		protected System.Web.UI.WebControls.Label LBL_TXT_LEMBAGA_PRKT;
		protected System.Web.UI.WebControls.Label LBL_TXT_PRKT_PNRBT_COLL;
		protected System.Web.UI.WebControls.Label LBL_DDL_TGL_PEMERINGKATAN;
		protected System.Web.UI.WebControls.Label LBL_TXT_NILAI_IKAT;
		protected System.Web.UI.WebControls.Label LBL_TXT_NO_IKAT;
		protected System.Web.UI.WebControls.Label LBL_DDL_MM_PNLN_KE1;
		protected System.Web.UI.WebControls.Label LBL_DDL_MM_PNLN_KE2;
		protected System.Web.UI.WebControls.Label LBL_DDL_JENISIKAT;
		protected System.Web.UI.WebControls.Label LBL_DDL_MM_TGLIKAT;
		protected System.Web.UI.WebControls.Label LBL_DDL_JENISAGUNAN;
		protected System.Web.UI.WebControls.Label LBL_RDO_ASURANSI;
		protected System.Web.UI.WebControls.Label LBL_DDL_PRKT_SRT_BERHARGA;
		protected System.Web.UI.WebControls.Label LBL_DDL_MM_TGLPRKT;
		protected System.Web.UI.WebControls.Label LBL_DDL_PNRBTN_SRT_BRHRG;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label LBL_DDL_MM_TGLTERBIT;
		protected System.Web.UI.WebControls.Label LBL_DDL_MM_JTHTEMPO;
		protected System.Web.UI.WebControls.Label LBL_TXT_PLDAMTTOLIMIT;
		protected System.Web.UI.WebControls.Label LBL_TXT_PLDAMTTOAVALIMIT;
		protected System.Web.UI.WebControls.Label LBL_TXT_PPA_CADUM;
		protected System.Web.UI.WebControls.Button BTN_UPDATE;
		protected System.Web.UI.WebControls.Label LBL_DDL_PENILAIANOLEH;
		protected System.Web.UI.WebControls.Label LBL_TXT_PPA_CADKUS;
	
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
