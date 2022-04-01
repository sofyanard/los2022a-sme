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

namespace SME.CBI
{
	/// <summary>
	/// Summary description for DocUmum.
	/// </summary>
	public partial class DocUmum : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SME;uid=sa;pwd=;Pooling=true");
		//protected Connection conn = new Connection("Data Source=localhost;Initial Catalog=SME;uid=sa;pwd=");
		protected Connection conn;
		int JML_DOC;
		string FIX, EXPDATE, KET, RCVDATE;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			string sta = Request.Form["sta"];
			if (!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_TC.Text = Request.QueryString["tc"];
				
				ViewData();				
				conn.QueryString = "select CU_JNSNASABAH from customer where cu_ref = '"+LBL_CUREF.Text+"'";
				conn.ExecuteQuery();
				string jnsnasabah = conn.GetFieldValue("CU_JNSNASABAH");
				if (jnsnasabah == "A")
				{
					string sql;
					if (Request.QueryString["dtbo"] == "0") sql = "select distinct a.DOCID,DOCDESC from TBOLIST a join RFTBODOC b on a.DOCID = b.DOCID and DOCTYPEID ='1' and (JNSNASABAH = 'A' or JNSNASABAH is null)";
					else sql = "select distinct a.DOCID,DOCDESC from TBOLIST a join RFTBODOC b on a.DOCID = b.DOCID and ACTIVE = '1' and DOCTYPEID ='1' and (JNSNASABAH = 'A' or JNSNASABAH is null)";
					conn.QueryString = sql;
					conn.ExecuteQuery();
				}
				else
				{
					string sql;
					if (Request.QueryString["dtbo"] == "0") sql = "select distinct a.DOCID, a.DOCID + ' - ' + DOCDESC as DOCDESC from TBOLIST a join RFTBODOC b on a.DOCID = b.DOCID and DOCTYPEID ='1' and (JNSNASABAH = 'B' or JNSNASABAH is null)";
					else sql = "select distinct a.DOCID, a.DOCID + ' - ' + DOCDESC as DOCDESC from TBOLIST a join RFTBODOC b on a.DOCID = b.DOCID and ACTIVE = '1' and DOCTYPEID ='1' and (JNSNASABAH = 'B' or JNSNASABAH is null)";
					conn.QueryString = sql;
					conn.ExecuteQuery();
				}
					DDL_NEWITEM.Items.Clear();
				
				for (int i = 0;i < conn.GetRowCount();i++)
				{
					DDL_NEWITEM.Items.Add(new ListItem (conn.GetFieldValue(i,"DOCDESC"),conn.GetFieldValue(i,"DOCID")));
				}

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
			this.DGR_DU.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_DU_ItemCommand);

		}
		#endregion

		private void SecureData() 
		{
			if (Request.QueryString["dtbo"] == "0")
			{
				Button1.Visible = false;
				DDL_NEWITEM.Enabled = false;

				for(int i=0; i<DGR_DU.Items.Count; i++) 
				{
					CheckBox chkAvail			= (CheckBox) DGR_DU.Items[i].Cells[3].FindControl("CHB_AT_FIX");
					TextBox TXT_EXPDATE			= (TextBox) DGR_DU.Items[i].Cells[5].FindControl("TXT_AT_EXPDATEDAY");
					DropDownList DDL_EXPDATE	= (DropDownList) DGR_DU.Items[i].Cells[5].FindControl("DDL_AT_EXPDATEMONTH");
					TextBox TXT_EXTYEARDATE		= (TextBox) DGR_DU.Items[i].Cells[5].FindControl("TXT_AT_EXPDATEYEAR");
					TextBox TXT_KETERANGAN		= (TextBox) DGR_DU.Items[i].Cells[7].FindControl("TXT_AT_KETERANGAN");
					TextBox TXT_RECDATE			= (TextBox) DGR_DU.Items[i].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY");
					DropDownList DDL_RECDATE	= (DropDownList) DGR_DU.Items[i].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH");
					TextBox TXT_RECYEARDATE		= (TextBox) DGR_DU.Items[i].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR");

					chkAvail.Enabled = false;
					TXT_EXPDATE.ReadOnly = true;
					DDL_EXPDATE.Enabled = false;
					TXT_EXTYEARDATE.ReadOnly = true;
					TXT_KETERANGAN.ReadOnly = true;
					TXT_RECDATE.ReadOnly = true;
					DDL_RECDATE.Enabled = false;
					TXT_RECYEARDATE.ReadOnly = true;

					DGR_DU.Items[i].Cells[11].Text = "Delete";
					DGR_DU.Items[i].Cells[11].Enabled = false;
				}
			}
		}

		private void ViewData()
		{
			conn.QueryString = "select CU_JNSNASABAH from customer where cu_ref = '"+LBL_CUREF.Text+"'";
			conn.ExecuteQuery();
			string jnsnasabah = conn.GetFieldValue("CU_JNSNASABAH");
			if (jnsnasabah == "A")
			{
				conn.QueryString = "select * from VW_DTBODOCUMUM "+
					"where ap_regno = '"+ LBL_REGNO.Text +"' order by SEQ";				
			}
			else
			{
				conn.QueryString = "select * from VW_DTBODOCUMUM2 "+
					"where ap_regno = '"+ LBL_REGNO.Text +"' order by SEQ";				
			}			
			conn.ExecuteQuery();				
			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_DU.DataSource = data;
			DGR_DU.DataBind();
			JML_DOC = DGR_DU.Items.Count;
			string MANDATORY;
			for (int NO_DOC=0; NO_DOC<JML_DOC; NO_DOC++)
			{
				DropDownList expdate = ((DropDownList)DGR_DU.Items[NO_DOC].Cells[5].FindControl("DDL_AT_EXPDATEMONTH"));
				DropDownList rcvdate = ((DropDownList)DGR_DU.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH"));
				expdate.Items.Add(new ListItem("-Pilih-", ""));
				rcvdate.Items.Add(new ListItem("-Pilih-", ""));
				for (int i=1; i<=12; i++)
				{
					expdate.Items.Add(new ListItem(DateAndTime.MonthName(i, true), i.ToString()));
					rcvdate.Items.Add(new ListItem(DateAndTime.MonthName(i, true), i.ToString()));
				}

				FIX = DGR_DU.Items[NO_DOC].Cells[2].Text;
				EXPDATE = DGR_DU.Items[NO_DOC].Cells[4].Text;
				RCVDATE = DGR_DU.Items[NO_DOC].Cells[8].Text;
				MANDATORY = DGR_DU.Items[NO_DOC].Cells[10].Text;
				KET = DGR_DU.Items[NO_DOC].Cells[6].Text;
				if (KET == "&nbsp;")
					KET = "";

				((CheckBox)DGR_DU.Items[NO_DOC].Cells[3].FindControl("CHB_AT_FIX")).Checked = tool.ConvertCheck(FIX);
				((TextBox)DGR_DU.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEDAY")).Text = tool.FormatDate_Day(EXPDATE);
				((DropDownList)DGR_DU.Items[NO_DOC].Cells[5].FindControl("DDL_AT_EXPDATEMONTH")).SelectedValue = tool.FormatDate_Month(EXPDATE);
				((TextBox)DGR_DU.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEYEAR")).Text = tool.FormatDate_Year(EXPDATE);
				((TextBox)DGR_DU.Items[NO_DOC].Cells[7].FindControl("TXT_AT_KETERANGAN")).Text = KET;
				((TextBox)DGR_DU.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY")).Text = tool.FormatDate_Day(RCVDATE);
				((DropDownList)DGR_DU.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH")).SelectedValue = tool.FormatDate_Month(RCVDATE);
				((TextBox)DGR_DU.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR")).Text = tool.FormatDate_Year(RCVDATE);
				if (MANDATORY == "1")
				{
					((CheckBox)DGR_DU.Items[NO_DOC].Cells[3].FindControl("CHB_AT_FIX")).CssClass = "mandatory";
					((TextBox)DGR_DU.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEDAY")).CssClass = "mandatory";
					((DropDownList)DGR_DU.Items[NO_DOC].Cells[5].FindControl("DDL_AT_EXPDATEMONTH")).CssClass = "mandatory";
					((TextBox)DGR_DU.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEYEAR")).CssClass = "mandatory";
					((TextBox)DGR_DU.Items[NO_DOC].Cells[7].FindControl("TXT_AT_KETERANGAN")).CssClass = "mandatory";
					((TextBox)DGR_DU.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY")).CssClass = "mandatory";
					((DropDownList)DGR_DU.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH")).CssClass = "mandatory";
					((TextBox)DGR_DU.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR")).CssClass = "mandatory";
				}
			}				
			/*if (jnsnasabah == "A")
			{
				string sql = "select a.DOCID,DOCDESC from TBOLIST a join RFTBODOC b on a.DOCID = b.DOCID and ACTIVE = '1' and MANDATORY = '0' and DOCTYPEID = '1' and a.DOCID not in (select DOCID from apptbo where ap_regno = '"+LBL_REGNO.Text+"') where JNSNASABAH = 'A'";
				conn.QueryString = sql;
				conn.ExecuteQuery();
				DDL_NEWITEM.Items.Clear();
				for (int i = 0;i < conn.GetRowCount();i++)
				{
					DDL_NEWITEM.Items.Add(new ListItem (conn.GetFieldValue(i,"DOCDESC"),conn.GetFieldValue(i,"DOCID")));
				}
			}
			else
			{
				string sql = "select a.DOCID,DOCDESC from TBOLIST a join RFTBODOC b on a.DOCID = b.DOCID and ACTIVE = '1' and MANDATORY = '0' and DOCTYPEID = '1' and a.DOCID not in (select DOCID from apptbo where ap_regno = '"+LBL_REGNO.Text+"') where JNSNASABAH = 'B'";
				conn.QueryString = sql;
				conn.ExecuteQuery();
				DDL_NEWITEM.Items.Clear();
				for (int i = 0;i < conn.GetRowCount();i++)
				{
					DDL_NEWITEM.Items.Add(new ListItem (conn.GetFieldValue(i,"DOCDESC"),conn.GetFieldValue(i,"DOCID")));
				}
			}*/

			SecureData();
		}

		private void InputDoc()
		{
			JML_DOC = DGR_DU.Items.Count;
			string REGNO = LBL_REGNO.Text;
			string CUREF = LBL_CUREF.Text;

			for (int NO_DOC=0; NO_DOC<JML_DOC; NO_DOC++)
			{								
				FIX = tool.ConvertFlag(((CheckBox)DGR_DU.Items[NO_DOC].Cells[3].FindControl("CHB_AT_FIX")).Checked);
				KET = ((TextBox)DGR_DU.Items[NO_DOC].Cells[7].FindControl("TXT_AT_KETERANGAN")).Text;
				EXPDATE = tool.ConvertDate(((TextBox)DGR_DU.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEDAY")).Text, ((DropDownList)DGR_DU.Items[NO_DOC].Cells[5].FindControl("DDL_AT_EXPDATEMONTH")).SelectedValue, ((TextBox)DGR_DU.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEYEAR")).Text);								
				if (EXPDATE != "null")
				{
					if (Tools.isDateValid(this,((TextBox)DGR_DU.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEDAY")).Text,((DropDownList)DGR_DU.Items[NO_DOC].Cells[5].FindControl("DDL_AT_EXPDATEMONTH")).SelectedValue,((TextBox)DGR_DU.Items[NO_DOC].Cells[5].FindControl("TXT_AT_EXPDATEYEAR")).Text))
					{
						if ((DateTime.Now > DateAndTime.DateValue(EXPDATE)))
						{
							Tools.popMessage(Page,"Expired date must be greater then today");
						}
						else
						{
							if (Tools.isDateValid(this,((TextBox)DGR_DU.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY")).Text,((DropDownList)DGR_DU.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH")).SelectedValue,((TextBox)DGR_DU.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR")).Text))
							{
								RCVDATE = tool.ConvertDate(((TextBox)DGR_DU.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY")).Text, ((DropDownList)DGR_DU.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH")).SelectedValue, ((TextBox)DGR_DU.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR")).Text);
								conn.QueryString = "exec DTBO_DOC '"+ REGNO +"', null, null, '"+ 
									DGR_DU.Items[NO_DOC].Cells[0].Text +"', '"+ FIX +"', "+ EXPDATE +", '"+ KET +"', "+ RCVDATE +", '1' ,"+ 
									DGR_DU.Items[NO_DOC].Cells[13].Text +"";
								//Response.Write(conn.QueryString +"<br>");
								conn.ExecuteNonQuery();
							}
						}
					}
				}
				else
				{
					if (Tools.isDateValid(this,((TextBox)DGR_DU.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY")).Text,((DropDownList)DGR_DU.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH")).SelectedValue,((TextBox)DGR_DU.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR")).Text))
					{
						RCVDATE = tool.ConvertDate(((TextBox)DGR_DU.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEDAY")).Text, ((DropDownList)DGR_DU.Items[NO_DOC].Cells[9].FindControl("DDL_AT_RECEIVEDATEMONTH")).SelectedValue, ((TextBox)DGR_DU.Items[NO_DOC].Cells[9].FindControl("TXT_AT_RECEIVEDATEYEAR")).Text);
						conn.QueryString = "exec DTBO_DOC '"+ REGNO +"', null, null, '"+ 
							DGR_DU.Items[NO_DOC].Cells[0].Text +"', '"+ FIX +"', "+ EXPDATE +", '"+ KET +"', "+ RCVDATE +", '1', "+ 
							DGR_DU.Items[NO_DOC].Cells[13].Text +" ";
						//Response.Write(conn.QueryString +"<br>");
						conn.ExecuteNonQuery();
					}
				}								
			}
			ViewData();			
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			string sql1 = "select isnull(max(seq),0) + 1 seq from APPTBO where CU_REF = '"+LBL_CUREF.Text+"' and DOCTYPE = '1'";
			conn.QueryString = sql1;
			conn.ExecuteQuery();
			int jml = Convert.ToInt32(conn.GetFieldValue("seq"));						
			
			string sql = "insert APPTBO(AP_REGNO,CU_REF,SEQ,DOCID,AT_RECEIVEDATE,DOCTYPE,AT_FIX,AT_FLAG) values ('"+LBL_REGNO.Text+"','"+LBL_CUREF.Text+"',"+jml.ToString()+",'"+DDL_NEWITEM.SelectedValue.Trim()+"',getdate(),'1','0','1')";
			conn.QueryString = sql;
			conn.ExecuteNonQuery();
			ViewData();
		}

		private void DDL_NEWITEM_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void DGR_DU_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string docid = e.Item.Cells[0].Text.Trim();
			string seq = e.Item.Cells[13].Text;
			string sql1 = "select MANDATORY,AT_FLAG from tbolist a join apptbo app on a.docid = app.docid where a.DOCID = '"+docid+"' and DOCTYPE = '1' and AT_RECEIVEDATE = '"+e.Item.Cells[12].Text.Trim()+"' and app.ap_regno = '"+LBL_REGNO.Text+"' and app.SEQ = "+seq+"";
			conn.QueryString = sql1;
			conn.ExecuteQuery();

			string sql = "delete apptbo where ap_regno = '" + LBL_REGNO.Text + 
				"' and DOCID = '" + docid + 
				"' and DOCTYPE = '1' " + 
				" and AT_RECEIVEDATE = '" + e.Item.Cells[12].Text.Trim() + 
				"' and DOCTYPE = '1' " + 
				" and SEQ = " + seq + "";
			conn.QueryString = sql;
			conn.ExecuteNonQuery();
			ViewData();
			/*
			if ((conn.GetFieldValue("MANDATORY") == "0") || (conn.GetFieldValue("AT_FLAG") == "1"))
			{
				string sql = "delete apptbo where ap_regno = '"+LBL_REGNO.Text+"' and DOCID = '"+docid+"' and DOCTYPE = '1' and AT_RECEIVEDATE = '"+e.Item.Cells[12].Text.Trim()+"' and DOCTYPE = '1' and SEQ = "+seq+"";
				conn.QueryString = sql;
				conn.ExecuteNonQuery();
				ViewData();
			}
			else
			{
				
				Tools.popMessage(Page,"This item is mandatory");	
			}
			*/
		}

		protected void DGR_DU_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}
	}
}
