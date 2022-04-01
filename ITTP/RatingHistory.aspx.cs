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
namespace SME.ITTP
{
	/// <summary>
	/// Summary description for RatingHistory.
	/// </summary>
	public partial class RatingHistory : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label name;
		#region " My Variables "
		private Connection conn;
		private Tools tool = new Tools();
		private string CUREF;
		#endregion	
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
			//	Response.Redirect("/SME/Restricted.aspx");

			//REGNO		= Request.QueryString["regno"];
			CUREF		= Request.QueryString["curef"];

			if(!IsPostBack)
			{
				ViewData();
			}
		}

		private void ViewData()
		{	
			//lbl_userid.Text = Session["UserID"].ToString();
			DataTable dt = new DataTable();
			
			conn.QueryString = "select * from VW_IT_RATING_HISTORY where cu_ref='" + Request.QueryString["curef"] + "' order by ap_signdate asc ";
			conn.ExecuteQuery();

			dt = conn.GetDataTable().Copy();
			dgratinghistory.DataSource = dt;
			try 
			{
				dgratinghistory.DataBind();
			}
			catch 
			{
				dgratinghistory.CurrentPageIndex = 0;
				dgratinghistory.DataBind();
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
			this.dgratinghistory.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);

		}
		#endregion

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
					//conn.QueryString = "select cu_rm from customer where cu_ref='" + e.Item.Cells[0].Text + "'";
					//Generate AP_REGNO
					//conn.QueryString = "exec IT_RATING_DETAIL_HISTORY '" + e.Item.Cells[1].Text + "'";
					//conn.ExecuteQuery();

					Response.Write("<script language='javascript'>window.open('RatingDetailHistory.aspx?regno="+e.Item.Cells[1].Text+"','RatingDetailHistory','status=no,scrollbars=yes,width=1200,height=400');</script>");
					break;	
			}
		}

	}
}
