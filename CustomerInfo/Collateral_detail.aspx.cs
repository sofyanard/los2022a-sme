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

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for jaminan_detail.
	/// </summary>
	public partial class Collateral_detail : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			ViewMenu();
		}

		private void ViewMenu()
		{
			
//			HyperLink t1	= new HyperLink();
//			t1.Text			= "Account Customer";
//			t1.Font.Bold	= true;
//			t1.NavigateUrl	= "InfoCustomer.aspx?sta="+Request.QueryString["sta"]+"&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"];
//			Menu.Controls.Add(t1);
//			Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
//
//			HyperLink t2		= new HyperLink();
//			t2.Text				= "Collateral Customer";
//			t2.Font.Bold		= true;
//			t2.NavigateUrl		= "Collateral_Detail.aspx?sta="+Request.QueryString["sta"]+"&regno="+Request.QueryString["regno"]+"&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"];
//			Menu.Controls.Add(t2);
//			Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
			

			// View Link dari sub-modul
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
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
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

		protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
			Response.Redirect("SearchCustomer.aspx?mc=030");
		}
	}
}
