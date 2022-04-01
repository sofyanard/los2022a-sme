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

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for SubApplicationList.
	/// </summary>
	public partial class SubApplicationList : System.Web.UI.Page
	{
		protected Connection conn;
		private string regno, curef, mc, tc, de;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (Request.QueryString["de"] == "1")
				if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
					Response.Redirect("/SME/Restricted.aspx");

			regno	= (string) Request.QueryString["regno"];
			curef	= (string) Request.QueryString["curef"];
			mc		= (string) Request.QueryString["mc"];
			tc		= (string) Request.QueryString["tc"];
			de		= (string) Request.QueryString["de"];

			if (!IsPostBack) 
			{

				GlobalTools.fillRefList(DDL_KETKREDIT,"select KET_CODE, KET_DESC from KETENTUAN_KREDIT where AP_REGNO = '"+Request.QueryString["regno"]+"'",false,conn);			

				//---Mengambil program code---//
				conn.QueryString = "select PROG_CODE, AP_RELMNGR from APPLICATION where AP_REGNO = '" + regno + "'";
				conn.ExecuteQuery();
				LBL_PROG_CODE.Text	= conn.GetFieldValue("PROG_CODE");
				LBL_AP_RELMNGR.Text = conn.GetFieldValue("AP_RELMNGR");
				//----------------------------//
			}

			ViewMenu();		
			initEvents();	

		}

		private void initEvents() 
		{
			DDL_KETKREDIT.SelectedIndexChanged += new EventHandler(DDL_KETKREDIT_SelectedIndexChanged);
			DDL_PRODLIST.SelectedIndexChanged += new EventHandler(DDL_PRODLIST_SelectedIndexChanged);
			BTN_ADD.Click += new EventHandler(BTN_ADD_Click);
			DGR_SUBAPP.SortCommand += new DataGridSortCommandEventHandler(DGR_SUBAPP_SortCommand);
			DGR_SUBAPP.ItemCommand += new DataGridCommandEventHandler(DGR_SUBAPP_ItemCommand);
			DGR_SUBAPP.PageIndexChanged += new DataGridPageChangedEventHandler(DGR_SUBAPP_PageIndexChanged);
			BTN_BACK.Click += new ImageClickEventHandler(BTN_BACK_Click);
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

		#region " Defined Methods "

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

		private string getProductID(string regno, string ket_code, string prod_seq) 
		{
			conn.QueryString = "select PRODUCTID from CUSTPRODUCT where AP_REGNO = '" + regno + 
				"' and KET_CODE = '" + DDL_KETKREDIT.SelectedValue + 
				"' and PROD_SEQ = '" + DDL_PRODLIST.SelectedValue + "'";
			conn.ExecuteQuery();

			return conn.GetFieldValue("PRODUCTID");
		}

		private void viewData() 
		{
			try 
			{
				string SU_BRANCH = (string) Session["BranchID"];
				/***
				conn.QueryString = "exec DE_SUBAPPLICATION_LIST '" + 
									regno + "', '" + 
									SU_BRANCH + "', '" + 
									tc + "', '" + 
									DDL_KETKREDIT.SelectedValue + "', '" +
									DDL_PRODLIST.SelectedValue + "', '" +
									LBL_SORTEXP.Text + "', '" + 
									LBL_SORTTYPE.Text + "'";
				**/
				string productID = getProductID(regno, DDL_KETKREDIT.SelectedValue, DDL_PRODLIST.SelectedValue);

				conn.QueryString = "select * from VW_DE_SUBAPPLICATIONLIST where ap_mainapregno = '" + regno + "' " + 
					"and su_branch = '" + SU_BRANCH + "' " + 
					"and mainprod_seq = '" + DDL_PRODLIST.SelectedValue + "' " + 
					"and mainproductid = '" + productID + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException ex) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return;
			}

			DGR_SUBAPP.DataSource = conn.GetDataTable().DefaultView;
			try 
			{
				DGR_SUBAPP.DataBind();
			} 
			catch 
			{
				DGR_SUBAPP.CurrentPageIndex = 0;
				DGR_SUBAPP.DataBind();
			}

			setCancelConfirmation();
		}

		private void cekProductSubApp() 
		{
			try 
			{				
				conn.QueryString = "select SUPPORTSUBAPP from RFPRODUCT where PRODUCTID = '" + getProductID(regno, DDL_KETKREDIT.SelectedValue, DDL_PRODLIST.SelectedValue) + "'";
				conn.ExecuteQuery();
			}
			catch (NullReferenceException e) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			if (conn.GetFieldValue("SUPPORTSUBAPP") == "0")
				BTN_ADD.Enabled = false;
			else
				BTN_ADD.Enabled = true;
		}

		private void setCancelConfirmation() 
		{
			for(int i=0; i<DGR_SUBAPP.Items.Count; i++) 
			{
				LinkButton LNK_CANCEL = (LinkButton) DGR_SUBAPP.Items[i].Cells[8].FindControl("LNK_CANCEL");
				LNK_CANCEL.Attributes.Add("onclick","if(!batal()) { return false; };");

				if (Request.QueryString["de"] != "1") 
				{
					LNK_CANCEL.Visible = false;
				}
			}
		}

		#endregion

		protected void BTN_ADD_Click(object sender, System.EventArgs e)
		{
			if (DDL_PRODLIST.SelectedValue == "") 
			{
				GlobalTools.popMessage(this, "Product tidak boleh kosong!");
				return;
			}

			/////////////////////////////////////////////////////////
			///	Mendapatkan curef aplikasi
			regno	= (string) Request.QueryString["regno"];
			curef	= (string) Request.QueryString["curef"];
			mc		= (string) Request.QueryString["mc"];
			tc		= (string) Request.QueryString["tc"];
			de		= (string) Request.QueryString["de"];
			
			Response.Write("<script for=window event=onload language='javascript'>" + 
						"PopupPage('IDE_FindCustomer.aspx?mainregno=" + regno + 
							"&mainprod_seq=" + DDL_PRODLIST.SelectedValue +
							"&mainproductid=" + getProductID(regno, DDL_KETKREDIT.SelectedValue, DDL_PRODLIST.SelectedValue) +
							"&maincuref=" + curef + 
							"&mc=" + mc + 
							"&tc=" + tc + 
							"&de=" + de + 
							"&rm=" + LBL_AP_RELMNGR.Text + 
							"&formParent=Form1" +
							"&controlParent=DDL_PRODLIST" +
						"', '1000','620');</script>");
			
		}

		private void DGR_SUBAPP_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			LBL_SORTEXP.Text = e.SortExpression;
			if (LBL_SORTTYPE.Text == "ASC") LBL_SORTTYPE.Text = "DESC";
			else LBL_SORTTYPE.Text = "ASC";
            
			viewData();
		}

		private void DGR_SUBAPP_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string subRegno, subCuref;
			switch (e.CommandName.ToString()) 
			{
				case "View":
					subRegno = e.Item.Cells[0].Text;
					subCuref = e.Item.Cells[1].Text;					

					Response.Write("<script for=window event=onload language='javascript'>" + 
						"PopupPage('SubApplicationMain.aspx?mainregno=" + regno + 
						"&mainprod_seq=" + DDL_PRODLIST.SelectedValue +
						"&mainproductid=" + getProductID(regno, DDL_KETKREDIT.SelectedValue, DDL_PRODLIST.SelectedValue) +
						"&maincuref=" + curef + 
						"&regno=" + subRegno +
						"&curef=" + subCuref +
						"&mc=" + mc + 
						"&tc=" + tc + 
						"&de=" + de + 
						"&rm=" + LBL_AP_RELMNGR.Text + 
						"&controlParent=DDL_PRODLIST&formParent=Form1&exist=1" +
						"', '1000','620');</script>");
					break;
					
				case "Cancel":
					subRegno = e.Item.Cells[0].Text;
					subCuref = e.Item.Cells[1].Text;					

					//conn.QueryString = "update APPLICATION set AP_REJECT = '1', AP_CANCEL = '1' where AP_REGNO = '" + subRegno + "'";
					conn.QueryString = "exec KET_KREDIT null, null, '" + subRegno + "', null, null, null, null,'3'";
					conn.ExecuteNonQuery();

					viewData();
					break;
			}
		}

		private void DGR_SUBAPP_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_SUBAPP.CurrentPageIndex = e.NewPageIndex;
			viewData();
		}

		private void DDL_KETKREDIT_SelectedIndexChanged(object sender, System.EventArgs e)
		{	
			DGR_SUBAPP.Visible = false;
			BTN_ADD.Enabled = false;
			DDL_PRODLIST.Items.Clear();

			//GlobalTools.fillRefList(DDL_PRODLIST, "select A.PRODUCTID, A.PROD_SEQ + '|' + B.PRODUCTDESC as PRODUCTDESC from custproduct A, RFPRODUCT B where ap_regno = '"+Request.QueryString["regno"]+"' AND A.PRODUCTID = B.PRODUCTID AND A.KET_CODE='" + DDL_KETKREDIT.SelectedValue + "'", true, conn);
			GlobalTools.fillRefList(DDL_PRODLIST, "select distinct A.PROD_SEQ, A.PRODUCTID + '|' + B.PRODUCTDESC as PRODUCTDESC from custproduct A, RFPRODUCT B where ap_regno = '"+Request.QueryString["regno"]+"' AND A.PRODUCTID = B.PRODUCTID AND A.KET_CODE='" + DDL_KETKREDIT.SelectedValue + "'", false, conn);
		}

		private void DDL_PRODLIST_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DGR_SUBAPP.Visible = true;
			cekProductSubApp();
			viewData();
		}

		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["par"] != null && Request.QueryString["par"] != "") 
				Response.Redirect(Request.QueryString["par"] + "&regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"]);
			else
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));		
		}		
	}
}
