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
	/// Summary description for ParameterReport.
	/// </summary>
	public class ParameterReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton btn_back;
		protected System.Web.UI.WebControls.TextBox TXT_TGL1;
		protected System.Web.UI.WebControls.DropDownList DDL_BLN1;
		protected System.Web.UI.WebControls.TextBox TXT_THN1;
		protected System.Web.UI.WebControls.TextBox TXT_TGL2;
		protected System.Web.UI.WebControls.DropDownList DDL_BLN2;
		protected System.Web.UI.WebControls.TextBox TXT_THN2;
		protected System.Web.UI.WebControls.Button BTN_Find;
		protected System.Web.UI.WebControls.Button BTN_Cancel;
		protected Microsoft.Samples.ReportingServices.ReportViewer ReportViewer1;
		protected System.Web.UI.WebControls.DropDownList DDL_PARAMETER;
		protected System.Web.UI.WebControls.DropDownList DDL_USER;
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected Tools tools = new Tools();
		protected Connection conn;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				DDL_PARAMETER.Items.Add(new ListItem("--Pilih--",""));
				DDL_USER.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN1.Items.Add(new ListItem("-- Pilih --",""));
				DDL_BLN2.Items.Add(new ListItem("-- Pilih --",""));
				DDL_USER.Items.Add(new ListItem("--Pilih--",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_BLN1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				FillParam();
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
			this.DDL_PARAMETER.SelectedIndexChanged += new System.EventHandler(this.DDL_PARAMETER_SelectedIndexChanged);
			this.BTN_BACK.Click += new System.Web.UI.ImageClickEventHandler(this.BTN_BACK_Click);
			this.BTN_Find.Click += new System.EventHandler(this.BTN_Find_Click);
			this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void FillParam()
		{
			DDL_PARAMETER.Items.Clear();
			DDL_PARAMETER.Items.Add(new ListItem("--Pilih--",""));

			conn.QueryString = "EXEC JWS_PARAM_LIST ''";
			conn.ExecuteQuery();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_PARAMETER.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void DDL_PARAMETER_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillUser();
		}

		private void FillUser()
		{
			DDL_USER.Items.Clear();
			DDL_USER.Items.Add(new ListItem("--Pilih--",""));

			switch(DDL_PARAMETER.SelectedValue)
			{
				case "01":
					conn.QueryString = "SELECT DISTINCT [USER], [USER_NAME] FROM RFDEPT_HISTORY WHERE STATUS='1'";
					conn.ExecuteQuery();
					for(int i = 0; i < conn.GetRowCount(); i++)
					{
						DDL_USER.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					}
					break;
				case "02": 
					conn.QueryString = "SELECT DISTINCT [USER], [USER_NAME] FROM RFSELF_HISTORY WHERE STATUS='1'";
					conn.ExecuteQuery();
					for(int i = 0; i < conn.GetRowCount(); i++)
					{
						DDL_USER.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					}
					break;
				case "03":
					conn.QueryString = "SELECT DISTINCT [USER], [USER_NAME] FROM RFCUSTOMER_HISTORY WHERE STATUS='1'";
					conn.ExecuteQuery();
					for(int i = 0; i < conn.GetRowCount(); i++)
					{
						DDL_USER.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					}
					break;
				case "04":
					conn.QueryString = "SELECT DISTINCT [USER], [USER_NAME] FROM RFLINK_HISTORY WHERE STATUS='1'";
					conn.ExecuteQuery();
					for(int i = 0; i < conn.GetRowCount(); i++)
					{
						DDL_USER.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					}
					break;
				case "05":
					conn.QueryString = "SELECT DISTINCT [USER], [USER_NAME] FROM RFSCORE_HISTORY WHERE STATUS='1'";
					conn.ExecuteQuery();
					for(int i = 0; i < conn.GetRowCount(); i++)
					{
						DDL_USER.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					}
					break;
			}
		}

		private void BTN_Find_Click(object sender, System.EventArgs e)
		{
			string param		= DDL_PARAMETER.SelectedValue;
			string user			= DDL_USER.SelectedValue;

			string tanggal1 = "";
			string tanggal2 = "";
			
			if(DDL_PARAMETER.SelectedValue=="")
			{
				Tools.popMessage(this, "Invalid Parameter!");
			}

			else if (TXT_TGL1.Text=="" && DDL_BLN1.SelectedValue=="" && TXT_THN1.Text=="" && TXT_TGL2.Text=="" && DDL_BLN2.SelectedValue=="" && TXT_THN2.Text=="")
			{
				LoadReport_Load(param, user, tanggal1, tanggal2);
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

						LoadReport_Load(param, user, tanggal1, tanggal2);
					}
				}
				else
				{
					Response.Write("<script language='javascript'>alert('Invalid Date !')</script>");
				}
			}
		}

		private void LoadReport_Load(string param, string user, string tanggal1, string tanggal2)
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

			switch(param.ToString())
			{
				case "01":
					ReportViewer1.ReportPath = "/SMEReports/RptJwsParDept&param=" + param + "&user=" + user + "&date1=" + tanggal1 + "&date2=" + tanggal2;
					break;
				case "02": 
					ReportViewer1.ReportPath = "/SMEReports/RptJwsParSelf&param=" + param + "&user=" + user + "&date1=" + tanggal1 + "&date2=" + tanggal2;
					break;
				case "03":
					ReportViewer1.ReportPath = "/SMEReports/RptJwsParCust&param=" + param + "&user=" + user + "&date1=" + tanggal1 + "&date2=" + tanggal2;
					break;
				case "04":
					ReportViewer1.ReportPath = "/SMEReports/RptJwsParLink&param=" + param + "&user=" + user + "&date1=" + tanggal1 + "&date2=" + tanggal2;
					break;
				case "05":
					ReportViewer1.ReportPath = "/SMEReports/RptJwsParScore&param=" + param + "&user=" + user + "&date1=" + tanggal1 + "&date2=" + tanggal2;
					break;
			}
		}

		private void BTN_Cancel_Click(object sender, System.EventArgs e)
		{
			DDL_PARAMETER.SelectedValue="";
			FillUser();
			TXT_TGL1.Text="";
			DDL_BLN1.SelectedValue="";
			TXT_THN1.Text="";
			TXT_TGL2.Text="";
			DDL_BLN2.SelectedValue="";
			TXT_THN2.Text="";
		}

		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("Dashboard.aspx?mc=" + Request.QueryString["mc"]);
		}
	}
}
