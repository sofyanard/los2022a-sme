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
	/// Summary description for SelfReport.
	/// </summary>
	public partial class SelfReport : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				DDL_GROUP.Items.Add(new ListItem("--Pilih--",""));
				DDL_DEPT.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN1.Items.Add(new ListItem("-- Pilih --",""));
				DDL_BLN2.Items.Add(new ListItem("-- Pilih --",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_BLN1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				FillGroup();
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

		private void FillGroup()
		{
			DDL_GROUP.Items.Clear();
			DDL_GROUP.Items.Add(new ListItem("--Pilih--",""));

			conn.QueryString = "SELECT DISTINCT G_CODE, G_DESC FROM RF_DEPT WHERE STATUS='1'";
			conn.ExecuteQuery();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_GROUP.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		protected void DDL_GROUP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillDept();
		}

		private void FillDept()
		{
			DDL_DEPT.Items.Clear();
			DDL_DEPT.Items.Add(new ListItem("--Pilih--",""));

			conn.QueryString = "SELECT DISTINCT D_CODE, D_DESCNEW FROM RF_DEPT WHERE G_CODE='" + DDL_GROUP.SelectedValue + "' AND STATUS='1'";
			conn.ExecuteQuery();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_DEPT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		protected void BTN_Find_Click(object sender, System.EventArgs e)
		{
			string group		= DDL_GROUP.SelectedValue;
			string dept			= DDL_DEPT.SelectedValue;

			string tanggal1 = "";
			string tanggal2 = "";
			
			if (TXT_TGL1.Text=="" && DDL_BLN1.SelectedValue=="" && TXT_THN1.Text=="" && TXT_TGL2.Text=="" && DDL_BLN2.SelectedValue=="" && TXT_THN2.Text=="")
			{
				LoadReport_Load(group, dept, tanggal1, tanggal2);
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

						LoadReport_Load(group, dept, tanggal1, tanggal2);
					}
				}
				else
				{
					Response.Write("<script language='javascript'>alert('Invalid Date !')</script>");
				}
			}
		}

		private void LoadReport_Load(string group, string dept, string tanggal1, string tanggal2)
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

			ReportViewer1.ReportPath = "/SMEReports/RptJwsSelf&group=" + group + "&dept=" + dept + "&date1=" + tanggal1 + "&date2=" + tanggal2;
		}

		protected void BTN_Cancel_Click(object sender, System.EventArgs e)
		{
			DDL_GROUP.SelectedValue="";
			FillDept();
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
