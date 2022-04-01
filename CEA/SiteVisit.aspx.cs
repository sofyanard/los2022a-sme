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


namespace SME.CEA
{
	/// <summary>
	/// Summary description for SiteVisit.
	/// </summary>
	public partial class SiteVisit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RadioButton RB_Sarana1;
		protected System.Web.UI.WebControls.RadioButton RB_Sarana2;
		protected System.Web.UI.WebControls.Label LBL_Alamat;
		protected System.Web.UI.WebControls.RadioButton RB_Sarana3;
		protected System.Web.UI.WebControls.RadioButton RB_Sarana4;
		protected System.Web.UI.WebControls.RadioButton RB_Sarana5;
		protected System.Web.UI.WebControls.Label LBL_Sarana;
		protected System.Web.UI.WebControls.RadioButton RB_DBase1;
		protected System.Web.UI.WebControls.RadioButton RB_DBase2;
		protected System.Web.UI.WebControls.RadioButton RB_DBase3;
		protected System.Web.UI.WebControls.RadioButton RB_DBase4;
		protected System.Web.UI.WebControls.RadioButton RB_DBase5;
		protected System.Web.UI.WebControls.Label LBL_DBase;
		protected System.Web.UI.WebControls.RadioButton RB_Arsip1;
		protected System.Web.UI.WebControls.RadioButton RB_Arsip2;
		protected System.Web.UI.WebControls.RadioButton RB_Arsip3;
		protected System.Web.UI.WebControls.RadioButton RB_Arsip4;
		protected System.Web.UI.WebControls.RadioButton RB_Arsip5;
		protected System.Web.UI.WebControls.Label LBL_Arsip;
		protected System.Web.UI.WebControls.RadioButton RB_Gedung1;
		protected System.Web.UI.WebControls.RadioButton RB_Gedung2;
		protected System.Web.UI.WebControls.RadioButton RB_Gedung3;
		protected System.Web.UI.WebControls.RadioButton RB_Gedung4;
		protected System.Web.UI.WebControls.RadioButton RB_Gedung5;
		protected System.Web.UI.WebControls.Label LBL_Gedung;
		protected System.Web.UI.WebControls.RadioButton RB_JML_TK1;
		protected System.Web.UI.WebControls.RadioButton RB_JML_TK2;
		protected System.Web.UI.WebControls.RadioButton RB_JML_TK3;
		protected System.Web.UI.WebControls.RadioButton RB_JML_TK4;
		protected System.Web.UI.WebControls.RadioButton RB_JML_TK5;
		protected System.Web.UI.WebControls.Label LBL_JML_TK;
		protected System.Web.UI.WebControls.Label LBL_Total;
		protected System.Web.UI.WebControls.RadioButton RB_Alamat1;
		protected System.Web.UI.WebControls.RadioButton RB_Alamat2;
		protected System.Web.UI.WebControls.RadioButton RB_Alamat3;
		protected System.Web.UI.WebControls.RadioButton RB_Alamat4;
		protected System.Web.UI.WebControls.RadioButton RB_Alamat5;
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected Connection conn;
		protected Tools tool = new Tools();
		protected CommonForm.DocExport DocExport1;
		protected CommonForm.DocUpload DocUpload1;
		protected string jenisrek="";
		protected string nama="";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			//---untuk kebutuhan audittrail
			conn.QueryString = "select * from vw_rekanan where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();
			jenisrek		=	conn.GetFieldValue("rfrekanantype");
			nama			=	conn.GetFieldValue("namerekanan");
			//---

			
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
			LBL_DAY.Text=tool.FormatDate_Day(conn.GetFieldValue("TGL_KUNJUNGAN"));

