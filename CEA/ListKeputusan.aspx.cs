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


namespace SME.CEA
{
	/// <summary>
	/// Summary description for ListKeputusan.
	/// </summary>
	public partial class ListKeputusan : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/../SME/Restricted.aspx");

			if(!IsPostBack)
			{
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"] != null) 
					GlobalTools.popMessage(this, Request.QueryString["msg"]);

				//conn.QueryString = "SELECT REKANAN_REF, REGNUM, NAMEREKANAN, ID_NUMBER, REKANANDESC FROM VW_REKANAN_COMPANY WHERE NAMEREKANAN LIKE '%" + TXT_REK_NAME.Text + "%' AND AP_CURRTRACK='A1.4'";
				//conn.QueryString += "UNION SELECT REKANAN_REF, REGNUM, NAMEREKANAN, ID_NUMBER, REKANANDESC FROM VW_REKANAN_PERSONAL WHERE NAMEREKANAN LIKE '%" + TXT_REK_NAME.Text + "%' AND AP_CURRTRACK='A1.4'";

				if(Session["BranchID"].ToString() == "99999")
					conn.QueryString = "select * from vw_rekanan_search where ap_currtrack='A1.4'";
				else
					conn.QueryString = "select * from vw_rekanan_search where ap_currtrack='A1.4' and areaid='" + Session["AreaID"].ToString() + "'";
				conn.ExecuteQuery();
				FillGrid();
			}
		}

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

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			DatGrd.CurrentPageIndex = 0;
			SearchData();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string area="";
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":	
					conn.QueryString = "select rfarea.areaid, rfarea.areaname from rekanan left outer join rfarea on rekanan.rekanan_wilayah=rfarea.areaid where rekanan_ref='" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					area = Session["AreaID"].ToString();
					if ((conn.GetFieldValue(0,0) == "") || (conn.GetFieldValue(0,0) == Session["AreaID"].ToString()) || Session["BranchID"].ToString() == "99999")
					{
						conn.QueryString = "exec REKANAN_GENERATE_ID '" + Session["BranchID"].ToString() + "', '0'";
						conn.ExecuteQuery();
						Response.Redirect("KeputusanMain.aspx?rekanan_ref=" + e.Item.Cells[0].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&regnum=" + e.Item.Cells[1].Text);
								
					}
					else
					{
						Response.Write("<script language='javascript'>alert('" + "Rekanan ini merupakan rekanan: " + conn.GetFieldValue("areaname") + "');</script>");
					}
					break;
			}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void SearchData()
		{
			//conn.QueryString = "SELECT REKANAN_REF, REGNUM, NAMEREKANAN, ID_NUMBER, REKANANDESC FROM VW_REKANAN_COMPANY WHERE NAMEREKANAN LIKE '%" + TXT_REK_NAME.Text + "%' AND AP_CURRTRACK='A1.4'";
			//conn.QueryString += "UNION SELECT REKANAN_REF, REGNUM, NAMEREKANAN, ID_NUMBER, REKANANDESC FROM VW_REKANAN_PERSONAL WHERE NAMEREKANAN LIKE '%" + TXT_REK_NAME.Text + "%' AND AP_CURRTRACK='A1.4'";
			conn.QueryString = "select * from vw_rekanan_search where NAMEREKANAN LIKE '%" + TXT_REK_NAME.Text + "%' and ap_currtrack='A1.4' and areaid='" + Session["AreaID"].ToString() + "'";
			conn.ExecuteQuery();
			FillGrid();
		}

	}
}
