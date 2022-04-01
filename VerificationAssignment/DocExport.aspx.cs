using System;
using DMS.DBConnection;

namespace SME.VerificationAssignment
{
    public partial class DocExport : System.Web.UI.Page
    {
        protected Connection Conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            Conn = (Connection)Session["Connection"];

            if (!IsPostBack)
            {
                DocExport1.GroupTemplate = "SVPRINT";
                DocUpload1.GroupTemplate = "SVUPLOAD";
                DocUpload1.WithReadExcel = false;
            }
        }
    }
}