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

namespace SME.DocumentTracking
{
	/// <summary>
	/// Summary description for SearchCustomer.
	/// </summary>
	public partial class ListDocTrack : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TXT_CU_CIF;
		protected System.Web.UI.WebControls.Button BTN_NEW;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn;
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
//				for (int i = 1; i <= 12; i++)
//					DDL_CU_DOB_MM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
//				conn.QueryString = "select cu_ref, cu_cif, comptypedesc + ' ' + cu_compname as cust_name, cu_npwp from vw_cust_company where cu_cif='00'";
//				conn.ExecuteQuery();
//				FillGrid();
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

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			DatGrd.CurrentPageIndex = 0;
			SearchData();
		}

		private void SearchData()
		{
			string str;
			str=" select * from vw_listdoctrack " +
			" where ap_username='" + Session["UserID"].ToString() + 
			"' or ap_ca='" + Session["UserID"].ToString()  +  "'";
			if(TXT_REGNO.Text!="") 
			{
				str=" select * from vw_listdoctrack " +
				" where ap_regno='" + TXT_REGNO.Text + "'";
			}
			conn.QueryString=str;
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
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
					Response.Redirect("DocTerima.aspx?regno=" + e.Item.Cells[0].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
				break;
			}
		}

		private void BTN_NEW_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec GENERATE_ID '" + Session["BranchID"].ToString() + "', '1'";
			conn.ExecuteQuery();
			Response.Redirect("InfoCustomer.aspx?sta=baru&curef=" + conn.GetFieldValue(0,0) + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}
	}
}
