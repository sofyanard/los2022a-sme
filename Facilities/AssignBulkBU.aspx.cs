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
using DMS.DBConnection;
using DMS.CuBESCore;
using Microsoft.VisualBasic;

namespace SME.Facilities
{
	/// <summary>
	/// Summary description for AssignBulkBU.
	/// </summary>
	public partial class AssignBulkBU : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				ViewData();
				FillDDLBranch();
			}

			BTN_ASSIGN.Attributes.Add("onclick","if(!assign()){return false;};");
			BTN_ASSIGNALL.Attributes.Add("onclick","if(!assignall()){return false;};");
		}

		private void FillDDLBranch()
		{
			DDL_BRANCHTO.Items.Clear();
			conn.QueryString = "EXEC ASSIGNMENTBULK_FILLBRANCH '" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();
			DDL_BRANCHTO.Items.Add(new ListItem("-- Select --",""));
			int row	= conn.GetRowCount();
			for (int i = 0 ; i < row;i++)
				DDL_BRANCHTO.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
		}

		private void FillDDLUser()
		{
			DDL_USERTO.Items.Clear();
			conn.QueryString = "SELECT * FROM VW_ASSIGNMENTBULK_FILLUSER WHERE BRANCH_CODE = '" + DDL_BRANCHTO.SelectedValue.Trim() + "' ORDER BY USERNAME";
			conn.ExecuteQuery();
			DDL_USERTO.Items.Add(new ListItem("-- Select --",""));
			int row	= conn.GetRowCount();
			for (int i = 0 ; i < row;i++)
				DDL_USERTO.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM VW_ASSIGNMENTBULK_LISTBU WHERE USERID = '" + Request.QueryString["uid"] + "' " + LBL_SORT.Text;
			conn.ExecuteQuery();
			
			DataTable dt = new DataTable();
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
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);
			this.DatGrd.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DatGrd_SortCommand);

		}
		#endregion

		protected void DDL_BRANCHTO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillDDLUser();
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i;
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "selectall":
					for (i = 0; i < DatGrd.PageSize; i++)
					{
						try
						{
							CheckBox cb = (CheckBox) DatGrd.Items[i].FindControl("CHK_ASSIGN");
							cb.Checked = true;
						} 
						catch {}
					}
					break;
				default:
					break;
			}
		}

		protected void BTN_ASSIGN_Click(object sender, System.EventArgs e)
		{
			if (DDL_USERTO.SelectedValue == "")
			{
				Tools.popMessage(this,"User assign to tidak boleh kosong!!");
				return;
			}

			try
			{
				for (int i=0; i<DatGrd.Items.Count; i++)
				{
					CheckBox chkassign = (CheckBox) DatGrd.Items[i].Cells[5].FindControl("CHK_ASSIGN");

					if (chkassign != null && chkassign.Checked == true)
					{
						conn.QueryString = "EXEC ASSIGNMENTBULK_PROCESSBU '" +
							DatGrd.Items[i].Cells[0].Text.Trim() + "', '" +
							Request.QueryString["uid"] + "', '" +
							DDL_USERTO.SelectedValue.Trim() + "'";
						conn.ExecuteNonQuery();
					}
				}

				ViewData();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
				Tools.popMessage(this,"Update Error!!");
			}
		}

		protected void BTN_ASSIGNALL_Click(object sender, System.EventArgs e)
		{
			if (DDL_USERTO.SelectedValue == "")
			{
				Tools.popMessage(this,"User assign to tidak boleh kosong!!");
				return;
			}

			try
			{
				conn.QueryString = "EXEC ASSIGNMENTBULK_PROCESSBUALL '" +
					Request.QueryString["uid"] + "', '" +
					DDL_USERTO.SelectedValue.Trim() + "'";
				conn.ExecuteNonQuery();

				ViewData();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
				Tools.popMessage(this,"Update Error!!");
			}
		}

		private void DatGrd_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			if (LBL_SORT.Text.IndexOf(e.SortExpression) != -1)
			{
				if (LBL_SORT.Text.IndexOf("ASC") != -1)
				{
					LBL_SORT.Text = LBL_SORT.Text.Replace("ASC","DESC");
				}
				else if (LBL_SORT.Text.IndexOf("DESC") != -1)
				{
					LBL_SORT.Text = LBL_SORT.Text.Replace("DESC","ASC");
				}
			}
			else
			{
				LBL_SORT.Text = " ORDER BY " + e.SortExpression + " ASC";
			}
			ViewData();
		}
	}
}
