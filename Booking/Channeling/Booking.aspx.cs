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
	public partial class Booking : System.Web.UI.Page
	{
		protected Connection conn;
		protected System.Web.UI.WebControls.PlaceHolder Menu;
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
			
		}

		private void ViewData(string sta)
		{	
			BindData("dgListChan","EXEC CHANNELING_VIEWDATA_BOOKING '" + Request.QueryString["regno"] + "','" + Session["UserID"] + "'");
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

		protected void btn_cari_Click(object sender, System.EventArgs e)
		{
			ViewData("1");
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			try
			{
				for (int i=0; i<dgListChan.Items.Count; i++)
				{
					RadioButton confirm = (RadioButton) dgListChan.Items[i].Cells[6].FindControl("rdo_confirm");
					RadioButton unconfirm = (RadioButton) dgListChan.Items[i].Cells[6].FindControl("rdo_unconfirm");

					if(confirm.Checked)
					{
						//exec APPROVAL_DECISION

						conn.QueryString = "EXEC CHANNELING_TRACKUPDATE_PERENDUSER '" + dgListChan.Items[i].Cells[0].Text.ToString() + "','" + Session["UserID"] + "','5.2'";
						conn.ExecuteNonQuery();

						updateRemainingEmasLimit(dgListChan.Items[i].Cells[0].Text.ToString(), Request.QueryString["parentregno"]);
					}
				}

				ViewData("0");

				if(dgListChan.Items.Count == 0)
				{
					conn.QueryString = "EXEC CHANNELING_TRACKUPDATE_PERENDUSER '" + Request.QueryString["regno"] + "','" + Session["UserID"] + "','5.6'";
					conn.ExecuteQuery();
				}
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
				Tools.popMessage(this,"Insert Error!!");
			}

			Response.Redirect("ListBooking.aspx?msg=ok");
		}

		private void updateRemainingEmasLimit(string regno, string parent)
		{
			conn.QueryString = "EXEC CHANNELING_UPDATE_REMAINING_EMAS_LIMIT '" + regno + "','" + parent + "'";
			conn.ExecuteQuery();
		}

		private void dgListChan_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
						Response.Redirect("AssignmentComplyMain.aspx?curef="+Request.QueryString["curef"]+"&productid="+Request.QueryString["productid"]+"&aano="+Request.QueryString["aano"]+"&prodseq="+Request.QueryString["prodseq"]+"&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&parentregno="+Request.QueryString["parentregno"]+"&regno="+Request.QueryString["regno"]+"&mode=lanjut&prodseqinduk="+Request.QueryString["prodseqinduk"]);
						break;
				case "allconfirm":
						allConfirm();
						break;
				case "allunconfirm":
						allUnConfirm();
						break;
			}
		}

		private void allConfirm()
		{
			for (int i=0; i<dgListChan.Items.Count; i++)
			{
				RadioButton confirm = (RadioButton) dgListChan.Items[i].Cells[5].FindControl("rdo_confirm");
				confirm.Checked = true;
			}
		}

		private void allUnConfirm()
		{
			for (int i=0; i<dgListChan.Items.Count; i++)
			{
				RadioButton unconfirm = (RadioButton) dgListChan.Items[i].Cells[6].FindControl("rdo_unconfirm");
				unconfirm.Checked = true;
			}
		}
	}
}
