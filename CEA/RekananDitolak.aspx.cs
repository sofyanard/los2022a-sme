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
	/// Summary description for RekananDitolak.
	/// </summary>
	public partial class RekananDitolak : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if(!IsPostBack)
			{
				conn.QueryString = "select * from vw_rekanan_ditolak_fix2 ";
				
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
			ClearData();
		}

		private void ClearData()
		{
			TXT_REGNUM.Text="";
			TXT_ADDRESS1.Text="";
			TXT_ADDRESS2.Text="";
			TXT_CITY.Text="";
			TXT_CP.Text="";
			TXT_JNS_REK.Text="";
			TXT_NAMA_REK.Text="";
			TXT_NOTLP.Text="";
			
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
			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				DatGrd.Items[i].Cells[4].Text = tool.FormatDate(DatGrd.Items[i].Cells[4].Text, true);
			}
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

			if(query!="")
			{
				conn.QueryString = "select * from vw_rekanan_ditolak_fix2 where 1=1"+ query;
				
				conn.ExecuteQuery();
				FillGrid();
			}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;

			conn.QueryString = "select * from vw_rekanan_ditolak_fix2 ";				
			conn.ExecuteQuery();
			FillGrid();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":	
					LBL_REGNUM.Text = e.Item.Cells[0].Text;
					LBL_REKANANREF.Text = e.Item.Cells[6].Text;
					ViewData();
					ViewData2();
					break;				
			}
		}

		private void ViewData2()
		{
			conn.QueryString="select * from vw_rekanan_ditolak_fix where ap_currtrack='A2.7' and regnum='" + LBL_REGNUM.Text + "'";
			conn.ExecuteQuery();
			TXT_REGNUM.Text = conn.GetFieldValue("regnum");
			TXT_CAT.Text = conn.GetFieldValue("alasan");

		}

		private void ViewData()
		{
			conn.QueryString = "select rekanantypeid from rekanan where rekanan_ref='" + LBL_REKANANREF.Text + "'";
			conn.ExecuteQuery();			

			if (conn.GetFieldValue("rekanantypeid")=="01")
			{
				conn.QueryString="select rekanan_ref, rekanandesc, namerekanan, pic_name, address1, address2, city, phone_area + '-' + phone# as phone from vw_rekanan_company where rekanan_ref='" + LBL_REKANANREF.Text + "'";
				conn.ExecuteQuery();	
				
				TXT_JNS_REK.Text = conn.GetFieldValue("rekanandesc");
				TXT_NAMA_REK.Text = conn.GetFieldValue("namerekanan");
				TXT_CP.Text = conn.GetFieldValue("pic_name");
				TXT_ADDRESS1.Text = conn.GetFieldValue("address1");
				TXT_ADDRESS2.Text = conn.GetFieldValue("address2");
				TXT_CITY.Text = conn.GetFieldValue("city");
				TXT_NOTLP.Text = conn.GetFieldValue("phone");
			}
			else
			{
				conn.QueryString="select rekanan_ref, rekanandesc, namerekanan, address1, address2, city, office_area + '-' + office# as phone from vw_rekanan_personal where rekanan_ref='" + LBL_REKANANREF.Text + "'";
				conn.ExecuteQuery();	
				
				TXT_JNS_REK.Text = conn.GetFieldValue("rekanandesc");
				TXT_NAMA_REK.Text = conn.GetFieldValue("namerekanan");
				TXT_ADDRESS1.Text = conn.GetFieldValue("address1");
				TXT_ADDRESS2.Text = conn.GetFieldValue("address2");
				TXT_CITY.Text = conn.GetFieldValue("city");
				TXT_NOTLP.Text = conn.GetFieldValue("phone");
			}
		}
	}
}
