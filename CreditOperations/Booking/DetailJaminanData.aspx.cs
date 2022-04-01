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
	/// Summary description for DetailJaminanData.
	/// </summary>
	public partial class DetailJaminanData : System.Web.UI.Page
	{
	
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				//LBL_PRODUCTID.Text = Request.QueryString["productid"];
				LBL_TC.Text = Request.QueryString["tc"];
				LBL_CL_SEQ.Text = Request.QueryString["cl_seq"];

				ViewData();
				bindData();
			}
		}

		private void ViewData()
		{
			conn.QueryString = "select top 1 APPRVALUE, LC_VALUE, CL_TYPE, ACL_IKATID, ACL_LEGALSTATUS, CL_DESC, "+
				"ADDR1, ADDR2, ADDR3 "+
				"FROM VW_CREOPR_NOTARYASSIGN_COLDATA "+
				"WHERE AP_REGNO = '"+ LBL_REGNO.Text +//"' AND PRODUCTID = '" + LBL_PRODUCTID.Text +
				"' AND CL_SEQ = "+ LBL_CL_SEQ.Text +" ";
			conn.ExecuteQuery();

			TXT_CL_DESC.Text = conn.GetFieldValue("CL_DESC");
			TXT_CL_APPRVALUE.Text = tool.MoneyFormat(conn.GetFieldValue("APPRVALUE"));
			TXT_CL_OFFERVALUE.Text = tool.MoneyFormat(conn.GetFieldValue("LC_VALUE"));
			LBL_CL_TYPE.Text = conn.GetFieldValue("CL_TYPE").Trim();
		}

		private void bindData()
		{
			DataTable dt = new DataTable();
			DataRow dr;
			conn.QueryString = "SELECT distinct SEQ, ICT_DESC, IC_DESC, IT_DESC, ACA_AMOUNT, ACA_PERCENTAGE, " +
				"ACA_CLASS, ACA_PREMI, IC_ID, IT_ID, ACA_ICRATE, ICT_ID, CURRENCYID, CURRENCYDESC, " +
				"ACA_POLICYNO, ACA_DATESTART, ACA_DATEEND "+
				"FROM VW_CREOPR_NOTARYASSIGN_COLASU WHERE AP_REGNO = '" + LBL_REGNO.Text.Trim() +
				//"' AND PRODUCTID = '" + LBL_PRODUCTID.Text.Trim() +
				"' AND CL_SEQ = " + LBL_CL_SEQ.Text +
				" ORDER BY IC_DESC ";
			conn.ExecuteQuery();
			dt.Columns.Add(new DataColumn("SEQ"));
			dt.Columns.Add(new DataColumn("ICT_DESC"));
			dt.Columns.Add(new DataColumn("INSRCOMPDESC"));
			dt.Columns.Add(new DataColumn("INSRTYPEDESC"));
			dt.Columns.Add(new DataColumn("ACA_VALUE"));
			dt.Columns.Add(new DataColumn("ACA_PERCENTAGE"));
			dt.Columns.Add(new DataColumn("ACA_CLASS"));
			dt.Columns.Add(new DataColumn("ACA_PREMI"));
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
				DataGrid1.Items[j].Cells[11].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[11].Text );
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
