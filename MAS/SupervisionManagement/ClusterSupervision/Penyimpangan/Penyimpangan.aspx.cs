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

namespace SME.MAS.SupervisionManagement.ClusterSupervision.Penyimpangan
{
	/// <summary>
	/// Summary description for Penyimpangan.
	/// </summary>
	public partial class Penyimpangan : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid Datagrid1;		
		protected Tools tool = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				DDL_BLN_PELAPORAN.Items.Add(new ListItem("--Pilih--",""));				
				for(int i=1; i<=12; i++)
				{
					DDL_BLN_PELAPORAN.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));				
				}
				TXT_CLUSTER.Text = Session["BranchName"].ToString();
				TXT_DISTRICT.Text = Session["BranchName"].ToString();

				DDL_KODE_PELAPORAN.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString = "select code, code + '- ' + [description] as [description] from mas_rf_pelaporan where status='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_KODE_PELAPORAN.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

				DDL_UNIT.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString = "select branch_code, branch_name from rfbranch where active='1' order by branch_name";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

				ViewData();
				ViewData2();
			}			
		}

		private void ViewData()
		{
			//conn.QueryString = "select * from mas_cluster_supervision_welcoming_call where flag='1' and unit_code= '"+ Session["BranchID"].ToString() +"'";
			conn.QueryString = "select * from mas_cluster_supervision_welcoming_call where flag not in ('0', '2') or flag is null and unit_code= '"+ Session["BranchID"].ToString() +"'";
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
				DatGrd.Items[i].Cells[3].Text = tool.FormatDate(DatGrd.Items[i].Cells[3].Text, true);
			}
		}

		private void ViewData2()
		{
			conn.QueryString = "select * from mas_cluster_supervision_welcoming_call where flag='2' and unit_code= '"+ Session["BranchID"].ToString() +"'";
			conn.ExecuteQuery();
			FillGrid2();
		}

		private void FillGrid2()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrd2.DataSource = dt;
			try 
			{
				DatGrd2.DataBind();
			} 
			catch 
			{
				DatGrd2.CurrentPageIndex = 0;
				DatGrd2.DataBind();
			}
	
			for (int i = 0; i < DatGrd2.Items.Count; i++)
			{
				DatGrd2.Items[i].Cells[7].Text = tool.FormatDate(DatGrd2.Items[i].Cells[7].Text, true);
			}
		}

		private void ClearData()
		{
			TXT_CUST_NAME.Text = "";
			TXT_ACC_NUM.Text = "";
			DDL_UNIT.SelectedValue = "";
			TXT_TGL_PELAPORAN.Text = "";
			DDL_BLN_PELAPORAN.SelectedValue = "";
			TXT_THN_PELAPORAN.Text = "";
			DDL_KODE_PELAPORAN.SelectedValue = "";
			TXT_KET.Text = "";
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

		}
		#endregion

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete_data":
					//conn.QueryString = "delete from mas_cluster_supervision_welcoming_call where acc_number= '" + e.Item.Cells[0].Text + "' ";
					conn.QueryString = "update mas_cluster_supervision_welcoming_call set flag='0' where acc_number= '" + e.Item.Cells[0].Text + "' ";
					conn.ExecuteQuery();					
					ClearData();					
					ViewData();
					break;

				case "edit_data":					
					conn.QueryString = "select * from mas_cluster_supervision_welcoming_call where acc_number= '" + e.Item.Cells[0].Text + "' ";
					conn.ExecuteQuery();					
					
					TXT_CUST_NAME.Text = conn.GetFieldValue("cust_name");	
					TXT_ACC_NUM.Text = conn.GetFieldValue("acc_number");	
					try{DDL_UNIT.SelectedValue = conn.GetFieldValue("unit_pelaporan");}
					catch{DDL_UNIT.SelectedValue = "";}
					TXT_TGL_PELAPORAN.Text = tool.FormatDate_Day(conn.GetFieldValue("pelaporan_date"));
					try{DDL_BLN_PELAPORAN.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("pelaporan_date")); }
					catch{DDL_BLN_PELAPORAN.SelectedValue = "";}
					TXT_THN_PELAPORAN.Text = tool.FormatDate_Year(conn.GetFieldValue("pelaporan_date"));
					try{DDL_KODE_PELAPORAN.SelectedValue = conn.GetFieldValue("pelaporan_code");}
					catch{DDL_KODE_PELAPORAN.SelectedValue = "";}
					TXT_KET.Text = conn.GetFieldValue("ket_penyimpangan");					
					break;

				case "send_data":
					conn.QueryString = "update mas_cluster_supervision_welcoming_call set flag='2', sending_date_penyimpangan=getdate() where acc_number= '" + e.Item.Cells[0].Text + "' ";
					conn.ExecuteQuery();					
					ClearData();					
					ViewData();
					ViewData2();
					break;
			}
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec mas_cluster_supervision_welcoming_call_update '" +
				TXT_ACC_NUM.Text + "', '" +
				DDL_UNIT.SelectedValue + "', " +
				tool.ConvertDate(TXT_TGL_PELAPORAN.Text, DDL_BLN_PELAPORAN.SelectedValue, TXT_THN_PELAPORAN.Text) + ", '" +
				DDL_KODE_PELAPORAN.SelectedValue + "', '" +
				TXT_KET.Text + "' ";
			conn.ExecuteQuery();
			ClearData();					
			ViewData();
		}
	}
}
