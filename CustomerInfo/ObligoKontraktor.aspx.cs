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

namespace SME.CustomerInfo
{
	/// <summary>
	/// Summary description for ObligoKontraktor.
	/// </summary>
	public partial class ObligoKontraktor : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				GlobalTools.initDateForm(TXT_CONTRACTEXPDATE_DAY, DDL_CONTRACTEXPDATE_MONTH, TXT_CONTRACTEXPDATE_YEAR, true);
				GlobalTools.initDateForm(TXT_PENCAIRAN_TGL_DAY, DDL_PENCAIRAN_TGL_MONTH, TXT_PENCAIRAN_TGL_YEAR, true);
				GlobalTools.initDateForm(TXT_PROGRESS_TGL_DAY, DDL_PROGRESS_TGL_MONTH, TXT_PROGRESS_TGL_YEAR, true);
				GlobalTools.initDateForm(TXT_PENAGIHAN_TGL_DAY, DDL_PENAGIHAN_TGL_MONTH, TXT_PENAGIHAN_TGL_YEAR, true);
				GlobalTools.initDateForm(TXT_PEMBAYARAN_TGL_DAY, DDL_PEMBAYARAN_TGL_MONTH, TXT_PEMBAYARAN_TGL_YEAR, true);
				GlobalTools.initDateForm(TXT_POSISI_TGL_DAY, DDL_POSISI_TGL_MONTH, TXT_POSISI_TGL_YEAR, true);
				
