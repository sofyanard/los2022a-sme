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

namespace SME.Booking.Channeling
{
	/// <summary>
	/// Summary description for Syarat.
	/// </summary>
	public partial class SyaratMainPage : System.Web.UI.Page
	{

		#region " My Variable "
		protected Tools tool = new Tools();
		protected Connection conn;
		protected System.Web.UI.WebControls.DataGrid DATGRD_PKDOCC;
		private string bussUnit;
		#endregion
		
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			bussUnit = getBussUnitFromApplication();

			/*if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");*/

			if (!IsPostBack)
			{
				DDL_PK.Items.Add(new ListItem("- SELECT -", ""));
				DDL_TERBIT.Items.Add(new ListItem("- SELECT -", ""));
				DDL_LAIN.Items.Add(new ListItem("- SELECT -", ""));

				conn.QueryString = "select * from VW_DTBOLIST where DOCTYPEID = '4' ";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_PK.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				conn.QueryString = "select * from VW_DTBOLIST where DOCTYPEID = '5' ";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_TERBIT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				conn.QueryString = "select * from VW_DTBOLIST where DOCTYPEID = '6' ";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_LAIN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				//--- hide row jenis product for syarat perjanjian kredit
				TR_JNSPROD_SYARATPK.Visible = false;
				//--- hide row jenis product for syarat penarikan kredit
				TR_JNSPROD_SYARATTARIK.Visible = false;
				//--- hide row jenis product for syarat lain
				TR_JNSPROD_SYARATLAIN.Visible = false;
				
				ViewDataPK();
				ViewDataTerbit();
				ViewDataLain();
			}

			ViewMenu();
			SecureData();
			BTNINSERT_PK.Attributes.Add("onclick","if(!CekEntry('PK')){return false;};");
			BTNINSERT_LAIN.Attributes.Add("onclick","if(!CekEntry('LAIN')){return false;};");
			BTNINSERT_TERBIT.Attributes.Add("onclick","if(!CekEntry('TERBIT')){return false;};");
		
			
			TR_JNSPROD_SYARATPK.Visible = false;
			TR_JNSPROD_SYARATTARIK.Visible = false;
			TR_JNSPROD_SYARATLAIN.Visible = false;
		}

