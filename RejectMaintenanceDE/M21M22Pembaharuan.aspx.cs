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
	/// Summary description for M21M22Pembaharuan.
	/// </summary>
	public partial class M21M22Pembaharuan : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DatGrd;
		protected System.Web.UI.WebControls.DropDownList DDL_CL_ID;
		protected System.Web.UI.WebControls.TextBox TXT_LC_PERCENTAGE;
		protected System.Web.UI.WebControls.TextBox TXT_LC_VALUE;
		protected System.Web.UI.WebControls.TextBox TXT_ENDVALUE;
		protected System.Web.UI.WebControls.Button insert;
		protected System.Web.UI.WebControls.TextBox TXT_CL_DESC;
		protected Tools tools = new Tools();
		
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if(!IsPostBack)
			{
				LBL_REGNO.Text	= Request.QueryString["regno"];
				LBL_PRODID.Text	= Request.QueryString["prodid"];
				LBL_APPTYPE.Text= Request.QueryString["apptype"];
				LBL_PROD_SEQ.Text= Request.QueryString["prod_seq"];

				isiddl();
				viewdata();	
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
				
				 //CODEGEN: This call is required by the ASP.NET Web Form Designer.
				
				InitializeComponent();
				base.OnInit(e);
		}
		
		///<summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion


		private void isiddl()
		{
			conn.QueryString = "select aa_no, cu_ref from application where ap_regno='"+LBL_REGNO.Text+"'";
			conn.ExecuteQuery();
			string aa_no		= conn.GetFieldValue("aa_no");
			TXT_CP_CUREF.Text	= conn.GetFieldValue("cu_ref");
			conn.ClearData();

			conn.QueryString = "select acc_seq, acc_no from BOOKEDPROD where productid='"+LBL_PRODID.Text+"' and aa_no='"+aa_no+"'";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			DDL_CP_NOREK.Items.Add(new ListItem("-- PILIH --","0"));
			for (int i = 0; i<row; i++)
				DDL_CP_NOREK.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			conn.ClearData();

			//--- Tujuan Penggunaan
			conn.QueryString = "select LOANPURPID, LOANPURPID+' - '+LOANPURPDESC as LOANPURPDESC from RFLOANPURPOSE where ACTIVE='1' order by LOANPURPID";
			conn.ExecuteQuery();
			row = conn.GetRowCount();
			DDL_CP_LOANPURPOSE.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 0; i<row; i++)
				DDL_CP_LOANPURPOSE.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			conn.ClearData();
			
			DDL_NEWTENOR.Items.Add(new ListItem("-- PILIH --", ""));
			conn.QueryString = "select tenorcode, tenordesc from rftenorcode where active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_NEWTENOR.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		private void viewdata()
		{
			conn.QueryString="select APPTYPEDESC, PRODUCTDESC, CP_LOANPURPOSE, "+
				"CP_LIMIT, CP_installment, AA_NO, ACC_SEQ, "+
				"CP_KETERANGAN, ACC_NO, CP_VARCODE, CP_RATENO, CP_VARIANCE, "+
				"REVOLVING, CURRENCY, NEWVALUE, NEWCODE, OLDVALUE, OLDCODE, b.tenordesc "+
				", CP_DECSTA, AD_VARCODE, AD_VARIANCE, AD_RATENO "+
				"from VW_CUSTPRODUCT a "+
				"left join rftenorcode b on b.tenorcode=a.OLDCODE "+
				"where ap_regno='"+ LBL_REGNO.Text +"' and productid='"+ LBL_PRODID.Text +"' and apptype='"+ LBL_APPTYPE.Text +"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";			
			conn.ExecuteQuery();
			TXT_APPTYPE.Text		= conn.GetFieldValue("APPTYPEDESC");
			TXT_PRODUCT.Text		= conn.GetFieldValue("PRODUCTDESC");
			TXT_CP_INSTALLMENT.Text	= conn.GetFieldValue("CP_installment");
			TXT_CP_KETERANGAN.Text	= conn.GetFieldValue("CP_KETERANGAN");
			TXT_REVOLVING.Text		= conn.GetFieldValue("REVOLVING");
			LBL_CURRENCY.Text		= conn.GetFieldValue("CURRENCY");
			TXT_OLDTENOR.Text		= conn.GetFieldValue("OLDVALUE");
			TXT_NEWTENOR.Text		= conn.GetFieldValue("NEWVALUE");
			LBL_OLDTENOR.Text		= conn.GetFieldValue("tenordesc");
			TXT_CP_NOREK.Text		= conn.GetFieldValue("ACC_NO");
			string CP_DECSTA		= conn.GetFieldValue("CP_DECSTA");
			string AD_VARCODE		= conn.GetFieldValue("AD_VARCODE");
			string AD_VARIANCE		= conn.GetFieldValue("AD_VARIANCE");
			string AD_RATENO		= conn.GetFieldValue("AD_RATENO");

			if (!conn.GetFieldValue("NEWCODE").Equals(""))
			{
				try
				{
					DDL_NEWTENOR.SelectedValue	= conn.GetFieldValue("NEWCODE");
				} 
				catch {}
			}
			if (!conn.GetFieldValue("CP_LOANPURPOSE").Equals(""))
			{
				try
				{
					DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue("CP_LOANPURPOSE");
				} 
				catch {}
			}
			string seq						= conn.GetFieldValue("ACC_SEQ");
			for (int g=0; g<DDL_CP_NOREK.Items.Count; g++)
			{
				if (DDL_CP_NOREK.Items[g].Value.ToString()== seq.ToString())
				{
					try
					{
						DDL_CP_NOREK.SelectedValue		= seq;				
					} 
					catch {}
				}
			}
			string AA_NO					= conn.GetFieldValue("AA_NO");
			string ACC_SEQ					= conn.GetFieldValue("ACC_SEQ");
			conn.ClearData();
			conn.QueryString = "SELECT LIMIT FROM BOOKEDPROD WHERE AA_NO='"+AA_NO+"' AND ACC_SEQ="+tools.ConvertNum(ACC_SEQ)+" AND PRODUCTID='"+LBL_PRODID.Text+"'";
			conn.ExecuteQuery();
			TXT_CP_LIMIT.Text				= conn.GetFieldValue("LIMIT");
			conn.ClearData();
			TR_IDC.Visible					= false;
			LBL_PRODUCT.Text				= Request.QueryString["teks"];

			conn.QueryString = "select interesttype from rfproduct where productid='" + LBL_PRODID.Text + "'";
			conn.ExecuteQuery();
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
			}
		}

		protected void CHECK_IDC_CheckedChanged(object sender, System.EventArgs e)
		{
			if (CHECK_IDC.Checked ==true)
			{
				TR_IDC.Visible = true;
				viewIDC();
			}
			else
				TR_IDC.Visible = false;
		}

		void viewIDC()
		{
			conn.QueryString="select IDC_CAPAMNT, IDC_CAPRATIO, IDC_JWAKTU, "+
				"IDC_PRIMEVARCODE, IDC_RATIO, IDC_VARCODE, IDC_VARIANCE from vw_custproduct_idc "+
				"where ap_regno='"+ LBL_REGNO.Text +"' and productid='"+ LBL_PRODID.Text +"' and apptype='"+LBL_APPTYPE.Text+"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			TXT_IDC_CAPAMNT.Text		= conn.GetFieldValue("IDC_CAPAMNT");
			TXT_IDC_CAPRATIO.Text		= conn.GetFieldValue("IDC_CAPRATIO");
			TXT_IDC_JWAKTU.Text			= conn.GetFieldValue("IDC_JWAKTU");
			TXT_IDC_PRIMEVARCODE.Text	= conn.GetFieldValue("IDC_PRIMEVARCODE");
			try 
			{
				if (!conn.GetFieldValue("IDC_VARCODE").Equals(""))
					DDL_IDC_VARCODE.SelectedValue	= conn.GetFieldValue("IDC_VARCODE");
			} 
			catch {}
			TXT_IDC_VARIANCE.Text		= conn.GetFieldValue("IDC_VARIANCE");
			TXT_IDC_RATIO.Text			= conn.GetFieldValue("IDC_RATIO");
			conn.ClearData();
		}

		protected void update_Click(object sender, System.EventArgs e)
		{
			if (CHECK_IDC.Checked==true)
			{
		   		conn.QueryString = "exec DE_STRUCCREDIT1_AD '"+LBL_REGNO.Text+"', '"+
					LBL_PRODID.Text+"', '"+LBL_APPTYPE.Text+"', "+
					tools.ConvertNum(TXT_CP_INSTALLMENT.Text)+", "+tools.ConvertNum(TXT_NEWTENOR.Text)+", '"+
					DDL_NEWTENOR.SelectedValue+"' ,'"+ TXT_CP_KETERANGAN.Text +"', " +
					tools.ConvertNum(TXT_IDC_RATIO.Text) +","+ tools.ConvertNum(TXT_IDC_JWAKTU.Text) +","+ 
					tools.ConvertNum(TXT_IDC_CAPAMNT.Text)+","+tools.ConvertNum(TXT_IDC_CAPRATIO.Text)+",'"+
					TXT_IDC_PRIMEVARCODE.Text+"', '', 0, 0, 0, '', 0,"+
					""+tools.ConvertNull(LBL_VARCODE.Text)+", "+tools.ConvertNull(LBL_RATENO.Text)+", "+tools.ConvertFloat(LBL_VARIANCE.Text)+", "+
					""+tools.ConvertFloat(LBL_INTEREST.Text)+", "+tools.ConvertNull(DDL_IDC_VARCODE.SelectedValue)+", "+tools.ConvertNum(TXT_IDC_VARIANCE.Text)+", "+
					"1,4, '" + LBL_PROD_SEQ.Text + "'";
				conn.ExecuteNonQuery();
			}
			else
			{
				conn.QueryString = "exec DE_STRUCCREDIT1_AD '"+LBL_REGNO.Text+"', '"+
					LBL_PRODID.Text+"', '"+LBL_APPTYPE.Text+"', "+
					tools.ConvertNum(TXT_CP_INSTALLMENT.Text)+", "+tools.ConvertNum(TXT_NEWTENOR.Text)+", '"+
					DDL_NEWTENOR.SelectedValue+"' ,'"+ TXT_CP_KETERANGAN.Text +"', " +
					tools.ConvertNum(TXT_IDC_RATIO.Text) +","+ tools.ConvertNum(TXT_IDC_JWAKTU.Text) +","+ 
					tools.ConvertNum(TXT_IDC_CAPAMNT.Text)+","+tools.ConvertNum(TXT_IDC_CAPRATIO.Text)+",'"+
					TXT_IDC_PRIMEVARCODE.Text+"', '', 0, 0, 0, '', 0,"+
					""+tools.ConvertNull(LBL_VARCODE.Text)+", "+tools.ConvertNull(LBL_RATENO.Text)+", "+tools.ConvertFloat(LBL_VARIANCE.Text)+", "+
					""+tools.ConvertFloat(LBL_INTEREST.Text)+", "+tools.ConvertNull(DDL_IDC_VARCODE.SelectedValue)+", "+tools.ConvertNum(TXT_IDC_VARIANCE.Text)+", "+
					"0,4, '" + LBL_PROD_SEQ.Text + "'";
				conn.ExecuteNonQuery();
			}
		}
	}
}
