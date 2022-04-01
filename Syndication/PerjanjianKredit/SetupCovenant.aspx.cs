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

namespace SME.Syndication.PerjanjianKredit
{
	/// <summary>
	/// Summary description for SetupConvenant.
	/// </summary>
	public partial class SetupConvenant : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			if(!IsPostBack)
			{
				FillDDLItem();

				DDL_JATUH_TEMPO_MONTH.Items.Add(new ListItem("--Select--",""));
				DDL_PEMENUHAN_MONTH.Items.Add(new ListItem("--Select--",""));
				DDL_NEXT_PERIOD_MONTH.Items.Add(new ListItem("--Select--",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_JATUH_TEMPO_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_PEMENUHAN_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_NEXT_PERIOD_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
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

		private void FillDDLItem()
		{
			DDL_ITEM_TYPE.Items.Clear();

			DDL_ITEM_TYPE.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT ITEMID, ITEMDESC FROM RF_ITEM_SYARAT WHERE ACTIVE = '1' ORDER BY ITEMDESC";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_ITEM_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDataGrid()
		{
			conn.QueryString = "SELECT * FROM VW_SDC_COVENANT WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			BindData(DATA_GRID.ID.ToString(), conn.QueryString);
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

				for (int i = 0; i < dg.Items.Count; i++)
				{
					dg.Items[i].Cells[3].Text = tools.FormatDate(dg.Items[i].Cells[3].Text, true);
					dg.Items[i].Cells[4].Text = tools.FormatDate(dg.Items[i].Cells[4].Text, true);
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
			this.DATA_GRID.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_GRID_ItemCommand);
			this.DATA_GRID.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_GRID_PageIndexChanged);

		}
		#endregion

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if (TXT_JATUH_TEMPO_DAY.Text != "" && DDL_JATUH_TEMPO_MONTH.SelectedValue != "" && TXT_JATUH_TEMPO_YEAR.Text != "") 
			{
				if (!GlobalTools.isDateValid(TXT_JATUH_TEMPO_DAY.Text, DDL_JATUH_TEMPO_MONTH.SelectedValue, TXT_JATUH_TEMPO_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Jatuh Tempo Tidak Valid!");
					return;
				}
			}

			if (TXT_PEMENUHAN_DAY.Text != "" && DDL_PEMENUHAN_MONTH.SelectedValue != "" && TXT_PEMENUHAN_YEAR.Text != "") 
			{
				if (!GlobalTools.isDateValid(TXT_PEMENUHAN_DAY.Text, DDL_PEMENUHAN_MONTH.SelectedValue, TXT_PEMENUHAN_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Dipenuhi Tidak Valid!");
					return;
				}
			}

			if (TXT_NEXT_PERIOD_DAY.Text != "" && DDL_NEXT_PERIOD_MONTH.SelectedValue != "" && TXT_NEXT_PERIOD_YEAR.Text != "") 
			{
				if (!GlobalTools.isDateValid(TXT_NEXT_PERIOD_DAY.Text, DDL_NEXT_PERIOD_MONTH.SelectedValue, TXT_NEXT_PERIOD_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Next Period Tidak Valid!");
					return;
				}
			}

			try
			{
				conn.QueryString = "EXEC SDC_COVENANT_INSERT '" +
									LBL_SEQ.Text + "','" +
									Session["UserID"].ToString() + "','" +
									Request.QueryString["curef"] + "','" +
									Request.QueryString["cif"] + "','" +
									DDL_ITEM_TYPE.SelectedValue + "','" +
									TXT_DESCRIPTION.Text + "'," +
									tools.ConvertDate(TXT_JATUH_TEMPO_DAY.Text, DDL_JATUH_TEMPO_MONTH.SelectedValue, TXT_JATUH_TEMPO_YEAR.Text) + "," +
									tools.ConvertDate(TXT_PEMENUHAN_DAY.Text, DDL_PEMENUHAN_MONTH.SelectedValue, TXT_PEMENUHAN_YEAR.Text) + "," +
									tools.ConvertDate(TXT_NEXT_PERIOD_DAY.Text, DDL_NEXT_PERIOD_MONTH.SelectedValue, TXT_NEXT_PERIOD_YEAR.Text) + ",'" +
									CHK_STATUS.Checked + "'";
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
			LBL_SEQ.Text						= "";
			DDL_ITEM_TYPE.SelectedValue			= "";
			TXT_DESCRIPTION.Text				= "";
			TXT_JATUH_TEMPO_DAY.Text			= "";
			DDL_JATUH_TEMPO_MONTH.SelectedValue	= "";
			TXT_JATUH_TEMPO_YEAR.Text			= "";
			TXT_PEMENUHAN_DAY.Text				= "";
			DDL_PEMENUHAN_MONTH.SelectedValue	= "";
			TXT_PEMENUHAN_YEAR.Text				= "";
			TXT_NEXT_PERIOD_DAY.Text			= "";
			DDL_NEXT_PERIOD_MONTH.SelectedValue	= "";
			TXT_NEXT_PERIOD_YEAR.Text			= "";
			CHK_STATUS.Checked					= false;
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
					conn.QueryString = "SELECT * FROM SDC_COVENANT WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();

					LBL_SEQ.Text						= conn.GetFieldValue("SEQ").ToString().Replace("&nbsp;","");
					DDL_ITEM_TYPE.SelectedValue			= conn.GetFieldValue("ITEM_CODE").ToString().Replace("&nbsp;","");
					TXT_DESCRIPTION.Text				= conn.GetFieldValue("DESC").ToString().Replace("&nbsp;","");
					TXT_JATUH_TEMPO_DAY.Text			= tools.FormatDate_Day(conn.GetFieldValue("COVENANT_EXP").ToString());
					DDL_JATUH_TEMPO_MONTH.SelectedValue	= tools.FormatDate_Month(conn.GetFieldValue("COVENANT_EXP").ToString());
					TXT_JATUH_TEMPO_YEAR.Text			= tools.FormatDate_Year(conn.GetFieldValue("COVENANT_EXP").ToString());
					TXT_PEMENUHAN_DAY.Text				= tools.FormatDate_Day(conn.GetFieldValue("PEMENUHAN").ToString());
					DDL_PEMENUHAN_MONTH.SelectedValue	= tools.FormatDate_Month(conn.GetFieldValue("PEMENUHAN").ToString());
					TXT_PEMENUHAN_YEAR.Text				= tools.FormatDate_Year(conn.GetFieldValue("PEMENUHAN").ToString());
					TXT_NEXT_PERIOD_DAY.Text			= tools.FormatDate_Day(conn.GetFieldValue("NEXT_PERIOD").ToString());
					DDL_NEXT_PERIOD_MONTH.SelectedValue	= tools.FormatDate_Month(conn.GetFieldValue("NEXT_PERIOD").ToString());
					TXT_NEXT_PERIOD_YEAR.Text			= tools.FormatDate_Year(conn.GetFieldValue("NEXT_PERIOD").ToString());

					if(conn.GetFieldValue("STATUS").ToString() == "0")
					{
						CHK_STATUS.Checked					= false;
					}
					else
					{
						CHK_STATUS.Checked					= true;
					}
					break;

				case "delete":
					conn.QueryString = "DELETE SDC_COVENANT WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();

					FillDataGrid();
					break;
			}
		}
	}
}
