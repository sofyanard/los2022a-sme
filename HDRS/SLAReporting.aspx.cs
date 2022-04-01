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
using DMS.DBConnection;
using Microsoft.VisualBasic;
using DMS.CuBESCore;

namespace SME.HDRS
{
	/// <summary>
	/// Summary description for SLAReporting.
	/// </summary>
	public partial class SLAReporting : System.Web.UI.Page
	{
		protected Connection conn;
		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			if (!IsPostBack)
			{
				DDL_BLN1.Items.Add(new ListItem("-- PILIH --",""));
				DDL_BLN2.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_BLN1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}				
				TXT_TGL1.Text=DateAndTime.Today.Day.ToString();
				DDL_BLN1.SelectedValue=DateAndTime.Today.Month.ToString();
				TXT_THN1.Text=DateAndTime.Today.Year.ToString();
				TXT_TGL2.Text=DateAndTime.Today.Day.ToString();
				DDL_BLN2.SelectedValue=DateAndTime.Today.Month.ToString();
				TXT_THN2.Text=DateAndTime.Today.Year.ToString();

				DDL_PROB.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString = "select prob_cd, prob_desc from rfproblem where active='1'";
				conn.ExecuteQuery();	
				for(int i=0; i<conn.GetRowCount(); i++)
					DDL_PROB.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
		
				//ViewUserRespon();
				conn.QueryString = "select a.groupid, b.sg_grpname from grpaccessmenu a left join scgroup b on a.groupid=b.groupid where a.menucode like 'b02'" ;
				conn.ExecuteQuery();
				DDL_PIC2.Items.Add(new ListItem("--Pilih--",""));
				DDL_PIC.Items.Add(new ListItem("--Pilih--",""));
				for (int i=0; i < conn.GetRowCount(); i++)
					DDL_PIC2.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));	
			}
		}

		private void ViewUserRespon()
		{
			conn.QueryString="SELECT * FROM VW_HELPDESK_PIC_RESPON WHERE USERID='" + Session["UserID"].ToString() + "' ";
			conn.ExecuteQuery();
			string BUSS_ID_TXT="";
			BUSS_ID_TXT = conn.GetFieldValue("sg_bussunitid");
			conn.QueryString="select * from scgroup where sg_grpname like 'other%' and sg_bussunitid = '"+ BUSS_ID_TXT +"'";
			conn.ExecuteQuery();

			string PICID_TXT="";
			PICID_TXT = conn.GetFieldValue("groupid");
			conn.QueryString = "select userid, su_fullname from scuser where groupid = '"+ PICID_TXT +"'";
			conn.ExecuteQuery();

			DDL_PIC.Items.Add(new ListItem("--Pilih--",""));
			for (int i=0; i < conn.GetRowCount(); i++)
				DDL_PIC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

		}

		private void LoadSql(string action)
		{
			string h_problem_type	= DDL_PROB.SelectedValue;
			string pic_name			= DDL_PIC.SelectedValue;
			string h_pic_group		= DDL_PIC2.SelectedValue;
			
			string tanggal1 = "";
			string tanggal2 = "";
			
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
					LoadReport_Load(tanggal1, tanggal2, h_problem_type, h_pic_group, pic_name);
			}
			else
			{
				Response.Write("<script language='javascript'>alert('Invalid Date !')</script>");
			}
			
		}

		private void LoadReport_Load(string tanggal1, string tanggal2, string h_problem_type, string h_pic_group, string pic_name)
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

			ReportViewer1.ReportPath = "/SMEReports/HlpRptSla&date1="+ tanggal1 + "&date2=" + tanggal2 + "&h_problem_type=" + h_problem_type +  "&h_pic_group=" + h_pic_group + "&pic_name=" + pic_name + "&rs:Command=Render";
					
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

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			TXT_TGL1.Text="";
			DDL_BLN1.SelectedValue="";
			TXT_THN1.Text="";
			TXT_TGL2.Text="";
			DDL_BLN2.SelectedValue="";
			TXT_THN2.Text="";
			DDL_PIC.SelectedValue="";
			DDL_PROB.SelectedValue="";
		}

		protected void BTN_Back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("HelpDeskDashboard.aspx?mc=" + Request.QueryString["mc"]);
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			if (TXT_TGL1.Text=="" || DDL_BLN1.SelectedValue=="" || TXT_THN1.Text=="" || TXT_TGL2.Text=="" || DDL_BLN2.SelectedValue=="" || TXT_THN2.Text=="")
			{
				GlobalTools.popMessage(this, "Isi terlebih dahulu HRS Received Date!");
				return;	
			}
			LoadSql("");
		}

		private void ViewPic()
		{
			DDL_PIC.Items.Clear();
			DDL_PIC.Items.Add(new ListItem("- PILIH -", ""));
			
			conn.QueryString = "select userid, su_fullname from scuser where groupid='" + DDL_PIC2.SelectedValue + "' order by su_fullname";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_PIC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		protected void DDL_PIC2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewPic();
		}
	}
}
