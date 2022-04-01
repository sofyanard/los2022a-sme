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

namespace SME.CreditOperations.RejectMaintenance
{
	/// <summary>
	/// Summary description for RejectMaintenanceList.
	/// </summary>
	public partial class RejectMaintenanceList : System.Web.UI.Page
	{
		protected Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

            string a = Session["GroupID"].ToString();
            string b = Request.QueryString["mc"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				bindData();
			}
		}

		private void bindData()
		{
            conn.QueryString = "SELECT * FROM [VW_CREOPR_REJECTMAINTENANCE_LIST_PUNDI] " +
				" where (AP_CA='" + Session["UserID"].ToString() + "') " ;
			conn.ExecuteQuery();
            DataGrid2.DataSource = conn.GetDataTable().Copy();
			try 
			{
                DataGrid2.DataBind();
			} 
			catch 
			{
                DataGrid2.CurrentPageIndex = 0;
                DataGrid2.DataBind();
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

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			// Set CurrentPageIndex to the page the user clicked.
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData();	
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					string regno = e.Item.Cells[0].Text.Trim(),
						curef = e.Item.Cells[1].Text.Trim(),
						apptype = e.Item.Cells[2].Text.Trim(),
						prodid = e.Item.Cells[3].Text.Trim(),
						ufcpseq = e.Item.Cells[4].Text.Trim(),
						prod_seq = e.Item.Cells[12].Text.Trim();
					Response.Redirect("RejectMaintenanceDetail.aspx?regno=" + regno + "&curef=" + curef +
						"&apptype=" + apptype + "&productid=" + prodid + "&uf_cpseq=" + ufcpseq +
						"&prod_seq=" + prod_seq +
						"&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
					break;

				default:
					// Do nothing.
					break;
			}
		}

        protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (((LinkButton)e.CommandSource).CommandName)
            {
                case "view":
                    string regno = e.Item.Cells[0].Text.Trim(),
                        curef = e.Item.Cells[1].Text.Trim();
                        /*apptype = e.Item.Cells[2].Text.Trim(),
                        prodid = e.Item.Cells[3].Text.Trim(),
                        ufcpseq = e.Item.Cells[4].Text.Trim(),
                        prod_seq = e.Item.Cells[12].Text.Trim();*/
                    Response.Redirect("RejectMaintenanceDetail.aspx?regno=" + regno + "&curef=" + curef +
                        "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
                    break;

                default:
                    // Do nothing.
                    break;
            }
        }
	}
}
