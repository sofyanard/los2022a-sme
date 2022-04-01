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

namespace SME.CEA.DataEntry
{
	/// <summary>
	/// Summary description for Perizinan.
	/// </summary>
	public partial class Perizinan : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		int seq=8;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");
			if(!IsPostBack)
			{
			
				
			
				DDL_BLN_DOC.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLNEXP_DOC.Items.Add(new ListItem("--Pilih--",""));
				DDL_JNS_DOC.Items.Add(new ListItem("--Pilih--",""));

				for(int i=1; i<=12; i++)
				{
					DDL_BLN_DOC.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLNEXP_DOC.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				conn.QueryString = "select doc_id, doc_desc from rekanan_rfdoctype where active='1'";
				conn.ExecuteQuery();
				for (int i=0; i<conn.GetRowCount(); i++)
				{
					DDL_JNS_DOC.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
				}
			}
			ViewMenu();
			ViewData();
			BTN_UPDATE.Visible=false;
			BTN_INSERT.Visible=true;
			
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
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"]+ "&exist=" + Request.QueryString["exist"];
						else	
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+ "&exist=" + Request.QueryString["exist"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					MenuPerizinan.Controls.Add(t);
					MenuPerizinan.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
					

					
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}
		private void ViewData()
		{
			conn.QueryString = "select SEQ, DOC_DESC, DOC#, DOC_DATE, DOC_END, DOC_FROM from vw_rekanan_doc where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();
			FillDocGrid();
		}

		private void FillDocGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGridDoc.DataSource = dt;
			try 
			{
				DatGridDoc.DataBind();
			} 
			catch 
			{
				DatGridDoc.CurrentPageIndex = 0;
				DatGridDoc.DataBind();
			}
			for (int i = 0; i < DatGridDoc.Items.Count; i++)
			{
				DatGridDoc.Items[i].Cells[3].Text = tool.FormatDate(DatGridDoc.Items[i].Cells[3].Text, true);
				DatGridDoc.Items[i].Cells[4].Text = tool.FormatDate(DatGridDoc.Items[i].Cells[4].Text, true);
			}
		}

		private void DatGridDoc_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete_doc":
					conn.QueryString = "delete from rekanan_doc where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "' and SEQ=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();
					ViewData();
					FillDocGrid();
				break;
				case "edit_doc":
					BTN_UPDATE.Visible=true;
					BTN_INSERT.Visible=false;
					conn.QueryString = "select * from rekanan_doc where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "' and SEQ=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();

					seq = Convert.ToInt32(conn.GetFieldValue("SEQ"));
					try{ DDL_JNS_DOC.SelectedValue = conn.GetFieldValue("rfdoc");}
					catch{DDL_JNS_DOC.SelectedValue = "";}
					TXT_NO_DOC.Text = conn.GetFieldValue("DOC#");
					TXT_DIKELUARKAN_OLEH.Text = conn.GetFieldValue("DOC_FROM");
					TXT_TGL_DOC.Text = tool.FormatDate_Day(conn.GetFieldValue("DOC_DATE"));
					try{ DDL_BLN_DOC.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("DOC_DATE"));}
					catch{DDL_BLN_DOC.SelectedValue = "";}
					TXT_THN_DOC.Text = tool.FormatDate_Year(conn.GetFieldValue("DOC_DATE"));
					TXT_TGLEXP_DOC.Text = tool.FormatDate_Day(conn.GetFieldValue("DOC_END"));
					try{ DDL_BLNEXP_DOC.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("DOC_END"));}
					catch{ DDL_BLNEXP_DOC.SelectedValue = "";}
					TXT_THNEXP_DOC.Text = tool.FormatDate_Year(conn.GetFieldValue("DOC_END"));
					TXT_NOTARIS.Text = conn.GetFieldValue("NOTARIS");
					TXT_SEQ.Text = conn.GetFieldValue("SEQ");
					ViewData();
				break;
			}


			
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "exec REKANAN_DOC_UPDATE " +
					Convert.ToUInt32(TXT_SEQ.Text) + ", '" + Request.QueryString["rekanan_ref"] + "', '" +
					DDL_JNS_DOC.SelectedValue + "', '" +
					TXT_NO_DOC.Text + "', '" +
					TXT_DIKELUARKAN_OLEH.Text + "', " +
					tool.ConvertDate(TXT_TGL_DOC.Text, DDL_BLN_DOC.SelectedValue, TXT_THN_DOC.Text) + ", " +
					tool.ConvertDate(TXT_TGLEXP_DOC.Text, DDL_BLNEXP_DOC.SelectedValue, TXT_THNEXP_DOC.Text) + ", '" +
					TXT_NOTARIS.Text + "'";
				conn.ExecuteNonQuery();
			}
			catch
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../../Login.aspx?expire=1");
			}
			ViewData();
			BTN_UPDATE.Visible = false;
			BTN_INSERT.Visible = true;
			ClearData();
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
			
		}

		private void ClearData()
		{
			DDL_JNS_DOC.SelectedValue = "";
			TXT_NO_DOC.Text="";
			TXT_DIKELUARKAN_OLEH.Text="";
			TXT_TGL_DOC.Text="";
			DDL_BLN_DOC.SelectedValue="";
			TXT_THN_DOC.Text="";
			TXT_TGLEXP_DOC.Text="";
			DDL_BLNEXP_DOC.SelectedValue="";
			TXT_THNEXP_DOC.Text="";
			TXT_NOTARIS.Text="";
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), DocExp, DocDate;
			
			//--VALIDASI TANGGAL DOKUMEN--//
			try 
			{
				DocDate = Int64.Parse(Tools.toISODate(TXT_TGL_DOC.Text, DDL_BLN_DOC.SelectedValue, TXT_THN_DOC.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal Dokumen tidak valid!");
				return;
			}
			if (DocDate > now)
			{
				GlobalTools.popMessage(this, "Tanggal Dokumen cannot be greater than current date!");
				return;
			}

			//--VALIDASI DOKUMEN EXP--//
			if (!GlobalTools.isDateValid(TXT_TGLEXP_DOC.Text, DDL_BLNEXP_DOC.SelectedValue, TXT_THNEXP_DOC.Text)) 
			{
				GlobalTools.popMessage(this, "Tanggal Berakhir Dokumen tidak valid!");
				return;
			}
			int banding = Tools.compareDate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), TXT_TGLEXP_DOC.Text, DDL_BLNEXP_DOC.SelectedValue, TXT_THNEXP_DOC.Text);
			if (banding >= 0) 
			{
				GlobalTools.popMessage(this, "Tanggal berakhir dokumen tidak boleh kurang dari tanggal sekarang!");
				return;
			}

			try
			{
				conn.QueryString = "exec REKANAN_DOC_INSERT2 '" +
					Request.QueryString["rekanan_ref"] + "', '" +
					DDL_JNS_DOC.SelectedValue + "', '" +
					TXT_NO_DOC.Text + "', '" +
					TXT_DIKELUARKAN_OLEH.Text + "', " +
					tool.ConvertDate(TXT_TGL_DOC.Text, DDL_BLN_DOC.SelectedValue, TXT_THN_DOC.Text) + ", " +
					tool.ConvertDate(TXT_TGLEXP_DOC.Text, DDL_BLNEXP_DOC.SelectedValue, TXT_THNEXP_DOC.Text) + ", '" +
					TXT_NOTARIS.Text + "'";
				conn.ExecuteNonQuery();
			}
			catch
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../../Login.aspx?expire=1");
			}

			ViewData();
			ClearData();


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
			this.DatGridDoc.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGridDoc_ItemCommand);

		}
		#endregion
	}
}
