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
	/// Summary description for LinkDataIDParam.
	/// </summary>
	public partial class LinkDataIDParam : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
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
				GenerateCode();
				ViewExisitingParameter();
				ViewRequestingParameter();
			}
		}

		private void GenerateCode()
		{
			conn.QueryString = "SELECT ISNULL(MAX(SEQ),0)+1 AS SEQ FROM( SELECT SEQ FROM DCM_RF_LINK_DATA UNION SELECT SEQ FROM DCM_RF_LINK_DATA_TEMP)A";
			conn.ExecuteQuery();

			LBL_SEQ.Text = conn.GetFieldValue("SEQ");
		}

		private void ViewExisitingParameter()
		{
			BindData("DGR_DATA_EXIST", "SELECT * FROM VW_DCM_LINK_DATA_ID_PARAM ORDER BY SEQ");
		}

		private void ViewRequestingParameter()
		{
			BindData("DGR_DATA_REQUEST", "SELECT * FROM VW_DCM_LINK_DATA_ID_PARAM_TEMP ORDER BY SEQ");
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
				string a = dg.Items[i].Cells[8].Text.ToString();
				int num = int.Parse(dg.Items[i].Cells[8].Text.ToString());

				LinkButton toBeHidden;
				if(num == 1)
				{
					toBeHidden = ((LinkButton)dg.Items[i].Cells[9].FindControl("LNK_UNDELETE"));
					toBeHidden.Visible = false;
				}
				else if(num == 0)
				{
					toBeHidden = ((LinkButton)dg.Items[i].Cells[9].FindControl("LNK_DELETE"));
					toBeHidden.Visible = false;
				}
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

		private void CheckCode(string code)
		{
			/*
			 * Prosedur untuk generate ID secara otomatis sesuai data type yang dipilih
			 */
			conn.QueryString = "EXEC DCM_RULE_ID_PARAM '" + code + "','" + TXT_DESC.Text + "'";
			conn.ExecuteQuery();

			TXT_RULE_ID.Text = conn.GetFieldValue("RULE_ID");
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
			CheckCode(DDL_DATA_TYPE.SelectedValue);

			FillDDLField();
		}

		protected void TXT_DESC_TextIndexChanged(object sender, System.EventArgs e)
		{
			CheckCode(DDL_DATA_TYPE.SelectedValue);
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if(DDL_DATA_TYPE.SelectedValue.ToString() == "" || DDL_FIELD.SelectedValue.ToString() == "" || TXT_DESC.Text == "")
			{
				GlobalTools.popMessage(this, "Check Field Mandatory!");
				return;
			}
			else
			{
				conn.QueryString = "SELECT * FROM DCM_RF_LINK_DATA WHERE SEQ = CONVERT(INT, '" + LBL_SEQ.Text + "')";
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

				conn.QueryString = "EXEC DCM_LINK_DATA_INSERT_PARAM '" +
									LBL_SEQ.Text + "','" + 
									TXT_RULE_ID.Text + "','" +
									DDL_DATA_TYPE.SelectedValue + "','" +
									DDL_FIELD.SelectedValue + "','" +
									TXT_DESC.Text + "',1,'" + status + "'";
				conn.ExecuteQuery();
				ViewExisitingParameter();
				ViewRequestingParameter();

				ClearData();
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{
			GenerateCode();
			TXT_RULE_ID.Text			= "";
			DDL_DATA_TYPE.SelectedValue = "";
			DDL_FIELD.SelectedValue		= "";
			TXT_DESC.Text				= "";
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
					TXT_RULE_ID.Text			= e.Item.Cells[1].Text.ToString().Replace("&nbsp;","");
					DDL_DATA_TYPE.SelectedValue = e.Item.Cells[3].Text.ToString().Replace("&nbsp;","");
					FillDDLField();
					DDL_FIELD.SelectedValue		= e.Item.Cells[5].Text.ToString().Replace("&nbsp;","");
					TXT_DESC.Text				= e.Item.Cells[7].Text.ToString().Replace("&nbsp;","");
					break;
					
				case "delete":
					conn.QueryString = "EXEC DCM_LINK_DATA_INSERT_PARAM '" +
										e.Item.Cells[0].Text.ToString() + "','" + 
										e.Item.Cells[1].Text.ToString() + "','" +
										e.Item.Cells[3].Text.ToString() + "','" +
										e.Item.Cells[5].Text.ToString() + "','" +
										e.Item.Cells[7].Text.ToString() + "',0,'DELETE'";
					conn.ExecuteQuery();
					ViewExisitingParameter();
					ViewRequestingParameter();
					break;
				case "undelete":
					conn.QueryString = "EXEC DCM_LINK_DATA_INSERT_PARAM '" +
										e.Item.Cells[0].Text.ToString() + "','" + 
										e.Item.Cells[1].Text.ToString() + "','" +
										e.Item.Cells[3].Text.ToString() + "','" +
										e.Item.Cells[5].Text.ToString() + "','" +
										e.Item.Cells[7].Text.ToString() + "',1,'UNDELETE'";
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
					TXT_RULE_ID.Text			= e.Item.Cells[1].Text.ToString().Replace("&nbsp;","");
					DDL_DATA_TYPE.SelectedValue = e.Item.Cells[3].Text.ToString().Replace("&nbsp;","");
					FillDDLField();
					DDL_FIELD.SelectedValue		= e.Item.Cells[5].Text.ToString().Replace("&nbsp;","");
					TXT_DESC.Text				= e.Item.Cells[7].Text.ToString().Replace("&nbsp;","");
					break;

				case "delete_req":
					conn.QueryString = "DELETE DCM_RF_LINK_DATA_TEMP WHERE SEQ = '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					ViewRequestingParameter();
					break;
			}
		}
	}
}
