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
using System.Web.Security;
using DMS.CuBESCore;

namespace SME.Maintenance.User
{
	/// <summary>
	/// Summary description for User. Blah
	/// 
	/// TODO : User Maintenance Enhancements
	///		   (mirip Consumer .... )
	///		   
	/// </summary>
	public partial class User : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DDL_CL_TYPE;
		protected System.Web.UI.WebControls.Button BTN_INSCOLL;
		protected System.Web.UI.WebControls.TextBox TXT_CL_VALUE;
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			HyperLink1.NavigateUrl = "User.aspx?mc=" + Request.QueryString["mc"];
			HyperLink2.NavigateUrl = "Group.aspx?mc=" + Request.QueryString["mc"];

			if (!IsPostBack)
			{
				DDL_GROUPID.Items.Add(new ListItem("- PILIH -", ""));
				DDL_BRANCH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_USRGRPID.Items.Add(new ListItem("- PILIH -", ""));
				DDL_SU_BRANCH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_AREAID.Items.Add(new ListItem("- PILIH -", ""));
				DDL_FIND_AREAID.Items.Add(new ListItem("- PILIH -", ""));
				DDL_SU_UPLINER.Items.Add(new ListItem("- PILIH -", ""));
				DDL_SU_MIDUPLINER.Items.Add(new ListItem("- PILIH -", ""));
				ddl_jbcode.Items.Add(new ListItem("- PILIH -", ""));
				ddl_scmitra.Items.Add(new ListItem("- PILIH -", ""));
				ddl_teamleader.Items.Add(new ListItem("- PILIH -", ""));

				conn.QueryString = "select groupid, sg_grpname from scgroup where sg_active='1' order by sg_grpname";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_GROUPID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					DDL_USRGRPID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}
				
