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
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.Facilities
{
	/// <summary>
	/// Summary description for InquiryDocumentTracking.
	/// </summary>
	public partial class InquiryDocumentTracking : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
	
		protected Connection conn;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
			//	Response.Redirect("/SME/Restricted.aspx");

			if(!IsPostBack)
			{
				IsiGrid_App("select * from vw_app_cust_personal where ap_regno = ''");
				IsiDDL();
			}
		}

		private void IsiGrid_App(string isiQuery)
		{
			DataTable dt = new DataTable();
			conn.QueryString=isiQuery;
			try 
			{
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return;
			}

			dt = conn.GetDataTable().Copy();
			//if (cek!=1)
			//DatGrd_App.Columns.Remove(DatGrd_App.Columns[3]);
			DatGrd_App.DataSource = dt;
			try 
			{
				DatGrd_App.DataBind();
			} 
			catch 
			{
				DatGrd_App.CurrentPageIndex = DatGrd_App.PageCount - 1;
				DatGrd_App.DataBind();
			}
		}

		private void IsiDDL()
		{
			DDL_MONTH.Items.Add(new ListItem("-- Select --",""));
			for (int i = 1; i <= 12; i++)
			{
				DDL_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}

			conn.QueryString = "select * from rfarea";
			conn.ExecuteQuery();
			DDL_AREA.Items.Add(new ListItem("-- Select --",""));
			for (int i = 0 ; i < conn.GetRowCount();i++)
			{
				DDL_AREA.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
			conn.ClearData();
		}

		private void IsiGrid(string ap_regno)
		{
			DataTable dt = new DataTable();
			conn.QueryString="select * from VW_F_DOCTRACK_HISTORY where ap_regno = '"+ ap_regno +
				"' AND (ORIGINAL is null or ORIGINAL = '1')";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = DatGrd.PageCount - 1;
				DatGrd.DataBind();
			}
			conn.ClearData();
			System.Web.UI.WebControls.Image img;
			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				img = (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[4].FindControl("IMG_ORIGINAL");
				if(DatGrd.Items[i].Cells[5].Text == "1")
					img.ImageUrl = "../image/Complete.gif";
				else if(DatGrd.Items[i].Cells[5].Text == "0")
					img.ImageUrl = "../image/UnComplete.gif";
				else
					img.Visible = false;
			}
		}

		private void ViewData(string ap_regno, string productid, string apptype, string PROD_SEQ)
		{
			conn.QueryString = "select * from vw_app_cust_personal where ap_regno = '"+ ap_regno +"' and productid = '"+
				productid+"' and apptype = '"+apptype+"' and prod_seq = '" + PROD_SEQ + "'" +
				"union "+
				"select * from vw_app_cust_company where ap_regno = '"+ ap_regno +
				"' and productid = '"+ productid + 
				"' and apptype = '" + apptype + 
				"' and prod_seq = '" + PROD_SEQ + "'";
			conn.ExecuteQuery();
			TXT_IDNUMBER.Text = conn.GetFieldValue("cu_idcardnum");
			
			TXT_APPNO.Text = conn.GetFieldValue("ap_regno");
			TXT_NAME.Text = conn.GetFieldValue("Nama");
			TXT_DATE.Text = tool.FormatDate_Day(conn.GetFieldValue("ap_recvdate"));
			DDL_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("ap_recvdate"));
			TXT_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("ap_recvdate"));
			DDL_AREA.SelectedValue = conn.GetFieldValue("areaid");
			string branch = conn.GetFieldValue("branch_code");
			conn.ClearData();
			conn.QueryString = "select branch_code,branch_name from vw_branch where areaid = '"+ DDL_AREA.SelectedValue +"'";
			conn.ExecuteQuery();
			DDL_BRANCH.Items.Clear();
			DDL_BRANCH.Items.Add(new ListItem("-- Select --",""));
			string kd_branch ;
			bool same_branch = false;
			for (int i=0;i<conn.GetRowCount();i++)
			{
				kd_branch = conn.GetFieldValue(i,0);
				if (kd_branch == branch)
					same_branch = true;
				DDL_BRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
			if (same_branch)
				DDL_BRANCH.SelectedValue = branch;
			conn.ClearData();
		}
		
		private string CekJmlRecord(string Query)
		{
			conn.QueryString = Query;
			try 
			{
				conn.ExecuteQuery();
			} 
			catch (ApplicationException) 
			{
				Tools.popMessage(this, "Input tidak valid !");
				return "";
			}
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Server Error !");
				return "";
			}

			int i = conn.GetRowCount();
			string ap_regno = conn.GetFieldValue("ap_regno");
			conn.ClearData();
			if (i == 1)
				return ap_regno;
			else
				return "";
		}

		private string Query(string ap_regno,string name,string ap_recvdate,string cu_idcardnum,string areaid,string branchcode)
		{
			string where="";
			if (!ap_regno.Equals(""))
				where = " ap_regno = '"+ ap_regno +"'";
			if (!name.Equals(""))
			{
				if (!where.Equals(""))
					where = where +" and ltrim(rtrim(Nama)) like  '%"+ name +"%'";
				else
					where = " ltrim(rtrim(Nama)) like  '%"+ name +"%'";
			}
			//if (ap_recvdate != "" || ap_recvdate!=null || ap_recvdate != "null")
			if (TXT_DATE.Text != "")
			{
				if (where != "")
					where = where +" and ap_recvdate = "+ap_recvdate+"";
				else
					where = " ap_recvdate = "+ap_recvdate+"";
			}
			
			if (!areaid.Equals(""))
			{
				if(!where.Equals(""))
					where = where +" and areaid = '"+ areaid +"'";
				else
					where = " areaid = '"+ areaid +"'";
			}
			if (!branchcode.Equals(""))
			{
				if(!where.Equals(""))
					where = where +" and branch_code = '"+ branchcode +"'";
				else
					where = " branch_code = '"+ branchcode +"'";
			}
			
			if (!cu_idcardnum.Equals(""))
			{
				if (!where.Equals(""))
					where = where +" and cu_idcardnum = '"+ cu_idcardnum +"'";
				else
					where = " cu_idcardnum = '"+ cu_idcardnum +"'";
			}
			if (!where.Equals(""))
				return "select * from vw_app_cust_personal where "+ where +" "+
					"union "+
					"select * from vw_app_cust_company where "+ where +"";
			else
				return "select * from vw_app_cust_personal "+
					"union "+
					"select * from vw_app_cust_company";
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
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);
			this.DatGrd_App.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_App_ItemCommand);
			this.DatGrd_App.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_App_PageIndexChanged);

		}
		#endregion

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			string isiQuery = Query(TXT_APPNO.Text,TXT_NAME.Text,tool.ConvertDate(TXT_DATE.Text,DDL_MONTH.SelectedValue,TXT_YEAR.Text),TXT_IDNUMBER.Text,DDL_AREA.SelectedValue,DDL_BRANCH.SelectedValue);
			string cek = CekJmlRecord(isiQuery);
			if (cek=="")//jumlah record != 1
			{
				DatGrd.Visible = false;
				DatGrd_App.Visible = true;
				IsiGrid_App(isiQuery);
			}
			else //jmulah record = 1
			{
				DatGrd.Visible = true;
				conn.QueryString = "select PRODUCTID, APPTYPE, PROD_SEQ from CUSTPRODUCT where AP_REGNO = '"+cek+"'";
				conn.ExecuteQuery();
				ViewData(cek, conn.GetFieldValue("PRODUCTID"), conn.GetFieldValue("APPTYPE"), conn.GetFieldValue("PROD_SEQ"));
				IsiGrid(cek);
				DatGrd_App.Visible = false;
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			TXT_APPNO.Text = "";
			TXT_DATE.Text = "";
			TXT_IDNUMBER.Text = "";
			TXT_IDNUMBER.Enabled=true;
			TXT_NAME.Text = "";
			TXT_YEAR.Text = "";
			DDL_BRANCH.SelectedValue = "";
			DDL_AREA.SelectedValue = "";
			DDL_MONTH.SelectedValue = "";
			DDL_BRANCH.Items.Clear();
			IsiGrid("null");
		}

		private void DatGrd_App_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
					DatGrd.Visible = true;
					ViewData(e.Item.Cells[0].Text, e.Item.Cells[5].Text, e.Item.Cells[6].Text, e.Item.Cells[8].Text);
					IsiGrid(e.Item.Cells[0].Text);
					DatGrd_App.Visible = false;
					break;
			}
		}

		private void DatGrd_App_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd_App.Visible = true;
			DatGrd.Visible = false;
			DatGrd_App.CurrentPageIndex = e.NewPageIndex;
			string isiQuery = Query(TXT_APPNO.Text,TXT_NAME.Text,tool.ConvertDate(TXT_DATE.Text,DDL_MONTH.SelectedValue,TXT_YEAR.Text),TXT_IDNUMBER.Text,DDL_AREA.SelectedValue,DDL_BRANCH.SelectedValue);
			IsiGrid_App(isiQuery);
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			IsiGrid(TXT_APPNO.Text);
		}

		protected void DDL_AREA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!DDL_AREA.SelectedValue.Equals(""))
			{
				conn.QueryString = "select Branch_Name,Branch_Code from VW_BRANCH where AreaId = '"+ DDL_AREA.SelectedValue +"' ";
				conn.ExecuteQuery();
				DDL_BRANCH.Items.Add(new ListItem("-- Select --",""));
				for (int i = 0; i<conn.GetRowCount(); i++)
				{
					DDL_BRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,0),conn.GetFieldValue(i,1)));
				}
				conn.ClearData();
			}
			else
			{
				DDL_BRANCH.Items.Clear();
			}
		}
	}
}
