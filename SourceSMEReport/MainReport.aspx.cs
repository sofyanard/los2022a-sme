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

namespace SourceSMEReport
{
	/// <summary>
	/// Summary description for MainReport.sadfsdafs
	/// </summary>
	public partial class MainReport : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
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

		}
		#endregion

		protected void DDL_REPORT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			RB_OR.Visible	= false;
			RB_SLA.Visible	= false;
			RB_PR.Visible	= false;
			RB_CR.Visible	= false;
			BTN_VIEW.Visible	= true;
			if (DDL_REPORT.SelectedValue=="OR")
				RB_OR.Visible	= true;
			else if (DDL_REPORT.SelectedValue=="SLA")
				RB_SLA.Visible	= true;
			else if (DDL_REPORT.SelectedValue=="PR")
				RB_PR.Visible	= true;
			else if (DDL_REPORT.SelectedValue=="CR")
				RB_CR.Visible	= true;
			else
				BTN_VIEW.Visible	= false;
		}

		protected void BTN_VIEW_Click(object sender, System.EventArgs e)
		{
			string link="";
			if (DDL_REPORT.SelectedValue=="OR")
				link	= RB_OR.SelectedValue.Trim();
			else if (DDL_REPORT.SelectedValue=="SLA")
				link	= RB_SLA.SelectedValue.Trim();
			else if (DDL_REPORT.SelectedValue=="PR")
				link	= RB_PR.SelectedValue.Trim();
			else if (DDL_REPORT.SelectedValue=="CR")
				link	= RB_CR.SelectedValue.Trim();
			//Tools.popMessage(this,link);
			if (link !="none")
				Response.Redirect(link);
		}
	}
}
