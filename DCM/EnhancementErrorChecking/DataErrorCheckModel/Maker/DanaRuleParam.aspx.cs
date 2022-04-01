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
	/// Summary description for DanaRuleParam.
	/// </summary>
	public partial class DanaRuleParam : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn2"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				ViewExisitingParameter();
				ViewRequestingParameter();
			}
		}

		private void ViewExisitingParameter()
		{
			BindData("DGR_DANA_RULE", "EXEC DCM_VIEW_RULE_EXIST_PARAMETER '" + Request.QueryString["type"] + "','" + Request.QueryString["code"] + "'");
		}

		private void ViewRequestingParameter()
		{
			BindData("DGR_DANA_RULE_REQ", "EXEC DCM_VIEW_RULE_REQUEST_PARAMETER '" + Request.QueryString["type"] + "','" + Request.QueryString["code"] + "'");
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

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
			this.DGR_DANA_RULE.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_DANA_RULE_ItemCommand);
			this.DGR_DANA_RULE.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_DANA_RULE_PageIndexChanged);
			this.DGR_DANA_RULE_REQ.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_DANA_RULE_REQ_ItemCommand);
			this.DGR_DANA_RULE_REQ.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_DANA_RULE_REQ_PageIndexChanged);

		}
		#endregion

		private void DGR_DANA_RULE_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_DANA_RULE.CurrentPageIndex = e.NewPageIndex;
			ViewExisitingParameter();
		}

		private void DGR_DANA_RULE_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					TXT_FIELD_CODE.Text			= e.Item.Cells[2].Text.ToString().Replace("&nbsp;","");
					TXT_FIELD_DESC.Text			= e.Item.Cells[3].Text.ToString().Replace("&nbsp;","");
					TXT_ERR_MSG.Text			= e.Item.Cells[4].Text.ToString().Replace("&nbsp;","");
					TEXT_VALIDATION_RULE.Text	= e.Item.Cells[5].Text.ToString().Replace("&nbsp;","");
					break;

				case "delete":
					conn.QueryString = "EXEC DCM_RULE_INSERT_PARAM 'DANA','" +
										e.Item.Cells[0].Text.ToString() + "','" +
										e.Item.Cells[1].Text.ToString() + "','" +
										e.Item.Cells[2].Text.ToString() + "','" +
										e.Item.Cells[3].Text.ToString() + "','" +
										e.Item.Cells[4].Text.ToString() + "','DELETE',0,'DELETE'";
					conn.ExecuteQuery();
					ViewExisitingParameter();
					ViewRequestingParameter();
					break;
			}
		}

		private void DGR_DANA_RULE_REQ_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_DANA_RULE_REQ.CurrentPageIndex = e.NewPageIndex;
			ViewRequestingParameter();
		}

		private void DGR_DANA_RULE_REQ_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit_req":
					TXT_FIELD_CODE.Text			= e.Item.Cells[2].Text.ToString().Replace("&nbsp;","");
					TXT_FIELD_DESC.Text			= e.Item.Cells[3].Text.ToString().Replace("&nbsp;","");
					TXT_ERR_MSG.Text			= e.Item.Cells[4].Text.ToString().Replace("&nbsp;","");
					TEXT_VALIDATION_RULE.Text	= e.Item.Cells[5].Text.ToString().Replace("&nbsp;","");
					break;

				case "delete_req":
					/*Change Table 'DCM_RF_DANA_RULE_TEMP' To 'DCM_RF_CIF_RULE_TEMP'*/
					conn.QueryString = "DELETE DCM_RF_CIF_RULE_TEMP WHERE DATA_TYPE = '" + e.Item.Cells[0].Text +
										"' AND RULE_ID = '" + e.Item.Cells[1].Text + "' AND DATA_FIELD = '" + e.Item.Cells[2].Text + "'";
					conn.ExecuteQuery();
					ViewRequestingParameter();
					break;
			}
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			if(TXT_FIELD_CODE.Text == "" || TXT_FIELD_CODE.Text == null || TXT_ERR_MSG.Text == "" || TXT_ERR_MSG.Text == null)
			{
				GlobalTools.popMessage(this, "Field Code & Error Message Tidak Boleh Kosong!");
				return;
			}
			else
			{
				try
				{
					/*Change Table 'DCM_RF_DANA_RULE' To 'DCM_RF_CIF_RULE'*/
					conn.QueryString = "SELECT * FROM DCM_RF_CIF_RULE WHERE DATA_TYPE = '" + Request.QueryString["type"] +
						"' AND RULE_ID = '" + Request.QueryString["code"] + "' AND DATA_FIELD = '" + TXT_FIELD_CODE.Text + "' AND IS_ACTIVE = '1'";
					conn.ExecuteQuery();

					string status = "";

					if(conn.GetRowCount() == 0)
					{
						status = "INSERT";
					}
					else
					{
						status = "UPDATE";
					}

					conn.QueryString = "EXEC DCM_RULE_INSERT_PARAM 'DANA','" +
										Request.QueryString["type"] + "','" +
										Request.QueryString["code"] + "','" +
										TXT_FIELD_CODE.Text + "','" +
										TXT_FIELD_DESC.Text + "','" +
										TXT_ERR_MSG.Text + "','" +
										TEXT_VALIDATION_RULE.Text + "',1,'" + status + "'";
					conn.ExecuteQuery();
				}
				catch(Exception ex)
				{
					string errmsg = ex.Message.Replace("'","");
					if(errmsg.IndexOf("Last Query:")>0)
					{
						errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));	
					}
					GlobalTools.popMessage(this, errmsg);
					return;
				}
			}
			ViewExisitingParameter();
			ViewRequestingParameter();

			ClearData();
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{
			TXT_FIELD_CODE.Text			= "";
			TXT_FIELD_DESC.Text			= "";
			TXT_ERR_MSG.Text			= "";
			TEXT_VALIDATION_RULE.Text	= "";
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("DanaRule.aspx?mc=" + Request.QueryString["mc"]);
		}
	}
}
