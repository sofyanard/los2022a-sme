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
using DMS.CuBESCore;
using DMS.DBConnection;
using System.Configuration;

namespace SME.AccountPlanning.Parameter.Maker
{
	/// <summary>
	/// Summary description for ProductMasterParam.
	/// </summary>
	public class ProductMasterParam : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LBL_TXT_PRODUCT_LINK_ID;
		protected System.Web.UI.WebControls.TextBox TXT_PRODUCT_LINK_ID;
		protected System.Web.UI.WebControls.Label LBL_PRODUCT_LINK_NAME;
		protected System.Web.UI.WebControls.TextBox TXT_PRODUCT_LINK_NAME;
		protected System.Web.UI.WebControls.Label LBL_PRODUCT_IPS_LINK;
		protected System.Web.UI.WebControls.Button BTN_SAVE;
		protected System.Web.UI.WebControls.Button BTN_CLEAR;
		protected System.Web.UI.WebControls.DataGrid DGR_PRODUCT_LINK_EXIST;
		protected System.Web.UI.WebControls.DataGrid DGR_PRODUCT_LINK_REQ;
		protected System.Web.UI.WebControls.Label LBL_ID;
		protected System.Web.UI.WebControls.Label TXT_ID;
		protected Tools tools = new Tools();
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.Label Label24;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.Label Label29;
		protected System.Web.UI.WebControls.Label Label30;
		protected System.Web.UI.WebControls.Label Label31;
		protected System.Web.UI.WebControls.Label Label32;
		protected System.Web.UI.WebControls.Label Label33;
		protected System.Web.UI.WebControls.Label Label34;
		protected System.Web.UI.WebControls.Label Label35;
		protected System.Web.UI.WebControls.Label Label36;
		protected System.Web.UI.WebControls.Label Label37;
		protected System.Web.UI.WebControls.Label Label38;
		protected System.Web.UI.WebControls.Label Label39;
		protected System.Web.UI.WebControls.Label Label40;
		protected System.Web.UI.WebControls.Label Label41;
		protected System.Web.UI.WebControls.Label Label42;
		protected System.Web.UI.WebControls.Label Label43;
		protected System.Web.UI.WebControls.Label Label44;
		protected System.Web.UI.WebControls.Label Label45;
		protected System.Web.UI.WebControls.Label Label46;
		protected System.Web.UI.WebControls.Label Label47;
		protected System.Web.UI.WebControls.Label Label48;
		protected System.Web.UI.WebControls.TextBox TXT_ADMIN_FEE;
		protected System.Web.UI.WebControls.TextBox TXT_CASH_PROCESS;
		protected System.Web.UI.WebControls.TextBox TXT_PROVISI_BLOKIR;
		protected System.Web.UI.WebControls.TextBox TXT_ANNUAL_FEE;
		protected System.Web.UI.WebControls.TextBox TXT_CASH_IN_SHIFT;
		protected System.Web.UI.WebControls.TextBox TXT_INTEREST_RATE;
		protected System.Web.UI.WebControls.TextBox TXT_BI_COST;
		protected System.Web.UI.WebControls.TextBox TXT_CASH_IN_TRANSIT;
		protected System.Web.UI.WebControls.TextBox TXT_IT_C0ST;
		protected System.Web.UI.WebControls.TextBox TXT_CABLE_COST;
		protected System.Web.UI.WebControls.TextBox TXT_H2HDEV_FEE;
		protected System.Web.UI.WebControls.TextBox TXT_JOINING_FEE;
		protected System.Web.UI.WebControls.TextBox TXT_CABLE_FEE;
		protected System.Web.UI.WebControls.TextBox TXT_COLLECTION_FEE;
		protected System.Web.UI.WebControls.TextBox TXT_MAX_PROVOSION;
		protected System.Web.UI.WebControls.TextBox TXT_COMMITMENT_FEE;
		protected System.Web.UI.WebControls.TextBox TXT_MINIMUM_FEE;
		protected System.Web.UI.WebControls.TextBox TXT_CORRESPONDENT_COST;
		protected System.Web.UI.WebControls.TextBox TXT_MINIMUM_PROVISION;
		protected System.Web.UI.WebControls.TextBox TXT_CORRESPONDENT_FEE;
		protected System.Web.UI.WebControls.TextBox TXT_DIRECT_IT_COST;
		protected System.Web.UI.WebControls.TextBox TXT_FEE_TRANSACTION;
		protected System.Web.UI.WebControls.TextBox TXT_REFERRAL_FEE_INCOME;
		protected System.Web.UI.WebControls.TextBox TXT_NON_H2H_DEV_FEE;
		protected System.Web.UI.WebControls.TextBox TXT_SERVICE_COST;
		protected System.Web.UI.WebControls.TextBox TXT_PENALTY_FEE;
		protected System.Web.UI.WebControls.TextBox TXT_INDIRECT_COST;
		protected System.Web.UI.WebControls.TextBox TXT_SERVICE_FEE;
		protected System.Web.UI.WebControls.TextBox TXT_PREMIUM_LPS;
		protected System.Web.UI.WebControls.TextBox TXT_MONTHLY_MIN_TRANSACTION;
		protected System.Web.UI.WebControls.TextBox TXT_TRANSACTION_FEE;
		protected System.Web.UI.WebControls.TextBox TXT_CKPN;
		protected System.Web.UI.WebControls.TextBox TXT_PROVISI_FASILITAS;
		protected System.Web.UI.WebControls.TextBox TXT_SWIFT_FEE;
		protected System.Web.UI.WebControls.TextBox TXT_GWM;
		protected System.Web.UI.WebControls.TextBox TXT_PROVISI_GIRO_JAMINAN;
		protected System.Web.UI.WebControls.TextBox TXT_SYNDICATION_FEE;
		protected System.Web.UI.WebControls.TextBox TXT_SPREAD;
		protected System.Web.UI.WebControls.TextBox TXT_UNIT_COST;
		protected System.Web.UI.WebControls.TextBox TXT_USAGE_COMISSIOM_FEE;
		protected System.Web.UI.WebControls.TextBox TXT_LINKID;
		protected System.Web.UI.WebControls.Button BTN_LINK;
		protected System.Web.UI.WebControls.Label Label49;
		protected System.Web.UI.WebControls.DropDownList DDL_CATEGORY;
		protected System.Web.UI.WebControls.DropDownList DDL_PRODUCT_ID;
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected System.Web.UI.WebControls.Label Label50;
		protected System.Web.UI.WebControls.DropDownList DDL_BENCHMARK;
		protected System.Web.UI.WebControls.Label Label51;
		protected System.Web.UI.WebControls.DropDownList DDL_UPLOADED;
		protected System.Web.UI.WebControls.Label Label52;
		protected System.Web.UI.WebControls.Label Label53;
		protected System.Web.UI.WebControls.Label Label54;
		protected System.Web.UI.WebControls.TextBox TXT_OTHER_COST2;
		protected System.Web.UI.WebControls.TextBox TXT_FIXED_FEE2;
		protected System.Web.UI.WebControls.TextBox TXT_FTP_GWM2;
		protected System.Web.UI.WebControls.Label Label55;
		protected System.Web.UI.WebControls.Label Label57;
		protected System.Web.UI.WebControls.TextBox TXT_RATE_EMPLOYEE2;
		protected System.Web.UI.WebControls.TextBox TXT_FTP_INCOME_VALAS;
		protected System.Web.UI.WebControls.TextBox TXT_FTP_CKPN_IDR;
		protected System.Web.UI.WebControls.TextBox TXT_FTP_CKPN_VALAS;
		protected System.Web.UI.WebControls.TextBox TXT_FTP_COST_IDR;
		protected System.Web.UI.WebControls.TextBox TXT_FTP_COST_VALAS;
		protected System.Web.UI.WebControls.TextBox TXT_PROVISION_IDR;
		protected System.Web.UI.WebControls.TextBox TXT_PROVISION_VALAS;
		protected System.Web.UI.WebControls.TextBox TXT_FTP_INCOME_IDR;
		protected System.Web.UI.WebControls.Label SEQ;
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		private string seq;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if(!IsPostBack)
			{
				//CekCode();
				FillDDLType();
				FillGridExist();
				FillGridReq();					
			}

