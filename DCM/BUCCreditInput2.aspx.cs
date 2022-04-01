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
using Microsoft.VisualBasic;
using System.Configuration;

namespace SME.DCM
{
	/// <summary>
	/// Summary description for BUCCreditInput2.
	/// </summary>
	public partial class BUCCreditInput2 : System.Web.UI.Page
	{
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if(!IsPostBack)
			{
				DDL_BUC_CHECKING_DATA.Items.Add(new ListItem("--Pilih--", ""));
				DDL_BUC_INVALID_DATA.Items.Add(new ListItem("--Pilih--", ""));
				

				conn2.QueryString = "SELECT UNIT_CODE, UNIT_DESC FROM RF_DATA_OWNER WHERE ACTIVE='1'";
				conn2.ExecuteQuery();

				for(int i=0; i < conn2.GetRowCount(); i++)
				{
					DDL_BUC_CHECKING_DATA.Items.Add(new ListItem(conn2.GetFieldValue(i,0) + " - " + conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));
					DDL_BUC_INVALID_DATA.Items.Add(new ListItem(conn2.GetFieldValue(i,0) + " - " + conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));
				}
				
				ViewData();

				//BTN_FIND_CHECKING_DATA.Attributes.Add("onclick","if(!update()){return false;};");
				//BTN_FIND_INVALID_DATA.Attributes.Add("onclick","if(!update()){return false;};");
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
			this.DGR_INVALID_DATA.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_INVALID_DATA_ItemCommand);
			this.DGR_INVALID_DATA.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_INVALID_DATA_PageIndexChanged);
			this.DGR_CHECKING_DATA.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_CHECKING_DATA_ItemCommand);
			this.DGR_CHECKING_DATA.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_CHECKING_DATA_PageIndexChanged);

		}
		#endregion

		private void ViewData()
		{
			string tgl;
			string tgl_data;
			conn2.QueryString = "select TOP 0 * from buc_kredit where cifno not in (select cifno from buc_kredit where status_data='ERR' and error_msg like 'BUC tidak%')";
			conn2.ExecuteQuery(100000);
			FillGridCheckingData();

			conn2.QueryString = "select len(tgl_Data) DATE_LENGTH, * from buc_kredit where status_data='ERR' and error_msg like 'BUC tidak%' order by cifno";
			conn2.ExecuteQuery(100000);

			tgl = conn2.GetFieldValue("DATE_LENGTH");
			tgl_data = conn2.GetFieldValue("TGL_DATA");

			FillGridInvalidData();

			if(tgl == "5")
				conn2.QueryString = "select '0' + substring('" + tgl_data + "',1,1) + '-' + substring('" + tgl_data + "', 2,2) + '-20' + substring('" + tgl_data + "',4,2) TGL";
			else
				conn2.QueryString = "select substring('" + tgl_data + "',1,2) + '-' + substring('" + tgl_data + "', 3,2) + '-20' + substring('" + tgl_data + "',5,2) TGL";
				
			conn2.ExecuteQuery();
			//TXT_TGL_DATA_CHECKING.Text = conn2.GetFieldValue(0,0);
			TXT_TGL_DATA_INVALID.Text = conn2.GetFieldValue(0,0);

		}

		private void FillGridInvalidData()
		{
			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn2.GetDataTable().Copy();

			DGR_INVALID_DATA.DataSource = dt;
			try
			{
				DGR_INVALID_DATA.DataBind();
			}
			catch
			{
				DGR_INVALID_DATA.CurrentPageIndex = 0;
				DGR_INVALID_DATA.DataBind();
			}

			DropDownList ddl;
			LinkButton lnk;

			for (int i=0; i < DGR_INVALID_DATA.Items.Count; i++)
			{
				ddl = (DropDownList) DGR_INVALID_DATA.Items[i].FindControl("DDL_UPDATE_DATA_INVALID");
				ddl.Items.Add(new ListItem("--Pilih--",""));
				
				conn2.QueryString = "SELECT UNIT_CODE, UNIT_DESC FROM RF_DATA_OWNER WHERE ACTIVE='1'";
				conn2.ExecuteQuery();

				for(int j=0; j < conn2.GetRowCount(); j++)
					ddl.Items.Add(new ListItem(conn2.GetFieldValue(j,0) + " - " + conn2.GetFieldValue(j,1), conn2.GetFieldValue(j,0)));

				conn2.QueryString = "select * from dc_buc_credit where cifno='" + DGR_INVALID_DATA.Items[i].Cells[1].Text + "' and acctno='" + DGR_INVALID_DATA.Items[i].Cells[3].Text + "'";
				conn2.ExecuteQuery();

				if(conn2.GetRowCount() > 0)
				{
					ddl.SelectedValue = conn2.GetFieldValue("BUC_UPDATE");

					if(conn2.GetFieldValue("FLAG")!= "0")
						ddl.Enabled = false;

					//if(conn2.GetFieldValue("FLAG") == "0")
					lnk = (LinkButton)DGR_INVALID_DATA.Items[i].FindControl("LNK_UPDATE_INVALID_DATA");
					lnk.Visible = true;
				}
				else
				{
					lnk = (LinkButton)DGR_INVALID_DATA.Items[i].FindControl("LNK_UPDATE_INVALID_DATA");
					lnk.Visible = false;
				}
			}
		}

		private void FillGridCheckingData()
		{
			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn2.GetDataTable().Copy();

			DGR_CHECKING_DATA.DataSource = dt;
			try
			{
				DGR_CHECKING_DATA.DataBind();
			}
			catch
			{
				DGR_CHECKING_DATA.CurrentPageIndex = 0;
				DGR_CHECKING_DATA.DataBind();
			}

			DropDownList ddl;
			LinkButton lnk;

			for (int i=0; i < DGR_CHECKING_DATA.Items.Count; i++)
			{
				ddl = (DropDownList) DGR_CHECKING_DATA.Items[i].FindControl("DDL_UPDATE_DATA_CHECK");
				ddl.Items.Add(new ListItem("--Pilih--",""));
				
				conn2.QueryString = "SELECT UNIT_CODE, UNIT_DESC FROM RF_DATA_OWNER WHERE ACTIVE='1'";
				conn2.ExecuteQuery();

				for(int j=0; j < conn2.GetRowCount(); j++)
					ddl.Items.Add(new ListItem(conn2.GetFieldValue(j,0) + " - " + conn2.GetFieldValue(j,1), conn2.GetFieldValue(j,0)));

				conn2.QueryString = "select * from dc_buc_credit where cifno='" + DGR_CHECKING_DATA.Items[i].Cells[1].Text + "' and acctno='" + DGR_CHECKING_DATA.Items[i].Cells[3].Text + "'";
				conn2.ExecuteQuery();

				if(conn2.GetRowCount() > 0)
				{
					ddl.SelectedValue = conn2.GetFieldValue("BUC_UPDATE");

					if(conn2.GetFieldValue("FLAG")!= "0")
						ddl.Enabled = false;

					lnk = (LinkButton)DGR_CHECKING_DATA.Items[i].FindControl("LNK_UPDATE_CHECKING_DATA");
					lnk.Visible = true;
				}
				else
				{
					lnk = (LinkButton)DGR_CHECKING_DATA.Items[i].FindControl("LNK_UPDATE_CHECKING_DATA");
					lnk.Visible = false;
				}
			}
		}

		private void DGR_INVALID_DATA_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_INVALID_DATA.CurrentPageIndex = e.NewPageIndex;
			SearchDataInvalid();
		}

		private void SearchDataInvalid()
		{
			string tgl;
			string tgl_data;
			int count=0;
			string query="";

			/*if(DDL_BUC_INVALID_DATA.SelectedValue == "" && TXT_CUST_NAME_INVALID_DATA.Text == "")
			{
				GlobalTools.popMessage(this, "BUC atau customer name harus di isi!");
				return;
			}*/

			if (DDL_BUC_INVALID_DATA.SelectedValue != "")
				query = query + " and left(BUC_eMAS,5)='" + DDL_BUC_INVALID_DATA.SelectedValue + "'";

			if (TXT_CUST_NAME_INVALID_DATA.Text != "")
				query = query + " and sname like '%" + TXT_CUST_NAME_INVALID_DATA.Text + "%'";

			conn2.QueryString = "select len(tgl_Data) DATE_LENGTH, * from buc_kredit where status_data='ERR' and error_msg like 'BUC tidak%'" + query + " order by cifno";
			conn2.ExecuteQuery(100000);

			tgl = conn2.GetFieldValue("DATE_LENGTH");
			tgl_data = conn2.GetFieldValue("TGL_DATA");
			count = conn2.GetRowCount();

			FillGridInvalidData();
			if(count > 0)
			{
				if(tgl == "5")
					conn2.QueryString = "select '0' + substring('" + tgl_data + "',1,1) + '-' + substring('" + tgl_data + "', 2,2) + '-20' + substring('" + tgl_data + "',4,2) TGL";
				else
					conn2.QueryString = "select substring('" + tgl_data + "',1,2) + '-' + substring('" + tgl_data + "', 3,2) + '-20' + substring('" + tgl_data + "',5,2) TGL";
				
				conn2.ExecuteQuery();
				//TXT_TGL_DATA_CHECKING.Text = conn2.GetFieldValue(0,0);
				TXT_TGL_DATA_INVALID.Text = conn2.GetFieldValue(0,0);
			}
			else
			{
				TXT_TGL_DATA_INVALID.Text = "";
			}
		}

		private void SearchDataChecking()
		{
			string tgl;
			string tgl_data;
			int count=0;
			string query="";

			if(DDL_BUC_CHECKING_DATA.SelectedValue == "" && TXT_CUST_NAME_CHECKING_DATA.Text == "")
			{
				GlobalTools.popMessage(this, "BUC atau customer name harus di isi!");
				return;
			}

			if (DDL_BUC_CHECKING_DATA.SelectedValue != "")
				query = query + " and left(BUC_eMAS,5)='" + DDL_BUC_CHECKING_DATA.SelectedValue + "'";

			if (TXT_CUST_NAME_CHECKING_DATA.Text != "")
				query = query + " and sname like '%" + TXT_CUST_NAME_CHECKING_DATA.Text + "%'";

			conn2.QueryString = "select len(tgl_Data) DATE_LENGTH, * from buc_kredit where cifno not in (select cifno from buc_kredit where status_data='ERR' and error_msg like 'BUC tidak%')" + query + " order by cifno";
			conn2.ExecuteQuery(100000);

			tgl = conn2.GetFieldValue("DATE_LENGTH");
			tgl_data = conn2.GetFieldValue("TGL_DATA");
			count = conn2.GetRowCount();

			FillGridCheckingData();
			if(count > 0)
			{
				if(tgl == "5")
					conn2.QueryString = "select '0' + substring('" + tgl_data + "',1,1) + '-' + substring('" + tgl_data + "', 2,2) + '-20' + substring('" + tgl_data + "',4,2) TGL";
				else
					conn2.QueryString = "select substring('" + tgl_data + "',1,2) + '-' + substring('" + tgl_data + "', 3,2) + '-20' + substring('" + tgl_data + "',5,2) TGL";
				
				conn2.ExecuteQuery();
				TXT_TGL_DATA_CHECKING.Text = conn2.GetFieldValue(0,0);
			}
			else
			{
				TXT_TGL_DATA_CHECKING.Text = "";
			}
		}

		private void DGR_INVALID_DATA_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				DropDownList ddl;
				LinkButton lnk;
				ddl = (DropDownList)e.Item.Cells[6].FindControl("DDL_UPDATE_DATA_INVALID");
				lnk = (LinkButton)e.Item.Cells[8].FindControl("LNK_UPDATE_INVALID_DATA");

				try
				{
					switch(((Button)e.CommandSource).CommandName)
					{
						case "btn_save_invalid":
							conn2.QueryString = "exec dc_buc_credit_insert '" +
								TXT_TGL_DATA_INVALID.Text + "', '" +
								e.Item.Cells[1].Text + "', '" +
								e.Item.Cells[2].Text + "', '" +
								e.Item.Cells[3].Text + "', '" +
								e.Item.Cells[4].Text + "', '" +
								e.Item.Cells[5].Text + "', '" +
								ddl.SelectedValue.ToString() + "', '" +
								Session["UserID"].ToString() + "', '" +
								Session["FullName"].ToString() + "', '1', 'I'";
							conn2.ExecuteQuery();

							lnk.Visible = true;
							break;
						default:
							break;
					}
				}
				catch{}

				try
				{
					switch(((LinkButton)e.CommandSource).CommandName)
					{
						case "Update_Invalid":
							try
							{
								conn2.QueryString = "exec dc_buc_credit_insert '" +
									TXT_TGL_DATA_INVALID.Text + "', '" +
									e.Item.Cells[1].Text + "', '" +
									e.Item.Cells[2].Text + "', '" +
									e.Item.Cells[3].Text + "', '" +
									e.Item.Cells[4].Text + "', '" +
									e.Item.Cells[5].Text + "', '" +
									ddl.SelectedValue.ToString() + "', '" +
									Session["UserID"].ToString() + "', '" +
									Session["FullName"].ToString() + "', '2', 'I'";
								conn2.ExecuteQuery();
							}
							catch(Exception ex)
							{
								string errmsg = ex.Message.Replace("'","");
								if (errmsg.IndexOf("Last Query:") > 0)
									errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
								GlobalTools.popMessage(this, errmsg);
								return;
							}

							ddl.Enabled = false;
							break;
						default:
							break;
					}
				}
				catch{}
			}
			catch{}
		}

		private void DGR_CHECKING_DATA_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				DropDownList ddl;
				LinkButton lnk;
				ddl = (DropDownList)e.Item.Cells[6].FindControl("DDL_UPDATE_DATA_CHECK");
				lnk = (LinkButton)e.Item.Cells[8].FindControl("LNK_UPDATE_CHECKING_DATA");

				try
				{
					switch(((Button)e.CommandSource).CommandName)
					{
						case "btn_save_checking":
							conn2.QueryString = "exec dc_buc_credit_insert '" +
								TXT_TGL_DATA_CHECKING.Text + "', '" +
								e.Item.Cells[1].Text + "', '" +
								e.Item.Cells[2].Text + "', '" +
								e.Item.Cells[3].Text + "', '" +
								e.Item.Cells[4].Text + "', '" +
								e.Item.Cells[5].Text + "', '" +
								ddl.SelectedValue.ToString() + "', '" +
								Session["UserID"].ToString() + "', '" +
								Session["FullName"].ToString() + "', '1', 'C'";
							conn2.ExecuteQuery();

							lnk.Visible = true;
							break;
						default:
							break;
					}
				}
				catch{}

				try
				{
					switch(((LinkButton)e.CommandSource).CommandName)
					{
						case "Update_Checking":
							try
							{
								conn2.QueryString = "exec dc_buc_credit_insert '" +
									TXT_TGL_DATA_CHECKING.Text + "', '" +
									e.Item.Cells[1].Text + "', '" +
									e.Item.Cells[2].Text + "', '" +
									e.Item.Cells[3].Text + "', '" +
									e.Item.Cells[4].Text + "', '" +
									e.Item.Cells[5].Text + "', '" +
									ddl.SelectedValue.ToString() + "', '" +
									Session["UserID"].ToString() + "', '" +
									Session["FullName"].ToString() + "', '2', 'C'";
								conn2.ExecuteQuery();
							}
							catch(Exception ex)
							{
								string errmsg = ex.Message.Replace("'","");
								if (errmsg.IndexOf("Last Query:") > 0)
									errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
								GlobalTools.popMessage(this, errmsg);
								return;
							}

							ddl.Enabled = false;
							break;
						default:
							break;
					}
				}
				catch{}
			}
			catch{}
		}

		private void DGR_CHECKING_DATA_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_CHECKING_DATA.CurrentPageIndex = e.NewPageIndex;
			SearchDataChecking();
		}

		protected void BTN_FIND_INVALID_DATA_Click(object sender, System.EventArgs e)
		{
			SearchDataInvalid();
		}

		protected void BTN_FIND_CHECKING_DATA_Click(object sender, System.EventArgs e)
		{
			SearchDataChecking();
		}

	}
}
