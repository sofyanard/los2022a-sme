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

namespace SME.Legal
{
	/// <summary>
	/// Summary description for ListDisbursement.
	/// </summary>
	public partial class ListDisbursement : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_TC.Text = Request.QueryString["tc"];

				Tools.initDateForm(txt_Date, ddl_Month, txt_Year, true);
				txt_Date.Text = "";
				txt_Year.Text = "";
				Tools.initDateForm(txt_Date1, ddl_Month1, txt_Year1, true);
				txt_Date1.Text = "";
				txt_Year1.Text = "";

				DataTable DTBO = new DataTable();
				this.DGR_LIST.DataSource = new DataView(DTBO);
				DGR_LIST.DataBind();

				// Munculkan pesan next step
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"] != null) 
					GlobalTools.popMessage(this, Request.QueryString["msg"]);
				
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

		private void ViewAllData()
		{
			DataTable DTBO = new DataTable();
			DataRow datrow;
			DTBO.Columns.Add(new DataColumn("AP_REGNO"));
			DTBO.Columns.Add(new DataColumn("CU_REF"));
			DTBO.Columns.Add(new DataColumn("CU_NAME"));
			DTBO.Columns.Add(new DataColumn("AP_RELMNGR"));
			DTBO.Columns.Add(new DataColumn("AP_SIGNDATE"));
			DTBO.Columns.Add(new DataColumn("AP_CO"));
			
			// menggabung data PERSONAL maupun COMPANY
//			conn.QueryString = "SELECT AP_REGNO, CU_REF, NAME, SU_FULLNAME, AP_SIGNDATE, AP_CO FROM VW_LISTCUSTOMER_PERSONAL WHERE ap_currtrack = '" + Request.QueryString["tc"] + "' and (ap_co='" + Session["UserID"].ToString() + "' or ap_co is null)" ;
//			conn.QueryString += " UNION SELECT AP_REGNO, CU_REF, CU_COMPNAME, SU_FULLNAME, AP_SIGNDATE, AP_CO FROM VW_LISTCUSTOMER_COMPANY WHERE ap_currtrack = '" + Request.QueryString["tc"] + "' and (ap_co='" + Session["UserID"].ToString() + "' or ap_co is null)";

			//conn.QueryString = "SELECT AP_REGNO, CU_REF, NAME, SU_FULLNAME, AP_SIGNDATE, AP_CO FROM VW_DISBURSEMENT_CUSTPERSONAL_LIST WHERE ap_currtrack = '" + Request.QueryString["tc"] + "' and (ap_co='" + Session["UserID"].ToString() + "' or ap_co is null)" ;
			//conn.QueryString += " UNION SELECT AP_REGNO, CU_REF, CU_COMPNAME, SU_FULLNAME, AP_SIGNDATE, AP_CO FROM VW_DISBURSEMENT_CUSTCOMPANY_LIST WHERE ap_currtrack = '" + Request.QueryString["tc"] + "' and (ap_co='" + Session["UserID"].ToString() + "' or ap_co is null)";

            conn.QueryString = "SELECT AP_REGNO, CU_REF, NAME, SU_FULLNAME, AP_SIGNDATE, AP_CO FROM VW_DISBURSEMENT_CUSTPERSONAL_LIST WHERE ap_currtrack = '" + Request.QueryString["tc"] + "' and BRANCH_CODE = '" + Session["BranchID"].ToString() + "'";
            conn.QueryString += " UNION SELECT AP_REGNO, CU_REF, CU_COMPNAME, SU_FULLNAME, AP_SIGNDATE, AP_CO FROM VW_DISBURSEMENT_CUSTCOMPANY_LIST WHERE ap_currtrack = '" + Request.QueryString["tc"] + "' and BRANCH_CODE = '" + Session["BranchID"].ToString() + "'";
			conn.ExecuteQuery();

			for (int i =0; i < conn.GetRowCount(); i++) 
			{
				datrow = DTBO.NewRow();
				datrow[0] = conn.GetFieldValue(i,0);
				datrow[1] = conn.GetFieldValue(i,1);
				datrow[2] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,2);
				datrow[3] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,3);
				datrow[4] = tools.FormatDate(conn.GetFieldValue(i,4),true);	
				DTBO.Rows.Add(datrow);
			}
			this.DGR_LIST.DataSource = new DataView(DTBO);
			DGR_LIST.DataBind();
		}

		private void ViewData()
		{
			DataTable DTBO = new DataTable();
			DataRow datrow;
			DTBO.Columns.Add(new DataColumn("AP_REGNO"));
			DTBO.Columns.Add(new DataColumn("CU_REF"));
			DTBO.Columns.Add(new DataColumn("CU_NAME"));
			DTBO.Columns.Add(new DataColumn("AP_RELMNGR"));
			DTBO.Columns.Add(new DataColumn("AP_SIGNDATE"));
			DTBO.Columns.Add(new DataColumn("AP_CO"));
			//DTBO.Columns.Add(new DataColumn("APPTYPE"));
			
			//Customer Personal			
			string sqlCondPersonal = "WHERE(";
			string sjoin = RDB_COND.SelectedValue;

			if (txt_IdCard.Text.Trim() != "")
				sqlCondPersonal = sqlCondPersonal + " CU_IDCARDNUM like '%" + txt_IdCard.Text + "%' " + sjoin;
			if (txt_NPWP.Text.Trim() != "")
				sqlCondPersonal = sqlCondPersonal + " CU_NPWP like '%" + txt_NPWP.Text + "%' " + sjoin;
			if (txt_Name.Text.Trim() != "")
				sqlCondPersonal = sqlCondPersonal + " NAME like '%" + txt_Name.Text + "%' " + sjoin;
			if (txt_ProsID.Text.Trim() != "")
				sqlCondPersonal = sqlCondPersonal + " AP_REGNO like '%" + txt_ProsID.Text + "%' " + sjoin;
			if ( ((txt_Date.Text.Trim() != "") && (txt_Year.Text.Trim() != "")) && ((txt_Date1.Text.Trim() != "") && (txt_Year1.Text.Trim() != "")) )
				sqlCondPersonal = sqlCondPersonal + " AP_RECVDATE BETWEEN '" + Tools.toSQLDate(txt_Date, ddl_Month, txt_Year) + "' and '"+ Tools.toSQLDate(txt_Date1, ddl_Month1, txt_Year1) +"' " + sjoin;
			if (sqlCondPersonal == "WHERE(") 
				sqlCondPersonal = "";
			else
			{
				sqlCondPersonal = sqlCondPersonal.Substring(0, sqlCondPersonal.Length - sjoin.Length);
				sqlCondPersonal = sqlCondPersonal + ")";
			}

			//Customer Company
			string sqlCondCompany = "WHERE(";			
			if (txt_NPWP.Text.Trim() != "")
				sqlCondCompany = sqlCondCompany + " CU_COMPNPWP like '%" + txt_NPWP.Text + "%' " + sjoin;
			if (txt_Name.Text.Trim() != "")
				sqlCondCompany = sqlCondCompany + " CU_COMPNAME like '%" + txt_Name.Text + "%' " + sjoin;
			if (txt_ProsID.Text.Trim() != "")
				sqlCondCompany = sqlCondCompany + " AP_REGNO like '%" + txt_ProsID.Text + "%' " + sjoin;
			if ( ((txt_Date.Text.Trim() != "") && (txt_Year.Text.Trim() != "")) && ((txt_Date1.Text.Trim() != "") && (txt_Year1.Text.Trim() != "")) )
				sqlCondCompany = sqlCondCompany + " AP_RECVDATE BETWEEN '" + Tools.toSQLDate(txt_Date, ddl_Month, txt_Year) + "' and '"+ Tools.toSQLDate(txt_Date1, ddl_Month1, txt_Year1) +"' " + sjoin;
			if (sqlCondCompany == "WHERE(") 
				sqlCondCompany = "";
			else
			{
				sqlCondCompany = sqlCondCompany.Substring(0, sqlCondCompany.Length - sjoin.Length);
				sqlCondCompany = sqlCondCompany + ")";
			}

			if (sqlCondPersonal != "") 
			{
				//personal
				conn.QueryString = "SELECT * FROM VW_DISBURSEMENT_CUSTPERSONAL_LIST " + sqlCondPersonal + " and ap_currtrack = '" + Request.QueryString["tc"] + "' and (ap_co='" + Session["UserID"].ToString() + "' or ap_co is null)" ;
				conn.ExecuteQuery();
				for (int i =0; i < conn.GetRowCount(); i++) 
				{
					datrow = DTBO.NewRow();
					datrow[0] = conn.GetFieldValue(i,0);
					datrow[1] = conn.GetFieldValue(i,1);
					datrow[2] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,2);
					datrow[3] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,5);
					datrow[4] = tools.FormatDate(conn.GetFieldValue(i,3),true);	
					datrow[5] = conn.GetFieldValue(i,14);
					DTBO.Rows.Add(datrow);
				}
			}

			if (sqlCondCompany != "") 
			{
				//company
				conn.QueryString = "SELECT * FROM VW_DISBURSEMENT_CUSTCOMPANY_LIST " + sqlCondCompany + " and ap_currtrack = '" + Request.QueryString["tc"] + "' and (ap_co='" + Session["UserID"].ToString() + "' or ap_co is null)";
				conn.ExecuteQuery();
				for (int i =0; i < conn.GetRowCount(); i++) 
				{
					datrow = DTBO.NewRow();
					datrow[0] = conn.GetFieldValue(i,0);
					datrow[1] = conn.GetFieldValue(i,1);
					datrow[2] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,2);
					datrow[3] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,5);
					datrow[4] = tools.FormatDate(conn.GetFieldValue(i,3),true);	
					datrow[5] = conn.GetFieldValue(i,13);
					DTBO.Rows.Add(datrow);

				}
			}
			this.DGR_LIST.DataSource = new DataView(DTBO);
			DGR_LIST.DataBind();

			/*
			 * 
			string sql="";
			if (!TXT_AP_REGNO.Text.Equals("")) 
				sql = " where ap_regno='"+TXT_AP_REGNO.Text+"'";
			conn.QueryString = "select distinct ap_regno, cu_ref, cu_name, ap_signdate, cu_rm, apptype "+
				"from VW_CUST_COMP_PRODUCT "+sql;
			conn.ExecuteQuery();
			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_LIST.DataSource = data;
			DGR_LIST.DataBind();
			for (int i = 0; i < DGR_LIST.Items.Count; i++)
				DGR_LIST.Items[i].Cells[4].Text = tools.FormatDate(DGR_LIST.Items[i].Cells[4].Text, true);
				
			*/
		}

		private void DGR_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "undo":
					break;
				case "view":
					if (e.Item.Cells[10].Text == "&nbsp;")
					{
						conn.QueryString = "update application set ap_co='" + Session["UserID"].ToString() + "' where ap_regno='" + e.Item.Cells[0].Text + "'";
						conn.ExecuteNonQuery();
					}
					Response.Redirect("Disbursement.aspx?regno="+ e.Item.Cells[0].Text +"&curef=" + e.Item.Cells[1].Text + "&tc="+ LBL_TC.Text+"&mc=" + Request.QueryString["mc"]);
					break;
			}
		}

		private void DGR_LIST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_LIST.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			DGR_LIST.CurrentPageIndex = 0;
			ViewData();
		}

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			this.ViewData();
		}
	}
}
