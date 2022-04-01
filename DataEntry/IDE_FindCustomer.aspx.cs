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

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for IDE_FindCustomer.
	/// </summary>
	public partial class IDE_FindCustomer : System.Web.UI.Page
	{

		#region " My Variables "
		protected Connection conn;
		private Tools tool = new Tools();
		private string mainregno, maincuref, tc, mc, formParent, mainprod_seq, mainproductid, controlParent, rm;
		#endregion
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			mainregno		= Request.QueryString["mainregno"];
			mainprod_seq	= Request.QueryString["mainprod_seq"];
			mainproductid	= Request.QueryString["mainproductid"];
			maincuref		= Request.QueryString["maincuref"];
			tc				= Request.QueryString["tc"];
			mc				= Request.QueryString["mc"];
			formParent		= Request.QueryString["formParent"];
			controlParent	= Request.QueryString["controlParent"];
			rm				= Request.QueryString["rm"];

			if (!IsPostBack) 
			{
				GlobalTools.initDateForm(TXT_CU_DOB_DAY, DDL_CU_DOB_MM, TXT_CU_DOB_YEAR, true);

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

		}
		#endregion

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


		protected void BTN_NEW_Click(object sender, System.EventArgs e)
		{	

			//
			// Generate REGNO dan CUREF
			//
			conn.QueryString = "exec GENERATE_ID '" + Session["BranchID"].ToString() + "', '2'";
			conn.ExecuteQuery();
			Response.Redirect("SubApplicationMain.aspx?mainregno=" + mainregno + 
								"&mainprod_seq=" + mainprod_seq +
								"&mainproductid=" + mainproductid +
								"&maincuref=" + maincuref + 
								"&regno=" + conn.GetFieldValue(0,0) + 
								"&curef=" + conn.GetFieldValue(0,1) + 
								"&tc=" + tc +
								"&mc=" + mc +
								"&rm=" + rm +
								"&formParent=" + formParent +
								"&controlParent=" + controlParent +
								"&exist=0");
		}

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
				}

				if (conn.GetRowCount() != 0)
				{
					if (conn.GetFieldValue("CU_CUSTTYPEID") == "01")
						conn.QueryString = "select cu_ref, cu_cif, comptypedesc + ' ' + cu_compname as cust_name, cu_npwp from vw_cust_company where cu_cif='" + TXT_CU_CIF.Text + "'";
					else if (conn.GetFieldValue("CU_CUSTTYPEID") == "02")
						conn.QueryString = "select cu_ref, cu_cif, cu_firstname + ' ' + cu_middlename + ' ' + cu_lastname as cust_name, cu_npwp from vw_cust_personal where cu_cif='" + TXT_CU_CIF.Text + "'";
					conn.ExecuteQuery();

					FillGrid();
				}
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
				conn.QueryString = "select cu_ref, cu_cif, cu_firstname + ' ' + cu_middlename + ' ' + cu_lastname as cust_name, cu_npwp from vw_cust_personal where cu_firstname like '%" + txt_Name.Text + "%' or cu_middlename like '%" + txt_Name.Text + "%' or cu_lastname like '%" + txt_Name.Text + "%'";
				conn.QueryString += " union select cu_ref, cu_cif, cu_compname as cust_name, cu_npwp from vw_cust_company where cu_compname like '%" + txt_Name.Text + "%'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() != 0)
					FillGrid();
			}
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
					/*
					string user = "";
					conn.QueryString = "select CUSTOMER.CU_RM, SCUSER.SU_FULLNAME, SCUSER.SU_HPNUM from CUSTOMER left join " + 
						"SCUSER on CUSTOMER.CU_RM = SCUSER.USERID where CU_REF='" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					user = Session["UserID"].ToString();
					if ((conn.GetFieldValue(0,0) == "") || (conn.GetFieldValue(0,0) == Session["UserID"].ToString()))
					{
					*/

					//////////////////////////////////////////////////////////
					///	sebelum generate regno, cek bahwa customer ybs
					///	belum pernah membuat sub application
					///	
					conn.QueryString = "select COUNT(*) JUMLAH from CUSTPRODUCT c left join APPLICATION a on c.AP_REGNO = a.AP_REGNO where MAINAP_REGNO = '" + mainregno + "' and CU_REF = '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					if (conn.GetFieldValue("JUMLAH") != "0") 
					{
						GlobalTools.popMessage(this, "Customer sudah memilik sub application!");
						return;
					}
					

					///////////////////////////////////////////////////////////
					///	Generate REGNO
					///	
					conn.QueryString = "exec GENERATE_ID '" + Session["BranchID"].ToString() + "', '0'";
					conn.ExecuteQuery();
					Response.Redirect("SubApplicationMain.aspx?mainregno=" + mainregno + 
								"&mainprod_seq=" + mainprod_seq +
								"&mainproductid=" + mainproductid +
								"&maincuref=" + maincuref + 
								"&regno=" + conn.GetFieldValue(0,0) + 
								"&curef=" + e.Item.Cells[0].Text + 
								"&tc=" + tc + 
								"&mc=" + mc + 
								"&rm=" + rm + 
								"&formParent=" + formParent +
								"&controlParent=" + controlParent +
								"&exist=1");

					/*
					}
					else
					{
						Response.Write("<script language='javascript'>alert('" + "This customer is owned by: " + conn.GetFieldValue("su_fullname") + " (" + conn.GetFieldValue("su_hpnum") + ")" + "');</script>");
					}
					*/
					break;
			}
		}
	}
}
