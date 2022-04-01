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
	/// Summary description for CRSS.
	/// </summary>
	public partial class CRSS : System.Web.UI.Page
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
				GlobalTools.initDateForm(this.txt_SC_TGLAPP_dd,this.ddl_SC_TGLAPP_mm,this.txt_SC_TGLAPP_yy);
				ViewData();

			}

			ViewMenu();
			Hitung();
			SecureData();

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
			catch (NullReferenceException e) 
			{
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
				this.txt_SC_NMMOHON.Text = conn.GetFieldValue("nama");
				this.txt_SC_ALAMAT.Text = conn.GetFieldValue("addr");;
				this.txt_SC_KOTA.Text = conn.GetFieldValue("cityname");
				this.txt_SC_KDPOS.Text = conn.GetFieldValue("zipcode");
				this.txt_SC_TELP.Text = conn.GetFieldValue("phnarea").Trim() + " " +conn.GetFieldValue("phnnum").Trim();
				this.txt_SC_BIDUSAHA.Text = conn.GetFieldValue("busstypedesc");
				try {Tools.fromSQLDate(conn.GetFieldValue("ap_signdate"), this.txt_SC_TGLAPP_dd, this.ddl_SC_TGLAPP_mm, this.txt_SC_TGLAPP_yy);} catch {}
				this.txt_SC_AANO.Text = conn.GetFieldValue("ap_regno");
				this.txt_SC_REFNO.Text = conn.GetFieldValue("cu_ref");
				this.txt_SC_CABANG.Text = conn.GetFieldValue("branch_name");
				this.txt_SC_TEAMLEAD.Text = conn.GetFieldValue("ap_teamleader");
				this.txt_SC_RELMNGR.Text = conn.GetFieldValue("su_fullname");
				this.txt_SC_NMANALIS.Text = conn.GetFieldValue("analyst");
				this.txt_SC_BINISUNIT.Text = conn.GetFieldValue("bussunitdesc");
			}
			catch {}

			this.conn.QueryString = "select * from VW_SCORING_CRSS where AP_REGNO ='" + APREGNO + "' and CU_REF = '" + CUREF + "'";
			this.conn.ExecuteQuery();

			try
			{
				//-------------------------------------------------------------------------
				this.txt_SC_FC_EQUITYRETURN.Text = conn.GetFieldValue("SC_FC_EQUITYRETURN");
				this.txt_SC_FC_TOTCAPITAL.Text = conn.GetFieldValue("SC_FC_TOTCAPITAL");
				this.txt_SC_FC_NETLIABI.Text = conn.GetFieldValue("SC_FC_NETLIABI");
				this.txt_SC_FC_LIQUIDITY.Text = conn.GetFieldValue("SC_FC_LIQUIDITY");
				this.txt_SC_FC_REVENUEDEV.Text = conn.GetFieldValue("SC_FC_REVENUEDEV");
				this.txt_SC_FC_TOTALOUT.Text = conn.GetFieldValue("SC_FC_TOTALOUT");

				//-------------------------------------------------------------------------
				this.txt_SC_LEGALSTAT.Text = conn.GetFieldValue("SC_LEGALSTAT");

				//-------------------------------------------------------------------------
				this.txt_SC_R_PROVINFO.Text = conn.GetFieldValue("SC_R_PROVINFO");
				this.txt_SC_R_CONDACC.Text = conn.GetFieldValue("SC_R_CONDACC");
				this.txt_SC_R_HONAGREE.Text = conn.GetFieldValue("SC_R_HONAGREE");

				//-------------------------------------------------------------------------
				this.txt_SC_MP_PRODQUAL.Text = conn.GetFieldValue("SC_MP_PRODQUAL");
				this.txt_SC_MP_MARKETSTRA.Text = conn.GetFieldValue("SC_MP_MARKETSTRA");
				this.txt_SC_MP_DEMANDSIT.Text = conn.GetFieldValue("SC_MP_DEMANDSIT");
				this.txt_SC_MP_DEPENDENCE.Text = conn.GetFieldValue("SC_MP_DEPENDENCE");
				this.txt_SC_MP_RISKS.Text = conn.GetFieldValue("SC_MP_RISKS");

				//-------------------------------------------------------------------------
				this.txt_SC_M_CAPABILITY.Text = conn.GetFieldValue("SC_M_CAPABILITY");
				this.txt_SC_M_STRAVISI.Text = conn.GetFieldValue("SC_M_STRAVISI");
				this.txt_SC_M_INTCTRL.Text = conn.GetFieldValue("SC_M_INTCTRL");
				this.txt_SC_M_EXTREGAUDIT.Text = conn.GetFieldValue("SC_M_EXTREGAUDIT");
				this.txt_SC_M_SUCCESSION.Text = conn.GetFieldValue("SC_M_SUCCESSION");

				//-------------------------------------------------------------------------
				this.txt_SC_V_NEWCAPITAL.Text = conn.GetFieldValue("SC_V_NEWCAPITAL");
				this.txt_SC_V_SOLVPROB.Text = conn.GetFieldValue("SC_V_SOLVPROB");
				this.txt_SC_V_PRODDEV.Text = conn.GetFieldValue("SC_V_PRODDEV");
				this.txt_SC_V_OPPROBLEM.Text = conn.GetFieldValue("SC_V_OPPROBLEM");
				this.txt_SC_V_MANPROBLEM.Text = conn.GetFieldValue("SC_V_MANPROBLEM");

				//-------------------------------------------------------------------------
				this.txt_SC_D_INTDEV.Text = conn.GetFieldValue("SC_D_INTDEV");
				this.txt_SC_D_INDOUTLOOK.Text = conn.GetFieldValue("SC_D_INDOUTLOOK");
			}
			catch {}
		}

		protected void btn_Save_Click(object sender, System.EventArgs e)
		{
			Hitung();
			conn.QueryString = "EXEC SP_SCORING_CRSS 'Save','" + APREGNO + "','" + CUREF + "'," +
				tool.ConvertNull(this.txt_SC_FC_EQUITYRETURN.Text) + "," +
				tool.ConvertNull(this.txt_SC_FC_TOTCAPITAL.Text) + "," +
				tool.ConvertNull(this.txt_SC_FC_NETLIABI.Text) + "," +
				tool.ConvertNull(this.txt_SC_FC_LIQUIDITY.Text) + "," +
				tool.ConvertNull(this.txt_SC_FC_REVENUEDEV.Text) + "," +
				tool.ConvertNull(this.txt_SC_FC_TOTALOUT.Text) + "," +
				tool.ConvertNull(this.txt_SC_LEGALSTAT.Text) + "," +
				tool.ConvertNull(this.txt_SC_R_PROVINFO.Text) + "," +
				tool.ConvertNull(this.txt_SC_R_CONDACC.Text) + "," +
				tool.ConvertNull(this.txt_SC_R_HONAGREE.Text) + "," +
				tool.ConvertNull(this.txt_SC_MP_PRODQUAL.Text) + "," +
				tool.ConvertNull(this.txt_SC_MP_MARKETSTRA.Text) + "," +
				tool.ConvertNull(this.txt_SC_MP_DEMANDSIT.Text) + "," +
				tool.ConvertNull(this.txt_SC_MP_DEPENDENCE.Text) + "," +
				tool.ConvertNull(this.txt_SC_MP_RISKS.Text) + "," +
				tool.ConvertNull(this.txt_SC_M_CAPABILITY.Text) + "," +
				tool.ConvertNull(this.txt_SC_M_STRAVISI.Text) + "," +
				tool.ConvertNull(this.txt_SC_M_INTCTRL.Text) + "," +
				tool.ConvertNull(this.txt_SC_M_EXTREGAUDIT.Text) + "," +
				tool.ConvertNull(this.txt_SC_M_SUCCESSION.Text) + "," +
				tool.ConvertNull(this.txt_SC_V_NEWCAPITAL.Text) + "," +
				tool.ConvertNull(this.txt_SC_V_SOLVPROB.Text) + "," +
				tool.ConvertNull(this.txt_SC_V_PRODDEV.Text) + "," +
				tool.ConvertNull(this.txt_SC_V_OPPROBLEM.Text) + "," +
				tool.ConvertNull(this.txt_SC_V_MANPROBLEM.Text) + "," +
				tool.ConvertNull(this.txt_SC_D_INTDEV.Text) + "," +
				tool.ConvertNull(this.txt_SC_D_INDOUTLOOK.Text) + "," +
				tool.ConvertFloat(this.txt_Total.Text.ToString()) + ",'" + 
				this.txt_Score.Text + "'";
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
				conn.QueryString = "EXEC SP_SCORING_CRSS 'Save','" + APREGNO + "','" + CUREF + "'," +
					tool.ConvertNull(this.txt_SC_FC_EQUITYRETURN.Text) + "," +
					tool.ConvertNull(this.txt_SC_FC_TOTCAPITAL.Text) + "," +
					tool.ConvertNull(this.txt_SC_FC_NETLIABI.Text) + "," +
					tool.ConvertNull(this.txt_SC_FC_LIQUIDITY.Text) + "," +
					tool.ConvertNull(this.txt_SC_FC_REVENUEDEV.Text) + "," +
					tool.ConvertNull(this.txt_SC_FC_TOTALOUT.Text) + "," +
					tool.ConvertNull(this.txt_SC_LEGALSTAT.Text) + "," +
					tool.ConvertNull(this.txt_SC_R_PROVINFO.Text) + "," +
					tool.ConvertNull(this.txt_SC_R_CONDACC.Text) + "," +
					tool.ConvertNull(this.txt_SC_R_HONAGREE.Text) + "," +
					tool.ConvertNull(this.txt_SC_MP_PRODQUAL.Text) + "," +
					tool.ConvertNull(this.txt_SC_MP_MARKETSTRA.Text) + "," +
					tool.ConvertNull(this.txt_SC_MP_DEMANDSIT.Text) + "," +
					tool.ConvertNull(this.txt_SC_MP_DEPENDENCE.Text) + "," +
					tool.ConvertNull(this.txt_SC_MP_RISKS.Text) + "," +
					tool.ConvertNull(this.txt_SC_M_CAPABILITY.Text) + "," +
					tool.ConvertNull(this.txt_SC_M_STRAVISI.Text) + "," +
					tool.ConvertNull(this.txt_SC_M_INTCTRL.Text) + "," +
					tool.ConvertNull(this.txt_SC_M_EXTREGAUDIT.Text) + "," +
					tool.ConvertNull(this.txt_SC_M_SUCCESSION.Text) + "," +
					tool.ConvertNull(this.txt_SC_V_NEWCAPITAL.Text) + "," +
					tool.ConvertNull(this.txt_SC_V_SOLVPROB.Text) + "," +
					tool.ConvertNull(this.txt_SC_V_PRODDEV.Text) + "," +
					tool.ConvertNull(this.txt_SC_V_OPPROBLEM.Text) + "," +
					tool.ConvertNull(this.txt_SC_V_MANPROBLEM.Text) + "," +
					tool.ConvertNull(this.txt_SC_D_INTDEV.Text) + "," +
					tool.ConvertNull(this.txt_SC_D_INDOUTLOOK.Text) + "," +
					tool.ConvertFloat(this.txt_Total.Text.ToString()) + ",'" + 
					this.txt_Score.Text + "'";
				try
				{
					conn.ExecuteNonQuery();

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
				catch
				{
					Response.Write("<script language='javascript'>alert('Ada masalah waktu penyimpanan');</script>");
				}
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
			if (txt_SC_FC_EQUITYRETURN.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Equity Return harus diisi');</script>");
				return false;
			}
			else if (txt_SC_FC_TOTCAPITAL.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Return on Total Capital harus diisi');</script>");
				return false;
			}
			else if (txt_SC_FC_NETLIABI.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Gross Cash Flow as % of  Net Liabilities harus diisi');</script>");
				return false;
			}
			else if (txt_SC_FC_LIQUIDITY.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Liquidity/Financial Structure harus diisi');</script>");
				return false;
			}
			else if (txt_SC_FC_REVENUEDEV.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Revenue Development harus diisi');</script>");
				return false;
			}
			else if (txt_SC_FC_TOTALOUT.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Gross Cash Flow as % Total Output harus diisi');</script>");
				return false;
			}
			else if (txt_SC_LEGALSTAT.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Legal status harus diisi');</script>");
				return false;
			}
			else if (txt_SC_R_PROVINFO.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Provision of Information harus diisi');</script>");
				return false;
			}
			else if (txt_SC_R_CONDACC.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Conduct of Accont harus diisi');</script>");
				return false;
			}
			else if (txt_SC_R_HONAGREE.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Honoring of Agreement harus diisi');</script>");
				return false;
			}
			else if (txt_SC_MP_PRODQUAL.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Product Quality... harus diisi');</script>");
				return false;
			}
			else if (txt_SC_MP_MARKETSTRA.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Marketing Strategy... harus diisi');</script>");
				return false;
			}
			else if (txt_SC_MP_DEMANDSIT.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Demand situation... harus diisi');</script>");
				return false;
			}
			else if (txt_SC_MP_DEPENDENCE.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Depencence... harus diisi');</script>");
				return false;
			}
			else if (txt_SC_MP_RISKS.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Risk... harus diisi');</script>");
				return false;
			}
			else if (txt_SC_M_CAPABILITY.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Capability & Integrity harus diisi');</script>");
				return false;
			}
			else if (txt_SC_M_STRAVISI.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Strategic Vision harus diisi');</script>");
				return false;
			}
			else if (txt_SC_M_INTCTRL.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Internal Control harus diisi');</script>");
				return false;
			}
			else if (txt_SC_M_EXTREGAUDIT.Text == "")
			{
				Response.Write("<script language='javascript'>alert('External Register Audit harus diisi');</script>");
				return false;
			}
			else if (txt_SC_M_SUCCESSION.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Succession harus diisi');</script>");
				return false;
			}
			else if (txt_SC_V_NEWCAPITAL.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Availability... harus diisi');</script>");
				return false;
			}
			else if (txt_SC_V_SOLVPROB.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Willingness... harus diisi');</script>");
				return false;
			}
			else if (txt_SC_V_PRODDEV.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Product Development... harus diisi');</script>");
				return false;
			}
			else if (txt_SC_V_OPPROBLEM.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Operational Problems harus diisi');</script>");
				return false;
			}
			else if (txt_SC_V_MANPROBLEM.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Manpower Problem harus diisi');</script>");
				return false;
			}
			else if (txt_SC_D_INTDEV.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Interim Development... harus diisi');</script>");
				return false;
			}
			else if (txt_SC_D_INDOUTLOOK.Text == "")
			{
				Response.Write("<script language='javascript'>alert('Medium/Long... harus diisi');</script>");
				return false;
			}

			return true;
		}


		private void Hitung()
		{
			double FinancialRatio, LegalStatus, Relationship, MarketPosition, Management, 
				Viability, Develop, Total;
			string Score="";
			try 
			{
            
				FinancialRatio = ( Double.Parse(this.txt_SC_FC_EQUITYRETURN.Text) +
					Double.Parse(this.txt_SC_FC_TOTCAPITAL.Text) +
					Double.Parse(this.txt_SC_FC_NETLIABI.Text) +
					Double.Parse(this.txt_SC_FC_LIQUIDITY.Text) +
					Double.Parse(this.txt_SC_FC_REVENUEDEV.Text) +
					Double.Parse(this.txt_SC_FC_TOTALOUT.Text) ) / 6;

				LegalStatus = Double.Parse(this.txt_SC_LEGALSTAT.Text);

				Relationship = ( Double.Parse(this.txt_SC_R_PROVINFO.Text) +
					Double.Parse(this.txt_SC_R_CONDACC.Text) +
					Double.Parse(this.txt_SC_R_HONAGREE.Text) ) / 3;

				MarketPosition = ( Double.Parse(this.txt_SC_MP_PRODQUAL.Text) +
					Double.Parse(this.txt_SC_MP_MARKETSTRA.Text) +
					Double.Parse(this.txt_SC_MP_DEMANDSIT.Text) +
					Double.Parse(this.txt_SC_MP_DEPENDENCE.Text) +
					Double.Parse(this.txt_SC_MP_RISKS.Text) ) / 5;

				Management = ( Double.Parse(this.txt_SC_M_CAPABILITY.Text) +
					Double.Parse(this.txt_SC_M_STRAVISI.Text) +
					Double.Parse(this.txt_SC_M_INTCTRL.Text) +
					Double.Parse(this.txt_SC_M_EXTREGAUDIT.Text) +
					Double.Parse(this.txt_SC_M_SUCCESSION.Text) ) / 5;

				Viability = ( Double.Parse(this.txt_SC_V_NEWCAPITAL.Text) +
					Double.Parse(this.txt_SC_V_SOLVPROB.Text) +
					Double.Parse(this.txt_SC_V_PRODDEV.Text) +
					Double.Parse(this.txt_SC_V_OPPROBLEM.Text) +
					Double.Parse(this.txt_SC_V_MANPROBLEM.Text) ) / 5;

				Develop = ( Double.Parse(this.txt_SC_D_INTDEV.Text) +
					Double.Parse(this.txt_SC_D_INDOUTLOOK.Text) ) / 2;

				Total = FinancialRatio + LegalStatus + Relationship + MarketPosition +
					Management + Viability + Develop;

			

				if (Total <= 15)
					Score = "Ia";
				else if ((Total > 15) && (Total <= 20))
					Score = "Ib";
				else if ((Total > 20) && (Total <= 28))
					Score = "Ic";
				else if ((Total > 28) && (Total <= 35))
					Score = "II";
				else if ((Total > 35) && (Total <= 42))
					Score = "III";
				else if ((Total > 42) && (Total <= 49))
					Score = "IV";
				else if (Total > 49)
					Score = "V";

				txt_FinancialRatio.Text = tool.MoneyFormat(FinancialRatio.ToString());
				txt_Relationship.Text = tool.MoneyFormat(Relationship.ToString());
				txt_MarketPosition.Text = tool.MoneyFormat(MarketPosition.ToString());
				txt_Management.Text = tool.MoneyFormat(Management.ToString());
				txt_Viability.Text = tool.MoneyFormat(Viability.ToString());
				txt_Develop.Text = tool.MoneyFormat(Develop.ToString());

				txt_Total.Text = tool.MoneyFormat(Total.ToString());
				txt_Score.Text = Score;
			}
			catch {}
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
		}

	}
}
