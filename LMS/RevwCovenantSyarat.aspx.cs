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

namespace SME.LMS
{
	/// <summary>
	/// Summary description for RevwCovenantSyarat.
	/// </summary>
	public partial class RevwCovenantSyarat : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				ViewDataPK();
				ViewDataTerbit();
				ViewDataLain();
			}

			ViewMenu();
			SecureData();
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

		private void SecureData() 
		{
			if (Request.QueryString["cov"] != null)
			{
				if (Request.QueryString["cov"] == "1") //Risk
				{
					BTNSAVE_PK.Enabled = false;
					BTNSAVE_TERBIT.Enabled = false;
					BTNSAVE_LAIN.Enabled = true;

					for (int i=0;i<DatGrd_PK.Items.Count;i++)
					{
						DatGrd_PK.Items[i].Cells[7].Enabled = false;
						DatGrd_PK.Items[i].Cells[8].Enabled = false;
						DatGrd_PK.Items[i].Cells[9].Enabled = false;
						DatGrd_PK.Items[i].Cells[10].Enabled = false;
					}

					for (int i=0;i<DATGRID_TERBIT.Items.Count;i++)
					{
						DATGRID_TERBIT.Items[i].Cells[7].Enabled = false;
						DATGRID_TERBIT.Items[i].Cells[8].Enabled = false;
						DATGRID_TERBIT.Items[i].Cells[9].Enabled = false;
						DATGRID_TERBIT.Items[i].Cells[10].Enabled = false;
					}

					for (int i=0;i<DATGRID_LAIN.Items.Count;i++)
					{
						DATGRID_LAIN.Items[i].Cells[7].Enabled = true;
						DATGRID_LAIN.Items[i].Cells[8].Enabled = true;
						DATGRID_LAIN.Items[i].Cells[9].Enabled = true;
						DATGRID_LAIN.Items[i].Cells[10].Enabled = true;
					}
				}
				else if (Request.QueryString["cov"] == "2") //CO
				{
					BTNSAVE_PK.Enabled = true;
					BTNSAVE_TERBIT.Enabled = true;
					BTNSAVE_LAIN.Enabled = false;

					for (int i=0;i<DatGrd_PK.Items.Count;i++)
					{
						DatGrd_PK.Items[i].Cells[7].Enabled = true;
						DatGrd_PK.Items[i].Cells[8].Enabled = true;
						DatGrd_PK.Items[i].Cells[9].Enabled = true;
						DatGrd_PK.Items[i].Cells[10].Enabled = true;
					}

					for (int i=0;i<DATGRID_TERBIT.Items.Count;i++)
					{
						DATGRID_TERBIT.Items[i].Cells[7].Enabled = true;
						DATGRID_TERBIT.Items[i].Cells[8].Enabled = true;
						DATGRID_TERBIT.Items[i].Cells[9].Enabled = true;
						DATGRID_TERBIT.Items[i].Cells[10].Enabled = true;
					}

					for (int i=0;i<DATGRID_LAIN.Items.Count;i++)
					{
						DATGRID_LAIN.Items[i].Cells[7].Enabled = false;
						DATGRID_LAIN.Items[i].Cells[8].Enabled = false;
						DATGRID_LAIN.Items[i].Cells[9].Enabled = false;
						DATGRID_LAIN.Items[i].Cells[10].Enabled = false;
					}
				}
			}
			else
			{
				BTNSAVE_PK.Enabled = false;
				BTNSAVE_TERBIT.Enabled = false;
				BTNSAVE_LAIN.Enabled = false;

				for (int i=0;i<DatGrd_PK.Items.Count;i++)
				{
					DatGrd_PK.Items[i].Cells[7].Enabled = false;
					DatGrd_PK.Items[i].Cells[8].Enabled = false;
					DatGrd_PK.Items[i].Cells[9].Enabled = false;
					DatGrd_PK.Items[i].Cells[10].Enabled = false;
				}

				for (int i=0;i<DATGRID_TERBIT.Items.Count;i++)
				{
					DATGRID_TERBIT.Items[i].Cells[7].Enabled = false;
					DATGRID_TERBIT.Items[i].Cells[8].Enabled = false;
					DATGRID_TERBIT.Items[i].Cells[9].Enabled = false;
					DATGRID_TERBIT.Items[i].Cells[10].Enabled = false;
				}

				for (int i=0;i<DATGRID_LAIN.Items.Count;i++)
				{
					DATGRID_LAIN.Items[i].Cells[7].Enabled = false;
					DATGRID_LAIN.Items[i].Cells[8].Enabled = false;
					DATGRID_LAIN.Items[i].Cells[9].Enabled = false;
					DATGRID_LAIN.Items[i].Cells[10].Enabled = false;
				}
			}
		}

		private void ViewDataPK()
		{
			conn.QueryString = "SELECT * FROM VW_REVWCOVSYARAT WHERE AP_REGNO ='" + Request.QueryString["regno"] + "' AND DOCTYPEID = '4'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrd_PK.DataSource = dt;
			try 
			{
				DatGrd_PK.DataBind();
			} 
			catch 
			{
				DatGrd_PK.CurrentPageIndex = 0;
				DatGrd_PK.DataBind();
			}

			for (int i = 0; i < DatGrd_PK.Items.Count; i++)
			{
				int Count = i+1;
				DatGrd_PK.Items[i].Cells[3].Text = Count.ToString();
			}

			ViewDataPKDoc();
			ViewDataPKCov();
			SecureData();
		}

		private void ViewDataTerbit()
		{
			conn.QueryString = "SELECT * FROM VW_REVWCOVSYARAT WHERE AP_REGNO ='" + Request.QueryString["regno"] + "' AND DOCTYPEID = '5'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DATGRID_TERBIT.DataSource = dt;
			try 
			{
				DATGRID_TERBIT.DataBind();
			} 
			catch 
			{
				DATGRID_TERBIT.CurrentPageIndex = 0;
				DATGRID_TERBIT.DataBind();
			}

			for (int i = 0; i < DATGRID_TERBIT.Items.Count; i++)
			{
				int Count = i+1;
				DATGRID_TERBIT.Items[i].Cells[3].Text = Count.ToString();
			}

			ViewDataTerbitDoc();
			ViewDataTerbitCov();
			SecureData();
		}

		private void ViewDataLain()
		{
			conn.QueryString = "SELECT * FROM VW_REVWCOVSYARAT WHERE AP_REGNO ='" + Request.QueryString["regno"] + "' AND DOCTYPEID = '6'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DATGRID_LAIN.DataSource = dt;
			try 
			{
				DATGRID_LAIN.DataBind();
			} 
			catch 
			{
				DATGRID_LAIN.CurrentPageIndex = 0;
				DATGRID_LAIN.DataBind();
			}

			for (int i = 0; i < DATGRID_LAIN.Items.Count; i++)
			{
				int Count = i+1;
				DATGRID_LAIN.Items[i].Cells[3].Text = Count.ToString();
			}

			ViewDataLainDoc();
			ViewDataLainCov();
			SecureData();
		}

		private void ViewDataPKDoc()
		{
			for (int i=0;i<DatGrd_PK.Items.Count;i++)
			{
				DataGrid dgpkdoc = (DataGrid) DatGrd_PK.Items[i].Cells[7].FindControl("DG_PKDOC");

				conn.QueryString = "SELECT * FROM VW_SYARAT_DOC WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND DOCTYPEID = '4' AND COVSEQ = '" + DatGrd_PK.Items[i].Cells[2].Text.Trim() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtpkdoc = new DataTable();
					dtpkdoc = conn.GetDataTable().Copy();
					dgpkdoc.DataSource = dtpkdoc;
					try 
					{
						dgpkdoc.DataBind();
					} 
					catch 
					{
						dgpkdoc.CurrentPageIndex = 0;
						dgpkdoc.DataBind();
					}

					for (int j = 0; j < dgpkdoc.Items.Count; j++)
					{
						int n = j+1;
						dgpkdoc.Items[j].Cells[2].Text = n.ToString();
						HyperLink HpDownload = (HyperLink) dgpkdoc.Items[j].Cells[4].FindControl("HL_DOWNLOAD1");
						HpDownload.NavigateUrl = dgpkdoc.Items[j].Cells[7].Text.Trim();
					}
				}
			}
		}

		private void ViewDataTerbitDoc()
		{
			for (int i=0;i<DATGRID_TERBIT.Items.Count;i++)
			{
				DataGrid dgterbitdoc = (DataGrid) DATGRID_TERBIT.Items[i].Cells[7].FindControl("DG_TERBITDOC");

				conn.QueryString = "SELECT * FROM VW_SYARAT_DOC WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND DOCTYPEID = '5' AND COVSEQ = '" + DATGRID_TERBIT.Items[i].Cells[2].Text.Trim() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtterbitdoc = new DataTable();
					dtterbitdoc = conn.GetDataTable().Copy();
					dgterbitdoc.DataSource = dtterbitdoc;
					try 
					{
						dgterbitdoc.DataBind();
					} 
					catch 
					{
						dgterbitdoc.CurrentPageIndex = 0;
						dgterbitdoc.DataBind();
					}

					for (int j = 0; j < dgterbitdoc.Items.Count; j++)
					{
						int n = j+1;
						dgterbitdoc.Items[j].Cells[2].Text = n.ToString();
						HyperLink HpDownload = (HyperLink) dgterbitdoc.Items[j].Cells[4].FindControl("HL_DOWNLOAD2");
						HpDownload.NavigateUrl = dgterbitdoc.Items[j].Cells[7].Text.Trim();
					}
				}
			}
		}

		private void ViewDataLainDoc()
		{
			for (int i=0;i<DATGRID_LAIN.Items.Count;i++)
			{
				DataGrid dglaindoc = (DataGrid) DATGRID_LAIN.Items[i].Cells[7].FindControl("DG_LAINDOC");

				conn.QueryString = "SELECT * FROM VW_SYARAT_DOC WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND DOCTYPEID = '6' AND COVSEQ = '" + DATGRID_LAIN.Items[i].Cells[2].Text.Trim() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtlaindoc = new DataTable();
					dtlaindoc = conn.GetDataTable().Copy();
					dglaindoc.DataSource = dtlaindoc;
					try 
					{
						dglaindoc.DataBind();
					} 
					catch 
					{
						dglaindoc.CurrentPageIndex = 0;
						dglaindoc.DataBind();
					}

					for (int j = 0; j < dglaindoc.Items.Count; j++)
					{
						int n = j+1;
						dglaindoc.Items[j].Cells[2].Text = n.ToString();
						HyperLink HpDownload = (HyperLink) dglaindoc.Items[j].Cells[4].FindControl("HL_DOWNLOAD3");
						HpDownload.NavigateUrl = dglaindoc.Items[j].Cells[7].Text.Trim();
					}
				}
			}
		}

		private void ViewDataPKCov()
		{
			for (int i=0;i<DatGrd_PK.Items.Count;i++)
			{
				TextBox txtnextdate_day = (TextBox) DatGrd_PK.Items[i].Cells[9].FindControl("TXT_PK_NEXTDATE_DAY");
				DropDownList ddlnextdate_month = (DropDownList) DatGrd_PK.Items[i].Cells[9].FindControl("DDL_PK_NEXTDATE_MONTH");
				TextBox txtnextdate_year = (TextBox) DatGrd_PK.Items[i].Cells[9].FindControl("TXT_PK_NEXTDATE_YEAR");

				txtnextdate_day.Text = tools.FormatDate_Day(DatGrd_PK.Items[i].Cells[11].Text);
				try {ddlnextdate_month.SelectedValue = tools.FormatDate_Month(DatGrd_PK.Items[i].Cells[11].Text);}
				catch {}
				txtnextdate_year.Text = tools.FormatDate_Year(DatGrd_PK.Items[i].Cells[11].Text);

				CheckBox chkcovfinish = (CheckBox) DatGrd_PK.Items[i].Cells[10].FindControl("CHK_PK_ISFINISH");

				if (DatGrd_PK.Items[i].Cells[12].Text == "1")
					chkcovfinish.Checked = true;
				else
					chkcovfinish.Checked = false;
			}
		}

		private void ViewDataTerbitCov()
		{
			for (int i=0;i<DATGRID_TERBIT.Items.Count;i++)
			{
				TextBox txtnextdate_day = (TextBox) DATGRID_TERBIT.Items[i].Cells[9].FindControl("TXT_TERBIT_NEXTDATE_DAY");
				DropDownList ddlnextdate_month = (DropDownList) DATGRID_TERBIT.Items[i].Cells[9].FindControl("DDL_TERBIT_NEXTDATE_MONTH");
				TextBox txtnextdate_year = (TextBox) DATGRID_TERBIT.Items[i].Cells[9].FindControl("TXT_TERBIT_NEXTDATE_YEAR");

				txtnextdate_day.Text = tools.FormatDate_Day(DATGRID_TERBIT.Items[i].Cells[11].Text);
				try {ddlnextdate_month.SelectedValue = tools.FormatDate_Month(DATGRID_TERBIT.Items[i].Cells[11].Text);}
				catch {}
				txtnextdate_year.Text = tools.FormatDate_Year(DATGRID_TERBIT.Items[i].Cells[11].Text);

				CheckBox chkcovfinish = (CheckBox) DATGRID_TERBIT.Items[i].Cells[10].FindControl("CHK_TERBIT_ISFINISH");

				if (DATGRID_TERBIT.Items[i].Cells[12].Text == "1")
					chkcovfinish.Checked = true;
				else
					chkcovfinish.Checked = false;
			}
		}

		private void ViewDataLainCov()
		{
			for (int i=0;i<DATGRID_LAIN.Items.Count;i++)
			{
				TextBox txtnextdate_day = (TextBox) DATGRID_LAIN.Items[i].Cells[9].FindControl("TXT_LAIN_NEXTDATE_DAY");
				DropDownList ddlnextdate_month = (DropDownList) DATGRID_LAIN.Items[i].Cells[9].FindControl("DDL_LAIN_NEXTDATE_MONTH");
				TextBox txtnextdate_year = (TextBox) DATGRID_LAIN.Items[i].Cells[9].FindControl("TXT_LAIN_NEXTDATE_YEAR");

				txtnextdate_day.Text = tools.FormatDate_Day(DATGRID_LAIN.Items[i].Cells[11].Text);
				try {ddlnextdate_month.SelectedValue = tools.FormatDate_Month(DATGRID_LAIN.Items[i].Cells[11].Text);}
				catch {}
				txtnextdate_year.Text = tools.FormatDate_Year(DATGRID_LAIN.Items[i].Cells[11].Text);

				CheckBox chkcovfinish = (CheckBox) DATGRID_LAIN.Items[i].Cells[10].FindControl("CHK_LAIN_ISFINISH");

				if (DATGRID_LAIN.Items[i].Cells[12].Text == "1")
					chkcovfinish.Checked = true;
				else
					chkcovfinish.Checked = false;
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
			this.DatGrd_PK.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DatGrd_PK_ItemCreated);
			this.DatGrd_PK.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_PK_ItemCommand);
			this.DatGrd_PK.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PK_PageIndexChanged);
			this.DATGRID_TERBIT.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DATGRID_TERBIT_ItemCreated);
			this.DATGRID_TERBIT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATGRID_TERBIT_ItemCommand);
			this.DATGRID_TERBIT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATGRID_TERBIT_PageIndexChanged);
			this.DATGRID_LAIN.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DATGRID_LAIN_ItemCreated);
			this.DATGRID_LAIN.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATGRID_LAIN_ItemCommand);
			this.DATGRID_LAIN.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATGRID_LAIN_PageIndexChanged);

		}
		#endregion

		private void DatGrd_PK_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Upload":
					Response.Write("<script language='javascript'>window.open('../CreditProposal/SyaratUploadFile.aspx?regno=" + Request.QueryString["regno"] + "&doctype=4&covseq=" + e.Item.Cells[2].Text + "&theForm=Form1&theObj=TXT_TEMP_PK','UploadDocument','status=no,scrollbars=yes,width=800,height=600');</script>");
					break;
			}
		}

		private void DATGRID_TERBIT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Upload":
					Response.Write("<script language='javascript'>window.open('../CreditProposal/SyaratUploadFile.aspx?regno=" + Request.QueryString["regno"] + "&doctype=5&covseq=" + e.Item.Cells[2].Text + "&theForm=Form1&theObj=TXT_TEMP_TERBIT','UploadDocument','status=no,scrollbars=yes,width=800,height=600');</script>");
					break;
			}
		}

		private void DATGRID_LAIN_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Upload":
					Response.Write("<script language='javascript'>window.open('../CreditProposal/SyaratUploadFile.aspx?regno=" + Request.QueryString["regno"] + "&doctype=6&covseq=" + e.Item.Cells[2].Text + "&theForm=Form1&theObj=TXT_TEMP_LAIN','UploadDocument','status=no,scrollbars=yes,width=800,height=600');</script>");
					break;
			}
		}

		private void DatGrd_PK_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd_PK.CurrentPageIndex = e.NewPageIndex;
			ViewDataPK();
			SecureData();
		}

		private void DATGRID_TERBIT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATGRID_TERBIT.CurrentPageIndex = e.NewPageIndex;
			ViewDataTerbit();
			SecureData();
		}

		private void DATGRID_LAIN_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATGRID_LAIN.CurrentPageIndex = e.NewPageIndex;
			ViewDataLain();
			SecureData();
		}

		private void DatGrd_PK_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			DataGrid dgpkdoc = (DataGrid) e.Item.FindControl("DG_PKDOC");
			if (dgpkdoc != null)
			{
				dgpkdoc.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgpkdoc_ItemDataBound);
				dgpkdoc.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgpkdoc_ItemCommand);
				dgpkdoc.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgpkdoc_PageIndexChanged);
			}

			DropDownList ddlnextdate = (DropDownList) e.Item.FindControl("DDL_PK_NEXTDATE_MONTH");
			if (ddlnextdate != null)
			{
				ddlnextdate.Items.Add(new ListItem("- SELECT -", ""));
				for (int i = 1; i <= 12; i++)
				{
					ddlnextdate.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
			}
		}

		private void dgpkdoc_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
		}

		private void dgpkdoc_ItemCommand(object sender, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					try
					{
						conn.QueryString = "EXEC SYARAT_DOC_DELETE '" +
							Request.QueryString["regno"] + "', '4', '" +
							e.Item.Cells[0].Text + "', '" +
							e.Item.Cells[1].Text + "'";
						conn.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						Response.Write("<!--" + ex.Message + "-->");
						Tools.popMessage(this,"Delete Error!!");
					}

					ViewDataPK();
					break;
			}
		}

		private void dgpkdoc_PageIndexChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			dg.CurrentPageIndex = e.NewPageIndex;
			ViewDataPKDoc();
			SecureData();
		}

		protected void TXT_TEMP_PK_TextChanged(object sender, System.EventArgs e)
		{
			ViewDataPK();
			SecureData();
			TXT_TEMP_PK.Text = "";
		}

		private void DATGRID_TERBIT_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			DataGrid dgterbitdoc = (DataGrid) e.Item.FindControl("DG_TERBITDOC");
			if (dgterbitdoc != null)
			{
				dgterbitdoc.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgterbitdoc_ItemDataBound);
				dgterbitdoc.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgterbitdoc_ItemCommand);
				dgterbitdoc.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgterbitdoc_PageIndexChanged);
			}

			DropDownList ddlnextdate = (DropDownList) e.Item.FindControl("DDL_TERBIT_NEXTDATE_MONTH");
			if (ddlnextdate != null)
			{
				ddlnextdate.Items.Add(new ListItem("- SELECT -", ""));
				for (int i = 1; i <= 12; i++)
				{
					ddlnextdate.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
			}
		}

		private void dgterbitdoc_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
		}

		private void dgterbitdoc_ItemCommand(object sender, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					try
					{
						conn.QueryString = "EXEC SYARAT_DOC_DELETE '" +
							Request.QueryString["regno"] + "', '5', '" +
							e.Item.Cells[0].Text + "', '" +
							e.Item.Cells[1].Text + "'";
						conn.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						Response.Write("<!--" + ex.Message + "-->");
						Tools.popMessage(this,"Delete Error!!");
					}

					ViewDataTerbit();
					break;
			}
		}

		private void dgterbitdoc_PageIndexChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			dg.CurrentPageIndex = e.NewPageIndex;
			ViewDataTerbitDoc();
			SecureData();
		}

		protected void TXT_TEMP_TERBIT_TextChanged(object sender, System.EventArgs e)
		{
			ViewDataTerbit();
			SecureData();
			TXT_TEMP_TERBIT.Text = "";
		}

		private void DATGRID_LAIN_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			DataGrid dglaindoc = (DataGrid) e.Item.FindControl("DG_LAINDOC");
			if (dglaindoc != null)
			{
				dglaindoc.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dglaindoc_ItemDataBound);
				dglaindoc.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dglaindoc_ItemCommand);
				dglaindoc.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dglaindoc_PageIndexChanged);
			}

			DropDownList ddlnextdate = (DropDownList) e.Item.FindControl("DDL_LAIN_NEXTDATE_MONTH");
			if (ddlnextdate != null)
			{
				ddlnextdate.Items.Add(new ListItem("- SELECT -", ""));
				for (int i = 1; i <= 12; i++)
				{
					ddlnextdate.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
			}
		}

		private void dglaindoc_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
		}

		private void dglaindoc_ItemCommand(object sender, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					try
					{
						conn.QueryString = "EXEC SYARAT_DOC_DELETE '" +
							Request.QueryString["regno"] + "', '6', '" +
							e.Item.Cells[0].Text + "', '" +
							e.Item.Cells[1].Text + "'";
						conn.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						Response.Write("<!--" + ex.Message + "-->");
						Tools.popMessage(this,"Delete Error!!");
					}

					ViewDataLain();
					break;
			}
		}

		private void dglaindoc_PageIndexChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			dg.CurrentPageIndex = e.NewPageIndex;
			ViewDataLainDoc();
			SecureData();
		}

		protected void TXT_TEMP_LAIN_TextChanged(object sender, System.EventArgs e)
		{
			ViewDataLain();
			SecureData();
			TXT_TEMP_LAIN.Text = "";
		}

		protected void BTNSAVE_PK_Click(object sender, System.EventArgs e)
		{
			string nextdate = null, isfinish = null;
			try
			{
				for (int i=0; i<DatGrd_PK.Items.Count; i++)
				{
					if ((DatGrd_PK.Items[i].Cells[9].Visible == true) && (DatGrd_PK.Items[i].Cells[10].Visible == true))
					{
						TextBox txtnextdate_day = (TextBox) DatGrd_PK.Items[i].Cells[9].FindControl("TXT_PK_NEXTDATE_DAY");
						DropDownList ddlnextdate_month = (DropDownList) DatGrd_PK.Items[i].Cells[9].FindControl("DDL_PK_NEXTDATE_MONTH");
						TextBox txtnextdate_year = (TextBox) DatGrd_PK.Items[i].Cells[9].FindControl("TXT_PK_NEXTDATE_YEAR");
						CheckBox chkcovfinish = (CheckBox) DatGrd_PK.Items[i].Cells[10].FindControl("CHK_PK_ISFINISH");

						if ((txtnextdate_day != null) && (ddlnextdate_month != null) && (txtnextdate_year != null))
						{
							if (GlobalTools.isDateValid(this, txtnextdate_day.Text.Trim(), ddlnextdate_month.SelectedValue.Trim(), txtnextdate_year.Text.Trim())) 
							{
								nextdate = tools.ConvertDate(txtnextdate_day.Text, ddlnextdate_month.SelectedValue, txtnextdate_year.Text);
							}
							else
							{
								nextdate = "''";
							}
						}
						else
						{
							nextdate = null;
						}

						if (chkcovfinish != null)
						{
							if (chkcovfinish.Checked == true)
								isfinish = "1";
							else
								isfinish = "0";
						}
						else
						{
							isfinish = null;
						}
					}
					else
					{
						return;
					}

					conn.QueryString = "EXEC COVENANT_SAVEREVIEW_CO '" +
						Request.QueryString["regno"] + "', '4', '" +
						DatGrd_PK.Items[i].Cells[2].Text.Trim() + "', " +
						nextdate + ", '" +
						isfinish + "'";
					conn.ExecuteNonQuery();
				}

				ViewDataPK();
				SecureData();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
				Tools.popMessage(this,"Insert Error!!");
			}
		}

		protected void BTNSAVE_TERBIT_Click(object sender, System.EventArgs e)
		{
			string nextdate = null, isfinish = null;
			try
			{
				for (int i=0; i<DATGRID_TERBIT.Items.Count; i++)
				{
					if ((DATGRID_TERBIT.Items[i].Cells[9].Visible == true) && (DATGRID_TERBIT.Items[i].Cells[10].Visible == true))
					{
						TextBox txtnextdate_day = (TextBox) DATGRID_TERBIT.Items[i].Cells[9].FindControl("TXT_TERBIT_NEXTDATE_DAY");
						DropDownList ddlnextdate_month = (DropDownList) DATGRID_TERBIT.Items[i].Cells[9].FindControl("DDL_TERBIT_NEXTDATE_MONTH");
						TextBox txtnextdate_year = (TextBox) DATGRID_TERBIT.Items[i].Cells[9].FindControl("TXT_TERBIT_NEXTDATE_YEAR");
						CheckBox chkcovfinish = (CheckBox) DATGRID_TERBIT.Items[i].Cells[10].FindControl("CHK_TERBIT_ISFINISH");

						if ((txtnextdate_day != null) && (ddlnextdate_month != null) && (txtnextdate_year != null))
						{
							if (GlobalTools.isDateValid(this, txtnextdate_day.Text.Trim(), ddlnextdate_month.SelectedValue.Trim(), txtnextdate_year.Text.Trim())) 
							{
								nextdate = tools.ConvertDate(txtnextdate_day.Text, ddlnextdate_month.SelectedValue, txtnextdate_year.Text);
							}
							else
							{
								nextdate = "''";
							}
						}
						else
						{
							nextdate = null;
						}

						if (chkcovfinish != null)
						{
							if (chkcovfinish.Checked == true)
								isfinish = "1";
							else
								isfinish = "0";
						}
						else
						{
							isfinish = null;
						}
					}
					else
					{
						return;
					}

					conn.QueryString = "EXEC COVENANT_SAVEREVIEW_CO '" +
						Request.QueryString["regno"] + "', '5', '" +
						DATGRID_TERBIT.Items[i].Cells[2].Text.Trim() + "', " +
						nextdate + ", '" +
						isfinish + "'";
					conn.ExecuteNonQuery();
				}

				ViewDataTerbit();
				SecureData();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
				Tools.popMessage(this,"Insert Error!!");
			}
		}

		protected void BTNSAVE_LAIN_Click(object sender, System.EventArgs e)
		{
			string nextdate = null, isfinish = null;
			try
			{
				for (int i=0; i<DATGRID_LAIN.Items.Count; i++)
				{
					if ((DATGRID_LAIN.Items[i].Cells[9].Visible == true) && (DATGRID_LAIN.Items[i].Cells[10].Visible == true))
					{
						TextBox txtnextdate_day = (TextBox) DATGRID_LAIN.Items[i].Cells[9].FindControl("TXT_LAIN_NEXTDATE_DAY");
						DropDownList ddlnextdate_month = (DropDownList) DATGRID_LAIN.Items[i].Cells[9].FindControl("DDL_LAIN_NEXTDATE_MONTH");
						TextBox txtnextdate_year = (TextBox) DATGRID_LAIN.Items[i].Cells[9].FindControl("TXT_LAIN_NEXTDATE_YEAR");
						CheckBox chkcovfinish = (CheckBox) DATGRID_LAIN.Items[i].Cells[10].FindControl("CHK_LAIN_ISFINISH");

						if ((txtnextdate_day != null) && (ddlnextdate_month != null) && (txtnextdate_year != null))
						{
							if (GlobalTools.isDateValid(this, txtnextdate_day.Text.Trim(), ddlnextdate_month.SelectedValue.Trim(), txtnextdate_year.Text.Trim())) 
							{
								nextdate = tools.ConvertDate(txtnextdate_day.Text, ddlnextdate_month.SelectedValue, txtnextdate_year.Text);
							}
							else
							{
								nextdate = "''";
							}
						}
						else
						{
							nextdate = null;
						}

						if (chkcovfinish != null)
						{
							if (chkcovfinish.Checked == true)
								isfinish = "1";
							else
								isfinish = "0";
						}
						else
						{
							isfinish = null;
						}
					}
					else
					{
						return;
					}

					conn.QueryString = "EXEC COVENANT_SAVEREVIEW_CO '" +
						Request.QueryString["regno"] + "', '6', '" +
						DATGRID_LAIN.Items[i].Cells[2].Text.Trim() + "', " +
						nextdate + ", '" +
						isfinish + "'";
					conn.ExecuteNonQuery();
				}

				ViewDataLain();
				SecureData();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
				Tools.popMessage(this,"Insert Error!!");
			}
		}
	}
}
