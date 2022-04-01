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
using Microsoft.VisualBasic;

namespace SME.Facilities
{
	/// <summary>
	/// Summary description for InteractionMemo.
	/// </summary>
	public partial class InteractionMemo : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SME;uid=sa;pwd=");
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				string regno		= Request.QueryString["regno"].ToString();
				LBL_APPNO.Text		= regno;
				LBL_NAME.Text		= Request.QueryString["nama"].ToString();
				LBL_CIF.Text		= Request.QueryString["cif"].ToString();
				LBL_NPWP.Text		= Request.QueryString["npwp"].ToString();
				conn.QueryString = "select productid, productdesc, tenor, cp_limit, "+
					"status = case when cp_reject='1' then 'Ditolak' when cp_cancel='1' then 'Dibatalkan' else 'proses' end "+
					"from vw_productlist where ap_regno='"+regno+"'";
				conn.ExecuteQuery();
				DataTable data = new DataTable();
				data = conn.GetDataTable().Copy();
				DGR_PRODUCT.DataSource = data;
				DGR_PRODUCT.DataBind();
				for (int i = 0; i < DGR_PRODUCT.Items.Count; i++)
					DGR_PRODUCT.Items[i].Cells[3].Text = tools.MoneyFormat(DGR_PRODUCT.Items[i].Cells[3].Text);
				ViewData();
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

		private void ViewData()
		{
			conn.QueryString = "select ci_seq, convert(varchar,ci_date,106)+' '+convert(varchar,ci_date,108) as ci_date, ci_content, ci_answer, ci_userid "+
				"from CUST_INTERACTION where ap_regno='"+LBL_APPNO.Text+"'";
			conn.ExecuteQuery();
			DataTable d1		= new DataTable();
			d1					= conn.GetDataTable().Copy();
			DGR_MEMO.DataSource	= d1;
			DGR_MEMO.DataBind();
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			if ((TXT_COMMENT.Text.Trim()!="") || (TXT_ANSWER.Text.Trim()!=""))
			{
				conn.QueryString = "exec ENTRY_INTER_MEMO '"+LBL_APPNO.Text+"', '"+TXT_COMMENT.Text+"', '"+TXT_ANSWER.Text+"', '"+Session["UserID"]+"'";
				conn.ExecuteNonQuery();
			}
			TXT_COMMENT.Text	= "";
			TXT_ANSWER.Text		= "";
			ViewData();
			//Response.Redirect("CustInteraction.aspx");
		}
	}
}
