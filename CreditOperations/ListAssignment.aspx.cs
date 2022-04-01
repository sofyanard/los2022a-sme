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

namespace SME.CreditOperation
{
	/// <summary>
	/// Summary description for ListAssignment.
	/// </summary>
	public partial class ListAssignment : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			string tc = "";//,mi = "";//, si = "";
			try 
			{
				tc = Request.QueryString["tc"];
				//mi = Request.QueryString["mi"];
				//si = Request.QueryString["si"];
			} 
			catch {}
			
			if (!IsPostBack)
			{
				bindData();
			}

			DatGrd.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
			BtnFind.Click += new EventHandler(BtnFind_Click);
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);

		}
		#endregion
		
		private void bindData()
		{
			string USERID = (string) Session["UserID"];

			System.Web.UI.WebControls.Image ImgAppr, ImgBI;
			DataTable dt = new DataTable();
			//conn.QueryString = "select * from VW_CO_ASSIGNMENTLIST where ap_currtrack='" + Request.QueryString["tc"] + "'";
			//conn.QueryString = "select distinct AP_REGNO, CU_REF, AP_SIGNDATE, AP_APPRSTATUS, CHECKBI, BS_COMPLETE, CU_NAME, LA_CREDITOPR, CU_RM from VW_CREDITOPR_ASSGN where LA_CREDITOPR ='" + Session["UserID"].ToString() + "' and (AP_APPRSTATUS <> '1' and AP_APPRSTATUS <> '3') ";
			//where AP_REGNO ='"+ Request.QueryString["regno"] + "'";

			if (TXT_AP_REGNO.Text.Trim() == "") 
			{
				//--- modif oleh Yudi
				conn.QueryString = "select distinct AP_REGNO, CU_REF, AP_SIGNDATE, AP_APPRSTATUS, CHECKBI, BS_COMPLETE, CU_NAME, LA_CREDITOPR, CU_RM " + 
					"from VW_CREDITOPR_ASSGN " + 
					//"where LA_CREDITOPR ='" + Session["UserID"].ToString() + 
					"where LA_CREDITOPR ='" + Session["BranchID"].ToString() + 
					"' and (AP_APPRSTATUS <> '1' and AP_APPRSTATUS <> '3') " + 
					" and LA_APPRSTATUS <> '7' " + 
					" and AP_REJECT = '0' and AP_CANCEL = '0' " + 
					"and (OFFICERSEQ IS NULL OR OFFICERSEQ in (select USERID from SCUSER " +
						"where SU_UPLINER = '" + USERID + "' and SU_ACTIVE = '1') or OFFICERSEQ = '" + USERID + "')";
			} 
			else 
			{
				conn.QueryString = "select distinct AP_REGNO, CU_REF, AP_SIGNDATE, AP_APPRSTATUS, CHECKBI, BS_COMPLETE, CU_NAME, LA_CREDITOPR, CU_RM " + 
					"from VW_CREDITOPR_ASSGN " + 
					//"where LA_CREDITOPR ='" + Session["UserID"].ToString() + 
					"where LA_CREDITOPR ='" + Session["BranchID"].ToString() + 
					"' and (AP_APPRSTATUS <> '1' and AP_APPRSTATUS <> '3') " + 
					" and AP_REJECT = '0' and AP_CANCEL = '0' " + 
					"and AP_REGNO = '" + TXT_AP_REGNO.Text.Trim() + "' " +
					"and (OFFICERSEQ IS NULL OR OFFICERSEQ in (select USERID from SCUSER " +
					"where SU_UPLINER = '" + USERID + "' and SU_ACTIVE = '1') or OFFICERSEQ = '" + USERID + "')";
			}

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
			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				ImgAppr	= (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[6].FindControl("IMG_LA_APPRSTATUS"); 
				ImgBI	= (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[9].FindControl("IMG_BS_COMPLETE");
				Label LblAppr	= (Label) DatGrd.Items[i].Cells[6].FindControl("LBL_LA_APPRSTATUS");
				Label LblBI		= (Label) DatGrd.Items[i].Cells[9].FindControl("LBL_BS_COMPLETE");
				LinkButton LbUpdate = (LinkButton) DatGrd.Items[i].Cells[10].FindControl("LB_UPDATESTATUS");
				
				conn.QueryString = "select count(*) from BI_STATUS where AP_REGNO = '"+DatGrd.Items[i].Cells[0].Text+"' and CU_REF = '"+DatGrd.Items[i].Cells[1].Text+"'";
				conn.ExecuteQuery();
				//if (DatGrd.Items[i].Cells[7].Text == "1")
				if (conn.GetFieldValue(0,0).ToString() != "0")
				{
					if (DatGrd.Items[i].Cells[8].Text == "2")
					{
						LblBI.Text = "Done";
						ImgBI.ImageUrl = "../image/Complete.gif";
					}
					else
					{
						LblBI.Text = "In Process";
						ImgBI.ImageUrl = "../image/UnComplete.gif";
					}
				}
				else
				{
					LblBI.Text = "Done";
					ImgBI.ImageUrl = "../image/Complete.gif";
				}
				
				conn.QueryString = "exec APPRAISAL_GETSTATUS '" + 
					DatGrd.Items[i].Cells[0].Text + "', '" + 
					Session["BranchID"].ToString() + "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue("CDONE").ToString() == "0")
				{
					LblAppr.Text = "Done";
					ImgAppr.ImageUrl = "../image/Complete.gif";
					LbUpdate.Visible = true;
				}
				else
				{
					LblAppr.Text = "In Process";
					ImgAppr.ImageUrl = "../image/UnComplete.gif";
					LbUpdate.Visible = false;
				}

				/*
				if (DatGrd.Items[i].Cells[5].Text == "2")
					LbUpdate.Visible = true;
				else
					LbUpdate.Visible = false;
				*/

			}
		}

		void Grid_Change(Object sender, DataGridPageChangedEventArgs e) 
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			bindData();	
			
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "View":								
					string tc = (string) Request.QueryString["tc"];
					Response.Redirect("MainCoAssignment.aspx?regno=" + e.Item.Cells[0].Text + "&curef=" + e.Item.Cells[1].Text+ "&tc="+tc+"&mc=" + Request.QueryString["mc"]);
					break;
				case "UpdateStatus":
					conn.QueryString = "select count(*) from listassignment where la_apprstatus <> '3' and ap_regno = '"+e.Item.Cells[0].Text+"'";
					conn.ExecuteQuery();
					if (conn.GetFieldValue(0,0) == "0")
					{
						conn.QueryString = "update application set ap_apprstatus = '1' where ap_regno='" + e.Item.Cells[0].Text + "'";
						conn.ExecuteNonQuery();
					}
					else
					{
						conn.QueryString = "update application set ap_apprstatus = '3' where ap_regno='" + e.Item.Cells[0].Text + "'";
						conn.ExecuteNonQuery();
					}
					bindData();
					break;
				default:
					break;
			}

		}

		private void BtnFind_Click(object sender, EventArgs e)
		{
			bindData();
		}
	}
}
 
  