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
	/// Summary description for DataKewajibanSpot.
	/// </summary>
	public partial class DataKewajibanSpot : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList Dropdownlist23;
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if(!IsPostBack)
			{
				DDL_GOL_LAWAN.Items.Add(new ListItem("--Pilih--",""));
				DDL_HUB_BANK.Items.Add(new ListItem("--Pilih--",""));
				DDL_JENIS.Items.Add(new ListItem("--Pilih--",""));
				DDL_KONTRAK.Items.Add(new ListItem("--Pilih--",""));
				DDL_NEGARA_LAWAN.Items.Add(new ListItem("--Pilih--",""));
				DDL_STATUS_LAWAN.Items.Add(new ListItem("--Pilih--",""));
				DDL_UNDERLYING_VARIABLE.Items.Add(new ListItem("--Pilih--",""));

				conn2.QueryString = "select * from vw_dcm_cif_ddl_jenisdebitur";
				conn2.ExecuteQuery();
				for(int i=0; i<conn2.GetRowCount(); i++)
					DDL_JENIS.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DC_TREASURY_DDLKONTRAK";
				conn2.ExecuteQuery();
				for(int i=0; i<conn2.GetRowCount(); i++)
					DDL_KONTRAK.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DC_TREASURY_UNDERLYING_VARIABLE";
				conn2.ExecuteQuery();
				for(int i=0; i<conn2.GetRowCount(); i++)
					DDL_UNDERLYING_VARIABLE.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));




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
