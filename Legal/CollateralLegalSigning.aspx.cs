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
	/// Summary description for CollateralLegalSigning.
	/// </summary>
	public partial class CollateralLegalSigning : System.Web.UI.Page
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
				ViewJaminan();
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

		private void ViewJaminan()
		{
			conn.QueryString = "select CL.CL_SEQ, CL.CL_TYPE "+
				", CT.COLTYPEID, CT.COLTYPEDESC "+
				"from COLLATERAL CL "+
				"join RFCOLLATERALTYPE CT on CT.COLTYPESEQ = CL.CL_TYPE "+
				"where CU_REF = '"+ LBL_CUREF.Text +"' ";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			string CL_TYPE, cl_seq;
			for (int i = 0; i < row; i++)
			{
				cl_seq = conn.GetFieldValue(i, 0);
				CL_TYPE= conn.GetFieldValue(i, 1);
				HyperLink t = new HyperLink();
				t.Text = conn.GetFieldValue(i, 2) +" - "+ conn.GetFieldValue(i, 3);
				t.CssClass = "TDBGColor1";
				t.Font.Bold = true;
				
				t.NavigateUrl = "CollateralLegalSigning_Data.aspx?regno="+ LBL_REGNO.Text +"&curef="+ LBL_CUREF.Text +"&tc="+ LBL_TC.Text +"&cl_seq="+ cl_seq+"&cl_type="+ CL_TYPE;
				t.Target = "frm_jaminan";
				this.TBL_JAMINAN.Rows.Add(new TableRow());
				this.TBL_JAMINAN.Rows[i].Cells.Add(new TableCell());
				this.TBL_JAMINAN.Rows[i].Cells[0].Controls.Add(t);
			}
		}
	}
}
