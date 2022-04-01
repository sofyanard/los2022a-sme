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
using Microsoft.VisualBasic;
namespace SME.ITTP
{
	/// <summary>
	/// Summary description for WorksheetReport.
	/// </summary>
	public partial class WorksheetReport : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				ViewData();
				//secureData();
				LBL_AP_REGNO.Visible	= false;
				LBL_CUREF.Visible		= false;
				LBL_TRACK.Visible		= false;
				conn.QueryString = "SELECT TANGGAL = DATENAME(DAY, getDATE())+ ' '+DATENAME(MONTH, getDATE())+' '+DATENAME(YEAR, getDATE())";
				conn.ExecuteQuery();
				print_date.Text = conn.GetFieldValue("TANGGAL");
				bindData();
			}		
		}

		private void ViewData()
		{
			LBL_AP_REGNO.Text	= Request.QueryString["regno"];
			LBL_CUREF.Text		= Request.QueryString["curef"];
			//lbl_prod.Text		= Request.QueryString["prod"];
			LBL_TRACK.Text		= Request.QueryString["tc"];
			DataTable dt		= new DataTable();
			conn.QueryString	= "select * from vw_it_viewdata3 where ap_regno = '"+LBL_AP_REGNO.Text+"'";
			conn.ExecuteQuery();
			dt	= conn.GetDataTable().Copy();
			TXT_CU_CIF.Text		= conn.GetFieldValue("CU_CIF");
			TXT_NAME.Text		= conn.GetFieldValue("NAMA");
			TXT_IDDESC.Text		= conn.GetFieldValue("IDTYPE");
			TXT_ADDR.Text		= conn.GetFieldValue("ADDR");
			TXT_APRV.Text		= conn.GetFieldValue("APPROVAL");
			AP_RELMNGR.Text		= conn.GetFieldValue("SU_FULLNAME");
			TXT_IDNO.Text		= conn.GetFieldValue("IDNUM");
		}

		private void bindData()
		{
			conn.QueryString = "SELECT * FROM VW_IT_CREOPR_SUCCESS_LIST where CU_REF='"+LBL_CUREF.Text+"' and AP_REGNO = '"+LBL_AP_REGNO.Text+"'";
			conn.ExecuteQuery();
			DataGrid1.DataSource = conn.GetDataTable().Copy();
			try 
			{
				DataGrid1.DataBind();
			} 
			catch 
			{
				DataGrid1.CurrentPageIndex = 0;
				DataGrid1.DataBind();
			}
			for (int i = 0; i < DataGrid1.Items.Count; i++)
			{
				if (DataGrid1.Items[i].Cells[5].Text != "&nbsp;")
					DataGrid1.Items[i].Cells[5].Text = tool.MoneyFormat(DataGrid1.Items[i].Cells[5].Text);
			}

			conn.QueryString = "exec it_docworksheet '"+LBL_AP_REGNO.Text+"'";
			conn.ExecuteQuery();
			DataGrid3.DataSource = conn.GetDataTable().Copy();
			try 
			{
				DataGrid3.DataBind();
			} 
			catch 
			{
				DataGrid3.CurrentPageIndex = 0;
				DataGrid3.DataBind();
			}

			for (int i = 0; i < DataGrid3.Items.Count; i++)
			{
				if (DataGrid3.Items[i].Cells[4].Text != "&nbsp;")
					DataGrid3.Items[i].Cells[4].Text = tool.FormatDate (DataGrid3.Items[i].Cells[4].Text);
				if (DataGrid3.Items[i].Cells[5].Text != "&nbsp;")
					DataGrid3.Items[i].Cells[5].Text = tool.FormatDate (DataGrid3.Items[i].Cells[5].Text);
			}

			conn.QueryString = "SELECT * FROM VW_IT_VIEWCOLLATERAL where CU_REF='"+LBL_CUREF.Text+"' and AP_REGNO = '"+LBL_AP_REGNO.Text+"'";
			conn.ExecuteQuery();
			DataGrid2.DataSource = conn.GetDataTable().Copy();
			try 
			{
				DataGrid2.DataBind();
			} 
			catch 
			{
				DataGrid2.CurrentPageIndex = 0;
				DataGrid2.DataBind();
			}

			for (int i = 0; i < DataGrid2.Items.Count; i++)
			{
				if (DataGrid2.Items[i].Cells[4].Text != "&nbsp;")
					DataGrid2.Items[i].Cells[4].Text = tool.MoneyFormat(DataGrid2.Items[i].Cells[4].Text);
			}

		}

		private void BTN_PRINT_ServerClick(object sender, System.EventArgs e)
		{
			string USERID = (string) Session["UserID"];
			string REGNO  = Request.QueryString["regno"];

			conn.QueryString = "exec IDE_LETTERNO_INSERT '"+REGNO+"','2','"+ TXT_REMARK.Text +"','"+USERID+"'";
			conn.ExecuteQuery();
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
