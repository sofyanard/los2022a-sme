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

namespace SME.AccountPlanning.ActionPlan
{
	/// <summary>
	/// Summary description for AnchorInfo.
	/// </summary>
	public partial class AnchorInfo : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				FillDDLGroup();
				FillDDLUnit1();
				FillDDLUnit2();
				//FillDDLUnit3();
				FillDDLInc();
				FillDDLStatus();
				FillDDLProduct();
				//FillDDLCategory();
				FillDDLRole();

				DDL_ANCHOR_MONTH.Items.Add(new ListItem("--Select--", ""));
				
				for (int i = 1; i <= 12; i++)
				{
					DDL_ANCHOR_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
	
				if(Request.QueryString["exist"] == "1")
				{
					BTN_UPDATE_ANCHOR.Visible = true;
					ViewData();
				}
				else
				{
					BTN_SAVE_ANCHOR.Visible = true;
				}
			}
			FillGridSub();
			//FillGridVChain();
			FillGridAnchor();
		}

		private void FillDDLGroup()
		{
			DDL_ANCHOR_GROUP_NAME.Items.Clear();
			DDL_SUB_GROUP_NAME.Items.Clear();
			//DDL_VC_GROUP_NAME.Items.Clear();
			DDL_TEAM_WORKING_UNIT.Items.Clear();

			DDL_ANCHOR_GROUP_NAME.Items.Add(new ListItem("--Select--", ""));
			DDL_SUB_GROUP_NAME.Items.Add(new ListItem("--Select--", ""));
			//DDL_VC_GROUP_NAME.Items.Add(new ListItem("--Select--", ""));
			DDL_TEAM_WORKING_UNIT.Items.Add(new ListItem("--Select--", ""));
			
			conn.QueryString = "SELECT BUSSUNITID, BUSSUNITDESC FROM RFBUSINESSUNIT WHERE ACTIVE='1'";
			conn.ExecuteQuery();
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_ANCHOR_GROUP_NAME.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				DDL_SUB_GROUP_NAME.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				//DDL_VC_GROUP_NAME.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				DDL_TEAM_WORKING_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		protected void DDL_ANCHOR_GROUP_NAME_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillDDLUnit1();
		}

		protected void DDL_SUB_GROUP_NAME_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillDDLUnit2();
		}
