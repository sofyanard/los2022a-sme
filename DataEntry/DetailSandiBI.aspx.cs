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

namespace SME.CreditOperations.Booking
{
	/// <summary>
	/// Summary description for DetailSandiBI.
	/// </summary>
	public partial class DetailSandiBI : System.Web.UI.Page
	{
		string temp_grpunit;
	
		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (Request.QueryString["de"] == "1")
				if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
					Response.Redirect("/SME/Restricted.aspx");

			if(!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_TC.Text = Request.QueryString["tc"];
				ViewList();
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
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						//t.ForeColor = Color.MidnightBlue; 
						if (conn.GetFieldValue(i,3).IndexOf("de=") < 0) strtemp = strtemp + "&de=" + Request.QueryString["de"];	
						if (conn.GetFieldValue(i,3).IndexOf("par=") < 0)  strtemp = strtemp + "&par=" + Request.QueryString["par"];
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

		private void ViewList()
		{
			//pipeline
			conn.QueryString = "SELECT sg_BUSSUNITid,sg_grpunit FROM scgroup WHERE groupid = '" + Session["GroupID"].ToString() + "'";
			conn.ExecuteQuery();
			temp_grpunit = conn.GetFieldValue("sg_grpunit");
			//
			conn.QueryString = "select distinct PR.PRODUCTID, PR.PRODUCTDESC, CP.PROD_SEQ "+
				"from CUSTPRODUCT CP "+
				"join RFPRODUCT PR on PR.PRODUCTID = CP.PRODUCTID "+
				"where CP.AP_REGNO = '"+ LBL_REGNO.Text +"' and apptype in ('01','09')";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			string productid;
			//pipe
			if ( temp_grpunit=="CO")
			{
				conn.QueryString = "select distinct PR.PRODUCTID, PR.PRODUCTDESC, CP.PROD_SEQ "+
					"from CUSTPRODUCT CP "+
					"join RFPRODUCT PR on PR.PRODUCTID = CP.PRODUCTID "+
					"where CP.AP_REGNO = '"+ LBL_REGNO.Text +"' ";
				conn.ExecuteQuery();
				row = conn.GetRowCount();
			}
			if (row == 0)
				Tools.popMessage(this, "Sandi BI hanya untuk Permohonan Baru");
			
			else
				for (int i = 0; i < row; i++)
				{
					productid = conn.GetFieldValue(i, 0);
					HyperLink t = new HyperLink();
					t.Text = productid +" - "+conn.GetFieldValue(i, 1);
					t.CssClass = "TDBGColor1";
					t.Font.Bold = true;
				
					t.NavigateUrl = "DetailSandiBIData.aspx?regno="+ LBL_REGNO.Text +"&curef="+ LBL_CUREF.Text +"&tc="+ LBL_TC.Text +"&productid="+ productid +"&de=" +Request.QueryString["de"] + "&prod_seq=" + conn.GetFieldValue(i, "PROD_SEQ");
					t.Target = "frm_sandibi";
					this.TBL_FASILITAS.Rows.Add(new TableRow());
					this.TBL_FASILITAS.Rows[i].Cells.Add(new TableCell());
					this.TBL_FASILITAS.Rows[i].Cells[0].Controls.Add(t);
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
			if (Request.QueryString["par"] != null && Request.QueryString["par"] != "") 
				Response.Redirect(Request.QueryString["par"] + "&regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"]);
			else
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));

		}

	}
}
