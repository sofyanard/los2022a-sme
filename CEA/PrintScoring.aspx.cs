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
namespace SME.CEA
{
	/// <summary>
	/// Summary description for PrintScoring.
	/// </summary>
	public partial class PrintScoring : System.Web.UI.Page
	{

		protected Tools tool = new Tools();

		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			ViewData();

		}

		private void ViewData()
		{
			conn.QueryString="select * from rekanan_score where regnum='" + Request.QueryString["regnum"] + "' ";
			conn.ExecuteQuery();
			TXT_TOTAL_QUAN.Text=conn.GetFieldValue("sc_kuantitatif");
			TXT_TOTAL_QUAL.Text=conn.GetFieldValue("sc_kualitatif");
			TOTAL_SCORING.Text=conn.GetFieldValue("total");
			KLASIFIKASI.Text=conn.GetFieldValue("klasifikasi");

			conn.QueryString="select * from vw_rekanan where regnum='" + Request.QueryString["regnum"] + "' ";
			conn.ExecuteQuery();
			LBL_REKANAN_REF.Text=conn.GetFieldValue("rekanan_ref");
			LBL_REGNUM.Text=conn.GetFieldValue("regnum");
			LBL_NAMA.Text=conn.GetFieldValue("namerekanan");
			LBL_RFREKANANTYPE.Text=conn.GetFieldValue("rfrekanantype");

			conn.QueryString="select * from rfjenisrekanan where rekananid='" + LBL_RFREKANANTYPE.Text + "' ";
			conn.ExecuteQuery();

			LBL_JENIS_REKANAN.Text=conn.GetFieldValue("rekanandesc");

			BindQual();			    
			BindDataQuanitative();
			BindCla();

		}

		private void BindDataQuanitative()
		{
			conn.QueryString = "select * from vw_rekanan_print_quanscoring WHERE regnum = '" + Request.QueryString["regnum"] + "' ";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_QUAN.DataSource = dt;
			try 
			{
				DGR_QUAN.DataBind();
			}
			catch 
			{
				DGR_QUAN.CurrentPageIndex = 0;
				DGR_QUAN.DataBind();
			}					
		}

		private void BindQual()
		{
			conn.QueryString = "select * from vw_rekanan_print_scoring WHERE regnum = '" + Request.QueryString["regnum"] + "' ";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_QUAL.DataSource = dt;
			try 
			{
				DGR_QUAL.DataBind();
			}
			catch 
			{
				DGR_QUAL.CurrentPageIndex = 0;
				DGR_QUAL.DataBind();
			}
			
		}

		private void BindCla()
		{
			conn.QueryString="select * from vw_rekanan_print_CritScoring WHERE regnum = '" + Request.QueryString["regnum"] + "' ORDER BY CRITEID";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_CLA.DataSource = dt;
			try 
			{
				DGR_CLA.DataBind();
			}
			catch 
			{
				DGR_CLA.CurrentPageIndex = 0;
				DGR_CLA.DataBind();
			}

			
		}

		private void DGR_QUAN_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_QUAN.CurrentPageIndex = e.NewPageIndex;
			BindDataQuanitative();
		}
		
		private void DGR_QUAL_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_QUAL.CurrentPageIndex = e.NewPageIndex;
			BindQual();
		}

		private void DGR_CLA_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_CLA.CurrentPageIndex = e.NewPageIndex;
			BindCla();
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
