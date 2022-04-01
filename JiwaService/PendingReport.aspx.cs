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
using Microsoft.VisualBasic;

namespace SME.JiwaService
{
	/// <summary>
	/// Summary description for PendingReport.
	/// </summary>
	public partial class PendingReport : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				FillDDLPosition();
				DDL_BLN1.Items.Add(new ListItem("-- Pilih --",""));
				DDL_BLN2.Items.Add(new ListItem("-- Pilih --",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_BLN1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
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

		private void FillDDLPosition()
		{
			DDL_POSITION.Items.Clear();
			DDL_POSITION.Items.Add(new ListItem("--Pilih--", ""));

			conn.QueryString = "EXEC JWS_SERVICE_FUNCTION ''";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_POSITION.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}
		
		protected void BTN_Find_Click(object sender, System.EventArgs e)
		{
			string position = DDL_POSITION.SelectedValue;
			string tanggal1 = "";
			string tanggal2 = "";
			
			if (TXT_TGL1.Text=="" && DDL_BLN1.SelectedValue=="" && TXT_THN1.Text=="" && TXT_TGL2.Text=="" && DDL_BLN2.SelectedValue=="" && TXT_THN2.Text=="")
			{
				LoadReport_Load(position, tanggal1, tanggal2);
			}
			else
			{
				if (Tools.isDateValid(this,TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text)&&Tools.isDateValid(this, TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text))
				{
					tanggal1 = tools.ConvertDate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);
					tanggal2 = tools.ConvertDate(TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text);

					if (!Information.IsDate(tanggal1) || !Information.IsDate(tanggal2))
					{
						Tools.popMessage(this,"Invalid date");
						if (!Information.IsDate(tanggal1))
							Tools.SetFocus(this,TXT_TGL1);
						else
							Tools.SetFocus(this,TXT_TGL2);
					}
					else
					{
						tanggal1		= tanggal1.Replace("'","");
						tanggal2		= tanggal2.Replace("'","");

						LoadReport_Load(position, tanggal1, tanggal2);
					}
				}
				else
				{
					Response.Write("<script language='javascript'>alert('Invalid Date !')</script>");
				}
			}
		}

		private void LoadReport_Load(string position, string tanggal1, string tanggal2)
		{	
			string ReportAddr="";
			conn.QueryString = "select reportaddr from app_parameter";
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
			{
				ReportAddr = conn.GetFieldValue(0,0);
			}
			else
			{
				ReportAddr  = "10.123.12.50";
			}
			
			ReportViewer1.ServerUrl = "http://" + ReportAddr + "/ReportServer";

			ReportViewer1.ReportPath = "/SMEReports/RptJwsPending&position=" + position + "&date1=" + tanggal1 + "&date2=" + tanggal2;
		}

		protected void BTN_Cancel_Click(object sender, System.EventArgs e)
		{
			TXT_TGL1.Text="";
			DDL_BLN1.SelectedValue="";
			TXT_THN1.Text="";
			TXT_TGL2.Text="";
			DDL_BLN2.SelectedValue="";
			TXT_THN2.Text="";
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("Dashboard.aspx?mc=" + Request.QueryString["mc"]);
		}
	}
}