/*
		private void DDL_VC_GROUP_NAME_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillDDLUnit3();
		}
*/
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

		private void FillDDLUnit2()
		{
			DDL_SUB_UNIT_NAME.Items.Clear();
			DDL_SUB_UNIT_NAME.Items.Add(new ListItem("--Select--", ""));
			
			if(DDL_SUB_GROUP_NAME.SelectedValue == "")
			{
				conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH WHERE ACTIVE='1'";
				conn.ExecuteQuery();
			}
			else
			{
				conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH WHERE BUSSUNITID = '" + DDL_SUB_GROUP_NAME.SelectedValue + "' AND ACTIVE='1'";
				conn.ExecuteQuery();
			}
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_SUB_UNIT_NAME.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}
/*
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
*/
		private void FillDDLInc()
		{
			DDL_ANCHOR_INDUSTRY.Items.Clear();
			DDL_SUB_INDUSTRY.Items.Clear();
			//DDL_VC_INDUSTRY.Items.Clear();
			DDL_ANCHOR_INDUSTRY.Items.Add(new ListItem("--Select--", ""));
			DDL_SUB_INDUSTRY.Items.Add(new ListItem("--Select--", ""));
			//DDL_VC_INDUSTRY.Items.Add(new ListItem("--Select--", ""));
			
			conn.QueryString = "SELECT CODE, CODE_DESCRIPTION FROM AP_RF_INDUSTRY_BCG WHERE ACTIVE = '1'";
			conn.ExecuteQuery();
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_ANCHOR_INDUSTRY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				DDL_SUB_INDUSTRY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				//DDL_VC_INDUSTRY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLStatus()
		{
			DDL_SUB_RELATION.Items.Clear();
			//DDL_VC_RELATION.Items.Clear();
			DDL_SUB_RELATION.Items.Add(new ListItem("--Select--", ""));
			//DDL_VC_RELATION.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT CODE, CODE_DESC FROM AP_RF_STATUS_RELATION_BCG WHERE ACTIVE = '1'";
			conn.ExecuteQuery();
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_SUB_RELATION.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				//DDL_VC_RELATION.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLProduct()
		{
			DDL_TEAM_PRODUCT.Items.Clear();
			DDL_TEAM_PRODUCT.Items.Add(new ListItem("--Select--", ""));
						
			conn.QueryString = "SELECT ID_AP_VARIABLE, [DESCRIPTION] FROM AP_VARIABLE WHERE STATUS='1'";
			conn.ExecuteQuery();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_TEAM_PRODUCT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}
/*
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
*/
		private void FillDDLRole()
		{
			DDL_TEAM_ROLE.Items.Clear();
			DDL_TEAM_ROLE.Items.Add(new ListItem("--Select--", ""));
						
			conn.QueryString = "SELECT CODE, CODE_DESC FROM AP_RF_ROLE WHERE ACTIVE = '1'";
			conn.ExecuteQuery();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_TEAM_ROLE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillGridSub()
		{
			conn.QueryString = "SELECT * FROM VW_AP_ANCHOR_SUB_INFO WHERE CIF_GROUP ='" + TXT_ANCHOR_CIF.Text + "'";
			BindData(DGR_SUBSIDIARY.ID.ToString(), conn.QueryString);
		}
/*
		private void FillGridVChain()
		{
			conn.QueryString = "SELECT * FROM VW_AP_ANCHOR_CHAIN_INFO WHERE CIF_GROUP ='" + TXT_ANCHOR_CIF.Text + "'";
			BindData(DGR_VALUE_CHAIN.ID.ToString(), conn.QueryString);
		}
*/
		private void FillGridAnchor()
		{
			conn.QueryString = "SELECT * FROM VW_AP_ANCHOR_CLIENT_TEAM WHERE CIF ='" + TXT_ANCHOR_CIF.Text + "'";
			BindData(DGR_ANCHOR_TEAM.ID.ToString(), conn.QueryString);
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
			Response.Redirect("CustomerList.aspx?mc=" + Request.QueryString["mc"]);
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
			this.DGR_SUBSIDIARY.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_SUBSIDIARY_ItemCommand);
			this.DGR_SUBSIDIARY.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_SUBSIDIARY_PageIndexChanged);
			this.DGR_ANCHOR_TEAM.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_ANCHOR_TEAM_ItemCommand);
			this.DGR_ANCHOR_TEAM.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_ANCHOR_TEAM_PageIndexChanged);

		}
		#endregion

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM AP_ANCHOR_INFO WHERE CIF# ='" + Request.QueryString["cif"] + "'";
			conn.ExecuteQuery();

			LBL_SEQ.Text						= conn.GetFieldValue("SEQ");
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

		protected void BTN_SAVE_ANCHOR_Click(object sender, System.EventArgs e)
		{
			if (TXT_ANCHOR_DAY.Text != "" && DDL_ANCHOR_MONTH.SelectedValue != "" && TXT_ANCHOR_YEAR.Text != "") 
			{
				if (!GlobalTools.isDateValid(TXT_ANCHOR_DAY.Text, DDL_ANCHOR_MONTH.SelectedValue, TXT_ANCHOR_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Action Date tidak valid!");
					return;
				}
			}
			
			if(TXT_ANCHOR_CIF.Text != "")
			{
				try
				{
					conn.QueryString = "EXEC AP_ANCHOR_INFO_SETUP '" +
						LBL_SEQ.Text + "','" +
						TXT_ANCHOR_CIF.Text + "','" +
						TXT_ANCHOR_NAME.Text + "','" +
						TXT_ANCHOR_ADDRESS.Text + "','" +
						TXT_ANCHOR_CITY.Text + "','" +
						DDL_ANCHOR_INDUSTRY.SelectedValue + "'," +
						tools.ConvertDate(TXT_ANCHOR_DAY.Text, DDL_ANCHOR_MONTH.SelectedValue, TXT_ANCHOR_YEAR.Text) + ",'" +
						TXT_ANCHOR_RM.Text + "','" +
						DDL_ANCHOR_GROUP_NAME.SelectedValue + "','" +
						DDL_ANCHOR_UNIT_NAME.SelectedValue + "','" +
						TXT_ANCHOR_RELATIONSHIP.Text + "'";
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
				return;
			}

			ViewData();
			BTN_SAVE_ANCHOR.Visible = false;
			BTN_UPDATE_ANCHOR.Visible = true;
		}

		protected void BTN_UPDATE_ANCHOR_Click(object sender, System.EventArgs e)
		{
			if (TXT_ANCHOR_DAY.Text != "" && DDL_ANCHOR_MONTH.SelectedValue != "" && TXT_ANCHOR_YEAR.Text != "") 
			{
				if (!GlobalTools.isDateValid(TXT_ANCHOR_DAY.Text, DDL_ANCHOR_MONTH.SelectedValue, TXT_ANCHOR_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Action Date tidak valid!");
					return;
				}
			}

			if(TXT_ANCHOR_CIF.Text != "")
			{
				try
				{
					conn.QueryString = "EXEC AP_ANCHOR_INFO_SETUP '" +
						LBL_SEQ.Text + "','" +
						TXT_ANCHOR_CIF.Text + "','" +
						TXT_ANCHOR_NAME.Text + "','" +
						TXT_ANCHOR_ADDRESS.Text + "','" +
						TXT_ANCHOR_CITY.Text + "','" +
						DDL_ANCHOR_INDUSTRY.SelectedValue + "'," +
						tools.ConvertDate(TXT_ANCHOR_DAY.Text, DDL_ANCHOR_MONTH.SelectedValue, TXT_ANCHOR_YEAR.Text) + ",'" +
						TXT_ANCHOR_RM.Text + "','" +
						DDL_ANCHOR_GROUP_NAME.SelectedValue + "','" +
						DDL_ANCHOR_UNIT_NAME.SelectedValue + "','" +
						TXT_ANCHOR_RELATIONSHIP.Text + "'";
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
				return;
			}

			ViewData();
		}

		protected void BTN_SAVE_SUB_Click(object sender, System.EventArgs e)
		{
			if(TXT_ANCHOR_CIF.Text != "")
			{
				if(TXT_SUB_CIF.Text != "")
				{
					try
					{
						conn.QueryString = "EXEC AP_SUBSIDIARY_INFO_SETUP '" +
							LBL_SEQ_SUB.Text + "','" +
							TXT_ANCHOR_CIF.Text + "','" +
							TXT_SUB_CIF.Text + "','" +
							TXT_SUB_NAME.Text + "','" +
							TXT_SUB_ADDRESS.Text + "','" +
							TXT_SUB_CITY.Text + "','" +
							DDL_SUB_INDUSTRY.SelectedValue + "','" +
							DDL_SUB_RELATION.SelectedValue + "','" +
							DDL_SUB_GROUP_NAME.SelectedValue + "','" +
							DDL_SUB_UNIT_NAME.SelectedValue + "','" +
							TXT_SUB_LEN_RELATION.Text + "','" +
							RDO_SUB_PRIORITY.SelectedValue + "','" +
							RDO_SUB_MEET.SelectedValue + "','" +
							TXT_SUB_CONTACT.Text + "','" +
							TXT_NUMBER_EMPLOYEE.Text + "'";
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
			FillGridSub();
			ClearData();
		}

		private void DGR_SUBSIDIARY_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_SUBSIDIARY.CurrentPageIndex = e.NewPageIndex;
			FillGridSub();
		}

		private void DGR_SUBSIDIARY_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					conn.QueryString = "SELECT * FROM AP_COMPANY_INFO WHERE SEQ = '" + e.Item.Cells[0].Text.Trim() + "'";
					conn.ExecuteQuery();

					LBL_SEQ_SUB.Text				= e.Item.Cells[0].Text.Trim();
					TXT_SUB_CIF.Text				= conn.GetFieldValue("CIF_CUST").ToString().Replace("&nbsp;","");
					TXT_SUB_NAME.Text				= conn.GetFieldValue("CUSTOMER_NAME").ToString().Replace("&nbsp;","");
					TXT_SUB_ADDRESS.Text			= conn.GetFieldValue("CUST_ADDRESS").ToString().Replace("&nbsp;","");
					TXT_SUB_CITY.Text				= conn.GetFieldValue("CUST_CITY").ToString().Replace("&nbsp;","");
					DDL_SUB_INDUSTRY.SelectedValue	= conn.GetFieldValue("INDUSTRY_NAME").ToString();
					DDL_SUB_RELATION.SelectedValue	= conn.GetFieldValue("RELATION_STATUS").ToString();
					DDL_SUB_GROUP_NAME.SelectedValue= conn.GetFieldValue("GROUP_ID").ToString();
					DDL_SUB_UNIT_NAME.SelectedValue	= conn.GetFieldValue("BUC").ToString();
					TXT_SUB_LEN_RELATION.Text		= conn.GetFieldValue("CUST_LENGTH").ToString().Replace("&nbsp;","");
					if(conn.GetFieldValue("PRIORITY") != "" && conn.GetFieldValue("PRIORITY") != null)
					{
						RDO_SUB_PRIORITY.SelectedValue	= conn.GetFieldValue("PRIORITY");
					}
					if(conn.GetFieldValue("MEET") != "" && conn.GetFieldValue("MEET") != null)
					{
						RDO_SUB_MEET.SelectedValue	= conn.GetFieldValue("PRIORITY");
					}
					TXT_SUB_CONTACT.Text			= conn.GetFieldValue("KEY_CONTACT").ToString().Replace("&nbsp;","");
					TXT_NUMBER_EMPLOYEE.Text		= conn.GetFieldValue("NO_EMPLOYEE");
					break;

				case "delete":
					conn.QueryString="DELETE AP_COMPANY_INFO WHERE SEQ = '" + e.Item.Cells[0].Text.Trim() + "'";
					conn.ExecuteQuery();

					FillGridSub();
					break;
			}
		}
/*
		private void BTN_SAVE_VC_Click(object sender, System.EventArgs e)
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

					FillGridSub();
					break;
			}
		}
*/
		protected void BTN_SAVE_ANCHOR_TEAM_Click(object sender, System.EventArgs e)
		{
			if(TXT_ANCHOR_CIF.Text != "")
			{
				try
				{
					conn.QueryString = "EXEC AP_ANCHOR_CLIENT_TEAM_INSERT '" +
										LBL_TEAMID.Text + "','" +
										TXT_ANCHOR_CIF.Text + "','" +
										DDL_TEAM_ROLE.SelectedValue + "','" +
										TXT_TEAM_NAME.Text + "','" +
										RDO_TEAM_SIGNED.SelectedValue + "','" +
										DDL_TEAM_WORKING_UNIT.SelectedValue + "','" +
										TXT_TEAM_PHONE.Text + "','" +
										DDL_TEAM_PRODUCT.SelectedValue + "','" +
										TXT_TEAM_REMARK.Text + "'";
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
				GlobalTools.popMessage(this, "Check CIF Anchor!");
				return;
			}
			FillGridAnchor();
			ClearData();
		}

		private void DGR_ANCHOR_TEAM_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_ANCHOR_TEAM.CurrentPageIndex = e.NewPageIndex;
			FillGridAnchor();
		}

		private void DGR_ANCHOR_TEAM_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					conn.QueryString = "SELECT *, CASE SIGNED_OFF_AP WHEN '1' THEN 'Yes' WHEN '0' THEN 'Not Yet' END AS SIGNED_OFF FROM AP_ANCHOR_CLIENT_TEAM WHERE SEQ = '" + e.Item.Cells[0].Text.Trim() + "'";
					conn.ExecuteQuery();

					LBL_TEAMID.Text						= e.Item.Cells[0].Text.Trim();
					DDL_TEAM_ROLE.SelectedValue			= conn.GetFieldValue("ROLE_ID").ToString().Replace("&nbsp;","");
					TXT_TEAM_NAME.Text					= conn.GetFieldValue("TEAM_NAME").ToString().Replace("&nbsp;","");
					DDL_TEAM_WORKING_UNIT.SelectedValue	= conn.GetFieldValue("GROUP_CODE").ToString();
					TXT_TEAM_PHONE.Text					= conn.GetFieldValue("PHONE").ToString().Replace("&nbsp;","");
					DDL_TEAM_PRODUCT.SelectedValue		= conn.GetFieldValue("PRODUCTID").ToString();
					TXT_TEAM_REMARK.Text				= conn.GetFieldValue("REMARK").ToString().Replace("&nbsp;","");

					if(conn.GetFieldValue("SIGNED_OFF_AP") != "" && conn.GetFieldValue("SIGNED_OFF_AP") != null)
					{
						RDO_TEAM_SIGNED.SelectedValue	= conn.GetFieldValue("SIGNED_OFF_AP");
					}
					break;

				case "delete":
					conn.QueryString="DELETE AP_ANCHOR_CLIENT_TEAM WHERE SEQ = '" + e.Item.Cells[0].Text.Trim() + "'";
					conn.ExecuteQuery();

					FillGridAnchor();
					break;
			}
		}

		private void ClearData()
		{
			//SUBSIDIARY_INFO
			LBL_SEQ_SUB.Text				= "";
			TXT_SUB_CIF.Text				= "";
			TXT_SUB_NAME.Text				= "";
			TXT_SUB_ADDRESS.Text			= "";
			TXT_SUB_CITY.Text				= "";
			DDL_SUB_INDUSTRY.SelectedValue	= "";
			DDL_SUB_RELATION.SelectedValue	= "";
			DDL_SUB_GROUP_NAME.SelectedValue= "";
			DDL_SUB_UNIT_NAME.SelectedValue	= "";
			TXT_SUB_LEN_RELATION.Text		= "";
			RDO_SUB_PRIORITY.SelectedValue	= null;
			RDO_SUB_MEET.SelectedValue		= null;
			TXT_SUB_CONTACT.Text			= "";
			TXT_NUMBER_EMPLOYEE.Text		= "";

			//VALUE CHAIN INFO
/*			LBL_SEQ_VC.Text					= "";
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
*/
			//ANCHOR CLIENT TEAM
			DDL_TEAM_ROLE.SelectedValue		= "";
			TXT_TEAM_NAME.Text				= "";
			RDO_TEAM_SIGNED.SelectedValue	= null;
			DDL_TEAM_WORKING_UNIT.SelectedValue	= "";
			TXT_TEAM_PHONE.Text				= "";
			DDL_TEAM_PRODUCT.SelectedValue	= "";
			TXT_TEAM_REMARK.Text			= "";
		}
	}
}
