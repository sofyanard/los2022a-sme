using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SME.DTBO
{
    public partial class DocUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DocumentUploadDTBO.WithReadExcel = false;
            DocumentUploadDTBO.GroupTemplate = "DOCUPLOAD";
        }
    }
}