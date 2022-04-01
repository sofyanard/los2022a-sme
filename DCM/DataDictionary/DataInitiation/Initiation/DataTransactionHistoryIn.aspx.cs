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

namespace SME.DCM.DataDictionary.DataInitiation.Initiation
{
	/// <summary>
	/// Summary description for DataTransactionHistoryIn.
	/// </summary>
	public class DataTransactionHistoryIn : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.DataGrid DGR_PROBLEM;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_RBI;
		protected System.Web.UI.WebControls.RadioButtonList RDO_RBI;
		protected System.Web.UI.WebControls.RadioButtonList Radiobuttonlist1;
		protected System.Web.UI.WebControls.DataGrid Datagrid1;
		protected System.Web.UI.HtmlControls.HtmlTableRow Tr1;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.RadioButtonList Radiobuttonlist2;
		protected System.Web.UI.WebControls.DataGrid Datagrid2;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.HtmlControls.HtmlTableRow Tr2;
		protected System.Web.UI.WebControls.RadioButtonList Radiobuttonlist3;
		protected System.Web.UI.WebControls.DataGrid Datagrid3;
		protected System.Web.UI.WebControls.Button Button4;
		protected System.Web.UI.WebControls.RadioButtonList Radiobuttonlist4;
		protected System.Web.UI.WebControls.DataGrid Datagrid4;
		protected System.Web.UI.WebControls.Button Button5;
		protected System.Web.UI.HtmlControls.HtmlTableRow Tr3;
		protected System.Web.UI.HtmlControls.HtmlTableRow Tr4;
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected System.Web.UI.WebControls.Button Button1;
	
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
