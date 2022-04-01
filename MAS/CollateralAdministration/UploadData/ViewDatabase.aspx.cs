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
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;

namespace SME.MAS.CollateralAdministration.UploadData
{
	/// <summary>
	/// Summary description for ViewDatabase.
	/// </summary>
	public partial class ViewDatabase : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			if(!IsPostBack)
			{
				ViewDataResult();	
				conn.QueryString = "select count(*) as tot_record from MAS_COLLATERAL";
				conn.ExecuteQuery();
				TXT_TOT_RECORD.Text = conn.GetFieldValue("tot_record");
			}	
		}

		private void ViewDataResult()
		{
			if(TXT_ACC_NUM.Text != "" && TXT_CUST_NAME.Text == "")
			{
				conn.QueryString = "select a.UPLOAD_DATE, a.ACC_NUMBER, a.CUST_NAME, a.COLLATERAL_ID, a.agunan_name, a.DISTRIK_CODE, a.CLUSTER_CODE, a.UNIT_CODE, b.ACC_STATUS from MAS_COLLATERAL a, MAS_APP_CURRTRACK b where a.acc_number= '"+ TXT_ACC_NUM.Text +"'" + 
									" and a.COLLATERAL_ID = b.COLLATERALID and a.acc_number = b.ACC_NUMBER order by a.upload_date desc";
				conn.ExecuteQuery();				
			}
			if (TXT_ACC_NUM.Text == "" && TXT_CUST_NAME.Text != "")
			{
				conn.QueryString = "select * from MAS_COLLATERAL, MAS_APP_CURRTRACK where cust_name like '%" + TXT_CUST_NAME.Text + "%' order by upload_date desc";
				conn.QueryString = "select a.UPLOAD_DATE, a.ACC_NUMBER, a.CUST_NAME, a.COLLATERAL_ID, a.agunan_name, a.DISTRIK_CODE, a.CLUSTER_CODE, a.UNIT_CODE, b.ACC_STATUS from MAS_COLLATERAL a, MAS_APP_CURRTRACK b where a.cust_name like '%" + TXT_CUST_NAME.Text + "%'" + 
					" and a.COLLATERAL_ID = b.COLLATERALID and a.acc_number = b.ACC_NUMBER order by a.upload_date desc";
				conn.ExecuteQuery();
			}
			if (TXT_ACC_NUM.Text == "" && TXT_CUST_NAME.Text == "")
			{
				conn.QueryString = "select a.UPLOAD_DATE, a.ACC_NUMBER, a.CUST_NAME, a.COLLATERAL_ID, a.agunan_name, a.DISTRIK_CODE, a.CLUSTER_CODE, a.UNIT_CODE, b.ACC_STATUS from MAS_COLLATERAL a, MAS_APP_CURRTRACK b where a.COLLATERAL_ID = b.COLLATERALID and a.acc_number = b.ACC_NUMBER order by a.upload_date desc";
				conn.ExecuteQuery();
			}			
			FillGridResult();
		}

		private void FillGridResult()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_RESULT.DataSource = dt;
			try 
			{
				DGR_RESULT.DataBind();
			} 
			catch 
			{
				DGR_RESULT.CurrentPageIndex = 0;
				DGR_RESULT.DataBind();
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
			this.DGR_RESULT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_RESULT_PageIndexChanged);

		}
		#endregion

		protected void BTN_FIND1_Click(object sender, System.EventArgs e)
		{
			ViewDataResult();
		}

		private void DGR_RESULT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_RESULT.CurrentPageIndex = e.NewPageIndex;
			ViewDataResult();
		}

		protected void BTN_FIND2_Click(object sender, System.EventArgs e)
		{
			ViewDataResult();
		}

		private void ViewMenu()
		{
			Menu.Controls.Clear();
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
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"] + "&exist=" + Request.QueryString["exist"]+ "&view=" + Request.QueryString["view"];
						else	
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+ "&exist=" + Request.QueryString["exist"]+ "&tc="+Request.QueryString["tc"]+ "&view=" + Request.QueryString["view"];
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"] + "&mc2=" + Request.QueryString["mc2"];
					}
					else 
					{
						strtemp = ""; 
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
