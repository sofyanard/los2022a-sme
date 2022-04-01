using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.Facilities
{
    public partial class ViewUploadedFiles : System.Web.UI.Page
    {
        protected Connection conn;
        protected Tools tool = new Tools();

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = (Connection)Session["Connection"];

            if (!IsPostBack)
            {

            }
        }

		private void ViewUploadFiles()
		{
			System.Data.DataTable dt = new System.Data.DataTable();

			conn.QueryString = "select distinct * from VW_CUSTOMER_FILEUPLOAD_LIST where 1=1 ";

			if (TXT_APPNO.Text.Trim() != "")
			{
				conn.QueryString += "and AP_REGNO = '" + TXT_APPNO.Text + "' ";
			}

			if (TXT_CIFNO.Text.Trim() != "")
			{
				conn.QueryString += "and CU_CIF = '" + TXT_CIFNO.Text + "' ";
			}

			if (TXT_IDNO.Text.Trim() != "")
			{
				conn.QueryString += "and CU_IDCARDNUM = '" + TXT_IDNO.Text + "' ";
			}

			if (TXT_CU_NAME.Text.Trim() != "")
            {
				conn.QueryString += "and CU_NAME like '%" + TXT_CU_NAME.Text + "%' ";
			}

			conn.ExecuteQuery();

			dt = conn.GetDataTable().Copy();
			DG_UPFILES.DataSource = dt;
			try
			{
				DG_UPFILES.DataBind();
			}
			catch
			{
				DG_UPFILES.CurrentPageIndex = 0;
				DG_UPFILES.DataBind();
			}
			for (int i = 1; i <= DG_UPFILES.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink)DG_UPFILES.Items[i - 1].Cells[6].FindControl("FU_DOWNLOAD");
				HpDownload.NavigateUrl = DG_UPFILES.Items[i - 1].Cells[5].Text.Trim();
			}
		}

        protected void BTN_SEARCH_Click(object sender, EventArgs e)
        {
			ViewUploadFiles();
		}

        protected void BTN_CLEAR_Click(object sender, EventArgs e)
        {
			TXT_APPNO.Text = "";
			TXT_CIFNO.Text = "";
			TXT_IDNO.Text = "";
			TXT_CU_NAME.Text = "";

			DG_UPFILES.DataSource = null;
			try
			{
				DG_UPFILES.CurrentPageIndex = 0;
				DG_UPFILES.DataBind();
			}
			catch
			{
				DG_UPFILES.CurrentPageIndex = 0;
				DG_UPFILES.DataBind();
			}
		}

        protected void DG_UPFILES_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
			DG_UPFILES.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFiles();
		}
    }
}