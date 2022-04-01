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
	/// Summary description for Jaminan_List.asdfasdfasdfasdsadfsdaf
	/// </summary>
	public partial class Jaminan_List : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				conn.QueryString = "select * from RFCOLLATERALTYPE order by coltypeid";
				conn.ExecuteQuery();
				int row = conn.GetRowCount();
				for (int i = 0; i<row; i++)
				{
					DDL_CL_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i, 1)+" - "+ conn.GetFieldValue(i, 2), conn.GetFieldValue(i, 0)));
				}
			}

			ViewData();
			this.SecureData();
			BTN_DELETE.Attributes.Add("onclick","if(!update()){return false;};");
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
				for (int i = 0; i < coll[1].Controls.Count; i++) 
				{
					if (coll[1].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[1].Controls[i];
						txt.ReadOnly = true;
						//txt.Enabled = false;
					}
					else if (coll[1].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[1].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[1].Controls[i] is Button)
					{
						Button btn = (Button) coll[1].Controls[i];
						//btn.Enabled = false;
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
					else if (coll[1].Controls[i] is DataGrid) 
					{						
						DataGrid dg = (DataGrid) coll[1].Controls[i];						
						/*
						try 
						{
							for(int j=0; j < dg.Items.Count; j++) 
							{
								dg.Items[i].Enabled	= false;
							}
						}
						catch (ArgumentOutOfRangeException ex) 
						{
							// ignore...
						}
						*/
					}
					else if (coll[1].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[1].Controls[i];
						//htr.Disabled = true;	

						for (int j=0; j < htr.Controls.Count; j++) 
						{							
							for (int jj = 0; jj < htr.Controls[j].Controls.Count; jj++) 
							{
								if (htr.Controls[j].Controls[jj] is TextBox) 
								{
									TextBox txt = (TextBox) htr.Controls[j].Controls[jj];
									txt.ReadOnly = true;
									//txt.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is DropDownList) 
								{
									DropDownList ddl = (DropDownList) htr.Controls[j].Controls[jj];
									ddl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is Button)
								{
									Button btn = (Button) htr.Controls[j].Controls[jj];
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

		private void ViewData()
		{
			string curef = Request.QueryString["curef"], regno = Request.QueryString["regno"];
			
			conn.QueryString = "EXEC DDE_JAMINAN_LIST '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			int tblRowCount = Table_List.Rows.Count;
			for (int i = tblRowCount - 1; i >= 0; i--)
				Table_List.Rows.Remove(Table_List.Rows[i]);

			int row = conn.GetRowCount();
			int rowtemp = row;
			//int CL_TYPE;
			//int CL_SEQ;
			string cl_type = "", cl_seq = "";
			TXT_JML_JAMINAN.Text = row.ToString();
			for (int i = 0; i < row; i++)
			{
				HyperLink t = new HyperLink();
				t.Text = conn.GetFieldValue(i, 0)+". "+conn.GetFieldValue(i, "CL_DESC") + " (" + conn.GetFieldValue(i,2) + ")";
				t.CssClass = "TDBGColor1";
				t.Font.Bold = true;
				t.ID	= "CollName"+i;
				/*
				CL_SEQ	= Convert.ToInt16(conn.GetFieldValue(i, 0));
				CL_TYPE = Convert.ToInt16(conn.GetFieldValue(i, 1));
				*/
				cl_seq = conn.GetFieldValue(i,0);
				cl_type = conn.GetFieldValue(i,1);

				//t.NavigateUrl = conn.GetFieldValue(i, 4) + "curef="+Request.QueryString["curef"]+"&colid="+conn.GetFieldValue(i, 1)+"&coltype="+conn.GetFieldValue(i, 2);
				//----- changed by Yudi -------
				//t.NavigateUrl = conn.GetFieldValue(i, 3) +".aspx?curef="+ curef +"&coltypeid="+ CL_TYPE +"&CL_SEQ="+ CL_SEQ;
				if (Request.QueryString["new"] != null && Request.QueryString["new"] == "1")
					t.NavigateUrl = "collateralnew.aspx?regno="+regno+"&curef="+ curef +"&coltypeid="+ cl_type +"&CL_SEQ="+ cl_seq + "&de=" + Request.QueryString["de"] + "&new=" + Request.QueryString["new"];
				else
					t.NavigateUrl = conn.GetFieldValue(i, 3) +".aspx?regno="+regno+"&curef="+ curef +"&coltypeid="+ cl_type +"&CL_SEQ="+ cl_seq + "&de=" + Request.QueryString["de"];
				//------------------------------
				t.Target = "coldetail";
				CheckBox t1 = new CheckBox();
				t1.ID = "check" + i ;
				TextBox t2 = new TextBox();
				t2.ID = "cl_seq" + i;
				//t2.Text = CL_SEQ.ToString();
				t2.Text = cl_seq;
				t2.Visible = false;
				TextBox t3 = new TextBox();
				t3.ID = "coltype" + i;
				//t3.Text = CL_TYPE.ToString();
				t3.Text = cl_type;
				t3.Visible = false;
				this.Table_List.Rows.Add(new TableRow());
				this.Table_List.Rows[i].Cells.Add(new TableCell());
				this.Table_List.Rows[i].Cells[0].Controls.Add(t);
				this.Table_List.Rows[i].Cells.Add(new TableCell());
				this.Table_List.Rows[i].Cells[1].Controls.Add(t1);
				this.Table_List.Rows[i].Cells.Add(new TableCell());
				this.Table_List.Rows[i].Cells[1].Controls.Add(t2);
				this.Table_List.Rows[i].Cells[1].Controls.Add(t3);
			}
			conn.ClearData();
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

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec DE_COLL '0', '"+ Request.QueryString["curef"] + "', 0, "+
				DDL_CL_TYPE.SelectedValue +", 0, '', null, null, null,null,null,null,null,'"+Request.QueryString["regno"]+"'" ;
			conn.ExecuteQuery();
			ViewData();
		}

		protected void BTN_DELETE_Click(object sender, System.EventArgs e)
		{
			int row = Convert.ToInt16(TXT_JML_JAMINAN.Text);
			for (int i=0; i<row; i++)
			{
				if (((CheckBox)Table_List.FindControl("check"+ i)).Checked == true)
				{
					string CL_SEQdel = ((TextBox)Table_List.FindControl("cl_seq"+ i)).Text;
					string CL_DESCdel = ((HyperLink)Table_List.FindControl("CollName"+ i)).Text;
					//--pengecekan data di listcollateral
					conn.QueryString = "select count(*) from LISTCOLLATERAL lc "+
									   "left join COLLATERAL cl on lc.CU_REF = cl.CU_REF and lc.CL_SEQ = cl.CL_SEQ "+
									   "left join RFCOLLATERALTYPE rf on cl.CL_TYPE = rf.COLTYPESEQ "+
									   "where lc.cu_ref='"+Request.QueryString["curef"]+"' and lc.cl_seq = "+CL_SEQdel+" and AP_REGNO = '"+Request.QueryString["regno"]+"'";
					conn.ExecuteQuery();
					if (conn.GetFieldValue(0,0).ToString() != "0")

						Tools.popMessage(this,"Data Jaminan "+CL_DESCdel+" masih digunakan untuk jaminan fasilitas");
					else
					{
						conn.QueryString = "exec DE_COLL '2', '"+ Request.QueryString["curef"] + "', "+CL_SEQdel+
							", "+((TextBox)Table_List.FindControl("coltype"+ i)).Text +", 0, '', null, null, null, null, null, null, null, '" + 
							Request.QueryString["regno"] + "'" ;
						conn.ExecuteQuery();
					}
				}
			}
			ViewData();
			
		}
	}
}
