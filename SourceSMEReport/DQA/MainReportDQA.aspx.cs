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
using Microsoft.VisualBasic;
using System.Configuration;
namespace SME.SourceSMEReport.DQA
{
	/// <summary>
	/// Summary description for MainReportDQA.
	/// </summary>
	public partial class MainReportDQA : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]); 
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Request.QueryString ["mc"]=="DQA01")
			{
				TR_BUC_KREDIT.Visible = false;
				TR_CIF_KREDIT.Visible = false;
				TR_PERKREDITAN.Visible = false;
				TR_AGUNAN.Visible = false;
				TR_ILP_ERROR.Visible = false;
			}
			else if (Request.QueryString ["mc"]=="DQA03")
			{
				TR_BUC_DANA.Visible = false;
				TR_CIF_DANA.Visible = false;
				TR_UNCLEAN_CIF.Visible = false;
//				TR_NORMALISASI.Visible = false;
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
	}
}
