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

namespace SME.Facilities
{
	/// <summary>
	/// Summary description for RejectApplication.
	/// </summary>
	public partial class RejectApplication : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

            if (Session["RejectCancelMC"] == null)
            {
                Session["RejectCancelMC"] = Request.QueryString["mc"];
            }

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Session["RejectCancelMC"].ToString(), conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				string ap_regno	= Request.QueryString["ap_regno"].ToString();
				string nama		= Request.QueryString["nama"].ToString();
				string cust		= Request.QueryString["cust"].ToString();
				string tgl		= Request.QueryString["tgl"].ToString();
				string bln		= Request.QueryString["bln"].ToString();
				string thn		= Request.QueryString["thn"].ToString();
				string noID		= Request.QueryString["noID"].ToString();
				string area		= Request.QueryString["area"].ToString();
				string cabang	= Request.QueryString["cabang"].ToString();
				string tampil	= Request.QueryString["tampil"].ToString();

				conn.QueryString = "select in_branchpusat from rfinitial";
				conn.ExecuteQuery();
				Label1.Text = conn.GetFieldValue("in_branchpusat");

				fillMonth();

				fillArea();

				fillReason();

				setCriteria(ap_regno, nama, cust, tgl, bln, thn, noID, area, cabang);

				if (tampil.Trim()!="")
				{
					viewByProduct(tampil);
				}
			}
			else
			{
					if (TXT_TAMPIL.Text=="true")
						ViewGrid();
					if (TXT_TAMPIL1.Text=="true")
					{
						string ap_link	= Request.QueryString["ap_link"].ToString();		
						oTable1.Visible		= Status(TXT_TAMPIL1.Text);
						if (Status(TXT_TAMPIL1.Text))
							ViewGrid1(ap_link);
					}
			}
			Button2.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			Button2.Attributes.Add("onclick","if(!ConfirmBox('Are you sure want to Reject or Cancel this application ?')){return false;};");
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

		private void fillMonth() 
		{
			DDL_MONTH.Items.Add(new ListItem("-- Select --",""));
			for (int i = 1; i <= 12; i++)
			{
				DDL_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}
		}

		private void fillArea() 
		{
			conn.QueryString = "select areaid, areaname from rfarea";
			conn.ExecuteQuery();
			DDL_AREA.Items.Add(new ListItem("-- Select --",""));
			for (int i = 0 ; i < conn.GetRowCount();i++)
			{
				DDL_AREA.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
			conn.ClearData();
		}

		private void fillReason() 
		{
			DDL_BRANCH.Items.Add(new ListItem("-- Select --",""));

			conn.QueryString = "select reasonid, reasondesc from RFREASON where reasontype ='0' and active = '1'";
			conn.ExecuteQuery();
			DDL_REJECT.Items.Add(new ListItem("-- Select --",""));
			for (int i = 0 ; i < conn.GetRowCount();i++)
			{
				DDL_REJECT.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
			conn.ClearData();			
		}

		private void viewByProduct(string tampil) 
		{
			TXT_TAMPIL1.Text	= tampil;
			TXT_TAMPIL.Text		= "true";
			ViewGrid();
			string ap_link	= Request.QueryString["ap_link"].ToString();		
			oTable1.Visible		= Status(TXT_TAMPIL1.Text);
			if (Status(tampil))
				ViewGrid1(ap_link);
		}

		private void setCriteria(string ap_regno, string nama, string cust, string tgl, string bln, string thn, string noID, string area, string cabang) 
		{
			TXT_APPNO.Text	= ap_regno;
			TXT_NAME.Text	= nama;
			if (cust=="0")
				RB_COMPANY.Checked	= true;
			else
				RB_PERSONAL.Checked	= true;
			TXT_DATE.Text	= tgl;
			if (bln.Trim()!="")
				DDL_MONTH.SelectedValue	= bln;
			TXT_YEAR.Text	= thn;
			TXT_IDNUMBER.Text	= noID;
			if (area.Trim()!="")
				DDL_AREA.SelectedValue	= area;
			if (cabang.Trim()!="")
				DDL_BRANCH.SelectedValue	= cabang;

		}

		private bool Status(string tampil)
		{
			if (tampil=="true")
				return true;
			else
				return false;
		}

		private void ViewGrid()
		{
			bool sta	= false;
			if (oTable1.Visible==false)
				sta=true;
			string ap_regno	= TXT_APPNO.Text;
			string nama		= TXT_NAME.Text;
			string tgl		= TXT_DATE.Text;
			string thn		= TXT_YEAR.Text;
			string noID		= TXT_IDNUMBER.Text;
			string bln		= DDL_MONTH.SelectedValue;
			string area		= DDL_AREA.SelectedValue;
			string cabang	= DDL_BRANCH.SelectedValue;
			int cust;
			if (RB_PERSONAL.Checked==true)
				cust	= 1;
			else
				cust	= 0;
			string link			= "ap_regno="+ap_regno+"&nama="+nama+"&cust="+cust.ToString()+"&tgl="+tgl+"&bln="+bln+"&thn="+thn+"&noID="+noID+"&area="+area+"&cabang="+cabang;
			conn.QueryString	= Query(ap_regno,nama,cust,tools.ConvertDate(tgl,bln,thn),noID,area,cabang);
			try 
			{
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}
			
			int j	= 0;
			int tblRowCount = oTable.Rows.Count;
			for (int i = tblRowCount - 1; i >= 1; i--)
				oTable.Rows.Remove(oTable.Rows[i]);
			for (int i = 0; j < conn.GetRowCount(); i++) 
			{
				oTable.Rows.Add(new TableRow());
				oTable.Rows[i+1].Cells.Add(new TableCell());
				oTable.Rows[i+1].Cells[0].Text = conn.GetFieldValue(j, "AP_REGNO");
				oTable.Rows[i+1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				oTable.Rows[i+1].CssClass		= tools.ChangeListColor(j);
				
				oTable.Rows[i+1].Cells.Add(new TableCell());
				oTable.Rows[i+1].Cells[1].Text = conn.GetFieldValue(j, "cu_ref");
				oTable.Rows[i+1].Cells[1].HorizontalAlign = HorizontalAlign.Center;

				oTable.Rows[i+1].Cells.Add(new TableCell());
				oTable.Rows[i+1].Cells[2].Text = conn.GetFieldValue(j, "NAMA");
				oTable.Rows[i+1].Cells[2].HorizontalAlign = HorizontalAlign.Center;
				
				oTable.Rows[i+1].Cells.Add(new TableCell());
				oTable.Rows[i+1].Cells[3].Text = conn.GetFieldValue(j, "NAMARM");
				oTable.Rows[i+1].Cells[3].HorizontalAlign = HorizontalAlign.Center;

				oTable.Rows[i+1].Cells.Add(new TableCell());
				oTable.Rows[i+1].Cells[4].Text = tools.FormatDate(conn.GetFieldValue(j, "AP_RECVDATE"), true);
				oTable.Rows[i+1].Cells[4].HorizontalAlign = HorizontalAlign.Center;
				
				//if (conn.GetFieldValue(j, "TRACK")=="1.1")
				if (conn.GetFieldValue(j, "TRACK")=="3.6")
				{
					HyperLink t		= new HyperLink();
					t.Text			= "view";
                    t.NavigateUrl = "RejectApplication.aspx?tampil=true&ap_link=" + conn.GetFieldValue(j, "AP_REGNO") + "&" + link + "&mc=" + Session["RejectCancelMC"];
					oTable.Rows[i+1].Cells.Add(new TableCell());
					oTable.Rows[i+1].Cells[5].HorizontalAlign = HorizontalAlign.Center;
					oTable.Rows[i+1].Cells[5].Controls.Add(t);
				}
				else
				{
					CheckBox t = new CheckBox();
					t.ID = "check"+conn.GetFieldValue(j, "AP_REGNO");
					t.Visible	= sta;
					oTable.Rows[i+1].Cells.Add(new TableCell());
					oTable.Rows[i+1].Cells[5].HorizontalAlign = HorizontalAlign.Center;
					oTable.Rows[i+1].Cells[5].Controls.Add(t);
				}
				i++;
				oTable.Rows.Add(new TableRow());
				for (int y = 0; y < 6; y++) 
				{
					oTable.Rows[i+1].Cells.Add(new TableCell());
					oTable.Rows[i+1].Cells[y].Height	= 1;
				}
				oTable.Rows[i+1].CssClass		= "garis";
				j++;
			}
		}
		
		private void ViewGrid1(string ap_link)
		{
			LBL_APREGNO.Text	= ap_link;
			LBL_APREGNO.Visible	= true;
			LBL_TEKS.Visible	= true;
			conn.QueryString = "select productid, productdesc from vw_app_cust_company_rmp where ap_regno='"+ap_link+"'";
			conn.ExecuteQuery();
			int j = 1;
			for (int i = 0; j-1 < conn.GetRowCount(); i++) 
			{
				oTable1.Rows.Add(new TableRow());
				oTable1.Rows[i+1].Cells.Add(new TableCell());
				oTable1.Rows[i+1].Cells[0].Text				= j.ToString();
				oTable1.Rows[i+1].Cells[0].HorizontalAlign	= HorizontalAlign.Center;
				oTable1.Rows[i+1].CssClass					= tools.ChangeListColor(j);
				
				oTable1.Rows[i+1].Cells.Add(new TableCell());
				oTable1.Rows[i+1].Cells[1].Text				= conn.GetFieldValue(j-1, "productid");
				oTable1.Rows[i+1].Cells[1].HorizontalAlign	= HorizontalAlign.Center;

				oTable1.Rows[i+1].Cells.Add(new TableCell());
				oTable1.Rows[i+1].Cells[2].Text				= conn.GetFieldValue(j-1, "productdesc");
				oTable1.Rows[i+1].Cells[2].HorizontalAlign	= HorizontalAlign.Center;
				
				CheckBox t = new CheckBox();
				t.ID	=  "check"+conn.GetFieldValue(j-1, "productid");
				oTable1.Rows[i+1].Cells.Add(new TableCell());
				oTable1.Rows[i+1].Cells[3].HorizontalAlign	= HorizontalAlign.Center;
				oTable1.Rows[i+1].Cells[3].Controls.Add(t);
				
				i++;
				oTable1.Rows.Add(new TableRow());
				for (int y = 0; y < 4; y++) 
				{
					oTable1.Rows[i+1].Cells.Add(new TableCell());
					oTable1.Rows[i+1].Cells[y].Height	= 1;
				}
				oTable1.Rows[i+1].CssClass		= "garis";
				j++;
			}
			TXT_JML.Text	= j.ToString();
		}

		protected void DDL_AREA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DDL_BRANCH.Items.Clear();
			DDL_BRANCH.Items.Add(new ListItem("-- Select --",""));
			if(!DDL_AREA.SelectedValue.Equals(""))
			{
				conn.QueryString = "select Branch_Name,Branch_Code from VW_BRANCH where AreaId = '"+ DDL_AREA.SelectedValue +"' ";
				conn.ExecuteQuery();
				for (int i = 0; i<conn.GetRowCount(); i++)
				{
					DDL_BRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,0),conn.GetFieldValue(i,1)));
				}
				conn.ClearData();
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
            Response.Redirect("RejectApplication.aspx?ap_regno=&nama=&cust=&tgl=&bln=&thn=&noID=&area=&cabang=&tampil=&ap_link=&mc=" + Session["RejectCancelMC"]);
		}

		string Query(string ap_regno,string name,int cust_type,string ap_recvdate,string cu_idcardnum,string areaid,string branchcode)
		{
			/*****
			string where="";
			if (!ap_regno.Equals(""))	where = " and AP_REGNO like '%"+ ap_regno +"%'";
			if (!name.Equals(""))		where = where +" and ltrim(rtrim(Nama)) like  '%"+ name +"%'";

			if (ap_recvdate != "null")	where = where +" and ap_recvdate = "+ap_recvdate+"";	
			if (!areaid.Equals(""))		where = where +" and areaid = '"+ areaid +"'";
			if (!branchcode.Equals(""))	where = where +" and branch_code = '"+ branchcode +"'";
			if (cust_type == 1)
			{
				if (!cu_idcardnum.Equals(""))
					where = where +" and cu_idcardnum = '"+ cu_idcardnum +"'";
				return "select ap_regno, cu_ref, nama, namarm, AP_RECVDATE, track from vw_app_cust_personal_rm where 1=1 "+ where +"";
			}
			else
				return "select ap_regno, cu_ref, nama, namarm, AP_RECVDATE, track from vw_app_cust_company_rm where 1=1 "+ where +"";
			*/

			
			string where=" where 1 = 1 ";
			if (!ap_regno.Equals(""))
				where += " and ap_regno = '"+ ap_regno +"'";
			if (!name.Equals(""))
				where += " and ltrim(rtrim(Nama)) like  '%"+ name +"%'";

			if (ap_recvdate != "null")
				where += " and convert(varchar, ap_recvdate, 112) = convert(varchar, convert(datetime,"+ap_recvdate+"), 112) ";	
			if (!areaid.Equals(""))
				where += " and areaid = '"+ areaid +"'";
			if (!branchcode.Equals(""))
				where += " and branch_code = '"+ branchcode +"'";
			if (cust_type == 1)
				where += " and CU_CUSTTYPEID = '02'";
			else
				where += " and CU_CUSTTYPEID = '01'";

			where = where.Replace("'", "''");
			return "exec REJCAN_GETLISTAPP '" + (string) Session["UserID"] + "', '" + where + "' ";
			/*
			if (cust_type == 1)
			{
				if (!cu_idcardnum.Equals(""))
					where = where +" and cu_idcardnum = '"+ cu_idcardnum +"'";
				if (Label1.Text == Session["BranchID"].ToString())
					return "select ap_regno, cu_ref, nama, namarm, AP_RECVDATE, track from vw_app_cust_personal_rm where 1=1 "+ where +"";
				return "select ap_regno, cu_ref, nama, namarm, AP_RECVDATE, track from vw_app_cust_personal_rm where 1=1 and CBC_CODE='" + Session["CBC"].ToString() + "' "+ where +"";
			}
			else
			{
				if (Label1.Text == Session["BranchID"].ToString())
					return "select ap_regno, cu_ref, nama, namarm, AP_RECVDATE, track from vw_app_cust_company_rm where 1=1 "+ where +"";
				return "select ap_regno, cu_ref, nama, namarm, AP_RECVDATE, track from vw_app_cust_company_rm where 1=1 and CBC_CODE='" + Session["CBC"].ToString() + "' "+ where +"";
			}
			*/
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			if ((TXT_APPNO.Text=="") && (TXT_NAME.Text==""))
			{
				int tblRowCount = oTable.Rows.Count;
				for (int i = tblRowCount - 1; i >= 1; i--)
					oTable.Rows.Remove(oTable.Rows[i]);

				Tools.popMessage(this,"Nomor Aplikasi atau Nama harus diisi !");
				Tools.SetFocus(this,TXT_APPNO);
			}
			else
			{	ViewGrid();
				TXT_TAMPIL.Text		= "true";
				LBL_APREGNO.Visible	= false;
				LBL_TEKS.Visible	= false;
				oTable1.Visible		= false;
			}
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
            Response.Redirect("RejectApplication.aspx?ap_regno=&nama=&cust=&tgl=&bln=&thn=&noID=&area=&cabang=&tampil=&ap_link=&mc=" + Session["RejectCancelMC"]);
		}

		private void Simpan()
		{
			string tipe, oleh;
			int cust;
			//DataTable dt;

			if (RB_PERSONAL.Checked==true)
				cust	= 1;
			else
				cust	= 0;
			if (RB_PROSES.Items[0].Selected)
			{
				oleh	= "0";
				tipe	= "0";
			}
			else
			{
				tipe	= "1";			
				oleh	= "1";
			}


			if (oTable1.Visible==true)		
			{
				conn.QueryString = "select * from ketentuan_kredit where ap_Regno = '" + LBL_APREGNO.Text + "'";
				conn.ExecuteQuery();
				DataTable dtk = conn.GetDataTable().Copy();

				conn.QueryString = "select productid, apptype, prod_seq from vw_app_cust_company_rmp where ap_regno='"+LBL_APREGNO.Text+"'";
				conn.ExecuteQuery();
				bool sta=true;
				
				try 
				{
					/// Loop per product berdasarkan aplikasi defined
					/// 
					for (int i = 0; i<conn.GetRowCount(); i++)
					{
						Tools.popMessage(this,"check"+conn.GetFieldValue(i, "productid").ToString());					
						if (((CheckBox)oTable1.FindControl("check"+conn.GetFieldValue(i, "productid"))).Checked == true )
						{
							conn.QueryString = "exec ENTRY_REJECT_CANCEL "+
								"'"+LBL_APREGNO.Text+"', '"+conn.GetFieldValue(i, "productid")+"', '"+conn.GetFieldValue(i, "apptype")+"', "+
								"'"+tipe+"', '"+DDL_REJECT.SelectedValue+"', '"+oleh+"', '1', '"+tipe+"', '"+ Session["UserID"]+"', '" + 
								conn.GetFieldValue(i, "prod_seq") + "'";
							conn.ExecTrans();

							//conn.ExecuteNonQuery();
						}
						else
							sta = false;
					}

					/// Kalau semua product dalam aplikasi di reject/cancel, 
					/// maka set flag reject/cancel aplikasi tersebut menjadi 1
					/// 
					if (sta)
					{
						/// Reject Aplikasi
						/// 
						if (tipe=="0")
						{
							conn.QueryString = "Update Application set AP_REJECT='1' where ap_regno='"+LBL_APREGNO.Text+"'"; 
							conn.ExecTrans();
							//conn.ExecuteNonQuery();

							/*						
							conn.QueryString = "Update apptrack set ap_currtrack = '3.8' where ap_regno='" + LBL_APREGNO.Text + "'";
							conn.ExecuteNonQuery();

							conn.QueryString = "select apptype, productid from cust_product where ap_regno='" + Request.QueryString["regno"] + "'";
							conn.ExecuteQuery();
							dt = conn.GetDataTable().Copy();
							for (int i = 0; i < dt.Rows.Count; i++)
							{
								conn.QueryString = "exec TRACK_HISTORY_INSERT '" + LBL_APREGNO.Text + "', '" + dt.Rows[i][0].ToString() + "', '" + dt.Rows[i][1].ToString() + "', '3.8', '" + Session["UserID"].ToString() + "'";
								conn.ExecuteNonQuery();
							}
							*/
						}
						else
						{
							/// Cancel Aplikasi
							/// 
							conn.QueryString = "Update Application set AP_CANCEL='1' where ap_regno='"+LBL_APREGNO.Text+"'"; 
							conn.ExecTrans();
							//conn.ExecuteNonQuery();

							//////////////////////////////////////////////////////////////////
							/// For the sake of safety, check first whether it needs
							/// earmarking or not
							/// 						
							for(int i=0; i<dtk.Rows.Count; i++) 
							{
								conn.QueryString = "exec EARMARK_CEK '" + 
									LBL_APREGNO.Text + "', '" + 
									dtk.Rows[i]["ket_code"].ToString() + "'";
								conn.ExecuteQuery();
								if (conn.GetFieldValue("NEED_EARMARK") == "1") 
								{
									/// Reverse Earmark
									/// 
									Earmarking.Earmarking.reverseEarmark(LBL_APREGNO.Text, dtk.Rows[i]["ket_code"].ToString(), conn);
								}
							}
							

							/*
							conn.QueryString = "Update apptrack set ap_currtrack = '3.9' where ap_regno='" + LBL_APREGNO.Text + "'";
							conn.ExecuteNonQuery();

							conn.QueryString = "select apptype, productid from cust_product where ap_regno='" + Request.QueryString["regno"] + "'";
							conn.ExecuteQuery();
							dt = conn.GetDataTable().Copy();
							for (int i = 0; i < dt.Rows.Count; i++)
							{
								conn.QueryString = "exec TRACK_HISTORY_INSERT '" + LBL_APREGNO.Text + "', '" + dt.Rows[i][0].ToString() + "', '" + dt.Rows[i][1].ToString() + "', '3.9', '" + Session["UserID"].ToString() + "'";
								conn.ExecuteNonQuery();
							}
							*/
						}


						/// Membuat backup data aplikasi
						/// 
						conn.QueryString = "exec CHECK_BACKUP_DATA '" + LBL_APREGNO.Text + "'";
						conn.ExecTrans();
					}

					conn.ExecTran_Commit();
				} 
				catch 
				{
					conn.ExecTran_Rollback();
					GlobalTools.popMessage(this, "Aplikasi gagal di reject/cancel !");
				}
			}
			else
			{
				conn.QueryString = Query(TXT_APPNO.Text,TXT_NAME.Text,cust,tools.ConvertDate(TXT_DATE.Text,DDL_MONTH.SelectedValue,TXT_YEAR.Text),TXT_IDNUMBER.Text,DDL_AREA.SelectedValue,DDL_BRANCH.SelectedValue);
				conn.ExecuteQuery();

				int countError = 0;
				string pesanError = "Aplikasi yang gagal direject/cancel:\\n";

				for (int i = 0; i<conn.GetRowCount(); i++)
				{
					//if (conn.GetFieldValue(i, "TRACK")!="1.1")
					if (conn.GetFieldValue(i, "TRACK")!= "3.6")
					{
						CheckBox CHK_AP_REGNO = (CheckBox) oTable.FindControl("check" + conn.GetFieldValue(i, "ap_regno"));

						//if ((CheckBox)oTable.FindControl("check" + conn.GetFieldValue(i, "ap_regno")).Checked == true)
						if (CHK_AP_REGNO.Checked == true)
						{
							try 
							{
								/// Men-set flag reject/cancel aplikasi menjadi 1
								/// 
								conn.QueryString = "exec ENTRY_REJECT_CANCEL "+
									"'"+conn.GetFieldValue(i, "ap_regno")+"', '', '', "+
									"'"+tipe+"', '"+DDL_REJECT.SelectedValue+"', '"+oleh+"', '2', '"+tipe+"', '"+ 
									Session["UserID"]+"', ''";
								conn.ExecTrans();
								//conn.ExecuteNonQuery();

								/// Membuat backup data aplikasi
								/// 
								conn.QueryString = "exec CHECK_BACKUP_DATA '" + conn.GetFieldValue(i, "ap_regno") + "'";
								conn.ExecTrans();

								conn.ExecTran_Commit();
							} 
							catch 
							{
								countError++;
								pesanError = pesanError + countError + "-" + conn.GetFieldValue(i, "ap_regno") + "\\n";
								conn.ExecTran_Rollback();
							}
						}
					}
				}					

				if (countError > 0) 
				{
					GlobalTools.popMessage(this, pesanError);
				}
			}

            Response.Redirect("RejectApplication.aspx?ap_regno=&nama=&cust=&tgl=&bln=&thn=&noID=&area=&cabang=&tampil=&ap_link=&mc=" + Session["RejectCancelMC"]);
		}

		protected void RadioButtonList2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string tipe;
			if (RB_PROSES.Items[0].Selected)
			{
				tipe			= "0";
				LBL_PROSES.Text	= "Alasan Ditolak";
			}
			else
			{
				tipe			= "1";
				LBL_PROSES.Text	= "Alasan Dibatalkan";
			}

			DDL_REJECT.Items.Clear();
			conn.QueryString = "select reasonid, reasondesc from RFREASON where reasontype='"+tipe+"' and active = '1'";
			conn.ExecuteQuery();
			DDL_REJECT.Items.Add(new ListItem("-- Select --",""));
			for (int i = 0 ; i < conn.GetRowCount();i++)
			{
				DDL_REJECT.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
			conn.ClearData();			
		}

		protected void Button2_Click(object sender, System.EventArgs e)
		{
			if (DDL_REJECT.SelectedValue.Trim()=="")
			{
				Tools.popMessage(this, LBL_PROSES.Text+" harus diisi !");
				Tools.SetFocus(this,DDL_REJECT);
			}
			else 
			{
				Simpan();

				
				///////////////////////////////////////////////////////////////////////////////////////////
				/// Audit Trail
				/// 
				try
				{
					string cu_ref;

					conn.QueryString = " select cu_ref from application where ap_regno = '" + LBL_APREGNO.Text + "'";
					conn.ExecuteQuery();
					if ( conn.GetRowCount() > 0  ) 
					{
						cu_ref = conn.GetFieldValue("cu_ref");
					}
					else cu_ref = "???";
				
					conn.QueryString = "SP_AUDITTRAIL_APP " + 
						"'"+ LBL_APREGNO.Text +"', null, null, null," + 
						"'"+ cu_ref.ToString() +"', null,' Cancel/Reject Application, Reason: " + DDL_REJECT.SelectedItem.Text + "'," + 
						"null,"  +  
						"'"+ Session["UserID"].ToString() + "','xxxx',null,null,null";
					conn.ExecuteNonQuery();
				}
				catch 	{ 	}
				//////////////////////////////////////////////////////////////////////////////////////////

			}
		}

		protected void RB_PERSONAL_CheckedChanged(object sender, System.EventArgs e)
		{
			TXT_IDNUMBER.Enabled	= true;
		}

		protected void RB_COMPANY_CheckedChanged(object sender, System.EventArgs e)
		{
			TXT_IDNUMBER.Text		= "";
			TXT_IDNUMBER.Enabled	= false;
		}
	}
}
