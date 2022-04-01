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

namespace SME.LMS
{
	/// <summary>
	/// Summary description for PorAccountInfo.
	/// </summary>
	public partial class PorAccountInfo : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				BindData();
			}

			ViewMenu();
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				string mc1 = Request.QueryString["mc"];
				string mc2 = Request.QueryString["mc"];
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "porlmsreg="+Request.QueryString["porlmsreg"]+"&scr="+Request.QueryString["scr"];
						else	strtemp = "porlmsreg="+Request.QueryString["porlmsreg"]+"&mc="+Request.QueryString["mc"]+"&scr="+Request.QueryString["scr"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void BindData()
		{
			conn.QueryString = "SELECT * FROM VW_PORLMSACCOUNTINFO_BINDDATA WHERE PORLMS_REGNO = '" + Request.QueryString["porlmsreg"] + "' ORDER BY CU_NAME";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_PORWATCH.DataSource = dt;
			try 
			{
				DG_PORWATCH.DataBind();
			}
			catch 
			{
				DG_PORWATCH.CurrentPageIndex = 0;
				DG_PORWATCH.DataBind();
			}

			BindDataAccount();
		}

		private void BindDataAccount()
		{
			for (int i=0;i<DG_PORWATCH.Items.Count;i++)
			{
				DataGrid dgacc = (DataGrid) DG_PORWATCH.Items[i].Cells[3].FindControl("DG_ACCOUNT");

				conn.QueryString = "SELECT * FROM VW_PORLMSACCOUNTINFO_BINDDATAACCOUNT WHERE LMS_REGNO = '" + DG_PORWATCH.Items[i].Cells[0].Text.Trim() + "' ORDER BY ACC_NO";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtacc = new DataTable();
					dtacc = conn.GetDataTable().Copy();
					dgacc.DataSource = dtacc;
					try 
					{
						dgacc.DataBind();
					} 
					catch 
					{
						dgacc.CurrentPageIndex = 0;
						dgacc.DataBind();
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
			this.DG_PORWATCH.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DG_PORWATCH_ItemCreated);
			this.DG_PORWATCH.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_PORWATCH_PageIndexChanged);

		}
		#endregion

		private void DG_PORWATCH_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_PORWATCH.CurrentPageIndex = e.NewPageIndex;
			BindData();
		}

		private void DG_PORWATCH_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			DataGrid dgacc = (DataGrid) e.Item.FindControl("DG_ACCOUNT");
			if (dgacc != null)
			{
				dgacc.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgacc_PageIndexChanged);
			}
		}

		private void dgacc_PageIndexChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			dg.CurrentPageIndex = e.NewPageIndex;
			BindDataAccount();
		}
	}
}
