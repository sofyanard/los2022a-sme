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


namespace SME
{
	/// <summary>
	/// Summary description for PendingApplicationInfo.
	/// </summary>
	public partial class PendingApplicationInfo : System.Web.UI.Page
	{

		private Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack) 
			{
				bindData();
				bindMsg();
			}
		}

		private void bindData() 
		{
			conn.QueryString = "exec PENDINGAPPLICATIONLIST '" + (string) Session["UserID"] + "'";			
			conn.ExecuteQuery();

			DGR_PENDING.DataSource = conn.GetDataTable().DefaultView;
			try 
			{
				DGR_PENDING.DataBind();
			}
			catch {
				DGR_PENDING.CurrentPageIndex = 0;
				DGR_PENDING.DataBind();
			}
			
			/// Untuk menghitung jumlah kemunculan pesan pending aplikasi
			/// 
			Session.Add("pendingAppCount", 1);
		}

		private void bindMsg() 
		{
			conn.QueryString = "exec PENDINGMESSAGELIST '" + (string) Session["UserID"] + "'";			
			conn.ExecuteQuery();

			DGR_MSG.DataSource = conn.GetDataTable().DefaultView;
			try 
			{
				DGR_MSG.DataBind();
			}
			catch 
			{
				DGR_MSG.CurrentPageIndex = 0;
				DGR_MSG.DataBind();
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
