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
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for CustProductBaru.asdfsdafs
	/// </summary>
	public partial class CustProductBaru : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			TR_COLL.Visible = false;

			if (Request.QueryString["de"] == "1")
				if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
					Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack) 
			{				
				GlobalTools.fillRefList(DDL_KETENTUAN_KREDIT, "select KET_CODE, KET_DESC from KETENTUAN_KREDIT where AP_REGNO = '" + Request.QueryString["regno"] + "'", false, conn);
				//GlobalTools.fillRefList(ddl_PRJ_CODE, "select PRJ_CODE, PRJ_NAME from rfproject where active = '1' and convert(varchar, prj_expiry_date, 112) >= convert(varchar, getdate(), 112) order by PRJ_NAME", false, conn);
				GlobalTools.fillRefList(ddl_PRJ_CODE, "select PRJ_CODE, PRJ_NAME from rfproject where active = '1' and PRJ_CODE = 'chan1000' order by PRJ_NAME", false, conn);

				tr_confirm_negative.Visible = false;
			}
			//viewdata();
			ViewMenu();
			secureData();

			////////////////////////////////////////////
			///	Initialize Events
			///	
			DDL_KETENTUAN_KREDIT.SelectedIndexChanged += new EventHandler(DDL_KETENTUAN_KREDIT_SelectedIndexChanged);
			BTN_BACK.Click += new ImageClickEventHandler(BTN_BACK_Click);
			this.BTN_PROJECTLIST.Click += new System.EventHandler(this.BTN_PROJECTLIST_Click);
			this.BTN_REEARMARK.Click += new EventHandler(BTN_REEARMARK_Click);
			this.BTN_REFRESH.Click += new EventHandler(BTN_REFRESH_Click);
			this.btn_Save.Click += new EventHandler(btn_Save_Click);
			this.BTN_NEGATIVE_CANCEL.Click += new EventHandler(BTN_NEGATIVE_CANCEL_Click);
			this.BTN_NEGATIVE_OK.Click += new EventHandler(BTN_NEGATIVE_OK_Click);
		}

		private void secureData() 
		{
			if (Request.QueryString["de"] != "1") 
			{
				ddl_PRJ_CODE.Enabled =  false;
				btn_Save.Enabled = false;
				BTN_REEARMARK.Enabled = false;
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
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						//t.ForeColor = Color.MidnightBlue; 
						if (conn.GetFieldValue(i,3).IndexOf("?de=") < 0 && conn.GetFieldValue(i,3).IndexOf("&de=") < 0) 
							strtemp = strtemp + "&de=" + Request.QueryString["de"];	
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"];
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
		
		void viewdata(string KET_CODE)
		{
			string query = "select * from VW_PRODUCTLIST where ap_regno ='"+ Request.QueryString["regno"] + "' and KET_CODE = '" + KET_CODE + "'";

			/// check, kalau dipanggil dari History Loan Info, tidak perlu cek cp_reject atau cp_cancel
			///			
			conn.QueryString = "select * from SCGROUP_INIT2 where GR_KEY like '%MC_HISTORYLOAN%' and groupid = '" + Request.QueryString["mc"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() == 0)
				query = query + " and (cp_reject <> '1' and cp_cancel <> '1')";

			conn.QueryString = query;
			conn.ExecuteQuery();
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			int jmlCell = dt.Rows.Count;
			int jmlRow = HitungRow(jmlCell);
			int cellKe = 0;

			Table1.Rows.Clear();

			for (int i = 0; i < jmlRow ; i++) // Jumlah Row = 3
			{
				// cek productid pada row ke-i, jika dia merupakan not nego dan alternate rate -> generate
				generateAlternateRate(dt.Rows[0]["PRODUCTID"].ToString(), dt.Rows[0]["APPTYPE"].ToString(), dt.Rows[0]["PROD_SEQ"].ToString());

				int posisi = 0;
				if (cellKe == jmlCell)
					break;
				for (int j = 0; j < 3; j++) // Jumlah Cell per Row = 3
				{
					if (cellKe == jmlCell)
						break;
					this.Table1.Rows.Add(new TableRow());
						
					HyperLink t = new HyperLink();
					t.Text = dt.Rows[cellKe][1]+" "+dt.Rows[cellKe][2]+" ("+dt.Rows[cellKe][3]+")";
					t.CssClass = "White";
					t.Font.Bold = true;

					if (dt.Rows[cellKe][0].ToString() == "01")
					{
						conn.QueryString = "select iscashloan from rfproduct where productid='" + dt.Rows[cellKe][1].ToString() + "'";
						conn.ExecuteQuery();
						if (conn.GetFieldValue(0,0) == "0")
							conn.QueryString = "select screenlink from apptypelink where APPTYPEID = '"+ dt.Rows[cellKe][0] + "' and PRODUCTID='" + "M21"/*+ dt.Rows[i+j][1]*/ + "' and fungsiId='CS' and iscashloan='0'";
						else	conn.QueryString = "select screenlink from apptypelink where APPTYPEID = '"+ dt.Rows[cellKe][0] + "' and PRODUCTID='" + "M21"/*+ dt.Rows[i+j][1]*/ + "' and fungsiId='CS' and iscashloan='1'";
					}
					else 
					{
						TR_COLL.Visible = true;
						conn.QueryString = "select screenlink from apptypelink where APPTYPEID = '"+ dt.Rows[cellKe][0] + "' and PRODUCTID='" + "M21"/*+ dt.Rows[i+j][1]*/ + "' and fungsiId='CS' ";
					}
					conn.ExecuteQuery();

					//---------- edited by Yudi ------------
					//t.NavigateUrl = conn.GetFieldValue("screenlink")+"?regno="+Request.QueryString["regno"]+"&prodid="+dt.Rows[i+j][1]+"&teks="+t.Text;
					//ditambahkan flag untuk Request.QueryString["view"] untuk keperluan status tampilan alternate rate
					t.NavigateUrl = conn.GetFieldValue("screenlink")+"?regno="+Request.QueryString["regno"]+"&curef=" + Request.QueryString["curef"] + "&apptype="+dt.Rows[cellKe][0] + "&prodid="+dt.Rows[cellKe][1]+"&teks="+t.Text + "&de=" + Request.QueryString["de"] + "&prod_seq=" + dt.Rows[cellKe]["PROD_SEQ"].ToString() + "&view=" + Request.QueryString["sta"] + "&ket_code=" + KET_CODE;
					//t.NavigateUrl = conn.GetFieldValue("screenlink")+"?regno=11052004001000001&prodid="+dt.Rows[i+j][1]+"&teks="+t.Text+"&view="+Request.QueryString["sta"]+"";

					t.Target = "ProdDetail";
					this.Table1.Rows[i].Cells.Add(new TableCell());
					this.Table1.Rows[i].Cells[posisi].Text = (cellKe+1) +". ";
					this.Table1.Rows[i].Cells[posisi].VerticalAlign=VerticalAlign.Top;
					this.Table1.Rows[i].Cells.Add(new TableCell());
					this.Table1.Rows[i].Cells[posisi+1].Controls.Add(t);
					this.Table1.Rows[i].Cells[posisi+1].VerticalAlign=VerticalAlign.Top;
					posisi +=2;
					cellKe++;
				}
				//rowKe++;
				//jmlCell -=3;
				if (cellKe == jmlCell)
					break;
			}
			conn.ClearData();		
		}

		int HitungRow(int count)
		{
			int jml = count/3;
			int mod = count % 3;
			if (mod == 0)
				return jml;
			else
				return jml+1;

		}

		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["par"] != null && Request.QueryString["par"] != "") 
				Response.Redirect(Request.QueryString["par"] + "&regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"]);
			else 
			{
				string tc = Request.QueryString["tc"];
				string mc = Request.QueryString["mc"];
				string backLink1 = DMS.CuBESCore.Logic.backLink(tc, mc, conn);
				string backLink2 = DMS.CuBESCore.Logic.backLink(tc, conn);
				if (backLink1.Equals("")) 
				{
					Response.Redirect("/SME/" + backLink2);
				}
				else 
				{
					Response.Redirect("/SME/" + backLink1);
				}
			}			
		}

		private void viewKetentuanKredit(string KET_CODE) 
		{
			try 
			{	
				///////////////////////////////////////////////////////////////////////////
				/// Because of the growth of complexity, view data is modified
				/// from VIEW to STORED PROCEDURE
				/// 
				//conn.QueryString = "select * from VW_KETENTUAN_KREDIT where KET_CODE = '" + KET_CODE + "'";
				
				conn.QueryString = "exec DE_KETENTUAN_KREDIT '" + KET_CODE + "'";
				conn.ExecuteQuery();

				LBL_AA_NO.Text = conn.GetFieldValue("AA_NO");
				LBL_ACC_NO.Text = conn.GetFieldValue("ACC_NO");
				LBL_PRODUCTID.Text = conn.GetFieldValue("PRODUCTID");
				LBL_ACC_SEQ.Text = conn.GetFieldValue("ACC_SEQ");


				////////////////////////////////////////
				/// Earmark by Project
				/// 
				LBL_PRJ_CODE.Text = conn.GetFieldValue("PRJ_NAME");
				try {ddl_PRJ_CODE.SelectedValue = conn.GetFieldValue("PRJ_CODE");}
				catch {}
				LBL_EARMARK_AMOUNT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("EARMARK_AMOUNT_PRJ"));


				////////////////////////////////////////
				/// Earmark by Facility
				/// 
				LBL_REMAIN_EMAS_LIMIT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("remaining_emas_limit"));
				LBL_PENDING_ACCEPT_LIMIT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("pending_accept_limit"));
				LBL_UNUTILIZED_LIMIT.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("unutilized_limit"));
				LBL_CUREF_CHANN.Text = conn.GetFieldValue("cu_ref_chann_name");
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error !");
				return;
			}
			catch (Exception ex)
			{
				ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "App No: " + Request.QueryString["regno"]);
			}
		}

		private void DDL_KETENTUAN_KREDIT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			viewdata(DDL_KETENTUAN_KREDIT.SelectedValue);
			viewKetentuanKredit(DDL_KETENTUAN_KREDIT.SelectedValue);
		}

		private void generateAlternateRate( string productid, string apptype, string prodseq )
		{
			string regno = Request.QueryString["regno"];
			try
			{
				//cek dulu syarat punya preset: ISNEGORATE == 0 dan INTERESTTYPE == 03
				conn.QueryString  = "select INTERESTTYPE, ISNEGORATE, ALTRATECALC, ISINSTALLMENT from RFPRODUCT ";
				conn.QueryString += "where PRODUCTID = '" + productid +"'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() < 1) return; //jika tidak ada langsung break

				string interesttype	= conn.GetFieldValue("INTERESTTYPE");
				string isnegorate	= conn.GetFieldValue("ISNEGORATE");
				string altratecalc	= conn.GetFieldValue("ALTRATECALC");
				string isinstallment= conn.GetFieldValue("ISINSTALLMENT");
				if (!((interesttype == "03") && (isnegorate == "0"))) return; // jika tidak memenuhi syarat preset rate, keluar
 
				conn.QueryString  = "select * from VW_CUSTPRODUCT where ap_regno='"+ regno +"' and ";
				conn.QueryString += "PRODUCTID='"+ productid +"' and APPTYPE='" + apptype +"' and ";
				conn.QueryString += "PROD_SEQ = '" + prodseq + "'";
				conn.ExecuteQuery();
				// dapatkan limitnya
				double cp_exlimitval = double.Parse(conn.GetFieldValue("CP_EXLIMITVAL"));
				// dapatkan maxtenornya
				int cp_jangkawkt	= int.Parse(conn.GetFieldValue("CP_JANGKAWKT"));
				// dapatkab tenorcodenya
				string tenorcode	= conn.GetFieldValue("CP_TENORCODE");
				
				//ambil rfproduct_preset_rate
				conn.QueryString  = "select * from VW_PARAM_GENERAL_RFPRODUCT_PRESETRATE ";
				conn.QueryString += "where PRODUCTID = '" + productid + "' order by SEQUENCE ASC";
				conn.ExecuteQuery();
				 
				DataTable dt = new DataTable();
				dt = conn.GetDataTable().Copy();
				//Response.Write(conn.QueryString + "<BR>");

				int maxseq = conn.GetRowCount();
				int presettenor = 0;
				double fixedrate = 0;
				double floatingrate = 0;
				double variance = 0;
				double installment = 0;
				string varcode = " ";
				string ACCKIND = "0";


				// loop untuk mengenerate item untuk dimasukkan ke alternaterate table
				int sequence = 1; //sequence awal
				for ( int i = 0; i < maxseq; i++)
				{
					try 
					{
						presettenor = Convert.ToInt32(dt.Rows[i]["TENOR"].ToString());
					} 
					catch (Exception) { presettenor = 0; }
					try 
					{
						fixedrate = Convert.ToDouble(dt.Rows[i]["FIXEDRATE"].ToString());
					} 
					catch (Exception) { fixedrate = 0; }
					try 
					{
						floatingrate = Convert.ToDouble(dt.Rows[i]["RATE"].ToString());
					} 
					catch (Exception) { floatingrate = 0; }
					try 
					{
						variance = Convert.ToDouble(dt.Rows[i]["VARIANCE"].ToString());
					} 
					catch (Exception) { variance = 0; }
					try 
					{
						varcode = dt.Rows[i]["VARCODE"].ToString();
					} 
					catch (Exception) { varcode = " "; }

					// hitung installment
					//Response.Write(presettenor + " " + fixedrate + " " + floatingrate + " " + varcode + " " + variance + " " + installment + "<BR>");
					
					if ((cp_jangkawkt >= 1) && (cp_jangkawkt >= presettenor) && (presettenor >= 1) && (i != (maxseq-1)))
					{	// cp_jangkawkt / maxtenor >= tenor pada sequence ke-i, bukan di baris akhir
						installment = hitungInstallment(productid, cp_exlimitval, tenorcode, presettenor, 
							fixedrate, floatingrate, varcode, variance, altratecalc, isinstallment);
						conn.QueryString  = "exec DE_ALTERNATE_RATE " +
							"'" + regno + "', '" + productid + "', " + prodseq + ", '" + ACCKIND +
							"', " + sequence + ", " + presettenor + 
							", " + fixedrate.ToString().Replace(".","").Replace(",",".") + 
							", " + floatingrate.ToString().Replace(".","").Replace(",",".") + 
							", '" + varcode + 
							"', " + variance.ToString().Replace(".","").Replace(",",".") + 
							", " + installment.ToString().Replace(".","").Replace(",",".") + 
							", '1'";
						//Response.Write(conn.QueryString + "<BR>");
						conn.ExecuteNonQuery();
						cp_jangkawkt -= presettenor; // tenor produk dikurangi
						sequence++;
					} 
					else if ((cp_jangkawkt >= presettenor) && (i == (maxseq-1) && (cp_jangkawkt >=1)))
					{ // cp_jangkawkt >= presettenor di baris terakhir
						//installment = calcInstallment(maxtenor, fixedrate, floatingrate, varcode, variance, calcmethod);
						installment = hitungInstallment(productid, cp_exlimitval, tenorcode, cp_jangkawkt, 
							fixedrate, floatingrate, varcode, variance, altratecalc, isinstallment);
					
						conn.QueryString  = "exec DE_ALTERNATE_RATE " +
							"'" + regno + "', '" + productid + "', " + prodseq + ", '" + ACCKIND +
							"', " + sequence + ", " + cp_jangkawkt + 
							", " + fixedrate.ToString().Replace(".","").Replace(",",".") + 
							", " + floatingrate.ToString().Replace(".","").Replace(",",".") + 
							", '" + varcode + 
							"', " + variance.ToString().Replace(".","").Replace(",",".") + 
							", " + installment.ToString().Replace(".","").Replace(",",".") + 
							", '1'";
						//Response.Write(conn.QueryString + "<BR>");
						conn.ExecuteNonQuery();
						cp_jangkawkt = 0;
						sequence++;
						break;
					}
					else if ((cp_jangkawkt <= presettenor) && (cp_jangkawkt >=1))
					{	// tenor tersisa akan dihitung dengan preset rate terakhir
						//installment = calcInstallment(maxtenor, fixedrate, floatingrate, varcode, variance, calcmethod);
						installment = hitungInstallment(productid, cp_exlimitval, tenorcode, cp_jangkawkt, 
							fixedrate, floatingrate, varcode, variance, altratecalc, isinstallment);

						conn.QueryString  = "exec DE_ALTERNATE_RATE " +
							"'" + regno + "', '" + productid + "', " + prodseq + ", '" + ACCKIND +
							"', " + sequence + ", " + cp_jangkawkt + 
							", " + fixedrate.ToString().Replace(".","").Replace(",",".") + 
							", " + floatingrate.ToString().Replace(".","").Replace(",",".") + 
							", '" + varcode + 
							"', " + variance.ToString().Replace(".","").Replace(",",".") + 
							", " + installment.ToString().Replace(".","").Replace(",",".") + 
							", '1'";
						//Response.Write( conn.QueryString + "<BR>");
						conn.ExecuteNonQuery();
						cp_jangkawkt = 0;
						sequence++;
						break;
					} 
				}
			}
			catch {}
		}

		private double hitungInstallment(
			string productid,
			double cpexlimitval,
			string tenorcode,
			int tenor,
			double fixedrate, 
			double floatingrate, 
			string varcode, 
			double variance, 
			string method,
			string isinstallment)
		{
			double retval = 0;
			double blr = 0;

			if (varcode == "+") blr = floatingrate + variance;
			else if (varcode == "-") blr = floatingrate - variance;
			else blr = floatingrate;

			if (method == "0") 
			{	// Based Landing Rate (BLR)
				try 
				{
					// bagi persentase berdasarkan tenor code: bunga per hari atau per bulan
					// kalikan bunga dengan jumlah tenor lalu kalikan dengan limit
					// bagilah dengan 100 untuk menghilangkan persen
					double bunga = 0;
					if (tenorcode == "M") 
					{
						bunga = blr / 12; // 12 mendandakan jumlah bulan setahun
					} 
					else if (tenorcode == "D") 
					{
						bunga = blr / 365; // 12 mendandakan jumlah bulan setahun
					}
					retval = tenor * bunga * cpexlimitval / 100; // 100 digunakan untuk menghilangkan tanda persen dari bunga
				}
				catch(Exception)
				{
					retval = 0;
				}
			} 
			else
			{	// calcmethod tidak bernilai 0 maka dihitung secara vary
				if (fixedrate != 0) 
				{ // hasil = (sukubunga/tenor) * (cplimit/100)// angka 100 untuk membagi sukubunga yang masih dalam persen 
					try 
					{ // input ratre untuk rumus berikut adalah persentase dalam angka bulat: 19% maka rate yang jadi argumen adalah 19
						double bunga = 0;
						if (tenorcode == "M") 
						{
							bunga = fixedrate / 12; // 12 menandakan jumlah bulan setahun
						} 
						else if (tenorcode == "D") 
						{
							bunga = fixedrate / 365; // 12 menandakan jumlah bulan setahun
						}
						retval = tenor * bunga * cpexlimitval / 100; // 100 digunakan untuk menghilangkan tanda persen dari bunga
					}
					catch (Exception) 
					{
						retval = 0;
					}
				}
				else 
				{ // hitung bunga berdasarkan floatingrate + variance
					try 
					{
						double bunga = 0;
						if (tenorcode == "M") 
						{
							bunga = blr / 12; // 12 mendandakan jumlah bulan setahun
						} 
						else if (tenorcode == "D") 
						{
							bunga = blr / 365; // 12 mendandakan jumlah bulan setahun
						}
						retval = tenor * bunga * cpexlimitval / 100; // 100 digunakan untuk menghilangkan tanda persen dari 
					} 
					catch(Exception) 
					{
						retval = 0;
					}
				}
			}
			// jika kasusnya installment maka bunga ditambah dengan cpexlimitval
			if (isinstallment == "1") retval += cpexlimitval;
			return retval;
		}

		private void BTN_PROJECTLIST_Click(object sender, System.EventArgs e)
		{			
			Response.Write("<script for=window event=onload language='javascript'>PopupPage('../ProjectInfo.aspx?targetFormID=Form1', '800','600');</script>");
			DDL_KETENTUAN_KREDIT_SelectedIndexChanged(sender, e);
		}

		private void BTN_REEARMARK_Click(object sender, EventArgs e)
		{
			string _apregno = Request.QueryString["regno"];

			/*
			//////////////////////////////////////////////////////////////////
			/// For the sake of safety, check first whether it needs
			/// earmarking or not
			/// 
			conn.QueryString = "exec EARMARK_CEK '" + _apregno + "', '" + DDL_KETENTUAN_KREDIT.SelectedValue + "'";
			conn.ExecuteQuery();
			//Response.Write("<!-- query EARMARK_CEK: " + conn.QueryString.ToString() + "-->");
			if (conn.GetFieldValue("NEED_EARMARK") == "1") 
			{
			*/

				try 
				{								
					/// Reverse dulu
					/// 
					/*Earmarking.Earmarking.reverseEarmark(_apregno, DDL_KETENTUAN_KREDIT.SelectedValue, conn);
					Response.Write("<!-- reverse -->");*/

					/// re-calculate earmark amount
					/// 
					/*Earmarking.Earmarking.calculateEarmarkLimit(_apregno, DDL_KETENTUAN_KREDIT.SelectedValue, conn);
					Response.Write("<!-- calculate -->");*/

					/// Update Ketentuan Kredit
					/// 				
					conn.QueryString = "UPDATE KETENTUAN_KREDIT SET PRJ_CODE = " + GlobalTools.ConvertNull(ddl_PRJ_CODE.SelectedValue) + " WHERE KET_CODE = '" + DDL_KETENTUAN_KREDIT.SelectedValue + "'";
					conn.ExecuteQuery();
					//Response.Write("<!-- update ketentuan -->");

					/// Do Earmark
					/// 
					/*if (TXT_NEGATIVE.Text == "YES") 
						Earmarking.Earmarking.doEarmark(_apregno, DDL_KETENTUAN_KREDIT.SelectedValue, conn, "1", "");
					else
						Earmarking.Earmarking.doEarmark(_apregno, DDL_KETENTUAN_KREDIT.SelectedValue, conn);
					
					Response.Write("<!-- earmark -->");
					Response.Write("<!-- ap_regno: " + _apregno + " -->");
					Response.Write("<!-- ket_code: " + DDL_KETENTUAN_KREDIT.SelectedValue + " -->");
					Response.Write("<!-- TXT_NEGATIVE: " + TXT_NEGATIVE.Text + " -->");
					

					conn.ExecTran_Commit();*/
				} 
				catch (Earmarking.NegativeLimitException ex1) 
				{
					/*Response.Write("<!-- negativeLimitException -->");
					if (conn != null) conn.ExecTran_Rollback();

					if (ex1.getMessage() == "FACILITY") 
					{
						GlobalTools.popMessage(this, "Earmarking by facility failed. Remaining limit become negative!");
						return;
					} 

					if (TXT_NEGATIVE.Text == "NO") {
						tr_confirm_negative.Visible = true;
					}	*/				
				}
				catch (Exception ex)
				{
					/*ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "App No: " + _apregno);
					if (conn != null) 
					{
						conn.ExecTran_Rollback();
					}*/
				}

			/*}*/

			DDL_KETENTUAN_KREDIT_SelectedIndexChanged(sender, e);
		}

		private void BTN_REFRESH_Click(object sender, EventArgs e)
		{
			viewKetentuanKredit(DDL_KETENTUAN_KREDIT.SelectedValue);
			DDL_KETENTUAN_KREDIT_SelectedIndexChanged(sender, e);
		}

		private void BTN_NEGATIVE_OK_Click(object sender, System.EventArgs e)
		{
			TXT_NEGATIVE.Text = "YES";
			BTN_REEARMARK_Click(sender, e);
			TXT_NEGATIVE.Text = "NO";
			tr_confirm_negative.Visible = false;

			try { DDL_KETENTUAN_KREDIT.SelectedValue = ""; } catch {}
		}

		private void BTN_NEGATIVE_CANCEL_Click(object sender, System.EventArgs e)
		{
			tr_confirm_negative.Visible = false;
			try { DDL_KETENTUAN_KREDIT.SelectedValue = ""; } catch {}
		}

		private void btn_Save_Click(object sender, System.EventArgs e)
		{
			BTN_REEARMARK_Click(sender, e);
			//DDL_KETENTUAN_KREDIT_SelectedIndexChanged(sender, e);
		}
	}
}

