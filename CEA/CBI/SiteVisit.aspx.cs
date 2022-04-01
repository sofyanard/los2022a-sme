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
using System.Configuration;
using DMS.DBConnection;
using DMS.CuBESCore;
using DMS.BlackList;
using Microsoft.VisualBasic;

namespace SME.CEA.CBI
{
	/// <summary>
	/// Summary description for SiteVisit.
	/// </summary>
	public partial class SiteVisit : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		protected CommonForm.DocExport DocExport1;
		protected CommonForm.DocUpload DocUpload1;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			conn.QueryString="delete from rekanan_iscomply_site_visit";
			conn.ExecuteQuery();
			
			conn.QueryString="delete from rekanan_scoring_site_visit";
			conn.ExecuteQuery();

			conn.QueryString="update vw_rekanan_iscomply_site_visit set score=null";
			conn.ExecuteQuery();

			conn.QueryString = "exec REKANAN_InputData_Scoring_Site_Visit '" + 
				Request.QueryString["rekanan_ref"] + "', '"+
				Request.QueryString["regnum"] + "' ";
			conn.ExecuteNonQuery();
			
			if (!IsPostBack)
			{
				DDL_BLN_VISIT.Items.Add(new ListItem("--Pilih--",""));
				for (int i = 1; i <= 12; i++)
					DDL_BLN_VISIT.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				
				BindDataQuestionVisitSum();				
				BindDataQuestionVisit();
				ViewData();			
	
				DocExport1.GroupTemplate = "SVPRINT";
				DocUpload1.GroupTemplate = "SVUPLOAD";
				DocUpload1.WithReadExcel = false;
			}	
			
