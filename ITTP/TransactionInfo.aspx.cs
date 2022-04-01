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

namespace SME.ITTP
{
	/// <summary>
	/// Summary description for TransactionInfo.
	/// </summary>
	public partial class TransactionInfo : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			ViewMenu();

			if (!IsPostBack)
			{
				//Region
				TXT_REGION.Text = Session["AreaName"].ToString();

				//ap_regno
				TXT_AP_REGNO.Text = Request.QueryString["regno"];

				//Business Unit / Cabang
				conn.QueryString = "SELECT b.BUSSUNITID, BUSSUNITDESC FROM rfbranch a left join RFBUSINESSUNIT b on a.BUSSUNITID = b.BUSSUNITID where BRANCH_CODE = '" + Session["BranchID"].ToString() + "'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					TXT_BUSINESS_UNIT.Text = conn.GetFieldValue("BUSSUNITDESC");
					temp_txt_business_unit.Text = conn.GetFieldValue("BUSSUNITID");
				}

				DDL_AP_SIGNDATE_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_OPERATION_UNIT.Items.Add(new ListItem("- PILIH -", ""));

				//Program
				conn.QueryString = "SELECT PROGRAMID, PROGRAMDESC FROM RFPROGRAM WHERE AREAID = '" + Session["AreaID"] + "' AND ACTIVE = '1' AND PROGRAMID like '%0000%' AND BUSINESSUNIT = '" + temp_txt_business_unit.Text + "'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_PROGRAM.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//Operation Unit
				conn.QueryString = "select branch_code, branch_name from rfbranch where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_OPERATION_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//Disable item app
				TXT_REGION.Enabled=false;
				TXT_BUSINESS_UNIT.Enabled=false;

				//Hide item
				temp_txt_business_unit.Visible=false;

				//Tanggal
				for (int i = 1; i <= 12; i++)
				{
					DDL_AP_SIGNDATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				//Tools.initDateForm(TXT_AP_SIGNDATE_DAY, DDL_AP_SIGNDATE_MONTH, TXT_AP_SIGNDATE_YEAR, false);

				//fillAcquireInformation();

				BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");

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
