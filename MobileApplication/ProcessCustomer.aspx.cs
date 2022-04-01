using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DMS.CuBESCore;
using DMS.DBConnection;
using System.Data;
using System.IO;

namespace SME.MobileApplication
{
    public partial class ProcessCustomer : System.Web.UI.Page
    {
        protected Tools tools = new Tools();
        protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
        protected Connection connM = new Connection(ConfigurationSettings.AppSettings["connMobile"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
                Response.Redirect("../Restricted.aspx");

            if (!IsPostBack)
            {
                ListCustomerFromMobile();

                kota.Items.Add(new ListItem("- PILIH -", ""));
                conn.QueryString = "select CITYID, CITYNAME from RFCITY WHERE ACTIVE = '1'";
                conn.ExecuteQuery();
                for (int i = 0; i < conn.GetRowCount(); i++)
                {
                    kota.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
                }
            }
        }

        private void ListCustomerFromMobile()
        {
            connM.QueryString = "select distinct n.Id, NoIdentitas, NamaLengkap, TanggalLahir, AlamatRumah, " +
                "k.Name as KotaKabRumah, p.Name as PropinsiRumah from Nasabah n " +
                "left join Pengajuan a on n.Id = a.NasabahId " +
                "left join RefPropinsi p on n.PropinsiRumah = p.Id " +
                "left join RefKotaKab k on n.KotaKabRumah = k.Id " +
                "where isnull(LosCuRef, '') = '' and a.BranchCode = '" + Session["BranchID"].ToString() + "'";
            connM.ExecuteQuery();

            DataTable dt = new DataTable();
            dt = connM.GetDataTable().Copy();
            GridView1.DataSource = dt;
            try
            {
                GridView1.DataBind();
            }
            catch
            {
                GridView1.PageIndex = 0;
                GridView1.DataBind();
            }
        }

        private void viewDetails(string Id)
        {
            connM.QueryString = "select n.Id, " +
                        "UserName, " +
                        "GelarSebelum, " +
                        "NamaLengkap, " +
                        "GelarSesudah, " +
                        "s.SEXDESC as JenisKelamin, " +
                        "TempatLahir, " +
                        "convert(varchar, TanggalLahir, 105) as TanggalLahir, " +
                        "NoIdentitas, " +
                        "AlamatRumah, " +
                        "p1.Name as PropinsiRumah, " +
                        "k1.Name as KotaKabRumah, " +
                        "c1.Name as KecamatanRumah, " +
                        "l1.Name as KelurahanRumah, " +
                        "KodePosRumah, " +
                        "TeleponRumah, " +
                        "TeleponGenggam, " +
                        "NamaIbuKandung, " +
                        "e.EDUCATIONDESC as Pendidikan, " +
                        "m.MARITALDESC as StatusPerkawinan, " +
                        "z.CITIZENDESC as Kewarganegaraan, " +
                        "h.HM_DESC as StatusRumah, " +
                        "j.JOBTITLEDESC as JenisPekerjaan, " +
                        "Pendapatan, " +
                        "AlamatKantor, " +
                        "TeleponKantor, " +
                        "p2.Name as PropinsiKantor, " +
                        "k2.Name as KotaKabKantor, " +
                        "KodePosKantor, " +
                        "NamaSaudara, " +
                        "AlamatSaudara, " +
                        "p3.Name as PropinsiSaudara, " +
                        "k3.Name as KotaKabSaudara, " +
                        "KodePosSaudara, " +
                        "r.RELTYPEDESC as HubunganSaudara, " +
                        "LosCuRef " +
                        "from Nasabah n " +
                        "left join RFSEX s on n.JenisKelamin = s.SEXID " +
                        "left join RefPropinsi p1 on n.PropinsiRumah = p1.Id " +
                        "left join RefKotaKab k1 on n.KotaKabRumah = k1.Id " +
                        "left join RefKecamatan c1 on n.KecamatanRumah = c1.Id " +
                        "left join RefKelurahan l1 on n.KelurahanRumah = l1.Id " +
                        "left join RFEDUCATION e on n.Pendidikan = e.EDUCATIONID " +
                        "left join RFMARITAL m on n.StatusPerkawinan = m.MARITALID " +
                        "left join RFCITIZENSHIP z on n.Kewarganegaraan = z.CITIZENID " +
                        "left join RFHOMESTA h on n.StatusRumah = h.HM_CODE " +
                        "left join RFJOBTITLE j on n.JenisPekerjaan = j.JOBTITLEID " +
                        "left join RefPropinsi p2 on n.PropinsiKantor = p2.Id " +
                        "left join RefKotaKab k2 on n.KotaKabKantor = k2.Id " +
                        "left join RefPropinsi p3 on n.PropinsiSaudara = p3.Id " +
                        "left join RefKotaKab k3 on n.KotaKabSaudara = k3.Id " +
                        "left join RFRELATIONSHIP r on n.HubunganSaudara = r.RELTYPEID " +
                        "where n.Id = " + Id;
            connM.ExecuteQuery();

            clearDetails();

            if (connM.GetRowCount() > 0)
            {
                LblId.Text = connM.GetFieldValue("Id");
                LblUserName.Text = connM.GetFieldValue("UserName");
                LblGelarSebelum.Text = connM.GetFieldValue("GelarSebelum");
                LblNamaLengkap.Text = connM.GetFieldValue("NamaLengkap");
                LblGelarSesudah.Text = connM.GetFieldValue("GelarSesudah");
                LblJenisKelamin.Text = connM.GetFieldValue("JenisKelamin");
                LblTempatLahir.Text = connM.GetFieldValue("TempatLahir");
                LblTanggalLahir.Text = connM.GetFieldValue("TanggalLahir");
                LblNoIdentitas.Text = connM.GetFieldValue("NoIdentitas");
                LblAlamatRumah.Text = connM.GetFieldValue("AlamatRumah");
                LblPropinsiRumah.Text = connM.GetFieldValue("PropinsiRumah");
                LblKotaKabRumah.Text = connM.GetFieldValue("KotaKabRumah");
                LblKecamatanRumah.Text = connM.GetFieldValue("KecamatanRumah");
                LblKelurahanRumah.Text = connM.GetFieldValue("KelurahanRumah");
                LblKodePosRumah.Text = connM.GetFieldValue("KodePosRumah");
                LblTeleponRumah.Text = connM.GetFieldValue("TeleponRumah");
                LblTeleponGenggam.Text = connM.GetFieldValue("TeleponGenggam");
                LblNamaIbuKandung.Text = connM.GetFieldValue("NamaIbuKandung");
                LblPendidikan.Text = connM.GetFieldValue("Pendidikan");
                LblStatusPerkawinan.Text = connM.GetFieldValue("StatusPerkawinan");
                LblKewarganegaraan.Text = connM.GetFieldValue("Kewarganegaraan");
                LblStatusRumah.Text = connM.GetFieldValue("StatusRumah");
                LblJenisPekerjaan.Text = connM.GetFieldValue("JenisPekerjaan");
                LblPendapatan.Text = connM.GetFieldValue("Pendapatan");
                LblAlamatKantor.Text = connM.GetFieldValue("AlamatKantor");
                LblTeleponKantor.Text = connM.GetFieldValue("TeleponKantor");
                LblPropinsiKantor.Text = connM.GetFieldValue("PropinsiKantor");
                LblKotaKabKantor.Text = connM.GetFieldValue("KotaKabKantor");
                LblKodePosKantor.Text = connM.GetFieldValue("KodePosKantor");
                LblNamaSaudara.Text = connM.GetFieldValue("NamaSaudara");
                LblAlamatSaudara.Text = connM.GetFieldValue("AlamatSaudara");
                LblPropinsiSaudara.Text = connM.GetFieldValue("PropinsiSaudara");
                LblKotaKabSaudara.Text = connM.GetFieldValue("KotaKabSaudara");
                LblKodePosSaudara.Text = connM.GetFieldValue("KodePosSaudara");
                LblHubunganSaudara.Text = connM.GetFieldValue("HubunganSaudara");
                // TxtLosCuRef.Text = connM.GetFieldValue("LosCuRef");

            }
        }

        private void clearDetails()
        {
            LblId.Text = "";
            LblUserName.Text = "";
            LblGelarSebelum.Text = "";
            LblNamaLengkap.Text = "";
            LblGelarSesudah.Text = "";
            LblJenisKelamin.Text = "";
            LblTempatLahir.Text = "";
            LblTanggalLahir.Text = "";
            LblNoIdentitas.Text = "";
            LblAlamatRumah.Text = "";
            LblPropinsiRumah.Text = "";
            LblKotaKabRumah.Text = "";
            LblKecamatanRumah.Text = "";
            LblKelurahanRumah.Text = "";
            LblKodePosRumah.Text = "";
            LblTeleponRumah.Text = "";
            LblTeleponGenggam.Text = "";
            LblNamaIbuKandung.Text = "";
            LblPendidikan.Text = "";
            LblStatusPerkawinan.Text = "";
            LblKewarganegaraan.Text = "";
            LblStatusRumah.Text = "";
            LblJenisPekerjaan.Text = "";
            LblPendapatan.Text = "";
            LblAlamatKantor.Text = "";
            LblTeleponKantor.Text = "";
            LblPropinsiKantor.Text = "";
            LblKotaKabKantor.Text = "";
            LblKodePosKantor.Text = "";
            LblNamaSaudara.Text = "";
            LblAlamatSaudara.Text = "";
            LblPropinsiSaudara.Text = "";
            LblKotaKabSaudara.Text = "";
            LblKodePosSaudara.Text = "";
            LblHubunganSaudara.Text = "";
            TxtLosCuRef.Text = "";
        }

        private void viewUploads(string Id)
        {
            connM.QueryString = "select Id, NasabahId, FileName, Caption, " +
                "'../FileUpload/' + Filename as FileUrl " +
                "from NasabahUpload where NasabahId = " + Id;
            connM.ExecuteQuery();

            DataTable dt = new DataTable();
            dt = connM.GetDataTable().Copy();
            GridView2.DataSource = dt;
            try
            {
                GridView2.DataBind();
            }
            catch
            {
                GridView2.PageIndex = 0;
                GridView2.DataBind();
            }
        }

        private void clearUploads()
        {
            GridView2.DataSource = null;
            GridView2.DataBind();
        }

        protected void downloadFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }

