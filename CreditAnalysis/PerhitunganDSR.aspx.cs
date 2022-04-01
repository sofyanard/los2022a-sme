using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;

namespace SME.CreditAnalysis
{
    public partial class PerhitunganDSR : System.Web.UI.Page
    {
        protected Tools tool = new Tools();
        protected Connection conn;
        private float x_limit, x_bunga, x_sisapendapatan;
        private int x_tenor;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = (Connection)Session["Connection"];

            if (!IsPostBack)
            {
                conn.QueryString = "SELECT ITYPEID, ITYPEDESC FROM RFINTERESTTYPE";
                conn.ExecuteQuery();
                for (int i = 0; i < conn.GetRowCount(); i++)
                    DDL_SIFATBUNGA.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
                
                ViewData();
            }

            DocumentUpload1.WithReadExcel = false;
            DocumentUpload1.GroupTemplate = "ANALISA_DSR";
        }

        private void ViewData()
        {
            conn.QueryString = "SELECT TOP 1 A.APPTYPE, A.PRODUCTID, A.PROD_SEQ, A.CP_LIMIT, A.CP_JANGKAWKT, A.CP_INTEREST, " +
                                "B.INTERESTTYPE, B.DSCR, B.ANGSURAN, B.MAXANGSURAN, B.REKOMENDASILIMIT, C.SV_OFC_INCOME_MARGIN " +
                                "FROM CUSTPRODUCT A " +
                                "LEFT JOIN APPDSR B ON A.AP_REGNO = B.AP_REGNO AND A.APPTYPE = B.APPTYPE AND A.PRODUCTID = B.PRODUCTID AND A.PROD_SEQ = B.PROD_SEQ " +
                                "LEFT JOIN CUST_SITEVISIT C ON A.AP_REGNO = C.AP_REGNO " +
                                "WHERE A.AP_REGNO = '" + Request.QueryString["regno"] + "' ORDER BY PROD_SEQ DESC";
            conn.ExecuteQuery();

            if (conn.GetRowCount() > 0)
            {
                TXT_AP_REGNO_X.Text = Request.QueryString["regno"];
                TXT_APPTYPE_X.Text = conn.GetFieldValue("APPTYPE");
                TXT_PRODUCTID_X.Text = conn.GetFieldValue("PRODUCTID");
                TXT_PROD_SEQ_X.Text = conn.GetFieldValue("PROD_SEQ");

                try { x_limit = float.Parse(conn.GetFieldValue("CP_LIMIT")); }
                catch { x_limit = 0; }
                try { x_tenor = int.Parse(conn.GetFieldValue("CP_JANGKAWKT")); }
                catch { x_tenor = 0; }
                try { x_bunga = float.Parse(conn.GetFieldValue("CP_INTEREST")); }
                catch { x_bunga = 0; }

                TXT_PLAFOND.Text = tool.MoneyFormat(x_limit.ToString());
                TXT_JANGKAWAKTU.Text = x_tenor.ToString();
                TXT_SUKUBUNGA.Text = x_bunga.ToString();

                TXT_SISAPENDAPATAN_X.Text = conn.GetFieldValue("SV_OFC_INCOME_MARGIN");
                try { x_sisapendapatan = float.Parse(TXT_SISAPENDAPATAN_X.Text); }
                catch { x_sisapendapatan = 0; }

                TXT_SISAPENDAPATAN.Text = tool.MoneyFormat(x_sisapendapatan.ToString());

                try { DDL_SIFATBUNGA.SelectedValue = conn.GetFieldValue("INTERESTTYPE"); }
                catch { }
                TXT_DSCR.Text = conn.GetFieldValue("DSCR");
                TXT_ANGSURAN.Text = tool.MoneyFormat(conn.GetFieldValue("ANGSURAN"));
                TXT_MAXANGSURAN.Text = tool.MoneyFormat(conn.GetFieldValue("MAXANGSURAN"));
                TXT_REKOMENDASILIMIT.Text = tool.MoneyFormat(conn.GetFieldValue("REKOMENDASILIMIT"));
            }
        }

