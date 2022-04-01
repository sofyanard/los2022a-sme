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
namespace SME.ITTP
{
	/// <summary>
	/// Summary description for ViewCollateral.
	/// </summary>
	public partial class ViewCollateral : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				conn = (Connection) Session["Connection"];
				viewdata();
			}
		}

		private void viewdata()
		{
			conn.QueryString = "select * from VW_IT_DETAIL_COLLATERAL where ap_regno='" + Request.QueryString["regno"] + "' and productid='" + Request.QueryString["productid"] + "' and apptype='" + Request.QueryString["apptype"] + "'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_QUAL2.DataSource = dt;
			try 
			{
				DGR_QUAL2.DataBind();
			}
			catch 
			{
				DGR_QUAL2.CurrentPageIndex = 0;
				DGR_QUAL2.DataBind();
			}

			for (int i = 0; i < DGR_QUAL2.Items.Count; i++)
			{
				if (DGR_QUAL2.Items[i].Cells[6].Text != "&nbsp;")
					DGR_QUAL2.Items[i].Cells[6].Text = tool.MoneyFormat(DGR_QUAL2.Items[i].Cells[6].Text);
				if  (DGR_QUAL2.Items[i].Cells[8].Text != "&nbsp;")
					DGR_QUAL2.Items[i].Cells[8].Text = tool.MoneyFormat(DGR_QUAL2.Items[i].Cells[8].Text);
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

		}
		#endregion
	}
}
