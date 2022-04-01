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
namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for MainProductList.
	/// </summary>
	public partial class MainProductList : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				ddl_PRODUCTID.Items.Add(new ListItem("- SELECT -", ""));
				ddl_APPTYPE.Items.Add(new ListItem("- SELECT -", ""));

				conn.QueryString = "select * from RFPRODUCT where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					ddl_PRODUCTID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select * from RFAPPLICATIONTYPE where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					ddl_APPTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				ViewProductList();
				this.SecureData();
			}
			
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

		private void ViewProductList()
		{
			conn.QueryString = "select * from VW_DE_MAINPRODUCTLIST where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			for (int i =0; i < conn.GetRowCount(); i++)
			{
				this.Table1.Rows.Add(new TableRow());
				this.Table1.Rows[i+1].Cells.Add(new TableCell());
				this.Table1.Rows[i+1].Cells[0].CssClass = tool.ChangeListColor(i);
				this.Table1.Rows[i+1].Cells[0].Text = conn.GetFieldValue(i, 1);
				this.Table1.Rows[i+1].Cells.Add(new TableCell());
				this.Table1.Rows[i+1].Cells[1].CssClass = tool.ChangeListColor(i);
				this.Table1.Rows[i+1].Cells[1].Text = conn.GetFieldValue(i, 2);
				CheckBox t3 = new CheckBox();
				t3.ID = "check" + conn.GetFieldValue(i, 4) + conn.GetFieldValue(i, 3);
				this.Table1.Rows[i+1].Cells.Add(new TableCell());
				this.Table1.Rows[i+1].Cells[2].CssClass = tool.ChangeListColor(i);
				this.Table1.Rows[i+1].Cells[2].HorizontalAlign = HorizontalAlign.Center;
				this.Table1.Rows[i+1].Cells[2].Controls.Add(t3);
			}
			ddl_PRODUCTID.SelectedValue = "";
			ddl_APPTYPE.SelectedValue = "";
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

		protected void insert_Click(object sender, System.EventArgs e)
		{
//			conn.QueryString = "exec DE_MAIN_PRODUCTLIST '" + Request.QueryString["regno"] + "', '"+ddl_PRODUCTID.SelectedValue.ToString()+"', '"+ddl_APPTYPE.SelectedValue.ToString()+"','1', '0'";
//			conn.ExecuteQuery();
//			ViewProductList();

		}

		protected void delete_Click(object sender, System.EventArgs e)
		{
//			conn.QueryString = "select * from VW_DE_MAINPRODUCTLIST where ap_regno='" +Request.QueryString["regno"]+"'";
//			conn.ExecuteQuery();
//			int row = conn.GetRowCount();
//			for (int i = 0; i < row;i++) 
//			{
//				//Response.Write("check"+conn.GetFieldValue(i,4)+conn.GetFieldValue(i,3)+"<br>");
//				if (((CheckBox)Table1.FindControl("check"+conn.GetFieldValue(i, 4)+conn.GetFieldValue(i, 3))).Checked == true) 
//				{
//					conn.QueryString = "exec DE_MAIN_PRODUCTLIST '"+conn.GetFieldValue(i,0)+"', '" +conn.GetFieldValue(i,4)+ "', '"+conn.GetFieldValue(i, 3)+"', '2', '" + conn.GetFieldValue(i, "PROD_SEQ") + "'";
//					conn.ExecuteQuery();
//				}
//			}
		}
	}
}
