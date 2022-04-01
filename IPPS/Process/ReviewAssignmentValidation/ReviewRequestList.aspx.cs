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


namespace SME.IPPS.Process.ReviewAssignmentValidation
{
	/// <summary>
	/// Summary description for ReviewRequestList.
	/// </summary>
	public partial class ReviewRequestList : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				PopulateDGrid();
			}
		}

		private void PopulateDGrid()
		{
			conn.QueryString="exec IPPS_Review_Assignment_Validation 'list','','','','','','" + Session["UserID"].ToString() + "'";
			
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			dg_list_initiation.DataSource = dt;

			try
			{
				dg_list_initiation.DataBind();
			}
			catch
			{
				dg_list_initiation.CurrentPageIndex = dg_list_initiation.PageCount - 1;
				dg_list_initiation.DataBind();
			}

			conn.ClearData();
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
			this.dg_list_initiation.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dg_list_initiation_ItemCommand);
			this.dg_list_initiation.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dg_list_initiation_ItemDataBound);

		}
		#endregion

		private void dg_list_initiation_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "view":						
					Response.Redirect("AssignmenttoPIC.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] 
					+ "&regno=" + e.Item.Cells[0].Text.Trim()+ 
					"&unit=" + e.Item.Cells[2].Text.Trim()+ "&initdate=" + e.Item.Cells[1].Text.Trim()+ 
					"&reqseq=" + e.Item.Cells[4].Text.Trim() + "&revseq=" + e.Item.Cells[5].Text.Trim());					
				break;				

				case "update":						
					conn.QueryString="exec IPPS_Review_Assignment_Validation 'updatestatus','"+ 
						e.Item.Cells[0].Text.Trim() +"','"+ e.Item.Cells[4].Text.Trim()
						+ "','"+ e.Item.Cells[5].Text.Trim() +"','','','"+ Session["UserID"].ToString() +"'";			
					conn.ExecuteQuery();
					PopulateDGrid();

				break;				
			}
		}

		private void dg_list_initiation_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) 
			{
				System.Web.UI.WebControls.LinkButton update=(System.Web.UI.WebControls.LinkButton)e.Item.FindControl("update");
				System.Web.UI.WebControls.LinkButton view=(System.Web.UI.WebControls.LinkButton)e.Item.FindControl("view");
				System.Web.UI.WebControls.Label LblAppr=(System.Web.UI.WebControls.Label)e.Item.FindControl("LBL_STATUS");
				System.Web.UI.WebControls.Image ImgAppr=(System.Web.UI.WebControls.Image)e.Item.FindControl("IMG_STATUS");

				//string aaaa = e.Item.Cells[1];

				tools.FormatDate(e.Item.Cells[1].Text,true);

				e.Item.Cells[1].Text=tools.FormatDate(e.Item.Cells[1].Text, true);
				string status=e.Item.Cells[6].Text;

				if (status=="0" || status=="1")
				{
					update.Visible = false;
					view.Visible=true;
					ImgAppr.ImageUrl = "../../../image/UnComplete.gif";
					LblAppr.Text = "Not Assign";
				}
				else if(status=="2" || status=="3")
				{
					update.Visible = false;
					view.Visible=true;
					ImgAppr.ImageUrl = "../../../image/Complete.gif";
					LblAppr.Text = "Assign";
				}
				else if(status=="4")
				{
					update.Visible = true;
					view.Visible=false;
					ImgAppr.ImageUrl = "../../../image/Complete.gif";
					LblAppr.Text = "Done";
				}			
                				
			}
		}
	}
}
