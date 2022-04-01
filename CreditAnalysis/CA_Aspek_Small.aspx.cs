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

namespace SME.CreditAnalysis
{
	/// <summary>
	/// Summary description for CA_Aspek.
	/// </summary>
	public partial class CA_Aspek : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlTable TBL8;
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.RadioButton OPT_LMP_FORMAT_E;
		protected Connection conn;
		protected System.Web.UI.WebControls.DataGrid DGR_QUALNEW;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (Request.QueryString["viewmode"] == "1" || Request.QueryString["viewmode"] == "2")
			{
				/*20080120 remark by sofyan, old rating not used anymore
				DDL_MQUALITY.Enabled = false;
				DDL_INFDISCLOSURE.Enabled = false;
				DDL_COMPGROUP.Enabled = false;
				DDL_CAPSUPPORT.Enabled = false;
				DDL_MARKETSHR.Enabled = false;
				DDL_PRODCOMPTIVE.Enabled = false;
				DDL_COSTEFF.Enabled = false;
				DDL_3RDPARTY.Enabled = false;*/
				if (Request.QueryString["viewmode"] == "2")
				{
					BTN_INSERT.Visible = false;
					BTN_SIMPANLAH.Visible = false;

					BTN_SAVEQUAL.Visible = false;
					BTN_SAVERAC.Visible = false;
				}
			}

			if(!IsPostBack)
			{
				conn.QueryString= "select cu_jnsnasabah, prog_code from application a " +
					"inner join customer c on c.cu_ref = a.cu_ref " +
					"where ap_regno = '" + Request.QueryString["regno"] + "' ";
				conn.ExecuteQuery();
				LBL_H_JNSNASABAH.Text = conn.GetFieldValue(0,0);
				LBL_H_PROGRAMID.Text = conn.GetFieldValue(0,1);

				viewPickList();
				
				//20080120 remark by sofyan, old rating not used anymore
				//viewPickList_rating();
				
				//display(true);
				//display_none(true);
				//savebtn_show(true);
				//show_table(true);
				savebtn_show(true);
				show_table(true);
				cek_data();
				BindDataQualitativeNew();

				//20090203 add for RAC Small Business Enhancement
				ViewRACData();
			}

			ViewMenu();
			ViewSubMenu();
			
