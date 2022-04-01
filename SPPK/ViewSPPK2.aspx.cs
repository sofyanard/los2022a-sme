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

namespace SME.SPPK
{
	/// <summary>
	/// Summary description for ViewSPPK2.
	/// </summary>
	public partial class ViewSPPK2 : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				ViewData();
			}

			BTN_BACK.Click += new ImageClickEventHandler(BTN_BACK_Click);
		}

		private void ViewData()
		{
			lbl_regno.Text		= Request.QueryString["regno"];
			lbl_curef.Text		= Request.QueryString["curef"];

			HyperLink strcre = new HyperLink();
			strcre.Text = "Credit Structure";
			strcre.Font.Bold = true;
			strcre.NavigateUrl = "../dataentry/custproduct.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text+"&sta=view&de=1&mc="+Request.QueryString["mc"];
			strcre.Target = "if2";

			PlaceHolder1.Controls.Add(strcre);
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

		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["tc"] == "3.6" && Request.QueryString["mc"] == "039") 
			{
				Response.Redirect("/SME/SPPK/ListSPPKMonitor.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
			}
			else 
			{
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn));
			}
		}
	}
}
