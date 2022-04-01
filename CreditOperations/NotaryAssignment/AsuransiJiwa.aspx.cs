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

namespace SME.CreditOperations.NotaryAssignment
{
	/// <summary>
	/// Summary description for AsuransiJiwa.
	/// </summary>
	public partial class AsuransiJiwa : System.Web.UI.Page
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
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_TC.Text = Request.QueryString["tc"];

				//init rfrating
				conn.QueryString = "SELECT RATEID, RATEDESC FROM RFRATING ";
				conn.ExecuteQuery();
				DDL_ICRATE.Items.Clear();
				DDL_ICRATE.Items.Add(new ListItem("-- Pilih --", ""));
				for (int i=0; i<conn.GetRowCount(); i++)
					DDL_ICRATE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//init CUR_ID
				//--- Mata Uang
				conn.QueryString = "select CURRENCYID, CURRENCYID + ' - ' + CURRENCYDESC as CURRENCYDESC from RFCURRENCY where ACTIVE = '1' order by CURRENCYID";
				conn.ExecuteQuery();
				DDL_CP_CUR.Items.Clear();
				DDL_CP_CUR.Items.Add(new ListItem("- PILIH -", ""));
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					String s0 = conn.GetFieldValue(i,0),
						s1 = conn.GetFieldValue(i,1);
					ListItem li = new ListItem(s1,s0);
					DDL_CP_CUR.Items.Add(li);
				}

				Tools.initDateForm(TXT_DATESTART_DAY, DDL_DATESTART_MONTH, TXT_DATESTART_YEAR, false);
				Tools.initDateForm(TXT_DATEEND_DAY, DDL_DATEEND_MONTH, TXT_DATEEND_YEAR, false);

				fillInsrComp();
				bindData();
			}
			ViewMenu();
			DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
			BTN_CANCEL.Click += new EventHandler(BTN_CANCEL_Click);
			BTN_TAMBAH.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1)){return false;};");
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
						if (conn.GetFieldValue(i,3).IndexOf("?na=")<0 && conn.GetFieldValue(i,3).IndexOf("&na=")<0)
							strtemp = strtemp + "&na=" + Request.QueryString["na"];
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

		private void fillInsrComp()
		{
			conn.QueryString = "select distinct IC_ID, IC_DESC "+
				"from VW_CREOPR_NOTARYASSIGN_RFINSRCOMPANY_INSURANCE ";
			conn.ExecuteQuery();
			DDL_AP_INSRCOMP.Items.Clear();
			DDL_AP_INSRCOMP.Items.Add(new ListItem("-- Pilih --",""));
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				String s0 = conn.GetFieldValue(i,0),
					s1 = conn.GetFieldValue(i,1);
				ListItem li = new ListItem(s1,s0);
				DDL_AP_INSRCOMP.Items.Add(li);
			}
			fillInsrType();
		}

		private void fillInsrType()
		{
			DDL_CP_INSRTYPE.Items.Clear();
			if (DDL_AP_INSRCOMP.SelectedValue.Trim() == "")
				return;
			conn.QueryString = "select distinct IT_ID, IT_DESC from VW_CREOPR_NOTARYASSIGN_RFINSRTYPE_INSURANCE "+
				"where IC_ID = '" + DDL_AP_INSRCOMP.SelectedValue.Trim() + "' ";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				String s0 = conn.GetFieldValue(i,0),
					s1 = conn.GetFieldValue(i,1);
				ListItem li = new ListItem(s1,s0);
				DDL_CP_INSRTYPE.Items.Add(li);
			}
		}

		private void bindData()
		{
			DataTable dt = new DataTable();
			DataRow dr;
			conn.QueryString = "SELECT SEQ, IC_DESC IC_DESC, IT_DESC, ALI_AMOUNT, ALI_PERCENTAGE, ALI_PREMI, "+
				"IC_ID, IT_ID, ALI_ICRATE, CURRENCYID, CURRENCYDESC, "+
				"ALI_POLICYNO, ALI_DATESTART, ALI_DATEEND " +
				"FROM VW_CREOPR_NOTARYASSIGN_INSURANCE WHERE AP_REGNO = '" + Request.QueryString["regno"] +
				"' ORDER BY IC_DESC ";
			conn.ExecuteQuery();
			dt.Columns.Add(new DataColumn("SEQ"));
			dt.Columns.Add(new DataColumn("INSRCOMPDESC"));
			dt.Columns.Add(new DataColumn("INSRTYPEDESC"));
			dt.Columns.Add(new DataColumn("AN_VALUE"));
			dt.Columns.Add(new DataColumn("AN_PERCENTAGE"));
			dt.Columns.Add(new DataColumn("AN_PREMI"));
			dt.Columns.Add(new DataColumn("IC_ID"));
			dt.Columns.Add(new DataColumn("IT_ID"));
			dt.Columns.Add(new DataColumn("RATE"));
			dt.Columns.Add(new DataColumn("CUR_ID"));
			dt.Columns.Add(new DataColumn("AN_CUR"));
			dt.Columns.Add(new DataColumn("AN_POLICYNO"));
			dt.Columns.Add(new DataColumn("AN_DATESTART"));
			dt.Columns.Add(new DataColumn("AN_DATEEND"));
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				dr = dt.NewRow();
				for (int j = 0; j < conn.GetColumnCount(); j++)
				{
					dr[j] = conn.GetFieldValue(i,j);
				}
				dt.Rows.Add(dr);
			}
			DataGrid1.DataSource = new DataView(dt);
			try
			{
				DataGrid1.DataBind();
			}
			catch 
			{
				DataGrid1.CurrentPageIndex = DataGrid1.PageCount - 1;
				DataGrid1.DataBind();
			}
			for (int j = 0; j < DataGrid1.Items.Count; j++)
			{
				DataGrid1.Items[j].Cells[5].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[5].Text );
				DataGrid1.Items[j].Cells[8].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[8].Text );
				DataGrid1.Items[j].Cells[9].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[9].Text );
			}
		}

		private void clearEditBoxes()
		{
			try
			{
				DDL_AP_INSRCOMP.SelectedIndex = 0;
				DDL_CP_INSRTYPE.Items.Clear();
				DDL_ICRATE.SelectedIndex = 0;
				DDL_DATESTART_MONTH.SelectedIndex = 0;
				DDL_DATEEND_MONTH.SelectedIndex = 0;
				DDL_CP_CUR.SelectedIndex = 0;
			}
			catch {}
			TXT_CP_POLICYNO.Text = "";
			TXT_AP_INSRAMNT.Text = "";
			TXT_AP_INSRPREMI.Text = "";
			TXT_AP_INSRPCT.Text = "";
			TXT_DATESTART_DAY.Text = "";
			TXT_DATESTART_YEAR.Text = "";
			TXT_DATEEND_DAY.Text = "";
			TXT_DATEEND_YEAR.Text = "";
			LBL_H_SEQ.Text = "0";
			BTN_TAMBAH.Text = "Tambah";
			BTN_CANCEL.Visible = false;
		}

		private string validateSQLString(string str)
		{
			return str.Replace("'", "''");
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);

		}
		#endregion

		void Grid_Change(Object sender, DataGridPageChangedEventArgs e) 
		{
			// Set CurrentPageIndex to the page the user clicked.
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData();	
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string regno, seq, cu_ref;
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "print":
					//Response.Redirect("../CoverNote/AsuransiJiwa.aspx?ap_regno=" + LBL_REGNO.Text + "&cu_ref=" + LBL_CUREF.Text + "&seq=" + e.Item.Cells[0].Text.Trim());
					regno = LBL_REGNO.Text.Trim();
					cu_ref = this.LBL_CUREF.Text.Trim();			
					seq = e.Item.Cells[0].Text.Trim();
					Response.Write("<script language='javascript'>window.open('../CoverNote/AsuransiJiwa.aspx?seq=" + seq + "&regno=" + regno + "&cu_ref=" + cu_ref + "','AsuransiJiwa','status=no,scrollbars=yes,width=800,height=600');</script>");
					break;

				case "delete":
					regno = LBL_REGNO.Text.Trim();
					seq = e.Item.Cells[0].Text.Trim();
					//delete data
					conn.QueryString = "delete from APPLIFEINSURANCE where AP_REGNO = '" +
						regno + "' AND SEQ = " + seq;
					conn.ExecuteNonQuery();
					bindData();
					break;

				case "edit":
					LBL_H_SEQ.Text = e.Item.Cells[0].Text.Trim();
					try
					{
						DDL_AP_INSRCOMP.SelectedValue = e.Item.Cells[10].Text.Trim();
						fillInsrType();
					} 
					catch {}
					try
					{
						DDL_CP_INSRTYPE.SelectedValue = e.Item.Cells[11].Text.Trim();
					} 
					catch {}
					try
					{
						DDL_ICRATE.SelectedValue = e.Item.Cells[12].Text.Trim();
					} 
					catch {}
					try
					{
						DDL_CP_CUR.SelectedValue = e.Item.Cells[13].Text.Trim();
					} 
					catch {}
					TXT_AP_INSRAMNT.Text = e.Item.Cells[5].Text.Trim();
					try
					{
						TXT_DATESTART_DAY.Text = tool.FormatDate_Day(e.Item.Cells[6].Text.Trim());
						DDL_DATESTART_MONTH.SelectedValue = tool.FormatDate_Month(e.Item.Cells[6].Text.Trim());
						TXT_DATESTART_YEAR.Text = tool.FormatDate_Year(e.Item.Cells[6].Text.Trim());
					} 
					catch {}
					try
					{
						TXT_DATEEND_DAY.Text = tool.FormatDate_Day(e.Item.Cells[7].Text.Trim());
						DDL_DATEEND_MONTH.SelectedValue = tool.FormatDate_Month(e.Item.Cells[7].Text.Trim());
						TXT_DATEEND_YEAR.Text = tool.FormatDate_Year(e.Item.Cells[7].Text.Trim());
					} 
					catch {}
					TXT_AP_INSRPCT.Text = e.Item.Cells[8].Text.Trim();
					TXT_AP_INSRPREMI.Text = e.Item.Cells[9].Text.Trim();
					TXT_CP_POLICYNO.Text = e.Item.Cells[3].Text.Trim();
					BTN_TAMBAH.Text = "Save";
					BTN_CANCEL.Visible = true;
					break;

				default:
					// Do nothing.
					break;
			}

		}

		protected void BTN_TAMBAH_Click(object sender, System.EventArgs e)
		{
			string str = "";
			double val;
			string regno=LBL_REGNO.Text.Trim(),
				seq = LBL_H_SEQ.Text.Trim(),
				compname=DDL_AP_INSRCOMP.SelectedValue.Trim(),
				insrtype=DDL_CP_INSRTYPE.SelectedValue.Trim(),
				insramount=tool.ConvertFloat(TXT_AP_INSRAMNT.Text.Trim()),
				insrpct=TXT_AP_INSRPCT.Text.Trim(),
				insrpremi=tool.ConvertFloat(TXT_AP_INSRPREMI.Text.Trim()),
				rate=DDL_ICRATE.SelectedValue.Trim(),
				insrpolicyno=validateSQLString(TXT_CP_POLICYNO.Text.Trim()),
				insrcur=DDL_CP_CUR.SelectedValue.Trim(),
				insrdatestart="",
				insrdateend="";

			try
			{
				insrdatestart=Tools.toSQLDate(TXT_DATESTART_DAY,DDL_DATESTART_MONTH,TXT_DATESTART_YEAR);
			}
			catch {}
			try
			{
				insrdateend=Tools.toSQLDate(TXT_DATEEND_DAY,DDL_DATEEND_MONTH,TXT_DATEEND_YEAR);
			}
			catch {}

			if (insrpct.Trim() == "") insrpct = "0";

			// Nama Perusahaan asuransi tidak boleh kosong
			if (compname == "")
				str += "Nama Perusahaan Asuransi harus dipilih! ";

			val = -1;
			try {val = double.Parse(insrpct);} 
			catch {}


			// Persentase pertanggungan tidak boleh lebih dari 100%
			if ((val < 0)||(val > 100)) str += "Persentase Pertanggungan tidak boleh lebih dari 100%! ";

			if (str != "")
			{
				Tools.popMessage(this, str);
				return;
			}

			if (rate.Trim() == "")
				rate = "NULL";
			else
				rate = "'" + rate + "'";

			if (insrdatestart.Trim() == "")
				insrdatestart = "NULL";
			else
			{
				if (!Tools.isDateValid(this,TXT_DATESTART_DAY.Text,DDL_DATESTART_MONTH.SelectedValue,TXT_DATESTART_YEAR.Text))
				{
					Tools.popMessage(this, "Start date is not valid!");
					return;
				}
				insrdatestart = "'" + insrdatestart + "'";
			}

			if (insrdateend.Trim() == "")
				insrdateend = "NULL";
			else
			{
				if (!Tools.isDateValid(this,TXT_DATEEND_DAY.Text,DDL_DATEEND_MONTH.SelectedValue,TXT_DATEEND_YEAR.Text))
				{
					Tools.popMessage(this, "End date is not valid!");
					return;
				}
				insrdateend = "'" + insrdateend + "'";
			}

			if (insrcur.Trim() == "")
				insrcur = "NULL";
			else
				insrcur = "'" + insrcur + "'";

			insrpct = tool.ConvertFloat(insrpct);
			if (insramount.Trim() == "") insramount = "0";
			if (insrpct.Trim() == "") insrpct = "0";
			if (insrpremi.Trim() == "") insrpremi = "0";

			conn.QueryString = "exec NA_INSURANCE_SAVE '" + regno + "', " + seq + ", '" +
				compname + "', '" + insrtype + "', '" + insrpolicyno + "', " + insrcur + ", " +
				insramount + ", " + insrdatestart + ", " + insrdateend + ", " + 
				insrpct + ", " + insrpremi + ", " + rate ;
			conn.ExecuteNonQuery();
			clearEditBoxes();
			bindData();

			Tools.initDateForm(TXT_DATESTART_DAY, DDL_DATESTART_MONTH, TXT_DATESTART_YEAR, false);
			Tools.initDateForm(TXT_DATEEND_DAY, DDL_DATEEND_MONTH, TXT_DATEEND_YEAR, false);
		}

		protected void DDL_AP_INSRCOMP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillInsrType();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn));
		}

		private void BTN_CANCEL_Click(object sender, EventArgs e)
		{
			clearEditBoxes();
		}
	}
}
