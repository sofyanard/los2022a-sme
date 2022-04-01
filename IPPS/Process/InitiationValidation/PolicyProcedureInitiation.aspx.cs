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
using DMS.BlackList;

namespace SME.IPPS.Process.InitiationValidation
{
	/// <summary>
	/// Summary description for PolicyProcedureInitiation.
	/// </summary>
	public partial class PolicyProcedureInitiation : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../../SME/Restricted.aspx");

			ViewMenu();

			if(!IsPostBack)
			{
				
				FillDDL();
				PopulateRequest();
				FillNotaRow();
				ViewUploadFiles();


			}

		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '" + Request.QueryString["mc"] + "'";
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
							strtemp = "regno=" + Request.QueryString["regno"] +  "&tc=" + Request.QueryString["tc"] ;
						else	
							strtemp = "regno=" + Request.QueryString["regno"] +  "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i,3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		
		}

		private void ViewUploadFiles()
		{
			//contoh 
			//			string url = "";
			//			conn.QueryString = "SELECT EXPORT_URL FROM RFEXPORT WHERE EXPORT_ID = ''";
			//			conn.ExecuteQuery();
			//
			//			if (conn.GetRowCount() > 0) 
			//			{
			//				url = conn.GetFieldValue("EXPORT_URL");
			//			}
			//
			//			System.Data.DataTable dt = new System.Data.DataTable();
			//			conn.QueryString = "SELECT NOTA_SEQ, NOTA_FILENAME FROM IPPS_NOTAUPLOAD where IPPS_REGNO='" + Request.QueryString["regno"] + "'";
			//			conn.ExecuteQuery();
			//			dt = conn.GetDataTable().Copy();
			//			DATA_EXPORT.DataSource = dt;
			//			try 
			//			{
			//				DATA_EXPORT.DataBind();
			//			} 
			//			catch 
			//			{
			//				DATA_EXPORT.CurrentPageIndex = 0;
			//				DATA_EXPORT.DataBind();
			//			}
			//			for (int i = 1; i <= DATA_EXPORT.Items.Count; i++)
			//			{
			//				HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("EXPERIENCE_DOWNLOAD");
			//				LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[3].FindControl("EXPERIENCE_DELETE");
			//				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_EXP_NAME");
			//			}
		}

		private void PopulateRequest()
		{
			conn.QueryString = "select * from vw_ipps_requestlist where IPPS_REGNO='"+ Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			dg_list_request.DataSource = dt;
			try 
			{
				dg_list_request.DataBind();
			} 
			catch 
			{
				dg_list_request.CurrentPageIndex = 0;
				dg_list_request.DataBind();
			}
		}

		private void FillDDL()
		{
			//existing policy
			ddl_select_policy.Items.Add(new ListItem("--Select--",""));
			conn.QueryString="select existingpolicy_code, existingpolicy_desc from ipps_rfexistingpolicy where active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				ddl_select_policy.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			//request type
			ddl_req_type.Items.Add(new ListItem("--Select--",""));
			conn.QueryString="select requesttype_code, requesttype_desc from ipps_rfrequesttype where active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				ddl_req_type.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			//policy type
			ddl_pol_type.Items.Add(new ListItem("--Select--",""));
			conn.QueryString="select policytype_code, policytype_desc from ipps_rfpolicytype where active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				ddl_pol_type.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			//request purpose
			ddl_req_pur.Items.Add(new ListItem("--Select--",""));
			conn.QueryString="select requestpurpose_code, requestpurpose_desc from ipps_rfrequestpurpose where active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				ddl_req_pur.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			
			//targetdate
			DDL_BLN_tar_date.Items.Add(new ListItem("--Select--",""));
			ddl_bln_nota.Items.Add(new ListItem("--Select--",""));
			for(int i=1; i<=12; i++)
			{
				DDL_BLN_tar_date.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				ddl_bln_nota.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}
		}


		private void FillNotaRow()
		{
			conn.QueryString ="select * from IPPS_NOTAUPLOAD where IPPS_REGNO = '" + Request.QueryString["regno"] + "'";
            conn.ExecuteQuery();
			
			txt_no_nota.Text			= conn.GetFieldValue("NOTA_NO");
			txt_reference2.Text			= conn.GetFieldValue("IPPS_REGNO");
			txt_subject.Text			= conn.GetFieldValue("NOTA_SUBJECT");
			txt_tgl_nota.Text			= tool.FormatDate_Day(conn.GetFieldValue("NOTA_DATE"));
            ddl_bln_nota.SelectedValue	= tool.FormatDate_Month(conn.GetFieldValue("NOTA_DATE"));
			txt_thn_nota.Text			= tool.FormatDate_Year(conn.GetFieldValue("NOTA_DATE"));
		
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
			this.dg_list_request.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dg_list_request_ItemCommand);

		}
		#endregion

		private void dg_list_request_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":	
					conn.QueryString = "select * from ipps_request where ipps_regno='" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();

					//Fill REQUEST INFO ROW---
					ddl_select_policy.SelectedValue = "";
					
					if(conn.GetFieldValue("REQ_ISNEW")=="1")
					{
						ddl_req_type.Items.Add(new ListItem("New","n"));
						ddl_req_type.SelectedValue = "n";
					}
					else
						ddl_req_type.SelectedValue = conn.GetFieldValue("REQUEST_TYPE");
					
					ddl_pol_type.SelectedValue = conn.GetFieldValue("POLICY_TYPE");
					ddl_req_pur.SelectedValue = conn.GetFieldValue("REQUEST_PURPOSE");
					txt_tgl_tar_date.Text = tool.FormatDate_Day(conn.GetFieldValue("IMPLEMENT_TERGET_DATE"));
					DDL_BLN_tar_date.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("IMPLEMENT_TERGET_DATE"));
					TXT_THN_tar_date.Text = tool.FormatDate_Year(conn.GetFieldValue("IMPLEMENT_TERGET_DATE"));
					txt_remarks.Text = conn.GetFieldValue("REMARK");
					//----
					
					
					break;
			}
		
		}
	}
}
