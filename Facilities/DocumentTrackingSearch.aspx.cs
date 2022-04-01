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
	/// Summary description for DocumentTrackingSearch.
	/// </summary>
	public partial class DocumentTrackingSearch : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
	
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

			conn.QueryString = "select * from rfarea where active = '1'";
			conn.ExecuteQuery();
			DDL_AREA.Items.Add(new ListItem("-- Select --",""));
			for (int i = 0 ; i < conn.GetRowCount();i++)
			{
				DDL_AREA.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
			conn.ClearData();
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
			this.DatGrd_App.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_App_ItemCommand);
			this.DatGrd_App.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_App_PageIndexChanged);

		}
		#endregion

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
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			string isiQuery = Query(TXT_APPNO.Text,TXT_NAME.Text,tool.ConvertDate(TXT_DATE.Text,DDL_MONTH.SelectedValue,TXT_YEAR.Text),TXT_IDNUMBER.Text,DDL_AREA.SelectedValue,DDL_BRANCH.SelectedValue);
			IsiGrid_App(isiQuery);
		}

		private void DatGrd_App_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd_App.CurrentPageIndex = e.NewPageIndex;
			string isiQuery = Query(TXT_APPNO.Text,TXT_NAME.Text,tool.ConvertDate(TXT_DATE.Text,DDL_MONTH.SelectedValue,TXT_YEAR.Text),TXT_IDNUMBER.Text,DDL_AREA.SelectedValue,DDL_BRANCH.SelectedValue);
			IsiGrid_App(isiQuery);
		}

		private void DatGrd_App_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string regno, tc = Request.QueryString["tc"], mc = Request.QueryString["mc"];
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					regno = e.Item.Cells[0].Text;
					Response.Redirect("DocumentTracking.aspx?regno=" + regno + "&tc="+ tc + "&mc=" + mc);
					break;
				default:
					break;
			}
		}
	}
}
