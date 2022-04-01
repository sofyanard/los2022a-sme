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

namespace SME.CustomerInfo
{
	/// <summary>
	/// Summary description for InfoCollateral.
	/// </summary>
	public partial class InfoCollateral : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		//protected System.Web.UI.WebControls.TextBox TXT_CL_PERCENT;
		//protected Connection conn = new Connection("Data Source=10.204.9.78;Initial Catalog=SME;uid=sa;pwd=");
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				DDL_ACC_SEQ.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_SEQ.Items.Add(new ListItem("- PILIH -", ""));
				DDL_AI_FACILITY.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CURR.Items.Add(new ListItem("- PILIH -", ""));

				string curef = Request.QueryString["curef"];
				conn.QueryString = "select CL.CL_SEQ, CT.COLTYPEDESC, CL_DESC "+
					"from COLLATERAL CL "+
					"join RFCOLLATERALTYPE CT on CL.CL_TYPE = CT.COLTYPESEQ "+
					"where CU_REF = '"+ curef +"' order by COLTYPEDESC";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CL_SEQ.Items.Add(new ListItem(conn.GetFieldValue(i,2)+" ("+conn.GetFieldValue(i,1)+")", conn.GetFieldValue(i,0)));
				conn.ClearData();

				//--- Mata Uang
				conn.QueryString = "select rtrim(ltrim(currencyid)), currencyid+' - '+currencydesc from rfcurrency where active='1' order by currencyid";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CURR.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				conn.ClearData();

				DDL_AI_AA_NO.Items.Add(new ListItem("- PILIH -", ""));
				conn.QueryString = "select distinct rtrim(ltrim(aa_no)) from BOOKEDCUST where cu_ref='"+curef+"'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_AI_AA_NO.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
				conn.ClearData();
				ViewGrid();
			}
			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");

			//SecureData();
		}

		private void SecureData() 
		{
			BTN_SAVE.Enabled = false;
			Button1.Enabled = false;
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

		private void ViewGrid()
		{
			conn.QueryString = "select rtrim(ltrim(aa_no)) as aa_no, rtrim(ltrim(productid)) as productid, acc_no, acc_seq, cl_desc, coltypedesc, cl_percent, cl_value, cl_seq, sibs_colid, rtrim(ltrim(currencyid)) as currencyid "+
				"from VW_BOOKEDCOLLATERAL where cu_ref='"+Request.QueryString["curef"]+"'";	
			conn.ExecuteQuery();
			DataTable d = new DataTable();
			d			= conn.GetDataTable().Copy();
			DatGrd.DataSource	= d;
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
				DatGrd.Items[i].Cells[4].Text = DatGrd.Items[i].Cells[4].Text+" ("+DatGrd.Items[i].Cells[12].Text+")";
		}

		private void simpan()
		{
			conn.QueryString = "exec IN_BOOKEDCOLLATERAL '"+Request.QueryString["curef"]+"', '"+DDL_AI_AA_NO.SelectedValue+"', '"+DDL_AI_FACILITY.SelectedValue+"', "+
				tool.ConvertNum(DDL_ACC_SEQ.SelectedValue)+", "+tool.ConvertNum(DDL_CL_SEQ.SelectedValue)+", 0,'"+//tool.ConvertFloat(TXT_CL_PERCENT.Text)+", '"+
				TXT_SIBS_COLID.Text+"', "+tool.ConvertFloat(TXT_CL_VALUE.Text)+", '"+DDL_CURR.SelectedValue.Trim()+"', '0' ";
			conn.ExecuteNonQuery();
			ClearItems();
			ChangeSta(true);
			ViewGrid();
		}

		private void ClearItems()
		{
			DDL_ACC_SEQ.SelectedValue	= "";
			DDL_CL_SEQ.SelectedValue	= "";
			//TXT_CL_PERCENT.Text			= "";
			TXT_CL_VALUE.Text			= "";
			TXT_SIBS_COLID.Text			= "";	
			DDL_AI_AA_NO.SelectedValue	= "";
			DDL_AI_FACILITY.SelectedValue= "";
			DDL_CURR.SelectedValue		= "";
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Delete":
					conn.QueryString = "exec IN_BOOKEDCOLLATERAL '"+Request.QueryString["curef"]+"', '"+e.Item.Cells[0].Text+"', '"+e.Item.Cells[1].Text+"', "+tool.ConvertNum(e.Item.Cells[2].Text)+", "+tool.ConvertNum(e.Item.Cells[11].Text)+", "+tool.ConvertFloat(e.Item.Cells[5].Text)+", '"+TXT_SIBS_COLID.Text+"', "+tool.ConvertFloat(e.Item.Cells[7].Text)+", '"+DDL_CURR.SelectedValue+"', '1'";
					conn.ExecuteNonQuery();
					int index = DatGrd.Items.Count;			
					int jml = (index % 3)-1;
					if (jml == 0)
						DatGrd.CurrentPageIndex = index/3;
					ViewGrid();
					break;
				case "Edit":
					DDL_AI_AA_NO.SelectedValue		= e.Item.Cells[0].Text;
					GetFacility();
					DDL_AI_FACILITY.SelectedValue	= e.Item.Cells[1].Text;
					GetSeq();
					DDL_ACC_SEQ.SelectedValue		= e.Item.Cells[2].Text;
					DDL_CL_SEQ.SelectedValue		= e.Item.Cells[11].Text;
					DDL_CURR.SelectedValue			= e.Item.Cells[6].Text.Trim();
					//TXT_CL_PERCENT.Text				= e.Item.Cells[5].Text;
					TXT_CL_VALUE.Text				= e.Item.Cells[7].Text;
					string sibs						= e.Item.Cells[8].Text;
					if (sibs=="&nbsp;")
						sibs	= "";
					TXT_SIBS_COLID.Text				= sibs;
					ChangeSta(false);
					break;
			}
		}

		private void ChangeSta(bool sta)
		{
			DDL_ACC_SEQ.Enabled	= sta;
			DDL_CL_SEQ.Enabled	= sta;
			DDL_AI_AA_NO.Enabled	= sta;
			DDL_AI_FACILITY.Enabled	= sta;
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex	= e.NewPageIndex;
			ViewGrid();
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			ClearItems();
			ChangeSta(true);
		}

		protected void DDL_AI_AA_NO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			GetFacility();
		}

		private void GetFacility()
		{
			conn.QueryString = "select distinct rtrim(ltrim(productid)) from BOOKEDCUST where aa_no='"+DDL_AI_AA_NO.SelectedValue+"' and cu_ref='"+Request.QueryString["curef"]+"'";
			conn.ExecuteQuery();
			DDL_AI_FACILITY.Items.Clear();
			DDL_AI_FACILITY.Items.Add(new ListItem("- PILIH -", ""));
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_AI_FACILITY.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
			conn.ClearData();
		}

		protected void DDL_AI_FACILITY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			GetSeq();
		}

		private void GetSeq()
		{
			conn.QueryString = "select distinct b.acc_seq from bookedcust a inner join bookedprod b on a.productid=b.productid and a.aa_no=b.aa_no "+
				"where a.productid='"+DDL_AI_FACILITY.SelectedValue+"' and a.aa_no='"+DDL_AI_AA_NO.SelectedValue+"' and a.cu_ref='"+Request.QueryString["curef"]+"'";
			conn.ExecuteQuery();
			DDL_ACC_SEQ.Items.Clear();
			DDL_ACC_SEQ.Items.Add(new ListItem("- PILIH -", ""));
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_ACC_SEQ.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
			conn.ClearData();
		}

		protected void DDL_CL_SEQ_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select CL_PROPVALUE, isnull(rtrim(ltrim(cl_currency)),'') as cl_currency, rtrim(ltrim(SIBS_COLID)) as sibs_colid "+
				"from COLLATERAL "+
				"where CU_REF = '"+ Request.QueryString["curef"]+"' and CL_SEQ="+tool.ConvertNum(DDL_CL_SEQ.SelectedValue);
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
			{
				TXT_CL_VALUE.Text		= GlobalTools.MoneyFormat(conn.GetFieldValue("CL_PROPVALUE"));
				DDL_CURR.SelectedValue	= conn.GetFieldValue("cl_currency");
				TXT_SIBS_COLID.Text		= conn.GetFieldValue("SIBS_COLID");
			}
			else
			{
				TXT_CL_VALUE.Text		= "0";
				DDL_CURR.SelectedValue	= "";
				TXT_SIBS_COLID.Text		= "";
			}
			conn.ClearData();
		}
						
		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{								
			simpan();
		}

