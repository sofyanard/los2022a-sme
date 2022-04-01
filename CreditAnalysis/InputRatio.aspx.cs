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

namespace SME.CreditAnalysis
{
	/// <summary>
	/// Summary description for InputRatio.
	/// </summary>
	public partial class InputRatio : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				ViewDataProyeksi();
			}
			SecureData();
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

		private void SecureData() 
		{
			string ca = Request.QueryString["ca"];

			if (ca == "0")
			{
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for (int i = 0; i < coll[1].Controls.Count; i++) 
				{
					if (coll[1].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[1].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[1].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[1].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[1].Controls[i] is Button)
					{
						Button btn = (Button) coll[1].Controls[i];
						btn.Visible = false;
					}
					else if (coll[1].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[1].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[1].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[1].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[1].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[1].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[1].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[1].Controls[i];

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
		// 

		private void ViewDataProyeksi()
		{
			conn.QueryString = "select * from APP_PROYEKSIRATIO where AP_REGNO = '" +Request.QueryString["regno"]+ "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("PR_YEAR1").ToString().Trim() == "")
			{
				int NEXTYEAR = DateTime.Now.Year - 1;
				TXT_PR_YEAR1.Text	= NEXTYEAR.ToString();
			}
			else
				TXT_PR_YEAR1.Text	= conn.GetFieldValue("PR_YEAR1");
			
			if (conn.GetFieldValue("PR_YEAR2").ToString().Trim() == "")
				TXT_PR_YEAR2.Text	= DateTime.Now.Year.ToString();
			else
				TXT_PR_YEAR2.Text	= conn.GetFieldValue("PR_YEAR2");
			
			TXT_PR_NPV.Text				= setDigit(conn.GetFieldValue("PR_NPV").ToString().Replace(",","."),2,".");
			TXT_PR_IRR.Text				= setDigit(conn.GetFieldValue("PR_IRR").ToString().Replace(",","."),2,".");
			TXT_PR_PAYBACK.Text			= setDigit(conn.GetFieldValue("PR_PAYBACK").ToString().Replace(",","."),2,".");
			TXT_PR_ROA.Text				= setDigit(conn.GetFieldValue("PR_ROA").ToString().Replace(",","."),2,".");
			TXT_PR_ROE.Text				= setDigit(conn.GetFieldValue("PR_ROE").ToString().Replace(",","."),2,".");
			TXT_PR_NETPROFITMARGIN.Text	= setDigit(conn.GetFieldValue("PR_NETPROFITMARGIN").ToString().Replace(",","."),2,".");
			TXT_PR_ROI.Text				= setDigit(conn.GetFieldValue("PR_ROI").ToString().Replace(",","."),2,".");
			TXT_PR_NETWORTH.Text		= setDigit(conn.GetFieldValue("PR_NETWORTH").ToString().Replace(",","."),2,".");
			TXT_PR_PENJUALAN.Text		= setDigit(conn.GetFieldValue("PR_PENJUALAN").ToString().Replace(",","."),2,".");
			TXT_PR_LABABERSIH.Text		= setDigit(conn.GetFieldValue("PR_LABABERSIH").ToString().Replace(",","."),2,".");
			TXT_PR_DEBTEQUITY.Text		= setDigit(conn.GetFieldValue("PR_DEBTEQUITY").ToString().Replace(",","."),2,".");
			TXT_PR_TOTALAKTIVA.Text		= setDigit(conn.GetFieldValue("PR_TOTALAKTIVA").ToString().Replace(",","."),2,".");
			TXT_PR_COLLATERALCOV.Text	= setDigit(conn.GetFieldValue("PR_COLLATERALCOV").ToString().Replace(",","."),2,".");
			TXT_PR_CURRENTRATIO.Text	= setDigit(conn.GetFieldValue("PR_CURRENTRATIO").ToString().Replace(",","."),2,".");
			TXT_PR_DEBTSERVICE.Text		= setDigit(conn.GetFieldValue("PR_DEBTSERVICE").ToString().Replace(",","."),2,".");
			TXT_PR_CASHVELOCITY.Text	= setDigit(conn.GetFieldValue("PR_CASHVELOCITY").ToString().Replace(",","."),2,".");
			TXT_PR_DAYSRECEIVABLE.Text	= setDigit(conn.GetFieldValue("PR_DAYSRECEIVABLE").ToString().Replace(",","."),2,".");
			TXT_PR_DAYSINVENTORY.Text	= setDigit(conn.GetFieldValue("PR_DAYSINVENTORY").ToString().Replace(",","."),2,".");
			TXT_PR_DAYSACCOUNTPAY.Text	= setDigit(conn.GetFieldValue("PR_DAYSACCOUNTPAY").ToString().Replace(",","."),2,".");
			TXT_PR_TRADECYCLE.Text		= setDigit(conn.GetFieldValue("PR_TRADECYCLE").ToString().Replace(",","."),2,".");
			TXT_PR_TOTALASSET.Text		= setDigit(conn.GetFieldValue("PR_TOTALASSET").ToString().Replace(",","."),2,".");
			TXT_PR_LABAKOTOR.Text		= setDigit(conn.GetFieldValue("PR_LABAKOTOR").ToString().Replace(",","."),2,".");
			TXT_PR_BIAYAADM.Text		= setDigit(conn.GetFieldValue("PR_BIAYAADM").ToString().Replace(",","."),2,".");
			ViewDataRatio(1);
			ViewDataRatio(2);
			//TampilProyeksi();
		}

		private void ViewDataRatio(int cRatio)
		{
			conn.QueryString = "select * from CUST_RATIO where CU_REF = '" +Request.QueryString["curef"]+ "' and CA_RATIOYY = '" +
				((TextBox) FindControl("TXT_PR_YEAR"+cRatio.ToString())).Text +"'";
			//Response.Write(conn.QueryString+"<br>");
			conn.ExecuteQuery();
			
			((TextBox) FindControl("TXT_CA_ROA"+cRatio.ToString())).Text				= setDigit(conn.GetFieldValue("CA_ROA").ToString().Replace(",","."),2,".");
			((TextBox) FindControl("TXT_CA_ROE"+cRatio.ToString())).Text				= setDigit(conn.GetFieldValue("CA_ROE").ToString().Replace(",","."),2,".");
			((TextBox) FindControl("TXT_CA_NETPROFITMARGIN"+cRatio.ToString())).Text	= setDigit(conn.GetFieldValue("CA_NETPROFITMARGIN").ToString().Replace(",","."),2,".");
			((TextBox) FindControl("TXT_CA_ROI"+cRatio.ToString())).Text				= setDigit(conn.GetFieldValue("CA_ROI").ToString().Replace(",","."),2,".");
			((TextBox) FindControl("TXT_CA_NETWORTH"+cRatio.ToString())).Text			= setDigit(conn.GetFieldValue("CA_NETWORTH").ToString().Replace(",","."),2,".");
			((TextBox) FindControl("TXT_CA_PENJUALAN"+cRatio.ToString())).Text			= setDigit(conn.GetFieldValue("CA_PENJUALAN").ToString().Replace(",","."),2,".");
			((TextBox) FindControl("TXT_CA_LABABERSIH"+cRatio.ToString())).Text			= setDigit(conn.GetFieldValue("CA_LABABERSIH").ToString().Replace(",","."),2,".");
			((TextBox) FindControl("TXT_CA_DEBTEQUITY"+cRatio.ToString())).Text			= setDigit(conn.GetFieldValue("CA_DEBTEQUITY").ToString().Replace(",","."),2,".");
			((TextBox) FindControl("TXT_CA_TOTALAKTIVA"+cRatio.ToString())).Text		= setDigit(conn.GetFieldValue("CA_TOTALAKTIVA").ToString().Replace(",","."),2,".");
			((TextBox) FindControl("TXT_CA_COLLATERALCOV"+cRatio.ToString())).Text		= setDigit(conn.GetFieldValue("CA_COLLATERALCOV").ToString().Replace(",","."),2,".");
			((TextBox) FindControl("TXT_CA_CURRENTRATIO"+cRatio.ToString())).Text		= setDigit(conn.GetFieldValue("CA_CURRENTRATIO").ToString().Replace(",","."),2,".");
			((TextBox) FindControl("TXT_CA_DEBTSERVICE"+cRatio.ToString())).Text		= setDigit(conn.GetFieldValue("CA_DEBTSERVICE").ToString().Replace(",","."),2,".");
			((TextBox) FindControl("TXT_CA_CASHVELOCITY"+cRatio.ToString())).Text		= setDigit(conn.GetFieldValue("CA_CASHVELOCITY").ToString().Replace(",","."),2,".");
			((TextBox) FindControl("TXT_CA_DAYSRECEIVABLE"+cRatio.ToString())).Text		= setDigit(conn.GetFieldValue("CA_DAYSRECEIVABLE").ToString().Replace(",","."),2,".");
			((TextBox) FindControl("TXT_CA_DAYSINVENTORY"+cRatio.ToString())).Text		= setDigit(conn.GetFieldValue("CA_DAYSINVENTORY").ToString().Replace(",","."),2,".");
			((TextBox) FindControl("TXT_CA_DAYSACCOUNTPAY"+cRatio.ToString())).Text		= setDigit(conn.GetFieldValue("CA_DAYSACCOUNTPAY").ToString().Replace(",","."),2,".");
			((TextBox) FindControl("TXT_CA_TRADECYCLE"+cRatio.ToString())).Text			= setDigit(conn.GetFieldValue("CA_TRADECYCLE").ToString().Replace(",","."),2,".");
			((TextBox) FindControl("TXT_CA_TOTALASSET"+cRatio.ToString())).Text			= setDigit(conn.GetFieldValue("CA_TOTALASSET").ToString().Replace(",","."),2,".");
			((TextBox) FindControl("TXT_CA_LABAKOTOR"+cRatio.ToString())).Text			= setDigit(conn.GetFieldValue("CA_LABAKOTOR").ToString().Replace(",","."),2,".");
			((TextBox) FindControl("TXT_CA_BIAYAADM"+cRatio.ToString())).Text			= setDigit(conn.GetFieldValue("CA_BIAYAADM").ToString().Replace(",","."),2,".");
		}
		
		private string HitungProyeksi(string str1, string str2)
		{
			float hsl, nil1, nil2;
			hsl  = 0;
			if (str1.Trim() == "")
				nil1 = 0;
			else
				nil1 = float.Parse(str1);

			if (str2.Trim() == "")
				nil2 = 0;
			else
				nil2 = float.Parse(str2);

			if (nil1 == 0 && nil2 != 0)
				hsl = nil2;
			else if (nil1 != 0)
				hsl = (((nil2-nil1)/nil1) * 100);
			return hsl.ToString();
		}

		public static string setDigit(string str, int length, string point)
		{
			string num = "0", dec = "0";
			int i =	str.IndexOf(point), left;
			if (i < 0)	//point not found in str
				i = str.Length;
			try
			{
				num = str.Substring(0,i);
			} 
			catch {}
			try
			{
				int k = str.Length - i - 1;
				if (k < length)
				{
					if (k < 0)	
					{
						dec = ""; k = 0;
					}
					else	
						dec  = str.Substring(i+1,k);
					for (int j = 0; j < length - k; j++)
						dec += "0";
				}
				else
				{
					dec = str.Substring(i+1,length);
					left = int.Parse(str.Substring(i+1+length,1));
					i = int.Parse(dec);
					if (left >= 5)
						i = i + 1;
					dec = i.ToString();
				}
			} 
			catch {}
			if (num == "") num = "0";
			return num + point + dec;
		}

		private void TampilProyeksi()
		{
			TXT_PR_ROA.Text				= setDigit(HitungProyeksi(TXT_CA_ROA1.Text,TXT_CA_ROA2.Text),2,".");
			TXT_PR_ROE.Text				= setDigit(HitungProyeksi(TXT_CA_ROE1.Text,TXT_CA_ROE2.Text),2,".");
			TXT_PR_NETPROFITMARGIN.Text = setDigit(HitungProyeksi(TXT_CA_NETPROFITMARGIN1.Text,TXT_CA_NETPROFITMARGIN2.Text),2,".");
			TXT_PR_ROI.Text				= setDigit(HitungProyeksi(TXT_CA_ROI1.Text,TXT_CA_ROI2.Text),2,".");
			TXT_PR_NETWORTH.Text		= setDigit(HitungProyeksi(TXT_CA_NETWORTH1.Text,TXT_CA_NETWORTH2.Text),2,".");
			TXT_PR_PENJUALAN.Text		= setDigit(HitungProyeksi(TXT_CA_PENJUALAN1.Text,TXT_CA_PENJUALAN2.Text),2,".");
			TXT_PR_LABABERSIH.Text		= setDigit(HitungProyeksi(TXT_CA_LABABERSIH1.Text,TXT_CA_LABABERSIH2.Text),2,".");
			TXT_PR_DEBTEQUITY.Text		= setDigit(HitungProyeksi(TXT_CA_DEBTEQUITY1.Text,TXT_CA_DEBTEQUITY2.Text),2,".");
			TXT_PR_TOTALAKTIVA.Text		= setDigit(HitungProyeksi(TXT_CA_TOTALAKTIVA1.Text,TXT_CA_TOTALAKTIVA2.Text),2,".");
			TXT_PR_COLLATERALCOV.Text	= setDigit(HitungProyeksi(TXT_CA_COLLATERALCOV1.Text,TXT_CA_COLLATERALCOV2.Text),2,".");
			TXT_PR_CURRENTRATIO.Text	= setDigit(HitungProyeksi(TXT_CA_CURRENTRATIO1.Text,TXT_CA_CURRENTRATIO2.Text),2,".");
			TXT_PR_DEBTSERVICE.Text		= setDigit(HitungProyeksi(TXT_CA_DEBTSERVICE1.Text,TXT_CA_DEBTSERVICE2.Text),2,".");
			TXT_PR_CASHVELOCITY.Text	= setDigit(HitungProyeksi(TXT_CA_CASHVELOCITY1.Text,TXT_CA_CASHVELOCITY2.Text),2,".");
			TXT_PR_DAYSRECEIVABLE.Text	= setDigit(HitungProyeksi(TXT_CA_DAYSRECEIVABLE1.Text,TXT_CA_DAYSRECEIVABLE2.Text),2,".");
			TXT_PR_DAYSINVENTORY.Text	= setDigit(HitungProyeksi(TXT_CA_DAYSINVENTORY1.Text,TXT_CA_DAYSINVENTORY2.Text),2,".");
			TXT_PR_DAYSACCOUNTPAY.Text	= setDigit(HitungProyeksi(TXT_CA_DAYSACCOUNTPAY1.Text,TXT_CA_DAYSACCOUNTPAY2.Text),2,".");
			TXT_PR_TRADECYCLE.Text		= setDigit(HitungProyeksi(TXT_CA_TRADECYCLE1.Text,TXT_CA_TRADECYCLE2.Text),2,".");
			TXT_PR_TOTALASSET.Text		= setDigit(HitungProyeksi(TXT_CA_TOTALASSET1.Text,TXT_CA_TOTALASSET2.Text),2,".");
			TXT_PR_LABAKOTOR.Text		= setDigit(HitungProyeksi(TXT_CA_LABAKOTOR1.Text,TXT_CA_LABAKOTOR2.Text),2,".");
			TXT_PR_BIAYAADM.Text		= setDigit(HitungProyeksi(TXT_CA_BIAYAADM1.Text,TXT_CA_BIAYAADM2.Text),2,".");
		}

		protected void TXT_PR_YEAR1_TextChanged(object sender, System.EventArgs e)
		{
			ViewDataRatio(1);
			//TampilProyeksi();
		}

		protected void TXT_PR_YEAR2_TextChanged(object sender, System.EventArgs e)
		{
			ViewDataRatio(2);
			//TampilProyeksi();
		}

		private void SaveDataRatio(int cRatio)
		{
			conn.QueryString = "exec CA_CUST_RATIO '" +Request.QueryString["curef"]+ "', '" +((TextBox) FindControl("TXT_PR_YEAR"+cRatio.ToString())).Text+ "', "+
					((TextBox) FindControl("TXT_CA_ROA"+cRatio.ToString())).Text.Replace(",",".")+ ", "+((TextBox) FindControl("TXT_CA_ROE"+cRatio.ToString())).Text.Replace(",",".")+ ", " +
					((TextBox) FindControl("TXT_CA_NETPROFITMARGIN"+cRatio.ToString())).Text.Replace(",",".")+ ", " +((TextBox) FindControl("TXT_CA_ROI"+cRatio.ToString())).Text.Replace(",",".")+ ", " +
					((TextBox) FindControl("TXT_CA_NETWORTH"+cRatio.ToString())).Text.Replace(",",".")+ ", " +((TextBox) FindControl("TXT_CA_PENJUALAN"+cRatio.ToString())).Text.Replace(",",".")+ ", " +
					((TextBox) FindControl("TXT_CA_LABABERSIH"+cRatio.ToString())).Text.Replace(",",".")+ ", " +((TextBox) FindControl("TXT_CA_DEBTEQUITY"+cRatio.ToString())).Text.Replace(",",".")+ ", " +
					((TextBox) FindControl("TXT_CA_TOTALAKTIVA"+cRatio.ToString())).Text.Replace(",",".")+ ", " +((TextBox) FindControl("TXT_CA_COLLATERALCOV"+cRatio.ToString())).Text.Replace(",",".")+ ", " +
					((TextBox) FindControl("TXT_CA_CURRENTRATIO"+cRatio.ToString())).Text.Replace(",",".")+ ", " +((TextBox) FindControl("TXT_CA_DEBTSERVICE"+cRatio.ToString())).Text.Replace(",",".")+ ", " +
					((TextBox) FindControl("TXT_CA_CASHVELOCITY"+cRatio.ToString())).Text.Replace(",",".")+ ", " +((TextBox) FindControl("TXT_CA_DAYSRECEIVABLE"+cRatio.ToString())).Text.Replace(",",".")+ ", " +
					((TextBox) FindControl("TXT_CA_DAYSINVENTORY"+cRatio.ToString())).Text.Replace(",",".")+ ", " +((TextBox) FindControl("TXT_CA_DAYSACCOUNTPAY"+cRatio.ToString())).Text.Replace(",",".")+ ", " +
					((TextBox) FindControl("TXT_CA_TRADECYCLE"+cRatio.ToString())).Text.Replace(",",".")+ ", " +((TextBox) FindControl("TXT_CA_TOTALASSET"+cRatio.ToString())).Text.Replace(",",".")+ ", " +
					((TextBox) FindControl("TXT_CA_LABAKOTOR"+cRatio.ToString())).Text.Replace(",",".")+ ", " +((TextBox) FindControl("TXT_CA_BIAYAADM"+cRatio.ToString())).Text.Replace(",",".");
			//Response.Write(conn.QueryString);
			conn.ExecuteNonQuery();
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec CA_PROYEKSIRATIO '" +Request.QueryString["regno"]+ "', '" +Request.QueryString["curef"]+ "', '" + 
					TXT_PR_YEAR1.Text+ "', '" + TXT_PR_YEAR2.Text+ "', " +TXT_PR_NPV.Text.Replace(",",".")+ ", " +TXT_PR_IRR.Text.Replace(",",".")+ ", " +TXT_PR_PAYBACK.Text.Replace(",",".")+ ", " +
					TXT_PR_ROA.Text.Replace(",",".")+ ", " +TXT_PR_ROE.Text.Replace(",",".")+ ", " +TXT_PR_NETPROFITMARGIN.Text.Replace(",",".")+ ", " +TXT_PR_ROI.Text.Replace(",",".")+ ", " +TXT_PR_NETWORTH.Text.Replace(",",".")+ ", " +
					TXT_PR_PENJUALAN.Text.Replace(",",".")+ ", " +TXT_PR_LABABERSIH.Text.Replace(",",".")+ ", " +TXT_PR_DEBTEQUITY.Text.Replace(",",".")+ ", " +TXT_PR_TOTALAKTIVA.Text.Replace(",",".")+ ", " +
					TXT_PR_COLLATERALCOV.Text.Replace(",",".")+ ", " +TXT_PR_CURRENTRATIO.Text.Replace(",",".")+ ", " +TXT_PR_DEBTSERVICE.Text.Replace(",",".")+ ", " +TXT_PR_CASHVELOCITY.Text.Replace(",",".")+ ", " +
					TXT_PR_DAYSRECEIVABLE.Text.Replace(",",".")+ ", " +TXT_PR_DAYSINVENTORY.Text.Replace(",",".")+ ", " +TXT_PR_DAYSACCOUNTPAY.Text.Replace(",",".")+ ", " +TXT_PR_TRADECYCLE.Text.Replace(",",".")+ ", " +
					TXT_PR_TOTALASSET.Text.Replace(",",".")+ ", " +TXT_PR_LABAKOTOR.Text.Replace(",",".")+ ", " +TXT_PR_BIAYAADM.Text.Replace(",",".");
			conn.ExecuteNonQuery();
			SaveDataRatio(1);
			SaveDataRatio(2);
			ViewDataProyeksi();
		}

	}
}
