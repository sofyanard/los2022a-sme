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
	/// Summary description for ProductList.
	/// </summary>
	public partial class ProductList : System.Web.UI.Page

	{
		protected string newFacility;
		protected Connection conn;
		protected void Page_Load(object sender, System.EventArgs e)

		{
			conn = (Connection) Session["Connection"];

			viewdata();
			this.SecureData();
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

		void viewdata()
		{
			
			conn.QueryString = "select * from VW_PRODUCTLIST where ap_regno ='"+ Request.QueryString["regno"] +"'";
			//conn.GetFieldValue("CUSTPRODUCT");
			conn.ExecuteQuery();
			/*conn.GetDataTable("CUSTPRODUCT");
            int row = conn.GetRowCount();
			int rowtemp = row;
			Response.Write(row);*/
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			int jmlCell = dt.Rows.Count;
			int jmlRow = HitungRow(jmlCell);
			for (int i = 0; i < jmlRow ; i++)
			{
				int posisi=0;
				for (int j = 0; j < jmlCell; j++)
				{
					this.Table1.Rows.Add(new TableRow());
						
					HyperLink t = new HyperLink();
					//t.te = "";
					//t.Text = 
					t.Text = dt.Rows[i+j][1]+" "+dt.Rows[i+j][2]+" ("+dt.Rows[i+j][3]+")";
					t.CssClass = "White";
					t.Font.Bold = true;
					conn.QueryString = "select screenlink from apptypelink where APPTYPEID = '"+ dt.Rows[i+j][0] +"' and PRODUCTID='"+ dt.Rows[i+j][1] +"' and fungsiId='CS' ";
					conn.ExecuteQuery();
					t.NavigateUrl = conn.GetFieldValue("screenlink")+"?regno="+Request.QueryString["regno"]+"&prodid="+dt.Rows[i+j][1]+"&teks="+t.Text;
					t.Target = "prddetail";
					this.Table1.Rows[i].Cells.Add(new TableCell());
					//this.Table1.Rows[i].Cells[posisi].CssClass = "tdProductList";
					this.Table1.Rows[i].Cells[posisi].Text = (j+i+1) +". ";
					this.Table1.Rows[i].Cells[posisi].VerticalAlign=VerticalAlign.Top;
					//this.Table1.Rows[i].Cells[0].BorderColor =
					this.Table1.Rows[i].Cells.Add(new TableCell());
					//this.Table1.Rows[i].Cells[posisi+1].CssClass = "tdProductList";
					this.Table1.Rows[i].Cells[posisi+1].Controls.Add(t);
					this.Table1.Rows[i].Cells[posisi+1].VerticalAlign=VerticalAlign.Top;
					posisi +=2;
					/*if (newFacility == "1")
					{
						CheckBox t1 = new CheckBox();
						t1.ID = "check" + conn.GetFieldValue(i, 1);
				
						this.Table1.Rows[i].Cells.Add(new TableCell());
						this.Table1.Rows[i].Cells[1].Controls.Add(t1);

						TextBox t2 = new TextBox();
						t2.ID = "prodid" + conn.GetFieldValue(i, 1);
						t2.Text = conn.GetFieldValue(i, 1);
						t2.Visible = false;
				
						this.Table1.Rows[i].Cells.Add(new TableCell());
						this.Table1.Rows[i].Cells[1].Controls.Add(t2);
					}*/
				}
				jmlCell -=3;
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

		
	}
}
