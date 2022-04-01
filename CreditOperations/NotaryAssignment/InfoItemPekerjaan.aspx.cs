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

namespace SME.CreditOperations.NotaryAssignment
{
	/// <summary>
	/// Summary description for InfoItemPekerjaan.
	/// </summary>
	public partial class InfoItemPekerjaan : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			ViewData();
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM VW_INFO_ITEMPEKERJAAN";
			conn.ExecuteQuery();

			DataTable dtdet = new DataTable();
			dtdet = conn.GetDataTable().Copy();

			DG_PROCESS.DataSource = dtdet;
			try 
			{
				DG_PROCESS.DataBind();
			} 
			catch 
			{
				DG_PROCESS.CurrentPageIndex = 0;
				DG_PROCESS.DataBind();
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
