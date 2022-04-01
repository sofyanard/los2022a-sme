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
using DMS.DBConnection;
using DMS.CuBESCore;
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;

namespace SME.MAS.CollateralAdministration.DetailCollateral
{
	/// <summary>
	/// Summary description for Collateral_Ar.
	/// </summary>
	public partial class Collateral_Ar : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			ViewMenu();
			if(!IsPostBack)
			{	
				//FILLData();
				ViewDataSimulasiBunga();
				ViewDataSimulasiPencairan();
				ViewDataSimulasiPembayaran();
			}
		}


		private void ViewMenu()
		{
			Menu.Controls.Clear();
			try 
			{
				conn.QueryString = "SELECT * FROM SCREENMENU WHERE MENUCODE = '" + Request.QueryString["mc"] + "'";
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
							strtemp = "&curef=" + Request.QueryString["curef"] + "&cif=" + Request.QueryString["cif"] + "&exist=" + Request.QueryString["exist"];
						else	
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&curef=" + Request.QueryString["curef"] + "&cif=" + Request.QueryString["cif"] + "&exist=" + Request.QueryString["exist"];
					}
					else 
					{
						strtemp = ""; 
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

		private void FILLData()
		{
			DDL_LOANACCOUNT.Items.Add(new ListItem("--Pilih--", ""));
			DDL_LOANACCOUNT2.Items.Add(new ListItem("--Pilih--", ""));
			DDL_LOANACCOUNT3.Items.Add(new ListItem("--Pilih--", ""));

			conn.QueryString = "SELECT * FROM BRI_LOANACCOUNT";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_LOANACCOUNT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				DDL_LOANACCOUNT2.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				DDL_LOANACCOUNT3.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			}

			DDL_FLOAT.Items.Add(new ListItem("--Pilih--", ""));

			conn.QueryString = "SELECT * BRI_FLOATINGRATE";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_FLOAT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}

			DDL_VAR.Items.Add(new ListItem("--Pilih--", ""));
			DDL_VAR.Items.Add(new ListItem("+", "1"));
			DDL_VAR.Items.Add(new ListItem("-", "0"));

			DDL_KODE.Items.Add(new ListItem("--Pilih--", ""));

			conn.QueryString = "SELECT * BRI_KODEPEMBAYARAN";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_KODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void ViewDataSimulasiBunga()
		{
			conn.QueryString = "EXEC XXXXX_SIMULASI_VIEWSUKUBUNGA '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_SUKUBUNGA.DataSource = dt;
			try 
			{
				DG_SUKUBUNGA.DataBind();
			} 
			catch 
			{
				DG_SUKUBUNGA.CurrentPageIndex = 0;
				DG_SUKUBUNGA.DataBind();
			}
		}

		private void ViewDataSimulasiPencairan()
		{
			conn.QueryString = "EXEC XXXXX_SIMULASI_VIEWPENCAIRAN '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_PENCAIRAN.DataSource = dt;
			try 
			{
				DG_PENCAIRAN.DataBind();
			} 
			catch 
			{
				DG_PENCAIRAN.CurrentPageIndex = 0;
				DG_PENCAIRAN.DataBind();
			}
		}

		private void ViewDataSimulasiPembayaran()
		{
			conn.QueryString = "EXEC XXXXX_SIMULASI_VIEWPEMBAYARAN '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_PEMBAYARAN.DataSource = dt;
			try 
			{
				DG_PEMBAYARAN.DataBind();
			} 
			catch 
			{
				DG_PEMBAYARAN.CurrentPageIndex = 0;
				DG_PEMBAYARAN.DataBind();
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

		}
		#endregion

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			DDL_LOANACCOUNT.SelectedValue="";
			TXT_TENOR.Text="";
			TXT_FIXEDRATE.Text="";
			DDL_FLOAT.SelectedValue="";
			TXT_FLOAT.Text="";
			DDL_VAR.SelectedValue="";
			TXT_VAR.Text="";
			TXT_INSTALL.Text="";
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
		
		}
		
	}
}
