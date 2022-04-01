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

namespace SME.HistoricalLoanInfo
{
	/// <summary>
	/// Summary description for HistoricalLoanMain.
	/// </summary>
	public partial class HistoricalLoanMain : System.Web.UI.Page
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
				GlobalTools.initDateForm(TXT_AP_RECVDATE_DAY, DDL_AP_RECVDATE_MONTH, TXT_AP_RECVDATE_YEAR);

				viewData();
				ViewProductList();
			}

            BTN_BACK.Click += new ImageClickEventHandler(BTN_BACK_Click);

			ViewMenu();
			viewSubMenu();
		}

		private void viewData() 
		{
			double limitExposure = 0;
			conn.QueryString = "select * from VW_DE_MAIN where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			txt_AP_REGNO.Text		= conn.GetFieldValue("AP_REGNO");
			txt_CU_REF.Text			= conn.GetFieldValue("CU_REF");
			txt_AP_SIGNDATE.Text	= tool.FormatDate(conn.GetFieldValue("AP_SIGNDATE"));
			txt_PROGRAMDESC.Text	= conn.GetFieldValue("PROGRAMDESC");
			txt_BRANCH_NAME.Text	= conn.GetFieldValue("BRANCH_NAME");
			TXT_AP_RELMNGR.Text		= conn.GetFieldValue("SU_FULLNAME");
			txt_CHANNEL_DESC.Text	= conn.GetFieldValue("CHANNEL_DESC");
			txt_AP_SRCCODE.Text		= conn.GetFieldValue("AP_SRCCODE");
			txt_AP_SALESAGENCY.Text = conn.GetFieldValue("AGENCYNAME");
			TXT_GR_BUSINESSUNIT.Text = conn.GetFieldValue("BUSSUNITDESC");
			TXT_AP_TEAMLEADER.Text = conn.GetFieldValue("AP_TEAMLEADER");
			TXT_AP_RECVDATE_DAY.Text				= tool.FormatDate_Day(conn.GetFieldValue("AP_RECVDATE"));
			DDL_AP_RECVDATE_MONTH.SelectedValue		= tool.FormatDate_Month(conn.GetFieldValue("AP_RECVDATE"));
			TXT_AP_RECVDATE_YEAR.Text				= tool.FormatDate_Year(conn.GetFieldValue("AP_RECVDATE"));		

			/// Menghitung limit exposure
			/// 
			conn.QueryString = "exec DE_TOTALEXPOSURE '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			try 
			{
				limitExposure = double.Parse(conn.GetFieldValue(0,0));
			} 
			catch 
			{
				limitExposure = 0;
			}
			txt_AP_LIMITEXPOSURE.Text = tool.MoneyFormat(limitExposure.ToString());
		}

		private void ViewProductList()
		{
			DataTable dt = new DataTable();
			conn.QueryString = "select * from VW_DE_MAINPRODUCTLIST where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
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

                        if (conn.GetFieldValue(i, 3).IndexOf("mc=") >= 0)
                        {
                            strtemp = "regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"];
                        }
                        else
                        {
                            strtemp = "regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&mc=" + Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"];
                        }

                        if (conn.GetFieldValue(i, 3).IndexOf("?de=") < 0 && conn.GetFieldValue(i, 3).IndexOf("&de=") < 0)
                        {
                            strtemp = strtemp + "&de=" + Request.QueryString["de"];
                        }
                        if (conn.GetFieldValue(i, 3).IndexOf("?par=") < 0 && conn.GetFieldValue(i, 3).IndexOf("&par=") < 0)
                        {
                            strtemp = strtemp + "&par=" + Request.QueryString["par"];
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

		private void viewSubMenu() 
		{
			try 
			{
				conn.QueryString = "select * from SCREENSUBMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, "SM_MENUDISPLAY");
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, "SM_LINKNAME").Trim()!= "") 
					{						
						if (conn.GetFieldValue(i,"SM_LINKNAME").IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];

						if (conn.GetFieldValue(i,"SM_LINKNAME").IndexOf("?de=") < 0 && conn.GetFieldValue(i, "SM_LINKNAME").IndexOf("&de=") < 0) 
							strtemp = strtemp + "&de=" + Request.QueryString["de"];	

						if (conn.GetFieldValue(i,"SM_LINKNAME").IndexOf("?par=") < 0 && conn.GetFieldValue(i, "SM_LINKNAME").IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"];
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, "SM_LINKNAME")+strtemp;					
					PH_SUBMENU.Controls.Add(t);
					PH_SUBMENU.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
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
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink("", Request.QueryString["mc"], conn));

			//Response.Redirect("HistoricalLoanList.aspx?curef=" + Request.QueryString["curef"] + "&mc=" + Request.QueryString["mc"]);
		}
	}
}
