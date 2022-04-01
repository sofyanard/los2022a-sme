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

namespace SME.CreditOperations.NotaryAssignment
{
	/// <summary>
	/// Summary description for NotaryLegalSigning.
	/// </summary>
	public partial class NotaryLegalSigning : System.Web.UI.Page
	{

		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				DocUpload1.GroupTemplate = "NTRUPLOAD";
				DocUpload1.WithReadExcel = false;

				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_TC.Text = Request.QueryString["tc"];
				
				DDL_NA_APPNTDATETIMEMONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_COVERDATE_MONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_FINISHDATE_MONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_PKDATE_MONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_COVERDUEDATE_MONTH.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_ORDERDATE_MONTH.Items.Add(new ListItem("-- Pilih --", ""));
				string nm_bln;
				for (int i=1; i<=12; i++)
				{
					nm_bln = DateAndTime.MonthName(i, false);
					DDL_NA_APPNTDATETIMEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_COVERDATE_MONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_FINISHDATE_MONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_PKDATE_MONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_COVERDUEDATE_MONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_ORDERDATE_MONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
				}

				//item pekerjaan
				conn.QueryString = "SELECT PEKERJAANID, PEKERJAANDESC FROM VW_RFPEKERJAAN ";
				conn.ExecuteQuery();
				DDL_NA_ITEM.Items.Clear();
				DDL_NA_ITEM.Items.Add(new ListItem("-- Pilih --", ""));
				for (int i=0; i<conn.GetRowCount(); i++)
					DDL_NA_ITEM.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//Collateral
				conn.QueryString = "SELECT COL_ID, COL_DESC FROM VW_NOTARYASSIGN_FILLDDLCOLLATERAL WHERE AP_REGNO = '" + 
					Request.QueryString["regno"] + "' ORDER BY CU_REF, CL_SEQ";
				conn.ExecuteQuery();
				DDL_COL.Items.Clear();
				DDL_COL.Items.Add(new ListItem("-- Pilih --", ""));
				for (int i=0; i<conn.GetRowCount(); i++)
					DDL_COL.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				ViewData();
				LBL_SEQ.Text = "";
				LBL_SUBSEQ.Text = "";

				
			}
			secureData();
			ViewMenu();
		}

		private void secureData() 
		{
			if (Request.QueryString["na"] == "0") 
			{
				BTN_SAVE.Visible = false;
				BTN_SAVE2.Visible = false;
				TXT_NA_APPNTDATETIMEDAY.ReadOnly = true;
				TXT_NA_APPNTDATETIMEHOUR.ReadOnly = true;
				TXT_NA_APPNTDATETIMEMINUTE.ReadOnly = true;
				TXT_NA_APPNTDATETIMEYEAR.ReadOnly = true;
				TXT_NA_REMARKS.ReadOnly = true;
				TXT_NT_ADDR1.ReadOnly = true;
				TXT_NT_ADDR2.ReadOnly = true;
				TXT_NT_ADDR3.ReadOnly = true;
				TXT_NT_CITY.ReadOnly = true;
				TXT_NT_EMAIL.ReadOnly = true;
				TXT_NT_FAXAREA.ReadOnly = true;
				TXT_NT_FAXNUM.ReadOnly = true;
				TXT_NT_PHNAREA.ReadOnly = true;
				TXT_NT_PHNEXT.ReadOnly = true;
				TXT_NT_PHNNUM.ReadOnly = true;
				TXT_NT_ZIPCODE.ReadOnly = true;
				DDL_NA_APPNTDATETIMEMONTH.Enabled = false;
				TXT_NA_COVERNO.ReadOnly = true;
				TXT_COVERDATE_DAY.ReadOnly = true;
				DDL_COVERDATE_MONTH.Enabled = false;
				TXT_COVERDATE_YEAR.ReadOnly = true;
				TXT_FINISHDATE_DAY.ReadOnly = true;
				DDL_FINISHDATE_MONTH.Enabled = false;
				TXT_FINISHDATE_YEAR.ReadOnly = true;
				TXT_PKDATE_DAY.ReadOnly = true;
				DDL_PKDATE_MONTH.Enabled = false;
				TXT_PKDATE_YEAR.ReadOnly = true;
				TXT_COVERDUEDATE_DAY.ReadOnly = true;
				DDL_COVERDUEDATE_MONTH.Enabled = false;
				TXT_COVERDUEDATE_YEAR.ReadOnly = true;
				TXT_ORDERDATE_DAY.ReadOnly = true;
				DDL_ORDERDATE_MONTH.Enabled = false;
				TXT_ORDERDATE_YEAR.ReadOnly = true;
				DDL_NA_ITEM.Enabled = false;
				TXT_NA_ORDERNO.ReadOnly = true;

				for(int i=0 ; i<DG_NOTARY.Items.Count; i++) 
				{
					if (Request.QueryString["sta"] == "view") 
					{
						LinkButton LNK_EDIT = (LinkButton) DG_NOTARY.Items[i].FindControl("BTNEDIT");
						LinkButton LNK_DELETE = (LinkButton) DG_NOTARY.Items[i].FindControl("BTNDEL");

						LNK_EDIT.Text = "View";
						LNK_DELETE.Visible = false;
					}
				}

				for(int j=0 ; j<DG_PROCESS.Items.Count; j++) 
				{
					if (Request.QueryString["sta"] == "view") 
					{
						LinkButton LNK_EDIT2 = (LinkButton) DG_PROCESS.Items[j].FindControl("BTNEDIT2");
						LinkButton LNK_DELETE2 = (LinkButton) DG_PROCESS.Items[j].FindControl("BTNDEL2");

						LNK_EDIT2.Text = "View";
						LNK_DELETE2.Visible = false;
					}
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
						if (conn.GetFieldValue(i,3).IndexOf("na=") < 0) strtemp += "&" + Request.QueryString["na"];
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

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM VW_NOTARY_ASSIGN_VIEWDATA WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' ORDER BY SEQ";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_NOTARY.DataSource = dt;
			try 
			{
				DG_NOTARY.DataBind();
			} 
			catch 
			{
				DG_NOTARY.CurrentPageIndex = 0;
				DG_NOTARY.DataBind();
			}

			for (int i=0;i<DG_NOTARY.Items.Count;i++)
			{
				LinkButton lbdel = (LinkButton)DG_NOTARY.Items[i].Cells[9].FindControl("BTNDEL");
				lbdel.Attributes.Add("onclick","if(!deleteconfirm()){return false;};");
			}

			ViewData2();
		}

		private void ViewData2()
		{
			for (int i=0;i<DG_NOTARY.Items.Count;i++)
			{
				DataGrid dgdet = (DataGrid) DG_NOTARY.Items[i].Cells[8].FindControl("DG_DETAIL");

				conn.QueryString = "SELECT * FROM VW_NOTARY_ASSIGN_VIEWDATA2 WHERE AP_REGNO = '" + 
					DG_NOTARY.Items[i].Cells[0].Text.Trim() + "' AND SEQ = '" + DG_NOTARY.Items[i].Cells[1].Text.Trim() + "'";
				conn.ExecuteQuery();

				DataTable dtdet = new DataTable();
				dtdet = conn.GetDataTable().Copy();

				dgdet.DataSource = dtdet;
				try 
				{
					dgdet.DataBind();
				} 
				catch 
				{
					dgdet.CurrentPageIndex = 0;
					dgdet.DataBind();
				}
			}
		}

		private void ViewDetail()
		{
			conn.QueryString = "SELECT * FROM VW_NOTARY_ASSIGN_VIEWDATA2 WHERE AP_REGNO = '" + 
				LBL_REGNO.Text + "' AND SEQ = '" + LBL_SEQ.Text + "'";
			conn.ExecuteQuery();

			DataTable dtdet = new DataTable();
			dtdet = conn.GetDataTable().Copy();

			DG_PROCESS.DataSource = dtdet;
			try 
			{
				DG_PROCESS.DataBind();
			} 
			catch 
			{
				DG_PROCESS.CurrentPageIndex = 0;
				DG_PROCESS.DataBind();
			}
		}

		private void fillNTData()
		{
			conn.QueryString = "select * from RFNOTARY "+
				"where NTID = '"+ TXT_NTID.Text +"' ";
			conn.ExecuteQuery();
			TXT_NT_NAME.Text = conn.GetFieldValue("NT_NAME");
			TXT_NT_ADDR1.Text = conn.GetFieldValue("NT_ADDR1");
			TXT_NT_ADDR2.Text = conn.GetFieldValue("NT_ADDR2");
			TXT_NT_ADDR3.Text = conn.GetFieldValue("NT_ADDR3");
			TXT_NT_CITY.Text = conn.GetFieldValue("NT_CITY");
			TXT_NT_EMAIL.Text = conn.GetFieldValue("NT_EMAIL");
			TXT_NT_PHNAREA.Text = conn.GetFieldValue("NT_PHNAREA");
			TXT_NT_PHNNUM.Text = conn.GetFieldValue("NT_PHNNUM");
			TXT_NT_PHNEXT.Text = conn.GetFieldValue("NT_PHNEXT");
			TXT_NT_FAXAREA.Text = conn.GetFieldValue("NT_FAXAREA");
			TXT_NT_FAXNUM.Text = conn.GetFieldValue("NT_FAXNUM");
			TXT_NT_ZIPCODE.Text = conn.GetFieldValue("NT_ZIPCODE");
		}

		private string validateSQLString(string str)
		{
			return str.Replace("'", "''");
		}

		private void ClearEntryNotary()
		{
			TXT_NTID.Text = "";
			TXT_NT_NAME.Text = "";
			TXT_NT_ADDR1.Text = "";
			TXT_NT_ADDR2.Text = "";
			TXT_NT_ADDR3.Text = "";
			TXT_NT_CITY.Text = "";
			TXT_NT_EMAIL.Text = "";
			TXT_NT_PHNAREA.Text = "";
			TXT_NT_PHNNUM.Text = "";
			TXT_NT_PHNEXT.Text = "";
			TXT_NT_FAXAREA.Text = "";
			TXT_NT_FAXNUM.Text = "";
			TXT_NT_ZIPCODE.Text = "";

			LBL_SEQ.Text = "";
			TXT_NA_APPNTDATETIMEDAY.Text = "";
			try {DDL_NA_APPNTDATETIMEMONTH.SelectedValue = "";}
			catch {}
			TXT_NA_APPNTDATETIMEYEAR.Text = "";
			TXT_NA_APPNTDATETIMEHOUR.Text = "";
			TXT_NA_APPNTDATETIMEMINUTE.Text = "";
			TXT_NA_REMARKS.Text = "";

			try {DDL_COL.SelectedValue = "";} 
			catch{}
			TXT_NA_COVERNO.Text = "";
			TXT_COVERDATE_DAY.Text = "";
			try {DDL_COVERDATE_MONTH.SelectedValue = "";}
			catch {}
			TXT_COVERDATE_YEAR.Text = "";
			TXT_COVERDUEDATE_DAY.Text = "";
			try {DDL_COVERDUEDATE_MONTH.SelectedValue = "";}
			catch {}
			TXT_COVERDUEDATE_YEAR.Text = "";
			TXT_NA_ORDERNO.Text = "";
			TXT_ORDERDATE_DAY.Text = "";
			try {DDL_ORDERDATE_MONTH.SelectedValue = "";}
			catch {}
			TXT_ORDERDATE_YEAR.Text = "";
			TXT_PKDATE_DAY.Text = "";
			try {DDL_PKDATE_MONTH.SelectedValue = "";}
			catch {}
			TXT_PKDATE_YEAR.Text = "";
		}

		private void ClearEntryDetail()
		{
			LBL_SUBSEQ.Text = "";
			try {DDL_NA_ITEM.SelectedValue = "";}
			catch {}
			TXT_FINISHDATE_DAY.Text = "";
			DDL_FINISHDATE_MONTH.SelectedValue = "";
			TXT_FINISHDATE_YEAR.Text = "";
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
    		base.OnInit(e);
            if (!this.DesignMode)
            {
                InitializeComponent();
            }
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.DG_NOTARY.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DG_NOTARY_ItemCreated);
			this.DG_NOTARY.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_NOTARY_ItemCommand);
			this.DG_NOTARY.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_NOTARY_PageIndexChanged);
			this.DG_PROCESS.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_PROCESS_ItemCommand);
			this.DG_PROCESS.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_PROCESS_PageIndexChanged);

		}
		#endregion

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "exec LGL_NTASSIGN '"+ LBL_REGNO.Text + "', '" + LBL_SEQ.Text + "', '" + TXT_NTID.Text.Trim() + "', " +
					tool.ConvertDate(TXT_NA_APPNTDATETIMEDAY.Text, DDL_NA_APPNTDATETIMEMONTH.SelectedValue, 
					TXT_NA_APPNTDATETIMEYEAR.Text, TXT_NA_APPNTDATETIMEHOUR.Text, TXT_NA_APPNTDATETIMEMINUTE.Text) +
					", '" +	validateSQLString(TXT_NA_REMARKS.Text) +"', '" + Session["UserID"] +
					"', '" + TXT_NA_COVERNO.Text +
					"', " + tool.ConvertDate(TXT_COVERDATE_DAY.Text, DDL_COVERDATE_MONTH.SelectedValue, TXT_COVERDATE_YEAR.Text) +
					", " + tool.ConvertDate(TXT_COVERDUEDATE_DAY.Text, DDL_COVERDUEDATE_MONTH.SelectedValue, TXT_COVERDUEDATE_YEAR.Text) +
					", '" + TXT_NA_ORDERNO.Text +
					"', " + tool.ConvertDate(TXT_ORDERDATE_DAY.Text, DDL_ORDERDATE_MONTH.SelectedValue, TXT_ORDERDATE_YEAR.Text) +
					", " + tool.ConvertDate(TXT_PKDATE_DAY.Text, DDL_PKDATE_MONTH.SelectedValue, TXT_PKDATE_YEAR.Text) +
					", '" + DDL_COL.SelectedValue.Trim() + "'";
				conn.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
			ClearEntryNotary();
			ClearEntryDetail();
			ViewData();
			ViewDetail();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(),Request.QueryString["mc"].ToString(), conn));
		}

		protected void TXT_NTID_TextChanged(object sender, System.EventArgs e)
		{
			fillNTData();
		}

		private void DG_NOTARY_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			DataGrid dgdet = (DataGrid) e.Item.FindControl("DG_DETAIL");
			if (dgdet != null)
			{
				dgdet.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdet_PageIndexChanged);
			}
		}

		private void DG_NOTARY_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_NOTARY.CurrentPageIndex = e.NewPageIndex;
			ViewData();
			secureData();
		}

		private void dgdet_PageIndexChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			dg.CurrentPageIndex = e.NewPageIndex;
			ViewData2();
			secureData();
		}

		private void DG_NOTARY_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					try
					{
						LBL_SEQ.Text = e.Item.Cells[1].Text;
						TXT_NTID.Text = e.Item.Cells[2].Text;
						fillNTData();

						conn.QueryString = "SELECT * FROM VW_NOTARY_ASSIGN_VIEWDATA WHERE AP_REGNO = '" + 
							Request.QueryString["regno"] + "' AND SEQ = '" + LBL_SEQ.Text + "'";
						conn.ExecuteQuery();

						string NA_APPNTDATETIME = conn.GetFieldValue("NA_APPNTDATETIME");
						TXT_NA_APPNTDATETIMEDAY.Text = tool.FormatDate_Day(NA_APPNTDATETIME);
						DDL_NA_APPNTDATETIMEMONTH.SelectedValue = tool.FormatDate_Month(NA_APPNTDATETIME);
						TXT_NA_APPNTDATETIMEYEAR.Text = tool.FormatDate_Year(NA_APPNTDATETIME);
						TXT_NA_APPNTDATETIMEHOUR.Text = tool.FormatDate_Hour(NA_APPNTDATETIME);
						TXT_NA_APPNTDATETIMEMINUTE.Text = tool.FormatDate_Minute(NA_APPNTDATETIME);
						TXT_NA_REMARKS.Text = conn.GetFieldValue("NA_REMARKS");
						TXT_COVERDATE_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("NA_COVERDATE"));
						DDL_COVERDATE_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("NA_COVERDATE"));
						TXT_COVERDATE_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("NA_COVERDATE"));
						TXT_PKDATE_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("NA_PKDATE"));
						DDL_PKDATE_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("NA_PKDATE"));
						TXT_PKDATE_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("NA_PKDATE"));
						TXT_COVERDUEDATE_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("NA_COVERDUEDATE"));
						DDL_COVERDUEDATE_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("NA_COVERDUEDATE"));
						TXT_COVERDUEDATE_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("NA_COVERDUEDATE"));
						TXT_ORDERDATE_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("NA_ORDERDATE"));
						DDL_ORDERDATE_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("NA_ORDERDATE"));
						TXT_ORDERDATE_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("NA_ORDERDATE"));
						TXT_NA_COVERNO.Text = conn.GetFieldValue("NA_COVERNO");
						TXT_NA_ORDERNO.Text = conn.GetFieldValue("NA_ORDERNO");
						try {DDL_COL.SelectedValue = conn.GetFieldValue("CU_REF") + "-" + conn.GetFieldValue("CL_SEQ");}
						catch {}

						ViewDetail();
					}
					catch (Exception ex)
					{
						Response.Write("<!--" + ex.Message + "-->");
					}
					break;

				case "delete":
					try
					{
						conn.QueryString = "EXEC LGL_NTASSIGN_DELETE '" +
							Request.QueryString["regno"] + "', '" +
							e.Item.Cells[1].Text + "'";
						conn.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						return;
					}

					ViewData();
					ViewDetail();
					ClearEntryNotary();
					ClearEntryDetail();
					break;
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearEntryNotary();
			ClearEntryDetail();
			ViewDetail();
		}

		protected void BTN_SAVE2_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "exec LGL_NTASSIGN_DETAIL '" + 
					LBL_REGNO.Text + "', '" + 
					LBL_SEQ.Text + "', '" + 
					LBL_SUBSEQ.Text + "', " + 
					tool.ConvertDate(TXT_FINISHDATE_DAY.Text, DDL_FINISHDATE_MONTH.SelectedValue, TXT_FINISHDATE_YEAR.Text) + ", '" + 
					DDL_NA_ITEM.SelectedValue + "'";
				conn.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
			ViewData();
			ViewDetail();
			ClearEntryDetail();
		}

		private void DG_PROCESS_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_PROCESS.CurrentPageIndex = e.NewPageIndex;
			ViewDetail();
			secureData();
		}

		private void DG_PROCESS_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					try
					{
						LBL_SUBSEQ.Text = e.Item.Cells[2].Text;
						try {DDL_NA_ITEM.SelectedValue = e.Item.Cells[3].Text;}
						catch {}
						TXT_FINISHDATE_DAY.Text = tool.FormatDate_Day(e.Item.Cells[5].Text);
						DDL_FINISHDATE_MONTH.SelectedValue = tool.FormatDate_Month(e.Item.Cells[5].Text);
						TXT_FINISHDATE_YEAR.Text = tool.FormatDate_Year(e.Item.Cells[5].Text);
					}
					catch (Exception ex)
					{
						Response.Write("<!--" + ex.Message + "-->");
					}
					break;

				case "delete":
					try
					{
						conn.QueryString = "EXEC LGL_NTASSIGN_DETAIL_DELETE '" +
							Request.QueryString["regno"] + "', '" +
							e.Item.Cells[1].Text + "', '" +
							e.Item.Cells[2].Text + "'";
						conn.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						return;
					}

					ViewData();
					ViewDetail();
					ClearEntryDetail();
					break;
			}
		}

		protected void BTN_CLEAR2_Click(object sender, System.EventArgs e)
		{
			ClearEntryDetail();
		}
	}
}
