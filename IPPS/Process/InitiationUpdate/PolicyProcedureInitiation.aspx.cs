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
namespace SME.IPPS.Process.InitiationUpdate
{
	/// <summary>
	/// Summary description for PolicyProcedureInitiation.
	/// </summary>
	public class PolicyProcedureInitiation : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TXT_unit;
		protected System.Web.UI.WebControls.TextBox TXT_reference;
		protected System.Web.UI.WebControls.TextBox TXT_request_date;
		protected System.Web.UI.WebControls.RadioButtonList rdo_req_info;
		protected System.Web.UI.WebControls.DropDownList ddl_select_policy;
		protected System.Web.UI.WebControls.DropDownList ddl_req_type;
		protected System.Web.UI.WebControls.DropDownList ddl_pol_type;
		protected System.Web.UI.WebControls.DropDownList ddl_req_pur;
		protected System.Web.UI.WebControls.TextBox txt_tgl_tar_date;
		protected System.Web.UI.WebControls.DropDownList DDL_BLN_tar_date;
		protected System.Web.UI.WebControls.TextBox TXT_THN_tar_date;
		protected System.Web.UI.WebControls.TextBox txt_remark;
		protected System.Web.UI.WebControls.Button BTN_Insert;
		protected System.Web.UI.WebControls.Button BTN_clear;
		protected System.Web.UI.WebControls.DataGrid dg_list_request;
		protected System.Web.UI.WebControls.Label LBL_UPLOAD;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Label LBL_STATUSREPORT;
		protected System.Web.UI.WebControls.Button BTN_UPLOAD;
		protected System.Web.UI.WebControls.DataGrid DATA_EXPORT;
		protected System.Web.UI.WebControls.TextBox txt_no_nota;
		protected System.Web.UI.WebControls.TextBox txt_reference2;
		protected System.Web.UI.WebControls.TextBox txt_tgl_nota;
		protected System.Web.UI.WebControls.DropDownList ddl_bln_nota;
		protected System.Web.UI.WebControls.TextBox txt_thn_nota;
		protected System.Web.UI.WebControls.TextBox txt_subject;
		protected System.Web.UI.WebControls.Button btn_update;
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.TextBox TXT_REMARK;
		protected System.Web.UI.WebControls.TextBox txt_remarks;
		protected System.Web.UI.HtmlControls.HtmlInputFile TXT_FILE_UPLOAD;
		protected Connection conn;
		protected System.Web.UI.WebControls.Label LBL_SEQ;
		protected Tools tool = new Tools();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/../SME/Restricted.aspx");

			ViewMenu();

			if(!IsPostBack)
			{
				
				if(Request.QueryString["mc"]!="IPPS01012")
					btn_update.Visible = false;

				//fill remark
				conn.QueryString="select ACQINFO from IPPS_APPLICATION WHERE IPPS_REGNO='" + Request.QueryString["regno"] + "'" + " and CURRENT_TRACK='"+ Request.QueryString["tc"]+ "'";
				conn.ExecuteQuery();
				TXT_REMARK.Text = conn.GetFieldValue("ACQINFO");

				ViewData();
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


		private void ViewData()
		{
			conn.QueryString = "select * from vw_ipps_initiationlist where CURRENT_TRACK='"+ Request.QueryString["tc"] + "'" 
				+ "and IPPS_REGNO='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			TXT_unit.Text = conn.GetFieldValue("UNIT");
			TXT_reference.Text = conn.GetFieldValue("IPPS_REGNO");
			TXT_request_date.Text = conn.GetFieldValue("INIT_DATE");
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
			this.rdo_req_info.SelectedIndexChanged += new System.EventHandler(this.rdo_req_info_SelectedIndexChanged);
			this.BTN_Insert.Click += new System.EventHandler(this.BTN_Insert_Click);
			this.BTN_clear.Click += new System.EventHandler(this.BTN_clear_Click);
			this.dg_list_request.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dg_list_request_ItemCommand);
			this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dg_list_request_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":	
					conn.QueryString = "select * from ipps_request where ipps_regno='" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();

					//Fill REQUEST INFO ROW---
					
					LBL_SEQ.Text = conn.GetFieldValue("REQ_SEQ");
					if(conn.GetFieldValue("REQ_ISNEW")=="1")
					{
						rdo_req_info.SelectedValue = "1";
						ddl_select_policy.Enabled = false;
						ddl_req_type.Enabled = false;
					}
					else
					{
						rdo_req_info.SelectedValue = "2" ;
						ddl_req_type.SelectedValue = conn.GetFieldValue("REQUEST_TYPE");
					}
					ddl_pol_type.SelectedValue = conn.GetFieldValue("POLICY_TYPE");
					ddl_req_pur.SelectedValue = conn.GetFieldValue("REQUEST_PURPOSE");
					txt_tgl_tar_date.Text = tool.FormatDate_Day(conn.GetFieldValue("IMPLEMENT_TERGET_DATE"));
					DDL_BLN_tar_date.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("IMPLEMENT_TERGET_DATE"));
					TXT_THN_tar_date.Text = tool.FormatDate_Year(conn.GetFieldValue("IMPLEMENT_TERGET_DATE"));
					txt_remarks.Text = conn.GetFieldValue("REMARK");
					//----			
					
