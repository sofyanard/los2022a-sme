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

namespace SME.CreditOperations.RejectMaintenance
{
	/// <summary>
	/// Summary description for Jaminan_Legal.
	/// </summary>
	public partial class Jaminan_Legal : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_CL_SEQ.Text = Request.QueryString["cl_seq"];

				//init rfikat
				//--- Jenis Pengikatan
				conn.QueryString = "select IKATID, IKATID + ' - ' + IKATDESC AS IKATDESC from RFIKAT where active = '1' order by IKATID";
				conn.ExecuteQuery();
				DDL_CL_IKATTYPE.Items.Clear();
				DDL_CL_IKATTYPE.Items.Add(new ListItem("-- Pilih --", ""));
				for (int i=0; i<conn.GetRowCount(); i++)
					DDL_CL_IKATTYPE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//init rflegalstatus
				conn.QueryString = "select LEGALSTAID, LEGALSTADESC from RFLEGALSTATUS where active = '1' ";
				conn.ExecuteQuery();
				RBL_LEGALSTACOL.Items.Clear();
				for (int i=0; i<conn.GetRowCount(); i++)
					RBL_LEGALSTACOL.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				Response.Write("<script language='JavaScript'>window.parent.document.getElementById('coldetail').src='" +
					"../../RejectMaintenanceDE/" + Request.QueryString["collnk"] + ".aspx?curef=" + Request.QueryString["curef"] +
					"&coltypeid=" + Request.QueryString["coltypeid"] + "&CL_SEQ=" + Request.QueryString["CL_SEQ"] +
					"&de=" + Request.QueryString["de"] + "';</script>");
				ViewDataJaminan();
			}
		}

		private void ViewDataJaminan()
		{
			conn.QueryString = "select top 1 ACL_IKATID, ACL_LEGALSTATUS "+
				"FROM VW_CREOPR_NOTARYASSIGN_COLDATA "+
				"WHERE AP_REGNO = '"+ LBL_REGNO.Text +//"' AND PRODUCTID = '" + LBL_PRODUCTID.Text +
				"' AND CL_SEQ = "+ LBL_CL_SEQ.Text +" ";
			conn.ExecuteQuery();

			try
			{
				DDL_CL_IKATTYPE.SelectedValue = conn.GetFieldValue("ACL_IKATID").Trim();
			} 
			catch {}
			try
			{
				RBL_LEGALSTACOL.SelectedValue = conn.GetFieldValue("ACL_LEGALSTATUS").Trim();
			} 
			catch{}
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

		protected void BTN_SAVE_JAMINAN_Click(object sender, System.EventArgs e)
		{
			string cm = RBL_LEGALSTACOL.SelectedValue.Trim(),
				ikat = DDL_CL_IKATTYPE.SelectedValue.Trim();
			conn.QueryString = "exec LGL_SCOL '"+ LBL_REGNO.Text +"', null, "+
				LBL_CL_SEQ.Text + ", '" + ikat + "', '" + cm + "' ";
			conn.ExecuteNonQuery();
			ViewDataJaminan();
		}
	}
}
