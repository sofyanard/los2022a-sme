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
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.CreditProposal
{
	/// <summary>
	/// Summary description for DetailLegalSigning.
	/// </summary>
	public partial class BiayaPK : System.Web.UI.Page
	{

		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_TC.Text = Request.QueryString["tc"];
				
				ViewList();
				conn.QueryString = "select top 1 PRODUCTID , APPTYPE, PROD_SEQ from VW_CREDITPROPOSAL_CREDLIST "+
					"where AP_REGNO = '"+ LBL_REGNO.Text +"' order by apptype, productid ";
				conn.ExecuteQuery();
				if(conn.GetRowCount() > 0)
				{
					string autoLoadScript = "<script language='javascript'>" +
						"document.getElementById('frm_fasilitas').src='BiayaPK_Data.aspx?regno=" +
						LBL_REGNO.Text + "&curef=" + LBL_CUREF.Text + "&tc=" + LBL_TC.Text + "&na=" +
						Request.QueryString["na"] + "&productid=" + conn.GetFieldValue(0,0) + "&apptype=" +
						conn.GetFieldValue(0,1) + "&prod_seq=" + conn.GetFieldValue(0, "PROD_SEQ") + "';</script>";
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

		private void ViewList()
		{
			conn.QueryString = "select distinct PRODUCTID , PRODUCTDESC , APPTYPE , APPTYPEDESC, PROD_SEQ "+
				"from VW_CREDITPROPOSAL_CREDLIST "+
				"where AP_REGNO = '"+ LBL_REGNO.Text +"' order by apptype, productid ";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();

			//			if (row == 0)
			//			{
			//				conn.QueryString = "";
			//				conn.ExecuteQuery();
			//			}

			string productid, apptype, prod_seq;
			for (int i = 0; i < row; i++)
			{
				productid	= conn.GetFieldValue(i, 0);
				apptype		= conn.GetFieldValue(i, 2);
				prod_seq	= conn.GetFieldValue(i, "prod_seq");

				HyperLink t = new HyperLink();
				t.Text = productid + " - " + conn.GetFieldValue(i, 1) + " (" + conn.GetFieldValue(i, 3) + ") ";
				t.CssClass = "TDBGColor1";
				t.Font.Bold = true;
				
				t.NavigateUrl = "BiayaPK_Data.aspx?regno=" + LBL_REGNO.Text + "&curef=" + LBL_CUREF.Text +
					"&tc=" + LBL_TC.Text + "&productid=" + productid + "&apptype=" + apptype + "&na=" + Request.QueryString["na"] + "&prod_seq=" + prod_seq;
				t.Target = "frm_fasilitas";
				this.TBL_FASILITAS.Rows.Add(new TableRow());
				this.TBL_FASILITAS.Rows[i].Cells.Add(new TableCell());
				this.TBL_FASILITAS.Rows[i].Cells[0].Controls.Add(t);
			}
		}

		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn));
		}
	}
}