        private void searchExisting()
        {
            string sqlquery = "select " +
                "c.CU_REF, c.CU_CIF, " +
                "c1.CU_FIRSTNAME + isnull(' ' + c1.CU_MIDDLENAME, '') + isnull(' ' + c1.CU_LASTNAME, '') as CU_NAME, " +
                "convert(varchar, c1.CU_DOB, 106) as CU_DOB, " +
                "ltrim(rtrim(c1.CU_IDCARDNUM)) as CU_IDCARDNUM, " +
                "c1.CU_ADDR1 + isnull(' ' + c1.CU_ADDR2, '') + isnull(' ' + c1.CU_ADDR3, '') as CU_ADDRESS, " +
                "c1.CU_CITY, r.CITYNAME " +
                "from CUSTOMER c " +
                "join CUST_PERSONAL c1 on c.CU_REF = c1.CU_REF " +
                "left join RFCITY r on c1.CU_CITY = r.CITYID " +
                "where 1 = 1 ";

            if (nama.Text != "")
            {
                sqlquery = sqlquery + "and (c1.CU_FIRSTNAME like '%" + nama.Text.Trim() + "%' " +
                    "or c1.CU_MIDDLENAME like '%" + nama.Text.Trim() + "%' " +
                    "or c1.CU_LASTNAME like '%" + nama.Text.Trim() + "%') ";
            }

            if (noktp.Text != "")
            {
                sqlquery = sqlquery + "and CU_IDCARDNUM = '" + noktp.Text.Trim() + "' ";
            }

            if (tanggal.Text != "")
            {
                sqlquery = sqlquery + "and convert(varchar, c1.CU_DOB, 23) = '" + tanggal.Text + "' ";
            }

            if (alamat.Text != "")
            {
                sqlquery = sqlquery + "and (c1.CU_ADDR1 like '%" + alamat.Text.Trim() + "%' " +
                    "or c1.CU_ADDR2 like '%" + alamat.Text.Trim() + "%' " +
                    "or c1.CU_ADDR3 like '%" + alamat.Text.Trim() + "%') ";
            }

            if (kota.SelectedValue != "")
            {
                sqlquery = sqlquery + "and c1.CU_CITY = '" + kota.SelectedValue + "' ";
            }

            conn.QueryString = sqlquery;
            conn.ExecuteQuery();

            DataTable dt = new DataTable();
            dt = conn.GetDataTable().Copy();
            GridView3.DataSource = dt;
            try
            {
                GridView3.DataBind();
            }
            catch
            {
                GridView3.PageIndex = 0;
                GridView3.DataBind();
            }
        }

