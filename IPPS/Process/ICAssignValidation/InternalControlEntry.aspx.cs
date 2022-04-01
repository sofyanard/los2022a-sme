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

namespace SME.IPPS.Process.ICAssignValidation
{
	/// <summary>
	/// Summary description for InternalControlEntry.
	/// </summary>
	public partial class InternalControlEntry : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../../SME/Restricted.aspx");

			ViewMenu();

			if(!IsPostBack)
			{
				viewData();
			}
		}

		private void viewData()
		{
			conn.QueryString = "SELECT * FROM VW_IPPS_ICENTRY_VIEWREQUEST WHERE IPPS_REGNO = '" + Request.QueryString["regno"] + "'";
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

		private void fillField(string req_seq)
		{
			conn.QueryString = "SELECT * FROM VW_IPPS_ICENTRY_VIEWDRAFTING WHERE IPPS_REGNO = '" + Request.QueryString["regno"] + "' AND REQ_SEQ = '"+ req_seq + "'";
			conn.ExecuteQuery();

			TXT_EDISI.Text = conn.GetFieldValue("DRAFT_EDITION");
			TXT_NAME.Text = conn.GetFieldValue("DRAFT_NAME");
			TXT_REVISI.Text = conn.GetFieldValue("DRAFT_REVISION"); 
			TXT_TGL_BERLAKU.Text = tools.FormatDate(conn.GetFieldValue("NEW_DATE"),true);
			TXT_TGL_DIGANTI.Text = tools.FormatDate(conn.GetFieldValue("OLD_DATE"),true); 
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

		private void SaveRevisiDraft(string reqseq,string cntseq,string revseq, string teks)
		{
			try
			{
				conn.QueryString = "exec IPPS_ICENTRY_SAVE '" +
					Request.QueryString["regno"] + "', '" +
					Session["UserID"].ToString() + "'";
				conn.ExecuteNonQuery();

				Response.Redirect("ReviewICList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
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

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '" + Request.QueryString["mc"] + "'";
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
							strtemp = "regno=" + Request.QueryString["regno"] +  "&tc=" + Request.QueryString["tc"] ;
						else	
							strtemp = "regno=" + Request.QueryString["regno"] +  "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i,3)+strtemp;
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
			this.DGR_DRAFTINFO.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_DRAFTINFO_ItemCommand);
			this.DGR_DRAFTINFO.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGR_DRAFTINFO_ItemDataBound);
			this.DGR_COINTAINNEW.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_COINTAINNEW_ItemCommand);
			this.DGR_CONTAINUPD.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_CONTAINUPD_ItemCommand);

		}
		#endregion

		protected void TXT_OUTLINENEW_TextChanged(object sender, System.EventArgs e)
		{
		
		}

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
	}
}
