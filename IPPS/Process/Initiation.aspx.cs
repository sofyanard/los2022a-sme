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
	/// Summary description for Initiation.
	/// </summary>
	public partial class Initiation : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			ViewMenu();

			if (!IsPostBack)
			{
				DDL_BLN_tar_date.Items.Add(new ListItem("- SELECT -", ""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_BLN_tar_date.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				ddl_select_policy.Items.Add(new ListItem("- SELECT -", ""));
				conn.QueryString = "SELECT * FROM VW_IPPS_RFEXISTINGPOLICY";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					ddl_select_policy.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				ddl_req_type.Items.Add(new ListItem("- SELECT -", ""));
				conn.QueryString = "SELECT * FROM VW_IPPS_RFREQUESTTYPE";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					ddl_req_type.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				ddl_pol_type.Items.Add(new ListItem("- SELECT -", ""));
				conn.QueryString = "SELECT * FROM VW_IPPS_RFPOLICYTYPE";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					ddl_pol_type.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				ddl_req_pur.Items.Add(new ListItem("- SELECT -", ""));
				conn.QueryString = "SELECT * FROM VW_IPPS_RFREQUESTPURPOSE";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					ddl_req_pur.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				ViewGeneral();
				ViewRequest();
			}
		}

		private void ViewGeneral()
		{
			try
			{
				conn.QueryString = "SELECT * FROM VW_IPPS_INITIATION_VIEWGENERAL WHERE IPPS_REGNO = '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				TXT_reference.Text = conn.GetFieldValue("IPPS_REGNO");
				TXT_unit.Text = conn.GetFieldValue("BRANCH_NAME");
				TXT_request_date.Text = conn.GetFieldValue("INIT_DATE");
			}
			catch {}
		}

		private void ViewRequest()
		{
			conn.QueryString = "SELECT * FROM VW_IPPS_INITIATION_VIEWREQUEST WHERE IPPS_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			dg_list_request.DataSource = dt;
			try 
			{
				dg_list_request.DataBind();
			} 
			catch 
			{
				dg_list_request.CurrentPageIndex = 0;
				dg_list_request.DataBind();
			}
		}

		private void ClearRequestEntry()
		{
			LBL_REQ_SEQ.Text = "";
			try { ddl_select_policy.SelectedValue = ""; }
			catch {}
			try { ddl_req_type.SelectedValue = ""; }
			catch {}
			try { ddl_pol_type.SelectedValue = ""; }
			catch {}
			try { ddl_req_pur.SelectedValue = ""; }
			catch {}
			txt_tgl_tar_date.Text = "";
			try { DDL_BLN_tar_date.SelectedValue = ""; }
			catch {}
			TXT_THN_tar_date.Text = "";
			txt_remark.Text = "";
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
			this.dg_list_request.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dg_list_request_ItemCommand);
			this.DATA_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_ItemCommand);

		}
		#endregion

		protected void BTN_Insert_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "exec IPPS_INITIATION_REQUEST_SAVE '1', '" +
					Request.QueryString["regno"] + "', '" +
					LBL_REQ_SEQ.Text + "', '" +
					rdo_req_info.SelectedValue + "', '" +
					ddl_req_type.SelectedValue + "', '" +
					ddl_select_policy.SelectedValue + "', '" +
					ddl_pol_type.SelectedValue + "', '" +
					ddl_req_pur.SelectedValue + "', " +
					tool.ConvertDate(txt_tgl_tar_date.Text, DDL_BLN_tar_date.SelectedValue, TXT_THN_tar_date.Text) + ", '" +
					txt_remark.Text + "'";
				conn.ExecuteNonQuery();

				ViewRequest();
				ClearRequestEntry();
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

		protected void BTN_clear_Click(object sender, System.EventArgs e)
		{
			ClearRequestEntry();
		}

		protected void btn_update_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "exec IPPS_INITIATION_UPDATESTATUS '" +
					Request.QueryString["regno"] + "', '" +
					Session["UserID"].ToString() + "'";
				conn.ExecuteNonQuery();

				Response.Redirect("ListInitiation.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
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

		protected void rdo_req_info_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (rdo_req_info.SelectedValue == "1")
			{
				try
				{
					ddl_select_policy.SelectedValue = "";
				}
				catch
				{
					ddl_select_policy.SelectedValue = "";
				}
				ddl_select_policy.Enabled = false;
				
				try
				{
					ddl_req_type.SelectedValue = "01";
				}
				catch
				{
					ddl_req_type.SelectedValue = "";
				}
				ddl_req_type.Enabled = false;
			}
			else if (rdo_req_info.SelectedValue == "2")
			{
				try
				{
					ddl_select_policy.SelectedValue = "";
				}
				catch
				{
					ddl_select_policy.SelectedValue = "";
				}
				ddl_select_policy.Enabled = true;
				
				try
				{
					ddl_req_type.SelectedValue = "";
				}
				catch
				{
					ddl_req_type.SelectedValue = "";
				}
				ddl_req_type.Enabled = true;
			}
			else
			{
				try
				{
					ddl_select_policy.SelectedValue = "";
				}
				catch
				{
					ddl_select_policy.SelectedValue = "";
				}
				ddl_select_policy.Enabled = true;
				
				try
				{
					ddl_req_type.SelectedValue = "";
				}
				catch
				{
					ddl_req_type.SelectedValue = "";
				}
				ddl_req_type.Enabled = true;
			}
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
		
		}

		private void dg_list_request_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					LBL_REQ_SEQ.Text = e.Item.Cells[1].Text;
					try { rdo_req_info.SelectedValue = e.Item.Cells[2].Text; } 
					catch {}
					try { ddl_select_policy.SelectedValue = e.Item.Cells[5].Text; }
					catch {}
					try { ddl_req_type.SelectedValue = e.Item.Cells[3].Text; }
					catch {}
					try { ddl_pol_type.SelectedValue = e.Item.Cells[7].Text; }
					catch {}
					try { ddl_req_pur.SelectedValue = e.Item.Cells[9].Text; }
					catch {}
					txt_tgl_tar_date.Text = tool.FormatDate_Day(e.Item.Cells[11].Text);
					try { DDL_BLN_tar_date.SelectedValue = tool.FormatDate_Month(e.Item.Cells[11].Text); }
					catch {}
					TXT_THN_tar_date.Text = tool.FormatDate_Year(e.Item.Cells[11].Text);
					txt_remark.Text = e.Item.Cells[12].Text;

					break;

				case "delete":
					try
					{
						conn.QueryString = "exec IPPS_INITIATION_REQUEST_SAVE '2', '" +
							Request.QueryString["regno"] + "', '" +
							e.Item.Cells[1].Text + "', '" +
							/* e.Item.Cells[2].Text + */ "', '" +
							/* e.Item.Cells[3].Text + */ "', '" +
							/* e.Item.Cells[5].Text + */ "', '" +
							/* e.Item.Cells[7].Text + */ "', '" +
							/* e.Item.Cells[9].Text + */ "', '" +
							/* e.Item.Cells[11].Text + */ "', '" +
							/* e.Item.Cells[12].Text + */ "'";
						conn.ExecuteNonQuery();

						ViewRequest();
						ClearRequestEntry();
					}
					catch (Exception ex)
					{
						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						return;
					}

					break;
			}
		}
	}
}
