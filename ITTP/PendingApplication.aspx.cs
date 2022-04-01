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
namespace SME.ITTP
{
	/// <summary>
	/// Summary description for PendingApplication.
	/// </summary>
	public partial class PendingApplication : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		protected string groupUnit;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = new Connection(ConfigurationSettings.AppSettings["conn"]);

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack) 
			{
				//LBL_BR_CCOBRANCH.Text = getCCOBranch((string) Session["BranchID"]);
				LBL_TC.Text = Request.QueryString["tc"];
				//setTitle(Request.QueryString["mc"]);
				viewData();
				fillFindKriteria();
			}
		}

		private void fillFindKriteria() 
		{
			for(int i=0; i<DataGrid1.Columns.Count; i++) 
			{
				if (DataGrid1.Columns[i].Visible == true && DataGrid1.Columns[i].SortExpression != "") 
				{
					DDL_FIND_KRITERIA.Items.Add(new ListItem(DataGrid1.Columns[i].HeaderText, DataGrid1.Columns[i].SortExpression));
				}
			}
		}

		private void viewData() 
		{	
			try 
			{
				conn.QueryString = "select * from VW_IT_PENDINGLIST"; 
					//where "+ DDL_FIND_KRITERIA.SelectedValue + " LIKE '%" + TXT_FIND_KRITERIA.Text.Trim() + "%' ";
				conn.ExecuteQuery();
				FillGrid();
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error !");
				return;
			}
/*
			//--- bind data to datagrid
			DataGrid1.DataSource = new DataView(dt);
			try 
			{
				DataGrid1.DataBind();
			} 
			catch 
			{
				DataGrid1.CurrentPageIndex = 0;
				DataGrid1.DataBind();
			}
*/		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DataGrid1.DataSource = dt;
			try 
			{
				DataGrid1.DataBind();
			} 
			catch 
			{
				DataGrid1.CurrentPageIndex = 0;
				DataGrid1.DataBind();
			}
		}


		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string regno, curef;//, BS_COMPLETE, BS_BIASSIGN;
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "Continue":
					regno = e.Item.Cells[1].Text.Trim();
					curef = e.Item.Cells[0].Text.Trim();
					//BS_BIASSIGN = e.Item.Cells[7].Text.Trim();
					//BS_COMPLETE = e.Item.Cells[8].Text.Trim();
					Response.Redirect("InitiationMain.aspx?regno=" + regno + "&curef="+curef + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
						//&isassign=" + BS_BIASSIGN + "&iscomplete=" + BS_COMPLETE);
					break;
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);

		}
		#endregion

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			try 
			{
				conn.QueryString = "select * from VW_IT_PENDINGLIST where "+ DDL_FIND_KRITERIA.SelectedValue + " LIKE '%" + TXT_FIND_KRITERIA.Text.Trim() + "%' ";
				conn.ExecuteQuery();
				FillGrid();
			}
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error !");
				return;
			}
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			viewData();
		}

	}
}
