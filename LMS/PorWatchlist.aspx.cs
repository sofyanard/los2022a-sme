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

namespace SME.LMS
{
	/// <summary>
	/// Summary description for PorWatchlist.
	/// </summary>
	public partial class PorWatchlist : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				ViewAcquireInfo();
				BindDataWatchlist();
				SetButton();
				FillDDLWewenang();
				FillDDLForward();
				FillDDLAdvis();
			}

			ViewMenu();
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				string mc1 = Request.QueryString["mc"];
				string mc2 = Request.QueryString["mc"];
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "porlmsreg="+Request.QueryString["porlmsreg"]+"&scr="+Request.QueryString["scr"];
						else	strtemp = "porlmsreg="+Request.QueryString["porlmsreg"]+"&mc="+Request.QueryString["mc"]+"&scr="+Request.QueryString["scr"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
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

		private void BindDataWatchlist()
		{
			conn.QueryString = "SELECT * FROM VW_PORLMSWATCHLIST_BINDDATA WHERE PORLMS_REGNO = '" + Request.QueryString["porlmsreg"] + "' ORDER BY CU_NAME";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_PORWATCH.DataSource = dt;
			try 
			{
				DG_PORWATCH.DataBind();
			}
			catch 
			{
				DG_PORWATCH.CurrentPageIndex = 0;
				DG_PORWATCH.DataBind();
			}

			BindDataWatchlist2();
		}

		private void BindDataWatchlist2()
		{
			for (int i=0;i<DG_PORWATCH.Items.Count;i++)
			{
				DropDownList ddlacc = (DropDownList) DG_PORWATCH.Items[i].Cells[6].FindControl("DDL_ACCSTRAT");
				GlobalTools.fillRefList(ddlacc,"SELECT * FROM PORLMS_RFACCOUNTSTRATEGY ",false,conn);
				try {ddlacc.SelectedValue = DG_PORWATCH.Items[i].Cells[5].Text;}
				catch {}

				TextBox txtday = (TextBox) DG_PORWATCH.Items[i].Cells[8].FindControl("TXT_TARGET_PELAKSANAAN_DAY");
				DropDownList ddlmonth = (DropDownList) DG_PORWATCH.Items[i].Cells[8].FindControl("DDL_TARGET_PELAKSANAAN_MONTH");
				TextBox txtyear = (TextBox) DG_PORWATCH.Items[i].Cells[8].FindControl("TXT_TARGET_PELAKSANAAN_YEAR");
				ddlmonth.Items.Add(new ListItem("- SELECT -", ""));
				for (int j = 1; j <= 12; j++)
				{
					ddlmonth.Items.Add(new ListItem(DateAndTime.MonthName(j, false), j.ToString()));
				}
				txtday.Text = tool.FormatDate_Day(DG_PORWATCH.Items[i].Cells[7].Text);
				try {ddlmonth.SelectedValue = tool.FormatDate_Month(DG_PORWATCH.Items[i].Cells[7].Text);}
				catch {}
				txtyear.Text = tool.FormatDate_Year(DG_PORWATCH.Items[i].Cells[7].Text);
			}
		}

		private void SetButton()
		{
			conn.QueryString = "EXEC PORLMS_WATCHLIST_SETBUTTON '" + 
				Request.QueryString["porlmsreg"] + "', '" +
				Session["UserID"].ToString() + "', '" +
				Request.QueryString["scr"] + "'";
			conn.ExecuteQuery();
			
			if (conn.GetRowCount() > 0)
			{
				if (conn.GetFieldValue("SAVE_CHECKING") == "1")
				{
					TR_CHECK.Visible = true;
				}
				else
				{
					TR_CHECK.Visible = false;
				}

				if (conn.GetFieldValue("SAVE_WEWENANG") == "1")
				{
					DDL_WEWENANG.Enabled = true;
					DDL_WEWENANG.CssClass = "mandatory";
					BTN_SAVE.Visible = true;
				}
				else
				{
					DDL_WEWENANG.Enabled = false;
					DDL_WEWENANG.CssClass = "";
					BTN_SAVE.Visible = false;
				}

				if (conn.GetFieldValue("PROCEED_TO_ACCEPTANCE") == "1")
				{
					TR_UPDATE.Visible = true;
				}
				else
				{
					TR_UPDATE.Visible = false;
				}

				if (conn.GetFieldValue("ADVIS") == "1")
				{
					TR_ADVIS.Visible = true;
				}
				else
				{
					TR_ADVIS.Visible = false;
				}

				if (conn.GetFieldValue("ADVIS_REPLY") == "1")
				{
					TR_ADVISREPLY.Visible = true;
				}
				else
				{
					TR_ADVISREPLY.Visible = false;
				}

				if (conn.GetFieldValue("APPROVAL_FORWARD_TO") == "1")
				{
					TR_FORWARD.Visible = true;
				}
				else
				{
					TR_FORWARD.Visible = false;
				}

				if (conn.GetFieldValue("APPROVE") == "1")
				{
					TR_ACCEPT.Visible = true;
				}
				else
				{
					TR_ACCEPT.Visible = false;
				}

				if (conn.GetFieldValue("ACQUIRE_INFO") == "1")
				{
					TR_ACQINFO2.Visible = true;
				}
				else
				{
					TR_ACQINFO2.Visible = false;
				}
			}
		}

		private void FillDDLWewenang()
		{
			conn.QueryString = "exec PORLMS_WATCHLIST_FILLDDLWEWENANG '" + Request.QueryString["porlmsreg"] + "', '" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_WEWENANG.Items.Add(new ListItem(conn.GetFieldValue(i,"USERNAME"),conn.GetFieldValue(i,"USERID")));
			}
		}

		private void FillDDLForward()
		{
			conn.QueryString = "exec PORLMS_WATCHLIST_FILLDDLFORWARD '" + Request.QueryString["porlmsreg"] + "', '" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_FORWARD.Items.Add(new ListItem(conn.GetFieldValue(i,"USERNAME"),conn.GetFieldValue(i,"USERID")));
			}
		}

		private void FillDDLAdvis()
		{
			conn.QueryString = "exec PORLMS_WATCHLIST_FILLDDLADVIS '" + Request.QueryString["porlmsreg"] + "', '" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_ADVIS.Items.Add(new ListItem(conn.GetFieldValue(i,"USERNAME"),conn.GetFieldValue(i,"USERID")));
			}
		}

		private void SaveRemark()
		{
			try
			{
				conn.QueryString = "UPDATE PORLMS_APPLICATION SET PORLMS_APRVREMARK = '" + TXT_REMARK.Text + 
					"' WHERE PORLMS_REGNO = '" + Request.QueryString["porlmsreg"] + "'";
				conn.ExecuteQuery();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		private void ViewAcquireInfo()
		{
			conn.QueryString = "SELECT PORLMS_ACQINFO FROM PORLMS_APPLICATION WHERE PORLMS_REGNO = '" + Request.QueryString["porlmsreg"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				string textacqinfo = conn.GetFieldValue("PORLMS_ACQINFO");

				if (textacqinfo != "")
				{
					TR_ACQINFO.Visible = true;
					TR_ACQINFO1.Visible = true;
					TXT_ACQINFO.Text = textacqinfo;
				}
				else
				{
					TR_ACQINFO.Visible = false;
					TR_ACQINFO1.Visible = false;
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
			this.DG_PORWATCH.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_PORWATCH_PageIndexChanged);

		}
		#endregion

		protected void BTN_SAVESUMM_Click(object sender, System.EventArgs e)
		{
			try
			{
				for (int i = 0; i < DG_PORWATCH.Items.Count; i++)
				{
					DropDownList ddlacc = (DropDownList) DG_PORWATCH.Items[i].Cells[6].FindControl("DDL_ACCSTRAT");
					TextBox txtday = (TextBox) DG_PORWATCH.Items[i].Cells[8].FindControl("TXT_TARGET_PELAKSANAAN_DAY");
					DropDownList ddlmonth = (DropDownList) DG_PORWATCH.Items[i].Cells[8].FindControl("DDL_TARGET_PELAKSANAAN_MONTH");
					TextBox txtyear = (TextBox) DG_PORWATCH.Items[i].Cells[8].FindControl("TXT_TARGET_PELAKSANAAN_YEAR");

					string tgltarget = "''";
					if ((txtday.Text.Trim() != "") || (ddlmonth.SelectedValue.Trim() != "") || (txtyear.Text.Trim() != ""))
						if (!GlobalTools.isDateValid(this, txtday.Text.Trim(), ddlmonth.SelectedValue, txtyear.Text.Trim()))
						{
							GlobalTools.popMessage(this, "Tanggal tidak valid!");
							return;
						}
						else
						{
							tgltarget = tool.ConvertDate(txtday.Text, ddlmonth.SelectedValue, txtyear.Text);
						}

					conn.QueryString = "EXEC PORLMSWATCHLIST_SAVEDATASUMMARY '" + DG_PORWATCH.Items[i].Cells[1].Text.Trim() + "', '" + 
						ddlacc.SelectedValue.Trim() + "', " + tgltarget;
					conn.ExecuteQuery();
				}

				BindDataWatchlist();
			}
			catch (Exception ex)
			{
				GlobalTools.popMessage(this, "Save Error!");
				Response.Write("<!--" + ex.Message + "-->");
				return;
			}
		}

		private void DG_PORWATCH_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_PORWATCH.CurrentPageIndex = e.NewPageIndex;
			BindDataWatchlist();
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			SaveRemark();

			try
			{
				conn.QueryString = "exec PORLMS_WATCHLIST_SAVE '" + 
					Request.QueryString["porlmsreg"] + "', '" +
					DDL_WEWENANG.SelectedValue + "'";
				conn.ExecuteQuery();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			if (DDL_WEWENANG.SelectedValue == "" || DDL_WEWENANG.SelectedValue == null)
			{
				GlobalTools.popMessage(this, "Wewenang Memutus tidak boleh kosong!");
				return;
			}

			SaveRemark();
			
			try
			{
				conn.QueryString = "exec PORLMS_WATCHLIST_FORWARDTOACCEPTANCE '" + 
					Request.QueryString["porlmsreg"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "', '" +
					DDL_WEWENANG.SelectedValue + "'";
				conn.ExecuteQuery();
				string msg = conn.GetFieldValue("MSG");

				Response.Redirect("PorSearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&msg=" + msg +
					"&scr=" + Request.QueryString["scr"]);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		protected void BTN_ADVIS_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			try
			{
				conn.QueryString = "exec PORLMS_WATCHLIST_ADVIS '" + 
					Request.QueryString["porlmsreg"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "', '" +
					DDL_ADVIS.SelectedValue + "'";
				conn.ExecuteQuery();
				string msg = conn.GetFieldValue("MSG");

				Response.Redirect("PorSearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&msg=" + msg +
					"&scr=" + Request.QueryString["scr"]);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		protected void BTN_ADVISREPLY_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			try
			{
				conn.QueryString = "exec PORLMS_WATCHLIST_ADVISREPLY '" + 
					Request.QueryString["porlmsreg"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "'";
				conn.ExecuteQuery();
				string msg = conn.GetFieldValue("MSG");

				Response.Redirect("PorSearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&msg=" + msg +
					"&scr=" + Request.QueryString["scr"]);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		protected void BTN_FORWARD_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			try
			{
				conn.QueryString = "exec PORLMS_WATCHLIST_FORWARD '" + 
					Request.QueryString["porlmsreg"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "', '" +
					DDL_FORWARD.SelectedValue + "'";
				conn.ExecuteQuery();
				string msg = conn.GetFieldValue("MSG");

				Response.Redirect("PorSearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&msg=" + msg +
					"&scr=" + Request.QueryString["scr"]);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		protected void BTN_ACCEPT_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			try
			{
				conn.QueryString = "exec PORLMS_WATCHLIST_ACCEPT '" + 
					Request.QueryString["porlmsreg"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "'";
				conn.ExecuteQuery();
				string msg = conn.GetFieldValue("MSG");

				Response.Redirect("PorSearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&msg=" + msg +
					"&scr=" + Request.QueryString["scr"]);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		protected void BTN_ACQINFO_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			Response.Write("<script for=window event=onload language='javascript'>PopupPage('PorAcqInfo.aspx?porlmsreg=" + Request.QueryString["porlmsreg"] + "&tc=" + Request.QueryString["tc"] + "&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>");
		}

		protected void TXT_TEMP_TextChanged(object sender, System.EventArgs e)
		{
			if (TXT_TEMP.Text != "") 
			{
				string msg = "";
				msg = TXT_TEMP.Text;
				Response.Redirect("PorSearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&msg=" + msg +
					"&scr=" + Request.QueryString["scr"]);
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string url = "PorSearchCustomer.aspx?mc=" + Request.QueryString["mc"];
			if (Request.QueryString["tc"] != "")
			{
				url = url + "&tc=" + Request.QueryString["tc"];
			}
			if (Request.QueryString["scr"] != "")
			{
				url = url + "&scr=" + Request.QueryString["scr"];
			}
			Response.Redirect(url);
		}
	}
}
