using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.IO;
using DMS.DBConnection;

namespace SME.QTools
{
    public partial class QueryEditor : System.Web.UI.Page
    {
        protected Connection conn;
        protected string squery;
        protected DataTable dtresult;
        protected int rowsaffected;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = (Connection)Session["Connection"];
        }

        protected void ClearScreen()
        {
            TXT_QUERY.Text = "";
            squery = "";
            //dtresult.Clear();
            GV_RESULT.DataSource = null;
            GV_RESULT.DataBind();
            LBL_MESSAGE.ForeColor = Color.Black;
            LBL_MESSAGE.Text = "";
        }

        protected void BTN_SELECT_Click(object sender, EventArgs e)
        {
            try
            {
                squery = TXT_QUERY.Text;

                conn.QueryString = squery;
                conn.ExecuteQuery();

                dtresult = conn.GetDataTable().Copy();
                GV_RESULT.DataSource = dtresult;
                GV_RESULT.DataBind();

                LBL_MESSAGE.ForeColor = Color.Black;
                LBL_MESSAGE.Text = "Done";
            }
            catch (Exception ex)
            {
                LBL_MESSAGE.ForeColor = Color.Red;
                LBL_MESSAGE.Text = ex.Message;

                GV_RESULT.DataSource = null;
                GV_RESULT.DataBind();
            }
        }

        protected void BTN_UPDATE_Click(object sender, EventArgs e)
        {
            try
            {
                squery = TXT_QUERY.Text;

                conn.QueryString = squery;
                conn.ExecuteNonQuery();

                LBL_MESSAGE.ForeColor = Color.Black;
                LBL_MESSAGE.Text = "Done";

                GV_RESULT.DataSource = null;
                GV_RESULT.DataBind();
            }
            catch (Exception ex)
            {
                LBL_MESSAGE.ForeColor = Color.Red;
                LBL_MESSAGE.Text = ex.Message;

                GV_RESULT.DataSource = null;
                GV_RESULT.DataBind();
            }
        }

        protected void BTN_CLEAR_Click(object sender, EventArgs e)
        {
            ClearScreen();
        }

        protected void BTN_EXPORT_Click(object sender, EventArgs e)
        {
            string filename = "Result" + DateTime.Now.ToString("yyyyMMddHHmm") + ".xls";

            GV_RESULT.AllowPaging = false;

            try
            {
                squery = TXT_QUERY.Text;

                conn.QueryString = squery;
                conn.ExecuteQuery();

                dtresult = conn.GetDataTable().Copy();
                GV_RESULT.DataSource = dtresult;
                GV_RESULT.DataBind();
            }
            catch (Exception ex)
            {
                LBL_MESSAGE.ForeColor = Color.Red;
                LBL_MESSAGE.Text = ex.Message;
            }

            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    GV_RESULT.RenderControl(hw);
                    Response.Write(sw.ToString());
                }

                Response.End();
            }
            catch (Exception ex)
            {
                LBL_MESSAGE.ForeColor = Color.Red;
                LBL_MESSAGE.Text = ex.Message;
            }
        }

        protected void GV_RESULT_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_RESULT.PageIndex = e.NewPageIndex;

            squery = TXT_QUERY.Text;

            conn.QueryString = squery;
            conn.ExecuteQuery();

            dtresult = conn.GetDataTable().Copy();
            GV_RESULT.DataSource = dtresult;
            GV_RESULT.DataBind();
        }
    }
}