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
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;
using System.Configuration;

namespace SME.DCM.DataDictionary.DataRequestAssignValid
{
	/// <summary>
	/// Summary description for DataAssignValidList.
	/// </summary>
	public partial class DataAssignValidList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Image ImgAppr;
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				FillDataGrid();
			}
		}

		private void FillDataGrid()
		{
			conn.QueryString = "SELECT * FROM VW_DD_ASSSIGNMENT_VALIDATION_LIST";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			DGR_ASSIGNLIST.DataSource = dt;
			try
			{
				DGR_ASSIGNLIST.DataBind();
			}
			catch
			{
				DGR_ASSIGNLIST.CurrentPageIndex = 0;
				DGR_ASSIGNLIST.DataBind();
			}

			for (int i = 0; i < DGR_ASSIGNLIST.Items.Count; i++)
			{
				DGR_ASSIGNLIST.Items[i].Cells[2].Text = tools.FormatDate(DGR_ASSIGNLIST.Items[i].Cells[2].Text, true);
				LinkButton LNK_UPDATE = (LinkButton) DGR_ASSIGNLIST.Items[i].Cells[5].FindControl("LNK_UPDATE");

				ImgAppr	= (System.Web.UI.WebControls.Image) DGR_ASSIGNLIST.Items[i].Cells[6].FindControl("IMG_ASSIGN_STATUS");				
				Label LblAppr	= (Label) DGR_ASSIGNLIST.Items[i].Cells[6].FindControl("LBL_ASSIGN_STATUS");

				if(DGR_ASSIGNLIST.Items[i].Cells[5].Text == "3")
				{						
					ImgAppr.ImageUrl = "../../../image/Complete.gif";
					LblAppr.Text = "Status Done";

					LNK_UPDATE.Visible = true;
				}
				else
				{
					if(DGR_ASSIGNLIST.Items[i].Cells[5].Text == "2")
					{
						ImgAppr.ImageUrl = "../../../image/UnComplete.gif";
						LblAppr.Text = "In Process";
					}
					else if(DGR_ASSIGNLIST.Items[i].Cells[5].Text == "1")
					{
						ImgAppr.ImageUrl = "../../../image/UnComplete.gif";
						LblAppr.Text = "Assign";
					}
					else if(DGR_ASSIGNLIST.Items[i].Cells[5].Text == "0")
					{
						ImgAppr.ImageUrl = "../../../image/UnComplete.gif";
						LblAppr.Text = "Not Assign";
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
			this.DGR_ASSIGNLIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_ASSIGNLIST_ItemCommand);
			this.DGR_ASSIGNLIST.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_ASSIGNLIST_PageIndexChanged);

		}
		#endregion

		private void DGR_ASSIGNLIST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_ASSIGNLIST.CurrentPageIndex = e.NewPageIndex;
			FillDataGrid();
		}

		private void DGR_ASSIGNLIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					Response.Redirect("AssignMain.aspx?sta=exist&mc=" + Request.QueryString["mc"] + "&regno=" + e.Item.Cells[1].Text + "&exist=1");
					break;

				case "update":
					conn.QueryString = "EXEC DD_TRACKUPDATE_ASSIGN '" + Session["UserID"].ToString() + "','" + e.Item.Cells[1].Text.Trim() + "'";
					conn.ExecuteQuery();

					FillDataGrid();
					break;
			}
		}
	}
}
