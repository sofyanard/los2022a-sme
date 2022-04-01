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
namespace SME.ITTP
{
	/// <summary>
	/// Summary description for ApprovalHistory.
	/// </summary>
	public partial class ApprovalHistory : System.Web.UI.Page
	{
		#region "My Variables"
		private Connection conn;
		private Tools tool = new Tools();
		private string REGNO, CUREF, TC, USERID, MC;
		#endregion
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			REGNO		= Request.QueryString["regno"];
			CUREF		= Request.QueryString["curef"];
			TC			= Request.QueryString["tc"];
			USERID		= Session["USERID"].ToString();
			MC			= Request.QueryString["mc"];

			if (!IsPostBack) 
			{
				viewData();								
			}

			//viewMenu();
		}

		private void viewData() 
		{
			try 
			{
				conn.QueryString = "SELECT * FROM VW_IT_APPROVALDECISION " +
					"WHERE SU_FULLNAME = '" + USERID + "' " +
					//"AND USERID <> '" + USERID + "' " +
					"ORDER BY AD_SEQ, APPTYPE, PRODUCTID, PROD_SEQ";
				conn.ExecuteQuery();

				DGR_LIST.DataSource = conn.GetDataTable().DefaultView;
				DGR_LIST.DataBind();
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}
		}
/*
		private void viewMenu() 
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
*/

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
/*
		private void DGR_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (e.CommandName.ToString()) 
			{
				case "view":					
					string queryLink = "";
					if (e.Item.Cells[1].Text == "01") //Permohonan Baru 
					{
						conn.QueryString = "select iscashloan from rfproduct where productid='" + e.Item.Cells[2].Text + "'";
						conn.ExecuteQuery();
						if (conn.GetFieldValue(0,0) == "0")	//Non Cash Loan
							queryLink = "select screenlink from apptypelink where APPTYPEID = '"+ e.Item.Cells[1].Text + "' and fungsiId='APPRV' and iscashloan='0'";
						else	// Cash Loan
							queryLink = "select screenlink from apptypelink where APPTYPEID = '"+ e.Item.Cells[1].Text + "' and fungsiId='APPRV' and iscashloan='1'";
					}
					else //Non Permohonan Baru
					{
						queryLink = "select screenlink from apptypelink where APPTYPEID = '"+ e.Item.Cells[1].Text + "' and fungsiId='APPRV' ";
					}

					try 
					{
						conn.QueryString = queryLink;
						conn.ExecuteQuery();
					}
					catch (NullReferenceException) 
					{
						GlobalTools.popMessage(this, "Connection Error!");
						Response.Redirect("../Login.aspx?expire=1");
					}

					Response.Write("<script for=window event=onload language='javascript'>" + 
						"PopupPage('" + conn.GetFieldValue("screenlink")+
						"?regno="+ REGNO +
						"&curef="+ CUREF +
						"&ad_seq=" + e.Item.Cells[0].Text + 
						"&apptype="+ e.Item.Cells[1].Text +
						"&prod="+ e.Item.Cells[2].Text +
						"&prod_seq="+ e.Item.Cells[3].Text +
						"&teks="+ e.Item.Cells[5].Text + 
						"&sta=view" + "', '900', '500');</script>");
					break;
			}
		}
*/
//		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
//		{
//			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn));

			//Response.Redirect("ListApproval.aspx?tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"]);
//		}
	}
}