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
	/// Summary description for DocJaminan.
	/// </summary>
	public partial class DocJaminan : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Tools tool = new Tools();
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SME;uid=sa;pwd=;Pooling=true");
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
				ViewJaminan();
				updatelistcolateral();

				/*string sql = "select distinct a.DOCID,DOCDESC from TBOLIST a join RFTBODOC b on a.DOCID = b.DOCID and ACTIVE = '1' and MANDATORY = '0' and DOCTYPEID in ('1')";
				conn.QueryString = sql;
				conn.ExecuteQuery();
				DDL_LIST2.Items.Clear();
				for (int i = 0;i < conn.GetRowCount();i++)
				{
					DDL_LIST2.Items.Add(new ListItem (conn.GetFieldValue(i,"DOCDESC"),conn.GetFieldValue(i,"DOCID")));
				}*/
			}
			else if (sta == "save")
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
			this.DGR_DJ.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_DJ_ItemCommand);

		}
		#endregion
		
		private void SecureData() 
		{
			if (Request.QueryString["dtbo"] == "0") 
			{
				Button1.Visible = false;
				DDL_LIST2.Enabled = false;

				for(int i=0; i<DGR_DJ.Items.Count; i++) 
				{					
					CheckBox chkAvail			= (CheckBox) DGR_DJ.Items[i].Cells[3].FindControl("CHB_AT_FIX");
					TextBox TXT_EXPDATE			= (TextBox) DGR_DJ.Items[i].Cells[5].FindControl("TXT_AT_EXPDATEDAY");
					DropDownList DDL_EXPDATE	= (DropDownList) DGR_DJ.Items[i].Cells[5].FindControl("DDL_AT_EXPDATEMONTH");
					TextBox TXT_EXTYEARDATE		= (TextBox) DGR_DJ.Items[i].Cells[5].FindControl("TXT_AT_EXPDATEYEAR");
					TextBox TXT_KETERANGAN		= (TextBox) DGR_DJ.Items[i].Cells[7].FindControl("TXT_AT_KETERANGAN");
					TextBox TXT_RECDATE			= (TextBox) DGR_DJ.Items[i].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY");
					DropDownList DDL_RECDATE	= (DropDownList) DGR_DJ.Items[i].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH");
					TextBox TXT_RECYEARDATE		= (TextBox) DGR_DJ.Items[i].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR");

					chkAvail.Enabled = false;
					TXT_EXPDATE.ReadOnly = true;
					DDL_EXPDATE.Enabled = false;
					TXT_EXTYEARDATE.ReadOnly = true;
					TXT_KETERANGAN.ReadOnly = true;
					TXT_RECDATE.ReadOnly = true;
					DDL_RECDATE.Enabled = false;
					TXT_RECYEARDATE.ReadOnly = true;

					DGR_DJ.Items[i].Cells[11].Text = "Delete";
					DGR_DJ.Items[i].Cells[11].Enabled = false;
				}
			}
		}

		private void ViewJaminan()
		{
			string curef = LBL_CUREF.Text;
			string apregno = LBL_REGNO.Text;
			conn.QueryString = "select distinct CL.CL_SEQ, CL.CL_TYPE, CT.COLTYPEID, CT.COLTYPEDESC, CL.CL_DESC "+
				"from LISTCOLLATERAL LC " +
				"join COLLATERAL CL on LC.CL_SEQ = CL.CL_SEQ AND LC.CU_REF = CL.CU_REF " +
				"join RFCOLLATERALTYPE CT on CL.CL_TYPE = CT.COLTYPESEQ " +
				"where LC.AP_REGNO = '"+ apregno +"'";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			for (int i = 0; i < row; i++)
			{	
				DDL_JAMINAN.Items.Add(new ListItem(conn.GetFieldValue(i, 2) +" - "+ conn.GetFieldValue(i,4) + " (" + conn.GetFieldValue(i, 3) + ")", conn.GetFieldValue(i, 0)+ "|"+ conn.GetFieldValue(i, 1)));
			}			
		}

		private void ViewData()
		{
			string ARR_DDL_JAMINAN, CL_SEQ, CL_TYPE = "",ARR_ITEM_JAMINAN = "",CL_TYPEID = "";
			int NO_CHAR, PJG_TYPE, PJG_DDL_JAMINAN;
			ARR_DDL_JAMINAN = DDL_JAMINAN.SelectedValue;			
			CL_SEQ = "0";
			if (ARR_DDL_JAMINAN != "")
			{
				ARR_ITEM_JAMINAN = DDL_JAMINAN.SelectedItem.Text;
				PJG_DDL_JAMINAN = ARR_DDL_JAMINAN.Length;
				NO_CHAR = ARR_DDL_JAMINAN.IndexOf("|", 1, PJG_DDL_JAMINAN-1) + 1;				
				PJG_TYPE = PJG_DDL_JAMINAN - NO_CHAR;
				CL_SEQ = ARR_DDL_JAMINAN.Substring(0, NO_CHAR-1);
				CL_TYPE = ARR_DDL_JAMINAN.Substring(NO_CHAR, PJG_TYPE);
				CL_TYPE = CL_TYPE + CL_SEQ;				

				PJG_DDL_JAMINAN = ARR_ITEM_JAMINAN.Length;
				NO_CHAR = ARR_ITEM_JAMINAN.IndexOf("-", 1, PJG_DDL_JAMINAN-1) + 1;								
				CL_TYPEID = ARR_ITEM_JAMINAN.Substring(0, NO_CHAR-1);

			}

			conn.QueryString = "select * from VW_DTBODOCJAMINAN "+
				"where DOCTYPE = '3' and AP_REGNO = '"+ LBL_REGNO.Text +"' "+
				"and CLTYPESEQ = '"+CL_TYPE+"' order by SEQ" ;
			conn.ExecuteQuery();
			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_DJ.DataSource = data;
			DGR_DJ.DataBind();
			JML_DOC = DGR_DJ.Items.Count;
			string MANDATORY;
			for (int NO_DOC=0; NO_DOC<JML_DOC; NO_DOC++)
			{
				DropDownList expdate = ((DropDownList)DGR_DJ.Items[NO_DOC].Cells[5].FindControl("DDL_AT_EXPDATEMONTH"));
				DropDownList rcvdate = ((DropDownList)DGR_DJ.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH"));
				expdate.Items.Add(new ListItem("-Pilih-", ""));
				rcvdate.Items.Add(new ListItem("-Pilih-", ""));
				for (int i=1; i<=12; i++)
				{
					expdate.Items.Add(new ListItem(DateAndTime.MonthName(i, true), i.ToString()));
					rcvdate.Items.Add(new ListItem(DateAndTime.MonthName(i, true), i.ToString()));
				}

				FIX = DGR_DJ.Items[NO_DOC].Cells[2].Text;
				EXPDATE = DGR_DJ.Items[NO_DOC].Cells[4].Text;
				RCVDATE = DGR_DJ.Items[NO_DOC].Cells[8].Text;
				MANDATORY = DGR_DJ.Items[NO_DOC].Cells[10].Text;
				KET = DGR_DJ.Items[NO_DOC].Cells[6].Text;
				if (KET == "&nbsp;")
					KET = "";

				((CheckBox)DGR_DJ.Items[NO_DOC].Cells[3].FindControl("CHB_AT_FIX")).Checked = tool.ConvertCheck(FIX);
				((TextBox)DGR_DJ.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEDAY")).Text = tool.FormatDate_Day(EXPDATE);
				((DropDownList)DGR_DJ.Items[NO_DOC].Cells[5].FindControl("DDL_AT_EXPDATEMONTH")).SelectedValue = tool.FormatDate_Month(EXPDATE);
				((TextBox)DGR_DJ.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEYEAR")).Text = tool.FormatDate_Year(EXPDATE);
				((TextBox)DGR_DJ.Items[NO_DOC].Cells[7].FindControl("TXT_AT_KETERANGAN")).Text = KET;
				((TextBox)DGR_DJ.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY")).Text = tool.FormatDate_Day(RCVDATE);
				((DropDownList)DGR_DJ.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH")).SelectedValue = tool.FormatDate_Month(RCVDATE);
				((TextBox)DGR_DJ.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR")).Text = tool.FormatDate_Year(RCVDATE);
				if (MANDATORY == "1")
				{
					((CheckBox)DGR_DJ.Items[NO_DOC].Cells[3].FindControl("CHB_AT_FIX")).CssClass = "mandatory";
					((TextBox)DGR_DJ.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEDAY")).CssClass = "mandatory";
					((DropDownList)DGR_DJ.Items[NO_DOC].Cells[5].FindControl("DDL_AT_EXPDATEMONTH")).CssClass = "mandatory";
					((TextBox)DGR_DJ.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEYEAR")).CssClass = "mandatory";
					((TextBox)DGR_DJ.Items[NO_DOC].Cells[7].FindControl("TXT_AT_KETERANGAN")).CssClass = "mandatory";
					((TextBox)DGR_DJ.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY")).CssClass = "mandatory";
					((DropDownList)DGR_DJ.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH")).CssClass = "mandatory";
					((TextBox)DGR_DJ.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR")).CssClass = "mandatory";
				}
			}
			/*
			string sql = "select distinct a.DOCID,DOCDESC from TBOLIST a join RFTBODOC b on a.DOCID = b.DOCID and ACTIVE = '1' and MANDATORY = '0' and DOCTYPEID = '3' join rfcollateraltype c on a.coltypeid = c.coltypeid and c.coltypeid = '"+CL_TYPEID+"'";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DDL_LIST2.Items.Clear();
			for (int i = 0;i < conn.GetRowCount();i++)
			{				
				DDL_LIST2.Items.Add(new ListItem (conn.GetFieldValue(i,"DOCDESC"),conn.GetFieldValue(i,"DOCID")));
			}
			*/

			SecureData();
		}

		private void InputDoc()
		{
			string ARR_DDL_JAMINAN, CL_SEQ, CL_TYPE="";
			int NO_CHAR, PJG_TYPE, PJG_DDL_JAMINAN;
			ARR_DDL_JAMINAN = DDL_JAMINAN.SelectedValue;
			CL_SEQ = "0";
			if (ARR_DDL_JAMINAN != "")
			{
				PJG_DDL_JAMINAN = ARR_DDL_JAMINAN.Length;
				NO_CHAR = ARR_DDL_JAMINAN.IndexOf("|", 1, PJG_DDL_JAMINAN-1) + 1;
				PJG_TYPE = PJG_DDL_JAMINAN - NO_CHAR;
				CL_SEQ = ARR_DDL_JAMINAN.Substring(0, NO_CHAR-1);
				CL_TYPE = ARR_DDL_JAMINAN.Substring(NO_CHAR, PJG_TYPE);				
				CL_TYPE = CL_TYPE + CL_SEQ;
			}

			if (CL_SEQ != "0")
			{
				JML_DOC = DGR_DJ.Items.Count;
				string REGNO = LBL_REGNO.Text;
				for (int NO_DOC=0; NO_DOC<JML_DOC; NO_DOC++)
				{
					FIX = tool.ConvertFlag(((CheckBox)DGR_DJ.Items[NO_DOC].Cells[3].FindControl("CHB_AT_FIX")).Checked);
					KET = ((TextBox)DGR_DJ.Items[NO_DOC].Cells[7].FindControl("TXT_AT_KETERANGAN")).Text;
					EXPDATE = tool.ConvertDate(((TextBox)DGR_DJ.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEDAY")).Text, ((DropDownList)DGR_DJ.Items[NO_DOC].Cells[5].FindControl("DDL_AT_EXPDATEMONTH")).SelectedValue, ((TextBox)DGR_DJ.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEYEAR")).Text);
					if (EXPDATE != "null")
					{
						if (Tools.isDateValid(this,((TextBox)DGR_DJ.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEDAY")).Text,((DropDownList)DGR_DJ.Items[NO_DOC].Cells[5].FindControl("DDL_AT_EXPDATEMONTH")).SelectedValue,((TextBox)DGR_DJ.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEYEAR")).Text))
						{
                            string xdd, xmm, xyyyy, xdate;
                            xdd = ((TextBox)DGR_DJ.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEDAY")).Text;
                            xmm = ((DropDownList)DGR_DJ.Items[NO_DOC].Cells[5].FindControl("DDL_AT_EXPDATEMONTH")).SelectedValue;
                            xyyyy = ((TextBox)DGR_DJ.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEYEAR")).Text;
                            //xdate = xmm + "/" + xdd + "/" + xyyyy;
                            xdate = xdd + "-" + xmm + "-" + xyyyy;

                            if ((DateTime.Now > DateAndTime.DateValue(xdate)))
							{
								Tools.popMessage(Page,"Expired date must be greater then today");
							}
							else
							{
								if (Tools.isDateValid(this,((TextBox)DGR_DJ.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY")).Text,((DropDownList)DGR_DJ.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH")).SelectedValue,((TextBox)DGR_DJ.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR")).Text))
								{
									RCVDATE = tool.ConvertDate(((TextBox)DGR_DJ.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY")).Text, ((DropDownList)DGR_DJ.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH")).SelectedValue, ((TextBox)DGR_DJ.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR")).Text);
									
									conn.QueryString = "exec DTBO_DOC '"+ LBL_REGNO.Text +"', null, "+ Convert.ToInt16(CL_TYPE) +", '"+ 
										DGR_DJ.Items[NO_DOC].Cells[0].Text +"', '"+ FIX +"', "+ EXPDATE +", '"+ KET +"', "+ RCVDATE +", '3',"+ 
										DGR_DJ.Items[NO_DOC].Cells[13].Text +"  ";
									//Response.Write(conn.QueryString +"<br>");
									conn.ExecuteNonQuery();
								}
							}
						}
					}
					else
					{
						if (Tools.isDateValid(this,((TextBox)DGR_DJ.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY")).Text,((DropDownList)DGR_DJ.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH")).SelectedValue,((TextBox)DGR_DJ.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR")).Text))
						{
							RCVDATE = tool.ConvertDate(((TextBox)DGR_DJ.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY")).Text, ((DropDownList)DGR_DJ.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH")).SelectedValue, ((TextBox)DGR_DJ.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR")).Text);
									
							conn.QueryString = "exec DTBO_DOC '"+ LBL_REGNO.Text +"', null, "+ Convert.ToInt16(CL_TYPE) +", '"+ 
								DGR_DJ.Items[NO_DOC].Cells[0].Text +"', '"+ FIX +"', "+ EXPDATE +", '"+ KET +"', "+ RCVDATE +", '3' ,"+ 
								DGR_DJ.Items[NO_DOC].Cells[13].Text +" ";
							//Response.Write(conn.QueryString +"<br>");
							conn.ExecuteNonQuery();
						}
					}
				}
				ViewData();
			}
			
		}

		protected void DDL_JAMINAN_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewData();			
			updatelistcolateral();
		}

		private void updatelistcolateral()
		{
			string ARR_DDL_JAMINAN, CL_SEQ, CL_TYPE = "",ARR_ITEM_JAMINAN = "",CL_TYPEID = "";
			int NO_CHAR, PJG_TYPE, PJG_DDL_JAMINAN;
			ARR_DDL_JAMINAN = DDL_JAMINAN.SelectedValue;			
			CL_SEQ = "0";
			if (ARR_DDL_JAMINAN != "")
			{
				ARR_ITEM_JAMINAN = DDL_JAMINAN.SelectedItem.Text;
				PJG_DDL_JAMINAN = ARR_DDL_JAMINAN.Length;
				NO_CHAR = ARR_DDL_JAMINAN.IndexOf("|", 1, PJG_DDL_JAMINAN-1) + 1;				
				PJG_TYPE = PJG_DDL_JAMINAN - NO_CHAR;
				CL_SEQ = ARR_DDL_JAMINAN.Substring(0, NO_CHAR-1);
				CL_TYPE = ARR_DDL_JAMINAN.Substring(NO_CHAR, PJG_TYPE);
				CL_TYPE = CL_TYPE + CL_SEQ;				

				PJG_DDL_JAMINAN = ARR_ITEM_JAMINAN.Length;
				NO_CHAR = ARR_ITEM_JAMINAN.IndexOf("-", 1, PJG_DDL_JAMINAN-1) + 1;								
				CL_TYPEID = ARR_ITEM_JAMINAN.Substring(0, NO_CHAR-1);

			}
			string sql = "select distinct a.DOCID, a.DOCID + ' - ' + DOCDESC as DOCDESC from TBOLIST a join RFTBODOC b on a.DOCID = b.DOCID and ACTIVE = '1' and MANDATORY = '0' and DOCTYPEID = '3' join rfcollateraltype c on a.coltypeid = c.coltypeid and c.coltypeid = '"+CL_TYPEID+"'";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DDL_LIST2.Items.Clear();
			for (int i = 0;i < conn.GetRowCount();i++)
			{				
				DDL_LIST2.Items.Add(new ListItem (conn.GetFieldValue(i,"DOCDESC"),conn.GetFieldValue(i,"DOCID")));
			}
		}

		protected void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void DDL_JAMINAN_Load(object sender, System.EventArgs e)
		{
			ViewData();
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			string ARR_DDL_JAMINAN, CL_SEQ, CL_TYPE = "";
			int NO_CHAR, PJG_TYPE, PJG_DDL_JAMINAN;
			ARR_DDL_JAMINAN = DDL_JAMINAN.SelectedValue;
			CL_SEQ = "0";
			if (ARR_DDL_JAMINAN != "")
			{
				PJG_DDL_JAMINAN = ARR_DDL_JAMINAN.Length;
				NO_CHAR = ARR_DDL_JAMINAN.IndexOf("|", 1, PJG_DDL_JAMINAN-1) + 1;
				PJG_TYPE = PJG_DDL_JAMINAN - NO_CHAR;
				CL_SEQ = ARR_DDL_JAMINAN.Substring(0, NO_CHAR-1);
				CL_TYPE = ARR_DDL_JAMINAN.Substring(NO_CHAR, PJG_TYPE);
				CL_TYPE = CL_TYPE + CL_SEQ;
			}
			string sql1 = "select isnull(max(SEQ),0) + 1 seq from APPTBO where AP_REGNO = '"+LBL_REGNO.Text+"' and DOCTYPE = '3'";
			conn.QueryString = sql1;
			conn.ExecuteQuery();
			int jml = Convert.ToInt32(conn.GetFieldValue("seq"));						

			string sql = "insert APPTBO(AP_REGNO,CU_REF,SEQ,CLTYPESEQ,DOCID,AT_RECEIVEDATE,DOCTYPE,AT_FIX,AT_FLAG) values ('"+LBL_REGNO.Text+"','"+LBL_CUREF.Text+"',"+jml.ToString()+",'"+CL_TYPE+"' ,'"+DDL_LIST2.SelectedValue.Trim()+"',getdate(),'3','0','1')";
			conn.QueryString = sql;
			conn.ExecuteNonQuery();
			ViewData();
		}

		private void DGR_DJ_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ARR_DDL_JAMINAN, CL_SEQ, CL_TYPE = "";
			int NO_CHAR, PJG_TYPE, PJG_DDL_JAMINAN;
			ARR_DDL_JAMINAN = DDL_JAMINAN.SelectedValue;
			CL_SEQ = "0";
			if (ARR_DDL_JAMINAN != "")
			{
				PJG_DDL_JAMINAN = ARR_DDL_JAMINAN.Length;
				NO_CHAR = ARR_DDL_JAMINAN.IndexOf("|", 1, PJG_DDL_JAMINAN-1) + 1;
				PJG_TYPE = PJG_DDL_JAMINAN - NO_CHAR;
				CL_SEQ = ARR_DDL_JAMINAN.Substring(0, NO_CHAR-1);
				CL_TYPE = ARR_DDL_JAMINAN.Substring(NO_CHAR, PJG_TYPE);				
				CL_TYPE = CL_TYPE + CL_SEQ;
			}
			string docid = e.Item.Cells[0].Text.Trim();
            //2017-10-12
            /*
			string sql1 = "select MANDATORY,AT_FLAG from tbolist a join apptbo app on a.docid = app.docid where a.DOCID = '"+docid+"' and DOCTYPE = '3' and CLTYPESEQ = '"+CL_TYPE+"' and AT_RECEIVEDATE = '"+e.Item.Cells[12].Text.Trim()+"' and app.ap_regno = '"+LBL_REGNO.Text+"' and app.seq = "+e.Item.Cells[13].Text.Trim()+"";
			//string sql1 = "select MANDATORY,AT_FLAG from tbolist a join apptbo app on a.docid = app.docid where a.DOCID = '"+docid+"' and DOCTYPE = '2' and AT_RECEIVEDATE = '"+e.Item.Cells[12].Text.Trim()+"' and app.productid = '"+RBL_FASILITAS.SelectedValue+"'";
			conn.QueryString = sql1;
			conn.ExecuteQuery();
			if (conn.GetFieldValue("MANDATORY") == "0")
			{
            */
				string sql = "delete apptbo where ap_regno = '"+LBL_REGNO.Text+"' and DOCID = '"+docid+"'  and cltypeseq = '"+CL_TYPE+"' and AT_RECEIVEDATE = '"+e.Item.Cells[12].Text.Trim()+"' and DOCTYPE = '3' and seq = "+e.Item.Cells[13].Text.Trim()+"";
				conn.QueryString = sql;
				conn.ExecuteNonQuery();
				ViewData();
            //2017-10-12
            /*
			}
			else
			{
				
				Tools.popMessage(Page,"This item is mandatory");	
			}
            */
		}
	}
}
