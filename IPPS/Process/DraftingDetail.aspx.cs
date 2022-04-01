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

namespace SME.IPPS.Process
{
	/// <summary>
	/// Summary description for DraftingDetail.
	/// </summary>
	public partial class DraftingDetail : System.Web.UI.Page
	{

		protected Tools tool = new Tools();
		protected Connection conn;
		private string isnew;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			
			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
			//	Response.Redirect("../../Restricted.aspx");

			if (!IsPostBack)
			{
				DDL_OLD_DATE_MONTH.Items.Add(new ListItem("- SELECT -", ""));
				DDL_NEW_DATE_MONTH.Items.Add(new ListItem("- SELECT -", ""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_OLD_DATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_NEW_DATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				for (int i = 1; i <= 15; i++)
				{
					DDL_BAB.Items.Add(new ListItem(i.ToString(), i.ToString()));
				}

				ViewRequest(Request.QueryString["regno"], Request.QueryString["req"]);
				ViewDrafting(Request.QueryString["regno"], Request.QueryString["req"]);
				ViewOutline(Request.QueryString["regno"], Request.QueryString["req"]);
				ViewContain(Request.QueryString["regno"], Request.QueryString["req"]);
			}
		}

		private void ViewRequest(string regno, string reqseq)
		{
			conn.QueryString = "SELECT * FROM VW_IPPS_DRAFTING_VIEWREQUESTLIST WHERE IPPS_REGNO = '" + regno + "' AND REQ_SEQ = '" + reqseq + "' ORDER BY REQ_SEQ";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				LBL_REQ_DISP.Text = conn.GetFieldValue("DISP");
				
				isnew = conn.GetFieldValue("REQ_ISNEW");
				if (isnew == "1")
				{
					TXT_OLD_OUTLINE.Enabled = false;
				}
				else
				{
					TXT_OLD_OUTLINE.Enabled = true;
				}
			}
		}

