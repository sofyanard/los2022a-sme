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

namespace SME.DCM
{
	/// <summary>
	/// Summary description for LoanListDataBU.
	/// </summary>
	public partial class LoanListDataBU : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				if(Request.QueryString["msg"]!="" && Request.QueryString["msg"] != null)
				{
					GlobalTools.popMessage(this, Request.QueryString["msg"]);
				}

				fillWilayah();
				fillKelompok();
				DDL_UNIT_KERJA.Items.Add(new ListItem("-- PILIH --",""));

				conn2.QueryString = "select top 0 * from perkreditan";
				conn2.ExecuteQuery();
				FillGrid();

				SearchData();
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
			this.DGR_LOANBU_LIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_LOANBU_LIST_ItemCommand);
			this.DGR_LOANBU_LIST.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_LOANBU_LIST_PageIndexChanged);

		}
		#endregion

		private void fillWilayah()
		{
			DDL_WILAYAH.Items.Clear();
			DDL_WILAYAH.Items.Add(new ListItem("-- PILIH --",""));
			conn.QueryString = "select AREAID, AREANAME from rfarea where active ='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_WILAYAH.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}	
		}

		private void fillKelompok()
		{
			DDL_SEGMENT.Items.Clear();
			DDL_SEGMENT.Items.Add(new ListItem("-- PILIH --",""));
			conn.QueryString = "select bussunitid, bussunitdesc from rfbusinessunit order by bussunitid ";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_SEGMENT.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
		}

		private void fillUnit() 
		{
			DDL_UNIT_KERJA.Items.Clear();
			DDL_UNIT_KERJA.Items.Add(new ListItem("-- PILIH --",""));

			if (DDL_SEGMENT.SelectedValue=="")
			{
				conn.QueryString = "select DEPT_CODE, DEPT_DESC from  rfdepartmentcode order by dept_desc";
			}
			else
			{
				conn.QueryString = "select DEPT_CODE, DEPT_DESC from  rfdepartmentcode where BUSSUNITID='"+DDL_SEGMENT.SelectedValue+"'order by dept_desc";
			}

			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_UNIT_KERJA.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}			
		}

		protected void BTN_LIHAT_Click(object sender, System.EventArgs e)
		{
			DGR_LOANBU_LIST.CurrentPageIndex = 0;
			SearchData();
		}

		private void SearchData()
		{
			conn2.QueryString = "EXEC DQM_LOAN_BU_SEARCH '" + DDL_WILAYAH.SelectedValue +
				"', '" + DDL_UNIT_KERJA.SelectedValue + "', '" + DDL_SEGMENT.SelectedValue + "'";
			conn2.ExecuteQuery();
			FillGrid();
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn2.GetDataTable().Copy();
			DGR_LOANBU_LIST.DataSource = dt;
			try 
			{
				DGR_LOANBU_LIST.DataBind();
			} 
			catch 
			{
				DGR_LOANBU_LIST.CurrentPageIndex = 0;
				DGR_LOANBU_LIST.DataBind();
			}

			LinkButton lnk;

			for (int i = 0; i < DGR_LOANBU_LIST.Items.Count; i++)
			{
				conn2.QueryString = "select * from pending_loan_bu where ac_act#='" + DGR_LOANBU_LIST.Items[i].Cells[1].Text.Trim() + "' and flag='0'";
				conn2.ExecuteQuery();

				if (conn2.GetRowCount() > 0)	
				{
					lnk = (LinkButton)DGR_LOANBU_LIST.Items[i].Cells[5].FindControl("LNK_UPDATE");
					lnk.Visible = true;
				}
				else
				{
					lnk = (LinkButton)DGR_LOANBU_LIST.Items[i].Cells[5].FindControl("LNK_UPDATE");
					lnk.Visible = false;
				}
			}

			for (int i = 0; i < DGR_LOANBU_LIST.Items.Count; i++)
			{
				conn2.QueryString = "select * from pending_loan_bu where ac_act#='" + DGR_LOANBU_LIST.Items[i].Cells[1].Text.Trim() + "' and flag='2'";
				conn2.ExecuteQuery();

				if (conn2.GetRowCount() > 0)	
				{
					lnk = (LinkButton)DGR_LOANBU_LIST.Items[i].Cells[4].FindControl("LNK_VIEW");
					lnk.Visible = false;
				}
				else
				{
					lnk = (LinkButton)DGR_LOANBU_LIST.Items[i].Cells[4].FindControl("LNK_VIEW");
					lnk.Visible = true;
				}
			}
		}

		protected void DDL_SEGMENT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillUnit();
		}

		private void DGR_LOANBU_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":	
						Response.Redirect("LoanDetailDataBU.aspx?acc=" + e.Item.Cells[1].Text);
					break;
				case "Update":
					try
					{
						conn2.QueryString = "EXEC DQM_LOAN_BU_UPDATE '" + e.Item.Cells[1].Text.Trim() +
							"', '1'";
						conn2.ExecuteQuery();
						GlobalTools.popMessage(this, "Data masuk ke list pending approval");
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

		private void DGR_LOANBU_LIST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_LOANBU_LIST.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}
	}
}
