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
using System.Configuration;
using DMS.DBConnection;
using DMS.CuBESCore;
using DMS.BlackList;
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;

namespace SME.LMS.PortfolioWatchlistChecking
{
	/// <summary>
	/// Summary description for GenInfoWatchlist2.
	/// </summary>
	public partial class GenInfoWatchlist2 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LBL_STATUS;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Label LBL_STATUSREPORT;
		protected System.Web.UI.WebControls.Button BTN_UPLOAD;
		protected System.Web.UI.HtmlControls.HtmlTableCell Td1;
		protected System.Web.UI.HtmlControls.HtmlInputFile TXT_FILE_UPLOAD;
		protected Connection conn;
		protected System.Web.UI.WebControls.DataGrid DATA_EXPORT;
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected CommonForm.DocExport DocExport1;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
			//Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{				
				DDL_BLN_NOTA.Items.Add(new ListItem("--Pilih--",""));
				for(int i=1; i<=12; i++)
				{
					DDL_BLN_NOTA.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));					
				}

				conn.QueryString = "select top 0 * from VW_PORTFOLIO_KU_FIX";
				conn.ExecuteQuery();
				FillGridPortfolio();
				
				CekCode();				
				ViewPeriodeData();

				DocExport1.GroupTemplate = "PWLPRINT";							
			}
			ViewAcqInfo2();	
			ViewMenu();
		}

		private void CekCode()
		{			
			string flag = Request.QueryString["flag"];
			TXT_NO_LMS.Text = Request.QueryString["porlmsregno"];
			/*conn.QueryString = "select * from scuser where userid='"+Session["UserID"].ToString()+"' ";
			conn.ExecuteQuery();
			TXT_ANALYST.Text = conn.GetFieldValue("su_fullname") ;	*/	
		
			if (flag=="0")
			{
				conn.QueryString = "select getdate()";
				conn.ExecuteQuery();
				TXT_LMS_DATE.Text = conn.GetFieldValue(0,0);
			}
			else
			{
				conn.QueryString = "select * from PORTFOLIO_WC where no_lms= '"+Request.QueryString["porlmsregno"]+"' ";
				conn.ExecuteQuery();
				TXT_LMS_DATE.Text = conn.GetFieldValue("lms_date");
				TXT_NO_NOTA.Text = conn.GetFieldValue("no_nota");
				TXT_PERIODE.Text = conn.GetFieldValue("periode");
				TXT_TGL_NOTA.Text = tool.FormatDate_Day(conn.GetFieldValue("tgl_nota"));
				try{DDL_BLN_NOTA.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("tgl_nota"));}
				catch{DDL_BLN_NOTA.SelectedValue = "";}
				TXT_THN_NOTA.Text = tool.FormatDate_Year(conn.GetFieldValue("tgl_nota"));
				TXT_ANALYST.Text = conn.GetFieldValue("analyst") ;
			}
			
		}

		private void FillGridPortfolio()
		{			
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DATGRD_PORTFOLIO.DataSource = dt;
			try 
			{
				DATGRD_PORTFOLIO.DataBind();
			} 
			catch 
			{
				DATGRD_PORTFOLIO.CurrentPageIndex = 0;
				DATGRD_PORTFOLIO.DataBind();
			}

			for (int i=0;i<DATGRD_PORTFOLIO.Items.Count;i++)
			{
				TextBox por_strategy = (TextBox) DATGRD_PORTFOLIO.Items[i].Cells[7].FindControl("TXT_STRATEGY");				
				conn.QueryString = "select * from PORLMS_RESULT_DATA where unit_cd= '"+DATGRD_PORTFOLIO.Items[i].Cells[8].Text.Trim()+"' and loan_type_id='"+LBL_LOAN_TYPE_ID.Text+"' and no_lms='"+Request.QueryString["porlmsregno"]+"'";
				conn.ExecuteQuery();				
				por_strategy.Text = conn.GetFieldValue("strategy");
			}
		}		

		private void ViewPeriodeData()
		{
			conn.QueryString = "select distinct loan_type_id, loan_type from porlms_emas_data";
			conn.ExecuteQuery();

			FillGridPeriodeData();
		}

		private void FillGridPeriodeData()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DATGRD_PERIODE.DataSource = dt;
			try 
			{
				DATGRD_PERIODE.DataBind();
			} 
			catch 
			{
				DATGRD_PERIODE.CurrentPageIndex = 0;
				DATGRD_PERIODE.DataBind();
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
			this.DATGRD_PERIODE.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATGRD_PERIODE_ItemCommand);
			this.DATGRD_PERIODE.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATGRD_PERIODE_PageIndexChanged);
			this.DATGRD_PORTFOLIO.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATGRD_PORTFOLIO_PageIndexChanged);

		}
		#endregion

		private void DATGRD_PERIODE_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Retrieve":
					LBL_LOAN_TYPE_ID.Text = e.Item.Cells[0].Text;
					if (LBL_LOAN_TYPE_ID.Text=="01")
					{
						conn.QueryString = "select * from VW_PORTFOLIO_KUP_FIX order by buc_cd";
						conn.ExecuteQuery();
					}
					else
					{
						conn.QueryString = "select * from VW_PORTFOLIO_KU_FIX order by buc_cd";
						conn.ExecuteQuery();
					}
					FillGridPortfolio();
					break;
			}
		}

		private void DATGRD_PERIODE_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATGRD_PERIODE.CurrentPageIndex = e.NewPageIndex;
			ViewPeriodeData();
		}

		private void DATGRD_PORTFOLIO_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATGRD_PORTFOLIO.CurrentPageIndex = e.NewPageIndex;
			if (LBL_LOAN_TYPE_ID.Text=="01")
			{
				conn.QueryString = "select * from VW_PORTFOLIO_KUP_FIX";
				conn.ExecuteQuery();
			}
			else
			{
				conn.QueryString = "select * from VW_PORTFOLIO_KU_FIX";
				conn.ExecuteQuery();
			}

			FillGridPortfolio();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("PortfAccepNotaWCBU.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_CLEAR_PERIODE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "select * from VW_portfolio_wc_apptrack_history where no_lms='"+Request.QueryString["porlmsregno"]+"' ";
			conn.ExecuteQuery();
			if(conn.GetFieldValue("trackcode")!= "P2")
				Response.Redirect("PortfAccepNotaWCBU.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );

			conn.QueryString = "update PORLMS_RESULT_DATA set strategy='' where loan_type_id = '"+ LBL_LOAN_TYPE_ID.Text +"' and no_lms='"+Request.QueryString["porlmsregno"]+"'";
			conn.ExecuteQuery();

			if (LBL_LOAN_TYPE_ID.Text=="01")
			{
				conn.QueryString = "select * from VW_PORTFOLIO_KUP_FIX order by buc_cd";
				conn.ExecuteQuery();
			}
			else
			{
				conn.QueryString = "select * from VW_PORTFOLIO_KU_FIX order by buc_cd";
				conn.ExecuteQuery();
			}
			FillGridPortfolio();
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "select * from VW_portfolio_wc_apptrack_history where no_lms='"+Request.QueryString["porlmsregno"]+"' ";
			conn.ExecuteQuery();
			if(conn.GetFieldValue("trackcode")!= "P2")
				Response.Redirect("PortfAccepNotaWCBU.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );

			string loan_id = LBL_LOAN_TYPE_ID.Text;			

			for (int i = 0; i < DATGRD_PORTFOLIO.Items.Count; i++)
			{				
				TextBox por_strategy = (TextBox) DATGRD_PORTFOLIO.Items[i].Cells[7].FindControl("TXT_STRATEGY");
				string strategy;
				strategy=por_strategy.Text;				
					
				conn.QueryString = "exec LMSPO_RSULT_INSERT '" +
					TXT_NO_LMS.Text +"', "+	
					tool.ConvertDate(TXT_LMS_DATE.Text) +", '"+
					DATGRD_PORTFOLIO.Items[i].Cells[8].Text.Trim() + "' , '" + 
					DATGRD_PORTFOLIO.Items[i].Cells[0].Text.Trim() + "' , '" + 
					DATGRD_PORTFOLIO.Items[i].Cells[2].Text.Trim() + "' , '" + 
					tool.ConvertFloat(DATGRD_PORTFOLIO.Items[i].Cells[3].Text.Trim()) + "' , '" +
					tool.ConvertFloat(DATGRD_PORTFOLIO.Items[i].Cells[4].Text.Trim()) + "' , '" +
					tool.ConvertFloat(DATGRD_PORTFOLIO.Items[i].Cells[5].Text.Trim()) + "' , '" +
					DATGRD_PORTFOLIO.Items[i].Cells[6].Text.Trim() + "' , '" + 
					por_strategy.Text + "' , '" + 
					DATGRD_PORTFOLIO.Items[i].Cells[9].Text.Trim() + "' ";
				conn.ExecuteQuery();				
			}
		}

		protected void BTN_ACCEPT_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "select * from VW_portfolio_wc_apptrack_history where no_lms='"+Request.QueryString["porlmsregno"]+"' ";
			conn.ExecuteQuery();
			if(conn.GetFieldValue("trackcode")!= "P2")
				Response.Redirect("PortfAccepNotaWCBU.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );

			string mitrarm;
			conn.QueryString = "select * from scuser where userid='" + Session["UserID"].ToString() +"'";
			conn.ExecuteQuery();
			mitrarm = conn.GetFieldValue("su_mitrarm");

			conn.QueryString = " exec PORTFOLIO_WC_TRACKUPDATE '" +
				TXT_NO_LMS.Text +"', 'P3', '" + 				
				Session["UserID"].ToString()+" ', '"+mitrarm+"' ";			
			conn.ExecuteQuery();
			Response.Redirect("PortfAccepNotaWCBU.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );

			/*conn.QueryString = " exec PORTFOLIO_WC_ACQ_HISTORY '" +
				TXT_NO_LMS.Text + "', 'P3', '" + 				
				Session["UserID"].ToString()+ " ', '" + mitrarm + "', '' ";			
			conn.ExecuteNonQuery(); */
		}

		protected void BTN_ACQ_Click(object sender, System.EventArgs e)
		{			
			conn.QueryString = "select * from VW_portfolio_wc_apptrack_history where no_lms='"+Request.QueryString["porlmsregno"]+"' ";
			conn.ExecuteQuery();
			string trackcode = conn.GetFieldValue("trackcode");
			if(conn.GetFieldValue("trackcode")!= "P2")
				Response.Redirect("PortfAccepNotaWCBU.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );

			conn.QueryString = "select * from PORTFOLIO_WC where no_lms='" + TXT_NO_LMS.Text +"'";
			conn.ExecuteQuery();
			LBL_USERID.Text = conn.GetFieldValue("analyst_userid");
			Response.Write("<script for=window event=onload language='javascript'>PopupPage('AcqInfo1.aspx?no_lms=" + TXT_NO_LMS.Text+ "&por_trackby=" + Session["USERID"].ToString() + "&por_tracknextby=" + LBL_USERID.Text + "&theForm=Form1&theObj=TXT_TEMP', '800','350');</script>");			
		}

		private void ViewAcqInfo2()
		{
			conn.QueryString = "select * from VW_PORTFOLIO_WC_USER_HISTORY where no_lms='" +TXT_NO_LMS.Text+ "' ";
			conn.ExecuteQuery();			
			TXT_SEND_BY.Text = conn.GetFieldValue("analyst_userid");

			string upliner;
			conn.QueryString = "select * from scuser where userid='" + Session["UserID"].ToString() +"'";
			conn.ExecuteQuery();
			upliner=conn.GetFieldValue("su_upliner");

			HyperLink acqInfo = new HyperLink();
			acqInfo.Text = "Acquire Information";
			acqInfo.Font.Bold = true;
			acqInfo.NavigateUrl = "AcqInfo2.aspx?no_lms=" + TXT_NO_LMS.Text + "&send_to=" + upliner + "&send_by=" + TXT_SEND_BY.Text; //+ "&sta=view";
			//Response.Write("<script for=window event=onload language='javascript'>PopupPage('ACQ.aspx?regnum=" + TXT_HRS.Text + "&send_to=" + TXT_SEND_TO.Text + "&send_by=" + TXT_SEND_BY.Text + "&theForm=Form1&theObj=TXT_TEMP', '800','350');</script>");			
			acqInfo.Target = "if2";

			conn.QueryString = "select * from VW_PORTFOLIO_WC_ACQ_APPTRACK where no_lms='" +TXT_NO_LMS.Text+ "' ";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("TRACKCODE")=="P2")
			{
				Placeholder1.Controls.Add(acqInfo);
				Placeholder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));

				/***
				PlaceHolder1.Controls.Add(collateral_peal);
				PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				***/
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

	}
}
