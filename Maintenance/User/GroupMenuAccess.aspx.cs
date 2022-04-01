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

namespace SME.Maintenance.User
{
	/// <summary>
	/// Summary description for GroupMenuAccess.
	/// </summary>
	public partial class GroupMenuAccess : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=192.168.1.200;Initial Catalog=SME;uid=sa;pwd=");
		protected Connection conn;
		protected DataTable dtSubModule = new DataTable();
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
			//	Response.Redirect("/SME/Restricted.aspx");

			conn.QueryString = "select submoduleid, submoduledisplay from rfsubmodule where moduleid='" + ConfigurationSettings.AppSettings["ModuleID"] + "'";
			conn.ExecuteQuery();
			dtSubModule = conn.GetDataTable();
			int rowNumber = 0;

			for (int i = 0; i < dtSubModule.Rows.Count; i++)
			{
				TBL_MENU.Rows.Add(new TableRow());
				TBL_MENU.Rows[rowNumber].Cells.Add(new TableCell());
				TBL_MENU.Rows[rowNumber].Cells[0].Text = dtSubModule.Rows[i]["SUBMODULEDISPLAY"].ToString();
				TBL_MENU.Rows[rowNumber].Cells[0].Font.Bold = true;
				CheckBoxList chkList = new CheckBoxList();
				chkList.ID = "chkList_" + i.ToString();
				rowNumber++;

				TBL_MENU.Rows.Add(new TableRow());
				TBL_MENU.Rows[rowNumber].Cells.Add(new TableCell());
				TBL_MENU.Rows[rowNumber].Cells[0].Controls.Add(chkList);

				rowNumber++;

				if (!IsPostBack)
				{
					conn.QueryString = "select menucode, menudisplay from rfmenu where submoduleid='" + dtSubModule.Rows[i]["SUBMODULEID"].ToString() + "' and MODULEID='" + ConfigurationSettings.AppSettings["ModuleID"] + "' and MENUPARENTID is null";
					conn.ExecuteQuery();
					DataTable dtmnu = conn.GetDataTable().Copy();
					for (int j = 0; j < dtmnu.Rows.Count; j++)
					{
						CheckBoxList chkListTemp = (CheckBoxList) Page.FindControl("chkList_" + i.ToString());
						//chkListTemp.Items.Add(new ListItem(conn.GetFieldValue(j,1), conn.GetFieldValue(j,0)));
						chkListTemp.Items.Add(new ListItem(dtmnu.Rows[j][1].ToString(), dtmnu.Rows[j][0].ToString()));

						conn.QueryString = "select menucode, menudisplay from RFMENU where submoduleid = '" + dtSubModule.Rows[i]["SUBMODULEID"].ToString() + 
											"' and moduleid = '" + ConfigurationSettings.AppSettings["ModuleID"] + "' and menuparentid = '" + dtmnu.Rows[j]["menucode"].ToString() + "'";
						conn.ExecuteQuery();

						DataTable dtmnu2 = conn.GetDataTable().Copy();
						for(int k=0; k < dtmnu2.Rows.Count; k++) 
						{
							//chkListTemp.Items.Add(new ListItem(conn.GetFieldValue(k, "menudisplay"), conn.GetFieldValue(k, "menucode")));
							chkListTemp.Items.Add(new ListItem(dtmnu2.Rows[k]["menudisplay"].ToString(), dtmnu2.Rows[k]["menucode"].ToString()));

							conn.QueryString = "select menucode, menudisplay from RFMENU where submoduleid = '" + dtSubModule.Rows[i]["SUBMODULEID"].ToString() + 
								"' and moduleid = '" + ConfigurationSettings.AppSettings["ModuleID"] + "' and menuparentid = '" + dtmnu2.Rows[k]["menucode"].ToString() + "'";
							conn.ExecuteQuery();

							DataTable dtmnu3 = conn.GetDataTable().Copy();
							for(int l=0; l < dtmnu2.Rows.Count; l++) 
							{
								try 
								{
									chkListTemp.Items.Add(new ListItem(dtmnu3.Rows[l]["menudisplay"].ToString(), dtmnu3.Rows[l]["menucode"].ToString()));
								} 
								catch (IndexOutOfRangeException)
								{
									break;
								}
							}
						}
					}
				}
			}
			Label1.Text = dtSubModule.Rows.Count.ToString();
			ViewData();
			/*
			CheckBoxList cb1 = (CheckBoxList) Page.FindControl("chkList_0");
			CheckBoxList cb2 = (CheckBoxList) Page.FindControl("chkList_1");
			CheckBoxList cb3 = (CheckBoxList) Page.FindControl("chkList_2");
			CheckBoxList cb4 = (CheckBoxList) Page.FindControl("chkList_3");
			CheckBoxList cb5 = (CheckBoxList) Page.FindControl("chkList_4");
			Label2.Text = cb1.Items.Count + "-" + cb2.Items.Count + "-" + cb3.Items.Count + "-" + cb4.Items.Count;
			*/
		}

		private void ViewData()
		{
			conn.QueryString = "select menucode from grpaccessmenu where groupid='" + Request.QueryString["GroupID"] + "' and active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				for (int k = 0; k < dtSubModule.Rows.Count; k++)
				{
					CheckBoxList temp = (CheckBoxList) Page.FindControl("chkList_" + k.ToString());
					for (int l = 0; l < temp.Items.Count; l++)
					{
						if (temp.Items[l].Value == conn.GetFieldValue(i,0))
							temp.Items[l].Selected = true;
					}
				}
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

		}
		#endregion

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "delete from grpaccessmenu where groupid='" + Request.QueryString["GroupID"] + "'";
			conn.ExecuteNonQuery();

			for (int i = 0; i < dtSubModule.Rows.Count; i++)
			{
				CheckBoxList cbTemp = (CheckBoxList) Page.FindControl("chkList_" + i.ToString());
				//Label2.Text += " ----- " + cbTemp.Items.Count + " - ";
				
				for (int j = 0; j < cbTemp.Items.Count; j++)
				{
					if (cbTemp.Items[j].Selected)
					{
						conn.QueryString = "insert into grpaccessmenu (groupid, menucode, active) values ('" + Request.QueryString["GroupID"] + "', '" + cbTemp.Items[j].Value + "', '1')";
						conn.ExecuteNonQuery();
					}
				}
			}

			conn.QueryString = "select app_root from app_parameter where seq=1";
			conn.ExecuteQuery();
			string path = conn.GetFieldValue(0,0);

			//tool.GenerateMenu(Request.QueryString["GroupID"], path, conn);

			Response.Write("<script language='javascript'>alert('Group Menu Access Updated!');</script>");
		}
	}
}
