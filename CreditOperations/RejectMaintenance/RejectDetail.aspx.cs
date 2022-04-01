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
using DMS.CuBESCore;

namespace SME.CreditOperations.RejectMaintenance
{
	/// <summary>
	/// Summary description for RejectDetail.
	/// </summary>
	public partial class RejectDetail : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				TXT_AP_REGNO.Text = Request.QueryString["regno"];
				TXT_CU_REF.Text = Request.QueryString["curef"];
				LBL_TC.Text = Request.QueryString["tc"];

				ViewData();
				bindData();
			}
		}

		private void ViewData()
		{
			conn.QueryString = "select * from VW_INFOUMUM "+
				"where AP_REGNO = '"+ TXT_AP_REGNO.Text.Trim() +"' ";
			conn.ExecuteQuery();
			TXT_AP_REGNO.Text = conn.GetFieldValue("AP_REGNO");
			TXT_CU_REF.Text = conn.GetFieldValue("CU_REF");
			string AP_SIGNDATE = conn.GetFieldValue("AP_SIGNDATE");
			TXT_AP_SIGNDATE.Text = tool.FormatDate(AP_SIGNDATE);
			TXT_PROGRAMDESC.Text = conn.GetFieldValue("PROGRAMDESC");
			TXT_BRANCH_NAME.Text = conn.GetFieldValue("BRANCH_NAME");
			TXT_AP_TMLDRNM.Text = conn.GetFieldValue("AP_TMLDRNM");
			TXT_AP_RMNM.Text = conn.GetFieldValue("AP_RMNM");
			TXT_BU_DESC.Text = conn.GetFieldValue("BU_DESC");
			TXT_CU_NAME.Text = conn.GetFieldValue("CU_NAME");
			TXT_CU_ADDR1.Text = conn.GetFieldValue("CU_ADDR1");
			TXT_CU_ADDR2.Text = conn.GetFieldValue("CU_ADDR2");
			TXT_CU_ADDR3.Text = conn.GetFieldValue("CU_ADDR3");
			TXT_CU_CITYNM.Text = conn.GetFieldValue("CU_CITYNM");
			TXT_CU_PHN.Text = conn.GetFieldValue("CU_PHN");
			TXT_BUSSTYPEDESC.Text = conn.GetFieldValue("BUSSTYPEDESC");
		}

		private void bindData()
		{
			DataTable dt = new DataTable();
			conn.QueryString = "SELECT * FROM VW_CREOPR_REJECTMAINTENANCE_DETAIL WHERE AP_REGNO = '" +
				TXT_AP_REGNO.Text.Trim() + "' and UF_CPSEQ = '" + Request.QueryString["uf_cpseq"] + "' ";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			Datagrid1.DataSource = dt;
			try 
			{
				Datagrid1.DataBind();
			} 
			catch 
			{
				Datagrid1.CurrentPageIndex = 0;
				Datagrid1.DataBind();
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

		protected void BTN_CONFIRM_Click(object sender, System.EventArgs e)
		{
			//////////////////////////////////////////////////////////////
			/// Mengupdate flag Booking = 0 (siap untuk generate)
			/// 
//			conn.QueryString = "UPDATE APPLICATION SET AP_BOOKFLAG = '0' WHERE AP_REGNO = '"+
//				TXT_AP_REGNO.Text.Trim() + "' ";


			string vUSERID = (string) Session["UserID"];
			conn.QueryString = "exec REJECTMAIN_CONFIRM '" + 
				TXT_AP_REGNO.Text + "', '" + 
				Request.QueryString["productid"] + "', '" + 
				Request.QueryString["apptype"] + "', '" + 
				vUSERID + "', '" + 
				Request.QueryString["prod_seq"] + "'";
			conn.ExecuteNonQuery();

            //cek CIF atau BUKAN
            conn.QueryString = "SELECT [FILE] as F FROM AB_ERROR_UPLOAD WHERE AP_REGNO = '" + TXT_AP_REGNO.Text + "'";
            conn.ExecuteQuery();

            if (conn.GetFieldValue("F").Contains("COL"))
            {
                //cek ada prk atau g yang uda berhasil aplot apa g
                conn.QueryString = "SELECT CP.AP_REGNO, CP.APPTYPE, CP.PRODUCTID, CP.PROD_SEQ FROM [APPLICATION] A JOIN CUSTPRODUCT CP ON A.AP_REGNO = CP.AP_REGNO JOIN APPTRACK TR ON CP.AP_REGNO = TR.AP_REGNO AND CP.APPTYPE = TR.APPTYPE AND CP.PRODUCTID = TR.PRODUCTID AND CP.PROD_SEQ = TR.PROD_SEQ JOIN RFPRODUCT RP ON RP.PRODUCTID = CP.PRODUCTID WHERE (ISNULL(CP.CP_REJECT,'0') <> '1' and ISNULL(CP.CP_CANCEL,'0') <> '1') AND CP.APPTYPE = '01' AND TR.AP_CURRTRACK IN ('BP16.0','BP18.0') AND (RP.IS_PRK is null or RP.IS_PRK != '1')  AND (convert(varchar(20),CP.CP_NOTES) != 'LOAN DONE' or CP.CP_NOTES is null) AND A.AP_REGNO = '" + TXT_AP_REGNO.Text + "'";
                conn.ExecuteQuery();

                if (conn.GetRowCount() > 0)
                {
                    UploadingToCore.UploadToCoreClient upload = new UploadingToCore.UploadToCoreClient();
                    upload.CreateUploadFile(Request.QueryString["regno"], "COL", "");
                }
                else
                {
                    UploadingToCore.UploadToCoreClient upload = new UploadingToCore.UploadToCoreClient();
                    upload.CreateUploadFile(Request.QueryString["regno"], "COL", "PRK");
                }
            }
            else
            {
                conn.QueryString = "SELECT CP.AP_REGNO, CP.APPTYPE, CP.PRODUCTID, CP.PROD_SEQ FROM [APPLICATION] A JOIN CUSTPRODUCT CP ON A.AP_REGNO = CP.AP_REGNO JOIN APPTRACK TR ON CP.AP_REGNO = TR.AP_REGNO AND CP.APPTYPE = TR.APPTYPE AND CP.PRODUCTID = TR.PRODUCTID AND CP.PROD_SEQ = TR.PROD_SEQ JOIN RFPRODUCT RP ON RP.PRODUCTID = CP.PRODUCTID WHERE (ISNULL(CP.CP_REJECT,'0') <> '1' and ISNULL(CP.CP_CANCEL,'0') <> '1') AND CP.APPTYPE = '01' AND TR.AP_CURRTRACK IN ('BP16.0','BP18.0') AND (RP.IS_PRK is null or RP.IS_PRK != '1') AND (convert(varchar(20),CP.CP_NOTES) != 'LOAN DONE' or CP.CP_NOTES is null) AND A.AP_REGNO = '" + TXT_AP_REGNO.Text + "'";
                conn.ExecuteQuery();

                if (conn.GetRowCount() > 0)
                {
                    UploadingToCore.UploadToCoreClient upload = new UploadingToCore.UploadToCoreClient();
                    upload.CreateUploadFile(Request.QueryString["regno"], "CIF", "");
                }
                else
                {
                    UploadingToCore.UploadToCoreClient upload = new UploadingToCore.UploadToCoreClient();
                    upload.CreateUploadFile(Request.QueryString["regno"], "CIF", "PRK");
                }
            }
		}

		protected void BTN_UNCONFIRM_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "UPDATE APPLICATION SET AP_BOOKFLAG = '3' WHERE AP_REGNO = '"+
				TXT_AP_REGNO.Text.Trim() + "' ";
			conn.ExecuteNonQuery();
		}
	}
}
