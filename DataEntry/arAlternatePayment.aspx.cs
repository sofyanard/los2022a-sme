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
	/// Summary description for arAlternatePayment.
	/// </summary>
	public partial class arAlternatePayment : System.Web.UI.Page
	{
	
		#region " Variables "

			private Connection conn;
			private Tools tool = new Tools();
			private string AP_REGNO, CU_REF, APPTYPE, PRODUCTID, PROD_SEQ, VIEW;

		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			AP_REGNO	= Request.QueryString["regno"];
			CU_REF		= Request.QueryString["curef"];
			APPTYPE		= Request.QueryString["apptype"];
			PRODUCTID	= Request.QueryString["prodid"];
			PROD_SEQ	= Request.QueryString["prodseq"];
			VIEW		= Request.QueryString["view"];

			if (!IsPostBack) 
			{
				try
				{
					conn.QueryString  = "select ISNEGORATE, INTERESTTYPE, ISINSTALLMENT from RFPRODUCT ";
					conn.QueryString += "where PRODUCTID = '" + PRODUCTID + "'";
					conn.ExecuteQuery();
					LBL_NEGO.Text = conn.GetFieldValue("ISNEGORATE");
					LBL_IS_INSTALLMENT.Text = conn.GetFieldValue("ISINSTALLMENT");
					LBL_INTERESTTYPE.Text = conn.GetFieldValue("INTERESTTYPE");
					//Response.Write("<script language='javascript'>alert('NEGO: " + LBL_NEGO.Text + "');</script>");
					
					initializePage(); // menampilkan max tenor dan tenor yang terpakai
					/*if (!((LBL_NEGO.Text == "1") && (LBL_INTERESTTYPE.Text == "03")))
					{ // bukan negorate, DISABLE semua
						disableForm();
					}*/
 
					DDL_PAYCODE.Items.Clear();
					DDL_PAYCODE.Items.Add("");
					DDL_PAYCODE.Items.Add("Pokok");
					DDL_PAYCODE.Items.Add("Bunga");

					viewData(); // tampilkan data
				}
				catch
				{
					Response.Write("<script language='javascript'>alert('" + conn.QueryString + "');</script>");
				}
			}

			/// Men-disable field/input
			/// 
			secureData();			
		}

		private void secureData() 
		{
			/// kalau passed-query "de" <> "1", maka disable semua field/input
			/// 
			if (Request.QueryString["de"] != "1") disableForm();
		}

		private void disableForm()
		{
			TXT_SEQ_MONTH.Enabled = false;
			TXT_PERCENTAGE.Enabled = false;
			TXT_DRAWDOWN_AMOUNT.Enabled = false;
			TXT_ALTERNATE_PAYMENT.Enabled = false;
			TXT_CATATAN.Enabled = false;
			DDL_PAYCODE.Enabled = false;

			TXT_SEQ_MONTH.BackColor = Color.Gainsboro;
			TXT_PERCENTAGE.BackColor = Color.Gainsboro;
			TXT_DRAWDOWN_AMOUNT.BackColor = Color.Gainsboro;
			TXT_ALTERNATE_PAYMENT.BackColor = Color.Gainsboro;
			TXT_CATATAN.BackColor = Color.Gainsboro;
			DDL_PAYCODE.BackColor = Color.Gainsboro;

			BTN_INSERT.Enabled = false;
		}

		private void initializePage()
		{
			// ambil SP_LIMIT di CUSTPRODUCT
			conn.QueryString  = "select CP_LIMIT from CUSTPRODUCT where ";
			conn.QueryString += "AP_REGNO = '" + AP_REGNO + "' and ";
			conn.QueryString += "APPTYPE = '" + APPTYPE + "' and ";
			conn.QueryString += "PRODUCTID = '" + PRODUCTID + "' and ";
			conn.QueryString += "PROD_SEQ = " + PROD_SEQ;
			conn.ExecuteQuery();

			// nilai cp_limit disimpan di sebagai value dari objek TXT_LIMIT
			TXT_LIMIT.Text = conn.GetFieldValue("CP_LIMIT").ToString();
				
			string datacol = "DRAWDOWN_AMOUNT";
			if (RBL_AP_DDS.SelectedValue == "AP") datacol = "ALTERNATE_PAYMENT";
			else datacol = "DRAWDOWN_AMOUNT";

			conn.QueryString = "";
			conn.QueryString  = "select sum(" + datacol + ") as AP_DDS from ALTERNATEPAYMENT where ";
			conn.QueryString += "AP_REGNO = '" + AP_REGNO + "' and ";
			conn.QueryString += "PRODUCTID = '" + PRODUCTID + "' and ";
			conn.QueryString += "PROD_SEQ = " + PROD_SEQ + " and ";
			conn.QueryString += "MODE = '" + RBL_AP_DDS.SelectedValue + "'";
			conn.ExecuteQuery();
			QUERY.Text = conn.QueryString;

			// total drawdown atau total alternate payment
			TXT_AP_DDS.Text = conn.GetFieldValue("AP_DDS"); // berubah sesuai yang ditambah
			TXT_AP_DDS_BEFORE.Text = conn.GetFieldValue("AP_DDS");
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
			this.DGR_ALTERNATEPAYMENT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_ALTERNATEPAYMENT_ItemCommand);
			this.DGR_ALTERNATEPAYMENT.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DGR_ALTERNATEPAYMENT_SortCommand);

		}
		#endregion

		private void viewData() 
		{
			if (LBL_NEGO.Text == "0")
			{
				try 
				{
					conn.QueryString = "select top 1 * from ALTERNATEPAYMENT where AP_REGNO = '000'";
					conn.ExecuteQuery();
				}
				catch(Exception)
				{
					GlobalTools.popMessage(this, "Connection Error !");
					return;
				}
				DGR_ALTERNATEPAYMENT.DataSource = conn.GetDataTable().DefaultView;
				try 
				{
					DGR_ALTERNATEPAYMENT.DataBind();
				}
				catch 
				{
					DGR_ALTERNATEPAYMENT.CurrentPageIndex = 0;
					DGR_ALTERNATEPAYMENT.DataBind();
				}
			}

			try 
			{
				conn.QueryString  = "select * from ALTERNATEPAYMENT where ";
				conn.QueryString += "AP_REGNO = '" + AP_REGNO + "' and ";
				conn.QueryString += "PRODUCTID = '" + PRODUCTID + "' and ";
				conn.QueryString += "PROD_SEQ = " + PROD_SEQ + " and ";
				conn.QueryString += "MODE = '" + RBL_AP_DDS.SelectedValue + "' ";
				conn.QueryString += "order by " + LBL_COL_SORT.Text + " " + LBL_SORT_TYPE.Text;
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return;
			}

			DGR_ALTERNATEPAYMENT.DataSource = conn.GetDataTable().DefaultView;
			try 
			{
				DGR_ALTERNATEPAYMENT.DataBind();
			}
			catch 
			{
				DGR_ALTERNATEPAYMENT.CurrentPageIndex = 0;
				DGR_ALTERNATEPAYMENT.DataBind();
			}
		}

		private string updateAP_DDS_BEFORE(string seq)
		{
			string _r = "";

			string datacol = "DRAWDOWN_AMOUNT";
			if (RBL_AP_DDS.SelectedValue == "AP") datacol = "ALTERNATE_PAYMENT";
			else datacol = "DRAWDOWN_AMOUNT";

			conn.QueryString  = "select sum(" + datacol + ") as AP_DDS from ALTERNATEPAYMENT where ";
			conn.QueryString += "AP_REGNO = '" + AP_REGNO + "' and ";
			conn.QueryString += "PRODUCTID = '" + PRODUCTID + "' and ";
			conn.QueryString += "PROD_SEQ = " + PROD_SEQ + " and ";
			conn.QueryString += "MODE = '" + RBL_AP_DDS.SelectedValue + "'";

			if (seq != "") conn.QueryString += " and SEQ_MONTH <> " + seq;

			conn.ExecuteQuery();
			TXT_AP_DDS_BEFORE.Text = conn.GetFieldValue("AP_DDS").ToString();
			_r = TXT_AP_DDS_BEFORE.Text;
			QUERY.Text = conn.QueryString;
			return _r;
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

			if (TXT_SEQ_MONTH.Text == "") 
			{ // seq_month tidak diisi
				Response.Write("<script language='javascript'>alert('Kolom Nth Month tidak boleh kosong!');</script>");
				return false;
			}

			if (invalidComma(TXT_PERCENTAGE.Text))
			{
				return false;
			}
			if (TXT_DRAWDOWN_AMOUNT.Enabled && ((TXT_DRAWDOWN_AMOUNT.Text.Replace(",00", "") == "0") || (TXT_DRAWDOWN_AMOUNT.Text == "")))
			{ // drawdown tidak diisi
				Response.Write("<script language='javascript'>alert('Kolom Draw Down tidak boleh bernilai 0!');</script>");
				return false;
			}
			else if (TXT_ALTERNATE_PAYMENT.Enabled && ((TXT_ALTERNATE_PAYMENT.Text.Replace(",00", "") == "0") || (TXT_ALTERNATE_PAYMENT.Text == "")))
			{
				Response.Write("<script language='javascript'>alert('Kolom Alternate Payment tidak boleh bernilai 0!');</script>");
				return false;
			}
			// checking sequence input
			try 
			{
				conn.QueryString = "select * from ALTERNATEPAYMENT " + 
					"where AP_REGNO = '" + AP_REGNO + 
					"' and PRODUCTID = '" + PRODUCTID + 
					"' and PROD_SEQ = " + PROD_SEQ +
					" and SEQ_MONTH = '" + TXT_SEQ_MONTH.Text +
					"' and MODE = '" + RBL_AP_DDS.SelectedValue + "'";
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
			TXT_SEQ_MONTH.Text = "";
			TXT_PERCENTAGE.Text = "";
			TXT_DRAWDOWN_AMOUNT.Text = "";
			TXT_ALTERNATE_PAYMENT.Text = "";
			TXT_CATATAN.Text = "";
			DDL_PAYCODE.SelectedIndex = 0;
		}

		/* cek apakah total pententage > 100%
		 * 
		 * */
		private bool isOutOfPercentage(string addPercent, string seqMonth)
		{
			bool _r = false;

			addPercent.Replace("%",""); // menghilangkan lambang persen jika ada

			conn.QueryString  = "select sum(PERCENTAGE) as PERSEN from ALTERNATEPAYMENT ";
			conn.QueryString += "where AP_REGNO = '" + AP_REGNO + "' and ";
			conn.QueryString += "PRODUCTID = '" + PRODUCTID + "' and ";
			conn.QueryString += "PROD_SEQ = " + PROD_SEQ + " and ";
			conn.QueryString += "MODE = '" + RBL_AP_DDS.SelectedValue + "'";
			if (seqMonth != "")
			{ // mendakan status update, maka kondisi where harus ditambah
				conn.QueryString += " and SEQ_MONTH <> " + seqMonth;
			} 
			conn.ExecuteQuery();
			string strPercent = conn.GetFieldValue("PERSEN"); // akumulasi persentase dari basis data
			float totalPercentage = Convert.ToSingle(strPercent) + Convert.ToSingle(addPercent);

			if (totalPercentage > 100)
			{ // mengecek apakah total percentage > 100 apa tidak
				Response.Write("<script language='javascript'>alert('Akumulasi draw down melebihi limit!');</script>");
				_r = true;
			}
			return _r;
		}

		/*
		 * mengecek apakah total drawdown melebihi amount
		 * */
		private bool isOverLimit(string addData, string seqMonth)
		{
			bool _r = false;

			string datacol = "DRAWDOWN_AMOUNT";
			if (RBL_AP_DDS.SelectedValue == "AP") datacol = "ALTERNATE_PAYMENT";

			//addData = addData.Replace(".",""); // 1.000,00 -> 1000,00 
			//addData = addData.Replace(",","."); // 1000,00 -> 1000.00
			// ambil total drawdown sebelumnya yang ada di database
			conn.QueryString  = "select sum(" + datacol + ") as AMOUNT from ALTERNATEPAYMENT ";
			conn.QueryString += "where AP_REGNO = '" + AP_REGNO + "' and ";
			conn.QueryString += "PRODUCTID = '" + PRODUCTID + "' and ";
			conn.QueryString += "PROD_SEQ = " + PROD_SEQ + " and ";
			conn.QueryString += "MODE = '" + RBL_AP_DDS.SelectedValue + "'";
			
			if (seqMonth != "")
			{ // menandakan status update, maka kondisi where harus ditambah dimana drawdown yang diupdate tidak dikut dipilih
				conn.QueryString += " and SEQ_MONTH <> " + seqMonth;
			} 
			conn.ExecuteQuery();
			
			string strAmount = conn.GetFieldValue("AMOUNT"); // akumulasi persentase dari basis data
			if ((strAmount == "") || (strAmount == null)) strAmount = "0";
			//strAmount = strAmount.Replace(",","."); //ubah pemisah desimal menjadi titik

			double totalAmount = Convert.ToDouble(strAmount) + Convert.ToDouble(addData);
			QUERY.Text = strAmount + " " + Convert.ToDouble(strAmount).ToString() + 
				" " + Convert.ToDouble(addData).ToString() + " " + totalAmount.ToString();

			// periksa apa total drawdown/payment melebihi jangka waktu  di CUSTPRODUCT
			conn.QueryString  = "select CP_EXLIMITVAL from CUSTPRODUCT where ";
			conn.QueryString += "AP_REGNO = '" + AP_REGNO + "' and ";
			conn.QueryString += "APPTYPE = '" + APPTYPE + "' and ";
			conn.QueryString += "PRODUCTID = '" + PRODUCTID + "' and ";
			conn.QueryString += "PROD_SEQ = " + PROD_SEQ;
			conn.ExecuteQuery();

			double limit = Convert.ToDouble(tool.ConvertFloat(conn.GetFieldValue("CP_EXLIMITVAL")));
			QUERY.Text += " lim " + limit.ToString();

			if (totalAmount > limit)
			{ // mengecek apakah total drawdown > limit apa tidak
				Response.Write("<script language='javascript'>alert('Akumulasi " + datacol + " melebihi limit!');</script>");
				_r = true;
			}
			return _r;
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			if (!isInputValid()) return;
			if (RBL_AP_DDS.SelectedValue == "DDS") { // draw down schedule mode
				if (isOverLimit(TXT_DRAWDOWN_AMOUNT.Text,"")) return;
			} else {
				if (isOverLimit(TXT_ALTERNATE_PAYMENT.Text,"")) return;
			}
			// menyimpan sementara nilai akumuladi DDS atau AP
			try 
			{
				if (RBL_AP_DDS.SelectedValue == "DDS")
				{ // mode: Draw Down Schedule
					conn.QueryString = "exec DE_ALTERNATE_PAYMENT ";
					conn.QueryString += "'" + AP_REGNO + "', '" + PRODUCTID + "', ";
					conn.QueryString += PROD_SEQ + ", '" + TXT_SEQ_MONTH.Text + "', ";
					conn.QueryString += tool.ConvertFloat(TXT_PERCENTAGE.Text) + ", ";
					conn.QueryString += tool.ConvertFloat(TXT_DRAWDOWN_AMOUNT.Text) + ", ";
					conn.QueryString += "'DDS', '1', null, null";
				}
				else
				{ // mode insert Alternate Payment
					string strpay = TXT_ALTERNATE_PAYMENT.Text.Replace(".","");
					strpay.Replace(",",".");
					double payment = Convert.ToDouble(strpay);
					double limit   = Convert.ToDouble(tool.ConvertFloat(TXT_LIMIT.Text));
					double percent = (payment / limit) * 100;
					string percentage = percent.ToString();

					conn.QueryString = "exec DE_ALTERNATE_PAYMENT ";
					conn.QueryString += "'" + AP_REGNO + "', '" + PRODUCTID + "', ";
					conn.QueryString += PROD_SEQ + ", '" + TXT_SEQ_MONTH.Text + "', ";
					conn.QueryString += percentage.Replace(",",".") + ", ";
					conn.QueryString += tool.ConvertFloat(TXT_ALTERNATE_PAYMENT.Text) + ", ";
					conn.QueryString += "'AP', '1','" + DDL_PAYCODE.SelectedValue + "','" + TXT_CATATAN.Text + "'";
					QUERY.Text = percentage + " " + conn.QueryString;
				}
				conn.ExecuteNonQuery();
				TXT_AP_DDS.Text = updateAP_DDS_BEFORE("");
				viewData();
				clearInput(); // clear input form
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return;
			}
		}

		private void DGR_ALTERNATEPAYMENT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (e.CommandName.ToString()) 
			{
				case "Delete":
					try 
					{
						//conn.QueryString = "exec DE_ALTERNATE_PAYMENT '" + AP_REGNO + "', '', '" + e.Item.Cells[0].Text + "', '', '', '', '3'";

						conn.QueryString = "exec DE_ALTERNATE_PAYMENT ";
						conn.QueryString += "'" + AP_REGNO + "', '" + PRODUCTID + "', " + PROD_SEQ;
						conn.QueryString += ", '" + e.Item.Cells[0].Text + "', 0, 0, '" + RBL_AP_DDS.SelectedValue + "', '3', null, null";
						conn.ExecuteNonQuery();

						BTN_INSERT.Visible = true;
						BTN_UPDATE.Visible = false;
						BTN_CANCEL.Visible = false;

						TXT_SEQ_MONTH.Text = "";
						TXT_SEQ_MONTH.ReadOnly = false;
						TXT_SEQ_MONTH.BackColor = Color.White;
						TXT_PERCENTAGE.Text = "";
						TXT_DRAWDOWN_AMOUNT.Text = "";
						TXT_ALTERNATE_PAYMENT.Text = "";
						if (RBL_AP_DDS.SelectedValue == "DDS")
						{
							TXT_ALTERNATE_PAYMENT.Enabled = false;
							TXT_DRAWDOWN_AMOUNT.Enabled = true;
						} 
						else
						{
							TXT_DRAWDOWN_AMOUNT.Enabled = false;
							TXT_ALTERNATE_PAYMENT.Enabled = true;
						}
						TXT_AP_DDS.Text = updateAP_DDS_BEFORE("");
						viewData();
					} 
					catch (NullReferenceException) 
					{
						GlobalTools.popMessage(this, "Connection Error !");
						return;
					}					
					break;

				case "Edit":
					//DGR_ALTERNATEPAYMENT.EditItemIndex = e.Item.ItemIndex;
					BTN_INSERT.Visible = false;
					BTN_UPDATE.Visible = true;
					BTN_CANCEL.Visible = true;
					//meload nilai sequence ke TXT_SEQ_MONTH
					TXT_SEQ_MONTH.ReadOnly = true;
					TXT_SEQ_MONTH.BackColor = Color.Gainsboro;
					TXT_SEQ_MONTH.Text = e.Item.Cells[0].Text;

					// mode Draw Down Schedule
					if (RBL_AP_DDS.SelectedValue == "DDS")
					{
						TXT_PERCENTAGE.Text = e.Item.Cells[1].Text.Replace("%","");
						TXT_DRAWDOWN_AMOUNT.Text = e.Item.Cells[2].Text;
						TXT_ALTERNATE_PAYMENT.Enabled = false;
						if(e.Item.Cells[5].Text == "&nbsp;")
							TXT_CATATAN.Text = "";
						else
							TXT_CATATAN.Text = e.Item.Cells[5].Text;
						if(e.Item.Cells[4].Text == "&nbsp;")
							DDL_PAYCODE.SelectedValue = "";
						else
							DDL_PAYCODE.SelectedValue = e.Item.Cells[4].Text;
					}
					else
					{ // mode Alternate Payment
						TXT_PERCENTAGE.Text = e.Item.Cells[1].Text.Replace("%","");
						TXT_ALTERNATE_PAYMENT.Text = e.Item.Cells[3].Text;
						TXT_DRAWDOWN_AMOUNT.Enabled = false;
						if(e.Item.Cells[5].Text == "&nbsp;")
							TXT_CATATAN.Text = "";
						else
							TXT_CATATAN.Text = e.Item.Cells[5].Text;
						if(e.Item.Cells[4].Text == "&nbsp;")
							DDL_PAYCODE.SelectedValue = "";
						else
							DDL_PAYCODE.SelectedValue = e.Item.Cells[4].Text;

					}
					TXT_AP_DDS.Text = updateAP_DDS_BEFORE(TXT_SEQ_MONTH.Text.Trim());
					break;

				case "Cancel":
					DGR_ALTERNATEPAYMENT.EditItemIndex = -1;
					viewData();
					break;

				case "Update":
					TextBox txt0 = (TextBox) e.Item.Cells[0].Controls[0]; // sequence
					TextBox txt1 = (TextBox) e.Item.Cells[1].Controls[0]; // percentage
					TextBox txt2 = (TextBox) e.Item.Cells[2].Controls[0]; // drawdown
					TextBox txt3 = (TextBox) e.Item.Cells[3].Controls[0]; // alternate payment
					DropDownList txt4 = (DropDownList) e.Item.Cells[4].Controls[0]; // alternate payment
					TextBox txt5 = (TextBox) e.Item.Cells[5].Controls[0]; // alternate payment

					if (isOverLimit(txt1.Text, txt0.Text)) return;
					if (RBL_AP_DDS.SelectedValue == "DDS")
					{
						conn.QueryString = "exec DE_ALTERNATE_PAYMENT ";
						conn.QueryString += "'" + AP_REGNO + "', '" + PRODUCTID + "', ";
						conn.QueryString += PROD_SEQ + ", '" + txt0.Text.Trim() + "', ";
						conn.QueryString += tool.ConvertFloat(txt1.Text.Replace("%","")) + ", ";
						conn.QueryString += tool.ConvertFloat(txt2.Text.Trim()) + ", ";
						conn.QueryString += "'DDS', '2', null,null";
					}
					else
					{
						conn.QueryString = "exec DE_ALTERNATE_PAYMENT ";
						conn.QueryString += "'" + AP_REGNO + "', '" + PRODUCTID + "', ";
						conn.QueryString += PROD_SEQ + ", '" + txt0.Text.Trim() + "', ";
						conn.QueryString += tool.ConvertFloat(txt1.Text.Replace("%","")) + ", ";
						conn.QueryString += tool.ConvertFloat(txt3.Text.Trim()) + ", ";
						conn.QueryString += "'AP', '2','" + DDL_PAYCODE.SelectedValue + "','" + TXT_CATATAN.Text + "'";
					}
					conn.ExecuteNonQuery();

					DGR_ALTERNATEPAYMENT.EditItemIndex = -1;
					TXT_AP_DDS.Text = updateAP_DDS_BEFORE("");
					viewData();
					break;
			}
		}

		private void DGR_ALTERNATEPAYMENT_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			if (LBL_SORT_TYPE.Text == "ASC") LBL_SORT_TYPE.Text = "DESC";
			else LBL_SORT_TYPE.Text = "ASC";

			LBL_COL_SORT.Text = e.SortExpression;

			viewData();
		}

		protected void RBL_AP_DDS_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// pengaktifan tombol
			BTN_INSERT.Visible = true;
			BTN_UPDATE.Visible = false;
			BTN_CANCEL.Visible = false;

			// ubah MODE
			if (LBL_SELECT.Text == "DDS") LBL_SELECT.Text = "AP";
			else LBL_SELECT.Text = "DDS";

			if (TXT_SELECT.Text == "DDS") TXT_SELECT.Text = "AP";
			else TXT_SELECT.Text = "DDS";
											  
