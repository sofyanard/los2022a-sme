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
	/// Summary description for CifListDataApproval.
	/// </summary>
	public partial class CifListDataApproval : System.Web.UI.Page
	{
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				if(Request.QueryString["msg"]!="" && Request.QueryString["msg"] != null)
				{
					GlobalTools.popMessage(this, Request.QueryString["msg"]);
				}

				FillCifAppr();
			}
		}

		private void FillCifAppr()
		{
			conn2.QueryString = "select * from VW_CIF_LIST_APPROVAL order by sname";
			conn2.ExecuteQuery(10000);

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn2.GetDataTable().Copy();

			DGR_CIF_LIST.DataSource = dt;
			try
			{
				DGR_CIF_LIST.DataBind();
			}
			catch
			{
				DGR_CIF_LIST.CurrentPageIndex = 0;
				DGR_CIF_LIST.DataBind();
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
			this.DGR_CIF_LIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_CIF_LIST_ItemCommand);
			this.DGR_CIF_LIST.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_CIF_LIST_PageIndexChanged);

		}
		#endregion

		private void DGR_CIF_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i;
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "allAccept":
					for (i = 0; i < DGR_CIF_LIST.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DGR_CIF_LIST.Items[i].FindControl("RDO_ACCEPT"),
								rbB = (RadioButton) DGR_CIF_LIST.Items[i].FindControl("RDO_PENDING"),
								rbC = (RadioButton) DGR_CIF_LIST.Items[i].FindControl("RDO_REJECT");
							rbA.Checked = true;
							rbB.Checked = false;
							rbC.Checked = false;
						} 
						catch {}
					}
					break;
				case "allPend":
					for (i = 0; i < DGR_CIF_LIST.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DGR_CIF_LIST.Items[i].FindControl("RDO_ACCEPT"),
								rbB = (RadioButton) DGR_CIF_LIST.Items[i].FindControl("RDO_PENDING"),
								rbC = (RadioButton) DGR_CIF_LIST.Items[i].FindControl("RDO_REJECT");
							rbA.Checked = false;
							rbB.Checked = true;
							rbC.Checked = false;
						} 
						catch {}
					}
					break;
				case "allReject":
					for (i = 0; i < DGR_CIF_LIST.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DGR_CIF_LIST.Items[i].FindControl("RDO_ACCEPT"),
								rbB = (RadioButton) DGR_CIF_LIST.Items[i].FindControl("RDO_PENDING"),
								rbC = (RadioButton) DGR_CIF_LIST.Items[i].FindControl("RDO_REJECT");
							rbA.Checked = false;
							rbB.Checked = false;
							rbC.Checked = true;
						} 
						catch {}
					}
					break;
				case "View":
					Response.Redirect("CifGeneralData.aspx?cifno=" + e.Item.Cells[1].Text + "&tc=" + Request.QueryString["tc"] + "&mc=DCM0101"+ "&from_appr=1");
					break;
				default:
					// Do nothing.
					break;
			}
		}

		private void DGR_CIF_LIST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_CIF_LIST.CurrentPageIndex = e.NewPageIndex;
			FillCifAppr();
		}

		protected void BTN_SUBMIT_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < DGR_CIF_LIST.Items.Count; i++)
			{
				try	
				{
					RadioButton rbA = (RadioButton) DGR_CIF_LIST.Items[i].FindControl("RDO_ACCEPT"),
						rbR = (RadioButton) DGR_CIF_LIST.Items[i].FindControl("RDO_REJECT");
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
			FillCifAppr();
		}

		private void deleteData(int row)
		{
			/*try 
			{
				string cifno = DGR_CIF_LIST.Items[row].Cells[1].Text.Trim();

				conn2.QueryString = "exec CIF_FLAG_UPDATE '" + 
					cifno + "', '2'";
				conn2.ExecuteQuery();
			} 
			catch {} */
			try 
			{
				string cifno = DGR_CIF_LIST.Items[row].Cells[1].Text.Trim();

				conn2.QueryString = "exec CIF_DELETE '" + 
					cifno + "' ";
				conn2.ExecuteQuery();
			} 
			catch {}
		}

		private void performRequest(int row)
		{
			try 
			{
				string cifno = DGR_CIF_LIST.Items[row].Cells[1].Text.Trim();

				conn2.QueryString = "exec CIF_FLAG_UPDATE '" + 
					cifno + "', '2'";
				conn2.ExecuteQuery();
			} 
			catch {}
		}


	}
}
