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
using System.IO;
using System.Diagnostics;

namespace SME.MAS.CollateralAdministration.CollateralRequest
{
	/// <summary>
	/// Summary description for ListCollateral.
	/// </summary>
	public class ListCollateral : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btn_Find;
		protected System.Web.UI.WebControls.Label Label1;
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.DataGrid DGR_RESULT;
		protected System.Web.UI.WebControls.TextBox TXT_ACC_NUM;
		protected System.Web.UI.WebControls.TextBox TXT_CUST_NAME;
		protected System.Web.UI.WebControls.TextBox TXT_COL_ID;
		protected System.Web.UI.WebControls.Button BTN_CANCEL;
		protected System.Web.UI.WebControls.Button BTN_FIND;
		protected System.Web.UI.WebControls.PlaceHolder PH_SUBMENU;
		protected System.Web.UI.WebControls.Label Label2;
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{					
				//conn.QueryString = "select * from VW_MAS_INPUT_NEW_COLLATERAL WHERE ACC_STATUS='2' and pic_id='" + Session["UserID"].ToString() + "' and track_by is null ";
				//conn.QueryString = "select * from VW_MAS_INPUT_NEW_COLLATERAL WHERE ACC_STATUS='2' and pic_inisiation='" + Session["UserID"].ToString() + "' and agunan_status <> '6' and trackcode = 'M1.5'";
				//conn.QueryString = "select * from VW_MAS_INPUT_NEW_COLLATERAL WHERE ACC_STATUS='2' and unit_code='" + Session["BranchID"].ToString() + "' and agunan_status <> '6' and trackcode = 'M1.5' order by acc_number ";
				//conn.ExecuteQuery();
				//FillGridResult();				
				if (Request.QueryString["tc"]=="M1.5")
				{
					Label2.Text="List Collateral Request";
				}
				else
				{
					Label2.Text="List Collateral Finish";
				}
				SearchData();

			}	
			ViewScreenMenu();
		}

		private void ViewScreenMenu()
		{
			

			HyperLink h3 = new HyperLink();
			h3.Text = "List Collateral Request";
			h3.Font.Bold = true;
			string aaa="ListCollateral.aspx?&tc=M1.5&mc=M0105";
			h3.NavigateUrl=aaa;
			

			HyperLink h4 = new HyperLink();
			h4.Text = "List Collateral Finish";
			h4.Font.Bold = true;
			string aaa1="ListCollateral.aspx?&tc=finish&mc=M0105";
			h4.NavigateUrl=aaa1;
			
			
			PH_SUBMENU.Controls.Add(h3);
			PH_SUBMENU.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
			PH_SUBMENU.Controls.Add(h4);
			PH_SUBMENU.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
		}


		private void FillGridResult()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_RESULT.DataSource = dt;
			try 
			{
				DGR_RESULT.DataBind();
			} 
			catch 
			{
				DGR_RESULT.CurrentPageIndex = 0;
				DGR_RESULT.DataBind();
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
			this.BTN_FIND.Click += new System.EventHandler(this.BTN_FIND_Click);
			this.BTN_CANCEL.Click += new System.EventHandler(this.BTN_CANCEL_Click);
			this.DGR_RESULT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_RESULT_ItemCommand);
			this.DGR_RESULT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_RESULT_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			DGR_RESULT.CurrentPageIndex = 0;
			SearchData();
		}

		private void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			TXT_ACC_NUM.Text = "";
			TXT_COL_ID.Text = "";
			TXT_CUST_NAME.Text = "";
		}

		private void SearchData()
		{
			string query1=""; 			
			
			if(TXT_ACC_NUM.Text!="")
			{
				query1 += "and acc_number LIKE '%" + TXT_ACC_NUM.Text + "%' ";				
			}
			if(TXT_CUST_NAME.Text!="")
			{
				query1 += "and cust_name='" + TXT_CUST_NAME.Text + "' ";				
			}
			if(TXT_COL_ID.Text!="")
			{
				query1 += "and collateral_id='" + TXT_COL_ID.Text + "' ";				
			}
			
			//conn.QueryString = "select * from MAS_UPLOAD_DATA where ACC_STATUS='2' " + query1;
			
			if (Request.QueryString["tc"]=="M1.5")
			{
				conn.QueryString ="select * from VW_MAS_INPUT_NEW_COLLATERAL WHERE ACC_STATUS='2' and unit_code='" + Session["BranchID"].ToString() + "' and agunan_status <> '6' and trackcode = 'M1.5'  " + query1 + " order by acc_number ";				
			}
			else
			{
				conn.QueryString ="select * from VW_MAS_INPUT_NEW_COLLATERAL WHERE ACC_STATUS='2' and unit_code='" + Session["BranchID"].ToString() + "' and trackcode in ('M1.8', 'M1.9', 'M1.10', 'M1.11') " + query1 + "order by acc_number ";
			}
			
			conn.ExecuteQuery();
			//FillGridResult();			

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_RESULT.DataSource = dt;
			try 
			{
				DGR_RESULT.DataBind();
			} 
			catch 
			{
				DGR_RESULT.CurrentPageIndex = 0;
				DGR_RESULT.DataBind();
			}

		}

		private void DGR_RESULT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_RESULT.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void DGR_RESULT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":					
					Response.Redirect("CollateralRequest.aspx?sta=exist&acc_number=" + e.Item.Cells[1].Text + "&collateral_id=" + e.Item.Cells[3].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + 
						"&type=" + e.Item.Cells[4].Text + "&acc_status=" + e.Item.Cells[5].Text);
					break;
			}
		}

	}
}
