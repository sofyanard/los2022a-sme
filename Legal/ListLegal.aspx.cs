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
	/// Summary description for ListLegal.
	/// </summary>
	public partial class ListLegal : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

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

				viewAllData(); 

				// Munculkan pesan next step
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"]!= null)  
				{
					GlobalTools.popMessage(this, Request.QueryString["msg"]);
				}


				//ViewData();
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

		private void viewAllData()
		{
			DataTable DTBO = new DataTable();
			DataRow datrow;
			DTBO.Columns.Add(new DataColumn("AP_REGNO"));
			DTBO.Columns.Add(new DataColumn("CU_REF"));
			DTBO.Columns.Add(new DataColumn("CU_NAME"));
			DTBO.Columns.Add(new DataColumn("CU_RM"));		
			DTBO.Columns.Add(new DataColumn("AP_SIGNDATE"));
			DTBO.Columns.Add(new DataColumn("AP_CO"));

			try 
			{
				string szQuery = ""+
				"SELECT AP_REGNO, CU_REF, NAME as CU_NAME, SU_FULLNAME as CU_RM, AP_SIGNDATE ,AP_CO " +
				"FROM VW_LISTCUSTOMER_PERSONAL where  ap_currtrack = '" + Request.QueryString["tc"] + "' and (br_ccobranch=(" +
				"select br_ccobranch from scuser left join rfbranch on scuser.su_branch = rfbranch.branch_code where userid = '" + Session["UserID"].ToString() + "' ) or br_ccobranch is null) and AP_CO = '" + Session["UserID"].ToString() +"' " +
				"UNION " +
				"SELECT AP_REGNO, CU_REF, CU_COMPNAME as CU_NAME, SU_FULLNAME as CU_RM, AP_SIGNDATE, AP_CO " +
				"FROM VW_LISTCUSTOMER_COMPANY where  ap_currtrack = '" + Request.QueryString["tc"] + "' and (br_ccobranch=(" +
				"select br_ccobranch from scuser left join rfbranch on scuser.su_branch = rfbranch.branch_code where userid = '" + Session["UserID"].ToString() + "' ) or br_ccobranch is null) and AP_CO = '" + Session["UserID"].ToString() +"' ";

				conn.QueryString = szQuery;

				conn.ExecuteQuery();
			} 
			catch (ApplicationException) 
			{
				GlobalTools.popMessage(this, "Input tidak valid !");
				return;
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Server Error !");
				return;
			}
			for (int i =0; i < conn.GetRowCount(); i++) 
			{
				datrow = DTBO.NewRow();
				datrow[0] = conn.GetFieldValue(i,0);
				datrow[1] = conn.GetFieldValue(i,1);
				datrow[2] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,2);
				datrow[3] = conn.GetFieldValue(i,3);
				datrow[4] = tools.FormatDate(conn.GetFieldValue(i,4),true);

				DTBO.Rows.Add(datrow);
			}

			DGR_LIST.DataSource = new DataView(DTBO);
			try 
			{
				DGR_LIST.DataBind();
			} 
			catch 
			{
				GlobalTools.popMessage(this, "DataGrid Error !");
				return;
			}
		}

		private void ViewData()
		{
			DataTable DTBO = new DataTable();
			DataRow datrow;

			//Customer Personal
			string sqlCondPersonal = "WHERE(", sjoin = RDB_COND.SelectedValue;

			try 
			{
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
					//sqlCondPersonal = sqlCondPersonal + "AND AP_CURRTRACK = '" + Request.QueryString["tc"] + "'";
				}
			} 
			catch (ApplicationException) 
			{
				Tools.popMessage(this, "Input tidak valid !");
				return;
			}
			catch (FormatException) 
			{
				Tools.popMessage(this, "Input tidak valid !");
				return;
			}
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Server Error !");
				return;
			}


			//Customer Company
			string sqlCondCompany = "WHERE(";
			try 
			{
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
					//sqlCondCompany = sqlCondCompany + "AND AP_CURRTRACK = '" + Request.QueryString["tc"] + "'";
				}
			} 
			catch (ApplicationException) 
			{
				Tools.popMessage(this, "Input tidak valid !");
				return;
			}
			catch (FormatException) 
			{
				Tools.popMessage(this, "Input tidak valid !");
				return;				
			}
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Server Error !");
				return;
			}

			DTBO.Columns.Add(new DataColumn("AP_REGNO"));
			DTBO.Columns.Add(new DataColumn("CU_REF"));
			DTBO.Columns.Add(new DataColumn("CU_NAME"));
			DTBO.Columns.Add(new DataColumn("CU_RM"));		
			DTBO.Columns.Add(new DataColumn("AP_SIGNDATE"));
			DTBO.Columns.Add(new DataColumn("AP_CO"));

			string USERID = (string) Session["UserID"];
			if (sqlCondPersonal != "")
			{
				/*conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_PERSONAL " + sqlCondPersonal +
					" and ap_currtrack='" + Request.QueryString["tc"] + "' and (ap_co = '" +
					Session["UserID"].ToString() + "' or ap_co is null) and BR_CCOBRANCH='" +
					Session["BranchID"].ToString() + "'";*/
				/***
				 * -- Modif by Yudi
				 * Aplikasi yang kelihatan adalah aplikasi yang sudah diassign
				 * 
				conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_PERSONAL " + sqlCondPersonal +
					" and ap_currtrack='" + Request.QueryString["tc"] + "' and (br_ccobranch=" +
					"(select br_ccobranch from scuser left join rfbranch " +
					"on scuser.su_branch = rfbranch.branch_code where userid = '" +
					Session["UserID"].ToString() + "') or br_ccobranch is null)"; 
				***/
				conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_PERSONAL " + sqlCondPersonal +
					" and ap_currtrack='" + Request.QueryString["tc"] + "' and (br_ccobranch=" +
					"(select br_ccobranch from scuser left join rfbranch " +
					"on scuser.su_branch = rfbranch.branch_code where userid = '" +
					USERID + "') or br_ccobranch is null) and AP_CO = '" + USERID + "'"; 
				try 
				{
					conn.ExecuteQuery();
				} 
				catch (ApplicationException) 
				{
					Tools.popMessage(this, "Input tidak valid !");
					return;
				}
				catch (NullReferenceException) 
				{
					Tools.popMessage(this, "Server Error !");
					return;
				}
				//Response.Write(conn.QueryString);
				for (int i =0; i < conn.GetRowCount(); i++) 
				{
					datrow = DTBO.NewRow();
					datrow[0] = conn.GetFieldValue(i,0);
					datrow[1] = conn.GetFieldValue(i,1);
					datrow[2] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,2);
					datrow[3] = conn.GetFieldValue(i,5);
					datrow[4] = tools.FormatDate(conn.GetFieldValue(i,3),true);
					datrow[5] = conn.GetFieldValue(i,14);

					DTBO.Rows.Add(datrow);
				}
			}
			if (sqlCondCompany != "")
			{
				/*conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_COMPANY " + sqlCondCompany +
					" and ap_currtrack='" + Request.QueryString["tc"] + "' and (ap_co = '" +
					Session["UserID"].ToString() + "' or ap_co is null) and BR_CCOBRANCH='" +
					Session["BranchID"].ToString() + "'";*/
				/***
				 * --- Modif by Yudi
				 * Aplikasi yang kelihatan adalah aplikasi yang sudah diassign
				 * 
				conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_COMPANY " + sqlCondCompany +
					" and ap_currtrack='" + Request.QueryString["tc"] + "' and (br_ccobranch=" +
					"(select br_ccobranch from scuser left join rfbranch " +
					"on scuser.su_branch = rfbranch.branch_code where userid = '" +
					Session["UserID"].ToString() + "') or br_ccobranch is null)"; 
				***/
				conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_COMPANY " + sqlCondCompany +
					" and ap_currtrack='" + Request.QueryString["tc"] + "' and (br_ccobranch=" +
					"(select br_ccobranch from scuser left join rfbranch " +
					"on scuser.su_branch = rfbranch.branch_code where userid = '" +
					USERID + "') or br_ccobranch is null) and AP_CO = '" + USERID + "'"; 
				try 
				{
					conn.ExecuteQuery();
				} 
				catch (ApplicationException) 
				{
					Tools.popMessage(this, "Input tidak valid !");
					return;
				}
				catch (NullReferenceException) 
				{
					Tools.popMessage(this, "Server Error !");
					return;
				}
				for (int i =0; i < conn.GetRowCount(); i++) 
				{
					datrow = DTBO.NewRow();
					datrow[0] = conn.GetFieldValue(i,0);
					datrow[1] = conn.GetFieldValue(i,1);
					datrow[2] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,2);
					datrow[3] = conn.GetFieldValue(i,5);
					datrow[4] = tools.FormatDate(conn.GetFieldValue(i,3),true);
					datrow[5] = conn.GetFieldValue(i,13);
					
					DTBO.Rows.Add(datrow);
				}
			}
			this.DGR_LIST.DataSource = new DataView(DTBO);
			try 
			{
				DGR_LIST.DataBind();
			} 
			catch 
			{
			}

			/*
			DataTable DTBO = new DataTable();
			DataRow datrow;
			DTBO.Columns.Add(new DataColumn("AP_REGNO"));
			DTBO.Columns.Add(new DataColumn("CU_REF"));
			DTBO.Columns.Add(new DataColumn("CU_NAME"));
			DTBO.Columns.Add(new DataColumn("CU_RM"));		
			DTBO.Columns.Add(new DataColumn("AP_SIGNDATE"));		
			
			string sqlCond = "WHERE(", sjoin = RDB_COND.SelectedValue;
			if (txt_IdCard.Text.Trim() != "")
				sqlCond = sqlCond + " CU_IDCARDNUM like '%" + txt_IdCard.Text + "%' " + sjoin;
			if (txt_NPWP.Text.Trim() != "")
				sqlCond = sqlCond + " CU_NPWP like '%" + txt_NPWP.Text + "%' " + sjoin;
			if (txt_Name.Text.Trim() != "")
				sqlCond = sqlCond + " CU_NAME like '%" + txt_Name.Text + "%' " + sjoin;
			if (txt_ProsID.Text.Trim() != "")
				sqlCond = sqlCond + " AP_REGNO like '%" + txt_ProsID.Text + "%' " + sjoin;
			if ( ((txt_Date.Text.Trim() != "") && (txt_Year.Text.Trim() != "")) && ((txt_Date1.Text.Trim() != "") && (txt_Year1.Text.Trim() != "")) )
				sqlCond = sqlCond + " AP_SIGNDATE BETWEEN '" + Tools.toSQLDate(txt_Date, ddl_Month, txt_Year) + "' and '"+ Tools.toSQLDate(txt_Date1, ddl_Month1, txt_Year1) +"' " + sjoin;
			if (sqlCond == "WHERE(") 
				sqlCond = "";
			else
			{
				sqlCond = sqlCond.Substring(0, sqlCond.Length - sjoin.Length);
				sqlCond = sqlCond + ")";
			}

			if (sqlCond != "") 
			{
				conn.QueryString = "SELECT * FROM VW_CUST_COMP_PRODUCT " + sqlCond + " and AP_CURRTRACK='" + Request.QueryString["tc"] + "'"; // and branch_code='" + Session["BranchID"].ToString() + "'";
				conn.ExecuteQuery();
				for (int i =0; i < conn.GetRowCount(); i++) 
				{
					datrow = DTBO.NewRow();
					datrow[0] = conn.GetFieldValue(i,1);
					datrow[1] = conn.GetFieldValue(i,2);
					datrow[2] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,0);
					datrow[3] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,5);
					datrow[4] = tools.FormatDate(conn.GetFieldValue(i,3), true);
					datrow[5] = conn.GetFieldValue(i,6);
					datrow[6] = conn.GetFieldValue(i,7);
					datrow[7] = conn.GetFieldValue(i,8);
				
					DTBO.Rows.Add(datrow);
				}
			}
			this.DGR_LIST.DataSource = new DataView(DTBO);
			this.DGR_LIST.DataBind();	
			*/		
		}

		private void DGR_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "undo":
					break;
				case "view":
					//Response.Redirect("LegalSigning.aspx?regno="+ e.Item.Cells[0].Text +"&prodid="+ e.Item.Cells[8].Text +"&apptype="+ e.Item.Cells[9].Text +"&tc="+ LBL_TC.Text+"&mc=" + Request.QueryString["mc"]);
					if (e.Item.Cells[7].Text == "&nbsp;")
					{
						conn.QueryString = "update application set ap_co='" + Session["UserID"].ToString() + "' where ap_regno='" + e.Item.Cells[0].Text + "'";
						conn.ExecuteNonQuery();
					}
					Response.Redirect("LegalSigning.aspx?regno="+ e.Item.Cells[0].Text +"&curef=" + e.Item.Cells[1].Text + "&tc="+ LBL_TC.Text+"&mc=" + Request.QueryString["mc"]);
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
