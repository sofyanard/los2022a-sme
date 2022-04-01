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
	/// Summary description for DetailBiayaKredit.
	/// </summary>
	public partial class DetailBiayaKredit : System.Web.UI.Page
	{
	
		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_TC.Text = Request.QueryString["tc"];
				LBL_PRODUCTID.Text = Request.QueryString["productid"];
				LBL_APPTYPE.Text = Request.QueryString["apptype"];

				ViewData();
				bindData();
			}
			DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
		}

		private void ViewData()
		{
			conn.QueryString = "select APL_BEAADM, APL_BEAPROVISI, APL_BEANOTARIS, APL_BEAIKAT, APL_BEAMATERAI, APL_LEGALSTATUS "+
				"from appproductlegal where AP_REGNO = '"+ LBL_REGNO.Text + "' and PRODUCTID = '"+
				LBL_PRODUCTID.Text + "' and APPTYPE = '" + LBL_APPTYPE.Text + "' ";
			conn.ExecuteQuery();

			TXT_CP_BEAADM.Text = tool.MoneyFormat(conn.GetFieldValue("APL_BEAADM"));
			TXT_CP_BEAPROVISI.Text = tool.MoneyFormat(conn.GetFieldValue("APL_BEAPROVISI"));
			TXT_CP_BEANOTARIS.Text = tool.MoneyFormat(conn.GetFieldValue("APL_BEANOTARIS"));
			TXT_CP_BEAIKAT.Text = tool.MoneyFormat(conn.GetFieldValue("APL_BEAIKAT"));
			TXT_CP_BEAMATERAI.Text = tool.MoneyFormat(conn.GetFieldValue("APL_BEAMATERAI"));
		}

		private void bindData()
		{
			DataTable dt = new DataTable();
			DataRow dr;
			conn.QueryString = "SELECT SEQ, ICT_DESC, IC_DESC, IT_DESC, ACR_AMOUNT, " +
				"ACR_PERCENTAGE, ACR_PREMI, IC_ID, IT_ID, ACR_ICRATE, ICT_ID, CURRENCYID, CURRENCYDESC, "+
				"ACR_POLICYNO, ACR_DATESTART, ACR_DATEEND " +
				"FROM VW_CREOPR_NOTARYASSIGN_CREDASU WHERE AP_REGNO = '" + LBL_REGNO.Text.Trim() +
				"' AND PRODUCTID = '" + LBL_PRODUCTID.Text.Trim() + "' and APPTYPE = '" + LBL_APPTYPE.Text.Trim() + 
				"' ORDER BY IC_DESC ";
			conn.ExecuteQuery();
			dt.Columns.Add(new DataColumn("SEQ"));
			dt.Columns.Add(new DataColumn("ICT_DESC"));
			dt.Columns.Add(new DataColumn("INSRCOMPDESC"));
			dt.Columns.Add(new DataColumn("INSRTYPEDESC"));
			dt.Columns.Add(new DataColumn("AN_VALUE"));
			dt.Columns.Add(new DataColumn("AN_PERCENTAGE"));
			dt.Columns.Add(new DataColumn("AN_PREMI"));
			dt.Columns.Add(new DataColumn("IC_ID"));
			dt.Columns.Add(new DataColumn("IT_ID"));
			dt.Columns.Add(new DataColumn("RATE"));
			dt.Columns.Add(new DataColumn("ICT_ID"));
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
				DataGrid1.Items[j].Cells[6].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[6].Text );
				DataGrid1.Items[j].Cells[9].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[9].Text );
				DataGrid1.Items[j].Cells[10].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[10].Text );
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
