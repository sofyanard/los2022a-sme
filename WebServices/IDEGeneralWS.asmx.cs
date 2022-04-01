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
    public class IDEGeneralWS : System.Web.Services.WebService
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
        public ArrayList QueryZipCode(string par, string val)
        {
            con = new SqlConnection(connectionString);
            cmd = new SqlCommand("SELECT CITYID, CITYNAME, DESCRIPTION FROM VW_ZIPCODECITY WHERE rtrim(ltrim(ZIPCODE)) = '" + val + "'", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            ArrayList mydata = new ArrayList();

            while (reader.Read())
            {
                mydata.Add(new ListItem("CityID", reader["CITYID"].ToString()));
                mydata.Add(new ListItem("CityName", reader["CITYNAME"].ToString()));
                mydata.Add(new ListItem("Description", reader["DESCRIPTION"].ToString()));
            }

            return mydata;
        }
    }
}
