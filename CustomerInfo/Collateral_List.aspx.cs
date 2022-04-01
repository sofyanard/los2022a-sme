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
	/// Summary description for Jaminan_List.
	/// </summary>
	public partial class Collateral_List : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				conn.QueryString = "select * from RFCOLLATERALTYPE order by coltypeid";
				conn.ExecuteQuery();
				int row = conn.GetRowCount();
				for (int i = 0; i<row; i++)
				{
					DDL_CL_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i, 1)+" - "+ conn.GetFieldValue(i, 2), conn.GetFieldValue(i, 0)));
				}
			}
			ViewData();

			SecureData();
		}

		private void SecureData() 
		{
			BTN_SAVE.Enabled = false;
			BTN_DELETE.Enabled = false;
			//Button1.Enabled = false;
		}

		private void ViewData()
		{
			string curef = Request.QueryString["curef"];
			conn.QueryString = "select CL.CL_SEQ, CL.CL_TYPE, CT.COLTYPEDESC, CT.COLLINKTABLE, CL.CL_DESC "+
				"from COLLATERAL CL "+
				"join RFCOLLATERALTYPE CT on CL.CL_TYPE = CT.COLTYPESEQ "+
				"where CU_REF = '"+ curef +"'";
			conn.ExecuteQuery();
			
			int tblRowCount = Table_List.Rows.Count;
			for (int i = tblRowCount - 1; i >= 0; i--)
				Table_List.Rows.Remove(Table_List.Rows[i]);

			int row = conn.GetRowCount();
			int rowtemp = row;
			int CL_TYPE;
			int CL_SEQ;
			TXT_JML_JAMINAN.Text = row.ToString();
			for (int i = 0; i < row; i++)
			{
				HyperLink t = new HyperLink();
				t.Text = conn.GetFieldValue(i, 0)+". "+conn.GetFieldValue(i, 4)+" ("+conn.GetFieldValue(i, 2)+")";
				t.CssClass = "TDBGColor1";
				t.Font.Bold = true;

				CL_SEQ	= Convert.ToInt16(conn.GetFieldValue(i, 0));
				CL_TYPE = Convert.ToInt16(conn.GetFieldValue(i, 1));
				
				if(Request.QueryString["regno"].EndsWith("C"))
				{
					t.NavigateUrl = conn.GetFieldValue(i, 3) +".aspx?curef="+ curef +"&coltypeid="+ CL_TYPE +"&CL_SEQ="+ CL_SEQ+"&de=100&sta="+Request.QueryString["sta"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"];
				}
				else
				{
					//t.NavigateUrl = conn.GetFieldValue(i, 4) + "curef="+Request.QueryString["curef"]+"&colid="+conn.GetFieldValue(i, 1)+"&coltype="+conn.GetFieldValue(i, 2);
					t.NavigateUrl = conn.GetFieldValue(i, 3) +".aspx?curef="+ curef +"&coltypeid="+ CL_TYPE +"&CL_SEQ="+ CL_SEQ+"&&de=1&sta="+Request.QueryString["sta"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"];
				}
				t.Target = "coldetail";
				CheckBox t1 = new CheckBox();
				t1.ID = "check" + i ;
				TextBox t2 = new TextBox();
				t2.ID = "cl_seq" + i;
				t2.Text = CL_SEQ.ToString();
				t2.Visible = false;
				TextBox t3 = new TextBox();
				t3.ID = "coltype" + i;
				t3.Text = CL_TYPE.ToString();
				t3.Visible = false;
				this.Table_List.Rows.Add(new TableRow());
				this.Table_List.Rows[i].Cells.Add(new TableCell());
				this.Table_List.Rows[i].Cells[0].Controls.Add(t);
				this.Table_List.Rows[i].Cells.Add(new TableCell());
				this.Table_List.Rows[i].Cells[1].Controls.Add(t1);
				this.Table_List.Rows[i].Cells.Add(new TableCell());
				this.Table_List.Rows[i].Cells[1].Controls.Add(t2);
				this.Table_List.Rows[i].Cells[1].Controls.Add(t3);
			}
			conn.ClearData();
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

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec DE_COLL '0', '"+ Request.QueryString["curef"] + "', 0, "+
				DDL_CL_TYPE.SelectedValue +", 0, '', null, null" ;
			conn.ExecuteQuery();
			ViewData();
			Response.Write("<script language='JavaScript'>window.parent.document.getElementById('scola').src='InfoCollateral.aspx?sta="+Request.QueryString["sta"]+"&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"]+"';</script>");
		}

		protected void BTN_DELETE_Click(object sender, System.EventArgs e)
		{
			int row = Convert.ToInt16(TXT_JML_JAMINAN.Text);
			for (int i=0; i<row; i++)
			{
				if (((CheckBox)Table_List.FindControl("check"+ i)).Checked == true)
				{
					conn.QueryString = "select ap_regno from VW_CUSTOMER_COLLATERAL_CHECKDELETE where cu_ref='"+Request.QueryString["curef"]+"' and cl_seq="+tool.ConvertNum(((TextBox)Table_List.FindControl("cl_seq"+ i)).Text);
					//conn.QueryString = "select ap_regno from ListCollateral where cu_ref='"+Request.QueryString["curef"]+"' and cl_seq="+tool.ConvertNum(((TextBox)Table_List.FindControl("cl_seq"+ i)).Text);
					conn.ExecuteQuery();
					int row1 = conn.GetRowCount();
					conn.ClearData();
					if (row1>0)
						Tools.popMessage(this,"This Collateral already used !");
					else
					{
						conn.QueryString = "exec DE_COLL '2', '"+ Request.QueryString["curef"] + "', "+ 
							((TextBox)Table_List.FindControl("cl_seq"+ i)).Text +", "+
							((TextBox)Table_List.FindControl("coltype"+ i)).Text +", 0, '', null, null" ;
						conn.ExecuteQuery();
					}
				}
			}
			ViewData();	
			Response.Write("<script language='JavaScript'>window.parent.document.getElementById('scola').src='InfoCollateral.aspx?sta="+Request.QueryString["sta"]+"&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"]+"';</script>");
		}
	}
}
