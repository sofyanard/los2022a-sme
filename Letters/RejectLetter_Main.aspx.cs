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
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.SPPK
{
	/// <summary>
	/// Summary description for RejectLetter_Main.
	/// </summary>
	public partial class RejectLetter_Main : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack) 
			{
				this.view();
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

		}
		#endregion

		private void view() 
		{
			string par1 = Request.QueryString["nomor"];
			string par2 = Request.QueryString["curtime"];
			string par3 = Request.QueryString["cu_name"];
			string par4 = Request.QueryString["ADDR1"];
			string par5 = Request.QueryString["CITY"];
			string par6 = Request.QueryString["MNGR"];
			string par7 = Request.QueryString["ZIPCODE"];
			string par8 = Request.QueryString["PRODUCTDESC"];
			string BRANCH1 = Request.QueryString["BRANCH1"];
			string BRANCH2 = Request.QueryString["BRANCH2"];
			this.PH1.Controls.Add(new LiteralControl("<iframe src='RejectLetterPrint.aspx?nomor=" + par1 + "&curtime=" + par2 + "&cu_name=" + par3 + "&ADDR1=" + par4 + 
				"&CITY=" + par5 + "&MNGR=" + par6 + "&ZIPCODE=" + par7 + "&BRANCH1=" + BRANCH1 + "&BRANCH2=" + BRANCH2 + "&PRODUCTDESC=" + par8 +"' id='framereject' frameborder='0' width=800 height=1000></iframe>"));			
		}
	}
}
