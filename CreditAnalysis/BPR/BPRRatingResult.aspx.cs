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
using System.Data.SqlClient;
using System.Configuration;

namespace SME.CreditAnalysis.BPR
{
	/// <summary>
	/// Summary description for Main.sdafsadf
	/// </summary>
	public partial class BPRRatingResult : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		protected Connection2 conn3;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			conn3 = (Connection2) Session["Connection2"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			LoadResult();

			conn.QueryString = "SELECT * FROM BPR_RESULT WHERE AP_REGNO = '" + Request.QueryString["REGNO"] + "'";
			conn.ExecuteQuery();

			if(conn.GetRowCount() > 0)
			{
				updatestatus.Enabled = true;
			}

			ViewResult();
		}

		private void LoadResult()
		{
			conn.QueryString = "SELECT MAX(ID) as ID FROM BPR_RESULT WHERE AP_REGNO = '" + Request.QueryString["REGNO"] + "'";
			conn.ExecuteQuery();

			string id = conn.GetFieldValue("ID");

			conn.QueryString = "SELECT BPR_CUT_OFF.[DESCRIPTION], BPR_RESULT.TANGGAL, BPR_RESULT.AP_REGNO, BPR_RESULT.TOTAL " +
				"FROM BPR_RESULT, BPR_CUT_OFF WHERE BPR_RESULT.IDCUTOFF = BPR_CUT_OFF.[ID] AND BPR_RESULT.AP_REGNO = '" + 
				Request.QueryString["REGNO"] + "' AND BPR_RESULT.ID = '" + id + "'";
			conn.ExecuteQuery();

			if(conn.GetRowCount() > 0)
			{
				//LBL_OHD_SYS_DECISION.Text = conn.GetFieldValue("DESCRIPTION");
				LBL_A1401.Text = conn.GetFieldValue("DESCRIPTION");
				LBL_A1402.Text = conn.GetFieldValue("AP_REGNO");
				LBL_A1403.Text = conn.GetFieldValue("TANGGAL");
				LBL_A1404.Text = conn.GetFieldValue("TOTAL");
			}
		}
		

		//Procedure ini melakukan set Enable/Disable UpdateStatusButton Final Scoring
		private void setEnableUpadateStatusButton()
		{
			conn.QueryString="exec SP_GET_SCORINGRESULT_STATUS '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue(0,0)=="1")
			{
				updatestatus.Enabled=true;
				//btn_Print.Enabled=true;
			}
			else
			{
				updatestatus.Enabled=false;
				//btn_Print.Enabled=false;
			}
		}

		//Procedure ini melakukan set Disable semua kelompok business type
		private void setDisabledResult()
		{
			tr_hide1.Visible=false;
			
			TR_KetAmbilScoreTerakhir.Visible = false;
			updatestatus.Visible = false;
		}

		//Procedure ini melakukan set Disable semua kelompok business type
		private void setEnabledResult()
		{
			string tipeBusiness="";
			conn.QueryString="exec SP_GETBUSINESSTYPE '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
			tipeBusiness=conn.GetFieldValue("tipeKey");
		}


