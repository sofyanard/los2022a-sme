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
using SME.Syndication;
using System.Configuration;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME
{
	/// <summary>
	/// Summary description for TestSendEmailFunction.
	/// </summary>
	public partial class TestSendEmailFunction : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn.QueryString = "SELECT * FROM VW_SYNDICATION_EMAIL_TEST";
			SendingEmail.Send("HQMandiri@bankmandiri.co.id","prasetyo.wibowo@bankmandiri.co.id", SendingEmail.EmailFormat.LaporanDokumenYangAkanJatuhTempo, conn);
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
	}
}
