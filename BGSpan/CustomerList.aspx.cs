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

namespace SME.BGSpan
{
	/// <summary>
	/// Summary description for CustomerList1.
	/// </summary>
	public partial class CustomerList1 : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected string tesstring = "";
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				conn.QueryString = "SELECT DISTINCT * FROM VW_SDC_CUSTOMER_LIST ORDER BY SEQ";
				BindData(DATA_GRID.ID.ToString(), conn.QueryString);

				DDL_OPERATE_MONTH.Items.Add(new ListItem("--Select--",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_OPERATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				if(Request.QueryString["mc"] == "BGS01")	
				{
					BTN_FIND.Visible=true;
					BTN_NEW.Visible=true;
				}
				else
				{
					BTN_FIND.Visible=true;
					BTN_NEW.Visible=false;
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
			this.DATA_GRID.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_GRID_ItemCommand);

		}
		#endregion

		protected void BTN_NEW_Click(object sender, System.EventArgs e)
		{
			//conn.QueryString = "SELECT * FROM TABLE";
			//conn.ExecuteQuery();

			/*for(int i=0; i<conn.GetRowCount(); i++)
			{
				TXT_CIF.Text = conn.GetFieldValue(i, "A");
			}*/

			//BindData(DATA_GRID.ID,conn);

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

				Response.Redirect("Initiation/GeneralInfo.aspx?tc=" + Request.QueryString["tc"]+ "&mc=" + Request.QueryString["mc"] + "&curef=" + curef + "&exist=0");
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

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();

				System.Data.DataTable dt = new System.Data.DataTable();
				dt = conn.GetDataTable().Copy();

				System.Web.UI.WebControls.DataGrid ed = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);
				ed.DataSource = dt;

				try
				{
					ed.DataBind();
				}
				catch
				{
					ed.CurrentPageIndex = ed.PageCount - 1;
					ed.DataBind();
				}

				conn.ClearData();
			}
		}

		
		private void DATA_GRID_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "continue":						
					if (Request.QueryString["mc"] == "BGS01")	
					{
						Response.Redirect("Initiation/GeneralInfo.aspx?tc=" + Request.QueryString["tc"]+ "&mc=" + Request.QueryString["mc"]+ "&curef=" + e.Item.Cells[1].Text.Trim() + "&cif=" + e.Item.Cells[2].Text.Trim() + "&exist=1");
					}
//					else
//					{
//						Response.Redirect("TransactionHistory/NCLHistoryTransaction.aspx?mc=" + Request.QueryString["mc"] + "&curef=" + e.Item.Cells[1].Text.Trim() + "&cif=" + e.Item.Cells[2].Text.Trim() + "&exist=1");
//					}
					break;				
			}
		}

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
			if(TXT_ID_NO.Text != "")
			{
				query += "AND SIUP_TDP_NUMBER LIKE '%" + TXT_ID_NO .Text + "%' ";
			}

			if((TXT_OPERATE_DAY.Text != "")&(TXT_OPERATE_YEAR.Text != "")&(DDL_OPERATE_MONTH.SelectedItem.Text !="--Select--"))
			{
				if (GlobalTools.isDateValid(TXT_OPERATE_DAY.Text, DDL_OPERATE_MONTH.SelectedValue, TXT_OPERATE_YEAR.Text)) 
				{
					query += "AND Istablish_date=" + tools.ConvertDate(TXT_OPERATE_DAY.Text, DDL_OPERATE_MONTH.SelectedValue, TXT_OPERATE_YEAR.Text) + "";
				}				
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

	}
}
