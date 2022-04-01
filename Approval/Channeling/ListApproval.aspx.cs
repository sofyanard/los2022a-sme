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
namespace SME.Approval.Channeling
{
	/// <summary>
	/// Summary description for ListInitiation.
	/// </summary>
	public partial class ListApproval : System.Web.UI.Page
	{
		protected Connection conn;
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.PlaceHolder SubMenu;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			/*if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");*/

			if (!IsPostBack)
			{
				ViewData("0");
			}

			string asasa = Request.QueryString["msg"];

			if (Request.QueryString["msg"] == "ok") 
			{
				string message = "Track Updated to SPPK Letter Confirmation !";
				GlobalTools.popMessage(this, message);
			}
			else if(Request.QueryString["msg"] == "notok")
			{
				string message = "Track Updated to Credit Proposal !";
				GlobalTools.popMessage(this, message);
			}
			else if(Request.QueryString["msg"] != null)
			{
				string message = "Track Updated to " + Request.QueryString["msg"].ToString();
				GlobalTools.popMessage(this, message);
			}

			DisableAllControl();
		}

		private void DisableAllControl()
		{
			conn.QueryString = "SELECT * FROM APPLICATION WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND AP_RELMNGR = '" + Session["UserID"] + "'";
			conn.ExecuteQuery();

			if(conn.GetRowCount() == 0)
			{
				for (int i = 1; i <= dgListChan.Items.Count; i++)
				{
					dgListChan.Items[i-1].Cells[9].Visible = false;
				}
			}
		}

		private void ViewData(string sta)
		{	
			//BindData("dgListChan","EXEC CHANNELING_GETLIST_CREDIT_PROPOSAL '" + txt_customer.Text.ToString() + "','" + txt_regno.Text.ToString() + "'");
			BindData("dgListChan","EXEC CHANNELING_GETLIST_APPROVAL '" + Session["UserID"].ToString() + "'");
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

		}
		#endregion

		private void dgListChan_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "ContinuePending":
					/*conn.QueryString = "exec GENERATE_ID '" + Session["BranchID"].ToString() + "', '0'";
					conn.ExecuteQuery();*/
					//Response.Redirect("CreditProposalMainPage.aspx?curef="+e.Item.Cells[0].Text+"&regno="+conn.GetFieldValue(0,0)+"&productid="+e.Item.Cells[3].Text+"&aano="+e.Item.Cells[4].Text+"&prodseq="+e.Item.Cells[5].Text+"&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]);
					//Response.Redirect("ApprovalMainPage.aspx?curef="+e.Item.Cells[0].Text+"&productid="+e.Item.Cells[6].Text+"&aano="+e.Item.Cells[5].Text+"&prodseq="+e.Item.Cells[7].Text+"&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&regno="+e.Item.Cells[1].Text);
					Response.Redirect("ApprovalMainPage.aspx?curef="+e.Item.Cells[0].Text+"&productid="+e.Item.Cells[5].Text+"&aano="+e.Item.Cells[4].Text+"&prodseq="+e.Item.Cells[6].Text+"&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&parentregno="+e.Item.Cells[7].Text+"&regno="+e.Item.Cells[1].Text+"&mode=lanjut&prodseqinduk="+e.Item.Cells[10].Text);
					break;
				case "Delete":
					conn.QueryString = "EXEC CHANNELING_DELETE_PER_GELONDONGAN '"+e.Item.Cells[0].Text+"','"+e.Item.Cells[1].Text+"'";
					conn.ExecuteQuery();
					BindData("dgListChan","EXEC CHANNELING_GETLIST_APPROVAL '" + Session["UserID"].ToString() + "'");
					break;
			}
		}

		protected void btn_cari_Click(object sender, System.EventArgs e)
		{
			ViewData("1");
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
	}
}
