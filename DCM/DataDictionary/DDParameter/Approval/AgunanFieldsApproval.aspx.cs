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

namespace SME.DCM.DataDictionary.DDParameter.Approval
{
	/// <summary>
	/// Summary description for AgunanFieldsApproval1.
	/// </summary>
	public partial class AgunanFieldsApproval1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				BindData("DGR_PROBAPPR","SELECT * FROM DD_FIELDS_AGUNAN_TEMP");
			}
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
			this.DGR_PROBAPPR.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_PROBAPPR_ItemCommand);
			this.DGR_PROBAPPR.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_PROBAPPR_PageIndexChanged);

		}
		#endregion

		private void DGR_PROBAPPR_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
					//Response.Redirect("AssignmentComplyMain.aspx?curef="+Request.QueryString["curef"]+"&productid="+Request.QueryString["productid"]+"&aano="+Request.QueryString["aano"]+"&prodseq="+Request.QueryString["prodseq"]+"&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&parentregno="+Request.QueryString["parentregno"]+"&regno="+Request.QueryString["regno"]+"&mode=lanjut&prodseqinduk="+Request.QueryString["prodseqinduk"]);
					break;
				case "allAccept":
					allAccept();
					break;
				case "allPending":
					allPending();
					break;
				case "allReject":
					allReject();
					break;
			}
		}

		private void allReject()
		{
			for (int i=0; i<DGR_PROBAPPR.Items.Count; i++)
			{
				RadioButton reject = (RadioButton) DGR_PROBAPPR.Items[i].Cells[5].FindControl("RDO_REJECT");
				reject.Checked = true;
				RadioButton accept = (RadioButton) DGR_PROBAPPR.Items[i].Cells[3].FindControl("RDO_ACCEPT");
				accept.Checked = false;
				RadioButton pending = (RadioButton) DGR_PROBAPPR.Items[i].Cells[4].FindControl("RDO_PENDING");
				pending.Checked = false;
			}
		}

		private void allAccept()
		{
			for (int i=0; i<DGR_PROBAPPR.Items.Count; i++)
			{
				RadioButton accept = (RadioButton) DGR_PROBAPPR.Items[i].Cells[3].FindControl("RDO_ACCEPT");
				accept.Checked = true;
				RadioButton reject = (RadioButton) DGR_PROBAPPR.Items[i].Cells[5].FindControl("RDO_REJECT");
				reject.Checked = false;
				RadioButton pending = (RadioButton) DGR_PROBAPPR.Items[i].Cells[4].FindControl("RDO_PENDING");
				pending.Checked = false;
			}
		}

		private void allPending()
		{
			for (int i=0; i<DGR_PROBAPPR.Items.Count; i++)
			{
				RadioButton pending = (RadioButton) DGR_PROBAPPR.Items[i].Cells[4].FindControl("RDO_PENDING");
				pending.Checked = true;
				RadioButton accept = (RadioButton) DGR_PROBAPPR.Items[i].Cells[3].FindControl("RDO_ACCEPT");
				accept.Checked = false;
				RadioButton reject = (RadioButton) DGR_PROBAPPR.Items[i].Cells[5].FindControl("RDO_REJECT");
				reject.Checked = false;
			}
		}

		protected void BTN_SUB_Click(object sender, System.EventArgs e)
		{
			for (int i=0; i<DGR_PROBAPPR.Items.Count; i++)
			{
				RadioButton pending = (RadioButton) DGR_PROBAPPR.Items[i].Cells[4].FindControl("RDO_PENDING");
				RadioButton accept = (RadioButton) DGR_PROBAPPR.Items[i].Cells[3].FindControl("RDO_ACCEPT");
				RadioButton reject = (RadioButton) DGR_PROBAPPR.Items[i].Cells[5].FindControl("RDO_REJECT");

				if(pending.Checked == true)
				{
					continue;	
				}
				else if(accept.Checked == true)
				{
					conn.QueryString = "EXEC DD_EXECUTE_PENDING_PARAMETER '" + DGR_PROBAPPR.Items[i].Cells[0].Text.ToString() + "','AGUNAN','ACCEPT'";
					conn.ExecuteQuery();
				}
				else if(reject.Checked == true)
				{
					conn.QueryString = "EXEC DD_EXECUTE_PENDING_PARAMETER '" + DGR_PROBAPPR.Items[i].Cells[0].Text.ToString() + "','AGUNAN','REJECT'";
					conn.ExecuteQuery();
				}
			}

			BindData("DGR_PROBAPPR","SELECT * FROM DD_FIELDS_AGUNAN_TEMP");
		}

		private void DGR_PROBAPPR_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_PROBAPPR.CurrentPageIndex = e.NewPageIndex;
			BindData("DGR_PROBAPPR","SELECT * FROM DD_FIELDS_AGUNAN_TEMP");
		}
	}
}
