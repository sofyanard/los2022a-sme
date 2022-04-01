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
	public partial class BPRQualitative : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlTable TBL8;
		protected Tools tool = new Tools();
		protected System.Web.UI.HtmlControls.HtmlTable FORMAT_F;
		protected System.Web.UI.WebControls.RadioButton OPT_LMP_FORMAT_E;
		protected Connection conn;
		protected System.Web.UI.WebControls.DataGrid DGR_QUALNEW;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if(!IsPostBack)
			{
				BindDataQualitativeNew();
			}

			ViewMenu();
			ViewSubMenu();
		}
		
		private void BindDataQualitativeNew()
		{
			conn.QueryString = "SELECT * FROM VW_BPR_VIEWQUALITATIVENEW WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' ORDER BY QUALITATIVEID, SUBQUALITATIVEID";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
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
				CalculateQualitative();
			}
		}

		private void BindDataQualitativeNewSubSubQual()
		{
			for (int i=0;i<DGR_QUAL.Items.Count;i++)
			{
				RadioButtonList rblsubsubqual = (RadioButtonList) DGR_QUAL.Items[i].Cells[4].FindControl("RBL_SUBSUBQUAL");

				conn.QueryString = "exec BPR_NEWRATING_VIEWQUALITATIVENEW '" + Request.QueryString["regno"] + "', '" + DGR_QUAL.Items[i].Cells[0].Text.Trim() + "', '" + DGR_QUAL.Items[i].Cells[1].Text.Trim() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtsubsubqual = new DataTable();
					dtsubsubqual = conn.GetDataTable().Copy();

					string subsubqualid = "", subsubqualflag = "";
					double subsubqualscore = 0.0;
					DataRow[] drs = dtsubsubqual.Select();
					foreach (DataRow dr in drs)
					{
						if (dr["CHECKED"].ToString() == "1")
						{
							subsubqualid = dr["SUBSUBQUALITATIVEID"].ToString();
							subsubqualscore = MyConnection.ConvertToDouble2(dr["SCORE"].ToString().Replace(",","."));
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
						DGR_QUAL.Items[i].Cells[5].Text = subsubqualscore.ToString();
					} 
					catch {}
				}
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
			conn.QueryString = "exec BPR_NEWRATING_CALCULATEQUALITATIVE '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			LBL_QSCORE.Text = conn.GetFieldValue("TOTALSCORE").ToString();
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
					conn.QueryString = "exec BPR_NEWRATING_UPDATEQUALITATIVENEW '" +
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
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						else	
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = "../" + conn.GetFieldValue(i, 3)+strtemp;
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
				string sProgramID,sJnsNasabah;

				conn.QueryString = "select distinct top 1 cu_jnsnasabah from customer where cu_ref in (Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+ "')";
				conn.ExecuteQuery();
				sJnsNasabah = conn.GetFieldValue("cu_jnsnasabah").ToString();
				//------------------------------------------------------------------------------
					
				conn.QueryString = "select distinct top 1 programid from rfprogram where programid in (select prog_code from application where ap_regno = '"+Request.QueryString["regno"]+ "')";
				conn.ExecuteQuery();
				sProgramID = conn.GetFieldValue("programid").ToString();

				//conn.QueryString = "select * from screensubmenu where lg_code in (select distinct lg_code from rfcafinstatement where programid = '"+Request.QueryString["programid"]+"' and nasabahid = '" +Request.QueryString["jnsnasabah"]+"') and menucode = '" +Request.QueryString["mc"]+ "' and programid = '"+Request.QueryString["programid"]+"'";

				conn.QueryString = "select MENUCODE,BUSSUNITID,PROGRAMID,PROGRAMID_SEQ,SM_MENUDISPLAY,SM_LINKNAME,LG_CODE from screensubmenu where lg_code in (select distinct lg_code from rfcafinstatement where programid = '" + sProgramID + "' and nasabahid = '" + sJnsNasabah + "') and menucode = '" + Request.QueryString["mc"]+ "' and programid = '" + sProgramID + "'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 4);
					string strtemp = "";
					strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&tc="+Request.QueryString["tc"]+"&tahun="+Request.QueryString["tahun"]+"&mode="+Request.QueryString["mode"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
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
	}
}