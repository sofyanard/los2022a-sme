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
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.CreditOperations.BIChecking
{
	/// <summary>
	/// Summary description for BICheckingResult.
	/// </summary>
	public partial class BICheckingResult : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button BTN_UPDATESTATUS;
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			if (!IsPostBack)
				bindData();	
			ViewMenu();
		}

		private void bindData()
		{
			DataTable dt = new DataTable();
			DataRow dr;
			conn.QueryString = "SELECT CU_REF, CS_SEQ, BR_SEQ, NAME, ALAMAT, BANKID, REKENING, "+
				"JENISKREDIT, LIMIT, BAKIDEBET, COLLECTID, JAMINAN, BANKNAME, COLLECTDESC "+
				"FROM VW_CREOPR_BICHECK_RESULTENTRY WHERE AP_REGNO = '" + Request.QueryString["regno"] +
				"' ORDER BY AP_REGNO, CU_REF, CS_SEQ, BR_SEQ ";
			conn.ExecuteQuery();
			dt.Columns.Add(new DataColumn("CU_REF"));
			dt.Columns.Add(new DataColumn("CS_SEQ"));
			dt.Columns.Add(new DataColumn("BR_SEQ"));
			dt.Columns.Add(new DataColumn("NAME"));
			dt.Columns.Add(new DataColumn("ALAMAT"));
			dt.Columns.Add(new DataColumn("BANKID"));
			dt.Columns.Add(new DataColumn("REKENING"));
			dt.Columns.Add(new DataColumn("JENISKREDIT"));
			dt.Columns.Add(new DataColumn("LIMIT"));
			dt.Columns.Add(new DataColumn("BAKIDEBET"));
			dt.Columns.Add(new DataColumn("COLLECTID"));
			dt.Columns.Add(new DataColumn("JAMINAN"));
			dt.Columns.Add(new DataColumn("BANKNAME"));
			dt.Columns.Add(new DataColumn("COLLECTDESC"));
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
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
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
