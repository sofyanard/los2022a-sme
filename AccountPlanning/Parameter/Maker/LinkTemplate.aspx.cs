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

namespace SME.AccountPlanning.Parameter.Maker
{
	/// <summary>
	/// Summary description for LinkTemplate.
	/// </summary>
	public partial class LinkTemplate : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				FillDDLProduct();
				FillDDLTemplate();
				FillDDLField();
			}
			FillGridExist();
		}

		private void FillDDLProduct()
		{
			DDL_PRODUCT_ID.Items.Clear();
			DDL_PRODUCT_ID.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_AP_PRODUCT_DEAL_ANALYZER";
			conn.ExecuteQuery();
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_PRODUCT_ID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLTemplate()
		{
			DDL_TEMPLATE_ID.Items.Clear();
			DDL_TEMPLATE_ID.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_AP_PRODUCT_TYPE";
			conn.ExecuteQuery();
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_TEMPLATE_ID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		protected void DDL_TEMPLATE_ID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillDDLField();
		}

		private void FillDDLField()
		{
			DDL_FIELD_ID.Items.Clear();
			DDL_FIELD_ID.Items.Add(new ListItem("--Select--", ""));

			if(DDL_TEMPLATE_ID.SelectedValue == "")
			{
				conn.QueryString = "SELECT PRODUCTID, PRODUCT_NM FROM VW_AP_PRODUCT_NAME ORDER BY CONVERT(INT, PRODUCTID)";
				conn.ExecuteQuery();
			}
			else
			{
				conn.QueryString = "SELECT PRODUCTID, PRODUCT_NM FROM VW_AP_PRODUCT_NAME ORDER BY CONVERT(INT, PRODUCTID) WHERE CATEGORYID = '" + DDL_TEMPLATE_ID.SelectedValue + "'";
				conn.ExecuteQuery();
			}

			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_FIELD_ID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillGridExist()
		{
			conn.QueryString = "SELECT * FROM AP_QUERY_DEAL_ANALYZER WHERE ACTIVE = '1'";
			BindData(DGR_LINK_TEMPLATE_EXIST.ID.ToString(), conn.QueryString);
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

		private void DGR_LINK_TEMPLATE_EXIST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_LINK_TEMPLATE_EXIST.CurrentPageIndex = e.NewPageIndex;
			FillGridExist();
		}

		private void DGR_LINK_TEMPLATE_EXIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					conn.QueryString = "SELECT * FROM AP_QUERY_DEAL_ANALYZER WHERE SEQ = '" + e.Item.Cells[0].Text.Trim() + "' AND ACTIVE = '1'";
					conn.ExecuteQuery();

					LBL_SEQ.Text				= e.Item.Cells[0].Text.Trim();
					DDL_PRODUCT_ID.SelectedValue	= conn.GetFieldValue("PRODUCTID").ToString();
					DDL_TEMPLATE_ID.SelectedValue	= conn.GetFieldValue("ID_TEMPLATE").ToString();
					DDL_FIELD_ID.SelectedValue		= conn.GetFieldValue("FIELD").ToString();
					TXT_QUERY.Text					= conn.GetFieldValue("QUERY").ToString().Replace("&nbsp;","");
					break;

				case "delete":
					conn.QueryString="DELETE AP_QUERY_DEAL_ANALYZER WHERE SEQ = '" + e.Item.Cells[0].Text.Trim() + "'";
					conn.ExecuteQuery();

					FillGridExist();
					break;
			}
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if(DDL_PRODUCT_ID.SelectedValue != "")
			{
				try
				{
					conn.QueryString = "EXEC AP_LINK_TEMPLATE_INSERT '" +
										LBL_SEQ.Text + "','" +
										DDL_PRODUCT_ID.SelectedValue + "','" +
										DDL_TEMPLATE_ID.SelectedValue + "','" +
										DDL_FIELD_ID.SelectedValue + "','" +
										TXT_QUERY.Text + "'";
					conn.ExecuteQuery();
				}
				catch (Exception ex)
				{
					string errmsg = ex.Message.Replace("'","");
					if (errmsg.IndexOf("Last Query:") > 0)
						errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
					GlobalTools.popMessage(this, errmsg);
					return;
				}
			}
			else
			{
				GlobalTools.popMessage(this, "Check Field Mandatory!");
				return;
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			DDL_PRODUCT_ID.SelectedValue	= "";
			DDL_TEMPLATE_ID.SelectedValue	= "";
			DDL_FIELD_ID.SelectedValue		= "";
			TXT_QUERY.Text					= "";
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../AccountPlanningParam.aspx?mc=" + Request.QueryString["mc"]);
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
			this.DGR_LINK_TEMPLATE_EXIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_LINK_TEMPLATE_EXIST_ItemCommand);
			this.DGR_LINK_TEMPLATE_EXIST.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_LINK_TEMPLATE_EXIST_PageIndexChanged);

		}
		#endregion
	}
}
