using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using DMS.CuBESCore;
using DMS.DBConnection;
using WebCamService;

namespace SME.VerificationAssignment
{
    public partial class HouseEmployee : System.Web.UI.Page
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
            _param.FillDropDownBulan(DDL_BIRTHDATE_MONTH);

            //Fill DropDownList Parameter
            _param.FillDropDownParam(DDL_HUB_PEMBERI_KET_1, "SELECT RELTYPEID, RELTYPEDESC FROM RFRELATIONSHIP WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_HUB_PEMBERI_KET_2, "SELECT RELTYPEID, RELTYPEDESC FROM RFRELATIONSHIP WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_MARRIAGE, "SELECT MARITALID, MARITALDESC FROM RFMARITAL WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_COUPLE_JOB, "SELECT JOBTITLEID, JOBTITLEDESC FROM RFJOBTITLE WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_DEBITUR_TYPE, "SELECT RATEID, RATEDESC FROM RFRATING WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_HUB_FAMS, "SELECT RELTYPEID, RELTYPEDESC FROM RFRELATIONSHIP WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_STS_HS, "SELECT ALAMATID, ALAMATDESC FROM RFJENISALAMAT WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_JNSBANGUNAN_HS, "SELECT BANGUNANID, BANGUNANDESC FROM RFJENISBANGUNAN WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_LKSBANGUNAN_HS, "SELECT LOKASIID, LOKASIDESC FROM RF_APPR_LOKASIBANGUNAN WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_CONDBANGUNAN_HS, "SELECT GUNAID, GUNADESC FROM RF_APPR_PENGGUNAANBANGUNAN WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_FACILITY_HS, "SELECT LENGKAPID, LENGKAPDESC FROM RF_APPR_KELENGKAPAN WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_AKSES_HS, "SELECT JALANID, JALANDESC FROM RF_APPR_JALAN WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_COND_HS, "SELECT LOKASIID, LOKASIDESC FROM RF_APPR_LOKASIBANGUNAN WHERE ACTIVE = '1'");
            _param.FillDropDownParam(DDL_VHCTYP_HS, "SELECT JENISID, JENISDESC FROM RF_APPR_JENISOBYEK WHERE ACTIVE = '1'");
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

