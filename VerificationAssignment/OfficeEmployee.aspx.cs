using System;
using System.Web;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.VerificationAssignment
{
    public partial class OfficeEmployee : System.Web.UI.Page
    {
        protected Connection Conn;
        protected Tools Tool = new Tools();
        Paramater _param = new Paramater();

        protected void Page_Load(object sender, EventArgs e)
        {
            Conn = (Connection)Session["Connection"];

            if (!IsPostBack)
            {
                FillDdl();
                ViewDataApplication();
            }
        }

        private void FillDdl()
        {
            //Fill DropDownList Month
            _param.FillDropDownBulan(DDL_INVESTIGASI_MONTH);

            //Fill DropDownList Parameter
            _param.FillDropDownParam(DDL_POSISI_PEMBERI_KET1, "SELECT JOBTITLEID, JOBTITLEDESC FROM RFJOBTITLE WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_POSISI_PEMBERI_KET2, "SELECT JOBTITLEID, JOBTITLEDESC FROM RFJOBTITLE WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_OFFICE, "SELECT COMPTYPEID, COMPTYPEDESC FROM RFCOMPTYPE WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_USAHA_OFFICE, "SELECT BUSSTYPEID, BUSSTYPEDESC FROM RFBUSINESSTYPE WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_BANGUNAN_OFFICE, "SELECT BANGUNANID, BANGUNANDESC FROM RFJENISBANGUNAN WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_LOKASI_OFFICE, "SELECT LOKASIID, LOKASIDESC FROM RF_APPR_LOKASIBANGUNAN WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_KONDISI_OFFICE, "SELECT GUNAID, GUNADESC FROM RF_APPR_PENGGUNAANBANGUNAN WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_OWNER_OFFICE, "SELECT HM_CODE, HM_DESC FROM RFHOMESTA WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_NM_OFFICE_PLUS, "SELECT COMPTYPEID, COMPTYPEDESC FROM RFCOMPTYPE WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_POSISI_PEMOHON_PLUS, "SELECT JOBTITLEID, JOBTITLEDESC FROM RFJOBTITLE WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_NAME_WORK, "SELECT JOBTITLEID, JOBTITLEDESC FROM RFJOBTITLE WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_POSISI_WORK, "SELECT JOBTITLEID, JOBTITLEDESC FROM RFJOBTITLE WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_STATUS_WORK, "SELECT UMURID, UMURDESC FROM RF_APPR_UMUR WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_KINERJA_WORK, "SELECT RATEID, RATEDESC FROM RFRATING WHERE ACTIVE = '1'");
        }

        private void ViewDataApplication()
        {
            if (!Request.QueryString["regno"].ToString().EndsWith("C"))
            {
                Conn.QueryString = "SELECT * FROM CUST_SITEVISIT WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
                Conn.ExecuteQuery();
            }
            else
            {
                Conn.QueryString = "SELECT * FROM CUST_SITEVISIT WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
                Conn.ExecuteQuery();
            }

            //if (Conn.GetRowCount() > 0)
            //    BTN_PRINT.Enabled = true;

            #region Load Existing Data
            //Existing Data Kantor
            TXT_INVESTIGASI_DAY.Text = Tool.FormatDate_Day(Conn.GetFieldValue("SV_OFC_INVESTIGASI_DATE"));
            DDL_INVESTIGASI_MONTH.SelectedValue = Tool.FormatDate_Month(Conn.GetFieldValue("SV_OFC_INVESTIGASI_DATE"));
            TXT_INVESTIGASI_YEAR.Text = Tool.FormatDate_Year(Conn.GetFieldValue("SV_OFC_INVESTIGASI_DATE"));
            TXT_PEMBERI_KET1.Text = Conn.GetFieldValue("SV_OFC_PEMBERI_KET1").Replace("&nbsp;", "");
            DDL_POSISI_PEMBERI_KET1.SelectedValue = Conn.GetFieldValue("SV_OFC_POSISI_PEMBERI_KET1");
            TXT_PEMBERI_KET2.Text = Conn.GetFieldValue("SV_OFC_PEMBERI_KET2").Replace("&nbsp;", "");
            DDL_POSISI_PEMBERI_KET2.SelectedValue = Conn.GetFieldValue("SV_OFC_POSISI_PEMBERI_KET2");
            DDL_OFFICE.SelectedValue = Conn.GetFieldValue("SV_OFC_TYP_OFFICE");
            TXT_NM_OFFICE.Text = Conn.GetFieldValue("SV_OFC_NM_OFFICE").Replace("&nbsp;", "");
            TXT_ADDR_OFFICE1.Text = Conn.GetFieldValue("SV_OFC_ADDR_OFFICE1").Replace("&nbsp;", "");
            TXT_ADDR_OFFICE2.Text = Conn.GetFieldValue("SV_OFC_ADDR_OFFICE2").Replace("&nbsp;", "");
            TXT_ADDR_OFFICE3.Text = Conn.GetFieldValue("SV_OFC_ADDR_OFFICE3").Replace("&nbsp;", "");
            TXT_ZIPCODE_OFFICE.Text = Conn.GetFieldValue("SV_OFC_ZIPCODE_OFFICE").Replace("&nbsp;", "");
            LBL_CITY_OFFICE.Text = Conn.GetFieldValue("SV_OFC_CITY_CODE_OFFICE").Replace("&nbsp;", "");
            TXT_CITY_OFFICE.Text = Conn.GetFieldValue("SV_OFC_CITY_OFFICE").Replace("&nbsp;", "");
            TXT_N0_TLP_AREA_OFFICE.Text = Conn.GetFieldValue("SV_OFC_N0_TLP_AREA_OFFICE").Replace("&nbsp;", "");
            TXT_N0_TLP_OFFICE.Text = Conn.GetFieldValue("SV_OFC_N0_TLP_OFFICE").Replace("&nbsp;", "");
            TXT_EXT_OFFICE.Text = Conn.GetFieldValue("SV_OFC_EXT_OFFICE").Replace("&nbsp;", "");
            TXT_N0_FAX_AREA_OFFICE.Text = Conn.GetFieldValue("SV_OFC_N0_FAX_AREA_OFFICE").Replace("&nbsp;", "");
            TXT_N0_FAX_OFFICE.Text = Conn.GetFieldValue("SV_OFC_N0_FAX_OFFICE").Replace("&nbsp;", "");
            TXT_YEAR_OFFICE.Text = Conn.GetFieldValue("SV_OFC_YEAR_OFFICE").Replace("&nbsp;", "");
            DDL_USAHA_OFFICE.SelectedValue = Conn.GetFieldValue("SV_OFC_USAHA_OFFICE");
            TXT_STAF_OFFICE.Text = (Conn.GetFieldValue("SV_OFC_STAF_OFFICE").Replace("&nbsp;", "")).Replace(".", "'").Replace(",", ".").Replace("'", ",");
            TXT_SCALE_OFFICE.Text = Conn.GetFieldValue("SV_OFC_SCALE_OFFICE").Replace("&nbsp;", "");
            DDL_BANGUNAN_OFFICE.SelectedValue = Conn.GetFieldValue("SV_OFC_BANGUNAN_OFFICE");
            DDL_LOKASI_OFFICE.SelectedValue = Conn.GetFieldValue("SV_OFC_LOKASI_OFFICE");
            DDL_KONDISI_OFFICE.SelectedValue = Conn.GetFieldValue("SV_OFC_KONDISI_OFFICE");
            DDL_OWNER_OFFICE.SelectedValue = Conn.GetFieldValue("SV_OFC_OWNER_OFFICE");

            //Existing Data Kantor Tambahan
            DDL_NM_OFFICE_PLUS.SelectedValue = Conn.GetFieldValue("SV_OFC_TYP_OFFICE_PLUS");
            TXT_NM_OFFICE_PLUS.Text = Conn.GetFieldValue("SV_OFC_NM_OFFICE_PLUS").Replace("&nbsp;", "");
            DDL_POSISI_PEMOHON_PLUS.SelectedValue = Conn.GetFieldValue("SV_OFC_POSISI_PEMOHON_PLUS");
            TXT_NO_TLP_AREA_PLUS.Text = Conn.GetFieldValue("SV_OFC_NO_TLP_AREA_PLUS").Replace("&nbsp;", "");
            TXT_NO_TLP_PLUS.Text = Conn.GetFieldValue("SV_OFC_NO_TLP_PLUS").Replace("&nbsp;", "");
            TXT_NO_FAX_AREA_PLUS.Text = Conn.GetFieldValue("SV_OFC_NO_FAX_AREA_PLUS").Replace("&nbsp;", "");
            TXT_NO_FAX_PLUS.Text = Conn.GetFieldValue("SV_OFC_NO_FAX_PLUS").Replace("&nbsp;", "");
            TXT_ADDR_PLUS1.Text = Conn.GetFieldValue("SV_OFC_ADDR_PLUS1").Replace("&nbsp;", "");
            TXT_ADDR_PLUS2.Text = Conn.GetFieldValue("SV_OFC_ADDR_PLUS2").Replace("&nbsp;", "");
            TXT_ADDR_PLUS3.Text = Conn.GetFieldValue("SV_OFC_ADDR_PLUS3").Replace("&nbsp;", "");
            TXT_ZIPCODE_PLUS.Text = Conn.GetFieldValue("SV_OFC_ZIPCODE_PLUS").Replace("&nbsp;", "");
            LBL_CITY_PLUS.Text = Conn.GetFieldValue("SV_OFC_CITY_CODE_PLUS").Replace("&nbsp;", "");
            TXT_CITY_PLUS.Text = Conn.GetFieldValue("SV_OFC_CITY_PLUS").Replace("&nbsp;", "");

            //Existing Data Pekerjaaan & Perusahaan Sebelumnya
            DDL_NAME_WORK.SelectedValue = Conn.GetFieldValue("SV_OFC_NAME_WORK");
            DDL_POSISI_WORK.SelectedValue = Conn.GetFieldValue("SV_OFC_POSISI_WORK");
            TXT_YEAR_WORK.Text = Conn.GetFieldValue("SV_OFC_YEAR_WORK").Replace("&nbsp;", "");
            TXT_MONTH_WORK.Text = Conn.GetFieldValue("SV_OFC_MONTH_WORK").Replace("&nbsp;", "");
            DDL_STATUS_WORK.SelectedValue = Conn.GetFieldValue("SV_OFC_STATUS_WORK");
            TXT_UNIT_WORK.Text = Conn.GetFieldValue("SV_OFC_UNIT_WORK").Replace("&nbsp;", "");
            DDL_KINERJA_WORK.SelectedValue = Conn.GetFieldValue("SV_OFC_KINERJA_WORK");
            TXT_OFFICE_NM_HISTORY.Text = Conn.GetFieldValue("SV_OFC_OFFICE_NM_HISTORY").Replace("&nbsp;", "");
            TXT_NO_TLP_AREA_HISTORY.Text = Conn.GetFieldValue("SV_OFC_NO_TLP_AREA_HISTORY").Replace("&nbsp;", "");
            TXT_NO_TLP_HISTORY.Text = Conn.GetFieldValue("SV_OFC_NO_TLP_HISTORY").Replace("&nbsp;", "");
            TXT_OFFICE_YEAR_HISTORY.Text = Conn.GetFieldValue("SV_OFC_OFFICE_YEAR_HISTORY").Replace("&nbsp;", "");
            TXT_OFFICE_MONTH_HISTORY.Text = Conn.GetFieldValue("SV_OFC_OFFICE_MONTH_HISTORY").Replace("&nbsp;", "");

            //Existing Data Keuangan Customer
            TXT_INCOME_BRUTO_PEMOHON.Text = (Conn.GetFieldValue("SV_OFC_INCOME_BRUTO_PEMOHON").Replace("&nbsp;", "")).Replace(".", "'").Replace(",", ".").Replace("'", ",");
            TXT_INCOME_NETTO_PEMOHON.Text = (Conn.GetFieldValue("SV_OFC_INCOME_NETTO_PEMOHON").Replace("&nbsp;", "")).Replace(".", "'").Replace(",", ".").Replace("'", ",");
            TXT_OTHER_INCOME_PEMOHON.Text = (Conn.GetFieldValue("SV_OFC_OTHER_INCOME_PEMOHON").Replace("&nbsp;", "")).Replace(".", "'").Replace(",", ".").Replace("'", ",");
            TXT_TOTAL_INCOME_PEMOHON.Text = (Conn.GetFieldValue("SV_OFC_TOTAL_INCOME_PEMOHON").Replace("&nbsp;", "")).Replace(".", "'").Replace(",", ".").Replace("'", ",");
            TXT_PAY_PEMOHON.Text = (Conn.GetFieldValue("SV_OFC_PAY_PEMOHON").Replace("&nbsp;", "")).Replace(".", "'").Replace(",", ".").Replace("'", ",");
            TXT_INCOME_BRUTO_SPOUSE.Text = (Conn.GetFieldValue("SV_OFC_INCOME_BRUTO_SPOUSE").Replace("&nbsp;", "")).Replace(".", "'").Replace(",", ".").Replace("'", ",");
            TXT_INCOME_NETTO_SPOUSE.Text = (Conn.GetFieldValue("SV_OFC_INCOME_NETTO_SPOUSE").Replace("&nbsp;", "")).Replace(".", "'").Replace(",", ".").Replace("'", ",");
            TXT_OTHER_INCOME_SPOUSE.Text = (Conn.GetFieldValue("SV_OFC_OTHER_INCOME_SPOUSE").Replace("&nbsp;", "")).Replace(".", "'").Replace(",", ".").Replace("'", ",");
            TXT_TOTAL_INCOME_SPOUSE.Text = (Conn.GetFieldValue("SV_OFC_TOTAL_INCOME_SPOUSE").Replace("&nbsp;", "")).Replace(".", "'").Replace(",", ".").Replace("'", ",");
            TXT_PAY_SPOUSE.Text = (Conn.GetFieldValue("SV_OFC_PAY_SPOUSE").Replace("&nbsp;", "")).Replace(".", "'").Replace(",", ".").Replace("'", ",");
            TXT_INCOME_MARGIN.Text = (Conn.GetFieldValue("SV_OFC_INCOME_MARGIN").Replace("&nbsp;", "")).Replace(".", "'").Replace(",", ".").Replace("'", ",");

            //Existing Data Summary
            TXT_PEMOHON_SUMMARY.Text = Conn.GetFieldValue("SV_OFC_PEMOHON_SUMMARY").Replace("&nbsp;", "");
            TXT_OTHER_SUMMARY.Text = Conn.GetFieldValue("SV_OFC_OTHER_SUMMARY").Replace("&nbsp;", "");
            #endregion
        }

        #region Search ZIP Code
        protected void BTN_SEARCHZIP_OFFICE_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_ZIPCODE_OFFICE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
        }

        protected void BTN_SEARCHZIP_PLUS_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_ZIPCODE_PLUS','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
        }

        protected void TXT_ZIPCODE_OFFICE_TextChanged(object sender, EventArgs e)
        {
            Conn.QueryString = "SELECT CITYID, CITYNAME, [DESCRIPTION] FROM VW_ZIPCODECITY WHERE RTRIM(LTRIM(ZIPCODE)) = '" +
                                TXT_ZIPCODE_OFFICE.Text.Trim() + "' ";
            Conn.ExecuteQuery();
            try
            {
                LBL_CITY_OFFICE.Text = Conn.GetFieldValue(0, 0);
                TXT_CITY_OFFICE.Text = Conn.GetFieldValue(0, 1);
                TXT_ADDR_OFFICE3.Text = Conn.GetFieldValue(0, 2);
            }
            catch
            {
                TXT_ZIPCODE_OFFICE.Text = "";
                TXT_CITY_OFFICE.Text = "";
                GlobalTools.popMessage(this, "Invalid Zipcode!");
            }
        }

        protected void TXT_ZIPCODE_PLUS_TextChanged(object sender, EventArgs e)
        {
            Conn.QueryString = "SELECT CITYID, CITYNAME, [DESCRIPTION] FROM VW_ZIPCODECITY WHERE RTRIM(LTRIM(ZIPCODE)) = '" +
                                TXT_ZIPCODE_PLUS.Text.Trim() + "' ";
            Conn.ExecuteQuery();
            try
            {
                LBL_CITY_PLUS.Text = Conn.GetFieldValue(0, 0);
                TXT_CITY_PLUS.Text = Conn.GetFieldValue(0, 1);
                TXT_ADDR_PLUS3.Text = Conn.GetFieldValue(0, 2);
            }
            catch
            {
                TXT_ZIPCODE_PLUS.Text = "";
                TXT_CITY_PLUS.Text = "";
                GlobalTools.popMessage(this, "Invalid Zipcode!");
            }
        }
        #endregion

        #region Clear Data Field
        protected void BTN_CLR_OFFICE_Click(object sender, EventArgs e)
        {
            ClearData("1");
        }

        protected void BTN_CLR_OFFICE_PLUS_Click(object sender, EventArgs e)
        {
            ClearData("2");
        }

        protected void BTN_CLR_OFFICE_WORK_Click(object sender, EventArgs e)
        {
            ClearData("3");
        }

        protected void BTN_CLR_OFFICE_FINANCE_Click(object sender, EventArgs e)
        {
            ClearData("4");
        }

        protected void BTN_CLR_OFFICE_SUMMARY_Click(object sender, EventArgs e)
        {
            ClearData("5");
        }

        private void ClearData(string type)
        {
            switch (type)
            {
                case "1":
                    TXT_INVESTIGASI_DAY.Text = "";
                    DDL_INVESTIGASI_MONTH.SelectedValue = "";
                    TXT_INVESTIGASI_YEAR.Text = "";
                    TXT_PEMBERI_KET1.Text = "";
                    DDL_POSISI_PEMBERI_KET1.SelectedValue = "";
                    TXT_PEMBERI_KET2.Text = "";
                    DDL_POSISI_PEMBERI_KET2.SelectedValue = "";
                    DDL_OFFICE.SelectedValue = "";
                    TXT_NM_OFFICE.Text = "";
                    TXT_ADDR_OFFICE1.Text = "";
                    TXT_ADDR_OFFICE2.Text = "";
                    TXT_ADDR_OFFICE3.Text = "";
                    TXT_ZIPCODE_OFFICE.Text = "";
                    LBL_CITY_OFFICE.Text = "";
                    TXT_CITY_OFFICE.Text = "";
                    TXT_N0_TLP_AREA_OFFICE.Text = "";
                    TXT_N0_TLP_OFFICE.Text = "";
                    TXT_EXT_OFFICE.Text = "";
                    TXT_N0_FAX_AREA_OFFICE.Text = "";
                    TXT_N0_FAX_OFFICE.Text = "";
                    TXT_YEAR_OFFICE.Text = "";
                    DDL_USAHA_OFFICE.SelectedValue = "";
                    TXT_STAF_OFFICE.Text = "";
                    TXT_SCALE_OFFICE.Text = "";
                    DDL_BANGUNAN_OFFICE.SelectedValue = "";
                    DDL_LOKASI_OFFICE.SelectedValue = "";
                    DDL_KONDISI_OFFICE.SelectedValue = "";
                    DDL_OWNER_OFFICE.SelectedValue = "";
                    LBL_STS_OFFICE.Text = "";
                    break;

                case "2":
                    DDL_NM_OFFICE_PLUS.SelectedValue = "";
                    TXT_NM_OFFICE_PLUS.Text = "";
                    DDL_POSISI_PEMOHON_PLUS.SelectedValue = "";
                    TXT_NO_TLP_AREA_PLUS.Text = "";
                    TXT_NO_TLP_PLUS.Text = "";
                    TXT_NO_FAX_AREA_PLUS.Text = "";
                    TXT_NO_FAX_PLUS.Text = "";
                    TXT_ADDR_PLUS1.Text = "";
                    TXT_ADDR_PLUS2.Text = "";
                    TXT_ADDR_PLUS3.Text = "";
                    TXT_ZIPCODE_PLUS.Text = "";
                    LBL_CITY_PLUS.Text = "";
                    TXT_CITY_PLUS.Text = "";
                    LBL_STS_OFFICE_PLUS.Text = "";
                    break;

                case "3":
                    DDL_NAME_WORK.SelectedValue = "";
                    DDL_POSISI_WORK.SelectedValue = "";
                    TXT_YEAR_WORK.Text = "";
                    TXT_MONTH_WORK.Text = "";
                    DDL_STATUS_WORK.SelectedValue = "";
                    TXT_UNIT_WORK.Text = "";
                    DDL_KINERJA_WORK.SelectedValue = "";
                    TXT_OFFICE_NM_HISTORY.Text = "";
                    TXT_NO_TLP_AREA_HISTORY.Text = "";
                    TXT_NO_TLP_HISTORY.Text = "";
                    TXT_OFFICE_YEAR_HISTORY.Text = "";
                    TXT_OFFICE_MONTH_HISTORY.Text = "";
                    LBL_STS_OFFICE_WORK.Text = "";
                    break;

                case "4":
                    TXT_INCOME_BRUTO_PEMOHON.Text = "";
                    TXT_INCOME_NETTO_PEMOHON.Text = "";
                    TXT_OTHER_INCOME_PEMOHON.Text = "";
                    TXT_TOTAL_INCOME_PEMOHON.Text = "";
                    TXT_PAY_PEMOHON.Text = "";
                    TXT_INCOME_BRUTO_SPOUSE.Text = "";
                    TXT_INCOME_NETTO_SPOUSE.Text = "";
                    TXT_OTHER_INCOME_SPOUSE.Text = "";
                    TXT_TOTAL_INCOME_SPOUSE.Text = "";
                    TXT_PAY_SPOUSE.Text = "";
                    TXT_INCOME_MARGIN.Text = "";
                    LBL_STS_OFFICE_FINANCE.Text = "";
                    break;

                case "5":
                    TXT_PEMOHON_SUMMARY.Text = "";
                    TXT_OTHER_SUMMARY.Text = "";
                    LBL_STS_SUMMARY.Text = "";
                    break;
            }
        }
        #endregion

        #region Save Data Field
        protected void BTN_SV_OFFICE_Click(object sender, EventArgs e)
        {
            SaveDate("1");

            try
            {
                // Site visit tanggal kunjungan
                Conn.QueryString = "SP_AUDITTRAIL_APP '" +
                    Request.QueryString["regno"] + "',null,null,null,'" +
                    Request.QueryString["curef"] + "','" +
                    Request.QueryString["tc"] + "','Site visit start date [" + TXT_INVESTIGASI_DAY.Text + "-" + DDL_INVESTIGASI_MONTH.SelectedValue + "-" + TXT_INVESTIGASI_YEAR.Text + "]', '" +
                    TXT_INVESTIGASI_DAY.Text + "-" + DDL_INVESTIGASI_MONTH.SelectedValue + "-" + TXT_INVESTIGASI_YEAR.Text + "', '" +
                    Session["UserID"].ToString() + "',null,null";
                Conn.ExecTrans();

                // Site visit tanggal selesai
                /*Conn.QueryString = "SP_AUDITTRAIL_APP '" +
                    Request.QueryString["regno"] + "',null,null,null,'" +
                    Request.QueryString["curef"] + "','" +
                    Request.QueryString["tc"] + "','Site visit finish date [" + TXT_TG_DATE_DAY.Text + "-" + DDL_TG_DATE_MONTH.SelectedValue + "-" + TXT_TG_DATE_YEAR.Text + "]', '" +
                    TXT_SV_DATE_DAY.Text + "-" + DDL_SV_DATE_MONTH.SelectedValue + "-" + TXT_SV_DATE_YEAR.Text + "', '" +
                    Session["UserID"].ToString() + "',null,null";
                Conn.ExecTrans();*/

                Conn.ExecTran_Commit();
            }
            catch (Exception ex)
            {
                if (Conn != null) Conn.ExecTran_Rollback();
                try { ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "AP_REGNO: " + Request.QueryString["regno"]); }
                catch { }
            }
        }

        protected void BTN_SV_OFFICE_PLUS_Click(object sender, EventArgs e)
        {
            SaveDate("2");
        }

        protected void BTN_SV_OFFICE_WORK_Click(object sender, EventArgs e)
        {
            SaveDate("3");
        }

        protected void BTN_SV_OFFICE_FINANCE_Click(object sender, EventArgs e)
        {
            SaveDate("4");
        }

        protected void BTN_SV_OFFICE_SUMMARY_Click(object sender, EventArgs e)
        {
            SaveDate("5");
        }

        private void SaveDate(string type)
        {
            switch (type)
            {
                case "1":
                    try
                    {
                        Conn.QueryString = "EXEC VER_SITEVISIT_OFFICE '" +
                                           Request.QueryString["regno"] + "', '" +
                                           Request.QueryString["curef"] + "', " +
                                           Tool.ConvertDate(TXT_INVESTIGASI_DAY.Text, DDL_INVESTIGASI_MONTH.SelectedValue, TXT_INVESTIGASI_YEAR.Text) + ", '" +
                                           HttpContext.Current.Server.HtmlEncode(TXT_PEMBERI_KET1.Text) + "', '" +
                                           DDL_POSISI_PEMBERI_KET1.SelectedValue + "', '" +
                                           HttpContext.Current.Server.HtmlEncode(TXT_PEMBERI_KET2.Text) + "', '" +
                                           DDL_POSISI_PEMBERI_KET2.SelectedValue + "', '" +
                                           DDL_OFFICE.SelectedValue + "', '" +
                                           HttpContext.Current.Server.HtmlEncode(TXT_NM_OFFICE.Text) + "', '" +
                                           HttpContext.Current.Server.HtmlEncode(TXT_ADDR_OFFICE1.Text) + "', '" +
                                           HttpContext.Current.Server.HtmlEncode(TXT_ADDR_OFFICE2.Text) + "', '" +
                                           HttpContext.Current.Server.HtmlEncode(TXT_ADDR_OFFICE3.Text) + "', '" +
                                           TXT_ZIPCODE_OFFICE.Text + "', '" +
                                           LBL_CITY_OFFICE.Text + "', '" +
                                           TXT_CITY_OFFICE.Text + "', '" +
                                           TXT_N0_TLP_AREA_OFFICE.Text + "', '" +
                                           TXT_N0_TLP_OFFICE.Text + "', '" +
                                           TXT_EXT_OFFICE.Text + "', '" +
                                           TXT_N0_FAX_AREA_OFFICE.Text + "', '" +
                                           TXT_N0_FAX_OFFICE.Text + "', '" +
                                           TXT_YEAR_OFFICE.Text + "', '" +
                                           DDL_USAHA_OFFICE.SelectedValue + "', '" +
                                           TXT_STAF_OFFICE.Text.Replace(".", "").Replace(",", ".") + "', '" +
                                           HttpContext.Current.Server.HtmlEncode(TXT_SCALE_OFFICE.Text) + "', '" +
                                           DDL_BANGUNAN_OFFICE.SelectedValue + "', '" +
                                           DDL_LOKASI_OFFICE.SelectedValue + "', '" +
                                           DDL_KONDISI_OFFICE.SelectedValue + "', '" +
                                           DDL_OWNER_OFFICE.SelectedValue + "'";
                        Conn.ExecuteQuery();

                        LBL_STS_OFFICE.Text = "Data berhasil disimpan";
                    }
                    catch (Exception ex)
                    {
                        string errmsg = ex.Message.Replace("'", "");
                        if (errmsg.IndexOf("Last Query:") > 0)
                            errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
                        LBL_STS_OFFICE.Text = errmsg;
                    }
                    break;

                case "2":
                    try
                    {
                        Conn.QueryString = "EXEC VER_SITEVISIT_OFFICE_PLUS '" +
                                           Request.QueryString["regno"] + "', '" +
                                           Request.QueryString["curef"] + "', '" +
                                           DDL_NM_OFFICE_PLUS.SelectedValue + "', '" +
                                           HttpContext.Current.Server.HtmlEncode(TXT_NM_OFFICE_PLUS.Text) + "', '" +
                                           DDL_POSISI_PEMOHON_PLUS.SelectedValue + "', '" +
                                           TXT_NO_TLP_AREA_PLUS.Text + "', '" +
                                           TXT_NO_TLP_PLUS.Text + "', '" +
                                           TXT_NO_FAX_AREA_PLUS.Text + "', '" +
                                           TXT_NO_FAX_PLUS.Text + "', '" +
                                           HttpContext.Current.Server.HtmlEncode(TXT_ADDR_PLUS1.Text) + "', '" +
                                           HttpContext.Current.Server.HtmlEncode(TXT_ADDR_PLUS2.Text) + "', '" +
                                           HttpContext.Current.Server.HtmlEncode(TXT_ADDR_PLUS3.Text) + "', '" +
                                           TXT_ZIPCODE_PLUS.Text + "', '" +
                                           LBL_CITY_PLUS.Text + "', '" +
                                           TXT_CITY_PLUS.Text + "'";
                        Conn.ExecuteQuery();

                        LBL_STS_OFFICE_PLUS.Text = "Data berhasil disimpan";
                    }
                    catch (Exception ex)
                    {
                        string errmsg = ex.Message.Replace("'", "");
                        if (errmsg.IndexOf("Last Query:") > 0)
                            errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
                        LBL_STS_OFFICE_PLUS.Text = errmsg;
                    }
                    break;

                case "3":
                    try
                    {
                        Conn.QueryString = "EXEC VER_SITEVISIT_OFFICE_WORK '" +
                                           Request.QueryString["regno"] + "', '" +
                                           Request.QueryString["curef"] + "', '" +
                                           DDL_NAME_WORK.SelectedValue + "', '" +
                                           DDL_POSISI_WORK.SelectedValue + "', '" +
                                           TXT_YEAR_WORK.Text + "', '" +
                                           TXT_MONTH_WORK.Text + "', '" +
                                           DDL_STATUS_WORK.SelectedValue + "', '" +
                                           HttpContext.Current.Server.HtmlEncode(TXT_UNIT_WORK.Text) + "', '" +
                                           DDL_KINERJA_WORK.SelectedValue + "', '" +
                                           HttpContext.Current.Server.HtmlEncode(TXT_OFFICE_NM_HISTORY.Text) + "', '" +
                                           TXT_NO_TLP_AREA_HISTORY.Text + "', '" +
                                           TXT_NO_TLP_HISTORY.Text + "', '" +
                                           TXT_OFFICE_YEAR_HISTORY.Text + "', '" +
                                           TXT_OFFICE_MONTH_HISTORY.Text + "'";
                        Conn.ExecuteQuery();

                        LBL_STS_OFFICE_WORK.Text = "Data berhasil disimpan";
                    }
                    catch (Exception ex)
                    {
                        string errmsg = ex.Message.Replace("'", "");
                        if (errmsg.IndexOf("Last Query:") > 0)
                            errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
                        LBL_STS_OFFICE_WORK.Text = errmsg;
                    }
                    break;

                case "4":
                    try
                    {
                        Conn.QueryString = "EXEC VER_SITEVISIT_OFFICE_FINANCE '" +
                                           Request.QueryString["regno"] + "', '" +
                                           Request.QueryString["curef"] + "', " +
                                           Tool.ConvertFloat(TXT_INCOME_BRUTO_PEMOHON.Text.Replace(".", "").Replace(",", ".")) + ", " +
                                           Tool.ConvertFloat(TXT_INCOME_NETTO_PEMOHON.Text.Replace(".", "").Replace(",", ".")) + ", " +
                                           Tool.ConvertFloat(TXT_OTHER_INCOME_PEMOHON.Text.Replace(".", "").Replace(",", ".")) + ", " +
                                           Tool.ConvertFloat(TXT_TOTAL_INCOME_PEMOHON.Text.Replace(".", "").Replace(",", ".")) + ", " +
                                           Tool.ConvertFloat(TXT_PAY_PEMOHON.Text.Replace(".", "").Replace(",", ".")) + ", " +
                                           Tool.ConvertFloat(TXT_INCOME_BRUTO_SPOUSE.Text.Replace(".", "").Replace(",", ".")) + ", " +
                                           Tool.ConvertFloat(TXT_INCOME_NETTO_SPOUSE.Text.Replace(".", "").Replace(",", ".")) + ", " +
                                           Tool.ConvertFloat(TXT_OTHER_INCOME_SPOUSE.Text.Replace(".", "").Replace(",", ".")) + ", " +
                                           Tool.ConvertFloat(TXT_TOTAL_INCOME_SPOUSE.Text.Replace(".", "").Replace(",", ".")) + ", " +
                                           Tool.ConvertFloat(TXT_PAY_SPOUSE.Text.Replace(".", "").Replace(",", ".")) + ", " +
                                           Tool.ConvertFloat(TXT_INCOME_MARGIN.Text.Replace(".", "").Replace(",", "."));
                        Conn.ExecuteQuery();

                        LBL_STS_OFFICE_FINANCE.Text = "Data berhasil disimpan";
                    }
                    catch (Exception ex)
                    {
                        string errmsg = ex.Message.Replace("'", "");
                        if (errmsg.IndexOf("Last Query:") > 0)
                            errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
                        LBL_STS_OFFICE_FINANCE.Text = errmsg;
                    }
                    break;

                case "5":
                    try
                    {
                        Conn.QueryString = "EXEC VER_SITEVISIT_OFFICE_SUMMARY '" +
                                           Request.QueryString["regno"] + "', '" +
                                           Request.QueryString["curef"] + "', '" +
                                           HttpContext.Current.Server.HtmlEncode(TXT_PEMOHON_SUMMARY.Text) + "', '" +
                                           HttpContext.Current.Server.HtmlEncode(TXT_OTHER_SUMMARY.Text) + "'";
                        Conn.ExecuteQuery();

                        LBL_STS_SUMMARY.Text = "Data berhasil disimpan";
                    }
                    catch (Exception ex)
                    {
                        string errmsg = ex.Message.Replace("'", "");
                        if (errmsg.IndexOf("Last Query:") > 0)
                            errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
                        LBL_STS_SUMMARY.Text = errmsg;
                    }
                    break;
            }
        }
        #endregion
    }
}