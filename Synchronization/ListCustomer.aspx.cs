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
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.Synchronization
{
	/// <summary>
	/// Summary description for ListCustomer.
	/// </summary>
	public partial class ListCustomer : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				ViewDataSync();
			}
		}

		private void SearchCust()
		{
			if ((TXT_AP_REGNO.Text.Trim() == "") && (TXT_CU_CIF.Text.Trim() == "") && (TXT_NAME.Text.Trim().Length < 3))
			{
				return;
			}

			string qry = "SELECT DISTINCT CU_REF, CU_CIF, CU_NAME, CU_IDNO, CU_NPWP " +
				"FROM VW_EMASSYNC_SEARCHCUST WHERE 1=1 ";
			if (TXT_AP_REGNO.Text.Trim() != "")
				qry = qry + "AND AP_REGNO = '" + TXT_AP_REGNO.Text.Trim() + "' ";
			if (TXT_CU_CIF.Text.Trim() != "")
				qry = qry + "AND CU_CIF = '" + TXT_CU_CIF.Text.Trim() + "' ";
			if (TXT_NAME.Text.Trim() != "")
				qry = qry + "AND CU_NAME LIKE '%" + TXT_NAME.Text.Trim() + "%' ";
			qry = qry + "ORDER BY CU_CIF, CU_NAME";

			conn.QueryString = qry;
			conn.ExecuteQuery();
			
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_CUST.DataSource = dt;
			try 
			{
				DG_CUST.DataBind();
			} 
			catch 
			{
				DG_CUST.CurrentPageIndex = 0;
				DG_CUST.DataBind();
			}
		}

		private void ViewDataApp(string apregno)
		{
			conn.QueryString = "SELECT * FROM VW_EMASSYNC_VIEWDATAAPP WHERE CU_REF = '" + LBL_CUREF.Text + "'";
			conn.ExecuteQuery();
			
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_APP.DataSource = dt;
			try 
			{
				DG_APP.DataBind();
			} 
			catch 
			{
				DG_APP.CurrentPageIndex = 0;
				DG_APP.DataBind();
			}
		}

		private void ViewDataSync()
		{
			conn.QueryString = "SELECT * FROM VW_EMASSYNC_VIEWDATASYNC";
			conn.ExecuteQuery();
			
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_SYNC.DataSource = dt;
			try 
			{
				DG_SYNC.DataBind();
			} 
			catch 
			{
				DG_SYNC.CurrentPageIndex = 0;
				DG_SYNC.DataBind();
			}
		}

		private void ClearEntry()
		{
			TXT_AP_REGNO.Text = "";
			TXT_CU_CIF.Text = "";
			TXT_NAME.Text = "";
			LBL_CUREF.Text = "";
			DG_CUST.DataSource = null;
			DG_CUST.DataBind();
			DG_APP.DataSource = null;
			DG_APP.DataBind();
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
			this.DG_APP.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_APP_ItemCommand);
			this.DG_APP.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_APP_PageIndexChanged);
			this.DG_SYNC.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_SYNC_ItemCommand);
			this.DG_SYNC.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_SYNC_PageIndexChanged);
			this.DG_CUST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_CUST_ItemCommand);
			this.DG_CUST.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_CUST_PageIndexChanged);

		}
		#endregion

		private void DG_CUST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
					LBL_CUREF.Text = e.Item.Cells[0].Text;
					ViewDataApp(e.Item.Cells[0].Text);
					break;
			}
		}

		private void DG_CUST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_CUST.CurrentPageIndex = e.NewPageIndex;
			SearchCust();
		}

		private void DG_APP_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "Add":
					try
					{
						conn.QueryString = "exec EMASSYNC_ADDAPP '" +
							e.Item.Cells[0].Text.Trim() + "', '" + 
							e.Item.Cells[1].Text.Trim() + "', '" + 
							Session["UserID"].ToString() + "'";
						conn.ExecuteQuery();

						ViewDataSync();
					}
					catch (Exception ex)
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

		private void DG_APP_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_APP.CurrentPageIndex = e.NewPageIndex;
			ViewDataApp(LBL_CUREF.Text);
		}

		private void DG_SYNC_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "Delete":
					try
					{
						conn.QueryString = "exec EMASSYNC_DELAPP '" +
							e.Item.Cells[0].Text.Trim() + "', '" + 
							e.Item.Cells[1].Text.Trim() + "', '" + 
							Session["UserID"].ToString() + "'";
						conn.ExecuteQuery();

						ViewDataSync();
					}
					catch (Exception ex)
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

		private void DG_SYNC_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_SYNC.CurrentPageIndex = e.NewPageIndex;
			ViewDataSync();
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearEntry();
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			SearchCust();
		}
	}
}
