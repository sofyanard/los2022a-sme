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
	/// Summary description for RevwCovenantCustInfo.
	/// </summary>
	public partial class RevwCovenantCustInfo : System.Web.UI.Page
	{
		protected Connection conn;
	
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
							strtemp = "curef="+Request.QueryString["curef"];
						else
							strtemp = "curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"];
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

		private void ViewData()
		{
			try 
			{
				conn.QueryString = "SELECT * FROM VW_REVIEWCOVENANT_CUSTINFO WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0) 
				{
					TXT_CU_CIF.Text = conn.GetFieldValue("CU_CIF");
					TXT_CU_NAME.Text = conn.GetFieldValue("CU_NAME");
					TXT_CU_ADDR1.Text = conn.GetFieldValue("CU_ADDR1");
					TXT_CU_ADDR2.Text = conn.GetFieldValue("CU_ADDR2");
					TXT_CU_ADDR3.Text = conn.GetFieldValue("CU_ADDR3");
					TXT_CU_CITY.Text = conn.GetFieldValue("CU_CITY");
					TXT_KEYPERSON.Text = conn.GetFieldValue("KEYPERSON");
					TXT_PHONE.Text = conn.GetFieldValue("PHONE");
					TXT_CU_RM.Text = conn.GetFieldValue("CU_RM");
					TXT_BRANCH.Text = conn.GetFieldValue("BRANCH");
					TXT_BUSSUNIT.Text = conn.GetFieldValue("BUSSUNIT");
				}
			} 
			catch (Exception ex) 
			{
				Response.Write("<!--" + ex.Message + "-->");
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
	}
}
