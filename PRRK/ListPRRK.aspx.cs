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

namespace SME.PRRK
{
	/// <summary>
	/// Summary description for ListPRRK.
	/// </summary>
	public partial class ListPRRK : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

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

				DataTable DTBO = new DataTable();
				this.DatGrd.DataSource = new DataView(DTBO);
				this.DatGrd.DataBind();	

				bindData();

				// Munculkan pesan next step
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"]!= null)  
				{
					GlobalTools.popMessage(this, Request.QueryString["msg"]);
				}

			}
			DatGrd.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
		}

		private void ViewAllData()
		{
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
		private void bindData()
		{
			DataTable DTBO = new DataTable();
			DataRow datrow;
			DTBO.Columns.Add(new DataColumn("AP_REGNO"));
			DTBO.Columns.Add(new DataColumn("Name"));
			DTBO.Columns.Add(new DataColumn("AP_SIGNDATE"));
			DTBO.Columns.Add(new DataColumn("AP_LIMITEXPOSURE"));
			DTBO.Columns.Add(new DataColumn("SU_FULLNAME"));
			DTBO.Columns.Add(new DataColumn("CU_REF"));

			string sjoin = "";
			string sqlCondPersonal = "";
			string sqlCondCompany = "";
			try 
			{
				//Customer Personal			
				sqlCondPersonal = "WHERE(";
				sjoin = RDB_COND.SelectedValue;

				if (txt_IdCard.Text.Trim() != "")
					sqlCondPersonal = sqlCondPersonal + " CU_IDCARDNUM like '%" + txt_IdCard.Text + "%' " + sjoin;
				if (txt_NPWP.Text.Trim() != "")
					sqlCondPersonal = sqlCondPersonal + " CU_NPWP like '%" + txt_NPWP.Text + "%' " + sjoin;
				if (txt_Name.Text.Trim() != "")
					sqlCondPersonal = sqlCondPersonal + " NAME like '%" + txt_Name.Text + "%' " + sjoin;
				if (txt_ProsID.Text.Trim() != "")
					sqlCondPersonal = sqlCondPersonal + " AP_REGNO like '%" + txt_ProsID.Text + "%' " + sjoin;
				if ( ((txt_Date.Text.Trim() != "") && (txt_Year.Text.Trim() != "")) && ((txt_Date1.Text.Trim() != "") && (txt_Year1.Text.Trim() != "")) )
					sqlCondPersonal = sqlCondPersonal + " AP_SIGNDATE BETWEEN '" + Tools.toSQLDate(txt_Date, ddl_Month, txt_Year) + "' and '"+ Tools.toSQLDate(txt_Date1, ddl_Month1, txt_Year1) +"' " + sjoin;
				if (sqlCondPersonal == "WHERE(") 
					sqlCondPersonal = "";
				else
				{
					sqlCondPersonal = sqlCondPersonal.Substring(0, sqlCondPersonal.Length - sjoin.Length);
					sqlCondPersonal = sqlCondPersonal + ")";
				}
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
			catch (Exception) 
			{
				GlobalTools.popMessage(this, "Unknown Error !");
				return;
			}

			try 
			{
				//Customer Company
				sqlCondCompany = "WHERE(";			
				if (txt_NPWP.Text.Trim() != "")
					sqlCondCompany = sqlCondCompany + " CU_COMPNPWP like '%" + txt_NPWP.Text + "%' " + sjoin;
				if (txt_Name.Text.Trim() != "")
					sqlCondCompany = sqlCondCompany + " CU_COMPNAME like '%" + txt_Name.Text + "%' " + sjoin;
				if (txt_ProsID.Text.Trim() != "")
					sqlCondCompany = sqlCondCompany + " AP_REGNO like '%" + txt_ProsID.Text + "%' " + sjoin;
				if ( ((txt_Date.Text.Trim() != "") && (txt_Year.Text.Trim() != "")) && ((txt_Date1.Text.Trim() != "") && (txt_Year1.Text.Trim() != "")) )
					sqlCondCompany = sqlCondCompany + " AP_SIGNDATE BETWEEN '" + Tools.toSQLDate(txt_Date, ddl_Month, txt_Year) + "' and '"+ Tools.toSQLDate(txt_Date1, ddl_Month1, txt_Year1) +"' " + sjoin;
				if (sqlCondCompany == "WHERE(") 
					sqlCondCompany = "";
				else
				{
					sqlCondCompany = sqlCondCompany.Substring(0, sqlCondCompany.Length - sjoin.Length);
					sqlCondCompany = sqlCondCompany + ")";
				}
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
			catch (Exception) 
			{
				GlobalTools.popMessage(this, "Unknown Error !");
				return;
			}

			if (sqlCondPersonal != "") 
			{
				//personal
				conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_PERSONAL " + sqlCondPersonal + " and ap_currtrack = '" +Request.QueryString["tc"].ToString()+ "' and  BRANCH_CODE = '" + Session["BranchID"].ToString()+ "'";
				try 
				{
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
					datrow[1] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,2);
					datrow[2] = tool.FormatDate(conn.GetFieldValue(i,12));
					datrow[3] = tool.MoneyFormat(conn.GetFieldValue(i,4).ToString());
					datrow[4] = conn.GetFieldValue(i,5);
					datrow[5] = conn.GetFieldValue(i,1);
					DTBO.Rows.Add(datrow);
				}
			}

			if (sqlCondCompany != "") 
			{
				//company
				conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_COMPANY " + sqlCondCompany + " and ap_currtrack = '" + Request.QueryString["tc"] + "' and  BRANCH_CODE = '" + Session["BranchID"].ToString()+ "'";
				
				try 
				{
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
					datrow[1] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,2);
					datrow[2] = tool.FormatDate(conn.GetFieldValue(i,11));
					datrow[3] = tool.MoneyFormat(conn.GetFieldValue(i,4).ToString());
					datrow[4] = conn.GetFieldValue(i,5);
					datrow[5] = conn.GetFieldValue(i,1);
					DTBO.Rows.Add(datrow);
				}
			}

			if ((sqlCondPersonal == "") || (sqlCondCompany == ""))
			{ // menampilkan data jika tidak ada kondisi pencarian - Gatot
				conn.QueryString = "SELECT AP_REGNO,NAME,AP_SIGNDATE,AP_LIMITEXPOSURE,SU_FULLNAME,CU_REF";
				conn.QueryString += " FROM VW_LISTCUSTOMER_PERSONAL WHERE ap_currtrack = '" +Request.QueryString["tc"].ToString()+ "' and  BRANCH_CODE = '" + Session["BranchID"].ToString()+ "'";
				conn.QueryString += " UNION SELECT AP_REGNO,CU_COMPNAME,AP_SIGNDATE,AP_LIMITEXPOSURE,SU_FULLNAME,CU_REF";
				conn.QueryString += " FROM VW_LISTCUSTOMER_COMPANY WHERE ap_currtrack = '" + Request.QueryString["tc"] + "' and  BRANCH_CODE = '" + Session["BranchID"].ToString()+ "'";
				try 
				{
					conn.ExecuteQuery();
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
					datrow[1] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,1);
					datrow[2] = tool.FormatDate(conn.GetFieldValue(i,2));
					datrow[3] = tool.MoneyFormat(conn.GetFieldValue(i,3).ToString());
					datrow[4] = conn.GetFieldValue(i,4);
					datrow[5] = conn.GetFieldValue(i,5);
					DTBO.Rows.Add(datrow);
				}
			}
 
			DatGrd.DataSource = new DataView(DTBO);
			DatGrd.DataBind();
		}

		void Grid_Change(Object sender, DataGridPageChangedEventArgs e) 
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			bindData();	
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "View":								
					string tc = (string) Request.QueryString["tc"];
					Response.Redirect("MainPRRK.aspx?regno=" + e.Item.Cells[0].Text + "&curef=" + e.Item.Cells[5].Text+ "&tc="+tc+"&mc=" + Request.QueryString["mc"]);
					break;
				default:
					break;
			}
		}

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			this.bindData();
		}

	}
}
