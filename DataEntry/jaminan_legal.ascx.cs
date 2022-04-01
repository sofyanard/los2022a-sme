namespace SME.DataEntry
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using DMS.DBConnection;

	/// <summary>
	///		Summary description for jaminan_legal.
	/// </summary>
	public partial class jaminan_legal : System.Web.UI.UserControl
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

				ViewDataJaminan();
				SecureData();
			}
			else
			{
				SaveDataJaminan();
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

		private void SaveDataJaminan()
		{
			string cm = RBL_LEGALSTACOL.SelectedValue.Trim(),
				ikat = DDL_CL_IKATTYPE.SelectedValue.Trim();
			conn.QueryString = "exec LGL_SCOL '"+ LBL_REGNO.Text +"', null, "+
				LBL_CL_SEQ.Text + ", '" + ikat + "', '" + cm + "' ";
			conn.ExecuteNonQuery();
		}

		private void SecureData() 
		{
			string de = Request.QueryString["de"];
			if (de != "1") 
			{
				DDL_CL_IKATTYPE.Enabled = false;
				RBL_LEGALSTACOL.Enabled = false;
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion

	}
}