        private void clearSearch()
        {
            noktp.Text = "";
            nama.Text = "";
            tanggal.Text = "";
            alamat.Text = "";
            kota.SelectedValue = "";
        }

        private void clearExisting()
        {
            GridView3.DataSource = null;
            GridView3.DataBind();
        }

        protected void ShowModal(string title, string body)
        {
            string script = "window.onload = function() { ShowModal('" + title + "', '" + body + "'); };";
            ClientScript.RegisterStartupScript(this.GetType(), "ShowModal", script, true);
        }

        protected void ShowAlert(string message)
        {
            string script = "alert('" + message + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "ShowAlert", script, true);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ListCustomerFromMobile();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "detail":
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView1.Rows[index];

                    viewDetails(row.Cells[0].Text);
                    viewUploads(row.Cells[0].Text);
                    
                    break;
                default:
                    break;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            searchExisting();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            clearSearch();
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            searchExisting();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // Process New Customer

            if (LblId.Text == "")
            {
                ShowAlert("Anda belum memilih customer. Pilih satu customer dari tabel, kemudian klik Detail.");
                return;
            }

            // Cek apakah No KTP sudah ada

            conn.QueryString = "select 1 from CUST_PERSONAL where ltrim(rtrim(CU_IDCARDNUM)) = '" + LblNoIdentitas.Text.Trim() + "'";
            conn.ExecuteQuery();

