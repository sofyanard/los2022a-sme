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
using DMS.BlackList;

namespace SME.IPPS.Process.InitiationValidation
{
	/// <summary>
	/// Summary description for ValidationInfo.
	/// </summary>
	public partial class ValidationInfo : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			//conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../../SME/Restricted.aspx");

			ViewMenu();

			if(!IsPostBack)
			{
				ViewData();
				PopulateRequest();
				FillDDL();
			}
			
			PopulateReview();
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode ='" + Request.QueryString["mc"] + "'";
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
			DGR_REQUEST.DataSource = dt;
			try 
			{
				DGR_REQUEST.DataBind();
			} 
			catch 
			{
				DGR_REQUEST.CurrentPageIndex = 0;
				DGR_REQUEST.DataBind();
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
			ddl_request_purpose.Items.Add(new ListItem("--Select--",""));
			conn.QueryString="select requestpurpose_code, requestpurpose_desc from ipps_rfrequestpurpose where active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				ddl_request_purpose.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			//result
			ddl_result.Items.Add(new ListItem("--Select--",""));
			conn.QueryString="select validationresult_code, validationresult_desc from ipps_rfvalidationresult where active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				ddl_result.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			//re-assign
			ddl_reassign.Items.Add(new ListItem("--Select--",""));
			conn.QueryString="select userid, su_fullname from scuser where groupid in (select groupid from grpaccessmenu where menucode = 'IPPS01011')";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				ddl_reassign.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			//request
			ddl_request.Items.Add(new ListItem("--Select--",""));
			conn.QueryString="EXEC IPPS_REQUESTLIST '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				ddl_request.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

		}

		
		private void PopulateReview()
		{
			conn.QueryString = "EXEC  IPPS_Get_List_Unit_Full '"+  Request.QueryString["regno"] + "'";
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
			this.DGR_REQUEST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_REQUEST_ItemCommand);
			this.DGR_REQUEST.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGR_REQUEST_ItemDataBound);
			this.dg_list_request.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dg_list_request_ItemCommand);
			this.dg_list_request.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dg_list_request_EditCommand);

		}
		#endregion

		private void DGR_REQUEST_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item )
			{
				System.Web.UI.WebControls.LinkButton nama=(System.Web.UI.WebControls.LinkButton)e.Item.FindControl("link"); 
				nama.Text=e.Item.Cells[3].Text;
			}
		}

		private void DGR_REQUEST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "link":	
					conn.QueryString = "select * from IPPS_REQUEST where REQ_SEQ='" + e.Item.Cells[1].Text + "'" + "and IPPS_REGNO='" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					//Isi request info
					ddl_select_policy.SelectedValue = conn.GetFieldValue("EXISTING_POLICY");
					
					if(conn.GetFieldValue("REQ_ISNEW")=="1")
					{
						ddl_req_type.Items.Add(new ListItem("New","n"));
						ddl_req_type.SelectedValue = "n";
					}
					else
						ddl_req_type.SelectedValue = conn.GetFieldValue("REQUEST_TYPE");
					
					ddl_pol_type.SelectedValue = conn.GetFieldValue("POLICY_TYPE");
					ddl_request_purpose.SelectedValue = conn.GetFieldValue("REQUEST_PURPOSE");
					txt_Impl_Target_Date.Text = tool.FormatDate(conn.GetFieldValue("IMPLEMENT_TERGET_DATE"));
					txt_remarks.Text = conn.GetFieldValue("REMARK");
					
					break;
			}
		}

		protected void btn_accept_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC  IPPS_VALIDATION_UPDATE '"+  Request.QueryString["regno"]+
									"', '" +  Session["UserID"].ToString()+ 
									"', '" + ddl_result.SelectedValue + "'";
				conn.ExecuteQuery();

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

		protected void btn_process_Click(object sender, System.EventArgs e)
		{
			//Response.Write("<script for=window event=onload language='javascript'>PopupPage('AcqInfo.aspx?lmsreg=" + Request.QueryString["lmsreg"] + "&tc=" + Request.QueryString["tc"] + "&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>");
		
			Response.Write("<script for=window event=onload language='javascript'>PopupPage('AcqInfo.aspx?regno=" + Request.QueryString["regno"] + "&nextuser=" + ddl_reassign.SelectedValue + "&tcnext=PP1.1&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>");
		}

		protected void TXT_TEMP_TextChanged(object sender, System.EventArgs e)
		{
			if (TXT_TEMP.Text != "") 
			{
				string msg = "";
				msg = TXT_TEMP.Text;
				Response.Redirect("InitiationList.aspx?mc="+Request.QueryString["mc"]+"&tc=" + Request.QueryString["tc"]
					+"&msg=" + msg);
			}
		}

		protected void btn_search_unit_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('PopupUnit.aspx?targetFormID=Form1&targetObjectID1=txt_unit_review" +
						   "&ippsregno=" + TXT_reference.Text + "&reqseq="+ ddl_request.SelectedValue +"','SearchUnitCode','status=no,scrollbars=yes,width=500,height=700');</script>");

