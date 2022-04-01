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

namespace SME
{
	/// <summary>
	/// Summary description for ProjectInfo.
	/// </summary>
	public partial class ProjectInfo : System.Web.UI.Page
	{
		private Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack) 
			{
				bindData();
			}
		}

		#region my method

		private void bindData() 
		{
			conn.QueryString = "select * from VW_PROJECTLIST order by " + TXT_SORTEXP.Text + " " + TXT_SORTTYPE.Text;
			conn.ExecuteQuery();

			DGR_PROJECT.DataSource = conn.GetDataTable().DefaultView;
			try 
			{
				DGR_PROJECT.DataBind();
			}
			catch 
			{
				DGR_PROJECT.CurrentPageIndex = 0;
				DGR_PROJECT.DataBind();
			}			
		}

		private void clearData()
		{
		}

		#endregion

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
			this.DGR_PROJECT.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DGR_PROJECT_SortCommand);

		}
		#endregion

		protected void btn_SEARCH_Click(object sender, System.EventArgs e)
		{
			conn.QueryString="EXEC PROJECTINFO_FIND '"+txt_NAMAPROYEK.Text+"','"+txt_REMAININGLIMIT_AWAL.Text+"','"+txt_REMAININGLIMIT_AKHIR.Text+"' ";
			conn.ExecuteQuery();
			DGR_PROJECT.DataSource = conn.GetDataTable().DefaultView;
			try 
			{
				DGR_PROJECT.DataBind();
			}
			catch 
			{
				DGR_PROJECT.CurrentPageIndex = 0;
				DGR_PROJECT.DataBind();
			}

		}

		protected void btn_CLEAR_Click(object sender, System.EventArgs e)
		{
			clearSearch();
		}

		private void clearSearch()
		{ 
			txt_NAMAPROYEK.Text ="";
			txt_REMAININGLIMIT_AWAL.Text ="";
			txt_REMAININGLIMIT_AKHIR.Text ="";

		}

		private void DGR_PROJECT_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			if (TXT_SORTTYPE.Text == "ASC")
				TXT_SORTTYPE.Text = "DESC";
			else
				TXT_SORTTYPE.Text = "ASC";
			TXT_SORTEXP.Text = e.SortExpression;
			
			bindData();
		}	
	}
}
