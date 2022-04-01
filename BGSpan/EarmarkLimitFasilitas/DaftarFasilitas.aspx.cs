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


namespace SME.BGSpan.EarmarkLimitFasilitas
{
	/// <summary>
	/// Summary description for DaftarFasilitas.
	/// </summary>
	public partial class DaftarFasilitas : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				PopulaterGrid ();
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
			this.DATA_GRID_list_apps.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_GRID_list_apps_ItemCommand);

		}
		#endregion
		public void PopulaterGrid()
		{
			conn.QueryString = "";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			DATA_GRID_list_apps.DataSource = dt;

			try
			{
				DATA_GRID_list_apps.DataBind();
			}
			catch
			{
				DATA_GRID_list_apps.CurrentPageIndex = DATA_GRID_list_apps.PageCount - 1;
				DATA_GRID_list_apps.DataBind();
			}

			conn.ClearData();
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			if(TXT_CUST.Text=="")
			{
				PopulaterGrid ();
			}
			else
			{

				conn.QueryString = ""; // ini diisi queri sama kaya di populategrid tapi ditambahin where-nya 
									   // peke like '%isi textbox%'
				conn.ExecuteQuery();

				System.Data.DataTable dt = new System.Data.DataTable();
				dt = conn.GetDataTable().Copy();

				DATA_GRID_list_apps.DataSource = dt;

				try
				{
					DATA_GRID_list_apps.DataBind();
				}
				catch
				{
					DATA_GRID_list_apps.CurrentPageIndex = DATA_GRID_list_apps.PageCount - 1;
					DATA_GRID_list_apps.DataBind();
				}

				conn.ClearData();
			}
		}

		private void DATA_GRID_list_apps_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string reg_no;//yg mau di ambil id apa
			if (e.CommandName=="view")
			{
                reg_no=e.Item.Cells[0].Text; // di cel mana

				//nanti baru redirect ke halaman lain nuat munculin keterangannya...
				//tp di disable soalnya view doank nah pas di redirect ke halaman lempar value buat 

			}
		}


	}
}
