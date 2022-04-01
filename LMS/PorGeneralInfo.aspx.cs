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
	/// Summary description for PorGeneralInfo.
	/// </summary>
	public partial class PorGeneralInfo : System.Web.UI.Page
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
			}

			ViewMenu();
			InitializeEvent();
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
			conn.QueryString = "SELECT * FROM VW_PORLMSGENERALINFO_BINDDATA WHERE PORLMS_REGNO = '" + Request.QueryString["porlmsreg"] + "' ORDER BY CU_NAME";
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

			BindDataAccount();
			BindDataQualitative();
			BindDataWatchlistResult();
		}

		private void BindDataAccount()
		{
			for (int i=0;i<DG_PORWATCH.Items.Count;i++)
			{
				DataGrid dgacc = (DataGrid) DG_PORWATCH.Items[i].Cells[5].FindControl("DG_ACCOUNT");

				conn.QueryString = "SELECT * FROM VW_PORLMSGENERALINFO_BINDDATAACCOUNT WHERE LMS_REGNO = '" + DG_PORWATCH.Items[i].Cells[1].Text.Trim() + "' ORDER BY ACC_NO";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtacc = new DataTable();
					dtacc = conn.GetDataTable().Copy();
					dgacc.DataSource = dtacc;
					try 
					{
						dgacc.DataBind();
					} 
					catch 
					{
						dgacc.CurrentPageIndex = 0;
						dgacc.DataBind();
					}
				}
			}
		}

		private void BindDataQualitative()
		{
			for (int i=0;i<DG_PORWATCH.Items.Count;i++)
			{
				DataGrid dgqual = (DataGrid) DG_PORWATCH.Items[i].Cells[5].FindControl("DG_QUAL");

				conn.QueryString = "EXEC PORLMSGENERALINFO_BINDDATAQUALITATIVE '" + DG_PORWATCH.Items[i].Cells[1].Text.Trim() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtqual = new DataTable();
					dtqual = conn.GetDataTable().Copy();
					dgqual.DataSource = dtqual;
					try 
					{
						dgqual.DataBind();
					} 
					catch 
					{
						dgqual.CurrentPageIndex = 0;
						dgqual.DataBind();
					}
				}
			}
		}

		private void BindDataWatchlistResult()
		{
			for (int i=0;i<DG_PORWATCH.Items.Count;i++)
			{
				conn.QueryString = "EXEC PORLMS_CHECKWATCHLIST '" + DG_PORWATCH.Items[i].Cells[1].Text.Trim() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					if (conn.GetFieldValue("WATCHLIST_RESULT") == "1")
					{
						DG_PORWATCH.Items[i].Cells[7].ForeColor = Color.Red;
						DG_PORWATCH.Items[i].Cells[7].Text = "Watchlist";
					}
					else if (conn.GetFieldValue("WATCHLIST_RESULT") == "0")
					{
						DG_PORWATCH.Items[i].Cells[7].ForeColor = Color.Green;
						DG_PORWATCH.Items[i].Cells[7].Text = "Non Watchlist";
					}
					else
					{
						DG_PORWATCH.Items[i].Cells[7].ForeColor = Color.Black;
						DG_PORWATCH.Items[i].Cells[7].Text = "";
					}
				}
			}
		}

		private void UpdateDataWatchlist()
		{
			string lms_regno, isporwatchlist, watchlist_reason;

			for (int i=0;i<DG_PORWATCH.Items.Count;i++)
			{
				conn.QueryString = "EXEC PORLMS_CHECKWATCHLIST '" + DG_PORWATCH.Items[i].Cells[1].Text.Trim() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					lms_regno = DG_PORWATCH.Items[i].Cells[1].Text.Trim();
					isporwatchlist = conn.GetFieldValue("WATCHLIST_RESULT");
					watchlist_reason = conn.GetFieldValue("WATCHLIST_REASON");
					
					conn.QueryString = "EXEC PORLMS_UPDATEWATCHLIST '" + lms_regno + "', '" + isporwatchlist + "', '" + watchlist_reason + "'";
					conn.ExecuteQuery();
				}
			}
		}

		private void SetButton()
		{
			conn.QueryString = "EXEC PORLMSGENERALINFO_SETBUTTON '" + 
				Request.QueryString["porlmsreg"] + "', '" +
				Session["UserID"].ToString() + "', '" +
				Request.QueryString["scr"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				if (conn.GetFieldValue("CHECKING") == "1")
				{
					TR_CHECK.Visible = true;
				}
				else
				{
					TR_CHECK.Visible = false;
				}

				if (conn.GetFieldValue("CHECKING_RESULT") == "1")
				{
					TR_REV.Visible = true;
				}
				else
				{
					TR_REV.Visible = false;
				}

				if (conn.GetFieldValue("FORWARD_TO_LOANREVIEW") == "1")
				{
					BTN_FWDTOLOANREV.Visible = true;
				}
				else
				{
					BTN_FWDTOLOANREV.Visible = false;
				}

				if (conn.GetFieldValue("FORWARD_TO_WATCHLIST") == "1")
				{
					BTN_FWDTOWATCH.Visible = true;
				}
				else
				{
					BTN_FWDTOWATCH.Visible = false;
				}

				if (conn.GetFieldValue("NO_REVIEW") == "1")
				{
					BTN_NOREVIEW.Visible = true;
				}
				else
				{
					BTN_NOREVIEW.Visible = false;
				}

				if (conn.GetFieldValue("APP_FINISH") == "1")
				{
					BTN_FINISH.Visible = true;
				}
				else
				{
					BTN_FINISH.Visible = false;
				}

				if (conn.GetFieldValue("APPROVAL") == "1")
				{
					TR_APRV.Visible = true;
				}
				else
				{
					TR_APRV.Visible = false;
				}
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

		private void InitializeEvent()
		{
			BTN_FWDTOLOANREV.Attributes.Add("onclick","if(!update()){return false;};");
			BTN_FWDTOWATCH.Attributes.Add("onclick","if(!update()){return false;};");
			BTN_FINISH.Attributes.Add("onclick","if(!update()){return false;};");
			BTN_NOREVIEW.Attributes.Add("onclick","if(!update()){return false;};");
			BTN_ACCEPT.Attributes.Add("onclick","if(!update()){return false;};");
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
			this.DG_PORWATCH.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DG_PORWATCH_ItemCreated);
			this.DG_PORWATCH.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_PORWATCH_PageIndexChanged);

		}
		#endregion

		private void DG_PORWATCH_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_PORWATCH.CurrentPageIndex = e.NewPageIndex;
			BindDataWatchlist();
		}

		protected void BTN_SAVEQUAL_Click(object sender, System.EventArgs e)
		{
			try
			{
				for (int i = 0; i < DG_PORWATCH.Items.Count; i++)
				{
					DataGrid dgqual = (DataGrid) DG_PORWATCH.Items[i].Cells[5].FindControl("DG_QUAL");

					for (int j = 0; j < dgqual.Items.Count; j++)
					{
						string ischecked = null;
						RadioButtonList rbl = (RadioButtonList)dgqual.Items[j].Cells[4].FindControl("RBL_CHECKED");
						if (rbl.SelectedValue == "1")
							ischecked = "1";
						else if (rbl.SelectedValue == "0")
							ischecked = "0";

						conn.QueryString = "EXEC PORLMSGENERALINFO_SAVEDATAQUALITATIVE '" + dgqual.Items[j].Cells[0].Text.Trim() + "', '" + 
							dgqual.Items[j].Cells[1].Text.Trim() + "', '" + ischecked + "'";
						conn.ExecuteQuery();
					}
				}

				BindDataQualitative();
				UpdateDataWatchlist();
				SetButton();
			}
			catch (Exception ex)
			{
				GlobalTools.popMessage(this, "Save Error!");
				Response.Write("<!--" + ex.Message + "-->");
				return;
			}
		}

		private void dgqual_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			string ischecked;

			switch (e.Item.ItemType)
			{
				case ListItemType.AlternatingItem:
				case ListItemType.EditItem:
				case ListItemType.Item:
				case ListItemType.SelectedItem:
					try
					{
						ischecked = e.Item.Cells[3].Text.Trim();
						RadioButtonList rbl = (RadioButtonList)e.Item.Cells[4].FindControl("RBL_CHECKED");
						if (ischecked == "1")
							rbl.SelectedValue = "1";
						else if (ischecked == "0")
							rbl.SelectedValue = "0";
					} 
					catch {}
					break;
				case ListItemType.Footer:
					break;
				default:
					break;
			}
		}

		private void dgacc_PageIndexChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			dg.CurrentPageIndex = e.NewPageIndex;
			BindDataAccount();
			//SecureData();
		}

		private void dgqual_PageIndexChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			dg.CurrentPageIndex = e.NewPageIndex;
			BindDataQualitative();
			//SecureData();
		}

		private void DG_PORWATCH_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			DataGrid dgacc = (DataGrid) e.Item.FindControl("DG_ACCOUNT");
			DataGrid dgqual = (DataGrid) e.Item.FindControl("DG_QUAL");
			if (dgacc != null)
			{
				dgacc.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgacc_PageIndexChanged);

				dgqual.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgqual_PageIndexChanged);
				dgqual.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgqual_ItemDataBound);
			}
		}

		protected void BTN_FWDTOLOANREV_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			try
			{
				conn.QueryString = "exec PORLMS_GENERALINFO_FORWARDTOLOANREV '" + 
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

		protected void BTN_FWDTOWATCH_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			try
			{
				conn.QueryString = "exec PORLMS_GENERALINFO_FORWARDTOWATCHLIST '" + 
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

		protected void BTN_NOREVIEW_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			try
			{
				conn.QueryString = "exec PORLMS_GENERALINFO_NOREVIEW '" + 
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

		protected void BTN_FINISH_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			try
			{
				conn.QueryString = "exec PORLMS_GENERALINFO_FINISH '" + 
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

		protected void BTN_ACCEPT_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			try
			{
				conn.QueryString = "exec PORLMS_GENERALINFO_ACCEPT '" + 
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

		protected void BTN_ACQUIRE_Click(object sender, System.EventArgs e)
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
