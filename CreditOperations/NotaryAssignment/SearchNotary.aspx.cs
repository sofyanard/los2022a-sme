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

namespace SME.CreditOperations.NotaryAssignment
{
	/// <summary>
	/// Summary description for SearchNotary.
	/// </summary>
	public partial class SearchNotary : System.Web.UI.Page
	{
		protected Connection conn;
		private string theForm = "", theObj = "", theObjDesc = "";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = new Connection(Session["ConnString"].ToString());

			theForm = Request.QueryString["targetFormID"];
			theObj = Request.QueryString["targetObjectID"];
			theObjDesc = Request.QueryString["targetObjectDesc"];

			ok.Attributes.Add("onclick","pilih('" + theObj + "', '" + theObjDesc + "');");
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

		protected void BTN_SEARCH_Click(object sender, System.EventArgs e)
		{
			string qry = "SELECT NTID, NT_NAME FROM RFNOTARY WHERE ACTIVE = '1' ";

			if (TXT_NAME.Text != "")
				qry = qry + " AND NT_NAME LIKE '%" + TXT_NAME.Text + "%' ";

			qry = qry + " ORDER BY NT_NAME";
			conn.QueryString = qry;
			conn.ExecuteQuery();

			LST_RESULT.Items.Clear();
			for (int i = 0; i < conn.GetRowCount(); i++)
				LST_RESULT.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}
	}
}