		private void ViewDrafting(string regno, string reqseq)
		{
			try
			{
				conn.QueryString = "SELECT * FROM VW_IPPS_DRAFTING_VIEWDRAFTING WHERE IPPS_REGNO = '" + regno + "' AND REQ_SEQ = '" + reqseq + "' ORDER BY REQ_SEQ";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					TXT_DRAFT_NAME.Text = conn.GetFieldValue("DRAFT_NAME");
					TXT_DRAFT_EDITION.Text = conn.GetFieldValue("DRAFT_EDITION");
					TXT_DRAFT_REVISION.Text = conn.GetFieldValue("DRAFT_REVISION");
					TXT_OLD_DATE_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("OLD_DATE"));
					DDL_OLD_DATE_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("OLD_DATE"));
					TXT_OLD_DATE_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("OLD_DATE"));
					TXT_NEW_DATE_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("NEW_DATE"));
					DDL_NEW_DATE_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("NEW_DATE"));
					TXT_NEW_DATE_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("NEW_DATE"));
				}
			}
			catch {}
		}

		private void ViewOutline(string regno, string reqseq)
		{
			try
			{
				conn.QueryString = "SELECT * FROM VW_IPPS_DRAFTING_VIEWOUTLINE WHERE IPPS_REGNO = '" + regno + "' AND REQ_SEQ = '" + reqseq + "' ORDER BY REQ_SEQ";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					TXT_OLD_OUTLINE.Text = conn.GetFieldValue("OLD_OUTLINE");
					TXT_NEW_OUTLINE.Text = conn.GetFieldValue("NEW_OUTLINE");
				}
			}
			catch {}
		}

		private void ViewContain(string regno, string reqseq)
		{
			conn.QueryString = "SELECT * FROM VW_IPPS_INITIATION_VIEWCONTAIN WHERE IPPS_REGNO = '" + regno + "' AND REQ_SEQ = '" + reqseq + "' ORDER BY REQ_SEQ";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_CONTAIN.DataSource = dt;
			try 
			{
				DG_CONTAIN.DataBind();
			} 
			catch 
			{
				DG_CONTAIN.CurrentPageIndex = 0;
				DG_CONTAIN.DataBind();
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
			this.DG_CONTAIN.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DG_CONTAIN_ItemDataBound);

		}
		#endregion

		protected void BTN_SAVE_DRAFT_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "exec IPPS_DRAFTING_SAVEDRAFTING '" +
					Request.QueryString["regno"] + "', '" +
					Request.QueryString["req"] + "', '" +
					TXT_DRAFT_NAME.Text + "', '" +
					TXT_DRAFT_EDITION.Text + "', '" +
					TXT_DRAFT_REVISION.Text + "', " +
					tool.ConvertDate(TXT_OLD_DATE_DAY.Text, DDL_OLD_DATE_MONTH.SelectedValue, TXT_OLD_DATE_YEAR.Text) + ", " +
					tool.ConvertDate(TXT_NEW_DATE_DAY.Text, DDL_NEW_DATE_MONTH.SelectedValue, TXT_NEW_DATE_YEAR.Text);
				conn.ExecuteNonQuery();

				ViewDrafting(Request.QueryString["regno"], Request.QueryString["req"]);
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

		protected void BTN_SAVE_OUTLINE_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "exec IPPS_DRAFTING_SAVEOUTLINE '" +
					Request.QueryString["regno"] + "', '" +
					Request.QueryString["req"] + "', '" +
					TXT_OLD_OUTLINE.Text + "', '" +
					TXT_NEW_OUTLINE.Text + "'";
				conn.ExecuteNonQuery();

				ViewOutline(Request.QueryString["regno"], Request.QueryString["req"]);
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

		protected void btn_insert_jmlh_bab_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "exec IPPS_DRAFTING_INSERTBAB '" +
					Request.QueryString["regno"] + "', '" +
					Request.QueryString["req"] + "', '" +
					DDL_BAB.SelectedValue + "'";
				conn.ExecuteNonQuery();

				ViewContain(Request.QueryString["regno"], Request.QueryString["req"]);
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

		private void DG_CONTAIN_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			switch (e.Item.ItemType)
			{
				case ListItemType.AlternatingItem:
				case ListItemType.EditItem:
				case ListItemType.Item:
				case ListItemType.SelectedItem:
					try
					{
						TextBox tb_old = (TextBox)e.Item.Cells[5].FindControl("TXT_OLD_CONTAIN");
						tb_old.Text = e.Item.Cells[4].Text.ToString().Replace("&nbsp;","");
						if (isnew == "1")
						{
							tb_old.Enabled = false;
						}
						else
						{
							tb_old.Enabled = true;
						}

						TextBox tb_new = (TextBox)e.Item.Cells[7].FindControl("TXT_NEW_CONTAIN");
						tb_new.Text = e.Item.Cells[6].Text.ToString().Replace("&nbsp;","");
					} 
					catch {}
					break;
				case ListItemType.Footer:
					break;
				default:
					break;
			}
		}

		protected void BTN_SAVE_CONTAIN_Click(object sender, System.EventArgs e)
		{
			try
			{
				for (int i=0; i<DG_CONTAIN.Items.Count; i++)
				{
					TextBox tb_old = (TextBox) DG_CONTAIN.Items[i].Cells[5].FindControl("TXT_OLD_CONTAIN");
					TextBox tb_new = (TextBox) DG_CONTAIN.Items[i].Cells[7].FindControl("TXT_NEW_CONTAIN");
					
					if ((tb_old != null) && (tb_new != null))
					{
						conn.QueryString = "exec IPPS_DRAFTING_SAVECONTAIN '" +
							DG_CONTAIN.Items[i].Cells[0].Text.Trim() + "', '" +
							DG_CONTAIN.Items[i].Cells[1].Text.Trim() + "', '" +
							DG_CONTAIN.Items[i].Cells[2].Text.Trim() + "', '" +
							tb_old.Text + "', '" +
							tb_new.Text + "'";
						conn.ExecuteNonQuery();
					}
				}

				ViewContain(Request.QueryString["regno"], Request.QueryString["req"]);
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
	}
}
