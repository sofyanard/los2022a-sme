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


namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for arAspekTeknis.
	/// </summary>
	public partial class arAspekTeknisCBI : System.Web.UI.Page
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
			DE			= Request.QueryString["de"];
			MC			= Request.QueryString["mc"];
			TC			= Request.QueryString["tc"];
			PAR			= Request.QueryString["par"];


			if(!IsPostBack)
			{
				GlobalTools.fillRefList(this.ddl_AT_KETKREDIT,"select * from KETENTUAN_KREDIT where AP_REGNO = '" + REGNO + "'",false,conn);
				ViewData();
				ViewIzinGrid();
				ViewInvesGrid();
			}

			SecureData();
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
						/**
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
						***/
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
			this.dg_Izin.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dg_Izin_ItemCommand);
			this.dg_Inves.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dg_Inves_ItemCommand);

		}
		#endregion

		
		private void ViewData()
		{
			conn.QueryString = "select * from VW_ASPEK_ASPEKTEKNIS "+
				"where AP_REGNO = '"+ REGNO + "' and AT_KETKREDIT = '" + KETKREDIT + "'" ;
			conn.ExecuteQuery();

			try
			{
				this.ddl_AT_KETKREDIT.SelectedValue = KETKREDIT;
				this.txt_AT_OBJEKPEMBIAYAAN.Text = conn.GetFieldValue("AT_OBJEKPEMBIAYAAN");
				this.txt_AT_ASPEKTEKNIS.Text = conn.GetFieldValue("AT_ASPEKTEKNIS");
				this.ddl_AT_PEMBIAYAANINVESTASI.SelectedValue = conn.GetFieldValue("AT_PEMBIAYAANINVESTASI");
				this.ddl_AT_RENCANA.SelectedValue = conn.GetFieldValue("AT_RENCANA");
				this.txt_AT_NOTE.Text = conn.GetFieldValue("AT_NOTE");
			}
			catch {}
		}


		private void ViewIzinGrid()
		{
			conn.QueryString = "select IZIN_NO, IZIN_SURATIZINDARI, IZIN_NOSURAT, IZIN_KETERANGAN from ASPEK_ASPEKTEKNIS_PERIZINAN " +
				"where AP_REGNO = '" + REGNO + "'";
			conn.ExecuteQuery();
			this.dg_Izin.DataSource = conn.GetDataTable().Copy();
			this.dg_Izin.DataBind();
		}

		private void ViewIzinGrid2()
		{
			conn.QueryString = "select IZIN_NO, IZIN_SURATIZINDARI, IZIN_NOSURAT, IZIN_KETERANGAN from ASPEK_ASPEKTEKNIS_PERIZINAN " +
				"where AP_REGNO = '" + REGNO + "'";
			conn.ExecuteQuery();
			this.dg_Izin.DataSource = conn.GetDataTable().Copy();
			this.dg_Izin.DataBind();
		}


		private void ViewInvesGrid()
		{
			conn.QueryString = "select INVES_NO, INVES_JNSBIAYA, INVES_NILAIBIAYA, INVES_NILADITERIMA from ASPEK_ASPEKTEKNIS_INVESTASI " +
				"where AP_REGNO = '" + REGNO + "'";
			conn.ExecuteQuery();
			this.dg_Inves.DataSource = conn.GetDataTable().Copy();
			this.dg_Inves.DataBind();


			conn.QueryString = "select sum(INVES_NILAIBIAYA) as TOTINVES, sum(INVES_NILADITERIMA) as TOTDITERIMA from ASPEK_ASPEKTEKNIS_INVESTASI " +
				"where AP_REGNO = '" + REGNO + "'";
			conn.ExecuteQuery();
			this.txt_TotInves.Text = tool.MoneyFormat(conn.GetFieldValue("TOTINVES"));
			this.txt_TotDiterima.Text = tool.MoneyFormat(conn.GetFieldValue("TOTDITERIMA"));
		}


		protected void btn_AddIzin_Click(object sender, System.EventArgs e)
		{
			if (CekIzin())

			{
				SaveAspekTeknis();

				if (this.txt_IZIN_NO.Text == "")
					this.txt_IZIN_NO.Text = "0";

				conn.QueryString = "EXEC SP_ASPEK_ASPEKTEKNIS_PERIZINAN 'Save','" + REGNO + "','"+ KETKREDIT + "'," +
					this.txt_IZIN_NO.Text + ",'" +
					this.txt_IZIN_SURATIZINDARI.Text + "','" + 
					this.txt_IZIN_NOSURAT.Text + "','" +
					this.txt_IZIN_KETERANGAN.Text + "'";

				conn.ExecuteNonQuery();

				this.txt_IZIN_NO.Text = "";
				this.txt_IZIN_SURATIZINDARI.Text = "";
				this.txt_IZIN_NOSURAT.Text = "";
				this.txt_IZIN_KETERANGAN.Text = "";

				ViewIzinGrid2();
				
			}			
		}


		protected void btn_Save_Click(object sender, System.EventArgs e)
		{
			SaveAspekTeknis();
		}


		protected void btn_Delete_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC SP_ASPEK_ASPEKTEKNIS 'Delete','" + REGNO + "','" + KETKREDIT + "','','','','',''";
			conn.ExecuteNonQuery();

			conn.QueryString = "EXEC SP_ASPEK_LIST 'Delete','" + REGNO + "','"+ KETKREDIT + "','A',''";
			conn.ExecuteNonQuery();

			this.ddl_AT_KETKREDIT.SelectedIndex = 0;
			this.txt_AT_OBJEKPEMBIAYAAN.Text= "";
			this.txt_AT_ASPEKTEKNIS.Text = "";
			this.ddl_AT_PEMBIAYAANINVESTASI.SelectedIndex = 0;
			this.ddl_AT_RENCANA.SelectedIndex = 0;
			this.txt_AT_NOTE.Text = "";
			this.ViewIzinGrid();
			this.ViewInvesGrid();

			//-----------------------------------------------------------------refresh parent
			Response.Write("<script language='javascript'> " +
				"parent.document.Form1.action = 'arParentCBI.aspx?de=" + DE + "&regno=" + REGNO + "&curef=" + CUREF + "&mc=" + MC + "&tc=" + TC + "&par=" + PAR + "';" +
				"parent.document.Form1.submit();</script>");
		}


		private bool CekIzin()
		{
			if (this.txt_IZIN_SURATIZINDARI.Text.ToString() == "")
			{
				Response.Write("<script language='javascript'>alert('Surat Izin Dari harus diisi');</script>");
				return false;
			}
			else if (this.txt_IZIN_NOSURAT.Text.ToString() == "")
			{
				Response.Write("<script language='javascript'>alert('No. Surat harus diisi');</script>");
				return false;
			}
			return true;
		}


		private void dg_Izin_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;
			
			switch (cmd)
			{		  
				case "edit":
					this.txt_IZIN_NO.Text = e.Item.Cells[0].Text;
					this.txt_IZIN_SURATIZINDARI.Text = e.Item.Cells[1].Text;
					this.txt_IZIN_NOSURAT.Text = e.Item.Cells[2].Text;
					this.txt_IZIN_KETERANGAN.Text = e.Item.Cells[3].Text.Trim().Replace("&nbsp;","");
					break;
				case "delete":
					conn.QueryString = "EXEC SP_ASPEK_ASPEKTEKNIS_PERIZINAN 'Delete','" + REGNO + "','"+ KETKREDIT + "'," +
						e.Item.Cells[0].Text + ",'','',''";
					conn.ExecuteNonQuery();
					ViewIzinGrid();
					break;
			}
		}


		protected void btn_IzinCancel_Click(object sender, System.EventArgs e)
		{
			this.txt_IZIN_NO.Text = "";
			this.txt_IZIN_SURATIZINDARI.Text = "";
			this.txt_IZIN_NOSURAT.Text = "";
			this.txt_IZIN_KETERANGAN.Text = "";
		}


		protected void btn_AddInves_Click(object sender, System.EventArgs e)
		{
			if (CekInves())
			{
				SaveAspekTeknis();

				if (this.txt_INVES_NO.Text == "")
					this.txt_INVES_NO.Text = "0";

				conn.QueryString = "EXEC SP_ASPEK_ASPEKTEKNIS_INVESTASI 'Save','" + REGNO + "','" + KETKREDIT + "'," +
					this.txt_INVES_NO.Text + ",'" +
					this.txt_INVES_JNSBIAYA.Text + "'," + 
					tool.ConvertFloat(this.txt_INVES_NILAIBIAYA.Text) + "," +
					tool.ConvertFloat(this.txt_INVES_NILADITERIMA.Text) + "";

				conn.ExecuteNonQuery();

				this.txt_INVES_NO.Text = "";
				this.txt_INVES_JNSBIAYA.Text = "";
				this.txt_INVES_NILAIBIAYA.Text = "";
				this.txt_INVES_NILADITERIMA.Text = "";

				ViewInvesGrid();
			}
		}


		protected void btn_InvesCancel_Click(object sender, System.EventArgs e)
		{
			this.txt_INVES_NO.Text = "";
			this.txt_INVES_JNSBIAYA.Text = "";
			this.txt_INVES_NILAIBIAYA.Text = "";
			this.txt_INVES_NILADITERIMA.Text = "";
		}


		private bool CekInves()
		{
			if (this.txt_INVES_JNSBIAYA.Text.ToString() == "")
			{
				Response.Write("<script language='javascript'>alert('Jenis Biaya harus diisi');</script>");
				return false;
			}
			else if (this.txt_INVES_NILAIBIAYA.Text.ToString() == "")
			{
				Response.Write("<script language='javascript'>alert('Nilai Investasi harus diisi');</script>");
				return false;
			}
			else if (this.txt_INVES_NILADITERIMA.Text.ToString() == "")
			{
				Response.Write("<script language='javascript'>alert('Nilai yg Diterima harus diisi');</script>");
				return false;
			}

			return true;
		}


		private void dg_Inves_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;
			
			switch (cmd)
			{		  
				case "edit":
					this.txt_INVES_NO.Text = e.Item.Cells[0].Text;
					this.txt_INVES_JNSBIAYA.Text = e.Item.Cells[1].Text;
					this.txt_INVES_NILAIBIAYA.Text = e.Item.Cells[2].Text;
					this.txt_INVES_NILADITERIMA.Text = e.Item.Cells[3].Text;
					break;
				case "delete":
					conn.QueryString = "EXEC SP_ASPEK_ASPEKTEKNIS_INVESTASI 'Delete','" + REGNO + "','"+ KETKREDIT + "'," +
						e.Item.Cells[0].Text + ",'',0,0";
					conn.ExecuteNonQuery();
					this.ViewInvesGrid();
					break;
			}
		}


		private void SaveAspekTeknis()
		{
			if (this.ddl_AT_KETKREDIT.SelectedValue == "0")
			{
				Response.Write("<script language='javascript'>alert('Ketentuan Kredit harus dipilih dulu');</script>");
			}
			else
			{
				//--------------------------------------------------------------------simpan aspek teknis
				conn.QueryString = "SP_ASPEK_ASPEKTEKNIS 'Save','" + REGNO + "','" +
					this.ddl_AT_KETKREDIT.SelectedValue + "','" +
					this.txt_AT_OBJEKPEMBIAYAAN.Text + "','" +
					this.txt_AT_ASPEKTEKNIS.Text + "','" +
					this.ddl_AT_PEMBIAYAANINVESTASI.SelectedValue + "','" +
					this.ddl_AT_RENCANA.SelectedValue + "','" +
					this.txt_AT_NOTE.Text + "'";
				conn.ExecuteNonQuery();

				//--------------------------------------------------------------------simpan aspek list
				conn.QueryString = "SP_ASPEK_LIST 'Save','" + REGNO + "','" +
					KETKREDIT + "','A','ASPEK TEKNIS'";			
				conn.ExecuteNonQuery();	
			}
			ViewData();

			//-----------------------------------------------------------------refresh parent
			Response.Write("<script language='javascript'> " +
				"parent.document.Form1.action = 'arParentCBI.aspx?de=" + DE + "&regno=" + REGNO + "&curef=" + CUREF + "&mc=" + MC + "&tc=" + TC + "&par=" + PAR + "';" +
				"parent.document.Form1.submit();</script>");
		}



	}
}
