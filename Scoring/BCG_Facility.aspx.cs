using System;
using System.IO;
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

namespace SME.Scoring
{
	/// <summary>
	/// Facility Rating per Ketentuan Kredit!!
	/// </summary>
	public partial class BCG_Facility : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected Tools tool = new Tools();
		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV2;uid=sa;pwd=dmscorp");
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
			//	Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				this.ViewData();
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

		private void ViewData() 
		{
			string ap_regno = Request.QueryString["regno"];
			string cu_ref   = Request.QueryString["curef"];
			string mc       = Request.QueryString["mc"];
			string tc       = Request.QueryString["tc"];

			//conn.QueryString = "select distinct (PRODUCTID) from CUST_PRODUCT where AP_REGNO = '" + ap_regno + "'";
			//conn.QueryString = "select distinct PRODUCTID, PROD_SEQ from CUSTPRODUCT where AP_REGNO = '" + ap_regno + "'";
			conn.QueryString = "select distinct ket_code,ket_desc from ketentuan_kredit where ap_regno='" +
				Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{				
				HyperLink lnk_fac = new HyperLink();
				lnk_fac.ID = "facility" + i;
				lnk_fac.Text = conn.GetFieldValue(i,0);
				//lnk_fac.NavigateUrl = "BCG_Facility_Detail.aspx?regno=" + ap_regno + "&ketcode=" + lnk_fac.Text + "&cu_ref=" + cu_ref + "&mc=" + mc + "&tc=" + tc + "&scr="+Request.QueryString["scr"] + "&prod_seq=" + conn.GetFieldValue(i, "PROD_SEQ");
				lnk_fac.NavigateUrl = "BCG_Facility_Detail.aspx?regno=" + ap_regno + "&ketcode=" + lnk_fac.Text + "&curef=" + cu_ref + "&mc=" + mc + "&tc=" + tc + "&scr="+Request.QueryString["scr"];
				lnk_fac.Target = "if_apptype";

				this.PH_FACILITY.Controls.Add(new LiteralControl("" + (i+1) + ".&nbsp"));
				this.PH_FACILITY.Controls.Add(lnk_fac);
				//this.PH_FACILITY.Controls.Add(new LiteralControl("&nbsp&nbsp&nbsp"));
				this.PH_FACILITY.Controls.Add(new LiteralControl("<BR><BR>"));
			}


		}
	}
}