            #region Load Data Existing
            //Existing DataRumah
            TXT_INVESTIGASI_DAY.Text = Tool.FormatDate_Day(Conn.GetFieldValue("SV_HS_INVESTIGASI_DATE"));
            DDL_INVESTIGASI_MONTH.SelectedValue = Tool.FormatDate_Month(Conn.GetFieldValue("SV_HS_INVESTIGASI_DATE"));
            TXT_INVESTIGASI_YEAR.Text = Tool.FormatDate_Year(Conn.GetFieldValue("SV_HS_INVESTIGASI_DATE"));
            TXT_PEMBERI_KET_1.Text = Conn.GetFieldValue("SV_HS_PEMBERI_KET1").Replace("&nbsp;", "");
            DDL_HUB_PEMBERI_KET_1.SelectedValue = Conn.GetFieldValue("SV_HS_HUB_PEMBERI_KET1");
            TXT_PEMBERI_KET_2.Text = Conn.GetFieldValue("SV_HS_PEMBERI_KET2").Replace("&nbsp;", "");
            DDL_HUB_PEMBERI_KET_2.SelectedValue = Conn.GetFieldValue("SV_HS_HUB_PEMBERI_KET2");
            TXT_NAMA_PEMOHON1.Text = Conn.GetFieldValue("SV_HS_NM_PEMOHON1").Replace("&nbsp;", "");
            TXT_NAMA_PEMOHON2.Text = Conn.GetFieldValue("SV_HS_NM_PEMOHON2").Replace("&nbsp;", "");
            TXT_NAMA_PEMOHON3.Text = Conn.GetFieldValue("SV_HS_NM_PEMOHON3").Replace("&nbsp;", "");
            TXT_BIRTHDATE_DAY.Text = Tool.FormatDate_Day(Conn.GetFieldValue("SV_HS_BIRTH_DATE"));
            DDL_BIRTHDATE_MONTH.SelectedValue = Tool.FormatDate_Month(Conn.GetFieldValue("SV_HS_BIRTH_DATE"));
            TXT_BIRTHDATE_YEAR.Text = Tool.FormatDate_Year(Conn.GetFieldValue("SV_HS_BIRTH_DATE"));
            RDO_SEX_TYPE.SelectedValue = Conn.GetFieldValue("SV_HS_SEX_TYP");
            TXT_EMAIL.Text = Conn.GetFieldValue("SV_HS_EMAIL").Replace("&nbsp;", "");
            TXT_ADDR_KTP1.Text = Conn.GetFieldValue("SV_HS_ADDR_KTP1").Replace("&nbsp;", "");
            TXT_ADDR_KTP2.Text = Conn.GetFieldValue("SV_HS_ADDR_KTP2").Replace("&nbsp;", "");
            TXT_ADDR_KTP3.Text = Conn.GetFieldValue("SV_HS_ADDR_KTP3").Replace("&nbsp;", "");
            TXT_ZIPCODE_KTP.Text = Conn.GetFieldValue("SV_HS_ZIP_KTP").Replace("&nbsp;", "");
            LBL_CITY_KTP.Text = Conn.GetFieldValue("SV_HS_CITY_CODE_KTP").Replace("&nbsp;", "");
            TXT_CITY_KTP.Text = Conn.GetFieldValue("SV_HS_CITY_KTP").Replace("&nbsp;", "");
            TXT_ADDR1.Text = Conn.GetFieldValue("SV_HS_ADDR1").Replace("&nbsp;", "");
            TXT_ADDR2.Text = Conn.GetFieldValue("SV_HS_ADDR2").Replace("&nbsp;", "");
            TXT_ADDR3.Text = Conn.GetFieldValue("SV_HS_ADDR3").Replace("&nbsp;", "");
            TXT_ZIPCODE.Text = Conn.GetFieldValue("SV_HS_ZIP").Replace("&nbsp;", "");
            LBL_CITY.Text = Conn.GetFieldValue("SV_HS_CITY_CODE").Replace("&nbsp;", "");
            TXT_CITY.Text = Conn.GetFieldValue("SV_HS_CITY").Replace("&nbsp;", "");
            TXT_NO_TLP_AREA.Text = Conn.GetFieldValue("SV_HS_NO_TLP_AREA").Replace("&nbsp;", "");
            TXT_NO_TLP.Text = Conn.GetFieldValue("SV_HS_NO_TLP").Replace("&nbsp;", "");
            TXT_NO_HP_AREA.Text = Conn.GetFieldValue("SV_HS_NO_HP_AREA").Replace("&nbsp;", "");
            TXT_NO_HP.Text = Conn.GetFieldValue("SV_HS_NO_HP").Replace("&nbsp;", "");
            DDL_MARRIAGE.SelectedValue = Conn.GetFieldValue("SV_HS_MARRIAGE");
            TXT_COUPLE_NM1.Text = Conn.GetFieldValue("SV_HS_COUPLE_NM1").Replace("&nbsp;", "");
            TXT_COUPLE_NM2.Text = Conn.GetFieldValue("SV_HS_COUPLE_NM2").Replace("&nbsp;", "");
            TXT_COUPLE_NM3.Text = Conn.GetFieldValue("SV_HS_COUPLE_NM3").Replace("&nbsp;", "");
            DDL_COUPLE_JOB.SelectedValue = Conn.GetFieldValue("SV_HS_COUPLE_JOB");
            TXT_MOTHER_NM1.Text = Conn.GetFieldValue("SV_HS_MOTHER_NM1").Replace("&nbsp;", "");
            TXT_MOTHER_NM2.Text = Conn.GetFieldValue("SV_HS_MOTHER_NM2").Replace("&nbsp;", "");
            TXT_MOTHER_NM3.Text = Conn.GetFieldValue("SV_HS_MOTHER_NM3").Replace("&nbsp;", "");
            TXT_TERTANGGUNG.Text = (Conn.GetFieldValue("SV_HS_JML_TERTANGGUNG").Replace("&nbsp;", "")).Replace(".", "'").Replace(",", ".").Replace("'", ",");
            DDL_DEBITUR_TYPE.SelectedValue = Conn.GetFieldValue("SV_HS_DEBITUR_TYP");

