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
using Microsoft.VisualBasic;

namespace SME.RejectMaintenanceDE
{
	/// <summary>
	/// Summary description for 
	/// </summary>
	public partial class M21M22PerubahanLimit : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		
		protected Connection conn;
		protected Tools tool = new Tools();
			
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if(!IsPostBack)
			{
				LBL_REGNO.Text	= Request.QueryString["regno"];
				LBL_PRODID.Text	= Request.QueryString["prodid"];
				LBL_APPTYPE.Text= Request.QueryString["apptype"];
				LBL_PRODUCT.Text= Request.QueryString["teks"];
				LBL_PROD_SEQ.Text= Request.QueryString["prod_seq"];
				viewdata();			
				isiddl();
			}
			CalculateInstallment();
			TXT_CP_INSTALLMENT.Text = tool.MoneyFormat(TXT_CP_INSTALLMENT.Text);
			TXT_CP_LIMIT.Text		= tool.MoneyFormat(TXT_CP_LIMIT.Text);
			TXT_CP_EXRPLIMIT.Text	= tool.MoneyFormat(TXT_CP_EXRPLIMIT.Text);
			TXT_CP_EXLIMITVAL.Text	= tool.MoneyFormat(TXT_CP_EXLIMITVAL.Text);
		}

		private void CalculateInstallment()
		{
			double result = 0;

			conn.QueryString = "select calcmethod, isinstallment from rfproduct where productid='" + LBL_PRODID.Text + "'";
			conn.ExecuteQuery();
			if ((conn.GetFieldValue("isinstallment") == "1") /*&& (conn.GetFieldValue("calcmethod") == "Annuity")*/)
			{
				LBL_INSTALLMENT.Text = "Installment";
				result = DMS.CuBESCore.Logic.hitungInstalment(double.Parse(TXT_CP_EXLIMITVAL.Text), int.Parse(TXT_NEWTENOR.Text), double.Parse(LBL_INTEREST.Text), LBL_PRODID.Text, "M", conn);
				TXT_CP_INSTALLMENT.Text = result.ToString();
			}
			else if (conn.GetFieldValue("isinstallment") == "0")
			{
				LBL_INSTALLMENT.Text = "Bunga per bulan";
				result = double.Parse(LBL_INTEREST.Text) / 100 * double.Parse(TXT_CP_EXLIMITVAL.Text) / 12;
				TXT_CP_INSTALLMENT.Text = result.ToString();
				TXT_NEWTENOR.AutoPostBack = false;
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

		void isiddl()
		{
			/*
			conn.QueryString="select cu_ref from application where ap_regno='"+LBL_REGNO.Text+"'";	
            conn.ExecuteQuery();
			TXT_CP_CUREF.Text	= conn.GetFieldValue("cu_ref");

			conn.QueryString = "select distinct productid from bookedcust where cu_ref='" + TXT_CP_CUREF.Text + "' and aa_no='" + TXT_AA_NO.Text + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_PRODUCTID.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));

			DDL_PRODUCTID.SelectedValue = LBL_PRODID.Text;
			*/
			//TXT_PRODUCTID.Text = LBL_PRODID.Text;
			
			/*
			DDL_CP_NOREK.Items.Add(new ListItem("-- PILIH --",0.ToString()));
			int row = conn.GetRowCount();
			for (int i = 0; i<row; i++)
				DDL_CP_NOREK.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			conn.ClearData();
			*/

			conn.QueryString = "select LIMIT, TENOR, TENORCODE from bookedprod " +  
				"where aa_no='" + TXT_AA_NO.Text + "' and productid='" + LBL_PRODID.Text +
				"' and acc_seq='" + TXT_NOREK.Text.Trim() + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				TXT_CP_LIMITCHGTO.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LIMIT"));
				TXT_NEWTENOR.Text = conn.GetFieldValue(0, "TENOR");
				LBL_NEWTENORCODE.Text = conn.GetFieldValue(0, "TENORCODE");
			}

		}
		/* Test */
		void viewdata()
		{
			conn.QueryString="select APPTYPEDESC, PRODUCTDESC, CP_LOANPURPOSE, "+
				"CP_LIMIT, CP_installment, CP_EXRPLIMIT, CP_EXLIMITVAL, CP_VARCODE, CP_RATENO, CP_VARIANCE, "+
				"CP_KETERANGAN, ACC_SEQ, CP_JANGKAWKT, CP_TENORCODE, REVOLVING, aa_no, acc_seq "+
				", CP_DECSTA, AD_VARCODE, AD_VARIANCE, AD_RATENO, CP_LIMITCHG, CP_FACILITY_CODE "+
				"from VW_CUSTPRODUCT "+
				"where ap_regno='"+ LBL_REGNO.Text +"' and productid='"+ LBL_PRODID.Text +"' and apptype='"+LBL_APPTYPE.Text+"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			TXT_APPTYPE.Text				= conn.GetFieldValue("APPTYPEDESC");
			TXT_PRODUCT.Text				= conn.GetFieldValue("PRODUCTDESC");
			TXT_CP_LIMIT.Text			= conn.GetFieldValue("CP_LIMIT");
			TXT_CP_INSTALLMENT.Text		= conn.GetFieldValue("CP_installment");
			TXT_CP_EXRPLIMIT.Text		= conn.GetFieldValue("CP_EXRPLIMIT");
			TXT_CP_EXLIMITVAL.Text		= conn.GetFieldValue("CP_EXLIMITVAL");
			TXT_CP_KETERANGAN.Text		= conn.GetFieldValue("CP_KETERANGAN");
			DDL_CP_LIMITCHG.SelectedValue = conn.GetFieldValue("CP_LIMITCHG");
			string CP_DECSTA			= conn.GetFieldValue("CP_DECSTA");
			string AD_VARCODE			= conn.GetFieldValue("AD_VARCODE");
			string AD_VARIANCE			= conn.GetFieldValue("AD_VARIANCE");
			string AD_RATENO			= conn.GetFieldValue("AD_RATENO");
			TXT_NOREK.Text				= conn.GetFieldValue("ACC_SEQ");
			TXT_AA_NO.Text 				= conn.GetFieldValue("AA_NO");
			TXT_PRODUCTID.Text 				= conn.GetFieldValue("CP_FACILITY_CODE");

			conn.QueryString = "select interesttype, currency from rfproduct where productid='" + LBL_PRODID.Text + "'";
			conn.ExecuteQuery();
			
			LBL_CURR1.Text = conn.GetFieldValue("currency");
			LBL_CURR2.Text = conn.GetFieldValue("currency");
			LBL_CURR3.Text = conn.GetFieldValue("currency");

			if (conn.GetFieldValue(0,0) == "01")
			{
				LBL_INTERESTTYPE.Text = "Bunga / p.a: Floating";
				conn.QueryString = "select * from vw_floatingrate where productid='" + LBL_PRODID.Text + "'";
				conn.ExecuteQuery();
				LBL_INTEREST.Text	= conn.GetFieldValue("rate");  
				if (CP_DECSTA == "")
				{
					LBL_VARCODE.Text	= conn.GetFieldValue("varcode");  
					LBL_VARIANCE.Text	= conn.GetFieldValue("variance");
					LBL_RATENO.Text		= conn.GetFieldValue("rateno");  
				}
				else
				{
					LBL_VARCODE.Text	= AD_VARCODE;
					LBL_VARIANCE.Text	= AD_VARIANCE;
					LBL_RATENO.Text		= AD_RATENO;
				}
			}
			else
			{
				LBL_INTERESTTYPE.Text = "Bunga / p.a: Fix";
				conn.QueryString = "select interesttyperate from rfproduct where productid='" + LBL_PRODID.Text + "'";
				conn.ExecuteQuery();
				LBL_INTEREST.Text = conn.GetFieldValue("interesttyperate");
				LBL_VARIANCE.Visible = false;
				//TXT_CP_INTEREST.Visible = true;
			}
		}

		protected void update_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec DE_STRUCCREDIT1_AD '"+
				LBL_REGNO.Text+"', '"+
				LBL_PRODID.Text + "', '" + 
				LBL_APPTYPE.Text+"', "+
				tools.ConvertFloat(TXT_CP_INSTALLMENT.Text)+", "+
				tools.ConvertNum(TXT_NEWTENOR.Text)+", '"+
				LBL_NEWTENORCODE.Text+"' ,'"+  
				TXT_CP_KETERANGAN.Text +"', " +
				"0" +","+ 
				"0" +","+ 
				"0" +","+
				"0"+",'"+
				"0"+"', "+
				"null"+", "+
				tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+
				tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", "+
				tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+
				TXT_AA_NO.Text+"', "+
				TXT_NOREK.Text.Trim()+", "+
				""+tool.ConvertNull(LBL_VARCODE.Text)+", "+
				tool.ConvertNull(LBL_RATENO.Text)+", "+
				tool.ConvertFloat(LBL_VARIANCE.Text)+", "+
				""+tool.ConvertFloat(LBL_INTEREST.Text)+
				", "+
				"null"+", "+
				"null"+", "+
				"0,3, null, null, null, '" + 
				DDL_CP_LIMITCHG.SelectedValue + "'," + 
				"NULL, NULL, '" + LBL_PROD_SEQ.Text + "', NULL, " +
				GlobalTools.ConvertNull(TXT_PRODUCTID.Text);
			conn.ExecuteNonQuery();
		}

		protected void TXT_NOREK_TextChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select LIMIT from bookedprod " +  
				"where aa_no='" + TXT_AA_NO.Text + "' and productid='" + LBL_PRODID.Text +
				"' and acc_seq='" + TXT_NOREK.Text + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				TXT_CP_LIMITCHGTO.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LIMIT"));
			}
		}

	}
}
