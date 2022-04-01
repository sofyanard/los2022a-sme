namespace SME.LMS
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using DMS.CuBESCore;
	using DMS.DBConnection;

	/// <summary>
	///		Summary description for WatchlistItem.
	/// </summary>
	public partial class WatchlistItem : System.Web.UI.UserControl
	{
		protected Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			if (!IsPostBack)
			{
				FillDDL();
				CheckBussinessUnit();
				BindDataWatchlist();
				ViewResult();
			}
		}

		private void FillDDL()
		{
			GlobalTools.fillRefList(DDL_BUSSUNIT, "SELECT * FROM RFBUSINESSUNIT WHERE ACTIVE='1'", true, conn);
		}

		private void CheckBussinessUnit()
		{
			conn.QueryString = "SELECT * FROM VW_WATCHLIST_CHECKBUSINESSUNIT WHERE LMS_REGNO = '" + Request.QueryString["lmsreg"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				if (conn.GetFieldValue("BUSSUNITID") != "")
				{
					try
					{
						DDL_BUSSUNIT.SelectedValue = conn.GetFieldValue("BUSSUNITID");
						DDL_BUSSUNIT.Enabled = false;
					}
					catch {}
				}
				else
				{
					try
					{
						DDL_BUSSUNIT.SelectedValue = "";
						DDL_BUSSUNIT.Enabled = true;
					}
					catch {}
				}
			}
		}

		private void BindDataWatchlist()
		{
			conn.QueryString = "SELECT * FROM VW_WATCHLIST_ITEM_PARAM2 WHERE BUSSUNITID = '" + DDL_BUSSUNIT.SelectedValue + "' ORDER BY WATCHID, SUBWATCHID";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_WATCH.DataSource = dt;
			try 
			{
				DGR_WATCH.DataBind();
			}
			catch 
			{
				DGR_WATCH.CurrentPageIndex = 0;
				DGR_WATCH.DataBind();
			}

			BindDataWatchlist2();
		}

		private void BindDataWatchlist2()
		{
			for (int i=0;i<DGR_WATCH.Items.Count;i++)
			{
				RadioButtonList rblsubsubwatch = (RadioButtonList) DGR_WATCH.Items[i].Cells[5].FindControl("RBL_SUBSUBWATCH");

				conn.QueryString = "exec LMS_WATCHLIST_ITEM_VIEWDATA '" + Request.QueryString["lmsreg"] + 
					"', '" + DGR_WATCH.Items[i].Cells[0].Text.Trim() + 
					"', '" + DGR_WATCH.Items[i].Cells[1].Text.Trim() + 
					"', '" + DGR_WATCH.Items[i].Cells[2].Text.Trim() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtsubsubwatch = new DataTable();
					dtsubsubwatch = conn.GetDataTable().Copy();

					string subsubwatchid = "", subsubwatchflag = "", subsubwatchmand = "";
					DataRow[] drs = dtsubsubwatch.Select();
					foreach (DataRow dr in drs)
					{
						if (dr["ISCHECKED"].ToString() == "1")
						{
							subsubwatchid = dr["SUBSUBWATCHID"].ToString();
							subsubwatchflag = dr["ISWATCHLISTDESC"].ToString();
							subsubwatchmand = dr["ISMANDATORYDESC"].ToString();
						}
					}

					rblsubsubwatch.DataSource = dtsubsubwatch;
					try 
					{
						rblsubsubwatch.DataValueField = "SUBSUBWATCHID";
						rblsubsubwatch.DataTextField = "SUBSUBWATCHDESC";
						if (subsubwatchid != "")
							try {rblsubsubwatch.SelectedValue = subsubwatchid;} 
							catch {}
						rblsubsubwatch.DataBind();

						//Fill column ISWATCHLIST and ISMANDATORY
						DGR_WATCH.Items[i].Cells[6].Text = subsubwatchflag;
						DGR_WATCH.Items[i].Cells[7].Text = subsubwatchmand;
					} 
					catch {}
				}
			}
		}

		private void ViewResult()
		{
			conn.QueryString = "EXEC LMS_WATCHLIST_ITEM_VIEWRESULT '" + Request.QueryString["lmsreg"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				TXT_KATEGORI.Text = conn.GetFieldValue("KATEGORI");
				TXT_FAKTOR.Text = conn.GetFieldValue("FAKTOR_PENYEBAB");
				TXT_FOLLOW.Text = conn.GetFieldValue("FOLLOW_UP");
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.DGR_WATCH.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_WATCH_PageIndexChanged);

		}
		#endregion

		protected void DDL_BUSSUNIT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindDataWatchlist();
			ViewResult();
		}

		private void DGR_WATCH_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_WATCH.CurrentPageIndex = e.NewPageIndex;
			BindDataWatchlist();
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			for (int i=0; i<DGR_WATCH.Items.Count; i++)
			{
				RadioButtonList rblsubsubwatch = (RadioButtonList) DGR_WATCH.Items[i].Cells[5].FindControl("RBL_SUBSUBWATCH");

				try
				{
					conn.QueryString = "exec LMS_WATCHLIST_ITEM_SAVEDATA '" +
						Request.QueryString["lmsreg"] + "', '" +
						DGR_WATCH.Items[i].Cells[0].Text.Trim() + "', '" + 
						DGR_WATCH.Items[i].Cells[1].Text.Trim() + "', '" +
						DGR_WATCH.Items[i].Cells[2].Text.Trim() + "', '" +
						rblsubsubwatch.SelectedValue.Trim() + "'";
					conn.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					//string errmsg = ex.Message.Replace("'","");
					//if (errmsg.IndexOf("Last Query:") > 0)
					//	errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
					//GlobalTools.popMessage(this, errmsg);
					Response.Write("<!--"+ex.ToString()+"-->");
					return;
				}
			}

			BindDataWatchlist();
			ViewResult();
		}
	}
}
