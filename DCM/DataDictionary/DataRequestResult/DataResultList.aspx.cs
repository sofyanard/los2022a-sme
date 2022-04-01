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

namespace SME.DCM.DataDictionary.DataRequestResult
{
	/// <summary>
	/// Summary description for DataResultList.
	/// </summary>
	public partial class DataResultList : System.Web.UI.Page
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
			conn.QueryString = "SELECT * FROM VW_DD_DATA_REQUEST_RESULT_LIST WHERE REQ_PIC = '" + Session["USERID"] + "'";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			DGR_RESULT.DataSource = dt;
			try
			{
				DGR_RESULT.DataBind();
			}
			catch
			{
				DGR_RESULT.CurrentPageIndex = 0;
				DGR_RESULT.DataBind();
			}
			for (int i = 0; i < DGR_RESULT.Items.Count; i++)
			{
				DGR_RESULT.Items[i].Cells[2].Text = tools.FormatDate(DGR_RESULT.Items[i].Cells[2].Text, true);
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
			this.DGR_RESULT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_RESULT_ItemCommand);
			this.DGR_RESULT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_RESULT_PageIndexChanged);

		}
		#endregion

		private void DGR_RESULT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_RESULT.CurrentPageIndex = e.NewPageIndex;
			FillDataGrid();
		}

		private void DGR_RESULT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					Response.Redirect("GeneralInfoResult.aspx?sta=exist&mc=" + Request.QueryString["mc"] + "&regno=" + e.Item.Cells[1].Text + "&exist=1");
					break;
			}
		}
	}
}
