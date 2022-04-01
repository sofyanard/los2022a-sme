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

namespace SME.InitialDataEntry
{
	/// <summary>
	/// Summary description for FindCustomer.asdasd
	/// </summary>
	public partial class FindCustomer : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrd_PendingApp.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_PendingApp_ItemCommand);

		}
		#endregion

		protected void btn_Find_Click(object sender, System.EventArgs e)
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

			adjustGridLinkButton();
			FillGrid_PendingApp();
		}

		private void adjustGridLinkButton() 
		{
			for(int i=0; i<DatGrd.Items.Count; i++) 
			{
				LinkButton LinkButton1			= (LinkButton) DatGrd.Items[i].FindControl("LinkButton1");
				LinkButton LNK_CONT_PREENTRY	= (LinkButton) DatGrd.Items[i].FindControl("LNK_CONT_PREENTRY");

				//
				// Kalau TC null, berarti page ini dipanggil di Pre Initial Entry
				//
				//if (Request.QueryString["tc"] == "" || Request.QueryString["tc"] == null) 
				// Kalau TC = 1.0, berarti page ini dipanggil di Pre Initial Entry
				if (Request.QueryString["tc"] == "1.0")
				{
					LinkButton1.Visible = false;
				}
				else 
				{
					LNK_CONT_PREENTRY.Visible = false;
				}
			}
		}

		private void FillGrid_PendingApp() 
		{			
			try 
			{				
				//conn.QueryString = "select * from VW_IDE_PENDINGAPPLIST where PRE_RMUSER = '" + Session["UserID"].ToString() + "' and PRE_ISPROCESSED = '0'";
                conn.QueryString = "SELECT * FROM VW_IDE_PENDINGAPPLIST WHERE ((PRE_RMUSER = '" + Session["UserID"].ToString() + "') OR (ISNULL(PRE_RMUSER,'') = '' AND PRE_APPUNIT = '" + Session["BranchID"].ToString() + "')) AND PRE_ISPROCESSED = '0'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			DatGrd_PendingApp.DataSource = conn.GetDataTable().DefaultView;
			DatGrd_PendingApp.DataBind();

			//20080824, add for pipeline copoprate
			if (Request.QueryString["tc"] == "1.0")
			{
				DatGrd_PendingApp.Columns[7].Visible = false;
				DatGrd_PendingApp.Columns[8].Visible = true;
			}
			else
			{
				DatGrd_PendingApp.Columns[7].Visible = true;
				DatGrd_PendingApp.Columns[8].Visible = false;
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

				case "View2":
					Response.Redirect("PreInitialEntry.aspx?" + 
						"mc=" + Request.QueryString["mc"] + 
						"&curef=" + e.Item.Cells[0].Text +
						"&sta=old");
					break;
			}
		}

		protected void BTN_NEW_Click(object sender, System.EventArgs e)
		{
			//
			// Generate REGNO dan CUREF
			//
			conn.QueryString = "exec GENERATE_ID '" + Session["BranchID"].ToString() + "', '2'";
			conn.ExecuteQuery();
			Response.Redirect("GeneralInfo.aspx?regno=" + conn.GetFieldValue(0,0) + "&curef=" + conn.GetFieldValue(0,1) + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&exist=0");
		}

		private void DatGrd_PendingApp_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
					/*Cek Customer di Pre Initial Entry
					conn.QueryString = "exec IDE_CEK_PRE_ENTRY '" + e.Item.Cells[0].Text + "', '" + e.Item.Cells[1].Text + "'";
					conn.ExecuteNonQuery();*/

					Response.Redirect("GeneralInfo.aspx?regno=" + e.Item.Cells[10].Text.Trim() + "&curef=" + e.Item.Cells[0].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&seq=" +e.Item.Cells[9].Text.Trim()+ "&exist=1");
					break;

				case "View2":
					Response.Redirect("PreInitialEntry.aspx?" + 
						"mc=" + Request.QueryString["mc"] + 
						"&curef=" + e.Item.Cells[0].Text +
						"&sta=old");
					break;
			}
		}

		protected void BTN_NEW_PREENTRY_Click(object sender, System.EventArgs e)
		{
			//
			// Generate CUREF
			//
			conn.QueryString = "exec GENERATE_ID '" + Session["BranchID"].ToString() + "', '1'";
			conn.ExecuteQuery();
			Response.Redirect("PreInitialEntry.aspx?" + 
				"mc=" + Request.QueryString["mc"] + 
				"&curef=" + conn.GetFieldValue(0,0) + 
				"&exist=0&sta=new");
		}
	}
}
