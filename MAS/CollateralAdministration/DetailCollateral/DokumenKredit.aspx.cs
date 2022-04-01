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
using System.Configuration;
using DMS.DBConnection;
using DMS.CuBESCore;
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;

namespace SME.MAS.CollateralAdministration.DetailCollateral
{
	/// <summary>
	/// Summary description for DokumenKredit.
	/// </summary>
	public partial class DokumenKredit : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{		
				lbl_col_id.Text=Request.QueryString["collateral_id"];
				lbl_regno2.Text=Request.QueryString["acc_number"];
				lbl_kredit.Text=Request.QueryString["kredit"];
				ListDoc();
				ViewData();				
			}
		}

		private void ListDoc()
		{
			if (lbl_kredit.Text=="0")
			{
				conn.QueryString="select * from MAS_RFDOC where IS_DOC_KREDIT='0'";
			}

			else
			{
				conn.QueryString="select * from MAS_RFDOC where IS_DOC_KREDIT='1'";
			}

			
			conn.ExecuteQuery();
			for (int i = 0;i < conn.GetRowCount();i++)
			{
				DDL_NEWITEM.Items.Add(new ListItem (conn.GetFieldValue(i,"DOCDESC"),conn.GetFieldValue(i,"DOCID")));
			}
		}

		private void ViewData()
		{
			if (lbl_kredit.Text=="0")
			{
				conn.QueryString="select * from mas_col_doc a " +
								 " left join MAS_RFDOC r on a.doc_id=r.docid  " +
								 "where a.acc_number='" + Request.QueryString["acc_number"] + 
								 "' and a.collateral_id='" + Request.QueryString["collateral_id"] +
					             "' and r.IS_DOC_KREDIT='0'";				
			}

			else
			{
				conn.QueryString="select * from mas_col_doc a " +
					" left join MAS_RFDOC r on a.doc_id=r.docid  " +
					"where a.acc_number='" + Request.QueryString["acc_number"] + 
					"' and r.IS_DOC_KREDIT='1'";
			}

            
			conn.ExecuteQuery();	
			FillGridResult();
		}

		private void FillGridResult()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_DU.DataSource = dt;
			try 
			{
				DGR_DU.DataBind();
			} 
			catch 
			{
				DGR_DU.CurrentPageIndex = 0;
				DGR_DU.DataBind();
			}

			conn.QueryString="select acc_status from VW_MAS_INPUT_NEW_COLLATERAL" +
				" where acc_number='" + Request.QueryString["acc_number"] + "'" +
				" and collateral_id='" + Request.QueryString["collateral_id"] + "'";

			conn.ExecuteQuery();	

			if (conn.GetFieldValue("acc_status")=="2")
			{
				DGR_DU.Columns[16].Visible=false;
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
			this.DGR_DU.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_DU_ItemCommand);
			this.DGR_DU.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_DU_PageIndexChanged);
			this.DGR_DU.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGR_DU_ItemDataBound);

		}
		#endregion

		private void DGR_DU_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Delete":
					UpdateData("delete",DDL_NEWITEM.SelectedValue,DDL_NEWITEM.SelectedItem.Text,"","''","","''",e.Item.Cells[17].Text,"''","''","");
					
					ViewData();
					break;
			}
		}

		private void DGR_DU_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_DU.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}

		private void DGR_DU_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{            
			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) 
			{
				System.Web.UI.WebControls.TextBox expday=(System.Web.UI.WebControls.TextBox)e.Item.FindControl("TXT_EXPDATEDAY");
				System.Web.UI.WebControls.TextBox expyear=(System.Web.UI.WebControls.TextBox)e.Item.FindControl("TXT_EXPDATEYEAR");
				System.Web.UI.WebControls.TextBox recday=(System.Web.UI.WebControls.TextBox)e.Item.FindControl("TXT_RECEIVEDATEDAY");
				System.Web.UI.WebControls.TextBox recyear=(System.Web.UI.WebControls.TextBox)e.Item.FindControl("TXT_RECEIVEDATEYEAR");

				System.Web.UI.WebControls.TextBox terbitday=(System.Web.UI.WebControls.TextBox)e.Item.FindControl("terbitday");
				System.Web.UI.WebControls.TextBox terbitthn=(System.Web.UI.WebControls.TextBox)e.Item.FindControl("terbitthn");
				System.Web.UI.WebControls.TextBox terimaday=(System.Web.UI.WebControls.TextBox)e.Item.FindControl("terimaday");
				System.Web.UI.WebControls.TextBox terimathn=(System.Web.UI.WebControls.TextBox)e.Item.FindControl("terimathn");

				System.Web.UI.WebControls.TextBox ket=(System.Web.UI.WebControls.TextBox)e.Item.FindControl("TXT_KETERANGAN");

				System.Web.UI.WebControls.CheckBox avail=(System.Web.UI.WebControls.CheckBox)e.Item.FindControl("CHB_AT_FIX");

				System.Web.UI.WebControls.DropDownList expmonth=(System.Web.UI.WebControls.DropDownList)e.Item.FindControl("DDL_EXPDATEMONTH");
				System.Web.UI.WebControls.DropDownList recmonth=(System.Web.UI.WebControls.DropDownList)e.Item.FindControl("DDL_RECEIVEDATEMONTH");

				System.Web.UI.WebControls.DropDownList terbitbln=(System.Web.UI.WebControls.DropDownList)e.Item.FindControl("terbitbln");
				System.Web.UI.WebControls.DropDownList terimabln=(System.Web.UI.WebControls.DropDownList)e.Item.FindControl("terimabln");

				if (e.Item.Cells[3].Text=="1")
				{
					avail.Checked=true;
				}
				else
				{
					avail.Checked=false;
				}

				expmonth.Items.Add(new ListItem("--Pilih--",""));
				recmonth.Items.Add(new ListItem("--Pilih--",""));

				terbitbln.Items.Add(new ListItem("--Pilih--",""));
				terimabln.Items.Add(new ListItem("--Pilih--",""));
				
				for(int i=1; i<=12; i++)
				{
					expmonth.Items.Add(new ListItem(DateAndTime.MonthName(i, true), i.ToString()));
					recmonth.Items.Add(new ListItem(DateAndTime.MonthName(i, true), i.ToString()));

					terbitbln.Items.Add(new ListItem(DateAndTime.MonthName(i, true), i.ToString()));
					terimabln.Items.Add(new ListItem(DateAndTime.MonthName(i, true), i.ToString()));
				}

				terbitday.Text=tool.FormatDate_Day(e.Item.Cells[5].Text); 
				terbitthn.Text=tool.FormatDate_Year(e.Item.Cells[5].Text);
				terbitbln.SelectedValue=tool.FormatDate_Month(e.Item.Cells[5].Text); 

				terimaday.Text=tool.FormatDate_Day(e.Item.Cells[7].Text); 
				terimathn.Text=tool.FormatDate_Year(e.Item.Cells[7].Text);
				terimabln.SelectedValue=tool.FormatDate_Month(e.Item.Cells[7].Text); 

				expday.Text=tool.FormatDate_Day(e.Item.Cells[9].Text); 
				expyear.Text=tool.FormatDate_Year(e.Item.Cells[9].Text);
				expmonth.SelectedValue=tool.FormatDate_Month(e.Item.Cells[9].Text); 

				ket.Text=e.Item.Cells[11].Text;

				recday.Text=tool.FormatDate_Day(e.Item.Cells[13].Text); 
				recyear.Text=tool.FormatDate_Year(e.Item.Cells[13].Text);
				recmonth.SelectedValue=tool.FormatDate_Month(e.Item.Cells[13].Text);

				if (e.Item.Cells[15].Text=="1")
				{
					expday.CssClass="mandatory";
					expyear.CssClass="mandatory";
					expmonth.CssClass="mandatory";

					terbitday.CssClass="mandatory";
					terbitthn.CssClass="mandatory";
					terbitbln.CssClass="mandatory";

					terimaday.CssClass="mandatory";
					terimathn.CssClass="mandatory";
					terimabln.CssClass="mandatory";

					recday.CssClass="mandatory";
					recmonth.CssClass="mandatory";
					recyear.CssClass="mandatory";
					ket.CssClass="mandatory";
					avail.CssClass="mandatory";
				}

				System.Web.UI.WebControls.LinkButton linkntn=(System.Web.UI.WebControls.LinkButton)e.Item.FindControl("delete");
				linkntn.Attributes.Add("onClick", "return confirm('Apakah Anda yakin akan menghapus data ini?')");
			}
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{		
			string notaris;

			if (ddl_notaris_asuransi.Visible==false || ddl_notaris_asuransi.SelectedValue=="")
			{
				notaris="";
			}
			else
			{
				notaris=ddl_notaris_asuransi.SelectedItem.Text;
			}
			UpdateData("insert",DDL_NEWITEM.SelectedValue,DDL_NEWITEM.SelectedItem.Text,"","''","","''","","''","''",notaris);
			ViewData();
		}

		protected void BTN_save_Click(object sender, System.EventArgs e)
		{
			int i, j;
			j=DGR_DU.Items.Count;

			for(i=0;i<j;i++)
			{
				string check, expdate,recv,terbit,terima;
				check="0";expdate="";recv="";terbit="";terima="";				

				System.Web.UI.WebControls.CheckBox ck=(System.Web.UI.WebControls.CheckBox)DGR_DU.Items[i].FindControl("CHB_AT_FIX");

				System.Web.UI.WebControls.TextBox expday=(System.Web.UI.WebControls.TextBox)DGR_DU.Items[i].FindControl("TXT_EXPDATEDAY");
				System.Web.UI.WebControls.TextBox expyear=(System.Web.UI.WebControls.TextBox)DGR_DU.Items[i].FindControl("TXT_EXPDATEYEAR");

				System.Web.UI.WebControls.TextBox terbitday=(System.Web.UI.WebControls.TextBox)DGR_DU.Items[i].FindControl("terbitday");
				System.Web.UI.WebControls.TextBox terbityear=(System.Web.UI.WebControls.TextBox)DGR_DU.Items[i].FindControl("terbitthn");

				System.Web.UI.WebControls.TextBox terimaday=(System.Web.UI.WebControls.TextBox)DGR_DU.Items[i].FindControl("terimaday");
				System.Web.UI.WebControls.TextBox terimayear=(System.Web.UI.WebControls.TextBox)DGR_DU.Items[i].FindControl("terimathn");

				System.Web.UI.WebControls.TextBox recday=(System.Web.UI.WebControls.TextBox)DGR_DU.Items[i].FindControl("TXT_RECEIVEDATEDAY");
				System.Web.UI.WebControls.TextBox recyear=(System.Web.UI.WebControls.TextBox)DGR_DU.Items[i].FindControl("TXT_RECEIVEDATEYEAR");

				System.Web.UI.WebControls.DropDownList expmonth=(System.Web.UI.WebControls.DropDownList)DGR_DU.Items[i].FindControl("DDL_EXPDATEMONTH");
				System.Web.UI.WebControls.DropDownList recvmonth=(System.Web.UI.WebControls.DropDownList)DGR_DU.Items[i].FindControl("DDL_RECEIVEDATEMONTH");

				System.Web.UI.WebControls.DropDownList terbitbln=(System.Web.UI.WebControls.DropDownList)DGR_DU.Items[i].FindControl("terbitbln");
				System.Web.UI.WebControls.DropDownList terimabln=(System.Web.UI.WebControls.DropDownList)DGR_DU.Items[i].FindControl("terimabln");

				System.Web.UI.WebControls.TextBox keter=(System.Web.UI.WebControls.TextBox)DGR_DU.Items[i].FindControl("TXT_KETERANGAN");

				if (ck.Checked==true)
				{
					check="1";
				}

				expdate=tool.ConvertDate(expday.Text,expmonth.SelectedValue,expyear.Text);
				recv=tool.ConvertDate(recday.Text,recvmonth.SelectedValue,recyear.Text);
				terbit=tool.ConvertDate(terbitday.Text,terbitbln.SelectedValue,terbityear.Text);
				terima=tool.ConvertDate(terimaday.Text,terimabln.SelectedValue,terimayear.Text);

				if (check=="1")
				{
					UpdateData("update", DGR_DU.Items[i].Cells[0].Text,DGR_DU.Items[i].Cells[1].Text,check,expdate,keter.Text,recv,DGR_DU.Items[i].Cells[17].Text,terbit,terima,DGR_DU.Items[i].Cells[2].Text);
				}

				else
				{
					UpdateData("delete",DDL_NEWITEM.SelectedValue,DDL_NEWITEM.SelectedItem.Text,"","''","","''",DGR_DU.Items[i].Cells[17].Text,"''","''","");
				}
				
			}

			ViewData();

		
		}

		private void UpdateData(string mode,string docid, 
			string docdesc, string avail, string exp, 
			string ket, string recv, string seq, string terbit,string terima,string notaris)
		{
			string colid;

			if (lbl_kredit.Text=="0")
			{
				colid=lbl_col_id.Text;
				conn.QueryString="exec mas_insert_doc '"+mode+"','" +
					lbl_regno2.Text + "','" + colid + "','"+
					docid + "','" + docdesc + "','"+
					avail + "'," + exp + ",'"+
					ket + "'," + recv + ",'"+
					seq + "','" + Session["userID"] + "'," + 
					terbit + "," + terima + ",'" + notaris + "'";
			}
			
			else
			{
				colid="NULL";

				conn.QueryString="exec mas_insert_doc '"+mode+"','" +
					lbl_regno2.Text + "','" + colid + "','"+
					docid + "','" + docdesc + "','"+
					avail + "'," + exp + ",'"+
					ket + "'," + recv + ",'"+
					seq + "','" + Session["userID"] + "'," + 
					terbit + "," + terima + ",'" + notaris + "'";
			}

			conn.ExecuteQuery();	

		}

		protected void DDL_NEWITEM_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ddl_notaris_asuransi.Visible=true;
			if(DDL_NEWITEM.SelectedValue=="CNPAK"||
				DDL_NEWITEM.SelectedValue=="PAK"||
				DDL_NEWITEM.SelectedValue=="CNPAJ"||
				DDL_NEWITEM.SelectedValue=="PAJ"||
				DDL_NEWITEM.SelectedValue=="CNN"||
				DDL_NEWITEM.SelectedValue=="SKMHT"||
				DDL_NEWITEM.SelectedValue=="APHT"||
				DDL_NEWITEM.SelectedValue=="Fiducia")
			{
				ddl_notaris_asuransi.Visible=true;
				if(DDL_NEWITEM.SelectedValue=="CNPAK"||
					DDL_NEWITEM.SelectedValue=="PAK"||
					DDL_NEWITEM.SelectedValue=="CNPAJ"||
					DDL_NEWITEM.SelectedValue=="PAJ")
				{conn.QueryString="select seq,name from MAS_RFNOTARIS_ASURANSI where type='2' and branch='" + Session["BranchID"].ToString()+"'";}

				else
				{conn.QueryString="select seq,name from MAS_RFNOTARIS_ASURANSI where type='1' and branch='" + Session["BranchID"].ToString()+"'";}
				
				conn.ExecuteQuery();
				ddl_notaris_asuransi.Items.Clear();
				ddl_notaris_asuransi.Items.Add(new ListItem("--Pilih--",""));
				
				for(int i=1; i<=conn.GetRowCount(); i++)
				{
					ddl_notaris_asuransi.Items.Add(new ListItem(conn.GetFieldValue("NAME"),conn.GetFieldValue("SEQ")));
				}

			}
			else
			{
				ddl_notaris_asuransi.Visible=false;
			}
		}
	}
}
