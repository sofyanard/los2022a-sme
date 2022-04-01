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

namespace Websysca
{
	/// <summary>
	/// Summary description for List Customer DE
	/// </summary>
	public partial class ListCustomer : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.PlaceHolder Menu;
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
				LBL_USERID.Text = Session["UserID"].ToString();
				LBL_CBC.Text = Session["CBC"].ToString();

				Tools.initDateForm(txt_Date, ddl_Month, txt_Year, true);
				txt_Date.Text = "";
				txt_Year.Text = "";
				Tools.initDateForm(txt_Date1, ddl_Month1, txt_Year1, true);
				txt_Date1.Text = "";
				txt_Year1.Text = "";
				//bindData();
				ViewAllData(); // tampilkan seluruh data customer

				// Munculkan pesan next step
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"] != null) 
				{
					GlobalTools.popMessage(this, Request.QueryString["msg"]);
				}
			}
			DatGrd.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
		}		

		/* menampilkan data customer baik PERSONAL maupun COMPANY */
		private void ViewAllData()
		{
			DataTable DTBO = new DataTable();
			DataRow datrow;
			DTBO.Columns.Add(new DataColumn("AP_REGNO"));
			DTBO.Columns.Add(new DataColumn("Name"));
			DTBO.Columns.Add(new DataColumn("AP_SIGNDATE"));
			DTBO.Columns.Add(new DataColumn("AP_LIMITEXPOSURE"));
			DTBO.Columns.Add(new DataColumn("SU_FULLNAME"));
			DTBO.Columns.Add(new DataColumn("CU_REF"));
			DTBO.Columns.Add(new DataColumn("AP_CA"));

			try 
			{
				/*
				conn.QueryString = "SELECT AP_REGNO,NAME,AP_SIGNDATE,AP_LIMITEXPOSURE,SU_FULLNAME,CU_REF,AP_CA FROM VW_LISTCUSTOMER_PERSONAL WHERE ap_currtrack='" + Request.QueryString["tc"] + "' and ap_ca = '" + LBL_USERID.Text + "' "; //and cbc_code='" + LBL_CBC.Text + "'";
				conn.QueryString += " UNION SELECT AP_REGNO,CU_COMPNAME,AP_SIGNDATE,AP_LIMITEXPOSURE,SU_FULLNAME,CU_REF,AP_CA FROM VW_LISTCUSTOMER_COMPANY WHERE ap_currtrack='" + Request.QueryString["tc"] + "' and ap_ca = '" + LBL_USERID.Text + "'  "; //and cbc_code='" + LBL_CBC.Text + "'";
				*/
				conn.QueryString = "SELECT AP_REGNO,NAME,AP_SIGNDATE,AP_LIMITEXPOSURE,SU_FULLNAME,CU_REF,AP_CA FROM VW_LISTCUSTOMER_PERSONAL WHERE AP_CURRTRACK='" + Request.QueryString["tc"] + "' AND (AP_CA = '" + LBL_USERID.Text + "' OR (ISNULL(AP_CA,'') = '' AND BRANCH_CODE = '" + Session["BranchID"].ToString() + "'))";
				conn.QueryString += " UNION SELECT AP_REGNO,CU_COMPNAME,AP_SIGNDATE,AP_LIMITEXPOSURE,SU_FULLNAME,CU_REF,AP_CA FROM VW_LISTCUSTOMER_COMPANY WHERE AP_CURRTRACK='" + Request.QueryString["tc"] + "' AND (AP_CA = '" + LBL_USERID.Text + "' OR (ISNULL(AP_CA,'') = '' AND BRANCH_CODE = '" + Session["BranchID"].ToString() + "'))";
				conn.ExecuteQuery();
				//Response.Write(conn.QueryString);
				for (int i =0; i < conn.GetRowCount(); i++) 
				{
					datrow = DTBO.NewRow();
					datrow[0] = conn.GetFieldValue(i,0);
					datrow[1] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,1);
					datrow[2] = tool.FormatDate(conn.GetFieldValue(i,2));
					datrow[3] = conn.GetFieldValue(i,3);
					datrow[4] = conn.GetFieldValue(i,4);
					datrow[5] = conn.GetFieldValue(i,5);
					datrow[6] = conn.GetFieldValue(i,6);
					DTBO.Rows.Add(datrow);
				}

				DatGrd.DataSource = new DataView(DTBO);
				DatGrd.DataBind();
			} 
			catch (NullReferenceException)
			{
				GlobalTools.popMessage(this, "Connection Error !");
				Response.Redirect("../Login.aspx?expire=1");
			}
		}
		private void bindData()
		{
			DataTable DTBO = new DataTable();
			DataRow datrow;
			//Customer Personal
			//string sqlCondPersonal = "WHERE";
			string sqlCondPersonal = "";
			string sjoin = RDB_COND.SelectedValue;
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
			catch {
				Tools.popMessage(this, "Tanggal tidak valid !");
				return;
			}
			/*
			if (sqlCondPersonal == "WHERE") 
				sqlCondPersonal = "";
			else
			*/
			if ( sqlCondPersonal != "")
			{			
				sqlCondPersonal = sqlCondPersonal.Substring(0, sqlCondPersonal.Length - sjoin.Length);
				//sqlCondPersonal = sqlCondPersonal + "AND AP_CURRTRACK = '" + Request.QueryString["tc"] + "'";
			}
			else 
			{
				sqlCondPersonal = " 1= 1 ";
			}
			//Customer Company
			//string sqlCondCompany = "WHERE";
			string sqlCondCompany = "";
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
			/*
			if (sqlCondCompany == "WHERE") 
				sqlCondCompany = "";
			else
			*/
			if ( sqlCondCompany != "")
			{
				sqlCondCompany = sqlCondCompany.Substring(0, sqlCondCompany.Length - sjoin.Length);
				//sqlCondCompany = sqlCondCompany + "AND AP_CURRTRACK = '" + Request.QueryString["tc"] + "'";
			}
			else  { sqlCondCompany = " 1 = 1 ";  }
			DTBO.Columns.Add(new DataColumn("AP_REGNO"));
			DTBO.Columns.Add(new DataColumn("Name"));
			DTBO.Columns.Add(new DataColumn("AP_SIGNDATE"));
			DTBO.Columns.Add(new DataColumn("AP_LIMITEXPOSURE"));
			DTBO.Columns.Add(new DataColumn("SU_FULLNAME"));
			DTBO.Columns.Add(new DataColumn("CU_REF"));
			DTBO.Columns.Add(new DataColumn("AP_CA"));

			try 
			{
				if (sqlCondPersonal != "")
				{
					//--- modified by yudi (2004/09/09) ---
					//conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_PERSONAL " + sqlCondPersonal + " and ap_currtrack='" + Request.QueryString["tc"] + "' and (ap_ca = '" + Session["UserID"].ToString() + "' or ap_ca is null) and cbc_code='" + Session["CBC"].ToString() + "'";
					//--- modif by Yudi (2004/09/24)
					//conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_PERSONAL " + sqlCondPersonal + " and ap_currtrack='" + Request.QueryString["tc"] + "' and (ap_ca = '" + LBL_USERID.Text + "' or ap_ca is null) and cbc_code='" + LBL_CBC.Text + "'";
					conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_PERSONAL  where (" + sqlCondPersonal + ") and ap_currtrack='" + Request.QueryString["tc"] + "' and ap_ca = '" + LBL_USERID.Text + "' and cbc_code='" + LBL_CBC.Text + "'";
					//-------------------------------------
					conn.ExecuteQuery();
					//Response.Write(conn.QueryString);
					for (int i =0; i < conn.GetRowCount(); i++) 
					{
						datrow = DTBO.NewRow();
						datrow[0] = conn.GetFieldValue(i,0);
						datrow[1] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,2);
						datrow[2] = tool.FormatDate(conn.GetFieldValue(i,12));
						datrow[3] = conn.GetFieldValue(i,4);
						datrow[4] = conn.GetFieldValue(i,5);
						datrow[5] = conn.GetFieldValue(i,1);
						datrow[6] = conn.GetFieldValue(i,13);
						DTBO.Rows.Add(datrow);
					}
				}
				if (sqlCondCompany != "")
				{
					//--- modified by yudi (2004/09/09) ---
					//conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_COMPANY " + sqlCondCompany + " and ap_currtrack='" + Request.QueryString["tc"] + "' and (ap_ca = '" + Session["UserID"].ToString() + "' or ap_ca is null) and cbc_code='" + Session["CBC"].ToString() + "'";
					conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_COMPANY where (" + sqlCondCompany + ") and ap_currtrack='" + Request.QueryString["tc"] + "' and ap_ca = '" + LBL_USERID.Text + "'  and cbc_code='" + LBL_CBC.Text + "'";
					//-------------------------------------
					conn.ExecuteQuery();
					//Response.Write(conn.QueryString);asdf
					for (int i =0; i < conn.GetRowCount(); i++) 
					{
						datrow = DTBO.NewRow();
						datrow[0] = conn.GetFieldValue(i,0);
						datrow[1] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,2);
						datrow[2] = tool.FormatDate(conn.GetFieldValue(i,11));
						datrow[3] = conn.GetFieldValue(i,4);
						datrow[4] = conn.GetFieldValue(i,5);
						datrow[5] = conn.GetFieldValue(i,1);
						datrow[6] = conn.GetFieldValue(i,12);
						DTBO.Rows.Add(datrow);
					}
				}
				DatGrd.DataSource = new DataView(DTBO);
				DatGrd.DataBind();
			} 
			catch 
			{
				Tools.popMessage(this, "Pencarian Error !");
				return;
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
					// e.Item is the table row where the command is raised. For bound
					// columns, the value is stored in the Text property of a TableCell.
					//string spid = e.Item.Cells[0].Text.Trim();
					//string mi = (string) Request.QueryString["mi"],
					//si = (string) Request.QueryString["si"],
					string tc = (string) Request.QueryString["tc"];
					//TODO : Mengapa hal ini perlu dilakukan ???
					//       Hal ini memungkinkan aplikasi hilang
					if (e.Item.Cells[7].Text == "&nbsp;")
					{
						//--- modified by yudi (2004/09/09) ---
						//conn.QueryString = "update application set ap_ca='" + Session["UserID"].ToString() + "' where ap_regno='" + e.Item.Cells[0].Text + "'";
						conn.QueryString = "update application set ap_ca='" + LBL_USERID.Text + "' where ap_regno='" + e.Item.Cells[0].Text + "'";
						//--------------------------------------
						conn.ExecuteNonQuery();
					}
					//---- changes made by Yudi
					Response.Redirect("Main.aspx?regno=" + e.Item.Cells[0].Text + "&curef=" + e.Item.Cells[5].Text+"&tc="+tc + "&mc=" + Request.QueryString["mc"] + "&de=1");
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
