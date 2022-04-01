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

namespace SME.DCM.Data_Dictionary.DataInitiation.RejectInitiation
{
	/// <summary>
	/// Summary description for GeneralInformationIn.
	/// </summary>
	public class Main : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.TextBox TXT_AREA;
		protected System.Web.UI.WebControls.Label LBL_r;
		protected System.Web.UI.WebControls.Label LBL_REKANANTYPEID;
		protected System.Web.UI.WebControls.Label LBL_AP_PROG_CODE;
		protected System.Web.UI.WebControls.TextBox TXT_CODE;
		protected System.Web.UI.WebControls.TextBox TXT_TGL;
		protected System.Web.UI.WebControls.TextBox DESC_TXT;
		protected System.Web.UI.WebControls.Label LBL_STATUS;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.Label LBL_STATUSREPORT;
		protected System.Web.UI.WebControls.Label LBL_SUMBERDATA;
		protected System.Web.UI.WebControls.Button UPLOAD;
		protected System.Web.UI.WebControls.DataGrid DATA_EXPORT;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_EX_JUDUL;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_EX_CONTENT;
		protected System.Web.UI.WebControls.DropDownList DDL_PURPOSE;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DataGrid Datagrid1;
		protected System.Web.UI.WebControls.Button BTN_SAVE;
		protected System.Web.UI.WebControls.Button BTN_SEND;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.HtmlControls.HtmlInputFile TXT_FILE_UPLOAD;
	
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
