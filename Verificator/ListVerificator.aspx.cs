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

namespace SME.Verificator
{
	/// <summary>
	/// Summary description for ListPRRK.
	/// </summary>
	public partial class ListVer : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			string tc = "";//,mi = "";//, si = "";
			try 
			{
				tc = Request.QueryString["tc"];
				//mi = Request.QueryString["mi"];
				//si = Request.QueryString["si"];
			} 
			catch {}
			
			if (!IsPostBack)
			{
				Tools.initDateForm(txt_Date, ddl_Month, txt_Year, true);
				txt_Date.Text = "";
				txt_Year.Text = "";
				Tools.initDateForm(txt_Date1, ddl_Month1, txt_Year1, true);
				txt_Date1.Text = "";
				txt_Year1.Text = "";

				DataTable DTBO = new DataTable();
				this.DatGrd.DataSource = new DataView(DTBO);
				this.DatGrd.DataBind();	

				bindData();

				// Munculkan pesan next step
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"]!= null)  
				{
					GlobalTools.popMessage(this, Request.QueryString["msg"]);
				}

			}
			DatGrd.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
		}

		private void bindData()
		{
			string tgl, tgl1;
			string query = "SELECT * FROM VW_VERIFICATOR_LIST where AP_CURRTRACK = '" + Request.QueryString["tc"].ToString() +
				"' AND CBC_CODE = '" + Session["BranchID"].ToString() + "' ";

			if (txt_Date.Text != "" && ddl_Month.SelectedValue != "" && txt_Year.Text != "" &&
				txt_Date1.Text != "" && ddl_Month1.SelectedValue != "" && txt_Year1.Text != "")
			{
				if (Tools.isDateValid(this,txt_Date.Text, ddl_Month.SelectedValue, txt_Year.Text) &&
					(Tools.isDateValid(this,txt_Date1.Text, ddl_Month1.SelectedValue, txt_Year1.Text)))
				{
					tgl = Tools.toSQLDate(txt_Date, ddl_Month, txt_Year);
					tgl1 = Tools.toSQLDate(txt_Date1, ddl_Month1, txt_Year1);
					query = query + " AND REQUESTDATE BETWEEN '" + tgl + "' AND '" + tgl1 + "' ";
				}
				else
				{
					GlobalTools.popMessage(this, "Tanggal tidak valid!");
					return;
				}
			}

			if (txt_Name.Text != "")
			{
				query = query + " AND CU_NAME LIKE '%" + txt_Name.Text + "%' ";
			}

			if (txt_ProsID.Text != "")
			{
				query = query + " AND AP_REGNO = '" + txt_ProsID.Text + "' ";
			}

			if (txt_IdCard.Text != "")
			{
				query = query + " AND CU_IDCARDNUM = '" + txt_IdCard.Text + "' ";
			}

			if (txt_NPWP.Text != "")
			{
				query = query + " AND AP_REGNO = '" + txt_NPWP.Text + "' ";
			}

			if (LBL_SORT.Text != "")
				query = query + LBL_SORT.Text;

			conn.QueryString = query;
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = 0;
				DatGrd.DataBind();
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);
			this.DatGrd.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DatGrd_SortCommand);

		}
		#endregion

		void Grid_Change(Object sender, DataGridPageChangedEventArgs e) 
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			bindData();	
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "View":								
					string tc = (string) Request.QueryString["tc"];
					Response.Redirect("MainVerificator.aspx?regno=" + e.Item.Cells[0].Text + "&curef=" + e.Item.Cells[6].Text+ "&tc="+tc+"&mc=" + Request.QueryString["mc"]);
					break;
				default:
					break;
			}
		}

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			this.bindData();
		}

		private void DatGrd_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			LBL_SORT.Text = " ORDER BY " + e.SortExpression;
			bindData();
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			bindData();
		}

	}
}
