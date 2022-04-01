using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace SME.CommonForm
{
    /// <summary>
    /// Summary description for DocumentUpload2Handler
    /// </summary>
    public class DocumentUpload2Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            context.Response.Write(context.Request.QueryString["fname"]);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}