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
using Microsoft.VisualBasic;

namespace SME.Facilities
{
	/// <summary>
	/// Summary description for InquiryStage.
	/// </summary>
	public partial class InquiryStage : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if(!IsPostBack)
			{
				IsiDDL();
				IsiGrid("00");
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

		}
		#endregion

		void IsiDDL()
		{
			conn.QueryString = "select * from rftrack where active = 1";
			conn.ExecuteQuery();
			DDL_STATUS.Items.Add(new ListItem("-- Select --",""));
			for (int i = 0 ; i < conn.GetRowCount();i++)
			{
				DDL_STATUS.Items.Add(new ListItem(conn.GetFieldValue(i,0)+" | "+conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
			conn.ClearData();
		}

		protected void BTN_VIEW_Click(object sender, System.EventArgs e)
		{
			IsiGrid(DDL_STATUS.SelectedValue);

		}

		void IsiGrid(string track)
		{
			DataTable dt = new DataTable();

			//mengakomodasi permintaan user
			// ahmad: begin ############################################################
			if (track == "5.4")
				conn.QueryString="SELECT * FROM VW_INQUIRY_STAGE2";
			else
				conn.QueryString="select distinct AP_REGNO, CU_REF, Nama, RM, convert(datetime,(convert(varchar, AP_CURRTRACKDATE, 112))) as AP_CURRTRACKDATE, "+
					"trackBy, AP_CURRTRACK from VW_INQUIRY_STAGE where AP_CURRTRACK = '"+ track +"'";

			conn.ExecuteQuery();
			// ahmad: end ############################################################
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			DatGrd.DataBind();
			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				LinkButton LbView = (LinkButton) DatGrd.Items[i].Cells[1].FindControl("LINK_VIEW");
				LbView.Text		  = DatGrd.Items[i].Cells[0].Text; 
			}
			TXT_AMOUNT.Text = conn.GetRowCount().ToString();
			conn.ClearData();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
					Response.Write("<script language='javascript'>window.open('ViewProduct.aspx?regno="+e.Item.Cells[0].Text+"&tc="+DDL_STATUS.SelectedValue+"','ViewProduct','status=no,scrollbars=yes,width=400,height=400');</script>");
					break;
			}		
		}
	}
}
