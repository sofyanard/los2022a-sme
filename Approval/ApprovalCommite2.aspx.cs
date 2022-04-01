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

namespace SME.Approval
{
	/// <summary>
	/// Summary description for ApprovalCommite2.
	/// </summary>
	public partial class ApprovalCommite2 : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_REGNO.Text	= Request.QueryString["regno"];
				LBL_CUREF.Text	= Request.QueryString["curef"];
				LBL_TC.Text		= Request.QueryString["tc"];
				LBL_MC.Text		= Request.QueryString["mc"];
				
				fillDDLCommitee();
				fillDDLEmasAprv();

				viewData();
				viewEmasAprv();
			}

			ViewMenu();

			BTN_UPDATESTATUS.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1)){return false;}; if(!update()){return false;};");
			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");

            InitializeEvent();
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

		private void fillDDLCommitee()
		{
			GlobalTools.fillRefList(DDL_CURR_APRV, "SELECT * FROM VW_APPROVALCOMMITEE_FILLDDLCOMMITEE ORDER BY USERNAME", false, conn);
		}

		private void fillDDLEmasAprv()
		{
			GlobalTools.fillRefList(DDL_EMAS_BU, "SELECT * FROM VW_APPROVALCOMMITEE_FILLDDLEMASAPRV ORDER BY USERNAME", false, conn);
			GlobalTools.fillRefList(DDL_EMAS_RISK, "SELECT * FROM VW_APPROVALCOMMITEE_FILLDDLEMASAPRV ORDER BY USERNAME", false, conn);
		}

		private void viewData()
		{
			try 
			{
				conn.QueryString = "SELECT * FROM VW_APPROVALCOMMITEE_VIEWDATA WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' ORDER BY ADC_SEQ";
				conn.ExecuteQuery();
			
				DataTable dt = new DataTable();
				dt = conn.GetDataTable().Copy();
				DGR_APRVCOMMITEE.DataSource = dt;
				try 
				{
					DGR_APRVCOMMITEE.DataBind();
				} 
				catch 
				{
					DGR_APRVCOMMITEE.CurrentPageIndex = 0;
					DGR_APRVCOMMITEE.DataBind();
				}
			} 
			catch (Exception ex) 
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		private void viewEmasAprv()
		{
			try 
			{
				conn.QueryString = "EXEC APPROVALCOMMITEE_VIEWEMASAPRV '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				DDL_EMAS_BU.SelectedValue = conn.GetFieldValue("EMASBUAPRV");
				DDL_EMAS_RISK.SelectedValue = conn.GetFieldValue("EMASRISKAPRV");
				RBL_EMAS_BU.SelectedValue = conn.GetFieldValue("EMASBUDEC");
				RBL_EMAS_RISK.SelectedValue = conn.GetFieldValue("EMASRISKDEC");
			} 
			catch (Exception ex) 
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		private void clearEntryCommitee()
		{
			try {DDL_CURR_APRV.SelectedValue = "";}
			catch {}
			RBL_CURR_DEC.SelectedValue = "1";
		}

		private void saveToDatabase(string mode) 
		{
			try 
			{
				conn.QueryString	= "select * from rfinitial";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}
			string var_reject = conn.GetFieldValue("in_reject");

			try 
			{
				conn.QueryString = "select * from vw_currtrack where ap_regno = '"+ LBL_REGNO.Text + 
					"' and isnull(cp_decsta,'') <> '" + var_reject + "'";
				conn.ExecuteQuery();
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			DataTable dt_currtrack = new DataTable();
			dt_currtrack = conn.GetDataTable().Copy();
			
			for (int cnt = 0; cnt < dt_currtrack.Rows.Count;cnt++) 
			{
				conn.QueryString = "exec SP_APPROVAL_IN_COMMITEE '" + 
					LBL_REGNO.Text + "', '" + 
					dt_currtrack.Rows[cnt]["apptype"].ToString() + "', '" + 
					dt_currtrack.Rows[cnt]["productid"].ToString() + "', '" + 
					dt_currtrack.Rows[cnt]["PROD_SEQ"].ToString() + "', " + 
					tool.ConvertNull(RBL_EMAS_RISK.SelectedValue) + ", '" + 
					DDL_EMAS_BU.SelectedValue + "', '" + 
					RBL_EMAS_BU.SelectedValue + "', '" + 
					DDL_EMAS_RISK.SelectedValue + "', '" + mode + "'";
				conn.ExecuteNonQuery();				
			}			
		}

		private void saveToApprovalDecision() 
			//////////////////////////////////////////////////////////
		{
			///	menyimpan 1st approval dan 2nd approval
			///	ke table APPROVAL_DECISION
			///	untuk kebutuhan hosting ke eMAS
			///	
			conn.QueryString = "exec SP_APPROVAL_IN_COMMITEE2 '" + 
				DDL_EMAS_BU.SelectedValue + "', '" + 
				DDL_EMAS_RISK.SelectedValue + "', '" + 
				LBL_REGNO.Text + "'";
			conn.ExecuteNonQuery();
		}

        private void InitializeEvent()
        {
            this.BTN_ACQINFO.Click += new System.EventHandler(this.BTN_ACQINFO_Click);
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
			this.DGR_APRVCOMMITEE.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_APRVCOMMITEE_ItemCommand);
			this.DGR_APRVCOMMITEE.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_APRVCOMMITEE_PageIndexChanged);

		}
		#endregion

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC APPROVALCOMMITEE_INSERT '" +
					Request.QueryString["regno"] + "', '" + 
					DDL_CURR_APRV.SelectedValue.Trim() + "', '" + 
					RBL_CURR_DEC.SelectedValue.Trim() + "'";
				conn.ExecuteQuery();
				viewData();
				clearEntryCommitee();
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

		private void DGR_APRVCOMMITEE_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC APPROVALCOMMITEE_DELETE '" +
					Request.QueryString["regno"] + "', '" + 
					e.Item.Cells[0].Text + "', '" + 
					e.Item.Cells[1].Text + "'";
				conn.ExecuteQuery();
				viewData();
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

		private void DGR_APRVCOMMITEE_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_APRVCOMMITEE.CurrentPageIndex = e.NewPageIndex;
			viewData();
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC APPROVALCOMMITEE_SAVEEMASAPRV '" +
					Request.QueryString["regno"] + "', '" + 
					DDL_EMAS_BU.SelectedValue + "', '" + 
					DDL_EMAS_RISK.SelectedValue + "', '" + 
					RBL_EMAS_BU.SelectedValue + "', '" + 
					RBL_EMAS_RISK.SelectedValue + "'";
				conn.ExecuteQuery();
				viewEmasAprv();
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

        public string popUp = "";
        private void BTN_ACQINFO_Click(object sender, System.EventArgs e)
		{
			//Response.Write("<script for=window event=onload language='javascript'>PopupPage('AcqInfo.aspx?regno=" + LBL_REGNO.Text + "&curef=" + LBL_CUREF.Text + "&aprv=CRM&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>");
            popUp = "<script for=window event=onload language='javascript'>PopupPage('AcqInfo.aspx?regno=" + LBL_REGNO.Text + "&curef=" + LBL_CUREF.Text + "&aprv=BOD&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>";
		}

		protected void TXT_TEMP_TextChanged(object sender, System.EventArgs e)
		{
			if (TXT_TEMP.Text != "") 
			{
				string msg = "";
				msg = "Application acquire information from " + TXT_TEMP.Text + " !";
				Response.Redirect("ListApprovalCommitee.aspx?mc="+Request.QueryString["mc"]+"&tc=" + Request.QueryString["tc"]+"&msg="+msg);
			}
		}

		protected void BTN_UPDATESTATUS_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC APPROVALCOMMITEE_UPDATESTATUS '" + 
					Request.QueryString["regno"] + "', '" +
					Session["UserID"].ToString() + "', '" +
					DDL_EMAS_BU.SelectedValue + "', '" +
					RBL_EMAS_BU.SelectedValue + "', '" +
					DDL_EMAS_RISK.SelectedValue + "', '" +
					RBL_EMAS_RISK.SelectedValue + "'";
				conn.ExecuteQuery();

				string msg = "Application is " + RBL_EMAS_RISK.SelectedItem.Text;
				Response.Redirect("ListApprovalCommitee.aspx?msg="+msg+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"]);
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
	}
}
