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
	/// Summary description for CustomerInfo_edit.
	/// </summary>
	public class CustomerInfo_edit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox cu_comket;
		protected System.Web.UI.WebControls.TextBox cu_comnpwp;
		protected System.Web.UI.WebControls.TextBox cu_comemail;
		protected System.Web.UI.WebControls.TextBox cu_comnofax;
		protected System.Web.UI.WebControls.TextBox cu_comnotelp;
		protected System.Web.UI.WebControls.TextBox cu_comkota;
		protected System.Web.UI.WebControls.TextBox cu_comalamat3;
		protected System.Web.UI.WebControls.TextBox cu_comalamat2;
		protected System.Web.UI.WebControls.TextBox cu_comalamat1;
		protected System.Web.UI.WebControls.TextBox cu_comberdiriyear;
		protected System.Web.UI.WebControls.DropDownList cu_comberdirimonth;
		protected System.Web.UI.WebControls.TextBox cu_comberdiriday;
		protected System.Web.UI.WebControls.TextBox cu_comnamadulu;
		protected System.Web.UI.WebControls.DropDownList cu_comjenis;
		protected System.Web.UI.WebControls.TextBox cu_tglakhiryear;
		protected System.Web.UI.WebControls.DropDownList cu_tglakhirmonth;
		protected System.Web.UI.WebControls.TextBox cu_tglakhirday;
		protected System.Web.UI.WebControls.TextBox cu_noktp;
		protected System.Web.UI.WebControls.TextBox cu_kota;
		protected System.Web.UI.WebControls.TextBox cu_alamat3;
		protected System.Web.UI.WebControls.TextBox cu_alamat2;
		protected System.Web.UI.WebControls.TextBox cu_alamat1;
		protected System.Web.UI.WebControls.TextBox cu_nama;
		protected System.Web.UI.WebControls.TextBox cu_gelarsblm;
		protected System.Web.UI.WebControls.DropDownList cu_jenis;
		protected System.Web.UI.WebControls.HyperLink HL_HISTORY;
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		protected System.Web.UI.WebControls.HyperLink Hyperlink1;
		protected System.Web.UI.WebControls.HyperLink HL_ACCOUNT;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected System.Web.UI.WebControls.HyperLink HL_COLLATERAL;
		protected System.Web.UI.WebControls.RadioButtonList RDO_RFCUSTOMERTYPE;
		protected System.Web.UI.WebControls.TextBox cu_tmptlahir;
		protected System.Web.UI.WebControls.TextBox cu_tgllahirday;
		protected System.Web.UI.WebControls.DropDownList cu_tgllahirmonth;
		protected System.Web.UI.WebControls.TextBox cu_tgllahiryear;
		protected System.Web.UI.WebControls.Button BTN_NEW;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_PERSONAL;
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist1;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.TextBox cu_ket;
		protected System.Web.UI.WebControls.TextBox Textbox3;
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist2;
		protected System.Web.UI.WebControls.TextBox Textbox4;
		protected System.Web.UI.WebControls.TextBox Textbox5;
		protected System.Web.UI.WebControls.TextBox Textbox6;
		protected System.Web.UI.WebControls.TextBox Textbox7;
		protected System.Web.UI.WebControls.TextBox Textbox8;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_COMPANY;
	
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
