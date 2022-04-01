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
using System.IO;
using DMS.DBConnection;
using DMS.CuBESCore;
using Microsoft.VisualBasic;
using Earmarking;
using SME;

namespace SME.LOW.LPW
{
	/// <summary>
	/// Summary description for LOWNAKCreationList.
	/// </summary>
	public partial class LOWNAKCreationList : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			/*
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");
			*/
			conn.QueryString = "exec LOW_NAK_CUSTOMER_LIST '" + TXT_CU_CBI.Text + "','" + TXT_CU_CIF.Text + "','" + TXT_CU_NAME.Text + "','" + TXT_CU_NPWP.Text + "'";
			conn.ExecuteQuery();
			FillGrid(); 
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


		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string user = "";
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					conn.QueryString = "select customer.cu_rm, scuser.su_fullname, scuser.su_hpnum from customer left join " + 
						"scuser on customer.cu_rm = scuser.userid where cu_ref='" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					user = Session["UserID"].ToString();
					if ((conn.GetFieldValue(0,0) == "") || (conn.GetFieldValue(0,0) == Session["UserID"].ToString()))
					{
						//Generate AP_REGNO
						conn.QueryString = "exec GENERATE_ID '" + Session["BranchID"].ToString() + "', '0'";
						conn.ExecuteQuery();

						Response.Redirect("LOWMainSubmitNAK.aspx?regno=" + conn.GetFieldValue(0,0) + "&curef=" + e.Item.Cells[0].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&exist=1");
					}
					else
					{
						Response.Write("<script language='javascript'>alert('" + "This customer is owned by: " + conn.GetFieldValue("su_fullname") + " (" + conn.GetFieldValue("su_hpnum") + ")" + "');</script>");
					}
					break;

				case "delete":
					conn.QueryString = "delete application where cbi ='" + e.Item.Cells[1].Text +  "'";
					conn.ExecuteQuery();					
					break;
			}
		}


		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec LOW_NAK_CUSTOMER_LIST '" + TXT_CU_CBI.Text + "','" + TXT_CU_CIF.Text + "','" + TXT_CU_NAME.Text + "','" + TXT_CU_NPWP.Text + "'";
			conn.ExecuteQuery();
			FillGrid(); 
		}


		private void FillGrid()
		{
			try 
			{
				DataTable dt = new DataTable();
				dt = conn.GetDataTable().Copy();
				DatGrd.DataSource = dt;
				DatGrd.DataBind();				
			} 
			catch 
			{
				Tools.popMessage(this, "Error Grid !");
				return;
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			TXT_CU_CBI.Text = "";
			TXT_CU_CIF.Text = "";
			TXT_CU_NAME.Text = "";
			TXT_CU_NPWP.Text = "";
		}

	}
}