			ViewMenu();		
			CekView();	
		}

		
		private void ViewData()
		{
			conn.QueryString=" select * from rekanan_site_visit where regnum='"+Request.QueryString["regnum"]+"' ";
			conn.ExecuteQuery();

			TXT_DAY.Text=tool.FormatDate_Day(conn.GetFieldValue("TGL_KUNJUNGAN"));
			try{ DDL_BLN_VISIT.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("TGL_KUNJUNGAN"));}
			catch{DDL_BLN_VISIT.SelectedValue="";}
			TXT_YEAR.Text=tool.FormatDate_Year(conn.GetFieldValue("TGL_KUNJUNGAN"));
			TXT_DILAKSANAKAN1.Text=conn.GetFieldValue("DILAKSANAKAN1");
			TXT_DILAKSANAKAN2.Text=conn.GetFieldValue("DILAKSANAKAN2");
			TXT_DITERIMA1.Text=conn.GetFieldValue("DITERIMA1");
			TXT_DITERIMA2.Text=conn.GetFieldValue("DITERIMA2");
			TXT_DITERIMA3.Text=conn.GetFieldValue("DITERIMA3");
			TXT_AREA.Text=conn.GetFieldValue("AREA");
			try{RDO_STATUS.SelectedValue=conn.GetFieldValue("STATUS");}
			catch{RDO_STATUS.SelectedValue="0";}
			
			TXT_OWN_AGE.Text=conn.GetFieldValue("own_age");
			TXT_SINCE.Text=conn.GetFieldValue("since");
			TXT_Address1.Text=conn.GetFieldValue("address1");
			TXT_NO1.Text=conn.GetFieldValue("add#1");
			TXT_CITY1.Text=conn.GetFieldValue("add_city1");
			TXT_ADDRESS2.Text=conn.GetFieldValue("address2");
			TXT_NO2.Text=conn.GetFieldValue("add#2");
			TXT_CITY2.Text=conn.GetFieldValue("add_city2");
			TXT_PIC1.Text=conn.GetFieldValue("pic1");
			TXT_PIC2.Text=conn.GetFieldValue("pic2");
			TXT_PIC3.Text=conn.GetFieldValue("pic3");
			TXT_EMPLOYEE.Text=conn.GetFieldValue("employee");
			TXT_EXPERT.Text=conn.GetFieldValue("expert");
			TXT_ADMIN.Text=conn.GetFieldValue("admin");
			TXT_OUTSOURCE.Text=conn.GetFieldValue("outsource");

			try{RDO_EQUITMENT.SelectedValue=conn.GetFieldValue("equitment");}
			catch{RDO_EQUITMENT.SelectedValue="0";}
			
			try{RDO_DATABASE.SelectedValue=conn.GetFieldValue("database_rsv");}
			catch {RDO_DATABASE.SelectedValue="0";}

			try{RDO_BUILDING.SelectedValue=conn.GetFieldValue("building");}
			catch{RDO_BUILDING.SelectedValue="0";}
			
			try{RDO_ARSIP_ROOM.SelectedValue=conn.GetFieldValue("arsip_room");}
			catch{RDO_ARSIP_ROOM.SelectedValue="0";}
			
			TXT_ACTIVITY1.Text=conn.GetFieldValue("activity1");
			TXT_ACTIVITY2.Text=conn.GetFieldValue("activity2");
			TXT_SUM.Text=conn.GetFieldValue("sc_tot");

			conn.QueryString = "select sc_add, sc_sarana, sc_database, sc_equitment, sc_building, sc_resource, sc_tot from rekanan_site_visit where regnum='" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();
			
			if(conn.GetRowCount()>0)
			{
				for (int i = 0; i < DGR_VISIT.Items.Count; i++)
				{		
					DGR_VISIT.Items[i].Cells[7].Text = conn.GetFieldValue(0,i);
				}
			

				conn.QueryString = "exec rekanan_fillgrid_sitevisit '" + Request.QueryString["regnum"] + "'";
				conn.ExecuteQuery();

				if(conn.GetRowCount()>0)
			
					for (int i = 0; i < DGR_VISIT.Items.Count; i++)
					{		
						RadioButtonList rblsitevisit = (RadioButtonList)DGR_VISIT.Items[i].Cells[6].FindControl("RBL_VISIT");
						try{rblsitevisit.SelectedValue = conn.GetFieldValue(0,i);}
						catch{}
							
					}
			}			
		}

		private void DGR_VISIT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_VISIT.CurrentPageIndex = e.NewPageIndex;
			BindDataQuestionVisit();
		}

		private void BindDataQuestionVisit()
		{
						
			conn.QueryString="select * from VW_REKANAN_Iscomply_Site_Visit";
			conn.ExecuteQuery();			

			//ChooseRBL();

			/*conn.QueryString= "select sum(score) as SUM from vw_rekanan_iscomply_site_visit";
			conn.ExecuteQuery();*/
				
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_VISIT.DataSource = dt;
			try 
			{
				DGR_VISIT.DataBind();
			}
			catch 
			{
				DGR_VISIT.CurrentPageIndex = 0;
				DGR_VISIT.DataBind();
			}
			
		}

		

		private void BindDataQuestionVisitSum()
		{
			conn.QueryString= "select sum(score) as SUM from vw_rekanan_iscomply_site_visit";
			conn.ExecuteQuery();
				
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_SUM.DataSource = dt;
			try 
			{
				DGR_SUM.DataBind();
			}
			catch 
			{
				DGR_SUM.CurrentPageIndex = 0;
				DGR_SUM.DataBind();
			}			
			
		}		
		
		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{	
			/*try
			{
				conn.QueryString = "exec REKANAN_CHECK_MANDATORY_Verification_SiteVisit '" + Request.QueryString["regnum"] + "'";
				conn.ExecuteNonQuery();
			}	

			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}*/

			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), compEstablish;
			
			//////////////////////////////////////////////////////////////////
			/// VALIDASI TANGGAL 
 
			Int64 tanggalKunjungan;
			//tanggalKunjungan = Int64.Parse(Tools.toISODate(TXT_DAY.Text, DDL_BLN_VISIT.SelectedValue, TXT_YEAR.Text));			

			if (!GlobalTools.isDateValid(TXT_DAY.Text, DDL_BLN_VISIT.SelectedValue, TXT_YEAR.Text)) 
			{
				GlobalTools.popMessage(this, "Tanggal Kunjungan tidak valid!");
				return;
			}
			else 
			{			
				tanggalKunjungan = Int64.Parse(Tools.toISODate(TXT_DAY.Text, DDL_BLN_VISIT.SelectedValue, TXT_YEAR.Text));

				if (tanggalKunjungan > now) 
				{
					GlobalTools.popMessage(this, "Tanggal Kunjungan tidak bisa lebih dari tanggal saat ini!!");
					return;
				}
			}

			for (int i = 0; i < DGR_VISIT.Items.Count; i++)
			{		
				RadioButtonList rblsitevisit = (RadioButtonList)DGR_VISIT.Items[i].Cells[6].FindControl("RBL_VISIT");
			
				try
				{						
					string nilai = null;
					if (rblsitevisit.SelectedValue == "1")
						nilai = "1";
					else if (rblsitevisit.SelectedValue == "2")
						nilai = "2";
					else if (rblsitevisit.SelectedValue == "3")
						nilai = "3";
					else if (rblsitevisit.SelectedValue == "4")
						nilai = "4";
					else if (rblsitevisit.SelectedValue == "5")
						nilai = "5";  
					


					conn.QueryString=" exec REKANAN_Insert_Iscomply_Site_Visit " + DGR_VISIT.Items[i].Cells[0].Text.Trim() + ",  "+ tool.ConvertNum(MyConnection.ConvertToDouble(nilai).ToString()) +" ";
					conn.ExecuteNonQuery();

					conn.QueryString="update vw_rekanan_iscomply_site_visit set score=  iscomply*nilai_bobot";
					conn.ExecuteQuery();
					
					//rblsitevisit.SelectedValue = nilai;
					
				}	
				
						
				catch (Exception ex)
				{			
					
					string errmsg = ex.Message.Replace("'","");
					if (errmsg.IndexOf("Last Query:") > 0)
						errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
					GlobalTools.popMessage(this, errmsg);
					return;
				} 				
				
			}
	
						
			BindDataQuestionVisit();	
			
			BindDataQuestionVisitSum();
								
			conn.QueryString=" exec REKANAN_SITE_VISIT_INSERT '"+
				Request.QueryString["regnum"] + "', "+
				tool.ConvertDate(TXT_DAY.Text, DDL_BLN_VISIT.SelectedValue, TXT_YEAR.Text) + ", '" +
				TXT_DILAKSANAKAN1.Text +"', '"+
				TXT_DILAKSANAKAN2.Text +"', '"+
				TXT_DITERIMA1.Text +"', '"+
				TXT_DITERIMA2.Text +"', '"+
				TXT_DITERIMA3.Text +"', '"+
				TXT_AREA.Text +"', '"+
				RDO_STATUS.SelectedValue +"', '"+
				TXT_OWN_AGE.Text +"', '"+
				TXT_SINCE.Text +"', '"+
				TXT_Address1.Text +"', '"+
				TXT_NO1.Text +"', '"+
				TXT_CITY1.Text +"', '"+
				TXT_ADDRESS2.Text +"', '"+
				TXT_NO2.Text +"', '"+
				TXT_CITY2.Text +"', '"+
				TXT_PIC1.Text +"', '"+
				TXT_PIC2.Text +"', '"+
				TXT_PIC3.Text +"', '"+
				TXT_EMPLOYEE.Text +"', '"+
				TXT_EXPERT.Text +"', '"+
				TXT_ADMIN.Text +"', '"+
				TXT_OUTSOURCE.Text +"', '"+
				RDO_EQUITMENT.SelectedValue +"', '"+
				RDO_DATABASE.SelectedValue +"', '"+
				RDO_BUILDING.SelectedValue +"', '"+
				RDO_ARSIP_ROOM.SelectedValue +"', '"+
				TXT_ACTIVITY1.Text +"', '"+
				TXT_ACTIVITY2.Text +"', " + 
				tool.ConvertFloat(DGR_VISIT.Items[0].Cells[7].Text.Trim()) + ", " +
				tool.ConvertFloat(DGR_VISIT.Items[1].Cells[7].Text.Trim()) + ", " + 
				tool.ConvertFloat(DGR_VISIT.Items[2].Cells[7].Text.Trim()) + ", " +
				tool.ConvertFloat(DGR_VISIT.Items[3].Cells[7].Text.Trim()) + ", " +
				tool.ConvertFloat(DGR_VISIT.Items[4].Cells[7].Text.Trim()) + ", " +
				tool.ConvertFloat(DGR_VISIT.Items[5].Cells[7].Text.Trim()) + ", " +
				tool.ConvertFloat(DGR_SUM.Items[0].Cells[0].Text.Trim()) +" ";

			conn.ExecuteNonQuery();			

			TXT_SUM.Text = DGR_SUM.Items[0].Cells[0].Text.Trim() ;
			ViewData();

			//Cek Kelengkapan Mandatory Site Visit
			conn.QueryString="select * from rekanan_site_visit where regnum='" + Request.QueryString["regnum"] + "' and (dilaksanakan1='' or diterima1='' or tgl_kunjungan=null)";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				GlobalTools.popMessage(this, "Input Data mandatory Site Visit belum lengkap!");
				return;	
			}

			//Cek Kelengkapan Data Scoring Site_visit
			conn.QueryString = "select * from rekanan_site_visit where regnum='" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();

			float sc_add=0, sc_sarana=0, sc_database=0, sc_equitment=0, sc_building=0, sc_resource=0;			

			sc_add = float.Parse(DGR_VISIT.Items[0].Cells[7].Text.Trim());
			sc_sarana = float.Parse(DGR_VISIT.Items[1].Cells[7].Text.Trim());
			sc_database = float.Parse(DGR_VISIT.Items[2].Cells[7].Text.Trim());
			sc_equitment = float.Parse(DGR_VISIT.Items[3].Cells[7].Text.Trim());
			sc_building = float.Parse(DGR_VISIT.Items[4].Cells[7].Text.Trim());
			sc_resource = float.Parse(DGR_VISIT.Items[5].Cells[7].Text.Trim());

			if (sc_add==0 || sc_sarana==0 || sc_database==0 || sc_equitment==0 || sc_building==0 || sc_resource==0)
			{
				GlobalTools.popMessage(this, "Input Data Kesimpulan/Pendapat Site Visit belum lengkap!");
				return;	
			}	
			
		}		
		
		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{
			TXT_DAY.Text=""; 
			DDL_BLN_VISIT.SelectedValue=""; 
			TXT_YEAR.Text="";
			TXT_DILAKSANAKAN1.Text="";
			TXT_DILAKSANAKAN2.Text="";
			TXT_DITERIMA1.Text="";
			TXT_DITERIMA2.Text="";
			TXT_DITERIMA3.Text="";
			TXT_AREA.Text="";
			RDO_STATUS.SelectedValue="0";
			TXT_OWN_AGE.Text="";
			TXT_SINCE.Text="";
			TXT_Address1.Text="";
			TXT_NO1.Text="";
			TXT_CITY1.Text="";
			TXT_ADDRESS2.Text="";
			TXT_NO2.Text="";
			TXT_CITY2.Text="";
			TXT_PIC1.Text="";
			TXT_PIC2.Text="";
			TXT_PIC3.Text="";
			TXT_EMPLOYEE.Text="";
			TXT_EXPERT.Text="";
			TXT_ADMIN.Text="";
			TXT_OUTSOURCE.Text="";
			RDO_EQUITMENT.SelectedValue="0";
			RDO_DATABASE.SelectedValue="0";
			RDO_BUILDING.SelectedValue="0";
			RDO_ARSIP_ROOM.SelectedValue="0";
			TXT_ACTIVITY1.Text="";
			TXT_ACTIVITY2.Text="";		

		}

		private void ViewMenu()
		{
			Menu.Controls.Clear();
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
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"] + "&exist=" + Request.QueryString["exist"]+ "&view=" + Request.QueryString["view"];
						else	
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+ "&exist=" + Request.QueryString["exist"]+ "&tc="+Request.QueryString["tc"]+ "&view=" + Request.QueryString["view"];
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"] + "&mc2=" + Request.QueryString["mc2"];
					}
					else 
					{
						strtemp = ""; 
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

		protected void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
			conn.QueryString="select * from rekanan_site_visit where regnum ='" + Request.QueryString["regnum"]+" '";
			conn.ExecuteQuery();
			
			if (conn.GetRowCount() == 0)
			{
				GlobalTools.popMessage(this, "Data Site Visit belum diisi dan disimpan!");
				return;
			}

			//Cek Kelengkapan Mandatory Site Visit
			conn.QueryString="select * from rekanan_site_visit where regnum='" + Request.QueryString["regnum"] + "' and (dilaksanakan1='' or diterima1='' or tgl_kunjungan=null)";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				GlobalTools.popMessage(this, "Input Data mandatory Site Visit belum lengkap!");
				return;	
			}

			//Cek Kelengkapan Data Scoring Site_visit
			conn.QueryString = "select * from rekanan_site_visit where regnum='" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();

			float sc_add=0, sc_sarana=0, sc_database=0, sc_equitment=0, sc_building=0, sc_resource=0;			

			sc_add = float.Parse(DGR_VISIT.Items[0].Cells[7].Text.Trim());
			sc_sarana = float.Parse(DGR_VISIT.Items[1].Cells[7].Text.Trim());
			sc_database = float.Parse(DGR_VISIT.Items[2].Cells[7].Text.Trim());
			sc_equitment = float.Parse(DGR_VISIT.Items[3].Cells[7].Text.Trim());
			sc_building = float.Parse(DGR_VISIT.Items[4].Cells[7].Text.Trim());
			sc_resource = float.Parse(DGR_VISIT.Items[5].Cells[7].Text.Trim());

			if (sc_add==0 || sc_sarana==0 || sc_database==0 || sc_equitment==0 || sc_building==0 || sc_resource==0)
			{
				GlobalTools.popMessage(this, "Input Data Kesimpulan/Pendapat Site Visit belum lengkap!");
				return;	
			}	

			Response.Redirect("/SME/CEA/PrintSiteVisit.aspx?rekanan_ref=" + Request.QueryString["rekanan_ref"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&regnum=" + Request.QueryString["regnum"]);
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ListRekananInput.aspx?tc=" + Request.QueryString["tc"]+ "&mc=" + Request.QueryString["mc"]);
		}

		private void CekView()
		{
			if(Request.QueryString["view"]=="1")
			{
				DDL_BLN_VISIT.Enabled = false;
				BTN_SAVE.Enabled = false;
				BTN_CLEAR.Enabled = false;
				TXT_DAY.ReadOnly = true;
				TXT_YEAR.ReadOnly = true;
				TXT_DILAKSANAKAN1.ReadOnly = true;
				TXT_DILAKSANAKAN2.ReadOnly = true;
				TXT_DITERIMA1.ReadOnly = true;
				TXT_DITERIMA2.ReadOnly = true;
				TXT_DITERIMA3.ReadOnly = true;
				TXT_AREA.ReadOnly = true;
				RDO_STATUS.Enabled = false;
				TXT_OWN_AGE.ReadOnly = true;
				TXT_SINCE.ReadOnly = true;
				TXT_Address1.ReadOnly = true;
				TXT_NO1.ReadOnly = true;
				TXT_CITY1.ReadOnly = true;
				TXT_ADDRESS2.ReadOnly = true;
				TXT_NO2.ReadOnly = true;
				TXT_CITY2.ReadOnly = true;
				TXT_PIC1.ReadOnly = true;
				TXT_PIC2.ReadOnly = true;
				TXT_PIC3.ReadOnly = true;
				TXT_EMPLOYEE.ReadOnly = true;
				TXT_EXPERT.ReadOnly = true;
				TXT_ADMIN.ReadOnly = true;
				TXT_OUTSOURCE.ReadOnly = true;
				RDO_EQUITMENT.Enabled = false;
				RDO_DATABASE.Enabled = false;
				RDO_BUILDING.Enabled = false;
				RDO_ARSIP_ROOM.Enabled = false;
				//RBL_VISIT.Enabled = false;
				TXT_ACTIVITY1.ReadOnly = true;
				TXT_ACTIVITY2.ReadOnly = true;
				DGR_VISIT.Columns[6].Visible = false;
				TXT_SUM.ReadOnly = true;
				BTN_PRINT.Enabled = false;
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
	}
}
