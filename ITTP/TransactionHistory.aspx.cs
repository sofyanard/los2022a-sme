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

namespace SME.ITTP
{
	/// <summary>
	/// Summary description for TransactionHistory.
	/// </summary>
	public partial class TransactionHistory : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TXT_CON;
		protected System.Web.UI.WebControls.TextBox Textbox9;
		protected System.Web.UI.WebControls.TextBox Textbox10;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_generalinfo3;
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.TextBox TXT_AP_RELMNGR;
		protected System.Web.UI.WebControls.TextBox TXT_CU_IDTYPE;
		protected System.Web.UI.WebControls.TextBox TXT_CU_NAME;
		protected System.Web.UI.WebControls.TextBox TXT_CU_CIF;
		protected System.Web.UI.WebControls.TextBox TXT_CU_IDNUM;
		protected System.Web.UI.WebControls.TextBox TXT_CU_ADDR1;
		protected System.Web.UI.WebControls.TextBox TXT_CU_ADDR3;
		protected System.Web.UI.WebControls.TextBox TXT_AP_SIGNDATE;
		protected System.Web.UI.WebControls.TextBox TXT_TL;
		protected System.Web.UI.WebControls.TextBox TXT_BRANCH_NAME;
		protected System.Web.UI.WebControls.TextBox TXT_CU_ADDR2;
		protected System.Web.UI.WebControls.TextBox TXT_AP_REGNO;
		protected Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			lbl_curef.Text = Request.QueryString ["curef"];
		
			if (Request.QueryString["de"] == "1")
				if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
					Response.Redirect("/SME/Restricted.aspx");

			



			if (!IsPostBack)
			{

				ViewMenu();

				conn.QueryString = "exec IT_TRANSACTIONHISTORY '"+lbl_curef.Text+"'";
				conn.ExecuteQuery();
				FillGrid();
				
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


		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = 0;
				DatGrd.DataBind();
			}

			bool isComplete = false;
			for (int i = 0; i < DatGrd.Items.Count; i++) 
			{
				DatGrd.Items[i].Cells[5].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[5].Text);
				DatGrd.Items[i].Cells[8].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[8].Text);
				DatGrd.Items[i].Cells[9].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[9].Text);
				DatGrd.Items[i].Cells[10].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[10].Text);
			}
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
						if (conn.GetFieldValue(i,3).IndexOf("?de=") < 0 && conn.GetFieldValue(i,3).IndexOf("&de=") < 0) 
							strtemp = strtemp + "&de=" + Request.QueryString["de"];	
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"];
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
	}
}