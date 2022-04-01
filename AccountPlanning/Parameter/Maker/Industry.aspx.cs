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
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;
using System.Configuration;

namespace SME.AccountPlanning.Parameter.Maker
{
	/// <summary>
	/// Summary description for Industry.
	/// </summary>
	public partial class Industry : System.Web.UI.Page
	{
		protected Connection conn = new Connection(System.Configuration.ConfigurationSettings.AppSettings["connectionString"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{		
			if (!IsPostBack)
			{
				LBL_SAVEMODE.Text = "1";
				FillDDLInc();
				bindData1();
				bindData2();
			}			
			Datagrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change1);
			DataGrid2.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change2);
		}

		private void FillDDLInc()
		{
			DDL_BM_INDUSTRY.Items.Clear();
			DDL_BM_INDUSTRY.Items.Add(new ListItem("-- Select --", ""));

			conn.QueryString = "SELECT PD_INDUSTRY_NAMECD, PD_INDUSTRY_NAME FROM PD_RF_INDUSTRY_CLASS WHERE ACTIVE = '1'";
			conn.ExecuteQuery();

			for (int i=0; i<conn.GetRowCount(); i++)
			{
				DDL_BM_INDUSTRY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i, 0)));
			}
		}

		private void bindData1()
		{
			conn.QueryString = "SELECT CODE, CODE_DESCRIPTION, BM_INDUSTRY_CODE, PD_KSEBMDESC, (BM_INDUSTRY_CODE +' - '+ PD_KSEBMDESC) AS BM_INDUSTRY_LINK " +
								"FROM AP_RF_INDUSTRY_BCG a LEFT JOIN PD_RF_KSEBM b ON a.BM_INDUSTRY_CODE = b.PD_KSEBMCD WHERE a.ACTIVE = '1' ORDER BY CONVERT(INT,CODE)";
			conn.ExecuteQuery();
			
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			Datagrid1.DataSource = dt;
			Datagrid1.DataBind();
		}
	
		private void bindData2()
		{		
			conn.QueryString = "SELECT CODE, CODE_DESCRIPTION, (CODE +'-'+ CODE_DESCRIPTION) as CODEGAB, BM_INDUSTRY_CODE, (BM_INDUSTRY_CODE +' - '+ PD_KSEBMDESC) AS BM_INDUSTRY_LINK, PENDINGSTATUS " +
								"FROM AP_RF_PENDING_INDUSTRY_BCG a LEFT JOIN PD_RF_KSEBM b on a.BM_INDUSTRY_CODE = b.PD_KSEBMCD WHERE a.ACTIVE = '1' ORDER BY CONVERT(INT,CODE)";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DataGrid2.DataSource = dt;
			DataGrid2.DataBind();

			for (int i = 0; i < DataGrid2.Items.Count; i++)
			{
				if (DataGrid2.Items[i].Cells[5].Text.Trim() == "0")
				{
					DataGrid2.Items[i].Cells[5].Text = "UPDATE";
				}
				else if (DataGrid2.Items[i].Cells[5].Text.Trim() == "1")
				{
					DataGrid2.Items[i].Cells[5].Text = "INSERT";
				}
				else if (DataGrid2.Items[i].Cells[5].Text.Trim() == "2")
				{
					DataGrid2.Items[i].Cells[5].Text = "DELETE";
				}
			} 
		}

		private string getPendingStatus(string saveMode) 
		{
			string status = "";			
			switch (saveMode)
			{
				case "0":
					status = "Update";
					break;
				case "1":
					status = "Insert";
					break;
				case "2":
					status = "Delete";
					break;
				default:
					status = "";
					break;
			}
			return status;
		}
	
		

		private void clearEditBoxes()
		{
			TXT_AP_INDUSTRY_ID.Text			="";
			TXT_AP_INDUSTRY_NAME.Text		="";
			DDL_BM_INDUSTRY.SelectedValue	="";
			//DDL_BM_INDUSTRY.Enabled		=true;
					
			LBL_SAVEMODE.Text = "1";
			activatePostBackControls(true);
		}

		private void activatePostBackControls(bool mode)
		{
			//TXT_BRANCH_CODE.Enabled = mode;
		}

		private void cleansTextBox (TextBox tb)
		{
			if (tb.Text.Trim() == "&nbsp;")
				tb.Text = "";
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
			this.Datagrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Datagrid1_ItemCommand);
			this.Datagrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.Grid_Change1);
			this.DataGrid2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_ItemCommand);
			this.DataGrid2.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.Grid_Change2);

		}
		#endregion

		private void Grid_Change1(Object sender, DataGridPageChangedEventArgs e) 
		{
			// Set CurrentPageIndex to the page the user clicked.
			Datagrid1.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData1();	
		}

		private void Grid_Change2(Object sender, DataGridPageChangedEventArgs e) 
		{
			// Set CurrentPageIndex to the page the user clicked.
			DataGrid2.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData2();	
		}

		private void Datagrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			clearEditBoxes();
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					TXT_AP_INDUSTRY_ID.Text			= e.Item.Cells[0].Text.Trim().Replace("&nbsp;","");
					TXT_AP_INDUSTRY_NAME.Text		= e.Item.Cells[1].Text.Trim().Replace("&nbsp;","");
					DDL_BM_INDUSTRY.SelectedValue	= e.Item.Cells[2].Text.Trim().Replace("&nbsp;","");
					//DDL_BM_INDUSTRY.Enabled		= true;
					LBL_SAVEMODE.Text				= "0";
					//LBL_INDUSTRYCD.Text			= e.Item.Cells[0].Text.Trim();
					//LBL_INDUSTRYCD.Visible		= false;
					activatePostBackControls(false);
					cleansTextBox(TXT_AP_INDUSTRY_ID);
					cleansTextBox(TXT_AP_INDUSTRY_NAME);
					break;
					
				case "delete":
					//LBL_SAVEMODE.Text = "2";
					conn.QueryString = "INSERT INTO AP_RF_PENDING_INDUSTRY_BCG VALUES ('" + e.Item.Cells[0].Text.Trim() + "','" + e.Item.Cells[1].Text.Trim() + "', '" + e.Item.Cells[3].Text.Trim() + "','1','2')";
					conn.ExecuteNonQuery();

					bindData2();
					break;
				
				default:
					// Do nothing.
					break;
			} 
		}

		private void DataGrid2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			clearEditBoxes();
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					TXT_AP_INDUSTRY_ID.Text			= e.Item.Cells[0].Text.Trim().Replace("&nbsp;","");
					TXT_AP_INDUSTRY_NAME.Text		= e.Item.Cells[1].Text.Trim().Replace("&nbsp;","");
					DDL_BM_INDUSTRY.SelectedValue	= e.Item.Cells[2].Text.Trim().Replace("&nbsp;","");
					//DDL_BM_INDUSTRY.Enabled		= true;
					LBL_SAVEMODE.Text				= "0";
					//LBL_INDUSTRYCD.Text			= e.Item.Cells[0].Text.Trim();
					//LBL_INDUSTRYCD.Visible		= false;
					activatePostBackControls(false);
					cleansTextBox(TXT_AP_INDUSTRY_ID);
					cleansTextBox(TXT_AP_INDUSTRY_NAME);
					break;
					
				case "delete":
					//LBL_SAVEMODE.Text = "2";
					conn.QueryString = "DELETE AP_RF_PENDING_INDUSTRY_BCG WHERE BM_INDUSTRY_CODE='" + e.Item.Cells[2].Text.Trim() + "'";
					conn.ExecuteNonQuery();
					bindData2();
					break;
				default:
					// Do nothing.
					break;
			}  
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			//namafungsi(LBL_SAVEMODE.Text);
			if (LBL_SAVEMODE.Text == "0")
			{
				conn.QueryString = "SELECT * FROM AP_RF_PENDING_INDUSTRY_BCG WHERE BM_INDUSTRY_CODE='" + DDL_BM_INDUSTRY.SelectedValue + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0)
				{
					conn.QueryString = "UPDATE AP_RF_PENDING_INDUSTRY_BCG SET CODE='" + TXT_AP_INDUSTRY_ID.Text + "', CODE_DESCRIPTION='" + TXT_AP_INDUSTRY_NAME.Text + "', BM_INDUSTRY_CODE='" + DDL_BM_INDUSTRY.SelectedValue + "', active='1', PENDINGSTATUS='" + LBL_SAVEMODE.Text + "'";
					conn.ExecuteQuery();
					bindData2();
					clearEditBoxes();
				}
				else
				{
					conn.QueryString = "INSERT INTO AP_RF_PENDING_INDUSTRY_BCG VALUES ('" + TXT_AP_INDUSTRY_ID.Text + "','" + TXT_AP_INDUSTRY_NAME.Text + "','" + DDL_BM_INDUSTRY.SelectedValue + "','1','" + LBL_SAVEMODE.Text + "')";
					conn.ExecuteQuery();
					bindData2();
					clearEditBoxes();
				}
			}
			else if (LBL_SAVEMODE.Text == "1")
			{
				conn.QueryString = "INSERT INTO AP_RF_PENDING_INDUSTRY_BCG VALUES ('" + TXT_AP_INDUSTRY_ID.Text + "','" + TXT_AP_INDUSTRY_NAME.Text + "','" + DDL_BM_INDUSTRY.SelectedValue + "','1','" + LBL_SAVEMODE.Text + "')";
				conn.ExecuteQuery();
				bindData2();
				clearEditBoxes();
				LBL_SAVEMODE.Text = "1";	
			}
		}
