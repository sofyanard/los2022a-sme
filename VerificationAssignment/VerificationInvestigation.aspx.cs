using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.VerificationAssignment
{
    public partial class VerificationInvestigation : System.Web.UI.Page
    {
        protected Connection Conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            Conn = (Connection)Session["Connection"];

            if (!IsPostBack)
            {
                LBL_CUREF.Text = Request.QueryString["curef"];
                LBL_REGNO.Text = Request.QueryString["regno"];

                ViewDataApplication();

                //Hyperlink SubScreenMenu
                HPL_HOUSE.NavigateUrl = "HouseEmployee.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"];
                HPL_OFFICE.NavigateUrl = "OfficeEmployee.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"];
                //HPL_SELF.NavigateUrl = "SelfOffice.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"];
                //HPL_PRO.NavigateUrl = "ProOffice.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"];
                HPL_DOC.NavigateUrl = "DocExport.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"];
            }
            ViewMenu();
        }

        private void ViewMenu()
        {
            try
            {
                Conn.QueryString = "SELECT * FROM SCREENMENU WHERE MENUCODE = '" + Request.QueryString["mc"] + "'";
                Conn.ExecuteQuery();

                for (int i = 0; i < Conn.GetRowCount(); i++)
                {
                    HyperLink t = new HyperLink();
                    t.Text = Conn.GetFieldValue(i, 2);
                    t.Font.Bold = true;
                    string strtemp = "";
                    if (Conn.GetFieldValue(i, 3).Trim() != "")
                    {
                        if (Conn.GetFieldValue(i, 3).IndexOf("mc=") >= 0)
                            strtemp = "regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"] + "&lmsreg=" + Request.QueryString["lmsreg"] + "&scr=" + Request.QueryString["scr"];
                        else strtemp = "regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&mc=" + Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"] + "&lmsreg=" + Request.QueryString["lmsreg"] + "&scr=" + Request.QueryString["scr"];
                            //t.ForeColor = Color.MidnightBlue;
                        if (Conn.GetFieldValue(i, 3).IndexOf("?lkkn=") < 0 && Conn.GetFieldValue(i, 3).IndexOf("&lkkn=") < 0)
                            strtemp = strtemp + "&lkkn=" + Request.QueryString["lkkn"];
                            //strtemp = strtemp + "&de=" + Request.QueryString["de"];
                    }
                    else
                    {
                        strtemp = "";
                        t.ForeColor = Color.Red;
                    }
                    t.NavigateUrl = Conn.GetFieldValue(i, 3) + strtemp;
                    Menu.Controls.Add(t);
                    Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
                }
            }
            catch (Exception ex)
            {
                string temp = ex.ToString();
            }
        }

        private void ViewDataApplication()
        {
            if (!Request.QueryString["regno"].ToString().EndsWith("C"))
            {
                Conn.QueryString = "SELECT * FROM VW_CUST_FOR_SITEVISIT WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
                Conn.ExecuteQuery();
            }
            else
            {
                Conn.QueryString = "SELECT * FROM VW_CUST_FOR_SITEVISIT WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
                Conn.ExecuteQuery();
            }

            TXT_AP_RELMNGR.Text = Conn.GetFieldValue("SU_FULLNAME");
            TXT_BRANCH_CODE.Text = Conn.GetFieldValue("BRANCH_NAME");
            TXT_CU_NAME.Text = Conn.GetFieldValue("CU_NAME");
            TXT_CU_ADDR1.Text = Conn.GetFieldValue("CU_ADDR1");
            TXT_CU_ADDR2.Text = Conn.GetFieldValue("CU_ADDR2");
            TXT_CU_ADDR3.Text = Conn.GetFieldValue("CU_ADDR2");
            TXT_CU_CONTACTPERSON.Text = Conn.GetFieldValue("CU_CONTACTPERSON");
            TXT_GROUP.Text = Conn.GetFieldValue("CU_GROUP");
            TXT_CREDIT_ANALIS.Text = Conn.GetFieldValue("CREDIT_ANALIS");

            if (!Request.QueryString["regno"].ToString().EndsWith("C"))
            {
                Conn.QueryString = "SELECT * FROM APPLICATION WHERE AP_SITEVISITSTA = '1' AND AP_REGNO = '" + Request.QueryString["regno"] + "'";
                Conn.ExecuteQuery();
            }
            else
            {
                Conn.QueryString = "SELECT * FROM APPLICATION WHERE AP_SITEVISITSTA ='1' AND CU_REF = '" + Request.QueryString["curef"] + "'";
                Conn.ExecuteQuery();
            }

            if (Conn.GetRowCount() > 0)
                BTN_UPDATE.Visible = false;
        }

        protected void BTN_UPDATE_Click(object sender, EventArgs e)
        {
            if (!Request.QueryString["regno"].ToString().EndsWith("C"))
            {
                Conn.QueryString = "select * from CUST_SITEVISIT where AP_REGNO = '" + Request.QueryString["regno"] + "'";
                Conn.ExecuteQuery();
            }
            else
            {
                Conn.QueryString = "select * from CUST_SITEVISIT where CU_REF = '" + Request.QueryString["curef"] + "'";
                Conn.ExecuteQuery();
            }

            if (Conn.GetRowCount() > 0)
            {
                Conn.QueryString = "UPDATE APPLICATION SET AP_SITEVISITSTA = '1' WHERE AP_REGNO = '" +
                                   Request.QueryString["regno"] + "'";
                Conn.ExecuteNonQuery();

                // Audit Trail			 
                try
                {
                    Conn.QueryString = "SP_AUDITTRAIL_APP '" +
                                       Request.QueryString["regno"] + "',null,null,null,'" +
                                       Request.QueryString["curef"] + "','" +
                                       Request.QueryString["tc"] + "','Update LKKN ','" +
                                       Session["FullName"].ToString() + "','" +
                                       Session["userid"].ToString() + "',null,null";
                    Conn.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    try
                    {
                        ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path,
                            "AP_REGNO: " + Request.QueryString["regno"]);
                    }
                    catch
                    {
                    }
                }

                BTN_UPDATE.Visible = false;
            }
            else
            {
                GlobalTools.popMessage(this, "Update Status Gagal! Tanggal Site Visit tidak ditemukan");
            }
        }

        protected void BTN_BACK_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Conn));
        }
    }
}