				conn.QueryString = "select branch_code, branch_name from rfbranch where active='1' order by branch_code";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_BRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					DDL_SU_BRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				conn.QueryString = "select areaid, areaname from rfarea where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					DDL_AREAID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					DDL_FIND_AREAID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				conn.QueryString = "select jb_code, jb_desc from rfjabatan where active = '1' order by jb_desc";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					ddl_jbcode.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select userid, su_fullname from scuser "+
								   " where groupid = (select sg_mitrarm from scgroup where groupid = '"+DDL_USRGRPID.SelectedValue+"') "+
								   " and su_active = '1' order by su_fullname";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					ddl_scmitra.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				/***
				conn.QueryString = "select userid, su_fullname from scuser "+
								   " where substring(groupid,1,2) = '01' "+
								   " and su_active = '1' order by su_fullname";
				***/
				//--- Modified By Yudi ---
				conn.QueryString = "select * from VW_SCUSER_TL";
				//------------------------
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					ddl_teamleader.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				SetDisable();
				//FillBranchDDL();dsf
				fillGridAlt((LBL_ISSHOWALL.Text == "1")?true:false);
			}
			//conn = (Connection) Session["Connection"];dfd
			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");

			//FillGrid();	//--- Modified By Yudi (19-Ags-2004)						
			//fillGridAlt((LBL_ISSHOWALL.Text == "1")?true:false);
		}

		private void fillGridAlt(bool isShowAll) 
		{
			if (isShowAll) 
			{
				conn.QueryString = "select * " + 
								   "from vw_scuser " + 
								   "order by su_fullname";
								   //"where su_active = '1' order by su_fullname";
			}
			else 
			{
				conn.QueryString = "exec SU_FINDUSER '"+
					DDL_FIND_AREAID.SelectedValue+"','"+
					DDL_GROUPID.SelectedValue+"','"+
					DDL_BRANCH.SelectedValue+"','"+
					TXT_FIND_USERID.Text.Trim()+"','"+
					TXT_FIND_SU_FULLNAME.Text.Trim()+"','"+
					TXT_FIND_OFFICER_CODE.Text.Trim()+"'";
			}

			try 
			{
				//conn.ExecuteNonQuery();
				conn.ExecuteQuery();
			}
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Server Error !");
				return;
			}

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

			CheckBox cb;

			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				if (DatGrd.Items[i].Cells[4].Text == "1")
				{
					cb = (CheckBox)DatGrd.Items[i].Cells[6].FindControl("CheckBox1");
					cb.Checked = true;
				}
				if (DatGrd.Items[i].Cells[5].Text == "1")
				{
					cb = (CheckBox)DatGrd.Items[i].Cells[7].FindControl("CheckBox2");
					cb.Checked = true;
				}
				
				if (DatGrd.Items[i].Cells[8].Text == "1")				
					DatGrd.Items[i].Cells[8].Text = "Yes";				
				else 				
					DatGrd.Items[i].Cells[8].Text = "No";				
			}		
		}

		private void FillGrid()
		{			
			conn.QueryString = "select * from vw_scuser where groupid='" + DDL_GROUPID.SelectedValue + "' and su_active = '1' order by su_fullname";
			if ((DDL_BRANCH.SelectedValue != "") && (DDL_GROUPID.SelectedValue != ""))
				conn.QueryString = "select * from vw_scuser where groupid='" + DDL_GROUPID.SelectedValue + "' and su_branch='" + DDL_BRANCH.SelectedValue + "'";
			conn.ExecuteQuery();

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

			CheckBox cb;

			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				if (DatGrd.Items[i].Cells[4].Text == "1")
				{
					cb = (CheckBox)DatGrd.Items[i].Cells[6].FindControl("CheckBox1");
					cb.Checked = true;
				}
				if (DatGrd.Items[i].Cells[5].Text == "1")
				{
					cb = (CheckBox)DatGrd.Items[i].Cells[7].FindControl("CheckBox2");
					cb.Checked = true;
				}
			}
		}

		private void SetEnable()
		{
//			TXT_USERID.Enabled = true;
//			TXT_SU_FULLNAME.Enabled = true;
//			TXT_SU_PWD.Enabled = true;
//			TXT_VERIFYPWD.Enabled = true;
//			TXT_SU_HPNUM.Enabled = true;
//			TXT_SU_EMAIL.Enabled = true;

			TXT_USERID.ReadOnly = false;
			TXT_SU_FULLNAME.ReadOnly = false;
			TXT_SU_PWD.ReadOnly = false;
			TXT_VERIFYPWD.ReadOnly = false;
			TXT_SU_HPNUM.ReadOnly = false;
			TXT_SU_EMAIL.ReadOnly = false;
			DDL_USRGRPID.Enabled = true;
			DDL_AREAID.Enabled = true;
			DDL_SU_BRANCH.Enabled = true;

			TXT_CITYNAME.ReadOnly = false;

			DDL_SU_UPLINER.Enabled = true;

			TXT_SU_NIP.ReadOnly = false;

			DDL_SU_MIDUPLINER.Enabled = true;

			txt_ofcrcode.ReadOnly = false;

			cb_revoke.Enabled = true;
			ddl_jbcode.Enabled = true;
			ddl_scmitra.Enabled = true;

			txt_scaprvlimit.ReadOnly = false;
			txt_scemaslimit.ReadOnly = false;

			ddl_teamleader.Enabled = true;

			LNK_CHG_PWD.Visible = true;
			LNK_CHG_PWD.Enabled = true;
		}

		private void SetDisable()
		{
//			TXT_USERID.Enabled = false;
//			TXT_SU_FULLNAME.Enabled = false;
//			TXT_SU_PWD.Enabled = false;
//			TXT_VERIFYPWD.Enabled = false;
//			TXT_SU_HPNUM.Enabled = false;
//			TXT_SU_EMAIL.Enabled = false;

			TXT_USERID.ReadOnly = true;
			TXT_SU_FULLNAME.ReadOnly = true;
			TXT_SU_PWD.ReadOnly = true;
			TXT_VERIFYPWD.ReadOnly = true;
			TXT_SU_HPNUM.ReadOnly = true;
			TXT_SU_EMAIL.ReadOnly = true;

			DDL_USRGRPID.Enabled = false;
			DDL_AREAID.Enabled = false;
			DDL_SU_BRANCH.Enabled = false;

//			TXT_CITYNAME.Enabled = false;
			TXT_CITYNAME.ReadOnly = true;

			DDL_SU_UPLINER.Enabled = false;

//			TXT_SU_NIP.Enabled = false;
			TXT_SU_NIP.ReadOnly = true;

			DDL_SU_MIDUPLINER.Enabled = false;

//			txt_ofcrcode.Enabled = false;
			txt_ofcrcode.ReadOnly = true;

			ddl_jbcode.Enabled = false;
			ddl_scmitra.Enabled = false;

//			txt_scaprvlimit.Enabled = false;
			txt_scaprvlimit.ReadOnly = true;

			cb_revoke.Enabled = false;

//			txt_scemaslimit.Enabled = false;
			txt_scemaslimit.ReadOnly = true;

			ddl_teamleader.Enabled = false;

			LNK_CHG_PWD.Visible = false;
			LNK_CHG_PWD.Enabled = false;
		}

		private void ClearEntries()
		{
			TXT_USERID.Text = "";
			TXT_SU_FULLNAME.Text = "";
			TXT_SU_PWD.Text = "";
			TXT_VERIFYPWD.Text = "";
			TXT_SU_HPNUM.Text = "";
			TXT_SU_EMAIL.Text = "";
			DDL_USRGRPID.SelectedValue = "";
			DDL_AREAID.SelectedValue = "";
			DDL_SU_BRANCH.SelectedValue = "";
			TXT_CITYNAME.Text = "";
			DDL_SU_UPLINER.SelectedValue = "";
			TXT_SU_NIP.Text = "";
			txt_ofcrcode.Text = "";
			ddl_jbcode.SelectedValue = "";
			ddl_scmitra.SelectedValue = "";
			txt_scaprvlimit.Text = "";
			cb_revoke.Checked = false;
			txt_scemaslimit.Text = "";
			ddl_teamleader.SelectedValue = "";
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

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					BTN_SAVE.Visible	= false;
					BTN_CANCEL.Visible	= false;
					CHK_ISNEW.Checked	= false;

					TXT_USERID.ReadOnly		= true;
					TXT_CITYNAME.ReadOnly	= true;

					//FillUpliner(DDL_GROUPID.SelectedValue);
					//FillMitra(DDL_GROUPID.SelectedValue);
					//--- Modified  by Yudi ---
					FillUpliner(e.Item.Cells[2].Text);
					FillMitra(e.Item.Cells[2].Text);
					//-------------------------

					conn.QueryString = "select * from vw_scuser where userid='" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					TXT_USERID.Text					= conn.GetFieldValue("USERID");
					TXT_SU_FULLNAME.Text			= conn.GetFieldValue("SU_FULLNAME");
					TXT_SU_HPNUM.Text				= conn.GetFieldValue("SU_HPNUM");
					TXT_SU_EMAIL.Text				= conn.GetFieldValue("SU_EMAIL");
					DDL_USRGRPID.SelectedValue		= conn.GetFieldValue("GROUPID");
					DDL_AREAID.SelectedValue		= conn.GetFieldValue("AREAID");
					try
					{
						DDL_SU_UPLINER.SelectedValue	= conn.GetFieldValue("SU_UPLINER");
						DDL_SU_MIDUPLINER.SelectedValue = conn.GetFieldValue("SU_MIDUPLINER");
					}
					catch
					{
					}
					TXT_SU_NIP.Text					= conn.GetFieldValue("SU_NIP");
					txt_ofcrcode.Text				= conn.GetFieldValue("officer_code");
					try 
					{
						txt_scaprvlimit.Text			= tool.MoneyFormat(conn.GetFieldValue("su_aprvlimit"));
					} 
					catch {}
					ddl_jbcode.SelectedValue		= conn.GetFieldValue("jb_code");
					try
					{ddl_scmitra.SelectedValue		= conn.GetFieldValue("su_mitrarm");}
					catch
					{}
					try 
					{
						txt_scemaslimit.Text			= tool.MoneyFormat(conn.GetFieldValue("su_emaslimit"));
					} 
					catch {}
					try
					{ddl_teamleader.SelectedValue    = conn.GetFieldValue("su_teamleader");}
					catch
					{}
					if (conn.GetFieldValue("su_revoke").ToString() == "0")
						cb_revoke.Checked = false;
					else
						cb_revoke.Checked = true;
//					string branchID = conn.GetFieldValue("SU_BRANCH");
//					string cityName = conn.GetFieldValue("CITYNAME");
					DDL_SU_BRANCH.SelectedValue =  conn.GetFieldValue("SU_BRANCH");
					TXT_CITYNAME.Text = conn.GetFieldValue("CITYNAME");
					break;

				case "edit":
					BTN_SAVE.Visible = true;
					BTN_CANCEL.Visible = true;
					BTN_NEW.Visible = false;
					CHK_ISNEW.Checked = false;

					SetEnable();
					TXT_USERID.ReadOnly = true;
					TXT_CITYNAME.ReadOnly = true;

					
					//FillUpliner(DDL_GROUPID.SelectedValue);
					//FillMitra(DDL_GROUPID.SelectedValue);
					//--- Modified By Yudi ---
					FillUpliner(e.Item.Cells[2].Text);
					FillMitra(e.Item.Cells[2].Text);
					//------------------------

					conn.QueryString = "select * from vw_scuser where userid='" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					TXT_USERID.Text					= conn.GetFieldValue("USERID");
					TXT_SU_FULLNAME.Text			= conn.GetFieldValue("SU_FULLNAME");
					TXT_SU_HPNUM.Text				= conn.GetFieldValue("SU_HPNUM");
					TXT_SU_EMAIL.Text				= conn.GetFieldValue("SU_EMAIL");
					DDL_USRGRPID.SelectedValue		= conn.GetFieldValue("GROUPID");
					DDL_AREAID.SelectedValue		= conn.GetFieldValue("AREAID");
					try
					{
						DDL_SU_UPLINER.SelectedValue	= conn.GetFieldValue("SU_UPLINER");
						DDL_SU_MIDUPLINER.SelectedValue = conn.GetFieldValue("SU_MIDUPLINER");
					}
					catch
					{
					}
					TXT_SU_NIP.Text					= conn.GetFieldValue("SU_NIP");
					txt_ofcrcode.Text				= conn.GetFieldValue("officer_code");
					try 
					{
						//txt_scaprvlimit.Text			= conn.GetFieldValue("su_aprvlimit");
						//--- Modified by Yudi (2004-08-26) ----
						txt_scaprvlimit.Text			= tool.MoneyFormat(conn.GetFieldValue("su_aprvlimit"));
					} 
					catch {}
					ddl_jbcode.SelectedValue		= conn.GetFieldValue("jb_code");
					try
						{ddl_scmitra.SelectedValue		= conn.GetFieldValue("su_mitrarm");}
					catch
						{}
					try 
					{
						//txt_scemaslimit.Text			= conn.GetFieldValue("su_emaslimit");
						//--- Modified by Yudi (2004-08-26) ----
						txt_scemaslimit.Text			= tool.MoneyFormat(conn.GetFieldValue("su_emaslimit"));
					} 
					catch {}
					try
						{ddl_teamleader.SelectedValue    = conn.GetFieldValue("su_teamleader");}
					catch
						{}
					if (conn.GetFieldValue("su_revoke").ToString() == "0")
						cb_revoke.Checked = false;
					else
						cb_revoke.Checked = true;
//					string branchID = conn.GetFieldValue("SU_BRANCH");
//					string cityName = conn.GetFieldValue("CITYNAME");
					//FillBranchDDL();
					DDL_SU_BRANCH.SelectedValue = conn.GetFieldValue("SU_BRANCH");
					TXT_CITYNAME.Text = conn.GetFieldValue("CITYNAME");
					//--- Modified By Yudi (2004-09-06) ---
					//Response.Write("<script language='javascript'>alert('Modification to User Profile will reset password!');</script>");
					//-------------------------------------
					//DDL_SU_UPLINER.SelectedValue = conn.GetFieldValue("SU_UPLINER");
					//DDL_SU_MIDUPLINER.SelectedValue = conn.GetFieldValue("SU_MIDUPLINER");
					break;

				case "delete":
					/***
					conn.QueryString = "exec SU_SCUSER '" + e.Item.Cells[0].Text + "', '" + 
						DDL_GROUPID.SelectedValue + "', '" + 
						e.Item.Cells[1].Text + "', null, null, null, null, null,  '" + 
						Session["UserID"].ToString() + "', null, '2', '1', null, null, null, null, null, null, null, null, null";
					***/
					//--- Modified by Yudi ---
					conn.QueryString = "exec SU_SCUSER '" + e.Item.Cells[0].Text + "', '" + 
						e.Item.Cells[2].Text + "', '" +
						e.Item.Cells[1].Text + "', null, null, null, null, null,  '" + 
						Session["UserID"].ToString() + "', null, '2', '1', null, null, null, null, null, null, null, null, null";
					//------------------------
					try
					{  conn.ExecuteNonQuery();}
					catch{}
					Response.Write("<script language='javascript'>alert('Request Submitted! Awaiting approval...');</script>");
					break;

				case "active":
					conn.QueryString = "exec SU_ACTIVATEUSER '" + e.Item.Cells[0].Text + "','1'";
					try 
					{
						conn.ExecuteNonQuery();
					}
					catch {}
					Response.Write("<script language='javascript'>alert('UserID ["+e.Item.Cells[0].Text+"] is now active !');</script>");
					fillGridAlt((LBL_ISSHOWALL.Text == "1")?true:false);
					break;
			}
		}

		protected void DDL_AREAID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
