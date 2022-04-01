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
using System.IO;


namespace SME.CreditAnalysis.BPR
{
	/// <summary>
	/// Summary description for bprAnalisisRasio.
	/// </summary>
	public partial class bprAnalisisRasio : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dg_Excel;
		protected System.Web.UI.WebControls.Label lbl_Status;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;
		protected System.Web.UI.WebControls.Label lbl_StatusReport;
		protected System.Web.UI.WebControls.Button btn_Upload;
		protected System.Web.UI.HtmlControls.HtmlInputFile TXT_FILE_UPLOAD;
		protected System.Web.UI.WebControls.DataGrid DatGrid;
		protected System.Web.UI.WebControls.Button BTN_PROSES;

		protected Connection conn;
		//protected Tools tool = new Tools();


		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			
			if(!IsPostBack)
			{
				IsiTanggal();
				//ViewData();	
				RetrieveData();
			}
			ViewMenu();
			ViewSubMenu();
			
			//ViewGridExcel();
			//ViewFileUpload();

			secureData();

			btn_Save.Attributes.Add("onclick","if(!cek_key('rasio')){return false;};");
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


		/*
		private void ViewData()
		{
			conn.QueryString = "Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
			string a = conn.GetFieldValue("cu_ref").ToString();

			conn.QueryString = "select POSISI_TGL,JML_BLN from BPR_RASIO WHERE CU_REF = '"+a+"' order by POSISI_TGL desc";
			conn.ExecuteQuery();
			dg_Neraca.DataSource = conn.GetDataTable().Copy();
			dg_Neraca.DataBind();
			for(int i = 0; i < dg_Neraca.Items.Count; i++)
			{
				dg_Neraca.Items[i].Cells[0].Text = GlobalTools.FormatDate(dg_Neraca.Items[i].Cells[0].Text);
			}
		}
		*/


