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
using DMS.CuBESCore;
using DMS.DBConnection;
namespace SME.SPPK.Channeling
{
	/// <summary>
	/// Summary description for ListInitiation.
	/// </summary>
	public partial class ApprovalSPPK : System.Web.UI.Page
	{
		protected Connection conn;
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.PlaceHolder SubMenu;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			/*if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");*/

			if (!IsPostBack)
			{
				ViewMenu();
			}

			ViewData("0");
			fillDgListChan();
			checkAgingSPPK();
		}

		private void checkAgingSPPK()
		{
			for (int i = 0; i < dgListChan.Items.Count; i++)
			{
				string apregno = dgListChan.Items[i].Cells[0].Text.ToString();
				conn.QueryString = "EXEC CHANNELING_GETAGING_APPROVALSPPK '" + apregno + "'";
				conn.ExecuteQuery();

				dgListChan.Items[i].Cells[5].Text = conn.GetFieldValue("AGING");
			}
		}

		private void fillDgListChan()
		{
			for (int i = 0; i < dgListChan.Items.Count; i++)
			{
				/*** DropDownList Assign To ***/
				DropDownList DDL_CANCEL = (DropDownList) dgListChan.Items[i].Cells[7].FindControl("DDL_CANCEL");
				if(DDL_CANCEL != null)
				{
					DDL_CANCEL.ID = "DDL_CANCEL." + i.ToString();
					GlobalTools.fillRefList(DDL_CANCEL, "SELECT REASONID, REASONDESC FROM RFREASON WHERE REASONTYPE = '1'", conn);
					try { DDL_CANCEL.SelectedIndex = 0; }
					catch {}
					DDL_CANCEL.SelectedIndexChanged += new EventHandler(DDL_CANCEL_SelectedIndexChanged);
					DDL_CANCEL.AutoPostBack = true;
				}

				/*** Button Process ***/
				CheckBox CB_STATUS = (CheckBox) dgListChan.Items[i].Cells[6].FindControl("CB_STATUS");
				if(CB_STATUS != null)
				{
					CB_STATUS.ID = "CB_STATUS." + i.ToString();
					CB_STATUS.CheckedChanged += new EventHandler(CB_STATUS_CheckedChanged);
					CB_STATUS.AutoPostBack = true;
				}
			}
		}

		private void ViewData(string sta)
		{
			BindData("dgListChan","EXEC CHANNELING_GETLIST_APPROVALSPPK '" + Request.QueryString["regno"]  + "'");
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);

			dg.DataSource = dt;				

			try
			{
				dg.DataBind();
			}
			catch 
			{
				dg.CurrentPageIndex = dg.PageCount - 1;
				dg.DataBind();
			}

