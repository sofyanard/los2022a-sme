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

namespace SME.Legal
{
	/// <summary>
	/// Summary description for DetailLegalSigning.
	/// </summary>
	public partial class DetailLegalSigning : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SME;uid=sa;pwd=");
		protected Connection conn;
		protected Tools tool = new Tools();
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_TC.Text = Request.QueryString["tc"];
				
				ViewList();
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

		private void ViewList()
		{
			conn.QueryString = "select PR.PRODUCTID, PR.PRODUCTDESC, CP.PROD_SEQ "+
				"from CUSTPRODUCT CP "+
				"join RFPRODUCT PR on PR.PRODUCTID = CP.PRODUCTID "+
				"where CP.AP_REGNO = '"+ LBL_REGNO.Text +"' ";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			string productid;
			for (int i = 0; i < row; i++)
			{
				productid = conn.GetFieldValue(i, 0);
				HyperLink t = new HyperLink();
				t.Text = productid +" - "+conn.GetFieldValue(i, 1);
				t.CssClass = "TDBGColor1";
				t.Font.Bold = true;
				
				t.NavigateUrl = "FasilitasLegalSigning_Data.aspx?regno="+ LBL_REGNO.Text +"&curef="+ LBL_CUREF.Text +"&tc="+ LBL_TC.Text +"&productid="+ productid + "&prod_seq=" + conn.GetFieldValue(i, "prod_seq"); 
				t.Target = "frm_fasilitas";
				this.TBL_FASILITAS.Rows.Add(new TableRow());
				this.TBL_FASILITAS.Rows[i].Cells.Add(new TableCell());
				this.TBL_FASILITAS.Rows[i].Cells[0].Controls.Add(t);
			}
		}
	}
}
