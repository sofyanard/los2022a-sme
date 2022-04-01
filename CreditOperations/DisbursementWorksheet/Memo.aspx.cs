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
using Microsoft.VisualBasic;
namespace SME.DisbursementWorksheet
{
	/// <summary>
	/// Summary description for Memo.
	/// </summary>
	public partial class MemoDE : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			isiGrid();
			ViewMenu();
			//this.SecureData();
		}

		private void SecureData() 
		{
			// Jika yang memanggil bukan dalam scope DataEntry, maka disable semua control input
			// Flag :sadfasfsafsfasdfasfd
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
		void isiGrid()
		{
			DataTable dt = new DataTable();
			conn.QueryString="Select * from vw_memo where ap_regno='" + Request.QueryString["regno"] + "' order by tm_date desc";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = 0;
				DatGrd.DataBind();
			}
			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				DatGrd.Items[i].Cells[2].Text = ""+tool.FormatDate_Day(DatGrd.Items[i].Cells[2].Text)+"-"+tool.FormatDate_MonthName(DatGrd.Items[i].Cells[2].Text)+"-"+tool.FormatDate_Year(DatGrd.Items[i].Cells[2].Text)+"";
				if (DatGrd.Items[i].Cells[7].Text.Trim()!=Session["UserID"].ToString().Trim())
					DatGrd.Items[i].Cells[6].Enabled = false;
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);

		}
		#endregion

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			isiGrid();
		}


		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if (TXT_REGNO.Text =="")//insert
			{
				if (TXT_TM_CONTENT.Text.Trim() != "")
				{
					conn.QueryString="exec de_memo '" + Request.QueryString["regno"] + "','','','"+ TXT_TM_CONTENT.Text +"','" + Session["UserID"].ToString() + "',0";
					conn.ExecuteQuery();
					isiGrid();
				
				}
			}
			else //update
			{
				conn.QueryString="exec de_memo '" + Request.QueryString["regno"] + "',"+ tool.ConvertNum(TXT_TMSEQ.Text) +",'','"+ TXT_TM_CONTENT.Text +"','" + Session["UserID"].ToString() + "',2";
				conn.ExecuteQuery();
				isiGrid();
				TXT_REGNO.Text="";
				TXT_TMSEQ.Text="";
			}
			TXT_TM_CONTENT.Text="";
		}


		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string userid = Session["UserID"].ToString().Trim();
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "Delete":	
					if (e.Item.Cells[7].Text.Trim()==userid)
					{
						conn.QueryString="exec de_memo '"+ e.Item.Cells[0].Text +"',"+ tool.ConvertNum(e.Item.Cells[1].Text) +",'','','',1 ";
						conn.ExecuteQuery();
	
						int index = DatGrd.Items.Count;
						int jml = (index % 3)-1;
						if (jml == 0)
							DatGrd.CurrentPageIndex = index/3;
					}
					break;

				case "Edit":
					if (e.Item.Cells[7].Text.Trim()==userid)
					{
						conn.QueryString="select tm_content from vw_memo where ap_regno ='"+ e.Item.Cells[0].Text +"' and tm_seq = "+tool.ConvertNum(e.Item.Cells[1].Text)+" ";
						conn.ExecuteQuery();
						TXT_TM_CONTENT.Text = conn.GetFieldValue("tm_content");//"select tm_content from vw_memo where ap_regno ='"+ e.Item.Cells[0].Text +"' and tm_seq = "+tool.ConvertNum(e.Item.Cells[0].Text)+" ";//conn.GetFieldValue("TM_content");
						TXT_REGNO.Text = e.Item.Cells[0].Text;
						TXT_TMSEQ.Text = e.Item.Cells[1].Text;
						//Server.Transfer("Memo.aspx?Edit=1");
					}
					break;
				default:
					// Do nothing.
					break;
			}
			isiGrid();
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
						strtemp = strtemp + "&de=" + Request.QueryString["de"];
						strtemp = strtemp + "&par=" + Request.QueryString["par"];
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
			if (Request.QueryString["par"] != null && Request.QueryString["par"] != "")  
				Response.Redirect(Request.QueryString["par"] + "&regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"]);
			else if (Request.QueryString["mc"] != "" && Request.QueryString["mc"] != null)
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn));			
			else
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}
	}
}
