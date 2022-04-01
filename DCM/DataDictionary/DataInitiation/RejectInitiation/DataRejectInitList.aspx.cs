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

namespace SME.DCM.DataDictionary.DataInitiation.RejectInitiation
{
	/// <summary>
	/// Summary description for DataRejectInitList.
	/// </summary>
	public partial class DataRejectInitList : System.Web.UI.Page
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
			conn.QueryString = "SELECT * FROM VW_DD_DATA_REJECT_INITIATION_LIST";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			DGR_REJECT.DataSource = dt;
			try
			{
				DGR_REJECT.DataBind();
			}
			catch
			{
				DGR_REJECT.CurrentPageIndex = 0;
				DGR_REJECT.DataBind();
			}
			for (int i = 0; i < DGR_REJECT.Items.Count; i++)
			{
				DGR_REJECT.Items[i].Cells[2].Text = tools.FormatDate(DGR_REJECT.Items[i].Cells[2].Text, true);
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
			this.DGR_REJECT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_REJECT_ItemCommand);
			this.DGR_REJECT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_REJECT_PageIndexChanged);

		}
		#endregion

		private void DGR_REJECT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_REJECT.CurrentPageIndex = e.NewPageIndex;
			FillDataGrid();
		}

		private void DGR_REJECT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					Response.Redirect("GeneralInformationIn.aspx?sta=exist&mc=" + Request.QueryString["mc"] + "&regno=" + e.Item.Cells[1].Text + "&exist=1");
					break;
			}
		}
	}
}
