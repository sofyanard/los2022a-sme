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

namespace SME.CreditOperations.NotaryAssignment
{
	/// <summary>
	/// Summary description for CollateralLegalSigning.
	/// </summary>
	public partial class CollateralLegalSigning : System.Web.UI.Page
	{

		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn;

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
				ViewJaminan();
				conn.QueryString = "select top 1 CL_SEQ, CL_TYPE, PRODUCTID "+
					"from VW_CREOPR_NOTARYASSIGN_COLLIST "+
					"where AP_REGNO = '"+ LBL_REGNO.Text +"' ";
				conn.ExecuteQuery();
				
				if(conn.GetRowCount() > 0)
				{
					string autoLoadScript = "<script language='javascript'>" +
						"document.getElementById('frm_jaminan').src='CollateralLegalSigning_Data.aspx?regno="+
						LBL_REGNO.Text + "&curef=" + LBL_CUREF.Text + "&tc=" + LBL_TC.Text + "&prod=" + 
						conn.GetFieldValue(0,"PRODUCTID") + "&na="+ Request.QueryString["na"] +"&cl_seq=" + conn.GetFieldValue(0,0) + "&cl_type=" + conn.GetFieldValue(0,1) + "';</script>";
					Page.RegisterStartupScript("LoadScript", autoLoadScript);
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
							strtemp = "regno=" + Request.QueryString["regno"] +
								"&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"] +
								"";//"&na=" + Request.QueryString["na"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef=" +
									Request.QueryString["curef"] + "&mc=" + Request.QueryString["mc"] +
									"&tc=" + Request.QueryString["tc"];						
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

		private void ViewJaminan()
		{
			conn.QueryString = "select DISTINCT CL_SEQ, CL_TYPE "+
				", COLTYPEID, COLTYPEDESC, CU_REF, CL_DESC, PRODUCTID "+
				"from VW_CREOPR_NOTARYASSIGN_COLLIST "+
				"where AP_REGNO = '"+ LBL_REGNO.Text +"' ";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			string CL_TYPE, cl_seq, curef, prodid;
			for (int i = 0; i < row; i++)
			{
				cl_seq = conn.GetFieldValue(i, "CL_SEQ");
				CL_TYPE = conn.GetFieldValue(i, "CL_TYPE");
				curef = conn.GetFieldValue(i, "CU_REF");
				prodid = conn.GetFieldValue(i, "PRODUCTID");
				HyperLink t = new HyperLink();
				t.Text = conn.GetFieldValue(i,"CL_DESC") +" ("+ conn.GetFieldValue(i, "COLTYPEDESC") + ") ";
				t.CssClass = "TDBGColor1";
				t.Font.Bold = true;
				
				t.NavigateUrl = "CollateralLegalSigning_Data.aspx?regno="+ LBL_REGNO.Text +"&curef="+ curef + "&prod="+ prodid +
					"&tc="+ LBL_TC.Text +"&cl_seq="+ cl_seq+"&cl_type="+ CL_TYPE + "&na=" + Request.QueryString["na"];
				t.Target = "frm_jaminan";
				this.TBL_JAMINAN.Rows.Add(new TableRow());
				this.TBL_JAMINAN.Rows[i].Cells.Add(new TableCell());
				this.TBL_JAMINAN.Rows[i].Cells[0].Controls.Add(t);
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn));
		}
	}
}
