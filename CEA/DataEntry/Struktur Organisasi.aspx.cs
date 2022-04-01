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

namespace SME.CEA.DataEntry
{
	/// <summary>
	/// Summary description for Struktur_Organisasi.
	/// </summary>
	public class Struktur_Organisasi : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected System.Web.UI.WebControls.HyperLink HL_ACCOUNT;
		protected System.Web.UI.WebControls.HyperLink Hyperlink1;
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		protected System.Web.UI.WebControls.HyperLink HL_HISTORY;
		protected System.Web.UI.WebControls.HyperLink Hyperlink4;
		protected System.Web.UI.WebControls.LinkButton LNK_EDIT;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.DataGrid DatGridPengurus;
		protected System.Web.UI.WebControls.Button BTN_insert_org;
		protected System.Web.UI.WebControls.Button BTN_save_org;
		protected System.Web.UI.WebControls.TextBox TXT_status_org;
		protected System.Web.UI.WebControls.TextBox TXT_cabang_org;
		protected System.Web.UI.WebControls.TextBox TXT_tetap_org;
		protected System.Web.UI.WebControls.TextBox TXT_tdktetap_org;
		protected System.Web.UI.WebControls.TextBox TXT_agen_org;
		protected System.Web.UI.WebControls.TextBox TXT_nama_TA;
		protected System.Web.UI.WebControls.TextBox TXT_jabatan_TA;
		protected System.Web.UI.WebControls.TextBox TXT_Gelar_TA;
		protected System.Web.UI.WebControls.TextBox TXT_pengalaman_TA;
		protected System.Web.UI.WebControls.Button BTN_CLEAR_org;
		protected System.Web.UI.WebControls.Button BTN_clear2_org;
	
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
			this.BTN_insert_org.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