			conn.ClearData();
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
			this.dgListChan.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgListChan_ItemCommand);

		}
		#endregion

		private void checkAll()
		{
			for(int i=0; i< dgListChan.Items.Count; i++)
			{
				CheckBox cb = (CheckBox) dgListChan.Items[i].Cells[6].FindControl("CB_STATUS." + i.ToString());
				if(cb != null)
				{
					cb.Checked = true;
				}

				//string a =  dgListChan.Items[i].Cells[6].Text.ToString();
			}
		}

		private void dgListChan_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Export":
					//ap regno pakai :
					//e.Item.Cells[0].Text
					/*Response.Write("<script language='javascript'>window.open('SPPKPrint.aspx?regno=" +
						Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&nosurat=" + "" +
						"','PrintBIRequest');</script>");*/
					//Response.Write("<script language='javascript'>window.open('SPPKPrint.aspx?','Print End User SPPK');</script>");
					string a = "<script language='javascript'>window.open('SPPKPrint.aspx?regno=" + e.Item.Cells[0].Text.ToString() + "','Print End User SPPK');</script>";
					string b = "<script language='javascript'>window.open('SPPKPrint.aspx?regno=" +
						e.Item.Cells[0].Text.ToString() + "&curef=" + Request.QueryString["curef"] + "&nosurat=" + "" +
						"','PrintBIRequest');</script>";
					Response.Write(b);
					break;
				case "checkall":
					checkAll();
					break;
			}
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < dgListChan.Items.Count; i++)
			{
				CheckBox CB_STATUS = (CheckBox) dgListChan.Items[i].Cells[6].FindControl("CB_STATUS." + i.ToString());
				if(CB_STATUS != null)
				{
					//e.Item.Cells[0].Text
					conn.QueryString = "EXEC CHANNELING_TRACKUPDATE_PERENDUSER '" + dgListChan.Items[i].Cells[0].Text.ToString() + "','" + Session["UserID"] + "','TCHAN2.0'";
					conn.ExecuteNonQuery();
				}
			}

			conn.QueryString = "EXEC CHANNELING_TRACKUPDATE_PERENDUSER '" + Request.QueryString["regno"] + "','" + Session["UserID"] + "','TCHAN2.0'";
			conn.ExecuteNonQuery();
					
			Response.Redirect("ListSPPK.aspx?msg=notok");
		}

		string stats = "";

		protected void BTN_UPDATE_STATUS_Click(object sender, System.EventArgs e)
		{
			string co = "";
			for (int i = 0; i < dgListChan.Items.Count; i++)
			{
				CheckBox CB_STATUS = (CheckBox) dgListChan.Items[i].Cells[6].FindControl("CB_STATUS." + i.ToString());
				if(CB_STATUS != null && CB_STATUS.Checked == true)
				{
					//e.Item.Cells[0].Text
					conn.QueryString = "EXEC CHANNELING_GET_NEXTCO '" + dgListChan.Items[i].Cells[0].Text.ToString() + "'";
					conn.ExecuteQuery();

					co = conn.GetFieldValue("USERID");

					conn.QueryString = "EXEC CHANNELING_TRACKUPDATE_PERENDUSER '" + dgListChan.Items[i].Cells[0].Text.ToString() + "','" + Session["UserID"] + "','TCHAN5.0','" + conn.GetFieldValue("USERID") + "'";
					conn.ExecuteNonQuery();
					stats = "done";
				}

				if(stats == "")
				{
					conn.QueryString = "EXEC CHANNELING_GET_NEXTCO '" + dgListChan.Items[i].Cells[0].Text.ToString() + "'";
					conn.ExecuteQuery();

					co = conn.GetFieldValue("USERID");

					DropDownList DDL_CANCEL = (DropDownList) dgListChan.Items[i].Cells[7].FindControl("DDL_CANCEL." + i.ToString());
					if(DDL_CANCEL != null && DDL_CANCEL.SelectedIndex != 0)
					{
						/*Masukin dulu ke reject_cancel*/
						string cancelreasonid = DDL_CANCEL.SelectedValue.ToString();

						conn.QueryString = "EXEC PROCEED_TO_REJECT_CANCEL '" + dgListChan.Items[i].Cells[0].Text.ToString() + "','" + Session["UserID"] + "','1','" + cancelreasonid + "',''";
						conn.ExecuteNonQuery();
						conn.QueryString = "EXEC CHANNELING_TRACKUPDATE_PERENDUSER '" + dgListChan.Items[i].Cells[0].Text.ToString() + "','" + Session["UserID"] + "','TCHAN9.0'";
						conn.ExecuteNonQuery();
					}
				}
				stats = "";
			}

			BindData("dgListChan","EXEC CHANNELING_GETLIST_APPROVALSPPK '" + Request.QueryString["regno"]  + "'");
			fillDgListChan();
			cekIsDataStillAvailable(co);
		}

		private void cekIsDataStillAvailable(string co)
		{
			//cek apakah aplikasi induk ke CO atau semua enduser dicancel ?
			string counts = "";
			string userco = co;

			if(dgListChan.Items.Count == 0)
			{
				conn.QueryString = "SELECT COUNT(AP_REGNO) as COUNTS FROM APPTRACK WHERE AP_CURRTRACK = 'TCHAN5.0' AND AP_REGNO in (SELECT AP_REGNO FROM APPLICATION WHERE APREGNO_INDUK = '" + Request.QueryString["regno"] + "')";
				conn.ExecuteQuery();
				counts = conn.GetFieldValue("COUNTS").ToString();

				/*conn.QueryString = "EXEC CHANNELING_GET_NEXTCO '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
				userco = conn.GetFieldValue("USERID");*/

				if(counts == "0")
				{
					co = "Aplikasi dibatalkan karena semua enduser dicancel !";
					conn.QueryString = "EXEC CHANNELING_TRACKUPDATE_PERENDUSER '" + Request.QueryString["regno"] + "','" + Session["UserID"] + "','TCHAN9.0','" + userco + "'";
					conn.ExecuteNonQuery();
					Response.Redirect("ListSPPK.aspx?msg=ok&co=" + co);
				}
				else
				{
					co = "Track Updated to " + userco + " !";
					conn.QueryString = "EXEC CHANNELING_TRACKUPDATE_PERENDUSER '" + Request.QueryString["regno"] + "','" + Session["UserID"] + "','TCHAN5.0','" + userco + "'";
					conn.ExecuteNonQuery();
					Response.Redirect("ListSPPK.aspx?msg=ok&co=" + co);
				}
			}
		}
		
		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select SM_ID,MENUCODE,SM_MENUDISPLAY,SM_LINKNAME from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						else	
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}

					string a = conn.GetFieldValue(i, 3).Replace("Channeling/","");
					string b = strtemp;

					t.NavigateUrl = conn.GetFieldValue(i, 3).Replace("Channeling/","")+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void CB_STATUS_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				CheckBox b = (CheckBox) sender;
				string idx = b.ID.Replace("CB_STATUS.","");
				
				if(b.Checked == true)
				{
					DropDownList d = (DropDownList) dgListChan.Items[int.Parse(idx)].Cells[7].FindControl("DDL_CANCEL."+idx);
					d.SelectedIndex = 0;
				}
			}
			catch
			{

			}
		}

		private void DDL_CANCEL_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				DropDownList b = (DropDownList) sender;
				string idx = b.ID.Replace("DDL_CANCEL.","");
				
				if(b.SelectedIndex != 0)
				{
					CheckBox d = (CheckBox) dgListChan.Items[int.Parse(idx)].Cells[6].FindControl("CB_STATUS."+idx);
					d.Checked = false;
				}
			}
			catch
			{

			}
		}
	}
}
