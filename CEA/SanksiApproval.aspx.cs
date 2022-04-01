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
	/// Summary description for SanksiApproval.
	/// </summary>
	public partial class SanksiApproval : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool=new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");
			
			if(!IsPostBack)
			{
				TR_BUTTON.Visible = false;

				ViewData();
				
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

		private void ViewData()
		{
			conn.QueryString = "select * from vw_rekanan_sanksi_TEMP left outer join rekanan on vw_rekanan_sanksi_temp.rekanan_ref=rekanan.rekanan_ref where teamleader='" + Session["UserID"] + "'";
			conn.ExecuteQuery();
			FillGrid();
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

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			DatGrd.CurrentPageIndex = 0;
			SearchData();
			ClearData();
		}

		private void SearchData()
		{
			string query=""; 
			
			if(TXT_REK_NAME.Text!="")
			{
				query += "and rekanan.namerekanan LIKE '%" + TXT_REK_NAME.Text + "%' ";
			}
			if(TXT_NoReg.Text!="")
			{
				query += "and rekanan.rekanan_ref='" + TXT_NoReg.Text + "' ";
			}

			if(query!="")
			{
				conn.QueryString = "select * from vw_rekanan_sanksi_TEMP left outer join rekanan on vw_rekanan_sanksi_temp.rekanan_ref=rekanan.rekanan_ref where teamleader='" + Session["UserID"] + "' " + query;
				conn.ExecuteQuery();
				FillGrid();
			}
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Detail":	
					TR_BUTTON.Visible = true;
					LBL_REKANANREF.Text = e.Item.Cells[1].Text;
					TXT_SEQ.Text = e.Item.Cells[0].Text;

					conn.QueryString = "select rekanantypeid from rekanan where rekanan_ref='" + LBL_REKANANREF.Text + "'";
					conn.ExecuteQuery();

					if (conn.GetFieldValue("rekanantypeid")=="01")
					{
						conn.QueryString="select top 1 rekanan_ref, rekanandesc, namerekanan, pic_name, address1, address2, city, phone_area + '-' + phone# as phone from vw_rekanan_company where rekanan_ref='" + LBL_REKANANREF.Text + "'";
						conn.ExecuteQuery();

						TXT_REGNUM.Text = conn.GetFieldValue("rekanan_ref");
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
						conn.QueryString="select top 1 rekanan_ref, rekanandesc, namerekanan, address1, address2, city, office_area + '-' + office# as phone from vw_rekanan_personal where rekanan_ref='" + LBL_REKANANREF.Text + "'";
						conn.ExecuteQuery();

						TXT_REGNUM.Text = conn.GetFieldValue("rekanan_ref");
						TXT_JNS_REK.Text = conn.GetFieldValue("rekanandesc");
						TXT_NAMA_REK.Text = conn.GetFieldValue("namerekanan");
						TXT_ADDRESS1.Text = conn.GetFieldValue("address1");
						TXT_ADDRESS2.Text = conn.GetFieldValue("address2");
						TXT_CITY.Text = conn.GetFieldValue("city");
						TXT_NOTLP.Text = conn.GetFieldValue("phone");
					}

					conn.QueryString = "select * from vw_rekanan_sanksi_temp where seq='" + TXT_SEQ.Text + "' and rekanan_ref='" + LBL_REKANANREF.Text + "'";
					conn.ExecuteQuery();

					if (conn.GetRowCount() > 0)
					{
						//Sanksi Internal
						TXT_JNS_SANKSI.Text = conn.GetFieldValue("SANKSIDESC");
						TXT_NO_SURAT.Text = conn.GetFieldValue("LETTER#");
						TXT_TGL_SURAT.Text = tool.FormatDate(conn.GetFieldValue("LETTER_DATE"));
						TXT_JANGKA_WKT_SANKSI.Text = conn.GetFieldValue("JANGKA_WAKTU");
						TXT_PROBLEM.Text = conn.GetFieldValue("PROBLEMDESC");
						TXT_STATUS_SANKSI.Text = conn.GetFieldValue("RFSTATUS");
				
						//Sanksi Eksternal
						SANKSI_EXT.Text = conn.GetFieldValue("sanksi");
						NO_SURAT_EXT.Text = conn.GetFieldValue("no_surat");
						TXT_DAY_EXT.Text = tool.FormatDate(conn.GetFieldValue("tgl_surat"));
						DIKELUARKAN_EXT.Text = conn.GetFieldValue("dikeluarkan");
						JANGKA_WKT_EXT.Text = conn.GetFieldValue("jangka_waktu_ext");
						MASALAH_EXT.Text = conn.GetFieldValue("permasalahan");
						STATUS_EXT.Text = conn.GetFieldValue("status_sanksi");
						KET_EXT.Text = conn.GetFieldValue("keterangan");
					}
					break;		
			}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		protected void BTN_APPROVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec rekanan_sanksi_insert2 '" +
				LBL_REKANANREF.Text + "', " +
				TXT_SEQ.Text;
			conn.ExecuteNonQuery();
			ViewData();
			ClearData();
			TR_BUTTON.Visible = false;
		}

		protected void BTN_REJECT_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "delete from rekanan_sanksi_temp where rekanan_ref='" + LBL_REKANANREF.Text + "' and seq=" + TXT_SEQ.Text;
			conn.ExecuteQuery();
			ViewData();
			ClearData();
			TR_BUTTON.Visible = false;
		}

		private void ClearData()
		{
			TXT_NO_SURAT.Text="";
			TXT_TGL_SURAT.Text="";
			TXT_JANGKA_WKT_SANKSI.Text="";
			TXT_STATUS_SANKSI.Text="";
			TXT_JNS_SANKSI.Text="";
			TXT_PROBLEM.Text="";

			SANKSI_EXT.Text = "";
			NO_SURAT_EXT.Text = "";
			TXT_DAY_EXT.Text = "";
			DIKELUARKAN_EXT.Text = "";
			JANGKA_WKT_EXT.Text = "";
			MASALAH_EXT.Text = "";
			STATUS_EXT.Text = "";
			KET_EXT.Text = "";
			LBL_REKANANREF.Text="";
			TR_BUTTON.Visible = false;
		}
	}
}
