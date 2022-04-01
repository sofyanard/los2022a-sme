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
namespace SME.Booking.Channeling
{
	/// <summary>
	/// Summary description for ListInitiation.
	/// </summary>
	public partial class ListBooking : System.Web.UI.Page
	{
		protected Connection conn;
		protected System.Web.UI.WebControls.TextBox txt_Name;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			string groupid = Session["GroupID"].ToString();
			string mcs = Request.QueryString["mc"];

			/*if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");*/

			if (!IsPostBack)
			{
				
			}

			if(Request.QueryString["msg"] == "notok")
			{
				conn.QueryString = "SELECT SCUSER.SU_FULLNAME FROM APPLICATION, SCUSER WHERE AP_REGNO = '" + Request.QueryString["regno"].ToString() + "' AND APPLICATION.AP_RELMNGR = SCUSER.USERID";
				conn.ExecuteQuery();
				
				Tools.popMessage(this, "Track has been updated to Credit Proposal " + conn.GetFieldValue("SU_FULLNAME") + " !");
			}
			if(Request.QueryString["msg"] == "ok")
			{
				Tools.popMessage(this, "Application proceeds to Upload to eMas !");
			}

			BindData("dgListChan","EXEC CHANNELING_GETLIST_BOOKING '" + Session["UserID"].ToString() + "','" + txt_customer.Text.ToString() + "'");
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
					Response.Redirect("Booking.aspx?curef="+e.Item.Cells[0].Text+"&productid="+e.Item.Cells[5].Text+"&aano="+e.Item.Cells[4].Text+"&prodseq="+e.Item.Cells[6].Text+"&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&parentregno="+e.Item.Cells[7].Text+"&regno="+e.Item.Cells[1].Text+"&mode=lanjut&prodseqinduk="+e.Item.Cells[9].Text);
					break;
			}
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
