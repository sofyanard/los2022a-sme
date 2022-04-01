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
using DMS.DBConnection;
using DMS.CuBESCore;
using Microsoft.VisualBasic;


namespace SME.LKKN1
{
	
	public partial class LKKNBPrint : System.Web.UI.Page
	{
		
	
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
			
			
			string BRANCH = Request.QueryString["BRANCH"];
			string regno = Request.QueryString["regno"];
							
			
			this.PH1.Controls.Add(new LiteralControl("<iframe src='LKKNPrint.aspx?BRANCH=" + BRANCH + "&regno=" + regno +  
				"' id='framelkkn' frameborder='0' width=860 height=2600></iframe>"));			
		}
	}
}
