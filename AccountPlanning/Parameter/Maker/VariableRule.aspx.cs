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
using System.Configuration;

namespace SME.AccountPlanning.Parameter.Maker
{
	/// <summary>
	/// Summary description for VariableRule.
	/// </summary>
	public partial class VariableRule : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				TR_EDIT_PARAMETER.Visible	= false;
				TR_NEW_PARAMETER.Visible	= false;
				TR_ATTRIBUTE_RANGE.Visible = false;
				TR_ATTRIBUTE_NONRANGE.Visible = false;

				TR_VARIABLE_TEMP.Visible	= false;
				TR_ATTRANGE_TEMP.Visible = false;
				TR_ATTNONRANGE_TEMP.Visible = false;
			}
			
			conn.QueryString = "EXEC AP_BINDVARIABLE";
			conn.ExecuteQuery();

			BindData();
			BindData("DatGridVariableReq","EXEC AP_BINDVARIABLETEMP");
			BindData("DatGridVariableRangeReq","EXEC AP_BINDVARIABLERANGETEMP");
			BindData("DatGridVariableNonRangeReq","EXEC AP_BINDVARIABLENONRANGETEMP");
		}

		private void BindData()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrdVar.DataSource = dt;				
			DatGrdVar.DataBind();
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
			this.DatGrdVar.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrdVar_ItemCommand);
			this.DatGrdVar.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrdVar_PageIndexChanged);
			this.DatGridVariableRange.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGridVariableRange_ItemCommand);
			this.DatGridVariableRange.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGridVariableRange_PageIndexChanged);
			this.DatGridVariableNonRange.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGridVariableNonRange_ItemCommand);
			this.DatGridVariableNonRange.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGridVariableNonRange_PageIndexChanged);
			this.DatGridVariableReq.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGridVariableReq_ItemCommand);
			this.DatGridVariableReq.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGridVariableReq_PageIndexChanged);
			this.DatGridVariableRangeReq.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGridVariableRangeReq_ItemCommand);
			this.DatGridVariableRangeReq.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGridVariableRangeReq_PageIndexChanged);
			this.DatGridVariableNonRangeReq.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGridVariableNonRangeReq_ItemCommand);
			this.DatGridVariableNonRangeReq.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGridVariableNonRangeReq_PageIndexChanged);

		}
		#endregion

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			if(TXT_ID_PARAM.Text.ToString() == "" && TXT_VAR_NAME.Text.ToString() == "")
			{
				conn.QueryString = "EXEC AP_BINDVARIABLE ";
			}
			else if(TXT_ID_PARAM.Text.ToString() == "" && TXT_VAR_NAME.Text.ToString() != "")
			{
				conn.QueryString = "EXEC AP_BINDVARIABLE NULL,'" + TXT_VAR_NAME.Text.ToString() + "'";
			}
			else if(TXT_ID_PARAM.Text.ToString() != "" && TXT_VAR_NAME.Text.ToString() == "")
			{
				conn.QueryString = "EXEC AP_BINDVARIABLE '" + TXT_ID_PARAM.Text.ToString() + "'";
			}
			else if(TXT_ID_PARAM.Text.ToString() != "" && TXT_VAR_NAME.Text.ToString() != "")
			{
				conn.QueryString = "EXEC AP_BINDVARIABLE '" + TXT_ID_PARAM.Text.ToString() + "','" + TXT_VAR_NAME.Text.ToString() + "'";
			}
			conn.ExecuteQuery();
			BindData();
		}
		
		protected void BTN_NEW_Click(object sender, System.EventArgs e)
		{
			TR_EDIT_PARAMETER.Visible = false;
			TR_NEW_PARAMETER.Visible = true;
			TR_ATTRIBUTE_RANGE.Visible = false;
			TR_ATTRIBUTE_NONRANGE.Visible = false;
		}

		protected void BTN_NEW_INSERT_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC AP_INSERT_RFVARIABLE_TEMP '" + 
				TXT_NEW_ID.Text.ToString() + "','" +
				TXT_NEW_DESC.Text.ToString() + "'," +
				RDO_NEW_TYPE.SelectedValue.ToString() + "," +
				RDO_NEW_STATUS.SelectedValue.ToString() + ",'" +
				TXT_NEW_QUERY.Text.ToString() + "','" +
				TXT_NEW_FIELD.Text.ToString() + "','" +
				"1','-1'";
			conn.ExecuteQuery();

			Tools.popMessage(this,"Requesting Approval...");

			conn.QueryString = "EXEC AP_BINDVARIABLE";
			conn.ExecuteQuery();

			BindData("DatGridVariableReq","EXEC AP_BINDVARIABLETEMP");
		
			TXT_NEW_ID.Text					= "";
			TXT_NEW_DESC.Text				= "";
			TXT_NEW_QUERY.Text				= "";
			TXT_NEW_FIELD.Text				= "";
			RDO_NEW_TYPE.SelectedValue		= null;
			RDO_NEW_STATUS.SelectedValue	= null;

			TR_NEW_PARAMETER.Visible = false;
		}

		private void DatGridVariableReq_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			if(DatGridVariableReq.CurrentPageIndex >= 0 && DatGridVariableReq.CurrentPageIndex < DatGridVariableReq.PageCount)
			{
				DatGridVariableReq.CurrentPageIndex = e.NewPageIndex;
				BindData("DatGridVariableReq","EXEC AP_BINDVARIABLETEMP");
			}
		}

		private void DatGridVariableReq_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					TR_VARIABLE_TEMP.Visible = true;
					TXT_IDVARTEMP.Text = e.Item.Cells[0].Text.ToString();

					conn.QueryString = "SELECT VARIABLEID, DESCRIPT, COLUMNNAME, ISRANGE, ISACTIVE, QUERYTXT, STATUS, IDPREV " +
										"FROM AP_ITEMTEMP WHERE [ID] = '" + e.Item.Cells[0].Text.ToString() + "'";
					conn.ExecuteQuery();
					
					TXT_EDIT_IDTEMP.Text = e.Item.Cells[0].Text.ToString();
					TXT_EDIT_VARIDTEMP.Text = conn.GetFieldValue("VARIABLEID");
					TXT_EDIT_DESCTEMP.Text = conn.GetFieldValue("DESCRIPT");
					TXT_EDIT_QUERYTEMP.Text = conn.GetFieldValue("QUERYTXT");
					TXT_EDIT_FIELDTEMP.Text = conn.GetFieldValue("COLUMNNAME");

					if(conn.GetFieldValue("ISRANGE") == "1")
					{
						RDO_EDIT_TYPETEMP.SelectedValue = "1";
					}
					else
					{
						RDO_EDIT_TYPETEMP.SelectedValue = "0";
					}

					if(conn.GetFieldValue("ISACTIVE") == "1")
					{
						RDO_EDIT_STATUSTEMP.SelectedValue = "1";
					}
					else
					{
						RDO_EDIT_STATUSTEMP.SelectedValue = "0";
					}
					BindData("DatGridVariableReq","EXEC AP_BINDVARIABLETEMP");
					break;

				case "delete":
					conn.QueryString = "DELETE AP_ITEMTEMP WHERE [ID] = '" + e.Item.Cells[0].Text.ToString() + "'";
					conn.ExecuteQuery();

					BindData("DatGridVariableReq","EXEC AP_BINDVARIABLETEMP");
					TR_VARIABLE_TEMP.Visible = false;
					break;
			}
		}

		protected void BTN_UPDATE_VARIABLETEMP_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "UPDATE AP_ITEMTEMP SET VARIABLEID = '" + TXT_EDIT_VARIDTEMP.Text + "'," +
								"DESCRIPT = '" + TXT_EDIT_DESCTEMP.Text + "'," +
								"COLUMNNAME = '" + TXT_EDIT_FIELDTEMP.Text + "'," +
								"QUERYTXT = '" + TXT_EDIT_QUERYTEMP.Text + "'," +
								"ISRANGE = '" + RDO_EDIT_TYPETEMP.SelectedValue + "'," +
								"ISACTIVE = '" + RDO_EDIT_STATUSTEMP.SelectedValue + "' WHERE [ID] = '" + TXT_EDIT_IDTEMP.Text + "'";
			conn.ExecuteQuery();

			BindData("DatGridVariableReq","EXEC AP_BINDVARIABLETEMP");
			
			TXT_EDIT_IDTEMP.Text				= "";
			TXT_EDIT_VARIDTEMP.Text				= "";
			TXT_EDIT_DESCTEMP.Text				= "";
			TXT_EDIT_FIELDTEMP.Text				= "";
			TXT_EDIT_QUERYTEMP.Text				= "";
			RDO_EDIT_TYPETEMP.SelectedValue		= null;
			RDO_EDIT_STATUSTEMP.SelectedValue	= null;
			
			TR_VARIABLE_TEMP.Visible = false;
		}

		private void DatGrdVar_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			if(DatGrdVar.CurrentPageIndex >= 0 && DatGrdVar.CurrentPageIndex < DatGrdVar.PageCount)
			{
				DatGrdVar.CurrentPageIndex = e.NewPageIndex;
				conn.QueryString = "EXEC AP_BINDVARIABLE";
				conn.ExecuteQuery();
				BindData();
			}
		}

		private void DatGrdVar_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					TurnOnVisibleEditParameter(true);
					TXT_IDVARIABLE.Text = e.Item.Cells[0].Text.ToString();
					cekEditedField(e.Item.Cells[0].Text.ToString());
					break;
			}
		}

		private void TurnOnVisibleEditParameter(bool stat)
		{
			TR_EDIT_PARAMETER.Visible = stat;
			TR_NEW_PARAMETER.Visible = !stat;
			TR_ATTRIBUTE_NONRANGE.Visible = !stat;
			TR_ATTRIBUTE_RANGE.Visible = !stat;
		}

		private void cekEditedField(string id)
		{
			conn.QueryString = "SELECT * FROM AP_ITEM WHERE ID_AP_ITEM = '" + id + "'";
			conn.ExecuteQuery();

			TXT_EDITED_ID.Text				= conn.GetFieldValue("ID_AP_ITEM").ToString();
			TXT_EDITED_VARID.Text			= conn.GetFieldValue("ID_AP_VARIABLE").ToString();
			TXT_EDITED_DESC.Text			= conn.GetFieldValue("DESCRIPTION").ToString();
			TXT_EDITED_QUERY.Text			= conn.GetFieldValue("QUERY").ToString();
			TXT_EDITED_FIELD.Text			= conn.GetFieldValue("FIELD").ToString();
			RDO_EDITED_TYPE.SelectedValue	= conn.GetFieldValue("ISRANGE").ToString();
			RDO_EDITED_STATUS.SelectedValue	= conn.GetFieldValue("ISACTIVE").ToString();
			TXT_ID_STATUS.Text				= conn.GetFieldValue("STATUS").ToString();
		}

		protected void BTN_UPDATE_RULE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC AP_INSERT_RFVARIABLE_TEMP '" + 
				TXT_EDITED_VARID.Text.ToString() + "','" +
				TXT_EDITED_DESC.Text.ToString() + "'," +
				RDO_EDITED_TYPE.SelectedValue.ToString() + "," +
				RDO_EDITED_STATUS.SelectedValue.ToString() + ",'" +
				TXT_EDITED_QUERY.Text.ToString() + "','" +
				TXT_EDITED_FIELD.Text.ToString() + "','" +
				"2','" + 
				TXT_EDITED_ID.Text.ToString() + "'";
			conn.ExecuteQuery();

			Tools.popMessage(this,"Requesting Approval...");

			conn.QueryString = "EXEC AP_BINDVARIABLE";
			conn.ExecuteQuery();

			BindData();
			BindData("DatGridVariableReq","EXEC AP_BINDVARIABLETEMP");

			TR_EDIT_PARAMETER.Visible		= false;
			TR_NEW_PARAMETER.Visible		= false;
			TR_ATTRIBUTE_RANGE.Visible		= false;
			TR_ATTRIBUTE_NONRANGE.Visible	= false;

		}

		protected void BTN_VIEW_DETAIL_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "SELECT ID_AP_ITEM, ISRANGE FROM AP_ITEM WHERE ID_AP_ITEM = '" + TXT_EDITED_ID.Text.ToString() + "'";
			conn.ExecuteQuery();

			string id = conn.GetFieldValue("ID_AP_ITEM").ToString();

			if(conn.GetFieldValue("ISRANGE").ToString() == "0") // Non Range
			{
				TR_ATTRIBUTE_RANGE.Visible = false;
				TR_ATTRIBUTE_NONRANGE.Visible = true;
				TR_NEW_ATTRIBUTE_NONRANGE.Visible = true;
				TR_EDIT_ATTRIBUTE_NONRANGE.Visible = false;
				TR_EDIT_ATTRIBUTE_RANGE.Visible = false;

				conn.QueryString = "EXEC AP_BINDVARIABLENONRANGE '" + id + "'";
				conn.ExecuteQuery();
				BindDataAtt("NONRANGE");
			}
			else if(conn.GetFieldValue("ISRANGE").ToString() == "1") // Range
			{
				TR_ATTRIBUTE_NONRANGE.Visible = false;
				TR_ATTRIBUTE_RANGE.Visible = true;
				TR_NEW_ATTRIBUTE_RANGE.Visible = true;
				TR_EDIT_ATTRIBUTE_NONRANGE.Visible = false;
				TR_EDIT_ATTRIBUTE_RANGE.Visible = false;

				conn.QueryString = "EXEC AP_BINDVARIABLERANGE '" + id + "'";
				conn.ExecuteQuery();
				BindDataAtt("RANGE");
			}
		}

		private void BindDataAtt(string range)
		{
			if(range == "RANGE")
			{
				DataTable dt = new DataTable();
				dt = conn.GetDataTable().Copy();
				DatGridVariableRange.DataSource = dt;				
				DatGridVariableRange.DataBind();
			}
			else if(range == "NONRANGE")
			{
				DataTable dt = new DataTable();
				dt = conn.GetDataTable().Copy();
				DatGridVariableNonRange.DataSource = dt;				
				DatGridVariableNonRange.DataBind();
			}
		}

		protected void BTN_NEW_RANGE_Click(object sender, System.EventArgs e)
		{
			bool okay = false;

			if(RDO_NEW_RANGECONDITION.SelectedValue == "2")
			{
				conn.QueryString = "SELECT COUNT(ID) AS TOTAL FROM AP_ITEM_RANGETEMP WHERE ID_AP_ITEM = '" + TXT_IDVARIABLE.Text + "' AND HIGHEST = 'HIGH'";
				conn.ExecuteQuery();

				if(conn.GetFieldValue("TOTAL") == "0")
				{
					okay = true;
				}
				else
				{
					okay = false;
					Tools.popMessage(this, "Highestscore HIGH sudah ada !");
				}
			}
			else if(RDO_NEW_RANGECONDITION.SelectedValue == "1")
			{
				conn.QueryString = "SELECT COUNT(ID) AS TOTAL FROM AP_ITEM_RANGETEMP WHERE ID_AP_ITEM = '" + TXT_IDVARIABLE.Text + "' AND HIGHEST = 'NO INFORMATION' AND LOWEST = 'NO INFORMATION'";
				conn.ExecuteQuery();

				if(conn.GetFieldValue("TOTAL") == "0")
				{
					okay = true;
				}
				else
				{
					okay = false;
					Tools.popMessage(this, "No Information sudah ada !");
				}
			}
			else if(RDO_NEW_RANGECONDITION.SelectedValue == "3")
			{
				conn.QueryString = "SELECT COUNT(ID) as TOTAL FROM AP_ITEM_RANGETEMP WHERE ID_AP_ITEM = '" + TXT_IDVARIABLE.Text + "' AND LOWEST = 'BELOW'";
				conn.ExecuteQuery();

				if(conn.GetFieldValue("TOTAL") == "0")
				{
					okay = true;
				}
				else
				{
					okay = false;
					Tools.popMessage(this, "Lowestscore BELOW sudah ada !");
				}
			}
			else if(RDO_NEW_RANGECONDITION.SelectedValue == "0")
			{
				okay = true;
			}

			if(okay == true)
			{
				if(RDO_NEW_RANGECONDITION.SelectedValue.ToString() == "0")
				{
					conn.QueryString = "EXEC AP_INSERT_RFVARIABLE_RANGETEMP '" 
						+ TXT_EDITED_ID.Text.ToString() + "','"
						+ TXT_NEW_RANGELOWEST.Text.ToString() + "','"
						+ TXT_NEW_RANGEHIGHEST.Text.ToString() + "','"
						+ TXT_NEW_RANGEWEIGHT.Text.ToString() + "','"
						+ "INSERT" + "','-1'";
					conn.ExecuteQuery();
				}
				else if(RDO_NEW_RANGECONDITION.SelectedValue.ToString() == "1")
				{
					conn.QueryString = "EXEC AP_INSERT_RFVARIABLE_RANGETEMP '" 
						+ TXT_EDITED_ID.Text.ToString() + "','"
						+ "NO INFORMATION" + "','"
						+ "NO INFORMATION" + "','"
						+ TXT_NEW_RANGEWEIGHT.Text.ToString() + "','"
						+ "INSERT" + "','-1'";
					conn.ExecuteQuery();
				}
				else if(RDO_NEW_RANGECONDITION.SelectedValue.ToString() == "2")
				{
					conn.QueryString = "EXEC AP_INSERT_RFVARIABLE_RANGETEMP '" 
						+ TXT_EDITED_ID.Text.ToString() + "','"
						+ TXT_NEW_RANGELOWEST.Text.ToString() + "','"
						+ "HIGH" + "','"
						+ TXT_NEW_RANGEWEIGHT.Text.ToString() + "','"
						+ "INSERT" + "','-1'";
					conn.ExecuteQuery();
				}
				else if(RDO_NEW_RANGECONDITION.SelectedValue.ToString() == "3")
				{
					conn.QueryString = "EXEC AP_INSERT_RFVARIABLE_RANGETEMP '" 
						+ TXT_EDITED_ID.Text.ToString() + "','"
						+ "BELOW" + "','"
						+ TXT_NEW_RANGEHIGHEST.Text.ToString() + "','"
						+ TXT_NEW_RANGEWEIGHT.Text.ToString() + "','"
						+ "INSERT" + "','-1'";
					conn.ExecuteQuery();
				}

				conn.QueryString = "EXEC AP_BINDVARIABLERANGE '" + TXT_EDITED_ID.Text.ToString() + "'";
				conn.ExecuteQuery();
				BindDataAtt("RANGE");
				BindData("DatGridVariableRangeReq","EXEC AP_BINDVARIABLERANGETEMP");

				Tools.popMessage(this, "Request for approval...");
			}
			BindData("DatGridVariableRangeReq","EXEC AP_BINDVARIABLERANGETEMP");

			TXT_NEW_RANGELOWEST.Text				= "";
			TXT_NEW_RANGEHIGHEST.Text				= "";
			TXT_NEW_RANGEWEIGHT.Text				= "";
			RDO_NEW_RANGECONDITION.SelectedValue	= null;
		}

		private void DatGridVariableRangeReq_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			if(DatGridVariableRangeReq.CurrentPageIndex >= 0 && DatGridVariableRangeReq.CurrentPageIndex < DatGridVariableRangeReq.PageCount)
			{
				DatGridVariableRangeReq.CurrentPageIndex = e.NewPageIndex;
				BindData("DatGridVariableRangeReq","EXEC AP_BINDVARIABLERANGETEMP");
			}
		}

		private void DatGridVariableRangeReq_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					conn.QueryString = "SELECT AP_ITEM_RANGETEMP.[ID], ID_AP_ITEM, LOWEST, HIGHEST, WEIGHT, STATUS, IDPREV " +
						"FROM AP_ITEM_RANGETEMP WHERE AP_ITEM_RANGETEMP.[ID] = '" + e.Item.Cells[0].Text.ToString() + "'";
					conn.ExecuteQuery();

					TXT_EDIT_RANGEIDTEMP.Text		= conn.GetFieldValue("ID");
					TXT_EDIT_RANGELOWESTTEMP.Text	= conn.GetFieldValue("LOWEST");
					TXT_EDIT_RANGEHIGHESTTEMP.Text	= conn.GetFieldValue("HIGHEST");
					TXT_EDIT_RANGEWEIGHTTEMP.Text	= conn.GetFieldValue("WEIGHT");
					
					if(conn.GetFieldValue("HIGHEST") == "HIGH")
					{
						RDO_EDIT_RANGECONDITIONTEMP.SelectedValue = "2";
					}
					else if(conn.GetFieldValue("LOWEST") == "BELOW")
					{
						RDO_EDIT_RANGECONDITIONTEMP.SelectedValue = "3";
					}
					else if(conn.GetFieldValue("LOWEST").Replace(" ","").ToString() == "NOINFORMATION" 
						&& conn.GetFieldValue("HIGHEST").Replace(" ","").ToString() == "NOINFORMATION")
					{
						RDO_EDIT_RANGECONDITIONTEMP.SelectedValue = "1";
					}
					else
					{
						RDO_EDIT_RANGECONDITIONTEMP.SelectedValue = "0";
					}

					BindData("DatGridVariableRangeReq","EXEC AP_BINDVARIABLERANGETEMP");
					TR_ATTRANGE_TEMP.Visible = true;
					break;

				case "delete":
					conn.QueryString = "DELETE AP_ITEM_RANGETEMP WHERE [ID] = '" + e.Item.Cells[0].Text.ToString() + "'";
					conn.ExecuteQuery();
					BindData("DatGridVariableRangeReq","EXEC AP_BINDVARIABLERANGETEMP");
					TR_ATTRANGE_TEMP.Visible = false;
					break;
			}
		}

		protected void BTN_EDIT_RANGETEMP_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "UPDATE AP_ITEM_RANGETEMP SET LOWEST = '" + TXT_EDIT_RANGELOWESTTEMP.Text + "'," +
				"HIGHEST = '" + TXT_EDIT_RANGEHIGHESTTEMP.Text + "'," +
				"WEIGHT = '" + TXT_EDIT_RANGEWEIGHTTEMP.Text + "' " +
				"WHERE [ID] = '" + TXT_EDIT_RANGEIDTEMP.Text + "'";

			if(RDO_EDIT_RANGECONDITIONTEMP.SelectedValue == "2")
			{
				conn.QueryString = "UPDATE AP_ITEM_RANGETEMP SET LOWEST = '" + TXT_EDIT_RANGELOWESTTEMP.Text + "'," +
					"HIGHEST = 'HIGH'," +
					"WEIGHT = '" + TXT_EDIT_RANGEWEIGHTTEMP.Text + "' " +
					"WHERE [ID] = '" + TXT_EDIT_RANGEIDTEMP.Text + "'";
			}
			else if(RDO_EDIT_RANGECONDITIONTEMP.SelectedValue == "3")
			{
				conn.QueryString = "UPDATE AP_ITEM_RANGETEMP SET LOWEST = 'BELOW'," +
					"HIGHEST = '" + TXT_EDIT_RANGEHIGHESTTEMP.Text + "'," +
					"WEIGHT = '" + TXT_EDIT_RANGEWEIGHTTEMP.Text + "' " +
					"WHERE [ID] = '" + TXT_EDIT_RANGEIDTEMP.Text + "'";
			}
			else if(RDO_EDIT_RANGECONDITIONTEMP.SelectedValue == "1")
			{
				conn.QueryString = "UPDATE AP_ITEM_RANGETEMP SET LOWEST = 'NO INFORMATION'," +
					"HIGHEST = 'NO INFORMATION'," +
					"WEIGHT = '" + TXT_EDIT_RANGEWEIGHTTEMP.Text + "' " +
					"WHERE [ID] = '" + TXT_EDIT_RANGEIDTEMP.Text + "'";
			}
			else if(RDO_EDIT_RANGECONDITIONTEMP.SelectedValue == "0")
			{
				conn.QueryString = "UPDATE AP_ITEM_RANGETEMP SET LOWEST = '" + TXT_EDIT_RANGELOWESTTEMP.Text + "'," +
					"HIGHEST = '" + TXT_EDIT_RANGEHIGHESTTEMP.Text + "'," +
					"WEIGHT = '" + TXT_EDIT_RANGEWEIGHTTEMP.Text + "' " +
					"WHERE [ID] = '" + TXT_EDIT_RANGEIDTEMP.Text + "'";
			}
			conn.ExecuteQuery();

			BindData("DatGridVariableRangeReq","EXEC AP_BINDVARIABLERANGETEMP");
			TR_ATTRANGE_TEMP.Visible = false;
		}

		private void DatGridVariableRange_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			if(DatGridVariableRange.CurrentPageIndex >= 0 && DatGridVariableRange.CurrentPageIndex < DatGridVariableRange.PageCount)
			{
				DatGridVariableRange.CurrentPageIndex = e.NewPageIndex;
				BindDataAtt("RANGE");
			}
		}

		private void DatGridVariableRange_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					TR_EDIT_ATTRIBUTE_RANGE.Visible = true;
					TR_NEW_ATTRIBUTE_RANGE.Visible = false;
					TXT_IDVARRANGE.Text = e.Item.Cells[0].Text.ToString();
					cekEditedRange(e.Item.Cells[0].Text.ToString());
					break;

				case "delete":
					conn.QueryString = "SELECT AP_ITEM_RANGE.ID_AP_ITEM, AP_ITEM_RANGE.LOWEST, AP_ITEM_RANGE.HIGHEST, AP_ITEM_RANGE.WEIGHT, AP_ITEM.[DESCRIPTION] " +
						"FROM AP_ITEM, AP_ITEM_RANGE WHERE AP_ITEM.ID_AP_ITEM = AP_ITEM_RANGE.ID_AP_ITEM " +
						"AND AP_ITEM_RANGE.ID_AP_ITEM_RANGE = '" + e.Item.Cells[0].Text.ToString() + "'";
					conn.ExecuteQuery();

					conn.QueryString = "EXEC AP_INSERT_RFVARIABLE_RANGETEMP '" 
						+ conn.GetFieldValue("ID_AP_ITEM") + "','"
						+ conn.GetFieldValue("LOWEST") + "','"
						+ conn.GetFieldValue("HIGHEST") + "','"
						+ conn.GetFieldValue("WEIGHT") + "','"
						+ "DELETE" + "','" 
						+ e.Item.Cells[0].Text.ToString() + "'";
					conn.ExecuteQuery();
					Tools.popMessage(this, "Requesting approval...");
					BindDataAtt("RANGE");
					BindData("DatGridVariableRangeReq","EXEC AP_BINDVARIABLERANGETEMP");
					break;
			}
		}

		private void cekEditedRange(string id)
		{
			conn.QueryString = "SELECT * FROM AP_ITEM_RANGE WHERE ID_AP_ITEM_RANGE = '" + id + "'";
			conn.ExecuteQuery();

			TXT_EDITED_RANGEID.Text			= conn.GetFieldValue("ID_AP_ITEM_RANGE").ToString();
			TXT_EDITED_RANGELOWEST.Text		= conn.GetFieldValue("LOWEST").ToString();
			TXT_EDITED_RANGEHIGHEST.Text	= conn.GetFieldValue("HIGHEST").ToString();
			TXT_EDITED_RANGEWEIGHT.Text		= conn.GetFieldValue("WEIGHT").ToString();

			if(conn.GetFieldValue("HIGHEST").ToString().Replace(" ","").ToString() == "HIGH")
			{
				RDO_EDITED_RANGECONDITION.SelectedValue = "2";
			}
			else if(conn.GetFieldValue("LOWEST").ToString().Replace(" ","").ToString() == "BELOW")
			{
				RDO_EDITED_RANGECONDITION.SelectedValue = "3";
			}
			else if(conn.GetFieldValue("LOWEST").ToString().Replace(" ","").ToString() == "NOINFORMATION" &&
				conn.GetFieldValue("HIGHEST").ToString().Replace(" ","").ToString() == "NOINFORMATION")
			{
				RDO_EDITED_RANGECONDITION.SelectedValue = "1";
			}
			else
			{
				RDO_EDITED_RANGECONDITION.SelectedValue = "0";
			}
		}

		protected void BTN_EDITED_RANGE_Click(object sender, System.EventArgs e)
		{
			bool okay = false;

			if(RDO_EDITED_RANGECONDITION.SelectedValue == "2")
			{
				conn.QueryString = "SELECT COUNT(ID) as TOTAL FROM AP_ITEM_RANGETEMP WHERE ID_AP_ITEM = '" + TXT_IDVARRANGE.Text + "' AND HIGHEST = 'HIGH'";
				conn.ExecuteQuery();

				if(conn.GetFieldValue("TOTAL") == "0")
				{
					okay = true;
				}
				else
				{
					okay = false;
					Tools.popMessage(this, "Highestscore HIGH sudah ada !");
				}
			}
			else if(RDO_EDITED_RANGECONDITION.SelectedValue == "1")
			{
				conn.QueryString = "SELECT COUNT(ID) as TOTAL FROM AP_ITEM_RANGETEMP WHERE ID_AP_ITEM = '" + TXT_IDVARRANGE.Text + "' AND HIGHEST = 'NO INFORMATION' AND LOWEST = 'NO INFORMATION'";
				conn.ExecuteQuery();

				if(conn.GetFieldValue("TOTAL") == "0")
				{
					okay = true;
				}
				else
				{
					okay = false;
					Tools.popMessage(this, "No Information sudah ada !");
				}
			}
			else if(RDO_EDITED_RANGECONDITION.SelectedValue == "3")
			{
				conn.QueryString = "SELECT COUNT(ID) as TOTAL FROM AP_ITEM_RANGETEMP WHERE ID_AP_ITEM = '" + TXT_IDVARRANGE.Text + "' AND LOWEST = 'BELOW'";
				conn.ExecuteQuery();

				if(conn.GetFieldValue("TOTAL") == "0")
				{
					okay = true;
				}
				else
				{
					okay = false;
					Tools.popMessage(this, "Lowestscore BELOW sudah ada !");
				}
			}
			else if(RDO_EDITED_RANGECONDITION.SelectedValue == "0")
			{
				okay = true;
			}

			if(okay == true)
			{

				if(RDO_EDITED_RANGECONDITION.SelectedValue.ToString() == "0")
				{
					//sampai sini
					conn.QueryString = "EXEC AP_INSERT_RFVARIABLE_RANGETEMP '" 
						+ TXT_EDITED_ID.Text.ToString() + "','"
						+ TXT_EDITED_RANGELOWEST.Text.ToString() + "','"
						+ TXT_EDITED_RANGEHIGHEST.Text.ToString() + "','"
						+ TXT_EDITED_RANGEWEIGHT.Text.ToString() + "','"
						+ "UPDATE" + "','" 
						+ TXT_EDITED_RANGEID.Text.ToString() + "'";
					conn.ExecuteQuery();
				}
				else if(RDO_EDITED_RANGECONDITION.SelectedValue.ToString() == "1")
				{
					conn.QueryString = "EXEC AP_INSERT_RFVARIABLE_RANGETEMP '" 
						+ TXT_EDITED_ID.Text.ToString() + "','"
						+ "NO INFORMATION" + "','"
						+ "NO INFORMATION" + "','"
						+ TXT_EDITED_RANGEWEIGHT.Text.ToString() + "','"
						+ "UPDATE" + "','" 
						+ TXT_EDITED_RANGEID.Text.ToString() + "'";
					conn.ExecuteQuery();
				}
				else if(RDO_EDITED_RANGECONDITION.SelectedValue.ToString() == "2")
				{
					conn.QueryString = "EXEC AP_INSERT_RFVARIABLE_RANGETEMP '" 
						+ TXT_EDITED_ID.Text.ToString() + "','"
						+ TXT_EDITED_RANGELOWEST.Text.ToString() + "','"
						+ "HIGH" + "','"
						+ TXT_EDITED_RANGEWEIGHT.Text.ToString() + "','"
						+ "UPDATE" + "','" 
						+ TXT_EDITED_RANGEID.Text.ToString() + "'";
					conn.ExecuteQuery();
				}
				else if(RDO_EDITED_RANGECONDITION.SelectedValue.ToString() == "3")
				{
					conn.QueryString = "EXEC AP_INSERT_RFVARIABLE_RANGETEMP '" 
						+ TXT_EDITED_ID.Text.ToString() + "','"
						+ "BELOW" + "','"
						+ TXT_EDITED_RANGEHIGHEST.Text.ToString() + "','"
						+ TXT_EDITED_RANGEWEIGHT.Text.ToString() + "','"
						+ "UPDATE" + "','" 
						+ TXT_EDITED_RANGEID.Text.ToString() + "'";
					conn.ExecuteQuery();
				}

				conn.QueryString = "EXEC AP_BINDVARIABLERANGE '" + TXT_EDITED_ID.Text.ToString() + "'";
				conn.ExecuteQuery();
				BindDataAtt("RANGE");
				//ClearData();
				BindData("DatGridVariableRangeReq","EXEC AP_BINDVARIABLERANGETEMP");

				Tools.popMessage(this, "Request for approval...");
			}
			BindData("DatGridVariableRangeReq","EXEC AP_BINDVARIABLERANGETEMP");

			TXT_EDITED_RANGEID.Text					= "";
			TXT_EDITED_RANGELOWEST.Text				= "";
			TXT_EDITED_RANGEHIGHEST.Text			= "";
			TXT_EDITED_RANGEWEIGHT.Text				= "";
			RDO_EDITED_RANGECONDITION.SelectedValue = null;
		}

		protected void BTN_NEW_NONRANGE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC AP_INSERT_RFVARIABLE_NONRANGETEMP '" 
				+ TXT_IDVARIABLE.Text.ToString() + "','"
				+ TXT_NEW_NONRANGEVALUE.Text.ToString() + "','"
				+ TXT_NEW_NONRANGEWEIGHT.Text.ToString() + "','"
				+ "INSERT','-1'";
			conn.ExecuteQuery();

			Tools.popMessage(this, "Requesting approval...");

			BindDataAtt("NONRANGE");
			BindData("DatGridVariableNonRangeReq","EXEC AP_BINDVARIABLENONRANGETEMP");

			TXT_NEW_NONRANGEVALUE.Text	= "";
			TXT_NEW_NONRANGEWEIGHT.Text	= "";
		}

		private void DatGridVariableNonRangeReq_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			if(DatGridVariableNonRangeReq.CurrentPageIndex >= 0 && DatGridVariableNonRangeReq.CurrentPageIndex < DatGridVariableNonRangeReq.PageCount)
			{
				DatGridVariableNonRangeReq.CurrentPageIndex = e.NewPageIndex;
				BindData("DatGridVariableNonRangeReq","EXEC AP_BINDVARIABLENONRANGETEMP");
			}
		}

		private void DatGridVariableNonRangeReq_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					TR_ATTNONRANGE_TEMP.Visible = true;

					conn.QueryString = "SELECT * FROM AP_ITEM_NONRANGETEMP WHERE [ID] = '" + e.Item.Cells[0].Text.ToString() + "'";
					conn.ExecuteQuery();

					TXT_EDIT_NONRANGEIDTEMP.Text	= conn.GetFieldValue("ID");
					TXT_EDIT_NONRANGEVALUETEMP.Text	= conn.GetFieldValue("VALUE");
					TXT_EDIT_NONRANGEWEIGHTTEMP.Text= conn.GetFieldValue("WEIGHT");

					BindData("DatGridVariableNonRangeReq","EXEC AP_BINDVARIABLENONRANGETEMP");
					break;

				case "delete":
					conn.QueryString = "DELETE AP_ITEM_NONRANGETEMP WHERE [ID] = '" + e.Item.Cells[0].Text.ToString() + "'";
					conn.ExecuteQuery();
					BindData("DatGridVariableNonRangeReq","EXEC AP_BINDVARIABLENONRANGETEMP");
					TR_ATTNONRANGE_TEMP.Visible = false;
					break;
			}
		}

		protected void BTN_EDIT_NONRANGETEMP_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "UPDATE AP_ITEM_NONRANGETEMP SET VALUE = '" + TXT_EDIT_NONRANGEVALUETEMP.Text + "', WEIGHT = '" + TXT_EDIT_NONRANGEWEIGHTTEMP.Text + "' " +
				"WHERE [ID] = '" + TXT_EDIT_NONRANGEIDTEMP.Text + "'";
			conn.ExecuteQuery();
			BindData("DatGridVariableNonRangeReq","EXEC AP_BINDVARIABLENONRANGETEMP");
			TR_ATTNONRANGE_TEMP.Visible = false;
		}

		private void DatGridVariableNonRange_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			if(DatGridVariableNonRange.CurrentPageIndex >= 0 && DatGridVariableNonRange.CurrentPageIndex < DatGridVariableNonRange.PageCount)
			{
				DatGridVariableNonRange.CurrentPageIndex = e.NewPageIndex;
				BindDataAtt("NONRANGE");
			}
		}

		private void DatGridVariableNonRange_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					TR_EDIT_ATTRIBUTE_NONRANGE.Visible = true;
					TR_NEW_ATTRIBUTE_NONRANGE.Visible = false;
					cekEditedNonRange(e.Item.Cells[0].Text.ToString());
					break;

				case "delete":
					conn.QueryString = "DELETE AP_ITEM_NON_RANGE WHERE ID_AP_ITEM_NON_RANGE ='" + e.Item.Cells[0].Text.ToString() + "'";
					conn.ExecuteNonQuery();
					conn.QueryString = "EXEC AP_BINDVARIABLENONRANGE '" + TXT_EDITED_ID.Text + "'";
					conn.ExecuteQuery();
					BindDataAtt("NONRANGE");
					break;
			}
		}

		private void cekEditedNonRange(string id)
		{
			conn.QueryString = "SELECT * FROM AP_ITEM_NON_RANGE WHERE ID_AP_ITEM_NON_RANGE = '" + id + "'"; 
			conn.ExecuteQuery();

			TXT_EDITED_NONRANGEID.Text = conn.GetFieldValue("ID_AP_ITEM_NON_RANGE").ToString();
			TXT_EDITED_NONRANGEVALUE.Text = conn.GetFieldValue("VALUE").ToString();
			TXT_EDITED_NONRANGEWEIGHT.Text = conn.GetFieldValue("WEIGHT").ToString();
		}

		protected void BTN_EDITED_NONRANGE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC AP_INSERT_RFVARIABLE_NONRANGETEMP '" 
				+ TXT_IDVARIABLE.Text.ToString() + "','"
				+ TXT_EDITED_NONRANGEVALUE.Text.ToString() + "','"
				+ TXT_EDITED_NONRANGEWEIGHT.Text.ToString() + "','UPDATE','"
				+ TXT_EDITED_NONRANGEID.Text.ToString() + "'";
			conn.ExecuteQuery();

			BindData("DatGridVariableNonRangeReq","EXEC AP_BINDVARIABLENONRANGETEMP");
			//ClearData();
			TXT_EDITED_NONRANGEID.Text		= "";
			TXT_EDITED_NONRANGEVALUE.Text	= "";
			TXT_EDITED_NONRANGEWEIGHT.Text	= "";

			Tools.popMessage(this, "Requesting approval...");
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../AccountPlanningParam.aspx?mc=" + Request.QueryString["mc"]);
		}
	}
}
