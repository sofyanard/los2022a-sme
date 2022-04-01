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
	/// Summary description for Notaris.
	/// </summary>
	public partial class Notaris : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/../SME/Restricted.aspx");
			
			ViewMenu();
			
			if(!IsPostBack)
			{
				DDL_BLN_BURSA.Items.Add(new ListItem("--Pilih--", ""));
				DDL_BLN_PPAT.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN_SK.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN_SUMPAH.Items.Add(new ListItem("--Pilih--",""));

				for(int i=1; i<=12; i++)
				{
					DDL_BLN_BURSA.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_PPAT.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_SK.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_SUMPAH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				ViewData();
				TXT_HIGH_LIMIT.Text = tool.MoneyFormat(TXT_HIGH_LIMIT.Text);
			}
		}

		private void ViewData()
		{
			conn.QueryString = "select * from rekanan_notaris where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				TXT_REK_BURSA.Text = conn.GetFieldValue("REG_BURSA");
				TXT_TGL_BURSA.Text = tool.FormatDate_Day(conn.GetFieldValue("REG_DATE"));
				try{DDL_BLN_BURSA.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("REG_DATE"));}
				catch{DDL_BLN_BURSA.SelectedValue="";}
				TXT_THN_BURSA.Text = tool.FormatDate_Year(conn.GetFieldValue("REG_DATE"));
				TXT_HIGH_LIMIT.Text = conn.GetFieldValue("HIGH_LIMIT");
				TXT_SK_NOTARIS.Text = conn.GetFieldValue("SK_NOTARIS");
				TXT_TGL_SK.Text = tool.FormatDate_Day(conn.GetFieldValue("SK_DATE"));
				try{DDL_BLN_SK.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("SK_DATE"));}
				catch{DDL_BLN_SK.SelectedValue="";}
				TXT_THN_SK.Text = tool.FormatDate_Year(conn.GetFieldValue("SK_DATE"));
				TXT_KOTA_NOTARIS.Text = conn.GetFieldValue("NOTARY_CITY");
				TXT_SK_PPAT.Text = conn.GetFieldValue("PPAT");
				TXT_TGL_PPAT.Text = tool.FormatDate_Day(conn.GetFieldValue("PPAT_DATE"));
				try{DDL_BLN_PPAT.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("PPAT_DATE"));}
				catch{DDL_BLN_PPAT.SelectedValue = "";}
				TXT_THN_PPAT.Text = tool.FormatDate_Year(conn.GetFieldValue("PPAT_DATE"));
				TXT_PPAT_LOKASI.Text = conn.GetFieldValue("PPAT_LOKASI");
				TXT_SUMPAH_NOTARIS.Text = conn.GetFieldValue("NOTARY#");
				TXT_TGL_SUMPAH.Text = tool.FormatDate_Day(conn.GetFieldValue("NOTARY_DATE"));
				try{DDL_BLN_SUMPAH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("NOTARY_DATE"));}
				catch{DDL_BLN_SUMPAH.SelectedValue = "";}
				TXT_THN_SUMPAH.Text = tool.FormatDate_Year(conn.GetFieldValue("NOTARY_DATE"));
				TXT_REMARK.Text = conn.GetFieldValue("REMARKS");
			}
		}

		protected void BTN_SAVE_NOTARIS_Click(object sender, EventArgs e)
		{
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), BursaDate, SKDate, PPATDate, SumpahDate;
			
			//--VALIDASI TANGGAL REKENING PASAR MODAL--//
			try 
			{
				BursaDate = Int64.Parse(Tools.toISODate(TXT_TGL_BURSA.Text, DDL_BLN_BURSA.SelectedValue, TXT_THN_BURSA.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal rekening pasar modal tidak valid!");
				return;
			}
			if (BursaDate > now)
			{
				GlobalTools.popMessage(this, "Tanggal rekening pasar modal cannot be greater than current date!");
				return;
			}
			
			//--VALIDASI TANGGAL SK NOTARIS--//
			try 
			{
				SKDate = Int64.Parse(Tools.toISODate(TXT_TGL_SK.Text, DDL_BLN_SK.SelectedValue, TXT_THN_SK.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal SK notaris tidak valid!");
				return;
			}
			if (SKDate > now)
			{
				GlobalTools.popMessage(this, "Tanggal SK notaris cannot be greater than current date!");
				return;
			}

			//--VALIDASI TANGGAL PPAT--//
			try 
			{
				PPATDate = Int64.Parse(Tools.toISODate(TXT_TGL_PPAT.Text, DDL_BLN_PPAT.SelectedValue, TXT_THN_PPAT.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal PPAT tidak valid!");
				return;
			}
			if (PPATDate > now)
			{
				GlobalTools.popMessage(this, "Tanggal PPAT cannot be greater than current date!");
				return;
			}

			//--VALIDASI TANGGAL SUMPAH NOTARIS--//
			try 
			{
				SumpahDate = Int64.Parse(Tools.toISODate(TXT_TGL_SUMPAH.Text, DDL_BLN_SUMPAH.SelectedValue, TXT_THN_SUMPAH.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal sumpah notaris tidak valid!");
				return;
			}
			if (SumpahDate > now)
			{
				GlobalTools.popMessage(this, "Tanggal sumpah notaris cannot be greater than current date!");
				return;
			}

			conn.QueryString = "select * from rekanan_notaris where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				try
				{
					conn.QueryString = "exec REKANAN_NOTARIS_UPDATE '" +
						Request.QueryString["rekanan_ref"] + "', '" +
						TXT_REK_BURSA.Text + "', " +
						tool.ConvertDate(TXT_TGL_BURSA.Text, DDL_BLN_BURSA.SelectedValue, TXT_THN_BURSA.Text) + ", " +
						tool.ConvertFloat(TXT_HIGH_LIMIT.Text) + ", '" +
						TXT_SK_NOTARIS.Text + "', " +
						tool.ConvertDate(TXT_TGL_SK.Text, DDL_BLN_SK.SelectedValue, TXT_THN_SK.Text) + ", '" +
						TXT_KOTA_NOTARIS.Text + "', '" +
						TXT_SK_PPAT.Text + "', " +
						tool.ConvertDate(TXT_TGL_PPAT.Text, DDL_BLN_PPAT.SelectedValue, TXT_THN_PPAT.Text) + ", '" +
						TXT_PPAT_LOKASI.Text + "', '" +
						TXT_SUMPAH_NOTARIS.Text + "', " +
						tool.ConvertDate(TXT_TGL_SUMPAH.Text, DDL_BLN_SUMPAH.SelectedValue, TXT_THN_SUMPAH.Text) + ", '" +
						TXT_REMARK.Text + "'";
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
					conn.QueryString = "exec REKANAN_NOTARIS_INSERT '" +
						Request.QueryString["rekanan_ref"] + "', '" +
						TXT_REK_BURSA.Text + "', " +
						tool.ConvertDate(TXT_TGL_BURSA.Text, DDL_BLN_BURSA.SelectedValue, TXT_THN_BURSA.Text) + ", " +
						tool.ConvertFloat(TXT_HIGH_LIMIT.Text) + ", '" +
						TXT_SK_NOTARIS.Text + "', " +
						tool.ConvertDate(TXT_TGL_SK.Text, DDL_BLN_SK.SelectedValue, TXT_THN_SK.Text) + ", '" +
						TXT_KOTA_NOTARIS.Text + "', '" +
						TXT_SK_PPAT.Text + "', " +
						tool.ConvertDate(TXT_TGL_PPAT.Text, DDL_BLN_PPAT.SelectedValue, TXT_THN_PPAT.Text) + ", '" +
						TXT_PPAT_LOKASI.Text + "', '" +
						TXT_SUMPAH_NOTARIS.Text + "', " +
						tool.ConvertDate(TXT_TGL_SUMPAH.Text, DDL_BLN_SUMPAH.SelectedValue, TXT_THN_SUMPAH.Text) + ", '" +
						TXT_REMARK.Text + "'";
				}
				catch
				{
					GlobalTools.popMessage(this, "Connection Error!");
					Response.Redirect("../../Login.aspx?expire=1");
				}
			}
			conn.ExecuteNonQuery();
		}

		protected void BTN_CLEAR_NOTARIS_Click(object sender, EventArgs e)
		{
			TXT_REK_BURSA.Text = "";
			TXT_TGL_BURSA.Text = "";
			DDL_BLN_BURSA.SelectedValue = "";
			TXT_THN_BURSA.Text = "";
			TXT_HIGH_LIMIT.Text = "";
			TXT_SK_NOTARIS.Text = "";
			TXT_TGL_SK.Text = "";
			DDL_BLN_SK.SelectedValue = "";
			TXT_THN_SK.Text = "";
			TXT_KOTA_NOTARIS.Text = "";
			TXT_SK_PPAT.Text = "";
			TXT_TGL_PPAT.Text = "";
			DDL_BLN_PPAT.SelectedValue = "";
			TXT_THN_PPAT.Text = "";
			TXT_PPAT_LOKASI.Text = "";
			TXT_SUMPAH_NOTARIS.Text = "";
			TXT_TGL_SUMPAH.Text = "";
			DDL_BLN_SUMPAH.SelectedValue = "";
			TXT_THN_SUMPAH.Text = "";
			TXT_REMARK.Text = "";
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
					MenuNotaris.Controls.Add(t);
					MenuNotaris.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
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
	}
}
