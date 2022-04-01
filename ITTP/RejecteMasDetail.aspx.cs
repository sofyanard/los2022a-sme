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
namespace SME.ITTP
{
	/// <summary>
	/// Summary description for RejecteMasDetail.
	/// </summary>
	public partial class RejecteMasDetail : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if(!IsPostBack)
			{
				
				string lnk = Request.QueryString["lnk"];
				if ((lnk != "") && (lnk != null))
				{
					string autoLoadScript = "<script language='javascript'>" +
						"document.getElementById('rejectscreen').src='" + lnk + "';</script>";
					Page.RegisterStartupScript("LoadScript ", autoLoadScript);
				}
				else
				{
					string autoLoadScript = "<script language='javascript'>" +
						"document.getElementById('rejectscreen').src='RejectDetail.aspx?regno=" +
						Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] +
						"&apptype=" + Request.QueryString["apptype"] + "&productid=" +
						Request.QueryString["productid"] + "&tc=" + Request.QueryString["tc"] +
						"&mc=" + Request.QueryString["mc"] +
						"&prod_seq=" + Request.QueryString["prod_seq"] +
						"&uf_cpseq=" + Request.QueryString["uf_cpseq"] + "';</script>";
					Page.RegisterStartupScript("LoadScript ", autoLoadScript);
				}
				
			}

			ViewMenu();
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
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
						{
							strtemp = "&regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] +
								"&apptype=" + Request.QueryString["apptype"] + "&productid=" +
								Request.QueryString["productid"] + "&tc=" + Request.QueryString["tc"] +
								"&prod_seq=" + Request.QueryString["prod_seq"] +
								"&uf_cpseq=" + Request.QueryString["uf_cpseq"];
						}
						else
						{
							strtemp = "&regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + 
								"&apptype=" + Request.QueryString["apptype"] + "&productid=" + Request.QueryString["productid"] +
								"&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] +
								"&prod_seq=" + Request.QueryString["prod_seq"] +
								"&uf_cpseq=" + Request.QueryString["uf_cpseq"];
							t.Target = "rejectscreen";
						}
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

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("RejecteMas.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}
	}
}