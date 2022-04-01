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

namespace SME.DTBO
{
	/// <summary>
	/// Summary description for ListDTBO.
	/// </summary>
	public partial class ListPreScoring : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.204.9.78;Initial Catalog=SME;uid=sa;pwd="); asdfas
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				LBL_TC.Text=Request.QueryString["tc"];			

				// Munculkan pesan next step
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"]!= null)  
					GlobalTools.popMessage(this, Request.QueryString["msg"]);

				ViewAllData();
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


		private void ViewAllData()
		{
			string sql;
			sql = "select * from VW_LISTPRESCORING where 1=1 ";
			sql = sql + " and ap_currtrack='" + Request.QueryString["tc"] + "' and AP_REJECT = '0' and cu_rm='" + Session["UserID"].ToString() + "'";
			conn.QueryString = sql;
			try 
			{
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Server Error !");
				return;
			}

			GlobalTools.initDateForm(TXT_AP_SIGNDATEDAY1,DDL_AP_SIGNDATEMONTH1,TXT_AP_SIGNDATEYEAR1); 
			GlobalTools.initDateForm(TXT_AP_SIGNDATEDAY2,DDL_AP_SIGNDATEMONTH2,TXT_AP_SIGNDATEYEAR2); 

			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_LIST.DataSource = data;
			DGR_LIST.DataBind();

			for (int i = 0; i < DGR_LIST.Items.Count; i++) 
			{
				DGR_LIST.Items[i].Cells[3].Text = tool.FormatDate(DGR_LIST.Items[i].Cells[3].Text, true);

				/// Menambah konfirmasi saat update status
				LinkButton lbUpdate = (LinkButton) DGR_LIST.Items[i].FindControl("Linkbutton1");
				lbUpdate.Attributes.Add("onclick", "if(!update()){return false;};");
			}

		}
		private void ViewData()
		{
			string sql;
			sql = "select * from VW_LISTPRESCORING where 1=1 ";
			if (TXT_CU_NAME.Text != "")
				sql = sql + " and CU_NAME like '%"+ TXT_CU_NAME.Text +"%' ";
			if (TXT_AP_REGNO.Text != "")
				sql = sql + " and AP_REGNO = '"+ TXT_AP_REGNO.Text +"' ";
			if (TXT_CU_REF.Text != "")
				sql = sql + " and CU_REF = '"+ TXT_CU_REF.Text +"' ";
			if (TXT_AP_SIGNDATEDAY1.Text != "")
			{
				string AP_SIGNDATE1 = tool.ConvertDate(TXT_AP_SIGNDATEDAY1.Text, DDL_AP_SIGNDATEMONTH1.SelectedValue, TXT_AP_SIGNDATEYEAR1.Text);
				string AP_SIGNDATE2 = tool.ConvertDate(TXT_AP_SIGNDATEDAY2.Text, DDL_AP_SIGNDATEMONTH2.SelectedValue, TXT_AP_SIGNDATEYEAR2.Text);
				sql = sql + " and AP_SIGNDATE between "+ AP_SIGNDATE1 +" and "+ AP_SIGNDATE2 +" ";
			}
			sql = sql + " and ap_currtrack='" + Request.QueryString["tc"] + "' and AP_REJECT = '0' and cu_rm='" + Session["UserID"].ToString() + "'";
			conn.QueryString = sql;
			try 
			{
				conn.ExecuteQuery();
			} 
			catch (ApplicationException) 
			{
				GlobalTools.popMessage(this, "Input tidak valid !");
				return;
			}
			catch (FormatException) 
			{
				GlobalTools.popMessage(this, "Input tidak valid !");
				return;
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Server Error !");
				return;
			}

			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_LIST.DataSource = data;
			DGR_LIST.DataBind();

			for (int i = 0; i < DGR_LIST.Items.Count; i++)
				DGR_LIST.Items[i].Cells[3].Text = tool.FormatDate(DGR_LIST.Items[i].Cells[3].Text, true);
		}

		private void DGR_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// *** VIEW PreScoring ***
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					//ambil programcode dari application untuk digunakan oleh link di prescoring
					conn.QueryString  = "select PROG_CODE from APPLICATION where ";
					conn.QueryString += "AP_REGNO = '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					string prog = conn.GetFieldValue("PROG_CODE"); 
					Response.Redirect("PreScoringMain.aspx?regno="+ e.Item.Cells[0].Text +"&curef="+ e.Item.Cells[2].Text +"&prog="+ prog +"&tc="+ LBL_TC.Text + "&mc=" + Request.QueryString["mc"]+ "&CekData=0");
					break;
				case "UpdateStatus":
					conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					DataTable data = new DataTable();
					data = conn.GetDataTable().Copy();
			
					for (int i = 0; i < data.Rows.Count; i++)
					{
						conn.QueryString = "exec TRACKUPDATE '" + 
											e.Item.Cells[0].Text + "', '" +
											data.Rows[i]["productid"].ToString() + "', '" + 
											data.Rows[i]["apptype"].ToString() + "', '" + 
											Session["UserID"].ToString() + "', '" + 
											data.Rows[i]["PROD_SEQ"].ToString() + "','"+
											Request.QueryString["tc"].Trim()+"'";
						conn.ExecuteNonQuery();
					}
					ViewData();
					break;
			}
		}

		protected void BTN_CARI_Click(object sender, System.EventArgs e)
		{
			ViewData();
		}

		private void DGR_LIST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_LIST.CurrentPageIndex = e.NewPageIndex;
			ViewData();

		}

		protected void DGR_LIST_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}
	}
}
