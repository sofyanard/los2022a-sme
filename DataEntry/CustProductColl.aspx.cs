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

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for CustProductColl.
	/// </summary>
	public partial class CustProductColl : System.Web.UI.Page
	{

		#region " My Variables "
		protected Connection conn;
		protected Tools tool = new Tools();
		#endregion
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack) 
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];

//				LBL_PRODUCTID.Text = Request.QueryString["productid"];
//				LBL_PROD_SEQ.Text = Request.QueryString["prod_seq"];


				///////////////////////////////////////////////////////////////////////
				/// Mengambil product dari ket code
				/// 
				conn.QueryString = "select PRODUCTID from KETENTUAN_KREDIT " + 
					"where ap_regno = '" + LBL_REGNO.Text + 
					"' and ket_code = '" + Request.QueryString["ket_code"] + "'";
				conn.ExecuteQuery();
				LBL_PRODUCTID.Text = conn.GetFieldValue("PRODUCTID");


				////////////////////////////////////////////////////////////////////////
				/// Mengambil prod_seq dari custproduct
				/// 
				conn.QueryString = "select isnull(PROD_SEQ, 0) PROD_SEQ from CUSTPRODUCT " + 
					" where AP_REGNO = '" + LBL_REGNO.Text + 
					"' and PRODUCTID = '" + LBL_PRODUCTID.Text + 
					"' and KET_CODE = '" + Request.QueryString["ket_code"] + "'";
				conn.ExecuteQuery();
				LBL_PROD_SEQ.Text = conn.GetFieldValue("PROD_SEQ");


				fillDropDowns();
				SelectColl();
				
				isiGrid1();
				isiGrid();
			}
		}

		private void fillDropDowns() 
		{
			string query = "select CURRENCYID, CURRENCYID from RFCURRENCY where ACTIVE = '1'";
			
			GlobalTools.fillRefList(DDL_COLLCURRENCY, query, false, conn);
		}

		private void SelectColl()
		{
			/////////////////////////////////////////////////////////////////////////////////////////////////
			///	bagian ini mirip dengan method SelectColl() di DataEntry/M21M22PermohonanBaru.aspx
			///	
			DDL_CL_ID.Items.Clear();
			//20070117 changed by sofyan, replace with stored procedure below
			//utk mengatasi jika ada satu aplikasi yg productid-nya sama
			//conn.QueryString = "select DISTINCT cl.CL_SEQ, cl.CL_TYPE, ct.COLTYPEDESC, ct.COLLINKTABLE, cl.CL_DESC, "+
			//	"case isnull(lc.AP_REGNO,'') when '' then ca.AP_REGNO else lc.AP_REGNO end as AP_REGNO "+
			//	"from COLLATERAL cl join RFCOLLATERALTYPE ct on cl.CL_TYPE = ct.COLTYPESEQ "+
			//	"left join LISTCOLLATERAL lc on lc.CU_REF = cl.CU_REF and lc.CL_SEQ = cl.CL_SEQ "+
			//	"left join COLLATERAL_ADDDE ca on ca.CU_REF = cl.CU_REF and ca.CL_SEQ = cl.CL_SEQ "+
			//	"where (lc.AP_REGNO = '" + LBL_REGNO.Text + "' or ca.AP_REGNO = '" + LBL_REGNO.Text + "') " + 
			//	"and cl.cl_seq not in (select endi.cl_seq from listcollateral endi where ap_regno='" + LBL_REGNO.Text + 
			//	"' and productid='" + LBL_PRODUCTID.Text + "') and lc.lc_exchangerate is not null";
			conn.QueryString = "exec OBTAIN_EXISTING_COLLATERAL_LIST '" + LBL_CUREF.Text + "', '" + LBL_REGNO.Text + "', '" + LBL_PRODUCTID.Text + "', '" + Request.QueryString["ket_code"] + "'";
			conn.ExecuteQuery();

			int row = conn.GetRowCount();
			DDL_CL_ID.Items.Add(new ListItem("- PILIH -", ""));
			string CLFILTER = "", KOMA = "";
			for (int i = 0;i < row;i++)
			{
				DDL_CL_ID.Items.Add(new ListItem(conn.GetFieldValue(i, "CL_DESC") + " (" + conn.GetFieldValue(i,2) + ")", conn.GetFieldValue(i,0)));
				if (conn.GetFieldValue(i,0).ToString().Trim() != "")
				{
					CLFILTER = CLFILTER + KOMA + conn.GetFieldValue(i,0).ToString().Trim();
					KOMA = ",";
				}				
			}
			string QuL = "";
			QuL	= "select CL_SEQ, CL_DESC, COLTYPEDESC from COLLATERAL cl "+
				"left join RFCOLLATERALTYPE rf on cl.CL_TYPE = rf.COLTYPESEQ where isnull(SIBS_COLID,'') <> '' and CU_REF = (select CU_REF from APPLICATION where AP_REGNO = '"+Request.QueryString["regno"]+"') "+
				"and cl.cl_seq not in (select endi.cl_seq from listcollateral endi where ap_regno='" + Request.QueryString["regno"] + "' and productid='" + LBL_PRODUCTID.Text + "')";
			
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
		}

		void isiCollateral()
		{
			TXT_LC_PERCENTAGE.ReadOnly	= false;
			TXT_LC_PERCENTAGE.Text		= "0";
			TXT_ENDVALUE.Text			= "0";

			//TXT_COLLAMOUNT.Text = "0";
			//TXT_COLLPLEDGE.Text = "0";
			//TXT_COLLEXRATE.Text = "0";

			//TXT_COLLAMOUNT.ReadOnly = false;
			TXT_COLLPLEDGE.ReadOnly = false;
			TXT_COLLEXRATE.ReadOnly = false;


			insert.Enabled = true;
			calc.Enabled = true;
		}

		void tidakisiCollateral()
		{
			//TXT_LC_VALUE.Text			= "0";


			TXT_LC_PERCENTAGE.Text		= "0";
			TXT_LC_PERCENTAGE.ReadOnly	= true;
			TXT_ENDVALUE.Text			= "0";
			TXT_CL_DESC.Text			= "";
			//DDL_COLLCURRENCY.SelectedValue = "";

			TXT_COLLAMOUNT.Text = "";
			TXT_COLLPLEDGE.Text = "";
			TXT_COLLEXRATE.Text = "";

			//TXT_COLLAMOUNT.ReadOnly = true;
			TXT_COLLPLEDGE.ReadOnly = true;
			TXT_COLLEXRATE.ReadOnly = true;

			calc.Enabled = false;
			insert.Enabled = false;
		}

		private void isiGrid()
		{
			DataTable dt = new DataTable();
			/***
			conn.QueryString="select a.ap_regno, a.cl_seq, a.productid, c.coltypedesc, a.lc_percentage, b.cl_value, lc_value, b.cl_desc, a.prod_seq, a.cl_currency, a.cl_exchangerate " + 
				" from LISTCOLLATERAL a inner join collateral b on " +
				"a.cl_seq = b.cl_seq inner join RFCOLLATERALTYPE c on b.cl_type = c.coltypeseq " +
				"inner join APPLICATION d on a.ap_regno = d.ap_regno and b.cu_ref=d.cu_ref "+
				"where a.ap_regno = '" + LBL_REGNO.Text + 
				"' and a.productid='" + LBL_PRODUCTID.Text + 
				"' and a.prod_seq = '" + LBL_PROD_SEQ.Text + "'";
			***/

			conn.QueryString = "select * from VW_DE_COLLPRODUCT " + 
				"  where AP_REGNO = '" + LBL_REGNO.Text + 
				"' AND PRODUCTID = '" + LBL_PRODUCTID.Text + 
				"' AND PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DGR_COLL2.DataSource = dt;
			try 
			{
				DGR_COLL2.DataBind();
			} 
			catch 
			{
				DGR_COLL2.CurrentPageIndex = 0;
				DGR_COLL2.DataBind();
			}


			for (int i = 0; i < DGR_COLL2.Items.Count; i++)
			{
				if (DGR_COLL2.Items[i].Cells[4].Text != "&nbsp;")
					DGR_COLL2.Items[i].Cells[4].Text = tool.MoneyFormat(DGR_COLL2.Items[i].Cells[4].Text);
				if (DGR_COLL2.Items[i].Cells[5].Text != "&nbsp;")
					DGR_COLL2.Items[i].Cells[5].Text = DGR_COLL2.Items[i].Cells[5].Text + "%";
				if (DGR_COLL2.Items[i].Cells[6].Text != "&nbsp;")
					DGR_COLL2.Items[i].Cells[6].Text = tool.MoneyFormat(DGR_COLL2.Items[i].Cells[6].Text);
				if (DGR_COLL2.Items[i].Cells[7].Text != "&nbsp;")
					DGR_COLL2.Items[i].Cells[7].Text = tool.MoneyFormat(DGR_COLL2.Items[i].Cells[7].Text);
				if (DGR_COLL2.Items[i].Cells[8].Text != "&nbsp;")
					DGR_COLL2.Items[i].Cells[8].Text = tool.MoneyFormat(DGR_COLL2.Items[i].Cells[8].Text);

				//-------- Screen Protection ----------------------
				if (Request.QueryString["de"] != "1") 
				{
					DGR_COLL2.Items[i].Cells[9].Visible = false;
					/***
					DGR_COLL2.Items[i].Cells[9].Text = "Delete";
					DGR_COLL2.Items[i].Cells[9].Enabled = false;
					***/
				}
				//--------------------------------------------------
			}
		}

		private void isiGrid1() 
		{
			DataTable dt = new DataTable();
			conn.QueryString="select a.ap_regno, a.cl_seq, a.productid,c.coltypedesc, a.lc_percentage, b.cl_value, lc_value, b.cl_desc, a.prod_seq, "+
				"action = case when a.LC_ACTION='1' then 'Add' when a.LC_ACTION='2' then 'Remove' when a.LC_ACTION='3' then 'Re-Appraise' end "+
				"from listcollateral a inner join collateral b on " +
				"a.cl_seq = b.cl_seq inner join rfcollateraltype c on b.cl_type = c.coltypeseq " +
				"inner join application d on a.ap_regno = d.ap_regno and b.cu_ref=d.cu_ref "+
				"where a.ap_regno = '" + LBL_REGNO.Text + 
				"' and a.productid='" + LBL_PRODUCTID.Text + 
				"' and a.prod_seq = '" + LBL_PROD_SEQ.Text + "' and a.lc_exchangerate is null";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DGR_COLL1.DataSource = dt;
			DGR_COLL1.DataBind();

//			for (int i = 0; i < DatGrd1.Items.Count; i++)
//			{
//				DatGrd1.Items[i].Cells[3].Text = DatGrd1.Items[i].Cells[3].Text+" %";
//				DatGrd1.Items[i].Cells[4].Text = tool.MoneyFormat(tool.ConvertFloat(DatGrd1.Items[i].Cells[4].Text));
//				DatGrd1.Items[i].Cells[5].Text = tool.MoneyFormat(tool.ConvertFloat(DatGrd1.Items[i].Cells[5].Text));
//
//				//------ Screen Protection -----------
//				if (Request.QueryString["de"] != "1") 
//				{
//					DatGrd1.Items[i].Cells[7].Text = "Delete";
//					DatGrd1.Items[i].Cells[7].Enabled = false;
//				}
//				//------------------------------------
//			}

		}

		private bool isInputValid() 
		{
			bool validkah = true;
			double ENDVALUE = 0;
			double COLLAMOUNT = 0;
			double LC_PERCENTAGE = 0;
			double COLLPLEDGE = 0; 			
			
			try { COLLAMOUNT = Convert.ToDouble(TXT_COLLAMOUNT.Text); }
			catch {}
			try { LC_PERCENTAGE = Convert.ToDouble(TXT_LC_PERCENTAGE.Text); }
			catch {}
			try { COLLPLEDGE = Convert.ToDouble(TXT_COLLPLEDGE.Text); }
			catch {}

			/// Percentage tidak boleh lebih dari 100 %
			/// 
			if (LC_PERCENTAGE > 100.00) 
			{
				GlobalTools.popMessage(this, "% of use tidak boleh lebih dari 100%!");
				validkah = false;
			}
			
			/// Pledge Amount tidak boleh lebih dari Collateral Amount
			/// 
			if (COLLPLEDGE > COLLAMOUNT) 
			{
				GlobalTools.popMessage(this, "Pledge Amount tidak boleh lebih besar dari Collateral Amount!");
				validkah = false;
			}

			return validkah;
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
			this.DGR_COLL2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_COLL2_ItemCommand);
			this.DGR_COLL2.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_COLL2_PageIndexChanged);

		}
		#endregion

		protected void calc_Click(object sender, System.EventArgs e)
		{
			/////////////////////////////////////////////////////////////////
			/// validasi Exchange Rate
			/// 
			if (TXT_COLLEXRATE.Text == "") 
			{
				GlobalTools.popMessage(this, "Exchange Rate tidak boleh kosong!");
				return;
			}
			double COLLEXRATE = Convert.ToDouble(TXT_COLLEXRATE.Text);
			/////////////////////////////////////////////////////////////////

			double ENDVALUE = 0;
			double COLLAMOUNT = 0;
			double LC_PERCENTAGE = 0;
			double COLLPLEDGE = 0; 			

			try { COLLAMOUNT = Convert.ToDouble(TXT_COLLAMOUNT.Text); }
			catch {}
			try { LC_PERCENTAGE = Convert.ToDouble(TXT_LC_PERCENTAGE.Text); }
			catch {}
			try { COLLPLEDGE = Convert.ToDouble(TXT_COLLPLEDGE.Text); }
			catch {}

			/// Validasi input
			/// 
			if (!isInputValid()) return;


			if (TXT_COLLAMOUNT.Text != "" && TXT_LC_PERCENTAGE.Text != "" &&
				COLLAMOUNT > 0 && LC_PERCENTAGE > 0) 
			{
				LC_PERCENTAGE = LC_PERCENTAGE / 100;
				ENDVALUE = COLLEXRATE * COLLAMOUNT * LC_PERCENTAGE;
			}
			else if (TXT_COLLPLEDGE.Text != "" && COLLPLEDGE > 0) 
			{
				ENDVALUE = COLLPLEDGE * COLLEXRATE;
			}

			TXT_ENDVALUE.Text = tool.MoneyFormat(ENDVALUE.ToString());
		}

		protected void insert_Click(object sender, System.EventArgs e)
		{
			if(DDL_CL_ID.SelectedValue != "")
			{
				calc_Click(sender, e);
				
				double ENDVALUE = 0;
				double COLLAMOUNT = 0;
				double LC_PERCENTAGE = 0;
				double COLLPLEDGE = 0; 			
			
				try { COLLAMOUNT = Convert.ToDouble(TXT_COLLAMOUNT.Text); }
				catch {}
				try { LC_PERCENTAGE = Convert.ToDouble(TXT_LC_PERCENTAGE.Text); }
				catch {}
				try { COLLPLEDGE = Convert.ToDouble(TXT_COLLPLEDGE.Text); }
				catch {}

				/// Validasi input
				/// 
				if (!isInputValid()) return;


				if (TXT_COLLAMOUNT.Text != "" && TXT_LC_PERCENTAGE.Text != "" &&
					COLLAMOUNT > 0 && LC_PERCENTAGE > 0) 
				{
					float persen = 0;
					try { persen = float.Parse(TXT_LC_PERCENTAGE.Text); }
					catch {}
					if ( persen>0 && (persen<100 || persen == 100))
					{
						conn.QueryString = "exec SP_LISTCOLLPROCESS2 '" + 
							LBL_REGNO.Text + "', '" + 
							LBL_CUREF.Text +"', '"+ 
							LBL_PRODUCTID.Text+"', "+ 
							tool.ConvertNum(DDL_CL_ID.SelectedValue)+", "+
							tool.ConvertFloat(TXT_LC_PERCENTAGE.Text)+", " + 
							tool.ConvertFloat(TXT_ENDVALUE.Text) + ", '1', '" + 
							LBL_PROD_SEQ.Text + "', '" +
							DDL_COLLCURRENCY.SelectedValue + "', " + 
							tool.ConvertFloat(TXT_COLLAMOUNT.Text) + ", null, " +
							//tool.ConvertFloat(TXT_COLLPLEDGE.Text) + ", " +
							tool.ConvertFloat(TXT_COLLEXRATE.Text);
						conn.ExecuteNonQuery();
					}
				}
				else if (TXT_COLLPLEDGE.Text != "" && COLLPLEDGE > 0) 
				{
					conn.QueryString = "exec SP_LISTCOLLPROCESS2 '" + 
						LBL_REGNO.Text + "', '" + 
						LBL_CUREF.Text +"', '"+ 
						LBL_PRODUCTID.Text+"', "+ 
						tool.ConvertNum(DDL_CL_ID.SelectedValue)+", null, "+
						//tool.ConvertFloat(TXT_LC_PERCENTAGE.Text)+", " + 
						tool.ConvertFloat(TXT_ENDVALUE.Text) + ", '1', '" + 
						LBL_PROD_SEQ.Text + "', '" +
						DDL_COLLCURRENCY.SelectedValue + "', null, " + 
						//tool.ConvertFloat(TXT_COLLAMOUNT.Text) + ", " +
						tool.ConvertFloat(TXT_COLLPLEDGE.Text) + ", " +
						tool.ConvertFloat(TXT_COLLEXRATE.Text);
					conn.ExecuteNonQuery();
				}
			}

			SelectColl();
			isiGrid();
			tidakisiCollateral();
			DDL_CL_ID.SelectedValue	= "";
		}

		protected void DDL_CL_ID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (DDL_CL_ID.SelectedValue == "") return;

