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
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for Memo2.
	/// </summary>
	public partial class Memo2 : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (Request.QueryString["de"] == "1")
				if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))	
					Response.Redirect("/SME/Restricted.aspx");

			isiGrid();
			ViewMenu();
			secureData();
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

		private void secureData() 
		{
			if (Request.QueryString["de"] != "1") 
			{
				BTN_SAVE.Visible = false;
				TXT_TM_CONTENT.Visible = false;
			}
		}

		void isiGrid()
		{
			DataTable dt = new DataTable();
			conn.QueryString="Select * from vw_memo where ap_regno='" + Request.QueryString["regno"] + "' order by tm_date desc";
			conn.ExecuteQuery();
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
				DatGrd.Items[i].Cells[2].Text = ""+tool.FormatDate_Day(DatGrd.Items[i].Cells[2].Text)+"-"+tool.FormatDate_MonthName(DatGrd.Items[i].Cells[2].Text)+"-"+tool.FormatDate_Year(DatGrd.Items[i].Cells[2].Text)+"";

				if (DatGrd.Items[i].Cells[7].Text.Trim()!=Session["UserID"].ToString().Trim())
					DatGrd.Items[i].Cells[6].Enabled = false;

				/////////////////////////////////////////////////////////////////////////////
				/// if it is read-only-mode (de != 1)
				/// then don't allow user to edit or delete memo
				/// 
				if (Request.QueryString["de"] != "1") 
				{
					LinkButton LINK_DELETE = (LinkButton) DatGrd.Items[i].FindControl("LINK_DELETE");
					LinkButton LINK_EDIT = (LinkButton) DatGrd.Items[i].FindControl("LINK_EDIT");

					LINK_DELETE.Visible = false;
					LINK_EDIT.Visible = false;
				}
			}
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
						//t.ForeColor = Color.MidnightBlue; 
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

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["par"] != null && Request.QueryString["par"] != "")  
				Response.Redirect(Request.QueryString["par"] + "&regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"]);
			else if (Request.QueryString["mc"] != "" && Request.QueryString["mc"] != null)
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn));			
			else
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));

		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string userid = Session["UserID"].ToString().Trim();
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "Delete":	
					if (e.Item.Cells[7].Text.Trim()==userid)
					{
						conn.QueryString="exec de_memo '"+ e.Item.Cells[0].Text +"',"+ tool.ConvertNum(e.Item.Cells[1].Text) +",'','','',1 ";
						conn.ExecuteQuery();
	
						int index = DatGrd.Items.Count;
						int jml = (index % 3)-1;
						if (jml == 0)
							DatGrd.CurrentPageIndex = index/3;
					}
					break;

				case "Edit":
					if (e.Item.Cells[7].Text.Trim()==userid)
					{
						conn.QueryString="select tm_content from vw_memo where ap_regno ='"+ e.Item.Cells[0].Text +"' and tm_seq = "+tool.ConvertNum(e.Item.Cells[1].Text)+" ";
						conn.ExecuteQuery();
						TXT_TM_CONTENT.Text = conn.GetFieldValue("tm_content");//"select tm_content from vw_memo where ap_regno ='"+ e.Item.Cells[0].Text +"' and tm_seq = "+tool.ConvertNum(e.Item.Cells[0].Text)+" ";//conn.GetFieldValue("TM_content");
						TXT_REGNO.Text = e.Item.Cells[0].Text;
						TXT_TMSEQ.Text = e.Item.Cells[1].Text;
						//Server.Transfer("Memo.aspx?Edit=1");
					}
					break;
				default:
					// Do nothing.
					break;
			}
			isiGrid();
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if (TXT_REGNO.Text =="")//insert
			{
				if (TXT_TM_CONTENT.Text.Trim() != "")
				{
					conn.QueryString="exec de_memo '" + Request.QueryString["regno"] + "','','','"+ TXT_TM_CONTENT.Text +"','" + Session["UserID"].ToString() + "',0";
					conn.ExecuteQuery();
					isiGrid();
				
				}
			}
			else //update
			{
				conn.QueryString="exec de_memo '" + Request.QueryString["regno"] + "',"+ tool.ConvertNum(TXT_TMSEQ.Text) +",'','"+ TXT_TM_CONTENT.Text +"','" + Session["UserID"].ToString() + "',2";
				conn.ExecuteQuery();
				isiGrid();
				TXT_REGNO.Text="";
				TXT_TMSEQ.Text="";
			}
			TXT_TM_CONTENT.Text="";
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			isiGrid();
		}

	}
}
