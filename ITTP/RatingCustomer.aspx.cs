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

namespace SME.ITTP
{
	/// <summary>
	/// Summary description for RatingCustomer.
	/// </summary>
	public partial class RatingCustomer : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected System.Web.UI.WebControls.Button rate;

		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];


			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");
/*
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
/*				if (Request.QueryString["viewmode"] == "2")
				{
					//BTN_INSERT.Visible = false;
					BTN_SIMPANLAH.Visible = false;

					BTN_SAVEQUAL.Visible = false;
				}
			}
*/

			
			conn.QueryString= "select cu_jnsnasabah, prog_code from application a " +
				"inner join customer c on c.cu_ref = a.cu_ref " +
				"where ap_regno = '" + Request.QueryString["regno"] + "' ";
			conn.ExecuteQuery();

			LBL_H_JNSNASABAH.Text = conn.GetFieldValue(0,0);
			LBL_H_PROGRAMID.Text = conn.GetFieldValue(0,1);

			///DDL_KLASIFIKASINSB.Items.Add(new ListItem("- PILIH -", ""));
			//conn.QueryString = "select klasifikasiid from rfitklasifikasinsb where active='1'";
			//conn.ExecuteQuery();
			//for (int i = 0; i < conn.GetRowCount(); i++)
			//	DDL_KLASIFIKASINSB.Items.Add(new ListItem(conn.GetFieldValue(i,0)));

			if(!IsPostBack)
			{
				//viewPickList();
				
				//savebtn_show(true);
				//show_table(true);
				//cek_data();
				BindDataQualitativeNew();
				ViewData ();

				//DDL_KLASIFIKASINSB.Items.Add(new ListItem("- PILIH -", ""));
				//conn.QueryString = "select klasifikasiid from rfitklasifikasinsb where active='1'";
				//conn.ExecuteQuery();
				//for (int i = 0; i < conn.GetRowCount(); i++)
				//	DDL_KLASIFIKASINSB.Items.Add(new ListItem(conn.GetFieldValue(i,0)));
			}

			secureData();

			ViewMenu();
			//ViewSubMenu();
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
		