//			Response.Write("<script language='javascript'>window.open('PopupUnit.aspx?targetFormID=Form1&targetObjectID1=txt_unit_review" +
//				"&ippsregno="+TXT_reference.Text+"&reqseq="+ddl_request.SelectedValue+"','SearchUnitCode','status=no,scrollbars=yes,width=500,height=700');</script>");
		}


		protected void BTN_save_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC  IPPS_Input_to_Review '"+  "delete" +
					"', '" +  Request.QueryString["regno"] +
					"', '" +  ddl_request.SelectedValue + 
					"', '" +  lbl_list_code.Text + "'";
				conn.ExecuteQuery();

				conn.QueryString = "EXEC  IPPS_Input_to_Review '"+  "insert" +
					"', '" +  Request.QueryString["regno"] +
					"', '" +  ddl_request.SelectedValue + 
					"', '" +  lbl_list_code.Text + "'";
				conn.ExecuteQuery();

				PopulateReview();
				ddl_request.SelectedValue="";
				txt_unit_review.Text="";
				lbl_list_code.Text="";

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

		protected void btn_update_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC  IPPS_UPDATE_TRACK '"+  Request.QueryString["regno"] +
					"', '" +  "PP3.0" + 
					"', '" +  Session["UserID"].ToString() + 
					"', ''";
				conn.ExecuteQuery();
				Response.Redirect("InitiationList.aspx?mc="+Request.QueryString["mc"]+"&tc=" + Request.QueryString["tc"]);
									

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

		private void dg_list_request_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			
		}

		protected void TXT_UNITTEMP_TextChanged(object sender, System.EventArgs e)
		{
			string [] temp = TXT_UNITTEMP.Text.Split(new char[] {'='});
			lbl_list_code.Text = temp[0];
			txt_unit_review.Text = temp[1];

		}

		protected void txt_unit_review_TextChanged(object sender, System.EventArgs e)
		{
			string [] temp = txt_unit_review.Text.Split(new char[] {'='});
			lbl_list_code.Text = temp[0];
			txt_unit_review.Text = temp[1];
		}

		private void dg_list_request_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":	
					ddl_request.SelectedValue = e.Item.Cells[0].Text;
					txt_unit_review.Text = e.Item.Cells[3].Text;
					
					string listCode="";
					conn.QueryString = "EXEC  IPPS_Input_to_Review '"+  "fill_LblCode" +
						"', '" +  Request.QueryString["regno"] +
						"', '" +  ddl_request.SelectedValue + 
						"', ''";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						listCode = listCode + conn.GetFieldValue(i,0)+ ",";

					listCode=listCode.Substring(0,listCode.Length-1);
					lbl_list_code.Text = listCode;
			
					break;

				case "delete":
					conn.QueryString = "EXEC  IPPS_Input_to_Review '"+  "delete" +
						"', '" +  Request.QueryString["regno"] +
						"', '" +  ddl_request.SelectedValue + 
						"', '" +  lbl_list_code.Text + "'";
					conn.ExecuteQuery();
					break;
			}
		}

		protected void BTN_clear_Click(object sender, System.EventArgs e)
		{
			ddl_request.SelectedValue="";
			txt_unit_review.Text="";
			lbl_list_code.Text="";
		}

		
	}
}
