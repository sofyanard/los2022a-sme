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

namespace SME.AccountPlanning.InfoSetup
{
	/// <summary>
	/// Summary description for ValueChainInfo.
	/// </summary>
	public partial class ValueChainInfo : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				FillDDLGroup();
				FillDDLUnit3();
				FillDDLInc();
				FillDDLStatus();
				FillDDLCategory();

				DDL_ANCHOR_MONTH.Items.Add(new ListItem("--Select--", ""));
				
				for (int i = 1; i <= 12; i++)
				{
					DDL_ANCHOR_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				ViewData();

			}
			FillGridVChain();
		}

		private void FillDDLGroup()
		{
			DDL_ANCHOR_GROUP_NAME.Items.Clear();
			DDL_VC_GROUP_NAME.Items.Clear();

			DDL_ANCHOR_GROUP_NAME.Items.Add(new ListItem("--Select--", ""));
			DDL_VC_GROUP_NAME.Items.Add(new ListItem("--Select--", ""));
			
			conn.QueryString = "SELECT BUSSUNITID, BUSSUNITDESC FROM RFBUSINESSUNIT WHERE ACTIVE='1'";
			conn.ExecuteQuery();
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_ANCHOR_GROUP_NAME.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				DDL_VC_GROUP_NAME.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		protected void DDL_ANCHOR_GROUP_NAME_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillDDLUnit1();		
		}

		protected void DDL_VC_GROUP_NAME_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillDDLUnit3();
		}

		private void FillDDLUnit1()
		{
			DDL_ANCHOR_UNIT_NAME.Items.Clear();
			DDL_ANCHOR_UNIT_NAME.Items.Add(new ListItem("--Select--", ""));
			
			if(DDL_ANCHOR_GROUP_NAME.SelectedValue == "")
			{
				conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH WHERE ACTIVE='1'";
				conn.ExecuteQuery();
			}
			else
			{
				conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH WHERE BUSSUNITID = '" + DDL_ANCHOR_GROUP_NAME.SelectedValue + "' AND ACTIVE='1'";
				conn.ExecuteQuery();
			}
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_ANCHOR_UNIT_NAME.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLUnit3()
		{
			DDL_VC_UNIT_NAME.Items.Clear();
			DDL_VC_UNIT_NAME.Items.Add(new ListItem("--Select--", ""));
			
			if(DDL_VC_GROUP_NAME.SelectedValue == "")
			{
				conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH WHERE ACTIVE='1'";
				conn.ExecuteQuery();
			}
			else
			{
				conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH WHERE BUSSUNITID = '" + DDL_VC_GROUP_NAME.SelectedValue + "' AND ACTIVE='1'";
				conn.ExecuteQuery();
			}
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_VC_UNIT_NAME.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLInc()
		{
			DDL_ANCHOR_INDUSTRY.Items.Clear();
			DDL_VC_INDUSTRY.Items.Clear();
			DDL_ANCHOR_INDUSTRY.Items.Add(new ListItem("--Select--", ""));
			DDL_VC_INDUSTRY.Items.Add(new ListItem("--Select--", ""));
			
			conn.QueryString = "SELECT CODE, CODE_DESCRIPTION FROM AP_RF_INDUSTRY_BCG WHERE ACTIVE = '1'";
			conn.ExecuteQuery();
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_ANCHOR_INDUSTRY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				DDL_VC_INDUSTRY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLStatus()
		{
			DDL_VC_RELATION.Items.Clear();
			DDL_VC_RELATION.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT CODE, CODE_DESC FROM AP_RF_STATUS_RELATION_BCG WHERE ACTIVE = '1'";
			conn.ExecuteQuery();
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_VC_RELATION.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLCategory()
		{
			DDL_VC_CATEGORY.Items.Clear();
			DDL_VC_CATEGORY.Items.Add(new ListItem("--Select--", ""));
						
			conn.QueryString = "SELECT CATEGORY_ID, CATEGORY_DESC FROM AP_RF_CATEGORY_VC WHERE ACTIVE='1'";
			conn.ExecuteQuery();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_VC_CATEGORY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillGridVChain()
		{
			conn.QueryString = "SELECT * FROM VW_AP_ANCHOR_CHAIN_INFO WHERE CIF_GROUP ='" + TXT_ANCHOR_CIF.Text + "'";
			BindData(DGR_VALUE_CHAIN.ID.ToString(), conn.QueryString);
		}

		private void BindData(string dataGridName, string strconn)
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

				conn.ClearData();
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ChainCustomerList.aspx?mc=" + Request.QueryString["mc"]);
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
			this.DGR_VALUE_CHAIN.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_VALUE_CHAIN_ItemCommand);
			this.DGR_VALUE_CHAIN.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_VALUE_CHAIN_PageIndexChanged);

		}
		#endregion

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM VW_AP_CUSTOMER_LIST_VC WHERE CIF# ='" + Request.QueryString["cif"] + "'";
			conn.ExecuteQuery();

			//LBL_SEQ.Text						= conn.GetFieldValue("SEQ");
			TXT_ANCHOR_CIF.Text					= conn.GetFieldValue("CIF#");
			TXT_ANCHOR_NAME.Text				= conn.GetFieldValue("CUSTOMER_GROUP");
			TXT_ANCHOR_ADDRESS.Text				= conn.GetFieldValue("CUST_ADDRESS");
			TXT_ANCHOR_CITY.Text				= conn.GetFieldValue("CUST_CITY");
			DDL_ANCHOR_INDUSTRY.SelectedValue	= conn.GetFieldValue("INDUSTRY_NAME");
			TXT_ANCHOR_DAY.Text					= tools.FormatDate_Day(conn.GetFieldValue("CUST_DATE").ToString());
			DDL_ANCHOR_MONTH.SelectedValue		= tools.FormatDate_Month(conn.GetFieldValue("CUST_DATE").ToString());
			TXT_ANCHOR_YEAR.Text				= tools.FormatDate_Year(conn.GetFieldValue("CUST_DATE").ToString());
			TXT_ANCHOR_RM.Text					= conn.GetFieldValue("RM_NAME");
			LBL_TEMP.Text						= conn.GetFieldValue("GROUP_NAME");
			DDL_ANCHOR_UNIT_NAME.SelectedValue	= conn.GetFieldValue("BUC").ToString();
			TXT_ANCHOR_RELATIONSHIP.Text		= conn.GetFieldValue("CUST_LENGTH");


			conn.QueryString = "SELECT BUSSUNITID, BUSSUNITDESC FROM RFBUSINESSUNIT WHERE BUSSUNITDESC ='" + LBL_TEMP.Text + "' AND ACTIVE='1'";
			conn.ExecuteQuery();

			DDL_ANCHOR_GROUP_NAME.SelectedValue	= conn.GetFieldValue("BUSSUNITID");

		}

		protected void BTN_SAVE_VC_Click(object sender, System.EventArgs e)
		{
			if(TXT_ANCHOR_CIF.Text != "")
			{
				if(TXT_VC_CIF.Text != "")
				{
					try
					{
						conn.QueryString = "EXEC AP_VALUE_CHAIN_INFO_SETUP '" +
							LBL_SEQ_VC.Text + "','" +
							TXT_ANCHOR_CIF.Text + "','" +
							TXT_VC_CIF.Text + "','" +
							TXT_VC_NAME.Text + "','" +
							TXT_VC_ADDRESS.Text + "','" +
							TXT_VC_CITY.Text + "','" +
							DDL_VC_INDUSTRY.SelectedValue + "','" +
							DDL_VC_RELATION.SelectedValue + "','" +
							DDL_VC_CATEGORY.SelectedValue + "','" +
							DDL_VC_GROUP_NAME.SelectedValue + "','" +
							DDL_VC_UNIT_NAME.SelectedValue + "','" +
							TXT_VC_LEN_RELATION.Text + "','" +
							RDO_PRIORITY_VC.SelectedValue + "','" +
							RDO_MEET_VC.SelectedValue + "','" +
							TXT_VC_CONTACT.Text + "','" +
							TXT_VC_AVG_TURN.Text + "'";

						conn.ExecuteQuery();
					}
					catch (Exception ex)
					{
						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						return;
					}
				}
				else
				{
					GlobalTools.popMessage(this, "Check Field Mandatory!");
				}
			}
			else
			{
				GlobalTools.popMessage(this, "Check CIF Anchor!");
				return;
			}
			FillGridVChain();
			ClearData();
		}

		private void DGR_VALUE_CHAIN_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_VALUE_CHAIN.CurrentPageIndex = e.NewPageIndex;
			FillGridVChain();
		}

		private void DGR_VALUE_CHAIN_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					conn.QueryString = "SELECT * FROM AP_VALUE_CHAIN_INFO WHERE SEQ = '" + e.Item.Cells[0].Text.Trim() + "'";
					conn.ExecuteQuery();

					LBL_SEQ_VC.Text					= e.Item.Cells[0].Text.Trim();
					TXT_VC_CIF.Text					= conn.GetFieldValue("CIF_CUST").ToString().Replace("&nbsp;","");
					TXT_VC_NAME.Text				= conn.GetFieldValue("CUSTOMER_NAME").ToString().Replace("&nbsp;","");
					TXT_VC_ADDRESS.Text				= conn.GetFieldValue("CUST_ADDRESS").ToString().Replace("&nbsp;","");
					TXT_VC_CITY.Text				= conn.GetFieldValue("CUST_CITY").ToString().Replace("&nbsp;","");
					DDL_VC_INDUSTRY.SelectedValue	= conn.GetFieldValue("INDUSTRY_NAME").ToString();
					DDL_VC_RELATION.SelectedValue	= conn.GetFieldValue("RELATION_STATUS").ToString();
					DDL_VC_CATEGORY.SelectedValue	= conn.GetFieldValue("CATEGORY_ID").ToString();
					DDL_VC_GROUP_NAME.SelectedValue	= conn.GetFieldValue("GROUP_ID").ToString();
					DDL_VC_UNIT_NAME.SelectedValue	= conn.GetFieldValue("BUC").ToString();
					TXT_VC_LEN_RELATION.Text		= conn.GetFieldValue("CUST_LENGTH").ToString().Replace("&nbsp;","");
					TXT_VC_AVG_TURN.Text			= conn.GetFieldValue("AVG_TURN").ToString().Replace("&nbsp;","");

					if(conn.GetFieldValue("PRIORITY") != "" && conn.GetFieldValue("PRIORITY") != null)
					{
						RDO_PRIORITY_VC.SelectedValue	= conn.GetFieldValue("PRIORITY");
					}
					if(conn.GetFieldValue("MEET") != "" && conn.GetFieldValue("MEET") != null)
					{
						RDO_MEET_VC.SelectedValue	= conn.GetFieldValue("PRIORITY");
					}
					TXT_VC_CONTACT.Text			= conn.GetFieldValue("KEY_CONTACT").ToString().Replace("&nbsp;","");
					break;

				case "delete":
					conn.QueryString="DELETE AP_VALUE_CHAIN_INFO WHERE SEQ = '" + e.Item.Cells[0].Text.Trim() + "'";
					conn.ExecuteQuery();

					break;
			}
		}

		private void ClearData()
		{
			//VALUE CHAIN INFO
			LBL_SEQ_VC.Text					= "";
			TXT_VC_CIF.Text					= "";
			TXT_VC_NAME.Text				= "";
			TXT_VC_ADDRESS.Text				= "";
			TXT_VC_CITY.Text				= "";
			DDL_VC_INDUSTRY.SelectedValue	= "";
			DDL_VC_RELATION.SelectedValue	= "";
			DDL_VC_CATEGORY.SelectedValue	= "";
			DDL_VC_GROUP_NAME.SelectedValue	= "";
			DDL_VC_UNIT_NAME.SelectedValue	= "";
			TXT_VC_LEN_RELATION.Text		= "";
			RDO_PRIORITY_VC.SelectedValue	= null;
			RDO_MEET_VC.SelectedValue		= null;
			TXT_VC_CONTACT.Text				= "";
			TXT_VC_AVG_TURN.Text			= "";
		}

	}
}