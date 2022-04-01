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
using Excel;
using System.Diagnostics;
using System.IO;


namespace SME.CreditAnalysis.BPR
{
	/// <summary>
	/// Summary description for bprNeraca.
	/// </summary>
	public partial class bprKomDal : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txt_B2;
		protected System.Web.UI.WebControls.TextBox txt_C2;
		protected System.Web.UI.WebControls.TextBox txt_D2;
		protected System.Web.UI.WebControls.TextBox txt_BB33;
		protected System.Web.UI.WebControls.DropDownList ddl_B3;
		protected System.Web.UI.WebControls.DropDownList ddl_C3;
		protected System.Web.UI.WebControls.DropDownList ddl_D3;
		protected System.Web.UI.WebControls.TextBox TXT_PSV_TOTAL1;

		protected Connection conn;
		protected System.Web.UI.WebControls.TextBox TXT_NPL_PPAP_DIRAGUKAN1;
		protected System.Web.UI.WebControls.TextBox TXT_NPL_PPAP_DIRAGUKAN2;
		protected System.Web.UI.WebControls.TextBox TXT_NPL_PPAP_DIRAGUKAN3;
		protected System.Web.UI.WebControls.TextBox TXT_NPL_PPAP_MACET1;
		protected System.Web.UI.WebControls.TextBox TXT_NPL_PPAP_MACET2;
		protected System.Web.UI.WebControls.TextBox TXT_NPL_PPAP_MACET3;
		protected Connection2 conn2;
		private double totalAktiva;
		protected System.Web.UI.WebControls.TextBox Textbox13;
		protected System.Web.UI.WebControls.TextBox Textbox14;
		protected System.Web.UI.WebControls.TextBox Textbox15;
		protected System.Web.UI.WebControls.TextBox Textbox7;
		private double totalPasiva;
		//protected Tools tool = new Tools();
	
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			conn2 = new Connection2();
			
			if(!IsPostBack)
			{
				IsiTanggal();
				retrieve_data();
				
			}	

			ViewMenu();
			ViewSubMenu();
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

		private void IsiTanggal()
		{
			GlobalTools.initDateFormINA(txt_DD_B1, ddl_MM_B1, txt_YY_B1, true);
			GlobalTools.initDateFormINA(txt_DD_B2, ddl_MM_B2, txt_YY_B2, true);
		}

