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

namespace  SME.InitialDataEntry.Channeling
{
	/// <summary>
	/// Summary description for ListInitiation.
	/// </summary>
	public partial class ListInitiation : System.Web.UI.Page
	{
		protected Connection conn;
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (Request.QueryString["msg"] == "ok") 
			{
				string message = "Track Updated to Credit Proposal !";
				GlobalTools.popMessage(this, message);
			}
			else if (Request.QueryString["msg"] == "existing") 
			{
				string message = "Existing End User Creation is Success !";
				GlobalTools.popMessage(this, message);
			}

			string a = Request.QueryString["mc"];

			/*if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");*/

			if (!IsPostBack)
			{
				
			}

			BindData("dgListChan","EXEC CHANNELING_GETLIST_INITIATION '" + Session["UserID"].ToString() + "'");
			BindData("dgGridPendingApplication","EXEC CHANNELING_GETLIST_INITIATION_PENDING '" + Session["UserID"].ToString() + "'");
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
			this.dgListChan.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgListChan_ItemCommand);
			this.dgGridPendingApplication.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgGridPendingApplication_ItemCommand);

		}
		#endregion


		private string regno = "";
		private void dgListChan_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Continue":
					conn.QueryString = "EXEC CHANNELING_GENERATE_REGNO '" + e.Item.Cells[0].Text + "','" + Session["UserID"].ToString() + "'"; 
					conn.ExecuteQuery();
					regno = conn.GetFieldValue("AP_REGNO");
					conn.QueryString = "EXEC CHANNELING_GENERATE_PARENT_APPLICATION '" + e.Item.Cells[0].Text + "','" + e.Item.Cells[7].Text + "','" + e.Item.Cells[4].Text + "','" + e.Item.Cells[5].Text + "','" + e.Item.Cells[6].Text + "','" + regno + "'"; 
					conn.ExecuteQuery();
					Response.Redirect("InitiationMainPage.aspx?curef="+e.Item.Cells[0].Text+"&productid="+e.Item.Cells[5].Text+"&aano="+e.Item.Cells[4].Text+"&prodseq="+e.Item.Cells[6].Text+"&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&parentregno="+e.Item.Cells[7].Text+"&regno="+regno+"&mode=lanjut");
					break;
			}
		}

		protected void btn_cari_Click(object sender, System.EventArgs e)
		{
			BindData("dgListChan","EXEC CHANNELING_GETLIST_INITIATION '" + Session["UserID"].ToString() + "','" + txt_customer.Text.ToString() + "'");
			BindData("dgGridPendingApplication","EXEC CHANNELING_GETLIST_INITIATION_PENDING '" + Session["UserID"].ToString() + "','" + txt_customer.Text.ToString() + "'");
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);

			dg.DataSource = dt;				

			try
			{
				dg.DataBind();
			}
			catch 
			{
				dg.CurrentPageIndex = dg.PageCount - 1;
				dg.DataBind();
			}

			conn.ClearData();
		}

		private void dgGridPendingApplication_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "ContinuePending":
					Response.Redirect("InitiationMainPage.aspx?curef="+e.Item.Cells[0].Text+"&productid="+e.Item.Cells[5].Text+"&aano="+e.Item.Cells[4].Text+"&prodseq="+e.Item.Cells[6].Text+"&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&parentregno="+e.Item.Cells[7].Text+"&regno="+e.Item.Cells[1].Text+"&mode=lanjut&prodseqinduk="+e.Item.Cells[10].Text);
					break;
				case "Delete":
					conn.QueryString = "EXEC CHANNELING_DELETE_PER_GELONDONGAN '"+e.Item.Cells[0].Text+"','"+e.Item.Cells[1].Text+"'";
					conn.ExecuteQuery();
					BindData("dgListChan","EXEC CHANNELING_GETLIST_INITIATION '" + Session["UserID"].ToString() + "'");
					BindData("dgGridPendingApplication","EXEC CHANNELING_GETLIST_INITIATION_PENDING '" + Session["UserID"].ToString() + "'");
					break;
			}
		}
	}
}
