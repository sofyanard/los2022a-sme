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

namespace SME.JiwaService
{
	/// <summary>
	/// Summary description for DetailScoring.
	/// </summary>
	public partial class DetailScoring : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if(!IsPostBack)
			{	
				ViewData();
				ViewRemark();
			}
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM CUSTOMER_RESULT WHERE PIC_UNIT='" +
				Request.QueryString["userid"] + "' AND UPDATE_UNIT='" + 
				Session["BranchID"].ToString() + "' AND D_CODE='" +
				Request.QueryString["dc"] + "' AND ACTIVE='1'";
			conn.ExecuteQuery();

			if(conn.GetRowCount() > 0)
			{
				BindDataQuestionScore();
				DataScore();
			}
			else
			{
				BindDataQuestionScore();
			}
		}

		private void BindDataQuestionScore()
		{
			conn.QueryString="SELECT * FROM RF_CUSTOMER WHERE G_CODE='" + Request.QueryString["gc"] + "' AND D_CODE='" + Request.QueryString["dc"] + "' AND STATUS='1'";
			conn.ExecuteQuery();			
			
			if (conn.GetRowCount() > 0)
			{
				DataTable dt = new DataTable();
				dt = conn.GetDataTable().Copy();
				DGR_SCR.DataSource = dt;
				try 
				{
					DGR_SCR.DataBind();
				}
				catch 
				{
					DGR_SCR.CurrentPageIndex = 0;
					DGR_SCR.DataBind();
				}
			}
			BindDataQuestionScoreNew();
		}

		private void BindDataQuestionScoreNew()
		{
			for (int i=0;i<DGR_SCR.Items.Count;i++)
			{
				RadioButtonList rblscore = (RadioButtonList) DGR_SCR.Items[i].Cells[2].FindControl("RBL_SCORE");

				conn.QueryString = "EXEC JWS_BUTTON_LIST2 ''";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtscore = new DataTable();
					dtscore = conn.GetDataTable().Copy();
					DataRow[] drs = dtscore.Select();
					
					rblscore.DataSource = dtscore;
					rblscore.DataValueField = "RB_NILAI";
					rblscore.DataTextField = "RB_ID";
					rblscore.DataBind();
				}
				
				/*Menampilkan data yang belum selesai*/
				int a = int.Parse(DGR_SCR.Items[i].Cells[0].Text.Trim());

				conn.QueryString = "SELECT * FROM CUSTOMER_RESULT WHERE PIC_UNIT='" +
					Request.QueryString["userid"] + "' AND UPDATE_UNIT='" + 
					Session["BranchID"].ToString() + "' AND D_CODE='" +
					Request.QueryString["dc"] + "' AND ACTIVE='1' AND SEQ_PERTANYAAN='" + a + "'";
				conn.ExecuteQuery();

				if(conn.GetRowCount() > 0)
				{
					rblscore.SelectedValue = conn.GetFieldValue("SCORE");
				}
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
			this.DGR_SCR.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_SCR_PageIndexChanged);

		}
		#endregion

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			string a;

			for (int i=0; i<DGR_SCR.Items.Count; i++)
			{
				RadioButtonList rblscore = (RadioButtonList) DGR_SCR.Items[i].Cells[2].FindControl("RBL_SCORE");

				if(rblscore.SelectedValue == "")
				{
					a = "null";
				}
				else
				{
					a = rblscore.SelectedValue.ToString();
				}

				try
				{
					/*Insert Data*/
					conn.QueryString = "EXEC JWS_SCORING_INTERNAL '" +
						Request.QueryString["gc"] + "','" +
						Request.QueryString["dc"] + "','" +
						Request.QueryString["userid"] + "','" +
						DGR_SCR.Items[i].Cells[0].Text.Trim() + "','" +
						DGR_SCR.Items[i].Cells[1].Text.Trim() + "'," +
						a + ",'"+
						Session["UserID"].ToString() + "','" +
						Session["BranchID"].ToString() + "'";
					conn.ExecuteNonQuery();
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

			BindDataQuestionScore();
			DataScore();
		}

		private void DataScore()
		{
			conn.QueryString = "SELECT TOP 1 * FROM CUSTOMER_RESULT WHERE PIC_UNIT='" + 
				Request.QueryString["userid"] + "' AND UPDATE_UNIT='" + 
				Session["BranchID"].ToString() + "' AND D_CODE='" +
				Request.QueryString["dc"] + "' AND ACTIVE='1' ORDER BY SEQ# DESC";
			conn.ExecuteQuery();

			TXT_SCORE.Text = conn.GetFieldValue("T_SCORE").ToString();
			TXT_CATEGORY.Text = conn.GetFieldValue("CATEGORY").ToString();
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{
			conn.QueryString = "UPDATE CUSTOMER_RESULT SET ACTIVE='0' WHERE PIC_UNIT='" +
				Request.QueryString["userid"] + "' AND UPDATE_UNIT='" + 
				Session["BranchID"].ToString() + "' AND D_CODE='" +
				Request.QueryString["dc"] + "'";
			conn.ExecuteQuery();

			conn.QueryString = "DELETE JWS_HISTORY_RESULT WHERE PIC=''" +
				" AND USERID='" + Session["BranchID"].ToString() + "' AND G_CODE='" +
				Request.QueryString["gc"] + "' AND D_CODE='" + Request.QueryString["dc"] + "'";
			conn.ExecuteQuery();

			conn.QueryString = "DELETE CUSTOMER_REPORTING WHERE G_CODE='" + Request.QueryString["gc"] + "' AND D_CODE='" + Request.QueryString["dc"] + "' AND UPDATE_BY='" + Session["UserID"].ToString() + "' AND ACTIVE='1'";
			conn.ExecuteQuery();
			
			BindDataQuestionScore();
			TXT_SCORE.Text = "";
			TXT_CATEGORY.Text = "";
		}

		protected void DGR_SCR_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void DGR_SCR_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_SCR.CurrentPageIndex = e.NewPageIndex;
			BindDataQuestionScore();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("InternalCustomerInput.aspx?mc=" + Request.QueryString["mc"] + "&exist=1");
		}

		protected void BTN_SAVE_REMARK_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC JWS_REMARK '2','" +
				Request.QueryString["userid"] + "','" +
				Request.QueryString["gc"] + "','" +
				Request.QueryString["dc"] + "','" +
				Session["BranchID"].ToString() + "','" +
				TXT_REMARK.Text + "'";
			conn.ExecuteQuery();

			ViewRemark();
		}

		protected void BTN_CLEAR_REMARK_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "DELETE JIWASERVICE_REMARK WHERE [ID]='2' AND USERID='" + 
				Request.QueryString["userid"] + "' AND GROUPID='" +
				Request.QueryString["gc"] + "' AND DEPTID='" +
				Request.QueryString["dc"] + "' AND UPDATE_BY='" +
				Session["BranchID"].ToString() + "'";
			conn.ExecuteQuery();

			TXT_REMARK.Text = "";
		}

		private void ViewRemark()
		{
			conn.QueryString = "SELECT * FROM JIWASERVICE_REMARK WHERE [ID]='2' AND USERID='" +
				Request.QueryString["userid"] + "' AND GROUPID='" +
				Request.QueryString["gc"] + "' AND DEPTID='" +
				Request.QueryString["dc"] + "' AND UPDATE_BY='" +
				Session["BranchID"].ToString() + "'";
			conn.ExecuteQuery();

			TXT_REMARK.Text = conn.GetFieldValue("REMARK");
		}

	}
}