/*	
		private void ViewSubMenu()
		{
			try 
			{
				//string programid = LBL_H_PROGRAMID.Text;
				//string jnsnasabah = LBL_H_JNSNASABAH.Text ;

				conn.QueryString = "select MENUCODE,BUSSUNITID,PROGRAMID,PROGRAMID_SEQ,SM_MENUDISPLAY,SM_LINKNAME,LG_CODE from screensubmenu where lg_code in (select distinct lg_code " + 
					"from rfcafinstatement " + 
				//	"where programid = '" + programid + 
				//	"' and nasabahid = '" + jnsnasabah + 
					"')menucode = '" + Request.QueryString["mc"];
				//	"' and programid = '" + programid +"'";
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
*/
		private void BindDataQualitativeNew()
		{
			conn.QueryString = "SELECT * FROM VW_IT_CA_ASPEK_NEWRATING_VIEWQUALITATIVENEW WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' ORDER BY QUALITATIVEID, SUBQUALITATIVEID";
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
		//	CalculateQualitative();
		}

		private void BindDataQualitativeNewSubSubQual()
		{
			for (int i=0;i<DGR_QUAL.Items.Count;i++)
			{
				RadioButtonList rblsubsubqual = (RadioButtonList) DGR_QUAL.Items[i].Cells[4].FindControl("RBL_SUBSUBQUAL");

				conn.QueryString = "exec IT_CA_ASPEK_NEWRATING_VIEWQUALITATIVENEW '" + Request.QueryString["regno"] + "', '" + DGR_QUAL.Items[i].Cells[0].Text.Trim() + "', '" + DGR_QUAL.Items[i].Cells[1].Text.Trim() + "'";
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
			conn.QueryString = "exec IT_SCORING '" + Request.QueryString["regno"] + "'";
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

			LBL_RISKAPPETITENSB.Text = conn.GetFieldValue (2,3);
			LBL_PROFILRISKNSB.Text = conn.GetFieldValue (2,2);
			LBL_PROFILRISKNSB.Visible = false;

			//LBL_QSCORE.Text = Request.QueryString[]
			//LBL_KLASIFIKASI.Text = Request.QueryString



		//	LBL_KATEGORINSB = conn.GetFieldValue ("KATEGORI_NASABAH");
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

		private void ViewData()
		{
			//Data Customer
			conn.QueryString = "select top 1 * from VW_IT_SCORING_DATA where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			LBL_KLASIFIKASINSB.Text = conn.GetFieldValue("KLASIFIKASIID");
			LBL_PROFILRISKNSB_SCORE.Text=conn.GetFieldValue("PROFILRISK");
			LBL_RISKAPPETITENSB.Text = conn.GetFieldValue("RISKAPPETITE");
			LBL_RISKPROFNSB.Text = conn.GetFieldValue("RISKPROF");
			LBL_KATEGORINSB.Text=conn.GetFieldValue("KATEGORI");
			Label3.Text=conn.GetFieldValue("REKOMENDASI");
			TextBox1.Text=conn.GetFieldValue("CATATAN");

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

		}
		#endregion

		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
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
					conn.QueryString = "exec IT_CA_ASPEK_NEWRATING_UPDATEQUALITATIVENEW '" +
						Request.QueryString["regno"] + "','" +
						DGR_QUAL.Items[i].Cells[0].Text.Trim() + "', '" + 
						DGR_QUAL.Items[i].Cells[1].Text.Trim() + "', '" +
						rblsubsubqual.SelectedValue.Trim() + "'";
					conn.ExecuteNonQuery();
					conn.QueryString = "exec IT_SCORING '" +
						Request.QueryString["regno"] + "'";
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
			
			if (LBL_PROFILRISKNSB.Text != "")
			{
				conn.QueryString = "exec IT_SCORING2 '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
				LBL_PROFILRISKNSB_SCORE.Text = conn.GetFieldValue ("PROFILRISKNSB_SCORE");
				LBL_KATEGORINSB.Text = conn.GetFieldValue ("KATEGORI_NASABAH");
				catatantenor.Text = conn.GetFieldValue ("CATATAN_TENOR");
			}

			if (LBL_KATEGORINSB.Text != "")
			{
				conn.QueryString = "exec IT_SCORING3 '" + Request.QueryString["regno"] + "','" + LBL_PROFILRISKNSB_SCORE.Text 
				+ "','"+LBL_KATEGORINSB.Text+"','"+LBL_RISKAPPETITENSB.Text+"'";
				conn.ExecuteQuery();
				LBL_KLASIFIKASINSB.Text = conn.GetFieldValue ("KLASIFIKASINSB");
			}
			
			conn.QueryString = "select * from RFITKLASIFIKASINSB where ACTIVE='1' and KLASIFIKASIID='"+ LBL_KLASIFIKASINSB.Text+"'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				LBL_RISKPROFNSB.Text = conn.GetFieldValue ("KATEGORIDESC");
				Label3.Text = conn.GetFieldValue ("REKOMENDASIDESC");
			}


			BindDataQualitativeNew();
		}

		protected void BTN_SIMPANLAH_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec IT_IDE_SCORING_INSERT '" + 
				Request.QueryString["regno"] + "', '" + 
				LBL_KATEGORINSB.Text + "', '" +
				LBL_PROFILRISKNSB_SCORE.Text + "', '" +
				LBL_RISKAPPETITENSB.Text + "', '" + 
				LBL_RISKPROFNSB.Text + "', '" +
				LBL_KLASIFIKASINSB.Text + "', '" +
				Label3.Text +"', '" +
				TextBox1.Text +"', '" +
				catatantenor.Text + "'";
			conn.ExecuteNonQuery();
		}

		private void secureData() 
		{
			string de = Request.QueryString["de"];
			if (de == "1")
			{
				TR_BODY.Visible = false;
				TR_BUTTONS.Visible = false;
			}
		}


/*
		private void BTN_HISTORY_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('RatingHistory.aspx?curef='"+Request.QueryString["curef"]+"','RatingHistory','status=no,scrollbars=no,width=420,height=400');</script>");
		}
*/

	}
}