		private void ViewDataPKDoc()
		{
			for (int i=0;i<DatGrd_PK.Items.Count;i++)
			{
				DataGrid dgpkdoc = (DataGrid) DatGrd_PK.Items[i].Cells[1].FindControl("DG_PKDOC");

				conn.QueryString = "SELECT * FROM RFCHANNELINGCUSTEXPORT WHERE EXPORT_ID = 'CHANNELINGSYARAT'";
				conn.ExecuteQuery();

				string durl = conn.GetFieldValue("EXPORT_URL");

				conn.QueryString = "SELECT * FROM VW_SYARAT_DOC WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND DOCTYPEID = '4' AND COVSEQ = '" + DatGrd_PK.Items[i].Cells[1].Text.Trim() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtpkdoc = new DataTable();
					dtpkdoc = conn.GetDataTable().Copy();
					dgpkdoc.DataSource = dtpkdoc;
					try 
					{
						dgpkdoc.DataBind();
					} 
					catch 
					{
						dgpkdoc.CurrentPageIndex = 0;
						dgpkdoc.DataBind();
					}

					for (int j = 0; j < dgpkdoc.Items.Count; j++)
					{
						int n = j+1;
						dgpkdoc.Items[j].Cells[2].Text = n.ToString();
						HyperLink HpDownload = (HyperLink) dgpkdoc.Items[j].Cells[4].FindControl("HL_DOWNLOAD1");
						//edit ini !
						string a = durl + (dgpkdoc.Items[j].Cells[7].Text.Trim()).Remove(0, 14);
						HpDownload.NavigateUrl = durl + (dgpkdoc.Items[j].Cells[7].Text.Trim()).Remove(0, 14);
					}
				}
			}
		}

		private void ViewDataTerbitDoc()
		{
			for (int i=0;i<DATGRID_TERBIT.Items.Count;i++)
			{
				DataGrid dgterbitdoc = (DataGrid) DATGRID_TERBIT.Items[i].Cells[1].FindControl("DG_TERBITDOC");

				conn.QueryString = "SELECT * FROM RFCHANNELINGCUSTEXPORT WHERE EXPORT_ID = 'CHANNELINGSYARAT'";
				conn.ExecuteQuery();

				string durl = conn.GetFieldValue("EXPORT_URL");

				conn.QueryString = "SELECT * FROM VW_SYARAT_DOC WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND DOCTYPEID = '5' AND COVSEQ = '" + DATGRID_TERBIT.Items[i].Cells[1].Text.Trim() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtterbitdoc = new DataTable();
					dtterbitdoc = conn.GetDataTable().Copy();
					dgterbitdoc.DataSource = dtterbitdoc;
					try 
					{
						dgterbitdoc.DataBind();
					} 
					catch 
					{
						dgterbitdoc.CurrentPageIndex = 0;
						dgterbitdoc.DataBind();
					}

					for (int j = 0; j < dgterbitdoc.Items.Count; j++)
					{
						int n = j+1;
						dgterbitdoc.Items[j].Cells[2].Text = n.ToString();
						HyperLink HpDownload = (HyperLink) dgterbitdoc.Items[j].Cells[4].FindControl("HL_DOWNLOAD2");
						//edit ini !
						string a = durl + (dgterbitdoc.Items[j].Cells[7].Text.Trim()).Remove(0, 14);
						HpDownload.NavigateUrl = durl + (dgterbitdoc.Items[j].Cells[7].Text.Trim()).Remove(0, 14);
						//HpDownload.NavigateUrl = dgterbitdoc.Items[j].Cells[7].Text.Trim();
					}
				}
			}
		}

		private void ViewDataLainDoc()
		{
			for (int i=0;i<DATGRID_LAIN.Items.Count;i++)
			{
				DataGrid dglaindoc = (DataGrid) DATGRID_LAIN.Items[i].Cells[1].FindControl("DG_LAINDOC");

				conn.QueryString = "SELECT * FROM RFCHANNELINGCUSTEXPORT WHERE EXPORT_ID = 'CHANNELINGSYARAT'";
				conn.ExecuteQuery();

				string durl = conn.GetFieldValue("EXPORT_URL");

				conn.QueryString = "SELECT * FROM VW_SYARAT_DOC WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND DOCTYPEID = '6' AND COVSEQ = '" + DATGRID_LAIN.Items[i].Cells[1].Text.Trim() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtlaindoc = new DataTable();
					dtlaindoc = conn.GetDataTable().Copy();
					dglaindoc.DataSource = dtlaindoc;
					try 
					{
						dglaindoc.DataBind();
					} 
					catch 
					{
						dglaindoc.CurrentPageIndex = 0;
						dglaindoc.DataBind();
					}

					for (int j = 0; j < dglaindoc.Items.Count; j++)
					{
						int n = j+1;
						dglaindoc.Items[j].Cells[2].Text = n.ToString();
						HyperLink HpDownload = (HyperLink) dglaindoc.Items[j].Cells[4].FindControl("HL_DOWNLOAD3");
						//edit ini !
						string a = durl + (dglaindoc.Items[j].Cells[7].Text.Trim()).Remove(0, 14);
						HpDownload.NavigateUrl = durl + (dglaindoc.Items[j].Cells[7].Text.Trim()).Remove(0, 14);
						//HpDownload.NavigateUrl = dglaindoc.Items[j].Cells[7].Text.Trim();
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
			this.DatGrd_PK.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DatGrd_PK_ItemCreated);
			this.DatGrd_PK.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_PK_ItemCommand);
			this.DatGrd_PK.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PK_PageIndexChanged);
			this.DATGRID_TERBIT.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DATGRID_TERBIT_ItemCreated);
			this.DATGRID_TERBIT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATGRID_TERBIT_ItemCommand);
			this.DATGRID_TERBIT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATGRID_TERBIT_PageIndexChanged);
			this.DATGRID_LAIN.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DATGRID_LAIN_ItemCreated);
			this.DATGRID_LAIN.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATGRID_LAIN_ItemCommand);
			this.DATGRID_LAIN.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATGRID_LAIN_PageIndexChanged);

		}
		#endregion

		private string getBussUnitFromApplication() 
		{
			try 
			{
				conn.QueryString = "select AP_BUSINESSUNIT from APPLICATION where AP_REGNO = '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
			}
			catch (NullReferenceException)
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			return conn.GetFieldValue("AP_BUSINESSUNIT");
		}

		private void SecureData() 
		{
			/* *
			 * Untuk men-disable syarat jika di-pass parameter sy==0
			 * */
			string sy = Request.QueryString["sy"];
			if (sy == "0") 
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
					else if (coll[1].Controls[i] is DataGrid) 
					{						
						DataGrid dg = (DataGrid) coll[1].Controls[i];
						dg.Columns[5].Visible = false;
						for (int j = 0; j < dg.Items.Count; j++) 
						{
							dg.Items[j].Cells[5].Visible = false;
						}
					}
					/*
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
					*/
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
								/*
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
								*/					
							}
						}
					}
				}
			}
		}

		private void ViewDataPK()
		{
			DataTable dt = new DataTable();
			conn.QueryString = "select AP_REGNO, SEQ, case isnull(DOCID,'') when '' then SY_SYARAT else DOCDESC end as SYARAT_DESC,SY_USERID, ISNULL(SY_JENISPRODUCT, 'CL') AS SY_JENISPRODUCT from VW_CP_SYARATSYARAT "+
							   "where AP_REGNO ='" +Request.QueryString["regno"]+ "' and DOCTYPEID = '4' ";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrd_PK.DataSource = dt;
			try 
			{
				DatGrd_PK.DataBind();
			} 
			catch 
			{
				DatGrd_PK.CurrentPageIndex = 0;
				DatGrd_PK.DataBind();
			}

			for (int i = 0; i < DatGrd_PK.Items.Count; i++)
			{
				int Count = i+1;
				DatGrd_PK.Items[i].Cells[2].Text = Count.ToString();
			}
			
			//cekBussUnitForJenisProdView(ref DatGrd_PK, ref TR_JNSPROD_SYARATPK);- 
			cekBussUnitForJenisProdView(ref DATGRID_TERBIT, ref TR_JNSPROD_SYARATTARIK);

			ViewDataPKDoc();
		}

		private void cekBussUnitForJenisProdView(ref DataGrid DGR, ref HtmlTableRow TR_JNSPROD) 
		{
			//--- memeriksa business unit untuk view jenis product 
			try 
			{
				conn.QueryString = "select IN_SMALL, IN_MIDDLE, IN_CORPORATE from RFINITIAL";
				conn.ExecuteQuery();
			}
			catch (NullReferenceException)
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			if (conn.GetFieldValue("IN_SMALL") == bussUnit)	
			{
				TR_JNSPROD.Visible = false;
				DGR.Columns[5].Visible = false;
			}
			else if (conn.GetFieldValue("IN_MIDDLE") == bussUnit) 
			{
				TR_JNSPROD.Visible = true;				
				DGR.Columns[5].Visible = true;
			}
			else if (conn.GetFieldValue("IN_CORPORATE") == bussUnit) 
			{
				TR_JNSPROD.Visible = true;				
				DGR.Columns[5].Visible = true;
			}
			//---------------------------------------------------------
		}

		protected void BTNINSERT_PK_Click(object sender, System.EventArgs e)
		{
			string DOCID, SY_SYARAT;
			if (TXT_PK.Text.Trim() == "")
			{
				DOCID		= DDL_PK.SelectedValue;
				SY_SYARAT	= "";
			}
			else
			{
				DOCID		= "";
				SY_SYARAT	= TXT_PK.Text;
			}
			
			if (TR_JNSPROD_SYARATPK.Visible == false)
				conn.QueryString = "exec CP_SYARATSYARAT '"+ Request.QueryString["regno"] +"','4','', '" +DOCID+ "', '" +SY_SYARAT+ "','1','"+Session["USERID"].ToString()+"'";
			else
				conn.QueryString = "exec CP_SYARATSYARAT '"+ Request.QueryString["regno"] +"','4','', '" +DOCID+ "', '" +SY_SYARAT+ "','1','"+Session["USERID"].ToString()+"', '" + RDO_JNSPROD_SYARATPK.SelectedValue + "'";
			conn.ExecuteQuery();
			ViewDataPK();
			ClearDataPK();
		}

		private void ClearDataPK()
		{
			DDL_PK.SelectedValue	= "";
			TXT_PK.Text				= "";
		}

		private void DatGrd_PK_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Delete":
					try
					{
						conn.QueryString = "exec CP_SYARATSYARAT '"+ e.Item.Cells[0].Text +"','4', '" +e.Item.Cells[1].Text+ "', '', '','2','"+Session["USERID"].ToString()+"'";
						conn.ExecuteNonQuery();
						ViewDataPK();
					}
					catch (Exception ex)
					{
						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						return;
					}
					break;
					break;

				case "Upload":
					Response.Write("<script language='javascript'>window.open('SyaratUploadFile.aspx?regno=" + Request.QueryString["regno"] + "&doctype=4&covseq=" + e.Item.Cells[1].Text + "&theForm=Form1&theObj=TXT_TEMP_PK','UploadDocument','status=no,scrollbars=yes,width=800,height=600');</script>");
					break;
			}
		}

		private void ViewDataTerbit()
		{
			DataTable dt = new DataTable();
			conn.QueryString = "select AP_REGNO, SEQ, case isnull(DOCID,'') when '' then SY_SYARAT else DOCDESC end as SYARAT_DESC, ISNULL(SY_JENISPRODUCT, 'CL') AS SY_JENISPRODUCT from VW_CP_SYARATSYARAT "+
				"where AP_REGNO ='" +Request.QueryString["regno"]+ "' and DOCTYPEID = '5' ";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DATGRID_TERBIT.DataSource = dt;
			try 
			{
				DATGRID_TERBIT.DataBind();
			} 
			catch 
			{
				DATGRID_TERBIT.CurrentPageIndex = 0;
				DATGRID_TERBIT.DataBind();
			}

			for (int i = 0; i < DATGRID_TERBIT.Items.Count; i++)
			{
				int Count = i+1;
				DATGRID_TERBIT.Items[i].Cells[2].Text = Count.ToString();
			}

			//cekBussUnitForJenisProdView(ref DATGRID_TERBIT, ref TR_JNSPROD_SYARATTARIK);

			ViewDataTerbitDoc();
		}

		private void ClearDataTerbit()
		{
			DDL_TERBIT.SelectedValue	= "";
			TXT_TERBIT.Text				= "";
		}

		private void DATGRID_LAIN_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Delete":
					try
					{
						conn.QueryString = "exec CP_SYARATSYARAT '"+ e.Item.Cells[0].Text +"','6', '" +e.Item.Cells[1].Text+ "', '', '','2','"+Session["USERID"].ToString()+"'";
						conn.ExecuteNonQuery();
						ViewDataLain();
					}
					catch (Exception ex)
					{
						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						return;
					}
					break;

				case "Upload":
					Response.Write("<script language='javascript'>window.open('SyaratUploadFile.aspx?regno=" + Request.QueryString["regno"] + "&doctype=6&covseq=" + e.Item.Cells[1].Text + "&theForm=Form1&theObj=TXT_TEMP_LAIN','UploadDocument','status=no,scrollbars=yes,width=800,height=600');</script>");
					break;
			}
		}

		protected void BTNINSERT_LAIN_Click(object sender, System.EventArgs e)
		{
			string DOCID, SY_SYARAT;
			if (TXT_LAIN.Text.Trim() == "")
			{
				DOCID		= DDL_LAIN.SelectedValue;
				SY_SYARAT	= "";
			}
			else
			{
				DOCID		= "";
				SY_SYARAT	= TXT_LAIN.Text;
			}

			if (TR_JNSPROD_SYARATLAIN.Visible == false)
				conn.QueryString = "exec CP_SYARATSYARAT '"+ Request.QueryString["regno"] +"','6','', '" +DOCID+ "', '" +SY_SYARAT+ "','1','"+Session["USERID"].ToString()+"'";
			else
				conn.QueryString = "exec CP_SYARATSYARAT '"+ Request.QueryString["regno"] +"','6','', '" +DOCID+ "', '" +SY_SYARAT+ "','1','"+Session["USERID"].ToString()+"', '" + RDO_JNSPROD_SYARATLAIN.SelectedValue + "'";
			conn.ExecuteQuery();
			ViewDataLain();
			ClearDataLain();
		}

		protected void BTNINSERT_TERBIT_Click(object sender, System.EventArgs e)
		{
			string DOCID, SY_SYARAT;
			if (TXT_TERBIT.Text.Trim() == "")
			{
				DOCID		= DDL_TERBIT.SelectedValue;
				SY_SYARAT	= "";
			}
			else
			{
				DOCID		= "";
				SY_SYARAT	= TXT_TERBIT.Text;
			}

			if (TR_JNSPROD_SYARATTARIK.Visible == false)
				conn.QueryString = "exec CP_SYARATSYARAT '"+ Request.QueryString["regno"] +"','5','', '" +DOCID+ "', '" +SY_SYARAT+ "','1','"+Session["USERID"].ToString()+"'";
			else
				conn.QueryString = "exec CP_SYARATSYARAT '"+ Request.QueryString["regno"] +"','5','', '" +DOCID+ "', '" +SY_SYARAT+ "','1','"+Session["USERID"].ToString()+"', '" + RDO_JNSPROD_SYARATTERBIT.SelectedValue + "'";
			conn.ExecuteQuery();
			ViewDataTerbit();
			ClearDataTerbit();
		}

		private void DATGRID_TERBIT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Delete":
					try
					{
						conn.QueryString = "exec CP_SYARATSYARAT '"+ e.Item.Cells[0].Text +"','5', '" +e.Item.Cells[1].Text+ "', '', '','2','"+Session["USERID"].ToString()+"'";
						conn.ExecuteNonQuery();
						ViewDataTerbit();
					}
					catch (Exception ex)
					{
						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						return;
					}
					break;
					break;

				case "Upload":
					Response.Write("<script language='javascript'>window.open('SyaratUploadFile.aspx?regno=" + Request.QueryString["regno"] + "&doctype=5&covseq=" + e.Item.Cells[1].Text + "&theForm=Form1&theObj=TXT_TEMP_TERBIT','UploadDocument','status=no,scrollbars=yes,width=800,height=600');</script>");
					break;
			}
		}

		private void ViewDataLain()
		{
			DataTable dt = new DataTable();
			conn.QueryString = "select AP_REGNO, SEQ, case isnull(DOCID,'') when '' then SY_SYARAT else DOCDESC end as SYARAT_DESC, ISNULL(SY_JENISPRODUCT, 'CL') AS SY_JENISPRODUCT from VW_CP_SYARATSYARAT "+
							"where AP_REGNO ='" +Request.QueryString["regno"]+ "' and DOCTYPEID = '6' ";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DATGRID_LAIN.DataSource = dt;
			try 
			{
				DATGRID_LAIN.DataBind();
			} 
			catch 
			{
				DATGRID_LAIN.CurrentPageIndex = 0;
				DATGRID_LAIN.DataBind();
			}

			for (int i = 0; i < DATGRID_LAIN.Items.Count; i++)
			{
				int Count = i+1;
				DATGRID_LAIN.Items[i].Cells[2].Text = Count.ToString();
			}

			//cekBussUnitForJenisProdView(ref DATGRID_LAIN, ref TR_JNSPROD_SYARATLAIN);

			ViewDataLainDoc();
		}

		private void ClearDataLain()
		{
			DDL_LAIN.SelectedValue	= "";
			TXT_LAIN.Text			= "";
		}

		
		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select SM_ID,MENUCODE,SM_MENUDISPLAY,SM_LINKNAME from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
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
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]+"&parentregno="+Request.QueryString["parentregno"]+"&aano="+Request.QueryString["aano"] + "&productid=" + Request.QueryString["productid"] + "&prodseq=" + Request.QueryString["prodseq"];
						else	
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]+"&parentregno="+Request.QueryString["parentregno"]+"&aano="+Request.QueryString["aano"] + "&productid=" + Request.QueryString["productid"] + "&prodseq=" + Request.QueryString["prodseq"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = "../" + conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void DatGrd_PK_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			DataGrid dgpkdoc = (DataGrid) e.Item.FindControl("DG_PKDOC");
			if (dgpkdoc != null)
			{
				dgpkdoc.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgpkdoc_ItemDataBound);
				dgpkdoc.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgpkdoc_ItemCommand);
				dgpkdoc.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgpkdoc_PageIndexChanged);
			}
		}

		private void dgpkdoc_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
		}

		private void dgpkdoc_ItemCommand(object sender, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					try
					{
						conn.QueryString = "EXEC SYARAT_DOC_DELETE '" +
							Request.QueryString["regno"] + "', '4', '" +
							e.Item.Cells[0].Text + "', '" +
							e.Item.Cells[1].Text + "'";
						conn.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						Response.Write("<!--" + ex.Message + "-->");
						Tools.popMessage(this,"Delete Error!!");
					}

					ViewDataPK();
					break;
			}
		}

		private void dgpkdoc_PageIndexChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			dg.CurrentPageIndex = e.NewPageIndex;
			ViewDataPKDoc();
			SecureData();
		}

		protected void TXT_TEMP_PK_TextChanged(object sender, System.EventArgs e)
		{
			ViewDataPK();
			SecureData();
			TXT_TEMP_PK.Text = "";
		}

		private void DatGrd_PK_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd_PK.CurrentPageIndex = e.NewPageIndex;
			ViewDataPK();
			SecureData();
		}

		private void DATGRID_TERBIT_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			DataGrid dgterbitdoc = (DataGrid) e.Item.FindControl("DG_TERBITDOC");
			if (dgterbitdoc != null)
			{
				dgterbitdoc.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgterbitdoc_ItemDataBound);
				dgterbitdoc.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgterbitdoc_ItemCommand);
				dgterbitdoc.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgterbitdoc_PageIndexChanged);
			}
		}

		private void dgterbitdoc_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
		}

		private void dgterbitdoc_ItemCommand(object sender, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					try
					{
						conn.QueryString = "EXEC SYARAT_DOC_DELETE '" +
							Request.QueryString["regno"] + "', '5', '" +
							e.Item.Cells[0].Text + "', '" +
							e.Item.Cells[1].Text + "'";
						conn.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						Response.Write("<!--" + ex.Message + "-->");
						Tools.popMessage(this,"Delete Error!!");
					}

					ViewDataTerbit();
					break;
			}
		}

		private void dgterbitdoc_PageIndexChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			dg.CurrentPageIndex = e.NewPageIndex;
			ViewDataTerbitDoc();
			SecureData();
		}

		protected void TXT_TEMP_TERBIT_TextChanged(object sender, System.EventArgs e)
		{
			ViewDataTerbit();
			SecureData();
			TXT_TEMP_TERBIT.Text = "";
		}

		private void DATGRID_TERBIT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATGRID_TERBIT.CurrentPageIndex = e.NewPageIndex;
			ViewDataTerbit();
			SecureData();
		}

		private void DATGRID_LAIN_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			DataGrid dglaindoc = (DataGrid) e.Item.FindControl("DG_LAINDOC");
			if (dglaindoc != null)
			{
				dglaindoc.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dglaindoc_ItemDataBound);
				dglaindoc.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dglaindoc_ItemCommand);
				dglaindoc.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dglaindoc_PageIndexChanged);
			}
		}

		private void dglaindoc_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
		}

		private void dglaindoc_ItemCommand(object sender, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					try
					{
						conn.QueryString = "EXEC SYARAT_DOC_DELETE '" +
							Request.QueryString["regno"] + "', '6', '" +
							e.Item.Cells[0].Text + "', '" +
							e.Item.Cells[1].Text + "'";
						conn.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						Response.Write("<!--" + ex.Message + "-->");
						Tools.popMessage(this,"Delete Error!!");
					}

					ViewDataLain();
					break;
			}
		}

		private void dglaindoc_PageIndexChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			dg.CurrentPageIndex = e.NewPageIndex;
			ViewDataLainDoc();
			SecureData();
		}

		protected void TXT_TEMP_LAIN_TextChanged(object sender, System.EventArgs e)
		{
			ViewDataLain();
			SecureData();
			TXT_TEMP_LAIN.Text = "";
		}

		private void DATGRID_LAIN_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATGRID_LAIN.CurrentPageIndex = e.NewPageIndex;
			ViewDataLain();
			SecureData();
		}
	}
}
