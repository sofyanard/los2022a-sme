using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.InitialDataEntry
{
    public partial class MobileApplicationInfo : System.Web.UI.Page
    {
        protected Tools tools = new Tools();
        protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            DetailApplication(Request.QueryString["regno"]);
        }

        private void DetailApplication(string regno)
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
                "where p.LosApRegno = '" + regno + "'";
            conn.ExecuteQuery();

            if (conn.GetRowCount() > 0)
            {
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
    }
}