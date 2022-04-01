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
	/// Summary description for GenInfoWatchlist3_1.
	/// </summary>
	public partial class GenInfoWatchlist3_1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.Button BTN_INSERT;
		protected Tools tool = new Tools();
		protected Connection conn;
		protected CommonForm.DocExport DocExport1;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];			

			if (!IsPostBack)
			{				
				DDL_BLN_NOTA.Items.Add(new ListItem("--Pilih--",""));
				for(int i=1; i<=12; i++)
				{
					DDL_BLN_NOTA.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));					
				}				
								
				conn.QueryString = "select userid, su_fullname from scuser ";
				conn.ExecuteQuery();
				DDL_ASG.Items.Add(new ListItem("--Pilih--",""));				
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_ASG.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select top 0 * from VW_PORTFOLIO_KU_FIX";
				conn.ExecuteQuery();
				FillGridPortfolio();				
				
				CekCode();
				ViewUserRisk();				
				ViewPeriodeData();
				DocExport1.GroupTemplate = "PWLPRINT";
			}			
		}

		private void ViewUserRisk()
		{			
			conn.QueryString = "select * from VW_PORTFOLIO_WC_USER_HISTORY where no_lms='"+TXT_NO_LMS.Text+"' ";
			conn.ExecuteQuery();	
			DDL_ASG.SelectedValue = conn.GetFieldValue("por_trackby");
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

		protected void Button1_Click(object sender, System.EventArgs e)
		{
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

		protected void BTN_FWD_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "select * from VW_PORTFOLIO_WC_USER_HISTORY where no_lms='"+TXT_NO_LMS.Text+"' ";
			conn.ExecuteQuery();	
			string pic_risk = conn.GetFieldValue("por_trackby");
			conn.QueryString = " exec PORTFOLIO_WC_TRACKUPDATE '" +
				TXT_NO_LMS.Text +"', 'P3', '" + 				
				Session["UserID"].ToString()+" ', '"+ pic_risk +"' ";			
			conn.ExecuteQuery();
			Response.Redirect("AdvisPortRevWC.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("AdvisPortRevWC.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_CLEAR_PERIODE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "update PORLMS_RESULT_DATA set strategy='' where loan_type_id = '"+ LBL_LOAN_TYPE_ID.Text +"' and no_lms='"+Request.QueryString["porlmsregno"]+"'";
			conn.ExecuteQuery();

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



	}
}
