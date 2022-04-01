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
	/// Summary description for DaftarPensiun.
	/// </summary>
	public partial class DaftarPensiun : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton Imagebutton1;
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			
			if(!IsPostBack)
			{
				DDL_BLN_PENSIUN.Items.Add(new ListItem("--Pilih--", ""));

				for (int i=1; i<=12; i++)
				{
					DDL_BLN_PENSIUN.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
				BindDaftarPensiun2();
			}
			
		}
		private void BindDaftarPensiun2()
		{
			conn.QueryString="select * from VW_REKANAN_Daftar_Pensiun order by pensiun_date asc" ;
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_DAFTAR.DataSource = dt;
			try 
			{
				DGR_DAFTAR.DataBind();
			}
			catch 
			{
				DGR_DAFTAR.CurrentPageIndex = 0;
				DGR_DAFTAR.DataBind();
			}	
			
			for (int i = 0; i < DGR_DAFTAR.Items.Count; i++)
			{
				DGR_DAFTAR.Items[i].Cells[6].Text = tool.FormatDate(DGR_DAFTAR.Items[i].Cells[6].Text, true);
			}
		}

		private void BindDaftarPensiun()
		{
			if (DDL_BLN_PENSIUN.SelectedValue=="")
			{
				conn.QueryString="select * from VW_REKANAN_Daftar_Pensiun order by pensiun_date asc" ;
				conn.ExecuteQuery();
			}

			else
			{
				conn.QueryString="select * from VW_REKANAN_Daftar_Pensiun where year(pensiun_date)=year(getdate()) and month(pensiun_date)='" + DDL_BLN_PENSIUN.SelectedValue + "' and rekanan_wilayah='" + Session["AreaID"].ToString() + "'";
				conn.ExecuteQuery();
			}		

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_DAFTAR.DataSource = dt;
			try 
			{
				DGR_DAFTAR.DataBind();
			}
			catch 
			{
				DGR_DAFTAR.CurrentPageIndex = 0;
				DGR_DAFTAR.DataBind();
			}	
			
			for (int i = 0; i < DGR_DAFTAR.Items.Count; i++)
			{
				DGR_DAFTAR.Items[i].Cells[6].Text = tool.FormatDate(DGR_DAFTAR.Items[i].Cells[6].Text, true);
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
			this.DGR_DAFTAR.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_DAFTAR_PageIndexChanged);

		}
		#endregion

		protected void DDL_BLN_PENSIUN_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindDaftarPensiun();
		}

		private void DGR_DAFTAR_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_DAFTAR.CurrentPageIndex = e.NewPageIndex;
			BindDaftarPensiun();
		}
	}
}
