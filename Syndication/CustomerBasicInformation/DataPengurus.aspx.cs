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

namespace SME.Syndication.CustomerBasicInformation
{
	/// <summary>
	/// Summary description for DataPengurus.
	/// </summary>
	public partial class DataPengurus : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();

			if(!IsPostBack)
			{
				FillDDLPosition();
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

		private void FillDDLPosition()
		{
			DDL_JABATAN.Items.Clear();
			DDL_JABATAN.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT JOBTITLEID, JOBTITLEDESC FROM RFJOBTITLE WHERE ACTIVE = '1' ORDER BY JOBTITLEDESC";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_JABATAN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDataGrid()
		{
			conn.QueryString = "SELECT A.*, JOBTITLEDESC AS JABATAN_DESC FROM SDC_PENGURUS_INFO A LEFT OUTER JOIN RFJOBTITLE B ON A.JABATAN = B.JOBTITLEID WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
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
					dg.Items[i].Cells[5].Text = tools.MoneyFormat(dg.Items[i].Cells[5].Text);
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
			try
			{
				conn.QueryString = "EXEC SDC_PENGURUS_INFO_INSERT '" +
									LBL_SEQ.Text + "','" +
									Session["UserID"].ToString() + "','" +
									Request.QueryString["curef"] + "','" +
									Request.QueryString["cif"] + "','" +
									TXT_NAMA.Text + "','" +
									DDL_JABATAN.SelectedValue + "','" +
									TXT_SAHAM_PERCENT.Text + "','" +
									TXT_LEMBAR_SAHAM.Text + "','" +
									TXT_NILAI_SAHAM.Text + "','" +
									TXT_IDNUMBER.Text + "'";
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
			LBL_SEQ.Text				= "";
			TXT_NAMA.Text				= "";
			DDL_JABATAN.SelectedValue	= "";
			TXT_SAHAM_PERCENT.Text		= "";
			TXT_LEMBAR_SAHAM.Text		= "";
			TXT_NILAI_SAHAM.Text		= "";
			TXT_IDNUMBER.Text			= "";
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
					conn.QueryString = "SELECT * FROM SDC_PENGURUS_INFO WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();

					LBL_SEQ.Text				= conn.GetFieldValue("SEQ").ToString().Replace("&nbsp;","");
					TXT_NAMA.Text				= conn.GetFieldValue("NAME").ToString().Replace("&nbsp;","");
					DDL_JABATAN.SelectedValue	= conn.GetFieldValue("JABATAN").ToString();
					TXT_SAHAM_PERCENT.Text		= conn.GetFieldValue("SAHAM_PERCENT").ToString().Replace("&nbsp;","");
					TXT_LEMBAR_SAHAM.Text		= conn.GetFieldValue("LEMBAR_SAHAM").ToString().Replace("&nbsp;","");
					TXT_NILAI_SAHAM.Text		= conn.GetFieldValue("AMT_SAHAM").ToString().Replace("&nbsp;","");
					TXT_IDNUMBER.Text			= conn.GetFieldValue("ID_NUMBER").ToString().Replace("&nbsp;","");
					break;

				case "delete":
					conn.QueryString = "DELETE SDC_PENGURUS_INFO WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();

					FillDataGrid();
					break;
			}
		}
	}
}