					break;

				case "delete":
					try
					{
						conn.QueryString = "exec IPPS_INITIATION_REQUEST_SAVE '2', '" +
							Request.QueryString["regno"] + "', '" +
							e.Item.Cells[1].Text + "', '" +
							/* e.Item.Cells[2].Text + */ "', '" +
							/* e.Item.Cells[3].Text + */ "', '" +
							/* e.Item.Cells[5].Text + */ "', '" +
							/* e.Item.Cells[7].Text + */ "', '" +
							/* e.Item.Cells[9].Text + */ "', '" +
							/* e.Item.Cells[11].Text + */ "', '" +
							/* e.Item.Cells[12].Text + */ "'";
						conn.ExecuteNonQuery();

						PopulateRequest();
						ClearRequest();
					}
					catch (Exception ex)
					{
						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						return;
					}

					break;
			}
		
		
		
		}

		private void BTN_Insert_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "exec IPPS_INITIATION_REQUEST_SAVE '1', '" +
					Request.QueryString["regno"] + "', '" +
					LBL_SEQ.Text + "', '" +
					rdo_req_info.SelectedValue + "', '" +
					ddl_req_type.SelectedValue + "', '" +
					ddl_select_policy.SelectedValue + "', '" +
					ddl_pol_type.SelectedValue + "', '" +
					ddl_req_pur.SelectedValue + "', " +
					tool.ConvertDate(txt_tgl_tar_date.Text, DDL_BLN_tar_date.SelectedValue, TXT_THN_tar_date.Text) + ", '" +
					txt_remarks.Text + "'";

				conn.ExecuteNonQuery();
//				conn.QueryString = "EXEC IPPS_INITIATION_REQUEST_SAVE '" + Request.QueryString["regno"] + "', '"
//					+ LBL_SEQ.Text + "', '"
//					+ rdo_req_info.SelectedValue + "', '"
//					+ ddl_req_type.SelectedValue + "', '"
//					+ ddl_select_policy.SelectedValue + "', '"
//					+ ddl_pol_type.SelectedValue + "', '"
//					+ ddl_req_pur.SelectedValue + "', "
//					+ tool.ConvertDate(txt_tgl_tar_date.Text, DDL_BLN_tar_date.SelectedValue, TXT_THN_tar_date.Text) + ",'"
//					+ txt_remarks.Text + "'";

				PopulateRequest();
				ClearRequest();
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		private void BTN_clear_Click(object sender, System.EventArgs e)
		{
			ClearRequest();
			
			
		}

		private void ClearRequest()
		{
			ddl_select_policy.SelectedValue="";
			ddl_req_type.SelectedValue="";
			ddl_pol_type.SelectedValue="";
			ddl_req_pur.SelectedValue="";
			txt_tgl_tar_date.Text="";
			DDL_BLN_tar_date.SelectedValue="";
			TXT_THN_tar_date.Text = "";
			txt_remarks.Text="";
		}

		private void btn_update_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "exec IPPS_INITIATION_UPDATESTATUS '" +
					Request.QueryString["regno"] + "', '" +
					Session["UserID"].ToString() + "'";
				conn.ExecuteNonQuery();

				Response.Redirect("../../ListInitiation.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		private void rdo_req_info_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (rdo_req_info.SelectedValue == "1")
			{
				try
				{
					ddl_select_policy.SelectedValue = "";
				}
				catch
				{
					ddl_select_policy.SelectedValue = "";
				}
				ddl_select_policy.Enabled = false;
				
				try
				{
					ddl_req_type.SelectedValue = "01";
				}
				catch
				{
					ddl_req_type.SelectedValue = "";
				}
				ddl_req_type.Enabled = false;
			}
			else if (rdo_req_info.SelectedValue == "2")
			{
				try
				{
					ddl_select_policy.SelectedValue = "";
				}
				catch
				{
					ddl_select_policy.SelectedValue = "";
				}
				ddl_select_policy.Enabled = true;
				
				try
				{
					ddl_req_type.SelectedValue = "";
				}
				catch
				{
					ddl_req_type.SelectedValue = "";
				}
				ddl_req_type.Enabled = true;
			}
			else
			{
				try
				{
					ddl_select_policy.SelectedValue = "";
				}
				catch
				{
					ddl_select_policy.SelectedValue = "";
				}
				ddl_select_policy.Enabled = true;
				
				try
				{
					ddl_req_type.SelectedValue = "";
				}
				catch
				{
					ddl_req_type.SelectedValue = "";
				}
				ddl_req_type.Enabled = true;
			}
		}
	}
}
