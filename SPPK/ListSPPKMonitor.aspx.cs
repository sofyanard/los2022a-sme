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
namespace SME.SPPK
{
	/// <summary>
	/// Summary description for SPPKMonitoring.
	/// </summary>
	public partial class SPPKMonitoring : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				ViewData("0");
			}
		}

		private void ViewData(string sta)
		{	
			DataTable dt = new DataTable();
			if (sta == "1")
				conn.QueryString = "select * from vw_listsppk where getdate() >= isnull(ts_sppkexpdate,0) "+
								   " and ap_regno = '"+txt_regno.Text+"' and ap_currtrack='" + Request.QueryString["tc"] + "' and (ap_relmngr='" + Session["UserID"].ToString() + "' or ap_relmngr is null)";
			else
				conn.QueryString = "select * from vw_listsppk where getdate() >= isnull(ts_sppkexpdate,0) and ap_currtrack='" + Request.QueryString["tc"] + "' and (ap_relmngr='" + Session["UserID"].ToString() + "' or ap_relmngr is null)";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			dgListSPPK.DataSource = dt;
			dgListSPPK.DataBind();

			for (int i = 0; i < dgListSPPK.Items.Count; i++)
			{
				dgListSPPK.Items[i].Cells[5].Text = tool.FormatDate(dgListSPPK.Items[i].Cells[5].Text, true);
				//dgListSPPK.Items[i].Cells[6].Text = tool.MoneyFormat(dgListSPPK.Items[i].Cells[6].Text);
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
			this.dgListSPPK.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgListSPPK_ItemCommand);

		}
		#endregion

		private void dgListSPPK_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					//-------- edited by Yudi -------------asdfsadf
					//Response.Redirect("viewsppk.aspx?regno="+e.Item.Cells[0].Text+"&curef="+e.Item.Cells[1].Text+"&mc=" + Request.QueryString["mc"]);
					if (e.Item.Cells[8].Text == "&nbsp;")
					{
						conn.QueryString = "update application set ap_relmngr='" + Session["UserID"].ToString() + "' where ap_regno='" + e.Item.Cells[0].Text + "'";
						conn.ExecuteNonQuery();
					}
					Response.Redirect("viewsppk.aspx?regno="+e.Item.Cells[0].Text+"&curef="+e.Item.Cells[1].Text+"&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]);
					//--------------------------------------
				break;
				case "extend":
					conn.QueryString = "exec sppk_updexp '"+e.Item.Cells[0].Text+"'";
					conn.ExecuteQuery();			
					ViewData("0");
				break;
			}
		}

		protected void btn_cari_Click(object sender, System.EventArgs e)
		{
			ViewData("1");
		}
	}
}