/*
		private void namafungsi(string nama)
		{
			if(nama == "0")
			{
				//do nothing
			}
			else if(nama == "1")
			{
				conn.QueryString = "select max (convert (int,PD_INDUSTRY_NAMECD)) as INDUSTRY_NAMECD from PD_RF_INDUSTRY_CLASS";
				conn.ExecuteQuery();
				Label2.Text = conn.GetFieldValue("INDUSTRY_NAMECD");

				conn.QueryString = "select isnull(max (convert (int,PD_INDUSTRY_NAMECD)),0) as INDUSTRY_NAMECD1 from PD_PENDING_RF_INDUSTRY_CLASS";
				conn.ExecuteQuery();
				Label3.Text = conn.GetFieldValue("INDUSTRY_NAMECD1");

				if (int.Parse(Label2.Text) > int.Parse(Label3.Text))
				{
					LBL_INDUSTRYCD.Text = (int.Parse(Label2.Text) + 1).ToString();
				}
				else
				{
					LBL_INDUSTRYCD.Text = (int.Parse(Label3.Text) + 1).ToString();
				}		
			}
		}
*/
		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			clearEditBoxes();
			LBL_SAVEMODE.Text = "1";
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../AccountPlanningParam.aspx?mc=" + Request.QueryString["mc"] + "&moduleId=01");
			//Response.Redirect("../../GeneralParamAll.aspx?mc="+Request.QueryString["mc"]);
		}
	}
}