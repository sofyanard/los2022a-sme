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
using Microsoft.VisualBasic;

namespace SME.RejectMaintenanceDE
{
	/// <summary>
	/// Summary description for StrucCreditDetailM22.
	/// </summary>
	public partial class StrucCreditDetailM22 : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlTableRow tr;
		//protected Connection conn = new Connection("Data Source = 10.123.12.30; Initial Catalog=SMEDEV; uid=sa; pwd=;");
		protected Tools tool = new Tools();
		protected Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if(!IsPostBack)
			{
				LBL_REGNO.Text	= Request.QueryString["regno"];
				LBL_PRODID.Text	= Request.QueryString["prodid"];
				LBL_APPTYPE.Text= Request.QueryString["apptype"];
				LBL_PRODUCT.Text= Request.QueryString["teks"];
				LBL_PROD_SEQ.Text= Request.QueryString["prod_seq"];

				conn.QueryString = "select cu_ref from application where ap_regno='"+ LBL_REGNO.Text +"' ";
				conn.ExecuteQuery();
				LBL_CU_REF.Text = conn.GetFieldValue("cu_ref");
				conn.ClearData();
				isiddl();
				isiGrid1();
				viewdata();
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
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);
			this.DatGrd1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd1_ItemCommand);
			this.DatGrd1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd1_PageIndexChanged);

		}
		#endregion

		void isiddl()
		{
			DDL_CL_ID.Items.Clear();
			/*
			conn.QueryString = "SELECT a.CL_SEQ, isnull(a.cl_desc,'')+' ('+a.COLTYPEDESC+')' as cl_desc FROM  VW_COLLATERAL1 a "+
				"WHERE a.cu_ref='"+LBL_CU_REF.Text+"' and (a.CL_SEQ NOT IN (SELECT b.cl_seq FROM list-collateral b "+
				"WHERE a.cl_seq = b.cl_seq and b.ap_regno='"+LBL_REGNO.Text+"' and b.productid='"+LBL_PRODID.Text+"'))";
			conn.ExecuteQuery();
			*/
			conn.QueryString = "select DISTINCT cl.CL_SEQ, cl.CL_TYPE, ct.COLTYPEDESC, ct.COLLINKTABLE, cl.CL_DESC, "+
				"case isnull(lc.AP_REGNO,'') when '' then ca.AP_REGNO else lc.AP_REGNO end as AP_REGNO "+
				"from COLLATERAL cl join RFCOLLATERALTYPE ct on cl.CL_TYPE = ct.COLTYPESEQ "+
				"left join LISTCOLLATERAL lc on lc.CU_REF = cl.CU_REF and lc.CL_SEQ = cl.CL_SEQ "+
				"left join COLLATERAL_ADDDE ca on ca.CU_REF = cl.CU_REF and ca.CL_SEQ = cl.CL_SEQ "+
				"where (lc.AP_REGNO = '" + Request.QueryString["regno"] + "' or ca.AP_REGNO = '" + Request.QueryString["regno"] + "') " + 
				"and cl.cl_seq not in (select endi.cl_seq from listcollateral endi where ap_regno='" + Request.QueryString["regno"] + 
				"' and productid='" + LBL_PRODID.Text + "' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "')";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			DDL_CL_ID.Items.Add(new ListItem("-- PILIH --", ""));
			string CLFILTER = "", KOMA = "";
			for (int i = 0;i < row;i++)
			{
				DDL_CL_ID.Items.Add(new ListItem(conn.GetFieldValue(i, "CL_DESC") + " (" + conn.GetFieldValue(i,2) + ")", conn.GetFieldValue(i,0)));
				if (conn.GetFieldValue(i,0).ToString().Trim() != "")
				{
					CLFILTER = CLFILTER + KOMA + conn.GetFieldValue(i,0).ToString().Trim();
					KOMA = ",";
				}
				//DDL_CL_ID.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
			}
			string QuL = "";
			QuL	= "select CL_SEQ, CL_DESC, COLTYPEDESC from COLLATERAL cl "+
				"left join RFCOLLATERALTYPE rf on cl.CL_TYPE = rf.COLTYPESEQ where isnull(SIBS_COLID,'') <> '' and CU_REF = (select CU_REF from APPLICATION where AP_REGNO = '"+Request.QueryString["regno"]+"') "+
				"and cl.cl_seq not in (select endi.cl_seq from listcollateral endi where ap_regno='" + Request.QueryString["regno"] + 
				"' and productid='" + LBL_PRODID.Text + "' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "')";
			
			if (CLFILTER.Trim() != "")
			{
				CLFILTER = "(" +CLFILTER+")";
				QuL	= QuL	+ " and cl.cl_seq not in "+CLFILTER;
			}
			conn.QueryString = QuL;
			conn.ExecuteQuery();
			row = conn.GetRowCount();
			for (int i = 0;i < row;i++)
				DDL_CL_ID.Items.Add(new ListItem(conn.GetFieldValue(i, "CL_DESC") + " (" + conn.GetFieldValue(i,"COLTYPEDESC") + ")", conn.GetFieldValue(i,"CL_SEQ")));
			//conn.ClearData();
		}

		void viewdata()
		{
			conn.QueryString="select APPTYPEDESC, PRODUCTDESC, BC_LOANAMOUNT, CURRENCY, AA_NO, ACC_SEQ, "+
				"CP_KETERANGAN, CP_JANGKAWKT, CP_TENORCODE, REVOLVING "+
				"from VW_CUSTPRODUCT where ap_regno='"+ LBL_REGNO.Text + "' and productid='"+ LBL_PRODID.Text +
				"' and apptype='"+LBL_APPTYPE.Text+"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			TXT_APPTYPE.Text				= conn.GetFieldValue("APPTYPEDESC");
			TXT_PRODUCT.Text				= conn.GetFieldValue("PRODUCTDESC");
			TXT_REVOLVING.Text				= conn.GetFieldValue("REVOLVING");
			TXT_CP_LIMIT.Text				= conn.GetFieldValue("BC_LOANAMOUNT");
			LBL_CURRENCY.Text				= conn.GetFieldValue("CURRENCY");
			TXT_JANGKAWAKTU.Text			= conn.GetFieldValue("CP_JANGKAWKT");
			TXT_AA_NO.Text					= conn.GetFieldValue("AA_NO");
			TXT_ACCSEQ.Text					= conn.GetFieldValue("ACC_SEQ");
			string tenor					= conn.GetFieldValue("CP_TENORCODE");
			TXT_CP_KETERANGAN.Text			= conn.GetFieldValue("CP_KETERANGAN");
			conn.ClearData();
			conn.QueryString = "select TENORDESC from RFTENORCODE where TENORCODE='"+tenor+"'";
			conn.ExecuteQuery();
			LBL_TENORCODE.Text				= conn.GetFieldValue("TENORDESC");
			conn.ClearData();
			isiGrid();
			tidakisiCollateral();
		}

		void isiGrid()
		{
			DataTable dt = new DataTable();
			conn.QueryString = "select cl_seq, cl_desc, coltypedesc, cl_percent, cl_value " +
				"from vw_bookedcollateral where aa_no='" + TXT_AA_NO.Text + "' and " +
				"productid='" + LBL_PRODID.Text + "' ";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			DatGrd.DataBind();
			double nilaiAkhir = 0;

			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				nilaiAkhir = double.Parse(DatGrd.Items[i].Cells[3].Text) * (double.Parse(DatGrd.Items[i].Cells[2].Text) / 100);
				DatGrd.Items[i].Cells[3].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[3].Text);
				DatGrd.Items[i].Cells[4].Text = tool.MoneyFormat(nilaiAkhir.ToString());
				DatGrd.Items[i].Cells[2].Text = DatGrd.Items[i].Cells[2].Text+" %";
			}
		}

		private void isiGrid1()
		{
			DataTable dt = new DataTable();
			conn.QueryString="select a.ap_regno, a.cl_seq, a.productid,c.coltypedesc, a.lc_percentage, b.cl_value, lc_value, b.cl_desc, "+
				"action = case when a.LC_ACTION='1' then 'Add' when a.LC_ACTION='2' then 'Remove' when a.LC_ACTION='3' then 'Re-Appraise' end "+
				"from listcollateral a inner join collateral b on " +
				"a.cl_seq = b.cl_seq inner join rfcollateraltype c on b.cl_type = c.coltypeseq " +
				"inner join application d on a.ap_regno = d.ap_regno and b.cu_ref=d.cu_ref "+
				"where a.ap_regno = '"+LBL_REGNO.Text+"' and a.productid='"+ LBL_PRODID.Text+
				"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrd1.DataSource = dt;
			DatGrd1.DataBind();
			for (int i = 0; i < DatGrd1.Items.Count; i++)
			{
				DatGrd1.Items[i].Cells[3].Text = DatGrd1.Items[i].Cells[3].Text+" %";
				DatGrd1.Items[i].Cells[4].Text = tool.MoneyFormat(tool.ConvertFloat(DatGrd1.Items[i].Cells[4].Text));
				DatGrd1.Items[i].Cells[5].Text = tool.MoneyFormat(tool.ConvertFloat(DatGrd1.Items[i].Cells[5].Text));
			}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			isiGrid();
		}

		protected void DDL_CL_ID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "SELECT a.CL_VALUE, a.COLTYPEDESC FROM  VW_COLLATERAL1 a "+
				"WHERE a.cl_seq = "+tool.ConvertNum(DDL_CL_ID.SelectedValue)+" and a.cu_ref='"+LBL_CU_REF.Text+"' and (a.CL_SEQ NOT IN (SELECT b.cl_seq FROM listcollateral b "+
				"WHERE a.cl_seq = b.cl_seq and b.ap_regno='"+LBL_REGNO.Text+
				"' and b.productid='"+LBL_PRODID.Text+"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'))";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			if (row > 0) 
			{
				TXT_LC_VALUE.Text			= tool.MoneyFormat(conn.GetFieldValue("CL_VALUE"));
				TXT_CL_DESC.Text			= conn.GetFieldValue("COLTYPEDESC");
				TXT_LC_PERCENTAGE.ReadOnly	= false;
				TXT_LC_PERCENTAGE.Text		= "0";
				TXT_ENDVALUE.Text			= "0";
			}
			else
				tidakisiCollateral();				
			conn.ClearData();
		}
		
		void tidakisiCollateral()
		{
			TXT_LC_VALUE.Text			= "0";
			TXT_LC_PERCENTAGE.Text		= "0";
			TXT_LC_PERCENTAGE.ReadOnly	= true;
			TXT_ENDVALUE.Text			= "0";
			TXT_CL_DESC.Text			= "";
		}

		protected void insert_Click(object sender, System.EventArgs e)
		{
			if(DDL_CL_ID.SelectedValue != "")
			{
				float persen = float.Parse(TXT_LC_PERCENTAGE.Text);
				if ( persen>0 && (persen<100 || persen == 100))
				{
					conn.QueryString = "exec SP_LISTCOLLPROCESS '"+LBL_REGNO.Text+"', '"+ LBL_APPTYPE.Text +"','"+ LBL_CU_REF.Text +"', '"+LBL_PRODID.Text+"', "+tool.ConvertNum(DDL_CL_ID.SelectedValue)+", "+TXT_LC_PERCENTAGE.Text+", "+tool.ConvertFloat(TXT_ENDVALUE.Text)+", '"+rdoAction.SelectedValue.Trim()+"', '" + LBL_PROD_SEQ.Text + "'";
					conn.ExecuteNonQuery();
				}
			}
			isiddl();
			isiGrid1();
			tidakisiCollateral();
			DDL_CL_ID.SelectedValue	= "";
			//Server.Transfer("M21M22PerubahanJaminan.aspx?regno="+LBL_REGNO.Text+"&prodid="+LBL_PRODID.Text+"&apptype="+LBL_APPTYPE.Text+"&teks="+LBL_PRODUCT.Text);
		}

		protected void TXT_LC_PERCENTAGE_TextChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select persen from VW_PERCENTAGE_COL where cu_ref='"+LBL_CU_REF.Text+"' and cl_seq="+DDL_CL_ID.SelectedValue+"";
			conn.ExecuteQuery();
			float batas		= float.Parse(conn.GetFieldValue("persen"));
			float persen	= float.Parse(TXT_LC_PERCENTAGE.Text);
			float hasil		= 0;
			if ((batas+persen)>100)
			{
				Tools.popMessage(this,"Penggunaan Collateral ini melebihi 100%");
				TXT_LC_PERCENTAGE.Text	= "0";
				Tools.SetFocus(this,TXT_LC_PERCENTAGE);
				TXT_LC_VALUE.Text	= tool.MoneyFormat(tool.ConvertFloat(TXT_LC_VALUE.Text));
			}
			else
			{
				string temp			= tool.ConvertFloat(TXT_LC_VALUE.Text);
				temp				= temp.Replace(".", ",");
				//float nilai			= float.Parse(tool.ConvertNum(TXT_LC_VALUE.Text));
				float nilai			= float.Parse(temp);
				hasil				= (nilai * persen) / 100;
			}
			TXT_ENDVALUE.Text	= tool.MoneyFormat(hasil.ToString());
		}

		private void DatGrd1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd1.CurrentPageIndex = e.NewPageIndex;
			isiGrid1();
		}

		private void DatGrd1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			conn.QueryString="delete from listcollateral where ap_regno='"+ LBL_REGNO.Text +
				"' and productid='"+ LBL_PRODID.Text +"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "' "+
				" and cl_seq ="+int.Parse(tool.ConvertNum(e.Item.Cells[0].Text))+" ";
			conn.ExecuteNonQuery();

			int index = DatGrd1.Items.Count;
			int jml = (index % 3)-1;
			if (jml == 0)
				DatGrd1.CurrentPageIndex = index/3;

			isiGrid1();
			isiddl();
			tidakisiCollateral();
		}

		protected void update_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "update custproduct set cp_keterangan = '" + TXT_CP_KETERANGAN.Text + 
				"' , AA_NO = '" + TXT_AA_NO.Text + "' , '" + TXT_ACCSEQ.Text +
				"' where ap_regno='"+ LBL_REGNO.Text +"' and productid='"+ LBL_PRODID.Text +
				"' and apptype='"+LBL_APPTYPE.Text+"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteNonQuery();
		}
	}
}
