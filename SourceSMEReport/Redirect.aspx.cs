using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.SourceSMEReport
{
    public partial class Redirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userid = Session["UserID"];
            var pwd = Session["PWD"];
            var url = ConfigurationManager.AppSettings["appDashUrl"] +
                "/Auth/LosLogin?username=" + userid + "&hashPassword=" + pwd;
            Response.Write("<script language='javascript'>window.parent.location = '" + url + "';</script>");
        }
    }
}