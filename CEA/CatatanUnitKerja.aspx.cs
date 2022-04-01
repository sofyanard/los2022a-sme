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
using Microsoft.VisualBasic;

namespace SME.CEA
{
	/// <summary>
	/// Summary description for CatatanUnitKerja.
	/// </summary>
	public partial class CatatanUnitKerja : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");
			
			TXT_TGL.Text = DateAndTime.DateString;

			if(!IsPostBack)
			{
				TR_CATATAN.Visible = false;
				TR_CATATAN2.Visible = false;
				TR_BTN.Visible = false;

				conn.QueryString = "select * from vw_rekanan_existing2";
				conn.ExecuteQuery();
				FillGrid();
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);

		}
		#endregion

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			DatGrd.CurrentPageIndex = 0;
			SearchData();

			TR_CATATAN.Visible = false;
			TR_CATATAN2.Visible = false;
			TR_BTN.Visible = false;
		}

		private void SearchData()
		{
			string query=""; 
			
			if(TXT_REK_NAME.Text!="")
			{
				query += "and namerekanan LIKE '%" + TXT_REK_NAME.Text + "%' ";
			}
			if(TXT_NoReg.Text!="")
			{
				query += "and rekanan_ref='" + TXT_NoReg.Text + "' ";
			}

			//if(query!="")
			//{
				conn.QueryString = "select * from vw_rekanan_existing2 where 1=1 " + query;
				conn.ExecuteQuery();
				FillGrid();
			//}
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = 0;
				DatGrd.DataBind();
			}
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Continue":	
					TR_BTN.Visible=true;
					TR_CATATAN.Visible=true;
					TR_CATATAN2.Visible=true;
					TXT_REGNUM.Text = e.Item.Cells[0].Text;
					TXT_CATATAN.Text = "";
					TXT_UNIT_PELAPOR.Text = "";
					break;		
			}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if(TXT_UNIT_PELAPOR.Text.Trim()=="")
			{
				GlobalTools.popMessage(this, "Unit kerja pelapor/Sumber lain tidak boleh kosong!");
				return;
			}

			if (TXT_CATATAN.Text.Trim().Length <= 1) 
			{
				GlobalTools.popMessage(this, "Catatan tidak boleh kosong!");
				return;
			}
			
			try
			{
				conn.QueryString = "exec REKANAN_CATATAN_INSERT '" +
					TXT_REGNUM.Text + "', '" +
					TXT_UNIT_PELAPOR.Text + "', '" +
					TXT_CATATAN.Text + "'";
				conn.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
				return;
			}
		}
	}
}
