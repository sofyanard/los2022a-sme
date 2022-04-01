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


namespace SME.IDI_BI
{
	/// <summary>
	/// Summary description for ListInputReqBI.
	/// </summary>
	public partial class ListInputReqBI : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			if (!IsPostBack)
			{
				//conn.QueryString="select * from idi_request where idi_officer='"+Session["UserID"].ToString()+"' and idi_status is null ";
				conn.QueryString="select * from idi_request order by idi_reqdate desc";
				conn.ExecuteQuery();
				FillGrid();
			}			
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = 0;
				DatGrd.DataBind();
			}
		}

		private void SearchData()
		{
			string query=""; 
			
			if(TXT_CUST_NAME.Text!="")
			{
				query += "and IDI_CUSTNAME LIKE '%" + TXT_CUST_NAME.Text + "%' ";
			}
			if(TXT_KTP_NUM.Text!="")
			{
				query += "and IDI_KTP#='" + TXT_KTP_NUM.Text + "' ";
			}			
			if(NPWP_NUM.Text!="")
			{
				query += "and IDI_NPWP#='" + NPWP_NUM.Text + "' ";
			}			

			if(query!="")
			{
				//conn.QueryString="select * from idi_request where idi_officer='"+Session["UserID"].ToString()+"' and idi_status is null " + query;
				conn.QueryString="select * from idi_request where 1=1" + query + "order by idi_reqdate desc";
				conn.ExecuteQuery();
				FillGrid();
			}
			else
			{
				//conn.QueryString="select * from idi_request where idi_officer='"+Session["UserID"].ToString()+"' and idi_status is null ";
				conn.QueryString="select * from idi_request";
				conn.ExecuteQuery();
				FillGrid();
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);

		}
		#endregion

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			DatGrd.CurrentPageIndex = 0;
			SearchData();
		}

		protected void BTN_NEW_CUST_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec IDI_GENERATE_ID '" + Session["BranchID"].ToString() + "' ";
			conn.ExecuteQuery();
			Response.Redirect("InputBIReq.aspx?regnum=" + conn.GetFieldValue(0,0) + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&exist=0");
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Continue":
					conn.QueryString = "select * from idi_request where idi_req# = '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					string regnumexist;
					regnumexist = conn.GetFieldValue("idi_req#");
					if (conn.GetFieldValue("idi_status")=="0")
					{
						conn.QueryString = "exec IDI_GENERATE_ID '" + Session["BranchID"].ToString() + "' ";
						conn.ExecuteQuery();
						Response.Redirect("InputBIReq.aspx?regnum=" + conn.GetFieldValue(0,0) + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&regnumexist=" + regnumexist + "&exist=0");
					}

					Response.Redirect("InputBIReq.aspx?sta=exist&regnum=" + e.Item.Cells[0].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&exist=1");									
					break;
			}
		}
	}
}