			//TBL_SAVE.Visible=true;
			

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
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+LBL_H_JNSNASABAH.Text+"&programid="+LBL_H_PROGRAMID.Text+"&lmsreg="+Request.QueryString["lmsreg"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+LBL_H_JNSNASABAH.Text+"&programid="+LBL_H_PROGRAMID.Text+"&lmsreg="+Request.QueryString["lmsreg"];
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
		
	
		private void ViewSubMenu()
		{
			try 
			{
				string programid = LBL_H_PROGRAMID.Text;
				string jnsnasabah = LBL_H_JNSNASABAH.Text ;

				conn.QueryString = "select MENUCODE,BUSSUNITID,PROGRAMID,PROGRAMID_SEQ,SM_MENUDISPLAY,SM_LINKNAME,LG_CODE from screensubmenu where lg_code in (select distinct lg_code " + 
					"from rfcafinstatement " + 
					"where programid = '" + programid + 
					"' and nasabahid = '" + jnsnasabah + 
					"') and menucode = '" + Request.QueryString["mc"] + 
					"' and programid = '" + programid +"'";
				conn.ExecuteQuery();

				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 4);
					string strtemp = "";
					strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+LBL_H_JNSNASABAH.Text+"&programid="+LBL_H_PROGRAMID.Text+"&tc="+Request.QueryString["tc"]+"&tahun="+Request.QueryString["tahun"]+"&mode="+Request.QueryString["mode"]+"&lmsreg="+Request.QueryString["lmsreg"];
					t.NavigateUrl = conn.GetFieldValue(i, 5)+strtemp;
					SubMenu.Controls.Add(t);
					SubMenu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void BindDataQualitativeNew()
		{
			conn.QueryString = "SELECT * FROM VW_CA_ASPEK_NEWRATING_VIEWQUALITATIVENEW WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' ORDER BY QUALITATIVEID, SUBQUALITATIVEID";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_QUAL.DataSource = dt;
			try 
			{
				DGR_QUAL.DataBind();
			}
			catch 
			{
				DGR_QUAL.CurrentPageIndex = 0;
				DGR_QUAL.DataBind();
			}

			BindDataQualitativeNewSubSubQual();
			BindDataQualitative2();
			CalculateQualitative();
		}

		private void BindDataQualitativeNewSubSubQual()
		{
			for (int i=0;i<DGR_QUAL.Items.Count;i++)
			{
				RadioButtonList rblsubsubqual = (RadioButtonList) DGR_QUAL.Items[i].Cells[4].FindControl("RBL_SUBSUBQUAL");

				conn.QueryString = "exec CA_ASPEK_NEWRATING_VIEWQUALITATIVENEW '" + Request.QueryString["regno"] + "', '" + DGR_QUAL.Items[i].Cells[0].Text.Trim() + "', '" + DGR_QUAL.Items[i].Cells[1].Text.Trim() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtsubsubqual = new DataTable();
					dtsubsubqual = conn.GetDataTable().Copy();

					string subsubqualid = "", subsubqualflag = "", subsubqualscore = "";
					DataRow[] drs = dtsubsubqual.Select();
					foreach (DataRow dr in drs)
					{
						if (dr["CHECKED"].ToString() == "1")
						{
							subsubqualid = dr["SUBSUBQUALITATIVEID"].ToString();
							subsubqualscore = dr["SCORE"].ToString();
							subsubqualflag = dr["FLAG"].ToString();
						}
					}

					rblsubsubqual.DataSource = dtsubsubqual;
					try 
					{
						rblsubsubqual.DataValueField = "SUBSUBQUALITATIVEID";
						rblsubsubqual.DataTextField = "SUBSUBQUALITATIVEDESC";
						if (subsubqualid != "")
							try {rblsubsubqual.SelectedValue = subsubqualid;} 
							catch {}
						rblsubsubqual.DataBind();

						//Fill column SCORE and FLAG
						DGR_QUAL.Items[i].Cells[5].Text = subsubqualscore;
						DGR_QUAL.Items[i].Cells[6].Text = subsubqualflag;
					} 
					catch {}
				}
			}
		}

		private void BindDataQualitative2()
		{
			conn.QueryString = "exec CA_ASPEK_NEWRATING_VIEWQUALITATIVE2 '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			DataTable dt2 = new DataTable();
			dt2 = conn.GetDataTable().Copy();
			DGR_CLASSIFY.DataSource = dt2;
			try 
			{
				DGR_CLASSIFY.DataBind();
			}
			catch 
			{
				DGR_CLASSIFY.CurrentPageIndex = 0;
				DGR_CLASSIFY.DataBind();
			}
		}

		public int GroupColumn(DataGrid dg, int ColumnIndex)
		{
			int ItemIndex = 0;
			int Groupings = 0;

			foreach (DataGridItem dgi in dg.Items)
			{
				if (dgi.ItemIndex > 0)
				{
					//if current cells text is the same as the cell above it
					//make it invisible and increase the row span by 1 of the 
					//last visible cell in that column.
					if (dg.Items[dgi.ItemIndex].Cells[ColumnIndex].Text == dg.Items[dgi.ItemIndex-1].Cells[ColumnIndex].Text)
					{
						dg.Items[dgi.ItemIndex].Cells[ColumnIndex].Visible = false;
						if (dg.Items[ItemIndex].Cells[ColumnIndex].RowSpan == 0) { dg.Items[ItemIndex].Cells[ColumnIndex].RowSpan = 1; }
						dg.Items[ItemIndex].Cells[ColumnIndex].RowSpan = dg.Items[ItemIndex].Cells[ColumnIndex].RowSpan + 1;
						Groupings++;
						Response.Write("<!-- -"+dg.Items[dgi.ItemIndex].Cells[ColumnIndex].Text+" -->");
						Response.Write("<!-- -"+dgi.ItemIndex.ToString()+"-A-"+ItemIndex.ToString()+" -->");
						Response.Write("<!-- -"+dg.Items[ItemIndex].Cells[ColumnIndex].RowSpan.ToString()+" -->");
					}
					else if (dg.Items[dgi.ItemIndex-1].Cells[ColumnIndex].Visible)
					{
						//dg.Items[dgi.ItemIndex].DataItem = new System.Web.UI.WebControls.DataGridItem(1, 0, ListItemType.Item);
						ItemIndex = dgi.ItemIndex;
						Response.Write("<!-- -"+dgi.ItemIndex.ToString()+"-B-"+ItemIndex.ToString()+" -->");
					}
					else
					{
						ItemIndex = dgi.ItemIndex;
						if (dg.Items[ItemIndex].Cells[ColumnIndex].RowSpan == 0) { dg.Items[ItemIndex].Cells[ColumnIndex].RowSpan = 1; }
						dg.Items[ItemIndex].Cells[ColumnIndex].RowSpan = dg.Items[ItemIndex].Cells[ColumnIndex].RowSpan + 1;
						Response.Write("<!-- -"+dg.Items[dgi.ItemIndex].Cells[ColumnIndex].Text+" -->");
						Response.Write("<!-- -"+dgi.ItemIndex.ToString()+"-C-"+ItemIndex.ToString()+" -->");
						Response.Write("<!-- -"+dg.Items[ItemIndex].Cells[ColumnIndex].RowSpan.ToString()+" -->");
					}
				}
			}

			//dg.Items[dg.Items.Count-1].Visible = false;

			return Groupings;
		}

		private void CalculateQualitative()
		{
			conn.QueryString = "exec CA_ASPEK_NEWRATING_CALCULATEQUALITATIVE '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			LBL_QSCORE.Text = conn.GetFieldValue("TOTALSCORE").ToString();
			LBL_QREC.Text = conn.GetFieldValue("RECOMMENDATION").ToString();
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
			this.DGR_QUAL.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_QUAL_PageIndexChanged);
			this.DGR_RAC.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_RAC_PageIndexChanged);
			this.DGR_RAC.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGR_RAC_ItemDataBound);

		}
		#endregion

		private void viewPickList()
		{
			DDL_ASPEK.Items.Clear();
			//TO DO : BLA.........................
			string a = Request.QueryString["regno"];
			string b = LBL_H_PROGRAMID.Text;
			
			GlobalTools.fillRefList(DDL_ASPEK,"SELECT distinct A.FORMATID,B.FORMATDESC FROM RFCA_FORMATPROGRAM A, RFCA_FORMAT B " +
				" WHERE A.PROGRAMID = '" + b + "' AND A.FORMATID = B.FORMATID " +
				" AND A.FORMATID NOT IN (SELECT FORMATID FROM CA_ASPEK WHERE AP_REGNO = '" + a + "')",false,conn);
			
		}

		private void cek_data()
		{
			conn.QueryString = "SELECT distinct A.FORMATID,B.FORMATDESC FROM RFCA_FORMATPROGRAM A, RFCA_FORMAT B " +
				" WHERE A.PROGRAMID = '" + LBL_H_PROGRAMID.Text + "'AND A.FORMATID = B.FORMATID " +
				" AND A.FORMATID IN (SELECT FORMATID FROM CA_ASPEK WHERE AP_REGNO = '" + Request.QueryString["regno"] + "')";
			conn.ExecuteQuery();
		
			if (conn.GetRowCount() != 0 )
			{
				show_table(true);
				display_record();
			}
			else
			{	show_table(true); }
		}


		private void display_record()
		{
			conn.QueryString = "select subaspekid,web_controlid from rfca_subaspek " +
				" where subaspekid in (" +
				" select subaspekid from ca_aspek " +
				//" where formatid = (select formatid from rfca_formatprogram where programid = '" + LBL_H_PROGRAMID.Text+ "')" +
				" where formatid in (select formatid from rfca_formatprogram where programid = '" + LBL_H_PROGRAMID.Text + "')" +
				" and ap_regno = '" + Request.QueryString["regno"] + "')";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			for (int i=0; i<dt.Rows.Count; i++)
			{
				conn.QueryString = 	" select nilai from ca_aspek " +
					//" where formatid = (select formatid from rfca_formatprogram where programid = '" +LBL_H_PROGRAMID.Text+ "') " +
					" where formatid in (select formatid from rfca_formatprogram where programid = '" +LBL_H_PROGRAMID.Text+ "') " +
					" and ap_regno = '" +Request.QueryString["regno"]+ "' and subaspekid = '" + dt.Rows[i][0].ToString() + "'";
				conn.ExecuteQuery();
				
				for (int j=0; j<conn.GetRowCount(); j++)
				{
					
					if (Strings.Left(dt.Rows[i][1].ToString(),3)=="OPT")
					{
						RadioButton rd = (RadioButton) Page.FindControl(dt.Rows[i][1].ToString());
						if (conn.GetFieldValue(j,0)=="1")
							rd.Checked = true;
						else
							rd.Checked = false;
					}
					else if (Strings.Left(dt.Rows[i][1].ToString(),3)=="TXT")
					{
						TextBox txt = (TextBox) Page.FindControl(dt.Rows[i][1].ToString());
						try { txt.Text = conn.GetFieldValue(j,0).ToString(); }
						catch {}
					}
					else if (Strings.Left(dt.Rows[i][1].ToString(),3)=="DDL")
					{
						DropDownList ddl = (DropDownList) Page.FindControl(dt.Rows[i][1].ToString());
						try { ddl.SelectedValue = conn.GetFieldValue(j,0).ToString(); }
						catch {}
						try 
						{
							TextBox txt = (TextBox) Page.FindControl("TXT" + dt.Rows[i][1].ToString().Substring(3));
							txt.Text = ddl.SelectedItem.Text;
						}
						catch {}
					}
				}
			}
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			//TO DO : BLA.........................
			string a = Request.QueryString["regno"];
			//string c = "2";
			string c = LBL_H_PROGRAMID.Text;


			if (c!="10" && c!= "11") //c=10 adl kredit umum & ncl above 15 milyar, c=11 kredit program 4 eyes
			{
				conn.QueryString = "SELECT A.FORMATID,B.ASPEKID,C.SUBASPEKID FROM RFCA_FORMATPROGRAM A, RFCA_FORMATASPEK B, RFCA_SUBASPEK C" +
					" WHERE A.FORMATID = B.FORMATID " +
					" AND B.ASPEKID = C.ASPEKID AND A.FORMATID = C.FORMATID " +
					" AND A.PROGRAMID = '"+ c +"' " +
					" AND A.FORMATID = '"+ DDL_ASPEK.SelectedValue +"'";
				conn.ExecuteQuery();

				System.Data.DataTable dt = new System.Data.DataTable();
				dt = conn.GetDataTable().Copy();

				for (int i=0; i<conn.GetRowCount(); i++)
				{
					conn.QueryString = "exec ca_aspek_sp '"+a+"','"+dt.Rows[i][0].ToString()+"','"+dt.Rows[i][1].ToString()+"','"+dt.Rows[i][2].ToString()+"'";
					conn.ExecuteNonQuery();
				}
			}
			else
			{
				conn.QueryString = "SELECT A.FORMATID,B.ASPEKID,C.SUBASPEKID FROM RFCA_FORMATPROGRAM A, RFCA_FORMATASPEK B, RFCA_SUBASPEK C" +
					" WHERE A.FORMATID = B.FORMATID " +
					" AND B.ASPEKID = C.ASPEKID AND A.FORMATID = C.FORMATID " +
					" AND A.PROGRAMID = '"+ c +"' " +
					" AND A.FORMATID = '"+ DDL_ASPEK.SelectedValue +"'";
				conn.ExecuteQuery();

				System.Data.DataTable dt = new System.Data.DataTable();
				dt = conn.GetDataTable().Copy();
			
				string sSQL;
				
				sSQL = "delete from ca_aspek where ap_regno = '" + a + "' and formatid in ('A','B','C','D','E','F')";

				conn.QueryString = sSQL;
				conn.ExecuteNonQuery();

				for (int i=0; i<dt.Rows.Count; i++)
				{
					conn.QueryString = "insert into ca_aspek(ap_regno, formatid, aspekid, subaspekid) values ('" + a + "','" + dt.Rows[i][0].ToString() + "','" + dt.Rows[i][1].ToString() + "','" + dt.Rows[i][2].ToString() + "')";
					conn.ExecuteNonQuery();
				}
			}
			
			string _aspek = "(empty)";
			if (DDL_ASPEK.SelectedValue != "") _aspek = DDL_ASPEK.SelectedItem.Text;

			viewPickList();
			show_table(true);
			savebtn_show(true);

			
			//////////////////////////////////////////////////////////////////////
			/// audit trail
			try
			{
				conn.QueryString = "SP_AUDITTRAIL_APP '" + 
					Request.QueryString["regno"] + "',null,null,null,'" + 
					Request.QueryString["curef"] + "','" + 
					Request.QueryString["tc"] + "','Credit Analysis - Aspek-Aspek - " + _aspek + "','"+ 
					DDL_ASPEK.SelectedValue + "','" +  
					Session["userid"].ToString() + "',null,null";
				conn.ExecuteNonQuery();
			}
			catch (Exception ex)
			{ 
				Response.Write("<!-- generate err: " + ex.Message + " -->");
			}

		}

	
		private void savebtn_show(bool b)
		{
			string a = Request.QueryString["regno"];
			
			conn.QueryString = "select * from ca_aspek where ap_regno = '" + a + "' and FORMATID IN (SELECT FORMATID FROM RFCA_FORMATPROGRAM WHERE PROGRAMID = '" + LBL_H_PROGRAMID.Text + "')";
			conn.ExecuteQuery();

			if (conn.GetRowCount() <= 0)
			{
				TBL_SAVE.Visible = !b;
			} 
			else 
			{
				TBL_SAVE.Visible = b;
			}
		}

		

		private void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
		
		}

		private void show_table(bool x)
		{
			conn.QueryString = "SELECT DISTINCT FORMATID FROM CA_ASPEK WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' "+
				" AND FORMATID IN (SELECT FORMATID FROM RFCA_FORMATPROGRAM WHERE PROGRAMID = '" + LBL_H_PROGRAMID.Text + "')";
			conn.ExecuteQuery();

			for (int i=0;i<conn.GetRowCount();i++)
			{
				System.Web.UI.HtmlControls.HtmlTable IdTabel = (System.Web.UI.HtmlControls.HtmlTable) this.Page.FindControl("FORMAT_"+conn.GetFieldValue(i,0));
				IdTabel.Visible = x;
				
			}

			conn.QueryString="SELECT FORMATID FROM RFCA_FORMAT WHERE FORMATID NOT IN (" +
				" SELECT FORMATID FROM CA_ASPEK WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'" +
				" AND FORMATID IN (SELECT FORMATID FROM RFCA_FORMATPROGRAM WHERE PROGRAMID = '" + LBL_H_PROGRAMID.Text + "'))";
			conn.ExecuteQuery();
			
			for (int i=0;i<conn.GetRowCount();i++)
			{
				System.Web.UI.HtmlControls.HtmlTable IdTabel = (System.Web.UI.HtmlControls.HtmlTable) this.Page.FindControl("FORMAT_"+conn.GetFieldValue(i,0));
				IdTabel.Visible = !x;
			}
		}

		protected void BTN_SIMPANLAH_Click(object sender, System.EventArgs e)
		{
			conn.QueryString="select subaspekid,web_controlid from rfca_subaspek "+
				" where formatid in (select formatid from ca_aspek where ap_regno = '"+ Request.QueryString["regno"] +"' and formatid in (select formatid from rfca_formatprogram where programid = '" + LBL_H_PROGRAMID.Text + "'))";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			for (int i=0; i<dt.Rows.Count; i++)
			{
				//if (Strings.Left(dt.Rows[i][1].ToString(),3)=="OPT")
				if (Strings.Left(conn.GetFieldValue(i,1),3)=="OPT")
				{
					//RadioButton rd = (RadioButton) Page.FindControl(dt.Rows[i][1].ToString());
					RadioButton rd = (RadioButton) Page.FindControl(conn.GetFieldValue(i,1));
					string cek;
					if (rd.Checked)
						cek="1";
					else
						cek="0";

					conn.QueryString = "update ca_aspek set nilai = '" + cek + "' where ap_regno = '" + Request.QueryString["regno"] + "' and subaspekid = '"+ conn.GetFieldValue(i,0) + "'";
					conn.ExecuteNonQuery();
				}
				else if (Strings.Left(conn.GetFieldValue(i,1),3)=="TXT")
				{
					//TextBox txt = (TextBox) Page.FindControl(dt.Rows[i][1].ToString());
					try 
					{
						TextBox txt = (TextBox) Page.FindControl(conn.GetFieldValue(i,1));
						conn.QueryString = "update ca_aspek set nilai = '" + txt.Text + "' where ap_regno = '" + Request.QueryString["regno"] + "' and subaspekid = '"+ conn.GetFieldValue(i,0) + "'";
						conn.ExecuteNonQuery();
					}
					catch {}
				}
				else
				{
					try 
					{
						DropDownList ddl = (DropDownList) Page.FindControl(conn.GetFieldValue(i,1));
						conn.QueryString = "update ca_aspek set nilai = '" + ddl.SelectedValue + "' where ap_regno = '" + Request.QueryString["regno"] + "' and subaspekid = '"+ conn.GetFieldValue(i,0) + "'";
						conn.ExecuteNonQuery();
					}
					catch {}
				}
				
			}
		}

		/*20080120 remark by sofyan, old rating not used anymore
		********************************** mandiri rating ******************************************
		private void viewPickList_rating()
		{
			DDL_MQUALITY.Items.Add(new ListItem("- PILIH -", ""));
			//conn.QueryString = "select (bmr_code+cast(bmr2_code as char(1))+bmr3_code) as a, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'B' and bmr2_code = '1' and bmr3_active = '1'";
			conn.QueryString = "select ltrim(rtrim(bmr_code))+ltrim(rtrim(bmr2_code))+ltrim(rtrim(bmr3_code))+ltrim(rtrim(param_rating)) as a, bmr3_desc, left(bmr3_desc,120),bmr3_desc  from rfbmrating_III where bmr_code = 'B' and bmr2_code = '1' and bmr3_active = '1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_MQUALITY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			DDL_INFDISCLOSURE.Items.Add(new ListItem("- PILIH -", ""));
			//conn.QueryString = "select (bmr_code+cast(bmr2_code as char(1))+bmr3_code) as a, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'B' and bmr2_code = '2' and bmr3_active = '1'";
			conn.QueryString = "select ltrim(rtrim(bmr_code))+ltrim(rtrim(bmr2_code))+ltrim(rtrim(bmr3_code))+ltrim(rtrim(param_rating)) as a, bmr3_desc, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'B' and bmr2_code = '2' and bmr3_active = '1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_INFDISCLOSURE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			
			DDL_COMPGROUP.Items.Add(new ListItem("- PILIH -", ""));
			//conn.QueryString = "select (bmr_code+cast(bmr2_code as char(1))+bmr3_code) as a, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'B' and bmr2_code = '3' and bmr3_active = '1'";
			conn.QueryString = "select ltrim(rtrim(bmr_code))+ltrim(rtrim(bmr2_code))+ltrim(rtrim(bmr3_code))+ltrim(rtrim(param_rating)) as a, bmr3_desc, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'B' and bmr2_code = '3' and bmr3_active = '1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_COMPGROUP.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));	
			
			DDL_CAPSUPPORT.Items.Add(new ListItem("- PILIH -", ""));
			//conn.QueryString = "select (bmr_code+cast(bmr2_code as char(1))+bmr3_code) as a, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'B' and bmr2_code = '4' and bmr3_active = '1'";
			conn.QueryString = "select ltrim(rtrim(bmr_code))+ltrim(rtrim(bmr2_code))+ltrim(rtrim(bmr3_code))+ltrim(rtrim(param_rating)) as a, bmr3_desc, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'B' and bmr2_code = '4' and bmr3_active = '1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CAPSUPPORT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));	
			
			DDL_MARKETSHR.Items.Add(new ListItem("- PILIH -", ""));
			//conn.QueryString = "select (bmr_code+cast(bmr2_code as char(1))+bmr3_code) as a, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'C' and bmr2_code = '1' and bmr3_active = '1'";
			conn.QueryString = "select ltrim(rtrim(bmr_code))+ltrim(rtrim(bmr2_code))+ltrim(rtrim(bmr3_code))+ltrim(rtrim(param_rating)) as a, bmr3_desc, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'C' and bmr2_code = '1' and bmr3_active = '1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_MARKETSHR.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));	
			
			DDL_PRODCOMPTIVE.Items.Add(new ListItem("- PILIH -", ""));
			//conn.QueryString = "select (bmr_code+cast(bmr2_code as char(1))+bmr3_code) as a, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'C' and bmr2_code = '2' and bmr3_active = '1'";
			conn.QueryString = "select ltrim(rtrim(bmr_code))+ltrim(rtrim(bmr2_code))+ltrim(rtrim(bmr3_code))+ltrim(rtrim(param_rating)) as a, bmr3_desc, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'C' and bmr2_code = '2' and bmr3_active = '1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_PRODCOMPTIVE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));	

			DDL_COSTEFF.Items.Add(new ListItem("- PILIH -", ""));
			//conn.QueryString = "select (bmr_code+cast(bmr2_code as char(1))+bmr3_code) as a, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'C' and bmr2_code = '3' and bmr3_active = '1'";
			conn.QueryString = "select ltrim(rtrim(bmr_code))+ltrim(rtrim(bmr2_code))+ltrim(rtrim(bmr3_code))+ltrim(rtrim(param_rating)) as a, bmr3_desc, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'C' and bmr2_code = '3' and bmr3_active = '1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_COSTEFF.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));	

			DDL_3RDPARTY.Items.Add(new ListItem("- PILIH -", ""));
			//conn.QueryString = "select (bmr_code+cast(bmr2_code as char(1))+bmr3_code) as a, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'C' and bmr2_code = '4' and bmr3_active = '1'";
			conn.QueryString = "select ltrim(rtrim(bmr_code))+ltrim(rtrim(bmr2_code))+ltrim(rtrim(bmr3_code))+ltrim(rtrim(param_rating)) as a, bmr3_desc, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'C' and bmr2_code = '4' and bmr3_active = '1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_3RDPARTY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));	
			
		}

		private void DDL_MQUALITY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "Select bmr3_desc from rfbmrating_III where bmr_code = '" + DDL_MQUALITY.SelectedItem.Value.Substring(0,1) + "' and bmr2_code = '" + DDL_MQUALITY.SelectedItem.Value.Substring(1,1) + "' and bmr3_code = '" + DDL_MQUALITY.SelectedItem.Value.Substring(2,1) + "'";
			conn.ExecuteQuery();
			try { TXT_MQUALITY.Text = conn.GetFieldValue("bmr3_desc").ToString(); }
			catch { TXT_MQUALITY.Text = ""; }
		}

		private void DDL_INFDISCLOSURE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "Select bmr3_desc from rfbmrating_III where bmr_code = '" + DDL_INFDISCLOSURE.SelectedItem.Value.Substring(0,1) + "' and bmr2_code = '" + DDL_INFDISCLOSURE.SelectedItem.Value.Substring(1,1) + "' and bmr3_code = '" + DDL_INFDISCLOSURE.SelectedItem.Value.Substring(2,1) + "'";
			conn.ExecuteQuery();
			try { TXT_INFDISCLOSURE.Text = conn.GetFieldValue("bmr3_desc").ToString(); }
			catch { TXT_INFDISCLOSURE.Text = ""; }
		}

		private void DDL_COMPGROUP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "Select bmr3_desc from rfbmrating_III where bmr_code = '" + DDL_COMPGROUP.SelectedItem.Value.Substring(0,1) + "' and bmr2_code = '" + DDL_COMPGROUP.SelectedItem.Value.Substring(1,1) + "' and bmr3_code = '" + DDL_COMPGROUP.SelectedItem.Value.Substring(2,1) + "'";
			conn.ExecuteQuery();
			try { TXT_COMPGROUP.Text = conn.GetFieldValue("bmr3_desc").ToString(); }
			catch { TXT_COMPGROUP.Text = ""; }
		}

		private void DDL_CAPSUPPORT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "Select bmr3_desc from rfbmrating_III where bmr_code = '" + DDL_CAPSUPPORT.SelectedItem.Value.Substring(0,1) + "' and bmr2_code = '" + DDL_CAPSUPPORT.SelectedItem.Value.Substring(1,1) + "' and bmr3_code = '" + DDL_CAPSUPPORT.SelectedItem.Value.Substring(2,1) + "'";
			conn.ExecuteQuery();
			try { TXT_CAPSUPPORT.Text = conn.GetFieldValue("bmr3_desc").ToString(); }
			catch { TXT_CAPSUPPORT.Text = ""; }
		}

		private void DDL_MARKETSHR_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "Select bmr3_desc from rfbmrating_III where bmr_code = '" + DDL_MARKETSHR.SelectedItem.Value.Substring(0,1) + "' and bmr2_code = '" + DDL_MARKETSHR.SelectedItem.Value.Substring(1,1) + "' and bmr3_code = '" + DDL_MARKETSHR.SelectedItem.Value.Substring(2,1) + "'";
			conn.ExecuteQuery();
			try { TXT_MARKETSHR.Text = conn.GetFieldValue("bmr3_desc").ToString(); }
			catch { TXT_MARKETSHR.Text = ""; }
		}

		private void DDL_PRODCOMPTIVE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "Select bmr3_desc from rfbmrating_III where bmr_code = '" + DDL_PRODCOMPTIVE.SelectedItem.Value.Substring(0,1) + "' and bmr2_code = '" + DDL_PRODCOMPTIVE.SelectedItem.Value.Substring(1,1) + "' and bmr3_code = '" + DDL_PRODCOMPTIVE.SelectedItem.Value.Substring(2,1) + "'";
			conn.ExecuteQuery();
			
			try { TXT_PRODCOMPTIVE.Text = conn.GetFieldValue("bmr3_desc").ToString(); }
			catch { TXT_PRODCOMPTIVE.Text = ""; }

		}

		private void DDL_COSTEFF_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "Select bmr3_desc from rfbmrating_III where bmr_code = '" + DDL_COSTEFF.SelectedItem.Value.Substring(0,1) + "' and bmr2_code = '" + DDL_COSTEFF.SelectedItem.Value.Substring(1,1) + "' and bmr3_code = '" + DDL_COSTEFF.SelectedItem.Value.Substring(2,1) + "'";
			conn.ExecuteQuery();
			try { TXT_COSTEFF.Text = conn.GetFieldValue("bmr3_desc").ToString(); }
			catch { TXT_COSTEFF.Text = ""; }
		}

		private void DDL_3RDPARTY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "Select bmr3_desc from rfbmrating_III where bmr_code = '" + DDL_3RDPARTY.SelectedItem.Value.Substring(0,1) + "' and bmr2_code = '" + DDL_3RDPARTY.SelectedItem.Value.Substring(1,1) + "' and bmr3_code = '" + DDL_3RDPARTY.SelectedItem.Value.Substring(2,1) + "'";
			conn.ExecuteQuery();
			try { TXT_3RDPARTY.Text = conn.GetFieldValue("bmr3_desc").ToString(); }
			catch { TXT_3RDPARTY.Text = ""; }
		}
		*/

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn));
		}
		/******************************** end mandiri rating **************************************************************/

		/********************************** mandiri new rating ******************************************/
		private void DGR_QUAL_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_QUAL.CurrentPageIndex = e.NewPageIndex;
			BindDataQualitativeNew();
		}

		protected void BTN_SAVEQUAL_Click(object sender, System.EventArgs e)
		{
			for (int i=0; i<DGR_QUAL.Items.Count; i++)
			{
				RadioButtonList rblsubsubqual = (RadioButtonList) DGR_QUAL.Items[i].Cells[4].FindControl("RBL_SUBSUBQUAL");

				try
				{
					conn.QueryString = "exec CA_ASPEK_NEWRATING_UPDATEQUALITATIVENEW '" +
						Request.QueryString["regno"] + "', '" +
						DGR_QUAL.Items[i].Cells[0].Text.Trim() + "', '" + 
						DGR_QUAL.Items[i].Cells[1].Text.Trim() + "', '" +
						rblsubsubqual.SelectedValue.Trim() + "'";
					conn.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					string errmsg = ex.Message.Replace("'","");
					if (errmsg.IndexOf("Last Query:") > 0)
						errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
					GlobalTools.popMessage(this, errmsg);
					return;
				}
			}

			BindDataQualitativeNew();
		}
		/******************************** end mandiri new rating **************************************************************/

		/* RAC for Small Business Enhancement 2009 */
		private void ViewRACData()
		{
			conn.QueryString = "EXEC CA_ASPEK_RAC_VIEWDATA '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_RAC.DataSource = dt;
			try 
			{
				DGR_RAC.DataBind();
			} 
			catch 
			{
				DGR_RAC.CurrentPageIndex = 0;
				DGR_RAC.DataBind();
			}
		}

		private void DGR_RAC_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			string iscomply;

			switch (e.Item.ItemType)
			{
				case ListItemType.AlternatingItem:
				case ListItemType.EditItem:
				case ListItemType.Item:
				case ListItemType.SelectedItem:
					try
					{
						iscomply = e.Item.Cells[2].Text.Trim();
						RadioButtonList rbl = (RadioButtonList)e.Item.Cells[3].FindControl("RBL_RAC");
						if (iscomply == "1")
							rbl.SelectedValue = "1";
						else if (iscomply == "0")
							rbl.SelectedValue = "0";
					} 
					catch {}
					break;
				case ListItemType.Footer:
					break;
				default:
					break;
			}
		}

		protected void BTN_SAVERAC_Click(object sender, System.EventArgs e)
		{
			try
			{
				for (int i = 0; i < DGR_RAC.Items.Count; i++)
				{
					string iscomply = null;
					RadioButtonList rbl = (RadioButtonList)DGR_RAC.Items[i].Cells[3].FindControl("RBL_RAC");
					if (rbl.SelectedValue == "1")
						iscomply = "1";
					else if (rbl.SelectedValue == "0")
						iscomply = "0";

					conn.QueryString = "EXEC CA_ASPEK_RAC_SAVE '" + Request.QueryString["regno"] + "', '" + 
						DGR_RAC.Items[i].Cells[0].Text.Trim() + "', '" + iscomply + "'";
					conn.ExecuteQuery();
				}

				ViewRACData();
			}
			catch (Exception ex)
			{
				GlobalTools.popMessage(this, "Save Error!");
				Response.Write("<!--" + ex.Message + "-->");
				return;
			}
		}

		private void DGR_RAC_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_RAC.CurrentPageIndex = e.NewPageIndex;
			ViewRACData();
		}

		protected void BTN_RETRVCBI_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC CA_ASPEK_QUALITATIVE_RETRIEVEFROMCBI '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				BindDataQualitativeNew();
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}
		/* end RAC for Small Business Enhancement 2009 */
	}
}