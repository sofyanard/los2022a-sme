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

namespace SME.CEA
{
	/// <summary>
	/// Summary description for DetailDataRekanan.
	/// </summary>
	public partial class DetailDataRekanan : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DatGrd;
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			
			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], Conn))
			//Response.Redirect("/SME/Restricted.aspx");
			if (!IsPostBack)
			{
				DDL_JNS_REK.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString = "select rekananid, rekanandesc from rfjenisrekanan where active='1'";
				conn.ExecuteQuery();
	
				for(int i=0; i<conn.GetRowCount(); i++)
					DDL_JNS_REK.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

				DDL_WILAYAH.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString = "select areaid, areaname from rfarea where active='1'";
				conn.ExecuteQuery();

				for(int i=0; i<conn.GetRowCount(); i++)
					DDL_WILAYAH.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				
				//penambahan DDL KLASIFIKASI 13-2-2013 Oleh Ariel
				DDL_KLASIFIKASI.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString = "select KL_ID from REKANAN_RFKLASIFIKASI where active=1";
				conn.ExecuteQuery();

				for(int i=0; i<conn.GetRowCount(); i++)
					DDL_KLASIFIKASI.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));




				/*DDL_CABANG.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString = "select cityid, cityname from rfcity where active='1'";
				conn.ExecuteQuery();

				for(int i=0; i<conn.GetRowCount(); i++)
					DDL_CABANG.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				*/
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

		private void Load_ReportViewer(string kriteria)
		{
			string ReportAddr;

			conn.QueryString = "select reportaddr from app_parameter";
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
				ReportAddr = conn.GetFieldValue(0,0);
			else
				ReportAddr  = "10.123.12.50";
			ReportViewer2.ServerUrl = "http://" + ReportAddr + "/ReportServer";
			ReportViewer2.ReportPath = "/SMEReports/RptRekananData&sql_kondisi=" + kriteria;
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			LoadSql();
		}

		private void LoadSql()
		{
			string kriterianya = "";
			string nama = TXT_NAMA.Text;
			string JNS_REK = DDL_JNS_REK.SelectedValue;
			string NoReg = TXT_REGNUM.Text;
			string wilayah = DDL_WILAYAH.SelectedValue;
			string klasifikasi = DDL_KLASIFIKASI.SelectedValue;
			//string cabang = DDL_CABANG.SelectedValue;
			/*string kriteriaId ="";
			string kriteria1 = "";
			string kriteria2 = "";

			if (!nama.Equals(""))
			{
				kriterianya = nama;
				kriteriaId = "1";
			}
			else
				if(!JNS_REK.Equals(""))
			{
				kriterianya = JNS_REK;
				kriteriaId = "2";
			}
			else
				if(!NoReg.Equals(""))
			{
				kriterianya =NoReg;
				kriteriaId = "3";
			}*/

			if(!nama.Equals(""))
			{
				kriterianya += " and namarekanan like '%" + nama + "%'";
			}
			if(!JNS_REK.Equals(""))
			{
				kriterianya += " and rfrekanantype='" + JNS_REK + "'";
			}
			if(!NoReg.Equals(""))
			{
				kriterianya += " and regnum='" + NoReg + "'";
			}
			if(!wilayah.Equals(""))
			{
				kriterianya += " and rekanan_wilayah='" + wilayah + "'";
			}
			if(!klasifikasi.Equals(""))
			{
				kriterianya += " and klasifikasi='" + klasifikasi + "'";
			}
			/*if(!cabang.Equals(""))
			{
				kriterianya += " and cityid='" + cabang + "'";
			}*/

			/*conn.QueryString = "Delete from REKANAN_TMP_DATAREKANAN where userid='" + Session["UserID"].ToString()  + "' ";
			conn.ExecuteQuery();

			conn.QueryString = " exec rekanan_tmpdatarekanan_insert '" + Session["UserID"].ToString() + "', '" +
				kriterianya + "', '" + kriteriaId + "'";
			conn.ExecuteQuery(1800);*/

			if(kriterianya!="")
				Load_ReportViewer(kriterianya);

		}
		protected void BTN_Back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ReportingListing.aspx?mc=" + Request.QueryString["mc"]);
			
		}
	}
}
