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

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for BPRPermohonanBaru.
	/// </summary>
	public partial class BPRPermohonanBaru : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if(!IsPostBack)
			{
				isiddl();
				viewdata();	
				this.SecureData();
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
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);
			this.DatGrd.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_DeleteCommand);

		}
		#endregion

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
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for (int i = 0; i < coll[1].Controls.Count; i++) 
				{
					if (coll[1].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[1].Controls[i];
						txt.ReadOnly = true;
						//txt.Enabled = false;
					}
					else if (coll[1].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[1].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[1].Controls[i] is Button)
					{
						Button btn = (Button) coll[1].Controls[i];
						//btn.Enabled = false;
						btn.Visible = false;
					}
					else if (coll[1].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[1].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[1].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[1].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[1].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[1].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[1].Controls[i] is DataGrid) 
					{						
						DataGrid dg = (DataGrid) coll[1].Controls[i];						
						/*
						try 
						{
							for(int j=0; j < dg.Items.Count; j++) 
							{
								dg.Items[i].Enabled	= false;
							}
						}
						catch (ArgumentOutOfRangeException ex) 
						{
							// ignore...
						}
						*/
					}
					else if (coll[1].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[1].Controls[i];
						//htr.Disabled = true;	

						for (int j=0; j < htr.Controls.Count; j++) 
						{							
							for (int jj = 0; jj < htr.Controls[j].Controls.Count; jj++) 
							{
								if (htr.Controls[j].Controls[jj] is TextBox) 
								{
									TextBox txt = (TextBox) htr.Controls[j].Controls[jj];
									txt.ReadOnly = true;
									//txt.Enabled = false;
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

		void isiddl()
		{
			//--- Tujuan Penggunaan
			conn.QueryString="select LOANPURPID, LOANPURPID + ' - ' + LOANPURPDESC AS LOANPURPDESC from RFLOANPURPOSE where ACTIVE = '1' order by LOANPURPID";			
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			DDL_CP_LOANPURPOSE.Items.Add(new ListItem("-- select --",""));
			for (int i = 0; i<row; i++)
			{
				DDL_CP_LOANPURPOSE.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
			conn.ClearData();
			
			conn.QueryString="select TENORSEQ, TENORDESC from rftenor " +
				" where PROGRAMID in (select Prog_code from application where ap_regno ='"+ Request.QueryString["regno"] +"')" +
				" and PRODUCTID ='"+ Request.QueryString["prodid"] +"' and   ACTIVE=1 ";			
			conn.ExecuteQuery();
			row = conn.GetRowCount();
			DDL_CP_TENOR.Items.Add(new ListItem("-- select --",""));
			for (int i = 0; i<row; i++)
			{
				DDL_CP_TENOR.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
			conn.ClearData();

			conn.QueryString="select * from rfsifatkredit";			
			conn.ExecuteQuery();
			row = conn.GetRowCount();
			DDL_CP_SKREDIT.Items.Add(new ListItem("-- select --",""));
			for (int i = 0; i<row; i++)
			{
				DDL_CP_SKREDIT.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
			conn.ClearData();

			conn.QueryString = " select * from VW_COLLATERAL " +
				" where cu_ref in (select cu_ref from application where ap_regno='"+ Request.QueryString["regno"] +"')";
			conn.ExecuteQuery();
			row = conn.GetRowCount();
			DDL_CL_ID.Items.Add(new ListItem("--Select--", ""));
			for (int i = 0;i < row;i++) 
			{
				DDL_CL_ID.Items.Add(new ListItem(conn.GetFieldValue(i, 3), conn.GetFieldValue(i, 1)));
			}
			conn.ClearData();

			DDL_MONTHIDC.Items.Add(new ListItem("-- Select --",""));
			for (int i = 1; i <= 12; i++)
			{
				DDL_MONTHIDC.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}
		}


		void viewdata()
		{
			conn.QueryString="select * from VW_CUSTPRODUCT where ap_regno='"+ Request.QueryString["regno"] +"' and productid='"+ Request.QueryString["prodid"] +"' and prod_seq = '" + Request.QueryString["prod_seq"] + "'";
			conn.ExecuteQuery();
			TXT_APPTYPE.Text = conn.GetFieldValue("APPTYPEDESC");
			TXT_PRODUCT.Text = conn.GetFieldValue("PRODUCTDESC");
			DDL_CP_SKREDIT.SelectedValue = conn.GetFieldValue("cp_skredit");
			try{DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue("CP_LOANPURPOSE");}
			catch{}
			TXT_CP_LIMIT.Text  = conn.GetFieldValue("CP_LIMIT");
			TXT_CP_INSTALLMENT.Text = conn.GetFieldValue("CP_installment");
			DDL_CP_TENOR.SelectedValue = conn.GetFieldValue("CP_TENOR");
			TXT_CP_INTEREST.Text = conn.GetFieldValue("CP_INTEREST");
			TXT_CP_KETERANGAN.Text = conn.GetFieldValue("CP_KETERANGAN");
			/*TXT_CP_EXRPLIMIT.Text = conn.GetFieldValue("CP_EXRPLIMIT");
			TXT_CP_EXLIMITVAL.Text = conn.GetFieldValue("CP_EXLIMITVAL");
			TXT_CP_EXRPCOLL.Text = conn.GetFieldValue("CP_EXRPCOLL");
			TXT_CP_EXCOLLVAL.Text = conn.GetFieldValue("CP_EXCOLLVAL");
			*/
			conn.ClearData();
			isiGrid();
			TXT_LC_VALUE.Text ="0";
			TXT_LC_PERCENTAGE.Text = "0";
			TXT_ENDVALUE.Text = "0";
			TR_IDC.Visible=false;
			LBL_PRODUCT.Text = Request.QueryString["teks"];

		}
		
		void viewIDC()
		{
			conn.QueryString="select * from vw_custproduct_idc where ap_regno='"+ Request.QueryString["regno"] +"' and productid='"+ Request.QueryString["prodid"] +"' and PROD_SEQ = '" + Request.QueryString["prod_seq"] + "'";
			conn.ExecuteQuery();
			TXT_IDC_CAPAMNT.Text = conn.GetFieldValue("IDC_CAPAMNT");
			TXT_IDC_CAPRATIO.Text = conn.GetFieldValue("IDC_CAPRATIO");
			TXT_IDC_INTEREST.Text =conn.GetFieldValue("IDC_INTEREST");
			TXT_IDC_JWAKTU.Text = conn.GetFieldValue("IDC_JWAKTU");
			TXT_IDC_PRIMERATE.Text =conn.GetFieldValue("IDC_PRIMERATE");
			TXT_IDC_PRIMEVARCODE.Text = conn.GetFieldValue("IDC_PRIMEVARCODE");
			TXT_IDC_PVARIANCE.Text = conn.GetFieldValue("IDC_PVARIANCE");
			TXT_IDC_RATIO.Text = conn.GetFieldValue("IDC_RATIO");
			TXT_DAYIDC.Text = tool.FormatDate_Day(conn.GetFieldValue("IDC_EXPDATE"));
			DDL_MONTHIDC.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("IDC_EXPDATE"));
			TXT_YEARIDC.Text = tool.FormatDate_Year(conn.GetFieldValue("IDC_EXPDATE"));
			conn.ClearData();

		}

		void isiGrid()
		{
			DataTable dt = new DataTable();
			conn.QueryString="select a.ap_regno, a.cl_seq, a.productid,c.coltypedesc, a.lc_percentage, b.cl_value, lc_value from listcollateral a inner join collateral b on " +
				"a.cl_seq = b.cl_seq inner join rfcollateraltype c on b.cl_type = c.coltypeseq " +
				"where ap_regno = '"+Request.QueryString["regno"]+"' and a.productid='"+ Request.QueryString["prodid"]+"' ";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			//Response.Write(DatGrd.CurrentPageIndex);
			DatGrd.DataBind();
			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				DatGrd.Items[i].Cells[3].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[3].Text);
				DatGrd.Items[i].Cells[4].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[4].Text);
			}
		}

		protected void CHECK_IDC_CheckedChanged(object sender, System.EventArgs e)
		{
			if (CHECK_IDC.Checked ==true)
			{
				TR_IDC.Visible = true;
				viewIDC();
				//Server.Transfer("StrucCreditDetailM21.aspx?regno="+Request.Params["regno"]+"&prodid="+Request.Params["prodid"]+"&check=1");
			}
			else
			{
				TR_IDC.Visible = false;
			}
		}

		void isiCollateral()
		{
			
			TXT_LC_PERCENTAGE.ReadOnly=false;
			TXT_LC_PERCENTAGE.Text = "0";
			TXT_ENDVALUE.Text = "0";
		}

		void tidakisiCollateral()
		{
			TXT_LC_VALUE.Text ="0";
			TXT_LC_PERCENTAGE.Text = "0";
			TXT_LC_PERCENTAGE.ReadOnly=true;
			TXT_ENDVALUE.Text = "0";
		}

		private void DatGrd_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			TableCell itemCell0 = e.Item.Cells[0];
			conn.QueryString="delete from listcollateral where ap_regno='"+ Request.QueryString["regno"] +"' and productid='"+ Request.QueryString["prodid"] +"' "+
				" and cl_seq ="+int.Parse(itemCell0.Text)+" ";
			conn.ExecuteQuery();
			// menset page index dari DatGrd
			int index = DatGrd.Items.Count;
			
			int jml = (index % 3)-1;
			if (jml == 0)
				DatGrd.CurrentPageIndex = index/3;
			// Selesai
			isiGrid();

			DDL_CL_ID.Items.Clear();
			conn.QueryString = " select * from VW_COLLATERAL " +
				" where cu_ref in (select cu_ref from application where ap_regno='"+ Request.QueryString["regno"] +"')";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			DDL_CL_ID.Items.Add(new ListItem("--Select--", ""));
			for (int i = 0;i < row;i++) 
			{
				DDL_CL_ID.Items.Add(new ListItem(conn.GetFieldValue(i, 3), conn.GetFieldValue(i, 1)));
			}
			conn.ClearData();
			tidakisiCollateral();
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			isiGrid();
		}

		protected void DDL_CL_ID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select * from VW_COLLATERAL where " +
				" cu_ref in (select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+"') and cl_seq = "+tool.ConvertNum(DDL_CL_ID.SelectedValue)+"";
			//((Label)Table1.FindControl("TXT_ENDVALUE")).Text = conn.QueryString;
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			if (row > 0) 
			{
				TXT_LC_VALUE.Text = tool.MoneyFormat(conn.GetFieldValue("CL_VALUE"));
				isiCollateral();
			}
			else
			{	
				tidakisiCollateral();
				
			}
			conn.ClearData();
		}

		protected void TXT_LC_PERCENTAGE_TextChanged(object sender, System.EventArgs e)
		{
			float persen = float.Parse(TXT_LC_PERCENTAGE.Text);
			float nilai = float.Parse(TXT_LC_VALUE.Text);
			float hasil = nilai * persen / 100;
			TXT_LC_VALUE.Text = tool.MoneyFormat(nilai.ToString());
			//TXT_LC_VALUE.Text = tool.MoneyFormat("1.09");
			TXT_ENDVALUE.Text = tool.MoneyFormat(hasil.ToString());
		}

		protected void insert_Click(object sender, System.EventArgs e)
		{
			if(DDL_CL_ID.SelectedValue != "")

			{
				float persen = float.Parse(TXT_LC_PERCENTAGE.Text);
				if ( persen>0 && (persen<100 || persen == 100))
				{
					conn.QueryString = "select apptype,b.cu_ref cu_ref, a.prod_seq from custproduct a inner join application b on a.ap_regno=b.ap_regno " +
						" where b.ap_regno='"+ Request.QueryString["regno"] +
						"' and productid = '"+ Request.QueryString["prodid"] +
						"' and prod_seq = '" + Request.QueryString["prod_seq"] + "'";
					conn.ExecuteQuery();
					string apptype		= conn.GetFieldValue("apptype");
					string cu_ref		= conn.GetFieldValue("cu_ref");
					string prod_seq		= conn.GetFieldValue("prod_seq");
					conn.ClearData();

					conn.QueryString = "exec SP_LISTCOLLPROCESS '"+Request.QueryString["regno"]+"', '"+ apptype +"','"+ cu_ref +"', '"+Request.QueryString["prodid"]+"', "+tool.ConvertNum(DDL_CL_ID.SelectedValue)+", "+TXT_LC_PERCENTAGE.Text+", "+tool.ConvertNum(TXT_ENDVALUE.Text)+", '1', '" + prod_seq + "'";
					conn.ExecuteQuery();
					Server.Transfer("BPRPermohonanBaru.aspx?regno="+Request.Params["regno"]+"&prodid="+Request.Params["prodid"]);
				}
			}
			else
			{
				Server.Transfer("BPRPermohonanBaru.aspx?regno="+Request.Params["regno"]+"&prodid="+Request.Params["prodid"]);
			}
		}

		protected void update_Click(object sender, System.EventArgs e)
		{
			if (CHECK_IDC.Checked==true)//plus IDC
			{
				
				conn.QueryString = "exec DE_STRUCCREDIT '"+Request.QueryString["regno"]+"', '"+Request.QueryString["prodid"]+"', '"+ DDL_CP_SKREDIT.SelectedValue +"', '"+DDL_CP_LOANPURPOSE.SelectedValue+"', "+tool.ConvertNum(TXT_CP_LIMIT.Text)+", "+tool.ConvertNum(TXT_CP_INSTALLMENT.Text)+", "+tool.ConvertNum(DDL_CP_TENOR.SelectedValue)+", "+tool.ConvertNum(TXT_CP_INTEREST.Text)+", '', '', '', '','"+ TXT_CP_KETERANGAN.Text +"', " +
					""+ tool.ConvertNum(TXT_IDC_RATIO.Text) +","+ tool.ConvertNum(TXT_IDC_JWAKTU.Text) +","+ tool.ConvertDate(TXT_DAYIDC.Text,DDL_MONTHIDC.SelectedValue,TXT_YEARIDC.Text) +","+tool.ConvertNum(TXT_IDC_INTEREST.Text)+","+tool.ConvertNum(TXT_IDC_PVARIANCE.Text)+","+tool.ConvertNum(TXT_IDC_CAPAMNT.Text)+","+tool.ConvertNum(TXT_IDC_CAPRATIO.Text)+","+tool.ConvertNum(TXT_IDC_PRIMERATE.Text)+",'"+TXT_IDC_PRIMEVARCODE.Text+"','',1,2";
				conn.ExecuteQuery();
			}
			else //tanpa IDC
			{
				conn.QueryString = "exec DE_STRUCCREDIT '"+Request.QueryString["regno"]+"', '"+Request.QueryString["prodid"]+"', '"+ DDL_CP_SKREDIT.SelectedValue +"', '"+DDL_CP_LOANPURPOSE.SelectedValue+"', "+tool.ConvertNum(TXT_CP_LIMIT.Text)+", "+tool.ConvertNum(TXT_CP_INSTALLMENT.Text)+", "+tool.ConvertNum(DDL_CP_TENOR.SelectedValue)+", "+tool.ConvertNum(TXT_CP_INTEREST.Text)+",'','','','','"+ TXT_CP_KETERANGAN.Text +"','','','','','','','','','','',0,2";
				conn.ExecuteQuery();
			}
		}

	}
}
