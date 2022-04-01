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

namespace SME.HistoricalLoanInfo
{
	/// <summary>
	/// Summary description for SearchCustomer.
	/// </summary>
	public partial class SearchCustomer : System.Web.UI.Page
	{
		protected Connection conn;
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				GlobalTools.initDateForm(TXT_CU_DOB_DD, DDL_CU_DOB_MM, TXT_CU_DOB_YYYY);
			
				conn.QueryString = "select cu_ref, cu_cif, comptypedesc + ' ' + cu_compname as cust_name, cu_npwp from vw_cust_company where cu_cif='00'";
				conn.ExecuteQuery();
				FillGrid();
			}

            btn_Find.Click += new EventHandler(btn_Find_Click);

			GlobalTools.SetFocus(this, txt_Name);
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
			conn.QueryString = "exec SP_GETCUSTLOANHISTORYFILTER " + 
				GlobalTools.ConvertNull(TXT_CU_CIF.Text.Trim()) + ", " + 
				GlobalTools.ConvertNull(txt_Name.Text.Trim()) + ", " + 
				GlobalTools.ConvertNull(txt_IdCard.Text.Trim()) + ", null, " + 
				GlobalTools.ConvertNull(txt_NPWP.Text.Trim()) + ", '" + 
				(string) Session["AreaID"] + "', '" + 
				(string) Session["CBC"] + "', '" + 
				(string) Session["BranchID"] + "', '" + 
				(string) Session["UserID"] + "'";
			conn.ExecuteQuery();

			Response.Write("<!-- query: " + conn.QueryString.ToString() + " -->");

			FillGrid();


			/*
			bool stop = false;

			if (TXT_CU_CIF.Text != "")
			{
				conn.QueryString = "select CU_CUSTTYPEID, CU_CIF from VW_CUSTOMER_HISTORY where cu_cif = '" + TXT_CU_CIF.Text + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() != 0)
				{
					
					if (conn.GetFieldValue("CU_CUSTTYPEID") == "01")
						conn.QueryString = "select CU_REF, CU_CIF, COMPTYPEDESC + ' ' + CU_COMPNAME AS CUST_NAME, CU_NPWP from vw_cust_company where cu_cif = '" + TXT_CU_CIF.Text + "'";
					else if (conn.GetFieldValue("CU_CUSTTYPEID") == "02")
						conn.QueryString = "select CU_REF, CU_CIF, CU_FIRSTNAME + ' ' + CU_MIDDLENAME + ' ' + CU_LASTNAME AS CUST_NAME, CU_NPWP from vw_cust_personal where cu_cif = '" + TXT_CU_CIF.Text + "'";
										
					conn.ExecuteQuery();
					FillGrid();
				}
				stop = true;
			}

			else if (stop == false && txt_IdCard.Text != "")
			{
				conn.QueryString = "select CU_REF, CU_CIF, CU_FIRSTNAME + ' ' + CU_MIDDLENAME + ' ' + CU_LASTNAME AS CUST_NAME, CU_NPWP from vw_cust_personal_history where cu_idcardnum='" + txt_IdCard.Text + "'";
				conn.ExecuteQuery();
				FillGrid();
				stop = true;
			}

			else if (stop == false && txt_NPWP.Text != "")
			{
				conn.QueryString = "select CU_CUSTTYPEID, CU_NPWP from VW_CUSTOMER_HISTORY where cu_npwp = '" + txt_NPWP.Text + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() != 0)
				{
					if (conn.GetFieldValue("CU_CUSTTYPEID") == "01")
						conn.QueryString = "select CU_REF, CU_CIF, COMPTYPEDESC + ' ' + CU_COMPNAME AS CUST_NAME, CU_NPWP AS CUST_NAME from vw_cust_company_history where cu_npwp='" + txt_NPWP.Text + "'";
					else if (conn.GetFieldValue("CU_CUSTTYPEID") == "02")
						conn.QueryString = "select CU_REF, CU_CIF, CU_FIRSTNAME + ' ' + CU_MIDDLENAME + ' ' + CU_LASTNAME AS CUST_NAME, CU_NPWP from vw_cust_personal_history where cu_npwp='" + txt_NPWP.Text + "'";
					conn.ExecuteQuery();
					FillGrid();
				}
				stop = true;
			}

			else if (stop == false && txt_Name.Text != "")
			{
				conn.QueryString = "select CU_REF, CU_CIF, CU_FIRSTNAME + ' ' + CU_MIDDLENAME + ' ' + CU_LASTNAME AS CUST_NAME, CU_NPWP from vw_cust_personal_history where cu_firstname like '%" + txt_Name.Text + "%' or cu_middlename like '%" + txt_Name.Text + "%' or cu_lastname like '%" + txt_Name.Text + "%' "+
					" union "+
					"select CU_REF, CU_CIF, COMPTYPEDESC + ' ' + CU_COMPNAME AS CUST_NAME, CU_NPWP from vw_cust_company_history where cu_compname like '%" + txt_Name.Text + "%'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() != 0)
					FillGrid();				
			}
			*/

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
					Response.Redirect("HistoricalLoanList.aspx?" + 
						"curef=" + e.Item.Cells[0].Text + 
						"&mc=" + Request.QueryString["mc"]);
					break;
			}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}
	}
}
