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

namespace SME.Syndication.SyndicationCalculation
{
	/// <summary>
	/// Summary description for ActionTickler.
	/// </summary>
	public partial class ActionTickler : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			if(!IsPostBack)
			{
				FillDDLBank();
				FillDDLProduct();
				FillDDLType();
				FillViewData();

				DDL_ACTION_MONTH.Items.Add(new ListItem("--Select--",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_ACTION_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
			}
			FillDataGrid();
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
							strtemp = "&curef=" + Request.QueryString["curef"] + "&cif=" + Request.QueryString["cif"] + "&exist=" + Request.QueryString["exist"];
						else	
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&curef=" + Request.QueryString["curef"] + "&cif=" + Request.QueryString["cif"] + "&exist=" + Request.QueryString["exist"];
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

		private void FillDDLBank()
		{
			DDL_BANK_TYPE.Items.Clear();
			DDL_BANK_TYPE.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_SDC_DDLBANK WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_BANK_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i,2), conn.GetFieldValue(i,1)));
			}
		}

		private void FillDDLProduct()
		{
			DDL_PRODUCT_TYPE.Items.Clear();
			DDL_PRODUCT_TYPE.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT CODE, [DESC] FROM RF_SINDIKASI_PRODUCT WHERE ACTIVE = '1'";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_PRODUCT_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLType()
		{
			DDL_ACTION_TYPE.Items.Clear();
			DDL_ACTION_TYPE.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT CODE, [DESC] FROM RF_ACTION_TYPE WHERE ACTIVE = '1'";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_ACTION_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillViewData()
		{
			conn.QueryString = "SELECT * FROM VW_SDC_DATA_CREDIT_FACILITIES WHERE CU_REF = '" + Request.QueryString["curef"] + "' ORDER BY PRODUCT_ID";
			BindData(DGR_VIEWDATA.ID.ToString(), conn.QueryString, "1");
		}

		private void FillDataGrid()
		{
			conn.QueryString = "SELECT * FROM VW_SDC_ACTION_TICKLER WHERE CU_REF = '" + Request.QueryString["curef"] + "' ORDER BY SEQ";
			BindData(DATA_GRID.ID.ToString(), conn.QueryString, "2");
		}

		private void BindData(string dataGridName, string strconn, string id_grid)
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
				
				if(id_grid == "1")
				{
					for (int i = 0; i < dg.Items.Count; i++)
					{
						dg.Items[i].Cells[5].Text = tools.MoneyFormat(dg.Items[i].Cells[5].Text);
						dg.Items[i].Cells[6].Text = tools.MoneyFormat(dg.Items[i].Cells[6].Text);
						dg.Items[i].Cells[7].Text = tools.FormatDate(dg.Items[i].Cells[7].Text, true);
					}
				}
				else
				{
					for (int i = 0; i < dg.Items.Count; i++)
					{
						dg.Items[i].Cells[4].Text = tools.FormatDate(dg.Items[i].Cells[4].Text, true);
					} 
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
			this.DGR_VIEWDATA.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_VIEWDATA_ItemCommand);
			this.DGR_VIEWDATA.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_VIEWDATA_PageIndexChanged);
			this.DATA_GRID.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_GRID_ItemCommand);
			this.DATA_GRID.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_GRID_PageIndexChanged);

		}
		#endregion

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if (TXT_ACTION_DAY.Text != "" && DDL_ACTION_MONTH.SelectedValue != "" && TXT_ACTION_YEAR.Text != "") 
			{
				if (!GlobalTools.isDateValid(TXT_ACTION_DAY.Text, DDL_ACTION_MONTH.SelectedValue, TXT_ACTION_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Action Date Not Valid!");
					return;
				}
			}

			else if(LBL_PRODUCT_SEQ.Text == "" || LBL_PRODUCT_SEQ.Text == null)
			{
				GlobalTools.popMessage(this, "Data Invalid!");
				return;
			}
			
			try
			{
				conn.QueryString = "EXEC SDC_ACTION_TICKLER_INSERT '" +
									LBL_SEQ.Text + "','" +
									Session["UserID"].ToString() + "','" +
									Request.QueryString["curef"] + "','" +
									Request.QueryString["cif"] + "','" +
									DDL_BANK_TYPE.SelectedValue + "'," +
									LBL_PRODUCT_SEQ.Text + ",'" +
									DDL_PRODUCT_TYPE.SelectedValue + "','" +
									DDL_ACTION_TYPE.SelectedValue + "'," +
									tools.ConvertDate(TXT_ACTION_DAY.Text, DDL_ACTION_MONTH.SelectedValue, TXT_ACTION_YEAR.Text);
				conn.ExecuteQuery();

				ClearData();
				FillDataGrid();
			}

			catch(Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{
			LBL_SEQ.Text					= "";
			LBL_PRODUCT_SEQ.Text			= "";
			DDL_BANK_TYPE.SelectedValue		= "";
			DDL_PRODUCT_TYPE.SelectedValue	= "";
			DDL_ACTION_TYPE.SelectedValue	= "";
			TXT_ACTION_DAY.Text				= "";
			DDL_ACTION_MONTH.SelectedValue	= "";
			TXT_ACTION_YEAR.Text			= "";
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../CustomerList.aspx?mc=" + Request.QueryString["mc"]);
		}

		private void DATA_GRID_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_GRID.CurrentPageIndex = e.NewPageIndex;
			FillDataGrid();
		}

		private void DATA_GRID_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					conn.QueryString = "SELECT * FROM SDC_ACTION_TICKLER WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();

					LBL_SEQ.Text					= conn.GetFieldValue("SEQ").ToString().Replace("&nbsp;","");
					LBL_PRODUCT_SEQ.Text			= conn.GetFieldValue("PRODUCT_SEQ").ToString();
					DDL_BANK_TYPE.SelectedValue		= conn.GetFieldValue("BANK_NM").ToString();
					DDL_PRODUCT_TYPE.SelectedValue	= conn.GetFieldValue("PRODUCT_CODE").ToString();
					DDL_ACTION_TYPE.SelectedValue	= conn.GetFieldValue("ACTION_TYPE").ToString();
					TXT_ACTION_DAY.Text				= tools.FormatDate_Day(conn.GetFieldValue("ACTION_DATE").ToString());
					DDL_ACTION_MONTH.SelectedValue	= tools.FormatDate_Month(conn.GetFieldValue("ACTION_DATE").ToString());
					TXT_ACTION_YEAR.Text			= tools.FormatDate_Year(conn.GetFieldValue("ACTION_DATE").ToString());
					break;

				case "delete":
					conn.QueryString = "DELETE SDC_ACTION_TICKLER WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();

					FillDataGrid();
					break;
			}
		}

		protected void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('ActionTicklerPrint.aspx?mc=" + Request.QueryString["mc"] + "&curef=" + Request.QueryString["curef"] + "','PrintRequest');</script>");
		}

		private void DGR_VIEWDATA_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_VIEWDATA.CurrentPageIndex = e.NewPageIndex;
			FillViewData();
		}

		private void DGR_VIEWDATA_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					conn.QueryString = "SELECT * FROM VW_SDC_DATA_CREDIT_FACILITIES WHERE PRODUCT_SEQ = '" + e.Item.Cells[0].Text.ToString() +
										"' AND BANK_ID = '" + e.Item.Cells[1].Text.ToString() + "' AND PRODUCT_ID = '" + e.Item.Cells[3].Text.ToString() +
										"' AND CU_REF = '" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();

					LBL_PRODUCT_SEQ.Text				= conn.GetFieldValue("PRODUCT_SEQ").ToString().Replace("&nbsp;","");
					DDL_BANK_TYPE.SelectedValue			= conn.GetFieldValue("BANK_ID").ToString();
					DDL_PRODUCT_TYPE.SelectedValue		= conn.GetFieldValue("PRODUCT_ID").ToString();
					break;
			}
		}
	}
}
