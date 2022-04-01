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

namespace SME.Facilities
{
	/// <summary>
	/// Summary description for DocumentTrackingRecv.
	/// </summary>
	public partial class DocumentTrackingRecv : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LBL_LASTSTATUS;
		protected System.Web.UI.WebControls.TextBox TXT_SU_NAME;
		protected System.Web.UI.WebControls.TextBox TXT_TRACKNAME;
		protected System.Web.UI.WebControls.TextBox TXT_ADT_DOCTRACKDATE;
		protected System.Web.UI.WebControls.TextBox TXT_ADT_NOTES;
	
		protected Connection conn;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if(!IsPostBack)
			{
				TXT_AP_REGNO.Text = Request.QueryString["regno"];
				ViewData();
				BindData();
				fillDLL();
			}
		}

		private void fillDLL()
		{
			conn.QueryString = "select CU_JNSNASABAH from CUSTOMER where CU_REF = '" + TXT_CU_REF.Text + "' ";
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
				string sql = "select distinct a.DOCID, a.DOCID + ' - ' + DOCDESC as DOCDESC from TBOLIST a join RFTBODOC b on a.DOCID = b.DOCID and ACTIVE = '1' and DOCTYPEID ='1' and (JNSNASABAH = 'B' or JNSNASABAH is null)";
				conn.QueryString = sql;
				conn.ExecuteQuery();
			}
			DDL_NEWITEM.Items.Clear();
				
			for (int i = 0;i < conn.GetRowCount();i++)
			{
				DDL_NEWITEM.Items.Add(new ListItem (conn.GetFieldValue(i,"DOCDESC"),conn.GetFieldValue(i,"DOCID")));
			}
		}

		private void ViewData()
		{
			conn.QueryString = "select * from VW_INFOUMUM "+
				"where AP_REGNO = '"+ TXT_AP_REGNO.Text +"' ";
			conn.ExecuteQuery();
			TXT_AP_REGNO.Text = conn.GetFieldValue(0, "AP_REGNO");
			TXT_CU_REF.Text = conn.GetFieldValue(0, "CU_REF");
			string AP_SIGNDATE = conn.GetFieldValue(0, "AP_SIGNDATE");
			TXT_AP_SIGNDATE.Text = tool.FormatDate(AP_SIGNDATE);
			TXT_PROGRAMDESC.Text = conn.GetFieldValue(0, "PROGRAMDESC");
			TXT_BRANCH_NAME.Text = conn.GetFieldValue(0, "BRANCH_NAME");
			TXT_AP_TMLDRNM.Text = conn.GetFieldValue(0, "AP_TMLDRNM");
			TXT_AP_RMNM.Text = conn.GetFieldValue(0, "AP_RMNM");
			TXT_BU_DESC.Text = conn.GetFieldValue(0, "BU_DESC");
			TXT_CU_NAME.Text = conn.GetFieldValue(0, "CU_NAME");
			TXT_CU_ADDR1.Text = conn.GetFieldValue(0, "CU_ADDR1");
			TXT_CU_ADDR2.Text = conn.GetFieldValue(0, "CU_ADDR2");
			TXT_CU_ADDR3.Text = conn.GetFieldValue(0, "CU_ADDR3");
			TXT_CU_CITYNM.Text = conn.GetFieldValue(0, "CU_CITYNM");
			TXT_CU_PHN.Text = conn.GetFieldValue(0, "CU_PHN");
			TXT_BUSSTYPEDESC.Text = conn.GetFieldValue(0, "BUSSTYPEDESC");
		}

		private void BindData()
		{
			string userid = (string) Session["UserID"];
			conn.QueryString = "SELECT * FROM VW_F_DOCTRACK_DOCLIST WHERE AP_REGNO = '"+ TXT_AP_REGNO.Text + "' AND " +
				"( (RECVBY IS NULL AND SENDTO IS NULL) OR (RECVBY = '" + userid + "' AND SENDTO IS NULL) OR SENDTO = '" + userid + "' ) ";
			conn.ExecuteQuery();
			DatGrd.DataSource = conn.GetDataTable().Copy();
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				try
				{
					DatGrd.CurrentPageIndex = 0;
					DatGrd.DataBind();
				}
				catch {}
			}
			System.Web.UI.WebControls.Image img;
			CheckBox chk;
			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				DatGrd.Items[i].Cells[0].Text = ((int)(i + 1)).ToString();
				img = (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[4].FindControl("IMG_AT_FIX");
				if(DatGrd.Items[i].Cells[5].Text == "1")
					img.ImageUrl = "../image/Complete.gif";
				else
					img.ImageUrl = "../image/UnComplete.gif";
				img = (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[6].FindControl("IMG_ORIGINAL");
				if(DatGrd.Items[i].Cells[7].Text == "1")
					img.ImageUrl = "../image/Complete.gif";
				else if(DatGrd.Items[i].Cells[7].Text == "0")
					img.ImageUrl = "../image/UnComplete.gif";
				else
					img.Visible = false;
				img = (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[11].FindControl("IMG_RECEIVE");
				chk = (CheckBox) DatGrd.Items[i].Cells[11].FindControl("CHK_RECEIVE");
				if(DatGrd.Items[i].Cells[12].Text == userid)
				{
					img.ImageUrl = "../image/Complete.gif";
					chk.Checked = false;
					img.Visible = true;
					chk.Visible = false;
				}
				else
				{
					img.Visible = false;
					chk.Visible = true;
				}
			}
		}

		private string convertNBSP(string str)
		{
			if (str == "&nbsp;")
				return "";
			return str;
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

		protected void BTN_ACTION_Click(object sender, System.EventArgs e)
		{
			CheckBox chk;
			string regno = TXT_AP_REGNO.Text, doctype, docseq, docid, 
				recvby = (string) Session["UserID"], orig, 
				tc = tool.ConvertNull(Request.QueryString["tc"]), 
				purp, note;
			for(int i = 0; i < DatGrd.Items.Count; i++)
			{
				chk = (CheckBox) DatGrd.Items[i].Cells[11].FindControl("CHK_RECEIVE");
				if (chk.Checked)
				{
					doctype = DatGrd.Items[i].Cells[13].Text;
					docseq = DatGrd.Items[i].Cells[14].Text;
					docid = DatGrd.Items[i].Cells[15].Text;
					orig = tool.ConvertNull(convertNBSP(DatGrd.Items[i].Cells[7].Text));
					purp = tool.ConvertNull(convertNBSP(DatGrd.Items[i].Cells[16].Text));
					note = tool.ConvertNull(convertNBSP(DatGrd.Items[i].Cells[10].Text));
					conn.QueryString = "EXEC F_DOCTRACK_RECV '" + regno + "', '" + doctype + "', " + docseq +
						", '" + docid + "', '" + recvby + "', " + orig + ", " + tc + ", " + purp + ", " + note;
					conn.ExecuteNonQuery();
				}
			}
			BindData();
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			string recvby = (string) Session["UserID"],
				tc = tool.ConvertNull(Request.QueryString["tc"]), 
				orig = "0";
			if (CHK_NEWITEM_ORIGINAL.Checked)
				orig = "1";
			conn.QueryString = "select max(SEQ) + 1 seq from APPTBO where CU_REF = '" + TXT_CU_REF.Text + "' and DOCTYPE = '1'";
			conn.ExecuteQuery();
			int jml = Convert.ToInt32(conn.GetFieldValue("seq"));
			
			conn.QueryString = "insert APPTBO(AP_REGNO,CU_REF,SEQ,DOCID,AT_RECEIVEDATE,DOCTYPE,AT_FIX,AT_FLAG) " +
				"values ('" + TXT_AP_REGNO.Text + "','" + TXT_CU_REF.Text + "'," + jml.ToString() + ",'" + DDL_NEWITEM.SelectedValue + "',getdate(),'1','1','1')";
			conn.ExecuteNonQuery();

			conn.QueryString = "EXEC F_DOCTRACK_RECV '" + TXT_AP_REGNO.Text + "', '1', " + jml.ToString() +
				", '" + DDL_NEWITEM.SelectedValue + "', '" + recvby + "', '" + orig + "', " + tc + ", NULL, NULL" ;
			conn.ExecuteNonQuery();

			BindData();
		}
	}
}
