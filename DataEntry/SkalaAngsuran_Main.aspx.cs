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

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for SkalaAngsuran_Main.
	/// </summary>
	public partial class SkalaAngsuran_Main : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack) 
			{
				//
				this.viewLinks();
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

		private void viewLinks() 
		{
			HyperLink lnk_simple = new HyperLink();
			lnk_simple.Text = "Skala Angsuran Simple Interest";
			lnk_simple.ID = "simple";
			lnk_simple.NavigateUrl = "SkalaAngsuranDetail.aspx";
			lnk_simple.Target = "if";

			HyperLink lnk_annuity = new HyperLink();
			lnk_annuity.Text = "Skala Angsuran Anuitet";
			lnk_annuity.ID = "annuity";
			lnk_annuity.NavigateUrl = "SkalaAngsuranAnuitet.aspx";
			lnk_annuity.Target = "if";

			this.PH_JENIS_ANGSURAN.Controls.Add(lnk_simple);
			this.PH_JENIS_ANGSURAN.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
			this.PH_JENIS_ANGSURAN.Controls.Add(lnk_annuity);
		}
	}
}
