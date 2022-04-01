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

namespace SME.DCM.EnhancementErrorChecking.ValidateProcess
{
	/// <summary>
	/// Summary description for CIF.
	/// </summary>
	public partial class CIF : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
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
			conn.QueryString = "SELECT * FROM VW_DCM_RF_CIF_RULE";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			DGR_CIF_VALIDATION.DataSource = dt;
			try
			{
				DGR_CIF_VALIDATION.DataBind();
			}
			catch
			{
				DGR_CIF_VALIDATION.CurrentPageIndex = 0;
				DGR_CIF_VALIDATION.DataBind();
			}

			for(int i = 0; i < DGR_CIF_VALIDATION.Items.Count; i++)
			{
				Button btn_process = (Button)DGR_CIF_VALIDATION.Items[i].Cells[2].FindControl("BTN_PROCESS");
				btn_process.Visible = true;
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
			this.DGR_CIF_VALIDATION.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_CIF_VALIDATION_ItemCommand);
			this.DGR_CIF_VALIDATION.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_CIF_VALIDATION_PageIndexChanged);

		}
		#endregion

		private void DGR_CIF_VALIDATION_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_CIF_VALIDATION.CurrentPageIndex = e.NewPageIndex;
			FillGrid();
		}

		private void DGR_CIF_VALIDATION_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((Button)e.CommandSource).CommandName)
			{
				case "process":
					/*
					 * Prosedur untuk melakukan checking validation process 
					 */
					try
					{
						conn.QueryString = "EXEC DCM_VALIDATION_PROCESS '" + e.Item.Cells[0].Text + "','01'";
						conn.ExecuteQuery();
					}
					catch(Exception ex)
					{
						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						return;
					}
				break;
			}
		}
	}
}