		//		private void ViewGridExcel()
		//		{
		//			string a = "BPRF";
		//			conn.QueryString = "select seq, excel_name,location from ca_excel_template where lg_code ='" + a + "'";
		//			conn.ExecuteQuery();
		//			dg_Excel.DataSource = conn.GetDataTable().Copy();
		//			dg_Excel.DataBind();
		//			for(int i = 0; i < dg_Excel.Items.Count; i++)
		//			{
		//				HyperLink Hp = (HyperLink) dg_Excel.Items[i].Cells[3].FindControl("HL_DOWNLOAD");
		//				Hp.NavigateUrl = dg_Excel.Items[i].Cells[2].Text.Trim();
		//			}
		//		}	


		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
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
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
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
				Response.Write("<script language='javascript'>alert('"+temp+"');</script>");
			}
		}
	

		private void ViewSubMenu()
		{
			/*
			try 
			{
				conn.QueryString = "select * from screensubmenu where lg_code in (select distinct lg_code from rfcafinstatement where programid = '"+Request.QueryString["programid"]+"' and nasabahid = '" +Request.QueryString["jnsnasabah"]+"') and menucode = '" +Request.QueryString["mc"]+ "' and programid = '"+Request.QueryString["programid"]+"'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 4);
					string strtemp = "";
					strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"];
					t.NavigateUrl = conn.GetFieldValue(i, 5)+strtemp;
					SubMenu.Controls.Add(t);
					SubMenu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
				Response.Write("<script language='javascript'>alert('"+temp+"');</script>");
			}
			*/

			try 
			{
				//string programid = (string) Session["programid"];
				//string jnsnasabah = (string) Session["jnsnasabah"];

				conn.QueryString = "select distinct top 1 cu_jnsnasabah from customer where cu_ref in (Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+ "')";
				conn.ExecuteQuery();
				string jnsnasabah = conn.GetFieldValue("cu_jnsnasabah").ToString();
				
				conn.QueryString = "select distinct top 1 programid from rfprogram where programid in (select prog_code from application where ap_regno = '"+Request.QueryString["regno"]+ "')";
				conn.ExecuteQuery();
				string programid = conn.GetFieldValue("programid").ToString();

				conn.QueryString = "select distinct m.MENUCODE,m.BUSSUNITID,m.PROGRAMID,m.PROGRAMID_SEQ,m.SM_MENUDISPLAY,m.SM_LINKNAME,m.LG_CODE " +
					" from screensubmenu m " +
					" left join rfcafinstatement fin on fin.programid = m.programid and fin.lg_code= m.lg_code " +
					" where m.programid = '" + programid + "' " +
					" and fin.nasabahid = '" + jnsnasabah + "' and m.menucode = '" + Request.QueryString["mc"] + "'";
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



		// ----------------------------- start retrieve data ---------------------------------------------------- 
		private void RetrieveData()
		{
			//int jmlrow;
			//conn.QueryString = "select excel_field from ca_excel where excel_file = 'BPR' and excel_type = 'BS'";
			//conn.ExecuteQuery();
			//jmlrow = conn.GetRowCount();
			conn.QueryString = "Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
			string a = conn.GetFieldValue("cu_ref").ToString();


			conn.QueryString = "select top 3 * from BPR_RASIO where CU_REF = '"+a+"'and  year(POSISI_TGL) <= '" + Request.QueryString["tahun"] + "' order by POSISI_TGL asc";
			conn.ExecuteQuery();

			int row = 65;
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				
				row++;
				string vtmp = ((char)row).ToString();
				int k = 4;
				int l = 2;

				for (int m=12;m<=14;m++)
				{
					System.Web.UI.WebControls.TextBox txt_DD_ = (System.Web.UI.WebControls.TextBox) Page.FindControl("txt_DD_" + vtmp + m.ToString());
					System.Web.UI.WebControls.DropDownList ddl_MM_ = (System.Web.UI.WebControls.DropDownList) Page.FindControl("ddl_MM_" + vtmp + m.ToString());
					System.Web.UI.WebControls.TextBox txt_YY_ = (System.Web.UI.WebControls.TextBox) Page.FindControl("txt_YY_" + vtmp + m.ToString());
					System.Web.UI.WebControls.TextBox txt_ = (System.Web.UI.WebControls.TextBox) Page.FindControl("txt_" + vtmp + m.ToString());

					System.Web.UI.WebControls.DropDownList ddl_ = (System.Web.UI.WebControls.DropDownList) Page.FindControl("ddl_" + vtmp + m.ToString());

					if (Request.QueryString["mode"]=="retrieve")
					{
						if (m==12)
						{
					
							try
							{
								DateTime tgl = DateTime.Parse(GlobalTools.FormatDate(conn.GetFieldValue(i, l)));
								GlobalTools.fillDateForm(txt_DD_, ddl_MM_, txt_YY_, tgl);
							}
							catch 
							{
							}
						}
						else if (m==13)
						{
							try {txt_.Text = GlobalTools.ConvertFloat(conn.GetFieldValue(i, l));}
							catch {}
						}
						else if (m==14)
						{
							try {ddl_.SelectedValue = conn.GetFieldValue(i,"JNS_LAP").ToString();}
							catch {}
						}
					}
					else
					{
						if (m==12)
						{
							try
							{
								txt_DD_.Text = "";
								ddl_MM_.SelectedIndex = 0;
								txt_YY_.Text = "";
							}
							catch
							{
							}

						}
						else if (m==13)
						{
							try {txt_.Text = "";}
							catch {}
						}
						else if (m==14)
						{
							try {ddl_.SelectedValue = "-";}
							catch {}
						}

					}
					l++;
				}

				for (int j = 14; j <= 46; j++)
				{	
					System.Web.UI.WebControls.TextBox txt_ = (System.Web.UI.WebControls.TextBox) Page.FindControl("txt_" + vtmp + j.ToString());
					if (Request.QueryString["mode"]=="retrieve")
					{
						if ( j <= 24)
						{
							try 
							{
								txt_.Text = myMoneyFormat_noDec(conn.GetFieldValue(i, k).ToString());
							}
							catch 
							{
							}
						}
						else
						{
							try 
							{
								txt_.Text = myPercentFormat(conn.GetFieldValue(i, k).ToString());
							}
							catch 
							{
							}
						}
					}
					else 
					{
						try {txt_.Text = "";}
						catch {}

					}
					if (k > 46)
					{
						break;
					}
					else
					{
						k++; 
					}
				}
			}
		}	
		// ----------------------------- end retrieve data ---------------------------------------------------- 


		private void SaveRasio()
		{

			//Strings.Format(Double.Parse(txt_B30.Text.ToString().Replace("%",""))/10000,"0.0000").Replace(",",".") + "," + //ahmad

			conn.QueryString = "Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
			string a = conn.GetFieldValue("cu_ref").ToString();			

			conn.QueryString = "sp_bpr_rasio 'Save','" + a + "','" +
				Request.QueryString["regno"] + "'," +
				GlobalTools.ToSQLDate(txt_DD_B12.Text, ddl_MM_B12.SelectedValue, txt_YY_B12.Text) + "," +
				GlobalTools.ConvertFloat(txt_B13.Text) + ",'" +
				ddl_B14.SelectedValue + "'," +
				GlobalTools.ConvertFloat(txt_B15.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B16.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B17.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B18.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B19.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B20.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B21.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B22.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B23.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B24.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B25.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B26.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B27.Text) + "," + 
				GlobalTools.ConvertFloat(txt_B28.Text) + "," +
				GlobalTools.ConvertFloat(txt_B29.Text) + "," +
				//-----------------------------------------------------------------------------------------
				
				GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_B30.Text))/10000)) + "," +
				GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_B31.Text))/10000)) + "," +
				GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_B32.Text))/10000)) + "," +
				GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_B33.Text))/10000)) + "," +
				GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_B34.Text))/10000)) + "," +
				GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_B35.Text))/10000)) + "," +
				GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_B36.Text))/10000)) + "," +
				GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_B37.Text))/10000)) + "," +
				GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_B38.Text))/10000)) + "," +
				GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_B39.Text))/10000)) + "," +
				GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_B40.Text))/10000)) + "," +
				GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_B41.Text))/10000)) + "," +
				GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_B42.Text))/10000)) + "," +
				GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_B43.Text))/10000)) + "," +
				GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_B44.Text))/10000)) + "," +
				GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_B45.Text))/10000)) + "," +
				GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_B46.Text))/10000)) + ",'1'";
			//a="";
			//a=a+"b";
			conn.ExecuteNonQuery();

			if (txt_C15.Text != "")
			{
				

				conn.QueryString = "sp_bpr_rasio 'Save','" + a + "','" +
					Request.QueryString["regno"] + "'," +
					GlobalTools.ToSQLDate(txt_DD_C12.Text, ddl_MM_C12.SelectedValue, txt_YY_C12.Text) + "," +
					GlobalTools.ConvertFloat(txt_C13.Text) + ",'" +
					ddl_C14.SelectedValue + "'," +
					GlobalTools.ConvertFloat(txt_C15.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C16.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C17.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C18.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C19.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C20.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C21.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C22.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C23.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C24.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C25.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C26.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C27.Text) + "," + 
					GlobalTools.ConvertFloat(txt_C28.Text) + "," +
					GlobalTools.ConvertFloat(txt_C29.Text) + "," +
					//-----------------------------------------------------------------------------------------
				
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_C30.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_C31.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_C32.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_C33.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_C34.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_C35.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_C36.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_C37.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_C38.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_C39.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_C40.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_C41.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_C42.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_C43.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_C44.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_C45.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_C46.Text))/10000)) + ",'1'";
				conn.ExecuteNonQuery();
			}

			if (txt_D15.Text != "")
			{
				conn.QueryString = "sp_bpr_rasio 'Save','" + a + "','" +
					Request.QueryString["regno"] + "'," +
					GlobalTools.ToSQLDate(txt_DD_D12.Text, ddl_MM_D12.SelectedValue, txt_YY_D12.Text) + "," +
					GlobalTools.ConvertFloat(txt_D13.Text) + ",'" +
					ddl_D14.SelectedValue + "'," +
					GlobalTools.ConvertFloat(txt_D15.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D16.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D17.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D18.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D19.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D20.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D21.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D22.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D23.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D24.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D25.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D26.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D27.Text) + "," + 
					GlobalTools.ConvertFloat(txt_D28.Text) + "," +
					GlobalTools.ConvertFloat(txt_D29.Text) + "," +
					//-----------------------------------------------------------------------------------------
				
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_D30.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_D31.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_D32.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_D33.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_D34.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_D35.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_D36.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_D37.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_D38.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_D39.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_D40.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_D41.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_D42.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_D43.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_D44.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_D45.Text))/10000)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(double.Parse(GlobalTools.ConvertFloat(txt_D46.Text))/10000)) + ",''";
				conn.ExecuteNonQuery();
			}
		}


		//		private void btn_Upload_Click(object sender, System.EventArgs e)
		//		{
		//			string path;
		//
		//			path = @"D:\Projects\SME\Source\CreditAnalysis\ExcelTemplate\BPR.xls";			 
		//			System.IO.FileInfo fi = new System.IO.FileInfo(file_Nama.PostedFile.FileName);
		//			file_Nama.PostedFile.SaveAs(path);			
		//			lbl_Status.Text = "Upload Successful";
		//		}


		//		private void btn_Refresh_Click(object sender, System.EventArgs e)
		//		{
		//			ViewExcel();
		//		}

		private bool cekTanggal()
		{
			if (txt_DD_B12.Text != "" && ddl_MM_B12.SelectedIndex > 0 && txt_YY_B12.Text != "")
				if (!GlobalTools.isDateValid(this, txt_DD_B12.Text, ddl_MM_B12.SelectedValue, txt_YY_B12.Text)) 
				{
					GlobalTools.popMessage(this, "Data/Number of Months tidak valid!");
					return false;
				}
			if (txt_DD_C12.Text != "" && ddl_MM_C12.SelectedIndex > 0 && txt_YY_C12.Text != "")
				if (!GlobalTools.isDateValid(this, txt_DD_C12.Text, ddl_MM_C12.SelectedValue, txt_YY_C12.Text)) 
				{
					GlobalTools.popMessage(this, "Data/Number of Months tidak valid!");
					return false;
				}
			if (txt_DD_D12.Text != "" && ddl_MM_D12.SelectedIndex > 0 && txt_YY_D12.Text != "")
				if (!GlobalTools.isDateValid(this, txt_DD_D12.Text, ddl_MM_D12.SelectedValue, txt_YY_D12.Text)) 
				{
					GlobalTools.popMessage(this, "Data/Number of Months tidak valid!");
					return false;
				}

			return true;
		}


		protected void btn_Save_Click(object sender, System.EventArgs e)
		{
			if (!cekTanggal())
				return;

			SaveRasio();
		}


		//		private void dg_Neraca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		//		{
		//			string cmd = e.CommandName;
		//			switch (cmd)
		//			{		  
		//				case "retrieve" :
		//					Response.Redirect("bprAnalisisRasio.aspx?tahun=" + GlobalTools.FormatDate_Year(e.Item.Cells[0].Text) +"&mode=retrieve&regno="+Request.QueryString["regno"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]);
		//					RetrieveData();
		//					break;
		//				case "delete" :
		//					Response.Redirect("bprAnalisisRasio.aspx?tahun=" + GlobalTools.FormatDate_Year(e.Item.Cells[0].Text) +"&mode=delete&regno="+Request.QueryString["regno"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]);
		//					RetrieveData();
		//					break;
		//				default :
		//					break;
		//			}
		//		}


		private void IsiTanggal()
		{
			GlobalTools.initDateFormINA(txt_DD_B12, ddl_MM_B12, txt_YY_B12, true);
			GlobalTools.initDateFormINA(txt_DD_C12, ddl_MM_C12, txt_YY_C12, true);
			GlobalTools.initDateFormINA(txt_DD_D12, ddl_MM_D12, txt_YY_D12, true);
		}


		private void DatGrid_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;
			switch (cmd)
			{		  
				case "retrieve" :
					Response.Redirect("bprRugiLaba.aspx?tahun=" + GlobalTools.FormatDate_Year(e.Item.Cells[0].Text) +"&mode=retrieve&regno="+Request.QueryString["regno"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]);
					RetrieveData();
					break;
				case "delete" :
					Response.Redirect("bprRugiLaba.aspx?tahun=" + GlobalTools.FormatDate_Year(e.Item.Cells[0].Text) +"&mode=delete&regno="+Request.QueryString["regno"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]);
					RetrieveData();
					break;
				default :
					break;
			}
		}

		private void dg_Neraca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;
			switch (cmd)
			{		  
				case "retrieve" :
					Response.Redirect("bprAnalisisRasio.aspx?tahun=" + GlobalTools.FormatDate_Year(e.Item.Cells[0].Text) +"&mode=retrieve&regno="+Request.QueryString["regno"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]);
					RetrieveData();
					break;
				case "delete" :
					//---------------------------------------------------delete rasio
					conn.QueryString = "Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+"'";
					conn.ExecuteQuery();
					string a = conn.GetFieldValue("cu_ref").ToString();

					conn.QueryString = "SP_BPR_RASIO 'Delete','"+a+"','"+ Strings.Format(DateTime.Parse(e.Item.Cells[0].Text),"yyyy-MM-dd") +
						"',12,'Audited',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
					conn.ExecuteNonQuery();

					Response.Redirect("bprAnalisisRasio.aspx?tahun=" + GlobalTools.FormatDate_Year(e.Item.Cells[0].Text) +"&mode=delete&regno="+Request.QueryString["regno"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]);
					RetrieveData();
					break;
				default :
					break;
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink("",Request.QueryString["mc"].ToString(), conn));
		}

		private string myMoneyFormat_noDec(string str)
		{
			if ((str.Trim() == "") || (str.Trim() == "&nbsp;")) 
			{
				return Strings.FormatNumber(0, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
			} 
			else 
			{
				return Strings.FormatNumber(str, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
			}
		}

		private string formatMoney_ind(string a)
		{
			Response.Write("<!--formatMoney_ind-->");
			string b,c,d;																	//a = 1,230.00
			c = Strings.Replace(myMoneyFormat_noDec(a),".", ";",1,-1,CompareMethod.Binary);	//c = 1,230;00
			b = Strings.Replace(c,",", ".",1,-1,CompareMethod.Binary);						//b = 1.230;00
			d = Strings.Replace(b,";", ",",1,-1,CompareMethod.Binary);						//d = 1.230,00
			return a;
			//return myMoneyFormat_noDec(a);

		}

		private string myPercentFormat(string str)
		{
			if ((str.Trim() == "") || (str.Trim() == "&nbsp;")) 
			{
				return Strings.FormatPercent(0, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault).Replace("%","");
			} 
			else 
			{
				return Strings.FormatPercent(str, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault).Replace("%","");
			}
		}

		private string percentFormat_ind(string a)
		{
			Response.Write("<!--percentFormat_ind-->");
			string b,c,d;																	//a = 1,230.00
			c = Strings.Replace(myPercentFormat(a),".", ";",1,-1,CompareMethod.Binary);		//c = 1,230;00
			b = Strings.Replace(c,",", ".",1,-1,CompareMethod.Binary);						//b = 1.230;00
			d = Strings.Replace(b,";", ",",1,-1,CompareMethod.Binary);						//d = 1.230,00
			return d;
			//return myMoneyFormat_noDec(a);

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


	}
}