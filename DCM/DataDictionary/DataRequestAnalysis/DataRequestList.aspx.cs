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
using System.Configuration;

namespace SME.DCM.DataDictionary.DataRequestAnalysis
{
	/// <summary>
	/// Summary description for DataRequestList.
	/// </summary>
	public partial class DataRequestList : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				FillDataGrid();
			}
		}

		private void FillDataGrid()
		{
			conn.QueryString = "SELECT * FROM VW_DD_DATA_REQUEST_ANALYST_LIST WHERE DSO_PIC = '" + Session["UserID"] + "'";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			DGR_ANALYST.DataSource = dt;
			try
			{
				DGR_ANALYST.DataBind();
			}
			catch
			{
				DGR_ANALYST.CurrentPageIndex = 0;
				DGR_ANALYST.DataBind();
			}
			for (int i = 0; i < DGR_ANALYST.Items.Count; i++)
			{
				DGR_ANALYST.Items[i].Cells[2].Text = tools.FormatDate(DGR_ANALYST.Items[i].Cells[2].Text, true);
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
			this.DGR_ANALYST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_ANALYST_ItemCommand);
			this.DGR_ANALYST.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_ANALYST_PageIndexChanged);

		}
		#endregion

		private void DGR_ANALYST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_ANALYST.CurrentPageIndex = e.NewPageIndex;
			FillDataGrid();
		}

		private void DGR_ANALYST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "continue":
					conn.QueryString = "UPDATE DD_DATA_REQUEST SET DATA_FLAG = '2' WHERE REQ_NUMBER = '" + e.Item.Cells[1].Text + "'";
					conn.ExecuteQuery();

					Response.Redirect("AnalysisGeneralInfo.aspx?sta=exist&mc=" + Request.QueryString["mc"] + "&regno=" + e.Item.Cells[1].Text + "&exist=1");
					break;
			}
		}
	}
}
