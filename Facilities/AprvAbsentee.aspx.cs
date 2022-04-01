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

namespace SME.Facilities
{
	/// <summary>
	/// Summary description for ApvrAbesentee.
	/// </summary>

	public partial class AprvAbsentee : System.Web.UI.Page
	{

		/// <summary>
		/// ahmad
		/// Strore procedure & view baru yang digunakan di modul ini:
		/// APPROVAL_ABSENTEE_USER
		/// VW_APPROVAL_ABSENTEE
		/// SU_FINDUSER3
		/// SP_APPROVAL_ABSENTEE
		/// </summary>
		protected System.Web.UI.WebControls.DataGrid DatGrd;

		protected Connection conn;
		protected Tools tool = new Tools();

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				isiDDL();
				isiGrid();

				tbl_DETAIL.Visible = false;
			}

			btn_SAVE.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1)){return false;};");
		}

		#region Method
		private void isiDDL()
		{
			GlobalTools.fillRefList(ddl_SEARCH_BRANCH,"select branch_code, branch_name from RFBRANCH where ACTIVE = 1 order by BRANCH_NAME",false,conn);
			GlobalTools.fillRefList(ddl_SEARCH_GROUP,"select groupid, sg_grpname from SCGROUP where SG_ACTIVE = 1 order by SG_GRPNAME",false,conn);

			GlobalTools.fillRefList(ddl_USERNAME,"APPROVAL_ABSENTEE_USER null,'1'",false,conn);

			GlobalTools.initDateFormINA(txt_STARTABS_DD,ddl_STARTABS_MM,txt_STARTABS_YY);
			GlobalTools.initDateFormINA(txt_ENDABS_DD,ddl_ENDABS_MM,txt_ENDABS_YY);
			
		}

		private void isiGrid()
		{   
			conn.QueryString = "select * from VW_APPROVAL_ABSENTEE";
			conn.ExecuteQuery();
			DataTable dt = conn.GetDataTable().Copy();
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
				LinkButton Lbdelete = (LinkButton) DatGrd.Items[i].Cells[7].FindControl("lnkDelete");
				Lbdelete.Attributes.Add("onclick","if(!hapus()) { return false; };");   				
			}
		}

		private void clearEntries()
		{
			txt_USERID.Text = "";
			ddl_USERNAME.SelectedIndex = 0;
			txt_GROUP.Text = "";

			txt_STARTABS_DD.Text = "";
			ddl_STARTABS_MM.SelectedIndex = 0;
			txt_STARTABS_YY.Text = "";

			txt_ENDABS_DD.Text = "";
			ddl_ENDABS_MM.SelectedIndex = 0;
			txt_ENDABS_YY.Text = "";

			txt_PUSERID.Text = "";
			ddl_PUSERNAME.SelectedIndex = 0;
			txt_PGROUP.Text = "";
		}

		/// <summary>
		///  function untuk cek data yang disi sudah benar dan boleh disimpan
		/// </summary>
		/// <returns></returns>
		private bool isEntriesValid()
		{
			bool hasil = true;
			
			if (!GlobalTools.isDateValid(this, txt_STARTABS_DD.Text, ddl_STARTABS_MM.SelectedValue, txt_STARTABS_YY.Text))
			{
				GlobalTools.popMessage(this, "Tanggal mulai absen tidak valid");
				hasil = false;
			}
			else if (!GlobalTools.isDateValid(this, txt_ENDABS_DD.Text, ddl_ENDABS_MM.SelectedValue, txt_ENDABS_YY.Text))
			{
				GlobalTools.popMessage(this, "Tanggal akhir absen tidak valid");
				hasil = false;
			}
			else if ( DateTime.Parse(GlobalTools.ToSQLDate(txt_STARTABS_DD.Text,ddl_STARTABS_MM.SelectedValue,txt_STARTABS_YY.Text)) > DateTime.Parse(GlobalTools.ToSQLDate(txt_ENDABS_DD.Text,ddl_ENDABS_MM.SelectedValue,txt_ENDABS_YY.Text)) )
			{
				GlobalTools.popMessage(this, "Tanggal mulai harus lebih kecil dari tanggal selesai");
				hasil = false;
			}
			else if ( txt_USERID.Text == txt_PUSERID.Text )
			{
				GlobalTools.popMessage(this, "Nama user tidak boles sama dengan nama pengganti");
				hasil = false;
			}

			
			return hasil;
		}
		#endregion

		/// <summary>
		/// Set condition of buttons
		/// </summary>
		/// <param name="isEdit"></param>
		private void setStatus(bool isEdit) 
		{
			btn_NEW.Visible = !isEdit;
			btn_SAVE.Visible = isEdit;
			btn_CANCEL.Visible = isEdit;
				
			tbl_DETAIL.Visible = isEdit;
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

		}
		#endregion

		protected void btn_CARIPENGGANTI_Click(object sender, System.EventArgs e)
		{
			GlobalTools.fillRefList(ddl_PUSERNAME,"APPROVAL_ABSENTEE_USER '"+ddl_USERNAME.SelectedValue+"','2'",false,conn);
		}

		protected void ddl_USERNAME_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "SU_FINDUSER3 '" + ddl_USERNAME.SelectedValue + "'";
			conn.ExecuteQuery();
			txt_USERID.Text = conn.GetFieldValue("USERID");
			txt_GROUP.Text = conn.GetFieldValue("SG_GRPNAME");
		}

		protected void ddl_PUSERNAME_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "SU_FINDUSER3 '" + ddl_PUSERNAME.SelectedValue + "'";
			conn.ExecuteQuery();
			txt_PUSERID.Text = conn.GetFieldValue("USERID");
			txt_PGROUP.Text = conn.GetFieldValue("SG_GRPNAME");
		}

		protected void btn_CLEAR_Click(object sender, System.EventArgs e)
		{
			ddl_SEARCH_BRANCH.SelectedIndex = 0;
			ddl_SEARCH_GROUP.SelectedIndex = 0;
			txt_SEARCH_USERID.Text = "";
			txt_SEARCH_USERNAME.Text = "";
		}

		protected void btn_SEARCH_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec APPROVAL_ABSENTEE_FIND '" +ddl_SEARCH_BRANCH.SelectedValue+"', '"+
				               ddl_SEARCH_GROUP.SelectedValue+"','"+txt_SEARCH_USERID.Text+"', '"+txt_SEARCH_USERNAME.Text+"' "; 
			conn.ExecuteQuery();
			DataTable dt = conn.GetDataTable().Copy();
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

		protected void btn_NEW_Click(object sender, System.EventArgs e)
		{
			txt_STARTABS_DD.ReadOnly = false;
			ddl_STARTABS_MM.Enabled = true;
			txt_STARTABS_YY.ReadOnly = false;
			ddl_USERNAME.Enabled =true;
			
			clearEntries();
			setStatus(true);
			/*
			btn_NEW.Visible = false;
			btn_SAVE.Visible = true;
			btn_CANCEL.Visible = true;

			tbl_DETAIL.Visible = true;
			*/
			GlobalTools.SetFocus(this, btn_CANCEL);
		}

		protected void btn_SAVE_Click(object sender, System.EventArgs e)
		{
			if (isEntriesValid())
			{
				conn.QueryString = "SP_APPROVAL_ABSENTEE '1','" +
					txt_USERID.Text + "'," +
					GlobalTools.ToSQLDate(txt_STARTABS_DD.Text, ddl_STARTABS_MM.SelectedValue, txt_STARTABS_YY.Text,"00","00") + "," + 
					GlobalTools.ToSQLDate(txt_ENDABS_DD.Text, ddl_ENDABS_MM.SelectedValue, txt_ENDABS_YY.Text,"00","00") + ",'" + 
					txt_PUSERID.Text + "'";

				conn.ExecuteNonQuery();

				isiGrid();
			
				setStatus(false);
				/*btn_NEW.Visible = true;
				btn_SAVE.Visible = false;
				btn_CANCEL.Visible = false;
				clearEntries();

				tbl_DETAIL.Visible = false;*/
			}
			else
			{
				setStatus(true);
				/*btn_NEW.Visible = false;
				btn_SAVE.Visible = true;
				btn_CANCEL.Visible = true;
				
				tbl_DETAIL.Visible = true;*/
			}
		}

		protected void btn_CANCEL_Click(object sender, System.EventArgs e)
		{
			clearEntries();

			setStatus(false);

			/*
			btn_NEW.Visible = true;
			btn_SAVE.Visible = false;
			btn_CANCEL.Visible = false;		

			tbl_DETAIL.Visible = false;
			*/
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{   
			
			switch ( ( (LinkButton) e.CommandSource).CommandName )
			{
				case "edit":
					string UserID, UserID2;

					btn_NEW.Visible = false;
					btn_SAVE.Visible = true;
					btn_CANCEL.Visible = true;

					tbl_DETAIL.Visible = true;

					GlobalTools.SetFocus(this, btn_CANCEL);

					conn.QueryString = "select * from VW_APPROVAL_ABSENTEE where USERID = '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();

					txt_USERID.Text = conn.GetFieldValue("USERID");
					try {ddl_USERNAME.SelectedValue = conn.GetFieldValue("USERID");}
					catch {}
					ddl_USERNAME.Enabled =false;
					
					txt_GROUP.Text = conn.GetFieldValue("SG_GRPNAME");

					try {GlobalTools.fromSQLDate(conn.GetFieldValue("ABSENSTART"),txt_STARTABS_DD,ddl_STARTABS_MM,txt_STARTABS_YY);}
					catch {}
					txt_STARTABS_DD.ReadOnly = true;
					ddl_STARTABS_MM.Enabled = false;
					txt_STARTABS_YY.ReadOnly = true;

					try {GlobalTools.fromSQLDate(conn.GetFieldValue("ABSENEND"),txt_ENDABS_DD,ddl_ENDABS_MM,txt_ENDABS_YY);}
					catch {}

					txt_PUSERID.Text = conn.GetFieldValue("USERID2");
					try {ddl_PUSERNAME.SelectedValue = conn.GetFieldValue("USERID2");}
					catch {}
					txt_PGROUP.Text = conn.GetFieldValue("PEGGANTI_GROUP");

					UserID = conn.GetFieldValue("USERID");
					UserID2 = conn.GetFieldValue("USERID2");

					GlobalTools.fillRefList(ddl_PUSERNAME,"APPROVAL_ABSENTEE_USER '"+UserID+"','2'",false,conn);

					try {ddl_PUSERNAME.SelectedValue = UserID2;}
					catch {}


					break;

				case "delete":

					///// semua kondisi bisa didelete
					///
//					if (e.Item.Cells[3].Text != "ABSEN")
//					{  					    
						
						DateTime tgl = DateTime.Parse(e.Item.Cells[4].Text);
					
						conn.QueryString = "SP_APPROVAL_ABSENTEE '2','" + e.Item.Cells[0].Text + "','"+Strings.Format(tgl,"yyyy-MM-dd")+"'";
						conn.ExecuteNonQuery();

						isiGrid();
						
//					}
//					else 
//					{ 
//						GlobalTools.popMessage(this, "Record ini tidak bisa dihapus"); 
//					}
					break;
			}
		}

		
		
	}
}
