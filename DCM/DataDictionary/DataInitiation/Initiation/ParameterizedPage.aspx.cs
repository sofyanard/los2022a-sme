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

namespace SME.DCM.DataDictionary.DataInitiation.Initiation
{
	/// <summary>
	/// Summary description for DataCIFIn.
	/// </summary>
	public partial class ParameterizedPage : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);

		private string SM_ID = "";
		private string message = "";

		protected Connection connDQA;
		protected Connection connDQA2;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			connDQA = new Connection(ConfigurationSettings.AppSettings["conn2"]);
			connDQA2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
			ViewMenu();

			generateAllComponent();
			if(!IsPostBack)
			{
				/*string sdfsdtsgdf = "";*/

			}
			else
			{
				//disini harus diset !
				//cek all grid and bound all check box !
				/*DataGrid THE_GRID;
				string QueryString = "";

				
				THE_GRID = Session["CB_array_" + THE_GRID.ID];
				QueryString = Session["BIND_PROCEDURE_" + THE_GRID.ID];*/
				//GridConstructor(this);
			}

		}

		private void GridConstructor(Control Page)
		{
			string QueryString = "";
			DataGrid THE_GRID;
			foreach (Control ctrl in Page.Controls)
			{
				if (ctrl is DataGrid)
				{
					QueryString = (string)Session["BIND_PROCEDURE_" + ctrl.ID];
					THE_GRID = (DataGrid)ctrl;
					string opopo = THE_GRID.ID.ToString();
					string yukyuk = QueryString.ToString();
					BindData(THE_GRID, QueryString);
					SettingCheckBox(THE_GRID, THE_GRID.ID.Remove(0, 5));
				}
				else
				{
					if (ctrl.Controls.Count > 0)
					{
						GridConstructor(ctrl);
					}
				}
			}
		}

		private void generateAllComponent()
		{
			int jenisdata;

			/*connDQA.QueryString = "SELECT ID_JENIS_DATA DCM_2012_STRUKTURDATA WHERE SM_ID = '" + SM_ID + "'";
			connDQA.ExecuteQuery();

			jenisdata = conn.GetFieldValue(0, 0);

			connDQA.QueryString = "SELECT SM_ID DCM_2012_STRUKTURDATA WHERE PARENT = '" + jenisdata + "'";
			connDQA.ExecuteQuery();

			//Ambil semua SM_ID dan Generate Page
			for(int i=0; i<connDQA.GetRowCount; i++)
			{
				CreatePage(connDQA.GetFieldValue(i, 1).ToString());
			}*/

			CreatePage();
		}

		private void CreatePage()
		{
			SM_ID = "DCM070005";
			CreateHeader(SM_ID);

			connDQA.QueryString = "SELECT SM_ID FROM DCM_2012_STRUKTURDATA WHERE PARENT = 0";
			connDQA.ExecuteQuery();

			try
			{
				for(int i=0; i<connDQA.GetRowCount(); i++)
				{
					ConstructDOM(connDQA.GetFieldValue(i, "SM_ID"));
				}
			}
			catch(Exception o)
			{
				string abc = o.Message.ToString();
				string def = o.Message.ToString();
			}
		}

		private void CreateHeader(string SM_IDest)
		{
			connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_IDest + "' AND DESCRIPTION = 'TITLE'";
			connDQA2.ExecuteQuery();

			string procedure = connDQA2.GetFieldValue("THEPROCEDURE");

			connDQA2.QueryString = "EXEC " + procedure  + " ''";
			connDQA2.ExecuteQuery();

			LBL_PAGENAME.Text = connDQA2.GetFieldValue("TITLEPAGE");
			//LBL_PAGENAME.Text = "DATA TRANSACTION REQUEST";

			System.Web.UI.HtmlControls.HtmlTableRow TR;
			System.Web.UI.HtmlControls.HtmlTableCell TD;
			System.Web.UI.WebControls.Label LBL_LABEL;

			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			//LBL_LABEL.Text = "DATA HISTORICAL TRANSACTION";
			LBL_LABEL.Text = connDQA2.GetFieldValue("TITLEPAGE2");

			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["class"] = "tdHeader1";
			TD.Attributes["colspan"] = "2";
			TR.Controls.Add(TD);
			TBL_maintable.Controls.Add(TR);
		}

		private void ConstructDOM(string SM_ID)
		{
			#region NON-SESSION
			System.Web.UI.HtmlControls.HtmlTable TBL;
			System.Web.UI.HtmlControls.HtmlTable TBL3;
			System.Web.UI.HtmlControls.HtmlTableRow TR;
			System.Web.UI.HtmlControls.HtmlTableRow TRUtama;
			System.Web.UI.HtmlControls.HtmlTableCell TD;
			System.Web.UI.WebControls.CheckBox CB;
			System.Web.UI.WebControls.RadioButton RB;
			System.Web.UI.WebControls.Button BTN;
			System.Web.UI.WebControls.TextBox TXT_BOX;
			System.Web.UI.WebControls.Label LBL_LABEL;
			System.Web.UI.WebControls.DataGrid THE_GRID;
			CheckBoxTemplate CBT;

			/******************************* GOOD GAP *****************************/
			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			TR.Controls.Add(TD);
			TBL_maintable.Controls.Add(TR);

			/******************* TD UNTUK TEXTBOX AND BUTTON **********************/
			TR = new HtmlTableRow();

			//label name
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = "Field Name";
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["width"] = "25%";
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
			TXT_BOX.Width = 250;
			TXT_BOX.ID = "TXT_FIELD_NAME_" + SM_ID;
			TD.Controls.Add(TXT_BOX);
			TD.Attributes["width"] = "55%";
			TR.Controls.Add(TD);

			//btn
			TD = new HtmlTableCell();
			BTN = new Button();
			BTN.Attributes["class"] = "button1";
			BTN.Text = "   FIND   ";
			BTN.ID = "BTN_SEARCHBYFIELD_NAME_" + SM_ID;
			BTN.Click += new EventHandler(BTN_Click);
			TD.Controls.Add(BTN);
			TR.Controls.Add(TD);
			TR.Visible = false;

			TBL3 = new HtmlTable();
			TBL3.Controls.Add(TR);

			TD = new HtmlTableCell();
			TD.Controls.Add(TBL3);
			TR = new HtmlTableRow();
			TR.Controls.Add(TD);

			TBL = new HtmlTable();
			TBL.Controls.Add(TR);

			TRUtama = new HtmlTableRow();
			TD = new HtmlTableCell();
			TD.Controls.Add(TBL);
			TD.Attributes["width"] = "50%";
			TRUtama.Controls.Add(TD);
			TRUtama.Visible = false;
			TBL_maintable.Controls.Add(TRUtama);

			/******************* TD UNTUK TEXTBOX AND BUTTON **********************/
			TR = new HtmlTableRow();

			//label name
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = "Description";
			TD.Controls.Add(LBL_LABEL);
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
			TXT_BOX.Width = 250;
			TXT_BOX.ID = "TXT_DESCRIPTION_" + SM_ID;
			TD.Controls.Add(TXT_BOX);
			TR.Controls.Add(TD);

			//btn
			TD = new HtmlTableCell();
			BTN = new Button();
			BTN.Attributes["class"] = "button1";
			BTN.Text = "   FIND   ";
			BTN.ID = "BTN_SEARCHBY_DESCRIPTION_" + SM_ID;
			BTN.Click += new EventHandler(BTN_Click);
			TD.Controls.Add(BTN);
			TR.Controls.Add(TD);
			TR.Visible = false;

			TBL3 = new HtmlTable();
			TBL3.Controls.Add(TR);

			TD = new HtmlTableCell();
			TD.Controls.Add(TBL3);
			TR = new HtmlTableRow();
			TR.Controls.Add(TD);

			TBL = new HtmlTable();
			TBL.Controls.Add(TR);

			TD = new HtmlTableCell();
			TD.Controls.Add(TBL);
			TD.Attributes["width"] = "50%";
			TRUtama.Controls.Add(TD);
			TRUtama.Attributes["width"] = "100%";
			TRUtama.Visible = false;
			TBL_maintable.Controls.Add(TRUtama);

			/************************* UNTUK CHECKBOXNYA ***********************/
			CB = new CheckBox();
			
			connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_ID + "' AND DESCRIPTION = 'CHECKBOXTITLE'";
			connDQA2.ExecuteQuery();

			string procedure = connDQA2.GetFieldValue("THEPROCEDURE");

			connDQA2.QueryString = "EXEC " + procedure  + " '" + SM_ID + "'";
			connDQA2.ExecuteQuery();

			CB.Text = connDQA2.GetFieldValue("CBTITLE");
			CB.ID = "CB_" + SM_ID;

			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			TD.Attributes["colspan"] = "2";

			TD.Controls.Add(CB);
			TR.Controls.Add(TD);
			TBL_maintable.Controls.Add(TR);

			/************************** UNTUK GRIDNYA************************/
			TRUtama = new HtmlTableRow();
			TD = new HtmlTableCell();

			THE_GRID = new DataGrid();
			THE_GRID.ID = "GRID_" + SM_ID;
			THE_GRID.AllowPaging = true;
			THE_GRID.CellPadding = 1;
			THE_GRID.AutoGenerateColumns = false;
			THE_GRID.Width = Unit.Percentage(1.0);
			THE_GRID.AlternatingItemStyle.CssClass = "TblAlternating";
			THE_GRID.PagerStyle.Mode = PagerMode.NumericPages;

			BoundColumn columns = new BoundColumn();
			columns.HeaderText = "NO";
			columns.DataField = "NUMBER";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(5);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "FIELDS NAME";
			columns.DataField = "FIELDS_NAME";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(30.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "DESCRIPTION";
			columns.DataField = "DESCRIPTIONS";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(50.0);
			THE_GRID.Columns.Add(columns);

			TemplateColumn columnsz = new TemplateColumn();
			columnsz.HeaderText = "CHECK FOR SELECT";
			columnsz.HeaderStyle.CssClass = "tdSmallHeader";
			columnsz.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columnsz.ItemStyle.Width = Unit.Percentage(15.0);
			CBT = new CheckBoxTemplate("CBT_" + SM_ID);
			columnsz.ItemTemplate = CBT;
			THE_GRID.Columns.Add(columnsz);

			THE_GRID.Width = Unit.Percentage(100.0);
			TD.Controls.Add(THE_GRID);
			TD.Attributes["colspan"] = "2";
			TD.Attributes["width"] = "100%";
			TRUtama.Controls.Add(TD);
			TBL_maintable.Controls.Add(TRUtama);

			connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_ID + "' AND DESCRIPTION = 'BINDTABLE'";
			connDQA2.ExecuteQuery();

			procedure = connDQA2.GetFieldValue("THEPROCEDURE");
			#endregion

			/**********************************************  GRID SESSION ******************************************/
			if(!IsPostBack)
			{
				Session.Add("GRID_" + THE_GRID.ID, THE_GRID);
			}
			/***************************************************************************************************/

			BindData(THE_GRID, "EXEC " + procedure + " ''");

			/**********************************************  BIND SESSION ******************************************/
			if(!IsPostBack)
			{
				Session.Add("BIND_PROCEDURE_" + THE_GRID.ID, "EXEC " + procedure + " ''");
			}
			/***************************************************************************************************/

			#region NONSESSION2
			try
			{
				SettingCheckBox(THE_GRID, SM_ID);
			}
			catch(Exception o)
			{
				string sdfsdf = o.Message.ToString();
				string tytytyt = o.Message.ToString();
			}
			THE_GRID.PageIndexChanged += new DataGridPageChangedEventHandler(THE_GRID_PageIndexChanged);

			/************************** UNTUK BUTTON BELOW ************************/
			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			BTN = new Button();
			BTN.Attributes["class"] = "button1";
			BTN.ID = "BTN_SAVE_" + SM_ID;
			BTN.Text = "    SAVE    ";

			TD.Controls.Add(BTN);
			TD.Attributes["class"] = "tdHeader1";
			TD.Attributes["colspan"] = "2";
			TR.Controls.Add(TD);
			TBL_maintable.Controls.Add(TR);
			#endregion
		}

		private void BindData(DataGrid theGrid, string strconn)
		{
			if(strconn != "")
			{
				try
				{
					connDQA2.QueryString = strconn;
					connDQA2.ExecuteQuery();
				}
				catch(Exception o)
				{
					string yhyh = o.Message.ToString();
					string dhdh = o.Message.ToString();
				}
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
				if(Session["CB_array_" + theGrid.ID] == null)
				{
					createSession(theGrid, strconn);
				}
			}
			connDQA2.ClearData();
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
						SM_ID = conn.GetFieldValue(i, 0);
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

		private void BTN_Save_Click(object sender, EventArgs e)
		{

		}

		private void BTN_Click(object sender, EventArgs e)
		{
			string SMID = "";
			string JENISBUTTON = "";
			//"BTN_SEARCHBYFIELD_NAME_" + SM_ID
			//"TXT_FIELD_NAME_" + SM_ID

			//"BTN_SEARCHBY_DESCRIPTION_" + SM_ID
			//"TXT_DESCRIPTION_" + SM_ID

			

			if(((Button)sender).ID.ToString().StartsWith("BTN_SEARCHBYFIELD_NAME_"))
			{
				SMID = ((Button)sender).ID.ToString().Remove(0, 23).ToString();
				connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SMID + "' AND DESCRIPTION = 'BINDBYFIELDNAME'";
				connDQA2.ExecuteQuery();

				string procedure = connDQA2.GetFieldValue("THEPROCEDURE");
				connDQA2.QueryString = "EXEC " + procedure  + " '" + ((TextBox)this.FindControl("TXT_FIELD_NAME_" + SMID)).Text.ToString() + "'";
			}
			else if(((Button)sender).ID.ToString().StartsWith("BTN_SEARCHBY_DESCRIPTION_"))
			{
				SMID = ((Button)sender).ID.ToString().Remove(0, 25).ToString();
				connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SMID + "' AND DESCRIPTION = 'BINDBYDESCRIPTION'";
				connDQA2.ExecuteQuery();

				string procedure = connDQA2.GetFieldValue("THEPROCEDURE");
				connDQA2.QueryString = "EXEC " + procedure  + " '" + ((TextBox)this.FindControl("TXT_DESCRIPTION_" + SMID)).Text.ToString() + "'";
			}

			DataGrid THE_GRID = (DataGrid)this.FindControl("GRID_" + SMID);
			BindData(THE_GRID, connDQA2.QueryString);

			//Session.Add("GRID_" + THE_GRID.ID, THE_GRID);
			//Session.Add("BIND_PROCEDURE_" + THE_GRID.ID, "EXEC " + procedure + " ''");

			//bool []checkedbox2 = (bool [])Session["CB_array_" + theGrid.ID];
			Session["CB_array_" + THE_GRID.ID] = THE_GRID;
			Session["BIND_PROCEDURE_" + THE_GRID.ID] = connDQA2.QueryString;
		}


		private class CheckBoxTemplate : ITemplate
		{
			string id = "";
			public CheckBoxTemplate(string id)
			{
				this.id = id;
			}

			public void InstantiateIn(System.Web.UI.Control container)
			{    
				CheckBox cb = new CheckBox();
				cb.ID = id;
				cb.AutoPostBack = true;
				container.Controls.Add(cb);
			}
		}

		private void createSession(DataGrid theGrid, string strconn)
		{
			connDQA2.QueryString = strconn;
			connDQA2.ExecuteQuery();
			bool []checkedbox = new bool[connDQA2.GetRowCount()];
			Session.Add("CB_array_" + theGrid.ID, checkedbox);
		}

		private void SettingCheckBox(DataGrid theGrid, string SM_ID)
		{
			for(int i=0; i< theGrid.Items.Count; i++)
			{
				//CheckBox cb = (CheckBox)theGrid.Items[i].Cells[3].FindControl("CB_" + SM_ID);
				CheckBox cb = (CheckBox)theGrid.Items[i].Cells[3].FindControl("CBT_" + SM_ID);
				bool asas = cb.Checked;
				cb.CheckedChanged += new EventHandler(cb_CheckedChanged);
			}
		}

		private void cb_CheckedChanged(object sender, EventArgs e)
		{
			string SM_ID = ((CheckBox)sender).ID;
			SM_ID = SM_ID.Remove(0,4);
			DataGrid theGrid = (DataGrid)this.FindControl("GRID_" + SM_ID);
			//DataGrid theGrid = ((CheckBox)sender).Parent.ID;
			insertArray(theGrid, SM_ID);
			//string ghgfh = ((CheckBox)sender).Parent.ID;
		}

		private void insertArray(DataGrid theGrid, string SM_ID)
		{
			bool []checkedbox2 = (bool [])Session["CB_array_" + theGrid.ID];

			for(int i=0; i< theGrid.Items.Count; i++)
			{
				//dgListChan.Items[i].Cells[0].Text.ToString()
				try
				{
					CheckBox cb = (CheckBox)theGrid.Items[i].Cells[3].FindControl("CBT_" + SM_ID);
					if(cb.Checked)
					{
						//ambilnumbernya
						//checkedbox[int.Parse(DGR_INQUIRY.Items[i].Cells[0].Text.ToString())] = true;
						int a = int.Parse(theGrid.Items[i].Cells[0].Text.ToString());
						try
						{
							checkedbox2[a-1] = true;

						}
						catch(Exception M)
						{
							string b = M.Message.ToString();
							string c = M.Message.ToString();
						}
					}
					else
					{
						//checkedbox[int.Parse(DGR_INQUIRY.Items[i].Cells[0].Text.ToString())] = false;
						int a = int.Parse(theGrid.Items[i].Cells[0].Text.ToString());
						try
						{
							checkedbox2[a-1] = false;
						}
						catch(Exception M)
						{
							string b = M.Message.ToString();
							string c = M.Message.ToString();
						}
					}
				}
				catch (Exception o)
				{
					string ryty = o.Message.ToString();
					string ryty2 = o.Message.ToString();
				}
			}
			Session["CB_array_" + theGrid.ID] = checkedbox2;
		}

		private void retrieveArray(DataGrid theGrid)
		{
			bool []checkedbox2 = (bool [])Session["CB_array_" + theGrid.ID];
			string SM_ID = theGrid.ID;
			SM_ID = SM_ID.Remove(0,5);

			for(int i=0; i< theGrid.Items.Count; i++)
			{
				int a = int.Parse(theGrid.Items[i].Cells[0].Text.ToString());
				CheckBox cb = (CheckBox)theGrid.Items[i].Cells[3].FindControl("CBT_" + SM_ID);

				cb.Checked = checkedbox2[a-1];
			}
			Session["CB_array_" + theGrid.ID] = checkedbox2;
	 	}
 
		private void THE_GRID_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;
			string SM_ID = ((DataGrid)source).ID.Remove(0,5);
			connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_ID + "' AND DESCRIPTION = 'BINDTABLE'";
			connDQA2.ExecuteQuery();

			conn.QueryString = "EXEC " + connDQA2.GetFieldValue("THEPROCEDURE") + " ''";
			
			BindData(((DataGrid)source), conn.QueryString);
			retrieveArray((DataGrid)source);
		}
	}
}
