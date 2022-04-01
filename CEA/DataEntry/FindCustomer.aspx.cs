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


namespace dbrbm.Data_Entry
{
	/// <summary>
	/// Summary description for FindCustomer.
	/// </summary>
	public partial class FindCustomer : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DatGrd_PendingApp;
		protected Tools tool = new Tools();

		protected Connection conn;
		protected Connection conn1;
		protected Connection conn2;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"] != null) 
					GlobalTools.popMessage(this, Request.QueryString["msg"]);

				DDL_BLN_LAHIR.Items.Add(new ListItem("--Pilih--",""));
				for (int i = 1; i <= 12; i++)
					DDL_BLN_LAHIR.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));	

				conn.QueryString="select distinct(rekanan_ref), namerekanan, id_number, rekanandesc from vw_rekanan_existing";
				conn.ExecuteQuery();
				FillGrid();

				DDL_JNS_REKANAN.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString="select rekananid, rekanandesc from rfjenisrekanan where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_JNS_REKANAN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

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

		}
		#endregion
		private void FillGrid()
		{
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
	
		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string area="";	
			string branch="";
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":	
					conn.QueryString = "select rfarea.areaid, rfarea.areaname from rekanan left outer join rfarea on rekanan.rekanan_wilayah=rfarea.areaid where rekanan_ref='" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					area = Session["AreaID"].ToString();
					branch = Session["BranchID"].ToString();
					if ((conn.GetFieldValue(0,0) == "") || (conn.GetFieldValue(0,0) == Session["AreaID"].ToString()) || Session["BranchID"].ToString() == "99999")
					{
						conn.QueryString = "exec REKANAN_GENERATE_ID '" + Session["BranchID"].ToString() + "', '0'";
						conn.ExecuteQuery();
						Response.Redirect("InfoRekanan.aspx?sta=exist&rekanan_ref=" + e.Item.Cells[0].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&regnum=" + conn.GetFieldValue(0,0) + "&exist=1");
								
					}
					else
					{
						Response.Write("<script language='javascript'>alert('" + "Rekanan ini merupakan rekanan: " + conn.GetFieldValue("areaname") + "');</script>");
					}
					break;
			}
		}

		protected void BTN_NEW_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec REKANAN_GENERATE_ID '" + Session["BranchID"].ToString() + "', '2'";
			conn.ExecuteQuery();
			Response.Redirect("InfoRekanan.aspx?regnum=" + conn.GetFieldValue(0,0) + "&rekanan_ref=" + conn.GetFieldValue(0,1) + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&exist=0");
		}
		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}
		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			DatGrd.CurrentPageIndex = 0;
			SearchData();
		}
		private void SearchData()
		{
			string query=""; 
			
			if(TXT_REK_NAME.Text!="")
			{
				query += "and namerekanan LIKE '%" + TXT_REK_NAME.Text + "%' ";
			}
			if(TXT_REK_ID.Text!="")
			{
				query += "and id_number='" + TXT_REK_ID.Text + "' ";
			}
			if(DDL_JNS_REKANAN.SelectedValue!="")
			{
				query += "and rfrekanantype='" + DDL_JNS_REKANAN.SelectedValue + "' ";
			}
			if(TXT_NoReg.Text!="")
			{
				query += "and rekanan_ref='" + TXT_NoReg.Text + "' ";
			}
			if(TXT_TGL_LAHIR.Text!="" || DDL_BLN_LAHIR.SelectedValue!="" || TXT_THN_LAHIR.Text!="")
			{
				if (!GlobalTools.isDateValid(TXT_TGL_LAHIR.Text, DDL_BLN_LAHIR.SelectedValue, TXT_THN_LAHIR.Text)) 
				{
					GlobalTools.popMessage(this, "Format tanggal tidak valid!");
					return;
				}
				query = query + " and tgl_lahir=" + tool.ConvertDate(TXT_TGL_LAHIR.Text,DDL_BLN_LAHIR.SelectedValue,TXT_THN_LAHIR.Text);
			}

			if(query!="")
			{
				conn.QueryString="select distinct(rekanan_ref), namerekanan, id_number, rekanandesc from vw_rekanan_existing where 1=1 " + query;
				conn.ExecuteQuery();
				FillGrid();
			}
			else
			{
				conn.QueryString="select distinct(rekanan_ref), namerekanan, id_number, rekanandesc from vw_rekanan_existing";
				conn.ExecuteQuery();
				FillGrid();
			}
		}


	}
}
