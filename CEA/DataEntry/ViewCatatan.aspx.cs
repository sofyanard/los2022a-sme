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
using DMS.BlackList;

namespace SME.CEA.DataEntry
{
	/// <summary>
	/// Summary description for ViewCatatan.
	/// </summary>
	public partial class ViewCatatan : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			ViewMenu();
			ViewCatatanRekanan();
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
			this.DatgrdCat.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatgrdCat_ItemCommand);
			this.DatgrdCat.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatgrdCat_PageIndexChanged);

		}
		#endregion

		private void ViewMenu()
		{
			Menu.Controls.Clear();
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
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"] + "&exist=" + Request.QueryString["exist"]+ "&view=" + Request.QueryString["view"];
						else	
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+ "&exist=" + Request.QueryString["exist"]+ "&tc="+Request.QueryString["tc"]+ "&view=" + Request.QueryString["view"];
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"] + "&mc2=" + Request.QueryString["mc2"];
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

		private void DatgrdCat_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":	
					conn.QueryString = "select keterangan from rekanan_catatan where seq='" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					txt_catatan.Text = conn.GetFieldValue("keterangan");
					break;		
			}
		}

		private void ViewCatatanRekanan()
		{
			conn.QueryString = "select * from rekanan_catatan where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();
			FillGridCatatan();
		}

		private void FillGridCatatan()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatgrdCat.DataSource = dt;
			try 
			{
				DatgrdCat.DataBind();
			} 
			catch 
			{
				DatgrdCat.CurrentPageIndex = 0;
				DatgrdCat.DataBind();
			}
			for (int i = 0; i < DatgrdCat.Items.Count; i++)
			{
				DatgrdCat.Items[i].Cells[2].Text = tool.FormatDate(DatgrdCat.Items[i].Cells[2].Text, true);
			}
		}

		private void DatgrdCat_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatgrdCat.CurrentPageIndex = e.NewPageIndex;
			ViewCatatanRekanan();
		}
		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["par"] != null && Request.QueryString["par"] != "") 
			{
				Response.Redirect(Request.QueryString["par"] + "&mc=" + Request.QueryString["mc2"] + "&regnum=" + Request.QueryString["regnum"] + "&rekanan_ref=" + Request.QueryString["rekanan_ref"] + "&tc=" + Request.QueryString["tc"]+ "&view=" + Request.QueryString["view"]);}
			else
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}
	}
}
