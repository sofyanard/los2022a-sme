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
using System.Configuration;
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;

namespace SME.AccountPlanning.ActionPlanSetup
{
	/// <summary>
	/// Summary description for OpportunityTarget.
	/// </summary>
	public partial class OpportunityTarget : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label11;
		protected Tools tools = new Tools();
		protected System.Web.UI.WebControls.TextBox TXT_UNIT_MEASURE;
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				ViewData();

				TR_COMPANY_HEADER.Visible	= false;
				TR_COMPANY_GRID.Visible		= false;
				TR_COMPANY_FIELD.Visible	= false;
				TR_COMPANY_BTN.Visible		= false;

				FillDDLCategory();
				FillDDLProduct();
				FillDDLType();
				FillDDLUnit();
				ViewCompany();
			}
			ViewMenu();
			FillGridWholesale();
			FillGridAlliance();
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM AP_ANCHOR_INFO WHERE CIF#='" + Request.QueryString["cif"] + "' ORDER BY CONVERT(INT, CIF#)";
			conn.ExecuteQuery();

			TXT_CIF.Text				= conn.GetFieldValue("CIF#").ToString();
			TXT_CUST_NAME.Text			= conn.GetFieldValue("CUSTOMER_GROUP").ToString();
			TXT_ADDRESS.Text			= conn.GetFieldValue("CUST_ADDRESS").ToString();
			TXT_KOTA.Text				= conn.GetFieldValue("CUST_CITY").ToString();
			TXT_CUST_DATE.Text			= tools.FormatDate(conn.GetFieldValue("CUST_DATE").ToString());
			TXT_RM.Text					= conn.GetFieldValue("RM_NAME").ToString();
			TXT_GROUP_NAME.Text			= conn.GetFieldValue("GROUP_NAME").ToString();
			TXT_UNIT_NAME.Text			= conn.GetFieldValue("BUC").ToString();
			TXT_RELATIONSHIP.Text		= conn.GetFieldValue("CUST_LENGTH").ToString();
		}

		private void ViewMenu()
		{
			Menu.Controls.Clear();
			try 
			{
				conn.QueryString = "SELECT * FROM SCREENMENU WHERE MENUCODE = '" + Request.QueryString["mc"] + "'";
				conn.ExecuteQuery();
				
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "cif=" + Request.QueryString["cif"] + "&bs=" + Request.QueryString["bs"] + "&bc=" + Request.QueryString["bc"] + "&rd=" + Request.QueryString["rd"] + "&cd=" + Request.QueryString["cd"];
						else	
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&cif=" + Request.QueryString["cif"] + "&bs=" + Request.QueryString["bs"] + "&bc=" + Request.QueryString["bc"] + "&rd=" + Request.QueryString["rd"] + "&cd=" + Request.QueryString["cd"];
					}
					else 
					{
						strtemp = ""; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void FillDDLCategory()
		{
			DDL_CATEGORY.Items.Clear();
			DDL_CATEGORY.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT ID_AP_WALLET_SIZE_CATEGORY, [DESCRIPTION] FROM AP_WALLET_SIZE_CATEGORY WHERE ACTIVE = '1'";
			conn.ExecuteQuery();
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_CATEGORY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		protected void DDL_CATEGORY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TXT_OPP_DESC1.Text				= "";
			//TXT_OPP_DESC2.Text			= "";
			//TXT_OPP_DESC3.Text			= "";
			TXT_ASSUMP_WALLET.Text			= "";
			//TXT_ASSUMP_TARGET.Text		= "";
			//TXT_ASSUMP_SPREAD.Text		= "";
			TXT_WS_VOL.Text					= "";
			TXT_WS_INC.Text					= "";
			TXT_REAL_VOL.Text				= "";
			TXT_REAL_INC.Text				= "";
			TXT_REAL_SHARE.Text				= "";
			DDL_TYPE.SelectedValue			= "";
			DDL_UNIT_MEASURE.SelectedValue	= "";
			//TXT_AVG_BALANCE.Text			= "";
			//TXT_SPREAD.Text				= "";
			TXT_PROPOSED_VOL.Text			= "";
			TXT_PROPOSED_INC.Text			= "";
			TXT_PROPOSED_SHARE.Text			= "";
			TXT_PROPOSED_GROWTH.Text		= "";

			FillDDLProduct();
		}

		private void FillDDLProduct()
		{
			DDL_PRODUCT.Items.Clear();
			DDL_PRODUCT.Items.Add(new ListItem("--Select--", ""));

			if(DDL_CATEGORY.SelectedValue == "")
			{
				conn.QueryString = "SELECT ID_AP_VARIABLE, [DESCRIPTION] FROM AP_VARIABLE WHERE STATUS = '1'";
				conn.ExecuteQuery();
			}
			else
			{
				conn.QueryString = "SELECT B.* FROM AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL A LEFT JOIN " +
					"(SELECT DISTINCT ID_AP_VARIABLE, [DESCRIPTION] FROM AP_VARIABLE) B ON A.ID_AP_VARIABLE=B.ID_AP_VARIABLE " +
					"WHERE ID_AP_WALLET_SIZE_CATEGORY='" + DDL_CATEGORY.SelectedValue + "'";
				conn.ExecuteQuery();
			}
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_PRODUCT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		protected void DDL_PRODUCT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DDL_PRODUCT.SelectedValue != "")
			{
				float wallet_inc = 0;	float real_inc = 0;	int result = 0;

				//Ambil data Type & Unit Measurement
				/*conn.QueryString = "SELECT TYPE_ID, MEASURE_NM FROM AP_RF_PRODUCT WHERE PRODUCT_ID = '" + DDL_PRODUCT.SelectedValue + "'";
				conn.ExecuteQuery();

				DDL_TYPE.SelectedValue			= conn.GetFieldValue("TYPE_ID");
				DDL_UNIT_MEASURE.SelectedValue	= conn.GetFieldValue("MEASURE_NM");*/

				//Ambil data Wallet Size Volume & Income This Year
				conn.QueryString = "SELECT CURRENT_VOLUME, CURRENT_INCOME FROM AP_WALLET_SIZE_RESULT " +
									"WHERE CU_CIF='" + DDL_COMPANY.SelectedValue + "' AND ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL='" + DDL_PRODUCT.SelectedValue + "'";
				conn.ExecuteQuery();

				TXT_WS_VOL.Text					= conn.GetFieldValue("CURRENT_VOLUME");
				TXT_WS_INC.Text					= conn.GetFieldValue("CURRENT_INCOME");

				if(TXT_WS_VOL.Text == "" || TXT_WS_VOL.Text == null)
				{
					TXT_WS_VOL.Text				= "0";
				}

				if(TXT_WS_INC.Text == "" || TXT_WS_INC.Text == null)
				{
					TXT_WS_INC.Text				= "0";
				}

				wallet_inc						= MyConnection.ConvertToFloat(TXT_WS_INC.Text);

				conn.QueryString = "SELECT YEAR(GETDATE())-1 AS TANGGAL";
				conn.ExecuteQuery();

				LBL_TXT_CUST_DATE.Text			= conn.GetFieldValue("TANGGAL").ToString();


				//Ambil data Realisasi Wallet Size Volume, Income, Share Last Year
				conn.QueryString = "SELECT CASE WHEN VOLUME IS NULL THEN '0' ELSE VOLUME END AS VOLUME, CASE WHEN INCOME IS NULL THEN '0' ELSE INCOME END AS INCOME FROM AP_DASHBOARD_DATA_UPLOAD WHERE CU_CIF = '" +
									DDL_COMPANY.SelectedValue + "' AND ID_AP_VARIABLE = '" + DDL_PRODUCT.SelectedValue + "' AND D_DATE LIKE '%" + LBL_TXT_CUST_DATE.Text + "%'";
				conn.ExecuteQuery();

				TXT_REAL_VOL.Text				= conn.GetFieldValue("VOLUME").ToString();
				TXT_REAL_INC.Text				= conn.GetFieldValue("INCOME").ToString().Replace("Consolidated","0");

				if(TXT_REAL_VOL.Text == "" || TXT_REAL_VOL.Text == null)
				{
					TXT_REAL_VOL.Text				= "0";
				}

				if(TXT_REAL_INC.Text == "" || TXT_REAL_INC.Text == null)
				{
					TXT_REAL_INC.Text				= "0";
				}

				real_inc						= MyConnection.ConvertToFloat(TXT_REAL_INC.Text);

				if(wallet_inc != 0)
				{
					result						= Convert.ToInt32(real_inc / wallet_inc);
				}
				else
				{
					result						= 0;
				}

				TXT_REAL_SHARE.Text				= real_inc.ToString();

				//Ambil data Average Balance
				/*conn.QueryString = "EXEC AP_AVERAGE_BALANCE_PRODUCT '" + DDL_COMPANY.SelectedValue + "','" + DDL_PRODUCT.SelectedValue + "'";
				conn.ExecuteQuery();

				TXT_AVG_BALANCE.Text			= conn.GetFieldValue("AVG_BALANCE");*/

				//Ambil data Spread
				/*conn.QueryString = "SELECT * FROM AP_VARIABLE WHERE ID_AP_VARIABLE = '"+ DDL_PRODUCT.SelectedValue +"' AND STATUS = '1'";
				conn.ExecuteQuery();

				TXT_SPREAD.Text					= conn.GetFieldValue("SPREAD_PERCENT");*/
			}
		}

		private void FillDDLType()
		{
			DDL_TYPE.Items.Clear();
			DDL_TYPE.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT FIELDID, FIELDTEXT FROM VW_AP_TYPE_WHOLESALE_ALLIANCE";
			conn.ExecuteQuery();
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLUnit()
		{
			DDL_UNIT_MEASURE.Items.Clear();
			DDL_UNIT_MEASURE.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_AP_OPPORTUNITY_UNIT_MEASUREMENT";
			conn.ExecuteQuery();

			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_UNIT_MEASURE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void ViewCompany()
		{
			DDL_COMPANY.Items.Clear();
			DDL_COMPANY.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT CIF_CUST, CUSTOMER_NAME FROM AP_COMPANY_INFO WHERE CIF_GROUP='" + TXT_CIF.Text + "'";
			conn.ExecuteQuery();
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_COMPANY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillGridWholesale()
		{
			conn.QueryString = "EXEC AP_OPPORTUNITY_TARGET_CONSOLIDATED '" + Request.QueryString["cif"] + "','" + 1 + "'";
			BindData(DGR_WHOLESALE.ID.ToString(), conn.QueryString, "1");
		}

		private void DGR_WHOLESALE_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_WHOLESALE.CurrentPageIndex = e.NewPageIndex;
			FillGridWholesale();
		}

		private void FillGridAlliance()
		{
			conn.QueryString = "EXEC AP_OPPORTUNITY_TARGET_CONSOLIDATED '" + Request.QueryString["cif"] + "','" + 2 + "'";
			BindData(DGR_ALLIANCE.ID.ToString(), conn.QueryString, "1");
		}

		private void DGR_ALLIANCE_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_ALLIANCE.CurrentPageIndex = e.NewPageIndex;
			FillGridAlliance();
		}

		private void BindData(string dataGridName, string strconn, string type)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();

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
				if(type == "1")
				{
					for (int i = 0; i < dg.Items.Count; i++)
					{
						dg.Items[i].Cells[9].Text = tools.MoneyFormat(dg.Items[i].Cells[9].Text);
						dg.Items[i].Cells[10].Text = tools.MoneyFormat(dg.Items[i].Cells[10].Text);
						dg.Items[i].Cells[11].Text = tools.MoneyFormat(dg.Items[i].Cells[11].Text);
						dg.Items[i].Cells[12].Text = tools.MoneyFormat(dg.Items[i].Cells[12].Text);
						dg.Items[i].Cells[14].Text = tools.MoneyFormat(dg.Items[i].Cells[14].Text);
						dg.Items[i].Cells[15].Text = tools.MoneyFormat(dg.Items[i].Cells[15].Text);
					}
				}
				else if(type == "2")
				{
					for (int i = 0; i < dg.Items.Count; i++)
					{
						dg.Items[i].Cells[10].Text = tools.MoneyFormat(dg.Items[i].Cells[10].Text);
						dg.Items[i].Cells[11].Text = tools.MoneyFormat(dg.Items[i].Cells[11].Text);
						dg.Items[i].Cells[12].Text = tools.MoneyFormat(dg.Items[i].Cells[12].Text);
						dg.Items[i].Cells[13].Text = tools.MoneyFormat(dg.Items[i].Cells[13].Text);
						dg.Items[i].Cells[15].Text = tools.MoneyFormat(dg.Items[i].Cells[15].Text);
						dg.Items[i].Cells[16].Text = tools.MoneyFormat(dg.Items[i].Cells[16].Text);
					}
				}

				conn.ClearData();
			}
		}

		protected void DDL_COMPANY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DDL_COMPANY.SelectedValue == "")
			{
				TR_COMPANY_HEADER.Visible	= false;
				TR_COMPANY_GRID.Visible		= false;
				TR_COMPANY_FIELD.Visible	= false;
				TR_COMPANY_BTN.Visible		= false;
				ClearData();
			}
			else
			{
				TR_COMPANY_HEADER.Visible	= true;
				TR_COMPANY_GRID.Visible		= true;
				TR_COMPANY_FIELD.Visible	= true;
				TR_COMPANY_BTN.Visible		= true;
				LBL_COMPANY_HEADER.Text		= DDL_COMPANY.SelectedItem.ToString();

				FillGridCompany();
				ClearData();
			}
		}

		private void FillGridCompany()
		{
			conn.QueryString = "SELECT * FROM AP_OPPORTUNITY_TARGET WHERE CIF='" + DDL_COMPANY.SelectedValue + "'";
			BindData(DGR_COMPANY.ID.ToString(), conn.QueryString, "2");
		}

		private void DGR_COMPANY_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_COMPANY.CurrentPageIndex = e.NewPageIndex;
			FillGridCompany();
		}

		private void DGR_COMPANY_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					conn.QueryString = "SELECT * FROM AP_OPPORTUNITY_TARGET WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "'";
					conn.ExecuteQuery();

					LBL_SEQ.Text					= e.Item.Cells[0].Text.Trim();
					DDL_CATEGORY.SelectedValue		= conn.GetFieldValue("CATEGORYID").ToString().Replace("&nbsp;","");
					DDL_PRODUCT.SelectedValue		= conn.GetFieldValue("PRODUCTID").ToString().Replace("&nbsp;","");
					TXT_OPP_DESC1.Text				= conn.GetFieldValue("OPPDESC1").ToString().Replace("&nbsp;","");
					//TXT_OPP_DESC2.Text			= conn.GetFieldValue("OPPDESC2").ToString().Replace("&nbsp;","");
					//TXT_OPP_DESC3.Text			= conn.GetFieldValue("OPPDESC3").ToString().Replace("&nbsp;","");
					TXT_ASSUMP_WALLET.Text			= conn.GetFieldValue("AS_WALLET").ToString().Replace("&nbsp;","");
					//TXT_ASSUMP_TARGET.Text		= conn.GetFieldValue("AS_TARGET").ToString().Replace("&nbsp;","");
					//TXT_ASSUMP_SPREAD.Text		= conn.GetFieldValue("AS_SPREAD").ToString().Replace("&nbsp;","");
					TXT_WS_VOL.Text					= conn.GetFieldValue("WS_VOL").ToString().Replace("&nbsp;","");
					TXT_WS_INC.Text					= conn.GetFieldValue("WS_INC").ToString().Replace("&nbsp;","");
					TXT_REAL_VOL.Text				= conn.GetFieldValue("REAL_VOL").ToString().Replace("&nbsp;","");
					TXT_REAL_INC.Text				= conn.GetFieldValue("REAL_INC").ToString().Replace("&nbsp;","");
					TXT_REAL_SHARE.Text				= conn.GetFieldValue("REAL_SHARE").ToString().Replace("&nbsp;","");
					//TXT_AVG_BALANCE.Text			= conn.GetFieldValue("AVG_BALANCE").ToString().Replace("&nbsp;","");
					//TXT_SPREAD.Text				= conn.GetFieldValue("SPREAD").ToString().Replace("&nbsp;","");
					DDL_TYPE.SelectedValue			= conn.GetFieldValue("TYPEID").ToString().Replace("&nbsp;","");
					DDL_UNIT_MEASURE.SelectedValue	= conn.GetFieldValue("UNIT_MEASUREID").ToString().Replace("&nbsp;","");
					TXT_PROPOSED_VOL.Text			= conn.GetFieldValue("PROPOSED_VOL").ToString().Replace("&nbsp;","");
					TXT_PROPOSED_INC.Text			= conn.GetFieldValue("PROPOSED_INC").ToString().Replace("&nbsp;","");
					TXT_PROPOSED_GROWTH.Text		= conn.GetFieldValue("PROPOSED_GROWTH").ToString().Replace("&nbsp;","");
					TXT_PROPOSED_SHARE.Text			= conn.GetFieldValue("PROPOSED_SHARE").ToString().Replace("&nbsp;","");
					break;

				case "delete":
					conn.QueryString = "DELETE AP_OPPORTUNITY_TARGET WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "'";
					conn.ExecuteQuery();

					FillGridCompany();
					break;
			}
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			try
			{
				/*conn.QueryString = "EXEC AP_OPPORTUNITY_TARGET_INSERT '" +
									LBL_SEQ.Text + "','" +
									DDL_COMPANY.SelectedValue + "','" +
									DDL_CATEGORY.SelectedValue + "','" +
									DDL_PRODUCT.SelectedValue + "','" +
									TXT_OPP_DESC1.Text + "','" +
									TXT_OPP_DESC2.Text + "','" +
									TXT_OPP_DESC3.Text + "','" +
									TXT_ASSUMP_WALLET.Text + "','" +
									TXT_ASSUMP_TARGET.Text + "','" +
									TXT_ASSUMP_SPREAD.Text + "','" +
									DDL_TYPE.SelectedValue + "','" +
									DDL_UNIT_MEASURE.SelectedValue + "','" +
									TXT_WS_VOL.Text.Replace(",",".") + "','" +
									TXT_WS_INC.Text.Replace(",",".") + "','" +
									TXT_AVG_BALANCE.Text.Replace(",",".") + "','" +
									TXT_SPREAD.Text.Replace(",",".") + "','" +
									TXT_PROPOSED_VOL.Text.Replace(",",".") + "','" +
									TXT_PROPOSED_INC.Text.Replace(",",".") + "'";*/

				conn.QueryString = "EXEC AP_OPPORTUNITY_TARGET_INSERT '" +
									LBL_SEQ.Text + "','" +
									DDL_COMPANY.SelectedValue + "','" +
									DDL_CATEGORY.SelectedValue + "','" +
									DDL_PRODUCT.SelectedValue + "','" +
									TXT_OPP_DESC1.Text + "','" +
									TXT_ASSUMP_WALLET.Text + "','" +
									DDL_TYPE.SelectedValue + "','" +
									DDL_UNIT_MEASURE.SelectedValue + "','" +
									TXT_WS_VOL.Text.Replace(",",".") + "','" +
									TXT_WS_INC.Text.Replace(",",".") + "','" +
									TXT_REAL_VOL.Text.Replace(",",".") + "','" +
									TXT_REAL_INC.Text.Replace(",",".") + "','" +
									TXT_REAL_SHARE.Text.Replace(",",".") + "','" +
									TXT_PROPOSED_VOL.Text.Replace(",",".") + "','" +
									TXT_PROPOSED_INC.Text.Replace(",",".") + "','" +
									TXT_PROPOSED_GROWTH.Text.Replace(",",".") + "','" +
									TXT_PROPOSED_SHARE.Text.Replace(",",".") + "'";
				conn.ExecuteQuery();
			}

			catch(Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
			
			ClearData();
			FillGridCompany();
			FillGridWholesale();
			FillGridAlliance();
		}

		private void ClearData()
		{
			LBL_SEQ.Text					= "";
			DDL_CATEGORY.SelectedValue		= "";
			DDL_PRODUCT.SelectedValue		= "";
			TXT_OPP_DESC1.Text				= "";
			//TXT_OPP_DESC2.Text			= "";
			//TXT_OPP_DESC3.Text			= "";
			TXT_ASSUMP_WALLET.Text			= "";
			//TXT_ASSUMP_TARGET.Text		= "";
			//TXT_ASSUMP_SPREAD.Text		= "";
			TXT_WS_VOL.Text					= "";
			TXT_WS_INC.Text					= "";
			TXT_REAL_VOL.Text				= "";
			TXT_REAL_INC.Text				= "";
			TXT_REAL_SHARE.Text				= "";
			DDL_TYPE.SelectedValue			= "";
			DDL_UNIT_MEASURE.SelectedValue	= "";
			//TXT_AVG_BALANCE.Text			= "";
			//TXT_SPREAD.Text				= "";
			TXT_PROPOSED_VOL.Text			= "";
			TXT_PROPOSED_INC.Text			= "";
			TXT_PROPOSED_GROWTH.Text		= "";
			TXT_PROPOSED_SHARE.Text			= "";
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../ActionPlan/CustomerList.aspx?mc=" + Request.QueryString["mc"]);
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
			this.DGR_COMPANY.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_COMPANY_ItemCommand);
			this.DGR_COMPANY.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_COMPANY_PageIndexChanged);

		}
		#endregion	
	}
}