//			Response.Write("CL_ID: " + DDL_CL_ID.SelectedValue);
//			Response.Write(" | CU_REF: " + LBL_CUREF.Text);
//			Response.Write(" | AP_REGNO: " + LBL_REGNO.Text);
//			Response.Write(" | PRODUCTID: " + LBL_PRODUCTID.Text);

			//conn.QueryString = "SELECT a.CL_VALUE, a.COLTYPEDESC, a.CL_CURRENCY, a.LC_EXCHANGERATE " + 
			//	"FROM VW_COLLATERAL1 a "+
			//	"WHERE a.cl_seq = " + DDL_CL_ID.SelectedValue + " and a.cu_ref='" + LBL_CUREF.Text + 
			//	"' and (a.CL_SEQ NOT IN (SELECT b.cl_seq FROM listcollateral b "+
			//	"WHERE a.cl_seq = b.cl_seq and b.ap_regno='" + LBL_REGNO.Text + 
			//	"' and b.productid='" + LBL_PRODUCTID.Text + "'))";
			conn.QueryString = "exec OBTAIN_EXISTING_COLLATERAL_LIST2 '" + LBL_CUREF.Text + "', '" + LBL_REGNO.Text + "', '" + LBL_PRODUCTID.Text + "', '" + Request.QueryString["ket_code"] + "', " + DDL_CL_ID.SelectedValue;
			conn.ExecuteQuery();

