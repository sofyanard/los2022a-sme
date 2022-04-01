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

namespace SME.Maintenance.Parameters.General
{
	/// <summary>
	/// Summary description for RFProductAppr.
	/// </summary>
	public partial class RFProductAppr : System.Web.UI.Page
	{
	
		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				bindData();
			}
			DTG_APPR.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
		}

		private void bindData()
		{
			conn.QueryString = "SELECT PRODUCTID, PRODUCTDESC, SIBS_PRODCODE, SIBS_PRODID, " +
				"CURRENCYDESC, RATENO, RATE * 100 RATE, CALCMETHOD, INTERESTMODE, " +
				"case REVOLVING when '1' then 'YES' when '0' then 'NO' end REVOLVING, " +
				"case ISCASHLOAN when '1' then 'YES' when '0' then 'NO' end ISCASHLOAN, " +
				"case IDCFLAG when '1' then 'YES' when '0' then 'NO' end IDCFLAG, VARCODE, VARIANCE, "+
				"case SPK when '1' then 'YES' when '0' then 'NO' end SPK, INTERESTREST, " + 
				"case ISINSTALLMENT when '1' then 'INSTALLMENT' when '0' then 'INTEREST' end ISINSTALLMENT, " +
				"ITYPEDESC, FIRSTINSTALLDATE, INTERESTTYPERATE, IN_NAME, " +
				"case CONFIRMKORAN when '1' then 'YES' when '0' then 'NO' end CONFIRMKORAN, " +
				"STATUSDESC, PENDINGSTATUS "+
				"FROM VW_PARAM_GENERAL_PENDING_RFPRODUCT ";
			conn.ExecuteQuery();
			DTG_APPR.DataSource = conn.GetDataTable().Copy();
			try 
			{
				DTG_APPR.DataBind();
			}
			catch 
			{
				DTG_APPR.CurrentPageIndex = DTG_APPR.PageCount - 1;
				DTG_APPR.DataBind();
			}
		}

		private void performRequest(int row)
		{
			try 
			{
				string id = DTG_APPR.Items[row].Cells[1].Text.Trim();
				conn.QueryString = "PARAM_GENERAL_RFPRODUCT_APPR '" + id + "', '1'";
				conn.ExecuteQuery();
			} 
			catch {}
		}

		private void deleteData(int row)
		{
			try 
			{
				string id = DTG_APPR.Items[row].Cells[1].Text.Trim();
				conn.QueryString = "PARAM_GENERAL_RFPRODUCT_APPR '" + id + "', '0'";
				conn.ExecuteQuery();
			} 
			catch {}
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
			this.DTG_APPR.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DTG_APPR_ItemCommand);

		}
		#endregion

		void Grid_Change(Object sender, DataGridPageChangedEventArgs e) 
		{
			// Set CurrentPageIndex to the page the user clicked.
			DTG_APPR.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData();	
		}

		protected void BTN_SUBMIT_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < DTG_APPR.Items.Count; i++)
			{
				try
				{
					RadioButton rbA = (RadioButton) DTG_APPR.Items[i].FindControl("rdo_Approve"),
						rbR = (RadioButton) DTG_APPR.Items[i].FindControl("rdo_Reject");
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
			bindData();
		}

		private void DTG_APPR_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i;
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "allAppr":
					for (i = 0; i < DTG_APPR.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DTG_APPR.Items[i].FindControl("rdo_Approve"),
								rbB = (RadioButton) DTG_APPR.Items[i].FindControl("rdo_Reject"),
								rbC = (RadioButton) DTG_APPR.Items[i].FindControl("rdo_Pending");
							rbB.Checked = false;
							rbC.Checked = false;
							rbA.Checked = true;
						} 
						catch {}
					}
					break;
				case "allRejc":
					for (i = 0; i < DTG_APPR.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DTG_APPR.Items[i].FindControl("rdo_Approve"),
								rbB = (RadioButton) DTG_APPR.Items[i].FindControl("rdo_Reject"),
								rbC = (RadioButton) DTG_APPR.Items[i].FindControl("rdo_Pending");
							rbA.Checked = false;
							rbC.Checked = false;
							rbB.Checked = true;
						} 
						catch {}
					}
					break;
				case "allPend":
					for (i = 0; i < DTG_APPR.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DTG_APPR.Items[i].FindControl("rdo_Approve"),
								rbB = (RadioButton) DTG_APPR.Items[i].FindControl("rdo_Reject"),
								rbC = (RadioButton) DTG_APPR.Items[i].FindControl("rdo_Pending");
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
			Response.Redirect("../GeneralParamApproval.aspx?mc="+Request.QueryString["mc"]);
		}
	}
}
