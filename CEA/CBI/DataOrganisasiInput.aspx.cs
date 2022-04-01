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

namespace SME.CEA.CBI
{
	/// <summary>
	/// Summary description for DataOrganisasi.
	/// </summary>
	public class DataOrganisasi : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected System.Web.UI.WebControls.PlaceHolder MenuStrukturOrganisasi;
		protected System.Web.UI.WebControls.TextBox TXT_STATUS_KANTOR;
		protected System.Web.UI.WebControls.TextBox TXT_JML_CAB;
		protected System.Web.UI.WebControls.TextBox TXT_PEG_TETAP;
		protected System.Web.UI.WebControls.TextBox TXT_PEG_TDK_TETAP;
		protected System.Web.UI.WebControls.TextBox TXT_JML_AGEN;
		protected System.Web.UI.WebControls.TextBox TXT_MODAL;
		protected System.Web.UI.WebControls.Button BTN_SAVE_SO;
		protected System.Web.UI.WebControls.Button BTN_CLEAR_SO;
		protected System.Web.UI.WebControls.DataGrid DatGrdCab;
		protected System.Web.UI.WebControls.DropDownList DDL_JNS_CAB;
		protected System.Web.UI.WebControls.TextBox TXT_NAMA_CAB;
		protected System.Web.UI.WebControls.TextBox TXT_ADD_CAB;
		protected System.Web.UI.WebControls.TextBox TXT_NO_AREA;
		protected System.Web.UI.WebControls.TextBox TXT_NO_KNTR;
		protected System.Web.UI.WebControls.DropDownList DDL_CITY_CAB;
		protected System.Web.UI.WebControls.DropDownList DDL_KAB_CAB;
		protected System.Web.UI.WebControls.TextBox TXT_ZIPCD_CAB;
		protected System.Web.UI.WebControls.Button BTN_INSERT_CAB;
		protected System.Web.UI.WebControls.Button BTN_UPDATE_CAB;
		protected System.Web.UI.WebControls.Button BTN_CLEAR_CAB;
		protected System.Web.UI.WebControls.Label TXT_SEQ_CAB;
		protected System.Web.UI.WebControls.DataGrid DatGridTenagaAhli;
		protected System.Web.UI.WebControls.Label TXT_SEQ;
		protected System.Web.UI.WebControls.TextBox TXT_NAMA_TA;
		protected System.Web.UI.WebControls.TextBox TXT_JABATAN_TA;
		protected System.Web.UI.WebControls.TextBox TXT_SERTIFIKASI;
		protected System.Web.UI.WebControls.TextBox TXT_GELAR_TA;
		protected System.Web.UI.WebControls.TextBox TXT_ASOSIASI_PROFESI;
		protected System.Web.UI.WebControls.TextBox TXT_PENGALAMAN_TA;
		protected System.Web.UI.WebControls.Button BTN_INSERT_TA;
		protected System.Web.UI.WebControls.Button BTN_Clear_TA;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_MODAL;
	
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