		private void ViewData()
		{
			conn2.QueryString = "SELECT SYSCOLUMNS.[name] FROM SYSOBJECTS, SYSCOLUMNS WHERE SYSOBJECTS.[name] = 'CA_KOMDAL_BPR' AND SYSCOLUMNS.[ID] = SYSOBJECTS.[ID] AND SYSCOLUMNS.[name] not in ('CU_REF','AP_REGNO','SEQ')";
			conn2.ExecuteQuery();

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "1");
				System.Web.UI.WebControls.TextBox txt2 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "2");
				
				if(conn2.GetFieldValue(i,"name") != "POSISI_TGL" && conn2.GetFieldValue(i,"name") != "DDAY" && conn2.GetFieldValue(i,"name") != "DMONTH" && conn2.GetFieldValue(i,"name") != "DYEAR")
				{
					if(conn.GetFieldValue(0,conn2.GetFieldValue(i,"name")).ToString() != "")
					{
						txt1.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(0,conn2.GetFieldValue(i,"name")));
					}
					else
					{
						txt1.Text = "";
					}

					if(conn.GetFieldValue(1,conn2.GetFieldValue(i,"name")).ToString() != "")
					{
						txt2.Text = GlobalTools.MoneyFormat(conn.GetFieldValue(1,conn2.GetFieldValue(i,"name")));
					}
					else
					{
						txt2.Text = "";
					}
				}
				else
				{
					//GlobalTools.ToSQLDate(txt_DD_B1.Text, ddl_MM_B1.SelectedValue, txt_YY_B1.Text) 

					TXT_JUMLAH_BULAN1.Text = conn.GetFieldValue(0,"JML_BLN");
					TXT_JUMLAH_BULAN2.Text = conn.GetFieldValue(1,"JML_BLN");

					txt_DD_B1.Text = conn.GetFieldValue(0,"DDAY");
					txt_DD_B2.Text = conn.GetFieldValue(1,"DDAY");

					ddl_MM_B1.SelectedValue = conn.GetFieldValue(0,"DMONTH");
					ddl_MM_B2.SelectedValue = conn.GetFieldValue(1,"DMONTH");

					txt_YY_B1.Text = conn.GetFieldValue(0,"DYEAR");
					txt_YY_B2.Text = conn.GetFieldValue(1,"DYEAR");
				}
			}
		}


		/// <summary>
		/// Memeriksa validitas tanggal dari form input
		/// </summary>
		/// <returns></returns>
		private bool cekTanggal()
		{
			if (txt_DD_B1.Text != "" && ddl_MM_B1.SelectedIndex > 0 && txt_YY_B1.Text != "")
				if(!GlobalTools.isDateValid(this,txt_DD_B1.Text,ddl_MM_B1.SelectedValue,txt_YY_B1.Text))
				{
					GlobalTools.popMessage(this, "Data/Number of Months tidak valid!");
					return false;
				}
			
			if (txt_DD_B2.Text != "" && ddl_MM_B2.SelectedIndex > 0 && txt_YY_B2.Text != "")
				if(!GlobalTools.isDateValid(this,txt_DD_B2.Text,ddl_MM_B2.SelectedValue,txt_YY_B2.Text))
				{
					GlobalTools.popMessage(this, "Data/Number of Months tidak valid!");
					return false;
				}

			return true;
		}

		private void CalculatePertumbuhan()
		{
			conn2.QueryString = "SELECT SYSCOLUMNS.[name] FROM SYSOBJECTS, SYSCOLUMNS WHERE SYSOBJECTS.[name] = 'CA_KOMDAL_BPR' AND SYSCOLUMNS.[ID] = SYSOBJECTS.[ID] AND SYSCOLUMNS.[name] not in ('CU_REF','AP_REGNO','SEQ','POSISI_TGL','JML_BLN')";
			conn2.ExecuteQuery();
			double pertumbuhan;

			for(int i =0; i<conn2.GetRowCount(); i++)
			{
				System.Web.UI.WebControls.TextBox txt1 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "1");
				System.Web.UI.WebControls.TextBox txt2 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "2");
				System.Web.UI.WebControls.TextBox txt3 = (System.Web.UI.WebControls.TextBox) this.FindControl("TXT_" + conn2.GetFieldValue(i,"name") + "3");

				string id1 = txt1.ID;
				string id2 = txt2.ID;

				string isi1 = txt1.Text.ToString();
				string isi2 = txt2.Text.ToString();

				//txt1.Text = conn.GetFieldValue(0,conn2.GetFieldValue("name"));
				//txt2.Text = conn.GetFieldValue(1,conn2.GetFieldValue("name"));
				/*double a = MyConnection.ConvertToDouble2(txt1.Text);
				double b = MyConnection.ConvertToDouble2(txt2.Text);*/

				if(txt1.Text.ToString() != "" && txt2.Text.ToString() != "")
				{
					if(MyConnection.ConvertToDouble2(txt1.Text.Replace(",",".")) > 0.00 || MyConnection.ConvertToDouble2(txt1.Text.Replace(",",".")) < 0.00)
					{
						pertumbuhan = (MyConnection.ConvertToDouble2(txt2.Text.Replace(",",".")) - MyConnection.ConvertToDouble2(txt1.Text.Replace(",","."))) / MyConnection.ConvertToDouble2(txt1.Text.Replace(",",".")) * 100;
					}
					else
					{
						if(MyConnection.ConvertToDouble2(txt2.Text.Replace(",",".")) > 0.00 || MyConnection.ConvertToDouble2(txt2.Text.Replace(",",".")) < 0.00)
						{
							pertumbuhan = (MyConnection.ConvertToDouble2(txt2.Text.Replace(",",".")) / 1.00) * 100;
						}
						else
						{
							pertumbuhan = 0.0;
						}
					}
					txt3.Text = GlobalTools.MoneyFormat(pertumbuhan.ToString()) + "%";
				}
				else
				{
					txt3.Text = "";
				}
			}
		}


		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink("",Request.QueryString["mc"].ToString(), conn));
		}

		private void secureData() 
		{
			if (Request.QueryString["ca"]=="0") 
			{
				int kk = 0, index = -1;
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for (kk = 0; kk < coll.Count; kk++) 
				{
					if (coll[kk] is System.Web.UI.HtmlControls.HtmlForm) 
					{
						index = kk;
						break;
					}
				}

				if (index == -1) return;
				if (kk == coll.Count) return;

				for (int i = 0; i < coll[index].Controls.Count; i++) 
				{
					if (coll[index].Controls[i] is System.Web.UI.WebControls.TextBox) 
					{
						System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) coll[index].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[index].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[index].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[index].Controls[i] is System.Web.UI.WebControls.Button)
					{
						System.Web.UI.WebControls.Button btn = (System.Web.UI.WebControls.Button) coll[index].Controls[i];
						btn.Visible = false;
					}
					else if (coll[index].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[index].Controls[i];

						for (int j=0; j < htr.Controls.Count; j++) 
						{							
							for (int jj = 0; jj < htr.Controls[j].Controls.Count; jj++) 
							{
								if (htr.Controls[j].Controls[jj] is System.Web.UI.WebControls.TextBox) 
								{
									System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) htr.Controls[j].Controls[jj];
									txt.ReadOnly = true;
								}
								else if (htr.Controls[j].Controls[jj] is DropDownList) 
								{
									DropDownList ddl = (DropDownList) htr.Controls[j].Controls[jj];
									ddl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is System.Web.UI.WebControls.Button)
								{
									System.Web.UI.WebControls.Button btn = (System.Web.UI.WebControls.Button) htr.Controls[j].Controls[jj];
									btn.Visible = false;
								}
							}
						}
					}
				}
			}
		}


		private void retrieve_data()
		{
			string regno =  Request.QueryString["regno"];
			string curef = Request.QueryString["curef"];

			conn.QueryString = "EXEC BPR_GETKOMDAL '" + curef + "','" + regno + "'";
			conn.ExecuteQuery();

			if(conn.GetRowCount() != 0)
			{
				ViewData();
				CalculatePertumbuhan();
			}
		}
	
		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select SM_ID,MENUCODE,SM_MENUDISPLAY,SM_LINKNAME from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						else	
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = "../" + conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}
		
	
		private void ViewSubMenu()
		{
			try 
			{
				string sProgramID,sJnsNasabah;

				conn.QueryString = "select distinct top 1 cu_jnsnasabah from customer where cu_ref in (Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+ "')";
				conn.ExecuteQuery();
				sJnsNasabah = conn.GetFieldValue("cu_jnsnasabah").ToString();
				//------------------------------------------------------------------------------
					
				conn.QueryString = "select distinct top 1 programid from rfprogram where programid in (select prog_code from application where ap_regno = '"+Request.QueryString["regno"]+ "')";
				conn.ExecuteQuery();
				sProgramID = conn.GetFieldValue("programid").ToString();

				//conn.QueryString = "select * from screensubmenu where lg_code in (select distinct lg_code from rfcafinstatement where programid = '"+Request.QueryString["programid"]+"' and nasabahid = '" +Request.QueryString["jnsnasabah"]+"') and menucode = '" +Request.QueryString["mc"]+ "' and programid = '"+Request.QueryString["programid"]+"'";

				conn.QueryString = "select MENUCODE,BUSSUNITID,PROGRAMID,PROGRAMID_SEQ,SM_MENUDISPLAY,SM_LINKNAME,LG_CODE from screensubmenu where lg_code in (select distinct lg_code from rfcafinstatement where programid = '" + sProgramID + "' and nasabahid = '" + sJnsNasabah + "') and menucode = '" + Request.QueryString["mc"]+ "' and programid = '" + sProgramID + "'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 4);
					string strtemp = "";
					strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&tc="+Request.QueryString["tc"]+"&tahun="+Request.QueryString["tahun"]+"&mode="+Request.QueryString["mode"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
					t.NavigateUrl = conn.GetFieldValue(i, 5)+strtemp;
					SubMenu.Controls.Add(t);
					SubMenu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		protected void BtnCalculate_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC CALCULATE_BPR_KOMDAL '" + Request.QueryString["regno"] + "','" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			retrieve_data();
			CalculatePertumbuhan();
		}
	}
}