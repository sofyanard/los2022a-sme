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
using Microsoft.VisualBasic;

namespace SME.IDI_BI
{
	/// <summary>
	/// Summary description for FullBIRes.
	/// </summary>
	public partial class FullBIRes : System.Web.UI.Page
	{
		protected Connection conn = new Connection();
		protected Tools tools = new Tools();
		
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			if (!IsPostBack)
			{	
				//conn.QueryString = "select * from idi_result where idi_req#='" + Request.QueryString["regnum"] + "' ";
				conn.QueryString = "SELECT * FROM VW_IDI_BI_KREDIT where ap_regno='" + Request.QueryString["regnum"] + "'  and dpt_nosurat='" + Request.QueryString["no_surat"] + "' ";
				conn.ExecuteQuery();
				FillGrid_DataKredit();

				//conn.QueryString = "select * from idi_result where idi_req#='" + Request.QueryString["regnum"] + "' ";
				conn.QueryString = "SELECT * FROM VW_IDI_BI_AGUNAN where ap_regno='" + Request.QueryString["regnum"] + "' and dpt_nosurat='" + Request.QueryString["no_surat"] + "' ";
				conn.ExecuteQuery();
				FillGrid_DataAgunan();				

				//conn.QueryString = "select * from idi_result where idi_req#='" + Request.QueryString["regnum"] + "' ";
				conn.QueryString = "SELECT * FROM VW_IDI_BI_LC where ap_regno='" + Request.QueryString["regnum"] + "' and dpt_nosurat='" + Request.QueryString["no_surat"] + "' ";
				conn.ExecuteQuery();
				FillGrid_DataIrre();

				//conn.QueryString = "select * from idi_result where idi_req#='" + Request.QueryString["regnum"] + "' ";
				conn.QueryString = "SELECT * FROM VW_IDI_BI_BG where ap_regno='" + Request.QueryString["regnum"] + "' and dpt_nosurat='" + Request.QueryString["no_surat"] + "' ";
				conn.ExecuteQuery();				
				FillGrid_DataBG();		
				
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

		private void FillGrid_DataKredit()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_DATAKREDIT.DataSource = dt;
			try 
			{
				DGR_DATAKREDIT.DataBind();
			} 
			catch 
			{
				DGR_DATAKREDIT.CurrentPageIndex = 0;
				DGR_DATAKREDIT.DataBind();
			}
		}

		private void FillGrid_DataAgunan()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_DATAAGUNAN.DataSource = dt;
			try 
			{
				DGR_DATAAGUNAN.DataBind();
			} 
			catch 
			{
				DGR_DATAAGUNAN.CurrentPageIndex = 0;
				DGR_DATAAGUNAN.DataBind();
			}
		}

		private void FillGrid_DataIrre()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_IRR.DataSource = dt;
			try 
			{
				DGR_IRR.DataBind();
			} 
			catch 
			{
				DGR_IRR.CurrentPageIndex = 0;
				DGR_IRR.DataBind();
			}
		}

		private void FillGrid_DataBG()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_BG.DataSource = dt;
			try 
			{
				DGR_BG.DataBind();
			} 
			catch 
			{
				DGR_BG.CurrentPageIndex = 0;
				DGR_BG.DataBind();
			}
		}

		protected void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
			//Response.Redirect("/SME/IDI_BI/PrintBIRes.aspx?sta=exist&regnum=" + Request.QueryString["regnum"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);	
			//Response.Write("<script language='javascript'>window.open('ViewSIDText.aspx?regno=" + Request.QueryString["regnum"] + "&no_din=" + Request.QueryString["no_din"] + "','ViewSIDText','status=no,scrollbars=yes,width=1000,height=600');</script>");	
			Response.Redirect("/SME/IDI_BI/ViewSIDText.aspx?sta=exist&regno=" + Request.QueryString["regnum"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]+ "&no_din="  + Request.QueryString["no_din"]);	
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("RetreiveBIRes.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}
	}
}
