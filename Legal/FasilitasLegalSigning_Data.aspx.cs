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


namespace SME.Legal
{
	/// <summary>
	/// Summary description for FasilitasLegalSigning_Data.
	/// </summary>
	public partial class FasilitasLegalSigning_Data : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SME;uid=sa;pwd=");
		protected Tools tool = new Tools();
		protected Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_REGNO.Text		= Request.QueryString["regno"];
				LBL_CUREF.Text		= Request.QueryString["curef"];
				LBL_TC.Text			= Request.QueryString["tc"];
				LBL_PRODUCTID.Text	= Request.QueryString["productid"];
				LBL_PROD_SEQ.Text	= Request.QueryString["PROD_SEQ"];
				LBL_APPTYPE.Text	= Request.QueryString["apptype"];
				
				DDL_CP_PKDATEMONTH.Items.Add(new ListItem("-- Pilih --",""));
				DDL_CP_ISSUEDATEMONTH.Items.Add(new ListItem("-- Pilih --",""));
				string nm_bln;
				for (int i=1; i<=12; i++)
				{
					nm_bln = DateAndTime.MonthName(i, false);
					DDL_CP_PKDATEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_CP_ISSUEDATEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
				}

				//--- Tujuan Penggunaan
				int jml_row;
				conn.QueryString = "select LOANPURPID, LOANPURPID+' - '+LOANPURPDESC from RFLOANPURPOSE where active='1' order by LOANPURPID";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_CP_LOANPURPOSE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				ViewData();
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

		private void ViewData()
		{
			/***********************************************************************************
			conn.QueryString = "select CP_LIMIT, CP_TENOR, CP_INTEREST, CP_LOANPURPOSE, CP_ISSUEDATE "+
				", CP_BEAADM, CP_BEAPROVISI, CP_BEANOTARIS, CP_BEAIKAT, CP_BEAMATERAI "+
				"from custproduct "+
				"where AP_REGNO = '"+ LBL_REGNO.Text +
					"' and PRODUCTID = '"+ LBL_PRODUCTID.Text +
					"' and APPTYPE = '" + LBL_APPTYPE.Text +
					"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			***********************************************************************************/
			//ahmad
			conn.QueryString = "select * from VW_LEGAL_SIGNING_structure_credit" + 
				"where AP_REGNO = '"+ LBL_REGNO.Text +
					"' and PRODUCTID = '"+ LBL_PRODUCTID.Text +
					"' and APPTYPE = '" + LBL_APPTYPE.Text +
					"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();

			TXT_CP_LIMIT.Text = tool.ConvertCurr(conn.GetFieldValue("CP_LIMIT"));
			TXT_CP_TENOR.Text = conn.GetFieldValue("CP_TENOR");
			TXT_CP_INTEREST.Text = conn.GetFieldValue("CP_INTEREST");
			//			TXT_CP_INTTYPE.Text = conn.GetFieldValue("CP_INTTYPE");
			DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue("CP_LOANPURPOSE");
			string CP_ISSUEDATE = conn.GetFieldValue("CP_ISSUEDATE");
			TXT_CP_ISSUEDATEDAY.Text = tool.FormatDate_Day(CP_ISSUEDATE);
			DDL_CP_ISSUEDATEMONTH.SelectedValue = tool.FormatDate_Month(CP_ISSUEDATE);
			TXT_CP_ISSUEDATEYEAR.Text = tool.FormatDate_Year(CP_ISSUEDATE);
			//			TXT_CP_PKNO.Text = conn.GetFieldValue("CP_PKNO");
			//			string CP_PKDATE = conn.GetFieldValue("CP_PKDATE");
			//			TXT_CP_PKDATEDAY.Text = tool.FormatDate_Day(CP_PKDATE);
			//			DDL_CP_PKDATEMONTH.SelectedValue = tool.FormatDate_Month(CP_PKDATE);
			//			TXT_CP_PKDATEYEAR.Text = tool.FormatDate_Year(CP_PKDATE);
			TXT_CP_BEAADM.Text = tool.ConvertCurr(conn.GetFieldValue("CP_BEAADM"));
			TXT_CP_BEAPROVISI.Text = tool.ConvertCurr(conn.GetFieldValue("CP_BEAPROVISI"));
			TXT_CP_BEANOTARIS.Text = tool.ConvertCurr(conn.GetFieldValue("CP_BEANOTARIS"));
			TXT_CP_BEAIKAT.Text = tool.ConvertCurr(conn.GetFieldValue("CP_BEAIKAT"));
			TXT_CP_BEAMATERAI.Text = tool.ConvertCurr(conn.GetFieldValue("CP_BEAMATERAI"));
			//			DDL_CP_INSRCOMP.SelectedValue = conn.GetFieldValue("CP_INSRCOMP");
			//			TXT_CP_INSRTYPE.Text = conn.GetFieldValue("CP_INSRTYPE");
			//			TXT_CP_INSRAMNT.Text = conn.GetFieldValue("CP_INSRAMNT");
			//			TXT_CP_INSRMASA.Text = conn.GetFieldValue("CP_INSRMASA");
			//			TXT_CP_INSRPREMI.Text = conn.GetFieldValue("CP_INSRPREMI");

		}
		private void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			string pk = "";
			if (RDB_PK1.Checked) pk = "01"; // notary
			else if (RDB_PK2.Checked) pk = "02"; // bawah tangan

			if (!GlobalTools.isDateValid(TXT_CP_PKDATEDAY.Text, DDL_CP_PKDATEMONTH.SelectedValue, TXT_CP_PKDATEYEAR.Text)) 
			{
				GlobalTools.popMessage(this, "Tanggal PK tidak valid!");
				GlobalTools.SetFocus(this, TXT_CP_PKDATEDAY);
				return;
			}

			conn.QueryString = "exec LGL_SCREDIT '"+ 
				LBL_REGNO.Text +"', '"+ 
				LBL_APPTYPE.Text + "', '" +
				LBL_PRODUCTID.Text +"', "+
				tool.ConvertNum(TXT_CP_BEAADM.Text) +", "+ 
				tool.ConvertNum(TXT_CP_BEAPROVISI.Text) +", "+
				tool.ConvertNum(TXT_CP_BEANOTARIS.Text) +", "+ 
				tool.ConvertNum(TXT_CP_BEAIKAT.Text) +", "+
				tool.ConvertNum(TXT_CP_BEAMATERAI.Text) + ", '" + 
				pk + "', '" +
				TXT_CP_PKNO.Text + "', " +
				tool.ConvertDate(TXT_CP_PKDATEDAY.Text, DDL_CP_PKDATEMONTH.SelectedValue, TXT_CP_PKDATEYEAR.Text) +  ", '" + 
				LBL_PROD_SEQ.Text + "'";
			conn.ExecuteNonQuery();
			ViewData();
		}

	}
}
