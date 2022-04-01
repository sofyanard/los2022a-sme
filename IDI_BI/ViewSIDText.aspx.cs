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
using System.Configuration;
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.IDI_BI
{
	/// <summary>
	/// Summary description for ViewSIDText.
	/// </summary>
	public partial class ViewSIDText : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlTableRow tr_print;
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			Label4.Text = Request.QueryString["regno"];
			Label5.Text= Request.QueryString["no_din"];
			
			//object [] par = new object[3]{Request.QueryString["regno"],Request.QueryString["seq"],Request.QueryString["status_app"]};
			conn = new Connection((string) Session["ConnString"]);
			conn.QueryString = "exec IDI_USP_VIEWSIDTEXT '"+Label4.Text+"', '"+Label5.Text+"'";
			conn.ExecuteQuery();

			if(conn.GetRowCount() != 0)
			{
				if(conn.GetFieldValue("SIDTEXT").ToString().ToLower().IndexOf("html")!=-1)
				{
					TR_TEXT.Visible = false;
					
					//frSID.Visible=true;
					//frSID.InnerHtml = conn.GetFieldValue("SIDTEXT").ToString();
					
					Response.Write(conn.GetFieldValue("SIDTEXT").ToString());
					Response.End();
				}

				else
				{
					TR_TEXT.Visible = true;
					TXT_TEXT.Text = conn.GetFieldValue("SIDTEXT").ToString();
				}
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
