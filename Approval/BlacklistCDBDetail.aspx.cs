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

namespace SME.Approval
{
	/// <summary>
	/// Summary description for BlacklistCDBDetail.
	/// </summary>
	public partial class BlacklistCDBDetail : System.Web.UI.Page
	{
		private Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = new Connection((string)Session["ConnString"]);
			regno.Text = Request.QueryString["regno"];
			seq.Text = Request.QueryString["seq"];

			if(!IsPostBack)
			{
				viewData();
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

		}
		#endregion

		private void viewData()
		{
			conn.QueryString = "exec SP_VW_BLACKLIST_DETAIL '"+regno.Text.Trim()+"', '"+seq.Text.Trim()+"' ";	
			conn.ExecuteQuery();

			if(conn.GetRowCount() > 0)
			{
				lbl_ap_regno.Text = conn.GetFieldValue("ap_regno");
				lbl_seq.Text = conn.GetFieldValue("seq");
				lbl_EXACTMATCH_DESC.Text = conn.GetFieldValue("EXACTMATCH_DESC");
				lbl_REMARK.Text = conn.GetFieldValue("remark");
				lbl_name.Text = conn.GetFieldValue("bl_name");
				lbl_idtype.Text = conn.GetFieldValue("bl_idtype");
				lbl_idNumber.Text = conn.GetFieldValue("bl_idnumber");
				lbl_source.Text = conn.GetFieldValue("bl_source");
				lbl_Address1.Text = conn.GetFieldValue("bl_address1");	
				lbl_Address2.Text = conn.GetFieldValue("bl_address2");
				lbl_Address3.Text = conn.GetFieldValue("bl_address3");
				lbl_Address4.Text = conn.GetFieldValue("bl_address4");
				lbl_STARTDATE.Text = GlobalTools.FormatDate(conn.GetFieldValue("bl_startdate"));
			}
		}

	}
}
