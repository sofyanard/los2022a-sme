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
using DMS.DBConnection;
using DMS.CuBESCore;
using Microsoft.VisualBasic;

namespace SME.HDRS
{
	/// <summary>
	/// Summary description for PendingList.
	/// </summary>
	public partial class PendingList : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				conn.QueryString = "select a.groupid, b.sg_grpname from grpaccessmenu a left join scgroup b on a.groupid=b.groupid where a.menucode like 'b02'" ;
				conn.ExecuteQuery();
				DDL_PIC2.Items.Add(new ListItem("--Pilih--",""));				
				for (int i=0; i < conn.GetRowCount(); i++)
					DDL_PIC2.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));	

				conn.QueryString = "select * from VW_HELPDESK_PENDING_LIST WHERE ACTIVE='0'";
				conn.ExecuteQuery();
				FillGrid();
			}
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_PROBLEM.DataSource = dt;
			try 
			{
				DGR_PROBLEM.DataBind();
			} 
			catch 
			{
				DGR_PROBLEM.CurrentPageIndex = 0;
				DGR_PROBLEM.DataBind();
			}
		}

		private void SearchData()
		{
			string query1=""; 
			
			if(TXT_HRS.Text!="")
			{
				query1 += "and H_HRS# LIKE '%" + TXT_HRS.Text + "%' ";				
			}
			if(TXT_AP.Text!="")
			{
				query1 += "and H_APP#='" + TXT_AP.Text + "' ";				
			}
			if(TXT_CUST.Text!="")
			{
				query1 += "and H_CUSTOMER LIKE '%" + TXT_CUST.Text + "%' ";				
			}

			if(DDL_PIC2.SelectedValue!="")
			{
				query1 += "and GROUPID='" + DDL_PIC2.SelectedValue + "' ";				
			}

			conn.QueryString = "select * from VW_HELPDESK_PENDING_LIST where ACTIVE='0' " + query1;
			conn.ExecuteQuery();
			FillGrid();
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
			this.DGR_PROBLEM.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_PROBLEM_ItemCommand);
			this.DGR_PROBLEM.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_PROBLEM_PageIndexChanged);

		}
		#endregion

		private void DGR_PROBLEM_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":					
					Response.Redirect("PicAssignment.aspx?sta=exist&regnum=" + e.Item.Cells[0].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
									
					break;
			}
		}

		private void DGR_PROBLEM_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_PROBLEM.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			DGR_PROBLEM.CurrentPageIndex = 0;
			SearchData();
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			TXT_HRS.Text = "";
			TXT_AP.Text = "";
			TXT_CUST.Text = "";			
		}
	}
}