            //Existing DataRumahTambahan
            TXT_ADDR_PLUS1.Text = Conn.GetFieldValue("SV_HS_ADDR_PLUS1").Replace("&nbsp;", "");
            TXT_ADDR_PLUS2.Text = Conn.GetFieldValue("SV_HS_ADDR_PLUS2").Replace("&nbsp;", "");
            TXT_ADDR_PLUS3.Text = Conn.GetFieldValue("SV_HS_ADDR_PLUS3").Replace("&nbsp;", "");
            TXT_ZIPCODE_PLUS.Text = Conn.GetFieldValue("SV_HS_ZIP_PLUS").Replace("&nbsp;", "");
            LBL_CITY_PLUS.Text = Conn.GetFieldValue("SV_HS_CITY_CODE_PLUS").Replace("&nbsp;", "");
            TXT_CITY_PLUS.Text = Conn.GetFieldValue("SV_HS_CITY_PLUS").Replace("&nbsp;", "");
            TXT_NO_TLP_AREA_PLUS.Text = Conn.GetFieldValue("SV_HS_NO_TLP_AREA_PLUS").Replace("&nbsp;", "");
            TXT_NO_TLP_PLUS.Text = Conn.GetFieldValue("SV_HS_NO_TLP_PLUS").Replace("&nbsp;", "");
            TXT_NO_HP_AREA_PLUS.Text = Conn.GetFieldValue("SV_HS_NO_HP_AREA_PLUS").Replace("&nbsp;", "");
            TXT_NO_HP_PLUS.Text = Conn.GetFieldValue("SV_HS_NO_HP_PLUS").Replace("&nbsp;", "");

            //Existing KeluargaTidakSerumah
            TXT_NAMA_FAMS1.Text = Conn.GetFieldValue("SV_HS_NM_FAMS1").Replace("&nbsp;", "");
            TXT_NAMA_FAMS2.Text = Conn.GetFieldValue("SV_HS_NM_FAMS2").Replace("&nbsp;", "");
            TXT_NAMA_FAMS3.Text = Conn.GetFieldValue("SV_HS_NM_FAMS3").Replace("&nbsp;", "");
            TXT_ADDR_FAMS1.Text = Conn.GetFieldValue("SV_HS_ADDR_FAMS1").Replace("&nbsp;", "");
            TXT_ADDR_FAMS2.Text = Conn.GetFieldValue("SV_HS_ADDR_FAMS2").Replace("&nbsp;", "");
            TXT_ADDR_FAMS3.Text = Conn.GetFieldValue("SV_HS_ADDR_FAMS3").Replace("&nbsp;", "");
            TXT_ZIPCODE_FAMS.Text = Conn.GetFieldValue("SV_HS_ZIP_FAMS").Replace("&nbsp;", "");
            LBL_CITY_FAMS.Text = Conn.GetFieldValue("SV_HS_CITY_CODE_FAMS").Replace("&nbsp;", "");
            TXT_CITY_FAMS.Text = Conn.GetFieldValue("SV_HS_CITY_FAMS").Replace("&nbsp;", "");
            TXT_NO_TLP_AREA_FAMS.Text = Conn.GetFieldValue("SV_HS_NO_TLP_AREA_FAMS").Replace("&nbsp;", "");
            TXT_NO_TLP_FAMS.Text = Conn.GetFieldValue("SV_HS_NO_TLP_FAMS").Replace("&nbsp;", "");
            TXT_N0_OFFICE_AREA_FAMS.Text = Conn.GetFieldValue("SV_HS_NO_OFFICE_AREA_FAMS").Replace("&nbsp;", "");
            TXT_N0_OFFICE_FAMS.Text = Conn.GetFieldValue("SV_HS_NO_OFFICE_FAMS").Replace("&nbsp;", "");
            TXT_EXT_OFFICE_FAMS.Text = Conn.GetFieldValue("SV_HS_NO_OFFICE_EXT_FAMS").Replace("&nbsp;", "");
            TXT_NO_HP_AREA_FAMS.Text = Conn.GetFieldValue("SV_HS_NO_HP_AREA_FAMS").Replace("&nbsp;", "");
            TXT_NO_HP_FAMS.Text = Conn.GetFieldValue("SV_HS_NO_HP_FAMS").Replace("&nbsp;", "");
            DDL_HUB_FAMS.SelectedValue = Conn.GetFieldValue("SV_HS_HUB_FAMS");

