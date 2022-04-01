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
using System.Globalization;
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.DTBO
{
	/// <summary>
	/// Summary description for ListDTBO.
	/// </summary>
	public partial class ListBlackList : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_TC.Text = Request.QueryString["tc"];
				DDL_AP_SIGNDATEMONTH1.Items.Add(new ListItem ("-- Plih --", ""));
				DDL_AP_SIGNDATEMONTH2.Items.Add(new ListItem ("-- Plih --", ""));

				string nm_bln;
				for (int i=1; i<=12; i++)
				{
					//nm_bln = DateAndTime.MonthName(i, false);
					nm_bln = DateTimeFormatInfo.CurrentInfo.GetMonthName(i);
					DDL_AP_SIGNDATEMONTH1.Items.Add(new ListItem (nm_bln, i.ToString()));
					DDL_AP_SIGNDATEMONTH2.Items.Add(new ListItem (nm_bln, i.ToString()));
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
			this.DGR_LIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_LIST_ItemCommand);

		}
		#endregion


		private void ViewData()
		{
			string sql;
			sql = "select * from VW_LISTCUST where 1=1 ";
			if (TXT_CU_NAME.Text != "")
				sql = sql + " and CU_NAME like '%"+ TXT_CU_NAME.Text +"%' ";
			if (TXT_AP_REGNO.Text != "")
				sql = sql + " and AP_REGNO = '"+ TXT_AP_REGNO.Text +"' ";
			if (TXT_CU_REF.Text != "")
				sql = sql + " and CU_REF = '"+ TXT_CU_REF.Text +"' ";
			if (TXT_AP_SIGNDATEDAY1.Text != "")
			{
				string AP_SIGNDATE1 = tool.ConvertDate(TXT_AP_SIGNDATEDAY1.Text, DDL_AP_SIGNDATEMONTH1.SelectedValue, TXT_AP_SIGNDATEYEAR1.Text);
				string AP_SIGNDATE2 = tool.ConvertDate(TXT_AP_SIGNDATEDAY2.Text, DDL_AP_SIGNDATEMONTH2.SelectedValue, TXT_AP_SIGNDATEYEAR2.Text);
				sql = sql + " and AP_SIGNDATE between "+ AP_SIGNDATE1 +" and "+ AP_SIGNDATE2 +" ";
			}
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_LIST.DataSource = data;
			try 
			{
				DGR_LIST.DataBind();		
			} 
			catch 
			{
				DGR_LIST.CurrentPageIndex = 0;
				DGR_LIST.DataBind();
			}

		}
		private void DGR_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// *** VIEW DTBO ***
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					Response.Redirect("BL_result.aspx?regno="+ e.Item.Cells[1].Text +"&curef="+ e.Item.Cells[2].Text +"&tc="+ LBL_TC.Text);
					break;
			}
		}

		protected void BTN_CARI_Click(object sender, System.EventArgs e)
		{
			ViewData();
		}

		protected void DGR_LIST_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
