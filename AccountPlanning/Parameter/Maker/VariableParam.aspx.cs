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
using DMS.CuBESCore;
using DMS.DBConnection;
using System.Configuration;

namespace SME.AccountPlanning.Parameter.Maker
{
	/// <summary>
	/// Summary description for VariableParam.
	/// </summary>
	public partial class VariableParam : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				CekCode();
				FillDDLType();
				FillGridExist();
				FillGridReq();
			}
		}

		private void CekCode()
		{
			conn.QueryString = "SELECT ISNULL(MAX(CONVERT(INT, SEQ)),0) AS SEQ FROM AP_RF_VARIABLE";
			conn.ExecuteQuery();
			LBL_ID.Text =  conn.GetFieldValue("SEQ").ToString();

			conn.QueryString = "EXEC AP_GENERATE_SEQ_PARAM '" + LBL_ID.Text + "'";
			conn.ExecuteQuery();
			TXT_ID.Text = conn.GetFieldValue(0,0).ToString();
		}

		private void FillDDLType()
		{
			DDL_DATA_UPLOAD.Items.Clear();
			DDL_DATA_UPLOAD.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_AP_DATA_UPLOAD_TYPE";
			conn.ExecuteQuery();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_DATA_UPLOAD.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		protected void DDL_DATA_UPLOAD_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TXT_LINKID.Text = "";
		}

		private void FillGridExist()
		{
			conn.QueryString = "SELECT * FROM AP_RF_VARIABLE WHERE STATUS='1' ORDER BY SEQ ASC";
			BindData(DGR_VARIABLE_EXIST.ID.ToString(), conn.QueryString);
		}

		private void FillGridReq()
		{
			conn.QueryString = "SELECT * FROM AP_RF_VARIABLE WHERE STATUS='2' ORDER BY SEQ ASC";
			BindData(DGR_VARIABLE_REQ.ID.ToString(), conn.QueryString);
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

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
			this.DGR_VARIABLE_EXIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_VARIABLE_EXIST_ItemCommand);
			this.DGR_VARIABLE_EXIST.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_VARIABLE_EXIST_PageIndexChanged);
			this.DGR_VARIABLE_REQ.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_VARIABLE_REQ_ItemCommand);
			this.DGR_VARIABLE_REQ.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_VARIABLE_REQ_PageIndexChanged);

		}
		#endregion

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if(TXT_VARIABLE_ID.Text == "" || TXT_VARIABLE_NAME.Text == "")
			{
				GlobalTools.popMessage(this, "Check Field Mandatory!");
				return;
			}
			else
			{
				if(DDL_DATA_UPLOAD.SelectedValue == "" || TXT_LINKID.Text == "")
				{
					GlobalTools.popMessage(this, "Check Link Data Upload!");
					return;
				}
				else if(TXT_VALUE_NON_RANGE.Text == "" && TXT_VALUE_RANGE.Text == "")
				{
					GlobalTools.popMessage(this, "Silahkan Isi Value Range atau Non Value Range!");
					return;
				}
				else if(TXT_VALUE_NON_RANGE.Text != "" && TXT_VALUE_RANGE.Text != "")
				{
					GlobalTools.popMessage(this, "Silahkan Isi Value Range atau Non Value Range!");
					return;
				}
				else if(TXT_VALUE_RANGE.Text != "" && TXT_VALUE_RANGE_SCORE.Text == "")
				{
					GlobalTools.popMessage(this, "Silahkan Isi Value Range Score!");
					return;
				}
				else
				{
					try
					{
						conn.QueryString = "EXEC AP_RF_VARIABLE_INSERT_PARAM '" + TXT_ID.Text + "','"
							+ TXT_VARIABLE_ID.Text + "','" + TXT_VARIABLE_NAME.Text + "','"
							+ DDL_DATA_UPLOAD.SelectedValue + "','" + TXT_LINKID.Text + "','"
							+ TXT_VALUE_NON_RANGE.Text + "','" + TXT_VALUE_RANGE.Text + "','"
							+ TXT_VALUE_RANGE_SCORE.Text + "'";
						conn.ExecuteQuery();
					}
					catch (Exception ex)
					{
						ClearData();
						FillGridExist();
						FillGridReq();

						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						return;
					}

					ClearData();
					FillGridExist();
					FillGridReq();
				}
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{
			TXT_VARIABLE_ID.Text = "";
			TXT_VARIABLE_NAME.Text = "";
			DDL_DATA_UPLOAD.SelectedValue = "";
			TXT_LINKID.Text = "";
			TXT_VALUE_NON_RANGE.Text = "";
			TXT_VALUE_RANGE.Text = "";
			TXT_VALUE_RANGE_SCORE.Text = "";
			CekCode();
		}

		protected void BTN_LINK_Click(object sender, System.EventArgs e)
		{
			if(DDL_DATA_UPLOAD.SelectedValue == "")
			{
				GlobalTools.popMessage(this, "Pilih Link Data Upload Terlebih Dahulu!");
				return;
			}
			else
			{
				Response.Write("<script language='javascript'>window.open('LinkDataUpload.aspx?targetFormID=Form1&targetObjectID=TXT_LINKID&targetLinkID=" + DDL_DATA_UPLOAD.SelectedValue + "','LinkDataUpload','status=no,scrollbars=yes,width=500,height=500');</script>");
			}
		}

		private void DGR_VARIABLE_EXIST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_VARIABLE_EXIST.CurrentPageIndex = e.NewPageIndex;
			FillGridExist();
		}

		private void DGR_VARIABLE_REQ_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_VARIABLE_REQ.CurrentPageIndex = e.NewPageIndex;
			FillGridReq();
		}

		private void DGR_VARIABLE_EXIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit_exist":
					TXT_ID.Text = e.Item.Cells[0].Text.Trim();
					TXT_VARIABLE_ID.Text = e.Item.Cells[1].Text.Trim();
					TXT_VARIABLE_NAME.Text = e.Item.Cells[2].Text.Trim();
					DDL_DATA_UPLOAD.SelectedValue = e.Item.Cells[3].Text.Trim();
					TXT_LINKID.Text = e.Item.Cells[4].Text.Trim();
					TXT_VALUE_NON_RANGE.Text = e.Item.Cells[5].Text.Trim().Replace("-","");
					TXT_VALUE_RANGE.Text = e.Item.Cells[6].Text.Trim().Replace("-","");
					TXT_VALUE_RANGE_SCORE.Text = e.Item.Cells[7].Text.Trim().Replace("&nbsp;","");
					break;

				case "delete_exist":
					conn.QueryString = "UPDATE AP_RF_VARIABLE SET STATUS='0', REQUEST='Not Active' WHERE SEQ='" + e.Item.Cells[0].Text.Trim() +"'";
					conn.ExecuteQuery();
					
					ClearData();
					FillGridExist();
					break;
			}
		}

		private void DGR_VARIABLE_REQ_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit_req":
					TXT_ID.Text = e.Item.Cells[0].Text.Trim();
					TXT_VARIABLE_ID.Text = e.Item.Cells[1].Text.Trim();
					TXT_VARIABLE_NAME.Text = e.Item.Cells[2].Text.Trim();
					DDL_DATA_UPLOAD.SelectedValue = e.Item.Cells[3].Text.Trim();
					TXT_LINKID.Text = e.Item.Cells[4].Text.Trim();
					TXT_VALUE_NON_RANGE.Text = e.Item.Cells[5].Text.Trim().Replace("-","");
					TXT_VALUE_RANGE.Text = e.Item.Cells[6].Text.Trim().Replace("-","");
					TXT_VALUE_RANGE_SCORE.Text = e.Item.Cells[7].Text.Trim().Replace("&nbsp;","");
					break;

				case "delete_req":
					conn.QueryString = "DELETE AP_RF_VARIABLE WHERE SEQ='" + e.Item.Cells[0].Text.Trim() +"'";
					conn.ExecuteQuery();
					
					ClearData();
					FillGridExist();
					break;
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../AccountPlanningParam.aspx?mc=" + Request.QueryString["mc"]);
		}
	}
}
