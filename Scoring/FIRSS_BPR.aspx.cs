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
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.Scoring
{
	/// <summary>
	/// Summary description for FIRSS_BRP.
	/// </summary>
	public partial class FIRSS_BPR : System.Web.UI.Page
	{

		protected Tools tool = new Tools();
		protected Connection conn;
		string APREGNO, CUREF, MC, TC, SCR, PAR;


		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			APREGNO = Request.QueryString["regno"];
			CUREF = Request.QueryString["curef"];
			MC = Request.QueryString["mc"];
			TC = Request.QueryString["tc"];
			SCR = Request.QueryString["scr"];
			PAR = Request.QueryString["par"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), MC, conn))
				Response.Redirect("/SME/Restricted.aspx");
			if (!IsPostBack)
			{
				GlobalTools.initDateForm(this.txt_SB_TGLAPP_dd,this.ddl_SB_TGLAPP_mm,this.txt_SB_TGLAPP_yy);
				GlobalTools.initDateForm(this.txt_SB_POSISI_dd,this.ddl_SB_POSISI_mm,this.txt_SB_POSISI_yy);
				ViewData();

			}
			Hitung();
			ViewMenu();
			SecureData();

			btn_Save.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			this.btn_UpdateStatus.Attributes.Add("onclick", "if(!update()) { return false; };");
		}

		private void SecureData() 
		{
			string scr = Request.QueryString["scr"];

			if (scr == "0")
			{
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				int ii = 0;
				for (ii = 0; ii < coll.Count; ii++) 
				{
					if (coll[ii] is System.Web.UI.HtmlControls.HtmlForm) 
					{
						break;
					}
				}
				if (ii == coll.Count) return;

				for (int i = 0; i < coll[ii].Controls.Count; i++) 
				{
					if (coll[ii].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[ii].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[ii].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[ii].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[ii].Controls[i] is Button)
					{
						Button btn = (Button) coll[ii].Controls[i];
						btn.Visible = false;
					}
					else if (coll[ii].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[ii].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[ii].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[ii].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[ii].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[ii].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[ii].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[ii].Controls[i];

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

		private string backLinkLocal(string mc) 
		{
			try 
			{
				conn.QueryString = "select TM_LINKNAME + TM_PARSINGPARAM as BACKLINK from track_menu where menucode = '" + mc + "'";
				conn.ExecuteQuery(); 

				return conn.GetFieldValue("BACKLINK");
			}
			catch (NullReferenceException e) {
				GlobalTools.popMessage(this, "Server Error!");				
				return "Login.aspx?expire=1";
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


		private void ViewMenu() 
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '" + MC + "'";
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
							strtemp = "regno=" + APREGNO + "&curef="+ CUREF +"&tc="+ TC;
						else
							strtemp = "regno=" + APREGNO + "&curef="+ CUREF +"&mc="+ MC +"&tc="+ TC;

						if (conn.GetFieldValue(i,3).IndexOf("?scr=") < 0 && conn.GetFieldValue(i,3).IndexOf("&scr=") < 0) 
							strtemp += "&"+ SCR;

						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0) 
							strtemp += "&"+ PAR;
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
				Console.Write(ex.Message);
			}
		}


		private void ViewData()
		{
			conn.QueryString	= "select * from VW_SCORING_BPR_HEADER where AP_REGNO = '"+ APREGNO+"'";
			conn.ExecuteQuery();

			try
			{
				this.txt_SB_NMMOHON.Text = conn.GetFieldValue("nama");
				this.txt_SB_ALAMAT.Text = conn.GetFieldValue("addr");;
				this.txt_SB_KOTA.Text = conn.GetFieldValue("cityname");
				this.txt_SB_KDPOS.Text = conn.GetFieldValue("zipcode");
				this.txt_SB_TELP.Text = conn.GetFieldValue("phnarea").Trim() + " " +conn.GetFieldValue("phnnum").Trim();
				this.txt_SB_BIDUSAHA.Text = conn.GetFieldValue("busstypedesc");
				try {Tools.fromSQLDate(conn.GetFieldValue("ap_signdate"), this.txt_SB_TGLAPP_dd, this.ddl_SB_TGLAPP_mm, this.txt_SB_TGLAPP_yy);}
				catch {}
				this.txt_SB_AANO.Text = conn.GetFieldValue("ap_regno");
				this.txt_SB_REFNO.Text = conn.GetFieldValue("cu_ref");
				this.txt_SB_CABANG.Text = conn.GetFieldValue("branch_name");
				this.txt_SB_TEAMLEAD.Text = conn.GetFieldValue("ap_teamleader");
				this.txt_SB_RELMNGR.Text = conn.GetFieldValue("su_fullname");
				this.txt_SB_NMANALIS.Text = conn.GetFieldValue("analyst");
				this.txt_SB_BINISUNIT.Text = conn.GetFieldValue("bussunitdesc");
			}
			catch {}

			this.conn.QueryString = "select * from VW_SCORING_BPR where AP_REGNO ='" + APREGNO + "' and CU_REF = '" + CUREF + "'";
			this.conn.ExecuteQuery();

			try
			{
				this.ddl_SB_POLCON.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_POLCON"));
			

				this.ddl_SB_ECONCON.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_ECONCON"));
				
				this.ddl_SB_LEGALFRM.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_LEGALFRM"));
				this.ddl_SB_PERFRA.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_PERFRA"));
				this.ddl_SB_ACCMONEY.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_ACCMONEY"));

				//--------------------------------------------------------------------------------
				this.ddl_SB_AUDITREP.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_AUDITREP"));
				this.ddl_SB_AUDITOPI.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_AUDITOPI"));

				this.ddl_SB_ROE.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_ROE"));
				this.ddl_SB_NETINT.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_NETINT"));

				this.ddl_SB_OPREX.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_OPREX"));

				this.ddl_SB_NETWORTH.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_NETWORTH"));
				this.ddl_SB_QLTYASSET.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_QLTYASSET"));
				this.ddl_SB_RECPROFIT.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_RECPROFIT"));
				this.ddl_SB_PERFOUTLOOK.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_PERFOUTLOOK"));

				//--------------------------------------------------------------------------------
				this.ddl_SB_BUSSPLCY.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_BUSSPLCY"));
				this.ddl_SB_RISKMAN.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_RISKMAN"));
				this.ddl_SB_QLTYMAN.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_QLTYMAN"));
				this.ddl_SB_QLTYBANK.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_QLTYBANK"));

				//--------------------------------------------------------------------------------
                this.ddl_SB_MARKET.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_MARKET"));
				this.ddl_SB_SEHAT.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_SEHAT"));
				try {Tools.fromSQLDate(conn.GetFieldValue("SB_POSISI"), this.txt_SB_POSISI_dd, this.ddl_SB_POSISI_mm, this.txt_SB_POSISI_yy);}
				catch {}
				this.txt_SB_NILAI.Text = conn.GetFieldValue("SB_NILAI");

				//--------------------------------------------------------------------------------
				this.ddl_SB_PROFIT.SelectedIndex = Convert.ToByte(conn.GetFieldValue("SB_PROFIT"));
				

				//================================================================================
				this.txt_SB_POLCON.Text = this.ddl_SB_POLCON.SelectedValue;
				this.txt_SB_ECONCON.Text = this.ddl_SB_ECONCON.SelectedValue;

				this.txt_SB_LEGALFRM.Text = this.ddl_SB_LEGALFRM.SelectedValue;
				this.txt_SB_PERFRA.Text = this.ddl_SB_PERFRA.SelectedValue;
				this.txt_SB_ACCMONEY.Text = this.ddl_SB_ACCMONEY.SelectedValue;	

				//-------------------------------------------------------------
				this.txt_SB_AUDITREP.Text = this.ddl_SB_AUDITREP.SelectedValue;
				this.txt_SB_AUDITOPI.Text = this.ddl_SB_AUDITOPI.SelectedValue;
		
				this.txt_SB_ROE.Text = this.ddl_SB_ROE.SelectedValue;
				this.txt_SB_NETINT.Text = this.ddl_SB_NETINT.SelectedValue;

				this.txt_SB_OPREX.Text = ddl_SB_OPREX.SelectedValue;

				this.txt_SB_NETWORTH.Text = this.ddl_SB_NETWORTH.SelectedValue;
				this.txt_SB_QLTYASSET.Text = this.ddl_SB_QLTYASSET.SelectedValue;
				this.txt_SB_RECPROFIT.Text = this.ddl_SB_RECPROFIT.SelectedValue;
				this.txt_SB_PERFOUTLOOK.Text = this.ddl_SB_PERFOUTLOOK.SelectedValue;

				//-------------------------------------------------------------
				this.txt_SB_BUSSPLCY.Text = this.ddl_SB_BUSSPLCY.SelectedValue;
				this.txt_SB_RISKMAN.Text = this.ddl_SB_RISKMAN.SelectedValue;
				this.txt_SB_QLTYMAN.Text = this.ddl_SB_QLTYMAN.SelectedValue;
				this.txt_SB_QLTYBANK.Text = this.ddl_SB_QLTYBANK.SelectedValue;

				this.txt_SB_MARKET.Text = this.ddl_SB_MARKET.SelectedValue;
				this.txt_SB_SEHAT.Text = this.ddl_SB_SEHAT.SelectedValue;
				this.txt_SB_PROFIT.Text = this.ddl_SB_PROFIT.SelectedValue;
			}
			catch {}
		}


		protected void btn_Save_Click(object sender, System.EventArgs e)
		{
			Hitung();
			string tgl = GlobalTools.ToSQLDate("1", this.ddl_SB_POSISI_mm.SelectedValue.ToString(), this.txt_SB_POSISI_yy.Text);
			conn.QueryString = "EXEC SP_SCORING_BPR 'Save','" + APREGNO + "','" + CUREF + "'," +
				this.ddl_SB_POLCON.SelectedIndex + "," +
				this.ddl_SB_ECONCON.SelectedIndex + "," +
				this.ddl_SB_LEGALFRM.SelectedIndex + "," +
				this.ddl_SB_PERFRA.SelectedIndex + "," +
				this.ddl_SB_ACCMONEY.SelectedIndex + "," +
				this.ddl_SB_AUDITREP.SelectedIndex + "," +
				this.ddl_SB_AUDITOPI.SelectedIndex + "," +
				this.ddl_SB_ROE.SelectedIndex + "," +
				this.ddl_SB_NETINT.SelectedIndex + "," +
				this.ddl_SB_OPREX.SelectedIndex + "," +
				this.ddl_SB_NETWORTH.SelectedIndex + "," +
				this.ddl_SB_QLTYASSET.SelectedIndex + "," +
				this.ddl_SB_RECPROFIT.SelectedIndex + "," +
				this.ddl_SB_PERFOUTLOOK.SelectedIndex + "," +
				this.ddl_SB_BUSSPLCY.SelectedIndex + "," +
				this.ddl_SB_RISKMAN.SelectedIndex + "," +
				this.ddl_SB_QLTYMAN.SelectedIndex + "," +
				this.ddl_SB_QLTYBANK.SelectedIndex + "," +
				this.ddl_SB_MARKET.SelectedIndex + "," +
				this.ddl_SB_SEHAT.SelectedIndex + "," +
				GlobalTools.ToSQLDate("1", this.ddl_SB_POSISI_mm.SelectedValue.ToString(), this.txt_SB_POSISI_yy.Text) + "," +
				tool.ConvertFloat(this.txt_SB_NILAI.Text) + "," +
				this.ddl_SB_PROFIT.SelectedIndex+ ",'1'," +
				this.txt_FIRating.Text + ",'" +
				this.txt_MandiriRating.Text + "'";
			try
			{
				conn.ExecuteNonQuery();
			}
			catch
			{
				Response.Write("<script language='javascript'>alert('Ada masalah waktu penyimpanan');</script>");
			}
		}

		protected void btn_UpdateStatus_Click(object sender, System.EventArgs e)
		{
			if (CekSimpan())
			{
				Hitung();
				conn.QueryString = "EXEC SP_SCORING_BPR 'Save','" + APREGNO + "','" + CUREF + "'," +
					this.ddl_SB_POLCON.SelectedIndex + "," +
					this.ddl_SB_ECONCON.SelectedIndex + "," +
					this.ddl_SB_LEGALFRM.SelectedIndex + "," +
					this.ddl_SB_PERFRA.SelectedIndex + "," +
					this.ddl_SB_ACCMONEY.SelectedIndex + "," +
					this.ddl_SB_AUDITREP.SelectedIndex + "," +
					this.ddl_SB_AUDITOPI.SelectedIndex + "," +
					this.ddl_SB_ROE.SelectedIndex + "," +
					this.ddl_SB_NETINT.SelectedIndex + "," +
					this.ddl_SB_OPREX.SelectedIndex + "," +
					this.ddl_SB_NETWORTH.SelectedIndex + "," +
					this.ddl_SB_QLTYASSET.SelectedIndex + "," +
					this.ddl_SB_RECPROFIT.SelectedIndex + "," +
					this.ddl_SB_PERFOUTLOOK.SelectedIndex + "," +
					this.ddl_SB_BUSSPLCY.SelectedIndex + "," +
					this.ddl_SB_RISKMAN.SelectedIndex + "," +
					this.ddl_SB_QLTYMAN.SelectedIndex + "," +
					this.ddl_SB_QLTYBANK.SelectedIndex + "," +
					this.ddl_SB_MARKET.SelectedIndex + "," +
					this.ddl_SB_SEHAT.SelectedIndex + "," +
					GlobalTools.ToSQLDate(this.txt_SB_POSISI_dd.Text, this.ddl_SB_POSISI_mm.SelectedValue, this.txt_SB_POSISI_yy.Text) + "," +
					tool.ConvertFloat(this.txt_SB_NILAI.Text) + "," +
					this.ddl_SB_PROFIT.SelectedIndex+ ",'1'," +
					this.txt_FIRating.Text + ",'" +
					this.txt_MandiriRating.Text + "'";
				try
				{
					conn.ExecuteNonQuery();
				}
				catch
				{
					Response.Write("<script language='javascript'>alert('Ada masalah waktu penyimpanan');</script>");
				}

				//---------------------------------------------------------------------- Update Status
				DataTable dt;
				conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + Request.QueryString["regno"] +
					"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
				conn.ExecuteQuery();
				dt = conn.GetDataTable().Copy();
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					conn.QueryString = "exec TRACKUPDATE '" + Request.QueryString["regno"] + "', '" +
						dt.Rows[i][1].ToString() + "', '" + dt.Rows[i][0].ToString() + "', '" + Session["UserID"].ToString() + "', '" + dt.Rows[i]["PROD_SEQ"].ToString() + "','"+Request.QueryString["tc"].Trim()+"'";
					conn.ExecuteNonQuery();
				}
				string msg = getNextStepMsg(Request.QueryString["regno"]);
				Response.Redirect("ListScoring.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);

			}
		}

		private string getNextStepMsg(string regno) 
		{
			string pesan = "";
			string nextTrack = "";
			try 
			{
				/***
				 * Memunculkan pesan next step
				 ***/
				conn.QueryString = "exec TRACKNEXTMSG '" + regno + "'";
				conn.ExecuteQuery();
				nextTrack = conn.GetFieldValue("TRACKNAME");
				pesan = "Application proceeds to " + nextTrack;
				/***********************************/
			} 
			catch 
			{
				throw new Exception();
			}
			return pesan;
		}

		private bool CekSimpan()
		{
			if (ddl_SB_POLCON.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Political Conditions harus dipilih');</script>");
				return false;
			}
			else if (ddl_SB_ECONCON.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Economic Conditions harus dipilih');</script>");
				return false;
			}
			else if (ddl_SB_LEGALFRM.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Legal Framework harus dipilih');</script>");
				return false;
			}
			else if (ddl_SB_PERFRA.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Performance of Regulatory... harus dipilih');</script>");
				return false;
			}
			else if (ddl_SB_ACCMONEY.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Access to Money harus dipilih');</script>");
				return false;
			}
			else if (ddl_SB_AUDITREP.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Auditor Reputation harus dipilih');</script>");
				return false;
			}
			else if (ddl_SB_AUDITOPI.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Auditor Opinion harus dipilih');</script>");
				return false;
			}
			else if (ddl_SB_ROE.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Return on Equity harus dipilih');</script>");
				return false;
			}
			else if (ddl_SB_NETINT.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Net Interest Income... harus dipilih');</script>");
				return false;
			}
			else if (ddl_SB_OPREX.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Operating Expenses... harus dipilih');</script>");
				return false;
			}
			else if (ddl_SB_NETWORTH.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Net Worth... harus dipilih');</script>");
				return false;
			}
			else if (ddl_SB_QLTYASSET.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Quality of Assets harus dipilih');</script>");
				return false;
			}
			else if (ddl_SB_RECPROFIT.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Recent Profitability Trend... harus dipilih');</script>");
				return false;
			}
			else if (ddl_SB_PERFOUTLOOK.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Performance Outlook harus dipilih');</script>");
				return false;
			}
			else if (ddl_SB_BUSSPLCY.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Business Policy... harus dipilih');</script>");
				return false;
			}
			else if (ddl_SB_RISKMAN.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Risk Management... harus dipilih');</script>");
				return false;
			}
			else if (ddl_SB_QLTYMAN.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('RQuality of Management harus dipilih');</script>");
				return false;
			}
			else if (ddl_SB_QLTYBANK.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Quality of Bank Services... harus dipilih');</script>");
				return false;
			}
			else if (ddl_SB_MARKET.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Market Standing harus dipilih');</script>");
				return false;
			}
			else if (ddl_SB_SEHAT.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Penilaian Kesehatan... harus dipilih');</script>");
				return false;
			}
			else if (txt_SB_NILAI.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Nilai Kesehatan harus diisi');</script>");
				return false;
			}
			else if (ddl_SB_PROFIT.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Probability... harus dipilih');</script>");
				return false;
			}

			return true;
		}


		private void Hitung()
		{
			string BIRating;
			int FIRating = 0;

			this.txt_SB_POLCON.Text = this.ddl_SB_POLCON.SelectedValue;
			this.txt_SB_ECONCON.Text = this.ddl_SB_ECONCON.SelectedValue;
			this.txt_SB_LEGALFRM.Text = this.ddl_SB_LEGALFRM.SelectedValue;
			this.txt_SB_PERFRA.Text = this.ddl_SB_PERFRA.SelectedValue;
			this.txt_SB_ACCMONEY.Text = this.ddl_SB_ACCMONEY.SelectedValue;
			this.txt_SB_AUDITREP.Text = this.ddl_SB_AUDITREP.SelectedValue;
			this.txt_SB_AUDITOPI.Text = this.ddl_SB_AUDITOPI.SelectedValue;
			this.txt_SB_ROE.Text = this.ddl_SB_ROE.SelectedValue;
			this.txt_SB_NETINT.Text = this.ddl_SB_NETINT.SelectedValue;
			this.txt_SB_OPREX.Text = ddl_SB_OPREX.SelectedValue;
			this.txt_SB_NETWORTH.Text = this.ddl_SB_NETWORTH.SelectedValue;
			this.txt_SB_QLTYASSET.Text = this.ddl_SB_QLTYASSET.SelectedValue;
			this.txt_SB_RECPROFIT.Text = this.ddl_SB_RECPROFIT.SelectedValue;
			this.txt_SB_PERFOUTLOOK.Text = this.ddl_SB_PERFOUTLOOK.SelectedValue;
			this.txt_SB_BUSSPLCY.Text = this.ddl_SB_BUSSPLCY.SelectedValue;
			this.txt_SB_RISKMAN.Text = this.ddl_SB_RISKMAN.SelectedValue;
			this.txt_SB_QLTYMAN.Text = this.ddl_SB_QLTYMAN.SelectedValue;
			this.txt_SB_QLTYBANK.Text = this.ddl_SB_QLTYBANK.SelectedValue;
			this.txt_SB_MARKET.Text = this.ddl_SB_MARKET.SelectedValue;
			this.txt_SB_SEHAT.Text = this.ddl_SB_SEHAT.SelectedValue;
			this.txt_SB_PROFIT.Text = this.ddl_SB_PROFIT.SelectedValue;

			try
			{
				FIRating = Convert.ToInt32(this.txt_SB_POLCON.Text) + 
					Convert.ToInt32(this.txt_SB_ECONCON.Text) + 
					Convert.ToInt32(this.txt_SB_LEGALFRM.Text) +
					Convert.ToInt32(this.txt_SB_PERFRA.Text) +
					Convert.ToInt32(this.txt_SB_ACCMONEY.Text) +
				
					Convert.ToInt32(this.txt_SB_AUDITREP.Text) + 
					Convert.ToInt32(this.txt_SB_AUDITOPI.Text) + 
					Convert.ToInt32(this.txt_SB_ROE.Text) +
					Convert.ToInt32(this.txt_SB_NETINT.Text) +
					Convert.ToInt32(this.txt_SB_OPREX.Text) + 
					Convert.ToInt32(this.txt_SB_NETWORTH.Text) + 
					Convert.ToInt32(this.txt_SB_QLTYASSET.Text) +
					Convert.ToInt32(this.txt_SB_RECPROFIT.Text) +
					Convert.ToInt32(this.txt_SB_PERFOUTLOOK.Text) +

					Convert.ToInt32(this.txt_SB_BUSSPLCY.Text) +
					Convert.ToInt32(this.txt_SB_RISKMAN.Text) +
					Convert.ToInt32(this.txt_SB_QLTYMAN.Text) +
					Convert.ToInt32(this.txt_SB_QLTYBANK.Text) +

					Convert.ToInt32(this.txt_SB_MARKET.Text) +
					Convert.ToInt32(this.txt_SB_SEHAT.Text) +
					Convert.ToInt32(this.txt_SB_PROFIT.Text);
			}
			catch {}

			if (FIRating < 73)
				BIRating = "Ia";
			else if (FIRating < 85)
				BIRating = "Ib";
			else if (FIRating < 105)
				BIRating = "Ic";
			else if (FIRating < 112)
				BIRating = "II";
			else if (FIRating < 130)
				BIRating = "III";
			else if (FIRating < 211)
				BIRating = "IV";
			else
				BIRating = "V";

			this.txt_FIRating.Text = Convert.ToString(FIRating);
			this.txt_MandiriRating.Text = BIRating;
		}


		protected void btn_Calculate_Click(object sender, System.EventArgs e)
		{
			if (CekSimpan())
				Hitung();
			
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["tc"] != null && Request.QueryString["tc"] != "") 
			{
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn));
			} 
			else if (Request.QueryString["mc"] != null && Request.QueryString["mc"] != "")
			{
				Response.Redirect("/SME/" + backLinkLocal(Request.QueryString["mc"]));
			}
			else 
			{
				//	do nothing !!!
			}
		}
	}
}