            if (conn.GetRowCount() > 0)
            {
                ShowAlert("No Identitas " + LblNoIdentitas.Text + " sudah ada. Proses ditolak. Gunakan Proses Sebagai Existing Customer.");
                return;
            }

            // Insert

            conn.QueryString = "exec GENERATE_ID '" + Session["BranchID"].ToString() + "', '1'";
            conn.ExecuteQuery();

            string newcuref = conn.GetFieldValue(0, 0);

            string sqlquery = "insert into CUSTOMER " +
                "(CU_REF, " +
                "CU_CUSTTYPEID, " +
                "CU_JNSNASABAH, " +
                "CU_RM, " +
                "CU_NETINCOME) " +
                "select " +
                "'" + newcuref + "', " +
                "'02', " +
                "'A', " +
                "'" + Session["UserID"].ToString() + "', " +
                "Pendapatan " +
                "from Nasabah where Id = " + LblId.Text ;

            try
            {
                conn.QueryString = sqlquery;
                conn.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }

            sqlquery = "insert into CUST_PERSONAL " +
                "(CU_REF, " +
                "CU_TITLEBEFORENAME, " +
                "CU_FIRSTNAME, " +
                "CU_SEX, " +
                "CU_POB, " +
                "CU_DOB, " +
                "CU_IDCARDNUM, " +
                "CU_ADDR1, " +
                "CU_ADDR2, " +
                "CU_CITY, " +
                "CU_ADDR3, " +
                "CU_ZIPCODE, " +
                "CU_PHNNUM, " +
                "CU_FAXNUM, " +
                "CU_MOTHER, " +
                "CU_EDUCATION, " +
                "CU_MARITAL, " +
                "CU_CITIZENSHIP, " +
                "CU_HOMESTA, " +
                "CU_JOBTITLE, " +
                "CU_NETINCOMEMM) " +
                "select " +
                "'" + newcuref + "', " +
                "GelarSebelum, " +
                "NamaLengkap, " +
                "JenisKelamin, " +
                "TempatLahir, " +
                "TanggalLahir, " +
                "NoIdentitas, " +
                "AlamatRumah, " +
                "PropinsiRumah, " +
                "KotaKabRumah, " +
                "c.Name, " +
                "KodePosRumah, " +
                "TeleponRumah, " +
                "TeleponGenggam, " +
                "NamaIbuKandung, " +
                "Pendidikan, " +
                "StatusPerkawinan, " +
                "Kewarganegaraan, " +
                "StatusRumah, " +
                "JenisPekerjaan, " +
                "Pendapatan " +
                "from Nasabah n " +
                "left join RefKecamatan c on n.KecamatanRumah = c.Id " +
                "where n.Id = " + LblId.Text;

            try
            {
                conn.QueryString = sqlquery;
                conn.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }

            try
            {
                connM.QueryString = "update Nasabah set LosCuRef = '" + newcuref + "' where Id = " + LblId.Text;
                connM.ExecuteNonQuery();

                ShowAlert("Success!.");

                ListCustomerFromMobile();
                clearDetails();
                clearUploads();
                clearSearch();
                clearExisting();
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            // Process Existing Customer

            if (LblId.Text == "")
            {
                ShowAlert("Anda belum memilih customer. Pilih satu customer dari tabel, kemudian klik Detail.");
                return;
            }

            if (TxtLosCuRef.Text.Trim() == "")
            {
                ShowAlert("Existing Cust Ref No harus diisi.");
                return;
            }

            conn.QueryString = "select 1 from CUST_PERSONAL where CU_REF = '" + TxtLosCuRef.Text + "'";
            conn.ExecuteQuery();

            if (conn.GetRowCount() == 0)
            {
                ShowAlert("Cust Ref No yang dimasukkan salah.");
                return;
            }

            // Update
            try
            {
                connM.QueryString = "update Nasabah set LosCuRef = '" + TxtLosCuRef.Text + "' where Id = " + LblId.Text;
                connM.ExecuteNonQuery();

                ShowAlert("Success!.");

                ListCustomerFromMobile();
                clearDetails();
                clearUploads();
                clearSearch();
                clearExisting();
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            viewUploads(LblId.Text);
        }
    }
}