//			if ((LBL_NEGO.Text == "1") && (LBL_INTERESTTYPE.Text == "03"))
//			{	//jika negotiable
				if (RBL_AP_DDS.SelectedValue == "DDS")
				{ // MODE: Draw Down Shedule, tidak peduli installment apa bukan
					TXT_SEQ_MONTH.Text = "";
					TXT_SEQ_MONTH.ReadOnly = false;
					TXT_SEQ_MONTH.BackColor = Color.White;
					TXT_PERCENTAGE.Text = "";
					TXT_PERCENTAGE.Enabled = true;
					TXT_PERCENTAGE.BackColor = Color.White;
					TXT_DRAWDOWN_AMOUNT.Text = "";
					TXT_DRAWDOWN_AMOUNT.Enabled = true;
					TXT_DRAWDOWN_AMOUNT.BackColor = Color.White;
					TXT_DRAWDOWN_AMOUNT.ForeColor = Color.Black;
					TXT_ALTERNATE_PAYMENT.Text = "";
					TXT_ALTERNATE_PAYMENT.Enabled = false;
					TXT_ALTERNATE_PAYMENT.BackColor = Color.Gainsboro;
					TXT_ALTERNATE_PAYMENT.ForeColor = Color.Gainsboro;
					TXT_CATATAN.Enabled = false;
					TXT_CATATAN.BackColor = Color.Gainsboro;
					TXT_CATATAN.Text = "";
					DDL_PAYCODE.Enabled = false;
					DDL_PAYCODE.BackColor = Color.Gainsboro;
					DDL_PAYCODE.SelectedValue = "";

				}			
				else 
				{ // MODE: ALTERNATE PAYMENT
					if (LBL_IS_INSTALLMENT.Text == "1")
					{ // jika perlu hitung installment, alternate payment di-disabled
						TXT_SEQ_MONTH.Text = "";
						TXT_SEQ_MONTH.ReadOnly = true;
						TXT_SEQ_MONTH.BackColor = Color.Gainsboro;
						TXT_PERCENTAGE.Text = "";
						TXT_PERCENTAGE.Enabled = false;
						TXT_PERCENTAGE.BackColor = Color.Gainsboro;
						TXT_DRAWDOWN_AMOUNT.Text = "";
						TXT_DRAWDOWN_AMOUNT.Enabled = false;
						TXT_DRAWDOWN_AMOUNT.BackColor = Color.Gainsboro;
						TXT_ALTERNATE_PAYMENT.Text = "";
						TXT_ALTERNATE_PAYMENT.Enabled = false;
						TXT_ALTERNATE_PAYMENT.BackColor = Color.Gainsboro;
						TXT_CATATAN.Enabled = true;
						TXT_CATATAN.BackColor = Color.White;
						DDL_PAYCODE.Enabled = true;
						DDL_PAYCODE.BackColor = Color.White;
					} 
					else
					{ // jika tidak perlu hitung installment maka dibolehkan pakai alternate payment
						TXT_SEQ_MONTH.Text = "";
						TXT_SEQ_MONTH.ReadOnly = false;
						TXT_SEQ_MONTH.BackColor = Color.White;
						TXT_PERCENTAGE.Text = "";
						TXT_PERCENTAGE.Enabled = true;
						TXT_PERCENTAGE.BackColor = Color.White;
						TXT_DRAWDOWN_AMOUNT.Text = "";
						TXT_DRAWDOWN_AMOUNT.Enabled = false;
						TXT_DRAWDOWN_AMOUNT.BackColor = Color.Gainsboro;
						TXT_ALTERNATE_PAYMENT.Text = "";
						TXT_ALTERNATE_PAYMENT.Enabled = true;
						TXT_ALTERNATE_PAYMENT.ForeColor = Color.Black;
						TXT_ALTERNATE_PAYMENT.BackColor = Color.White;
						TXT_CATATAN.Enabled = true;
						TXT_CATATAN.BackColor = Color.White;
						DDL_PAYCODE.Enabled = true;
						DDL_PAYCODE.BackColor = Color.White;
					}
				}
