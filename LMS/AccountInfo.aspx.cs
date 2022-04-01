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
	/// Summary description for BankRelation.
	/// </summary>
	public partial class BankRelation : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				ViewData();

				DDL_TGLPENILAIAN_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_TGLPENILAIAN_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				DDL_JENISKREDIT.Items.Add(new ListItem("- PILIH -", ""));
				conn.QueryString = "select * from VW_LMS_ACCINFO_FILLDDLJENISKREDIT ";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_JENISKREDIT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				DDL_KOLEKTIBILITAS.Items.Add(new ListItem("- PILIH -", ""));
				conn.QueryString = "select * from VW_LMS_ACCINFO_FILLDDLKOLEKTIBILITAS ";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_KOLEKTIBILITAS.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}
			}
			ViewMenu();
		}

		private void ViewData()
		{
			conn.QueryString = "EXEC LMS_ACCCOLINFO '" + Request.QueryString["lmsreg"] + "'";
			conn.ExecuteQuery();
			FillGrid();
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
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
				LinkButton HpDelete = (LinkButton) DatGrd.Items[i].Cells[14].FindControl("LinkButton1");
				if (DatGrd.Items[i].Cells[13].Text.Trim() != "0")
				{
					HpDelete.Visible = false;
				}
			}
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				string mc1 = Request.QueryString["mc"];
				string mc2 = Request.QueryString["mc"];
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						else	strtemp = "lmsreg="+Request.QueryString["lmsreg"]+"&mc="+Request.QueryString["mc"]+"&scr="+Request.QueryString["scr"];
						//t.ForeColor = Color.MidnightBlue; 

						//2010-05-14, ILP Enh 2010
						if (Request.QueryString["curef"] != null && Request.QueryString["curef"] != "")
							strtemp = strtemp + "&curef=" + Request.QueryString["curef"];
						if (Request.QueryString["regno"] != null && Request.QueryString["regno"] != "")
							strtemp = strtemp + "&regno=" + Request.QueryString["regno"];
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

		private void ClearEntry()
		{
			TXT_ACCNO.Text = "";
			try { DDL_JENISKREDIT.SelectedValue = ""; } 
			catch {}
			TXT_EXCHRP.Text = "1";
			TXT_LIMIT.Text = "";
			TXT_BAKIDEBET.Text = "";
			TXT_TGKPOKOK.Text = "";
			TXT_TGKBUNGA.Text = "";
			try { DDL_KOLEKTIBILITAS.SelectedValue = ""; } 
			catch {}
			TXT_JMLPENCAIRAN.Text = "";
			TXT_NILAIAGUNAN.Text = "";
			TXT_NILAIIKAT.Text = "";
			TXT_TGLPENILAIAN_DAY.Text = "";
			TXT_TGLPENILAIAN_YEAR.Text = "";
			try { DDL_TGLPENILAIAN_MONTH.SelectedValue = ""; } 
			catch {}
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

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string url = "SearchCustomer.aspx?mc=" + Request.QueryString["mc"];
			if (Request.QueryString["tc"] != "")
			{
				url = url + "&tc=" + Request.QueryString["tc"];
			}
			if (Request.QueryString["scr"] != "")
			{
				url = url + "&scr=" + Request.QueryString["scr"];
			}
			Response.Redirect(url);
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			if (TXT_TGLPENILAIAN_DAY.Text.Trim() != "" || DDL_TGLPENILAIAN_MONTH.SelectedValue != "" || TXT_TGLPENILAIAN_YEAR.Text.Trim() != "") 
			{
				if (!GlobalTools.isDateValid(TXT_TGLPENILAIAN_DAY.Text, DDL_TGLPENILAIAN_MONTH.SelectedValue, TXT_TGLPENILAIAN_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Penilaian tidak valid!");
					return;
				}
			}

			if (TXT_ACCNO.Text == "")
			{
				GlobalTools.popMessage(this, "No. Rekening tidak boleh kosong!");
				return;
			}

			if (DDL_JENISKREDIT.SelectedValue == "")
			{
				GlobalTools.popMessage(this, "Jenis Kredit tidak boleh kosong!");
				return;
			}

			if (TXT_LIMIT.Text == "")
			{
				GlobalTools.popMessage(this, "Limit tidak boleh kosong!");
				return;
			}

			if (TXT_EXCHRP.Text == "")
			{
				GlobalTools.popMessage(this, "Exchange Rate tidak boleh kosong!");
				return;
			}

			try 
			{
				conn.QueryString = "EXEC LMS_ACCCOLINFO_INSERT '" + Request.QueryString["lmsreg"] + 
					"', '" + TXT_ACCNO.Text + 
					"', '" + DDL_JENISKREDIT.SelectedValue + 
					"', " + tool.ConvertFloat(TXT_EXCHRP.Text) + 
					", " + tool.ConvertFloat(TXT_LIMIT.Text) + 
					", " + tool.ConvertFloat(TXT_BAKIDEBET.Text) + 
					", " + tool.ConvertFloat(TXT_TGKPOKOK.Text) + 
					", " + tool.ConvertFloat(TXT_TGKBUNGA.Text) + 
					", '" + DDL_KOLEKTIBILITAS.SelectedValue + 
					"', " + tool.ConvertFloat(TXT_JMLPENCAIRAN.Text) + 
					", " + tool.ConvertFloat(TXT_NILAIAGUNAN.Text) + 
					", " + tool.ConvertFloat(TXT_NILAIIKAT.Text) + 
					", " + tool.ConvertDate(TXT_TGLPENILAIAN_DAY.Text, DDL_TGLPENILAIAN_MONTH.SelectedValue, TXT_TGLPENILAIAN_YEAR.Text);
				conn.ExecuteQuery();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}

			ViewData();
			ClearEntry();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try 
			{
				conn.QueryString = "EXEC LMS_ACCCOLINFO_DELETE '" + Request.QueryString["lmsreg"] + 
					"', '" + e.Item.Cells[0].Text + "'";
				conn.ExecuteQuery();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}

			ViewData();
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearEntry();
		}

		protected void DDL_JENISKREDIT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (DDL_JENISKREDIT.SelectedValue != "")
			{
				conn.QueryString = "SELECT CURRENCY, EXCHANGERP from VW_LMS_ACCINFO_GETEXCHANGERP WHERE PRODUCTID = '" + DDL_JENISKREDIT.SelectedValue + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					TXT_EXCHRP.Text = conn.GetFieldValue("EXCHANGERP");
				}
			}
		}
	}
}
