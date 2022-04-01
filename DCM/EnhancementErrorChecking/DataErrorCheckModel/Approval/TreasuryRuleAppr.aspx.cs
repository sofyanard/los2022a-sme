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

namespace SME.DCM.EnhancementErrorChecking.DataErrorCheckModel.Approval
{
	/// <summary>
	/// Summary description for TreasuryRuleAppr.
	/// </summary>
	public partial class TreasuryRuleAppr : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn2"]);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if(!IsPostBack)
			{
				BindData("DGR_TREASURYRULE","SELECT * FROM VW_DCM_TREASURY_RULE_PARAMETER_TEMP");
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
			this.DGR_TREASURYRULE.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_TREASURYRULE_ItemCommand);
			this.DGR_TREASURYRULE.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_TREASURYRULE_PageIndexChanged);

		}
		#endregion

		private void DGR_TREASURYRULE_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_TREASURYRULE.CurrentPageIndex = e.NewPageIndex;
			BindData("DGR_TREASURYRULE","SELECT * FROM VW_DCM_TREASURY_RULE_PARAMETER_TEMP");
		}

		private void DGR_TREASURYRULE_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "allAccept":
					allAccept();
					break;
				case "allPending":
					allPending();
					break;
				case "allReject":
					allReject();
					break;
			}
		}

		private void allReject()
		{
			for (int i=0; i<DGR_TREASURYRULE.Items.Count; i++)
			{
				RadioButton reject = (RadioButton) DGR_TREASURYRULE.Items[i].FindControl("RDO_REJECT");
				reject.Checked = true;
				RadioButton accept = (RadioButton) DGR_TREASURYRULE.Items[i].FindControl("RDO_ACCEPT");
				accept.Checked = false;
				RadioButton pending = (RadioButton) DGR_TREASURYRULE.Items[i].FindControl("RDO_PENDING");
				pending.Checked = false;
			}
		}

		private void allAccept()
		{
			for (int i=0; i<DGR_TREASURYRULE.Items.Count; i++)
			{
				RadioButton accept = (RadioButton) DGR_TREASURYRULE.Items[i].FindControl("RDO_ACCEPT");
				accept.Checked = true;
				RadioButton reject = (RadioButton) DGR_TREASURYRULE.Items[i].FindControl("RDO_REJECT");
				reject.Checked = false;
				RadioButton pending = (RadioButton) DGR_TREASURYRULE.Items[i].FindControl("RDO_PENDING");
				pending.Checked = false;
			}
		}

		private void allPending()
		{
			for (int i=0; i<DGR_TREASURYRULE.Items.Count; i++)
			{
				RadioButton pending = (RadioButton) DGR_TREASURYRULE.Items[i].FindControl("RDO_PENDING");
				pending.Checked = true;
				RadioButton accept = (RadioButton) DGR_TREASURYRULE.Items[i].FindControl("RDO_ACCEPT");
				accept.Checked = false;
				RadioButton reject = (RadioButton) DGR_TREASURYRULE.Items[i].FindControl("RDO_REJECT");
				reject.Checked = false;
			}
		}

		protected void BTN_SUB_Click(object sender, System.EventArgs e)
		{
			for (int i=0; i<DGR_TREASURYRULE.Items.Count; i++)
			{
				RadioButton pending = (RadioButton) DGR_TREASURYRULE.Items[i].FindControl("RDO_PENDING");
				RadioButton accept = (RadioButton) DGR_TREASURYRULE.Items[i].FindControl("RDO_ACCEPT");
				RadioButton reject = (RadioButton) DGR_TREASURYRULE.Items[i].FindControl("RDO_REJECT");

				if(pending.Checked == true)
				{
					continue;	
				}
				else if(accept.Checked == true)
				{
					conn.QueryString = "EXEC DCM_ERROR_CHECKING_RULE_PARAMETER '" +
										DGR_TREASURYRULE.Items[i].Cells[0].Text.ToString() + "','" +
										DGR_TREASURYRULE.Items[i].Cells[1].Text.ToString() + "','" +
										DGR_TREASURYRULE.Items[i].Cells[2].Text.ToString() + "','TREASURY','ACCEPT'";
					conn.ExecuteQuery();
				}
				else if(reject.Checked == true)
				{
					conn.QueryString = "EXEC DCM_ERROR_CHECKING_RULE_PARAMETER '" +
										DGR_TREASURYRULE.Items[i].Cells[0].Text.ToString() + "','" +
										DGR_TREASURYRULE.Items[i].Cells[1].Text.ToString() + "','" +
										DGR_TREASURYRULE.Items[i].Cells[2].Text.ToString() + "','TREASURY','REJECT'";
					conn.ExecuteQuery();
				}
			}

			BindData("DGR_TREASURYRULE","SELECT * FROM VW_DCM_TREASURY_RULE_PARAMETER_TEMP");
		}
	}
}