				ViewCust();
				ViewData();
				SecureData();
				ViewDetail(LBL_SEQ.Text);
			}

			ViewMenu();
		}

		private void ViewMenu() 
		{
			string strtemp = "";
			try 
			{
				//--- Membuat menu dari DATABASE
				conn.QueryString = "select * from SCREENMENU where menucode = '" + Request.QueryString["mc"] + "'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
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
				Console.Write(ex.Message);
			}			
		}

		private void SecureData()
		{
			if (Request.QueryString["ob"] != null && Request.QueryString["ob"] == "0")
			{
				BTN_SAVE.Visible = false;
				BTN_SAVE2.Visible = false;
				DG_OB.Columns[11].Visible = false;
				DG_DET.Columns[20].Visible = false;
			}
		}

		private void ViewCust()
		{
			conn.QueryString = "SELECT * FROM VW_OBLIGOKONTRAKTOR_VIEWCUST WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				TXT_CU_CIF.Text = conn.GetFieldValue("CU_CIF");
				TXT_CU_NAME.Text = conn.GetFieldValue("CU_NAME");
			}
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM VW_OBLIGOKONTRAKTOR_VIEWDATA WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_OB.DataSource = dt;
			try 
			{
				DG_OB.DataBind();
			}
			catch 
			{
				DG_OB.CurrentPageIndex = 0;
				DG_OB.DataBind();
			}
		}

		private void ViewDetail(string seq)
		{
			conn.QueryString = "SELECT * FROM VW_OBLIGOKONTRAKTOR_VIEWDETAIL WHERE CU_REF = '" + Request.QueryString["curef"] + "' AND OB_SEQ = '" + seq + "'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_DET.DataSource = dt;
			try 
			{
				DG_DET.DataBind();
			}
			catch 
			{
				DG_DET.CurrentPageIndex = 0;
				DG_DET.DataBind();
			}
		}

		private void SaveData()
		{
			if (TXT_CONTRACTEXPDATE_DAY.Text != "" && DDL_CONTRACTEXPDATE_MONTH.SelectedValue != "" && TXT_CONTRACTEXPDATE_YEAR.Text != "") 
			{
				if (!GlobalTools.isDateValid(TXT_CONTRACTEXPDATE_DAY.Text, DDL_CONTRACTEXPDATE_MONTH.SelectedValue, TXT_CONTRACTEXPDATE_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal JT Kontrak tidak valid!");
					return;
				}
			}

			try
			{
				conn.QueryString = "EXEC OBLIGOKONTRAKTOR_SAVEDATA '" + 
					Request.QueryString["curef"] + "', '" +
					LBL_SEQ.Text + "', '" +
					TXT_BOUWHEERNAME.Text + "', '" +
					TXT_CONTRACTNO.Text + "', " +
					tool.ConvertDate(TXT_CONTRACTEXPDATE_DAY.Text, DDL_CONTRACTEXPDATE_MONTH.SelectedValue, TXT_CONTRACTEXPDATE_YEAR.Text) + ", " + 
					tool.ConvertFloat(TXT_CONTRACTVALUE.Text.Trim()) + ", " + 
					tool.ConvertFloat(TXT_NETTOVALUE.Text.Trim()) + ", " + 
					tool.ConvertFloat(TXT_PROJECTCOST.Text.Trim()) + ", " + 
					tool.ConvertFloat(TXT_DOWNPAYMENT.Text.Trim()) + ", " + 
					tool.ConvertFloat(TXT_BIAYABANK.Text.Trim());
				conn.ExecuteQuery();

				ViewData();
				ClearEntry();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		private void SaveDetail()
		{
			try
			{
				conn.QueryString = "EXEC OBLIGOKONTRAKTOR_SAVEDETAIL '" + 
					Request.QueryString["curef"] + "', '" +
					LBL_SEQ.Text + "', '" +
					LBL_SEQ2.Text + "', " +
					tool.ConvertDate(TXT_PENCAIRAN_TGL_DAY.Text, DDL_PENCAIRAN_TGL_MONTH.SelectedValue, TXT_PENCAIRAN_TGL_YEAR.Text) + ", " + 
					tool.ConvertFloat(TXT_PENCAIRAN_NILAI.Text.Trim()) + ", '" + 
					TXT_PENCAIRAN_TUJUAN.Text + "', " +
					tool.ConvertDate(TXT_PROGRESS_TGL_DAY.Text, DDL_PROGRESS_TGL_MONTH.SelectedValue, TXT_PROGRESS_TGL_YEAR.Text) + ", " + 
					tool.ConvertFloat(TXT_PROGRESS_PERCENT.Text.Trim()) + ", " + 
					tool.ConvertFloat(TXT_PROGRESS_NILAI.Text.Trim()) + ", " + 
					tool.ConvertDate(TXT_PENAGIHAN_TGL_DAY.Text, DDL_PENAGIHAN_TGL_MONTH.SelectedValue, TXT_PENAGIHAN_TGL_YEAR.Text) + ", " + 
					tool.ConvertFloat(TXT_PENAGIHAN_PERCENT.Text.Trim()) + ", " + 
					tool.ConvertFloat(TXT_PENAGIHAN_NILAI.Text.Trim()) + ", " + 
					tool.ConvertDate(TXT_PEMBAYARAN_TGL_DAY.Text, DDL_PEMBAYARAN_TGL_MONTH.SelectedValue, TXT_PEMBAYARAN_TGL_YEAR.Text) + ", " + 
					tool.ConvertFloat(TXT_PEMBAYARAN_PERCENT2.Text.Trim()) + ", " + 
					tool.ConvertFloat(TXT_PEMBAYARAN_NILAI2.Text.Trim()) + ", " + 
					tool.ConvertDate(TXT_POSISI_TGL_DAY.Text, DDL_POSISI_TGL_MONTH.SelectedValue, TXT_POSISI_TGL_YEAR.Text) + ", " + 
					tool.ConvertFloat(TXT_POSISI_SISA.Text.Trim()) + ", " + 
					tool.ConvertFloat(TXT_POSISI_BAKIDEBET.Text.Trim()) + ", " + 
					tool.ConvertFloat(TXT_POSISI_COVERAGE.Text.Trim());
				conn.ExecuteQuery();

				ViewDetail(LBL_SEQ.Text);
				ClearEntry2();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		private void ClearEntry()
		{
			LBL_SEQ.Text = "";
			TXT_BOUWHEERNAME.Text = "";
			TXT_CONTRACTNO.Text = "";
			TXT_CONTRACTEXPDATE_DAY.Text = "";
			DDL_CONTRACTEXPDATE_MONTH.SelectedValue = "";
			TXT_CONTRACTEXPDATE_YEAR.Text = "";
			TXT_CONTRACTVALUE.Text = "";
			TXT_NETTOVALUE.Text = "";
			TXT_PROJECTCOST.Text = "";
			TXT_DOWNPAYMENT.Text = "";
			TXT_BIAYABANK.Text = "";
		}

		private void ClearEntry2()
		{
			LBL_SEQ2.Text = "";
			TXT_PENCAIRAN_TGL_DAY.Text = "";
			try {DDL_PENCAIRAN_TGL_MONTH.SelectedValue = "";}
			catch {}
			TXT_PENCAIRAN_TGL_YEAR.Text = "";
			TXT_PENCAIRAN_NILAI.Text = "";
			TXT_PENCAIRAN_TUJUAN.Text = "";
			TXT_PROGRESS_TGL_DAY.Text = "";
			try {DDL_PROGRESS_TGL_MONTH.SelectedValue = "";}
			catch {}
			TXT_PROGRESS_TGL_YEAR.Text = "";
			TXT_PROGRESS_PERCENT.Text = "";
			TXT_PROGRESS_NILAI.Text = "";
			TXT_PENAGIHAN_TGL_DAY.Text = "";
			try {DDL_PENAGIHAN_TGL_MONTH.SelectedValue = "";}
			catch {}
			TXT_PENAGIHAN_TGL_YEAR.Text = "";
			TXT_PENAGIHAN_PERCENT.Text = "";
			TXT_PENAGIHAN_NILAI.Text = "";
			TXT_PEMBAYARAN_TGL_DAY.Text = "";
			try {DDL_PEMBAYARAN_TGL_MONTH.SelectedValue = "";}
			catch {}
			TXT_PEMBAYARAN_TGL_YEAR.Text = "";
			TXT_PEMBAYARAN_PERCENT2.Text = "";
			TXT_PEMBAYARAN_NILAI2.Text = "";
			TXT_POSISI_TGL_DAY.Text = "";
			try {DDL_POSISI_TGL_MONTH.SelectedValue = "";}
			catch {}
			TXT_POSISI_TGL_YEAR.Text = "";
			TXT_POSISI_SISA.Text = "";
			TXT_POSISI_BAKIDEBET.Text = "";
			TXT_POSISI_COVERAGE.Text = "";
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
			this.DG_OB.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_OB_ItemCommand);
			this.DG_OB.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_OB_PageIndexChanged);
			this.DG_DET.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_DET_ItemCommand);

		}
		#endregion

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			SaveData();
			ClearEntry();
		}

		protected void BTN_SAVE2_Click(object sender, System.EventArgs e)
		{
			SaveDetail();
			ClearEntry2();
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearEntry();
			ClearEntry2();
			ViewDetail("");
		}

		protected void BTN_CLEAR2_Click(object sender, System.EventArgs e)
		{
			ClearEntry2();
		}

		private void DG_OB_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Edit":
					LBL_SEQ.Text = e.Item.Cells[1].Text.Trim();
					TXT_BOUWHEERNAME.Text = e.Item.Cells[2].Text.Trim();
					TXT_CONTRACTNO.Text = e.Item.Cells[3].Text.Trim();
					TXT_CONTRACTEXPDATE_DAY.Text = GlobalTools.FormatDate_Day(e.Item.Cells[4].Text.Trim());
					try {DDL_CONTRACTEXPDATE_MONTH.SelectedValue = GlobalTools.FormatDate_Month(e.Item.Cells[4].Text.Trim());}
					catch {}
					TXT_CONTRACTEXPDATE_YEAR.Text = GlobalTools.FormatDate_Year(e.Item.Cells[4].Text.Trim());
					TXT_CONTRACTVALUE.Text = GlobalTools.MoneyFormat(e.Item.Cells[5].Text.Trim());
					TXT_NETTOVALUE.Text = GlobalTools.MoneyFormat(e.Item.Cells[6].Text.Trim());
					TXT_PROJECTCOST.Text = GlobalTools.MoneyFormat(e.Item.Cells[7].Text.Trim());
					TXT_DOWNPAYMENT.Text = GlobalTools.MoneyFormat(e.Item.Cells[8].Text.Trim());
					TXT_BIAYABANK.Text = GlobalTools.MoneyFormat(e.Item.Cells[9].Text.Trim());

					ViewDetail(LBL_SEQ.Text);
					break;

				case "Delete":
					try
					{
						conn.QueryString = "EXEC OBLIGOKONTRAKTOR_DELETEDATA '" +
							Request.QueryString["curef"] + "', '" +
							e.Item.Cells[1].Text + "'";
						conn.ExecuteNonQuery();

						ViewData();
					}
					catch (Exception ex)
					{
						Response.Write("<!--" + ex.ToString() + "-->");
						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						return;
					}
					break;

				default:
					break;
			}
		}

		private void DG_DET_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Edit":
					LBL_SEQ.Text = e.Item.Cells[1].Text.Trim();
					LBL_SEQ2.Text = e.Item.Cells[2].Text.Trim();
					TXT_PENCAIRAN_TGL_DAY.Text = GlobalTools.FormatDate_Day(e.Item.Cells[3].Text.Trim());
					try {DDL_PENCAIRAN_TGL_MONTH.SelectedValue = GlobalTools.FormatDate_Month(e.Item.Cells[3].Text.Trim());}
					catch {}
					TXT_PENCAIRAN_TGL_YEAR.Text = GlobalTools.FormatDate_Year(e.Item.Cells[3].Text.Trim());
					TXT_PENCAIRAN_NILAI.Text = GlobalTools.MoneyFormat(e.Item.Cells[4].Text.Trim());
					TXT_PENCAIRAN_TUJUAN.Text = e.Item.Cells[5].Text.Trim();
					TXT_PROGRESS_TGL_DAY.Text = GlobalTools.FormatDate_Day(e.Item.Cells[6].Text.Trim());
					try {DDL_PROGRESS_TGL_MONTH.SelectedValue = GlobalTools.FormatDate_Month(e.Item.Cells[6].Text.Trim());}
					catch {}
					TXT_PROGRESS_TGL_YEAR.Text = GlobalTools.FormatDate_Year(e.Item.Cells[6].Text.Trim());
					TXT_PROGRESS_PERCENT.Text = e.Item.Cells[7].Text.Trim();
					TXT_PROGRESS_NILAI.Text = GlobalTools.MoneyFormat(e.Item.Cells[8].Text.Trim());
					TXT_PENAGIHAN_TGL_DAY.Text = GlobalTools.FormatDate_Day(e.Item.Cells[9].Text.Trim());
					try {DDL_PENAGIHAN_TGL_MONTH.SelectedValue = GlobalTools.FormatDate_Month(e.Item.Cells[9].Text.Trim());}
					catch {}
					TXT_PENAGIHAN_TGL_YEAR.Text = GlobalTools.FormatDate_Year(e.Item.Cells[9].Text.Trim());
					TXT_PENAGIHAN_PERCENT.Text = e.Item.Cells[10].Text.Trim();
					TXT_PENAGIHAN_NILAI.Text = GlobalTools.MoneyFormat(e.Item.Cells[11].Text.Trim());
					TXT_PEMBAYARAN_TGL_DAY.Text = GlobalTools.FormatDate_Day(e.Item.Cells[12].Text.Trim());
					try {DDL_PEMBAYARAN_TGL_MONTH.SelectedValue = GlobalTools.FormatDate_Month(e.Item.Cells[12].Text.Trim());}
					catch {}
					TXT_PEMBAYARAN_TGL_YEAR.Text = GlobalTools.FormatDate_Year(e.Item.Cells[12].Text.Trim());
					TXT_PEMBAYARAN_PERCENT2.Text = e.Item.Cells[13].Text.Trim();
					TXT_PEMBAYARAN_NILAI2.Text = GlobalTools.MoneyFormat(e.Item.Cells[14].Text.Trim());
					TXT_POSISI_TGL_DAY.Text = GlobalTools.FormatDate_Day(e.Item.Cells[15].Text.Trim());
					try {DDL_POSISI_TGL_MONTH.SelectedValue = GlobalTools.FormatDate_Month(e.Item.Cells[15].Text.Trim());}
					catch {}
					TXT_POSISI_TGL_YEAR.Text = GlobalTools.FormatDate_Year(e.Item.Cells[15].Text.Trim());
					TXT_POSISI_SISA.Text = GlobalTools.MoneyFormat(e.Item.Cells[16].Text.Trim());
					TXT_POSISI_BAKIDEBET.Text = GlobalTools.MoneyFormat(e.Item.Cells[17].Text.Trim());
					TXT_POSISI_COVERAGE.Text = e.Item.Cells[18].Text.Trim();
					break;

				case "Delete":
					try
					{
						conn.QueryString = "EXEC OBLIGOKONTRAKTOR_DELETEDETAIL '" +
							Request.QueryString["curef"] + "', '" +
							e.Item.Cells[1].Text + "', '" +
							e.Item.Cells[2].Text + "'";
						conn.ExecuteNonQuery();

						ViewDetail(LBL_SEQ.Text);
					}
					catch (Exception ex)
					{
						Response.Write("<!--" + ex.ToString() + "-->");
						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						return;
					}
					break;

				default:
					break;
			}
		}

		private void DG_OB_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_OB.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}

		private void DG_DET_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_DET.CurrentPageIndex = e.NewPageIndex;
			ViewDetail(LBL_SEQ.Text);
		}
	}
}
