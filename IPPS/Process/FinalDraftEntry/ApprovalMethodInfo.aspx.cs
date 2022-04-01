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


namespace SME.IPPS.Process.FinalDraftEntry
{
	/// <summary>
	/// Summary description for ApprovalMethodInfo.
	/// </summary>
	public partial class ApprovalMethodInfo : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				ResetPage();
			}

			ViewMenu();

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
			this.dg_list_request.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dg_list_request_ItemDataBound);

		}
		#endregion

		protected void BTN_Insert_Click(object sender, System.EventArgs e)
		{
			string mode="";
			if(Label1.Text=="")
			{
				mode="insert";
			}
			else
			{
				mode="update";
			}

			string notif="";

			if (DDL_REQUEST.SelectedValue=="")
			{
				notif=notif + "Request, ";
			}

			if (DDL_APP_METHOD.SelectedValue=="")
			{
				notif=notif + "Approval method, ";
			}

			if (TXT_APPBY.Text=="")
			{
				notif=notif + "Approved by, ";
			}

			if (DDL_COMNAME.SelectedValue=="")
			{
				notif=notif + "Committe Name ";
			}

			notif=notif + "tidak boleh kosong";

			if (DDL_REQUEST.SelectedValue!=""&&
				DDL_APP_METHOD.SelectedValue!=""&&
				TXT_APPBY.Text!=""&&
				DDL_COMNAME.SelectedValue!="")
			{
				string commdate=tool.ConvertDate(TXT_TGL_COM.Text,DDL_BLN_COM.SelectedValue,TXT_THN_COM.Text);
				ManipulateData(mode,DDL_REQUEST.SelectedValue,DDL_APP_METHOD.SelectedValue,DDL_COMNAME.SelectedValue,
					commdate,txt_remarks.Text,lbl_id.Text,lbl_name.Text,Label1.Text);
				ResetPage();
			}
			else
			{
				GlobalTools.popMessage(this, notif);
				return;	
			}

			
		}

		protected void BTN_clear_Click(object sender, System.EventArgs e)
		{
			ResetPage();
		}

		protected void btn_update_Click(object sender, System.EventArgs e)
		{
			conn.QueryString="select POLICYTYPE_DESC,req_seq from vw_ipps_requestlist where ipps_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			if(conn.GetRowCount()==dg_list_request.Items.Count)
			{
				conn.QueryString = "EXEC  IPPS_UPDATE_TRACK '"+  Request.QueryString["regno"] +
					"', '" +  "PP8.0" + 
					"', '" +  Session["UserID"].ToString() + 
					"', ''";
				conn.ExecuteQuery();
				Response.Redirect("WGList.aspx?mc="+Request.QueryString["mc"]+"&tc=" + Request.QueryString["tc"]);
			}
			else
			{
				GlobalTools.popMessage(this, "Data request forward to approval kurang");
				return;	
			}
			
		}

		protected void BTN_APPBY_Click(object sender, System.EventArgs e)
		{			
			if (Label1.Text=="")
			{
				Response.Write("<script language='javascript'>window.open('PopupCommittee.aspx?targetFormID=Form1&targetObjectID=TXT_APPBY" + 
					"&ippsregno=" + TXT_reference.Text + "&reqseq="+ DDL_REQUEST.SelectedValue +
                    "&apprseq=new&listcode="+ lbl_id.Text +"','ApprovalCommittee','status=no,scrollbars=no,width=500,height=700');</script>");
			}
			else
			{
				Response.Write("<script language='javascript'>window.open('PopupCommittee.aspx?targetFormID=Form1&targetObjectID=TXT_APPBY" + 
					"&ippsregno=" + TXT_reference.Text + "&reqseq="+ DDL_REQUEST.SelectedValue +
                    "&apprseq="+ Label1.Text +"&listcode="+ lbl_id.Text +"','ApprovalCommittee','status=no,scrollbars=no,width=500,height=700');</script>");
			}
		}

		private void DDL()
		{
			DDL_APP_METHOD.Items.Clear();
			DDL_BLN_COM.Items.Clear();
			DDL_COMNAME.Items.Clear();
			DDL_REQUEST.Items.Clear();

			DDL_BLN_COM.Items.Add(new ListItem("--Pilih--",""));
			DDL_APP_METHOD.Items.Add(new ListItem("--Pilih--",""));
			DDL_COMNAME.Items.Add(new ListItem("--Pilih--",""));
			DDL_REQUEST.Items.Add(new ListItem("--Pilih--",""));
				
			for(int i=1; i<=12; i++)
				DDL_BLN_COM.Items.Add(new ListItem(DateAndTime.MonthName(i,false), i.ToString()));

			conn.QueryString="select Approve_name,Approve_code from ipps_rfapprovalmethod where active='1'";
			conn.ExecuteQuery();

			for(int i=0; i<conn.GetRowCount(); i++)
				DDL_APP_METHOD.Items.Add(new ListItem(conn.GetFieldValue(i,0),conn.GetFieldValue(i,1)));


			conn.QueryString="select committee_name,committee_code from ipps_rfcommitteename where active='1'";
			conn.ExecuteQuery();

			for(int i=0; i<conn.GetRowCount(); i++)
				DDL_COMNAME.Items.Add(new ListItem(conn.GetFieldValue(i,0),conn.GetFieldValue(i,1)));


			conn.QueryString="select POLICYTYPE_DESC,req_seq from vw_ipps_requestlist where ipps_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			for(int i=0; i<conn.GetRowCount(); i++)
				DDL_REQUEST.Items.Add(new ListItem(conn.GetFieldValue(i,0),conn.GetFieldValue(i,1)));
			


		}

		private void ResetPage()
		{
			DDL();
			FillInfo();
			PopulateGrid();

			TXT_APPBY.Text="";
			DDL_APP_METHOD.SelectedValue="";
			DDL_BLN_COM.SelectedValue="";
			DDL_COMNAME.SelectedValue="";
			DDL_REQUEST.SelectedValue="";
			txt_remarks.Text="";
			TXT_TGL_COM.Text="";
			TXT_THN_COM.Text="";
			lbl_id.Text="";lbl_name.Text="";	
			Label1.Text="";
		}

		private void FillInfo()
		{ 
			conn.QueryString="select * from ipps_application where ipps_regno='" + Request.QueryString["regno"] + "'";
            conn.ExecuteQuery();		

			TXT_unit.Text=conn.GetFieldValue("UNIT_CODE");
			TXT_reference.Text=Request.QueryString["regno"];
			TXT_request_date.Text=tool.FormatDate(conn.GetFieldValue("init_date"));

			if (conn.GetFieldValue("ACQINFO")!="")
			{
				TXT_REMARK_APP.Text=conn.GetFieldValue("ACQINFO");
				tr_remark.Visible=true;
				tr_remark1.Visible=true;
			}
			else
			{
				tr_remark.Visible=false;
				tr_remark1.Visible=false;
			}
		}

		private void PopulateGrid()
		{
			conn.QueryString="exec IPPS_FINAL_DRAFT_ENTRY 'listtoapprove','" + Request.QueryString["regno"] + "','','','','','','','',''";			
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

		private void ManipulateData(string mode,string reqseq,string apprmethod, string commitcode,
			string commitdate,string remark, string listid,string listname, string seqapp)
		{
			
			if (mode=="insert")
			{
				conn.QueryString="select * from ipps_approval_info where ipps_regno='" +Request.QueryString["regno"]+ "' and req_seq='" +reqseq+ "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount()>0)
				{
					GlobalTools.popMessage(this, "Data approval method sudah ada");
					return;	
				}
			}
	
			conn.QueryString="exec IPPS_FINAL_DRAFT_ENTRY '" + mode + "','" + 
					Request.QueryString["regno"] + "','" +
					reqseq + "','" +
					apprmethod + "','" +
					commitcode + "'," +
					commitdate + ",'" +
					remark + "','" +
					listid + "','" +
					listname + "','" +
					seqapp + "'";			
				conn.ExecuteQuery();		

				if (mode=="edit")
				{
					txt_remarks.Text=conn.GetFieldValue("REMARK");
					TXT_TGL_COM.Text=tool.FormatDate_Day(conn.GetFieldValue("COMMITTEE_DATE"));
					TXT_THN_COM.Text=tool.FormatDate_Year(conn.GetFieldValue("COMMITTEE_DATE"));				
					DDL_BLN_COM.SelectedValue =tool.FormatDate_Month(conn.GetFieldValue("COMMITTEE_DATE"));				
					DDL_COMNAME.SelectedValue=conn.GetFieldValue("COMMITTEE_CODE");
					DDL_APP_METHOD.SelectedValue=conn.GetFieldValue("APPROVAL_METHOD");
					DDL_REQUEST.SelectedValue=conn.GetFieldValue("req_seq");
					getListIDName(reqseq,seqapp);
					Label1.Text=seqapp;
				}			
		}

		private void dg_list_request_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":					
					ManipulateData("edit",e.Item.Cells[2].Text.Trim(),"","","''","","","",e.Item.Cells[0].Text.Trim());					
					break;
				case "delete":
					ManipulateData("delete",e.Item.Cells[2].Text.Trim(),"","","''","","","",e.Item.Cells[0].Text.Trim());
					ResetPage();
					break;
			}
		}

		private void getListIDName(string reqseq,string seqapp)
		{
			lbl_id.Text="";lbl_name.Text="";TXT_APPBY.Text="";

			conn.QueryString="select APPROVED_BY,APPROVER_NAME from ipps_approval_info_user where IPPS_REGNO ='" + Request.QueryString["regno"] + "'" +
				" and req_seq='"+ reqseq +"' and appr_seq='" + seqapp + "'";

			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
			{
				for (int i =0; i<conn.GetRowCount();i++)
				{
					lbl_id.Text=lbl_id.Text+ "!" + conn.GetFieldValue(i,0);
					lbl_name.Text=lbl_name.Text+ "!" + conn.GetFieldValue(i,1);
					TXT_APPBY.Text=TXT_APPBY.Text + "," + conn.GetFieldValue(i,1);
				}
				lbl_id.Text=lbl_id.Text.Remove(0,1);
				lbl_name.Text=lbl_name.Text.Remove(0,1);
				TXT_APPBY.Text=TXT_APPBY.Text.Remove(0,1);
			}


		}

		protected void txt_temp_TextChanged(object sender, System.EventArgs e)
		{
			string [] temp = txt_temp.Text.Split(new char[] {'='});
			lbl_id.Text = temp[0];
			lbl_name.Text = temp[1];
			TXT_APPBY.Text = temp[2];
			txt_temp.Text="";
		}

		protected void TXT_APPBY_TextChanged(object sender, System.EventArgs e)
		{
			string [] temp = TXT_APPBY.Text.Split(new char[] {'='});
			lbl_id.Text = temp[0];
			lbl_name.Text = temp[1];
			TXT_APPBY.Text = temp[2];
			//txt_temp.Text="";
		
		}

		private void dg_list_request_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) 
			{
				e.Item.Cells[8].Text=tool.FormatDate(e.Item.Cells[8].Text);
			}
		}

		
	}
}
