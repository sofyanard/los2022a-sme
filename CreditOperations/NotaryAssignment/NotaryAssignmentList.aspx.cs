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

namespace SME.CreditOperations.NotaryAssignment
{
	/// <summary>
	/// Summary description for NotaryAssignmentList.
	/// </summary>
	public partial class NotaryAssignmentList : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn;
		protected Tools tools = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				LBL_H_TC.Text = Request.QueryString["tc"];
				
				Tools.initDateForm(txt_Date, ddl_Month, txt_Year, true);
				txt_Date.Text = "";
				txt_Year.Text = "";
				Tools.initDateForm(txt_Date1, ddl_Month1, txt_Year1, true);
				txt_Date1.Text = "";
				txt_Year1.Text = "";

				DataTable DTBO = new DataTable();
				this.DataGrid1.DataSource = new DataView(DTBO);
				try 
				{
					DataGrid1.DataBind();
				} 
				catch 
				{
					DataGrid1.CurrentPageIndex = 0;
					DataGrid1.DataBind();
				}

				// Munculkan pesan next step
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"]!= null)  
					GlobalTools.popMessage(this, Request.QueryString["msg"]);

				bindData();
			}
			
			// Manually register the event-handling method for the PageIndexChanged 
			// event of the DataGrid control.
			DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
		}

		private void bindData()
		{
			DataTable DTBO = new DataTable();
			DataRow datrow;
			string sqlCond = "WHERE(", sjoin = RDB_COND.SelectedValue;
			if (txt_IdCard.Text.Trim() != "")
				sqlCond = sqlCond + " CU_IDCARDNUM like '%" + txt_IdCard.Text + "%' " + sjoin;
			if (txt_NPWP.Text.Trim() != "")
				sqlCond = sqlCond + " CU_NPWP like '%" + txt_NPWP.Text + "%' " + sjoin;
			if (txt_Name.Text.Trim() != "")
				sqlCond = sqlCond + " NAME like '%" + txt_Name.Text + "%' " + sjoin;
			if (txt_ProsID.Text.Trim() != "")
				sqlCond = sqlCond + " AP_REGNO like '%" + txt_ProsID.Text + "%' " + sjoin;
			if ( ((txt_Date.Text.Trim() != "") && (txt_Year.Text.Trim() != "")) && ((txt_Date1.Text.Trim() != "") && (txt_Year1.Text.Trim() != "")) )
				sqlCond = sqlCond + " AP_SIGNDATE BETWEEN '" + Tools.toSQLDate(txt_Date, ddl_Month, txt_Year) + "' and '"+ Tools.toSQLDate(txt_Date1, ddl_Month1, txt_Year1) +"' " + sjoin;
			if (sqlCond == "WHERE(") 
				sqlCond = "";
			else
			{
				sqlCond = sqlCond.Substring(0, sqlCond.Length - sjoin.Length);
				sqlCond = sqlCond + ")";
			}

			DTBO.Columns.Add(new DataColumn("AP_REGNO"));
			DTBO.Columns.Add(new DataColumn("CU_REF"));
			DTBO.Columns.Add(new DataColumn("NAME"));			
			DTBO.Columns.Add(new DataColumn("AP_SIGNDATE"));			
			DTBO.Columns.Add(new DataColumn("AP_RELMNGR"));
			DTBO.Columns.Add(new DataColumn("LIMIT"));
			DTBO.Columns.Add(new DataColumn("AP_CO"));

			string vBRANCHID = (string) Session["BranchID"];
			if (sqlCond != "") 
			{
				conn.QueryString = "SELECT * FROM VW_CREOPR_NOTARYASSIGN_LIST " + sqlCond + 
					" and AP_CURRTRACK='" + Request.QueryString["tc"] + 
					"' and (AP_CO='" + Session["UserID"].ToString() + "' or AP_CO is null) " + 
					" and BR_CCOBRANCH ='" + vBRANCHID + "'";
				conn.ExecuteQuery();
				for (int i =0; i < conn.GetRowCount(); i++) 
				{
					datrow = DTBO.NewRow();
					datrow[0] = conn.GetFieldValue(i,0);
					datrow[1] = conn.GetFieldValue(i,1);
					datrow[2] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,2);					
					datrow[3] = tools.FormatDate(conn.GetFieldValue(i,3), true);
					datrow[4] = conn.GetFieldValue(i,4);					
					datrow[5] = tools.MoneyFormat(conn.GetFieldValue(i,6).ToString());
					datrow[6] = conn.GetFieldValue(i,10);
				
					DTBO.Rows.Add(datrow);
				}
			} 
			else
			{
				//Response.Write("No Condition");
				conn.QueryString = "SELECT * FROM VW_CREOPR_NOTARYASSIGN_LIST " + 
					" WHERE AP_CURRTRACK='" + Request.QueryString["tc"] + 
					"' and (AP_CO='" + Session["UserID"].ToString() + "' or AP_CO is null) " +
					" and BR_CCOBRANCH = '" + vBRANCHID + "'";
				conn.ExecuteQuery();
				for (int i =0; i < conn.GetRowCount(); i++) 
				{
					datrow = DTBO.NewRow();
					datrow[0] = conn.GetFieldValue(i,0);
					datrow[1] = conn.GetFieldValue(i,1);
					datrow[2] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,2);					
					datrow[3] = tools.FormatDate(conn.GetFieldValue(i,3), true);
					datrow[4] = conn.GetFieldValue(i,4);					
					datrow[5] = tools.MoneyFormat(conn.GetFieldValue(i,6).ToString());
					datrow[6] = conn.GetFieldValue(i,10);
				
					DTBO.Rows.Add(datrow);
				}
			}

			this.DataGrid1.DataSource = new DataView(DTBO);
			try 
			{
				this.DataGrid1.DataBind();
			} 
			catch 
			{
				DataGrid1.CurrentPageIndex = 0;
				DataGrid1.DataBind();
			}

			try 
			{
				/// Get the right application limit value
				/// 
				for (int i = 0; i < DataGrid1.Items.Count; i++) 
				{
					conn.QueryString = "DE_TOTALEXPOSURE '" + DataGrid1.Items[i].Cells[0].Text.Trim() + "'";
					conn.ExecuteQuery(300);
					DataGrid1.Items[i].Cells[5].Text = GlobalTools.MoneyFormat(conn.GetFieldValue("tot_limit"));					
				}
			} 
			catch (Exception e)
			{
				Response.Write("<!-- get right app value err : " + e.Message + "-->");
			}


			/*
			 * 
			DataTable dt = new DataTable();
			DataRow dr;
			conn.QueryString = "SELECT AP_REGNO, CU_REF, NAME, AP_SIGNDATE, AP_RELMNGR, LIMIT "+
				"FROM VWCREOPR_NOTARYASSIGN_LIST ";
			conn.ExecuteQuery();
			dt.Columns.Add(new DataColumn("AP_REGNO"));
			dt.Columns.Add(new DataColumn("CU_REF"));
			dt.Columns.Add(new DataColumn("NAME"));
			dt.Columns.Add(new DataColumn("AP_SIGNDATE"));
			dt.Columns.Add(new DataColumn("AP_RELMNGR"));
			dt.Columns.Add(new DataColumn("LIMIT"));
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				dr = dt.NewRow();
				for (int j = 0; j < conn.GetColumnCount(); j++)
				{
					dr[j] = conn.GetFieldValue(i,j);
				}
				dt.Rows.Add(dr);
			}
			DataGrid1.DataSource = new DataView(dt);
			DataGrid1.DataBind();
			*/
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

		}
		#endregion

		void Grid_Change(Object sender, DataGridPageChangedEventArgs e) 
		{
			// Set CurrentPageIndex to the page the user clicked.
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData();	
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string regno, curef;
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "undo":
					// e.Item is the table row where the command is raised. For bound
					// columns, the value is stored in the Text property of a TableCell.
					regno = e.Item.Cells[0].Text.Trim();
					curef = e.Item.Cells[1].Text.Trim();
					//delete row
					break;

				case "view":
					regno = e.Item.Cells[0].Text.Trim();
					curef = e.Item.Cells[1].Text.Trim();
					if (e.Item.Cells[7].Text == "&nbsp;")
					{
						conn.QueryString = "update application set ap_co='" + Session["UserID"].ToString() + "' where ap_regno='" + e.Item.Cells[0].Text + "'";
						conn.ExecuteNonQuery();
					}

					Response.Redirect("DetailLegalSigning.aspx?regno="+ e.Item.Cells[0].Text +"&curef="+ e.Item.Cells[1].Text +"&tc="+ LBL_H_TC.Text+ "&mc=" + Request.QueryString["mc"]);
					//Response.Redirect("DetailLegalSigning.aspx?regno="+ e.Item.Cells[0].Text +"&curef="+ e.Item.Cells[1].Text +"&tc="+ LBL_H_TC.Text+ "&mc=019");
					break;

				default:
					// Do nothing.
					break;
			}
		}

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			this.bindData();
		}
	}
}
