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

namespace SME.DCM.DataDictionary.DDParameter.Approval
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

			//disini retrieve semua session
		}

		private void CreateHeader(string SM_IDest)
		{
			System.Web.UI.WebControls.Button BTN;
			System.Web.UI.WebControls.TextBox TXT_BOX;
			System.Web.UI.HtmlControls.HtmlTable TBL3;
			System.Web.UI.WebControls.DataGrid THE_GRID;
			RadioButtonTemplate RBT;
			SelectAllTemplate SAT;

			connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_IDest + "' AND DESCRIPTION = 'DCM_DataDictionary_DDParameter_Approval_ParameterizedPage.aspx_TITLEPARAMETERAPPROVAL'";
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

			/*********************************************************************************************/
			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			TD.Attributes["colspan"] = "2";

			THE_GRID = new DataGrid();
			THE_GRID.ID = "GRID_APPROVAL_PARAMETER_" + SM_IDest;
			THE_GRID.AllowPaging = false;
			THE_GRID.ShowFooter = true;
			THE_GRID.PageSize = 1000;
			THE_GRID.CellPadding = 1;
			THE_GRID.AutoGenerateColumns = false;
			THE_GRID.Width = Unit.Percentage(100.0);
			THE_GRID.AlternatingItemStyle.CssClass = "TblAlternating";
			THE_GRID.PagerStyle.Mode = PagerMode.NumericPages;

			BoundColumn columns = new BoundColumn();
			columns.HeaderText = "Code";
			columns.DataField = "CODE";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Description";
			columns.DataField = "DESCRIPTIONS";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(65.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Pending Status";
			columns.DataField = "PENDINGSTATUS";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);

			TemplateColumn columnsz = new TemplateColumn();
			columnsz.HeaderText = "Approve";
			columnsz.HeaderStyle.CssClass = "tdSmallHeader";
			columnsz.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columnsz.ItemStyle.Width = Unit.Percentage(5.0);
			RBT = new RadioButtonTemplate("RBT_APPROVE_" + SM_IDest);
			columnsz.ItemTemplate = RBT;
			SAT = new SelectAllTemplate("SELECT_ALL_APPROVE_" + SM_IDest, this);
			columnsz.FooterTemplate = SAT;
			THE_GRID.Columns.Add(columnsz);

			columnsz = new TemplateColumn();
			columnsz.HeaderText = "Pending";
			columnsz.HeaderStyle.CssClass = "tdSmallHeader";
			columnsz.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columnsz.ItemStyle.Width = Unit.Percentage(5.0);
			RBT = new RadioButtonTemplate("RBT_PENDING_" + SM_IDest);
			columnsz.ItemTemplate = RBT;
			SAT = new SelectAllTemplate("SELECT_ALL_PENDING_" + SM_IDest, this);
			columnsz.FooterTemplate = SAT;
			THE_GRID.Columns.Add(columnsz);

			columnsz = new TemplateColumn();
			columnsz.HeaderText = "Reject";
			columnsz.HeaderStyle.CssClass = "tdSmallHeader";
			columnsz.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columnsz.ItemStyle.Width = Unit.Percentage(5.0);
			RBT = new RadioButtonTemplate("RBT_REJECT_" + SM_IDest);
			columnsz.ItemTemplate = RBT;
			SAT = new SelectAllTemplate("SELECT_ALL_REJECT_" + SM_IDest, this);
			columnsz.FooterTemplate = SAT;
			THE_GRID.Columns.Add(columnsz);

			connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SM_IDest + "' AND DESCRIPTION = 'DCM_DataDictionary_DDParameter_Approval_ParameterizedPage.aspx_BINDINGGRID'";
			connDQA2.ExecuteQuery();
			procedure = connDQA2.GetFieldValue("THEPROCEDURE");
			BindData(THE_GRID, "EXEC " + procedure + " ''");

			TD.Controls.Add(THE_GRID);
			TR.Controls.Add(TD);

			TBL_maintable.Controls.Add(TR);

			/************************************************************************************************/
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
			TR.Controls.Add(TD);

			TBL_maintable.Controls.Add(TR);

			/************************************************************************************************/

			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			TR.Controls.Add(TD);
			TBL_maintable.Controls.Add(TR);

			RebindTheRadioButtonGroup(this, SM_IDest);
		}

		private void BTN_Click(object sender, EventArgs e)
		{
			Save(((Button)sender).ID.Remove(0,9));
		}

		public void Save(string SMID)
		{
			bool approve = false;
			bool pending = false;
			bool reject = false;
			bool checkeds = false;
			string THEPROCEDURE = "";
			foreach (Control ctrl in Page.Controls)
			{
				if (ctrl is DataGrid)
				{
					DataGrid grid = (DataGrid)ctrl;
					string id = grid.ID;
					for(int i =0; i< grid.Items.Count; i++)
					{
						approve = ((RadioButton)grid.Items[i].Cells[3].FindControl("RBT_APPROVE_" + SMID)).Checked;
						pending = ((RadioButton)grid.Items[i].Cells[4].FindControl("RBT_PENDING_" + SMID)).Checked;
						reject = ((RadioButton)grid.Items[i].Cells[5].FindControl("RBT_REJECT_" + SMID)).Checked;
					
						//insert disini

						string DESCRIPTION = "DCM_DataDictionary_DDParameter_Approval_ParameterizedPage.aspx_APP_PARAMETER_APPROVAL";

						connDQA2.QueryString = "SELECT THEPROCEDURE FROM DCM_2012_PROCEDURE WHERE SM_ID = '" + SMID + "' AND DESCRIPTION = '" + DESCRIPTION + "'";
						connDQA2.ExecuteQuery();

						THEPROCEDURE = connDQA2.GetFieldValue("THEPROCEDURE");

						connDQA2.QueryString = "EXEC " + THEPROCEDURE + " " + approve + "," + pending + "," + reject + " ";
						connDQA2.ExecuteQuery();
					}
				}
				else
				{
					if (ctrl.Controls.Count > 0)
					{
						RebindTheRadioButtonGroup(ctrl, SMID);
					}
				}
			}
		}

		public void RebindTheRadioButtonGroup(Control Page, string str)
		{
			/*ini ngeceknya klo kosong doang*/
			foreach (Control ctrl in Page.Controls)
			{
				if (ctrl is DataGrid)
				{
					DataGrid grid = (DataGrid)ctrl;
					string id = grid.ID;
					for(int i =0; i< grid.Items.Count; i++)
					{
						try
						{
							((RadioButton)grid.Items[i].Cells[3].FindControl("RBT_APPROVE_" + str)).GroupName = grid.Items[i].Cells[0].Text.ToString();
							((RadioButton)grid.Items[i].Cells[4].FindControl("RBT_PENDING_" + str)).GroupName = grid.Items[i].Cells[0].Text.ToString();
							((RadioButton)grid.Items[i].Cells[5].FindControl("RBT_REJECT_" + str)).GroupName = grid.Items[i].Cells[0].Text.ToString();
						}
						catch(Exception o)
						{
							string a = o.Message.ToString();
							string b = o.Message.ToString();
						}
					}
				}
				else
				{
					if (ctrl.Controls.Count > 0)
					{
						RebindTheRadioButtonGroup(ctrl, str);
					}
				}
			}
		}

		private class RadioButtonTemplate : ITemplate
		{
			string SMID = "";
			string theID = "";
			public RadioButtonTemplate(string id)
			{
				//RBT_APPROVE_
				//RBT_PENDING_
				//RBT_REJECT_
				if(id.StartsWith("RBT_APPROVE_"))
				{
					SMID = id.Remove(0,12);
				}
				else if(id.StartsWith("RBT_PENDING_"))
				{
					SMID = id.Remove(0,12);
				}
				else if(id.StartsWith("RBT_REJECT_"))
				{
					SMID = id.Remove(0,11);
				}
				theID = id;
			}

			public void InstantiateIn(System.Web.UI.Control container)
			{    
				RadioButton lb = new RadioButton();
				if(theID.StartsWith("RBT_APPROVE_"))
				{
					lb.ID = "RBT_APPROVE_" + SMID;
				}
				else if(theID.StartsWith("RBT_PENDING_"))
				{
					lb.ID = "RBT_PENDING_" + SMID;
				}
				else if(theID.StartsWith("RBT_REJECT_"))
				{
					lb.ID = "RBT_REJECT_" + SMID;
				}
				container.Controls.Add(lb);
			}
		}


		private class SelectAllTemplate : ITemplate
		{
			string theID = "";
			Control page;

			public SelectAllTemplate(string theid, Control dPage)
			{
				this.theID = theid;
				this.page = dPage;
			}

			public void InstantiateIn(System.Web.UI.Control container)
			{
				LinkButton lb = new LinkButton();
				lb.ID = theID;
				lb.Text = "Select All";
				if(theID.StartsWith("SELECT_ALL_APPROVE_"))
				{
					lb.CommandName = "all_approve";
				}
				else if(theID.StartsWith("SELECT_ALL_PENDING_"))
				{
					lb.CommandName = "all_pending";
				}
				else if(theID.StartsWith("SELECT_ALL_REJECT_"))
				{
					lb.CommandName = "all_reject";
				}
				lb.Click += new EventHandler(lb_Click);
				container.Controls.Add(lb);
			}

			private void lb_Click(object sender, EventArgs e)
			{
				string SMID = "";
				string PREFIX = "";
				if(theID.StartsWith("SELECT_ALL_APPROVE_"))
				{
					SMID = theID.Remove(0,19);
					PREFIX = "RBT_APPROVE_";
				}
				else if(theID.StartsWith("SELECT_ALL_PENDING_"))
				{
					SMID = theID.Remove(0,19);
					PREFIX = "RBT_PENDING_";
				}
				else if(theID.StartsWith("SELECT_ALL_REJECT_"))
				{
					SMID = theID.Remove(0,18);
					PREFIX = "RBT_REJECT_";
				}
				CheckAllRadioButton(page, PREFIX, SMID);
			}

			public void CheckAllRadioButton(Control Page, string PREFIX, string SMID)
			{
				/*ini ngeceknya klo kosong doang*/
				foreach (Control ctrl in Page.Controls)
				{
					if (ctrl is DataGrid)
					{
						DataGrid grid = (DataGrid)ctrl;
						string id = grid.ID;
						for(int i =0; i< grid.Items.Count; i++)
						{
							try
							{
								((RadioButton)grid.Items[i].Cells[3].FindControl("RBT_APPROVE_" + SMID)).Checked = false;
								((RadioButton)grid.Items[i].Cells[4].FindControl("RBT_PENDING_" + SMID)).Checked = false;
								((RadioButton)grid.Items[i].Cells[5].FindControl("RBT_REJECT_" + SMID)).Checked = false;

								if(PREFIX == "RBT_APPROVE_")
								{
									((RadioButton)grid.Items[i].Cells[3].FindControl("RBT_APPROVE_" + SMID)).Checked = true;
								}
								else if(PREFIX == "RBT_PENDING_")
								{
									((RadioButton)grid.Items[i].Cells[4].FindControl("RBT_PENDING_" + SMID)).Checked = true;
								}
								else if(PREFIX == "RBT_REJECT_")
								{
									((RadioButton)grid.Items[i].Cells[5].FindControl("RBT_REJECT_" + SMID)).Checked = true;
								}
							}
							catch(Exception o)
							{
								string a = o.Message.ToString();
								string b = o.Message.ToString();
							}
						}
					}
					else
					{
						if (ctrl.Controls.Count > 0)
						{
							CheckAllRadioButton(ctrl, PREFIX, SMID);
						}
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
	}
}
