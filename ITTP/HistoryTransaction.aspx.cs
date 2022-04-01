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

namespace SME.ITTP
{
	/// <summary>
	/// Summary description for HistoryTransaction.
	/// </summary>
	public partial class HistoryTransaction : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			lbl_curef.Text = Request.QueryString ["curef"];

			if (!IsPostBack)
			{
				ViewData();
				ViewGrid();
				FillGrid();
			}
		}

		private void ViewData()
		{
			string curef = lbl_curef.Text;
			conn.QueryString = "exec IT_NCLCUSTOMER '"+lbl_curef.Text+"'";
			conn.ExecuteQuery();
			TXT_CU_CIF.Text		= conn.GetFieldValue("CIF");
			TXT_CU_NAME.Text	= conn.GetFieldValue("NAMA");
			TXT_NPWP.Text		= conn.GetFieldValue("NPWP");
			TXT_TGL_LAHIR.Text	= conn.GetFieldValue("TGL_LAHIR");
			TXT_ALAMAT1.Text	= conn.GetFieldValue("ALAMAT1");
			TXT_ALAMAT2.Text	= conn.GetFieldValue("ALAMAT2");
			TXT_ALAMAT3.Text	= conn.GetFieldValue("ALAMAT3");
		}

		private void FillGrid()
		{
			conn.QueryString = "exec IT_TRANSACTIONHISTORY '"+lbl_curef.Text+"'";
				conn.ExecuteQuery();

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

			bool isComplete = false;
			for (int i = 0; i < DatGrd.Items.Count; i++) 
			{
				DatGrd.Items[i].Cells[5].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[5].Text);
				DatGrd.Items[i].Cells[8].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[8].Text);
				DatGrd.Items[i].Cells[9].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[9].Text);
				DatGrd.Items[i].Cells[10].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[10].Text);
			}
		}
		private void ViewGrid()
		{
			conn.QueryString = "exec IT_NCLCUSTOMERINFO '"+lbl_curef.Text+"'";
			conn.ExecuteQuery();

			DataTable d = new DataTable();
			d			= conn.GetDataTable().Copy();
			Datagrid1.DataSource	= d;
			try 
			{
				Datagrid1.DataBind();
			} 
			catch 
			{
				Datagrid1.CurrentPageIndex = 0;
				Datagrid1.DataBind();
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

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("SearchCustomerHistoryTransaction.aspx?mc=IT08");
		}
	}
}
