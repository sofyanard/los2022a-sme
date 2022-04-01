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
	/// Summary description for AnalisaScoringInput.
	/// </summary>
	public partial class AnalisaScoringInput : System.Web.UI.Page
	{

		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			conn.QueryString="delete from REKANAN_QUAN_COUNT";
			conn.ExecuteQuery();
			/*conn.QueryString="delete rekanan_quantitative";
			conn.ExecuteQuery();
			conn.QueryString="delete rekanan_qualitative"; 
			conn.ExecuteQuery();
			conn.QueryString="delete rekanan_crite";
			conn.ExecuteQuery(); */

			ViewMenu();
			

			/*BindQual();			    
			BindDataQuanitative();
			BindCla(); */

			if (!IsPostBack)
			{
				BindQual();			    
				BindDataQuanitative();
				BindCla(); 
				//BindDataQuanR();
				ViewData();
				//BindDataQualR();
				
				
			}
			CekView();
		}

		private void ViewData()
		{
			conn.QueryString="select * from rekanan_score where regnum='" + Request.QueryString["regnum"] + "' ";
			conn.ExecuteQuery();
			TXT_TOTAL_QUAN.Text=conn.GetFieldValue("sc_kuantitatif");
			TXT_TOTAL_QUAL.Text=conn.GetFieldValue("sc_kualitatif");
			TOTAL_SCORING.Text=conn.GetFieldValue("total");
			KLASIFIKASI.Text=conn.GetFieldValue("klasifikasi");			
		}

		private void BindDataQuanitative()
		{
			conn.QueryString = "select * from vw_rekanan_analisa_quan_new WHERE regnum = '" + Request.QueryString["regnum"] + "' ORDER BY QUANTITATIVEID, SUBQUANTITATIVEID";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_QUAN.DataSource = dt;
			try 
			{
				DGR_QUAN.DataBind();
			}
			catch 
			{
				DGR_QUAN.CurrentPageIndex = 0;
				DGR_QUAN.DataBind();
			}

			conn.QueryString="select * from rekanan_quantitative where regnum = '" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				BindDataQuantitativeSubSubQuanNew();
			}
			else
			{
				BindDataQuantitativeSubSubQuan();
			}			
			
		}
		
		private void BindDataQuantitativeSubSubQuanNew()
		{
			for (int i=0;i<DGR_QUAN.Items.Count;i++)
			{
				RadioButtonList rblsubsubquan = (RadioButtonList) DGR_QUAN.Items[i].Cells[4].FindControl("RBL_SUBSUBQUAN");

				conn.QueryString = "exec REKANAN_VIEWQUANTITATIVE_New '" + Request.QueryString["regnum"] + "', '" + DGR_QUAN.Items[i].Cells[0].Text.Trim() + "', '" + DGR_QUAN.Items[i].Cells[1].Text.Trim() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtsubsubquan = new DataTable();
					dtsubsubquan = conn.GetDataTable().Copy();

					string subsubquantitativeid = "", nilai = "";
					DataRow[] drs = dtsubsubquan.Select();
					foreach (DataRow dr in drs)
					{
						if (dr["CHECKED"].ToString() == "1")
						{
							subsubquantitativeid = dr["SUBSUBQUANTITATIVEID"].ToString();
							nilai = dr["NILAI"].ToString();							
						}						
					}

					rblsubsubquan.DataSource = dtsubsubquan;
					try 
					{
						rblsubsubquan.DataValueField = "SUBSUBQUANTITATIVEID";
						rblsubsubquan.DataTextField = "SUBSUBQUANTITATIVEDESC";
						if (subsubquantitativeid != "")
							try {rblsubsubquan.SelectedValue = subsubquantitativeid;} 
							catch {}
						rblsubsubquan.DataBind();

						//Fill column SCORE and FLAG
						DGR_QUAN.Items[i].Cells[5].Text = nilai;
						//DGR_QUAN.Items[i].Cells[6].Text = subsubqualflag;
					} 
					catch {}

					//if(Request.QueryString["view"]=="1")
					//	DGR_QUAN.Items[i].Cells[4].Enabled = false;
				}
			}
		}

		private void BindDataQuantitativeSubSubQuan()
		{
			for (int i=0;i<DGR_QUAN.Items.Count;i++)
			{
				RadioButtonList rblsubsubquan = (RadioButtonList) DGR_QUAN.Items[i].Cells[4].FindControl("RBL_SUBSUBQUAN");

				conn.QueryString = "exec REKANAN_VIEWQUANTITATIVE '" + Request.QueryString["regnum"] + "', '" + DGR_QUAN.Items[i].Cells[0].Text.Trim() + "', '" + DGR_QUAN.Items[i].Cells[1].Text.Trim() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtsubsubquan = new DataTable();
					dtsubsubquan = conn.GetDataTable().Copy();

					string subsubquantitativeid = "", nilai = "";
					DataRow[] drs = dtsubsubquan.Select();
					foreach (DataRow dr in drs)
					{
						if (dr["CHECKED"].ToString() == "0")
						{
							subsubquantitativeid = dr["SUBSUBQUANTITATIVEID"].ToString();
							nilai = dr["NILAI"].ToString();							
						}						
					}

					rblsubsubquan.DataSource = dtsubsubquan;
					try 
					{
						rblsubsubquan.DataValueField = "SUBSUBQUANTITATIVEID";
						rblsubsubquan.DataTextField = "SUBSUBQUANTITATIVEDESC";
						if (subsubquantitativeid != "")
							try {rblsubsubquan.SelectedValue = subsubquantitativeid;} 
							catch {}
						rblsubsubquan.DataBind();

						//Fill column SCORE and FLAG
						DGR_QUAN.Items[i].Cells[5].Text = nilai;
						//DGR_QUAN.Items[i].Cells[6].Text = subsubqualflag;
					} 
					catch {}

					//if(Request.QueryString["view"]=="1")
					//	DGR_QUAN.Items[i].Cells[4].Enabled = false;
				}
			}
		}


		
		
		private void BindQual()
		{
			conn.QueryString = "select * from vw_rekanan_analisa_qual_new WHERE regnum = '" + Request.QueryString["regnum"] + "' ORDER BY QUALITATIVEID";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_QUAL.DataSource = dt;
			try 
			{
				DGR_QUAL.DataBind();
			}
			catch 
			{
				DGR_QUAL.CurrentPageIndex = 0;
				DGR_QUAL.DataBind();
			}

			conn.QueryString="select * from rekanan_qualitative where regnum = '" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				BindDataQualitativeSubQualNew();
			}
			else
			{
				BindDataQualitativeSubQual();
			}			
		}

		private void BindDataQualitativeSubQualNew()
		{
			for (int i=0;i<DGR_QUAL.Items.Count;i++)
			{
				RadioButtonList rblsubqual = (RadioButtonList) DGR_QUAL.Items[i].Cells[3].FindControl("RBL_SUBQUAL");

				conn.QueryString = "exec REKANAN_VIEWQUALITATIVE_New '" + DGR_QUAL.Items[i].Cells[5].Text.Trim() + "','" + Request.QueryString["regnum"] + "', '" + DGR_QUAL.Items[i].Cells[0].Text.Trim() + "' ";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtsubqual = new DataTable();
					dtsubqual = conn.GetDataTable().Copy();

					string subqualitativeid = "", score = "";
					DataRow[] drs = dtsubqual.Select();
					foreach (DataRow dr in drs)
					{
						if (dr["CHECKED"].ToString() == "1")
						{
							subqualitativeid = dr["SUBQUALITATIVEID"].ToString();
							score = dr["SCORE"].ToString();
							//subsubqualflag = dr["FLAG"].ToString();
						}
					}

					rblsubqual.DataSource = dtsubqual;
					try 
					{
						rblsubqual.DataValueField = "SUBQUALITATIVEID";
						rblsubqual.DataTextField = "SUBQUALITATIVEDESC";
						
						if (subqualitativeid != "")
							try {rblsubqual.SelectedValue = subqualitativeid;} 
							catch {}
						rblsubqual.DataBind();

						//Fill column SCORE and FLAG
						DGR_QUAL.Items[i].Cells[4].Text = score;
						//DGR_QUAN.Items[i].Cells[6].Text = subsubqualflag;
					} 
					catch {}

					//if(Request.QueryString["view"]=="1")
					//	DGR_QUAL.Items[i].Cells[3].Enabled = false;
				}
			}
		}
        
		private void BindDataQualitativeSubQual()
		{
			for (int i=0;i<DGR_QUAL.Items.Count;i++)
			{
				RadioButtonList rblsubqual = (RadioButtonList) DGR_QUAL.Items[i].Cells[3].FindControl("RBL_SUBQUAL");

				conn.QueryString = "exec REKANAN_VIEWQUALITATIVE '" + DGR_QUAL.Items[i].Cells[5].Text.Trim() + "','" + Request.QueryString["regnum"] + "', '" + DGR_QUAL.Items[i].Cells[0].Text.Trim() + "' ";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtsubqual = new DataTable();
					dtsubqual = conn.GetDataTable().Copy();

					string subqualitativeid = "", score = "";
					DataRow[] drs = dtsubqual.Select();
					foreach (DataRow dr in drs)
					{
						if (dr["CHECKED"].ToString() == "0")
						{
							subqualitativeid = dr["SUBQUALITATIVEID"].ToString();
							score = dr["SCORE"].ToString();
							//subsubqualflag = dr["FLAG"].ToString();
						}
					}

					rblsubqual.DataSource = dtsubqual;
					try 
					{
						rblsubqual.DataValueField = "SUBQUALITATIVEID";
						rblsubqual.DataTextField = "SUBQUALITATIVEDESC";
						
						if (subqualitativeid != "")
							try {rblsubqual.SelectedValue = subqualitativeid;} 
							catch {}
						rblsubqual.DataBind();

						//Fill column SCORE and FLAG
						DGR_QUAL.Items[i].Cells[4].Text = score;
						//DGR_QUAN.Items[i].Cells[6].Text = subsubqualflag;
					} 
					catch {}

					//if(Request.QueryString["view"]=="1")
					//	DGR_QUAL.Items[i].Cells[3].Enabled = false;
				}
			}
		}


		private void BindCla()
		{
			conn.QueryString="select * from VW_REKANAN_Analisa_Cla_New WHERE regnum = '" + Request.QueryString["regnum"] + "' ORDER BY CRITEID";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_CLA.DataSource = dt;
			try 
			{
				DGR_CLA.DataBind();
			}
			catch 
			{
				DGR_CLA.CurrentPageIndex = 0;
				DGR_CLA.DataBind();
			}

			conn.QueryString="select * from rekanan_crite where regnum = '" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				BindDataClaSubNew();
			}
			else
			{
				BindDataClaSub();
			}		
		}

		private void BindDataClaSub()
		{
			for (int i=0;i<DGR_CLA.Items.Count;i++)
			{
				RadioButtonList rblcla = (RadioButtonList) DGR_CLA.Items[i].Cells[3].FindControl("RBL_CLA");

				conn.QueryString = "exec REKANAN_VIEWCRIT '" + DGR_CLA.Items[i].Cells[5].Text.Trim() + "','" + Request.QueryString["regnum"] + "', '" + DGR_CLA.Items[i].Cells[0].Text.Trim() + "' ";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtcla = new DataTable();
					dtcla = conn.GetDataTable().Copy();

					string subcriteid = "";
					DataRow[] drs = dtcla.Select();
					foreach (DataRow dr in drs)
					{
						if (dr["CHECKED"].ToString() == "0")
						{
							subcriteid = dr["SUBCRITEID"].ToString();
								
						}
					}

					rblcla.DataSource = dtcla;
					try 
					{
						rblcla.DataValueField = "SUBCRITEID";
						rblcla.DataTextField = "SUBCRITEDESC";
						if (subcriteid != "")
							try {rblcla.SelectedValue = subcriteid;} 
							catch {}
						rblcla.DataBind();					
					} 
					catch {}

					//if(Request.QueryString["view"]=="1")
					//	DGR_CLA.Items[i].Cells[3].Enabled = false;
				}
			}
		}

		private void BindDataClaSubNew()
		{
			for (int i=0;i<DGR_CLA.Items.Count;i++)
			{
				RadioButtonList rblcla = (RadioButtonList) DGR_CLA.Items[i].Cells[3].FindControl("RBL_CLA");

				conn.QueryString = "exec REKANAN_VIEWCRIT_New '" + DGR_CLA.Items[i].Cells[5].Text.Trim() + "','" + Request.QueryString["regnum"] + "', '" + DGR_CLA.Items[i].Cells[0].Text.Trim() + "' ";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtcla = new DataTable();
					dtcla = conn.GetDataTable().Copy();

					string subcriteid = "";
					DataRow[] drs = dtcla.Select();
					foreach (DataRow dr in drs)
					{
						if (dr["CHECKED"].ToString() == "1")
						{
							subcriteid = dr["SUBCRITEID"].ToString();
								
						}
					}

					rblcla.DataSource = dtcla;
					try 
					{
						rblcla.DataValueField = "SUBCRITEID";
						rblcla.DataTextField = "SUBCRITEDESC";
						if (subcriteid != "")
							try {rblcla.SelectedValue = subcriteid;} 
							catch {}
						rblcla.DataBind();					
					} 
					catch {}

					//if(Request.QueryString["view"]=="1")
					//	DGR_CLA.Items[i].Cells[3].Enabled = false;
				}
			}
		}


		private void InsertUpdateQuan()
		{
			conn.QueryString = "select * from rekanan_quantitative WHERE regnum = '" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				for (int i=0; i<DGR_QUAN.Items.Count; i++)
				{
					RadioButtonList rblsubsubquan = (RadioButtonList) DGR_QUAN.Items[i].Cells[4].FindControl("RBL_SUBSUBQUAN");

					try
					{
						conn.QueryString = "exec REKANAN_UPDATEQUANTITATIVE_NEW3 '" +
							Request.QueryString["regnum"] + "', '" +
							DGR_QUAN.Items[i].Cells[0].Text.Trim() + "', '" + 
							DGR_QUAN.Items[i].Cells[1].Text.Trim() + "', '" +
							rblsubsubquan.SelectedValue.Trim() + "'";
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
					//	if(Request.QueryString["view"]=="1")
					//	DGR_QUAN.Items[i].Cells[4].Enabled = false;
				
				}		

			}

			else
			{
				for (int i=0; i<DGR_QUAN.Items.Count; i++)
				{
					RadioButtonList rblsubsubquan = (RadioButtonList) DGR_QUAN.Items[i].Cells[4].FindControl("RBL_SUBSUBQUAN");

					try
					{
						conn.QueryString = "exec REKANAN_UPDATEQUANTITATIVE_NEW2 '" +
							Request.QueryString["regnum"] + "', '" +
							DGR_QUAN.Items[i].Cells[0].Text.Trim() + "', '" + 
							DGR_QUAN.Items[i].Cells[1].Text.Trim() + "', '" +
							rblsubsubquan.SelectedValue.Trim() + "'";
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
				
					//	if(Request.QueryString["view"]=="1")
					//		DGR_QUAN.Items[i].Cells[4].Enabled = false;
				
				}		

			}
		}
		
		private void InsertUpdateQual()
		{
			conn.QueryString = "select * from rekanan_qualitative WHERE regnum = '" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				for (int i=0; i<DGR_QUAL.Items.Count; i++)
				{
					RadioButtonList rblsubqual = (RadioButtonList) DGR_QUAL.Items[i].Cells[3].FindControl("RBL_SUBQUAL");

					try
					{
						conn.QueryString = "exec REKANAN_UPDATEQUALITATIVE_NEW3 '" +
							Request.QueryString["regnum"] + "', '" +
							DGR_QUAL.Items[i].Cells[0].Text.Trim() + "', '" + 						
							rblsubqual.SelectedValue.Trim() + "'";
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
					
					//if(Request.QueryString["view"]=="1")
					//	DGR_QUAL.Items[i].Cells[3].Enabled = false;
				
				}
			}

			else
			{
				for (int i=0; i<DGR_QUAL.Items.Count; i++)
				{
					RadioButtonList rblsubqual = (RadioButtonList) DGR_QUAL.Items[i].Cells[3].FindControl("RBL_SUBQUAL");

					try
					{
						conn.QueryString = "exec REKANAN_UPDATEQUALITATIVE_NEW2 '" +
							Request.QueryString["regnum"] + "', '" +
							DGR_QUAL.Items[i].Cells[0].Text.Trim() + "', '" + 						
							rblsubqual.SelectedValue.Trim() + "'";
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
				
					//if(Request.QueryString["view"]=="1")
					//	DGR_QUAL.Items[i].Cells[3].Enabled = false;
				
				}
			}


		}
		private void InsertUpdateCrite()
		{
			conn.QueryString = "select * from rekanan_crite WHERE regnum = '" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				for (int i=0; i<DGR_CLA.Items.Count; i++)
				{
					RadioButtonList rblcla = (RadioButtonList) DGR_CLA.Items[i].Cells[3].FindControl("RBL_CLA");

					try
					{
						conn.QueryString = "exec REKANAN_UPDATECRITE_NEW3 '" +
							Request.QueryString["regnum"] + "', '" +
							DGR_CLA.Items[i].Cells[0].Text.Trim() + "', '" + 						
							rblcla.SelectedValue.Trim() + "'";
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
			
					//if(Request.QueryString["view"]=="1")
					//	DGR_CLA.Items[i].Cells[3].Enabled = false;
				
				}
			}
			else
			{
				for (int i=0; i<DGR_CLA.Items.Count; i++)
				{
					RadioButtonList rblcla = (RadioButtonList) DGR_CLA.Items[i].Cells[3].FindControl("RBL_CLA");

					try
					{
						conn.QueryString = "exec REKANAN_UPDATECRITE_NEW2 '" +
							Request.QueryString["regnum"] + "', '" +
							DGR_CLA.Items[i].Cells[0].Text.Trim() + "', '" + 						
							rblcla.SelectedValue.Trim() + "'";
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
		
					//if(Request.QueryString["view"]=="1")
					//	DGR_CLA.Items[i].Cells[3].Enabled = false;
				
				}
			}
		}
		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			//Data Quantitative
			InsertUpdateQuan();
			LBL_RFREKANANTYPE.Text=DGR_QUAN.Items[0].Cells[6].Text.Trim() ;
			conn.QueryString= "exec REKANAN_QUAN_CALCULATE '" + DGR_QUAN.Items[0].Cells[6].Text.Trim() + "', '" + Request.QueryString["regnum"] + "' ";
			conn.ExecuteNonQuery();

			BindDataQuanR();
			TXT_TOTAL_QUAN.Text= DGR_QUANR.Items[0].Cells[0].Text.Trim() ;	

			//Data Qualitative
			InsertUpdateQual();
			BindDataQualR();
			
				
			try 
			{
				TXT_TOTAL_QUAL.Text= DGR_QUALR.Items[0].Cells[0].Text.Trim() ;
				if (TXT_TOTAL_QUAL.Text=="null" || TXT_TOTAL_QUAL.Text=="&nbsp;" )
					TXT_TOTAL_QUAL.Text="0";}
			catch{TXT_TOTAL_QUAL.Text="0";}
			

			//Data Clasifikasi
			InsertUpdateCrite();			

			conn.QueryString= "exec REKANAN_INSERT_SCORE '" + Request.QueryString["regnum"] + "', '" + LBL_RFREKANANTYPE.Text + "' , "+ tool.ConvertFloat(DGR_QUANR.Items[0].Cells[0].Text.Trim())+" ,"+ tool.ConvertFloat(TXT_TOTAL_QUAL.Text.Trim()) +"  ";								
			conn.ExecuteNonQuery();
		    
			BindScoring();
			TOTAL_SCORING.Text=DGR_SCORE.Items[0].Cells[3].Text.Trim();
			KLASIFIKASI.Text=DGR_SCORE.Items[0].Cells[4].Text.Trim();

			//Cek Kelengkapan Scoring Analisa Kualitatif dan Kuantitatif
			if ( (LBL_RFREKANANTYPE.Text=="06") || (LBL_RFREKANANTYPE.Text=="08"))
			{
				conn.QueryString="select * from rekanan_quantitative where regnum='" + Request.QueryString["regnum"] + "' and nilai is null";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0)
				{
					GlobalTools.popMessage(this, "Input Data Kuantitatif belum lengkap!");
					return;	
				}
			}
			else
			{
				conn.QueryString="select * from rekanan_quantitative where regnum='" + Request.QueryString["regnum"] + "' and nilai is null";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0)
				{
					GlobalTools.popMessage(this, "Input Data Kuantitatif belum lengkap!");
					return;	
				}

				conn.QueryString="select * from rekanan_qualitative where regnum='" + Request.QueryString["regnum"] + "' and score is null";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0)
				{
					GlobalTools.popMessage(this, "Input Data Kualitatif belum lengkap!");
					return;	
				}					
			}

			//Cek Kelengkapan Scoring Kriteria Tambahan
			if ((LBL_RFREKANANTYPE.Text=="01") || (LBL_RFREKANANTYPE.Text=="02") || (LBL_RFREKANANTYPE.Text=="03")|| (LBL_RFREKANANTYPE.Text=="07"))
			{
				conn.QueryString="select * from rekanan_crite where regnum='" + Request.QueryString["regnum"] + "' and nilai is null";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0)
				{
					GlobalTools.popMessage(this, "Input Data Kriteria Tambahan belum lengkap!");
					return;	
				}
			}


		}	

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			Clear();
		}

		private void Clear()
		{
			BindDataQuantitativeSubSubQuan();
			BindDataQualitativeSubQual();
			BindDataClaSub();
			TXT_TOTAL_QUAN.Text="";
			TXT_TOTAL_QUAL.Text="";
			TOTAL_SCORING.Text="";
			KLASIFIKASI.Text="";
		}

		private void BindDataQuanR()
		{
			if (LBL_RFREKANANTYPE.Text=="01")//Akreditasi Perusahaan Penilai
			{
				conn.QueryString="Select sum(hasil)*0.75 as SUM from REKANAN_QUAN_COUNT ";
				conn.ExecuteQuery();
			}
			else if (LBL_RFREKANANTYPE.Text=="02")//Akreditasi Kantor Akuntan Publik
			{
				conn.QueryString="Select sum(hasil)*0.7 as SUM from REKANAN_QUAN_COUNT ";
				conn.ExecuteQuery();
			}
			else if (LBL_RFREKANANTYPE.Text=="03")//Konsultan Manajemen
			{
				conn.QueryString="Select sum(hasil)*0.6 as SUM from REKANAN_QUAN_COUNT ";
				conn.ExecuteQuery();
			}
			else if (LBL_RFREKANANTYPE.Text=="04")//Perusahaan Asuransi
			{
				conn.QueryString="Select sum(hasil)*0.6 as SUM from REKANAN_QUAN_COUNT ";
				conn.ExecuteQuery();
			}
			else if (LBL_RFREKANANTYPE.Text=="05")//Perusahaan Asuransi
			{
				conn.QueryString="Select sum(hasil)*0.6 as SUM from REKANAN_QUAN_COUNT ";
				conn.ExecuteQuery();
			}
			else if (LBL_RFREKANANTYPE.Text=="06")//Broker Asuransi
			{
				conn.QueryString="Select sum(hasil) as SUM from REKANAN_QUAN_COUNT ";
				conn.ExecuteQuery();
			}
			else if (LBL_RFREKANANTYPE.Text=="07")//Notaris
			{
				conn.QueryString="Select sum(hasil)*0.6 as SUM from REKANAN_QUAN_COUNT ";
				conn.ExecuteQuery();
			}
			else if (LBL_RFREKANANTYPE.Text=="08")//Balai Lelang
			{
				conn.QueryString="Select sum(hasil) as SUM from REKANAN_QUAN_COUNT ";
				conn.ExecuteQuery();
			}

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_QUANR.DataSource = dt;
			try 
			{
				DGR_QUANR.DataBind();
			}
			catch 
			{
				DGR_QUANR.CurrentPageIndex = 0;
				DGR_QUANR.DataBind();
			}
		}
	
		private void BindDataQualR()
		{
			
			if (LBL_RFREKANANTYPE.Text=="01")//Akreditasi Perusahaan Penilai
			{
				conn.QueryString="Select sum(score)*0.25 as SUM from REKANAN_QUALITATIVE where regnum='" + Request.QueryString["regnum"] + "' ";
				conn.ExecuteQuery();
			}
			else if (LBL_RFREKANANTYPE.Text=="02")//Akreditasi Kantor Akuntan Publik
			{
				conn.QueryString="Select sum(score)*0.3 as SUM from REKANAN_QUALITATIVE where regnum='" + Request.QueryString["regnum"] + "' ";
				conn.ExecuteQuery();
			}
			else if (LBL_RFREKANANTYPE.Text=="03")//Konsultan Manajemen
			{
				conn.QueryString="Select sum(score)*0.4 as SUM from REKANAN_QUALITATIVE where regnum='" + Request.QueryString["regnum"] + "' ";
				conn.ExecuteQuery();
			}
			else if (LBL_RFREKANANTYPE.Text=="04")//Perusahaan Asuransi
			{
				conn.QueryString="Select sum(score)*0.4 as SUM from REKANAN_QUALITATIVE where regnum='" + Request.QueryString["regnum"] + "' ";
				conn.ExecuteQuery();
			}
			else if (LBL_RFREKANANTYPE.Text=="05")//Perusahaan Asuransi
			{
				conn.QueryString="Select sum(score)*0.4 as SUM from REKANAN_QUALITATIVE where regnum='" + Request.QueryString["regnum"] + "' ";
				conn.ExecuteQuery();
			}
			
			else if (LBL_RFREKANANTYPE.Text=="07")//Notaris
			{
				conn.QueryString="Select sum(score)*0.4 as SUM from REKANAN_QUALITATIVE where regnum='" + Request.QueryString["regnum"] + "' "; 
				conn.ExecuteQuery();
			}
			

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_QUALR.DataSource = dt;
			try 
			{
				DGR_QUALR.DataBind();
			}
			catch 
			{
				DGR_QUALR.CurrentPageIndex = 0;
				DGR_QUALR.DataBind();
			}			
		}
	
		private void BindScoring()
		{
			conn.QueryString="Select * from rekanan_score where regnum= '" + Request.QueryString["regnum"] + "' ";
			conn.ExecuteQuery();
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_SCORE.DataSource = dt;
			try 
			{
				DGR_SCORE.DataBind();
			}
			catch 
			{
				DGR_SCORE.CurrentPageIndex = 0;
				DGR_SCORE.DataBind();
			}
		}
		

		private void ViewMenu()
		{
			try 
			{				
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"' and sm_id not in ('A010303') ";
				conn.ExecuteQuery();
				
				if(Request.QueryString["flag"]=="1")
				{
					for (int i = 0; i < conn.GetRowCount(); i++) 
					{
						if(conn.GetFieldValue(i,0)!="A010301" && conn.GetFieldValue(i,0)!="A010304" && conn.GetFieldValue(i,0)!="A010305")
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
								strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"] + "&exist=1"+ "&view=" + Request.QueryString["view"];
							else	
								strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+ "&exist=1"+ "&view=" + Request.QueryString["view"];
							//t.ForeColor = Color.MidnightBlue; 
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

		private void DGR_QUAN_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_QUAN.CurrentPageIndex = e.NewPageIndex;
			BindDataQuanitative();
		}

		private void DGR_QUANR_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_QUANR.CurrentPageIndex = e.NewPageIndex;
			BindDataQuanR();
			
		}		

		private void DGR_QUAL_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_QUAL.CurrentPageIndex = e.NewPageIndex;
			BindQual();
		}

		private void DGR_CLA_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_CLA.CurrentPageIndex = e.NewPageIndex;
			BindCla();
		}
		
		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			/*if (Request.QueryString["par"] != null && Request.QueryString["par"] != "") 
			{
				Response.Redirect(Request.QueryString["par"] + "&mc=" + Request.QueryString["mc2"] + "&regnum=" + Request.QueryString["regnum"] + "&rekanan_ref=" + Request.QueryString["rekanan_ref"] + "&tc=" + Request.QueryString["tc"]+ "&view=" + Request.QueryString["view"]);}
			else
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
			*/
			Response.Redirect("ListRekananInput.aspx?tc=" + Request.QueryString["tc"]+ "&mc=" + Request.QueryString["mc"]);
		}

		protected void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/SME/CEA/PrintScoring.aspx?rekanan_ref=" + Request.QueryString["rekanan_ref"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&regnum=" + Request.QueryString["regnum"]);
		}

		private void CekView()
		{
			if(Request.QueryString["view"]=="1")
			{
				BTN_CLEAR.Enabled = false;
				BTN_PRINT.Enabled = false;
				BTN_SAVE.Enabled = false;
				TXT_TOTAL_QUAN.ReadOnly = true;
				TXT_TOTAL_QUAL.ReadOnly = true;
				TOTAL_SCORING.ReadOnly = true;
				KLASIFIKASI.ReadOnly = true;

				for (int i=0;i<DGR_QUAN.Items.Count;i++)
				{
					DGR_QUAN.Items[i].Cells[4].Enabled = false;
				}
				for (int i=0;i<DGR_QUAL.Items.Count;i++)
				{
					DGR_QUAL.Items[i].Cells[3].Enabled = false;
				}
				for (int i=0;i<DGR_CLA.Items.Count;i++)
				{
					DGR_CLA.Items[i].Cells[3].Enabled = false;
				}
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
