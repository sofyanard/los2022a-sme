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
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.CustomerInfo
{
    public partial class SimulasiDSR : System.Web.UI.Page
    {
        protected Connection conn;
        protected Tools tool = new Tools();

        double limit, rate, angspokok, angsbunga, angsuran;
        int tenor;
        double income, maxangsuran, dscr;
        double jumlangspokok = 0, jumlangsbunga = 0, jumltotangsuran = 0;
        DataTable dt_cicilan;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = (Connection)Session["Connection"];

            if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
                Response.Redirect("../Restricted.aspx");

            if (!IsPostBack)
            {
                
            }

            ViewMenu();

            DocumentUpload1.WithReadExcel = false;
            DocumentUpload1.GroupTemplate = "SIMULASI_DSR";
        }

        private void ViewMenu()
        {
            string strtemp = "";
            try
            {
                //--- Membuat menu dari DATABASE
                conn.QueryString = "select * from SCREENMENU where menucode = '" + Request.QueryString["mc"] + "'";
                conn.ExecuteQuery();
                for (int i = 0; i < conn.GetRowCount(); i++)
                {
                    HyperLink t = new HyperLink();
                    t.Text = conn.GetFieldValue(i, 2);
                    t.Font.Bold = true;
                    if (conn.GetFieldValue(i, 3).Trim() != "")
                    {
                        if (conn.GetFieldValue(i, 3).IndexOf("mc=") >= 0)
                            strtemp = "regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"];
                        else strtemp = "regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&mc=" + Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"];
                    }
                    else
                    {
                        strtemp = "";
                        t.ForeColor = Color.Red;
                    }
                    t.NavigateUrl = conn.GetFieldValue(i, 3) + strtemp;
                    Menu.Controls.Add(t);
                    Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void Calculate()
        {
            if (RB_PLAFOND.Checked)
            {
                /* Berdasarkan Plafond */
                try { limit = double.Parse(TXT_PLAFOND.Text); }
                catch { limit = 0; }
                try { rate = double.Parse(TXT_SUKUBUNGA.Text) / 100.0; }
                catch { rate = 0; }
                try { tenor = int.Parse(TXT_JANGKAWAKTU.Text); }
                catch { tenor = 0; }

                try
                {
                    if (RDO_SIFATBUNGA.SelectedValue == "1") //Flat
                    {
                        angspokok = limit / tenor;

                        angsbunga = (limit * (rate / 12));

                        angsuran = angspokok + angsbunga;
                    }
                    else if (RDO_SIFATBUNGA.SelectedValue == "2") //Anuitas
                    {
                        double dangsuran;
                        //dangsuran = limit * (rate / 12) * (1 / (1 - (1 / (Math.Pow(1 + (rate / 12), tenor)))));
                        dangsuran = Financial.Pmt(rate / 12, tenor, -limit);

                        angsuran = float.Parse(dangsuran.ToString());
                    }
                    else
                    {
                        angsuran = 0;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<!--" + ex.Message + "-->");
                    angsuran = 0;
                }

                TXT_ANGSURAN.Text = tool.MoneyFormat(angsuran.ToString());
            }
            else if (RB_ANGSURAN.Checked)
            {
                /* Berdasarkan Angsuran */
                try { angsuran = double.Parse(TXT_ANGSURAN.Text); }
                catch { angsuran = 0; }
                try { rate = double.Parse(TXT_SUKUBUNGA.Text) / 100.0; }
                catch { rate = 0; }
                try { tenor = int.Parse(TXT_JANGKAWAKTU.Text); }
                catch { tenor = 0; }

                try
                {
                    if (RDO_SIFATBUNGA.SelectedValue == "1") //Flat
                    {
                        limit = ((1 - ((rate / 12) * tenor)) / 1) * angsuran * tenor;
                    }
                    else if (RDO_SIFATBUNGA.SelectedValue == "2") //Anuitas
                    {
                        double dlimit;
                        dlimit = Financial.PV(rate / 12, tenor, -angsuran);

                        limit = float.Parse(dlimit.ToString());
                    }
                    else
                    {
                        limit = 0;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<!--" + ex.Message + "-->");
                    limit = 0;
                }

                TXT_PLAFOND.Text = tool.MoneyFormat(limit.ToString());
            }



            HitungTabelCicilan1();
        }

        protected void HitungTabelCicilan1()
        {
            dt_cicilan = new DataTable();
            dt_cicilan.Rows.Add();
            dt_cicilan.Columns.Add("BULANKE");
            dt_cicilan.Columns.Add("ANGSURANPOKOK");
            dt_cicilan.Columns.Add("ANGSURANBUNGA");
            dt_cicilan.Columns.Add("TOTALANGSURAN");
            dt_cicilan.Columns.Add("SISAPINJAMAN");

            jumlangspokok = 0;
            jumlangsbunga = 0;
            jumltotangsuran = 0;

            double iapokok, iabunga, iatotal, ipsisa;

            iapokok = 0;
            iabunga = 0;
            iatotal = iapokok + iabunga;
            ipsisa = limit;

            jumlangspokok = jumlangspokok + iapokok;
            jumlangsbunga = jumlangsbunga + iabunga;
            jumltotangsuran = jumltotangsuran + iatotal;

            dt_cicilan.Rows[0]["BULANKE"] = 0;
            dt_cicilan.Rows[0]["ANGSURANPOKOK"] = iapokok;
            dt_cicilan.Rows[0]["ANGSURANBUNGA"] = iabunga;
            dt_cicilan.Rows[0]["TOTALANGSURAN"] = iatotal;
            dt_cicilan.Rows[0]["SISAPINJAMAN"] = ipsisa;

            for (int i = 1; i <= tenor; i++)
            {
                if (RDO_SIFATBUNGA.SelectedValue == "1") //Flat
                {
                    iapokok = limit / tenor;
                    if (iapokok > ipsisa)
                        iapokok = ipsisa;
                    iabunga = limit * (rate / 12);
                    iatotal = iapokok + iabunga;
                    ipsisa = ipsisa - iapokok;
                    if (ipsisa < 0)
                        ipsisa = 0.0;
                }
                else if (RDO_SIFATBUNGA.SelectedValue == "2") //Anuitas
                {
                    iapokok = Financial.PPmt(rate / 12, i, tenor, -limit);
                    if (iapokok > ipsisa)
                        iapokok = ipsisa;
                    iabunga = Financial.IPmt(rate / 12, i, tenor, -limit);
                    iatotal = iapokok + iabunga;
                    ipsisa = ipsisa - iapokok;
                    if (ipsisa < 0)
                        ipsisa = 0.0;
                }
                else
                {
                    return;
                }

                jumlangspokok = jumlangspokok + iapokok;
                jumlangsbunga = jumlangsbunga + iabunga;
                jumltotangsuran = jumltotangsuran + iatotal;

                dt_cicilan.Rows.Add();
                dt_cicilan.Rows[i]["BULANKE"] = i;
                dt_cicilan.Rows[i]["ANGSURANPOKOK"] = iapokok;
                dt_cicilan.Rows[i]["ANGSURANBUNGA"] = iabunga;
                dt_cicilan.Rows[i]["TOTALANGSURAN"] = iatotal;
                dt_cicilan.Rows[i]["SISAPINJAMAN"] = ipsisa;
            }

            BindTabelCicilan1();
        }

        protected void BindTabelCicilan1()
        {
            DG_CICILAN.DataSource = dt_cicilan;
            try
            {
                DG_CICILAN.DataBind();
            }
            catch
            {
                DG_CICILAN.PageIndex = 0;
                DG_CICILAN.DataBind();
            }
        }

        protected void BTN_CALCULATE_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        protected void DG_CICILAN_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string a = e.Row.Cells[1].Text;
                e.Row.Cells[1].Text = double.Parse(a).ToString("#,#0.00");

                string b = e.Row.Cells[2].Text;
                e.Row.Cells[2].Text = double.Parse(b).ToString("#,#0.00");

                string c = e.Row.Cells[3].Text;
                e.Row.Cells[3].Text = double.Parse(c).ToString("#,#0.00");

                string d = e.Row.Cells[4].Text;
                e.Row.Cells[4].Text = double.Parse(d).ToString("#,#0.00");
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "JUMLAH";
                e.Row.Cells[1].Text = jumlangspokok.ToString("#,#0.00");
                e.Row.Cells[2].Text = jumlangsbunga.ToString("#,#0.00");
                e.Row.Cells[3].Text = jumltotangsuran.ToString("#,#0.00");
            }
        }

        protected void DG_CICILAN_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DG_CICILAN.PageIndex = e.NewPageIndex;
            Calculate();
        }

        protected void RB_PLAFOND_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_PLAFOND.Checked)
            {
                TXT_PLAFOND.Enabled = true;
                TXT_PLAFOND.Text = "";

                TXT_ANGSURAN.Enabled = false;
                TXT_ANGSURAN.Text = "";
            }
        }

        protected void RB_ANGSURAN_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_ANGSURAN.Checked)
            {
                TXT_ANGSURAN.Enabled = true;
                TXT_ANGSURAN.Text = "";

                TXT_PLAFOND.Enabled = false;
                TXT_PLAFOND.Text = "";
            }
        }
    }
}