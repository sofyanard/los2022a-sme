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
	/// Summary description for DetailDataSaving.
	/// </summary>
	public partial class DetailDataSaving : System.Web.UI.Page
	{
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				DDL_TUJUAN_DANA.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_PENDAPATAN.Items.Add(new ListItem("-- Pilih --",""));
				DDL_TUJUAN_REK.Items.Add(new ListItem("-- Pilih --", ""));

				conn2.QueryString = "select pembukaan_rekg_cd, pembukaan_rekg_desc from rf_pembukaan_rekg where active = '1'";
				conn2.ExecuteQuery();

				for (int i=0; i < conn2.GetRowCount(); i++)
					DDL_TUJUAN_REK.Items.Add(new ListItem(conn2.GetFieldValue(i,0) + " - " + conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select SALARY_CD, SALARY_DESC from rf_salary_range where active = '1'";
				conn2.ExecuteQuery();

				for (int i=0; i < conn2.GetRowCount(); i++)
					DDL_PENDAPATAN.Items.Add(new ListItem(conn2.GetFieldValue(i,0) + " - " + conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select PENGGU_CD, PENGGU_DESC from rf_penggu_dana where active = '1'";
				conn2.ExecuteQuery();

				for (int i=0; i < conn2.GetRowCount(); i++)
					DDL_TUJUAN_DANA.Items.Add(new ListItem(conn2.GetFieldValue(i,0) + " - " + conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));

                ViewData();
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

		private void ViewData()
		{
			conn2.QueryString = "select sname, error_msg from buc_dana where acctno='" + Request.QueryString["acc"] + "'";
			conn2.ExecuteQuery(100000);

			TXT_ERROR_MSG.Text = conn2.GetFieldValue("error_msg");
			TXT_REKNUM.Text = Request.QueryString["acc"];
			TXT_NAMA.Text = conn2.GetFieldValue("sname");

			conn2.QueryString = "select * from ec_dana where ac_act#='" + Request.QueryString["acc"] + "' and flag in ('0','1')";
			conn2.ExecuteQuery(10000);
			
			if(conn2.GetRowCount()>0)
			{
				try{DDL_PENDAPATAN.SelectedValue = conn2.GetFieldValue("SALARY_RANGE");}
				catch{DDL_PENDAPATAN.SelectedValue = "";}
				try{DDL_TUJUAN_DANA.SelectedValue = conn2.GetFieldValue("AC_TUJUAN_PENGGU_DANA");}
				catch{DDL_TUJUAN_DANA.SelectedValue = "";}
				try{DDL_TUJUAN_REK.SelectedValue = conn2.GetFieldValue("AC_TUJUAN_PEMBU_REKG");}
				catch{DDL_TUJUAN_REK.SelectedValue = "";}
			}
				
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			string pesan="";
			try
			{
				conn2.QueryString = "EXEC DCM_DATA_DANA_INSERT '" + TXT_REKNUM.Text + "', '" +
					TXT_NAMA.Text + "', '" + DDL_PENDAPATAN.SelectedValue + "', '" + DDL_TUJUAN_DANA.SelectedValue + "', '" +
					DDL_TUJUAN_REK.SelectedValue + "', '" + Request.QueryString["from_appr"] + "', '" +
					Session["UserID"].ToString() + "', '" + Session["FullName"].ToString() + "'";
				conn2.ExecuteQuery(100000);

				pesan = "Data berhasil di simpan";
			}
			catch
			{
				pesan = "Data gagal disimpan, silahkan ulangi kembali!";
			}
			
			if(Request.QueryString["from_appr"]!="" && Request.QueryString["from_appr"]!= null)
			{
				Response.Redirect("DanaListDataApproval.aspx?msg=" + pesan);
			}
			else
			{
				Response.Redirect("ListData.aspx?msg=" + pesan);
			}
		}
	}
}
