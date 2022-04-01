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

namespace SME.CreditOperations.RejectMaintenance
{
	/// <summary>
	/// Summary description for Jaminan_List.
	/// </summary>
	public partial class Jaminan_List : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				ViewData();
			}
		}

		private void ViewData()
		{
			string curef = Request.QueryString["curef"],
				regno = Request.QueryString["regno"],
				prod = Request.QueryString["productid"], 
				prod_seq = Request.QueryString["prod_seq"];
			
			/*
			conn.QueryString = "select DISTINCT cl.CL_SEQ, cl.CL_TYPE, ct.COLTYPEDESC, ct.COLLINKTABLE, " +
				"cl.CL_DESC, lc.AP_REGNO, lc.PRODUCTID " +
				"from LISTCOLLATERAL lc join COLLATERAL cl on lc.CU_REF = cl.CU_REF and lc.CL_SEQ = cl.CL_SEQ " +
				"left join RFCOLLATERALTYPE ct on cl.CL_TYPE = ct.COLTYPESEQ " +
				"left join COLLATERAL_ADDDE ca on ca.AP_REGNO = lc.AP_REGNO and ca.CL_SEQ = cl.CL_SEQ " +
				"where lc.AP_REGNO = '" + regno + "' and lc.PRODUCTID = '" + prod + "' and lc.PROD_SEQ = '" + prod_seq + "'";
			conn.ExecuteQuery();
			*/
			conn.QueryString = "EXEC CREOPR_REJECTMNT_JAMINANLIST '" + regno + "', '" + prod + "', '" + prod_seq + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() == 0)
			{
				Tools.popMessage(this, "Data jaminan tidak ada.");
				return;
			}

			int tblRowCount = Table_List.Rows.Count;
			for (int i = tblRowCount - 1; i >= 0; i--)
				Table_List.Rows.Remove(Table_List.Rows[i]);

			int row = conn.GetRowCount();
			int rowtemp = row;
			string cl_type = "", cl_seq = "";
			for (int i = 0; i < row; i++)
			{
				HyperLink t = new HyperLink();
				t.Text = conn.GetFieldValue(i, 0)+". "+conn.GetFieldValue(i, "CL_DESC") + " (" + conn.GetFieldValue(i,2) + ")";
				t.CssClass = "TDBGColor1";
				t.Font.Bold = true;
				cl_seq = conn.GetFieldValue(i,0);
				cl_type = conn.GetFieldValue(i,1);

				//t.NavigateUrl = "../../DataEntry/" + conn.GetFieldValue(i, 3) +".aspx?curef="+ curef +"&coltypeid="+ cl_type +"&CL_SEQ="+ cl_seq  +"&de=" +Request.QueryString["de"];
				//t.Target = "coldetail";
				t.NavigateUrl = "Jaminan_Legal.aspx?regno=" + regno + "&curef=" + curef + 
					"&coltypeid=" + cl_type + "&CL_SEQ=" + cl_seq + "&de=" + Request.QueryString["de"] +
					"&collnk=" + conn.GetFieldValue(i, 3);
				t.Target = "collegal";
				this.Table_List.Rows.Add(new TableRow());
				this.Table_List.Rows[i].Cells.Add(new TableCell());
				this.Table_List.Rows[i].Cells[0].Controls.Add(t);
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

		}
		#endregion
	}
}
