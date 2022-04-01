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

namespace SME.CreditOperations.RejectMaintenance
{
	/// <summary>
	/// Summary description for DataJaminan.
	/// </summary>
	public partial class DataJaminan : System.Web.UI.Page
	{
        protected Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            conn = (Connection)Session["Connection"];
            viewAllKetentuanKredit();
		}

        void viewAllKetentuanKredit()
        {
            conn.QueryString = "SELECT * FROM [VW_CREOPR_REJECTMAINTENANCE_LIST_KETKREDIT] WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
            conn.ExecuteQuery();

            DataGrid1.DataSource = conn.GetDataTable().Copy();
            try
            {
                DataGrid1.DataBind();
            }
            catch
            {
                DataGrid1.CurrentPageIndex = 0;
                DataGrid1.DataBind();
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

        private void ViewList(string regno, string apptype, string cpproductid, string prodseq, string curef)
        {
            string autoLoadScript = "<script language='javascript'>" +
                "document.getElementById('scol').src='Jaminan_List.aspx?regno=" +
                regno + "&curef=" + curef +
                "&apptype=" + apptype + "&productid=" +
                cpproductid + "&prod_seq=" + prodseq +
                "&de=" + Request.QueryString["de"] +
                //uf_cpseq ??
                "&uf_cpseq=" + Request.QueryString["uf_cpseq"] +
                "&mc=" + Request.QueryString["mc"] + "';</script>";
            Page.RegisterStartupScript("LoadScript ", autoLoadScript);
        }

        protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (((LinkButton)e.CommandSource).CommandName)
            {
                case "view":

                    string KET_CODE = e.Item.Cells[4].Text.Trim();
                    string apptype = e.Item.Cells[2].Text.Trim();
                    string cpproductid = e.Item.Cells[3].Text.Trim();
                    string prodseq = e.Item.Cells[13].Text.Trim();
                    string regno = e.Item.Cells[0].Text.Trim();
                    string curef = e.Item.Cells[1].Text.Trim();

                    ViewList(regno, apptype, cpproductid, prodseq, curef);
                    break;
            }
        }
	}
}
