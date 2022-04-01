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

namespace SME.HistoricalLoanInfo
{
	/// <summary>
	/// Summary description for HistoricalLoanList.
	/// </summary>
	public partial class HistoricalLoanList : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack) 
			{
				LBL_CUREF.Text = Request.QueryString["curef"];
				viewData();
			}

            BTN_BACK.Click += new ImageClickEventHandler(BTN_BACK_Click);
            btn_cari.Click += new EventHandler(btn_cari_Click);

			ViewMenu();
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						if (conn.GetFieldValue(i,3).IndexOf("?de=") < 0 && conn.GetFieldValue(i,3).IndexOf("&de=") < 0) 
							strtemp = strtemp + "&de=" + Request.QueryString["de"];	
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"];
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		/// <summary>
		/// Menampilkan data aplikasi history customer
		/// </summary>		
		private void viewData() 
		{
			//conn.QueryString = "select * from VW_HISLOAN_APPLIST where CU_REF = '" + LBL_CUREF.Text + "'";

			conn.QueryString = "exec SP_GETLOANHISTORYFILTER '" + 
				LBL_CUREF.Text + "', " +
				GlobalTools.ConvertNull(txt_regno.Text.Trim()) + ", '" +
				Session["AreaID"].ToString() + "', '" + 
				Session["CBC"].ToString() + "', '" + 
				Session["BranchID"].ToString() + "', '" + 
				Session["UserID"].ToString() + "', '" + 
				Session["GroupID"].ToString() + "'";
			conn.ExecuteQuery(1200);

			// DEBUG
			Response.Write("<!-- " + conn.QueryString + " -->");

			DGR_LOANLIST.DataSource = conn.GetDataTable().Copy();
			try 
			{
				DGR_LOANLIST.DataBind();
			} 
			catch 
			{
				DGR_LOANLIST.CurrentPageIndex = 0;
				DGR_LOANLIST.DataBind();
			}

			TXT_AMOUNT.Text = conn.GetRowCount().ToString();

			gridFunctionSetup();
		}

		/// <summary>
		/// Konfigurasi function di datagrid
		/// Sembunyikan function "view" jika data berada di database housekeeping
		/// </summary>
		private void gridFunctionSetup() 
		{
			for(int i=0; i < DGR_LOANLIST.Items.Count; i++) 
			{
				/// Note: indikator lokasi database di kolom 7
				/// 
				if (DGR_LOANLIST.Items[i].Cells[7].Text.Trim() == "HOUSEKEEP") 
				{					
					LinkButton lnk_view = (LinkButton) DGR_LOANLIST.Items[i].FindControl("LNK_VIEW");
					lnk_view.Visible = false;
				}
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
			this.DGR_LOANLIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_LOANLIST_ItemCommand);

		}
		#endregion

		private void DGR_LOANLIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (e.CommandName.ToString()) 
			{
				case "view":
					string regno = e.Item.Cells[0].Text;
					Response.Redirect("HistoricalLoanMain.aspx?regno=" + regno + "&curef=" + LBL_CUREF.Text + "&mc=" + Request.QueryString["mc"]);
					break;
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink("", Request.QueryString["mc"], conn));
		}

		protected void btn_cari_Click(object sender, System.EventArgs e)
		{
			viewData();		
		}
	}
}
