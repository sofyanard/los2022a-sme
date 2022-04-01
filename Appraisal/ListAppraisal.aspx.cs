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


namespace SME.Appraisal
{
	/// <summary>
	/// Summary description for ListAppraisal.sadfasdf
	/// </summary>
	public partial class ListAppraisal : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

//			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
//				Response.Redirect("/SME/Restricted.aspx");asddsa

			LBL_REGNO.Text = Request.QueryString["regno"];
			LBL_CUREF.Text = Request.QueryString["curef"];
			LBL_TC.Text = Request.QueryString["tc"];
			LBL_USERID.Text = Session["UserID"].ToString();
			
			if ((LBL_REGNO.Text != "") && (LBL_CUREF.Text != ""))
			{
				conn.QueryString = "select distinct VW.* "+
					"from VW_LISTCUST VW "+
					"join COLLATERAL CL on CL.CU_REF = VW.CU_REF "+
					"where VW.AP_REGNO = '"+ LBL_REGNO.Text +"' and CL_TYPE = 1 ";
				conn.ExecuteQuery();
				ViewData();
			}
			else
			{
				//conn.QueryString = "select * from vw_listassignment where ap_currtrack='" + Request.QueryString["tc"] + "'";
				//--- modif by yudi (2004/09/09) ---
				////conn.QueryString = "select * from VW_CREDITOPR_ASSGN where OFFICERSEQ='" + Session["UserID"].ToString() + "' and LA_APPRSTATUS='2'";
				//conn.QueryString = "select * from VW_CREDITOPR_ASSGN where OFFICERSEQ='" + LBL_USERID.Text + "' and LA_APPRSTATUS='2'";
				//----------------------------------

				//--- modif by yudi (2004/09/18) ---
				conn.QueryString = "select * from VW_CREDITOPR_ASSGN where OFFICERSEQ='" + LBL_USERID.Text + "' and LA_APPRSTATUS='2' and AP_REJECT = '0' and AP_CANCEL = '0'";
				conn.ExecuteQuery();
				ViewData();
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
			this.DGR_LIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_LIST_ItemCommand);

		}
		#endregion

		private void ViewData()
		{
			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_LIST.DataSource = data;
			try 
			{
				DGR_LIST.DataBind();
			} 
			catch 
			{
				DGR_LIST.CurrentPageIndex = 0;
				DGR_LIST.DataBind();
			}
		}

		private void DGR_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// *** VIEW APPRAISAL ***
			//string CL_TYPE, ALAMAT;
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					Response.Redirect("InfoUmum.aspx?regno="+ e.Item.Cells[1].Text +"&curef="+ e.Item.Cells[2].Text +"&tc="+ LBL_TC.Text + "&mc=" + Request.QueryString["mc"]);
					break;
			}
		}
	}
}
