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
using DMS.CuBESCore;
using DMS.DBConnection;
using System.Configuration;
using Microsoft.VisualBasic;
namespace SME.ITTP
{
	/// <summary>
	/// Summary description for ComplianceList.
	/// </summary>
	public partial class ComplianceList : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		string user;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			user = Session["USERID"].ToString();



			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{


				DDL_MONTH.Items.Add(new ListItem("- SELECT -", ""));
				for (int i = 1; i <= 12; i++)
					DDL_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));

				SearchData ();
				FillGrid();

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

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			DatGrd.CurrentPageIndex = 0;
			SearchData();
		}

		private void SearchData()
		{
			bool stop = false;

			if (TXT_AP_REGNO.Text != "")
			{
				conn.QueryString = "select ap_regno, cu_ref, [name], ap_signdate, su_fullname, ad_limit, txntype, ap_currtrack from VW_IT_DDE_COMPLIANCE2 where ap_regno='" + TXT_AP_REGNO.Text + "'";
				conn.ExecuteQuery();
				FillGrid();
				stop = true;
			}

			else if (stop == false && txt_Name.Text != "")
			{
				conn.QueryString = "select ap_regno, cu_ref, [name], ap_signdate, su_fullname, ad_limit, txntype, ap_currtrack from VW_IT_DDE_COMPLIANCE2 where name like '%" + txt_Name.Text + "%'";
				conn.ExecuteQuery();
				FillGrid();				
			}
			else if (stop == false && tool.ConvertDate(TXT_DATE.Text,DDL_MONTH.SelectedValue,TXT_YEAR.Text) != "" && tool.ConvertDate(TXT_DATE.Text,DDL_MONTH.SelectedValue,TXT_YEAR.Text) !="null")
			{
				conn.QueryString = "select ap_regno, cu_ref, [name], ap_signdate, su_fullname, ad_limit, txntype, ap_currtrack from VW_IT_DDE_COMPLIANCE2 where ap_signdate="+tool.ConvertDate(TXT_DATE.Text,DDL_MONTH.SelectedValue,TXT_YEAR.Text)+"";
				conn.ExecuteQuery();
				FillGrid();				
			}
			else 
			{
				conn.QueryString = "select ap_regno, cu_ref, [name], ap_signdate, su_fullname, ad_limit, txntype, ap_currtrack from VW_IT_DDE_COMPLIANCE2 where userid='"+user+"'";
				conn.ExecuteQuery();
				FillGrid();	
			}

		}

		private void FillGrid()
		{
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

			bool isComplete = false;
			for (int i = 0; i < DatGrd.Items.Count; i++) 
			{
				DatGrd.Items[i].Cells[4].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[4].Text);
			}


		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string regno, curef;
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Continue":
					regno = e.Item.Cells[1].Text.Trim();
					curef = e.Item.Cells[0].Text.Trim();

					Session["curef"]	= Request.QueryString ["curef"];
					Session["tc"]		= Request.QueryString ["tc"];
					Session["mc"]		= Request.QueryString ["mc"];

					Response.Redirect("ComplianceCondition.aspx?regno=" +regno+ "&curef="+curef+ "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
					break;					
			}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			SearchData();				
		}

	}
}
