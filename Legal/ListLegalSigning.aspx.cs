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


namespace SME.Legal
{
	/// <summary>
	/// Summary description for LegalSigning.
	/// </summary>
	public partial class LegalSigning : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SME;uid=sa;pwd=");
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			if (!IsPostBack)
			{
				LBL_TC.Text = Request.QueryString["tc"];
				ViewData();
			}
			// Munculkan pesan next step
			if (Request.QueryString["msg"] != "" && Request.QueryString["msg"] != null) 
				GlobalTools.popMessage(this, Request.QueryString["msg"]);

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
			this.DGR_LIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_LIST_ItemCommand);

		}
		#endregion

		private void ViewData()
		{
			conn.QueryString = "select distinct VW.* "+
				"from VW_LISTCUST VW ";
			conn.ExecuteQuery();
			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_LIST.DataSource = data;
			DGR_LIST.DataBind();
		}

		private void DGR_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// *** VIEW APPRAISAL ***
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "undo":
					break;
				case "view":
					Response.Redirect("MainLegalSigning.aspx?regno="+ e.Item.Cells[1].Text +"&curef="+ e.Item.Cells[2].Text +"&tc="+ LBL_TC.Text);
					break;
			}
		}
	}
}
