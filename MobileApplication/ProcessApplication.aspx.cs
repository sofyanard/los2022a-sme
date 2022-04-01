using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.IO;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.MobileApplication
{
    public partial class ProcessApplication : System.Web.UI.Page
    {
        protected Tools tools = new Tools();
        protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
                Response.Redirect("../Restricted.aspx");

            if (!IsPostBack)
            {
                ListApplication();
            }
        }

        private void ListApplication()
        {
            conn.QueryString = "select " +
                "p.Id, " +
                "p.NasabahId, " +
                "n.NamaLengkap, " +
                "p.Product , f.PRODUCTDESC, " +
                "p.Limit, " +
                "p.Tenor, " +
                "p.CollateralType, c.COLTYPEDESC " +
                "from Nasabah n " +
                "join Pengajuan p on n.Id = p.NasabahId " +
                "join CUSTOMER n2 on n.LosCuRef = n2.CU_REF " +
                "join RFPRODUCT f on p.Product = f.PRODUCTID " +
                "left join RFCOLLATERALTYPE c on p.CollateralType = c.COLTYPESEQ " +
                "where isnull(p.LosApRegno,'') not in (select AP_REGNO from APPTRACK) " +
                "and p.BranchCode = '" + Session["BranchID"].ToString() + "'";
            conn.ExecuteQuery();

            DataTable dt = new DataTable();
            dt = conn.GetDataTable().Copy();
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

        private void DetailApplication(string PengajuanId)
        {
            conn.QueryString = "select " +
                "p.NasabahId, " +
                "n.UserName, " +
                "n.LosCuRef, " +
                "n.NamaLengkap, " +
                "n.JenisKelamin, " +
                "convert(varchar, n.TanggalLahir, 105) as TanggalLahir, " +
                "n.NoIdentitas, " +
                "n.AlamatRumah, " +
                "n.KotaKabRumah, k.Name as KotaKabRumahDesc, " +
                "p.Id, " +
                "p.Product, f.PRODUCTDESC, " +
                "p.Limit, " +
                "p.Tenor, " +
                "p.Purpose, l.LOANPURPDESC, " +
                "p.CollateralFlag, " +
                "p.CollateralType, c.COLTYPEDESC, " +
                "p.CollateralValue, " +
                "p.CertificateType, s.CERTTYPEDESC, " +
                "p.CertificateNo " +
                "from Nasabah n " +
                "join Pengajuan p on n.Id = p.NasabahId " +
                "left join RefKotaKab k on n.KotaKabRumah = k.Id " +
                "left join RFPRODUCT f on p.Product = f.PRODUCTID " +
                "left join RFLOANPURPOSE l on p.Purpose = l.LOANPURPID " +
                "left join RFCOLLATERALTYPE c on p.CollateralType = c.COLTYPESEQ " +
                "left join RFCERTTYPE s on p.CertificateType = s.CERTTYPEID " +
                "where p.Id = " + PengajuanId;
            conn.ExecuteQuery();

            clearDetails();

            if (conn.GetRowCount() > 0)
            {
                LblNasabahId.Text = conn.GetFieldValue("NasabahId");
                LblUserName.Text = conn.GetFieldValue("UserName");
                LblLosCuRef.Text = conn.GetFieldValue("LosCuRef");
                LblNamaLengkap.Text = conn.GetFieldValue("NamaLengkap");
                LblJenisKelamin.Text = conn.GetFieldValue("JenisKelamin");
                LblTanggalLahir.Text = conn.GetFieldValue("TanggalLahir");
                LblNoIdentitas.Text = conn.GetFieldValue("NoIdentitas");
                LblAlamatRumah.Text = conn.GetFieldValue("AlamatRumah");
                LblKotaKabRumah.Text = conn.GetFieldValue("KotaKabRumahDesc");
                LblId.Text = conn.GetFieldValue("Id");
                LblProduct.Text = conn.GetFieldValue("PRODUCTDESC");
                LblLimit.Text = conn.GetFieldValue("Limit");
                LblTenor.Text = conn.GetFieldValue("Tenor");
                LblPurpose.Text = conn.GetFieldValue("LOANPURPDESC");
                LblCollateralFlag.Text = conn.GetFieldValue("CollateralFlag");
                LblCollateralType.Text = conn.GetFieldValue("COLTYPEDESC");
                LblCollateralValue.Text = conn.GetFieldValue("CollateralValue");
                LblCertificateType.Text = conn.GetFieldValue("CERTTYPEDESC");
                LblCertificateNo.Text = conn.GetFieldValue("CertificateNo");
            }
        }

        private void clearDetails()
        {
            LblNasabahId.Text = "";
            LblUserName.Text = "";
            LblLosCuRef.Text = "";
            LblNamaLengkap.Text = "";
            LblJenisKelamin.Text = "";
            LblTanggalLahir.Text = "";
            LblNoIdentitas.Text = "";
            LblAlamatRumah.Text = "";
            LblKotaKabRumah.Text = "";
            LblId.Text = "";
            LblProduct.Text = "";
            LblLimit.Text = "";
            LblTenor.Text = "";
            LblPurpose.Text = "";
            LblCollateralFlag.Text = "";
            LblCollateralType.Text = "";
            LblCollateralValue.Text = "";
            LblCertificateType.Text = "";
            LblCertificateNo.Text = "";
        }

        private void viewUploads(string nasabahId)
        {
            conn.QueryString = "select Id, NasabahId, FileName, Caption, " +
                "'../FileUpload/' + Filename as FileUrl " +
                "from NasabahUpload where NasabahId = " + nasabahId;
            conn.ExecuteQuery();

            DataTable dt = new DataTable();
            dt = conn.GetDataTable().Copy();
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

        private void ApplicationProcess()
        {
            if ((LblNasabahId.Text == "") || ((LblId.Text == "")))
            {
                ShowAlert("Anda belum memilih aplikasi. Pilih satu aplikasi dari tabel, kemudian klik Detail.");
                return;
            }

            try
            {
                // Get Application Number
                conn.QueryString = "exec GENERATE_ID '" + Session["BranchID"].ToString() + "', '0'";
                conn.ExecuteQuery();
                string regno = conn.GetFieldValue(0, 0);

                // Update Application No to Tabel Pengajuan
                conn.QueryString = "update Pengajuan set LosApRegno = '" + regno + "' where Id = " + LblId.Text;
                conn.ExecuteNonQuery();

                // Insert Document to Application Document Table
                conn.QueryString = "select * from NasabahUpload where NasabahId = " + LblNasabahId.Text;
                conn.ExecuteQuery();
                DataTable dtDoc = new DataTable();
                dtDoc = conn.GetDataTable().Copy();
                conn.QueryString = "select isnull(max(SEQ),0) from DOCUPLOAD_FILEUPLOAD where AP_REGNO = '" + regno + "'";
                conn.ExecuteQuery();
                int lastseq = int.Parse(conn.GetFieldValue(0, 0));
                lastseq = lastseq + 1;
                foreach (DataRow row in dtDoc.Rows)
                {
                    conn.QueryString = "insert into DOCUPLOAD_FILEUPLOAD (AP_REGNO, GROUPFILE, SEQ, FU_FILENAME, FU_DATE, FU_USERID) values " +
                        "('" + regno + "', 'DOCUPLOAD', " + lastseq + ", '" + row["FileName"] + "', getdate(), '" + Session["UserID"].ToString() + "')";
                    conn.ExecuteNonQuery();
                    lastseq = lastseq + 1;
                }

                Response.Redirect("../InitialDataEntry/GeneralInfo.aspx?regno=" + regno + "&curef=" + LblLosCuRef.Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&exist=1");
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
                return;
            }
        }

        protected void ShowAlert(string message)
        {
            string script = "alert('" + message + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "ShowAlert", script, true);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ListApplication();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "detail":
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView1.Rows[index];

                    DetailApplication(row.Cells[0].Text);
                    viewUploads(row.Cells[1].Text);

                    break;
                default:
                    break;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ApplicationProcess();
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            viewUploads(LblNasabahId.Text);
        }
    }
}