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

namespace SME.CreditOperations.Booking
{
	/// <summary>
	/// Summary description for DetailJaminan.
	/// </summary>
	public partial class DetailJaminan : System.Web.UI.Page
	{
	
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_TC.Text = Request.QueryString["tc"];
				ViewJaminan();
				conn.QueryString = "select top 1 CL_SEQ, CL_TYPE "+
					"from VW_CREOPR_NOTARYASSIGN_COLLIST "+
					"where AP_REGNO = '"+ LBL_REGNO.Text +"' ";
				conn.ExecuteQuery();
				if(conn.GetRowCount() > 0)
				{
					string autoLoadScript = "<script language='javascript'>" +
						"document.getElementById('frm_jaminan').src='DetailJaminanData.aspx?regno="+
						LBL_REGNO.Text + "&curef=" + LBL_CUREF.Text + "&tc=" + LBL_TC.Text + //"&productid=" + conn.GetFieldValue(0,0) +
						"&cl_seq=" + conn.GetFieldValue(0,0) + "&cl_type=" + conn.GetFieldValue(0,1) + "';</script>";
					Page.RegisterStartupScript("LoadScript", autoLoadScript);
				}
			}
		}

		private void ViewJaminan()
		{
			conn.QueryString = "select DISTINCT CL_SEQ, CL_TYPE "+
				", COLTYPEID, COLTYPEDESC, CU_REF, CL_DESC "+
				"from VW_CREOPR_NOTARYASSIGN_COLLIST "+
				"where AP_REGNO = '"+ LBL_REGNO.Text +"' ";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			string CL_TYPE, cl_seq, curef; //, prodid;
			for (int i = 0; i < row; i++)
			{
				cl_seq = conn.GetFieldValue(i, 0);
				CL_TYPE= conn.GetFieldValue(i, 1);
				curef= conn.GetFieldValue(i, 4);
				//prodid= conn.GetFieldValue(i, 5);
				HyperLink t = new HyperLink();
				t.Text = conn.GetFieldValue(i, 2) +" - "+ conn.GetFieldValue(i, 3);
				t.CssClass = "TDBGColor1";
				t.Font.Bold = true;
				
				t.NavigateUrl = "DetailJaminanData.aspx?regno="+ LBL_REGNO.Text +"&curef="+ curef + //"&productid="+ prodid +
					"&tc="+ LBL_TC.Text +"&cl_seq="+ cl_seq+"&cl_type="+ CL_TYPE;
				t.Target = "frm_jaminan";
				this.TBL_JAMINAN.Rows.Add(new TableRow());
				this.TBL_JAMINAN.Rows[i].Cells.Add(new TableCell());
				this.TBL_JAMINAN.Rows[i].Cells[0].Controls.Add(t);
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
	}
}
