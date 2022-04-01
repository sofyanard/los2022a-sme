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

namespace SME.BGSpan
{
	/// <summary>
	/// Summary description for CustomerList.
	/// </summary>
	public class CustomerList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TXT_CU_CIF;
		protected System.Web.UI.WebControls.TextBox txt_Name;
		protected System.Web.UI.WebControls.TextBox txt_IdCard;
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected System.Web.UI.WebControls.DropDownList DDL_CU_DOB_MM;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.TextBox txt_NPWP;
		protected System.Web.UI.WebControls.Button btn_Find;
		protected System.Web.UI.WebControls.Button BTN_NEW;
		protected System.Web.UI.WebControls.DataGrid DatGrd;
		protected System.Web.UI.WebControls.Label Label1;
		protected Connection conn;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");
			
			if (!IsPostBack)
			{
				// menampilkan string pesan jika ada
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"] != null)
					GlobalTools.popMessage(this, Request.QueryString["msg"]);

				for (int i = 1; i <= 12; i++)
					DDL_CU_DOB_MM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));

				conn.QueryString = "select cu_ref, cu_cif, comptypedesc + ' ' + cu_compname as cust_name, cu_npwp from vw_cust_company where 1 = 2 ";		//do not auto load anything.. 
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
			this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
			this.BTN_NEW.Click += new System.EventHandler(this.BTN_NEW_Click);
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btn_Find_Click(object sender, System.EventArgs e)
		{
			bool stop = false;

			if (TXT_CU_CIF.Text != "")
			{
				conn.QueryString = "select cu_custtypeid, cu_cif from customer where cu_cif='" + TXT_CU_CIF.Text + "'";
				try 
				{
					conn.ExecuteQuery();
				} 
				catch (Exception) 
				{
					return;
				}

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
			{ //sdfasdf
				conn.QueryString = "select cu_custtypeid, cu_npwp from customer where cu_npwp='" + txt_NPWP.Text + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() != 0)
				{
					if (conn.GetFieldValue("CU_CUSTTYPEID") == "01")
						conn.QueryString = "select cu_ref, cu_cif, comptypedesc + ' ' + cu_compname as cust_name, cu_npwp from vw_cust_company where cu_npwp='" + txt_NPWP.Text + "'";
					else if (conn.GetFieldValue("CU_CUSTTYPEID") == "02")
						conn.QueryString = "select cu_ref, cu_cif, cu_firstname + ' ' + cu_middlename + ' ' + cu_lastname as cust_name, cu_npwp from vw_cust_personal where cu_npwp='" + txt_NPWP.Text + "'";
					
					conn.ExecuteQuery();
					FillGrid();
				}
				stop = true;
			}

			else if (stop == false && txt_Name.Text != "")
			{
				/*
				conn.QueryString = "select cu_ref, cu_cif, cu_firstname + ' ' + cu_middlename + ' ' + cu_lastname as cust_name, cu_npwp from vw_cust_personal where cu_firstname like '%" + txt_Name.Text + "%' or cu_middlename like '%" + txt_Name.Text + "%' or cu_lastname like '%" + txt_Name.Text + "%'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() != 0)
					FillGrid();
				
				conn.QueryString = "select cu_ref, cu_cif, cu_compname as cust_name, cu_npwp from vw_cust_company where cu_compname like '%" + txt_Name.Text + "%'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() != 0)
					FillGrid();
			  */
				conn.QueryString = "select cu_ref, cu_cif, cu_firstname + ' ' + isnull(cu_middlename,'') + ' ' + isnull(cu_lastname,'') as cust_name, cu_npwp from vw_cust_personal where cu_firstname like '%" + txt_Name.Text + "%' or cu_middlename like '%" + txt_Name.Text + "%' or cu_lastname like '%" + txt_Name.Text + "%'";
				conn.QueryString += " union select cu_ref, cu_cif, cu_compname as cust_name, cu_npwp from vw_cust_company where cu_compname like '%" + txt_Name.Text + "%'";
				conn.ExecuteQuery();
				
				//				if (conn.GetRowCount() != 0) // Saat searching, kalau tidak ada result, grid dikosongkan
				//				{
				FillGrid(); 
				//				}					
			}
		}

		private void FillGrid()
		{
			try 
			{
				DataTable dt = new DataTable();
				dt = conn.GetDataTable().Copy();
				DatGrd.DataSource = dt;
				DatGrd.DataBind();				
			} 
			catch 
			{
				Tools.popMessage(this, "Error Grid !");
				return;
			}
		}


		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string user = "";
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
					//conn.QueryString = "select cu_rm from customer where cu_ref='" + e.Item.Cells[0].Text + "'";
					conn.QueryString = "select customer.cu_rm, scuser.su_fullname, scuser.su_hpnum from customer left join " + 
						"scuser on customer.cu_rm = scuser.userid where cu_ref='" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					user = Session["UserID"].ToString();
					if ((conn.GetFieldValue(0,0) == "") || (conn.GetFieldValue(0,0) == Session["UserID"].ToString()))
					{
						//Generate AP_REGNO
						conn.QueryString = "exec GENERATE_ID '" + Session["BranchID"].ToString() + "', '0'";
						conn.ExecuteQuery();

						Response.Redirect("GeneralInfo.aspx?regno=" + conn.GetFieldValue(0,0) + "&curef=" + e.Item.Cells[0].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&exist=1");
					}
					else
					{
						Response.Write("<script language='javascript'>alert('" + "This customer is owned by: " + conn.GetFieldValue("su_fullname") + " (" + conn.GetFieldValue("su_hpnum") + ")" + "');</script>");
					}
					break;
			}
		}

		private void BTN_NEW_Click(object sender, System.EventArgs e)
		{
			//
			// Generate REGNO dan CUREF
			//
			conn.QueryString = "exec GENERATE_ID '" + Session["BranchID"].ToString() + "', '2'";
			conn.ExecuteQuery();
			Response.Redirect("GeneralInfo.aspx?regno=" + conn.GetFieldValue(0,0) + "&curef=" + conn.GetFieldValue(0,1) + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&exist=0");
		}

	}
}