//			}
			TXT_AP_DDS.Text = updateAP_DDS_BEFORE("");
			viewData();
		}

		private void disableDrawDown()
		{
			TXT_SEQ_MONTH.Text = "";
			TXT_SEQ_MONTH.ReadOnly = true;
			TXT_SEQ_MONTH.BackColor = Color.Gainsboro;
			TXT_PERCENTAGE.Text = "";
			TXT_PERCENTAGE.Enabled = false;
			TXT_PERCENTAGE.BackColor = Color.Gainsboro;
			TXT_DRAWDOWN_AMOUNT.Text = "";
			TXT_DRAWDOWN_AMOUNT.Enabled = false;
			TXT_DRAWDOWN_AMOUNT.BackColor = Color.Gainsboro;
			TXT_DRAWDOWN_AMOUNT.ForeColor = Color.Black;
			TXT_ALTERNATE_PAYMENT.Text = "";
			TXT_ALTERNATE_PAYMENT.Enabled = false;
			TXT_ALTERNATE_PAYMENT.BackColor = Color.Gainsboro;
			TXT_ALTERNATE_PAYMENT.ForeColor = Color.Gainsboro;
			TXT_CATATAN.Text = "";
			TXT_CATATAN.ReadOnly = false;
			TXT_CATATAN.BackColor = Color.Gainsboro;
			DDL_PAYCODE.SelectedValue = "";
			DDL_PAYCODE.Enabled = false;
			DDL_PAYCODE.BackColor = Color.Gainsboro;
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			if (RBL_AP_DDS.SelectedValue == "DDS") // draw down schedule mode
			{
				if (isOverLimit(TXT_DRAWDOWN_AMOUNT.Text,TXT_SEQ_MONTH.Text)) return;
			} else {
				if (isOverLimit(TXT_ALTERNATE_PAYMENT.Text,TXT_SEQ_MONTH.Text)) return;
			}

			try 
			{
				if (RBL_AP_DDS.SelectedValue == "DDS")
				{ // mode: Draw Down Schedule
					conn.QueryString = "exec DE_ALTERNATE_PAYMENT ";
					conn.QueryString += "'" + AP_REGNO + "', '" + PRODUCTID + "', ";
					conn.QueryString += PROD_SEQ + ", '" + TXT_SEQ_MONTH.Text + "', ";
					conn.QueryString += tool.ConvertFloat(TXT_PERCENTAGE.Text.Replace("%","")) + ", ";
					conn.QueryString += tool.ConvertFloat(TXT_DRAWDOWN_AMOUNT.Text.Trim()) + ", ";
					conn.QueryString += "'DDS', '2', null, null";
				}
				else
				{ // mode insert Alternate Payment
					string strpay = TXT_ALTERNATE_PAYMENT.Text.Replace(".","");
					strpay.Replace(",",".");
					double payment = Convert.ToDouble(strpay);
					double limit   = Convert.ToDouble(tool.ConvertFloat(TXT_LIMIT.Text));
					double percent = (payment / limit) * 100;
					string percentage = percent.ToString();

					conn.QueryString = "exec DE_ALTERNATE_PAYMENT ";
					conn.QueryString += "'" + AP_REGNO + "', '" + PRODUCTID + "', ";
					conn.QueryString += PROD_SEQ + ", '" + TXT_SEQ_MONTH.Text + "', ";
					conn.QueryString += percentage.Replace(",",".") + ", ";
					conn.QueryString += tool.ConvertFloat(TXT_ALTERNATE_PAYMENT.Text.Trim()) + ", ";
					conn.QueryString += "'AP', '2','" + DDL_PAYCODE.SelectedValue + "','" + TXT_CATATAN.Text + "'";
				}
				conn.ExecuteNonQuery();
				TXT_AP_DDS.Text = updateAP_DDS_BEFORE("");
				viewData();
				clearInput(); // clear input form
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return;
			}

			TXT_SEQ_MONTH.ReadOnly = false;
			TXT_SEQ_MONTH.BackColor = Color.White;
			BTN_INSERT.Visible = true;
			BTN_UPDATE.Visible = false;
			BTN_CANCEL.Visible = false;
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			BTN_INSERT.Visible = true;
			BTN_UPDATE.Visible = false;
			BTN_CANCEL.Visible = false;

			TXT_SEQ_MONTH.Text = "";
			TXT_PERCENTAGE.Text = "";
			TXT_DRAWDOWN_AMOUNT.Text = "";
			TXT_ALTERNATE_PAYMENT.Text = "";
			TXT_SEQ_MONTH.ReadOnly = false;
			TXT_SEQ_MONTH.BackColor = Color.White;
			if (RBL_AP_DDS.SelectedValue == "DDS")
			{
				TXT_ALTERNATE_PAYMENT.Enabled = false;
				TXT_DRAWDOWN_AMOUNT.Enabled = true;
				TXT_CATATAN.Enabled = false;
				DDL_PAYCODE.Enabled = false;
			} 
			else
			{
				TXT_DRAWDOWN_AMOUNT.Enabled = false;
				TXT_ALTERNATE_PAYMENT.Enabled = true;
				TXT_CATATAN.Enabled = true;
				DDL_PAYCODE.Enabled = true;
			}
		}
	}
}
