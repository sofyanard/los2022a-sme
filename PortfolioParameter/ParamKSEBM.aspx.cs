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
namespace SME.PortfolioParameter
{
	/// <summary>
	/// Summary description for ParamKSEBM.
	/// </summary>
	public partial class ParamKSEBM : System.Web.UI.Page
	{
	
		protected Connection conn = new Connection(System.Configuration.ConfigurationSettings.AppSettings["connectionString"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
		
			if (!IsPostBack)
			{
				LBL_SAVEMODE.Text = "1";

				bindData1();
				bindData2();
			}			
			Datagrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change1);
			DataGrid2.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change2);	
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
	
		private void bindData1()
		{
			conn.QueryString = "select * from PD_RF_KSEBM where active ='1'";
			conn.ExecuteQuery();
			
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			Datagrid1.DataSource = dt;
			Datagrid1.DataBind();
		}

	
		private void bindData2()
		{
		
			conn.QueryString = "select * from PD_PENDING_RF_KSEBM";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DataGrid2.DataSource = dt;
			DataGrid2.DataBind();

			for (int i = 0; i < DataGrid2.Items.Count; i++)
			{
				if (DataGrid2.Items[i].Cells[2].Text.Trim() == "0")
				{
					DataGrid2.Items[i].Cells[2].Text = "UPDATE";
				}
				else if (DataGrid2.Items[i].Cells[2].Text.Trim() == "1")
				{
					DataGrid2.Items[i].Cells[2].Text = "INSERT";
				}
				else if (DataGrid2.Items[i].Cells[2].Text.Trim() == "2")
				{
					DataGrid2.Items[i].Cells[2].Text = "DELETE";
				}
			} 
		}

		private void clearEditBoxes()
		{
			TXT_KSEBMCD.Text="";
			TXT_KSEBMDESC.Text="";
					
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
			this.DataGrid2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_ItemCommand);

		}
		#endregion

		void Grid_Change1(Object sender, DataGridPageChangedEventArgs e) 
		{
			// Set CurrentPageIndex to the page the user clicked.
			Datagrid1.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData1();	
		}

		void Grid_Change2(Object sender, DataGridPageChangedEventArgs e) 
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
					TXT_KSEBMCD.Text=e.Item.Cells[0].Text.Trim();
					TXT_KSEBMDESC.Text=e.Item.Cells[1].Text.Trim();
					LBL_SAVEMODE.Text = "0";
					activatePostBackControls(false);
					cleansTextBox(TXT_KSEBMCD);
					cleansTextBox(TXT_KSEBMDESC);
					break;
					
				case "delete":
					//LBL_SAVEMODE.Text = "2";
					conn.QueryString = "INSERT INTO PD_PENDING_RF_KSEBM values ('"+e.Item.Cells[0].Text.Trim()+"','"+e.Item.Cells[1].Text.Trim()+"','1','2')";
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
					TXT_KSEBMCD.Text=e.Item.Cells[0].Text.Trim();
					TXT_KSEBMDESC.Text=e.Item.Cells[1].Text.Trim();
					LBL_SAVEMODE.Text = "0";
					activatePostBackControls(false);
					cleansTextBox(TXT_KSEBMCD);
					cleansTextBox(TXT_KSEBMDESC);
					break;
					
				case "delete":
					conn.QueryString = "delete PD_PENDING_RF_KSEBM where PD_KSEBMCD='"+e.Item.Cells[0].Text.Trim()+"'";
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
				conn.QueryString = "select * from PD_PENDING_RF_KSEBM where PD_KSEBMCD='"+TXT_KSEBMCD.Text+"'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0)
				{
					conn.QueryString = "UPDATE PD_PENDING_RF_KSEBM SET PD_KSEBMDESC='"+TXT_KSEBMDESC.Text+"', active='1', PENDINGSTATUS='"+LBL_SAVEMODE.Text+"' where PD_KSEBMCD='"+LBL_KSEBMCD.Text+"'";
					conn.ExecuteQuery();
					bindData2();
					clearEditBoxes();
				}
				else
				{
					conn.QueryString = "INSERT INTO PD_PENDING_RF_KSEBM VALUES ('"+TXT_KSEBMCD.Text+"','"+TXT_KSEBMDESC.Text+"','1','"+LBL_SAVEMODE.Text+"')";
					conn.ExecuteQuery();
					bindData2();
					clearEditBoxes();
				}
			}
			else if (LBL_SAVEMODE.Text == "1")
			{
				string active ="0";
				if (TXT_KSEBMCD.Text.Trim() == "" || TXT_KSEBMDESC.Text.Trim() == "") return;

				if (LBL_SAVEMODE.Text.Trim() == "1") //--- Status INSERT
				{
					conn.QueryString = "select active from PD_RF_KSEBM WHERE PD_KSEBMCD ='" + TXT_KSEBMCD.Text.Trim() + "'";
					conn.ExecuteQuery();
				
					if (conn.GetRowCount() > 0) 
					{
						active = conn.GetFieldValue("active");
						if (active == "1")
						{
							Tools.popMessage(this, "ID has already been used! Request canceled!");
							return;
						}
						else
						{
							LBL_SAVEMODE.Text ="0";
						}
					}
					else
					{
						conn.QueryString = "INSERT INTO PD_PENDING_RF_KSEBM VALUES ('"+TXT_KSEBMCD.Text+"','"+TXT_KSEBMDESC.Text+"','1','"+LBL_SAVEMODE.Text+"')";
						conn.ExecuteQuery();
						bindData2();
						clearEditBoxes();
						LBL_SAVEMODE.Text = "1";
					}
				}	
			}
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			clearEditBoxes();
			LBL_SAVEMODE.Text = "1";
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("PDParam.aspx?mc="+Request.QueryString["mc"]+"&moduleId=01");
			//Response.Redirect("../../GeneralParamAll.aspx?mc="+Request.QueryString["mc"]);
		}
	}
}