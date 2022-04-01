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

namespace SME.Legal.LegalAdviseAdministration.InquiryHistoricalData
{
	/// <summary>
	/// Summary description for DetailRequestInfo.
	/// </summary>
	public partial class DetailRequestInfo : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			FillDGRDoc();
			ViewUploadFiles();
			if(!IsPostBack)
			{
				FillDDLGroup();
				FillDDLUnit();
				FillDDLRahasia();
				
				DDL_REQUEST_MONTH.Items.Add(new ListItem("--Select--",""));
				DDL_TGL_TARGET_MONTH.Items.Add(new ListItem("--Select--",""));
				DDL_TGL_KIRIM_MONTH.Items.Add(new ListItem("--Select--",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_REQUEST_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_TGL_TARGET_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_TGL_KIRIM_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
				FillDDLOfficer();
				ViewData();
			}
		}

		private void ViewMenu()
		{
			Menu.Controls.Clear();
			try 
			{
				conn.QueryString = "SELECT * FROM SCREENMENU WHERE MENUCODE = '" + Request.QueryString["mc"] + "'";
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
							strtemp = "&curef=" + Request.QueryString["curef"] + "&view=" + Request.QueryString["view"];
						else	
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&curef=" + Request.QueryString["curef"] + "&view=" + Request.QueryString["view"];
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

		private void FillDDLGroup()
		{
			DDL_GROUP.Items.Clear();
			DDL_GROUP.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_LGAM_DDLGROUP";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_GROUP.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLUnit()
		{
			DDL_UNIT.Items.Clear();
			DDL_UNIT.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_LGAM_DDLUNIT";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLRahasia()
		{
			DDL_STS_RAHASIA.Items.Clear();
			DDL_STS_RAHASIA.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT CODE, [DESC] FROM RF_RAHASIA_CODE WHERE ACTIVE = '1'";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_STS_RAHASIA.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM VW_LGAM_HISTORICAL_LIST WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			TXT_REF.Text						= conn.GetFieldValue("REFERENCE").ToString().Replace("&nbsp;","");
			TXT_REQUEST_DAY.Text				= tools.FormatDate_Day(conn.GetFieldValue("REQUEST_DATE").ToString());
			DDL_REQUEST_MONTH.SelectedValue		= tools.FormatDate_Month(conn.GetFieldValue("REQUEST_DATE").ToString());
			TXT_REQUEST_YEAR.Text				= tools.FormatDate_Year(conn.GetFieldValue("REQUEST_DATE").ToString());
			DDL_GROUP.SelectedValue				= conn.GetFieldValue("REQUESTER_GROUP").ToString();
			DDL_UNIT.SelectedValue				= conn.GetFieldValue("REQUESTER_UNIT").ToString();
			TXT_PIC_REQUEST.Text				= conn.GetFieldValue("REQUESTER").ToString().Replace("&nbsp;","");
			TXT_TGL_TARGET_DAY.Text				= tools.FormatDate_Day(conn.GetFieldValue("TARGET_FINISH").ToString());
			DDL_TGL_TARGET_MONTH.SelectedValue	= tools.FormatDate_Month(conn.GetFieldValue("TARGET_FINISH").ToString());
			TXT_TGL_TARGET_YEAR.Text			= tools.FormatDate_Year(conn.GetFieldValue("TARGET_FINISH").ToString());

			if(conn.GetFieldValue("DOC_COMPLITED").ToString() != "")
			{
				RDO_DOC_KELENGKAPAN.SelectedValue	= conn.GetFieldValue("DOC_COMPLITED").ToString();
			}

			DDL_STS_RAHASIA.SelectedValue		= conn.GetFieldValue("RAHASIA_STATUS").ToString();
			TXT_REQUEST_DESC.Text				= conn.GetFieldValue("REQUEST_DESC").ToString().Replace("&nbsp;","");
			DDL_LEGAL_OFFICER.SelectedValue		= conn.GetFieldValue("LEGAL_OFFICER").ToString();
			TXT_NOTA_KIRIM.Text					= conn.GetFieldValue("NOTA_RESULT").ToString().Replace("&nbsp;","");
			TXT_TGL_KIRIM_DAY.Text				= tools.FormatDate_Day(conn.GetFieldValue("SEND_RESULT").ToString());
			DDL_TGL_KIRIM_MONTH.SelectedValue	= tools.FormatDate_Month(conn.GetFieldValue("SEND_RESULT").ToString());
			TXT_TGL_KIRIM_YEAR.Text				= tools.FormatDate_Year(conn.GetFieldValue("SEND_RESULT").ToString());
			TXT_REMARK.Text						= conn.GetFieldValue("REMARK_RESULT").ToString().Replace("&nbsp","");
		}

		private void FillDDLOfficer()
		{
			DDL_LEGAL_OFFICER.Items.Clear();
			DDL_LEGAL_OFFICER.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_LGAM_LIST_LEGAL_OFFICER";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_LEGAL_OFFICER.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDGRDoc()
		{
			conn.QueryString = "SELECT * FROM LGAM_INITIATION_DOC_NAME WHERE CU_REF = '" + Request.QueryString["curef"] + "' ORDER BY SEQ";
			BindData(DATA_GRID.ID.ToString(), conn.QueryString);
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();

				System.Data.DataTable dt = new System.Data.DataTable();
				dt = conn.GetDataTable().Copy();

				System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);
				dg.DataSource = dt;

				try
				{
					dg.DataBind();
				}
				catch
				{
					dg.CurrentPageIndex = dg.PageCount - 1;	
					dg.DataBind();
				}

				conn.ClearData();
			}
		}

		private void ViewUploadFiles()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM RFEXPORT WHERE EXPORT_ID = 'LEGALADVISE01'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
				//url = /SME/JiwaServiceUpload/
			}

			conn.QueryString = "SELECT ID_UPLOAD_EXP, FILE_UPLOAD_EXP_NAME FROM LGAM_FILE_UPLOAD_EXP WHERE CU_REF = '" + Request.QueryString["curef"] + "' AND TYPE = '1'";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();
			DATA_EXPORT.DataSource = dt;
			try 
			{
				DATA_EXPORT.DataBind();
			} 
			catch 
			{
				DATA_EXPORT.CurrentPageIndex = 0;
				DATA_EXPORT.DataBind();
			}
			for (int i = 1; i <= DATA_EXPORT.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("SCORING_DOWNLOAD");
				//LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[3].FindControl("SCORING_DELETE");
				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_EXP_NAME");
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
			this.DATA_GRID.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_GRID_PageIndexChanged);
			this.DATA_EXPORT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_EXPORT_PageIndexChanged);

		}
		#endregion

		private void DATA_GRID_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_GRID.CurrentPageIndex = e.NewPageIndex;
			FillDGRDoc();
		}

		private void DATA_EXPORT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_EXPORT.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFiles();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(Request.QueryString["view"] == "1")
			{
				Response.Redirect("../AssignmentValidation/RequestList.aspx?mc=LGL02");
			}
			else
			{
				Response.Redirect("ResultList.aspx?mc=" + Request.QueryString["mc"]);
			}
		}
	}
}
