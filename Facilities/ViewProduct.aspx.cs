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

namespace SME.Facilities
{
	/// <summary>
	/// Summary description for ViewProduct.
	/// </summary>
	public partial class ViewProduct : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
			//	Response.Redirect("/SME/Restricted.aspx");

			DataTable dt = new DataTable();
			if (Request.QueryString["tc"] == "5.4") 
			{
				conn.QueryString = "select * from VW_INQUARYSTAGE_VIEW where AP_REGNO = '"+Request.QueryString["regno"]+"'";
			}
			else 
			{
				conn.QueryString = "select * from VW_INQUARYSTAGE_VIEW where AP_REGNO = '"+Request.QueryString["regno"]+"' and AP_CURRTRACK = '"+Request.QueryString["tc"]+"'";
			}
			conn.ExecuteQuery();
			
			LBL_AP_REGNO.Text	= conn.GetFieldValue("AP_REGNO").ToString();
			LBL_TRACKNAME.Text	= conn.GetFieldValue("TRACKNAME").ToString();

			dt = conn.GetDataTable().Copy();
			DatGrid.DataSource = dt;
			DatGrid.DataBind();
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