//			Response.Write(" | Query: " + conn.QueryString);

			int row = conn.GetRowCount();
			if (row > 0) 
			{
				//TXT_LC_VALUE.Text	= tool.MoneyFormat(conn.GetFieldValue("CL_VALUE"));

				TXT_COLLAMOUNT.Text = tool.MoneyFormat(conn.GetFieldValue("CL_VALUE"));
				TXT_CL_DESC.Text	= conn.GetFieldValue("COLTYPEDESC"); 
				try { DDL_COLLCURRENCY.SelectedValue = conn.GetFieldValue("CL_CURRENCY"); }
				catch {}
				TXT_COLLEXRATE.Text = conn.GetFieldValue("LC_EXCHANGERATE");
				isiCollateral();
			}
			else
				tidakisiCollateral();
			conn.ClearData();
		}

		private void DGR_COLL1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{			

		}

		private void DGR_COLL2_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_COLL2.CurrentPageIndex = e.NewPageIndex;
			isiGrid();
		}

		private void DGR_COLL2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "Delete":							
					///////////////////////////////////////////////////////////////////
					///	sebelum hapus cek dulu, apakah ada collateral sudah diassign
					///	kalau belum ada, boleh hapus
					///	
					conn.QueryString = "select AP_REGNO from LISTASSIGNMENT where AP_REGNO='"+ LBL_REGNO.Text + "'";
					conn.ExecuteQuery();
					if (conn.GetRowCount() == 0) 
					{
						conn.QueryString = "exec LISTCOLLATERAL_DELETE '" + 
							LBL_REGNO.Text + "', '" + 
							LBL_PRODUCTID.Text + "', '" + 
							LBL_PROD_SEQ.Text + "', '" + 
							int.Parse(e.Item.Cells[0].Text) + "'";
						conn.ExecuteNonQuery();
						break;
					}

					/***
					 * Sebelum menghapus collateral, cek dulu apakah collateral itu sudah diassign atau belum
					 * Kalau sudah diassign, collateral tersebut tidak boleh dihapus
					 * */

					//-- added by YUDI
					//TODO : CHANGE THIS QUERY INTO STORED PROCEDURE
					/// LA_APPRSTATUS :
					/// 0 : Not Assign
					/// 4 : Appraisal done
					/// 6 & 7 : Incomplete Documents
					/// 
					/*
					conn.QueryString = "select count(*) as JUMLAH from LISTASSIGNMENT where AP_REGNO='"+ LBL_REGNO.Text +
						"' and cl_seq = " + int.Parse(e.Item.Cells[0].Text)+
						"  and (LA_APPRSTATUS ('0', '4', '6', '7'))";	//-- artinya not assigned yet
					//"  and LA_APPRSTATUS <> '3'";	//-- artinya sedang diappraised
					*/
					conn.QueryString = "exec DE_COLL_COUNTAPPRAISAL '" + LBL_REGNO.Text + "', '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					//---

					if (Convert.ToInt16(conn.GetFieldValue("JUMLAH")) > 0) 
					{
						
						conn.QueryString = "exec LISTCOLLATERAL_DELETE '" + 
							LBL_REGNO.Text + "', '" + 
							LBL_PRODUCTID.Text + "', '" + 
							LBL_PROD_SEQ.Text + "', '" + 
							int.Parse(e.Item.Cells[0].Text) + "'";
						conn.ExecuteNonQuery();
					}
					else 
					{
						Tools.popMessage(this, "Collateral sedang di-appraise!");
					}
					break;
			}
			int index = DGR_COLL2.Items.Count;
			
			int jml = (index % 3)-1;
			if (jml == 0)
				DGR_COLL2.CurrentPageIndex = index/3;

			isiGrid();
			SelectColl();
			tidakisiCollateral();			
		}
	}
}
