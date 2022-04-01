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
using Microsoft.VisualBasic;
using System.Configuration;


namespace SME.BGSpan.TransactionHistory
{
	/// <summary>
	/// Summary description for NCLHistoryTransaction.
	/// </summary>
	public class NCLHistoryTransaction : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txt_npwp;
		protected string tesstring = "";
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.Label lbl_curef;
		protected System.Web.UI.WebControls.TextBox TXT_CU_CIF;
		protected System.Web.UI.WebControls.TextBox TXT_CU_NAME;
		protected System.Web.UI.WebControls.TextBox TXT_TGL_LAHIR;
		protected System.Web.UI.WebControls.TextBox TXT_NPWP;
		protected System.Web.UI.WebControls.TextBox TXT_ALAMAT1;
		protected System.Web.UI.WebControls.TextBox TXT_ALAMAT2;
		protected System.Web.UI.WebControls.TextBox TXT_ALAMAT3;
		protected System.Web.UI.WebControls.DataGrid Datagrid1;
		protected System.Web.UI.WebControls.DataGrid DatGrd;
		protected Tools tool = new Tools();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				conn = (Connection) Session["Connection"];
				lbl_curef.Text = Request.QueryString ["curef"];

				PopulateGridNonCash();
				PopulateGridTransInfo();
				FillDetailCustomer();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void PopulateGridNonCash()
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

		private void PopulateGridTransInfo()
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

		private void FillDetailCustomer()
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

		private void Datagrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			Datagrid1.CurrentPageIndex = e.NewPageIndex;
			PopulateGridNonCash();
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			PopulateGridTransInfo();
		}		
		
	}
}
