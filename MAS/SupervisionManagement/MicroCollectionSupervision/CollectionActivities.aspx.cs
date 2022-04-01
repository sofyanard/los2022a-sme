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

namespace SME.MAS.SupervisionManagement.MicroCollectionSupervision
{
	/// <summary>
	/// Summary description for CollectionActivities.
	/// </summary>
	public partial class CollectionActivities : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				DDL_BLN_KUNJUNGAN.Items.Add(new ListItem("--Pilih--",""));				
				for(int i=1; i<=12; i++)
				{
					DDL_BLN_KUNJUNGAN.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));					
				}

				DDL_ACTION_CODE.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString = "select code, code +'-'+ description as deskripsi from mas_rf_action where status='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_ACTION_CODE.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
			ViewData();
		}

		private void ViewData()
		{
			conn.QueryString = "select * from mas_collection where pic_inisiasi='"+ Session["UserID"].ToString() +"' ";
			conn.ExecuteQuery();
			FillGrid();
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
	
			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				DatGrd.Items[i].Cells[2].Text = tool.FormatDate(DatGrd.Items[i].Cells[2].Text, true);
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

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{
			TXT_NIP_MMC.Text = "";
			TXT_NO_REK.Text = "";
			TXT_TGL_KUNJUNGAN.Text = "";
			DDL_BLN_KUNJUNGAN.SelectedValue = "";
			TXT_THN_KIUNJUNGAN.Text = "";
			DDL_ACTION_CODE.SelectedValue = "";
			TXT_HASIL_KUNJUNGAN.Text = "";
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = " exec MAS_COLLECTION_INSERT '" + 			
				Session["UserID"].ToString() + "', '" +
				TXT_NIP_MMC.Text + "', '" +
				TXT_NO_REK.Text + "', " +
				tool.ConvertDate(TXT_TGL_KUNJUNGAN.Text, DDL_BLN_KUNJUNGAN.SelectedValue, TXT_THN_KIUNJUNGAN.Text) + ", '" +
				DDL_ACTION_CODE.SelectedValue + "', '" +
				TXT_HASIL_KUNJUNGAN.Text +"' " ;
			conn.ExecuteQuery();
			
			ClearData();
			ViewData();
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete_data":
					conn.QueryString = "delete from mas_collection where acc_number= '" + e.Item.Cells[1].Text + "' ";
					conn.ExecuteQuery();					
					ClearData();					
					ViewData();
					break;

				case "edit_data":					
					conn.QueryString = "select * from mas_collection where acc_number= '" + e.Item.Cells[1].Text + "' ";
					conn.ExecuteQuery();
					
					TXT_NIP_MMC.Text = conn.GetFieldValue("mmc_nip");
					TXT_NO_REK.Text = conn.GetFieldValue("acc_number");						
					TXT_TGL_KUNJUNGAN.Text = tool.FormatDate_Day(conn.GetFieldValue("kunjungan_date"));
					try{DDL_BLN_KUNJUNGAN.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("kunjungan_date")); }
					catch{DDL_BLN_KUNJUNGAN.SelectedValue = "";}
					TXT_THN_KIUNJUNGAN.Text = tool.FormatDate_Year(conn.GetFieldValue("kunjungan_date"));
					try{DDL_ACTION_CODE.SelectedValue = conn.GetFieldValue("action_code");}
					catch{DDL_ACTION_CODE.SelectedValue = "";}
					TXT_HASIL_KUNJUNGAN.Text = conn.GetFieldValue("hasil_kunjungan");					
					break;
			}
		}
	}
}
