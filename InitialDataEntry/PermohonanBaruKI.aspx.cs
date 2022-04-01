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

namespace SME.InitialDataEntry
{
	/// <summary>
	/// Summary description for PermohonanBaruKI.
	/// </summary>
	public partial class PermohonanBaruKI : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{	
				LBL_USERID.Text = Session["UserID"].ToString();
				//DDL_APPTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_TYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CP_LOANPURPOSE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CP_TENOR.Items.Add(new ListItem("- PILIH -", ""));
				DDL_PRODUCTID.Items.Add(new ListItem("- PILIH -", ""));

				conn.QueryString = "select apptypeid, apptypedesc from rfapplicationtype where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_APPTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//--- Jenis Jaminan
				conn.QueryString = "select COLTYPESEQ, COLTYPEID + ' - ' + COLTYPEDESC from RFCOLLATERALTYPE where ACTIVE='1' order by COLTYPEID";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CL_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//--- Tujuan Penggunaan
				conn.QueryString = "select LOANPURPID, LOANPURPID+' - '+LOANPURPDESC as LOANPURPDESC from RFLOANPURPOSE where ACTIVE='1' order by LOANPURPDESC";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CP_LOANPURPOSE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select productid, productdesc from vw_progprod where programid='" + Request.QueryString["prog"] + "' and active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_PRODUCTID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				DDL_APPTYPE.SelectedValue = Request.QueryString["app"];
				DDL_PRODUCTID.SelectedValue = Request.QueryString["prod"];

				conn.QueryString = "select tenorseq, tenordesc from rftenor where productid='" + DDL_PRODUCTID.SelectedValue + "' and active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CP_TENOR.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				ViewCollateral();
				ViewApplications();
			}
			ViewMenu();
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


