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
using System.Configuration;
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;

namespace SME.DCM.EnhancementErrorChecking.DataErrorCheckModel.Maker
{
	/// <summary>
	/// Summary description for AgunanRule.
	/// </summary>
	public partial class AgunanRule : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn2"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				BindData("DGR_AGUNAN_RULE","SELECT * FROM VW_DCM_AGUNAN_RULE_PARAM");
			}
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();

				System.Data.DataTable dt = new System.Data.DataTable();
				dt = conn.GetDataTable().Copy();

				System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);
				dg.DataSource = dt;

				try
				{
					dg.DataBind();
				}
				catch
				{
					dg.CurrentPageIndex = dg.PageCount - 1;	
					dg.DataBind();
				}

				conn.ClearData();
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
			this.DGR_AGUNAN_RULE.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_AGUNAN_RULE_ItemCommand);
			this.DGR_AGUNAN_RULE.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_AGUNAN_RULE_PageIndexChanged);

		}
		#endregion

		private void DGR_AGUNAN_RULE_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_AGUNAN_RULE.CurrentPageIndex = e.NewPageIndex;
			BindData("DGR_AGUNAN_RULE","SELECT * FROM VW_DCM_AGUNAN_RULE_PARAM");
		}

		private void DGR_AGUNAN_RULE_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					Response.Redirect("AgunanRuleParam.aspx?mc=" + Request.QueryString["mc"] + "&type=" + e.Item.Cells[0].Text + "&code=" + e.Item.Cells[1].Text);
					break;
			}
		}
	}
}
