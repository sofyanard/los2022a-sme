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
    public partial class Redirect2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userid = Session["UserID"];
            var pwd = Session["PWD"];
            var url = ConfigurationManager.AppSettings["appCollectionUrl"];
            //Response.Write("<script language='javascript'>window.parent.location = '" + url + "';</script>");
            Response.Write("<script language='javascript'>var win = window.open('" + url + "'); win.focus;</script>");
        }
    }
}