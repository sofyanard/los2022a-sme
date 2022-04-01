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

namespace SME.Approval
{
	/// <summary>
	/// Summary description for ListApprovalCondition.
	/// </summary>
	public partial class ListApprovalCondition : System.Web.UI.Page
	{

		#region "Variables"
		protected Connection conn;
		protected Tools tool = new Tools();
		#endregion
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				if ((Request.QueryString["msg"] != "") && (Request.QueryString["msg"] != null))
					GlobalTools.popMessage(this, Request.QueryString["msg"]);
				ViewData();

				// Munculkan pesan next step - Gatot - Agus
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"]!= null)  
				{
					GlobalTools.popMessage(this, Request.QueryString["msg"]);
				}
			}	
		}

		private void ViewData()
		{	
			lbl_userid.Text = Session["UserID"].ToString();
			DataTable dt = new DataTable();

			conn.QueryString = "EXEC LIST_APPROVAL_CONDITION '" + txt_regno.Text + "', '" + lbl_userid.Text + "'";
			conn.ExecuteQuery();
		
			dt = conn.GetDataTable().Copy();
			dgListApproval.DataSource = dt;
			try 
			{
				dgListApproval.DataBind();
			}
			catch 
			{
				dgListApproval.CurrentPageIndex = 0;
				dgListApproval.DataBind();
			}

			for (int i = 0; i < dgListApproval.Items.Count; i++)
			{
				dgListApproval.Items[i].Cells[3].Text = tool.FormatDate(dgListApproval.Items[i].Cells[3].Text, true);
				dgListApproval.Items[i].Cells[4].Text = tool.MoneyFormat(dgListApproval.Items[i].Cells[4].Text);
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
			this.dgListApproval.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgListApproval_ItemCommand);

		}
		#endregion

		private void dgListApproval_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					Response.Redirect("ApprovalCondition.aspx?regno="+e.Item.Cells[0].Text+
						"&curef="+e.Item.Cells[1].Text+
						"&tc="+Request.QueryString["tc"]+
						"&mc="+Request.QueryString["mc"]);
					break;
			}
		}

		protected void btn_cari_Click(object sender, System.EventArgs e)
		{
			ViewData();
		}
	}
}
