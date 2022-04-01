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
using Excel;

namespace SME.CBI
{
	/// <summary>
	/// Summary description for arNonCashLoan.
	/// </summary>
	public partial class arNonCashLoanCBI : System.Web.UI.Page
	{
		
		protected Tools tool = new Tools();
		protected Connection conn;

		string REGNO, CUREF, TC, MC, DE, PAR, KETKREDIT;
		
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			REGNO		= Request.QueryString["regno"];
			CUREF		= Request.QueryString["curef"];
			KETKREDIT	= Request.QueryString["ketkredit"];
			MC	= Request.QueryString["MC"];
			TC	= Request.QueryString["TC"];
			DE	= Request.QueryString["DE"];
			PAR	= Request.QueryString["PAR"];

			this.lbl_PAR.Text = PAR; //ahmad
			
			if(!IsPostBack)
			{
				GlobalTools.fillRefList(this.ddl_NCL_KETKREDIT,"select * from KETENTUAN_KREDIT where AP_REGNO = '" + REGNO + "';",false,conn);
				IsiDDL();
				ViewData();
				try {Hitung();}
				catch {}


			}
			SecureData();
			Tools.SetFocus(this,this.btn_Hitung);
		}


		private void SecureData() 
		{
			// Jika yang memanggil bukan dalam scope DataEntry, maka disable semua control input
			// Flag :
			//		Nama  = de
			//		Value ==  1 --> Parent DataEntry
			//			  !=  1 --> Parent non-DataEntry
			string de = Request.QueryString["de"];
			if (de != "1") 
			{
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				int k = 0;
				for(k = 0; k < coll.Count; k++) 
				{
					if (coll[k] is System.Web.UI.HtmlControls.HtmlForm) 
					{
						break;
					}
				}
				if (k == coll.Count) return;

				for (int i = 0; i < coll[k].Controls.Count; i++) 
				{
					if (coll[k].Controls[i] is System.Web.UI.WebControls.TextBox) 
					{
						System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) coll[k].Controls[i];
						txt.ReadOnly = true;
						//txt.Enabled = false;
					}
					else if (coll[k].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[k].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[k].Controls[i] is System.Web.UI.WebControls.Button)
					{
						System.Web.UI.WebControls.Button btn = (System.Web.UI.WebControls.Button) coll[k].Controls[i];
						//btn.Enabled = false;
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
					else if (coll[k].Controls[i] is System.Web.UI.WebControls.CheckBox)
					{
						System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) coll[k].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[k].Controls[i] is DataGrid) 
					{						
						DataGrid dg = (DataGrid) coll[k].Controls[i];						
						dg.Columns[10].Visible = false;
						for (int j = 0; j < dg.Items.Count; j++) 
						{
							//dg.Items[j].Cells[10].Enabled = false;
							dg.Items[j].Cells[10].Visible = false;
						}
					}
					else if (coll[k].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[k].Controls[i];
						//htr.Disabled = true;	

						for (int j=0; j < htr.Controls.Count; j++) 
						{							
							for (int jj = 0; jj < htr.Controls[j].Controls.Count; jj++) 
							{
								if (htr.Controls[j].Controls[jj] is System.Web.UI.WebControls.TextBox) 
								{
									System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) htr.Controls[j].Controls[jj];
									txt.ReadOnly = true;
									//txt.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is DropDownList) 
								{
									DropDownList ddl = (DropDownList) htr.Controls[j].Controls[jj];
									ddl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is System.Web.UI.WebControls.Button)
								{
									System.Web.UI.WebControls.Button btn = (System.Web.UI.WebControls.Button) htr.Controls[j].Controls[jj];
									//btn.Enabled = false;
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
								else if (htr.Controls[j].Controls[jj] is System.Web.UI.WebControls.CheckBox)
								{
									System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) htr.Controls[j].Controls[jj];
									cb.Enabled = false;
								}					
							}
						}
					}
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


		private void IsiDDL()
		{
			GlobalTools.initDateForm(this.txt_NCL_TD_JW_dd,this.ddl_NCL_TD_JW_mm,this.txt_NCL_TD_JW_yy);
			GlobalTools.initDateForm(this.txt_NCL_UM_JW_dd,this.ddl_NCL_UM_JW_mm,this.txt_NCL_UM_JW_yy);
			GlobalTools.initDateForm(this.txt_NCL_PK_JW_dd,this.ddl_NCL_PK_JW_mm,this.txt_NCL_PK_JW_yy);
			GlobalTools.initDateForm(this.txt_NCL_PM_JW_dd,this.ddl_NCL_PM_JW_mm,this.txt_NCL_PM_JW_yy);
			GlobalTools.initDateForm(this.txt_NCL_PB_JW_dd,this.ddl_NCL_PB_JW_mm,this.txt_NCL_PB_JW_yy);
			GlobalTools.initDateForm(this.txt_NCL_LC_JW_dd,this.ddl_NCL_LC_JW_mm,this.txt_NCL_LC_JW_yy);
		}


		private void ViewData()
		{
			conn.QueryString = "select * from VW_ASPEK_NCL where AP_REGNO = '"+ REGNO + "' and NCL_KETKREDIT = '" + KETKREDIT + "'"; 
			conn.ExecuteQuery();

			try
			{

				this.ddl_NCL_KETKREDIT.SelectedValue = KETKREDIT;

				//-----------------------------------------------------------------------------
				this.txt_NCL_TD_KONT.Text = tool.MoneyFormat(conn.GetFieldValue("NCL_TD_KONT"));
				this.txt_NCL_TD_PRSN.Text = tool.MoneyFormat(conn.GetFieldValue("NCL_TD_PRSN"));
				this.txt_NCL_TD_PSET.Text = tool.MoneyFormat(conn.GetFieldValue("NCL_TD_PSET"));
				try {GlobalTools.fillDateForm(this.txt_NCL_TD_JW_dd,this.ddl_NCL_TD_JW_mm,this.txt_NCL_TD_JW_yy,Convert.ToDateTime(conn.GetFieldValue("NCL_TD_JW")));}
				catch {}

				//-----------------------------------------------------------------------------
				this.txt_NCL_UM_KONT.Text = tool.MoneyFormat(conn.GetFieldValue("NCL_UM_KONT"));
				this.txt_NCL_UM_PRSN.Text = tool.MoneyFormat(conn.GetFieldValue("NCL_UM_PRSN"));
				this.txt_NCL_UM_PSET.Text = tool.MoneyFormat(conn.GetFieldValue("NCL_UM_PSET"));
				try {GlobalTools.fillDateForm(this.txt_NCL_UM_JW_dd,this.ddl_NCL_UM_JW_mm,this.txt_NCL_UM_JW_yy,Convert.ToDateTime(conn.GetFieldValue("NCL_UM_JW")));}
				catch {}

				//-----------------------------------------------------------------------------
				this.txt_NCL_PK_KONT.Text = tool.MoneyFormat(conn.GetFieldValue("NCL_PK_KONT"));
				this.txt_NCL_PK_PRSN.Text = tool.MoneyFormat(conn.GetFieldValue("NCL_PK_PRSN"));
				this.txt_NCL_PK_PSET.Text = tool.MoneyFormat(conn.GetFieldValue("NCL_PK_PSET"));
				try {GlobalTools.fillDateForm(this.txt_NCL_PK_JW_dd,this.ddl_NCL_PK_JW_mm,this.txt_NCL_PK_JW_yy,Convert.ToDateTime(conn.GetFieldValue("NCL_PK_JW")));}
				catch {}

				//-----------------------------------------------------------------------------
				this.txt_NCL_PM_KONT.Text = tool.MoneyFormat(conn.GetFieldValue("NCL_PM_KONT"));
				this.txt_NCL_PM_PRSN.Text = tool.MoneyFormat(conn.GetFieldValue("NCL_PM_PRSN"));
				this.txt_NCL_PM_PSET.Text = tool.MoneyFormat(conn.GetFieldValue("NCL_PM_PSET"));
				try {GlobalTools.fillDateForm(this.txt_NCL_PM_JW_dd,this.ddl_NCL_PM_JW_mm,this.txt_NCL_PM_JW_yy,Convert.ToDateTime(conn.GetFieldValue("NCL_PM_JW")));}
				catch {}

				//-----------------------------------------------------------------------------
				this.txt_NCL_PB_KONT.Text = tool.MoneyFormat(conn.GetFieldValue("NCL_PB_KONT"));
				this.txt_NCL_PB_PRSN.Text = tool.MoneyFormat(conn.GetFieldValue("NCL_PB_PRSN"));
				this.txt_NCL_PB_PSET.Text = tool.MoneyFormat(conn.GetFieldValue("NCL_PB_PSET"));
				try {GlobalTools.fillDateForm(this.txt_NCL_PB_JW_dd,this.ddl_NCL_PB_JW_mm,this.txt_NCL_PB_JW_yy,Convert.ToDateTime(conn.GetFieldValue("NCL_PB_JW")));}
				catch {}

				//-----------------------------------------------------------------------------
				this.txt_NCL_LC_KONT.Text = tool.MoneyFormat(conn.GetFieldValue("NCL_LC_KONT"));
				this.txt_NCL_LC_PRSN.Text = tool.MoneyFormat(conn.GetFieldValue("NCL_LC_PRSN"));
				this.txt_NCL_LC_PSET.Text = tool.MoneyFormat(conn.GetFieldValue("NCL_LC_PSET"));
				try {GlobalTools.fillDateForm(this.txt_NCL_LC_JW_dd,this.ddl_NCL_LC_JW_mm,this.txt_NCL_LC_JW_yy,Convert.ToDateTime(conn.GetFieldValue("NCL_LC_JW")));}
				catch {}

				//-----------------------------------------------------------------------------
			}
			catch{}
		}

		private void Hitung()
		{
			double _TD_Norm, _TD_SJam, _UM_Norm, _UM_SJam, _PK_Norm, _PK_SJam, _PM_Norm, _PM_SJam, _PB_Norm, _PB_SJam, 
				_LC_Norm, _LC_SJam, _NCL_TD_KONT, _NCL_UM_KONT, _NCL_PK_KONT, _NCL_PM_KONT, _NCL_PB_KONT, _NCL_LC_KONT;

			//==============================================================================
			try {_NCL_TD_KONT = Convert.ToDouble(this.txt_NCL_TD_KONT.Text);}
			catch {_NCL_TD_KONT = 0;}

			try {_NCL_UM_KONT = Convert.ToDouble(this.txt_NCL_UM_KONT.Text);}
			catch {_NCL_UM_KONT = 0;}

			try {_NCL_PK_KONT = Convert.ToDouble(this.txt_NCL_PK_KONT.Text);}
			catch {_NCL_PK_KONT = 0;}

			try {_NCL_PM_KONT = Convert.ToDouble(this.txt_NCL_PM_KONT.Text);}
			catch {_NCL_PM_KONT = 0;}

			try {_NCL_PB_KONT = Convert.ToDouble(this.txt_NCL_PB_KONT.Text);}
			catch {_NCL_PB_KONT = 0;}

			try {_NCL_LC_KONT = Convert.ToDouble(this.txt_NCL_LC_KONT.Text);}
			catch {_NCL_LC_KONT = 0;}


			//-----------------------------------------------------------------------------
			try {_TD_Norm = _NCL_TD_KONT/100.0 * Convert.ToDouble(this.txt_NCL_TD_PRSN.Text);}
			catch {_TD_Norm = 0;}

			try {_UM_Norm = _NCL_UM_KONT/100.0 * Convert.ToDouble(this.txt_NCL_UM_PRSN.Text);}
			catch {_UM_Norm = 0;}
		
			try {_PK_Norm = _NCL_PK_KONT/100.0 * Convert.ToDouble(this.txt_NCL_PK_PRSN.Text);}
			catch {_PK_Norm = 0;}

			try {_PM_Norm = _NCL_PM_KONT/100.0 * Convert.ToDouble(this.txt_NCL_PM_PRSN.Text);}
			catch {_PM_Norm = 0;}

			try {_PB_Norm = _NCL_PB_KONT/100.0 * Convert.ToDouble(this.txt_NCL_PB_PRSN.Text);}
			catch {_PB_Norm = 0;}
			
			try {_LC_Norm = _NCL_LC_KONT/100.0 * Convert.ToDouble(this.txt_NCL_LC_PRSN.Text);}
			catch {_LC_Norm = 0;}
			
			//=============================================================================
			try {_TD_SJam = _TD_Norm/100.0 * Convert.ToDouble(this.txt_NCL_TD_PSET.Text);}
			catch {_TD_SJam = 0;}

			try {_UM_SJam = _UM_Norm/100.0 * Convert.ToDouble(this.txt_NCL_UM_PSET.Text);}
			catch {_UM_SJam = 0;}

			try{_PK_SJam = _PK_Norm/100.0 * Convert.ToDouble(this.txt_NCL_PK_PSET.Text);}
			catch {_PK_SJam = 0;}

			try {_PM_SJam = _PM_Norm/100.0 * Convert.ToDouble(this.txt_NCL_PM_PSET.Text);}
			catch {_PM_SJam = 0;}

			try {_PB_SJam = _PB_Norm/100.0 * Convert.ToDouble(this.txt_NCL_PB_PSET.Text);}
			catch {_PB_SJam = 0;}

			try {_LC_SJam = _LC_Norm/100.0 * Convert.ToDouble(this.txt_NCL_LC_PSET.Text);}
			catch {_LC_SJam = 0;}

			//=============================================================================
			this.txt_TD_Norm.Text = tool.MoneyFormat(Convert.ToString(_TD_Norm));
			this.txt_TD_SJam.Text = tool.MoneyFormat(Convert.ToString(_TD_SJam));

			//-----------------------------------------------------------------------------
			this.txt_UM_Norm.Text = tool.MoneyFormat(Convert.ToString(_UM_Norm));
			this.txt_UM_SJam.Text = tool.MoneyFormat(Convert.ToString(_UM_SJam));

			//-----------------------------------------------------------------------------
			this.txt_PK_Norm.Text = tool.MoneyFormat(Convert.ToString(_PK_Norm));
			this.txt_PK_SJam.Text = tool.MoneyFormat(Convert.ToString(_PK_SJam));

			//-----------------------------------------------------------------------------
			this.txt_PM_Norm.Text = tool.MoneyFormat(Convert.ToString(_PM_Norm));
			this.txt_PM_SJam.Text = tool.MoneyFormat(Convert.ToString(_PM_SJam));

			//-----------------------------------------------------------------------------
			this.txt_PB_Norm.Text = tool.MoneyFormat(Convert.ToString(_PB_Norm));
			this.txt_PB_SJam.Text = tool.MoneyFormat(Convert.ToString(_PB_SJam));
			
			//-----------------------------------------------------------------------------
			this.txt_LC_Norm.Text = tool.MoneyFormat(Convert.ToString(_LC_Norm));
			this.txt_LC_SJam.Text = tool.MoneyFormat(Convert.ToString(_LC_SJam));

			//==============================================================================
			this.txt_TotKont.Text = tool.MoneyFormat(Convert.ToString(_NCL_TD_KONT + _NCL_UM_KONT + 
				_NCL_PK_KONT + _NCL_PM_KONT + _NCL_PB_KONT + _NCL_LC_KONT));

			this.txt_TotNorm.Text = tool.MoneyFormat(Convert.ToString(_TD_Norm + _UM_Norm +
				_PK_Norm + _PM_Norm + _PB_Norm + _LC_Norm));

			this.txt_TotSJam.Text = tool.MoneyFormat(Convert.ToString(_TD_SJam + _UM_SJam + 
				_PK_SJam + _PM_SJam + _PB_SJam + _LC_SJam));			
		}

		protected void btn_Save_Click(object sender, System.EventArgs e)
		{

			if (this.ddl_NCL_KETKREDIT.SelectedValue == "0")
			{
				Response.Write("<script language='javascript'>alert('Ketentuan Kredit harus dipilih dulu');</script>");
			}
			else
			{
				//--------------------------------------------------------------------simpan NCL
				conn.QueryString = "SP_ASPEK_NCL 'Save','" + REGNO + "','" +
					KETKREDIT + "'," +
					tool.ConvertFloat(this.txt_NCL_TD_KONT.Text) + "," +
					tool.ConvertFloat(this.txt_NCL_TD_PRSN.Text) + "," +
					tool.ConvertFloat(this.txt_NCL_TD_PSET.Text) + "," +
					
					GlobalTools.ToSQLDate(this.txt_NCL_TD_JW_dd.Text, this.ddl_NCL_TD_JW_mm.SelectedValue, this.txt_NCL_TD_JW_yy.Text) + "," +

					tool.ConvertFloat(this.txt_NCL_UM_KONT.Text) + "," +
					tool.ConvertFloat(this.txt_NCL_UM_PRSN.Text) + "," +
					tool.ConvertFloat(this.txt_NCL_UM_PSET.Text) + "," +
					GlobalTools.ToSQLDate(this.txt_NCL_UM_JW_dd.Text, this.ddl_NCL_UM_JW_mm.SelectedValue, this.txt_NCL_UM_JW_yy.Text) + "," +

					tool.ConvertFloat(this.txt_NCL_PK_KONT.Text) + "," +
					tool.ConvertFloat(this.txt_NCL_PK_PRSN.Text) + "," +
					tool.ConvertFloat(this.txt_NCL_PK_PSET.Text) + "," +
					GlobalTools.ToSQLDate(this.txt_NCL_PK_JW_dd.Text, this.ddl_NCL_PK_JW_mm.SelectedValue, this.txt_NCL_PK_JW_yy.Text) + "," +

					tool.ConvertFloat(this.txt_NCL_PM_KONT.Text) + "," +
					tool.ConvertFloat(this.txt_NCL_PM_PRSN.Text) + "," +
					tool.ConvertFloat(this.txt_NCL_PM_PSET.Text) + "," +
					GlobalTools.ToSQLDate(this.txt_NCL_PM_JW_dd.Text, this.ddl_NCL_PM_JW_mm.SelectedValue, this.txt_NCL_PM_JW_yy.Text) + "," +

					tool.ConvertFloat(this.txt_NCL_PB_KONT.Text) + "," +
					tool.ConvertFloat(this.txt_NCL_PB_PRSN.Text) + "," +
					tool.ConvertFloat(this.txt_NCL_PB_PSET.Text) + "," +
					GlobalTools.ToSQLDate(this.txt_NCL_PB_JW_dd.Text, this.ddl_NCL_PB_JW_mm.SelectedValue, this.txt_NCL_PB_JW_yy.Text) + "," +

					tool.ConvertFloat(this.txt_NCL_LC_KONT.Text) + "," +
					tool.ConvertFloat(this.txt_NCL_LC_PRSN.Text) + "," +
					tool.ConvertFloat(this.txt_NCL_LC_PSET.Text) + "," +
					GlobalTools.ToSQLDate(this.txt_NCL_LC_JW_dd.Text, this.ddl_NCL_LC_JW_mm.SelectedValue, this.txt_NCL_LC_JW_yy.Text) + ";";
				
				try
				{
					conn.ExecuteNonQuery();

					//--------------------------------------------------------------------simpan aspek list
					conn.QueryString = "SP_ASPEK_LIST 'Save','" + REGNO + "','" +
						KETKREDIT + "','B','NON CASH LOAN';";			
					conn.ExecuteNonQuery();
				}
				catch
				{
					Response.Write("<script language='javascript'>alert('Ada masalah saat penyimpanan data!');</script>");
				}
			}
			ViewData();

			//-----------------------------------------------------------------refresh parent
			Response.Write("<script language='javascript'> " +
				"parent.document.Form1.action = 'arParentCBI.aspx?de=" + DE + "&regno=" + REGNO + "&curef=" + CUREF + "&mc=" + MC + "&tc=" + TC + "&par=" + PAR + "';" +
				"parent.document.Form1.submit();</script>");
		}

		protected void btn_Delete_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "SP_ASPEK_NCL 'Delete','" + REGNO + "','" + KETKREDIT + "',0,0,0,'',0,0,0,''," +
				"0,0,0,'',0,0,0,'',0,0,0,'',0,0,0,'';";
			conn.ExecuteNonQuery();

			//--------------------------------------------------------------------hapus aspek list
			conn.QueryString = "EXEC SP_ASPEK_LIST 'Delete','" + REGNO + "','"+ KETKREDIT + "','B','';";
			conn.ExecuteNonQuery();

			ClearData();

			//-----------------------------------------------------------------refresh parent
			Response.Write("<script language='javascript'> " +
				"parent.document.Form1.action = 'arParentCBI.aspx?de=" + DE + "&regno=" + REGNO + "&curef=" + CUREF + "&mc=" + MC + "&tc=" + TC + "&par=" + PAR + "';" +
				"parent.document.Form1.submit();</script>");
		}

		protected void btn_Hitung_Click(object sender, System.EventArgs e)
		{
			try
			{
				Hitung();
			}
			catch
			{
				Response.Write("<script language='javascript'>alert('Data yang mau dihitung belum diisi lengkap');</script>");
			}
		}

		private void ClearData()
		{
			GlobalTools.initDateForm(this.txt_NCL_TD_JW_dd,this.ddl_NCL_TD_JW_mm,this.txt_NCL_TD_JW_yy);
			GlobalTools.initDateForm(this.txt_NCL_UM_JW_dd,this.ddl_NCL_UM_JW_mm,this.txt_NCL_UM_JW_yy);
			GlobalTools.initDateForm(this.txt_NCL_PK_JW_dd,this.ddl_NCL_PK_JW_mm,this.txt_NCL_PK_JW_yy);
			GlobalTools.initDateForm(this.txt_NCL_PM_JW_dd,this.ddl_NCL_PM_JW_mm,this.txt_NCL_PM_JW_yy);
			GlobalTools.initDateForm(this.txt_NCL_PB_JW_dd,this.ddl_NCL_PB_JW_mm,this.txt_NCL_PB_JW_yy);
			GlobalTools.initDateForm(this.txt_NCL_LC_JW_dd,this.ddl_NCL_LC_JW_mm,this.txt_NCL_LC_JW_yy);
			
			this.txt_NCL_TD_KONT.Text = "";
			this.txt_NCL_TD_PRSN.Text = "";
			this.txt_NCL_TD_PSET.Text = "";
			this.txt_NCL_UM_KONT.Text = "";
			this.txt_NCL_UM_PRSN.Text = "";
			this.txt_NCL_UM_PSET.Text = "";
			this.txt_NCL_PK_KONT.Text = "";
			this.txt_NCL_PK_PRSN.Text = "";
			this.txt_NCL_PK_PSET.Text = "";
			this.txt_NCL_PM_KONT.Text = "";
			this.txt_NCL_PM_PRSN.Text = "";
			this.txt_NCL_PM_PSET.Text = "";
			this.txt_NCL_PB_KONT.Text = "";
			this.txt_NCL_PB_PRSN.Text = "";
			this.txt_NCL_PB_PSET.Text = "";
			this.txt_NCL_LC_KONT.Text = "";
			this.txt_NCL_LC_PRSN.Text = "";
			this.txt_NCL_LC_PSET.Text = "";
		}


	}
}
