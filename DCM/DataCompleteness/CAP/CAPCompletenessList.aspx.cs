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
using System.Configuration;

namespace SME.DCM.DataCompleteness.CAP
{
	/// <summary>
	/// Summary description for CAPCompletenessList.
	/// </summary>
	public partial class CAPCompletenessList : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn2"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if(!IsPostBack)
			{
				FillGrid();
			}
		}

		private void FillGrid()
		{
			conn.QueryString = "SELECT * FROM VW_DCM_DATACOMPLETENESS_CAP_CAPCOMPLETENESSLIST";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			DGR_CIF_LIST.DataSource = dt;
			try
			{
				DGR_CIF_LIST.DataBind();
			}
			catch
			{
				DGR_CIF_LIST.CurrentPageIndex = 0;
				DGR_CIF_LIST.DataBind();
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
			this.DGR_CIF_LIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_CIF_LIST_ItemCommand);
			this.DGR_CIF_LIST.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_CIF_LIST_PageIndexChanged);

		}
		#endregion

		private void DGR_CIF_LIST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_CIF_LIST.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void DGR_CIF_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit_data":
					Response.Redirect("CIFDataComplet.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
					break;
				case "update_status":
					conn.QueryString = "UPDATE VW_DCM_DATACOMPLETENESS_CAP_CAPCOMPLETENESSLIST SET STATUS='0' WHERE CIF=" + e.Item.Cells[1] + "'";
					conn.ExecuteNonQuery();
					break;
			}
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			DGR_CIF_LIST.CurrentPageIndex = 0;
			SearchData();
		}

		private void SearchData()
		{
			string query = "";

			if(TXT_CIF.Text != "")
			{
				query += "AND CIF='" + TXT_CIF.Text + "'";
			}
			if(TXT_ACCOUNT.Text != "")
			{
				query += "AND ACCOUNT='" + TXT_ACCOUNT.Text + "'";
			}
			if(TXT_CUSTNAME.Text != "")
			{
				query += "AND CUST LIKE '%" + TXT_CUSTNAME.Text + "%'";
			}

			if(query != "")
			{
				conn.QueryString = "SELECT DISTINCT * FROM VW_DCM_DATACOMPLETENESS_CAP_CAPCOMPLETENESSLIST WHERE 1=1 " + query;
				conn.ExecuteQuery();
				FillGrid();
			}
			else
			{
				conn.QueryString = "SELECT DISTINCT * FROM VW_DCM_DATACOMPLETENESS_CAP_CAPCOMPLETENESSLIST WHERE 1=1 ";
				conn.ExecuteQuery();
				FillGrid();
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			TXT_CIF.Text = "";
			TXT_ACCOUNT.Text = "";
			TXT_CUSTNAME.Text = "";
		}
	}
}
