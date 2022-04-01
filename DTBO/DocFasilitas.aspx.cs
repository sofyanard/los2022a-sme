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

namespace DTBO
{
	/// <summary>
	/// Summary description for DocFasilitas.
	/// </summary>
	public partial class DocFasilitas : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SME;uid=sa;pwd=");
		protected Tools tool = new Tools();
		//protected Connection conn = new Connection("Data Source=10.204.9.78;Initial Catalog=SME;uid=sa;pwd=;Pooling=true");
		protected Connection conn;
		int JML_DOC;
		string FIX, EXPDATE, KET, RCVDATE;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

            string sta = Request.Form["TXT_TEST"];
			if (!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_TC.Text = Request.QueryString["tc"];
				ViewKetentuan();
				try 
				{
					RBL_KETENTUAN.SelectedIndex = 0;
					ViewFasilitas(RBL_KETENTUAN.SelectedValue);

					//RBL_FASILITAS.SelectedIndex = 0;
					ViewData();
				} 
				catch {}
				/*string sql = "select distinct a.DOCID,DOCDESC from TBOLIST a join RFTBODOC b on a.DOCID = b.DOCID and ACTIVE = '1' and MANDATORY = '0' and DOCTYPEID in ('2') and TBOLIST.PRODUCTID = '"++"'";
				conn.QueryString = sql;
				conn.ExecuteQuery();
				DDL_LIST2.Items.Clear();
				for (int i = 0;i < conn.GetRowCount();i++)
				{
					DDL_LIST2.Items.Add(new ListItem (conn.GetFieldValue(i,"DOCDESC"),conn.GetFieldValue(i,"DOCID")));
				}*/
			}
			else
				if (sta == "save")
				InputDoc();
			SecureData();
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
			this.DGR_DF.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_DF_ItemCommand);

		}
		#endregion

		private void SecureData() 
		{
			if (Request.QueryString["dtbo"] == "0") 
			{
				Button1.Visible = false;
				DDL_LIST2.Enabled = false;

				for(int i=0; i<DGR_DF.Items.Count; i++) 
				{					
					CheckBox chkAvail			= (CheckBox) DGR_DF.Items[i].Cells[3].FindControl("CHB_AT_FIX");
					TextBox TXT_EXPDATE			= (TextBox) DGR_DF.Items[i].Cells[5].FindControl("TXT_AT_EXPDATEDAY");
					DropDownList DDL_EXPDATE	= (DropDownList) DGR_DF.Items[i].Cells[5].FindControl("DDL_AT_EXPDATEMONTH");
					TextBox TXT_EXTYEARDATE		= (TextBox) DGR_DF.Items[i].Cells[5].FindControl("TXT_AT_EXPDATEYEAR");
					TextBox TXT_KETERANGAN		= (TextBox) DGR_DF.Items[i].Cells[7].FindControl("TXT_AT_KETERANGAN");
					TextBox TXT_RECDATE			= (TextBox) DGR_DF.Items[i].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY");
					DropDownList DDL_RECDATE	= (DropDownList) DGR_DF.Items[i].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH");
					TextBox TXT_RECYEARDATE		= (TextBox) DGR_DF.Items[i].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR");

					chkAvail.Enabled = false;
					TXT_EXPDATE.ReadOnly = true;
					DDL_EXPDATE.Enabled = false;
					TXT_EXTYEARDATE.ReadOnly = true;
					TXT_KETERANGAN.ReadOnly = true;
					TXT_RECDATE.ReadOnly = true;
					DDL_RECDATE.Enabled = false;
					TXT_RECYEARDATE.ReadOnly = true;

					DGR_DF.Items[i].Cells[11].Text = "Delete";
					DGR_DF.Items[i].Cells[11].Enabled = false;
				}
			}
		}


		private void ViewKetentuan()
		{			
			string regno = LBL_REGNO.Text;			
			conn.QueryString = "select KET_CODE, KET_DESC, AP_REGNO, PRODUCTID from KETENTUAN_KREDIT "+
				"where AP_REGNO = '"+ regno +"'";
			conn.ExecuteQuery();
			
			int row = conn.GetRowCount();
			for (int i = 0; i < row; i++)
			{	
				RBL_KETENTUAN.Items.Add(new ListItem(conn.GetFieldValue(i, "KET_DESC"), conn.GetFieldValue(i, "KET_CODE")));
			}
		}

		private void ViewFasilitas(string KET_CODE)
		{			
			string regno = LBL_REGNO.Text;			
			conn.QueryString = "select APPTYPE, CP.PRODUCTID+APPTYPE+cast(PROD_SEQ AS VARCHAR) as PRODUCTID, " +
				"PR.PRODUCTDESC, APPTYPEDESC, CP.PRODUCTID AS PRODID, CP.PROD_SEQ "+
				"from CUSTPRODUCT CP "+
				"join RFPRODUCT PR on PR.PRODUCTID = CP.PRODUCTID "+
				"join rfapplicationtype app on app.apptypeid = apptype "+
				"where CP.AP_REGNO = '"+ regno +"' and CP.KET_CODE = '" + KET_CODE + "'"; 
			conn.ExecuteQuery();

			LBL_PRODUCT.Text = conn.GetFieldValue("PRODID");
			LBL_PRODUCTDESC.Text = conn.GetFieldValue("PRODUCTDESC");
			LBL_H_PROD_SEQ.Text = conn.GetFieldValue("PROD_SEQ");

//			RBL_FASILITAS.Items.Clear();
//			int row = conn.GetRowCount();
//			for (int i = 0; i < row; i++)
//			{	
//				RBL_FASILITAS.Items.Add(new ListItem(conn.GetFieldValue(i,2)+" - "+conn.GetFieldValue(i,3), conn.GetFieldValue(i,1)));
//			}
		}

		private void ViewData()
		{
//			conn.QueryString = "select * from VW_DTBODOCFASILITAS "+
//				"where AP_REGNO = '"+ LBL_REGNO.Text +"' and PRODUCTID = '"+ RBL_FASILITAS.SelectedValue +"'";
//			conn.QueryString = "select * from VW_DTBODOCFASILITAS "+
//				"where AP_REGNO = '"+ LBL_REGNO.Text +"' and PRODUCTID = '"+ LBL_PRODUCT.Text +"'";
			conn.QueryString = "EXEC DTBO_DOCFACILITY_DOCLIST '" + LBL_REGNO.Text + "', '" + RBL_KETENTUAN.SelectedValue + "' " ;
			conn.ExecuteQuery();

			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_DF.DataSource = data;
			DGR_DF.DataBind();
			JML_DOC = DGR_DF.Items.Count;
			string MANDATORY;
			for (int NO_DOC=0; NO_DOC<JML_DOC; NO_DOC++)
			{
				DropDownList expdate = ((DropDownList)DGR_DF.Items[NO_DOC].Cells[5].FindControl("DDL_AT_EXPDATEMONTH"));
				DropDownList rcvdate = ((DropDownList)DGR_DF.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH"));
				expdate.Items.Add(new ListItem("-Pilih-", ""));
				rcvdate.Items.Add(new ListItem("-Pilih-", ""));
				for (int i=1; i<=12; i++)
				{
					expdate.Items.Add(new ListItem(DateAndTime.MonthName(i, true), i.ToString()));
					rcvdate.Items.Add(new ListItem(DateAndTime.MonthName(i, true), i.ToString()));
				}

				FIX = DGR_DF.Items[NO_DOC].Cells[2].Text;
				EXPDATE = DGR_DF.Items[NO_DOC].Cells[4].Text;
				RCVDATE = DGR_DF.Items[NO_DOC].Cells[8].Text;
				MANDATORY = DGR_DF.Items[NO_DOC].Cells[10].Text;
				KET = DGR_DF.Items[NO_DOC].Cells[6].Text;
				if (KET == "&nbsp;")
					KET = "";

				((CheckBox)DGR_DF.Items[NO_DOC].Cells[3].FindControl("CHB_AT_FIX")).Checked = tool.ConvertCheck(FIX);
				((TextBox)DGR_DF.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEDAY")).Text = tool.FormatDate_Day(EXPDATE);
				((DropDownList)DGR_DF.Items[NO_DOC].Cells[5].FindControl("DDL_AT_EXPDATEMONTH")).SelectedValue = tool.FormatDate_Month(EXPDATE);
				((TextBox)DGR_DF.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEYEAR")).Text = tool.FormatDate_Year(EXPDATE);
				((TextBox)DGR_DF.Items[NO_DOC].Cells[7].FindControl("TXT_AT_KETERANGAN")).Text = KET;
				((TextBox)DGR_DF.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY")).Text = tool.FormatDate_Day(RCVDATE);
				((DropDownList)DGR_DF.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH")).SelectedValue = tool.FormatDate_Month(RCVDATE);
				((TextBox)DGR_DF.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR")).Text = tool.FormatDate_Year(RCVDATE);
				if (MANDATORY == "1")
				{
					((CheckBox)DGR_DF.Items[NO_DOC].Cells[3].FindControl("CHB_AT_FIX")).CssClass = "mandatory";
					((TextBox)DGR_DF.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEDAY")).CssClass = "mandatory";
					((DropDownList)DGR_DF.Items[NO_DOC].Cells[5].FindControl("DDL_AT_EXPDATEMONTH")).CssClass = "mandatory";
					((TextBox)DGR_DF.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEYEAR")).CssClass = "mandatory";
					((TextBox)DGR_DF.Items[NO_DOC].Cells[7].FindControl("TXT_AT_KETERANGAN")).CssClass = "mandatory";
					((TextBox)DGR_DF.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY")).CssClass = "mandatory";
					((DropDownList)DGR_DF.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH")).CssClass = "mandatory";
					((TextBox)DGR_DF.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR")).CssClass = "mandatory";
				}
			}
			
			//string sql = "select a.DOCID,DOCDESC from TBOLIST a join RFTBODOC b on a.DOCID = b.DOCID and ACTIVE = '1' and MANDATORY = '0' and DOCTYPEID = '2' and a.DOCID not in (select DOCID from apptbo where ap_regno = '"+LBL_REGNO.Text+"' and PRODUCTID = '"+RBL_FASILITAS.SelectedValue+"') where a.PRODUCTID = '"+RBL_FASILITAS.SelectedValue+"'";									
			//string sql = "select a.DOCID, a.DOCID + ' - ' + DOCDESC as DOCDESC from TBOLIST a join RFTBODOC b on a.DOCID = b.DOCID and ACTIVE = '1' and MANDATORY = '0' and DOCTYPEID = '2' where a.PRODUCTID = '"+ RBL_FASILITAS.SelectedValue.Substring(0,(RBL_FASILITAS.SelectedValue.Length - 3)) +"'";
			string sql = "select a.DOCID, a.DOCID + ' - ' + DOCDESC as DOCDESC from TBOLIST a join RFTBODOC b on a.DOCID = b.DOCID and ACTIVE = '1' and MANDATORY = '0' and DOCTYPEID = '2' where a.PRODUCTID = '"+ LBL_PRODUCT.Text +"'";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DDL_LIST2.Items.Clear();
			for (int i = 0;i < conn.GetRowCount();i++)
			{				
				DDL_LIST2.Items.Add(new ListItem (conn.GetFieldValue(i,"DOCDESC"),conn.GetFieldValue(i,"DOCID")));
			}
			
			SecureData();
		}

		private void InputDoc()
		{
			JML_DOC = DGR_DF.Items.Count;
			string REGNO = LBL_REGNO.Text;
			//string FAS = RBL_FASILITAS.SelectedValue;
			string FAS = LBL_PRODUCT.Text;
			for (int NO_DOC=0; NO_DOC<JML_DOC; NO_DOC++)
			{
				FIX = tool.ConvertFlag(((CheckBox)DGR_DF.Items[NO_DOC].Cells[3].FindControl("CHB_AT_FIX")).Checked);
				KET = ((TextBox)DGR_DF.Items[NO_DOC].Cells[7].FindControl("TXT_AT_KETERANGAN")).Text;
				EXPDATE = tool.ConvertDate(((TextBox)DGR_DF.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEDAY")).Text, ((DropDownList)DGR_DF.Items[NO_DOC].Cells[5].FindControl("DDL_AT_EXPDATEMONTH")).SelectedValue, ((TextBox)DGR_DF.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEYEAR")).Text);
				if (EXPDATE != "null")
				{
					if (Tools.isDateValid(this,((TextBox)DGR_DF.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEDAY")).Text,((DropDownList)DGR_DF.Items[NO_DOC].Cells[5].FindControl("DDL_AT_EXPDATEMONTH")).SelectedValue,((TextBox)DGR_DF.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEYEAR")).Text))
					{
                        string xdd, xmm, xyyyy, xdate;
                        xdd = ((TextBox)DGR_DF.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEDAY")).Text;
                        xmm = ((DropDownList)DGR_DF.Items[NO_DOC].Cells[5].FindControl("DDL_AT_EXPDATEMONTH")).SelectedValue;
                        xyyyy = ((TextBox)DGR_DF.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEYEAR")).Text;
                        //xdate = xmm + "/" + xdd + "/" + xyyyy;
                        xdate = xdd + "-" + xmm + "-" + xyyyy;

                        if ((DateTime.Now > DateAndTime.DateValue(xdate)))
						{
							Tools.popMessage(Page,"Expired date must be greater then today");
						}
						else
						{
							if (Tools.isDateValid(this,((TextBox)DGR_DF.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY")).Text,((DropDownList)DGR_DF.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH")).SelectedValue,((TextBox)DGR_DF.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR")).Text))
							{
								RCVDATE = tool.ConvertDate(((TextBox)DGR_DF.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY")).Text, ((DropDownList)DGR_DF.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH")).SelectedValue, ((TextBox)DGR_DF.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR")).Text);
								
								conn.QueryString = "exec DTBO_DOC '"+ LBL_REGNO.Text +"','"+ FAS +"', null, '"+ 
									DGR_DF.Items[NO_DOC].Cells[0].Text +"', '"+ FIX +"', "+ EXPDATE +", '"+ KET +"', "+ RCVDATE +", '2', "+DGR_DF.Items[NO_DOC].Cells[13].Text.Trim() +", " + LBL_H_PROD_SEQ.Text;
								//Response.Write(conn.QueryString +"<br>");
								conn.ExecuteNonQuery();
							}
						}
					}
				}
				else
				{
					if (Tools.isDateValid(this,((TextBox)DGR_DF.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY")).Text,((DropDownList)DGR_DF.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH")).SelectedValue,((TextBox)DGR_DF.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR")).Text))
					{
						RCVDATE = tool.ConvertDate(((TextBox)DGR_DF.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY")).Text, ((DropDownList)DGR_DF.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH")).SelectedValue, ((TextBox)DGR_DF.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR")).Text);
								
						conn.QueryString = "exec DTBO_DOC '"+ LBL_REGNO.Text +"','"+ FAS +"', null, '"+ 
							DGR_DF.Items[NO_DOC].Cells[0].Text +"', '"+ FIX +"', "+ EXPDATE +", '"+ KET +"', "+ RCVDATE +", '2', "+DGR_DF.Items[NO_DOC].Cells[13].Text.Trim() +", " + LBL_H_PROD_SEQ.Text;
						//Response.Write(conn.QueryString +"<br>");
						conn.ExecuteNonQuery();
					}
				}
			}
			ViewData();
			
		}

		private void RBL_FASILITAS_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewData();
			SecureData();
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			string sql1 = "select isnull(max(SEQ),0) + 1 seq from APPTBO where AP_REGNO = '"+LBL_REGNO.Text+"' and DOCTYPE = '2'";
			conn.QueryString = sql1;
			conn.ExecuteQuery();
			int jml = Convert.ToInt32(conn.GetFieldValue("seq"));						
		
//			string sql = "insert APPTBO(AP_REGNO,CU_REF,SEQ,PRODUCTID,DOCID,AT_RECEIVEDATE,DOCTYPE,AT_FIX,AT_FLAG) values ('"+LBL_REGNO.Text+"','"+LBL_CUREF.Text+"',"+jml.ToString()+",'"+RBL_FASILITAS.SelectedValue+"' ,'"+DDL_LIST2.SelectedValue.Trim()+"',getdate(),'2','0','1')";
//			string sql = "insert APPTBO(AP_REGNO,CU_REF,SEQ,PRODUCTID,DOCID,AT_RECEIVEDATE,DOCTYPE,AT_FIX,AT_FLAG) values ('"+LBL_REGNO.Text+"','"+LBL_CUREF.Text+"',"+jml.ToString()+",'"+ LBL_PRODUCT.Text +"' ,'"+DDL_LIST2.SelectedValue.Trim()+"',getdate(),'2','0','1')";
			string sql = "insert APPTBO(AP_REGNO,CU_REF,SEQ,PRODUCTID,DOCID,AT_RECEIVEDATE,DOCTYPE,AT_FIX,AT_FLAG,PROD_SEQ) " +
				"values ('"+LBL_REGNO.Text+"','"+LBL_CUREF.Text+"',"+jml.ToString()+",'"+ LBL_PRODUCT.Text +"' ,'"+DDL_LIST2.SelectedValue.Trim()+"',getdate(),'2','0','1'," + LBL_H_PROD_SEQ.Text + " )";
			conn.QueryString = sql;
			conn.ExecuteNonQuery();
			ViewData();
		}

		private void DGR_DF_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string docid = e.Item.Cells[0].Text.Trim();
			string seq = e.Item.Cells[13].Text.Trim();
			//string sql1 = "select MANDATORY from tbolist where DOCID = '"+docid+"' and DOCTYPEID = '2' and productid = '"+RBL_FASILITAS.SelectedValue+"'";
			//string sql1 = "select MANDATORY,AT_FLAG from tbolist a join apptbo app on a.docid = app.docid where a.DOCID = '"+docid+"' and DOCTYPE = '2' and AT_RECEIVEDATE = '"+e.Item.Cells[12].Text.Trim()+"' and app.productid = '"+RBL_FASILITAS.SelectedValue+"' and app.ap_regno = '"+LBL_REGNO.Text+"' and  app.SEQ = "+seq+"";
			string sql1 = "select MANDATORY,AT_FLAG from tbolist a join apptbo app on a.docid = app.docid where a.DOCID = '"+docid+"' and DOCTYPE = '2' and AT_RECEIVEDATE = '"+e.Item.Cells[12].Text.Trim()+"' and app.productid = '"+ LBL_PRODUCT.Text +"' and app.ap_regno = '"+LBL_REGNO.Text+"' and  app.SEQ = "+seq+"";
			conn.QueryString = sql1;
			conn.ExecuteQuery();
			if ((conn.GetFieldValue("MANDATORY") == "0") || (conn.GetFieldValue("AT_FLAG") == "1"))
			{
				//string sql = "delete apptbo where ap_regno = '"+LBL_REGNO.Text+"' and DOCID = '"+docid+"'  and productid = '"+RBL_FASILITAS.SelectedValue+"'  and AT_RECEIVEDATE = '"+e.Item.Cells[12].Text.Trim()+"' and DOCTYPE = '2' and SEQ = "+seq+"";
				string sql = "delete apptbo where ap_regno = '"+LBL_REGNO.Text+"' and DOCID = '"+docid+"'  and productid = '"+LBL_PRODUCT.Text+"'  and AT_RECEIVEDATE = '"+e.Item.Cells[12].Text.Trim()+"' and DOCTYPE = '2' and SEQ = "+seq+"";
				conn.QueryString = sql;
				conn.ExecuteNonQuery();
				ViewData();
			}
			else
			{
				
				Tools.popMessage(Page,"This item is mandatory");	
			}
		}

		protected void RBL_KETENTUAN_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string id = RBL_KETENTUAN.SelectedValue;
			ViewFasilitas(id);
			ViewData();
//			RBL_FASILITAS.SelectedIndex = 0;
		}
	}
}
