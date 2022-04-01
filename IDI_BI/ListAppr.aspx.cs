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

namespace SME.IDI_BI
{
	/// <summary>
	/// Summary description for ListAppr.
	/// </summary>
	public partial class ListAppr : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			if (!IsPostBack)
			{
				conn.QueryString="select * from bi_request where idi_req#='" + Request.QueryString["regnum"] + "' and idi_choose='1' and idi_status='1' order by idi_reqdate desc";
				conn.ExecuteQuery();
				FillGrid();

				string idi_choose;
				idi_choose = conn.GetFieldValue("idi_choose");

				BTN_APPROVE.Enabled = false;

				for (int i = 0; i < DGR_RESULT.Items.Count; i++)
				{					
					CheckBox checkbox = (CheckBox)DGR_RESULT.Items[i].Cells[8].FindControl("check");
					if (idi_choose == "0")
					{
						checkbox.Checked = false;
					}
					else
					{
						checkbox.Checked = true;
					}
				}

			}		
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_RESULT.DataSource = dt;
			try 
			{
				DGR_RESULT.DataBind();
			} 
			catch 
			{
				DGR_RESULT.CurrentPageIndex = 0;
				DGR_RESULT.DataBind();
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

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < DGR_RESULT.Items.Count; i++)
			{					
				CheckBox checkbox = (CheckBox)DGR_RESULT.Items[i].Cells[8].FindControl("check");				
				
				string choose = null;					
				if(checkbox.Checked == false)
				{
					choose = "0";
				}
				else
				{
					choose = "1";						
				}

				if(choose == "1")
				{
					conn.QueryString = "delete bi_request where idi_req#='" +
						DGR_RESULT.Items[i].Cells[3].Text.Trim() + "' and idi_surat_seq#= '" +
						DGR_RESULT.Items[i].Cells[0].Text.Trim() + "' ";			
					conn.ExecuteQuery();
				}
			}
			/*conn.QueryString = "delete bi_request where idi_req='" + Request.QueryString["regnum"] + "' ";
			conn.ExecuteQuery();*/
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < DGR_RESULT.Items.Count; i++)
			{					
				CheckBox checkbox = (CheckBox)DGR_RESULT.Items[i].Cells[8].FindControl("check");				
				
				string choose = null;					
				if(checkbox.Checked == false)
				{
					choose = "0";
				}
				else
				{
					choose = "1";						
				}

				conn.QueryString = "update bi_request set idi_choose='"+choose+"' where idi_req#='" +
					DGR_RESULT.Items[i].Cells[3].Text.Trim() + "' and idi_surat_seq#= '" +
					DGR_RESULT.Items[i].Cells[0].Text.Trim() + "' ";			
				conn.ExecuteQuery();

				BTN_APPROVE.Enabled = true;				
			}
		}

		protected void BTN_APPROVE_Click(object sender, System.EventArgs e)
		{
			//conn.QueryString = "update bi_request set idi_status='2' where idi_req#='"+ Request.QueryString["regnum"]+"' and idi_choose='1'";
			//conn.ExecuteQuery();

			conn.QueryString = "exec IDI_TRACKUPDATE '" + 
				Request.QueryString["regnum"] + "', '" +
				Request.QueryString["tc"] + "', '" +
				Session["UserID"].ToString() + "' ";				
			conn.ExecuteNonQuery();		
			
			for (int i = 0; i < DGR_RESULT.Items.Count; i++)
			{					
				CheckBox checkbox = (CheckBox)DGR_RESULT.Items[i].Cells[8].FindControl("check");									
				if(checkbox.Checked == true)
				{
					conn.QueryString = "exec IDI_BI_APPROVE '" +
						DGR_RESULT.Items[i].Cells[3].Text.Trim() + "', '" +
						DGR_RESULT.Items[i].Cells[0].Text.Trim() + "', '" +
						Session["UserID"].ToString() + "' ";			
					conn.ExecuteQuery();	
				}							
			}			
			Response.Redirect("ApprBIRes.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

	}
}
