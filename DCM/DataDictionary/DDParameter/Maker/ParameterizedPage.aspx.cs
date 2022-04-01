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

namespace SME.DCM.DataDictionary.DDParameter.Maker
{
	/// <summary>
	/// Summary description for ParameterizedPage.
	/// </summary>
	public partial class ParameterizedPage : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection connDQA2;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			connDQA2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
			ViewMenu();

			CreateHeader("DCM070006");

			if(!IsPostBack)
			{
				Session.Add("grid", "");
			}
		}

		private void CreateHeader(string SM_IDest)
		{
			System.Web.UI.WebControls.Button BTN;
			System.Web.UI.WebControls.TextBox TXT_BOX;
			System.Web.UI.HtmlControls.HtmlTable TBL3;
			System.Web.UI.WebControls.DataGrid THE_GRID;
			LinkButtonTemplate LBT;

			connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_IDest + "' AND DESCRIPTION = 'TITLEDATAPURPOSE'";
			connDQA2.ExecuteQuery();

			string procedure = connDQA2.GetFieldValue("THEPROCEDURE");

			connDQA2.QueryString = "EXEC " + procedure  + " ''";
			connDQA2.ExecuteQuery();
			LBL_PAGENAME.Text = connDQA2.GetFieldValue("TITLEPAGE");

			System.Web.UI.HtmlControls.HtmlTableRow TR;
			System.Web.UI.HtmlControls.HtmlTableCell TD;
			System.Web.UI.WebControls.Label LBL_LABEL;

			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = connDQA2.GetFieldValue("TITLEPAGE2");

			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["class"] = "tdHeader1";
			TD.Attributes["colspan"] = "2";
			TR.Controls.Add(TD);

			TBL_maintable.Controls.Add(TR);

			/****************************** SETUP BUAT BIKIN LABEL AND TEXTBOX *******************************/

			/******************* TD UNTUK TEXTBOX AND BUTTON **********************/
			TR = new HtmlTableRow();

			//label name
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = connDQA2.GetFieldValue("TITLEPAGE3");
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["width"] = "35%";
			TD.Attributes["class"] = "TDBGColor1";
			TR.Controls.Add(TD);
			
			//label :
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = ":";
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["width"] = "1px";
			TR.Controls.Add(TD);
			
			//txt
			TD = new HtmlTableCell();
			TXT_BOX = new TextBox();
			TXT_BOX.Width = 300;
			TXT_BOX.ID = "TXT_CODE_" + SM_IDest;
			TD.Controls.Add(TXT_BOX);
			TR.Controls.Add(TD);

			TBL3 = new HtmlTable();
			TBL3.Controls.Add(TR);

			TD = new HtmlTableCell();
			TD.Controls.Add(TBL3);
			TD.Attributes["colspan"] = "4";
			TR = new HtmlTableRow();
			TR.Controls.Add(TD);

			TBL_maintable.Controls.Add(TR);

			/**********************************************************************************************/

			/******************* TD UNTUK TEXTBOX AND BUTTON **********************/
			TR = new HtmlTableRow();

			//label name
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = connDQA2.GetFieldValue("TITLEPAGE4");
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["width"] = "35%";
			TD.Attributes["class"] = "TDBGColor1";
			TR.Controls.Add(TD);
			
			//label :
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = ":";
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["width"] = "1px";
			TR.Controls.Add(TD);
			
			//txt
			TD = new HtmlTableCell();
			TXT_BOX = new TextBox();
			TXT_BOX.Width = 300;
			TXT_BOX.ID = "TXT_DESCRIPTION_" + SM_IDest;
			TD.Controls.Add(TXT_BOX);
			TR.Controls.Add(TD);

			TBL3 = new HtmlTable();
			TBL3.Controls.Add(TR);

			TD = new HtmlTableCell();
			TD.Controls.Add(TBL3);
			TD.Attributes["colspan"] = "4";
			TR = new HtmlTableRow();
			TR.Controls.Add(TD);

			TBL_maintable.Controls.Add(TR);

			/**********************************************************************************************/

			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			TD.Attributes["class"] = "TDBGColor2";
			TD.Attributes["align"] = "center";
			TD.Attributes["width"] = "100%";
			TD.Attributes["colSpan"] = "2";
			BTN = new Button();
			BTN.Attributes["class"] = "button1";
			BTN.Text = "   SAVE   ";
			BTN.ID = "BTN_SAVE_" + SM_IDest;
			// EVENT UNTUK SAVE
			BTN.Click += new EventHandler(BTN_Click);
			TD.Controls.Add(BTN);
			BTN = new Button();
			BTN.Attributes["class"] = "button1";
			BTN.Text = "   CLEAR   ";
			// EVENT UNTUK CLEAR
			BTN.ID = "BTN_CLEAR_" + SM_IDest;
			BTN.Click += new EventHandler(BTN_Click2);
			TD.Controls.Add(BTN);
			TR.Controls.Add(TD);

			TBL_maintable.Controls.Add(TR);

			/************************************************************************************************/

			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			TR.Controls.Add(TD);
			TBL_maintable.Controls.Add(TR);

			/************************************************************************************************/

			connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_IDest + "' AND DESCRIPTION = 'TITLEDATAPURPOSE'";
			connDQA2.ExecuteQuery();

			procedure = connDQA2.GetFieldValue("THEPROCEDURE");

			connDQA2.QueryString = "EXEC " + procedure  + " ''";
			connDQA2.ExecuteQuery();

			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			//LBL_LABEL.Text = "DATA HISTORICAL TRANSACTION";
			LBL_LABEL.Text = connDQA2.GetFieldValue("TITLEPAGE5");

			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["class"] = "tdHeader1";
			TD.Attributes["colspan"] = "2";
			TR.Controls.Add(TD);

			TBL_maintable.Controls.Add(TR);

			/************************************************************************************************/
			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			TD.Attributes["colspan"] = "2";

			THE_GRID = new DataGrid();
			THE_GRID.ID = "GRID_EXISTING_PARAMETER_" + SM_IDest;
			THE_GRID.AllowPaging = true;
			THE_GRID.CellPadding = 1;
			THE_GRID.AutoGenerateColumns = false;
			THE_GRID.Width = Unit.Percentage(100.0);
			THE_GRID.AlternatingItemStyle.CssClass = "TblAlternating";
			THE_GRID.PagerStyle.Mode = PagerMode.NumericPages;
			THE_GRID.ItemCommand += new DataGridCommandEventHandler(THE_GRID_ItemCommand);

			BoundColumn columns = new BoundColumn();
			columns.HeaderText = "Code";
			columns.DataField = "CODE";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(20.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Description";
			columns.DataField = "DESCRIPTIONS";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(50.0);
			THE_GRID.Columns.Add(columns);

			TemplateColumn columnsz = new TemplateColumn();
			columnsz.HeaderText = "Function";
			columnsz.HeaderStyle.CssClass = "tdSmallHeader";
			columnsz.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columnsz.ItemStyle.Width = Unit.Percentage(30.0);
			LBT = new LinkButtonTemplate("LBT_" + SM_IDest);
			columnsz.ItemTemplate = LBT;
			THE_GRID.Columns.Add(columnsz);

			connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_IDest + "' AND DESCRIPTION = 'BINDGRIDDDPARAPPMKRPARAMPAGE'";
			connDQA2.ExecuteQuery();
			procedure = connDQA2.GetFieldValue("THEPROCEDURE");
			BindData(THE_GRID, "EXEC " + procedure + " ''");

			TD.Controls.Add(THE_GRID);
			THE_GRID.PageIndexChanged += new DataGridPageChangedEventHandler(THE_GRID_PageIndexChanged);
			TR.Controls.Add(TD);

			TBL_maintable.Controls.Add(TR);

			/************************************************************************************************/
			connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_IDest + "' AND DESCRIPTION = 'TITLEDATAPURPOSE'";
			connDQA2.ExecuteQuery();
			procedure = connDQA2.GetFieldValue("THEPROCEDURE");
			connDQA2.QueryString = "EXEC " + procedure  + " ''";
			connDQA2.ExecuteQuery();

			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();

			try
			{
				LBL_LABEL.Text = connDQA2.GetFieldValue("TITLEPAGE6");
			}
			catch(Exception o)
			{
				string hjghg = o.Message.ToString();
				string tyuty = o.Message.ToString();
			}

			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["class"] = "tdHeader1";
			TD.Attributes["colspan"] = "2";
			TR.Controls.Add(TD);

			TBL_maintable.Controls.Add(TR);
			/************************************************************************************************/

			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			TD.Attributes["colspan"] = "2";

			THE_GRID = new DataGrid();
			THE_GRID.ID = "GRID_REQUEST_PARAMETER_" + SM_IDest;
			THE_GRID.AllowPaging = true;
			THE_GRID.CellPadding = 1;
			THE_GRID.AutoGenerateColumns = false;
			THE_GRID.Width = Unit.Percentage(100.0);
			THE_GRID.AlternatingItemStyle.CssClass = "TblAlternating";
			THE_GRID.PagerStyle.Mode = PagerMode.NumericPages;
			THE_GRID.ItemCommand += new DataGridCommandEventHandler(THE_GRID_ItemCommand2);

			columns = new BoundColumn();
			columns.HeaderText = "Code";
			columns.DataField = "CODE";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(20.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Description";
			columns.DataField = "DESCRIPTIONS";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(50.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Pending Status";
			columns.DataField = "PENDINGSTATUS";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(15.0);
			THE_GRID.Columns.Add(columns);

			columnsz = new TemplateColumn();
			columnsz.HeaderText = "Function";
			columnsz.HeaderStyle.CssClass = "tdSmallHeader";
			columnsz.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columnsz.ItemStyle.Width = Unit.Percentage(15.0);
			LBT = new LinkButtonTemplate("LBT_" + SM_IDest);
			columnsz.ItemTemplate = LBT;
			THE_GRID.Columns.Add(columnsz);

			connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_IDest + "' AND DESCRIPTION = 'BINDGRIDREQUESTPARAMDATAPURPOSE'";
			connDQA2.ExecuteQuery();
			procedure = connDQA2.GetFieldValue("THEPROCEDURE");
			BindData(THE_GRID, "EXEC " + procedure + " ''");

			TD.Controls.Add(THE_GRID);
			THE_GRID.PageIndexChanged += new DataGridPageChangedEventHandler(THE_GRID_PageIndexChanged2);
			TR.Controls.Add(TD);

			TBL_maintable.Controls.Add(TR);
		}

		private void BTN_Click(object sender, EventArgs e)
		{
			string SM_ID = ((Button)sender).ID.Remove(0, 9).ToString();
			string txtcode = "TXT_CODE_" + SM_ID;
			string txtdescription = "TXT_DESCRIPTION_" + SM_ID;
			string THEPROCEDURE = "";
			TextBox txt_box_code = (TextBox)this.FindControl(txtcode);
			TextBox txt_box_description = (TextBox)this.FindControl(txtdescription);

			if(Session["grid"].ToString() == "REQUESTED")
			{
				//disini update tabel requested
				string DESCRIPTION = "DCM_DataDictionary_DDParameter_Maker_ParameterizedPage.aspx_SAVE_PARAMETER_REQUESTED";

				connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_ID + "' AND DESCRIPTION = '" + DESCRIPTION + "'";
				connDQA2.ExecuteQuery();

				THEPROCEDURE = connDQA2.GetFieldValue("THEPROCEDURE");

				connDQA2.QueryString = "EXEC " + THEPROCEDURE + " '" + txt_box_code.Text.ToString() + "','" + txt_box_description.Text.ToString() + "'";
				connDQA2.ExecuteQuery();

				Tools.popMessage(this, "Request updated !");
			}
			else if(Session["grid"].ToString() == "EXISTING")
			{
				string DESCRIPTION = "DCM_DataDictionary_DDParameter_Maker_ParameterizedPage.aspx_SAVE_PARAMETER";

				connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_ID + "' AND DESCRIPTION = '" + DESCRIPTION + "'";
				connDQA2.ExecuteQuery();

				THEPROCEDURE = connDQA2.GetFieldValue("THEPROCEDURE");

				connDQA2.QueryString = "EXEC " + THEPROCEDURE + " '" + txt_box_code.Text.ToString() + "','" + txt_box_description.Text.ToString() + "'";
				connDQA2.ExecuteQuery();

				Tools.popMessage(this, "Request send to Pending !");
			}
			else
			{
				string DESCRIPTION = "DCM_DataDictionary_DDParameter_Maker_ParameterizedPage.aspx_SAVE_PARAMETER_NEW";

				connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_ID + "' AND DESCRIPTION = '" + DESCRIPTION + "'";
				connDQA2.ExecuteQuery();

				THEPROCEDURE = connDQA2.GetFieldValue("THEPROCEDURE");

				connDQA2.QueryString = "EXEC " + THEPROCEDURE + " '" + txt_box_code.Text.ToString() + "','" + txt_box_description.Text.ToString() + "'";
				connDQA2.ExecuteQuery();

				Tools.popMessage(this, "Send to Pending !");
			}

			txt_box_code.Text = "";
			txt_box_description.Text = "";

			connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_ID + "' AND DESCRIPTION = 'DCM_2012_DDPARAMETER_DATAPURPOSE_REQUESTPARAMETER'";
			connDQA2.ExecuteQuery();

			string REQUEST_GRID = "GRID_REQUEST_PARAMETER_" + SM_ID;
			DataGrid RequestGrid = (DataGrid)this.FindControl(REQUEST_GRID);

			THEPROCEDURE = connDQA2.GetFieldValue("THEPROCEDURE");
			string USERID = "";
			BindData(RequestGrid, "EXEC " + THEPROCEDURE + " '" + USERID + "'");

			Session["grid"] = "";
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
				lb.ID = "LNK_EDIT_REQ_" + id;
				lb.Text = "Edit";
				lb.CommandName = "edit_req";
				container.Controls.Add(lb);

				Label lbl = new Label();
				lbl.Text = "    ";
				container.Controls.Add(lbl);

				lb = new LinkButton();
				lb.ID = "LNK_DELETE_REQ" + id;
				lb.Text = "Delete";
				lb.CommandName = "delete_req";
				container.Controls.Add(lb);
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

		}
		#endregion

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select SM_ID,MENUCODE,SM_MENUDISPLAY,SM_LINKNAME from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
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
						{
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						}
						else
						{	
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						}
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;

					if(conn.GetFieldValue(i, 3).EndsWith(this.Page.ToString().Replace("ASP.","").Replace("_aspx",".aspx")))
					{
						//SM_ID = conn.GetFieldValue(i, 0);
					}

					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void BindData(DataGrid theGrid, string strconn)
		{
			if(strconn != "")
			{
				connDQA2.QueryString = strconn;
				connDQA2.ExecuteQuery();
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = connDQA2.GetDataTable().Copy();

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
			
			if(!IsPostBack)
			{

			}
			connDQA2.ClearData();
		}

		private void THE_GRID_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			string SM_ID = "";
			string DESCRIPTION = "";
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;

			SM_ID = ((DataGrid)source).ID.Remove(0,24);
			DESCRIPTION = "BINDGRIDDDPARAPPMKRPARAMPAGE";

			connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_ID + "' AND DESCRIPTION = '" + DESCRIPTION + "'";
			connDQA2.ExecuteQuery();

			conn.QueryString = "EXEC " + connDQA2.GetFieldValue("THEPROCEDURE") + " ''";
			
			BindData(((DataGrid)source), conn.QueryString);
		}

		private void THE_GRID_PageIndexChanged2(object source, DataGridPageChangedEventArgs e)
		{
			string SM_ID = "";
			string DESCRIPTION = "";
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;

			SM_ID = ((DataGrid)source).ID.Remove(0,23);
			DESCRIPTION = "BINDGRIDREQUESTPARAMDATAPURPOSE";

			connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_ID + "' AND DESCRIPTION = '" + DESCRIPTION + "'";
			connDQA2.ExecuteQuery();

			conn.QueryString = "EXEC " + connDQA2.GetFieldValue("THEPROCEDURE") + " ''";
			
			BindData(((DataGrid)source), conn.QueryString);
		}

		private void THE_GRID_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string DESCRIPTION = "";
			string THEPROCEDURE = "";
			string SM_ID = ((DataGrid)source).ID.Remove(0,24);
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "edit_req":
					DESCRIPTION = "DCM_DataDictionary_DDParameter_Maker_ParameterizedPage.aspx_THE_GRID_ItemCommand_edit_req";
					connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_ID + "' AND DESCRIPTION = '" + DESCRIPTION + "'";
					connDQA2.ExecuteQuery();

					THEPROCEDURE = connDQA2.GetFieldValue("THEPROCEDURE");

					connDQA2.QueryString = "EXEC " + THEPROCEDURE + " '" + e.Item.Cells[0].Text.ToString() + "'";
					connDQA2.ExecuteQuery();
					fillTheField(SM_ID, connDQA2.GetFieldValue("CODE"), connDQA2.GetFieldValue("DESCRIPTIONS"), "EXISTING");
					break;
				case "delete_req":
					DESCRIPTION = "DCM_DataDictionary_DDParameter_Maker_ParameterizedPage.aspx_THE_GRID_ItemCommand_delete_req";
					connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_ID + "' AND DESCRIPTION = '" + DESCRIPTION + "'";
					connDQA2.ExecuteQuery();

					THEPROCEDURE = connDQA2.GetFieldValue("THEPROCEDURE");

					connDQA2.QueryString = "EXEC " + THEPROCEDURE + " '" + e.Item.Cells[0].Text.ToString() + "'";
					connDQA2.ExecuteQuery();
					//bind the data grid to request pending
					Tools.popMessage(this, "Request send to Pending !");

					connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_ID + "' AND DESCRIPTION = 'DCM_2012_DDPARAMETER_DATAPURPOSE_REQUESTPARAMETER'";
					connDQA2.ExecuteQuery();

					THEPROCEDURE = connDQA2.GetFieldValue("THEPROCEDURE");
					string USERID = "";
					BindData((DataGrid)source, "EXEC " + THEPROCEDURE + " '" + USERID + "'");
					break;
			}
		}

		private void fillTheField(string SM_ID, string CODE, string DESCRIPTIONS, string SOURCE)
		{
			string txtcode = "TXT_CODE_" + SM_ID;
			string txtdescription = "TXT_DESCRIPTION_" + SM_ID;
			string THEPROCEDURE = "";

			TextBox txt_box_code = (TextBox)this.FindControl(txtcode);
			TextBox txt_box_description = (TextBox)this.FindControl(txtdescription);

			txt_box_code.Text = CODE;
			txt_box_description.Text = DESCRIPTIONS;

			Session["grid"] = SOURCE;
		}

		private void THE_GRID_ItemCommand2(object source, DataGridCommandEventArgs e)
		{
			string DESCRIPTION = "";
			string THEPROCEDURE = "";
			string SM_ID = ((DataGrid)source).ID.Remove(0,23);
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "edit_req":
					DESCRIPTION = "DCM_DataDictionary_DDParameter_Maker_ParameterizedPage.aspx_THE_GRID_ItemCommand_edit_req";
					connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_ID + "' AND DESCRIPTION = '" + DESCRIPTION + "'";
					connDQA2.ExecuteQuery();

					THEPROCEDURE = connDQA2.GetFieldValue("THEPROCEDURE");

					connDQA2.QueryString = "EXEC " + THEPROCEDURE + " '" + e.Item.Cells[0].Text.ToString() + "'";
					connDQA2.ExecuteQuery();
					//fill the field;

					fillTheField(SM_ID, e.Item.Cells[0].Text.ToString(), e.Item.Cells[1].Text.ToString(), "REQUESTED");
					break;
				case "delete_req":
					DESCRIPTION = "DCM_DataDictionary_DDParameter_Maker_ParameterizedPage.aspx_THE_GRID_ItemCommand_delete_req";
					connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_ID + "' AND DESCRIPTION = '" + DESCRIPTION + "'";
					connDQA2.ExecuteQuery();

					THEPROCEDURE = connDQA2.GetFieldValue("THEPROCEDURE");

					connDQA2.QueryString = "EXEC " + THEPROCEDURE + " '" + e.Item.Cells[0].Text.ToString() + "'";
					connDQA2.ExecuteQuery();
					//bind the data grid
					Tools.popMessage(this, "The Requested Data has been deleted !");
					connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_ID + "' AND DESCRIPTION = 'BINDGRIDREQUESTPARAMDATAPURPOSE'";
					connDQA2.ExecuteQuery();
					THEPROCEDURE = connDQA2.GetFieldValue("THEPROCEDURE");
					BindData((DataGrid)source, "EXEC " + THEPROCEDURE + " ''");
					break;
			}
		}

		private void BTN_Click2(object sender, EventArgs e)
		{
			//BTN_CLEAR_
			string SM_ID = ((Button)sender).ID.Remove(0, 10).ToString();
			string txtcode = "TXT_CODE_" + SM_ID;
			string txtdescription = "TXT_DESCRIPTION_" + SM_ID;
			TextBox txt_box_code = (TextBox)this.FindControl(txtcode);
			TextBox txt_box_description = (TextBox)this.FindControl(txtdescription);

			txt_box_code.Text = "";
			txt_box_description.Text = "";
		}
	}
}
