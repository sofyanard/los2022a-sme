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

namespace SME.AccountPlanning.ActionPlan
{
	/// <summary>
	/// Summary description for CustomerList.
	/// </summary>
	public partial class CustomerList : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				FillDDLSegment();
				FillDDLUnit();
				//FillDDLUpliner();

				if(Request.QueryString["mc"] == "AP08")			//Account Planning Setup
				{
					BTN_New.Visible = false;
				}
	
				conn.QueryString = "SELECT DISTINCT CIF#,BUSSUNITID,BUSSUNITDESC,BUC,BRANCH_NAME,RM_NAME,CUSTOMER_GROUP FROM VW_AP_CUSTOMER_LIST";
				BindData(DATA_GRID.ID.ToString(), conn.QueryString);
			}
		}

		private void FillDDLSegment()
		{
			DDL_SEGMENT.Items.Clear();
			DDL_SEGMENT.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT BUSSUNITID, BUSSUNITDESC FROM RFBUSINESSUNIT WHERE ACTIVE='1' ORDER BY BUSSUNITID";
			conn.ExecuteQuery();
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_SEGMENT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLUnit()
		{
			DDL_UNIT.Items.Clear();
			DDL_UNIT.Items.Add(new ListItem("--Select--", ""));

			if(DDL_SEGMENT.SelectedValue == "")
			{
				conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH WHERE ACTIVE='1'";
				conn.ExecuteQuery();
			}
			else
			{
				conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH WHERE BUSSUNITID = '" + DDL_SEGMENT.SelectedValue + "' AND ACTIVE='1'";
				conn.ExecuteQuery();
			}
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}
/*
		private void FillDDLUpliner()
		{
			DDL_CST.Items.Clear();
			DDL_CST.Items.Add(new ListItem("--Select--", ""));

			if(DDL_UNIT.SelectedValue == "")
			{
				conn.QueryString = "SELECT USERID, SU_FULLNAME FROM SCUSER WHERE GROUPID IN('010101010101010501','010101010101010505','00001','0101010101010106','010101010101010601','01010101010356') AND SU_ACTIVE='1'";
				conn.ExecuteQuery();
			}
			else
			{
				conn.QueryString = "SELECT USERID, SU_FULLNAME, SU_BRANCH FROM SCUSER WHERE GROUPID IN('010101010101010501','010101010101010505','00001','0101010101010106','010101010101010601','01010101010356') AND SU_BRANCH = '" + DDL_UNIT.SelectedValue + "' AND SU_ACTIVE='1'";
				conn.ExecuteQuery();
			}
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_CST.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}
*/
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
			this.DATA_GRID.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_GRID_ItemCommand);
			this.DATA_GRID.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_GRID_PageIndexChanged);

		}
		#endregion

		protected void DDL_SEGMENT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillDDLUnit();
			//FillDDLUpliner();
		}
/*
		private void DDL_UNIT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//FillDDLUpliner();
		}
*/
		protected void BTN_New_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("AnchorInfo.aspx?mc=" + Request.QueryString["mc"] + "&exist=0");
		}

		protected void BTN_Find_Click(object sender, System.EventArgs e)
		{
			DATA_GRID.CurrentPageIndex = 0;
			SearchData();
		}

		private void SearchData()
		{
			string query = "";

			if(DDL_SEGMENT.SelectedValue != "")
			{
				query += "AND BUSSUNITID = '" + DDL_SEGMENT.SelectedValue + "' ";
			}
			if(DDL_UNIT.SelectedValue != "")
			{
				query += "AND BUC = '" + DDL_UNIT.SelectedValue + "' ";
			}
			if(TXT_RM_NAME.Text != "")
			{
				query += "AND (RM_NAME like '%" + TXT_RM_NAME.Text + "%') ";
			}

			if(TXT_ANCHOR.Text != "")
			{
				query += "AND CUSTOMER_GROUP like '%" + TXT_ANCHOR.Text +"%' ";
			}	
		
			if(query != "")
			{
				conn.QueryString = "SELECT DISTINCT CIF#,BUSSUNITID,BUSSUNITDESC,BUC,BRANCH_NAME,RM_NAME,CUSTOMER_GROUP FROM VW_AP_CUSTOMER_LIST WHERE 1=1 " + query;
				BindData(DATA_GRID.ID.ToString(), conn.QueryString);
			}

			else
			{
				conn.QueryString = "SELECT DISTINCT CIF#,BUSSUNITID,BUSSUNITDESC,BUC,BRANCH_NAME,RM_NAME,CUSTOMER_GROUP FROM VW_AP_CUSTOMER_LIST";
				BindData(DATA_GRID.ID.ToString(), conn.QueryString);
			}

		}

		private void DATA_GRID_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_GRID.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void DATA_GRID_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "continue":
					if(Request.QueryString["mc"] == "AP07")			//Anchor Info & Team Setup
					{
						Response.Redirect("AnchorInfo.aspx?mc=" + Request.QueryString["mc"] +
							"&cif=" + e.Item.Cells[0].Text.Trim() + "&bs=" + e.Item.Cells[1].Text.Trim() + "&bc=" + e.Item.Cells[3].Text.Trim() +
							"&rd=" + e.Item.Cells[5].Text.Trim() + "&cd=" + e.Item.Cells[7].Text.Trim() + "&exist=1");
					}
					else if(Request.QueryString["mc"] == "AP08")	//Account Planning Setup
					{
						Response.Redirect("../AccountPlanSetup/Main.aspx?mc=" + Request.QueryString["mc"] +
							"&cif=" + e.Item.Cells[0].Text.Trim() + "&bs=" + e.Item.Cells[1].Text.Trim() + "&bc=" + e.Item.Cells[3].Text.Trim() +
							"&rd=" + e.Item.Cells[5].Text.Trim() + "&cd=" + e.Item.Cells[7].Text.Trim());
					}
				break;
			}
		}
	}
}
