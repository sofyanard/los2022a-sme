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
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.Facilities
{
	/// <summary>
	/// Summary description for PerformanceAccountDetail.
	/// </summary>
	public partial class PerformanceAccountDetail : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				ViewDataAccount();
				ViewDataCustRating();
				ViewDataFacRating();
				ViewDataWatchlist();
			}
		}

		private void ViewDataAccount()
		{
			try 
			{
				conn.QueryString = "SELECT * FROM VW_PERFORMANCEACCOUNTDETAIL_VIEWACCOUNT WHERE CU_REF = '" + Request.QueryString["curef"] + 
					"' ORDER BY ACC_NO";
				conn.ExecuteQuery();
			
				DataTable dt = new DataTable();
				dt = conn.GetDataTable().Copy();
				DG_ACC.DataSource = dt;
				try 
				{
					DG_ACC.DataBind();
				} 
				catch 
				{
					DG_ACC.CurrentPageIndex = 0;
					DG_ACC.DataBind();
				}
			} 
			catch (Exception ex) 
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		private void ViewDataCustRating()
		{
			try 
			{
				conn.QueryString = "SELECT * FROM VW_PERFORMANCEACCOUNTDETAIL_VIEWCUSTRATING WHERE CU_REF = '" + Request.QueryString["curef"] + 
					"' ORDER BY RATING_DATE";
				conn.ExecuteQuery();
			
				DataTable dt = new DataTable();
				dt = conn.GetDataTable().Copy();
				DG_CUCTRTG.DataSource = dt;
				try 
				{
					DG_CUCTRTG.DataBind();
				} 
				catch 
				{
					DG_CUCTRTG.CurrentPageIndex = 0;
					DG_CUCTRTG.DataBind();
				}
			} 
			catch (Exception ex) 
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		private void ViewDataFacRating()
		{
			try 
			{
				conn.QueryString = "SELECT * FROM VW_PERFORMANCEACCOUNTDETAIL_VIEWFACRATING WHERE CU_REF = '" + Request.QueryString["curef"] + 
					"' ORDER BY RATING_DATE";
				conn.ExecuteQuery();
			
				DataTable dt = new DataTable();
				dt = conn.GetDataTable().Copy();
				DG_FACRTG.DataSource = dt;
				try 
				{
					DG_FACRTG.DataBind();
				} 
				catch 
				{
					DG_FACRTG.CurrentPageIndex = 0;
					DG_FACRTG.DataBind();
				}
			} 
			catch (Exception ex) 
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		private void ViewDataWatchlist()
		{
			try 
			{
				conn.QueryString = "SELECT * FROM VW_PERFORMANCEACCOUNTDETAIL_VIEWWATCHLIST WHERE CU_REF = '" + Request.QueryString["curef"] + 
					"' ORDER BY LMS_RECVDATE";
				conn.ExecuteQuery();
			
				DataTable dt = new DataTable();
				dt = conn.GetDataTable().Copy();
				DG_WATCH.DataSource = dt;
				try 
				{
					DG_WATCH.DataBind();
				} 
				catch 
				{
					DG_WATCH.CurrentPageIndex = 0;
					DG_WATCH.DataBind();
				}
			} 
			catch (Exception ex) 
			{
				Response.Write("<!--" + ex.Message + "-->");
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
			this.DG_ACC.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_ACC_PageIndexChanged);
			this.DG_CUCTRTG.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_CUCTRTG_PageIndexChanged);
			this.DG_FACRTG.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_FACRTG_PageIndexChanged);
			this.DG_WATCH.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_WATCH_PageIndexChanged);

		}
		#endregion

		private void DG_ACC_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_ACC.CurrentPageIndex = e.NewPageIndex;
			ViewDataAccount();
		}

		private void DG_CUCTRTG_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_CUCTRTG.CurrentPageIndex = e.NewPageIndex;
			ViewDataCustRating();
		}

		private void DG_FACRTG_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_FACRTG.CurrentPageIndex = e.NewPageIndex;
			ViewDataFacRating();
		}

		private void DG_WATCH_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_WATCH.CurrentPageIndex = e.NewPageIndex;
			ViewDataWatchlist();
		}
	}
}
