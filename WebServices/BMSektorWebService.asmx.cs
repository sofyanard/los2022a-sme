using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;
using System.Collections;

namespace SME.WebServices
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class BMSektorWebService : System.Web.Services.WebService
    {
        private string connectionString = ConfigurationSettings.AppSettings["conn"];
        private SqlConnection con;
        private SqlCommand cmd;

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public ArrayList QueryDDL1(string par, string val)
        {
            con = new SqlConnection(connectionString);
            cmd = new SqlCommand("SELECT BM_CODE, BM_CODE + ' - ' + BM_DESC AS BMSEKTORDESC FROM RFBMSEKTOREKONOMI WHERE ACTIVE = '1' ORDER BY BM_CODE", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            ArrayList mydata = new ArrayList();
            mydata.Add(new ListItem("- PILIH -", ""));

            while (reader.Read())
            {
                mydata.Add(new ListItem(reader["BMSEKTORDESC"].ToString(), reader["BM_CODE"].ToString()));
            }

            return mydata;
        }

        [WebMethod]
        public ArrayList QueryDDL2(string par, string val)
        {
            con = new SqlConnection(connectionString);
            cmd = new SqlCommand("SELECT BMSUB_CODE, BMSUB_CODE + ' - ' + BMSUB_DESC AS BMSUBSEKTORDESC FROM RFBMSUBSEKTOREKONOMI WHERE ACTIVE = '1' AND BM_CODE = '" + val + "' ORDER BY BMSUB_CODE", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            ArrayList mydata = new ArrayList();
            mydata.Add(new ListItem("- PILIH -", ""));

            while (reader.Read())
            {
                mydata.Add(new ListItem(reader["BMSUBSEKTORDESC"].ToString(), reader["BMSUB_CODE"].ToString()));
            }

            return mydata;
        }

        [WebMethod]
        public ArrayList QueryDDL3(string par, string val)
        {
            con = new SqlConnection(connectionString);
            cmd = new SqlCommand("SELECT BMSUBSUB_CODE, BMSUBSUB_CODE + ' - ' + BMSUBSUB_DESC AS BMSUBSEKTORDESC FROM RFBMSUBSUBSEKTOREKONOMI WHERE ACTIVE = '1' AND BMSUB_CODE = '" + val + "' ORDER BY BMSUBSUB_CODE", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            ArrayList mydata = new ArrayList();
            mydata.Add(new ListItem("- PILIH -", ""));

            while (reader.Read())
            {
                mydata.Add(new ListItem(reader["BMSUBSEKTORDESC"].ToString(), reader["BMSUBSUB_CODE"].ToString()));
            }

            return mydata;
        }

        [WebMethod]
        public ArrayList QueryDDL4(string par, string val)
        {
            con = new SqlConnection(connectionString);
            cmd = new SqlCommand("SELECT BI_SEQ FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + val + "'", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string bi_seq = reader["BI_SEQ"].ToString();
            reader.Close();

            cmd = new SqlCommand("SELECT BI_SEQ, BI_SEQ + ' - ' + BI_DESC AS BI_DESC FROM RFBICODE WHERE BG_GROUP = '3' AND BI_SEQ = '" + bi_seq + "'", con);
            reader = cmd.ExecuteReader();

            ArrayList mydata = new ArrayList();

            while (reader.Read())
            {
                mydata.Add(new ListItem(reader["BI_DESC"].ToString(), reader["BI_SEQ"].ToString()));
            }

            return mydata;
        }
    }
}
