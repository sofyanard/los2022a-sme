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
namespace SME.Assignment.Channeling
{
	/// <summary>
	/// Summary description for ListInitiation.
	/// </summary>
	public partial class EditNasabah : System.Web.UI.Page
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
				conn.QueryString = "select * from VW_CHANNELING_INITIATION_LIST where cu_name like ''";
			else
				conn.QueryString = "select * from VW_CHANNELING_INITIATION_LIST";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
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

		}
		#endregion

		private void dgListChan_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Continue":
					Response.Redirect("MainInitiation.aspx?curef="+e.Item.Cells[1].Text+"&regno="+conn.GetFieldValue(0,0)+"&productid="+e.Item.Cells[3].Text+"&aano="+e.Item.Cells[4].Text+"&prodseq="+e.Item.Cells[5].Text+"&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]);
					break;
			}
		}

		private void btn_cari_Click(object sender, System.EventArgs e)
		{
			ViewData("1");
		}
	}
}
