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
using Microsoft.VisualBasic;
using System.Configuration;

namespace SME.DCM.DataCorrectionRequir
{
	/// <summary>
	/// Summary description for CollateralCorrectionList.
	/// </summary>
	public partial class CollateralCorrectionList : System.Web.UI.Page
	{
		protected Connection conn;
		protected Connection2 conn2;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			conn2 = new Connection2(ConfigurationSettings.AppSettings["conn2"]);

			if (!IsPostBack)
			{
				FillDDLBUC();
				FillDDLBranch();

				conn2.QueryString = "EXEC DRC_COLLATERAL_LIST_DATA '"+ 
									Session["GroupID"].ToString() + "', '" +
									TXT_CIF_NO.Text + "', '" +
									TXT_ID.Text + "', '" +
									TXT_CUST_NAME.Text + "', '" +
									DDL_BUC.SelectedValue + "', '" +
									DDL_BRANCH.SelectedValue + "' ";
				conn2.ExecuteQuery();
				FillGrid();				
			}
		}

		private void FillDDLBUC()
		{
			DDL_BUC.Items.Clear();
			DDL_BUC.Items.Add(new ListItem("--Pilih--", ""));

			conn.QueryString = "SELECT DEPT_CODE, DEPT_DESC FROM RFDEPARTMENTCODE WHERE ACTIVE = '1'";
			conn.ExecuteQuery();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_BUC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLBranch()
		{
			DDL_BRANCH.Items.Clear();
			DDL_BRANCH.Items.Add(new ListItem("--Pilih--", ""));

			conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH WHERE ACTIVE = '1'";
			conn.ExecuteQuery();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_BRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn2.GetDataTable().Copy();
			DGR_COLLATERAL_LIST.DataSource = dt;
			try 
			{
				DGR_COLLATERAL_LIST.DataBind();
			} 
			catch 
			{
				DGR_COLLATERAL_LIST.CurrentPageIndex = 0;
				DGR_COLLATERAL_LIST.DataBind();
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
			this.DGR_COLLATERAL_LIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_COLLATERAL_LIST_ItemCommand);
			this.DGR_COLLATERAL_LIST.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_COLLATERAL_LIST_PageIndexChanged);

		}
		#endregion

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			conn2.QueryString = "EXEC DRC_COLLATERAL_LIST_DATA '"+ 
								Session["GroupID"].ToString() + "', '" +
								TXT_CIF_NO.Text + "', '" +
								TXT_ID.Text + "', '" +
								TXT_CUST_NAME.Text + "', '" +
								DDL_BUC.SelectedValue + "', '" +
								DDL_BRANCH.SelectedValue + "' ";
			conn2.ExecuteQuery();
			FillGrid();
		}

		private void DGR_COLLATERAL_LIST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_COLLATERAL_LIST.CurrentPageIndex = e.NewPageIndex;
			conn2.QueryString = "EXEC DRC_COLLATERAL_LIST_DATA '"+ 
								Session["GroupID"].ToString() + "', '" +
								TXT_CIF_NO.Text + "', '" +
								TXT_ID.Text + "', '" +
								TXT_CUST_NAME.Text + "', '" +
								DDL_BUC.SelectedValue + "', '" +
								DDL_BRANCH.SelectedValue + "' ";
			conn2.ExecuteQuery();
			FillGrid();
		}

		private void DGR_COLLATERAL_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Edit":
					if (e.Item.Cells[5].Text=="DEP")
					{
						Response.Redirect("CashCollateralDEP.aspx?sta=exist&collid=" + e.Item.Cells[4].Text + "&tc=" + Request.QueryString["tc"] + "&from_appr=0");
					}
					if (e.Item.Cells[5].Text=="VEH")
					{
						Response.Redirect("BarangBergerakVEH.aspx?sta=exist&collid=" + e.Item.Cells[4].Text + "&tc=" + Request.QueryString["tc"] + "&from_appr=1");
					}
					if (e.Item.Cells[5].Text=="RE" || e.Item.Cells[5].Text=="VEH - Mesin" )
					{
						Response.Redirect("BarangTakBergerakVEH.aspx?sta=exist&collid=" + e.Item.Cells[4].Text + "&tc=" + Request.QueryString["tc"] + "&from_appr=1");
					}
					if (e.Item.Cells[5].Text=="INV")
					{
						Response.Redirect("PersediaanBarangINV.aspx?sta=exist&collid=" + e.Item.Cells[4].Text + "&tc=" + Request.QueryString["tc"] + "&from_appr=1");
					}
					if (e.Item.Cells[5].Text=="PG" || e.Item.Cells[5].Text=="CG" || e.Item.Cells[5].Text=="BOND" || e.Item.Cells[5].Text=="LC")
					{
						Response.Redirect("LainnyaPG.aspx?sta=exist&collid=" + e.Item.Cells[4].Text + "&tc=" + Request.QueryString["tc"] + "&from_appr=1");
					}
					if (e.Item.Cells[5].Text=="STOCK")
					{
						Response.Redirect("SuratBerhargaStock.aspx?sta=exist&collid=" + e.Item.Cells[4].Text + "&tc=" + Request.QueryString["tc"] + "&from_appr=1");
					}
					if (e.Item.Cells[5].Text=="PNCHQ" || e.Item.Cells[5].Text=="AR" )
					{
						Response.Redirect("CollateralListDataApp.aspx?sta=exist&collid=" + e.Item.Cells[4].Text + "&tc=" + Request.QueryString["tc"] + "&from_appr=2");
					}
					break;
			}
		}
	}
}
