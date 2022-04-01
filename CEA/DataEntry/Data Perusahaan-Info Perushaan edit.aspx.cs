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
	/// Summary description for Data_Perusahaan_Info_Perushaan_edit.
	/// </summary>
	public class Data_Perusahaan_Info_Perushaan_edit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink HL_HISTORY;
		protected System.Web.UI.WebControls.HyperLink HL_COLLATERAL;
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		protected System.Web.UI.WebControls.HyperLink Hyperlink1;
		protected System.Web.UI.WebControls.HyperLink HL_ACCOUNT;
		protected System.Web.UI.WebControls.DataGrid DatGridPengurus;
		protected System.Web.UI.WebControls.TextBox TXT_CS_IDCARDNUM;
		protected System.Web.UI.WebControls.TextBox TXT_CS_NPWP;
		protected System.Web.UI.WebControls.TextBox TXT_CS_STOCKPERC;
		protected System.Web.UI.WebControls.RadioButtonList RDO_KEY_PERSON;
		protected System.Web.UI.WebControls.Button BTN_STOCKHOLDER;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist1;
		protected System.Web.UI.WebControls.TextBox Textbox3;
		protected System.Web.UI.WebControls.TextBox Textbox4;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist2;
		protected System.Web.UI.WebControls.TextBox Textbox5;
		protected System.Web.UI.WebControls.TextBox Textbox6;
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
	
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
			this.BTN_STOCKHOLDER.Click += new System.EventHandler(this.BTN_STOCKHOLDER_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BTN_STOCKHOLDER_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
