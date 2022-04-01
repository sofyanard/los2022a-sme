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
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.DTBO
{
	/// <summary>
	/// Summary description for ListDTBO.
	/// </summary>
	public partial class ListDTBO : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.204.9.78;Initial Catalog=SME;uid=sa;pwd="); asdfas
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				// Munculkan pesan next step
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"] != null) 
					GlobalTools.popMessage(this, Request.QueryString["msg"]);


				LBL_TC.Text = Request.QueryString["tc"];
				DDL_AP_SIGNDATEMONTH1.Items.Add(new ListItem ("- PILIH -", ""));
				DDL_AP_SIGNDATEMONTH2.Items.Add(new ListItem ("- PILIH -", ""));

				string nm_bln;
				for (int i=1; i<=12; i++)
				{
					nm_bln = DateAndTime.MonthName(i, false);
					DDL_AP_SIGNDATEMONTH1.Items.Add(new ListItem (nm_bln, i.ToString()));
					DDL_AP_SIGNDATEMONTH2.Items.Add(new ListItem (nm_bln, i.ToString()));
				}

				// show all data
				ViewAllData();
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
			this.DGR_LIST.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_LIST_PageIndexChanged);

		}
		#endregion

		/* view all data */
		private void ViewAllData()
		{
			string sql;  // query to fetch all data
			sql = "select * from VW_LISTDTBO where 1=1 ";
			sql = sql + " and ap_currtrack='" + Request.QueryString["tc"] + "' and AP_REJECT = '0' and RM='" + Session["UserID"].ToString() + "'";
			conn.QueryString = sql;
			try 
			{
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Server Error !");
				return;
			}

			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_LIST.DataSource = data;
			DGR_LIST.DataBind();

			for (int i = 0; i < DGR_LIST.Items.Count; i++)
				DGR_LIST.Items[i].Cells[3].Text = tool.FormatDate(DGR_LIST.Items[i].Cells[3].Text, true);
		}

		private void ViewData()
		{
			string sql;
			//sql = "select * from VW_LISTCUST where 1=1 ";
			sql = "select * from VW_LISTDTBO where 1=1 ";
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
			sql = sql + " and ap_currtrack='" + Request.QueryString["tc"] + "' and AP_REJECT = '0' and RM='" + Session["UserID"].ToString() + "'";
			conn.QueryString = sql;
			try 
			{
				conn.ExecuteQuery();
			} 
			catch (ApplicationException) 
			{
				GlobalTools.popMessage(this, "Input tidak valid !");
				return;
			}
			catch (FormatException) 
			{
				GlobalTools.popMessage(this, "Input tidak valid !");
				return;
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Server Error !");
				return;
			}

			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_LIST.DataSource = data;
			DGR_LIST.DataBind();

			for (int i = 0; i < DGR_LIST.Items.Count; i++)
				DGR_LIST.Items[i].Cells[3].Text = tool.FormatDate(DGR_LIST.Items[i].Cells[3].Text, true);


		}
		private void DGR_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// *** VIEW DTBO ***
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					Response.Redirect("DTBO.aspx?regno="+ e.Item.Cells[0].Text +"&curef="+ e.Item.Cells[2].Text +"&tc="+ LBL_TC.Text + "&mc=" + Request.QueryString["mc"]);
					break;
			}
		}

		protected void BTN_CARI_Click(object sender, System.EventArgs e)
		{
			ViewData();
		}

		private void DGR_LIST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_LIST.CurrentPageIndex = e.NewPageIndex;
			ViewData();

		}

		protected void DGR_LIST_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
