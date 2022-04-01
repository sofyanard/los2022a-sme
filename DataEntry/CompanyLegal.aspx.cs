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
	/// Summary description for CompanyLegal.
	/// </summary>
	public partial class CompanyLegal : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				DDL_CI_AGREEMNTDATE_MONTH.Items.Add(new ListItem("- SELECT -", ""));
				DDL_CI_CERTDATE_MONTH.Items.Add(new ListItem("- SELECT -", ""));
				DDL_CI_CERTMODDATE_MONTH.Items.Add(new ListItem("- SELECT -", ""));
				DDL_CI_MKAPPRVDATE_MONTH.Items.Add(new ListItem("- SELECT -", ""));
				DDL_CI_PNREGDATE_MONTH.Items.Add(new ListItem("- SELECT -", ""));
				DDL_CL_CERTTYPE.Items.Add(new ListItem("- SELECT -", ""));;
				DDL_CL_CERTDATE_MONTH.Items.Add(new ListItem("- SELECT -", ""));
				
				for (int i = 1; i <= 12; i++)
				{
					DDL_CI_AGREEMNTDATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CI_CERTDATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CI_CERTMODDATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CI_MKAPPRVDATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CI_PNREGDATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CL_CERTDATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				conn.QueryString = "select * from RFCERTTYPE where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_CL_CERTTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				ViewData();
				ViewCustLegal();
				this.SecureData();
			}
			ViewMenu();
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
			this.DatGridLegal.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGridLegal_ItemCommand);

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


		private void ViewData()
		{
			conn.QueryString = "select * from VW_DE_COMPANYLEGAL where cu_ref ='" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			
			if (conn.GetFieldValue("CI_ISCOMPLETE") == "1")
				RDO_CI_AGREEMNTSTA1.Checked = true;
			else
				RDO_CI_AGREEMNTSTA0.Checked = true;
			TXT_CI_CERTNO.Text			= conn.GetFieldValue("CI_CERTNO");
			TXT_CI_CERTDATE_DAY.Text	= tool.FormatDate_Day(conn.GetFieldValue("CI_CERTDATE").ToString());
			DDL_CI_CERTDATE_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("CI_CERTDATE").ToString());
			TXT_CI_CERTDATE_YEAR.Text	= tool.FormatDate_Year(conn.GetFieldValue("CI_CERTDATE").ToString());
			TXT_CI_NOTARY.Text			= conn.GetFieldValue("CI_NOTARY");
			TXT_CI_MKAPPRV.Text			= conn.GetFieldValue("CI_MKAPPRV");
			TXT_CI_MKAPPRVDATE_DAY.Text	= tool.FormatDate_Day(conn.GetFieldValue("CI_MKAPPRVDATE").ToString());
			DDL_CI_MKAPPRVDATE_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("CI_MKAPPRVDATE").ToString());
			TXT_CI_MKAPPRVDATE_YEAR.Text	= tool.FormatDate_Year(conn.GetFieldValue("CI_MKAPPRVDATE").ToString());
			TXT_CI_PNREGNO.Text				= conn.GetFieldValue("CI_PNREGNO");
			TXT_CI_PNREGDATE_DAY.Text		= tool.FormatDate_Day(conn.GetFieldValue("CI_PNREGDATE").ToString());
			DDL_CI_PNREGDATE_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("CI_PNREGDATE").ToString());
			TXT_CI_PNREGDATE_YEAR.Text		= tool.FormatDate_Year(conn.GetFieldValue("CI_PNREGDATE").ToString());
			TXT_CI_CERTMOD.Text				= conn.GetFieldValue("CI_CERTMOD");
			TXT_CI_CERTMODDATE_DAY.Text		= tool.FormatDate_Day(conn.GetFieldValue("CI_CERTMODDATE").ToString());
			DDL_CI_CERTMODDATE_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("CI_CERTMODDATE").ToString());
			TXT_CI_CERTMODDATE_YEAR.Text	= tool.FormatDate_Year(conn.GetFieldValue("CI_CERTMODDATE").ToString());
			TXT_CI_MODNOTARY.Text			= conn.GetFieldValue("CI_MODNOTARY");
			TXT_CI_AGREEMNTNO.Text			= conn.GetFieldValue("CI_AGREEMNTNO");
			TXT_CI_AGREEMNTDATE_DAY.Text	= tool.FormatDate_Day(conn.GetFieldValue("CI_AGREEMNTDATE").ToString());
			DDL_CI_AGREEMNTDATE_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("CI_AGREEMNTDATE").ToString());
			TXT_CI_AGREEMNTDATE_YEAR.Text	= tool.FormatDate_Year(conn.GetFieldValue("CI_AGREEMNTDATE").ToString());
			if (conn.GetFieldValue("CI_AGREEMNTSTA") == "1")
			{
				RDO_CI_AGREEMNTSTA1.Checked = true;
			}
			else
			{
				RDO_CI_AGREEMNTSTA0.Checked = true;
			}
		}

		private void ViewCustLegal()
		{
			DataTable dt = new DataTable();
			conn.QueryString = "select * from VW_CUSTLEGAL where CU_REF ='"+ Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGridLegal.DataSource = dt;
			DatGridLegal.DataBind();
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec SP_CUSTLEGAL '"+ Request.QueryString["curef"] +"', '"+ DDL_CL_CERTTYPE.SelectedValue +"', '"+
				TXT_CL_CERTNO.Text + "', " +tool.ConvertDate(TXT_CL_CERTDATE_DAY.Text,DDL_CL_CERTDATE_MONTH.SelectedValue,TXT_CL_CERTDATE_YEAR.Text)+", '"+
				TXT_CL_ATASNAMA.Text +"', '1'";
			conn.ExecuteQuery();
			ViewCustLegal();
			ClearDataCustLegal();
		}

		private void ClearDataCustLegal()
		{
			DDL_CL_CERTTYPE.SelectedValue	= "";
			TXT_CL_CERTNO.Text				= "";
			TXT_CL_CERTDATE_DAY.Text		= "";
			DDL_CL_CERTDATE_MONTH.SelectedValue = "";
			TXT_CL_CERTDATE_YEAR.Text		= "";
			TXT_CL_ATASNAMA.Text			= "";
		}

		private void DatGridLegal_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "exec SP_CUSTLEGAL '" +e.Item.Cells[0].Text+ "', '"+e.Item.Cells[1].Text+"','','','','2'";
					conn.ExecuteNonQuery();
					break;
			}
			ViewCustLegal();
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			string CI_ISCOMPLETE, CI_AGREEMNTSTA;
			if (RDO_CI_ISCOMPLETE1.Checked)
				CI_ISCOMPLETE = "1";
			else
				CI_ISCOMPLETE = "0";
			
			if (RDO_CI_AGREEMNTSTA1.Checked)
				CI_AGREEMNTSTA = "1";
			else
				CI_AGREEMNTSTA = "0";
			conn.QueryString = "exec DE_COMPANYLEGAL '"+ Request.QueryString["curef"] +"', '" +CI_ISCOMPLETE+ "', '" +
								TXT_CI_CERTNO.Text+ "', " +tool.ConvertDate(TXT_CI_CERTDATE_DAY.Text,DDL_CI_CERTDATE_MONTH.SelectedValue,TXT_CI_CERTDATE_YEAR.Text)+ 
								", '" +TXT_CI_NOTARY.Text+ "', '" +TXT_CI_MKAPPRV.Text+ "', " +tool.ConvertDate(TXT_CI_MKAPPRVDATE_DAY.Text,DDL_CI_MKAPPRVDATE_MONTH.SelectedValue,TXT_CI_MKAPPRVDATE_YEAR.Text)+
								", '" +TXT_CI_PNREGNO.Text+ "', '" +TXT_CI_CERTMOD.Text+ "', " +tool.ConvertDate(TXT_CI_CERTMODDATE_DAY.Text,DDL_CI_CERTMODDATE_MONTH.SelectedValue,TXT_CI_CERTMODDATE_YEAR.Text)+
								", '" +TXT_CI_MODNOTARY.Text+ "', '" +TXT_CI_AGREEMNTNO.Text+ "', " +tool.ConvertDate(TXT_CI_AGREEMNTDATE_DAY.Text,DDL_CI_AGREEMNTDATE_MONTH.SelectedValue,TXT_CI_AGREEMNTDATE_YEAR.Text)+
								", '" +CI_AGREEMNTSTA+ "', " +tool.ConvertDate(TXT_CI_PNREGDATE_DAY.Text,DDL_CI_PNREGDATE_MONTH.SelectedValue,TXT_CI_PNREGDATE_YEAR.Text)+"'','','','0'";
			conn.ExecuteNonQuery();
			ViewData();
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
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}

	}
}
