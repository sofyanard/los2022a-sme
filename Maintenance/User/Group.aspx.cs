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

namespace SME.Maintenance.User
{
	/// <summary>
	/// Summary description for Group.
	/// </summary>
	public partial class Group : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=192.168.1.200;Initial Catalog=SME;uid=sa;pwd=");
		protected DataTable dt = new DataTable();
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			HyperLink1.NavigateUrl = "User.aspx?mc=" + Request.QueryString["mc"];
			HyperLink2.NavigateUrl = "Group.aspx?mc=" + Request.QueryString["mc"];

//			//--- Modified By Yudi (19-Ags-2004) ------
//			//conn.QueryString = "select groupid, sg_grpname from scgroup where sg_active='1'";
//			if (LBL_ISSHOWALL.Text == "0") 
//			{
//				if (TXT_FIND_GROUPID.Text.Trim() == "" && TXT_FIND_SG_GRPNAME.Text.Trim() == "")
//				{
//					conn.QueryString = "exec SU_FINDGROUP '"+
//						TXT_FIND_GROUPID.Text.Trim()+"','"+
//						TXT_FIND_SG_GRPNAME.Text.Trim()+"'";
//
//					conn.ExecuteQuery();
//					dt = conn.GetDataTable().Copy();
//					FillDataSet();
//				}
//			}
//			else 
//			{
//				conn.QueryString = conn.QueryString = "select groupid, sg_grpname from scgroup where sg_active='1'";
//				conn.ExecuteQuery();
//				dt = conn.GetDataTable().Copy();
//				FillDataSet();
//			}

//			conn.ExecuteQuery();
//			dt = conn.GetDataTable().Copy();
//			FillDataSet();

