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

namespace SME.Facilities
{
	/// <summary>
	/// Summary description for FindCustomer.fs
	/// </summary>
	public partial class FindCustomer : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			string tc = "";//,mi = "";//, si = "";
			try 
			{
				tc = Request.QueryString["tc"];
				//mi = Request.QueryString["mi"];
				//si = Request.QueryString["si"];
			} 
			catch {}
			
			if (!IsPostBack)
			{
				Tools.initDateForm(txt_Date, ddl_Month, txt_Year, true);
				txt_Date.Text = "";
				txt_Year.Text = "";
				Tools.initDateForm(txt_Date1, ddl_Month1, txt_Year1, true);
				txt_Date1.Text = "";
				txt_Year1.Text = "";
				bindData();

				/*conn.QueryString = "select in_branchpusat from rfinitial";
				conn.ExecuteQuery();
				Label2.Text = conn.GetFieldValue("in_branchpusat");
				*/

				/*conn.QueryString = "EXEC ASSIGN_GETUSERTYPE '" + (string) Session["UserID"] + "' ";
				conn.ExecuteQuery();
				LBL_H_BUSUNIT.Text = conn.GetFieldValue(0,"BUSUNIT");
				LBL_H_GRPUNIT.Text = conn.GetFieldValue(0,"GRPUNIT");
				*/
			}
			DatGrd.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
		}

		void Grid_Change(Object sender, DataGridPageChangedEventArgs e) 
		{
			// For the DataGrid control to navigate to the correct page when paging is
			// allowed, the CurrentPageIndex property must be programmatically updated.
			// This process is usually accomplished in the event-handling method for the
			// PageIndexChanged event.

			// Set CurrentPageIndex to the page the user clicked.
			DatGrd.CurrentPageIndex = e.NewPageIndex;

			// Re-bind the data to refresh the DataGrid control. 
			bindData();	
		}

		private void bindData()
		{
			DataTable DTBO = new DataTable();
			DataRow datrow;

			string sqlCond = "WHERE", sjoin = RDB_COND.SelectedValue;
			if (txt_IdCard.Text.Trim() != "")
				sqlCond += " CU_IDCARDNUM like '%" + txt_IdCard.Text + "%' " + sjoin;
			if (txt_NPWP.Text.Trim() != "")
				sqlCond += " CU_NPWP like '%" + txt_NPWP.Text + "%' " + sjoin;
			if (txt_Name.Text.Trim() != "")
				sqlCond += " NAME like '%" + txt_Name.Text + "%' " + sjoin;
			if (txt_ProsID.Text.Trim() != "")
				sqlCond += " AP_REGNO like '%" + txt_ProsID.Text + "%' " + sjoin;
			if (TXT_CIF.Text.Trim() != "")
				sqlCond += " CU_CIF = '" + TXT_CIF.Text + "' " + sjoin;
			try 
			{
				if ( ((txt_Date.Text.Trim() != "") && (txt_Year.Text.Trim() != "")) && ((txt_Date1.Text.Trim() != "") && (txt_Year1.Text.Trim() != "")) )
					sqlCond += " AP_SIGNDATE BETWEEN '" + Tools.toSQLDate(txt_Date, ddl_Month, txt_Year) + "' and '"+ Tools.toSQLDate(txt_Date1, ddl_Month1, txt_Year1) +"' " + sjoin;
			} 
			catch 
			{
				Tools.popMessage(this, "Tanggal tidak valid !");
				return;
			}
			if (sqlCond == "WHERE") 
			{
				//sqlCond += " AP_CURRTRACK = '" + Request.QueryString["tc"] + "'";
				sqlCond = "";
			}
			else
			{
				sqlCond = sqlCond.Substring(0, sqlCond.Length - sjoin.Length);
				//sqlCond += "AND AP_CURRTRACK = '" + Request.QueryString["tc"] + "'";
			}

			DTBO.Columns.Add(new DataColumn("CU_REF"));
			DTBO.Columns.Add(new DataColumn("Name"));

			sqlCond = sqlCond.Replace("'", "''");

			conn.QueryString = "exec ASSIGN_GETLISTCUST '" + (string) Session["UserID"] + "', '" + sqlCond + "' ";
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
				datrow[1] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,1);
		
				DTBO.Rows.Add(datrow);
			}
			
			//Customer Personal
			/*string sqlCondPersonal = "WHERE", sjoin = RDB_COND.SelectedValue;
			if (txt_IdCard.Text.Trim() != "")
				sqlCondPersonal = sqlCondPersonal + " CU_IDCARDNUM like '%" + txt_IdCard.Text + "%' " + sjoin;
			if (txt_NPWP.Text.Trim() != "")
				sqlCondPersonal = sqlCondPersonal + " CU_NPWP like '%" + txt_NPWP.Text + "%' " + sjoin;
			if (txt_Name.Text.Trim() != "")
				sqlCondPersonal = sqlCondPersonal + " NAME like '%" + txt_Name.Text + "%' " + sjoin;
			if (txt_ProsID.Text.Trim() != "")
				sqlCondPersonal = sqlCondPersonal + " AP_REGNO like '%" + txt_ProsID.Text + "%' " + sjoin;
			try 
			{
				if ( ((txt_Date.Text.Trim() != "") && (txt_Year.Text.Trim() != "")) && ((txt_Date1.Text.Trim() != "") && (txt_Year1.Text.Trim() != "")) )
					sqlCondPersonal = sqlCondPersonal + " AP_SIGNDATE BETWEEN '" + Tools.toSQLDate(txt_Date, ddl_Month, txt_Year) + "' and '"+ Tools.toSQLDate(txt_Date1, ddl_Month1, txt_Year1) +"' " + sjoin;
			} 
			catch 
			{
				Tools.popMessage(this, "Tanggal tidak valid !");
				return;
			}
			if (sqlCondPersonal == "WHERE") 
				sqlCondPersonal = "";
			else
			{
				sqlCondPersonal = sqlCondPersonal.Substring(0, sqlCondPersonal.Length - sjoin.Length);
				//sqlCondPersonal = sqlCondPersonal + "AND AP_CURRTRACK = '" + Request.QueryString["tc"] + "'";
			}
			//Customer Company
			string sqlCondCompany = "WHERE";
			if (txt_NPWP.Text.Trim() != "")
				sqlCondCompany = sqlCondCompany + " CU_COMPNPWP like '%" + txt_NPWP.Text + "%' " + sjoin;
			if (txt_Name.Text.Trim() != "")
				sqlCondCompany = sqlCondCompany + " CU_COMPNAME like '%" + txt_Name.Text + "%' " + sjoin;
			if (txt_ProsID.Text.Trim() != "")
				sqlCondCompany = sqlCondCompany + " AP_REGNO like '%" + txt_ProsID.Text + "%' " + sjoin;
			try 
			{
				if ( ((txt_Date.Text.Trim() != "") && (txt_Year.Text.Trim() != "")) && ((txt_Date1.Text.Trim() != "") && (txt_Year1.Text.Trim() != "")) )
					sqlCondCompany = sqlCondCompany + " AP_SIGNDATE BETWEEN '" + Tools.toSQLDate(txt_Date, ddl_Month, txt_Year) + "' and '"+ Tools.toSQLDate(txt_Date1, ddl_Month1, txt_Year1) +"' " + sjoin;
			} 
			catch 
			{
				Tools.popMessage(this, "Tanggal tidak valid !");
				return;
			}

			if (sqlCondCompany == "WHERE") 
				sqlCondCompany = "";
			else
			{
				sqlCondCompany = sqlCondCompany.Substring(0, sqlCondCompany.Length - sjoin.Length);
				//sqlCondCompany = sqlCondCompany + "AND AP_CURRTRACK = '" + Request.QueryString["tc"] + "'";asdfafsd
			}
			DTBO.Columns.Add(new DataColumn("CU_REF"));
			DTBO.Columns.Add(new DataColumn("Name"));

			if (sqlCondPersonal != "")
			{
				if (Label2.Text == Session["BranchID"].ToString())
					conn.QueryString = "SELECT distinct cu_ref, name FROM VW_LISTCUSTOMER_PERSONAL " + sqlCondPersonal;
				else
					conn.QueryString = "SELECT distinct cu_ref, name FROM VW_LISTCUSTOMER_PERSONAL " + sqlCondPersonal + " and cbc_code='" + Session["CBC"].ToString() + "'";//" and branch_code='" + Session["BranchID"].ToString() + "'";
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
					datrow[1] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,1);
		
					DTBO.Rows.Add(datrow);
				}
			}
			if (sqlCondCompany != "")
			{
				if (Label2.Text == Session["BranchID"].ToString())
					conn.QueryString = "SELECT distinct cu_ref, cu_compname FROM VW_LISTCUSTOMER_COMPANY " + sqlCondCompany;
				else
					conn.QueryString = "SELECT distinct cu_ref, cu_compname FROM VW_LISTCUSTOMER_COMPANY " + sqlCondCompany + " and cbc_code='" + Session["CBC"].ToString() + "'";//" and branch_code='" + Session["BranchID"].ToString() + "'";
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
				//Response.Write(conn.QueryString);asdf
				for (int i =0; i < conn.GetRowCount(); i++) 
				{
					datrow = DTBO.NewRow();
					datrow[0] = conn.GetFieldValue(i,0);
					datrow[1] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,1);
					
					DTBO.Rows.Add(datrow);
				}
			}*/
			DatGrd.DataSource = new DataView(DTBO);
			DatGrd.DataBind();
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

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			//Deliberately uncoded but still needed. The HTML controls will affect the Page_Load
			bindData();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "View":								
					//string tc = (string) Request.QueryString["tc"];
					//conn.QueryString = "select top 1 branch_code from application where cu_ref = '" + e.Item.Cells[1].Text + "' order by ap_recvdate desc";
					//conn.QueryString = "select count (*) from application where cu_ref = '" + e.Item.Cells[1].Text + "' and branch_code = '" + Session["BranchID"].ToString() + "'";
					//conn.ExecuteQuery();
					//if (conn.GetFieldValue(0,0) == Session["BranchID"].ToString())
					//if (conn.GetFieldValue(0,0) != "0")
					/*conn.QueryString = "select top 1 application.branch_code, cbc_code from application "+
									   " join rfbranch on application.branch_code = rfbranch.branch_code "+
									   " where cu_ref = '"+e.Item.Cells[1].Text+"'";
					conn.ExecuteQuery();
					string appcbc		= conn.GetFieldValue("cbc_code");
					string appbranch	= conn.GetFieldValue("branch_code");*/

					//if ((appcbc == Session["CBC"].ToString()) || (appbranch == Session["BranchID"].ToString()) || (appbranch == "99999"))
						Response.Redirect("Assignment.aspx?curef=" + e.Item.Cells[1].Text + "&mc=" + Request.QueryString["mc"] + "&regno=" + txt_ProsID.Text.Trim());
					//else
					//	Response.Write("<script language='javascript'>alert('The requested customer is not from your cbc');</script>");
					//---------------------------
					//Response.Redirect("Main.aspx?regno=" + e.Item.Cells[0].Text + "&curef=" + e.Item.Cells[5].Text+"&tc="+tc + "&mc=" + Request.QueryString["mc"]);
					//Server.Transfer("Main.aspx?regno=" + DatGrd.Items[0].Cells[0].Text + "&curef=" + DatGrd.Items[0].Cells[4].Text + "&mi="+mi+"&si=0001"+"&tc="+tc);
					break;
					// Add other cases here, if there are multiple ButtonColumns in 
					// the DataGrid control.
				default:
					// Do nothing.
					break;
			}
		}
	}
}
