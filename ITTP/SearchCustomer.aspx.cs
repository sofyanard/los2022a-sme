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

namespace SME.ITTP
{
	/// <summary>
	/// Summary description for SearchCustomer.
	/// </summary>
	public partial class SearchCustomer : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox c;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn;
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				for (int i = 1; i <= 12; i++)
					DDL_CU_DOB_MM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				conn.QueryString = "select cu_ref, cu_cif, comptypedesc + ' ' + cu_compname as cust_name, cu_npwp from vw_cust_company where cu_cif='00'";
				conn.ExecuteQuery();
				FillGrid();
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
			bool stop = false;

			if (TXT_CU_CIF.Text != "")
			{
				conn.QueryString = "select cu_custtypeid, cu_cif from customer where cu_cif='" + TXT_CU_CIF.Text + "'";
				conn.ExecuteQuery();
//				if (conn.GetRowCount() != 0) // Saat searching, kalau tidak ada result, grid dikosongkan
//				{
					if (conn.GetFieldValue("CU_CUSTTYPEID") == "01")
					conn.QueryString = "select cu_ref, cu_cif, comptypedesc + ' ' + cu_compname as cust_name, cu_npwp from vw_cust_company where cu_cif='" + TXT_CU_CIF.Text + "'";
					else if (conn.GetFieldValue("CU_CUSTTYPEID") == "02")
					conn.QueryString = "select cu_ref, cu_cif, cu_firstname + ' ' + cu_middlename + ' ' + cu_lastname as cust_name, cu_npwp from vw_cust_personal where cu_cif='" + TXT_CU_CIF.Text + "'";
					conn.ExecuteQuery();
					FillGrid();
//				}
				stop = true;
			}

			else if (stop == false && txt_IdCard.Text != "")
			{
				conn.QueryString = "select cu_ref, cu_cif, cu_firstname + ' ' + cu_middlename + ' ' + cu_lastname as cust_name, cu_npwp from vw_cust_personal where cu_idcardnum='" + txt_IdCard.Text + "'";
				conn.ExecuteQuery();
				FillGrid();
				stop = true;
			}

			else if (stop == false && txt_NPWP.Text != "")
			{
				conn.QueryString = "select cu_custtypeid, cu_npwp from customer where cu_npwp='" + txt_NPWP.Text + "'";
				conn.ExecuteQuery();
//				if (conn.GetRowCount() != 0)
//				{
					if (conn.GetFieldValue("CU_CUSTTYPEID") == "01")
						conn.QueryString = "select cu_ref, cu_cif, comptypedesc + ' ' + cu_compname as cust_name, cu_npwp as cust_name from vw_cust_company where cu_npwp='" + txt_NPWP.Text + "'";
					else if (conn.GetFieldValue("CU_CUSTTYPEID") == "02")
						conn.QueryString = "select cu_ref, cu_cif, cu_firstname + ' ' + cu_middlename + ' ' + cu_lastname as cust_name, cu_npwp from vw_cust_personal where cu_npwp='" + txt_NPWP.Text + "'";
					conn.ExecuteQuery();
					FillGrid();
//				}
				stop = true;
			}

			else if (stop == false && txt_Name.Text != "")
			{
				conn.QueryString = "select cu_ref, cu_cif, cu_firstname + ' ' + cu_middlename + ' ' + cu_lastname as cust_name, cu_npwp from vw_cust_personal where cu_firstname like '%" + txt_Name.Text + "%' or cu_middlename like '%" + txt_Name.Text + "%' or cu_lastname like '%" + txt_Name.Text + "%' "+
					" union "+
					"select cu_ref, cu_cif, cu_compname as cust_name, cu_npwp from vw_cust_company where cu_compname like '%" + txt_Name.Text + "%'";
				conn.ExecuteQuery();
//				if (conn.GetRowCount() != 0)
					FillGrid();				
			}
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
					//conn.QueryString = "select cu_rm from customer where cu_ref='" + e.Item.Cells[0].Text + "'";
					//Generate AP_REGNO
					conn.QueryString = "exec IT_GENERATE_ID '" + Session["BranchID"].ToString() + "', '0'";
					conn.ExecuteQuery();
	
					Response.Redirect("ProcessBPR.aspx?sta=exist&curef=" + e.Item.Cells[0].Text  + "&regno=" + conn.GetFieldValue(0,0) + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]+"&exist=1");
					break;					
			}
		}

		protected void BTN_NEW_Click(object sender, System.EventArgs e)
		{
//			conn.QueryString = "exec GENERATE_CUREF '" + Session["BranchID"] + "'";sdf
			conn.QueryString = "exec IT_GENERATE_ID '" + Session["BranchID"].ToString() + "', '2'";
//			conn.QueryString = "exec GENERATE_ID '10111', '1'";
			conn.ExecuteQuery();
			Response.Redirect("InitiationMain.aspx?sta=baru&curef=" + conn.GetFieldValue(0,1) + "&regno=" + conn.GetFieldValue(0,0) + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

	}
}
