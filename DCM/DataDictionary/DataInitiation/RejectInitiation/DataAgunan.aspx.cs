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
using DMS.DBConnection;
using DMS.CuBESCore;
using Microsoft.VisualBasic;
using System.IO;

namespace SME.DCM.DataDictionary.DataInitiation.RejectInitiation
{
	/// <summary>
	/// Summary description for DataAgunan.
	/// </summary>
	public partial class DataAgunan : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			ViewData();
			if(!IsPostBack)
			{
				
			}
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
							strtemp = "&regno=" + Request.QueryString["regno"] + "&view=1";
						else
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&regno=" + Request.QueryString["regno"] + "&view=1";
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
			this.DATA_GRID.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_GRID_PageIndexChanged);

		}
		#endregion

		protected void BTN_FIND_NAME_Click(object sender, System.EventArgs e)
		{
			ViewData();
		}

		protected void BTN_FIND_DESC_Click(object sender, System.EventArgs e)
		{
			ViewData();
		}

		private void ViewData()
		{
			string FIELDS_NAME	= TXT_FIELD_NAME.Text.ToString();
			string DESC			= TXT_DESCRIPTION.Text.ToString();

			if(FIELDS_NAME == "" && DESC == "")
			{
				BindData("DATA_GRID","SELECT * FROM DD_FIELDS_AGUNAN");
			}
			else if(FIELDS_NAME != "" && DESC == "")
			{
				BindData("DATA_GRID","SELECT * FROM DD_FIELDS_AGUNAN WHERE FIELDSNAME like '%" + FIELDS_NAME + "%'");
			}
			else if(FIELDS_NAME == "" && DESC != "")
			{
				BindData("DATA_GRID","SELECT * FROM DD_FIELDS_AGUNAN WHERE FIELDSDESCRIPTION like '%" + DESC + "%'");
			}
			else if(FIELDS_NAME != "" && DESC != "")
			{
				BindData("DATA_GRID","SELECT * FROM DD_FIELDS_AGUNAN WHERE FIELDSDESCRIPTION like '%" + DESC + "%' AND FIELDSNAME like '%" +  FIELDS_NAME+ "%'");
			}
			setUpeventhandlerCB();
			BindCBWithExistingData();
		}

		private void setUpeventhandlerCB()
		{
			for (int i = 0; i < DATA_GRID.Items.Count; i++)
			{
				/*** Button Process ***/
				CheckBox CHK_DATA = (CheckBox) DATA_GRID.Items[i].Cells[2].FindControl("CHK_DATA");
				if(CHK_DATA != null)
				{
					CHK_DATA.ID = "CHK_DATA." + DATA_GRID.Items[i].Cells[0].Text.ToString();
					CHK_DATA.CheckedChanged += new EventHandler(CB_STATUS_CheckedChanged);
					CHK_DATA.AutoPostBack = true;
				}
			}
		}

		private void BindCBWithExistingData()
		{
			for (int i = 0; i < DATA_GRID.Items.Count; i++)
			{
				conn.QueryString = "SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND FIELDSNAME = '" + DATA_GRID.Items[i].Cells[0].Text.ToString() + "' AND TABLE_NAME = 'DD_FIELDS_AGUNAN'";
				conn.ExecuteQuery();

				CheckBox CHK_DATA = (CheckBox) DATA_GRID.Items[i].Cells[2].FindControl("CHK_DATA." + DATA_GRID.Items[i].Cells[0].Text.ToString());
				if(conn.GetRowCount() > 0)
				{
					
					CHK_DATA.Checked = true;
				}
				else
				{	
					CHK_DATA.Checked = false;
				}
			}
		}

		private void CB_STATUS_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox b = (CheckBox) sender;
			string idx = b.ID.Replace("CHK_DATA.","");

			if(b.Checked == true)
			{
				conn.QueryString = "EXEC DD_INSERT_REQUESTED_FIELD_LIST '" + Request.QueryString["regno"] + "','" + Session["UserID"] + "','DD_FIELDS_AGUNAN','" + idx + "','INSERT'" ;
			}
			else
			{
				conn.QueryString = "EXEC DD_INSERT_REQUESTED_FIELD_LIST '" + Request.QueryString["regno"] + "','" + Session["UserID"] + "','DD_FIELDS_AGUNAN','" + idx + "','DELETE'" ;
			}
			conn.ExecuteQuery();
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

		private void DATA_GRID_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_GRID.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("DataRejectInitList.aspx?mc=" + Request.QueryString["mc"]);
		}
	}
}