//			FillBranchDDL();
		}

		private void FillBranchDDL()
		{
			DDL_SU_BRANCH.Items.Clear();
			DDL_SU_BRANCH.Items.Add(new ListItem("- SELECT -", ""));
			conn.QueryString = "select * from vw_branch where active='1' order by branch_code";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_SU_BRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if (TXT_SU_PWD.Text == TXT_VERIFYPWD.Text)
			{
				BTN_SAVE.Visible = false;
				BTN_CANCEL.Visible = false;
				BTN_NEW.Visible = true;
				string flag = "0";
				string revoke = "0";

				if (CHK_ISNEW.Checked == true)
					flag = "1";

				if (cb_revoke.Checked == true)
					revoke = "1";
				else
					revoke = "0";

				conn.QueryString = "select count(*) from pending_scuser where userid='" + TXT_USERID.Text + "'";
				conn.ExecuteQuery();

				if (conn.GetFieldValue(0,0) == "0")
				{
					//--- Modified By Yudi (2004-09-06) ---
					// Untuk kebutuhan mengubah password
					if (LBL_STATUS_PWD.Text == "1")
						conn.QueryString = "exec su_scuser '" + 
											TXT_USERID.Text + "', '"+
											DDL_USRGRPID.SelectedValue+"', "+ 
											" '"+TXT_SU_FULLNAME.Text+"', '"+
											System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(TXT_SU_PWD.Text, "sha1")+"', "+
											" '"+TXT_SU_HPNUM.Text+ "', '"+
											TXT_SU_EMAIL.Text+"', "+
											tool.ConvertNull(DDL_SU_BRANCH.SelectedValue)+", "+
											tool.ConvertNull(DDL_SU_UPLINER.SelectedValue)+", "+ 
											" '"+Session["UserID"].ToString()+"', null, '"+
											flag+"', '1', "+
											tool.ConvertNull(DDL_SU_MIDUPLINER.SelectedValue)+", " + 
											" '"+TXT_SU_NIP.Text+"', '"+
											txt_ofcrcode.Text+"', '"+
											revoke+"', '"+
											ddl_scmitra.SelectedValue+"', "+
											tool.ConvertFloat(txt_scaprvlimit.Text)+", "+
											" "+tool.ConvertNull(ddl_jbcode.SelectedValue)+", "+
											tool.ConvertFloat(txt_scemaslimit.Text)+", "+
											tool.ConvertNull(ddl_teamleader.SelectedValue)+"";
					else
						conn.QueryString = "exec su_scuser '" + 
							TXT_USERID.Text + "', '"+
							DDL_USRGRPID.SelectedValue+"', "+ 
							" '"+TXT_SU_FULLNAME.Text+"', null, " +	//--- Password set to null
							" '"+TXT_SU_HPNUM.Text+ "', '"+
							TXT_SU_EMAIL.Text+"', "+
							tool.ConvertNull(DDL_SU_BRANCH.SelectedValue)+", "+
							tool.ConvertNull(DDL_SU_UPLINER.SelectedValue)+", "+ 
							" '"+Session["UserID"].ToString()+"', null, '"+
							flag+"', '1', "+
							tool.ConvertNull(DDL_SU_MIDUPLINER.SelectedValue)+", " + 
							" '"+TXT_SU_NIP.Text+"', '"+
							txt_ofcrcode.Text+"', '"+
							revoke+"', '"+
							ddl_scmitra.SelectedValue+"', "+
							tool.ConvertFloat(txt_scaprvlimit.Text)+", "+
							" "+tool.ConvertNull(ddl_jbcode.SelectedValue)+", "+
							tool.ConvertFloat(txt_scemaslimit.Text)+", "+
							tool.ConvertNull(ddl_teamleader.SelectedValue)+"";

					conn.ExecuteNonQuery();

					ClearEntries();
					SetDisable();

					Response.Write("<script language='javascript'>alert('Request Submitted! Awaiting approval...');</script>");
				}
				else
				{
					ClearEntries();
					SetDisable();
					Response.Write("<script language='javascript'>alert('The UserID is already awaiting for approval... Request Rejected!');</script>");
				}
			}
			else
			{
				Response.Write("<script language='javascript'>alert('Password Mismatch!');</script>");
			}
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			BTN_SAVE.Visible = false;
			BTN_NEW.Visible = true;
			BTN_CANCEL.Visible = false;

			ClearEntries();
			SetDisable();

			//--- Added By Yudi ---
			LBL_STATUS_PWD.Text = "0";
			TXT_SU_PWD.Visible = false;
			TXT_SU_PWD.CssClass = "";
			TXT_VERIFYPWD.Visible = false;
			TXT_VERIFYPWD.CssClass = "";
		}

		protected void BTN_NEW_Click(object sender, System.EventArgs e)
		{
			BTN_NEW.Visible = false;
			BTN_SAVE.Visible = true;
			BTN_CANCEL.Visible = true;
			CHK_ISNEW.Checked = true;

			SetEnable();
			TXT_CITYNAME.ReadOnly = true;
			TXT_USERID.ReadOnly = false;

			DDL_USRGRPID.SelectedValue = DDL_GROUPID.SelectedValue;
			FillUpliner(DDL_USRGRPID.SelectedValue);

			//--- Added By Yudi (2004-09-06) ---
			LNK_CHG_PWD.Visible = false;
			TXT_SU_PWD.Visible = true;
			TXT_SU_PWD.CssClass = "mandatory";
			TXT_VERIFYPWD.Visible = true;
			TXT_VERIFYPWD.CssClass = "mandatory";
			//----
		}

		private void FillUpliner(string groupID)
		{
			DDL_SU_UPLINER.Items.Clear();
			DDL_SU_MIDUPLINER.Items.Clear();
			DDL_SU_UPLINER.Items.Add(new ListItem("- PILIH -", ""));
			DDL_SU_MIDUPLINER.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select userid, su_fullname from vw_scuser_upliner where groupid='" + groupID + "' and su_active='1' order by SU_FULLNAME";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_SU_UPLINER.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			
			conn.QueryString = "select userid, su_fullname from vw_scuser_midupliner where groupid='" + groupID + "' and su_active='1'  order by SU_FULLNAME";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_SU_MIDUPLINER.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		protected void DDL_SU_BRANCH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select cityname from vw_branch where branch_code='" + DDL_SU_BRANCH.SelectedValue + "'";
			conn.ExecuteQuery();
			TXT_CITYNAME.Text = conn.GetFieldValue("CITYNAME");
		}

		protected void DDL_USRGRPID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillUpliner(DDL_SU_UPLINER.SelectedValue);
			FillUpliner(DDL_USRGRPID.SelectedValue);
			FillMitra(DDL_USRGRPID.SelectedValue);
		}

		private void FillMitra(string groupid)
		{
			conn.QueryString = "select userid, su_fullname from scuser "+
				" where groupid = (select sg_mitrarm from scgroup where groupid = '"+groupid+"') "+
				" and su_active = '1'";
			conn.ExecuteQuery();

			ddl_scmitra.Items.Clear();
			ddl_scmitra.Items.Add(new ListItem("- PILIH -", ""));
			for (int i = 0; i < conn.GetRowCount(); i++)
				ddl_scmitra.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;

			//FillGrid();	//--- Modified By Yudi (19-Ags-2004)
			fillGridAlt((LBL_ISSHOWALL.Text == "1")?true:false);
		}

		protected void DDL_GROUPID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private bool isInputValid() 
		{
			bool validkah = true;

			return validkah;
		}

		protected void BTN_SEARCH_Click(object sender, System.EventArgs e)
		{
			LBL_ISSHOWALL.Text = "0";
			if (!isInputValid()) 
			{
				return;
			}
						
			fillGridAlt(false);
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			DDL_FIND_AREAID.SelectedValue = "";
			DDL_BRANCH.SelectedValue = "";
			DDL_GROUPID.SelectedValue = "";
			TXT_FIND_USERID.Text = "";
			TXT_FIND_SU_FULLNAME.Text = "";
			TXT_FIND_OFFICER_CODE.Text = "";
		}

		protected void BTN_SHOWALL_Click(object sender, System.EventArgs e)
		{
			LBL_ISSHOWALL.Text = "1";
			if (!isInputValid()) 
			{
				return;
			}
						
			fillGridAlt(true);
		}

		protected void LNK_CHG_PWD_Click(object sender, System.EventArgs e)
		{
			TXT_SU_PWD.Visible = true;
			TXT_SU_PWD.CssClass = "mandatory";

			TXT_VERIFYPWD.Visible = true;
			TXT_VERIFYPWD.CssClass = "mandatory";

			LBL_STATUS_PWD.Text = "1";
		}
	}
}