			if (SEQ.Text=="")
			{				
				conn.QueryString = "select max(seq)+1 from ap_variable";
				conn.ExecuteQuery();
				SEQ.Text = conn.GetFieldValue(0,0);
			}

			/*if (TXT_LINKID.Text == "")
			{
				GlobalTools.popMessage(this, "Data Product IPS Link tidak ada!");
				return;
			}*/
		}

		private void CekCode()
		{
			conn.QueryString = "SELECT ISNULL(MAX(CONVERT(INT, ID_AP_VARIABLE)),0) AS ID_AP_VARIABLE FROM AP_VARIABLE";
			conn.ExecuteQuery();
			LBL_ID.Text =  conn.GetFieldValue("ID_AP_VARIABLE").ToString();

			conn.QueryString = "EXEC AP_GENERATE_VARIABLE_PARAM '" + LBL_ID.Text + "'";
			conn.ExecuteQuery();
			TXT_ID.Text = conn.GetFieldValue(0,0).ToString();
			TXT_PRODUCT_LINK_ID.Text = TXT_ID.Text;

		}

		private void FillDDLType()
		{
			DDL_CATEGORY.Items.Clear();
			DDL_PRODUCT_ID.Items.Clear();
			DDL_CATEGORY.Items.Add(new ListItem("--Select--",""));
			DDL_PRODUCT_ID.Items.Add(new ListItem("--Select--",""));
			DDL_BENCHMARK.Items.Add(new ListItem("--Select--",""));
			DDL_UPLOADED.Items.Add(new ListItem("--Select--",""));

			conn.QueryString = "SELECT distinct id_ap_wallet_size_category, [description] FROM AP_WALLET_SIZE_CATEGORY WHERE ACTIVE='1' ORDER BY id_ap_wallet_size_category ASC";
			conn.ExecuteQuery();
			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_CATEGORY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}

			conn.QueryString = "SELECT * FROM VW_AP_PRODUCT_NAME ORDER BY CONVERT(INT, PRODUCTID)";
			conn.ExecuteQuery();
			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_PRODUCT_ID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}

			conn.QueryString = "SELECT * FROM AP_BENCHMARK";
			conn.ExecuteQuery();
			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_BENCHMARK.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}

			conn.QueryString = "SELECT * FROM ap_uploaded_data";
			conn.ExecuteQuery();
			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_UPLOADED.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillGridExist()
		{
			conn.QueryString = "SELECT * FROM AP_VARIABLE WHERE STATUS='1' ORDER BY id_ap_variable ASC";
			BindData(DGR_PRODUCT_LINK_EXIST.ID.ToString(), conn.QueryString);
		}

		private void FillGridReq()
		{
			conn.QueryString = "SELECT * FROM AP_VARIABLE WHERE STATUS='2' order by id_ap_variable ASC";
			BindData(DGR_PRODUCT_LINK_REQ.ID.ToString(), conn.QueryString);
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);
			dg.DataSource = dt;

			try
			{
				dg.DataBind();
			}
			catch
			{
				dg.CurrentPageIndex = dg.PageCount - 1;
				dg.DataBind();
			}

			conn.ClearData();
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
			this.BTN_BACK.Click += new System.Web.UI.ImageClickEventHandler(this.BTN_BACK_Click);
			this.BTN_LINK.Click += new System.EventHandler(this.BTN_LINK_Click);
			this.BTN_SAVE.Click += new System.EventHandler(this.BTN_SAVE_Click);
			this.BTN_CLEAR.Click += new System.EventHandler(this.BTN_CLEAR_Click);
			this.DGR_PRODUCT_LINK_EXIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_PRODUCT_LINK_EXIST_ItemCommand);
			this.DGR_PRODUCT_LINK_EXIST.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_PRODUCT_LINK_EXIST_PageIndexChanged);
			this.DGR_PRODUCT_LINK_REQ.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_PRODUCT_LINK_REQ_ItemCommand);
			this.DGR_PRODUCT_LINK_REQ.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_PRODUCT_LINK_REQ_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if(DDL_CATEGORY.SelectedValue == "" || TXT_LINKID.Text == "" || DDL_PRODUCT_ID.SelectedValue == "" || DDL_BENCHMARK.SelectedValue == "" || DDL_UPLOADED.SelectedValue == "")
			{
				GlobalTools.popMessage(this, "Check Field Mandatory!");
				return;
			}
			else
			{
				try
				{
					/*conn.QueryString = "EXEC AP_RF_PRODUCT_MASTER_INSERT_PARAM '" + TXT_ID.Text + "','"
										+ TXT_PRODUCT_LINK_ID.Text + "','" + TXT_PRODUCT_LINK_NAME.Text + "','"
										+ DDL_PRODUCT_IPS_LINK.SelectedValue + "'";
					*/
					conn.QueryString = "EXEC AP_VARIABLE_INSERT2 '" +
						DDL_PRODUCT_ID.SelectedValue + "', '"+ 
						DDL_PRODUCT_ID.SelectedItem + "', '"+ 
						DDL_CATEGORY.SelectedValue + "', '"+ 
						DDL_CATEGORY.SelectedItem + "', '"+ 
						TXT_CASH_PROCESS.Text + "', '"+ 
						TXT_CASH_IN_SHIFT.Text + "', '"+ 
						TXT_CASH_IN_TRANSIT.Text + "', '"+ 
						TXT_H2HDEV_FEE.Text + "', '"+ 
						TXT_COLLECTION_FEE.Text + "', '"+ 
						TXT_COMMITMENT_FEE.Text + "', '"+ 
						TXT_CORRESPONDENT_COST.Text + "', '"+ 
						TXT_CORRESPONDENT_FEE.Text + "', '"+ 
						TXT_DIRECT_IT_COST.Text + "', '"+ 
						TXT_FEE_TRANSACTION.Text + "', '"+ 
						TXT_NON_H2H_DEV_FEE.Text + "', '"+ 
						TXT_INDIRECT_COST.Text + "', '"+ 
						TXT_MONTHLY_MIN_TRANSACTION.Text + "', '"+ 
						TXT_PROVISI_FASILITAS.Text + "', '"+ 
						TXT_PROVISI_GIRO_JAMINAN.Text + "', '"+ 
						TXT_UNIT_COST.Text + "', '"+ 
						TXT_PROVISI_BLOKIR.Text + "', '"+ 
						TXT_INTEREST_RATE.Text + "', '"+ 
						TXT_IT_C0ST.Text + "', '"+ 
						TXT_JOINING_FEE.Text + "', '"+ 
						TXT_MAX_PROVOSION.Text + "', '"+ 
						TXT_MINIMUM_FEE.Text + "', '"+ 
						TXT_MINIMUM_PROVISION.Text + "', '"+ 
						TXT_PROVISION_IDR.Text + "', '"+ 
						TXT_RATE_EMPLOYEE2.Text + "', '"+ 
						TXT_REFERRAL_FEE_INCOME.Text + "', '"+ 
						TXT_SERVICE_COST.Text + "', '"+ 
						TXT_SERVICE_FEE.Text + "', '"+ 
						TXT_TRANSACTION_FEE.Text + "', '"+ 
						TXT_SWIFT_FEE.Text + "', '"+ 
						TXT_SYNDICATION_FEE.Text + "', '"+ 
						TXT_USAGE_COMISSIOM_FEE.Text + "', '"+ 
						TXT_ADMIN_FEE.Text + "', '"+ 
						TXT_ANNUAL_FEE.Text + "', '"+ 
						TXT_BI_COST.Text + "', '"+ 
						TXT_CABLE_COST.Text + "', '"+ 
						TXT_CABLE_FEE.Text + "', '"+ 
						TXT_FIXED_FEE2.Text + "', '"+ 
						TXT_FTP_CKPN_IDR.Text + "', '"+ 
						TXT_FTP_COST_IDR.Text + "', '"+ 
						TXT_FTP_GWM2.Text + "', '"+ 
						TXT_FTP_INCOME_IDR.Text + "', '"+ 
						TXT_OTHER_COST2.Text + "', '"+ 
						TXT_PENALTY_FEE.Text + "', '"+ 
						TXT_PREMIUM_LPS.Text + "', '"+ 
						TXT_CKPN.Text + "', '"+ 
						TXT_GWM.Text + "', '"+ 
						TXT_SPREAD.Text +"', '"+ 
						TXT_LINKID.Text +"', '" +
						DDL_BENCHMARK.SelectedValue +"', '" +
						DDL_UPLOADED.SelectedValue +"', '"+
						//tambahan
						TXT_FTP_INCOME_VALAS.Text + "', '"+ 
						TXT_FTP_CKPN_VALAS.Text + "', '"+ 
						TXT_FTP_COST_VALAS.Text + "', '"+ 
						TXT_PROVISION_VALAS.Text + "', '"+ SEQ.Text +"' ";					
					conn.ExecuteQuery();					
				}
				catch (Exception ex)
				{
					ClearData();
					FillGridExist();
					FillGridReq();

					string errmsg = ex.Message.Replace("'","");
					if (errmsg.IndexOf("Last Query:") > 0)
						errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
					GlobalTools.popMessage(this, errmsg);
					return;
				}

				ClearData();
				FillGridExist();
				FillGridReq();
			}
		}

		private void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{
			DDL_PRODUCT_ID.SelectedValue = "";			
			DDL_CATEGORY.SelectedValue = "";
			DDL_BENCHMARK.SelectedValue = "";
			DDL_UPLOADED.SelectedValue = "";
			TXT_LINKID.Text = "";
			TXT_ADMIN_FEE.Text = "";
			TXT_ANNUAL_FEE.Text = "";
			TXT_BI_COST.Text = "";
			TXT_CABLE_COST.Text = "";
			TXT_CABLE_FEE.Text = "";
			TXT_FIXED_FEE2.Text = "";
			TXT_FTP_CKPN_IDR.Text = "";
			TXT_FTP_COST_IDR.Text = "";
			TXT_FTP_GWM2.Text = "";
			TXT_FTP_INCOME_IDR.Text = "";
			TXT_OTHER_COST2.Text = "";
			TXT_PENALTY_FEE.Text = "";
			TXT_PREMIUM_LPS.Text = "";
			TXT_CKPN.Text = "";
			TXT_GWM.Text = "";
			TXT_SPREAD.Text = "";
			TXT_CASH_PROCESS.Text = "";
			TXT_CASH_IN_SHIFT.Text = "";
			TXT_CASH_IN_TRANSIT.Text = "";
			TXT_H2HDEV_FEE.Text = "";
			TXT_COLLECTION_FEE.Text = "";
			TXT_COMMITMENT_FEE.Text = "";
			TXT_CORRESPONDENT_COST.Text = "";
			TXT_CORRESPONDENT_FEE.Text = "";
			TXT_DIRECT_IT_COST.Text = "";
			TXT_FEE_TRANSACTION.Text = "";
			TXT_NON_H2H_DEV_FEE.Text = "";
			TXT_INDIRECT_COST.Text = "";
			TXT_MONTHLY_MIN_TRANSACTION.Text = "";
			TXT_PROVISI_FASILITAS.Text = "";
			TXT_PROVISI_GIRO_JAMINAN.Text = "";
			TXT_UNIT_COST.Text = "";
			TXT_PROVISI_BLOKIR.Text = "";
			TXT_INTEREST_RATE.Text = "";
			TXT_IT_C0ST.Text = "";
			TXT_JOINING_FEE.Text = "";
			TXT_MAX_PROVOSION.Text = "";
			TXT_MINIMUM_FEE.Text = "";
			TXT_MINIMUM_PROVISION.Text = "";
			TXT_PROVISION_IDR.Text = "";
			TXT_RATE_EMPLOYEE2.Text = "";
			TXT_REFERRAL_FEE_INCOME.Text = "";
			TXT_SERVICE_COST.Text = "";
			TXT_SERVICE_FEE.Text = "";
			TXT_TRANSACTION_FEE.Text = "";
			TXT_SWIFT_FEE.Text = "";
			TXT_SYNDICATION_FEE.Text = "";
			TXT_USAGE_COMISSIOM_FEE.Text = "";
			//tambahan
			TXT_FTP_INCOME_VALAS.Text = "";
			TXT_FTP_CKPN_VALAS.Text = "";
			TXT_FTP_COST_VALAS.Text = "";
			TXT_PROVISION_VALAS.Text = "";
			SEQ.Text = "";
			//CekCode();
		}

		private void DGR_PRODUCT_LINK_EXIST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_PRODUCT_LINK_EXIST.CurrentPageIndex = e.NewPageIndex;
			FillGridExist();
		}

		private void DGR_PRODUCT_LINK_REQ_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_PRODUCT_LINK_REQ.CurrentPageIndex = e.NewPageIndex;
			FillGridReq();
		}

		private void DGR_PRODUCT_LINK_EXIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit_exist":
					TXT_ID.Text = e.Item.Cells[1].Text.Trim();
					/*TXT_PRODUCT_LINK_ID.Text = e.Item.Cells[1].Text.Trim().Replace("&nbsp;","");
					TXT_PRODUCT_LINK_NAME.Text = e.Item.Cells[2].Text.Trim().Replace("&nbsp;","");
					TXT_LINKID.Text = e.Item.Cells[3].Text.Trim();*/

					ViewDataReq();
					break;

				case "delete_exist":
					conn.QueryString = "UPDATE AP_VARIABLE SET STATUS='0', REQUEST='Not Active' WHERE ID_AP_VARIABLE='" + e.Item.Cells[1].Text.Trim() + "' and seq='" + e.Item.Cells[0].Text.Trim() + "'";
					conn.ExecuteQuery();

					ClearData();
					FillGridExist();
					break;
			}
		}

		private void DGR_PRODUCT_LINK_REQ_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit_req":
					TXT_ID.Text = e.Item.Cells[1].Text.Trim();
					//TXT_PRODUCT_LINK_ID.Text = e.Item.Cells[1].Text.Trim().Replace("&nbsp;","");
					//TXT_PRODUCT_LINK_NAME.Text = e.Item.Cells[2].Text.Trim().Replace("&nbsp;","");					
					ViewDataReq();
					break;

				case "delete_req":
					conn.QueryString = "DELETE AP_VARIABLE WHERE ID_AP_VARIABLE='" + e.Item.Cells[1].Text.Trim() + "' and seq='" + e.Item.Cells[0].Text.Trim() + "'";
					conn.ExecuteQuery();

					ClearData();
					FillGridReq();
					break;
			}
		}

		private void ViewDataReq()
		{
			conn.QueryString = "select * from ap_variable where id_ap_variable = '"+ TXT_ID.Text +"' ";
			conn.ExecuteQuery();
			seq = conn.GetFieldValue("seq");
			SEQ.Text = seq;
			DDL_PRODUCT_ID.SelectedValue = conn.GetFieldValue("ID_AP_VARIABLE");			
			TXT_LINKID.Text = conn.GetFieldValue("PRODUCT_LINK_ID");
			DDL_BENCHMARK.SelectedValue = conn.GetFieldValue("ID_AP_BENCHMARK");
			DDL_UPLOADED.SelectedValue = conn.GetFieldValue("ID_AP_UPLOADED_DATA");

			//Kolom kedua
			TXT_CASH_PROCESS.Text = conn.GetFieldValue("CASH_PROCESSING_FEE_DAY");
			TXT_CASH_IN_SHIFT.Text = conn.GetFieldValue("CASH_IN_SHIFT_DAY");
			TXT_CASH_IN_TRANSIT.Text = conn.GetFieldValue("CASH_IN_TRANSIT_COST_DAY");
			TXT_H2HDEV_FEE.Text = conn.GetFieldValue("H2HDEVELOPMENT_FEE_USD");
			TXT_COLLECTION_FEE.Text = conn.GetFieldValue("COLLECTION_FEE_DAY");
			TXT_COMMITMENT_FEE.Text = conn.GetFieldValue("COMMITMENT_FEE");
			TXT_CORRESPONDENT_COST.Text = conn.GetFieldValue("CORRESPONDENT_COST_USD");
			TXT_CORRESPONDENT_FEE.Text = conn.GetFieldValue("CORRESPONDENT_FEE_USD");
			TXT_DIRECT_IT_COST.Text = conn.GetFieldValue("DIRECT_IT_COST_PER_MILLION_UNIT");
			TXT_FEE_TRANSACTION.Text = conn.GetFieldValue("FEE_TRANSACTION");
			TXT_NON_H2H_DEV_FEE.Text = conn.GetFieldValue("NON_H2H_DEV_FEE");
			TXT_INDIRECT_COST.Text = conn.GetFieldValue("INDIRECT_COST_TRANSACTION");
			TXT_MONTHLY_MIN_TRANSACTION.Text = conn.GetFieldValue("MONTHLY_MINIMUM_TRANSACTION");
			TXT_PROVISI_FASILITAS.Text = conn.GetFieldValue("PROVISI_FASILITAS_QUARTAL_PERCENT");
			TXT_PROVISI_GIRO_JAMINAN.Text = conn.GetFieldValue("PROVISI_GIRO_JAMINAN_USD");
			TXT_UNIT_COST.Text = conn.GetFieldValue("UNIT_COST_PER_MILLION_UNIT");
			
			//kolom ketiga
			TXT_PROVISI_BLOKIR.Text = conn.GetFieldValue("PROVISI_BLOKIR_PERQUARTAL_PERCENT");
			TXT_INTEREST_RATE.Text = conn.GetFieldValue("INTEREST_RATE_PERCENT");
			TXT_IT_C0ST.Text = conn.GetFieldValue("IT_COST_TRANSACTION");
			TXT_JOINING_FEE.Text = conn.GetFieldValue("JOINING_FEE");
			TXT_MAX_PROVOSION.Text = conn.GetFieldValue("MAXIMUM_PROVISION_USD");
			TXT_MINIMUM_FEE.Text = conn.GetFieldValue("MINIMUM_FEE_PER_PROCESS");
			TXT_MINIMUM_PROVISION.Text = conn.GetFieldValue("MINIMUM_PROVISION_USD");
			TXT_PROVISION_IDR.Text = conn.GetFieldValue("PROVISION_PERCENT");
			TXT_RATE_EMPLOYEE2.Text = conn.GetFieldValue("RATE_PER_EMPLOYEE");
			TXT_REFERRAL_FEE_INCOME.Text = conn.GetFieldValue("REFERRAL_FEE_INCOME_PERCENT");
			TXT_SERVICE_COST.Text = conn.GetFieldValue("SERVICE_COST");
			TXT_SERVICE_FEE.Text = conn.GetFieldValue("SERVICE_FEE_PERCENT");
			TXT_TRANSACTION_FEE.Text = conn.GetFieldValue("TRANSACTION_FEE");
			TXT_SWIFT_FEE.Text = conn.GetFieldValue("SWIFT_FEE_PERCENT");
			TXT_SYNDICATION_FEE.Text = conn.GetFieldValue("SYNDICATION_FEE_PERCENT");
			TXT_USAGE_COMISSIOM_FEE.Text = conn.GetFieldValue("USAGE_COMMISION_FEE_PERCENT");

			//Kolom pertama
			TXT_ADMIN_FEE.Text = conn.GetFieldValue("ADMIN_FEE_PERCENT");
			TXT_ANNUAL_FEE.Text = conn.GetFieldValue("ANNUAL_FEE");
			TXT_BI_COST.Text = conn.GetFieldValue("BI_COST");
			TXT_CABLE_COST.Text = conn.GetFieldValue("CABLE_COST_USD");
			TXT_CABLE_FEE.Text = conn.GetFieldValue("CABLE_FEE_USD");
			TXT_FIXED_FEE2.Text = conn.GetFieldValue("FIXED_FEE");
			TXT_FTP_CKPN_IDR.Text = conn.GetFieldValue("FTP_CKPN_PERCENT");
			TXT_FTP_COST_IDR.Text = conn.GetFieldValue("FTP_COST_PERCENT");
			TXT_FTP_GWM2.Text = conn.GetFieldValue("FTP_GWM_PERCENT");
			TXT_FTP_INCOME_IDR.Text = conn.GetFieldValue("FTP_INCOME_PERCENT");
			TXT_OTHER_COST2.Text = conn.GetFieldValue("OTHER_COST_PERCENT");
			TXT_PENALTY_FEE.Text = conn.GetFieldValue("PENALTY_FEE_PERCENT");
			TXT_PREMIUM_LPS.Text = conn.GetFieldValue("PREMIUM_FOR_LPS_PERCENT");
			TXT_CKPN.Text = conn.GetFieldValue("CKPN_PERCENT");
			TXT_GWM.Text = conn.GetFieldValue("GWM_PERCENT");
			TXT_SPREAD.Text = conn.GetFieldValue("SPREAD_PERCENT");

			//tambahan
			TXT_FTP_INCOME_VALAS.Text = conn.GetFieldValue("FTP_INCOME_PERCENT_VALAS");
			TXT_FTP_CKPN_VALAS.Text = conn.GetFieldValue("FTP_CKPN_PERCENT_VALAS");
			TXT_FTP_COST_VALAS.Text = conn.GetFieldValue("FTP_COST_PERCENT_VALAS");
			TXT_PROVISION_VALAS.Text = conn.GetFieldValue("PROVISION_PERCENT_VALAS");
			
			conn.QueryString = "select * from ap_wallet_size_category_to_ap_model where ID_AP_VARIABLE = '"+ TXT_ID.Text +"' ";
			conn.ExecuteQuery();
			DDL_CATEGORY.SelectedValue = conn.GetFieldValue("ID_AP_WALLET_SIZE_CATEGORY");
		}

		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../AccountPlanningParam.aspx?mc=" + Request.QueryString["mc"]);
		}

		private void BTN_LINK_Click(object sender, System.EventArgs e)
		{			
			Response.Write("<script language='javascript'>window.open('LinkDataProductIPS.aspx?targetFormID=Form1&targetObjectID=TXT_LINKID&targetLinkID=" + DDL_PRODUCT_ID.SelectedValue + "&seq=" + SEQ.Text + " ','LinkDataProductIPS','status=no,scrollbars=yes,width=500,height=500');</script>");			
		}
	}
}
