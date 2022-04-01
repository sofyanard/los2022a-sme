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
	/// Summary description for ReviewEntry.
	/// </summary>
	public partial class ReviewEntry : System.Web.UI.Page
	{

		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				viewData();
			}
		}


		private void viewData()
		{
			conn.QueryString="select * from ipps_request where ipps_regno='"+ Request.QueryString["regno"] +"'";
			conn.ExecuteQuery();
            
			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			DGR_DRAFTINFO.DataSource = dt;

			try
			{
				DGR_DRAFTINFO.DataBind();
			}
			catch
			{
				DGR_DRAFTINFO.CurrentPageIndex = DGR_DRAFTINFO.PageCount - 1;
				DGR_DRAFTINFO.DataBind();
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
			this.DGR_DRAFTINFO.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_DRAFTINFO_ItemCommand);
			this.DGR_DRAFTINFO.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGR_DRAFTINFO_ItemDataBound);
			this.DGR_COINTAINNEW.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_COINTAINNEW_ItemCommand);
			this.DGR_CONTAINUPD.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_CONTAINUPD_ItemCommand);

		}
		#endregion

		private void DGR_DRAFTINFO_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
                    fillField(e.Item.Cells[0].Text);					
				break;
			}
			
		}

		private void DGR_DRAFTINFO_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) 
			{
				System.Web.UI.WebControls.LinkButton link=(System.Web.UI.WebControls.LinkButton)e.Item.FindControl("link");
				System.Web.UI.WebControls.Label LblAppr=(System.Web.UI.WebControls.Label)e.Item.FindControl("lbl");

				LblAppr.Text=e.Item.Cells[1].Text;
				link.Text=e.Item.Cells[2].Text;			
				
			}
		}

		private void fillField(string req_seq)
		{
			conn.QueryString="select * from ipps_drafting where ipps_regno='"+ Request.QueryString["regno"] +"' and req_seq='"+ req_seq +"'";
			conn.ExecuteQuery();

			TXT_EDISI.Text=conn.GetFieldValue("draft_edition");
            TXT_NAME.Text=conn.GetFieldValue("draft_name");
			TXT_REVISI.Text=conn.GetFieldValue("draft_revision"); 
			TXT_TGL_BERLAKU.Text=tools.FormatDate(conn.GetFieldValue("new_date"),true);
			TXT_TGL_DIGANTI.Text=tools.FormatDate(conn.GetFieldValue("old_date"),true); 
            populateGridOutline1(req_seq);
			lbl_reqseq.Text=req_seq;
		}

		private void populateGridOutline1(string req_seq)
		{
			conn.QueryString="select * from ipps_outline where ipps_regno='"+ Request.QueryString["regno"] +"' and req_seq='"+ req_seq +"'";
			conn.ExecuteQuery();


			TXT_OUTLINENEW.Text=conn.GetFieldValue("new_outline"); 

			TXT_EXISTING.Text=conn.GetFieldValue("old_outline"); 
			TXT_REVISE.Text=conn.GetFieldValue("new_outline"); 

			if (conn.GetFieldValue("old_outline")=="")
			{
				TR_COINTAIN_NEW.Visible=true;
				TR_CONTAIN_UPDATE.Visible=false;
				TR_OUTLINE_NEW.Visible=true;
				TR_OUTLINE_UPDATE.Visible=false;
			}

			else
			{
				TR_COINTAIN_NEW.Visible=false;
				TR_CONTAIN_UPDATE.Visible=true;
				TR_OUTLINE_NEW.Visible=false;
				TR_OUTLINE_UPDATE.Visible=true;
			}

			conn.QueryString="select * from ipps_contain where ipps_regno='"+ Request.QueryString["regno"] +"' and req_seq='"+ req_seq +"'";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			DGR_COINTAINNEW.DataSource = dt;

			try
			{
				DGR_COINTAINNEW.DataBind();
			}
			catch
			{
				DGR_COINTAINNEW.CurrentPageIndex = DGR_COINTAINNEW.PageCount - 1;
				DGR_COINTAINNEW.DataBind();
			}


			DGR_CONTAINUPD.DataSource = dt;

			try
			{
				DGR_CONTAINUPD.DataBind();
			}
			catch
			{
				DGR_CONTAINUPD.CurrentPageIndex = DGR_CONTAINUPD.PageCount - 1;
				DGR_CONTAINUPD.DataBind();
			}

			conn.ClearData();
		}

		
		private void DGR_COINTAINNEW_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((Button)e.CommandSource).CommandName)
			{
				case "klik":
					System.Web.UI.WebControls.TextBox teks=(System.Web.UI.WebControls.TextBox)e.Item.FindControl("TXT_REVIEW");
					SaveRevisiDraft(lbl_reqseq.Text,e.Item.Cells[0].Text,Request.QueryString["revseq"],teks.Text);
				break;
			}	
		}

		private void DGR_CONTAINUPD_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((Button)e.CommandSource).CommandName)
			{
				case "klik":
					System.Web.UI.WebControls.TextBox teks=(System.Web.UI.WebControls.TextBox)e.Item.FindControl("TXT_REVIEW_UP");
					SaveRevisiDraft(lbl_reqseq.Text,e.Item.Cells[0].Text,Request.QueryString["revseq"],teks.Text);
				break;
			}	
		}

		private void SaveRevisiDraft(string reqseq,string cntseq,string revseq, string teks)
		{
			conn.QueryString="exec IPPS_Review_Assignment_Validation 'review','" +
				Request.QueryString["regno"] +"','" + 
				reqseq + "','" + 
				revseq + "','" +
				cntseq + "','" +
				teks + "','"+ Session["UserID"].ToString() +"'";			
			conn.ExecuteQuery();

		}
	}
}
