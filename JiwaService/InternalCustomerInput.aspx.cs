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

namespace SME.JiwaService
{
	/// <summary>
	/// Summary description for InternalCustomerInput.
	/// </summary>
	public partial class InternalCustomerInput : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if(!IsPostBack)
			{
				TXT_ID.Text = "2";
				FillGridCust();
				CheckCutOff();
			}
		}

		private void CheckCutOff()
		{
			try
			{
				conn.QueryString = "exec JWS_CEK_DATE '" + TXT_ID.Text + "'";
				conn.ExecuteNonQuery();
				return;
			}
			catch(Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);

				FillGridCutOff();
			}
		}

		private void FillGridCutOff()
		{
			conn.QueryString = "SELECT * FROM VW_JWS_INTERNALCUST WHERE 0=1";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
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

		private void FillGridCust()
		{
			System.Web.UI.WebControls.Image ImgAppr;
			
			conn.QueryString = "SELECT * FROM VW_JWS_INTERNALCUST WHERE CODE='" + Session["BranchID"].ToString() + "'";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
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

			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				ImgAppr	= (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[6].FindControl("IMG_INTERNAL_STATUS");				
				Label LblAppr	= (Label) DatGrd.Items[i].Cells[6].FindControl("LBL_INTERNAL_STATUS");

				if(DatGrd.Items[i].Cells[7].Text == "1")
				{						
					ImgAppr.ImageUrl = "../image/Complete.gif";
					LblAppr.Text = "Done";
				}
				else 
				{
					ImgAppr.ImageUrl = "../image/UnComplete.gif";
					LblAppr.Text = "Not Done";
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);

		}
		#endregion

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			FillGridCust();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					Response.Redirect("DetailScoring.aspx?sta=exist&seq=" + e.Item.Cells[0].Text + "&gc=" + e.Item.Cells[1].Text + "&dc=" + e.Item.Cells[3].Text + "&userid=" + e.Item.Cells[5].Text + "&mc=" + Request.QueryString["mc"] + "&exist=1");
					break;
			}
		}
	}
}