			FillDataSet();
			if (!IsPostBack)
			{
				DDL_SG_GRPUPLINER.Items.Add(new ListItem("- PILIH -", ""));
				DDL_SG_MDLUPLINER.Items.Add(new ListItem("- PILIH -", ""));
				DDL_SG_APRVTRACK.Items.Add(new ListItem("- PILIH -", ""));
				ddl_sgmitra.Items.Add(new ListItem("- PILIH -", ""));
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_SG_GRPUPLINER.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					DDL_SG_MDLUPLINER.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				conn.QueryString = "select trackcode, trackname from rftrack where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_SG_APRVTRACK.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select groupid, sg_grpname from scgroup where sg_active='1' and substring(groupid, 0, 3) = '02'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					ddl_sgmitra.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				SetDisable();
			}
			
			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");			
		}

		private void FillDataSet()
		{
			//--- Modified By Yudi (19-Ags-2004) ------
			if (LBL_ISSHOWALL.Text == "0") 
			{
//				if (TXT_FIND_GROUPID.Text.Trim() != "" || TXT_FIND_SG_GRPNAME.Text.Trim() != "")
//				{
					conn.QueryString = "exec SU_FINDGROUP '"+
						TXT_FIND_GROUPID.Text.Trim()+"','"+
						TXT_FIND_SG_GRPNAME.Text.Trim()+"'";

					conn.ExecuteQuery();
					dt = conn.GetDataTable().Copy();
//				}
			}
			else 
			{
				conn.QueryString = conn.QueryString = "select groupid, sg_grpname from scgroup where sg_active='1'";
				conn.ExecuteQuery();
				dt = conn.GetDataTable().Copy();
			}
			//-------------------------------------------

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

		private void SetDisable()
		{
			TXT_GROUPID.Enabled			= false;
			TXT_SG_GRPNAME.Enabled		= false;
			DDL_SG_GRPUPLINER.Enabled	= false;
			CHK_SG_APPRSTA.Enabled		= false;
			DDL_SG_MDLUPLINER.Enabled	= false;
			DDL_SG_APRVTRACK.Enabled	= false;
			ddl_sgmitra.Enabled			= false;
		}

		private void SetEnable()
		{
			TXT_GROUPID.Enabled			= true;
			TXT_SG_GRPNAME.Enabled		= true;
			DDL_SG_GRPUPLINER.Enabled	= true;
			CHK_SG_APPRSTA.Enabled		= true;
			DDL_SG_MDLUPLINER.Enabled	= true;
			DDL_SG_APRVTRACK.Enabled	= true;
			ddl_sgmitra.Enabled			= true;
		}

		private void ClearEntries()
		{
			TXT_GROUPID.Text				= "";
			TXT_SG_GRPNAME.Text				= "";
			DDL_SG_GRPUPLINER.SelectedValue = "";
			DDL_SG_MDLUPLINER.SelectedValue = "";
			CHK_SG_APPRSTA.Checked			= false;
			DDL_SG_APRVTRACK.SelectedValue	= "";
			ddl_sgmitra.SelectedValue		= "";
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

		protected void BTN_NEW_Click(object sender, System.EventArgs e)
		{
			BTN_NEW.Visible = false;
			BTN_SAVE.Visible = true;
			BTN_CANCEL.Visible = true;
			CHK_ISNEW.Checked = true;

			SetEnable();
			TXT_GROUPID.ReadOnly = false;
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			string approval = "0", flag = "0";
		
			if (CHK_SG_APPRSTA.Checked == true)
				approval = "1";
			if (CHK_ISNEW.Checked == true)
				flag = "1";

			conn.QueryString = "select count (*) from pending_scgroup where groupid='" + TXT_GROUPID.Text + "'";
			conn.ExecuteQuery();

			if (conn.GetFieldValue(0,0) == "0")
			{
				conn.QueryString = "exec SU_SCGROUP '"+TXT_GROUPID.Text+"', '"+TXT_SG_GRPNAME.Text+"', "+
								   " '"+DDL_SG_GRPUPLINER.SelectedValue+"', '"+approval+"', null, "+
								   " '"+flag+"', '1', '"+DDL_SG_MDLUPLINER.SelectedValue+"', "+
								   " "+tool.ConvertNull(DDL_SG_APRVTRACK.SelectedValue)+", "+tool.ConvertNull(ddl_sgmitra.SelectedValue)+" ";
				conn.ExecuteNonQuery();
			
//				ClearEntries();
//				SetDisable();

				Response.Write("<script language='javascript'>alert('Request Submitted! Awaiting approval...');</script>");
			}
			else
			{
//				ClearEntries();
//				SetDisable();

				Response.Write("<script language='javascript'>alert('That GroupID is already awaiting for approval... Request Rejected!');</script>");
			}

			ClearEntries();
			SetDisable();

			BTN_SAVE.Visible = false;
			BTN_NEW.Visible = true;
			BTN_CANCEL.Visible = false;
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			BTN_SAVE.Visible = false;
			BTN_NEW.Visible = true;
			BTN_CANCEL.Visible = false;

			ClearEntries();
			SetDisable();		
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					TXT_GROUPID.ReadOnly = true;
					BTN_SAVE.Visible = true;
					BTN_CANCEL.Visible = true;
					BTN_NEW.Visible = false;
					CHK_ISNEW.Checked = false;

					SetEnable();

					conn.QueryString = "select groupid, sg_grpname, sg_grpupliner, sg_mdlupliner, sg_apprsta, "+
									   " sg_active, sg_aprvtrack, sg_mitrarm from scgroup where groupid='" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					TXT_GROUPID.Text				= conn.GetFieldValue("GROUPID");
					TXT_SG_GRPNAME.Text				= conn.GetFieldValue("SG_GRPNAME");
					try
						{DDL_SG_GRPUPLINER.SelectedValue = conn.GetFieldValue("SG_GRPUPLINER");}
					catch{}
					try
						{DDL_SG_MDLUPLINER.SelectedValue = conn.GetFieldValue("SG_MDLUPLINER");}
					catch{}
					DDL_SG_APRVTRACK.SelectedValue	= conn.GetFieldValue("sg_aprvtrack");
					try
						{ddl_sgmitra.SelectedValue		= conn.GetFieldValue("sg_mitrarm");}
					catch{}

					if (conn.GetFieldValue("SG_APPRSTA") == "1")
					{
						CHK_SG_APPRSTA.Checked	= true;
						tr_aprvtrack.Visible	= true;
						tr_mitra.Visible		= true;
					}
					else
					{
						CHK_SG_APPRSTA.Checked	= false;
						tr_aprvtrack.Visible	= false;
						tr_mitra.Visible		= false;
					}
				break;

				case "delete":
					conn.QueryString = "exec SU_SCGROUP '" + e.Item.Cells[0].Text + "', null, null, null, null, '" + 
						"2', '1', '" + DDL_SG_MDLUPLINER.SelectedValue + "', "+tool.ConvertNull(DDL_SG_APRVTRACK.SelectedValue)+", "+
						" "+tool.ConvertNull(ddl_sgmitra.SelectedValue)+"";
					conn.ExecuteNonQuery();
					Response.Write("<script language='javascript'>alert('Request Submitted! Awaiting approval...');</script>");
				break;

				case "menuAccess":
					Response.Write("<script language='javascript'>window.open('GroupMenuAccess.aspx?GroupID=" + e.Item.Cells[0].Text + "','MenuAccess','status=no,scrollbars=yes,width=400,height=400');</script>");
				break;
			}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			FillDataSet();
		}

		protected void CHK_SG_APPRSTA_CheckedChanged(object sender, System.EventArgs e)
		{
			if (CHK_SG_APPRSTA.Checked)
			{
				tr_aprvtrack.Visible = true;
				tr_mitra.Visible	 = true;
				DDL_SG_APRVTRACK.CssClass = "mandatory";
			}
			else
			{
				tr_aprvtrack.Visible = false;
				tr_mitra.Visible	 = false;
				DDL_SG_APRVTRACK.CssClass = "";
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			TXT_FIND_GROUPID.Text = "";
			TXT_FIND_SG_GRPNAME.Text = "";
		}

		protected void BTN_SEARCH_Click(object sender, System.EventArgs e)
		{
			LBL_ISSHOWALL.Text = "0";
//			conn.QueryString = "exec SU_FINDGROUP '"+
//				TXT_FIND_GROUPID.Text.Trim()+"','"+
//				TXT_FIND_SG_GRPNAME.Text.Trim()+"'";
//			conn.ExecuteQuery();
//			dt = conn.GetDataTable().Copy();
			FillDataSet();
		}

		protected void BTN_SHOWALL_Click(object sender, System.EventArgs e)
		{
			LBL_ISSHOWALL.Text = "1";
//			conn.QueryString = conn.QueryString = "select groupid, sg_grpname from scgroup where sg_active='1'";
//			conn.ExecuteQuery();
//			dt = conn.GetDataTable().Copy();
			FillDataSet();
		}
	}
}
