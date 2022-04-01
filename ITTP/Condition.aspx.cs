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

namespace SME.ITTP
{
	/// <summary>
	/// Summary description for Condition.
	/// </summary>
	public partial class Condition : System.Web.UI.Page
	{

		#region " My Variable "
		protected Tools tool = new Tools();
		protected Connection conn;
		private string bussUnit;
		#endregion
		
	

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				ViewDataPK();
				DDL_PK.Items.Add(new ListItem("- SELECT -", ""));

				conn.QueryString = "select * from VW_DTBOLIST where DOCTYPEID = '4' ";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_PK.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}
			}

			ViewMenu();
			SecureData();
			BTNINSERT_PK.Attributes.Add("onclick","if(!CekEntry('PK')){return false;};");
		}

		private void ViewDataPKDoc()
		{
			for (int i=0;i<DatGrd_PK.Items.Count;i++)
			{
				DataGrid dgpkdoc = (DataGrid) DatGrd_PK.Items[i].Cells[1].FindControl("DG_PKDOC");

				conn.QueryString = "SELECT * FROM VW_IT_SYARAT_DOC WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND COVSEQ = '" + DatGrd_PK.Items[i].Cells[1].Text.Trim() + "'";
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
						HpDownload.NavigateUrl = dgpkdoc.Items[j].Cells[7].Text.Trim();
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

		}
		#endregion

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
			conn.QueryString = "select AP_REGNO, SEQ, case isnull(DOCID,'') when '' then SY_SYARAT else DOCDESC end as SYARAT_DESC,SY_USERID, ISNULL(SY_JENISPRODUCT, 'NCL') AS SY_JENISPRODUCT from VW_IT_CP_SYARATSYARAT "+
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
			//cekBussUnitForJenisProdView(ref DATGRID_TERBIT, ref TR_JNSPROD_SYARATTARIK);

			ViewDataPKDoc();
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
			
			conn.QueryString = "exec IT_CP_SYARATSYARAT '"+ Request.QueryString["regno"] +"','4','', '" +DOCID+ "', '" +SY_SYARAT+ "','1','"+Session["USERID"].ToString()+"'";
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
						conn.QueryString = "exec IT_CP_SYARATSYARAT '"+ e.Item.Cells[0].Text +"','4','" +e.Item.Cells[1].Text+ "','','','2','"+Session["USERID"].ToString()+"'";
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
					Response.Write("<script language='javascript'>window.open('../ITTP/ConditionUploadFile.aspx?regno=" + Request.QueryString["regno"]  + "&doctype=4&covseq=" +  e.Item.Cells[1].Text + "&theForm=Form1&theObj=TXT_TEMP_PK','UploadDocument','status=no,scrollbars=yes,width=800,height=600');</script>");
					break;
			}
		}

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
						if (conn.GetFieldValue(i,3).IndexOf("cp=") < 0) strtemp += "&"+Request.QueryString["cp"];
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
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["tc"] != null && Request.QueryString["tc"] != "")
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
			else
				Response.Write("<script language='javascript'>history.back(-1);</script>");
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
						conn.QueryString = "EXEC IT_SYARAT_DOC_DELETE '" +
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

	}
}