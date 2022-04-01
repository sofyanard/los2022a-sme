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
	/// Summary description for ActionPlanMain.
	/// </summary>
	public partial class ActionPlanMain : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				Session.Add("grid", "");
				FillDropListUnit();
				FillDropListProduct();
			}

			ViewData();
			FillAnchorGrid();
		}

		private void FillDropListUnit()
		{
			DDL_WORKING_UNIT.Items.Clear();
			DDL_WORKING_UNIT.Items.Add(new ListItem("--Select--", ""));
						
			conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH WHERE ACTIVE='1'";
			conn.ExecuteQuery();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_WORKING_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDropListProduct()
		{
			DDL_PRODUCT.Items.Clear();
			DDL_PRODUCT.Items.Add(new ListItem("--Select--", ""));
						
			conn.QueryString = "SELECT ID_AP_VARIABLE, [DESCRIPTION] FROM AP_VARIABLE WHERE STATUS='1'";
			conn.ExecuteQuery();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_PRODUCT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT DISTINCT * FROM VW_AP_CUSTOMER_LIST WHERE CIF#='" + Request.QueryString["cif"] + "'";
			conn.ExecuteQuery();

			TXT_CIF.Text = conn.GetFieldValue("CIF#").ToString();
			TXT_CUST_NAME.Text = conn.GetFieldValue("CUSTOMER_GROUP").ToString();
			TXT_ADDRESS.Text = conn.GetFieldValue("CUST_ADDRESS").ToString();
			TXT_KOTA.Text = conn.GetFieldValue("CUST_CITY").ToString();
			TXT_CUST_DATE.Text = tools.FormatDate(conn.GetFieldValue("CUST_DATE").ToString());
			TXT_RM.Text = conn.GetFieldValue("RM_NAME").ToString();
			TXT_GROUP_NAME.Text = conn.GetFieldValue("GROUP_NAME").ToString();
			TXT_UNIT_NAME.Text = conn.GetFieldValue("BRANCH_NAME").ToString();
			TXT_RELATIONSHIP.Text = conn.GetFieldValue("CUST_LENGTH").ToString();

			ViewCompany();
		}

		private void FillAnchorGrid()
		{
			conn.QueryString = "SELECT * FROM AP_ANCHOR_CLIENT_TEAM WHERE CIF='" + TXT_CIF.Text + "'";
			BindData(DGR_ANCHORTEAM, conn.QueryString);
		}

		private void ViewCompany()
		{
			conn2.QueryString = "SELECT * FROM AP_COMPANY_INFO WHERE CIF_GROUP='" + TXT_CIF.Text + "'";
			conn2.ExecuteQuery();

			for(int i = 0; i < conn2.GetRowCount(); i++)
			{
				CreateContent(conn2.GetFieldValue(i,"CIF_CUST"), conn2.GetFieldValue(i,"CUSTOMER_NAME"));
			}
		}

		private void CreateContent(string ID_CIF, string CUST_NAME)
		{
			System.Web.UI.WebControls.DataGrid DATA_GRID;
			System.Web.UI.WebControls.TextBox TXT_BOX;
			System.Web.UI.WebControls.DropDownList DDL;
			System.Web.UI.WebControls.Button BTN;
			LinkButtonTemplate LBT;

			System.Web.UI.HtmlControls.HtmlTableRow TR;
			System.Web.UI.HtmlControls.HtmlTableCell TD;
			System.Web.UI.HtmlControls.HtmlTableRow TR2;
			System.Web.UI.HtmlControls.HtmlTableCell TD2;
			System.Web.UI.WebControls.Label LBL_LABEL;
			System.Web.UI.HtmlControls.HtmlTable Table6;
			
			/************************************ MEMBUAT TITLE PAGE ********************************************/

			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = "COMPANY NAME : " + CUST_NAME;

			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["class"] = "tdHeader1";
			TD.Attributes["colspan"] = "2";
			TR.Controls.Add(TD);

			TBL_COMPANY.Controls.Add(TR);

			/************************************ MEMBUAT DATA GRID **********************************************/
			
			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			TD.Attributes["colspan"] = "2";

			DATA_GRID = new DataGrid();
			DATA_GRID.ID = "GRID_" + ID_CIF;
			DATA_GRID.AllowPaging = true;
			DATA_GRID.CellPadding = 1;
			DATA_GRID.AutoGenerateColumns = false;
			DATA_GRID.Width = Unit.Percentage(100.0);
			DATA_GRID.AlternatingItemStyle.CssClass = "TblAlternating";
			DATA_GRID.PagerStyle.Mode = PagerMode.NumericPages;
			DATA_GRID.ItemCommand += new DataGridCommandEventHandler(DATA_GRID_ItemCommand);

			/**************** Membuat Field pada Data Grid *****************/
			conn.QueryString = "SELECT * FROM VW_AP_COMPANY_FIELD_DATA_GRID ORDER BY CONVERT(INT,FIELDID) ASC";
			conn.ExecuteQuery();
	
			BoundColumn columns = new BoundColumn();
			columns.HeaderText = conn.GetFieldValue(0,1).ToString();
			columns.DataField = conn.GetFieldValue(0,2).ToString();
			columns.Visible = true;
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DATA_GRID.Columns.Add(columns);

			for(int i = 1; i < conn.GetRowCount(); i++)
			{
				columns = new BoundColumn();
				columns.HeaderText = conn.GetFieldValue(i,1).ToString();
				columns.DataField = conn.GetFieldValue(i,2).ToString();
				columns.HeaderStyle.CssClass = "tdSmallHeader";
				columns.Visible = true;
				columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
				DATA_GRID.Columns.Add(columns);
			}

			TemplateColumn columnsz = new TemplateColumn();
			columnsz = new TemplateColumn();
			columnsz.HeaderText = "Function";
			columnsz.HeaderStyle.CssClass = "tdSmallHeader";
			columnsz.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			LBT = new LinkButtonTemplate("LBT_" + ID_CIF);
			columnsz.ItemTemplate = LBT;
			DATA_GRID.Columns.Add(columnsz);

			/*********************** BIND DATA ****************************/
			//conn.QueryString = "EXEC AP_COMPANY_FIELD_DATA_GRID ''";
			conn.QueryString = "SELECT * FROM AP_ANCHOR_COMPANY WHERE CIF='" + ID_CIF + "'";
			BindData(DATA_GRID, conn.QueryString);

			TD.Controls.Add(DATA_GRID);
			DATA_GRID.PageIndexChanged += new DataGridPageChangedEventHandler(DATA_GRID_PageIndexChanged);
			TR.Controls.Add(TD);

			TBL_COMPANY.Controls.Add(TR);

			/******************* Membuat TD untuk Text Box & Button ********************/
			conn.QueryString = "SELECT * FROM VW_AP_COMPANY_FIELD_TITLE";
			conn.ExecuteQuery();
			
			/********************* Baris 1 *********************/
			TR2 = new HtmlTableRow();
			TD2 = new HtmlTableCell();
			Table6 = new HtmlTable();

			//label
			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = conn.GetFieldValue("TITLEPAGE1");
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["width"] = "25%";
			TD.Attributes["class"] = "TDBGColor1";
			TR.Controls.Add(TD);
						
			//txt
			TD = new HtmlTableCell();
			DDL = new DropDownList();
			DDL.Width = 350;
			DDL.ID = "DDL_PRODUCT_" + ID_CIF;
			TD.Controls.Add(DDL);
			TR.Controls.Add(TD);

			//label
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = conn.GetFieldValue("TITLEPAGE6");
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["width"] = "25%";
			TD.Attributes["class"] = "TDBGColor1";
			TR.Controls.Add(TD);
						
			//txt
			TD = new HtmlTableCell();
			TXT_BOX = new TextBox();
			TXT_BOX.Width = 350;
			TXT_BOX.ID = "TXT_PICNAME_" + ID_CIF;
			TD.Controls.Add(TXT_BOX);
			TR.Controls.Add(TD);

			Table6.Controls.Add(TR);
			TD2.Controls.Add(Table6);
			TR2.Controls.Add(TD2);

			TBL_COMPANY.Controls.Add(TR2);

			/********************* Baris 2 *********************/
			Table6 = new HtmlTable();
			//label
			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = conn.GetFieldValue("TITLEPAGE2");
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["width"] = "25%";
			TD.Attributes["class"] = "TDBGColor1";
			TR.Controls.Add(TD);
						
			//txt
			TD = new HtmlTableCell();
			TXT_BOX = new TextBox();
			TXT_BOX.Width = 350;
			TXT_BOX.ID = "TXT_ACTIONPLAN_" + ID_CIF;
			TD.Controls.Add(TXT_BOX);
			TR.Controls.Add(TD);
			
			//label
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = conn.GetFieldValue("TITLEPAGE7");
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["width"] = "25%";
			TD.Attributes["class"] = "TDBGColor1";
			TR.Controls.Add(TD);
						
			//txt
			TD = new HtmlTableCell();
			DDL = new DropDownList();
			DDL.Width = 350;
			DDL.ID = "DDL_UNIT_" + ID_CIF;
			TD.Controls.Add(DDL);
			TR.Controls.Add(TD);

			Table6.Controls.Add(TR);
			TD2.Controls.Add(Table6);
			TR2.Controls.Add(TD2);

			TBL_COMPANY.Controls.Add(TR2);

			/********************* Baris 3 *********************/
			//label
			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = conn.GetFieldValue("TITLEPAGE3");
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["width"] = "25%";
			TD.Attributes["class"] = "TDBGColor1";
			TR.Controls.Add(TD);
						
			//txt
			TD = new HtmlTableCell();
			TXT_BOX = new TextBox();
			TXT_BOX.Width = 350;
			TXT_BOX.ID = "TXT_ACTIONSTEP_" + ID_CIF;
			TD.Controls.Add(TXT_BOX);
			TR.Controls.Add(TD);
			
			//label
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = conn.GetFieldValue("TITLEPAGE8");
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["width"] = "25%";
			TD.Attributes["class"] = "TDBGColor1";
			TR.Controls.Add(TD);
						
			//txt
			TD = new HtmlTableCell();
			DDL = new DropDownList();
			DDL.Width = 350;
			DDL.ID = "DDL_SUPPORTTYPE_" + ID_CIF;
			TD.Controls.Add(DDL);
			TR.Controls.Add(TD);

			Table6.Controls.Add(TR);
			TD2.Controls.Add(Table6);
			TR2.Controls.Add(TD2);

			TBL_COMPANY.Controls.Add(TR2);

			/********************* Baris 4 *********************/
			//label
			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = conn.GetFieldValue("TITLEPAGE4");
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["width"] = "25%";
			TD.Attributes["class"] = "TDBGColor1";
			TR.Controls.Add(TD);
						
			//txt
			TD = new HtmlTableCell();
			//date
			TXT_BOX = new TextBox();
			TXT_BOX.Width = 30;
			TXT_BOX.Attributes["MaxLength"] = "2";
			TXT_BOX.ID = "TXT_ACTION_DD_" + ID_CIF;
			TD.Controls.Add(TXT_BOX);
			TR.Controls.Add(TD);
			//month
			DDL = new DropDownList();
			DDL.Width = 100;
			DDL.ID = "DDL_ACTION_MM_" + ID_CIF;
			TD.Controls.Add(DDL);
			TR.Controls.Add(TD);
			//year
			TXT_BOX = new TextBox();
			TXT_BOX.Width = 60;
			TXT_BOX.Attributes["MaxLength"] = "4";
			TXT_BOX.ID = "TXT_ACTION_YY_" + ID_CIF;
			TD.Controls.Add(TXT_BOX);
			TR.Controls.Add(TD);
			
			//label
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = conn.GetFieldValue("TITLEPAGE9");
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["width"] = "25%";
			TD.Attributes["class"] = "TDBGColor1";
			TR.Controls.Add(TD);
						
			//txt
			TD = new HtmlTableCell();
			TXT_BOX = new TextBox();
			TXT_BOX.Width = 350;
			TXT_BOX.ID = "TXT_SUPPORTDESC_" + ID_CIF;
			TD.Controls.Add(TXT_BOX);
			TR.Controls.Add(TD);

			Table6.Controls.Add(TR);
			TD2.Controls.Add(Table6);
			TR2.Controls.Add(TD2);

			TBL_COMPANY.Controls.Add(TR2);

			/********************* Baris 5 *********************/
			//label
			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = conn.GetFieldValue("TITLEPAGE5");
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["width"] = "25%";
			TD.Attributes["class"] = "TDBGColor1";
			TR.Controls.Add(TD);
						
			//txt
			TD = new HtmlTableCell();
			//date
			TXT_BOX = new TextBox();
			TXT_BOX.Width = 30;
			TXT_BOX.Attributes["MaxLength"] = "2";
			TXT_BOX.ID = "TXT_COMPLETION_DD_" + ID_CIF;
			TD.Controls.Add(TXT_BOX);
			TR.Controls.Add(TD);
			//month
			DDL = new DropDownList();
			DDL.Width = 100;
			DDL.ID = "DDL_COMPLETION_MM_" + ID_CIF;
			TD.Controls.Add(DDL);
			TR.Controls.Add(TD);
			//year
			TXT_BOX = new TextBox();
			TXT_BOX.Width = 60;
			TXT_BOX.Attributes["MaxLength"] = "4";
			TXT_BOX.ID = "TXT_COMPLETION_YY_" + ID_CIF;
			TD.Controls.Add(TXT_BOX);
			TR.Controls.Add(TD);
			
			//label
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = conn.GetFieldValue("TITLEPAGE10");
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["width"] = "25%";
			TD.Attributes["class"] = "TDBGColor1";
			TR.Controls.Add(TD);
						
			//txt
			TD = new HtmlTableCell();
			TXT_BOX = new TextBox();
			TXT_BOX.Width = 350;
			TXT_BOX.ID = "TXT_REMARK_" + ID_CIF;
			TD.Controls.Add(TXT_BOX);
			TR.Controls.Add(TD);

			Table6.Controls.Add(TR);
			TD2.Controls.Add(Table6);
			TR2.Controls.Add(TD2);

			TBL_COMPANY.Controls.Add(TR2);

			/********************* Baris 6 *********************/
			//label
			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.ID = "LBL_ID_" + ID_CIF;
			LBL_LABEL.Visible = false;
			TD.Controls.Add(LBL_LABEL);
			TR.Controls.Add(TD);

			Table6.Controls.Add(TR);
			TD2.Controls.Add(Table6);
			TR2.Controls.Add(TD2);

			TBL_COMPANY.Controls.Add(TR2);

			/******************* Fill DropDownList *******************/
			FillDDLProduct(ID_CIF, this);
			FillDDLDate(ID_CIF, this);
			FillDDLUnit(ID_CIF, this);
			FillDDLType(ID_CIF, this);

			/******************* TD untuk Button ********************/
			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			TD.Attributes["class"] = "TDBGColor2";
			TD.Attributes["align"] = "center";
			TD.Attributes["width"] = "100%";
			TD.Attributes["colSpan"] = "2";
			BTN = new Button();
			BTN.Attributes["class"] = "button1";
			BTN.Text = "   INSERT   ";
			BTN.ID = "BTN_SAVE_" + ID_CIF;
			// EVENT UNTUK INSERT
			BTN.Click += new EventHandler(BTN_Click);
			TD.Controls.Add(BTN);
			TR.Controls.Add(TD);

			TBL_COMPANY.Controls.Add(TR);
		}

		private class LinkButtonTemplate : ITemplate
		{
			string id = "";
			public LinkButtonTemplate(string id)
			{
				this.id = id;
			}

			public void InstantiateIn(System.Web.UI.Control container)
			{    
				LinkButton lb = new LinkButton();
				lb.ID = "LNK_EDIT_" + id;
				lb.Text = "Edit";
				lb.CommandName = "edit";
				container.Controls.Add(lb);

				Label lbl = new Label();
				lbl.Text = "    ";
				container.Controls.Add(lbl);

				lb = new LinkButton();
				lb.ID = "LNK_DELETE_" + id;
				lb.Text = "Delete";
				lb.CommandName = "delete";
				container.Controls.Add(lb);
			}
		}

		private void FillDDLProduct(string ID_CIF, Control Page)
		{
			foreach (Control ctrl in Page.Controls)
			{
				if (ctrl is DropDownList)
				{
					DropDownList product = (DropDownList)this.FindControl("DDL_PRODUCT_" + ID_CIF);
					//if(product.SelectedValue.ToString().Trim() == "")
					//{
						product.Items.Clear();
						product.Items.Add(new ListItem("--Select--", ""));
						
						//conn.QueryString = "SELECT PRODUCTID, PRODUCTDESC FROM RFPRODUCT WHERE ACTIVE='1'";
						conn.QueryString = "SELECT ID_AP_VARIABLE, [DESCRIPTION] FROM AP_VARIABLE WHERE STATUS='1'";
						conn.ExecuteQuery();

						for(int i = 0; i < conn.GetRowCount(); i++)
						{
							product.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
						}
					//}
				}

				else
				{
					if (ctrl.Controls.Count > 0)
					{
						FillDDLProduct(ID_CIF, ctrl);
					}
				}
			}
		}

		private void FillDDLDate(string ID_CIF, Control Page)
		{
			foreach (Control ctrl in Page.Controls)
			{
				if (ctrl is DropDownList)
				{
					DropDownList action = (DropDownList)this.FindControl("DDL_ACTION_MM_" + ID_CIF);
					DropDownList completion = (DropDownList)this.FindControl("DDL_COMPLETION_MM_" + ID_CIF);
			
					action.Items.Clear();
					completion.Items.Clear();
					action.Items.Add(new ListItem("--Select--", ""));
					completion.Items.Add(new ListItem("--Select--", ""));

					for(int i = 1; i <= 12; i++)
					{
						action.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
						completion.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					}
				}
				else
				{
					if (ctrl.Controls.Count > 0)
					{
						FillDDLDate(ID_CIF, ctrl);
					}
				}
			}
		}

		private void FillDDLUnit(string ID_CIF, Control Page)
		{
			foreach (Control ctrl in Page.Controls)
			{
				if (ctrl is DropDownList)
				{
					DropDownList unit = (DropDownList)this.FindControl("DDL_UNIT_" + ID_CIF);

					unit.Items.Clear();
					unit.Items.Add(new ListItem("--Select--", ""));
						
					conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH WHERE ACTIVE='1'";
					conn.ExecuteQuery();

					for(int i = 0; i < conn.GetRowCount(); i++)
					{
						unit.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					}
				}

				else
				{
					if (ctrl.Controls.Count > 0)
					{
						FillDDLUnit(ID_CIF, ctrl);
					}
				}
			}
		}

		private void FillDDLType(string ID_CIF, Control Page)
		{
			foreach (Control ctrl in Page.Controls)
			{
				if (ctrl is DropDownList)
				{
					DropDownList type = (DropDownList)this.FindControl("DDL_SUPPORTTYPE_" + ID_CIF);

					type.Items.Clear();
					type.Items.Add(new ListItem("--Select--", ""));
						
					conn.QueryString = "SELECT OTHERS_CODE, OTHERS_DESC FROM AP_RF_OTHERS WHERE OTHERS_TYPEID='2' AND STATUS='1'";
					conn.ExecuteQuery();

					for(int i = 0; i < conn.GetRowCount(); i++)
					{
						type.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					}
				}

				else
				{
					if (ctrl.Controls.Count > 0)
					{
						FillDDLType(ID_CIF, ctrl);
					}
				}
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
			this.DGR_ANCHORTEAM.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_ANCHORTEAM_ItemCommand);
			this.DGR_ANCHORTEAM.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_ANCHORTEAM_PageIndexChanged);

		}
		#endregion

		private void BindData(DataGrid theGrid, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			System.Web.UI.WebControls.DataGrid dg = theGrid;

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

		private void DGR_ANCHORTEAM_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_ANCHORTEAM.CurrentPageIndex = e.NewPageIndex;
			FillAnchorGrid();
		}

		private void DGR_ANCHORTEAM_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					LBL_TEAMID.Text = e.Item.Cells[0].Text.Trim();
					TXT_CST_NAME.Text = e.Item.Cells[1].Text.Trim().Replace("&nbsp;","");
					TXT_TEAM_NAME.Text = e.Item.Cells[2].Text.Trim().Replace("&nbsp;","");
					DDL_WORKING_UNIT.SelectedValue = e.Item.Cells[3].Text.Trim().Replace("&nbsp;","");
					TXT_PHONE.Text = e.Item.Cells[5].Text.Trim().Replace("&nbsp;","");
					DDL_PRODUCT.SelectedValue = e.Item.Cells[6].Text.Trim().Replace("&nbsp;","");
					TXT_REMARK.Text = e.Item.Cells[8].Text.Trim().Replace("&nbsp;","");
					break;

				case "delete":
					conn.QueryString="DELETE AP_ANCHOR_CLIENT_TEAM WHERE SEQ = '" + e.Item.Cells[0].Text.Trim() + "'";
					conn.ExecuteQuery();

					FillAnchorGrid();
					break;
			}
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC AP_ANCHOR_CLIENT_TEAM_INSERT '" + LBL_TEAMID.Text + "','" + TXT_CIF.Text + "','" + TXT_CST_NAME.Text + "','" + TXT_TEAM_NAME.Text + "','" +
				DDL_WORKING_UNIT.SelectedValue + "','" + TXT_PHONE.Text + "','" + DDL_PRODUCT.SelectedValue + "','" + TXT_REMARK.Text + "'";
			conn.ExecuteQuery();

			FillAnchorGrid();
			ClearData();
		}

		private void ClearData()
		{
			TXT_CST_NAME.Text = "";
			TXT_TEAM_NAME.Text = "";
			DDL_WORKING_UNIT.SelectedValue = "";
			TXT_PHONE.Text = "";
			DDL_PRODUCT.SelectedValue = "";
			TXT_REMARK.Text = "";
		}

		private void DATA_GRID_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			string ID_CIF = "";
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;

			ID_CIF = ((DataGrid)source).ID.Remove(0,5);

			conn.QueryString = "SELECT * FROM AP_ANCHOR_COMPANY WHERE CIF='" + ID_CIF.ToString() + "'";
			BindData(((DataGrid)source), conn.QueryString);
		}

		private void DATA_GRID_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string ID_CIF = ((DataGrid)source).ID.Remove(0,5);
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					conn.QueryString = "SELECT * FROM AP_ANCHOR_COMPANY WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "'";
					fillTheField(ID_CIF ,conn.QueryString);
					break;
				case "delete":
					conn.QueryString = "DELETE AP_ANCHOR_COMPANY WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "'";
					conn.ExecuteQuery();

					conn.QueryString = "SELECT * FROM AP_ANCHOR_COMPANY WHERE CIF = '" + ID_CIF + "'";
					BindData(((DataGrid)source), conn.QueryString);
					break;
			}
		}

		private void fillTheField(string ID_CIF, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();

				string product = "DDL_PRODUCT_" + ID_CIF;
				string actionplan = "TXT_ACTIONPLAN_" + ID_CIF;
				string actionstep = "TXT_ACTIONSTEP_" + ID_CIF;
				string actiondateday = "TXT_ACTION_DD_" + ID_CIF;
				string actiondatemonth = "DDL_ACTION_MM_" + ID_CIF;
				string actiondateyear = "TXT_ACTION_YY_" + ID_CIF;
				string completiondateday = "TXT_COMPLETION_DD_" + ID_CIF;
				string completiondatemonth = "DDL_COMPLETION_MM_" + ID_CIF;
				string completiondateyear = "TXT_COMPLETION_YY_" + ID_CIF;
				string picname = "TXT_PICNAME_" + ID_CIF;
				string unit = "DDL_UNIT_" + ID_CIF;
				string supporttype = "DDL_SUPPORTTYPE_" + ID_CIF;
				string suppoortdesc = "TXT_SUPPORTDESC_" + ID_CIF;
				string remarks = "TXT_REMARK_" + ID_CIF;
				string id_seq = "LBL_ID_" + ID_CIF;

				DropDownList ddl_product = (DropDownList)this.FindControl(product);
				TextBox txt_box_actionplan = (TextBox)this.FindControl(actionplan);
				TextBox txt_box_actionstep = (TextBox)this.FindControl(actionstep);
				TextBox txt_box_actiondateday = (TextBox)this.FindControl(actiondateday);
				DropDownList ddl_actiondatemonth = (DropDownList)this.FindControl(actiondatemonth);
				TextBox txt_box_actiondateyear = (TextBox)this.FindControl(actiondateyear);
				TextBox txt_box_completiondateday = (TextBox)this.FindControl(completiondateday);
				DropDownList ddl_completiondatemonth = (DropDownList)this.FindControl(completiondatemonth);
				TextBox txt_box_completiondateyear = (TextBox)this.FindControl(completiondateyear);
				TextBox txt_box_picname = (TextBox)this.FindControl(picname);
				DropDownList ddl_unit = (DropDownList)this.FindControl(unit);
				DropDownList ddl_supporttype = (DropDownList)this.FindControl(supporttype);
				TextBox txt_box_suppoortdesc = (TextBox)this.FindControl(suppoortdesc);
				TextBox txt_box_remarks = (TextBox)this.FindControl(remarks);
				Label lbl_id_seq = (Label)this.FindControl(id_seq);

				lbl_id_seq.Text = conn.GetFieldValue("SEQ");
				ddl_product.SelectedValue = conn.GetFieldValue("PRODUCTID");
				txt_box_actionplan.Text = conn.GetFieldValue("ACTION_PLAN");
				txt_box_actionstep.Text = conn.GetFieldValue("ACTION_STEP");
				txt_box_actiondateday.Text = tools.FormatDate_Day(conn.GetFieldValue("ACTION_DATE"));
				ddl_actiondatemonth.SelectedValue = tools.FormatDate_Month(conn.GetFieldValue("ACTION_DATE"));
				txt_box_actiondateyear.Text = tools.FormatDate_Year(conn.GetFieldValue("ACTION_DATE"));
				txt_box_completiondateday.Text = tools.FormatDate_Day(conn.GetFieldValue("COMPLETION_DATE"));
				ddl_completiondatemonth.SelectedValue = tools.FormatDate_Month(conn.GetFieldValue("COMPLETION_DATE"));
				txt_box_completiondateyear.Text = tools.FormatDate_Year(conn.GetFieldValue("COMPLETION_DATE"));
				txt_box_picname.Text = conn.GetFieldValue("PIC_NAME");
				ddl_unit.SelectedValue = conn.GetFieldValue("BRANCH_CODE");
				ddl_supporttype.SelectedValue = conn.GetFieldValue("SUPPORT_TYPE");
				txt_box_suppoortdesc.Text = conn.GetFieldValue("SUPPORT_DESC");
				txt_box_remarks.Text = conn.GetFieldValue("REMARKS");

				Session["grid"] = ID_CIF;
			}
		}

		private void BTN_Click(object sender, EventArgs e)
		{
			string ID_CIF = ((Button)sender).ID.Remove(0, 9).ToString();
			string product = "DDL_PRODUCT_" + ID_CIF;
			string actionplan = "TXT_ACTIONPLAN_" + ID_CIF;
			string actionstep = "TXT_ACTIONSTEP_" + ID_CIF;
			string actiondateday = "TXT_ACTION_DD_" + ID_CIF;
			string actiondatemonth = "DDL_ACTION_MM_" + ID_CIF;
			string actiondateyear = "TXT_ACTION_YY_" + ID_CIF;
			string completiondateday = "TXT_COMPLETION_DD_" + ID_CIF;
			string completiondatemonth = "DDL_COMPLETION_MM_" + ID_CIF;
			string completiondateyear = "TXT_COMPLETION_YY_" + ID_CIF;
			string picname = "TXT_PICNAME_" + ID_CIF;
			string unit = "DDL_UNIT_" + ID_CIF;
			string supporttype = "DDL_SUPPORTTYPE_" + ID_CIF;
			string suppoortdesc = "TXT_SUPPORTDESC_" + ID_CIF;
			string remarks = "TXT_REMARK_" + ID_CIF;
			string id_seq = "LBL_ID_" + ID_CIF;

			DropDownList ddl_product = (DropDownList)this.FindControl(product);
			TextBox txt_box_actionplan = (TextBox)this.FindControl(actionplan);
			TextBox txt_box_actionstep = (TextBox)this.FindControl(actionstep);
			TextBox txt_box_actiondateday = (TextBox)this.FindControl(actiondateday);
			DropDownList ddl_actiondatemonth = (DropDownList)this.FindControl(actiondatemonth);
			TextBox txt_box_actiondateyear = (TextBox)this.FindControl(actiondateyear);
			TextBox txt_box_completiondateday = (TextBox)this.FindControl(completiondateday);
			DropDownList ddl_completiondatemonth = (DropDownList)this.FindControl(completiondatemonth);
			TextBox txt_box_completiondateyear = (TextBox)this.FindControl(completiondateyear);
			TextBox txt_box_picname = (TextBox)this.FindControl(picname);
			DropDownList ddl_unit = (DropDownList)this.FindControl(unit);
			DropDownList ddl_supporttype = (DropDownList)this.FindControl(supporttype);
			TextBox txt_box_suppoortdesc = (TextBox)this.FindControl(suppoortdesc);
			TextBox txt_box_remarks = (TextBox)this.FindControl(remarks);
			Label lbl_id_seq = (Label)this.FindControl(id_seq);

			if(Session["grid"].ToString() == ID_CIF)
			{
				if (txt_box_actiondateday.Text != "" && ddl_actiondatemonth.SelectedValue != "" && txt_box_actiondateyear.Text != "") 
				{
					if (!GlobalTools.isDateValid(txt_box_actiondateday.Text, ddl_actiondatemonth.SelectedValue, txt_box_actiondateyear.Text)) 
					{
						GlobalTools.popMessage(this, "Action Date tidak valid!");
						return;
					}
				}

				if (txt_box_completiondateday.Text != "" && ddl_completiondatemonth.SelectedValue != "" && txt_box_completiondateyear.Text != "") 
				{
					if (!GlobalTools.isDateValid(txt_box_completiondateday.Text, ddl_completiondatemonth.SelectedValue, txt_box_completiondateyear.Text)) 
					{
						GlobalTools.popMessage(this, "Completion Date tidak valid!");
						return;
					}
				}

				try
				{
					conn.QueryString = "EXEC AP_ANCHOR_COMPANY_INSERT '" + lbl_id_seq.Text + "','" + ID_CIF.ToString() + "','" + ddl_product.SelectedValue + "','" + txt_box_actionplan.Text + "','" +
						txt_box_actionstep.Text + "'," + tools.ConvertDate(txt_box_actiondateday.Text, ddl_actiondatemonth.SelectedValue, txt_box_actiondateyear.Text) + "," +
						tools.ConvertDate(txt_box_completiondateday.Text, ddl_completiondatemonth.SelectedValue, txt_box_completiondateyear.Text) + ",'" +
						txt_box_picname.Text + "','" + ddl_unit.SelectedValue + "','" + ddl_supporttype.SelectedValue + "','" + txt_box_suppoortdesc.Text + "','" + txt_box_remarks.Text + "'";
					conn.ExecuteQuery();
				}

				catch(NullReferenceException)
				{
					GlobalTools.popMessage(this, "Connection Error!");
					Response.Redirect("../Login.aspx?expire=1");
				}
			}

			else if(Session["grid"].ToString() == "")
			{
				if (txt_box_actiondateday.Text != "" && ddl_actiondatemonth.SelectedValue != "" && txt_box_actiondateyear.Text != "") 
				{
					if (!GlobalTools.isDateValid(txt_box_actiondateday.Text, ddl_actiondatemonth.SelectedValue, txt_box_actiondateyear.Text)) 
					{
						GlobalTools.popMessage(this, "Action Date tidak valid!");
						return;
					}
				}

				if (txt_box_completiondateday.Text != "" && ddl_completiondatemonth.SelectedValue != "" && txt_box_completiondateyear.Text != "") 
				{
					if (!GlobalTools.isDateValid(txt_box_completiondateday.Text, ddl_completiondatemonth.SelectedValue, txt_box_completiondateyear.Text)) 
					{
						GlobalTools.popMessage(this, "Completion Date tidak valid!");
						return;
					}
				}

				try
				{
					conn.QueryString = "EXEC AP_ANCHOR_COMPANY_INSERT '" + lbl_id_seq.Text + "','" + ID_CIF.ToString() + "','" + ddl_product.SelectedValue + "','" + txt_box_actionplan.Text + "','" +
						txt_box_actionstep.Text + "'," + tools.ConvertDate(txt_box_actiondateday.Text, ddl_actiondatemonth.SelectedValue, txt_box_actiondateyear.Text) + "," +
						tools.ConvertDate(txt_box_completiondateday.Text, ddl_completiondatemonth.SelectedValue, txt_box_completiondateyear.Text) + ",'" +
						txt_box_picname.Text + "','" + ddl_unit.SelectedValue + "','" + ddl_supporttype.SelectedValue + "','" + txt_box_suppoortdesc.Text + "','" + txt_box_remarks.Text + "'";
					conn.ExecuteQuery();
				}

				catch(NullReferenceException)
				{
					GlobalTools.popMessage(this, "Connection Error!");
					Response.Redirect("../Login.aspx?expire=1");
				}
			}

			ddl_product.SelectedValue = "";
			txt_box_actionplan.Text = "";
			txt_box_actionstep.Text = "";
			txt_box_actiondateday.Text = "";
			ddl_actiondatemonth.SelectedValue = "";
			txt_box_actiondateyear.Text = "";
			txt_box_completiondateday.Text = "";
			ddl_completiondatemonth.SelectedValue = "";
			txt_box_completiondateyear.Text = "";
			txt_box_picname.Text = "";
			ddl_unit.SelectedValue = "";
			ddl_supporttype.SelectedValue = "";
			txt_box_suppoortdesc.Text = "";
			txt_box_remarks.Text = "";
			lbl_id_seq.Text = "";

			string request_grid = "GRID_" + ID_CIF;
			DataGrid RequestGrid = (DataGrid)this.FindControl(request_grid);

			conn.QueryString = "SELECT * FROM AP_ANCHOR_COMPANY WHERE CIF='" + ID_CIF + "'";
			BindData(RequestGrid, conn.QueryString);

			Session["grid"] = "";
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../CustomerList.aspx?mc=" + Request.QueryString["mc"]);
		}
	}
}
