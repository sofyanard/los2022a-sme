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
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.Maintenance.Parameters.General
{
	/// <summary>
	/// Summary description for ProductDetail.
	/// </summary>
	public partial class ProductDetail : System.Web.UI.Page
	{

		protected Tools tool = new Tools();
		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");
			string productID = Request.QueryString["productid"];

			if (!IsPostBack)
			{
				// menampilkan detil produk
				try 
				{
					conn.QueryString = "SELECT 	PRODUCTID,PRODUCTDESC,SIBS_PRODCODE,";
					conn.QueryString += "SIBS_PRODID,CURRENCY,CURRENCYDESC,INTERESTREST,";
					conn.QueryString += "ISCASHLOAN,REVOLVING,ITYPEDESC,INTERESTTYPERATE,";
					conn.QueryString += "RATENO,RATE * 100 AS PERCENTAGE,INTERESTMODE,VARCODE,";
					conn.QueryString += "VARIANCE,SPK,ISINSTALLMENT,INSTALMENTTYPE,";
					conn.QueryString += "CONFIRMKORAN,IN_NAME,ITYPEDESC, INTERESTTYPE, ISNEGORATE";
					conn.QueryString += " FROM VW_PARAM_GENERAL_RFPRODUCT";
					conn.QueryString += " WHERE PRODUCTID = '" + productID + "'";
					conn.ExecuteQuery();

					LBL_PRODUCTID.Text = conn.GetFieldValue("PRODUCTID"); // PRODUCTID
					LBL_PRODUCTDESC.Text = conn.GetFieldValue(0,1); // PRODUCTDESC
					LBL_SIBS_PRODCODE.Text = conn.GetFieldValue(0,2); // SIBS_PRODCODE
					LBL_SIBS_PRODID.Text = conn.GetFieldValue(0,3); //SIBS_PRODID
					LBL_CURRENCY.Text = conn.GetFieldValue(0,4); // CURRENCY
					LBL_CURRENCYDESC.Text = conn.GetFieldValue(0,5); // CURRENCYDESC
					LBL_INTERESTREST.Text = conn.GetFieldValue(0,6); // INTERESTREST
					string temp = conn.GetFieldValue(0,7); // ISCASHLOAN
					if (temp == "1") RDO_ISCASHLOAN.SelectedIndex = 0;
					else RDO_ISCASHLOAN.SelectedIndex = 1;
					temp = conn.GetFieldValue(0,8); // REVOLVING
					if (temp == "1") RDO_REVOLVING.SelectedIndex = 0;
					else RDO_REVOLVING.SelectedIndex = 1;
					LBL_INTERESTTYPE.Text = conn.GetFieldValue(0,9); // ITYPEDESC -- deskripsi INTERESTTYPE, floating, fixed
					LBL_INTERESTTYPERATE.Text = conn.GetFieldValue(0,10); // INTERESTTYPERATE
					LBL_RATENO.Text = conn.GetFieldValue(0,11); //RATENO
					LBL_RATEPERCENT.Text = conn.GetFieldValue(0,12); // PERCENTAGE
					LBL_RATE.Text = conn.GetFieldValue(0,13); // INTERESTRESTMODE TODO: // belum benar
					temp = conn.GetFieldValue(0,14); // VARCODE
					if (temp == "+") RDO_VARCODE.SelectedIndex = 1;
					else if (temp == "-") RDO_VARCODE.SelectedIndex = 2;
					else RDO_VARCODE.SelectedIndex = 0;
					LBL_VARIANCE.Text = conn.GetFieldValue(0,15);
					temp = conn.GetFieldValue(0,16); // VARIANCE
					if (temp == "1") RDO_SPK.SelectedIndex = 0;
					else RDO_SPK.SelectedIndex = 1;
					temp = conn.GetFieldValue(0,17); //SPK
					if (temp == "1") RDO_ISINSTALLMENT.SelectedIndex = 0;
					else RDO_ISINSTALLMENT.SelectedIndex = 1;
					LBL_INSTALLMENTTYPE.Text = conn.GetFieldValue(0,18); // ISINSTALMENT (payment type)
					temp = conn.GetFieldValue(0,19); //CONFIRMKORAN (rekening koran)
					if (temp == "1") RDO_CONFIRMKORAN.SelectedIndex = 0;
					else RDO_CONFIRMKORAN.SelectedIndex = 1;

					string ratetype = conn.GetFieldValue("INTERESTTYPE").Trim();
					string nego = conn.GetFieldValue("ISNEGORATE").Trim();
					if (nego == "1") RDO_CONFIRMKORAN.SelectedValue = "1";
					else RDO_CONFIRMKORAN.SelectedValue = "0";

					if (/*(ratetype == "03") && */(nego == "0"))
					{ // kalo database sudah diperbaiki, ratetype harus dicek, hilangkan commentnya
						BTN_VIEW.Enabled = true;
					} 
					else
					{
						BTN_VIEW.Enabled = false;
					}
				}
				catch(NullReferenceException)
				{
					GlobalTools.popMessage(this,"Server Error");
				}
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("RateInquiry.aspx?mc=" + Request.QueryString["mc"]);
		}

		protected void BTN_VIEW_Click(object sender, System.EventArgs e)
		{
			if (true)
			{
				Response.Write("<script language='javascript'>window.open('../Maintenance/Parameters/General/AlternateRate.aspx?productid=" + Request.QueryString["productid"] + "&edit=no','PresetAlternateRate','status=no,scrollbars=no,width=1000,height=350');</script>");
			}
		}
	}
}
