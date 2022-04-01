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
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;

namespace SME.DCM.EnhancementErrorChecking.DataErrorCheckModel.Maker
{
	/// <summary>
	/// Summary description for ErrorRuleParam.
	/// </summary>
	public partial class ErrorRuleParam : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				FillDDLType();
				DDL_FIELD.Items.Add(new ListItem("--Select--", ""));
				FillDDLPage();
				DDL_CONTROL.Items.Add(new ListItem("--Select--", ""));
				GenerateCode();
				ViewExisitingParameter();
				ViewRequestingParameter();
			}
		}

		private void FillDDLType()
		{
			DDL_DATA_TYPE.Items.Clear();
			DDL_DATA_TYPE.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT CODE, CODE + ' - ' + DESCRIPTION AS [DESC] FROM VW_DCM_RF_DATA_TYPE";
			conn.ExecuteQuery();
			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_DATA_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i, "DESC"), conn.GetFieldValue(i, "CODE")));
			}
		}

		private void FillDDLField()
		{
			DDL_FIELD.Items.Clear();
			DDL_FIELD.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT TABLE_LINK FROM VW_DCM_RF_DATA_TYPE WHERE CODE = '" + DDL_DATA_TYPE.SelectedValue + "'";
			conn.ExecuteQuery();
			
			string table = conn.GetFieldValue("TABLE_LINK");

			conn2.QueryString = "SELECT CODE, CODE + ' - ' + FIELDSDESCRIPTION AS FIELD FROM " + table ;
			conn2.ExecuteQuery();

			for(int i = 0; i < conn2.GetRowCount(); i++)
			{
				DDL_FIELD.Items.Add(new ListItem(conn2.GetFieldValue(i, "FIELD"), conn2.GetFieldValue(i, "CODE")));
			}
		}

		private void FillDDLPage()
		{
			DDL_PAGE.Items.Clear();
			DDL_PAGE.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT PAGE_ID, PAGE_NM FROM DCM_TABLE_PAGE WHERE ACTIVE = '1'";
			conn.ExecuteQuery();
			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_PAGE.Items.Add(new ListItem(conn.GetFieldValue(i, "PAGE_NM"), conn.GetFieldValue(i, "PAGE_ID")));
			}
		}

		private void FillDDLCtrl()
		{
			DDL_CONTROL.Items.Clear();
			DDL_CONTROL.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT CONTROL_ID, CONTROL_NM FROM DCM_PAGE_CONTROL WHERE PAGE_ID = '" + DDL_PAGE.SelectedValue + "' AND ACTIVE = '1'";
			conn.ExecuteQuery();
			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_CONTROL.Items.Add(new ListItem(conn.GetFieldValue(i, "CONTROL_NM"), conn.GetFieldValue(i, "CONTROL_ID")));
			}
		}

		private void GenerateCode()
		{
			conn.QueryString = "SELECT ISNULL(MAX(SEQ),0)+1 AS SEQ FROM( SELECT SEQ FROM DCM_PAGE_CONTROL_ERROR UNION SELECT SEQ FROM DCM_PAGE_CONTROL_ERROR_TEMP)A";
			conn.ExecuteQuery();

			LBL_SEQ.Text = conn.GetFieldValue("SEQ");
		}

		private void ViewExisitingParameter()
		{
			BindData("DGR_DATA_EXIST", "SELECT * FROM VW_DCM_PAGE_CONTROL_ERROR_PARAM ORDER BY SEQ");
		}

		private void ViewRequestingParameter()
		{
			BindData("DGR_DATA_REQUEST", "SELECT * FROM VW_DCM_PAGE_CONTROL_ERROR_PARAM_TEMP ORDER BY SEQ");
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();

				System.Data.DataTable dt = new System.Data.DataTable();
				dt = conn.GetDataTable().Copy();

				System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);
				dg.DataSource = dt;

				try
				{
					dg.DataBind();
				}
				catch
				{
					dg.CurrentPageIndex = dg.PageCount - 1;	
					dg.DataBind();
				}

				conn.ClearData();

				if(dg.ID == "DGR_DATA_EXIST")
				{
					MakeVisibleDeleteUndelete(dg);
				}
			}
		}

		private void MakeVisibleDeleteUndelete(System.Web.UI.WebControls.DataGrid dg)
		{
			for(int i=0; i< dg.Items.Count; i++)
			{
				string a = dg.Items[i].Cells[10].Text.ToString();
				int num = int.Parse(dg.Items[i].Cells[10].Text.ToString());

				LinkButton toBeHidden;
				if(num == 1)
				{
					toBeHidden = ((LinkButton)dg.Items[i].Cells[11].FindControl("LNK_UNDELETE"));
					toBeHidden.Visible = false;
				}
				else if(num == 0)
				{
					toBeHidden = ((LinkButton)dg.Items[i].Cells[11].FindControl("LNK_DELETE"));
					toBeHidden.Visible = false;
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
			this.DGR_DATA_EXIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_DATA_EXIST_ItemCommand);
			this.DGR_DATA_EXIST.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_DATA_EXIST_PageIndexChanged);
			this.DGR_DATA_REQUEST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_DATA_REQUEST_ItemCommand);
			this.DGR_DATA_REQUEST.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_DATA_REQUEST_PageIndexChanged);

		}
		#endregion

		protected void DDL_DATA_TYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillDDLField();
		}

		protected void DDL_PAGE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillDDLCtrl();
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "SELECT * FROM DCM_PAGE_CONTROL_ERROR WHERE SEQ = CONVERT(INT, '" + LBL_SEQ.Text + "')";
			conn.ExecuteQuery();

			string status = "";

			if(conn.GetRowCount() == 0)
			{
				status = "INSERT";
			}
			else
			{
				status = "UPDATE";
			}

			conn.QueryString = "EXEC DCM_PAGE_CONTROL_INSERT_PARAM '" +
								LBL_SEQ.Text + "','" + 
								DDL_DATA_TYPE.SelectedValue + "','" +
								DDL_FIELD.SelectedValue + "','" +
								DDL_PAGE.SelectedValue + "','" +
								DDL_CONTROL.SelectedValue + "','" +
								TXT_MESSAGE.Text + "','" +
								Session["UserID"].ToString() + "',1,'" + status + "'";
			conn.ExecuteQuery();
			ViewExisitingParameter();
			ViewRequestingParameter();

			ClearData();
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{
			GenerateCode();
			DDL_DATA_TYPE.SelectedValue	= "";
			DDL_FIELD.SelectedValue		= "";
			DDL_PAGE.SelectedValue		= "";
			DDL_CONTROL.SelectedValue	= "";
			TXT_MESSAGE.Text			= "";
		}

		private void DGR_DATA_EXIST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_DATA_EXIST.CurrentPageIndex = e.NewPageIndex;
			ViewExisitingParameter();
		}

		private void DGR_DATA_EXIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					LBL_SEQ.Text				= e.Item.Cells[0].Text.ToString();
					DDL_DATA_TYPE.SelectedValue = e.Item.Cells[1].Text.ToString().Replace("&nbsp;","");
					FillDDLField();
					DDL_FIELD.SelectedValue		= e.Item.Cells[3].Text.ToString().Replace("&nbsp;","");
					DDL_PAGE.SelectedValue		= e.Item.Cells[5].Text.ToString().Replace("&nbsp;","");
					FillDDLCtrl();
					DDL_CONTROL.SelectedValue	= e.Item.Cells[7].Text.ToString().Replace("&nbsp;","");
					TXT_MESSAGE.Text			= e.Item.Cells[9].Text.ToString().Replace("&nbsp;","");
					break;
				case "delete":
					conn.QueryString = "EXEC DCM_PAGE_CONTROL_INSERT_PARAM '" +
										e.Item.Cells[0].Text.ToString() + "','" + 
										e.Item.Cells[1].Text.ToString() + "','" +
										e.Item.Cells[3].Text.ToString() + "','" +
										e.Item.Cells[5].Text.ToString() + "','" +
										e.Item.Cells[7].Text.ToString() + "','" +
										e.Item.Cells[9].Text.ToString() + "',0,'DELETE'";
					conn.ExecuteQuery();
					ViewExisitingParameter();
					ViewRequestingParameter();
					break;
				case "undelete":
					conn.QueryString = "EXEC DCM_PAGE_CONTROL_INSERT_PARAM '" +
										e.Item.Cells[0].Text.ToString() + "','" + 
										e.Item.Cells[1].Text.ToString() + "','" +
										e.Item.Cells[3].Text.ToString() + "','" +
										e.Item.Cells[5].Text.ToString() + "','" +
										e.Item.Cells[7].Text.ToString() + "','" +
										e.Item.Cells[9].Text.ToString() + "',1,'UNDELETE'";
					conn.ExecuteQuery();
					ViewExisitingParameter();
					ViewRequestingParameter();
					break;
			}
		}

		private void DGR_DATA_REQUEST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_DATA_REQUEST.CurrentPageIndex = e.NewPageIndex;
			ViewRequestingParameter();
		}

		private void DGR_DATA_REQUEST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit_req":
					LBL_SEQ.Text				= e.Item.Cells[0].Text.ToString();
					DDL_DATA_TYPE.SelectedValue = e.Item.Cells[1].Text.ToString().Replace("&nbsp;","");
					FillDDLField();
					DDL_FIELD.SelectedValue		= e.Item.Cells[3].Text.ToString().Replace("&nbsp;","");
					DDL_PAGE.SelectedValue		= e.Item.Cells[5].Text.ToString().Replace("&nbsp;","");
					FillDDLCtrl();
					DDL_CONTROL.SelectedValue	= e.Item.Cells[7].Text.ToString().Replace("&nbsp;","");
					TXT_MESSAGE.Text			= e.Item.Cells[9].Text.ToString().Replace("&nbsp;","");
					break;
				case "delete_req":
					conn.QueryString = "DELETE DCM_PAGE_CONTROL_ERROR_TEMP WHERE SEQ = '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					ViewRequestingParameter();
					break;
			}
		}
	}
}