            //Existing DataRumahPemohon
            DDL_STS_HS.SelectedValue = Conn.GetFieldValue("SV_HS_STS_HOME_STAY");
            ParseCheckBox(CHB_CEK_HS, Conn.GetFieldValue("SV_HS_CEK_ARSIP_STAY"));
            RDO_AGUNAN_HS.SelectedValue = Conn.GetFieldValue("SV_HS_AGUNAN_STAY");
            TXT_STAY_DAY_HS.Text = Conn.GetFieldValue("SV_HS_DAY_STAY").Replace("&nbsp;", "");
            TXT_STAY_MONTH_HS.Text = Conn.GetFieldValue("SV_HS_MONTH_STAY").Replace("&nbsp;", "");
            DDL_JNSBANGUNAN_HS.SelectedValue = Conn.GetFieldValue("SV_HS_BANGUNAN_TYPE_STAY");
            DDL_LKSBANGUNAN_HS.SelectedValue = Conn.GetFieldValue("SV_HS_BANGUNAN_LOKASI_STAY");
            DDL_CONDBANGUNAN_HS.SelectedValue = Conn.GetFieldValue("SV_HS_BANGUNAN_COND_STAY");
            DDL_FACILITY_HS.SelectedValue = Conn.GetFieldValue("SV_HS_FASILITAS_STAY");
            ParseCheckBox(CHB_BARANG_HS, Conn.GetFieldValue("SV_HS_BARANG_HOME_STAY"));
            DDL_AKSES_HS.SelectedValue = Conn.GetFieldValue("SV_HS_AKSES_ROAD_STAY");
            DDL_COND_HS.SelectedValue = Conn.GetFieldValue("SV_HS_LINGKUNGAN_STAY");
            TXT_LUASTANAH_HS.Text = (Conn.GetFieldValue("SV_HS_LUAS_TANAH_STAY").Replace("&nbsp;", "")).Replace(".", "'").Replace(",", ".").Replace("'", ",");
            TXT_LUASBANGUNAN_HS.Text = (Conn.GetFieldValue("SV_HS_LUAS_BANGUNAN_STAY").Replace("&nbsp;", "")).Replace(".", "'").Replace(",", ".").Replace("'", ",");
            RDO_GARASI_HS.SelectedValue = Conn.GetFieldValue("SV_HS_GARASI_STAY");
            RDO_CARPORT_HS.SelectedValue = Conn.GetFieldValue("SV_HS_CARPORT_STAY");
            RDO_KENDARAAN_HS.SelectedValue = Conn.GetFieldValue("SV_HS_VEHICLE_STAY");
            DDL_VHCTYP_HS.SelectedValue = Conn.GetFieldValue("SV_HS_VEHICLE_TYPE_STAY");
            TXT_JUMVHC_HS.Text = (Conn.GetFieldValue("SV_HS_VEHICLE_COUNT_STAY").Replace("&nbsp;", "")).Replace(".", "'").Replace(",", ".").Replace("'", ",");
            RDO_CONDVHC_HS.SelectedValue = Conn.GetFieldValue("SV_HS_VEHICLE_COND_STAY");
            TXT_OTHERKET_HS.Text = Conn.GetFieldValue("SV_HS_KETERANGAN_STAY").Replace("&nbsp;", "");
            #endregion
        }

        protected void CHB_ADDR_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_ADDR.Checked == true)
            {
                TXT_ADDR1.Text = TXT_ADDR_KTP1.Text;
                TXT_ADDR2.Text = TXT_ADDR_KTP2.Text;
                TXT_ADDR3.Text = TXT_ADDR_KTP3.Text;
                TXT_CITY.Text = TXT_CITY_KTP.Text;
                TXT_ZIPCODE.Text = TXT_ZIPCODE_KTP.Text;
            }
            else
            {
                TXT_ADDR1.Text = "";
                TXT_ADDR2.Text = "";
                TXT_ADDR3.Text = "";
                TXT_CITY.Text = "";
                TXT_ZIPCODE.Text = "";
            }
        }

        private string ResultCheckBox(CheckBoxList idCheckBox)
        {
            string items = string.Empty;
            foreach (ListItem i in idCheckBox.Items)
            {
                if (i.Selected == true)
                {
                    items += i.Value + ",";
                }
            }
            return items;
        }

        private void ParseCheckBox(CheckBoxList idCheckBox, string check)
        {
            string[] words = check.Split(',');
            
            foreach (var word in words)
            {
                foreach (ListItem i in idCheckBox.Items)
                {
                    if (i.Value == word)
                    {
                        i.Selected=true;
                    }   
                }
            }
        }

        private void ClearCheckBox(CheckBoxList idCheckBox)
        {
            foreach (ListItem i in idCheckBox.Items)
            {
                i.Selected = false;
            }
        }

        #region Search ZIP Code
        protected void BTN_SEARCHZIP_KTP_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_ZIPCODE_KTP','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
        }

        protected void TXT_ZIPCODE_KTP_TextChanged(object sender, EventArgs e)
        {
            Conn.QueryString = "SELECT CITYID, CITYNAME, [DESCRIPTION] FROM VW_ZIPCODECITY WHERE RTRIM(LTRIM(ZIPCODE)) = '" +
                                TXT_ZIPCODE_KTP.Text.Trim() + "' ";
            Conn.ExecuteQuery();
            try
            {
                LBL_CITY_KTP.Text = Conn.GetFieldValue(0, 0);
                TXT_CITY_KTP.Text = Conn.GetFieldValue(0, 1);
                TXT_ADDR_KTP3.Text = Conn.GetFieldValue(0, 2);
            }
            catch
            {
                TXT_ZIPCODE_KTP.Text = "";
                TXT_CITY_KTP.Text = "";
                GlobalTools.popMessage(this, "Invalid Zipcode!");
            }
        }

        protected void BTN_SEARCHZIP_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_ZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
        }

        protected void TXT_ZIPCODE_TextChanged(object sender, EventArgs e)
        {
            Conn.QueryString = "SELECT CITYID, CITYNAME, [DESCRIPTION] FROM VW_ZIPCODECITY WHERE RTRIM(LTRIM(ZIPCODE)) = '" +
                                TXT_ZIPCODE.Text.Trim() + "' ";
            Conn.ExecuteQuery();
            try
            {
                LBL_CITY.Text = Conn.GetFieldValue(0, 0);
                TXT_CITY.Text = Conn.GetFieldValue(0, 1);
                TXT_ADDR3.Text = Conn.GetFieldValue(0, 2);
            }
            catch
            {
                TXT_ZIPCODE.Text = "";
                TXT_CITY.Text = "";
                GlobalTools.popMessage(this, "Invalid Zipcode!");
            }
        }

        protected void BTN_SEARCHZIP_PLUS_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_ZIPCODE_PLUS','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
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

        protected void BTN_SEARCHZIP_FAMS_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_ZIPCODE_FAMS','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
        }

        protected void TXT_ZIPCODE_FAMS_TextChanged(object sender, EventArgs e)
        {
            Conn.QueryString = "SELECT CITYID, CITYNAME, [DESCRIPTION] FROM VW_ZIPCODECITY WHERE RTRIM(LTRIM(ZIPCODE)) = '" +
                                TXT_ZIPCODE_FAMS.Text.Trim() + "' ";
            Conn.ExecuteQuery();
            try
            {
                LBL_CITY_FAMS.Text = Conn.GetFieldValue(0, 0);
                TXT_CITY_FAMS.Text = Conn.GetFieldValue(0, 1);
                TXT_ADDR_FAMS3.Text = Conn.GetFieldValue(0, 2);
            }
            catch
            {
                TXT_ZIPCODE_FAMS.Text = "";
                TXT_CITY_FAMS.Text = "";
                GlobalTools.popMessage(this, "Invalid Zipcode!");
            }
        }
        #endregion

        #region Clear Data Field
        protected void BTN_CLR_DATA_HM_Click(object sender, EventArgs e)
        {
            ClearData("1");
        }

        protected void BTN_CLR_HM_PLUS_Click(object sender, EventArgs e)
        {
            ClearData("2");
        }

        protected void BTN_CLR_HM_FAMS_Click(object sender, EventArgs e)
        {
            ClearData("3");
        }

        protected void BTN_CLR_HS_Click(object sender, EventArgs e)
        {
            ClearData("4");
        }

        private void ClearData(string type)
        {
            switch (type)
            {
                case "1":
                    TXT_INVESTIGASI_DAY.Text = "";
                    DDL_INVESTIGASI_MONTH.SelectedValue = "";
                    TXT_INVESTIGASI_YEAR.Text = "";
                    TXT_PEMBERI_KET_1.Text = "";
                    DDL_HUB_PEMBERI_KET_1.SelectedValue = "";
                    TXT_PEMBERI_KET_2.Text = "";
                    DDL_HUB_PEMBERI_KET_2.SelectedValue = "";
                    TXT_NAMA_PEMOHON1.Text = "";
                    TXT_NAMA_PEMOHON2.Text = "";
                    TXT_NAMA_PEMOHON3.Text = "";
                    TXT_BIRTHDATE_DAY.Text = "";
                    DDL_BIRTHDATE_MONTH.SelectedValue = "";
                    TXT_BIRTHDATE_YEAR.Text = "";
                    RDO_SEX_TYPE.SelectedValue = "1";
                    TXT_EMAIL.Text = "";
                    TXT_ADDR_KTP1.Text = "";
                    TXT_ADDR_KTP2.Text = "";
                    TXT_ADDR_KTP3.Text = "";
                    TXT_ZIPCODE_KTP.Text = "";
                    LBL_CITY_KTP.Text = "";
                    TXT_CITY_KTP.Text = "";
                    TXT_ADDR1.Text = "";
                    TXT_ADDR2.Text = "";
                    TXT_ADDR3.Text = "";
                    CHB_ADDR.Checked = false;
                    TXT_ZIPCODE.Text = "";
                    LBL_CITY.Text = "";
                    TXT_CITY.Text = "";
                    TXT_NO_TLP_AREA.Text = "";
                    TXT_NO_TLP.Text = "";
                    TXT_NO_HP_AREA.Text = "+62";
                    TXT_NO_HP.Text = "";
                    DDL_MARRIAGE.SelectedValue = "";
                    TXT_COUPLE_NM1.Text = "";
                    TXT_COUPLE_NM2.Text = "";
                    TXT_COUPLE_NM3.Text = "";
                    DDL_COUPLE_JOB.SelectedValue = "";
                    TXT_MOTHER_NM1.Text = "";
                    TXT_MOTHER_NM2.Text = "";
                    TXT_MOTHER_NM3.Text = "";
                    TXT_TERTANGGUNG.Text = "";
                    DDL_DEBITUR_TYPE.SelectedValue = "";
                    LBL_STS_DATA_HM.Text = "";
                    break;

                case "2":
                    TXT_ADDR_PLUS1.Text = "";
                    TXT_ADDR_PLUS2.Text = "";
                    TXT_ADDR_PLUS3.Text = "";
                    TXT_ZIPCODE_PLUS.Text = "";
                    LBL_CITY_PLUS.Text = "";
                    TXT_CITY_PLUS.Text = "";
                    TXT_NO_TLP_AREA_PLUS.Text = "";
                    TXT_NO_TLP_PLUS.Text = "";
                    TXT_NO_HP_AREA_PLUS.Text = "+62";
                    TXT_NO_HP_PLUS.Text = "";
                    LBL_STS_HM_PLUS.Text = "";
                    break;

                case "3":
                    TXT_NAMA_FAMS1.Text = "";
                    TXT_NAMA_FAMS2.Text = "";
                    TXT_NAMA_FAMS3.Text = "";
                    TXT_ADDR_FAMS1.Text = "";
                    TXT_ADDR_FAMS2.Text = "";
                    TXT_ADDR_FAMS3.Text = "";
                    TXT_ZIPCODE_FAMS.Text = "";
                    LBL_CITY_FAMS.Text = "";
                    TXT_CITY_FAMS.Text = "";
                    TXT_NO_TLP_AREA_FAMS.Text = "";
                    TXT_NO_TLP_FAMS.Text = "";
                    TXT_N0_OFFICE_AREA_FAMS.Text = "";
                    TXT_N0_OFFICE_FAMS.Text = "";
                    TXT_EXT_OFFICE_FAMS.Text = "";
                    TXT_NO_HP_AREA_FAMS.Text = "+62";
                    TXT_NO_HP_FAMS.Text = "";
                    DDL_HUB_FAMS.SelectedValue = "";
                    LBL_STS_HM_FAMS.Text = "";
                    break;

                case "4":
                    DDL_STS_HS.SelectedValue = "";
                    ClearCheckBox(CHB_CEK_HS);
                    RDO_AGUNAN_HS.SelectedValue = "0";
                    TXT_STAY_DAY_HS.Text = "";
                    TXT_STAY_MONTH_HS.Text = "";
                    DDL_JNSBANGUNAN_HS.SelectedValue = "";
                    DDL_LKSBANGUNAN_HS.SelectedValue = "";
                    DDL_CONDBANGUNAN_HS.SelectedValue = "";
                    DDL_FACILITY_HS.SelectedValue = "";
                    ClearCheckBox(CHB_BARANG_HS);
                    DDL_AKSES_HS.SelectedValue = "";
                    DDL_COND_HS.SelectedValue = "";
                    TXT_LUASTANAH_HS.Text = "";
                    TXT_LUASBANGUNAN_HS.Text = "";
                    RDO_GARASI_HS.SelectedValue = "0";
                    RDO_CARPORT_HS.SelectedValue = "0";
                    RDO_KENDARAAN_HS.SelectedValue = "0";
                    DDL_VHCTYP_HS.SelectedValue = "";
                    TXT_JUMVHC_HS.Text = "";
                    RDO_CONDVHC_HS.SelectedValue = "0";
                    TXT_OTHERKET_HS.Text = "";
                    LBL_STS_HS.Text = "";
                    break;
            }
        }
        #endregion

        #region Save Data Field
        protected void BTN_SV_DATA_HM_Click(object sender, EventArgs e)
        {
            SaveData("1");

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

        protected void BTN_SV_HM_PLUS_Click(object sender, EventArgs e)
        {
            SaveData("2");
        }

        protected void BTN_SV_HM_FAMS_Click(object sender, EventArgs e)
        {
            SaveData("3");
        }

        protected void BTN_SV_HS_Click(object sender, EventArgs e)
        {
            SaveData("4");
        }

        private void SaveData(string type)
        {
            switch (type)
            {
                case "1":
                    try
                    {
                        Conn.QueryString = "EXEC VER_SITEVISIT_HOUSE '" +
				                            Request.QueryString["regno"] + "', '" +
				                            Request.QueryString["curef"] + "', "+
                                            Tool.ConvertDate(TXT_INVESTIGASI_DAY.Text, DDL_INVESTIGASI_MONTH.SelectedValue, TXT_INVESTIGASI_YEAR.Text) + ", '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_PEMBERI_KET_1.Text) + "', '" +
                                            DDL_HUB_PEMBERI_KET_1.SelectedValue + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_PEMBERI_KET_2.Text) + "', '" +
                                            DDL_HUB_PEMBERI_KET_2.SelectedValue + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_NAMA_PEMOHON1.Text) + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_NAMA_PEMOHON2.Text) + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_NAMA_PEMOHON3.Text) + "', " +
                                            Tool.ConvertDate(TXT_BIRTHDATE_DAY.Text, DDL_BIRTHDATE_MONTH.SelectedValue, TXT_BIRTHDATE_YEAR.Text) + ", '" +
                                            RDO_SEX_TYPE.SelectedValue + "', '" +
                                            TXT_EMAIL.Text + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_ADDR_KTP1.Text) + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_ADDR_KTP2.Text) + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_ADDR_KTP3.Text) + "', '" +
                                            TXT_ZIPCODE_KTP.Text + "', '" +
                                            LBL_CITY_KTP.Text + "', '" +
                                            TXT_CITY_KTP.Text + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_ADDR1.Text) + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_ADDR2.Text) + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_ADDR3.Text) + "', '" +
                                            TXT_ZIPCODE.Text + "', '" +
                                            LBL_CITY.Text + "', '" +
                                            TXT_CITY.Text + "', '" +
                                            TXT_NO_TLP_AREA.Text + "', '" +
                                            TXT_NO_TLP.Text + "', '" +
                                            TXT_NO_HP_AREA.Text + "', '" +
                                            TXT_NO_HP.Text + "', '" +
                                            DDL_MARRIAGE.SelectedValue + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_COUPLE_NM1.Text) + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_COUPLE_NM2.Text) + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_COUPLE_NM3.Text) + "', '" +
                                            DDL_COUPLE_JOB.SelectedValue + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_MOTHER_NM1.Text) + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_MOTHER_NM2.Text) + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_MOTHER_NM3.Text) + "', '" +
                                            TXT_TERTANGGUNG.Text.Replace(".", "").Replace(",", ".") + "', '" +
                                            DDL_DEBITUR_TYPE.SelectedValue + "'";
				        Conn.ExecuteQuery();

                        LBL_STS_DATA_HM.Text = "Data berhasil disimpan";
                    }
                    catch (Exception ex)
                    {
                        string errmsg = ex.Message.Replace("'", "");
                        if (errmsg.IndexOf("Last Query:") > 0)
                            errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
                        LBL_STS_DATA_HM.Text = errmsg;
                    }
                    break;

                case "2":
                    try
                    {
                        Conn.QueryString = "EXEC VER_SITEVISIT_HOUSE_PLUS '" +
                                            Request.QueryString["regno"] + "', '" +
                                            Request.QueryString["curef"] + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_ADDR_PLUS1.Text) + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_ADDR_PLUS2.Text) + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_ADDR_PLUS3.Text) + "', '" +
                                            TXT_ZIPCODE_PLUS.Text + "', '" +
                                            LBL_CITY_PLUS.Text + "', '" +
                                            TXT_CITY_PLUS.Text + "', '" +
                                            TXT_NO_TLP_AREA_PLUS.Text + "', '" +
                                            TXT_NO_TLP_PLUS.Text + "', '" +
                                            TXT_NO_HP_AREA_PLUS.Text + "', '" +
                                            TXT_NO_HP_PLUS.Text + "'";
                        Conn.ExecuteQuery();

                        LBL_STS_HM_PLUS.Text = "Data berhasil disimpan";
                    }
                    catch (Exception ex)
                    {
                        string errmsg = ex.Message.Replace("'", "");
                        if (errmsg.IndexOf("Last Query:") > 0)
                            errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
                        LBL_STS_HM_PLUS.Text = errmsg;
                    }
                    break;

                case "3":
                    try
                    {
                        Conn.QueryString = "EXEC VER_SITEVISIT_HOUSE_FAMS '" +
                                            Request.QueryString["regno"] + "', '" +
                                            Request.QueryString["curef"] + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_NAMA_FAMS1.Text) + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_NAMA_FAMS2.Text) + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_NAMA_FAMS3.Text) + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_ADDR_FAMS1.Text) + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_ADDR_FAMS2.Text) + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_ADDR_FAMS3.Text) + "', '" +
                                            TXT_ZIPCODE_FAMS.Text + "', '" +
                                            LBL_CITY_FAMS.Text + "', '" +
                                            TXT_CITY_FAMS.Text + "', '" +
                                            TXT_NO_TLP_AREA_FAMS.Text + "', '" +
                                            TXT_NO_TLP_FAMS.Text + "', '" +
                                            TXT_N0_OFFICE_AREA_FAMS.Text + "', '" +
                                            TXT_N0_OFFICE_FAMS.Text + "', '" +
                                            TXT_EXT_OFFICE_FAMS.Text + "', '" +
                                            TXT_NO_HP_AREA_FAMS.Text + "', '" +
                                            TXT_NO_HP_FAMS.Text + "', '" +
                                            DDL_HUB_FAMS.SelectedValue + "'";
                        Conn.ExecuteQuery();

                        LBL_STS_HM_FAMS.Text = "Data berhasil disimpan";
                    }
                    catch (Exception ex)
                    {
                        string errmsg = ex.Message.Replace("'", "");
                        if (errmsg.IndexOf("Last Query:") > 0)
                            errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
                        LBL_STS_HM_FAMS.Text = errmsg;
                    }
                    break;

                case "4":
                    string chbCek = ResultCheckBox(CHB_CEK_HS);
                    string chbBarang = ResultCheckBox(CHB_BARANG_HS);
                    try
                    {
                        Conn.QueryString = "EXEC VER_SITEVISIT_HOUSE_STAY '" +
                                            Request.QueryString["regno"] + "', '" +
                                            Request.QueryString["curef"] + "', '" +
                                            DDL_STS_HS.SelectedValue + "', '" +
                                            chbCek.ToString() + "', '" +
                                            RDO_AGUNAN_HS.SelectedValue + "', '" +
                                            TXT_STAY_DAY_HS.Text + "', '" +
                                            TXT_STAY_MONTH_HS.Text + "', '" +
                                            DDL_JNSBANGUNAN_HS.SelectedValue + "', '" +
                                            DDL_LKSBANGUNAN_HS.SelectedValue + "', '" +
                                            DDL_CONDBANGUNAN_HS.SelectedValue + "', '" +
                                            DDL_FACILITY_HS.SelectedValue + "', '" +
                                            chbBarang.ToString() + "', '" +
                                            DDL_AKSES_HS.SelectedValue + "', '" +
                                            DDL_COND_HS.SelectedValue + "', '" +
                                            TXT_LUASTANAH_HS.Text.Replace(".", "").Replace(",", ".") + "', '" +
                                            TXT_LUASBANGUNAN_HS.Text.Replace(".", "").Replace(",", ".") + "', '" +
                                            RDO_GARASI_HS.SelectedValue + "', '" +
                                            RDO_CARPORT_HS.SelectedValue + "', '" +
                                            RDO_KENDARAAN_HS.SelectedValue + "', '" +
                                            DDL_VHCTYP_HS.SelectedValue + "', '" +
                                            TXT_JUMVHC_HS.Text.Replace(".", "").Replace(",", ".") + "', '" +
                                            RDO_CONDVHC_HS.SelectedValue + "', '" +
                                            HttpContext.Current.Server.HtmlEncode(TXT_OTHERKET_HS.Text) + "'";
                        Conn.ExecuteQuery();

                        LBL_STS_HS.Text = "Data berhasil disimpan";
                    }
                    catch (Exception ex)
                    {
                        string errmsg = ex.Message.Replace("'", "");
                        if (errmsg.IndexOf("Last Query:") > 0)
                            errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
                        LBL_STS_HS.Text = errmsg;
                    }
                    break;
            }
        }
        #endregion
    }
}