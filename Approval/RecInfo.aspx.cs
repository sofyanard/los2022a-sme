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

namespace SME.Approval
{
	/// <summary>
	/// Summary description for Memo.
	/// </summary>
	public partial class MemoDE : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			isiGrid();
		}

		void isiGrid()
		{
			DataTable dt = new DataTable();
			conn.QueryString="select ap_acqinfo, su_fullname, ap_acqinfodate from application a Left join scuser b on a.ap_acqinfoby=b.userid where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			try 
			{
				DatGrd.DataBind();
			} 
			catch {
				DatGrd.CurrentPageIndex = 0;
				DatGrd.DataBind();
			}
		for (int i = 0; i < DatGrd.Items.Count; i++)
	{
		DatGrd.Items[i].Cells[0].Text = ""+tool.FormatDate_Day(DatGrd.Items[i].Cells[0].Text)+"-"+tool.FormatDate_MonthName(DatGrd.Items[i].Cells[0].Text)+"-"+tool.FormatDate_Year(DatGrd.Items[i].Cells[0].Text)+"";
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
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);

		}
		#endregion

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			isiGrid();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("Approval.aspx?regno="+Request.QueryString["regno"]+"&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"]);
		}
	}
}
