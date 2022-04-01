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

namespace SME.Maintenance.User
{
	/// <summary>
	/// Summary description for GroupApproval.
	/// </summary>
	public partial class GroupApproval : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=192.168.1.200;Initial Catalog=SME;uid=sa;pwd=");df
		protected Connection conn;
		protected DataTable dt = new DataTable();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			HyperLink1.NavigateUrl = "UserApproval.aspx?mc=" + Request.QueryString["mc"];
			HyperLink2.NavigateUrl = "GroupApproval.aspx?mc=" + Request.QueryString["mc"];

			if (!IsPostBack)
				ViewData();
		}

		private void ViewData()
		{
			conn.QueryString = "select * from vw_pending_scgroup";
			conn.ExecuteQuery();
			dt = conn.GetDataTable();
			DataGrid1.DataSource = dt;
			DataGrid1.DataBind();
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

		protected void BTN_SUBMIT_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < DataGrid1.Items.Count; i++)
			{
				RadioButton rdA = (RadioButton) DataGrid1.Items[i].FindControl("RDO_APPROVE"),
					rdR = (RadioButton) DataGrid1.Items[i].FindControl("RDO_REJECT");
				if (rdA.Checked == true)
				{
					conn.QueryString = "exec SU_SCGROUP '" + 
						DataGrid1.Items[i].Cells[0].Text + 
						"', null, null, null, null, '" + 
						DataGrid1.Items[i].Cells[2].Text + 
						"', '0', null, null, null";
					conn.ExecuteNonQuery();
				}
				
				else if (rdR.Checked == true)
				{
					conn.QueryString = "delete from pending_scgroup where groupid='" + DataGrid1.Items[i].Cells[0].Text + "'";
					conn.ExecuteNonQuery();
				}
			}

			Response.Write("<script language='javascript'>alert('Update Complete...');</script>");
			ViewData();
		}
	}
}
