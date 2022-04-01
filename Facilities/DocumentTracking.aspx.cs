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
	/// Summary description for DocumentTracking.
	/// </summary>
	public partial class DocumentTracking : System.Web.UI.Page
	{
	
		protected Connection conn;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if(!IsPostBack)
			{
				TXT_AP_REGNO.Text = Request.QueryString["regno"];
				ViewData();
				BindDataRecv();
				fillDLL();
				BindDataSend();
			}
			ViewMenu();
			BTN_SEND.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1)){return false;};");
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
						if (conn.GetFieldValue(i,3).IndexOf("na=") < 0) strtemp += "&" + Request.QueryString["na"];
						//t.ForeColor = Color.MidnightBlue; 
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

		private void fillDLL()
		{
			GlobalTools.fillRefList(DDL_SENDTOBRANCH, "select branch_code, branch_name from vw_rfbranch ", conn);
			GlobalTools.fillRefList(DDL_PURPOSEID, "select * from rfdoctrackpurpose where active = '1'", conn);
			fillSENDTO();

			conn.QueryString = "select CU_JNSNASABAH from CUSTOMER where CU_REF = '" + TXT_CU_REF.Text + "' ";
			conn.ExecuteQuery();
			string jnsnasabah = conn.GetFieldValue("CU_JNSNASABAH");
			string sql = "";
			if (jnsnasabah == "A")
				sql = "select distinct a.DOCID,DOCDESC from TBOLIST a join RFTBODOC b on a.DOCID = b.DOCID and ACTIVE = '1' and DOCTYPEID ='1' and (JNSNASABAH = 'A' or JNSNASABAH is null)";
			else
				sql = "select distinct a.DOCID, a.DOCID + ' - ' + DOCDESC as DOCDESC from TBOLIST a join RFTBODOC b on a.DOCID = b.DOCID and ACTIVE = '1' and DOCTYPEID ='1' and (JNSNASABAH = 'B' or JNSNASABAH is null)";
			GlobalTools.fillRefList(DDL_NEWITEM, sql, conn);
		}

		private void fillSENDTO()
		{
			string q = "exec F_DOCTRACK_SENDTOLIST '" + (string)Session["UserID"] + "', '" + DDL_SENDTOBRANCH.SelectedValue + "' ";
			GlobalTools.fillRefList(DDL_SENDTO, q, conn);
		}

		private void BindDataRecv()
		{
			string userid = (string) Session["UserID"];
			conn.QueryString = "SELECT * FROM VW_F_DOCTRACK_DOCLIST WHERE AP_REGNO = '"+ TXT_AP_REGNO.Text + "' AND " +
				"( (RECVBY IS NULL AND SENDTO IS NULL) OR SENDTO = '" + userid + "' ) ";
			conn.ExecuteQuery();
			DatGrdRecv.DataSource = conn.GetDataTable().Copy();
			try 
			{
				DatGrdRecv.DataBind();
			} 
			catch 
			{
				try
				{
					DatGrdRecv.CurrentPageIndex = 0;
					DatGrdRecv.DataBind();
				}
				catch {}
			}
			System.Web.UI.WebControls.Image img;
			CheckBox chk;
			for (int i = 0; i < DatGrdRecv.Items.Count; i++)
			{
				//DatGrdRecv.Items[i].Cells[0].Text = ((int)(i + 1)).ToString();

				img = (System.Web.UI.WebControls.Image) DatGrdRecv.Items[i].Cells[4].FindControl("IMG_AT_FIX");
				if(DatGrdRecv.Items[i].Cells[5].Text == "1")
					img.ImageUrl = "../image/Complete.gif";
				else
					img.ImageUrl = "../image/UnComplete.gif";
				img = (System.Web.UI.WebControls.Image) DatGrdRecv.Items[i].Cells[6].FindControl("IMG_ORIGINAL");
				if(DatGrdRecv.Items[i].Cells[7].Text == "1")
					img.ImageUrl = "../image/Complete.gif";
				else if(DatGrdRecv.Items[i].Cells[7].Text == "0")
					img.ImageUrl = "../image/UnComplete.gif";
				else
					img.Visible = false;
				img = (System.Web.UI.WebControls.Image) DatGrdRecv.Items[i].Cells[11].FindControl("IMG_RECEIVE");
				chk = (CheckBox) DatGrdRecv.Items[i].Cells[11].FindControl("CHK_RECEIVE");
				if(DatGrdRecv.Items[i].Cells[12].Text == userid)
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

		private void BindDataSend()
		{
			string userid = (string) Session["UserID"];
			conn.QueryString = "SELECT * FROM VW_F_DOCTRACK_DOCLIST WHERE AP_REGNO = '"+ TXT_AP_REGNO.Text + "' AND " +
				"( RECVBY is not null AND RECVBY = '" + userid + "' ) ";
			conn.ExecuteQuery();
			DatGrdSend.DataSource = conn.GetDataTable().Copy();
			try 
			{
				DatGrdSend.DataBind();
			} 
			catch 
			{
				try
				{
					DatGrdSend.CurrentPageIndex = 0;
					DatGrdSend.DataBind();
				}
				catch {}
			}
			System.Web.UI.WebControls.Image img;
			CheckBox chk;
			//DropDownList ddl, ddlSendTo, ddlSendPurp;
			//ddlSendTo = new DropDownList();
			//ddlSendPurp = new DropDownList();
			//GlobalTools.fillRefList(DDL_SENDTO, "select userid, su_fullname from scuser order by su_fullname ", conn);
			//GlobalTools.fillRefList(DDL_SENDTO, "exec F_DOCTRACK_SENDTOLIST '" + (string)Session["UserID"] + "' ", conn);
			//GlobalTools.fillRefList(DDL_PURPOSEID, "select * from rfdoctrackpurpose where active = '1'", conn);
			TextBox txt;
			Label lbl;
			for (int i = 0; i < DatGrdSend.Items.Count; i++)
			{
				//DatGrdSend.Items[i].Cells[0].Text = ((int)(i + 1)).ToString();

				img = (System.Web.UI.WebControls.Image) DatGrdSend.Items[i].Cells[4].FindControl("IMG_AT_FIX_SEND");
				if(DatGrdSend.Items[i].Cells[5].Text == "1")
					img.ImageUrl = "../image/Complete.gif";
				else
					img.ImageUrl = "../image/UnComplete.gif";

				img = (System.Web.UI.WebControls.Image) DatGrdSend.Items[i].Cells[6].FindControl("IMG_ORIGINAL_SEND");
				chk = (CheckBox) DatGrdSend.Items[i].Cells[6].FindControl("CHK_ORIGINAL");
				if(DatGrdSend.Items[i].Cells[7].Text == "1")
				{
					img.ImageUrl = "../image/Complete.gif";
					chk.Checked = true;
					img.Visible = true;
					chk.Visible = false;
				}
				else if(DatGrdSend.Items[i].Cells[7].Text == "0")
				{
					img.ImageUrl = "../image/UnComplete.gif";
					chk.Checked = false;
					img.Visible = true;
					chk.Visible = false;
				}
				else
				{
					img.Visible = false;
					chk.Visible = true;
				}

				txt = (TextBox) DatGrdSend.Items[i].Cells[10].FindControl("TXT_NOTES");
				txt.Text = convertNBSP(DatGrdSend.Items[i].Cells[11].Text);
				//ddl = (DropDownList) DatGrdSend.Items[i].Cells[8].FindControl("DDL_SENDTO");
				lbl = (Label) DatGrdSend.Items[i].Cells[8].FindControl("LBL_SENDTO");
				if(convertNBSP(DatGrdSend.Items[i].Cells[17].Text) == "")		//if this doc is not been sent, enable sentTo ddl
				{
					/*for (int j = 0; j < ddlSendTo.Items.Count; j++)
					{
						ddl.Items.Add(new ListItem(ddlSendTo.Items[j].Text,ddlSendTo.Items[j].Value));
					}*/
					//ddl.Visible = true;
					lbl.Visible = false;
				}
				else
				{
					lbl.Text = DatGrdSend.Items[i].Cells[19].Text;
					//ddl.Visible = false;
					lbl.Visible = true;
					//txt = (TextBox) DatGrdSend.Items[i].Cells[10].FindControl("TXT_NOTES");
					//txt.Text = convertNBSP(DatGrdSend.Items[i].Cells[11].Text);
					txt.Enabled = false;
				}

				//ddl = (DropDownList) DatGrdSend.Items[i].Cells[9].FindControl("DDL_PURPOSEID");
				lbl = (Label) DatGrdSend.Items[i].Cells[9].FindControl("LBL_DTP_DESC");
				if(convertNBSP(DatGrdSend.Items[i].Cells[17].Text) == "")		//check the SentTo field
				{
					/*for (int k = 0; k < ddlSendPurp.Items.Count; k++)
					{
						ddl.Items.Add(new ListItem(ddlSendPurp.Items[k].Text, ddlSendPurp.Items[k].Value));
					}*/
					//ddl.Visible = true;
					lbl.Visible = false;
				}
				else
				{
					lbl.Text = DatGrdSend.Items[i].Cells[20].Text;
					//ddl.Visible = false;
					lbl.Visible = true;
				}

				img = (System.Web.UI.WebControls.Image) DatGrdSend.Items[i].Cells[18].FindControl("IMG_SEND");
				chk = (CheckBox) DatGrdSend.Items[i].Cells[18].FindControl("CHK_SEND");
				if(convertNBSP(DatGrdSend.Items[i].Cells[17].Text) == "")		//if this doc is not been sent, enable send checkbox
				{
					img.Visible = false;
					chk.Visible = true;
				}
				else
				{
					img.ImageUrl = "../image/Complete.gif";
					chk.Checked = false;
					img.Visible = true;
					chk.Visible = false;
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
			this.DatGrdSend.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrdSend_ItemCommand);

		}
		#endregion

		protected void BTN_RECEIVE_Click(object sender, System.EventArgs e)
		{
			CheckBox chk;
			string regno = TXT_AP_REGNO.Text, doctype, docseq, docid, 
				recvby = (string) Session["UserID"], orig, 
				tc = tool.ConvertNull(Request.QueryString["tc"]), 
				purp, note;
			for(int i = 0; i < DatGrdRecv.Items.Count; i++)
			{
				chk = (CheckBox) DatGrdRecv.Items[i].Cells[11].FindControl("CHK_RECEIVE");
				if (chk.Checked)
				{
					doctype = DatGrdRecv.Items[i].Cells[13].Text;
					docseq = DatGrdRecv.Items[i].Cells[14].Text;
					docid = DatGrdRecv.Items[i].Cells[15].Text;
					orig = "NULL";
					if(DatGrdRecv.Items[i].Cells[7].Text == "1")
						orig = "'1'";
					else if(DatGrdRecv.Items[i].Cells[7].Text == "0")
						orig = "'0'";
					purp = tool.ConvertNull(convertNBSP(DatGrdRecv.Items[i].Cells[16].Text));
					note = tool.ConvertNull(convertNBSP(DatGrdRecv.Items[i].Cells[10].Text));
					conn.QueryString = "EXEC F_DOCTRACK_RECV '" + regno + "', '" + doctype + "', " + docseq +
						", '" + docid + "', '" + recvby + "', " + orig + ", " + tc + ", " + purp + ", " + note;
					conn.ExecuteNonQuery();
				}
			}
			BindDataRecv();
			BindDataSend();
		}

		protected void BTN_SEND_Click(object sender, System.EventArgs e)
		{
			//DropDownList ddl;
			TextBox txt;
			CheckBox chk;
			string regno = TXT_AP_REGNO.Text, doctype, docseq, docid, 
				sentby = (string) Session["UserID"], orig, 
				tc = tool.ConvertNull(Request.QueryString["tc"]), 
				purp, note, sendto;
			sendto = DDL_SENDTO.SelectedValue;
			purp = tool.ConvertNull(DDL_PURPOSEID.SelectedValue);
			if (sendto == "")
				return;
			for(int i = 0; i < DatGrdSend.Items.Count; i++)
			{
				chk = (CheckBox) DatGrdSend.Items[i].Cells[18].FindControl("CHK_SEND");
				if (chk.Checked)
				{
					//ddl = (DropDownList) DatGrdSend.Items[i].Cells[8].FindControl("DDL_SENDTO");
					//sendto = convertNBSP(ddl.SelectedValue);
					//if (sendto != "")		//ensure that receiver has been set
					//{
						doctype = DatGrdSend.Items[i].Cells[13].Text;
						docseq = DatGrdSend.Items[i].Cells[14].Text;
						docid = DatGrdSend.Items[i].Cells[15].Text;
						chk = (CheckBox) DatGrdSend.Items[i].Cells[6].FindControl("CHK_ORIGINAL");
						orig = "0";
						if (chk.Checked)
							orig = "1";
						//ddl = (DropDownList) DatGrdSend.Items[i].Cells[9].FindControl("DDL_PURPOSEID");
						//purp = tool.ConvertNull(convertNBSP(ddl.SelectedValue));
						txt = (TextBox) DatGrdSend.Items[i].Cells[10].FindControl("TXT_NOTES");
						note = tool.ConvertNull(convertNBSP(txt.Text));
						conn.QueryString = "EXEC F_DOCTRACK_SEND '" + regno + "', '" + doctype + "', " + docseq +
							", '" + docid + "', '" + sendto + "', '" + sentby + "', '" + orig + "', " + tc + ", " + purp + ", " + note;
						conn.ExecuteNonQuery();
					//}
				}
			}
			BindDataSend();
			try
			{
				DDL_SENDTO.SelectedIndex = 0;
				DDL_PURPOSEID.SelectedIndex = 0;
			}
			catch{}
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			string recvby = (string) Session["UserID"],
				tc = tool.ConvertNull(Request.QueryString["tc"]), 
				orig = "0";
			if (CHK_NEWITEM_ORIGINAL.Checked)
				orig = "1";
			if (DDL_NEWITEM.SelectedValue != "")
			{
				conn.QueryString = "select isnull(max(SEQ),0) + 1 seq from APPDOCLIST where CU_REF = '" + TXT_CU_REF.Text + "' and DOCTYPE = '1'";
				conn.ExecuteQuery();
				int jml = Convert.ToInt32(conn.GetFieldValue("seq"));
			
				conn.QueryString = "insert APPDOCLIST(AP_REGNO,CU_REF,SEQ,DOCID,AT_RECEIVEDATE,DOCTYPE,AT_FIX,AT_FLAG) " +
					"values ('" + TXT_AP_REGNO.Text + "','" + TXT_CU_REF.Text + "'," + jml.ToString() + ",'" + DDL_NEWITEM.SelectedValue + "',getdate(),'1','1','1')";
				conn.ExecuteNonQuery();

				conn.QueryString = "EXEC F_DOCTRACK_RECV '" + TXT_AP_REGNO.Text + "', '1', " + jml.ToString() +
					", '" + DDL_NEWITEM.SelectedValue + "', '" + recvby + "', '" + orig + "', " + tc + ", NULL, NULL" ;
				conn.ExecuteNonQuery();

				BindDataRecv();
				BindDataSend();
			}
			try
			{
				CHK_NEWITEM_ORIGINAL.Checked = false;
				DDL_NEWITEM.SelectedIndex = 0;
			}
			catch{}
		}

		private void DatGrdSend_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string regno = TXT_AP_REGNO.Text, doctype, docseq;
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					doctype = e.Item.Cells[13].Text;
					docseq = e.Item.Cells[14].Text;
					conn.QueryString = "select original, dtregno, tboregno, sendto from VW_F_DOCTRACK_CHECKDOC " +
						"where ap_regno = '" + regno + "' and doctype = '" + doctype + "' and docseq = " + docseq;
					conn.ExecuteQuery();
					if (conn.GetRowCount() > 0)
					{
						if (conn.GetFieldValue(0,"original") == "1")
						{
							GlobalTools.popMessage(this, "Original Document cannot be deleted!");
						}
						else if (conn.GetFieldValue(0,"tboregno") != "")
						{
							GlobalTools.popMessage(this, "DTBO Document cannot be deleted!");
						}
						else if (conn.GetFieldValue(0,"sendto") != "")
						{
							GlobalTools.popMessage(this, "Sent Document cannot be deleted!");
						}
						else
						{
							conn.QueryString = "EXEC F_DOCTRACK_DELDOCLIST '" + regno +
								"', '" + doctype + "', " + docseq;
							conn.ExecuteNonQuery();
						}
					}
					BindDataSend();
					break;
				default:
					break;
			}
		}

		protected void DDL_SENDTOBRANCH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillSENDTO();
		}
	}
}
