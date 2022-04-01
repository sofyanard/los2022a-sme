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

namespace SourceSMEReport
{
	/// <summary>
	/// Summary description for DisbursementSheet.asdf
	/// </summary>
	public partial class DisbursementSheet : System.Web.UI.Page
	{
		//protected Connection Conn = new Connection("Data Source=10.204.9.78;Initial Catalog=SME;uid=sa;pwd=");
		protected Connection Conn;
		protected Tools tools = new Tools();
			
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], Conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				LBL_TC.Text = Request.QueryString["tc"];
				LBL_MC.Text = Request.QueryString["mc"];
				
				ViewGrid();
				//ViewData();
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
			this.DGR_LIST.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_LIST_PageIndexChanged);

		}
		#endregion

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			DGR_LIST.CurrentPageIndex	= 0;
			ViewGrid();
		}

		private void ViewData()
		{
			Conn.QueryString = "select in_reject from rfinitial";
			Conn.ExecuteQuery();

			string var_reject = Conn.GetFieldValue("in_reject");
			Conn.QueryString = "select * from VW_CUST_DISBURSEMENT_KETKREDIT where AP_CONFIRMBOOK='1' and  " + 
				" ap_currtrack in ('" + Request.QueryString["tc"] + "', '5.2')" +
				" and ap_currtrack <> '"+var_reject +
				" and branch_code = (select br_ccobranch from rfbranch where branch_code = (select su_branch from scuser where userid = '" + Session["UserID"] + "')) " +
				" order by ap_recvdate desc";
			Conn.ExecuteQuery();
			
			DataTable d			= new DataTable();
			d					= Conn.GetDataTable().Copy();
			DGR_LIST.DataSource	= d;
			DGR_LIST.DataBind();
			for (int i=0; i<DGR_LIST.Items.Count;i++)
				DGR_LIST.Items[i].Cells[3].Text	= tools.FormatDate(DGR_LIST.Items[i].Cells[3].Text);
		}

		private void ViewGrid()
		{
			string sql = "", regno="", nama="";
			regno	= TXT_AP_REGNO.Text.Trim();
			nama	= TXT_NAMA.Text.Trim();
			if (nama=="" && regno=="")
			{
				//Tools.popMessage(this,"Nomor Aplikasi atau Nama tidak boleh kosong !");
				Tools.SetFocus(this,TXT_AP_REGNO);
				ViewData();
			}
			else
			{
				
				Conn.QueryString = "select in_reject from rfinitial";
				Conn.ExecuteQuery();
				string var_reject = Conn.GetFieldValue("in_reject");

				/* script lama, diremark karena The items displayed under the worksheet should be under the same CCO branch
				 * correction by : cheng kl
				 * update by : denny
				 * 
				if (!regno.Equals(""))
					sql = " and ap_regno = '"+regno+"' ";
				*/
	
				if (!regno.Equals(""))
					sql = " and ap_regno = '"+regno+"' ";
				if (!nama.Equals(""))
					sql = sql +" and nama like '%"+nama+"%' ";

				sql = sql + " and branch_code = (select br_ccobranch from rfbranch where branch_code = (select su_branch from scuser where userid = '" + Session["UserID"] + "'))";

				Conn.QueryString = "select TOP 100 * from VW_CUST_DISBURSEMENT_KETKREDIT " + 
					"where AP_CONFIRMBOOK='1' and ap_currtrack in ('" + Request.QueryString["tc"] +"', '5.2')" + 
					"' and ap_currtrack <> '"+var_reject+"'"+ sql;
				Conn.QueryString = Conn.QueryString + " order by ap_recvdate desc";
				Conn.ExecuteQuery();
				DataTable d			= new DataTable();
				d					= Conn.GetDataTable().Copy();
				DGR_LIST.DataSource	= d;
				DGR_LIST.DataBind();
				for (int i=0; i<DGR_LIST.Items.Count;i++)
					DGR_LIST.Items[i].Cells[3].Text	= tools.FormatDate(DGR_LIST.Items[i].Cells[3].Text);
			}
		}

		private void DGR_LIST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_LIST.CurrentPageIndex	= e.NewPageIndex;
			ViewGrid();
		}

		private void DGR_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "report":
					Response.Redirect("Disbursement.aspx?regno="+ e.Item.Cells[0].Text +"&tc="+ LBL_TC.Text+"&mc=" + LBL_MC.Text + "&prodid="+ e.Item.Cells[7].Text+"&ket_code="+ e.Item.Cells[5].Text+"&cash="+ e.Item.Cells[8].Text+"&prod_seq="+ e.Item.Cells[10].Text);
					//GlobalTools.popMessage(this,"Disbursement.aspx?regno="+ e.Item.Cells[0].Text +"&tc="+ LBL_TC.Text+"&mc=" + LBL_MC.Text + "&prodid="+ e.Item.Cells[7].Text+"&ket_code="+ e.Item.Cells[5].Text+"&cash="+ e.Item.Cells[8].Text+"&prod_seq="+ e.Item.Cells[10].Text);
					break;
				case "view":
					Response.Redirect("../DisbursementWorksheet/DetailLegalSigning.aspx?regno="+ e.Item.Cells[0].Text +"&curef="+ e.Item.Cells[9].Text+"&tc="+ LBL_TC.Text+"&mc="+ LBL_MC.Text);
					break;
			}
		}
	}
}
