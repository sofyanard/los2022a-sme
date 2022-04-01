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

namespace SME.DCM.DataCorrectionRequir.SearchZipCode
{
	/// <summary>
	/// Summary description for SearchZipCode.
	/// </summary>
	public partial class SearchZipCode : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=192.168.1.200;Initial Catalog=SME;uid=sa;pwd=");
		protected Connection conn;

		private string theForm, theObj;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
			//	Response.Redirect("/SME/Restricted.aspx");

			theForm = Request.QueryString["targetFormID"].Trim();
			theObj = Request.QueryString["targetObjectID"].Trim();

			if (!IsPostBack)
			{
				//DDL_AREAID.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CITYID.Items.Add(new ListItem("- PILIH -", ""));
				DDL_REGIONID.Items.Add(new ListItem("- PILIH -", ""));
				
				/*
				conn.QueryString = "SELECT * FROM RFAREA";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_AREAID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				*/
				conn.QueryString = "select cityid, cityname from rfcity where active='1' order by cityname";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CITYID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

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

		protected void btn_OK_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='JavaScript1.2'>window.opener.document." + 
				theForm + "." + theObj + ".value='" + txt_ZIPCODE.Text.Trim() + "'; " +
				"window.opener.document." + theForm + ".submit(); window.close();</script>");
		}

		protected void btn_Cancel_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='JavaScript1.2'>window.close();</script>");
		}

		/*
		private void DDL_AREAID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DDL_CITYID.Items.Clear();
			DDL_CITYID.Items.Add(new ListItem("- PILIH -", ""));

			DDL_REGIONID.Items.Clear();
			DDL_REGIONID.Items.Add(new ListItem("- PILIH -", ""));

			conn.QueryString = "select cityid, cityname from rfcity where areaid='" + DDL_AREAID.SelectedValue + "' and active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CITYID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}
		*/

		protected void DDL_CITYID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DDL_REGIONID.Items.Clear();
			DDL_REGIONID.Items.Add(new ListItem("- PILIH -", ""));
			
			//conn.QueryString = "select zipcode, description from rfzipcodecity where cityid='" + DDL_CITYID.SelectedValue + "' and active='1' order by [description]";

			//////////////////////////////////////////////////////
			/// urut berdasarkan zipcode (yudi)
			/// 
			conn.QueryString = "select zipcode, description from rfzipcodecity " + 
				"where cityid='" + DDL_CITYID.SelectedValue + 
				"' and active='1' order by rtrim(ltrim(zipcode))";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_REGIONID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		protected void DDL_REGIONID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txt_ZIPCODE.Text = DDL_REGIONID.SelectedValue;		
		}
	}
}
