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

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for NasabahGroupInfo.
	/// </summary>
	public partial class RFReasonParamAppr : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.Button updatestatus;
		protected Tools tool = new Tools();
		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack) 
			{				
				LBL_PARAMNAME.Text = "RFREASON";
				LBL_ACTIVE.Text = "1";	//default condition

				fillDDLCollType();
			}

			DGRequest.PageIndexChanged +=new DataGridPageChangedEventHandler(DGRequest_PageIndexChanged);
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
			this.DGRequest.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGRequest_ItemCommand);

		}
		#endregion

		private void fillDDLCollType() 
		{
			conn.QueryString = "select * from VW_RFREASONTYPE";
			conn.ExecuteQuery();

			DDL_REASONTYPE.Items.Clear();
			DDL_REASONTYPE.Items.Add(new ListItem("- PILIH -",""));
			for(int i=0; i<conn.GetRowCount(); i++) 
			{
				DDL_REASONTYPE.Items.Add(new ListItem(conn.GetFieldValue(i, "REASONTYPEDESC"), conn.GetFieldValue(i, "REASONTYPEID")));
			}
		}

		private void viewPendingData(string REASONTYPE) 
		{
			conn.QueryString = "select * from VW_PARAM_GENERAL_PENDING_RFREASON where REASONTYPE = '"+REASONTYPE+"'";
			conn.ExecuteQuery();			

			DataTable dt = new DataTable();			
			dt.Columns.Add(new DataColumn("ID"));
			dt.Columns.Add(new DataColumn("DESC"));
			dt.Columns.Add(new DataColumn("REASONTYPEID"));
			dt.Columns.Add(new DataColumn("REASONTYPEDESC"));
			dt.Columns.Add(new DataColumn("PENDINGSTATUS"));
			dt.Columns.Add(new DataColumn("PENDING_STATUS"));			

			DataRow dr;
			for(int i = 0; i < conn.GetDataTable().Rows.Count; i++) 
			{
				dr = dt.NewRow();
				dr[0] = conn.GetFieldValue(i, "REASONID");
				dr[1] = conn.GetFieldValue(i, "REASONDESC");
				dr[2] = conn.GetFieldValue(i, "REASONTYPE");
				dr[3] = conn.GetFieldValue(i, "REASONTYPEDESC");
				dr[4] = conn.GetFieldValue(i, "PENDINGSTATUS");
				dr[5] = getPendingStatus(conn.GetFieldValue(i,"PENDINGSTATUS"));
				dt.Rows.Add(dr);
			}

			DGRequest.DataSource = new DataView(dt);
			try
			{
				DGRequest.DataBind();
			}
			catch
			{
				DGRequest.CurrentPageIndex = DGRequest.PageCount - 1;
				DGRequest.DataBind();
			}
		}

		private string getPendingStatus(string saveMode) 
		{
			string status = "";			
			switch (saveMode)
			{
				case "0":
					status = "Update";
					break;
				case "1":
					status = "Insert";
					break;
				case "2":
					status = "Delete";
					break;
				default:
					status = "";
					break;
			}
			return status;
		}

		private string getColumnKey() 
		{
			return LBL_ID.Text.Trim();
		}
		
		private string getColumnDesc()
		{
			return LBL_DESC.Text.Trim();
		}

		private void DGRequest_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			DGRequest.CurrentPageIndex = e.NewPageIndex;			
			viewPendingData(DDL_REASONTYPE.SelectedValue);
		}

		private void performRequest(int row)
		{
			try 
			{
				string id = DGRequest.Items[row].Cells[0].Text.Trim();
				executeApproval(id, "1");
			} 
			catch {}
		}

		private void deleteData(int row)
		{
			try 
			{
				string id = DGRequest.Items[row].Cells[0].Text.Trim();
				executeApproval(id, "0");
			} 
			catch {}
		}

		private void executeApproval(string id, string approvalFlag) 
		{
			conn.QueryString = "exec PARAM_GENERAL_RFREASON_APPR '" + id + "','"+ approvalFlag +"'";
			try 
			{
				conn.ExecuteNonQuery();
			} 
			catch {
				Tools.popMessage(this, "Error Stored-Procedure !");
				return;
			}
		}

		protected void BTN_SUBMIT_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < DGRequest.Items.Count; i++)
			{
				try
				{
					RadioButton rbA = (RadioButton) DGRequest.Items[i].FindControl("rdo_Approve"),
						        rbR = (RadioButton) DGRequest.Items[i].FindControl("rdo_Reject");
					if (rbA.Checked)
					{
						performRequest(i);
					}
					else if (rbR.Checked)
					{
						deleteData(i);
					}
				} 
				catch {}
			}
			viewPendingData(DDL_REASONTYPE.SelectedValue);
		}

		private void DGRequest_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i;
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "allAppr":
					for (i = 0; i < DGRequest.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DGRequest.Items[i].FindControl("rdo_Approve"),
								rbB = (RadioButton) DGRequest.Items[i].FindControl("rdo_Reject"),
								rbC = (RadioButton) DGRequest.Items[i].FindControl("rdo_Pending");
							rbB.Checked = false;
							rbC.Checked = false;
							rbA.Checked = true;
						} 
						catch {}
					}
					break;
				case "allRejc":
					for (i = 0; i < DGRequest.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DGRequest.Items[i].FindControl("rdo_Approve"),
								rbB = (RadioButton) DGRequest.Items[i].FindControl("rdo_Reject"),
								rbC = (RadioButton) DGRequest.Items[i].FindControl("rdo_Pending");
							rbA.Checked = false;
							rbC.Checked = false;
							rbB.Checked = true;
						} 
						catch {}
					}
					break;
				case "allPend":
					for (i = 0; i < DGRequest.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DGRequest.Items[i].FindControl("rdo_Approve"),
								rbB = (RadioButton) DGRequest.Items[i].FindControl("rdo_Reject"),
								rbC = (RadioButton) DGRequest.Items[i].FindControl("rdo_Pending");
							rbA.Checked = false;
							rbB.Checked = false;
							rbC.Checked = true;
						} 
						catch {}
					}
					break;
				default:
					// Do nothing.
					break;
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/Maintenance/Parameters/GeneralParamApproval.aspx?mc="+Request.QueryString["mc"]);
		}

		protected void DDL_REASONTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			viewPendingData(DDL_REASONTYPE.SelectedValue);
		}
	}		
}
