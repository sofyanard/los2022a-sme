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

namespace SME.RejectMaintenanceDE
{
	/// <summary>
	/// Summary description for M21M22PerubahanSyarat.
	/// </summary>
	public partial class M21M22PerubahanSyarat : System.Web.UI.Page
	{

		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				conn.QueryString = "select cu_ref from application where ap_regno='" + LBL_REGNO.Text + "'";
				conn.ExecuteQuery();
				LBL_CUREF.Text = conn.GetFieldValue("cu_ref");
				LBL_PRODID.Text = Request.QueryString["prodid"];
				LBL_APPTYPE.Text = Request.QueryString["apptype"];
				LBL_PROD_SEQ.Text = Request.QueryString["prod_seq"];
				viewdata();
			}
		}

		private void viewdata()
		{
			conn.QueryString = "select APPTYPEDESC, PRODUCTDESC, CP_LOANPURPOSE, "+
				"CP_LIMIT, CP_installment, AA_NO, ACC_SEQ, "+
				"CP_KETERANGAN, ACC_NO, CP_VARCODE, CP_RATENO, CP_VARIANCE, "+
				"REVOLVING, CURRENCY, NEWVALUE, NEWCODE, OLDVALUE, OLDCODE "+
				", CP_DECSTA, AD_VARCODE, AD_VARIANCE, AD_RATENO "+
				"from VW_CUSTPRODUCT a "+
				"where ap_regno='"+ LBL_REGNO.Text +"' and productid='"+
				LBL_PRODID.Text +"' and apptype='"+ LBL_APPTYPE.Text +"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			TXT_APPTYPE.Text		= conn.GetFieldValue("APPTYPEDESC");
			TXT_PRODUCTDESC.Text		= conn.GetFieldValue("PRODUCTDESC");
			TXT_REVOLVING.Text		= conn.GetFieldValue("REVOLVING");
			TXT_AA_NO.Text = conn.GetFieldValue("AA_NO");
			TXT_FACILITYNO.Text = conn.GetFieldValue("ACC_SEQ");
			TXT_CP_NOTES.Text = conn.GetFieldValue("CP_KETERANGAN");
			//TXT_LIMIT.Text		= conn.GetFieldValue("CP_LIMIT");
			//TXT_TENORDESC.Text		= conn.GetFieldValue("NEWVALUE") + " " + conn.GetFieldValue("NEWCODE");
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


		protected void BTN_Save_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec DE_STRUCCREDIT1_AD '"+LBL_REGNO.Text+"', '"+
				LBL_PRODID.Text+"', '"+LBL_APPTYPE.Text+"', null, null, null ,'"+ TXT_CP_NOTES.Text +"', " +
				"null, null,null,null,null, null, null, null, null, '" + TXT_AA_NO.Text.Trim()+
				"', " + TXT_FACILITYNO.Text.Trim() + ",null, null, null, null, null, null, 0, 5, null, null, null, null, null, null, '" + 
				LBL_PROD_SEQ.Text + "'";
			conn.ExecuteNonQuery();
		}
	}
}