/*		private void TXT_CL_PERCENT_TextChanged(object sender, System.EventArgs e)
		{
			if (DDL_AI_FACILITY.Enabled == false)
				conn.QueryString = "SELECT isnull(SUM(a.CL_PERCENT),0) - (select isnull(SUM(x.CL_PERCENT),0)  FROM BOOKEDCOLLATERAL x INNER JOIN COLLATERAL y ON x.CL_SEQ=y.CL_SEQ "+
					"WHERE y.CU_REF='"+Request.QueryString["curef"]+"' AND x.CL_SEQ="+tool.ConvertNum(DDL_CL_SEQ.SelectedValue)+" "+
					"and x.aa_no='"+DDL_AI_AA_NO.SelectedValue+"' and x.productid='"+DDL_AI_FACILITY.SelectedValue+"' and x.acc_seq="+tool.ConvertNum(DDL_ACC_SEQ.SelectedValue)+") AS AMOUNT "+
					"FROM BOOKEDCOLLATERAL a INNER JOIN COLLATERAL b ON a.CL_SEQ=b.CL_SEQ "+
					"WHERE b.CU_REF='"+Request.QueryString["curef"]+"' AND a.CL_SEQ= "+tool.ConvertNum(DDL_CL_SEQ.SelectedValue);
			else
				conn.QueryString = "SELECT isnull(SUM(CL_PERCENT),0) AS AMOUNT FROM BOOKEDCOLLATERAL a INNER JOIN COLLATERAL b ON a.CL_SEQ=b.CL_SEQ "+
					"WHERE CU_REF='"+Request.QueryString["curef"]+"' AND a.CL_SEQ= "+tool.ConvertNum(DDL_CL_SEQ.SelectedValue);
			conn.ExecuteQuery();

			float limit		= float.Parse(tool.ConvertFloat(conn.GetFieldValue(0,0)));
			float persen	= float.Parse(tool.ConvertFloat(TXT_CL_PERCENT.Text));
			float total		= limit+persen;
			if (total>100)
			{
				Tools.popMessage(this,"Penggunaan Collateral ini sudah melebihi 100%");
				TXT_CL_PERCENT.Text		= "0";
				Tools.SetFocus(this,TXT_CL_PERCENT);
			}
		}*/
	}
}
