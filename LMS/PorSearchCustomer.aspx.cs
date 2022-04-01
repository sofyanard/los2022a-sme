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
using DMS.DBConnection;
using DMS.CuBESCore;
using Microsoft.VisualBasic;

namespace SME.LMS
{
	/// <summary>
	/// Summary description for PorSearchCustomer.
	/// </summary>
	public partial class PorSearchCustomer : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
			//	Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				SearchData();

				if (Request.QueryString["scr"] == "1") //Watchlist Checking
				{
					LBL_TITLE.Text = "Watchlist Checking";
				}
				else if (Request.QueryString["scr"] == "2") //Acceptance Loan Review
				{
					LBL_TITLE.Text = "Acceptance Loan Review";
				}
				else if (Request.QueryString["scr"] == "3") //Nota Watchlist
				{
					LBL_TITLE.Text = "Nota Watchlist";
				}
				else if ((Request.QueryString["scr"] == "4") || (Request.QueryString["scr"] == "4b") || (Request.QueryString["scr"] == "5") || (Request.QueryString["scr"] == "6")) //Acceptance Nota Watchlist
				{
					LBL_TITLE.Text = "Acceptance Nota Watchlist";
				}
				else
				{
					LBL_TITLE.Text = "Customer List";
				}

				//Next Step Message
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"] != null) 
				{
					GlobalTools.popMessage(this, Request.QueryString["msg"]);
				}
			}
		}

		private void SearchData()
		{
			conn.QueryString = "EXEC PORLMS_SEARCHCUSTOMER '" +
				Request.QueryString["scr"] + "', '" +
				TXT_PORLMS_REGNO.Text + "', '" +
				Session["UserID"].ToString() + "', '" +
				Request.QueryString["tc"] + "'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = 0;
				DatGrd.DataBind();
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);

		}
		#endregion

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
					string url = "";
					if ((Request.QueryString["scr"] == "3") || (Request.QueryString["scr"] == "4") || (Request.QueryString["scr"] == "4b") || (Request.QueryString["scr"] == "5") || (Request.QueryString["scr"] == "6")) //Watchlist
					{
						url = "PorWatchlist.aspx?porlmsreg=" + e.Item.Cells[0].Text;
					}
					else if ((Request.QueryString["scr"] == "1") || (Request.QueryString["scr"] == "2") || (Request.QueryString["scr"] == "7")) //Loan Review
					{
						url = "PorGeneralInfo.aspx?porlmsreg=" + e.Item.Cells[0].Text;
					}

					if (Request.QueryString["mc"] != "")
					{
						url = url + "&mc=" + Request.QueryString["mc"];
					}
					if (Request.QueryString["tc"] != "")
					{
						url = url + "&tc=" + Request.QueryString["tc"];
					}
					if (Request.QueryString["scr"] != "")
					{
						url = url + "&scr=" + Request.QueryString["scr"];
					}
					Response.Redirect(url);
					break;					
			}
		}

		protected void btn_cari_Click(object sender, System.EventArgs e)
		{
			DatGrd.CurrentPageIndex = 0;
			SearchData();
		}
	}
}
