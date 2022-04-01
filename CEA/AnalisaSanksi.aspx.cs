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

namespace SME.CEA
{
	/// <summary>
	/// Summary description for AnalisaSanksi.
	/// </summary>
	public partial class AnalisaSanksi : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			/*if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/../SME/Restricted.aspx");
			*/
			
			ViewMenu();
			if(!IsPostBack)
			{
				DDL_BLN_SURAT.Items.Add(new ListItem("--Pilih-",""));

				for(int i=1; i<=12; i++)
					DDL_BLN_SURAT.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));

				DDL_JANGKA_WKT_SANKSI.Items.Add(new ListItem("-- PILIH --", ""));
				DDL_JNS_SANKSI.Items.Add(new ListItem("--Pilih--",""));
				//DDL_PROBLEM.Items.Add(new ListItem("--Pilih--",""));

				conn.QueryString = "select tenorcode, tenordesc from rftenorcode where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_JANGKA_WKT_SANKSI.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select rfrekanantype from vw_rekanan where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
				conn.ExecuteQuery();
				LBL_REKANAN_REF.Text = conn.GetFieldValue("rfrekanantype");

				/*conn.QueryString = "select sanksi_id, sanksidesc from rekanan_rfsanksi where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount();i++)
					DDL_JNS_SANKSI.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select problem_id, problemdesc from rekanan_rfproblem where active='1'";
				conn.ExecuteQuery();
				for (int i=0; i < conn.GetRowCount(); i++)
					DDL_PROBLEM.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				*/
				ViewSanksi();
				conn.QueryString = "select * from rekanan_sanksi where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
				conn.ExecuteQuery();
				DDL_JNS_SANKSI.SelectedValue = conn.GetFieldValue("RF_SANKSI_TYPE");
				ViewProblem();
				ViewData();
			}
			
		}

		private void ViewSanksi()
		{
			conn.QueryString = "select sanksi_id, sanksidesc from rekanan_rfsanksi where active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount();i++)
				DDL_JNS_SANKSI.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			
			//ViewProblem();
		}

		private void ViewProblem()
		{
			DDL_PROBLEM.Items.Clear();
			DDL_PROBLEM.Items.Add(new ListItem("--Pilih--",""));

			conn.QueryString = "select problem_id, problemdesc from vw_rekanan_problem where rfrekanantype='" + LBL_REKANAN_REF.Text + "' and sanksi_id='" + DDL_JNS_SANKSI.SelectedValue + "'";
			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_PROBLEM.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}
		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '" + Request.QueryString["mc"] + "'";
				conn.ExecuteQuery();
				
				if(Request.QueryString["flag"]=="1")
				{
					for (int i = 0; i < conn.GetRowCount(); i++) 
					{
						if(conn.GetFieldValue(i,0)!="A010301" && conn.GetFieldValue(i,0)!="A010304" && conn.GetFieldValue(i,0)!="A010305")
						{
							HyperLink t = new HyperLink();
							t.Text = conn.GetFieldValue(i, 2);
							t.Font.Bold = true;
							string strtemp = "";
							if (conn.GetFieldValue(i, 3).Trim()!= "") 
							{
								if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
									strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"] + "&flag=" + Request.QueryString["flag"];
								else	
									strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"] + "&flag=" + Request.QueryString["flag"];
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
				} 
				else
				{
					for (int i = 0; i < conn.GetRowCount(); i++) 
					{
						HyperLink t = new HyperLink();
						t.Text = conn.GetFieldValue(i, 2);
						t.Font.Bold = true;
						string strtemp = "";
						if (conn.GetFieldValue(i, 3).Trim()!= "") 
						{
							if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
								strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"] + "&exist=" + Request.QueryString["exist"];
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
						Menu.Controls.Add(t);
						Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
					}
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void ViewData()
		{	
			conn.QueryString = "select * from rekanan_sanksi where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				DDL_JNS_SANKSI.SelectedValue = conn.GetFieldValue("RF_SANKSI_TYPE");
				TXT_NO_SURAT.Text = conn.GetFieldValue("LETTER#");
				TXT_TGL_SURAT.Text = tool.FormatDate_Day(conn.GetFieldValue("LETTER_DATE"));
				DDL_BLN_SURAT.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("LETTER_DATE"));
				TXT_THN_SURAT.Text = tool.FormatDate_Year(conn.GetFieldValue("LETTER_DATE"));
				TXT_JANGKA_WKT_SANKSI.Text = conn.GetFieldValue("TENOR");
				DDL_JANGKA_WKT_SANKSI.SelectedValue = conn.GetFieldValue("PERIODE");
				DDL_PROBLEM.SelectedValue = conn.GetFieldValue("RFPROBLEM");
				TXT_STATUS_SANKSI.Text = conn.GetFieldValue("RFSTATUS");
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

		}
		#endregion

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), LetterDate;
			
			//--VALIDASI TANGGAL SURAT--//
			try 
			{
				LetterDate = Int64.Parse(Tools.toISODate(TXT_TGL_SURAT.Text, DDL_BLN_SURAT.SelectedValue, TXT_THN_SURAT.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal surat tidak valid!");
				return;
			}
			if (LetterDate > now)
			{
				GlobalTools.popMessage(this, "Tanggal surat cannot be greater than current date!");
				return;
			}

			conn.QueryString = "select * from rekanan_sanksi where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				try
				{
					conn.QueryString = "exec REKANAN_SANKSI_UPDATE '" +
						Request.QueryString["rekanan_ref"] + "', '" +
						DDL_JNS_SANKSI.SelectedValue + "', '" +
						TXT_NO_SURAT.Text + "', " +
						tool.ConvertDate(TXT_TGL_SURAT.Text, DDL_BLN_SURAT.SelectedValue, TXT_THN_SURAT.Text) + ", '" +
						tool.ConvertNum(TXT_JANGKA_WKT_SANKSI.Text) + "', '" +
						DDL_JANGKA_WKT_SANKSI.SelectedValue + "', '" +
						DDL_PROBLEM.SelectedValue + "', '" +
						TXT_STATUS_SANKSI.Text + "'";
				}
				catch
				{
					GlobalTools.popMessage(this, "Connection Error!");
					Response.Redirect("../../Login.aspx?expire=1");
				}
			}
			else
			{
				try
				{
					conn.QueryString = "exec REKANAN_SANKSI_INSERT '" +
						Request.QueryString["rekanan_ref"] + "', '" +
						DDL_JNS_SANKSI.SelectedValue + "', '" +
						TXT_NO_SURAT.Text + "', " +
						tool.ConvertDate(TXT_TGL_SURAT.Text, DDL_BLN_SURAT.SelectedValue, TXT_THN_SURAT.Text) + ", '" +
						tool.ConvertNum(TXT_JANGKA_WKT_SANKSI.Text) + "', '" +
						DDL_JANGKA_WKT_SANKSI.SelectedValue + "', '" +
						DDL_PROBLEM.SelectedValue + "', '" +
						TXT_STATUS_SANKSI.Text + "'";
				}
				catch
				{
					GlobalTools.popMessage(this, "Connection Error!");
					Response.Redirect("../../Login.aspx?expire=1");
				}
			}
			conn.ExecuteNonQuery();
			ViewData();
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			DDL_JNS_SANKSI.SelectedValue="";
			TXT_NO_SURAT.Text="";
			TXT_TGL_SURAT.Text="";
			DDL_BLN_SURAT.SelectedValue="";
			TXT_THN_SURAT.Text="";
			TXT_JANGKA_WKT_SANKSI.Text="";
			DDL_JANGKA_WKT_SANKSI.SelectedValue="";
			DDL_PROBLEM.SelectedValue="";
			TXT_STATUS_SANKSI.Text="";
		}

		protected void DDL_JNS_SANKSI_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewProblem();
		}
	}
}
