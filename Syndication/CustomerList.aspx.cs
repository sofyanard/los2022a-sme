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

namespace SME.Syndication
{
	/// <summary>
	/// Summary description for CustomerList.
	/// </summary>
	public partial class CustomerList : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				if(Request.QueryString["mc"] == "SDC01")		//Customer Basic Information
				{
					BTN_NEW.Visible = true;
					conn.QueryString = "SELECT DISTINCT * FROM VW_SDC_CUSTOMER_LIST ORDER BY SEQ";
					BindData(DATA_GRID.ID.ToString(), conn.QueryString);
				}
				
				else	//Documentation, Perjanjian Kredit, Syndication Calculation
				{
					BTN_CLEAR.Visible = true;
					conn.QueryString = "SELECT DISTINCT * FROM VW_SDC_CUSTOMER_LIST ORDER BY SEQ";
					BindData(DATA_GRID.ID.ToString(), conn.QueryString);
				}
			}
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
			this.DATA_GRID.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_GRID_ItemCommand);
			this.DATA_GRID.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_GRID_PageIndexChanged);

		}
		#endregion

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			DATA_GRID.CurrentPageIndex = 0;
			SearchData();
		}

		private void SearchData()
		{
			string query = "";

			if(TXT_CIF.Text != "")
			{
				query += "AND CIF LIKE '%" + TXT_CIF.Text + "%' ";
			}
			if(TXT_CUST.Text != "")
			{
				query += "AND CUST_NAME LIKE '%" + TXT_CUST.Text + "%' ";
			}
			if(TXT_NO_SIUP.Text != "")
			{
				query += "AND SIUP_TDP_NUMBER LIKE '%" + TXT_NO_SIUP.Text + "%' ";
			}

			if(TXT_NO_NPWP.Text != "")
			{
				query += "AND NPWP LIKE '%" + TXT_NO_NPWP.Text +"%' ";
			}

			if(query != "")
			{
				conn.QueryString = "SELECT DISTINCT * FROM VW_SDC_CUSTOMER_LIST WHERE 1=1 " + query + "ORDER BY SEQ";
				BindData(DATA_GRID.ID.ToString(), conn.QueryString);
			}

			else
			{
				conn.QueryString = "SELECT DISTINCT * FROM VW_SDC_CUSTOMER_LIST ORDER BY SEQ";
				BindData(DATA_GRID.ID.ToString(), conn.QueryString);
			}
		}

		protected void BTN_NEW_Click(object sender, System.EventArgs e)
		{
			try
			{
				string curef;

				conn.QueryString = "EXEC GENERATE_CUREF_CBI '" + Session["BranchID"].ToString() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					curef = conn.GetFieldValue("CUREF");
				}
				else
				{
					return;
				}

				Response.Redirect("CustomerBasicInformation/CustomerData.aspx?mc=" + Request.QueryString["mc"] + "&curef=" + curef + "&exist=0");
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

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			TXT_CIF.Text		= "";
			TXT_CUST.Text		= "";
			TXT_NO_SIUP.Text	= "";
			TXT_NO_NPWP.Text	= "";
		}

		private void DATA_GRID_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_GRID.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void DATA_GRID_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "continue":
					if(Request.QueryString["mc"] == "SDC01")		//Customer Basic Information
					{
						Response.Redirect("CustomerBasicInformation/CustomerData.aspx?mc=" + Request.QueryString["mc"] + "&curef=" + e.Item.Cells[1].Text.Trim() + "&cif=" + e.Item.Cells[2].Text.Trim() + "&exist=1");
					}
					else if(Request.QueryString["mc"] == "SDC02")	//Documentation
					{
						Response.Redirect("Documentation/GeneralInfo.aspx?mc=" + Request.QueryString["mc"] + "&curef=" + e.Item.Cells[1].Text.Trim() + "&cif=" + e.Item.Cells[2].Text.Trim() + "&exist=1");
					}
					else if(Request.QueryString["mc"] == "SDC03")	//Perjanjian Kredit
					{
						Response.Redirect("PerjanjianKredit/GeneralInfo.aspx?mc=" + Request.QueryString["mc"] + "&curef=" + e.Item.Cells[1].Text.Trim() + "&cif=" + e.Item.Cells[2].Text.Trim() + "&exist=1");
					}
					else if(Request.QueryString["mc"] == "SDC04")	//Syndication Calculation
					{
						Response.Redirect("SyndicationCalculation/PenarikanPenerbitan.aspx?mc=" + Request.QueryString["mc"] + "&curef=" + e.Item.Cells[1].Text.Trim() + "&cif=" + e.Item.Cells[2].Text.Trim() + "&exist=1");
					}
					break;
			}
		}
	}
}
