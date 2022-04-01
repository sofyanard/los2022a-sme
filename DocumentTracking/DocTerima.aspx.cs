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

namespace DocumentTracing
{
	/// <summary>
	/// Summary description for DocUmum.
	/// </summary>
	public partial class DocTerima : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SME;uid=sa;pwd=;Pooling=true");
		//protected Connection conn = new Connection("Data Source=localhost;Initial Catalog=SME;uid=sa;pwd=");
		protected Connection conn;
		protected System.Web.UI.WebControls.DataGrid Datagrid1;
		protected string MyStrTemp;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			string sta = Request.Form["sta"];
			if (!IsPostBack)
			{
				string str;
				LBL_REGNO.Text  = Request.QueryString["regno"];
				LBL_CUREF.Text  = Request.QueryString["curef"];
				LBL_MC.Text		= Request.QueryString["mc"];
				str="select MENUCODE,MENUDISPLAY from rfmenu";
				GlobalTools.fillRefList(DDL_StageFrom,str,conn);
				GlobalTools.fillRefList(DDL_StageTo,str,conn);
				str="select * from scgroup";
				GlobalTools.fillRefList(DDL_SCGROUP,str,conn);
				ViewData();
			}
			ViewMenu(); 
			//ViewMenuLocal();
			//ViewKirimTerima();
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


		private void ViewData()
		{

			string str;
			string USERID = Session["UserID"].ToString();
			str="select * from docrcv where AP_REGNO = '" + LBL_REGNO.Text+
			"' and ap_regno not in (select ap_regno from docsend)";
			if(!DDL_StageTo.SelectedValue.Equals(""))
			{
				str=str+ " and rcvsm='" + DDL_StageTo.SelectedValue   + "'";
			}
			conn.QueryString = str;
			conn.ExecuteQuery();
			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_LIST.DataSource = data;
			DGR_LIST.DataBind();


			if(LBL_MC.Text.Equals("003"))
			{
				DGR_KIRIM.Columns[6].Visible=false;
				DGR_KIRIM.Columns[7].Visible=true;
				str="select a.docid,a.ap_regno,a.cu_ref,seq,b.DOCDESC as description, "+
				" convert(varchar,AT_RECEIVEDATE,103) as sentdate, "+
				" '' notes,ap_username SentTo,'' original from apptbo a "+
				" inner join rftbodoc b on a.docid=b.docid "+
				" inner join application c on a.ap_regno=c.ap_regno "+
				" where a.ap_regno='" + LBL_REGNO.Text + 
				"' and a.ap_regno not in (select ap_regno from docrcv)";			
			}
			else
			{
				DGR_KIRIM.Columns[6].Visible=true;
				DGR_KIRIM.Columns[7].Visible=false;
				str="select * from docsend where AP_REGNO = '" + LBL_REGNO.Text + 
				"' and ap_regno not in (select ap_regno from docrcv) ";
			}
			if(!DDL_StageFrom.SelectedValue.Equals(""))
			{
				str=str+ " and sendsm='" + DDL_StageFrom.SelectedValue   + "'";
			}
			conn.QueryString = str;
			conn.ExecuteQuery();
			DataTable dataK = new DataTable();
			dataK = conn.GetDataTable().Copy();
			DGR_KIRIM.DataSource = dataK;
			DGR_KIRIM.DataBind();

			if(LBL_MC.Text=="003"||LBL_MC.Text=="018"||LBL_MC.Text=="004")
			{
				LBL_STAGEFROM.Visible=false;
				LBL_STAGETO.Visible=false;
				LBL_SENDTO.Visible=false;
				DDL_StageFrom.Visible=false;
				DDL_StageTo.Visible=false;
				DDL_SCGROUP.Visible=false;
			}

		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						if (conn.GetFieldValue(i,3).IndexOf("cp=") < 0) strtemp += "&"+Request.QueryString["cp"];
						MyStrTemp=strtemp;
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		protected void BTN_RCV_Click(object sender, System.EventArgs e)
		{
			string docid,recdate,description,sentto,catatan,str;
			bool original;
			for(int i = 0; i < DGR_KIRIM.Items.Count; i++)
			{
				TextBox txt = (TextBox) DGR_KIRIM.Items[i].Cells[3].FindControl("TXT_NOTES");
				CheckBox chk = (CheckBox) DGR_KIRIM.Items[i].Cells[5].FindControl("CHK_ORIGINAL");
				docid=DGR_KIRIM.Items[i].Cells[0].Text; 
				description=DGR_KIRIM.Items[i].Cells[1].Text; 
				recdate=DGR_KIRIM.Items[i].Cells[2].Text; 
				catatan=txt.Text ; 
				sentto=DGR_KIRIM.Items[i].Cells[4].Text; 
				original=chk.Checked;
				str="insert into docrcv(AP_REGNO,DOCID,Description,RecDate," +
				" Notes,sentto,Original,RcvSM) values('" + LBL_REGNO.Text + 
				"','" + docid + "','" + description + 
				"'," + GlobalTools.ToSQLDate(recdate) + ",'" + catatan + "','" + sentto + "','" +
				original.ToString()  + "','" + DDL_StageFrom.SelectedValue   + "')";
				conn.QueryString=str;
				conn.ExecuteNonQuery();
			}
			ViewData();
		}

		protected void BTN_SEND_Click(object sender, System.EventArgs e)
		{
			string docid,recdate,description,sendby,catatan,str,original;
			for(int i = 0; i < DGR_LIST.Items.Count; i++)
			{
				TextBox txt1 = (TextBox) DGR_LIST.Items[i].Cells[3].FindControl("TXT_NOTES1");
				docid=DGR_LIST.Items[i].Cells[0].Text; 
				description=DGR_LIST.Items[i].Cells[1].Text; 
				recdate=DGR_LIST.Items[i].Cells[2].Text; 
				catatan=txt1.Text ; 
				sendby=DGR_LIST.Items[i].Cells[4].Text; 
				original=DGR_LIST.Items[i].Cells[5].Text;
				str="insert into docsend(AP_REGNO,DOCID,Description,sendDate," +
					" Notes,sendby,Original,SendSM) values('" + LBL_REGNO.Text + 
					"','" + docid + "','" + description + 
					"'," + GlobalTools.ToSQLDate(recdate) + ",'" + catatan + "','" + sendby + "','" +
					original  + "','" + DDL_StageTo.SelectedValue  + "')";
				conn.QueryString=str;
				conn.ExecuteNonQuery();
			}
			ViewData();
		}

		protected void DDL_SCGROUP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		}

		protected void DDL_StageTo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewData();			
		}

		protected void DDL_StageFrom_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewData();			
		}

	}
}        