			try{ 
				DDL_BLN_VISIT.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("TGL_KUNJUNGAN"));
				LBL_BLN_VISIT.Text =  tool.FormatDate_Month(conn.GetFieldValue("TGL_KUNJUNGAN"));
			}
			catch{DDL_BLN_VISIT.SelectedValue="";}

			TXT_YEAR.Text=tool.FormatDate_Year(conn.GetFieldValue("TGL_KUNJUNGAN"));
			LBL_YEAR.Text=tool.FormatDate_Year(conn.GetFieldValue("TGL_KUNJUNGAN"));

			TXT_DILAKSANAKAN1.Text=conn.GetFieldValue("DILAKSANAKAN1");
			LBL_DILAKSANAKAN1.Text=conn.GetFieldValue("DILAKSANAKAN1");

			TXT_DILAKSANAKAN2.Text=conn.GetFieldValue("DILAKSANAKAN2");
			LBL_DILAKSANAKAN2.Text=conn.GetFieldValue("DILAKSANAKAN2");

			TXT_DITERIMA1.Text=conn.GetFieldValue("DITERIMA1");
			LBL_DITERIMA1.Text=conn.GetFieldValue("DITERIMA1");

			TXT_DITERIMA2.Text=conn.GetFieldValue("DITERIMA2");
			LBL_DITERIMA2.Text=conn.GetFieldValue("DITERIMA2");

			TXT_DITERIMA3.Text=conn.GetFieldValue("DITERIMA3");
			LBL_DITERIMA3.Text=conn.GetFieldValue("DITERIMA3");

			TXT_AREA.Text=conn.GetFieldValue("AREA");
			LBL_AREA.Text=conn.GetFieldValue("AREA");

			try{
				RDO_STATUS.SelectedValue=conn.GetFieldValue("STATUS");
				LBL_RDO_STATUS.Text = RDO_STATUS.SelectedItem.Text;
			}
			catch{RDO_STATUS.SelectedValue="0";}
			
			TXT_OWN_AGE.Text=conn.GetFieldValue("own_age");
			LBL_OWN_AGE.Text=conn.GetFieldValue("own_age");

			TXT_SINCE.Text=conn.GetFieldValue("since");
			LBL_SINCE.Text=conn.GetFieldValue("since");

			TXT_Address1.Text=conn.GetFieldValue("address1");
			LBL_Address1.Text=conn.GetFieldValue("address1");

			TXT_NO1.Text=conn.GetFieldValue("add#1");
			LBL_NO1.Text=conn.GetFieldValue("add#1");

			TXT_CITY1.Text=conn.GetFieldValue("add_city1");
			LBL_CITY1.Text=conn.GetFieldValue("add_city1");

			TXT_ADDRESS2.Text=conn.GetFieldValue("address2");
			LBL_ADDRESS2.Text=conn.GetFieldValue("address2");

			TXT_NO2.Text=conn.GetFieldValue("add#2");
			LBL_NO2.Text=conn.GetFieldValue("add#2");

			TXT_CITY2.Text=conn.GetFieldValue("add_city2");
			LBL_CITY2.Text=conn.GetFieldValue("add_city2");

			TXT_PIC1.Text=conn.GetFieldValue("pic1");
			LBL_PIC1.Text=conn.GetFieldValue("pic1");

			TXT_PIC2.Text=conn.GetFieldValue("pic2");
			LBL_PIC2.Text=conn.GetFieldValue("pic2");

			TXT_PIC3.Text=conn.GetFieldValue("pic3");
			LBL_PIC3.Text=conn.GetFieldValue("pic3");

			TXT_EMPLOYEE.Text=conn.GetFieldValue("employee");
			LBL_EMPLOYEE.Text=conn.GetFieldValue("employee");

			TXT_EXPERT.Text=conn.GetFieldValue("expert");
			LBL_EXPERT.Text=conn.GetFieldValue("expert");

			TXT_ADMIN.Text=conn.GetFieldValue("admin");
			LBL_ADMIN.Text=conn.GetFieldValue("admin");

			TXT_OUTSOURCE.Text=conn.GetFieldValue("outsource");
			LBL_OUTSOURCE.Text=conn.GetFieldValue("outsource");

			try{
				RDO_EQUITMENT.SelectedValue=conn.GetFieldValue("equitment");
				LBL_RDO_EQUITMENT.Text = RDO_EQUITMENT.SelectedItem.Text;
			}
			catch{RDO_EQUITMENT.SelectedValue="0";}
			
			try{
				RDO_DATABASE.SelectedValue=conn.GetFieldValue("database_rsv");
				LBL_RDO_DATABASE.Text = RDO_DATABASE.SelectedItem.Text;
			}
			catch {RDO_DATABASE.SelectedValue="0";}

			try{
				RDO_BUILDING.SelectedValue=conn.GetFieldValue("building");
				LBL_RDO_BUILDING.Text =  RDO_BUILDING.SelectedItem.Text;
			}
			catch{RDO_BUILDING.SelectedValue="0";}
			
			try{
				RDO_ARSIP_ROOM.SelectedValue=conn.GetFieldValue("arsip_room");
				LBL_RDO_ARSIP_ROOM.Text = RDO_ARSIP_ROOM.SelectedItem.Text;
			}
			catch{RDO_ARSIP_ROOM.SelectedValue="0";}
			
			TXT_ACTIVITY1.Text=conn.GetFieldValue("activity1");
			LBL_ACTIVITY1.Text=conn.GetFieldValue("activity1");

			TXT_ACTIVITY2.Text=conn.GetFieldValue("activity2");
			LBL_ACTIVITY2.Text=conn.GetFieldValue("activity2"); 

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
						Label lbl = (Label) DGR_VISIT.Items[i].Cells[8].FindControl("LBL_RDO_HIST_VISIT");
						try{
							rblsitevisit.SelectedValue = conn.GetFieldValue(0,i);
							lbl.Text = rblsitevisit.SelectedValue;
						}
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
		
		private void AuditTrailCheck(string kodeJenisData)
		{
			string userName		= Session["FullName"].ToString();
			string status		= "update";
			string rekanan_ref	= Request.QueryString["rekanan_ref"];
			string regnum		= Request.QueryString["regnum"];			

			cekFIELD(kodeJenisData, rekanan_ref, regnum, userName, status);
				
		}

		private void cekFIELD(string kodeJenisData, string rekref, string regnum, string user, string stat)
		{
			
			string temp			=   "";
			string sqlpar		=	rekref + "', '" +
				regnum + "', '" +
				kodeJenisData + "', '" +
				jenisrek + "', '" +
				nama + "', '" +
				user + "', '" +
				stat +  "' ";

			//cek field yang berubah dan masukan ke audittrail jika ada perubahan
			string tglWW = tool.ConvertDate(LBL_DAY.Text, LBL_BLN_VISIT.Text, LBL_YEAR.Text);
			string tglWWNew = tool.ConvertDate(TXT_DAY.Text, DDL_BLN_VISIT.SelectedValue, TXT_YEAR.Text);
			if(tglWW!=tglWWNew)
			{	
				temp="Tgl Kunjungan: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + tglWW.Replace("'","") + "', '" +
						temp + tglWWNew.Replace("'","") + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_DILAKSANAKAN1.Text!=TXT_DILAKSANAKAN1.Text)
			{
				temp="Dilaksanakan oleh: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_DILAKSANAKAN1.Text + "', '" +
						temp + TXT_DILAKSANAKAN1.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_DILAKSANAKAN2.Text!=TXT_DILAKSANAKAN2.Text)
			{
				temp="Dilaksanakan oleh: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_DILAKSANAKAN2.Text + "', '" +
						temp + TXT_DILAKSANAKAN2.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_DITERIMA1.Text!=TXT_DITERIMA1.Text)
			{
				temp="Diterima oleh: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_DITERIMA1.Text + "', '" +
						temp + TXT_DITERIMA1.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_DITERIMA2.Text!=TXT_DITERIMA2.Text)
			{
				temp="Diterima oleh: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_DITERIMA2.Text + "', '" +
						temp + TXT_DITERIMA2.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_DITERIMA3.Text!=TXT_DITERIMA3.Text)
			{
				temp="Diterima oleh: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_DITERIMA3.Text + "', '" +
						temp + TXT_DITERIMA3.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_AREA.Text!=TXT_AREA.Text)
			{
				temp="Luas Bangunan Tempat Usaha: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_AREA.Text + "', '" +
						temp + TXT_AREA.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_RDO_STATUS.Text!=RDO_STATUS.SelectedItem.Text)
			{
				temp="Status Kepemilikan: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_RDO_STATUS.Text + "', '" +
						temp + RDO_STATUS.SelectedItem.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_OWN_AGE.Text!=TXT_OWN_AGE.Text)
			{
				temp="Lama menempati gedung (tahun): ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_OWN_AGE.Text + "', '" +
						temp + TXT_OWN_AGE.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_SINCE.Text!=TXT_SINCE.Text)
			{
				temp="Menempati Gedung Sejak Tahun: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_SINCE.Text + "', '" +
						temp + TXT_SINCE.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_SINCE.Text!=TXT_SINCE.Text)
			{
				temp="Menempati Gedung Sejak Tahun: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_SINCE.Text + "', '" +
						temp + TXT_SINCE.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_Address1.Text!=TXT_Address1.Text)
			{
				temp="Alamat Cabang : ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_Address1.Text + "', '" +
						temp + TXT_Address1.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_NO1.Text!=TXT_NO1.Text)
			{
				temp="Alamat Cabang - No: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NO1.Text + "', '" +
						temp + TXT_NO1.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_CITY1.Text!=TXT_CITY1.Text)
			{
				temp="Alamat Cabang - Kota: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NO1.Text + "', '" +
						temp + TXT_NO1.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_ADDRESS2.Text!=TXT_ADDRESS2.Text)
			{
				temp="Alamat Cabang2 : ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_Address1.Text + "', '" +
						temp + TXT_Address1.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_NO2.Text!=TXT_NO1.Text)
			{
				temp="Alamat Cabang2 - No: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NO1.Text + "', '" +
						temp + TXT_NO1.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_CITY2.Text!=TXT_CITY1.Text)
			{
				temp="Alamat Cabang2 - Kota: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NO1.Text + "', '" +
						temp + TXT_NO1.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_PIC1.Text!=TXT_PIC1.Text)
			{
				temp="Kontak Person Cabang: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_PIC1.Text + "', '" +
						temp + TXT_PIC1.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_PIC1.Text!=TXT_PIC2.Text)
			{
				temp="Kontak Person Cabang2: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_PIC2.Text + "', '" +
						temp + TXT_PIC2.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_PIC3.Text!=TXT_PIC3.Text)
			{
				temp="Kontak Person Cabang3: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_PIC3.Text + "', '" +
						temp + TXT_PIC3.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_PIC3.Text!=TXT_PIC3.Text)
			{
				temp="Kontak Person Cabang3: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_PIC3.Text + "', '" +
						temp + TXT_PIC3.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_EMPLOYEE.Text!=TXT_EMPLOYEE.Text)
			{
				temp="Jumlah Tenaga Kerja: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_EMPLOYEE.Text + "', '" +
						temp + TXT_EMPLOYEE.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_EXPERT.Text!=TXT_EXPERT.Text)
			{
				temp="Jumlah Tenaga Ahli: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_EXPERT.Text + "', '" +
						temp + TXT_EXPERT.Text + "'"; 
					conn.ExecuteNonQuery(); 
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
		
			if(LBL_ADMIN.Text!=TXT_ADMIN.Text)
			{
				temp="Jumlah Tenaga Administrasi: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_ADMIN.Text + "', '" +
						temp + TXT_ADMIN.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_OUTSOURCE.Text!=TXT_OUTSOURCE.Text)
			{
				temp="Jumlah Tenaga Kerja Tidak Tetap: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_OUTSOURCE.Text + "', '" +
						temp + TXT_OUTSOURCE.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_RDO_EQUITMENT.Text!=RDO_EQUITMENT.SelectedItem.Text)
			{
				temp="Peralatan Kantor: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_RDO_EQUITMENT.Text + "', '" +
						temp + RDO_EQUITMENT.SelectedItem.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_RDO_DATABASE.Text!=RDO_DATABASE.SelectedItem.Text)
			{
				temp="Sistem Database yang dimiliki: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_RDO_DATABASE.Text + "', '" +
						temp + RDO_DATABASE.SelectedItem.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_RDO_BUILDING.Text!=RDO_BUILDING.SelectedItem.Text)
			{
				temp="Kondisi Gedung: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_RDO_BUILDING.Text + "', '" +
						temp + RDO_BUILDING.SelectedItem.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_RDO_ARSIP_ROOM.Text!=RDO_ARSIP_ROOM.SelectedItem.Text)
			{
				temp="Kondisi Ruang Arsip: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_RDO_ARSIP_ROOM.Text + "', '" +
						temp + RDO_ARSIP_ROOM.SelectedItem.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_ACTIVITY1.Text!=TXT_ACTIVITY1.Text)
			{
				temp="Kegiatan yang sedang dilakukan: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_ACTIVITY1.Text + "', '" +
						temp + TXT_ACTIVITY1.Text + "'"; 
					conn.ExecuteNonQuery(); 
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

			if(LBL_ACTIVITY2.Text!=TXT_ACTIVITY2.Text)
			{
				temp="Kegiatan yang sedang dilakukan: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_ACTIVITY2.Text + "', '" +
						temp + TXT_ACTIVITY2.Text + "'"; 
					conn.ExecuteNonQuery(); 
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
			
			for (int i = 0; i < DGR_VISIT.Items.Count; i++)
			{	
				RadioButtonList rblsitevisit= (RadioButtonList)DGR_VISIT.Items[i].Cells[6].FindControl("RBL_VISIT");
				Label lbl = (Label) DGR_VISIT.Items[i].Cells[8].FindControl("LBL_RDO_HIST_VISIT");
			
				if (lbl.Text != rblsitevisit.SelectedValue)
				{
					temp="Skala " + DGR_VISIT.Items[i].Cells[2].Text + " : ";
					try
					{						
						
						conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
							sqlpar + ", '" +
							temp + lbl.Text+ "', '" +
							temp + rblsitevisit.SelectedValue + "'"; 
						conn.ExecuteNonQuery(); 
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

			AuditTrailCheck("41");	
						
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
			try 
			{				
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();
				
				if(Request.QueryString["flag"]=="1")
				{
					for (int i = 0; i < conn.GetRowCount(); i++) 
					{
						if(conn.GetFieldValue(i,0)!="A010201" && conn.GetFieldValue(i,0)!="A010205")
						{
							HyperLink t = new HyperLink();
							t.Text = conn.GetFieldValue(i, 2);
							t.Font.Bold = true;
							string strtemp = "";
							if (conn.GetFieldValue(i, 3).Trim()!= "") 
							{
								if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
									strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"] + "&flag=" + Request.QueryString["flag"]+ "&view=" + Request.QueryString["view"];
								else	
									strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"] + "&flag=" + Request.QueryString["flag"]+ "&view=" + Request.QueryString["view"];
								//t.ForeColor = Color.MidnightBlue; 
								if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
									strtemp = strtemp + "&par=" + Request.QueryString["par"] + "&mc2=" + Request.QueryString["mc2"];
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
				} 
				else
				{
					for (int i = 0; i < conn.GetRowCount(); i++) 
					{
						HyperLink t = new HyperLink();
						t.Text = conn.GetFieldValue(i, 2);
						t.Font.Bold = true;
						string strtemp = "";
						if (conn.GetFieldValue(i, 3).Trim()!= "") 
						{
							if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
								strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"]+ "&view=" + Request.QueryString["view"];
							else	
								strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+ "&view=" + Request.QueryString["view"];
							//t.ForeColor = Color.MidnightBlue; 
							if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
								strtemp = strtemp + "&par=" + Request.QueryString["par"] + "&mc2=" + Request.QueryString["mc2"];
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

		private void RadioButton16_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["par"] != null && Request.QueryString["par"] != "") 
			{
				Response.Redirect(Request.QueryString["par"] + "&mc=" + Request.QueryString["mc2"] + "&regnum=" + Request.QueryString["regnum"] + "&rekanan_ref=" + Request.QueryString["rekanan_ref"] + "&tc=" + Request.QueryString["tc"]+ "&view=" + Request.QueryString["view"]);}
			else
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
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
	}
}
