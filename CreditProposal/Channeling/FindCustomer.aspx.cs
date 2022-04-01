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

namespace SME.CreditProposal.Channeling
{
	/// <summary>
	/// Summary description for FindCustomer.asdasd
	/// </summary>
	public partial class FindCustomer : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			/*if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");*/
			
			if (!IsPostBack)
			{
				// menampilkan string pesan jika ada
			}

			if (Request.QueryString["msg"] == "ok") 
			{
				string message = "Track Updated to Approval !";
				GlobalTools.popMessage(this, message);
			}

			ViewData("0");
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

		private void ViewData(string sta)
		{	
			BindData("dgListChan","EXEC CHANNELING_GETLIST_CREDIT_PROPOSAL '" + Session["UserID"].ToString() + "','" + txt_customer.Text.ToString() + "'");
			//BindData("dgListChan","EXEC CHANNELING_GETLIST_CREDIT_PROPOSAL '" + txt_customer.Text.ToString() + "','" + txt_regno.Text.ToString() + "'");
		}

		private void dgListChan_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "ContinuePending":
					/*conn.QueryString = "exec GENERATE_ID '" + Session["BranchID"].ToString() + "', '0'";
					conn.ExecuteQuery();*/
					//Response.Redirect("CreditProposalMainPage.aspx?mc=" + Request.QueryString["mc"] + "&regno=" + e.Item.Cells[1].Text.ToString() + "&curef=" + e.Item.Cells[0].Text.ToString());
					//Response.Redirect("CreditProposalMainPage.aspx?curef="+e.Item.Cells[0].Text+"&productid="+e.Item.Cells[5].Text+"&aano="+e.Item.Cells[4].Text+"&prodseq="+e.Item.Cells[6].Text+"&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&parentregno="+e.Item.Cells[7].Text+"&regno="+regno+"&mode=lanjut");
					Response.Redirect("CreditProposalMainPage.aspx?curef="+e.Item.Cells[0].Text+"&productid="+e.Item.Cells[5].Text+"&aano="+e.Item.Cells[4].Text+"&prodseq="+e.Item.Cells[6].Text+"&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&parentregno="+e.Item.Cells[7].Text+"&regno="+e.Item.Cells[1].Text+"&mode=lanjut&prodseqinduk="+e.Item.Cells[10].Text);
					break;
				case "Delete":
					conn.QueryString = "EXEC CHANNELING_DELETE_PER_GELONDONGAN '"+e.Item.Cells[0].Text+"','"+e.Item.Cells[1].Text+"'";
					conn.ExecuteQuery();
					BindData("dgListChan","EXEC CHANNELING_GETLIST_CREDIT_PROPOSAL '" + Session["UserID"].ToString() + "','" + txt_customer.Text.ToString() + "'");
					break;
			}
		}

		protected void btn_Find_Click(object sender, System.EventArgs e)
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
