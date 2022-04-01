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
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.IPPS.Process
{
	/// <summary>
	/// Summary description for ListInitiation.
	/// </summary>
	public partial class ListInitiation : System.Web.UI.Page
	{
		protected Connection conn;
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../../SME/Restricted.aspx");

			if(!IsPostBack)
			{
				if(Request.QueryString["tc"]== "PP1.0")
				{
					LBL_TITLEPAGE.Text = "Initiation List";
					TR_INITIATION.Visible = true;
				}
				else if(Request.QueryString["tc"]== "PP1.1")
				{
					LBL_TITLEPAGE.Text = "Initiation Update List";
					TR_INITIATION.Visible = false;
				}
				else
				{
					LBL_TITLEPAGE.Text = "";
					TR_INITIATION.Visible = false;
				}

				conn.QueryString = "SELECT * FROM VW_IPPS_INITIATIONLIST WHERE CURRENT_TRACK = '" + Request.QueryString["tc"] + 
					"' AND OWNER_ID = '" + Session["UserID"].ToString() + "' ORDER BY INIT_DATE";
				conn.ExecuteQuery();
				FillGrid();
			}
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			dg_list_initiation.DataSource = dt;
			try 
			{
				dg_list_initiation.DataBind();
			} 
			catch 
			{
				dg_list_initiation.CurrentPageIndex = 0;
				dg_list_initiation.DataBind();
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
			this.dg_list_initiation.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dg_list_initiation_ItemCommand);
			this.dg_list_initiation.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dg_list_initiation_PageIndexChanged);

		}
		#endregion

		private void dg_list_initiation_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":	
					if(Request.QueryString["tc"]== "PP1.0")
						Response.Redirect("Initiation.aspx?regno=" + e.Item.Cells[0].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
					else if(Request.QueryString["tc"]== "PP1.1")
						Response.Redirect("InitiationUpdate/PolicyProcedureInitiation.aspx?regno=" + e.Item.Cells[0].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
					break;				
			}
		
		}

		private void dg_list_initiation_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dg_list_initiation.CurrentPageIndex = e.NewPageIndex;
		}

		protected void btn_new_Click(object sender, System.EventArgs e)
		{
			string regno;

			conn.QueryString  = "EXEC IPPS_GENERATE_REGNO '" + Session["BranchID"].ToString() + "', '" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			regno = conn.GetFieldValue("REGNO");

			Response.Redirect("Initiation.aspx?regno=" + regno + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}
	}
}