		private void SecureData() 
		{
			string scr = Request.QueryString["scr"];

			if (scr == "0")
			{
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				int k = 0;
				for (int j=0; j < coll.Count; j++) 
				{
					if (coll[j] is System.Web.UI.HtmlControls.HtmlForm) 
					{
						k = j;
						break;
					}
				}				

				for (int i = 0; i < coll[k].Controls.Count; i++) 
				{
					if (coll[k].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[k].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[k].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[k].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[k].Controls[i] is Button)
					{
						Button btn = (Button) coll[k].Controls[i];
						btn.Visible = false;
					}
					else if (coll[k].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[k].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[k].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[k].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[k].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[k].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[k].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[k].Controls[i];

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

		//Menentukan url link back dari menu scoring result
		private string backLinkLocal(string mc) 
		{
			try 
			{
				conn.QueryString = "select TM_LINKNAME + TM_PARSINGPARAM as BACKLINK from track_menu where menucode = '" + mc + "'";
				conn.ExecuteQuery(); 

				return conn.GetFieldValue("BACKLINK");
			}
			catch (NullReferenceException) 
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


		//Procedure untuk menampilkan menu melalui placeholder
		/*private void ViewMenu()
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
						strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
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
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}*/

		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["tc"] != null && Request.QueryString["tc"] != "") 
			{
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
			} 
			else if (Request.QueryString["mc"] != null && Request.QueryString["mc"] != "") 
			{
				Response.Redirect("/SME/" + backLinkLocal(Request.QueryString["mc"]));
			}
			else 
			{
				// do nothing !!
			}
		}

		SqlDataReader reader2;
		MyConnection con2 = new MyConnection();

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "DELETE BPR_DOWNGRADE WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				//calculate mapping ratio
				con2.OpenConnection();
				reader2 = con2.Query("SELECT ID, DESCRIPTION, QUERYSTRING, REQUESTEDPARAM, COLUMNNAME FROM BPR_KUANTITATIF WHERE ISACTIVE = '1'");
				double result = 0.0;

				conn.QueryString = "DELETE BPR_KUANTITATIF_RESULT WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				if(reader2.HasRows)
				{
					while(reader2.Read())
					{
						string idatt = reader2[0].ToString();
						string query = reader2[2].ToString();
						string param = reader2[3].ToString();
						string namakolom = reader2[4].ToString();
						string deskripsi = reader2[1].ToString();
					
						string querys = query + " '" + Request.QueryString[param].ToString() + "'";
						conn.QueryString = querys;
						conn.ExecuteQuery();

						double ratioResult = MyConnection.ConvertToDouble2(conn.GetFieldValue(namakolom).Replace(",","."));
						string ratioResultS = ratioResult.ToString();

						result += getRatioScore(idatt, ratioResult,deskripsi);
						string resultS = result.ToString();
					}
				}
				con2.CloseConnection();
						
				//setelah dapetin score dari semua ratio, dapetin score dari qualitative
				conn.QueryString = "SELECT COUNT(AP_REGNO) as TOTAL FROM BPR_QUALITATIVE_RESULT WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				int total1 = int.Parse(conn.GetFieldValue("TOTAL"));

				conn.QueryString = "SELECT COUNT(SUBQUALITATIVEID) as TOTAL FROM BPR_SUBQUALITATIVE";
				conn.ExecuteQuery();

				int total2 = int.Parse(conn.GetFieldValue("TOTAL"));

				if(total1 == total2)
				{
					con2.OpenConnection();
					reader2 = con2.Query("SELECT NILAI, SUBSUBQUALITATIVEID, SUBQUALITATIVEID FROM BPR_QUALITATIVE_RESULT WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'");

					if(reader2.HasRows)
					{
						while(reader2.Read())
						{
							string SUBSUBQUALITATIVEID = reader2[1].ToString();
							string SUBQUALITATIVEID = reader2[2].ToString();

							conn.QueryString = "SELECT SUBSUBQUALITATIVEDESC, DOWNGRADE_FLAG FROM BPR_SUBSUBQUALITATIVE WHERE SUBSUBQUALITATIVEID = '" + SUBSUBQUALITATIVEID + "'";
							conn.ExecuteQuery();
						
							if(conn.GetFieldValue("DOWNGRADE_FLAG") == "1")
							{
								string subsubqualitativedesc = conn.GetFieldValue("SUBSUBQUALITATIVEDESC");

								conn.QueryString = "SELECT SUBQUALITATIVEDESC FROM BPR_SUBQUALITATIVE WHERE SUBQUALITATIVEID = '" + SUBQUALITATIVEID + "'";
								conn.ExecuteQuery();

								string subqualitativedesc = conn.GetFieldValue("SUBSUBQUALITATIVEDESC");

								conn3.QueryString = "EXEC BPRINSERTDOWNGRADE '" + Request.QueryString["regno"] + "','"+ subqualitativedesc + ":" +  subsubqualitativedesc + "'";
								conn3.ExecuteQuery();
							}

							result += MyConnection.ConvertToDouble2(reader2[0].ToString().Replace(",","."));
						}

						//cek dulu uda kena downgrade apa g ?
						conn.QueryString = "SELECT COUNT(AP_REGNO) as NUM FROM BPR_DOWNGRADE WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
						conn.ExecuteQuery();

						if(conn.GetFieldValue("NUM") == "0")
						{
							//disini mapping semua result

							conn.QueryString = "SELECT ID, DESCRIPTION, LOWEST, HIGHEST, ISHIGHEST, ISLOWEST FROM BPR_CUT_OFF";
							conn.ExecuteQuery();

							for(int i=0; i<conn.GetRowCount(); i++)
							{
								double a = MyConnection.ConvertToDouble2(conn.GetFieldValue(i,"LOWEST").Replace(",","."));
								double b = MyConnection.ConvertToDouble2(conn.GetFieldValue(i,"HIGHEST").Replace(",","."));

								if(conn.GetFieldValue(i,"ISHIGHEST") == "1")
								{
									if(result >= MyConnection.ConvertToDouble2(conn.GetFieldValue(i,"LOWEST").Replace(",",".")))
									{
										//update idcutoff
										conn.QueryString = "EXEC BPR_SAVE_RESULT '" + Request.QueryString["regno"] + "'," + 
											result.ToString().Replace(",",".") + ",'" + conn.GetFieldValue(i,"ID") + "'" ;
										conn.ExecuteQuery();
										break;
									}
								}
								else if(conn.GetFieldValue(i,"ISLOWEST") == "1")
								{
									if(result <= MyConnection.ConvertToDouble2(conn.GetFieldValue(i,"HIGHEST").Replace(",",".")))
									{
										conn.QueryString = "EXEC BPR_SAVE_RESULT '" + Request.QueryString["regno"] + "'," + 
											result.ToString().Replace(",",".") + ",'" + conn.GetFieldValue(i,"ID") + "'" ;
										conn.ExecuteQuery();
										break;
									}
								}
								else
								{
									if(result >= MyConnection.ConvertToDouble2(conn.GetFieldValue(i,"LOWEST").Replace(",",".")) &&
										result <= MyConnection.ConvertToDouble2(conn.GetFieldValue(i,"HIGHEST").Replace(",",".")))
									{
										conn.QueryString = "EXEC BPR_SAVE_RESULT '" + Request.QueryString["regno"] + "'," + 
											result.ToString().Replace(",",".") + ",'" + conn.GetFieldValue(i,"ID") + "'" ;
										conn.ExecuteQuery();
										break;
									}
								}
							}
						}
						else
						{
							//ambil id paling maks (D)
							conn.QueryString = "SELECT MAX(ID) as ID FROM BPR_CUT_OFF";
							conn.ExecuteQuery();

							conn.QueryString = "EXEC BPR_SAVE_RESULT '" + Request.QueryString["regno"] + "'," + 
								result.ToString().Replace(",",".") + ",'" + conn.GetFieldValue("ID") + "'" ;
							conn.ExecuteQuery();
						}
					}

					con2.CloseConnection();
				}
				else
				{
					Tools.popMessage(this,"Data qualitative belum dilengkapi ! Silahkan dilengkapi terlebih dahulu !");
				}

				ViewResult();
			}
			catch
			{
				Tools.popMessage(this, "Data Neraca / Laba Rugi / ATMR / Komdal / Ratio belum diisi !");
			}
		}

		private double getRatioScore(string idatt, double ratioResult, string deskripsi)
		{
			ratioResult = ratioResult / 100;
			conn.QueryString = "SELECT ID, IDBPRKUANTITATIF, LOWEST, HIGHEST, SCORE, ISHIGHEST, ISLOWEST, DOWNGRADENUM FROM BPR_KUANTITATIF_SCORE WHERE IDBPRKUANTITATIF = '" + idatt + "'";
			conn.ExecuteQuery();

			double rett = 0.0;

			for(int i=0; i<conn.GetRowCount(); i++)
			{
				if(conn.GetFieldValue(i,"ISHIGHEST") == "1")
				{
					if(ratioResult >= MyConnection.ConvertToDouble2(conn.GetFieldValue(i,"LOWEST").Replace(",",".")))
					{
						if(conn.GetFieldValue(i,"DOWNGRADENUM") != "")
						{
							conn3.QueryString = "SELECT DESCRIPTION, DOWNGRADENUM FROM BPR_KUANTITATIF WHERE ID = '" + conn.GetFieldValue ("IDBPRKUANTITATIF") + "'";
							conn3.ExecuteQuery();
							
							string description = conn3.GetFieldValue("DESCRIPTION") + "<" + conn3.GetFieldValue("DOWNGRADENUM");

							conn3.QueryString = "EXEC BPRINSERTDOWNGRADE '" + Request.QueryString["regno"] + "','"+ description + "'";
							conn3.ExecuteQuery();
						}
						string a = MyConnection.ConvertToDouble2(conn.GetFieldValue(i,"SCORE").Replace(",",".")).ToString();
						rett = MyConnection.ConvertToDouble2(conn.GetFieldValue(i,"SCORE").Replace(",","."));

						conn.QueryString = "EXEC BPR_SAVE_RATIO_HIST '" + Request.QueryString["regno"] + "','" + 
							deskripsi + "','" + conn.GetFieldValue(i,"SCORE").Replace(",",".") + "'" ;
						conn.ExecuteQuery();

						return rett;
					}
				}
				else if(conn.GetFieldValue(i,"ISLOWEST") == "1")
				{
					if(ratioResult <= MyConnection.ConvertToDouble2(conn.GetFieldValue(i,"HIGHEST").Replace(",",".")))
					{
						string a = MyConnection.ConvertToDouble2(conn.GetFieldValue(i,"SCORE").Replace(",",".")).ToString();
						rett = MyConnection.ConvertToDouble2(conn.GetFieldValue(i,"SCORE").Replace(",","."));

						conn.QueryString = "EXEC BPR_SAVE_RATIO_HIST '" + Request.QueryString["regno"] + "','" + 
							deskripsi + "','" + conn.GetFieldValue(i,"SCORE").Replace(",",".") + "'" ;
						conn.ExecuteQuery();

						return rett;
					}
				}
				else
				{
					if(ratioResult >= MyConnection.ConvertToDouble2(conn.GetFieldValue(i,"LOWEST").Replace(",",".")) &&
						ratioResult <= MyConnection.ConvertToDouble2(conn.GetFieldValue(i,"HIGHEST").Replace(",",".")))
					{
						string a = MyConnection.ConvertToDouble2(conn.GetFieldValue(i,"SCORE").Replace(",",".")).ToString();
						rett = MyConnection.ConvertToDouble2(conn.GetFieldValue(i,"SCORE").Replace(",","."));

						conn.QueryString = "EXEC BPR_SAVE_RATIO_HIST '" + Request.QueryString["regno"] + "','" + 
							deskripsi + "','" + conn.GetFieldValue(i,"SCORE").Replace(",",".") + "'" ;
						conn.ExecuteQuery();

						return rett;
					}
				}
			}
			return 0.0;
		}

		private void ViewResult()
		{
			conn.QueryString = "SELECT MAX(ID) as ID FROM BPR_RESULT WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			string id = conn.GetFieldValue("ID");

			conn.QueryString = "SELECT BPR_RESULT.*, BPR_CUT_OFF.DESCRIPTION FROM BPR_RESULT,BPR_CUT_OFF WHERE BPR_RESULT.ID = '" + id + "' AND AP_REGNO = '" + Request.QueryString["regno"] + "' AND BPR_CUT_OFF.ID = BPR_RESULT.IDCUTOFF";
			conn.ExecuteQuery();

			LBL_A1401.Text = conn.GetFieldValue("DESCRIPTION");
			LBL_A1402.Text = Request.QueryString["regno"];
			LBL_A1403.Text = conn.GetFieldValue("TANGGAL");
		}

		protected void updatestatus_Click(object sender, System.EventArgs e)
		{
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

			this.backToList();
			
			// menambahkan pesan: GATOT
			string msg = getNextStepMsg(Request.QueryString["regno"]);
			Response.Redirect("../../Scoring/ListScoring.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
		}

		private void backToList() 
		{
			Session.Add("tc", Request.QueryString["tc"]);
			Session.Add("mc", Request.QueryString["mc"]);
			
			string link = "../../Scoring/ListScoring.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"];
			Response.Write("<form name='Form2' action='"+link+"' target='main'");
			Response.Write("");
			Response.Write("</form>");
			Response.Write("<script language='javascript'>alert('Track Update Successful!');</script>");
			Response.Write("<script language='JavaScript'>document.Form2.submit();</script>");			
			
			//Server.Transfer("ListScoring.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);				
			Server.Transfer("../../Scoring/ListScoring.aspx");						
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

	}
}
