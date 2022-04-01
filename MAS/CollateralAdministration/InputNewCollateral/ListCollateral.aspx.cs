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

namespace SME.MAS.CollateralAdministration.InputNewCollateral
{
	/// <summary>
	/// Summary description for ListCollateral.
	/// </summary>
	public partial class ListCollateral : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{					
				//conn.QueryString = "select * from VW_MAS_INPUT_NEW_COLLATERAL WHERE ACC_STATUS ='1' and PIC_INISIATION = '" + Session["UserID"].ToString() + "' and agunan_status <> '6' and trackcode = 'M1.2' order by cust_name"; 
				/*and (agunan_status is null or agunan_status = '1' or agunan_status = '')";*/
				conn.QueryString = "select * from VW_MAS_INPUT_NEW_COLLATERAL WHERE ACC_STATUS ='1' and unit_code = '" + Session["BranchID"].ToString() + "' and agunan_status <> '6' and trackcode = 'M1.2' order by cust_name"; 
				conn.ExecuteQuery();
				FillGridResult();				
			}	
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
			this.DGR_RESULT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_RESULT_ItemCommand);
			this.DGR_RESULT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_RESULT_PageIndexChanged);

		}
		#endregion

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			DGR_RESULT.CurrentPageIndex = 0;
			SearchData();
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
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
				query1 += "and cust_name like '%" + TXT_CUST_NAME.Text + "%' ";				
			}
			if(TXT_COL_ID.Text!="")
			{
				query1 += "and collateral_id like '" + TXT_COL_ID.Text + "' ";				
			}
			
			//conn.QueryString = "select * from MAS_UPLOAD_DATA a, MAS_APP_CURRTRACK b where a.ACC_NUMBER = b.ACC_NUMBER and a.collateral_id = b.COLLATERALID  and b.ACC_STATUS='1'" + query1;
			conn.QueryString = "select * from VW_MAS_INPUT_NEW_COLLATERAL WHERE ACC_STATUS ='1' and unit_code = '" + Session["BranchID"].ToString() + "' and agunan_status <> '6' and trackcode = 'M1.2' " + query1 + "order by cust_name"; 
			conn.ExecuteQuery();
			FillGridResult();			
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
					Response.Redirect("CollateralData.aspx?sta=exist&acc_number=" + e.Item.Cells[1].Text + "&collateral_id=" + e.Item.Cells[3].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + 
					"&type=" + e.Item.Cells[4].Text + "&acc_status=" + e.Item.Cells[5].Text);
					break;
			}
		}
		
	}
}
