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
	/// Summary description for eBizCardPola.
	/// </summary>
	public partial class eBizCardPola : System.Web.UI.Page
	{

		#region " Variables "
		private Tools tool = new Tools();
		private Connection conn;
		private string regno, appType, productId, prod_seq;
		#endregion
		protected string v_disttype;
		



		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn		= (Connection) Session["Connection"];
			regno		= Request.QueryString["regno"];
			appType		= Request.QueryString["apptype"];
			productId	= Request.QueryString["productid"];
			prod_seq	= Request.QueryString["prod_seq"];

			if (!IsPostBack) 
			{
				TBL_INPUT.Visible = false;
				GlobalTools.initDateForm(TXT_EBIZ_ISSUE_DAY, DDL_EBIZ_ISSUE_MONTH, TXT_EBIZ_ISSUE_YEAR);
			
				string query1 = "select * from rfdistributor";
			
				GlobalTools.fillRefList(DDL_DIST, query1, false, conn);

				viewData();

			}
			secureData();
			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			BTN_SAVEDIST.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
		}

		private void secureData() 
		{
			if (Request.QueryString["de"] != "1") 
			{
				int index = -1;
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for(int j=0; j<coll.Count; j++) 
				{
					if (coll[j] is System.Web.UI.HtmlControls.HtmlForm) 
					{
						index = j;
						break;
					}
				}

				/// Kalau ngga ketemu indexnya, secure/disable secara manual
				/// 
				if (index == -1) 
				{
					TXT_EBIZ_FIRSTNAME.ReadOnly = true;
					TXT_EBIZ_LASTNAME.ReadOnly = true;
					TXT_EBIZ_MIDDLENAME.ReadOnly = true;

					TXT_EBIZ_IDCARDNUM.ReadOnly = true;
					TXT_EBIZ_ISSUE_DAY.ReadOnly = true;
					DDL_EBIZ_ISSUE_MONTH.Enabled = false;
					TXT_EBIZ_ISSUE_YEAR.ReadOnly = true;
					
					TXT_ENDORSENAME_1.ReadOnly = true;
					TXT_ENDORSENAME_2.ReadOnly = true;
					BTN_NEW.Visible = false;
					DDL_DIST.Enabled = false;
					DDL_DISTCODE.Enabled = false;
					BTN_SAVEDIST.Visible = false;
					
					return;
				}


				for (int i = 0; i < coll[index].Controls.Count; i++) 
				{
					if (coll[index].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[index].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[index].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[index].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[index].Controls[i] is Button)
					{
						Button btn = (Button) coll[index].Controls[i];
						btn.Visible = false;
					}
					else if (coll[index].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[index].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[index].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[index].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[index].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[index].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[index].Controls[i] is DataGrid) 
					{						
						DataGrid dg = (DataGrid) coll[index].Controls[i];						
						//dg.Columns[6].Visible = false;sadff
						for (int j = 0; j < dg.Items.Count; j++) 
						{
							dg.Items[j].Cells[6].Enabled = false;							
							dg.Items[j].Cells[6].Text = "Delete";
						}
					}
					else if (coll[index].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[index].Controls[i];

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
				} // end for


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
			this.DGR_EBIZ.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_EBIZ_ItemCommand);
			this.DGR_EBIZ.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_EBIZ_PageIndexChanged);
			this.DGR_EBIZ.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DGR_EBIZ_SortCommand);

		}
		#endregion

		#region " Defined Methods "

		private void disableAllButtons() 
		{
			BTN_NEW.Visible		= false;
			BTN_SAVE.Visible	= false;
			BTN_UPDATE.Visible	= false;
			BTN_CANCEL.Visible	= false;
		}

		private void setButtonStatus(bool isEdit, bool isNew) 
		{
				BTN_UPDATE.Visible	= isEdit;
				BTN_CANCEL.Visible	= isEdit;
				BTN_SAVE.Visible	= !isEdit;

				TBL_INPUT.Visible = isNew;

				BTN_NEW.Visible = !isNew;
				BTN_SAVE.Visible = isNew;
				BTN_CANCEL.Visible = isNew;
			
		}

		private void clearInputs() 
		{
			TXT_EBIZ_FIRSTNAME.Text		= "";
			TXT_EBIZ_MIDDLENAME.Text	= "";
			TXT_EBIZ_LASTNAME.Text		= "";
			TXT_EBIZ_IDCARDNUM.Text		= "";
			TXT_EBIZ_ISSUE_DAY.Text		= "";
			DDL_EBIZ_ISSUE_MONTH.SelectedValue = "";
			TXT_EBIZ_ISSUE_YEAR.Text	= "";
			TXT_ENDORSENAME_1.Text		= "";
			TXT_ENDORSENAME_2.Text		= "";
		}

		private void viewData() 
		{
			try 
			{
				conn.QueryString = "select isnull(FIRSTNAME,'') + ' ' + isnull(MIDDLENAME,'') + ' ' + isnull(LASTNAME,'') as NAME, * " + 
									"from EBIZCARDINFO where AP_REGNO = '" + regno + 
									"' and apptype = '" + appType + 
									"' and productid = '" + productId + 
									"' and prod_seq = '" + prod_seq + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			DGR_EBIZ.DataSource = conn.GetDataTable().DefaultView;
			DGR_EBIZ.DataBind();

			////// lihat isi disttype dan distcode di tabel ketentuan_kredit

			conn.QueryString = "select disttype,distcode from ketentuan_kredit where productid='"+productId+"' "+
				"and ap_regno ='"+regno+"'";
			conn.ExecuteQuery();
			string v_disttype= conn.GetFieldValue("disttype");
			string v_distcode= conn.GetFieldValue("distcode");

			if (v_distcode != "" )	// jika disttype dan distcode tdk NULL		
			{ 
				conn.QueryString = "select distid from rfdistributor where disttype = '"+v_disttype+"'";
				conn.ExecuteQuery();

				try
				{
					DDL_DIST.SelectedValue = conn.GetFieldValue("distid");
				}
				catch{}
				
				////// isi ddl_distcode
				///
				string query2 = "select distcode, distdesc from rfdistributorcode "+
					"where disttype = '"+ v_disttype +"' ";
			
				GlobalTools.fillRefList(DDL_DISTCODE, query2, false, conn);
				try
				{
					DDL_DISTCODE.SelectedValue = v_distcode;
				}
				catch{}
			}


		}

		private void viewDataEntry() 
		{
			
			try 
			{
				conn.QueryString = "select * from EBIZCARDINFO where AP_REGNO = '" + regno + 
					"' and apptype = '" + appType + 
					"' and productid = '" + productId + 
					"' and prod_seq = '" + prod_seq + "'";
				conn.ExecuteQuery();
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			TXT_EBIZ_FIRSTNAME.Text = conn.GetFieldValue("firstname");
			TXT_EBIZ_MIDDLENAME.Text = conn.GetFieldValue("middlename");
			TXT_EBIZ_LASTNAME.Text = conn.GetFieldValue("lastname");
			TXT_EBIZ_IDCARDNUM.Text = conn.GetFieldValue("idcardnum");
			try 
			{
				GlobalTools.fromSQLDate(conn.GetFieldValue("issuancedate"), TXT_EBIZ_ISSUE_DAY, DDL_EBIZ_ISSUE_MONTH, TXT_EBIZ_ISSUE_YEAR);
			} 
			catch {}
			TXT_ENDORSENAME_1.Text = conn.GetFieldValue("endorsename_1");
			TXT_ENDORSENAME_2.Text = conn.GetFieldValue("endorsename_2");
		}


		#endregion

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{		
			try 
			{
				conn.QueryString = "exec DE_EBIZCARD '" + regno + "', '', '" + TXT_EBIZ_FIRSTNAME.Text.Trim() + 
									"', " + tool.ConvertNull(TXT_EBIZ_MIDDLENAME.Text.Trim()) + 
									", " + tool.ConvertNull(TXT_EBIZ_LASTNAME.Text.Trim()) + 
									", " + tool.ConvertNull(TXT_EBIZ_IDCARDNUM.Text.Trim()) + 
									", " + GlobalTools.ToSQLDate(TXT_EBIZ_ISSUE_DAY.Text, DDL_EBIZ_ISSUE_MONTH.SelectedValue, TXT_EBIZ_ISSUE_YEAR.Text) + 
									", " + tool.ConvertNull(TXT_ENDORSENAME_1.Text.Trim()) + 
									", " + tool.ConvertNull(TXT_ENDORSENAME_2.Text.Trim()) + 
									", '1', '" + appType + 
									"', '" + productId + 
									"', '" + prod_seq + "'";
				conn.ExecuteNonQuery();
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			viewData();

			clearInputs();
			disableAllButtons();
			TBL_INPUT.Visible	= false;
			BTN_NEW.Visible		= true;
		}

		private void DGR_EBIZ_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_EBIZ.CurrentPageIndex = e.NewPageIndex;
			viewData();
		}

		private void DGR_EBIZ_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (e.CommandName.ToString()) 
			{
				case "edit":
					disableAllButtons();
					TBL_INPUT.Visible = true;
					BTN_UPDATE.Visible = true;
					BTN_CANCEL.Visible = true;

					LBL_SEQ.Text = e.Item.Cells[1].Text;
					viewDataEntry();					
					break;

				case "delete":
					try 
					{
						conn.QueryString = "exec DE_EBIZCARD '" + regno + "', '" + e.Item.Cells[1].Text + 
							"','','','','','','', '', '3', '" + appType + "', '" + productId + "', '" + prod_seq + "'";
						conn.ExecuteNonQuery();
					}
					catch (NullReferenceException) 
					{
						GlobalTools.popMessage(this, "Connection Error!");
						Response.Redirect("../Login.aspx?expire=1");
					}
					viewData();
					break;
			}			
		}

		private void DGR_EBIZ_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
		
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{			
			try 
			{
				conn.QueryString = "exec DE_EBIZCARD '" + regno + 
					"', '" + LBL_SEQ.Text + 
					"', '" + TXT_EBIZ_FIRSTNAME.Text.Trim() + 
					"', " + tool.ConvertNull(TXT_EBIZ_MIDDLENAME.Text.Trim()) + 
					", " + tool.ConvertNull(TXT_EBIZ_LASTNAME.Text.Trim()) + 
					", " + tool.ConvertNull(TXT_EBIZ_IDCARDNUM.Text.Trim()) + 
					", " + GlobalTools.ToSQLDate(TXT_EBIZ_ISSUE_DAY.Text, DDL_EBIZ_ISSUE_MONTH.SelectedValue, TXT_EBIZ_ISSUE_YEAR.Text) + 
					", " + tool.ConvertNull(TXT_ENDORSENAME_1.Text.Trim()) + 
					", " + tool.ConvertNull(TXT_ENDORSENAME_2.Text.Trim()) + 
					", '2', '" + appType + "', '" + productId + "', '" + prod_seq + "'";
				conn.ExecuteNonQuery();
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}


			viewData();
			disableAllButtons();
			TBL_INPUT.Visible	= false;
			BTN_NEW.Visible		= true;
			clearInputs();
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			disableAllButtons();
			clearInputs();
			TBL_INPUT.Visible	= false;
			BTN_NEW.Visible		= true;
		}

		protected void BTN_NEW_Click(object sender, System.EventArgs e)
		{
			disableAllButtons();
			TBL_INPUT.Visible	= true;
			BTN_SAVE.Visible	= true;
			BTN_CANCEL.Visible	= true;
		}

		protected void DDL_DIST_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// ambil disttype di tabel rfdistributor untuk mengisi ddl_distcode
			conn.QueryString = "select disttype from rfdistributor where distid ='"+DDL_DIST.SelectedValue+"' ";
			conn.ExecuteQuery();
			LBL_DISTTYPE.Text = conn.GetFieldValue("disttype");

			// isi ddl_distcode
			string query = "select distcode, distdesc from rfdistributorcode "+
				    		"where disttype = '"+ LBL_DISTTYPE.Text.Trim() +"' ";
			
			GlobalTools.fillRefList(DDL_DISTCODE, query, false, conn);
			
		}

		protected void BTN_SAVEDIST_Click(object sender, System.EventArgs e)
		{	
			conn.QueryString = "update ketentuan_kredit set disttype='"+LBL_DISTTYPE.Text.Trim()+"' "+
				               ", distcode ='"+DDL_DISTCODE.SelectedValue+"' where productid='"+productId+"' "+
							   "and ap_regno ='"+regno+"' ";
			conn.ExecuteQuery();
		}
	}
}
