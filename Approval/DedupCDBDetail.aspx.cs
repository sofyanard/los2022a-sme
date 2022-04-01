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
	/// Summary description for DedupCDBDetail.
	/// </summary>
	public partial class DedupCDBDetail : System.Web.UI.Page
	{
		private Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = new Connection((string)Session["ConnString"]);
			regno.Text = Request.QueryString["regno"];
			regno_CDB.Text = Request.QueryString["regno_cdb"];
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
			conn.QueryString = "exec SP_VW_DEDUP_DETAIL '"+regno.Text.Trim()+"', '"+regno_CDB.Text+"', '"+seq.Text.Trim()+"' ";	
			conn.ExecuteQuery();

			if(conn.GetRowCount() > 0)
			{
				lbl_ap_regno.Text = conn.GetFieldValue("ap_regno");
				lbl_ap_Regno_cdb.Text = conn.GetFieldValue("ap_regno_cdb");
				lbl_seq.Text = conn.GetFieldValue("seq");
				lbl_cu_ref.Text = conn.GetFieldValue("cu_ref");
				lbl_cu_cif.Text = conn.GetFieldValue("cu_cif");
				lbl_EXACTMATCH_DESC.Text = conn.GetFieldValue("EXACTMATCH");
				lbl_REMARK.Text = conn.GetFieldValue("remark");
				lbl_name.Text = conn.GetFieldValue("cu_name");
				lbl_cu_borndate.Text = GlobalTools.FormatDate(conn.GetFieldValue("cu_borndate"));
				lbl_sex.Text = conn.GetFieldValue("sex");
				lbl_idtype.Text = conn.GetFieldValue("cu_idtype");
				lbl_idNumber.Text = conn.GetFieldValue("cu_idnumber");
				lbl_cu_mothername.Text = conn.GetFieldValue("cu_mothername");
				lbl_cu_Address.Text = conn.GetFieldValue("cu_address");	
				lbl_modulename.Text = conn.GetFieldValue("modulename");
				lbl_ap_recvdate.Text = GlobalTools.FormatDate(conn.GetFieldValue("ap_recvdate"));
				lbl_ap_product.Text = conn.GetFieldValue("ap_product");
				lbl_ap_amount.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("ap_amount"));
				lbl_ap_tenor.Text = conn.GetFieldValue("ap_tenor");
				lbl_ap_interest.Text = conn.GetFieldValue("ap_interest");
				lbl_ap_installment.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("ap_installment"));
				lbl_status.Text = conn.GetFieldValue("ap_status");
			}
		}

	}
}
