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
using System.Configuration;

namespace SME.DCM
{
	/// <summary>
	/// Summary description for LoanDetailDataCO2.
	/// </summary>
	public partial class LoanDetailDataCO2 : System.Web.UI.Page
	{
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				ViewBulan();
				JenisPar();
				BTN_UPDATE.Enabled=false;
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

		private void JenisPar()
		{
			DDL_JNS_REST.Items.Add(new ListItem("--Pilih--","0"));
			conn2.QueryString="select * from RF_RESTRU_TYPE where active='1'";
			conn2.ExecuteQuery();
			for (int i = 0; i < conn2.GetRowCount(); i++) 
			{
				DDL_JNS_REST.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0))); 
			}

			DDL_KOLE.Items.Add(new ListItem("--Pilih--","0"));
			conn2.QueryString="select * from RF_BICOL where active='1'";
			conn2.ExecuteQuery();
			for (int j = 0; j < conn2.GetRowCount(); j++) 
			{
				DDL_KOLE.Items.Add(new ListItem(conn2.GetFieldValue(j,1), conn2.GetFieldValue(j,0))); 
			}

			DDL_KET_REST.Items.Add(new ListItem("--Pilih--","0"));
			conn2.QueryString="select * from RF_KET_RESTRU where active='1'";
			conn2.ExecuteQuery();
			for (int k = 0; k < conn2.GetRowCount(); k++) 
			{
				DDL_KET_REST.Items.Add(new ListItem(conn2.GetFieldValue(k,1), conn2.GetFieldValue(k,0))); 
			}

			DDL_SANDI.Items.Add(new ListItem("--Pilih--","0"));
			conn2.QueryString="select * from RF_POSITION where active='1'";
			conn2.ExecuteQuery();
			for (int l = 0; l < conn2.GetRowCount(); l++) 
			{
				DDL_SANDI.Items.Add(new ListItem(conn2.GetFieldValue(l,1), conn2.GetFieldValue(l,0))); 
			}

			DDL_MACET.Items.Add(new ListItem("--Pilih--","0"));
			conn2.QueryString="select * from RF_POSITION where active='1'";
			conn2.ExecuteQuery();
			for (int m = 0; m < conn2.GetRowCount(); m++) 
			{
				DDL_MACET.Items.Add(new ListItem(conn2.GetFieldValue(m,1), conn2.GetFieldValue(m,0))); 
			}
		}

		private void ViewBulan()
		{
			DDL_BLN_PK_AWAL.Items.Add(new ListItem("--Pilih--", ""));
			DDL_BLN_PK_AKHIR.Items.Add(new ListItem("--Pilih--",""));
			DDL_BLN_REST_AW.Items.Add(new ListItem("--Pilih--",""));
			DDL_BLN_REST_AKH.Items.Add(new ListItem("--Pilih--",""));
			DDL_BLN_RVW.Items.Add(new ListItem("--Pilih--",""));
			DDL_BLN_POS.Items.Add(new ListItem("--Pilih--",""));
			DDL_BLN_MCT.Items.Add(new ListItem("--Pilih--",""));
			
			for(int i=1; i<=12; i++)
			{
				DDL_BLN_PK_AWAL.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN_PK_AKHIR.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN_REST_AW.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN_REST_AKH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN_RVW.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN_POS.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN_MCT.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));				
			}
		}


		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn2.QueryString = " exec DQM_LOAN_CO_INSERT '" +
				Request.QueryString["acctno"] + "', '" +
				tool.ConvertDate(TXT_TGL_PK_AWAL.Text, DDL_BLN_PK_AWAL.SelectedValue, TXT_THN_PK_AWAL.Text) + ", '" +
				TXT_NOPK_AWAL.Text +"', '"+				
				tool.ConvertDate(TXT_TGL_PK_AKHIR.Text, DDL_BLN_PK_AKHIR.SelectedValue, TXT_THN_PK_AKHIR.Text) + ", '" +
				TXT_NOPK_AKHIR.Text +"', '"+
				RDO_PPA.SelectedValue +"', '"+
				RDO_KOLE.SelectedValue +"', '"+
				RDO_FLAG.SelectedValue +"', '"+
				RDO_RESTRU.SelectedValue +"', '"+
				tool.ConvertDate(TXT_TGL_REST_AW.Text, DDL_BLN_REST_AW.SelectedValue, TXT_THN_REST_AW.Text) + ", '" +
				tool.ConvertDate(TXT_TGL_REST_AKH.Text, DDL_BLN_REST_AKH.SelectedValue, TXT_THN_REST_AKH.Text) + ", '" +				
				DDL_JNS_REST.SelectedValue +"','"+
				DDL_KOLE.SelectedValue  +"','"+
				tool.ConvertDate(TXT_TGL_RVW.Text, DDL_BLN_RVW.SelectedValue, TXT_THN_REST.Text) + ", '" +
				TXT_REST_KE.Text +"', '"+
				DDL_KET_REST.SelectedValue +"', '"+
				DDL_SANDI.SelectedValue +"', '"+
				tool.ConvertDate(TXT_TGL_POS.Text, DDL_BLN_POS.SelectedValue, TXT_THN_POS.Text) + ", '" +
				DDL_MACET.SelectedValue +"', '"+
				tool.ConvertDate(TXT_TGL_MCT.Text, DDL_BLN_MCT.SelectedValue, TXT_THN_MCT.Text) + "', '0' ";
			conn2.ExecuteNonQuery();

			BTN_UPDATE.Enabled = true;
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			conn2.QueryString = "update PENDING_LOAN_CO set flag='1' where where ACCTNO='"+ Request.QueryString["acctno"] +"' ";
			conn2.ExecuteQuery();
			Response.Redirect("LoanListData.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("LoanListData.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}
	}
}
