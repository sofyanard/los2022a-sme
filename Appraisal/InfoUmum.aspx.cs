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


namespace SME.Appraisal
{
	/// <summary>
	/// Summary description for InfoUmum.
	/// </summary>
	public partial class InfoUmum : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=192.168.1.200;Initial Catalog=SME;uid=sa;pwd=");
		protected Connection conn;
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.Button BTN_MAIN;
		protected System.Web.UI.WebControls.Button BTN_DETAIL;
		string APREGNO, CUREF, CLSEQ, TC, MC;
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			CUREF = Request.QueryString["curef"];
			APREGNO = Request.QueryString["regno"];
			CLSEQ = Request.QueryString["cl_seq"];
			TC = Request.QueryString["tc"];
			MC = Request.QueryString["mc"];

			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
			//	Response.Redirect("/SME/Restricted.aspx");sdf

			LBL_REGNO.Text = Request.QueryString["regno"];
			LBL_CUREF.Text = Request.QueryString["curef"];
			LBL_TC.Text = Request.QueryString["tc"];
			if (!IsPostBack)
			{
				DDL_AP_SIGNDATEMONTH.Items.Add(new ListItem("- SELECT -", ""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_AP_SIGNDATEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
				ViewData();
			}
			ViewListJaminan();
			ViewMenu();
		}

		private bool isPetugas(string groupid) 
		{
			bool petugas = false;

			conn.QueryString = "select groupid from scgroup where sg_grpupliner = '" + groupid + "'";
			conn.ExecuteQuery();
			
			if (conn.GetRowCount() == 0) petugas = true;

			return petugas;
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

		private void ViewData()
		{
			conn.QueryString = "select * from VW_INFOUMUM_APPRAISAL "+
				"where AP_REGNO = '"+ LBL_REGNO.Text +"' ";
			conn.ExecuteQuery();
			TXT_AP_REGNO.Text = conn.GetFieldValue("AP_REGNO");
			//TXT_CU_REF.Text = conn.GetFieldValue("CU_REF");
			string AP_SIGNDATE = conn.GetFieldValue("AP_SIGNDATE");
			TXT_AP_SIGNDATEDAY.Text = tool.FormatDate_Day(AP_SIGNDATE);
			DDL_AP_SIGNDATEMONTH.SelectedValue = tool.FormatDate_Month(AP_SIGNDATE);
			TXT_AP_SIGNDATEYEAR.Text = tool.FormatDate_Year(AP_SIGNDATE);
			TXT_PROGRAMDESC.Text = conn.GetFieldValue("PROGRAMDESC");
			TXT_BRANCH_NAME.Text = conn.GetFieldValue("BRANCH_NAME");
			TXT_AP_TMLDRNM.Text = conn.GetFieldValue("AP_TMLDRNM");
			TXT_AP_RMNM.Text = conn.GetFieldValue("AP_RMNM");
			TXT_BU_DESC.Text = conn.GetFieldValue("BU_DESC");
			TXT_CU_NAME.Text = conn.GetFieldValue("CU_NAME");
			TXT_CU_ADDR1.Text = conn.GetFieldValue("CU_ADDR1");
			TXT_CU_ADDR2.Text = conn.GetFieldValue("CU_ADDR2");
			TXT_CU_ADDR3.Text = conn.GetFieldValue("CU_ADDR3");
			TXT_CU_CITYNM.Text = conn.GetFieldValue("CU_CITYNM");
			TXT_CU_PHN.Text = conn.GetFieldValue("CU_PHN");
			TXT_BUSSTYPEDESC.Text = conn.GetFieldValue("BUSSTYPEDESC");
		}

		private void ViewListJaminan()
		{
			string ApprID = "", ApprType = "";
			string mGROUP = Session["GroupID"].ToString(), MKOND = "";
			string userID = Session["UserID"].ToString();
			string branchID = Session["BranchID"].ToString();
			string vSG_GRPUNIT = "", userid1="";

			/////////////////////////////////////////
			///	mendapatkan group
			///	
			conn.QueryString = "select isnull(SG_GRPUNIT,'') as SG_GRPUNIT from SCGROUP where GROUPID = '" + mGROUP + "'";
			conn.ExecuteQuery();
			vSG_GRPUNIT = conn.GetFieldValue("SG_GRPUNIT");


			conn.QueryString = "select GRP_CO, GRP_COOFF from APP_PARAMETER";
			conn.ExecuteQuery();

			string GRP_CO = conn.GetFieldValue("GRP_CO"), GRP_COOFF = conn.GetFieldValue("GRP_COOFF");


			if (vSG_GRPUNIT == "CO") 
			{
				//if (mGROUP == CO Manager)
				if (!isPetugas(mGROUP))
					//MKOND = "and LA_CREDITOPR = '" +Session["UserID"].ToString()+ "'";
					MKOND = "and LA_CREDITOPR = '" + branchID + "' " + 
							"and LA_APPRSTATUS <> '7'";		// not done
					//else if (mGROUP == Petugas CO)
				else if (isPetugas(mGROUP))
					//MKOND = "and LA_APPRSTATUS='2' and OFFICERSEQ = '" +Session["UserID"].ToString()+ "'";
					MKOND = "and LA_APPRSTATUS = '2' and OFFICERSEQ = '" + userID + "'";
			}
			else
				MKOND = "and (LA_APPRTYPE = '0' or LA_APPRTYPE = '1')";


			conn.QueryString = "select * from VW_APPRAISAL_RESULTLIST where AP_REGNO = '"+ Request.QueryString["regno"]+"' "+MKOND.Trim();
			conn.ExecuteQuery();
		
			///////----------
			userid1 = conn.GetFieldValue("OFFICERSEQ");

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			
			int tblRowCount = Table_List.Rows.Count;
			for (int i = tblRowCount - 1; i >= 1; i--)
				Table_List.Rows.Remove(Table_List.Rows[i]);

			int row = conn.GetRowCount();
			string BGCOLOR = "TDBGColor11", CL_SEQ;
			int no_row;
			for (int i = 0; i < row; i++)
			{
				if (BGCOLOR == "TDBGColor11")
					BGCOLOR = "TDBGColor21";
				else
					BGCOLOR = "TDBGColor11";
				
				Label Lbl1 = new Label();
				Lbl1.ID = "COLL_LBL" + i;
				Lbl1.Text = dt.Rows[i][2].ToString()+". ";
				Lbl1.Font.Bold = true;

				Label lbl2 = new Label();
				lbl2.ID = "LBL_KET" + i;
				lbl2.Text = dt.Rows[i][7].ToString()+" ("+dt.Rows[i][6].ToString()+")";
				lbl2.Font.Bold = true;
				CL_SEQ	= dt.Rows[i][2].ToString();

//				HyperLink t = new HyperLink();
//				t.Text = dt.Rows[i][7].ToString()+" ("+dt.Rows[i][6].ToString()+")";
//				t.ID = "COLL_LINK"+ i;
//				t.Font.Bold = true;
//				CL_SEQ	= dt.Rows[i][2].ToString();
//				t.NavigateUrl = "AppraisalEntry.aspx?regno="+LBL_REGNO.Text+"&curef="+LBL_CUREF.Text+"&cl_seq="+ CL_SEQ;
//				t.Target = "ApprResult";


				conn.QueryString = "select * from APPR_LIST where AP_REGNO = '" + APREGNO + "' and "+
					"CU_REF = '" + CUREF + "' and  CL_SEQ = '" + CL_SEQ + "'";
				conn.ExecuteQuery();

				ApprType = conn.GetFieldValue("AL_APPRTYPE");
				ApprID = conn.GetFieldValue("AL_APPRID");

				if (ApprID == "") ApprID = "0";



				DropDownList ddl = new DropDownList();
				ddl.ID = "COLL_TYPE" + i;
				ddl.Items.Add(new ListItem("-Pilih-",""));
				ddl.Items.Add(new ListItem("Bangunan","PenilaianJaminanBangunan.aspx?cl_seq="+ CL_SEQ));
				ddl.Items.Add(new ListItem("Kendaraan","PenilaianJaminanNonTanah.aspx?cl_seq="+ CL_SEQ));
				ddl.Items.Add(new ListItem("Kios","PenilaianJaminanStand.aspx?cl_seq="+ CL_SEQ));
				ddl.Items.Add(new ListItem("RUKO","PenilaianJaminanRUKO.aspx?cl_seq="+ CL_SEQ));
				ddl.Items.Add(new ListItem("RUSUN","PenilaianJaminanRUSUN.aspx?cl_seq="+ CL_SEQ));
				ddl.Items.Add(new ListItem("Sawah","PenilaianJaminanSawah.aspx?cl_seq="+ CL_SEQ));
				ddl.Items.Add(new ListItem("SPBU","PenilaianJaminanSPBU.aspx?cl_seq="+ CL_SEQ));
				ddl.Items.Add(new ListItem("Tanah","PenilaianJaminanTanah.aspx?cl_seq="+ CL_SEQ));
				//ddl.Items.Add(new ListItem("Tanah & Bangunan","PenilaianJaminanTanahBangunan.aspx?cl_seq="+ CL_SEQ));
				ddl.Items.Add(new ListItem("Standar","AppraisalEntry.aspx?cl_seq="+ CL_SEQ));
				ddl.Items.Add(new ListItem("Standar New","AppraisalNew.aspx?cl_seq="+ CL_SEQ));
				
								
				///////////////////////////////////////////////////////////////////
				///	Check untuk disable/enable picklist form appraisal
				///	

				/// appraisal form belum ditentukan
				/// 
				if (ApprID == "0")
				{
					/*
                    if (vSG_GRPUNIT == "CO")	/// CO yang hanya bisa memilih jenis form-nya
					{
                    */
						ddl.Items.Clear();
						ddl.Items.Add(new ListItem("-Pilih-",""));
						ddl.Items.Add(new ListItem("Standar New","AppraisalNew.aspx?cl_seq="+ CL_SEQ));
						try {ddl.SelectedValue = "Standar New";}
						catch {}
						ddl.Enabled = true;
					/*
                    }
					else						/// BU tidak bisa memilih jenis form
						ddl.Enabled = false;
                    */
				}					
				else
				{
					/// Appraisal form sudah ditentukan
					/// 
					try { ddl.SelectedIndex = Convert.ToByte(ApprID); } catch {}
					ddl.Enabled = false;
				}


				//ddl.Enabled = false; //ahmad

				Button btn = new Button();
				btn.ID = "COLL_BTN" + i;
				btn.Text = "View";
				btn.Click += new EventHandler(btn_Click);				

				/****
				HyperLink t1 = new HyperLink();
				t1.Text = "standar";
				t1.ID = "COLL_LINK1"+ i;
				t1.Font.Bold = true;
				CL_SEQ	= dt.Rows[i][2].ToString();
				t1.NavigateUrl = "AppraisalEntry.aspx?regno="+LBL_REGNO.Text+"&curef="+LBL_CUREF.Text+"&CL_SEQ="+ CL_SEQ;
				t1.Target = "ApprResult";

				HyperLink t2 = new HyperLink();
				t2.Text = "custom";
				t2.ID = "COLL_LINK2"+ i;
				t2.Font.Bold = true;
				CL_SEQ	= dt.Rows[i][2].ToString();
				t2.NavigateUrl = "PenilaianJaminanBangunan.aspx";
				t2.Target = "ApprResult";
				***/


				no_row = (i*2)+1;
				this.Table_List.Rows.Add(new TableRow());
				this.Table_List.Rows[no_row].CssClass = BGCOLOR;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());				
				this.Table_List.Rows[no_row].Cells[0].Controls.Add(Lbl1);
				this.Table_List.Rows[no_row].Cells[0].VerticalAlign = VerticalAlign.Top;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(lbl2);
				this.Table_List.Rows[no_row].Cells[1].VerticalAlign = VerticalAlign.Top;

				//menamabah control tipe screen
				no_row = no_row + 1;
				this.Table_List.Rows.Add(new TableRow());
				this.Table_List.Rows[no_row].CssClass = BGCOLOR;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());				
				this.Table_List.Rows[no_row].Cells[0].Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
				this.Table_List.Rows[no_row].Cells[0].VerticalAlign = VerticalAlign.Top;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());				
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(ddl);
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(btn);
				this.Table_List.Rows[no_row].Cells[1].VerticalAlign = VerticalAlign.Top;

//				no_row = no_row + 1;
//				this.Table_List.Rows.Add(new TableRow());
//				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
//				this.Table_List.Rows[no_row].Cells[0].ColumnSpan = 2;
//				this.Table_List.Rows[no_row].Cells[0].Controls.Add(new LiteralControl("&nbsp&nbsp"));
//				this.Table_List.Rows[no_row].CssClass = BGCOLOR;
			}
		}

		protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}

		private void btn_Click(object sender, EventArgs e)
		{
			Button b = (Button) sender;
			string seq = b.ID.Replace("COLL_BTN","");
			
			DropDownList dl = (DropDownList) Page.FindControl("COLL_TYPE" + seq);
			Label lbl = (Label) Page.FindControl("COLL_LBL" + seq);
			string CL_SEQ = lbl.Text.Trim().Replace(".","");

			string link = dl.SelectedValue + "&regno="+ APREGNO +"&curef="+ CUREF + "&tc=" + TC + "&mc=" + MC;

			if (dl.SelectedIndex == 0)
			{
				GlobalTools.popMessage(this,"Jenis form appraisal harus dipilih");
				GlobalTools.SetFocus(this,dl);
			}
			else
			{
				coldetail.Attributes.Add("src", link);
			}
		}
	}
}
