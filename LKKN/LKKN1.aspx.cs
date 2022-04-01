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
using System.Text;

namespace SME.LKKN1
{
	
	public partial class LKKN1 : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn;
		protected CommonForm.DocumentExport DocExport1;
		protected CommonForm.DocumentUpload DocUpload1;
		//sadfsdfsadfsafd
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			ViewBtn.Enabled = false;
			string regno = Request.QueryString["regno"].ToString();
			if (!IsPostBack)
			{
				conn.QueryString = "SELECT * FROM VW_LKKN1 WHERE AP_REGNO ='" + regno + "'";
				conn.ExecuteQuery();

				TXT_CUST_NAME.Text = conn.GetFieldValue("NAMA");
				TXT_ADDR.Text= conn.GetFieldValue("ALAMAT");
				TXT_PHNAREA.Text=conn.GetFieldValue("PHNAREA");
				TXT_PHNNUM.Text=conn.GetFieldValue("PHNNUM");
				TXT_PHNEXT.Text=conn.GetFieldValue("PHNEXT");
				TXT_BRANCH.Text = conn.GetFieldValue("BRANCH_NAME");
				TXT_CONTACTPERSON.Text = conn.GetFieldValue("cu_contactperson");
				TXT_BO.Text = (string) Session["FullName"];

				for (int i = 1; i <= 12; i++)
					DDL_VISIT_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));

				for (int i = 1; i <= 12; i++)
					DDL_TARGET_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));

				conn.QueryString = "SELECT WAKTU = DATENAME(DAY, getDATE())+ ' '+" +
					"DATENAME(MONTH, getDATE()) +' '+ " +
					"DATENAME(YEAR, getDATE())" ;
				conn.ExecuteQuery();
				
				TXT_ENTRYDATE1.Text = conn.GetFieldValue("WAKTU");
				conn.QueryString = "SELECT ENTRYDATE=GETDATE()";
				conn.ExecuteQuery();

				TXT_ENTRYDATE.Text =  conn.GetFieldValue("ENTRYDATE");

				ViewData(regno);

				ViewDataGridPengurus(regno);
				ViewDataGridAgunan(regno);
			
				p_LastSeqPengurus();
				p_LastSeqAgunan();

				DocExport1.GroupTemplate = "LKKNPRINT";
				DocUpload1.GroupTemplate = "LKKNUPLOAD";
				DocUpload1.WithReadExcel = false;
			}

			secureData();
			ViewMenu();			
		}

		private void secureData() 
		{
			string lkkn = Request.QueryString["lkkn"];

			if (lkkn == "0")
			{
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
						for(int idg=0; idg < dg.Items.Count; idg++) 
						{
							dg.Items[idg].Cells[6].Text		= "Delete";
							dg.Items[idg].Cells[6].Enabled	= false;
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

		private bool isDateValid(string dd, string mm, string yyyy)
		{
			bool retVal = false;
			try
			{
				retVal = isDateValid(Int16.Parse(dd), Int16.Parse(mm), Int16.Parse(yyyy));
			}
			catch {}
			return retVal;
		}

		private bool isDateValid(int dd, int mm, int yyyy)
		{
			if ((dd < 1) || (dd > 31) || (mm < 1) || (mm > 12))
				return false;
			if ((yyyy < 1900) || (yyyy > 2100))
			{
				Tools.popMessage(this, "Year must be between 1900 and 2100");
				return false;
			}
			switch (mm)
			{
				case 4 : case 6 : case 9 : case 11 : 
					if (dd > 30) return false;
					break;
				case 2 :
					if (yyyy % 4 == 0)	//kabisat
					{
						if (dd > 29) return false;
					}
					else
					{
						if (dd > 28) return false;
					}
					break;
				default:
					break;
			}
			return true;
		}

		protected override bool OnBubbleEvent(object sender, EventArgs e)
		{
			if(sender is Button || sender is ImageButton)
			{

				WebControl webControl = (WebControl)sender;
				//Debug.WriteLine("Clicked " + webControl.ClientID);
				//GlobalTools.popMessage(this, "OnBubbleEvent()!");
				StringBuilder sb = GetFocusScriptBlock(webControl);
				RegisterClientScriptBlock("FocusScript", sb.ToString());
			}
			return base.OnBubbleEvent(sender, e);
		}

 		private static StringBuilder GetFocusScriptBlock(WebControl webControl)
		{
			StringBuilder sb = new StringBuilder(1000);
			sb.Append("<script language = 'javascript'>");
			sb.Append("function ControlFocus() {");
			sb.Append("document.getElementById('" + webControl.ClientID + "').focus();");
			//sb.Append("Form1." + webControl.ClientID + ".focus();");
			sb.Append("}");
			sb.Append(String.Concat(Environment.NewLine, Environment.NewLine, "window.onload = ControlFocus;"));
			sb.Append("</script>");
			return sb;
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
			this.DATA_PENGURUS.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_PENGURUS_ItemCommand);
			this.DATA_PENGURUS.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_PENGURUS_PageIndexChanged);
			this.DATA_COLLATERAL.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_COLLATERAL_ItemCommand);

		}
		#endregion

		

		protected void SaveBtn_Click(object sender, System.EventArgs e)
		{
			string regno = Request.QueryString["regno"].ToString();
			string curef = Request.QueryString["curef"].ToString();

			////////////////////////////////////////////////////////////
			///	Kalau tulisan button "SAVE" .....
			///	
			if(SaveBtn.Text.ToUpper()=="SAVE")
			{
				//--- Periksa validitas Tanggal Kunjungan
				if (!isDateValid(TXT_VISIT_DAY.Text, DDL_VISIT_MONTH.SelectedValue, TXT_VISIT_YEAR.Text))
				{
					Tools.popMessage(this, "Tanggal kunjungan tidak valid!");
					return;
				}
				//--- Periksa validitas Tanggal Penyelesaian
				if (!isDateValid(TXT_TARGET_DATE.Text, DDL_TARGET_MONTH.SelectedValue, TXT_TARGET_YEAR.Text))
				{
					Tools.popMessage(this, "Tanggal penyelesaian tidak valid!");
					return;
				}

				//--- Tanggal Kunjungan harus <= Tanggal Penyelesaian
				DateTime dk = new DateTime(Convert.ToInt16(TXT_VISIT_YEAR.Text), Convert.ToInt16(DDL_VISIT_MONTH.SelectedValue), Convert.ToInt16(TXT_VISIT_DAY.Text));
				DateTime dp = new DateTime(Convert.ToInt16(TXT_TARGET_YEAR.Text) , Convert.ToInt16(DDL_TARGET_MONTH.SelectedValue), Convert.ToInt16(TXT_TARGET_DATE.Text));
				if (dk > dp) 
				{
					Tools.popMessage(this, "Tanggal Penyelesaian harus lebih besar dari Tanggal Kunjungan!");
					return;
				}

				///////////////////////////////////////////////////////////////////////
				///	save data umum ke database
				///	
				conn.QueryString= " exec SVT_LKKN '" + regno + "', '" + curef + "', '" +
					CBL_KM_PENGALAMAN.SelectedValue + "', '" + 
					CBL_KM_KUALIFIKASI.SelectedValue + "', '" + TXT_KM_LAIN.Text + "', '" + 
					CBL_KM_ADMKEUANGAN.SelectedValue + "', '" +

					CBL_OP_SIFAT.SelectedValue + "', '" +
					CBL_OP_KARAKTER.SelectedValue + "', '" + 
					TXT_OP_PENGALAMAN.Text + "', '" + 
					CBL_OP_ORGANISASI.SelectedValue + "', '" +
					TXT_OP_LAIN.Text + "', '" + 
				
					CBL_OAT_DAERAH.SelectedValue +"', '" + 
					CBL_OAT_LOKASI.SelectedValue + "', " +
					GlobalTools.ConvertNum(TXT_OAT_LUASTANAH.Text) + ", " + 
					GlobalTools.ConvertNum(TXT_OAT_LUASBANGUNAN.Text) + ", '" + 
					CBL_OAT_KONDISI.SelectedValue + "', '" +
					CBL_OAT_STATUS.SelectedValue + "', '" + CBL_OAT_UTILISASI.SelectedValue + "', '" +
					CBL_OAT_PERALATAN.SelectedValue +"', '"+  CBL_OAT_PRASARANA.SelectedValue + "', '" +
					CBL_OAT_BAHANBAKU.SelectedValue +"', '"+ TXT_OAT_PROSESPROD.Text + "', '" + 
					TXT_OAT_SUPLIER.Text + "', " +
					GlobalTools.ConvertNum(TXT_OAT_REALISASIKUANTUM.Text) + ", " + 
					GlobalTools.ConvertFloat(TXT_OAT_REALISASINILAI.Text) + ", " + 
					GlobalTools.ConvertNum(TXT_OAT_TARGETKUANTUM.Text) + ", " +
					GlobalTools.ConvertFloat(TXT_OAT_TARGETNILAI.Text) + ", " + 
					GlobalTools.ConvertFloat(TXT_OAT_BIAYA.Text) + ", "	+ 
					GlobalTools.ConvertNum(TXT_OAT_KARYAWAN.Text) + ", '" +		
					TXT_OAT_LAIN.Text +"', '"+ 
				
					TXT_OAP_PRODUK.Text + "', '" + CBL_OAP_PROSPEK.SelectedValue + "', '" +
					TXT_OAP_PELANGGAN.Text + "', '" + CBL_OAP_PERSAINGAN.SelectedValue + "', '" + 
					TXT_OAP_PESAING.Text + "', '" +
					TXT_OAP_LOKASIPESAING.Text + "', '" + CBL_OAP_HARGA.SelectedValue +"', '" + 
					CBL_OAP_DISTRIBUSI.SelectedValue + "', '" +
					CBL_OAP_PENJUALAN.SelectedValue +"', '" + CBL_OAP_PROMOSI.SelectedValue +"', "+  
					GlobalTools.ConvertNum(TXT_OAP_JUALKUANTUM.Text) + ", " +
					GlobalTools.ConvertFloat(TXT_OAP_JUALNILAI.Text) + ", " + 
					GlobalTools.ConvertNum(TXT_OAP_TARGETKUANTUM.Text) +", " + 
					GlobalTools.ConvertFloat(TXT_OAP_TARGETNILAI.Text) +", '" +
					TXT_OAP_LAIN.Text + "', " + GlobalTools.ConvertFloat(TXT_OAK_POSISI.Text) + ", " + 
					GlobalTools.ConvertFloat(TXT_OAK_KAS.Text) + ", " +
					GlobalTools.ConvertFloat(TXT_OAK_PIUTANG.Text) + ", " + 
					GlobalTools.ConvertFloat(TXT_OAK_PERSEDIAAN.Text) + ", " + 
					GlobalTools.ConvertFloat(TXT_OAK_AKTIVATTP.Text) + ", " +
					GlobalTools.ConvertFloat(TXT_OAK_HTGDAGANG.Text) + ", " + 
					GlobalTools.ConvertFloat(TXT_OAK_HTGBANK.Text) + ", " 
								
					+ GlobalTools.ConvertFloat(TXT_OAK_MODAL.Text) + ", '" +
					TXT_OAK_BIAYAPROYEK.Text + "', '" + 
				
					CBL_OLL_JUMLAH.SelectedValue + "', '" + 
					CBL_OLL_KEADAAN.SelectedValue + "', '" +
				
					CBL_OLL_DAMPAK.SelectedValue + "', '" + TXT_OLL_JUMLAHLAIN.Text + "', '" + 
					TXT_KETERANGAN.Text + "', '" +
					TXT_TINDAKLANJUT.Text + "', " + 
					tools.ConvertDate(TXT_TARGET_DATE.Text, DDL_TARGET_MONTH.SelectedValue,TXT_TARGET_YEAR.Text) + ", '" + 
					TXT_CONTACTPERSON.Text + "', " +
					tools.ConvertDate(TXT_VISIT_DAY.Text,DDL_VISIT_MONTH.SelectedValue,TXT_VISIT_YEAR.Text) + ", " + 
					tools.ConvertDate(tools.FormatDate_Day(TXT_ENTRYDATE.Text),tools.FormatDate_Month(TXT_ENTRYDATE.Text),tools.FormatDate_Year(TXT_ENTRYDATE.Text))+ ", '" +
					TXT_BO.Text + "', '" + TXT_ATASAN.Text + "', '" + TXT_PEMBUAT.Text + "', '" +
					TXT_OAP_DISTRIBUSILAIN.Text + "', '" + TXT_OAP_PENJUALANLAIN.Text + "', '" + 
					TXT_OAP_PROMOSILAIN.Text + "'";
				
				conn.ExecuteNonQuery();


				/////////////////////////////////////////////////////////////
				///	sava data agunan ke database
				///	
				for (int i= 0 ; i< DATA_COLLATERAL.Items.Count;i++)
				{
					if ((DATA_COLLATERAL.Items[i].Cells[0].Text.Trim() != "&nbsp;")&&(DATA_COLLATERAL.Items[i].Cells[1].Text.Trim()!="&nbsp;")&&(DATA_COLLATERAL.Items[i].Cells[2].Text.Trim() !="&nbsp;")&&(DATA_COLLATERAL.Items[i].Cells[3].Text.Trim() !="&nbsp;")&&(DATA_COLLATERAL.Items[i].Cells[4].Text!="")&&(DATA_COLLATERAL.Items[i].Cells[5].Text.Trim() !="&nbsp;"))
					{
						conn.QueryString= "exec SVT_LKKN_AGUNAN '" + 
							regno + "', '" + curef + "', " + 
							DATA_COLLATERAL.Items[i].Cells[0].Text + ", '" +
							DATA_COLLATERAL.Items[i].Cells[1].Text + "', "+ 
							GlobalTools.ConvertFloat(DATA_COLLATERAL.Items[i].Cells[2].Text) +", '"+
							DATA_COLLATERAL.Items[i].Cells[3].Text + "', '" + 
							DATA_COLLATERAL.Items[i].Cells[4].Text +"', '"+
							DATA_COLLATERAL.Items[i].Cells[5].Text + "'";
						conn.ExecuteNonQuery();
					}
				}
			
				////////////////////////////////////////////////////////////////
				/// save data pengurus ke database
				/// 
				for (int i=0 ; i< DATA_PENGURUS.Items.Count;i++)
				{
					if ((DATA_PENGURUS.Items[i].Cells[0].Text!="&nbsp;")&&(DATA_PENGURUS.Items[i].Cells[1].Text!="&nbsp;")&&(DATA_PENGURUS.Items[i].Cells[2].Text!="&nbsp;")&&(DATA_PENGURUS.Items[i].Cells[3].Text!="&nbsp;")&&(DATA_PENGURUS.Items[i].Cells[4].Text!="&nbsp;")&&(DATA_PENGURUS.Items[i].Cells[5].Text!="&nbsp;"))
					{
						conn.QueryString= "exec SVT_LKKN_PENGURUS '" + regno + "', '" + curef + "', " + 
							DATA_PENGURUS.Items[i].Cells[0].Text + ", '" +
							DATA_PENGURUS.Items[i].Cells[1].Text + "', '"+ 
							DATA_PENGURUS.Items[i].Cells[2].Text +"', "+
							GlobalTools.ConvertFloat(DATA_PENGURUS.Items[i].Cells[3].Text) + ", '" + 
							DATA_PENGURUS.Items[i].Cells[4].Text +"', '"+
							DATA_PENGURUS.Items[i].Cells[5].Text + "'";
						conn.ExecuteNonQuery();

					}
				}

				ViewDataGridPengurus(regno);
				ViewDataGridAgunan(regno);

				ViewBtn.Enabled = true;
				BTN_UPDATE.Enabled = true;

			}
			else
			{
				p_ShowPengurus(regno);
				p_ShowAgunan(regno);
			}

			/////////////////////////////////////////////////////////////////
			/// store procedure untuk audit trail
			/// 
	
			//ahmad

			//try
			//{
			/// Site visit oleh siapa
			/// 
//			try
//			{
//				conn.QueryString = "SP_AUDITTRAIL_APP '" + 
//					Request.QueryString["regno"] + "',null,null,null,'" + 
//					Request.QueryString["curef"] + "','" + 
//					Request.QueryString["tc"] + "','Site visit by','"+ 
//					TXT_PEMBUAT.Text + "','" +  
//					Session["UserID"].ToString() + "',null,null";
//				conn.ExecTrans();
//			}
//			catch
//			{
//			}


			try
			{
				/// Site visit tanggal kunjungan
				/// 
				conn.QueryString = "SP_AUDITTRAIL_APP '" + 
					Request.QueryString["regno"] + "',null,null,null,'" + 
					Request.QueryString["curef"] + "','" + 
					Request.QueryString["tc"] + "','Site visit start date [" + TXT_VISIT_DAY.Text + "-" + DDL_VISIT_MONTH.SelectedValue + "-" + TXT_VISIT_YEAR.Text + "]','" +  
					TXT_VISIT_DAY.Text + "-" + DDL_VISIT_MONTH.SelectedValue + "-" + TXT_VISIT_YEAR.Text + "', '" +
					Session["UserID"].ToString() + "',null,null";
				conn.ExecTrans();

				/// Site visit tanggal selesai
				/// 
				conn.QueryString = "SP_AUDITTRAIL_APP '" + 
					Request.QueryString["regno"] + "',null,null,null,'" + 
					Request.QueryString["curef"] + "','" + 
					Request.QueryString["tc"] + "','Site visit finish date [" + TXT_TARGET_DATE.Text + "-" + DDL_TARGET_MONTH.SelectedValue + "-" + TXT_TARGET_YEAR.Text + "]', '" +  
					TXT_TARGET_DATE.Text + "-" + DDL_TARGET_MONTH.SelectedValue + "-" + TXT_TARGET_YEAR.Text + "', '" +
					Session["UserID"].ToString() + "',null,null";
				conn.ExecTrans();

				conn.ExecTran_Commit();
			} 
			catch (Exception ex)
			{
				if (conn != null) conn.ExecTran_Rollback();
				ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "AP_REGNO: " + Request.QueryString["regno"]);
			}

			OnBubbleEvent(sender, e);
		}

		protected void UpdateBtn_Click(object sender, System.EventArgs e)
		{			
			Response.Redirect("LKKNPrint.aspx?BRANCH=" + TXT_BRANCH.Text + "&regno=" + Request.QueryString["regno"]);
			BTN_UPDATE.Enabled = true;
		}

		private void ViewDataGridPengurus(string regno)
		{
			DataTable dt1;
			conn.QueryString = "select *, case when LP_BLACKLIST = 'T' then 'TIDAK' else 'YA' end LP_BLACKLISTDESC from LKKNPENGURUS where ap_regno='" + regno + "'";
			conn.ExecuteQuery();
			
			if(conn.GetRowCount()>0)
			{
				dt1 = conn.GetDataTable().Copy();
				Session.Add("dataTable1",dt1);
				DATA_PENGURUS.DataSource = dt1;
				DATA_PENGURUS.DataBind();
			}
			else
				p_ShowPengurus(regno);
		}

		private void ViewDataGridAgunan(string regno)
		{
            DataTable dt2;
			conn.QueryString = "select * from LKKNAGUNAN where ap_regno='" + regno + "'";
			conn.ExecuteQuery();

			if(conn.GetRowCount()>0)
			{
				dt2 = conn.GetDataTable().Copy();
				Session.Add("dataTable2",dt2);
				DATA_COLLATERAL.DataSource = dt2;
				DATA_COLLATERAL.DataBind();
			}
			else
				p_ShowAgunan(regno);
		}

		private void p_ShowPengurus(string regno)
		{
			string curef = Request.QueryString["curef"];
			
			conn.QueryString = "select * from VIEW_LKKN_PENGURUS where ap_regno = '" + regno + "'";
			conn.ExecuteQuery();

			DataTable dt1;
			dt1 = conn.GetDataTable().Copy();
			Session.Add("dataTable1",dt1);
			DATA_PENGURUS.DataSource = dt1;
			if (conn.GetRowCount() > 0)
			{
				DATA_PENGURUS.DataBind();
				SaveBtn.Text = "Save";
			}
			for(int i = 0; i < DATA_PENGURUS.Items.Count ;i++)
			{
				string NM = DATA_PENGURUS.Items[i].Cells[1].Text;
				if(NM=="&nbsp;")NM="";
				string JAB = DATA_PENGURUS.Items[i].Cells[2].Text;
				if(JAB=="&nbsp;")JAB="";
				string SHM = GlobalTools.ConvertFloat(DATA_PENGURUS.Items[i].Cells[3].Text);
				if(SHM=="&nbsp;")SHM="0";
				string DIK = DATA_PENGURUS.Items[i].Cells[4].Text;
				if(DIK=="&nbsp;")DIK="";
				string YT = DATA_PENGURUS.Items[i].Cells[7].Text;
				if(YT=="&nbsp;")YT="";

				conn.QueryString= "exec SVT_LKKN_PENGURUS '" + 
					regno + "', '" + curef + "', " + i.ToString() + ", '" + NM + "', '"+ 
					JAB +"', "+ SHM + ", '" + DIK +"', '" + YT + "'";
				conn.ExecuteNonQuery();
			}
		}

		private void p_ShowAgunan(string regno)
		{
			string curef = Request.QueryString["curef"];
			
			conn.QueryString = "select * from VIEW_LKKN_AGUNAN where ap_regno = '" + regno + "'";
			conn.ExecuteQuery();

			DataTable dt1;
			dt1 = conn.GetDataTable().Copy();
			Session.Add("dataTable2",dt1);
			DATA_COLLATERAL.DataSource = dt1;
			if (conn.GetRowCount() > 0)
			{
				DATA_COLLATERAL.DataBind();
				SaveBtn.Text = "Save";
			}
			for(int i = 0; i < DATA_COLLATERAL.Items.Count ;i++)
			{
				string NM = DATA_COLLATERAL.Items[i].Cells[1].Text;
				if(NM=="&nbsp;")NM="";
				string JAB = DATA_COLLATERAL.Items[i].Cells[2].Text;
				if(JAB=="&nbsp;")JAB="";
				string SHM = DATA_COLLATERAL.Items[i].Cells[3].Text;
				if(SHM=="&nbsp;")SHM="0";
				string DIK = DATA_COLLATERAL.Items[i].Cells[4].Text;
				if(DIK=="&nbsp;")DIK="";
				string AN = DATA_COLLATERAL.Items[i].Cells[5].Text;
				if(AN=="&nbsp;")AN="";


				conn.QueryString= "exec SVT_LKKN_AGUNAN '" + 
					regno + "', '" + curef + "', " + 
					i.ToString() + ", '" + 
					NM + "', " + 
					GlobalTools.ConvertFloat(JAB) +", '"+ 
					SHM + "', '" + 
					DIK + "', '" + 
					AN + "'";
				conn.ExecuteNonQuery();
			}
		}

		protected void Add_Agunan_Btn_Click(object sender, System.EventArgs e)
		{
			if(this.TXT_BUKTI_KEPEMILIKAN.Text == string.Empty)
			{
				GlobalTools.popMessage(this, "Bukti Kepemilikan harus diisi");
				return;
			}
			string regno = Request.QueryString["regno"];
			string curef = Request.QueryString["curef"];

			conn.QueryString = "exec SVT_LKKN_AGUNAN '" + 
				regno + "', '" + curef + "', '" +
				LBL_AGN.Text + "', '" + 
				TXT_JENIS_AGUNAN.Text + "', '" + 
				GlobalTools.ConvertFloat(TXT_NILAI.Text) + "', '" +
				TXT_LOKASI.Text + "', '" +
				TXT_BUKTI_KEPEMILIKAN.Text + "','" + 
				TXT_ATAS_NAMA.Text + "'";
			conn.ExecuteNonQuery();
			
			if(Add_Agunan_Btn.Text=="Save")
				Add_Agunan_Btn.Text="Add";

			Cancel_Agunan.Visible = false;

			ViewDataGridAgunan(regno);
			p_ClearAgunan();
			p_LastSeqAgunan();

			OnBubbleEvent(sender, e);
		}

		protected void Add_Pengurus_Btn_Click(object sender, System.EventArgs e)
		{
			if(this.TXT_NAMA.Text == string.Empty)
			{
				GlobalTools.popMessage(this, "Nama Pengurus harus diisi");
				return;
			}

			string regno = Request.QueryString["regno"];
			string curef = Request.QueryString["curef"];

			conn.QueryString = "exec SVT_LKKN_PENGURUS '" + regno + "', '" + curef + "', " +
				LBL_SEQ.Text + ",'" + 
				TXT_NAMA.Text + "','" + 
				TXT_JABATAN.Text + "'," +
				GlobalTools.ConvertFloat(TXT_JUMLAH_SAHAM.Text) + ",'" + 
				TXT_PENDIDIKAN.Text + "','" + 
				DDL_DAFTAR_HITAM.SelectedValue + "'";
			conn.ExecuteNonQuery();

			if(Add_Pengurus_Btn.Text=="Save")
				Add_Pengurus_Btn.Text="Add";

			Cancel_Pengurus_Btn.Visible = false;

			ViewDataGridPengurus(regno);
			p_ClearPengurus();
			p_LastSeqPengurus();

			OnBubbleEvent(sender, e);
		}

		private void p_LastSeqPengurus()
		{	
			//LBL_SEQ.Text = DATA_PENGURUS.Items.Count.ToString();

			/////////////////////////////////////////////////////////////////////////////
			/// Get the maximum sequence, then plus one to get the last sequence
			/// 
			conn.QueryString = "select isnull(max(seq) + 1,0) seq from LKKNPENGURUS where ap_regno = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			LBL_SEQ.Text = conn.GetFieldValue("seq");
		}

		private void p_LastSeqAgunan()
		{	
			//LBL_AGN.Text = DATA_COLLATERAL.Items.Count.ToString();

			/////////////////////////////////////////////////////////////////////////////
			/// Get the maximum sequence, then plus one to get the last sequence
			/// 
			conn.QueryString = "select isnull(max(seq) + 1,0) seq from LKKNAGUNAN where ap_regno = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			LBL_AGN.Text = conn.GetFieldValue("seq");
		}

		private void DATA_PENGURUS_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
		
			string regno = Request.QueryString["regno"];
			string seq = null;

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":

					seq = e.Item.Cells[0].Text;
				
					DataTable dt;
					dt = (DataTable) Session["dataTable1"];
												
					for (int i = 0; i < dt.Rows.Count; i++)
					{
						if (dt.Rows[i].RowState.ToString() == "Deleted") continue;
						if (dt.Rows[i]["SEQ"].ToString() == seq)
						{
							dt.Rows[i].Delete();
							break;
						}
					}

					Session.Remove("dataTable1");
					Session.Add("dataTable1", dt);

					DATA_PENGURUS.DataSource = dt;
					DATA_PENGURUS.DataBind();
				
					conn.QueryString = "delete from lkknpengurus where ap_regno='" +regno + "'"+
						" and SEQ = '" + seq + "' ";					
					conn.ExecuteNonQuery();

					break;

				case "view":
					Add_Pengurus_Btn.Text = "Save";
					Cancel_Pengurus_Btn.Visible = true;

					string NM = e.Item.Cells[1].Text;
					if(NM=="&nbsp;")NM="";
					string JAB = e.Item.Cells[2].Text;
					if(JAB=="&nbsp;")JAB="";
					string SHM = e.Item.Cells[3].Text;
					if(SHM=="&nbsp;")SHM="0";
					string DIK = e.Item.Cells[4].Text;
					if(DIK=="&nbsp;")DIK="";

					LBL_SEQ.Text = e.Item.Cells[0].Text;
					TXT_NAMA.Text = NM;
					TXT_JABATAN.Text = JAB;
					TXT_JUMLAH_SAHAM.Text = SHM;
					TXT_PENDIDIKAN.Text = DIK;
					DDL_DAFTAR_HITAM.SelectedValue = e.Item.Cells[7].Text;
					break;
			}
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				string mc1 = Request.QueryString["mc"];
				string mc2 = Request.QueryString["mc"];
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						//t.ForeColor = Color.MidnightBlue; 
						if (conn.GetFieldValue(i,3).IndexOf("?lkkn=") < 0 && conn.GetFieldValue(i,3).IndexOf("&lkkn=") < 0) 
							strtemp = strtemp + "&lkkn=" + Request.QueryString["lkkn"];
						//strtemp = strtemp + "&de=" + Request.QueryString["de"];
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void DATA_COLLATERAL_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string regno = Request.QueryString["regno"];
			string seq2 = null;

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":

					seq2 = e.Item.Cells[0].Text;
					
					DataTable dt2;
					dt2 = (DataTable) Session["dataTable2"];
												
					for (int i = 0; i < dt2.Rows.Count; i++)
					{
						if (dt2.Rows[i].RowState.ToString() == "Deleted") continue;
						if (dt2.Rows[i]["SEQ"].ToString() == seq2)
						{
							dt2.Rows[i].Delete();
							break;
						}
					}
					
					Session.Remove("dataTable2");
					Session.Add("dataTable2", dt2);

					DATA_COLLATERAL.DataSource = dt2;
					DATA_COLLATERAL.DataBind();

					conn.QueryString="delete from lkknagunan where ap_regno='" + regno + "'"+
						" and SEQ = '" + seq2 + "' ";					
					conn.ExecuteNonQuery();

					break;
				case "view":
					Add_Agunan_Btn.Text = "Save";
					Cancel_Agunan.Visible = true;
					
					
					string JNS = e.Item.Cells[1].Text;
					if(JNS=="&nbsp;")JNS="";
					string NIL = e.Item.Cells[2].Text;
					if(NIL=="&nbsp;")NIL="0";
					string LOK = e.Item.Cells[3].Text;
					if(LOK=="&nbsp;")LOK="";
					string BKK = e.Item.Cells[4].Text;
					if(BKK=="&nbsp;")BKK="";
					string AN = e.Item.Cells[5].Text;
					if(AN=="&nbsp;")AN="";

					LBL_AGN.Text = e.Item.Cells[0].Text;
					TXT_JENIS_AGUNAN.Text = JNS;
					TXT_NILAI.Text = NIL;
					TXT_LOKASI.Text = LOK;
					TXT_BUKTI_KEPEMILIKAN.Text = BKK;
					TXT_ATAS_NAMA.Text = AN;
					break;
			}
		}

		private void ViewData(string regno )
		{
			conn.QueryString= " SELECT * FROM LKKN WHERE AP_REGNO ='"+ regno +"'" ;
			conn.ExecuteQuery();
			if(conn.GetRowCount() > 0)
			{
				ViewBtn.Enabled = true;

				TXT_BO.Text = conn.GetFieldValue("SBO");
				TXT_OAP_TARGETKUANTUM.Text	= conn.GetFieldValue("OAP_TARGETKUANTUM");
				TXT_CONTACTPERSON.Text = conn.GetFieldValue("CONTACTPERSON");
				TXT_KM_LAIN.Text = conn.GetFieldValue("KM_LAIN");
				TXT_OP_PENGALAMAN.Text = conn.GetFieldValue("OP_PENGALAMAN");
				TXT_OP_LAIN.Text = conn.GetFieldValue("OP_LAIN");
				TXT_OAT_LUASTANAH.Text = conn.GetFieldValue("OAT_LUASTANAH");
				TXT_OAT_LUASBANGUNAN.Text = conn.GetFieldValue("OAT_LUASBANGUNAN");
			
				try
				{CBL_KM_PENGALAMAN.SelectedValue = conn.GetFieldValue("KM_PENGALAMAN");}	
				catch{}
				try
				{CBL_KM_ADMKEUANGAN.SelectedValue = conn.GetFieldValue("KM_ADMKEUANGAN"); } 
				catch{}
				try 
				{
					CBL_KM_KUALIFIKASI.SelectedValue = conn.GetFieldValue("KM_KUALIFIKASI"); } 
				catch{}

				try 
				{
					CBL_OP_SIFAT.SelectedValue = conn.GetFieldValue("OP_SIFAT"); 	} 
				catch{}
				try
				{
					CBL_OP_KARAKTER.SelectedValue = conn.GetFieldValue("OP_KARAKTER");	} 
				catch{}
				try
				{
					CBL_OP_ORGANISASI.SelectedValue = conn.GetFieldValue("OP_ORGANISASI");	} 
				catch{}
				try
				{
					CBL_OAT_DAERAH.SelectedValue = conn.GetFieldValue("OAT_DAERAH");	} 
				catch{}
				try
				{
					CBL_OAT_LOKASI.SelectedValue = conn.GetFieldValue("OAT_LOKASI");	} 
				catch{}
				try
				{
					CBL_OAT_KONDISI.SelectedValue = conn.GetFieldValue("OAT_KONDISI");	} 
				catch{}
				try
				{
					CBL_OAT_STATUS.SelectedValue = conn.GetFieldValue("OAT_STATUS");	} 
				catch{}
				try
				{
					CBL_OAT_UTILISASI.SelectedValue = conn.GetFieldValue("OAT_UTILISASI");	} 
				catch{}
				try
				{
					CBL_OAT_PERALATAN.SelectedValue = conn.GetFieldValue("OAT_PERALATAN");	} 
				catch{}
				try
				{
					CBL_OAT_PRASARANA.SelectedValue = conn.GetFieldValue("OAT_PRASARANA");	} 
				catch{}
				try
				{
					CBL_OAT_BAHANBAKU.SelectedValue = conn.GetFieldValue("OAT_BAHANBAKU");	} 
				catch{}
		 
				TXT_OAT_PROSESPROD.Text = conn.GetFieldValue("OAT_PROSESPROD");
				TXT_OAT_SUPLIER.Text = conn.GetFieldValue("OAT_SUPLIER");
				TXT_OAT_REALISASIKUANTUM.Text = conn.GetFieldValue("OAT_REALISASIKUANTUM");
				TXT_OAT_REALISASINILAI.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAT_REALISASINILAI"));
				TXT_OAT_TARGETKUANTUM.Text = conn.GetFieldValue("OAT_TARGETKUANTUM");
				TXT_OAT_TARGETNILAI.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAT_TARGETNILAI"));
				TXT_OAT_BIAYA.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAT_BIAYA"));
				TXT_OAT_KARYAWAN.Text = conn.GetFieldValue("OAT_KARYAWAN");
				TXT_OAT_LAIN.Text = conn.GetFieldValue("OAT_LAIN");
			
				TXT_OAP_PRODUK.Text = conn.GetFieldValue("OAP_PRODUK");
				try
				{
					CBL_OAP_PROSPEK.SelectedValue = conn.GetFieldValue("OAP_PROSPEK");	} 
				catch{}
				TXT_OAP_PELANGGAN.Text = conn.GetFieldValue("OAP_PELANGGAN");
				try
				{
					CBL_OAP_PERSAINGAN.SelectedValue = conn.GetFieldValue("OAP_PERSAINGAN");	} 
				catch{}
				TXT_OAP_PESAING.Text= conn.GetFieldValue("OAP_PESAING");
				TXT_OAP_LOKASIPESAING.Text = conn.GetFieldValue("OAP_LOKASIPESAING");
				try
				{
					CBL_OAP_HARGA.SelectedValue = conn.GetFieldValue("OAP_HARGA");	} 
				catch{}
				try
				{
					CBL_OAP_DISTRIBUSI.SelectedValue = conn.GetFieldValue("OAP_DISTRIBUSI");	} 
				catch{}
				try
				{	
					CBL_OAP_PENJUALAN.SelectedValue = conn.GetFieldValue("OAP_PENJUALAN");	} 
				catch{}
				TXT_OAP_PENJUALANLAIN.Text = conn.GetFieldValue("OAP_PENJUALAN");
				try
				{
					CBL_OAP_PROMOSI.SelectedValue = conn.GetFieldValue("OAP_PROMOSI");	} 
				catch{}
				TXT_OAP_JUALKUANTUM.Text = conn.GetFieldValue("OAP_JUALKUANTUM");
				TXT_OAP_JUALNILAI.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAP_JUALNILAI"));
				TXT_OAP_TARGETKUANTUM.Text = conn.GetFieldValue("OAP_TARGETKUANTUM");
				TXT_OAP_TARGETNILAI.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAP_TARGETNILAI"));
				TXT_OAP_LAIN.Text = conn.GetFieldValue("OAP_LAIN");
				TXT_OAP_DISTRIBUSILAIN.Text = conn.GetFieldValue("OAP_DISTRIBUSILAIN");
				TXT_OAP_PENJUALANLAIN.Text = conn.GetFieldValue("OAP_PENJUALANLAIN");
				TXT_OAP_PROMOSILAIN.Text = conn.GetFieldValue("OAP_PROMOSILAIN");
						
				TXT_OAK_POSISI.Text = conn.GetFieldValue("OAK_POSISI");
				TXT_OAK_KAS.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAK_KAS"));
				TXT_OAK_HTGDAGANG.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAK_HTGDAGANG"));
				TXT_OAK_PIUTANG.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAK_PIUTANG"));
				TXT_OAK_HTGBANK.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAK_HTGBANK"));
				TXT_OAK_PERSEDIAAN.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAK_PERSEDIAAN"));
				TXT_OAK_MODAL.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAK_MODAL"));
				TXT_OAK_AKTIVATTP.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("OAK_AKTIVATTP"));
				TXT_OAK_BIAYAPROYEK.Text = conn.GetFieldValue("OAK_BIAYAPROYEK");
				try
				{
					CBL_OLL_JUMLAH.SelectedValue = conn.GetFieldValue("OLL_JUMLAH");	} 
				catch{}
				TXT_OLL_JUMLAHLAIN.Text = conn.GetFieldValue("OLL_JUMLAHLAIN");
				try
				{
					CBL_OLL_KEADAAN.SelectedValue = conn.GetFieldValue("OLL_KEADAAN");	} 
				catch{}
				try
				{
					CBL_OLL_DAMPAK.SelectedValue = conn.GetFieldValue("OLL_DAMPAK");	} 
				catch{}
				TXT_KETERANGAN.Text = conn.GetFieldValue("KETERANGAN");
				TXT_TINDAKLANJUT.Text = conn.GetFieldValue("TINDAKLANJUT");
			
			
				TXT_ATASAN.Text = conn.GetFieldValue("ATASAN");
				TXT_PEMBUAT.Text = conn.GetFieldValue("PEMBUAT");

				conn.QueryString=("SELECT VISITDAY = DATENAME(DAY, VISITDATE) " +
					",VISITMONTH = MONTH(VISITDATE), VISITYEAR = DATENAME(YEAR, VISITDATE) " +
					",TARGETDAY = DATENAME(DAY, TARGETSELESAI) " +
					",TARGETMONTH = MONTH(TARGETSELESAI), TARGETYEAR = DATENAME(YEAR, TARGETSELESAI) " +
					"FROM LKKN WHERE AP_REGNO ='" + regno + "'");
				conn.ExecuteQuery();

				TXT_VISIT_DAY.Text = conn.GetFieldValue("VISITDAY");
				try {DDL_VISIT_MONTH.SelectedValue = conn.GetFieldValue("VISITMONTH");} 
				catch{}
				TXT_VISIT_YEAR.Text =conn.GetFieldValue("VISITYEAR");
				TXT_TARGET_YEAR.Text = conn.GetFieldValue("TARGETYEAR");
				TXT_TARGET_DATE.Text = conn.GetFieldValue("TARGETDAY");
				try {DDL_TARGET_MONTH.SelectedValue = conn.GetFieldValue("TARGETMONTH");} 
				catch{}

				conn.QueryString = "select * from application  where ap_sitevisitsta='1' and ap_regno='" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				if(conn.GetRowCount() > 0)
					BTN_UPDATE.Visible = false;

			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["tc"] != null && Request.QueryString["tc"] != "")
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}

		protected void Cancel_Pengurus_Btn_Click(object sender, System.EventArgs e)
		{
			p_ClearPengurus();
			OnBubbleEvent(sender, e);
		}
		
		private void p_ClearPengurus()
		{
			TXT_NAMA.Text = "";
			TXT_JUMLAH_SAHAM.Text = "";
			TXT_JABATAN.Text ="";
			TXT_PENDIDIKAN.Text = "";
			DDL_DAFTAR_HITAM.SelectedValue = "T";
			Cancel_Pengurus_Btn.Visible = false;
			Add_Pengurus_Btn.Text = "Add";
		}

		protected void Cancel_Agunan_Click(object sender, System.EventArgs e)
		{
			p_ClearAgunan();
			OnBubbleEvent(sender, e);
		}
		private void p_ClearAgunan()
		{
			TXT_BUKTI_KEPEMILIKAN.Text = "";
			TXT_JENIS_AGUNAN.Text = "";
			TXT_NILAI.Text = "0";
			TXT_LOKASI.Text = "";
			TXT_ATAS_NAMA.Text = "";
			Cancel_Agunan.Visible = false;
			Add_Agunan_Btn.Text = "Add";
		}

		private void DATA_PENGURUS_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			string regno = Request.QueryString["regno"];
			DATA_PENGURUS.CurrentPageIndex = e.NewPageIndex;
			ViewDataGridPengurus(regno);
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			//////////////////////////////////////
			/// saat klik view button,
			/// update status sitevisit, dan 
			/// tampilkan preview untuk print
			/// 
			conn.QueryString = "update application set ap_sitevisitsta='1' where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteNonQuery();
			
			BTN_UPDATE.Visible = false;
			ViewBtn.Enabled = true;

			 //////////////////////////////////////////////
			 /// audit trail
			 
			try
			{
				conn.QueryString = "SP_AUDITTRAIL_APP '" + 
					Request.QueryString["regno"] + "',null,null,null,'" + 
					Request.QueryString["curef"] + "','" + 
					Request.QueryString["tc"] + "','Update LKKN ','"+ 
					TXT_PEMBUAT.Text + "','" +  
					Session["userid"].ToString() + "',null,null";
				conn.ExecuteNonQuery();
			}
			catch
			{
			}
		}
	}
}
