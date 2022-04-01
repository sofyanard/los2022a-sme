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
	/// Summary description for SelfAssessmentInput.
	/// </summary>
	public partial class SelfAssessmentInput : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
		//protected Connection2 conn2;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			//conn2 = (Connection2) Session["Connection2"];

			if(!IsPostBack)
			{	
				TXT_ID.Text = "1";
				BTN_SAVE.Enabled = false;
				BTN_CLEAR.Enabled = false;
				BTN_SAVE_REMARK.Enabled = false;
				BTN_CLEAR_REMARK.Enabled =false;
				TR_QUESTION.Visible = false;

				DeptData();
				ViewData();
				CheckCutOff();
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
			this.DGR_SELF.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_SELF_PageIndexChanged);

		}
		#endregion
		
		private void CheckCutOff()
		{			
			try
			{
				conn.QueryString = "exec JWS_CEK_DATE '" + TXT_ID.Text + "'";
				conn.ExecuteNonQuery();
				return;
			}
			catch(Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				
				DDL_DEPT_NAME.Items.Clear();
				BTN_SAVE.Enabled = false;
				BTN_SAVE_REMARK.Enabled = false;
				BTN_CLEAR.Enabled = false;
				BTN_CLEAR_REMARK.Enabled = false;
				BTN_INSERT.Enabled = false;
				TR_QUESTION.Visible = false;
				TXT_SCORE.Text = "";
				TXT_CATEGORY.Text = "";
				TXT_REMARK.Text = "";
				TXT_REMARK.ReadOnly = true;
			}
		}
		
		private void DeptData()
		{
			DDL_DEPT_NAME.Items.Clear();

			DDL_DEPT_NAME.Items.Add(new ListItem("--Select--",""));

			conn.QueryString = "SELECT * FROM VW_JWS_SELF WHERE USERID='" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_DEPT_NAME.Items.Add(new ListItem(conn.GetFieldValue(i,5), conn.GetFieldValue(i,4)));
			}
		}
		
		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM VW_JWS_GROUP WHERE USERID='" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			TXT_NAME.Text =  conn.GetFieldValue(0,1);
			TXT_GROUPID.Text =  conn.GetFieldValue(0,2);
			TXT_GROUP.Text =  conn.GetFieldValue(0,3);
			
			conn.QueryString="EXEC FORMAT_DATE ''";
			conn.ExecuteQuery();

			TXT_DATE.Text = conn.GetFieldValue("TANGGAL");

			conn.QueryString="SELECT TOP 1 * FROM SELF_RESULT WHERE UPDATE_BY='" +
				Session["UserID"].ToString() + "' AND UPDATE_GROUPID='" +
				Session["BranchID"].ToString() + "' AND ACTIVE='1'";
			conn.ExecuteQuery();

			if(conn.GetRowCount() > 0)
			{
				try
				{
					DDL_DEPT_NAME.SelectedValue = conn.GetFieldValue("UPDATE_DEPTID");
				}
				catch
				{
					DDL_DEPT_NAME.SelectedValue = "";
				}

				BindDataQuestionSelf();
				DataScore();
				ViewRemark();
				BTN_SAVE.Enabled = true;
				BTN_CLEAR.Enabled = true;
				BTN_SAVE_REMARK.Enabled = true;
				BTN_CLEAR_REMARK.Enabled = true;
				TR_QUESTION.Visible = true;
			}
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			BTN_SAVE.Enabled = true;
			BTN_CLEAR.Enabled = false;
			BTN_SAVE_REMARK.Enabled = true;
			BTN_CLEAR_REMARK.Enabled = true;
			TR_QUESTION.Visible = true;

			BindDataQuestionSelf();
			DataScore();
			ViewRemark();
		}

		private void BindDataQuestionSelf()
		{
			conn.QueryString = "SELECT * FROM RF_SELF WHERE G_CODE='" + TXT_GROUPID.Text + "' AND D_CODE='" + DDL_DEPT_NAME.SelectedValue + "' AND STATUS='1' ORDER BY LANGKAH_SEQ ASC";
			conn.ExecuteQuery();

			if (conn.GetRowCount() == 0)
			{
				DataTable dt = new DataTable();
				dt = conn.GetDataTable().Copy();
				DGR_SELF.DataSource = dt;
				try 
				{
					DGR_SELF.DataBind();
				}
				catch 
				{
					DGR_SELF.CurrentPageIndex = 0;
					DGR_SELF.DataBind();
				}
			}

			if (conn.GetRowCount() > 0)
			{
				DataTable dt = new DataTable();
				dt = conn.GetDataTable().Copy();
				DGR_SELF.DataSource = dt;
				try 
				{
					DGR_SELF.DataBind();
				}
				catch 
				{
					DGR_SELF.CurrentPageIndex = 0;
					DGR_SELF.DataBind();
				}
			}

			for (int i=0;i<DGR_SELF.Items.Count;i++)
			{
				TextBox bukti = (TextBox) DGR_SELF.Items[i].Cells[8].FindControl("TXT_BUKTI");

				conn.QueryString = "SELECT BUKTI FROM SELF_RESULT WHERE SEQ#='" + DGR_SELF.Items[i].Cells[0].Text.Trim() + "' AND LANGKAH_SEQ#='" + 
					DGR_SELF.Items[i].Cells[3].Text.Trim() + "' AND UPDATE_BY='" +
					Session["UserID"].ToString() + "' AND UPDATE_DEPTID='" +
					DDL_DEPT_NAME.SelectedValue + "' AND ACTIVE='1'";
				conn.ExecuteQuery();

				bukti.Text = conn.GetFieldValue("BUKTI");
			}

			BindDataQuestionSelfNew();
		}

		private void BindDataQuestionSelfNew()
		{
			for (int i=0;i<DGR_SELF.Items.Count;i++)
			{
				RadioButtonList rblself = (RadioButtonList) DGR_SELF.Items[i].Cells[7].FindControl("RBL_SELF");

				conn.QueryString = "EXEC JWS_BUTTON_LIST ''";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtself = new DataTable();
					dtself = conn.GetDataTable().Copy();
					DataRow[] drs = dtself.Select();
					
					rblself.DataSource = dtself;
					rblself.DataValueField = "RB";
					rblself.DataTextField = "RB";
					rblself.DataBind();
				}

				int a = int.Parse(DGR_SELF.Items[i].Cells[3].Text.Trim());
				int b = int.Parse(DGR_SELF.Items[i].Cells[0].Text.Trim());

				conn.QueryString="SELECT * FROM SELF_RESULT WHERE SEQ#='" + b + "' AND UPDATE_BY='" + Session["UserID"].ToString() + "' AND UPDATE_DEPTID='" + DDL_DEPT_NAME.SelectedValue + "' AND LANGKAH_SEQ#='" + a + "' AND ACTIVE='1'";
				conn.ExecuteQuery();
				
				if(conn.GetRowCount() > 0)
				{
					rblself.SelectedValue = conn.GetFieldValue("SCORE");
				}
			}
		}
		
		private void DGR_SELF_SelectedIndexChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_SELF.CurrentPageIndex = e.NewPageIndex;
			BindDataQuestionSelf();
		}

		private void DGR_SELF_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_SELF.CurrentPageIndex = e.NewPageIndex;
			BindDataQuestionSelf();
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			for (int i=0; i<DGR_SELF.Items.Count; i++)
			{
				RadioButtonList rblself = (RadioButtonList) DGR_SELF.Items[i].Cells[7].FindControl("RBL_SELF");
				
				string bukti = "";

				try
				{
					conn.QueryString = "EXEC JWS_NEWRATING_UPDATEQUESTION '" +
						Session["UserID"].ToString() + "', '" +
						DGR_SELF.Items[i].Cells[0].Text.Trim() + "', '" + 
						DGR_SELF.Items[i].Cells[1].Text.Trim() + "', '" + 
						DGR_SELF.Items[i].Cells[2].Text.Trim() + "', '" +
						DGR_SELF.Items[i].Cells[3].Text.Trim() + "', '" +
						rblself.SelectedValue.Trim() + "','" +
						bukti + "'";
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

				TextBox tmp_bukti = (TextBox) DGR_SELF.Items[i].Cells[8].FindControl("TXT_BUKTI");

				conn.QueryString = "UPDATE SELF_RESULT SET BUKTI='" + tmp_bukti.Text + "' WHERE SEQ#='" + 
					DGR_SELF.Items[i].Cells[0].Text.Trim() + "' AND LANGKAH_SEQ#='" +
					DGR_SELF.Items[i].Cells[3].Text.Trim() + "' AND UPDATE_BY='" +
					Session["UserID"].ToString() + "' AND UPDATE_DEPTID='" +
					DDL_DEPT_NAME.SelectedValue + "' AND ACTIVE='1'";
				conn.ExecuteQuery();
			}

			BindDataQuestionSelf();
			DataScore();
		}

		private void DataScore()
		{
			conn.QueryString = "SELECT * FROM SELF_RESULT WHERE UPDATE_BY='" + Session["UserID"].ToString() + "' AND UPDATE_DEPTID='" + DDL_DEPT_NAME.SelectedValue + "' AND ACTIVE='1'";
			conn.ExecuteQuery();

			TXT_SCORE.Text = conn.GetFieldValue("T_SCORE").ToString();
			TXT_CATEGORY.Text = conn.GetFieldValue("CATEGORY").ToString();

			BTN_CLEAR.Enabled = true;
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{			
			conn.QueryString = "UPDATE SELF_RESULT SET ACTIVE='0' WHERE UPDATE_BY='" + Session["UserID"].ToString() + "' AND UPDATE_DEPTID='" + DDL_DEPT_NAME.SelectedValue + "'";
			conn.ExecuteQuery();
			conn.QueryString = "DELETE SELF_REPORTING WHERE UPDATE_ID='" + Session["UserID"].ToString() + "' AND G_CODE='" + TXT_GROUPID.Text + "' AND D_CODE='" + DDL_DEPT_NAME.SelectedValue + "'";
			conn.ExecuteQuery();
			
			ViewData();
			DeptData();
			BindDataQuestionSelf();
			TR_QUESTION.Visible = false;
			TXT_SCORE.Text = "";
			TXT_CATEGORY.Text = "";

			BTN_CLEAR.Enabled = false;

		}

		protected void DDL_DEPT_NAME_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TR_QUESTION.Visible = false;
			BTN_SAVE.Enabled = false;
			BTN_CLEAR.Enabled = false;
			BTN_SAVE_REMARK.Enabled = false;
			BTN_CLEAR_REMARK.Enabled = false;
			TXT_SCORE.Text = "";
			TXT_CATEGORY.Text = "";
			TXT_REMARK.Text = "";
		}

		protected void BTN_SAVE_REMARK_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC JWS_REMARK '1','" +
				Session["UserID"].ToString() + "','" +
				Session["BranchID"].ToString() + "','" +
				DDL_DEPT_NAME.SelectedValue + "','" +
				Session["UserID"].ToString() + "','" +
				TXT_REMARK.Text + "'";
			conn.ExecuteQuery();

			ViewRemark();
		}

		protected void BTN_CLEAR_REMARK_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "DELETE JIWASERVICE_REMARK WHERE [ID]='1' AND USERID='" + 
				Session["UserID"].ToString() + "' AND GROUPID='" + 
				Session["BranchID"].ToString() + "' AND DEPTID='" + 
				DDL_DEPT_NAME.SelectedValue + "' AND UPDATE_BY='" +
				Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			TXT_REMARK.Text = "";
		}

		private void ViewRemark()
		{
			conn.QueryString = "SELECT * FROM JIWASERVICE_REMARK WHERE [ID]='1' AND USERID='" +
				Session["UserID"].ToString() + "' AND GROUPID='" + 
				Session["BranchID"].ToString() + "' AND DEPTID='" + 
				DDL_DEPT_NAME.SelectedValue + "' AND UPDATE_BY='" +
				Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			TXT_REMARK.Text = conn.GetFieldValue("REMARK");
		}
	}
}
