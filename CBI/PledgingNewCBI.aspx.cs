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

namespace SME.CBI
{
	/// <summary>
	/// Summary description for PledgingNew.
	/// </summary>
	public partial class PledgingNewCBI : System.Web.UI.Page
	{
		protected Connection conn;
		double totlimit = 0.0, totbade = 0.0, totcollimit = 0.0,
			totratiolimit = 0.0, totratiobade = 0.0;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (Request.QueryString["de"] == "1")
				if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
					Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				ViewData();
				SecureData();
			}
			
			ViewMenu();
		}

		private void FillDDLGroup()
		{
			DDL_GROUP.Items.Clear();
            conn.QueryString = "SELECT PL_SEQ, PL_SEQ as PL_SEQ_DESC FROM VW_PLEDGINGGROUP WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' ORDER BY PL_SEQ";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_GROUP.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			if (DDL_GROUP.Items.Count == 0)
				DDL_GROUP.Items.Add(new ListItem("0", "0"));
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				string mc1 = Request.QueryString["mc"];
				string mc2 = Request.QueryString["mc"];
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
						if (conn.GetFieldValue(i,3).IndexOf("?de=") < 0 && conn.GetFieldValue(i,3).IndexOf("&de=") < 0) 
							strtemp = strtemp + "&de=" + Request.QueryString["de"];	
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
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
				int index = -1;
				
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for(int j=0; j<coll.Count; j++) 
				{
					if (coll[j] is HtmlForm) 
					{
						index = j;
						break;
					}
				}
	
				for (int i = 0; i < coll[index].Controls.Count; i++) 
				{
					if (coll[index].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[index].Controls[i];
						txt.ReadOnly = true;
						//txt.Enabled = false;
					}
					else if (coll[index].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[index].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[index].Controls[i] is Button)
					{
						Button btn = (Button) coll[index].Controls[i];
						//btn.Enabled = false;
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
						if (dg.ID == "DG_PLEDGINGMAIN")
							try 
							{
								for (int j = 0; j < dg.Items.Count; j++)
								{
									dg.Items[j].Cells[3].Enabled = false;
									dg.Items[j].Cells[3].Text = "Delete";

									DataGrid dgf = (DataGrid) dg.Items[j].Cells[1].FindControl("DG_PLEDGINGFAC");
									for (int k = 0; k < dgf.Items.Count; k++)
									{
										dgf.Items[k].Cells[9].Enabled = false;
										dgf.Items[k].Cells[9].Text = "Delete";
									}

									DataGrid dgc = (DataGrid) dg.Items[j].Cells[2].FindControl("DG_PLEDGINGCOL");
									for (int l = 0; l < dgc.Items.Count; l++)
									{
										dgc.Items[l].Cells[7].Enabled = false;
										dgc.Items[l].Cells[7].Text = "Delete";
									}
								}
							}
							catch (ArgumentOutOfRangeException ex) 
							{
								// ignore...
							}
					}
				}
			}
		}

		private void ViewData()
		{
			FillDDLGroup();
			ViewCustFacility();
			ViewCustCollateral();
			ViewPledging();
		}

		private void ViewCustFacility()
		{
			conn.QueryString = "EXEC DDE_PLEDGING_VIEWCUSTFACILITY '" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_CUSTFAC.DataSource = dt;
			try 
			{
				DG_CUSTFAC.DataBind();
			} 
			catch 
			{
				DG_CUSTFAC.CurrentPageIndex = 0;
				DG_CUSTFAC.DataBind();
			}
		}

		private void ViewCustCollateral()
		{
			conn.QueryString = "EXEC DDE_PLEDGING_VIEWCUSTCOLLATERAL '" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_CUSTCOL.DataSource = dt;
			try 
			{
				DG_CUSTCOL.DataBind();
			} 
			catch 
			{
				DG_CUSTCOL.CurrentPageIndex = 0;
				DG_CUSTCOL.DataBind();
			}
		}

		private void ViewPledging()
		{
			conn.QueryString = "SELECT * FROM VW_PLEDGINGGROUP WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_PLEDGINGMAIN.DataSource = dt;
			try 
			{
				DG_PLEDGINGMAIN.DataBind();
			} 
			catch 
			{
				DG_PLEDGINGMAIN.CurrentPageIndex = 0;
				DG_PLEDGINGMAIN.DataBind();
			}

			for (int i=0;i<DG_PLEDGINGMAIN.Items.Count;i++)
			{
				LinkButton lbdelgrp = (LinkButton)DG_PLEDGINGMAIN.Items[i].Cells[3].FindControl("lb_delgroup");
				lbdelgrp.Attributes.Add("onclick","if(!deleteconfirm()){return false;};");
			}

			ViewPledgingFacility();
			ViewPledgingCollateral();
			ViewListPledging();
		}

		private void ViewPledgingFacility()
		{
			for (int i=0;i<DG_PLEDGINGMAIN.Items.Count;i++)
			{
				DataGrid dgfac = (DataGrid) DG_PLEDGINGMAIN.Items[i].Cells[1].FindControl("DG_PLEDGINGFAC");

				conn.QueryString = "EXEC DDE_PLEDGING_VIEWGROUPFACILITY '" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "', " + DG_PLEDGINGMAIN.Items[i].Cells[0].Text.Trim();
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtfac = new DataTable();
					dtfac = conn.GetDataTable().Copy();

					totlimit = (double)dtfac.Compute("sum(limit)", "");
					totbade = (double)dtfac.Compute("sum(baki_debet)", "");
					totratiolimit = (double)dtfac.Compute("sum(ratio_limit)", "");
					totratiobade = (double)dtfac.Compute("sum(ratio_bade)", "");

					dgfac.DataSource = dtfac;
					try 
					{
						dgfac.DataBind();
					} 
					catch 
					{
						dgfac.CurrentPageIndex = 0;
						dgfac.DataBind();
					}
				}
			}
		}

		private void ViewPledgingCollateral()
		{
			for (int i=0;i<DG_PLEDGINGMAIN.Items.Count;i++)
			{
				DataGrid dgcol = (DataGrid) DG_PLEDGINGMAIN.Items[i].Cells[2].FindControl("DG_PLEDGINGCOL");
				string k = DG_PLEDGINGMAIN.Items[i].Cells[0].Text.Trim();

				conn.QueryString = "EXEC DDE_PLEDGING_VIEWGROUPCOLLATERAL '" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "', " + DG_PLEDGINGMAIN.Items[i].Cells[0].Text.Trim();
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtcol = new DataTable();
					dtcol = conn.GetDataTable().Copy();

					try
					{
						totcollimit = (double)dtcol.Compute("sum(cl_value)", "");
					}
					catch
					{
						totcollimit = 0.0;
					}

					dgcol.DataSource = dtcol;
					try 
					{
						dgcol.DataBind();
					} 
					catch 
					{
						dgcol.CurrentPageIndex = 0;
						dgcol.DataBind();
					}
				}
			}
		}

		private void ViewListPledging()
		{
			conn.QueryString = "SELECT AA_NO, PRODUCTID, ACC_SEQ, ACC_NO, CU_REF, CL_SEQ, CL_DESC, SIBS_COLID, PERCENTAGE FROM VW_PLEDGINGALLLIST WHERE AP_REGNO = '" + 
				Request.QueryString["regno"] + "' ORDER BY AA_NO, PRODUCTID, ACC_SEQ, ACC_NO, CU_REF, CL_SEQ";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_LISTPLEDGING.DataSource = dt;
			try 
			{
				DG_LISTPLEDGING.DataBind();
			} 
			catch 
			{
				DG_LISTPLEDGING.CurrentPageIndex = 0;
				DG_LISTPLEDGING.DataBind();
			}
		}

		private void UpdateListCollateral()
		{
			conn.QueryString = "EXEC DDE_PLEDGING_UPDATE_LISTCOLLATERAL '" + Request.QueryString["regno"] + "'";
			conn.ExecuteNonQuery();
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
			this.DG_CUSTFAC.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_CUSTFAC_ItemCommand);
			this.DG_CUSTFAC.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_CUSTFAC_PageIndexChanged);
			this.DG_CUSTFAC.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DG_CUSTFAC_ItemDataBound);
			this.DG_CUSTCOL.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_CUSTCOL_ItemCommand);
			this.DG_CUSTCOL.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_CUSTCOL_PageIndexChanged);
			this.DG_CUSTCOL.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DG_CUSTCOL_ItemDataBound);
			this.DG_PLEDGINGMAIN.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DG_PLEDGINGMAIN_ItemCreated);
			this.DG_PLEDGINGMAIN.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_PLEDGINGMAIN_ItemCommand);
			this.DG_PLEDGINGMAIN.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_PLEDGINGMAIN_PageIndexChanged);
			this.DG_LISTPLEDGING.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_LISTPLEDGING_PageIndexChanged);
			this.DG_LISTPLEDGING.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DG_LISTPLEDGING_ItemDataBound);

		}
		#endregion

		protected void BTN_ADD_Click(object sender, System.EventArgs e)
		{
			if (DDL_GROUP.SelectedValue == "")
			{
				Tools.popMessage(this,"Please select one group!");
				return;
			}

			try
			{
				for (int i=0; i<DG_CUSTFAC.Items.Count; i++)
				{
					CheckBox cbf = (CheckBox) DG_CUSTFAC.Items[i].FindControl("chk_pledgefac");
					if (cbf.Checked == true)
					{
						conn.QueryString = "EXEC DDE_PLEDGING_ADDFACILITY '" +
							Request.QueryString["regno"] + "', '" +
							DG_CUSTFAC.Items[i].Cells[8].Text.Trim() + "', '" +
							DDL_GROUP.SelectedValue.Trim() + "', '" +
							DG_CUSTFAC.Items[i].Cells[0].Text.Trim() + "', '" +
							DG_CUSTFAC.Items[i].Cells[1].Text.Trim() + "', '" +
							DG_CUSTFAC.Items[i].Cells[2].Text.Trim() + "', '" +
							DG_CUSTFAC.Items[i].Cells[3].Text.Trim() + "'";
						conn.ExecuteNonQuery();
					}
				}

				for (int i=0; i<DG_CUSTCOL.Items.Count; i++)
				{
					CheckBox cbc = (CheckBox) DG_CUSTCOL.Items[i].FindControl("chk_pledgecol");
					if (cbc.Checked == true)
					{
						conn.QueryString = "EXEC DDE_PLEDGING_ADDCOLLATERAL '" +
							Request.QueryString["regno"] + "', '" +
							Request.QueryString["curef"] + "', '" +
							DDL_GROUP.SelectedValue.Trim() + "', '" +
							DG_CUSTCOL.Items[i].Cells[0].Text.Trim() + "', '" +
							DG_CUSTCOL.Items[i].Cells[1].Text.Trim() + "'";
						conn.ExecuteNonQuery();
					}
				}

				UpdateListCollateral();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
				Tools.popMessage(this,"Insert Error!!");
			}

			ViewData();
		}

		private void DG_CUSTFAC_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_CUSTFAC.CurrentPageIndex = e.NewPageIndex;
			ViewCustFacility();
		}

		private void DG_CUSTCOL_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_CUSTCOL.CurrentPageIndex = e.NewPageIndex;
			ViewCustCollateral();
		}

		private void DG_CUSTFAC_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i;
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "allfac":
					for (i = 0; i < DG_CUSTFAC.PageSize; i++)
					{
						try
						{
							CheckBox cb = (CheckBox) DG_CUSTFAC.Items[i].FindControl("chk_pledgefac");
							cb.Checked = true;
						} 
						catch {}
					}
					break;
				default:
					break;
			}
		}

		private void DG_CUSTCOL_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i;
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "allcol":
					for (i = 0; i < DG_CUSTCOL.PageSize; i++)
					{
						try
						{
							CheckBox cb = (CheckBox) DG_CUSTCOL.Items[i].FindControl("chk_pledgecol");
							cb.Checked = true;
						} 
						catch {}
					}
					break;
				default:
					break;
			}
		}

		private void DG_PLEDGINGMAIN_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_PLEDGINGMAIN.CurrentPageIndex = e.NewPageIndex;
			ViewPledging();
			SecureData();
		}

		private void DG_PLEDGINGMAIN_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					try
					{
						conn.QueryString = "EXEC DDE_PLEDGING_DELETEGROUP '" +
							Request.QueryString["regno"] + "', '" +
							Request.QueryString["curef"] + "', '" +
							e.Item.Cells[0].Text + "'";
						conn.ExecuteNonQuery();

						UpdateListCollateral();
					}
					catch (Exception ex)
					{
						Response.Write("<!--" + ex.Message + "-->");
						Tools.popMessage(this,"Delete Error!!");
					}

					ViewData();
					break;
			}
		}

		private void dgfac_PageIndexChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			dg.CurrentPageIndex = e.NewPageIndex;
			ViewPledgingFacility();
			SecureData();
		}

		private void dgcol_PageIndexChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			dg.CurrentPageIndex = e.NewPageIndex;
			ViewPledgingCollateral();
			SecureData();
		}

		protected void BTN_NEW_Click(object sender, System.EventArgs e)
		{
			int t = 0;
			for (int i=0; i<DDL_GROUP.Items.Count; i++)
			{
				t = Math.Max(int.Parse(DDL_GROUP.Items[i].Text),t);
			}
			t++;
			DDL_GROUP.Items.Add(new ListItem(t.ToString(), t.ToString()));
		}

		private void dgfac_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			double ilimit, ibade, iratiolimit, iratiobade;
			switch (e.Item.ItemType)
			{
				case ListItemType.AlternatingItem:
				case ListItemType.EditItem:
				case ListItemType.Item:
				case ListItemType.SelectedItem:
					try
					{
						ilimit = double.Parse(e.Item.Cells[5].Text);
						e.Item.Cells[5].Text = ilimit.ToString("#,##0.#");
					} 
					catch {}
					try
					{
						ibade = double.Parse(e.Item.Cells[6].Text);
						e.Item.Cells[6].Text = ibade.ToString("#,##0.#");
					} 
					catch {}
					try
					{
						iratiolimit = double.Parse(e.Item.Cells[7].Text);
						e.Item.Cells[7].Text = iratiolimit.ToString("#,##0.#0");
					} 
					catch {}
					try
					{
						iratiobade = double.Parse(e.Item.Cells[8].Text);
						e.Item.Cells[8].Text = iratiobade.ToString("#,##0.#0");
					} 
					catch {}
					break;
				case ListItemType.Footer:
					e.Item.Cells[0].Text = "TOTAL";
					e.Item.Cells[5].Text = totlimit.ToString("#,##0.#");
					e.Item.Cells[6].Text = totbade.ToString("#,##0.#");
					e.Item.Cells[7].Text = totratiolimit.ToString("#,##0.#0");
					e.Item.Cells[8].Text = totratiobade.ToString("#,##0.#0");
					break;
				default:
					break;
			}
		}

		private void dgcol_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			double ilimit;
			switch (e.Item.ItemType)
			{
				case ListItemType.AlternatingItem:
				case ListItemType.EditItem:
				case ListItemType.Item:
				case ListItemType.SelectedItem:
					try
					{
						ilimit = double.Parse(e.Item.Cells[6].Text);
						//totcollimit += ilimit;
						e.Item.Cells[6].Text = ilimit.ToString("#,##0.#");
					} 
					catch {}
					break;
				case ListItemType.Footer:
					e.Item.Cells[3].Text = "TOTAL";
					e.Item.Cells[6].Text = totcollimit.ToString("#,##0.#");
					break;
				default:
					break;
			}
		}

		private void dgfac_ItemCommand(object sender, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					try
					{
						conn.QueryString = "EXEC DDE_PLEDGING_DELETEFACILITY '" +
							Request.QueryString["regno"] + "', '" +
							Request.QueryString["curef"] + "', '" +
							"', '" +
							e.Item.Cells[0].Text + "', '" +
							e.Item.Cells[1].Text + "', '" +
							e.Item.Cells[2].Text + "', '" +
							e.Item.Cells[3].Text + "'";
						conn.ExecuteNonQuery();

						UpdateListCollateral();
					}
					catch (Exception ex)
					{
						Response.Write("<!--" + ex.Message + "-->");
						Tools.popMessage(this,"Delete Error!!");
					}

					ViewData();
					break;
			}
		}

		private void dgcol_ItemCommand(object sender, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					try
					{
						conn.QueryString = "EXEC DDE_PLEDGING_DELETECOLLATERAL '" +
							Request.QueryString["regno"] + "', '" +
							Request.QueryString["curef"] + "', '" +
							"', '" +
							e.Item.Cells[0].Text + "', '" +
							e.Item.Cells[1].Text + "'";
						conn.ExecuteNonQuery();

						UpdateListCollateral();
					}
					catch (Exception ex)
					{
						Response.Write("<!--" + ex.Message + "-->");
						Tools.popMessage(this,"Delete Error!!");
					}

					ViewData();
					break;
			}
		}

		private void DG_PLEDGINGMAIN_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			DataGrid dgfac = (DataGrid) e.Item.FindControl("DG_PLEDGINGFAC");
			DataGrid dgcol = (DataGrid) e.Item.FindControl("DG_PLEDGINGCOL");
			if (dgfac != null)
			{
				dgfac.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgfac_PageIndexChanged);
				dgfac.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgfac_ItemDataBound);
				dgfac.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgfac_ItemCommand);

				dgcol.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgcol_PageIndexChanged);
				dgcol.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgcol_ItemDataBound);
				dgcol.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgcol_ItemCommand);
			}
		}

		private void DG_CUSTFAC_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			double ilimit, ibade;
			switch (e.Item.ItemType)
			{
				case ListItemType.AlternatingItem:
				case ListItemType.EditItem:
				case ListItemType.Item:
				case ListItemType.SelectedItem:
					try
					{
						ilimit = double.Parse(e.Item.Cells[5].Text);
						e.Item.Cells[5].Text = ilimit.ToString("#,##0.#");
					} 
					catch {}
					try
					{
						ibade = double.Parse(e.Item.Cells[6].Text);
						e.Item.Cells[6].Text = ibade.ToString("#,##0.#");
					} 
					catch {}
					break;
				case ListItemType.Footer:
					break;
				default:
					break;
			}
		}

		private void DG_CUSTCOL_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			double ilimit;
			switch (e.Item.ItemType)
			{
				case ListItemType.AlternatingItem:
				case ListItemType.EditItem:
				case ListItemType.Item:
				case ListItemType.SelectedItem:
					try
					{
						ilimit = double.Parse(e.Item.Cells[6].Text);
						e.Item.Cells[6].Text = ilimit.ToString("#,##0.#");
					} 
					catch {}
					break;
				case ListItemType.Footer:
					break;
				default:
					break;
			}
		}

		private void DG_LISTPLEDGING_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_LISTPLEDGING.CurrentPageIndex = e.NewPageIndex;
			ViewListPledging();
		}

		private void DG_LISTPLEDGING_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			double percent;
			switch (e.Item.ItemType)
			{
				case ListItemType.AlternatingItem:
				case ListItemType.EditItem:
				case ListItemType.Item:
				case ListItemType.SelectedItem:
					try
					{
						percent = double.Parse(e.Item.Cells[8].Text);
						e.Item.Cells[8].Text = percent.ToString("#,##0.#0");
					} 
					catch {}
					break;
				case ListItemType.Footer:
					break;
				default:
					break;
			}
		}
	}
}