		private void ViewCollateral()
		{
			DataTable dt = new DataTable();
			conn.QueryString = "select * from vw_ide_listcollateral where cu_ref='" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			DatGrd.DataBind();

			for (int i = 0; i < DatGrd.Items.Count; i++)
				DatGrd.Items[i].Cells[2].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[2].Text);
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
			this.DATAGRID1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATAGRID1_ItemCommand);

		}
		#endregion

		private string getNextStepMsg(string regno) 
		{
			string pesan = "";
			string nextTrack = "";
			try 
			{
				/***
				 * Memunculkan pesan next step
				 ***/
				conn.QueryString = "exec TRACKNEXTMSG '" + regno + "'";
				conn.ExecuteQuery();
				nextTrack = conn.GetFieldValue("TRACKNAME");
				pesan = "Application proceeds to " + nextTrack;
				/***********************************/
			} 
			catch 
			{
				throw new Exception();
			}

			return pesan;
		}

		protected void DDL_PRODUCTID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*
			DDL_CP_TENOR.Items.Clear();
			DDL_CP_TENOR.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select tenorseq, tenordesc from rftenor where productid='" + DDL_PRODUCTID.SelectedValue + "' and active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CP_TENOR.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			*/
			
			if ((DDL_APPTYPE.SelectedValue != "") && (DDL_PRODUCTID.SelectedValue != ""))
			{
				conn.QueryString = "select screenlink from apptypelink where apptypeid='" + DDL_APPTYPE.SelectedValue + "' and productid='" + DDL_PRODUCTID.SelectedValue + "' and fungsiid='IDE'";
				conn.ExecuteQuery();
				string link = conn.GetFieldValue(0,0) + "?app=" + DDL_APPTYPE.SelectedValue + "&prod=" + DDL_PRODUCTID.SelectedValue;
				Response.Redirect(link + "&regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&prog=" + Request.QueryString["prog"] + "&tc=" + Request.QueryString["tc"]);
			}
		}

		protected void DDL_APPTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ((DDL_APPTYPE.SelectedValue != "") && (DDL_PRODUCTID.SelectedValue != ""))
			{
				conn.QueryString = "select screenlink from apptypelink where apptypeid='" + DDL_APPTYPE.SelectedValue + "' and productid='" + DDL_PRODUCTID.SelectedValue + "' and fungsiid='IDE' and [default]='1'";
				conn.ExecuteQuery();
				string link = conn.GetFieldValue(0,0) + "?app=" + DDL_APPTYPE.SelectedValue + "&prod=" + DDL_PRODUCTID.SelectedValue;
				Response.Redirect(link + "&regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&prog=" + Request.QueryString["prog"] + "&tc=" + Request.QueryString["tc"]);
			}
		}

		private void ViewApplications()
		{
			DataTable dt1 = new DataTable();
			conn.QueryString = "select * from vw_ide_listapplication where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			dt1 = conn.GetDataTable().Copy();
			DATAGRID1.DataSource = dt1;
			DATAGRID1.DataBind();

			/*
			for (int i = 0; i < DATAGRID1.Items.Count; i++)
			{
				DATAGRID1.Items[i].Cells[3].Text = tool.MoneyFormat(DATAGRID1.Items[i].Cells[3].Text);
				DATAGRID1.Items[i].Cells[4].Text = tool.MoneyFormat(DATAGRID1.Items[i].Cells[4].Text);
			}
			*/
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec IDE_LOANINFO_PBARUKI '" + Request.QueryString["regno"] + "', '" + 
				DDL_APPTYPE.SelectedValue + "', '" + DDL_PRODUCTID.SelectedValue + "', " + 
				TXT_CP_LIMIT.Text + ", " + DDL_CP_TENOR.SelectedValue + ", '" + DDL_CP_LOANPURPOSE.SelectedValue + "', '" + 
				TXT_CP_PROJADDR1.Text + "', '" + TXT_CP_PROJADDR2.Text + "', '" + 
				TXT_CP_PROJADDR3.Text + "', " + TXT_CP_PROJVALUE.Text;
			conn.ExecuteNonQuery();

			conn.QueryString = "insert into apptrack (ap_regno, apptype, productid, ap_currtrack, ap_currtrackdate, ap_currtrackby) " + 
				"values ('" + Request.QueryString["regno"] + "', '" + DDL_APPTYPE.SelectedValue + "', '" + 
				DDL_PRODUCTID.SelectedValue + "', '" + Request.QueryString["tc"] + "', '" + DateTime.Now + "', '" + LBL_USERID.Text + "')";
				//DDL_PRODUCTID.SelectedValue + "', '" + Request.QueryString["tc"] + "', '" + DateTime.Now + "', '" + Session["UserID"].ToString() + "')";
			conn.ExecuteNonQuery();

			ViewApplications();
		}

		protected void BTN_INSCOLL_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec IDE_LOANINFO_COLL '" + Request.QueryString["curef"] + "', '" +
				DDL_CL_TYPE.SelectedValue + "', '" + TXT_CL_VALUE.Text + "', " + 
				"null, '0'";
			conn.ExecuteNonQuery();
			ViewCollateral();
			try{DDL_CL_TYPE.SelectedValue = "";}
			catch{}
			TXT_CL_VALUE.Text = "";
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "exec IDE_LOANINFO_COLL '" + Request.QueryString["curef"] + "', '', null, " + 
						e.Item.Cells[0].Text + ", '2'";
					conn.ExecuteNonQuery();
					break;
			}
			ViewCollateral();
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			ViewCollateral();
		}

		protected void Button2_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("InfoPerusahaan.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&prog=" + Request.QueryString["prog"] + "&tc=" + Request.QueryString["tc"]);
		}

		private void DATAGRID1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "delete from custproduct where ap_regno='" + Request.QueryString["regno"] + "' and apptype='" + e.Item.Cells[1].Text + "' and productid='" + e.Item.Cells[3].Text + "'";
					conn.ExecuteNonQuery();
					
					conn.QueryString = "delete from apptrack where ap_regno='" + Request.QueryString["regno"] + "', and apptype='" + e.Item.Cells[1].Text + "' and productid='" + e.Item.Cells[3].Text + "'";
					conn.ExecuteNonQuery();
					break;
			}
			ViewApplications();
		}
	}
}
