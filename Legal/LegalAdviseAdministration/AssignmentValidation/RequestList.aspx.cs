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

namespace SME.Legal.LegalAdviseAdministration.AssigmentValidation
{
	/// <summary>
	/// Summary description for RequestList.
	/// </summary>
	public partial class RequestList : System.Web.UI.Page
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
			conn.QueryString = "SELECT * FROM VW_LGAM_REQUEST_LIST";
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

				DATA_GRID.DataSource = dt;
				try
				{
					DATA_GRID.DataBind();
				}
				catch
				{
					DATA_GRID.CurrentPageIndex = 0;
					DATA_GRID.DataBind();
				}

				for (int i = 0; i < DATA_GRID.Items.Count; i++)
				{
					DATA_GRID.Items[i].Cells[2].Text = tools.FormatDate(DATA_GRID.Items[i].Cells[2].Text, true);
					LinkButton LNK_UPDATE = (LinkButton) DATA_GRID.Items[i].Cells[5].FindControl("LNK_UPDATE");

					ImgAppr	= (System.Web.UI.WebControls.Image) DATA_GRID.Items[i].Cells[6].FindControl("IMG_INTERNAL_STATUS");				
					Label LblAppr	= (Label) DATA_GRID.Items[i].Cells[6].FindControl("LBL_INTERNAL_STATUS");

					if(DATA_GRID.Items[i].Cells[7].Text == "LGL.2" && DATA_GRID.Items[i].Cells[9].Text == "0")
					{
						LNK_UPDATE.Visible = false;
						ImgAppr.ImageUrl = "../../../image/UnComplete.gif";
						LblAppr.Text = "Not Assign";
					}
					else if(DATA_GRID.Items[i].Cells[7].Text == "LGL.3" && DATA_GRID.Items[i].Cells[9].Text == "0")
					{
						LNK_UPDATE.Visible = false;
						ImgAppr.ImageUrl = "../../../image/UnComplete.gif";
						LblAppr.Text = "Assign to LO";
					}
					else if(DATA_GRID.Items[i].Cells[7].Text == "LGL.3" && DATA_GRID.Items[i].Cells[9].Text == "1")
					{
						LNK_UPDATE.Visible = false;
						ImgAppr.ImageUrl = "../../../image/UnComplete.gif";
						LblAppr.Text = "In Progress";
					}
					else if(DATA_GRID.Items[i].Cells[7].Text == "LGL.2" && DATA_GRID.Items[i].Cells[9].Text == "1")
					{
						LNK_UPDATE.Visible = true;
						ImgAppr.ImageUrl = "../../../image/Complete.gif";
						LblAppr.Text = "Done";
					}
					/*else if(DATA_GRID.Items[i].Cells[7].Text == "LGL.4" || DATA_GRID.Items[i].Cells[7].Text == "LGL.5")
					{
						//LNK_UPDATE.Visible = true;
						ImgAppr.ImageUrl = "../../../image/Complete.gif";
						LblAppr.Text = "Done";
					}*/
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
			this.DATA_GRID.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_GRID_PageIndexChanged);

		}
		#endregion

		private void DATA_GRID_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_GRID.CurrentPageIndex = e.NewPageIndex;
			FillDataGrid();
		}

		private void DATA_GRID_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					string currtrack = "";

					conn.QueryString = "SELECT AP_CURRTRACK FROM VW_LGAM_REQUEST_LIST WHERE CU_REF = '" + e.Item.Cells[0].Text.Trim() + "'";
					conn.ExecuteQuery();

					currtrack = conn.GetFieldValue("AP_CURRTRACK").ToString();

					if(currtrack == "LGL.2" || currtrack == "LGL.3")
					{
						Response.Redirect("AssignmentValidation.aspx?mc=" + Request.QueryString["mc"] + "&curef=" + e.Item.Cells[0].Text.Trim());
					}
					/*else if(currtrack == "LGL.4" || currtrack == "LGL.5")
					{
						Response.Redirect("../InquiryHistoricalData/DetailRequestInfo.aspx?mc=LGL05&curef=" + e.Item.Cells[0].Text.Trim() + "&view=1");
					}*/
				break;


				case "update":
					conn.QueryString = "EXEC LGAM_TRACKUPDATE_FINISH '" + Session["UserID"].ToString() + "','" + e.Item.Cells[0].Text.Trim() + "'";
					conn.ExecuteQuery();

					GlobalTools.popMessage(this, "Aplikasi telah berhasil terupdate");
					FillDataGrid();
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

			if(TXT_NO_REF.Text != "")
			{
				query += "AND REFERENCE LIKE '%" + TXT_NO_REF.Text + "%' ";
			}

			if(query != "")
			{
				conn.QueryString = "SELECT DISTINCT * FROM VW_LGAM_REQUEST_LIST WHERE 1=1 " + query + "ORDER BY SEQ";
				BindData(DATA_GRID.ID.ToString(), conn.QueryString);
			}

			else
			{
				conn.QueryString = "SELECT DISTINCT * FROM VW_LGAM_REQUEST_LIST ORDER BY SEQ";
				BindData(DATA_GRID.ID.ToString(), conn.QueryString);
			}
		}
	}
}
