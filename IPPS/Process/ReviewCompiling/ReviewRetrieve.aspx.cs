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
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;

namespace SME.IPPS.Process.ReviewCompiling
{
	/// <summary>
	/// Summary description for ReviewRetrieve.
	/// </summary>
	public class ReviewRetrieve : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.TextBox TXT_unit;
		protected System.Web.UI.WebControls.TextBox TXT_reference;
		protected System.Web.UI.WebControls.TextBox TXT_request_date;
		protected System.Web.UI.WebControls.DataGrid dg_list_retrieved;
		protected System.Web.UI.WebControls.Button btn_submit_wg;
		protected System.Web.UI.WebControls.Button BTN_RETRIEVE;
		protected System.Web.UI.WebControls.Button BTN_SUBMIT;
		protected System.Web.UI.WebControls.Button btn_retrieve;
		protected Tools tools = new Tools();
		protected System.Web.UI.WebControls.DropDownList ddl_request;
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			if(!IsPostBack)
			{
				fillField();
			}
			PopulateGrid(ddl_request.SelectedValue);
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '" + Request.QueryString["mc"] + "'";
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
							strtemp = "regno=" + Request.QueryString["regno"] +  "&tc=" + Request.QueryString["tc"] ;
						else	
							strtemp = "regno=" + Request.QueryString["regno"] +  "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i,3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		
		}

		private void fillField()
		{
			
			TXT_unit.Text = Request.QueryString["unit"];
			TXT_reference.Text = Request.QueryString["regno"];
			TXT_request_date.Text = Request.QueryString["initdate"];

			ddl_request.Items.Add(new ListItem("--Select--",""));
			conn.QueryString="EXEC IPPS_REQUESTLIST '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				ddl_request.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		private void PopulateGrid(string reqseq)
		{
			conn.QueryString = "EXEC IPPS_RETRIEVED_REVIEW '" + Request.QueryString["regno"] + "', '" + reqseq + "'";
			conn.ExecuteQuery();

			System.Data.DataTable dt =
				new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			dg_list_retrieved.DataSource = dt;

			try
			{
				dg_list_retrieved.DataBind();
			}
			catch
			{
				dg_list_retrieved.CurrentPageIndex = dg_list_retrieved.PageCount - 1;
				dg_list_retrieved.DataBind();
			}

			conn.ClearData();
			CekList(reqseq);

			
		}
	
		private void CekList(string reqseq)
		{
			conn.QueryString="select * from ipps_review where approve_date is null and ipps_regno='" +
								Request.QueryString["regno"]+ "' and req_seq='" + reqseq + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount()==0)
				BTN_SUBMIT.Visible=true;
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
			this.ddl_request.SelectedIndexChanged += new System.EventHandler(this.ddl_request_SelectedIndexChanged);
			this.dg_list_retrieved.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dg_list_retrieved_ItemCommand);
			this.dg_list_retrieved.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dg_list_retrieved_ItemDataBound);
			this.BTN_RETRIEVE.Click += new System.EventHandler(this.BTN_RETRIEVE_Click);
			this.BTN_SUBMIT.Click += new System.EventHandler(this.BTN_SUBMIT_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dg_list_retrieved_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":	
					Response.Redirect("ReviewEntryRetrieved.aspx?regno=" + Request.QueryString["regno"] + 
						"&reqseq=" + e.Item.Cells[0].Text + "&revseq=" + e.Item.Cells[1].Text 
						+ "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
					break;

				
			}
		
		}

		private void ddl_request_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			PopulateGrid(ddl_request.SelectedValue);
		}

		private void BTN_RETRIEVE_Click(object sender, System.EventArgs e)
		{
			PopulateGrid(ddl_request.SelectedValue);
		}

		private void BTN_SUBMIT_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString= " EXEC IPPS_UPDATE_TRACK '" + Request.QueryString["regno"] + "', '"
					+ "PP7.0" + "', '" + Session["UserID"].ToString() + "', ''";
				conn.ExecuteQuery();
			}
			catch(Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		private void dg_list_retrieved_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) 
			{
				System.Web.UI.WebControls.LinkButton view=(System.Web.UI.WebControls.LinkButton)e.Item.FindControl("view");
				
				e.Item.Cells[3].Text=tools.FormatDate(e.Item.Cells[3].Text,true);
				e.Item.Cells[4].Text=tools.FormatDate(e.Item.Cells[4].Text,true);
				
				if(e.Item.Cells[4].Text=="")
					view.Visible= false;
				else
					view.Visible= true;

				
			}
		}
	}
}
