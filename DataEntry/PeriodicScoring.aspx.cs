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

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for PeriodicScoring.
	/// </summary>
	public partial class PeriodicScoring : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if(!IsPostBack)
			{
				LBL_REGNO.Text	= Request.QueryString["regno"];
				LBL_PRODID.Text	= Request.QueryString["prodid"];
				LBL_APPTYPE.Text = Request.QueryString["apptype"];
				LBL_PROD_SEQ.Text = Request.QueryString["prod_seq"];

				isiddl();
				viewdata();	
				SecureData();
			}

			this.update.Click += new EventHandler(update_Click);
		}

		private void SecureData() 
		{
			// Jika yang memanggil bukan dalam scope DataEntry, maka disable semua control input
			// Flag :asdfasd
			//		Nama  = de
			//		Value ==  1 --> Parent DataEntry
			//			  !=  1 --> Parent non-DataEntry

			

			string de = Request.QueryString["de"];
			if (de != "1") 
			{
				update.Visible					= false;

				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for (int i = 0; i < coll[3].Controls.Count; i++) 
				{
					if (coll[3].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[3].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[3].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[3].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[3].Controls[i] is Button)
					{
						Button btn = (Button) coll[3].Controls[i];
						btn.Visible = false;
					}
					else if (coll[3].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[3].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[3].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[3].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[3].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[3].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[3].Controls[i] is DataGrid) 
					{						
						DataGrid dg = (DataGrid) coll[3].Controls[i];						
						//dg.Columns[6].Visible = false;
						for (int j = 0; j < dg.Items.Count; j++) 
						{
							dg.Items[j].Cells[6].Enabled = false;							
							dg.Items[j].Cells[6].Text = "Delete";
						}
					}
					else if (coll[3].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[3].Controls[i];

						for (int j=0; j < htr.Controls.Count; j++) 
						{							
							for (int jj = 0; jj < htr.Controls[j].Controls.Count; jj++) 
							{
								if (htr.Controls[j].Controls[jj] is TextBox) 
								{
									TextBox txt = (TextBox) htr.Controls[j].Controls[jj];
									txt.ReadOnly = true;
								}
								else if (htr.Controls[j].Controls[jj] is DropDownList) 
								{
									DropDownList ddl = (DropDownList) htr.Controls[j].Controls[jj];
									ddl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is Button)
								{
									Button btn = (Button) htr.Controls[j].Controls[jj];
									//btn.Enabled = false;
									btn.Visible = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButtonList) 
								{
									RadioButtonList rbl = (RadioButtonList) htr.Controls[j].Controls[jj];
									rbl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButton) 
								{
									RadioButton rb = (RadioButton) htr.Controls[j].Controls[jj];
									rb.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is CheckBox)
								{
									CheckBox cb = (CheckBox) htr.Controls[j].Controls[jj];
									cb.Enabled = false;
								}					
							}
						}
					}
				}
			}
		}

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
			conn.QueryString = "select LOANPURPID, LOANPURPID + ' - ' +LOANPURPDESC AS LOANPURPDESC from RFLOANPURPOSE where ACTIVE='1' order by LOANPURPID";			
			conn.ExecuteQuery();
			row = conn.GetRowCount();
			DDL_CP_LOANPURPOSE.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 0; i<row; i++)
				DDL_CP_LOANPURPOSE.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			conn.ClearData();
		}

		private void viewdata()
		{
			conn.QueryString="select APPTYPEDESC, PRODUCTDESC, CP_LOANPURPOSE, "+
				"CP_LIMIT, CP_installment, AA_NO, ACC_SEQ, "+
				"CP_KETERANGAN, ACC_NO, CP_VARCODE, CP_RATENO, CP_VARIANCE, "+
				"REVOLVING, CURRENCY, NEWVALUE, NEWCODE, OLDVALUE, OLDCODE, b.tenordesc "+
				", CP_DECSTA, AD_VARCODE, AD_VARIANCE, AD_RATENO, CP_MATURITYDATE "+
				"from VW_CUSTPRODUCT a "+
				"left join RFTENORCODE B on B.TENORCODE=A.OLDCODE "+
				"where AP_REGNO='"+ LBL_REGNO.Text +"' and PRODUCTID='"+ LBL_PRODID.Text +"' and APPTYPE='"+ LBL_APPTYPE.Text +"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			TXT_APPTYPE.Text		= conn.GetFieldValue("APPTYPEDESC");
			TXT_PRODUCT.Text		= conn.GetFieldValue("PRODUCTDESC");
			TXT_CP_KETERANGAN.Text	= conn.GetFieldValue("CP_KETERANGAN");
			TXT_REVOLVING.Text		= conn.GetFieldValue("REVOLVING");
			LBL_CURRENCY.Text		= conn.GetFieldValue("CURRENCY");
			//TXT_OLDTENOR.Text		= conn.GetFieldValue("OLDVALUE");
			//LBL_OLDTENOR.Text		= conn.GetFieldValue("TENORDESC");
			TXT_CP_NOREK.Text		= conn.GetFieldValue("ACC_NO");
			string CP_DECSTA		= conn.GetFieldValue("CP_DECSTA");
			string AD_VARCODE		= conn.GetFieldValue("AD_VARCODE");
			string AD_VARIANCE		= conn.GetFieldValue("AD_VARIANCE");
			string AD_RATENO		= conn.GetFieldValue("AD_RATENO");

			if (!conn.GetFieldValue("CP_LOANPURPOSE").Equals("")) 
			{
				try{DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue("CP_LOANPURPOSE");}
				catch{}
			}
			string seq = conn.GetFieldValue("ACC_SEQ");
			for (int g=0; g<DDL_CP_NOREK.Items.Count; g++) 
			{
				if (DDL_CP_NOREK.Items[g].Value.ToString()== seq.ToString()) DDL_CP_NOREK.SelectedValue = seq;				
			}
			string AA_NO	= conn.GetFieldValue("AA_NO");
			string ACC_SEQ	= conn.GetFieldValue("ACC_SEQ");

			conn.ClearData();

			//--- Mengambil limit
			conn.QueryString = "SELECT LIMIT, TENOR FROM BOOKEDPROD WHERE AA_NO='"+AA_NO+"' AND ACC_SEQ="+tools.ConvertNum(ACC_SEQ)+" AND PRODUCTID='"+LBL_PRODID.Text+"'";
			conn.ExecuteQuery();
			TXT_CP_LIMIT.Text				= tools.MoneyFormat(conn.GetFieldValue("LIMIT"));
			TXT_OLDTENOR.Text				= conn.GetFieldValue("TENOR");
			LBL_PRODUCT.Text				= Request.QueryString["teks"];

			conn.ClearData();
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

		protected void update_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec DE_STRUCCREDIT1 '" + LBL_REGNO.Text + "', '" +
				LBL_PRODID.Text + "', '" + LBL_APPTYPE.Text + "', " +
				"null, null, " +
				"null , '" + TXT_CP_KETERANGAN.Text + "', " +
				"null, null, " + 
				"null, null, " +
				"null, '" + DDL_CP_LOANPURPOSE.SelectedValue + "', 0, 0, 0, '', 0, " +
				"null, null, null, " +
				"null, null, null, " +
				"0, 4 , null, null, null, null, null, null, '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteNonQuery();
		}
	}
}
