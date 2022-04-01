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

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for arAlternateRate.
	/// </summary>
	public partial class arAlternateRate : System.Web.UI.Page
	{
	
		#region " Variables "

		private Connection conn;
		private Tools tool = new Tools();
		private string AP_REGNO, CU_REF, APPTYPE, PRODUCTID, PROD_SEQ, ACCKIND, TENORCODE, VIEW;

		#endregion

		protected System.Web.UI.WebControls.Button BTN_SAVE;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			AP_REGNO	= Request.QueryString["regno"];
			CU_REF		= Request.QueryString["curef"];
			APPTYPE		= Request.QueryString["apptype"];
			PRODUCTID	= Request.QueryString["prodid"];
			PROD_SEQ	= Request.QueryString["prodseq"];
			ACCKIND		= Request.QueryString["acckind"];
			VIEW		= Request.QueryString["view"];

			if (!IsPostBack) 
			{
				setScreen();
			}

			/// men-disable semua field/input
			/// 
			secureData();
		}

		private void secureData() 
		{
			/// kalau passed-query "de" <> "1", maka disable semua field/input
			/// 
			if (Request.QueryString["de"] != "1") disableForm();
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
			this.DGR_ALTERNATERATE.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_ALTERNATERATE_ItemCommand);
			this.DGR_ALTERNATERATE.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DGR_ALTERNATERATE_SortCommand);

		}
		#endregion		

		private void viewData() 
		{
			DataTable RATE = new DataTable();
			DataRow datrow;
			RATE.Columns.Add(new DataColumn("SEQUENCE"));
			RATE.Columns.Add(new DataColumn("TENOR"));
			RATE.Columns.Add(new DataColumn("FIXEDRATE"));
			RATE.Columns.Add(new DataColumn("FLOATINGRATE"));
			RATE.Columns.Add(new DataColumn("VARCODE"));
			RATE.Columns.Add(new DataColumn("VARIANCE"));
			RATE.Columns.Add(new DataColumn("INSTALLMENT"));

			try 
			{
				conn.QueryString = "select * from ALTERNATERATE " + 
					"where AP_REGNO = '" + AP_REGNO + 
					"' and PRODUCTID = '" + PRODUCTID + 
					"' and PROD_SEQ = " + PROD_SEQ +
					" and ACCKIND = '" + ACCKIND + "' order by " + LBL_SORT_EXP.Text + " " + LBL_SORT_TYPE.Text;
				//LBL_SERBA.Text = conn.QueryString;
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return;
			}
			try 
			{
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Server Error !");
				return;
			}

			//Response.Write(conn.QueryString);
			string ratefixed, ratefloat = "";
			for (int i =0; i < conn.GetRowCount(); i++) 
			{
				datrow = RATE.NewRow();
				datrow[0] = conn.GetFieldValue(i,"SEQUENCE"); //seq
				datrow[1] = conn.GetFieldValue(i,"TENOR"); //tenor
				ratefixed = conn.GetFieldValue(i,"FIXEDRATE");
				ratefloat = conn.GetFieldValue(i,"FLOATINGRATE");
				
				if ((ratefixed == "") || (ratefixed == null))
					datrow[2] = "";
				else if (Convert.ToSingle(ratefixed) > 0)
                    datrow[2] = GlobalTools.MoneyFormat(ratefixed) + "%"; //fixed
				else datrow[2] = "";
				
				if ((ratefloat == "") || (ratefloat == null))
					datrow[3] = "";
				else if (Convert.ToSingle(ratefloat) > 0)
                    datrow[3] = GlobalTools.MoneyFormat( ratefloat) + "%"; //floating
				else datrow[3] = "";

				datrow[4] = conn.GetFieldValue(i,"VARCODE"); //varcode
				if ((datrow[4].ToString() == "+") || (datrow[4].ToString() == "-"))
				{ // sudah benar
					datrow[5] = GlobalTools.MoneyFormat(conn.GetFieldValue(i,"VARIANCE")) + "%"; //variance
				} 
				else
				{
					datrow[5] = "";
				}
				
				if (LBL_ISINSTALLMENT.Text == "1") 
				{ // jika installment maka installment tidak ditampilkan
					datrow[6] = "";
				}
				else if (LBL_NEGO.Text == "1")
				{ // jika nego maka asalkan bukan installment, tampilkan bunga
					//datrow[6] = "";
					datrow[6] = GlobalTools.MoneyFormat(conn.GetFieldValue(i,"INSTALLMENT")); //installment
				} else
				{
					datrow[6] = GlobalTools.MoneyFormat(conn.GetFieldValue(i,"INSTALLMENT")); //installment
				}
	
				RATE.Rows.Add(datrow);
			}
			DGR_ALTERNATERATE.DataSource = new DataView(RATE);
			DGR_ALTERNATERATE.DataBind();
		}

		// mengecek apakah string mengandung koma lebih dari satu
		// mengembalikan true jika string mengandung koma lebih dari satu
		private bool invalidComma(string s)
		{
			bool r = false;
			int len = s.Length;
			int flag = 0;
			for (int i=0; i<len; i++)
			{
				if (s.Substring(i,1) == ",") flag++;
				if (flag == 2)
				{
					Response.Write("<script language='javascript'>alert('Input tidak valid!');</script>");
					r = true;
					break;
				}
			}
			return r;
		}

		private bool isInputValid() 
		{
			bool isValid = true;
			if (TXT_SEQ.Text == "") 
			{
				Response.Write("<script language='javascript'>alert('Kolom Sequence tidak boleh kosong!');</script>");
				isValid = false;
				return isValid;
			}
			if ((TXT_TENOR.Text == "0") || (TXT_TENOR.Text == ""))
			{
				Response.Write("<script language='javascript'>alert('Kolom Tenor tidak boleh kosong!');</script>");
				isValid = false;
				return isValid;
			}

			if ((TXT_FIXEDRATE.Text != "") || (TXT_FLOATINGRATE.Text != "") || (TXT_VARIANCE.Text != ""))
			{
				if (TXT_FIXEDRATE.Text.StartsWith(",") || TXT_FLOATINGRATE.Text.StartsWith(","))
				{
					Response.Write("<script language='javascript'>alert('Input tidak valid!');</script>");
					isValid = false;
					return isValid;
				}

				if (invalidComma(TXT_FIXEDRATE.Text) || invalidComma(TXT_FLOATINGRATE.Text) || invalidComma(TXT_VARIANCE.Text))
				{
					isValid = false;
					return isValid;
				}
			
				// checking sequence input
			}

			if ((TXT_FIXEDRATE.Text == "") && (TXT_FLOATINGRATE.Text == ""))
			{
				Response.Write("<script language='javascript'>alert('Salah satu rate harus diisi!');</script>");
				isValid = false;
				return isValid;
			}
			try 
			{
				conn.QueryString = "select * from ALTERNATERATE " + 
					"where AP_REGNO = '" + AP_REGNO + 
					"' and PRODUCTID = '" + PRODUCTID + 
					"' and PROD_SEQ = " + PROD_SEQ +
					" and ACCKIND = '" + ACCKIND +
					"' and SEQUENCE = '" + TXT_SEQ.Text.Trim() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0) 
				{
					Response.Write("<script language='javascript'>alert('Sequence sudah ada!');</script>");
					isValid = false;
				}
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				isValid = false;
			}

			return isValid;
		}

		private void clearInput() 
		{
			TXT_SEQ.Text			= "";
			TXT_SEQ.BackColor		= Color.White;
			TXT_SEQ.ReadOnly		= false;
			TXT_TENOR.Text			= "";
			TXT_FIXEDRATE.Text		= "";
			TXT_FLOATINGRATE.Text	= "";
			//if (LBL_ISINSTALLMENT.Text == "1") LBL_ISINSTALLMENT.Text	= "";
			DDL_CODE.SelectedValue	= " ";
			TXT_VARIANCE.Text		= "";
			TXT_INSTALLMENT.Text	= "";
		}


		private void setScreen()
		{
			conn.QueryString  = "select ISNEGORATE, ISINSTALLMENT, INTERESTTYPE from RFPRODUCT ";
			conn.QueryString += "where PRODUCTID = '" + PRODUCTID + "'";
			conn.ExecuteQuery();

			LBL_NEGO.Text			= conn.GetFieldValue("ISNEGORATE");
			LBL_ISINSTALLMENT.Text	= conn.GetFieldValue("ISINSTALLMENT");
			LBL_INTERESTTYPE.Text	= conn.GetFieldValue("INTERESTTYPE"); 
			//LBL_SERBA.Text = conn.QueryString + " " + nego + " " + installment;

			TXT_INSTALLMENT.ReadOnly = true; // default tidak bisa diketik
			TXT_INSTALLMENT.BackColor = Color.Gainsboro;

			// mengeset cp_tenor dan limit
			conn.QueryString  = "select CP_JANGKAWKT, CP_EXLIMITVAL, CP_INSTALLMENT from CUSTPRODUCT where ";
			conn.QueryString += "AP_REGNO = '" + AP_REGNO + "' and ";
			conn.QueryString += "APPTYPE = '" + APPTYPE + "' and ";
			conn.QueryString += "PRODUCTID = '" + PRODUCTID + "' and ";
			conn.QueryString += "PROD_SEQ = " + PROD_SEQ;
			conn.ExecuteQuery();

			TXT_CP_TENOR.Text = conn.GetFieldValue("CP_JANGKAWKT");
			TXT_LIMIT.Text = conn.GetFieldValue("CP_EXLIMITVAL");
			TXT_CP_INSTALLMENT.Text = conn.GetFieldValue("CP_INSTALLMENT");
			
			updateViewTenor("");

			if (!((LBL_NEGO.Text == "1") && (LBL_INTERESTTYPE.Text == "03")))
			{ // bukan alternate rate dan bukan negorate, DISABLE semua
				//Response.Redirect("../Maintenance/Parameters/General/AlternateRate.aspx?productid=" + Request.QueryString["productid"] + "&edit=no");
				disableForm();
				viewPresetAlternateRate();
			}
			else
			{
				if ((VIEW != "") && (VIEW != null))
				{ // jika ada flag agar men-disable form
					disableForm();
				}
				viewData();
			}			
		}

		/* method untuk men-disable form pada saat mode read only */
		private void disableForm()
		{
			TXT_SEQ.Enabled = false;
			TXT_TENOR.Enabled = false;
			TXT_FIXEDRATE.Enabled = false;
			TXT_FLOATINGRATE.Enabled = false;
			TXT_VARIANCE.Enabled = false;
			TXT_INSTALLMENT.Enabled = false;
			DDL_CODE.Enabled = false;

			TXT_SEQ.BackColor = Color.Gainsboro;
			TXT_TENOR.BackColor = Color.Gainsboro;
			TXT_FIXEDRATE.BackColor = Color.Gainsboro;
			TXT_FLOATINGRATE.BackColor = Color.Gainsboro;
			TXT_VARIANCE.BackColor = Color.Gainsboro;
			TXT_INSTALLMENT.BackColor = Color.Gainsboro;
			DDL_CODE.BackColor = Color.Gainsboro;

			BTN_INSERT.Enabled = false;
			//LBL_CP_TENOR.Visible = false;
			//LBL_SUM_TENOR.Visible = false;
			//TXT_CP_TENOR.Visible = false;
			//TXT_SUM_TENOR.Visible = false;
		}

		/* method ini menghitung bunga yang harus dibayar beserta pokoknya */
		private double calcInstallment()
		{
			double retval = 0;
			double blr = 0;

			conn.QueryString  = "select INTERESTTYPE, ISNEGORATE, ALTRATECALC from RFPRODUCT ";
			conn.QueryString += "where PRODUCTID = '" + PRODUCTID + "'";
			conn.ExecuteQuery();
			
			string method = conn.GetFieldValue("ALTRATECALC"); // cara kalkulasi: BLR or VARY

			// mengeset cp_tenor dan limit
			conn.QueryString  = "select CP_TENORCODE from CUSTPRODUCT where ";
			conn.QueryString += "AP_REGNO = '" + AP_REGNO + "' and ";
			conn.QueryString += "APPTYPE = '" + APPTYPE + "' and ";
			conn.QueryString += "PRODUCTID = '" + PRODUCTID + "' and ";
			conn.QueryString += "PROD_SEQ = " + PROD_SEQ;
			//LBL_SERBA.Text = conn.QueryString;
			conn.ExecuteQuery();

			TENORCODE = conn.GetFieldValue("CP_TENORCODE");

			double limit = double.Parse(GlobalTools.ConvertFloat(TXT_LIMIT.Text));

			int tenor = 0;
			double fixedrate = 0;
			double floatingrate = 0;
			double variance = 0;
			string varcode = "0";

			try 
			{
				tenor = Convert.ToInt32(TXT_TENOR.Text);
			} 
			catch (Exception) { tenor = 0; }
			try 
			{
				fixedrate = Convert.ToDouble(toStrBiasa(TXT_FIXEDRATE.Text));
			} 
			catch (Exception) { fixedrate = 0; }
			try 
			{
				floatingrate = Convert.ToDouble(toStrBiasa(TXT_FLOATINGRATE.Text));
			} 
			catch (Exception) { floatingrate = 0; }
			try 
			{
				variance = Convert.ToDouble(toStrBiasa(TXT_VARIANCE.Text));
			} 
			catch (Exception) { variance = 0; }
			try 
			{
				varcode = DDL_CODE.SelectedValue;
			} 
			catch (Exception) { varcode = " "; }

			if (varcode == "+") blr = floatingrate + variance;
			else if (varcode == "-") blr = floatingrate - variance;
			else blr = floatingrate;

			if (method == "0") 
			{	// Based Landing Rate (BLR)
				try 
				{
					retval = DMS.CuBESCore.Logic.hitungInstalment(limit, tenor, fixedrate, PRODUCTID, TENORCODE, conn);
				}
				catch(Exception)
				{
					retval = 0;
				}
			} 
			else
			{	// vary
				if (fixedrate != 0) 
				{ // hasil = (sukubunga/tenor) * (cplimit/100)// angka 100 untuk membagi sukubunga yang masih dalam persen 
					try 
					{
						retval = DMS.CuBESCore.Logic.hitungInstalment(limit, tenor, fixedrate, PRODUCTID, TENORCODE, conn);
					}
					catch (Exception) 
					{
						retval = 0;
					}
				}
				else 
				{
					try 
					{
						retval = DMS.CuBESCore.Logic.hitungInstalment(limit, tenor, blr, PRODUCTID, TENORCODE, conn);
					} 
					catch(Exception) 
					{
						retval = 0;
					}
				}
			}
			return retval;
		}

		/* method ini menghitung bunga yang harus dibayar saja */
		private double hitungInstallment()
		{	
			double retval = 0;
			double blr = 0;

			conn.QueryString  = "select INTERESTTYPE, ISNEGORATE, ALTRATECALC from RFPRODUCT ";
			conn.QueryString += "where PRODUCTID = '" + PRODUCTID + "'";
			conn.ExecuteQuery();
			
			string method = conn.GetFieldValue("ALTRATECALC"); // cara kalkulasi: BLR or VARY

			// mengeset cp_tenor dan limit
			conn.QueryString  = "select CP_TENORCODE from CUSTPRODUCT where ";
			conn.QueryString += "AP_REGNO = '" + AP_REGNO + "' and ";
			conn.QueryString += "APPTYPE = '" + APPTYPE + "' and ";
			conn.QueryString += "PRODUCTID = '" + PRODUCTID + "' and ";
			conn.QueryString += "PROD_SEQ = " + PROD_SEQ;
			//LBL_SERBA.Text = conn.QueryString;
			conn.ExecuteQuery();

			TENORCODE = conn.GetFieldValue("CP_TENORCODE");

			double limit = 0;
			try 
			{
				limit = double.Parse(GlobalTools.ConvertFloat(TXT_LIMIT.Text));
			}
			catch(Exception) { limit = 0;}

			int tenor = 0;
			double fixedrate = 0;
			double floatingrate = 0;
			double variance = 0;
			string varcode = "0";

			try 
			{
				tenor = Convert.ToInt32(TXT_TENOR.Text);
			} 
			catch (Exception) { tenor = 0; }
			try 
			{
				fixedrate = Convert.ToDouble(toStrBiasa(TXT_FIXEDRATE.Text));
			} 
			catch (Exception) { fixedrate = 0; }
			try 
			{
				floatingrate = Convert.ToDouble(toStrBiasa(TXT_FLOATINGRATE.Text));
			} 
			catch (Exception) { floatingrate = 0; }
			try 
			{
				variance = Convert.ToDouble(toStrBiasa(TXT_VARIANCE.Text));
			} 
			catch (Exception) { variance = 0; }
			try 
			{
				varcode = DDL_CODE.SelectedValue;
			} 
			catch (Exception) { varcode = " "; }

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
					if (TENORCODE == "M") {
						bunga = blr / 12; // 12 mendandakan jumlah bulan setahun
					} 
					else if (TENORCODE == "D") {
						bunga = blr / 365; // 12 mendandakan jumlah bulan setahun
					}
					retval = tenor * bunga * limit / 100; // 100 digunakan untuk menghilangkan tanda persen dari bunga
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
						if (TENORCODE == "M") 
						{
							bunga = fixedrate / 12; // 12 menandakan jumlah bulan setahun
						} 
						else if (TENORCODE == "D") 
						{
							bunga = fixedrate / 365; // 12 menandakan jumlah bulan setahun
						}
						retval = tenor * bunga * limit / 100; // 100 digunakan untuk menghilangkan tanda persen dari bunga
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
						if (TENORCODE == "M") {
							bunga = blr / 12; // 12 mendandakan jumlah bulan setahun
						} 
						else if (TENORCODE == "D") {
							bunga = blr / 365; // 12 mendandakan jumlah bulan setahun
						}
						retval = tenor * bunga * limit / 100; // 100 digunakan untuk menghilangkan tanda persen dari 
					} 
					catch(Exception) 
					{
						retval = 0;
					}
				}
			}
			return retval;
		}

		private void viewPresetAlternateRate()
		{
			DataTable RATE = new DataTable();
			DataRow datrow;
			RATE.Columns.Add(new DataColumn("SEQUENCE"));
			RATE.Columns.Add(new DataColumn("TENOR"));
			RATE.Columns.Add(new DataColumn("FIXEDRATE"));
			RATE.Columns.Add(new DataColumn("FLOATINGRATE"));
			RATE.Columns.Add(new DataColumn("VARCODE"));
			RATE.Columns.Add(new DataColumn("VARIANCE"));
			RATE.Columns.Add(new DataColumn("INSTALLMENT"));

			try 
			{
				conn.QueryString = "select * from ALTERNATERATE " + 
					"where AP_REGNO = '" + AP_REGNO + 
					"' and PRODUCTID = '" + PRODUCTID + 
					"' and PROD_SEQ = " + PROD_SEQ +
					" and ACCKIND = '0' order by " + LBL_SORT_EXP.Text + " " + LBL_SORT_TYPE.Text;
				//LBL_SERBA.Text = conn.QueryString;
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return;
			}

			try 
			{
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Server Error !");
				return;
			}

			DGR_ALTERNATERATE.Columns[7].Visible = false;
			DGR_ALTERNATERATE.Columns[8].Visible = false;

			//Response.Write(conn.QueryString);
			string ratefixed, ratefloat = "";
			for (int i =0; i < conn.GetRowCount(); i++) 
			{
				datrow = RATE.NewRow();
				datrow[0] = conn.GetFieldValue(i,"SEQUENCE"); //seq
				datrow[1] = conn.GetFieldValue(i,"TENOR"); //tenor
				//datrow[2] = GlobalTools.MoneyFormat(conn.GetFieldValue(i,"FIXEDRATE")); //fixed
				//datrow[3] = GlobalTools.MoneyFormat(conn.GetFieldValue(i,"FLOATINGRATE")); //floating
				ratefixed = conn.GetFieldValue(i,"FIXEDRATE");
				ratefloat = conn.GetFieldValue(i,"FLOATINGRATE");
				datrow[4] = conn.GetFieldValue(i,"VARCODE"); //varcode
				datrow[5] = GlobalTools.MoneyFormat(conn.GetFieldValue(i,"VARIANCE")); //variance
				datrow[6] = GlobalTools.MoneyFormat(conn.GetFieldValue(i,"INSTALLMENT")); //installment

				if ((ratefixed == "") || (ratefixed == null))
					datrow[2] = "";
				else if (Convert.ToSingle(ratefixed) > 0)
					datrow[2] = GlobalTools.MoneyFormat(ratefixed) + "%"; //fixed
				else datrow[2] = "";
				
				if ((ratefloat == "") || (ratefloat == null))
					datrow[3] = "";
				else if (Convert.ToSingle(ratefloat) > 0)
					datrow[3] = GlobalTools.MoneyFormat( ratefloat) + "%"; //floating
				else datrow[3] = "";

				datrow[4] = conn.GetFieldValue(i,"VARCODE"); //varcode
				if ((datrow[4].ToString() == "+") || (datrow[4].ToString() == "-"))
				{ // sudah benar
					datrow[5] = GlobalTools.MoneyFormat(conn.GetFieldValue(i,"VARIANCE")) + "%"; //variance
				} 
				else
				{
					datrow[5] = "";
				}
				
				if (LBL_ISINSTALLMENT.Text == "1")
				{ // jika installment maka jangan tampilkan nilai di kolom installment
					datrow[6] = "";
				}
				else if (LBL_NEGO.Text == "1")
				{
					//datrow[6] = "";
					datrow[6] = GlobalTools.MoneyFormat(conn.GetFieldValue(i,"INSTALLMENT")); //installment
				} else
				{
					//datrow[6] = "";
					datrow[6] = GlobalTools.MoneyFormat(conn.GetFieldValue(i,"INSTALLMENT")); //installment
				}

				RATE.Rows.Add(datrow);
			}
			DGR_ALTERNATERATE.DataSource = new DataView(RATE);
			DGR_ALTERNATERATE.DataBind();

		}

		private void updateViewTenor(string seq)
		{
			// untuk mode view preset alternate rate, acckind harus diset ke 0
			if ((LBL_NEGO.Text == "0") && (LBL_INTERESTTYPE.Text == "03"))
				ACCKIND = "0";

			conn.QueryString  = "select sum(TENOR) as TOTALTENOR from ALTERNATERATE ";
			conn.QueryString += "where AP_REGNO = '" + AP_REGNO + "' and ";
			conn.QueryString += "PRODUCTID = '" + PRODUCTID + "' and ";
			conn.QueryString += "ACCKIND = '" + ACCKIND + "' and ";
			conn.QueryString += "PROD_SEQ = '" + PROD_SEQ + "'";

			if (seq != "") conn.QueryString += " and SEQUENCE <> " + seq;

			conn.ExecuteQuery();
			string tenor = conn.GetFieldValue("TOTALTENOR").Trim();
			if ((tenor == "") || (tenor == null)) 
			{ // 
				TXT_OLD_TENOR.Text = "0";
				TXT_SUM_TENOR.Text = "0";
				LBL_SERBA.Text += "Null :" + TXT_OLD_TENOR.Text + " "; // + conn.QueryString;
			} 
			else
			{
				TXT_OLD_TENOR.Text = tenor;
				LBL_SERBA.Text += "Not Null :" + TXT_OLD_TENOR.Text + " "; // + conn.QueryString;
				//TXT_SUM_TENOR.Text = tenor;
				if (seq == "") TXT_SUM_TENOR.Text = tenor;
			}
		}

		private string toStrBiasa(string s)
		{
			s = s.Replace("%","");
			s = s.Replace(",00","");
			s = s.Replace(".","");
			s = s.Replace(",",".");
			return s;
		}
		
		private string toStrCurrency(string s)
		{ // masih salah
			string r = "";
			int pjstr = s.Length;
			while (pjstr > 3)
			{
				r = "." + s.Substring(pjstr-3, pjstr-1);
				pjstr -= 3;
				s = s.Substring(0,pjstr-1);
			}
			r = s + r + ",00";
			return r;
		}

		/* cek apakah total tenor melebihi jangka waktu 
		 * 
		 * */
		private bool isOutOfTenor(string addtenor, string sequence)
		{
			bool _r = false;
			conn.QueryString  = "select sum(TENOR) as TOTALTENOR from ALTERNATERATE ";
			conn.QueryString += "where AP_REGNO = '" + AP_REGNO + "' and ";
			conn.QueryString += "PRODUCTID = '" + PRODUCTID + "' and ";
			conn.QueryString += "ACCKIND = '" + ACCKIND + "' and ";
			conn.QueryString += "PROD_SEQ = '" + PROD_SEQ + "'";
			if (sequence != "")
			{ // mendakan status update, maka kondisi where harus ditambah
				conn.QueryString += " and SEQUENCE <> " + sequence;
			} 
			conn.ExecuteQuery();
			string acumtenor = conn.GetFieldValue("TOTALTENOR");
			if ((acumtenor == "") || (acumtenor == null)) acumtenor = "0";
			// total tenor setelah ditambah tenor yang akan dimasukkan ke dbase
			int sigmatenor = Convert.ToInt32(acumtenor) + Convert.ToInt32(addtenor);
			// periksa apa total tenor itu melebihi jangka waktu  di CUSTPRODUCT
			conn.QueryString  = "select CP_JANGKAWKT from CUSTPRODUCT where ";
			conn.QueryString += "AP_REGNO = '" + AP_REGNO + "' and ";
			conn.QueryString += "APPTYPE = '" + APPTYPE + "' and ";
			conn.QueryString += "PRODUCTID = '" + PRODUCTID + "' and ";
			conn.QueryString += "PROD_SEQ = " + PROD_SEQ;
			conn.ExecuteQuery();
			//Label1.Text = conn.QueryString;
			//Label1.Text = acumtenor + " +  " + conn.GetFieldValue("CP_JANGKAWKT");
			//Label1.Text += " " + sigmatenor.ToString();
			int jangkawaktu = Convert.ToInt32(conn.GetFieldValue("CP_JANGKAWKT"));

			if (sigmatenor > jangkawaktu)
			{
				//Label1.Text = acumtenor + " " + conn.GetFieldValue("CP_JANGKAWKT");
				Response.Write("<script language='javascript'>alert('Akumulasi tenor melebihi tenor produk!');</script>");
				_r = true;
			}
			return _r;
		}

		private void CalculateInstallment()
		{ // diambil dari PermohonanBaruNonCach.aspx.cs
			double result = 0;

			try
			{
				conn.QueryString = "select rate from vw_floatingrate where productid='" + PRODUCTID + "'";
				conn.ExecuteQuery();
				string rate = conn.GetFieldValue("RATE");

				if (LBL_ISINSTALLMENT.Text == "1")/* && (conn.GetFieldValue("calcmethod") == "Annuity")*/
				{
					result = DMS.CuBESCore.Logic.hitungInstalment(double.Parse(TXT_LIMIT.Text), int.Parse(TXT_CP_TENOR.Text), double.Parse(rate), PRODUCTID, TENORCODE, conn);
					TXT_INSTALLMENT.Text = tool.MoneyFormat(result.ToString());
					//LBL_SERBA.Text = toStrCurrency(TXT_INSTALLMENT.Text);
				}
				else if (LBL_ISINSTALLMENT.Text == "0")
				{
					TXT_INSTALLMENT.Text = "";
				}
			}
			catch
			{
			}
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{	
			if (!isInputValid()) return; // input tidak valid
			if (isOutOfTenor(TXT_TENOR.Text.Trim(),"")) return; // total tenor > jangka waktu

			//LBL_SERBA.Text = TXT_INSTALLMENT.Text + "-" + tool.ConvertFloat(TXT_INSTALLMENT.Text);
			double installment = 0;
			if (LBL_NEGO.Text != "1") 
			{// jika bukan negorate maka installment baru dihitung
				installment = calcInstallment(); //hitungInstallment();
			}

			try 
			{
				conn.QueryString = "exec DE_ALTERNATE_RATE " +
					"'" + AP_REGNO + "', '" + PRODUCTID + "', " + PROD_SEQ + ", " + ACCKIND +
					", " + TXT_SEQ.Text.Trim() + ", " + TXT_TENOR.Text.Trim() + 
					", " + tool.ConvertFloat(TXT_FIXEDRATE.Text.Trim()) + 
					", " + tool.ConvertFloat(TXT_FLOATINGRATE.Text.Trim()) + 
					", '" + DDL_CODE.SelectedValue + 
					"', " + tool.ConvertFloat(TXT_VARIANCE.Text.Trim()) + 
					", " + installment.ToString().Replace(".","").Replace(",",".") + 
					", '1'";
				conn.ExecuteNonQuery();
				//LBL_SERBA.Text = conn.QueryString;

				viewData();
				clearInput();
				updateViewTenor("");
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return;
			}
		}

		private void DGR_ALTERNATERATE_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			LBL_SORT_EXP.Text = e.SortExpression;
			if (LBL_SORT_TYPE.Text == "ASC") LBL_SORT_TYPE.Text = "DESC";
			else LBL_SORT_TYPE.Text = "ASC";

			viewData();
		}

		private void DGR_ALTERNATERATE_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (e.CommandName.ToString()) 
			{
				case "Delete":
					try 
					{
						conn.QueryString = "exec DE_ALTERNATE_RATE " +
							"'" + AP_REGNO + "', '" + PRODUCTID + "', " + PROD_SEQ + 
							", '" + ACCKIND + "', " + e.Item.Cells[0].Text + ", 0, 0, 0, '', 0, 0, '3'";

						conn.ExecuteNonQuery();
					} 
					catch (NullReferenceException) 
					{
						GlobalTools.popMessage(this, "Connection Error !");
						return;
					}		
					clearInput();
					viewData();
					updateViewTenor("");
					BTN_INSERT.Visible = true;
					BTN_UPDATE.Visible = false;
					BTN_CANCEL.Visible = false;

					break;

				case "Edit":
					BTN_INSERT.Visible = false;
					BTN_UPDATE.Visible = true;
					BTN_CANCEL.Visible = true;

					TXT_SEQ.Text = e.Item.Cells[0].Text; // sequence
					TXT_SEQ.ReadOnly = true;
					TXT_SEQ.BackColor = Color.Gainsboro;
					TXT_TENOR.Text = e.Item.Cells[1].Text;
					
					string temp = e.Item.Cells[2].Text.Trim().Replace("%","");
					try
					{
						if (Convert.ToSingle(temp) != 0)
							TXT_FIXEDRATE.Text = temp;
						else TXT_FIXEDRATE.Text = "";
					}
					catch(Exception) { TXT_FIXEDRATE.Text = ""; }
					LBL_SERBA.Text += temp + "=";

					temp = e.Item.Cells[3].Text.Trim().Replace("%","");
					LBL_SERBA.Text = temp;
					try
					{ 
						if (Convert.ToSingle(temp) != 0)
							TXT_FLOATINGRATE.Text = temp;
						else TXT_FLOATINGRATE.Text = "";
					} 
					catch(Exception) { TXT_FLOATINGRATE.Text = ""; }
					
					LBL_SERBA.Text += temp + "=";

					string code = e.Item.Cells[4].Text.Trim();
					if (code == "+")
					{
						DDL_CODE.SelectedValue = "+";
					}
					else if (code == "-")
					{
						DDL_CODE.SelectedValue = "-";
					}
					else
					{
						DDL_CODE.SelectedValue = " ";
					}
					LBL_SERBA.Text += code + "=";

					temp = e.Item.Cells[5].Text.Trim().Replace("%","");
					LBL_SERBA.Text += temp + "=END";
					try
					{ 
						TXT_VARIANCE.Text = "";
						if (Convert.ToSingle(temp) != 0)
							TXT_VARIANCE.Text = temp;
						else TXT_VARIANCE.Text = "";
					}
					catch(Exception) { TXT_VARIANCE.Text = ""; }

					temp = e.Item.Cells[6].Text.Trim();
					try
					{ 
						if (Convert.ToSingle(temp) != 0)
							TXT_INSTALLMENT.Text = temp;
						else TXT_INSTALLMENT.Text = "";
					} 
					catch(Exception) { TXT_INSTALLMENT.Text = ""; }

					updateViewTenor(TXT_SEQ.Text.Trim());
					break;

				case "Cancel":
					DGR_ALTERNATERATE.EditItemIndex = -1;
					viewData();
					break;

				case "Update":
					TextBox txt0 = (TextBox) e.Item.Cells[0].Controls[0]; // seq
					TextBox txt1 = (TextBox) e.Item.Cells[1].Controls[0]; // tenor
					TextBox txt2 = (TextBox) e.Item.Cells[2].Controls[0]; // fixed
					TextBox txt3 = (TextBox) e.Item.Cells[3].Controls[0]; // floating
					DropDownList ddl4 = (DropDownList) e.Item.Cells[4].Controls[1]; // varcode
					TextBox txt5 = (TextBox) e.Item.Cells[5].Controls[0]; // variance
					TextBox txt6 = (TextBox) e.Item.Cells[6].Controls[0]; // installment

					if (isOutOfTenor(txt1.Text.Trim(),txt0.Text.Trim())) return; // total tenor > jangka waktu

					conn.QueryString = "exec DE_ALTERNATE_RATE " + 
						"'" + AP_REGNO + "', '" + PRODUCTID + "', " + PROD_SEQ + ", '" + ACCKIND + 
						"', " + txt0.Text.Trim() + ", " + txt1.Text.Trim() + 
						", " + tool.ConvertFloat(txt2.Text.Replace("%","")) + //fixed
						", " + tool.ConvertFloat(txt3.Text.Replace("%","")) +  // floating
						", '" + ddl4.SelectedValue +  //varcode
						"', " + tool.ConvertFloat(txt5.Text.Trim()) + // variance
						", " + tool.ConvertFloat(txt6.Text.Trim()) + // installment
						", '2'"; // kode update = 2
					conn.ExecuteNonQuery();

					DGR_ALTERNATERATE.EditItemIndex = -1;
					viewData();
					break;
			}			
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			clearInput();
			TXT_SEQ.Text = "";
			TXT_SEQ.ReadOnly = false;
			
			TXT_SEQ.BackColor = Color.White;

			BTN_INSERT.Visible = true;
			BTN_UPDATE.Visible = false;
			BTN_CANCEL.Visible = false;
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			if (isOutOfTenor(TXT_TENOR.Text.Trim(), TXT_SEQ.Text)) return; // total tenor > jangka waktu

			try 
			{
				double installment = 0;
				if (LBL_ISINSTALLMENT.Text == "1")
				{ // jika produknya installment maka installmentnya baru dihitung
					installment = calcInstallment(); //hitungInstallment();
				}

				conn.QueryString = "exec DE_ALTERNATE_RATE " +
					"'" + AP_REGNO + "', '" + PRODUCTID + "', " + PROD_SEQ + ", '" + ACCKIND + 
					"', " + TXT_SEQ.Text.Trim() + ", " + TXT_TENOR.Text.Trim() + 
					", " + tool.ConvertFloat(TXT_FIXEDRATE.Text.Trim()) + 
					", " + tool.ConvertFloat(TXT_FLOATINGRATE.Text.Trim()) + 
					", '" + DDL_CODE.SelectedValue + 
					"', " + tool.ConvertFloat(TXT_VARIANCE.Text.Trim()) + 
					", " + installment.ToString().Replace(".","").Replace(",",".") + 
					", '2'";
				conn.ExecuteNonQuery();
				//LBL_SERBA.Text = conn.QueryString;

				viewData();
				clearInput();
				updateViewTenor("");
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return;
			}
			BTN_INSERT.Visible = true;
			BTN_UPDATE.Visible = false;
			BTN_CANCEL.Visible = false;
		}
	}
}
