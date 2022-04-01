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

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for M21M22PerubahanSyarat.
	/// </summary>
	public partial class M21M22PerubahanSyarat : System.Web.UI.Page
	{

		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				DDL_FACILITYNO.Items.Add(new ListItem("- PILIH -", "0"));
				LBL_REGNO.Text = Request.QueryString["regno"];
				conn.QueryString = "select cu_ref from application where ap_regno='" + LBL_REGNO.Text + "'";
				conn.ExecuteQuery();
				LBL_CUREF.Text = conn.GetFieldValue("cu_ref");
				LBL_PRODID.Text = Request.QueryString["prodid"];
				LBL_APPTYPE.Text = Request.QueryString["apptype"];
				LBL_PROD_SEQ.Text = Request.QueryString["prod_seq"];

				//--- Tujuan Penggunaan
				conn.QueryString = "select LOANPURPID, LOANPURPID + ' - ' +LOANPURPDESC AS LOANPURPDESC from RFLOANPURPOSE where ACTIVE='1' order by LOANPURPID";			
				conn.ExecuteQuery();
				DDL_CP_LOANPURPOSE.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 0; i<conn.GetRowCount(); i++)
					DDL_CP_LOANPURPOSE.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
				conn.ClearData();

				fillAANo();
				viewdata();
				SecureData();
				conn.QueryString = "select bp.productid, rp.productdesc, bp.limit, bp.tenor, rt.tenordesc " +
					"from bookedprod bp left join rftenorcode rt on bp.tenorcode=rt.tenorcode " +
					"inner join rfproduct rp on bp.productid=rp.productid where aa_no='" + DDL_AA_NO.SelectedValue + "' and acc_seq = '" + DDL_FACILITYNO.SelectedValue + "' and bp.productid = '" + LBL_PRODID.Text + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0)
				{
					TXT_LIMIT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LIMIT"));
					TXT_TENORDESC.Text = conn.GetFieldValue(0, "tenor") + " " + conn.GetFieldValue(0, "TENORDESC");
					//TXT_PRODUCTDESC.Text = conn.GetFieldValue(0, "productdesc");
					//LBL_PRODUCTID.Text = conn.GetFieldValue(0, "productid");
				}
			}
			BTN_Save.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
		}

		private void viewdata()
		{
			conn.QueryString = "select APPTYPEDESC, PRODUCTDESC, CP_LOANPURPOSE, "+
				"CP_LIMIT, CP_installment, AA_NO, ACC_SEQ, "+
				"CP_KETERANGAN, ACC_NO, CP_VARCODE, CP_RATENO, CP_VARIANCE, "+
				"REVOLVING, CURRENCY, NEWVALUE, NEWCODE, OLDVALUE, OLDCODE "+
				", CP_DECSTA, AD_VARCODE, AD_VARIANCE, AD_RATENO "+
				"from VW_CUSTPRODUCT a "+
				"where ap_regno='"+ LBL_REGNO.Text +"' and productid='"+
				LBL_PRODID.Text +"' and apptype='"+ LBL_APPTYPE.Text +"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			TXT_APPTYPE.Text		= conn.GetFieldValue("APPTYPEDESC");
			TXT_PRODUCTDESC.Text		= conn.GetFieldValue("PRODUCTDESC");
			TXT_REVOLVING.Text		= conn.GetFieldValue("REVOLVING");
			DDL_AA_NO.SelectedValue = conn.GetFieldValue("AA_NO");
			DDL_FACILITYNO.SelectedValue = conn.GetFieldValue("ACC_SEQ");
			TXT_CP_NOTES.Text = conn.GetFieldValue("CP_KETERANGAN");
			//TXT_LIMIT.Text		= conn.GetFieldValue("CP_LIMIT");
			//TXT_TENORDESC.Text		= conn.GetFieldValue("NEWVALUE") + " " + conn.GetFieldValue("NEWCODE");
			try{DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue("CP_LOANPURPOSE");}
			catch{}
		}

		private void fillAANo()
		{
			conn.QueryString = "select distinct aa_no from bookedcust where cu_ref='" + LBL_CUREF.Text + "'";
			conn.ExecuteQuery();
			DDL_AA_NO.Items.Clear();
			DDL_AA_NO.Items.Add(new ListItem("- PILIH -", ""));
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_AA_NO.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
			
			conn.QueryString = "select aa_no from custproduct where ap_regno='" + LBL_REGNO.Text + "' and productid='" + LBL_PRODID.Text + "' and apptype='" + LBL_APPTYPE.Text + "' and prod_seq = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			DDL_AA_NO.SelectedValue = conn.GetFieldValue("aa_no");
			fillFasilitasNo();
		}

		private void fillFasilitasNo()
		{
			DDL_FACILITYNO.Items.Clear();
			DDL_FACILITYNO.Items.Add(new ListItem("- PILIH -", "0"));

			conn.QueryString = "select acc_seq, acc_no from bookedprod where aa_no = '" +
				DDL_AA_NO.SelectedValue + "' and productid = '" + LBL_PRODID.Text + "'";
			conn.ExecuteQuery();
			
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_FACILITYNO.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		private void SecureData() 
		{
			// Jika yang memanggil bukan dalam scope DataEntry, maka disable semua control input
			// Flag :
			//		Nama  = de
			//		Value ==  1 --> Parent DataEntry
			//			  !=  1 --> Parent non-DataEntry
			string de = Request.QueryString["de"];
			if (de != "1") 
			{
				int index = -1;
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for(int j=0; j<coll.Count; j++) 
				{
					if (coll[j] is HtmlForm) 
					{
						index = j;
						break;
					}
				}

				/// Kalau ngga ketemu index, secure/disable secara manual
				/// 
				if (index == -1) 
				{
					TXT_CP_NOTES.ReadOnly = true;
					BTN_Save.Visible = false;
					return;
				}
				

				for (int i = 0; i < coll[index].Controls.Count; i++) 
				{
					if (coll[index].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[index].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[index].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[index].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[index].Controls[i] is Button)
					{
						Button btn = (Button) coll[index].Controls[i];
						btn.Visible = false;
					}
					else if (coll[index].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[index].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[index].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[index].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[index].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[index].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[index].Controls[i] is DataGrid) 
					{						
						DataGrid dg = (DataGrid) coll[index].Controls[i];						
						//dg.Columns[6].Visible = false;
						for (int j = 0; j < dg.Items.Count; j++) 
						{
							dg.Items[j].Cells[6].Enabled = false;							
							dg.Items[j].Cells[6].Text = "Delete";
						}
					}
					else if (coll[index].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[index].Controls[i];

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

		// safjsdfklasj asdfsafd

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


		protected void DDL_AA_NO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillFasilitasNo();
			TXT_LIMIT.Text = "";
			TXT_TENORDESC.Text = "";
		}

		protected void DDL_FACILITYNO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select bp.productid, rp.productdesc, bp.limit, bp.tenor, rt.tenordesc " +
				"from bookedprod bp left join rftenorcode rt on bp.tenorcode=rt.tenorcode " +
				"inner join rfproduct rp on bp.productid=rp.productid where aa_no='" + DDL_AA_NO.SelectedValue + "' and acc_seq = "+DDL_FACILITYNO.SelectedValue;
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				TXT_LIMIT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LIMIT"));
				TXT_TENORDESC.Text = conn.GetFieldValue(0, "tenor") + " " + conn.GetFieldValue(0, "TENORDESC");
				//TXT_PRODUCTDESC.Text = conn.GetFieldValue(0, "productdesc");
				//LBL_PRODUCTID.Text = conn.GetFieldValue(0, "productid");
			}
			else 
			{
				TXT_LIMIT.Text = "";
				TXT_TENORDESC.Text = "";
			}
		}

		protected void BTN_Save_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "exec DE_STRUCCREDIT1 '"+LBL_REGNO.Text+"', '"+
					LBL_PRODID.Text+"', '"+LBL_APPTYPE.Text+"', null, null, null ,'"+ TXT_CP_NOTES.Text +"', " +
					"null, null,null,null,null, '" + DDL_CP_LOANPURPOSE.SelectedValue + "', null, null, null, '" + DDL_AA_NO.SelectedValue.Trim()+
					"', " + DDL_FACILITYNO.SelectedValue + ",null, null, null, null, null, null, 0, 5, null, null, null, null, null, null, '" + LBL_PROD_SEQ.Text + "'";
				conn.ExecuteNonQuery();
				TR_STATUS.Visible = false;
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				labelStatus.Text = errmsg;
				TR_STATUS.Visible = true;
				return;
			}
		}
	}
}
