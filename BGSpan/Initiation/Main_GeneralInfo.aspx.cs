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

namespace SME.BGSpan.Initiation
{
	/// <summary>
	/// Summary description for Main_GeneralInfo.
	/// </summary>
	public class Main_GeneralInfo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.Label LBL_SEQ;
		protected System.Web.UI.WebControls.Button BTN_SAVE;
		protected System.Web.UI.WebControls.Button BTN_UPDATE;
		protected System.Web.UI.WebControls.TextBox TXT_TGL_TARGET_DAY;
		protected System.Web.UI.WebControls.TextBox TXT_TGL_TARGET_YEAR;
		protected System.Web.UI.WebControls.Label LBL_REGION;
		protected System.Web.UI.WebControls.Label LBL_TXT_BUSUNIT;
		protected System.Web.UI.WebControls.DropDownList DDL_BUSUNIT;
		protected System.Web.UI.WebControls.Label LBL_TXT_PROGRAM;
		protected System.Web.UI.WebControls.DropDownList DDL_PROGRAM;
		protected System.Web.UI.WebControls.Label LBL_TXT_OPUNIT;
		protected System.Web.UI.WebControls.DropDownList DDL_OPUNIT;
		protected System.Web.UI.WebControls.Label LBL_TXT_APP_DATE;
		protected System.Web.UI.WebControls.DropDownList DDL_APP_DATE_MONTH;
		protected System.Web.UI.WebControls.Label LBL_TXT_APPNUMBER;
		protected System.Web.UI.WebControls.TextBox APPNUMBER;
		protected System.Web.UI.WebControls.TextBox REGION;
	
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
