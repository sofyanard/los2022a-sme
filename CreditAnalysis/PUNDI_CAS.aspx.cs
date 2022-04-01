using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DMS.DBConnection;
using System.Data;

namespace SME.CreditAnalysis
{
    public partial class PUNDI_CAS : System.Web.UI.Page
    {
        protected Connection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = (Connection)Session["Connection"];

            ViewAllData();

            DocumentUpload1.WithReadExcel = true;
            DocumentUpload1.GroupTemplate = "PUNDI_CAS";

            Retrieve.Click += new EventHandler(Retrieve_Click);
        }

        void Retrieve_Click(object sender, EventArgs e)
        {
            ViewAllData();
        }

        protected void ViewAllData()
        {
            //Grid CAS
            conn.QueryString = "SELECT * FROM PUNDI_CAS WHERE SEQ not in (SELECT MAX(SEQ) as SEQ FROM PUNDI_CAS WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND " +
                "CU_REF = '" + Request.QueryString["curef"] + "') AND AP_REGNO = '" + Request.QueryString["regno"] + "' AND CU_REF = '" + Request.QueryString["curef"] + "'";
            conn.ExecuteQuery();

            DatGrd.DataSource = conn.GetDataTable().Copy();
            DatGrd.DataBind();

            //DGSummary
            conn.QueryString = "SELECT * FROM PUNDI_CAS WHERE SEQ in (SELECT MAX(SEQ) as SEQ FROM PUNDI_CAS WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND " +
                "CU_REF = '" + Request.QueryString["curef"] + "') AND AP_REGNO = '" + Request.QueryString["regno"] + "' AND CU_REF = '" + Request.QueryString["curef"] + "'";
            conn.ExecuteQuery();
            DGSummary.DataSource = conn.GetDataTable().Copy();
            DGSummary.DataBind();

            /*try
            {
                DatGrd.DataBind();
            }
            catch
            {
                DatGrd.CurrentPageIndex = 0;
                DatGrd.DataBind();
            }*/

            //Grid UPLOADED FILE
        }

        protected void DatGrd_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (((LinkButton)e.CommandSource).CommandName)
            {
                case "Delete":
                    conn.QueryString = "DELETE PUNDI_CAS WHERE AP_REGNO = '" + e.Item.Cells[10].Text + "' AND CU_REF = '" + e.Item.Cells[11].Text + "' AND SEQ = '" + e.Item.Cells[9].Text + "'";
                    conn.ExecuteQuery();
                    ViewAllData();
                    break;
            }
        }
    }
}