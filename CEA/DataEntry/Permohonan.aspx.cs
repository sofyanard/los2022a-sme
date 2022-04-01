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
using System.Configuration;
using DMS.DBConnection;
using DMS.CuBESCore;
using Microsoft.VisualBasic;


namespace dbrbm.Data_Entry
{
	/// <summary>
	/// Summary description for Permohonan.
	/// </summary>
	public partial class Permohonan : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
			// Put user code to initialize the page here
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

		private void ShowBlank()
		{
			TXT_KETERANGAN.Text = "";
		}

		private void FillCSGrid()
		{
			DataTable dt = new DataTable();
			conn.QueryString = "select *, case isnull(apptype,'0') when '0' then 'Baru' when '1' then 'Perpanjangan'when '2' then 'Peningkatan Klasifikasi' when '4' then 'Pengaktifan Kembali' end as apptype_desc from custproduct where no_registrasi ='"+ Request.QueryString["noreg"] + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DGR_PERMOHONAN.DataSource = dt;
			DGR_PERMOHONAN.DataBind();
		}
		protected void BTN_ADD_Click(object sender, System.EventArgs e)
		{
			SEQ.Text="";
			conn.QueryString = "exec DE_CUSTPRODUCT '" + 
				Request.QueryString["noreg"] + "', '" + 
				RDO_PBARU.SelectedValue + "', '" + tool.ConvertNull(DDL_JENISREKANAN.SelectedValue) + "', '" + TXT_KETERANGAN + "'";
				
			conn.ExecuteNonQuery();
			/*
			conn.QueryString = "insert into cust_stockholder " + 
				"(cu_ref, seq, cs_firstname, cs_middlename, cs_lastname, cs_dob, cs_idcardnum, cs_npwp, cs_experience, cs_education, cs_jobtitle, cs_stockperc, cs_natstat, active, cs_addr1, cs_addr2, cs_addr3, cs_zipcode) " + 
				"values ('" + Request.QueryString["curef"] + "', " + 
				count.ToString() + ", '" + 
				TXT_CS_FIRSTNAME.Text + "', '" + 
				TXT_CS_MIDDLENAME.Text + "', '" + 
				TXT_CS_LASTNAME.Text + "', " + 
				tool.ConvertDate(TXT_CS_DOB_DAY.Text, DDL_CS_DOB_MONTH.SelectedValue, TXT_CS_DOB_YEAR.Text) + ", '" + 
				TXT_CS_IDCARDNUM.Text + "', '" + 
				TXT_CS_NPWP.Text + "', " + 
				tool.ConvertNull(DDL_CS_EXPERIENCE.SelectedValue) + ", " + 
				tool.ConvertNull(DDL_CS_EDUCATION.SelectedValue) + ", " + 
				tool.ConvertNull(DDL_CS_JOBTITLE.SelectedValue) + ", " + 
				TXT_CS_STOCKPERC.Text + ", '" + status + "', '1', '" + 
				TXT_CS_ADDR1.Text + "', '" + TXT_CS_ADDR2.Text + "', '" + TXT_CS_ADDR3.Text + "', '" + 
				TXT_CS_ZIPCODE.Text + "')";
			conn.ExecuteNonQuery();
			*/

			ShowBlank();			
			FillCSGrid();
			//
			// kalau ada penambahan orang, reset nama stockholder account
			//
			BTN_ADD.Visible = false;			
			BTN_CANCEL.Visible = true;

			RDO_PBARU.Enabled = false;
			DDL_JENISREKANAN.Enabled = false;

			BTN_SAVE.Enabled = true;			


			/////////////////////////////////////////////////////////////////////////////////////
			/// Get CU_REF Channeling Company
			/// 
			///////////////////////////////////////


		}

	}
}
