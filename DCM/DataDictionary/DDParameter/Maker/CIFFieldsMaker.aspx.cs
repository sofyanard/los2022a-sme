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
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;

namespace SME.DCM.Data_Dictionary.DD_Parameter.Maker
{
	/// <summary>
	/// Summary description for CIFFieldsMaker.
	/// </summary>
	public partial class CIFFieldsMaker : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected System.Web.UI.WebControls.TextBox TXT_PROBNAME;
		protected System.Web.UI.WebControls.DataGrid Dgr_RequestStage;
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				ViewExisitingParameter();
				ViewRequestingParameter();
				GenerateCode();
			}
		}

		private void GenerateCode()
		{
			string year = System.DateTime.Now.Year.ToString();
			year.Remove(0,2);
			string month  = System.DateTime.Now.Month.ToString();
			string day = System.DateTime.Now.Day.ToString();
			string second = System.DateTime.Now.Second.ToString();

			if(second.Length == 1)
			{
				second = "0" + second;
			}

			TXT_CODE.Text = year + month + day + second;
		}

		private void ViewExisitingParameter()
		{
			BindData("Dgr_CurrStage", "SELECT * FROM VW_DD_FIELDS_CIF");
		}

		private void ViewRequestingParameter()
		{
			BindData("DgRequesting", "SELECT * FROM VW_DD_FIELDS_CIF_TEMP");
		}

		private void MakeVisibleDeleteUndelete(System.Web.UI.WebControls.DataGrid dg)
		{
			for(int i=0; i< dg.Items.Count; i++)
			{
				string a = dg.Items[i].Cells[3].Text.ToString();
				int num = int.Parse(dg.Items[i].Cells[3].Text.ToString());

				LinkButton toBeHidden;
				if(num == 1)
				{
					toBeHidden = ((LinkButton)dg.Items[i].Cells[4].FindControl("LNK_UNDELETE"));
					toBeHidden.Visible = false;
				}
				else if(num == 0)
				{
					toBeHidden = ((LinkButton)dg.Items[i].Cells[4].FindControl("LNK_DELETE"));
					toBeHidden.Visible = false;
				}
			}
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();

				System.Data.DataTable dt = new System.Data.DataTable();
				dt = conn.GetDataTable().Copy();

				System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);
				dg.DataSource = dt;

				try
				{
					dg.DataBind();
				}
				catch
				{
					dg.CurrentPageIndex = dg.PageCount - 1;	
					dg.DataBind();
				}

				conn.ClearData();

				if(dg.ID == "Dgr_CurrStage")
				{
					MakeVisibleDeleteUndelete(dg);
				}
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
			this.Dgr_CurrStage.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Dgr_CurrStage_ItemCommand);
			this.Dgr_CurrStage.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.Dgr_CurrStage_PageIndexChanged);
			this.DgRequesting.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DgRequesting_ItemCommand);
			this.DgRequesting.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DgRequesting_PageIndexChanged);

		}
		#endregion

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "SELECT * FROM DD_FIELDS_CIF WHERE CODE = '" + TXT_CODE.Text + "'";
			conn.ExecuteQuery();

			string status = "";

			if(conn.GetRowCount() == 0)
			{
				status = "INSERT";
			}
			else
			{
				status = "UPDATE";
			}

			conn.QueryString = "EXEC DD_INSERT_PARAMETER 'CIF','" + TXT_CODE.Text + "','" + TXT_FIELDS_NAME.Text + "','" + TXT_FIELDS_DESCRIPTION.Text + "',1, '" + status + "'";
			conn.ExecuteQuery();
			ViewExisitingParameter();
			ViewRequestingParameter();

			GenerateCode();
			TXT_FIELDS_DESCRIPTION.Text = "";
			TXT_FIELDS_NAME.Text = "";
		}

		private void Dgr_CurrStage_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					TXT_CODE.Text = e.Item.Cells[0].Text.ToString();
					TXT_FIELDS_DESCRIPTION.Text = e.Item.Cells[2].Text.ToString();
					TXT_FIELDS_NAME.Text = e.Item.Cells[1].Text.ToString();
					break;
				case "delete":
					conn.QueryString = "EXEC DD_INSERT_PARAMETER 'CIF','" + e.Item.Cells[0].Text.ToString() + "','" + e.Item.Cells[1].Text.ToString() + "','" + e.Item.Cells[2].Text.ToString() + "',0, 'DELETE'";
					conn.ExecuteQuery();
					ViewExisitingParameter();
					ViewRequestingParameter();
					break;
				case "undelete":
					conn.QueryString = "EXEC DD_INSERT_PARAMETER 'CIF','" + e.Item.Cells[0].Text.ToString() + "','" + e.Item.Cells[1].Text.ToString() + "','" + e.Item.Cells[2].Text.ToString() + "',1, 'UNDELETE'";
					conn.ExecuteQuery();
					ViewExisitingParameter();
					ViewRequestingParameter();
					break;
			}
		}

		private void DgRequesting_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					TXT_CODE.Text = e.Item.Cells[0].Text.ToString();
					TXT_FIELDS_DESCRIPTION.Text = e.Item.Cells[2].Text.ToString();
					TXT_FIELDS_NAME.Text = e.Item.Cells[1].Text.ToString();
					break;
				case "delete":
					conn.QueryString = "DELETE DD_FIELDS_CIF_TEMP WHERE CODE = '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					ViewRequestingParameter();
					break;
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			GenerateCode();
			TXT_FIELDS_DESCRIPTION.Text = "";
			TXT_FIELDS_NAME.Text = "";
		}

		private void Dgr_CurrStage_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			Dgr_CurrStage.CurrentPageIndex = e.NewPageIndex;
			ViewExisitingParameter();
		}

		private void DgRequesting_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DgRequesting.CurrentPageIndex = e.NewPageIndex;
			ViewRequestingParameter();
		}
	}
}
