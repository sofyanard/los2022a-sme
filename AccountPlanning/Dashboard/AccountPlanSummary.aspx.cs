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
using DMS.BlackList;

namespace SME.AccountPlanning.Dashboard
{
	/// <summary>
	/// Summary description for AccountPlanSummary.
	/// </summary>
	public partial class AccountPlanSummary : System.Web.UI.Page
	{
		//protected System.Web.UI.WebControls.TextBox undefined;
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			
			conn = (Connection) Session["Connection"];
			
			if(!IsPostBack)
			{	
				DeptData();	
				TR_UNIT.Visible = false;
				TR_GROUPUNIT.Visible = false;
				TR_INDUSTRY.Visible =  false;
				TR_PRODUCT.Visible = false;
			}

			/*--------------input data chart--------------*/
			string a = "30";
			string b = "30";
			string c = "40";

			double self = MyConnection.ConvertToDouble(a);
			double customer = MyConnection.ConvertToDouble(b);
			double valid = MyConnection.ConvertToDouble(c);
			
			selfassesment.Text = self.ToString();
			internalcustomer.Text = customer.ToString();
			validation.Text = valid.ToString();
			/*---------------------------------------------*/
		}

		private void DeptData()
		{			
			DDL_GROUP.Items.Add(new ListItem("--Pilih--", ""));			
			DDL_INDUSTRY.Items.Add(new ListItem("--Pilih--", ""));
			DDL_PRODUCT.Items.Add(new ListItem("--Pilih--",""));
			DDL_UNIT.Items.Add(new ListItem("--Pilih--",""));
			DDL_UNIT_NAME.Items.Add(new ListItem("--Pilih--",""));
			DDL_CUST_NAME.Items.Add(new ListItem("--Pilih--",""));

			conn.QueryString="select * from rfbranch where active='1' order by branch_name";
			conn.ExecuteQuery();			
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_GROUP.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			
			conn.QueryString="select * from PD_RF_INDUSTRY_CLASS where active='1' order by pd_industry_name";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_INDUSTRY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString="select * from rfproduct where active='1' order by productdesc";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_PRODUCT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			
			conn.QueryString="select * from VW_AP_SUMMARY_UNIT_NAME where active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_UNIT_NAME.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString="select * from VW_AP_SUMMARY_CUST_NAME where active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CUST_NAME.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		protected void DDL_GROUP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select bussunitid from rfbranch where branch_code = '"+DDL_GROUP.SelectedValue+"' ";
			conn.ExecuteQuery();
			string bussunitid = conn.GetFieldValue("bussunitid");
			
			conn.QueryString="select * from rfbusinessunit where active='1' and bussunitid='"+bussunitid+"' order by bussunitdesc";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
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
			this.DGR_UNIT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_UNIT_PageIndexChanged);
			this.DGR_COMP_TREE.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_COMP_TREE_PageIndexChanged);
			this.DGR_COMPETITOR_SCAN.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_COMPETITOR_SCAN_PageIndexChanged);
			this.DGR_DEAL_TOP10.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_DEAL_TOP10_PageIndexChanged);
			this.DGR_DEAL_KEY.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_DEAL_KEY_PageIndexChanged);

		}
		#endregion

		protected void BTN_RTV_Click(object sender, System.EventArgs e)
		{
			if(DDL_GROUP.SelectedValue != "" && DDL_INDUSTRY.SelectedValue == "" && DDL_PRODUCT.SelectedValue == "" && DDL_UNIT.SelectedValue=="")
			{
				TR_GROUPUNIT.Visible = true;
				TR_INDUSTRY.Visible = false;
				TR_PRODUCT.Visible = false;
				TR_UNIT.Visible = false;
				
				ViewDataGroupUnit();
			}
			if(DDL_GROUP.SelectedValue != "" && DDL_INDUSTRY.SelectedValue == "" && DDL_PRODUCT.SelectedValue == "" && DDL_UNIT.SelectedValue != "")
			{
				TR_GROUPUNIT.Visible = false;
				TR_INDUSTRY.Visible = false;
				TR_PRODUCT.Visible = false;
				TR_UNIT.Visible = true;

				ViewDataUnit();
			}
			if(DDL_PRODUCT.SelectedValue != "" && DDL_INDUSTRY.SelectedValue == "")
			{
				TR_GROUPUNIT.Visible = false;
				TR_INDUSTRY.Visible = false;
				TR_PRODUCT.Visible = true;
				TR_UNIT.Visible = false;

				ViewDataProduct();
			}
			if(DDL_PRODUCT.SelectedValue == "" && DDL_INDUSTRY.SelectedValue != "")
			{
				TR_GROUPUNIT.Visible = false;
				TR_INDUSTRY.Visible = true;
				TR_PRODUCT.Visible = false;
				TR_UNIT.Visible = false;

				ViewDataIndustry();
			}
		}

		private void ViewDataGroupUnit()
		{
			conn.QueryString = " exec AP_DASHBOARD_SUMMARY_UNIT_GROUP_NAME_VOLUME";
			conn.ExecuteQuery();
			TXT_LC1_GROUP.Text = conn.GetFieldValue("LCF_Target_2012");
			TXT_LC2_GROUP.Text = conn.GetFieldValue("LCF_Wallet_Size_Est");
			TXT_LC3_GROUP.Text = conn.GetFieldValue("LCF_Wallet_Size_Share");
			TXT_TD1_GROUP.Text = conn.GetFieldValue("TD_Target_2012");
			TXT_TD2_GROUP.Text = conn.GetFieldValue("TD_Wallet_Size_Est");
			TXT_TD3_GROUP.Text = conn.GetFieldValue("TD_Wallet_Size_Share");
			TXT_TC1_GROUP.Text = conn.GetFieldValue("TC_Target_2012");
			TXT_TC2_GROUP.Text = conn.GetFieldValue("TC_Wallet_Size_Est");
			TXT_TC3_GROUP.Text = conn.GetFieldValue("TC_Wallet_Size_Share");
			TXT_IL1_GROUP.Text = conn.GetFieldValue("IL_Target_2012");
			TXT_IL2_GROUP.Text = conn.GetFieldValue("IL_Wallet_Size_Est");
			TXT_IL3_GROUP.Text = conn.GetFieldValue("IL_Wallet_Size_Share");
			TXT_WL1_GROUP.Text = conn.GetFieldValue("WL_Target_2012");
			TXT_WL2_GROUP.Text = conn.GetFieldValue("WL_Wallet_Size_Est");
			TXT_WL3_GROUP.Text = conn.GetFieldValue("WL_Wallet_Size_Share");
			TXT_U1_GROUP.Text = conn.GetFieldValue("U_Target_2012");
			TXT_U2_GROUP.Text = conn.GetFieldValue("U_Wallet_Size_Est");
			TXT_U3_GROUP.Text = conn.GetFieldValue("U_Wallet_Size_Share");
			
			TXT_WI_NII1_GROUP.Text = conn.GetFieldValue("WI_NII_Target_2012");
			TXT_WI_NII2_GROUP.Text = conn.GetFieldValue("WI_NII_Wallet_Size_Est");
			TXT_WI_NII3_GROUP.Text = conn.GetFieldValue("WI_NII_Wallet_Size_Share");
			TXT_WI_ASSETS1_GROUP.Text = conn.GetFieldValue("WI_Assets_Target_2012");
			TXT_WI_ASSETS2_GROUP.Text = conn.GetFieldValue("WI_Assets_Wallet_Size_Est");
			TXT_WI_ASSETS3_GROUP.Text = conn.GetFieldValue("WI_Assets_Wallet_Size_Share");
			TXT_WI_LIABILITIS1_GROUP.Text = conn.GetFieldValue("WI_Liabilities_Target_2012");
			TXT_WI_LIABILITIS2_GROUP.Text = conn.GetFieldValue("WI_Liabilities_Wallet_Size_Est");
			TXT_WI_LIABILITIS3_GROUP.Text = conn.GetFieldValue("WI_Liabilities_Wallet_Size_Share");
			TXT_WI_FI1_GROUP.Text = conn.GetFieldValue("WI_FI_Target_2012");
			TXT_WI_FI2_GROUP.Text = conn.GetFieldValue("WI_FI_Wallet_Size_Est");
			TXT_WI_FI3_GROUP.Text = conn.GetFieldValue("WI_FI_Wallet_Size_Share");
			TXT_WI_DCA1_GROUP.Text = conn.GetFieldValue("WI_DCA_Target_2012");
			TXT_WI_DCA2_GROUP.Text = conn.GetFieldValue("WI_DCA_Wallet_Size_Est");
			TXT_WI_DCA3_GROUP.Text = conn.GetFieldValue("WI_DCA_Wallet_Size_Share");
			TXT_WI_CM1_GROUP.Text = conn.GetFieldValue("WI_CM_Target_2012");
			TXT_WI_CM2_GROUP.Text = conn.GetFieldValue("WI_CM_Wallet_Size_Est");
			TXT_WI_CM3_GROUP.Text = conn.GetFieldValue("WI_CM_Wallet_Size_Share");

			TXT_AI_NII1_GROUP.Text = conn.GetFieldValue("AI_NII_Target_2012");
			TXT_AI_NII2_GROUP.Text = conn.GetFieldValue("AI_NII_Wallet_Size_Est");
			TXT_AI_NII3_GROUP.Text = conn.GetFieldValue("AI_NII_Wallet_Size_Share");
			TXT_AI_ASSETS1_GROUP.Text = conn.GetFieldValue("AI_Assets_Target_2012");
			TXT_AI_ASSETS2_GROUP.Text = conn.GetFieldValue("AI_Assets_Wallet_Size_Est");
			TXT_AI_ASSETS3_GROUP.Text = conn.GetFieldValue("AI_Assets_Wallet_Size_Share");
			TXT_AI_LIABILITIS1_GROUP.Text = conn.GetFieldValue("AI_Liabilities_Target_2012");
			TXT_AI_LIABILITIS2_GROUP.Text = conn.GetFieldValue("AI_Liabilities_Wallet_Size_Est");			
			TXT_AI_LIABILITIS3_GROUP.Text = conn.GetFieldValue("AI_Liabilities_Wallet_Size_Share");	
			TXT_AI_FI1_GROUP.Text = conn.GetFieldValue("AI_FI_Target_2012");	
			TXT_AI_FI2_GROUP.Text = conn.GetFieldValue("AI_FI_Wallet_Size_Est");	
			TXT_AI_FI3_GROUP.Text = conn.GetFieldValue("AI_FI_Wallet_Size_Share");	

			TXT_TRI1_GROUP.Text = conn.GetFieldValue("TRI_Target_2012");	
			TXT_TRI2_GROUP.Text = conn.GetFieldValue("TRI_Wallet_Size_Est");	
			TXT_TRI3_GROUP.Text = conn.GetFieldValue("TRI_Wallet_Size_Share");	
		}		

		private void ViewDataUnit()
		{
			conn.QueryString = "exec AP_DASHBOARD_SUMMARY_UNIT_NAME";
			conn.ExecuteQuery();
			FillGridUnit();
		}

		private void FillGridUnit()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_UNIT.DataSource = dt;
			try 
			{
				DGR_UNIT.DataBind();
			} 
			catch 
			{
				DGR_UNIT.CurrentPageIndex = 0;
				DGR_UNIT.DataBind();
			}			
		}

		private void DGR_UNIT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_UNIT.CurrentPageIndex = e.NewPageIndex;
		}

		private void ViewDataIndustry()
		{
			conn.QueryString = " exec AP_DASHBOARD_SUMMARY_UNIT_GROUP_NAME_VOLUME";
			conn.ExecuteQuery();
			TXT_LCF1_INDUSTRY.Text = conn.GetFieldValue("LCF_Target_2012");
			TXT_LCF2_INDUSTRY.Text = conn.GetFieldValue("LCF_Wallet_Size_Est");
			TXT_LCF3_INDUSTRY.Text = conn.GetFieldValue("LCF_Wallet_Size_Share");
			TXT_TD1_INDUSTRY.Text = conn.GetFieldValue("TD_Target_2012");
			TXT_TD2_INDUSTRY.Text = conn.GetFieldValue("TD_Wallet_Size_Est");
			TXT_TD3_INDUSTRY.Text = conn.GetFieldValue("TD_Wallet_Size_Share");
			TXT_TCF1_INDUSTRY.Text = conn.GetFieldValue("TC_Target_2012");
			TXT_TCF2_INDUSTRY.Text = conn.GetFieldValue("TC_Wallet_Size_Est");
			TXT_TCF3_INDUSTRY.Text = conn.GetFieldValue("TC_Wallet_Size_Share");
			TXT_IL1_INDUSTRY.Text = conn.GetFieldValue("IL_Target_2012");
			TXT_IL2_INDUSTRY.Text = conn.GetFieldValue("IL_Wallet_Size_Est");
			TXT_IL3_INDUSTRY.Text = conn.GetFieldValue("IL_Wallet_Size_Share");
			TXT_WCL1_INDUSTRY.Text = conn.GetFieldValue("WL_Target_2012");
			TXT_WCL2_INDUSTRY.Text = conn.GetFieldValue("WL_Wallet_Size_Est");
			TXT_WCL3_INDUSTRY.Text = conn.GetFieldValue("WL_Wallet_Size_Share");
			TXT_U1_INDUSTRY.Text = conn.GetFieldValue("U_Target_2012");
			TXT_U2_INDUSTRY.Text = conn.GetFieldValue("U_Wallet_Size_Est");
			TXT_U3_INDUSTRY.Text = conn.GetFieldValue("U_Wallet_Size_Share");
			
			TXT_WI_NII1_INDUSTRY.Text = conn.GetFieldValue("WI_NII_Target_2012");
			TXT_WI_NII2_INDUSTRY.Text = conn.GetFieldValue("WI_NII_Wallet_Size_Est");
			TXT_WI_NII3_INDUSTRY.Text = conn.GetFieldValue("WI_NII_Wallet_Size_Share");
			TXT_WI_ASSETS1_INDUSTRY.Text = conn.GetFieldValue("WI_Assets_Target_2012");
			TXT_WI_ASSETS2_INDUSTRY.Text = conn.GetFieldValue("WI_Assets_Wallet_Size_Est");
			TXT_WI_ASSETS3_INDUSTRY.Text = conn.GetFieldValue("WI_Assets_Wallet_Size_Share");
			TXT_WI_LIABILITIES1_INDUSTRY.Text = conn.GetFieldValue("WI_Liabilities_Target_2012");
			TXT_WI_LIABILITIES2_INDUSTRY.Text = conn.GetFieldValue("WI_Liabilities_Wallet_Size_Est");
			TXT_WI_LIABILITIES3_INDUSTRY.Text = conn.GetFieldValue("WI_Liabilities_Wallet_Size_Share");
			TXT_WI_FI1_INDUSTRY.Text = conn.GetFieldValue("WI_FI_Target_2012");
			TXT_WI_FI2_INDUSTRY.Text = conn.GetFieldValue("WI_FI_Wallet_Size_Est");
			TXT_WI_FI3_INDUSTRY.Text = conn.GetFieldValue("WI_FI_Wallet_Size_Share");
			TXT_WI_DCA1_INDUSTRY.Text = conn.GetFieldValue("WI_DCA_Target_2012");
			TXT_WI_DCA2_INDUSTRY.Text = conn.GetFieldValue("WI_DCA_Wallet_Size_Est");
			TXT_WI_DCA3_INDUSTRY.Text = conn.GetFieldValue("WI_DCA_Wallet_Size_Share");
			TXT_WI_CM1_INDUSTRY.Text = conn.GetFieldValue("WI_CM_Target_2012");
			TXT_WI_CM2_INDUSTRY.Text = conn.GetFieldValue("WI_CM_Wallet_Size_Est");
			TXT_WI_CM3_INDUSTRY.Text = conn.GetFieldValue("WI_CM_Wallet_Size_Share");

			TXT_AI_NII1_INDUSTRY.Text = conn.GetFieldValue("AI_NII_Target_2012");
			TXT_AI_NII2_INDUSTRY.Text = conn.GetFieldValue("AI_NII_Wallet_Size_Est");
			TXT_AI_NII3_INDUSTRY.Text = conn.GetFieldValue("AI_NII_Wallet_Size_Share");
			TXT_AI_ASSETS1_INDUSTRY.Text = conn.GetFieldValue("AI_Assets_Target_2012");
			TXT_AI_ASSETS2_INDUSTRY.Text = conn.GetFieldValue("AI_Assets_Wallet_Size_Est");
			TXT_AI_ASSETS3_INDUSTRY.Text = conn.GetFieldValue("AI_Assets_Wallet_Size_Share");
			TXT_AI_LIABILITIES1_INDUSTRY.Text = conn.GetFieldValue("AI_Liabilities_Target_2012");
			TXT_AI_LIABILITIES2_INDUSTRY.Text = conn.GetFieldValue("AI_Liabilities_Wallet_Size_Est");			
			TXT_AI_LIABILITIES3_INDUSTRY.Text = conn.GetFieldValue("AI_Liabilities_Wallet_Size_Share");	
			TXT_AI_FI1_INDUSTRY.Text = conn.GetFieldValue("AI_FI_Target_2012");	
			TXT_AI_FI2_INDUSTRY.Text = conn.GetFieldValue("AI_FI_Wallet_Size_Est");	
			TXT_AI_FI3_INDUSTRY.Text = conn.GetFieldValue("AI_FI_Wallet_Size_Share");	

			TXT_TRI1_INDUSTRY.Text = conn.GetFieldValue("TRI_Target_2012");	
			TXT_TRI2_INDUSTRY.Text = conn.GetFieldValue("TRI_Wallet_Size_Est");	
			TXT_TRI3_INDUSTRY.Text = conn.GetFieldValue("TRI_Wallet_Size_Share");	
		}

		private void ViewDataProduct()
		{
			conn.QueryString = "exec AP_DASHBOARD_SUMMARY_PRODUCT_NAME";
			conn.ExecuteQuery();
			FillGridProduct();
		}

		private void FillGridProduct()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_PRODUCT.DataSource = dt;
			try 
			{
				DGR_PRODUCT.DataBind();
			} 
			catch 
			{
				DGR_PRODUCT.CurrentPageIndex = 0;
				DGR_PRODUCT.DataBind();
			}			
		}

		private void DGR_PRODUCT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_PRODUCT.CurrentPageIndex = e.NewPageIndex;
		}

		protected void BTN_RETRIEVE2_Click(object sender, System.EventArgs e)
		{
			ViewCustDetailInfo();
			ViewDataCompTree();
			ViewDataKeyFinancial(); 
			ViewDataCompetitorScan();
			ViewDataDealPreasure();
			ViewDataDealKey();
			ViewKeyTargets();
		}

		private void ViewCustDetailInfo()
		{
			conn.QueryString = "exec AP_DASHBOARD_SUMMARY_CUST_DETAIL_INFO";
			conn.ExecuteQuery();
			TXT_CIF_NO.Text = conn.GetFieldValue("CIF_No");
			TXT_CUST_NAME.Text = conn.GetFieldValue("Cust_Name");
			TXT_ADDRESS.Text = conn.GetFieldValue("Address");
			TXT_KOTA.Text = conn.GetFieldValue("Kota");
			TXT_PRIMARY_RELATIONS.Text = conn.GetFieldValue("Primary_Relations");
			TXT_CUST_DATE.Text = conn.GetFieldValue("Customer_Date");
			TXT_LOR.Text = conn.GetFieldValue("LOR");
			TXT_RELATIONSHIP_MANAGER.Text = conn.GetFieldValue("RM");
			TXT_GROUP_NAME.Text = conn.GetFieldValue("Group_Name");
			TXT_UNIT_NAME.Text = conn.GetFieldValue("Unit_Name");
			TXT_BUSINESS_DESC.Text = conn.GetFieldValue("buss_desc");
			TXT_RECENT_DEV.Text = conn.GetFieldValue("recent_dev");
			TXT_NOTES.Text = conn.GetFieldValue("Notes_Deal");
		}

		private void ViewDataCompTree()
		{
			conn.QueryString = "exec AP_DASHBOARD_SUMMARY_COMP_TREE";
			conn.ExecuteQuery();
			FillGridCompTree();
		}

		private void FillGridCompTree()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_COMP_TREE.DataSource = dt;
			try 
			{
				DGR_COMP_TREE.DataBind();
			} 
			catch 
			{
				DGR_COMP_TREE.CurrentPageIndex = 0;
				DGR_COMP_TREE.DataBind();
			}			
		}

		private void DGR_COMP_TREE_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_COMP_TREE.CurrentPageIndex = e.NewPageIndex;
		}

		private void ViewDataKeyFinancial()
		{
			conn.QueryString = " exec AP_DASHBOARD_SUMMARY_KEY_FINANCIAL";
			conn.ExecuteQuery();
			TXT_CURRENCY.Text = conn.GetFieldValue("Currency");
			TXT_DENOMINATOR.Text = conn.GetFieldValue("Denominator");
			TXT_CASHBANK1.Text = conn.GetFieldValue("CNB_1");
			TXT_CASHBANK2.Text = conn.GetFieldValue("CNB_2");
			TXT_CASHBANK3.Text = conn.GetFieldValue("CNB_3");
			TXT_CASHBANK4.Text = conn.GetFieldValue("CNB_4");
			TXT_TOT_ASSET1.Text = conn.GetFieldValue("TA_1");
			TXT_TOT_ASSET2.Text = conn.GetFieldValue("TA_2");
			TXT_TOT_ASSET3.Text = conn.GetFieldValue("TA_3");
			TXT_TOT_ASSET4.Text = conn.GetFieldValue("TA_4");
			TXT_TOT_LOAN1.Text = conn.GetFieldValue("TL_1");
			TXT_TOT_LOAN2.Text = conn.GetFieldValue("TL_2");
			TXT_TOT_LOAN3.Text = conn.GetFieldValue("TL_3");
			TXT_TOT_LOAN4.Text = conn.GetFieldValue("TL_4");
			TXT_OPERATING_EARNING1.Text = conn.GetFieldValue("OE_1");
			TXT_OPERATING_EARNING2.Text = conn.GetFieldValue("OE_2");
			TXT_OPERATING_EARNING3.Text = conn.GetFieldValue("OE_3");
			TXT_OPERATING_EARNING4.Text = conn.GetFieldValue("OE_4");
			TXT_EBIT1.Text = conn.GetFieldValue("EBIT_1");
			TXT_EBIT2.Text = conn.GetFieldValue("EBIT_2");
			TXT_EBIT3.Text = conn.GetFieldValue("EBIT_3");
			TXT_EBIT4.Text = conn.GetFieldValue("EBIT_4");
			TXT_EBIT_MARGINS1.Text = conn.GetFieldValue("EBIT_M1");
			TXT_EBIT_MARGINS2.Text = conn.GetFieldValue("EBIT_M2");
			TXT_EBIT_MARGINS3.Text = conn.GetFieldValue("EBIT_M3");
			TXT_EBIT_MARGINS4.Text = conn.GetFieldValue("EBIT_M4");
			TXT_NET_INCOME1.Text = conn.GetFieldValue("NI_1");
			TXT_NET_INCOME2.Text = conn.GetFieldValue("NI_2");
			TXT_NET_INCOME3.Text = conn.GetFieldValue("NI_3");
			TXT_NET_INCOME4.Text = conn.GetFieldValue("NI_4");
			TXT_NPAT_MARGINS1.Text = conn.GetFieldValue("NPAT_N1");	
			TXT_NPAT_MARGINS2.Text = conn.GetFieldValue("NPAT_N2");	
			TXT_NPAT_MARGINS3.Text = conn.GetFieldValue("NPAT_N3");	
			TXT_NPAT_MARGINS4.Text = conn.GetFieldValue("NPAT_N4");
			TXT_CURRENT_RATIO1.Text = conn.GetFieldValue("CR_1");
			TXT_CURRENT_RATIO2.Text = conn.GetFieldValue("CR_2");
			TXT_CURRENT_RATIO3.Text = conn.GetFieldValue("CR_3");
			TXT_CURRENT_RATIO4.Text = conn.GetFieldValue("CR_4");
			TXT_DEBT_TO_ASSETS1.Text = conn.GetFieldValue("DA_1");
			TXT_DEBT_TO_ASSETS2.Text = conn.GetFieldValue("DA_2");
			TXT_DEBT_TO_ASSETS3.Text = conn.GetFieldValue("DA_3");
			TXT_DEBT_TO_ASSETS4.Text = conn.GetFieldValue("DA_4");
			TXT_INTEREST_COVERAGE1.Text = conn.GetFieldValue("IC_1");
			TXT_INTEREST_COVERAGE2.Text = conn.GetFieldValue("IC_2");
			TXT_INTEREST_COVERAGE3.Text = conn.GetFieldValue("IC_3");
			TXT_INTEREST_COVERAGE4.Text = conn.GetFieldValue("IC_4");
			TXT_INVENTORY_TURNOVER1.Text = conn.GetFieldValue("IT_1");
			TXT_INVENTORY_TURNOVER2.Text = conn.GetFieldValue("IT_2");
			TXT_INVENTORY_TURNOVER3.Text = conn.GetFieldValue("IT_3");
			TXT_INVENTORY_TURNOVER4.Text = conn.GetFieldValue("IT_4");
			TXT_ACP1.Text = conn.GetFieldValue("ACP_1");
			TXT_ACP2.Text = conn.GetFieldValue("ACP_2");
			TXT_ACP3.Text = conn.GetFieldValue("ACP_3");
			TXT_ACP4.Text = conn.GetFieldValue("ACP_4");
			TXT_EMPLOYEE1.Text = conn.GetFieldValue("employee1");
			TXT_EMPLOYEE2.Text = conn.GetFieldValue("employee2");
			TXT_EMPLOYEE3.Text = conn.GetFieldValue("employee3");
			TXT_EMPLOYEE4.Text = conn.GetFieldValue("employee4");
		}

		private void ViewDataCompetitorScan()
		{
			conn.QueryString = "exec AP_DASHBOARD_SUMMARY_COMPETITOR_SCAN";
			conn.ExecuteQuery();
			FillGridCompetitorScan();
		}

		private void FillGridCompetitorScan()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_COMPETITOR_SCAN.DataSource = dt;
			try 
			{
				DGR_COMPETITOR_SCAN.DataBind();
			} 
			catch 
			{
				DGR_COMPETITOR_SCAN.CurrentPageIndex = 0;
				DGR_COMPETITOR_SCAN.DataBind();
			}			
		}

		private void DGR_COMPETITOR_SCAN_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_COMPETITOR_SCAN.CurrentPageIndex = e.NewPageIndex;
		}

		private void ViewDataDealPreasure()
		{
			conn.QueryString = "exec AP_DASHBOARD_SUMMARY_DEAL_LEAD_PERSUE";
			conn.ExecuteQuery();
			FillGridDealPreasure();
		}

		private void FillGridDealPreasure()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_DEAL_TOP10.DataSource = dt;
			try 
			{
				DGR_DEAL_TOP10.DataBind();
			} 
			catch 
			{
				DGR_DEAL_TOP10.CurrentPageIndex = 0;
				DGR_DEAL_TOP10.DataBind();
			}			
		}

		private void DGR_DEAL_TOP10_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_DEAL_TOP10.CurrentPageIndex = e.NewPageIndex;
		}

		private void ViewDataDealKey()
		{
			conn.QueryString = "exec AP_DASHBOARD_SUMMARY_DEAL_LEAD_KEY";
			conn.ExecuteQuery();
			FillGridDealKey();
		}

		private void FillGridDealKey()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_DEAL_KEY.DataSource = dt;
			try 
			{
				DGR_DEAL_KEY.DataBind();
			} 
			catch 
			{
				DGR_DEAL_KEY.CurrentPageIndex = 0;
				DGR_DEAL_KEY.DataBind();
			}			
		}

		private void DGR_DEAL_KEY_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_DEAL_KEY.CurrentPageIndex = e.NewPageIndex;
		}

		private void ViewKeyTargets()
		{
			conn.QueryString = "AP_DASHBOARD_SUMMARY_KEY_TARGETS";
			conn.ExecuteQuery();
			TXT_KEY_LCF1.Text = conn.GetFieldValue("LCF_1");
			TXT_KEY_LCF2.Text = conn.GetFieldValue("LCF_2");
			TXT_KEY_LCF3.Text = conn.GetFieldValue("LCF_3");
			TXT_KEY_LCF4.Text = conn.GetFieldValue("LCF_4");
			TXT_KEY_TD1.Text = conn.GetFieldValue("TD_1");
			TXT_KEY_TD2.Text = conn.GetFieldValue("TD_2");
			TXT_KEY_TD3.Text = conn.GetFieldValue("TD_3");
			TXT_KEY_TD4.Text = conn.GetFieldValue("TD_4");
			TXT_KEY_TCF1.Text = conn.GetFieldValue("TCF_1");
			TXT_KEY_TCF2.Text = conn.GetFieldValue("TCF_2");
			TXT_KEY_TCF3.Text = conn.GetFieldValue("TCF_3");
			TXT_KEY_TCF4.Text = conn.GetFieldValue("TCF_4");
			TXT_KEY_IL1.Text = conn.GetFieldValue("IL_1");
			TXT_KEY_IL2.Text = conn.GetFieldValue("IL_2");
			TXT_KEY_IL3.Text = conn.GetFieldValue("IL_3");
			TXT_KEY_IL4.Text = conn.GetFieldValue("IL_4");
			TXT_KEY_WCL1.Text = conn.GetFieldValue("WCL_1");
			TXT_KEY_WCL2.Text = conn.GetFieldValue("WCL_2");
			TXT_KEY_WCL3.Text = conn.GetFieldValue("WCL_3");
			TXT_KEY_WCL4.Text = conn.GetFieldValue("WCL_4");
			TXT_KEY_U1.Text = conn.GetFieldValue("U1");
			TXT_KEY_U2.Text = conn.GetFieldValue("U2");
			TXT_KEY_U3.Text = conn.GetFieldValue("U3");
			TXT_KEY_U4.Text = conn.GetFieldValue("U4");
			TXT_KEY_WI_NII1.Text = conn.GetFieldValue("NII1");
			TXT_KEY_WI_NII2.Text = conn.GetFieldValue("NII2");
			TXT_KEY_WI_NII3.Text = conn.GetFieldValue("NII3");
			TXT_KEY_WI_NII4.Text = conn.GetFieldValue("NII4");
			TXT_KEY_WI_A1.Text = conn.GetFieldValue("Assets1");
			TXT_KEY_WI_A2.Text = conn.GetFieldValue("Assets2");
			TXT_KEY_WI_A3.Text = conn.GetFieldValue("Assets3");
			TXT_KEY_WI_A4.Text = conn.GetFieldValue("Assets4");
			TXT_KEY_WI_L1.Text = conn.GetFieldValue("L1");
			TXT_KEY_WI_L2.Text = conn.GetFieldValue("L2");
			TXT_KEY_WI_L3.Text = conn.GetFieldValue("L3");
			TXT_KEY_WI_L4.Text = conn.GetFieldValue("L4");
			TXT_KEY_WI_FI1.Text = conn.GetFieldValue("FI1");
			TXT_KEY_WI_FI2.Text = conn.GetFieldValue("FI2");
			TXT_KEY_WI_FI3.Text = conn.GetFieldValue("FI3");
			TXT_KEY_WI_FI4.Text = conn.GetFieldValue("FI4");
			TXT_KEY_WI_DCA1.Text = conn.GetFieldValue("DCA1");
			TXT_KEY_WI_DCA2.Text = conn.GetFieldValue("DCA2");
			TXT_KEY_WI_DCA3.Text = conn.GetFieldValue("DCA3");
			TXT_KEY_WI_DCA4.Text = conn.GetFieldValue("DCA4");
			TXT_KEY_WI_CM1.Text = conn.GetFieldValue("CM1");
			TXT_KEY_WI_CM2.Text = conn.GetFieldValue("CM2");
			TXT_KEY_WI_CM3.Text = conn.GetFieldValue("CM3");
			TXT_KEY_WI_CM4.Text = conn.GetFieldValue("CM4");
			TXT_KEY_AI_NII1.Text = conn.GetFieldValue("AI_NII1");
			TXT_KEY_AI_NII2.Text = conn.GetFieldValue("AI_NII2");
			TXT_KEY_AI_NII3.Text = conn.GetFieldValue("AI_NII3");
			TXT_KEY_AI_NII4.Text = conn.GetFieldValue("AI_NII4");
			TXT_KEY_AI_A1.Text = conn.GetFieldValue("AI_Assets1");
			TXT_KEY_AI_A2.Text = conn.GetFieldValue("AI_Assets2");
			TXT_KEY_AI_A3.Text = conn.GetFieldValue("AI_Assets3");
			TXT_KEY_AI_A4.Text = conn.GetFieldValue("AI_Assets4");
			TXT_KEY_AI_L1.Text = conn.GetFieldValue("AI_L1");
			TXT_KEY_AI_L2.Text = conn.GetFieldValue("AI_L2");
			TXT_KEY_AI_L3.Text = conn.GetFieldValue("AI_L3");
			TXT_KEY_AI_L4.Text = conn.GetFieldValue("AI_L4");
			TXT_KEY_AI_FI1.Text = conn.GetFieldValue("AI_FI1");
			TXT_KEY_AI_FI2.Text = conn.GetFieldValue("AI_FI2");
			TXT_KEY_AI_FI3.Text = conn.GetFieldValue("AI_FI3");
			TXT_KEY_AI_FI4.Text = conn.GetFieldValue("AI_FI4");
		}

	}
}
