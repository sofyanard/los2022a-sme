using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.VerificationAssignment
{
    public partial class SiteVisitAssignment : System.Web.UI.Page
    {
        protected Connection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = (Connection)Session["Connection"];

            if (!IsPostBack)
            {
                Ddl_City.Items.Add(new ListItem("- SELECT -", ""));

                conn.QueryString = "select CITYID, CITYNAME from RFCITY where ACTIVE = '1'";
                conn.ExecuteQuery();
                for (int j = 0; j < conn.GetRowCount(); j++)
                    Ddl_City.Items.Add(new ListItem(conn.GetFieldValue(j, 1), conn.GetFieldValue(j, 0)));

                ViewData();
            }
        }

        private void ViewData()
        {
            conn.QueryString = "select * from SITEVISITASSIGNMENT a " +
                "join RFSITEVISITASSIGNMENTSTATUS b on a.VISIT_STATUS = b.VISITASSIGNSTATUSID " +
                "where AP_REGNO = '" + Request.QueryString["regno"] + "'";
            conn.ExecuteQuery();

            if (conn.GetRowCount() > 0)
            {
                string visitStatus = conn.GetFieldValue("VISIT_STATUS");

                if (visitStatus == "1") // assign to surveyor
                {
                    Lbl_Status.Text = conn.GetFieldValue("VISITASSIGNSTATUSDESC");


                }
                else if (visitStatus == "2") // visited by surveyor
                {
                    Lbl_Status.Text = conn.GetFieldValue("VISITASSIGNSTATUSDESC");


                }
                else if (visitStatus == "3") // finish
                {
                    Lbl_Status.Text = conn.GetFieldValue("VISITASSIGNSTATUSDESC");


                }

                string cityId = conn.GetFieldValue("CITYID");
                string agencyId = conn.GetFieldValue("AGENCYID");
                string officerId = conn.GetFieldValue("OFFICERID");

                try { Ddl_City.SelectedValue = cityId; }
                catch { }

                FillDdlAgency(cityId);

                try { Ddl_Agency.SelectedValue = agencyId; }
                catch { }

                FillDdlOfficer(agencyId);

                try { Ddl_Officer.SelectedValue = officerId; }
                catch { }
            }
            else // belum pernah di-assign
            {
                Lbl_Status.Text = "Not Assign";
                Ddl_City.Enabled = true;
                Ddl_Agency.Enabled = true;
                Ddl_Officer.Enabled = true;
            }
        }

        private void FillDdlAgency(string cityId)
        {
            Ddl_Agency.Items.Clear();
            Ddl_Agency.Items.Add(new ListItem("- SELECT -", ""));

            conn.QueryString = "select AGENCYID, AGENCYNAME from RFAGENCY where AGENCYTYPEID = '04' and ACTIVE = '1' and CITYID = '" + cityId + "'";
            conn.ExecuteQuery();
            for (int j = 0; j < conn.GetRowCount(); j++)
                Ddl_Agency.Items.Add(new ListItem(conn.GetFieldValue(j, 1), conn.GetFieldValue(j, 0)));

            Ddl_Officer.Items.Clear();
        }

        private void FillDdlOfficer(string agencyId)
        {
            Ddl_Officer.Items.Clear();
            Ddl_Officer.Items.Add(new ListItem("- SELECT -", ""));

            conn.QueryString = "select AGOFR_CODE, AGOFR_DESC from RFAGENCYOFR where AGENCYID = '" + agencyId + "'";
            conn.ExecuteQuery();
            for (int j = 0; j < conn.GetRowCount(); j++)
                Ddl_Officer.Items.Add(new ListItem(conn.GetFieldValue(j, 1), conn.GetFieldValue(j, 0)));
        }

        protected void Ddl_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDdlAgency(Ddl_City.SelectedValue);
        }

        protected void Ddl_Agency_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDdlOfficer(Ddl_Agency.SelectedValue);
        }

        protected void Btn_Assign_Click(object sender, EventArgs e)
        {
            if ((Ddl_City.SelectedValue.Trim() == "") || (Ddl_Agency.SelectedValue.Trim() == "") || (Ddl_Officer.SelectedValue.Trim() == ""))
            {
                GlobalTools.popMessage(this, "Data Assignment Harus Diisi Lengkap !");
                return;
            }

            conn.QueryString = "select * from SITEVISITASSIGNMENT where AP_REGNO = '" + Request.QueryString["regno"] + "'";
            conn.ExecuteQuery();

            if (conn.GetRowCount() > 0)
            {
                try
                {
                    conn.QueryString = "UPDATE SITEVISITASSIGNMENT set " +
                        "CITYID = '" + Ddl_City.SelectedValue + "', " +
                        "AGENCYID = '" + Ddl_Agency.SelectedValue + "', " +
                        "OFFICERID = '" + Ddl_Officer.SelectedValue + "', " +
                        "ASSIGN_BY = '" + Session["UserID"].ToString() + "', " +
                        "ASSIGN_DATE = '" + DateTime.Now + "', " +
                        "VISIT_STATUS = '1' " +
                        "where AP_REGNO = '" + Request.QueryString["regno"] + "'";
                    conn.ExecuteNonQuery();

                    ViewData();
                }
                catch (Exception ex)
                {
                    GlobalTools.popMessage(this, ex.Message);
                    return;
                }
            }
            else
            {
                try
                {
                    conn.QueryString = "INSERT INTO SITEVISITASSIGNMENT " +
                        "(AP_REGNO, CITYID, AGENCYID, OFFICERID, ASSIGN_BY, ASSIGN_DATE, VISIT_STATUS) VALUES " +
                        "('" + Request.QueryString["regno"] + "', " +
                        "'" + Ddl_City.SelectedValue + "', " +
                        "'" + Ddl_Agency.SelectedValue + "', " +
                        "'" + Ddl_Officer.SelectedValue + "', " +
                        "'" + Session["UserID"].ToString() + "', " +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + "', '1')";
                    conn.ExecuteNonQuery();

                    ViewData();
                }
                catch (Exception ex)
                {
                    GlobalTools.popMessage(this, ex.Message);
                    return;
                }
            }
        }
    }
}