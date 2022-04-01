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

namespace SME.CustomerInfo
{
	/// <summary>
	/// Summary description for CovenantInfo.
	/// </summary>
	public partial class CovenantInfo : System.Web.UI.Page
	{
		protected Connection conn;
		private string regno, curef;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				ViewData();
			}

			ViewMenu();
		}

		private void ViewMenu() 
		{
			string strtemp = "";
			try 
			{
				//--- Membuat menu dari DATABASE
				conn.QueryString = "select * from SCREENMENU where menucode = '" + Request.QueryString["mc"] + "'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
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
				Console.Write(ex.Message);
			}			
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM VW_CUSTINFO_COVENANTINFO WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_COVENANT.DataSource = dt;
			try 
			{
				DG_COVENANT.DataBind();
			}
			catch 
			{
				DG_COVENANT.CurrentPageIndex = 0;
				DG_COVENANT.DataBind();
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
			this.DG_COVENANT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_COVENANT_ItemCommand);
			this.DG_COVENANT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_COVENANT_PageIndexChanged);

		}
		#endregion

		private void DG_COVENANT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					string url = e.Item.Cells[5].Text + "&mc=" + Request.QueryString["mc"] + "&scr=" + Request.QueryString["scr"] + "&sy=" + Request.QueryString["sy"];
					Response.Redirect(url);
					break;

				default:
					break;
			}
		}

		private void DG_COVENANT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_COVENANT.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}
	}
}
