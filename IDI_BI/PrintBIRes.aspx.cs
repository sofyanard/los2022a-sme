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
using DMS.BlackList;

namespace SME.IDI_BI
{
	/// <summary>
	/// Summary description for PrintBIRes.
	/// </summary>
	public partial class PrintBIRes : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			if (!IsPostBack)
			{	
				conn.QueryString = "select * from idi_result where idi_req#='" + Request.QueryString["regnum"] + "' ";
				conn.ExecuteQuery();
				FillGrid_DataAgunan();

				conn.QueryString = "select * from idi_result where idi_req#='" + Request.QueryString["regnum"] + "' ";
				conn.ExecuteQuery();
				FillGrid_DataKredit();

				conn.QueryString = "select * from idi_result where idi_req#='" + Request.QueryString["regnum"] + "' ";
				conn.ExecuteQuery();
				FillGrid_DataIrre();

				conn.QueryString = "select * from idi_result where idi_req#='" + Request.QueryString["regnum"] + "' ";
				conn.ExecuteQuery();
				FillGrid_DataBG();
				
				conn.QueryString = "select * from idi_result where idi_req#='" + Request.QueryString["regnum"] + "' ";
				conn.ExecuteQuery();
				LBL_IDI_REQ.Text = Request.QueryString["regnum"];
				LBL_DATE.Text = tool.FormatDate(conn.GetFieldValue("idi_reqdate"), false);
			}
		}

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
