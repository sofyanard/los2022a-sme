using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Drawing;
using System.Globalization;
using Microsoft.VisualBasic;
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.InitialDataEntry
{
    public partial class PermohonanBaru2 : System.Web.UI.Page
    {
        protected Tools tool = new Tools();
        protected Connection conn;
        protected DataTable dtColl;
        protected string alihdeb;
        protected string APPTYPE, PROG, REGNO, CUREF, TC, MC, PROD, KET_CODE, view;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = (Connection)Session["Connection"];

            APPTYPE = Request.QueryString["app"];
            PROG = Request.QueryString["prog"];
            PROD = Request.QueryString["prod"];
            REGNO = Request.QueryString["regno"];
            CUREF = Request.QueryString["curef"];
            KET_CODE = Request.QueryString["ket_code"];
            TC = Request.QueryString["tc"];
            MC = Request.QueryString["mc"];
            view = Request.QueryString["view"];

            //if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
            //	Response.Redirect("/SME/Restricted.aspx");

            cekIsView(view);

            if (!IsPostBack)
            {
                viewExchangeRate();

                LBL_MAINREGNO.Text = Request.QueryString["mainregno"];		//optional!, berasal dari sub app (DE)
                LBL_MAINPROD_SEQ.Text = Request.QueryString["mainprod_seq"];	//optional!, berasal dari sub app (DE)
                LBL_MAINPRODUCTID.Text = Request.QueryString["mainproductid"];	//idem

                LBL_USERID.Text = Session["UserID"].ToString();

                //--- Application Type
                conn.QueryString = "select apptypeid, apptypedesc from rfapplicationtype where active='1'";
                conn.ExecuteQuery();
                for (int i = 0; i < conn.GetRowCount(); i++)
                    DDL_APPTYPE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

                //--- Product
                DDL_PRODUCTID.Items.Add(new ListItem("- PILIH -", ""));
                //===KALAU PUNYA MAINREGNO, BERARTI PAGE INI DIPANGGIL OLEH SUBAPP (DE)===//
                if (LBL_MAINREGNO.Text != "" && LBL_MAINREGNO.Text != null)
                {
                    conn.QueryString = "select PRODUCTID, PRODUCTDESC from VW_PROGPROD where PROGRAMID='" + Request.QueryString["prog"] + "' and ACTIVE='1' and ISSUBAPPPROD = '1'";

                    // untuk sub application, tidak ada earmarking
                    DDL_PROJECT_CODE.Enabled = false;
                }
                else
                {
                    conn.QueryString = "select PRODUCTID, PRODUCTDESC from VW_PROGPROD where PROGRAMID='" + Request.QueryString["prog"] + "' and ACTIVE='1'";
                }
                conn.ExecuteQuery();
                for (int i = 0; i < conn.GetRowCount(); i++)
                    DDL_PRODUCTID.Items.Add(new ListItem(conn.GetFieldValue(i, 0) + " - " + conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

                try { DDL_APPTYPE.SelectedValue = Request.QueryString["app"]; }
                catch { DDL_APPTYPE.SelectedValue = ""; }
                try { DDL_PRODUCTID.SelectedValue = Request.QueryString["prod"]; }
                catch { DDL_PRODUCTID.SelectedValue = ""; }

                //--- Tenor
                DDL_CP_TENORCODE.Items.Add(new ListItem("- PILIH -", ""));
                conn.QueryString = "select tenorcode, tenordesc from rftenorcode where active='1'";
                conn.ExecuteQuery();
                for (int i = 0; i < conn.GetRowCount(); i++)
                    DDL_CP_TENORCODE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
                try
                {
                    DDL_CP_TENORCODE.SelectedValue = "M";
                }
                catch { }

                //--- Loan Purpose
                DDL_CP_LOANPURPOSE.Items.Add(new ListItem("- PILIH -", ""));
                conn.QueryString = "select LOANPURPID, LOANPURPID + ' - ' + LOANPURPDESC as LOANPURPDESC from RFLOANPURPOSE where ACTIVE='1' order by LOANPURPID";
                conn.ExecuteQuery();
                for (int i = 0; i < conn.GetRowCount(); i++)
                    DDL_CP_LOANPURPOSE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

                GlobalTools.fillRefList(DDL_PROJECT_CODE, "select * from VW_RFPROJECT where ACTIVE = '1'", false, conn);

                //--- Jenis Jaminan
                DDL_CL_TYPE.Items.Add(new ListItem("- PILIH -", ""));
                conn.QueryString = "select COLTYPESEQ, COLTYPEID + ' - ' + COLTYPEDESC as COLTYPEDESC from RFCOLLATERALTYPE where ACTIVE='1' order by COLTYPEID";
                conn.ExecuteQuery();
                for (int i = 0; i < conn.GetRowCount(); i++)
                    DDL_CL_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

                //--- Currency
                DDL_CL_CURRENCY.Items.Add(new ListItem("- PILIH -", ""));
                //conn.QueryString = "select currencyid, currencyid+' - '+currencydesc from rfcurrency where active='1' order by currencyid";
                conn.QueryString = "select currencyid, currencydesc from rfcurrency where active='1' order by currencyid";
                conn.ExecuteQuery();
                for (int i = 0; i < conn.GetRowCount(); i++)
                    DDL_CL_CURRENCY.Items.Add(new ListItem(conn.GetFieldValue(i, 0) + " - " + conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
                try
                {
                    DDL_CL_CURRENCY.SelectedValue = "IDR";
                }
                catch { }

                //--- Klasifikasi Jaminan
                DDL_CL_COLCLASSIFY.Items.Add(new ListItem("- PILIH -", ""));
                conn.QueryString = "select colclassid, colclassdesc from rfcollclass where active='1'";
                conn.ExecuteQuery();
                for (int i = 0; i < conn.GetRowCount(); i++)
                    DDL_CL_COLCLASSIFY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

                DDL_CL_TYPE_EXISTING.Items.Add(new ListItem("- PILIH -", "0"));

                //--- Bukti Kepemilikan
                DDL_BUKTI_KEPEMILIKAN.Items.Add(new ListItem("- PILIH -", ""));
                conn.QueryString = "SELECT CERTTYPEID, CERTTYPEDESC FROM RFCERTTYPE WHERE ACTIVE = '1' ORDER BY CERTTYPEDESC";
                conn.ExecuteQuery();
                for (int i = 0; i < conn.GetRowCount(); i++)
                    DDL_BUKTI_KEPEMILIKAN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

                //--- Bentuk Pengikatan
                DDL_BENTUK_PENGIKATAN.Items.Add(new ListItem("- PILIH -", ""));
                conn.QueryString = "SELECT IKATID, IKATDESC FROM RFIKAT WHERE ACTIVE = '1' ORDER BY IKATID";
                conn.ExecuteQuery();
                for (int i = 0; i < conn.GetRowCount(); i++)
                    DDL_BENTUK_PENGIKATAN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

                //--- Tanggal Penilaian
                DDL_TGLPENILAIAN_MONTH.Items.Add(new ListItem("- PILIH -", ""));
                for (int i = 1; i <= 12; i++)
                {
                    DDL_TGLPENILAIAN_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
                }

                //--- Penilaian Oleh
                DDL_PENILAI_OLEH.Items.Add(new ListItem("- PILIH -", ""));
                conn.QueryString = "select ACCRDTOID, ACCRDTODESC from RFVALUEACCORDING where active='1'";
                conn.ExecuteQuery();
                for (int i = 0; i < conn.GetRowCount(); i++)
                    DDL_PENILAI_OLEH.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

                dtColl = (DataTable)Session["dataTable"];
                try
                {
                    if (dtColl.Rows.Count > 0)
                        ViewCollateral();
                }
                catch
                {
                    dtColl = new DataTable();
                    dtColl.Columns.Add(new DataColumn("CL_SEQ"));
                    dtColl.Columns.Add(new DataColumn("COLTYPEID"));
                    dtColl.Columns.Add(new DataColumn("COLTYPEDESC"));
                    dtColl.Columns.Add(new DataColumn("CL_DESC"));
                    dtColl.Columns.Add(new DataColumn("CL_CERTTYPE1"));
                    dtColl.Columns.Add(new DataColumn("CL_CERTTYPE1DESC"));
                    dtColl.Columns.Add(new DataColumn("CL_IKATID"));
                    dtColl.Columns.Add(new DataColumn("CL_IKATIDDESC"));
                    dtColl.Columns.Add(new DataColumn("CL_VALUE2"));
                    dtColl.Columns.Add(new DataColumn("CL_VALUE"));
                    dtColl.Columns.Add(new DataColumn("CL_VALUEINS"));
                    dtColl.Columns.Add(new DataColumn("CL_VALUEIKAT"));
                    dtColl.Columns.Add(new DataColumn("CL_VALUEPPA"));
                    dtColl.Columns.Add(new DataColumn("CL_VALUELIQ"));
                    dtColl.Columns.Add(new DataColumn("LC_PERCENTAGE"));
                    dtColl.Columns.Add(new DataColumn("ISNEW"));
                    dtColl.Columns.Add(new DataColumn("CL_CURRENCY"));
                    dtColl.Columns.Add(new DataColumn("CL_COLCLASSIFY"));
                    dtColl.Columns.Add(new DataColumn("CL_FOREIGNVAL2"));
                    dtColl.Columns.Add(new DataColumn("CL_FOREIGNVAL"));
                    dtColl.Columns.Add(new DataColumn("CL_FOREIGNVALINS"));
                    dtColl.Columns.Add(new DataColumn("CL_FOREIGNVALIKAT"));
                    dtColl.Columns.Add(new DataColumn("CL_FOREIGNVALPPA"));
                    dtColl.Columns.Add(new DataColumn("CL_FOREIGNVALLIQ"));
                    dtColl.Columns.Add(new DataColumn("CL_EXCHANGERATE"));
                    dtColl.Columns.Add(new DataColumn("CL_PENILAIANDATE"));
                    dtColl.Columns.Add(new DataColumn("CL_PENILAIANBY"));
                    dtColl.Columns.Add(new DataColumn("SIBS_COLID"));
                    Session.Add("dataTable", dtColl);
                    ViewCollateral();
                }

                conn.QueryString = "select isnull(max(cl_seq),0) from collateral where cu_ref='" + Request.QueryString["curef"] + "'";
                conn.ExecuteQuery();
                LBL_SEQ.Text = conn.GetFieldValue(0, 0);

                conn.QueryString = "select cl_seq, cl_desc, cl_utilization, cl_apprvalue, sibs_colid " +
                    "from collateral where cu_ref='" + Request.QueryString["curef"] + "' " +
                    "and ((sibs_colid is not null and sibs_colid <> '') or cl_seq in (select cl_seq from " +
                    "listcollateral where ap_regno = '" + Request.QueryString["regno"] + "'))";
                conn.ExecuteQuery();
                for (int i = 0; i < conn.GetRowCount(); i++)
                    DDL_CL_TYPE_EXISTING.Items.Add(new ListItem(conn.GetFieldValue(i, 1) + " [" + conn.GetFieldValue(i, "sibs_colid") + "]", conn.GetFieldValue(i, 0)));

                //ViewCollateral();
                ViewApplications();

                conn.QueryString = "select withdrawl from rfprogram where programid='" + Request.QueryString["prog"] + "'";
                conn.ExecuteQuery();
                if (conn.GetRowCount() > 0 && conn.GetFieldValue(0, 0) == "0")
                    DDL_APPTYPE.Items.Remove(DDL_APPTYPE.Items.FindByValue("06"));

                //-- Yudi
                //Untuk kebutuhan KETENTUAN KREDIT, kalau permohonan baru dalam satu ketentuan kredit
                //tidak bisa bergabung dengan jenis pengajuan lain.				
                DDL_APPTYPE.Enabled = false;

                //20070725 add by sofyan for alih debitur
                alihdeb = "0";
                TR_OLDCIFNO.Visible = false;
                TR_OLDACCNO.Visible = false;
            }

            if (RDO_COLLATERAL.SelectedValue == "1")
            {
                DDL_CL_TYPE.Visible = true;
                DDL_CL_TYPE.CssClass = "mandatoryColl";
                DDL_CL_TYPE_EXISTING.Visible = false;
                DDL_CL_TYPE_EXISTING.CssClass = "";
                TXT_CL_DESC.ReadOnly = false;
                DDL_CL_CURRENCY.Enabled = true;
                Label1.Text = "Jenis Jaminan";
                Label2.Text = "Keterangan";
                LBL_SISAUTILIZATION.Text = "100";
                DDL_CL_TYPE_EXISTING.SelectedValue = "0";
            }
            else
            {
                DDL_CL_TYPE.Visible = false;
                DDL_CL_TYPE.CssClass = "";
                DDL_CL_TYPE_EXISTING.Visible = true;
                DDL_CL_TYPE_EXISTING.CssClass = "mandatoryColl";
                TXT_CL_DESC.ReadOnly = true;
                DDL_CL_CURRENCY.Enabled = false;
                Label1.Text = "Keterangan";
                Label2.Text = "Jenis Jaminan";
            }
            ViewMenu();
            BTN_INSCOLL.Attributes.Add("onclick", "if(!cek_mandatoryColl(document.getElementById('Form1'))){return false;};");
            //BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
            BTN_SAVE.Attributes.Add("onclick", "if(!cek_mandatory(document.getElementById('Form1'))){return false;};if(!SaveMsg()){return false;};");
            Button1.Attributes.Add("onclick", "if(!update()){return false;};");

            //PUNDI
            setDefault();

            TXT_CL_VALUE.Attributes.Add("readonly", "readonly");
            TXT_CL_VALUE2.Attributes.Add("readonly", "readonly");
            TXT_CL_VALUEINS.Attributes.Add("readonly", "readonly");
            TXT_CL_VALUEIKAT.Attributes.Add("readonly", "readonly");
            TXT_CL_VALUEPPA.Attributes.Add("readonly", "readonly");
            TXT_CL_VALUELIQ.Attributes.Add("readonly", "readonly");
        }

        private void setDefault()
        {
            TXT_CP_EXRPLIMIT.Text = "1";
            TXT_CP_EXRPLIMIT.Enabled = true;
            TXT_CP_LIMIT.Enabled = true;
        }

        private void cekIsView(string view)
        {
            if (view == "1")
            {
                TR_JENISPENGAJUAN.Visible = false;
                TR_COLL.Visible = false;
                TR_BUTTONS.Visible = false;
            }
        }

        private void viewExchangeRate()
        {
            try
            {
                conn.QueryString = "select PRODUCTID, CURRENCY, C.CURRENCYRATE " +
                    "from RFPRODUCT p " +
                    "left join RFCURRENCY c on P.CURRENCY = C.CURRENCYID " +
                    "where C.ACTIVE = '1' and P.ACTIVE = '1' and PRODUCTID = '" + Request.QueryString["prod"] + "'";
                conn.ExecuteQuery();

                TXT_CP_EXRPLIMIT.Text = conn.GetFieldValue("CURRENCYRATE");
            }
            catch (NullReferenceException)
            {
                Tools.popMessage(this, "Connection Error !");
                return;
            }
        }

        private void ViewCollateral()
        {
            double nilaiAkhir = 0;

            dtColl = (DataTable)Session["dataTable"];
            DatGrd.DataSource = dtColl;
            DatGrd.DataBind();

            try
            {
                for (int i = 0; i < DatGrd.Items.Count; i++)
                {
                    nilaiAkhir = double.Parse(DatGrd.Items[i].Cells[9].Text) * double.Parse(DatGrd.Items[i].Cells[14].Text) / 100;
                    DatGrd.Items[i].Cells[15].Text = tool.MoneyFormat(nilaiAkhir.ToString());
                }
            }
            catch (Exception ex1)
            {
                for (int i = 0; i < DatGrd.Items.Count; i++)
                {
                    nilaiAkhir = 0;
                    DatGrd.Items[i].Cells[15].Text = tool.MoneyFormat(nilaiAkhir.ToString());
                }
            }
        }

        private void ViewApplications()
        {
            DataTable dt1 = new DataTable();
            conn.QueryString = "select * from vw_ide_listapplication where ap_regno='" + Request.QueryString["regno"] + "' and KET_CODE = '" + Request.QueryString["ket_code"] + "'";
            conn.ExecuteQuery();
            dt1 = conn.GetDataTable().Copy();
            DATAGRID1.DataSource = dt1;
            DATAGRID1.DataBind();

            for (int i = 0; i < DATAGRID1.Items.Count; i++)
            {
                if (DATAGRID1.Items[i].Cells[5].Text != "&nbsp;")
                    DATAGRID1.Items[i].Cells[5].Text = tool.MoneyFormat(DATAGRID1.Items[i].Cells[5].Text);
                if (DATAGRID1.Items[i].Cells[6].Text != "&nbsp;")
                    DATAGRID1.Items[i].Cells[6].Text = tool.MoneyFormat(DATAGRID1.Items[i].Cells[6].Text);
            }
        }

        private bool cekLimitSubApplication()
        {
            /*
             * Mengambil limit main application
             */
            conn.QueryString = "select CP_LIMIT, APPTYPE from CUSTPRODUCT C left join APPLICATION A on C.AP_REGNO = A.AP_REGNO " +
                " where A.AP_REJECT <> '1' AND A.AP_CANCEL <> '1' " +
                "  and C.AP_REGNO = '" + LBL_MAINREGNO.Text +
                "' and C.PRODUCTID = '" + LBL_MAINPRODUCTID.Text +
                "' and C.PROD_SEQ = '" + LBL_MAINPROD_SEQ.Text + "'";
            conn.ExecuteQuery();

            /////////////////////////////////////////////////////////////
            ///	kalau main application bukan permohonan baru,
            ///	tidak perlu cek limit main application
            ///				
            if (conn.GetFieldValue("APPTYPE") != "01") return true;

            double CP_LIMIT_MAIN = 0;
            double CP_LIMIT_CURR_SUB = 0;
            double CP_LIMIT_ALL_SUB = 0;

            try { CP_LIMIT_CURR_SUB = Convert.ToDouble(TXT_CP_LIMIT.Text); }
            catch { }

            try { CP_LIMIT_MAIN = Convert.ToDouble(conn.GetFieldValue("CP_LIMIT")); }
            catch { }

            /**
             * Mengambil limit semua sub application
             */
            conn.QueryString = "select sum(CP_LIMIT) as CP_LIMIT_ALL_SUB from CUSTPRODUCT where MAINAP_REGNO = '" + LBL_MAINREGNO.Text +
                "' and MAINPRODUCTID = '" + LBL_MAINPRODUCTID.Text +
                "' and MAINPROD_SEQ = '" + LBL_MAINPROD_SEQ.Text + "'";
            conn.ExecuteQuery();

            try { CP_LIMIT_ALL_SUB = Convert.ToDouble(conn.GetFieldValue("CP_LIMIT_ALL_SUB")); }
            catch { }

            /*
             * Kalau LIMIT SUB + LIMIT SEMUA SUB > LIMIT MAIN ....
             */
            if (CP_LIMIT_ALL_SUB + CP_LIMIT_CURR_SUB > CP_LIMIT_MAIN)
            {
                GlobalTools.popMessage(this, "Limit sub aplikasi melebihi limit main aplikasi!");
                return false;
            }

            return true;
        }

        private void ViewMenu()
        {
            try
            {
                conn.QueryString = "select * from SCREENMENU where menucode = '" + Request.QueryString["mc"] + "'";
                conn.ExecuteQuery();
                for (int i = 0; i < conn.GetRowCount(); i++)
                {
                    HyperLink t = new HyperLink();
                    t.Text = conn.GetFieldValue(i, 2);
                    t.Font.Bold = true;
                    string strtemp = "";
                    if (conn.GetFieldValue(i, 3).Trim() != "")
                    {
                        if (conn.GetFieldValue(i, 3).IndexOf("mc=") >= 0)
                            strtemp = "regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"];
                        else strtemp = "regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&mc=" + Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"];
                        //t.ForeColor = Color.MidnightBlue; 
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
                string temp = ex.ToString();
            }
        }

        private string getNextStepMsg(string regno)
        {
            string pesan = "";
            string nextTrack = "";
            try
            {
                /***
                 * Memunculkan pesan next step
                 ***/
                conn.QueryString = "exec TRACKNEXTMSG '" + regno + "'";
                conn.ExecuteQuery();
                nextTrack = conn.GetFieldValue("TRACKNAME");
                pesan = "Application proceeds to " + nextTrack;
                /***********************************/
            }
            catch
            {
                throw new Exception();
            }

            return pesan;
        }

        private void Clear()
        {
            TXT_CP_LIMIT.Text = "";
            TXT_CP_JANGKAWKT.Text = "";
            TXT_CL_EXCHANGERATE.Text = "1";
            TXT_CP_EXRPLIMIT.Text = "1";

            DDL_CP_LOANPURPOSE.SelectedValue = "";
            TXT_CP_EXLIMITVAL.Text = "";
            TXT_CP_NOTES.Text = "";

            DDL_CL_TYPE.SelectedValue = "";
            DDL_CL_TYPE_EXISTING.SelectedValue = "0";
            DDL_CL_COLCLASSIFY.SelectedValue = "";
            DDL_CL_CURRENCY.SelectedValue = "";
            TXT_CL_FOREIGNVAL.Text = "";
            TXT_CL_EXCHANGERATE.Text = "1";
            TXT_CL_VALUE.Text = "";
            DDL_PRODUCTID.SelectedValue = "";

            TXT_COL_ID.Text = "";
            DDL_BUKTI_KEPEMILIKAN.SelectedValue = "";
            DDL_BENTUK_PENGIKATAN.SelectedValue = "";
            TXT_CL_FOREIGNVAL2.Text = "";
            TXT_CL_VALUE2.Text = "";
            TXT_CL_FOREIGNVALINS.Text = "";
            TXT_CL_VALUEINS.Text = "";
            TXT_CL_FOREIGNVALIKAT.Text = "";
            TXT_CL_VALUEIKAT.Text = "";
            TXT_CL_FOREIGNVALPPA.Text = "";
            TXT_CL_VALUEPPA.Text = "";
            TXT_CL_FOREIGNVALLIQ.Text = "";
            TXT_CL_VALUELIQ.Text = "";
            TXT_TGLPENILAIAN_DAY.Text = "";
            DDL_TGLPENILAIAN_MONTH.SelectedValue = "";
            TXT_TGLPENILAIAN_YEAR.Text = "";
            DDL_PENILAI_OLEH.SelectedValue = "";

            dtColl = (DataTable)Session["dataTable"];
            int count = dtColl.Rows.Count;

            for (int i = 0; i < count; i++)
                dtColl.Rows[0].Delete();

            Session.Remove("dataTable");
            Session.Add("dataTable", dtColl);

            DatGrd.DataSource = dtColl;
            DatGrd.DataBind();
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            base.OnInit(e);
            if (!this.DesignMode)
            {
                InitializeComponent();
            }
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
            this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);
            this.DATAGRID1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATAGRID1_ItemCommand);

        }
        #endregion

        protected void DDL_PRODUCTID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((DDL_APPTYPE.SelectedValue != "") && (DDL_PRODUCTID.SelectedValue != ""))
            {
                string isCashLoan = "", link = "", CURRENCY = ""; ;

                if (DDL_APPTYPE.SelectedValue == "01")
                {
                    conn.QueryString = "select ISCASHLOAN, CURRENCY from RFPRODUCT where PRODUCTID='" + DDL_PRODUCTID.SelectedValue + "'";
                    conn.ExecuteQuery();
                    isCashLoan = conn.GetFieldValue(0, 0);
                    CURRENCY = conn.GetFieldValue("CURRENCY");
                    TXT_CP_EXRPLIMIT.Text = CURRENCY;

                    conn.QueryString = "select screenlink from apptypelink where apptypeid='01' and iscashloan='" + isCashLoan + "' and fungsiid='IDE' and [default]='2'";
                    conn.ExecuteQuery();
                    link = conn.GetFieldValue(0, 0) + "?app=01&prod=" + DDL_PRODUCTID.SelectedValue;
                }
                else
                {
                    conn.QueryString = "select screenlink from apptypelink where apptypeid='" + DDL_APPTYPE.SelectedValue + "' and productid='" + DDL_PRODUCTID.SelectedValue + "' and fungsiid='IDE' and [default]='2'";
                    conn.ExecuteQuery();
                    link = conn.GetFieldValue(0, 0) + "?app=" + DDL_APPTYPE.SelectedValue + "&prod=" + DDL_PRODUCTID.SelectedValue;
                }

                Response.Redirect(link +
                    "&regno=" + Request.QueryString["regno"] +
                    "&curef=" + Request.QueryString["curef"] +
                    "&prog=" + Request.QueryString["prog"] +
                    "&tc=" + Request.QueryString["tc"] +
                    "&mc=" + Request.QueryString["mc"] +
                    "&ket_code=" + Request.QueryString["ket_code"] +
                    "&mainregno=" + LBL_MAINREGNO.Text +
                    "&mainprod_seq=" + LBL_MAINPROD_SEQ.Text +
                    "&mainproductid=" + LBL_MAINPRODUCTID.Text);
            }
        }

        protected void DDL_APPTYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDL_APPTYPE.SelectedValue != "")
            {
                conn.QueryString = "select screenlink from apptypelink where apptypeid='" + DDL_APPTYPE.SelectedValue + "' and fungsiid='IDE' and [default]='2'";
                conn.ExecuteQuery();
                string link = conn.GetFieldValue(0, 0) + "?app=" + DDL_APPTYPE.SelectedValue;
                Response.Redirect(link + "&regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&prog=" + Request.QueryString["prog"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
            }
        }

        protected void BTN_SAVE_Click(object sender, EventArgs e)
        {
            //Sebelum save, cek dulu ......

            //-------------------------------------------------------------------------------
            //Kalau checkbox collateral dipilih, tapi tidak ada collateral dimasukkan, maka
            //munculkan pesan
            //keyword: collateral
            if (CHK_COLLATERAL.Checked == true)
            {
                if (DatGrd.Items.Count == 0)
                {
                    Tools.popMessage(this, "Data collateral belum diisi!");
                    return;
                }
            }
            //-------------------------------------------------------------------------------

            //-------------------------------------------------------------------------------
            //Kalau aplikasi ybs adalah sub aplikasi, maka limit sub aplikasi tidak boleh
            //melebihi limit aplikasi utama
            //keyword: limit, sub application
            if (LBL_MAINREGNO.Text != "" && LBL_MAINREGNO.Text != null)
            {
                if (!cekLimitSubApplication()) return;
            }
            //-------------------------------------------------------------------------------

            /*** Cek Limit Atas dan Limit Bawah ***/
            if (!cek_limit(TXT_CP_EXLIMITVAL.Text, DDL_PRODUCTID.SelectedValue))
                return;
            /*** Cek Limit Atas dan Limit Bawah ***/
            
            string vPROD_SEQ = "0";

            if (CHK_ALIHDEB.Checked == true)
            {
                alihdeb = "1";
            }
            else
            {
                alihdeb = "0";
            }

            try
            {
                conn.QueryString = "exec IDE_LOANINFO_PBARU '" + Request.QueryString["regno"] + "', '" +
                    DDL_APPTYPE.SelectedValue + "', '" + DDL_PRODUCTID.SelectedValue + "', " +
                    tool.ConvertFloat(TXT_CP_LIMIT.Text) + ", '" + DDL_CP_LOANPURPOSE.SelectedValue + "', " +
                    tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text) + ", " +
                    tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text) + ", '" +
                    TXT_CP_NOTES.Text + "', " +
                    TXT_CP_JANGKAWKT.Text + ", " +
                    tool.ConvertNull(DDL_CP_TENORCODE.SelectedValue) + ", " +
                    tool.ConvertNull(DDL_PROJECT_CODE.SelectedValue) + ", '" +
                    alihdeb + "', '" +
                    TXT_OLDCIFNO.Text + "', '" +
                    TXT_OLDACCNO.Text + "'";
                conn.ExecuteQuery();
            }
            catch (Exception ex)
            {
                string errmsg = ex.Message.Replace("'", "");
                if (errmsg.IndexOf("Last Query:") > 0)
                    errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
                GlobalTools.popMessage(this, errmsg);
                return;
            }

            vPROD_SEQ = conn.GetFieldValue("PROD_SEQ");

            //--- menyimpan data parent application untuk jika sub application --//
            try
            {
                conn.QueryString = "exec IDE_LOANINFO_SUBAPP '" +
                    REGNO + "', '" +
                    DDL_APPTYPE.SelectedValue + "', '" +
                    DDL_PRODUCTID.SelectedValue + "', '" +
                    LBL_MAINREGNO.Text + "', '" +
                    LBL_MAINPRODUCTID.Text + "', '" +
                    LBL_MAINPROD_SEQ.Text + "'";
                conn.ExecuteNonQuery();
            }
            catch (NullReferenceException)
            {
                GlobalTools.popMessage(this, "Connection Error!");
                return;
            }

            try
            {
                conn.QueryString = "exec IDE_LOANINFO_GENERAL '" +
                    Request.QueryString["regno"] + "', '" +
                    DDL_APPTYPE.SelectedValue + "', '" +
                    DDL_PRODUCTID.SelectedValue + "', '" +
                    Request.QueryString["tc"] + "', '" +
                    LBL_USERID.Text + "'";
                conn.ExecuteNonQuery();
            }
            catch (NullReferenceException)
            {
                GlobalTools.popMessage(this, "Connection Error!");
                return;
            }

            for (int i = 0; i < DatGrd.Items.Count; i++)
            {
                if (DatGrd.Items[i].Cells[17].Text == "1")
                {
                    conn.QueryString = "exec IDE_LOANINFO_COLL2 '" + Request.QueryString["regno"] + "', '" +
                        Request.QueryString["curef"] + "', '" +
                        DatGrd.Items[i].Cells[3].Text + "', " +
                        DatGrd.Items[i].Cells[1].Text + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[9].Text) + ", " +
                        DatGrd.Items[i].Cells[0].Text + ", '" +
                        DDL_PRODUCTID.SelectedValue + "', " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[14].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[15].Text) + ", '1', '" +
                        DatGrd.Items[i].Cells[18].Text + "', '" +
                        DatGrd.Items[i].Cells[19].Text + "', " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[21].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[26].Text) + ", NULL, " + vPROD_SEQ + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[8].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[20].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[10].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[22].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[11].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[23].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[12].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[24].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[13].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[25].Text) + ", '" +
                        DatGrd.Items[i].Cells[4].Text + "', '" +
                        DatGrd.Items[i].Cells[6].Text + "', " +
                        /*
                        tool.ConvertDate(DatGrd.Items[i].Cells[27].Text) + ", '" + 
                        */
                        DatGrd.Items[i].Cells[27].Text + ", '" +
                        DatGrd.Items[i].Cells[28].Text + "'";
                    conn.ExecuteNonQuery();
                }
                else if (DatGrd.Items[i].Cells[17].Text == "0")
                {
                    conn.QueryString = "exec IDE_LOANINFO_COLL2 '" + Request.QueryString["regno"] + "', '" +
                        Request.QueryString["curef"] + "', " +
                        "null, null, 0," +
                        DatGrd.Items[i].Cells[0].Text + ", '" +
                        DDL_PRODUCTID.SelectedValue + "', " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[14].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[15].Text) + ", '2', '" +
                        DatGrd.Items[i].Cells[18].Text + "', '" +
                        DatGrd.Items[i].Cells[19].Text + "', 0, 0, NULL, '" + vPROD_SEQ + "', " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[8].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[20].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[10].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[22].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[11].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[23].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[12].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[24].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[13].Text) + ", " +
                        tool.ConvertFloat(DatGrd.Items[i].Cells[25].Text) + ", '" +
                        DatGrd.Items[i].Cells[4].Text + "', '" +
                        DatGrd.Items[i].Cells[6].Text + "', " +
                        /*
                        tool.ConvertDate(DatGrd.Items[i].Cells[27].Text) + ", '" + 
                        */
                        DatGrd.Items[i].Cells[27].Text + ", '" +
                        DatGrd.Items[i].Cells[28].Text + "'";
                    conn.ExecuteNonQuery();
                }
            }

            conn.QueryString = "UPDATE KETENTUAN_KREDIT SET TAKEOVER_FLAG = '" + Request.QueryString["takeover"] +
                "' WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' " +
                "AND KET_CODE = '" + Request.QueryString["ket_code"] + "'";
            conn.ExecuteQuery();

            Clear();
            ViewApplications();
            Button1.Enabled = true;
            Button2.Enabled = true;

            //Mengingat 1 ketentuan kredit hanya 1 permohonan baru, 
            //maka setelah permohonan baru dibuat, tidak bisa membuat pengajuan lagi
            //dengan jenis yang sama
            TR_JENISPENGAJUAN.Visible = false;
            TR_COLL.Visible = false;
            TR_BUTTONS.Visible = false;
        }

        protected void BTN_INSCOLL_Click(object sender, EventArgs e)
        {
            // ---- Baru ----
            if (DDL_CL_COLCLASSIFY.SelectedValue == "")
            {
                GlobalTools.popMessage(this, "Jenis Jaminan tidak boleh kosong!");
                return;
            }

            if (!GlobalTools.isDateValid(this, TXT_TGLPENILAIAN_DAY.Text, DDL_TGLPENILAIAN_MONTH.SelectedValue, TXT_TGLPENILAIAN_YEAR.Text))
            {
                GlobalTools.popMessage(this, "Tanggal Penilaian tidak valid!");
                GlobalTools.SetFocus(this, TXT_TGLPENILAIAN_DAY);
                return;
            }

            if (double.Parse(TXT_LC_PERCENTAGE.Text) > double.Parse(LBL_SISAUTILIZATION.Text))
            {
                Response.Write("<script language='javascript'>alert('Utilization Melebihi Limit!');</script>");
            }
            else
            {
                dtColl = (DataTable)Session["dataTable"];
                DataRow dr;
                try
                {
                    dr = dtColl.NewRow();
                }
                catch
                {
                    dtColl = new DataTable();
                    dtColl.Columns.Add(new DataColumn("CL_SEQ"));
                    dtColl.Columns.Add(new DataColumn("COLTYPEID"));
                    dtColl.Columns.Add(new DataColumn("COLTYPEDESC"));
                    dtColl.Columns.Add(new DataColumn("CL_DESC"));
                    dtColl.Columns.Add(new DataColumn("CL_CERTTYPE1"));
                    dtColl.Columns.Add(new DataColumn("CL_CERTTYPE1DESC"));
                    dtColl.Columns.Add(new DataColumn("CL_IKATID"));
                    dtColl.Columns.Add(new DataColumn("CL_IKATIDDESC"));
                    dtColl.Columns.Add(new DataColumn("CL_VALUE2"));
                    dtColl.Columns.Add(new DataColumn("CL_VALUE"));
                    dtColl.Columns.Add(new DataColumn("CL_VALUEINS"));
                    dtColl.Columns.Add(new DataColumn("CL_VALUEIKAT"));
                    dtColl.Columns.Add(new DataColumn("CL_VALUEPPA"));
                    dtColl.Columns.Add(new DataColumn("CL_VALUELIQ"));
                    dtColl.Columns.Add(new DataColumn("LC_PERCENTAGE"));
                    dtColl.Columns.Add(new DataColumn("ISNEW"));
                    dtColl.Columns.Add(new DataColumn("CL_CURRENCY"));
                    dtColl.Columns.Add(new DataColumn("CL_COLCLASSIFY"));
                    dtColl.Columns.Add(new DataColumn("CL_FOREIGNVAL2"));
                    dtColl.Columns.Add(new DataColumn("CL_FOREIGNVAL"));
                    dtColl.Columns.Add(new DataColumn("CL_FOREIGNVALINS"));
                    dtColl.Columns.Add(new DataColumn("CL_FOREIGNVALIKAT"));
                    dtColl.Columns.Add(new DataColumn("CL_FOREIGNVALPPA"));
                    dtColl.Columns.Add(new DataColumn("CL_FOREIGNVALLIQ"));
                    dtColl.Columns.Add(new DataColumn("CL_EXCHANGERATE"));
                    dtColl.Columns.Add(new DataColumn("CL_PENILAIANDATE"));
                    dtColl.Columns.Add(new DataColumn("CL_PENILAIANBY"));
                    dtColl.Columns.Add(new DataColumn("SIBS_COLID"));
                    Session.Add("dataTable", dtColl);

                    dr = dtColl.NewRow();
                }

                int seq = 0;
                try
                {
                    seq = int.Parse(LBL_SEQ.Text);
                }
                catch
                {
                    seq = 0;
                }

                if (RDO_COLLATERAL.SelectedValue == "1")
                {
                    seq++;
                    dr[0] = seq.ToString();
                    dr[1] = DDL_CL_TYPE.SelectedValue;
                    dr[2] = DDL_CL_TYPE.SelectedItem.Text;
                    dr[3] = TXT_CL_DESC.Text;
                    dr[4] = DDL_BUKTI_KEPEMILIKAN.SelectedValue;
                    dr[5] = DDL_BUKTI_KEPEMILIKAN.SelectedItem.Text;
                    dr[6] = DDL_BENTUK_PENGIKATAN.SelectedValue;
                    dr[7] = DDL_BENTUK_PENGIKATAN.SelectedItem.Text;
                    dr[8] = TXT_CL_VALUE2.Text;
                    dr[9] = TXT_CL_VALUE.Text;
                    dr[10] = TXT_CL_VALUEINS.Text;
                    dr[11] = TXT_CL_VALUEIKAT.Text;
                    dr[12] = TXT_CL_VALUEPPA.Text;
                    dr[13] = TXT_CL_VALUELIQ.Text;
                    dr[14] = TXT_LC_PERCENTAGE.Text;
                    dr[15] = "1";
                    dr[16] = DDL_CL_CURRENCY.SelectedValue;
                    dr[17] = DDL_CL_COLCLASSIFY.SelectedValue;
                    dr[18] = TXT_CL_FOREIGNVAL2.Text;
                    dr[19] = TXT_CL_FOREIGNVAL.Text;
                    dr[20] = TXT_CL_FOREIGNVALINS.Text;
                    dr[21] = TXT_CL_FOREIGNVALIKAT.Text;
                    dr[22] = TXT_CL_FOREIGNVALPPA.Text;
                    dr[23] = TXT_CL_FOREIGNVALLIQ.Text;
                    dr[24] = TXT_CL_EXCHANGERATE.Text;
                    dr[25] = tool.ConvertDate(TXT_TGLPENILAIAN_DAY.Text, DDL_TGLPENILAIAN_MONTH.SelectedValue, TXT_TGLPENILAIAN_YEAR.Text);
                    dr[26] = DDL_PENILAI_OLEH.SelectedValue;
                    dr[27] = TXT_COL_ID.Text;
                }
                else
                {
                    dr[0] = DDL_CL_TYPE_EXISTING.SelectedValue;
                    //dr[1] = DDL_CL_TYPE.SelectedValue;
                    //dr[2] = DDL_CL_TYPE.SelectedItem.Text;
                    dr[3] = DDL_CL_TYPE_EXISTING.SelectedItem.Text;
                    dr[4] = DDL_BUKTI_KEPEMILIKAN.SelectedValue;
                    dr[5] = DDL_BUKTI_KEPEMILIKAN.SelectedItem.Text;
                    dr[6] = DDL_BENTUK_PENGIKATAN.SelectedValue;
                    dr[7] = DDL_BENTUK_PENGIKATAN.SelectedItem.Text;
                    dr[8] = TXT_CL_VALUE2.Text;
                    dr[9] = TXT_CL_VALUE.Text;
                    dr[10] = TXT_CL_VALUEINS.Text;
                    dr[11] = TXT_CL_VALUEIKAT.Text;
                    dr[12] = TXT_CL_VALUEPPA.Text;
                    dr[13] = TXT_CL_VALUELIQ.Text;
                    dr[14] = TXT_LC_PERCENTAGE.Text;
                    dr[15] = "0";
                    dr[16] = DDL_CL_CURRENCY.SelectedValue;
                    dr[17] = DDL_CL_COLCLASSIFY.SelectedValue;
                    dr[18] = TXT_CL_FOREIGNVAL2.Text;
                    dr[19] = TXT_CL_FOREIGNVAL.Text;
                    dr[20] = TXT_CL_FOREIGNVALINS.Text;
                    dr[21] = TXT_CL_FOREIGNVALIKAT.Text;
                    dr[22] = TXT_CL_FOREIGNVALPPA.Text;
                    dr[23] = TXT_CL_FOREIGNVALLIQ.Text;
                    dr[24] = TXT_CL_EXCHANGERATE.Text;
                    dr[25] = tool.ConvertDate(TXT_TGLPENILAIAN_DAY.Text, DDL_TGLPENILAIAN_MONTH.SelectedValue, TXT_TGLPENILAIAN_YEAR.Text);
                    dr[26] = DDL_PENILAI_OLEH.SelectedValue;
                    dr[27] = TXT_COL_ID.Text;
                }

                dtColl.Rows.Add(dr);

                Session.Remove("dataTable");
                Session.Add("dataTable", dtColl);

                ViewCollateral();

                //DatGrd.DataSource = new DataView(dtColl);
                //DatGrd.DataBind();
                LBL_SEQ.Text = seq.ToString();

                TXT_CL_DESC.Text = "";
                DDL_CL_TYPE.SelectedValue = "";
                DDL_CL_COLCLASSIFY.SelectedValue = "";
                DDL_CL_CURRENCY.SelectedValue = "";
                TXT_CL_FOREIGNVAL.Text = "";
                TXT_CL_EXCHANGERATE.Text = "1";
                TXT_CL_VALUE.Text = "";
                TXT_LC_PERCENTAGE.Text = "100";
                try { DDL_CL_TYPE_EXISTING.SelectedValue = "0"; }
                catch { }

                TXT_COL_ID.Text = "";
                DDL_BUKTI_KEPEMILIKAN.SelectedValue = "";
                DDL_BENTUK_PENGIKATAN.SelectedValue = "";
                TXT_CL_FOREIGNVAL2.Text = "";
                TXT_CL_VALUE2.Text = "";
                TXT_CL_FOREIGNVALINS.Text = "";
                TXT_CL_VALUEINS.Text = "";
                TXT_CL_FOREIGNVALIKAT.Text = "";
                TXT_CL_VALUEIKAT.Text = "";
                TXT_CL_FOREIGNVALPPA.Text = "";
                TXT_CL_VALUEPPA.Text = "";
                TXT_CL_FOREIGNVALLIQ.Text = "";
                TXT_CL_VALUELIQ.Text = "";
                TXT_TGLPENILAIAN_DAY.Text = "";
                DDL_TGLPENILAIAN_MONTH.SelectedValue = "";
                TXT_TGLPENILAIAN_YEAR.Text = "";
                DDL_PENILAI_OLEH.SelectedValue = "";

                LBL_SISAUTILIZATION.Text = "100";
            }
        }

        protected void DATAGRID1_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (((LinkButton)e.CommandSource).CommandName)
            {
                case "delete":
                    /****************************************************************************************
                     * Kalau delete dari selain IDE, tidak bisa dilakukan jika tinggal 1 jenis pengajuan
                     *****************************************************************************************/
                    conn.QueryString = "select * from scgroup_init2 where gr_key like '%IDE%' and groupid = '" + Request.QueryString["tc"] + "'";
                    conn.ExecuteQuery();
                    if (conn.GetRowCount() == 0 && DATAGRID1.Items.Count == 1)
                    {
                        GlobalTools.popMessage(this, "Jenis Pengajuan tidak bisa dihapus karena aplikasi akan tidak memiliki kredit !");
                        return;
                    }
                    /****************************************************************************************/

                    try
                    {
                        conn.QueryString = "exec IDE_LOANINFO_DELETE '" +
                            Request.QueryString["regno"] + "', '" +
                            e.Item.Cells[1].Text + "', '" + // apptype
                            e.Item.Cells[3].Text + "', '" + // productid
                            e.Item.Cells[9].Text + "'";		// prod_seq
                        conn.ExecTrans();
                        conn.ExecTran_Commit();
                    }
                    catch (Exception ex)
                    {
                        if (conn != null)
                            conn.ExecTran_Rollback();
                        ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "ERROR DELETE : " + Request.QueryString["regno"]);
                    }

                    break;
            }
            ViewApplications();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Remove("dataTable");
            Response.Redirect("FairIsaac.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&prog=" + Request.QueryString["prog"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
        }

        protected void DatGrd_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string seq = null;

            switch (((LinkButton)e.CommandSource).CommandName)
            {
                case "delete":
                    seq = e.Item.Cells[0].Text;
                    dtColl = (DataTable)Session["dataTable"];

                    for (int i = 0; i < dtColl.Rows.Count; i++)
                        if (dtColl.Rows[i]["CL_SEQ"].ToString() == seq)
                            dtColl.Rows[i].Delete();

                    Session.Remove("dataTable");
                    Session.Add("dataTable", dtColl);

                    ViewCollateral();
                    break;
            }
        }

        protected void DatGrd_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            DatGrd.CurrentPageIndex = e.NewPageIndex;
            ViewCollateral();
        }

        protected void DDL_CL_TYPE_EXISTING_SelectedIndexChanged(object sender, EventArgs e)
        {
            //conn.QueryString = "select coltypedesc, cl_value, sisautilization, cl_currency, cl_colclassify, cl_exchangerate, cl_foreignval, sibs_colid from vw_collateral1 where cu_ref='" + Request.QueryString["curef"] + "' and cl_seq='" + DDL_CL_TYPE_EXISTING.SelectedValue + "'";
            conn.QueryString = "exec COLLATERALNEW1 '" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "', " + DDL_CL_TYPE_EXISTING.SelectedValue;
            conn.ExecuteQuery();
            TXT_CL_DESC.Text = conn.GetFieldValue(0, "coltypedesc");
            TXT_CL_VALUE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_value"));
            TXT_CL_VALUE2.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_value2"));
            TXT_CL_VALUEINS.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_valueins"));
            TXT_CL_VALUEIKAT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_valueikat"));
            TXT_CL_VALUEPPA.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_valueppa"));
            TXT_CL_VALUELIQ.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_valueliq"));
            try { DDL_CL_CURRENCY.SelectedValue = conn.GetFieldValue(0, "cl_currency"); }
            catch { }
            try { DDL_CL_COLCLASSIFY.SelectedValue = conn.GetFieldValue(0, "cl_colclassify"); }
            catch { }
            try { DDL_BUKTI_KEPEMILIKAN.SelectedValue = conn.GetFieldValue("cl_certtype1"); }
            catch { }
            try { DDL_BENTUK_PENGIKATAN.SelectedValue = conn.GetFieldValue("cl_ikatid"); }
            catch { }
            TXT_TGLPENILAIAN_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("cl_penilaiandate"));
            try { DDL_TGLPENILAIAN_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("cl_penilaiandate")); }
            catch { }
            TXT_TGLPENILAIAN_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("cl_penilaiandate"));
            try { DDL_PENILAI_OLEH.SelectedValue = conn.GetFieldValue("cl_penilaianby"); }
            catch { }
            if (conn.GetFieldValue(0, "cl_exchangerate") != "")
                TXT_CL_EXCHANGERATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_exchangerate"));
            else
                TXT_CL_EXCHANGERATE.Text = tool.MoneyFormat("1");
            if (conn.GetFieldValue(0, "cl_foreignval") != "")
                TXT_CL_FOREIGNVAL.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_foreignval"));
            else
                TXT_CL_FOREIGNVAL.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_value"));
            if (conn.GetFieldValue(0, "cl_foreignval2") != "")
                TXT_CL_FOREIGNVAL2.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_foreignval2"));
            else
                TXT_CL_FOREIGNVAL2.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_value2"));
            if (conn.GetFieldValue(0, "cl_foreignvalins") != "")
                TXT_CL_FOREIGNVALINS.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_foreignvalins"));
            else
                TXT_CL_FOREIGNVALINS.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_valueins"));
            if (conn.GetFieldValue(0, "cl_foreignvalikat") != "")
                TXT_CL_FOREIGNVALIKAT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_foreignvalikat"));
            else
                TXT_CL_FOREIGNVALIKAT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_valueikat"));
            if (conn.GetFieldValue(0, "cl_foreignvalppa") != "")
                TXT_CL_FOREIGNVALPPA.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_foreignvalppa"));
            else
                TXT_CL_FOREIGNVALPPA.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_valueppa"));
            if (conn.GetFieldValue(0, "cl_foreignvalliq") != "")
                TXT_CL_FOREIGNVALLIQ.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_foreignvalliq"));
            else
                TXT_CL_FOREIGNVALLIQ.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_valueliq"));
            LBL_SISAUTILIZATION.Text = conn.GetFieldValue(0, "sisautilization");
            if (conn.GetFieldValue(0, "sibs_colid") != "")
            {
                conn.QueryString = "select sum(lc_percentage) from listcollateral where ap_regno='" + Request.QueryString["regno"] + "' and cl_seq=" + DDL_CL_TYPE_EXISTING.SelectedValue;
                conn.ExecuteQuery();
                try
                {
                    double temp = 100 - double.Parse(conn.GetFieldValue(0, 0).ToString().Replace(".", ","));
                    LBL_SISAUTILIZATION.Text = temp.ToString();
                }
                catch
                {
                    LBL_SISAUTILIZATION.Text = "100";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //conn.QueryString = "select checkbi from customer where cu_ref='" + Request.QueryString["curef"] + "'";
            conn.QueryString = "select ap_checkbi from application where ap_regno='" + Request.QueryString["regno"] + "'";
            conn.ExecuteQuery();
            if (conn.GetRowCount() > 0)
            {
                if (conn.GetFieldValue(0, 0) == "1")
                {
                    conn.QueryString = "insert into bi_status (ap_regno, cu_ref, bs_reqdate, bs_recvdate, bs_bidataavail, bs_complete) " +
                        "values ('" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "', getdate(), null, null, '0')";
                    conn.ExecuteQuery();
                }
            }

            DataTable dt;
            conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + Request.QueryString["regno"] +
                "' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
            conn.ExecuteQuery();
            dt = conn.GetDataTable().Copy();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                conn.QueryString = "exec TRACKUPDATE '" +
                    Request.QueryString["regno"] + "', '" +
                    dt.Rows[i][1].ToString() + "', '" +
                    dt.Rows[i][0].ToString() + "', '" +
                    LBL_USERID.Text + "', '" +
                    dt.Rows[i]["PROD_SEQ"].ToString() + "','" + Request.QueryString["tc"].Trim() + "'";
                conn.ExecuteNonQuery();
            }
            Response.Redirect("FindCustomer.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
        }

        protected void CHK_COLLATERAL_CheckedChanged(object sender, EventArgs e)
        {
            if (CHK_COLLATERAL.Checked == true)
            {
                TR_COLL.Visible = true;
            }
            else
            {
                TR_COLL.Visible = false;
            }
        }

        protected void DDL_CL_CURRENCY_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.QueryString = "select CURRENCYRATE from RFCURRENCY where CURRENCYID = '" + DDL_CL_CURRENCY.SelectedValue + "'";
                conn.ExecuteQuery();

                TXT_CL_EXCHANGERATE.Text = tool.MoneyFormat(conn.GetFieldValue("CURRENCYRATE"));
            }
            catch (NullReferenceException)
            {
                GlobalTools.popMessage(this, "Connection Error !");
                return;
            }
        }

        protected void CHK_ALIHDEB_CheckedChanged(object sender, EventArgs e)
        {
            if (CHK_ALIHDEB.Checked == true)
            {
                TR_OLDCIFNO.Visible = true;
                TR_OLDACCNO.Visible = true;
            }
            else
            {
                TR_OLDCIFNO.Visible = false;
                TR_OLDACCNO.Visible = false;
            }
        }

        protected void TXT_CP_EXLIMITVAL_TextChanged(object sender, EventArgs e)
        {
            cek_limit();
        }

        private void cek_limit()
        {
            conn.QueryString = "select productid, limit_atas, limit_bawah from rfproduct where productid = '" +
                               DDL_PRODUCTID.SelectedValue + "' ";
            conn.ExecuteQuery();
            string a = conn.GetFieldValue("limit_atas"); //a=="" if NULL
            string b = conn.GetFieldValue("limit_bawah");

            //if (a == "" || a == "NULL" || a == null)
            //{
            //    a = "0";
            //}

            //if (b == "" || b == "NULL" || b == null)
            //{
            //    b = "0";
            //}
            //---------------------------------------------
            //if (a == "")
            //{
            //}
            //if (b == "")
            //{
            //} 
            //if (a == "" && b=="")
            //{
            //}
            if (a != "" && b != "")
            {


                float limitA = float.Parse(a, CultureInfo.InvariantCulture.NumberFormat);
                float limitB = float.Parse(b, CultureInfo.InvariantCulture.NumberFormat);

                string limitT = TXT_CP_EXLIMITVAL.Text;
                limitT = limitT.Replace(".", "*").Replace(",", ".").Replace("*", "");
                float limit = float.Parse(limitT, CultureInfo.InvariantCulture.NumberFormat);

                string m;
                if (limit > limitA)
                {
                    m = "Nilai Limit melebihi limit product!, Nilai Limit Atas: " +
                        limitA.ToString("N").Replace(",", "*").Replace(".", ",").Replace("*", ".");
                    GlobalTools.popMessage(this, m);
                    return;
                }
                else if (limit < limitB)
                {
                    m = "Nilai Limit kurang dari limit product!, Nilai Limit Bawah: " +
                        limitB.ToString("N").Replace(",", "*").Replace(".", ",").Replace("*", ".");
                    GlobalTools.popMessage(this, m);
                    return;
                }


            }
        }

        private bool cek_limit(string cp_limit, string productid)
        {
            conn.QueryString = "SELECT PRODUCTID, LIMIT_ATAS, LIMIT_BAWAH FROM RFPRODUCT WHERE PRODUCTID = '" + productid + "'";
            conn.ExecuteQuery();

            string a = conn.GetFieldValue("LIMIT_ATAS");
            string b = conn.GetFieldValue("LIMIT_BAWAH");

            float limitA = 0;
            float limitB = 0;
            float limit = 0;

            if (a != "")
            {
                try { limitA = float.Parse(a, CultureInfo.InvariantCulture.NumberFormat); }
                catch { }
            }

            if (b != "")
            {
                try { limitB = float.Parse(b, CultureInfo.InvariantCulture.NumberFormat); }
                catch { }
            }

            try
            {
                cp_limit = cp_limit.Replace(".", "*").Replace(",", ".").Replace("*", "");
                limit = float.Parse(cp_limit, CultureInfo.InvariantCulture.NumberFormat);
            }
            catch { }

            string m;

            if ((limitA > 0) && (limit > limitA))
            {
                m = "Nilai Limit melebihi limit product!, Nilai Limit Atas: " +
                    limitA.ToString("N").Replace(",", "*").Replace(".", ",").Replace("*", ".");
                GlobalTools.popMessage(this, m);
                return false;
            }

            if ((limitB > 0) && (limit < limitB))
            {
                m = "Nilai Limit kurang dari limit product!, Nilai Limit Bawah: " +
                        limitB.ToString("N").Replace(",", "*").Replace(".", ",").Replace("*", ".");
                GlobalTools.popMessage(this, m);
                return false;
            }

            return true;
        }
    }
}