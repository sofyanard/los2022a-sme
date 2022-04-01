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
	public partial class DocKirim : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
		protected string MyStrTemp;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			string sta = Request.Form["sta"];
			if (!IsPostBack)
			{
				LBL_REGNO.Text  = Request.QueryString["regno"];
				LBL_CUREF.Text  = Request.QueryString["curef"];
				
				ViewData();
				conn.QueryString = "select CU_JNSNASABAH from customer where cu_ref = '"+LBL_CUREF.Text+"'";
				conn.ExecuteQuery();
				string jnsnasabah = conn.GetFieldValue("CU_JNSNASABAH");
				if (jnsnasabah == "A")
				{
					string sql = "select distinct a.DOCID,DOCDESC from TBOLIST a join RFTBODOC b on a.DOCID = b.DOCID and ACTIVE = '1' and DOCTYPEID ='1' and (JNSNASABAH = 'A' or JNSNASABAH is null)";
					conn.QueryString = sql;
					conn.ExecuteQuery();
				}
				else
				{
					string sql = "select distinct a.DOCID,DOCDESC from TBOLIST a join RFTBODOC b on a.DOCID = b.DOCID and ACTIVE = '1' and DOCTYPEID ='1' and (JNSNASABAH = 'B' or JNSNASABAH is null)";
					conn.QueryString = sql;
					conn.ExecuteQuery();
				}
				DDL_NEWITEM.Items.Clear();
				
				for (int i = 0;i < conn.GetRowCount();i++)
				{
					DDL_NEWITEM.Items.Add(new ListItem (conn.GetFieldValue(i,"DOCDESC"),conn.GetFieldValue(i,"DOCID")));
				}

			}
			ViewMenu();
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
			this.DGR_LIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_LIST_ItemCommand);

		}
		#endregion


		protected void Button1_Click(object sender, System.EventArgs e)
		{
			string USERID = Session["UserID"].ToString();
			string sql1 = "select isnull(max(SEQ),0) + 1 seq from " +
			" SENDRECEIVEDOCLIST where AP_REGNO = '"+ LBL_REGNO.Text  +"'";
			conn.QueryString = sql1;
			conn.ExecuteQuery();
			int jml = Convert.ToInt32(conn.GetFieldValue("seq"));	
			
			string sql = "SELECT * FROM SENDRECEIVEDOCLIST WHERE " +
				"AP_REGNO='"+LBL_REGNO.Text+"' and " +
				"DOCID='"+ DDL_NEWITEM.SelectedValue.Trim() +"'";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			int sudahAda = Convert.ToInt32(conn.GetRowCount());
			if(sudahAda>0) 
			{
				Tools.popMessage(this,"Document Sudah ada");
			}
			else
			{

				sql = "insert SENDRECEIVEDOCLIST(AP_REGNO,SEQ,DOCID," + 
					" SEND_DATE,RECEIVE_BY,SEND_BY,HASUPDATED)  values ('"+LBL_REGNO.Text+"'," +
					jml.ToString()+
					",'" + DDL_NEWITEM.SelectedValue.Trim()+"',getdate(),'" + 
					USERID +"','',1)";
				conn.QueryString = sql;
				conn.ExecuteNonQuery();
				sql = "insert SENDRECEIVEDOCLISTHISTORY(AP_REGNO,SEQ,DOCID," + 
					" SEND_DATE,RECEIVE_BY,SEND_BY)  values ('"+LBL_REGNO.Text+"'," +
					jml.ToString()+
					",'" + DDL_NEWITEM.SelectedValue.Trim()+"',getdate(),'" + 
					USERID +"','')";
				conn.QueryString = sql;
				conn.ExecuteNonQuery();
				ViewData();
			}
		}

		private void ViewData()
		{
			string str="select a.*,b.docdesc from SENDRECEIVEDOCLIST a  " + 
				" inner join RFTBODOC b on a.docid=b.docid where AP_REGNO = '" + 
				LBL_REGNO.Text+"' and a.send_by<>a.receive_by";
			conn.QueryString = str;
			conn.ExecuteQuery();
			DataTable dataK = new DataTable();
			dataK = conn.GetDataTable().Copy();
			DGR_LIST.DataSource = dataK;
			DGR_LIST.DataBind();
		}

		private void ViewMenu()
		{
			try 
			{
				string sql="select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.QueryString = sql;
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





		private void DGR_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string USERID = Session["UserID"].ToString();
			if (e.CommandName.Equals("Kirim"))
			{
				string docid = e.Item.Cells[0].Text.Trim();
				string seq = e.Item.Cells[1].Text;
				string sql = "update sendreceivedoclist set " +
					" send_date=getdate(),sent_menucode='" + 
					LBL_MC.Text + "',SEND_BY='" + USERID + "'" + 
					",HASUPDATED=2" +
					" where ap_regno = '"+LBL_REGNO.Text+"' and DOCID = '"+
					docid +"'";
				conn.QueryString = sql;
				conn.ExecuteNonQuery();
				
				string sql1 = "select isnull(max(SEQ),0) + 1 seq " +
					" from SENDRECEIVEDOCLISTHISTORY where AP_REGNO = '"+ 
					LBL_REGNO.Text  +"' and DOCID = '"+ docid  
					+ "' and receive_by='" + USERID  + "'";
				conn.QueryString = sql1;
				conn.ExecuteQuery();
				int jml = Convert.ToInt32(conn.GetFieldValue("seq"));						
				
				sql = "insert SENDRECEIVEDOCLISTHISTORY(AP_REGNO,SEQ,DOCID," +
					" send_BY,send_DATE,sent_menucode)  values ('"+
					LBL_REGNO.Text+"',"+jml.ToString()+",'" + 
					docid  +"','" + USERID  + 
					"',getdate(),'" + LBL_MC.Text + "')";
				conn.QueryString = sql;
				conn.ExecuteNonQuery();
			}
			else if(e.CommandName.Equals("Delete"))
			{
				string docid = e.Item.Cells[0].Text.Trim();
				string seq = e.Item.Cells[1].Text;
				string sql = "delete sendreceivedoclist where ap_regno = '"+LBL_REGNO.Text+"' and DOCID = '"+docid+"' and SEQ = "+seq+"";
				conn.QueryString = sql;
				conn.ExecuteNonQuery();
			}
			ViewData();
		}

		protected void DGR_LIST_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
		
		}

	}
}        
