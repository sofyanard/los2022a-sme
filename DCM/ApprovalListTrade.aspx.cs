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
	/// Summary description for ApprovalListTrade.
	/// </summary>
	public partial class ApprovalListTrade : System.Web.UI.Page
	{
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				FillData();
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
			this.DGR_PENDING_LIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_PENDING_LIST_ItemCommand);

		}
		#endregion

		private void FillData()
		{
			conn2.QueryString = "select * from vw_dc_interim where flag='1' and source_application='02' order by cif_cif#";
			conn2.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn2.GetDataTable().Copy();

			DGR_PENDING_LIST.DataSource = dt;
			try
			{
				DGR_PENDING_LIST.DataBind();
			}
			catch
			{
				DGR_PENDING_LIST.CurrentPageIndex = 0;
				DGR_PENDING_LIST.DataBind();
			}
		}

		protected void BTN_SUBMIT_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < DGR_PENDING_LIST.Items.Count; i++)
			{
				try	
				{
					RadioButton rbA = (RadioButton) DGR_PENDING_LIST.Items[i].FindControl("RDO_ACCEPT_DATA"),
						rbR = (RadioButton) DGR_PENDING_LIST.Items[i].FindControl("RDO_REJECT_DATA");
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
			FillData();
		}

		private void performRequest(int row)
		{
			string cifno = DGR_PENDING_LIST.Items[row].Cells[2].Text.Trim();
			string product = DGR_PENDING_LIST.Items[row].Cells[4].Text.Trim();

			conn2.QueryString = "exec DC_INTERIM_APPROVAL '" + cifno + "', '" +
				product + "', '2'";
			conn2.ExecuteQuery();
		} 

		private void deleteData(int row)
		{
			string cifno = DGR_PENDING_LIST.Items[row].Cells[2].Text.Trim();
			string product = DGR_PENDING_LIST.Items[row].Cells[4].Text.Trim();

			conn2.QueryString = "exec DC_INTERIM_APPROVAL '" + cifno + "', '" +
				product + "', '3'";
			conn2.ExecuteQuery();
		}

		private void DGR_PENDING_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i;
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "allAccept":
					for (i = 0; i < DGR_PENDING_LIST.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DGR_PENDING_LIST.Items[i].FindControl("RDO_ACCEPT"),
								rbB = (RadioButton) DGR_PENDING_LIST.Items[i].FindControl("RDO_PENDING"),
								rbC = (RadioButton) DGR_PENDING_LIST.Items[i].FindControl("RDO_REJECT");
							rbA.Checked = true;
							rbB.Checked = false;
							rbC.Checked = false;
						} 
						catch {}
					}
					break;
				case "allPend":
					for (i = 0; i < DGR_PENDING_LIST.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DGR_PENDING_LIST.Items[i].FindControl("RDO_ACCEPT"),
								rbB = (RadioButton) DGR_PENDING_LIST.Items[i].FindControl("RDO_PENDING"),
								rbC = (RadioButton) DGR_PENDING_LIST.Items[i].FindControl("RDO_REJECT");
							rbA.Checked = false;
							rbB.Checked = true;
							rbC.Checked = false;
						} 
						catch {}
					}
					break;
				case "allReject":
					for (i = 0; i < DGR_PENDING_LIST.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DGR_PENDING_LIST.Items[i].FindControl("RDO_ACCEPT"),
								rbB = (RadioButton) DGR_PENDING_LIST.Items[i].FindControl("RDO_PENDING"),
								rbC = (RadioButton) DGR_PENDING_LIST.Items[i].FindControl("RDO_REJECT");
							rbA.Checked = false;
							rbB.Checked = false;
							rbC.Checked = true;
						} 
						catch {}
					}
					break;
				case "view_data":
					if(e.Item.Cells[4].Text.Trim() == "LC")
						Response.Redirect("LCDataComplet.aspx?cif_no=" + e.Item.Cells[2].Text.Trim());
					else if (e.Item.Cells[4].Text.Trim() == "BG")
						Response.Redirect("BCDataComplet.aspx?cif_no=" + e.Item.Cells[2].Text.Trim());
					else if (e.Item.Cells[4].Text.Trim() == "SJ")
						Response.Redirect("SetoranJaminan.aspx?cif_no=" + e.Item.Cells[2].Text.Trim());
					break;
				default:
					// Do nothing.
					break;
			}
		}
	}
}
