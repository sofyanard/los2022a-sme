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

namespace SME.ComplyReview.Channeling.Condition
{
	/// <summary>
	/// Summary description for ListInitiation.
	/// </summary>
	public partial class PengikatanAgunan : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				
			}
			
			ViewMenu();
			BindData("dgListChan","EXEC CHANNELING_VIEWDATA_AGUNAN '" + Request.QueryString["regno"] + "'");
			BindDgListChan();
			fillDDL();
			//replace ama existing data disini
			PutExistingData();
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
			this.dgListChan.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgListChan_ItemCreated);

		}
		#endregion

		private void fillDDL()
		{
			conn.QueryString = "SELECT IKATDESC, IKATID FROM RFIKAT WHERE ACTIVE = '1'";
			conn.ExecuteQuery();

			for(int i=0; i< dgListChan.Items.Count; i++)
			{
				DropDownList DDL_JENIS = (DropDownList) dgListChan.Items[i].Cells[2].FindControl("DDL_JENIS." + dgListChan.Items[i].Cells[0].Text.ToString());
				DDL_JENIS.Items.Clear();
				DDL_JENIS.Items.Add(new ListItem("- SELECT -", ""));
				
				for(int k=0; k<conn.GetRowCount(); k++)
				{	
					DDL_JENIS.Items.Add(new ListItem(conn.GetFieldValue(k,"IKATDESC"), conn.GetFieldValue(k,"IKATID")));
				}
			}
		}

		private void BindDgListChan()
		{

			for(int i=0; i< dgListChan.Items.Count; i++)
			{
				//dari sini pake index
				/*** DropDownList Assign To ***/
				DropDownList DDL_JENIS = (DropDownList) dgListChan.Items[i].Cells[4].FindControl("DDL_JENIS");
				if(DDL_JENIS != null)
				{
					DDL_JENIS.ID = "DDL_JENIS." + dgListChan.Items[i].Cells[0].Text.ToString();
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
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]+"&parentregno="+Request.QueryString["parentregno"]+"&aano="+Request.QueryString["aano"] + "&productid=" + Request.QueryString["productid"] + "&prodseq=" + Request.QueryString["prodseq"];
						else	
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]+"&parentregno="+Request.QueryString["parentregno"]+"&aano="+Request.QueryString["aano"] + "&productid=" + Request.QueryString["productid"] + "&prodseq=" + Request.QueryString["prodseq"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = "../" + conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
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

		private void dgListChan_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			try
			{
				for(int i=0; i< dgListChan.Items.Count; i++)
				{
					string ddlvalue = "";

					DropDownList DDL_JENIS = (DropDownList) dgListChan.Items[i].Cells[4].FindControl("DDL_JENIS." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(DDL_JENIS != null)
					{
						ddlvalue = DDL_JENIS.SelectedValue.ToString();

						conn.QueryString = "EXEC CHANNELING_SAVE_PENGIKATANAGUNAN '" + dgListChan.Items[i].Cells[0].Text.ToString() + "','" + ddlvalue + "'";
						conn.ExecuteQuery();
					}
				}

				Tools.popMessage(this, "Data has been saved !");
			}
			catch
			{
				Tools.popMessage(this, "Invalid Data !");
			}

			BindData("dgListChan","EXEC CHANNELING_VIEWDATA_AGUNAN '" + Request.QueryString["regno"] + "'");
			BindDgListChan();
			fillDDL();
			PutExistingData();
		}

		private void PutExistingData()
		{
			for(int i=0; i< dgListChan.Items.Count; i++)
			{
				conn.QueryString = "EXEC CHANNELING_GETDATA_PENGIKATANAGUNAN '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				if(conn.GetRowCount() > 0)
				{
					DropDownList DDL_JENIS = (DropDownList) dgListChan.Items[i].Cells[4].FindControl("DDL_JENIS." + conn.GetFieldValue(i,"AP_REGNO"));
					if(DDL_JENIS != null)
					{
						DDL_JENIS.SelectedValue = conn.GetFieldValue(i,"ACL_IKATID");
					}
				}
			}
		}
	}
}