        private void Calculate()
        {
            /*
            if (TXT_PLAFOND.Text.ToString() == "");
            {
                GlobalTools.popMessage(this, "Plafond tidak boleh kosong!");
                return;
            }

            if (TXT_JANGKAWAKTU.Text.ToString() == "") ;
            {
                GlobalTools.popMessage(this, "Jangka Waktu tidak boleh kosong!");
                return;
            }

            if (TXT_SUKUBUNGA.Text.ToString() == "") ;
            {
                GlobalTools.popMessage(this, "Suku Bunga tidak boleh kosong!");
                return;
            }

            if (TXT_SISAPENDAPATAN.Text.ToString() == "") ;
            {
                GlobalTools.popMessage(this, "Sisa Pendapatan tidak boleh kosong!");
                return;
            }

            if (RDO_SIFATBUNGA.SelectedValue.ToString() == "") ;
            {
                GlobalTools.popMessage(this, "Sifat Bunga harus dipilih!");
                return;
            }

            if (TXT_DSCR.Text.ToString() == "") ;
            {
                GlobalTools.popMessage(this, "DSCR harus diisi!");
                return;
            }
            */

            try
            {
                x_sisapendapatan = float.Parse(TXT_SISAPENDAPATAN_X.Text);

                float limit = x_limit;
                int tenor = x_tenor;
                float rate = x_bunga;
                float angsuran, pokok, bunga;
                float dscr;
                try { dscr = float.Parse(TXT_DSCR.Text) / 100; }
                catch { dscr = 0; }
                float sisa_pendapatan = x_sisapendapatan;
                float max_angsuran, rec_limit;

                /*
                if (RDO_SIFATBUNGA.SelectedValue == "1") //Flat
                {
                    pokok = limit / tenor;

                    bunga = (limit * rate) / 12;

                    angsuran = pokok + bunga;
                }
                else if (RDO_SIFATBUNGA.SelectedValue == "2") //Anuitas
                {
                    double dangsuran;
                    dangsuran = limit * (rate / 12) * (1 / (1 - (1 / (Math.Pow(1 + (rate / 12), tenor)))));

                    angsuran = float.Parse(dangsuran.ToString());
                }
                else
                {
                    angsuran = 0;
                }
                */

                try { max_angsuran = sisa_pendapatan * dscr; }
                catch { max_angsuran = 0; }

                //rec_limit = (limit / tenor) + (limit * rate);

                //LBL_ANGSURAN.Text = tool.MoneyFormat(angsuran.ToString());
                TXT_MAXANGSURAN.Text = tool.MoneyFormat(max_angsuran.ToString());
                //LBL_REKOMENDASILIMIT.Text = tool.MoneyFormat(rec_limit.ToString());
            }
            catch (Exception ex)
            {
                string errmsg = ex.Message.Replace("'", "");
                if (errmsg.IndexOf("Last Query:") > 0)
                    errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
                GlobalTools.popMessage(this, errmsg);
                return;
            }
        }

        private void SaveData()
        {
            try
            {
                conn.QueryString = "EXEC PERHITUNGAN_DSR_SAVE '" +
                    Request.QueryString["regno"] + "', '" +
                    TXT_APPTYPE_X.Text + "', '" +
                    TXT_PRODUCTID_X.Text + "', '" +
                    TXT_PROD_SEQ_X.Text + "', '" +
                    DDL_SIFATBUNGA.SelectedValue + "', '" +
                    TXT_DSCR.Text + "', '" +
                    tool.ConvertFloat(TXT_ANGSURAN.Text) + "', '" +
                    tool.ConvertFloat(TXT_MAXANGSURAN.Text) + "', '" +
                    tool.ConvertFloat(TXT_REKOMENDASILIMIT.Text) + "'";
                conn.ExecuteNonQuery();

                GlobalTools.popMessage(this, "Data berhasil disimpan");
                ViewData();
            }
            catch (Exception ex)
            {
                string errmsg = ex.Message.Replace("'", "");
                if (errmsg.IndexOf("Last Query:") > 0)
                    errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
                GlobalTools.popMessage(this, errmsg);
                return;
            }
        }

        protected void BTN_SAVE_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        protected void BTN_CALCULATE_Click(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}