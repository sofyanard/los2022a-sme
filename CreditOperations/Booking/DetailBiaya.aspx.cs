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

namespace SME.CreditOperations.Booking
{
	/// <summary>
	/// Summary description for DetailBiaya.
	/// </summary>
	public partial class DetailBiaya : System.Web.UI.Page
	{
		
		protected Connection conn;
		protected Tools tool = new Tools();
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if(!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_TC.Text = Request.QueryString["tc"];
				ViewList();
				bindData();
				conn.QueryString = "select top 1 PRODUCTID , APPTYPE, PROD_SEQ from VW_CREOPR_NOTARYASSIGN_CREDLIST "+
					"where AP_REGNO = '"+ LBL_REGNO.Text +"' order by apptype, productid ";
				conn.ExecuteQuery();
				if(conn.GetRowCount() > 0)
				{
					string autoLoadScript = "<script language='javascript'>" +
						"document.getElementById('frm_fasilitas').src='DetailBiayaKredit.aspx?regno=" +
						LBL_REGNO.Text + "&curef=" + LBL_CUREF.Text + "&tc=" + LBL_TC.Text + "&productid="
						+ conn.GetFieldValue(0,0) + "&apptype=" + conn.GetFieldValue(0,1) + "';</script>";
					Page.RegisterStartupScript("LoadScript ", autoLoadScript);
				}
			}
			DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
		}

		private void ViewList()
		{
			conn.QueryString = "select distinct PRODUCTID , PRODUCTDESC , APPTYPE , APPTYPEDESC, PROD_SEQ "+
				"from VW_CREOPR_NOTARYASSIGN_CREDLIST "+
				"where AP_REGNO = '"+ LBL_REGNO.Text +"' order by apptype, productid ";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			string productid, apptype;
			for (int i = 0; i < row; i++)
			{
				productid = conn.GetFieldValue(i, 0);
				apptype = conn.GetFieldValue(i, 2);
				HyperLink t = new HyperLink();
				t.Text = productid + " - " + conn.GetFieldValue(i, 1) + " (" + conn.GetFieldValue(i, 3) + ") ";
				t.CssClass = "TDBGColor1";
				t.Font.Bold = true;
				
				t.NavigateUrl = "DetailBiayaKredit.aspx?regno=" + LBL_REGNO.Text + "&curef=" + LBL_CUREF.Text +
					"&tc=" + LBL_TC.Text + "&productid=" + productid + "&apptype=" + apptype;
				t.Target = "frm_fasilitas";
				this.TBL_FASILITAS.Rows.Add(new TableRow());
				this.TBL_FASILITAS.Rows[i].Cells.Add(new TableCell());
				this.TBL_FASILITAS.Rows[i].Cells[0].Controls.Add(t);
			}
		}

		private void bindData()
		{
			DataTable dt = new DataTable();
			DataRow dr;
			conn.QueryString = "SELECT SEQ, IC_DESC, IT_DESC, ALI_AMOUNT, ALI_PERCENTAGE, ALI_PREMI, "+
				"IC_ID, IT_ID, ALI_ICRATE, CURRENCYID, CURRENCYDESC, "+
				"ALI_POLICYNO, ALI_DATESTART, ALI_DATEEND " +
				"FROM VW_CREOPR_NOTARYASSIGN_INSURANCE WHERE AP_REGNO = '" + Request.QueryString["regno"] +
				"' ORDER BY IC_DESC ";
			conn.ExecuteQuery();
			dt.Columns.Add(new DataColumn("SEQ"));
			dt.Columns.Add(new DataColumn("INSRCOMPDESC"));
			dt.Columns.Add(new DataColumn("INSRTYPEDESC"));
			dt.Columns.Add(new DataColumn("AN_VALUE"));
			dt.Columns.Add(new DataColumn("AN_PERCENTAGE"));
			dt.Columns.Add(new DataColumn("AN_PREMI"));
			dt.Columns.Add(new DataColumn("IC_ID"));
			dt.Columns.Add(new DataColumn("IT_ID"));
			dt.Columns.Add(new DataColumn("RATE"));
			dt.Columns.Add(new DataColumn("CUR_ID"));
			dt.Columns.Add(new DataColumn("AN_CUR"));
			dt.Columns.Add(new DataColumn("AN_POLICYNO"));
			dt.Columns.Add(new DataColumn("AN_DATESTART"));
			dt.Columns.Add(new DataColumn("AN_DATEEND"));
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				dr = dt.NewRow();
				for (int j = 0; j < conn.GetColumnCount(); j++)
				{
					dr[j] = conn.GetFieldValue(i,j);
				}
				dt.Rows.Add(dr);
			}
			DataGrid1.DataSource = new DataView(dt);
			try 
			{
				DataGrid1.DataBind();
			} 
			catch 
			{
				DataGrid1.CurrentPageIndex = 0;
				DataGrid1.DataBind();
			}
			for (int j = 0; j < DataGrid1.Items.Count; j++)
			{
				DataGrid1.Items[j].Cells[5].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[5].Text );
				DataGrid1.Items[j].Cells[8].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[8].Text );
				DataGrid1.Items[j].Cells[9].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[9].Text );
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

		void Grid_Change(Object sender, DataGridPageChangedEventArgs e) 
		{
			// Set CurrentPageIndex to the page the user clicked.
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData();	
		}

	}
}
